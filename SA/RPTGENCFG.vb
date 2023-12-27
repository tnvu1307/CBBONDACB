Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class RPTGENCFG
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "RPTGENCFG"
    End Sub

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL As String
        Dim v_strLocal, v_strSHORTNAME As String
        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strRptId As String
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
                        Case "RPTID"
                            v_strRptId = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            If Not String.IsNullOrEmpty(v_strRptId) Then
                v_strSQL = "SELECT COUNT(RPTID) FROM " & ATTR_TABLE & " WHERE RPTID = '" & v_strRptId & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_RPTGENCFG_EXISTS
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return v_lngErrCode

    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_BRKID, v_strSQL, v_AUTOID, v_strRptId As String
        Dim v_ds As DataSet
        Try
            Dim v_obj As DataAccess
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_AUTOID = v_strVALUE
                        Case "RPTID"
                            v_strRptId = Trim(v_strVALUE)
                    End Select
                End With
            Next
            If Not String.IsNullOrEmpty(v_strRptId) And Not String.IsNullOrEmpty(v_AUTOID) Then
                v_strSQL = "SELECT COUNT(RPTID) FROM " & ATTR_TABLE & " WHERE RPTID <> '" & v_strRptId & "' AND AUTOID = '" + v_AUTOID + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_RPTGENCFG_EXISTS
                    End If
                End If
            End If
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return ERR_SYSTEM_OK
    End Function
End Class
