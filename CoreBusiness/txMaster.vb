Imports DataAccessLayer
Imports HostCommonLibrary
Imports System.Data

Public Interface IBusiness
    Function txUpdate(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
    Function txCheck(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
    Function txMisc(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
End Interface

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class txMaster
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

#Region " Khai báo hằng, biến "
    Dim mv_sModule As String
    Dim mv_sAcctNo As String
    Dim mv_sCaseBy As String
    Dim mv_sFrDate As String
    Dim mv_sToDate As String
    Dim mv_sCmdMiscInquiry As String
    Dim mv_sCmdAccountInquiry As String = String.Empty
    Dim mv_sCmdHistoryInquiry As String = String.Empty
    Dim mv_intPageNumber As Integer = 1
#End Region

#Region " Các thuộc tính của lớp "
    Public Property ATTR_MODULE() As String
        Get
            Return mv_sModule
        End Get
        Set(ByVal Value As String)
            mv_sModule = Value
        End Set
    End Property

    Public Property ATTR_ACCTNO() As String
        Get
            Return mv_sAcctNo
        End Get
        Set(ByVal Value As String)
            mv_sAcctNo = Value
        End Set
    End Property

    Public Property ATTR_CASEBY() As String
        Get
            Return mv_sCaseBy
        End Get
        Set(ByVal Value As String)
            mv_sCaseBy = Value
        End Set
    End Property

    Public Property ATTR_FRDATE() As String
        Get
            Return mv_sFrDate
        End Get
        Set(ByVal Value As String)
            mv_sFrDate = Value
        End Set
    End Property

    Public Property ATTR_TODATE() As String
        Get
            Return mv_sToDate
        End Get
        Set(ByVal Value As String)
            mv_sToDate = Value
        End Set
    End Property

    Public Property ATTR_CMDMISCINQUIRY() As String
        Get
            Return mv_sCmdMiscInquiry
        End Get
        Set(ByVal Value As String)
            mv_sCmdMiscInquiry = Value
        End Set
    End Property

    Public Property ATTR_CMDACCOUNTINQUIRY() As String
        Get
            Return mv_sCmdAccountInquiry
        End Get
        Set(ByVal Value As String)
            mv_sCmdAccountInquiry = Value
        End Set
    End Property

    Public Property ATTR_CMDHISTORYINQUIRY() As String
        Get
            Return mv_sCmdHistoryInquiry
        End Get
        Set(ByVal Value As String)
            mv_sCmdHistoryInquiry = Value
        End Set
    End Property

    Public Property ATTR_PAGENUMBER() As Integer
        Get
            Return mv_intPageNumber
        End Get
        Set(ByVal Value As Integer)
            mv_intPageNumber = Value
        End Set
    End Property

#End Region

#Region " Core functions - can not override "
    Public Function txCoreMiscInquiry(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_obj As New DataAccess ', v_ds As DataSet
        Dim v_strSQL As String
        Dim v_strXMLMessage As String = pv_xmlDocument.InnerXml

        Try
            Dim v_arrInquiryPara() As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            'Doc du liệu tìm kiếm
            'v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If ATTR_CMDACCOUNTINQUIRY.Length > 0 Then
                'Get ACCTNO parameter
                ReDim v_arrInquiryPara(0)
                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "ACCTNO"
                v_objInquiryParam.ParamValue = Me.ATTR_ACCTNO
                v_objInquiryParam.ParamSize = Me.ATTR_ACCTNO.Length
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(0) = v_objInquiryParam
                Using v_ds As DataSet = v_obj.ExecuteSQLParametersReturnDataset(ATTR_CMDACCOUNTINQUIRY, v_arrInquiryPara)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_NO_DATAFOUND
                    End If
                    BuildXMLObjData(v_ds, v_strXMLMessage)
                End Using
            ElseIf ATTR_CMDHISTORYINQUIRY.Length > 0 Then
                'Get ACCTNO, FRDATE and TODATE
                ReDim v_arrInquiryPara(2)
                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "ACCTNO"
                v_objInquiryParam.ParamValue = Me.ATTR_ACCTNO
                v_objInquiryParam.ParamSize = Me.ATTR_ACCTNO.Length
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(0) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "FRDATE"
                v_objInquiryParam.ParamValue = Me.ATTR_FRDATE
                v_objInquiryParam.ParamSize = Me.ATTR_FRDATE.Length
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(1) = v_objInquiryParam

                v_objInquiryParam = New ReportParameters
                v_objInquiryParam.ParamName = "TODATE"
                v_objInquiryParam.ParamValue = Me.ATTR_TODATE
                v_objInquiryParam.ParamSize = Me.ATTR_TODATE.Length
                v_objInquiryParam.ParamType = "String"
                v_arrInquiryPara(2) = v_objInquiryParam

                Using v_ds As DataSet = v_obj.ExecuteSQLParametersReturnDataset(ATTR_CMDHISTORYINQUIRY, v_arrInquiryPara)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_NO_DATAFOUND
                    End If
                    BuildXMLObjData(v_ds, v_strXMLMessage)
                End Using
            Else 'default 
                v_strSQL = Me.ATTR_CMDMISCINQUIRY

                Using v_ds As DataSet = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_NO_DATAFOUND
                    End If
                    BuildXMLObjData(v_ds, v_strXMLMessage)
                End Using
            End If
            'If v_ds.Tables(0).Rows.Count <= 0 Then
            '    Rollback() 'ContextUtil.SetAbort()
            '    Return ERR_SA_NO_DATAFOUND
            'End If
            'BuildXMLObjData(v_ds, v_strXMLMessage)
            pv_xmlDocument.LoadXml(v_strXMLMessage)
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            'If Not v_ds Is Nothing Then
            '    v_ds.Dispose()
            'End If

            'TruongLD Comment when convert
            'If Not v_obj Is Nothing Then
            '    'v_obj.Dispose()
            'End If
        End Try
    End Function

    Public Function txCoreCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.txMaster.txCoreCheck", v_strErrorMessage As String
        Dim v_attrColl As Xml.XmlAttributeCollection
        Dim v_strTLTXCD, v_strUPDMODE, v_strLOCAL As String
        Dim v_strTBLNAME, v_strFLDKEY, v_strACCTNO, v_strFIELD, v_strVALUE, v_strERRMSG, v_strSECTYPE, v_strCUSTID As String
        'Dim v_ds, v_ds1 As DataSet
        'Dim v_strSQL As String = String.Empty
        Dim v_ds, v_ds1, v_ErrorDS As DataSet
        Dim v_strSQL As String = String.Empty, v_strErrorSQL As String = String.Empty

        Dim v_lngErrNumber As Long = 0
        Dim v_obj As DataAccess
        Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
        Dim v_strBusDate As String

        Try
            'Get message information
            v_attrColl = pv_xmlDocument.DocumentElement.Attributes
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value Is Nothing) Then
                v_strTLTXCD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Else
                v_strTLTXCD = String.Empty
            End If

            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeUPDATEMODE), Xml.XmlAttribute).Value Is Nothing) Then
                v_strUPDMODE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeUPDATEMODE), Xml.XmlAttribute).Value)
            Else
                v_strUPDMODE = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value Is Nothing) Then
                v_strLOCAL = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLOCAL = String.Empty
            End If

            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeBUSDATE), Xml.XmlAttribute).Value Is Nothing) Then
                v_strBusDate = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBUSDATE), Xml.XmlAttribute).Value)
            Else
                v_strBusDate = String.Empty
            End If

            v_strTBLNAME = String.Empty
            v_strFLDKEY = String.Empty
            v_strACCTNO = String.Empty
            v_strFIELD = String.Empty
            v_strVALUE = String.Empty

            'Create connection to DB
            If v_strLOCAL = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLOCAL = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Scan APPCHK entry
            Dim v_nodeData As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            v_nodeData = pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk")

            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                If CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("apptype").Value) = ATTR_MODULE Then
                    'New account for checking
                    If v_strTBLNAME <> CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("refid").Value) _
                        Or v_strFLDKEY <> CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("fldkey").Value) _
                        Or v_strACCTNO <> CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acctno").Value) Then
                        'Get account information
                        v_strTBLNAME = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("refid").Value)
                        v_strFLDKEY = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("fldkey").Value)
                        v_strACCTNO = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acctno").Value)
                        ReDim v_arrRptPara(3)
                        '0. Condition value
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "pv_condvalue" 'pv_CONDVALUE
                        v_objRptParam.ParamValue = v_strACCTNO
                        v_objRptParam.ParamSize = CStr(20)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(0) = v_objRptParam

                        '1. Table Name
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "pv_tblname" 'pv_TBLNAME
                        v_objRptParam.ParamValue = v_strTBLNAME
                        v_objRptParam.ParamSize = CStr(50)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(1) = v_objRptParam

                        '2. KEY field. Example: Acctno, AFacctno ....
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "pv_fldkey" 'pv_FLDKEY
                        v_objRptParam.ParamValue = v_strFLDKEY
                        v_objRptParam.ParamSize = CStr(50)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(2) = v_objRptParam

                        '3. BUSDATE: posting date
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "pv_busdate" 'pv_BUSDATE
                        v_objRptParam.ParamValue = v_strBusDate
                        v_objRptParam.ParamSize = CStr(50)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(3) = v_objRptParam

                        v_ds = v_obj.ExecuteStoredReturnDataset("txpks_check.pr_txcorecheck", v_arrRptPara)

                        If v_ds.Tables(0).Rows.Count = 0 Then
                            If v_strTBLNAME = "SEMAST" Then
                                'Tự động mở tài khoản SE nếu thiếu
                                Dim v_strAFACCTNO, v_strCODEID As String
                                v_strAFACCTNO = Left(v_strACCTNO, 10)
                                v_strCODEID = Right(v_strACCTNO, 6)
                                v_lngErrNumber = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
                                v_strSQL = "SELECT TYP.SETYPE SETYPE, AF.CUSTID CUSTID FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAFACCTNO & "'"
                                v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_ds1.Tables(0).Rows.Count > 0 Then
                                    v_strSECTYPE = v_ds1.Tables(0).Rows(0)("SETYPE")
                                    v_strCUSTID = v_ds1.Tables(0).Rows(0)("CUSTID")
                                    v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                                           & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                                           & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                                           & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                                               & " VALUES ('" & v_strSECTYPE & "', '" & v_strCUSTID & "', '" & v_strACCTNO & "', '" & v_strCODEID & "','" & v_strAFACCTNO & "'," & ControlChars.CrLf _
                                                               & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                               & "0,0,0,0,0,0,0,0,0 )"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If


                                'Lấy lại thông tin tài khoản vừa tạo
                                'Kienvt sua ham trim
                                'v_strSQL = "SELECT * FROM " & v_strTBLNAME & " WHERE TRIM(ACCTNO) = '" & v_strACCTNO & "' "
                                v_strSQL = "SELECT * FROM " & v_strTBLNAME & " WHERE ACCTNO = '" & v_strACCTNO & "' "
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            ElseIf v_strTBLNAME = "REMAST" Then
                                Dim v_strRECUSTID, v_strREACTYPE As String
                                'Mot MG-mot loai hinh chi co mot account
                                v_strRECUSTID = Left(v_strACCTNO, 10)
                                v_strREACTYPE = Right(v_strACCTNO, 4)
                                'Kiem tra moi gioi co duoc phep dung loai hinh nay khong
                                v_strSQL = "SELECT COUNT(AUTOID) FROM (SELECT RECFDEF.AUTOID AUTOID FROM RECFDEF, RECFLNK WHERE RECFDEF.REFRECFLNKID=RECFLNK.AUTOID " & ControlChars.CrLf _
                                    & "AND RECFLNK.CUSTID= '" & v_strRECUSTID & "' AND RECFDEF.REACTYPE='" & v_strREACTYPE & "' UNION ALL " & ControlChars.CrLf _
                                    & "SELECT AUTOID FROM REGRP WHERE CUSTID= '" & v_strRECUSTID & "' AND ACTYPE='" & v_strREACTYPE & "')"
                                v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_ds1.Tables(0).Rows.Count = 1 Then
                                    If v_ds1.Tables(0).Rows(0)(0) = 0 Then
                                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                     & "Error code: System error!" & vbNewLine _
                                                     & "Error message: " & ControlChars.CrLf & v_strSQL & ControlChars.CrLf & ERR_REMISER_ACCOUNT_INVALID_ACTYPE, "EventLogEntryType.Error")
                                        Rollback() 'ContextUtil.SetAbort()
                                        Return ERR_REMISER_ACCOUNT_INVALID_ACTYPE
                                    Else
                                        'Tu dong mo REMAST
                                        v_strSQL = "INSERT INTO REMAST (ACCTNO,CUSTID,ACTYPE,STATUS,PSTATUS,LAST_CHANGE,RATECOMM,BALANCE,DAMTACR,DAMTLASTDT," & ControlChars.CrLf _
                                            & "IAMTACR,IAMTLASTDT,DIRECTACR,INDIRECTACR,ODFEETYPE,ODFEERATE,COMMTYPE,LASTCOMMDATE)" & ControlChars.CrLf _
                                            & "SELECT '" & v_strACCTNO & "', '" & v_strRECUSTID & "', '" & v_strREACTYPE & "', 'A','', SYSTIMESTAMP, RATECOMM, 0, 0, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                                            & "0, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), 0, 0, ODFEETYPE,ODFEERATE,COMMTYPE,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                            & "FROM RETYPE WHERE ACTYPE='" & v_strREACTYPE & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    End If
                                End If

                                'Lấy lại thông tin tài khoản vừa tạo
                                v_strSQL = "SELECT * FROM " & v_strTBLNAME & " WHERE ACCTNO = '" & v_strACCTNO & "' "
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            Else
                                v_lngErrNumber = ERR_SA_APPCHK_ACCTNO_NOTFOUND
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: System error!" & vbNewLine _
                                             & "Error message: " & v_strSQL & "." & ControlChars.CrLf & v_strTBLNAME & "." & v_strACCTNO, "EventLogEntryType.Error")
                                'Trả về mã lỗi
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrNumber
                            End If
                        End If
                    End If
                    v_strFIELD = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("field").Value)
                    v_strVALUE = v_nodeData.ChildNodes(i).InnerXml

                    Select Case CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("operand").Value)
                        Case ">>"
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) > CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case ">="
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) >= CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "<<"
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) < CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "<="
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) <= CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "=="
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) = CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "!="
                            If Not (CDbl(v_ds.Tables(0).Rows(0)(v_strFIELD)) <> CDbl(v_strVALUE)) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "IN"
                            If Not (InStr(1, v_strVALUE, Trim(v_ds.Tables(0).Rows(0)(v_strFIELD))) > 0) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If
                        Case "NI"
                            If (InStr(1, v_strVALUE, Trim(v_ds.Tables(0).Rows(0)(v_strFIELD))) > 0) Then
                                v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                            End If

                        Case "CB"
                            'Check care by them 12/11/2008    
                            Dim v_strCAREBYGRP As String
                            v_strCAREBYGRP = gf_CorrectStringField(v_ds.Tables(0).Rows(0)(v_strFIELD))
                            If v_strCAREBYGRP.Trim.Length > 0 Then
                                If Not (String.Compare(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value, HO_BRID) = 0 _
                                    And String.Compare(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value, ADMIN_ID) = 0) Then
                                    'Supervisor: no need to check
                                    v_strSQL = "SELECT COUNT(*) FROM TLGRPUSERS WHERE GRPID = '" & v_strCAREBYGRP & "' " &
                                        "AND BRID = '" & pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value & "' " &
                                        "AND TLID = '" & pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value & "' "
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                                        v_lngErrNumber = CDbl(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errnum").Value)
                                    Else
                                        'Capture group
                                        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCAREBY).Value = "[" & v_strCAREBYGRP & "]" &
                                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCAREBY).Value
                                    End If
                                Else
                                    'Capture group
                                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCAREBY).Value = "[" & v_strCAREBYGRP & "]" &
                                        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCAREBY).Value
                                End If
                            End If
                    End Select

                    If v_lngErrNumber <> ERR_SYSTEM_OK Then
                        'Kiểm tra nếu là mã lỗi cần checker 1 duyệt thì ERRMESSAGE chính là nguyên nhân duyệt
                        If v_lngErrNumber = ERR_SA_CHECKER1_OVR Then
                            'Lấy nguyên nhân duyệt trả v?. T ại Router sẽ kiểm tra nếu có nguyên nhân duyệt sẽ raise mã lỗi sau
                            v_strERRMSG = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("errmsg").Value)
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value & v_strERRMSG
                            Rollback() 'ContextUtil.SetAbort()
                            v_lngErrNumber = ERR_SYSTEM_OK
                        ElseIf CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("chklev").Value) <> gc_ERROR_MESSAGE Then
                            'Add warning or info exception
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: System error!" & vbNewLine _
                                         & "Error message: " & v_strTLTXCD & "." & v_strTBLNAME & "." & v_strACCTNO & "." & v_strFIELD & "." & v_strVALUE, "EventLogEntryType.Error")
                            v_strErrorSQL = "SELECT ERRDESC FROM DEFERROR WHERE ERRNUM = '" & v_lngErrNumber.ToString & "'"
                            Try
                                v_ErrorDS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strErrorSQL)
                                v_strErrorMessage = v_ErrorDS.Tables(0).Rows(0)("ERRDESC")
                            Catch ex As Exception
                                v_strErrorMessage = "[" & v_lngErrNumber.ToString() & "]: Undefined error!"
                            End Try
                            BuildXMLWarningException(pv_xmlDocument, v_strErrorSource, v_lngErrNumber, v_strErrorMessage, CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("chklev").Value))
                            v_lngErrNumber = ERR_SYSTEM_OK
                        Else
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: System error!" & vbNewLine _
                                         & "Error message: " & v_strTLTXCD & "." & v_strTBLNAME & "." & v_strACCTNO & "." & v_strFIELD & "." & v_strVALUE, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrNumber
                        End If
                    End If

                End If
            Next

            'For special implementing in Business module
            v_lngErrNumber = txImpCheck(pv_xmlDocument)
            If v_lngErrNumber <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrNumber
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function txCoreMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'For special implementing in Business module
        Return txImpMisc(pv_xmlDocument)
    End Function

    Public Function txCoreUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_obj As DataAccess
        Dim v_strSQL As String = vbNullString
        Dim v_strSQLTemp As String = vbNullString
        Dim v_strSQLMASTER As String = vbNullString
        Dim v_strSQLTRANS As String = vbNullString
        Dim v_strTABLE As String = vbNullString
        Dim v_strFIELD As String = vbNullString

        Dim v_strTBLNAME As String = vbNullString
        Dim v_strACFLD As String = vbNullString
        Dim v_strFLDTYPE As String = vbNullString
        Dim v_strTXCD As String = vbNullString
        Dim v_strTXTYPE As String = vbNullString
        Dim v_dblNAMT As Double = 0
        Dim v_strCAMT As String = vbNullString
        Dim v_strACCTNO As String = vbNullString
        Dim v_strREFACCTNO As String = vbNullString
        Dim v_strFLDKEY As String = vbNullString
        Dim v_strOLDACCTNO As String = vbNullString
        Dim v_strTRDESC As String = vbNullString
        Try
            'Get message information
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD, v_strTXNUM, v_strTXDATE, v_strBKDATE, v_strREVERSAL, v_strUPDMODE, v_strLOCAL As String

            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value Is Nothing) Then
                v_strTLTXCD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Else
                v_strTLTXCD = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value Is Nothing) Then
                v_strTXNUM = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Else
                v_strTXNUM = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeBUSDATE), Xml.XmlAttribute).Value Is Nothing) Then
                v_strBKDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBUSDATE), Xml.XmlAttribute).Value)
            Else
                v_strBKDATE = v_strTXDATE
            End If
            'Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value

            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value Is Nothing) Then
                v_strREVERSAL = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Else
                v_strREVERSAL = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeUPDATEMODE), Xml.XmlAttribute).Value Is Nothing) Then
                v_strUPDMODE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeUPDATEMODE), Xml.XmlAttribute).Value)
            Else
                v_strUPDMODE = String.Empty
            End If
            If Not (CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value Is Nothing) Then
                v_strLOCAL = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLOCAL = String.Empty
            End If

            'Create an instance of DataAccess class
            If v_strLOCAL = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLOCAL = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Which table will be updated
            Dim v_strTBLFILE, v_strTBLTRAN As String

            'Thực hiện cập nhật đặc biệt luôn để nếu có lỗi sẽ rollback luôn
            Dim v_lngError As Long = txImpUpdate(pv_xmlDocument)
            If v_lngError <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngError
            End If

            'Scan APPMAP entry
            Dim v_nodeData As Xml.XmlNode
            v_nodeData = pv_xmlDocument.SelectSingleNode("/TransactMessage/appmap")
            If Not v_nodeData Is Nothing Then
                For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                    If CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("apptype").Value) = ATTR_MODULE _
                        And Len(CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("ofile").Value)) = 0 Then
                        v_strACCTNO = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acctno").Value)
                        v_strREFACCTNO = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acfldref").Value)
                        'Get value
                        v_strTXCD = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("apptxcd").Value)
                        v_strTBLNAME = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("tblname").Value)
                        v_strTXTYPE = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("txtype").Value)
                        v_strFLDTYPE = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("fldtype").Value)
                        v_strTBLTRAN = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("tranf").Value)
                        v_strFLDKEY = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("fldkey").Value)
                        v_strTRDESC = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("trdesc").Value)
                        v_dblNAMT = 0
                        v_strCAMT = vbNullString
                        Select Case v_strFLDTYPE
                            Case "N"
                                v_dblNAMT = FRound(CDbl(v_nodeData.ChildNodes(i).InnerXml), 4)
                                If v_dblNAMT = 0 Then v_strTBLTRAN = String.Empty
                            Case "C", "D"
                                v_strCAMT = CStr(v_nodeData.ChildNodes(i).InnerXml)
                                If v_strCAMT.Length = 0 Then v_strTBLTRAN = String.Empty
                        End Select

                        'If save to transaction file
                        If Len(v_strTBLTRAN) > 0 And v_strREVERSAL = "N" Then
                            v_strSQLTemp = "INSERT INTO " & v_strTBLTRAN & " (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID,TLTXCD,BKDATE,TRDESC) VALUES ('" _
                                    & v_strACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXCD & "'," & v_dblNAMT & ",'" & v_strCAMT & "','" & v_strREFACCTNO & "','N',SEQ_" & v_strTBLTRAN & ".NEXTVAL,'" & v_strTLTXCD & "',TO_DATE('" & v_strBKDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strTRDESC & "')"
                            If Len(v_strSQLTRANS) = 0 Then
                                v_strSQLTRANS = v_strSQLTemp
                            Else
                                v_strSQLTRANS = v_strSQLTRANS & vbCrLf & v_strSQLTemp
                            End If
                            'Thực hiện lệnh SQL
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLTemp)
                        ElseIf Len(v_strTBLTRAN) > 0 And v_strREVERSAL = "Y" Then
                            'Delete transaction
                            'v_strSQLTemp = "UPDATE " & v_strTBLTRAN & " SET DELTD = 'Y' " _
                            '    & "WHERE TRIM(TXNUM) = '" & v_strTXNUM & "' AND TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_strSQLTemp = "UPDATE " & v_strTBLTRAN & " SET DELTD = 'Y' " _
                                & "WHERE TXNUM = '" & v_strTXNUM & "' AND TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_strSQLTRANS = v_strSQLTemp
                            'Thực hiện lệnh SQL
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLTemp)
                        End If

                        'Store SQL command to update account
                        If v_strACFLD <> CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acfld").InnerXml) Then  'if update to mext account
                            'Store current SQL command
                            If Len(v_strSQLMASTER) <> 0 Then
                                'remove first character of strSQLMASTER:  ","
                                v_strSQLMASTER = Mid(v_strSQLMASTER, 2)
                                'v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE TRIM(ACCTNO) = '" & v_strOLDACCTNO & "'"
                                'v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE TRIM(" & v_strFLDKEY & ") = '" & v_strOLDACCTNO & "'"
                                v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE " & v_strFLDKEY & " = '" & v_strOLDACCTNO & "'"
                                v_strSQL = v_strSQL & v_strSQLTemp
                                'Thực hiện lệnh SQL
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLTemp)
                            End If
                            'Reset value
                            v_strSQLMASTER = vbNullString
                        End If

                        'Build expression for field
                        If v_strFIELD <> CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("field").InnerXml) _
                            Or Len(v_strSQLMASTER) = 0 Then
                            v_strFIELD = Trim(CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("field").InnerXml))
                            'Update new field
                            Select Case v_strFLDTYPE
                                Case "N"
                                    Select Case v_strTXTYPE
                                        Case "D"
                                            v_strSQLMASTER = v_strSQLMASTER & "," & v_strFIELD & " = " & v_strFIELD & IIf(v_strREVERSAL = "Y", "+", "-") & "(" & v_dblNAMT & ")"
                                        Case "C"
                                            v_strSQLMASTER = v_strSQLMASTER & "," & v_strFIELD & " = " & v_strFIELD & IIf(v_strREVERSAL = "Y", "-", "+") & "(" & v_dblNAMT & ")"
                                        Case "U"
                                            v_strSQLMASTER = v_strSQLMASTER & "," & v_strFIELD & " = " & "(" & v_dblNAMT & ")"
                                    End Select
                                Case "C"
                                    Select Case v_strFIELD
                                        Case "ORSTATUS", "STATUS", "ODSTS", "ISOTC", "EXORSTATUS"
                                            v_strSQLMASTER = v_strSQLMASTER & "," & IIf(v_strREVERSAL = "Y",
                                                v_strFIELD & "=SUBSTR(P" & v_strFIELD & ",LENGTH(P" & v_strFIELD & "),1), P" & v_strFIELD & "=SUBSTR(P" & v_strFIELD & ",1,LENGTH(P" & v_strFIELD & ")-1)",
                                                "P" & v_strFIELD & " = P" & v_strFIELD & " || " & v_strFIELD & ", " & v_strFIELD & " = '" & v_strCAMT & "'")
                                        Case Else
                                            v_strSQLMASTER = v_strSQLMASTER & "," & v_strFIELD & " = '" & v_strCAMT & "'"
                                    End Select
                                Case "D"
                                    v_strSQLMASTER = v_strSQLMASTER & "," & v_strFIELD & " = TO_DATE('" & v_strCAMT & "','" & gc_FORMAT_DATE & "')"
                            End Select
                        Else
                            'If update old value and field type is numeric
                            Select Case v_strFLDTYPE
                                Case "N"
                                    Select Case v_strTXTYPE
                                        Case "D"
                                            v_strSQLMASTER = v_strSQLMASTER & IIf(v_strREVERSAL = "Y", "+", "-") & "(" & v_dblNAMT & ")"
                                        Case "C"
                                            v_strSQLMASTER = v_strSQLMASTER & IIf(v_strREVERSAL = "Y", "-", "+") & "(" & v_dblNAMT & ")"
                                    End Select
                            End Select
                        End If

                        'Ghi nhận tạm th?i
                        v_strOLDACCTNO = v_strACCTNO
                        v_strACFLD = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("acfld").InnerXml)
                        v_strFIELD = CStr(v_nodeData.ChildNodes(i).Attributes.GetNamedItem("field").InnerXml)
                    End If
                Next
            End If


            'Store current SQL command
            If Len(v_strSQLMASTER) <> 0 Then
                If InStr(v_strTBLNAME, "MAST") > 0 Then
                    v_strSQLMASTER = v_strSQLMASTER & " ,LAST_CHANGE = SYSTIMESTAMP "
                End If
                'remove first character of strSQLMASTER:  ","
                v_strSQLMASTER = Mid(v_strSQLMASTER, 2)
                'v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE TRIM(ACCTNO) = '" & v_strACCTNO & "'"
                'v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE TRIM(" & v_strFLDKEY & ") = '" & v_strACCTNO & "'"
                v_strSQLTemp = " UPDATE " & v_strTBLNAME & " SET " & v_strSQLMASTER & " WHERE " & v_strFLDKEY & " = '" & v_strACCTNO & "'"
                v_strSQL = v_strSQL & v_strSQLTemp
                'Th�ực hiện lệnh SQL
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLTemp)
            End If
            v_strSQL = v_strSQL & " " & v_strSQLTRANS
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngError
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
#End Region

#Region " Implement functions - Overridable "
    Overridable Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Overridable Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Overridable Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Overridable Function BasedGenIntTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Trans.GenIntTrans", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strACCTNO, v_strINTTYPE, v_strFRDATE, v_strTODATE, v_strICCFCD As String
            Dim v_dblBALANCE, v_dblINTAMT, v_dblRATE As Double
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich tinh lai cong don cua phan he: Cau truc giao dich nhu duoi day
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
                            v_dblINTAMT = v_dblVALUE
                        Case "12" 'RATE
                            v_dblRATE = v_dblVALUE
                        Case "04" 'ICRULE
                            v_strICCFCD = v_strVALUE
                        Case "07" 'INTTYPE
                            v_strINTTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Tao phieu tinh lai
            If Not v_blnReversal Then
                v_strSQL = "INSERT INTO " & ATTR_MODULE & "INTTRAN (AUTOID, ACCTNO, INTTYPE, FRDATE, TODATE, ICRULE, IRRATE, INTBAL, INTAMT, TXDATE, TXNUM) " & ControlChars.CrLf _
                    & "VALUES (SEQ_" & ATTR_MODULE & "INTTRAN.NEXTVAL,'" & v_strACCTNO & "','" & v_strINTTYPE & "', " & ControlChars.CrLf _
                    & "TO_DATE('" & v_strFRDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                    & "TO_DATE('" & v_strTODATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                    & "'" & v_strICCFCD & "'," & v_dblRATE & "," & v_dblBALANCE & "," & v_dblINTAMT & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), '" & v_strTXNUM & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "DELETE FROM  " & ATTR_MODULE & "INTTRAN WHERE TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM='" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function BasedInquiryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Trans.BasedInquiryAccount", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_obj As New DataAccess, v_ds As DataSet, v_nodeList As Xml.XmlNodeList
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            'Doc noi dung giao dich
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
                            ATTR_ACCTNO = v_strVALUE
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next

            'Kiem tra co tai khoan khong
            v_strSQL = "SELECT ACCTNO FROM " & Me.ATTR_MODULE & "MAST WHERE ACCTNO='" & ATTR_ACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Bao loi 
                v_lngErrCode = ERR_SA_ACCTNO_MASTER_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Tao cau lenh SQL de lay du lieu: Nguyen tac su dung SEARCHCODE = TLTX.MNEM, KEYFIELD = ACCTNO
            v_strSQL = "SELECT SEARCH.SEARCHCMDSQL FROM SEARCH, TLTX WHERE SEARCH.SEARCHCODE=TLTX.MNEM AND TLTX.TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strSQL = v_ds.Tables(0).Rows(0)("SEARCHCMDSQL") & " AND MST.ACCTNO=:ACCTNO"
            Else
                v_strSQL = "SELECT * FROM " & ATTR_MODULE & "MAST WHERE ACCTNO=:ACCTNO"
            End If
            ATTR_CMDACCOUNTINQUIRY = v_strSQL
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function StoreInquiryAccount(ByRef pv_xmlDocument As Xml.XmlDocument, ByVal pv_strTBLNAME As String,
                                             Optional ByVal pv_strTXDATE As String = "", Optional ByVal pv_strTYPE As String = "")
        '--------------------------------------------------------------
        'Create :   TruongLD
        'Date:      14/04/2010
        'Purpose :  Inquiry Account
        '--------------------------------------------------------------
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_arrInquiryPara() As ReportParameters
        Dim v_objInquiryParam As ReportParameters

        'Doc du liệu tìm kiếm
        v_obj = New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_objRptParam As ReportParameters
        Dim v_arrRptPara() As ReportParameters
        ReDim v_arrRptPara(3)

        '0. Table Name
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "f_TABLENAME"
        v_objRptParam.ParamValue = pv_strTBLNAME
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(0) = v_objRptParam

        '1. ACCTNO 
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "f_ACCTNO"
        v_objRptParam.ParamValue = ATTR_ACCTNO
        v_objRptParam.ParamSize = 30
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(1) = v_objRptParam

        '2. FRDATE
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "f_INDATE"
        v_objRptParam.ParamValue = pv_strTXDATE
        v_objRptParam.ParamSize = 100
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(2) = v_objRptParam

        '3. FRDATE
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "f_TYPE"
        v_objRptParam.ParamValue = pv_strTYPE
        v_objRptParam.ParamSize = 100
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(3) = v_objRptParam



        v_ds = v_obj.ExecuteStoredReturnDataset("INQUIRYACCOUNT", v_arrRptPara)

        'If v_ds.Tables(0).Rows.Count <= 0 Then
        '    'Rollback() 'ContextUtil.SetAbort()
        '    Return ERR_SYSTEM_OK 'ERR_SA_NO_DATAFOUND
        'End If

        Dim v_strXMLMessage As String
        v_strXMLMessage = pv_xmlDocument.InnerXml
        BuildXMLObjData(v_ds, v_strXMLMessage)
        pv_xmlDocument.LoadXml(v_strXMLMessage)

        Return ERR_SYSTEM_OK

    End Function

    Overridable Function StoreHistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument, ByVal pv_strTBLNAME As String, Optional ByVal pv_strAFACCTNO As String = "",
                                             Optional ByVal pv_strCASEBY As String = "", Optional ByVal pv_strCODEID As String = "") As Long
        '--------------------------------------------------------------
        'Create :   TruongLD
        'Date:      14/04/2010
        'Purpose :  Lay danh sach GD
        '--------------------------------------------------------------

        Dim v_strPAGENO As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value
        If IsNumeric(v_strPAGENO) Then
            Me.ATTR_PAGENUMBER = CInt(v_strPAGENO)
        Else
            Me.ATTR_PAGENUMBER = 1
        End If
        Dim v_intFrom, v_intTo As Integer
        v_intFrom = (Me.ATTR_PAGENUMBER - 1) * ROWS_PER_PAGE + 1
        v_intTo = Me.ATTR_PAGENUMBER * ROWS_PER_PAGE


        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_arrInquiryPara() As ReportParameters
        Dim v_objInquiryParam As ReportParameters

        'Doc du liệu tìm kiếm
        v_obj = New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_objRptParam As ReportParameters
        Dim v_arrRptPara() As ReportParameters
        ReDim v_arrRptPara(8)

        '0. Table Name
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "TABLENAME"
        v_objRptParam.ParamValue = pv_strTBLNAME
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(0) = v_objRptParam

        '1. ACCTNO 
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "ACCTNO"
        v_objRptParam.ParamValue = ATTR_ACCTNO
        v_objRptParam.ParamSize = 30
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(1) = v_objRptParam

        '2. FRDATE
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "FRDATE"
        v_objRptParam.ParamValue = ATTR_FRDATE
        v_objRptParam.ParamSize = 100
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(2) = v_objRptParam

        '3. FRDATE
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "TODATE"
        v_objRptParam.ParamValue = ATTR_TODATE
        v_objRptParam.ParamSize = 100
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(3) = v_objRptParam

        '4. FPAGENUMBER
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "FPAGENUMBER"
        v_objRptParam.ParamValue = v_intFrom
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "NUMBER"
        v_arrRptPara(4) = v_objRptParam

        '5. TPAGENUMBER
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "TPAGENUMBER"
        v_objRptParam.ParamValue = v_intTo
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "NUMBER"
        v_arrRptPara(5) = v_objRptParam


        '6. AFACCTNO
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "AFACCTNO"
        v_objRptParam.ParamValue = pv_strAFACCTNO
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(6) = v_objRptParam

        '7. CASEBY 
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "CASEBY"
        v_objRptParam.ParamValue = pv_strCASEBY
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(7) = v_objRptParam

        '6. CODEID
        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "CODEID"
        v_objRptParam.ParamValue = pv_strCODEID
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "VARCHAR2"
        v_arrRptPara(8) = v_objRptParam

        v_ds = v_obj.ExecuteStoredReturnDataset("HISTORYACCOUNT", v_arrRptPara)

        If v_ds.Tables(0).Rows.Count <= 0 Then
            'Rollback() 'ContextUtil.SetAbort()
            Return ERR_SYSTEM_OK 'ERR_SA_NO_DATAFOUND
        End If

        Dim v_strXMLMessage As String
        v_strXMLMessage = pv_xmlDocument.InnerXml
        BuildXMLObjData(v_ds, v_strXMLMessage)
        pv_xmlDocument.LoadXml(v_strXMLMessage)

        Return ERR_SYSTEM_OK

    End Function


    Overridable Function BasedHistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Trans.BasedHistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            'Doc noi dung giao dich
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
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_strPAGENO As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value
            If IsNumeric(v_strPAGENO) Then
                Me.ATTR_PAGENUMBER = CInt(v_strPAGENO)
            Else
                Me.ATTR_PAGENUMBER = 1
            End If
            Dim v_intFrom, v_intTo As Integer
            v_intFrom = (Me.ATTR_PAGENUMBER - 1) * ROWS_PER_PAGE + 1
            v_intTo = Me.ATTR_PAGENUMBER * ROWS_PER_PAGE

            If ATTR_MODULE = "RE" Then
                ATTR_CMDMISCINQUIRY = "SELECT * FROM (SELECT LOGDATA.*, ROWNUM RN FROM  " & ControlChars.CrLf _
                   & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
                   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
                   & "FROM " & Me.ATTR_MODULE & "TRAN WHERE ACCTNO IN (SELECT ACCTNO FROM " & Me.ATTR_MODULE & "MAST WHERE ACCTNO = '" & ATTR_ACCTNO & "')" & ControlChars.CrLf _
                   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX  " & ControlChars.CrLf _
                   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  " & ControlChars.CrLf _
                   & "UNION ALL  " & ControlChars.CrLf _
                   & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
                   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
                   & "FROM " & Me.ATTR_MODULE & "TRANA WHERE ACCTNO IN (SELECT ACCTNO FROM " & Me.ATTR_MODULE & "MAST WHERE ACCTNO = '" & ATTR_ACCTNO & "')  " & ControlChars.CrLf _
                   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')   " & ControlChars.CrLf _
                   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
                   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA) T1  " & ControlChars.CrLf _
                   & "WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo & " " & ControlChars.CrLf _
                   & "ORDER BY TXDATE, TXNUM "
            Else
                ATTR_CMDMISCINQUIRY = "SELECT * FROM (SELECT LOGDATA.*, ROWNUM RN FROM  " & ControlChars.CrLf _
                   & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
                   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
                   & "FROM " & Me.ATTR_MODULE & "TRAN WHERE ACCTNO IN (SELECT ACCTNO FROM " & Me.ATTR_MODULE & "MAST WHERE ACCTNO = '" & ATTR_ACCTNO & "' UNION ALL SELECT CF.CUSTID FROM cfmast CF, afmast AF WHERE CF.CUSTID = AF.CUSTID AND AF.ACCTNO = '" & ATTR_ACCTNO & "')" & ControlChars.CrLf _
                   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX  " & ControlChars.CrLf _
                   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  " & ControlChars.CrLf _
                   & "UNION ALL  " & ControlChars.CrLf _
                   & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
                   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
                   & "FROM " & Me.ATTR_MODULE & "TRANA WHERE ACCTNO IN (SELECT ACCTNO FROM " & Me.ATTR_MODULE & "MAST WHERE ACCTNO = '" & ATTR_ACCTNO & "' UNION ALL SELECT CF.CUSTID FROM cfmast CF, afmast AF WHERE CF.CUSTID = AF.CUSTID AND AF.ACCTNO = '" & ATTR_ACCTNO & "')  " & ControlChars.CrLf _
                   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')   " & ControlChars.CrLf _
                   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
                   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA) T1  " & ControlChars.CrLf _
                   & "WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo & " " & ControlChars.CrLf _
                   & "ORDER BY TXDATE, TXNUM "
            End If
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Based functions - Overridable "
    Overridable Function txUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long

        Try
            v_lngErrCode = txCoreUpdate(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()

                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = ATTR_MODULE & ".txUpdate"
                v_strErrorMessage = String.Empty
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
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

    Overridable Function txCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long

        Try
            v_lngErrCode = txCoreCheck(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                Rollback() 'ContextUtil.SetAbort()

                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = ATTR_MODULE & ".txCheck"
                v_strErrorMessage = String.Empty
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)

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

    Overridable Function txMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long

        Try
            v_lngErrCode = txCoreMisc(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()

                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = ATTR_MODULE & ".txMisc"
                v_strErrorMessage = String.Empty
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
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
#End Region

End Class
