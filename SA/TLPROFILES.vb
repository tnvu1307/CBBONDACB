Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class TLPROFILES
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TLPROFILES"
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
                Case "GetTellerId"
                    v_lngErrCode = GetTellerId(v_strObjMsg)
                Case "AddNewUser"
                    v_lngErrCode = AddNewUser(pv_xmlDocument)
                Case "EditUser"
                    v_lngErrCode = EditUser(pv_xmlDocument)
                Case "GetUserParentMenu"
                    v_lngErrCode = GetUserParentMenu(v_strObjMsg)
                Case "GetUserChildMenu"
                    v_lngErrCode = GetUserChildMenu(v_strObjMsg)
                Case "GetRptParentMenu"
                    v_lngErrCode = GetRptParentMenu(v_strObjMsg)
                Case "GetRptChildMenu"
                    v_lngErrCode = GetRptChildMenu(v_strObjMsg)
                Case "GetTransParentMenu"
                    v_lngErrCode = GetTransParentMenu(v_strObjMsg)
                Case "GetTransChildMenu"
                    v_lngErrCode = GetTransChildMenu(v_strObjMsg)

                Case "FunctionAssignment"
                    v_lngErrCode = FunctionAssignment(pv_xmlDocument)
                Case "ReportAssignment"
                    v_lngErrCode = ReportAssignment(pv_xmlDocument)
                Case "TransactionAssignment"
                    v_lngErrCode = TransactionAssignment(pv_xmlDocument)
                Case "GetChildMenu"
                    v_lngErrCode = GetChildMenu(v_strObjMsg)
                Case "GetChildAdjustMenu"
                    v_lngErrCode = GetChildAdjustMenu(v_strObjMsg)
                Case "GetParentMenu"
                    v_lngErrCode = GetParentMenu(v_strObjMsg)
                Case "GetParentAdjustMenu"
                    v_lngErrCode = GetParentAdjustMenu(v_strObjMsg)
                Case "GetGnrViewChildMenu"
                    v_lngErrCode = GetGnrViewChildMenu(v_strObjMsg)
            End Select
            pv_xmlDocument.LoadXml(v_strObjMsg)
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

                v_strErrorSource = "TLPROFILES.Delete"
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

                Dim v_arrClause(), v_strTlidDel As String
                v_arrClause = v_strClause.Split("=")
                v_strTlidDel = v_arrClause(1)
                v_strTlidDel = Replace(v_strTlidDel, "'", "").Trim

                'Delete all from CMDAUTH and TLAUTH
                Dim v_strDelSQL As String
                'Delete from CMDAUTH
                v_strDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strTlidDel & "' AND AUTHTYPE = 'U'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strDelSQL)
                'Delete from TLAUTH
                v_strDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strTlidDel & "' AND AUTHTYPE = 'U'"
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
            Dim v_strLocal, v_strTlId, v_strTlname As String
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
                        Case "TLID"
                            v_strTlId = Trim(v_strVALUE)
                        Case "TLNAME"
                            v_strTlname = Trim(v_strVALUE)
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

            'Kiểm tra TLID không được trùng
            v_strSQL = "SELECT COUNT(TLID) FROM " & ATTR_TABLE & " WHERE TLID = '" & v_strTlId & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLID_DUPLICATED
                End If
            End If
            'Kiểm tra TLNAME không được trùng
            v_strSQL = "SELECT COUNT(TLNAME) FROM " & ATTR_TABLE & " WHERE TLNAME = '" & v_strTlname & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLNAME_DUPLICATED
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTlId, v_strTlname, v_strBranchId, v_strUsrBrid As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If


            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "BRID"
                            v_strUsrBrid = Trim(v_strVALUE)
                        Case "TLNAME"
                            v_strTlname = Trim(v_strVALUE)
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

            'Do not allow edit if current teller is not in Head Office or 
            'the user that edited is not in current branch
            If v_strUsrBrid <> v_strBranchId Then
                If v_strBranchId <> HO_BRID Then
                    Return ERR_SA_NOT_RIGHT_MODIFY
                End If
            End If
            'Kiểm tra TLNAME không được trùng
            v_strSQL = "SELECT COUNT(TLNAME) FROM " & ATTR_TABLE & " WHERE TLNAME = '" & v_strTlname & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLNAME_DUPLICATED
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

        'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentTlid, v_strBranchId, v_strUsrBrid As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strLocal As String
            Dim v_strSQL As String
            Dim v_strAutoid As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strCurrentTlid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentTlid = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_objBr As DataAccess
            v_objBr = New DataAccess
            v_objBr.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = "SELECT BRID FROM TLPROFILES WHERE TLID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_objBr.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strUsrBrid = CStr(IIf(v_ds.Tables(0).Rows(0)("BRID") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("BRID"))).Trim
            End If

            'Do not allow delete if current teller is not in Head Office or 
            'the user that edited is not in current branch
            If v_strUsrBrid <> v_strBranchId Then
                If v_strBranchId <> HO_BRID Then
                    Return ERR_SA_NOT_RIGHT_MODIFY
                End If
            End If

            'Không cho phép xóa chính NSD đang sử dụng hệ thống
            Dim v_arrClause(), v_strTlidDel As String
            v_arrClause = v_strClause.Split("=")
            v_strTlidDel = v_arrClause(1)
            v_strTlidDel = Replace(v_strTlidDel, "'", "").Trim
            If v_strTlidDel = v_strCurrentTlid Then
                Return ERR_SA_TL_IN_SYS
            End If

            'Không cho phép xoá NSD đã có trong 1 nhóm cụ thể
            v_strSQL = "SELECT COUNT(TLID) FROM TLGRPUSERS WHERE TLID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TL_HAS_CHILD
                End If
            End If

            'Không cho phép xoá NSD đã có trong danh sách thực hiện GD trong ngày
            v_strSQL = "SELECT COUNT(TLID) FROM TLLOG WHERE TLID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TL_HAS_TLAUTH
                End If
            End If

            'Không cho phép xoá NSD đã có trong danh sách thực hiện GD
            v_strSQL = "SELECT COUNT(TLID) FROM TLLOGALL WHERE TLID " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TL_HAS_TLAUTH
                End If
            End If

            ''Không cho phép xoá NSD đã có trong DS phân quy?n
            'v_strSQL = "SELECT COUNT(AUTHID) FROM CMDAUTH WHERE AUTHTYPE = 'U' AND AUTHID " & Mid(v_strClause, InStr(v_strClause, "="))
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_TL_HAS_CMDAUTH
            '    End If
            'End If

            ''Kh�ông cho phép xoá NSD đã có trong DS thực hiện giao dịch
            'v_strSQL = "SELECT COUNT(AUTHID) FROM TLAUTH WHERE AUTHTYPE = 'U' AND AUTHID " & Mid(v_strClause, InStr(v_strClause, "="))
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_TL_HAS_TLAUTH
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
    ''-- + Mục đích: Lấy TellerId chưa sử dụng nh? nh�ất  --'' 
    ''-- + ?�ầu vào: pv_strObjMsg: Các thông số tìm kiếm --''
    ''-- + ?�ầu ra: TellerId                              --''
    ''-- + Tác giả: Nguyễn Nhân Thế                     --''
    ''-- + Ghi chú: N/A                                 --''
    ''----------------------------------------------------''
    Private Function GetTellerId(ByRef pv_strObjMsg As String) As Long
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
            v_strSQL = "SELECT MAX(ODR)+1 AUTOTLID FROM " _
                    & "(SELECT ROWNUM ODR, INVTLID " _
                    & " FROM (SELECT TLID INVTLID FROM TLPROFILES ORDER BY TLID) " _
                    & " WHERE TO_NUMBER(INVTLID)=ROWNUM) "

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


    Private Function AddNewUser(ByRef pv_xmlDocument As XmlDocumentEx) As Long
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

            Dim v_strHomeorder, v_strTlid, v_strBrid, v_strTlgroup, v_strTlname, v_strTlpassword, v_strFullname, v_strTltitle, v_strTltitle1, v_strTltitlenb, v_strTltitle1EN, v_strEmail, v_strTlprn, v_strTldescription, v_strTlType, v_strActive, v_strIdcode, v_strIsParCert As String
            Dim v_intTlLev As Integer
            Dim v_arrTlProfile() As String

            If v_strClause <> String.Empty Then
                v_arrTlProfile = v_strClause.Split("|")
                If v_arrTlProfile.Length = 19 Then
                    v_strTlid = v_arrTlProfile(0)
                    v_strBrid = v_arrTlProfile(1)
                    v_strTlgroup = v_arrTlProfile(2)
                    v_strTlname = v_arrTlProfile(3)
                    v_strFullname = v_arrTlProfile(4)
                    v_strTltitle = v_arrTlProfile(5)
                    v_strTlprn = v_arrTlProfile(6)
                    v_strTldescription = v_arrTlProfile(7)
                    v_strTlpassword = v_arrTlProfile(8)
                    v_strTlpassword = IIf(v_strTlpassword Is Nothing Or v_strTlpassword.Length < 1, v_strTlname, v_strTlpassword)
                    v_intTlLev = CInt(v_arrTlProfile(9))
                    v_strTlType = v_arrTlProfile(10)
                    v_strActive = v_arrTlProfile(11)
                    v_strIdcode = v_arrTlProfile(12)
                    v_strHomeorder = v_arrTlProfile(13)
                    v_strIsParCert = v_arrTlProfile(14)
                    v_strTltitle1 = v_arrTlProfile(15)
                    v_strEmail = v_arrTlProfile(16)
                    v_strTltitlenb = v_arrTlProfile(17)
                    v_strTltitle1EN = v_arrTlProfile(18)
                End If
            End If

            Dim v_ds As DataSet
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Check before add
            'Kiểm tra TLID không được trùng
            Dim v_strSQL As String
            v_strSQL = "SELECT COUNT(TLID) FROM TLPROFILES WHERE TLID = '" & v_strTlid & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLID_DUPLICATED
                End If
            End If
            'Kiểm tra TLNAME không được trùng
            v_strSQL = "SELECT COUNT(TLNAME) FROM TLPROFILES WHERE upper(TLNAME) = upper('" & v_strTlname & "') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLNAME_DUPLICATED
                End If
            End If

            'Add data to database
            ' DUCNV MA HOA PIN
            v_strSQL = "INSERT INTO TLPROFILES(TLID, TLNAME, TLFULLNAME, TLLEV, BRID, TLTITLE, TLPRN, TLGROUP, PIN, DESCRIPTION, TLTYPE,ACTIVE,IDCODE,HOMEORDER, ISPARCERT,TLTITLET,EMAIL,TLTITLENB,TLTITLETEN) " _
                       & "VALUES('" & v_strTlid & "', upper('" & v_strTlname & "'), '" & v_strFullname & "', '" & v_intTlLev & "', '" & v_strBrid & "', '" & v_strTltitle & "', '" & v_strTlprn & "', '" & v_strTlgroup & "', GENENCRYPTPASSWORD('" & v_strTlpassword & "'), '" & v_strTldescription & "', '" & v_strTlType & "', '" & v_strActive & "','" & v_strIdcode & "','" & v_strHomeorder & "','" & v_strIsParCert & "','" & v_strTltitle1 & "','" & v_strEmail & "' ,'" & v_strTltitlenb & "','" & v_strTltitle1EN & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '08/10/2015 DieuNDA luu log maintain
            Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")
            xmlMsg.SetAttribute(gc_AtributeCLAUSE, "TLID" + " = '" + v_strTlid + "'")
         
                Dim result As Long
                result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
                'End 08/10/2015 DieuNDA 

                Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function EditUser(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId, v_strBranchId As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If


            Dim v_strHomeorder, v_strTlid, v_strBrid, v_strTlgroup, v_strTlname, v_strTlpassword, v_strFullname, v_strTltitle, v_strTltitle1, v_strTltitlenb, v_strTltitle1EN, v_strEmail, v_strTlprn, v_strTldescription, v_strTlType, v_strActive, v_strIdcode, v_strIsParCert As String
            Dim v_strOldPIN As String = String.Empty
            Dim v_intTlLev As Integer
            Dim v_arrTlProfile() As String

            If v_strClause <> String.Empty Then
                v_arrTlProfile = v_strClause.Split("|")
                If v_arrTlProfile.Length = 19 Then
                    v_strTlid = v_arrTlProfile(0)
                    v_strBrid = v_arrTlProfile(1)
                    v_strTlgroup = v_arrTlProfile(2)
                    v_strTlname = v_arrTlProfile(3)
                    v_strFullname = v_arrTlProfile(4)
                    v_strTltitle = v_arrTlProfile(5)
                    v_strTlprn = v_arrTlProfile(6)
                    v_strTldescription = v_arrTlProfile(7)
                    v_strTlpassword = v_arrTlProfile(8)
                    v_intTlLev = CInt(v_arrTlProfile(9))
                    v_strTlType = v_arrTlProfile(10)
                    v_strActive = v_arrTlProfile(11)
                    v_strIdcode = v_arrTlProfile(12)
                    v_strHomeorder = v_arrTlProfile(13)
                    v_strIsParCert = v_arrTlProfile(14)
                    v_strTltitle1 = v_arrTlProfile(15)
                    v_strEmail = v_arrTlProfile(16)
                    v_strTltitlenb = v_arrTlProfile(17)
                    v_strTltitle1EN = v_arrTlProfile(18)
                End If
            End If

            Dim v_ds As DataSet
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strSQL As String
            'Check before Edit
            'Check to sure that the user to edit is not the current user
            If Trim(v_strTellerId) = Trim(v_strTlid) Then
                Return ERR_SA_TL_EDIT_CURRENT_USR
            End If
            'Do not allow edit if current teller is not in Head Office or 
            'the user that edited is not in current branch
            If v_strBrid <> v_strBranchId Then
                If v_strBranchId <> HO_BRID Then
                    Return ERR_SA_NOT_RIGHT_MODIFY
                End If
            End If
            'Kiểm tra TLNAME không được trùng
            v_strSQL = "SELECT COUNT(TLNAME) FROM TLPROFILES WHERE UPPER(TLNAME) = UPPER('" & v_strTlname & "') AND TLID <> '" & v_strTlid & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_TLNAME_DUPLICATED
                End If
            End If

            'Get old PIN
            v_strSQL = "SELECT PIN FROM TLPROFILES WHERE TLID = '" & v_strTlid & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strOldPIN = v_ds.Tables(0).Rows(0)("PIN")
            End If

            'Update data to database
            v_strSQL = "UPDATE TLPROFILES SET TLNAME = '" & v_strTlname & "', TLFULLNAME = '" & v_strFullname & "', TLLEV = '" & v_intTlLev & "', BRID = '" & v_strBrid & "', TLTITLE = '" & v_strTltitle & "',TLTITLET = '" & v_strTltitle1 & "',EMAIL = '" & v_strEmail & "',TLTITLENB = '" & v_strTltitlenb & "',TLTITLETEN = '" & v_strTltitle1EN & "', " _
                                           & "TLPRN = '" & v_strTlprn & "', TLGROUP = '" & v_strTlgroup & "', DESCRIPTION = '" & v_strTldescription & "', TLTYPE = '" _
                                           & v_strTlType & "', ACTIVE = '" & v_strActive & "', IDCODE='" & v_strIdcode & "'" & ", ISPARCERT='" & v_strIsParCert & "' ,HOMEORDER= '" & v_strHomeorder & "' WHERE TLID = '" & v_strTlid & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Update PIN if Old PIN <> new PIN
            If v_strOldPIN <> v_strTlpassword Then
                v_strSQL = "UPDATE TLPROFILES SET PIN = GENENCRYPTPASSWORD('" & v_strTlpassword & "') WHERE TLID = '" & v_strTlid & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'Update limit of right of user
            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            If v_strTlType <> String.Empty Then
                v_strTeller = Mid(v_strTlType, 1, 1)
                v_strCashier = Mid(v_strTlType, 2, 1)
                v_strOfficer = Mid(v_strTlType, 3, 1)
                v_strChecker = Mid(v_strTlType, 4, 1)

                'Delete limit of right
                If v_strTeller = "N" Then
                    v_strSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strTlid & "' AND AUTHTYPE = 'U' AND TLTYPE = 'T'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                If v_strCashier = "N" Then
                    v_strSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strTlid & "' AND AUTHTYPE = 'U' AND TLTYPE = 'C'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                If v_strOfficer = "N" Then
                    v_strSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strTlid & "' AND AUTHTYPE = 'U' AND TLTYPE = 'A'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                If v_strChecker = "N" Then
                    v_strSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strTlid & "' AND AUTHTYPE = 'U' AND TLTYPE = 'R'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If

            '08/10/2015 DieuNDA luu log maintain
            Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")
            xmlMsg.SetAttribute(gc_AtributeCLAUSE, "TLID" + " = '" + v_strTlid + "'")
            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionEdit)
            'End 08/10/2015 DieuNDA 

            Return ERR_SYSTEM_OK
        Catch ex As Exception
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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                    & "from CMDMENU M " _
                    & "where M.LEV = 1 " _
                    & "order by M.CMDID"
            'Else
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                & "from CMDMENU M, CMDAUTH A " _
            '                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '                & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
            '                & "order by M.CMDID"
            'End If


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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') CMDNAME, M.EN_CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') EN_CMDNAME, M.LEV LEV, M.LAST LAST, " _
                    & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                    & "M.AUTHCODE AUTHCODE, 'YYYY' STRAUTH " _
                    & "from CMDMENU M " _
                    & "where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                    & "order by M.CMDID"
            'Else
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') CMDNAME, M.EN_CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') EN_CMDNAME, M.LEV LEV, M.LAST LAST, decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, M.AUTHCODE AUTHCODE " _
            '        & "from CMDMENU M, CMDAUTH A " _
            '        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '        & "and A.AUTHID = '" & v_strTellerId & "' and A.CMDTYPE = 'M' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
            '        & "order by M.CMDID"
            'End If

            '& "and (M.MENUTYPE = 'A' OR M.MENUTYPE = 'M' OR M.MENUTYPE = 'P') " _


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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
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


            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 1 LEV, A.CMDALLOW CMDALLOW " _
            '    & "FROM APPMODULES M, CMDAUTH A " _
            '    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & v_strTellerId & "' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, 0 IMGINDEX, C.CMDID CMDID, C.LEV, 'Y' CMDALLOW, 'YYYY' STRAUTH " _
                    & "FROM APPMODULES N, CMDMENU C " _
                    & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R' ORDER BY C.CMDID "
            'Else
            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, N.MODNAME MODNAME, C.CMDID CMDID, C.LEV " _
            '                & "FROM APPMODULES N, CMDMENU C " _
            '                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R') M, CMDAUTH A " _
            '        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & v_strTellerId & "' AND A.CMDTYPE = 'M' AND A.CMDALLOW = 'Y' " _
            '        & "ORDER BY M.CMDID "
            'End If

            'v_strSQL = "SELECT M.TXCODE TXCODE, M.MODCODE MODCODE, M.MODNAME MODNAME, 0 IMGINDEX, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    & "FROM APPMODULES M, CMDAUTH A " _
            '    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & v_strTellerId & "' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT M.RPTID RPTID, M.MODCODE MODCODE, M.RPTID ||': '|| M.DESCRIPTION RPTNAME,M.CMDTYPE CMDTYPE, 'Y' CMDALLOW, 'YYYY' STRAUTH, 3 IMGINDEX, 2 LEV " _
                    & "FROM RPTMASTER M " _
                    & "WHERE M.MODCODE = '" & v_strParentKey & "' AND M.VISIBLE = 'Y' AND M.CMDTYPE = 'R' " _
                    & "ORDER BY M.RPTID"
            'Else
            'v_strSQL = "SELECT M.RPTID RPTID, M.MODCODE MODCODE, M.DESCRIPTION RPTNAME,M.CMDTYPE CMDTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 3 IMGINDEX, 2 LEV " _
            '        & "FROM RPTMASTER M, CMDAUTH A " _
            '        & "WHERE M.MODCODE = '" & v_strParentKey & "' AND M.RPTID = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' AND M.VISIBLE = 'Y' " _
            '        & "ORDER BY M.RPTID"
            'End If


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
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            'If v_strTellerId = ADMIN_ID Then
            'v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 2 LEV " _
            '        & "FROM TLTX M " _
            '        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strParentKey & "' ORDER BY M.TLTXCD"
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.TLTXCD TLTXCD,M.TLTXCD ||': '|| M.TXDESC TXDESC ,M.TLTXCD ||': '|| M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 2 LEV " & ControlChars.CrLf _
                        & "FROM TLTX M, APPMODULES A " & ControlChars.CrLf _
                        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strParentKey & "' AND M.VISIBLE = 'Y' " & ControlChars.CrLf _
                        & "ORDER BY M.TLTXCD"
            Else

                v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TLTXCD ||': '|| M.TXDESC TXDESC, M.TLTXCD ||': '|| M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 2 LEV " & ControlChars.CrLf _
                        & "FROM TLTX M, APPMODULES A " & ControlChars.CrLf _
                        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strParentKey & "' AND M.VISIBLE = 'Y' " & ControlChars.CrLf _
                        & "     AND NOT EXISTS ( " & ControlChars.CrLf _
                        & "         SELECT SR.searchcode, SR.tltxcd" & ControlChars.CrLf _
                        & "         FROM SEARCH SR, RPTMASTER RPT, TLTX TL " & ControlChars.CrLf _
                        & "         WHERE SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND SR.tltxcd IS NOT NULL AND SR.TLTXCD = TL.TLTXCD AND TL.DIRECT = 'N' " & ControlChars.CrLf _
                        & "             AND NOT EXISTS(SELECT TLTXCD FROM CMDMENU CM WHERE CM.tltxcd IS NOT NULL AND INSTR(CM.tltxcd, TL.tltxcd) > 0)" & ControlChars.CrLf _
                        & "             AND M.tltxcd = SR.tltxcd)" & ControlChars.CrLf _
                        & "     AND (M.DIRECT = 'Y' OR EXISTS(SELECT TLTXCD FROM CMDMENU CM WHERE CM.tltxcd IS NOT NULL AND INSTR(CM.tltxcd, M.tltxcd) > 0)) " & ControlChars.CrLf _
                        & "ORDER BY M.TLTXCD"
                'Else
                'v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TLTXCD ||': '|| M.TXDESC TXDESC, M.TLTXCD ||': '|| M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 2 LEV " & ControlChars.CrLf _
                '        & "FROM TLTX M, APPMODULES A, CMDAUTH C " & ControlChars.CrLf _
                '        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strParentKey & "' AND M.VISIBLE = 'Y' " & ControlChars.CrLf _
                '        & "     AND NOT EXISTS ( " & ControlChars.CrLf _
                '        & "         SELECT SR.searchcode, SR.tltxcd" & ControlChars.CrLf _
                '        & "         FROM SEARCH SR, RPTMASTER RPT, TLTX TL " & ControlChars.CrLf _
                '        & "         WHERE SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND SR.tltxcd IS NOT NULL AND SR.TLTXCD = TL.TLTXCD AND TL.DIRECT = 'N' AND M.tltxcd = SR.tltxcd)" & ControlChars.CrLf _
                '        & "     AND M.TLTXCD = C.CMDCODE AND C.AUTHID = '" & v_strTellerId & "' AND C.AUTHTYPE = 'U' AND C.CMDTYPE = 'T' AND C.CMDALLOW = 'Y' " & ControlChars.CrLf _
                '        & "     AND (M.DIRECT = 'Y' OR EXISTS(SELECT TLTXCD FROM CMDMENU CM WHERE CM.tltxcd IS NOT NULL AND INSTR(CM.tltxcd, M.tltxcd) > 0)) " & ControlChars.CrLf _
                '        & "ORDER BY M.TLTXCD"

                ''v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.TXTYPE TXTYPE, A.CMDALLOW CMDALLOW, 3 IMGINDEX, 2 LEV " _
                ''        & "FROM TLTX M, CMDAUTH A " _
                ''        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strParentKey & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                ''        & "ORDER BY M.TLTXCD "
                'End If
            End If

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

            'Get strAuth of each node
            Dim v_arrClause(), v_arrStrAuth(), v_strUserId As String
            v_arrClause = v_strClause.Split("$")
            v_strUserId = v_arrClause(0)
            v_arrStrAuth = v_arrClause(1).Split("#")

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
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
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
            v_strSQL = "SELECT CMDCODE, CMDALLOW || STRAUTH STRAUTH FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M' ORDER BY CMDCODE"
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
            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Insert data to CMDAUTH table
            For i As Integer = 0 To v_arrStrAuth.Length - 2
                Dim v_strCmdInsertSQL As String
                Dim v_strCMDCODE, v_strCMDALLOW, v_strAuth, v_arrMenuKey() As String
                v_arrMenuKey = v_arrStrAuth(i).Split("|")
                v_strCMDCODE = v_arrMenuKey(0)
                v_strAuth = v_arrMenuKey(2)
                v_strCMDALLOW = Mid(v_strAuth, 1, 1)                
                'AnhVT changed
                'v_strAuth = Mid(v_strAuth, 2, 4)
                v_strAuth = Mid(v_strAuth, 2, 5)

                If Trim(v_strCMDALLOW) = "Y" Then
                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                    & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
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
            'Ghi nhan log cac chuc nang bi xoa quyen
            If v_strFuncRemoved.Length > 0 Then
                Dim v_arrFuncRemoved() As String
                v_arrFuncRemoved = v_strFuncRemoved.Split("|")
                For m As Integer = 0 To v_arrFuncRemoved.Length - 1
                    v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                        & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                        & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'U', '" & v_strUserId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
                        & " '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrFuncRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If

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

            'Get strAuth of each node
            Dim v_arrClause(), v_arrStrAuth(), v_strUserId As String
            v_arrClause = v_strClause.Split("$")
            v_strUserId = v_arrClause(0)
            v_arrStrAuth = v_arrClause(1).Split("#")

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
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE IN ('R','G')"
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
            v_strSQL = "SELECT CMDCODE, CMDTYPE, CMDALLOW || STRAUTH STRAUTH FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE IN ('R','G') ORDER BY CMDCODE"
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
            'Delete assigned data of RptParents
            'v_strCmdDelSQL = "DELETE FROM CMDAUTH " _
            '                & "WHERE CMDCODE IN (SELECT CMDID CMDCODE " _
            '                                    & "FROM CMDMENU WHERE TRIM(MENUTYPE) = 'R') " _
            '                                    & "AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M' "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Delete assigned data of Rpt
            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE IN ('R','G')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Insert data to CMDAUTH table
            Dim v_strCmdInsertSQL As String
            Dim v_strCMDCODE, v_strCMDALLOW, v_strLEV, v_strAuth, v_strMenuType, v_arrMenuKey() As String
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
                    v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE CMDCODE = '" & v_strCMDCODE & "' AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE CMDCODE = '" & v_strCMDCODE & "' AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                    'Ghi nhan them de tim chuc nang/ bao cao xoa quyen
                    v_strOldValueFunc = v_strOldValueFunc & "|" & v_strCMDCODE
                    'Insert to database
                    If Trim(v_strCMDALLOW) = "Y" Then
                        v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', '" & v_strMenuType & "', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                        'Ghi nhan de tim chuc nang/ bao cao xoa quyen
                        v_strNewValueFunc = v_strNewValueFunc & "|" & v_strCMDCODE
                    End If
                Else
                    'Insert to database
                    If Trim(v_strCMDALLOW) = "Y" And CInt(v_strLEV) = 4 Then
                        v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                        & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', '" & v_strMenuType & "', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                        'Ghi nhan de tim chuc nang/ bao cao xoa quyen
                        v_strNewValue = v_strNewValue & "|" & v_strCMDCODE & "#" & v_strMenuType
                    End If
                End If
                

                ''If CMDCODE is parents of Rpts
                'If CInt(v_strLEV) = 1 Then
                '    'Insert with right as functions
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                                & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', 'M', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                '    'Insert with right as Reports
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                                & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                'Else
                '    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH) " _
                '                                & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', 'R', '" & v_strCMDCODE & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "')"
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
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'U', '" & v_strUserId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
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
                'Ghi nhan log cac bao cao/ general view bi xoa quyen
                If v_strReportRemoved.Length > 0 Then
                    Dim v_arrReportRemoved() As String
                    Dim v_strCMDTYPE, v_strCMDCODERemoved As String
                    v_arrReportRemoved = v_strReportRemoved.Split("|")
                    For m As Integer = 0 To v_arrReportRemoved.Length - 1
                        v_strCMDCODERemoved = Mid(v_arrReportRemoved(m), 1, InStr(v_arrReportRemoved(m), "#") - 1)
                        v_strCMDTYPE = Mid(v_arrReportRemoved(m), InStr(v_arrReportRemoved(m), "#") + 1)
                        v_strSQL = "INSERT INTO rightassign_log(autoid,logtable,brid,grpid,authtype,AUTHID,cmdcode,cmdtype,cmdallow," & ControlChars.CrLf _
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'U', '" & v_strUserId & "','" & v_strCMDCODERemoved & "','" & v_strCMDTYPE & "',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrReportRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

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
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SA.TLPROFILES.TransactionAssignment", v_strErrorMessage As String
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

            'Get CMDAUTH's string and TLAUTH's string
            Dim v_arrStrAuth(), v_strCmdauthString, v_strTlauthString, v_strUserId As String
            If v_strClause <> String.Empty Then
                v_arrStrAuth = v_strClause.Split("$")
                v_strUserId = v_arrStrAuth(0)
                v_strCmdauthString = v_arrStrAuth(1)
                v_strTlauthString = v_arrStrAuth(2)
            End If

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
            v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'TLAUTH
            v_strSQL = "UPDATE TLAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U'"
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

            v_strSQL = "SELECT CMDCODE, CMDTYPE, CMDALLOW || STRAUTH STRAUTH FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T' ORDER BY CMDCODE"
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
            v_strSQL = "SELECT TLTXCD, TLTYPE, TLLIMIT FROM TLAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' ORDER BY TLTXCD, TLTYPE"
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
            'Delete data from CMDAUTH table
            'Delete assigned data of TransParents
            'v_strCmdDelSQL = "DELETE FROM CMDAUTH " _
            '                & "WHERE CMDCODE IN (SELECT CMDID CMDCODE " _
            '                                    & "FROM CMDMENU WHERE TRIM(MENUTYPE) = 'T') " _
            '                                    & "AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M' "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Delete assigned data of Trans
            'If v_strTellerId = ADMIN_ID Then
            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'End If

            'Delete data from TLAUTH table]
            'If v_strTellerId = ADMIN_ID Then
            v_strCmdDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'End If


            'Insert database to CMDAUTH table
            Dim v_arrCMDAUTH() As String
            v_arrCMDAUTH = v_strCmdauthString.Split("#")
            For i As Integer = 0 To v_arrCMDAUTH.Length - 2
                Dim v_strCmdInsertSQL As String
                Dim v_arrMenuKey() As String
                Dim v_strTLTXCD, v_strCMDALLOW, v_strLEV, v_strMenuType, v_strAuth As String

                'Get TLTXCD and CMDALLOW
                v_arrMenuKey = v_arrCMDAUTH(i).Split("|")
                v_strTLTXCD = v_arrMenuKey(0)
                v_strLEV = CStr(v_arrMenuKey(1)).Trim
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
                    v_strSQL = "UPDATE CMDAUTH SET SAVETLID = '" & v_strTellerId & "' WHERE CMDCODE = '" & v_strTLTXCD & "' AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE CMDCODE = '" & v_strTLTXCD & "' AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'M'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                    'Ghi nhan them de tim chuc nang xoa quyen
                    v_strOldValueFunc = v_strOldValueFunc & "|" & v_strTLTXCD
                End If
                'If v_strTellerId <> ADMIN_ID Then
                '    v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE CMDCODE = '" & v_strTLTXCD & "' AND AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND CMDTYPE = 'T'"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                'End If

                If Trim(v_strCMDALLOW) = "Y" Then
                    v_strCmdInsertSQL = "INSERT INTO CMDAUTH(AUTOID, AUTHTYPE, AUTHID, CMDTYPE, CMDCODE, CMDALLOW, STRAUTH, SAVETLID, LASTDATE) " _
                                    & "VALUES(SEQ_CMDAUTH.NEXTVAL, 'U', '" & v_strUserId & "', '" & v_strMenuType & "', '" & v_strTLTXCD & "', '" & v_strCMDALLOW & "', '" & v_strAuth & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                    'Ghi nhan de tim chuc nang/ GD xoa quyen
                    If v_strMenuType = "M" Then
                        v_strNewValueFunc = v_strNewValueFunc & "|" & v_strTLTXCD
                    Else
                        v_strNewValue = v_strNewValue & "|" & v_strTLTXCD
                    End If
                End If

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
                            & "     strauth,tltype,tllimit,chgtlid,chgtime, OLDVALUE, NEWVALUE, BUSDATE) " & ControlChars.CrLf _
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'U', '" & v_strUserId & "','" & v_arrFuncRemoved(m) & "','M',''," & ControlChars.CrLf _
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
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'CMDAUTH', '', '', 'U', '" & v_strUserId & "','" & v_arrTransRemoved(m) & "','T',''," & ControlChars.CrLf _
                            & "     '','','','" & v_strTellerId & "',SYSTIMESTAMP,'" & hOldValue(v_arrTransRemoved(m)) & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If


            'Insert data to TLAUTH table
            Dim v_arrTLAUTH() As String
            v_arrTLAUTH = v_strTlauthString.Split("#")
            For i As Integer = 0 To v_arrTLAUTH.Length - 2
                Dim v_strCmdInsertSQL As String
                Dim v_arrTransString() As String
                Dim v_strTLTXCD, v_strCURRCOD, v_strTLTYPE, v_strLIMIT As String
                Dim v_dblLIMIT As Double

                v_arrTransString = v_arrTLAUTH(i).Split("|")
                v_strTLTXCD = v_arrTransString(0)
                v_strCURRCOD = v_arrTransString(1)
                v_strTLTYPE = v_arrTransString(2)
                v_strLIMIT = v_arrTransString(3)
                If v_strLIMIT = "." Then
                    v_strLIMIT = "0.00"
                End If
                Dim v_strTransLimit As String
                v_strTransLimit = v_strLIMIT
                'Check limit
                If v_strTellerId <> ADMIN_ID Then
                    ''Dim v_strSQL As String = "SELECT * FROM TLAUTH WHERE AUTHID = '" & v_strTellerId & "' AND AUTHTYPE = 'U' AND TLLIMIT >=" & v_strTransLimit
                    ''Dim ds As DataSet = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    ''If ds.Tables(0).Rows.Count < 1 Then
                    ''    v_lngErrCode = ERR_SA_TRANSACT_TRANSOVRLIMIT
                    ''    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    ''                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    ''                 & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
                    ''    Return v_lngErrCode
                    ''End If
                    ''Get LIMIT of user
                    'Dim v_strTltxSQL As String
                    'v_strTltxSQL = "SELECT A.TLLIMIT TLLIMIT " _
                    '                & "FROM TLTX M, TLAUTH A " _
                    '                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strTellerId & "' AND A.TLTYPE = 'R' AND A.AUTHTYPE = 'U'"
                    'Dim v_dsTltx As DataSet
                    'Dim v_strUsrLIMIT As String
                    'v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                    'If v_dsTltx.Tables(0).Rows.Count > 0 Then
                    '    v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                    'End If

                    ''Get the groups that user is in
                    'Dim v_strGrpSQL As String
                    'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
                    'Dim v_dsGrp As DataSet
                    'v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                    'Dim v_dblGrpLIMIT As Double = 0
                    'If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    '    Dim v_intNumGrp As Integer
                    '    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    '    Dim v_strGrpId As String
                    '    'Get Largest Limit of groups
                    '    For j As Integer = 0 To v_intNumGrp - 1
                    '        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(j)("GRPID")).Trim
                    '        'Get Limit of each group.
                    '        Dim v_strSQL As String = "SELECT A.TLLIMIT TLLIMIT " _
                    '                & "FROM TLTX M, TLAUTH A " _
                    '                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE = 'R' AND A.AUTHTYPE = 'G'"

                    '        Dim v_dsGrpRight As DataSet
                    '        v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    '        'Get Limit of group
                    '        Dim v_strLIMIT1 As String
                    '        If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                    '            v_strLIMIT1 = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                    '            If (v_strLIMIT1 <> String.Empty) And (IsNumeric(v_strLIMIT1)) Then
                    '                If CDbl(v_strLIMIT1) > v_dblGrpLIMIT Then
                    '                    v_dblGrpLIMIT = CDbl(v_strLIMIT1)
                    '                End If
                    '            End If
                    '        End If
                    '    Next
                    'End If
                    ''Compare value of transaction with limit
                    'If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                    '    If (v_strUsrLIMIT <> String.Empty) And (IsNumeric(v_strUsrLIMIT)) Then
                    '        If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) Then
                    '            v_lngErrCode = ERR_SA_TRANSACT_TRANSOVRLIMIT
                    '            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                         & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
                    '            Return v_lngErrCode
                    '        End If
                    '    ElseIf v_dblGrpLIMIT > 0 Then
                    '        'If this user hasn't got his own right with this transaction
                    '        If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                    '            v_lngErrCode = ERR_SA_TRANSACT_TRANSOVRLIMIT
                    '            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                         & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
                    '            Return v_lngErrCode
                    '        End If
                    '    ElseIf (CDbl(v_strUsrLIMIT) = 0) And (v_dblGrpLIMIT = 0) Then
                    '        v_lngErrCode = ERR_SA_TRANSACT_TRANSOVRLIMIT
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
                    '        Return v_lngErrCode
                    '    End If
                    'Else

                    'End If
                    'Delete data from TLAUTH table]
                    v_strCmdDelSQL = "DELETE FROM TLAUTH WHERE AUTHID = '" & v_strUserId & "' AND AUTHTYPE = 'U' AND TLTXCD = '" & v_strTLTXCD & "' AND TLTYPE = '" & v_strTLTYPE & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
                End If

                'Insert data to TLAUTH table

                v_strCmdInsertSQL = "INSERT INTO TLAUTH(AUTOID, AUTHTYPE, AUTHID, CODETYPE, CODEID, TLTXCD, TLTYPE, TLLIMIT, SAVETLID, LASTDATE) " _
                                    & "VALUES(SEQ_TLAUTH.NEXTVAL, 'U', '" & v_strUserId & "', 'C', '" & v_strCURRCOD & "', '" & v_strTLTXCD & "', '" & v_strTLTYPE & "', '" & v_strTransLimit & "', '" & v_strTellerId & "',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
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
                            & "VALUES (seq_rightassign_log.NEXTVAL, 'TLAUTH', '', '', 'U', '" & v_strUserId & "','" & v_strTLTXCDRemove & "','T',''," & ControlChars.CrLf _
                            & "     '','" & v_strTLTYPERemove & "','','" & v_strTellerId & "',SYSTIMESTAMP,'" & v_strTLLIMITRemove & "','D',TO_DATE('" & v_strCurrDate & "','DD/MM/YYYY'))"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If


            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GetParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                    & "from CMDMENU M " _
                    & "where M.LEV = 1 " _
                    & "order by M.CMDID"
            'Else
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '        & "from CMDMENU M, CMDAUTH A " _
            '        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            '        & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
            '        & "order by M.CMDID"
            'End If


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


    Private Function GetParentAdjustMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
            'v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, case when last = 'Y' then 3 else 0 end IMGINDEX " _
            '        & "from ADJUSTMENU M " _
            '        & "where M.LEV = 1 " _
            '        & "order by M.CMDID"
            v_strSQL = "Select AM.CMDID CMDID, AM.PRID PRID,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description  " & ControlChars.CrLf _
                        & "            else AM.CMDNAME end CMDNAME,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME  " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description " & ControlChars.CrLf _
                        & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,   " & ControlChars.CrLf _
                        & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX, " & ControlChars.CrLf _
                        & "            AM.MENUTYPE,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then T.TLTXCD " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then R.RPTID " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then G.gvid " & ControlChars.CrLf _
                        & "            else AM.CMDNAME end REFID,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.LEV " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then 4 " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then 4 " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then 4 " & ControlChars.CrLf _
                        & "            else M.LEV end REFLEV,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.MENUTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then T.TXTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then R.CMDTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then 'E' " & ControlChars.CrLf _
                        & "            else M.MENUTYPE end REFMENUTYPE,  " & ControlChars.CrLf _
                        & "            M.cmdid REFCMDID,  " & ControlChars.CrLf _
                        & "            nvl(M.AUTHCODE,'YYYYYYYYYYN') AUTHCODE " & ControlChars.CrLf _
                        & "     from ADJUSTMENU AM, CMDMENU M, (select appmodules.modcode, tltx.* from appmodules, tltx where appmodules.txcode = substr(tltx.tltxcd,1,2)) T,  " & ControlChars.CrLf _
                        & "            (select * from RPTMASTER where cmdtype = 'R' and visible = 'Y') R,  " & ControlChars.CrLf _
                        & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*  " & ControlChars.CrLf _
                        & "                from RPTMASTER G, search s  " & ControlChars.CrLf _
                        & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y') G " & ControlChars.CrLf _
                        & "     where AM.LEV = 1 " & ControlChars.CrLf _
                        & "        and AM.menucode = M.cmdid(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = g.gvid(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                        & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                        & "            ) " & ControlChars.CrLf _
                        & "order by AM.cmdid "

            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "minhtk"
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

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
    Private Function GetChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT M.CMDID, M.PRID, DECODE(M.LAST,'Y',M.CMDID || ': ','') || M.CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') CMDNAME, DECODE(M.LAST,'Y',M.CMDID || ': ','') || M.EN_CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') EN_CMDNAME, M.LEV, DECODE(M.MENUTYPE,'R','N','G','N',M.LAST) LAST,  " & ControlChars.CrLf _
                    & "     CASE WHEN M.MENUTYPE IN ('R','G') OR M.LAST = 'N' THEN 0 ELSE 3 END IMGINDEX, M.MODCODE, M.OBJNAME,  " & ControlChars.CrLf _
                    & "     M.MENUTYPE, M.AUTHCODE, M.STRAUTH " & ControlChars.CrLf _
                    & " FROM " & ControlChars.CrLf _
                    & "     (Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, M.LAST LAST, " & ControlChars.CrLf _
                    & "         decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, " & ControlChars.CrLf _
                    & "         CASE WHEN instr(m.objname, 'GENERALVIEW') > 0 THEN 'G' ELSE M.MENUTYPE END MENUTYPE," & ControlChars.CrLf _
                    & "         M.AUTHCODE AUTHCODE, 'YYYY' STRAUTH, M.TLTXCD " & ControlChars.CrLf _
                    & "     from CMDMENU M " & ControlChars.CrLf _
                    & "     where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' ) M " & ControlChars.CrLf _
                    & "order by M.CMDID"
            'Else
            'v_strSQL = "SELECT M.CMDID, M.PRID, DECODE(M.LAST,'Y',M.CMDID || ': ','') || M.CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') CMDNAME, DECODE(M.LAST,'Y',M.CMDID || ': ','') || M.EN_CMDNAME || decode(m.tltxcd,'','',' (GD: '|| m.tltxcd || ')') EN_CMDNAME, M.LEV, DECODE(M.MENUTYPE,'R','N','G','N',M.LAST) LAST,  " & ControlChars.CrLf _
            '        & "     CASE WHEN M.MENUTYPE IN ('R','G') OR M.LAST = 'N' THEN 0 ELSE 3 END IMGINDEX, M.MODCODE, M.OBJNAME,  " & ControlChars.CrLf _
            '        & "     M.MENUTYPE, M.AUTHCODE, M.STRAUTH " & ControlChars.CrLf _
            '        & " FROM " & ControlChars.CrLf _
            '        & "     (Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, M.LAST LAST, " & ControlChars.CrLf _
            '        & "         decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, " & ControlChars.CrLf _
            '        & "         CASE WHEN instr(m.objname, 'GENERALVIEW') > 0 THEN 'G' ELSE M.MENUTYPE END MENUTYPE," & ControlChars.CrLf _
            '        & "         M.AUTHCODE AUTHCODE, 'YYYY' STRAUTH, M.TLTXCD " & ControlChars.CrLf _
            '        & "     from CMDMENU M " & ControlChars.CrLf _
            '        & "     where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' ) M, CMDAUTH A " & ControlChars.CrLf _
            '        & " where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " & ControlChars.CrLf _
            '        & "     and A.AUTHID = '" & v_strTellerId & "' and A.CMDTYPE = 'M'" & ControlChars.CrLf _
            '        & "order by M.CMDID"

            ''v_strSQL = "Select M.CMDID CMDID, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LEV LEV, M.LAST LAST, decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            ''        & "from CMDMENU M, CMDAUTH A " _
            ''        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            ''        & "and A.AUTHID = '" & v_strTellerId & "' and A.CMDTYPE = 'M' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
            ''        & "order by M.CMDID"
            'End If

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

    Private Function GetChildAdjustMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            v_strSQL = "Select AM.CMDID CMDID, AM.PRID PRID,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description  " & ControlChars.CrLf _
                        & "            else AM.CMDNAME end CMDNAME,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME  " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description " & ControlChars.CrLf _
                        & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,   " & ControlChars.CrLf _
                        & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX, " & ControlChars.CrLf _
                        & "            AM.MENUTYPE,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.cmdid " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then T.TLTXCD " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then R.RPTID " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then G.gvid " & ControlChars.CrLf _
                        & "            else M.cmdid end REFID,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.LEV " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then 4 " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then 4 " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then 4 " & ControlChars.CrLf _
                        & "            else M.LEV end REFLEV,  " & ControlChars.CrLf _
                        & "            case when AM.menutype = 'M' then M.MENUTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'T' then T.TXTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'R' then R.CMDTYPE " & ControlChars.CrLf _
                        & "                when AM.menutype = 'G' then 'E' " & ControlChars.CrLf _
                        & "            else M.MENUTYPE end REFMENUTYPE,  " & ControlChars.CrLf _
                        & "            M.cmdid REFCMDID,  " & ControlChars.CrLf _
                        & "            nvl(M.AUTHCODE,'YYYYYYYYYYN') AUTHCODE " & ControlChars.CrLf _
                        & "     from ADJUSTMENU AM, CMDMENU M, (select appmodules.modcode, tltx.* from appmodules, tltx where appmodules.txcode = substr(tltx.tltxcd,1,2)) T,  " & ControlChars.CrLf _
                        & "            (select * from RPTMASTER where cmdtype = 'R' and visible = 'Y') R,  " & ControlChars.CrLf _
                        & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*  " & ControlChars.CrLf _
                        & "                from RPTMASTER G, search s  " & ControlChars.CrLf _
                        & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y') G " & ControlChars.CrLf _
                        & "     where AM.LEV > 1 and AM.PRID = '" & v_strParentKey & "'  " & ControlChars.CrLf _
                        & "        and AM.menucode = M.cmdid(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = g.gvid(+)  " & ControlChars.CrLf _
                        & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                        & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                        & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                        & "            ) " & ControlChars.CrLf _
                        & "order by AM.cmdid "

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = v_strSQL

            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)
            v_dal.LogCommand = True

            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GetGnrViewChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strSQL, v_arr(), v_strParentKey As String

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_arr = v_strClause.Split("|")
            v_strParentKey = CStr(v_arr(0)).Trim

            'If v_strTellerId = ADMIN_ID Then
            v_strSQL = "SELECT RPT.RPTID || '^' || CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END TLTXCD," & ControlChars.CrLf _
                    & "     RPT.RPTID ||'-'|| CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END ||': '|| RPT.DESCRIPTION TXDESC, " & ControlChars.CrLf _
                    & "     RPT.RPTID ||'-'|| CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END ||': '|| RPT.DESCRIPTION EN_TXDESC, " & ControlChars.CrLf _
                    & "     'E' TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
                    & "FROM SEARCH SR, RPTMASTER RPT  " & ControlChars.CrLf _
                    & "WHERE SR.SEARCHCODE = RPT.RPTID AND RPT.VISIBLE = 'Y' AND RPT.CMDTYPE IN ('V','D','L') AND RPT.MODCODE = '" & v_strParentKey & "'" & ControlChars.CrLf _
                    & "ORDER BY RPT.RPTID"

            'v_strSQL = "SELECT * FROM ( " & ControlChars.CrLf _
            '        & "SELECT MAX(RPT.RPTID) || '^' || M.TLTXCD TLTXCD, MAX(RPT.rptid ||'-'|| M.TLTXCD ||': '|| RPT.description) TXDESC, MAX(RPT.rptid ||'-'|| M.TLTXCD ||': '|| RPT.description) EN_TXDESC, MAX(M.TXTYPE) TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
            '        & "FROM TLTX M, APPMODULES A, SEARCH SR, RPTMASTER RPT  " & ControlChars.CrLf _
            '        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strParentKey & "'  " & ControlChars.CrLf _
            '        & "     AND M.tltxcd = SR.tltxcd AND SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND RPT.CMDTYPE = 'V' " & ControlChars.CrLf _
            '        & "GROUP BY M.TLTXCD " & ControlChars.CrLf _
            '        & "UNION ALL " & ControlChars.CrLf _
            '        & "SELECT RPT.rptid  || '^EXEC' TLTXCD, RPT.rptid ||'-'|| SR.TLTXCD ||': '|| RPT.description TXDESC, RPT.rptid ||'-'|| SR.TLTXCD ||': '|| RPT.description EN_TXDESC, 'E' TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
            '        & "FROM SEARCH SR, RPTMASTER RPT" & ControlChars.CrLf _
            '        & "WHERE SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND RPT.CMDTYPE = 'V' " & ControlChars.CrLf _
            '        & "     AND SUBSTR(RPT.rptid,1,2) = '" & v_strParentKey & "' AND SR.tltxcd = 'EXEC' " & ControlChars.CrLf _
            '        & ") M ORDER BY M.TLTXCD"
            'Else
            'v_strSQL = "SELECT RPT.RPTID || '^' || CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END TLTXCD," & ControlChars.CrLf _
            '        & "     RPT.RPTID ||'-'|| CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END ||': '|| RPT.DESCRIPTION TXDESC, " & ControlChars.CrLf _
            '        & "     RPT.RPTID ||'-'|| CASE WHEN SR.TLTXCD IS NULL THEN 'VIEW' ELSE SR.TLTXCD END ||': '|| RPT.DESCRIPTION EN_TXDESC, " & ControlChars.CrLf _
            '        & "     'E' TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
            '        & "FROM SEARCH SR, RPTMASTER RPT, CMDAUTH C  " & ControlChars.CrLf _
            '        & "WHERE SR.SEARCHCODE = RPT.RPTID AND RPT.VISIBLE = 'Y' AND RPT.CMDTYPE IN ('V','D','L') AND RPT.MODCODE = '" & v_strParentKey & "'" & ControlChars.CrLf _
            '        & "     AND RPT.RPTID = C.CMDCODE AND C.AUTHID = '" & v_strTellerId & "' AND C.AUTHTYPE = 'U' AND C.CMDTYPE = 'G' AND C.CMDALLOW = 'Y' " & ControlChars.CrLf _
            '        & "ORDER BY RPT.RPTID"

            ''v_strSQL = "SELECT * FROM ( " & ControlChars.CrLf _
            ''        & "SELECT MAX(RPT.RPTID) || '^' || M.TLTXCD TLTXCD, MAX(RPT.rptid ||'-'|| M.TLTXCD ||': '|| RPT.description) TXDESC, MAX(RPT.rptid ||'-'|| M.TLTXCD ||': '|| RPT.description) EN_TXDESC, MAX(M.TXTYPE) TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
            ''        & "FROM TLTX M, APPMODULES A, SEARCH SR, RPTMASTER RPT, CMDAUTH C  " & ControlChars.CrLf _
            ''        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strParentKey & "'  " & ControlChars.CrLf _
            ''        & "     AND M.tltxcd = SR.tltxcd AND SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND RPT.CMDTYPE = 'V' " & ControlChars.CrLf _
            ''        & "     AND RPT.RPTID = C.CMDCODE AND C.AUTHID = '" & v_strTellerId & "' AND C.AUTHTYPE = 'U' AND C.CMDTYPE = 'G' AND C.CMDALLOW = 'Y' " & ControlChars.CrLf _
            ''        & "GROUP BY M.TLTXCD " & ControlChars.CrLf _
            ''        & "UNION ALL " & ControlChars.CrLf _
            ''        & "SELECT RPT.rptid  || '^EXEC' TLTXCD, RPT.rptid ||'-'|| SR.TLTXCD ||': '|| RPT.description TXDESC, RPT.rptid ||'-'|| SR.TLTXCD ||': '|| RPT.description EN_TXDESC, 'E' TXTYPE, 'Y' CMDALLOW, 3 IMGINDEX, 4 LEV " & ControlChars.CrLf _
            ''        & "FROM SEARCH SR, RPTMASTER RPT, CMDAUTH C" & ControlChars.CrLf _
            ''        & "WHERE SR.searchcode = RPT.rptid AND RPT.visible = 'Y' AND RPT.CMDTYPE = 'V' " & ControlChars.CrLf _
            ''        & "     AND SUBSTR(RPT.rptid,1,2) = '" & v_strParentKey & "' AND SR.tltxcd = 'EXEC' " & ControlChars.CrLf _
            ''        & "     AND RPT.RPTID = C.CMDCODE AND C.AUTHID = '" & v_strTellerId & "' AND C.AUTHTYPE = 'U' AND C.CMDTYPE = 'G' AND C.CMDALLOW = 'Y' " & ControlChars.CrLf _
            ''        & ") M ORDER BY M.TLTXCD"
            'End If


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

#End Region

End Class
