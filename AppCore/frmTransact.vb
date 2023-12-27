Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Globalization


Public Class frmTransact
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmTransact-"
    Private mv_lngFeeEntry As Long = 0
    Private mv_strCustName As String
    Private mv_strDESC As String
    Private mv_strAddress As String
    Private mv_strLicense As String
    'TruongLD add 20/03/2010
    Private mv_strIDDate As String
    Private mv_strIDPlace As String
    'End TruongLD
    Private mv_strBankAcct As String
    Private mv_strBankname As String
    Private mv_strBankQue As String
    Private mv_strHoldAmt As String
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strCreatedDate As String
    Private mv_strCreatedDate_EN As String
    Private mv_strModuleCode As String
    Private mv_strVoucherID As String
    Private mv_strLanguage As String
    Private mv_blnOnDisplayScreen As Boolean = False
    Private mv_blnAcctEntry As Boolean = False
    Private mv_blnTranAdjust As Boolean = False
    Private mv_blnIsHistoryView As Boolean = False
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrObjAccounts() As CAccountEntry
    Private mv_arrObjVAT() As CVATVoucher
    Private mv_arrObjIEFMIS() As CIEFMISEntry
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument
    Private mv_strPOSTINGDATE As String = String.Empty
    Private mv_isAutoSubmitWhenExecue As Boolean = False

    Private mv_strXmlMessageData As String
    Private mv_strDefaultValue As String = String.Empty
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strGroup As String
    Private mv_strTellerType As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDesc As String = String.Empty
    Private mv_strTxBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty
    Private mv_isAutoClosedWhenOK As Boolean = False
    Private mv_isCancelClick As Boolean = False
    Private mv_isAdjust As Boolean = False
    Private mv_isBackDate As Boolean = False
    Private mv_isEnableBackDate As Boolean = True
    'Them de lay ra clipboard
    Private mv_strMsgAccount As String

    Public mv_frmSearchScreen As frmXtraSearch
    Public mv_frmCFMAST As frmMaintenance  'frmCFMAST
    Public mv_frmCFAUTH As frmMaintenance  'frmCFAUTH
    Public mv_frmCFRELATION As frmMaintenance  'frmCFAUTH

    Private mv_retREFFIELD As String
    Private mv_retROLETYPE As String
    Private mv_retCUSTID As String
    Private mv_retCUSTNAME As String
    Private mv_retIDNUMBER As String
    Private mv_retIDDATE As String
    Private mv_retIDPLACE As String
    Private mv_retADDRESS As String
    'GianhVG add loai tien/chungkhoan
    Private mv_strCCYCD As String

    Dim mv_strOrgRequestMessage As String
    'Ghi nhan danh sach bieu phi dang duoc chon cua giao dich
    Dim mv_strListOfTXFeeCode As String = String.Empty

    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 10
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 165 '150 'thunt-tang hien thi truong captions
    Const ALL_WIDTH = 900
    Const WIDTH_PERCHAR = 15
    Const PANEL_TOP = 54
    Const PANEL_HEIGHT = 300
    Const TABS_TOP = 10
    Const TABS_HEIGHT = 140
    Const LABEL_HELPER_TOP = 420
    Const FIX_TABS_TOP = 13

    Const PREFIXED_FLDNAME_FEECODE = "$FEECD"
    Const PREFIXED_MSKDATA = "mskData"
    Const PREFIXED_LBLDESC = "lblDesc"
    Const PREFIXED_LBLCAP = "lblCaption"

    Const POS_FLDNAME = 1
    Const POS_FLDTYPE = POS_FLDNAME + 2
    Const POS_PRINTINFO = POS_FLDTYPE + 1
    Const POS_LOOKUP = POS_PRINTINFO + 10
    Const POS_SQLLIST = POS_LOOKUP + 1

    Const BTN_GAP = 7
    Const BTN_WIDTH = 80
    Const BTN_ROOT_LEFT = 550
    
    Const ACCOUNTENTRY_EN = "Account entries"
    Const VATVOUCHER_EN = "VAT voucher"
    Const FIXEDASSEST_EN = "Fixed Assest"
    Const SUBTXNO_EN = "No"
    Const CCYCD_EN = "Currency"
    Const DORC_EN = "Debit/Credit"
    Const ACCOUNT_EN = "Account"
    Const AMOUNT_EN = "Amount"
    Const DRAMT_EN = "Debit"
    Const CRAMT_EN = "Credit"
    Const ACCOUNTENTRY_VN = "Háº¡ch toÃ¡n"
    Const SUBTXNO_VN = "STT"
    Const CCYCD_VN = "Loáº¡i tiá»?n"
    Const DORC_VN = "Ná»£/CÃ³"
    Const ACCOUNT_VN = "TÃ i khoáº£n"
    Const AMOUNT_VN = "Sá»‘ tiá»?n"
    Const DRAMT_VN = "Ná»£"
    Const CRAMT_VN = "CÃ³"

    Const FEEDETAIL_EN = "Fee details"
    Const FEECD_EN = "Fee code"
    Const FEENAME_EN = "Fee name"
    Const FORP_EN = "Fee type"
    Const GLACCTNO_EN = "Fee Account"
    Const FEEAMT_EN = "Fee amount"
    Const MINVAL_EN = "Min amount"
    Const VATRATE_EN = "VAT rate"
    Const MAXVAL_EN = "Max amount"
    Const FEERATE_EN = "Fee rate"
    Const FEEDETAIL_VN = "Fee details"
    Const FEECD_VN = "Fee code"
    Const FEENAME_VN = "Fee name"
    Const FORP_VN = "Fee type"
    Const GLACCTNO_VN = "Fee Account"
    Const FEEAMT_VN = "Fee amount"
    Const MAXVAL_VN = "Max amount"
    Const VATRATE_VN = "VAT rate"
    Const MINVAL_VN = "Min amount"
    Const FEERATE_VN = "Fee rate"
    Private BranchName As String
    Private BranchAddress As String

    Private BranchAddress_EN As String
    Private Phone As String
    Private Fax As String
    Private DepositID As String

    Private BranchPhoneFax As String
    Private ReportTitle As String
    Private HEADOFFICE As String
    Private DEALINGCUSTODYCD As String
    ' VinhLD add for auto resize
    Const BASED_SCREEN_WIDTH = 800
    Const BASED_SCREEN_HEIGHT = 600
    Const BASED_FORM_WIDTH = 800
    Const BASED_FORM_HEIGHT = 464
    Const BASED_PANEL_WIDTH = 784
    Private mv_dblWindowSizeXRatio As Double = 1
    Private mv_dblWindowSizeRatio_X As Double = 1
    Friend WithEvents stbMain As System.Windows.Forms.StatusBar
    Private mv_dblWindowSizeRatio_Y As Double = 1
    ' end of VinhLD add for auto resize
#End Region

#Region " Properties "
    Public Property VoucherID() As String
        Get
            Return mv_strVoucherID
        End Get
        Set(ByVal Value As String)
            mv_strVoucherID = Value
        End Set
    End Property

    Public Property AutoSubmitWhenExecute() As Boolean
        Get
            Return mv_isAutoSubmitWhenExecue
        End Get
        Set(ByVal Value As Boolean)
            mv_isAutoSubmitWhenExecue = Value
        End Set
    End Property

    Public Property CancelClick() As Boolean
        Get
            Return mv_isCancelClick
        End Get
        Set(ByVal Value As Boolean)
            mv_isCancelClick = Value
        End Set
    End Property

    Public Property AutoClosedWhenOK() As Boolean
        Get
            Return mv_isAutoClosedWhenOK
        End Get
        Set(ByVal Value As Boolean)
            mv_isAutoClosedWhenOK = Value
        End Set
    End Property

    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property

    Public Property TXDESC() As String
        Get
            Return mv_strDESC
        End Get
        Set(ByVal Value As String)
            mv_strDESC = Value
        End Set
    End Property

    Public Property DefaultValue() As String
        Get
            Return mv_strDefaultValue
        End Get
        Set(ByVal Value As String)
            mv_strDefaultValue = Value
        End Set
    End Property

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property PostingDate() As String
        Get
            Return mv_strPOSTINGDATE
        End Get
        Set(ByVal Value As String)
            mv_strPOSTINGDATE = Value
        End Set
    End Property
    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
        End Set
    End Property


    Public Property TxNum() As String
        Get
            Return mv_strTxNum
        End Get
        Set(ByVal Value As String)
            mv_strTxNum = Value
        End Set
    End Property

    Public Property MessageData() As String
        Get
            Return mv_strXmlMessageData
        End Get
        Set(ByVal Value As String)
            mv_strXmlMessageData = Value
        End Set
    End Property

    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property

    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
        End Set
    End Property

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
        End Set
    End Property

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property
    Public Property GroupCareBy() As String
        Get
            Return mv_strGroup
        End Get
        Set(ByVal Value As String)
            mv_strGroup = Value
        End Set
    End Property
    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
        End Set
    End Property

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property Tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
        End Set
    End Property
    Public Property IsHistoryView() As Boolean
        Get
            Return mv_blnIsHistoryView
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsHistoryView = Value
        End Set
    End Property

    Public Property CreatedDate() As String
        Get
            Return mv_strCreatedDate
        End Get
        Set(ByVal Value As String)
            mv_strCreatedDate = Value
        End Set
    End Property
    Public Property CreatedDate_En() As String
        Get
            Return mv_strCreatedDate_en
        End Get
        Set(ByVal Value As String)
            mv_strCreatedDate_en = Value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
    End Sub

    Property AutoApprove As Boolean

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblTransCode As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents lblTransCaption As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Friend WithEvents btnEntries As System.Windows.Forms.Button
    Friend WithEvents lblHelper As System.Windows.Forms.Label
    Friend WithEvents pnTransDetail As System.Windows.Forms.Panel
    Friend WithEvents tabTransact As System.Windows.Forms.TabControl
    Friend WithEvents tabAccountEntry As System.Windows.Forms.TabPage
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents dtpValidateField As System.Windows.Forms.DateTimePicker
    Friend WithEvents tabVATVoucher As System.Windows.Forms.TabPage
    Friend WithEvents btnRefuse As System.Windows.Forms.Button
    Friend WithEvents TabFEEDetails As System.Windows.Forms.TabPage
    Public WithEvents mskTransCode As AppCore.FlexMaskEditBox
    Friend WithEvents btnVoucher As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTransCode = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.lblTransCaption = New System.Windows.Forms.Label
        Me.mskTransCode = New AppCore.FlexMaskEditBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpValidateField = New System.Windows.Forms.DateTimePicker
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.btnEntries = New System.Windows.Forms.Button
        Me.lblHelper = New System.Windows.Forms.Label
        Me.pnTransDetail = New System.Windows.Forms.Panel
        Me.tabTransact = New System.Windows.Forms.TabControl
        Me.tabAccountEntry = New System.Windows.Forms.TabPage
        Me.TabFEEDetails = New System.Windows.Forms.TabPage
        Me.tabVATVoucher = New System.Windows.Forms.TabPage
        Me.btnReject = New System.Windows.Forms.Button
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnRefuse = New System.Windows.Forms.Button
        Me.btnVoucher = New System.Windows.Forms.Button
        Me.stbMain = New System.Windows.Forms.StatusBar
        Me.Panel1.SuspendLayout()
        Me.tabTransact.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTransCode
        '
        Me.lblTransCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransCode.Location = New System.Drawing.Point(8, 14)
        Me.lblTransCode.Name = "lblTransCode"
        Me.lblTransCode.Size = New System.Drawing.Size(100, 21)
        Me.lblTransCode.TabIndex = 58
        Me.lblTransCode.Tag = "lblTransCode"
        Me.lblTransCode.Text = "TransCode:"
        Me.lblTransCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(628, 405)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 50
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCANCEL.Location = New System.Drawing.Point(712, 405)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 51
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'lblTransCaption
        '
        Me.lblTransCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransCaption.Location = New System.Drawing.Point(200, 14)
        Me.lblTransCaption.Name = "lblTransCaption"
        Me.lblTransCaption.Size = New System.Drawing.Size(424, 21)
        Me.lblTransCaption.TabIndex = 59
        Me.lblTransCaption.Text = "lblTransCaption"
        Me.lblTransCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mskTransCode
        '
        Me.mskTransCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mskTransCode.Location = New System.Drawing.Point(112, 14)
        Me.mskTransCode.Mask = "9999"
        Me.mskTransCode.Name = "mskTransCode"
        Me.mskTransCode.SelTxtOnEnter = AppCore.FlexMaskEditBox.SelectTxt.Always
        Me.mskTransCode.Size = New System.Drawing.Size(76, 21)
        Me.mskTransCode.TabIndex = 56
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpValidateField)
        Me.Panel1.Controls.Add(Me.lblTransCode)
        Me.Panel1.Controls.Add(Me.lblTransCaption)
        Me.Panel1.Controls.Add(Me.mskTransCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 50)
        Me.Panel1.TabIndex = 52
        '
        'dtpValidateField
        '
        Me.dtpValidateField.CustomFormat = "DD/MM/YYYY"
        Me.dtpValidateField.Location = New System.Drawing.Point(376, 16)
        Me.dtpValidateField.Name = "dtpValidateField"
        Me.dtpValidateField.Size = New System.Drawing.Size(200, 21)
        Me.dtpValidateField.TabIndex = 60
        Me.dtpValidateField.Visible = False
        '
        'btnAdjust
        '
        Me.btnAdjust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjust.Location = New System.Drawing.Point(538, 405)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(80, 24)
        Me.btnAdjust.TabIndex = 51
        Me.btnAdjust.Text = "btnAdjust"
        '
        'btnEntries
        '
        Me.btnEntries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEntries.Location = New System.Drawing.Point(451, 405)
        Me.btnEntries.Name = "btnEntries"
        Me.btnEntries.Size = New System.Drawing.Size(80, 24)
        Me.btnEntries.TabIndex = 7
        Me.btnEntries.Text = "btnEntries"
        '
        'lblHelper
        '
        Me.lblHelper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHelper.Location = New System.Drawing.Point(170, 405)
        Me.lblHelper.Name = "lblHelper"
        Me.lblHelper.Size = New System.Drawing.Size(56, 21)
        Me.lblHelper.TabIndex = 56
        Me.lblHelper.Text = "lblHelper"
        Me.lblHelper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHelper.Visible = False
        '
        'pnTransDetail
        '
        Me.pnTransDetail.AutoScroll = True
        Me.pnTransDetail.BackColor = System.Drawing.SystemColors.Control
        Me.pnTransDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnTransDetail.Location = New System.Drawing.Point(0, 54)
        Me.pnTransDetail.Name = "pnTransDetail"
        Me.pnTransDetail.Size = New System.Drawing.Size(784, 200)
        Me.pnTransDetail.TabIndex = 0
        '
        'tabTransact
        '
        Me.tabTransact.Controls.Add(Me.tabAccountEntry)
        Me.tabTransact.Controls.Add(Me.TabFEEDetails)
        Me.tabTransact.Controls.Add(Me.tabVATVoucher)
        Me.tabTransact.Location = New System.Drawing.Point(0, 258)
        Me.tabTransact.Name = "tabTransact"
        Me.tabTransact.SelectedIndex = 0
        Me.tabTransact.Size = New System.Drawing.Size(784, 140)
        Me.tabTransact.TabIndex = 57
        '
        'tabAccountEntry
        '
        Me.tabAccountEntry.BackColor = System.Drawing.SystemColors.Control
        Me.tabAccountEntry.Location = New System.Drawing.Point(4, 22)
        Me.tabAccountEntry.Name = "tabAccountEntry"
        Me.tabAccountEntry.Size = New System.Drawing.Size(776, 114)
        Me.tabAccountEntry.TabIndex = 0
        Me.tabAccountEntry.Text = "tabAccountEntry"
        '
        'TabFEEDetails
        '
        Me.TabFEEDetails.Location = New System.Drawing.Point(4, 22)
        Me.TabFEEDetails.Name = "TabFEEDetails"
        Me.TabFEEDetails.Size = New System.Drawing.Size(776, 114)
        Me.TabFEEDetails.TabIndex = 2
        Me.TabFEEDetails.Text = "TabFEEDetails"
        '
        'tabVATVoucher
        '
        Me.tabVATVoucher.Location = New System.Drawing.Point(4, 22)
        Me.tabVATVoucher.Name = "tabVATVoucher"
        Me.tabVATVoucher.Size = New System.Drawing.Size(776, 114)
        Me.tabVATVoucher.TabIndex = 1
        Me.tabVATVoucher.Text = "tabVATVoucher"
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.Location = New System.Drawing.Point(364, 405)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(80, 24)
        Me.btnReject.TabIndex = 55
        Me.btnReject.Text = "btnReject"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.Location = New System.Drawing.Point(277, 405)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(80, 24)
        Me.btnApprove.TabIndex = 54
        Me.btnApprove.Text = "btnApprove"
        '
        'btnRefuse
        '
        Me.btnRefuse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefuse.Location = New System.Drawing.Point(194, 405)
        Me.btnRefuse.Name = "btnRefuse"
        Me.btnRefuse.Size = New System.Drawing.Size(80, 24)
        Me.btnRefuse.TabIndex = 58
        Me.btnRefuse.Text = "btnRefuse"
        '
        'btnVoucher
        '
        Me.btnVoucher.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoucher.Location = New System.Drawing.Point(170, 405)
        Me.btnVoucher.Name = "btnVoucher"
        Me.btnVoucher.Size = New System.Drawing.Size(80, 24)
        Me.btnVoucher.TabIndex = 59
        Me.btnVoucher.Text = "btnVoucher"
        '
        'stbMain
        '
        Me.stbMain.Location = New System.Drawing.Point(0, 436)
        Me.stbMain.Name = "stbMain"
        Me.stbMain.Size = New System.Drawing.Size(796, 22)
        Me.stbMain.TabIndex = 60
        Me.stbMain.Visible = False
        '
        'frmTransact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(796, 458)
        Me.Controls.Add(Me.stbMain)
        Me.Controls.Add(Me.pnTransDetail)
        Me.Controls.Add(Me.btnVoucher)
        Me.Controls.Add(Me.btnRefuse)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.tabTransact)
        Me.Controls.Add(Me.lblHelper)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.btnEntries)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTransact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTransact"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabTransact.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Sub SetLookUpDataForm()

    End Sub

    Protected Overridable Function InitDialog()
        Try

            'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadResource(Me)
            'Check day of this client
            If Not CheckDate() Then
                MessageBox.Show(mv_ResourceManager.GetString("TxDateBusDate"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                OnClose()
                Exit Function
            End If

            ' VinhLD add for auto resize
            mv_dblWindowSizeRatio_X = Screen.PrimaryScreen.Bounds.Width / BASED_SCREEN_WIDTH
            mv_dblWindowSizeRatio_Y = Screen.PrimaryScreen.Bounds.Height / BASED_SCREEN_HEIGHT
            mv_dblWindowSizeRatio_X = 1
            Me.Width = BASED_FORM_WIDTH * mv_dblWindowSizeRatio_X
            Me.Height = BASED_FORM_HEIGHT * mv_dblWindowSizeRatio_Y
            'end of VinhLD add for auto resize
            'Thiáº¿t láº­p cÃ¡c thuá»™c tÃ­nh ban Ä‘áº§u cho form
            DoResizeForm()


            If Me.ObjectName.Length > 0 Then
                LoadScreen(Me.ObjectName.ToString)
            ElseIf Me.TxDate.Length > 0 And Me.TxNum.Length > 0 Then
                If Me.Tltxcd = gc_GL_REVERSE9900 Then
                    LoadScreen(Me.Tltxcd)
                Else
                    ViewMessage(TxDate, TxNum)
                End If
            Else
                ResetScreen()
            End If
        Catch ex As Exception
            LogError.Write("frmTransact.:InitDialog.:" & ex.ToString, EventLogEntryType.Error)
        End Try
    End Function


    Private Function GetFieldValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmTransact.GetFieldValueByName"
        Dim i, v_count As Integer, v_strFLDVALUE As String
        Try
            v_strFLDVALUE = String.Empty
            If String.Compare(String.Empty, Trim(pv_strFLDNAME)) = 0 Then
                Return v_strFLDVALUE
            End If
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    v_strFLDVALUE = mv_arrObjFields(i).FieldValue
                    Return v_strFLDVALUE
                End If
            Next
            Return v_strFLDVALUE
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function
    'ctype(Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex),ComboBoxEx).SelectedValue
    Private Function GetControlValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmTransact.GetFieldValueByName"
        Dim i, v_count As Integer, v_strFLDVALUE As String
        Try
            v_strFLDVALUE = String.Empty
            If String.Compare(String.Empty, Trim(pv_strFLDNAME)) = 0 Then
                Return v_strFLDVALUE
            End If
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    Select Case mv_arrObjFields(i).ControlType
                        Case "C"
                            Return CType(Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex), ComboBoxEx).SelectedValue()
                        Case Else
                            Return Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex).Text
                    End Select
                    v_strFLDVALUE = mv_arrObjFields(i).FieldValue
                    Return v_strFLDVALUE
                End If
            Next
            Return v_strFLDVALUE
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Private Function GetDefaultValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmTransact.GetDefaultValueByName"
        Dim i, v_count As Integer, v_strFLDVALUE As String
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    v_strFLDVALUE = mv_arrObjFields(i).DefaultValue
                    Return v_strFLDVALUE
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Private Sub cboData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Create message to inquiry object fields
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Neu dang nap du lieu cho combo thi bo qua
            ' If mv_blnOnDisplayScreen = True Then Exit Sub

            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String
            Dim v_strFULLNAME As String
            v_strFULLNAME = ""
            Dim v_xmlDocument As New Xml.XmlDocument, ctl As Control
            Dim v_strLookupName As String, i, j, v_intNodeIndex, v_intCount As Integer

            ''    If (TypeOf (sender) Is ComboBoxEx) And Not mv_blnOnDisplayScreen Then
            If (TypeOf (sender) Is ComboBoxEx) Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing And Not IsDBNull(CType(sender, ComboBoxEx).SelectedValue) Then
                    v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    If v_strFieldValue <> "" And strFLDNAME <> "" Then
                        FillLookupDataRefCBO(strFLDNAME, v_strFieldValue)
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            ''MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub



    Public Sub FillLookupDataRefCBO(ByVal v_strFLDNAME As String, ByVal v_strVALUE As String)
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, ctl As Control, v_cboData As ComboBoxEx
        Dim v_strLookupName, v_strCMDSQL, v_strObjMsg As String, i, j, v_intNodeIndex, v_intCount As Integer
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try

            v_intCount = mv_arrObjFields.GetLength(0)

            For i = 0 To v_intCount - 1 Step 1
                If Trim(mv_arrObjFields(i).TagList).Length > 0 Then
                    If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                        If mv_arrObjFields(i).ControlType = "C" Then
                            v_strCMDSQL = mv_arrObjFields(i).TagList.Replace("<$TAGFIELD>", v_strVALUE)
                            'Lay du lieu
                            v_cboData = CType(Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex), ComboBoxEx)
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
                            v_ws.Message(v_strObjMsg)
                            '' mv_blnOnDisplayScreen = True    'Disable selected index change
                            FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                            
                            ''  mv_blnOnDisplayScreen = False
                        End If
                    End If
                End If
            Next

        Catch ex As Exception

        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try

    End Sub


    '---------------------------------------------------------------------------------------------------------
    'HÃ m nÃ y Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘iá»?n cÃ¡c thÃ´ng tin giÃ¡ trá»‹ Lookup Ä‘Æ°á»£c.
    'Biáº¿n vÃ o 
    '   v_strFLDNAME LÃ  mÃ£ trÆ°á»?ng thá»±c hiá»‡n Lookup
    '   v_strRETURNDATA  LÃ  giÃ¡ trá»‹ Value Ä‘Æ°á»£c chá»?n
    '   v_strFULLDATA   LÃ  káº¿t quáº£ danh sÃ¡ch tra cá»©u
    '---------------------------------------------------------------------------------------------------------
    Public Sub FillLookupData(ByVal v_strFLDNAME As String, ByVal v_strVALUE As String, ByVal v_strFULLDATA As String, Optional ByVal v_strFieldKey As String = "VALUE")
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, ctl As Control, v_cboData As ComboBoxEx
        Dim v_strLookupName, v_strCMDSQL, v_strObjMsg As String, i, j, v_intNodeIndex, v_intCount As Integer
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            If Len(v_strFULLDATA) > 0 Then
                v_xmlDocument.LoadXml(v_strFULLDATA)
                v_intCount = mv_arrObjFields.GetLength(0)
                If v_intCount > 0 Then
                    'Xac dinh node chua du lieu
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If v_strFieldKey = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) _
                                    And v_strVALUE = Trim(.InnerText.ToString) Then
                                    v_intNodeIndex = i
                                    Exit For
                                End If
                            End With
                        Next
                    Next

                    'Nap du lieu cho cac control duoc khai bao LookUpName/TagField
                    For i = 0 To v_intCount - 1 Step 1
                        If Not mv_arrObjFields(i) Is Nothing Then
                            If Trim(mv_arrObjFields(i).LookupName).Length > 0 Then
                                'Nạp các tham số lấy giá trị
                                If Mid(Trim(mv_arrObjFields(i).LookupName), 1, 2) = v_strFLDNAME Then
                                    'Từ vị trí thứ 3 trở đi là tên trường chứa dữ liệu
                                    v_strLookupName = Mid(Trim(mv_arrObjFields(i).LookupName), 3)
                                    If Not v_nodeList.Item(v_intNodeIndex) Is Nothing Then
                                        For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                            With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                                If v_strLookupName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                                    'Gan gia tri cho control tim duoc
                                                    ctl = Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex)
                                                    If Not (InStr("FULLNAME/ADDRESS/LICENSE/IDDATE/IDPLACE", v_strLookupName) > 0 And mv_retREFFIELD = v_strFLDNAME) Then
                                                        'Gan gia tri cho control tim duoc                                                    
                                                        If mv_arrObjFields(i).ControlType = "C" Then
                                                            CType(ctl, ComboBoxEx).SelectedValue = Trim(.InnerText.ToString)
                                                        Else
                                                            ctl.Text = Trim(.InnerText.ToString)
                                                        End If

                                                        If mv_arrObjFields(i).DataType = "N" And Len(mv_arrObjFields(i).FieldFormat) > 0 Then
                                                            FormatNumericTextbox(CType(ctl, TextBox))
                                                        End If
                                                    Else
                                                        'ctl.Text = mv_arrObjFields(i).DefaultValue
                                                    End If
                                                End If
                                            End With
                                        Next
                                    End If
                                End If
                            ElseIf Trim(mv_arrObjFields(i).TagList).Length > 0 Then
                                If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                                    If mv_arrObjFields(i).ControlType = "C" Then
                                        v_strCMDSQL = mv_arrObjFields(i).TagList.Replace("<$TAGFIELD>", v_strVALUE)
                                        'Lay du lieu
                                        v_cboData = CType(Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex), ComboBoxEx)
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
                                        v_ws.Message(v_strObjMsg)
                                        mv_blnOnDisplayScreen = True    'Disable selected index change
                                        FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                        If Trim(mv_arrObjFields(i).DefaultValue).Length > 0 Then
                                            CType(v_cboData, ComboBoxEx).SelectedValue = mv_arrObjFields(i).DefaultValue
                                        End If
                                        mv_blnOnDisplayScreen = False
                                    End If
                                End If
                            End If
                        End If
                    Next
                    ProcessTagFieldOnScreen()
                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try

    End Sub
    'Xu ly enabled/disable cac control tren man hinh theo TAGFIELD & TAGVALUE
    Public Sub ProcessTagFieldOnScreen()
        Dim ctl As Control
        Dim v_strTagFieldValue, v_strTagFieldName As String, i, j, v_intTagFieldIndex, v_intCount As Integer
        Try
            v_strTagFieldValue = ""
            v_intCount = mv_arrObjFields.GetLength(0)
            If v_intCount > 0 Then
                'Scan cac field co tham so TAGFIELD khac null
                For i = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(i) Is Nothing Then
                        If mv_arrObjFields(i).TagField.Trim.Length > 0 Then
                            v_strTagFieldName = mv_arrObjFields(i).TagField
                            'Xac dinh gia tri hien tai cua truong TAGFIELD
                            For j = 0 To v_intCount - 1 Step 1
                                If Not mv_arrObjFields(j) Is Nothing Then
                                    If String.Compare(v_strTagFieldName, mv_arrObjFields(j).FieldName) = 0 Then
                                        If Not Me.pnTransDetail.Controls(mv_arrObjFields(j).ControlIndex) Is Nothing Then
                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(j).ControlIndex)
                                            If mv_arrObjFields(j).ControlType = "C" Then
                                                v_strTagFieldValue = CType(ctl, ComboBoxEx).SelectedValue
                                            ElseIf mv_arrObjFields(j).ControlType = "T" Or mv_arrObjFields(j).ControlType = "M" Or mv_arrObjFields(j).ControlType = "R" Then
                                                v_strTagFieldValue = ctl.Text.Trim
                                            Else
                                                v_strTagFieldValue = ""
                                            End If
                                        End If
                                        Exit For
                                    End If
                                End If
                            Next

                            'Duyet cac control co tham chieu den TAGFIELD de enabled/disable
                            For v_intTagFieldIndex = 0 To v_intCount - 1 Step 1
                                If Not mv_arrObjFields(v_intTagFieldIndex) Is Nothing Then
                                    If String.Compare(mv_arrObjFields(v_intTagFieldIndex).TagField, v_strTagFieldName) = 0 And Not v_strTagFieldValue Is Nothing And Trim(mv_arrObjFields(v_intTagFieldIndex).TagList) = "" Then
                                        If v_strTagFieldValue.Trim.Length > 0 Then
                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intTagFieldIndex).ControlIndex)
                                            If mv_arrObjFields(v_intTagFieldIndex).TagValue.IndexOf("[" & v_strTagFieldValue & "]") >= 0 Then
                                                ctl.Enabled = True
                                                mv_arrObjFields(v_intTagFieldIndex).Enabled = True
                                            Else
                                                ctl.Enabled = False
                                                mv_arrObjFields(v_intTagFieldIndex).Enabled = False
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------
    'HÃ m nÃ y Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘á»ƒ náº¡p mÃ n hÃ¬nh.
    'Biáº¿n vÃ o 
    '   strTLTXCD lÃ  mÃ£ giao dá»‹ch, dÃ¹ng Ä‘á»ƒ xÃ¡c Ä‘á»‹nh cÃ¡c trÆ°á»?ng trong giao dá»‹ch
    '   v_blnChain  XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh sau khi Ä‘Ã£ tra cá»©u khÃ´ng
    '   v_blnData   XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh xem chi tiáº¿t giao dá»‹ch khÃ´ng
    '   v_strXML    LÃ  ná»™i dung chuá»—i XML tÆ°Æ¡ng á»©ng vá»›i v_blnChain hoáº·c v_blnData
    '---------------------------------------------------------------------------------------------------------
    Public Sub LoadScreen(ByVal strTLTXCD As String, _
                Optional ByVal v_blnChain As Boolean = False, _
                Optional ByVal v_blnData As Boolean = False, _
                Optional ByVal v_strXML As String = vbNullString)
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String, i, j, m, n, lngPosition1, lngPosition2 As Integer, v_objField As CFieldMaster, v_objFieldVal As CFieldVal
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strControlType, _
            v_strChainName, v_strLookupName, v_strPrintInfo, v_strInvName, v_strInvFormat, v_strFldSource, v_strFldDesc, _
            v_strSearchCode, v_strSrModCode, v_strPDefName, v_strTagList, v_strTagField, v_strTagValue, v_strFldRound As String
        Dim v_intOdrNum, v_intFldLen, v_intFldWidth, v_intFldRow, v_intIndex As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
            'v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            v_strClause = "SELECT TLTX.*,FEEENTRY FROM TLTX,(SELECT '" & strTLTXCD & "' TLTXCD, COUNT(*) FEEENTRY FROM FEEMAP WHERE TLTXCD='" & strTLTXCD & "') FEETX WHERE TLTX.TLTXCD=FEETX.TLTXCD"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetScreen()
                Exit Sub
            End If
            mv_isBackDate = False
            mv_blnAcctEntry = mv_blnAcctEntry
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    lblTransCaption.Text = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    lblTransCaption.Text = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "FEEENTRY"
                                mv_lngFeeEntry = v_strValue
                            Case "BGCOLOR"
                                pnTransDetail.BackColor = getTransBGColor(CInt(Trim(v_strValue)))
                            Case "BKDATE"
                                mv_isBackDate = IIf(Trim(v_strValue) = "Y", True, False)
                            Case "VOUCHERID"
                                VoucherID = IIf(v_strValue Is Nothing, "", v_strValue)
                            Case "MSG_ACCT"
                                mv_strMsgAccount = IIf(v_strValue Is Nothing, "", v_strValue)
                            Case "CCYCD"
                                mv_strCCYCD = IIf(v_strValue Is Nothing, "##", v_strValue)
                        End Select
                    End With
                Next
            Next
            mskTransCode.Text = strTLTXCD
            mv_strTxBusDate = Me.BusDate

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            'ReDim mv_arrObjFields(v_nodeList.Count - 1)
            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = Trim(v_strValue)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "FLDWIDTH"
                                v_intFldWidth = CInt(Trim(v_strValue))
                            Case "FLDROW"
                                v_intFldRow = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                                'Xá»­ lÃ½ cÃ¡c biáº¿n há»‡ thá»‘ng
                                v_strLList = v_strLList.Replace("<$BRID>", Me.BranchId)
                                v_strLList = v_strLList.Replace("<$TLID>", Me.TellerId)
                                v_strLList = v_strLList.Replace("<$BUSDATE>", Me.BusDate)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "CTLTYPE"
                                v_strControlType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "INVFORMAT"
                                v_strInvFormat = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSrModCode = Trim(v_strValue)
                            Case "PDEFNAME"
                                v_strPDefName = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
                            Case "TAGLIST"
                                v_strTagList = v_strValue
                            Case "TAGFIELD"
                                v_strTagField = v_strValue
                            Case "FLDRND"
                                v_strFldRound = v_strValue

                            Case "TAGVALUE"
                                v_strTagValue = v_strValue
                        End Select
                    End With
                Next

                v_objField = New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .FieldWidth = v_intFldWidth
                    .FieldRow = v_intFldRow
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .LookupName = v_strLookupName
                    .TagList = v_strTagList
                    .TagField = v_strTagField
                    .TagValue = v_strTagValue

                    If v_strDefName = "DESC" And Len(v_strDefVal) = 0 Then
                        'Xá»­ lÃ½ cho trÆ°á»?ng Description
                        v_strDefVal = Me.lblTransCaption.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    ElseIf v_strDefVal = "<$TLID>" Then
                        v_strDefVal = Me.TellerId
                        'HaiLT them
                    ElseIf v_strDefVal.IndexOf("<$SQL>") >= 0 Then
                        'Neu la tham chieu tu cau lenh SQL
                        Dim mv_strXMLFldMasterTmp As String
                        Dim v_nodeListTmp As Xml.XmlNodeList
                        Dim v_xmlDocumentTmp As New Xml.XmlDocument
                        Dim v_strClauseTmp, v_strValueTmp, v_strFLDNAMETmp As String
                        v_strDefVal = Replace(v_strDefVal, "<$SQL>", "")
                        v_strDefVal = Replace(v_strDefVal, "<$BRID>", Me.BranchId)
                        v_strDefVal = Replace(v_strDefVal, "<$TLID>", Me.TellerId)
                        v_strDefVal = Replace(v_strDefVal, "<$BUSDATE>", Me.BusDate)

                        'Doc thong tin cac truong cua object duoc dung de hien thi
                        Dim v_strObjMsgTmp As String
                        v_strObjMsgTmp = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strDefVal, )
                        v_ws.Message(v_strObjMsgTmp)
                        'mv_strXMLFldMasterTmp = v_strObjMsgTmp
                        v_xmlDocumentTmp.LoadXml(v_strObjMsgTmp)
                        v_nodeListTmp = v_xmlDocumentTmp.SelectNodes("/ObjectMessage/ObjData")
                        'ReDim mv_arrObjFields(v_nodeListTmp.Count)
                        For l As Integer = 0 To v_nodeListTmp.Count - 1
                            For k As Integer = 0 To v_nodeListTmp.Item(l).ChildNodes.Count - 1
                                With v_nodeListTmp.Item(l).ChildNodes(k)
                                    v_strValueTmp = .InnerText.ToString
                                    v_strFLDNAMETmp = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                                    Select Case Trim(v_strFLDNAMETmp)
                                        Case "DEFNAME"
                                            v_strDefVal = Trim(v_strValueTmp)
                                    End Select
                                End With
                            Next
                        Next
                        'End of HaiLT them
                    ElseIf DefaultValue <> "" Then
                        'Láº¥y máº·c Ä‘á»‹nh tá»« form search khÃ¡c truyá»?n vÃ o
                        lngPosition1 = InStr(1, DefaultValue, "[" & v_strFieldName)
                        If lngPosition1 > 0 Then
                            lngPosition2 = InStr(lngPosition1, DefaultValue, "]")
                            v_strDefVal = Mid(DefaultValue, lngPosition1 + 4, lngPosition2 - lngPosition1 - 4)
                        End If
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°á»?ng nÃ y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/Entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiáº¿t)
                    End If
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .ControlType = v_strControlType
                    .InvName = v_strInvName
                    .InvFormat = v_strInvFormat
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSrModCode
                    .FieldValue = String.Empty
                    .PDefName = v_strPDefName
                    .FldRound = v_strFldRound

                    '
                    If .LookupCheck = "Y" Then
                        Me.stbMain.Visible = True
                    End If
                End With
                mv_arrObjFields(i) = v_objField
            Next
            'ReDim Preserve mv_arrObjFields(v_nodeList.Count - 1)
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°á»?ng giao dá»‹ch
            'v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
            '    "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan trá»?ng khÃ´ng sá»­a
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            'v_ws.Message(v_strObjMsg)
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG, CHKLEV,TAGFIELD,TAGVALUE FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± order by lÃƒÂ  quan trÃ¡Â»?ng khÃƒÂ´ng sÃ¡Â»Â¬a
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)
            'Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
            '    v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg As String
            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg, v_strFieldVal_ChkLev, _
                v_strFieldVal_TagField, v_strFieldVal_TagValue As String
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°á»?ng cá»§a giao dá»‹ch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldVal_FldName = Trim(v_strValue)
                            Case "VALTYPE"
                                v_strFieldVal_ValType = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strFieldVal_Operator = Trim(v_strValue)
                            Case "VALEXP"
                                v_strFieldVal_ValExp = Trim(v_strValue)
                            Case "VALEXP2"
                                v_strFieldVal_ValExp2 = Trim(v_strValue)
                            Case "ERRMSG"
                                v_strFieldVal_ErrMsg = Trim(v_strValue)
                            Case "EN_ERRMSG"
                                v_strFieldVal_EnErrMsg = Trim(v_strValue)
                            Case "CHKLEV"
                                v_strFieldVal_ChkLev = Trim(v_strValue)
                            Case "TAGFIELD"
                                v_strFieldVal_TagField = Trim(v_strValue)
                            Case "TAGVALUE"
                                v_strFieldVal_TagValue = Trim(v_strValue)

                        End Select
                    End With
                Next

                'XÃ¡c Ä‘á»‹nh index cá»§a máº£ng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                'Ä?iá»?u kiá»‡n xá»­ lÃ½
                v_objFieldVal = New CFieldVal
                With v_objFieldVal
                    .OBJNAME = strTLTXCD
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .CHKLEV = v_strFieldVal_ChkLev
                    .IDXFLD = v_intIndex
                    .TAGFIELD = v_strFieldVal_TagField
                    .TAGVALUE = v_strFieldVal_TagValue
                End With
                mv_arrObjFldVals(i) = v_objFieldVal
            Next
            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)
            'Hiá»ƒn thá»‹ thÃ´ng tin giao dá»‹ch lÃªn mÃ n hÃ¬nh
            DisplayScreen()

            If strTLTXCD = gc_GL_REVERSE9900 Then
                Dim v_ctl As Control
                For Each v_ctl In Me.pnTransDetail.Controls
                    'Láº¥y ná»™i dung giao dá»‹ch
                    If v_ctl.Name = PREFIXED_MSKDATA & "03" Then 'BRID
                        v_ctl.Text = Me.BranchId
                    ElseIf v_ctl.Name = PREFIXED_MSKDATA & "90" Then 'TXDATE
                        v_ctl.Text = Me.TxDate
                    ElseIf v_ctl.Name = PREFIXED_MSKDATA & "91" Then 'TXNUM
                        v_ctl.Text = Me.TxNum
                    ElseIf v_ctl.Name = PREFIXED_MSKDATA & "30" Then 'TXDESC
                        v_ctl.Text = "Delete: " & Me.TXDESC
                    End If
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_xmlDocumentData = Nothing
            v_ws = Nothing
        End Try
    End Sub

    '18/11/2008:Cap nhat ham AppCore.frmTransact.CreateFeemap de cho phep tu dong lua chon bieu phi theo dieu kien chon
    Private Function CreateFeemap(ByRef pv_xmlDocument As Xml.XmlDocument)
        Dim v_feeElement As Xml.XmlElement, v_entryNode As Xml.XmlNode, v_ctl As Control
        Dim strTLTXCD, v_strFEECD, v_strREFCODE, v_strREFFIELD, v_strREFFIELDVAL, v_strGLACCTNO, v_strFORP, v_strAMTEXP, v_strVALEXP As String
        Dim v_dblTOTALFEEAMT, v_dblTOTALVATAMT, v_dblFLATAMT, v_dblFEEAMT, v_dblVATAMT, v_dblTXAMT, v_dblFEERATE, v_dblVATRATE, v_dblMINVAL, v_dblMAXVAL As Double

        'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
        strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).InnerXml

        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, i, j As Integer, v_strSQL, v_strValue, v_strFLDNAME As String
        Dim v_objEval As New Evaluator
        Dim v_xmlFeeDocument As New Xml.XmlDocument, v_xmlFeeDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        Dim v_intIndex As Integer, v_strFieldValue, strFLDNAME As String
        mv_strListOfTXFeeCode = String.Empty
        For Each v_control As Control In Me.pnTransDetail.Controls
            If InStr(CType(v_control, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(v_control, Control).Tag
                v_strFLDNAME = mv_arrObjFields(v_intIndex).ColumnName
                If v_strFLDNAME.IndexOf(PREFIXED_FLDNAME_FEECODE) <> -1 Then
                    v_strFieldValue = v_control.Text.Trim
                    If v_strFieldValue.Length > 0 Then
                        v_strFieldValue = "'" & v_strFieldValue & "'"
                        If Not mv_strListOfTXFeeCode.IndexOf(v_strFieldValue) > 0 Then
                            If mv_strListOfTXFeeCode.Length = 0 Then
                                mv_strListOfTXFeeCode = v_strFieldValue
                            Else
                                mv_strListOfTXFeeCode = v_strFieldValue & "," & mv_strListOfTXFeeCode
                            End If
                        End If
                    End If
                End If
            End If
        Next

        If mv_strListOfTXFeeCode.Length > 0 Then
            'Neu giao dich co lua chon phi
            v_strSQL = "SELECT FEEMASTER.*, FEEMAP.AMTEXP, FEEMAP.REFFIELD FROM FEEMAP,FEEMASTER WHERE FEEMASTER.STATUS='Y' AND FEEMASTER.FEECD=FEEMAP.FEECD AND FEEMAP.TLTXCD='" & strTLTXCD & "' AND FEEMASTER.FEECD IN (" & mv_strListOfTXFeeCode & ") ORDER BY FEEMASTER.REFCODE"
        Else
            'Neu khong co
            v_strSQL = "SELECT FEEMASTER.*, FEEMAP.AMTEXP, FEEMAP.REFFIELD FROM FEEMAP,FEEMASTER WHERE FEEMASTER.STATUS='Y' AND FEEMASTER.FEECD=FEEMAP.FEECD AND FEEMAP.TLTXCD='" & strTLTXCD & "' ORDER BY FEEMASTER.REFCODE"
        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlFeeDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlFeeDocument.SelectNodes("/ObjectMessage/ObjData")
        v_feeElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "feemap", "")
        v_dblTOTALFEEAMT = 0
        v_dblTOTALVATAMT = 0

        For i = 0 To v_nodeList.Count - 1
            'Lay bang dinh nghia phi giao dich
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "FEECD"
                            v_strFEECD = v_strValue
                        Case "REFFIELD"
                            v_strREFFIELD = v_strValue
                        Case "REFCODE"
                            v_strREFCODE = v_strValue
                        Case "GLACCTNO"
                            v_strGLACCTNO = v_strValue
                        Case "FORP"
                            v_strFORP = v_strValue
                        Case "AMTEXP"
                            v_strAMTEXP = v_strValue
                        Case "FEEAMT"
                            v_dblFLATAMT = v_strValue
                        Case "FEERATE"
                            v_dblFEERATE = v_strValue
                        Case "VATRATE"
                            v_dblVATRATE = v_strValue
                        Case "MINVAL"
                            v_dblMINVAL = v_strValue
                        Case "MAXVAL"
                            v_dblMAXVAL = v_strValue
                    End Select
                End With
            Next

            'Xac dinh gia tri cua REFFIELD
            v_strREFFIELDVAL = String.Empty
            If v_strREFCODE.Trim.Length > 0 Then
                For Each v_ctl In Me.pnTransDetail.Controls
                    'If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 And TypeOf (v_ctl) Is FlexMaskEditBox Then
                    If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strREFFIELD) > 0 Then
                        If TypeOf (v_ctl) Is ComboBoxEx Then
                            v_strREFFIELDVAL = CType(v_ctl, ComboBoxEx).SelectedValue
                        Else
                            v_strREFFIELDVAL = Convert.ToDouble(v_ctl.Text).ToString
                        End If
                        If v_strREFFIELDVAL Is Nothing Or Len(v_strValue) = 0 Then
                            v_strREFFIELDVAL = "0"
                        End If
                        Exit For
                    End If
                Next
            End If

            'Tao fee map neu gia tri cua REFFIELD=REFCODE
            If String.Compare(v_strREFFIELDVAL, v_strREFCODE) = 0 Then
                'Tinh toan gia tri phi
                v_strVALEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                v_dblTXAMT = v_objEval.Eval(v_strVALEXP)
                If v_strFORP = "F" Then
                    'Phi co dinh
                    v_dblFEEAMT = v_dblFLATAMT
                Else
                    'Phi theo ty le
                    If v_dblTXAMT > 0 Then
                        v_dblFEEAMT = v_dblFEERATE * v_dblTXAMT / 100
                        If v_dblFEEAMT < v_dblMINVAL Then v_dblFEEAMT = v_dblMINVAL
                        If v_dblFEEAMT > v_dblMAXVAL Then v_dblFEEAMT = v_dblMAXVAL
                    Else
                        v_dblFEEAMT = 0
                    End If
                End If
                v_dblVATAMT = v_dblFEEAMT * v_dblVATRATE / 100

                'Tao cac dong thu phi
                v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                Dim v_attrFEECD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feecd")
                v_attrFEECD.Value = v_strFEECD
                v_entryNode.Attributes.Append(v_attrFEECD)

                Dim v_attrGLACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("glacctno")
                v_attrGLACCTNO.Value = v_strGLACCTNO
                v_entryNode.Attributes.Append(v_attrGLACCTNO)

                Dim v_attrFEEAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feeamt")
                v_attrFEEAMT.Value = v_dblFEEAMT
                v_entryNode.Attributes.Append(v_attrFEEAMT)

                Dim v_attrVATAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vatamt")
                v_attrVATAMT.Value = v_dblVATAMT
                v_entryNode.Attributes.Append(v_attrVATAMT)

                Dim v_attrVATRATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vatrate")
                v_attrVATRATE.Value = v_dblVATRATE
                v_entryNode.Attributes.Append(v_attrVATRATE)

                Dim v_attrTXAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("txamt")
                v_attrTXAMT.Value = v_dblTXAMT
                v_entryNode.Attributes.Append(v_attrTXAMT)

                Dim v_attFEERATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feerate")
                v_attFEERATE.Value = v_dblFEERATE
                v_entryNode.Attributes.Append(v_attFEERATE)

                v_entryNode.InnerText = v_dblFEEAMT
                v_feeElement.AppendChild(v_entryNode)

                v_dblTOTALFEEAMT = v_dblTOTALFEEAMT + v_dblFEEAMT
                v_dblTOTALVATAMT = v_dblTOTALVATAMT + v_dblVATAMT
            End If
        Next
        pv_xmlDocument.DocumentElement.AppendChild(v_feeElement)
        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).InnerXml = v_dblTOTALFEEAMT
        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).InnerXml = v_dblTOTALVATAMT
    End Function


    '---------------------------------------------------------------------------------------------------------
    'HÃ m nÃ y Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘á»ƒ hiá»ƒn thá»‹ thÃ´ng tin giao dá»‹ch
    'Biáº¿n vÃ o 
    '   strTXDATE   NgÃ y giao dá»‹ch
    '   strTXNUM    Sá»‘ chá»©ng tá»«
    '---------------------------------------------------------------------------------------------------------
    Public Sub ViewMessage(ByVal v_strTXDATE As String, ByVal v_strTXNUM As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Create message to inquiry object fields
            Dim v_strClause, v_strSQL, v_strObjMsg, v_strFLDNAME, v_strValue, v_strTXSTATUS, v_strTXBUSDATE, v_strDELTD As String, i, j As Integer
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
            Dim v_objField As CFieldMaster, v_objAccount As CAccountEntry, v_objVAT As CVATVoucher, v_objFA As CIEFMISEntry
            Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
                v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strControlType, _
                v_strChainName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, _
                v_strTagList, v_strTagField, v_strTagValue, v_strNValue, v_strCValue, v_strPDefName As String
            Dim v_intOdrNum, v_intFldLen, v_intFldWidth, v_intFldRow As Integer
            Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
            If v_strTXDATE = Me.BusDate Then
                If Strings.Left(v_strTXNUM, 2) = BATCH_PREFIXED Then
                    v_strSQL = "SELECT TLTX.VOUCHERID,TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOG.TXSTATUS, TLLOG.BUSDATE, TLLOG.TXDESC LOGDESC,TLLOG.DELTD FROM TLTX, TLLOG " & ControlChars.CrLf _
                                            & "WHERE TLTX.TLTXCD=TLLOG.TLTXCD AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
                Else
                    v_strSQL = "SELECT TLTX.VOUCHERID,TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOG.TXSTATUS, TLLOG.BUSDATE, TLLOG.TXDESC LOGDESC,TLLOG.DELTD FROM TLTX, TLLOG " & ControlChars.CrLf _
                                            & "WHERE TLTX.TLTXCD=TLLOG.TLTXCD AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
                End If
            Else
                v_strSQL = "SELECT TLTX.VOUCHERID,TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOGALL.TXSTATUS, TLLOGALL.BUSDATE, TLLOGALL.TXDESC LOGDESC,TLLOGALL.DELTD FROM TLTX, TLLOGALL " & ControlChars.CrLf _
                        & "WHERE TLTX.TLTXCD=TLLOGALL.TLTXCD AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TLTXCD"
                                mskTransCode.Text = Trim(v_strValue)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    lblTransCaption.Text = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    lblTransCaption.Text = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"
                                pnTransDetail.BackColor = getTransBGColor(CInt(Trim(v_strValue)))
                            Case "TXSTATUS"
                                v_strTXSTATUS = Trim(v_strValue)
                            Case "DELTD"
                                v_strDELTD = Trim(v_strValue)
                            Case "BUSDATE"
                                mv_strTxBusDate = Trim(v_strValue)
                            Case "LOGDESC"
                                mv_strTxDesc = Trim(v_strValue)
                            Case "VOUCHERID"
                                VoucherID = IIf(v_strValue Is Nothing, "", v_strValue)

                            Case "BKDATE"
                                mv_isBackDate = IIf(Trim(v_strValue) = "Y", True, False)
                        End Select
                    End With
                Next
            Next
            'PhuongHT- comment
            ' mv_isBackDate = False 'KhÃ´ng cho phÃ©p sá»­a láº¡i posting date
            mv_isEnableBackDate = False

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
            If v_strTXDATE = Me.BusDate Then
                If Strings.Left(v_strTXNUM, 2) = BATCH_PREFIXED Then
                    v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                                            & "FROM FLDMASTER FLD, TLLOGFLD LGFLD, TLLOG LG " & ControlChars.CrLf _
                                            & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                                            & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                            & "ORDER BY ODRNUM"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
                Else
                    v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                                            & "FROM FLDMASTER FLD, TLLOGFLD LGFLD, TLLOG LG " & ControlChars.CrLf _
                                            & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                                            & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                            & "ORDER BY ODRNUM"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strSQL)
                End If
            Else
                v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                        & "FROM FLDMASTER FLD, TLLOGFLDALL LGFLD, TLLOGALL LG " & ControlChars.CrLf _
                        & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY ODRNUM"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'ReDim mv_arrObjFields(v_nodeList.Count - 1)
            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                v_strNValue = vbNullString
                v_strCValue = vbNullString
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = Trim(v_strValue)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "FLDWIDTH"
                                v_intFldWidth = CInt(Trim(v_strValue))
                            Case "FLDROW"
                                v_intFldRow = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "CTLTYPE"
                                v_strControlType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
                            Case "NVALUE"
                                v_strNValue = v_strValue
                            Case "CVALUE"
                                v_strCValue = v_strValue
                            Case "PDEFNAME"
                                v_strPDefName = v_strValue
                            Case "TAGLIST"
                                v_strTagList = v_strValue
                            Case "TAGFIELD"
                                v_strTagField = v_strValue
                            Case "TAGVALUE"
                                v_strTagValue = v_strValue
                        End Select
                    End With
                Next

                v_objField = New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .FieldWidth = v_intFldWidth
                    .FieldRow = v_intFldRow
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .TagList = v_strTagList
                    .TagField = v_strTagField
                    .TagValue = v_strTagValue
                    'XÃ¡c Ä‘á»‹nh giÃ¡ trá»‹ hiá»ƒn thá»‹ trÃªn mÃ n hÃ¬nh
                    If CDbl(v_strNValue) <> 0 Then
                        v_strDefVal = v_strNValue
                    ElseIf v_strFldType = "N" Then
                        v_strDefVal = v_strNValue
                    Else
                        v_strDefVal = v_strCValue
                    End If
                    .FieldValue = v_strDefVal
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = False 'v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .ControlType = v_strControlType
                    .InvName = v_strInvName
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .PDefName = v_strPDefName
                    If .LookupCheck = "Y" Then
                        Me.stbMain.Visible = True
                    End If
                End With
                mv_arrObjFields(i) = v_objField
            Next
            'ReDim Preserve mv_arrObjFields(v_nodeList.Count - 1)
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Láº¥y thÃ´ng tin vá»? háº¡ch toÃ¡n
            If v_strTXDATE = Me.BusDate Then
                If Strings.Left(v_strTXNUM, 2) = BATCH_PREFIXED Then
                    v_strSQL = "SELECT GL.* FROM TLLOG LG, GLTRAN GL " & ControlChars.CrLf _
                                            & "WHERE LG.TXNUM=GL.TXNUM AND LG.TXDATE=GL.TXDATE " & ControlChars.CrLf _
                                            & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                            & "ORDER BY GL.SUBTXNO, GL.DORC DESC"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
                Else
                    v_strSQL = "SELECT GL.* FROM TLLOG LG, GLTRAN GL " & ControlChars.CrLf _
                                            & "WHERE LG.TXNUM=GL.TXNUM AND LG.TXDATE=GL.TXDATE " & ControlChars.CrLf _
                                            & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                            & "ORDER BY GL.SUBTXNO, GL.DORC DESC"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
                End If
            Else
                v_strSQL = "SELECT GL.* FROM TLLOGALL LG, GLTRANA GL " & ControlChars.CrLf _
                        & "WHERE LG.TXNUM=GL.TXNUM AND LG.TXDATE=GL.TXDATE " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY GL.SUBTXNO, GL.DORC DESC"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strACCTNO As String, v_dblAMT As Double
            If v_nodeList.Count = 0 Then
                mv_arrObjAccounts = Nothing
            Else
                ReDim mv_arrObjAccounts(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "SUBTXNO"
                                    v_strSUBTXNO = Trim(v_strValue)
                                Case "CCYCD"
                                    v_strCCYCD = Trim(v_strValue)
                                Case "DORC"
                                    v_strDORC = Trim(v_strValue)
                                Case "ACCTNO"
                                    v_strACCTNO = Trim(v_strValue)
                                Case "AMT"
                                    v_dblAMT = CDbl(Trim(v_strValue))
                            End Select
                        End With
                    Next
                    v_objAccount = New CAccountEntry
                    With v_objAccount
                        .SUBTXNO = v_strSUBTXNO
                        .CCYCD = v_strCCYCD
                        .DORC = v_strDORC
                        .ACCTNO = v_strACCTNO
                        .AMOUNT = v_dblAMT
                    End With
                    mv_arrObjAccounts(i) = v_objAccount
                Next
                ReDim Preserve mv_arrObjAccounts(v_nodeList.Count)
            End If

            '-------------------------
            'Láº¥y thÃ´ng tin vá»? hoÃ¡ Ä‘Æ¡n VAT
            If v_strTXDATE = Me.BusDate Then
                v_strSQL = "SELECT * FROM VATTRAN VAT WHERE VAT.TXNUM='" & v_strTXNUM & "' AND VAT.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') ORDER BY VAT.VOUCHERNO"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            Else
                v_strSQL = "SELECT * FROM VATTRAN VAT WHERE VAT.TXNUM='" & v_strTXNUM & "' AND VAT.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') ORDER BY VAT.VOUCHERNO"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strVOUCHERNO, v_strVOUCHERTYPE, v_strSERIENO, v_strCUSTID, v_strTAXCODE, v_strCUSTNAME, v_strADDRESS, v_strCONTENTS, v_strDESCRIPTION As String
            Dim v_dblQTTY, v_dblPRICE, v_dblVATRATE As Double
            Dim v_strVOUCHERDATE As String

            If v_nodeList.Count = 0 Then
                mv_arrObjVAT = Nothing
            Else
                Me.btnEntries.Visible = True
                Me.btnEntries.Enabled = False
                ReDim mv_arrObjVAT(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "VOUCHERNO"
                                    v_strVOUCHERNO = Trim(v_strValue)
                                Case "VOUCHERTYPE"
                                    v_strVOUCHERTYPE = Trim(v_strValue)
                                Case "SERIENO"
                                    v_strSERIENO = Trim(v_strValue)
                                Case "VOUCHERDATE"
                                    v_strVOUCHERDATE = Trim(v_strValue)
                                Case "CUSTID"
                                    v_strCUSTID = Trim(v_strValue)
                                Case "TAXCODE"
                                    v_strTAXCODE = Trim(v_strValue)
                                Case "CUSTNAME"
                                    v_strCUSTNAME = Trim(v_strValue)
                                Case "ADDRESS"
                                    v_strADDRESS = Trim(v_strValue)
                                Case "CONTENTS"
                                    v_strCONTENTS = Trim(v_strValue)
                                Case "QTTY"
                                    v_dblQTTY = CDbl(Trim(v_strValue))
                                Case "PRICE"
                                    v_dblPRICE = CDbl(Trim(v_strValue))
                                Case "VATRATE"
                                    v_dblVATRATE = CDbl(Trim(v_strValue))
                                Case "DESCRIPTION"
                                    v_strDESCRIPTION = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    v_objVAT = New CVATVoucher
                    With v_objVAT
                        .VOUCHERNO = v_strVOUCHERNO
                        .VOUCHERTYPE = v_strVOUCHERTYPE
                        .SERIENO = v_strSERIENO
                        .VOUCHERDATE = v_strVOUCHERDATE
                        .CUSTID = v_strCUSTID
                        .TAXCODE = v_strTAXCODE
                        .CUSTNAME = v_strCUSTNAME
                        .ADDRESS = v_strADDRESS
                        .CONTENTS = v_strCONTENTS
                        .QTTY = v_dblQTTY
                        .PRICE = v_dblPRICE
                        .VATRATE = v_dblVATRATE
                        .DESCRIPTION = v_strDESCRIPTION
                    End With
                    mv_arrObjVAT(i) = v_objVAT
                Next
                ReDim Preserve mv_arrObjVAT(v_nodeList.Count)
            End If

            'Láº¥y thÃ´ng tin vá»? Fixed assest/Income/Expense
            v_strSQL = "SELECT * FROM MITRAN MST WHERE MST.TXNUM='" & v_strTXNUM & "' AND MST.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') ORDER BY MST.SUBTXNO,MST.DORC DESC"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_dblMISUBTXNO As Double, v_strMIDORC, v_strMIACCTNO, v_strMICUSTID, v_strMICUSTNAME, v_strMITASKCD, v_strMIDEPTCD, v_strMIMICD, v_strMIDESCRIPTION As String

            If v_nodeList.Count = 0 Then
                mv_arrObjIEFMIS = Nothing
            Else
                ReDim mv_arrObjIEFMIS(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "SUBTXNO"
                                    v_dblMISUBTXNO = CDbl(Trim(v_strValue))
                                Case "DORC"
                                    v_strMIDORC = Trim(v_strValue)
                                Case "ACCTNO"
                                    v_strMIACCTNO = Trim(v_strValue)
                                Case "CUSTID"
                                    v_strMICUSTID = Trim(v_strValue)
                                Case "CUSTNAME"
                                    v_strMICUSTNAME = Trim(v_strValue)
                                Case "TASKCD"
                                    v_strMITASKCD = Trim(v_strValue)
                                Case "DEPTCD"
                                    v_strMIDEPTCD = Trim(v_strValue)
                                Case "MICD"
                                    v_strMIMICD = Trim(v_strValue)
                                Case "DESCRIPTION"
                                    v_strMIDESCRIPTION = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    v_objFA = New CIEFMISEntry
                    With v_objFA
                        .SUBTXNO = v_dblMISUBTXNO
                        .DORC = v_strMIDORC
                        .ACCTNO = v_strMIACCTNO
                        .CUSTID = v_strMICUSTID
                        .CUSTNAME = v_strMICUSTNAME
                        .TASKCD = v_strMITASKCD
                        .DEPTCD = v_strMIDEPTCD
                        .MICD = v_strMIMICD
                        .DESCRIPTION = v_strMIDESCRIPTION
                    End With
                    mv_arrObjIEFMIS(i) = v_objFA
                Next
                ReDim Preserve mv_arrObjIEFMIS(v_nodeList.Count)
            End If

            '------------------------
            'Hiá»ƒn thá»‹ thÃ´ng tin giao dá»‹ch lÃªn mÃ n hÃ¬nh
            ShowUserViewInfo()
            DisplayScreen()
            'Tráº¡ng thÃ¡i máº·c Ä‘á»‹nh lÃ  chá»‰ hiá»‡n phÃ­m CANCEL
            Me.mskTransCode.Enabled = False
            Me.btnAdjust.Visible = False
            Me.btnApprove.Visible = False
            Me.btnReject.Visible = False
            Me.btnRefuse.Visible = False
            Me.btnEntries.Visible = False
            Me.btnOK.Visible = False
            Me.btnCANCEL.Visible = True
            If (VoucherID.Trim.Length > 0) Then
                Me.btnVoucher.Visible = True
            End If
            'check co can voucher hay ko
            v_strClause = "select VOUCHERID from tltx where tltxcd='" & Me.mskTransCode.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                VoucherID = ""
            Else : VoucherID = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString
            End If
            If (VoucherID.Trim.Length > 0) Then
                Me.btnVoucher.Visible = True
            End If

            'Náº¿u hiá»ƒn thá»‹ tá»« mÃ n hÃ¬nh tra cá»©u giao dá»‹ch thÃ¬ áº©n chá»‰ hiá»ƒn thá»‹ nÃºt cancel
            If Not Me.IsHistoryView Then
                If v_strTXSTATUS = TransactStatus.Pending Then
                    'Cho phÃ©p sá»­a náº¿u giao dá»‹ch á»Ÿ tráº¡ng thÃ¡i Pending 
                    'thÃ¬ hiá»ƒn thá»‹ phÃ­m Adjust/Reject/Refuse/Approve Ä‘á»ƒ hiá»‡u chá»‰nh láº¡i giao dá»‹ch
                    'Me.btnAdjust.Visible = True
                    Me.btnApprove.Visible = True
                    Me.btnReject.Visible = True
                    Me.btnRefuse.Visible = True
                ElseIf v_strTXSTATUS = TransactStatus.Rejected Or v_strDELTD = "Y" Then
                    'Cho phÃ©p sá»­a náº¿u giao dá»‹ch á»Ÿ tráº¡ng thÃ¡i Rejected 
                    'thÃ¬ hiá»ƒn thá»‹ phÃ­m Adjust Ä‘á»ƒ hiá»‡u chá»‰nh láº¡i giao dá»‹ch
                    'Khong cho sua khi view nua
                    'Me.btnAdjust.Visible = True
                End If

            End If
            'Náº¿u lÃ  giao dá»‹ch cÃ³ chá»©ng tá»« hoáº·c dá»¯ liá»‡u MITRAN thÃ¬ hiá»ƒn thá»‹ Entries
            If (Not mv_arrObjIEFMIS Is Nothing) Or (Not mv_arrObjVAT Is Nothing) Then
                Me.btnEntries.Visible = True
                Me.btnEntries.Enabled = True
            End If
            'QuÃ©t láº¥y thÃªm thÃ´ng tin cá»§a Ä‘á»‘i tÆ°á»£ng lookup
            GetOtherViewInfo()
            ShowFEEDetails(mskTransCode.Text)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub DisplayScreen()
        Dim v_intTmpIndex, v_intIndex, v_intCount, v_intPosition, v_intTop, v_intLeft, v_intWidth, v_intLastTop As Integer
        Dim v_lblCaption As Label, v_mskData As FlexMaskEditBox, v_txtData As TextBox, v_cboData As ComboBox, v_lblDesc As Label, v_dtgPostmap As GridEx, v_rtbData As RichTextBox
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL, v_strObjMsg, v_strTmp, v_strDefaultTmp, v_strTmp1 As String

        Try
            mv_blnOnDisplayScreen = True
            'XoÃ¡ mÃ n hÃ¬nh cÅ©
            Me.pnTransDetail.Controls.Clear()
            If mv_blnAcctEntry = True Then
                btnEntries.Visible = True
            Else
                btnEntries.Visible = False
            End If
            btnAdjust.Visible = False
            btnReject.Visible = False
            btnApprove.Visible = False
            btnRefuse.Visible = False
            btnVoucher.Visible = False
            mv_strListOfTXFeeCode = String.Empty
            'Táº¡o mÃ n hÃ¬nh má»›i
            v_intCount = mv_arrObjFields.GetLength(0)
            If v_intCount > 0 Then
                Me.pnTransDetail.Visible = True
                Me.pnTransDetail.Top = PANEL_TOP

                'Hiá»ƒn thá»‹ Ã´ nháº­p giÃ¡ trá»‹ ngÃ y háº¡ch toÃ¡n
                v_lblCaption = New Label
                v_lblCaption.Text = mv_ResourceManager.GetString("POSTING_DATE_CAPTION")
                v_lblCaption.RightToLeft = RightToLeft.Yes
                v_lblCaption.Width = LBLCAPTION_WIDTH
                v_lblCaption.ForeColor = System.Drawing.Color.Red
                v_lblCaption.Name = PREFIXED_LBLCAP & "BUSDATE"
                'v_lblCaption.Visible = True
                v_lblCaption.Visible = mv_isBackDate

                v_mskData = New FlexMaskEditBox
                v_mskData.FieldType = FlexMaskEditBox._FieldType.DATE_
                v_mskData.Name = PREFIXED_MSKDATA & "BUSDATE"
                v_mskData.MaxLength = 10
                v_mskData.Width = 10 * WIDTH_PERCHAR
                v_mskData.Mask = "99/99/9999"
                v_mskData.PromptChar = "_"
                v_mskData.MaskCharInclude = True
                'v_mskData.Visible = True
                v_mskData.Visible = mv_isBackDate
                If Me.PostingDate.Length > 0 Then
                    v_mskData.Text = Me.PostingDate
                Else
                    v_mskData.Text = mv_strTxBusDate
                End If

                v_mskData.Enabled = mv_isEnableBackDate

                v_lblCaption.Top = CONTROL_TOP
                v_lblCaption.Left = CONTROL_LEFT
                v_mskData.Top = v_lblCaption.Top
                v_mskData.Left = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP

                Me.pnTransDetail.Controls.Add(v_lblCaption)
                Me.pnTransDetail.Controls.Add(v_mskData)

                v_intPosition = IIf(mv_isBackDate, 1, 0)    'CÃ³ hiá»‡n Ã´ háº¡ch toÃ¡n hay khÃ´ng
                'v_intPosition = 1

                'Hiá»ƒn thá»‹ ná»™i dung cÃ¡c trÆ°á»?ng giao dá»‹ch
                Dim v_intRow As Integer = 1
                Dim v_lngAddLength As Long = 0
                For v_intIndex = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_lblCaption = New Label
                        v_lblDesc = New Label
                        v_lblCaption.Visible = mv_arrObjFields(v_intIndex).Visible
                        v_lblDesc.Visible = False

                        v_intTop = CONTROL_TOP + v_intPosition * (CONTROL_HEIGHT + CONTROL_GAP) + v_lngAddLength
                        If Trim(mv_arrObjFields(v_intIndex).ControlType) = "R" Then
                            v_intRow = mv_arrObjFields(v_intIndex).FieldRow
                            v_lngAddLength += ((v_intRow - 1) * (CONTROL_HEIGHT - 10))
                        Else
                            v_intRow = 1
                        End If
                        v_lblCaption.Top = v_intTop
                        v_lblCaption.Left = CONTROL_LEFT
                        v_lblCaption.Width = LBLCAPTION_WIDTH
                        If mv_arrObjFields(v_intIndex).Mandatory Then
                            v_lblCaption.ForeColor = System.Drawing.Color.Red
                        Else
                            v_lblCaption.ForeColor = System.Drawing.Color.Blue
                        End If
                        v_lblCaption.Tag = mv_arrObjFields(v_intIndex).ValidTag
                        v_lblCaption.Text = mv_arrObjFields(v_intIndex).Caption
                        v_lblCaption.RightToLeft = RightToLeft.Yes
                        v_lblCaption.Name = PREFIXED_LBLCAP & Trim(mv_arrObjFields(v_intIndex).FieldName)

                        'Format hiển thị
                        If Trim(mv_arrObjFields(v_intIndex).DataType) = "N" Then
                            If Trim(mv_arrObjFields(v_intIndex).FldRound).Length > 0 Then
                                If IsNumeric(mv_arrObjFields(v_intIndex).FldRound) _
                                    And IsNumeric(mv_arrObjFields(v_intIndex).FieldValue) Then
                                    mv_arrObjFields(v_intIndex).FieldValue = gf_RoundNumber(mv_arrObjFields(v_intIndex).FieldValue, mv_arrObjFields(v_intIndex).FldRound)
                                End If

                                If IsNumeric(mv_arrObjFields(v_intIndex).FldRound) _
                                    And IsNumeric(mv_arrObjFields(v_intIndex).DefaultValue) Then
                                    mv_arrObjFields(v_intIndex).DefaultValue = gf_RoundNumber(mv_arrObjFields(v_intIndex).DefaultValue, mv_arrObjFields(v_intIndex).FldRound)
                                End If
                            End If
                        End If

                        Select Case Trim(mv_arrObjFields(v_intIndex).ControlType)
                            Case "T" 'TextBox
                                'Náº¿u khÃ´ng cÃ³ Masked thÃ¬ sá»­ dá»¥ng Textbox thÃ´ng thÆ°á»?ng Ä‘á»ƒ nháº­p Ä‘Æ°á»£c font Unicode
                                v_txtData = New TextBox
                                v_txtData.Visible = mv_arrObjFields(v_intIndex).Visible
                                v_txtData.Top = v_intTop
                                v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                v_txtData.Left = v_intLeft
                                v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                If ALL_WIDTH < v_intLeft + v_intWidth Then
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                v_txtData.MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                                v_txtData.Width = v_intWidth * 2 / 3
                                v_txtData.Tag = v_intIndex  'LÆ°u láº¡i chá»‰ sá»‘ cá»§a máº£ng Ä‘á»ƒ láº¥y cÃ¡c thÃ´ng tin tÆ°Æ¡ng á»©ng Ä‘áº¿n trÆ°á»?ng
                                v_txtData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                v_txtData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                    v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                    If mv_arrObjFields(v_intIndex).DataType = "N" Then
                                        FormatNumericTextbox(CType(v_txtData, TextBox))
                                    End If
                                Else
                                    If mv_arrObjFields(v_intIndex).DataType = "N" Then
                                        v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                        FormatNumericTextbox(CType(v_txtData, TextBox))
                                    Else
                                        v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                    End If
                                End If
                                'ThanhNM 27/02/2012
                                'Tu dong fill so tai khoan LK
                                'Them viewmode, excute mode
                                If mv_arrObjFields(v_intIndex).Enabled = True Then
                                    Dim v_strColumnName As String
                                    Dim v_strCustodyCd As String

                                    v_strColumnName = Trim(mv_arrObjFields(v_intIndex).ColumnName)
                                    If Len(v_txtData.Text) < 10 And (v_strColumnName = "CUSTODYCD" Or v_strColumnName = "SCUSTODYCD" Or v_strColumnName = "BCUSTODYCD") Then

                                        v_strCustodyCd = gc_COMPANY_CODE
                                        'Fill to MaskEditbox
                                        v_txtData.Text = Trim(v_strCustodyCd)
                                    End If
                                End If

                                AddHandler v_txtData.GotFocus, AddressOf mskData_GotFocus
                                AddHandler v_txtData.Validating, AddressOf mskData_Validating
                                AddHandler v_txtData.Validated, AddressOf mskData_Validated

                                v_lblDesc.Top = v_intTop
                                v_lblDesc.AutoSize = True
                                v_intLeft = v_txtData.Left + v_txtData.Width + CONTROL_GAP
                                If v_intLeft >= ALL_WIDTH Then
                                    v_intWidth = 0
                                Else
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If

                                If Trim(mv_arrObjFields(v_intIndex).DataType) = "P" Then
                                    CType(v_txtData, TextBox).PasswordChar = "*"
                                End If
                            Case "R" 'RichTextBox
                                'Náº¿u khÃ´ng cÃ³ Masked thÃ¬ sá»­ dá»¥ng Textbox thÃ´ng thÆ°á»?ng Ä‘á»ƒ nháº­p Ä‘Æ°á»£c font Unicode
                                v_rtbData = New RichTextBox
                                v_rtbData.Visible = mv_arrObjFields(v_intIndex).Visible
                                v_rtbData.Top = v_intTop
                                v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                v_rtbData.Left = v_intLeft
                                v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                If ALL_WIDTH < v_intLeft + v_intWidth Then
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                v_rtbData.MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                                v_rtbData.Width = v_intWidth * 2 / 3
                                v_rtbData.Tag = v_intIndex  'LÆ°u láº¡i chá»‰ sá»‘ cá»§a máº£ng Ä‘á»ƒ láº¥y cÃ¡c thÃ´ng tin tÆ°Æ¡ng á»©ng Ä‘áº¿n trÆ°á»?ng
                                v_rtbData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                v_rtbData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                v_rtbData.Height = CONTROL_HEIGHT + (CONTROL_HEIGHT - 10) * (v_intRow - 1)
                                v_rtbData.Multiline = True
                                v_rtbData.BorderStyle = BorderStyle.Fixed3D

                                If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                    v_rtbData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                Else
                                    v_rtbData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                End If
                                'ThanhNM 27/02/2012
                                'Tu dong fill so tai khoan LK
                                'Them viewmode, excute mode
                                'If mv_arrObjFields(v_intIndex).Enabled = True Then
                                '    Dim v_strColumnName As String
                                '    Dim v_strCustodyCd As String

                                '    v_strColumnName = Trim(mv_arrObjFields(v_intIndex).ColumnName)
                                '    If Len(v_txtData.Text) < 10 And v_strColumnName = "CUSTODYCD" Then

                                '        v_strCustodyCd = gc_COMPANY_CODE
                                '        'Fill to MaskEditbox
                                '        v_txtData.Text = Trim(v_strCustodyCd)
                                '    End If
                                'End If

                                AddHandler v_rtbData.GotFocus, AddressOf rtbData_GotFocus
                                AddHandler v_rtbData.Validating, AddressOf rtbData_Validating
                                AddHandler v_rtbData.Validated, AddressOf rtbData_Validated

                                v_lblDesc.Top = v_intTop
                                v_lblDesc.AutoSize = True
                                v_intLeft = v_rtbData.Left + v_rtbData.Width + CONTROL_GAP
                                If v_intLeft >= ALL_WIDTH Then
                                    v_intWidth = 0
                                Else
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If


                            Case "M" 'FlexMaskedEdit
                                'Náº¿u cÃ³ Mask vÃ  khÃ´ng pháº£i trÆ°á»?ng sá»‘ thÃ¬ sá»­ dá»¥ng FlexMaskedEdit
                                v_mskData = New FlexMaskEditBox
                                v_mskData.Visible = mv_arrObjFields(v_intIndex).Visible
                                v_mskData.Top = v_intTop
                                v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                v_mskData.Left = v_intLeft
                                v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                If ALL_WIDTH < v_intLeft + v_intWidth Then
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                v_mskData.Width = v_intWidth * 2 / 3
                                v_mskData.Tag = v_intIndex  'LÆ°u láº¡i chá»‰ sá»‘ cá»§a máº£ng Ä‘á»ƒ láº¥y cÃ¡c thÃ´ng tin tÆ°Æ¡ng á»©ng Ä‘áº¿n trÆ°á»?ng
                                v_mskData.PromptChar = "_"
                                'v_mskData.SetFormatString = "C"

                                If Trim(mv_arrObjFields(v_intIndex).DataType) = "N" Then
                                    v_mskData.MaskCharInclude = False
                                    v_mskData.FieldType = FlexMaskEditBox._FieldType.NUMERIC
                                ElseIf Trim(mv_arrObjFields(v_intIndex).DataType) = "C" Then
                                    v_mskData.MaskCharInclude = False
                                    v_mskData.FieldType = FlexMaskEditBox._FieldType.ALFA
                                Else
                                    v_mskData.MaskCharInclude = True
                                    v_mskData.FieldType = FlexMaskEditBox._FieldType.DATE_
                                End If
                                v_mskData.Mask = mv_arrObjFields(v_intIndex).InputMask
                                v_mskData.MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                                v_mskData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                v_mskData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)

                                If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                    v_mskData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                Else
                                    If Len(Trim(mv_arrObjFields(v_intIndex).DefaultValue)) > 0 Then
                                        v_mskData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                    Else
                                        If Trim(mv_arrObjFields(v_intIndex).DataType) = "N" Then
                                            v_mskData.Text = "0"
                                        ElseIf Trim(mv_arrObjFields(v_intIndex).DataType) = "D" Then
                                            v_mskData.Text = mv_strTxBusDate
                                        End If
                                    End If
                                End If
                                'ThanhNM 27/02/2012
                                'Tu dong fill so tai khoan LK
                                'Them viewmode, excute mode
                                If mv_arrObjFields(v_intIndex).Enabled = True Then
                                    Dim v_strColumnName As String
                                    Dim v_strCustodyCd As String
                                    v_strColumnName = Trim(mv_arrObjFields(v_intIndex).ColumnName)
                                    If Len(v_mskData.Text) < 10 And (v_strColumnName = "CUSTODYCD" Or v_strColumnName = "SCUSTODYCD" Or v_strColumnName = "BCUSTODYCD") Then

                                        v_strCustodyCd = gc_COMPANY_CODE
                                        'Fill to MaskEditbox
                                        v_mskData.Text = Trim(v_strCustodyCd)
                                    End If
                                End If

                                AddHandler v_mskData.GotFocus, AddressOf mskData_GotFocus
                                AddHandler v_mskData.Validating, AddressOf mskData_Validating
                                AddHandler v_mskData.Validated, AddressOf mskData_Validated

                                v_lblDesc.Top = v_intTop
                                v_lblDesc.AutoSize = True
                                v_intLeft = v_mskData.Left + v_mskData.Width + CONTROL_GAP
                                If v_intLeft >= ALL_WIDTH Then
                                    v_intWidth = 0
                                Else
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                            Case "C" 'ComboBox
                                'Nếu là  combo phải náº¡p dá»¯ liá»‡u cho ComBo theo LookUpList
                                v_cboData = New ComboBoxEx
                                v_cboData.Visible = mv_arrObjFields(v_intIndex).Visible
                                v_cboData.Top = v_intTop
                                v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                v_cboData.Left = v_intLeft
                                v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                If ALL_WIDTH < v_intLeft + v_intWidth Then
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                v_cboData.Width = v_intWidth
                                v_cboData.Tag = v_intIndex  'LÆ°u láº¡i chá»‰ sá»‘ cá»§a máº£ng Ä‘á»ƒ láº¥y cÃ¡c thÃ´ng tin tÆ°Æ¡ng á»©ng Ä‘áº¿n trÆ°á»?ng
                                v_cboData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                v_cboData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                v_cboData.DropDownStyle = ComboBoxStyle.DropDown
                                'AddHandler v_cboData.SelectedIndexChanged, AddressOf cboData_SelectedIndexChanged
                                AddHandler v_cboData.Validating, AddressOf v_cboData_Validating
                                AddHandler v_cboData.SelectedValueChanged, AddressOf cboData_SelectedIndexChanged
                                v_lblDesc.Top = v_intTop
                                v_lblDesc.AutoSize = True
                                v_intLeft = v_cboData.Left + v_cboData.Width + CONTROL_GAP
                                If v_intLeft >= ALL_WIDTH Then
                                    v_intWidth = 0
                                Else
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                'Nap du lieu cho ComboBox
                                If mv_arrObjFields(v_intIndex).LookupList.Length > 0 Then
                                    v_strCmdSQL = mv_arrObjFields(v_intIndex).LookupList
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                    v_ws.Message(v_strObjMsg)
                                    FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                ElseIf mv_arrObjFields(v_intIndex).TagList.Length > 0 Then
                                    v_strTmp = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField)
                                    v_strDefaultTmp = GetDefaultValueByName(mv_arrObjFields(v_intIndex).TagField)
                                    v_strTmp1 = GetDefaultValueByName(mv_arrObjFields(v_intIndex).TagValue)
                                    If v_strTmp = String.Empty Then
                                        v_strTmp = v_strDefaultTmp
                                    End If
                                    If v_strTmp.Length > 0 Then
                                        v_strCmdSQL = mv_arrObjFields(v_intIndex).TagList.Replace("<$TAGFIELD>", v_strTmp)
                                        v_strCmdSQL = v_strCmdSQL.Replace("<$TAGVALUE>", v_strTmp1)
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                        v_ws.Message(v_strObjMsg)
                                        FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                    End If
                                End If
                        End Select
                        v_lblDesc.Tag = mv_arrObjFields(v_intIndex).LookupCheck
                        v_lblDesc.Left = v_intLeft
                        ' VinhLD edit for auto resize
                        v_lblDesc.Width = BASED_PANEL_WIDTH * mv_dblWindowSizeRatio_X - -v_intLeft - CONTROL_GAP
                        v_lblDesc.Text = ""
                        v_lblDesc.Name = PREFIXED_LBLDESC & Trim(mv_arrObjFields(v_intIndex).FieldName)

                        Me.pnTransDetail.Controls.Add(v_lblCaption)
                        Me.pnTransDetail.Controls.Add(v_lblDesc)
                        mv_arrObjFields(v_intIndex).LabelIndex = Me.pnTransDetail.Controls.IndexOf(v_lblDesc)
                        Select Case Trim(mv_arrObjFields(v_intIndex).ControlType)
                            Case "T"
                                Me.pnTransDetail.Controls.Add(v_txtData)
                                If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_txtData)).BackColor = System.Drawing.Color.GreenYellow
                                ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_txtData)).BackColor = System.Drawing.Color.Khaki
                                End If
                                mv_arrObjFields(v_intIndex).ControlIndex = Me.pnTransDetail.Controls.IndexOf(v_txtData)
                            Case "R"
                                Me.pnTransDetail.Controls.Add(v_rtbData)
                                If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_rtbData)).BackColor = System.Drawing.Color.GreenYellow
                                ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_rtbData)).BackColor = System.Drawing.Color.Khaki
                                End If
                                mv_arrObjFields(v_intIndex).ControlIndex = Me.pnTransDetail.Controls.IndexOf(v_rtbData)
                            Case "M"
                                Me.pnTransDetail.Controls.Add(v_mskData)
                                If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_mskData)).BackColor = System.Drawing.Color.GreenYellow
                                ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                    Me.pnTransDetail.Controls(Me.pnTransDetail.Controls.IndexOf(v_mskData)).BackColor = System.Drawing.Color.Khaki
                                End If
                                mv_arrObjFields(v_intIndex).ControlIndex = Me.pnTransDetail.Controls.IndexOf(v_mskData)
                            Case "C"
                                Me.pnTransDetail.Controls.Add(v_cboData)
                                mv_arrObjFields(v_intIndex).ControlIndex = Me.pnTransDetail.Controls.IndexOf(v_cboData)
                                'Ä?áº·t giÃ¡ trá»‹ máº·c Ä‘á»‹nh cho Combo vá»«a Ä‘Æ°á»£c Add vÃ o
                                If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                    CType(Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex), ComboBoxEx).SelectedValue = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                Else
                                    CType(Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex), ComboBoxEx).SelectedValue = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                End If
                        End Select

                        'TÃ­nh toÃ¡n vá»‹ trÃ­ hiá»ƒn thá»‹ náº¿u control lÃ  visible
                        If mv_arrObjFields(v_intIndex).Visible Then
                            v_intPosition = v_intPosition + 1
                            v_intLastTop = v_intTop
                        End If

                    End If
                Next

                Me.pnTransDetail.Width = mv_dblWindowSizeRatio_X * BASED_PANEL_WIDTH
                If v_intLastTop + CONTROL_HEIGHT * 2 + v_lngAddLength < PANEL_TOP + PANEL_HEIGHT * mv_dblWindowSizeRatio_Y Then
                    'Náº¿u sá»‘ lÆ°á»£ng control hiá»ƒn thá»‹ Ã­t hÆ¡n Ä‘á»™ cao hiá»‡n táº¡i cá»§a PANEL
                    Me.pnTransDetail.Height = v_intLastTop + CONTROL_HEIGHT * 2 + v_lngAddLength
                Else
                    'Náº¿u nhiá»?u hÆ¡n Ä‘áº·t máº·c Ä‘á»‹nh
                    Me.pnTransDetail.Height = PANEL_HEIGHT * mv_dblWindowSizeRatio_Y
                End If

                If Not mv_arrObjAccounts Is Nothing Then
                    'Hiá»‡n bá»™ Ä‘á»‹nh khoáº£n
                    RetrievePostmap()
                Else
                    'KhÃ´ng cÃ³ Ä‘á»‹nh khoáº£n
                    Me.tabTransact.Visible = False
                    Me.lblHelper.Top = Me.pnTransDetail.Top + Me.pnTransDetail.Height + TABS_TOP + FIX_TABS_TOP
                    Me.btnOK.Top = Me.lblHelper.Top
                    Me.btnVoucher.Top = Me.lblHelper.Top
                    Me.btnCANCEL.Top = Me.lblHelper.Top
                    Me.btnAdjust.Top = Me.lblHelper.Top
                    Me.btnEntries.Top = Me.lblHelper.Top
                    Me.btnReject.Top = Me.lblHelper.Top
                    Me.btnApprove.Top = Me.lblHelper.Top
                    Me.btnRefuse.Top = Me.lblHelper.Top
                    'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh

                    Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_HEIGHT + TABS_TOP + FIX_TABS_TOP
                    If Me.stbMain.Visible = True Then
                        Me.Height = Me.Height + 20
                        Me.stbMain.Text = mv_ResourceManager.GetString("STATUSBAR_ACCINFO")
                    End If
                End If

                If Not mv_arrObjVAT Is Nothing Then
                    'Hiá»‡n VAT voucher
                    RetrieveVATVoucher()
                Else
                    'KhÃ´ng cÃ³ Ä‘á»‹nh khoáº£n
                    Me.tabVATVoucher.Visible = False
                End If
            Else
                'KhÃ´ng cÃ³ trÆ°á»?ng nÃ o cá»§a giao dá»‹ch
                Me.tabTransact.Visible = False
                Me.pnTransDetail.Visible = False
                Me.lblHelper.Top = PANEL_TOP
                Me.btnOK.Top = Me.lblHelper.Top
                Me.btnCANCEL.Top = Me.lblHelper.Top
                Me.btnAdjust.Top = Me.lblHelper.Top
                Me.btnEntries.Top = Me.lblHelper.Top
                Me.btnReject.Top = Me.lblHelper.Top
                Me.btnApprove.Top = Me.lblHelper.Top
                Me.btnRefuse.Top = Me.lblHelper.Top
                'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh
                Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_HEIGHT + TABS_TOP + FIX_TABS_TOP
                If Me.stbMain.Visible = True Then
                    Me.Height = Me.Height + 20
                    Me.stbMain.Text = mv_ResourceManager.GetString("STATUSBAR_ACCINFO")
                End If
            End If
            mv_blnOnDisplayScreen = False
            'Them su kien Validating cho truong ngay chung tu
            Dim v_ctl2 As Control
            For Each v_ctl2 In Me.pnTransDetail.Controls
                If v_ctl2.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                    AddHandler Me.pnTransDetail.Controls(1).Validating, AddressOf v_ctl_Validating
                End If
            Next
            'End
            ' VinhLD add for auto resize
            ' Get the Width and Height of the form  
            Dim frm_width As Integer = Me.Width
            Dim frm_height As Integer = Me.Height

            'Get the Width and Height (resolution) of the screen  
            Dim src As System.Windows.Forms.Screen = System.Windows.Forms.Screen.PrimaryScreen
            Dim src_height As Integer = src.Bounds.Height
            Dim src_width As Integer = src.Bounds.Width

            'Set the left and top property to move the form to center of the screen  
            Me.Left = (src_width - frm_width) / 2
            Me.Top = (src_height - frm_height) / 2
            'end of VinhLD add for auto resize
        Catch ex As Exception
            mv_blnOnDisplayScreen = False
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub DisplayButton()
        Dim v_btn() As Button
        Dim i As Integer
        Dim v_intLeft As Integer
        ReDim v_btn(7)
        v_btn(0) = btnCANCEL
        v_btn(1) = btnOK
        v_btn(2) = btnAdjust
        v_btn(3) = btnEntries
        v_btn(4) = btnReject
        v_btn(5) = btnApprove
        v_btn(6) = btnRefuse
        v_btn(7) = btnVoucher

        v_intLeft = Me.pnTransDetail.Left + Me.pnTransDetail.Width - BTN_WIDTH
        For i = 0 To 7
            If v_btn(i).Visible = True Then
                If v_btn(i) Is btnApprove Then
                    v_btn(i).Left = Me.pnTransDetail.Left
                Else
                    v_btn(i).Left = v_intLeft
                    v_intLeft = v_intLeft - (BTN_WIDTH + BTN_GAP)
                End If
            End If
        Next

    End Sub

    Private Sub ShowUserViewInfo()
        Dim v_ctl As Control
        Dim v_intIndex As Integer
        Dim v_strSQLCMD, v_strFULLDATA As String
        Dim strFLDNAME As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
        Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
        Dim v_strModule, v_strFldSource, v_strFldDesc As String
        Dim v_btlOK As Boolean = False
        Dim i As Integer

        For v_intIndex = 0 To mv_arrObjFields.Length - 1
            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                If mv_arrObjFields(v_intIndex).PrintInfo <> "##########" Then
                    mv_arrObjFields(v_intIndex).Visible = True
                End If
            End If
        Next
    End Sub

    Private Sub GetOtherViewInfo()
        Dim v_ctl As Control, v_intIndex As Integer
        Dim v_strSQLCMD, v_strFULLDATA, strFLDNAME As String
        Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
        Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
        Dim v_strModule, v_strFldSource, v_strFldDesc As String
        Dim v_btlOK As Boolean = False
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            For Each v_ctl In Me.pnTransDetail.Controls
                If TypeOf (v_ctl) Is TextBox Or TypeOf (v_ctl) Is FlexMaskEditBox Or TypeOf (v_ctl) Is RichTextBox Then
                    If InStr(v_ctl.Name, PREFIXED_MSKDATA) > 0 And Not (CType(v_ctl, Control).Tag Is Nothing) Then
                        v_intIndex = CType(v_ctl, Control).Tag
                        If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                            'Hien thi thong tin chung cua tai khoan
                            If mv_arrObjFields(v_intIndex).PrintInfo = "03CUSTNAME" Or mv_arrObjFields(v_intIndex).PrintInfo = "03ADDRESS#" Or mv_arrObjFields(v_intIndex).PrintInfo = "03LICENSE#" Then
                                mv_arrObjFields(v_intIndex).Visible = True
                            End If
                            'Hiá»ƒn thá»‹ thÃªm thong tin cho cÃ¡c trÆ°á»›ng lookup
                            If mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                                v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                                If v_strSQLCMD.Length > 0 Then
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                    v_ws.Message(v_strObjMsg)
                                    'LÆ°u trá»¯ danh sÃ¡ch tÃ¬m kiáº¿m tráº£ vá»?
                                    v_strFULLDATA = v_strObjMsg
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    'Kiá»ƒm tra xem giÃ¡ trá»‹ co há»£p lá»‡ khÃ´ng
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                                    v_strValue = Trim(.InnerText.ToString)
                                                    If v_ctl.Text = v_strValue Then
                                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                            With v_nodeList.Item(i).ChildNodes(k)
                                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                                    v_btlOK = True
                                                                    Exit For
                                                                End If
                                                            End With
                                                        Next
                                                        Dim ctl As Control
                                                        If v_btlOK = True Then
                                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                                            ctl.Top = v_ctl.Top
                                                            'ctl.Left = v_ctl.Left + v_ctl.Width + CONTROL_GAP
                                                            ctl.Text = v_strDisplay
                                                            ctl.Visible = v_ctl.Visible
                                                            Exit For
                                                        End If
                                                        v_btlOK = False
                                                    End If
                                                End If
                                            End With
                                        Next
                                        If v_btlOK = True Then
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        End If

                    End If
                ElseIf TypeOf (v_ctl) Is ComboBox Or TypeOf (v_ctl) Is ComboBoxEx Then
                    Dim v_strFULLNAME As String
                    Dim i, j As Integer
                    If InStr(v_ctl.Name, PREFIXED_MSKDATA) > 0 And Not (CType(v_ctl, Control).Tag Is Nothing) Then
                        v_intIndex = CType(v_ctl, Control).Tag
                        If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                            'Hiá»ƒn thá»‹ thÃ´ng tin chá»§ tÃ i khoáº£n
                            'If mv_arrObjFields(v_intIndex).LookUp = "Y" And mv_arrObjFields(v_intIndex).ControlType <> "C" Then
                            If mv_arrObjFields(v_intIndex).LookUp = "Y" And mv_arrObjFields(v_intIndex).ColumnName = "CODEID" Then
                                v_strSQLCMD = "SELECT FULLNAME FROM ISSUERS ISS,SBSECURITIES SB WHERE ISS.ISSUERID=SB.ISSUERID AND SB.CODEID='" & CType(v_ctl, ComboBoxEx).SelectedValue & "'"
                                'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                v_ws.Message(v_strObjMsg)
                                'LÆ°u trá»¯ danh sÃ¡ch tÃ¬m kiáº¿m tráº£ vá»?
                                v_strFULLDATA = v_strObjMsg
                                v_xmlDocument.LoadXml(v_strFULLDATA)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                'Kiá»ƒm tra xem giÃ¡ trá»‹ co há»£p lá»‡ khÃ´ng
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                For i = 0 To v_nodeList.Count - 1
                                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strValue = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "FULLNAME"
                                                    v_strFULLNAME = v_strValue
                                            End Select
                                        End With
                                    Next
                                Next
                                'If v_strFULLNAME.Trim.Length > 0 Then
                                Dim ctl As Control
                                ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                ctl.Top = v_ctl.Top
                                ctl.Text = v_strFULLNAME
                                ctl.Visible = True
                                'End If
                            End If
                        End If

                    End If
                End If
            Next

        Catch ex As Exception
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub
    Private Function BuildAMTEXP(ByVal pv_xmlDocument As Xml.XmlDocument, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex As Long, v_ctl As Control

            Dim v_strFEEAMT, v_strVATAMT As String
            If Not pv_xmlDocument.DocumentElement Is Nothing Then
                v_strFEEAMT = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).Value.ToString
            Else
                v_strFEEAMT = 0
            End If
            If Not pv_xmlDocument.DocumentElement Is Nothing Then
                v_strVATAMT = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).Value.ToString
            Else
                v_strVATAMT = 0
            End If
            If Not IsNumeric(v_strFEEAMT) Then v_strFEEAMT = 0
            If Not IsNumeric(v_strVATAMT) Then v_strVATAMT = 0

            v_strEvaluator = vbNullString
            v_lngIndex = 1
            If Mid$(strAMTEXP, 1, 1) = "@" Then
                v_strEvaluator = Mid$(strAMTEXP, 2)
            Else
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
                            v_strEvaluator = v_strEvaluator & Mid(v_strElemenent, 1, 1)
                        Case "@1"
                            'Operand
                            v_strEvaluator = v_strEvaluator & "1"
                        Case "MD"
                            v_strEvaluator = v_strEvaluator & "M"
                        Case "BD"
                            v_strEvaluator = Me.BusDate
                        
                        Case Else
                            'Operator
                            For Each v_ctl In Me.pnTransDetail.Controls
                                'If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 And TypeOf (v_ctl) Is FlexMaskEditBox Then
                                If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 Then
                                    If TypeOf (v_ctl) Is ComboBoxEx Then
                                        v_strValue = CType(v_ctl, ComboBoxEx).SelectedValue
                                    Else
                                        v_strValue = Replace(v_ctl.Text, ",", "")
                                    End If
                                    If v_strValue Is Nothing Or Len(v_strValue) = 0 Then
                                        v_strValue = "0"
                                    End If
                                    Exit For
                                End If
                            Next
                            v_strEvaluator = v_strEvaluator & v_strValue
                    End Select
                    v_lngIndex = v_lngIndex + 2
                End While
            End If


            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function

    Private Function BuildFUNCPARA(ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex, v_lngControlIndex As Long, v_ctl As Control

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "##"
                        'Dau phan cach: giu nguyen
                        v_strEvaluator = v_strEvaluator & ","
                    Case "BD"   'Busdate
                        For Each v_ctl In Me.pnTransDetail.Controls
                            If v_ctl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                                v_strEvaluator = v_strEvaluator & "TO_DATE('" & v_ctl.Text & "','" & gc_FORMAT_DATE & "')"
                                Exit For
                            End If
                        Next
                    Case "TD"   'transaction date
                        v_strEvaluator = v_strEvaluator & "TO_DATE('" & Me.mv_strBusDate & "','" & gc_FORMAT_DATE & "')"
                    Case "BR" 'BranchID'
                        v_strEvaluator = v_strEvaluator & "'" & Me.BranchId & "'"
                    Case "TL"
                        v_strEvaluator = v_strEvaluator & "'" & mskTransCode.Text & "'"
                    Case "NU"
                        v_strEvaluator = v_strEvaluator & "''"
                    Case Else
                        If v_strElemenent.StartsWith("@") Then
                            v_strValue = v_strElemenent.Substring(1)
                        Else
                            'Operator
                            For Each v_ctl In Me.pnTransDetail.Controls
                                If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 Then
                                    If TypeOf (v_ctl) Is ComboBoxEx Then
                                        If CType(v_ctl, ComboBoxEx).SelectedValue Is Nothing Then
                                            v_strValue = ""
                                        Else
                                            Dim v_strText As String = CType(v_ctl, ComboBoxEx).Text
                                            If CType(v_ctl, ComboBoxEx).SelectedValue = "" Then
                                                CType(v_ctl, ComboBoxEx).SelectedIndex = CType(v_ctl, ComboBoxEx).FindStringExact(v_strText, -1)
                                            End If
                                            v_strValue = CType(v_ctl, ComboBoxEx).SelectedValue
                                        End If
                                    Else
                                        v_strValue = v_ctl.Text
                                    End If
                                    'xu ly neu la ky tu
                                    v_lngControlIndex = CType(v_ctl, Control).Tag
                                    If Not mv_arrObjFields(v_lngControlIndex) Is Nothing Then
                                        If mv_arrObjFields(v_lngControlIndex).DataType = "C" Then
                                            v_strValue = "'" & v_strValue.Replace("'", "''") & "'"
                                        ElseIf mv_arrObjFields(v_lngControlIndex).DataType = "D" Then
                                            v_strValue = "'" & v_strValue.Replace("'", "''") & "'"
                                        ElseIf mv_arrObjFields(v_lngControlIndex).DataType = "N" Then
                                            v_strValue = CDbl(v_strValue).ToString
                                        End If
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                        v_strEvaluator = v_strEvaluator & v_strValue
                End Select
                v_lngIndex = v_lngIndex + 2
            End While

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function

    Private Function BuildCONCAT(ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex As Long, v_ctl As Control

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "&&"
                        'Operand
                        'v_strEvaluator = v_strEvaluator & Mid(v_strElemenent, 1, 1)
                    Case Else
                        'Operator
                        For Each v_ctl In Me.pnTransDetail.Controls
                            'If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 And TypeOf (v_ctl) Is FlexMaskEditBox Then
                            If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 Then
                                If TypeOf (v_ctl) Is ComboBoxEx Then
                                    Dim v_strText As String = CType(v_ctl, ComboBoxEx).Text
                                    If CType(v_ctl, ComboBoxEx).SelectedValue = "" Then
                                        CType(v_ctl, ComboBoxEx).SelectedIndex = CType(v_ctl, ComboBoxEx).FindStringExact(v_strText, -1)
                                    End If
                                    v_strValue = CType(v_ctl, ComboBoxEx).SelectedValue
                                Else
                                    v_strValue = v_ctl.Text
                                End If
                                Exit For
                            End If
                        Next
                        v_strEvaluator = v_strEvaluator & v_strValue
                End Select
                v_lngIndex = v_lngIndex + 2
            End While

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function

    'Verify rules cá»§a giao dá»‹ch, tráº£ vá»? Ä‘iá»‡n giao dá»‹ch Ä‘Ã£ Ä‘Æ°á»£c táº¡o
    Private Function VerifyRules(ByRef v_strTxMsg As String, ByRef v_strTLTXCD As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
            'TruongLD Comment when convert
            'Dim v_intIndex, v_intRefIndex As Long
            'TruonLD Modify when convert
            Dim v_intIndex, v_intRefIndex As Integer
            'End TruongLD
            Dim i, j, v_intCount As Integer
            Dim v_strFLDNAME, v_strFLDROUND, v_strFLDDEFNAME, v_strDATATYPE, v_strDEFNAME, v_strFLDVALUE, v_strTXBUSDATE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_blnIsCorrect As Boolean
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_attrDEFNAME As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strFieldValue, strFLDNAME As String

            'Check data control before commit
            For Each v_control As Control In Me.pnTransDetail.Controls
                If InStr(CType(v_control, Control).Name, PREFIXED_MSKDATA) > 0 Then
                    v_intIndex = CType(v_control, Control).Tag
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        If TypeOf (v_control) Is ComboBoxEx Or TypeOf (v_control) Is ComboBox Then
                            v_strFieldValue = CType(v_control, ComboBoxEx).SelectedValue
                        Else
                            v_strFieldValue = CType(v_control, Control).Text
                        End If
                        strFLDNAME = Mid(CType(v_control, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                        If mv_arrObjFields(v_intIndex).Mandatory = True And mv_arrObjFields(v_intIndex).Visible = True And mv_arrObjFields(v_intIndex).Enabled = True And Len(v_strFieldValue) = 0 Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CType(v_control, Control).Focus()
                            Exit Function
                        End If
                        'Khong duoc them check MANDATORY tai day !!!!!!!!!!!!!!!!!!!!!! 
                        If TypeOf (v_control) Is ComboBoxEx AndAlso CType(v_control, ComboBoxEx).SelectedIndex < 0 AndAlso mv_arrObjFields(v_intIndex).Visible = True Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_COMBOEX"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CType(v_control, Control).Focus()
                            Exit Function
                            'End If
                        End If
                    End If
                End If
            Next

            'Táº¡o Ä‘iá»‡n giao dá»‹ch
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, Trim(mskTransCode.Text), Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , , IIf(mv_strCCYCD = "##", "00", BuildAMTEXP(v_xmlDocument, mv_strCCYCD)))
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

            'Truongld
            If Trim(mskTransCode.Text) = gc_GL_CAST_IN Or Trim(mskTransCode.Text) = gc_GL_CAST_OUT Then
                AutoCreatePostmap()
                CreatePostmap(v_xmlDocument)
            End If
            'End TruongLD

            'Nếu giao dịch cho phép nhập bút toán kế toán thì lấy bút toán kế toán ở đây
            If mv_blnAcctEntry Then
                If Me.tabAccountEntry.Controls.Count > 0 Or Me.tabVATVoucher.Controls.Count > 0 Then
                    CreatePostmap(v_xmlDocument)
                    CreateVATVoucher(v_xmlDocument)
                Else
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransact.PostMapEmpty"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

            End If
            'Nếu giao dịch có khai báo sử dụng biểu phí giao dịch riêng
            If mv_lngFeeEntry > 0 Then
                'CreateFeemap(v_xmlDocument)
                ShowFEEDetails(mskTransCode.Text)
            Else
                Me.TabFEEDetails.Dispose()
            End If

            'Duyệt mảng dữ liệu danh mục các điều kiện kiểm tra
            v_intCount = mv_arrObjFldVals.GetLength(0)
            Dim v_strTagValue As String
            If v_intCount > 0 Then
                For i = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFldVals(i) Is Nothing Then
                        With mv_arrObjFldVals(i)
                            'Xác định control index
                            v_intIndex = mv_arrObjFields(.IDXFLD).ControlIndex
                            ' tinh gia tri tagvalue
                            If (.TAGVALUE.StartsWith("@")) Then
                                v_strTagValue = .TAGVALUE.Trim("@")
                            Else
                                v_strTagValue = GetFieldValueByName(.TAGVALUE)
                            End If
                            ' neu tagfield= tagvalue thi moi check
                            'If (String.Compare(GetFieldValueByName(.TAGFIELD), v_strTagValue) = 0 Or Trim(.TAGFIELD) = "") Then
                            If (String.Compare(GetControlValueByName(.TAGFIELD), v_strTagValue) = 0 Or Trim(.TAGFIELD) = "") Then

                                'Thá»±c hiá»‡n xá»­ lÃ½ cho tá»«ng phÃ©p toÃ¡n
                                If .VALTYPE = "E" Then
                                    'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  sá»‘
                                    If mv_arrObjFields(.IDXFLD).DataType <> "D" Then
                                        Select Case .[OPERATOR]
                                            Case "MA"
                                                v_strVALEXP = .VALEXP
                                                v_strVALEXP2 = .VALEXP2
                                                If String.Compare(v_strVALEXP.Substring(0, 1), "@") = 0 Then
                                                    v_strVALEXP = v_strVALEXP.Substring(1)    'Lay truc tiep gia tri
                                                Else
                                                    v_strVALEXP = BuildAMTEXP(v_xmlDocument, v_strVALEXP)
                                                End If
                                                If String.Compare(v_strVALEXP2.Substring(0, 1), "@") = 0 Then
                                                    v_strVALEXP2 = v_strVALEXP2.Substring(1)    'Lay truc tiep gia tri
                                                Else
                                                    v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, v_strVALEXP2)
                                                End If
                                                'v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                'v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            Case "MI"
                                                v_strVALEXP = .VALEXP
                                                v_strVALEXP2 = .VALEXP2
                                                If String.Compare(v_strVALEXP.Substring(0, 1), "@") = 0 Then
                                                    v_strVALEXP = v_strVALEXP.Substring(1)    'Lay truc tiep gia tri
                                                Else
                                                    v_strVALEXP = BuildAMTEXP(v_xmlDocument, v_strVALEXP)
                                                End If
                                                If String.Compare(v_strVALEXP2.Substring(0, 1), "@") = 0 Then
                                                    v_strVALEXP2 = v_strVALEXP2.Substring(1)    'Lay truc tiep gia tri
                                                Else
                                                    v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, v_strVALEXP2)
                                                End If
                                                'v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                'v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetMin(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            Case "&&"
                                                v_strVALEXP = BuildCONCAT(.VALEXP)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = v_strVALEXP
                                            Case "EX"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = FRound(v_objEval.Eval(v_strVALEXP), 0)
                                                Else
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_objEval.Eval(v_strVALEXP)
                                                End If
                                            Case "IP"   'Lay gia tri toi thieu nhung phai lon hon 0
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                    v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = GetMinPositive(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                                End If
                                            Case "IF"   'Phep toan so sanh, su dung VALEXP de so sanh neu OK lay gia tri trong VALEXP2
                                                '02 ky tu dau tien la truong can so sanh
                                                '02 ky tu tiep theo la phep toan
                                                'con lai la gia tri can so sanh: neu bat dau la @ lay truc tiep, con lai la gia tri truong
                                                If .VALEXP.Length > 4 Then
                                                    v_blnIsCorrect = False
                                                    v_strVALEXP = .VALEXP.Substring(0, 2)
                                                    'Xac dinh v_intRefIndex cua truong can so sanh
                                                    For j = 0 To v_intCount - 1 Step 1
                                                        If Not mv_arrObjFields(j) Is Nothing Then
                                                            If String.Compare(mv_arrObjFields(j).FieldName, v_strVALEXP) = 0 Then
                                                                v_intRefIndex = j
                                                            End If
                                                        End If
                                                    Next
                                                    'Xac dinh cac gia tri trong phep toan so sanh
                                                    v_strVALEXP = BuildAMTEXP(v_xmlDocument, v_strVALEXP)
                                                    v_strOPERATOR = .VALEXP.Substring(2, 2)
                                                    v_strVALEXP2 = .VALEXP.Substring(4)
                                                    If String.Compare(v_strVALEXP2.Substring(0, 1), "@") = 0 Then
                                                        v_strVALEXP2 = v_strVALEXP2.Substring(1)    'Lay truc tiep gia tri
                                                    Else
                                                        v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, v_strVALEXP2)
                                                    End If
                                                    'Thuc hien so sanh
                                                    Select Case v_strOPERATOR
                                                        Case "=="
                                                            If mv_arrObjFields(v_intRefIndex).DataType = "N" Then
                                                                If v_objEval.Eval(v_strVALEXP) = v_objEval.Eval(v_strVALEXP2) Then
                                                                    v_blnIsCorrect = True
                                                                End If
                                                            ElseIf mv_arrObjFields(v_intRefIndex).DataType = "C" Then
                                                                If String.Compare(v_strVALEXP, v_strVALEXP2) = 0 Then
                                                                    v_blnIsCorrect = True
                                                                End If
                                                            ElseIf mv_arrObjFields(v_intRefIndex).DataType = "D" Then
                                                                If DDMMYYYY_SystemDate(v_strVALEXP) = DDMMYYYY_SystemDate(v_strVALEXP2) Then
                                                                    v_blnIsCorrect = True
                                                                End If
                                                            End If
                                                    End Select
                                                    'Dat gia tri neu phep toan kiem tra la dung
                                                    If v_blnIsCorrect Then
                                                        v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                        If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                            Me.pnTransDetail.Controls(v_intIndex).Text = FRound(v_objEval.Eval(v_strVALEXP2), 0)
                                                        Else
                                                            Me.pnTransDetail.Controls(v_intIndex).Text = v_objEval.Eval(v_strVALEXP2)
                                                        End If
                                                    End If
                                                End If
                                            Case "FF"   'Lay gia tri phi
                                                If Not v_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT) Is Nothing Then
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).InnerXml
                                                End If
                                            Case "VV"   'Lay gia tri VAT
                                                If Not v_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT) Is Nothing Then
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).InnerXml
                                                End If
                                                'PhuongHT add
                                            Case "FX"   'Goi ham oracle
                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so

                                                If TypeOf (Me.pnTransDetail.Controls(v_intIndex)) Is ComboBoxEx Then
                                                    CType(Me.pnTransDetail.Controls(v_intIndex), ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                Else
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                    If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                        FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                                    End If
                                                End If
                                                ' end of PhuongHT add
                                        End Select
                                        'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  ngÃ y thÃ¡ng
                                        'Làm tròn số
                                        If mv_arrObjFields(.IDXFLD).DataType = "N" And IsNumeric(Me.pnTransDetail.Controls(v_intIndex).Text) And _
                                            IsNumeric(mv_arrObjFields(.IDXFLD).FldRound) Then
                                            Me.pnTransDetail.Controls(v_intIndex).Text = gf_RoundNumber(Me.pnTransDetail.Controls(v_intIndex).Text, mv_arrObjFields(.IDXFLD).FldRound)
                                        End If
                                    ElseIf mv_arrObjFields(.IDXFLD).DataType = "D" Then
                                        Select Case .[OPERATOR]
                                            Case "MA"
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                v_dtVALEXP2 = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP2))
                                                If v_dtVALEXP > v_dtVALEXP2 Then
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_dtVALEXP
                                                Else
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_dtVALEXP2
                                                End If
                                            Case "MI"
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                v_dtVALEXP2 = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP2))
                                                If v_dtVALEXP > v_dtVALEXP2 Then
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_dtVALEXP2
                                                Else
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = v_dtVALEXP
                                                End If
                                            Case "FX"   'Goi ham oracle
                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so

                                                If TypeOf (Me.pnTransDetail.Controls(v_intIndex)) Is ComboBoxEx Then
                                                    CType(Me.pnTransDetail.Controls(v_intIndex), ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                Else
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                    If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                        FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                                    End If
                                                End If
                                                ' end of PhuongHT add
                                        End Select
                                    End If
                                ElseIf .VALTYPE = "I" Then
                                    If mv_arrObjFields(.IDXFLD).FieldName = .FLDNAME Then
                                        Select Case .[OPERATOR]
                                            Case "FX"   'Goi ham oracle
                                                'Return : 0 OK, -1 Error
                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so
                                                Dim v_LogInt As Integer = 0
                                                v_LogInt = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                If v_LogInt <> 0 Then
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If
                                                End If
                                        End Select
                                    End If
                                ElseIf .VALTYPE = "V" Then
                                    If TypeOf (Me.pnTransDetail.Controls(v_intIndex)) Is ComboBoxEx Then
                                        v_strFLDVALUE = CType(Me.pnTransDetail.Controls(v_intIndex), ComboBoxEx).SelectedValue
                                    Else
                                        v_strFLDVALUE = Me.pnTransDetail.Controls(v_intIndex).Text
                                    End If

                                    'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  sá»‘
                                    If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                        If Not gf_Numberic(v_strFLDVALUE) Then
                                            MessageBox.Show(mv_ResourceManager.GetString("ERR_INVALID_NUMERIC_NUMBER"))
                                            Me.pnTransDetail.Controls(v_intIndex).Focus()
                                            Return False
                                        End If
                                        v_strFLDVALUE = CDbl(v_strFLDVALUE).ToString
                                        Select Case .[OPERATOR]
                                            Case ">>"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not CDbl(v_strFLDVALUE) > v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case ">="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not CDbl(v_strFLDVALUE) >= v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<<"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not CDbl(v_strFLDVALUE) < v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not CDbl(v_strFLDVALUE) <= v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "=="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)

                                                If Not CDbl(v_strFLDVALUE) = v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If


                                            Case "<>"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not CDbl(v_strFLDVALUE) <> v_objEval.Eval(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "IN"
                                            Case "NI"
                                        End Select
                                    ElseIf mv_arrObjFields(.IDXFLD).DataType = "C" Or mv_arrObjFields(.IDXFLD).DataType = "P" Then
                                        Select Case .[OPERATOR]
                                            Case ">>"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not (v_strFLDVALUE) > v_objEval.EvalString(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case ">="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not (v_strFLDVALUE) >= v_objEval.EvalString(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<<"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not (v_strFLDVALUE) < v_objEval.EvalString(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not (v_strFLDVALUE) <= v_objEval.EvalString(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "=="
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If IsNumeric(v_strVALEXP) Then
                                                    If Not (v_strFLDVALUE) = v_objEval.EvalString(v_strVALEXP) Then
                                                        'If Me.UserLanguage = "EN" Then
                                                        '    MsgBox(.EN_ERRMSG)
                                                        'Else
                                                        '    MsgBox(.ERRMSG)
                                                        'End If
                                                        'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        'Return False
                                                        If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                            Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                            Return False
                                                        End If

                                                    End If
                                                Else
                                                    If Not (v_strFLDVALUE) = v_strVALEXP Then
                                                        'If Me.UserLanguage = "EN" Then
                                                        '    MsgBox(.EN_ERRMSG)
                                                        'Else
                                                        '    MsgBox(.ERRMSG)
                                                        'End If
                                                        'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        'Return False
                                                        If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                            Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                            Return False
                                                        End If

                                                    End If
                                                End If


                                            Case "<>"
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                If Not (v_strFLDVALUE) <> v_objEval.EvalString(v_strVALEXP) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "CB" 'Ducnv check Careby
                                                Dim v_strCAREBYGRP As String
                                                Dim v_strSQL, v_strObjMsg As String
                                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                                Dim v_xmlDocument1 As New Xml.XmlDocument
                                                Dim v_nodeList1 As Xml.XmlNodeList

                                                v_strCAREBYGRP = Me.pnTransDetail.Controls(v_intIndex).Text
                                                If v_strCAREBYGRP.Trim.Length > 0 Then
                                                    If Not (String.Compare(v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value, HO_BRID) = 0 _
                                                        And String.Compare(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value, ADMIN_ID) = 0) Then
                                                        'Supervisor: no need to check
                                                        v_strSQL = "SELECT COUNT(*) CAREBY FROM TLGRPUSERS WHERE GRPID = '" & v_strCAREBYGRP & "' " & _
                                                            "AND BRID = '" & v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value & "' " & _
                                                            "AND TLID = '" & v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value & "' "
                                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strSQL)
                                                        v_ws.Message(v_strObjMsg)
                                                        v_xmlDocument1.LoadXml(v_strObjMsg)
                                                        v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                                                        If v_nodeList1.Count > 0 Then

                                                            If Not CInt(v_nodeList1.Item(0).ChildNodes(0).InnerText.ToString()) > 0 Then
                                                                'If Me.UserLanguage = "EN" Then
                                                                '    MsgBox(.EN_ERRMSG)
                                                                'Else
                                                                '    MsgBox(.ERRMSG)
                                                                'End If
                                                                'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                                'Return False
                                                                If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                    Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                                    Return False
                                                                End If

                                                            End If
                                                        Else
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG)
                                                            'Else
                                                            '    MsgBox(.ERRMSG)
                                                            'End If
                                                            'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                                Return False
                                                            End If

                                                        End If
                                                    End If
                                                End If
                                            Case "IN"
                                                If Not (InStr(1, .VALEXP, v_strFLDVALUE) > 0) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "NI"
                                                If (InStr(1, .VALEXP, v_strFLDVALUE) > 0) Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                                'Check Margin type - TungNT added
                                            Case "MR"
                                                'End

                                        End Select
                                        'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  ngÃ y thÃ¡ng
                                    ElseIf mv_arrObjFields(.IDXFLD).DataType = "D" Then
                                        If Not IsDateValue(v_strFLDVALUE) Then
                                            MessageBox.Show(mv_ResourceManager.GetString("ERR_DATE_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        Else
                                            v_dtFLDVALUE = DDMMYYYY_SystemDate(v_strFLDVALUE)
                                        End If
                                        Select Case .[OPERATOR]
                                            Case ">>"
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                If Not v_dtFLDVALUE > v_dtVALEXP Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case ">="
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                If Not v_dtFLDVALUE >= v_dtVALEXP Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<<"
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                If Not v_dtFLDVALUE < v_dtVALEXP Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "<="
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                If Not v_dtFLDVALUE <= v_dtVALEXP Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "=="

                                                'PhuongHT add de check dau vao la ngay lam viec
                                                If (.VALEXP.Trim = "<$WORKDATE>") Then
                                                    Dim v_strSQL, v_strObjMsg As String
                                                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                                    Dim v_xmlDocument1 As New Xml.XmlDocument
                                                    Dim v_nodeList1 As Xml.XmlNodeList
                                                    v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE CLDRTYPE ='000' and SBDATE = TO_DATE('" & v_dtFLDVALUE & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strSQL)
                                                    v_ws.Message(v_strObjMsg)
                                                    v_xmlDocument1.LoadXml(v_strObjMsg)
                                                    v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                                                    If v_nodeList1.Count >= 1 Then
                                                        If CInt(v_nodeList1.Item(0).ChildNodes(0).InnerText.ToString()) > 0 Then
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                                Return False
                                                            End If
                                                        End If

                                                    End If

                                                Else
                                                    v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                    If Not v_dtFLDVALUE = v_dtVALEXP Then
                                                        'If Me.UserLanguage = "EN" Then
                                                        '    MsgBox(.EN_ERRMSG)
                                                        'Else
                                                        '    MsgBox(.ERRMSG)
                                                        'End If
                                                        'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        'Return False
                                                        If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                            Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                            Return False
                                                        End If

                                                    End If
                                                End If

                                            Case "<>"
                                                v_dtVALEXP = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                If Not v_dtFLDVALUE <> v_dtVALEXP Then
                                                    'If Me.UserLanguage = "EN" Then
                                                    '    MsgBox(.EN_ERRMSG)
                                                    'Else
                                                    '    MsgBox(.ERRMSG)
                                                    'End If
                                                    'Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                    'Return False
                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                        Me.pnTransDetail.Controls(v_intIndex).Focus()
                                                        Return False
                                                    End If

                                                End If
                                            Case "IN"
                                            Case "NI"
                                        End Select
                                    End If
                                End If
                            End If
                        End With
                    End If
                Next
            End If
            For Each v_ctl In Me.pnTransDetail.Controls
                If v_ctl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                    'Lấy ngày hạch toán được nhập
                    mv_strTxBusDate = v_ctl.Text
                    'Kiem tra ngay chung tu hop le hay ko
                    Try
                        DDMMYYYY_SystemDate(mv_strTxBusDate)
                    Catch ex As Exception
                        MessageBox.Show(mv_ResourceManager.GetString("BUSDATE_NOT_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                    'Kiểm tra ngày hạch toán không được sau ngày làm việc hiện tại
                    If DDMMYYYY_SystemDate(mv_strTxBusDate) > DDMMYYYY_SystemDate(Me.BusDate) Then
                        MessageBox.Show(mv_ResourceManager.GetString("BUSDATE_AFTER_CURRDATE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    Else
                        'PhuongHT add check ngay chung tu pai la ngay lam viec
                        Dim v_strSQL, v_strObjMsg As String
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_xmlDocument1 As New Xml.XmlDocument
                        Dim v_nodeList1 As Xml.XmlNodeList
                        v_strSQL = "SELECT * FROM SBCLDR WHERE CLDRTYPE ='000' and SBDATE = TO_DATE('" & mv_strTxBusDate & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, Me.TellerId, , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strSQL)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument1.LoadXml(v_strObjMsg)
                        v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                        If v_nodeList1.Count >= 1 Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_POSTING_DATE_MUST_BE_WORK_DATE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.pnTransDetail.Controls(v_intIndex).Focus()
                            Return False

                        End If
                        ' end of PhuongHT
                        If v_strTLTXCD = gc_SE_SEND_DEPOSIT Or v_strTLTXCD = gc_SE_COMPLETE_DEPOSIT Then
                            Dim v_dPostedDate As String
                            Dim v_ctl1 As Control
                            For Each v_ctl1 In Me.pnTransDetail.Controls
                                If v_ctl1.Name = PREFIXED_MSKDATA & "07" Then
                                    v_dPostedDate = v_ctl1.Text
                                End If
                            Next
                            If DDMMYYYY_SystemDate(v_dPostedDate) > DDMMYYYY_SystemDate(mv_strTxBusDate) Then
                                MessageBox.Show(mv_ResourceManager.GetString("ERR_INVALID_POSTING_DATE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.pnTransDetail.Controls(v_intIndex).Focus()
                                Return False
                            End If
                        End If
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).InnerXml = mv_strTxBusDate
                    End If
                Else
                    'Lấy nội dung giao dịch
                    If InStr(v_ctl.Name, PREFIXED_MSKDATA) > 0 Then
                        'Get data
                        v_intIndex = v_ctl.Tag
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        v_strDEFNAME = mv_arrObjFields(v_intIndex).ColumnName
                        v_strFLDROUND = mv_arrObjFields(v_intIndex).FldRound
                        If (TypeOf (v_ctl) Is ComboBoxEx) Then
                            Dim v_strText As String = CType(v_ctl, ComboBoxEx).Text
                            If CType(v_ctl, ComboBoxEx).SelectedValue = "" Then
                                CType(v_ctl, ComboBoxEx).SelectedIndex = CType(v_ctl, ComboBoxEx).FindStringExact(v_strText, -1)
                            End If
                            v_strFLDVALUE = CType(v_ctl, ComboBoxEx).SelectedValue
                        Else
                            If mv_arrObjFields(v_intIndex).DataType = "N" Then
                                If Not gf_Numberic(v_ctl.Text) Then
                                    'Thông báo phải nhập giá trị số
                                    v_strFLDVALUE = mv_arrObjFields(v_intIndex).Caption & ":" & mv_ResourceManager.GetString("ERR_NUMERIC_VALUE")
                                    MessageBox.Show(v_strFLDVALUE, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.pnTransDetail.Controls(v_intIndex).Focus()
                                    If v_ctl.Visible And v_ctl.Enabled Then
                                        v_ctl.Focus()
                                    End If
                                    Return False
                                Else
                                    If v_strFLDROUND.Trim.Length > 0 Then
                                        If IsNumeric(v_strFLDROUND) Then
                                            'v_strFLDVALUE = FormatNumber(gf_Cdbl(v_ctl.Text), CLng(v_strFLDROUND))
                                            'v_strFLDVALUE = gf_Cdbl(v_strFLDVALUE)
                                            v_strFLDVALUE = gf_RoundNumber(gf_Cdbl(v_ctl.Text), CLng(v_strFLDROUND))
                                        Else
                                            v_strFLDVALUE = gf_Cdbl(v_ctl.Text).ToString
                                        End If
                                    Else
                                        'Nếu không có qui định làm tròn
                                        v_strFLDVALUE = gf_Cdbl(v_ctl.Text).ToString
                                    End If
                                End If
                            Else
                                'v_strFLDVALUE = v_ctl.Text
                                v_strFLDVALUE = Replace(v_ctl.Text, "'", "''")
                            End If
                        End If

                        'LÆ°u láº¡i giÃ¡ trá»‹ Ä‘á»ƒ sá»­ dá»¥ng náº¿u áº¥n phÃ­m Adjust
                        mv_arrObjFields(v_intIndex).DefaultValue = v_strFLDVALUE

                        'Append entry to data node
                        v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        'Add field name
                        v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                        v_attrFLDNAME.Value = v_strFLDNAME
                        v_entryNode.Attributes.Append(v_attrFLDNAME)

                        'Add field type
                        v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                        v_attrDATATYPE.Value = v_strDATATYPE
                        v_entryNode.Attributes.Append(v_attrDATATYPE)

                        'Add coloum name
                        v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                        v_attrDEFNAME.Value = v_strDEFNAME
                        v_entryNode.Attributes.Append(v_attrDEFNAME)

                        'Set value
                        v_entryNode.InnerText = v_strFLDVALUE

                        v_dataElement.AppendChild(v_entryNode)

                        'Remember next transaction
                        If Mid(Trim(mskTransCode.Text), 3, 2) = "71" Then
                            If UCase(v_strFLDNAME) = "04" Then
                                v_strTLTXCD = v_strFLDVALUE
                            End If
                        End If

                        'Remember account field
                        'Remember message account
                        If mv_strMsgAccount Is Nothing Or mv_strMsgAccount.Length = 0 Then
                            If UCase(v_strFLDNAME) = "03" Then
                                Clipboard.SetDataObject(v_strFLDVALUE)
                            End If
                        Else
                            If UCase(v_strFLDNAME) = mv_strMsgAccount Then
                                Clipboard.SetDataObject(v_strFLDVALUE)
                            End If
                        End If
                        'If UCase(v_strFLDNAME) = "03" Then
                        '    Clipboard.SetDataObject(v_strFLDVALUE)
                        'End If
                    End If
                    v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                End If
            Next
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    'HÃ m nÃ y hiá»‡n láº¡i FEEDetail trÃªn cÆ¡ sá»Ÿ máº£ng thÃ´ng tin fee
    Private Function ShowFEEDetails(ByVal pv_tltxcd As String)
        Dim v_dtgFEEDetail As GridEx, v_intCount, v_intIndex As Integer
        Me.TabFEEDetails.Controls.Clear()
        'Thá»ƒ hiá»‡n pháº§n Ä‘á»‹nh khoáº£n
        'Náº¡p FEEDetails cho DataGrid
        v_dtgFEEDetail = New GridEx
        v_dtgFEEDetail.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgFEEDetail.FixedHeaderRows.Add(v_cmrHeader)

        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("FEECD", GetType(System.String)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("FEENAME", GetType(System.String)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("GLACCTNO", GetType(System.String)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("FORP", GetType(System.String)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("FEEAMT", GetType(System.Double)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("FEERATE", GetType(System.Double)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("MINVAL", GetType(System.Double)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("MAXVAL", GetType(System.Double)))
        v_dtgFEEDetail.Columns.Add(New Xceed.Grid.Column("VATRATE", GetType(System.Double)))

        TabFEEDetails.Text = mv_ResourceManager.GetString("FEEDETAIL_EN")
        v_dtgFEEDetail.Columns("FEECD").Title = mv_ResourceManager.GetString("FEECD_EN")
        v_dtgFEEDetail.Columns("FEENAME").Title = mv_ResourceManager.GetString("FEENAME_EN")
        v_dtgFEEDetail.Columns("GLACCTNO").Title = mv_ResourceManager.GetString("GLACCTNO_EN")
        v_dtgFEEDetail.Columns("FORP").Title = mv_ResourceManager.GetString("FORP_EN")
        v_dtgFEEDetail.Columns("FEEAMT").Title = mv_ResourceManager.GetString("FEEAMT_EN")
        v_dtgFEEDetail.Columns("FEERATE").Title = mv_ResourceManager.GetString("FEERATE_EN")
        v_dtgFEEDetail.Columns("MINVAL").Title = mv_ResourceManager.GetString("MINVAL_EN")
        v_dtgFEEDetail.Columns("MAXVAL").Title = mv_ResourceManager.GetString("MAXVAL_EN")
        v_dtgFEEDetail.Columns("VATRATE").Title = mv_ResourceManager.GetString("VATRATE_EN")

        v_dtgFEEDetail.Columns("FEECD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgFEEDetail.Columns("FEENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgFEEDetail.Columns("GLACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgFEEDetail.Columns("FORP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgFEEDetail.Columns("FEEAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgFEEDetail.Columns("MINVAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgFEEDetail.Columns("MAXVAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgFEEDetail.Columns("FEERATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgFEEDetail.Columns("VATRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        'Remove các bản ghi cũ
        v_dtgFEEDetail.DataRows.Clear()
        Dim v_strSQL As String = "SELECT * FROM FEEMASTER WHERE FEECD IN (SELECT FEECD FROM FEEMAP WHERE TLTXCD='" & pv_tltxcd & "') AND STATUS='Y'"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        Dim v_strResourceManager As String
        FillDataGrid(v_dtgFEEDetail, v_strObjMsg, "")
        TabFEEDetails.Controls.Add(v_dtgFEEDetail)
        If v_dtgFEEDetail.DataRows.Count = 0 Then
            Me.TabFEEDetails.Dispose()
        End If
    End Function

    'HÃ m nÃ y Ä‘Æ°á»£c dÃ¹ng Ä‘á»ƒ hiá»ƒn thá»‹ láº¡i Ä‘iá»‡n giao dá»‹ch tráº£ vá»? tá»« trÃªn HOST Ä‘á»‘i vá»›i giao dá»‹ch Submit 02 láº§n
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        Try
            Dim v_dataElement As Xml.XmlElement, v_nodetxData, v_nodetxDataFulname, v_nodetxDataAddress, v_nodetxDataLicence, v_nodetxDataNew As Xml.XmlNode
            Dim v_nodetxDataBankAccount, v_nodetxDataBankName, v_nodetxDataBankQueue, v_nodetxDataHoldAmount, v_nodetxDataIDDate, v_nodetxDataIDPlace As Xml.XmlNode
            Dim v_ctl As Control, v_objAccount As CAccountEntry

            Dim v_nodetxDataField As Xml.XmlAttribute
            Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME, v_strDEFNAME, v_strDATATYPE As String, i, j, v_intIndex As Integer
            Dim v_attrFLDNAME, v_attrDATATYPE, v_attrDEFNAME As Xml.XmlAttribute
            Me.mskTransCode.Enabled = False
            mv_isBackDate = False   'KhÃ´ng cho phÃ©p sá»­a láº¡i ngÃ y posting date ná»¯a
            'CÃ¡c trÆ°á»?ng giao dá»‹ch
            For Each v_ctl In Me.pnTransDetail.Controls
                If Not v_ctl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                    If InStr(v_ctl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_strPRINTVALUE = String.Empty
                        v_intIndex = v_ctl.Tag
                        'Ä?áº·t láº¡i giÃ¡ trá»‹ cá»§a Objects field
                        v_strFLDNAME = Trim(mv_arrObjFields(v_intIndex).FieldName)
                        v_strDEFNAME = Trim(mv_arrObjFields(v_intIndex).ColumnName)
                        'Láº¥y trÆ°á»?ng Ä‘á»‹nh nghÄ©a PrintInfo
                        v_strPRINTINFO = Replace(mv_arrObjFields(v_intIndex).PrintInfo, "#", String.Empty)
                        If Len(v_strPRINTINFO) > 0 Then
                            'Cáº¥u trÃºc lÃ  02 kÃ½ tá»± Ä‘áº§u lÃ  mÃ£ trÆ°á»?ng tÃ i khoáº£n, tiáº¿p theo lÃ  tÃªn
                            v_strPRINTNAME = Mid(v_strPRINTINFO, 3)
                            v_nodetxData = v_xmlDocument.SelectSingleNode("TransactMessage/printinfo/entry[@fldname='" & Mid(v_strPRINTINFO, 1, 2) & "']")
                            v_nodetxDataFulname = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoCUSTNAME & "']")
                            v_nodetxDataAddress = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoADDRESS & "']")
                            v_nodetxDataLicence = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoLICENSE & "']")
                            'TruongLD Add 20/03/2010
                            v_nodetxDataIDDate = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoIDDATE & "']")
                            v_nodetxDataIDPlace = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoIDPLACE & "']")
                            'End TruongLd

                            v_nodetxDataBankAccount = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoBANKACCT & "']")
                            v_nodetxDataBankName = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoBANKNAME & "']")
                            v_nodetxDataBankQueue = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoBANKQUE & "']")
                            v_nodetxDataHoldAmount = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='" & gc_PrintInfoHOLDAMT & "']")


                            Select Case v_strPRINTNAME
                                Case gc_PrintInfoCUSTNAME
                                    v_strPRINTVALUE = v_nodetxData.Attributes("custname").Value
                                    mv_strCustName = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataFulname)
                                Case gc_PrintInfoADDRESS
                                    v_strPRINTVALUE = v_nodetxData.Attributes("address").Value
                                    mv_strAddress = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataAddress)
                                Case gc_PrintInfoLICENSE
                                    v_strPRINTVALUE = v_nodetxData.Attributes("license").Value
                                    mv_strLicense = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)

                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)

                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataLicence)

                                Case gc_PrintInfoIDDATE
                                    'TruongLD Add 20/03/2010
                                    v_strPRINTVALUE = v_nodetxData.Attributes("iddate").Value
                                    mv_strIDDate = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)

                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)

                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataIDDate)
                                Case gc_PrintInfoIDPLACE
                                    v_strPRINTVALUE = v_nodetxData.Attributes("idplace").Value
                                    mv_strIDPlace = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)

                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)

                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataIDPlace)
                                    'End TruongLD
                                Case gc_PrintInfoBANKACCT
                                    v_strPRINTVALUE = v_nodetxData.Attributes("bankacct").Value
                                    mv_strBankAcct = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataBankAccount)
                                Case gc_PrintInfoBANKNAME
                                    v_strPRINTVALUE = v_nodetxData.Attributes("bankname").Value
                                    mv_strBankname = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataBankName)
                                Case gc_PrintInfoBANKQUE
                                    v_strPRINTVALUE = v_nodetxData.Attributes("bankque").Value
                                    mv_strBankQue = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataBankQueue)
                                Case gc_PrintInfoHOLDAMT
                                    v_strPRINTVALUE = v_nodetxData.Attributes("holdamt").Value
                                    mv_strBankQue = v_strPRINTVALUE
                                    'Append entry to data node
                                    v_nodetxDataNew = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrFLDNAME)
                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strDATATYPE
                                    v_nodetxDataNew.Attributes.Append(v_attrDATATYPE)
                                    'Add def name
                                    v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
                                    v_attrDEFNAME.Value = v_strDEFNAME
                                    v_nodetxDataNew.Attributes.Append(v_attrDEFNAME)
                                    'Set value
                                    v_nodetxDataNew.InnerText = Replace(v_strPRINTVALUE, "'", "''")
                                    v_xmlDocument.DocumentElement("fields").ReplaceChild(v_nodetxDataNew, v_nodetxDataHoldAmount)
                            End Select
                        End If
                        ''Ä?áº·t láº¡i giÃ¡ trá»‹ cá»§a Objects field
                        'v_strFLDNAME = Trim(mv_arrObjFields(v_intIndex).FieldName)
                        If Len(v_strPRINTVALUE) > 0 Then
                            mv_arrObjFields(v_intIndex).FieldValue = v_strPRINTVALUE
                        Else
                            If TypeOf (v_ctl) Is ComboBoxEx Then
                                mv_arrObjFields(v_intIndex).FieldValue = CType(v_ctl, ComboBoxEx).SelectedValue
                            Else
                                mv_arrObjFields(v_intIndex).FieldValue = v_ctl.Text
                            End If
                        End If
                        mv_arrObjFields(v_intIndex).Visible = True
                        mv_arrObjFields(v_intIndex).Enabled = False
                    End If
                End If
            Next

            'Neu la giao dich Inquiry ra ngan hang thi hien thi gia tri Inquity
            'If Me.mskTransCode.Text = gc_RM_INQUIRY Then
            '    Dim v_strTltalBalance = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='TOTALBALANCE']").InnerText
            '    Dim v_strAvlBalance = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='AVLBALANCE']").InnerText
            '    Dim v_strHolhAmount = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='HOLDAMOUNT']").InnerText
            '    Dim v_strInqResult = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='INQRESULT']").InnerText
            '    For i = 0 To mv_arrObjFields.GetLength(0) - 2
            '        Select Case mv_arrObjFields(i).ColumnName
            '            Case "TOTALBALANCE"
            '                mv_arrObjFields(i).FieldValue = v_strTltalBalance
            '            Case "AVLBALANCE"
            '                mv_arrObjFields(i).FieldValue = v_strAvlBalance
            '            Case "HOLDAMOUNT"
            '                mv_arrObjFields(i).FieldValue = v_strHolhAmount
            '            Case "INQRESULT"
            '                mv_arrObjFields(i).FieldValue = v_strInqResult
            '        End Select
            '    Next
            'End If

            'Bá»™ Ä‘á»‹nh khoáº£n káº¿ toÃ¡n
            mv_arrObjAccounts = Nothing
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strACCTNO As String, v_dblAMT As Double
            v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/postmap/entry")
            If v_nodeList.Count > 0 Then
                ReDim mv_arrObjAccounts(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1 Step 1
                    'Láº¥y tham sá»‘ háº¡ch toÃ¡n
                    With v_nodeList.Item(i)
                        v_strSUBTXNO = CStr(CType(.Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value)
                        v_strDORC = CStr(CType(.Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value)
                        v_strCCYCD = CStr(CType(.Attributes.GetNamedItem("ccycd"), Xml.XmlAttribute).Value)
                        v_strACCTNO = CStr(CType(.Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value).ToString()
                        v_dblAMT = CDbl(.InnerXml)
                    End With
                    'BÃºt toÃ¡n káº¿ toÃ¡n
                    v_objAccount = New CAccountEntry
                    With v_objAccount
                        .SUBTXNO = v_strSUBTXNO
                        .CCYCD = v_strCCYCD
                        .DORC = v_strDORC
                        .ACCTNO = v_strACCTNO
                        .AMOUNT = v_dblAMT
                    End With
                    mv_arrObjAccounts(i) = v_objAccount
                Next
                ReDim Preserve mv_arrObjAccounts(v_nodeList.Count)
            Else
                'Truongld
                If Trim(mskTransCode.Text) = "9904" Or Trim(mskTransCode.Text) = "9905" Then
                    AutoCreatePostmap()
                End If
                'End TruongLD
            End If

            'Hiển thị lên màn hinh
            DisplayScreen()
            If Not (VoucherID Is Nothing) Then
                If VoucherID.Trim.Length > 0 Then
                    Me.btnVoucher.Visible = True
                End If
            End If
            btnAdjust.Visible = True
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function AutoCreatePostmap()
        Dim v_objAccount As CAccountEntry
        Dim v_CONST As Integer = 2
        Dim i As Integer, v_dblAMT As Double
        Dim v_strSUBTXNO, v_strDORC, v_strDRACCTNO, v_strCRACCTNO, v_strCCYCD, v_strBACCTNO As String

        ReDim mv_arrObjAccounts(v_CONST)

        Dim v_ctl As Control

        For Each v_ctl In Me.pnTransDetail.Controls
            Select Case v_ctl.Name
                Case PREFIXED_MSKDATA & "10" 'AMT
                    v_dblAMT = v_ctl.Text
                Case PREFIXED_MSKDATA & "97" 'SUBTXNO
                    v_strSUBTXNO = v_ctl.Text
                Case PREFIXED_MSKDATA & "98" 'DORC
                    v_strDORC = v_ctl.Text
                Case PREFIXED_MSKDATA & "02" 'DRACCTNO
                    v_ctl.Text = Replace(v_ctl.Text, "####", Me.BranchId)
                    v_ctl.Text = Replace(v_ctl.Text, "AAAA", Me.BranchId)
                    v_strDRACCTNO = v_ctl.Text
                Case PREFIXED_MSKDATA & "03" 'CRACCTNO
                    v_ctl.Text = Replace(v_ctl.Text, "####", Me.BranchId)
                    v_ctl.Text = Replace(v_ctl.Text, "AAAA", Me.BranchId)
                    v_strCRACCTNO = v_ctl.Text
                Case PREFIXED_MSKDATA & "04" 'BRACCTNO
                    v_ctl.Text = Replace(v_ctl.Text, "####", Me.BranchId)
                    v_ctl.Text = Replace(v_ctl.Text, "AAAA", Me.BranchId)
                    v_strBACCTNO = v_ctl.Text
                Case PREFIXED_MSKDATA & "05" 'CCYCD
                    v_strCCYCD = v_ctl.Text
            End Select

        Next

        '
        'DRACCTNO
        '
        v_objAccount = New CAccountEntry
        With v_objAccount
            .SUBTXNO = v_strSUBTXNO
            .CCYCD = v_strCCYCD
            .DORC = v_strDORC
            .ACCTNO = v_strDRACCTNO
            .AMOUNT = v_dblAMT
        End With
        mv_arrObjAccounts(0) = v_objAccount

        '
        'DRACCTNO
        '
        v_objAccount = New CAccountEntry
        With v_objAccount
            .SUBTXNO = v_strSUBTXNO
            .CCYCD = v_strCCYCD
            .DORC = IIf(v_strDORC = "D", "C", "D")
            .ACCTNO = v_strCRACCTNO
            .AMOUNT = v_dblAMT
        End With

        mv_arrObjAccounts(1) = v_objAccount

        '
        'BACCTNO
        '
        v_objAccount = New CAccountEntry
        With v_objAccount
            .SUBTXNO = v_strSUBTXNO + 1
            .CCYCD = v_strCCYCD
            .DORC = IIf(v_strDORC = "D", "D", "C")
            .ACCTNO = v_strBACCTNO
            .AMOUNT = v_dblAMT
        End With

        mv_arrObjAccounts(2) = v_objAccount

        ReDim Preserve mv_arrObjAccounts(v_CONST)

        RetrievePostmap()

    End Function

    Public Sub ResetScreen(Optional ByVal pv_ResetPostmap As Boolean = True)
        Me.pnTransDetail.Controls.Clear()
        Me.tabAccountEntry.Controls.Clear()
        Me.mskTransCode.Enabled = True
        'Me.mskTransCode.Text = String.Empty
        Me.tabTransact.Visible = False
        Me.pnTransDetail.Visible = False
        If pv_ResetPostmap Then mv_arrObjAccounts = Nothing
        mv_arrObjFields = Nothing
        Me.lblHelper.Top = PANEL_TOP
        Me.btnOK.Top = Me.lblHelper.Top
        Me.btnCANCEL.Top = Me.lblHelper.Top
        Me.MessageData = vbNullString
        'lblTransCaption.Text = vbNullString
        'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh
        Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_GAP * 20
        Me.stbMain.Visible = False
        Me.ActiveControl = Me.mskTransCode
        DisplayButton()
    End Sub

    'HÃ m nÃ y táº¡o láº¡i Postmap trÃªn cÆ¡ sá»Ÿ GridPostmap 
    Private Function CreatePostmap(ByRef pv_xmlDocument As Xml.XmlDocument)
        Dim v_postingElement As Xml.XmlElement
        Dim v_entryNode As Xml.XmlNode
        Dim v_strACCTNO, v_strDORC, v_strCCYCD As String, v_dblSUBTXNO, v_dblAMT As Double
        Dim v_dblMISUBTXNO As Double, v_strMIDORC, v_strMIACCTNO, v_strMICUSTID, v_strMICUSTNAME, v_strMITASKCD, v_strMIDEPTCD, v_strMIMICD, v_strMIDESCRIPTION As String
        Dim v_dtgPostmap As GridEx
        If Me.tabAccountEntry.Controls.Count > 0 Then
            v_dtgPostmap = CType(Me.tabAccountEntry.Controls(0), GridEx)
            Dim v_xDataRow As Xceed.Grid.DataRow

            v_postingElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "postmap", "")
            For Each v_xDataRow In v_dtgPostmap.DataRows
                'Láº¥y dá»¯ liá»‡u
                v_dblSUBTXNO = CDbl(v_xDataRow.Cells("SUBTXNO").Value)
                v_strCCYCD = v_xDataRow.Cells("CCYCD").Value
                v_strDORC = v_xDataRow.Cells("DORC").Value
                v_strACCTNO = v_xDataRow.Cells("ACCTNO").Value
                v_dblAMT = v_xDataRow.Cells("AMOUNT").Value
                'Táº¡o bÃºt toÃ¡n Ä‘á»‹nh khoáº£n
                v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("subtxno")
                v_attrSUBTXNO.Value = v_dblSUBTXNO
                v_entryNode.Attributes.Append(v_attrSUBTXNO)

                Dim v_attrDORC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("dorc")
                v_attrDORC.Value = v_strDORC
                v_entryNode.Attributes.Append(v_attrDORC)

                Dim v_attrCCYCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("ccycd")
                v_attrCCYCD.Value = v_strCCYCD
                v_entryNode.Attributes.Append(v_attrCCYCD)

                Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                v_attrACCTNO.Value = v_strACCTNO
                v_entryNode.Attributes.Append(v_attrACCTNO)

                v_entryNode.InnerText = v_dblAMT
                v_postingElement.AppendChild(v_entryNode)
            Next
            pv_xmlDocument.DocumentElement.AppendChild(v_postingElement)
        End If

        'Táº¡o láº¡i MITRAN trÃªn cÆ¡ sá»Ÿ máº£ng dÅ© liá»‡u MITRAN
        If Not mv_arrObjIEFMIS Is Nothing Then
            v_postingElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "mitran", "")
            Dim i As Integer
            For i = 0 To mv_arrObjIEFMIS.Length - 1
                With mv_arrObjIEFMIS(i)
                    'Láº¥y dá»¯ liá»‡u
                    v_dblMISUBTXNO = .SUBTXNO
                    v_strMIDORC = .DORC
                    v_strMIACCTNO = .ACCTNO
                    v_strMICUSTID = .CUSTID
                    v_strMICUSTNAME = .CUSTNAME
                    v_strMITASKCD = .TASKCD
                    v_strMIDEPTCD = .DEPTCD
                    v_strMIMICD = .MICD
                    v_strMIDESCRIPTION = .DESCRIPTION

                    'Táº¡o bÃºt toÃ¡n Ä‘á»‹nh khoáº£n
                    v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                    Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("subtxno")
                    v_attrSUBTXNO.Value = v_dblMISUBTXNO
                    v_entryNode.Attributes.Append(v_attrSUBTXNO)

                    Dim v_attrDORC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("dorc")
                    v_attrDORC.Value = v_strMIDORC
                    v_entryNode.Attributes.Append(v_attrDORC)

                    Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                    v_attrACCTNO.Value = v_strMIACCTNO
                    v_entryNode.Attributes.Append(v_attrACCTNO)

                    Dim v_attrCUSTID As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custid")
                    v_attrCUSTID.Value = v_strMICUSTID
                    v_entryNode.Attributes.Append(v_attrCUSTID)

                    Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custname")
                    v_attrCUSTNAME.Value = v_strMICUSTNAME
                    v_entryNode.Attributes.Append(v_attrCUSTNAME)

                    Dim v_attrTASKCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("taskcd")
                    v_attrTASKCD.Value = v_strMITASKCD
                    v_entryNode.Attributes.Append(v_attrTASKCD)

                    Dim v_attrDEPTCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("deptcd")
                    v_attrDEPTCD.Value = v_strMIDEPTCD
                    v_entryNode.Attributes.Append(v_attrDEPTCD)

                    Dim v_attrMICD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("micd")
                    v_attrMICD.Value = v_strMIMICD
                    v_entryNode.Attributes.Append(v_attrMICD)

                    Dim v_attrDESCRIPTION As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("description")
                    v_attrDESCRIPTION.Value = v_strMIDESCRIPTION
                    v_entryNode.Attributes.Append(v_attrDESCRIPTION)

                    v_entryNode.InnerText = "MITRAN"
                    v_postingElement.AppendChild(v_entryNode)
                End With
            Next
            pv_xmlDocument.DocumentElement.AppendChild(v_postingElement)
        End If
    End Function

    'HÃ m nÃ y táº¡o láº¡i VATVoucher trÃªn cÆ¡ sá»Ÿ GridPostmap 
    Private Function CreateVATVoucher(ByRef pv_xmlDocument As Xml.XmlDocument)
        Dim v_postingElement As Xml.XmlElement
        Dim v_entryNode As Xml.XmlNode
        Dim v_strVOUCHERNO, v_strVOUCHERTYPE, v_strSERIENO, v_strVOUCHERDATE, v_strCUSTID, v_strTAXCODE, v_strCUSTNAME, v_strADDRESS, v_strCONTENTS, v_strDESCRIPTION As String, v_dblQTTY, v_dblPRICE, v_dblVATRATE As Double

        Dim v_dtgVATVoucher As GridEx
        If Me.tabVATVoucher.Controls.Count > 0 Then
            v_dtgVATVoucher = CType(Me.tabVATVoucher.Controls(0), GridEx)
            Dim v_xDataRow As Xceed.Grid.DataRow

            v_postingElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "vatvoucher", "")
            For Each v_xDataRow In v_dtgVATVoucher.DataRows
                'Láº¥y dá»¯ liá»‡u
                v_strVOUCHERNO = v_xDataRow.Cells("VOUCHERNO").Value
                v_strVOUCHERTYPE = v_xDataRow.Cells("VOUCHERTYPE").Value
                v_strSERIENO = v_xDataRow.Cells("SERIENO").Value
                v_strVOUCHERDATE = Format(v_xDataRow.Cells("VOUCHERDATE").Value, gc_FORMAT_DATE)
                v_strCUSTID = v_xDataRow.Cells("CUSTID").Value
                v_strTAXCODE = v_xDataRow.Cells("TAXCODE").Value
                v_strCUSTNAME = v_xDataRow.Cells("CUSTNAME").Value
                v_strADDRESS = v_xDataRow.Cells("ADDRESS").Value
                v_strCONTENTS = v_xDataRow.Cells("CONTENTS").Value
                v_strDESCRIPTION = v_xDataRow.Cells("DESCRIPTION").Value
                v_dblQTTY = CDbl(v_xDataRow.Cells("QTTY").Value)
                v_dblPRICE = CDbl(v_xDataRow.Cells("PRICE").Value)
                v_dblVATRATE = CDbl(v_xDataRow.Cells("VATRATE").Value)
                'Táº¡o bÃºt toÃ¡n Ä‘á»‹nh khoáº£n
                v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                Dim v_attrVOUCHERNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("voucherno")
                v_attrVOUCHERNO.Value = v_strVOUCHERNO
                v_entryNode.Attributes.Append(v_attrVOUCHERNO)

                Dim v_attrVOUCHERTYPE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vouchertype")
                v_attrVOUCHERTYPE.Value = v_strVOUCHERTYPE
                v_entryNode.Attributes.Append(v_attrVOUCHERTYPE)

                Dim v_attrSERIENO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("serieno")
                v_attrSERIENO.Value = v_strSERIENO
                v_entryNode.Attributes.Append(v_attrSERIENO)

                Dim v_attrVOUCHERDATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("voucherdate")
                v_attrVOUCHERDATE.Value = v_strVOUCHERDATE
                v_entryNode.Attributes.Append(v_attrVOUCHERDATE)

                Dim v_attrCUSTID As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custid")
                v_attrCUSTID.Value = v_strCUSTID
                v_entryNode.Attributes.Append(v_attrCUSTID)

                Dim v_attrTAXCODE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("taxcode")
                v_attrTAXCODE.Value = v_strTAXCODE
                v_entryNode.Attributes.Append(v_attrTAXCODE)

                Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custname")
                v_attrCUSTNAME.Value = v_strCUSTNAME
                v_entryNode.Attributes.Append(v_attrCUSTNAME)

                Dim v_attrADDRESS As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("address")
                v_attrADDRESS.Value = v_strADDRESS
                v_entryNode.Attributes.Append(v_attrADDRESS)

                Dim v_attrCONTENTS As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("contents")
                v_attrCONTENTS.Value = v_strCONTENTS
                v_entryNode.Attributes.Append(v_attrCONTENTS)

                Dim v_attrDESCRIPTION As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("description")
                v_attrDESCRIPTION.Value = v_strDESCRIPTION
                v_entryNode.Attributes.Append(v_attrDESCRIPTION)

                Dim v_attrQTTY As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("qtty")
                v_attrQTTY.Value = v_dblQTTY
                v_entryNode.Attributes.Append(v_attrQTTY)

                Dim v_attrPRICE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("price")
                v_attrPRICE.Value = v_dblPRICE
                v_entryNode.Attributes.Append(v_attrPRICE)

                Dim v_attrVATRATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vatrate")
                v_attrVATRATE.Value = v_dblVATRATE
                v_entryNode.Attributes.Append(v_attrVATRATE)

                v_entryNode.InnerText = v_dblVATRATE
                v_postingElement.AppendChild(v_entryNode)
            Next
            pv_xmlDocument.DocumentElement.AppendChild(v_postingElement)
        End If
    End Function

    'HÃ m nÃ y hiá»‡n láº¡i Postmap trÃªn cÆ¡ sá»Ÿ máº£ng thÃ´ng tin Ä‘á»‹nh khoáº£n
    Private Function RetrievePostmap()
        Dim v_dtgPostmap As GridEx, v_intCount, v_intIndex As Integer
        Me.tabAccountEntry.Controls.Clear()

        'Thá»ƒ hiá»‡n pháº§n Ä‘á»‹nh khoáº£n
        If Not mv_arrObjAccounts Is Nothing Then
            v_intCount = mv_arrObjAccounts.GetLength(0)
            If v_intCount > 0 Then
                'Náº¡p POSTMAP cho DataGrid
                v_dtgPostmap = New GridEx
                v_dtgPostmap.Dock = DockStyle.Fill
                Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                v_dtgPostmap.FixedHeaderRows.Add(v_cmrHeader)
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("SUBTXNO", GetType(Integer)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DORC", GetType(System.String)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("AMOUNT", GetType(System.String)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DRAMT", GetType(System.String)))
                v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CRAMT", GetType(System.String)))

                mv_ResourceManager.GetString("")
                tabAccountEntry.Text = mv_ResourceManager.GetString("ACCOUNTENTRY_EN")
                v_dtgPostmap.Columns("SUBTXNO").Title = mv_ResourceManager.GetString("SUBTXNO_EN")
                v_dtgPostmap.Columns("CCYCD").Title = mv_ResourceManager.GetString("CCYCD_EN")
                v_dtgPostmap.Columns("DORC").Title = mv_ResourceManager.GetString("DORC_EN")
                v_dtgPostmap.Columns("ACCTNO").Title = mv_ResourceManager.GetString("ACCOUNT_EN")
                v_dtgPostmap.Columns("AMOUNT").Title = mv_ResourceManager.GetString("AMOUNT_EN")
                v_dtgPostmap.Columns("DRAMT").Title = mv_ResourceManager.GetString("DRAMT_EN")
                v_dtgPostmap.Columns("CRAMT").Title = mv_ResourceManager.GetString("CRAMT_EN")
                'If Me.UserLanguage = "EN" Then
                '    tabAccountEntry.Text = ACCOUNTENTRY_EN
                '    v_dtgPostmap.Columns("SUBTXNO").Title = SUBTXNO_EN
                '    v_dtgPostmap.Columns("CCYCD").Title = CCYCD_EN
                '    v_dtgPostmap.Columns("DORC").Title = DORC_EN
                '    v_dtgPostmap.Columns("ACCTNO").Title = ACCOUNT_EN
                '    v_dtgPostmap.Columns("AMOUNT").Title = AMOUNT_EN
                '    v_dtgPostmap.Columns("DRAMT").Title = DRAMT_EN
                '    v_dtgPostmap.Columns("CRAMT").Title = CRAMT_EN
                'Else
                '    tabAccountEntry.Text = ACCOUNTENTRY_VN
                '    v_dtgPostmap.Columns("SUBTXNO").Title = SUBTXNO_VN
                '    v_dtgPostmap.Columns("CCYCD").Title = CCYCD_VN
                '    v_dtgPostmap.Columns("DORC").Title = DORC_VN
                '    v_dtgPostmap.Columns("ACCTNO").Title = ACCOUNT_VN
                '    v_dtgPostmap.Columns("AMOUNT").Title = AMOUNT_VN
                '    v_dtgPostmap.Columns("DRAMT").Title = DRAMT_VN
                '    v_dtgPostmap.Columns("CRAMT").Title = CRAMT_VN
                'End If
                v_dtgPostmap.Columns("SUBTXNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgPostmap.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgPostmap.Columns("DORC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgPostmap.Columns("ACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                v_dtgPostmap.Columns("AMOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                v_dtgPostmap.Columns("DRAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                v_dtgPostmap.Columns("CRAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

                'Ä?iá»?n thÃ´ng tin háº¡ch toÃ¡n
                v_dtgPostmap.DataRows.Clear()
                v_dtgPostmap.BeginInit()
                For v_intIndex = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjAccounts(v_intIndex) Is Nothing Then
                        Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgPostmap.DataRows.AddNew()
                        v_xDataRow.Cells("SUBTXNO").Value = mv_arrObjAccounts(v_intIndex).SUBTXNO
                        v_xDataRow.Cells("CCYCD").Value = mv_arrObjAccounts(v_intIndex).CCYCD
                        v_xDataRow.Cells("DORC").Value = mv_arrObjAccounts(v_intIndex).DORC
                        v_xDataRow.Cells("ACCTNO").Value = mv_arrObjAccounts(v_intIndex).ACCTNO
                        v_xDataRow.Cells("AMOUNT").Value = Format(mv_arrObjAccounts(v_intIndex).AMOUNT, gc_FORMAT_NUMBER_0)
                        If mv_arrObjAccounts(v_intIndex).DORC.Trim = "D" Then
                            v_xDataRow.Cells("DRAMT").Value = Format(mv_arrObjAccounts(v_intIndex).AMOUNT, gc_FORMAT_NUMBER_0)
                            v_xDataRow.Cells("CRAMT").Value = "0"
                        Else
                            v_xDataRow.Cells("DRAMT").Value = "0"
                            v_xDataRow.Cells("CRAMT").Value = Format(mv_arrObjAccounts(v_intIndex).AMOUNT, gc_FORMAT_NUMBER_0)
                        End If
                        v_xDataRow.EndEdit()
                    End If
                Next
                v_dtgPostmap.EndInit()
                tabAccountEntry.Controls.Add(v_dtgPostmap)
                v_dtgPostmap.Columns("SUBTXNO").Width = v_dtgPostmap.Width / 10
                v_dtgPostmap.Columns("CCYCD").Width = 1.5 * v_dtgPostmap.Width / 10
                'v_dtgPostmap.Columns("DORC").Width = 0
                v_dtgPostmap.Columns("DORC").Visible = False
                v_dtgPostmap.Columns("ACCTNO").Width = 2.5 * v_dtgPostmap.Width / 10
                'v_dtgPostmap.Columns("AMOUNT").Width = 0
                v_dtgPostmap.Columns("AMOUNT").Visible = False
                v_dtgPostmap.Columns("DRAMT").Width = 2 * v_dtgPostmap.Width / 10
                v_dtgPostmap.Columns("CRAMT").Width = 2 * v_dtgPostmap.Width / 10

                Me.tabTransact.Visible = True
                Me.tabTransact.Top = Me.pnTransDetail.Top + Me.pnTransDetail.Height + TABS_TOP + FIX_TABS_TOP
                Me.tabTransact.Height = TABS_HEIGHT
                Me.lblHelper.Top = Me.tabTransact.Top + Me.tabTransact.Height + TABS_TOP + FIX_TABS_TOP + FIX_TABS_TOP
                Me.btnOK.Top = Me.lblHelper.Top
                Me.btnVoucher.Top = Me.lblHelper.Top
                Me.btnCANCEL.Top = Me.lblHelper.Top
                Me.btnAdjust.Top = Me.lblHelper.Top
                Me.btnEntries.Top = Me.lblHelper.Top
                Me.btnReject.Top = Me.lblHelper.Top
                Me.btnApprove.Top = Me.lblHelper.Top
                Me.btnRefuse.Top = Me.lblHelper.Top
            Else
                Me.tabTransact.Visible = False
                Me.tabAccountEntry.Visible = False
                Me.lblHelper.Top = Me.pnTransDetail.Top + Me.pnTransDetail.Height + TABS_TOP + FIX_TABS_TOP + FIX_TABS_TOP
                Me.btnOK.Top = Me.lblHelper.Top
                Me.btnVoucher.Top = Me.lblHelper.Top
                Me.btnCANCEL.Top = Me.lblHelper.Top
                Me.btnAdjust.Top = Me.lblHelper.Top
                Me.btnEntries.Top = Me.lblHelper.Top
                Me.btnReject.Top = Me.lblHelper.Top
                Me.btnApprove.Top = Me.lblHelper.Top
                Me.btnRefuse.Top = Me.lblHelper.Top
            End If
        End If

        'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh
        Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_HEIGHT + TABS_TOP + FIX_TABS_TOP
    End Function

    'HÃ m nÃ y hiá»‡n láº¡i VATVoucher trÃªn cÆ¡ sá»Ÿ máº£ng thÃ´ng tin Ä‘á»‹nh khoáº£n
    Private Function RetrieveVATVoucher()
        Dim v_dtgVATVoucher As GridEx, v_intCount, v_intIndex As Integer
        Me.tabVATVoucher.Controls.Clear()

        'Thá»ƒ hiá»‡n pháº§n Ä‘á»‹nh khoáº£n
        If Not mv_arrObjVAT Is Nothing Then
            v_intCount = mv_arrObjVAT.GetLength(0)
            If v_intCount > 0 Then
                'If v_intCount > 0 And Me.btnEntries.Visible = True Then
                Dim i As Integer
                'Náº¡p VATVoucher cho DataGrid
                tabVATVoucher.Text = VATVOUCHER_EN
                v_dtgVATVoucher = New GridEx
                v_dtgVATVoucher.Dock = DockStyle.Fill
                Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                v_dtgVATVoucher.FixedHeaderRows.Add(v_cmrHeader)
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("VOUCHERNO", GetType(System.String)))
                v_dtgVATVoucher.Columns("VOUCHERNO").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("VOUCHERTYPE", GetType(System.String)))
                v_dtgVATVoucher.Columns("VOUCHERTYPE").ReadOnly = True
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("SERIENO", GetType(System.String)))
                v_dtgVATVoucher.Columns("SERIENO").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("VOUCHERDATE", GetType(System.DateTime)))
                v_dtgVATVoucher.Columns("VOUCHERDATE").FormatSpecifier = "dd/MM/yyyy"
                v_dtgVATVoucher.Columns("VOUCHERDATE").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
                v_dtgVATVoucher.Columns("CUSTID").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("TAXCODE", GetType(System.String)))
                v_dtgVATVoucher.Columns("TAXCODE").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("CUSTNAME", GetType(System.String)))
                v_dtgVATVoucher.Columns("CUSTNAME").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
                v_dtgVATVoucher.Columns("ADDRESS").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("CONTENTS", GetType(System.String)))
                v_dtgVATVoucher.Columns("CONTENTS").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
                v_dtgVATVoucher.Columns("QTTY").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
                v_dtgVATVoucher.Columns("PRICE").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("VATRATE", GetType(System.Double)))
                v_dtgVATVoucher.Columns("VATRATE").ReadOnly = False
                v_dtgVATVoucher.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
                v_dtgVATVoucher.Columns("DESCRIPTION").ReadOnly = False

                For i = 0 To v_dtgVATVoucher.Columns.Count - 1 Step 1
                    v_dtgVATVoucher.Columns(i).Title = mv_ResourceManager.GetString("frmPostmap." & v_dtgVATVoucher.Columns(i).FieldName)
                Next

                v_dtgVATVoucher.Columns("VOUCHERNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("VOUCHERNO").Width = 70
                v_dtgVATVoucher.Columns("VOUCHERTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("VOUCHERTYPE").Width = 60
                v_dtgVATVoucher.Columns("SERIENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("SERIENO").Width = 100
                v_dtgVATVoucher.Columns("VOUCHERDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("VOUCHERDATE").Width = 100
                v_dtgVATVoucher.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                v_dtgVATVoucher.Columns("CUSTID").Width = 70
                v_dtgVATVoucher.Columns("CUSTID").FormatSpecifier = "####.######"
                v_dtgVATVoucher.Columns("TAXCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("TAXCODE").Width = 100
                v_dtgVATVoucher.Columns("CUSTNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("CUSTNAME").Width = 100
                v_dtgVATVoucher.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("ADDRESS").Width = 100
                v_dtgVATVoucher.Columns("CONTENTS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                v_dtgVATVoucher.Columns("CONTENTS").Width = 100
                v_dtgVATVoucher.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                v_dtgVATVoucher.Columns("QTTY").Width = 100
                v_dtgVATVoucher.Columns("QTTY").FormatSpecifier = "#,##0"
                v_dtgVATVoucher.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                v_dtgVATVoucher.Columns("PRICE").Width = 100
                v_dtgVATVoucher.Columns("PRICE").FormatSpecifier = "#,##0.00"
                v_dtgVATVoucher.Columns("VATRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                v_dtgVATVoucher.Columns("VATRATE").Width = 100
                v_dtgVATVoucher.Columns("VATRATE").FormatSpecifier = "#,##0.00"
                v_dtgVATVoucher.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                v_dtgVATVoucher.Columns("DESCRIPTION").Width = 150
                'Náº¡p vÃ o Panel
                tabVATVoucher.Controls.Add(v_dtgVATVoucher)

                'Hiá»‡n bá»™ Ä‘á»‹nh khoáº£n náº¿u cÃ³
                If Not mv_arrObjVAT Is Nothing Then
                    v_intCount = mv_arrObjVAT.GetLength(0)
                    If v_intCount > 0 Then
                        v_dtgVATVoucher.BeginInit()
                        For v_intIndex = 0 To v_intCount - 1 Step 1
                            If Not mv_arrObjVAT(v_intIndex) Is Nothing Then
                                Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgVATVoucher.DataRows.AddNew()
                                v_xDataRow.Cells("VOUCHERNO").Value = mv_arrObjVAT(v_intIndex).VOUCHERNO
                                v_xDataRow.Cells("VOUCHERTYPE").Value = mv_arrObjVAT(v_intIndex).VOUCHERTYPE
                                v_xDataRow.Cells("SERIENO").Value = mv_arrObjVAT(v_intIndex).SERIENO
                                v_xDataRow.Cells("VOUCHERDATE").Value = DDMMYYYY_SystemDate(mv_arrObjVAT(v_intIndex).VOUCHERDATE)
                                v_xDataRow.Cells("CUSTID").Value = mv_arrObjVAT(v_intIndex).CUSTID
                                v_xDataRow.Cells("TAXCODE").Value = mv_arrObjVAT(v_intIndex).TAXCODE
                                v_xDataRow.Cells("CUSTNAME").Value = mv_arrObjVAT(v_intIndex).CUSTNAME
                                v_xDataRow.Cells("ADDRESS").Value = mv_arrObjVAT(v_intIndex).ADDRESS
                                v_xDataRow.Cells("CONTENTS").Value = mv_arrObjVAT(v_intIndex).CONTENTS
                                v_xDataRow.Cells("QTTY").Value = mv_arrObjVAT(v_intIndex).QTTY
                                v_xDataRow.Cells("PRICE").Value = mv_arrObjVAT(v_intIndex).PRICE
                                v_xDataRow.Cells("VATRATE").Value = mv_arrObjVAT(v_intIndex).VATRATE
                                v_xDataRow.Cells("DESCRIPTION").Value = mv_arrObjVAT(v_intIndex).DESCRIPTION
                                v_xDataRow.EndEdit()
                            End If
                        Next
                        v_dtgVATVoucher.EndInit()
                    End If
                End If

                Me.tabTransact.Visible = True
                Me.tabTransact.Top = Me.pnTransDetail.Top + Me.pnTransDetail.Height + TABS_TOP + FIX_TABS_TOP
                Me.tabTransact.Height = TABS_HEIGHT
                Me.lblHelper.Top = Me.tabTransact.Top + Me.tabTransact.Height + TABS_TOP + FIX_TABS_TOP
                Me.btnOK.Top = Me.lblHelper.Top
                Me.btnVoucher.Top = Me.lblHelper.Top
                Me.btnCANCEL.Top = Me.lblHelper.Top
                Me.btnAdjust.Top = Me.lblHelper.Top
                Me.btnEntries.Top = Me.lblHelper.Top
                Me.btnReject.Top = Me.lblHelper.Top
                Me.btnApprove.Top = Me.lblHelper.Top
            Else
                Me.tabVATVoucher.Visible = False
            End If
        End If

        'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh
        Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_HEIGHT + TABS_TOP + FIX_TABS_TOP
    End Function


    'Private Function RetrieveFixedAssest()
    '    Dim v_dtgFA As GridEx, v_intCount, v_intIndex As Integer
    '    Me.tabFixedAssest.Controls.Clear()

    '    'Thá»ƒ hiá»‡n pháº§n Ä‘á»‹nh khoáº£n
    '    If Not mv_arrObjIEFMIS Is Nothing Then
    '        v_intCount = mv_arrObjIEFMIS.GetLength(0)
    '        If v_intCount > 0 Then
    '            'Khá»Ÿi táº¡o Grid chá»©a thÃ´ng tin Ä‘á»‹nh khoáº£n
    '            Dim i As Integer
    '            'Náº¡p Fixed Assest cho DataGrid
    '            v_dtgFA = New GridEx
    '            v_dtgFA.Dock = DockStyle.Fill
    '            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
    '            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
    '            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    '            v_dtgFA.FixedHeaderRows.Add(v_cmrHeader)
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("ACNAME", GetType(System.String)))
    '            v_dtgFA.Columns("ACNAME").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
    '            v_dtgFA.Columns("CCYCD").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
    '            v_dtgFA.Columns("PRICE").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("MIGROUP", GetType(System.String)))
    '            v_dtgFA.Columns("MIGROUP").ReadOnly = True
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("DEPTYPE", GetType(System.String)))
    '            v_dtgFA.Columns("DEPTYPE").ReadOnly = True
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("DEPTIME", GetType(System.Double)))
    '            v_dtgFA.Columns("DEPTIME").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("PERCENTAGE", GetType(System.Double)))
    '            v_dtgFA.Columns("PERCENTAGE").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("ACCUMULATE", GetType(System.Double)))
    '            v_dtgFA.Columns("ACCUMULATE").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("DRGLEXPAC", GetType(System.String)))
    '            v_dtgFA.Columns("DRGLEXPAC").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("CRGLDEPRAC", GetType(System.String)))
    '            v_dtgFA.Columns("CRGLDEPRAC").ReadOnly = False
    '            v_dtgFA.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
    '            v_dtgFA.Columns("DESCRIPTION").ReadOnly = False

    '            For i = 0 To v_dtgFA.Columns.Count - 1 Step 1
    '                v_dtgFA.Columns(i).Title = mv_ResourceManager.GetString("frmPostmap." & v_dtgFA.Columns(i).FieldName)
    '            Next

    '            v_dtgFA.Columns("ACNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("ACNAME").Width = 70
    '            v_dtgFA.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("CCYCD").Width = 60
    '            v_dtgFA.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("PRICE").Width = 100
    '            v_dtgFA.Columns("PRICE").FormatSpecifier = "#,##0.00"
    '            v_dtgFA.Columns("MIGROUP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("MIGROUP").Width = 100
    '            v_dtgFA.Columns("DEPTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
    '            v_dtgFA.Columns("DEPTYPE").Width = 70
    '            v_dtgFA.Columns("DEPTIME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("DEPTIME").Width = 100
    '            v_dtgFA.Columns("DEPTIME").FormatSpecifier = "#,##0"
    '            v_dtgFA.Columns("PERCENTAGE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("PERCENTAGE").Width = 100
    '            v_dtgFA.Columns("PERCENTAGE").FormatSpecifier = "#,##0.00"
    '            v_dtgFA.Columns("ACCUMULATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("ACCUMULATE").Width = 100
    '            v_dtgFA.Columns("ACCUMULATE").FormatSpecifier = "#,##0.00"
    '            v_dtgFA.Columns("DRGLEXPAC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '            v_dtgFA.Columns("DRGLEXPAC").Width = 100
    '            v_dtgFA.Columns("CRGLDEPRAC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
    '            v_dtgFA.Columns("CRGLDEPRAC").Width = 100
    '            v_dtgFA.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
    '            v_dtgFA.Columns("DESCRIPTION").Width = 150


    '            'Náº¡p vÃ o Panel
    '            tabFixedAssest.Controls.Add(v_dtgFA)

    '            If Not mv_arrObjIEFMIS Is Nothing Then
    '                v_intCount = mv_arrObjIEFMIS.GetLength(0)
    '                If v_intCount > 0 Then
    '                    v_dtgFA.BeginInit()
    '                    For v_intIndex = 0 To v_intCount - 1 Step 1
    '                        If Not mv_arrObjIEFMIS(v_intIndex) Is Nothing Then
    '                            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgFA.DataRows.AddNew()
    '                            v_xDataRow.Cells("ACNAME").Value = mv_arrObjIEFMIS(v_intIndex).ACNAME
    '                            v_xDataRow.Cells("CCYCD").Value = mv_arrObjIEFMIS(v_intIndex).CCYCD
    '                            v_xDataRow.Cells("PRICE").Value = mv_arrObjIEFMIS(v_intIndex).PRICE
    '                            v_xDataRow.Cells("MIGROUP").Value = mv_arrObjIEFMIS(v_intIndex).MIGROUP
    '                            v_xDataRow.Cells("DEPTYPE").Value = mv_arrObjIEFMIS(v_intIndex).DEPTYPE
    '                            v_xDataRow.Cells("DEPTIME").Value = mv_arrObjIEFMIS(v_intIndex).DEPTIME
    '                            v_xDataRow.Cells("PERCENTAGE").Value = mv_arrObjIEFMIS(v_intIndex).PERCENTAGE
    '                            v_xDataRow.Cells("ACCUMULATE").Value = mv_arrObjIEFMIS(v_intIndex).ACCUMULATE
    '                            v_xDataRow.Cells("DRGLEXPAC").Value = mv_arrObjIEFMIS(v_intIndex).DRGLEXPAC
    '                            v_xDataRow.Cells("CRGLDEPRAC").Value = mv_arrObjIEFMIS(v_intIndex).CRGLDEPRAC
    '                            v_xDataRow.Cells("DESCRIPTION").Value = mv_arrObjIEFMIS(v_intIndex).DESCRIPTION
    '                            v_xDataRow.EndEdit()
    '                        End If
    '                    Next
    '                    v_dtgFA.EndInit()
    '                End If
    '            End If
    '            Me.tabTransact.Visible = True
    '            Me.tabTransact.Top = Me.pnTransDetail.Top + Me.pnTransDetail.Height + TABS_TOP
    '            Me.tabTransact.Height = TABS_HEIGHT
    '            Me.lblHelper.Top = Me.tabTransact.Top + Me.tabTransact.Height + TABS_TOP
    '            Me.btnOK.Top = Me.lblHelper.Top
    '            Me.btnCANCEL.Top = Me.lblHelper.Top
    '            Me.btnAdjust.Top = Me.lblHelper.Top
    '            Me.btnEntries.Top = Me.lblHelper.Top
    '            Me.btnReject.Top = Me.lblHelper.Top
    '            Me.btnApprove.Top = Me.lblHelper.Top
    '        Else
    '            Me.tabFixedAssest.Visible = False
    '        End If
    '    End If

    '    'Ä?áº·t láº¡i Ä‘á»™ cao cá»§a mÃ n hÃ¬nh
    '    Me.Height = Me.btnOK.Top + Me.btnOK.Height + CONTROL_HEIGHT + TABS_TOP
    'End Function

    Private Sub DoResizeForm()

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmTransact." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmTransact." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmTransact." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            End If
        Next
        'Ä?áº·t format cá»§a DateTimePicker theo qui Ä‘á»‹nh chung
        Me.dtpValidateField.Format = DateTimePickerFormat.Custom
        Me.dtpValidateField.CustomFormat = gc_FORMAT_DATE
        Me.Text = mv_ResourceManager.GetString("frmTransact")
        Me.tabAccountEntry.Text = mv_ResourceManager.GetString("tabAccountEntry")
        Me.tabVATVoucher.Text = mv_ResourceManager.GetString("tabVATVoucher")
    End Sub

    Private Function getTransBGColor(ByVal pv_intColor As Integer) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_intColor
            Case 0 'Default color
                v_color = System.Drawing.SystemColors.Control
            Case 1 'Honeydew
                v_color = System.Drawing.Color.Honeydew
            Case 2 'LightGreen
                v_color = System.Drawing.Color.LightGreen
            Case 3 'DarkKhaki
                v_color = System.Drawing.Color.DarkKhaki
            Case 4 'Aquamarine
                v_color = System.Drawing.Color.Aquamarine
            Case 5 'Skyblue
                v_color = System.Drawing.Color.SkyBlue
            Case 6 'Violet
                v_color = System.Drawing.Color.Violet
            Case 7 'Lightpink
                v_color = System.Drawing.Color.LightPink
            Case 8 'LightSalomon
                v_color = System.Drawing.Color.LightSalmon
        End Select
        Return v_color
    End Function

    Public Sub ShowNextTran()
        Dim v_strSQL As String
        v_strSQL = "select TXNUM,TXDATE from TLLOG where AUTOID= (SELECT MAX(AUTOID) from TLLOG WHERE DELTD <> 'Y' AND TXSTATUS='" & TransactStatus.Pending & "')"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "SY.TLLOG", _
            gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        Dim v_strValue, v_strFLDNAME, v_strTXNUM, v_strTXDATE As String
        Dim i, j As Integer
        If v_nodeList.Count < 1 Then
            v_strTXNUM = ""
            v_strTXDATE = ""
        Else
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXNUM"
                                v_strTXNUM = Trim(v_strValue)
                            Case "TXDATE"
                                v_strTXDATE = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
        End If
        If v_strTXDATE.Length <> 0 And v_strTXNUM.Length <> 0 Then
            Dim frm As New frmTransact(UserLanguage)
            frm.LocalObject = gc_IsNotLocalMsg
            frm.ObjectName = ""
            frm.TxDate = v_strTXDATE
            frm.TxNum = v_strTXNUM
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.ShowDialog()
            'ViewMessage(v_strTXDATE, v_strTXNUM)
        Else
            MessageBox.Show(mv_ResourceManager.GetString("frmTransact.CanNotShowNext"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function CheckDate() As Boolean
        Try
            Dim v_strSQL, v_strTXDATE, v_strObjMsg, v_strValue, v_strFLDNAME As String

            v_strSQL = "SELECT VARVALUE TXDATE FROM SYSVAR WHERE VARNAME = 'CURRDATE' AND GRNAME = 'SYSTEM' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDATE"
                                v_strTXDATE = Trim(v_strValue)
                        End Select
                    End With
                Next
            End If

            'me.BusDate
            If Trim(CStr(Me.BusDate)) = Trim(v_strTXDATE) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub PrintTransact(ByRef pv_VoucherID As String) 'linh add
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_ctl As Control

            Dim v_strRptFilePath As String = pv_VoucherID & ".rpt"
            Dim v_blnFileExists As Boolean = False
            Dim v_strReportDirectory, v_strReportTempDirectory As String

            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_strOffName, v_strTlName, v_strTXSTATUS As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String

            'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
            Dim v_blnVietnamese As Boolean
            Dim v_strDValue As String
            Dim v_strMValue As String
            Dim v_strYValue As String
            Dim v_strTemp As String
            Dim d As New Date
            'Thanh.Tran end.
            v_strReportDirectory = GetReportDirectory()
            v_strReportTempDirectory = GetReportTempDirectory(v_strReportDirectory)
            Dim v_dirInfo As New DirectoryInfo(v_strReportDirectory)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_file As FileInfo
            'AnTB add ten chi nhanh
            Dim v_strBRNAME As String
            Dim v_strTxTime As String

            ' Check if report template is exists
            For Each v_file In v_fileInfo
                If v_file.Name = v_strRptFilePath Then
                    v_blnFileExists = True
                    Exit For
                End If
            Next

            'TruongLD Add 30/03/2010
            If v_blnFileExists = False Then
                MessageBox.Show(mv_ResourceManager.GetString("FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'End TruongLD

            ' LINH05122008-001 - voucher
            v_strSQL = "select tllog.TLID,tlprofiles.TLFULLNAME TLNAME, tllog.txstatus STATUS from tllog, tlprofiles where txnum='" & Me.TxNum & "' and tllog.TLID=tlprofiles.tlid "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TLNAME"
                                v_strTlName = v_strValue.Trim()
                            Case "STATUS"
                                v_strTXSTATUS = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next
            v_strSQL = " select tllog.TLID,tlprofiles.TLFULLNAME OFFNAME, tllog.chktime  from tllog, tlprofiles where txnum='" & Me.TxNum & "' and tllog.offid =tlprofiles.tlid"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "OFFNAME"
                                v_strOffName = v_strValue.Trim()
                            Case "CHKTIME"
                                v_strTxTime = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next
            ' end LINH05122008-001 - voucher
            'AnTB add 10/03/2015 them ten chi nhanh trong chung tu
            v_strSQL = " select brname from brgrp where brid = '" & Me.BranchId & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "BRNAME"
                                v_strBRNAME = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next
            'End AnTB add 10/03/2015 them ten chi nhanh trong chung tu
            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(v_strReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName As String
            Dim v_strNumberToText As String = "Không đồng"

            GetReportFormularValue()

            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
            For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name
                For j As Integer = 0 To mv_arrObjFields.Length - 1
                    Try
                        If (v_strFormulaName.ToUpper = (mv_arrObjFields(j).PDefName)) Then
                            For Each v_ctl In Me.pnTransDetail.Controls

                                If Trim(Replace(v_ctl.Name, PREFIXED_MSKDATA, "")) = mv_arrObjFields(j).FieldName Then
                                    If Not v_strFormulaName.Equals("P_AMT") Then
                                        '26/07/2018 DieuNDA: Fix loi in chung tu truong hop co dau nhay
                                        'v_crFFieldDefinition.Text = "'" & v_ctl.Text & "'"
                                        v_crFFieldDefinition.Text = "'" & v_ctl.Text.Replace("'", "''") & "'"
                                        'End 26/07/2018 DieuNDA: Fix loi in chung tu truong hop co dau nhay
                                    Else
                                        v_crFFieldDefinition.Text = "'" & v_ctl.Text & "'"
                                        v_strNumberToText = modCommond.NumberToText(v_ctl.Text)
                                    End If


                                End If
                            Next
                        End If
                        If (v_strFormulaName.ToUpper = (mv_arrObjFields(j).PDefName) & "_2STRING") Then
                            For Each v_ctl In Me.pnTransDetail.Controls
                                If Trim(Replace(v_ctl.Name, PREFIXED_MSKDATA, "")) = mv_arrObjFields(j).FieldName Then
                                    v_crFFieldDefinition.Text = "'" & IIf(IsNumeric(v_ctl.Text), Num2Text(v_ctl.Text), "") & "'"
                                End If
                            Next
                        End If

                    Catch
                    End Try
                Next

                Dim v_intCount, v_intIndex As Integer
                If Not mv_arrObjAccounts Is Nothing Then
                    v_intCount = mv_arrObjAccounts.GetLength(0)
                End If

                Select Case v_strFormulaName.ToUpper()
                    Case "P_TOWORD"
                        v_crFFieldDefinition.Text = "'" & v_strNumberToText & "'"
                    Case "P_DRGLACCOUNT"
                        For v_intIndex = 0 To v_intCount - 1 Step 1
                            If Not mv_arrObjAccounts(v_intIndex) Is Nothing Then
                                If mv_arrObjAccounts(v_intIndex).DORC.Trim = "D" Then
                                    v_crFFieldDefinition.Text = "'" & mv_arrObjAccounts(v_intIndex).ACCTNO & "'"
                                    Exit For
                                End If
                            End If
                        Next
                    Case "P_CRGLACCOUNT"
                        For v_intIndex = 0 To v_intCount - 1 Step 1
                            If Not mv_arrObjAccounts(v_intIndex) Is Nothing Then
                                If mv_arrObjAccounts(v_intIndex).DORC.Trim = "C" Then
                                    v_crFFieldDefinition.Text = "'" & mv_arrObjAccounts(v_intIndex).ACCTNO & "'"
                                    Exit For
                                End If
                            End If
                        Next
                    Case "P_DATE"
                        v_crFFieldDefinition.Text = "'" & Me.TxDate & "'"
                    Case "P_BUSDATE"
                        v_crFFieldDefinition.Text = "'" & Me.mv_strTxBusDate & "'"
                    Case "P_TXNUM"
                        v_crFFieldDefinition.Text = "'" & Me.TxNum & "'"
                    Case "P_TLNAME"
                        v_crFFieldDefinition.Text = "'" & v_strTlName & "'"
                    Case "P_OFFNAME"
                        v_crFFieldDefinition.Text = "'" & v_strOffName & "'"
                    Case "P_BRID"
                        v_crFFieldDefinition.Text = "'" & Me.BranchId & "'"
                    Case "P_BRNAME"
                        v_crFFieldDefinition.Text = "'" & v_strBRNAME & "'"
                    Case "P_TXTIME"
                        v_crFFieldDefinition.Text = "'" & v_strTxTime & "'"
                    Case "P_STATUS"
                        v_crFFieldDefinition.Text = "'" & v_strTXSTATUS & "'"
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HEADOFFICE & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_FORMULAR_DEALINGCUSTODYCD
                        v_crFFieldDefinition.Text = "'" & DEALINGCUSTODYCD & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & CreatedDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Me.TellerId & "'"
                    Case gc_RPT_FORMULAR_DEPOSITID
                        v_crFFieldDefinition.Text = "'" & DepositID & "'"
                End Select
            Next

            'TruongLD Add 14/09/2011
            'Neu dung Culture la "vi-VN" --> khong su dung duoc func Convert Number to Text --> Chuyen ve "en-US"
            'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
            Dim v_strOldCultureName As String = String.Empty
            v_strOldCultureName = SetCultureInfo("en-US")
            'End TruongLD

            If v_rptDocument.IsLoaded Then
                'Export to PDF
                v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, v_strReportTempDirectory & pv_VoucherID & ".rpt")
            End If

            Dim v_frm As New frmReportView
            Dim v_Path As String = Environment.CurrentDirectory
            v_frm.RptFileName = v_strReportTempDirectory & pv_VoucherID & ".rpt"
            v_frm.RptName = pv_VoucherID
            v_frm.ShowDialog()
            Environment.CurrentDirectory = v_Path
            'TruongLD Add 14/09/2011
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            'End TruongLD

        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub GetReportFormularValue()
        Try
            'Get common values from SYSVAR table
            Dim v_strSQL As String = "SELECT VARNAME, VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND varname IN ('DEPOSITID','COMPANYCD','BRADDRESS_EN','FAX','PHONE','BRADDRESS','BRPHONEFAX','BRNAME', 'HEADOFFICE', 'DEALINGCUSTODYCD')"
            Dim v_strObjMsg As String = String.Empty
            'TruongLD Comment when convert
            'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
            'TruongLD Add when convert
            Dim v_ws As New BDSRptDeliveryManagement
            'End TruongLD
            Dim v_intRowCount As Integer
            Dim v_strVarName, v_strVarValue As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_xmlNode As Xml.XmlNode

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count

            If (v_intRowCount > 0) Then
                v_xmlNode = v_xmlDocument.FirstChild

                For i As Integer = 0 To v_intRowCount - 1
                    v_strVarName = v_xmlNode.ChildNodes(i).ChildNodes(0).InnerText.Trim().ToUpper()

                    Select Case v_strVarName
                        Case "HEADOFFICE"
                            HEADOFFICE = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME"
                            BranchName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS"
                            BranchAddress = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX"
                            BranchPhoneFax = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "DEALINGCUSTODYCD"
                            DEALINGCUSTODYCD = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case gc_RPT_FORMULAR_ADDRESS_EN
                            BranchAddress_EN = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case gc_RPT_FORMULAR_DEPOSITID
                            DepositID = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()

                    End Select
                Next
                'TruongLD them 2010/11/03
                CreatedDate = "Ngày " & Me.BusDate.Substring(0, 2) & " tháng " & Me.BusDate.Substring(3, 2) _
                                & " năm " & Me.BusDate.Substring(6)
                CreatedDate_En = Me.BusDate.Substring(0, 2) & " / " & Me.BusDate.Substring(3, 2) _
                    & " / " & Me.BusDate.Substring(6)
                'End TruongLD
            Else
                BranchName = String.Empty
                BranchAddress = String.Empty
                BranchPhoneFax = String.Empty
                DEALINGCUSTODYCD = String.Empty
                HEADOFFICE = String.Empty
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetReportDirectory() As String 'linh add
        Try
            'Get report directory from SYSVAL table on BDS
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            'TruongLD Comment when convert
            'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
            'TruongLD Add when convert
            Dim v_ws As New BDSRptDeliveryManagement
            'End TruongLD
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String
            Dim v_strReportDir As String = String.Empty

            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'DIRRPTFILES'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strReportDir = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next

            If Not (v_strReportDir.Length > 0) Then
                v_strReportDir = GetDirectoryName(ExecutablePath) & "\REPORTS\"
            End If
            v_strReportDir = v_strReportDir.Trim() & IIf(v_strReportDir.Trim().Substring(v_strReportDir.Trim().Length - 1) = "\", "", "\")

            'Check if report directory is exists; otherwise, create it
            Dim v_dirInfo As New DirectoryInfo(v_strReportDir)
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If
            'Check if report temporary directory is exists; otherwise, create it
            v_dirInfo = New DirectoryInfo(GetReportTempDirectory(v_strReportDir))
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If

            Return v_strReportDir
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Function GetReportTempDirectory(ByVal pv_strReportDir As String) As String
        Return pv_strReportDir & "TEMP\"
    End Function

    Private Function ShowValMsg(ByVal pv_arrObjFldVal As CFieldVal, ByVal pv_strLanguage As String)
        If pv_strLanguage = "EN" Then
            If pv_arrObjFldVal.CHKLEV = gc_INFO_MESSAGE Then
                MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return True
            ElseIf pv_arrObjFldVal.CHKLEV = gc_WARNING_MESSAGE Then
                If MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Ok Then
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return False
            End If
        Else
            If pv_arrObjFldVal.CHKLEV = gc_INFO_MESSAGE Then
                MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return True
            ElseIf pv_arrObjFldVal.CHKLEV = gc_WARNING_MESSAGE Then
                If MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Ok Then
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return False
            End If
        End If
        Return True
    End Function

#End Region

#Region " Overridable Function "
    'Function GetBankBalance(ByVal pv_strACCTNO As String) As String
    '    Try
    '        Dim v_strClause, v_strObjMsg, v_strValue As String
    '        Dim v_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New BDSDeliveryManagement
    '        'Tao message gui len HOST de xu ly
    '        v_strClause = v_strValue
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , pv_strACCTNO)
    '        v_ws.Message(v_strObjMsg)
    '        'Lay gia tri tra ve
    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
    '        v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

    '        Return v_strValue
    '    Catch ex As Exception
    '        'Throw ex
    '        Return "0"
    '    End Try
    'End Function
    Function GetDBFunction(ByVal pv_strFunctionName As String, ByVal pv_strParameters As String) As String
        Try
            'Cau truc pv_strParameters: giatri1##giatri2##...##giatrin
            Dim v_strClause, v_strObjMsg, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_ws As New BDSDelivery.BDSDelivery
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strClause = v_strValue
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, pv_strFunctionName, pv_strParameters, "ExecDBFunction")
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Return v_strValue
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetInventory(ByVal v_strFldSource As String, ByVal v_strFldDesc As String, ByVal v_strInvName As String, ByVal v_strInvFormat As String)
        Try
            Dim v_strModule, v_strValue, v_strFldName As String
            Dim v_ctlmskData As FlexMaskEditBox, v_ctrl As Control
            Dim v_strTemp, v_strINVReturn As String, v_intPos As Integer
            v_strModule = Mid(v_strFldSource, 1, 2)
            v_strFldSource = Mid(v_strFldSource, 3)

            If Not mv_arrObjFields Is Nothing Then
                'XÃ¡c Ä‘á»‹nh giÃ¡ trá»‹ cá»§a cÃ¡c trÆ°á»?ng dÃ¹ng Ä‘á»ƒ gá»™p vá»›i Inventory Name
                For Each v_ctrl In Me.pnTransDetail.Controls
                    If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                        v_ctlmskData = CType(v_ctrl, FlexMaskEditBox)
                        v_strFldName = Mid(v_ctlmskData.Name, Len(PREFIXED_MSKDATA) + 1)
                        If InStr(v_strFldSource, v_strFldName & "@") > 0 Then
                            If Len(v_ctlmskData.Text) > 0 Then
                                v_strValue = v_strValue & v_ctlmskData.Text
                            Else
                                'Náº¿u chÆ°a cÃ³ giÃ¡ trá»‹ thÃ¬ khÃ´ng táº¡o Inventory ná»¯a
                                Exit Sub
                            End If

                        End If
                    End If
                Next

                'Náº¿u cÃ³ láº¥y Inventory thÃ¬ pháº£i xÃ¡c Ä‘á»‹nh giÃ¡ trá»‹ cá»§a trÆ°á»?ng nguá»“n
                If Len(v_strInvName) > 0 Then
                    'Cáº¥u trÃºc cá»§a 01 inventoy lÃ : PhÃ¢n há»‡ + MÃ£ chi nhÃ¡nh + TÃªn Inventory + GiÃ¡ trá»‹ trÆ°á»?ng nguá»“n
                    'v_strValue = v_strModule & Me.BranchId & v_strInvName & v_strValue
                    v_strValue = v_strModule & Me.BranchId & v_strInvName

                    'Gá»?i hÃ m Ä‘á»ƒ xÃ¡c Ä‘á»‹nh Inventory
                    Dim v_strClause, v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
                    v_strClause = v_strValue
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
                    v_ws.Message(v_strObjMsg)
                    'Láº¥y giÃ¡ trá»‹ tráº£ vá»? (tráº£ táº¡i má»‡nh Ä‘á»? Clause luÃ´n)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                    v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

                    'Táº¡o theo cáº¥u trÃºc InvFormat
                    v_intPos = 1
                    v_strINVReturn = String.Empty
                    While v_intPos < Len(v_strInvFormat)
                        v_strTemp = Mid(v_strInvFormat, v_intPos, 2)
                        If v_strTemp = "BR" Then
                            v_strINVReturn = v_strINVReturn & Me.BranchId
                        Else
                            'Láº¥y giÃ¡ trá»‹ hiá»‡n táº¡i cá»§a trÆ°á»?ng nÃ o Ä‘Ã³
                            For Each v_ctrl In Me.pnTransDetail.Controls
                                If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                                    v_ctlmskData = CType(v_ctrl, FlexMaskEditBox)
                                    v_strFldName = Mid(v_ctlmskData.Name, Len(PREFIXED_MSKDATA) + 1)
                                    If Trim(v_strTemp) = Trim(v_strFldName) Then
                                        v_strINVReturn = v_strINVReturn & CType(v_ctrl, FlexMaskEditBox).Text
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                        v_intPos = v_intPos + 2
                    End While

                    'Ä?áº·t Inventory cho trÆ°á»?ng Ä‘Ã­ch: 
                    For Each v_ctrl In Me.pnTransDetail.Controls
                        If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                            v_ctlmskData = CType(v_ctrl, FlexMaskEditBox)
                            v_strFldName = Mid(v_ctlmskData.Name, Len(PREFIXED_MSKDATA) + 1)
                            If Trim(v_strFldDesc) = Trim(v_strFldName) Then
                                v_strTemp = Strings.Right(gc_FORMAT_ODAUTOID & v_strValue, CType(v_ctrl, FlexMaskEditBox).MaxLength - Len(v_strINVReturn))
                                CType(v_ctrl, FlexMaskEditBox).Text = v_strINVReturn & v_strTemp
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub OnSubmit()

        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        'Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_strErrorSource, v_strErrorMessage, v_strWarningMessage, v_strInfoMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String, v_strRef As String
        Try
            If Me.pnTransDetail.Controls.Count = 0 Then 'Náº¡p mÃ n hÃ¬nh láº§n Ä‘áº§u
                If Len(Trim(mskTransCode.Text)) = 4 Then
                    mv_xmlDocumentInquiryData.RemoveAll()
                    LoadScreen(Trim(mskTransCode.Text))
                End If
            Else    'Ä?Ã£ nháº­p thÃ´ng tin trÃªn mÃ n hÃ¬nh vÃ  submit gá»­i lÃªn APP-SERVER Ä‘á»ƒ xá»­ lÃ½
                If mskTransCode.Enabled Then 'Submit láº§n Ä‘áº§u tiÃªn
                    'Khá»Ÿi táº¡o Ä‘iá»‡n giao dá»‹ch
                    MessageData = vbNullString
                    '1. Verify vÃ  táº¡o Ä‘iá»‡n giao dá»‹ch
                    v_strNEXTTX = Trim(mskTransCode.Text)
                    If Not VerifyRules(v_strTxMsg, v_strNEXTTX) Then
                        Exit Sub
                    End If
                    'Improve Caching
                    mv_strOrgRequestMessage = v_strTxMsg
                    'TungNT added - thuc hien hold neu giao dich nao khai bao hold truoc
                    v_strRef = "<![CDATA[" & mv_strOrgRequestMessage & "]]>"
                    v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankHoldDirect", , , v_strRef, Me.WsName, Me.IpAddress)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    'End
                    '2. Ä?áº©y Ä‘iá»‡n giao dá»‹ch lÃªn APP-SERVER
                    v_lngError = v_ws.Message(v_strTxMsg)

                    'get Warning Message
                    GetWarningFromMessage(v_strTxMsg, v_strWarningMessage, v_strInfoMessage)
                    Cursor.Current = Cursors.Default
                    If v_strInfoMessage <> String.Empty Then
                        MsgBox(v_strInfoMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    If v_strWarningMessage <> String.Empty Then
                        If MsgBox(v_strWarningMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
                            Exit Sub
                        End If
                    End If

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'ThÃ´ng bÃ¡o lá»—i
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'TungNT added - for corebank
                            'Truong hop thieu tien voi 3384 thi bo qua canh bao lan dau tien,
                            'dong thoi tinh toan so du thuc hien de hold them

                            'End

                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        Else
                            'Láº¥y thÃªm nguyÃªn nhÃ¢n duyá»‡t
                            ' GetErrorFromMessage(v_strTxMsg, v_strErrorMessage)
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            If AutoSubmitWhenExecute = False Then
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            End If

                        End If
                    End If

                    v_xmlDocument.LoadXml(v_strTxMsg)
                    v_attrColl = v_xmlDocument.DocumentElement.Attributes

                    '3. Nháº­n vÃ  refersh láº¡i mÃ n hÃ¬nh theo káº¿t quáº£ xá»­ lÃ½ trÃªn APP-SERVER gá»­i vá»?
                    If Mid(Trim(mskTransCode.Text), 3, 2) = "71" And Trim(mskTransCode.Text) <> gc_RM_INQUIRY Then ' Then
                        'Tra cá»©u thÃ´ng tin
                        'LogError.Write("Error source: 1171 Error code: " & v_strTxMsg & "Error message: " & v_strTxMsg, EventLogEntryType.Information)
                        If (Len(v_strNEXTTX) = 0) Or (v_strNEXTTX = gc_CF_CONTRACTINQUIRY) Then
                            v_strNEXTTX = Trim(mskTransCode.Text)
                            ShowInquiry(v_strNEXTTX, v_strTxMsg)
                        End If
                        'Náº¡p mÃ n hÃ¬nh giao dá»‹ch káº¿ tiáº¿p
                        If Len(v_strNEXTTX) > 0 Then
                            'Check xem giao dá»‹ch káº¿ tiáº¿p cÃ³ pháº£i lÃ  giao dá»‹ch cháº¡y Batch khÃ´ng
                            Dim v_strCmdInquiry, v_strTLTXCD As String
                            v_strTLTXCD = ""
                            v_strCmdInquiry = "SELECT TLTXCD FROM TLTX WHERE TLTX.TLTXCD='" & v_strNEXTTX & "' AND TLTX.DIRECT='N' AND CHAIN='N'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
                            v_ws.Message(v_strObjMsg)

                            Dim v_xmlChkDocument As New System.Xml.XmlDocument
                            Dim v_nodeList As Xml.XmlNodeList
                            Dim v_nodeEntry As Xml.XmlNode
                            Dim v_strFLDNAME As String
                            Dim v_strValue As String

                            v_xmlChkDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlChkDocument.SelectNodes("/ObjectMessage/ObjData")

                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strValue = .InnerText.ToString
                                        Select Case Trim(v_strFLDNAME)
                                            Case "TLTXCD"
                                                v_strTLTXCD = Trim(v_strValue)
                                                Exit For
                                        End Select
                                    End With
                                Next
                            Next

                            If Len(v_strTLTXCD) = 0 Then
                                LoadScreen(v_strNEXTTX, True, , v_strTxMsg)
                                Me.ActiveControl = Me.mskTransCode
                                SendKeys.Send("{Tab}")

                                If Not Me.pnTransDetail.Controls(PREFIXED_MSKDATA & "BUSDATE") Is Nothing Then
                                    Me.ActiveControl = Me.pnTransDetail.Controls(PREFIXED_MSKDATA & "BUSDATE")
                                End If
                            Else
                                'MessageBox.Show("Can not execute batch transaction manually!")
                                MessageBox.Show(mv_ResourceManager.GetString("CANNOTEXCUTETRANSACT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else
                            ResetScreen()
                        End If

                    ElseIf Trim(mskTransCode.Text) = gc_OD_CLEARINGINQUIRY Then
                        v_strNEXTTX = Trim(mskTransCode.Text)
                        ShowInquiry(v_strNEXTTX, v_strTxMsg)
                        'Náº¡p mÃ n hÃ¬nh giao dá»‹ch káº¿ tiáº¿p
                        If Len(v_strNEXTTX) > 0 Then
                            LoadScreen(v_strNEXTTX, True, , v_strTxMsg)
                        Else
                            ResetScreen()
                        End If
                        'ElseIf Mid(Trim(mskTransCode.Text), 3, 2) = "72" _
                        '    Or Trim(mskTransCode.Text) = gc_CI_GETINTTRANS Or Trim(mskTransCode.Text) = gc_CI_AVERAGE_BALANCE Then
                        '    'Tra cá»©u lá»‹ch sá»­ giao dá»‹ch
                        '    ShowHistory(Trim(mskTransCode.Text), v_strTxMsg)
                        '    ResetScreen()
                    ElseIf Trim(mskTransCode.Text) = gc_OD_IBT_SETTLEMENT Then
                        'Tra cá»©u lá»‹ch sá»­ giao dá»‹ch
                        ShowHistory(Trim(mskTransCode.Text), v_strTxMsg)
                        ResetScreen()
                    ElseIf Trim(mskTransCode.Text) = gc_SE_COSTPRICE_HISTORY Then
                        'Tra cá»©u lá»‹ch sá»­ giao dá»‹ch
                        ShowHistory(Trim(mskTransCode.Text), v_strTxMsg)
                        ResetScreen()
                    Else
                        'Giao dá»‹ch khÃ¡c: Kiá»ƒm tra cÃ³ lá»—i tráº£ vá»? khÃ´ng

                        'Láº¥y sá»‘ láº§n SUBMIT
                        v_intNOSUBMIT = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeNOSUBMIT), Xml.XmlAttribute).Value)

                        Dim v_strLate As String = CType(v_attrColl.GetNamedItem(gc_AtributeLATE), Xml.XmlAttribute).Value
                        If v_intNOSUBMIT = 2 And String.Compare(v_strLate, "0") = 0 Then
                            'Náº¿u giao dá»‹ch cáº§n 02 láº§n SUBMIT thÃ¬ Disable mskTransCode vÃ  hiá»ƒn thá»‹ láº¡i thÃ´ng tin tráº£ vá»?
                            DisplayConfirm(v_xmlDocument)
                            MessageData = v_xmlDocument.InnerXml
                            DisplayButton()
                        Else
                            'Náº¿u giao dá»‹ch chá»‰ 01 láº§n SUBMIT thÃ¬ Reset láº¡i mÃ n hinh
                            If AutoClosedWhenOK Then
                                OnClose()
                            Else
                                ResetScreen()
                            End If
                        End If
                    End If

                    Me.TxNum = CStr(v_attrColl.GetNamedItem(gc_AtributeTXNUM).Value)
                    Me.TxDate = CStr(v_attrColl.GetNamedItem(gc_AtributeTXDATE).Value)

                Else 'Submit láº§n thá»© hai (confirm)
                    'Náº¡p cÃ¡c mÃ£ Checker ID Ä‘á»ƒ duyá»‡t (checker 1, checker 2)
                    'Ä?áº©y láº¡i lá»‡nh lÃªn APP-SRV
                    v_strTxMsg = Me.MessageData
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'ThÃ´ng bÃ¡o lá»—i
                        If mskTransCode.Text = gc_CF_REMAP_TOKEN Then
                            Dim v_xmlErrorDocument As XmlDocumentEx
                            v_xmlErrorDocument = New XmlDocumentEx()
                            v_xmlErrorDocument.LoadXml(v_strTxMsg)
                            Dim v_xmlerrorNode = v_xmlErrorDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='p_err_message']")
                            If Not (v_xmlerrorNode Is Nothing) Then
                                v_strErrorMessage = v_xmlerrorNode.InnerText
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            Else
                                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                        Else
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                    End If
                    If AutoClosedWhenOK Then
                        OnClose()
                    Else
                        ResetScreen()
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub ShowInquiry(ByRef v_strTLTXCD As String, ByRef v_strXmlData As String)
        
    End Sub

    Public Overridable Sub ShowHistory(ByVal v_strTLTXCD As String, ByVal v_strXmlData As String)
        
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

   

    Public Overridable Sub mskData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_mskctrl As FlexMaskEditBox
            Dim v_txtctrl As TextBox
            Dim v_int As Integer = 0
            v_int = CType(sender, Control).Tag
            'Chá»?n toÃ n bá»™ pháº§n dá»¯ liá»‡u Ä‘ang cÃ³
            If (TypeOf (sender) Is FlexMaskEditBox) Then
                v_mskctrl = CType(sender, FlexMaskEditBox)
                'Modified by ChienTD: DÃ¹ng hÃ m SelectText lá»±a chá»?n pháº§n dá»¯ liá»‡u
                'v_ctrl.SelectText()
                If mv_arrObjFields(v_int).ColumnName = "CUSTODYCD" Or mv_arrObjFields(v_int).ColumnName = "BCUSTODYCD" Or mv_arrObjFields(v_int).ColumnName = "SCUSTODYCD" Then
                    If Len(v_mskctrl.Text) >= gc_COMPANY_CODE.Length Then
                        v_mskctrl.SelectionStart = 0
                        v_mskctrl.SelectionLength = Len(v_mskctrl.Text)
                    Else
                        v_mskctrl.SelectionStart = gc_COMPANY_CODE.Length
                        v_mskctrl.SelectionLength = Len(v_mskctrl.Text) - gc_COMPANY_CODE.Length
                    End If
                Else
                    v_mskctrl.SelectionStart = 0
                    v_mskctrl.SelectionLength = Len(v_mskctrl.Text)
                End If

            ElseIf (TypeOf (sender) Is TextBox) Then
                v_txtctrl = CType(sender, TextBox)
                If mv_arrObjFields(v_int).ColumnName = "CUSTODYCD" Or mv_arrObjFields(v_int).ColumnName = "BCUSTODYCD" Or mv_arrObjFields(v_int).ColumnName = "SCUSTODYCD" Then
                    If Len(v_txtctrl.Text) >= gc_COMPANY_CODE.Length Then
                        v_txtctrl.SelectionStart = gc_COMPANY_CODE.Length
                        v_txtctrl.SelectionLength = Len(v_txtctrl.Text) - gc_COMPANY_CODE.Length
                    Else
                        v_txtctrl.SelectionStart = 0
                        v_txtctrl.SelectionLength = Len(v_txtctrl.Text)
                    End If
                Else
                    v_txtctrl.SelectionStart = 0
                    v_txtctrl.SelectionLength = Len(v_txtctrl.Text)
                End If
            
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub rtbData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_rtbctrl As RichTextBox
            Dim v_int As Integer = 0
            v_int = CType(sender, Control).Tag
            'Chá»?n toÃ n bá»™ pháº§n dá»¯ liá»‡u Ä‘ang cÃ³
            If (TypeOf (sender) Is RichTextBox) Then
                v_rtbctrl = CType(sender, RichTextBox)
                v_rtbctrl.SelectionStart = 0
                v_rtbctrl.SelectionLength = Len(v_rtbctrl.Text)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub v_cboData_Validating(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_bolCheck As Boolean = False
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub v_cboData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_strObjMsg, v_strDATAObjMsg As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_xmlATXDocument As New Xml.XmlDocument

        Dim strFLDNAME As String, v_intIndex As Integer
        Dim v_strSQLCMD, v_strFULLDATA As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
        Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
        Dim v_strModule, v_strFldSource, v_strFldDesc As String
        Try

            Dim v_bolCheck As Boolean = False
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    If mv_arrObjFields(v_intIndex).ControlType = "C" Then
                        v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    Else
                        v_strFieldValue = CType(sender, Control).Text
                    End If

                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    If mv_arrObjFields(v_intIndex).Mandatory = True And Len(v_strFieldValue) = 0 And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_COMBO").Replace("{FIELDNAME}", mv_arrObjFields(v_intIndex).Caption), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True
                        Exit Sub
                    End If

                    If mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        'Lay thong tin chung ve giao dich
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        'Luu tru danh sach ket qua tra ve
                        v_strFULLDATA = v_strObjMsg
                        'Hien thi du lieu tu Lookup data
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    End If

                    'Fill du lieu lookup tá»« HOST (Fill dá»¯ liá»‡u cho Refvalue vÃ  cÃ¡c control khÃ¡c)
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Kiem tra du lieu nhap vao co dung khong
                            v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                            v_strKeyVal = Replace(v_strFieldValue, ".", "")
                            'Lay KeyName
                            v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                                & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                                & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case "KEYNAME"
                                                    v_strKeyName = Trim(v_strValue)
                                                Case "SEARCHCMDSQL"
                                                    v_strSEARCHSQL = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                Next
                                Dim v_strClause As String
                                v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If

                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                                v_ws.Message(v_strObjMsg)
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                                'Fill Refval
                                v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                            & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If


                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                v_ws.Message(v_strObjMsg)
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                If v_nodeList.Count > 0 Then
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                v_strValue = Trim(.InnerText)
                                                Select Case v_strFLDNAME
                                                    Case "FIELDCODE"
                                                        v_strFIELDCODE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next
                                    Next
                                    v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                    Else
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                    End If

                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                    v_ws.Message(v_strObjMsg)
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    If v_nodeList.Count > 0 Then
                                        For i As Integer = 0 To v_nodeList.Count - 1
                                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                With v_nodeList.Item(i).ChildNodes(j)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    v_strValue = Trim(.InnerText)
                                                    Select Case v_strFLDNAME
                                                        Case v_strFIELDCODE
                                                            v_strRefValue = v_strValue
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        If Len(v_strRefValue) > 0 Then
                                            'Fill Refval 
                                            Dim ctl As Control
                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                            ctl.Top = sender.Top
                                            ctl.Text = v_strRefValue
                                            ctl.Visible = True
                                            mv_strCustName = v_strRefValue
                                        End If
                                    Else
                                        'If mv_arrObjFields(v_intIndex).Mandatory = True Then
                                        '    MessageBox.Show(mv_ResourceManager.GetString("ERR_DATA_NOTFOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        '    e.Cancel = True
                                        '    Exit Sub
                                        'End If
                                    End If
                                End If
                            End If
                        End If

                        'ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        '    v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        '    'Lay thong tin chung ve giao dich
                        '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        '    v_ws.Message(v_strObjMsg)
                        '    'Luu tru danh sach ket qua tra ve
                        '    v_strFULLDATA = v_strObjMsg
                        '    'Hien thi du lieu tu Lookup data
                        '    FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    End If

                    'Reset gia tri
                    If mv_retREFFIELD = mv_arrObjFields(v_intIndex).FieldName Then
                        mv_retREFFIELD = String.Empty
                        mv_retROLETYPE = String.Empty
                        mv_retCUSTID = String.Empty
                        mv_retCUSTNAME = String.Empty
                        mv_retIDNUMBER = String.Empty
                        mv_retIDDATE = String.Empty
                        mv_retIDPLACE = String.Empty
                        mv_retADDRESS = String.Empty
                    End If
                End If
            End If
            Dim lngErr As Integer = ERR_SYSTEM_OK
            lngErr = ExecFldval(v_xmlATXDocument, v_intIndex)
            If lngErr = ERR_SYSTEM_START Then
                If Not ShowValMsg(mv_arrObjFldVals(v_intIndex), Me.UserLanguage) Then
                    Me.pnTransDetail.Controls(v_intIndex).Focus()
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
            v_xmlATXDocument = Nothing
        End Try
    End Sub
    'Kiem tra ngay nhap co phai ngay lam viec ko
    Private Sub v_ctl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim v_strSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_xmlDocument1 As New Xml.XmlDocument
        Dim v_nodeList1 As Xml.XmlNodeList
        Dim mv_strTxBusDate As String
        Try
            mv_strTxBusDate = sender.Text
            v_strSQL = "SELECT * FROM SBCLDR WHERE CLDRTYPE ='000' and SBDATE = TO_DATE('" & mv_strTxBusDate & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument1.LoadXml(v_strObjMsg)
            v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList1.Count >= 1 Then
                MessageBox.Show(mv_ResourceManager.GetString("ERR_POSTING_DATE_MUST_BE_WORK_DATE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.pnTransDetail.Controls(1).Focus()
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Private Sub mskData_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_intIndex As Integer, v_strFLDNAME, v_strFieldValue As String
        Try
            'Xac dinh cac loai phi giao dich
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                v_strFLDNAME = mv_arrObjFields(v_intIndex).ColumnName
                If v_strFLDNAME.IndexOf(PREFIXED_FLDNAME_FEECODE) <> -1 Then
                    v_strFieldValue = CType(sender, Control).Text.Trim
                    If v_strFieldValue.Length > 0 Then
                        v_strFieldValue = "'" & v_strFieldValue & "'"
                        If Not mv_strListOfTXFeeCode.IndexOf(v_strFieldValue) > 0 Then
                            If mv_strListOfTXFeeCode.Length = 0 Then
                                mv_strListOfTXFeeCode = v_strFieldValue
                            Else
                                mv_strListOfTXFeeCode = v_strFieldValue & "," & mv_strListOfTXFeeCode
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub rtbData_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_intIndex As Integer, v_strFLDNAME, v_strFieldValue As String
        Try
            'Xac dinh cac loai phi giao dich
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                v_strFLDNAME = mv_arrObjFields(v_intIndex).ColumnName
                If v_strFLDNAME.IndexOf(PREFIXED_FLDNAME_FEECODE) <> -1 Then
                    v_strFieldValue = CType(sender, Control).Text.Trim
                    If v_strFieldValue.Length > 0 Then
                        v_strFieldValue = "'" & v_strFieldValue & "'"
                        If Not mv_strListOfTXFeeCode.IndexOf(v_strFieldValue) > 0 Then
                            If mv_strListOfTXFeeCode.Length = 0 Then
                                mv_strListOfTXFeeCode = v_strFieldValue
                            Else
                                mv_strListOfTXFeeCode = v_strFieldValue & "," & mv_strListOfTXFeeCode
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_strObjMsg As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            If Me.ActiveControl Is btnCANCEL Then
                CancelClick = True
                OnClose()
                Exit Sub
            End If
            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME, v_strDEFNAME As String
            Dim v_strTempValue, v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String

            Dim v_bolCheck As Boolean = False
            'If InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    If mv_arrObjFields(v_intIndex).ControlType = "T" _
                        Or mv_arrObjFields(v_intIndex).ControlType = "M" Then
                        v_strFieldValue = CType(sender, Control).Text
                    Else
                        v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    End If
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)


                    'Truong mandatory phai nhap
                    If mv_arrObjFields(v_intIndex).Mandatory = True And mv_arrObjFields(v_intIndex).Enabled = True And Len(v_strFieldValue) = 0 And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True
                        Exit Sub
                    End If

                    If Len(v_strFieldValue) > 0 Then
                        v_strDataType = Trim(mv_arrObjFields(v_intIndex).DataType)
                        Select Case v_strDataType
                            Case "N"
                                If Not IsNumeric(v_strFieldValue) Then
                                    'Thong bao phai nhap du lieu kieu so
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_NUMERIC_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                Else
                                    FormatNumericTextbox(CType(sender, TextBox))
                                    If Len(v_strFieldValue) > 30 Then
                                        MessageBox.Show(mv_ResourceManager.GetString("ERR_OVER_DBL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                End If
                            Case "D"
                                If Not IsDateValue(v_strFieldValue) Then
                                    'Thong bao phai nhap du lieu kieu ngay thang
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_DATE_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                        End Select
                    End If

                    'Validate custody code 
                    'ThanhNM 27/02/2012
                    v_strDEFNAME = mv_arrObjFields(v_intIndex).ColumnName
                    If String.Compare(v_strDEFNAME, "CUSTODYCD") = 0 Or String.Compare(v_strDEFNAME, "BCUSTODYCD") = 0 Or String.Compare(v_strDEFNAME, "SCUSTODYCD") = 0 Then
                        v_strTempValue = v_strFieldValue.Replace(".", String.Empty).ToUpper
                        Dim v_strCustodyCD, v_strBrcode, v_strCustNo As String
                        Dim v_textData As New TextBox
                        v_textData = CType(sender, TextBox)

                        If Trim(v_textData.Text).Length > gc_COMPANY_CODE.Length Then
                            v_strCustodyCD = Trim(v_textData.Text)
                            v_strBrcode = Mid(v_strCustodyCD, 1, gc_COMPANY_CODE.Length)
                            v_strCustNo = Mid(v_strCustodyCD, 5)
                            v_strCustodyCD = v_strBrcode & Mid("000000", 1, 6 - v_strCustNo.Length) & v_strCustNo
                            'Fill so hop dong
                            v_strFieldValue = v_strCustodyCD
                            CType(sender, Control).Text = v_strCustodyCD.ToUpper
                        Else
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            e.Cancel = True
                            Exit Sub
                        End If


                        If CType(sender, Control).Text.Length <> 10 Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_CUSTODYCD_INVALID_LENGTH"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            e.Cancel = True
                            Exit Sub
                        Else
                            If CType(sender, Control).Text.Substring(0, 3) = "001" Then
                                If CType(sender, Control).Text.Substring(3, 1) = "C" _
                                                                Or CType(sender, Control).Text.Substring(3, 1) = "P" _
                                                                Or CType(sender, Control).Text.Substring(3, 1) = "F" _
                                                                Or CType(sender, Control).Text.Substring(3, 1) = "E" _
                                                                Or CType(sender, Control).Text.Substring(3, 1) = "M" Then
                                    'If v_strTempValue.Substring(3, 1) = "C" _
                                    '    Or v_strTempValue.Substring(3, 1) = "P" Then
                                    'If Not IsNumeric(v_strFieldValue.Substring(4)) Then
                                    '    MessageBox.Show(mv_ResourceManager.GetString("ERR_CUSTODYCD_INVALID_PCFLAG_PC"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    '    e.Cancel = True
                                    '    Exit Sub
                                    'Else
                                    'UPPER CASE
                                    'v_strFieldValue = v_strFieldValue.ToUpper
                                    'CType(sender, Control).Text = v_strFieldValue
                                    'End If
                                    'Else
                                    'UPPER CASE
                                    v_strFieldValue = CType(sender, Control).Text.ToUpper
                                    CType(sender, Control).Text = v_strFieldValue
                                    'End If
                                Else
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_CUSTODYCD_INVALID_PCFLAG_PC"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Else
                                'UPPER CASE
                                v_strFieldValue = CType(sender, Control).Text
                                CType(sender, Control).Text = v_strFieldValue
                            End If
                        End If
                        'trung.luu 29-02-2020 GD 1711 custodycd => ALL
                    ElseIf String.Compare(v_strDEFNAME, "PCUSTODYCD") = 0 And Me.ObjectName = "1711" Then
                        Exit Sub
                    End If

                    'Fill du lieu lookup tu HOST (Fill du lieu cho Refvalue va cac control khac)
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Kiem tra du lieu nhap vao co dung khong
                            v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                            v_strKeyVal = Replace(v_strFieldValue, ".", "").ToUpper
                            'Lay KeyName
                            v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                                & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                                & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case "KEYNAME"
                                                    v_strKeyName = Trim(v_strValue)
                                                Case "SEARCHCMDSQL"
                                                    v_strSEARCHSQL = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                Next
                                Dim v_strClause As String
                                v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")
                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If

                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                                v_ws.Message(v_strObjMsg)
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                                'Fill Refval
                                v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                            & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If


                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                v_ws.Message(v_strObjMsg)
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                If v_nodeList.Count > 0 Then
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                v_strValue = Trim(.InnerText)
                                                Select Case v_strFLDNAME
                                                    Case "FIELDCODE"
                                                        v_strFIELDCODE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next
                                    Next
                                    v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                    Else
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                    End If

                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                    v_ws.Message(v_strObjMsg)
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    If v_nodeList.Count > 0 Then
                                        For i As Integer = 0 To v_nodeList.Count - 1
                                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                With v_nodeList.Item(i).ChildNodes(j)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    v_strValue = Trim(.InnerText)
                                                    Select Case v_strFLDNAME
                                                        Case v_strFIELDCODE
                                                            v_strRefValue = v_strValue
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        If Len(v_strRefValue) > 0 Then
                                            'Fill Refval 
                                            Dim ctl As Control
                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                            ctl.Top = sender.Top
                                            ctl.Text = v_strRefValue
                                            ctl.Visible = True
                                            mv_strCustName = v_strRefValue
                                        End If
                                    Else
                                        If mv_arrObjFields(v_intIndex).Mandatory = True And mv_arrObjFields(v_intIndex).LookupCheck <> "N" Then
                                            MessageBox.Show(mv_ResourceManager.GetString("ERR_DATA_NOTFOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Fill DL lookup tu BDS 
                            v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                            If Me.UserLanguage = gc_LANG_ENGLISH Then
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                            Else
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                            End If

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                            v_ws.Message(v_strObjMsg)
                            v_strFULLDATA = v_strObjMsg
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                            v_strValue = Trim(.InnerText.ToString)
                                            If v_strFieldValue = v_strValue Then
                                                For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                    With v_nodeList.Item(i).ChildNodes(k)
                                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                            v_strDisplay = Trim(.InnerText.ToString)
                                                        End If
                                                    End With
                                                Next
                                                Dim ctl As Control
                                                ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                                ctl.Top = sender.Top
                                                ctl.Text = v_strDisplay
                                                ctl.Visible = True
                                                v_bolCheck = True
                                                Exit For
                                            End If
                                        End If
                                    End With
                                Next
                            Next
                            If v_bolCheck = True Then
                                'Hien thi du lieu tu lookup
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                            Else
                                If mv_arrObjFields(v_intIndex).LookupCheck <> "N" Then
                                    'Thong bao loi
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_LOOKUP_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                    '----------------------------------
                End If

                'Truong Inventory
                If Len(mv_arrObjFields(v_intIndex).InvName) > 0 Then
                    v_strFldSource = mv_arrObjFields(v_intIndex).FldSource
                    v_strFldDesc = mv_arrObjFields(v_intIndex).FldDesc
                    'Them
                    Dim v_ctrl As Control, v_ctlmskData As FlexMaskEditBox

                    For Each v_ctrl In Me.pnTransDetail.Controls
                        If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                            v_ctlmskData = CType(v_ctrl, FlexMaskEditBox)
                            v_strFLDNAME = Mid(v_ctlmskData.Name, Len(PREFIXED_MSKDATA) + 1)
                            If Trim(v_strFldDesc) = Trim(v_strFLDNAME) Then
                                'v_strTemp = Strings.Right(gc_FORMAT_ODAUTOID & v_strValue, CType(v_ctrl, FlexMaskEditBox).MaxLength - Len(v_strINVReturn))
                                If Len(CType(v_ctrl, FlexMaskEditBox).Text) = 0 Then
                                    GetInventory(v_strFldSource, v_strFldDesc, mv_arrObjFields(v_intIndex).InvName, mv_arrObjFields(v_intIndex).InvFormat)
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If
            End If
            Dim v_xmlATXDocument As New Xml.XmlDocument
            Dim lngErr As Integer = ERR_SYSTEM_OK
            Dim v_intFldval As Integer = 0
            v_intFldval = v_intIndex
            lngErr = ExecFldval(v_xmlATXDocument, v_intFldval)
            If lngErr = ERR_SYSTEM_START Then
                If Not ShowValMsg(mv_arrObjFldVals(v_intFldval), Me.UserLanguage) Then
                    Me.pnTransDetail.Controls(v_intFldval).Focus()
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub rtbData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_strObjMsg As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            If Me.ActiveControl Is btnCANCEL Then
                CancelClick = True
                OnClose()
                Exit Sub
            End If
            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME, v_strDEFNAME As String
            Dim v_strTempValue, v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String

            Dim v_bolCheck As Boolean = False
            'If InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    If mv_arrObjFields(v_intIndex).ControlType = "R" Then
                        v_strFieldValue = CType(sender, Control).Text
                    Else
                        v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    End If

                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)


                    'Truong mandatory phai nhap
                    If mv_arrObjFields(v_intIndex).Mandatory = True And mv_arrObjFields(v_intIndex).Enabled = True And Len(v_strFieldValue) = 0 And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True
                        Exit Sub
                    End If

                    If Len(v_strFieldValue) > 0 Then
                        v_strDataType = Trim(mv_arrObjFields(v_intIndex).DataType)
                        Select Case v_strDataType
                            Case "N"
                                If Not IsNumeric(v_strFieldValue) Then
                                    'Thong bao phai nhap du lieu kieu so
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_NUMERIC_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                Else
                                    'FormatNumericTextbox(CType(sender, TextBox))
                                    If Len(v_strFieldValue) > 30 Then
                                        MessageBox.Show(mv_ResourceManager.GetString("ERR_OVER_DBL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                End If
                            Case "D"
                                If Not IsDateValue(v_strFieldValue) Then
                                    'Thong bao phai nhap du lieu kieu ngay thang
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_DATE_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                        End Select
                    End If

                    'Validate custody code 
                    'ThanhNM 27/02/2012
                    v_strDEFNAME = mv_arrObjFields(v_intIndex).ColumnName

                    'Fill du lieu lookup tu HOST (Fill du lieu cho Refvalue va cac control khac)
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Kiem tra du lieu nhap vao co dung khong
                            v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                            v_strKeyVal = Replace(v_strFieldValue, ".", "").ToUpper
                            'Lay KeyName
                            v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                                & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                                & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case "KEYNAME"
                                                    v_strKeyName = Trim(v_strValue)
                                                Case "SEARCHCMDSQL"
                                                    v_strSEARCHSQL = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                Next
                                Dim v_strClause As String
                                v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")
                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If

                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                                v_ws.Message(v_strObjMsg)
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                                'Fill Refval
                                v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                            & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                If Me.UserLanguage = gc_LANG_ENGLISH Then
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                Else
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                End If


                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                v_ws.Message(v_strObjMsg)
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                If v_nodeList.Count > 0 Then
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                v_strValue = Trim(.InnerText)
                                                Select Case v_strFLDNAME
                                                    Case "FIELDCODE"
                                                        v_strFIELDCODE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next
                                    Next
                                    v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                    Else
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                    End If

                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                    v_ws.Message(v_strObjMsg)
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    If v_nodeList.Count > 0 Then
                                        For i As Integer = 0 To v_nodeList.Count - 1
                                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                With v_nodeList.Item(i).ChildNodes(j)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    v_strValue = Trim(.InnerText)
                                                    Select Case v_strFLDNAME
                                                        Case v_strFIELDCODE
                                                            v_strRefValue = v_strValue
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        If Len(v_strRefValue) > 0 Then
                                            'Fill Refval 
                                            Dim ctl As Control
                                            ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                            ctl.Top = sender.Top
                                            ctl.Text = v_strRefValue
                                            ctl.Visible = True
                                            mv_strCustName = v_strRefValue
                                        End If
                                    Else
                                        If mv_arrObjFields(v_intIndex).Mandatory = True And mv_arrObjFields(v_intIndex).LookupCheck <> "N" Then
                                            MessageBox.Show(mv_ResourceManager.GetString("ERR_DATA_NOTFOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Fill DL lookup tu BDS 
                            v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                            If Me.UserLanguage = gc_LANG_ENGLISH Then
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                            Else
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                            End If

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                            v_ws.Message(v_strObjMsg)
                            v_strFULLDATA = v_strObjMsg
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                            v_strValue = Trim(.InnerText.ToString)
                                            If v_strFieldValue = v_strValue Then
                                                For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                    With v_nodeList.Item(i).ChildNodes(k)
                                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                            v_strDisplay = Trim(.InnerText.ToString)
                                                        End If
                                                    End With
                                                Next
                                                Dim ctl As Control
                                                ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                                ctl.Top = sender.Top
                                                ctl.Text = v_strDisplay
                                                ctl.Visible = True
                                                v_bolCheck = True
                                                Exit For
                                            End If
                                        End If
                                    End With
                                Next
                            Next
                            If v_bolCheck = True Then
                                'Hien thi du lieu tu lookup
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                            Else
                                If mv_arrObjFields(v_intIndex).LookupCheck <> "N" Then
                                    'Thong bao loi
                                    MessageBox.Show(mv_ResourceManager.GetString("ERR_LOOKUP_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                    '----------------------------------
                End If
            End If


            Dim v_xmlATXDocument As New Xml.XmlDocument
            Dim lngErr As Integer = ERR_SYSTEM_OK
            Dim v_intFldval As Integer = 0
            v_intFldval = v_intIndex
            lngErr = ExecFldval(v_xmlATXDocument, v_intFldval)
            If lngErr = ERR_SYSTEM_START Then
                If Not ShowValMsg(mv_arrObjFldVals(v_intFldval), Me.UserLanguage) Then
                    Me.pnTransDetail.Controls(v_intFldval).Focus()
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Function ExecFldval(ByVal v_xmlDocument As Xml.XmlDocument, ByRef pv_int As Integer) As Long
        Dim v_intCount, v_intIndex, i As Integer
        Dim v_strFLDNAME, v_strFLDDEFNAME, v_strDATATYPE, v_strFLDVALUE, v_strTXBUSDATE As String
        Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String
        Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
        Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
        Dim v_arrOperand() As String
        Dim v_dblOpr1 As Double = 0
        Dim v_dblOpr2 As Double = 0
        Dim v_dblResult As Double = -1
        Dim v_strTagValue As String
        Dim v_dblTotalBalance, v_dblMinBalance, v_dblAvailBalance As Double
        Dim v_strTotalBalance, v_strMinBalacne, v_strAvailBalance As String
        Dim v_blnBankCalled As Boolean = False
        'Duyá»‡t máº£ng dá»¯ liá»‡u danh má»¥c cÃ¡c Ä‘iá»?u kiá»‡n kiá»ƒm tra
        v_intCount = mv_arrObjFldVals.GetLength(0)
        If v_intCount > 0 Then
            For i = 0 To v_intCount - 1 Step 1
                If Not mv_arrObjFldVals(i) Is Nothing Then
                    'Xá»­ lÃ½ theo tham sá»‘ Ä‘Ã£ cÃ i Ä‘áº·t
                    With mv_arrObjFldVals(i)
                        'XÃ¡c Ä‘inh control index
                        v_intIndex = mv_arrObjFields(.IDXFLD).ControlIndex
                        'Thá»±c hiá»‡n xá»­ lÃ½ cho tá»«ng phÃ©p toÃ¡n
                        ' tinh gia tri tagvalue
                        If (.TAGVALUE.StartsWith("@")) Then
                            v_strTagValue = .TAGVALUE.Trim("@")
                        Else
                            v_strTagValue = BuildAMTEXP(v_xmlDocument, .TAGVALUE)
                        End If
                        ' neu tagfield= tagvalue thi moi check
                        If (String.Compare(BuildAMTEXP(v_xmlDocument, .TAGFIELD), v_strTagValue) = 0 Or Trim(.TAGFIELD) = "") Then
                            If .VALTYPE = "E" _
                                    OrElse (.VALTYPE = "T" _
                                            AndAlso (Len(.VALEXP) > 0 AndAlso .VALEXP.Contains(mv_arrObjFields(pv_int).FieldName) _
                                                        OrElse (Len(.VALEXP2) > 0 AndAlso .VALEXP2.Contains(mv_arrObjFields(pv_int).FieldName)))) Then
                                'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  sá»‘
                                If mv_arrObjFields(.IDXFLD).DataType <> "D" Then
                                    Select Case .[OPERATOR]
                                        Case "EX"
                                            v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                Me.pnTransDetail.Controls(v_intIndex).Text = FRound(v_objEval.Eval(v_strVALEXP), 0)
                                                FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                            Else
                                                Me.pnTransDetail.Controls(v_intIndex).Text = v_objEval.Eval(v_strVALEXP)
                                            End If
                                        Case "MA"
                                            v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                            v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                Me.pnTransDetail.Controls(v_intIndex).Text = FRound(GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)), 0)
                                                FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                            Else
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            End If
                                            'Me.pnTransDetail.Controls(v_intIndex).Text = GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                        Case "MI"
                                            v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                            v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                Me.pnTransDetail.Controls(v_intIndex).Text = FRound(GetMin(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)), 0)
                                                FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                            Else
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetMin(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            End If
                                        Case "IP"   'Lay gia tri toi thieu nhung phai lon hon 0
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetMinPositive(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                                FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                            End If
                                        Case "FM"   'Lay gia tri toi thieu, lam tron xuong nhung phai lon hon 0
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                                v_strVALEXP2 = BuildAMTEXP(v_xmlDocument, .VALEXP2)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = Math.Floor(GetMinPositive(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2))).ToString
                                                FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                            End If
                                        Case "ES"   'Xu ly nhung toan tu nhu MOD
                                            v_strVALEXP = BuildAMTEXP(v_xmlDocument, .VALEXP)
                                            If InStr(v_strVALEXP, "M") > 0 Then
                                                v_arrOperand = v_strVALEXP.Split("M")
                                                v_dblOpr1 = CDbl(v_arrOperand(0))
                                                v_dblOpr2 = CDbl(v_arrOperand(1))
                                                v_dblResult = IIf(v_dblOpr2 <> 0, v_dblOpr1 Mod v_dblOpr2, 0)
                                                Me.pnTransDetail.Controls(v_intIndex).Text = IIf(v_dblResult > 0, (v_dblOpr1 \ v_dblOpr2) + 1, IIf(v_dblOpr2 > 0, v_dblOpr1 / v_dblOpr2, 0)).ToString()
                                            End If
                                        Case "FX"   'Goi ham oracle
                                            '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                            v_strVALEXP = .VALEXP   'Ten oracle function name
                                            v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so

                                            If TypeOf (Me.pnTransDetail.Controls(v_intIndex)) Is ComboBoxEx Then
                                                CType(Me.pnTransDetail.Controls(v_intIndex), ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                            Else
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                                End If
                                            End If
                                        Case "RM" 'Goi ham GetBankBalance
                                            v_strVALEXP = .VALEXP   'Ten truong so tieu khoan
                                            v_strVALEXP2 = .VALEXP2
                                            If mv_arrObjFields(pv_int).FieldName = v_strVALEXP Then ' Neu validate tai truong so tai khoan thi goi
                                                If v_blnBankCalled = False Then
                                                    'Me.pnTransDetail.Controls(v_intIndex).Text = GetBankBalance(BuildAMTEXP(v_xmlDocument, .VALEXP))
                                                    v_blnBankCalled = True
                                                    Dim v_arr() As String = GetBankBalance(BuildAMTEXP(v_xmlDocument, .VALEXP)).Split("|")
                                                    v_dblTotalBalance = CDbl(v_arr(1))
                                                    v_dblMinBalance = CDbl(v_arr(2))
                                                    v_dblAvailBalance = Math.Max(CDbl(v_arr(0)) - CDbl(v_arr(2)), 0)
                                                End If
                                                If v_strVALEXP2 = "AVLBAL" Then
                                                    v_strAvailBalance = v_dblAvailBalance.ToString("0,0", CultureInfo.InvariantCulture)
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", v_strAvailBalance)
                                                ElseIf v_strVALEXP2 = "BALANCE" Then
                                                    v_strTotalBalance = v_dblTotalBalance.ToString("0,0", CultureInfo.InvariantCulture)
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", v_strTotalBalance)
                                                ElseIf v_strVALEXP2 = "MINBAL" Then
                                                    v_strMinBalacne = v_dblMinBalance.ToString("0,0", CultureInfo.InvariantCulture)
                                                    Me.pnTransDetail.Controls(v_intIndex).Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", v_strMinBalacne)
                                                End If
                                            End If
                                        Case "&&"
                                            v_strVALEXP = BuildCONCAT(.VALEXP)
                                            Me.pnTransDetail.Controls(v_intIndex).Text = v_strVALEXP
                                    End Select
                                    'Náº¿u trÆ°á»?ng cÃ³ kiá»ƒu dá»¯ liá»‡u lÃ  ngÃ y thÃ¡ng
                                ElseIf mv_arrObjFields(.IDXFLD).DataType = "D" Then
                                    Select Case .[OPERATOR]
                                        Case "DF"
                                            If .VALEXP = "00" Then
                                                v_dtVALEXP = DDMMYYYY_SystemDate(Me.pnTransDetail.Controls(0).Text)
                                            End If
                                            v_dtVALEXP2 = DDMMYYYY_SystemDate(BuildAMTEXP(v_xmlDocument, .VALEXP2))
                                            Me.pnTransDetail.Controls(v_intIndex).Text = DateDiff(DateInterval.Day, v_dtVALEXP, v_dtVALEXP2).ToString
                                        Case "FX"   'Goi ham oracle
                                            v_strVALEXP = .VALEXP   'Ten oracle function name
                                            v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so

                                            If TypeOf (Me.pnTransDetail.Controls(v_intIndex)) Is ComboBoxEx Then
                                                CType(Me.pnTransDetail.Controls(v_intIndex), ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                            Else
                                                Me.pnTransDetail.Controls(v_intIndex).Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    FormatNumericTextbox(CType(Me.pnTransDetail.Controls(v_intIndex), TextBox))
                                                End If
                                            End If
                                    End Select
                                End If
                                'Check gia tri nhap vao co hop le, goi vao function tren DB
                            ElseIf .VALTYPE = "I" Then

                                If mv_arrObjFields(pv_int).FieldName = mv_arrObjFldVals(i).FLDNAME Then
                                    Select Case .[OPERATOR]
                                        Case "FX"   'Goi ham oracle
                                            'Return : 0 OK, -1 Error
                                            '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                            v_strVALEXP = .VALEXP   'Ten oracle function name
                                            v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so
                                            Dim v_LogInt As Integer = 0
                                            v_LogInt = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                            If v_LogInt <> 0 Then
                                                pv_int = i
                                                Return v_LogInt
                                            End If
                                    End Select
                                End If
                            End If
                        End If

                    End With
                End If
            Next
        End If
        Return ERR_SYSTEM_OK
    End Function

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String
            Dim v_intIndex As Integer
            v_intIndex = CType(pv_ctrl, TextBox).Tag
            v_strFormat = mv_arrObjFields(v_intIndex).FieldFormat
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                If FormatNumber(pv_ctrl.Text, v_intDecimal) = FRound(CDbl(pv_ctrl.Text)) Then
                    'pv_ctrl.Text = FormatNumber(Math.Floor(CDbl(pv_ctrl.Text)), v_intDecimal)
                    pv_ctrl.Text = FormatNumber(FRound(CDbl(pv_ctrl.Text)), v_intDecimal)
                Else
                    pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Form events "

    Private Sub frmTransact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ActiveControl.Name = "mskTransCode" Then
                    'Nap man hinh moi
                    If Len(Trim(mskTransCode.Text)) = 4 Then
                        mv_strTxDesc = String.Empty
                        LoadScreen(Trim(mskTransCode.Text))
                        'Chuyen den control ke tiep
                        SendKeys.Send("{Tab}")
                        e.Handled = True
                    End If
                ElseIf InStr(CType(Me.ActiveControl, Control).Name, PREFIXED_MSKDATA) > 0 And (Not TypeOf (Me.ActiveControl) Is RichTextBox) Then
                    'Chuyen den control ke tiep
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
        End Select
    End Sub
    Private Sub frmTransact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
        DisplayButton()
        If AutoSubmitWhenExecute Then
            Me.OnSubmit()
            If mskTransCode.Enabled = False Then
                Me.OnSubmit()
            End If
        End If
    End Sub

    Private Sub frmTransact_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmTransact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME, strLOOKUPNAME As String, v_intIndex, i As Integer
        Try

            Select Case e.KeyCode
                Case Keys.Escape
                    OnClose()
                Case Keys.F5
                    If Me.ActiveControl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                        Exit Sub
                    ElseIf Me.ActiveControl.Name = "mskTransCode" Then
                        Dim frm As New frmLookUp(UserLanguage)

                        frm.SQLCMD = "SELECT DISTINCT TLTX.TLTXCD VALUE, TLTX.TXDESC DISPLAY, TLTX.EN_TXDESC EN_DISPLAY FROM TLTX, FLDMASTER " _
                            & " WHERE TRIM(TLTX.CHAIN)='N' AND TRIM(TLTX.DIRECT)='Y' AND TRIM(TLTX.TLTXCD) = TRIM(FLDMASTER.OBJNAME) AND TRIM(FLDMASTER.MODCODE) LIKE '%' ORDER BY TLTXCD"
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            SendKeys.Send("{Enter}")
                            e.Handled = True
                        End If
                        frm.Dispose()

                    ElseIf InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_intIndex = Me.ActiveControl.Tag
                        'Tra cuu thong tin: Khong cho F5 voi dropdown list
                        If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 _
                                And mv_arrObjFields(v_intIndex).ControlType <> "C" Then
                            SetLookUpDataForm()
                            mv_frmSearchScreen.TableName = mv_arrObjFields(v_intIndex).SearchCode
                            mv_frmSearchScreen.ModuleCode = mv_arrObjFields(v_intIndex).SrModCode
                            'Only search and choose
                            mv_frmSearchScreen.AuthCode = "NNNNYYNNNN"
                            mv_frmSearchScreen.AuthString = "NNNNNNNNNN"

                            mv_frmSearchScreen.IsLocalSearch = gc_IsNotLocalMsg
                            mv_frmSearchScreen.IsLookup = "Y"
                            mv_frmSearchScreen.SearchOnInit = False
                            mv_frmSearchScreen.BranchId = Me.BranchId
                            mv_frmSearchScreen.TellerId = Me.TellerId
                            mv_frmSearchScreen.SearchByTransact = True
                            mv_frmSearchScreen.ShowDialog()
                            If Not mv_frmSearchScreen.ReturnValue Is Nothing Then
                                Me.ActiveControl.Text = mv_frmSearchScreen.ReturnValue
                                If Len(mv_frmSearchScreen.RefValue) > 0 Then
                                    ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    ctl.Top = Me.ActiveControl.Top
                                    If mv_arrObjFields(v_intIndex).ControlType = "T" _
                                        Or mv_arrObjFields(v_intIndex).ControlType = "M" _
                                        Or mv_arrObjFields(v_intIndex).ControlType = "R" Then
                                        ctl.Text = mv_frmSearchScreen.RefValue
                                    ElseIf mv_arrObjFields(v_intIndex).ControlType = "C" Then
                                        CType(ctl, ComboBoxEx).SelectedValue = mv_frmSearchScreen.RefValue
                                    End If
                                    ctl.Visible = True
                                End If
                                'Nap cac gia tri tim duoc cho cac truong khac
                                strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                                FillLookupData(strFLDNAME, mv_frmSearchScreen.ReturnValue, mv_frmSearchScreen.FULLDATA, mv_frmSearchScreen.KeyColumn)
                                mv_frmSearchScreen.Dispose()
                            End If

                        ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" _
                                And mv_arrObjFields(v_intIndex).ControlType <> "C" Then
                            Dim frm As New frmLookUp(UserLanguage)
                            frm.IsLocalSearch = gc_IsLocalMsg
                            If Trim(mskTransCode.Text) = gc_CF_CHANGE_AFTYPE Then
                                Dim v_strObjMsg As String
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionAdhoc, , GroupCareBy, "GetAFtypes")
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                v_ws.Message(v_strObjMsg)

                                Dim v_nodeList As Xml.XmlNodeList
                                Dim XmlDocument As New Xml.XmlDocument
                                Dim v_strFLDNAME, v_strValue, v_strActype, v_strDescription As String

                                XmlDocument.LoadXml(v_strObjMsg)

                                frm.AFtypeData = v_strObjMsg
                            ElseIf Trim(mskTransCode.Text) = gc_CF_CHANGE_CUSTOMIZE_AMPLITUDE Or Trim(mskTransCode.Text) = gc_CF_CHANGE_SYSTEM_BOUNDARY Then
                                Dim strMODCODE As String
                                For i = 0 To mv_arrObjFields.Length - 1
                                    If mv_arrObjFields(i).FieldName = "01" Then
                                        ctl = Me.pnTransDetail.Controls(mv_arrObjFields(i).ControlIndex)
                                        strMODCODE = CType(ctl, ComboBoxEx).SelectedValue.ToString()
                                        Exit For
                                    End If
                                Next
                                frm.SQLCMD = "SELECT EVENTCODE VALUECD, EVENTCODE VALUE, EVENTNAME DISPLAY,EVENTNAME DESCRIPTION FROM APPEVENTS WHERE MODCODE = '" & strMODCODE & "' ORDER BY EVENTCODE"
                            Else
                                frm.SQLCMD = mv_arrObjFields(v_intIndex).LookupList
                                frm.SQLCMD = frm.SQLCMD.Replace("<$TLTXCD>", Me.mskTransCode.Text.Trim)
                            End If

                            frm.ShowDialog()
                            If Not frm.RETURNDATA Is Nothing Then
                                v_intPos = InStr(frm.RETURNDATA, vbTab)
                                If v_intPos > 0 Then
                                    Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                                    ctl = Me.pnTransDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    ctl.Top = Me.ActiveControl.Top
                                    ctl.Text = Mid(frm.RETURNDATA, v_intPos + 1)
                                    ctl.Visible = True
                                    'Nap cac gia tri tim duoc cho cac truong khac
                                    strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                                    FillLookupData(strFLDNAME, Mid(frm.RETURNDATA, 1, v_intPos - 1), frm.FULLDATA)
                                End If
                                frm.Dispose()
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mskTransCode_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskTransCode.GotFocus
        mskTransCode.SelectionStart = 0
        mskTransCode.SelectionLength = Len(Trim(mskTransCode.Text))
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        If Me.mskTransCode.Enabled = False And Me.TxNum.Length = 0 Then
            ResetScreen()
        Else
            CancelClick = True
            OnClose()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.btnOK.Focus() 'QuangVD: them vao de tranh loi khi an Alt+C
        OnSubmit()
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        If Not mskTransCode.Enabled Then 'O lan submit thu hai
            Dim i As Integer
            Dim v_arrText(mv_arrObjFields.Length - 2) As String
            Dim v_strTranCode, v_strTempTxBusDate, mv_strTempTxdesc As String
            v_strTempTxBusDate = mv_strTxBusDate
            mv_strTempTxdesc = mv_strTxDesc
            v_strTranCode = mskTransCode.Text
            'LÆ°u láº¡i giÃ¡ trá»‹ cÅ©: Khi view giao dá»‹ch, giÃ¡ trá»‹ cá»§a cÃ¡c trÆ°á»?ng Ä‘Æ°á»£c máº·c Ä‘á»‹nh trong DefaultValue
            For i = 0 To mv_arrObjFields.Length - 2
                v_arrText(i) = mv_arrObjFields(i).DefaultValue
            Next
            'Reset láº¡i mÃ n hÃ¬nh náº¡p láº¡i giao dá»‹ch: Náº¿u lÃ  loáº¡i giao dá»‹ch nháº­p bÃºt toÃ¡n trá»±c tiáº¿p thÃ¬ khÃ´ng Reset
            ResetScreen(Not mv_blnAcctEntry)
            mskTransCode.Text = v_strTranCode
            LoadScreen(Trim(mskTransCode.Text))
            'Ä?áº·t láº¡i giÃ¡ trá»‹ cÅ©
            For i = 0 To mv_arrObjFields.Length - 2
                mv_arrObjFields(i).FieldValue = v_arrText(i)
            Next
            mskTransCode.Enabled = True
            Me.btnOK.Visible = True
            'Hiá»ƒn thá»‹ mÃ n hinh
            mv_strTxBusDate = v_strTempTxBusDate
            DisplayScreen()
            'Me.SelectNextControl(Me.mskTransCode, True, True, True, True)
            Me.btnOK.Focus()
        End If
    End Sub

    Private Sub btnEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntries.Click

    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Try
            'Láº¥y TXDATE vÃ  TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
            v_strTXNUM = Me.TxNum
            v_strTXDATE = Me.TxDate
            'Láº¥y thÃ´ng tin chi tiáº¿t vá»? Ä‘iá»‡n giao dá»‹ch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strWarningMessage As String = String.Empty
            Dim v_strInfoMessage As String = String.Empty

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch. Message tráº£ vá»? sáº½ lÃ  TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chá»‰ cho phÃ©p duyá»‡t Ä‘á»‘i vá»›i nhá»¯ng giao dá»‹ch chÆ°a hoÃ n táº¥t vÃ  
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)

                    ''get Warning Message
                    GetWarningFromMessage(v_strObjMsg, v_strWarningMessage, v_strInfoMessage)
                    Cursor.Current = Cursors.Default
                    If v_strInfoMessage <> String.Empty Then
                        MsgBox(v_strInfoMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    If v_strWarningMessage <> String.Empty Then
                        MsgBox(v_strWarningMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'ThÃ´ng bÃ¡o lá»—i
                        If mskTransCode.Text = gc_CF_REMAP_TOKEN Then
                            Dim v_xmlErrorDocument As XmlDocumentEx
                            v_xmlErrorDocument = New XmlDocumentEx()
                            v_xmlErrorDocument.LoadXml(v_strObjMsg)
                            Dim v_xmlerrorNode = v_xmlErrorDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='p_err_message']")
                            If Not (v_xmlerrorNode Is Nothing) Then
                                v_strErrorMessage = v_xmlerrorNode.InnerText
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            Else
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                        Else
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                    End If
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransact.ApproveSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'show giao dá»‹ch tiáº¿p theo
                    Me.Dispose()
                    'ShowNextTran()
                End If
            ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveDeleteMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'ThÃ´ng bÃ¡o lá»—i
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransact.DeleteSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'show giao dá»‹ch tiáº¿p theo
                    Me.Dispose()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Try
            'Láº¥y TXDATE vÃ  TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long
            v_strTXNUM = Me.TxNum
            v_strTXDATE = Me.TxDate
            'Láº¥y thÃ´ng tin chi tiáº¿t vá»? Ä‘iá»‡n giao dá»‹ch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch. Message tráº£ vá»? sáº½ lÃ  TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chá»‰ cho phÃ©p duyá»‡t Ä‘á»‘i vá»›i nhá»¯ng giao dá»‹ch Ä‘ang chá»? duyá»‡t vÃ  chÆ°a bá»‹ xoÃ¡
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    'Hiá»ƒn thá»‹ InputBox yÃªu cáº§u nháº­p lÃ½ do Reject
                    v_strCommentMessage = InputBox(mv_ResourceManager.GetString("frmTransact.RejectComment"), Me.Text, v_strCommentMessage)
                    If Len(Trim(v_strCommentMessage)) > 0 Then
                        v_strObjMsg = String.Empty
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strCommentMessage)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'ThÃ´ng bÃ¡o lá»—i
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                        MessageBox.Show(mv_ResourceManager.GetString("frmTransact.RejectedSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'show giao dá»‹ch tiáº¿p theo
                        Me.Dispose()
                        'ShowNextTran()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnRefuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefuse.Click
        Try
            'Láº¥y TXDATE vÃ  TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
            v_strTXNUM = Me.TxNum
            v_strTXDATE = Me.TxDate
            'Láº¥y thÃ´ng tin chi tiáº¿t vá»? Ä‘iá»‡n giao dá»‹ch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch. Message tráº£ vá»? sáº½ lÃ  TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chá»‰ cho phÃ©p duyá»‡t Ä‘á»‘i vá»›i nhá»¯ng giao dá»‹ch Ä‘ang chá»? duyá»‡t vÃ  chÆ°a bá»‹ xoÃ¡
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RefuseMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'ThÃ´ng bÃ¡o lá»—i
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransact.RefuseMessage"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'show giao dá»‹ch tiáº¿p theo
                    Me.Dispose()
                    'ShowNextTran()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub btnVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoucher.Click

    End Sub
#End Region

    Private Sub pnTransDetail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pnTransDetail.Validating

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
