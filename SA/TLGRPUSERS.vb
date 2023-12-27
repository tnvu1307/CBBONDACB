Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class TLGRPUSERS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TLGRPUSERS"
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
                Case "AddUsersToGroup"
                    v_lngErrCode = AddUsersToGroup(pv_xmlDocument)
                Case "AddAftypeToGroup"
                    v_lngErrCode = AddAftypeToGroup(pv_xmlDocument)
                Case "AddUser2Groups"
                    v_lngErrCode = AddUser2Groups(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Private methods "
    ''---------------------------------------------------------------------''
    ''-- + Mục đích: Ghi dữ liệu định nghĩa ngư�?i dùng cho nhóm vào CSDL --'' 
    ''-- + �?ầu vào: pv_xmlDocument: XmlDocument chứa dữ liệu cần thiết   --''
    ''-- + �?ầu ra: N/A                                                   --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                      --''
    ''-- + Ghi chú: N/A                                                  --''
    ''---------------------------------------------------------------------''
    'Private Function AddUsersToGroup(ByRef pv_xmlDocument As XmlDocumentEx) As Long
    '    Try
    '        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
    '        Dim v_strClause, v_strBranchId, v_strTellerId As String
    '        Dim v_strLocal As String
    '        Dim v_strAutoId As String

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
    '            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
    '        Else
    '            v_strClause = String.Empty
    '        End If

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
    '            v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
    '        Else
    '            v_strBranchId = String.Empty
    '        End If

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
    '            v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
    '        Else
    '            v_strTellerId = String.Empty
    '        End If

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
    '            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
    '        Else
    '            v_strLocal = String.Empty
    '        End If

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
    '            v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
    '        Else
    '            v_strAutoId = String.Empty
    '        End If

    '        'Inquiry data
    '        Dim v_obj As DataAccess
    '        If v_strLocal = "Y" Then
    '            v_obj = New DataAccess
    '        ElseIf v_strLocal = "N" Then
    '            v_obj = New DataAccess
    '            v_obj.NewDBInstance(gc_MODULE_HOST)
    '        End If

    '        Dim v_arrClause(), v_arrGroup(), v_arrUsr(), v_arrBRGR() As String
    '        Dim v_strGroupId, v_strUserId, v_strBRID As String

    '        v_arrClause = v_strClause.Split("$")
    '        'v_strGrpid = v_arrClause(0)
    '        'v_arrTlid = v_arrClause(1).Split("|")
    '        'v_arrBrid = v_arrClause(2).Split("|")

    '        For i As Integer = 0 To v_arrClause.Length - 2
    '            v_arrGroup = v_arrClause(i).Split("#")
    '            v_arrBRGR = v_arrGroup(0).Split("|")
    '            'v_strGroupId = CStr(v_arrGroup(0)).Trim
    '            v_strBRID = CStr(v_arrBRGR(0)).Trim
    '            v_strGroupId = CStr(v_arrBRGR(1)).Trim
    '            'Delete data in database
    '            Dim v_strCmdDelSQL As String
    '            v_strCmdDelSQL = "DELETE FROM TLGRPUSERS WHERE GRPID = '" & v_strGroupId & "' and BRID = '" & v_strBRID & "'"
    '            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

    '            'Update database
    '            For j As Integer = 1 To v_arrGroup.Length - 2
    '                v_arrUsr = v_arrGroup(j).Split("|")
    '                v_strUserId = CStr(v_arrUsr(1)).Trim

    '                Dim v_strCmdInsertSQL As String
    '                v_strCmdInsertSQL = "INSERT INTO TLGRPUSERS(AUTOID, GRPID, BRID, TLID, DESCRIPTION) " _
    '                                    & "VALUES(SEQ_TLGRPUSERS.NEXTVAL, '" & v_strGroupId & "', '" & v_strBRID & "', '" & v_strUserId & "', '')"
    '                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
    '            Next
    '        Next

    '        'ContextUtil.SetComplete()
    '        Return ERR_SYSTEM_OK
    '    Catch ex As Exception
    '        'ContextUtil.SetAbort()
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        Throw ex
    '    End Try
    'End Function


    Private Function AddUsersToGroup(ByRef pv_xmlDocument As XmlDocumentEx) As Long
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
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_arrClause(), v_arrGroup(), v_arrUsr(), v_arrBRGR() As String
            Dim v_strGroupId, v_strUserId, v_strBRID, v_strGRPTYPE As String

            v_arrClause = v_strClause.Split("$")
            'v_strGrpid = v_arrClause(0)
            'v_arrTlid = v_arrClause(1).Split("|")
            'v_arrBrid = v_arrClause(2).Split("|")
            Dim v_strSQL As String
            'Dim v_dsOV As DataSet
            'Dim v_strOldValue As String = String.Empty
            'Dim v_strNewValue As String = String.Empty
            'Dim v_arrOldValue() As String

            For i As Integer = 0 To v_arrClause.Length - 2
                v_arrGroup = v_arrClause(i).Split("#")
                v_arrBRGR = v_arrGroup(0).Split("|")
                'v_strGroupId = CStr(v_arrGroup(0)).Trim
                v_strBRID = CStr(v_arrBRGR(0)).Trim
                v_strGRPTYPE = CStr(v_arrBRGR(1)).Trim
                v_strGroupId = CStr(v_arrBRGR(2)).Trim

                'Lay du lieu cu de ghi log
                'v_strOldValue = String.Empty
                'v_strNewValue = String.Empty
                Dim v_dsOV As DataSet
                Dim v_strOldValue As String = String.Empty
                Dim v_strNewValue As String = String.Empty
                Dim v_arrOldValue() As String

                v_strSQL = "SELECT BRID, TLID FROM TLGRPUSERS WHERE GRPID = '" & v_strGroupId & "' and BRID = '" & v_strBRID & "' ORDER BY BRID, TLID"
                v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_dsOV.Tables(0).Rows.Count > 0 Then
                    ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count - 1)
                    For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                        v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("TLID")
                        v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("TLID")
                    Next
                End If

                'Delete data in database
                Dim v_strCmdDelSQL As String
                v_strCmdDelSQL = "DELETE FROM TLGRPUSERS WHERE GRPID = '" & v_strGroupId & "' and BRID = '" & v_strBRID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

                'Update database
                For j As Integer = 1 To v_arrGroup.Length - 2
                    v_arrUsr = v_arrGroup(j).Split("|")
                    v_strUserId = CStr(v_arrUsr(1)).Trim

                    Dim v_strCmdInsertSQL As String
                    v_strCmdInsertSQL = "INSERT INTO TLGRPUSERS(AUTOID, GRPID, BRID, TLID, DESCRIPTION) " _
                                        & "VALUES(SEQ_TLGRPUSERS.NEXTVAL, '" & v_strGroupId & "', '" & v_strBRID & "', '" & v_strUserId & "', '')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                    'Ghi nhan du lieu de ghi log
                    v_strNewValue = v_strNewValue & "|" & v_strUserId
                Next

                'Tim nhom/NSD them vao va nhom/NSD remove de ghi log
                'Nhom/NSD co trong chuoi nhom/NSD cu & ko co trong chuoi nhom/NSD moi la cac nhom/NSD bi remove
                'Nhom/NSD co trong chuoi nhom/NSD moi & ko co trong chuoi nhom/NSD cu la cac nhom/NSD dc them moi
                Dim v_strUserRemoved As String = String.Empty
                Dim v_strUserAdded As String = String.Empty
                If Not v_arrOldValue Is Nothing Then
                    For k As Integer = 0 To v_arrOldValue.Length - 1
                        If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 Then
                            v_strUserRemoved = v_strUserRemoved & ", " & v_arrOldValue(k)
                        End If
                    Next
                    v_strUserRemoved = Mid(v_strUserRemoved, 2)
                End If

                If Not v_arrGroup Is Nothing Then
                    For m As Integer = 1 To v_arrGroup.Length - 2
                        If Not InStr(v_strOldValue, Mid(v_arrGroup(m), InStr(v_arrGroup(m), "|") + 1)) > 0 Then
                            v_strUserAdded = v_strUserAdded & ", " & Mid(v_arrGroup(m), InStr(v_arrGroup(m), "|") + 1)
                        End If
                    Next
                    v_strUserAdded = Mid(v_strUserAdded, 2)
                End If

                'Ghi log thay doi
                If v_strUserAdded.Length > 0 Or v_strUserRemoved.Length > 0 Then
                    v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                        & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                        & "VALUES (seq_rightassign_log.NEXTVAL, 'TLGRPUSERS', '" & v_strBRID & "', '" & v_strGroupId & "', 'G', '','','" & v_strGRPTYPE & "'," & ControlChars.CrLf _
                        & "     '','','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strUserRemoved & "','" & v_strUserAdded & "', GETCURRDATE)"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Next

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function AddUser2Groups(ByRef pv_xmlDocument As XmlDocumentEx) As Long
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
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_arrClause(), v_arrGroup(), v_arrUsr(), v_arrBRGR() As String
            Dim v_strGroupId, v_strUserId, v_strBRID, v_strGRPTYPE As String

            v_arrClause = v_strClause.Split("$")
            'v_strGrpid = v_arrClause(0)
            'v_arrTlid = v_arrClause(1).Split("|")
            'v_arrBrid = v_arrClause(2).Split("|")

            For i As Integer = 0 To v_arrClause.Length - 2
                v_arrUsr = v_arrClause(i).Split("#")
                v_arrBRGR = v_arrUsr(0).Split("|")
                'v_strGroupId = CStr(v_arrGroup(0)).Trim
                v_strBRID = CStr(v_arrBRGR(0)).Trim
                v_strGRPTYPE = CStr(v_arrBRGR(1)).Trim
                v_strUserId = CStr(v_arrBRGR(2)).Trim

                'Lay du lieu cu de ghi log
                'v_strOldValue = String.Empty
                'v_strNewValue = String.Empty
                Dim v_strSQL As String
                Dim v_dsOV As DataSet
                Dim v_strOldValue As String = String.Empty
                Dim v_strNewValue As String = String.Empty
                Dim v_arrOldValue() As String

                v_strSQL = "SELECT TGU.BRID, TGU.GRPID FROM TLGRPUSERS TGU, TLGROUPS TLG WHERE TGU.TLID = '" & v_strUserId & "' and TGU.BRID = '" & v_strBRID & "' AND TGU.GRPID = TLG.GRPID AND TLG.GRPTYPE = '" & v_strGRPTYPE & "' ORDER BY TGU.BRID, TGU.TLID"
                v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_dsOV.Tables(0).Rows.Count > 0 Then
                    ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count - 1)
                    For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                        v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("GRPID")
                        v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("GRPID")
                    Next
                End If

                'Delete data in database
                'If i = 0 Then
                Dim v_strCmdDelSQL As String
                v_strCmdDelSQL = "DELETE FROM TLGRPUSERS TGU WHERE TGU.TLID = '" & v_strUserId & "' and TGU.BRID = '" & v_strBRID & "' AND EXISTS(SELECT GRPID FROM TLGROUPS TLG WHERE TLG.grptype = '" & v_strGRPTYPE & "' AND TLG.grpid = TGU.grpid)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                'End If

                'Update database
                For j As Integer = 1 To v_arrUsr.Length - 2
                    v_arrGroup = v_arrUsr(j).Split("|")
                    v_strGroupId = CStr(v_arrGroup(1)).Trim

                    Dim v_strCmdInsertSQL As String
                    v_strCmdInsertSQL = "INSERT INTO TLGRPUSERS(AUTOID, GRPID, BRID, TLID, DESCRIPTION) " _
                                        & "VALUES(SEQ_TLGRPUSERS.NEXTVAL, '" & v_strGroupId & "', '" & v_strBRID & "', '" & v_strUserId & "', '')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                    'Ghi nhan du lieu de ghi log
                    v_strNewValue = v_strNewValue & "|" & v_strGroupId
                Next

                'Tim nhom/NSD them vao va nhom/NSD remove de ghi log
                'Nhom/NSD co trong chuoi nhom/NSD cu & ko co trong chuoi nhom/NSD moi la cac nhom/NSD bi remove
                'Nhom/NSD co trong chuoi nhom/NSD moi & ko co trong chuoi nhom/NSD cu la cac nhom/NSD dc them moi
                Dim v_strGrpRemoved As String = String.Empty
                Dim v_strGrpAdded As String = String.Empty

                'Trung.luu them if kiem tra
                If Not v_arrOldValue Is Nothing Then
                    For k As Integer = 0 To v_arrOldValue.Length - 1
                        If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 Then
                            v_strGrpRemoved = v_strGrpRemoved & ", " & v_arrOldValue(k)
                        End If
                    Next
                End If
                
                v_strGrpRemoved = Mid(v_strGrpRemoved, 2)

                For m As Integer = 1 To v_arrUsr.Length - 2
                    If Not InStr(v_strOldValue, Mid(v_arrUsr(m), InStr(v_arrUsr(m), "|") + 1)) > 0 Then
                        v_strGrpAdded = v_strGrpAdded & ", " & Mid(v_arrUsr(m), InStr(v_arrUsr(m), "|") + 1)
                    End If
                Next
                v_strGrpAdded = Mid(v_strGrpAdded, 2)

                'Ghi log thay doi
                If v_strGrpAdded.Length > 0 Or v_strGrpRemoved.Length > 0 Then
                    v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                        & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                        & "VALUES (seq_rightassign_log.NEXTVAL, 'TLGRPUSERS', '" & v_strBRID & "', '" & v_strUserId & "', 'U', '','','" & v_strGRPTYPE & "'," & ControlChars.CrLf _
                        & "     '','','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strGrpRemoved & "','" & v_strGrpAdded & "', GETCURRDATE)"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

            Next

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function AddAftypeToGroup(ByRef pv_xmlDocument As XmlDocumentEx) As Long
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

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
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
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_arrClause(), v_arrGroup(), v_arrAftype() As String
            Dim v_strGroupId, v_strAftype As String

            v_arrClause = v_strClause.Split("$")
            'v_strGrpid = v_arrClause(0)
            'v_arrTlid = v_arrClause(1).Split("|")
            'v_arrBrid = v_arrClause(2).Split("|")

            For i As Integer = 0 To v_arrClause.Length - 2
                v_arrGroup = v_arrClause(i).Split("#")
                v_strGroupId = CStr(v_arrGroup(0)).Trim

                'Lay du lieu cu de ghi log
                'v_strOldValue = String.Empty
                'v_strNewValue = String.Empty
                Dim v_strSQL As String
                Dim v_dsOV As DataSet
                Dim v_strOldValue As String = String.Empty
                Dim v_strNewValue As String = String.Empty
                Dim v_arrOldValue() As String

                v_strSQL = "SELECT AFTYPE FROM TLGRPAFTYPE WHERE GRPID = '" & v_strGroupId & "' ORDER BY AFTYPE"
                v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_dsOV.Tables(0).Rows.Count > 0 Then
                    ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count - 1)
                    For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                        v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("AFTYPE")
                        v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("AFTYPE")
                    Next
                End If

                'Delete data in database
                Dim v_strCmdDelSQL As String
                v_strCmdDelSQL = "DELETE FROM TLGRPAFTYPE WHERE GRPID = '" & v_strGroupId & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

                'Update database
                For j As Integer = 1 To v_arrGroup.Length - 2
                    v_arrAftype = v_arrGroup(j).Split("|")
                    v_strAftype = CStr(v_arrAftype(1)).Trim

                    Dim v_strCmdInsertSQL As String
                    v_strCmdInsertSQL = "INSERT INTO TLGRPAFTYPE(AUTOID, GRPID, BRID, AFTYPE, DESCRIPTION) " _
                                        & "VALUES(seq_tlgrpaftype.nextval, '" & v_strGroupId & "', '" & v_strBranchId & "', '" & v_strAftype & "', '')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                    'Ghi nhan du lieu de ghi log
                    v_strNewValue = v_strNewValue & "|" & v_strAftype
                Next

                'Tim AFTYPE them vao va AFTYPE remove de ghi log
                'AFTYPE co trong chuoi AFTYPE cu & ko co trong chuoi AFTYPE moi la cac AFTYPE bi remove
                'AFTYPE co trong chuoi AFTYPE moi & ko co trong chuoi AFTYPE cu la cac AFTYPE dc them moi
                Dim v_strAftypeRemoved As String = String.Empty
                Dim v_strAftypeAdded As String = String.Empty
                For k As Integer = 0 To v_arrOldValue.Length - 1
                    If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 Then
                        v_strAftypeRemoved = v_strAftypeRemoved & ", " & v_arrOldValue(k)
                    End If
                Next
                v_strAftypeRemoved = Mid(v_strAftypeRemoved, 2)

                For m As Integer = 1 To v_arrGroup.Length - 2
                    If Not InStr(v_strOldValue, Mid(v_arrGroup(m), InStr(v_arrGroup(m), "|") + 1)) > 0 Then
                        v_strAftypeAdded = v_strAftypeAdded & ", " & Mid(v_arrGroup(m), InStr(v_arrGroup(m), "|") + 1)
                    End If
                Next
                v_strAftypeAdded = Mid(v_strAftypeAdded, 2)

                'Ghi log thay doi
                If v_strAftypeAdded.Length > 0 Or v_strAftypeRemoved.Length > 0 Then
                    v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                        & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                        & "VALUES (seq_rightassign_log.NEXTVAL, 'TLGRPAFTYPE', '', '" & v_strGroupId & "', 'G', '','','A'," & ControlChars.CrLf _
                        & "     '','','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strAftypeRemoved & "','" & v_strAftypeAdded & "', GETCURRDATE)"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Next

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class

