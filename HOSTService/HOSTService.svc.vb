Imports System.Xml
Imports HostCommonLibrary
Imports System.Configuration
Imports Newtonsoft.Json
Imports DataAccessLayer
Imports System.Data
' NOTE: If you change the class name "HOSTService" here, you must also update the reference to "HOSTService" in Web.config and in the associated .svc file.

Public Class HOSTService
    Implements IHOSTService

    Dim LogError As LogError = New LogError()

    Public Sub DoWork() Implements IHOSTService.DoWork
    End Sub

    Public Function GetVersion(ByRef pv_arrByteMessage() As Byte) As Long Implements IHOSTService.GetVersion
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.GetVersion", v_strErrorMessage As String
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlDoc As New XmlDocumentEx
        Dim v_lngErr As Long = 0
        Try
            Dim v_strSQL As String
            v_strSQL = "SELECT * FROM VERSION ORDER BY ACTUALVERSION DESC FETCH FIRST 1 ROW ONLY"


            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String
            Dim v_NewVersion As String
            Dim v_strObjMsg As String = ""
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_lngErr = (New Host.objRouter()).Transfer(v_strObjMsg)


            v_xmlDoc.LoadXml(v_strObjMsg)
            v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
            v_strObjMsg = v_xmlDoc.OuterXml

            LogError.Write("::MessageByte:: [END]" & v_strObjMsg)

            ''Compress message
            v_strObjMsg = TripleDesEncryptData(v_strObjMsg)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(v_strObjMsg)

            Return v_lngErr

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function MessageByte(ByRef pv_arrByteMessage() As Byte) As Long Implements IHOSTService.MessageByte
        Dim v_lngErr As Long = 0
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String
        Dim pv_strMessage As String
        Dim v_xmlDoc As XmlDocument = New XmlDocumentEx()
        Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()

        Try
            ''Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            LogError.Write("::MessageByte:: [BEGIN]" & pv_strMessage)

            ''Read transaction message 
            v_xmlDocumentMessage.LoadXml(pv_strMessage)

            ''Get header message.
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strLOCAL = v_attrColl.GetNamedItem(modCommond.gc_AtributeLOCAL).Value
            Dim v_strMSGTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeMSGTYPE).Value

            Dim checkSign = ConfigurationManager.AppSettings("CheckSign")
            If checkSign = "Y" Then
                Try
                    Dim v_strSignature = v_attrColl.GetNamedItem(modCommond.gc_AtributeSignature).Value
                    Dim v_key = RSA.RsaDecryptWithPrivate(v_strSignature, modCommond.Signature_PrivateKey)
                    If v_key <> modCommond.Signature_KEY Then
                        v_lngErr = modCommond.ERR_CR_ACCOUNTPERMISSIONDENEINED
                    End If
                Catch ex As Exception
                    LogError.WriteException(ex)
                    v_lngErr = modCommond.ERR_SYSTEM_START
                End Try
            End If

            If v_lngErr <> ERR_SYSTEM_OK Then
                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                v_xmlDoc.LoadXml(pv_strMessage)
                v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
                pv_strMessage = v_xmlDoc.OuterXml

                pv_strMessage = TripleDesEncryptData(pv_strMessage)
                pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

                LogError.Write("::MessageByte:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErr
            End If

            Select Case v_strMSGTYPE
                Case modCommond.gc_MsgTypeTranS
                    Dim v_strTXTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeTXTYPE).Value

                    If v_strTXTYPE.Trim() = "I" Then
                        v_lngErr = (New Host.miscRouter()).Transact(v_xmlDocumentMessage)
                    Else
                        v_lngErr = (New Host.brRouter()).txTransfer(pv_strMessage)
                        Exit Select
                    End If
                    Exit Select
                Case modCommond.gc_MsgTypeObj
                    ''Object message
                    v_lngErr = (New Host.objRouter()).Transfer(pv_strMessage)
                    Exit Select
            End Select

            If v_lngErr <> ERR_SYSTEM_OK Then
                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                LogError.Write("::MessageByte:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
            End If

            v_xmlDoc.LoadXml(pv_strMessage)
            v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
            pv_strMessage = v_xmlDoc.OuterXml

            LogError.Write("::MessageByte:: [END]" & pv_strMessage)

            ''Compress message
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            Return v_lngErr
        Catch ex As Exception
            LogError.WriteException(ex)
            Return modCommond.ERR_SYSTEM_START
        End Try
    End Function

    Public Function MessageString(ByRef pv_strMessage As String) As Long Implements IHOSTService.MessageString
        Dim v_lngErr As Long = 0
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String
        Dim v_xmlDoc As XmlDocument = New XmlDocumentEx()
        Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()
        Try
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            LogError.Write("::MessageString:: [BEGIN]" & pv_strMessage)

            ''Read transaction message 
            v_xmlDocumentMessage.LoadXml(pv_strMessage)

            ''Get header message.
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strMSGTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeMSGTYPE).Value

            Dim checkSign = ConfigurationManager.AppSettings("CheckSign")
            If checkSign = "Y" Then
                Try
                    Dim v_strSignature = v_attrColl.GetNamedItem(modCommond.gc_AtributeSignature).Value
                    Dim v_key = RSA.RsaDecryptWithPrivate(v_strSignature, modCommond.Signature_PrivateKey)
                    If v_key <> modCommond.Signature_KEY Then
                        v_lngErr = modCommond.ERR_CR_ACCOUNTPERMISSIONDENEINED
                    End If
                Catch ex As Exception
                    LogError.WriteException(ex)
                    v_lngErr = modCommond.ERR_SYSTEM_START
                End Try
            End If

            If v_lngErr <> ERR_SYSTEM_OK Then
                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                v_xmlDoc.LoadXml(pv_strMessage)
                v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
                pv_strMessage = v_xmlDoc.OuterXml

                pv_strMessage = TripleDesEncryptData(pv_strMessage)

                LogError.Write("::MessageByte:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErr
            End If

            Select Case v_strMSGTYPE
                Case modCommond.gc_MsgTypeTranS
                    Dim v_strTXTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeTXTYPE).Value
                    If v_strTXTYPE.Trim() = "I" Then
                        v_lngErr = (New Host.miscRouter()).Transact(v_xmlDocumentMessage)
                    Else
                        v_lngErr = (New Host.brRouter()).txTransfer(pv_strMessage)
                    End If
                    Exit Select
                Case modCommond.gc_MsgTypeObj
                    ''Object message
                    v_lngErr = (New Host.objRouter()).Transfer(pv_strMessage)
                    Exit Select
            End Select

            If v_lngErr <> ERR_SYSTEM_OK Then
                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                LogError.Write("::MessageString:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
            End If

            v_xmlDoc.LoadXml(pv_strMessage)
            v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
            pv_strMessage = v_xmlDoc.OuterXml

            LogError.Write("::MessageString:: [END]" & pv_strMessage)

            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            Return v_lngErr
        Catch ex As Exception
            LogError.WriteException(ex)
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            Return ERR_SYSTEM_START
        End Try
    End Function

    Public Function OMessageByte(ByVal pv_arrByteMessage As Byte()) As Object() Implements IHOSTService.OMessageByte
        Dim v_lngErr As Long = 0

        Try
            ''Decompress
            Dim pv_strMessage As String
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            LogError.Write("::OMessageByte:: [BEGIN]" & pv_strMessage)

            ''Read transaction message 
            Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()
            v_xmlDocumentMessage.LoadXml(pv_strMessage)

            ''Get header message.
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strLOCAL = v_attrColl.GetNamedItem(modCommond.gc_AtributeLOCAL).Value
            Dim v_strMSGTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeMSGTYPE).Value

            Select Case v_strMSGTYPE
                Case modCommond.gc_MsgTypeTranS
                    Dim v_strTXTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeTXTYPE).Value
                    If v_strTXTYPE.Trim() = "I" Then
                        ''Inquiry message
                        v_lngErr = (New Host.miscRouter()).Transact(v_xmlDocumentMessage)
                    Else
                        v_lngErr = (New Host.brRouter()).txTransfer(pv_strMessage)
                        Exit Select
                    End If
                    Exit Select
                Case modCommond.gc_MsgTypeObj
                    ''Object message
                    v_lngErr = (New Host.objRouter()).Transfer(pv_strMessage)
                    Exit Select
            End Select

            If v_lngErr <> ERR_SYSTEM_OK Then
                Dim v_strErrorMessage As String = String.Empty
                Dim v_strErrorSource As String = String.Empty

                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                LogError.Write("::OMessageByte:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
            End If

            LogError.Write("::OMessageByte:: [END]" & pv_strMessage)

            ''Compress message
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            Return New Object() {v_lngErr, pv_arrByteMessage}

        Catch ex As Exception
            LogError.WriteException(ex)
            Return New Object() {ERR_SYSTEM_START, pv_arrByteMessage}
        End Try
    End Function

    Public Function OMessageString(ByVal pv_strMessage As String) As Object() Implements IHOSTService.OMessageString
        Dim v_lngErr As Long = 0

        Try
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            LogError.Write("::OMessageString:: [BEGIN]" & pv_strMessage)

            ''Read transaction message 
            Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()
            v_xmlDocumentMessage.LoadXml(pv_strMessage)

            ''Get header message.
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strMSGTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeMSGTYPE).Value

            Select Case v_strMSGTYPE
                Case modCommond.gc_MsgTypeTranS
                    Dim v_strTXTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeTXTYPE).Value
                    If v_strTXTYPE.Trim() = "I" Then
                        v_lngErr = (New Host.miscRouter()).Transact(v_xmlDocumentMessage)
                    Else
                        v_lngErr = (New Host.brRouter()).txTransfer(pv_strMessage)
                    End If
                    Exit Select
                Case modCommond.gc_MsgTypeObj
                    ''Object message
                    v_lngErr = (New Host.objRouter()).Transfer(pv_strMessage)
                    Exit Select
            End Select

            If v_lngErr <> ERR_SYSTEM_OK Then
                Dim v_strErrorMessage As String = String.Empty
                Dim v_strErrorSource As String = String.Empty

                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                LogError.Write("::OMessageString:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
            End If

            LogError.Write("::OMessageString:: [END]" & pv_strMessage)

            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            Return New Object() {v_lngErr, pv_strMessage}
        Catch ex As Exception
            LogError.WriteException(ex)
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            Return New Object() {ERR_SYSTEM_START, pv_strMessage}
        End Try
    End Function

    Public Function GetFlagSignature() As String Implements IHOSTService.GetFlagSignature
        Dim checkSign As String = ConfigurationManager.AppSettings("CheckSign")
        Dim strReturn As String = "{0}|{1}|{2}"
        If checkSign = "Y" Then
            Return String.Format(strReturn, checkSign, modCommond.gc_AtributeSignature, modCommond.Signature_KEY)
        Else
            Return String.Format(strReturn, checkSign, modCommond.gc_AtributeSignature, " ")
        End If
    End Function

    Private Function GetErrorMessage(ByVal pv_lngErrorCode As Long) As String
        Dim v_strErrorMessage As String = String.Empty
        Dim v_lngError As Long = 0

        Try
            Dim v_strClause = " ERRNUM = " & pv_lngErrorCode
            Dim v_strObjMsg = modCommond.BuildXMLObjMsg(String.Empty, String.Empty, String.Empty, String.Empty, modCommond.gc_IsLocalMsg, modCommond.gc_MsgTypeObj, modCommond.OBJNAME_SY_DEFERROR, modCommond.gc_ActionInquiry, String.Empty, v_strClause, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)

            v_lngError = (New Host.objRouter()).Transfer(v_strObjMsg)

            Dim v_xmlDocument = New XmlDocument()
            Dim v_strValue As String
            Dim v_strFLDNAME As String

            ''Read object message 
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        Dim objTemp = v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = objTemp.InnerText
                        v_strFLDNAME = objTemp.Attributes.GetNamedItem("fldname").Value

                        If v_strFLDNAME.Trim() = "ERRDESC" Then
                            v_strErrorMessage = v_strValue
                        End If
                    Next
                Next
            Else
                v_strErrorMessage = "[" & pv_lngErrorCode & "]: Unknown error!"
            End If
            Return v_strErrorMessage
        Catch ex As Exception
            LogError.WriteException(ex)
            Return pv_lngErrorCode & " " & ex.Message
        End Try
    End Function

    Public Function GetInfoAuthorMicrosoft(ByRef pv_arrByteMessage As Byte()) As Long Implements IHOSTService.GetInfoAuthorMicrosoft
        Dim v_lngErr = ERR_SYSTEM_OK
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String
        Dim pv_strMessage As String
        Dim v_xmlDoc As XmlDocument = New XmlDocumentEx()
        Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()

        Try
            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            'Check Sign
            v_xmlDocumentMessage.LoadXml(pv_strMessage)
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim checkSign = ConfigurationManager.AppSettings("CheckSign")
            If checkSign = "Y" Then
                Try
                    Dim v_strSignature = v_attrColl.GetNamedItem(modCommond.gc_AtributeSignature).Value
                    Dim v_key = RSA.RsaDecryptWithPrivate(v_strSignature, modCommond.Signature_PrivateKey)
                    If v_key <> modCommond.Signature_KEY Then
                        v_lngErr = -100
                    End If
                Catch ex As Exception
                    LogError.WriteException(ex)
                    v_lngErr = modCommond.ERR_SYSTEM_START
                End Try
            End If

            If v_lngErr <> ERR_SYSTEM_OK Then
                v_strErrorMessage = GetErrorMessage(v_lngErr)
                ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErr, v_strErrorMessage)

                v_xmlDoc.LoadXml(pv_strMessage)
                v_xmlDoc.DocumentElement.Attributes.RemoveNamedItem(modCommond.gc_AtributeSignature)
                pv_strMessage = v_xmlDoc.OuterXml

                pv_strMessage = TripleDesEncryptData(pv_strMessage)
                pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

                LogError.Write("::GetQueryParamsAuthorizationMicrosoft:: ERRCODE: " & v_lngErr & " ERRMSG: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErr
            End If

            'Response
            Dim info As New Dictionary(Of String, String)
            info.Add("urlAuthorizeCode", ConfigurationManager.AppSettings("URLAuthorCodeMicrosoft"))
            info.Add("urlAccessToken", ConfigurationManager.AppSettings("URLAccessTokenMicrosoft"))
            info.Add("redirectUri", ConfigurationManager.AppSettings("RedirectUriMicrosoft"))
            info.Add("clientId", ConfigurationManager.AppSettings("ClientIdMicrosoft"))
            info.Add("clientSecret", ConfigurationManager.AppSettings("ClientSecretMicrosoft"))
            info.Add("scope", ConfigurationManager.AppSettings("ScopeMicrosoftGraph"))

            pv_strMessage = JsonConvert.SerializeObject(info)

            'Compress message
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            Return v_lngErr
        Catch ex As Exception
            LogError.WriteException(ex)
            Return modCommond.ERR_SYSTEM_START
        End Try

        Return ERR_SYSTEM_OK
    End Function

    Public Function InsertOrUpdateAccMicrosoft(ByRef pv_arrByteMessage As Byte()) As Long Implements IHOSTService.InsertOrUpdateAccMicrosoft
        Dim pv_strMessage As String
        Dim pv_message As ResponseAuthenMicrosoft
        Dim v_bCmd As New BusinessCommand
        Dim v_dal As New DataAccess
        Dim v_ds As DataSet
        Dim largestTLID = GetLargestTLIDFromTLPROFILES()
        Dim defauleBRID = "0001"
        Dim defaultTlgroup = "001" 'Phong Cong Nghe Thong Tin
        Dim mv_strTicket As String

        Try
            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            pv_message = JsonConvert.DeserializeObject(Of ResponseAuthenMicrosoft)(pv_strMessage)

            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            ''Get info account Microsoft
            v_bCmd.SQLCommand = String.Format("SELECT * FROM TLPROFILES WHERE USERID = '{0}'", pv_message.user_id)
            v_ds = v_dal.ExecuteSQLReturnDataset(v_bCmd)

            'Account does not exist yet
            If v_ds.Tables(0).Rows.Count <> 1 Then
                v_bCmd.SQLCommand = String.Format("INSERT INTO TLPROFILES (TLID,BRID,TLGROUP,ACTIVE,FIRSTTOKEN,USERID) VALUES ('{0}', '" & defauleBRID & "', '" & defaultTlgroup & "', 'Y' ,'{1}', '{2}')",
                                             largestTLID,
                                             pv_message.access_token,
                                             pv_message.user_id)

                v_dal.ExecuteSQLReturnDataset(v_bCmd)

                mv_strTicket = Util.EncryptString(defauleBRID & "|" & largestTLID & "|")
            Else

                Dim tlid = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
                Dim brid = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID"))

                v_bCmd.SQLCommand = String.Format("UPDATE TLPROFILES SET ACCESSTOKEN = '{0}' WHERE USERID = '{1}'",
                                              pv_message.access_token,
                                              pv_message.user_id)

                v_dal.ExecuteSQLReturnDataset(v_bCmd)
                mv_strTicket = Util.EncryptString(brid & "|" & tlid & "|")
            End If

            ''Return ticket
            'Compress message
            mv_strTicket = TripleDesEncryptData(mv_strTicket)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(mv_strTicket)
        Catch ex As Exception
            LogError.WriteException(ex)
            Return modCommond.ERR_SYSTEM_START
        End Try

        Return ERR_SYSTEM_OK
    End Function

    Public Function GetLargestTLIDFromTLPROFILES() As String
        Dim v_bCmd As New BusinessCommand
        Dim v_dal As New DataAccess
        Dim v_ds As DataSet

        Try
            'ExecuteSQL
            v_bCmd.SQLCommand = "SELECT TLID FROM TLPROFILES WHERE ROWNUM=1 ORDER BY TLID DESC"

            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            v_ds = v_dal.ExecuteSQLReturnDataset(v_bCmd)

            If v_ds.Tables(0).Rows.Count = 1 Then
                Return Convert.ToInt32(gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TLID")) + 1).ToString("D4")
            End If

        Catch ex As Exception
            LogError.WriteException(ex)
        End Try

        Return String.Empty
    End Function

    Public Function GetSecondsLimitAFK(ByRef pv_arrByteMessage As Byte()) As Long Implements IHOSTService.GetSecondsLimitAFK
        Try
            Dim pv_strMessage As String

            ''Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            pv_strMessage = ConfigurationManager.AppSettings("SecondsLimitAFK")

            ''Compress message
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)
        Catch ex As Exception
            LogError.WriteException(ex)
            Return modCommond.ERR_SYSTEM_START
        End Try

        Return ERR_SYSTEM_OK
    End Function
End Class