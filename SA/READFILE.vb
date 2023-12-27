Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class READFILE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Private mDelimiterRows As Char = "|"
    Private mDelimiterItems As Char = "~"

    Public Sub New()
        ATTR_TABLE = "READFILE"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ImportXMLFileToDB"
                    v_lngErrCode = ImportXMLFileToDB(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        v_strMessage = pv_xmlDocument.InnerXml
                        Return v_lngErrCode
                    End If
                Case "RejectImportFile"
                    v_lngErrCode = RejectImportFile(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "ImportXMLFileToDBTable"
                    v_lngErrCode = ImportXMLFileToDBTable(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "ImportXMLFileToDBTradingResult"
                    v_lngErrCode = ImportXMLFileToDBTradingResult(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "CompareDBTradingResult"
                    v_lngErrCode = CompareDBTradingResult(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "ImportXMLFileASTDL"
                    v_lngErrCode = ImportXMLFileASTDL(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "EXPORTEXCELCV"
                    v_lngErrCode = EXPORTEXCELCV(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "CLEARDATACV"
                    v_lngErrCode = CLEARDATACV(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "IMPTABLECV"
                    v_lngErrCode = IMPTABLECV(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "ImportXMLFileToDBCV"
                    v_lngErrCode = ImportXMLFileToDBCV(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

            End Select

            'ContextUtil.SetComplete()S
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ImportXMLFileToDBCV(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.ImportXMLFileToDB", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String
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
            'Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            'ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            'For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
            '    v_arrSumAmount(ik) = 0
            'Next
            'Inquiry data
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
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"


            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)

            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TABLENAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
            Else
                'Tra ve ma loi
                Return -1
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
                'v_sql = "TRUNCATE TABLE " & v_strTablename
                'v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

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

                v_strFeedBackMsg = "Tổng số bản ghi: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
                'For ih As Integer = 0 To v_arrSumAmount.GetLength(0) - 1
                '    If v_arrTypeClause(ih) = "N" Then
                '        v_strFeedBackMsg = v_strFeedBackMsg & "Tổng giá trị (" & v_arrTitleClause(ih) & "): " & v_arrSumAmount(ih).ToString & ControlChars.CrLf
                '    End If
                'Next
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

                '    If Len(Trim(v_strProcFillter)) > 0 Then
                '        'Goi store procedure fillter neu co khai bao can fillter
                '        Dim v_objParam As New StoreParameter
                '        Dim v_arrPara(2) As StoreParameter
                '        v_objParam.ParamName = "p_tlid"
                '        v_objParam.ParamDirection = ParameterDirection.Input
                '        v_objParam.ParamValue = v_strTellerID
                '        v_objParam.ParamSize = 100
                '        v_objParam.ParamType = GetType(System.String).Name
                '        v_arrPara(0) = v_objParam

                '        v_objParam = New StoreParameter
                '        v_objParam.ParamName = "p_err_param"
                '        v_objParam.ParamDirection = ParameterDirection.Output
                '        v_objParam.ParamValue = ""
                '        v_objParam.ParamSize = 100
                '        v_objParam.ParamType = GetType(System.String).Name
                '        v_arrPara(1) = v_objParam

                '        v_objParam = New StoreParameter
                '        v_objParam.ParamName = "p_err_message"
                '        v_objParam.ParamDirection = ParameterDirection.Output
                '        v_objParam.ParamValue = ""
                '        v_objParam.ParamSize = 100
                '        v_objParam.ParamType = GetType(System.String).Name
                '        v_arrPara(2) = v_objParam
                '        v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcFillter, v_arrPara, 2)

                '        If Not IsNumeric(v_arrPara(1).ParamValue) Then
                '            v_lngErrCode = 0
                '        Else
                '            v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                '        End If
                '    End If
                'End If
                'If v_strIsApprove = "Y" Or v_strOVRRQD = "N" Then
                '    'Neu khong can duyet thong tin hoac dang o buoc duyet thi thuc hien ghi du lieu tu Temp sang dile du lieu
                '    'Sau khi insert xong, thuc hien dong bo du lieu 
                '    'Goi store procedure
                '    Dim v_objParam As New StoreParameter
                '    Dim v_arrPara(2) As StoreParameter
                '    v_objParam.ParamName = "p_tlid"
                '    v_objParam.ParamDirection = ParameterDirection.Input
                '    v_objParam.ParamValue = v_strTellerID
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(0) = v_objParam

                '    v_objParam = New StoreParameter
                '    v_objParam.ParamName = "p_err_param"
                '    v_objParam.ParamDirection = ParameterDirection.Output
                '    v_objParam.ParamValue = ""
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(1) = v_objParam

                '    v_objParam = New StoreParameter
                '    v_objParam.ParamName = "p_err_message"
                '    v_objParam.ParamDirection = ParameterDirection.Output
                '    v_objParam.ParamValue = ""
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(2) = v_objParam
                '    v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcname, v_arrPara, 2)
                '    If Not IsNumeric(v_arrPara(1).ParamValue) Then
                '        v_lngErrCode = 0
                '    Else
                '        v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                '    End If
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function
    Private Function EXPORTEXCELCV(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.EXPORTEXCELCV", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String
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
            Dim V_RPTID As String
            v_sql = "SELECT * FROM filemaster WHERE eori='C' ORDER BY FILECODE "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)

            If v_ds.Tables(0).Rows.Count > 0 Then

                For I As Integer = 0 To v_ds.Tables(0).Rows.Count
                    v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(I)("TABLENAME"))
                    v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(I)("PROCNAME"))
                    v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(I)("PROCFILLTER"))
                    v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(I)("ROWTITLE"))
                    v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(I)("OVRRQD"))
                    V_RPTID = gf_CorrectStringField(v_ds.Tables(0).Rows(I)("RPTID"))

                    Dim v_ds_CV As New DataSet
                    Dim v_ds_CV_HCM As New DataSet

                    If V_RPTID = "N" Then
                        v_ds_CV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, "SELECT ROWNUM STT, A.* FROM V_" & v_strTablename & " A")
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            ExcelLibrary.DataSetHelper.CreateWorkbook(v_strClause & v_strTablename & ".XLS", v_ds_CV)
                        End If
                    Else
                        v_ds_CV = v_obj.ExecuteSQLReturnDataset(CommandType.Text, "SELECT ROWNUM STT, A.* FROM V_" & v_strTablename & " A WHERE A.BRID ='0001'")
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            ExcelLibrary.DataSetHelper.CreateWorkbook(v_strClause & v_strTablename & "_HN.XLS", v_ds_CV)
                        End If

                        v_ds_CV_HCM = v_obj.ExecuteSQLReturnDataset(CommandType.Text, "SELECT ROWNUM STT, A.* FROM V_" & v_strTablename & " A WHERE A.BRID ='0101' ")
                        If v_ds_CV_HCM.Tables(0).Rows.Count > 0 Then
                            ExcelLibrary.DataSetHelper.CreateWorkbook(v_strClause & v_strTablename & "_HCM.XLS", v_ds_CV_HCM)
                        End If
                    End If
                Next
            Else
                'Tra ve ma loi
                Return -1
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function

    Private Function IMPTABLECV(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.CLEARDATACV", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String
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



            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_strSQL As String

            v_strSQL = "BEGIN  pks_covert_flex.ImpTableConvert(); END; "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = String.Empty



            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function

    Private Function CLEARDATACV(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.CLEARDATACV", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String
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



            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_strSQL As String

            v_strSQL = "BEGIN  pks_covert_flex.Cleandata(); END; "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = String.Empty



            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function
    Private Function ImportXMLFileASTDL(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRADING_RESULT.ImportXMLFileASTDL", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
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

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split("|")

            Dim v_strtype = v_strFileCode.Split(":")
            If (v_strtype(1) = "LO") Then
                v_obj.ExecuteNonQuery(CommandType.Text, "TRUNCATE TABLE FILE_ASTDL")
                For i As Integer = 0 To v_arrClause.Count - 2
                    v_obj.ExecuteNonQuery(CommandType.Text, v_arrClause(i))
                Next
            Else
                v_obj.ExecuteNonQuery(CommandType.Text, "TRUNCATE TABLE FILE_ASTPT")
                For i As Integer = 0 To v_arrClause.Count - 2
                    v_obj.ExecuteNonQuery(CommandType.Text, v_arrClause(i))
                Next
            End If



            
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try


    End Function


    Private Function CompareDBTradingResult(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRADING_RESULT.CompareDBTradingResult", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
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

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strtype = v_strFileCode.Split(":")
            If (v_strtype(0) = "HO") Then
                If v_strtype(1) = "LO" Then
                    'Goi store procedure
                    v_obj.ExecuteNonQuery(CommandType.Text, "BEGIN prc_compare_horesult(); END; ")
                    Dim v_sql As String
                    Dim v_dsresult As New DataSet
                    v_sql = "SELECT ROWNUM AUTOID, CONFIRM_NO,TXDATE,SYMBOL,PRICE,QTTY,MATCHAMOUNT,BORS,CUSTODYCD, REASON FROM TRADINGRESULTEXP "
                    v_dsresult = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                    Dim v_strvalue As String = String.Empty
                    Dim v_strBuffer As New System.Text.StringBuilder
                    'Gan title
                    If v_dsresult.Tables(0).Rows.Count > 0 Then
                        For Each dtrow As DataRow In v_dsresult.Tables(0).Rows
                            For i As Integer = 0 To v_dsresult.Tables(0).Columns.Count - 1
                                If dtrow(i) Is DBNull.Value Then
                                    v_strvalue = String.Empty
                                Else : v_strvalue = dtrow(i)
                                End If
                                If dtrow(i).ToString = "N" Then
                                    v_strvalue = "Deal khớp trên SGDCK, core chưa khớp"
                                ElseIf dtrow(i).ToString = "P" Then
                                    v_strvalue = "Deal khớp, nhưng không có trên SGKCK"
                                End If
                                v_strBuffer.Append("" & v_strvalue & ":")
                            Next
                            v_strBuffer.Append("|")
                        Next
                        pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strBuffer.ToString
                    Else : pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = String.Empty

                    End If
                Else
                    v_obj.ExecuteNonQuery(CommandType.Text, "BEGIN prc_compare_hoptresult(); END; ")
                    Dim v_sql As String
                    Dim v_dsresult As New DataSet
                    v_sql = "SELECT ROWNUM AUTOID, CONFIRM_NO,TXDATE,SYMBOL,PRICE,QTTY,MATCHAMOUNT,BORS,CUSTODYCD,REASON FROM TRADINGRESULTEXP "
                    v_dsresult = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                    Dim v_strvalue As String = String.Empty
                    Dim v_strBuffer As New System.Text.StringBuilder
                    'Gan title
                    If v_dsresult.Tables(0).Rows.Count > 0 Then
                        For Each dtrow As DataRow In v_dsresult.Tables(0).Rows
                            For i As Integer = 0 To v_dsresult.Tables(0).Columns.Count - 1
                                If dtrow(i) Is DBNull.Value Then
                                    v_strvalue = String.Empty
                                Else : v_strvalue = dtrow(i)
                                End If
                                If dtrow(i).ToString = "N" Then
                                    v_strvalue = "Deal khớp trên SGDCK, core chưa khớp"
                                ElseIf dtrow(i).ToString = "P" Then
                                    v_strvalue = "Deal khớp, nhưng không có trên SGKCK"
                                End If
                                v_strBuffer.Append("" & v_strvalue & ":")
                            Next
                            v_strBuffer.Append("|")
                        Next
                        pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strBuffer.ToString
                    Else : pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = String.Empty

                    End If
                End If
            Else
                Dim v_ds As New DataSet
                Dim v_sql As String
                Dim v_strTablename As String
                Dim v_strProcname As String
                Dim v_IntRowtitle As Integer
                v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strTablename = v_ds.Tables(0).Rows(0)("TABLENAME")
                    v_strProcname = v_ds.Tables(0).Rows(0)("PROCNAME")
                    v_IntRowtitle = v_ds.Tables(0).Rows(0)("ROWTITLE")
                Else
                    'Tra ve ma loi
                    Return -1
                End If

                'Goi store procedure

                v_obj.ExecuteNonQuery(CommandType.Text, "BEGIN " & v_strProcname & "(); END; ")

                Dim v_dsresult As New DataSet
                v_sql = "SELECT ROWNUM AUTOID,TXDATE,SYMBOL,PRICE,QTTY,MATCHAMOUNT,BORS,CUSTODYCD,REASON FROM TRADINGRESULTEXP ORDER BY AUTOID ASC "
                v_dsresult = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                Dim v_strvalue As String = String.Empty
                Dim v_strBuffer As New System.Text.StringBuilder
                'Gan title
                If v_dsresult.Tables(0).Rows.Count > 0 Then
                    For Each dtrow As DataRow In v_dsresult.Tables(0).Rows
                        For i As Integer = 0 To v_dsresult.Tables(0).Columns.Count - 1
                            If dtrow(i) Is DBNull.Value Then
                                v_strvalue = String.Empty
                            Else : v_strvalue = dtrow(i)
                            End If
                            If dtrow(i).ToString = "N" Then
                                v_strvalue = "Deal khớp trên SGDCK, core chưa khớp"
                            ElseIf dtrow(i).ToString = "P" Then
                                v_strvalue = "Deal khớp, nhưng không có trên SGKCK"
                            End If
                            v_strBuffer.Append("" & v_strvalue & ":")
                        Next
                        v_strBuffer.Append("|")
                    Next
                    pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strBuffer.ToString
                Else : pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = String.Empty
                End If
            End If
          

       
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try


    End Function



    Private Function ImportXMLFileToDB(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.ImportXMLFileToDB", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String
            Dim v_strImportbyIndex As String
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
            'Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            'ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            'For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
            '    v_arrSumAmount(ik) = 0
            'Next
            'Inquiry data
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
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TABLENAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
                v_strImportbyIndex = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("IMPBYINDEX"))
            Else
                'Tra ve ma loi
                Return -1
            End If

            Dim v_strFileId As String
            'Xu ly them doan check truoc khi insert
            Try
                Dim v_objParamAd As New StoreParameter
                Dim v_arrParaAd(4) As StoreParameter
                v_objParamAd.ParamName = "p_tlid"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strTellerID
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(0) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_filecode"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strFileCode
                v_objParamAd.ParamSize = 200
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(1) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_fileid"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 200
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(2) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_err_code"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(3) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_err_message"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 4000
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(4) = v_objParamAd
                v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster.PR_PREV_AUTO_FILLER", v_arrParaAd, 4)

                If Not IsNumeric(v_arrParaAd(3).ParamValue) Then
                    v_lngErrCode = 0
                    v_strFileId = v_arrParaAd(2).ParamValue
                Else
                    v_lngErrCode = CDec(v_arrParaAd(3).ParamValue)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'Tra ve ma loi xuat ra tu function
                        pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
                        Rollback()
                        Return v_lngErrCode
                    End If
                    v_strFileId = v_arrParaAd(2).ParamValue
                    pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeAUTOID).Value = v_strFileId

                End If

            Catch ex As Exception
                LogError.WriteException(ex)

            End Try

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
                            'trung.luu cot IMPBYINDEX trong filemap = Y => import theo index cua cot,khong theo header
                            If v_strImportbyIndex = "Y" Then
                                If i.ToString() = CStr(v_ds.Tables(0).Rows(j)("LSTODR")).ToUpper Then
                                    v_strTblFld = v_ds.Tables(0).Rows(j)("tblrowname")
                                    v_arrTypeClause(i) = v_ds.Tables(0).Rows(j)("tblrowtype")
                                    v_strBeginInsertClause = v_strBeginInsertClause & v_strTblFld & ","
                                    Exit For
                                End If
                            Else
                                If v_strFileFld.ToUpper = CStr(v_ds.Tables(0).Rows(j)("FILEROWNAME")).ToUpper Then
                                    v_strTblFld = v_ds.Tables(0).Rows(j)("tblrowname")
                                    v_arrTypeClause(i) = v_ds.Tables(0).Rows(j)("tblrowtype")
                                    v_strBeginInsertClause = v_strBeginInsertClause & v_strTblFld & ","
                                    Exit For
                                End If
                            End If
                        Next
                        'TruongLD Add 20/01/2020, xac dinh cac cot trong file excel
                        If i = v_arrTitleClause.Length - 1 Then
                            Exit For
                        End If
                    Next
                    v_strBeginInsertClause = Strings.Left(v_strBeginInsertClause, v_strBeginInsertClause.Length - 1) & ", fileid" & ")"
                Else
                    'Tra ve ma loi
                    Return -1
                End If
                Dim v_strEndInsertClause, v_strInsertClause As String
                Dim v_strSQL As String
                Dim v_strValueClause As String
                Dim v_strArrValue() As String

                ''Clean old data
                'v_sql = "TRUNCATE TABLE " & v_strTablename
                'v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

                For i As Integer = 1 To v_arrClause.GetLength(0) - 2
                    v_strEndInsertClause = " VALUES ("
                    v_strValueClause = v_arrClause(i)
                    v_strArrValue = v_strValueClause.Split(mDelimiterItems)
                    For j As Integer = 0 To v_strArrValue.GetLength(0) - 1
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
                                If String.Compare(v_strFileCode, "I074") = 0 Then
                                    v_strEndInsertClause = v_strEndInsertClause & "TO_DATE(TO_CHAR(TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','MM/DD/RRRR')),'" & gc_FORMAT_DATE_DB & "')" & ","
                                ElseIf String.Compare(v_strFileCode, "I075") = 0 Then
                                    v_strEndInsertClause = v_strEndInsertClause & "TO_DATE(TO_CHAR(TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','RRRR/MM/DD')),'" & gc_FORMAT_DATE_DB & "')" & ","
                                Else
                                    v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','" & gc_FORMAT_DATE_DB & " hh24:mi:ss')" & ","
                                End If
                        End Select
                    Next
                    v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & ",'" & v_strFileId & "'" & "); "
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

                v_strFeedBackMsg = "Tổng số bản ghi: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
                'For ih As Integer = 0 To v_arrSumAmount.GetLength(0) - 1
                '    If v_arrTypeClause(ih) = "N" Then
                '        v_strFeedBackMsg = v_strFeedBackMsg & "Tổng giá trị (" & v_arrTitleClause(ih) & "): " & v_arrSumAmount(ih).ToString & ControlChars.CrLf
                '    End If
                'Next
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg


                ''-----locpt 20141114 sau khi import thi add them cac thong tin vao bang tam
                Try
                    Dim v_objParamAd As New StoreParameter
                    Dim v_arrParaAd(5) As StoreParameter
                    v_objParamAd.ParamName = "p_tlid"
                    v_objParamAd.ParamDirection = ParameterDirection.Input
                    v_objParamAd.ParamValue = v_strTellerID
                    v_objParamAd.ParamSize = 100
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(0) = v_objParamAd

                    v_objParamAd = New StoreParameter
                    v_objParamAd.ParamName = "p_tableName"
                    v_objParamAd.ParamDirection = ParameterDirection.Input
                    v_objParamAd.ParamValue = v_strTablename
                    v_objParamAd.ParamSize = 200
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(1) = v_objParamAd

                    v_objParamAd = New StoreParameter
                    v_objParamAd.ParamName = "p_filecode"
                    v_objParamAd.ParamDirection = ParameterDirection.Input
                    v_objParamAd.ParamValue = v_strFileCode
                    v_objParamAd.ParamSize = 200
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(2) = v_objParamAd

                    v_objParamAd = New StoreParameter
                    v_objParamAd.ParamName = "p_fileId"
                    v_objParamAd.ParamDirection = ParameterDirection.Input
                    v_objParamAd.ParamValue = v_strFileId
                    v_objParamAd.ParamSize = 200
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(3) = v_objParamAd

                    v_objParamAd = New StoreParameter
                    v_objParamAd.ParamName = "p_err_param"
                    v_objParamAd.ParamDirection = ParameterDirection.Output
                    v_objParamAd.ParamValue = ""
                    v_objParamAd.ParamSize = 100
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(4) = v_objParamAd

                    v_objParamAd = New StoreParameter
                    v_objParamAd.ParamName = "p_err_message"
                    v_objParamAd.ParamDirection = ParameterDirection.Output
                    v_objParamAd.ParamValue = ""
                    v_objParamAd.ParamSize = 4000
                    v_objParamAd.ParamType = GetType(System.String).Name
                    v_arrParaAd(5) = v_objParamAd
                    v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster.PR_AUTO_FILLER", v_arrParaAd, 5)

                    If Not IsNumeric(v_arrParaAd(4).ParamValue) Then
                        v_lngErrCode = 0
                    Else
                        v_lngErrCode = CDec(v_arrParaAd(4).ParamValue)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            'Tra ve ma loi xuat ra tu function
                            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
                            Rollback()
                            Return v_lngErrCode
                        End If

                    End If

                Catch ex As Exception
                    LogError.WriteException(ex)

                End Try

                    '-----end locpt 20141114--------------------------------------------------


                'If Len(Trim(v_strProcFillter)) > 0 Then
                '    'Goi store procedure fillter neu co khai bao can fillter
                '    Dim v_objParam As New StoreParameter
                'Dim v_arrPara(2) As StoreParameter
                '    v_objParam.ParamName = "p_tlid"
                '    v_objParam.ParamDirection = ParameterDirection.Input
                '    v_objParam.ParamValue = v_strTellerID
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(0) = v_objParam

                '    v_objParam = New StoreParameter
                '    v_objParam.ParamName = "p_err_param"
                '    v_objParam.ParamDirection = ParameterDirection.Output
                '    v_objParam.ParamValue = ""
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(1) = v_objParam

                '    v_objParam = New StoreParameter
                '    v_objParam.ParamName = "p_err_message"
                '    v_objParam.ParamDirection = ParameterDirection.Output
                '    v_objParam.ParamValue = ""
                '    v_objParam.ParamSize = 100
                '    v_objParam.ParamType = GetType(System.String).Name
                '    v_arrPara(2) = v_objParam
                '    v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcFillter, v_arrPara, 2)

                '    If Not IsNumeric(v_arrPara(1).ParamValue) Then
                '        v_lngErrCode = 0
                '    Else
                '        v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                '        If v_lngErrCode <> ERR_SYSTEM_OK Then
                '            'Tra ve ma loi xuat ra tu function
                '            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
                '            Return v_lngErrCode
                '        End If

                '    End If
                'End If




            End If
            If v_strIsApprove = "Y" Then
                'If v_strIsApprove = "Y" Or v_strOVRRQD = "N" Then
                'Neu khong can duyet thong tin hoac dang o buoc duyet thi thuc hien ghi du lieu tu Temp sang dile du lieu
                'Sau khi insert xong, thuc hien dong bo du lieu 
                'Goi store procedure
                'Dim v_objParam As New StoreParameter
                'Dim v_arrPara(2) As StoreParameter
                'v_objParam.ParamName = "p_tlid"
                'v_objParam.ParamDirection = ParameterDirection.Input
                'v_objParam.ParamValue = v_strTellerID
                'v_objParam.ParamSize = 100
                'v_objParam.ParamType = GetType(System.String).Name
                'v_arrPara(0) = v_objParam

                'v_objParam = New StoreParameter
                'v_objParam.ParamName = "p_err_param"
                'v_objParam.ParamDirection = ParameterDirection.Output
                'v_objParam.ParamValue = ""
                'v_objParam.ParamSize = 100
                'v_objParam.ParamType = GetType(System.String).Name
                'v_arrPara(1) = v_objParam

                'v_objParam = New StoreParameter
                'v_objParam.ParamName = "p_err_message"
                'v_objParam.ParamDirection = ParameterDirection.Output
                'v_objParam.ParamValue = ""
                'v_objParam.ParamSize = 100
                'v_objParam.ParamType = GetType(System.String).Name
                'v_arrPara(2) = v_objParam
                'v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster." & v_strProcname, v_arrPara, 2)
                'If Not IsNumeric(v_arrPara(1).ParamValue) Then
                '    v_lngErrCode = 0
                'Else
                '    v_lngErrCode = CDec(v_arrPara(1).ParamValue)
                '    If v_lngErrCode <> ERR_SYSTEM_OK Then
                '        'Tra ve ma loi xuat ra tu function
                '        pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
                '        Return v_lngErrCode
                '    End If

                'End If


                ''-----locpt 20141114 sau khi duyet thi cap nhat cac thong tin vao bang tam
                'Try
                '    Dim v_objParamUp As New StoreParameter
                '    Dim v_arrParaUp(3) As StoreParameter
                '    v_objParamUp.ParamName = "p_tlid"
                '    v_objParamUp.ParamDirection = ParameterDirection.Input
                '    v_objParamUp.ParamValue = v_strTellerID
                '    v_objParamUp.ParamSize = 100
                '    v_objParamUp.ParamType = GetType(System.String).Name
                '    v_arrParaUp(0) = v_objParamUp

                '    v_objParamUp = New StoreParameter
                '    v_objParamUp.ParamName = "p_filecode"
                '    v_objParamUp.ParamDirection = ParameterDirection.Input
                '    v_objParamUp.ParamValue = v_strFileCode
                '    v_objParamUp.ParamSize = 100
                '    v_objParamUp.ParamType = GetType(System.String).Name
                '    v_arrParaUp(1) = v_objParamUp

                '    v_objParamUp = New StoreParameter
                '    v_objParamUp.ParamName = "p_err_param"
                '    v_objParamUp.ParamDirection = ParameterDirection.Output
                '    v_objParamUp.ParamValue = ""
                '    v_objParamUp.ParamSize = 100
                '    v_objParamUp.ParamType = GetType(System.String).Name
                '    v_arrParaUp(2) = v_objParamUp

                '    v_objParamUp = New StoreParameter
                '    v_objParamUp.ParamName = "p_err_message"
                '    v_objParamUp.ParamDirection = ParameterDirection.Output
                '    v_objParamUp.ParamValue = ""
                '    v_objParamUp.ParamSize = 100
                '    v_objParamUp.ParamType = GetType(System.String).Name
                '    v_arrParaUp(3) = v_objParamUp
                '    v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster.PR_AUTO_UPDATE_AFPRO", v_arrParaUp, 3)
                'Catch ex1 As Exception
                '    LogError.Write("Error source: " & ex1.Source & vbNewLine _
                '                & "Error code: System error!" & vbNewLine _
                '                & "Error message: " & ex1.Message, EventLogEntryType.Error)

                'End Try


                '-----end locpt 20141114--------------------------------------------------


            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try

        
    End Function


    Private Function ImportXMLFileToDBTradingResult(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRADING_RESULT.ImportTrandingResultToDB", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
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

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            'Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            'ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            'For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
            '    v_arrSumAmount(ik) = 0
            'Next
            'Inquiry data
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
            Dim v_IntRowtitle As Integer
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = v_ds.Tables(0).Rows(0)("TABLENAME")
                v_strProcname = v_ds.Tables(0).Rows(0)("PROCNAME")
                v_IntRowtitle = v_ds.Tables(0).Rows(0)("ROWTITLE")
            Else
                'Tra ve ma loi
                Return ERR_SYSTEM_START
            End If

            Dim v_strBeginInsertClause As String
            v_strBeginInsertClause = "INSERT INTO " & v_strTablename & " ("
            v_sql = "SELECT * FROM filemap WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                    Dim v_strFileFld, v_strTblFld As String
                    v_strFileFld = v_arrTitleClause(i)
                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                        If i = j Then
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
                Return ERR_SYSTEM_START
            End If
            Dim v_strEndInsertClause, v_strInsertClause As String
            Dim v_strSQL As String = String.Empty
            Dim v_DateValue As Date
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
                            v_strEndInsertClause = v_strEndInsertClause & "'" & v_strArrValue(j) & "',"
                        Case "N"
                            v_strEndInsertClause = v_strEndInsertClause & v_strArrValue(j) & ","
                        Case "D"
                            v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & v_strArrValue(j) & "','" & gc_FORMAT_DATE_DB & "')" & ","
                    End Select
                Next
                v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & "); "
                v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause & vbCrLf

                v_strSQL = v_strSQL & v_strInsertClause

                If i Mod gc_EXECUTE_ROWS = 0 Then
                    v_strSQL = "BEGIN " & v_strSQL & " END;"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = String.Empty
                End If

            Next

            If v_strSQL <> String.Empty Then
                v_strSQL = "BEGIN " & v_strSQL & " END;"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = String.Empty
            End If

            v_strFeedBackMsg = "Tổng số bản ghi: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
            'For ih As Integer = 0 To v_arrSumAmount.GetLength(0) - 1
            '    If v_arrTypeClause(ih) = "N" Then
            '        v_strFeedBackMsg = v_strFeedBackMsg & "Tổng giá trị (" & v_arrTitleClause(ih) & "): " & v_arrSumAmount(ih).ToString & ControlChars.CrLf
            '    End If
            'Next
            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            'Sau khi insert xong, thuc hien dong bo du lieu 
            'Goi store procedure
            
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function


    Private Function ImportXMLFileToDBTable(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.ImportXMLFileToDBTable", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
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

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                v_arrSumAmount(ik) = 0
            Next
            'Inquiry data
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
            Dim v_IntRowtitle As Integer
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = v_ds.Tables(0).Rows(0)("TABLENAME")
                v_IntRowtitle = v_ds.Tables(0).Rows(0)("ROWTITLE")
            Else
                'Tra ve ma loi
                Return -1
            End If

            Dim v_strBeginInsertClause As String
            v_strBeginInsertClause = "INSERT INTO " & v_strTablename & "DTL" & " ("
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
            Dim v_strSQL As String = String.Empty
            Dim v_strValueClause As String
            Dim v_strArrValue() As String

            'Backup old data
            v_sql = "select count(1) from " & v_strTablename & "DTL" & " where status <> 'P'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows(0)(0) <> "0" Then
                v_sql = "insert into " & v_strTablename & "DTL" & "HIST" & " select * from " & v_strTablename
                v_obj.ExecuteNonQuery(CommandType.Text, v_sql)
            End If
            'Clean old data
            v_sql = "delete " & v_strTablename & "DTL"
            v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

            For i As Integer = 1 To v_arrClause.GetLength(0) - 2
                v_strEndInsertClause = " VALUES ("
                v_strValueClause = v_arrClause(i)
                v_strArrValue = v_strValueClause.Split(mDelimiterItems)
                For j As Integer = 0 To v_strArrValue.GetLength(0) - 2
                    Select Case v_arrTypeClause(j)
                        Case "C"
                            v_strEndInsertClause = v_strEndInsertClause & "'" & v_strArrValue(j) & "',"
                        Case "N"
                            v_strEndInsertClause = v_strEndInsertClause & CDbl(v_strArrValue(j)) & ","
                            v_arrSumAmount(j) = v_arrSumAmount(j) + v_strArrValue(j)
                        Case "D"
                            v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & v_strArrValue(j) & "','" & gc_FORMAT_DATE & "')" & ","
                    End Select
                Next
                v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & "); "
                v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause & vbCrLf

                v_strSQL = v_strSQL & v_strInsertClause

                If i Mod gc_EXECUTE_ROWS = 0 Then
                    v_strSQL = "BEGIN " & v_strSQL & "END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

            Next

            If v_strSQL <> String.Empty Then
                v_strSQL = "BEGIN " & v_strSQL & "END; "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Dim v_strBUSDATE As String
            v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
            v_sql = "update " & v_strTablename & "DTL" & " set txcode = (SELECT to_char(to_date('" & v_strBUSDATE & "','DD/MM/RRRR'),'RRRRMMDD') || lpad(nvl(max(to_number(substr(txcode,9,4)))+1,1),4,'0') TXCODE  FROM " & v_strTablename & "DTLHIST WHERE txdate = to_date('" & v_strBUSDATE & "','DD/MM/RRRR')) "
            v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function RejectImportFile(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            'Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.READFILE.RejectImportFile", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID, v_strFileId, v_strTxnum, v_strTxdate As String
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

            'If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
            '    v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            'Else
            '    v_strAutoId = String.Empty
            'End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strFileId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strFileId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXNUM) Is Nothing) Then
                v_strTxnum = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Else
                v_strTxnum = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTxdate = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTxdate = String.Empty
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            'Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            'Inquiry data
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
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TABLENAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
            Else
                'Tra ve ma loi
                Return -1
            End If
            'Bo truncate table thay bang goi ham cspks_filemaster.PR_AUTO_REJECT
            'v_sql = "TRUNCATE TABLE " & v_strTablename
            'v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

            Try
                Dim v_objParamAd As New StoreParameter
                Dim v_arrParaAd(4) As StoreParameter
                v_objParamAd.ParamName = "p_tlid"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strTellerID
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(0) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_filecode"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strFileCode
                v_objParamAd.ParamSize = 200
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(1) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_fileId"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strFileId
                v_objParamAd.ParamSize = 500
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(2) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_err_code"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(3) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_err_message"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 4000
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(4) = v_objParamAd
                v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_filemaster.PR_AUTO_REJECT", v_arrParaAd, 4)

                If Not IsNumeric(v_arrParaAd(3).ParamValue) Then
                    v_lngErrCode = 0
                Else
                    v_lngErrCode = CDec(v_arrParaAd(3).ParamValue)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'Tra ve ma loi xuat ra tu function
                        pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
                        Return v_lngErrCode
                    End If

                End If

            Catch ex As Exception
                LogError.WriteException(ex)

            End Try

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try
    End Function

End Class