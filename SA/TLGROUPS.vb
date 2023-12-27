Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class TLGROUPS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TLGROUPS"
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
                Case "GetGroupId"
                    v_lngErrCode = GetGroupId(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "AddUsersToGroup"
                    v_lngErrCode = AddUsersToGroup(pv_xmlDocument)
                Case "GetUserParentMenu"
                    v_lngErrCode = GetUserParentMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "GetUserChildMenu"
                    v_lngErrCode = GetUserChildMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "GetTransParentMenu"
                    v_lngErrCode = GetTransParentMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "GetRptParentMenu"
                    v_lngErrCode = GetRptParentMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "GetRptChildMenu"
                    v_lngErrCode = GetRptChildMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "GetTransChildMenu"
                    v_lngErrCode = GetTransChildMenu(v_strObjMsg)
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                Case "FunctionAssignment"
                    v_lngErrCode = FunctionAssignment(pv_xmlDocument)
                Case "ReportAssignment"
                    v_lngErrCode = ReportAssignment(pv_xmlDocument)
                Case "TransactionAssignment"
                    v_lngErrCode = TransactionAssignment(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
        End Try
    End Function

    Overrides Function Delete(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = _CoreDelete(v_strMessage)

            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = "TLGROUPS.Delete"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Information")
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

                Dim v_arrClause(), v_strGrpidDel As String
                v_arrClause = v_strClause.Split("=")
                v_strGrpidDel = v_arrClause(1)
                v_strGrpidDel = Replace(v_strGrpidDel, "'", "").Trim

                'Delete all from CMDAUTH and TLAUTH
                Dim v_strDelSQL As String
                'Delete from CMDAUTH
                v_strDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strGrpidDel & "' AND AUTHTYPE = 'G'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strDelSQL)
                'Delete from TLAUTH
                v_strDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strGrpidDel & "' AND AUTHTYPE = 'G'"
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

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGrpId, v_strGrpName As String
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
                        Case "GRPID"
                            v_strGrpId = Trim(v_strVALUE)
                        Case "GRPNAME"
                            v_strGrpName = Trim(v_strVALUE)
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

            'Kiểm tra GRPID không được trùng
            v_strSQL = "SELECT COUNT(GRPID) FROM " & ATTR_TABLE & " WHERE GRPID = '" & v_strGrpId & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_GRPID_DUPLICATED
                End If
            End If
            'Kiểm tra GRPNAME không được trùng
            v_strSQL = "SELECT COUNT(GRPNAME) FROM " & ATTR_TABLE & " WHERE GRPNAME = '" & v_strGrpName & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_GRPNAME_DUPLICATED
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

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentGrpid As String
            Dim v_strLocal As String
            Dim v_strSQL As String
            Dim v_strAutoid As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoid = String.Empty
            End If

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

            'Không cho phép xoá nhóm ngư?i s�ử dụng không rỗng
            v_strSQL = "SELECT COUNT(GRPID) FROM TLGRPUSERS WHERE GRPID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_GRP_HAS_CHILD
                End If
            End If

            'Do not allow delete group if this group caring customers
            v_strSQL = "SELECT COUNT(CF.CUSTID) FROM TLGROUPS GRP, CFMAST CF WHERE GRP.GRPTYPE = '2' AND CF.CAREBY = GRP.GRPID AND GRP.GRPID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLGROUPS_CAREBY
                End If
            End If


            ''Không cho phép xoá nhóm NSD đã được phân quy?n
            'v_strSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHTYPE = 'G' AND AUTHID " & Mid(v_strClause, InStr(v_strClause, "="))
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_GRP_HAS_CMDAUTH
            '    End If
            'End If

            ''Kh�ông cho phép xoá nhóm NSD đã được cho phép thực hiện giao dịch
            'v_strSQL = "SELECT COUNT(AUTHID) FROM TLAUTH WHERE AUTHTYPE = 'G' AND AUTHID " & Mid(v_strClause, InStr(v_strClause, "="))
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_GRP_HAS_TLAUTH
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
#End Region

#Region " Private methods "

    ''----------------------------------------------------''
    ''-- + Mục đích: Lấy GroupId chưa sử dụng nh? nh�ất  --'' 
    ''-- + ?�ầu vào: pv_strObjMsg: Các thông số tìm kiếm --''
    ''-- + ?�ầu ra: GroupId                              --''
    ''-- + Tác giả: Nguyễn Nhân Thế                     --''
    ''-- + Ghi chú: N/A                                 --''
    ''----------------------------------------------------''
    Private Function GetGroupId(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strLocal As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Get GroupId that not in use
            Dim v_strSQL As String
            v_strSQL = "SELECT MAX(ODR)+1 GRPID FROM " _
                    & "(SELECT ROWNUM ODR, INVGRPID " _
                    & " FROM (SELECT GRPID INVGRPID FROM TLGROUPS ORDER BY GRPID) " _
                    & " WHERE TO_NUMBER(INVGRPID)=ROWNUM) "

            'Inquiry data
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = v_strSQL

            Dim v_ds As DataSet = v_obj.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    ''---------------------------------------------------------------------''
    ''-- + Mục đích: Ghi dữ liệu định nghĩa ngư?i d�ùng cho nhóm vào CSDL --'' 
    ''-- + ?�ầu vào: pv_xmlDocument: XmlDocument chứa dữ liệu cần thiết   --''
    ''-- + ?�ầu ra: N/A                                                   --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                      --''
    ''-- + Ghi chú: N/A                                                  --''
    ''---------------------------------------------------------------------''
    Private Function AddUsersToGroup(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            Dim v_strGrpid As String
            Dim v_arrClause() As String
            Dim v_arrTlid() As String
            Dim v_arrBrid() As String

            v_arrClause = v_strClause.Split("#")
            v_strGrpid = v_arrClause(0)
            v_arrTlid = v_arrClause(1).Split("|")
            v_arrBrid = v_arrClause(2).Split("|")

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Delete data in database
            Dim v_strCmdDelSQL As String
            v_strCmdDelSQL = "DELETE FROM TLGRPUSERS WHERE GRPID = '" & v_strGrpid & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Update database
            For i As Integer = 0 To v_arrTlid.Length - 2
                Dim v_strCmdInsertSQL As String
                v_strCmdInsertSQL = "INSERT INTO TLGRPUSERS(AUTOID, GRPID, BRID, TLID, DESCRIPTION) " _
                                    & "VALUES(SEQ_TLGRPUSERS.NEXTVAL, '" & v_strGrpid & "', '" & v_arrBrid(i) & "', '" & v_arrTlid(i) & "', '')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            Next

            '' Get access right of group
            'Dim v_strFuncSQL, v_strRptSQL, v_strTransSQL, v_strTlLimit As String
            'Dim v_dsFunc, v_dsRpt, v_dsTrans, v_dsTlLimit As DataSet

            ''Get Function access right
            'v_strFuncSQL = "SELECT CMDCODE, CMDALLOW, STRAUTH FROM CMDAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGrpid & "' AND CMDTYPE = 'M'"
            'Dim v_objFunc As New DataAccess(gc_MODULE_HOST)
            'v_dsFunc = v_objFunc.ExecuteSQLReturnDataset(CommandType.Text, v_strFuncSQL)

            ''Get Report access right
            'v_strRptSQL = "SELECT CMDCODE, CMDALLOW, STRAUTH FROM CMDAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGrpid & "' AND CMDTYPE = 'R'"
            'Dim v_objRpt As New DataAccess(gc_MODULE_HOST)
            'v_dsRpt = v_objRpt.ExecuteSQLReturnDataset(CommandType.Text, v_strRptSQL)

            ''Get Transaction access right
            'v_strTransSQL = "SELECT CMDCODE, CMDALLOW FROM CMDAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGrpid & "' AND CMDTYPE = 'T'"
            'Dim v_objTrans As New DataAccess(gc_MODULE_HOST)
            'v_dsTrans = v_objTrans.ExecuteSQLReturnDataset(CommandType.Text, v_strTransSQL)

            ''Get Transactions limit
            'v_strTlLimit = "SELECT CODETYPE, CODEID, TLTXCD, TLTYPE, TLLIMIT FROM TLAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGrpid & "'"
            'Dim v_objTlLimit As New DataAccess(gc_MODULE_HOST)
            'v_dsTlLimit = v_objTlLimit.ExecuteSQLReturnDataset(CommandType.Text, v_strTlLimit)

            ''Check and assign access right for users
            'If v_arrTlid.Length > 1 Then
            '    For i As Integer = 0 To v_arrTlid.Length - 2
            '        'Check access right of user
            '        'If user has been in assignment list, do not assign again
            '        Dim v_strCountSQL As String
            '        'Check Function access right
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrTlid(i) & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
            '        Dim v_dsCount As DataSet
            '        Dim v_objCount As New DataAccess(gc_MODULE_HOST)
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                For j As Integer = 0 To v_dsFunc.Tables(0).Rows.Count - 1
            '                    Dim v_strCMDCODE, v_strCMDALLOW, v_strAUTH As String
            '                    v_strCMDCODE = CStr(v_dsFunc.Tables(0).Rows(j)("CMDCODE"))
            '                    v_strCMDALLOW = CStr(v_dsFunc.Tables(0).Rows(j)("CMDALLOW"))
            '                    v_strAUTH = CStr(v_dsFunc.Tables(0).Rows(j)("STRAUTH"))
            '                    Dim v_strCmdInsertSQL As String
            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrTlid(i) & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAUTH & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If

            '        'Check Report Access right
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrTlid(i) & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'R'"
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                For j As Integer = 0 To v_dsRpt.Tables(0).Rows.Count - 1
            '                    Dim v_strCMDCODE, v_strCMDALLOW, v_strAUTH As String
            '                    v_strCMDCODE = CStr(v_dsRpt.Tables(0).Rows(j)("CMDCODE"))
            '                    v_strCMDALLOW = CStr(v_dsRpt.Tables(0).Rows(j)("CMDALLOW"))
            '                    v_strAUTH = CStr(v_dsRpt.Tables(0).Rows(j)("STRAUTH"))
            '                    Dim v_strCmdInsertSQL As String
            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrTlid(i) & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAUTH & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If

            '        'Check Transaction Access right
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrTlid(i) & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T'"
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                For j As Integer = 0 To v_dsTrans.Tables(0).Rows.Count - 1
            '                    Dim v_strCMDCODE, v_strCMDALLOW As String
            '                    v_strCMDCODE = CStr(v_dsTrans.Tables(0).Rows(j)("CMDCODE"))
            '                    v_strCMDALLOW = CStr(v_dsTrans.Tables(0).Rows(j)("CMDALLOW"))
            '                    Dim v_strCmdInsertSQL As String
            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrTlid(i) & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '                'Insert transaction limits
            '                For k As Integer = 0 To v_dsTlLimit.Tables(0).Rows.Count - 1
            '                    Dim v_strCODETYPE, v_strCODEID, v_strTLTXCD, v_strTLTYPE, v_strLIMIT As String
            '                    v_strCODETYPE = CStr(v_dsTlLimit.Tables(0).Rows(k)("CODETYPE"))
            '                    v_strCODEID = CStr(v_dsTlLimit.Tables(0).Rows(k)("CODEID"))
            '                    v_strTLTXCD = CStr(v_dsTlLimit.Tables(0).Rows(k)("TLTXCD"))
            '                    v_strTLTYPE = CStr(v_dsTlLimit.Tables(0).Rows(k)("TLTYPE"))
            '                    v_strLIMIT = CStr(v_dsTlLimit.Tables(0).Rows(k)("TLLIMIT"))
            '                    Dim v_dblLIMIT As Double
            '                    If IsNumeric(v_strLIMIT) Then
            '                        v_dblLIMIT = CDbl(v_strLIMIT)
            '                    Else
            '                        v_dblLIMIT = 0
            '                    End If
            '                    Dim v_strCmdInsertSQL As String
            '                    v_strCmdInsertSQL = "INSERT INTO TLAUTH(AUTOID, AUTHTYPE, AUTHID, CODETYPE, CODEID, TLTXCD, TLTYPE, TLLIMIT) " _
            '                                        & "VALUES(SEQ_TLAUTH.NEXTVAL, 'U', '" & v_arrTlid(i) & "', 'C', '" & v_strCODEID & "', '" & v_strTLTXCD & "', '" & v_strTLTYPE & "', '" & v_dblLIMIT & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If

            '    Next
            'End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''----------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node cha của cây menu chức năng --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm       --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                       --''
    ''-- + Tác giả:                                                       --''
    ''-- + Ghi chú: N/A                                                   --''
    ''----------------------------------------------------------------------''
    Private Function GetUserParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strGroupId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strGroupId = Trim(v_strGroupId)
            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                    & "from CMDMENU M " _
                                    & "where M.LEV = 1 " _
                                    & "order by M.CMDID"
            'Else
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                    & "from CMDMENU M, CMDAUTH A " _
            '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '                    & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
            '                    & "order by M.CMDID"
            'End If


            'v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.LEV LEV, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    & "from CMDMENU M, CMDAUTH A " _
            '    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '    & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
            '    & "order by M.CMDID"

            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "minhtk"
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''----------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node con của cây menu chức năng --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm       --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                       --''
    ''-- + Tác giả:                                                       --''
    ''-- + Ghi chú: N/A                                                   --''
    ''----------------------------------------------------------------------''
    Private Function GetUserChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String
        Dim v_strArr(), v_strGroupId, v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            'If v_strArr.Length = 2 Then
            v_strGroupId = Trim(v_strArr(0))
            v_strParentKey = Trim(v_strArr(1))
            'End If
            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, M.LAST LAST, " _
                                    & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                    & "M.AUTHCODE AUTHCODE, 'YYYY' STRAUTH " _
                                    & "from CMDMENU M " _
                                    & "where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                    & "order by M.CMDID"
            'Else
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, M.LAST LAST, decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                    & "from CMDMENU M, CMDAUTH A " _
            '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '                    & "and A.AUTHID = '" & v_strTellerId & "' and A.CMDTYPE = 'M' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
            '                    & "order by M.CMDID"
            'End If

            '& "and (M.MENUTYPE = 'A' OR M.MENUTYPE = 'M' OR M.MENUTYPE = 'P') " _

            'v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.LEV LEV, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    & "from CMDMENU M, CMDAUTH A " _
            '    & "where M.CMDID = A.CMDCODE (+) and A.AUTHTYPE (+) = 'G' and A.CMDALLOW (+) = 'Y' " _
            '    & "and A.AUTHID (+) = '" & v_strTellerId & "' and A.CMDTYPE (+) = 'M' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
            '    & "order by M.CMDID"

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''----------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node cha của cây menu giao dịch --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm       --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                       --''
    ''-- + Tác giả:                                                       --''
    ''-- + Ghi chú: N/A                                                   --''
    ''----------------------------------------------------------------------''
    Private Function GetTransParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strGroupId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, 0 IMGINDEX, C.CMDID CMDID, C.LEV LEV, 'Y' CMDALLOW, 'YYYY' STRAUTH " _
                                    & "FROM APPMODULES N, CMDMENU C " _
                                    & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'T' ORDER BY C.CMDID"
            'Else
            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, C.CMDID CMDID, C.LEV LEV " _
            '                & "FROM APPMODULES N, CMDMENU C " _
            '                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'T') M, CMDAUTH A " _
            '        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & v_strTellerId & "' AND A.CMDTYPE = 'M' AND A.CMDALLOW = 'Y' " _
            '        & "ORDER BY M.CMDID "
            'End If


            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, 1 LEV, A.CMDALLOW CMDALLOW " _
            '    & "FROM APPMODULES M, CMDAUTH A " _
            '    & "WHERE M.TXCODE = A.CMDCODE (+) AND A.AUTHTYPE (+)= 'G' AND A.AUTHID (+)= '" & v_strTellerId & "' AND A.CMDTYPE (+)= 'T' AND A.CMDALLOW (+)= 'Y' " _
            '    & "ORDER BY M.TXCODE"

            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "minhtk"
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''--------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node cha của cây menu báo cáo --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm     --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                     --''
    ''-- + Tác giả:                                                     --''
    ''-- + Ghi chú: N/A                                                 --''
    ''--------------------------------------------------------------------''
    Private Function GetRptParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strGroupId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, 0 IMGINDEX, C.CMDID CMDID, C.LEV, 'Y' CMDALLOW, 'YYYY' STRAUTH " _
                    & "FROM APPMODULES N, CMDMENU C " _
                    & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R' ORDER BY C.CMDID "
            'Else
            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '       & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, C.CMDID CMDID, C.LEV " _
            '               & "FROM APPMODULES N, CMDMENU C " _
            '               & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R') M, CMDAUTH A " _
            '       & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & v_strTellerId & "' AND A.CMDTYPE = 'M' AND A.CMDALLOW = 'Y' " _
            '       & "ORDER BY M.CMDID "
            'End If


            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    & "FROM APPMODULES M, CMDAUTH A " _
            '    & "WHERE M.TXCODE = A.CMDCODE (+) AND A.AUTHTYPE (+)= 'G' AND A.AUTHID (+)= '" & v_strTellerId & "' AND A.CMDTYPE (+)= 'R' AND A.CMDALLOW (+)= 'Y' " _
            '    & "ORDER BY M.TXCODE"

            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "minhtk"
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''--------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node con của cây menu báo cáo --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm     --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                     --''
    ''-- + Tác giả:                                                     --''
    ''-- + Ghi chú: N/A                                                 --''
    ''--------------------------------------------------------------------''
    Private Function GetRptChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String
        Dim v_strArr(), v_strGroupId, v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            'If v_strArr.Length = 2 Then
            v_strGroupId = Trim(v_strArr(0))
            v_strParentKey = Trim(v_strArr(1))
            'End If

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT M.RPTID RPTID, M.MODCODE MODCODE, M.DESCRIPTION RPTNAME,M.CMDTYPE CMDTYPE, 'Y' CMDALLOW, 'YYYY' STRAUTH, 3 IMGINDEX, 2 LEV " _
                                    & "FROM RPTMASTER M " _
                                    & "WHERE M.MODCODE = '" & v_strParentKey & "' AND M.VISIBLE = 'Y'" _
                                    & "ORDER BY M.RPTID"
            'Else
            'v_strSQL = "SELECT M.RPTID RPTID, M.MODCODE MODCODE, M.DESCRIPTION RPTNAME, M.CMDTYPE CMDTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 3 IMGINDEX, 2 LEV " _
            '                & "FROM RPTMASTER M, CMDAUTH A " _
            '                & "WHERE M.MODCODE = '" & v_strParentKey & "' AND M.RPTID = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' AND M.VISIBLE = 'Y' " _
            '                & "ORDER BY M.RPTID"
            'End If


            'v_strSQL = "SELECT M.RPTID RPTID, M.MODCODE MODCODE, M.DESCRIPTION RPTNAME, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 3 IMGINDEX, 2 LEV " _
            '    & "FROM RPTMASTER M, CMDAUTH A " _
            '    & "WHERE M.MODCODE = '" & v_strParentKey & "' AND M.RPTID = A.CMDCODE (+) AND A.AUTHID (+) = '" & v_strTellerId & "' AND A.AUTHTYPE (+) = 'G' AND A.CMDTYPE (+) = 'R' AND A.CMDALLOW (+) = 'Y' " _
            '    & "ORDER BY M.RPTID"

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''----------------------------------------------------------------------''
    ''-- + Mục đích: Lấy dữ liệu fill lên node con của cây menu giao dịch --''
    ''-- + ?�ầu vào: pv_strObjMsg: Chuỗi chứa các đi?u ki�ện tìm kiếm       --''
    ''-- + ?�ầu ra: Dữ liệu lấy được                                       --''
    ''-- + Tác giả:                                                       --''
    ''-- + Ghi chú: N/A                                                   --''
    ''----------------------------------------------------------------------''
    Private Function GetTransChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String
        Dim v_strArr(), v_strGroupId, v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            v_strGroupId = Trim(v_strArr(0))
            v_strParentKey = Trim(v_strArr(1))

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 2 LEV " _
                                    & "FROM TLTX M " _
                                    & "WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strParentKey & "' ORDER BY M.TLTXCD"
            'Else
            'v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, A.CMDALLOW CMDALLOW, 3 IMGINDEX, 2 LEV " _
            '                        & "FROM TLTX M, CMDAUTH A " _
            '                        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strParentKey & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
            '                        & "ORDER BY M.TLTXCD "
            'End If


            'v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, A.CMDALLOW CMDALLOW, 3 IMGINDEX, 2 LEV " _
            '            & "FROM TLTX M, CMDAUTH A " _
            '            & "WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strParentKey & "' AND M.TLTXCD = A.CMDCODE (+) AND A.AUTHID (+) = '" & v_strTellerId & "' AND A.AUTHTYPE (+) = 'G' AND A.CMDTYPE (+) = 'T' AND A.CMDALLOW (+) = 'Y' " _
            '            & "ORDER BY M.TLTXCD "

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''------------------------------------------------------------------------''
    ''-- + Mục đích: Cập nhật các dữ liệu phân quy?n ch�ức năng vào CSDL     --''
    ''-- + ?�ầu vào: pv_xmlDocument: XmlDocument chứa các dữ liệu phân quy?n --''
    ''-- + �?�ầu ra: N/A                                                      --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                         --''
    ''-- + Ghi chú: N/A                                                     --''
    ''------------------------------------------------------------------------''
    Private Function FunctionAssignment(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            'Get Group information and strAuth
            Dim v_arrGrp(), v_arrStrAuth(), v_arrUsersId(), v_strGroupId As String
            v_arrGrp = v_strClause.Split("$")
            v_strGroupId = v_arrGrp(0)
            v_arrStrAuth = v_arrGrp(1).Split("#")
            v_arrUsersId = v_arrGrp(2).Split("#")

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Cap nhat thong tin NSD truoc khi xoa de ghi nhan log
            Dim v_strSQL As String
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'LAY NGAY HIEN TAI
            Dim v_ds As DataSet
            Dim v_strCurrDate As String
            v_strSQL = "SELECT TO_CHAR(GETCURRDATE,'DD/MM/YYYY') CURRDATE FROM DUAL"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCurrDate = v_ds.Tables(0).Rows(0)("CURRDATE")
            End If

            'Lay thong tin du lieu truoc khi cap nhat de log cac truong hop xoa quyen
            Dim v_arrOldValue() As String
            Dim v_strOldValue As String = String.Empty
            Dim v_strNewValue As String = String.Empty
            Dim v_dsOV As DataSet
            Dim hOldValue As New Hashtable
            v_strSQL = "SELECT CMDCODE, CMDALLOW || STRAUTH STRAUTH FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M' ORDER BY CMDCODE"
            v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsOV.Tables(0).Rows.Count > 0 Then
                ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count)
                For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                    v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("CMDCODE")
                    v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("CMDCODE")
                    hOldValue.Add(v_dsOV.Tables(0).Rows(j)("CMDCODE"), v_dsOV.Tables(0).Rows(j)("STRAUTH"))
                Next
            End If

            'Delete data in database
            Dim v_strCmdDelSQL As String
            'Delete Group information
            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'Delete Users information
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            '    Next
            'End If

            'Insert data to CMDAUTH table
            Dim v_strCmdInsertSQL As String
            Dim v_strCMDCODE, v_strCMDALLOW, v_strAuth, v_arrMenuKey() As String

            'Insert group's auth info
            For i As Integer = 0 To v_arrStrAuth.Length - 2
                v_arrMenuKey = v_arrStrAuth(i).Split("|")
                v_strCMDCODE = v_arrMenuKey(0)
                v_strAuth = v_arrMenuKey(2)
                v_strCMDALLOW = Mid(v_strAuth, 1, 1)
                'v_strAuth = Mid(v_strAuth, 2, 4)
                'GianhVG change for Appvove Right
                v_strAuth = Mid(v_strAuth, 2, 5)

                If Trim(v_strCMDALLOW) = "Y" Then
                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)

                    v_strNewValue = v_strNewValue & "|" & v_strCMDCODE
                End If
            Next

            'Tim cac chuc nang bi xoa quyen
            Dim v_strFuncRemoved As String = String.Empty
            For k As Integer = 0 To v_arrOldValue.Length - 1
                If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 Then
                    v_strFuncRemoved = v_strFuncRemoved & "|" & v_arrOldValue(k)
                End If
            Next
            v_strFuncRemoved = Mid(v_strFuncRemoved, 2)
            If v_strFuncRemoved.Length > 0 Then
                'Ghi nhan log cac chuc nang bi xoa quyen
                Dim v_arrFuncRemoved() As String
                v_arrFuncRemoved = v_strFuncRemoved.Split("|")
                For m As Integer = 0 To v_arrFuncRemoved.Length - 1
                    v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                        & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                        & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
                        & " '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrFuncRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If

            ''Insert users's auth info
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        'Check access right of user
            '        'If user has been in assignment list, do not assign again
            '        Dim v_strCountSQL As String
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'M'"
            '        Dim v_dsCount As DataSet
            '        Dim v_objCount As New DataAccess(gc_MODULE_HOST)
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                For j As Integer = 0 To v_arrStrAuth.Length - 2
            '                    v_arrMenuKey = v_arrStrAuth(j).Split("|")
            '                    v_strCMDCODE = v_arrMenuKey(0)
            '                    v_strAuth = v_arrMenuKey(2)
            '                    v_strCMDALLOW = Mid(v_strAuth, 1, 1)
            '                    v_strAuth = Mid(v_strAuth, 2, 4)

            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrUsersId(i) & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If
            '    Next
            'End If
            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''------------------------------------------------------------------------''
    ''-- + Mục đích: Cập nhật các dữ liệu phân quy?n b�áo cáo vào CSDL       --''
    ''-- + ?�ầu vào: pv_xmlDocument: XmlDocument chứa các dữ liệu phân quy?n --''
    ''-- + �?�ầu ra: N/A                                                      --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                         --''
    ''-- + Ghi chú: N/A                                                     --''
    ''------------------------------------------------------------------------''
    Private Function ReportAssignment(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            'Get Group information and strAuth
            Dim v_arrGrp(), v_arrStrAuth(), v_arrUsersId(), v_strGroupId As String
            v_arrGrp = v_strClause.Split("$")
            v_strGroupId = v_arrGrp(0)
            v_arrStrAuth = v_arrGrp(1).Split("#")
            v_arrUsersId = v_arrGrp(2).Split("#")


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Cap nhat thong tin NSD truoc khi xoa de ghi nhan log
            Dim v_strSQL As String
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE IN ('R','G')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'LAY NGAY HIEN TAI
            Dim v_ds As DataSet
            Dim v_strCurrDate As String
            v_strSQL = "SELECT TO_CHAR(GETCURRDATE,'DD/MM/YYYY') CURRDATE FROM DUAL"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCurrDate = v_ds.Tables(0).Rows(0)("CURRDATE")
            End If

            'Lay thong tin du lieu truoc khi cap nhat de log cac truong hop xoa quyen
            Dim v_arrOldValue() As String
            Dim v_arrOldValueFunc() As String
            Dim v_strOldValue As String = String.Empty
            Dim v_strOldValueFunc As String = String.Empty
            Dim v_strNewValue As String = String.Empty
            Dim v_strNewValueFunc As String = String.Empty
            Dim v_dsOV As DataSet
            Dim hOldValue As New Hashtable
            v_strSQL = "SELECT CMDCODE, CMDTYPE, CMDALLOW || STRAUTH STRAUTH FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE IN ('R','G') ORDER BY CMDCODE"
            v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsOV.Tables(0).Rows.Count > 0 Then
                ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count)
                For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                    v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("CMDCODE") & "#" & v_dsOV.Tables(0).Rows(j)("CMDTYPE")
                    v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("CMDCODE") & "#" & v_dsOV.Tables(0).Rows(j)("CMDTYPE")
                    hOldValue.Add(v_dsOV.Tables(0).Rows(j)("CMDCODE") & "#" & v_dsOV.Tables(0).Rows(j)("CMDTYPE"), v_dsOV.Tables(0).Rows(j)("STRAUTH"))
                Next
            End If

            'Delete data in database
            Dim v_strCmdDelSQL As String
            'Delete Group' informations
            'Delete assigned data of RptParents
            'v_strCmdDelSQL = "DELETE FROM CMDAUTH " _
            '                & "WHERE CMDCODE IN (SELECT CMDID CMDCODE " _
            '                                    & "FROM CMDMENU WHERE TRIM(MENUTYPE) = 'R') " _
            '                                    & "AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M' "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE IN ('R','G')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'Delete Users' informations
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'R'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            '    Next
            'End If

            'Insert data to CMDAUTH table
            Dim v_strCmdInsertSQL As String
            Dim v_strCMDCODE, v_strLEV, v_strCMDALLOW, v_strAuth, v_strMenuType, v_arrMenuKey() As String
            'Insert group's auth info
            For i As Integer = 0 To v_arrStrAuth.Length - 2
                v_arrMenuKey = v_arrStrAuth(i).Split("|")
                v_strCMDCODE = v_arrMenuKey(0)
                v_strLEV = v_arrMenuKey(1)
                v_strAuth = v_arrMenuKey(2)
                v_strMenuType = v_arrMenuKey(3)
                If v_strAuth.Length > 1 Then
                    v_strCMDALLOW = Mid(v_strAuth, 1, 1)
                    v_strAuth = Mid(v_strAuth, 2, 4)
                Else
                    v_strCMDALLOW = v_strAuth
                    v_strAuth = String.Empty
                End If
                
                If Trim(v_strMenuType) = "M" Then
                    'Cap nhat thong tin NSD truoc khi xoa de ghi nhan log
                    v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE CMDCODE = '" & v_strCMDCODE & "' AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE CMDCODE = '" & v_strCMDCODE & "' AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                    'Ghi nhan them de tim chuc nang/ bao cao xoa quyen
                    v_strOldValueFunc = v_strOldValueFunc & "|" & v_strCMDCODE

                    If Trim(v_strCMDALLOW) = "Y" Then
                        v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                            & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', '" & v_strMenuType & "', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                        'Ghi nhan de tim chuc nang/ bao cao xoa quyen
                        v_strNewValueFunc = v_strNewValueFunc & "|" & v_strCMDCODE
                    End If
                Else
                    If Trim(v_strCMDALLOW) = "Y" And CInt(v_strLEV) = 4 Then '
                        v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                            & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', '" & v_strMenuType & "', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                        'Ghi nhan de tim chuc nang/ bao cao xoa quyen
                        v_strNewValue = v_strNewValue & "|" & v_strCMDCODE & "#" & v_strMenuType
                    End If
                End If
                'Insert to database

                
                

                ''If CMDCODE is parents of Rpts
                'If CInt(v_strLEV) = 1 Then
                '    'Insert with right as functions
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                '    'Insert with right as Rpts
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                'End If

            Next

            'Tim cac chuc nang bi xoa quyen
            If v_strOldValueFunc.Length > 0 Then
                Dim v_strFuncRemoved As String = String.Empty
                v_arrOldValueFunc = v_strOldValueFunc.Split("|")
                For k As Integer = 0 To v_arrOldValueFunc.Length - 1
                    If Not InStr(v_strNewValueFunc, v_arrOldValueFunc(k)) > 0 And v_arrOldValueFunc(k).Length > 0 Then
                        v_strFuncRemoved = v_strFuncRemoved & "|" & v_arrOldValueFunc(k)
                    End If
                Next
                v_strFuncRemoved = Mid(v_strFuncRemoved, 2)
                If v_strFuncRemoved.Length > 0 Then
                    'Ghi nhan log cac chuc nang bi xoa quyen
                    Dim v_arrFuncRemoved() As String
                    v_arrFuncRemoved = v_strFuncRemoved.Split("|")
                    For m As Integer = 0 To v_arrFuncRemoved.Length - 1
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'YNNNNN','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If
            

            'Tim cac bao cao / general view bi xoa quyen
            If v_strOldValue.Length > 0 Then
                Dim v_strReportRemoved As String = String.Empty
                v_arrOldValue = v_strOldValue.Split("|")
                For k As Integer = 0 To v_arrOldValue.Length - 1
                    If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 And v_arrOldValue(k).Length > 0 Then
                        v_strReportRemoved = v_strReportRemoved & "|" & v_arrOldValue(k)
                    End If
                Next
                v_strReportRemoved = Mid(v_strReportRemoved, 2)
                If v_strReportRemoved.Length > 0 Then
                    'Ghi nhan log cac bao cao/ general view bi xoa quyen
                    Dim v_arrReportRemoved() As String
                    Dim v_strCMDTYPE, v_strCMDCODERemoved As String
                    v_arrReportRemoved = v_strReportRemoved.Split("|")
                    For m As Integer = 0 To v_arrReportRemoved.Length - 1
                        v_strCMDCODERemoved = Mid(v_arrReportRemoved(m), 1, InStr(v_arrReportRemoved(m), "#") - 1)
                        v_strCMDTYPE = Mid(v_arrReportRemoved(m), InStr(v_arrReportRemoved(m), "#") + 1)
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_strCMDCODERemoved & "','" & v_strCMDTYPE & "',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrReportRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If
            
            ''Insert users's auth info
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        'Check access right of user
            '        'If user has been in assignment list, do not assign again
            '        Dim v_strCountSQL As String
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'R'"
            '        Dim v_dsCount As DataSet
            '        Dim v_objCount As New DataAccess(gc_MODULE_HOST)
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                For j As Integer = 0 To v_arrStrAuth.Length - 2
            '                    v_arrMenuKey = v_arrStrAuth(j).Split("|")
            '                    v_strCMDCODE = v_arrMenuKey(0)
            '                    v_strAuth = v_arrMenuKey(2)
            '                    v_strCMDALLOW = Mid(v_strAuth, 1, 1)
            '                    v_strAuth = Mid(v_strAuth, 2, 4)

            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrUsersId(i) & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If

            '    Next
            'End If
            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''------------------------------------------------------------------------''
    ''-- + Mục đích: Cập nhật các dữ liệu phân quy?n giao d�ịch vào CSDL     --''
    ''-- + ?�ầu vào: pv_xmlDocument: XmlDocument chứa các dữ liệu phân quy?n --''
    ''-- + �?�ầu ra: N/A                                                      --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                         --''
    ''-- + Ghi chú: N/A                                                     --''
    ''------------------------------------------------------------------------''
    Private Function TransactionAssignment(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            'Get Group info and CMDAUTH's string and TLAUTH's string
            Dim v_arrGrp(), v_arrStrAuth(), v_arrUsersId() As String
            Dim v_strCmdauthString, v_strTlauthString, v_strGroupId As String
            v_arrGrp = v_strClause.Split("$")
            v_strGroupId = v_arrGrp(0)
            v_strCmdauthString = v_arrGrp(1)
            v_strTlauthString = v_arrGrp(2)
            v_arrUsersId = v_arrGrp(3).Split("#")

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Cap nhat thong tin NSD truoc khi xoa de ghi nhan log
            Dim v_strSQL As String
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'T'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'TLAUTH
            v_strSQL = "UPDATE TLAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'LAY NGAY HIEN TAI
            Dim v_ds As DataSet
            Dim v_strCurrDate As String
            v_strSQL = "SELECT TO_CHAR(GETCURRDATE,'DD/MM/YYYY') CURRDATE FROM DUAL"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCurrDate = v_ds.Tables(0).Rows(0)("CURRDATE")
            End If

            'Lay thong tin du lieu truoc khi cap nhat de log cac truong hop xoa quyen
            Dim v_arrOldValue() As String
            Dim v_arrOldTLValue() As String
            Dim v_arrOldValueFunc() As String
            Dim v_strOldValue As String = String.Empty
            Dim v_strOldTLValue As String = String.Empty
            Dim v_strNewTLValue As String = String.Empty
            Dim v_strOldValueFunc As String = String.Empty
            Dim v_strNewValue As String = String.Empty
            Dim v_strNewValueFunc As String = String.Empty
            Dim v_dsOV As DataSet
            Dim hOldTLValue As New Hashtable
            Dim hOldValue As New Hashtable

            v_strSQL = "SELECT CMDCODE, CMDTYPE, CMDALLOW || STRAUTH STRAUTH  FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'T' ORDER BY CMDCODE"
            v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsOV.Tables(0).Rows.Count > 0 Then
                ReDim v_arrOldValue(v_dsOV.Tables(0).Rows.Count)
                For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                    v_arrOldValue(j) = v_dsOV.Tables(0).Rows(j)("CMDCODE")
                    v_strOldValue = v_strOldValue & "|" & v_dsOV.Tables(0).Rows(j)("CMDCODE")
                    hOldValue.Add(v_dsOV.Tables(0).Rows(j)("CMDCODE"), v_dsOV.Tables(0).Rows(j)("STRAUTH"))
                Next
            End If
            'Thong tin phan quyen han muc
            v_strSQL = "SELECT TLTXCD, TLTYPE, TLLIMIT FROM TLAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' ORDER BY TLTXCD, TLTYPE"
            v_dsOV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsOV.Tables(0).Rows.Count > 0 Then
                'ReDim v_arrOldTLValue(v_dsOV.Tables(0).Rows.Count)
                For j As Integer = 0 To v_dsOV.Tables(0).Rows.Count - 1
                    'v_arrOldTLValue(j) = v_dsOV.Tables(0).Rows(j)("CMDCODE")
                    hOldTLValue.Add(v_dsOV.Tables(0).Rows(j)("TLTXCD") & v_dsOV.Tables(0).Rows(j)("TLTYPE"), v_dsOV.Tables(0).Rows(j)("TLLIMIT"))
                    v_strOldTLValue = v_strOldTLValue & "|" & v_dsOV.Tables(0).Rows(j)("TLTXCD") & v_dsOV.Tables(0).Rows(j)("TLTYPE")
                Next
            End If

            'Delete data in database
            Dim v_strCmdDelSQL As String
            'Delete group' informations
            'Delete data from CMDAUTH table
            'Delete assigned data of TransParents
            'v_strCmdDelSQL = "DELETE FROM CMDAUTH " _
            '                & "WHERE CMDCODE IN (SELECT CMDID CMDCODE " _
            '                                    & "FROM CMDMENU WHERE TRIM(MENUTYPE) = 'T') " _
            '                                    & "AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M' "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'T'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'Delete data from TLAUTH table
            v_strCmdDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Delete users' informations
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        'Delete data from CMDAUTH table
            '        v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            '        'Delete data from TLAUTH table
            '        v_strCmdDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'U'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            '    Next
            'End If

            'Insert data to CMDAUTH table
            Dim v_arrCMDAUTH() As String
            v_arrCMDAUTH = v_strCmdauthString.Split("#")
            Dim v_strCmdInsertSQL As String
            Dim v_arrMenuKey() As String
            Dim v_strTLTXCD, v_strLEV, v_strCMDALLOW As String

            'Data insert to TLAUTH
            Dim v_arrTLAUTH() As String
            v_arrTLAUTH = v_strTlauthString.Split("#")
            Dim v_arrTransString() As String
            Dim v_strCURRCOD, v_strTLTYPE, v_strLIMIT, v_strAuth, v_strMenuType As String
            Dim v_dblLIMIT As Double

            'Insert group' informations
            For i As Integer = 0 To v_arrCMDAUTH.Length - 2
                'Get TLTXCD and CMDALLOW
                v_arrMenuKey = v_arrCMDAUTH(i).Split("|")
                v_strTLTXCD = v_arrMenuKey(0)
                v_strLEV = v_arrMenuKey(1)
                v_strCMDALLOW = v_arrMenuKey(2)

                v_strAuth = v_arrMenuKey(2)
                v_strMenuType = v_arrMenuKey(3)
                If Len(Trim(v_strAuth)) = 1 Then
                    v_strCMDALLOW = v_strAuth
                    v_strAuth = String.Empty
                Else
                    v_strCMDALLOW = Mid(v_strAuth, 1, 1)
                    v_strAuth = Mid(v_strAuth, 2, 4)
                End If

                'Insert data to CMDAUTH table
                If Trim(v_strMenuType) = "M" Then
                    'Cap nhat thong tin NSD truoc khi xoa de ghi nhan log
                    v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE CMDCODE = '" & v_strTLTXCD & "' AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE CMDCODE = '" & v_strTLTXCD & "' AND AUTHID = '" & v_strGroupId & "' AND AUTHTYPE = 'G' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                    'Ghi nhan them de tim chuc nang xoa quyen
                    v_strOldValueFunc = v_strOldValueFunc & "|" & v_strTLTXCD
                End If
                If Trim(v_strCMDALLOW) = "Y" Then
                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', '" & v_strMenuType & "', '" & v_strTLTXCD & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                    'Ghi nhan de tim chuc nang/ GD xoa quyen
                    If v_strMenuType = "M" Then
                        v_strNewValueFunc = v_strNewValueFunc & "|" & v_strTLTXCD
                    Else
                        v_strNewValue = v_strNewValue & "|" & v_strTLTXCD
                    End If
                End If

                ''Insert data to CMDAUTH table

                'If CInt(v_strLEV) = 1 Then
                '    'Insert with right as functions
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'M', '" & v_strTLTXCD & "', '" & v_strCMDALLOW & "', '')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                '    'Insert with right as Trans
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'T', '" & v_strTLTXCD & "', '" & v_strCMDALLOW & "', '')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                'End If

            Next

            'Tim cac chuc nang bi xoa quyen
            If v_strOldValueFunc.Length > 0 Then
                Dim v_strFuncRemoved As String = String.Empty
                v_arrOldValueFunc = v_strOldValueFunc.Split("|")
                For k As Integer = 0 To v_arrOldValueFunc.Length - 1
                    If Not InStr(v_strNewValueFunc, v_arrOldValueFunc(k)) > 0 And v_arrOldValueFunc(k).Length > 0 Then
                        v_strFuncRemoved = v_strFuncRemoved & "|" & v_arrOldValueFunc(k)
                    End If
                Next
                v_strFuncRemoved = Mid(v_strFuncRemoved, 2)
                'Ghi nhan log cac chuc nang bi xoa quyen
                If v_strFuncRemoved.Length > 0 Then
                    Dim v_arrFuncRemoved() As String
                    v_arrFuncRemoved = v_strFuncRemoved.Split("|")
                    For m As Integer = 0 To v_arrFuncRemoved.Length - 1
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE,BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'YNNNNN','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

            'Tim cac GD bi xoa quyen
            If v_strOldValue.Length > 0 Then
                Dim v_strTransRemoved As String = String.Empty
                v_arrOldValue = v_strOldValue.Split("|")
                For k As Integer = 0 To v_arrOldValue.Length - 1
                    If Not InStr(v_strNewValue, v_arrOldValue(k)) > 0 And v_arrOldValue(k).Length > 0 Then
                        v_strTransRemoved = v_strTransRemoved & "|" & v_arrOldValue(k)
                    End If
                Next
                v_strTransRemoved = Mid(v_strTransRemoved, 2)
                'Ghi nhan log cac bao cao/ general view bi xoa quyen
                If v_strTransRemoved.Length > 0 Then
                    Dim v_arrTransRemoved() As String
                    v_arrTransRemoved = v_strTransRemoved.Split("|")
                    For m As Integer = 0 To v_arrTransRemoved.Length - 1
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_arrTransRemoved(m) & "','T',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrTransRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

            'Insert data to TLAUTH table
            'Insert group' informations
            For i As Integer = 0 To v_arrTLAUTH.Length - 2
                v_arrTransString = v_arrTLAUTH(i).Split("|")
                v_strTLTXCD = v_arrTransString(0)
                v_strCURRCOD = v_arrTransString(1)
                v_strTLTYPE = v_arrTransString(2)
                v_strLIMIT = v_arrTransString(3)
                If v_strLIMIT = "." Then
                    v_strLIMIT = "0.00"
                End If
                v_dblLIMIT = CDbl(v_strLIMIT)

                'Insert data to TLAUTH table
                v_strCmdInsertSQL = "INSERT INTO TLAUTH(AUTOID, AUTHTYPE, AUTHID, CODETYPE, CODEID, TLTXCD, TLTYPE, TLLIMIT, SAVETLID, LASTDATE) " _
                                    & "VALUES(SEQ_TLAUTH.NEXTVAL, 'G', '" & v_strGroupId & "', 'C', '" & v_strCURRCOD & "', '" & v_strTLTXCD & "', '" & v_strTLTYPE & "', '" & v_dblLIMIT & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                'Ghi nhan them de tim GD xoa han muc
                v_strNewTLValue = v_strNewTLValue & "|" & v_strTLTXCD & v_strTLTYPE
            Next

            'Tim cac GD bi xoa han muc
            If v_strOldTLValue.Length > 0 Then
                Dim v_strTransTLRemoved As String = String.Empty
                v_arrOldTLValue = v_strOldTLValue.Split("|")
                For k As Integer = 0 To v_arrOldTLValue.Length - 1
                    If Not InStr(v_strNewTLValue, v_arrOldTLValue(k)) > 0 And v_arrOldTLValue(k).Length > 0 Then
                        v_strTransTLRemoved = v_strTransTLRemoved & "|" & v_arrOldTLValue(k)
                    End If
                Next
                v_strTransTLRemoved = Mid(v_strTransTLRemoved, 2)
                'Ghi nhan log cac bao cao/ general view bi xoa quyen
                If v_strTransTLRemoved.Length > 0 Then
                    Dim v_arrTransTLRemoved() As String
                    Dim v_strTLTXCDRemove, v_strTLTYPERemove, v_strTLLIMITRemove As String

                    v_arrTransTLRemoved = v_strTransTLRemoved.Split("|")

                    For m As Integer = 0 To v_arrTransTLRemoved.Length - 1
                        v_strTLTXCDRemove = Mid(v_arrTransTLRemoved(m), 1, 4)
                        v_strTLTYPERemove = Mid(v_arrTransTLRemoved(m), 5)
                        v_strTLLIMITRemove = hOldTLValue(v_arrTransTLRemoved(m))
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'TLAUTH', '', '', 'G', '" & v_strGroupId & "','" & v_strTLTXCDRemove & "','T',''," & ControlChars.CrLf _
                            & "     '','" & v_strTLTYPERemove & "','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strTLLIMITRemove & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

            ''Insert users' informations
            'If v_arrUsersId.Length > 1 Then
            '    For i As Integer = 0 To v_arrUsersId.Length - 2
            '        'Check access right of user
            '        'If user has been in assignment list, do not assign again
            '        Dim v_strCountSQL As String
            '        v_strCountSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHID = '" & v_arrUsersId(i) & "' AND AUTHTYPE = 'T'"
            '        Dim v_dsCount As DataSet
            '        Dim v_objCount As New DataAccess(gc_MODULE_HOST)
            '        v_dsCount = v_objCount.ExecuteSQLReturnDataset(CommandType.Text, v_strCountSQL)
            '        If v_dsCount.Tables(0).Rows.Count = 1 Then
            '            If v_dsCount.Tables(0).Rows(0)(0) = 0 Then
            '                'Insert data to CMDAUTH table
            '                For j As Integer = 0 To v_arrCMDAUTH.Length - 2
            '                    'Get TLTXCD and CMDALLOW
            '                    v_arrMenuKey = v_arrCMDAUTH(j).Split("|")
            '                    v_strTLTXCD = v_arrMenuKey(0)
            '                    v_strCMDALLOW = v_arrMenuKey(2)
            '                    'Insert data to CMDAUTH table                
            '                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
            '                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_arrUsersId(i) & "', 'T', '" & v_strTLTXCD & "', '" & v_strCMDALLOW & "', '')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next

            '                'Insert data to TLAUTH table
            '                For j As Integer = 0 To v_arrTLAUTH.Length - 2
            '                    v_arrTransString = v_arrTLAUTH(j).Split("|")
            '                    v_strTLTXCD = v_arrTransString(0)
            '                    v_strCURRCOD = v_arrTransString(1)
            '                    v_strTLTYPE = v_arrTransString(2)
            '                    v_strLIMIT = v_arrTransString(3)
            '                    If v_strLIMIT = "." Then
            '                        v_strLIMIT = "0.00"
            '                    End If
            '                    v_dblLIMIT = CDbl(v_strLIMIT)

            '                    'Insert data to TLAUTH table
            '                    v_strCmdInsertSQL = "INSERT INTO TLAUTH(AUTOID, AUTHTYPE, AUTHID, CODETYPE, CODEID, TLTXCD, TLTYPE, TLLIMIT) " _
            '                                        & "VALUES(SEQ_TLAUTH.NEXTVAL, 'U', '" & v_arrUsersId(i) & "', 'C', '" & v_strCURRCOD & "', '" & v_strTLTXCD & "', '" & v_strTLTYPE & "', '" & v_dblLIMIT & "')"
            '                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            '                Next
            '            End If
            '        End If
            '    Next
            'End If

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
