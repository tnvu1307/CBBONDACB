Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CSVCMP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CSVCMP"
    End Sub
    Private mDelimiterRows As Char = "|"
    Private mDelimiterItems As Char = "~"
    Private mDelimiterRef As Char = "^"
#Region "Overrides Function"
    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName, v_strCMPid As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            v_strCMPid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Select Case v_strFuncName
                Case "getCompare"
                    v_lngErrCode = getCompare(v_strMessage)
                Case "saveCompare"
                    v_lngErrCode = saveCompare(v_strMessage)
                Case "ImportCSVToDB"
                    v_lngErrCode = importCSV(v_strMessage)
                Case "ViewImportCSV"
                    v_lngErrCode = viewImportDetail(v_strMessage)
                Case "apprvImport"
                    v_lngErrCode = apprvoCSV(v_strMessage)
                Case "getFileDetail"
                    v_lngErrCode = getFileDetail(v_strMessage)
            End Select
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SYSTEM_START
        End Try
    End Function
#End Region
#Region "Private Function"
    Private Function getFileDetail(ByRef v_strMessage) As Long
        Dim v_ds, v_retds, v_dataSet As DataSet
        Dim v_dataTable, v_retTable As DataTable
        Dim v_obj As DataAccess
        Dim v_sql, v_data As String
        Dim v_fromRow, v_toRow As Integer
        Dim v_arr(1) As String
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strReference As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_arr = v_strReference.Split(mDelimiterRef)
            v_fromRow = Integer.Parse(v_arr(0))
            v_toRow = Integer.Parse(v_arr(1))
            v_sql = "SELECT vsd.msgbody  FROM (select * from  vsd_csvcontent_log union all select * from VSD_CSVCONTENT_LOGHIST) vsd WHERE autoid = " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_data = v_ds.Tables(0).Rows(0)(0).ToString
            Else
                Return ERR_SYSTEM_START
            End If
            v_dataSet = CommonLib.ConvertXmlToDataSet(v_data)
            'v_dataTable = New DataTable
            'v_dataTable = v_dataSet.Tables(0)
            'v_toRow = Math.Min(v_toRow, v_dataTable.Rows.Count)
            'v_retTable = New DataTable
            'v_retTable = v_dataTable.Copy
            'v_retTable.Clear()
            'For i As Integer = v_fromRow To v_toRow
            '    v_retTable.ImportRow(v_dataTable.Rows(i - 1))
            'Next
            'v_retds = New DataSet
            'v_retds.Tables.Add(v_retTable)
            'Dim v_xml As String = CommonLib.ConvertTableToXml(v_retTable, "MSGBODY")
            BuildXMLObjData(v_dataSet, v_strMessage, , , v_fromRow, v_toRow)



            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function
    Private Function apprvoCSV(ByRef v_strMessage As String) As Long
        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Dim v_arrParam() As String
            'v_arrParam = v_strClause.Split(mDelimiterItems)
            'If Not v_arrParam.Length = 2 Then
            '    Return ERR_SYSTEM_START
            'End If



            Dim v_strProc = "TXPKS_csvCMPmaster.apprvoCSV"
            Dim v_arrRptParam() As StoreParameter
            ReDim v_arrRptParam(2)
            Dim v_objRptParam As StoreParameter = New StoreParameter
            v_objRptParam.ParamName = "pv_FuncType"
            v_objRptParam.ParamValue = v_strClause
            v_objRptParam.ParamSize = CStr(40)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptParam(0) = v_objRptParam
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "pv_err_code"
            v_objRptParam.ParamSize = CStr(40)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptParam(1) = v_objRptParam
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "pv_err_message"
            v_objRptParam.ParamSize = CStr(40)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptParam(2) = v_objRptParam

            v_obj.ExecuteOracleStored(v_strProc, v_arrRptParam, 1)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function
    Private Function getCompare(ByRef v_strMessage As String) As Long
        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strReference As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            Dim v_arrRef() As String = v_strReference.Split(mDelimiterRef)
            Dim v_fromRow As Integer = Integer.Parse(v_arrRef(0))
            Dim v_toRow As Integer = Integer.Parse(v_arrRef(1))
            Dim v_arrParam() As String
            v_arrParam = v_strClause.Split(mDelimiterItems)

            Dim v_strProc = "TXPKS_csvCMPmaster.getCompare"
            Dim v_arrRptParam() As ReportParameters
            ReDim v_arrRptParam(3)
            Dim v_objRptParam As ReportParameters = New ReportParameters
            v_objRptParam.ParamName = "pv_FuncType"
            v_objRptParam.ParamValue = v_arrParam(0)
            v_objRptParam.ParamSize = CStr(40)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptParam(0) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_FileName"
            v_objRptParam.ParamValue = v_arrParam(1)
            v_objRptParam.ParamSize = CStr(40)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptParam(1) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_FromRow"
            v_objRptParam.ParamValue = v_fromRow
            v_objRptParam.ParamSize = CInt(20)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptParam(2) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_ToRow"
            v_objRptParam.ParamValue = v_toRow
            v_objRptParam.ParamSize = CInt(20)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptParam(3) = v_objRptParam
            v_ds = v_obj.ExecuteStoredReturnDataset(v_strProc, v_arrRptParam)
            BuildXMLObjData(v_ds, v_strMessage)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
            Return ERR_SYSTEM_START
        Finally
            If Not v_ds Is Nothing Then
                v_ds.Dispose()
            End If
        End Try
    End Function
    Private Function saveCompare(ByVal v_strMessage As String) As Long
        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strRef As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_date As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Dim v_pageNum As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_arrParr() As String
            v_arrParr = v_strClause.Split(mDelimiterItems)
            Dim v_strSQL As String
            Dim v_SEQ As String
            If v_pageNum = 1 Then
                v_strSQL = "SELECT seq_csvlogcompare.nextval SEQ FROM DUAL"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_SEQ = v_ds.Tables(0).Rows(0)(0)
                v_strSQL = "DELETE csvlogcomparedtl WHERE refautoid IN (SELECT autoid FROM csvlogcompare WHERE comparedate=TO_DATE('{0}','dd/mm/rrrr') AND comparetype='{1}')"
                v_strSQL = String.Format(v_strSQL, v_date, v_arrParr(0))
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "DELETE csvlogcompare WHERE comparedate=TO_DATE('{0}','dd/mm/rrrr') AND comparetype='{1}'"
                v_strSQL = String.Format(v_strSQL, v_date, v_arrParr(0))
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "INSERT INTO csvlogcompare (autoid, tlid, comparedate, comparetime, comparetype) VALUES ({0},'{1}',TO_DATE('{2}','dd/mm/rrrr'),SYSTIMESTAMP,'{3}')"
                v_strSQL = String.Format(v_strSQL, v_SEQ, v_strTLID, v_date, v_arrParr(0))
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "SELECT AUTOID FROM csvlogcompare WHERE tlid = '{0}' AND comparedate = TO_DATE('{1}','DD/MM/RRRR') AND comparetype = '{2}'"
                v_strSQL = String.Format(v_strSQL, v_strTLID, v_date, v_arrParr(0))
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_SEQ = v_ds.Tables(0).Rows(0)(0)
            End If

            Dim v_arrRow() As String
            Dim v_arrCell() As String
            Dim v_arrValue() As String
            v_arrRow = v_strRef.Split(mDelimiterRows)
            v_strSQL = String.Empty
            Dim v_columnName, v_value As String
            Dim v_tmpSQL = "INSERT INTO csvlogcomparedtl (RN,refautoid,column_name,value) VALUES ({0},{1},{2},{3}); "
            Dim v_rowsCount = v_arrRow.Length
            Dim v_rn As Integer
            For i As Integer = 0 To v_rowsCount - 1
                v_arrCell = v_arrRow(i).Split(mDelimiterItems)
                For Each cell In v_arrCell
                    v_arrValue = cell.Split("=")
                    If v_arrValue.Length = 3 Then
                        v_rn = v_arrValue(0).Trim
                        v_columnName = "'" & v_arrValue(1).Trim & "'"
                        v_value = IIf(v_arrValue(2).Trim = "NULL", "NULL", "'" & v_arrValue(2) & "'")
                        v_strSQL = v_strSQL & String.Format(v_tmpSQL, v_rn, v_SEQ, v_columnName, v_value)
                    End If
                Next
                If i Mod gc_EXECUTE_ROWS = 0 Then
                    v_strSQL = "BEGIN " & v_strSQL & "END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = ""
                End If
            Next
            If v_strSQL.Length > 0 Then
                v_strSQL = "BEGIN " & v_strSQL & "END; "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If


        Catch ex As Exception
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function
    Private Function importCSV(ByRef v_strMessage As String) As Long
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String
            Dim v_strCMPID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause, v_strLocal, v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "DS.CSVCMP.importCSV", v_strErrorMessage As String
            Dim v_strFeedBackMsg, v_strIsApprove, v_strOVRRQD, v_strTellerID As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String
            Dim v_strTablename As String
            Dim v_strProcname As String
            Dim v_strProcFillter As String
            Dim v_IntRowtitle As Integer


            'get fileCode from FuncName
            v_sql = "SELECT * FROM csvcompare WHERE cmpid='" & v_strCMPID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strFileCode = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FILECODE"))
            Else
                'Tra ve ma loi
                Return -1
            End If

            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TABLENAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                'v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
            Else
                'Tra ve ma loi
                Return -1
            End If
            v_strOVRRQD = "N"
            v_strIsApprove = "N"
            If v_strOVRRQD = "Y" And v_strIsApprove = "N" Then
                v_sql = "SELECT COUNT(*) NCOUNT FROM " & v_strTablename & " WHERE NVL(deltd,'N') <> 'Y' AND NVL(status,'P') = 'P' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                If v_ds.Tables(0).Rows(0)("NCOUNT") > 0 Then
                    Return -109050
                End If
            End If
            If v_strIsApprove = "N" Then
                'Khong can duyet thong tin thi se thuc hien import du lieu vao file temp
                Dim v_strBeginInsertClause As String
                v_strBeginInsertClause = "INSERT INTO " & v_strTablename & " ("
                v_sql = "SELECT * FROM filemap WHERE filecode='" & v_strFileCode & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                        Dim v_strFileFld, v_strTblFld As String
                        v_strFileFld = v_arrTitleClause(i)
                        For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                            If v_strFileFld.ToUpper = CStr(v_ds.Tables(0).Rows(j)("FILEROWNAME")).ToUpper Then
                                v_strTblFld = v_ds.Tables(0).Rows(j)("tblrowname")
                                v_arrTypeClause(i) = v_ds.Tables(0).Rows(j)("tblrowtype")
                                v_strBeginInsertClause = v_strBeginInsertClause & v_strTblFld & ","
                                Exit For
                            End If
                        Next
                    Next
                    v_strBeginInsertClause = Strings.Left(v_strBeginInsertClause, v_strBeginInsertClause.Length - 1) & ")"
                Else
                    'Tra ve ma loi
                    Return -1
                End If
                Dim v_strEndInsertClause, v_strInsertClause As String
                Dim v_strSQL As String
                Dim v_strValueClause As String
                Dim v_strArrValue() As String

                'Clean old data
                v_sql = "TRUNCATE TABLE " & v_strTablename
                v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

                For i As Integer = 1 To v_arrClause.GetLength(0) - 2
                    v_strEndInsertClause = " VALUES ("
                    v_strValueClause = v_arrClause(i)
                    v_strArrValue = v_strValueClause.Split(mDelimiterItems)
                    For j As Integer = 0 To v_strArrValue.GetLength(0) - 2
                        Select Case v_arrTypeClause(j)
                            Case "C"
                                v_strEndInsertClause = v_strEndInsertClause & "'" & gf_CorrectStringField(v_strArrValue(j)) & "',"
                            Case "N"
                                'QuangVD: sua de tranh loi convert string "" to decimal
                                If (v_strArrValue(j).ToString = "") Then
                                    v_strEndInsertClause = v_strEndInsertClause & "0" & ","
                                Else
                                    v_strEndInsertClause = v_strEndInsertClause & gf_CorrectNumericField(v_strArrValue(j)) & ","
                                End If
                                'QuangVD: end here
                            Case "D"
                                v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','" & gc_FORMAT_DATE & "')" & ","
                        End Select
                    Next
                    v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & "); "
                    v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause & vbCrLf

                    v_strSQL = v_strSQL & v_strInsertClause

                    If i Mod gc_EXECUTE_ROWS = 0 Then
                        v_strSQL = "BEGIN " & v_strSQL & " END; "
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        v_strSQL = String.Empty
                    End If

                Next

                If v_strSQL <> String.Empty Then
                    v_strSQL = "BEGIN " & v_strSQL & " END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = String.Empty
                End If

                'NamTv - chinh sua ngon ngu
                'v_strFeedBackMsg = "Tổng số bản ghi: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
                v_strFeedBackMsg = v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
                'NamTv end
                'For ih As Integer = 0 To v_arrSumAmount.GetLength(0) - 1
                '    If v_arrTypeClause(ih) = "N" Then
                '        v_strFeedBackMsg = v_strFeedBackMsg & "Tổng giá trị (" & v_arrTitleClause(ih) & "): " & v_arrSumAmount(ih).ToString & ControlChars.CrLf
                '    End If
                'Next
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

                If Len(Trim(v_strProcFillter)) > 0 Then
                    'Goi store procedure fillter neu co khai bao can fillter
                    Dim v_objParam As New StoreParameter
                    Dim v_arrPara(2) As StoreParameter
                    v_objParam.ParamName = "p_tlid"
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamValue = v_strTellerID
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_param"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamValue = ""
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_message"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamValue = ""
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(2) = v_objParam
                    v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcFillter, v_arrPara, 2)

                    If Not IsNumeric(v_arrPara(1).ParamValue) Then
                        v_lngErrCode = 0
                    Else
                        v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                    End If
                End If
            End If
            If v_strIsApprove = "Y" Or v_strOVRRQD = "N" Then
                'Neu khong can duyet thong tin hoac dang o buoc duyet thi thuc hien ghi du lieu tu Temp sang dile du lieu
                'Sau khi insert xong, thuc hien dong bo du lieu 
                'Goi store procedure
                Dim v_objParam As New StoreParameter
                Dim v_arrPara(2) As StoreParameter
                v_objParam.ParamName = "p_tlid"
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamValue = v_strTellerID
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_err_param"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = ""
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(1) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_err_message"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = ""
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(2) = v_objParam
                v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcname, v_arrPara, 2)
                If Not IsNumeric(v_arrPara(1).ParamValue) Then
                    v_lngErrCode = 0
                Else
                    v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                End If
                'Namtv FDS so dong du lieu do vao
                'v_strFeedBackMsg = "Tổng số dòng duyệt: " & CStr(v_arrPara(2).ParamValue) & ControlChars.CrLf
                v_strFeedBackMsg = CStr(v_arrPara(2).ParamValue) & ControlChars.CrLf
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
        End Try

    End Function
    Private Function viewImportDetail(ByRef v_strMessage As String) As Long
        Try
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String
            Dim v_strCMPID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause, v_strLocal, v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "DS.CSVCMP.viewImportDetail", v_strErrorMessage As String
            Dim v_strFeedBackMsg, v_strIsApprove, v_strOVRRQD, v_strTellerID As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String
            Dim v_strTablename As String
            Dim v_strProcname As String
            Dim v_strProcFillter As String
            Dim v_IntRowtitle As Integer


            'get fileCode from FuncName
            v_sql = "SELECT * FROM csvcompare WHERE cmpid='" & v_strCMPID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strFileCode = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FILECODE"))
            Else
                'Tra ve ma loi
                Return -1
            End If

            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TABLENAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                'v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
            Else
                'Tra ve ma loi
                Return -1
            End If

            v_sql = "SELECT * FROM " & v_strTablename
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            BuildXMLObjData(v_ds, v_strMessage)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SYSTEM_START 'File du lieu dau vao khong hop le
        End Try
    End Function
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
