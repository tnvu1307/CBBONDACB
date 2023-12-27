Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SBBATCHCTL
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SBBATCHCTL"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'ContextUtil.SetComplete()
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strSQL, v_strClause As String, v_ds As DataSet
        Dim v_strObjMsg As String
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer
        Try
            'Xây dựng các tham số hệ thống
            Dim v_strCURRDATE, v_strNEXTDATE As String
            Dim v_objSBBATCHSTS As New SBBATCHSTS

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'v_strSQL = "SELECT * FROM SBBATCHSTS WHERE BCHDATE = TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND BCHSTS = ' '"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            v_strSQL = "SELECT * FROM SBBATCHSTS WHERE  BCHSTS = ' '"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
            Else

                If Format(DDMMYYYY_SystemDate(v_strCURRDATE), "yyyy") <> Format(DDMMYYYY_SystemDate(v_strNEXTDATE), "yyyy") Then
                    'Là ngày cuối năm
                    v_strClause = "WHERE STATUS = 'Y' "
                ElseIf Format(DDMMYYYY_SystemDate(v_strCURRDATE), "MM") <> Format(DDMMYYYY_SystemDate(v_strNEXTDATE), "MM") And _
                    Format(DDMMYYYY_SystemDate(v_strCURRDATE), "yyyy") = Format(DDMMYYYY_SystemDate(v_strNEXTDATE), "yyyy") Then
                    'Là ngày cuối tháng
                    v_strClause = "WHERE STATUS = 'Y' AND UPPER(RUNAT) <> 'EOY'"
                Else
                    'Là ngày bình thường
                    v_strClause = "WHERE STATUS = 'Y' AND UPPER(RUNAT) <> 'EOY' AND UPPER(RUNAT) <> 'EOM'"
                End If

                v_strSQL = "INSERT INTO SBBATCHSTS " & ControlChars.CrLf & _
                            "SELECT TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') BCHDATE, BCHMDL, ' ' BCHSTS, '' CMPLTIME, ROWPERPAGE,0  " & ControlChars.CrLf & _
                            "FROM SBBATCHCTL " & ControlChars.CrLf & v_strClause & " Order by BCHSQN"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'v_strSQL = "SELECT DISTINCT B.*,A.BCHSUCPAGE FROM SBBATCHSTS A, SBBATCHCTL B WHERE A.BCHMDL = B.BCHMDL AND A.BCHDATE = TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND A.BCHSTS = ' ' ORDER BY B.BCHSQN"
            v_strSQL = "SELECT DISTINCT B.*,A.BCHSUCPAGE,A.BCHDATE FROM SBBATCHSTS A, SBBATCHCTL B WHERE A.BCHMDL = B.BCHMDL AND A.BCHSTS = ' ' AND B.STATUS = 'Y' ORDER BY B.BCHSQN"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SBBATCHSTS, gc_ActionInquiry, v_strSQL)
            pv_xmlDocument.LoadXml(v_strObjMsg)

            v_lngErrCode = v_objSBBATCHSTS.Inquiry(v_strObjMsg)
            v_strMessage = v_strObjMsg
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

End Class
