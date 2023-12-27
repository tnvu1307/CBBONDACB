Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
'Imports System.EnterpriseServices

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Batch
    Inherits CoreBusiness.Batch

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "SA"
        ''ContextUtil.SetComplete()
    End Sub

    'Hàm thực hiện chạy xử lý Batch của phân hệ nghiệp vụ
    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            'Chuyển đến các bước chạy xử lý của phân hệ nghiệp vụ
            Select Case v_strBCHMDL
                Case "SAGNWK"
                    v_lngErrCode = GeneralWorking()
                Case "SABKDT"
                    v_lngErrCode = BackupData()
                Case "SACWD"
                    'Xu ly cuoi ngay, chuyen sang ngay lam viec moi
                    v_lngErrCode = ChangeWorkingDate()

            End Select

            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#Region " Private Function "
    Private Function GeneralWorking() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteBatchName", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsSeq As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            v_strSQL = "begin GeneralWorking; end;"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function BackupData() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.BackupData", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_intdays As Integer
        Try
            'X�y d?ng c�c tham s? h? th?ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As StoreParameter
            Dim v_arrPara(0) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "INDATE"
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_obj.ExecuteStoredNonQuerry("BACKUPDATA", v_arrPara)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeWorkingDate() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteBatchName", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_ds1, v_dsEx, v_dsSeq As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Xac dinh cac tham so he thong
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE, v_strDUEDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Cap nhat la ingay tinh lai thau chi, lai tien gui
            'v_strSQL = "UPDATE CIMAST SET CRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ODINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat thong tin chung khoan cuoi ngay.
            'v_strSQL = "UPDATE SEMAST SET PREVQTTY=TRADE+MORTAGE+MARGIN+SECURED+BLOCKED+WITHDRAW " & ControlChars.CrLf _
            '    & " WHERE STATUS<>'C'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ''Xoa cac bang __TRAN cua cac phan he nghiep vu
            'v_strSQL = "SELECT FRTABLE, TOTABLE FROM TBLBACKUP WHERE TYPBK='T'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
            '        v_strFRTABLE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FRTABLE")))
            '        v_strTOTABLE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TOTABLE")))
            '        'Sao luu __TRANA
            '        v_strSQL = "INSERT INTO " & v_strTOTABLE & " SELECT DTL.* FROM " & v_strFRTABLE & " DTL, TLLOG, TLTX " & ControlChars.CrLf _
            '                & "WHERE TLLOG.TLTXCD=TLTX.TLTXCD AND TRIM(TLTX.BACKUP)='Y' " & ControlChars.CrLf _
            '                & "AND TLLOG.TXNUM=DTL.TXNUM AND TLLOG.TXDATE=DTL.TXDATE " & ControlChars.CrLf _
            '                & "AND (TRIM(TLLOG.TXSTATUS)='" & TransactStatus.Cashier & "' OR TRIM(TLLOG.TXSTATUS)='" & TransactStatus.Completed & "')"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If

            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
            '        v_strFRTABLE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FRTABLE")))
            '        'Xoa bang __TRAN 
            '        v_strSQL = "DELETE FROM " & v_strFRTABLE
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If

            ''Sao luu du lieu bang TLLOG, TLLOGFLD Cho cac giao dich� BACKUP=Y
            'v_strSQL = "INSERT INTO TLLOGALL SELECT TLLOG.* FROM TLLOG, TLTX " & ControlChars.CrLf _
            '    & "WHERE TLLOG.TLTXCD=TLTX.TLTXCD AND TLTX.BACKUP='Y' " & ControlChars.CrLf _
            '    & "AND (TLLOG.TXSTATUS='" & TransactStatus.Cashier & "' OR TLLOG.TXSTATUS='" & TransactStatus.Completed & "' OR TLLOG.TXSTATUS='" & TransactStatus.Deleting & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'v_strSQL = "INSERT INTO TLLOGFLDALL SELECT DTL.* FROM TLLOGFLD DTL, TLLOG, TLTX " & ControlChars.CrLf _
            '    & "WHERE TLLOG.TLTXCD=TLTX.TLTXCD AND TLTX.BACKUP='Y'  " & ControlChars.CrLf _
            '    & "AND TLLOG.TXNUM=DTL.TXNUM AND TLLOG.TXDATE=DTL.TXDATE " & ControlChars.CrLf _
            '    & "AND (TLLOG.TXSTATUS='" & TransactStatus.Cashier & "' OR TLLOG.TXSTATUS='" & TransactStatus.Completed & "' OR TLLOG.TXSTATUS='" & TransactStatus.Deleting & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            ''Xoa bnag TLLOG va� TLLOGFLD hien tai
            'v_strSQL = "DELETE FROM TLLOG"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'v_strSQL = "DELETE FROM TLLOGFLD"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ''Da khai bao tblbackup: D
            'v_strSQL = "DELETE FROM ODCHANGING"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ''Da khai bao tblbackup: N
            ''Backup ODQUEUE into ODQUEUEALL
            'v_strSQL = "INSERT INTO ODQUEUEALL select * from ODQUEUE"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'v_strSQL = "DELETE from ODQUEUE"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'TruongLD Add 08/03/2010
            Dim v_objParam As New ReportParameters
            Dim v_arrPara(0) As ReportParameters
            v_objParam.ParamName = "pv_TXDATE"
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamSize = 50
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_obj.ExecuteStoredNonQuerry("SP_CHANGEWORKINGDATE", v_arrPara)
            'End TruongLD

            'Cap nhat thong tin vao AVRBAL,AVRBALALL
            Dim v_intNum, v_intBKNUM, v_intNEXTNUM As Int32
            Dim v_strLAST_DAY As String

            v_strSQL = " SELECT TO_CHAR(DT.LAST_DAY,'DD/MM/YYYY') LAST_DAY,DT.NUM,DT.NEXTNUM,DT.BKNUM FROM (SELECT TO_DATE('" & v_strNEXTDATE & "','" & gc_FORMAT_DATE & "')-TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') NUM," & ControlChars.CrLf _
            & "DT.LAST_DAY,TO_DATE('" & v_strNEXTDATE & "','" & gc_FORMAT_DATE & "')- DT.LAST_DAY NEXTNUM,DT.LAST_DAY-TO_DATE('" & v_strCURRDATE & "',' " & gc_FORMAT_DATE & "') BKNUM  FROM (SELECT LAST_DAY(TO_DATE('" & v_strCURRDATE & "','dd/mm/yyyy')) LAST_DAY FROM DUAL ) DT )DT "
            v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds1.Tables(0).Rows.Count > 0 Then
                v_intNum = gf_CorrectStringField(v_ds1.Tables(0).Rows(0)("NUM"))
                v_intBKNUM = gf_CorrectStringField(v_ds1.Tables(0).Rows(0)("BKNUM"))
                v_intNEXTNUM = gf_CorrectStringField(v_ds1.Tables(0).Rows(0)("NEXTNUM"))
                v_strLAST_DAY = gf_CorrectStringField(v_ds1.Tables(0).Rows(0)("LAST_DAY"))
            End If

            ''Cap nhat so du vao AVRBAL
            'v_strSQL = "INSERT INTO AVRBAL SELECT * FROM (SELECT CI.AFACCTNO,TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') TXDATE,CI.BALANCE CIBALANCE,DT.SEBALANCE,CI.BALANCE+DT.SEBALANCE AVRBAL,'EOD' " & ControlChars.CrLf _
            '& "FROM CIMAST CI,(SELECT MAX(SE.AFACCTNO) AFACCTNO,SUM((SE.TRADE + SE.MARGIN + SE.MORTAGE + SE.BLOCKED + SE.SECURED + SE.REPO + SE.DTOCLOSE+SE.WITHDRAW)*SEC.BASICPRICE)  SEBALANCE FROM SEMAST SE,SECURITIES_INFO SEC " & ControlChars.CrLf _
            '& "WHERE SEC.CODEID =SE.CODEID GROUP BY SE.AFACCTNO) DT " & ControlChars.CrLf _
            '& "WHERE CI.AFACCTNO=DT.AFACCTNO ORDER BY AFACCTNO) "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ''Cap nhat vao bang AVRBALALL khi cuoi thang
            'If GetDateValue(v_strCURRDATE, "M") <> GetDateValue(v_strNEXTDATE, "M") Then
            '    v_strSQL = "INSERT INTO AVRBALALL " & ControlChars.CrLf _
            '    & "SELECT DT.*,OD.AVRODPLACE,OD.AVRODMATCH,OD.FEEACR FROM " & ControlChars.CrLf _
            '    & "(SELECT MAX(AFACCTNO) AFACCTNO,MAX(TXDATE) TXDATE,SUM(CIBALANCE)/count(AFACCTNO) CIBALANCE," & ControlChars.CrLf _
            '    & "SUM(SEBALANCE)/count(AFACCTNO) SEBALANCE,SUM(AVRBAL)/count(AFACCTNO)  AVRBAL, 'EOM' " & ControlChars.CrLf _
            '    & "FROM AVRBAL WHERE TXDATE<=TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "') GROUP BY  AFACCTNO) DT " & ControlChars.CrLf _
            '    & " LEFT JOIN " & ControlChars.CrLf _
            '    & "(SELECT OD.AFACCTNO, SUM(OD.QUOTEPRICE*OD.ORDERQTTY) AVRODPLACE , SUM(IO.MATCHPRICE*IO.MATCHQTTY) AVRODMATCH, SUM(OD.FEEACR) FEEACR FROM " & ControlChars.CrLf _
            '    & "(SELECT TXDATE,AFACCTNO,QUOTEPRICE,ORDERQTTY,FEEACR ,ORDERID FROM ODMASTHIST WHERE DELTD <>'Y' " & ControlChars.CrLf _
            '    & "UNION ALL " & ControlChars.CrLf _
            '    & "SELECT TXDATE,AFACCTNO,QUOTEPRICE,ORDERQTTY,FEEACR ,ORDERID FROM ODMAST WHERE DELTD <>'Y' )OD, " & ControlChars.CrLf _
            '    & "(SELECT TXDATE,MATCHPRICE,MATCHQTTY ,ORGORDERID FROM IOD WHERE DELTD <>'Y'" & ControlChars.CrLf _
            '    & "UNION ALL " & ControlChars.CrLf _
            '    & "SELECT TXDATE,MATCHPRICE,MATCHQTTY,ORGORDERID FROM IODHIST WHERE DELTD <>'Y' )IO " & ControlChars.CrLf _
            '    & "WHERE OD.ORDERID =IO.ORGORDERID " & ControlChars.CrLf _
            '    & "AND OD.TXDATE>=TO_DATE(TRUNC(TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "'), 'MM'), 'DD/MM/YYYY')" & ControlChars.CrLf _
            '    & "AND OD.TXDATE<=LAST_DAY(TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "')) " & ControlChars.CrLf _
            '    & "GROUP BY OD.AFACCTNO) OD " & ControlChars.CrLf _
            '    & "ON DT.AFACCTNO=OD.AFACCTNO"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    'Xoa trong AVRBAL khi het thang
            '    v_strSQL = "DELETE FROM AVRBAL WHERE TXDATE <=TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "')"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'End If
            '& "AND IO.TXDATE>=TO_DATE(TRUNC(TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "'), 'MM'), 'DD/MM/YYYY') " & ControlChars.CrLf _
            '& "AND IO.TXDATE<=LAST_DAY(TO_DATE('" & v_strLAST_DAY & "','" & gc_FORMAT_DATE & "')) " & ControlChars.CrLf _

            

            'Kiem tra lich lai suat tha loi, xem co lich nao den ky khong 
            'Neu co lich thoa man thi lay lich setup gan nhat de kich hoat
            Dim v_strRATEID As String
            Dim v_dblAutoid As Double
            v_strSQL = "SELECT * FROM IRRATESCHD WHERE EFFECTIVEDT<=TO_DATE('" & v_strNEXTDATE & "','DD/MM/YYYY') ORDER BY AUTOID"
            v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds1.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds1.Tables(0).Rows.Count - 1
                    v_strRATEID = v_ds1.Tables(0).Rows(i)("RATEID")
                    v_dblAutoid = v_ds1.Tables(0).Rows(i)("AUTOID")
                    '1. CAP NHAT LAI SUAT CU VAO TRONG HIST
                    v_strSQL = "INSERT INTO IRRATEHIST (AUTOID,RATEID,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM, LASTDATE,EFFECTIVEDT,RATETYPE,MODCODE,STATUS) " & ControlChars.CrLf _
                                & "SELECT SEQ_IRRATEHIST.NEXTVAL AUTOID,RATEID ,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') LASTDATE,EFFECTIVEDT,RATETYPE,MODCODE,STATUS FROM IRRATE WHERE RATEID='" & v_strRATEID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '2. XOA CAC LAI SUAT CU DE DUA VAO LAI SUAT MOI
                    v_strSQL = "DELETE FROM IRRATE WHERE RATEID='" & v_strRATEID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '3. CAP NHAT CAC LAI SUAT DEN KY TU IRRATESCHD VAO IRRATE
                    v_strSQL = "INSERT INTO IRRATE (RATEID,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,EFFECTIVEDT,RATETYPE,MODCODE,STATUS) " & ControlChars.CrLf _
                                & "SELECT RATEID ,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,EFFECTIVEDT,RATETYPE,MODCODE,STATUS FROM IRRATESCHD WHERE AUTOID=" & v_dblAutoid
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '4. XOA TRONG IRRATESCHD NHUNG LICH DA DUA VAO TRONG IRRATE
                    v_strSQL = "DELETE FROM IRRATESCHD WHERE AUTOID=" & v_dblAutoid
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If

            'Kiem tra lich customize & Buckshee, xem co lich nao den ky khong 
            'Neu co lich thoa man thi lay lich setup gan nhat de kich hoat
            Dim v_strEVENTCODE As String
            Dim v_strAFACCTNO As String
            Dim v_strEXTYPE As String
            v_dblAutoid = 0
            v_strSQL = "SELECT * FROM EXAFSCHD WHERE EFFECTIVEDT<=TO_DATE('" & v_strNEXTDATE & "','DD/MM/YYYY') ORDER BY AUTOID"
            v_dsEx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsEx.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_dsEx.Tables(0).Rows.Count - 1
                    v_strEVENTCODE = v_dsEx.Tables(0).Rows(i)("EVENTCODE")
                    v_strAFACCTNO = v_dsEx.Tables(0).Rows(i)("AFACCTNO")
                    v_strEXTYPE = v_dsEx.Tables(0).Rows(i)("EXTYPE")
                    v_dblAutoid = v_dsEx.Tables(0).Rows(i)("AUTOID")
                    '1. CAP NHAT SU KIEN CU TRUNG VOI SU KIEN NAY VAO TRONG HIST
                    v_strSQL = "INSERT INTO EXAFMASTHIST(AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS,CURRRATE,EFFECTIVEDT,MODCODE,EXTYPE) " & ControlChars.CrLf _
                                & "SELECT SEQ_EXAFMASTHIST.NEXTVAL AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS, CURRRATE,EFFECTIVEDT,MODCODE,EXTYPE FROM EXAFMAST WHERE EVENTCODE='" & v_strEVENTCODE & "' AND AFACCTNO='" & v_strAFACCTNO & "' AND EXTYPE= '" & v_strEXTYPE & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '2. XOA CAC SU KIEN CU 
                    v_strSQL = "DELETE FROM EXAFMAST WHERE EVENTCODE='" & v_strEVENTCODE & "' AND AFACCTNO='" & v_strAFACCTNO & "' AND EXTYPE= '" & v_strEXTYPE & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '3. CAP NHAT CAC SU KIEN DEN KY TU EXAFSCHD VAO EXAFMAST
                    v_strSQL = "INSERT INTO EXAFMAST(AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS,CURRRATE,EFFECTIVEDT,MODCODE,EXTYPE) " & ControlChars.CrLf _
                                & "SELECT SEQ_EXAFMASTHIST.NEXTVAL AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS, CURRRATE,EFFECTIVEDT,MODCODE,EXTYPE FROM EXAFSCHD WHERE AUTOID=" & v_dblAutoid
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '4. XOA TRONG EXAFSCHD NHUNG SU KIEN DA DUA VAO TRONG EXAFMAST
                    v_strSQL = "DELETE FROM EXAFSCHD WHERE AUTOID=" & v_dblAutoid
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If
            'Kiem tra xem lich nao den ngay Exprire thi day vao trong HIST
            v_strSQL = "INSERT INTO EXAFMASTHIST(AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS,CURRRATE,EFFECTIVEDT,MODCODE,EXTYPE) " & ControlChars.CrLf _
                    & "SELECT SEQ_EXAFMASTHIST.NEXTVAL AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS, CURRRATE, EFFECTIVEDT,MODCODE,EXTYPE FROM EXAFMAST WHERE EXPDATE<=TO_DATE('" & v_strNEXTDATE & "','DD/MM/YYYY')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Xoa nhung lich den ngay Exprire
            v_strSQL = "DELETE FROM EXAFMAST WHERE EXPDATE<=TO_DATE('" & v_strNEXTDATE & "','DD/MM/YYYY')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Back up securities_info_hist
            Dim v_SecCount As Double
            v_strSQL = "INSERT INTO securities_info_hist (AUTOID,CODEID,SYMBOL,HISTDATE,TXDATE,LISTINGQTTY,TRADEUNIT,LISTINGSTATUS,ADJUSTQTTY," _
                                    & " LISTTINGDATE,REFERENCESTATUS,ADJUSTRATE,REFERENCERATE,REFERENCEDATE,STATUS,BASICPRICE,OPENPRICE,PREVCLOSEPRICE, " _
                                    & " CURRPRICE,CLOSEPRICE,AVGPRICE,CEILINGPRICE,FLOORPRICE,MTMPRICE,MTMPRICECD,INTERNALBIDPRICE,INTERNALASKPRICE,PE, " _
                                    & " EPS,DIVYEILD,DAYRANGE,YEARRANGE,TRADELOT,TRADEBUYSELL,TELELIMITMIN,TELELIMITMAX,ONLINELIMITMIN,ONLINELIMITMAX, " _
                                    & " REPOLIMITMIN,REPOLIMITMAX,ADVANCEDLIMITMIN,ADVANCEDLIMITMAX,MARGINLIMITMIN,MARGINLIMITMAX,SECURERATIOTMIN," _
                                    & " SECURERATIOMAX,DEPOFEEUNIT,DEPOFEELOT,MORTAGERATIOMIN,MORTAGERATIOMAX,SECUREDRATIOMIN,SECUREDRATIOMAX," _
                                    & " CURRENT_ROOM,BMINAMT,SMINAMT,MARGINPRICE,MARGINREFPRICE,ROOMLIMIT,ROOMLIMITMAX,DFREFPRICE,SYROOMLIMIT," _
                                    & " SYROOMUSED,MARGINCALLPRICE,MARGINREFCALLPRICE,DFRLSPRICE) " _
                                    & " select seq_securities_info_hist.nextval AUTOID,CODEID,SYMBOL,TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') HISTDATE, TXDATE,LISTINGQTTY,TRADEUNIT,LISTINGSTATUS,ADJUSTQTTY," _
                                    & " LISTTINGDATE,REFERENCESTATUS,ADJUSTRATE,REFERENCERATE,REFERENCEDATE,STATUS,BASICPRICE,OPENPRICE,PREVCLOSEPRICE, " _
                                    & " CURRPRICE,CLOSEPRICE,AVGPRICE,CEILINGPRICE,FLOORPRICE,MTMPRICE,MTMPRICECD,INTERNALBIDPRICE,INTERNALASKPRICE,PE," _
                                    & " EPS,DIVYEILD,DAYRANGE,YEARRANGE,TRADELOT,TRADEBUYSELL,TELELIMITMIN,TELELIMITMAX,ONLINELIMITMIN,ONLINELIMITMAX," _
                                    & " REPOLIMITMIN,REPOLIMITMAX,ADVANCEDLIMITMIN,ADVANCEDLIMITMAX,MARGINLIMITMIN,MARGINLIMITMAX,SECURERATIOTMIN," _
                                    & " SECURERATIOMAX,DEPOFEEUNIT,DEPOFEELOT,MORTAGERATIOMIN,MORTAGERATIOMAX,SECUREDRATIOMIN,SECUREDRATIOMAX," _
                                    & " CURRENT_ROOM,BMINAMT,SMINAMT,MARGINPRICE,MARGINREFPRICE,ROOMLIMIT,ROOMLIMITMAX,DFREFPRICE,SYROOMLIMIT," _
                                    & " SYROOMUSED,MARGINCALLPRICE,MARGINREFCALLPRICE,DFRLSPRICE  from securities_info "
            '
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            'Backup SMS data
            BackupSMSData()

            ''Kiem tra tao sequence moi
            'Sua dua doan nay vao thu tuc
            'v_strSQL = "SELECT FRTABLE, TOTABLE FROM TBLBACKUP WHERE TYPBK='S'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
            '        v_strFRTABLE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FRTABLE")))
            '        v_strSQL = "SELECT * FROM USER_OBJECTS WHERE OBJECT_NAME = '" & v_strFRTABLE & "'"
            '        v_dsSeq = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '        If v_dsSeq.Tables(0).Rows.Count > 0 Then
            '            v_strSQL = "DROP SEQUENCE " & v_strFRTABLE
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '        End If
            '        v_strSQL = "CREATE SEQUENCE " & v_strFRTABLE & " NOCACHE "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If

            'Cap nhat lai thong tin tin SBEOW, SBEOM, SBEOQ, SBEOY
            'Neu la ngay cuoi nam cap nhat SBEOY, SBEOQ va� SBEOM
            'Neu la ngay cuoi quy cap nhat SBEOQ va� SBEOM
            'Neu la ngay cuoi thang cap nhat SBEOM            
            'If v_ds.Tables(0).Rows.Count = 0 Then
            '    Return ERR_SA_CALENDAR_MISSING
            'Else
            If Year(DDMMYYYY_SystemDate(v_strCURRDATE)) <> Year(DDMMYYYY_SystemDate(v_strNEXTDATE)) Then
                v_strSQL = "UPDATE SBCLDR SET SBEOY = 'Y', SBEOQ = 'Y', SBEOM = 'Y' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf Month(DDMMYYYY_SystemDate(v_strCURRDATE)) <> Month(DDMMYYYY_SystemDate(v_strNEXTDATE)) And Month(DDMMYYYY_SystemDate(v_strCURRDATE)) Mod 3 Then
                v_strSQL = "UPDATE SBCLDR SET SBEOQ = 'Y', SBEOM = 'Y' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf Month(DDMMYYYY_SystemDate(v_strCURRDATE)) <> Month(DDMMYYYY_SystemDate(v_strNEXTDATE)) Then
                v_strSQL = "UPDATE SBCLDR SET SBEOM = 'Y' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf Weekday(DDMMYYYY_SystemDate(v_strCURRDATE), FirstDayOfWeek.Monday) > Weekday(DDMMYYYY_SystemDate(v_strNEXTDATE), FirstDayOfWeek.Monday) Then
                v_strSQL = "UPDATE SBCLDR SET SBEOW = 'Y' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'Ngay lam viec truoc
            v_strPREVDATE = v_strCURRDATE
            'Ngay lam viec moi
            v_strSQL = "SELECT MIN(SBDATE) FROM SBCLDR WHERE CLDRTYPE='000' AND HOLIDAY='N' AND SBDATE > TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_CALENDAR_MISSING
            Else
                v_strCURRDATE = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)(0)), gc_FORMAT_DATE)
            End If
            'Ngay lam viec tiep theo
            v_strSQL = "SELECT MIN(SBDATE) FROM SBCLDR WHERE CLDRTYPE='000' AND HOLIDAY='N' AND SBDATE > TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_CALENDAR_MISSING
            Else
                v_strNEXTDATE = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)(0)), gc_FORMAT_DATE)
            End If

            v_strSQL = "SELECT MAX (SBDATE) SBDATE FROM SBCLDR WHERE CLDRTYPE = '000' AND HOLIDAY = 'N' AND SBDATE < TO_DATE('" & v_strPREVDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_CALENDAR_MISSING
            Else
                v_strDUEDATE = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)(0)), gc_FORMAT_DATE)
            End If

            'Dat lai thong tin bang SYSVAR
            v_lngErrCode = v_obj.SetSysVar("SYSTEM", "DUEDATE", v_strDUEDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.SetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.SetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.SetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Cap nhat lai tin trong SBCLDR
            v_strSQL = "UPDATE SBCLDR SET SBBUSDAY='N' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strPREVDATE & "','" & gc_FORMAT_DATE & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "UPDATE SBCLDR SET SBBUSDAY='Y' WHERE CLDRTYPE='000' AND SBDATE = TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Chinh lai cac tham so do ap dung tang he thong
            ApplySystemParam()

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function ApplySystemParam() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ApplySystemParam", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_ds1, v_dsEx, v_dsSeq As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Xac dinh cac tham so he thong
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE, v_strDUEDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            Dim v_strLAST_DAY As String

            'Kiem tra lich customize & Buckshee, xem co lich nao den ky khong 
            'Neu co lich thoa man thi lay lich setup gan nhat de kich hoat
            Dim v_strACTYPE As String
            Dim v_strAFACCTNO As String
            Dim v_strEXTYPE As String
            Dim v_dblAutoid As Double = 0
            'Luu cac thong tin Margin chung khoan gan theo loai hinh cu
            v_strSQL = "INSERT INTO afseriskhist (CODEID,ACTYPE,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN,EXPDATE,BACKUPDT) " & ControlChars.CrLf _
                        & "select CODEID,ACTYPE,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN,EXPDATE,to_char(sysdate,'DD/MM/YYYY:HH:MI:SS') FROM afserisk"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Xoa cac thong tin Margin chung khoan gan theo loai hinh cu
            v_strSQL = "TRUNCATE TABLE AFSERISK "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Luu cac basket chung khoan het hieu luc
            v_strSQL = "INSERT INTO afsebaskethist (autoid,BASKETID,actype,effdate,expdate,BACKUPDT) " & ControlChars.CrLf _
                    & "select autoid,BASKETID,actype,effdate,expdate,to_char(sysdate,'DD/MM/YYYY:HH:MI:SS') from afsebasket WHERE EXPDATE<=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Xoa cac basket chung khoan da het hieu luc.
            v_strSQL = "DELETE FROM AFSEBASKET WHERE EXPDATE<=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Dua cac tham so Margin chung khoan vao ap dung cho cac loai hinh
            v_strSQL = "SELECT ACTYPE, MAX(AUTOID) AUTOID FROM (SELECT * FROM AFSEBASKET WHERE EFFDATE<=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') ORDER BY AUTOID DESC) GROUP BY ACTYPE"
            v_dsEx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsEx.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_dsEx.Tables(0).Rows.Count - 1
                    v_strACTYPE = v_dsEx.Tables(0).Rows(i)("ACTYPE")
                    v_dblAutoid = v_dsEx.Tables(0).Rows(i)("AUTOID")
                    '1. Cap nhat thong tin Margin cac chung khoan theo loai hinh
                    v_strSQL = "INSERT INTO afserisk (CODEID,ACTYPE,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN)" & ControlChars.CrLf _
                                & "SELECT SB.CODEID,AF.ACTYPE,  " & ControlChars.CrLf _
                                & "LEAST(SEC.MRRATIORATE,RATE.MRRATIORATE) MRRATIORATE, " & ControlChars.CrLf _
                                & "LEAST(SEC.MRRATIOLOAN,RATE.MRRATIOLOAN) MRRATIOLOAN, " & ControlChars.CrLf _
                                & "LEAST(SEC.MRPRICERATE,RSK.MRPRICERATE) MRPRICERATE, " & ControlChars.CrLf _
                                & "LEAST(SEC.MRPRICELOAN,RSK.MRPRICELOAN) MRPRICELOAN " & ControlChars.CrLf _
                                & "FROM AFSEBASKET AF, SECBASKET SEC, SECURITIES_INFO SB, SECURITIES_RISK RSK, SECURITIES_RATE RATE " & ControlChars.CrLf _
                                & "WHERE RSK.CODEID=RATE.CODEID AND RATE.FROMPRICE<=SB.FLOORPRICE AND RATE.TOPRICE>SB.FLOORPRICE AND AF.AUTOID=" & v_dblAutoid & " AND AF.BASKETID=SEC.BASKETID AND TRIM(SEC.SYMBOL)=TRIM(SB.SYMBOL) AND SB.CODEID=RSK.CODEID " & ControlChars.CrLf
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    
                Next
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function BackupSMSData() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ApplySystemParam", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Xac dinh cac tham so he thong
            'Bakup SMS Margi
            v_strSQL = " insert into SMSMARGINCALLHIST (autoid, actype, acctno, email, mobile, address, " & ControlChars.CrLf _
                        & " fullname, phone1, desc_status, balance, bamt, odamt, " & ControlChars.CrLf _
                        & " advlimit, mrcrlimitmax, mrclamt, mrcrlimit, mrirate, " & ControlChars.CrLf _
                        & " mrmrate, mrlrate, marginrate, avlwithdraw, pp, " & ControlChars.CrLf _
                        & " avllimit, navaccount, outstanding, addvnd, smsstatus, " & ControlChars.CrLf _
                        & " execdate, exectime, calldate, calltime) " & ControlChars.CrLf _
                        & " select autoid, actype, acctno, email, mobile, address, " & ControlChars.CrLf _
                        & " fullname, phone1, desc_status, balance, bamt, odamt, " & ControlChars.CrLf _
                        & " advlimit, mrcrlimitmax, mrclamt, mrcrlimit, mrirate, " & ControlChars.CrLf _
                        & " mrmrate, mrlrate, marginrate, avlwithdraw, pp, " & ControlChars.CrLf _
                        & " avllimit, navaccount, outstanding, addvnd, smsstatus, " & ControlChars.CrLf _
                        & " execdate, exectime, calldate, calltime  " & ControlChars.CrLf _
                        & " from SMSMARGINPROCESSED " & ControlChars.CrLf _
                        & " where to_date(EXECDATE,'DD/MM/YYYY') - (select VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' and VARNAME= 'EXPSMSDAY') " & ControlChars.CrLf _
                        & " >=(select to_date(VARVALUE,'DD/MM/YYYY') FROM SYSVAR WHERE GRNAME='SYSTEM' and VARNAME= 'CURRDATE') " & ControlChars.CrLf
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = " delete from SMSMARGINPROCESSED " & ControlChars.CrLf _
                     & " where to_date(EXECDATE,'DD/MM/YYYY') - (select VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' and VARNAME= 'EXPSMSDAY') " & ControlChars.CrLf _
                     & " >=(select to_date(VARVALUE,'DD/MM/YYYY') FROM SYSVAR WHERE GRNAME='SYSTEM' and VARNAME= 'CURRDATE') " & ControlChars.CrLf
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

End Class
