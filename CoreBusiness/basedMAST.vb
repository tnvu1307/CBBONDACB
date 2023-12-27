Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Imports System.Diagnostics
Public Class basedMAST
    Inherits Maintain

    Dim LogError As LogError = New LogError()

#Region " Overridable functions "
    Overridable Function MASTCheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".MASTCheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strACTYPE = String.Empty
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty
            v_strACCTNO = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                    End Select
                End With
            Next
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra ACTYPE không được trùng
            If v_strACTYPE.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE & " WHERE ACCTNO = '" & v_strACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_ACCTNO_DUPLICATED
                    End If
                End If
            End If


            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function MASTCheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".MASTCheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function MASTCheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".MASTCheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        'Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid As String
            Dim v_strLocal As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra xem Mã dữ liệu bị xoá có nằm trong bảng __TRAN, __TRANA  khác hay không
            v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE.Substring(0, 2) & "TRAN WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE.Substring(0, 2) & "TRANA WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Return MASTCheckBeforeAdd(v_strMessage)
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Return MASTCheckBeforeEdit(v_strMessage)
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Return MASTCheckBeforeDelete(v_strMessage)
    End Function
#End Region

End Class
