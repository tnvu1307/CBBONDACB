Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Imports Newtonsoft.Json
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Xml

Public Class CHANGESECRET
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CHANGESECRET"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "Submit"
                    v_lngErrCode = Submit(pv_xmlDocument)
                Case "CallAPIVmoney"
                    v_lngErrCode = CallAPIVmoney(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Private methods "

    Private Function Submit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strerrorCode, v_strerrorDesc, v_strtransactionDate As String
        Dim v_VMoneyUri, v_VMoneyApiKey As String
        Dim res As String
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_attrFLDNAME As Xml.XmlAttribute

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strBranchId, v_strTellerId As String
            Dim v_strLocal As String
            Dim v_strAutoId As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            'Inquiry data
            Dim v_obj As DataAccess = New DataAccess
            If v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_xmlDocumentAPI As XmlDocument
            Dim v_nodeListAPI As XmlNodeList

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



                res = callAPIRestful(v_VMoneyUri & "/vmoney/change/secret?secretKey=" & v_strClause, "GET", v_VMoneyApiKey, "")

                res = "{'root':" & res & "}"

                v_xmlDocumentAPI = JsonConvert.DeserializeXmlNode(res)

                v_nodeListAPI = v_xmlDocumentAPI.SelectNodes("/root")

                For Each v_node As XmlElement In v_nodeListAPI
                    v_strerrorCode = v_node.SelectSingleNode("errorCode").InnerText
                    v_strerrorDesc = v_node.SelectSingleNode("errorDesc").InnerText
                    v_strtransactionDate = v_node.SelectSingleNode("transactionDate").InnerText
                Next
            Catch ex As Exception
                v_strerrorCode = "-1"
                v_strerrorDesc = ex.Message
                v_strtransactionDate = 0

                LogError.WriteException(ex)
            End Try

            v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorCode"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorCode
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorDesc"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorDesc
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "transactionDate"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strtransactionDate

            v_dataElement.AppendChild(v_entryNode)

            pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            v_strerrorCode = "-1"
            v_strerrorDesc = ex.Message
            v_strtransactionDate = 0

            v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorCode"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorCode
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorDesc"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorDesc
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "transactionDate"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strtransactionDate

            v_dataElement.AppendChild(v_entryNode)

            pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            LogError.Write("Error source:  " & "APIVMONEY" & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & ex.Message & vbNewLine _
                                 & "v_VMoneyUri: " & v_VMoneyUri & vbNewLine _
                                 & "v_VMoneyApiKey: " & v_VMoneyApiKey & vbNewLine _
                                 & "res: " & res & vbNewLine _
                                 , "EventLogEntryType.Error"
                          )
            Return ERR_SYSTEM_OK
        End Try
    End Function

    Private Function CallAPIVmoney(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strerrorCode, v_strerrorDesc, v_strtransactionDate As String
        Dim v_VMoneyUri, v_VMoneyApiKey As String
        Dim res As String
        Dim v_strClause, v_strBranchId, v_strTellerId As String
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_attrFLDNAME As Xml.XmlAttribute

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strAutoId As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            'Inquiry data
            Dim v_obj As DataAccess = New DataAccess
            If v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_xmlDocumentAPI As XmlDocument
            Dim v_nodeListAPI As XmlNodeList


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

                res = callAPIRestful(v_VMoneyUri & v_strClause, "GET", v_VMoneyApiKey, "")

                v_strerrorCode = "00"
                v_strerrorDesc = ""
                v_strtransactionDate = 0

            Catch ex As Exception
                v_strerrorCode = "-1"
                v_strerrorDesc = ex.Message
                v_strtransactionDate = 0

                LogError.Write("Error source: " & "APIVMONEY" & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message & vbNewLine _
                                     & "v_VMoneyUri: " & v_VMoneyUri & vbNewLine _
                                     & "v_VMoneyApiKey: " & v_VMoneyApiKey & vbNewLine _
                                     & "v_strClause: " & v_strClause & vbNewLine _
                                     & "res: " & res & vbNewLine _
                                     , "EventLogEntryType.Error"
                              )
            End Try

            v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorCode"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorCode
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorDesc"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorDesc
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "transactionDate"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strtransactionDate

            v_dataElement.AppendChild(v_entryNode)

            pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            v_strerrorCode = "-1"
            v_strerrorDesc = ex.Message
            v_strtransactionDate = 0

            v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorCode"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorCode
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "errorDesc"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strerrorDesc
            v_dataElement.AppendChild(v_entryNode)

            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "transactionDate"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            v_entryNode.InnerText = v_strtransactionDate

            v_dataElement.AppendChild(v_entryNode)

            pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            LogError.Write("Error source: " & "APIVMONEY" & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & ex.Message & vbNewLine _
                                 & "v_VMoneyUri: " & v_VMoneyUri & vbNewLine _
                                 & "v_VMoneyApiKey: " & v_VMoneyApiKey & vbNewLine _
                                 & "v_strClause: " & v_strClause & vbNewLine _
                                 & "res: " & res & vbNewLine _
                                 , "EventLogEntryType.Error"
                          )
            Return ERR_SYSTEM_OK
        End Try
    End Function

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

