Imports HostCommonLibrary
Imports DataAccessLayer
Imports Newtonsoft.Json
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Data

Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "BA"
    End Sub

#Region " Implement functions"
    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)

        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case "2203"
                v_lngErrorCode = Update_2203(pv_xmlDocument)
        End Select
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case "2203"
                v_lngErrorCode = Check_2203(pv_xmlDocument)
        End Select
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
#Region "Check function"
    Private Function Check_2203(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.Check_2203", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strFLDTXDATE, v_strFLDBICCODE, v_strFLDCUSTODYCD, v_strFLDFULLNAME, v_strFLDIDCODE, v_strFLDIDDATE, v_strFLDIDPLACE, v_strFLDDESC As String
        Dim v_amount As Long
        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess, v_ds As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "01"
                            v_strFLDTXDATE = v_strVALUE
                        Case "05"
                            v_strFLDFULLNAME = v_strVALUE
                        Case "30"
                            v_strFLDDESC = v_strVALUE
                        Case "31"
                            v_strFLDIDCODE = v_dblVALUE
                        Case "56"
                            v_strFLDBICCODE = v_dblVALUE
                        Case "88"
                            v_strFLDCUSTODYCD = v_dblVALUE
                        Case "95"
                            v_strFLDIDDATE = v_dblVALUE
                        Case "96"
                            v_strFLDIDPLACE = v_dblVALUE
                    End Select
                End With
            Next

        Catch ex As Exception
            Return ERR_SYSTEM_START
        End Try
        Return v_lngErrCode
    End Function
#End Region


#Region "Update Function"
    Private Function Update_2203(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.Update_2203", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strFLDTXDATE, v_strFLDBICCODE, v_strFLDCUSTODYCD, v_strFLDFULLNAME, v_strFLDIDCODE, v_strFLDIDDATE, v_strFLDIDPLACE, v_strFLDDESC As String
        Dim v_amount As Long
        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess, v_ds As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                    Else
                        v_strVALUE = Trim(.InnerText)
                    End If
                    Select Case v_strFLDCD
                        Case "01"
                            v_strFLDTXDATE = v_strVALUE
                        Case "05"
                            v_strFLDFULLNAME = v_strVALUE
                        Case "30"
                            v_strFLDDESC = v_strVALUE
                        Case "31"
                            v_strFLDIDCODE = v_strVALUE
                        Case "56"
                            v_strFLDBICCODE = v_strVALUE
                        Case "88"
                            v_strFLDCUSTODYCD = v_strVALUE
                        Case "95"
                            v_strFLDIDDATE = v_strVALUE
                        Case "96"
                            v_strFLDIDPLACE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_VMoneyUri, v_VMoneyApiKey As String

            Try
                v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME = 'URI' AND GRNAME = 'VMONEY'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                Try
                    v_VMoneyUri = v_ds.Tables(0).Rows(0)("VARVALUE")
                Catch ex As Exception
                    v_VMoneyUri = "http://localhost"
                End Try

                v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME = 'APIKEY' AND GRNAME = 'VMONEY'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Try
                    v_VMoneyApiKey = v_ds.Tables(0).Rows(0)("VARVALUE")
                Catch ex As Exception

                End Try

                Dim res As String

                res = callAPIRestful(v_VMoneyUri & "/vmoney/checkbalance/" & v_strFLDCUSTODYCD, "GET", v_VMoneyApiKey, "")

                res = "{'root':" & res & "}"

                Dim v_xmlDocumentAPI As XmlDocument = JsonConvert.DeserializeXmlNode(res)
                Dim v_nodeListAPI As XmlNodeList
                Dim v_int, v_intCount As Integer
                Dim v_strerrorCode, v_strerrorDesc, v_strtransactionDate, v_straccountNo, v_straccountType, v_stramount As String

                v_nodeListAPI = v_xmlDocumentAPI.SelectNodes("/root")

                For Each v_node As XmlElement In v_nodeListAPI
                    v_strerrorCode = v_node.SelectSingleNode("errorCode").InnerText
                    v_strerrorDesc = v_node.SelectSingleNode("errorDesc").InnerText
                    v_strtransactionDate = v_node.SelectSingleNode("transactionDate").InnerText
                Next

                v_nodeListAPI = v_xmlDocumentAPI.SelectNodes("/root/result")

                For Each v_node In v_nodeListAPI
                    v_straccountNo = v_node.SelectSingleNode("accountNo").InnerText
                    v_straccountType = v_node.SelectSingleNode("accountType").InnerText
                    v_stramount = v_node.SelectSingleNode("amount").InnerText
                Next

                If v_strerrorCode <> "00" Then
                    Throw New System.Exception(v_strerrorCode & "-" & v_strerrorDesc)
                End If

                v_strSQL = "INSERT INTO CALLAPI_CHECKBALANCE_LOG(TXDATE ,TXNUM ,BICCODE ,CUSTODYCD ,FULLNAME ,IDCODE ,IDDATE ,IDPLACE ,PROCESS_ERROR ,APIERRORCODE ,APIERRORDESC ,APITRANSACTIONDATE ,APIACCOUNTNO ,APIACCOUNTTYPE ,APIAMOUNT)" & _
                "VALUES (TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), '" & v_strTXNUM & "', '" & v_strFLDBICCODE & "', '" & v_strFLDCUSTODYCD & "', '" & v_strFLDFULLNAME & "'" & _
                ", '" & v_strFLDIDCODE & "', TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), '" & v_strFLDIDPLACE & "', '', '" & v_strerrorCode & "', '" & v_strerrorDesc & "'" & _
                ", '" & v_strtransactionDate & "', '" & v_straccountNo & "', '" & v_straccountType & "', '" & v_stramount & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Catch ex As Exception
                v_strSQL = "INSERT INTO CALLAPI_CHECKBALANCE_LOG(TXDATE ,TXNUM ,BICCODE ,CUSTODYCD ,FULLNAME ,IDCODE ,IDDATE ,IDPLACE ,PROCESS_ERROR ,APIERRORCODE ,APIERRORDESC ,APITRANSACTIONDATE ,APIACCOUNTNO ,APIACCOUNTTYPE ,APIAMOUNT)" & _
                "VALUES (TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), '" & v_strTXNUM & "', '" & v_strFLDBICCODE & "', '" & v_strFLDCUSTODYCD & "', '" & v_strFLDFULLNAME & "'" & _
                ", '" & v_strFLDIDCODE & "', TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), '" & v_strFLDIDPLACE & "', '" & ex.Message & "', '', '', ''" & _
                ", '', '', '')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                LogError.Write("Error source: " & "APIVMONEY" & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & ex.Message & vbNewLine _
                                 & "v_VMoneyUri: " & v_VMoneyUri & vbNewLine _
                                 & "v_VMoneyApiKey: " & v_VMoneyApiKey & vbNewLine _
                                 , "EventLogEntryType.Error"
                          )
            End Try

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SYSTEM_START
        End Try

        Return v_lngErrCode
    End Function
#End Region
#End Region


    Private Function callAPIRestful(ByVal requestUri As String, ByVal method As String, ByVal apikey As String, ByVal params As String) As String
        Dim v_blnRet As String
        Dim paramsBytes As Object = Encoding.UTF8.GetBytes(params)
        Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUri), HttpWebRequest)
        req.ContentType = "application/json"
        req.Method = method
        If apikey <> Nothing Then
            req.Headers.Add("Authorization", apikey)
        End If
        If ("POST".Equals(method.ToUpper())) Then
            req.ContentLength = paramsBytes.Length
            Dim stream = req.GetRequestStream()
            stream.Write(paramsBytes, 0, paramsBytes.Length)
            stream.Close()
        End If

        Dim response = req.GetResponse().GetResponseStream()
        Dim reader As New StreamReader(req.GetResponse().GetResponseStream())
        Dim res = reader.ReadToEnd()

        reader.Close()
        response.Close()
        If res Is Nothing Then
            v_blnRet = ""
        Else
            v_blnRet = res.ToString
        End If
        Return v_blnRet
    End Function
End Class
