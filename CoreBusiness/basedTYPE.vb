Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Imports System.Diagnostics
Public Class basedTYPE
    Inherits Maintain

    Dim LogError As LogError = New LogError()

#Region " Overridable functions "
    Overridable Function TYPECheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".TYPECheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
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

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
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
                v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE & " WHERE ACTYPE = '" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_PRODUCT_ACTYPE_DUPLICATED
                    End If
                End If
            End If

            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'AND ACTIVE='Y' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_PRODUCT_CCYCD_NOTFOUND
                    End If
                End If
            End If

            'Kiểm tra GLGRP phải tồn tại
            If v_strGLGRP.Length > 0 Then
                'v_strSQL = "SELECT COUNT(GLGRP) FROM GLREF WHERE APPTYPE='" & ATTR_TABLE.Substring(0, 2) & "' AND GLGRP = '" & v_strGLGRP & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count >= 1 Then
                '    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                '        Return ERR_SA_PRODUCT_GLGRP_NOTEXITS
                '    End If
                'End If
            End If

            'Kiểm tra GLBANK phải tồn tại
            If v_strGLBANK.Length > 0 Then
                v_strSQL = "SELECT COUNT(GLBANK) FROM GLBANK WHERE GLBANK = '" & v_strGLBANK & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_PRODUCT_GLBANK_NOTFOUND
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

    Overridable Function TYPECheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".TYPECheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD, v_strGLBANK As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strGLGRP As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
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

            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'AND ACTIVE='Y' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_PRODUCT_CCYCD_NOTFOUND
                    End If
                End If
            End If

            'Kiểm tra GLGRP phải tồn tại
            If v_strGLGRP.Length > 0 Then
                'v_strSQL = "SELECT COUNT(GLGRP) FROM GLREF WHERE APPTYPE='" & ATTR_TABLE.Substring(0, 2) & "' AND GLGRP = '" & v_strGLGRP & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count >= 1 Then
                '    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                '        Return ERR_SA_PRODUCT_GLGRP_NOTEXITS
                '    End If
                'End If
            End If

            'Kiểm tra GLBANK phải tồn tại
            If v_strGLBANK.Length > 0 Then
                v_strSQL = "SELECT COUNT(GLBANK) FROM GLBANK WHERE GLBANK = '" & v_strGLBANK & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_PRODUCT_GLBANK_NOTFOUND
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

    Overridable Function TYPECheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".TYPECheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        ' Return 0
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

            'Kiểm tra xem Mã dữ liệu bị xoá có nằm trong bảng __MAST khác hay không
            v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE.Substring(0, 2) & "MAST WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            'Kiem tra ACTYPE co con du lieu lien quan trong bang ICCFTYPEDEF hay khong?
            v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPEDEF WHERE MODCODE = '" & ATTR_TABLE.Substring(0, 2) & "' AND " & v_strClause
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

    Overridable Function TYPEDelete(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = _CoreDelete(v_strMessage)

            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = ATTR_TABLE & ".Delete"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Else

                Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
                Dim v_strClause, v_strLocal As String

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


                'Delete all from BRIDTYPE and AFIDTYPE
                Dim v_strDelSQL As String
                'Delete from CMDAUTH
                v_strDelSQL = "DELETE FROM BRIDTYPE WHERE OBJNAME = '" & ATTR_TABLE.Substring(0, 2) & "." & ATTR_TABLE & "' AND " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strDelSQL)
                'Delete from TLAUTH
                v_strDelSQL = "DELETE FROM AFIDTYPE WHERE OBJNAME = '" & ATTR_TABLE.Substring(0, 2) & "." & ATTR_TABLE & "' AND " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strDelSQL)
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Return TYPECheckBeforeAdd(v_strMessage)
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Return TYPECheckBeforeEdit(v_strMessage)
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Return TYPECheckBeforeDelete(v_strMessage)
    End Function

    Overrides Function Delete(ByRef v_strMessage As String) As Long
        Return TYPEDelete(v_strMessage)
    End Function
#End Region

End Class
