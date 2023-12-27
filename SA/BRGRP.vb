Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class BRGRP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "BRGRP"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            Select Case Trim(v_strFuncName)
                Case "AddGroups2Branch"
                    v_lngErrCode = AddGroups2Branch(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strBrId, v_strParentId As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

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
                        Case "BRID"
                            v_strBrId = Trim(v_strVALUE)
                        Case "PRBRID"
                            v_strParentId = Trim(v_strVALUE)
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

            'Kiểm tra BDSID không được trùng
            v_strSQL = "SELECT COUNT(BRID) FROM " & ATTR_TABLE & " WHERE BRID = '" & v_strBrId & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_BRID_DUPLICATED
                End If
            End If

            'Kiểm tra PRBRID phải tồn tại
            'If v_strParentId.Length > 0 Then
            '    v_strSQL = "SELECT COUNT(BRID) FROM " & ATTR_TABLE & " WHERE PRBRID = '" & v_strParentId & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '            Return ERR_SA_PRBRID_NOTFOUND
            '        End If
            '    End If
            'End If

            'If Not (v_ds Is Nothing) Then
            '    v_ds.Dispose()
            'End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strParentId As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

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
                        Case "PRBRID"
                            v_strParentId = Trim(v_strVALUE)
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

            'Kiểm tra PRBRID phải tồn tại
            'If v_strParentId.Length > 0 Then
            '    v_strSQL = "SELECT COUNT(BDSID) FROM " & ATTR_TABLE & " WHERE BDSID = '" & v_strParentId & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '            Return ERR_SA_PRBRID_NOTFOUND
            '        End If
            '    End If
            'End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBrId As String
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
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strCurrentBrId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentBrId = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Không cho phép xoá chi nhánh hiện tại
            If v_strCurrentBrId <> String.Empty Then
                v_strSQL = "SELECT COUNT(BRID) FROM BRGRP WHERE BRID = '" & v_strCurrentBrId & "' AND " & v_strClause

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_CANNOT_DEL_CURRENT_BRANCH
                    End If
                End If
            End If

            'Không cho phép xoá chi nhánh có các chi nhánh/đại lý con
            v_strSQL = "SELECT COUNT(BRID) FROM BRGRP WHERE PRBRID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_BRANCH_HAS_CHILD
                End If
            End If

            'Không cho phép xoá chi nhánh có các teller vẫn tồn tại
            v_strSQL = "SELECT COUNT(TLID) FROM TLPROFILES WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_BRANCH_HAS_TELLER
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Private methods "
    ''---------------------------------------------------------------------''
    ''-- + Mục đích: Ghi dữ liệu định nghĩa nhóm cho chi nhánh vào CSDL  --'' 
    ''-- + ?�ầu vào: pv_xmlDocument: XmlDocument chứa dữ liệu cần thiết   --''
    ''-- + ?�ầu ra: N/A                                                   --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                      --''
    ''-- + Ghi chú: N/A                                                  --''
    ''---------------------------------------------------------------------''

    Private Function AddGroups2Branch(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strLocal, v_strTellerId, v_strCurrBranchId As String
            Dim v_strAutoId As String
            'Dim v_

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCurrBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrBranchId = String.Empty
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

            'Get current date
            Dim v_strSQL As String
            v_strSQL = "SELECT TO_CHAR(GETCURRDATE,'DD/MM/YYYY') BUSDATE FROM DUAL "

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strDate As String
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strDate = CStr(IIf(v_ds.Tables(0).Rows(0)("BUSDATE") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("BUSDATE"))).Trim
            End If

            'Get Branch - Groups info
            Dim v_strBranchId As String
            Dim v_arrClause() As String
            Dim v_arrGrpId() As String
            'Dim v_arrBrid() As String
            Dim v_strOldValue As String = String.Empty
            Dim v_strNewValue As String = String.Empty
            Dim v_arrOldValue() As String = {""}

            v_arrClause = v_strClause.Split("#")
            v_strBranchId = v_arrClause(0)
            v_arrGrpId = v_arrClause(1).Split("|")
            'v_strNewValue = v_arrClause(1)
            'v_arrBrid = v_arrClause(2).Split("|")

            'Lay du lieu cu de ghi log

            Dim v_dsOV As DataSet
            v_strSQL = "SELECT BR.BRID, BR.PARAVALUE FROM BRGRPPARAM BR WHERE BRID = '" & v_strBranchId & "' AND PARATYPE = 'TLGROUPS' ORDER BY BR.PARAVALUE"
            v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsOV.Tables(0).Rows.Count > 0 Then
                ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count)
                For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                    v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("PARAVALUE")
                    v_strOldValue = v_strOldValue & "," & v_dsOV.Tables(0).Rows(j)("PARAVALUE")
                Next
            End If

            'Delete data in database
            Dim v_strCmdDelSQL As String
            v_strCmdDelSQL = "DELETE FROM BRGRPPARAM WHERE BRID = '" & v_strBranchId & "' AND PARATYPE = 'TLGROUPS'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Tang sequence len 1 de ghi log
            v_strCmdDelSQL = "select seq_rightassign_log.nextval from dual"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Update database
            For i As Integer = 0 To v_arrGrpId.Length - 2
                Dim v_strCmdInsertSQL As String
                v_strCmdInsertSQL = "INSERT INTO BRGRPPARAM(AUTOID, BRID, PARATYPE, PARAVALUE, DELTD, SAVETLID, SAVEBRID, LASTDATE) " _
                                    & "VALUES(SEQ_BRGRPPARAM.NEXTVAL, '" & v_strBranchId & "', 'TLGROUPS',  '" & v_arrGrpId(i) & "', 'N',  '" & v_strTellerId & "','" & v_strCurrBranchId & "', TO_DATE('" & v_strDate & "', 'DD/MM/YYYY'))"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                v_strNewValue = v_strNewValue & "," & v_arrGrpId(i)
            Next
            'Tim nhom them vao va nhom remove de ghi log
            'Nhom co trong chuoi nhom cu & ko co trong chuoi nhom moi la cac nhom bi remove
            'Nhom co trong chuoi nhom moi & ko co trong chuoi nhom cu la cac nhom dc them moi
            Dim v_strGroupRemoved As String = String.Empty
            Dim v_strGroupAdded As String = String.Empty
            If v_arrOldValue Is Nothing Then
                For k As Integer = 0 To v_arrOldValue.Length - 1
                    If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 Then
                        v_strGroupRemoved = v_strGroupRemoved & ", " & v_arrOldValue(k)
                    End If
                Next
            End If

            v_strGroupRemoved = Mid(v_strGroupRemoved, 2)

            For m As Integer = 0 To v_arrGrpId.Length - 2
                If Not InStr(v_strOldValue, v_arrGrpId(m)) > 0 Then
                    v_strGroupAdded = v_strGroupAdded & ", " & v_arrGrpId(m)
                End If
            Next
            v_strGroupAdded = Mid(v_strGroupAdded, 2)

            'Ghi log thay doi
            If v_strGroupAdded.Length > 0 Or v_strGroupRemoved.Length > 0 Then
                v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                    & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                    & "VALUES (seq_rightassign_log.NEXTVAL, 'BRGRPPARAM', '" & v_strBranchId & "', '', '', '','',''," & ControlChars.CrLf _
                    & " '','','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strGroupRemoved & "','" & v_strGroupAdded & "', TO_DATE('" & v_strDate & "', 'DD/MM/YYYY'))"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
