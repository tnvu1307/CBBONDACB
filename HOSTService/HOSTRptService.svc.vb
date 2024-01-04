Imports System.Transactions
Imports System.Xml
Imports HostCommonLibrary
Imports System.Configuration

' NOTE: If you change the class name "HOSTRptService" here, you must also update the reference to "HOSTRptService" in Web.config and in the associated .svc file.

Public Class HOSTRptService
    Implements IHOSTRptService

    Dim LogError As LogError = New LogError()

    Public Sub DoWork() Implements IHOSTRptService.DoWork
    End Sub

    Private Function GetErrorMessage(ByVal pv_lngErrorCode As Long) As String
        Dim v_strErrorMessage As String = String.Empty
        Dim v_obj = New HOSTReport.HOSTReport()
        Dim v_lngError As Long = 0

        Try
            Dim v_strClause = " ERRNUM = " & pv_lngErrorCode
            Dim v_strObjMsg = modCommond.BuildXMLObjMsg(String.Empty, String.Empty, String.Empty, String.Empty, modCommond.gc_IsLocalMsg, modCommond.gc_MsgTypeObj,
             modCommond.OBJNAME_SY_DEFERROR, modCommond.gc_ActionInquiry, String.Empty, v_strClause, String.Empty, String.Empty,
             String.Empty, String.Empty, String.Empty, String.Empty)

            v_lngError = v_obj.objTransfer(v_strObjMsg)

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

    Public Function MessageByte(ByRef pv_arrByteMessage() As Byte) As Long Implements IHOSTRptService.MessageByte
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

            Using scope As New TransactionScope(TransactionScopeOption.Suppress)
                Try
                    Dim v_obj = New HOSTReport.HOSTReport()
                    v_lngErr = v_obj.objTransfer(pv_strMessage)
                    scope.Complete()
                Catch ex As Exception
                    scope.Dispose()
                    Throw ex
                End Try
            End Using

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

    Public Function MessageString(ByRef pv_strMessage As String) As Long Implements IHOSTRptService.MessageString
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
            Dim v_strLOCAL = v_attrColl.GetNamedItem(modCommond.gc_AtributeLOCAL).Value

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

            Using scope As New TransactionScope(TransactionScopeOption.Suppress)
                Dim v_obj = New HOSTReport.HOSTReport()
                v_lngErr = v_obj.objTransfer(pv_strMessage)
                scope.Complete()
            End Using


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
End Class