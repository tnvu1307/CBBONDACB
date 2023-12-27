Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
'Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Configuration
Imports System.Data
Public Structure SYSTEMTIME
    Public wYear As UInt16
    Public wMonth As UInt16
    Public wDayOfWeek As UInt16
    Public wDay As UInt16
    Public wHour As UInt16
    Public wMinute As UInt16
    Public wSecond As UInt16
    Public wMilliseconds As UInt16
End Structure

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class SystemAdmin
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Public st As New SYSTEMTIME
    <DllImport("kernel32.dll")> _
    Public Shared Sub SetLocalTime(ByRef lpSystemTime As SYSTEMTIME)
    End Sub

    <DllImport("kernel32.dll")> _
    Public Shared Sub GetLocalTime(ByRef lpSystemTime As SYSTEMTIME)
    End Sub

#Region " Util Methods "

    Private Function GetErrorMsg(ByVal pv_lngErrorCode As Long, Optional ByVal pv_strLanguage As String = "VN") As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.GetErrorMsg", v_strErrorMessage As String
        Dim v_objDB As DataAccess, v_strSQL As String, v_ds As DataSet
        Dim v_strRet As String = ""
        Try
            v_objDB = New DataAccess
            v_objDB.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT ERRDESC,EN_ERRDESC FROM DEFERROR WHERE ERRNUM='" & pv_lngErrorCode.ToString() & "'"
            v_ds = v_objDB.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If pv_strLanguage = "VN" Then
                    v_strRet = v_ds.Tables(0).Rows(0)("ERRDESC").ToString()
                Else
                    v_strRet = v_ds.Tables(0).Rows(0)("EN_ERRDESC").ToString()
                End If
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_objDB = Nothing
            v_ds = Nothing
        End Try

        Return v_strRet
    End Function

#End Region

#Region " User/Group Authorization "
    Public Function GetReportList(ByRef pv_strObjMsg As String) As Long
        Dim v_dsUsr As DataSet
        Dim v_obj As New DataAccess
        Dim XMLDocument As New Xml.XmlDocument
        Try
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim hUsrRptFilter As New Hashtable
            Dim hRptFilter As New Hashtable
            Dim h_arrGrpRptFilter() As Hashtable
            Dim v_strRPTID, v_strRPTNAME, v_strTEMPLATEID, v_strPAPER, v_strORIENTATION, v_strSTOREDNAME, v_strISLOCAL, v_strSTRAUTH, v_strISCAREBY, v_strAREA, v_strSUBRPT, v_strISCMP, v_strAD_HOC As String
            Dim v_intNumGrp, v_intNumRpt As Integer


            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strBranchId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strModuleCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strAreaCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.AREA ,M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, 'YYA' STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP, M.TEMPLATEID " _
                        & "FROM RPTMASTER M, ALLCODE A " _
                        & "WHERE M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "ORDER BY M.RPTID"
            Else 'thunt
                v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME , M.AREA , M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP, M.TEMPLATEID  " _
                        & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                        & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strTellerId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'U' AND N.CMDTYPE = 'R' " _
                        & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "AND 1 = (CASE WHEN '" & v_strAreaCode & "' = 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'B' AND M.AREA <> 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'S' AND M.AREA <> 'A' AND M.AREA <> 'B' THEN 1 ELSE 0 END ) " _
                        & "ORDER BY M.RPTID"
            End If

            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strRPTID = IIf(v_dsUsr.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTID"))
                    v_strRPTNAME = IIf(v_dsUsr.Tables(0).Rows(i)("RPTNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTNAME"))
                    v_strPAPER = IIf(v_dsUsr.Tables(0).Rows(i)("PAPER") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PAPER"))
                    v_strORIENTATION = IIf(v_dsUsr.Tables(0).Rows(i)("ORIENTATION") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ORIENTATION"))
                    v_strSTOREDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("STOREDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STOREDNAME"))
                    v_strISLOCAL = IIf(v_dsUsr.Tables(0).Rows(i)("ISLOCAL") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISLOCAL"))
                    v_strSTRAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    v_strISCAREBY = IIf(v_dsUsr.Tables(0).Rows(i)("ISCAREBY") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCAREBY"))
                    v_strAREA = IIf(v_dsUsr.Tables(0).Rows(i)("AREA") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AREA"))
                    v_strSUBRPT = IIf(v_dsUsr.Tables(0).Rows(i)("SUBRPT") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("SUBRPT"))
                    v_strISCMP = IIf(v_dsUsr.Tables(0).Rows(i)("ISCMP") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCMP"))
                    v_strTEMPLATEID = IIf(v_dsUsr.Tables(0).Rows(i)("TEMPLATEID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("TEMPLATEID"))
                    v_strAD_HOC = IIf(v_dsUsr.Tables(0).Rows(i)("AD_HOC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AD_HOC"))
                    'Add new value to User hash table
                    v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strAREA & "|" & v_strSUBRPT & "|" & v_strISCMP & "|" & v_strTEMPLATEID & "|" & v_strAD_HOC
                    hUsrRptFilter.Add(v_strRPTID, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpRptFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.AREA, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP, M.TEMPLATEID  " _
                            & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                            & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strGrpId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'G' AND N.CMDTYPE = 'R' " _
                            & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                            & "AND 1 = (CASE WHEN '" & v_strAreaCode & "' = 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'B' AND M.AREA <> 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'S' AND M.AREA <> 'A' AND M.AREA <> 'B' THEN 1 ELSE 0 END ) " _
                            & "ORDER BY M.RPTID"

                    Dim v_dsGrpRpt As DataSet
                    v_dsGrpRpt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpRptFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRpt.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRpt.Tables(0).Rows.Count - 1
                            v_strRPTID = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTID") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTID"))
                            v_strRPTNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME"))
                            v_strPAPER = IIf(v_dsGrpRpt.Tables(0).Rows(j)("PAPER") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("PAPER"))
                            v_strORIENTATION = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION"))
                            v_strSTOREDNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME"))
                            v_strISLOCAL = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL"))
                            v_strSTRAUTH = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH"))
                            v_strISCAREBY = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY"))
                            v_strAREA = IIf(v_dsGrpRpt.Tables(0).Rows(j)("AREA") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("AREA"))
                            v_strSUBRPT = IIf(v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT"))
                            v_strISCMP = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCMP") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCMP"))
                            v_strTEMPLATEID = IIf(v_dsGrpRpt.Tables(0).Rows(j)("TEMPLATEID") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("TEMPLATEID"))
                            v_strAD_HOC = IIf(v_dsGrpRpt.Tables(0).Rows(j)("AD_HOC") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("AD_HOC"))
                            'Add new value to User hash table
                            'thunt
                            v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strAREA & "|" & v_strSUBRPT & "|" & v_strISCMP & "|" & v_strTEMPLATEID & "|" & v_strAD_HOC
                            hGrpFilter.Add(v_strRPTID, v_strHashValue)
                        Next
                    End If
                    h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT RPTID FROM RPTMASTER WHERE CMDTYPE='R' AND MODCODE = '" & v_strModuleCode & "' ORDER BY RPTID"
            Dim v_dsRptId As DataSet
            v_dsRptId = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrRPTID() As String
            If v_dsRptId.Tables(0).Rows.Count > 0 Then
                v_intNumRpt = v_dsRptId.Tables(0).Rows.Count
                ReDim v_arrRPTID(v_intNumRpt - 1)
                For i As Integer = 0 To v_intNumRpt - 1
                    v_arrRPTID(i) = IIf(v_dsRptId.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsRptId.Tables(0).Rows(i)("RPTID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsRpt As New DataSet
            v_dsRpt.Tables.Add()
            v_dsRpt.Tables(0).Columns.Add("RPTID")
            v_dsRpt.Tables(0).Columns.Add("RPTNAME")
            v_dsRpt.Tables(0).Columns.Add("PAPER")
            v_dsRpt.Tables(0).Columns.Add("ORIENTATION")
            v_dsRpt.Tables(0).Columns.Add("STOREDNAME")
            v_dsRpt.Tables(0).Columns.Add("ISLOCAL")
            v_dsRpt.Tables(0).Columns.Add("STRAUTH")
            v_dsRpt.Tables(0).Columns.Add("ISCAREBY")
            v_dsRpt.Tables(0).Columns.Add("AREA")
            v_dsRpt.Tables(0).Columns.Add("SUBRPT")
            v_dsRpt.Tables(0).Columns.Add("ISCMP")
            v_dsRpt.Tables(0).Columns.Add("TEMPLATEID") 'thunt
            v_dsRpt.Tables(0).Columns.Add("AD_HOC")
            Dim v_arrRpt() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumRpt > 0 Then
                For i As Integer = 0 To v_intNumRpt - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrRptFilter(v_arrRPTID(i)) Is Nothing Then
                        'Get data of row
                        v_arrRpt = CStr(hUsrRptFilter(v_arrRPTID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrRptFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strPrint, v_strAdd, v_strAreaRight As String
                            Dim v_blnPrint, v_blnAdd As Boolean
                            Dim v_blnPrePrint, v_blnPreAdd As Boolean
                            Dim v_strPreAreaRight As String

                            v_blnPrePrint = False
                            v_blnPreAdd = False
                            v_strPreAreaRight = "S" 'Gan quyen pham vi nho nhat - phong giao dich

                            If Not v_arrRpt Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrRpt.Clear(v_arrRpt, 0, v_arrRpt.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpRptFilter(j)(v_arrRPTID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrRpt = CStr(h_arrGrpRptFilter(j)(v_arrRPTID(i))).Split("|")
                                    v_strAUTHSTR = v_arrRpt(6)
                                    v_strPrint = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strAreaRight = Mid(v_strAUTHSTR, 3, 1)

                                    v_blnPrint = IIf(v_strPrint = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)

                                    'Combination right of groups
                                    v_blnPrint = (v_blnPrint Or v_blnPrePrint)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    If v_strAreaRight = "S" And (v_strPreAreaRight = "A" Or v_strPreAreaRight = "B") Then
                                        v_strAreaRight = v_strPreAreaRight
                                    ElseIf v_strAreaRight = "B" And v_strPreAreaRight = "A" Then
                                        v_strAreaRight = v_strPreAreaRight
                                    End If

                                    'Assign right to previous right
                                    v_blnPrePrint = v_blnPrint
                                    v_blnPreAdd = v_blnAdd
                                    v_strPreAreaRight = v_strAreaRight
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrRpt Is Nothing Then
                                If Not v_arrRpt.GetValue(0) Is Nothing Then
                                    v_strPrint = IIf(v_blnPrint = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strAUTHSTR = v_strPrint & v_strAdd & v_strAreaRight
                                    v_arrRpt(6) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                                End If
                            End If
                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsRpt, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
            XMLDocument = Nothing
        End Try
    End Function

    Public Function GetReportBatch(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_obj As New DataAccess
        Try
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim hUsrRptFilter As New Hashtable
            Dim hRptFilter As New Hashtable
            Dim h_arrGrpRptFilter() As Hashtable
            Dim v_strRPTID, v_strRPTNAME, v_strPAPER, v_strORIENTATION, v_strSTOREDNAME, v_strISLOCAL, v_strSTRAUTH, v_strISCAREBY, v_strSUBRPT, v_strISCMP As String
            Dim v_intNumGrp, v_intNumRpt As Integer


            XmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XmlDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strBranchId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strModuleCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, 'YY' STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                        & "FROM RPTMASTER M, ALLCODE A " _
                        & "WHERE M.CMDTYPE='R' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION  AND M.ISPUBLIC = 'Y' " _
                        & "ORDER BY M.RPTID"

            Else
                v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                        & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                        & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strTellerId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'U' AND N.CMDTYPE = 'R' " _
                        & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "ORDER BY M.RPTID"
            End If

            Dim v_dsUsr As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strRPTID = IIf(v_dsUsr.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTID"))
                    v_strRPTNAME = IIf(v_dsUsr.Tables(0).Rows(i)("RPTNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTNAME"))
                    v_strPAPER = IIf(v_dsUsr.Tables(0).Rows(i)("PAPER") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PAPER"))
                    v_strORIENTATION = IIf(v_dsUsr.Tables(0).Rows(i)("ORIENTATION") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ORIENTATION"))
                    v_strSTOREDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("STOREDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STOREDNAME"))
                    v_strISLOCAL = IIf(v_dsUsr.Tables(0).Rows(i)("ISLOCAL") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISLOCAL"))
                    v_strSTRAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    v_strISCAREBY = IIf(v_dsUsr.Tables(0).Rows(i)("ISCAREBY") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCAREBY"))
                    v_strSUBRPT = IIf(v_dsUsr.Tables(0).Rows(i)("SUBRPT") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("SUBRPT"))
                    v_strISCMP = IIf(v_dsUsr.Tables(0).Rows(i)("ISCMP") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCMP"))
                    'Add new value to User hash table
                    v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strSUBRPT & "|" & v_strISCMP
                    hUsrRptFilter.Add(v_strRPTID, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpRptFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                            & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                            & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strGrpId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'G' AND N.CMDTYPE = 'R' " _
                            & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                            & "ORDER BY M.RPTID"

                    Dim v_dsGrpRpt As DataSet
                    v_dsGrpRpt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpRptFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRpt.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRpt.Tables(0).Rows.Count - 1
                            v_strRPTID = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTID") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTID"))
                            v_strRPTNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME"))
                            v_strPAPER = IIf(v_dsGrpRpt.Tables(0).Rows(j)("PAPER") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("PAPER"))
                            v_strORIENTATION = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION"))
                            v_strSTOREDNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME"))
                            v_strISLOCAL = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL"))
                            v_strSTRAUTH = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH"))
                            v_strISCAREBY = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY"))
                            v_strSUBRPT = IIf(v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT"))
                            v_strISCMP = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCMP") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCMP"))
                            'Add new value to User hash table
                            v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strSUBRPT & "|" & v_strISCMP
                            hGrpFilter.Add(v_strRPTID, v_strHashValue)
                        Next
                    End If
                    h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT RPTID FROM RPTMASTER WHERE CMDTYPE='R'  ORDER BY RPTID"
            Dim v_dsRptId As DataSet
            v_dsRptId = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrRPTID() As String
            If v_dsRptId.Tables(0).Rows.Count > 0 Then
                v_intNumRpt = v_dsRptId.Tables(0).Rows.Count
                ReDim v_arrRPTID(v_intNumRpt - 1)
                For i As Integer = 0 To v_intNumRpt - 1
                    v_arrRPTID(i) = IIf(v_dsRptId.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsRptId.Tables(0).Rows(i)("RPTID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsRpt As New DataSet
            v_dsRpt.Tables.Add()
            v_dsRpt.Tables(0).Columns.Add("RPTID")
            v_dsRpt.Tables(0).Columns.Add("RPTNAME")
            v_dsRpt.Tables(0).Columns.Add("PAPER")
            v_dsRpt.Tables(0).Columns.Add("ORIENTATION")
            v_dsRpt.Tables(0).Columns.Add("STOREDNAME")
            v_dsRpt.Tables(0).Columns.Add("ISLOCAL")
            v_dsRpt.Tables(0).Columns.Add("STRAUTH")
            v_dsRpt.Tables(0).Columns.Add("ISCAREBY")
            v_dsRpt.Tables(0).Columns.Add("SUBRPT")
            v_dsRpt.Tables(0).Columns.Add("ISCMP")

            Dim v_arrRpt() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumRpt > 0 Then
                For i As Integer = 0 To v_intNumRpt - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrRptFilter(v_arrRPTID(i)) Is Nothing Then
                        'Get data of row
                        v_arrRpt = CStr(hUsrRptFilter(v_arrRPTID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrRptFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strPrint, v_strAdd As String
                            Dim v_blnPrint, v_blnAdd As Boolean
                            Dim v_blnPrePrint, v_blnPreAdd As Boolean

                            v_blnPrePrint = False
                            v_blnPreAdd = False

                            If Not v_arrRpt Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrRpt.Clear(v_arrRpt, 0, v_arrRpt.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpRptFilter(j)(v_arrRPTID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrRpt = CStr(h_arrGrpRptFilter(j)(v_arrRPTID(i))).Split("|")
                                    v_strAUTHSTR = v_arrRpt(6)
                                    v_strPrint = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)

                                    v_blnPrint = IIf(v_strPrint = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)

                                    'Combination right of groups
                                    v_blnPrint = (v_blnPrint Or v_blnPrePrint)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)

                                    'Assign right to previous right
                                    v_blnPrePrint = v_blnPrint
                                    v_blnPreAdd = v_blnAdd
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrRpt Is Nothing Then
                                If Not v_arrRpt.GetValue(0) Is Nothing Then
                                    v_strPrint = IIf(v_blnPrint = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strAUTHSTR = v_strPrint & v_strAdd
                                    v_arrRpt(6) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                                End If
                            End If
                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsRpt, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
            XMLDocument = Nothing
        End Try
    End Function

    Public Function GetUserParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            v_strTellerId = Trim(v_strTellerId)
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                        & "from CMDMENU M " _
                                        & "where M.LEV = 1 " _
                                        & "order by M.CMDID"
            Else
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                        & "from CMDMENU M, CMDAUTH A " _
                                        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                                        & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
                                        & "order by M.CMDID"
            End If


            Dim v_dsUsr As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE
                    If Not hUsrFuncFilter.ContainsKey(v_strCMDCODE) Then
                        hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                    End If
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                            & "from CMDMENU M, CMDAUTH A " _
                                            & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                                            & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV = 1 " _
                                            & "order by M.CMDID"

                    Dim v_dsGrpRight As DataSet
                    v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE
                            If Not hGrpFilter.ContainsKey(v_strCMDCODE) Then
                                hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                            End If
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM CMDMENU WHERE LEV = '1' order by CMDID"
            Dim v_dsCmdid As DataSet
            v_dsCmdid = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumFunc - 1
                If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                    'Get data of row
                    v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                    'Add right of user to dataset
                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                'Get data of row
                                v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                'Add right of user to dataset
                                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function GetUserAdjustMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strREFCMDCODE, v_strEN_CMDNAME, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strLAST, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            v_strTellerId = Trim(v_strTellerId)
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
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
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE, " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE    " & ControlChars.CrLf _
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
            Else
                v_strSQL = "select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                            & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                            & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                            & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE " & ControlChars.CrLf _
                            & "from ADJUSTMENU AM,  " & ControlChars.CrLf _
                            & "    (Select M.*  " & ControlChars.CrLf _
                            & "        from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                            & "        where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') M, " & ControlChars.CrLf _
                            & "    (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                            & "        from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                            & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                            & "         AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'U' and tl.AUTHID = '" & v_strTellerId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                            & "    (select R.*  " & ControlChars.CrLf _
                            & "        from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                            & "        where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                            & "        AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                            & "        and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') R,   " & ControlChars.CrLf _
                            & "    (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                            & "        from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                            & "        where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                            & "        AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                            & "        and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') G   " & ControlChars.CrLf _
                            & "where AM.LEV = 1  " & ControlChars.CrLf _
                            & "    and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                            & "    and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                            & "    and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                            & "    and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                            & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                            & "            ) " & ControlChars.CrLf _
                            & "order by AM.CMDID"
            End If


            Dim v_dsUsr As DataSet
            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strREFCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("REFCMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("REFCMDCODE"))
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strREFCMDCODE & "|" & v_strLAST & "|" & v_strAUTHCODE & "|" & v_strAUTH
                    If Not hUsrFuncFilter.ContainsKey(v_strCMDCODE) Then
                        hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                    End If
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    'v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                    '                        & "from CMDMENU M, CMDAUTH A " _
                    '                        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                    '                        & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV = 1 " _
                    '                        & "order by M.CMDID"
                    v_strSQL = "select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                                & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                                & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                                & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                                & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                                & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                                & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE  " & ControlChars.CrLf _
                                & "from ADJUSTMENU AM,  " & ControlChars.CrLf _
                                & "    (Select M.*  " & ControlChars.CrLf _
                                & "        from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                                & "        where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') M, " & ControlChars.CrLf _
                                & "    (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                                & "        from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                                & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                                & "         AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'G' and tl.AUTHID = '" & v_strGrpId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                                & "    (select R.*  " & ControlChars.CrLf _
                                & "        from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                                & "        where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                                & "        AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                                & "        and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') R,   " & ControlChars.CrLf _
                                & "    (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                                & "        from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                                & "        where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                                & "        AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                                & "        and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') G   " & ControlChars.CrLf _
                                & "where AM.LEV = 1  " & ControlChars.CrLf _
                                & "    and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                                & "    and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                                & "    and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                                & "    and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                                & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                                & "            ) " & ControlChars.CrLf _
                                & "order by AM.CMDID"

                    Dim v_dsGrpRight As DataSet
                    v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strREFCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE"))
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strREFCMDCODE & "|" & v_strLAST & "|" & v_strAUTHCODE & "|" & v_strAUTH
                            If Not hGrpFilter.ContainsKey(v_strCMDCODE) Then
                                hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                            End If
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM ADJUSTMENU WHERE LEV = '1' order by CMDID"
            Dim v_dsCmdid As DataSet
            v_dsCmdid = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("REFCMDCODE")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumFunc - 1
                If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                    'Get data of row
                    v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                    'Add right of user to dataset
                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                'Get data of row
                                v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                'Add right of user to dataset
                                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function GetUserChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strLAST, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            If v_strArr.Length = 2 Then
                v_strTellerId = Trim(v_strArr(0))
                v_strParentKey = Trim(v_strArr(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                & "M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH " _
                                & "from CMDMENU M " _
                                & "where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                & "order by M.CMDID"
            Else
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                & "from CMDMENU M, CMDAUTH A " _
                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                & "order by M.CMDID"
            End If


            Dim v_dsUsr As DataSet
            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                    hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                                & "from CMDMENU M, CMDAUTH A " _
                                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                                & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                & "order by M.CMDID"

                    Dim v_dsGrpRight As DataSet
                    v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                            hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM CMDMENU WHERE PRID = '" & v_strParentKey & "' order by CMDID"
            Dim v_dsCmdid As DataSet
            v_dsCmdid = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumFunc > 0 Then
                For i As Integer = 0 To v_intNumFunc - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                        'Get data of row
                        v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove As String
                            Dim v_blnInquiry, v_blnAdd, v_blnEdit, v_blnDelete, v_blnApprove As Boolean
                            Dim v_blnPreInquiry, v_blnPreAdd, v_blnPreEdit, v_blnPreDelete, v_blnPreApprove As Boolean

                            v_blnPreInquiry = False
                            v_blnPreAdd = False
                            v_blnPreEdit = False
                            v_blnPreDelete = False
                            v_blnPreApprove = False

                            If Not v_arrFunc Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                    v_strAUTHSTR = v_arrFunc(10)
                                    v_strInquiry = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strEdit = Mid(v_strAUTHSTR, 3, 1)
                                    v_strDelete = Mid(v_strAUTHSTR, 4, 1)
                                    v_strApprove = Mid(v_strAUTHSTR, 5, 1)

                                    v_blnInquiry = IIf(v_strInquiry = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)
                                    v_blnEdit = IIf(v_strEdit = "Y", True, False)
                                    v_blnDelete = IIf(v_strDelete = "Y", True, False)
                                    v_blnApprove = IIf(v_strApprove = "Y", True, False)

                                    'Combination right of groups
                                    v_blnInquiry = (v_blnInquiry Or v_blnPreInquiry)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    v_blnEdit = (v_blnEdit Or v_blnPreEdit)
                                    v_blnDelete = (v_blnDelete Or v_blnPreDelete)
                                    v_blnApprove = (v_blnApprove Or v_blnPreApprove)

                                    'Assign right to previous right
                                    v_blnPreInquiry = v_blnInquiry
                                    v_blnPreAdd = v_blnAdd
                                    v_blnPreEdit = v_blnEdit
                                    v_blnPreDelete = v_blnDelete
                                    v_blnPreApprove = v_blnApprove
                                    'Else
                                    '    If Not v_arrFunc Is Nothing Then
                                    '        'v_arrFunc.s
                                    '        'ReDim v_arrFunc(0)
                                    '        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                                    '    End If
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrFunc Is Nothing Then
                                If Not v_arrFunc.GetValue(0) Is Nothing Then
                                    v_strInquiry = IIf(v_blnInquiry = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strEdit = IIf(v_blnEdit = True, "Y", "N")
                                    v_strDelete = IIf(v_blnDelete = True, "Y", "N")
                                    v_strApprove = IIf(v_blnApprove = True, "Y", "N")
                                    v_strAUTHSTR = v_strInquiry & v_strAdd & v_strEdit & v_strDelete & v_strApprove
                                    v_arrFunc(10) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                End If
                            End If

                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function GetTransChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_arrClause(), v_strTellerId, v_strHashValue, v_strModCode As String
        Dim v_strTLTXCD, v_strTXDESC, v_strEN_TXDESC, v_strMODCOD, v_strCMDALLOW, v_strIMGINDEX As String
        Dim v_intNumGrp, v_intNumTrans As Integer
        Dim hUsrTransFilter As New Hashtable
        Dim h_arrGrpTransFilter() As Hashtable
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_arrClause = v_strClause.Split("|")
            If v_arrClause.Length = 2 Then
                v_strTellerId = Trim(v_arrClause(0))
                v_strModCode = Trim(v_arrClause(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, 'Y' CMDALLOW, 3 IMGINDEX " _
                                        & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                            & "FROM TLTX N, APPMODULES B " _
                                            & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT='Y') M " _
                                        & "WHERE M.MODCODE = '" & v_strModCode & "' " _
                                        & "ORDER BY M.TLTXCD "
            Else
                v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, A.CMDALLOW CMDALLOW, 3 IMGINDEX " _
                                        & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                            & "FROM TLTX N, APPMODULES B " _
                                            & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT='Y') M, CMDAUTH A " _
                                        & "WHERE M.MODCODE = '" & v_strModCode & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' " _
                                        & "AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                        & "ORDER BY M.TLTXCD "
            End If


            Dim v_dsUsr As DataSet
            v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strTLTXCD = IIf(v_dsUsr.Tables(0).Rows(i)("TLTXCD") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("TLTXCD"))
                    v_strTXDESC = IIf(v_dsUsr.Tables(0).Rows(i)("TXDESC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("TXDESC"))
                    v_strEN_TXDESC = IIf(v_dsUsr.Tables(0).Rows(i)("EN_TXDESC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_TXDESC"))
                    v_strMODCOD = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strCMDALLOW = IIf(v_dsUsr.Tables(0).Rows(i)("CMDALLOW") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDALLOW"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))

                    'Add new value to User hash table
                    v_strHashValue = v_strTLTXCD & "|" & v_strTXDESC & "|" & v_strEN_TXDESC & "|" & v_strMODCOD & "|" & v_strCMDALLOW & "|" & v_strIMGINDEX
                    hUsrTransFilter.Add(v_strTLTXCD, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpTransFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, A.CMDALLOW CMDALLOW, 3 IMGINDEX " _
                                & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                    & "FROM TLTX N, APPMODULES B " _
                                & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT = 'Y') M, CMDAUTH A " _
                                & "WHERE M.MODCODE = '" & v_strModCode & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strGrpId & "' " _
                                & "AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                & "ORDER BY M.TLTXCD "

                    Dim v_dsGrpRight As DataSet
                    v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpTransFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strTLTXCD = IIf(v_dsGrpRight.Tables(0).Rows(j)("TLTXCD") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("TLTXCD"))
                            v_strTXDESC = IIf(v_dsGrpRight.Tables(0).Rows(j)("TXDESC") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("TXDESC"))
                            v_strEN_TXDESC = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_TXDESC") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_TXDESC"))
                            v_strMODCOD = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strCMDALLOW = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDALLOW"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            'Add new value to User hash table
                            v_strHashValue = v_strTLTXCD & "|" & v_strTXDESC & "|" & v_strEN_TXDESC & "|" & v_strMODCOD & "|" & v_strCMDALLOW & "|" & v_strIMGINDEX
                            hGrpFilter.Add(v_strTLTXCD, v_strHashValue)
                        Next
                    End If
                    h_arrGrpTransFilter(i) = hGrpFilter
                Next
            End If

            'Get TLTCXD of all transaction
            v_strSQL = "SELECT M.TLTXCD TLTXCD FROM TLTX M, APPMODULES A " _
                        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strModCode & "' " _
                        & "ORDER BY M.TLTXCD "
            Dim v_dsTltxcd As DataSet
            v_dsTltxcd = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrTLTXCD() As String
            If v_dsTltxcd.Tables(0).Rows.Count > 0 Then
                v_intNumTrans = v_dsTltxcd.Tables(0).Rows.Count
                ReDim v_arrTLTXCD(v_intNumTrans - 1)
                For i As Integer = 0 To v_intNumTrans - 1
                    v_arrTLTXCD(i) = IIf(v_dsTltxcd.Tables(0).Rows(i)("TLTXCD") Is DBNull.Value, "", v_dsTltxcd.Tables(0).Rows(i)("TLTXCD"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsTrans As New DataSet
            v_dsTrans.Tables.Add()
            v_dsTrans.Tables(0).Columns.Add("TLTXCD")
            v_dsTrans.Tables(0).Columns.Add("TXDESC")
            v_dsTrans.Tables(0).Columns.Add("EN_TXDESC")
            v_dsTrans.Tables(0).Columns.Add("MODCODE")
            v_dsTrans.Tables(0).Columns.Add("CMDALLOW")
            v_dsTrans.Tables(0).Columns.Add("IMGINDEX")

            Dim v_arrTrans() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumTrans - 1
                If Not hUsrTransFilter(v_arrTLTXCD(i)) Is Nothing Then
                    'Get data of row
                    v_arrTrans = CStr(hUsrTransFilter(v_arrTLTXCD(i))).Split("|")
                    'Add right of user to dataset
                    v_dsTrans.Tables(0).Rows.Add(v_arrTrans)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpTransFilter(j)(v_arrTLTXCD(i)) Is Nothing Then
                                'Get data of row
                                v_arrTrans = CStr(h_arrGrpTransFilter(j)(v_arrTLTXCD(i))).Split("|")
                                'Add right of user to dataset
                                v_dsTrans.Tables(0).Rows.Add(v_arrTrans)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsTrans, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function GetTellerRight(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
        Dim v_arrGRPRIGHT() As String
        Dim v_intNumGrp, v_intNumFunc As Integer

        XMLDocument.LoadXml(pv_strObjMsg)
        Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
        Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try

            v_strTellerId = Trim(v_strClause)

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            Dim v_dsGrp As DataSet
            v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select GRPRIGHT FROM TLGROUPS WHERE GRPID = '" & v_strGrpId & "'"

                    Dim v_dsGrpRight As DataSet
                    v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve v_arrGRPRIGHT(v_intNumGrp - 1)

                    If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                        v_arrGRPRIGHT(i) = IIf(v_dsGrpRight.Tables(0).Rows(0)("GRPRIGHT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("GRPRIGHT"))
                    End If

                    'h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Create dataset to contain right of teller
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("GRPRIGHT")

            Dim v_arrFunc(0) As String

            'Check right of each function, 
            If v_intNumGrp > 0 Then
                Dim v_strGRPRIGHT As String
                Dim v_strMaker, v_strCashier, v_strOfficer, v_strChecker As String
                Dim v_blnMaker, v_blnCashier, v_blnOfficer, v_blnChecker As Boolean
                Dim v_blnPreMaker, v_blnPreCashier, v_blnPreOfficer, v_blnPreChecker As Boolean

                v_blnPreMaker = False
                v_blnPreCashier = False
                v_blnPreOfficer = False
                v_blnPreChecker = False

                If Not v_arrFunc Is Nothing Then
                    'v_arrFunc.s
                    'ReDim v_arrFunc(0)
                    v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                End If

                For i As Integer = 0 To v_intNumGrp - 1
                    If Not CStr(v_arrGRPRIGHT(i)) Is String.Empty Then
                        'Get data of row
                        v_strMaker = Mid(v_arrGRPRIGHT(i), 1, 1)
                        v_strCashier = Mid(v_arrGRPRIGHT(i), 2, 1)
                        v_strOfficer = Mid(v_arrGRPRIGHT(i), 3, 1)
                        v_strChecker = Mid(v_arrGRPRIGHT(i), 4, 1)

                        v_blnMaker = IIf(v_strMaker = "Y", True, False)
                        v_blnCashier = IIf(v_strCashier = "Y", True, False)
                        v_blnOfficer = IIf(v_strOfficer = "Y", True, False)
                        v_blnChecker = IIf(v_strChecker = "Y", True, False)

                        'Combination right of groups
                        v_blnMaker = (v_blnMaker Or v_blnPreMaker)
                        v_blnCashier = (v_blnCashier Or v_blnPreCashier)
                        v_blnOfficer = (v_blnOfficer Or v_blnPreOfficer)
                        v_blnChecker = (v_blnChecker Or v_blnPreChecker)

                        'Assign right to previous right
                        v_blnPreMaker = v_blnMaker
                        v_blnPreCashier = v_blnCashier
                        v_blnPreOfficer = v_blnOfficer
                        v_blnPreChecker = v_blnChecker
                        'Else
                        '    If Not v_arrFunc Is Nothing Then
                        '        'v_arrFunc.s
                        '        'ReDim v_arrFunc(0)
                        '        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                        '    End If
                    End If
                Next
                'Get last right of groups
                v_strMaker = IIf(v_blnMaker = True, "Y", "N")
                v_strCashier = IIf(v_blnCashier = True, "Y", "N")
                v_strOfficer = IIf(v_blnOfficer = True, "Y", "N")
                v_strChecker = IIf(v_blnChecker = True, "Y", "N")
                v_strGRPRIGHT = v_strMaker & v_strCashier & v_strOfficer & v_strChecker
                v_arrFunc(0) = v_strGRPRIGHT

                'Add right of user to dataset
                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)

            End If

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        Finally
            v_obj = Nothing
        End Try

    End Function

    Public Function ChangeBOPassword(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL As String
        Dim v_strTellerID, v_strOldPass, v_strNewPass As String
        Dim v_ds As DataSet
        Dim v_lngErr As Long = ERR_SYSTEM_OK
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            Dim v_arrParam As String() = Trim(v_strClause).Split("|".ToCharArray())

            If v_arrParam.GetLength(0) = 3 Then
                v_strTellerID = v_arrParam(0)
                v_strOldPass = v_arrParam(1)
                v_strNewPass = v_arrParam(2)

                v_strSQL = "SELECT * FROM TLPROFILES WHERE TLID='" & v_strTellerID & "' AND PIN=GENENCRYPTPASSWORD('" & v_strOldPass & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds Is Nothing Then
                    If v_ds.Tables(0).Rows.Count > 0 Then

                        'TruongLD Add 10/08/2016, ValidatePassword 
                        v_lngErr = ValidatePassword(v_strNewPass, v_strOldPass)
                        If v_lngErr <> ERR_SYSTEM_OK Then
                            Rollback()
                            Return v_lngErr
                        End If

                        v_strSQL = "UPDATE TLPROFILES SET PIN=GENENCRYPTPASSWORD('" & v_strNewPass & "') WHERE TLID='" & v_strTellerID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        Rollback()
                        Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                    End If
                Else
                    Rollback()
                    Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                End If
            Else
                Rollback()
                Return ERR_SA_CHANGEPASS_INPUTINCORRECT
            End If

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        Finally
            v_obj = Nothing
        End Try

    End Function

    Public Function GetGroupCareBy(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
        Dim v_arrGRPRIGHT() As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            If v_strTellerId = ADMIN_ID Then
                'v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y' ORDER BY GRPID "
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y' ORDER BY (CASE WHEN GRPID =NVL((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' AND VARNAME='DEFGRPCAREBY'),'0000')  THEN '0000' ELSE GRPID END) "
            Else
                'v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                '                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y')" _
                '                                        & " AND M.GRPID = N.GRPID ORDER BY M.GRPID "
                v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y')" _
                                                        & " AND M.GRPID = N.GRPID ORDER BY (CASE WHEN M.GRPID =NVL((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' AND VARNAME='DEFGRPCAREBY'),'0000')  THEN '0000' ELSE M.GRPID END) "
            End If


            Dim v_ds As DataSet
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            v_obj = Nothing
        End Try

    End Function

    Public Function GetTellerGroup(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
        Dim v_arrGRPRIGHT() As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE ACTIVE = 'Y' ORDER BY GRPID "
            Else
                v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE ACTIVE = 'Y')" _
                                                        & " AND M.GRPID = N.GRPID ORDER BY M.GRPID "
            End If


            Dim v_ds As DataSet
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            v_obj = Nothing
        End Try

    End Function

    Public Function GetAuthorizationTicket(ByRef pv_strObjMsg As String) As Long
        Dim v_strRetval As String
        Dim v_strTellerId, v_strBranchId, v_strPIN As String
        Dim v_strEncryPass, v_strUserName, v_strPassword As String
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        Try
            'Lay thong tin UserName va Password
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            v_strUserName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_strPassword = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Dim v_bCmd As New BusinessCommand
            v_bCmd.SQLCommand = "Select BRID, TLID, PIN, SYSDATE , GENENCRYPTPASSWORD('" + v_strPassword + "') ENCRYPASS from TLPROFILES where upper(TLNAME) = '" & UCase$(v_strUserName) & "' And ACTIVE = 'Y'"

            v_dal.LogCommand = True
            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

            If v_ds.Tables(0).Rows.Count = 1 Then
                v_strBranchId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID"))
                v_strTellerId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
                v_strPIN = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PIN"))
                v_strEncryPass = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ENCRYPASS"))
                If v_strBranchId = String.Empty Or v_strTellerId = String.Empty Then
                    v_strRetval = Nothing
                Else
                    If (v_strPassword.Length > 0) Then     'Lưu mật khẩu trong DB
                        'If (DataProtection.UnprotectData(pv_strPassword) <> DataProtection.UnprotectData(v_strPIN)) Then
                        'Ducnv kiem tra pass ma hoa
                        If v_strPIN <> v_strEncryPass Then
                            v_strRetval = Nothing
                        Else
                            v_strRetval = v_strBranchId & "|" & v_strTellerId & "|" & DataProtection.UnprotectData(v_strPIN)
                        End If
                    Else    'Sử dụng LDAP để lưu mật khẩu
                        v_strRetval = v_strBranchId & "|" & v_strTellerId
                    End If
                End If
            Else
                v_strRetval = Nothing
            End If

            'Gan gia tri Retval tra ve
            XMLDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_strRetval
            pv_strObjMsg = XMLDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        Finally
            XMLDocument = Nothing
            v_dal = Nothing
        End Try
    End Function

    Public Function GetTellerProfile(ByRef pv_strObjMsg As String) As Long
        Dim v_strBrachId, v_strTellerId As String
        Dim v_strTLTYPE, v_strGRPTYPE, v_strMaxType As String
        Dim tlProfile As New CTellerProfile
        Dim v_strObjMsg As String
        Dim v_XmlDocument As New Xml.XmlDocument

        v_XmlDocument.LoadXml(pv_strObjMsg)
        Dim v_attrColl As Xml.XmlAttributeCollection = v_XmlDocument.DocumentElement.Attributes
        v_strBrachId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
        v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

        Dim v_strSQL As String = "Select P.BRID BDSID, P.TLID TLID, B.BRNAME BRNAME, P.DESCRIPTION DESCRIPTION, P.TLTYPE TLTYPE, " _
            & "P.TLGROUP TLGROUP, P.TLID TLID, P.TLLEV TLLEV, P.TLNAME TLNAME, P.TLPRN TLPRN, P.TLTITLE TLTITLE, P.TLFULLNAME TLFULLNAME, P.PIN PIN, " _
            & " (SELECT MAX(SUBSTR(GRPRIGHT,1,1)) || MAX(SUBSTR(GRPRIGHT,2,1)) || MAX(SUBSTR(GRPRIGHT,3,1)) || MAX(SUBSTR(GRPRIGHT,4,1)) GRPRIGHT " _
            & " FROM TLPROFILES TL, TLGROUPS GRP, TLGRPUSERS TLGRP " _
            & " WHERE  TL.TLID = TLGRP.TLID AND GRP.GRPID = TLGRP.GRPID  AND TL.TLID = '" & v_strTellerId & "') GRPRIGHT " _
            & "from BRGRP B, TLPROFILES P " _
            & "where B.BRID = P.BRID and P.BRID = '" & v_strBrachId & "' and P.TLID = '" & v_strTellerId & "'"

        Dim v_bCmd As New BusinessCommand
        v_bCmd.ExecuteUser = "FLEX"
        v_bCmd.SQLCommand = v_strSQL

        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        Dim v_strBUSDATE, v_strNEXTDATE, v_strINTERVAL, v_strSYSVAR, v_strTIMESEARCH, v_strCOMPANYCD, v_strCOMPANYNAME, v_strDEPOSITID As String, v_lngError As Long
        v_lngError = v_dal.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
        v_lngError = v_dal.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
        v_lngError = v_dal.GetSysVar("SYSTEM", "TLLOGINTERVAL", v_strINTERVAL)
        v_lngError = v_dal.GetSysVar("SYSTEM", "TIMESEARCH", v_strTIMESEARCH)
        v_lngError = v_dal.GetSysVar("SYSTEM", "HEADOFFICE", v_strCOMPANYNAME)
        v_lngError = v_dal.GetSysVar("SYSTEM", "DEALINGCUSTODYCD", v_strCOMPANYCD)
        'v_lngError = v_dal.GetSysVar("SYSTEM", "DEPOSITID", v_strDEPOSITID)
        v_strCOMPANYCD = v_strCOMPANYCD.Replace("P", String.Empty)
        v_dal.LogCommand = True

        Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

        'Dim v_ds As DataSet = OracleHelper.ExecuteDataset(mv_strConnectionString, CommandType.Text, v_strSQL)

        If v_ds.Tables(0).Rows.Count = 1 Then
            tlProfile.BranchId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BDSID"))
            tlProfile.BranchName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRNAME"))
            tlProfile.Description = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DESCRIPTION"))
            v_strGRPTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTYPE"))
            v_strTLTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("GRPRIGHT"))
            v_strMaxType = ""
            If Trim(v_strGRPTYPE).Length >= 4 Then
                If Mid(v_strGRPTYPE, 1, 1) > Mid(v_strTLTYPE, 1, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 1, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 1, 1)
                End If
                If Mid(v_strGRPTYPE, 2, 1) > Mid(v_strTLTYPE, 2, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 2, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 2, 1)
                End If
                If Mid(v_strGRPTYPE, 3, 1) > Mid(v_strTLTYPE, 3, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 3, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 3, 1)
                End If
                If Mid(v_strGRPTYPE, 4, 1) > Mid(v_strTLTYPE, 4, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 4, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 4, 1)
                End If
                v_strMaxType &= Mid(v_strTLTYPE, 5)
            End If
            'tlProfile.TellerRight = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTYPE"))
            tlProfile.TellerRight = v_strMaxType
            tlProfile.TellerGroup = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLGROUP"))
            tlProfile.TellerId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
            tlProfile.TellerLevel = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TLLEV"))
            tlProfile.TellerName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLNAME"))
            tlProfile.TellerFullName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLFULLNAME"))
            tlProfile.TellerPrinterName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLPRN"))
            tlProfile.TellerTitle = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTITLE"))
            tlProfile.Password = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PIN"))
            tlProfile.BusDate = v_strBUSDATE
            tlProfile.NextDate = v_strNEXTDATE
            tlProfile.Interval = v_strINTERVAL
            tlProfile.TimeSearch = v_strTIMESEARCH
            tlProfile.CompanyName = v_strCOMPANYNAME
            tlProfile.CompanyCode = v_strCOMPANYCD
            'tlProfile.DepositID = v_strDEPOSITID
        End If

        v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
        v_ds = v_dal.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count > 0 Then
            tlProfile.LoginTime = v_ds.Tables(0).Rows(0)("TXTIME")
        Else
            tlProfile.LoginTime = "00:00:00"
        End If

        'Convert to XML to return
        Dim xml_serializer As New Xml.Serialization.XmlSerializer(tlProfile.GetType)
        Dim string_writer As New StringWriter
        xml_serializer.Serialize(string_writer, tlProfile)
        pv_strObjMsg = string_writer.ToString

        Complete() 'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Public Function GetFunctionsByTellerId(ByRef pv_strObjMsg As String) As Long
        Dim v_strTellerId As String
        Dim v_strSQL As String
        Dim v_XmlDocument As New Xml.XmlDocument

        v_XmlDocument.LoadXml(pv_strObjMsg)
        Dim v_attrColl As Xml.XmlAttributeCollection = v_XmlDocument.DocumentElement.Attributes
        v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

        v_strSQL = "Select A.CMDCODE CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME " _
            & "from CMDMENU M, CMDAUTH A " _
            & "where M.CMDID = A.CMDCODE and A.CMDTYPE = 'M' and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            & "and A.AUTHID = '" & v_strTellerId & "' " _
            & "order by A.CMDCODE"

        Dim v_bCmd As New BusinessCommand
        v_bCmd.ExecuteUser = "FLEX"
        v_bCmd.SQLCommand = v_strSQL

        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        v_dal.LogCommand = True

        Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

        'Convert to XML to return
        Dim xml_serializer As New Xml.Serialization.XmlSerializer(v_ds.GetType)
        Dim string_writer As New StringWriter
        xml_serializer.Serialize(string_writer, v_ds)
        pv_strObjMsg = string_writer.ToString
        Complete() 'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Public Function GetTreeMenuByUser(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_XmlDocument As New Xml.XmlDocument
        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_strSQL, v_strAuthId, v_strTypeID, v_strClause As String
            v_XmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_XmlDocument.DocumentElement.Attributes
            v_strAuthId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            v_strTypeID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Xây dựng cây menu chức năng theo TellerID/GroupID
            If v_strAuthId = ADMIN_ID And v_strTypeID <> "G" Then
                'Lấy full cây chức năng
                v_strSQL = "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, " _
                            & "M.LAST, M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, 'YYYYY' STRAUTH, 'A' RIGHTSCOPE " & ControlChars.CrLf _
                            & "FROM VW_CMDMENU_ALL M WHERE M.LEV > 0 " _
                            & "ORDER BY M.ODRID "
            Else
                'Lấy cây chức năng theo phân quyền
                If v_strTypeID = "G" Then
                    'Cây chức năng của nhóm
                    v_strSQL = "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, " _
                                & "M.LAST, M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, M.STRAUTH, M.RIGHTSCOPE " & ControlChars.CrLf _
                                & "FROM " _
                                    & "(SELECT M.CMDID ODRID, M.CMDID CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, M.LAST,  " _
                                    & " (CASE WHEN M.LEV=1 THEN 0 ELSE (CASE WHEN M.LAST='Y' THEN 3 ELSE 1 END) END) IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, 'YYYYY' STRAUTH, 'A' RIGHTSCOPE " _
                                    & " FROM CMDMENU M WHERE M.LAST='N' AND M.LEV > 0 UNION ALL " _
                                    & "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, M.LAST,   " _
                                    & "M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, A.STRAUTH, A.RIGHTSCOPE " _
                                    & "FROM VW_CMDMENU_ALL M,  " _
                                        & "(SELECT A.CMDTYPE, A.CMDCODE, A.STRAUTH, 'A' RIGHTSCOPE   " _
                                        & "FROM CMDAUTH A WHERE A.AUTHTYPE='G' AND A.AUTHID='" & v_strAuthId & "' AND A.CMDALLOW='Y') A " _
                                    & "WHERE M.LAST='Y' AND (CASE WHEN M.MENUTYPE IN ('R','A','O','P') THEN 'M' ELSE M.MENUTYPE END) || M.CMDCODE = A.CMDTYPE || A.CMDCODE) M " _
                                & "ORDER BY M.ODRID "
                Else
                    'Cây chức năng theo User
                    v_strSQL = "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, " _
                                & "M.LAST, M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, MAX(SUBSTR(M.STRAUTH,1,1)) ||   MAX(SUBSTR(M.STRAUTH,2,1)) || MAX(SUBSTR(M.STRAUTH,3,1))  || MAX(SUBSTR(M.STRAUTH,4,1)) || MAX(SUBSTR(M.STRAUTH,5,1)) STRAUTH, M.RIGHTSCOPE " & ControlChars.CrLf _
                                & "FROM " _
                                    & "(SELECT M.CMDID ODRID, M.CMDID CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, M.LAST,  " _
                                    & " (CASE WHEN M.LEV=1 THEN 0 ELSE (CASE WHEN M.LAST='Y' THEN 3 ELSE 1 END) END) IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, 'YYYYY' STRAUTH, 'A' RIGHTSCOPE " _
                                    & " FROM CMDMENU M WHERE M.LAST='N' AND M.LEV > 0 UNION ALL " _
                                    & "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, M.LAST,   " _
                                    & "M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, A.STRAUTH, A.RIGHTSCOPE " _
                                    & "FROM VW_CMDMENU_ALL M,  " _
                                        & "(SELECT A.CMDTYPE, A.CMDCODE, A.STRAUTH, 'A' RIGHTSCOPE   " _
                                        & "FROM CMDAUTH A WHERE A.AUTHTYPE='U' AND A.AUTHID='" & v_strAuthId & "' AND A.CMDALLOW='Y' UNION ALL " _
                                        & "SELECT A.CMDTYPE, A.CMDCODE, A.STRAUTH, 'A' RIGHTSCOPE  " _
                                        & "FROM CMDAUTH A, TLGRPUSERS G  " _
                                        & "WHERE A.AUTHTYPE='G' AND A.AUTHID=G.GRPID AND A.CMDALLOW='Y' AND G.TLID='" & v_strAuthId & "') A " _
                                    & "WHERE M.LAST='Y' AND (CASE WHEN M.MENUTYPE IN ('R','A','O','P') THEN 'M' ELSE M.MENUTYPE END) || M.CMDCODE = A.CMDTYPE || A.CMDCODE) M " _
        & "GROUP BY M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, M.LAST, M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, CMDALLOW, M.AUTHCODE, M.RIGHTSCOPE " _
                                & "ORDER BY M.ODRID "
                End If
            End If

            'Trâ về dữ liệu cây MENU
            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "FLEX"
            v_bCmd.SQLCommand = v_strSQL
            v_dal.LogCommand = True
            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        Finally
            v_dal = Nothing
            v_XmlDocument = Nothing
        End Try
    End Function

    Public Function GetTreeMenuAll(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_XmlDocument As New Xml.XmlDocument
        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_strSQL As String
            v_strSQL = "SELECT M.ODRID, M.CMDCODE, M.CMDID, M.PRID, M.CMDNAME, M.EN_CMDNAME, M.LEV, " _
                        & "M.LAST, M.IMGINDEX, M.MODCODE, M.OBJNAME, M.MENUTYPE, 'Y' CMDALLOW, M.AUTHCODE, 'YYYYY' STRAUTH, 'A' RIGHTSCOPE " & ControlChars.CrLf _
                        & "FROM VW_CMDMENU_ALL_RPT M " _
                        & "ORDER BY M.ODRID "

            'Trâ về dữ liệu cây MENU
            Dim v_bCmd As New BusinessCommand
            v_bCmd.ExecuteUser = "FLEX"
            v_bCmd.SQLCommand = v_strSQL
            v_dal.LogCommand = True
            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        Finally
            v_dal = Nothing
            v_XmlDocument = Nothing
        End Try
    End Function
#End Region

#Region " Adhoc functions "
    'TungNT them vao, lay du lieu tu tren host , tra ve dang dataset, co nen
    Public Function GetHostData(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.GetHostData", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strSQL = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value).Replace("<![CDATA[", "").Replace("]]>", "")
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = String.Empty
                v_lngErrCode = ERR_SA_NO_DATAFOUND
            Else
                Dim v_st As New MemoryStream
                v_ds.WriteXml(v_st)
                Dim v_strXml As String = ZipString(Encoding.UTF8.GetString(v_st.ToArray()))
                CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = "<![CDATA[" & v_strXml & "]]>"
            End If
            pv_strObjMsg = v_xmlDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    'TungNT end

    Public Function ExecDBFunction(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecDBFunction", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strFUNCNAME As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
            Dim v_strPARAMETERS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTEMP, v_strRETURN As String

            v_strSQL = "SELECT " & v_strFUNCNAME & "(" & v_strPARAMETERS & ") AS RETVAL FROM DUAL"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = String.Empty
            Else
                Try
                    CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = CStr(v_ds.Tables(0).Rows(0)("RETVAL"))
                Catch ex As Exception
                    CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = String.Empty
                End Try
            End If
            pv_strObjMsg = v_xmlDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function MapExchangeStockTicker(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.MapExchangeStockTicker", v_strErrorMessage As String
        Dim v_strSQL, v_strTXDATE As String, v_ds As DataSet, v_DataAccess As New DataAccess, pv_xmlDocument As New Xml.XmlDocument
        Try
            'Map exchange order book to current order book
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Get data from stock exchange
            v_strSQL = "UPDATE SECURITIES_INFO " & ControlChars.CrLf _
                            & "SET TXDATE=TO_DATE(:TXDATE, '" & gc_FORMAT_DATE & "'),CURRPRICE=:CURRPRICE,BASICPRICE=:BASICPRICE, " & ControlChars.CrLf _
                            & "OPENPRICE=:OPENPRICE,CEILINGPRICE=:CEILINGPRICE,FLOORPRICE=:FLOORPRICE " & ControlChars.CrLf _
                            & "WHERE SYMBOL=:SYMBOL"

            Dim v_arrInquiryPara(6) As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "TXDATE"
            v_objInquiryParam.ParamValue = v_strTXDATE
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(0) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CURRPRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(1) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "BASICPRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(2) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "OPENPRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(3) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CEILINGPRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(4) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "FLOORPRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(5) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "SYMBOL"
            v_objInquiryParam.ParamSize = 50
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(6) = v_objInquiryParam

            Dim v_nodeList As Xml.XmlNodeList, i, j As Integer
            pv_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/StockTicker")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                For j = 1 To 6 Step 1
                    If v_arrInquiryPara(j).ParamType = "String" Or v_arrInquiryPara(j).ParamType = "Date" Then
                        v_arrInquiryPara(j).ParamValue =
                            v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim
                    Else
                        If IsNumeric(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim) Then
                            v_arrInquiryPara(j).ParamValue =
                                CDbl(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim) * 1000
                        Else
                            v_arrInquiryPara(j).ParamValue = 0
                        End If
                    End If
                Next
                v_DataAccess.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            Next

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not v_ds Is Nothing Then v_ds.Dispose()
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
            pv_xmlDocument = Nothing
        End Try
    End Function

    Public Function MapExchangeOrderBook(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.MapExchangeOrderBook", v_strErrorMessage As String
        Dim v_strSQL, v_strSQLMAP, v_strTXDATE As String, v_ds, v_dsCHECK As DataSet, v_DataAccess As New DataAccess, pv_xmlDocument As New Xml.XmlDocument
        Try
            'Map exchange order book to current order book
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Clean old data
            v_strSQL = "TRUNCATE TABLE STCORDERBOOKBUFFER DROP STORAGE "
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "TRUNCATE TABLE STCORDERBOOKTEMP  DROP STORAGE "
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Get data from stock exchange
            v_strSQL = "INSERT INTO STCORDERBOOKBUFFER (TXDATE, ORDERNUMBER, REFORDERNUMBER, CUSTODYCD, " _
                        & "SYMBOL, BSCA, NORP, ORDERTYPE, VOLUME, PRICE, TRADERID, MEMBERID, BOARD) VALUES (" _
                        & "TO_DATE(:TXDATE, '" & gc_FORMAT_DATE & "'), :ORDERNUMBER, :REFORDERNUMBER, :CUSTODYCD, " _
                        & ":SYMBOL, :BSCA, :NORP, :ORDERTYPE, :VOLUME, :PRICE, :TRADERID, :MEMBERID, :BOARD)"

            Dim v_arrInquiryPara(12) As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "TXDATE"
            v_objInquiryParam.ParamValue = v_strTXDATE
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(0) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "ORDERNUMBER"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(1) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "REFORDERNUMBER"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(2) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CUSTODYCD"
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(3) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "SYMBOL"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(4) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "BSCA"
            v_objInquiryParam.ParamSize = 1
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(5) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "NORP"
            v_objInquiryParam.ParamSize = 1
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(6) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "ORDERTYPE"
            v_objInquiryParam.ParamSize = 3
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(7) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "VOLUME"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(8) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "PRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(9) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "TRADERID"
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(10) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "MEMBERID"
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(11) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "BOARD"
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(12) = v_objInquiryParam

            Dim v_nodeList As Xml.XmlNodeList, i, j As Integer
            pv_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/OrderBook")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                For j = 1 To 12 Step 1
                    If v_arrInquiryPara(j).ParamType = "String" Or v_arrInquiryPara(j).ParamType = "Date" Then
                        v_arrInquiryPara(j).ParamValue =
                            v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim
                    Else
                        If IsNumeric(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim) Then
                            v_arrInquiryPara(j).ParamValue =
                                CDbl(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim)
                        Else
                            v_arrInquiryPara(j).ParamValue = 0
                        End If
                    End If
                Next
                If String.Compare(v_nodeList.Item(0).ChildNodes(i).Attributes("REFORDERNUMBER").InnerText.Substring(0, 2), "VS") = 0 Then
                    v_arrInquiryPara(9).ParamValue = v_arrInquiryPara(9).ParamValue * 1000
                End If
                v_DataAccess.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            Next

            'Ghi nhan cac lenh moi vao bang temp
            v_strSQL = "INSERT INTO STCORDERBOOKTEMP " _
                    & "SELECT * FROM STCORDERBOOKBUFFER S WHERE NOT EXISTS " _
                    & "(SELECT REFORDERNUMBER FROM STCORDERBOOK WHERE REFORDERNUMBER =S.REFORDERNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Thuc hien mapping so hieu lenh tu bang temp cho cac lenh chua duoc map.
            Dim v_strORDERID, v_strORDERNUMBER, v_strREFORDERNUMBER, v_strCUSTODYCD, v_strSYMBOL, v_strBSCA, v_strNORP, v_strORDERTYPE As String
            Dim v_dblVOLUME, v_dblPRICE As Double
            v_strSQL = "SELECT * FROM STCORDERBOOKTEMP"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Chuan bi cau lenh lay du lieu
                v_strSQL = "SELECT ORDERID FROM ODMAST MST, OOD, SBSECURITIES CD, AFMAST AF, CFMAST CF " & ControlChars.CrLf _
                    & "WHERE MST.CODEID=CD.CODEID AND MST.AFACCTNO=AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & ControlChars.CrLf _
                    & "AND MST.ORDERID=OOD.ORGORDERID AND OOD.DELTD<>'Y' AND OOD.OODSTATUS='S' " & ControlChars.CrLf _
                    & "AND CF.CUSTODYCD=:CUSTODYCD AND CD.SYMBOL=:SYMBOL " & ControlChars.CrLf _
                    & "AND MST.PRICETYPE=:ORDERTYPE AND MST.MATCHTYPE=:NORP " & ControlChars.CrLf _
                    & "AND (CASE WHEN (MST.EXECTYPE='NB' OR MST.EXECTYPE='BC') THEN 'B' WHEN (MST.EXECTYPE = 'NS' OR MST.EXECTYPE = 'MS') Then 'S' END)=:BSCA " & ControlChars.CrLf _
                    & "AND MST.ORDERQTTY=:VOLUME AND MST.QUOTEPRICE=(CASE WHEN MST.PRICETYPE<>'LO' THEN MST.QUOTEPRICE ELSE :PRICE END) " & ControlChars.CrLf _
                    & "AND  NOT EXISTS (SELECT ORDERID FROM STCORDERBOOK WHERE ORDERID = MST.ORDERID) " & ControlChars.CrLf _
                    & "ORDER BY MST.ORDERID"
                ReDim v_arrInquiryPara(6)

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "CUSTODYCD"
                v_objInquiryParam.ParamSize = 10
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(0) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "SYMBOL"
                v_objInquiryParam.ParamSize = 30
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(1) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "ORDERTYPE"
                v_objInquiryParam.ParamSize = 3
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(2) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "NORP"
                v_objInquiryParam.ParamSize = 1
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(3) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "BORS"
                v_objInquiryParam.ParamSize = 1
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(4) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "VOLUME"
                v_objInquiryParam.ParamSize = 30
                v_objInquiryParam.ParamType = "Double"
                v_arrInquiryPara(5) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "PRICE"
                v_objInquiryParam.ParamSize = 30
                v_objInquiryParam.ParamType = "Double"
                v_arrInquiryPara(6) = v_objInquiryParam

                'Mapping SQL
                Dim v_arrMapPara(1) As ReportParameters
                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "ORDERID"
                v_objInquiryParam.ParamSize = 30
                v_objInquiryParam.ParamType = "String"
                v_arrMapPara(0) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "REFORDERNUMBER"
                v_objInquiryParam.ParamSize = 30
                v_objInquiryParam.ParamType = "String"
                v_arrMapPara(1) = v_objInquiryParam

                v_strSQLMAP = "INSERT INTO STCORDERBOOK (ORDERID, TXDATE, ORDERNUMBER, REFORDERNUMBER, CUSTODYCD, " & ControlChars.CrLf _
                                & "SYMBOL, BSCA, NORP, ORDERTYPE, VOLUME, PRICE, TRADERID, MEMBERID, BOARD) " & ControlChars.CrLf _
                                & "SELECT :ORDERID, TXDATE, ORDERNUMBER, REFORDERNUMBER, CUSTODYCD, " & ControlChars.CrLf _
                                & "SYMBOL, BSCA, NORP, ORDERTYPE, VOLUME, PRICE, TRADERID, MEMBERID, BOARD " & ControlChars.CrLf _
                                & "FROM STCORDERBOOKTEMP WHERE REFORDERNUMBER=:REFORDERNUMBER"

                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strORDERNUMBER = CStr(v_ds.Tables(0).Rows(i)("ORDERNUMBER")).Trim
                    v_strREFORDERNUMBER = gf_CorrectStringField(CStr(v_ds.Tables(0).Rows(i)("REFORDERNUMBER")).Trim)
                    v_arrInquiryPara(0).ParamValue = CStr(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CUSTODYCD")).Trim)
                    v_arrInquiryPara(1).ParamValue = CStr(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SYMBOL")).Trim)
                    v_arrInquiryPara(2).ParamValue = CStr(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORDERTYPE")).Trim)
                    v_arrInquiryPara(3).ParamValue = CStr(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("NORP")).Trim)
                    v_arrInquiryPara(4).ParamValue = CStr(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("BSCA")).Trim)
                    v_arrInquiryPara(5).ParamValue = CDbl(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("VOLUME")))
                    v_arrInquiryPara(6).ParamValue = CDbl(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PRICE")))
                    v_dsCHECK = v_DataAccess.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
                    If v_dsCHECK.Tables(0).Rows.Count > 0 Then
                        v_arrMapPara(0).ParamValue = CStr(v_dsCHECK.Tables(0).Rows(0)(0)).Trim
                        v_arrMapPara(1).ParamValue = v_strREFORDERNUMBER
                        v_DataAccess.ExecuteSQLParametersReturnDataset(v_strSQLMAP, v_arrMapPara)
                    End If
                Next
            End If

            'Xoa di nhung lenh trong STCORDERBOOKTEMP ma da map duoc
            v_strSQL = "DELETE FROM STCORDERBOOKTEMP WHERE REFORDERNUMBER IN " _
                    & "(SELECT REFORDERNUMBER FROM STCORDERBOOK)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Xoa di nhung lenh trong STCORDERBOOKEXP ma khong xuat hien trong STCORDERBOOKTEMP
            v_strSQL = "DELETE FROM STCORDERBOOKEXP S WHERE  NOT EXISTS " _
                    & "(SELECT REFORDERNUMBER FROM STCORDERBOOKTEMP WHERE REFORDERNUMBER= S.REFORDERNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Day vao trong STCORDERBOOKEXP nhung lenh exception moi
            v_strSQL = "INSERT INTO STCORDERBOOKEXP SELECT * FROM STCORDERBOOKTEMP S WHERE  NOT EXISTS " _
                    & "(SELECT REFORDERNUMBER FROM STCORDERBOOKEXP WHERE REFORDERNUMBER=S.REFORDERNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not v_ds Is Nothing Then v_ds.Dispose()
            If Not v_dsCHECK Is Nothing Then v_dsCHECK.Dispose()
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
            pv_xmlDocument = Nothing
        End Try
    End Function

    Public Function MapExchangeTradeBook(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.MapExchangeTradeBook", v_strErrorMessage As String
        Dim v_strSQL, v_strTXDATE As String, v_DataAccess As New DataAccess, pv_xmlDocument As New Xml.XmlDocument
        Try
            'Map exchange order book to current order book
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Clean old data
            v_strSQL = "TRUNCATE TABLE STCTRADEBOOKBUFFER DROP STORAGE "
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "TRUNCATE TABLE STCTRADEBOOKTEMP DROP STORAGE "
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Get data from stock exchange
            v_strSQL = "INSERT INTO STCTRADEBOOKBUFFER (TXDATE, CONFIRMNUMBER, REFCONFIRMNUMBER, " _
                        & "ORDERNUMBER, BORS, VOLUME, PRICE) VALUES (" _
                        & "TO_DATE(:TXDATE, '" & gc_FORMAT_DATE & "'), :CONFIRMNUMBER, :REFCONFIRMNUMBER, " _
                        & ":ORDERNUMBER, :BORS, :VOLUME, :PRICE)"

            Dim v_arrInquiryPara(6) As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "TXDATE"
            v_objInquiryParam.ParamValue = v_strTXDATE
            v_objInquiryParam.ParamSize = 10
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(0) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CONFIRMNUMBER"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(1) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "REFCONFIRMNUMBER"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(2) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "ORDERNUMBER"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(3) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "BORS"
            v_objInquiryParam.ParamSize = 1
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(4) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "VOLUME"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(5) = v_objInquiryParam

            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "PRICE"
            v_objInquiryParam.ParamSize = 30
            v_objInquiryParam.ParamType = "Double"
            v_arrInquiryPara(6) = v_objInquiryParam

            Dim v_nodeList As Xml.XmlNodeList, i, j As Integer
            pv_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/TradeBook")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                For j = 1 To 6 Step 1
                    If v_arrInquiryPara(j).ParamType = "String" Or v_arrInquiryPara(j).ParamType = "Date" Then
                        v_arrInquiryPara(j).ParamValue =
                            v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim
                    Else
                        If IsNumeric(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim) Then
                            v_arrInquiryPara(j).ParamValue =
                                CDbl(v_nodeList.Item(0).ChildNodes(i).Attributes(v_arrInquiryPara(j).ParamName).InnerText.Trim)
                        Else
                            v_arrInquiryPara(j).ParamValue = 0
                        End If
                    End If
                Next
                If String.Compare(v_nodeList.Item(0).ChildNodes(i).Attributes("REFCONFIRMNUMBER").InnerText.Substring(0, 2), "VS") = 0 Then
                    v_arrInquiryPara(6).ParamValue = v_arrInquiryPara(6).ParamValue * 1000
                End If
                v_DataAccess.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            Next

            'Dua cac lenh moi vao bang ket qua khop lenh tam thoi.
            v_strSQL = "INSERT INTO STCTRADEBOOKTEMP " _
                    & "SELECT * FROM STCTRADEBOOKBUFFER S WHERE  NOT EXISTS " _
                    & "(SELECT REFCONFIRMNUMBER FROM STCTRADEBOOK WHERE REFCONFIRMNUMBER =S.REFCONFIRMNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat STCTRADEBOOK cho nhung lenh da duoc map (o bang STCORDERBOOK)
            v_strSQL = "INSERT INTO STCTRADEBOOK " _
                    & "SELECT * FROM STCTRADEBOOKTEMP WHERE SUBSTR(REFCONFIRMNUMBER,1,2) || ORDERNUMBER IN " _
                    & "(SELECT SUBSTR(REFORDERNUMBER,1,2) || ORDERNUMBER FROM STCORDERBOOK)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Xoa nhung DEAL trong STCTRADEBOOKTEMP ma co ban ghi trong STCTRADEBOOK
            v_strSQL = "DELETE FROM STCTRADEBOOKTEMP S WHERE EXISTS " _
                    & "(SELECT REFCONFIRMNUMBER FROM STCTRADEBOOK WHERE REFCONFIRMNUMBER=S.REFCONFIRMNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Xoa di nhung DEAL khop lenh trong STCTRADEBOOKEXP ma khong xuat hien trong STCTRADEBOOKTEMP
            v_strSQL = "DELETE FROM STCTRADEBOOKEXP S WHERE  NOT EXISTS " _
                    & "(SELECT REFCONFIRMNUMBER FROM STCTRADEBOOKTEMP WHERE REFCONFIRMNUMBER =S.REFCONFIRMNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Day vao trong STCORDERBOOKEXP nhung lenh exception moi
            v_strSQL = "INSERT INTO STCTRADEBOOKEXP SELECT * FROM STCTRADEBOOKTEMP S WHERE  NOT EXISTS " _
                    & "(SELECT REFCONFIRMNUMBER FROM STCTRADEBOOKEXP WHERE REFCONFIRMNUMBER=S.REFCONFIRMNUMBER)"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)


            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
            pv_xmlDocument = Nothing
        End Try
    End Function

    Public Function DeleteAutoGV(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.DeleteAutoGV", v_strErrorMessage As String

        Dim pv_xmlMessage As New Xml.XmlDocument
        Try
            pv_xmlMessage.LoadXml(pv_strObjMsg)
            'TÃ¡ÂºÂ¡o message
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlMessage.DocumentElement.Attributes
            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)

            Dim v_TXRouter As New txRouter
            v_lngErrCode = v_TXRouter.DeleteAutoGV(v_strTXDATE, v_strTXNUM)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Public Function AutoRunOTCGeneralView(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.AutoRunGeneralView", v_strErrorMessage As String
        Dim v_objTxRouter As New Host.txRouter
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_xmlTXMessage As New Xml.XmlDocument
        Dim mv_XMLBuffer As New Xml.XmlDocument
        Dim v_dataElement As Xml.XmlElement, v_entryNode, v_nodetxData As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTxdate, v_strTxnum As String
        Dim v_spmCaching As New spRouter
        Dim v_DataAccess As New DataAccess
        Dim mv_arrSEARCHFLD_FLDMASTER() As String
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL, v_strSQLMST, v_strSQLFLD, v_strSQLTLLOG As String, v_ds, v_dsMST, v_dsFLD, v_dsTLLOG, v_dsTime As DataSet
        Dim v_intMap, v_intMapCount As Integer, v_strTEMP, v_strMapFLDCD, v_strMapFIELDTYPE, v_strMapFIELDCODE As String
        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            Dim v_strSearchCode As String
            Dim v_strSQLMaster As String
            Dim v_lngROWPERPAGE As Long = 0
            Dim v_strTLTXCD, v_strCacheTLTXData As String, v_strCNTRECORD As Integer
            Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE, v_strFIELDCODE As String
            v_strSQL = "SELECT RPTID, ORD, ROWPERPAGE FROM RPTMASTER WHERE CMDTYPE='V' AND ISAUTO='A' AND STOREDNAME='OTC' ORDER BY ORD"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    'Voi moi generalview thuc hien map giao dich va thuc hien giao dich ay
                    v_strSearchCode = v_ds.Tables(0).Rows(i)("RPTID")
                    v_lngROWPERPAGE = v_ds.Tables(0).Rows(i)("ROWPERPAGE")
                    v_strSQLMST = "SELECT SEARCHCMDSQL, TLTXCD, NVL(CNTRECORD,'0') CNTRECORD FROM SEARCH WHERE SEARCHCODE='" & v_strSearchCode & "'"
                    v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLMST)
                    'Lay trong SEARCH ra cau lenh SQL de map va giao dich duoc MAP vao.
                    If v_dsMST.Tables(0).Rows.Count > 0 Then
                        v_strSQLMaster = v_dsMST.Tables(0).Rows(0)("SEARCHCMDSQL")
                        v_strTLTXCD = v_dsMST.Tables(0).Rows(0)("TLTXCD")
                        v_strCNTRECORD = v_dsMST.Tables(0).Rows(0)("CNTRECORD")
                        If CInt(v_strCNTRECORD) > 0 Then
                            v_strSQLMaster = " SELECT  * FROM (" & v_strSQLMaster & ") WHERE  ROWNUM <= " & CInt(v_strCNTRECORD)
                        End If

                        'Lay cache khung giao dich
                        v_strCacheTLTXData = v_spmCaching.TLTXGetPropertyValue(v_strTLTXCD)
                        If v_strCacheTLTXData.Length > 0 Then
                            mv_XMLBuffer.LoadXml(v_strCacheTLTXData)
                            v_strCacheTLTXData = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText
                        End If

                        'Lay bang MAP giua ket qua tim kiem voi giao dich: SEARCHFLD -> FLDMASTER
                        v_strSQLTLLOG = "SELECT FLDCD, FIELDTYPE, FIELDCODE FROM SEARCHFLD WHERE SEARCHCODE='" & v_strSearchCode & "'"
                        v_dsTLLOG = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTLLOG)
                        v_intMapCount = v_dsTLLOG.Tables(0).Rows.Count
                        If v_intMapCount > 0 Then
                            'Dataset TLLOG se luu truong nao trong du lieu duoc map voi field code nao trong giao dich
                            'Vi field code la 02 ky tu so nen se map FLDCD + FIELDCODE
                            ReDim mv_arrSEARCHFLD_FLDMASTER(v_intMapCount - 1)
                            For v_intMap = 0 To v_intMapCount - 1
                                v_strTEMP = gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FLDCD")).Trim
                                If v_strTEMP.Length = 0 Then v_strTEMP = "##"
                                v_strTEMP = v_strTEMP & gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FIELDTYPE")).Trim
                                v_strTEMP = v_strTEMP & gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FIELDCODE")).Trim()
                                mv_arrSEARCHFLD_FLDMASTER(v_intMap) = v_strTEMP
                            Next
                        End If

                        'Voi cau SQL khai bao trong search, fill vao dataset de lay gia tri
                        v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTxdate)
                        v_dsFLD = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLMaster)
                        If v_dsFLD.Tables(0).Rows.Count > 0 Then
                            For k As Integer = 0 To v_dsFLD.Tables(0).Rows.Count - 1
                                'TAO GIAO DICH
                                'Get HostTime for transact
                                v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
                                Dim v_strHostTime As String
                                v_dsTime = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsTime.Tables(0).Rows.Count > 0 Then
                                    v_strHostTime = v_dsTime.Tables(0).Rows(0)("TXTIME")
                                Else
                                    v_strHostTime = "00:00:00"
                                End If
                                If v_strCacheTLTXData.Length > 0 Then
                                    v_strTxnum = GV_PREFIXED & Right(gc_FORMAT_GENERALVIEWTXNUm & CStr(v_DataAccess.GetIDValue("GENERALVIEWTXNUM")), Len(gc_FORMAT_GENERALVIEWTXNUm) - Len(GV_PREFIXED))
                                    v_xmlTXMessage.LoadXml(v_strCacheTLTXData)
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxnum
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxdate
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strHostTime
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "GV"
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
                                Else
                                    v_lngErrCode = BuildGeneralViewTxMsg(v_xmlTXMessage, "GV")
                                End If
                                v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD

                                'Voi moi dong, se Map thanh mot giao dich de thuc hien.
                                'Su dung mang mv_arrSEARCHFLD_FLDMASTER de map giao dich
                                For v_intMap = 0 To v_intMapCount - 1
                                    v_strTEMP = mv_arrSEARCHFLD_FLDMASTER(v_intMap)
                                    v_strMapFLDCD = v_strTEMP.Substring(0, 2)
                                    v_strMapFIELDTYPE = v_strTEMP.Substring(2, 1)
                                    v_strMapFIELDCODE = v_strTEMP.Substring(3)
                                    If v_strMapFLDCD <> "##" Then
                                        'Set value
                                        Select Case v_strMapFIELDTYPE
                                            Case "C"
                                                v_strVALUE = gf_CorrectStringField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                                v_strVALUE = Replace(v_strVALUE, ".", "")
                                            Case "D"
                                                v_strVALUE = Strings.Right("00" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Day, 2) _
                                                & Strings.Right("00" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Month, 2) _
                                                & Strings.Right("0000" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Year, 4)
                                            Case "N"
                                                v_strVALUE = gf_CorrectNumericField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                            Case Else
                                                v_strVALUE = gf_CorrectStringField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                        End Select
                                        v_nodetxData = v_xmlTXMessage.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strMapFLDCD & "']")
                                        If Not v_nodetxData Is Nothing Then
                                            v_nodetxData.InnerText = v_strVALUE
                                        End If
                                    End If
                                Next

                                'Ghi nhan vao trong tllog
                                v_lngErrCode = v_objMessageLog.TransLog(v_xmlTXMessage)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return v_lngErrCode
                                End If

                                'Sau khi ghi nhan se doc len de thuc hien giao dich
                                v_strTxnum = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                                v_strTxdate = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString

                                Dim v_TXRouter As New txRouter
                                v_lngErrCode = v_TXRouter.ExecuteGVTxMessage(v_strTxdate, v_strTxnum)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    '   Return v_lngErrCode
                                End If
                                If v_lngROWPERPAGE > 0 Then
                                    If k > v_lngROWPERPAGE Then
                                        'Neu qua so luong ban ghi thi dung view nay lai, chuyen qua view khac thuc hien
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
        End Try
    End Function

    Public Function AutoRunGeneralView(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.AutoRunGeneralView", v_strErrorMessage As String
        Dim v_objTxRouter As New Host.txRouter
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_xmlTXMessage As New Xml.XmlDocument
        Dim mv_XMLBuffer As New Xml.XmlDocument
        Dim v_dataElement As Xml.XmlElement, v_entryNode, v_nodetxData As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTxdate, v_strTxnum As String
        Dim v_spmCaching As New spRouter
        Dim v_DataAccess As New DataAccess
        Dim mv_arrSEARCHFLD_FLDMASTER() As String
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL, v_strSQLMST, v_strSQLFLD, v_strSQLTLLOG As String, v_ds, v_dsMST, v_dsFLD, v_dsTLLOG, v_dsTime As DataSet
        Dim v_intMap, v_intMapCount As Integer, v_strTEMP, v_strMapFLDCD, v_strMapFIELDTYPE, v_strMapFIELDCODE As String
        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            Dim v_strSearchCode As String
            Dim v_strSQLMaster As String
            Dim v_lngROWPERPAGE As Long = 0
            Dim v_strTLTXCD, v_strCacheTLTXData As String, v_strCNTRECORD As Integer
            Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE, v_strFIELDCODE As String
            v_strSQL = "SELECT RPTID, ORD, ROWPERPAGE FROM RPTMASTER WHERE CMDTYPE='V' AND ISAUTO='A'  AND STOREDNAME<>'OTC'  ORDER BY ORD"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    'Voi moi generalview thuc hien map giao dich va thuc hien giao dich ay
                    v_strSearchCode = v_ds.Tables(0).Rows(i)("RPTID")
                    v_lngROWPERPAGE = v_ds.Tables(0).Rows(i)("ROWPERPAGE")
                    v_strSQLMST = "SELECT SEARCHCMDSQL, TLTXCD, NVL(CNTRECORD,'0') CNTRECORD FROM SEARCH WHERE SEARCHCODE='" & v_strSearchCode & "'"
                    v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLMST)
                    'Lay trong SEARCH ra cau lenh SQL de map va giao dich duoc MAP vao.
                    If v_dsMST.Tables(0).Rows.Count > 0 Then
                        v_strSQLMaster = v_dsMST.Tables(0).Rows(0)("SEARCHCMDSQL")
                        v_strTLTXCD = v_dsMST.Tables(0).Rows(0)("TLTXCD")
                        v_strCNTRECORD = v_dsMST.Tables(0).Rows(0)("CNTRECORD")
                        If CInt(v_strCNTRECORD) > 0 Then
                            v_strSQLMaster = " SELECT  * FROM (" & v_strSQLMaster & ") WHERE  ROWNUM <= " & CInt(v_strCNTRECORD)
                        End If

                        'Lay cache khung giao dich
                        v_strCacheTLTXData = v_spmCaching.TLTXGetPropertyValue(v_strTLTXCD)
                        If v_strCacheTLTXData.Length > 0 Then
                            mv_XMLBuffer.LoadXml(v_strCacheTLTXData)
                            v_strCacheTLTXData = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText
                        End If

                        'Lay bang MAP giua ket qua tim kiem voi giao dich: SEARCHFLD -> FLDMASTER
                        v_strSQLTLLOG = "SELECT FLDCD, FIELDTYPE, FIELDCODE FROM SEARCHFLD WHERE SEARCHCODE='" & v_strSearchCode & "'"
                        v_dsTLLOG = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTLLOG)
                        v_intMapCount = v_dsTLLOG.Tables(0).Rows.Count
                        If v_intMapCount > 0 Then
                            'Dataset TLLOG se luu truong nao trong du lieu duoc map voi field code nao trong giao dich
                            'Vi field code la 02 ky tu so nen se map FLDCD + FIELDCODE
                            ReDim mv_arrSEARCHFLD_FLDMASTER(v_intMapCount - 1)
                            For v_intMap = 0 To v_intMapCount - 1
                                v_strTEMP = gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FLDCD")).Trim
                                If v_strTEMP.Length = 0 Then v_strTEMP = "##"
                                v_strTEMP = v_strTEMP & gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FIELDTYPE")).Trim
                                v_strTEMP = v_strTEMP & gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(v_intMap)("FIELDCODE")).Trim()
                                mv_arrSEARCHFLD_FLDMASTER(v_intMap) = v_strTEMP
                            Next
                        End If

                        'Voi cau SQL khai bao trong search, fill vao dataset de lay gia tri
                        v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTxdate)
                        v_dsFLD = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLMaster)
                        If v_dsFLD.Tables(0).Rows.Count > 0 Then
                            For k As Integer = 0 To v_dsFLD.Tables(0).Rows.Count - 1
                                'TAO GIAO DICH
                                'Get HostTime for transact
                                v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
                                Dim v_strHostTime As String
                                v_dsTime = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsTime.Tables(0).Rows.Count > 0 Then
                                    v_strHostTime = v_dsTime.Tables(0).Rows(0)("TXTIME")
                                Else
                                    v_strHostTime = "00:00:00"
                                End If
                                If v_strCacheTLTXData.Length > 0 Then
                                    v_strTxnum = GV_PREFIXED & Right(gc_FORMAT_GENERALVIEWTXNUm & CStr(v_DataAccess.GetIDValue("GENERALVIEWTXNUM")), Len(gc_FORMAT_GENERALVIEWTXNUm) - Len(GV_PREFIXED))
                                    v_xmlTXMessage.LoadXml(v_strCacheTLTXData)
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxnum
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxdate
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strHostTime
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "GV"
                                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
                                Else
                                    v_lngErrCode = BuildGeneralViewTxMsg(v_xmlTXMessage, "GV")
                                End If
                                v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD

                                'Voi moi dong, se Map thanh mot giao dich de thuc hien.
                                'Su dung mang mv_arrSEARCHFLD_FLDMASTER de map giao dich
                                For v_intMap = 0 To v_intMapCount - 1
                                    v_strTEMP = mv_arrSEARCHFLD_FLDMASTER(v_intMap)
                                    v_strMapFLDCD = v_strTEMP.Substring(0, 2)
                                    v_strMapFIELDTYPE = v_strTEMP.Substring(2, 1)
                                    v_strMapFIELDCODE = v_strTEMP.Substring(3)
                                    If v_strMapFLDCD <> "##" Then
                                        'Set value
                                        Select Case v_strMapFIELDTYPE
                                            Case "C"
                                                v_strVALUE = gf_CorrectStringField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                                v_strVALUE = Replace(v_strVALUE, ".", "")
                                            Case "D"
                                                v_strVALUE = Strings.Right("00" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Day, 2) _
                                                & Strings.Right("00" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Month, 2) _
                                                & Strings.Right("0000" & gf_CorrectDateField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE)).Year, 4)
                                            Case "N"
                                                v_strVALUE = gf_CorrectNumericField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                            Case Else
                                                v_strVALUE = gf_CorrectStringField(v_dsFLD.Tables(0).Rows(k)(v_strMapFIELDCODE))
                                        End Select
                                        v_nodetxData = v_xmlTXMessage.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strMapFLDCD & "']")
                                        If Not v_nodetxData Is Nothing Then
                                            v_nodetxData.InnerText = v_strVALUE
                                        End If
                                    End If
                                Next

                                'Ghi nhan vao trong tllog
                                v_lngErrCode = v_objMessageLog.TransLog(v_xmlTXMessage)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return v_lngErrCode
                                End If

                                'Sau khi ghi nhan se doc len de thuc hien giao dich
                                v_strTxnum = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                                v_strTxdate = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString

                                Dim v_TXRouter As New txRouter
                                v_lngErrCode = v_TXRouter.ExecuteGVTxMessage(v_strTxdate, v_strTxnum)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    '   Return v_lngErrCode
                                End If
                                If v_lngROWPERPAGE > 0 Then
                                    If k > v_lngROWPERPAGE Then
                                        'Neu qua so luong ban ghi thi dung view nay lai, chuyen qua view khac thuc hien
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
        End Try
    End Function

    Public Function CoreBankExecute(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function ExecuteExternalJobs(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreExec(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strCmdInquiry As String
        Dim v_strCmdType As String
        Dim v_strReference As String
        Dim v_obj As DataAccess
        Dim v_lngErrCode As String

        Dim v_strSQL As String

        Try
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
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY) Is Nothing) Then
                v_strCmdInquiry = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
            Else
                v_strCmdInquiry = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDTYPE) Is Nothing) Then
                v_strCmdType = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDTYPE), Xml.XmlAttribute).Value)
            Else
                v_strCmdType = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            If v_strCmdType = gc_CommandProcedurE Then
                'Cau truy van truyen vao dang CommandProcedure, khong truyen tham so dau vao
                Dim v_arrStrClause() As String
                Dim v_objRptParam As StoreParameter
                Dim v_arrRptPara() As StoreParameter
                v_arrStrClause = v_strClause.Split("^")
                ReDim v_arrRptPara(v_arrStrClause.GetLength(0) - 1)
                For i As Integer = 0 To v_arrStrClause.GetLength(0) - 1
                    Dim v_arrStrParam() As String = v_arrStrClause(i).Split("!")
                    v_objRptParam = New StoreParameter
                    v_objRptParam.ParamName = IIf(v_arrStrParam(0) Is Nothing, "", v_arrStrParam(0))
                    v_objRptParam.ParamValue = IIf(v_arrStrParam(1) Is Nothing, "", v_arrStrParam(1))
                    v_objRptParam.ParamSize = IIf(v_arrStrParam(3) Is Nothing, 0, v_arrStrParam(3))
                    v_objRptParam.ParamType = IIf(v_arrStrParam(2) Is Nothing, "", v_arrStrParam(2))
                    v_arrRptPara(i) = v_objRptParam
                Next
                ReDim Preserve v_arrRptPara(v_arrStrClause.GetLength(0) - 1)
                v_strSQL = v_strCmdInquiry
                v_lngErrCode = v_obj.ExecuteOracleStored(v_strSQL, v_arrRptPara, v_arrStrClause.GetLength(0) - 1)

            End If


            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function BranchExecute(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.BranchExecute", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_obj As txRouter
        Dim v_nodeList As Xml.XmlNodeList, v_xmlDocument As New Xml.XmlDocument
        Dim v_strTLTXCD, v_strTXDATE, v_strBCHMDL, v_strAPPTYPE, v_strBATCHNAME, v_strRUNMOD, v_strLastRun As String, i, j, k, intPos As Integer
        Dim v_intMaxRow As Integer = 0
        Dim v_ds, v_dsTMP As DataSet
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_strFillter As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeCLAUSE).Value.ToString)
            v_strTXDATE = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString)
            Dim v_strIsBeforeBatch As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeRESERVER).Value.ToString)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_IntCurrRow As Integer = CInt(Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value.ToString))
            'KiÃ¡Â»Æ’m tra chÃ¡Â»â€° cho phÃƒÂ©p chÃ¡ÂºÂ¡y Batch nÃ¡ÂºÂ¿u HOST Ã„â€˜ang Ã¡Â»Å¸ trÃ¡ÂºÂ¡ng thÃƒÂ¡i OPERATION_INACTIVE
            Dim v_strSYSVAR As String

            'trung.luu: 07-04-2020 đóng cửa chi nhánh,đóng cửa hội sở trong txpks_batch

            'v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            'If v_lngErrCode <> ERR_SYSTEM_OK Then
            '    Rollback() 'ContextUtil.SetAbort()
            '    Return v_lngErrCode
            'End If
            If Not v_strIsBeforeBatch = "True" Then
                'If v_strSYSVAR <> OPERATION_INACTIVE Then
                '    Rollback() 'ContextUtil.SetAbort()
                '    Return ERR_SA_HOST_OPERATION_STILLACTIVE
                'Else
                'v_strSQL = "SELECT BRID, BRNAME FROM BRGRP WHERE STATUS='" & BRGRP_ACTIVE & "'"
                'v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    Rollback() 'ContextUtil.SetAbort()
                '    Return ERR_SA_STILLHAS_BRGRP_ACTIVE
                'End If
                'End trung.luu: 07-04-2020
                'Kiem tra xem con giao dich nao o trang thai chua duyet, chua cachier, dang duyet xoa cua nhung giao dich hoach toan truoc luc duyet.
                v_strSQL = "select txnum from tllog where deltd <> 'Y' and txstatus in ('4','7','3')"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Con giao dich Pending, thong bao loi
                    Rollback() 'ContextUtil.SetAbort()
                    Return "-100148"
                End If
                'End If
            Else
                If v_strSYSVAR <> OPERATION_INACTIVE Then
                    v_DataAccess.SetSysVar("SYSTEM", "HOSTATUS", OPERATION_INACTIVE)
                End If
            End If

            'Thuc hien cac buoc chay Batch theo danh sach duoc goi
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'LÃ¡ÂºÂ¥y tÃƒÂªn BATCHNAME cÃ¡ÂºÂ§n chÃ¡ÂºÂ¡y
                            v_strBATCHNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            intPos = InStr(v_strBATCHNAME, ".")
                            v_strAPPTYPE = Mid(v_strBATCHNAME, 1, intPos - 1)
                            v_strBCHMDL = Mid(v_strBATCHNAME, intPos + 1)

                            v_strSQL = "select count(1) from ( " & ControlChars.CrLf _
                                        & "select * from ( " & ControlChars.CrLf _
                                        & "select sts.bchmdl, ctl.bchsqn " & ControlChars.CrLf _
                                        & "from sbbatchsts sts, sbbatchctl ctl  " & ControlChars.CrLf _
                                        & "where sts.bchdate = (select max(bchdate) from sbbatchsts) " & ControlChars.CrLf _
                                        & "and sts.bchmdl = ctl.bchmdl and ctl.status = 'Y' and sts.bchsts <> 'Y' and sts.cmpltime is null " & ControlChars.CrLf _
                                        & "order by bchsqn ) " & ControlChars.CrLf _
                                        & "where rownum = 1) " & ControlChars.CrLf _
                                        & "where bchmdl = '" & v_strBCHMDL.Trim & "' "
                            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows(0)(0) <> 1 Then
                                Return ERR_BATCH_PROCESS_FOLLOW_SEQUENCE
                            End If


                            Try
                                v_strSQL = "SELECT RUNMOD FROM SBBATCHCTL WHERE BCHMDL='" & v_strBCHMDL.Trim & "'"
                                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                v_strRUNMOD = v_ds.Tables(0).Rows(0)("RUNMOD")
                            Catch ex As Exception
                                v_strRUNMOD = "NET"
                            End Try
                            If v_strRUNMOD = "DB" Then
                                v_obj = New txRouter
                                v_lngErrCode = v_obj.DBBatch(v_strAPPTYPE, v_strBCHMDL, v_strLastRun)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    'Co loi thi rollback va thoat
                                    Rollback()
                                    Return v_lngErrCode
                                End If
                                If v_strLastRun = "Y" Then
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = -1
                                Else
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = 9000000000
                                End If
                                pv_strObjMsg = v_xmlDocument.InnerXml
                            Else
                                'Ã„?ÃƒÂ¡nh dÃ¡ÂºÂ¥u xoÃƒÂ¡ cÃƒÂ¡c giao dÃ¡Â»â€¹ch cÃ…Â©
                                v_strSQL = "UPDATE TLLOG SET DELTD='Y' WHERE TXSTATUS <> '1' AND BATCHNAME='" & v_strBCHMDL.Trim & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                                'ThÃ¡Â»Â±c hiÃ¡Â»â€¡n chÃ¡ÂºÂ¡y Batch
                                v_obj = New txRouter
                                v_lngErrCode = v_obj.Batch(v_strAPPTYPE, v_strBCHMDL, v_strFillter, v_intMaxRow)
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_intMaxRow.ToString
                                pv_strObjMsg = v_xmlDocument.InnerXml
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                    Return v_lngErrCode
                                Else
                                    'CÃ¡ÂºÂ­p nhÃ¡ÂºÂ­t bÃ†Â°Ã¡Â»â€ºc chÃ¡ÂºÂ¡y batch thÃƒÂ nh cÃƒÂ´ng
                                    If v_IntCurrRow = -1 Then
                                        'KhÃƒÂ´ng phÃƒÂ¢n trang
                                        If v_strIsBeforeBatch = "True" AndAlso v_strBCHMDL = "SAAFINDAYPROCESS" Then
                                            v_DataAccess.SetSysVar("SYSTEM", "HOSTATUS", OPERATION_ACTIVE)
                                        End If
                                        v_strSQL = "UPDATE SBBATCHSTS SET BCHSTS = 'Y', CMPLTIME = SYSDATE,BCHSUCPAGE=" & v_IntCurrRow & " WHERE UPPER(BCHMDL) = '" & v_strBCHMDL & "' AND BCHDATE=(SELECT MAX(BCHDATE) FROM SBBATCHSTS) "
                                        v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Else
                                        'PhÃƒÂ¢n trang
                                        If v_IntCurrRow >= v_intMaxRow Then
                                            'LÃƒÂ  trang cuÃ¡Â»â€˜i
                                            If v_strIsBeforeBatch = "True" AndAlso v_strBCHMDL = "SAAFINDAYPROCESS" Then
                                                v_DataAccess.SetSysVar("SYSTEM", "HOSTATUS", OPERATION_ACTIVE)
                                            End If
                                            v_strSQL = "UPDATE SBBATCHSTS SET BCHSTS = 'Y', CMPLTIME = SYSDATE,BCHSUCPAGE=" & v_IntCurrRow & " WHERE UPPER(BCHMDL) = '" & v_strBCHMDL & "' AND BCHDATE=(SELECT MAX(BCHDATE) FROM SBBATCHSTS) "
                                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                        Else
                                            'KhÃƒÂ´ng lÃƒÂ  trang cuÃ¡Â»â€˜i
                                            v_strSQL = "UPDATE SBBATCHSTS SET BCHSUCPAGE=" & v_IntCurrRow & " WHERE UPPER(BCHMDL) = '" & v_strBCHMDL & "' AND BCHDATE=(SELECT MAX(BCHDATE) FROM SBBATCHSTS) "
                                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                        End If
                                    End If
                                End If
                            End If
                        End With
                    Next
                    If v_strRUNMOD <> "DB" Then
                        'Kiem tra neu giao dich trong Batch co tao bang ke thi goi ham xu ly yeu cau tao bang ke luon
                        v_strSQL = "SELECT DISTINCT LG.TLTXCD FROM TLLOG LG, CRBTXMAP RF" & vbCrLf &
                                    "WHERE LG.TLTXCD=RF.OBJNAME AND RF.OBJTYPE='T' AND LG.DELTD<>'Y'" & vbCrLf &
                                    "AND LG.TXSTATUS='1' AND TRIM(LG.BATCHNAME)='" & v_strBCHMDL.Trim & "'"
                        'End
                        v_dsTMP = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_dsTMP.Tables(0).Rows.Count > 0 Then
                            Dim v_objParam As New StoreParameter
                            For k = 0 To v_dsTMP.Tables(0).Rows.Count - 1
                                v_strTLTXCD = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(k)("TLTXCD"))
                                'Goi ham tao bang ke truyen TXDATE=NULL de hieu la ngay lam viec hien tai
                                Dim v_arrPara(2) As StoreParameter
                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_err_code"
                                v_objParam.ParamValue = "0"
                                v_objParam.ParamDirection = ParameterDirection.Output
                                v_objParam.ParamSize = 10
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(0) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_tltxcd"
                                v_objParam.ParamValue = v_strTLTXCD
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamSize = 10
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(1) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_txdate"
                                v_objParam.ParamValue = ""
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamSize = 10
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(2) = v_objParam

                                v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.SP_EXEC_CREATE_CRBTXREQ_TLTXCD", v_arrPara, 0)
                                v_strSQL = String.Empty
                            Next
                        End If
                        'End
                    End If

                Next
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function BranchDeActive(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.BranchDeActive", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ds As DataSet
        Try
            v_strSQL = "select txnum from tllog where deltd <> 'Y' and txstatus in ('4','7','3')"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Con giao dich Pending, thong bao loi
                Rollback() 'ContextUtil.SetAbort()
                Return "-100148"
            End If
            v_strSQL = "SELECT * FROM ODMAST A, (SELECT * FROM ODMAPEXT WHERE DELTD <> 'Y' AND STATUS <> 'Y' ORDER BY ORDERID) B, SBSECURITIES C, AFMAST D, CFMAST E , SECURITIES_INFO F " & ControlChars.CrLf _
                        & "WHERE A.ORDERID = B.ORDERID AND A.CODEID=C.CODEID AND D.ACCTNO=A.AFACCTNO AND D.CUSTID=E.CUSTID AND A.CODEID=F.CODEID AND A.exectype ='NS' and A.matchtype='P' and A.grporder='Y'and A.deltd<>'Y'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Con giao dich Pending, thong bao loi
                Rollback() 'ContextUtil.SetAbort()
                Return "-100722"
            End If
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            v_strSQL = "UPDATE BRGRP SET STATUS='" & BRGRP_CLOSED & "' WHERE BRID='" & Trim(v_strBRID) & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ResetCacheProcessing(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ResetCacheProcessing", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_spmCaching As New spRouter
            v_spmCaching.ResetCache()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function BranchActive(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.BranchActive", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strSYSVAR As String

            'KiÃ¡Â»Æ’m tra chÃ¡Â»â€° cho phÃƒÂ©p Active branch nÃ¡ÂºÂ¿u HOST Ã„â€˜ÃƒÂ£ Active
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            Else
                'CÃ¡ÂºÂ­p nhÃ¡ÂºÂ­t lÃ¡ÂºÂ¡i trÃ¡ÂºÂ¡ng thÃƒÂ¡i cÃ¡Â»Â§a chi nhÃƒÂ¡nh
                v_strSQL = "UPDATE BRGRP SET STATUS='" & BRGRP_ACTIVE & "' WHERE BRID='" & Trim(v_strBRID) & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'TrÃ¡ÂºÂ£ vÃ¡Â»? ngÃƒÂ y lÃƒÂ m viÃ¡Â»â€¡c hiÃ¡Â»â€¡n tÃ¡ÂºÂ¡i cÃ¡Â»Â§a hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
                v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strSYSVAR)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = v_strSYSVAR
                v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "NEXTDATE", v_strSYSVAR)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value = v_strSYSVAR
                pv_strObjMsg = v_xmlDocument.InnerXml

            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Public Function HostDeActive(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.HostDeActive", v_strErrorMessage As String
        Dim v_strSQL, v_strREFERENCE As String, v_ds As DataSet, v_DataAccess As New DataAccess

        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            Dim v_xmlDocument As New Xml.XmlDocument
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes

            'KiÃ¡Â»Æ’m tra khÃƒÂ´ng cho phÃƒÂ©p DeActive HeadOffice nÃ¡ÂºÂ¿u cÃƒÂ¡c Branch vÃ¡ÂºÂ«n chÃ†Â°a DeActive hÃ¡ÂºÂ¿t
            v_strSQL = "SELECT BRID, BRNAME FROM BRGRP WHERE STATUS='" & BRGRP_ACTIVE & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strREFERENCE = vbNullString
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strREFERENCE = v_strREFERENCE & "@" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("BRID")))
                Next
                CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = v_strREFERENCE
                pv_strObjMsg = v_xmlDocument.InnerXml
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_STILLHAS_BRGRP_ACTIVE
            End If
            'ThÃ¡Â»Â±c hiÃ¡Â»â€¡n DeActive
            Dim v_strSYSVAR As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            If v_strSYSVAR = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            Else
                'CÃ¡ÂºÂ­p nhÃ¡ÂºÂ­t trÃ¡ÂºÂ¡ng thÃƒÂ¡i Ã¡Â»Å¸ BDS
                v_lngErrCode = v_DataAccess.SetSysVar("SYSTEM", "HOSTATUS", OPERATION_INACTIVE)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function HostActive(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.HostActive", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess

        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            Dim v_strSYSVAR As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR = OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_STILLACTIVE
            Else
                'CÃ¡ÂºÂ­p nhÃ¡ÂºÂ­t trÃ¡ÂºÂ¡ng thÃƒÂ¡i Ã¡Â»Å¸ HeadOffice
                v_lngErrCode = v_DataAccess.SetSysVar("SYSTEM", "HOSTATUS", OPERATION_ACTIVE)

                'CÃ¡ÂºÂ­p nhÃ¡ÂºÂ­t lÃ¡ÂºÂ¡i trÃ¡ÂºÂ¡ng thÃƒÂ¡i cho cac bÃ†Â°Ã¡Â»â€ºc Batch khÃƒÂ´ng Ã„â€˜Ã†Â°Ã¡Â»Â£c chÃ¡ÂºÂ¡y
                Dim v_strCURRDATE As String
                v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                Dim v_obj As New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
                Dim v_strSQL As String
                v_strSQL = "UPDATE SBBATCHSTS SET BCHSTS='N' WHERE BCHSTS = ' ' AND BCHDATE < TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Ngay 20/10/2019 NamTv them goi thuc cat tien dang ky mua CK quyen 
                'Dim pv_Error_Message_CA3384 As String
                'ExecuteCA3384(pv_Error_Message_CA3384)
                'If pv_Error_Message_CA3384 <> ERR_SYSTEM_OK Then
                '    Return pv_Error_Message_CA3384
                'End If
                'Ngay 20/10/2019 NamTv End
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function GetInventory(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.GetInventory", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Dim v_strSQL As String, XMLDocument As New Xml.XmlDocument
        Dim v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_strSYSVAR As String
        Dim v_strGetInitNumber As String
        Dim v_iRefLength As Integer

        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "COMPANYCD", v_strSYSVAR)

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            'Ã„?ÃƒÂ¢y lÃƒÂ  tÃƒÂªn cÃ¡Â»Â§a Inventory
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strREFERENCE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            v_iRefLength = v_strREFERENCE.Length()

            'Select Case v_strClause
            '    Case "CUSTID"
            '        'LÃ¡ÂºÂ¥y mÃƒÂ£ khÃƒÂ¡ch hÃƒÂ ng cÃƒÂ²n cÃƒÂ³ thÃ¡Â»Æ’ sÃ¡Â»Â­ dÃ¡Â»Â¥ng cÃ¡Â»Â§a tÃ¡Â»Â«ng BRID
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,4), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT CUSTID INVACCT FROM CFMAST WHERE SUBSTR(CUSTID,1,4)='" & v_strBRID & "' ORDER BY CUSTID) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,5,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,4)"

            '    Case "CAMASTID"
            '        'Láº¥y sá»‘ hiá»‡u láº§n thá»±c hiá»‡n quyá»?n
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,10), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT CAMASTID INVACCT FROM CAMAST WHERE SUBSTR(CAMASTID,1,10)='" & v_strREFERENCE & "' ORDER BY CAMASTID) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,11,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,10)"

            '    Case "CITYPE", "ODTYPE", "SETYPE", "AFTYPE", "RPTYPE", "FOTYPE", "CLTYPE", "LNTYPE", "DDTYPE", "MRTYPE", "MTTYPE", "PRTYPE"
            '        'Lay TYPE nho nhat thoa man chua co trong loai hinh
            '        v_strSQL = " SELECT  NVL(MAX(ODR)+1,1) AUTOINV FROM  " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT  " & ControlChars.CrLf _
            '            & "FROM (SELECT actype INVACCT FROM " & v_strClause & "  ORDER BY actype) DAT  " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(INVACCT)=ROWNUM) INVTAB "

            '    Case "CUSTODYCD"
            '        'LÃ¡ÂºÂ¥y sÃ¡Â»â€˜ tÃƒÂ i khoÃ¡ÂºÂ£n lÃ†Â°u kÃƒÂ½ cÃƒÂ²n cÃƒÂ³ thÃ¡Â»Æ’ sÃ¡Â»Â­ dÃ¡Â»Â¥ng theo mÃƒÂ£ cÃ¡Â»Â§a cÃƒÂ´ng ty
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,4), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT CUSTODYCD INVACCT FROM CFMAST WHERE SUBSTR(CUSTODYCD,1,4)='" & v_strSYSVAR & "C' AND TRIM(TO_CHAR(TRANSLATE(SUBSTR(CUSTODYCD,5,6),'0123456789',' '))) IS NULL ORDER BY CUSTODYCD) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,5,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,4)"

            '    Case "AFACCTNO"
            '        'LÃ¡ÂºÂ¥y sÃ¡Â»â€˜ hÃ¡Â»Â£p Ã„â€˜Ã¡Â»â€œng cÃƒÂ²n cÃƒÂ³ thÃ¡Â»Æ’ sÃ¡Â»Â­ dÃ¡Â»Â¥ng cÃ¡Â»Â§a tÃ¡Â»Â«ng BRID
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,4), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM AFMAST WHERE SUBSTR(ACCTNO,1,4)='" & v_strBRID & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,5,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,4)"

            '    Case "TDACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,12), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM TDMAST WHERE SUBSTR(ACCTNO,1,12)='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,12)"

            '    Case "SDACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,12), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM SDMAST WHERE SUBSTR(ACCTNO,1,12)='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,12)"

            '    Case "REACCTNO"
            '        'Lay so tieu khoan RE
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,4), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM REMAST WHERE SUBSTR(ACCTNO,1,4)='" & v_strBRID & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,5,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,4)"

            '    Case "GRACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM GRMAST WHERE SUBSTR(ACCTNO,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "LMACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM LMMAST WHERE SUBSTR(ACCTNO,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "LAACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM LAMAST WHERE SUBSTR(ACCTNO,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "LAASSEST"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1,16), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM LAASSEST WHERE SUBSTR(ACCTNO,1,16)='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,17,2))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1,16)"

            '    Case "CLACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM CLMAST WHERE SUBSTR(ACCTNO,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,4))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "LNAPPLID"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT APPLID INVACCT FROM LNAPPL WHERE SUBSTR(APPLID,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY APPLID) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,13,3))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "LNACCTNO"
            '        'Lay so tai khoan han muc
            '        v_strSQL = "SELECT SUBSTR(INVACCT,1," & v_iRefLength & "), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ACCTNO INVACCT FROM LNMAST WHERE SUBSTR(ACCTNO,1," & v_iRefLength & ")='" & v_strREFERENCE & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(SUBSTR(INVACCT,16,3))=ROWNUM) INVTAB " & ControlChars.CrLf _
            '            & "GROUP BY SUBSTR(INVACCT,1," & v_iRefLength & ")"

            '    Case "OPTCODEID"
            '        v_strSQL = "SELECT	 MAX (nvl(invacct,0)), MAX (nvl(odr,0)) + 1 autoinv " & ControlChars.CrLf _
            '            & "FROM	 (SELECT   ROWNUM odr, invacct " & ControlChars.CrLf _
            '            & "FROM   (  SELECT   invacct " & ControlChars.CrLf _
            '            & "FROM   (  SELECT   codeid invacct FROM sbsecurities WHERE substr(codeid,1,1)=9 UNION ALL SELECT '900001' FROM dual) " & ControlChars.CrLf _
            '            & "ORDER BY   invacct) dat " & ControlChars.CrLf _
            '            & "WHERE   substr(invacct,2,5) = ROWNUM) invtab "

            '    Case "SEQ_ODMAST", "SEQ_DFMAST", "SEQ_WITHDRAWN"
            '        v_strSQL = "SELECT " & v_strClause & ".NEXTVAL AUTOINV FROM DUAL"
            '    Case "ISSUERID"
            '        'LÃ¡ÂºÂ¥y mÃƒÂ£ khÃƒÂ¡ch hÃƒÂ ng cÃƒÂ²n cÃƒÂ³ thÃ¡Â»Æ’ sÃ¡Â»Â­ dÃ¡Â»Â¥ng cÃ¡Â»Â§a tÃ¡Â»Â«ng BRID
            '        v_strSQL = "SELECT MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT ISSUERID INVACCT FROM ISSUERS  ORDER BY ISSUERID) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(INVACCT)=ROWNUM) INVTAB " & ControlChars.CrLf
            '    Case "CODEID"
            '        'LÃ¡ÂºÂ¥y mÃƒÂ£ khÃƒÂ¡ch hÃƒÂ ng cÃƒÂ²n cÃƒÂ³ thÃ¡Â»Æ’ sÃ¡Â»Â­ dÃ¡Â»Â¥ng cÃ¡Â»Â§a tÃ¡Â»Â«ng BRID
            '        v_strSQL = "SELECT MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT CODEID INVACCT FROM SBSECURITIES  ORDER BY CODEID) DAT " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(INVACCT)=ROWNUM) INVTAB " & ControlChars.CrLf
            '    Case "POTXNUM"
            '        v_strSQL = "SELECT NVL(MAX(INVACCT)+1,1) AUTOINV FROM " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
            '            & "FROM (SELECT SUBSTR(TXNUM,5,6) INVACCT FROM POMAST WHERE BRID='" & v_strBRID & "' ORDER BY TXNUM) DAT " & ControlChars.CrLf _
            '            & ") INVTAB " & ControlChars.CrLf
            '    Case "PRMASTER"
            '        v_strSQL = " SELECT  NVL(MAX(ODR)+1,1) AUTOINV FROM  " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT  " & ControlChars.CrLf _
            '            & "FROM (SELECT prcode INVACCT FROM " & v_strClause & "  ORDER BY prcode) DAT  " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(INVACCT)=ROWNUM) INVTAB "
            '    Case "BANKNOSTRO"
            '        v_strSQL = " SELECT  NVL(MAX(ODR)+1,1) AUTOINV FROM  " & ControlChars.CrLf _
            '            & "(SELECT ROWNUM ODR, INVACCT  " & ControlChars.CrLf _
            '            & "FROM (SELECT SHORTNAME INVACCT FROM " & v_strClause & "  ORDER BY SHORTNAME) DAT  " & ControlChars.CrLf _
            '            & "WHERE TO_NUMBER(INVACCT)=ROWNUM) INVTAB "
            'End Select

            ''KiÃ¡Â»Æ’m tra Sequence Ã„â€˜ÃƒÂ£ tÃ¡Â»â€œn tÃ¡ÂºÂ¡i chÃ†Â°a
            'v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 0 Then
            '    CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = "1"
            'Else
            '    CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
            'End If


            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters

            ReDim v_arrRptPara(4)

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "CLAUSE"
            v_objRptParam.ParamValue = v_strClause
            v_objRptParam.ParamSize = v_strClause.Length
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
            v_objRptParam.ParamValue = v_strSYSVAR
            v_objRptParam.ParamSize = v_strSYSVAR.Length
            v_objRptParam.ParamType = "String"
            v_arrRptPara(2) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "RefLength"
            v_objRptParam.ParamValue = v_iRefLength
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(3) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "REFERENCE"
            v_objRptParam.ParamValue = v_strREFERENCE
            v_objRptParam.ParamSize = v_strREFERENCE.Length
            v_objRptParam.ParamType = "String"
            v_arrRptPara(4) = v_objRptParam


            v_ds = v_DataAccess.ExecuteStoredReturnDataset("SP_GetInventory", v_arrRptPara)
            If v_ds.Tables(0).Rows.Count = 0 Then
                CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = "1"
            Else
                CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
            End If

            'TrÃ¡ÂºÂ£ vÃ¡Â»? kÃ¡ÂºÂ¿t quÃ¡ÂºÂ£
            pv_strObjMsg = XMLDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function GetSystemTime(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.GetSystemTime", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            'GetLocalTime(st)

            v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            v_xmlDocument.LoadXml(pv_strObjMsg)

            If v_ds.Tables(0).Rows.Count > 0 Then
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeCLAUSE).Value = v_ds.Tables(0).Rows(0)("TXTIME")
            Else
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeCLAUSE).Value = "00:00:00"
            End If

            pv_strObjMsg = v_xmlDocument.InnerXml

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CheckTradeBuySell(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CheckTradeBuySell", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet, v_dsext As DataSet
        Dim v_strTRADEBUYSELL, v_strEXECTYPE, v_strTXDATE, v_strAFACCTNO, v_strCODEID As String
        Dim v_strFLDCD, v_strFLDTYPE, v_strVALUE, v_dblVALUE As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)

            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData/Entry")


            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            'v_strTXDATE = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            For i As Integer = 0 To v_nodeList.Count - 1
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "22" 'EXECTYPE
                            v_strEXECTYPE = v_strVALUE

                    End Select
                End With
            Next


            'Kienvt sua ham trim
            'v_strSQL = "SELECT * FROM SECURITIES_INFO WHERE TRIM(CODEID)='" & v_strCODEID & "'"
            v_strSQL = "SELECT * FROM SECURITIES_INFO WHERE CODEID='" & v_strCODEID & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            v_strTRADEBUYSELL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEBUYSELL"))
            If v_strTRADEBUYSELL = "N" Then
                If v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC" Then
                    'Kienvt sua bo ham trim
                    'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO) IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                    '  & "AND (EXECTYPE='NS' OR EXECTYPE='SS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE CODEID='" & v_strCODEID & "' AND AFACCTNO IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                       & "AND (EXECTYPE='NS' OR EXECTYPE='SS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')   AND REMAINQTTY+EXECQTTY>0  "
                Else
                    'Kienvt sua ham trim
                    'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO) IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                    '    & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE CODEID='" & v_strCODEID & "' AND AFACCTNO IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                         & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')   AND REMAINQTTY+EXECQTTY>0  "
                End If

                v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("CNT")) > 0 Then
                    'BÃ¡o lá»—i khÃ´ng thá»ƒ cÃ¹ng mua cÃ¹ng bÃ¡n má»™t chá»©ng khoÃ¡n trong cÃ¹ng má»™t ngÃ y
                    v_lngErrCode = ERR_OD_BUYSELL_SAME_SECURITIES
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Sub LogOrderMessage(ByRef OrderID As String)
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_strSQL As String
            'Log vao messagebus
            v_strSQL = "INSERT INTO BUSTXLOG (AUTOID,TLTXCD,REFTYPE,REFKEY,TBLNAME,QUEUENAME,TXDATE,TXNUM,MSGBODY) " & ControlChars.CrLf _
            & " VALUES (SEQ_BUSTXLOG.NEXTVAL,'9999','000','ORDERID','ODMAST','QUEUEDEF','01/01/2001','0000000000', " & ControlChars.CrLf _
            & " 'SELECT * FROM ( v_busOrderStatus ) ODMAST  WHERE ORDERID=''" & OrderID & "''') " & ControlChars.CrLf
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception
        Finally
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
        End Try

    End Sub

    Public Function SendOrderToCompany(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.SendOrderToCompany", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds As DataSet, v_xmlDocument As New Xml.XmlDocument
        Dim v_strRunMOD As String
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "FO2ODMOD", v_strRunMOD)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                v_strRunMOD = "NET"
            End If
            If v_strRunMOD = "DB" Then
                v_lngErrCode = DBSendOrderToCompany()
            Else
                v_lngErrCode = NETSendOrderToCompany(pv_strObjMsg)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
        End Try
    End Function

    Public Function DBSendOrderToCompany() As Long
        Try
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_DataAccess.ExecuteNonQuery(CommandType.Text, "Begin txpks_auto.pr_fo2od; end;")
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function NETSendOrderToCompany(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.NETSendOrderToCompany", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds, v_dsTemp, v_dsTLLOG, v_dsMST As DataSet, v_objMessageLog As New MessageLog, v_xmlDocument As New Xml.XmlDocument
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strFLDVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim j As Integer
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_blnOK As Boolean = True
        Dim v_strTLTXCD As String
        Dim v_strEXECTYPE, v_strORGEXECTYPE As String
        Dim v_strOLDEXECTYPE As String
        Dim v_strCMDSQL As String
        Dim v_strVIA As String
        Dim v_strCLEARCD As String
        Dim v_strTIMETYPE As String
        Dim v_strPRICETYPE As String
        Dim v_strMATCHTYPE As String
        Dim v_strTRADEPLACE As String
        Dim v_strSECTYPE As String
        Dim v_strPARVALUE As String
        Dim v_strNORK As String
        Dim v_strTRADELOT As String
        Dim v_strTRADEUNIT As String
        Dim v_strAFACCTNO As String
        Dim v_strDFACCTNO As String
        Dim v_strCODEID As String
        Dim v_strSYMBOL As String
        Dim v_strQUOTEPRICE As String
        Dim v_strQUANTITY As String
        Dim v_strACTYPE As String
        Dim v_strTXTIME As String
        Dim v_strCLEARDAY As String
        Dim v_strCUSTODYCD As String
        Dim v_strFULLNAME As String
        Dim mv_dblSecureBratioMin, mv_dblSecureBratioMax, mv_dblTyp_Bratio, mv_dblAF_Bratio, mv_dblFeeAmountMin, mv_dblFeeRate As Double
        Dim mv_strACTYPE As String
        Dim v_dblSecureRatio, v_dblFeeSecureRatioMin As Double
        Dim v_dblFeeAmout As Double
        Dim v_strOrderID As String
        Dim v_strORGACCTNO As String
        Dim v_strREFACCTNO As String
        Dim v_strREFQUANTITY As String
        Dim v_strREFPRICE As String
        Dim v_dblCeilPrice As Double
        Dim v_dblFloorPrice As Double
        Dim v_dblMarginPrice As Double
        Dim v_dblAdvanceSecuredAmount As Double
        Dim v_spmCaching As New spRouter, mv_XMLBuffer As New Xml.XmlDocument, v_nodeData As Xml.XmlNode, v_strCacheTLTXData As String
        Dim v_strTLID As String
        Dim v_strPuttype As String
        Dim v_strMarginType As String = "N"
        Dim v_dblMarginRatioRate As Double = 0
        Dim v_dblSecMarginPrice As Double = 0
        Dim v_dblIsPPUsed As Double = 1
        Try
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "FOUSER", v_strTLID)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Kiá»ƒm tra chá»‰ cho phÃ©p cháº¡y Batch náº¿u BDS Ä‘Ã£ InActive
            Dim v_strSYSVAR, v_strSQL, v_strTXDATE, v_strTXNUM, v_strMSGID, v_strTxMsg As String
            Dim v_strHoseBreakingSize As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Lay TXDATE
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Lay HOSE breaking size
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSEBREAKSIZE", v_strHoseBreakingSize)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Lay ATC start time
            Dim v_strATCStartTime As String = "000000"
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "ATCSTARTTIME", v_strATCStartTime)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If Not v_strSYSVAR = OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            Else
                v_strSQL = "SELECT MST.*,INF.CEILINGPRICE,INF.FLOORPRICE,INF.MARGINPRICE,SEC.TRADEPLACE,SEC.SECTYPE,SEC.PARVALUE,INF.TRADELOT,INF.TRADEUNIT,INF.SECUREDRATIOMIN,INF.SECUREDRATIOMAX FROM FOMAST MST,SBSECURITIES SEC,SECURITIES_INFO INF " _
                & " WHERE MST.BOOK='A' AND MST.TIMETYPE <> 'G' AND MST.STATUS='P' AND MST.CODEID=SEC.CODEID AND MST.CODEID=INF.CODEID AND ROWNUM BETWEEN 1 AND (SELECT TO_NUMBER(TRIM(VARVALUE)) FROM SYSVAR WHERE VARNAME ='ODSENDSIZE')"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                        v_blnOK = True
                        'I. Create standart message
                        '-----------------------
                        '1.Xac dinh giao dich tuong ung
                        v_strVIA = IIf(v_ds.Tables(0).Rows(i)("VIA") Is Nothing, "T", v_ds.Tables(0).Rows(i)("VIA")) 'Tam thoi lay la Tele
                        v_strCLEARCD = v_ds.Tables(0).Rows(i)("CLEARCD")
                        v_strTIMETYPE = v_ds.Tables(0).Rows(i)("TIMETYPE")
                        v_strPRICETYPE = v_ds.Tables(0).Rows(i)("PRICETYPE")
                        v_strMATCHTYPE = v_ds.Tables(0).Rows(i)("MATCHTYPE")
                        v_strTRADEPLACE = v_ds.Tables(0).Rows(i)("TRADEPLACE")
                        v_strSECTYPE = v_ds.Tables(0).Rows(i)("SECTYPE")
                        v_strPARVALUE = v_ds.Tables(0).Rows(i)("PARVALUE")
                        v_strNORK = v_ds.Tables(0).Rows(i)("NORK")
                        v_strTRADELOT = v_ds.Tables(0).Rows(i)("TRADELOT")
                        v_strTRADEUNIT = v_ds.Tables(0).Rows(i)("TRADEUNIT")
                        v_strAFACCTNO = v_ds.Tables(0).Rows(i)("AFACCTNO")
                        v_strCODEID = v_ds.Tables(0).Rows(i)("CODEID")
                        v_strSYMBOL = v_ds.Tables(0).Rows(i)("SYMBOL")
                        v_strQUOTEPRICE = v_ds.Tables(0).Rows(i)("QUOTEPRICE")
                        v_strQUANTITY = v_ds.Tables(0).Rows(i)("QUANTITY")
                        v_strEXECTYPE = v_ds.Tables(0).Rows(i)("EXECTYPE")
                        mv_dblSecureBratioMin = v_ds.Tables(0).Rows(i)("SECUREDRATIOMIN")
                        mv_dblSecureBratioMax = v_ds.Tables(0).Rows(i)("SECUREDRATIOMAX")
                        v_strORGACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGACCTNO"))
                        v_strREFACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFACCTNO"))
                        v_strREFQUANTITY = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFQUANTITY"))
                        v_strREFPRICE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFPRICE"))
                        v_dblCeilPrice = v_ds.Tables(0).Rows(i)("CEILINGPRICE")
                        v_dblFloorPrice = v_ds.Tables(0).Rows(i)("FLOORPRICE")
                        v_dblMarginPrice = v_ds.Tables(0).Rows(i)("MARGINPRICE")
                        v_strDFACCTNO = v_ds.Tables(0).Rows(i)("DFACCTNO")
                        v_strORGEXECTYPE = v_strEXECTYPE
                        v_strOLDEXECTYPE = v_strEXECTYPE
                        v_strPuttype = "O" ' Mac dinh
                        If v_ds.Tables(0).Columns.Contains("PUTTYPE") Then
                            v_strPuttype = v_ds.Tables(0).Rows(i)("PUTTYPE")
                        End If
                        Select Case v_strEXECTYPE
                            Case "NB"
                                v_strTLTXCD = gc_OD_PLACENORMALBUYORDER_ADVANCEd
                                v_strEXECTYPE = "NB"
                            Case "NS", "MS", "SS"
                                v_strTLTXCD = gc_OD_PLACENORMALSELLORDER_ADVANCEd
                                v_strEXECTYPE = v_strEXECTYPE
                            Case "AB"
                                v_strTLTXCD = gc_OD_AMENDMENTBUYORDER
                                'v_strEXECTYPE = "NB"
                            Case "AS"
                                v_strTLTXCD = gc_OD_AMENDMENTSELLORDER
                                'v_strEXECTYPE = "NS"
                            Case "CB"
                                v_strTLTXCD = gc_OD_CANCELBUYORDER
                                'v_strEXECTYPE = "NB"
                            Case "CS"
                                v_strTLTXCD = gc_OD_CANCELSELLORDER
                                'v_strEXECTYPE = "NS"
                        End Select
                        If v_strREFACCTNO.Trim.Length > 0 Then 'lENH HUY SUA
                            v_strSQL = "SELECT EXECTYPE  FROM FOMAST WHERE ORGACCTNO='" & v_strREFACCTNO & "'"
                            v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsMST.Tables(0).Rows.Count > 0 Then
                                v_strEXECTYPE = v_dsMST.Tables(0).Rows(0)("EXECTYPE")
                            End If
                        End If
                        'Lay lai gio he thong
                        v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24MISS') SYSTEMTIME FROM DUAL"
                        v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        Dim v_strSystemTime As String = v_dsMST.Tables(0).Rows(0)("SYSTEMTIME")
                        'Xac dinh trang thai thi truong xem la phien 1,2 or 3
                        v_strSQL = "SELECT SYSVALUE  FROM ORDERSYS WHERE SYSNAME='CONTROLCODE'"
                        v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        Dim v_strMarketStatus As String
                        v_strMarketStatus = v_dsMST.Tables(0).Rows(0)("SYSVALUE")
                        'v_strMarketStatus=P: 8h30-->9h00 phien 1 ATO
                        'v_strMarketStatus=O: 9h00-->10h15 phien 2 MP
                        'v_strMarketStatus=A: 10h15-->10h30 phien 3 ATC
                        If v_strPRICETYPE <> "LO" Then
                            If v_strPRICETYPE = "ATO" Then
                                If v_strMarketStatus = "O" Or v_strMarketStatus = "A" Then
                                    v_lngErrCode = ERR_SA_INVALID_SECSSION
                                    'Cap nhat trang thai tro lai FOMAST
                                    v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    'Log vao messagebus
                                    LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                                    v_blnOK = False
                                End If
                            End If
                            If v_strPRICETYPE = "ATC" Then
                                If v_strMarketStatus = "A" Then
                                ElseIf v_strMarketStatus = "O" And v_strSystemTime >= v_strATCStartTime Then
                                Else
                                    v_lngErrCode = ERR_SA_INVALID_SECSSION
                                    v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                                    'Cap nhat trang thai tro lai FOMAST
                                    v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    'Log vao messagebus
                                    LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                                    v_blnOK = False
                                End If
                            End If

                            If v_strPRICETYPE = "MO" Then
                                If v_strMarketStatus <> "O" Then
                                    v_lngErrCode = ERR_SA_INVALID_SECSSION
                                    'Cap nhat trang thai tro lai FOMAST
                                    v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    'Log vao messagebus
                                    LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                                    v_blnOK = False
                                End If
                            End If
                        ElseIf v_strTRADEPLACE = "001" Then 'Lenh limit San Hose
                            ''Lenh LO, check lenh huy
                            'v_strSQL = "SELECT HOSESESSION FROM ODMAST WHERE ORDERID='" & v_strORGACCTNO & "'"
                            'v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'If v_dsMST.Tables(0).Rows.Count > 0 Then
                            '    'La lenh huy, sua
                            '    Dim v_strOrderSession = v_dsMST.Tables(0).Rows(0)("HOSESESSION")
                            '    If v_strOrderSession <> v_strMarketStatus And v_strOrderSession <> "N" Then
                            '        v_lngErrCode = ERR_SA_INVALID_SECSSION
                            '        'Cap nhat trang thai tro lai FOMAST
                            '        v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                            '        v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            '    End If
                            'End If
                        End If

                        If v_strPRICETYPE <> "LO" Then
                            If v_strEXECTYPE = "NB" Then
                                v_strQUOTEPRICE = v_dblCeilPrice / v_strTRADEUNIT
                            Else
                                v_strQUOTEPRICE = v_dblFloorPrice / v_strTRADEUNIT
                            End If
                        End If

                        '3.Xac dinh cac thong tin lien quan den lenh
                        'v_strSQL = "SELECT MST.BRATIO, CF.CUSTODYCD,CF.FULLNAME,MST.ACTYPE FROM AFMAST MST, CFMAST CF WHERE ACCTNO='" & v_strAFACCTNO & "' AND MST.CUSTID=CF.CUSTID"
                        v_strCMDSQL = "SELECT MST.BRATIO, CF.CUSTODYCD,CF.FULLNAME,MST.ACTYPE,MRT.MRTYPE,MRT.ISPPUSED, " & ControlChars.CrLf _
                                    & " NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(MRPRICELOAN,0) MRPRICELOAN  " & ControlChars.CrLf _
                                    & " FROM AFMAST MST, CFMAST CF ,AFTYPE AFT, MRTYPE MRT, " & ControlChars.CrLf _
                                    & " (SELECT * FROM AFSERISK WHERE CODEID='" & v_strCODEID & "' ) RSK  " & ControlChars.CrLf _
                                    & " WHERE MST.ACCTNO='" & v_strAFACCTNO & "' AND MST.CUSTID=CF.CUSTID " & ControlChars.CrLf _
                                    & " and mst.actype =aft.actype and aft.mrtype = mrt.actype " & ControlChars.CrLf _
                                    & " AND AFT.ACTYPE =RSK.ACTYPE(+)"
                        v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strCMDSQL)
                        If v_dsMST.Tables(0).Rows.Count > 0 Then
                            v_strMarginType = v_dsMST.Tables(0).Rows(0)("MRTYPE")
                            v_dblMarginRatioRate = v_dsMST.Tables(0).Rows(0)("MRRATIOLOAN")
                            v_dblSecMarginPrice = v_dsMST.Tables(0).Rows(0)("MRPRICELOAN")
                            v_dblIsPPUsed = v_dsMST.Tables(0).Rows(0)("ISPPUSED")
                            v_strCUSTODYCD = v_dsMST.Tables(0).Rows(0)("CUSTODYCD")
                            v_strFULLNAME = v_dsMST.Tables(0).Rows(0)("FULLNAME")
                            mv_dblAF_Bratio = v_dsMST.Tables(0).Rows(0)("BRATIO")
                            mv_strACTYPE = v_dsMST.Tables(0).Rows(0)("ACTYPE")
                            If v_dblMarginRatioRate >= 100 Or v_dblMarginRatioRate < 0 Then v_dblMarginRatioRate = 0
                            v_dblSecMarginPrice = IIf(v_dblMarginPrice > v_dblSecMarginPrice, v_dblSecMarginPrice, v_dblMarginPrice)
                        End If

                        '2.Xac dinh loai hinh lenh tuong ung
                        v_strCMDSQL = "SELECT ACTYPE, CLEARDAY, " & ControlChars.CrLf _
                                & " TYPENAME DESCRIPTION, TRADELIMIT, BRATIO, MINFEEAMT, DEFFEERATE,to_char(sysdate,'HH:MI:SS') TXTIME FROM ODTYPE " & ControlChars.CrLf _
                                & " WHERE STATUS='Y' AND ( VIA='" & v_strVIA & "'OR VIA = 'A') " & ControlChars.CrLf _
                                & " AND CLEARCD='" & v_strCLEARCD & "' " & ControlChars.CrLf _
                                & " AND (EXECTYPE='" & v_strEXECTYPE & "' OR EXECTYPE='AA') " & ControlChars.CrLf _
                                & " AND (TIMETYPE='" & v_strTIMETYPE & "' OR TIMETYPE='A' )" & ControlChars.CrLf _
                                & " AND (PRICETYPE='" & v_strPRICETYPE & "' OR PRICETYPE='AA') " & ControlChars.CrLf _
                                & " AND (MATCHTYPE='" & v_strMATCHTYPE & "' OR MATCHTYPE='A')" & ControlChars.CrLf _
                                & " AND (TRADEPLACE='" & v_strTRADEPLACE & "' OR TRADEPLACE='000')" & ControlChars.CrLf _
                                & " AND (INSTR(CASE WHEN '" & v_strSECTYPE & "' IN ('001','002') THEN '" & v_strSECTYPE & "' || ',111,333'" & ControlChars.CrLf _
                                & "                 WHEN '" & v_strSECTYPE & "' IN ('003','006') THEN '" & v_strSECTYPE & "' || ',222,333,444'" & ControlChars.CrLf _
                                & "                 WHEN '" & v_strSECTYPE & "' IN ('008') THEN '" & v_strSECTYPE & "' || ',111,444'" & ControlChars.CrLf _
                                & "                 ELSE '" & v_strSECTYPE & "' END, SECTYPE) > 0 OR SECTYPE = '000')" & ControlChars.CrLf _
                                & " AND (NORK='" & v_strNORK & "' OR NORK ='A')" & ControlChars.CrLf _
                                & " AND ACTYPE IN (SELECT ACTYPE FROM REGTYPE WHERE MODCODE='OD' AND AFTYPE = '" & mv_strACTYPE & "')"
                        v_dsTemp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strCMDSQL)
                        If Not (v_dsTemp.Tables(0).Rows.Count > 0) Then
                            v_lngErrCode = ERR_OD_ODTYPE_NOTFOUND
                            v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                            'Cap nhat trang thai tro lai FOMAST
                            v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_ds.Tables(0).Rows(i)("ACCTNO") & " :[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            'Log vao messagebus
                            LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                            v_blnOK = False
                        Else
                            v_strACTYPE = v_dsTemp.Tables(0).Rows(0)("ACTYPE")
                            v_strCLEARDAY = v_dsTemp.Tables(0).Rows(0)("CLEARDAY")
                            mv_dblTyp_Bratio = v_dsTemp.Tables(0).Rows(0)("BRATIO")
                            mv_dblFeeAmountMin = v_dsTemp.Tables(0).Rows(0)("MINFEEAMT")
                            mv_dblFeeRate = v_dsTemp.Tables(0).Rows(0)("DEFFEERATE")
                            v_strTXTIME = v_dsTemp.Tables(0).Rows(0)("TXTIME")
                        End If

                        'v_lngErrCode = BuildFOTxMsg(v_xmlDocument)
                        'v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                        'v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'v_strTXDATE = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
                        '4.Xac dinh ty le ky quy theo loai hinh
                        '--------------------
                        If v_strMarginType = "S" Or v_strMarginType = "T" Or v_strMarginType = "N" Then
                            'Voi tai khoan Margin yeu cau ky quy 100% gia tri
                            'Voi tai khoan binh thuong se ky quy 100%
                            v_dblSecureRatio = 100
                        ElseIf v_strMarginType = "L" Then
                            v_strCMDSQL = "select nvl(dfrate,0) dfrate from (select df.* from dfbasket df, sbsecurities sb where df.symbol = sb.symbol and sb.codeid ='" & v_strCODEID & "') bk, aftype aft, dftype dft, afmast af where af.actype = aft.actype and aft.dftype = dft.actype and dft.basketid = bk.basketid (+) and af.acctno ='" & v_strAFACCTNO & "'"
                            v_dsTemp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strCMDSQL)
                            If Not (v_dsTemp.Tables(0).Rows.Count > 0) Then
                                v_dblSecureRatio = 100
                            Else
                                v_dblSecureRatio = Math.Max(100 - v_dsTemp.Tables(0).Rows(0)("DFRATE"), 0)
                            End If
                        Else
                            'Gia tri lenh ky quy theo loai hinh
                            v_dblSecureRatio = Math.Max(Math.Min(mv_dblTyp_Bratio + mv_dblAF_Bratio, 100), mv_dblSecureBratioMin)
                            v_dblSecureRatio = CDec(IIf(v_dblSecureRatio > mv_dblSecureBratioMax, mv_dblSecureBratioMax, v_dblSecureRatio))
                        End If

                        'Cá»™ng thÃªm kÃ½ quá»¹ cho phÃ­ giao dá»‹ch theo loáº¡i hÃ¬nh lá»‡nh
                        v_dblFeeSecureRatioMin = mv_dblFeeAmountMin * 100 / (CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * CDbl(v_strTRADEUNIT))
                        If v_dblFeeSecureRatioMin > mv_dblFeeRate Then
                            v_dblSecureRatio += v_dblFeeSecureRatioMin
                        Else
                            v_dblSecureRatio += mv_dblFeeRate
                        End If
                        '--------------------
                        '5. Voi lenh sua, xac dinh pham phai ky quy them
                        v_dblAdvanceSecuredAmount = 0
                        If CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * v_dblSecureRatio / 100 - CDbl(v_strREFPRICE) * CDbl(v_strREFQUANTITY) * v_dblSecureRatio / 100 > 0 Then
                            v_dblAdvanceSecuredAmount = (CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * CDbl(v_dblSecureRatio) / 100 - CDbl(v_strREFPRICE) * CDbl(v_strREFQUANTITY) * v_dblSecureRatio / 100)
                        Else
                            v_dblAdvanceSecuredAmount = "0"
                        End If
                        '---------------------------------------
                        'Tach lenh HOse neu lon hon v_strHoseBreakingSize
                        Dim v_dblCount As Integer = 0
                        Dim v_strSendQuantity As String
                        While CDbl(v_strQUANTITY) > 0
                            v_dblCount = v_dblCount + 1
                            If v_strTRADEPLACE = "001" Then 'San HO
                                v_strSendQuantity = IIf(CDbl(v_strQUANTITY) > CDbl(v_strHoseBreakingSize), v_strHoseBreakingSize, v_strQUANTITY)
                            Else 'San khac thi khong tach lenh
                                v_strSendQuantity = v_strQUANTITY
                            End If
                            '6.Lay so hieu lenh
                            v_strOrderID = FO_PREFIXED & "00" & Mid(Replace(v_strTXDATE, "/", vbNullString), 1, 4) & Mid(Replace(v_strTXDATE, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOId & CStr(v_DataAccess.GetIDValue("ODMAST")), Len(gc_FORMAT_ODAUTOId))

                            v_strCacheTLTXData = v_spmCaching.TLTXGetPropertyValue(v_strTLTXCD)
                            If v_strCacheTLTXData.Length > 0 Then
                                mv_XMLBuffer.LoadXml(v_strCacheTLTXData)
                                v_strCacheTLTXData = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText
                                v_xmlDocument.LoadXml(v_strCacheTLTXData)
                                v_strTXNUM = FO_PREFIXED & Right(gc_FORMAT_BATCHTXNUm & CStr(v_DataAccess.GetIDValue("FOTXNUM")), Len(gc_FORMAT_BATCHTXNUm) - Len(FO_PREFIXED))

                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTXDATE
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTXNUM
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strTXTIME
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "FO"
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value = v_strTLID
                                'Scan all field in the transaction to set value
                                v_nodeData = v_xmlDocument.SelectSingleNode("TransactMessage/fields")
                                If Not v_nodeData Is Nothing Then
                                    For j = 0 To v_nodeData.ChildNodes.Count - 1
                                        v_strDEFNAME = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeDEFNAME).Value)
                                        v_strFLDNAME = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeFLDNAME).Value)
                                        v_strFLDTYPE = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeFLDTYPE).Value)
                                        'Set value
                                        Select Case v_strFLDNAME
                                            Case "01" 'CODEID
                                                v_strFLDVALUE = v_strCODEID
                                            Case "07" 'SYMBOL
                                                v_strFLDVALUE = v_strSYMBOL
                                            Case "02" 'ACTYPE
                                                v_strFLDVALUE = v_strACTYPE
                                            Case "03" 'AFACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO
                                            Case "50" 'CUSTNAME 'Lay lam thong tin nguoi dat lenh
                                                v_strFLDVALUE = ""
                                            Case "05" 'CIACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO
                                            Case "06" 'SEACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO & v_strCODEID
                                            Case "20" 'TIMETYPE                                       
                                                v_strFLDVALUE = v_strTIMETYPE
                                            Case "21" 'EXPDATE                                       
                                                v_strFLDVALUE = v_strTXDATE
                                            Case "22" 'EXECTYPE  
                                                'v_strFLDVALUE = v_strEXECTYPE
                                                v_strFLDVALUE = v_strORGEXECTYPE
                                                'v_strFLDVALUE = cboExecType.SelectedValue
                                            Case "23" 'NORK                                       
                                                v_strFLDVALUE = v_strNORK
                                            Case "24" 'MATCHTYPE                                       
                                                v_strFLDVALUE = v_strMATCHTYPE
                                            Case "25" 'VIA                                       
                                                v_strFLDVALUE = v_strVIA
                                            Case "26" 'CLEARCD                                       
                                                v_strFLDVALUE = v_strCLEARCD
                                            Case "27" 'PRICETYPE                                       
                                                v_strFLDVALUE = v_strPRICETYPE
                                            Case "10" 'CLEARDAY
                                                v_strFLDVALUE = v_strCLEARDAY
                                            Case "11" 'QUOTEPRICE
                                                'If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "MO" Then  'Lenh ATO then
                                                v_strFLDVALUE = v_strQUOTEPRICE
                                            Case "12" 'ORDERQTTY             
                                                v_strFLDVALUE = v_strSendQuantity 'v_strQUANTITY
                                            Case "13" 'BRATIO                                      
                                                v_strFLDVALUE = v_dblSecureRatio
                                            Case "14" 'LIMITPRICE
                                                v_strFLDVALUE = v_ds.Tables(0).Rows(i)("PRICE")
                                            Case "40" 'Feeamt
                                                v_strFLDVALUE = "0" ' Tam thoi lay la 0
                                            Case "15" 'PARVALUE
                                                v_strFLDVALUE = v_strPARVALUE
                                            Case "16" 'Original ORDERQTTY (For Adjust Order Only)
                                                v_strFLDVALUE = v_strREFQUANTITY
                                            Case "17" 'Original ORDERPrice (For Adjust Order Only)
                                                v_strFLDVALUE = v_strREFPRICE
                                            Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                                v_strFLDVALUE = v_dblAdvanceSecuredAmount.ToString
                                            Case "28" 'VOUCHER
                                                v_strFLDVALUE = "P"
                                            Case "29" 'CONSULTANT
                                                v_strFLDVALUE = "N"
                                            Case "04" 'ORDERID
                                                v_strFLDVALUE = v_strOrderID
                                            Case "08" 'Cancel Order ID
                                                v_strFLDVALUE = v_strORGACCTNO
                                            Case "30" 'DESC 
                                                v_strFLDVALUE = "FO" & Strings.Left(v_strOrderID, 4) & "." & Strings.Mid(v_strOrderID, 5, 6) & "." & Strings.Right(v_strOrderID, 6) & "." & Trim(v_strFULLNAME) & "." & v_strMATCHTYPE & "" & v_strORGEXECTYPE & "." & v_strSYMBOL & "." & v_strSendQuantity & "." & v_strQUOTEPRICE
                                            Case "09" 'Custody Code
                                                v_strFLDVALUE = v_strCUSTODYCD
                                            Case "95"
                                                v_strFLDVALUE = v_strDFACCTNO
                                            Case "99" 'Top up
                                                'v_strFLDVALUE = "100"
                                                If v_strMarginType = "N" Then
                                                    v_strFLDVALUE = "100"
                                                Else
                                                    If v_dblIsPPUsed = 1 Then
                                                        v_strFLDVALUE = CStr(100 / (1 - v_dblMarginRatioRate / 100 * v_dblSecMarginPrice / CDbl(v_strQUOTEPRICE) / (v_strTRADEUNIT)))
                                                    Else
                                                        v_strFLDVALUE = "100"
                                                    End If
                                                End If
                                            Case "98" 'TradeUnit
                                                v_strFLDVALUE = v_strTRADEUNIT
                                            Case "97" 'Mode dat lenh
                                                v_strFLDVALUE = "A"
                                            Case "60" 'Is mortage
                                                v_strFLDVALUE = IIf(v_strEXECTYPE = "MS", "1", "0")
                                            Case "96"
                                                v_strFLDVALUE = 1
                                            Case "72"
                                                v_strFLDVALUE = v_strPuttype
                                        End Select
                                        v_nodeData.ChildNodes(j).InnerText = v_strFLDVALUE
                                    Next
                                Else
                                    'Filling Transaction
                                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»Ãƒâ€šÃ‚Â© tÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»Ãƒâ€šÃ‚Â± ODRER BY lÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â  quan trÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»?ng
                                    v_dsTLLOG = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                                        'Create Transaction contents
                                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                                            'Add field name
                                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                            v_attrFLDNAME.Value = v_strFLDNAME
                                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                                            'Add field type
                                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                            v_attrDATATYPE.Value = v_strFLDTYPE
                                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                                            'Set value
                                            Select Case v_strFLDNAME
                                                Case "01" 'CODEID
                                                    v_strFLDVALUE = v_strCODEID
                                                Case "07" 'SYMBOL
                                                    v_strFLDVALUE = v_strSYMBOL
                                                Case "02" 'ACTYPE
                                                    v_strFLDVALUE = v_strACTYPE
                                                Case "03" 'AFACCTNO
                                                    v_strFLDVALUE = v_strAFACCTNO
                                                Case "50" 'CUSTNAME 'Lay lam thong tin nguoi dat lenh
                                                    v_strFLDVALUE = ""
                                                Case "05" 'CIACCTNO
                                                    v_strFLDVALUE = v_strAFACCTNO
                                                Case "06" 'SEACCTNO
                                                    v_strFLDVALUE = v_strAFACCTNO & v_strCODEID
                                                Case "20" 'TIMETYPE                                       
                                                    v_strFLDVALUE = v_strTIMETYPE
                                                Case "21" 'EXPDATE                                       
                                                    v_strFLDVALUE = v_strTXDATE
                                                Case "22" 'EXECTYPE  
                                                    'v_strFLDVALUE = v_strEXECTYPE
                                                    v_strFLDVALUE = v_strORGEXECTYPE
                                                    'v_strFLDVALUE = cboExecType.SelectedValue
                                                Case "23" 'NORK                                       
                                                    v_strFLDVALUE = v_strNORK
                                                Case "24" 'MATCHTYPE                                       
                                                    v_strFLDVALUE = v_strMATCHTYPE
                                                Case "25" 'VIA                                       
                                                    v_strFLDVALUE = v_strVIA
                                                Case "26" 'CLEARCD                                       
                                                    v_strFLDVALUE = v_strCLEARCD
                                                Case "27" 'PRICETYPE                                       
                                                    v_strFLDVALUE = v_strPRICETYPE
                                                Case "10" 'CLEARDAY
                                                    v_strFLDVALUE = v_strCLEARDAY
                                                Case "11" 'QUOTEPRICE
                                                    'If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "MO" Then  'Lenh ATO then
                                                    v_strFLDVALUE = v_strQUOTEPRICE
                                                Case "12" 'ORDERQTTY                                      
                                                    v_strFLDVALUE = v_strSendQuantity
                                                Case "13" 'BRATIO                                      
                                                    v_strFLDVALUE = v_dblSecureRatio
                                                Case "14" 'LIMITPRICE
                                                    v_strFLDVALUE = v_ds.Tables(0).Rows(i)("PRICE")
                                                Case "40" 'Feeamt
                                                    v_strFLDVALUE = "0" ' Tma thoi lay la 0
                                                Case "15" 'PARVALUE
                                                    v_strFLDVALUE = v_strPARVALUE
                                                Case "16" 'Original ORDERQTTY (For Adjust Order Only)
                                                    v_strFLDVALUE = v_strREFQUANTITY
                                                Case "17" 'Original ORDERPrice (For Adjust Order Only)
                                                    v_strFLDVALUE = v_strREFPRICE
                                                Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                                    v_strFLDVALUE = v_dblAdvanceSecuredAmount.ToString
                                                Case "28" 'VOUCHER
                                                    v_strFLDVALUE = "P"
                                                Case "29" 'CONSULTANT
                                                    v_strFLDVALUE = "N"
                                                Case "04" 'ORDERID
                                                    v_strFLDVALUE = v_strOrderID
                                                Case "08" 'Cancel Order ID
                                                    v_strFLDVALUE = v_strORGACCTNO
                                                Case "30" 'DESC 
                                                    v_strFLDVALUE = "FO" & Strings.Left(v_strOrderID, 4) & "." & Strings.Mid(v_strOrderID, 5, 6) & "." & Strings.Right(v_strOrderID, 6) & "." & Trim(v_strFULLNAME) & "." & v_strMATCHTYPE & "" & v_strEXECTYPE & "." & v_strSYMBOL & "." & v_strSendQuantity & "." & v_strQUOTEPRICE
                                                Case "09" 'Custody Code
                                                    v_strFLDVALUE = v_strCUSTODYCD
                                                Case "99" 'Top up
                                                    'v_strFLDVALUE = "100"
                                                    If v_strMarginType = "S" Or v_strMarginType = "T" Then
                                                        If v_dblIsPPUsed = 1 Then
                                                            v_strFLDVALUE = CStr(100 / (1 - v_dblMarginRatioRate / 100 * v_dblSecMarginPrice / CDbl(v_strQUOTEPRICE) / (v_strTRADEUNIT)))
                                                        Else
                                                            v_strFLDVALUE = "100"
                                                        End If

                                                    Else
                                                        v_strFLDVALUE = "100"
                                                    End If
                                                Case "98" 'TradeUnit
                                                    v_strFLDVALUE = v_strTRADEUNIT
                                                Case "97" 'Mode dat lenh
                                                    v_strFLDVALUE = "A"
                                                Case "60" 'Is mortage
                                                    v_strFLDVALUE = IIf(v_strEXECTYPE = "MS", "1", "0")
                                                Case "96"
                                                    v_strFLDVALUE = 1
                                            End Select
                                            v_entryNode.InnerText = v_strFLDVALUE

                                            v_dataElement.AppendChild(v_entryNode)
                                        Next
                                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                                    End If
                                End If
                            End If
                            'Ghi nhan vao TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                            'II. Execute message
                            '-----------------------
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                                'Cap nhat trang thai tro lai FOMAST
                                v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                v_strSQL = "INSERT INTO rootordermap(FOACCTNO,ORDERID,STATUS,MESSAGE,ID) VALUES ('" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','','R','[" & v_lngErrCode & "] " & v_strErrorMessage & " '," & v_dblCount & ")"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'Log vao messagebus
                                LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                                v_blnOK = False
                                Exit While
                            End If
                            If v_blnOK Then
                                'Doc tu TLLOG len de thuc hien
                                v_strTXNUM = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                                v_strTXDATE = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                                Dim v_obj As New txRouter
                                v_lngErrCode = v_obj.ExecuteFOMessage(v_strTXDATE, v_strTXNUM)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                                    'Cap nhat trang thai tro lai FOMAST
                                    v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    v_strSQL = "INSERT INTO rootordermap(FOACCTNO,ORDERID,STATUS,MESSAGE,ID) VALUES ('" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','','R','[" & v_lngErrCode & "] " & v_strErrorMessage & " '," & v_dblCount & ")"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    'Log vao messagebus
                                    LogOrderMessage(v_ds.Tables(0).Rows(i)("ACCTNO"))
                                    v_blnOK = False
                                    Exit While
                                Else
                                    v_strSQL = "UPDATE FOMAST SET ORGACCTNO='" & v_strOrderID & "', STATUS='A',FEEDBACKMSG='Order is active and sucessfull processed: " & v_strOrderID.ToString & "' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    v_strSQL = "INSERT INTO rootordermap(FOACCTNO,ORDERID,STATUS,MESSAGE,ID) VALUES ('" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','" & v_strOrderID & "','A','[" & v_lngErrCode & "] " & v_strErrorMessage & " '," & v_dblCount & ")"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                            End If
                            v_strQUANTITY = CStr(CDbl(v_strQUANTITY) - CDbl(v_strSendQuantity))
                        End While
                    Next
                End If
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
            v_objMessageLog = Nothing
        End Try
    End Function

    Public Function SendOTCOrderToExchange(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.SendOTCOrderToExchange", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(0) As StoreParameter
            v_objParam.ParamName = "SENDTIME"
            v_objParam.ParamValue = Now.ToString
            v_objParam.ParamSize = 50
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_DataAccess.ExecuteStoredNonQuerry("PROCESS_ORDER", v_arrPara)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
        End Try
    End Function

    Public Function ReceiveGXTrade(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ReceiveGXTrade", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(0) As StoreParameter
            v_objParam.ParamName = "SENDTIME"
            v_objParam.ParamValue = Now.ToString
            v_objParam.ParamSize = 50
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_DataAccess.ExecuteStoredNonQuerry("PROCESS_TRADE", v_arrPara)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
        End Try
    End Function

    Public Function SendGTCOrderToCompany(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.SendGTCOrderToCompany", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds, v_dsTemp, v_dsTLLOG, v_dsMST As DataSet, v_objMessageLog As New MessageLog, v_xmlDocument As New Xml.XmlDocument
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strFLDVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim j As Integer
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_blnOK As Boolean = True
        Dim v_strTLTXCD As String
        Dim v_strTXTIME As String
        Dim v_strEXECTYPE As String
        Dim v_strCMDSQL As String
        Dim v_strFOACCTNO As String
        Dim v_strVIA As String
        Dim v_strCLEARCD As String
        Dim v_strTIMETYPE As String
        Dim v_strPRICETYPE As String
        Dim v_strMATCHTYPE As String
        Dim v_strTRADEPLACE As String
        Dim v_strSECTYPE As String
        Dim v_strPARVALUE As String
        Dim v_strNORK As String
        Dim v_strTRADELOT As String
        Dim v_strTRADEUNIT As String
        Dim v_strAFACCTNO As String
        Dim v_strCODEID As String
        Dim v_strSYMBOL As String
        Dim v_strQUOTEPRICE As String
        Dim v_strQUANTITY As String
        Dim v_strACTYPE As String
        Dim v_strCLEARDAY As String
        Dim v_strCUSTODYCD As String
        Dim v_strFULLNAME As String
        Dim mv_dblSecureBratioMin, mv_dblSecureBratioMax, mv_dblTyp_Bratio, mv_dblAF_Bratio, mv_dblFeeAmountMin, mv_dblFeeRate As Double
        Dim v_dblSecureRatio, v_dblFeeSecureRatioMin As Double
        Dim v_dblFeeAmout As Double
        Dim v_strOrderID As String
        Dim v_strORGACCTNO As String
        Dim v_strREFACCTNO As String
        Dim v_strREFQUANTITY As String
        Dim v_strREFPRICE As String
        Dim v_dblCeilPrice As Double
        Dim v_dblFloorPrice As Double
        Dim v_dblMarginPrice As Double
        Dim v_dblAdvanceSecuredAmount As Double
        Dim v_spmCaching As New spRouter, mv_XMLBuffer As New Xml.XmlDocument, v_nodeData As Xml.XmlNode, v_strCacheTLTXData As String
        Dim v_dtTXDATE As Date
        Dim v_strODTXNUM As String = ""
        Dim v_strOUTPRICEALLOW As String = "Y"
        Dim v_strMarginType As String = "N"
        Dim v_dblMarginRatioRate As Double = 0
        Dim v_dblSecMarginPrice As Double = 0
        Dim v_dblIsPPUsed As Double = 1

        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strFunType As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            'Kiá»ƒm tra chá»‰ cho phÃ©p cháº¡y Batch náº¿u BDS Ä‘Ã£ InActive
            Dim v_strSYSVAR, v_strSQL, v_strTXDATE, v_strTXNUM, v_strMSGID, v_strTxMsg As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Lay TXDATE
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If Not v_strSYSVAR = OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            Else
                'Select Case v_strFunType
                '    Case "GTC-HO" 'Lenh GTC san HOSE
                '        v_strSQL = "    SELECT * FROM (SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "  FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,CIMAST CI " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0 " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('NB','BC') AND MST.PRICETYPE<>'SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='001' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                '            & "   AND CI.ACCTNO =MST.AFACCTNO " & ControlChars.CrLf _
                '            & "   AND CI.BALANCE >= MST.BRATIO/100*MST.REMAINQTTY* " & ControlChars.CrLf _
                '            & "   (CASE WHEN PRICETYPE='LO' THEN MST.QUOTEPRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "         ELSE INF.CEILINGPRICE " & ControlChars.CrLf _
                '            & "    END) " & ControlChars.CrLf _
                '            & "UNION  " & ControlChars.CrLf _
                '            & "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "         FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,SEMAST SE " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0  " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('MS','SS','NS')  AND MST.PRICETYPE<>'SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='001' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                '            & "   AND SE.ACCTNO =MST.AFACCTNO || MST.CODEID " & ControlChars.CrLf _
                '            & "   AND (CASE WHEN MST.EXECTYPE='MS' THEN SE.MORTAGE ELSE SE.TRADE END)  >= MST.REMAINQTTY) ORDER BY TO_DATE(SUBSTR(ACCTNO,5,6),'DDMMYY'), SUBSTR(ACCTNO,11,6) " & ControlChars.CrLf
                '    Case "GTC-HA"
                '        v_strSQL = "SELECT * FROM (SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "  FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,CIMAST CI " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0 " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('NB','BC')  AND MST.PRICETYPE<>'SL'  " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='002' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                '            & "   AND CI.ACCTNO =MST.AFACCTNO " & ControlChars.CrLf _
                '            & "   AND CI.BALANCE >= MST.BRATIO/100*MST.REMAINQTTY* " & ControlChars.CrLf _
                '            & "   (CASE WHEN PRICETYPE='LO' THEN MST.QUOTEPRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "         ELSE INF.CEILINGPRICE " & ControlChars.CrLf _
                '            & "    END) " & ControlChars.CrLf _
                '            & "UNION  " & ControlChars.CrLf _
                '            & "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "         FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,SEMAST SE " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0  " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('MS','SS','NS')  AND MST.PRICETYPE<>'SL'  " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='002' " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                '            & "   AND SE.ACCTNO =MST.AFACCTNO || MST.CODEID " & ControlChars.CrLf _
                '            & "   AND (CASE WHEN MST.EXECTYPE='MS' THEN SE.MORTAGE ELSE SE.TRADE END)  >= MST.REMAINQTTY) ORDER BY TO_DATE(SUBSTR(ACCTNO,5,6),'DDMMYY'), SUBSTR(ACCTNO,11,6) " & ControlChars.CrLf
                '    Case "SL-HO"
                '        '& "   AND (MST.outpriceallow='Y' or (MST.outpriceallow='N' and mst.quoteprice*INF.TRADEUNIT>=INF.FLOORPRICE and mst.quoteprice*INF.TRADEUNIT<=INF.CEILINGPRICE )) " & ControlChars.CrLf _
                '        v_strSQL = "SELECT * FROM (SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT,  " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE  " & ControlChars.CrLf _
                '            & "  FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,CIMAST CI,CURR_SEC_INFO CURRINF " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0  " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('NB','BC') AND MST.PRICETYPE='SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G'  " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID  " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='001'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID  " & ControlChars.CrLf _
                '            & "   AND INF.SYMBOL = TRIM(CURRINF.CODE)  " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE>0 " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE*10<=MST.PRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                '            & "   AND CI.ACCTNO =MST.AFACCTNO  " & ControlChars.CrLf _
                '            & "   AND CI.BALANCE >= MST.BRATIO/100*MST.REMAINQTTY*  " & ControlChars.CrLf _
                '            & "   (CASE WHEN MST.QUOTEPRICE>INF.CEILINGPRICE THEN INF.CEILINGPRICE  " & ControlChars.CrLf _
                '            & "         WHEN MST.QUOTEPRICE<INF.FLOORPRICE THEN INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "         else MST.QUOTEPRICE * INF.TRADEUNIT  " & ControlChars.CrLf _
                '            & "    END)  " & ControlChars.CrLf _
                '            & "UNION   " & ControlChars.CrLf _
                '            & "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT,  " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE  " & ControlChars.CrLf _
                '            & "         FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,SEMAST SE,CURR_SEC_INFO CURRINF  " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0   " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('MS','SS','NS')  AND MST.PRICETYPE='SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G'  " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID  " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='001'  " & ControlChars.CrLf _
                '            & "  AND (MST.outpriceallow='Y' or (MST.outpriceallow='N' and mst.quoteprice*INF.TRADEUNIT>=INF.FLOORPRICE and mst.quoteprice*INF.TRADEUNIT<=INF.CEILINGPRICE )) " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID  " & ControlChars.CrLf _
                '            & "   AND INF.SYMBOL = TRIM(CURRINF.CODE) " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE>0 " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE*10>=MST.PRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                '            & "   AND SE.ACCTNO =MST.AFACCTNO || MST.CODEID  " & ControlChars.CrLf _
                '            & "   AND (CASE WHEN MST.EXECTYPE='MS' THEN SE.MORTAGE ELSE SE.TRADE END)  >= MST.REMAINQTTY) ORDER BY TO_DATE(SUBSTR(ACCTNO,5,6),'DDMMYY'), SUBSTR(ACCTNO,11,6)  " & ControlChars.CrLf
                '    Case "SL-HA"
                '        '& "  AND (MST.outpriceallow='Y' or (MST.outpriceallow='N' and mst.quoteprice*INF.TRADEUNIT>=INF.FLOORPRICE and mst.quoteprice*INF.TRADEUNIT<=INF.CEILINGPRICE )) " & ControlChars.CrLf _
                '        v_strSQL = "SELECT * FROM (SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT,  " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE  " & ControlChars.CrLf _
                '            & "  FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,CIMAST CI,CURR_SEC_INFO CURRINF " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0  " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('NB','BC') AND MST.PRICETYPE='SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G'  " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID  " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='002'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID  " & ControlChars.CrLf _
                '            & "   AND INF.SYMBOL = TRIM(CURRINF.CODE)  " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE>0 " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE<=MST.PRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                '            & "   AND CI.ACCTNO =MST.AFACCTNO  " & ControlChars.CrLf _
                '            & "   AND CI.BALANCE >= MST.BRATIO/100*MST.REMAINQTTY*  " & ControlChars.CrLf _
                '            & "   (CASE WHEN MST.QUOTEPRICE>INF.CEILINGPRICE THEN INF.CEILINGPRICE  " & ControlChars.CrLf _
                '            & "         WHEN MST.QUOTEPRICE<INF.FLOORPRICE THEN INF.FLOORPRICE " & ControlChars.CrLf _
                '            & "         else MST.QUOTEPRICE * INF.TRADEUNIT  " & ControlChars.CrLf _
                '            & "    END)  " & ControlChars.CrLf _
                '            & "UNION   " & ControlChars.CrLf _
                '            & "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT,  " & ControlChars.CrLf _
                '            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE  " & ControlChars.CrLf _
                '            & "         FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,SEMAST SE,CURR_SEC_INFO CURRINF  " & ControlChars.CrLf _
                '            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0   " & ControlChars.CrLf _
                '            & "   AND MST.EXECTYPE IN ('MS','SS','NS')  AND MST.PRICETYPE='SL' " & ControlChars.CrLf _
                '            & "   AND MST.TIMETYPE = 'G'  " & ControlChars.CrLf _
                '            & "   AND MST.STATUS = 'P'  " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = SEC.CODEID  " & ControlChars.CrLf _
                '            & "   AND SEC.TRADEPLACE='002'  " & ControlChars.CrLf _
                '            & "  AND (MST.outpriceallow='Y' or (MST.outpriceallow='N' and mst.quoteprice*INF.TRADEUNIT>=INF.FLOORPRICE and mst.quoteprice*INF.TRADEUNIT<=INF.CEILINGPRICE )) " & ControlChars.CrLf _
                '            & "   AND MST.CODEID = INF.CODEID  " & ControlChars.CrLf _
                '            & "   AND INF.SYMBOL = TRIM(CURRINF.CODE) " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE>0 " & ControlChars.CrLf _
                '            & "   AND MATCH_PRICE>=MST.PRICE * INF.TRADEUNIT " & ControlChars.CrLf _
                '            & "   AND MST.EFFDATE <= TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                '            & "   AND SE.ACCTNO =MST.AFACCTNO || MST.CODEID  " & ControlChars.CrLf _
                '            & "   AND (CASE WHEN MST.EXECTYPE='MS' THEN SE.MORTAGE ELSE SE.TRADE END)  >= MST.REMAINQTTY) ORDER BY TO_DATE(SUBSTR(ACCTNO,5,6),'DDMMYY'), SUBSTR(ACCTNO,11,6)  " & ControlChars.CrLf
                'End Select

                'v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_objRptParam As ReportParameters
                Dim v_arrRptPara() As ReportParameters
                ReDim v_arrRptPara(0)
                '0. So hop dong
                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "pv_FunType"
                v_objRptParam.ParamValue = v_strFunType
                v_objRptParam.ParamSize = CStr(40)
                v_objRptParam.ParamType = "VARCHAR2"
                v_arrRptPara(0) = v_objRptParam
                v_ds = v_DataAccess.ExecuteStoredReturnDataset("GETCONDITIONFONTORDER", v_arrRptPara)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                        v_blnOK = True
                        'I. Create standart message
                        '-----------------------
                        '1.Xac dinh giao dich tuong ung
                        v_strFOACCTNO = v_ds.Tables(0).Rows(i)("ACCTNO")
                        v_strVIA = v_ds.Tables(0).Rows(i)("VIA")   'Tam thoi lay la Tele
                        v_strCLEARCD = v_ds.Tables(0).Rows(i)("CLEARCD")
                        v_strCLEARDAY = v_ds.Tables(0).Rows(i)("CLEARDAY")
                        v_strTIMETYPE = v_ds.Tables(0).Rows(i)("TIMETYPE")
                        v_strPRICETYPE = v_ds.Tables(0).Rows(i)("PRICETYPE")
                        v_strMATCHTYPE = v_ds.Tables(0).Rows(i)("MATCHTYPE")
                        v_strTRADEPLACE = v_ds.Tables(0).Rows(i)("TRADEPLACE")
                        v_strSECTYPE = v_ds.Tables(0).Rows(i)("SECTYPE")
                        v_strPARVALUE = v_ds.Tables(0).Rows(i)("PARVALUE")
                        v_strNORK = v_ds.Tables(0).Rows(i)("NORK")
                        v_strTRADELOT = v_ds.Tables(0).Rows(i)("TRADELOT")
                        v_strTRADEUNIT = v_ds.Tables(0).Rows(i)("TRADEUNIT")
                        v_strAFACCTNO = v_ds.Tables(0).Rows(i)("AFACCTNO")
                        v_strCODEID = v_ds.Tables(0).Rows(i)("CODEID")
                        v_strSYMBOL = v_ds.Tables(0).Rows(i)("SYMBOL")
                        v_strQUOTEPRICE = v_ds.Tables(0).Rows(i)("QUOTEPRICE")
                        v_strQUANTITY = v_ds.Tables(0).Rows(i)("REMAINQTTY")
                        v_strEXECTYPE = v_ds.Tables(0).Rows(i)("EXECTYPE")
                        mv_dblSecureBratioMin = v_ds.Tables(0).Rows(i)("SECUREDRATIOMIN")
                        mv_dblSecureBratioMax = v_ds.Tables(0).Rows(i)("SECUREDRATIOMAX")
                        v_strORGACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGACCTNO"))
                        v_strREFACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFACCTNO"))
                        v_strREFQUANTITY = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFQUANTITY"))
                        v_strREFPRICE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFPRICE"))
                        v_dblSecureRatio = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("BRATIO"))
                        v_strACTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTYPE"))
                        v_dblCeilPrice = v_ds.Tables(0).Rows(i)("CEILINGPRICE")
                        v_dblFloorPrice = v_ds.Tables(0).Rows(i)("FLOORPRICE")
                        v_dblMarginPrice = v_ds.Tables(0).Rows(i)("MARGINPRICE")
                        v_dtTXDATE = v_ds.Tables(0).Rows(i)("TXDATE")
                        v_strODTXNUM = v_ds.Tables(0).Rows(i)("TXNUM")
                        v_strOUTPRICEALLOW = v_ds.Tables(0).Rows(i)("OUTPRICEALLOW")

                        If v_strFunType = "SL-HA" Or v_strFunType = "SL-HO" Then
                            If v_strOUTPRICEALLOW = "N" And (v_strQUOTEPRICE > v_dblCeilPrice / CDbl(v_strTRADEUNIT) Or v_strQUOTEPRICE < v_dblFloorPrice / CDbl(v_strTRADEUNIT)) Then
                                v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_ds.Tables(0).Rows(i)("ACCTNO") & " Over ceiling or under floor price" & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'Luu lai trang lenh da day
                                v_strSQL = "INSERT INTO FOMASTLOG(ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,SENDDT) SELECT ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS') SENDDT FROM FOMAST WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                v_blnOK = False
                            Else
                                'Neu vuot qua bien thi lay bien
                                v_strQUOTEPRICE = IIf(v_strQUOTEPRICE > v_dblCeilPrice / CDbl(v_strTRADEUNIT), v_dblCeilPrice / CDbl(v_strTRADEUNIT), v_strQUOTEPRICE)
                                v_strQUOTEPRICE = IIf(v_strQUOTEPRICE < v_dblFloorPrice / CDbl(v_strTRADEUNIT), v_dblFloorPrice / CDbl(v_strTRADEUNIT), v_strQUOTEPRICE)
                            End If
                        End If

                        Select Case v_strEXECTYPE
                            Case "NB", "BC"
                                v_strTLTXCD = gc_OD_PLACENORMALBUYORDER_ADVANCEd
                                v_strEXECTYPE = v_strEXECTYPE
                            Case "NS", "MS", "SS"
                                v_strTLTXCD = gc_OD_PLACENORMALSELLORDER_ADVANCEd
                                v_strEXECTYPE = v_strEXECTYPE
                            Case "AB"
                                v_strTLTXCD = gc_OD_AMENDMENTBUYORDER
                                v_strEXECTYPE = "NB"
                            Case "AS"
                                v_strTLTXCD = gc_OD_AMENDMENTSELLORDER
                                v_strEXECTYPE = "NS"
                            Case "CB"
                                v_strTLTXCD = gc_OD_CANCELBUYORDER
                                v_strEXECTYPE = "NB"
                            Case "CS"
                                v_strTLTXCD = gc_OD_CANCELSELLORDER
                                v_strEXECTYPE = "NS"
                        End Select

                        If v_strPRICETYPE <> "LO" And v_strPRICETYPE <> "SL" Then
                            'Xac dinh trang thai thi truong xem la phien 1,2 or 3
                            v_strSQL = "SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='CONTROLCODE'"
                            v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            Dim v_strMarketStatus As String
                            v_strMarketStatus = v_dsMST.Tables(0).Rows(0)("SYSVALUE")
                            'v_strMarketStatus=P: 8h30-->9h00 phien 1 ATO
                            'v_strMarketStatus=O: 9h00-->10h15 phien 2 MP
                            'v_strMarketStatus=A: 10h15-->10h30 phien 3 ATC
                            v_strPRICETYPE = "ATO"
                            Select Case v_strMarketStatus
                                Case "O"
                                    v_strPRICETYPE = "LO"
                                Case "A"
                                    v_strPRICETYPE = "ATC"
                                Case "P"
                                    v_strPRICETYPE = "ATO"
                            End Select
                            If (v_strEXECTYPE = "NS" Or v_strEXECTYPE = "MS") Then 'Lenh ATO then
                                v_strQUOTEPRICE = v_dblFloorPrice / CDbl(v_strTRADEUNIT)
                            ElseIf (v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC") Then 'Lenh ATO then
                                v_strQUOTEPRICE = v_dblCeilPrice / CDbl(v_strTRADEUNIT)
                            End If
                        End If
                        '2.KIEM TRA XEM CO DU KY QUY KHONG
                        v_strSQL = "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                            & "  FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,CIMAST CI,v_getbuyorderinfo V " & ControlChars.CrLf _
                            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0 AND CI.ACCTNO=V.afacctno(+) " & ControlChars.CrLf _
                            & "   AND MST.EXECTYPE IN ('NB','BC') " & ControlChars.CrLf _
                            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                            & "   AND CI.ACCTNO =MST.AFACCTNO " & ControlChars.CrLf _
                            & "   AND CHECKGTCBUYORDER(mst.afacctno,MST.REMAINQTTY, " & ControlChars.CrLf _
                            & "                           (CASE WHEN PRICETYPE='LO' THEN MST.QUOTEPRICE " & ControlChars.CrLf _
                            & "                                 WHEN PRICETYPE='SL' THEN " & CDbl(v_strQUOTEPRICE) & ControlChars.CrLf _
                            & "                                 ELSE INF.CEILINGPRICE/INF.TRADEUNIT " & ControlChars.CrLf _
                            & "                            END), " & ControlChars.CrLf _
                            & "                               MST.BRATIO,SEC.SYMBOL " & ControlChars.CrLf _
                            & "                   )>=0 " & ControlChars.CrLf _
                            & "UNION  " & ControlChars.CrLf _
                            & "SELECT MST.*, SEC.TRADEPLACE, SEC.SECTYPE, SEC.PARVALUE, INF.TRADELOT, " & ControlChars.CrLf _
                            & "       INF.TRADEUNIT, INF.SECUREDRATIOMIN, INF.SECUREDRATIOMAX,INF.CEILINGPRICE,INF.FLOORPRICE " & ControlChars.CrLf _
                            & "         FROM FOMAST MST, SBSECURITIES SEC, SECURITIES_INFO INF,SEMAST SE,v_getsellorderinfo V " & ControlChars.CrLf _
                            & " WHERE MST.DELTD<>'Y' AND MST.BOOK = 'A' AND  MST.REMAINQTTY>0 AND SE.ACCTNO=V.seacctno(+)  " & ControlChars.CrLf _
                            & "   AND MST.EXECTYPE IN ('MS','SS','NS') " & ControlChars.CrLf _
                            & "   AND MST.TIMETYPE = 'G' " & ControlChars.CrLf _
                            & "   AND MST.STATUS = 'P' " & ControlChars.CrLf _
                            & "   AND MST.CODEID = SEC.CODEID " & ControlChars.CrLf _
                            & "   AND MST.CODEID = INF.CODEID " & ControlChars.CrLf _
                            & "   AND SE.ACCTNO =MST.AFACCTNO || MST.CODEID " & ControlChars.CrLf _
                            & "   AND (CASE WHEN MST.EXECTYPE='MS' THEN SE.MORTAGE-nvl(v.securemtg,0) ELSE SE.TRADE-nvl(V.secureamt,0)+nvl(V.sereceiving,0) END)  >= MST.REMAINQTTY AND MST.ACCTNO='" & v_strFOACCTNO & "' " & ControlChars.CrLf
                        v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_dsMST.Tables(0).Rows.Count > 0 Then
                            'dU KY QUY
                            v_blnOK = True
                        Else
                            'kHONG DU KY QUY
                            v_blnOK = False
                        End If
                        If v_dtTXDATE = DDMMYYYY_SystemDate(v_strTXDATE) And v_strODTXNUM.Length > 0 Then
                            'Kiem tra xem giao dich dat lenh da duoc duyet hay chua
                            v_strSQL = "SELECT TXSTATUS FROM TLLOG WHERE TXNUM='" & v_strODTXNUM & "' AND TXSTATUS='1'"
                            v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsMST.Tables(0).Rows.Count > 0 Then
                                'GIAO DICH DA DUOC DUYET
                                v_blnOK = v_blnOK And True
                            Else
                                'GIAO DICH CHUA DUOC DUYET
                                v_blnOK = v_blnOK And False
                            End If
                        End If
                        ''3.Xac dinh cac thong tin lien quan den lenh
                        'v_strSQL = "SELECT MST.BRATIO, CF.CUSTODYCD,CF.FULLNAME FROM AFMAST MST, CFMAST CF WHERE ACCTNO='" & v_strAFACCTNO & "' AND MST.CUSTID=CF.CUSTID"
                        'v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'If v_ds.Tables(0).Rows.Count > 0 Then
                        '    v_strCUSTODYCD = v_dsMST.Tables(0).Rows(0)("CUSTODYCD")
                        '    v_strFULLNAME = v_dsMST.Tables(0).Rows(0)("FULLNAME")
                        '    mv_dblAF_Bratio = v_dsMST.Tables(0).Rows(0)("BRATIO")
                        'End If
                        '3.Xac dinh cac thong tin lien quan den lenh
                        v_strCMDSQL = "SELECT MST.BRATIO, CF.CUSTODYCD,CF.FULLNAME,MST.ACTYPE,MRT.MRTYPE,MRT.ISPPUSED, " & ControlChars.CrLf _
                                    & " NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(MRPRICELOAN,0) MRPRICELOAN  " & ControlChars.CrLf _
                                    & " FROM AFMAST MST, CFMAST CF ,AFTYPE AFT, MRTYPE MRT, " & ControlChars.CrLf _
                                    & " (SELECT * FROM AFSERISK WHERE CODEID='" & v_strCODEID & "' ) RSK  " & ControlChars.CrLf _
                                    & " WHERE MST.ACCTNO='" & v_strAFACCTNO & "' AND MST.CUSTID=CF.CUSTID " & ControlChars.CrLf _
                                    & " and mst.actype =aft.actype and aft.mrtype = mrt.actype " & ControlChars.CrLf _
                                    & " AND AFT.ACTYPE =RSK.ACTYPE(+)"
                        v_dsMST = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strCMDSQL)
                        If v_dsMST.Tables(0).Rows.Count > 0 Then
                            v_strMarginType = v_dsMST.Tables(0).Rows(0)("MRTYPE")
                            v_dblMarginRatioRate = v_dsMST.Tables(0).Rows(0)("MRRATIOLOAN")
                            v_dblSecMarginPrice = v_dsMST.Tables(0).Rows(0)("MRPRICELOAN")
                            v_dblIsPPUsed = v_dsMST.Tables(0).Rows(0)("ISPPUSED")
                            v_strCUSTODYCD = v_dsMST.Tables(0).Rows(0)("CUSTODYCD")
                            v_strFULLNAME = v_dsMST.Tables(0).Rows(0)("FULLNAME")
                            mv_dblAF_Bratio = v_dsMST.Tables(0).Rows(0)("BRATIO")
                            If v_dblMarginRatioRate >= 100 Or v_dblMarginRatioRate < 0 Then v_dblMarginRatioRate = 0
                            v_dblSecMarginPrice = IIf(v_dblMarginPrice > v_dblSecMarginPrice, v_dblSecMarginPrice, v_dblMarginPrice)
                        End If

                        'v_lngErrCode = BuildFOTxMsg(v_xmlDocument)
                        'v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                        'v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'v_strTXDATE = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
                        '4.Xac dinh ty le ky quy theo loai hinh
                        '--------------------
                        'v_dblSecureRatio = Math.Max(Math.Min(mv_dblTyp_Bratio * mv_dblAF_Bratio, 100), mv_dblSecureBratioMin)
                        'v_dblSecureRatio = CDec(IIf(v_dblSecureRatio > mv_dblSecureBratioMax, mv_dblSecureBratioMax, v_dblSecureRatio))

                        ''Cá»™ng thÃªm kÃ½ quá»¹ cho phÃ­ giao dá»‹ch theo loáº¡i hÃ¬nh lá»‡nh
                        'v_dblFeeSecureRatioMin = mv_dblFeeAmountMin * 100 / (CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * CDbl(v_strTRADEUNIT))
                        'If v_dblFeeSecureRatioMin > mv_dblFeeRate Then
                        '    v_dblSecureRatio += v_dblFeeSecureRatioMin
                        'Else
                        '    v_dblSecureRatio += mv_dblFeeRate
                        'End If
                        '--------------------
                        '5. Voi lenh sua, xac dinh pham phai ky quy them
                        v_dblAdvanceSecuredAmount = 0
                        If CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * v_dblSecureRatio / 100 - CDbl(v_strREFPRICE) * CDbl(v_strREFQUANTITY) * v_dblSecureRatio / 100 > 0 Then
                            v_dblAdvanceSecuredAmount = (CDbl(v_strQUANTITY) * CDbl(v_strQUOTEPRICE) * CDbl(v_dblSecureRatio) / 100 - CDbl(v_strREFPRICE) * CDbl(v_strREFQUANTITY) * v_dblSecureRatio / 100)
                        Else
                            v_dblAdvanceSecuredAmount = "0"
                        End If

                        '6.Lay so hieu lenh
                        v_strOrderID = FO_PREFIXED & "00" & Mid(Replace(v_strTXDATE, "/", vbNullString), 1, 4) & Mid(Replace(v_strTXDATE, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOId & CStr(v_DataAccess.GetIDValue("ODMAST")), Len(gc_FORMAT_ODAUTOId))

                        v_strCacheTLTXData = v_spmCaching.TLTXGetPropertyValue(v_strTLTXCD)
                        If v_strCacheTLTXData.Length > 0 Then
                            mv_XMLBuffer.LoadXml(v_strCacheTLTXData)
                            v_strCacheTLTXData = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText
                            v_xmlDocument.LoadXml(v_strCacheTLTXData)
                            v_strTXNUM = FO_PREFIXED & Right(gc_FORMAT_BATCHTXNUm & CStr(v_DataAccess.GetIDValue("FOTXNUM")), Len(gc_FORMAT_BATCHTXNUm) - Len(FO_PREFIXED))
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strTXTIME
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTXDATE
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTXNUM
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "FO"
                            'Scan all field in the transaction to set value
                            v_nodeData = v_xmlDocument.SelectSingleNode("TransactMessage/fields")
                            If Not v_nodeData Is Nothing Then
                                For j = 0 To v_nodeData.ChildNodes.Count - 1
                                    v_strDEFNAME = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeDEFNAME).Value)
                                    v_strFLDNAME = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeFLDNAME).Value)
                                    v_strFLDTYPE = CStr(v_nodeData.ChildNodes(j).Attributes.GetNamedItem(gc_AtributeFLDTYPE).Value)
                                    'Set value
                                    Select Case v_strFLDNAME
                                        Case "01" 'CODEID
                                            v_strFLDVALUE = v_strCODEID
                                        Case "07" 'SYMBOL
                                            v_strFLDVALUE = v_strSYMBOL
                                        Case "02" 'ACTYPE
                                            v_strFLDVALUE = v_strACTYPE
                                        Case "03" 'AFACCTNO
                                            v_strFLDVALUE = v_strAFACCTNO
                                        Case "50" 'CUSTNAME 'Lay lam thong tin nguoi dat lenh
                                            v_strFLDVALUE = v_strFOACCTNO
                                        Case "05" 'CIACCTNO
                                            v_strFLDVALUE = v_strAFACCTNO
                                        Case "06" 'SEACCTNO
                                            v_strFLDVALUE = v_strAFACCTNO & v_strCODEID
                                        Case "20" 'TIMETYPE                                       
                                            v_strFLDVALUE = v_strTIMETYPE
                                        Case "21" 'EXPDATE                                       
                                            v_strFLDVALUE = v_strTXDATE
                                        Case "22" 'EXECTYPE  
                                            v_strFLDVALUE = v_strEXECTYPE
                                            'v_strFLDVALUE = cboExecType.SelectedValue
                                        Case "23" 'NORK                                       
                                            v_strFLDVALUE = v_strNORK
                                        Case "24" 'MATCHTYPE                                       
                                            v_strFLDVALUE = v_strMATCHTYPE
                                        Case "25" 'VIA                                       
                                            v_strFLDVALUE = v_strVIA
                                        Case "26" 'CLEARCD                                       
                                            v_strFLDVALUE = v_strCLEARCD
                                        Case "27" 'PRICETYPE   
                                            v_strFLDVALUE = IIf(v_strPRICETYPE = "SL", "LO", v_strPRICETYPE)
                                        Case "10" 'CLEARDAY
                                            v_strFLDVALUE = v_strCLEARDAY
                                        Case "11" 'QUOTEPRICE
                                            'If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "MO" Then  'Lenh ATO then
                                            v_strFLDVALUE = v_strQUOTEPRICE
                                        Case "12" 'ORDERQTTY                                      
                                            v_strFLDVALUE = v_strQUANTITY
                                        Case "13" 'BRATIO                                      
                                            v_strFLDVALUE = v_dblSecureRatio
                                        Case "14" 'LIMITPRICE
                                            v_strFLDVALUE = v_ds.Tables(0).Rows(i)("PRICE") * CDbl(v_strTRADEUNIT)
                                        Case "40" ' Feeamt
                                            v_strFLDVALUE = "0" 'Tam thoi lay la 0
                                        Case "15" 'PARVALUE
                                            v_strFLDVALUE = v_strPARVALUE
                                        Case "16" 'Original ORDERQTTY (For Adjust Order Only)
                                            v_strFLDVALUE = v_strREFQUANTITY
                                        Case "17" 'Original ORDERPrice (For Adjust Order Only)
                                            v_strFLDVALUE = v_strREFPRICE
                                        Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                            v_strFLDVALUE = v_dblAdvanceSecuredAmount.ToString
                                        Case "28" 'VOUCHER
                                            v_strFLDVALUE = "P"
                                        Case "29" 'CONSULTANT
                                            v_strFLDVALUE = "N"
                                        Case "04" 'ORDERID
                                            v_strFLDVALUE = v_strOrderID
                                        Case "08" 'Cancel Order ID
                                            v_strFLDVALUE = v_strORGACCTNO
                                        Case "30" 'DESC 
                                            v_strFLDVALUE = "GTC" & Strings.Left(v_strOrderID, 4) & "." & Strings.Mid(v_strOrderID, 5, 6) & "." & Strings.Right(v_strOrderID, 6) & "." & Trim(v_strFULLNAME) & "." & v_strMATCHTYPE & "" & v_strEXECTYPE & "." & v_strSYMBOL & "." & v_strQUANTITY & "." & v_strQUOTEPRICE
                                        Case "09" 'Custody Code
                                            v_strFLDVALUE = v_strCUSTODYCD
                                        Case "99" 'Top up
                                            If v_strMarginType = "N" Then
                                                v_strFLDVALUE = "100"
                                            Else
                                                If v_dblIsPPUsed = 1 Then
                                                    v_strFLDVALUE = CStr(100 / (1 - v_dblMarginRatioRate / 100 * v_dblSecMarginPrice / CDbl(v_strQUOTEPRICE) / (v_strTRADEUNIT)))
                                                Else
                                                    v_strFLDVALUE = "100"
                                                End If
                                            End If
                                        Case "98" 'TradeUnit
                                            v_strFLDVALUE = v_strTRADEUNIT
                                        Case "97" 'Mode dat lenh
                                            v_strFLDVALUE = "A"
                                        Case "96"
                                            v_strFLDVALUE = 1
                                        Case "60" 'Is mortage
                                            v_strFLDVALUE = IIf(v_strEXECTYPE = "MS", 1, 0)
                                    End Select
                                    v_nodeData.ChildNodes(j).InnerText = v_strFLDVALUE
                                Next
                            Else
                                'Filling Transaction
                                v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                                    & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»Ãƒâ€šÃ‚Â© tÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»Ãƒâ€šÃ‚Â± ODRER BY lÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â  quan trÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»?ng
                                v_dsTLLOG = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                                    v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                                    'Create Transaction contents
                                    For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                                        v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                                        v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                                        v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                                        v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                                        'Add field name
                                        v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                        v_attrFLDNAME.Value = v_strFLDNAME
                                        v_entryNode.Attributes.Append(v_attrFLDNAME)

                                        'Add field type
                                        v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                        v_attrDATATYPE.Value = v_strFLDTYPE
                                        v_entryNode.Attributes.Append(v_attrDATATYPE)

                                        'Set value
                                        Select Case v_strFLDNAME
                                            Case "01" 'CODEID
                                                v_strFLDVALUE = v_strCODEID
                                            Case "07" 'SYMBOL
                                                v_strFLDVALUE = v_strSYMBOL
                                            Case "02" 'ACTYPE
                                                v_strFLDVALUE = v_strACTYPE
                                            Case "03" 'AFACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO
                                            Case "50" 'CUSTNAME 'Lay lam thong tin nguoi dat lenh
                                                v_strFLDVALUE = ""
                                            Case "05" 'CIACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO
                                            Case "06" 'SEACCTNO
                                                v_strFLDVALUE = v_strAFACCTNO & v_strCODEID
                                            Case "20" 'TIMETYPE                                       
                                                v_strFLDVALUE = v_strTIMETYPE
                                            Case "21" 'EXPDATE                                       
                                                v_strFLDVALUE = v_strTXDATE
                                            Case "22" 'EXECTYPE  
                                                v_strFLDVALUE = v_strEXECTYPE
                                                'v_strFLDVALUE = cboExecType.SelectedValue
                                            Case "23" 'NORK                                       
                                                v_strFLDVALUE = v_strNORK
                                            Case "24" 'MATCHTYPE                                       
                                                v_strFLDVALUE = v_strMATCHTYPE
                                            Case "25" 'VIA                                       
                                                v_strFLDVALUE = v_strVIA
                                            Case "26" 'CLEARCD                                       
                                                v_strFLDVALUE = v_strCLEARCD
                                            Case "27" 'PRICETYPE                                       
                                                'v_strFLDVALUE = v_strPRICETYPE
                                                v_strFLDVALUE = IIf(v_strPRICETYPE = "SL", "LO", v_strPRICETYPE)
                                            Case "10" 'CLEARDAY
                                                v_strFLDVALUE = v_strCLEARDAY
                                            Case "11" 'QUOTEPRICE
                                                'If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "MO" Then  'Lenh ATO then
                                                v_strFLDVALUE = v_strQUOTEPRICE
                                            Case "12" 'ORDERQTTY                                      
                                                v_strFLDVALUE = v_strQUANTITY
                                            Case "13" 'BRATIO                                      
                                                v_strFLDVALUE = v_dblSecureRatio
                                            Case "14" 'LIMITPRICE
                                                v_strFLDVALUE = v_ds.Tables(0).Rows(i)("PRICE") * CDbl(v_strTRADEUNIT)
                                            Case "40" ' Feeamt
                                                v_strFLDVALUE = "0" 'Tam thoi lay la 0
                                            Case "15" 'PARVALUE
                                                v_strFLDVALUE = v_strPARVALUE
                                            Case "16" 'Original ORDERQTTY (For Adjust Order Only)
                                                v_strFLDVALUE = v_strREFQUANTITY
                                            Case "17" 'Original ORDERPrice (For Adjust Order Only)
                                                v_strFLDVALUE = v_strREFPRICE
                                            Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                                v_strFLDVALUE = v_dblAdvanceSecuredAmount.ToString
                                            Case "28" 'VOUCHER
                                                v_strFLDVALUE = "P"
                                            Case "29" 'CONSULTANT
                                                v_strFLDVALUE = "N"
                                            Case "04" 'ORDERID
                                                v_strFLDVALUE = v_strOrderID
                                            Case "08" 'Cancel Order ID
                                                v_strFLDVALUE = v_strORGACCTNO
                                            Case "30" 'DESC 
                                                v_strFLDVALUE = "GTC" & Strings.Left(v_strOrderID, 4) & "." & Strings.Mid(v_strOrderID, 5, 6) & "." & Strings.Right(v_strOrderID, 6) & "." & Trim(v_strFULLNAME) & "." & v_strMATCHTYPE & "" & v_strEXECTYPE & "." & v_strSYMBOL & "." & v_strQUANTITY & "." & v_strQUOTEPRICE
                                            Case "09" 'Custody Code
                                                v_strFLDVALUE = v_strCUSTODYCD
                                            Case "99" 'Top up
                                                'v_strFLDVALUE = "100"
                                                If v_strMarginType = "N" Then
                                                    v_strFLDVALUE = "100"
                                                Else
                                                    If v_dblIsPPUsed = 1 Then
                                                        v_strFLDVALUE = CStr(100 / (1 - v_dblMarginRatioRate / 100 * v_dblSecMarginPrice / CDbl(v_strQUOTEPRICE) / (v_strTRADEUNIT)))
                                                    Else
                                                        v_strFLDVALUE = "100"
                                                    End If
                                                End If
                                            Case "98" 'TradeUnit
                                                v_strFLDVALUE = v_strTRADEUNIT
                                            Case "97" 'Mode dat lenh
                                                v_strFLDVALUE = "A"
                                            Case "96"
                                                v_strFLDVALUE = 1
                                            Case "60" 'Is mortage
                                                v_strFLDVALUE = IIf(v_strEXECTYPE = "MS", 1, 0)
                                        End Select
                                        v_entryNode.InnerText = v_strFLDVALUE

                                        v_dataElement.AppendChild(v_entryNode)
                                    Next
                                    v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                                End If
                            End If
                        End If
                        'Ghi nhan vao TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        'II. Execute message
                        '-----------------------
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                            'Cap nhat trang thai tro lai FOMAST
                            v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_ds.Tables(0).Rows(i)("ACCTNO") & " :[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            'Luu lai trang lenh da day
                            v_strSQL = "INSERT INTO FOMASTLOG(ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,SENDDT) SELECT ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS') SENDDT FROM FOMAST WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_blnOK = False
                        End If
                        If v_blnOK Then
                            'Doc tu TLLOG len de thuc hien
                            v_strTXNUM = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                            v_strTXDATE = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                            Dim v_obj As New txRouter
                            v_lngErrCode = v_obj.ExecuteFOMessage(v_strTXDATE, v_strTXNUM)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                v_strErrorMessage = v_DataAccess.GetErrorMessage(v_lngErrCode)
                                'Cap nhat trang thai tro lai FOMAST
                                v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_ds.Tables(0).Rows(i)("ACCTNO") & " :[" & v_lngErrCode & "] " & v_strErrorMessage & " ' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                v_blnOK = False
                            Else
                                v_strSQL = "UPDATE FOMAST SET ORGACCTNO='" & v_strOrderID & "', STATUS='A',FEEDBACKMSG='Order is active and sucessfull processed: " & v_strOrderID.ToString & "' WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            End If
                            'Luu lai trang lenh da day
                            v_strSQL = "INSERT INTO FOMASTLOG(ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,SENDDT) SELECT ACCTNO,ACTYPE,AFACCTNO,STATUS,EXECTYPE,PRICETYPE,TIMETYPE,MATCHTYPE,NORK,CLEARCD,CLEARDAY,CODEID,SYMBOL,QUANTITY,PRICE,QUOTEPRICE,TRIGGERPRICE,EXECQTTY,EXECAMT,REMAINQTTY,CANCELQTTY,AMENDQTTY,CONFIRMEDVIA,BOOK,ORGACCTNO,REFACCTNO,REFQUANTITY,REFPRICE,REFQUOTEPRICE,FEEDBACKMSG,ACTIVATEDT,CREATEDDT,REFORDERID,REFUSERNAME,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,DELTD,OUTPRICEALLOW,TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS') SENDDT FROM FOMAST WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Next
                End If
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
            v_objMessageLog = Nothing
        End Try
    End Function

    Overridable Function BuildFOTxMsg(ByRef v_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "HOST.SystemAdmin.BuildFOTxMsg", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg, v_strTxNum, v_strTxDate, v_strPrevDate, v_strNextDate As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'LÃ¡ÂºÂ¥y sÃ¡Â»â€˜ chÃ¡Â»Â©ng tÃ¡Â»Â«
            v_strTxNum = FO_PREFIXED & Right(gc_FORMAT_BATCHTXNUm & CStr(v_obj.GetIDValue("FOTXNUM")), Len(gc_FORMAT_BATCHTXNUm) - Len(FO_PREFIXED))
            'LÃ¡ÂºÂ¥y ngÃƒÂ y lÃƒÂ m viÃ¡Â»â€¡c hiÃ¡Â»â€¡n tÃ¡ÂºÂ¡i
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTxDate)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'TÃ¡ÂºÂ¡o message trÃ¡ÂºÂ£ vÃ¡Â»?
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTranS, gc_IsNotLocalMsg, , HO_BRID, ADMIN_ID, "HOST", "HOST")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxNum
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxDate
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "FO"
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function BuildGeneralViewTxMsg(ByRef v_xmlDocument As Xml.XmlDocument, ByVal v_strDetailBatchName As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin..BuildGeneralViewTxMsg", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg, v_strTxNum, v_strTxDate, v_strPrevDate, v_strNextDate As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Get HostTime for transact
            v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
            Dim v_strHostTime As String
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHostTime = v_ds.Tables(0).Rows(0)("TXTIME")
            Else
                v_strHostTime = "00:00:00"
            End If
            'LÃ¡ÂºÂ¥y sÃ¡Â»â€˜ chÃ¡Â»Â©ng tÃ¡Â»Â«
            v_strTxNum = BATCH_PREFIXED & Right(gc_FORMAT_GENERALVIEWTXNUm & CStr(v_obj.GetIDValue("GENERALVIEWTXNUM")), Len(gc_FORMAT_GENERALVIEWTXNUm) - Len(GV_PREFIXED))
            'LÃ¡ÂºÂ¥y ngÃƒÂ y lÃƒÂ m viÃ¡Â»â€¡c hiÃ¡Â»â€¡n tÃ¡ÂºÂ¡i
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTxDate)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'TÃ¡ÂºÂ¡o message trÃ¡ÂºÂ£ vÃ¡Â»?
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTranS, gc_IsNotLocalMsg, , "0000", "0000", "HOST", "HOST")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxNum
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxDate
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strHostTime
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = v_strDetailBatchName
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ProcessGatewayMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ProcessGatewayMessage", v_strErrorMessage As String
        Dim v_xmlParaDocument As New Xml.XmlDocument
        Dim v_xmlDocument As New Xml.XmlDocument
        'Dim v_xmlTXMessage As New Xml.XmlDocument
        Dim v_xmlTXMessage As New XmlDocumentEx
        Dim mv_XMLBuffer As New Xml.XmlDocument
        Dim v_spmCaching As New spRouter
        Dim v_DataAccess As New DataAccess
        Dim v_objMessageLog As New MessageLog

        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute, v_nodeData, v_nodetxData As Xml.XmlNode
        Dim v_strTxdate, v_strTxtime, v_strTxnum, v_strExtRefnum, v_strAutoID, v_strMapFLDCD, v_strVALUE As String, v_ds As DataSet
        Try
            'Lay thong tin xu ly cua dien giao dich
            v_xmlDocument.LoadXml(pv_strObjMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strParametersArray As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_xmlParaDocument.LoadXml(v_strParametersArray)

            Dim v_strRefSource, v_strRefNum, v_strBranchID, v_strTellerID, v_strWSNAME, v_strIPADDRESS, v_strTXTYPE As String
            Dim v_strSQL, v_strTLTXCD, v_strCacheTLTXData As String, v_strCNTRECORD As Integer
            v_strIPADDRESS = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value
            v_strWSNAME = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeWSNAME).Value
            v_strBranchID = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            v_strTellerID = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            v_strTLTXCD = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            v_strTXTYPE = v_xmlParaDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value
            v_strRefSource = v_xmlParaDocument.DocumentElement.Attributes("SRC").Value
            v_strRefNum = v_xmlParaDocument.DocumentElement.Attributes("REFNUM").Value
            v_strErrorSource = v_strErrorSource & " [" & v_strRefSource & "]"

            v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME, VARVALUE TXDATE FROM SYSVAR WHERE VARNAME='CURRDATE' AND GRNAME='SYSTEM'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTxtime = v_ds.Tables(0).Rows(0)("TXTIME")
                v_strTxdate = v_ds.Tables(0).Rows(0)("TXDATE")
            Else
                v_strTxtime = "00:00:00"
            End If

            Dim v_strHOSTATUS As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strHOSTATUS)
            If v_lngErrCode = ERR_SYSTEM_OK Then
                If v_strHOSTATUS <> OPERATION_ACTIVE Then
                    v_lngErrCode = ERR_SA_HOST_OPERATION_ISINACTIVE
                End If
            End If

            If v_lngErrCode = ERR_SYSTEM_OK Then
                If v_strTXTYPE = "I" Then
                    v_strTxnum = BATCH_PREFIXED & Right(gc_FORMAT_GENERALVIEWTXNUm & CStr(v_DataAccess.GetIDValue("GENERALVIEWTXNUM")), Len(gc_FORMAT_GENERALVIEWTXNUm) - Len(GV_PREFIXED))
                    v_strCacheTLTXData = BuildXMLTxMsg(gc_MsgTypeTranS, gc_IsNotLocalMsg, v_strTLTXCD, v_strBranchID, v_strTellerID, v_strIPADDRESS, v_strWSNAME, "I", "1", , , , , , , , , , , , , , , , , , , , , , , )
                    v_xmlTXMessage.LoadXml(v_strCacheTLTXData)
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxnum
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxdate
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "GV"
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strTxtime
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value = v_strTellerID

                    Dim v_entryNode As Xml.XmlNode, v_dataElement As Xml.XmlElement
                    Dim v_attrDEFNAME As Xml.XmlAttribute
                    Dim v_strMapFLDNAME, v_strMapFLDTYPE As String

                    v_dataElement = v_xmlTXMessage.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                    'Map PARA va FLDMASTER: Chi quet parameters trong danh sach
                    v_nodeData = v_xmlParaDocument.SelectSingleNode("parameters")
                    For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                        v_strMapFLDCD = v_nodeData.ChildNodes(i).Attributes("FLDCD").Value
                        v_strMapFLDNAME = v_nodeData.ChildNodes(i).InnerText
                        v_strMapFLDTYPE = v_nodeData.ChildNodes(i).Attributes("FLDTYPE").Value

                        v_entryNode = v_xmlTXMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        'Add field name
                        v_attrFLDNAME = v_xmlTXMessage.CreateAttribute(gc_AtributeFLDNAME)
                        v_attrFLDNAME.Value = v_strMapFLDCD
                        v_entryNode.Attributes.Append(v_attrFLDNAME)

                        'Add field type
                        v_attrDATATYPE = v_xmlTXMessage.CreateAttribute(gc_AtributeFLDTYPE)
                        v_attrDATATYPE.Value = v_strMapFLDTYPE
                        v_entryNode.Attributes.Append(v_attrDATATYPE)

                        'Add coloum name
                        v_attrDEFNAME = v_xmlTXMessage.CreateAttribute(gc_AtributeDEFNAME)
                        v_attrDEFNAME.Value = v_strMapFLDNAME
                        v_entryNode.Attributes.Append(v_attrDEFNAME)

                        'Set value
                        v_entryNode.InnerText = v_nodeData.ChildNodes(i).InnerXml

                        v_dataElement.AppendChild(v_entryNode)
                    Next

                    v_xmlTXMessage.DocumentElement.AppendChild(v_dataElement)


                    Dim v_miscRouter As New miscRouter
                    v_lngErrCode = v_miscRouter.Transact(v_xmlTXMessage)

                Else
                    v_strSQL = "SELECT RETURNMSG, NVL(ERRNUM,0) ERRNUM FROM GWLOG WHERE REFNUM = '" & v_strRefNum & "' AND GWSTATUS <> 'P' "
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count = 1 Then
                        pv_strObjMsg = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RETURNMSG"))
                        v_lngErrCode = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ERRNUM"))
                        Return v_lngErrCode
                    End If

                    'Lay cache khung giao dich
                    v_strCacheTLTXData = v_spmCaching.TLTXGetPropertyValue(v_strTLTXCD)
                    If v_strCacheTLTXData.Length > 0 Then
                        mv_XMLBuffer.LoadXml(v_strCacheTLTXData)
                        v_strCacheTLTXData = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText
                    End If

                    'TAO GIAO DICH
                    If v_strCacheTLTXData.Length > 0 Then
                        v_strTxnum = BATCH_PREFIXED & Right(gc_FORMAT_GENERALVIEWTXNUm & CStr(v_DataAccess.GetIDValue("GENERALVIEWTXNUM")), Len(gc_FORMAT_GENERALVIEWTXNUm) - Len(GV_PREFIXED))
                        v_xmlTXMessage.LoadXml(v_strCacheTLTXData)
                        v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxnum
                        v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxdate
                        v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "GV"
                        v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
                    Else
                        v_lngErrCode = BuildGeneralViewTxMsg(v_xmlTXMessage, "GV")
                    End If
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strTxtime
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
                    v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value = v_strTellerID   'Ko can duyet qui trinh                

                    'Map PARA va FLDMASTER: Chi quet parameters trong danh sach
                    v_nodeData = v_xmlParaDocument.SelectSingleNode("parameters")
                    For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                        v_strMapFLDCD = v_nodeData.ChildNodes(i).Attributes("FLDCD").Value
                        v_nodetxData = v_xmlTXMessage.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strMapFLDCD & "']")
                        If Not v_nodetxData Is Nothing Then
                            v_nodetxData.InnerText = v_nodeData.ChildNodes(i).InnerXml
                        End If
                    Next

                    'Ghi nhan vao trong tllog
                    v_lngErrCode = v_objMessageLog.TransLog(v_xmlTXMessage)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If

                    'Sau khi ghi nhan se doc len de thuc hien giao dich
                    v_strTxnum = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                    v_strTxdate = v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                    Dim v_TXRouter As New txRouter
                    'v_lngErrCode = v_TXRouter.ExecuteGVTxMessage(v_strTxdate, v_strTxnum)
                    v_lngErrCode = v_TXRouter.ExecuteGVTxMessage(v_strTxdate, v_strTxnum)
                End If
            End If

            v_strAutoID = CStr(v_DataAccess.GetIDValue("GWLOG"))
            v_strExtRefnum = "I" & v_strTxdate.Replace("/", String.Empty) & v_strAutoID

            Dim v_ErrStringBuilder As New StringBuilder, v_strDataMsg As String

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strENErrMsg, v_strVNErrMsg As String
                v_strSQL = "SELECT ERRDESC, EN_ERRDESC FROM DEFERROR WHERE ERRNUM = " & v_lngErrCode
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    v_strENErrMsg = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EN_ERRDESC"))
                    v_strVNErrMsg = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ERRDESC"))
                    v_ErrStringBuilder.Append("<ERR ERRNUM='" & v_lngErrCode.ToString() & "'>")
                    v_ErrStringBuilder.Append("<EXTREFNUM>" & v_strExtRefnum & "</EXTREFNUM>")
                    v_ErrStringBuilder.Append("<EN>" & v_strENErrMsg & "</EN>")
                    v_ErrStringBuilder.Append("<VN>" & v_strVNErrMsg & "</VN>")
                    v_ErrStringBuilder.Append("</ERR>")
                Else
                    v_ErrStringBuilder.Append("<ERR ERRNUM='" & v_lngErrCode.ToString() & "'>")
                    v_ErrStringBuilder.Append("<EXTREFNUM>" & v_strExtRefnum & "</EXTREFNUM>")
                    v_ErrStringBuilder.Append("<EN>Undefined error!</EN>")
                    v_ErrStringBuilder.Append("<VN>Lá»—i chÆ°a Ä‘Æ°á»£c Ä‘á»‹nh nghÄ©a</VN>")
                    v_ErrStringBuilder.Append("</ERR>")
                End If
            Else
                v_ErrStringBuilder.Append("<ERR ERRNUM='0'>")
                v_ErrStringBuilder.Append("<EXTREFNUM>" & v_strExtRefnum & "</EXTREFNUM>")
                v_ErrStringBuilder.Append("<EN>Processing sucessfully!</EN>")
                v_ErrStringBuilder.Append("<VN>Xá»­ lÃ½ thÃ nh cÃ´ng</VN>")
                v_ErrStringBuilder.Append("</ERR>")
            End If

            v_strErrorMessage = v_ErrStringBuilder.ToString

            If Not v_xmlTXMessage Is Nothing Then
                v_nodeData = v_xmlTXMessage.SelectSingleNode("TransactMessage/ObjData")
                If Not v_nodeData Is Nothing Then
                    v_strDataMsg = v_nodeData.InnerXml()
                End If
            End If


            pv_strObjMsg = "<RETURNMESSAGE><ObjData>" & v_strDataMsg & "</ObjData>" & v_strErrorMessage & "</RETURNMESSAGE>"

            Dim v_strReturnMsg As String = IIf(v_strTXTYPE = "I", v_strErrorMessage, pv_strObjMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                v_strSQL = "INSERT INTO GWLOG (AUTOID, GWDIRECTION, TXDATE, TXNUM, REFNUM, REFSRC, REMOTEIPADDR, REMOTEWSNAME, REFBRID, REFTLID, EXTREFNUM, GWTIME, GWSTATUS, MSGDTL, RETURNMSG, ERRNUM) " & ControlChars.CrLf _
                    & "SELECT " & v_strAutoID & ", 'I', TO_DATE('" & v_strTxdate & "', '" & gc_FORMAT_DATE & "'), '" & v_strTxnum & "','" & v_strRefNum & "','" & v_strRefSource & "'," & ControlChars.CrLf _
                    & "'" & v_strIPADDRESS & "','" & v_strWSNAME & "','" & v_strBranchID & "','" & v_strTellerID & "','" & v_strExtRefnum & "', to_char(sysdate,'hh24:mi:ss'), 'E', " & ControlChars.CrLf _
                    & "'" & v_strParametersArray.Replace("'", "''") & "','" & v_strReturnMsg.Replace("'", "''") & "'," & v_lngErrCode & " FROM DUAL"
            Else
                v_strSQL = "INSERT INTO GWLOG (AUTOID, GWDIRECTION, TXDATE, TXNUM, REFNUM, REFSRC, REMOTEIPADDR, REMOTEWSNAME, REFBRID, REFTLID, EXTREFNUM, GWTIME, GWSTATUS, MSGDTL, RETURNMSG, ERRNUM) " & ControlChars.CrLf _
                    & "SELECT " & v_strAutoID & ", 'I', TO_DATE('" & v_strTxdate & "', '" & gc_FORMAT_DATE & "'), '" & v_strTxnum & "','" & v_strRefNum & "','" & v_strRefSource & "'," & ControlChars.CrLf _
                    & "'" & v_strIPADDRESS & "','" & v_strWSNAME & "','" & v_strBranchID & "','" & v_strTellerID & "','" & v_strExtRefnum & "', to_char(sysdate,'hh24:mi:ss'), 'A', " & ControlChars.CrLf _
                    & "'" & v_strParametersArray.Replace("'", "''") & "','" & v_strReturnMsg.Replace("'", "''") & "',NULL FROM DUAL"
            End If
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_strExtRefnum
            'pv_strObjMsg = v_xmlDocument.InnerXml
            'v_xmlTXMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_strExtRefnum
            'pv_strObjMsg = v_xmlTXMessage.InnerXml

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not v_ds Is Nothing Then v_ds.Dispose()
            v_xmlParaDocument = Nothing
            v_xmlDocument = Nothing
            v_xmlTXMessage = Nothing
            mv_XMLBuffer = Nothing
            v_spmCaching = Nothing
            v_objMessageLog = Nothing
            'TruongLD Comment when convert
            'v_DataAccess.Dispose()
        End Try
    End Function


    ''Thuc hien ghi log giao dich
    Public Function TransTLLOGEXT(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.TransTLLOGEXT", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_strFLDCD, v_strFLDTYPE, v_strVALUE, v_dblVALUE As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_xmlTx As New Xml.XmlDocument
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strTxMsg As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strRefKeyVal As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Dim v_strType As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strRefObj As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            v_xmlTx.LoadXml(v_strTxMsg)

            Dim v_strTLTXCD, v_strTXNUM, v_strTXDATE, v_strTXSTATUS, v_strDELTD As String
            v_strTLTXCD = v_xmlTx.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            v_strTXNUM = v_xmlTx.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            v_strTXDATE = v_xmlTx.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            v_strTXSTATUS = v_xmlTx.DocumentElement.Attributes(gc_AtributeSTATUS).Value
            v_strDELTD = v_xmlTx.DocumentElement.Attributes(gc_AtributeDELTD).Value


            Select Case v_strType
                Case "I"
                    'Insert TllogExt
                    v_strSQL = "SELECT COUNT(*) CN FROM TLLOGEXT WHERE TXNUM ='" & v_strTXNUM & "'  AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)("CN") = 0 Then
                        v_strSQL = "INSERT INTO TLLOGEXT (TXDATE,TXNUM,TLTXCD,REFOBJ,REFKEY,STATUS,DELTD) VALUES (TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" _
                                               & v_strTXNUM & "','" & v_strTLTXCD & "','" & v_strRefObj & "','" & v_strRefKeyVal & "','" & v_strTXSTATUS & "','" & v_strDELTD & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                Case "U"
                    'Check xem da co ban ghi chua. Neu chua co thi thuc hien Insert
                    v_strSQL = "SELECT COUNT(*) CN FROM TLLOGEXT WHERE TXNUM ='" & v_strTXNUM & "'  AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)("CN") = 0 Then
                        v_strSQL = "INSERT INTO TLLOGEXT (TXDATE,TXNUM,TLTXCD,REFOBJ,REFKEY,STATUS,DELTD) VALUES (TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" _
                                               & v_strTXNUM & "','" & v_strTLTXCD & "','" & v_strRefObj & "','" & v_strRefKeyVal & "','" & v_strTXSTATUS & "','" & v_strDELTD & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    'update TllogExt
                    v_strSQL = "UPDATE TLLOGEXT SET STATUS = '" & v_strTXSTATUS & "'  WHERE TXNUM='" & v_strTXNUM & "'  AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Case "D"
                    'Delete TllogExt
                    v_strSQL = "UPDATE TLLOGEXT SET DELTD = '" & v_strDELTD & "'  WHERE TXNUM='" & v_strTXNUM & "'  AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End Select

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CoreBankHoldQueueExecute(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTransferEODPreport(ByVal pv_strObjMessage As String) As Long

    End Function

    Public Function CoreBankTransferReport(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankGetReportSts(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankGetBalance(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankGetTransList(ByRef pv_strObjMsg As String) As Long

    End Function

    Private Function GetReferenceValueForAMTEXP(ByRef pv_xmlDocument As Xml.XmlDocument, ByVal pv_strREFVAL As String) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GetReferenceValueForAMTEXP", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds, v_dsACTYPE As DataSet
        Dim v_strVALUE As String, v_nodetxData As Xml.XmlNode, v_objEval As New Evaluator
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            If Len(pv_strREFVAL) > 0 Then
                If Left(pv_strREFVAL, 1) = "@" Then
                    v_strVALUE = Mid(pv_strREFVAL, 2)
                ElseIf Left(pv_strREFVAL, 1) = "$" Or Left(pv_strREFVAL, 1) = "#" Then
                    'Get field code
                    v_strVALUE = Mid(pv_strREFVAL, 2)
                    'Get field value
                    v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                    v_strVALUE = v_nodetxData.InnerText
                ElseIf pv_strREFVAL = "<$BUSDATE>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strVALUE)
                ElseIf pv_strREFVAL = "<$TXDATE>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strVALUE)
                ElseIf pv_strREFVAL = "<$COMPANYNAME>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "COMPANYNAME", v_strVALUE)
                Else
                    'Armethic expression
                    v_strVALUE = v_objEval.Eval(BuildAMTEXP(pv_xmlDocument, pv_strREFVAL)).ToString
                End If
            End If
            Return v_strVALUE
        Catch ex As Exception
            ex.Source = v_strErrorSource
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_objEval = Nothing
            v_DataAccess = Nothing
        End Try

    End Function

    Private Function BuildAMTEXP(ByVal pv_xmlDocument As Xml.XmlDocument, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent As String
            Dim v_lngIndex As Long
            Dim v_nodetxData As Xml.XmlNode
            Dim v_strFEEAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).Value.ToString
            Dim v_strVATAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).Value.ToString

            v_strFEEAMT = IIf(v_strFEEAMT.Length = 0, "0", v_strFEEAMT)
            v_strVATAMT = IIf(v_strVATAMT.Length = 0, "0", v_strVATAMT)

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "FF"
                        'Fee amount
                        v_strEvaluator = v_strEvaluator & v_strFEEAMT
                    Case "VV"
                        'VAT amount
                        v_strEvaluator = v_strEvaluator & v_strVATAMT
                    Case "++", "--", "**", "//", "((", "))"
                        'Operand
                        v_strEvaluator = v_strEvaluator & Left$(v_strElemenent, 1)
                    Case "@1"
                        'Operand
                        v_strEvaluator = v_strEvaluator & "1"
                    Case Else
                        'Operator
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strElemenent & "']")
                        v_strEvaluator = v_strEvaluator & v_nodetxData.InnerText
                End Select
                v_lngIndex = v_lngIndex + 2
            End While
            Complete() 'ContextUtil.SetComplete()
            Return v_strEvaluator
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CoreBankDirectHold(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CoreBankDirectHold", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_DataAccess As New DataAccess()
        Dim v_strReference, v_strSQL As String
        Dim v_ds As DataSet
        Dim i, v_nRow As Integer, v_strTLTXCD, v_strTLID, v_strBRID, v_strDELTD, v_strSTATUS, v_strTXDATE, v_strTXNUM As String
        Dim v_strTRFCODE, v_strTRFCODEORG, v_strFLDACCTNO, _strFLDREFCODE, v_strAMTEXP, v_strFLDREFCODE,
            v_strAFACCTNO, v_strREFCODE, v_strFLDAFFECTDATE, v_strAFFECTDATE, v_strVALUE As String
        Dim v_xmlTxDocument As New XmlDocument()
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            'Lay cac thong so tu client chuyen len
            v_xmlDocument = New XmlDocument
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_strReference = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value.ToString)

            'Truong hop hold truoc khi tao dien giao dich
            If v_strReference.StartsWith("<![CDATA[") Then
                v_xmlTxDocument.LoadXml(v_strReference.Replace("<![CDATA[", "").Replace("]]>", ""))
                If Not v_xmlTxDocument Is Nothing Then
                    v_strTLTXCD = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
                    v_strTLID = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
                    v_strBRID = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
                    v_strTXDATE = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                    v_strTXNUM = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                    v_strDELTD = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
                    v_strSTATUS = v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
                    Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
                    Dim v_strMSGTYPE As String = Trim(v_xmlTxDocument.DocumentElement.Attributes(gc_AtributeMSGTYPE).Value.ToString)

                    If v_strSTATUS = TransactStatus.Deleting Then
                        v_blnReversal = True
                    End If

                    If v_strMSGTYPE = "T" AndAlso Not v_blnReversal Then
                        v_strSQL = "SELECT OBJTYPE, OBJNAME, TRFCODE, FLDBANK, FLDACCTNO, FLDBANKACCT, FLDREFCODE,AFFECTDATE, FLDNOTES, AMTEXP " &
                                    "FROM CRBTXMAP MST WHERE MST.OBJTYPE = 'D' AND MST.OBJNAME = '" & v_strTLTXCD & "'"
                        v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            'Một giao dịch cho phép khai báo tạo ra nhiều hơn một bảng kê
                            For v_nRow = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                                'Ghi nhận vào bảng CRBTXREQ
                                v_strTRFCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("TRFCODE")).Trim
                                v_strFLDACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDACCTNO")).Trim
                                v_strFLDREFCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDREFCODE")).Trim
                                v_strFLDAFFECTDATE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("AFFECTDATE")).Trim
                                v_strAMTEXP = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("AMTEXP")).Trim
                                v_strTRFCODEORG = v_strTRFCODE

                                If v_strFLDREFCODE.Length = 0 Then
                                    v_strREFCODE = v_strTXDATE & v_strTXNUM
                                Else
                                    v_strREFCODE = GetReferenceValueForAMTEXP(v_xmlTxDocument, v_strFLDREFCODE)
                                End If

                                If String.IsNullOrEmpty(v_strFLDAFFECTDATE) OrElse v_strFLDAFFECTDATE = "<$TXDATE>" Then
                                    v_strAFFECTDATE = v_strTXDATE
                                Else
                                    v_strAFFECTDATE = GetReferenceValueForAMTEXP(v_xmlTxDocument, v_strFLDAFFECTDATE)
                                End If

                                'Trong truong hop mot giao dich co nhieu ma trfcode thi phai lay lai trfcode do
                                If Left(v_strTRFCODE, 1) = "$" Then
                                    'Lấy trfcode theo giá trị lựa chọn trên màn hình giao dịch
                                    v_strTRFCODE = GetReferenceValueForAMTEXP(v_xmlTxDocument, v_strTRFCODE)
                                End If

                                If v_strTRFCODE = "UNHOLD" Then
                                    v_strTRFCODE = "UH"
                                ElseIf v_strTLTXCD = "1120" Or v_strTLTXCD = "1130" Then
                                    v_strTRFCODE = "HA" 'Hold Advance
                                Else
                                    v_strTRFCODE = "HL"
                                End If

                                v_strAFACCTNO = GetReferenceValueForAMTEXP(v_xmlTxDocument, v_strFLDACCTNO)
                                v_strVALUE = GetReferenceValueForAMTEXP(v_xmlTxDocument, v_strAMTEXP)
                                If CDbl(v_strVALUE) > 0 Then
                                    v_lngErrCode = CoreBankDirectAction(v_strTRFCODE & "|" & v_strAFACCTNO & "|" & v_strVALUE, v_strTXNUM)
                                    If v_lngErrCode = ERR_SYSTEM_OK Then
                                        Complete()
                                    Else
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            Else
                v_lngErrCode = CoreBankDirectAction(v_strReference, String.Empty)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            v_strErrorMessage = ex.Message
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Function

    Public Function CoreBankDirectFOHold(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CoreBankDirectFOHold", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strReference, v_strInputData As String
        Try
            'Lay cac thong so tu client chuyen len
            v_xmlDocument = New XmlDocument
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_strInputData = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeRESERVER).Value.ToString)
            v_strReference = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value.ToString)
            v_lngErrCode = CoreBankDirectAction(v_strInputData, v_strReference)
            Return v_lngErrCode
        Catch ex As Exception
            v_strErrorMessage = ex.Message
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Function


    Public Function CoreBankDirectAction(ByVal pv_strIn As String, ByVal pv_strRefTxnum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CoreBankDirectAction", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess,
        v_objMessageLog As New MessageLog, v_txRouter As New txRouter
        Dim v_strCURRDATE, v_strTxTime, v_strAFACCTNO, v_strAction, v_strTLTX, v_strTxNum, v_strTxMsg As String
        Dim v_strCustodyCD, v_strBankAcctNo, v_strBANKCODE, v_strBANKNAME, v_strCUSTNAME, v_strADDRESS, v_strLICENSE As String
        Dim v_lngAmount, v_lngMustHold As Long

        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute

        Dim v_ds As DataSet
        Dim v_strHoldDesc, v_strUnholdDesc As String
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_objMessageLog.NewDBInstance(gc_MODULE_HOST)

            v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_DataAccess.GetSysVar("SYSTEM", "SYSTIME", v_strTxTime)

            v_strAction = pv_strIn.Split("|".ToCharArray())(0)
            v_strAFACCTNO = pv_strIn.Split("|".ToCharArray())(1)

            '--Patten: NB|AFACCTNO|ACTYPE|SYMBOL|QTTY|PRICE
            '--Patten: AB|AFACCTNO|ACTYPE|SYMBOL|QTTY|PRICE|ORGORDERID
            '--Patten: HL|AFACCTNO|AMOUNT

            '25/03/2016 - TruongLD them --> TT NH = Offline --> Khong goi qua NH nua --> Return luon
            '25/03/2016 - TruongLD them --> TT NH = Online & ngoai gio GD ==> khong hold nua.
            Dim v_strStatus As String = "O"
            Dim v_strISRun As String = "N"
            v_strSQL = "SELECT CRB.STATUS, FN_CHECKCOREBANKTRADINGTIME(CRB.BANKCODE) ISRUN " &
                       "FROM CRBDEFBANK CRB, AFMAST AF " &
                       "WHERE CRB.BANKCODE = AF.BANKNAME AND AF.ACCTNO ='" & v_strAFACCTNO & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strStatus = v_ds.Tables(0).Rows(0)("STATUS")
                v_strISRun = v_ds.Tables(0).Rows(0)("ISRUN")
            End If

            If v_strStatus = ConfigurationSettings.AppSettings("BankConnMode") Then
                LogError.Write("CoreBankDirectAction:CRBDEFBANK Not Call to Bank: " & v_strStatus, "EventLogEntryType.Error")
                Return v_lngErrCode
            ElseIf v_strISRun = "Y" Then
                'Neu KH dat lenh trong thoi gian CUT OF TIME cua BIDV --> reset BANKAVLBAL = 0
                Dim v_objParam As New StoreParameter
                Dim v_arrPara(1) As StoreParameter
                v_objParam.ParamName = "p_strAcctno"
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamValue = v_strAFACCTNO
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_err_code"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = ""
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(1) = v_objParam
                v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.pr_ResetBANKAVLBAL", v_arrPara, 1)
                Return ERR_SYSTEM_OK
            End If
            LogError.Write("CoreBankDirectAction:CRBDEFBANK Call to Bank: " & v_strISRun, "EventLogEntryType.Error")
            'End TruongLD

            v_strHoldDesc = "Tạm giữ tiền thực hiện giao dịch"
            v_strUnholdDesc = "Giải toả tiền thực hiện giao dịch"
            If v_strAction = "NB" Then
                v_strHoldDesc = "Tạm giữ tiền lệnh mua " & pv_strIn.Split("|".ToCharArray())(3) & " KL " & pv_strIn.Split("|".ToCharArray())(4) & " giá " & pv_strIn.Split("|".ToCharArray())(5)
            ElseIf v_strAction = "AB" Then
                v_strHoldDesc = "Tạm giữ tiền sửa lệnh mua " & pv_strIn.Split("|".ToCharArray())(3) & " KL " & pv_strIn.Split("|".ToCharArray())(4) & " giá " & pv_strIn.Split("|".ToCharArray())(5)
            End If

            If v_strAction = "HA" Then ' Thuc truy van de lay lai so du Ngan Hang moi nhat
                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , v_strAFACCTNO)
                v_lngErrCode = CoreBankGetBalance(v_strObjMsg)
            End If



            'Neu la unhold thi khong can tinh
            If v_strAction = "UH" Then
                v_lngAmount = Convert.ToDouble(pv_strIn.Split("|".ToCharArray())(2))
                v_strTLTX = gc_RM_UNHOLD_DIRECT

            ElseIf v_strAction = "HO" Then
                v_lngAmount = Convert.ToDouble(pv_strIn.Split("|".ToCharArray())(2))
                v_strTLTX = gc_RM_HOLD_DIRECT
                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , v_strAFACCTNO)
                v_lngErrCode = CoreBankGetBalance(v_strObjMsg)
            Else
                'Con lai thi phai tinh toan so du hold xem co du ko
                v_strTLTX = gc_RM_HOLD_DIRECT
                Dim v_objParam As New StoreParameter
                Dim v_arrPara(2) As StoreParameter
                v_objParam.ParamName = "p_strIn"
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamValue = pv_strIn
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_holdamt"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = v_lngAmount.ToString()
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.Int64).Name
                v_arrPara(1) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_err_code"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = ""
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(2) = v_objParam

                '09/05/2015 DieuNDA: Them doan check neu suc mua du thi khong can hold
                v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.pr_PreCaculateHoldAmount", v_arrPara, 2)
                v_lngAmount = 0
                If Not IsNumeric(v_arrPara(2).ParamValue) Then
                    v_lngErrCode = 0
                Else
                    v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                End If

                If Not IsNumeric(v_arrPara(1).ParamValue) Then
                    v_lngMustHold = 0
                Else
                    v_lngMustHold = Convert.ToInt64(v_arrPara(1).ParamValue)
                End If



                If v_lngMustHold = 1 Then
                    Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , v_strAFACCTNO)
                    v_lngErrCode = CoreBankGetBalance(v_strObjMsg)

                    v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.pr_CaculateHoldAmount", v_arrPara, 2)
                    If Not IsNumeric(v_arrPara(2).ParamValue) Then
                        v_lngErrCode = 0
                    Else
                        v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                    End If

                    If Not IsNumeric(v_arrPara(1).ParamValue) Then
                        v_lngAmount = 0
                    Else
                        v_lngAmount = Convert.ToInt64(v_arrPara(1).ParamValue)
                    End If

                End If
                'End

                'v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.pr_CaculateHoldAmount", v_arrPara, 2)
                'If Not IsNumeric(v_arrPara(2).ParamValue) Then
                '    v_lngErrCode = 0
                'Else
                '    v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                'End If

                'If Not IsNumeric(v_arrPara(1).ParamValue) Then
                '    v_lngAmount = 0
                'Else
                '    v_lngAmount = Convert.ToInt64(v_arrPara(1).ParamValue)
                'End If


            End If

            If v_lngAmount > 0 Then
                'Neu co hold thi lam giao dich
                'Lay thong tin co ban ra
                v_strSQL = "SELECT CF.CUSTODYCD,CF.FULLNAME CUSTNAME,CF.ADDRESS,CF.IDCODE LICENSE," & vbCrLf &
                           "AF.BANKACCTNO,CRB.BANKCODE,CRB.BANKCODE||':'||CRB.BANKNAME BANKNAME" & vbCrLf &
                           "FROM AFMAST AF,CFMAST CF,CRBDEFBANK CRB,CIMAST CI" & vbCrLf &
                           "WHERE AF.CUSTID=CF.CUSTID AND AF.ACCTNO=CI.AFACCTNO AND (case when ci.corebank = 'Y' then ci.corebank else af.alternateacct end)='Y'" & vbCrLf &
                           "AND AF.BANKNAME=CRB.BANKCODE AND AF.ACCTNO='" & v_strAFACCTNO & "' "
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCustodyCD = v_ds.Tables(0).Rows(0)("CUSTODYCD").ToString()
                    v_strBankAcctNo = v_ds.Tables(0).Rows(0)("BANKACCTNO").ToString()
                    v_strBANKCODE = v_ds.Tables(0).Rows(0)("BANKCODE").ToString()
                    v_strBANKNAME = v_ds.Tables(0).Rows(0)("BANKNAME").ToString()
                    v_strCUSTNAME = v_ds.Tables(0).Rows(0)("CUSTNAME").ToString()
                    v_strADDRESS = v_ds.Tables(0).Rows(0)("ADDRESS").ToString()
                    v_strLICENSE = v_ds.Tables(0).Rows(0)("LICENSE").ToString()

                    'Build giao dich
                    v_strTxNum = COREBANK_PREFIXED & Right(gc_FORMAT_COREBANKTXNUM &
                                 CStr(v_DataAccess.GetIDValue("COREBANKTXNUM")),
                                 Len(gc_FORMAT_COREBANKTXNUM) - Len(COREBANK_PREFIXED))
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsNotLocalMsg,
                                               , "0000", "0000", "HOST", "HOST")

                    v_xmlDocument = New XmlDocument
                    v_xmlDocument.LoadXml(v_strTxMsg)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxNum
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTX
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strCURRDATE
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value = v_strTxTime
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "BANK"
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)

                    'Lay cac field ra
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE TRIM(OBJNAME)='" & v_strTLTX & "' ORDER BY ODRNUM"
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                        For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "88" 'CUSTODYCD
                                    v_strVALUE = v_strCustodyCD
                                Case "03" 'SECACCOUNT
                                    v_strVALUE = v_strAFACCTNO
                                Case "90" 'CUSTNAME
                                    v_strVALUE = Replace(v_strCUSTNAME, "'", "''")
                                Case "91" 'ADDRESS
                                    v_strVALUE = Replace(v_strADDRESS, "'", "''")
                                Case "92" 'LICENSE
                                    v_strVALUE = v_strLICENSE
                                Case "93" 'BANACCOUNT
                                    v_strVALUE = v_strBankAcctNo
                                Case "94" 'BANKNAME
                                    v_strVALUE = v_strBANKCODE & ":" & v_strBANKNAME
                                Case "95" 'BANKQUEUE
                                    v_strVALUE = v_strBANKCODE
                                Case "10" 'AMOUNT
                                    v_strVALUE = v_lngAmount.ToString()
                                Case "30" 'DESC
                                    If v_strTLTX = gc_RM_HOLD_DIRECT Then
                                        v_strVALUE = v_strHoldDesc '"Tạm giữ tiền thực hiện giao dịch"
                                    Else
                                        v_strVALUE = v_strUnholdDesc '"Giải toả tiền thực hiện giao dịch"
                                    End If
                                Case Else
                                    If v_strFLDTYPE = "C" Then
                                        v_strVALUE = ""
                                    Else
                                        v_strVALUE = "0"
                                    End If
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhan vao TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode = ERR_SYSTEM_OK Then
                            'Goi ham thuc hien giao dich
                            v_lngErrCode = v_txRouter.ExecuteTxMessage(v_strCURRDATE, v_strTxNum)
                            If v_lngErrCode = ERR_SYSTEM_OK Then
                                'Cap nhat vao crbtxreq voi txnum,txdate ngay hien tai truyen vao
                                If Not String.IsNullOrEmpty(pv_strRefTxnum) Then
                                    v_strSQL = "UPDATE CRBTXREQ SET REFTXNUM='" & pv_strRefTxnum & "'," & vbCrLf &
                                                "REFTXDATE=TO_DATE('" & v_strCURRDATE & "','DD/MM/RRRR') WHERE OBJKEY='" & v_strTxNum & "'"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                                Complete()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return v_lngErrCode
    End Function

    Public Function CoreBankTCDTRequestTransfer(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTCDTTransferReconcide(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTCDTSendReconcide(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTCDTGetTransferResult(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTCDTGetBankList(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function CoreBankTCDTGetCreditList(ByRef pv_strObjMsg As String) As Long

    End Function

    Public Function BuyFeeTransfer(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.BuyFeeTransfer", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "BFEETRF"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function ExecuteCA3384(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteCA3384", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEXCA3384"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Public Function ExecuteCA3386(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteCA3386", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEXCA3386"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteCA3350(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteCA3350", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEXCA3350"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ProcessFeeCalculate(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ProcessFeeCalculate", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(0) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_odproc.pr_ODProcessFeeCalculate", v_arrPara, 0)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Function ProcessClearOrder(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ProcessClearOrder", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "pv_exectype"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "ALL"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_odproc.pr_CancelOrderAfterDay", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteCA3350DF(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteCA3350DF", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEXCA3350DF"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteRM8879(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteRM8879", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEX8879"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteRM8879DF(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteRM8879DF", v_strErrorMessage As String
        Dim v_obj As New DataAccess()
        Dim v_strErr_Out As String
        Dim v_strReturn As String

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Thuc hien cac buoc batch du bi truoc
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_batchname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "RMEX8879DF"
            v_objParam.ParamSize = 100
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            'Batch
            v_strReturn = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RunningRMBatch", v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteCoreBankDBBatch(ByVal pv_strBatchName As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteDBBatch", v_strErrorMessage As String
        Dim v_strErr_Out As String
        Dim v_strReturn As String
        Dim v_obj As New DataAccess()
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Goi batch de thuc hien
            Dim v_arrPara(1) As StoreParameter

            Dim v_objParam As New StoreParameter()
            v_objParam.ParamName = "p_bchmdl"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_strBatchName
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter()
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam

            v_strReturn = v_obj.ExecuteOracleStored("txpks_batch.pr_rm" & pv_strBatchName, v_arrPara, 1)
            v_lngErrCode = Convert.ToInt64(v_strReturn)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If

            v_lngErrCode = ExecuteGenBankRQS(pv_strBatchName)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If

            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Public Function ExecuteGenBankRQS(ByVal pv_strBatchName As String) As Long
        Dim v_strErrorSource As String = "Host.SystemAdmin.ExecuteRM8879DF", v_strErrorMessage As String
        Dim v_strSQL, v_strTLTXCD As String, v_dsTMP As DataSet
        Dim v_DataAccess As New DataAccess()
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            'Kiem tra neu giao dich trong Batch co tao bang ke thi goi ham xu ly yeu cau tao bang ke luon
            v_strSQL = "SELECT DISTINCT LG.TLTXCD FROM TLLOG LG, CRBTXMAP RF WHERE LG.TLTXCD=RF.OBJNAME AND RF.OBJTYPE='T' AND LG.DELTD<>'Y' AND LG.TXSTATUS='1' AND LG.BATCHNAME='" & pv_strBatchName.Trim & "'"
            v_dsTMP = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsTMP.Tables(0).Rows.Count > 0 Then
                Dim v_objParam As New StoreParameter
                For i As Integer = 0 To v_dsTMP.Tables(0).Rows.Count - 1
                    v_strTLTXCD = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(i)("TLTXCD"))
                    'Goi ham tao bang ke truyen TXDATE=NULL de hieu la ngay lam viec hien tai
                    Dim v_arrPara(2) As StoreParameter
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_code"
                    v_objParam.ParamValue = "0"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_tltxcd"
                    v_objParam.ParamValue = v_strTLTXCD
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_txdate"
                    v_objParam.ParamValue = ""
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(2) = v_objParam

                    v_lngErrCode = v_DataAccess.ExecuteOracleStored("cspks_rmproc.SP_EXEC_CREATE_CRBTXREQ_TLTXCD", v_arrPara, 0)
                    v_strSQL = String.Empty
                Next
            End If
        Catch ex As Exception
            v_lngErrCode = ERR_SYSTEM_START
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return v_lngErrCode
    End Function

    Function ValidatePassword(ByVal pwd As String, ByVal oldpwd As String) As Long

        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim v_special As String = ConfigurationManager.AppSettings.Get("Special_letters")
        Dim special As New System.Text.RegularExpressions.Regex(v_special)

        'Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")

        If pwd = oldpwd Then Return ERR_SA_CHANGEPASS_INPUTINCORRECT - 3
        ' Check the length.
        If Len(pwd) < CInt(ConfigurationManager.AppSettings.Get("PASS_LEN")) Then Return ERR_SA_CHANGEPASS_INPUTINCORRECT - 4

        ' Check for minimum number of occurrences.        
        If lower.Matches(pwd).Count < 1 Then Return ERR_SA_CHANGEPASS_INPUTINCORRECT
        'If upper.Matches(pwd).Count >= 1 Then score = score + 1
        If number.Matches(pwd).Count < 1 Then Return ERR_SA_CHANGEPASS_INPUTINCORRECT
        If special.Matches(pwd).Count < 1 Then Return ERR_SA_CHANGEPASS_INPUTINCORRECT - 5

        ' Passed all checks.
        Return ERR_SYSTEM_OK
    End Function

#End Region

End Class
