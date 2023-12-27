Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
Imports System.Data

'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Batch
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

#Region " Khai bÃ¡o háº±ng, biáº¿n "
    Dim mv_sModule As String
    Dim mv_sTable As String
#End Region

#Region " CÃ¡c thuá»™c tÃ­nh cá»§a lá»›p "
    Public Property ATTR_MODULE() As String
        Get
            Return mv_sModule
        End Get
        Set(ByVal Value As String)
            mv_sModule = Value
        End Set
    End Property

    Public Property ATTR_TABLE() As String
        Get
            Return mv_sTable
        End Get
        Set(ByVal Value As String)
            mv_sTable = Value
        End Set
    End Property
#End Region

#Region " CÃ¡c hÃ m xá»­ lÃ½ Batch "

    'HÃ m nÃ y khá»Ÿi táº¡o message cho bÆ°á»›c cháº¡y Batch
    Overridable Function BuildBatchTxMsg(ByRef v_xmlDocument As Xml.XmlDocument, ByVal v_strDetailBatchName As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.BuildBatchTxMsg", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg, v_strTxNum, v_strTxDate, v_strPrevDate, v_strNextDate As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Láº¥y sá»‘ chá»©ng tá»«
            v_strTxNum = BATCH_PREFIXED & Right(gc_FORMAT_BATCHTXNUM & CStr(v_obj.GetIDValue("BATCHTXNUM")), Len(gc_FORMAT_BATCHTXNUM) - Len(BATCH_PREFIXED))
            'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTxDate)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Táº¡o message tráº£ vá»?
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsNotLocalMsg, , "0000", "0000", "HOST", "HOST")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxNum
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxDate
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

    'Láº¥y giÃ¡ trá»‹ biáº¿n SDE.DAYS
    Public Function GetSDE_DAYS(ByVal pv_strLastICCFDate As String, ByVal pv_strMONTHDAY As String, ByRef pv_intDAYS As Integer) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.GetSDE_DAYS", v_strErrorMessage As String
        Dim v_strSYSVAR As String, v_obj As New DataAccess
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_dtCURRDATE, v_dtCMPDATE, v_dtBOMDATE As Date, v_intCMPDAY, v_intCURRDAY As Integer
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            v_dtCURRDATE = DDMMYYYY_SystemDate(v_strSYSVAR)
            v_dtCMPDATE = DDMMYYYY_SystemDate(pv_strLastICCFDate)
            v_dtBOMDATE = DDMMYYYY_SystemDate("01/" & v_dtCMPDATE.Month & "/" & v_dtCMPDATE.Year)
            Select Case pv_strMONTHDAY
                Case "A"
                    'Sá»‘ ngÃ y thá»±c táº¿
                    pv_intDAYS = DateDiff(DateInterval.Day, v_dtCMPDATE, v_dtCURRDATE)
                Case "M"
                    'LÃ m trÃ²n thÃ¡ng 30 ngÃ y
                    If DateDiff(DateInterval.Month, v_dtCMPDATE, v_dtCURRDATE) > 0 Then
                        'Náº¿u khÃ¡c thÃ¡ng. Láº¥y sá»‘ ngÃ y trong cÃ¡c thÃ¡ng náº±m giá»¯a CMPDATE vÃ  CURRDATE
                        pv_intDAYS = (DateDiff(DateInterval.Month, v_dtCMPDATE, v_dtCURRDATE) - 1) * 30
                        'LÃ m trÃ²n thÃ¡ng chá»‰ cÃ³ 30 ngÃ y
                        v_intCMPDAY = IIf(30 - v_dtCMPDATE.Day > 0, 30 - v_dtCMPDATE.Day, 0)
                        v_intCURRDAY = IIf(v_dtCURRDATE.Day > 30, 30, v_dtCURRDATE.Day)
                        pv_intDAYS = pv_intDAYS + v_intCMPDAY + v_intCURRDAY
                    Else
                        pv_intDAYS = DateDiff(DateInterval.Day, v_dtCMPDATE, v_dtCURRDATE)
                        If pv_intDAYS > 30 Then pv_intDAYS = 30
                    End If
                Case "E"
                    'LÃ m trÃ²n thÃ¡ng 30 ngÃ y, nhÆ°ng náº¿u cÃ³ thÃ¡ng 2 thÃ¬ pháº£i xÃ¡c Ä‘á»‹nh chÃ­nh xÃ¡c sá»‘ ngÃ y cá»§a thÃ¡ng 2 Ä‘Ã³. 
                    'Giáº£i thuáº­t lÃ  náº¿u cÃ³ thÃ¡ng 2 náº±m trong khoáº£ng thá»?i gian xá»­ lÃ½ thÃ¬ xÃ¡c Ä‘á»‹nh sá»‘ ngÃ y cá»§a thÃ¡ng 2 Ä‘Ã³

                    'LÃ m trÃ²n thÃ¡ng 30 ngÃ y (giá»‘ng vá»›i MONTHDAY=M)
                    If DateDiff(DateInterval.Month, v_dtCMPDATE, v_dtCURRDATE) > 0 Then
                        'Náº¿u khÃ¡c thÃ¡ng. Láº¥y sá»‘ ngÃ y trong cÃ¡c thÃ¡ng náº±m giá»¯a CMPDATE vÃ  CURRDATE
                        pv_intDAYS = (DateDiff(DateInterval.Month, v_dtCMPDATE, v_dtCURRDATE) - 1) * 30
                        'LÃ m trÃ²n thÃ¡ng chá»‰ cÃ³ 30 ngÃ y
                        v_intCMPDAY = IIf(30 - v_dtCMPDATE.Day > 0, 30 - v_dtCMPDATE.Day, 0)
                        v_intCURRDAY = IIf(v_dtCURRDATE.Day > 30, 30, v_dtCURRDATE.Day)
                        pv_intDAYS = pv_intDAYS + v_intCMPDAY + v_intCURRDAY
                    Else
                        pv_intDAYS = DateDiff(DateInterval.Day, v_dtCMPDATE, v_dtCURRDATE)
                        If pv_intDAYS > 30 Then pv_intDAYS = 30
                    End If

                    'Duyá»‡t tá»« v_dtCMPDATE Ä‘áº¿n v_dtCURRDATE cÃ³ bao nhiÃªu thÃ¡ng 2
                    v_intCMPDAY = 0
                    While v_dtCMPDATE < v_dtCURRDATE
                        If v_dtCMPDATE.Month = 2 Then
                            v_intCMPDAY = v_intCMPDAY + 30 - v_dtCMPDATE.DaysInMonth(v_dtCMPDATE.Year, 2)
                        End If
                        v_dtCMPDATE = DateAdd(DateInterval.Month, 1, v_dtCMPDATE)
                    End While
                    'Xá»­ lÃ½ náº¿u ngÃ y hiá»‡n táº¡i lÃ  cuá»‘i thÃ¡ng 2
                    If v_dtCURRDATE.Month = 2 And v_dtCURRDATE.Day >= v_dtCURRDATE.DaysInMonth(v_dtCURRDATE.Year, 2) Then
                        v_intCMPDAY = v_intCMPDAY + 30 - v_dtCURRDATE.DaysInMonth(v_dtCURRDATE.Year, 2)
                    End If
                    'Sá»‘ ngÃ y tÃ­nh Ä‘Æ°á»£c sáº½ báº±ng sá»‘ trÃ²n 30 ngÃ y trá»« Ä‘i sá»‘ ngÃ y thÃ¡ng 2 bá»‹ bÃ¹
                    pv_intDAYS = pv_intDAYS - v_intCMPDAY
            End Select
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetSDEFormulaValue(ByVal pv_strSDEName As String, ByRef pv_strValue As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strSYSVAR As String, v_obj As New DataAccess, v_dtREFDATE As Date
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            v_dtREFDATE = DDMMYYYY_SystemDate(v_strSYSVAR)
            Select Case pv_strSDEName
                Case "MONTHDAY"
                    'pv_strValue lÃ  giÃ¡ trá»‹ Ä‘Æ°á»£c chá»?n
                    If pv_strValue = "A" Then
                        'Láº¥y sá»‘ ngÃ y thá»±c táº¿ trong thÃ¡ng
                        pv_strValue = CStr(v_dtREFDATE.DaysInMonth(v_dtREFDATE.Year, v_dtREFDATE.Month))
                    ElseIf pv_strValue = "M" Then
                        'Láº¥y trÃ²n 30 ngÃ y
                        pv_strValue = "30"
                    ElseIf pv_strValue = "E" Then
                        'Láº¥y trÃ²n 30 ngÃ y trá»« thÃ¡ng 2 láº¥y theo Ä‘Ãºng ngÃ y thá»±c táº¿
                        If GetDateValue(v_strSYSVAR, "M") <> 2 Then
                            pv_strValue = "30"
                        Else
                            pv_strValue = CStr(v_dtREFDATE.DaysInMonth(v_dtREFDATE.Year, 2))
                        End If
                    End If
                Case "YEARDAY"
                    'pv_strValue lÃ  giÃ¡ trá»‹ Ä‘Æ°á»£c chá»?n
                    If pv_strValue = "A" Then
                        'Láº¥y sá»‘ ngÃ y thá»±c táº¿ trong nÄƒm
                        If v_dtREFDATE.DaysInMonth(v_dtREFDATE.Year, 2) = 28 Then
                            pv_strValue = "365"
                        Else
                            pv_strValue = "366"
                        End If
                    ElseIf pv_strValue = "M" Then
                        'Láº¥y thÃ¡ng trÃ²n 30 ngÃ y -> 1 nÄƒm 360 ngÃ y
                        pv_strValue = "360"
                    ElseIf pv_strValue = "E" Then
                        'Láº¥y trÃ²n 30 ngÃ y trá»« thÃ¡ng 2 láº¥y theo Ä‘Ãºng ngÃ y thá»±c táº¿
                        pv_strValue = CStr(360 - v_dtREFDATE.DaysInMonth(v_dtREFDATE.Year, 2))
                    End If
                Case "DRATE"
                    If pv_strValue = "D1" Then
                        pv_strValue = "30"
                    ElseIf pv_strValue = "D2" Then
                        pv_strValue = CStr(v_dtREFDATE.DaysInMonth(v_dtREFDATE.Year, v_dtREFDATE.Month))
                    ElseIf pv_strValue = "Y1" Then
                        pv_strValue = "360"
                    ElseIf pv_strValue = "Y2" Then
                        pv_strValue = CStr(v_dtREFDATE.DayOfYear)
                    End If
                Case "RATE"
                    'pv_strValue lÃ  giÃ¡ trá»‹ mÃ£ lÃ£i suáº¥t tháº£ ná»•i

                Case Else
                    'Láº¥y trong báº£ng SYSVAR
                    v_lngErrCode = v_obj.GetSysVar("SYSTEM", pv_strSDEName, pv_strValue)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
            End Select
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    'HÃ m nÃ y tÃ­nh toÃ¡n biá»ƒu thá»©c sá»‘ há»?c trÃªn cÆ¡ sá»Ÿ máº£ng ICCFTX
    Public Function BuildICCFTXEXP(ByVal pv_arrICCFTX() As ICCFTX, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent As String, v_lngIndex, i As Long
            v_strEvaluator = vbNullString
            v_lngIndex = 1

            If Mid(strAMTEXP, 1, 1) = "@" Then 'Láº¥y trá»±c tiáº¿p giÃ¡ trá»‹ sau kÃ½ tá»± @
                Return Mid(strAMTEXP, 2)
            ElseIf Mid(strAMTEXP, 1) = "$" Then 'Láº¥y giÃ¡ trá»‹ cá»§a trÆ°á»?ng
                strAMTEXP = Mid(strAMTEXP, 2)
                'Ä?á»?c thÃ´ng tin trong máº£ng pv_arrICCFTX Ä‘á»ƒ láº¥y giÃ¡ trá»‹
                If pv_arrICCFTX.GetLength(0) > 0 Then
                    For i = 0 To pv_arrICCFTX.GetLength(0) - 1 Step 1
                        If Not pv_arrICCFTX(i) Is Nothing Then
                            If pv_arrICCFTX(i).TXCD = strAMTEXP Then
                                Return pv_arrICCFTX(i).VALNUMBER
                            End If
                        End If
                    Next
                End If
            Else 'Biá»ƒu thá»©c sá»‘ há»?c
                While v_lngIndex < Len(strAMTEXP)
                    'Get 02 charatacters in AMTEXP
                    v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                    Select Case v_strElemenent
                        Case "++", "--", "**", "//", "((", "))"
                            'Operand: ToÃ¡n tá»­
                            v_strEvaluator = v_strEvaluator & Left$(v_strElemenent, 1)
                        Case Else
                            'Operator: ToÃ¡n háº¡ng - Ä‘á»?c thÃ´ng tin trong máº£ng pv_arrICCFTX Ä‘á»ƒ láº¥y giÃ¡ trá»‹
                            If pv_arrICCFTX.GetLength(0) > 0 Then
                                For i = 0 To pv_arrICCFTX.GetLength(0) - 1 Step 1
                                    If Not pv_arrICCFTX(i) Is Nothing Then
                                        If pv_arrICCFTX(i).TXCD = v_strElemenent Then
                                            v_strEvaluator = v_strEvaluator & pv_arrICCFTX(i).VALNUMBER
                                            Exit For
                                        End If
                                    End If
                                Next
                            End If
                    End Select
                    v_lngIndex = v_lngIndex + 2
                End While
                Return v_strEvaluator
            End If
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'HÃ m thá»±c hiá»‡n kiá»ƒm tra Ä‘iá»?u kiá»‡n
    Public Function CheckCompareExpression(ByVal pv_arrICCFTX() As ICCFTX,
        ByVal pv_strCMPCD As String, ByVal pv_strOPERAND As String, ByVal pv_strCMPEXP As String) As Boolean
        Try
            Dim i As Integer, v_strValue As String = String.Empty
            For i = 0 To pv_arrICCFTX.GetLength(0) - 1 Step 1
            Next
            Complete() 'ContextUtil.SetComplete()
            Return False
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    'HÃ m láº¥y giÃ¡ trá»‹ cá»§a ICCFTX theo REFNAME
    Public Function GetICCFTXValueByREFNAME(ByVal pv_arrICCFTX() As ICCFTX, ByVal pv_strREFNAME As String) As String
        Try
            Dim i As Integer, v_strValue As String = String.Empty
            For i = 0 To pv_arrICCFTX.GetLength(0) - 1 Step 1
                If Not pv_arrICCFTX(i) Is Nothing Then
                    If Trim(pv_arrICCFTX(i).REFNAME) = Trim(pv_strREFNAME) Then
                        If pv_arrICCFTX(i).DATATYPE = "N" Then
                            v_strValue = CStr(pv_arrICCFTX(i).VALNUMBER)
                        Else
                            v_strValue = pv_arrICCFTX(i).VALCHAR
                        End If
                        Return v_strValue
                    End If
                End If
            Next
            Complete() 'ContextUtil.SetComplete()
            Return v_strValue
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    'HÃ m láº¥y giÃ¡ trá»‹ cá»§a ICCFTX theo TXCD
    Public Function GetICCFTXValueByTXCD(ByVal pv_arrICCFTX() As ICCFTX, ByVal pv_strTXCD As String) As String
        Try
            Dim i As Integer, v_strValue As String = String.Empty
            For i = 0 To pv_arrICCFTX.GetLength(0) - 1 Step 1
                If Not pv_arrICCFTX(i) Is Nothing Then
                    If Trim(pv_arrICCFTX(i).TXCD) = Trim(pv_strTXCD) Then
                        If pv_arrICCFTX(i).DATATYPE = "N" Then
                            v_strValue = CStr(pv_arrICCFTX(i).VALNUMBER)
                        Else
                            v_strValue = pv_arrICCFTX(i).VALCHAR
                        End If
                        Return v_strValue
                    End If
                End If
            Next
            Complete() 'ContextUtil.SetComplete()
            Return v_strValue
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Overridable Function ICCFCalculate(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ICCFCalculate." & v_strBATCHNAME, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsSYS, v_dsIRRATE, v_dsMAST, v_dsICCFTX, v_dsTIER, v_dsTLLOG, v_dsEXAFMAST As DataSet
        Dim v_obj As New DataAccess, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_arrICCFTX() As ICCFTX, v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Lay tham so ngay lam viec
            Dim v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE, v_strPERIOD, v_strICCFLASTDATE As String
            Dim v_intCURRMONTH, v_intCURRYEAR, v_intNEXTMONTH, v_intNEXTYEAR As Integer

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_strICCFLASTDATE = v_strPREVDATE

            'Lay cac tai khoan can tinh lai
            If GetDateValue(v_strCURRDATE, "Y") <> GetDateValue(v_strNEXTDATE, "Y") Then
                'EOY. Ngay cuoi nam
                v_strPERIOD = "('D','M','Y')"
            ElseIf GetDateValue(v_strCURRDATE, "M") <> GetDateValue(v_strNEXTDATE, "M") Then
                'EOM. Ngay cuoi thang
                v_strPERIOD = "('D','M')"
            Else
                'EOD. Cuoi ngay
                v_strPERIOD = "('D')"
            End If

            'Doi voi loai PERIOD=S, Xac dinh chinh xac PERIODDAY phai nam trong khoang CURRDATE & NEXTDATE
            v_intCURRMONTH = GetDateValue(v_strCURRDATE, "M")
            v_intCURRYEAR = GetDateValue(v_strCURRDATE, "Y")
            v_intNEXTMONTH = GetDateValue(v_strNEXTDATE, "M")
            v_intNEXTYEAR = GetDateValue(v_strNEXTDATE, "Y")

            'Thuat toan: 
            Dim v_strCRITERIA, v_strACTYPE, v_strEVENTCODE, v_strMODCODE, v_strTLTXCD, v_strFLDTXCD,
                v_strRULETYPE, v_strMONTHDAY, v_strYEARDAY, v_strGLREF, v_strICTYPE, v_strICRATECD, v_strLine As String
            Dim v_dblMINBAL, v_dblMAXBAL As Double
            Dim v_strICRULE As String, i, j, v_intVALUE As Integer
            'TruongLD them 09/03/2010 luu so ngay tinh lai trong thang
            Dim v_intDaysCalcInterest As Integer = 1
            Dim intIndexICCFBAL, intIndexICCFRATE, intIndexINTBAL, intIndexINTAMT As Integer
            Dim dblBALANCE, dblBASEDRATE, dblRATE, dblINTAMT, dblFRAMT, dblTOAMT, dblDELTA As Double
            Dim dblICBASEDRATE, dblICBASEDRATEMIN, dblICBASEDRATEMAX As Double
            Dim dblSYSRATEMIN, dblSYSRATEMAX, dblSYSAMTMIN, dblSYSAMTMAX As Double
            Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
            Dim v_strCMPCD, v_strOPERAND, v_strCMPEXP As String, v_blnRuleAllow, v_blnMinMax As Boolean, v_dblMinMaxValue As Double
            Dim v_objEval As New Evaluator

            'Lay gia tri de phan trang
            If ATTR_MODULE = "CF" Then
                v_strSQL = "SELECT COUNT(*) MAXROW FROM  AFMAST"
            Else
                v_strSQL = "SELECT COUNT(*) MAXROW FROM  " & ATTR_MODULE & "MAST"
            End If
            v_dsMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_dsMAST.Tables(0).Rows(0)("MAXROW")

            '1.Láº¥y cÃ¡c event Ä‘áº¿n háº¡n xá»­ lÃ½ cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥
            'CÄƒn cá»© vÃ o ngÃ y hiá»‡n táº¡i Ä‘á»ƒ lá»?c láº¥y cÃ¡c event thá»±c hiá»‡n daily/monthly/yearly hoáº·c ngÃ y xÃ¡c Ä‘á»‹nh
            'Náº¿u lÃ  ngÃ y xÃ¡c Ä‘á»‹nh thÃ¬ kiá»ƒm tra Ä‘Ã£ Ä‘áº¿n ngÃ y Ä‘Ã³ chÆ°a
            v_strSQL = "SELECT ICDEF.*, ENV.CRITERIA, ENV.LSTODR, ENV.TLTXCD, ENV.FLDTXCD, ENV.ACFLD, ENV.FLDKEY, ENV.TBLNAME " & ControlChars.CrLf _
                & "FROM ICCFTYPEDEF ICDEF, APPEVENTS ENV " & ControlChars.CrLf _
                & "WHERE ICDEF.RULETYPE<>'S' AND ICDEF.MODCODE = ENV.MODCODE And ICDEF.EVENTCODE = ENV.EVENTCODE " & ControlChars.CrLf _
                & "AND ICDEF.MODCODE='" & ATTR_MODULE & "' AND ICDEF.DELTD<> 'Y' " & ControlChars.CrLf _
                & "AND ((ICDEF.PERIOD IN " & v_strPERIOD & ") " & ControlChars.CrLf _
                & "OR (ICDEF.PERIOD='S' AND TO_DATE(ICDEF.PERIODDAY || '/" & v_intCURRMONTH & "/" & v_intCURRYEAR & "','" & gc_FORMAT_DATE & "')>=" & ControlChars.CrLf _
                & "TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                & "AND TO_DATE(ICDEF.PERIODDAY || '/" & v_intCURRMONTH & "/" & v_intCURRYEAR & "','" & gc_FORMAT_DATE & "')<" & ControlChars.CrLf _
                & "TO_DATE('" & v_strNEXTDATE & "','" & gc_FORMAT_DATE & "'))) " & ControlChars.CrLf _
                & "AND ENV.BCHMDL = '" & v_strBATCHNAME & "'" & ControlChars.CrLf _
                & "ORDER BY ICDEF.MODCODE, ENV.LSTODR, ENV.EVENTCODE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For intEventCount As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    '2. Vá»›i má»—i event, lá»?c láº¥y cÃ¡c tÃ i khoáº£n thoáº£ mÃ£n yÃªu cáº§u xá»­ lÃ½
                    v_strCRITERIA = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("CRITERIA"))
                    v_strEVENTCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("EVENTCODE"))
                    v_strMODCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("MODCODE"))
                    v_strRULETYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("RULETYPE"))
                    v_strTLTXCD = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("TLTXCD"))
                    v_strFLDTXCD = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("FLDTXCD"))
                    v_strMONTHDAY = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("MONTHDAY"))
                    v_strYEARDAY = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("YEARDAY"))
                    v_strACTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("ACTYPE"))
                    v_strGLREF = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("GLACCTNO"))
                    v_strICTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("ICTYPE"))
                    v_strICRATECD = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("ICRATECD"))
                    'Khoang gia tri min, max cho gia tri tinh lai
                    v_dblMINBAL = gf_CorrectNumericField(v_ds.Tables(0).Rows(intEventCount)("MINVAL"))
                    v_dblMAXBAL = gf_CorrectNumericField(v_ds.Tables(0).Rows(intEventCount)("MAXVAL"))
                    v_strLine = gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("LINE"))

                    'Xac dinh cac gia tri lai suat co ban cua ICCF
                    dblICBASEDRATEMIN = -1   'Khong gioi han
                    dblICBASEDRATEMAX = -1   'Khong gioi han

                    'Xac dinh cac gia tri gioi han tang he thong cho tung su kien
                    v_strSQL = "SELECT FLRRATE,CELRATE,FLRAMT,CELAMT FROM EVENTSYS WHERE MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "'"
                    v_dsSYS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsSYS.Tables(0).Rows.Count > 0 Then
                        'Bi chan boi tang he thong
                        dblSYSRATEMIN = gf_CorrectNumericField(v_dsSYS.Tables(0).Rows(0)("FLRRATE"))
                        dblSYSRATEMAX = gf_CorrectNumericField(v_dsSYS.Tables(0).Rows(0)("CELRATE"))
                        dblSYSAMTMIN = gf_CorrectNumericField(v_dsSYS.Tables(0).Rows(0)("FLRAMT"))
                        dblSYSAMTMAX = gf_CorrectNumericField(v_dsSYS.Tables(0).Rows(0)("CELAMT"))
                    Else
                        'Khong bi chan boi tang he thong
                        dblSYSRATEMIN = -1
                        dblSYSRATEMAX = -1
                        dblSYSAMTMIN = -1
                        dblSYSAMTMAX = -1
                    End If

                    'So sanh Min,Max voi tang he thong, Tang he thong se quyet dinh sau cung
                    If dblSYSAMTMIN >= 0 Then
                        v_dblMINBAL = IIf(v_dblMINBAL < dblSYSAMTMIN, dblSYSAMTMIN, v_dblMINBAL)
                    End If
                    If dblSYSAMTMAX >= 0 Then
                        v_dblMAXBAL = IIf(v_dblMAXBAL > dblSYSAMTMAX, dblSYSAMTMAX, v_dblMAXBAL)
                    End If

                    If v_strICTYPE = "F" Then
                        'Má»©c cá»‘ Ä‘á»‹nh
                        dblICBASEDRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(intEventCount)("ICFLAT")).ToString
                    ElseIf v_strICTYPE = "P" Then
                        If v_strICRATECD = "S" Then
                            'Lai suat co dinh
                            dblICBASEDRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(intEventCount)("ICRATE"))
                        ElseIf v_strICRATECD = "F" Then
                            'LÃ£i suáº¥t Ä‘iá»?u chá»‰nh (cá»™ng thÃªm vÃ o lÃ£i suáº¥t cÆ¡ sá»Ÿ)
                            dblICBASEDRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(intEventCount)("ICRATE"))
                            'Lai suat tha noi
                            v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("ICRATEID")))
                            v_strSQL = "SELECT * FROM IRRATE WHERE STATUS='Y' AND RATEID='" & v_strVALUE & "'"
                            v_dsIRRATE = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsIRRATE.Tables(0).Rows.Count > 0 Then
                                dblICBASEDRATE = dblICBASEDRATE + gf_CorrectNumericField(v_dsIRRATE.Tables(0).Rows(0)("RATE"))
                                dblICBASEDRATEMIN = gf_CorrectNumericField(v_dsIRRATE.Tables(0).Rows(0)("FLRRATE"))
                                dblICBASEDRATEMAX = gf_CorrectNumericField(v_dsIRRATE.Tables(0).Rows(0)("CELRATE"))
                            Else
                                'LÃ£i suáº¥t tháº£ ná»•i háº¿t hiá»‡u lá»±c 
                                dblICBASEDRATE = 0
                            End If
                        End If
                    End If


                    'Lá»?c giÃ¡ trá»‹ theo phÃ¢n trang vÃ  bá»™ Fillter khai bÃ¡o
                    Select Case ATTR_MODULE
                        Case SUB_SYSTEM_SE
                            'PHAN HE SE PHAI LAY THEM THONG TIN VE CHUNG KHOAN
                            v_strSQL = "SELECT AF.TRADERATE, AF.DEPORATE, INF.PARVALUE, SEINF.DEPOFEEUNIT, SEINF.DEPOFEELOT, SEINF.CURRPRICE, AF.MISCRATE, MST.* " & ControlChars.CrLf _
                                & "FROM AFMAST AF, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW," & ATTR_MODULE & "MAST.* FROM " & ATTR_MODULE & "MAST) MOD  WHERE 0=0  " & v_strBCHFillter & "  ) MST, SECURITIES_INFO SEINF, SBSECURITIES INF " & ControlChars.CrLf _
                                & "WHERE AF.ACCTNO=MST.AFACCTNO AND MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                                & "AND MST.CODEID=SEINF.CODEID AND INF.CODEID=SEINF.CODEID " & ControlChars.CrLf _
                                & " AND  MST.AFACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))" 'DIEU KIEN LOAI BO NHUNG KHACH HANG DUOC MIEN PHI
                        Case SUB_SYSTEM_CF
                            'v_strSQL = "SELECT MST.ACCTNO AFACCTNO,MST.* " & ControlChars.CrLf _
                            '& " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,AFMAST.* FROM AFMAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST WHERE MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                            '& " AND  MST.ACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND  EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))" 'DIEU KIEN LOAI BO NHUNG KHACH HANG DUOC MIEN PHI
                            'v_strSQL = " SELECT * FROM (SELECT MST.*,NVL(OD.SELLAMT,0) SELLAMT FROM (SELECT MST.ACCTNO AFACCTNO,TYP.VAT,MST.* " & ControlChars.CrLf _
                            '& " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,AFMAST.* FROM AFMAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST, AFTYPE TYP WHERE MST.ACTYPE=TYP.ACTYPE AND MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                            '& " AND  MST.ACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND  EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))) MST, " & ControlChars.CrLf _
                            '& "(SELECT ACCTNO, SUM(AMT) SELLAMT FROM STSCHD WHERE STATUS ='C' AND DUETYPE ='RM' GROUP BY ACCTNO) OD WHERE MST.ACCTNO=OD.ACCTNO(+)) MST WHERE 0=0  "
                            v_strSQL = " SELECT * FROM (SELECT MST.*,NVL(OD.SELLAMT,0) SELLAMT FROM (SELECT MST.ACCTNO AFACCTNO,TYP.VAT,MST.* " & ControlChars.CrLf _
                            & " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,AFMAST.* FROM AFMAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST, AFTYPE TYP WHERE MST.ACTYPE=TYP.ACTYPE AND MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                            & " AND  MST.ACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND  EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))) MST, " & ControlChars.CrLf _
                            & "(SELECT ACCTNO, SUM(AMT) SELLAMT FROM STSCHD ST WHERE STATUS ='C' AND DUETYPE ='RM' " & ControlChars.CrLf _
                            & " AND CLEARDAY = (SELECT SUM(CASE WHEN CLDR.HOLIDAY = 'Y' THEN 0 ELSE 1 END)-1 " & ControlChars.CrLf _
                            & "             FROM SBCLDR CLDR " & ControlChars.CrLf _
                            & "             WHERE CLDR.CLDRTYPE = '000' AND CLDR.SBDATE >= ST.TXDATE AND CLDR.SBDATE <= TO_DATE ('" & v_strCURRDATE & "', '" & gc_FORMAT_DATE & "')) " & ControlChars.CrLf _
                            & " GROUP BY ACCTNO) OD WHERE MST.ACCTNO=OD.ACCTNO(+)) MST WHERE 0=0  "
                        Case SUB_SYSTEM_LN
                            v_strSQL = "SELECT MST.* " & ControlChars.CrLf _
                                & " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW," & ATTR_MODULE & "MAST.* FROM " & ATTR_MODULE & "MAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST " & ControlChars.CrLf _
                                & " WHERE MST.ACTYPE = '" & v_strACTYPE & "' "
                        Case SUB_SYSTEM_CI
                            v_strSQL = "SELECT AF.TRADERATE, AF.DEPORATE, AF.MISCRATE, nvl(STS.TRFEXEAMT,0) TRFEXEAMT, MST.* " & ControlChars.CrLf _
                                & " FROM AFMAST AF, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW," & ATTR_MODULE & "MAST.* FROM " & ATTR_MODULE & "MAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST, " & ControlChars.CrLf _
                                & " (select acctno , sum(trfexeamt) trfexeamt " & ControlChars.CrLf _
                                & " from stschd sts, sbsecurities sb " & ControlChars.CrLf _
                                & " where sts.codeid = sb.codeid and duetype = 'SM' and trfbuysts = 'N' " & ControlChars.CrLf _
                                & "     and sts.cleardate <= (select to_date(varvalue,'DD/MM/RRRR') from sysvar where varname = 'CURRDATE') " & ControlChars.CrLf _
                                & " group by acctno) sts " & ControlChars.CrLf _
                                & " WHERE AF.ACCTNO=MST.AFACCTNO AND AF.ACCTNO = sts.ACCTNO(+) AND MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                                & " AND  MST.AFACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))" 'DIEU KIEN LOAI BO NHUNG KHACH HANG DUOC MIEN PHI
                        Case Else
                            v_strSQL = "SELECT AF.TRADERATE, AF.DEPORATE, AF.MISCRATE, MST.* " & ControlChars.CrLf _
                                & " FROM AFMAST AF, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW," & ATTR_MODULE & "MAST.* FROM " & ATTR_MODULE & "MAST) MOD  WHERE 0=0 " & v_strBCHFillter & "  ) MST WHERE AF.ACCTNO=MST.AFACCTNO AND MST.ACTYPE='" & v_strACTYPE & "' " & ControlChars.CrLf _
                                & " AND  MST.AFACCTNO NOT IN (SELECT AFACCTNO FROM EXAFMAST WHERE STATUS <> 'E' AND EXTYPE='B' AND MODCODE='" & v_strMODCODE & "' AND EVENTCODE='" & v_strEVENTCODE & "' AND EXPDATE>=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'))" 'DIEU KIEN LOAI BO NHUNG KHACH HANG DUOC MIEN PHI
                    End Select

                    If Len(Trim(v_strCRITERIA)) > 0 Then
                        v_strCRITERIA = v_strCRITERIA.Replace("<$CURRDATE>", "TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "' )")
                        v_strSQL = v_strSQL & " AND " & v_strCRITERIA
                    End If

                    v_dsMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    If v_dsMAST.Tables(0).Rows.Count > 0 Then
                        '3. Vá»›i má»—i tÃ i khoáº£n thá»±c hiá»‡n tÃ­nh toÃ¡n theo cÃ´ng thá»©c ICCF
                        '3.1 Lay danh sach cac phep toan cua Events
                        v_strSQL = "SELECT MST.* FROM ICCFTX MST WHERE MODCODE='" & ATTR_MODULE & "' AND EVENTCODE='" & v_strEVENTCODE & "' ORDER BY TXCD"
                        v_dsICCFTX = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                        If v_dsICCFTX.Tables(0).Rows.Count > 0 Then
                            'Dung thong tin bang ICCFTX
                            ReDim v_arrICCFTX(v_dsICCFTX.Tables(0).Rows.Count - 1)
                            For intTXCount As Integer = 0 To v_dsICCFTX.Tables(0).Rows.Count - 1 Step 1
                                Dim v_objICCFTX As New ICCFTX
                                v_objICCFTX.ICRULE = v_strEVENTCODE
                                v_objICCFTX.TXCD = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("TXCD")))
                                v_objICCFTX.SORU = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("SORU")))
                                v_objICCFTX.DATATYPE = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("DATATYPE")))
                                v_objICCFTX.REFNAME = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("REFNAME")))
                                v_objICCFTX.AMTEXP = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("AMTEXP")))
                                v_objICCFTX.CMPCD = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("CMPCD")))
                                v_objICCFTX.OPERAND = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("OPERAND")))
                                v_objICCFTX.CMPEXP = Trim(gf_CorrectStringField(v_dsICCFTX.Tables(0).Rows(intTXCount)("CMPEXP")))
                                v_arrICCFTX(intTXCount) = v_objICCFTX
                            Next

                            '3.2 Xac dinh phep toan cho tung tai khoan
                            For intMastCount As Integer = 0 To v_dsMAST.Tables(0).Rows.Count - 1
#If DEBUG Then
                                'Log lai thong tin cho debug
                                LogError.Write("Source: " & v_strErrorSource & vbNewLine _
                                    & "Error message: " & ATTR_MODULE & "." & v_strACTYPE & "." & v_strEVENTCODE & "." & intMastCount, "EventLogEntryType.Error")
#End If

                                '4. Tao giao dich tuong ung
                                '4.1 Tinh toan cac gia tri cho mang ICCFTX
                                intIndexICCFBAL = -1
                                intIndexICCFRATE = -1
                                intIndexINTBAL = -1
                                dblBASEDRATE = 0
                                For i = 0 To v_arrICCFTX.GetLength(0) - 1 Step 1
                                    If Not v_arrICCFTX(i) Is Nothing Then
                                        '4.1.1 Kiá»ƒm tra Ä‘iá»?u kiá»‡n Ä‘á»ƒ thá»±c hiá»‡n Rule cÃ³ thoáº£ mÃ£n khÃ´ng
                                        v_blnRuleAllow = False
                                        v_blnMinMax = False 'Máº·c Ä‘á»‹nh lÃ  khÃ´ng so sÃ¡nh
                                        v_dblMinMaxValue = 0
                                        v_strCMPCD = v_arrICCFTX(i).CMPCD
                                        v_strOPERAND = v_arrICCFTX(i).OPERAND
                                        v_strCMPEXP = v_arrICCFTX(i).CMPEXP

                                        'Ghi nháº­n vá»‹ trÃ­ trÆ°á»?ng BALANCE/RATE
                                        If v_arrICCFTX(i).REFNAME = "ICCFBAL" Then intIndexICCFBAL = i
                                        If v_arrICCFTX(i).REFNAME = "ICCFRATE" Then intIndexICCFRATE = i
                                        'Ghi nháº­n vá»‹ trÃ­ trÆ°á»?ng INTAMT
                                        If v_arrICCFTX(i).REFNAME = "INTAMT" Then intIndexINTAMT = i
                                        'Ghi nháº­n vá»‹ trÃ­ trÆ°á»?ng biá»ƒu thá»©c sá»‘ tráº£ vá»?
                                        If v_arrICCFTX(i).TXCD = v_strFLDTXCD Then
                                            intIndexINTBAL = i
                                        End If

                                        If Len(v_strCMPCD) = 0 Or Len(v_strOPERAND) = 0 Or Len(v_strCMPEXP) = 0 Then
                                            v_blnRuleAllow = True
                                        Else
                                            v_strVALUE = BuildICCFTXEXP(v_arrICCFTX, v_strCMPCD)
                                            v_strCMPCD = v_strVALUE
                                            v_strVALUE = BuildICCFTXEXP(v_arrICCFTX, v_strCMPEXP)
                                            v_strCMPEXP = v_strVALUE
                                            'Kiá»ƒm tra
                                            v_blnRuleAllow = ICCFEvaluateChecking(v_strOPERAND, v_strCMPCD, v_strCMPEXP, v_blnMinMax, v_dblMinMaxValue)
                                        End If

                                        '4.1.2 TÃ­nh toÃ¡n giÃ¡ trá»‹ cho pháº§n tá»­ máº£ng v_arrICCFTX
                                        If Not v_blnRuleAllow Then
                                            'Náº¿u khÃ´ng thoáº£ mÃ£n Ä‘iá»?u kiá»‡n lá»±a chá»?n thÃ¬ láº¥y giÃ¡ trá»‹ máº·c Ä‘á»‹nh
                                            If v_arrICCFTX(i).DATATYPE = "N" Then
                                                v_arrICCFTX(i).VALNUMBER = 0
                                            Else
                                                v_arrICCFTX(i).VALCHAR = String.Empty
                                            End If
                                        Else
                                            If v_arrICCFTX(i).SORU = "S" Then
                                                v_strVALUE = vbNullString
                                                If v_arrICCFTX(i).REFNAME = "DAYS" Then
                                                    'Náº¿u REFNAME lÃ  DAYS, thÃ¬ sáº½ so sÃ¡nh giá»¯a ngÃ y hiá»‡n táº¡i vÃ  giÃ¡ trá»‹ Ä‘Æ°á»£c chá»‰ Ä‘á»‹nh
                                                    'v_strVALEXP = Trim(Mid(v_arrICCFTX(i).AMTEXP, 2))
                                                    'v_strVALUE = Format(gf_CorrectDateField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)), gc_FORMAT_DATE)
                                                    v_strVALUE = Format(DDMMYYYY_SystemDate(v_strICCFLASTDATE), gc_FORMAT_DATE)
                                                    v_lngErrCode = GetSDE_DAYS(v_strVALUE, v_strMONTHDAY, v_intVALUE)
                                                    v_strVALUE = v_intVALUE.ToString
                                                    'TruongLD them 09/03/2009 
                                                ElseIf v_arrICCFTX(i).REFNAME = "MDAYS" Then 'MDAYS 
                                                    v_strVALEXP = Trim(Mid(v_arrICCFTX(i).AMTEXP, 2))
                                                    v_strVALUE = Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)))
                                                    v_strVALUE = Format(DDMMYYYY_SystemDate(v_strVALUE), gc_FORMAT_DATE)
                                                    v_lngErrCode = GetSDE_DAYS(v_strVALUE, v_strMONTHDAY, v_intVALUE)
                                                    v_strVALUE = v_intVALUE.ToString
                                                    v_intDaysCalcInterest = v_intVALUE
                                                    'End TruongLD
                                                ElseIf v_arrICCFTX(i).REFNAME = "DRATE" Then
                                                    v_strVALEXP = Trim(Mid(v_arrICCFTX(i).AMTEXP, 2))
                                                    v_strVALUE = Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)))
                                                    v_lngErrCode = GetSDEFormulaValue(v_strVALEXP, v_strVALUE)
                                                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                                                        Rollback() 'ContextUtil.SetAbort()
                                                        Return v_lngErrCode
                                                    End If

                                                Else
                                                    'Náº¿u lÃ  SDE.System Element Definition thÃ¬ láº¥y giÃ¡ trá»‹ luÃ´n
                                                    'Ä?á»‘i vá»›i SDE thÃ¬ khÃ´ng cáº§n quan tÃ¢m Ä‘áº¿n CMPCD. 
                                                    'Biá»ƒu thá»©c Ä‘iá»?u kiá»‡n chá»‰ sá»­ dá»¥ng cho UDE.User Element Definition
                                                    v_strVALEXP = Trim(Mid(v_arrICCFTX(i).AMTEXP, 2))
                                                    If Len(v_arrICCFTX(i).AMTEXP) >= 2 Then
                                                        Select Case Mid(v_arrICCFTX(i).AMTEXP, 1, 1)
                                                            Case "$"
                                                                If v_strVALEXP = "PERIOD" Then
                                                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(intEventCount)("PERIOD")))
                                                                ElseIf v_strVALEXP = "RULETYPE" Then
                                                                    v_strVALUE = v_strRULETYPE
                                                                ElseIf v_strVALEXP = "EVENTCODE" Then
                                                                    v_strVALUE = v_strEVENTCODE
                                                                ElseIf v_strVALEXP = "GLREF" Then
                                                                    v_strVALUE = v_strGLREF
                                                                ElseIf v_strVALEXP = "RATE" Then
                                                                    v_strVALUE = dblICBASEDRATE.ToString
                                                                Else
                                                                    If v_strVALEXP = "MONTHDAY" Then
                                                                        'Lay gia tri duoc xac dinh trong ICCFMAP
                                                                        v_strVALUE = v_strMONTHDAY
                                                                    ElseIf v_strVALEXP = "YEARDAY" Then
                                                                        'Lay gia tri duoc xac dinh trong ICCFMAP
                                                                        v_strVALUE = v_strYEARDAY
                                                                    End If
                                                                    'Lay du lieu SDE
                                                                    v_lngErrCode = GetSDEFormulaValue(v_strVALEXP, v_strVALUE)
                                                                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                                                                        Rollback() 'ContextUtil.SetAbort()
                                                                        Return v_lngErrCode
                                                                    End If
                                                                End If
                                                            Case "@"
                                                                'Lay du lieu truc tiep
                                                                v_strVALUE = v_strVALEXP
                                                            Case "#"
                                                                'Lay du lieu tu thong tin tai khoan
                                                                If v_arrICCFTX(i).DATATYPE = "D" Then
                                                                    v_strVALUE = Format(gf_CorrectDateField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)), gc_FORMAT_DATE)
                                                                ElseIf v_arrICCFTX(i).DATATYPE = "N" Then
                                                                    v_strVALUE = Trim(gf_CorrectNumericField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)))
                                                                ElseIf v_arrICCFTX(i).DATATYPE = "C" Then
                                                                    v_strVALUE = Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)(v_strVALEXP)))
                                                                End If
                                                            Case Else
                                                        End Select
                                                    End If
                                                End If
                                                'GÃ¡n giÃ¡ trá»‹ tráº£ vá»?
                                                If v_arrICCFTX(i).DATATYPE = "N" Then
                                                    v_arrICCFTX(i).VALNUMBER = FRound(CDbl(v_strVALUE), 4)
                                                Else
                                                    v_arrICCFTX(i).VALCHAR = v_strVALUE
                                                End If

                                            ElseIf v_arrICCFTX(i).SORU = "U" Then
                                                'Biá»ƒu thá»©c sá»‘ há»?c: Chá»‰ sá»­ dá»¥ng cho UDE
                                                If v_blnMinMax Then
                                                    'Náº¿u lÃ  phÃ©p toÃ¡n so sÃ¡nh láº¥y trá»±c tiáº¿p giÃ¡ trá»‹
                                                    If v_arrICCFTX(i).DATATYPE = "N" Then
                                                        v_arrICCFTX(i).VALNUMBER = FRound(v_dblMinMaxValue, 4)
                                                    End If
                                                Else
                                                    If v_arrICCFTX(i).DATATYPE = "N" Then
                                                        v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(i).AMTEXP)
                                                        v_arrICCFTX(i).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)
                                                    End If
                                                End If
                                            End If

                                        End If 'Cá»§a If Not v_blnRuleAllow Then

                                    End If 'Cá»§a If Not v_arrICCFTX(i) Is Nothing Then
                                Next 'Cá»§a For intMastCount As Integer = 0 To v_dsMAST.Tables(0).Rows.Count - 1

                                '4.2 Náº¡p giao dá»‹ch tÆ°Æ¡ng á»©ng trÃªn cÆ¡ sá»Ÿ thÃ´ng tin cá»§a máº£ng ICCFTX
                                'PhÃ¢n loáº¡i RULETYPE (Fixed/Tier/Cluster) Ä‘á»ƒ cÃ³ cÃ¡ch xá»­ lÃ½ tÆ°Æ¡ng á»©ng
                                'TrÆ°á»?ng sá»‘ dÆ° Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘á»ƒ MAP lÃ  trÆ°á»?ng cÃ³ AMTEXP=$ICCFBAL
                                'Táº¡o giao dá»‹ch ICCF: CÃ¡c giao dá»‹ch sinh ra tá»« ICCF khi khai bÃ¡o FLDMASTER sáº½ Ä‘á»ƒ DEFNAME=REFNAME cá»§a ICCFTX


                                'Láº¥y cÃ¡c Tier cá»§a trÆ°á»?ng sá»‘ Ä‘á»ƒ tÃ­nh toÃ¡n náº¿u cÃ³
                                If Not (intIndexICCFBAL = -1 Or intIndexICCFRATE = -1 Or intIndexINTBAL = -1) Then
                                    v_strSQL = "SELECT MST.* FROM ICCFTIER MST WHERE MODCODE='" & ATTR_MODULE & "' AND ACTYPE='" & v_strACTYPE & "' AND EVENTCODE='" & v_strEVENTCODE & "'"
                                    v_dsTIER = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_dsTIER.Tables(0).Rows.Count > 0 Then
                                        'CÃ³ Ä‘á»‹nh nghÄ©a cÃ¡c tier xá»­ lÃ½

                                        'TruongLD Them 09/03/2010
                                        'Xu ly them truong hop neu tinh lai theo PP binh quan thang thi lay so du chia cho so ngay can tinh lai
                                        'dblBALANCE = v_arrICCFTX(intIndexICCFBAL).VALNUMBER     'Sá»‘ dÆ° tÃ­nh toÃ¡n cá»§a tÃ i khoáº£n
                                        dblBALANCE = v_arrICCFTX(intIndexICCFBAL).VALNUMBER / v_intDaysCalcInterest     'Sá»‘ dÆ° tÃ­nh toÃ¡n cá»§a tÃ i khoáº£n
                                        dblBASEDRATE = v_arrICCFTX(intIndexICCFRATE).VALNUMBER  'LÃ£i suáº¥t cÆ¡ sá»Ÿ
                                        For intTierCount As Integer = 0 To v_dsTIER.Tables(0).Rows.Count - 1 Step 1
                                            'Duyá»‡t tá»«ng Tier Ä‘á»ƒ xá»­ lÃ½ 
                                            dblFRAMT = gf_CorrectNumericField(v_dsTIER.Tables(0).Rows(intTierCount)("FRAMT"))
                                            dblTOAMT = gf_CorrectNumericField(v_dsTIER.Tables(0).Rows(intTierCount)("TOAMT"))
                                            dblDELTA = gf_CorrectNumericField(v_dsTIER.Tables(0).Rows(intTierCount)("DELTA"))
                                            Select Case v_strRULETYPE
                                                Case "F"    'Fixed
                                                    'Láº¥y toÃ n bá»™ sá»‘ dÆ°
                                                    v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblBALANCE, 4)
                                                    v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblBASEDRATE + dblDELTA
                                                    'TÃ­nh toÃ¡n láº¡i thÃ´ng tin lÃ£i
                                                    v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(intIndexINTBAL).AMTEXP)
                                                    v_arrICCFTX(intIndexINTBAL).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)
                                                    'Cusstomize fee den tung khach hang
                                                    If v_strLine = "Y" Then
                                                        v_strSQL = "SELECT * FROM EXAFMAST WHERE " & ControlChars.CrLf _
                                                           & "AFACCTNO = '" & Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)("AFACCTNO"))) & "' " & ControlChars.CrLf _
                                                           & "AND EVENTCODE = '" & v_strEVENTCODE & "' AND STATUS = 'C'"
                                                        v_dsEXAFMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                                        If v_dsEXAFMAST.Tables(0).Rows.Count > 0 Then
                                                            v_strVALUE = v_arrICCFTX(intIndexICCFRATE).VALNUMBER
                                                            Select Case gf_CorrectStringField(v_dsEXAFMAST.Tables(0).Rows(0)("OPERAND"))
                                                                Case "+"
                                                                    v_strVALUE = v_strVALUE + gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                Case "-"
                                                                    v_strVALUE = v_strVALUE - gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                Case "="
                                                                    v_strVALUE = gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                            End Select
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = v_strVALUE
                                                        End If
                                                    End If
                                                    'Check tren tang loai hinh
                                                    If v_strICTYPE = "P" And v_strICRATECD = "F" Then
                                                        'Neu lai suat tha noi phai kiem tra lai suat san va tran
                                                        If v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblICBASEDRATEMIN And dblICBASEDRATEMIN > 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = FRound(dblICBASEDRATEMIN, 4)
                                                        ElseIf v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblICBASEDRATEMAX And dblICBASEDRATEMAX > 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = FRound(dblICBASEDRATEMAX, 4)
                                                        End If
                                                    End If

                                                    'Check tren tang he thong cao nhat
                                                    If dblSYSRATEMIN >= 0 Then
                                                        v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblSYSRATEMIN, dblSYSRATEMIN, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                    End If
                                                    If dblSYSRATEMAX >= 0 Then
                                                        v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblSYSRATEMAX, dblSYSRATEMAX, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                    End If
                                                    'Tinh lai gia tri phi theo lai suat moi
                                                    v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(intIndexINTBAL).AMTEXP)
                                                    v_arrICCFTX(intIndexINTBAL).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)

                                                    'Tao giao dich
                                                    'Vá»›i kiá»ƒu fixed thÃ¬ chá»‰ tÃ­nh lÃ£i má»™t láº§n, theo lÃ£i suáº¥t cá»§a tier Ä‘áº§u tiÃªn lÃ  cá»™ng 0
                                                    ICCFBuildTransact(v_arrICCFTX, v_strTLTXCD, v_strFLDTXCD, v_strBATCHNAME, v_dblMINBAL, v_dblMAXBAL)
                                                    Exit For
                                                Case "T"    'Tier
                                                    'Chá»‰ cÃ³ má»™t má»©c lÃ£i suáº¥t chung cho sá»‘ dÆ° tÃ­nh lÃ£i
                                                    dblRATE = 0
                                                    If dblFRAMT <= 0 And dblBALANCE <= dblTOAMT Then  'KhÃ´ng xÃ¡c Ä‘á»‹nh má»©c sÃ n cho sá»‘ dÆ°
                                                        dblRATE = dblBASEDRATE + dblDELTA
                                                    ElseIf dblFRAMT < dblBALANCE And dblTOAMT <= 0 Then   'KhÃ´ng xÃ¡c Ä‘á»‹nh má»©c tráº§n cho sá»‘ dÆ°
                                                        dblRATE = dblBASEDRATE + dblDELTA
                                                    ElseIf dblFRAMT <= 0 And dblTOAMT <= 0 Then   'KhÃ´ng xÃ¡c Ä‘á»‹nh má»©c tráº§n/sÃ n cho sá»‘ dÆ°
                                                        dblRATE = dblBASEDRATE + dblDELTA
                                                    Else    'Xá»­ lÃ½ cho dblFRAMT > dblTOAMT > 0 
                                                        If dblTOAMT >= dblBALANCE And dblBALANCE > dblFRAMT Then
                                                            dblRATE = dblBASEDRATE + dblDELTA
                                                        End If
                                                    End If
                                                    If dblRATE > 0 Then
                                                        v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblRATE
                                                        v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblBALANCE, 4)
                                                        'Cusstomize fee den tung khach hang
                                                        If v_strLine = "Y" Then
                                                            v_strSQL = "SELECT * FROM EXAFMAST WHERE " & ControlChars.CrLf _
                                                               & "AFACCTNO = '" & Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)("AFACCTNO"))) & "' " & ControlChars.CrLf _
                                                               & "AND EVENTCODE = '" & v_strEVENTCODE & "' AND STATUS = 'C'"
                                                            v_dsEXAFMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                                            If v_dsEXAFMAST.Tables(0).Rows.Count > 0 Then
                                                                v_strVALUE = v_arrICCFTX(intIndexICCFRATE).VALNUMBER
                                                                Select Case gf_CorrectStringField(v_dsEXAFMAST.Tables(0).Rows(0)("OPERAND"))
                                                                    Case "+"
                                                                        v_strVALUE = v_strVALUE + gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                    Case "-"
                                                                        v_strVALUE = v_strVALUE - gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                    Case "="
                                                                        v_strVALUE = gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                End Select
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = v_strVALUE
                                                            End If
                                                        End If
                                                        'Check Fee tang loai hinh tha noi
                                                        If v_strICTYPE = "P" And v_strICRATECD = "F" Then
                                                            'Neu lai suat tha noi phai kiem tra lai suat san va tran
                                                            If v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblICBASEDRATEMIN And dblICBASEDRATEMIN > 0 Then
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = FRound(dblICBASEDRATEMIN, 4)
                                                            ElseIf v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblICBASEDRATEMAX And dblICBASEDRATEMAX > 0 Then
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = FRound(dblICBASEDRATEMAX, 4)
                                                            End If
                                                        End If

                                                        'Check tren tang he thong cao nhat
                                                        If dblSYSRATEMIN >= 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblSYSRATEMIN, dblSYSRATEMIN, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                        End If
                                                        If dblSYSRATEMAX >= 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblSYSRATEMAX, dblSYSRATEMAX, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                        End If

                                                        'Tinh lai gia tri phi, theo lai suat moi
                                                        v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(intIndexINTBAL).AMTEXP)
                                                        v_arrICCFTX(intIndexINTBAL).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)

                                                        'Tao giao dich
                                                        ICCFBuildTransact(v_arrICCFTX, v_strTLTXCD, v_strFLDTXCD, v_strBATCHNAME, v_dblMINBAL, v_dblMAXBAL)
                                                    End If
                                                Case "C"    'Cluster
                                                    'Má»—i Tier cÃ³ má»™t má»©c lÃ£i suáº¥t khÃ¡c nhau
                                                    dblRATE = dblBASEDRATE + dblDELTA
                                                    If dblFRAMT <= 0 Then   'KhÃ´ng xÃ¡c Ä‘á»‹nh má»©c sÃ n cho sá»‘ dÆ°
                                                        If dblTOAMT >= dblBALANCE Then
                                                            v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblBALANCE, 4)
                                                        Else
                                                            v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblTOAMT, 4)
                                                        End If
                                                    ElseIf dblTOAMT <= 0 Then   'KhÃ´ng xÃ¡c Ä‘á»‹nh má»©c tráº§n cho sá»‘ dÆ°
                                                        If dblBALANCE > dblFRAMT Then
                                                            v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblBALANCE - dblFRAMT, 4)
                                                        Else
                                                            v_arrICCFTX(intIndexICCFBAL).VALNUMBER = 0
                                                        End If
                                                    Else    'Xá»­ lÃ½ cho dblFRAMT > dblTOAMT > 0 
                                                        If dblTOAMT >= dblBALANCE And dblBALANCE > dblFRAMT Then
                                                            v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblBALANCE - dblFRAMT, 4)
                                                        Else
                                                            'v_arrICCFTX(intIndexICCFBAL).VALNUMBER = dblTOAMT - dblFRAMT
                                                            '----------------------------
                                                            'Sá»­a thay dÃ²ng code bá»‹ Ä‘Ã³ng á»Ÿ trÃªn
                                                            'Vi trÆ°á»?ng há»£p trÃªn chÆ°a tÃ­nh cho trÆ°á»?ng há»£p dblBALANCE <= dblFRAMT
                                                            If dblBALANCE <= dblFRAMT Then
                                                                v_arrICCFTX(intIndexICCFBAL).VALNUMBER = 0
                                                            Else
                                                                v_arrICCFTX(intIndexICCFBAL).VALNUMBER = FRound(dblTOAMT - dblFRAMT, 4)
                                                            End If
                                                            '------------------------------
                                                        End If
                                                    End If
                                                    If dblRATE > 0 And v_arrICCFTX(intIndexICCFBAL).VALNUMBER > 0 Then
                                                        v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblRATE
                                                        'Cusstomize fee den tung khach hang
                                                        If v_strLine = "Y" Then
                                                            v_strSQL = "SELECT * FROM EXAFMAST WHERE " & ControlChars.CrLf _
                                                               & "AFACCTNO = '" & Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)("AFACCTNO"))) & "' " & ControlChars.CrLf _
                                                               & "AND EVENTCODE = '" & v_strEVENTCODE & "' AND STATUS = 'C'"
                                                            v_dsEXAFMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                                            If v_dsEXAFMAST.Tables(0).Rows.Count > 0 Then
                                                                v_strVALUE = v_arrICCFTX(intIndexICCFRATE).VALNUMBER
                                                                Select Case gf_CorrectStringField(v_dsEXAFMAST.Tables(0).Rows(0)("OPERAND"))
                                                                    Case "+"
                                                                        v_strVALUE = v_strVALUE + gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                    Case "-"
                                                                        v_strVALUE = v_strVALUE - gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                    Case "="
                                                                        v_strVALUE = gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                                End Select
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = v_strVALUE
                                                            End If
                                                        End If
                                                        If v_strICTYPE = "P" And v_strICRATECD = "F" Then
                                                            ''Neu lai suat tha noi phai kiem tra lai suat san va tran
                                                            If v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblICBASEDRATEMIN And dblICBASEDRATEMIN > 0 Then
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblICBASEDRATEMIN
                                                            ElseIf v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblICBASEDRATEMAX And dblICBASEDRATEMAX > 0 Then
                                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblICBASEDRATEMAX
                                                            End If
                                                        End If

                                                        'Check tren tang he thong cao nhat
                                                        If dblSYSRATEMIN >= 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblSYSRATEMIN, dblSYSRATEMIN, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                        End If
                                                        If dblSYSRATEMAX >= 0 Then
                                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblSYSRATEMAX, dblSYSRATEMAX, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                                        End If

                                                        'Tinh lai gia tri lai
                                                        v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(intIndexINTBAL).AMTEXP)
                                                        v_arrICCFTX(intIndexINTBAL).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)
                                                        'Táº¡o giao dá»‹ch
                                                        ICCFBuildTransact(v_arrICCFTX, v_strTLTXCD, v_strFLDTXCD, v_strBATCHNAME, v_dblMINBAL, v_dblMAXBAL)
                                                    End If
                                            End Select
                                        Next
                                    Else
                                        'Cusstomize fee den tung khach hang
                                        If v_strLine = "Y" Then
                                            v_strSQL = "SELECT * FROM EXAFMAST WHERE " & ControlChars.CrLf _
                                               & "AFACCTNO = '" & Trim(gf_CorrectStringField(v_dsMAST.Tables(0).Rows(intMastCount)("AFACCTNO"))) & "' " & ControlChars.CrLf _
                                               & "AND EVENTCODE = '" & v_strEVENTCODE & "' AND STATUS = 'C'"
                                            v_dsEXAFMAST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                            If v_dsEXAFMAST.Tables(0).Rows.Count > 0 Then
                                                v_strVALUE = v_arrICCFTX(intIndexICCFRATE).VALNUMBER
                                                Select Case gf_CorrectStringField(v_dsEXAFMAST.Tables(0).Rows(0)("OPERAND"))
                                                    Case "+"
                                                        v_strVALUE = v_strVALUE + gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                    Case "-"
                                                        v_strVALUE = v_strVALUE - gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                    Case "="
                                                        v_strVALUE = gf_CorrectNumericField(v_dsEXAFMAST.Tables(0).Rows(0)("DELTA"))
                                                End Select
                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = v_strVALUE
                                            End If
                                        End If
                                        'Check tren tang system
                                        If v_strICTYPE = "P" And v_strICRATECD = "F" Then
                                            If v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblICBASEDRATEMIN And dblICBASEDRATEMIN > 0 Then
                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblICBASEDRATEMIN
                                            ElseIf v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblICBASEDRATEMAX And dblICBASEDRATEMAX > 0 Then
                                                v_arrICCFTX(intIndexICCFRATE).VALNUMBER = dblICBASEDRATEMAX
                                            End If
                                        End If

                                        'Check tren tang he thong cao nhat
                                        If dblSYSRATEMIN >= 0 Then
                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER < dblSYSRATEMIN, dblSYSRATEMIN, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                        End If
                                        If dblSYSRATEMAX >= 0 Then
                                            v_arrICCFTX(intIndexICCFRATE).VALNUMBER = IIf(v_arrICCFTX(intIndexICCFRATE).VALNUMBER > dblSYSRATEMAX, dblSYSRATEMAX, v_arrICCFTX(intIndexICCFRATE).VALNUMBER)
                                        End If
                                        'Tinh lai gia tri phi theo lai suat moi
                                        v_strVALEXP = BuildICCFTXEXP(v_arrICCFTX, v_arrICCFTX(intIndexINTBAL).AMTEXP)
                                        v_arrICCFTX(intIndexINTBAL).VALNUMBER = FRound(CDbl(v_objEval.Eval(v_strVALEXP).ToString), 4)

                                        'Build giao dich
                                        ICCFBuildTransact(v_arrICCFTX, v_strTLTXCD, v_strFLDTXCD, v_strBATCHNAME, v_dblMINBAL, v_dblMAXBAL)
                                    End If 'Cá»§a If v_dsTIER.Tables(0).Rows.Count > 0 Then
                                End If 'Cá»§a If Not (intIndexICCFBAL = -1 Or intIndexICCFRATE = -1 Or intIndexINTBAL = -1) Then

                            Next 'Cá»§a For intMastCount As Integer = 0 To v_dsMAST.Tables(0).Rows.Count - 1
                        End If 'Cá»§a If v_dsICCFTX.Tables(0).Rows.Count > 0 Then

                    End If 'Cá»§a If v_dsMAST.Tables(0).Rows.Count > 0 Then

                Next 'Cá»§a For intEventCount As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
            End If 'Cá»§a If v_ds.Tables(0).Rows.Count > 0 Then


            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    'HÃ m nÃ y xÃ¢y dá»±ng Ä‘á»ƒ thá»±c hiá»‡n kiá»ƒm tra pháº§n tá»­ ICCF cÃ³ thoáº£ mÃ£n Ä‘iá»?u kiá»‡n khÃ´ng
    Private Function ICCFEvaluateChecking(ByVal v_strOPERAND As String, ByVal v_strCMPCD As String, ByVal v_strCMPEXP As String,
        ByRef v_blnMinMax As Boolean, ByRef v_dblMinMaxValue As Double) As Boolean
        Dim v_objEval As New Evaluator, v_blnRuleAllow As Boolean = False
        Select Case v_strOPERAND
            Case ">>"
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) > CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_blnRuleAllow = True
                End If
            Case ">="
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) >= CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_blnRuleAllow = True
                End If
            Case "<<"
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) < CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then

                End If
            Case "<="
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) <= CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_blnRuleAllow = True
                End If
            Case "=="
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) = CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_blnRuleAllow = True
                End If
            Case "<>"
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) <> CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_blnRuleAllow = True
                End If
            Case "IN"
                If InStr(v_strCMPEXP, v_strCMPCD) > 0 Then
                    v_blnRuleAllow = True
                End If
            Case "NI"
                If Not InStr(v_strCMPEXP, v_strCMPCD) > 0 Then
                    v_blnRuleAllow = True
                End If
            Case "MI"
                'TrÆ°á»?ng há»£p nÃ y tráº£ vá»? giÃ¡ trá»‹ MIN vÃ  Allow
                v_blnRuleAllow = True
                v_blnMinMax = True
                If CDbl(v_objEval.Eval(v_strCMPCD).ToString) > CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_dblMinMaxValue = CDbl(v_objEval.Eval(v_strCMPEXP).ToString)
                Else
                    v_dblMinMaxValue = CDbl(v_objEval.Eval(v_strCMPCD).ToString)
                End If
            Case "MA"
                'TrÆ°á»?ng há»£p nÃ y tráº£ vá»? giÃ¡ trá»‹ MAX vÃ  Allow
                v_blnRuleAllow = True
                v_blnMinMax = True
                If Not CDbl(v_objEval.Eval(v_strCMPCD).ToString) > CDbl(v_objEval.Eval(v_strCMPEXP).ToString) Then
                    v_dblMinMaxValue = CDbl(v_objEval.Eval(v_strCMPEXP).ToString)
                Else
                    v_dblMinMaxValue = CDbl(v_objEval.Eval(v_strCMPCD).ToString)
                End If
            Case Else
        End Select
        Return v_blnRuleAllow
    End Function

    'HÃ m nÃ y xÃ¢y dá»±ng giao dá»‹ch theo luáº­t ICCF cÄƒn cá»© thÃ´ng tin cá»§a máº£ng ICCFTX
    Private Function ICCFBuildTransact(ByVal v_arrICCFTX() As ICCFTX,
        ByVal v_strTLTXCD As String, ByVal v_strFLDTXCD As String, ByVal v_strBATCHNAME As String, ByVal v_dblMINBAL As Double, ByVal v_dblMAXBAL As Double) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ICCFBuildTransact." & v_strBATCHNAME & "." & v_strTLTXCD, v_strErrorMessage As String
        Dim v_strSQL, v_strVALUE, v_strDEFNAME, v_strFLDNAME, v_strFLDTYPE, v_strFLDACCT, v_strDESC, v_strINTAMT As String, v_dsTLLOG As DataSet
        Dim v_dblINTAMT As Double
        Dim v_obj As New DataAccess, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strACCTNO As String
        Try
            v_strVALUE = GetICCFTXValueByTXCD(v_arrICCFTX, v_strFLDTXCD)
            'Náº¿u cÃ³ trÆ°á»?ng INTAMT thÃ¬ so sÃ¡nh giÃ¡ trá»‹ trÆ°á»?ng nÃ y vá»›i giÃ¡ trá»‹ max, min.
            '   Náº¿u lá»›n hÆ¡n Max thÃ¬ láº¥y max
            '   Náº¿u nhá»? hÆ¡n Min thÃ¬ láº¥y Min
            v_strINTAMT = GetICCFTXValueByREFNAME(v_arrICCFTX, "INTAMT")
            If v_strINTAMT <> String.Empty Then
                If IsNumeric(v_strINTAMT) Then
                    v_dblINTAMT = CDbl(v_strINTAMT)
                    If v_dblINTAMT < v_dblMINBAL Then v_dblINTAMT = v_dblMINBAL
                    If v_dblINTAMT > v_dblMAXBAL Then v_dblINTAMT = v_dblMAXBAL
                    For i As Integer = 0 To v_arrICCFTX.GetLength(0) - 1 Step 1
                        If Not v_arrICCFTX(i) Is Nothing Then
                            If Trim(v_arrICCFTX(i).REFNAME) = Trim("INTAMT") Then
                                If v_arrICCFTX(i).DATATYPE = "N" Then
                                    v_arrICCFTX(i).VALNUMBER = v_dblINTAMT
                                Else
                                    v_arrICCFTX(i).VALCHAR = v_strINTAMT
                                End If
                            End If
                        End If
                    Next
                End If
            End If

            If IsNumeric(v_strVALUE) Then
                If CDbl(v_strVALUE) > 0 Then
                    'Táº¡o connection Ä‘áº¿n HOST
                    v_obj.NewDBInstance(gc_MODULE_HOST)
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD

                    v_strSQL = "SELECT FLDMASTER.FLDNAME, FLDMASTER.FLDTYPE, FLDMASTER.DEFNAME, TLTX.EN_TXDESC TLTXDESC, TLTX.MSG_ACCT  " & ControlChars.CrLf _
                        & "FROM FLDMASTER, TLTX WHERE TLTX.TLTXCD=OBJNAME AND OBJNAME='" & v_strTLTXCD & "' ORDER BY ODRNUM"
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                        'Táº¡o pháº§n ná»™i dung cá»§a giao dá»‹ch
                        For j As Integer = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))
                            v_strFLDACCT = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("MSG_ACCT")))
                            v_strDESC = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("TLTXDESC")))
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
                            v_entryNode.InnerText = GetICCFTXValueByREFNAME(v_arrICCFTX, v_strDEFNAME)
                            If Len(Trim(v_entryNode.InnerText)) = 0 And v_strDEFNAME = "DESC" Then
                                v_entryNode.InnerText = v_strDESC
                            End If

                            v_dataElement.AppendChild(v_entryNode)
                            If v_strFLDNAME = v_strFLDACCT Then
                                v_strACCTNO = GetICCFTXValueByREFNAME(v_arrICCFTX, v_strDEFNAME)
                                'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_strACCTNO.Substring(0, 4)
                                'End of modified by MinhTK, 7-Apr-07
                            End If
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                        'Xu ly dac biet cho phan he CI,SE
                        Select Case v_strTLTXCD
                            Case "1160", "1161" 'Lai cong don, lai thau chi
                                v_lngErrCode = GenCIIntTrans(v_xmlDocument)
                            Case "1360", "1364" 'Lai cong don, lai thau chi
                                v_lngErrCode = GenDDIntTrans(v_xmlDocument)
                                'Case "2260"
                                '    v_lngErrCode = GenSECostPrice(v_xmlDocument)
                                'Case "2261" 'So du luu ky cong don
                                '    v_lngErrCode = GenSEDepositoryBalance(v_xmlDocument)
                            Case "1158" 'Lai tinh theo so du binh quan thang
                                v_lngErrCode = GenCIMIntTrans(v_xmlDocument)
                            Case Else 'Neu khong
                                'Ghi nháº­n giao dá»‹ch vÃ o TLLOG
                                v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        End Select
                        'Tra loi
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    End If
                End If 'Cá»§a If CDbl(v_strVALUE) > 0 Then
            End If 'Cá»§a If IsNumeric(v_strVALUE) Then
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'HÃ m nÃ y cáº§n Ä‘Æ°á»£c cÃ¡c phÃ¢n há»‡ nghiá»‡p vá»¥ override Ä‘á»ƒ implement cá»¥ thá»ƒ
    Overridable Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Return ERR_SYSTEM_OK
        Complete() 'ContextUtil.SetComplete()
    End Function

    'HÃ m nÃ y thá»±c hiá»‡n tÃ¬nh ra ngÃ y cÃ¡ch ngÃ y pv_dtFromday lÃ  pv_intNum theo loáº¡i lá»‹ch pv_strCarType
    'pv_strCarType cÃ³ giÃ¡ trá»‹ truyá»?n vÃ o lÃ  "B" hoáº·c "N"
    Private Function DateCalculate(ByVal pv_intNum As Integer, ByVal pv_dtFromday As Date, ByVal pv_strCarType As String) As Date
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strSQL As String, v_intWITHHOLIDAY, v_intWITHOUTHOLIDAY As Integer, v_dtSBDATE As Date
        Dim v_obj As New DataAccess, v_ds As New DataSet
        v_obj.NewDBInstance(gc_MODULE_HOST)
        v_strSQL = "select SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) WITHHOLIDAY,SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) WITHOUTHOLIDAY,MAX(SBDATE) SBDATE from SBCLDR CLR1 where CLR1.CLDRTYPE='000' AND CLR1.SBDATE>= '" & pv_dtFromday & "' AND CLR1.SBDATE< TO_DATE('" & pv_dtFromday & "','" & gc_FORMAT_DATE & "') +" & pv_intNum
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count > 0 Then
            v_intWITHHOLIDAY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("WITHHOLIDAY"))
            v_intWITHOUTHOLIDAY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("WITHOUTHOLIDAY"))
            v_dtSBDATE = gf_CorrectDateField(v_ds.Tables(0).Rows(0)("SBDATE"))
            If pv_dtFromday = "N" Then
                Return v_dtSBDATE
            Else
                If v_intWITHHOLIDAY < pv_intNum Then
                    Return DateCalculate(pv_intNum - v_intWITHHOLIDAY, v_dtSBDATE, "B")
                Else
                    Return v_dtSBDATE
                End If
            End If
        End If
        Return DDMMYYYY_SystemDate(gc_NULL_DATE)
    End Function

    Private Function GenCIIntTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.GenCIIntTrans", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strINTTYPE, v_strFRDATE, v_strTODATE, v_strICCFCD As String
            Dim v_dblBALANCE, v_dblINTAMT, v_dblRATE As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE, v_strDUEDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Cap nhat la ingay tinh lai thau chi, lai tien gui
            'v_strSQL = "UPDATE CIMAST SET CRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ODINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh lÃ£i cá»™ng dá»“n: 1160
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
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
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            v_strFRDATE = v_strVALUE
                        Case "06" 'TODATE
                            v_strTODATE = v_strVALUE
                        Case "10" 'BALANCE
                            v_dblBALANCE = v_dblVALUE
                        Case "11" 'INTAMT
                            v_dblINTAMT = FRound(v_dblVALUE, 4)
                        Case "12" 'RATE
                            v_dblRATE = v_dblVALUE
                        Case "04" 'ICRULE
                            v_strICCFCD = v_strVALUE
                        Case "07" 'INTTYPE
                            v_strINTTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Táº¡o phiáº¿u tÃ­nh lÃ£i
            v_strSQL = "INSERT INTO CIINTTRAN (AUTOID, ACCTNO, INTTYPE, FRDATE, TODATE, ICRULE, IRRATE, INTBAL, INTAMT) " & ControlChars.CrLf _
                & "VALUES (SEQ_CIINTTRAN.NEXTVAL,'" & v_strACCTNO & "','" & v_strINTTYPE & "', " & ControlChars.CrLf _
                & "TO_DATE('" & v_strFRDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "TO_DATE('" & v_strTODATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "'" & v_strICCFCD & "'," & v_dblRATE & "," & v_dblBALANCE & "," & v_dblINTAMT & ")"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Cap nhat lai lai
            Select Case v_strINTTYPE
                Case "CR"
                    v_strSQL = "UPDATE CIMAST SET CRINTACR=CRINTACR+" & v_dblINTAMT & " , CRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strACCTNO & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Case "OD"
                    v_strSQL = "UPDATE CIMAST SET ODINTACR=ODINTACR+" & v_dblINTAMT & ",ODINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')WHERE ACCTNO='" & v_strACCTNO & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End Select
            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function GenDDIntTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.GenCIIntTrans", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strINTTYPE, v_strFRDATE, v_strTODATE, v_strICCFCD As String
            Dim v_dblBALANCE, v_dblINTAMT, v_dblRATE As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh lÃ£i cá»™ng dá»“n: 1160
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
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
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            v_strFRDATE = v_strVALUE
                        Case "06" 'TODATE
                            v_strTODATE = v_strVALUE
                        Case "10" 'BALANCE
                            v_dblBALANCE = v_dblVALUE
                        Case "13" 'INTAMT
                            v_dblINTAMT = FRound(v_dblVALUE, 4)
                        Case "12" 'RATE
                            v_dblRATE = v_dblVALUE
                        Case "04" 'ICRULE
                            v_strICCFCD = v_strVALUE
                        Case "07" 'INTTYPE
                            v_strINTTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Táº¡o phiáº¿u tÃ­nh lÃ£i
            v_strSQL = "INSERT INTO DDINTTRAN (AUTOID, ACCTNO, INTTYPE, FRDATE, TODATE, ICRULE, IRRATE, INTBAL, INTAMT) " & ControlChars.CrLf _
                & "VALUES (SEQ_CIINTTRAN.NEXTVAL,'" & v_strACCTNO & "','" & v_strINTTYPE & "', " & ControlChars.CrLf _
                & "TO_DATE('" & v_strFRDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "TO_DATE('" & v_strTODATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "'" & v_strICCFCD & "'," & v_dblRATE & "," & v_dblBALANCE & "," & v_dblINTAMT & ")"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Cap nhat lai lai
            Select Case v_strINTTYPE
                Case "CR"
                    v_strSQL = "UPDATE DDMAST SET CRINTACR=CRINTACR+" & v_dblINTAMT & " WHERE ACCTNO='" & v_strACCTNO & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Case "OD"
                    v_strSQL = "UPDATE DDMAST SET ODINTACR=ODINTACR+" & v_dblINTAMT & " WHERE ACCTNO='" & v_strACCTNO & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End Select
            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenCIMIntTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Author : TruongLD
        'Date : 09/03/2010
        'Puspose : CI Credit interest by average month calculate 
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.GenCIIntTrans", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strINTTYPE, v_strFRDATE, v_strTODATE, v_strICCFCD As String
            Dim v_dblBALANCE, v_dblINTAMT, v_dblRATE As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE, v_strDUEDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Cap nhat la ingay tinh lai thau chi, lai tien gui
            'v_strSQL = "UPDATE CIMAST SET CRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ODINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh lÃ£i cá»™ng dá»“n: 1160
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
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
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            v_strFRDATE = v_strVALUE
                        Case "06" 'TODATE
                            v_strTODATE = v_strVALUE
                        Case "10" 'BALANCE
                            v_dblBALANCE = v_dblVALUE
                        Case "11" 'INTAMT
                            v_dblINTAMT = FRound(v_dblVALUE, 4)
                        Case "12" 'RATE
                            v_dblRATE = v_dblVALUE
                        Case "04" 'ICRULE
                            v_strICCFCD = v_strVALUE
                        Case "07" 'INTTYPE
                            v_strINTTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Táº¡o phiáº¿u tÃ­nh lÃ£i
            v_strSQL = "INSERT INTO CIINTTRAN (AUTOID, ACCTNO, INTTYPE, FRDATE, TODATE, ICRULE, IRRATE, INTBAL, INTAMT) " & ControlChars.CrLf _
                & "VALUES (SEQ_CIINTTRAN.NEXTVAL,'" & v_strACCTNO & "','" & v_strINTTYPE & "', " & ControlChars.CrLf _
                & "TO_DATE('" & v_strFRDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "TO_DATE('" & v_strTODATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "'" & v_strICCFCD & "'," & v_dblRATE & "," & v_dblBALANCE & "," & v_dblINTAMT & ")"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Cap nhat lai lai
            Select Case v_strINTTYPE
                Case "CR"
                    'Sau khi tinh lai xong : Update MBALANCE = 0 va MCRINTDT = CURRDATE
                    v_strSQL = "UPDATE CIMAST SET MBALANCE = 0, CRINTACR=" & v_dblINTAMT & " , MCRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),  CRINTDT=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strACCTNO & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End Select
            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenSEDepositoryBalance(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.GenSEDepositoryBalance", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strTXDATE As String
            Dim v_dblDAYS, v_dblBALANCE, v_dblQTTY, v_dblPREVQTTY As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            'Ä?á»?c ná»™i dung giao dá»‹ch so du luu ky cá»™ng dá»“n: 2261
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
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
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "04" 'DAYS
                            v_dblDAYS = v_dblVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            'Ghi lai thay doi so du luu ky cong don
            v_strSQL = "INSERT INTO SEDEPOBAL (AUTOID, ACCTNO, TXDATE, DAYS, QTTY, DELTD) " & ControlChars.CrLf _
                & "VALUES (SEQ_SEDEPOBAL.NEXTVAL,'" & v_strACCTNO & "', " & ControlChars.CrLf _
                & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & v_dblDAYS & "," & v_dblQTTY & ",'N')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat so du lu ky cong don
            v_strSQL = "UPDATE SEMAST SET TBALDEPO=TBALDEPO+" & v_dblQTTY * v_dblDAYS & ControlChars.CrLf _
                & " ,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TBALDT=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')" & ControlChars.CrLf _
                & " WHERE ACCTNO='" & v_strACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenSECostPrice(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.GenSECostPrice", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strTXDATE As String
            Dim v_dblCOSTPRICE, v_dblPREVCOSTPRICE, v_dblPREVQTTY, v_dblDCRAMT, v_dblDCRQTTY As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh gia von: 2260
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
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
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "09" 'OLDCOST
                            v_dblPREVCOSTPRICE = v_dblVALUE
                        Case "10" 'COSTPRICE
                            v_dblCOSTPRICE = v_dblVALUE
                        Case "12" 'DCRQTTY
                            v_dblDCRQTTY = v_dblVALUE
                        Case "13" 'DCRAMT
                            v_dblDCRAMT = v_dblVALUE
                    End Select
                End With
            Next

            'Ghi nhan gia von thay doi
            v_strSQL = "INSERT INTO SECOSTPRICE (AUTOID, ACCTNO, TXDATE, COSTPRICE, PREVCOSTPRICE, DCRAMT, DCRQTTY, DELTD) " & ControlChars.CrLf _
                & "VALUES (SEQ_SECOSTPRICE.NEXTVAL,'" & v_strACCTNO & "', " & ControlChars.CrLf _
                & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & v_dblCOSTPRICE & "," & v_dblPREVCOSTPRICE & "," & v_dblDCRAMT & "," & v_dblDCRQTTY & ",'N')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat thong tin gia von
            'v_strSQL = "UPDATE SEMAST SET DCRAMT=0,DCRQTTY=0,PREVQTTY=PREVQTTY+" & v_dblDCRQTTY & ",COSTPRICE=" & v_dblCOSTPRICE & "," & ControlChars.CrLf _
            '    & " LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),COSTDT=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')" & ControlChars.CrLf _
            '    & " WHERE ACCTNO='" & v_strACCTNO & "'"
            v_strSQL = "UPDATE SEMAST SET DCRAMT=0,DCRQTTY=0,PREVQTTY=TRADE+MORTAGE+MARGIN+SECURED+BLOCKED+WITHDRAW,COSTPRICE=" & v_dblCOSTPRICE & "," & ControlChars.CrLf _
            & " LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),COSTDT=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')" & ControlChars.CrLf _
            & " WHERE ACCTNO='" & v_strACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

End Class
