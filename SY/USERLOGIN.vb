Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class USERLOGIN
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "USERLOGIN"
    End Sub
#Region "Overrides Funtion"
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL As String
        Dim v_strLocal As String
        Dim v_strFLDNAME, v_strVALUE, v_strUsername, v_strEmail, v_strREFFAMEMBERID, v_strCUSTODYCD As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "USERNAME"
                            v_strUsername = Trim(v_strVALUE)
                        Case "EMAIL"
                            v_strEmail = Trim(v_strVALUE)
                        Case "REFFAMEMBERID"
                            v_strREFFAMEMBERID = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT COUNT(USERNAME) FROM " & ATTR_TABLE & " WHERE USERNAME = '" & v_strUsername & "' AND STATUS <> 'E'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_USERNAME_DUPLICATE
                End If
            End If

            'trung.luu: lam gium anh DA 28-02-2020
            'v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE email = '" & v_strEmail & "' AND STATUS <> 'E'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_USERLOGIN_EMAIL_EXISTS
            '    End If
            'End If

            'trung.luu: 20-08-2020 bo check trung reffamemberid 
            'If Len(v_strREFFAMEMBERID) > 0 Then
            '    'v_strSQL = "SELECT COUNT(1) FROM famembers WHERE shortname = '" & v_strREFFAMEMBERID & "'"
            '    'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    'If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '    '    Return ERR_SA_FUNDID_NOT_FOUND
            '    'End If
            '    v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE reffamemberid = '" & v_strREFFAMEMBERID & "' AND STATUS <> 'E'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_FUNDID_NOT_FOUND
            '    End If
            'End If
            If Len(v_strCUSTODYCD) > 0 Then
                v_strSQL = "SELECT COUNT(1) FROM cfmast WHERE custodycd = '" & v_strCUSTODYCD & "' AND status <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SA_USERLOGIN_STC_NOT_FOUND
                End If
                'v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE reffamemberid = '" & v_strREFFAMEMBERID & "' AND STATUS <> 'E'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows(0)(0) > 0 Then
                '    Return ERR_SA_FUNDID_NOT_FOUND
                'End If
            End If


        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeApprove(v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlNode As Xml.XmlNode
        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL As String
        Dim v_strLocal As String
        Dim v_strFLDNAME, v_strVALUE, v_strUsername As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_xmlNode = pv_xmlDocument.SelectSingleNode("ObjectMessage")

            Dim clause As String = v_xmlNode.Attributes("CLAUSE").Value

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Overrides Function CheckBeforeEdit(v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL As String
        Dim v_strLocal, v_strSHORTNAME, v_strGLACCOUNT As String
        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strUsername, v_strEmail, v_strREFFAMEMBERID As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "USERNAME"
                            v_strUsername = Trim(v_strVALUE)
                        Case "EMAIL"
                            v_strEmail = Trim(v_strVALUE)
                        Case "REFFAMEMBERID"
                            v_strREFFAMEMBERID = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'If Len(v_strREFFAMEMBERID) > 0 Then
            '    v_strSQL = "SELECT COUNT(1) FROM famembers WHERE TO_CHAR(autoid) = '" & v_strREFFAMEMBERID & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '        Return ERR_SA_FUNDID_NOT_FOUND
            '    End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "getUserNameFormat"
                    v_lngErrCode = getUserNameFormat(pv_xmlDocument)
            End Select
            'pv_xmlDocument.LoadXml(v_strObjMsg)
            v_strMessage = pv_xmlDocument.InnerXml

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function ProcessAfterApprove(v_strMessage As String) As Long
        
        Dim xmlDocument As New Xml.XmlDocument
        xmlDocument.LoadXml(v_strMessage)
        Dim v_attrColl As Xml.XmlAttributeCollection = xmlDocument.DocumentElement.Attributes
        Dim v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Dim v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)

        Dim v_obj As New DataAccess(gc_MODULE_HOST)
        Dim v_objRptParam As StoreParameter
        Dim v_arrRptPara() As StoreParameter
        ReDim v_arrRptPara(0)

        v_objRptParam = New StoreParameter
        v_objRptParam.ParamName = "CLAUSE"
        v_objRptParam.ParamValue = v_strCLAUSE
        v_objRptParam.ParamSize = 1000
        v_objRptParam.ParamType = "String"
        v_arrRptPara(0) = v_objRptParam

        v_obj.ExecuteOracleStored("pr_SendUserLoginEmail", v_arrRptPara, 0)
    End Function
#End Region
#Region "Private Function"
    Private Function getUserNameFormat(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_arrKey = v_strCLAUSE.Split("|")

            Dim v_DataAccess As New DataAccess(gc_MODULE_HOST)
            Dim username As String
            If v_arrKey(0) = "STC" Then
                Dim v_sql = "SELECT custtype FROM cfmast WHERE CUSTODYCD='" & v_arrKey(1) & "'"
                Dim v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                If v_ds.Tables(0).Rows(0)(0).ToString = "I" Then
                    username = "I"
                Else
                    username = "C"
                End If

            Else
                Dim v_objRptParam As ReportParameters
                Dim v_arrRptPara() As ReportParameters
                ReDim v_arrRptPara(4)

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "CLAUSE"
                v_objRptParam.ParamValue = "AFACCTNO"
                v_objRptParam.ParamSize = 8
                v_objRptParam.ParamType = "String"
                v_arrRptPara(0) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "BRID"
                v_objRptParam.ParamValue = v_strBRID
                v_objRptParam.ParamSize = v_strBRID.Length
                v_objRptParam.ParamType = "String"
                v_arrRptPara(1) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "SSYSVAR"
                v_objRptParam.ParamValue = "SHVF"
                v_objRptParam.ParamSize = 4
                v_objRptParam.ParamType = "String"
                v_arrRptPara(2) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "RefLength"
                v_objRptParam.ParamValue = 6
                v_objRptParam.ParamSize = 20
                v_objRptParam.ParamType = "NUMBER"
                v_arrRptPara(3) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "REFERENCE"
                v_objRptParam.ParamValue = ""
                v_objRptParam.ParamSize = 100
                v_objRptParam.ParamType = "String"
                v_arrRptPara(4) = v_objRptParam


                Dim v_ds = v_DataAccess.ExecuteStoredReturnDataset("SP_GetInventory", v_arrRptPara)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    username = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
                Else
                    username = "001"
                End If
                username = Strings.Right("000000" & CStr(username), Len("000000"))
            End If
            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = username
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
