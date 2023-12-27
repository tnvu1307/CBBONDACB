Imports AppCore
Imports CommonLibrary
Imports System.IO
Imports TestBase64
Imports SendFiles
Imports ZetaCompressionLibrary
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.Drawing.Printing


Public Class frmMaster
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal v_strTableName As String, ByVal v_intExecFlag As Integer, ByVal v_strUserLanguage As String, ByVal v_strModuleCode As String, _
                    ByVal v_strFullObjName As String, ByVal v_strIsLocalSearch As String, ByVal v_strFormCaption As String, ByVal v_strTellerId As String, _
                    ByVal v_strTellerRight As String, ByVal v_strGroupCareBy As String, ByVal v_strAuthString As String, ByVal v_strBranchId As String, _
                    ByVal v_strBusDate As String, ByVal v_strKeyColumn As String, ByVal v_strKeyFieldType As String, ByVal v_strKeyFieldValue As String, _
                    ByVal v_strLinkValue As String, ByVal v_strLinkField As String, ByVal v_strParentValue As String, ByVal v_strParentObject As String, _
                    ByVal v_strParentModule As String, ByVal v_objRefField As Object, Optional ByVal v_strParentClause As String = "", _
                    Optional ByVal v_strCompanyCode As String = "", Optional ByVal v_strCompanyName As String = "")

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.TableName = v_strTableName
        Me.ExeFlag = v_intExecFlag
        Me.UserLanguage = v_strUserLanguage
        Me.ModuleCode = v_strModuleCode
        Me.ObjectName = v_strFullObjName
        Me.LocalObject = v_strIsLocalSearch
        Me.Text = v_strFormCaption
        Me.TellerId = v_strTellerId
        Me.TellerRight = v_strTellerRight
        Me.GroupCareBy = v_strGroupCareBy
        Me.AuthString = v_strAuthString
        Me.BranchId = v_strBranchId
        Me.BusDate = v_strBusDate
        Me.KeyFieldName = v_strKeyColumn
        Me.KeyFieldType = v_strKeyFieldType
        Me.KeyFieldValue = v_strKeyFieldValue
        Me.ParentValue = v_strParentValue
        Me.ParentObject = v_strParentObject
        Me.ParentModule = v_strParentModule
        Me.LinkValue = v_strLinkValue
        Me.LinkField = v_strLinkField
        Me.mv_arrRefObjFields = v_objRefField
        Me.ParentClause = v_strParentClause
        Me.CompanyCode = v_strCompanyCode

        'Set click event for buttons
        AddHandler btnOK.Click, AddressOf Button_Click
        AddHandler btnApply.Click, AddressOf Button_Click
        AddHandler btnCancel.Click, AddressOf Button_Click
        AddHandler btnExternal.Click, AddressOf Button_Click
        AddHandler btnNavigate.Click, AddressOf Button_Click
        AddHandler btnReject.Click, AddressOf Button_Click
        AddHandler btnApprove.Click, AddressOf Button_Click

        mv_resourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        LoadScreen()
        'Get all information to show screen
        If (Me.ExeFlag = ExecuteFlag.AddNew) Then
            Me.lblCaption.Text = mv_resourceManager.GetString("CaptionAdd")
        ElseIf (Me.ExeFlag = ExecuteFlag.Edit) Then
            Me.lblCaption.Text = mv_resourceManager.GetString("CaptionEdit")
        ElseIf (Me.ExeFlag = ExecuteFlag.View) Then
            Me.lblCaption.Text = mv_resourceManager.GetString("CaptionView")
        Else
            Me.lblCaption.Text = mv_resourceManager.GetString("CaptionDefault")
        End If
    End Sub

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
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Protected WithEvents btnApply As System.Windows.Forms.Button
    Protected WithEvents btnOK As System.Windows.Forms.Button
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    Protected WithEvents btnExternal As System.Windows.Forms.Button
    Friend WithEvents tabMaster As System.Windows.Forms.TabControl
    Protected WithEvents btnNavigate As System.Windows.Forms.Button
    Protected WithEvents btnApprove As System.Windows.Forms.Button
    Protected WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents popmenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnDownLoad As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PreviewPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cboLink As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnExternal = New System.Windows.Forms.Button()
        Me.tabMaster = New System.Windows.Forms.TabControl()
        Me.btnNavigate = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.cboLink = New System.Windows.Forms.ComboBox()
        Me.popmenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnDownLoad = New DevExpress.XtraBars.BarButtonItem()
        Me.PreviewPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Panel1.SuspendLayout()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(480, 424)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(70, 23)
        Me.btnApply.TabIndex = 7
        Me.btnApply.Tag = "btnApply"
        Me.btnApply.Text = "btnApply"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(408, 424)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(70, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(552, 424)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnExternal
        '
        Me.btnExternal.Location = New System.Drawing.Point(192, 424)
        Me.btnExternal.Name = "btnExternal"
        Me.btnExternal.Size = New System.Drawing.Size(70, 23)
        Me.btnExternal.TabIndex = 3
        Me.btnExternal.Tag = "btnExternal"
        Me.btnExternal.Text = "btnExternal"
        '
        'tabMaster
        '
        Me.tabMaster.Location = New System.Drawing.Point(8, 56)
        Me.tabMaster.Name = "tabMaster"
        Me.tabMaster.SelectedIndex = 0
        Me.tabMaster.Size = New System.Drawing.Size(616, 360)
        Me.tabMaster.TabIndex = 9
        '
        'btnNavigate
        '
        Me.btnNavigate.Location = New System.Drawing.Point(120, 424)
        Me.btnNavigate.Name = "btnNavigate"
        Me.btnNavigate.Size = New System.Drawing.Size(70, 23)
        Me.btnNavigate.TabIndex = 2
        Me.btnNavigate.Tag = "btnNavigate"
        Me.btnNavigate.Text = "btnNavigate"
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(336, 424)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(70, 23)
        Me.btnApprove.TabIndex = 5
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(264, 424)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(70, 23)
        Me.btnReject.TabIndex = 4
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        '
        'cboLink
        '
        Me.cboLink.ItemHeight = 13
        Me.cboLink.Location = New System.Drawing.Point(8, 424)
        Me.cboLink.Name = "cboLink"
        Me.cboLink.Size = New System.Drawing.Size(112, 21)
        Me.cboLink.TabIndex = 1
        '
        'popmenu
        '
        Me.popmenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDownLoad), New DevExpress.XtraBars.LinkPersistInfo(Me.PreviewPrint)})
        Me.popmenu.Manager = Me.BarManager1
        Me.popmenu.Name = "popmenu"
        '
        'btnDownLoad
        '
        Me.btnDownLoad.Caption = "Export"
        Me.btnDownLoad.Id = 0
        Me.btnDownLoad.Name = "btnDownLoad"
        '
        'PreviewPrint
        '
        Me.PreviewPrint.Caption = "Print"
        Me.PreviewPrint.Id = 1
        Me.PreviewPrint.Name = "PreviewPrint"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnDownLoad, Me.PreviewPrint})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(634, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 510)
        Me.barDockControlBottom.Size = New System.Drawing.Size(634, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 510)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(634, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 510)
        '
        'frmMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 510)
        Me.Controls.Add(Me.cboLink)
        Me.Controls.Add(Me.tabMaster)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnExternal)
        Me.Controls.Add(Me.btnNavigate)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMaster"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Khai báo biến, hằng "
    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 5
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 200
    Const ALL_WIDTH = 800
    Const ALL_WIDTH_R = 800
    Const WIDTH_PERCHAR = 15
    Const PANEL_TOP = 54
    Const PANEL_HEIGHT = 200
    Const TABS_TOP = 10
    Const TABS_HEIGHT = 140
    Const LABEL_HELPER_TOP = 420

    Const PREFIXED_REFMASTER = "$REF_"
    Const PREFIXED_BTNDATA = "btnData"
    Const PREFIXED_MSKDATA = "mskData"
    Const PREFIXED_LBLDESC = "lblDesc"
    Const PREFIXED_LBLCAP = "lblCaption"
    Const PREFIXED_BTNTABPAGE = "btnTabPage"
    Const PREFIXED_LTVDATA = "ltvData"

    Const POS_FLDNAME = 1
    Const POS_FLDTYPE = POS_FLDNAME + 2
    Const POS_PRINTINFO = POS_FLDTYPE + 1
    Const POS_LOOKUP = POS_PRINTINFO + 10
    Const POS_SQLLIST = POS_LOOKUP + 1

    Const BTN_GAP = 7
    Const BTN_WIDTH = 80
    Const BTN_ROOT_LEFT = 550

    Const LTV_WIDTH = 232

    Const tabpage_Panel_WIDTH = 600
    Const tabpage_Panel_HEIGHT = 300
    Const tabpage_Button_MAX = 8
    Const tabpage_Button_POS_TOP = 5
    Const tabpage_Button_POS_LEFT = 5
    Const tabpage_Button_POS_HEIGHT = 23
    Const tabpage_Button_POS_WIDTH = 60
    Const tabpage_Button_POS_GAP = 5
    Const tabpage_Button_VIEW = 1
    Const tabpage_Button_INSERT = 2
    Const tabpage_Button_EDIT = 3
    Const tabpage_Button_DELETE = 4
    Const tabpage_Button_FIRST = 5
    Const tabpage_Button_PREVIOUS = 6
    Const tabpage_Button_NEXT = 7
    Const tabpage_Button_LAST = 8
    Const tabpage_Button_REFRESH = 9
    Const tabpage_Button_EXPORT = 10 'FDS DieuNDA them nut Export

    Const window_Button_NAVIGATE = 1
    Const window_Button_EXTERNAL = 2
    Const window_Button_REJECT = 3
    Const window_Button_APPROVE = 4
    Const window_Button_OK = 5
    Const window_Button_APPLY = 6
    Const window_Button_CANCEL = 7

    Const c_ResourceManager = "AppCore.frmMaster-"
    'VinhLD add for auto resize
    Const BASED_SCREEN_WIDTH = 800
    Const BASED_SCREEN_HEIGHT = 600
    Const BASED_FORM_WIDTH = 640
    Const BASED_FORM_HEIGHT = 500
    Const BASED_PANEL_WIDTH = 616
    Const BASED_PANEL_HEIGHT = 320
    ' end of VinhLD add for auto resize
    Dim mv_blnShowMode As Boolean = False 'False: Basic, True: Advanced
    Dim mv_xmlDocument As New Xml.XmlDocument

    Private mv_blnIsLoading As Boolean = True
    Private mv_blnIsRiskManagement As Boolean = False
    Private mv_intExecFlag As Integer
    Private mv_strLanguage As String
    Private mv_resourceManager As Resources.ResourceManager

    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String
    Private mv_strObjCareBy As String
    Private mv_strObjAutoID As String

    Private mv_strKeyField As String
    Private mv_strKeyType As String
    Private mv_strKeyValue As String
    Private mv_strParentValue As String
    Private mv_strParentObject As String
    Private mv_strParentModule As String

    Protected mv_arrObjGroups() As CGrpMaster
    Protected mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrRefObjFields() As CFieldMaster

    Private mv_strCompanyCode As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strAuthString As String
    Private mv_strTellerRight As String
    Private mv_strGroupCareBy As String
    Private mv_strBusDate As String

    Private mv_strLocalObject As String
    Private mv_strXMLFldMaster As String

    Protected mv_dsOldInput As DataSet
    Protected mv_dsInput As DataSet
    Dim mv_v_rtbData_RichTextBox As RichTextBox = New RichTextBox

    Private mv_saveButtonType As SaveButtonType

    Private mv_strLinkValue As String
    Private mv_strLinkField As String

    Private hLinkSrc As New Hashtable
    Private hLinkDes As New Hashtable
    Private mv_strNextDate As String
    Public mv_frmSearchScreen As frmSearch

    Private mv_strGLGRP As String
    Private mv_strCCYCD As String
    Private mv_strParentClause As String
    'VinhLD add for auto resize
    Private mv_dblWindowSizeXRatio As Double = 1
    Private mv_dblWindowSizeRatio_X As Double = 1
    Private mv_dblWindowSizeRatio_Y As Double = 1

    Private mv_FlagLog As String = "NONE"
    Private mv_arrMemoHash As Hashtable
    Protected mv_dsMemoInput As DataSet
    'end of VinhLD add for auto resize
#End Region

#Region " Properties "
    Public Property FlagLog() As String
        Get
            Return mv_FlagLog
        End Get
        Set(ByVal Value As String)
            mv_FlagLog = Value
        End Set
    End Property

    Public Property CompanyCode() As String
        Get
            Return mv_strCompanyCode
        End Get
        Set(ByVal Value As String)
            mv_strCompanyCode = Value
        End Set
    End Property

    Public Property ObjCareBy() As String
        Get
            Return mv_strObjCareBy
        End Get
        Set(ByVal Value As String)
            mv_strObjCareBy = Value
        End Set
    End Property

    Public Property ParentClause() As String
        Get
            Return mv_strParentClause
        End Get
        Set(ByVal Value As String)
            mv_strParentClause = Value
        End Set
    End Property

    Public Property ObjAutoID() As String
        Get
            Return mv_strObjAutoID
        End Get
        Set(ByVal Value As String)
            mv_strObjAutoID = Value
        End Set
    End Property

    Public ReadOnly Property attrSaveButtonType() As SaveButtonType
        Get
            Return mv_saveButtonType
        End Get
    End Property

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkField() As String
        Get
            Return mv_strLinkField
        End Get
        Set(ByVal Value As String)
            mv_strLinkField = Value
        End Set
    End Property

    Public Property NextDate() As String
        Get
            Return mv_strNextDate
        End Get
        Set(ByVal Value As String)
            mv_strNextDate = Value
        End Set
    End Property

    Public Property IsRiskManagement() As Boolean
        Get
            Return mv_blnIsRiskManagement
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsRiskManagement = Value
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

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return mv_strKeyField
        End Get
        Set(ByVal Value As String)
            mv_strKeyField = Value
        End Set
    End Property

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyType
        End Get
        Set(ByVal Value As String)
            mv_strKeyType = Value
        End Set
    End Property

    Public Property KeyFieldValue() As String
        Get
            Return mv_strKeyValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyValue = Replace(Value, ".", "")
        End Set
    End Property

    Public Property ParentValue() As String
        Get
            Return mv_strParentValue
        End Get
        Set(ByVal Value As String)
            mv_strParentValue = Replace(Value, ".", "")
        End Set
    End Property

    Public Property ParentObject() As String
        Get
            Return mv_strParentObject
        End Get
        Set(ByVal Value As String)
            mv_strParentObject = Value
        End Set
    End Property

    Public Property ParentModule() As String
        Get
            Return mv_strParentModule
        End Get
        Set(ByVal Value As String)
            mv_strParentModule = Value
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

    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
        End Set
    End Property


    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property


#End Region

#Region " Private functions "
    Private Sub ToggleFirstTabBasicAdvancedShow(Optional ByVal pv_ChangeMode As Boolean = True)
        Dim v_ctrl, v_btnData, v_lblCaption, v_lblDesc As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE, v_strTempValue As String
        Dim i, v_intPosition, v_intTop, v_count, v_panelIndex, v_tabIndex, v_ControlIndex, v_intPos As Integer, v_blnShowControl, v_blnFlagVisible As Boolean
        If pv_ChangeMode Then
            mv_blnShowMode = Not mv_blnShowMode
        End If

        'mv_blnShowMode = True 'Luôn hiển thị hết
        v_count = UBound(mv_arrObjFields)
        If v_count > 0 Then
            v_intPosition = 0
            Dim v_lngAddLength As Long = 0
            Dim v_intRow As Integer = 1
            For i = 0 To v_count - 1
                'Xac dinh cac control 
                v_tabIndex = mv_arrObjFields(i).TabIndex
                v_panelIndex = mv_arrObjFields(i).GroupIndex
                v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                v_panel.AutoScroll = False
                v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                v_lblDesc = v_panel.Controls(mv_arrObjFields(i).LabelIndex)
                v_lblCaption = v_panel.Controls(mv_arrObjFields(i).CaptionIndex)

                'Xác định vị trí hiển thị
                v_intTop = CONTROL_TOP + v_intPosition * (CONTROL_HEIGHT + CONTROL_GAP) + v_lngAddLength

                v_strTempValue = String.Empty
                If mv_arrObjFields(i).PDefName.Trim.Length > 0 And mv_arrObjFields(i).SubField.Trim = "Y" Then
                    v_intPos = mv_arrObjFields(i).PDefValue.Trim.IndexOf("[")
                    If v_intPos = 0 Then
                        v_strTempValue = GetControlValueByName(mv_arrObjFields(i).PDefName)
                        'Chi visible control neu gia tri hien tai
                        If mv_arrObjFields(i).PDefValue.IndexOf("[" & v_strTempValue & "]") >= 0 Then
                            v_blnFlagVisible = True
                        Else
                            v_blnFlagVisible = False
                        End If
                    Else
                        'Neu TagValue ko co gia tri thi THEO qui dinh
                        v_blnFlagVisible = False
                    End If
                Else
                    v_blnFlagVisible = True
                End If

                If mv_arrObjFields(i).ControlType = "R" And v_blnFlagVisible = True Then
                    v_intRow = mv_arrObjFields(i).FieldRow
                    v_lngAddLength += ((v_intRow - 1) * (CONTROL_HEIGHT - 10))
                Else
                    v_intRow = 1
                End If

                'Xac dinh control co duoc hien thi hay khong
                If (mv_blnShowMode And mv_arrObjFields(i).Visible And v_blnFlagVisible) Or _
                    (Not mv_blnShowMode And mv_arrObjFields(i).Mandatory And mv_arrObjFields(i).Visible And v_blnFlagVisible) Then
                    'mv_blnShowMode=TRUE, advanced mode, mv_blnShowMode=FALSE, basic mode
                    'Advanced mode will show all, Basic mode only shown mandatory field
                    v_blnShowControl = True
                    If mv_arrObjFields(i).ControlType = "L" Then
                        v_intPosition = v_intPosition + 4
                    Else
                        v_intPosition = v_intPosition + 1
                    End If
                Else
                    v_blnShowControl = False
                End If

                'Neu control duoc hien thi thi tinh toan lai vi tri tren man hinh
                v_ctrl.Visible = v_blnShowControl
                v_lblCaption.Visible = v_blnShowControl
                v_lblDesc.Visible = v_blnShowControl And (v_lblDesc.Text.Trim.Length > 0)
                v_ctrl.Top = v_intTop
                v_lblCaption.Top = v_intTop
                v_lblDesc.Top = v_intTop
                If ObjectName = "MT.SHVTXREQ" Or ObjectName = "MT.SHVSWIFT" Or ObjectName = "MT.MT9000" Or ObjectName = "ST.VSDTXINFO" Or ObjectName = "ST.VSDTXINFOHIST" Or ObjectName = "MT.WCRBLOG" Then
                    v_lblCaption.Visible = False

                End If


                If mv_arrObjFields(i).ButtonIndex <> -1 Then
                    v_btnData = v_panel.Controls(mv_arrObjFields(i).ButtonIndex)
                    v_btnData.Top = v_intTop
                    v_btnData.Left = v_lblDesc.Left
                    v_btnData.Visible = v_blnShowControl
                End If
                v_panel.AutoScroll = True
            Next
        End If
    End Sub

    Private Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Space
                Cursor.Current = Cursors.WaitCursor
                Cursor.Show()
            Case Keys.Enter 'Enter = Onclose de insert luon cho GD,Double_click =View 
                Cursor.Current = Cursors.WaitCursor
                Cursor.Show()
            Case Keys.Delete
        End Select
    End Sub


    Private Sub cboData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strSelectedValue, v_strFieldName, v_strTagValue, v_strTagListData As String, v_intIndex, v_count, i, v_tabIndex, v_panelIndex As Integer
        Dim v_combodata As ComboBoxEx, v_panel As Panel, v_ctrl As Control, v_blnRePositioningControl As Boolean
        Dim v_intPos As Integer
        Try
            v_blnRePositioningControl = False
            If mv_blnIsLoading Then Exit Sub
            'Scan all depend field

            '2011/10/14 - TruongLD Move len dau
            'PhuongHT
            Dim v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Neu dang nap du lieu cho combo thi bo qua
            Dim strFLDNAME As String, v_intIndex_1 As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String
            Dim v_strFULLNAME As String
            v_strFULLNAME = ""
            Dim v_xmlDocument As New Xml.XmlDocument, ctl As Control
            Dim v_strLookupName As String, j, v_intNodeIndex, v_intCount As Integer

            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 And (TypeOf (sender) Is ComboBoxEx) Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    'Tra cuu thong tin
                    If mv_arrObjFields(v_intIndex).LookUp = "Y" And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                        If Me.UserLanguage = gc_LANG_ENGLISH Then
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                        Else
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                        End If
                        'NamTv End.
                        'Lay thong tin chung ve giao dich
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        'Luu tru danh sach ket qua tra ve
                        v_strFULLDATA = v_strObjMsg
                        'Hien thi du lieu tu Lookup data
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    End If
                End If
            End If
            'End of PhuongHT
            'End TruongLD

            If TypeOf (sender) Is ComboBoxEx Then
                v_combodata = CType(sender, ComboBoxEx)
                If v_combodata.SelectedIndex <> -1 Then
                    v_strSelectedValue = CType(v_combodata.SelectedValue, String).Trim
                    v_intIndex = CType(sender, Control).Tag
                    v_strFieldName = mv_arrObjFields(v_intIndex).FieldName
                    mv_arrObjFields(v_intIndex).FieldValue = v_strSelectedValue
                    If v_strFieldName = "GLGRP" Then
                        mv_strGLGRP = v_strSelectedValue
                    ElseIf v_strFieldName = "CCYCD" Then
                        mv_strCCYCD = v_strSelectedValue
                    End If

                    v_count = UBound(mv_arrObjFields)


                    For i = 0 To v_count - 1 Step 1
                        'v_ctrl = GetControlByName(mv_arrObjFields(i).FieldName)
                        v_ctrl = GetControlByIndex(i)
                        If v_strFieldName = "GLGRP" Or v_strFieldName = "CCYCD" Then
                            If mv_arrObjFields(i).ControlType = "L" Then
                                'v_tabIndex = mv_arrObjFields(i).TabIndex
                                'v_panelIndex = mv_arrObjFields(i).GroupIndex
                                'v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                'v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                                DoFillReturnValue(mv_strGLGRP, Me.ModuleCode, CType(v_ctrl, ListView), mv_strCCYCD)
                            End If
                        End If

                        If String.Compare(v_strFieldName, mv_arrObjFields(i).TagField) = 0 Then
                            'Enabled or Disabled control based on TagValue selected
                            'Lay gia tri cua truong tham chieu TAGFIELD
                            'TAGVALUE co dang FIELDNAME[FIELDVALUE]
                            'Neu FIELDNAME = "" -> truong tham chieu la TAGFIELD, FIELDVALUE lay gia tri cua TAGFIELD
                            'Neu khong thi truong tham chieu la FIELDNAME, so sanh FIELDVALUE theo gia tri cua FIELDNAME
                            'Gia tri cua truong tham chieu = FIELDVALUE -> enable control                            
                            v_strTagValue = mv_arrObjFields(i).TagValue.Trim
                            v_intPos = mv_arrObjFields(i).TagValue.Trim.IndexOf("[")
                            If v_intPos = 0 Then
                                If (v_strTagValue.IndexOf("[" & v_strSelectedValue & "]") >= 0 Or v_strTagValue.Trim.Length = 0) Then
                                    If Me.ExeFlag = ExecuteFlag.Edit And mv_arrObjFields(i).RiskField = True Then
                                        v_ctrl.Enabled = False
                                    Else
                                        v_ctrl.Enabled = True
                                        v_ctrl.BackColor = Drawing.Color.White
                                    End If
                                    If Len(mv_arrObjFields(i).SearchCode) > 0 Then
                                        v_ctrl.BackColor = System.Drawing.Color.GreenYellow
                                    ElseIf Len(mv_arrObjFields(i).LookupList) > 0 And mv_arrObjFields(i).ControlType = "T" Then
                                        v_ctrl.BackColor = System.Drawing.Color.Khaki
                                    End If
                                Else
                                    v_ctrl.Enabled = False
                                    v_ctrl.BackColor = System.Drawing.Color.LightGray
                                    If mv_arrObjFields(i).DefaultValue <> String.Empty Then
                                        If TypeOf (v_ctrl) Is ComboBoxEx Then
                                            CType(v_ctrl, ComboBoxEx).SelectedValue = mv_arrObjFields(i).DefaultValue
                                            mv_arrObjFields(i).FieldValue = CType(v_ctrl, ComboBoxEx).SelectedValue
                                        ElseIf TypeOf (v_ctrl) Is TextBox Or TypeOf (v_ctrl) Is FlexMaskEditBox Then
                                            v_ctrl.Text = mv_arrObjFields(i).DefaultValue
                                            mv_arrObjFields(i).FieldValue = v_ctrl.Text
                                        End If
                                    End If
                                End If
                            Else
                                v_ctrl.Enabled = mv_arrObjFields(i).Enabled
                                v_ctrl.BackColor = Drawing.Color.White
                            End If

                            'Reload relate combo box
                            v_strTagListData = mv_arrObjFields(i).TagListData.Trim
                            If v_strTagListData.Length > 0 And mv_arrObjFields(i).ControlType = "C" Then
                                If mv_arrObjFields(i).TagField.Length > 0 Then
                                    Dim v_strCmdSQLTagList As String = mv_arrObjFields(i).TagList.Trim.Replace("<$TAGFIELD>", GetFieldValueByName(mv_arrObjFields(i).TagField))
                                    'FDS DieuNDA Them <$PARENTID>
                                    v_strCmdSQLTagList = v_strCmdSQLTagList.Replace("<$PARENTID>", Me.ParentValue)
                                    'End FDS DieuNDA
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQLTagList)
                                    v_ws.Message(v_strObjMsg)
                                    mv_arrObjFields(i).TagListData = v_strObjMsg
                                    v_strTagListData = mv_arrObjFields(i).TagListData.Trim
                                End If
                                mv_blnIsLoading = True
                                FillComboEx(v_strTagListData, CType(v_ctrl, ComboBoxEx), v_strSelectedValue, Me.UserLanguage)
                                mv_blnIsLoading = False
                            End If
                        End If

                        'Nếu giá trị của combo làm ảnh hưởng đến subfield
                        If mv_arrObjFields(i).SubField.Trim = "Y" And String.Compare(v_strFieldName, mv_arrObjFields(i).PDefName) = 0 Then
                            v_blnRePositioningControl = True
                            'FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                        End If

                        'Trường Description
                        If mv_arrObjFields(i).DefDesc.Length > 0 Then
                            v_ctrl.Text = FillDefinitionDescription(i)
                        End If
                    Next
                    'Sắp xếp lại màn hình theo lựa chọn mới của Combo
                    If v_blnRePositioningControl Then ToggleFirstTabBasicAdvancedShow(False)
                End If
            End If


            ''PhuongHT
            'Dim v_strObjMsg As String
            'Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            ''Neu dang nap du lieu cho combo thi bo qua
            '' If mv_blnOnDisplayScreen = True Then Exit Sub


            '=======
            'Dim strFLDNAME As String, v_intIndex_1 As Integer
            'Dim v_strSQLCMD, v_strFULLDATA As String
            'Dim v_nodeList As Xml.XmlNodeList
            'Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            'Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            'Dim v_strModule, v_strFldSource, v_strFldDesc As String
            'Dim v_strFULLNAME As String
            'v_strFULLNAME = ""
            'Dim v_xmlDocument As New Xml.XmlDocument, ctl As Control
            'Dim v_strLookupName As String, j, v_intNodeIndex, v_intCount As Integer
            '>>>>>>> .r2069

            'If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 And (TypeOf (sender) Is ComboBoxEx) Then
            '    v_intIndex = CType(sender, Control).Tag
            '    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
            '        v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
            '        strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
            '        'Tra cuu thong tin
            '        If mv_arrObjFields(v_intIndex).LookUp = "Y" And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
            '            v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
            '            'Lay thong tin chung ve giao dich
            '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
            '            v_ws.Message(v_strObjMsg)
            '            'Luu tru danh sach ket qua tra ve
            '            v_strFULLDATA = v_strObjMsg
            '            'Hien thi du lieu tu Lookup data
            '            FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
            '        End If
            '    End If
            'End If
            ''end of PhuongHT

            '<<<<<<< .TanTV add
            If v_strFieldName = "DFTYPE" And v_strSelectedValue = "L" Then
                For i = 0 To v_count - 1 Step 1

                    If mv_arrObjFields(i).FieldName = "RRTYPE" Then
                        v_ctrl = GetControlByIndex(i)
                        If (v_ctrl.Text.Trim = "Giải ngân từ CI") Then
                            If Me.UserLanguage = "EN" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_INVALID_VALUE"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_INVALID_VALUE"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            v_ctrl.Focus()
                            v_ctrl.Text = "Nguồn công ty"
                        End If
                        'CType(v_ctrl, ComboBox).Items.RemoveAt(2)
                    End If
                Next
            End If


            If v_strFieldName = "RRTYPE" And v_strSelectedValue = "O" Then
                For i = 0 To v_count - 1 Step 1

                    If mv_arrObjFields(i).FieldName = "DFTYPE" Then
                        v_ctrl = GetControlByIndex(i)
                        If (v_ctrl.Text.Trim = "Margin loan") Then
                            If Me.UserLanguage = "EN" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_INVALID_VALUE"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_INVALID_VALUE"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            v_ctrl.Focus()
                            v_ctrl.Text = "Forward on trading"
                        End If
                        'CType(v_ctrl, ComboBox).Items.RemoveAt(2)
                    End If
                Next

            End If

            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 And (TypeOf (sender) Is ComboBoxEx) Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    'Tra cuu thong tin
                    If mv_arrObjFields(v_intIndex).LookUp = "Y" And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                        If Me.UserLanguage = gc_LANG_ENGLISH Then
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                        Else
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                        End If
                        'NamTv End.
                        'Lay thong tin chung ve giao dich
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        'Luu tru danh sach ket qua tra ve
                        v_strFULLDATA = v_strObjMsg
                        'Hien thi du lieu tu Lookup data
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    End If
                End If
            End If
            ' end of TanTV add
            ExecFldval()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub cboData_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Dim v_strSelectedValue, v_strFieldName, v_strTagValue, v_strTagListData As String, v_intIndex, v_count, i, v_tabIndex, v_panelIndex As Integer
        'Dim v_combodata As ComboBoxEx, v_panel As Panel, v_ctrl As Control, v_blnRePositioningControl As Boolean
        'Dim v_intPos As Integer
        Dim v_intIndex As Integer
        Dim v_bolCheck As Boolean
        Dim v_strFieldValue, strFLDNAME, v_strSQLCMD, v_strFULLDATA As String
        Try
            'v_blnRePositioningControl = False
            If mv_blnIsLoading Then Exit Sub
            'Scan all depend field

            '2011/10/14 - TruongLD Move len dau
            'PhuongHT
            Dim v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery


            'Check the data if the field is in SEARCHCODE or LOOKUP command sql


            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 And (TypeOf (sender) Is ComboBoxEx) Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 And Len(v_strFieldValue) > 0 Then
                        v_bolCheck = FillControlValueBySearchCode(CType(sender, Control), v_strFieldValue, strFLDNAME)
                        If mv_arrObjFields(v_intIndex).LookupCheck <> "N" And Not v_bolCheck Then
                            If Me.UserLanguage = "EN" And Me.mv_strObjectName <> "FA.FAMEMBERS" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            ElseIf Me.mv_strObjectName = "FA.FAMEMBERS" Then
                                Exit Sub
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            e.Cancel = True
                            Exit Sub
                        End If
                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" And Len(v_strFieldValue) > 0 Then
                        v_bolCheck = FillControlValueByLookup(CType(sender, Control), v_strFieldValue, strFLDNAME)
                        If mv_arrObjFields(v_intIndex).LookupCheck <> "N" And Not v_bolCheck Then
                            If Me.UserLanguage = "EN" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            e.Cancel = True
                            Exit Sub
                        End If

                    End If
                End If
            End If




            'ExecFldval()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_mskctrl As FlexMaskEditBox
            Dim v_txtctrl As TextBox
            If (TypeOf (sender) Is FlexMaskEditBox) Then
                v_mskctrl = CType(sender, FlexMaskEditBox)
                v_mskctrl.SelectionStart = 0
                v_mskctrl.SelectionLength = Len(v_mskctrl.Text)
            ElseIf (TypeOf (sender) Is TextBox) Then
                v_txtctrl = CType(sender, TextBox)
                v_txtctrl.SelectionStart = 0
                v_txtctrl.SelectionLength = Len(v_txtctrl.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim i, v_count As Integer, v_ctl As Control
        Dim strFLDNAME As String, v_intIndex As Integer
        Dim v_strSQLCMD, v_strFULLDATA As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
        Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
        Dim v_strModule, v_strFldSource, v_strFldDesc As String
        Dim v_bolCheck As Boolean = False
        Try
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    v_strFieldValue = CType(sender, Control).Text.ToUpper()
                    'CType(sender, Control).Text = CType(sender, Control).Text.ToUpper()
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    'Check mandatory field
                    If mv_arrObjFields(v_intIndex).Mandatory = True And Len(v_strFieldValue) = 0 And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        If Me.UserLanguage = "EN" Then
                            MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Else
                            MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                        e.Cancel = True
                        Exit Sub
                    End If
                    'Check the datatype
                    If Len(v_strFieldValue) > 0 Then
                        v_strDataType = Trim(mv_arrObjFields(v_intIndex).DataType)
                        Select Case v_strDataType
                            Case "N"
                                If Not IsNumeric(v_strFieldValue) Then
                                    'Numeric value
                                    If Me.UserLanguage = "EN" Then
                                        MsgBox(Replace(ResourceManager.GetString("ERR_NUMERIC_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    Else
                                        MsgBox(Replace(ResourceManager.GetString("ERR_NUMERIC_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    End If
                                    e.Cancel = True
                                    Exit Sub
                                Else
                                    'Too big number
                                    FormatNumericTextbox(CType(sender, TextBox))
                                    If Len(v_strFieldValue) > 30 Then
                                        If Me.UserLanguage = "EN" Then
                                            MsgBox(Replace(ResourceManager.GetString("ERR_OVER_DBL_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                        Else
                                            MsgBox(Replace(ResourceManager.GetString("ERR_OVER_DBL_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                        End If
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                End If
                            Case "D"
                                If v_strFieldValue <> "  /  /" And Not IsDateValue(v_strFieldValue) Then
                                    'Date value
                                    If Me.UserLanguage = "EN" Then
                                        MsgBox(Replace(ResourceManager.GetString("ERR_DATE_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    Else
                                        MsgBox(Replace(ResourceManager.GetString("ERR_DATE_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    End If
                                    e.Cancel = True
                                    Exit Sub
                                End If
                        End Select
                    End If
                    'Check the data if the field is in SEARCHCODE or LOOKUP command sql
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 And Len(v_strFieldValue) > 0 Then
                        v_bolCheck = FillControlValueBySearchCode(CType(sender, Control), v_strFieldValue, strFLDNAME)
                        If mv_arrObjFields(v_intIndex).LookupCheck <> "N" And Not v_bolCheck Then
                            If Me.UserLanguage = "EN" And Me.mv_strObjectName <> "FA.FAMEMBERS" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            ElseIf Me.mv_strObjectName = "FA.FAMEMBERS" Then
                                Exit Sub
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            e.Cancel = True
                            Exit Sub
                        End If
                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" And Len(v_strFieldValue) > 0 Then
                        v_bolCheck = FillControlValueByLookup(CType(sender, Control), v_strFieldValue, strFLDNAME)
                        If mv_arrObjFields(v_intIndex).LookupCheck <> "N" And Not v_bolCheck Then
                            If Me.UserLanguage = "EN" Then
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Else
                                MsgBox(Replace(ResourceManager.GetString("ERR_LOOKUP_VALUE"), "@", mv_arrObjFields(v_intIndex).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            e.Cancel = True
                            Exit Sub
                        End If
                    Else
                        'Xử lý trường hợp liên quan đến Description
                        v_count = UBound(mv_arrObjFields)
                        For i = 0 To v_count - 1
                            If mv_arrObjFields(i).DefDesc.Length > 0 And mv_arrObjFields(i).DefParam.IndexOf(PREFIXED_REFMASTER & mv_arrObjFields(v_intIndex).FieldName) >= 0 Then
                                v_ctl = GetControlByIndex(i)
                                v_ctl.Text = FillDefinitionDescription(i)
                            End If

                        Next
                    End If

                    ''PhuongHT add lookup ja tri OPTSYMBOL trong man hinh CAMAST,co tuc bang quyen mua
                    'If String.Compare(Me.ObjectName, "CA.CAMAST") = 0 And String.Compare(mv_arrObjFields(v_intIndex).FieldName, "REPORTDATE") = 0 Then
                    '    Dim v_strTEMPVAL As String
                    '    v_strTEMPVAL = String.Empty
                    '    v_strTEMPVAL = GetControlValueByName("CODEID", "T")
                    '    v_strTEMPVAL = v_strTEMPVAL & "_" & CDate(GetControlValueByName("REPORTDATE")).ToString("MMyy")
                    '    v_ctl = GetControlByName("014OPTSYMBOL")
                    '    v_ctl.Text = v_strTEMPVAL
                    'End If
                    ' end of PhuongHT add
                    If String.Compare(Me.ObjectName, "CA.CAMAST") = 0 Then
                        Dim v_strTEMPVAL As String
                        Dim v_strCatype As String
                        Dim v_strFieldName As String
                        v_strTEMPVAL = String.Empty
                        v_strCatype = String.Empty
                        v_strFieldName = String.Empty
                        If String.Compare(Me.ObjectName, "CA.CAMAST") = 0 And String.Compare(mv_arrObjFields(v_intIndex).FieldName, "014FRDATETRANSFER") = 0 Then
                            v_strTEMPVAL = GetControlValueByName("014FRDATETRANSFER")
                            v_ctl = GetControlByName("014BEGINDATE")
                            v_ctl.Text = v_strTEMPVAL
                        End If
                        'PhuongHT add lookup ja tri PURPOSEDESC trong man hinh CAMAST
                        If String.Compare(Me.ObjectName, "CA.CAMAST") = 0 And String.Compare(mv_arrObjFields(v_intIndex).FieldName, "PURPOSEDESC") = 0 And Trim(GetControlValueByName("PURPOSEDESC")).Length = 0 Then

                            v_strCatype = GetControlValueByName("CATYPE")
                            v_strFieldName = v_strCatype & "DESCRIPTION"
                            v_strTEMPVAL = GetControlValueByName(v_strFieldName)
                            v_ctl = GetControlByName("PURPOSEDESC")
                            v_ctl.Text = v_strTEMPVAL
                        End If

                        'end of PhuongHT add
                    End If
                End If
            End If
            ExecFldval()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Sub FillDataCombo(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBox)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_int, v_index As Integer
        Try
            v_int = 0
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim v_arrValue(v_nodeList.Count)
            ReDim v_arrDisplay(v_nodeList.Count)
            For i As Integer = 0 To v_nodeList.Count - 1
                v_int += 1
                'Get data
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_arrValue(v_int) = Trim(v_strValue)
                            Case "DISPLAY"
                                v_arrDisplay(v_int) = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    Private Function GetInventoryValue(ByVal v_strInvName As String, ByVal v_strInvFormat As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetInventoryValue"
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            Dim v_strObjMsg, v_strClause, v_strAutoID, v_strAutoPrefix, v_strBufferAutoPrefix, v_strAutoString, v_strFLDTAG, v_strFLDNAME, v_strVALUE As String
            Dim v_intStart, v_intStop As Integer
            Const START_PREFIED = "<$"
            Const END_PREFIED = ">"

            'v_strInvFormat: The inventory format. <$BRID>000000, <$CUSTODYCD>000000, <$fieldname>[000000]. 
            'The auto number must be at the end of inventory string
            v_intStart = v_strInvFormat.IndexOf("[")
            v_intStop = v_strInvFormat.IndexOf("]")
            v_strAutoString = v_strInvFormat.Substring(v_intStart + 1, v_intStop - v_intStart - 1)
            v_strAutoPrefix = v_strInvFormat.Replace("[" & v_strAutoString & "]", String.Empty)

            'Xu ly Prefix value
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$BRID>", Me.BranchId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$TLID>", Me.TellerId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$BUSDATE>", Me.BusDate)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$CUSTODYCD>", System.Configuration.ConfigurationManager.AppSettings("PrefixedCustodyCode") & "C")
            v_strBufferAutoPrefix = v_strAutoPrefix
            v_intStart = 0
            v_intStop = v_strAutoPrefix.IndexOf(START_PREFIED, v_intStart)
            While v_intStop >= 0
                v_intStart = v_intStop + 2
                v_intStop = v_strAutoPrefix.IndexOf(END_PREFIED, v_intStart)
                If v_intStop > 0 Then
                    v_strFLDNAME = v_strAutoPrefix.Substring(v_intStart, v_intStop - v_intStart)
                    If String.Compare(v_strFLDNAME, "BRANCHID") = 0 Then
                        'TIM DEN CONTROL LUA CHON CHI NHANH
                        v_strFLDTAG = GetControlValueByName("BRID")
                    Else
                        v_strFLDTAG = GetControlValueByName(v_strFLDNAME)
                    End If
                    v_strBufferAutoPrefix = v_strBufferAutoPrefix.Replace(START_PREFIED & v_strFLDNAME & END_PREFIED, v_strFLDTAG)
                    v_intStop = v_strAutoPrefix.IndexOf(START_PREFIED, v_intStart)
                Else
                    v_intStop = -1
                End If
            End While
            v_strAutoPrefix = v_strBufferAutoPrefix

            'Get inventory
            v_strClause = v_strInvName
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory", , , v_strAutoPrefix)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
            v_strAutoID = Strings.Right(v_strAutoString.Trim & CStr(v_strAutoID), v_strAutoString.Trim.Length)
            v_strAutoID = v_strAutoPrefix & v_strAutoID
            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & "-" & v_strInvName & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function FillControlValueBySearchCode(ByVal v_ctrl As Control, ByVal v_strFieldValue As String, ByVal strFLDNAME As String) As Boolean
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".FillControlValueBySearchCode"
        Dim ctlCheck As Windows.Forms.Control, v_panel As Panel, v_intIndex As Integer
        Dim v_strObjMsg, v_strSQLCMD, v_strValue As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Get the parent panel & the field index
            v_intIndex = v_ctrl.Tag
            v_panel = v_ctrl.Parent
            If v_panel Is Nothing Then Exit Function
            ctlCheck = v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
            If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                'Kiá»ƒm tra xem dá»¯ liá»‡u nháº­p vÃ o cÃ³ Ä‘Ãºng khÃ´ng?
                v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                v_strKeyVal = Replace(v_strFieldValue, ".", "")
                'Láº¥y KeyName
                'v_strSQLCMD = "SELECT FLDMASTER.OBJNAME,SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL, SEFLD.FIELDCODE FROM SEARCHFLD,SEARCH,FLDMASTER, SEARCHFLD SEFLD " & ControlChars.CrLf _
                '& " WHERE FLDMASTER.FLDNAME = SEARCHFLD.FIELDCODE AND SUBSTR(FLDMASTER.OBJNAME,4) = SEARCH.SEARCHCODE AND SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                '& " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "' " & ControlChars.CrLf _
                '& " AND SEFLD.SEARCHCODE = SEARCH.SEARCHCODE AND SEFLD.REFVALUE = 'Y' "

                v_strSQLCMD = "SELECT SEARCH.OBJNAME, SEARCHFLD.FIELDCODE KEYNAME, SEARCH.SEARCHCMDSQL, SEFLD.FIELDCODE FROM SEARCHFLD,SEARCH, SEARCHFLD SEFLD " & ControlChars.CrLf _
                & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "' " & ControlChars.CrLf _
                & " AND SEFLD.SEARCHCODE = SEARCH.SEARCHCODE AND SEFLD.REFVALUE = 'Y' "

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
                                    Case "OBJNAME"
                                        v_strOBJNAME = Trim(v_strValue)
                                    Case "FIELDCODE"
                                        v_strFIELDCODE = Trim(v_strValue)
                                End Select
                            End With
                        Next

                    Next

                    'Náº¡p giÃ¡ trá»‹ tÆ°Æ¡ng á»©ng cho cÃ¡c trÆ°Æ¡ng khÃ¡c
                    Dim v_strClause As String
                    v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$TLID>", Me.TellerId)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTID>", Me.ParentValue)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTOBJ>", Me.ParentObject)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTMOD>", Me.ParentModule)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$KEYVALUE>", Me.KeyFieldValue)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$OBJNAME>", Me.ObjectName)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$MODCODE>", Me.ModuleCode)

                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                    Else
                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQLCMD)
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

                        Dim v_ctl As Control
                        v_ctl = v_panel.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                        v_ctl.Top = ctlCheck.Top
                        v_ctl.Text = v_strRefValue
                        v_ctl.Visible = True
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                    Else
                        Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function FillControlValueByLookup(ByVal v_ctrl As Control, ByVal v_strFieldValue As String, ByVal strFLDNAME As String) As Boolean
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".FillControlValueByLookup"
        Dim ctlCheck As Windows.Forms.Control, v_panel As Panel, v_intIndex As Integer
        Dim v_strObjMsg, v_strSQLCMD, v_strValue, v_strDisplay, v_strFULLDATA As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Get the parent panel & the field index
            v_intIndex = v_ctrl.Tag
            v_panel = v_ctrl.Parent
            If v_panel Is Nothing Then Exit Function
            ctlCheck = v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
            Dim v_strFILTERID As String
            'Get filterid from related field (TAGFIELD)
            If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                v_strFILTERID = GetControlValueByName(mv_arrObjFields(v_intIndex).TagField)
            Else
                v_strFILTERID = String.Empty
            End If

            If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                v_strSQLCMD = v_strSQLCMD.Replace("<$TAGFIELD>", v_strFILTERID)
                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", Me.BranchId)
                v_strSQLCMD = v_strSQLCMD.Replace("<$TLID>", Me.TellerId)
                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTID>", Me.ParentValue)
                v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTOBJ>", Me.ParentObject)
                v_strSQLCMD = v_strSQLCMD.Replace("<$PARENTMOD>", Me.ParentModule)
                v_strSQLCMD = v_strSQLCMD.Replace("<$KEYVALUE>", Me.KeyFieldValue)
                v_strSQLCMD = v_strSQLCMD.Replace("<$OBJNAME>", Me.ObjectName)
                v_strSQLCMD = v_strSQLCMD.Replace("<$MODCODE>", Me.ModuleCode)
                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                Else
                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                End If
                'NamTv End.
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
                                    'Show detail on the label
                                    Dim ctl As Control
                                    ctl = v_panel.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    ctl.Top = v_ctrl.Top
                                    ctl.Text = v_strDisplay
                                    ctl.Visible = True
                                    FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                                    Return True
                                End If
                            End If
                        End With
                    Next
                Next
            End If
            Return False
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    'Tự động tạo description cho trường thông tin
    Private Function FillDefinitionDescription(ByVal v_intIDXFIELD As Integer) As String
        Dim v_strDefDesc, v_strDesc, v_strDefVal As String, i, v_intParams As Integer, v_arrParams() As String, v_ctl As Control
        Try
            v_strDesc = String.Empty
            If Not mv_arrObjFields(v_intIDXFIELD) Is Nothing Then
                If mv_arrObjFields(v_intIDXFIELD).DefDesc.Trim.Length > 0 Then
                    'Chuỗi khai báo để có thể sử dụng được hàm String.Format
                    v_strDefDesc = mv_arrObjFields(v_intIDXFIELD).DefDesc
                    v_intParams = CharCount(mv_arrObjFields(v_intIDXFIELD).DefParam, ",")
                    If v_intParams > 0 Then
                        'Tạo mảng các tham số
                        v_arrParams = mv_arrObjFields(v_intIDXFIELD).DefParam.Split(",")
                        For i = 0 To v_intParams Step 1
                            If Not v_arrParams(i) Is Nothing Then
                                'Xác định giá trị cho biết
                                v_strDefVal = v_arrParams(i).ToString.Trim
                                If String.Compare(v_strDefVal, "<$BRID>") = 0 Then v_strDefVal = Me.BranchId
                                If String.Compare(v_strDefVal, "<$TLID>") = 0 Then v_strDefVal = Me.TellerId
                                If String.Compare(v_strDefVal, "<$BUSDATE>") = 0 Then v_strDefVal = Me.BusDate
                                If String.Compare(v_strDefVal, "<$PARENTID>") = 0 Then v_strDefVal = Me.ParentValue
                                If String.Compare(v_strDefVal, "<$PARENTOBJ>") = 0 Then v_strDefVal = Me.ParentObject
                                If String.Compare(v_strDefVal, "<$PARENTMOD>") = 0 Then v_strDefVal = Me.ParentModule
                                If String.Compare(v_strDefVal, "<$KEYVALUE>") = 0 Then v_strDefVal = Me.KeyFieldValue
                                If String.Compare(v_strDefVal, "<$OBJNAME>") = 0 Then v_strDefVal = Me.ObjectName
                                If String.Compare(v_strDefVal, "<$MODCODE>") = 0 Then v_strDefVal = Me.ModuleCode
                                If String.Compare(v_strDefVal, "<$COMPANYCD>") = 0 Then v_strDefVal = Me.CompanyCode
                                If v_strDefVal.IndexOf(PREFIXED_REFMASTER) >= 0 Then
                                    'Neu la truong tham chieu tu object cha
                                    v_strDefVal = GetControlValueByName(v_strDefVal, "T")
                                End If
                                v_arrParams(i) = v_strDefVal
                            End If
                        Next
                        'Parse lại giá trị
                        v_strDesc = String.Format(v_strDefDesc, v_arrParams)
                        Return v_strDesc
                    End If
                End If
            End If
            Return v_strDesc
        Catch ex As Exception
        Finally
        End Try
    End Function

    Private Sub FillLookupData(ByVal v_strFLDNAME As String, ByVal v_strVALUE As String, ByVal v_strFULLDATA As String, Optional ByVal v_strFieldKey As String = "VALUE")
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, ctl As Control, v_pnControl As Panel
        Dim v_strLookupName As String, i, j, v_intNodeIndex, v_intCount As Integer
        Dim v_intPos As Int16, strFLDNAME As String, v_intIndex, vintCVALIndex, vintNVALIndex, vcboItemIndex As Integer
        Dim v_strFLDVALUE, v_strVALEXP, v_strTEMPVAL As String, v_ctl, v_panel As Control, v_tabIndex, v_panelIndex As Integer
        Dim v_strREF_DEFVAL, v_strREF_MANDARTORY, v_strREF_DATATYPE, v_strREF_FLDMASK, v_strREF_FLDFORMAT, _
                v_strREF_FLDLEN, v_strREF_CTLTYPE, v_strREF_LOOKUP, v_strREF_SEARCHCODE, v_strREF_LOOKUPNAME, v_strCMDLOOKUP As String
        Dim pos As Integer
        Dim v_strTempValue As String = String.Empty
        Dim v_strRefField As String = String.Empty
        Dim v_blnEnabled As Boolean
        Dim v_strCMDSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            v_xmlDocument.LoadXml(v_strFULLDATA)
            v_intCount = mv_arrObjFields.GetLength(0)
            vintCVALIndex = -1
            vintNVALIndex = -1
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

                If strFLDNAME = "GLGRP" Then
                    mv_strGLGRP = v_strVALUE
                ElseIf strFLDNAME = "CCYCD" Then
                    mv_strCCYCD = v_strVALUE
                End If

                'Nap du lieu Lookup cho cac control duoc khai bao
                For i = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(i) Is Nothing Then
                        v_ctl = GetControlByIndex(i) 'GetControlByName(mv_arrObjFields(i).FieldName)

                        If String.Compare(Me.ObjectName, "SA.EXTREFVAL") = 0 Then
                            'Ghi nhan index cua CVAL & NVAL neu la external reference
                            If String.Compare(mv_arrObjFields(i).FieldName, "CVAL") = 0 Then
                                vintCVALIndex = i
                            ElseIf String.Compare(mv_arrObjFields(i).FieldName, "NVAL") = 0 Then
                                vintNVALIndex = i
                            End If


                        End If

                        'Nap lai account entries neu la control khai bao GLGRP hay CCYCD
                        If strFLDNAME = "GLGRP" Or strFLDNAME = "CCYCD" Then

                            If Me.ExeFlag = ExecuteFlag.Edit Or Me.ExeFlag = ExecuteFlag.AddNew Then
                                If mv_arrObjFields(i).ControlType = "L" Then
                                    'v_ctl = GetControlByName(mv_arrObjFields(i).FieldName)
                                    DoFillReturnValue(mv_strGLGRP, Me.ModuleCode, CType(v_ctl, ListView), mv_strCCYCD)
                                End If
                            End If
                        End If

                        'Xử lý cho field thông thường
                        'Enable control BY TAGFIELD & TAGVALUE
                        If (Not mv_arrObjFields(i).RiskField) Then
                            'If (Me.ExeFlag = ExecuteFlag.Edit And Not mv_arrObjFields(i).RiskField) Or Me.ExeFlag = ExecuteFlag.AddNew Or Me.ExeFlag = ExecuteFlag.View Then
                            If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                                v_strTempValue = String.Empty
                                pos = Trim(mv_arrObjFields(i).TagValue).IndexOf("[")
                                If pos > 0 Then
                                    v_strRefField = Trim(mv_arrObjFields(i).TagValue).Substring(0, pos)
                                    For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                        With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                            If v_strRefField = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                                v_strTempValue = Trim(.InnerText.ToString)
                                            End If
                                        End With
                                    Next
                                Else
                                    'v_strTempValue = GetFieldValueByName(mv_arrObjFields(i).TagField)
                                    If Not mv_arrObjFields Is Nothing Then
                                        Dim v_count = UBound(mv_arrObjFields)
                                        For k As Integer = 0 To v_count - 1
                                            If String.Compare(mv_arrObjFields(k).FieldName, mv_arrObjFields(i).TagField) = 0 Then
                                                v_strFLDVALUE = mv_arrObjFields(k).FieldValue
                                                If mv_arrObjFields(k).ControlType = "C" Then
                                                    v_strTempValue = CType(GetControlByName(mv_arrObjFields(k).FieldName), ComboBoxEx).SelectedValue
                                                Else
                                                    v_strTempValue = GetControlByName(mv_arrObjFields(k).FieldName).Text
                                                End If
                                            End If
                                        Next
                                    End If

                                End If

                                If mv_arrObjFields(i).TagValue.Trim.Length > 0 Then
                                    If mv_arrObjFields(i).TagValue.IndexOf("[" & v_strTempValue & "]") >= 0 Then
                                        v_blnEnabled = True
                                    Else
                                        v_blnEnabled = False
                                    End If
                                    'v_tabIndex = mv_arrObjFields(i).TabIndex
                                    'v_panelIndex = mv_arrObjFields(i).GroupIndex
                                    'v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                    'v_ctl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                                    v_ctl.Enabled = v_blnEnabled
                                End If
                            End If
                        End If

                        'Fill lookup BY TAGFIELD:  And mv_arrObjFields(i).TagUpdate = "N" 
                        If Trim(mv_arrObjFields(i).LookupName).Length > 0 Then
                            'If Trim(mv_arrObjFields(i).LookupName).Length > 0 And (Me.ExeFlag = ExecuteFlag.AddNew Or Me.ExeFlag = ExecuteFlag.Edit) Then
                            If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                                v_strLookupName = mv_arrObjFields(i).LookupName.Trim
                                For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                    With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                        If v_strLookupName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                            'Get panel via GroupIndex
                                            'v_tabIndex = mv_arrObjFields(i).TabIndex
                                            'v_panelIndex = mv_arrObjFields(i).GroupIndex
                                            'v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                            'v_ctl = v_panel.Controls(mv_arrObjFields(i).ControlIndex) 'Get control via Panel.ControlIndex
                                            v_strTEMPVAL = Trim(.InnerText.ToString)

                                            ''PhuongHT add lookup ja tri OPTSYMBOL trong man hinh CAMAST,co tuc bang quyen mua
                                            'If String.Compare(Me.ObjectName, "CA.CAMAST") = 0 And String.Compare(v_strLookupName, "OPTSYMBOL") = 0 Then
                                            '    v_strTEMPVAL = v_strTEMPVAL & "_" & CDate(GetControlValueByName("REPORTDATE")).ToString("MMyy")
                                            'End If
                                            '' end of PhuongHT add

                                            If TypeOf (v_ctl) Is TextBox Then
                                                CType(v_ctl, TextBox).Text = v_strTEMPVAL
                                                If mv_arrObjFields(i).DataType = "N" Then
                                                    FormatNumericTextbox(CType(v_ctl, TextBox))
                                                End If
                                            ElseIf TypeOf (v_ctl) Is FlexMaskEditBox Then
                                                CType(v_ctl, FlexMaskEditBox).Text = v_strTEMPVAL
                                                If mv_arrObjFields(i).DataType = "N" Then
                                                    FormatNumericTextbox(CType(v_ctl, TextBox))
                                                End If
                                            ElseIf TypeOf (v_ctl) Is ComboBox Or TypeOf (v_ctl) Is ComboBoxEx Then
                                                CType(v_ctl, ComboBoxEx).SelectedValue = v_strTEMPVAL
                                            End If
                                        End If
                                    End With
                                Next
                            End If
                        ElseIf Trim(mv_arrObjFields(i).TagList).Length > 0 Then
                            If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                                If mv_arrObjFields(i).ControlType = "C" Then
                                    v_strCMDSQL = mv_arrObjFields(i).TagList.Replace("<$TAGFIELD>", v_strVALUE)
                                    ''Lay du lieu
                                    'v_ctl = CType(v_panel.Controls(mv_arrObjFields(i).ControlIndex), ComboBoxEx)
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
                                    v_ws.Message(v_strObjMsg)
                                    mv_blnIsLoading = True    'Disable selected index change
                                    FillComboEx(v_strObjMsg, v_ctl, "", Me.UserLanguage)
                                    If Trim(mv_arrObjFields(i).DefaultValue).Length > 0 Then
                                        CType(v_ctl, ComboBoxEx).SelectedValue = mv_arrObjFields(i).DefaultValue
                                    End If
                                    If CType(v_ctl, ComboBoxEx).Items.Count > 0 Then
                                        If CType(v_ctl, ComboBoxEx).SelectedIndex = -1 Then
                                            CType(v_ctl, ComboBoxEx).SelectedIndex = 0
                                        End If
                                    End If
                                    mv_blnIsLoading = False

                                End If
                            End If
                        End If

                        'Trường description
                        If mv_arrObjFields(i).DefDesc.Length > 0 Then
                            v_ctl.Text = FillDefinitionDescription(i)
                        End If
                    End If
                Next

                'Xu ly dac biet neu OBJNAME=EXTREFVAL: Thong tin external reference cua doi tuong
                'Gia tri cua thong tin LOOKUP se quyet dinh cach thuc nhap lieu NVAL & CVAL
                If String.Compare(Me.ObjectName, "SA.EXTREFVAL") = 0 And String.Compare(v_strFLDNAME, "DEFNAME") = 0 _
                    And vintCVALIndex <> -1 And vintNVALIndex <> -1 Then
                    'Lay cac thuoc tinh cua DEFNAME
                    For i = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intNodeIndex).ChildNodes(i)
                            Select Case CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Case "DEFVAL"
                                    v_strREF_DEFVAL = .InnerText.ToString.Trim
                                Case "MANDARTORY"
                                    v_strREF_MANDARTORY = .InnerText.ToString.Trim
                                Case "DATATYPE"
                                    v_strREF_DATATYPE = .InnerText.ToString.Trim
                                Case "FLDMASK"
                                    v_strREF_FLDMASK = .InnerText.ToString.Trim
                                Case "FLDFORMAT"
                                    v_strREF_FLDFORMAT = .InnerText.ToString.Trim
                                Case "FLDLEN"
                                    v_strREF_FLDLEN = .InnerText.ToString.Trim
                                Case "CTLTYPE"
                                    v_strREF_CTLTYPE = .InnerText.ToString.Trim
                                Case "LOOKUP"
                                    v_strREF_LOOKUP = .InnerText.ToString.Trim
                                Case "SEARCHCODE"
                                    v_strREF_SEARCHCODE = .InnerText.ToString.Trim
                                Case "LOOKUPNAME"
                                    v_strREF_LOOKUPNAME = .InnerText.ToString.Trim
                            End Select
                        End With
                    Next
                    'Xu ly truong thong tin CVAL va NVAL
                    If String.Compare(v_strREF_DATATYPE, "N") = 0 Then
                        'Enable NVAL
                        v_tabIndex = mv_arrObjFields(vintNVALIndex).TabIndex
                        v_panelIndex = mv_arrObjFields(vintNVALIndex).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(vintNVALIndex).ControlIndex) 'Get control via Panel.ControlIndex
                        v_ctl.Enabled = True
                        If IsNumeric(v_strREF_DEFVAL) Then
                            v_ctl.Text = v_strREF_DEFVAL
                        Else
                            v_ctl.Text = "0"
                        End If

                        'Disable CVAL
                        mv_arrObjFields(vintCVALIndex).LookUp = "N"
                        mv_arrObjFields(vintCVALIndex).LookupList = String.Empty
                        v_tabIndex = mv_arrObjFields(vintCVALIndex).TabIndex
                        v_panelIndex = mv_arrObjFields(vintCVALIndex).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(vintCVALIndex).ControlIndex) 'Get control via Panel.ControlIndex
                        v_ctl.Enabled = False
                        v_ctl.Text = String.Empty
                        v_ctl.BackColor = System.Drawing.Color.White
                    Else
                        'Disable NVAL
                        v_tabIndex = mv_arrObjFields(vintNVALIndex).TabIndex
                        v_panelIndex = mv_arrObjFields(vintNVALIndex).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(vintNVALIndex).ControlIndex) 'Get control via Panel.ControlIndex
                        v_ctl.Enabled = False
                        v_ctl.Text = "0"

                        'Enable CVAL
                        v_tabIndex = mv_arrObjFields(vintCVALIndex).TabIndex
                        v_panelIndex = mv_arrObjFields(vintCVALIndex).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(vintCVALIndex).ControlIndex) 'Get control via Panel.ControlIndex
                        v_ctl.Enabled = True
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$BUSDATE>", Me.BusDate)
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$BRID>", Me.BranchId)
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$TLID>", Me.TellerId)
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$PARENTOBJ>", Me.ParentObject)
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$PARENTID>", Me.ParentValue)
                        v_strREF_DEFVAL = v_strREF_DEFVAL.Replace("<$KEYVALUE>", Me.KeyFieldValue)
                        v_ctl.Text = v_strREF_DEFVAL
                        If String.Compare(v_strREF_LOOKUP, "Y") = 0 And v_strREF_SEARCHCODE.Trim.Length > 0 And v_strREF_LOOKUPNAME.Trim.Length > 0 Then
                            v_strCMDLOOKUP = "SELECT CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE CDTYPE ='" & v_strREF_SEARCHCODE & "' AND CDNAME='" & v_strREF_LOOKUPNAME & "' ORDER BY LSTODR"
                            mv_arrObjFields(vintCVALIndex).LookUp = "Y"
                            mv_arrObjFields(vintCVALIndex).LookupList = v_strCMDLOOKUP
                            v_ctl.BackColor = System.Drawing.Color.Khaki
                        Else
                            mv_arrObjFields(vintCVALIndex).LookUp = "N"
                            mv_arrObjFields(vintCVALIndex).LookupList = String.Empty
                            v_ctl.BackColor = System.Drawing.Color.White
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Function VerifyRules() As Boolean
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".VerifyRules"
        'Dim v_intIndex As Integer

        Dim v_strFLDVALUE, v_strVALEXP, v_strVALEXP2 As String, v_ctl, v_panel As Control, v_tabIndex, v_panelIndex As Integer

        Try
            'Verify all mandatory and data type fields 
            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                If Not mv_arrObjFields(i) Is Nothing Then
                    v_ctl = GetControlByName(mv_arrObjFields(i).FieldName)
                    If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                        And (mv_arrObjFields(i).Mandatory) And (mv_arrObjFields(i).Enabled = True) Then 'Text or MaskedEdit
                        If v_ctl.Visible Or mv_arrObjFields(i).SubField <> "Y" Then
                            v_strFLDVALUE = v_ctl.Text.Trim
                            If Not (v_strFLDVALUE.Length > 0) And v_ctl.Enabled Then    'Chi validate cho control nao enabled
                                If Me.UserLanguage = "EN" Then
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Else
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                End If
                                v_ctl.Focus()
                                Return False
                            End If
                        End If

                    ElseIf (mv_arrObjFields(i).FieldType = "D") And (mv_arrObjFields(i).Mandatory) Then
                        If v_ctl.Visible Or mv_arrObjFields(i).SubField <> "Y" Then
                            v_strFLDVALUE = v_ctl.Text.Trim
                            If (Not (v_strFLDVALUE.Length > 0)) Or (v_strFLDVALUE.Trim() = gc_NULL_DATE) And v_ctl.Enabled Then
                                If Me.UserLanguage = "EN" Then
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Else
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                End If
                                v_ctl.Focus()
                                Return False
                            End If
                        End If
                    End If

                    If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                        And (mv_arrObjFields(i).DataType = "N") Then
                        If v_ctl.Visible Or mv_arrObjFields(i).SubField <> "Y" Then
                            v_strFLDVALUE = v_ctl.Text.Trim
                            If v_strFLDVALUE.Length > 0 Then
                                If Not IsNumeric(v_strFLDVALUE) Then
                                    If Me.UserLanguage = "EN" Then
                                        MsgBox(Replace(ResourceManager.GetString("ERR_NUMERIC_VALUE"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    Else
                                        MsgBox(Replace(ResourceManager.GetString("ERR_NUMERIC_VALUE"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    End If
                                    v_ctl.Focus()
                                    Return False
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            'Duyệt mảng dữ liệu danh mục các dieu kien kiểm tra
            If Not mv_arrObjFldVals Is Nothing Then
                Dim v_intCount As Integer = mv_arrObjFldVals.GetLength(0)
                Dim v_objEval As New Evaluator

                If v_intCount > 0 Then
                    For i As Integer = 0 To v_intCount - 1 Step 1
                        If Not mv_arrObjFldVals(i) Is Nothing Then
                            'Chỉ kiểm tra nếu trường subfield là visible
                            'Xử lý theo tham số đã cài đặt
                            With mv_arrObjFldVals(i)
                                v_ctl = GetControlByName(.FLDNAME)

                                ' kiem tra neu tagfield=tagvalue thi moi check

                                If (GetControlValueByName(.TAGFIELD) = .TAGVALUE.Trim("@") Or Trim(.TAGFIELD) = "") Then
                                    If v_ctl.Visible Then
                                        Select Case GetFieldDataType(.FLDNAME)
                                            Case "N"
                                                'Thực hiện xử lý cho từng phép toán
                                                If .VALTYPE = "E" Then
                                                    'Do nothing
                                                ElseIf .VALTYPE = "V" Then
                                                    'Lấy dữ liệu của truong can validate
                                                    v_strFLDVALUE = GetControlValueByName(.FLDNAME)
                                                    If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, bo qua
                                                        Select Case .[OPERATOR]
                                                            Case ">>"
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) > v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case ">="
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) >= v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "<<"
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) < v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "<="
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) <= v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "=="
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) = v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "<>"
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not (CDbl(v_strFLDVALUE) <> v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                                'T10/2015 TTBT T+2. Begin
                                                                '22/10/2015 DieuNDA: Them fldval FV check validate theo ket qua function tra ve
                                                                'Neu function tra ve 'False' thi bao loi, neu tra ve 'True' thi pass
                                                            Case "FV"
                                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                                v_strVALEXP2 = String.Empty
                                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                                                Dim v_check As String = "False"
                                                                If (v_strVALEXP2 = String.Empty) Then
                                                                    Exit Select
                                                                End If
                                                                v_check = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                                If Not (v_check.ToUpper = "TRUE") Then
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If
                                                                End If
                                                                'End 22/10/2015 DieuNDA
                                                                'T10/2015 TTBT T+2. Begin

                                                        End Select
                                                    End If
                                                End If
                                            Case "D"
                                                'Thuc hiện xử lý cho từng phép toán
                                                If .VALTYPE = "E" Then
                                                    'Do nothing
                                                ElseIf .VALTYPE = "V" Then
                                                    'Lấy dữ liệu của truong can validate
                                                    v_strFLDVALUE = GetControlValueByName(.FLDNAME)
                                                    If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, bo qua
                                                        Select Case .[OPERATOR]
                                                            Case ">>"
                                                                If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) > BuildDATEEXP(.VALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case ">="
                                                                If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) >= BuildDATEEXP(.VALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "<<"
                                                                If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) < BuildDATEEXP(.VALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "<="
                                                                If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) <= BuildDATEEXP(.VALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
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
                                                                    v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE CLDRTYPE='000' and SBDATE = TO_DATE('" & DDMMYYYY_SystemDate(v_strFLDVALUE) & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                                                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strSQL)
                                                                    v_ws.Message(v_strObjMsg)
                                                                    v_xmlDocument1.LoadXml(v_strObjMsg)
                                                                    v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                                                                    If v_nodeList1.Count >= 1 Then
                                                                        If CInt(v_nodeList1.Item(0).ChildNodes(0).InnerText.ToString()) > 0 Then
                                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                                SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                                Return False
                                                                            End If
                                                                        End If

                                                                    End If

                                                                Else
                                                                    If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) = BuildDATEEXP(.VALEXP)) Then
                                                                        'If Me.UserLanguage = "EN" Then
                                                                        '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                        'Else
                                                                        '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                        'End If
                                                                        'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        'Return False
                                                                        If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                            SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                            Return False
                                                                        End If

                                                                    End If
                                                                End If

                                                            Case "<>"
                                                                If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) <> BuildDATEEXP(.VALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                                'T10/2015 TTBT T+2. Begin
                                                                '22/10/2015 DieuNDA: Them fldval FV check validate theo ket qua function tra ve
                                                                'Neu function tra ve 'False' thi bao loi, neu tra ve 'True' thi pass
                                                            Case "FV"
                                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                                v_strVALEXP2 = String.Empty
                                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                                                Dim v_check As String = "False"
                                                                If (v_strVALEXP2 = String.Empty) Then
                                                                    Exit Select
                                                                End If
                                                                v_check = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                                If Not (v_check.ToUpper = "TRUE") Then
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If
                                                                End If
                                                                'End 22/10/2015 DieuNDA
                                                                'T10/2015 TTBT T+2. Begin

                                                        End Select
                                                    End If
                                                End If
                                            Case "C"

                                                'PhuongHT add to check input format
                                                If .VALTYPE = "F" Then
                                                    'Lấy dữ liệu của truong can validate
                                                    v_strFLDVALUE = GetControlValueByName(.FLDNAME)
                                                    If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, bo qua
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        Dim v_regexFormat As New Regex(v_strVALEXP)
                                                        Select Case .[OPERATOR]
                                                            Case "IN"
                                                                If Not (v_regexFormat.IsMatch(v_strFLDVALUE)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "NI"
                                                                If (v_regexFormat.IsMatch(v_strFLDVALUE)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If

                                                        End Select
                                                    End If
                                                ElseIf .VALTYPE = "V" Then
                                                    v_strFLDVALUE = GetControlValueByName(.FLDNAME)
                                                    If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, bo qua

                                                        Select Case .[OPERATOR]
                                                            Case "<>"
                                                                v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                                If Not ((v_strFLDVALUE) <> v_objEval.Eval(v_strVALEXP)) Then
                                                                    'If Me.UserLanguage = "EN" Then
                                                                    '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'Else
                                                                    '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                                    'End If
                                                                    'SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                    'Return False
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If

                                                                End If
                                                            Case "FX"   'Goi ham oracle
                                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                                v_strVALEXP2 = String.Empty
                                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                                                If (v_strVALEXP2 = String.Empty) Then
                                                                    Exit Select
                                                                End If
                                                                If TypeOf (v_ctl) Is ComboBoxEx Then
                                                                    CType(v_ctl, ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                                Else
                                                                    v_ctl.Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                                    If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                                        FormatNumericTextbox(CType(v_ctl, TextBox))
                                                                    End If
                                                                End If
                                                                'T10/2015 TTBT T+2. Begin
                                                                '22/10/2015 DieuNDA: Them fldval FV check validate theo ket qua function tra ve
                                                                'Neu function tra ve 'False' thi bao loi, neu tra ve 'True' thi pass
                                                            Case "FV"
                                                                '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                                v_strVALEXP = .VALEXP   'Ten oracle function name
                                                                v_strVALEXP2 = String.Empty
                                                                v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                                                Dim v_check As String = "False"
                                                                If (v_strVALEXP2 = String.Empty) Then
                                                                    Exit Select
                                                                End If
                                                                v_check = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                                If Not (v_check.ToUpper = "TRUE") Then
                                                                    If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                        SetControlFocusByName(mv_arrObjFldVals(i).FLDNAME)
                                                                        Return False
                                                                    End If
                                                                End If
                                                                'End 22/10/2015 DieuNDA
                                                                'T10/2015 TTBT T+2. Begin

                                                        End Select
                                                    End If
                                                End If
                                                'end of PhuongHT add
                                        End Select
                                    End If
                                End If

                            End With
                        End If
                    Next
                End If
            End If

            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function ExecFldval()
        Dim v_intCount, v_intIndex, i As Integer
        Dim v_strFLDNAME, v_strFLDDEFNAME, v_strDATATYPE, v_strFLDVALUE, v_strTXBUSDATE As String
        Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String
        Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
        Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
        Dim v_ctrl As Control, v_panel As Panel
        Dim v_tabIndex, v_panelIndex As Integer
        Dim v_strTagValue As String

        'Duyet mang du lieu danh muc cac dieu kien kiem tra
        v_intCount = mv_arrObjFldVals.GetLength(0)
        If v_intCount > 0 Then
            For i = 0 To v_intCount - 1 Step 1
                If Not mv_arrObjFldVals(i) Is Nothing Then
                    With mv_arrObjFldVals(i)
                        'Xac dinh control index
                        v_intIndex = .IDXFLD
                        ' tinh gia tri tagvalue
                        If (.TAGVALUE.StartsWith("@")) Then
                            v_strTagValue = .TAGVALUE.Trim("@")
                        Else
                            v_strTagValue = BuildAMTEXP(.TAGVALUE)
                        End If
                        ' neu tagfield= tagvalue thi moi check
                        If (String.Compare(BuildAMTEXP(.TAGFIELD), v_strTagValue) = 0 Or Trim(.TAGFIELD) = "") Then
                            'Thuc hien xu ly cho tung phep toan
                            If .VALTYPE = "E" Then
                                v_tabIndex = mv_arrObjFields(v_intIndex).TabIndex
                                v_panelIndex = mv_arrObjFields(v_intIndex).GroupIndex
                                v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                v_ctrl = v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                                If mv_arrObjFields(.IDXFLD).DataType <> "D" Then
                                    Select Case .[OPERATOR]
                                        Case "EX"
                                            v_strVALEXP = BuildAMTEXP(.VALEXP)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                v_ctrl.Text = FRound(v_objEval.Eval(v_strVALEXP), 0)
                                                FormatNumericTextbox(CType(v_ctrl, TextBox))
                                            Else
                                                v_ctrl.Text = v_objEval.Eval(v_strVALEXP)
                                            End If
                                        Case "MA"
                                            v_strVALEXP = BuildAMTEXP(.VALEXP)
                                            v_strVALEXP2 = BuildAMTEXP(.VALEXP2)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                v_ctrl.Text = FRound(GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)), 0)
                                                FormatNumericTextbox(CType(v_ctrl, TextBox))
                                            Else
                                                v_ctrl.Text = GetMax(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            End If
                                        Case "MI"
                                            v_strVALEXP = BuildAMTEXP(.VALEXP)
                                            v_strVALEXP2 = BuildAMTEXP(.VALEXP2)
                                            If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                v_ctrl.Text = FRound(GetMin(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)), 0)
                                                FormatNumericTextbox(CType(v_ctrl, TextBox))
                                            Else
                                                v_ctrl.Text = GetMin(v_objEval.Eval(v_strVALEXP), v_objEval.Eval(v_strVALEXP2)).ToString
                                            End If
                                        Case "FX"   'Goi ham oracle
                                            '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                            v_strVALEXP = .VALEXP   'Ten oracle function name
                                            v_strVALEXP2 = String.Empty
                                            v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                            If (v_strVALEXP2 = String.Empty) Then
                                                Exit Select
                                            End If
                                            If TypeOf (v_ctrl) Is ComboBoxEx Then
                                                CType(v_ctrl, ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                            Else
                                                v_ctrl.Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    FormatNumericTextbox(CType(v_ctrl, TextBox))
                                                End If
                                            End If
                                            'Case "IF"
                                            '    'Neu Valexp ma TRUE thi moi thuc hien VALEXP2
                                            '    v_strVALEXP = BuildAMTEXP(.VALEXP)
                                            '    v_strVALEXP2 = BuildAMTEXP(.VALEXP2)
                                            '    If v_objEval.Eval(v_strVALEXP) Then
                                            '        v_ctrl.Text = FRound(v_objEval.Eval(v_strVALEXP2), 0)
                                            '        FormatNumericTextbox(CType(v_ctrl, TextBox))
                                            '    End If
                                    End Select
                                ElseIf mv_arrObjFields(.IDXFLD).DataType = "D" Then
                                    Select Case .[OPERATOR]
                                        Case "FX"   'Goi ham oracle
                                            '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                            v_strVALEXP = .VALEXP   'Ten oracle function name
                                            v_strVALEXP2 = String.Empty
                                            v_strVALEXP2 = BuildFUNCPARA(.VALEXP2, v_panel) 'noi dung tham so
                                            If (v_strVALEXP2 = String.Empty) Then
                                                Exit Select
                                            End If
                                            If TypeOf (v_ctrl) Is ComboBoxEx Then
                                                CType(v_ctrl, ComboBoxEx).SelectedValue = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                            Else
                                                v_ctrl.Text = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                If mv_arrObjFields(.IDXFLD).DataType = "N" Then
                                                    FormatNumericTextbox(CType(v_ctrl, TextBox))
                                                End If
                                            End If
                                    End Select
                                End If

                            End If
                        End If
                    End With
                End If
            Next
        End If
    End Function
    Private Function BuildFUNCPARA(ByVal strAMTEXP As String, ByVal v_panel As Panel) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex, v_lngControlIndex As Long, v_ctl As Control
            Dim v_intIndex As Integer
            v_strEvaluator = vbNullString
            v_lngIndex = 1
            Dim v_index_spilit As Long
            v_index_spilit = 0


            While strAMTEXP.Length > 0
                'lay ra tung element phan cach nhau boi dau ##
                v_index_spilit = strAMTEXP.IndexOf("#")
                If (v_index_spilit > 1) Then
                    v_strElemenent = strAMTEXP.Substring(0, v_index_spilit)
                    strAMTEXP = strAMTEXP.Substring(v_index_spilit + 2)
                Else
                    v_strElemenent = strAMTEXP
                    strAMTEXP = ""
                End If


                Select Case v_strElemenent
                    Case "##"
                        'Dau phan cach: giu nguyen
                        v_strEvaluator = v_strEvaluator & ","
                    Case "BD"   'Busdate
                        For Each v_ctl In v_panel.Controls
                            If v_ctl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                                v_strEvaluator = v_strEvaluator & "TO_DATE('" & v_ctl.Text & "','" & gc_FORMAT_DATE & "')"
                                Exit For
                            End If
                        Next
                    Case "TD"   'transaction date
                        v_strEvaluator = v_strEvaluator & "TO_DATE('" & Me.mv_strBusDate & "','" & gc_FORMAT_DATE & "')"
                    Case "BR" 'BranchID'
                        v_strEvaluator = v_strEvaluator & "'" & Me.BranchId & "'"
                    Case Else
                        'Operator
                        'For Each v_ctl In v_panel.Controls
                        '    If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 Then
                        '        If TypeOf (v_ctl) Is ComboBoxEx Then
                        '            If CType(v_ctl, ComboBoxEx).SelectedValue Is Nothing Then
                        '                v_strValue = ""
                        '            Else
                        '                Dim v_strText As String = CType(v_ctl, ComboBoxEx).Text
                        '                If CType(v_ctl, ComboBoxEx).SelectedValue = "" Then
                        '                    CType(v_ctl, ComboBoxEx).SelectedIndex = CType(v_ctl, ComboBoxEx).FindStringExact(v_strText, -1)
                        '                End If
                        '                v_strValue = CType(v_ctl, ComboBoxEx).SelectedValue
                        '            End If
                        '        Else
                        '            v_strValue = v_ctl.Text
                        '        End If
                        '        xu ly neu la ky tu
                        '        v_lngControlIndex = CType(v_ctl, Control).Tag
                        '        If Not mv_arrObjFields(v_lngControlIndex) Is Nothing Then
                        '            If mv_arrObjFields(v_lngControlIndex).DataType = "C" Then
                        '                v_strValue = "'" & v_strValue.Replace("'", "''") & "'"
                        '            ElseIf mv_arrObjFields(v_lngControlIndex).DataType = "N" Then
                        '                v_strValue = CDbl(v_strValue).ToString
                        '            End If
                        '        End If
                        '        Exit For
                        '    End If
                        'Next

                        If (v_strElemenent.StartsWith("@")) Then
                            v_strValue = v_strElemenent.Trim("@")
                        Else
                            v_strValue = GetControlValueByName(v_strElemenent)
                        End If
                        'If (v_strValue = Nothing) Then
                        '    Exit Function

                        'End If
                        v_strValue = "'" & v_strValue.Replace("'", "''") & "'"
                        v_strEvaluator = v_strEvaluator & v_strValue
                End Select
                If v_index_spilit > 1 Then
                    v_strEvaluator = v_strEvaluator & ","
                End If

            End While

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function
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


    Private Function GetFieldDataType(ByVal pv_strFLDNAME As String) As String
        Try
            Dim v_strDataType As String = String.Empty

            For i As Integer = 0 To mv_arrObjFields.Length - 1
                If (mv_arrObjFields(i).FieldName = pv_strFLDNAME) Then
                    v_strDataType = mv_arrObjFields(i).DataType
                    Exit For
                End If
            Next
            Return v_strDataType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BuildDATEEXP(ByVal strDATEEXP As String) As Date
        Dim v_dtmRetVal As Date
        Dim v_strDateEXP As String
        Try
            If Mid(strDATEEXP, 1, 1) = "@" Then
                v_strDateEXP = Mid(strDATEEXP, 2)
                v_strDateEXP = Replace(v_strDateEXP, "<$BUSDATE>", Me.BusDate)
                v_dtmRetVal = DDMMYYYY_SystemDate(v_strDateEXP)
            Else
                v_dtmRetVal = DDMMYYYY_SystemDate(GetControlValueByName(strDATEEXP))
            End If

            Return v_dtmRetVal
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function BuildAMTEXP(ByVal strAMTEXP As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".BuildAMTEXP"
        Dim v_strEvaluator, v_strElemenent, v_strValue, v_arrTemp() As String
        Try
            v_strEvaluator = vbNullString
            'If Mid(strAMTEXP, 1, 1) = "@" Then
            '    v_strEvaluator = Mid(strAMTEXP, 2)
            'Else
            v_arrTemp = strAMTEXP.Split("|")

            For i As Integer = 0 To v_arrTemp.Length - 1
                v_strElemenent = v_arrTemp(i)

                If Mid(v_strElemenent, 1, 1) = "@" Then
                    v_strEvaluator &= Mid(v_strElemenent, 2)
                Else
                    Select Case v_strElemenent
                        Case "++", "--", "**", "//", "((", "))"
                            'Operand
                            v_strEvaluator &= Mid(v_strElemenent, 1, 1)
                        Case Else
                            'Operator
                            v_strValue = GetControlValueByName(v_strElemenent)

                            'If IsNumeric(v_strValue) Then
                            '    v_strValue = CDbl(v_strValue).ToString("#0.##0")
                            'End If
                            v_strEvaluator &= v_strValue
                    End Select
                End If

            Next
            'End If
            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & strAMTEXP & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub SetControlFocusByName(ByVal pv_strFLDNAME As String)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".SetControlFocusByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    'Scan all field in array
                    v_ctrl = GetControlByName(mv_arrObjFields(i).FieldName)
                    'Set control focus
                    Me.tabMaster.TabPages(v_tabIndex).Focus()
                    v_ctrl.Focus()
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub

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
                    If v_strFormat.IndexOf("#,##") > -1 Then
                        pv_ctrl.Text = Format(Math.Floor(CDbl(pv_ctrl.Text)), v_strFormat.Trim)
                    Else
                        pv_ctrl.Text = FormatNumber(Math.Floor(CDbl(pv_ctrl.Text)), v_intDecimal)
                    End If
                Else
                    If v_strFormat.IndexOf("#,##") > -1 Then
                        pv_ctrl.Text = Format(Math.Floor(CDbl(pv_ctrl.Text) * Math.Pow(10, v_intDecimal)) / Math.Pow(10, v_intDecimal), v_strFormat.Trim)
                    Else
                        pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetStringFromImage(ByVal pv_PicBox As PictureBox) As String
        Dim v_mStream As New MemoryStream
        Dim v_Compressed As Byte()
        Dim v_Encoded As Char()
        Dim v_arrMyImage As Byte()
        Dim v_strBuilder As String = String.Empty
        'CType((v_ctrl), PictureBox)()
        If pv_PicBox.Image Is Nothing Then
            Return ""
        Else
            pv_PicBox.Image.Save(v_mStream, pv_PicBox.Image.RawFormat)
            v_arrMyImage = v_mStream.GetBuffer
            v_mStream.Close()
            v_Compressed = CompressionHelper.CompressBytes(v_arrMyImage)
            Dim v_BE As New Base64Encoder(v_Compressed)
            v_Encoded = v_BE.GetEncoded
            v_strBuilder &= v_Encoded
            Return v_strBuilder
        End If
    End Function

    Private Function GetImageFromString(ByVal pv_strFLDVAL) As System.Drawing.Bitmap
        If pv_strFLDVAL = "" Then
            Return Nothing
        Else
            Dim v_strCompress As String = Trim(pv_strFLDVAL)
            Dim v_Compression As Byte()
            Dim v_Base64Decoder As New Base64Decoder(v_strCompress)
            v_Compression = v_Base64Decoder.GetDecoded()
            Dim v_arrActualSignImage As Byte()
            v_arrActualSignImage = CompressionHelper.DecompressBytes(v_Compression)
            Dim tmpImage As System.Drawing.Bitmap = New System.Drawing.Bitmap(New MemoryStream(v_arrActualSignImage))
            Return tmpImage
        End If
    End Function

    Private Function GetControlByCtlName(ByVal pv_strCTLNAME As String, ByVal pv_ctrl As Control) As Control
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetControlValueByName"
        Dim v_strReturnValue As Control
        Try
            pv_strCTLNAME = UCase(pv_strCTLNAME)
            For Each v_ctrl As Control In pv_ctrl.Controls
                If (TypeOf (v_ctrl) Is TabControl) Then
                    For Each v_ctrTabPage As Control In v_ctrl.Controls
                        If (TypeOf (v_ctrTabPage) Is TabPage) Then
                            v_strReturnValue = GetControlByCtlName(pv_strCTLNAME, v_ctrTabPage)
                            If (Not v_strReturnValue Is Nothing) Then
                                Exit For
                            End If
                        End If
                    Next
                ElseIf (TypeOf (v_ctrl) Is Panel) Then
                    For Each v_ctrPanel As Control In v_ctrl.Controls
                        If (TypeOf (v_ctrPanel) Is Panel) Then
                            v_strReturnValue = GetControlByCtlName(pv_strCTLNAME, v_ctrPanel)
                            If (Not v_strReturnValue Is Nothing) Then
                                Exit For
                            End If
                        End If
                    Next
                ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                    v_strReturnValue = GetControlByCtlName(pv_strCTLNAME, v_ctrl)
                    If (Not v_strReturnValue Is Nothing) Then
                        Exit For
                    End If
                ElseIf (TypeOf (v_ctrl) Is GridEx) Then
                    If (UCase(v_ctrl.Name) = pv_strCTLNAME) Then
                        v_strReturnValue = CType(v_ctrl, TextBox)
                    End If
                ElseIf (TypeOf (v_ctrl) Is TextBox) Then
                    If (UCase(v_ctrl.Name) = pv_strCTLNAME) Then
                        v_strReturnValue = CType(v_ctrl, TextBox)
                    End If
                ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                    If (UCase(v_ctrl.Name) = pv_strCTLNAME) Then
                        v_strReturnValue = CType(v_ctrl, FlexMaskEditBox)
                    End If
                ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then
                    If (UCase(v_ctrl.Name) = pv_strCTLNAME) Then
                        v_strReturnValue = CType(v_ctrl, DateTimePicker)
                    End If
                ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                    If (UCase(v_ctrl.Name) = pv_strCTLNAME) Then
                        v_strReturnValue = CType(v_ctrl, ComboBoxEx)
                    End If
                End If
                If (Not v_strReturnValue Is Nothing) Then
                    Exit For
                End If
            Next
            Return v_strReturnValue
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return Nothing
        End Try
    End Function

    Private Function GetControlByName(ByVal pv_strFLDNAME As String) As Control
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetControlValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    'Scan all field in array
                    v_tabIndex = mv_arrObjFields(i).TabIndex
                    v_panelIndex = mv_arrObjFields(i).GroupIndex
                    v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                    v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                    Return v_ctrl
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Private Sub DisplayButton()
        Dim v_btn() As Button
        Dim i As Integer
        Dim v_intLeft As Integer
        ReDim v_btn(5)
        v_btn(0) = btnCancel
        v_btn(1) = btnOK
        v_btn(2) = btnApply
        v_btn(3) = btnApprove
        v_btn(4) = btnReject
        v_btn(5) = btnExternal

        'v_intLeft = BTN_ROOT_LEFT
        v_intLeft = tabMaster.Left + tabMaster.Width - BTN_WIDTH
        For i = 0 To 5
            If v_btn(i).Visible = True Then
                v_btn(i).Left = v_intLeft
                v_intLeft = v_intLeft - BTN_WIDTH
            End If
        Next
    End Sub

    Private Function GetControlByIndex(ByVal pv_intIDX As Integer) As Control
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetControlValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_count = UBound(mv_arrObjFields)
            If pv_intIDX >= v_count Then Return Nothing
            i = pv_intIDX
            If Not mv_arrObjFields(i) Is Nothing Then
                v_tabIndex = mv_arrObjFields(i).TabIndex
                v_panelIndex = mv_arrObjFields(i).GroupIndex
                v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                Return v_ctrl
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Private Function GetControlValueByName(ByVal pv_strFLDNAME As String, Optional ByVal pv_strValOrText As String = "V") As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetControlValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            pv_strFLDNAME = pv_strFLDNAME.Replace(PREFIXED_REFMASTER, String.Empty)
            If (pv_strFLDNAME.Trim = "") Then
                Return ""
            End If
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    'Scan all field in array
                    v_tabIndex = mv_arrObjFields(i).TabIndex
                    v_panelIndex = mv_arrObjFields(i).GroupIndex
                    v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                    v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                    'Set data 2 control
                    Select Case mv_arrObjFields(i).ControlType
                        Case "T"
                            v_strFLDVALUE = CType(v_ctrl, TextBox).Text
                        Case "M"
                            v_strFLDVALUE = CType(v_ctrl, FlexMaskEditBox).Text
                        Case "C"
                            If pv_strValOrText = "V" Then
                                v_strFLDVALUE = CType(v_ctrl, ComboBox).SelectedValue
                            Else
                                v_strFLDVALUE = CType(v_ctrl, ComboBox).Text
                            End If
                    End Select
                    If mv_arrObjFields(i).DataType = "N" And InStr(mv_arrObjFields(i).FieldFormat, ",") Then
                        v_strFLDVALUE = Strings.Replace(v_strFLDVALUE, ",", "")
                    End If
                    If mv_arrObjFields(i).DataType = "D" And v_strFLDVALUE = "  /  /" Then
                        v_strFLDVALUE = ""
                    End If
                    If v_strFLDVALUE Is Nothing Then
                        v_strFLDVALUE = ""
                    End If
                    Return v_strFLDVALUE
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Private Function GetRefFieldValueByName(ByVal pv_strREFFLDNAME As String, Optional ByVal pv_strValOrText As String = "V") As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetFieldValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_strFLDNAME = pv_strREFFLDNAME.Substring(Len(PREFIXED_REFMASTER) + 1, pv_strREFFLDNAME.Length - Len(PREFIXED_REFMASTER) - 2)
            v_strFLDVALUE = String.Empty
            If Not mv_arrRefObjFields Is Nothing Then
                v_count = UBound(mv_arrRefObjFields)
                For i = 0 To v_count - 1
                    If String.Compare(mv_arrRefObjFields(i).FieldName, v_strFLDNAME) = 0 Then
                        v_strFLDVALUE = mv_arrRefObjFields(i).FieldValue
                        Return v_strFLDVALUE
                    End If
                Next
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Private Function GetFieldValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetFieldValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    v_strFLDVALUE = mv_arrObjFields(i).FieldValue
                    Return v_strFLDVALUE
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Private Sub GetFieldSearchCodeDescByIndex(ByVal v_intIndex As Integer)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetFieldSearchCodeDescByIndex"
        Dim ctlCheck As Windows.Forms.Control, v_panel As Panel, i, j, v_intNodeIndex As Integer
        Dim v_strObjMsg, v_strSQLCMD, v_strValue, v_strFieldValue, strFLDNAME As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Lay SEARCHCODE va FIELDVALUE
            v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
            v_strFieldValue = mv_arrObjFields(v_intIndex).FieldValue
            v_strKeyVal = Replace(v_strFieldValue, ".", "")
            v_strRefValue = String.Empty
            If Not (v_strKeyVal Is Nothing) Then
                If v_strKeyVal.Trim.Length > 0 Then
                    'Fill Refval
                    v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i = 0 To v_nodeList.Count - 1
                            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strValue = Trim(.InnerText)
                                    Select Case v_strFLDNAME
                                        Case "KEYNAME"
                                            v_strKeyName = Trim(v_strValue)
                                        Case "FIELDCODE"
                                            v_strFIELDCODE = Trim(v_strValue)
                                        Case "SEARCHCMDSQL"
                                            v_strSEARCHSQL = Trim(v_strValue)
                                    End Select
                                End With
                            Next
                        Next
                        v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)

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
                            For i = 0 To v_nodeList.Count - 1
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
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
                        End If
                    End If
                End If
            End If
            mv_arrObjFields(v_intIndex).TagLookUpDesc = v_strRefValue
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub GetFieldLookUpDescByIndex(ByVal v_intIndex As Integer)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetFieldLookUpDescByName"
        Dim ctlCheck As Windows.Forms.Control, v_panel As Panel
        Dim v_strObjMsg, v_strSQLCMD, v_strValue, v_strDisplay, v_strFULLDATA, v_strFieldValue As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            Dim v_strFILTERID As String
            'Get filterid from related field (TAGFIELD)
            If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                v_strFILTERID = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField)
            Else
                v_strFILTERID = String.Empty
            End If
            'Get the field value
            If mv_arrObjFields(v_intIndex).FieldValue.Trim.Length > 0 Then
                v_strFieldValue = mv_arrObjFields(v_intIndex).FieldValue.Trim
            ElseIf mv_arrObjFields(v_intIndex).DefaultValue.Trim.Length > 0 Then
                v_strFieldValue = mv_arrObjFields(v_intIndex).DefaultValue.Trim
            Else
                v_strFieldValue = String.Empty
            End If

            mv_arrObjFields(v_intIndex).TagLookUpDesc = String.Empty
            If v_strFieldValue.Length > 0 Then
                v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                Else
                    v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                End If
                'NamTv End.
                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                v_strSQLCMD = v_strSQLCMD.Replace("<$TAGFIELD>", v_strFILTERID)
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
                                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" _
                                                And Me.UserLanguage = "VN" Then
                                                mv_arrObjFields(v_intIndex).TagLookUpDesc = Trim(.InnerText.ToString)
                                                Exit Sub
                                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "EN_DISPLAY" _
                                                And Me.UserLanguage = "EN" Then
                                                mv_arrObjFields(v_intIndex).TagLookUpDesc = Trim(.InnerText.ToString)
                                                Exit Sub
                                            End If
                                        End With
                                    Next
                                End If
                            End If
                        End With
                    Next
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadObjectFieldValidateRules()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".LoadObjectFieldValidateRules"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery, 
        Dim v_strSQL As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strClause, v_strObjMsg, v_strValue, v_strFLDNAME As String, v_intIndex As Integer
        Dim v_objFieldVal As CFieldVal, v_nodeList As Xml.XmlNodeList
        Try
            'Lấy các luật kiểm tra của các truong giao dic
            'v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG,TAGFIELD,TAGVALUE FROM FLDVAL " & _
            '    "WHERE upper(OBJNAME) = '" & ObjectName & "' ORDER BY VALTYPE, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            'v_ws.Message(v_strObjMsg)
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG, TAGFIELD,TAGVALUE,CHKLEV FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & ObjectName & "' ORDER BY VALTYPE, ODRNUM" 'Thứ tự order by là quan tr?ng kh ông sửa
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)


            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)

            'Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
            '    v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg, _
            '    v_strFieldVal_TagField, v_strFieldVal_TagValue As String
            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg, _
                v_strFieldVal_TagField, v_strFieldVal_TagValue, v_strFieldVal_ChkLev As String

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng truong cua form
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

                'Xác định index của mảng FldMaster
                For j As Integer = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                            Exit For
                        End If
                    End If
                Next

                'Cau truc phan tu xu ly
                v_objFieldVal = New CFieldVal
                With v_objFieldVal
                    .OBJNAME = ObjectName
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .CHKLEV = v_strFieldVal_ChkLev
                    .TAGFIELD = v_strFieldVal_TagField
                    .TAGVALUE = v_strFieldVal_TagValue
                    .IDXFLD = v_intIndex
                End With
                mv_arrObjFldVals(i) = v_objFieldVal
            Next

            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message & ControlChars.CrLf & v_strSQL, EventLogEntryType.Error)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadScreen()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".LoadScreen"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery, 
        Dim v_strSQL As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strObjMsg, v_strObjMsgTmp, v_strClause, v_strMainTabSearchCode As String
            Dim v_strFieldName, v_strDefName, v_strPDefName, v_strPDefValue, v_strCaption, v_strEnCaption, v_strFldType, v_strFldMask, _
                v_strDefDesc, v_strDefParam, v_strFldFormat, v_strLList, _
                v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strLookupName, v_strSearchCode, _
                v_strGroupName, v_strTagField, v_strTagValue, v_strTagList, v_strTagUpdate, v_strTagListData, v_strTagLookUpDesc, _
                v_strSRMODCode, v_strCtlType, v_strInvName, v_strInvFormat, v_strSubField As String
            Dim v_strTabGrName, v_strTabGrCaption, v_strTabENGrCaption, v_strTabSearchCode, v_strTabGrType, v_strTabGrButtons, _
                v_strObjTitle, v_strObjEnTitle, v_strCareByChk, v_strObjButtons, v_strObjCareBy, v_strObjAutoID, v_strObjName, v_strObjNameTmp, v_strGrpObjName As String
            Dim v_intOdrNum, v_intFldLen, v_intFldWidth, v_intFldRow, v_count, i, j, k, v_PanelIndex, v_GridIndex As Integer, v_strIndicator As String
            Dim v_blnVisible, v_blnEnabled, v_blnMandatory, v_blnRiskField As Boolean

            '===============================================================================================================================
            'Setup tabs on the screen

            ' VinhLD add for auto resize
            Dim frm_width As Integer = Me.Width
            Dim frm_height As Integer = Me.Height

            'Get the Width and Height (resolution) of the screen  
            Dim src As System.Windows.Forms.Screen = System.Windows.Forms.Screen.PrimaryScreen
            Dim src_height As Integer = src.Bounds.Height
            Dim src_width As Integer = src.Bounds.Width

            'Set the left and top property to move the form to center of the screen  
            Me.Left = (src_width - frm_width) / 2
            Me.Top = (src_height - frm_height) / 2
            mv_dblWindowSizeRatio_X = src_width / BASED_SCREEN_WIDTH
            mv_dblWindowSizeRatio_X = IIf(mv_dblWindowSizeRatio_X <= 1.5, mv_dblWindowSizeRatio_X, 1.5)
            mv_dblWindowSizeRatio_Y = src_height / BASED_SCREEN_HEIGHT

            If ObjectName = "MT.SHVTXREQ" Or ObjectName = "MT.SHVSWIFT" Or ObjectName = "MT.MT9000" Or ObjectName = "ST.VSDTXINFO" Or ObjectName = "ST.VSDTXINFOHIST" Or ObjectName = "MT.WCRBLOG" Then
                Me.tabMaster.Width = 500 * mv_dblWindowSizeRatio_X
                Me.tabMaster.Height = 350 * mv_dblWindowSizeRatio_Y
            Else
                Me.tabMaster.Width = BASED_PANEL_WIDTH * mv_dblWindowSizeRatio_X
                Me.tabMaster.Height = BASED_PANEL_HEIGHT * mv_dblWindowSizeRatio_Y
            End If


            Me.Height = Me.lblCaption.Height + tabMaster.Top + tabMaster.Height + btnOK.Height + CONTROL_TOP * 2 + 20
            Me.Width = Me.tabMaster.Width + 2 * Me.tabMaster.Left + 4
            ' end of VinhLD add for auto resize

            Me.tabMaster.TabPages.Clear()
            v_strSQL = "SELECT GR.ODRNUM, GR.GRNAME, GR.OBJNAME, GR.GRTYPE, GR.GRCAPTION, GR.EN_GRCAPTION, GR.SEARCHCODE, GR.CAREBYCHK, " & ControlChars.CrLf _
                & "GR.GRBUTTONS, OBJ.OBJTITLE, OBJ.EN_OBJTITLE, OBJ.OBJBUTTONS, OBJ.CAREBYCHK OBJCAREBYCHK, OBJ.USEAUTOID OBJAUTOIDCHK " & ControlChars.CrLf _
                & "FROM GRMASTER GR, OBJMASTER OBJ WHERE OBJ.MODCODE=GR.MODCODE AND OBJ.OBJNAME=GR.OBJNAME " & ControlChars.CrLf _
                & "AND upper(OBJ.MODCODE) = '" & ModuleCode & "' AND upper(OBJ.OBJNAME) = '" & ObjectName & "' ORDER BY GR.ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjGroups(v_nodeList.Count)
            For i = 0 To v_nodeList.Count - 1
                'Get tab information
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "OBJCAREBYCHK"
                                v_strObjCareBy = Trim(v_strValue)
                            Case "OBJAUTOIDCHK"
                                v_strObjAutoID = Trim(v_strValue)
                            Case "OBJNAME"
                                v_strObjName = Trim(v_strValue)
                            Case "CAREBYCHK"
                                v_strCareByChk = Trim(v_strValue)
                            Case "OBJTITLE"
                                v_strObjTitle = Trim(v_strValue)
                            Case "EN_OBJTITLE"
                                v_strObjEnTitle = Trim(v_strValue)
                            Case "OBJBUTTONS"
                                v_strObjButtons = Trim(v_strValue)
                            Case "GRNAME"
                                v_strTabGrName = Trim(v_strValue)
                            Case "GRTYPE"
                                v_strTabGrType = Trim(v_strValue)
                            Case "GRCAPTION"
                                v_strTabGrCaption = Trim(v_strValue)
                            Case "EN_GRCAPTION"
                                v_strTabENGrCaption = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strTabSearchCode = Trim(v_strValue)
                            Case "GRBUTTONS"
                                v_strTabGrButtons = Trim(v_strValue)
                        End Select
                    End With
                Next

                'Create tabpage
                Dim v_tabGrMaster As New TabPage
                v_tabGrMaster.Name = v_strTabGrName
                If Me.UserLanguage = "VN" Then
                    v_tabGrMaster.Text = v_strTabGrCaption
                Else
                    v_tabGrMaster.Text = v_strTabENGrCaption
                End If
                v_tabGrMaster.Visible = True
                v_tabGrMaster.Tag = v_strTabGrType & "[" & v_strTabSearchCode & "]"
                'Normal panel to display information
                v_count = 0
                Dim v_tabGrPanel As New Panel
                v_tabGrPanel.Name = "pn" & v_strTabGrName
                v_tabGrPanel.Top = tabpage_Button_POS_TOP + tabpage_Button_POS_GAP + tabpage_Button_POS_HEIGHT
                v_tabGrPanel.Width = tabMaster.Width - 100 'tabpage_Panel_WIDTH
                v_tabGrPanel.Height = tabMaster.Height - 65 'tabpage_Panel_HEIGHT
                v_tabGrPanel.Tag = 0 'Used to monitor dynamic control
                v_tabGrPanel.AutoScroll = True
                v_tabGrPanel.Visible = True

                If v_strTabGrType = "N" Then
                    v_strMainTabSearchCode = v_strTabSearchCode
                End If

                If Not v_strTabGrType = "N" Then
                    'Create sub button to control
                    Dim l As Integer = -1 'FDS DieuNDA
                    For k = 0 To v_strTabGrButtons.Length - 1 Step 1
                        v_strIndicator = v_strTabGrButtons.Substring(k, 1)
                        If Not v_strIndicator = "N" Then
                            'Visible
                            Dim v_tabSubButton As New Button
                            Select Case k + 1
                                Case tabpage_Button_REFRESH
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Reresh"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubRefresh")
                                Case tabpage_Button_VIEW
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_View"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubView")
                                Case tabpage_Button_INSERT
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Insert"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubInsert")
                                Case tabpage_Button_EDIT
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Edit"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubEdit")
                                Case tabpage_Button_DELETE
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Delete"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubDelete")
                                Case tabpage_Button_FIRST
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_First"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubFirst")
                                Case tabpage_Button_PREVIOUS
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Previous"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubPrevious")
                                Case tabpage_Button_NEXT
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Next"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubNext")
                                Case tabpage_Button_LAST
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Last"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubLast")
                                Case tabpage_Button_EXPORT 'TruongLD Add 24/08/2017 
                                    v_tabSubButton.Name = PREFIXED_BTNTABPAGE & "_" & v_strTabGrName & "_Export"
                                    v_tabSubButton.Text = mv_resourceManager.GetString("btnSubExport")
                            End Select
                            v_tabSubButton.Visible = True
                            v_tabSubButton.Enabled = IIf(v_strIndicator = "E", True, False)
                            v_tabSubButton.Top = tabpage_Button_POS_TOP
                            v_tabSubButton.Height = tabpage_Button_POS_HEIGHT
                            v_tabSubButton.Width = tabpage_Button_POS_WIDTH
                            'v_tabSubButton.Left = tabpage_Button_POS_LEFT + k * (tabpage_Button_POS_WIDTH + tabpage_Button_POS_GAP)
                            l = l + IIf(v_strIndicator = "E", 1, 0) 'FDS DieuNDA
                            v_tabSubButton.Left = tabpage_Button_POS_LEFT + l * (tabpage_Button_POS_WIDTH + tabpage_Button_POS_GAP) 'FDS DieuNDA
                            v_tabSubButton.Tag = i  'Which tabPage
                            AddHandler v_tabSubButton.Click, AddressOf Button_Click
                            v_tabGrMaster.Controls.Add(v_tabSubButton)
                            v_count = v_count + 1
                        End If
                    Next
                    If v_strTabSearchCode.Length > 0 Then
                        'Get data via SearchCode
                        If v_strTabGrType = "G" Then
                            'The grid in which data is filled by SEARCHCODE
                            Dim v_tabGrGrid As New GridEx
                            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
                            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                            v_tabGrGrid.FixedHeaderRows.Add(v_cmrHeader)
                            v_tabGrGrid.ReadOnly = True
                            v_tabGrPanel.Controls.Add(v_tabGrGrid)
                            v_GridIndex = v_tabGrPanel.Controls.IndexOf(v_tabGrGrid)
                            v_tabGrGrid.Dock = Windows.Forms.DockStyle.Fill
                            AddHandler v_tabGrGrid.DoubleClick, AddressOf Grid_DblClick
                            If v_tabGrGrid.DataRowTemplate.Cells.Count >= 0 Then
                                For j = 0 To v_tabGrGrid.DataRowTemplate.Cells.Count - 1
                                    AddHandler v_tabGrGrid.DataRowTemplate.Cells(j).DoubleClick, AddressOf Grid_DblClick
                                    AddHandler v_tabGrGrid.DataRowTemplate.Cells(j).Click, AddressOf Grid_Click
                                Next
                            End If
                            AddHandler v_tabGrGrid.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp
                        End If
                    End If
                End If
                v_tabGrMaster.Controls.Add(v_tabGrPanel)
                v_PanelIndex = v_tabGrMaster.Controls.IndexOf(v_tabGrPanel)
                If v_count = 0 Then
                    v_tabGrPanel.Dock = Windows.Forms.DockStyle.Fill
                Else
                    v_tabGrPanel.Dock = Windows.Forms.DockStyle.Bottom

                End If

                Dim v_objGroup As New CGrpMaster
                With v_objGroup
                    .OBJNAME = v_strGrpObjName
                    .GRNAME = v_strTabGrName
                    .GRTYPE = v_strTabGrType
                    .SEARCHCODE = v_strTabSearchCode
                    .GRBUTTONS = v_strObjButtons
                    .CAREBYCHK = v_strCareByChk
                    .GRIDIDX = v_GridIndex
                    .PANELIDX = v_PanelIndex
                End With
                mv_arrObjGroups(i) = v_objGroup

                Me.tabMaster.TabPages.Add(v_tabGrMaster)
            Next
            ReDim Preserve mv_arrObjGroups(v_nodeList.Count)

            'Show window title
            If Me.UserLanguage = "VN" Then
                Me.Text = v_strObjTitle
            Else
                Me.Text = v_strObjEnTitle
            End If
            Dim v_intTop As Integer = tabpage_Button_POS_TOP + Me.tabMaster.Top + Me.tabMaster.Height
            'Show window main button
            For k = 0 To v_strObjButtons.Length - 1 Step 1
                v_strIndicator = v_strObjButtons.Substring(k, 1)
                Select Case k + 1
                    Case window_Button_NAVIGATE
                        Me.btnNavigate.Visible = IIf(v_strIndicator = "Y", True, False)
                        Me.cboLink.Visible = Me.btnNavigate.Visible
                        cboLink.Top = v_intTop
                        btnNavigate.Top = v_intTop
                    Case window_Button_EXTERNAL
                        Me.btnExternal.Visible = IIf(v_strIndicator = "Y", True, False)
                        btnExternal.Top = v_intTop
                    Case window_Button_REJECT
                        Me.btnReject.Visible = IIf(v_strIndicator = "Y", True, False)
                        btnReject.Top = v_intTop
                    Case window_Button_APPROVE
                        Me.btnApprove.Visible = IIf(v_strIndicator = "Y", True, False)
                        btnApprove.Top = v_intTop
                    Case window_Button_OK
                        Me.btnOK.Visible = IIf(v_strIndicator = "Y", True, False)
                        btnOK.Top = v_intTop
                    Case window_Button_APPLY
                        If Me.ExeFlag = ExecuteFlag.AddNew Then
                            Me.btnApply.Visible = False
                        Else
                            Me.btnApply.Visible = IIf(v_strIndicator = "Y", True, False)
                        End If

                        btnApply.Top = v_intTop
                    Case window_Button_CANCEL
                        Me.btnCancel.Visible = IIf(v_strIndicator = "Y", True, False)
                        btnCancel.Top = v_intTop
                End Select
            Next
            btnOK.Enabled = (Me.ExeFlag <> ExecuteFlag.View)
            btnApply.Enabled = (Me.ExeFlag <> ExecuteFlag.View)
            btnApprove.Enabled = (Me.ExeFlag = ExecuteFlag.Approve)
            btnApprove.Visible = (Me.ExeFlag = ExecuteFlag.Approve)
            btnReject.Enabled = (Me.ExeFlag <> ExecuteFlag.View) And (Me.ExeFlag <> ExecuteFlag.AddNew)
            Me.ObjCareBy = v_strObjCareBy
            Me.ObjAutoID = v_strObjAutoID
            '===============================================================================================================================

            '===============================================================================================================================
            'Doc thong tin cac truong cua object duoc dung de hien thi
            v_strClause = "upper(MODCODE) = '" & ModuleCode & "' AND upper(OBJNAME) = '" & ObjectName & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)
            mv_strXMLFldMaster = v_strObjMsg

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
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
                            Case "PDEFNAME"
                                v_strPDefName = Trim(v_strValue)
                            Case "CAPTION"
                                v_strCaption = Trim(v_strValue)
                            Case "EN_CAPTION"
                                v_strEnCaption = Trim(v_strValue)
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
                                v_strCtlType = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSRMODCode = Trim(v_strValue)
                            Case "RISKFLD"
                                v_blnRiskField = (Trim(v_strValue) = "Y")
                            Case "GRNAME"
                                v_strGroupName = Trim(v_strValue)
                            Case "TAGFIELD"
                                v_strTagField = Trim(v_strValue)
                            Case "TAGVALUE"
                                v_strTagValue = Trim(v_strValue)
                            Case "TAGLIST"
                                v_strTagList = Trim(v_strValue)
                            Case "TAGUPDATE"
                                v_strTagUpdate = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "INVFORMAT"
                                v_strInvFormat = Trim(v_strValue)
                            Case "SUBFIELD"
                                v_strSubField = Trim(v_strValue)
                            Case "PDEFVAL"
                                v_strPDefValue = Trim(v_strValue)
                            Case "DEFDESC"
                                v_strDefDesc = Trim(v_strValue)
                            Case "DEFPARAM"
                                v_strDefParam = Trim(v_strValue)
                        End Select
                    End With
                Next

                If String.Compare(v_strDefVal, "<$BRID>") = 0 Then v_strDefVal = Me.BranchId
                If String.Compare(v_strDefVal, "<$TLID>") = 0 Then v_strDefVal = Me.TellerId
                If String.Compare(v_strDefVal, "<$BUSDATE>") = 0 Then v_strDefVal = Me.BusDate
                If String.Compare(v_strDefVal, "<$NEXTDATE>") = 0 Then v_strDefVal = Me.NextDate
                If String.Compare(v_strDefVal, "<$PARENTID>") = 0 Then v_strDefVal = Me.ParentValue
                If String.Compare(v_strDefVal, "<$PARENTOBJ>") = 0 Then v_strDefVal = Me.ParentObject
                If String.Compare(v_strDefVal, "<$PARENTMOD>") = 0 Then v_strDefVal = Me.ParentModule
                If String.Compare(v_strDefVal, "<$KEYVALUE>") = 0 Then v_strDefVal = Me.KeyFieldValue
                If String.Compare(v_strDefVal, "<$OBJNAME>") = 0 Then v_strDefVal = Me.ObjectName
                If String.Compare(v_strDefVal, "<$MODCODE>") = 0 Then v_strDefVal = Me.ModuleCode
                If String.Compare(v_strDefVal, "<$COMPANYCD>") = 0 Then v_strDefVal = Me.CompanyCode

                'HaiLT them
                If v_strDefVal.IndexOf("<$SQL>") >= 0 Then
                    'Neu la tham chieu tu cau lenh SQL
                    Dim mv_strXMLFldMasterTmp As String
                    Dim v_nodeListTmp As Xml.XmlNodeList
                    Dim v_xmlDocumentTmp As New Xml.XmlDocument
                    Dim v_strClauseTmp, v_strValueTmp, v_strFLDNAMETmp As String
                    v_strDefVal = Replace(v_strDefVal, "<$SQL>", "")
                    v_strDefVal = Replace(v_strDefVal, "<$BRID>", Me.BranchId)
                    v_strDefVal = Replace(v_strDefVal, "<$TLID>", Me.TellerId)
                    v_strDefVal = Replace(v_strDefVal, "<$BUSDATE>", Me.BusDate)
                    v_strDefVal = Replace(v_strDefVal, "<$PARENTID>", Me.ParentValue)
                    v_strDefVal = Replace(v_strDefVal, "<$PARENTOBJ>", Me.ParentObject)
                    v_strDefVal = Replace(v_strDefVal, "<$PARENTMOD>", Me.ParentModule)
                    v_strDefVal = Replace(v_strDefVal, "<$KEYVALUE>", Me.KeyFieldValue)
                    v_strDefVal = Replace(v_strDefVal, "<$OBJNAME>", Me.ObjectName)
                    v_strDefVal = Replace(v_strDefVal, "<$MODCODE>", Me.ModuleCode)
                    v_strDefVal = Replace(v_strDefVal, "<$COMPANYCD>", Me.CompanyCode)

                    v_strDefVal = Replace(v_strDefVal, "<$REF_MODCODE>", "'" & GetRefFieldValueByName("<$REF_MODCODE>") & "'")
                    v_strDefVal = Replace(v_strDefVal, "<$REF_ACTYPE>", "'" & GetRefFieldValueByName("<$REF_ACTYPE>") & "'")
                    v_strDefVal = Replace(v_strDefVal, "<$REF_EVENTCODE>", "'" & GetRefFieldValueByName("<$REF_EVENTCODE>") & "'")
                    v_strDefVal = Replace(v_strDefVal, "<$REF_CUSTID>", "'" & GetRefFieldValueByName("<$REF_CUSTID>") & "'")
                    v_strDefVal = Replace(v_strDefVal, "<$REF_CUSTODYCD>", "'" & GetRefFieldValueByName("<$REF_CUSTODYCD>") & "'")


                    'Doc thong tin cac truong cua object duoc dung de hien thi
                    v_strObjMsgTmp = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strDefVal, )
                    v_ws.Message(v_strObjMsgTmp)
                    'mv_strXMLFldMasterTmp = v_strObjMsgTmp
                    v_xmlDocumentTmp.LoadXml(v_strObjMsgTmp)
                    v_nodeListTmp = v_xmlDocumentTmp.SelectNodes("/ObjectMessage/ObjData")
                    'ReDim mv_arrObjFields(v_nodeListTmp.Count)
                    For l As Integer = 0 To v_nodeListTmp.Count - 1
                        For m As Integer = 0 To v_nodeListTmp.Item(l).ChildNodes.Count - 1
                            With v_nodeListTmp.Item(l).ChildNodes(m)
                                v_strValueTmp = .InnerText.ToString
                                v_strFLDNAMETmp = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                                Select Case Trim(v_strFLDNAMETmp)
                                    Case "DEFNAME"
                                        v_strDefVal = Trim(v_strValueTmp)
                                End Select
                            End With
                        Next
                    Next

                End If
                'End of HaiLT them


                If v_strDefVal.IndexOf(PREFIXED_REFMASTER) >= 0 Then
                    'Neu la truong tham chieu tu object cha
                    v_strDefVal = GetRefFieldValueByName(v_strDefVal)
                End If

                'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    v_strLList = v_strLList.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                    v_strLList = v_strLList.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                Else
                    v_strLList = v_strLList.Replace("<@CDCONTENT>", "CDCONTENT")
                    v_strLList = v_strLList.Replace("<@DESCRIPTION>", "DESCRIPTION")
                End If
                'NamTv End.

                Dim v_objField As New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .EnCaption = v_strEnCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .ControlType = v_strCtlType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .FieldWidth = v_intFldWidth
                    .FieldRow = v_intFldRow
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .LookupName = v_strLookupName
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSRMODCode
                    .RiskField = v_blnRiskField
                    .GroupName = v_strGroupName
                    .TagField = v_strTagField
                    .TagValue = v_strTagValue
                    .TagList = v_strTagList
                    .TagListData = String.Empty
                    .TagLookUpDesc = String.Empty
                    .TagUpdate = v_strTagUpdate
                    .InvName = v_strInvName
                    .InvFormat = v_strInvFormat
                    .PDefName = v_strPDefName
                    .PDefValue = v_strPDefValue
                    .SubField = v_strSubField
                    .DefDesc = v_strDefDesc
                    .DefParam = v_strDefParam
                    .GroupIndex = -1
                    .TabIndex = -1
                    .ControlIndex = -1
                End With
                mv_arrObjFields(i) = v_objField
            Next
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)
            '===============================================================================================================================

            '===============================================================================================================================
            'Doc thong tin cac luat kiem tra
            LoadObjectFieldValidateRules()
            '===============================================================================================================================

            'Get master data to fill to FieldValue of the Fields array
            If (Me.ExeFlag = ExecuteFlag.Edit) Or (Me.ExeFlag = ExecuteFlag.View) Or (Me.ExeFlag = ExecuteFlag.Approve) Then
                GetMasterData(v_strMainTabSearchCode)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message & ControlChars.CrLf & v_strSQL, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadTabPageControl()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".LoadTabPageControl"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery, v_strSQL As String
        Dim v_count, v_intIndex, v_intSubIndex, v_intTop, v_intPosition, v_intLastTop, v_intLeft, v_intWidth, i, j As Integer
        Dim v_lblCaption, v_lblDesc As Label, v_ltvData As ListView, v_txtData As TextBox, v_mskData As FlexMaskEditBox, v_cboData As ComboBoxEx, v_btnData As Button, v_control As Control, v_panel As Panel, v_rtbData As RichTextBox
        Dim v_strIndicator, v_strTabPanelName, v_strGroupName, v_strCmdSQL, v_strObjMsg, v_strTempValue, v_strREFVALUE As String, v_blnFlagEnabled, v_blnFlagVisible As Boolean
        Dim v_intPos As Integer

        Try
            If Me.tabMaster.TabPages.Count > 0 Then 'Already tab control
                For i = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                    v_strIndicator = Me.tabMaster.TabPages(i).Tag
                    v_strGroupName = Me.tabMaster.TabPages(i).Name
                    If v_strIndicator.Substring(0, 1) <> "G" Then   'If tab does not have grid
                        v_strTabPanelName = "pn" & Me.tabMaster.TabPages(i).Name
                        Me.tabMaster.SelectedIndex = i
                        For Each v_control In Me.tabMaster.TabPages(i).Controls
                            If v_control.Name = v_strTabPanelName Then
                                v_control.Show()
                                v_panel = CType(v_control, Panel)
                                'Clear all child control in panel
                                v_panel.Controls.Clear()
                                v_panel.Tag = 0
                                v_panel.AutoScroll = True
                                v_panel.Visible = True
                                'Scan all field in object fields array to add to panel
                                v_count = mv_arrObjFields.GetLength(0)
                                j = 0
                                v_intPosition = 0
                                If v_count > 0 Then
                                    Dim v_intRow As Integer = 1
                                    Dim v_lngAddLength As Long = 0
                                    For v_intIndex = 0 To v_count - 1 Step 1
                                        If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                            If mv_arrObjFields(v_intIndex).GroupName = v_strGroupName Then
                                                v_lblCaption = New Label
                                                v_lblDesc = New Label
                                                v_lblCaption.Visible = mv_arrObjFields(v_intIndex).Visible
                                                v_lblDesc.Text = mv_arrObjFields(v_intIndex).TagLookUpDesc
                                                If mv_arrObjFields(v_intIndex).TagLookUpDesc.Trim.Length > 0 _
                                                    And mv_arrObjFields(v_intIndex).LookUp = "Y" _
                                                    And (mv_arrObjFields(v_intIndex).ControlType.Trim = "T" _
                                                    Or mv_arrObjFields(v_intIndex).ControlType.Trim = "M") Then
                                                    v_lblDesc.Visible = True
                                                ElseIf mv_arrObjFields(v_intIndex).TagLookUpDesc.Trim.Length > 0 _
                                                    And mv_arrObjFields(v_intIndex).SearchCode.Length > 0 _
                                                    And (mv_arrObjFields(v_intIndex).ControlType.Trim = "T" _
                                                    Or mv_arrObjFields(v_intIndex).ControlType.Trim = "M") Then
                                                    v_lblDesc.Visible = True
                                                Else
                                                    v_lblDesc.Visible = False
                                                End If

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
                                                If Me.UserLanguage = "VN" Then
                                                    v_lblCaption.Text = mv_arrObjFields(v_intIndex).Caption
                                                Else
                                                    v_lblCaption.Text = mv_arrObjFields(v_intIndex).EnCaption
                                                End If
                                                v_lblCaption.RightToLeft = RightToLeft.Yes
                                                v_lblCaption.Name = PREFIXED_LBLCAP & Trim(mv_arrObjFields(v_intIndex).FieldName)

                                                'Lay gia tri cua truong tham chieu TAGFIELD
                                                'TAGVALUE co dang FIELDNAME[FIELDVALUE]
                                                'Neu FIELDNAME = "" -> truong tham chieu la TAGFIELD, FIELDVALUE lay gia tri cua TAGFIELD
                                                'Neu khong thi truong tham chieu la FIELDNAME, so sanh FIELDVALUE theo gia tri cua FIELDNAME
                                                'Gia tri cua truong tham chieu = FIELDVALUE -> enable control
                                                v_blnFlagEnabled = False 'Default is enabled
                                                v_strTempValue = String.Empty
                                                If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                                    v_intPos = mv_arrObjFields(v_intIndex).TagValue.Trim.IndexOf("[")
                                                    If v_intPos = 0 Then
                                                        v_strTempValue = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField)
                                                        'Chi enabled control neu gia tri hien tai
                                                        If mv_arrObjFields(v_intIndex).TagValue.IndexOf("[" & v_strTempValue & "]") >= 0 Then
                                                            v_blnFlagEnabled = True
                                                        End If
                                                    Else
                                                        'Neu TagValue ko co gia tri thi THEO qui dinh
                                                        v_blnFlagEnabled = mv_arrObjFields(v_intIndex).Enabled
                                                    End If
                                                End If

                                                Select Case Trim(mv_arrObjFields(v_intIndex).ControlType)
                                                    Case "L" 'ListView
                                                        v_ltvData = New ListView
                                                        v_ltvData.Visible = mv_arrObjFields(v_intIndex).Visible
                                                        v_ltvData.Top = v_intTop
                                                        v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                                        v_ltvData.Left = v_intLeft
                                                        v_intWidth = LTV_WIDTH
                                                        If ALL_WIDTH < v_intLeft + v_intWidth Then
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        v_ltvData.Width = v_intWidth
                                                        v_ltvData.Tag = v_intIndex
                                                        v_ltvData.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                                        v_ltvData.FullRowSelect = True
                                                        v_ltvData.GridLines = True
                                                        v_ltvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
                                                        v_ltvData.View = System.Windows.Forms.View.Details
                                                        v_ltvData.Name = PREFIXED_LTVDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                    Case "T" 'TextBox
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
                                                        v_txtData.Width = v_intWidth
                                                        v_txtData.Tag = v_intIndex

                                                        'Xử lý enabled/visible
                                                        If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                                            v_txtData.Enabled = v_blnFlagEnabled
                                                        Else
                                                            v_txtData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                                        End If

                                                        'Neu o mode edit va la truong key HOAC riskfield thi disabled luon
                                                        'Trung.luu => Neu o mode approve thi disabled tat ca cac field
                                                        If Me.ExeFlag = ExecuteFlag.Edit Then
                                                            If String.Compare(mv_arrObjFields(v_intIndex).FieldName, Me.KeyFieldName) = 0 Or _
                                                            mv_arrObjFields(v_intIndex).RiskField Then
                                                                v_txtData.Enabled = False
                                                            End If
                                                        ElseIf Me.ExeFlag = ExecuteFlag.View Then
                                                            v_txtData.Enabled = False
                                                        ElseIf Me.ExeFlag = ExecuteFlag.Approve Then
                                                            v_txtData.Enabled = False
                                                        End If
                                                        v_txtData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                        If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                                            v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                                            If mv_arrObjFields(v_intIndex).DataType = "N" Then
                                                                FormatNumericTextbox(CType(v_txtData, TextBox))
                                                            End If
                                                        Else
                                                            If mv_arrObjFields(v_intIndex).DefDesc.Length > 0 Then
                                                                v_txtData.Text = FillDefinitionDescription(v_intIndex)
                                                            Else
                                                                If mv_arrObjFields(v_intIndex).DataType = "N" Then
                                                                    v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                                                    FormatNumericTextbox(CType(v_txtData, TextBox))
                                                                Else
                                                                    v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                                                End If
                                                            End If

                                                        End If
                                                        AddHandler v_txtData.GotFocus, AddressOf mskData_GotFocus
                                                        AddHandler v_txtData.Validating, AddressOf mskData_Validating
                                                        v_lblDesc.Top = v_intTop
                                                        v_intLeft = v_txtData.Left + v_txtData.Width + CONTROL_GAP
                                                        If v_intLeft >= ALL_WIDTH Then
                                                            v_intWidth = 0
                                                        Else
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        If Trim(mv_arrObjFields(v_intIndex).DataType) = "P" Then
                                                            CType(v_txtData, TextBox).PasswordChar = "*"
                                                        End If
                                                        If Me.ExeFlag = ExecuteFlag.Edit And Me.IsRiskManagement Then
                                                            v_txtData.Enabled = mv_arrObjFields(v_intIndex).RiskField
                                                        End If
                                                        'Vutn them case upper
                                                        If mv_arrObjFields(v_intIndex).FieldFormat = "UPPER" Then
                                                            v_txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
                                                        End If
                                                        'End Vutn them case upper
                                                    Case "R" 'RichTextBox
                                                        v_rtbData = New RichTextBox
                                                        v_rtbData.Visible = mv_arrObjFields(v_intIndex).Visible
                                                        v_rtbData.Top = v_intTop
                                                        v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP

                                                        v_rtbData.Left = v_intLeft
                                                        v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                                        If ALL_WIDTH_R < v_intLeft + v_intWidth Then
                                                            v_intWidth = ALL_WIDTH_R - v_intLeft
                                                        End If
                                                        v_rtbData.MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                                                        v_rtbData.Width = v_intWidth
                                                        v_rtbData.Tag = v_intIndex

                                                        'Xử lý enabled/visible
                                                        If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                                            v_rtbData.Enabled = v_blnFlagEnabled
                                                        Else
                                                            v_rtbData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                                        End If

                                                        'Neu o mode edit va la truong key HOAC riskfield thi disabled luon
                                                        'Trung.luu => Neu o mode approve thi disabled tat ca cac field
                                                        If Me.ExeFlag = ExecuteFlag.Edit Then
                                                            If String.Compare(mv_arrObjFields(v_intIndex).FieldName, Me.KeyFieldName) = 0 Or _
                                                            mv_arrObjFields(v_intIndex).RiskField Then
                                                                v_rtbData.Enabled = False
                                                            End If
                                                        ElseIf Me.ExeFlag = ExecuteFlag.View Then
                                                            v_rtbData.Enabled = False
                                                        ElseIf Me.ExeFlag = ExecuteFlag.Approve Then
                                                            v_rtbData.Enabled = False
                                                        End If
                                                        v_rtbData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                        If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                                            v_rtbData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                                        End If
                                                        mv_v_rtbData_RichTextBox.Text = v_rtbData.Text 'trung.luu: 14-01-2021 log lai data de ket xuat
                                                        AddHandler v_rtbData.GotFocus, AddressOf mskData_GotFocus
                                                        AddHandler v_rtbData.Validating, AddressOf mskData_Validating
                                                        AddHandler v_rtbData.MouseUp, AddressOf tabMaster_MouseDown 'trung.luu: 14-01-2021 ket xuat dien

                                                        v_lblDesc.Top = v_intTop
                                                        v_intLeft = v_rtbData.Left + v_rtbData.Width + CONTROL_GAP
                                                        If v_intLeft >= ALL_WIDTH_R Then
                                                            v_intWidth = 0
                                                        Else
                                                            v_intWidth = ALL_WIDTH_R - v_intLeft
                                                        End If
                                                        If Me.ExeFlag = ExecuteFlag.Edit And Me.IsRiskManagement Then
                                                            v_rtbData.Enabled = mv_arrObjFields(v_intIndex).RiskField
                                                        End If
                                                        'v_rtbData.Height = v_rtbData.Width * 2 / 3
                                                        If ObjectName = "MT.SHVTXREQ" Or ObjectName = "MT.SHVSWIFT" Or ObjectName = "MT.MT9000" Or ObjectName = "ST.VSDTXINFO" Or ObjectName = "ST.VSDTXINFOHIST" Or ObjectName = "MT.WCRBLOG" Then
                                                            v_lblCaption.Visible = False
                                                            v_lblCaption.Top = 10000
                                                            v_rtbData.Enabled = True
                                                            v_rtbData.Width = ALL_WIDTH_R - CONTROL_LEFT - CONTROL_GAP
                                                            v_rtbData.Left = CONTROL_LEFT + CONTROL_GAP
                                                        End If

                                                        v_rtbData.Height = CONTROL_HEIGHT + (CONTROL_HEIGHT - 10) * (v_intRow - 1)
                                                        v_rtbData.Multiline = True
                                                        v_rtbData.BorderStyle = BorderStyle.Fixed3D

                                                    Case "M" 'FlexMaskedEdit
                                                        v_mskData = New FlexMaskEditBox
                                                        v_mskData.Visible = mv_arrObjFields(v_intIndex).Visible
                                                        v_mskData.Top = v_intTop
                                                        v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                                        v_mskData.Left = v_intLeft
                                                        v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                                        If ALL_WIDTH < v_intLeft + v_intWidth Then
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        v_mskData.Width = v_intWidth
                                                        v_mskData.Tag = v_intIndex
                                                        v_mskData.PromptChar = "_"

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

                                                        If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                                            v_mskData.Enabled = v_blnFlagEnabled
                                                        Else
                                                            v_mskData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                                        End If

                                                        'Neu o mode edit va la truong key thi disabled luon
                                                        'Trung.luu => Neu o mode approve thi disabled tat ca cac field
                                                        If Me.ExeFlag = ExecuteFlag.Edit Then
                                                            If String.Compare(mv_arrObjFields(v_intIndex).FieldName, Me.KeyFieldName) = 0 Or _
                                                            mv_arrObjFields(v_intIndex).RiskField Then
                                                                v_mskData.Enabled = False
                                                            End If
                                                        ElseIf Me.ExeFlag = ExecuteFlag.View Then
                                                            v_mskData.Enabled = False
                                                        ElseIf Me.ExeFlag = ExecuteFlag.Approve Then
                                                            v_mskData.Enabled = False
                                                        End If
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
                                                                    If Me.ExeFlag = ExecuteFlag.AddNew Then
                                                                        'v_mskData.Text = Me.BusDate
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                        AddHandler v_mskData.GotFocus, AddressOf mskData_GotFocus
                                                        AddHandler v_mskData.Validating, AddressOf mskData_Validating

                                                        v_lblDesc.Top = v_intTop
                                                        v_intLeft = v_mskData.Left + v_mskData.Width + CONTROL_GAP
                                                        If v_intLeft >= ALL_WIDTH Then
                                                            v_intWidth = 0
                                                        Else
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        If Me.ExeFlag = ExecuteFlag.Edit And Me.IsRiskManagement Then
                                                            v_mskData.Enabled = mv_arrObjFields(v_intIndex).RiskField
                                                        End If

                                                    Case "C" 'ComboBox
                                                        v_cboData = New ComboBoxEx
                                                        'v_cboData.DropDownStyle = ComboBoxStyle.DropDown
                                                        v_cboData.DropDownStyle = ComboBoxStyle.DropDown

                                                        v_cboData.Top = v_intTop
                                                        v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                                        v_cboData.Left = v_intLeft
                                                        If mv_arrObjFields(v_intIndex).FieldLength <= 15 Then
                                                            v_intWidth = 15 * WIDTH_PERCHAR
                                                        Else
                                                            v_intWidth = mv_arrObjFields(v_intIndex).FieldWidth * WIDTH_PERCHAR
                                                        End If

                                                        If ALL_WIDTH < v_intLeft + v_intWidth Then
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        v_cboData.Width = v_intWidth
                                                        v_cboData.Tag = v_intIndex

                                                        If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                                            v_cboData.Enabled = v_blnFlagEnabled
                                                        Else
                                                            v_cboData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                                        End If

                                                        'Neu o mode edit va la truong key thi disabled luon
                                                        'Trung.luu => Neu o mode approve thi disabled tat ca cac field
                                                        If Me.ExeFlag = ExecuteFlag.Edit Then
                                                            If String.Compare(mv_arrObjFields(v_intIndex).FieldName, Me.KeyFieldName) = 0 Or _
                                                            mv_arrObjFields(v_intIndex).RiskField Then
                                                                v_cboData.Enabled = False
                                                            End If
                                                        ElseIf Me.ExeFlag = ExecuteFlag.View Then
                                                            v_cboData.Enabled = False
                                                        ElseIf Me.ExeFlag = ExecuteFlag.Approve Then
                                                            v_cboData.Enabled = False
                                                        End If

                                                        v_cboData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                        v_cboData.DropDownStyle = ComboBoxStyle.DropDown
                                                        AddHandler v_cboData.SelectedIndexChanged, AddressOf cboData_SelectedIndexChanged
                                                        AddHandler v_cboData.Validating, AddressOf cboData_Validating

                                                        v_lblDesc.Top = v_intTop
                                                        v_intLeft = v_cboData.Left + v_cboData.Width + CONTROL_GAP
                                                        If v_intLeft >= ALL_WIDTH Then
                                                            v_intWidth = 0
                                                        Else
                                                            v_intWidth = ALL_WIDTH - v_intLeft
                                                        End If
                                                        If Me.ExeFlag = ExecuteFlag.Edit And Me.IsRiskManagement Then
                                                            v_cboData.Enabled = mv_arrObjFields(v_intIndex).RiskField
                                                        End If

                                                        'Nap du lieu cho ComboBox
                                                        v_strCmdSQL = mv_arrObjFields(v_intIndex).LookupList
                                                        'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                                                        If Me.UserLanguage = gc_LANG_ENGLISH Then
                                                            v_strCmdSQL = v_strCmdSQL.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                                            v_strCmdSQL = v_strCmdSQL.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                                        Else
                                                            v_strCmdSQL = v_strCmdSQL.Replace("<@CDCONTENT>", "CDCONTENT")
                                                            v_strCmdSQL = v_strCmdSQL.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                                        End If
                                                        'NamTv End.
                                                        If v_strCmdSQL.Trim.Length > 0 Then
                                                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                                            v_ws.Message(v_strObjMsg)
                                                            FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                                        End If

                                                        'Luu tru danh sach TagList
                                                        v_strCmdSQL = mv_arrObjFields(v_intIndex).TagList
                                                        If v_strCmdSQL.Trim.Length > 0 Then
                                                            If mv_arrObjFields(v_intIndex).TagField.Length > 0 Then
                                                                v_strREFVALUE = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField)
                                                                v_strCmdSQL = v_strCmdSQL.Replace("<$TAGFIELD>", v_strREFVALUE)
                                                            End If
                                                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                                            v_ws.Message(v_strObjMsg)
                                                            mv_arrObjFields(v_intIndex).TagListData = v_strObjMsg
                                                            FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                                        End If

                                                End Select

                                                v_lblDesc.Tag = mv_arrObjFields(v_intIndex).LookupCheck
                                                v_lblDesc.Left = v_intLeft
                                                'v_lblDesc.Width = v_intWidth
                                                v_lblDesc.Width = v_panel.Width - v_intLeft - 100
                                                v_lblDesc.Name = PREFIXED_LBLDESC & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                v_panel.Controls.Add(v_lblCaption)

                                                v_panel.Controls.Add(v_lblDesc)
                                                mv_arrObjFields(v_intIndex).CaptionIndex = v_panel.Controls.IndexOf(v_lblCaption)
                                                mv_arrObjFields(v_intIndex).LabelIndex = v_panel.Controls.IndexOf(v_lblDesc)
                                                mv_arrObjFields(v_intIndex).GroupIndex = Me.tabMaster.TabPages(i).Controls.IndexOf(v_panel)
                                                mv_arrObjFields(v_intIndex).TabIndex = i
                                                Select Case Trim(mv_arrObjFields(v_intIndex).ControlType)
                                                    Case "L"
                                                        v_panel.Controls.Add(v_ltvData)
                                                        mv_arrObjFields(v_intIndex).ControlIndex = v_panel.Controls.IndexOf(v_ltvData)
                                                    Case "T"
                                                        v_panel.Controls.Add(v_txtData)
                                                        If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_txtData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_txtData)).BackColor = System.Drawing.Color.GreenYellow
                                                        ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_txtData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_txtData)).BackColor = System.Drawing.Color.Khaki
                                                        End If
                                                        mv_arrObjFields(v_intIndex).ControlIndex = v_panel.Controls.IndexOf(v_txtData)
                                                        mv_arrObjFields(v_intIndex).FieldValue = v_txtData.Text
                                                    Case "R"
                                                        v_panel.Controls.Add(v_rtbData)
                                                        If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_rtbData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_rtbData)).BackColor = System.Drawing.Color.GreenYellow
                                                        ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_rtbData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_rtbData)).BackColor = System.Drawing.Color.Khaki
                                                        End If
                                                        mv_arrObjFields(v_intIndex).ControlIndex = v_panel.Controls.IndexOf(v_rtbData)
                                                        mv_arrObjFields(v_intIndex).FieldValue = v_rtbData.Text
                                                    Case "M"
                                                        v_panel.Controls.Add(v_mskData)
                                                        If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_mskData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_mskData)).BackColor = System.Drawing.Color.GreenYellow
                                                        ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 _
                                                            And v_panel.Controls(v_panel.Controls.IndexOf(v_mskData)).Enabled Then
                                                            v_panel.Controls(v_panel.Controls.IndexOf(v_mskData)).BackColor = System.Drawing.Color.Khaki
                                                        End If
                                                        mv_arrObjFields(v_intIndex).ControlIndex = v_panel.Controls.IndexOf(v_mskData)
                                                        mv_arrObjFields(v_intIndex).FieldValue = v_mskData.Text
                                                        If mv_arrObjFields(v_intIndex).FieldName = "CCYCD" Then
                                                            mv_strCCYCD = v_mskData.Text
                                                        ElseIf mv_arrObjFields(v_intIndex).FieldName = "GLGRP" Then
                                                            mv_strGLGRP = v_mskData.Text
                                                        End If
                                                    Case "C"
                                                        v_panel.Controls.Add(v_cboData)
                                                        mv_arrObjFields(v_intIndex).ControlIndex = v_panel.Controls.IndexOf(v_cboData)
                                                        'Set selectedvalue for combo
                                                        If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                                            CType(v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex), ComboBoxEx).SelectedValue = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                                        ElseIf Len(Trim(mv_arrObjFields(v_intIndex).DefaultValue)) > 0 Then
                                                            CType(v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex), ComboBoxEx).SelectedValue = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                                        End If
                                                        mv_arrObjFields(v_intIndex).FieldValue = CType(v_panel.Controls(mv_arrObjFields(v_intIndex).ControlIndex), ComboBoxEx).SelectedValue
                                                        If mv_arrObjFields(v_intIndex).FieldName = "CCYCD" Then
                                                            mv_strCCYCD = mv_arrObjFields(v_intIndex).FieldValue
                                                        ElseIf mv_arrObjFields(v_intIndex).FieldName = "GLGRP" Then
                                                            mv_strGLGRP = mv_arrObjFields(v_intIndex).FieldValue
                                                        End If
                                                        v_cboData.Visible = mv_arrObjFields(v_intIndex).Visible
                                                        v_cboData.Show()
                                                End Select

                                                If mv_arrObjFields(v_intIndex).InvName.Trim.Length > 0 And Me.ExeFlag = ExecuteFlag.AddNew Then
                                                    'Generate value
                                                    v_btnData = New Button
                                                    v_btnData.Name = PREFIXED_BTNDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                                    v_btnData.Text = "@"
                                                    v_btnData.Tag = v_intIndex
                                                    v_btnData.Top = v_lblDesc.Top
                                                    v_btnData.Left = v_lblDesc.Left
                                                    v_btnData.Height = v_lblDesc.Height
                                                    v_btnData.Width = 24
                                                    v_btnData.Visible = True
                                                    v_lblDesc.Visible = False
                                                    AddHandler v_btnData.Click, AddressOf Button_Click
                                                    v_panel.Controls.Add(v_btnData)
                                                    mv_arrObjFields(v_intIndex).ButtonIndex = v_panel.Controls.IndexOf(v_btnData)
                                                Else
                                                    mv_arrObjFields(v_intIndex).ButtonIndex = -1
                                                End If


                                                If mv_arrObjFields(v_intIndex).Visible Then
                                                    If mv_arrObjFields(v_intIndex).ControlType = "L" Then
                                                        v_intPosition = v_intPosition + 4
                                                    Else
                                                        v_intPosition = v_intPosition + 1
                                                    End If
                                                    v_intLastTop = v_intTop
                                                End If
                                                j = j + 1
                                            End If
                                        End If
                                    Next
                                End If
                                'Save number of fields in the panel
                                v_panel.Tag = j
                            End If

                        Next
                    End If
                Next
                Me.tabMaster.SelectedIndex = 0


                Dim v_tabIndex, v_panelIndex As Integer
                Dim v_ctrl As Control
                For i = 0 To v_count - 1
                    If Not mv_arrObjFields(i) Is Nothing Then
                        If Len(mv_arrObjFields(i).SearchCode) > 0 Or mv_arrObjFields(i).LookUp = "Y" Then
                            v_tabIndex = mv_arrObjFields(i).TabIndex
                            v_panelIndex = mv_arrObjFields(i).GroupIndex
                            v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                            v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                            If mv_arrObjFields(i).ControlType = "T" Or mv_arrObjFields(i).ControlType = "M" Or mv_arrObjFields(i).ControlType = "R" Then
                                If Len(mv_arrObjFields(i).SearchCode) > 0 And Len(mv_arrObjFields(i).FieldValue) > 0 Then
                                    FillControlValueBySearchCode(v_ctrl, mv_arrObjFields(i).FieldValue, mv_arrObjFields(i).FieldName)
                                ElseIf mv_arrObjFields(i).LookUp = "Y" And Len(mv_arrObjFields(i).FieldValue) > 0 Then
                                    FillControlValueByLookup(v_ctrl, mv_arrObjFields(i).FieldValue, mv_arrObjFields(i).FieldName)
                                End If
                            End If
                        End If
                        If mv_arrObjFields(i).ControlType = "L" Then
                            v_tabIndex = mv_arrObjFields(i).TabIndex
                            v_panelIndex = mv_arrObjFields(i).GroupIndex
                            v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                            v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                            If mv_strGLGRP <> String.Empty Then
                                DoFillReturnValue(mv_strGLGRP, Me.ModuleCode, CType(v_ctrl, ListView), mv_strCCYCD)
                            End If
                        End If
                    End If
                Next

            End If
            'Dat che do ban dau la hien thi o Basic mode
            ToggleFirstTabBasicAdvancedShow()
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub ShowScreenBasedOnActionFlag()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".ShowScreenBasedOnActionFlag"
        Try
            Dim v_control As Control, v_panel As Panel, v_strIndicator As String
            Dim v_idx, v_panelIndex As Integer
            Select Case Me.ExeFlag
                Case ExecuteFlag.AddNew
                    'All grid & record tabs are invisible
                    For v_idx = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                        v_strIndicator = Me.tabMaster.TabPages(v_idx).Tag
                        If v_strIndicator.Substring(0, 1) <> "N" Then   'If tab is not grid or record
                            Me.tabMaster.TabPages(v_idx).Enabled = False
                        End If
                    Next
                Case ExecuteFlag.Edit
                    'All tabs are enable
                    For v_idx = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                        v_strIndicator = Me.tabMaster.TabPages(v_idx).Tag
                        If v_strIndicator.Substring(0, 1) <> "N" Then
                            'v_panelIndex = mv_arrObjGroups(v_idx).PANELIDX
                            'v_panel = Me.tabMaster.TabPages(v_idx).Controls(v_panelIndex)
                            For Each v_control In Me.tabMaster.TabPages(v_idx).Controls
                                If TypeOf (v_control) Is Button Then
                                    v_control.Enabled = True
                                End If
                            Next
                        End If
                    Next
                    'Enabled button if it is visible
                    If Me.btnApply.Visible Then Me.btnApply.Enabled = True
                    If Me.btnApprove.Visible Then Me.btnApprove.Enabled = True
                    If Me.btnExternal.Visible Then Me.btnExternal.Enabled = True
                    If Me.btnOK.Visible Then Me.btnOK.Enabled = True
                    If Me.btnReject.Visible Then Me.btnReject.Enabled = True
                Case ExecuteFlag.View
                    'All subbutton being in tabpage is disabled
                    For v_idx = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                        v_strIndicator = Me.tabMaster.TabPages(v_idx).Tag
                        If v_strIndicator.Substring(0, 1) <> "N" Then
                            For Each v_control In Me.tabMaster.TabPages(v_idx).Controls
                                If v_control.Name.IndexOf(PREFIXED_BTNTABPAGE) <> -1 Then
                                    If v_control.Name.IndexOf("_Insert") <> -1 Or _
                                        v_control.Name.IndexOf("_Edit") <> -1 Or _
                                        v_control.Name.IndexOf("_Delete") <> -1 Then
                                        v_control.Enabled = False
                                    Else
                                        v_control.Enabled = True
                                    End If
                                End If
                            Next
                        End If
                    Next
                    'All main buttons are disable except cancel & navigate buttons
                    If Me.btnApply.Visible Then Me.btnApply.Enabled = False
                    If Me.btnApprove.Visible Then Me.btnApprove.Enabled = False
                    If Me.btnExternal.Visible Then Me.btnExternal.Enabled = False
                    If Me.btnOK.Visible Then Me.btnOK.Enabled = False
                    If Me.btnReject.Visible Then Me.btnReject.Enabled = False
                Case ExecuteFlag.Approve
                    'All subbutton being in tabpage is disabled
                    For v_idx = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                        v_strIndicator = Me.tabMaster.TabPages(v_idx).Tag
                        If v_strIndicator.Substring(0, 1) <> "N" Then
                            For Each v_control In Me.tabMaster.TabPages(v_idx).Controls
                                If v_control.Name.IndexOf(PREFIXED_BTNTABPAGE) <> -1 Then
                                    If v_control.Name.IndexOf("_Insert") <> -1 Or _
                                        v_control.Name.IndexOf("_Edit") <> -1 Or _
                                        v_control.Name.IndexOf("_Delete") <> -1 Then
                                        v_control.Enabled = False
                                    Else
                                        v_control.Enabled = True
                                    End If
                                End If
                            Next
                        End If
                    Next
                    If Me.btnApply.Visible Then Me.btnApply.Enabled = False


                    btnOK.Enabled = False
                    btnApply.Enabled = False
                    btnOK.Visible = False
                    btnApply.Visible = False
            End Select
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub


    Private Sub CaptureMasterDataFromScreen()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".CaptureMasterDataFromScreen"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                'Scan all field in array
                v_tabIndex = mv_arrObjFields(i).TabIndex
                v_panelIndex = mv_arrObjFields(i).GroupIndex
                v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)
                'Set data 2 control
                If TypeOf (v_ctrl) Is TextBox Then
                    v_strFLDVALUE = CType(v_ctrl, TextBox).Text
                    If (mv_arrObjFields(i).FieldType = "M") And (mv_arrObjFields(i).DataType = "C") Then
                        v_strFLDVALUE = v_strFLDVALUE.Replace(".", String.Empty)
                    End If
                ElseIf TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    v_strFLDVALUE = CType(v_ctrl, FlexMaskEditBox).Text
                    If (mv_arrObjFields(i).FieldType = "M") And (mv_arrObjFields(i).DataType = "C") Then
                        v_strFLDVALUE = v_strFLDVALUE.Replace(".", String.Empty)
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBox Then
                    v_strFLDVALUE = CType(v_ctrl, ComboBox).SelectedValue
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    v_strFLDVALUE = CType(v_ctrl, ComboBoxEx).SelectedValue
                ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                    v_strFLDVALUE = CType(v_ctrl, RichTextBox).Text
                End If
                mv_arrObjFields(i).FieldValue = v_strFLDVALUE
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub

    Private Sub FillMasterData2Screen()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".FillMasterData2Screen"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE, v_strREFTAGFIELDVALUE, v_strTAGVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex, v_intPos As Integer
        Try
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                'Scan all field in array
                v_tabIndex = mv_arrObjFields(i).TabIndex
                v_panelIndex = mv_arrObjFields(i).GroupIndex
                v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                v_ctrl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)

                'Get the data
                If Me.ExeFlag = ExecuteFlag.Approve Then
                    'Duyệt thì lấy thông tin từ Memo ra
                    If FlagLog <> "NONE" And (Not mv_arrMemoHash Is Nothing) Then
                        If mv_arrMemoHash.ContainsKey(mv_arrObjFields(i).FieldName.Trim) Then
                            v_strFLDVALUE = mv_arrMemoHash(mv_arrObjFields(i).FieldName.Trim)
                        Else
                            v_strFLDVALUE = String.Empty
                        End If
                    End If
                Else
                    'Get the data
                    If mv_arrObjFields(i).FieldValue.Length > 0 Then
                        v_strFLDVALUE = mv_arrObjFields(i).FieldValue.Trim
                    ElseIf mv_arrObjFields(i).DefaultValue.Length > 0 Then
                        v_strFLDVALUE = mv_arrObjFields(i).DefaultValue.Trim
                    Else
                        v_strFLDVALUE = String.Empty
                    End If
                End If

                'Set data 2 control
                If TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).Text = v_strFLDVALUE
                    If mv_arrObjFields(i).DataType = "N" Then
                        FormatNumericTextbox(CType(v_ctrl, TextBox))
                    End If
                ElseIf TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    CType(v_ctrl, FlexMaskEditBox).Text = v_strFLDVALUE
                    If mv_arrObjFields(i).DataType = "N" Then
                        FormatNumericTextbox(CType(v_ctrl, TextBox))
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBox Then
                    CType(v_ctrl, ComboBox).SelectedValue = v_strFLDVALUE
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    CType(v_ctrl, ComboBoxEx).SelectedValue = v_strFLDVALUE
                End If

                'Lay gia tri cua truong tham chieu TAGFIELD
                'TAGVALUE co dang FIELDNAME[FIELDVALUE]
                'Neu FIELDNAME = "" -> truong tham chieu la TAGFIELD, FIELDVALUE lay gia tri cua TAGFIELD
                'Neu khong thi truong tham chieu la FIELDNAME, so sanh FIELDVALUE theo gia tri cua FIELDNAME
                'Gia tri cua truong tham chieu = FIELDVALUE -> enable control
                If mv_arrObjFields(i).TagField.Trim.Length > 0 Then
                    v_intPos = mv_arrObjFields(i).TagValue.Trim.IndexOf("[")
                    If v_intPos = 0 Then
                        v_strREFTAGFIELDVALUE = GetFieldValueByName(mv_arrObjFields(i).TagField)
                        'Chi enabled control neu gia tri hien tai
                        If mv_arrObjFields(i).TagValue.IndexOf("[" & v_strREFTAGFIELDVALUE & "]") >= 0 Then
                            v_ctrl.Enabled = True
                        Else
                            v_ctrl.Enabled = False
                        End If
                    Else
                        v_strREFTAGFIELDVALUE = String.Empty
                    End If

                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub


    Private Sub GetLogMaster(ByVal v_strTableName As String, ByVal v_strRecordKey As String)
        Dim v_strSQL, v_strObjMsg, v_strFLDNAME, v_strDataType, v_strValue As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim i, j, v_count As Integer
        Try
            mv_arrMemoHash = New Hashtable
            v_strSQL = "SELECT ACTION_FLAG FROM APPRVEXEC WHERE STATUS='N' AND TABLE_NAME='" & v_strTableName & "' AND RECORD_KEY='" & v_strRecordKey.Replace("'", "''") & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 1 Then
                'Xác định loại log đang chờ duyệt
                For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACTION_FLAG" Then
                            FlagLog = .InnerText.ToString
                            Exit For
                        End If
                    End With
                Next

                'Lấy dữ liệu từ Memo                
                If String.Compare(TableName, "BSIDTYPE") = 0 Then
                    v_strSQL = "SELECT * FROM AFIDTYPEMEMO WHERE " & v_strRecordKey
                ElseIf String.Compare(TableName, "SRMASTER") = 0 Then
                    v_strSQL = "SELECT * FROM PRMASTERMEMO WHERE " & v_strRecordKey
                ElseIf String.Compare(TableName, "FAACCTMAIN") = 0 Then
                    v_strSQL = "SELECT * FROM CFFEEEXP WHERE " & v_strRecordKey
                Else
                    v_strSQL = "SELECT * FROM " & v_strTableName & "MEMO WHERE " & v_strRecordKey
                End If
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count = 1 Then
                    v_count = UBound(mv_arrObjFields)
                    'Get the Field Value
                    For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                        With v_nodeList.Item(0).ChildNodes(i)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        mv_arrMemoHash.Add(v_strFLDNAME, v_strValue)
                    Next

                    'Remember current value
                    PrepareDataSet(mv_dsMemoInput)
                    'Map into table
                    Dim v_dr As DataRow, v_dc As DataColumn, v_strFldType, v_strFldValue As String
                    v_dr = mv_dsMemoInput.Tables(0).NewRow()
                    v_count = UBound(mv_arrObjFields)
                    For Each v_dc In mv_dsMemoInput.Tables(0).Columns
                        For i = 0 To v_count - 1
                            If mv_arrObjFields(i).SubField.Trim = "Y" Then
                                'Sub field thì dùng ColumnName (FLDMASTER.DEFNAME)
                                If String.Compare(v_dc.ColumnName, mv_arrObjFields(i).ColumnName) = 0 Then
                                    v_strFldType = mv_arrObjFields(i).FieldType
                                    v_strDataType = mv_arrObjFields(i).DataType
                                    v_strFLDNAME = mv_arrObjFields(i).ColumnName
                                    v_strFldValue = mv_arrMemoHash(v_strFLDNAME)
                                    If String.Compare(v_strDataType, "N") = 0 Then
                                        v_dr(v_strFLDNAME) = gf_Cdbl(v_strFldValue.Replace(",", "").Trim)
                                    ElseIf String.Compare(v_strDataType, "D") = 0 Then
                                        v_dr(v_strFLDNAME) = DDMMYYYY_SystemDate(v_strFldValue.Trim)
                                    Else
                                        v_dr(v_strFLDNAME) = v_strFldValue.Trim
                                    End If
                                    If Me.ExeFlag = ExecuteFlag.Approve Then
                                        mv_arrObjFields(i).FieldType = v_strFldValue
                                        mv_arrObjFields(i).DefaultValue = v_strFldValue
                                    End If
                                    Exit For
                                End If
                            Else
                                If String.Compare(v_dc.ColumnName, mv_arrObjFields(i).FieldName) = 0 Then
                                    v_strFldType = mv_arrObjFields(i).FieldType
                                    v_strDataType = mv_arrObjFields(i).DataType
                                    v_strFLDNAME = mv_arrObjFields(i).FieldName
                                    v_strFldValue = mv_arrMemoHash(v_strFLDNAME)
                                    If String.Compare(v_strDataType, "N") = 0 Then
                                        v_dr(v_strFLDNAME) = gf_Cdbl(v_strFldValue.Replace(",", "").Trim)
                                    ElseIf String.Compare(v_strDataType, "D") = 0 Then
                                        v_dr(v_strFLDNAME) = DDMMYYYY_SystemDate(v_strFldValue.Trim)
                                    Else
                                        v_dr(v_strFLDNAME) = v_strFldValue.Trim
                                    End If
                                    If Me.ExeFlag = ExecuteFlag.Approve Then
                                        mv_arrObjFields(i).FieldType = v_strFldValue
                                        mv_arrObjFields(i).DefaultValue = v_strFldValue
                                    End If
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    mv_dsMemoInput.Tables(0).Rows.Add(v_dr)

                Else
                    mv_arrMemoHash = Nothing
                    mv_dsMemoInput = Nothing
                End If
            Else
                FlagLog = "NONE"
                mv_arrMemoHash = Nothing
                mv_dsMemoInput = Nothing
            End If
        Catch ex As Exception

        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try
    End Sub


    Private Sub GetMasterData(Optional ByVal pv_strSearchCodeTab As String = "")
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetMasterData"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strSQL As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_strCmdInquiry, v_strFilter, v_strFLDNAME, v_strDEFNAME, v_strSUBFIELD, v_strValue, v_strFieldType, v_strDataType, v_blnRiskFld As String
        Dim v_strIndicator, v_strGrpType, v_strSearchCode, v_strGroupName As String, v_pnControl, v_gridControl As Control
        Dim v_strObjMsg, v_strObjName, v_strSearchSQL, v_strOrderBy As String
        Dim v_ctrl As Control, v_panel As Panel
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            '=====================================================================================================================
            'Load information for master file (tabGroupType="M")
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            'Check log master
            GetLogMaster(TableName, v_strFilter)

            v_strCmdInquiry = String.Empty
            'Then If pv_strSearchCodeTab.Length <> 0 Then 
            'TruongLD Add 24/08/2017, Xu ly them cho truong hop, view data tu cau SQL trong bang SEARCH
            If String.Compare(TableName, "CFSY02") = 0 Then
                v_strSQL = "SELECT SEARCHCMDSQL FROM SEARCH WHERE SEARCHCODE='" & pv_strSearchCodeTab & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = Trim(.InnerText)
                                Select Case v_strFLDNAME
                                    Case "SEARCHCMDSQL"
                                        v_strCmdInquiry = Trim(v_strValue)
                                        v_strCmdInquiry = v_strCmdInquiry.Replace("<$KEYVAL>", KeyFieldValue)
                                        Exit For
                                End Select
                            End With
                        Next
                    Next
                End If
                'End TruongLD
            Else
                If String.Compare(TableName, "ODMAST") = 0 Then
                    v_strCmdInquiry &= " SELECT * FROM ODMAST WHERE " & v_strFilter
                    v_strCmdInquiry &= " UNION ALL "
                    v_strCmdInquiry &= " SELECT * FROM ODMASTHIST WHERE " & v_strFilter
                ElseIf String.Compare(TableName, "BSIDTYPE") = 0 Then
                    v_strCmdInquiry &= "SELECT * FROM AFIDTYPE WHERE " & v_strFilter
                    'ElseIf String.Compare(TableName, "DFBASKET") = 0 Then
                    '    'Vi gia tham chieu trong bang DFBASKET luon = 0 nen phai re nhanh cho nay de lay tu SECURITIES_INFO
                    '    v_strCmdInquiry &= "SELECT DFB.BASKETID, DFB.SYMBOL, SEIF.BASICPRICE REFPRICE, DFB.DFPRICE, DFB.TRIGGERPRICE, DFB.DFRATE, DFB.IRATE, DFB.MRATE, DFB.LRATE, DFB.CALLTYPE, DFB.IMPORTDT, DFB.AUTOID FROM DFBASKET DFB, (SELECT SYMBOL, BASICPRICE FROM SECURITIES_INFO) SEIF WHERE DFB.SYMBOL = SEIF.SYMBOL AND " & v_strFilter
                ElseIf String.Compare(TableName, "SRMASTER") = 0 Then
                    v_strCmdInquiry &= "SELECT * FROM PRMASTER WHERE " & v_strFilter
                ElseIf String.Compare(TableName, "SYROOM") = 0 Then
                    v_strCmdInquiry &= "select * from (select DISTINCT symbol codeid from prsecmap where status='A' ) where  " & v_strFilter
                ElseIf String.Compare(TableName, "FAACCTMAIN") = 0 Then
                    v_strCmdInquiry &= " SELECT * FROM CFFEEEXP WHERE " & v_strFilter
                ElseIf String.Compare(TableName, "RPTMASTER") = 0 Then
                    v_strCmdInquiry &= " SELECT RPT.*, CASE WHEN FEE.RPTID IS NULL THEN 'N' ELSE 'Y' END FEERPT FROM RPTMASTER RPT, RPTMASTER_FEE FEE WHERE RPT.RPTID = FEE.RPTID(+) AND RPT." & v_strFilter
                Else
                    v_strCmdInquiry &= "SELECT * FROM " & TableName & " WHERE " & v_strFilter
                End If
            End If


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count = 1 Then
                v_count = UBound(mv_arrObjFields)
                'Get the Field Value
                If Not (Me.ExeFlag = ExecuteFlag.Approve And FlagLog <> "NONE") Then    'Nếu Approve và có thông tin từ Memo thì đã lấy trong memo
                    'Get the Field Value
                    For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                        With v_nodeList.Item(0).ChildNodes(i)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With

                        For j = 0 To v_count - 1
                            If mv_arrObjFields(j).SubField.Trim = "Y" Then
                                'Debug.Assert(Not (v_strFLDNAME = "OPTSYMBOL"), "Type parameter is null", j)
                                If mv_arrObjFields(j).ColumnName = Trim(v_strFLDNAME) Then
                                    mv_arrObjFields(j).FieldValue = v_strValue
                                    mv_arrObjFields(j).DefaultValue = v_strValue
                                End If
                            Else
                                If mv_arrObjFields(j).FieldName = Trim(v_strFLDNAME) Then
                                    mv_arrObjFields(j).FieldValue = v_strValue
                                    mv_arrObjFields(j).DefaultValue = v_strValue
                                End If
                            End If
                        Next
                    Next
                End If

                'Get the label description
                For i = 0 To v_count - 1
                    If mv_arrObjFields(i).LookUp = "Y" _
                        And (mv_arrObjFields(i).ControlType.Trim = "T" _
                        Or mv_arrObjFields(i).ControlType.Trim = "M") Then
                        GetFieldLookUpDescByIndex(i)
                    ElseIf mv_arrObjFields(i).SearchCode.Trim.Length > 0 _
                        And (mv_arrObjFields(i).ControlType.Trim = "T" _
                        Or mv_arrObjFields(i).ControlType.Trim = "M") Then
                        GetFieldSearchCodeDescByIndex(i)
                    End If
                Next
            End If
            '=====================================================================================================================

            'Remember current value
            PrepareDataSet(mv_dsOldInput)
            'Map into table
            Dim v_dr As DataRow, v_dc As DataColumn, v_strFldType, v_strFldValue As String
            v_dr = mv_dsOldInput.Tables(0).NewRow()
            v_count = UBound(mv_arrObjFields)
            For Each v_dc In mv_dsOldInput.Tables(0).Columns
                For i = 0 To v_count - 1
                    If mv_arrObjFields(i).SubField.Trim = "Y" Then
                        'Sub field thì dùng ColumnName (FLDMASTER.DEFNAME)
                        If String.Compare(v_dc.ColumnName, mv_arrObjFields(i).ColumnName) = 0 Then
                            v_strFldType = mv_arrObjFields(i).FieldType
                            v_strDataType = mv_arrObjFields(i).DataType
                            v_strFldValue = mv_arrObjFields(i).FieldValue
                            v_strFLDNAME = mv_arrObjFields(i).ColumnName
                            If String.Compare(v_strDataType, "N") = 0 Then
                                v_dr(v_strFLDNAME) = gf_Cdbl(v_strFldValue.Replace(",", "").Trim)
                            ElseIf String.Compare(v_strDataType, "D") = 0 Then
                                v_dr(v_strFLDNAME) = DDMMYYYY_SystemDate(v_strFldValue.Trim)
                            Else
                                v_dr(v_strFLDNAME) = v_strFldValue.Trim
                            End If
                            Exit For
                        End If
                    Else
                        If String.Compare(v_dc.ColumnName, mv_arrObjFields(i).FieldName) = 0 Then
                            v_strFldType = mv_arrObjFields(i).FieldType
                            v_strDataType = mv_arrObjFields(i).DataType
                            v_strFldValue = mv_arrObjFields(i).FieldValue
                            v_strFLDNAME = mv_arrObjFields(i).FieldName
                            If String.Compare(v_strDataType, "N") = 0 Then
                                v_dr(v_strFLDNAME) = gf_Cdbl(v_strFldValue.Replace(",", "").Trim)
                            ElseIf String.Compare(v_strDataType, "D") = 0 Then
                                v_dr(v_strFLDNAME) = DDMMYYYY_SystemDate(v_strFldValue.Trim)
                            Else
                                v_dr(v_strFLDNAME) = v_strFldValue.Trim
                            End If
                            Exit For
                        End If
                    End If
                Next
            Next
            mv_dsOldInput.Tables(0).Rows.Add(v_dr)

        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message & ControlChars.CrLf & v_strSQL, EventLogEntryType.Error)
        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try
    End Sub

    Private Sub LoadDetailData(Optional ByVal pv_strRefeshTab As String = "")
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".LoadDetailData"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strSQL As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_strCmdInquiry, v_strFilter, v_strFLDNAME, v_strValue, v_strFieldType, v_strDataType, v_blnRiskFld As String
        Dim v_strIndicator, v_strGrpType, v_strSearchCode, v_strGroupName As String, v_pnControl, v_gridControl As Control
        Dim v_strObjMsg, v_strObjName, v_strSearchSQL, v_strOrderBy As String
        Dim v_ctrl As Control, v_panel As Panel
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            '=====================================================================================================================
            'Load information for detail file (tabGroupType="G" OR "R")
            If Me.tabMaster.TabPages.Count > 0 Then 'Already tab control
                For i = 0 To Me.tabMaster.TabPages.Count - 1 Step 1
                    v_strIndicator = Me.tabMaster.TabPages(i).Tag
                    v_strGroupName = Me.tabMaster.TabPages(i).Name
                    v_strGrpType = v_strIndicator.Substring(0, 1)
                    v_strSearchCode = v_strIndicator.Substring(2).Replace("]", String.Empty)
                    If v_strGrpType <> "N" And (pv_strRefeshTab.Trim.Length = 0 Or String.Compare(pv_strRefeshTab, v_strGroupName) = 0) Then 'If the tab is not normal
                        'Get schema for subscreen
                        v_strCmdInquiry = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
                        v_strFilter = " UPPER(SEARCHCODE) = '" & v_strSearchCode & "' ORDER BY POSITION"
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strFilter, )
                        v_ws.Message(v_strObjMsg)
                        'Get panel contails grid
                        For Each v_pnControl In Me.tabMaster.TabPages(i).Controls
                            If v_pnControl.Name = "pn" & v_strGroupName Then
                                Exit For
                            End If
                        Next
                        'Create the subscreen and fill data
                        If v_strGrpType = "G" Then
                            For Each v_gridControl In v_pnControl.Controls
                                If (TypeOf (v_gridControl) Is GridEx) Then
                                    'Setup the format of the grid
                                    LoadGridExSchema(CType(v_gridControl, GridEx), v_strObjMsg, v_strObjName, v_strSearchSQL, v_strOrderBy)
                                    If v_strSearchSQL.Trim.Length > 0 Then
                                        v_strSearchSQL = v_strSearchSQL & ControlChars.CrLf & v_strOrderBy
                                        v_strSearchSQL = v_strSearchSQL.Replace("<$KEYVAL>", Me.KeyFieldValue)
                                        v_strSearchSQL = v_strSearchSQL.Replace("<$OBJNAME>", Me.ObjectName)
                                        v_strSearchSQL = v_strSearchSQL.Replace("<$MODCODE>", Me.ModuleCode)
                                        v_strSearchSQL = v_strSearchSQL.Replace("<$PARENTMOD>", Me.ParentModule)
                                        If String.Compare(Me.BranchId, HO_BRID) = 0 And String.Compare(Me.TellerId, ADMIN_ID) = 0 Then
                                            'SuperVisor
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$SUPERID>", "Y")
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$BRID>", "%")
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$TLID>", "%")
                                        Else
                                            'Normal
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$SUPERID>", "N")
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$BRID>", Me.BranchId)
                                            v_strSearchSQL = v_strSearchSQL.Replace("<$TLID>", Me.TellerId)
                                        End If
                                        'FDS_TruongLD Add, 05/04/2016, xu ly song ngu tren form search
                                        If Me.UserLanguage = gc_LANG_ENGLISH Then
                                            v_strSearchSQL = v_strSearchSQL.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                            v_strSearchSQL = v_strSearchSQL.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                                        Else
                                            v_strSearchSQL = v_strSearchSQL.Replace("<@CDCONTENT>", "CDCONTENT")
                                            v_strSearchSQL = v_strSearchSQL.Replace("<@DESCRIPTION>", "DESCRIPTION")
                                        End If
                                        'Filldata to subscreen
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSearchSQL)
                                        v_ws.Message(v_strObjMsg)
                                        FillDataGrid(CType(v_gridControl, GridEx), v_strObjMsg, "")
                                        mv_arrObjGroups(i).KEYFIELD = CType(v_gridControl, GridEx).Tag
                                        mv_arrObjGroups(i).OBJNAME = v_strObjName
                                    End If
                                End If
                            Next
                        ElseIf v_strGrpType = "R" Then
                            'Create the subscreen

                            'Filldata to subscreen

                        End If

                    End If
                Next
            End If
            '=====================================================================================================================
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message & ControlChars.CrLf & v_strSQL, EventLogEntryType.Error)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadGridExSchema(ByVal v_Grid As GridEx, ByVal v_strObjMsg As String, _
        ByRef v_ObjectName As String, ByRef v_SearchSQL As String, ByRef v_OrderBy As String)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".LoadGridExSchema"
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strSQL As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Try
            Dim v_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
            Dim v_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
            Dim v_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
            Dim v_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
            Dim v_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
            Dim v_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
            Dim v_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
            Dim v_arrStFieldDefValue() As String                   'Giá trị mặc định
            Dim v_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
            Dim v_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
            Dim v_arrSrFieldWidth() As Integer                     '?ộ rộng hiển thị trên lưới
            Dim v_arrStFieldMandartory() As String
            Dim v_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
            Dim v_arrStFieldRefCDType() As String                   'Có đa ngôn ngữ không
            Dim v_arrStFieldRefCDName() As String                   'Có đa ngôn ngữ không

            Dim v_strCaption, v_strEnCaption, v_strCmdSql, v_strObjName, v_strFormName, _
                v_strKeyColumn, v_strKeyFieldType, v_strRefColumn, v_strRefFieldType, v_strSrOderByCmd, v_strTLTXCD As String
            Dim v_intSearchNum, v_index, v_count As Integer
            'Get array value
            PrepareSearchParams(UserLanguage, v_strObjMsg, v_strCaption, v_strEnCaption, v_strCmdSql, v_strObjName, v_strFormName, _
                v_arrSrFieldSrch, v_arrSrFieldDisp, v_arrSrFieldType, v_arrSrFieldMask, v_arrStFieldDefValue, _
                v_arrSrFieldOperator, v_arrSrFieldFormat, v_arrSrFieldDisplay, v_arrSrFieldWidth, _
                v_arrSrSQLRef, v_arrStFieldMultiLang, v_arrStFieldMandartory, v_arrStFieldRefCDType, v_arrStFieldRefCDName, _
                v_strKeyColumn, v_strKeyFieldType, v_intSearchNum, v_strRefColumn, v_strRefFieldType, v_strSrOderByCmd, v_strTLTXCD)

            'Create grid format
            v_Grid.DataRows.Clear()
            v_Grid.Columns.Clear()
            If v_intSearchNum > 0 Then
                v_Grid.Tag = v_strKeyColumn 'Keep the key column
                v_ObjectName = v_strObjName
                v_SearchSQL = v_strCmdSql
                v_OrderBy = v_strSrOderByCmd
                For v_index = 1 To v_intSearchNum Step 1
                    'Create field
                    Select Case v_arrSrFieldType(v_index)
                        Case "N"
                            v_Grid.Columns.Add(New Xceed.Grid.Column(v_arrSrFieldSrch(v_index), GetType(Double)))
                            v_Grid.Columns(v_arrSrFieldSrch(v_index)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                        Case "D"
                            v_Grid.Columns.Add(New Xceed.Grid.Column(v_arrSrFieldSrch(v_index), GetType(String)))
                            v_Grid.Columns(v_arrSrFieldSrch(v_index)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                        Case Else
                            v_Grid.Columns.Add(New Xceed.Grid.Column(v_arrSrFieldSrch(v_index), GetType(String)))
                            v_Grid.Columns(v_arrSrFieldSrch(v_index)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                    End Select
                    'v_Grid.Columns(v_arrSrFieldSrch(v_index)).ReadOnly = False
                    v_Grid.Columns(v_arrSrFieldSrch(v_index)).FormatSpecifier = v_arrSrFieldFormat(v_index)
                    v_Grid.Columns(v_arrSrFieldSrch(v_index)).Title = v_arrSrFieldDisp(v_index)
                    v_Grid.Columns(v_arrSrFieldSrch(v_index)).Width = v_arrSrFieldWidth(v_index)
                    v_Grid.Columns(v_arrSrFieldSrch(v_index)).Visible = IIf(String.Compare(v_arrSrFieldDisplay(v_index), "N") <> 0, True, False)
                    AddHandler v_Grid.DataRowTemplate.Cells(v_arrSrFieldSrch(v_index)).DoubleClick, AddressOf Grid_DblClick
                    AddHandler v_Grid.DataRowTemplate.Cells(v_arrSrFieldSrch(v_index)).KeyUp, AddressOf Grid_KeyUp
                Next
            Else
                v_ObjectName = String.Empty
                v_SearchSQL = String.Empty
                v_OrderBy = String.Empty
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message & ControlChars.CrLf & v_strSQL, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_resourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_resourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_resourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            End If
        Next
        Me.Text = mv_resourceManager.GetString("frmMaster")
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".Button_Click"
        Try
            If (sender Is btnOK) Then
                mv_saveButtonType = SaveButtonType.OKButton
                OnSave()
            ElseIf (sender Is btnApply) Then
                mv_saveButtonType = SaveButtonType.ApplyButton
                OnSave()
            ElseIf (sender Is btnCancel) Then
                mv_saveButtonType = SaveButtonType.CancelButton
                OnClose()
            ElseIf (sender Is btnExternal) Then
                mv_saveButtonType = SaveButtonType.ExternalButton
                OnExternalField()
            ElseIf (sender Is btnNavigate) Then
                mv_saveButtonType = SaveButtonType.NavigateButton
                OnNavigate()
            ElseIf (sender Is btnReject) Then
                mv_saveButtonType = SaveButtonType.RejectButton
                OnReject()
            ElseIf (sender Is btnApprove) Then
                mv_saveButtonType = SaveButtonType.ApproveButton
                OnApprove()
            Else
                Dim v_ctrl As Control = CType(sender, Control), v_idx As Integer
                Dim v_strModuleCode, v_strTableName, v_strObjName, v_strObjTitle, v_strKeyField, v_strKeyValue, v_strParentValue As String
                Dim v_panel As Panel, v_grid As GridEx, v_ctl As Control
                Dim v_fldIndex, v_tabIndex, v_panelIndex, v_gridIndex, v_intExecFlag As Integer, v_strAutoValue, v_strInvName, v_strInvFormat As String
                If v_ctrl.Name.IndexOf(PREFIXED_BTNDATA) <> -1 Then
                    'AutoGenerate value
                    v_fldIndex = CType(sender, Control).Tag
                    If Not mv_arrObjFields(v_fldIndex) Is Nothing Then
                        v_strInvName = mv_arrObjFields(v_fldIndex).InvName
                        v_strInvFormat = mv_arrObjFields(v_fldIndex).InvFormat
                        v_strAutoValue = GetInventoryValue(v_strInvName, v_strInvFormat)
                        v_tabIndex = mv_arrObjFields(v_fldIndex).TabIndex
                        v_panelIndex = mv_arrObjFields(v_fldIndex).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(v_fldIndex).ControlIndex)
                        v_ctl.Text = v_strAutoValue
                    End If
                ElseIf v_ctrl.Name.IndexOf(PREFIXED_BTNTABPAGE) <> -1 Then
                    v_idx = v_ctrl.Tag
                    If IsNumeric(v_idx) Then
                        'AnhVT Added for approval
                        Dim v_strParentClause As String
                        Select Case KeyFieldType
                            Case "C"
                                v_strParentClause = KeyFieldName & " = '" & GetControlValueByName(KeyFieldName) & "'"
                            Case "D"
                                v_strParentClause = KeyFieldName & " = TO_DATE('" & GetControlValueByName(KeyFieldName) & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strParentClause = KeyFieldName & " = " & GetControlValueByName(KeyFieldName).ToString()
                        End Select
                        'AnhVT Added for ended

                        If Not mv_arrObjGroups(v_idx) Is Nothing Then
                            If mv_arrObjGroups(v_idx).GRTYPE = "G" Then
                                'Get information
                                v_panelIndex = mv_arrObjGroups(v_idx).PANELIDX
                                v_gridIndex = mv_arrObjGroups(v_idx).GRIDIDX
                                v_panel = Me.tabMaster.TabPages(v_idx).Controls(v_panelIndex)
                                v_grid = v_panel.Controls(v_gridIndex)
                                v_strParentValue = Me.KeyFieldValue
                                v_strKeyField = v_grid.Tag
                                v_strObjName = mv_arrObjGroups(v_idx).OBJNAME
                                If v_strObjName.IndexOf(".") > 0 Then
                                    v_strModuleCode = v_strObjName.Substring(0, v_strObjName.IndexOf("."))
                                    v_strTableName = v_strObjName.Substring(v_strObjName.IndexOf(".") + 1)
                                Else
                                    v_strModuleCode = Me.ModuleCode
                                    v_strTableName = v_strObjName
                                End If
                                'Execute button
                                If v_ctrl.Name.IndexOf("_Reresh") <> -1 Then
                                    'Refresh
                                ElseIf v_ctrl.Name.IndexOf("_Insert") <> -1 Then
                                    'Insert
                                    v_intExecFlag = ExecuteFlag.AddNew
                                    v_strKeyValue = String.Empty
                                    Select Case v_strTableName
                                        Case "ODPROBRKAF"
                                            Dim frmSearch As New frmSearch(mv_strLanguage)
                                            frmSearch.BusDate = Me.BusDate
                                            frmSearch.TableName = "ODFEEBRK"
                                            frmSearch.ModuleCode = Me.ModuleCode
                                            '     frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                                            frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                                            'frmSearch.AuthCode = frm.AuthCode
                                            frmSearch.CMDTYPE = "V"
                                            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                                            frmSearch.SearchOnInit = False
                                            frmSearch.BranchId = Me.BranchId
                                            frmSearch.TellerId = Me.TellerId
                                            frmSearch.LinkValue = v_strParentValue
                                            frmSearch.ShowDialog()
                                            LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
                                        Case Else
                                            Dim v_frm As New frmMaster(v_strTableName, v_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                                                Me.tabMaster.TabPages(v_idx).Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                                                KeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields, v_strParentClause)
                                            Dim frmResult As DialogResult = v_frm.ShowDialog()
                                            LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
                                    End Select

                                ElseIf v_ctrl.Name.IndexOf("_Edit") <> -1 Then
                                    'Edit
                                    v_strKeyValue = Trim(CType(v_grid.CurrentRow, Xceed.Grid.DataRow).Cells(v_strKeyField).Value)
                                    v_intExecFlag = ExecuteFlag.Edit
                                    Dim v_frm As New frmMaster(v_strTableName, v_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                                                Me.tabMaster.TabPages(v_idx).Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                                                KeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields, v_strParentClause)
                                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                                    LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
                                ElseIf v_ctrl.Name.IndexOf("_Delete") <> -1 Then
                                    'Delete
                                    'v_strKeyValue = Trim(CType(v_grid.CurrentRow, Xceed.Grid.DataRow).Cells(v_strKeyField).Value)
                                    'OnDeleteDetail(v_strKeyField, v_strKeyValue, v_strObjName)
                                    'LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)

                                    'Chinh sua thanh cho phep xoa nhieu dong du lieu mot luc
                                    If MsgBox(mv_resourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                                        For i As Integer = 0 To v_grid.DataRows.Count - 1 Step 1
                                            If v_grid.SelectedRows.Contains(v_grid.DataRows(i)) Then
                                                v_strKeyValue = Trim(CType(v_grid.DataRows(i), Xceed.Grid.DataRow).Cells(v_strKeyField).Value)
                                                OnDeleteDetail(v_strKeyField, v_strKeyValue, v_strObjName, Me.ObjectName, v_strParentClause)
                                            End If
                                        Next
                                        LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
                                    End If
                                ElseIf v_ctrl.Name.IndexOf("_View") <> -1 Then
                                    'View
                                    v_intExecFlag = ExecuteFlag.View
                                    v_strKeyValue = Trim(CType(v_grid.CurrentRow, Xceed.Grid.DataRow).Cells(v_strKeyField).Value)
                                    Dim v_frm As New frmMaster(v_strTableName, v_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                                                Me.tabMaster.TabPages(v_idx).Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                                                KeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields, v_strParentClause)
                                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                                ElseIf v_ctrl.Name.IndexOf("_First") <> -1 Then
                                    'First
                                ElseIf v_ctrl.Name.IndexOf("_Previous") <> -1 Then
                                    'Previous
                                ElseIf v_ctrl.Name.IndexOf("_Next") <> -1 Then
                                    'Next
                                ElseIf v_ctrl.Name.IndexOf("_Last") <> -1 Then
                                    'Last
                                ElseIf v_ctrl.Name.IndexOf("_Export") <> -1 Then
                                    'Export
                                    OnExport(v_grid)
                                    'End FDS DieuNDA
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub GetControlValue(ByRef pv_dr As DataRow, _
                                ByVal pv_ds As DataSet, _
                                ByVal pv_ctrl As Windows.Forms.Control)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetControlValue"
        Dim v_dc As DataColumn
        Dim v_ctrl, v_ctrTabPage As Windows.Forms.Control
        Dim v_strFldType, v_strDataType As String
        Try
            For Each v_ctrl In pv_ctrl.Controls
                If (TypeOf (v_ctrl) Is TabControl) Then
                    For Each v_ctrTabPage In CType(v_ctrl, TabControl).TabPages
                        GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
                    Next
                ElseIf (TypeOf (v_ctrl) Is TabPage) Then
                    GetControlValue(pv_dr, pv_ds, v_ctrl)
                Else
                    For Each v_dc In pv_ds.Tables(0).Columns
                        If (TypeOf (v_ctrl) Is TextBox) Then
                            If UCase(v_dc.ColumnName) = UCase(v_ctrl.Tag) Then
                                For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                    If (UCase(v_ctrl.Tag) = mv_arrObjFields(i).FieldName) Then
                                        v_strFldType = mv_arrObjFields(i).FieldType
                                        v_strDataType = mv_arrObjFields(i).DataType
                                        Exit For
                                    End If
                                Next
                                If (v_strFldType = "T") And (v_strDataType = "N") Then
                                    If Trim(CType(v_ctrl, TextBox).Text) = "" Then
                                        pv_dr(CType(v_ctrl, TextBox).Tag) = "0"
                                    Else
                                        pv_dr(CType(v_ctrl, TextBox).Tag) = Trim(CType(v_ctrl, TextBox).Text)
                                    End If
                                ElseIf (v_strFldType = "T") And (v_strDataType <> "N") Then
                                    pv_dr(CType(v_ctrl, TextBox).Tag) = Trim(CType(v_ctrl, TextBox).Text)
                                ElseIf (v_strFldType = "M") And (v_strDataType = "N") Then
                                    pv_dr(CType(v_ctrl, FlexMaskEditBox).Tag) = Replace(CType(v_ctrl, FlexMaskEditBox).Text, ",", "").Trim()
                                ElseIf (v_strFldType = "M") Then
                                    pv_dr(CType(v_ctrl, FlexMaskEditBox).Tag) = CType(v_ctrl, FlexMaskEditBox).Text.Trim()
                                End If
                                Exit For
                            End If
                        ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                            If UCase(v_dc.ColumnName) = UCase(v_ctrl.Tag) Then
                                pv_dr(CType(v_ctrl, FlexMaskEditBox).Tag) = Trim(CType(v_ctrl, FlexMaskEditBox).Text)
                                Exit For
                            End If
                        ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then
                            If UCase(v_dc.ColumnName) = UCase(v_ctrl.Tag) Then
                                If CType(v_ctrl, DateTimePicker).Checked Then
                                    pv_dr(CType(v_ctrl, DateTimePicker).Tag) = Trim(CStr(CType(v_ctrl, DateTimePicker).Value))
                                Else
                                    pv_dr(CType(v_ctrl, DateTimePicker).Tag) = CDate(gc_NULL_DATE)
                                End If
                                Exit For
                            End If
                        ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                            If UCase(v_dc.ColumnName) = UCase(v_ctrl.Tag) Then
                                pv_dr(CType(v_ctrl, ComboBoxEx).Tag) = Trim(CType(v_ctrl, ComboBoxEx).SelectedValue)
                                Exit For
                            End If

                        ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                            If UCase(v_dc.ColumnName) = UCase(v_ctrl.Tag) Then
                                pv_dr(CType(v_ctrl, PictureBox).Tag) = GetStringFromImage(CType(v_ctrl, PictureBox))
                                Exit For
                            End If
                        ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                            GetControlValue(pv_dr, pv_ds, v_ctrl)
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & "-" & pv_ctrl.Name & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub PrepareDataSet(ByRef pv_ds As DataSet)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".PrepareDataSet"
        Dim v_dc As DataColumn, v_strFIELDNAME As String
        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If

            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add(TableName)

            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                ''Chi cap nhat nhung truong duoc danh dau
                If String.Compare(mv_arrObjFields(i).TagUpdate, "Y") = 0 Then
                    If mv_arrObjFields(i).SubField = "Y" Then
                        v_strFIELDNAME = mv_arrObjFields(i).ColumnName
                    Else
                        v_strFIELDNAME = mv_arrObjFields(i).FieldName
                    End If
                    'Check đã có field trong dataset chưa
                    If Not pv_ds.Tables(0).Columns.Contains(v_strFIELDNAME.Trim) Then
                        v_dc = New DataColumn(v_strFIELDNAME)
                        Select Case mv_arrObjFields(i).DataType
                            Case "C"
                                v_dc.DataType = GetType(String)
                            Case "D"
                                v_dc.DataType = GetType(System.DateTime)
                            Case "N"
                                v_dc.DataType = GetType(Double)
                            Case Else
                                v_dc.DataType = GetType(String)
                        End Select
                        pv_ds.Tables(0).Columns.Add(v_dc)
                    End If
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngError.ToString & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".DoDataExchange"
        Dim v_dr As DataRow, v_dc As DataColumn, i, v_count, v_tabIndex, v_panelIndex As Integer
        Dim v_ctl As Control, v_panel As Panel
        Dim v_strFldName, v_strFldType, v_strFldValue, v_strDataType As String
        Dim v_bln As Boolean
        Try
            If pv_blnSaved Then
                'Capture data from the screen
                CaptureMasterDataFromScreen()
                PrepareDataSet(mv_dsInput)
                'Map into table
                v_dr = mv_dsInput.Tables(0).NewRow()
                v_count = UBound(mv_arrObjFields)
                For Each v_dc In mv_dsInput.Tables(0).Columns
                    For i = 0 To v_count - 1
                        v_tabIndex = mv_arrObjFields(i).TabIndex
                        v_panelIndex = mv_arrObjFields(i).GroupIndex
                        v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                        v_ctl = v_panel.Controls(mv_arrObjFields(i).ControlIndex)

                        'Nếu là SubField thì control phải ở trạng thái Visible mới được nạp -> Chinh lai: PDefValue || ColumnName = FieldName
                        If (mv_arrObjFields(i).SubField = "Y" And String.Compare(GetFieldValueByName(mv_arrObjFields(i).PDefName) & mv_arrObjFields(i).ColumnName, mv_arrObjFields(i).FieldName) = 0 And _
                                         String.Compare(v_dc.ColumnName, mv_arrObjFields(i).ColumnName) = 0) Or _
                            (mv_arrObjFields(i).SubField <> "Y" And String.Compare(v_dc.ColumnName, mv_arrObjFields(i).FieldName) = 0) Then
                            v_strFldType = mv_arrObjFields(i).FieldType
                            v_strDataType = mv_arrObjFields(i).DataType
                            v_strFldValue = mv_arrObjFields(i).FieldValue
                            v_strFldValue = IIf(v_strFldValue Is Nothing, "", v_strFldValue)
                            If mv_arrObjFields(i).SubField = "Y" Then
                                v_strFldName = mv_arrObjFields(i).ColumnName
                            Else
                                v_strFldName = mv_arrObjFields(i).FieldName
                            End If

                            'Binhpt kiem tra xem combobox co duoc chon gia tri ko
                            If mv_arrObjFields(i).Mandatory And (TypeOf (v_ctl) Is ComboBox) And mv_arrObjFields(i).Visible And v_strFldValue Is Nothing Then
                                If Me.UserLanguage = "EN" Then
                                    MsgBox(Replace(ResourceManager.GetString("ERR_COMBOBOX_SELECTVALUE"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Else
                                    MsgBox(Replace(ResourceManager.GetString("ERR_COMBOBOX_SELECTVALUE"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                End If
                                Return False
                            End If
                            'End Binhpt
                            If mv_arrObjFields(i).Mandatory And mv_arrObjFields(i).Visible And v_strFldValue.Trim.Length = 0 Then  'And mv_arrObjFields(i).Enabled
                                If Me.UserLanguage = "EN" Then
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Else
                                    MsgBox(Replace(ResourceManager.GetString("ERR_MANDATORY_FIELD"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                End If
                                Return False
                            End If
                            If String.Compare(v_strDataType, "N") = 0 Then
                                v_dr(v_strFldName) = gf_Cdbl(v_strFldValue.Replace(",", "").Trim)
                            ElseIf String.Compare(v_strDataType, "D") = 0 Then
                                If v_strFldValue.Trim.Length = 0 Then
                                    'v_dr(v_strFldName) = DDMMYYYY_SystemDate(Me.BusDate)
                                    v_dr(v_strFldName) = DDMMYYYY_SystemDate("")
                                ElseIf v_strFldValue = "  /  /" Then
                                    v_dr(v_strFldName) = DDMMYYYY_SystemDate("")
                                Else
                                    v_dr(v_strFldName) = DDMMYYYY_SystemDate(v_strFldValue.Trim)
                                End If
                            Else
                                v_dr(v_strFldName) = v_strFldValue.Trim
                            End If
                            Exit For

                        End If
                    Next
                Next
                mv_dsInput.Tables(0).Rows.Add(v_dr)
            Else
                'Fill data to the screen
                FillMasterData2Screen()
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ControlChars.CrLf & i & ControlChars.Tab & v_strFldName)
            Return False
        End Try
    End Function

    Private Sub ShowScreenByStatus()

    End Sub

    Private Sub DoFillReturnValue(ByVal v_strGLGRP As String, ByVal v_strModCode As String, ByVal v_ctrlAccountEntries As System.Windows.Forms.ListView, Optional ByVal v_strCurrency As String = "")
        Dim v_strObjMsg, v_strCurrencyTem As String
        Dim v_strCmdInquiry As String
        Try
            v_strCurrencyTem = v_strCurrency
            v_strCmdInquiry = "SELECT ACNAME ,ACCTNO FROM GLREF WHERE APPTYPE='" & v_strModCode & "' AND GLGRP ='" & v_strGLGRP & "' ORDER BY ACNAME "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry, )
            Dim v_strOldObjMsg As String = v_strObjMsg
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument
            v_xmlDocument.LoadXml(v_strObjMsg)

            'Hien thi header
            v_ctrlAccountEntries.Clear()

            Dim v_ACNAME As New System.Windows.Forms.ColumnHeader
            v_ACNAME.Text = "ACNAME"
            v_ACNAME.Width = 80
            'v_ColReport.Text.
            v_ctrlAccountEntries.Columns.Add(v_ACNAME)

            Dim v_ACCTNO As New System.Windows.Forms.ColumnHeader
            v_ACCTNO.Text = "ACCTNO"
            v_ACCTNO.Width = 120
            v_ctrlAccountEntries.Columns.Add(v_ACCTNO)

            'Hien thi du lieu
            Dim v_ListViewItem As ListViewItem
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strAcc, v_strAccName, v_strTem As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_arrStr(2) As String
            v_ctrlAccountEntries.Items.Clear()
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_ctrlAccountEntries.Items.Clear()
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = vbNullString
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ACNAME"
                                v_strAccName = v_strValue
                            Case "ACCTNO"
                                v_strAcc = v_strValue
                                If i = 0 Then
                                    v_strCurrency = Strings.Mid(v_strAcc, 5, 2)
                                End If
                            Case Else
                        End Select
                    End With
                Next

                'Fill du lieu vao grid
                If v_strCurrencyTem <> "" Then
                    If Strings.Mid(v_strAcc, 5, 2) = v_strCurrencyTem Then
                        v_arrStr(0) = v_strAccName
                        v_arrStr(1) = v_strAcc
                        v_ListViewItem = New ListViewItem(v_arrStr)
                        v_ctrlAccountEntries.Items.Add(v_ListViewItem)
                    End If
                Else
                    v_arrStr(0) = v_strAccName
                    v_arrStr(1) = v_strAcc
                    v_ListViewItem = New ListViewItem(v_arrStr)
                    v_ctrlAccountEntries.Items.Add(v_ListViewItem)
                End If
            Next
        Catch ex As Exception
            v_ctrlAccountEntries.Visible = True
        End Try
    End Sub

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

#Region " Overriable functions "

    Public Overridable Sub OnSave()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".OnSave"
        Dim v_strObjMsg, v_strClause, v_strAutoIDRef, v_strErrorMessage, v_strInfoMessage, v_strWarningMessage As String, v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        Try
            If FlagLog <> "NONE" Then
                'Không cho phép Save
                If MsgBox(mv_resourceManager.GetString("ERR_INVALID_STATUS_01"), _
                    MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
                Return
            End If

            If VerifyRules() Then
                If Not DoDataExchange(True) Then Exit Sub 'Get data from the screen to record set
                Select Case ExeFlag
                    Case ExecuteFlag.AddNew
                        'Build Object.Edit
                        Select Case KeyFieldType
                            Case "C"
                                v_strClause = KeyFieldName & " = '" & GetControlValueByName(KeyFieldName) & "'"
                            Case "D"
                                v_strClause = KeyFieldName & " = TO_DATE('" & GetControlValueByName(KeyFieldName) & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = KeyFieldName & " = " & GetControlValueByName(KeyFieldName).ToString()
                        End Select

                        'Build Object.Add
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , v_strClause, , Me.ObjAutoID, , , , , , ParentObject, ParentClause)
                        BuildXMLObjData(mv_dsInput, v_strObjMsg)

                        ' PhuongHT add : canh bao khi trung catype,actiondate,codeid
                        If (ObjectName = "CA.CAMAST") Then
                            Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                            Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strReportdate, v_strCatype, v_strCodeid, v_strCamastid As String
                            Dim v_dblCount As Double

                            If v_strObjMsg.Length > 0 Then
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strVALUE = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "CODEID"
                                                    v_strCodeid = v_strVALUE
                                                Case "REPORTDATE"
                                                    v_strReportdate = v_strVALUE
                                                Case "CATYPE"
                                                    v_strCatype = v_strVALUE
                                                Case "CAMASTID"
                                                    v_strCamastid = v_strVALUE
                                            End Select
                                        End With
                                    Next
                                Next
                            End If
                            v_strSQL = "SELECT COUNT(*) COUNT FROM CAMAST WHERE  DELTD ='N' AND CATYPE ='" & v_strCatype & "' AND " & " REPORTDATE =TO_DATE('" & v_strReportdate & "','" & gc_FORMAT_DATE & "')" _
                                       & " AND CODEID ='" & v_strCodeid & "' AND CAMASTID <> '" & v_strCamastid & "'"
                            Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg_2)
                            If v_strObjMsg_2.Length > 0 Then
                                v_xmlDocument.LoadXml(v_strObjMsg_2)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strVALUE = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "COUNT"
                                                    v_dblCount = v_strVALUE
                                            End Select
                                        End With
                                    Next
                                Next
                            End If
                            If (v_dblCount > 0) Then
                                If MsgBox(mv_resourceManager.GetString("ERR_INVALID_STATUS_02"), MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If
                            End If
                        End If
                        ' end of PhuongHT add : canh bao khi trung catype,actiondate,codeid

                        'AnTB add 14/02/2015: canh bao khi chuyen khoan ra ngoai ma thong tin nguoi nhan khac thong tin nguoi chuyen
                        If (ObjectName = "CF.CFOTHERACC") Then
                            Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                            Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strTYPE, v_strCFCUSTID, v_strIDCODE, v_strIDDATE, v_strIDPLACE As String
                            Dim v_strCUSTID, v_strACNIDCODE, v_strACNIDDATE, v_strACNIDPLACE As String
                            Dim v_strBANKACC, v_strBANKCODE As String
                            Dim v_dblCount As Double

                            If v_strObjMsg.Length > 0 Then
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strVALUE = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "TYPE"
                                                    v_strTYPE = v_strVALUE
                                                Case "CFCUSTID"
                                                    v_strCFCUSTID = v_strVALUE
                                                Case "IDCODE"
                                                    v_strIDCODE = v_strVALUE
                                                Case "IDDATE"
                                                    v_strIDDATE = v_strVALUE
                                                Case "IDPLACE"
                                                    v_strIDPLACE = v_strVALUE
                                                Case "CUSTID"
                                                    v_strCUSTID = v_strVALUE
                                                Case "ACNIDCODE"
                                                    v_strACNIDCODE = v_strVALUE
                                                Case "ACNIDDATE"
                                                    v_strACNIDDATE = v_strVALUE
                                                Case "ACNIDPLACE"
                                                    v_strIDPLACE = v_strVALUE
                                                Case "BANKACC"
                                                    v_strBANKACC = v_strVALUE
                                            End Select
                                        End With
                                    Next
                                Next
                            End If

                            If (v_strTYPE = "1" And (UCase(Trim(v_strCFCUSTID)) <> UCase(Trim(v_strCUSTID)) Or UCase(Trim(v_strIDCODE)) <> UCase(Trim(v_strACNIDCODE)) Or _
                                UCase(Trim(v_strIDDATE)) <> UCase(Trim(v_strACNIDDATE)))) Then
                                If MsgBox(mv_resourceManager.GetString("ERR_CFOTHERACC_DIFFERENCE_INFO"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If
                            End If
                            'AnTB add 01/03/2015: canh bao khi NH chuyen tien khong phai NH lien ket
                            v_strSQL = "SELECT COUNT(*) COUNT FROM VW_AFMAST_CUSTODYCD WHERE  BANKACCTNO like '" & v_strBANKACC & "'"
                            Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg_2)
                            If v_strObjMsg_2.Length > 0 Then
                                v_xmlDocument.LoadXml(v_strObjMsg_2)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strVALUE = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "COUNT"
                                                    v_dblCount = v_strVALUE
                                            End Select
                                        End With
                                    Next
                                Next
                            End If
                            If (v_strTYPE = "1" And v_dblCount = 0) Then
                                If MsgBox(mv_resourceManager.GetString("ERR_CFOTHERACC_BANKACC_NOT_LINK"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If
                            End If
                            'AnTB add 01/03/2015: canh bao khi NH chuyen tien khong phai NH lien ket
                        End If
                        'AnTB add 14/02/2015: canh bao khi chuyen khoan ra ngoai ma thong tin nguoi nhan khac thong tin nguoi chuyen

                        v_lngError = v_ws.Message(v_strObjMsg)

                        'Get error description
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                        MsgBox(Replace(ResourceManager.GetString("AddSuccess"), "@", Me.Text), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        'Refresh to screen
                        Select Case Me.attrSaveButtonType
                            Case SaveButtonType.ApplyButton
                                If Me.KeyFieldName = "AUTOID" And Me.ObjAutoID = "Y" Then
                                    Dim v_xmlDocRef As New XmlDocumentEx
                                    v_xmlDocRef.LoadXml(v_strObjMsg)
                                    Dim v_attrCollRef As Xml.XmlAttributeCollection = v_xmlDocRef.DocumentElement.Attributes
                                    If Not (v_attrCollRef.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                                        v_strAutoIDRef = CStr(CType(v_attrCollRef.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
                                    Else
                                        v_strAutoIDRef = String.Empty
                                    End If

                                    KeyFieldValue = v_strAutoIDRef
                                Else
                                    KeyFieldValue = GetControlValueByName(KeyFieldName)
                                End If
                                ExeFlag = ExecuteFlag.Edit
                                'Change the screen to edit mode
                                ShowScreenBasedOnActionFlag()
                                mv_dsOldInput = mv_dsInput
                            Case SaveButtonType.OKButton
                                Me.DialogResult = DialogResult.OK
                                OnClose()
                        End Select
                    Case ExecuteFlag.Edit
                        'Build Object.Edit
                        Select Case KeyFieldType
                            Case "C"
                                v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                            Case "D"
                                v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                        End Select
                        If ObjectName = "SA.RPTMASTER" Then
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, gc_ActionEdit, , , , , , , ParentObject, ParentClause)
                            BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                            v_lngError = v_ws.Message(v_strObjMsg)

                            'Get error description
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Update mouse pointer
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                            MsgBox(Replace(ResourceManager.GetString("EditSuccess"), "@", Me.Text), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            'Refresh to screen
                            If Me.attrSaveButtonType = SaveButtonType.ApplyButton Then
                                ShowScreenBasedOnActionFlag()
                            ElseIf Me.attrSaveButtonType = SaveButtonType.OKButton Then
                                OnClose()
                            End If

                        Else

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObject, ParentClause)
                            BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                            ' PhuongHT add : canh bao khi trung catype,actiondate,codeid
                            If (ObjectName = "CA.CAMAST") Then
                                Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                                Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strReportdate, v_strCatype, v_strCodeid, v_strCamastid As String
                                Dim v_dblCount As Double

                                If v_strObjMsg.Length > 0 Then
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strVALUE = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "CODEID"
                                                        v_strCodeid = v_strVALUE
                                                    Case "REPORTDATE"
                                                        v_strReportdate = v_strVALUE
                                                    Case "CATYPE"
                                                        v_strCatype = v_strVALUE
                                                    Case "CAMASTID"
                                                        v_strCamastid = v_strVALUE
                                                End Select
                                            End With
                                        Next
                                    Next
                                End If
                                v_strSQL = "SELECT COUNT(*) COUNT FROM CAMAST WHERE  DELTD ='N' AND CATYPE ='" & v_strCatype & "' AND " & " REPORTDATE =TO_DATE('" & v_strReportdate & "','" & gc_FORMAT_DATE & "')" _
                                           & " AND CODEID ='" & v_strCodeid & "' AND CAMASTID <> '" & v_strCamastid & "'"
                                Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                                v_ws.Message(v_strObjMsg_2)
                                If v_strObjMsg_2.Length > 0 Then
                                    v_xmlDocument.LoadXml(v_strObjMsg_2)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strVALUE = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "COUNT"
                                                        v_dblCount = v_strVALUE
                                                End Select
                                            End With
                                        Next
                                    Next
                                End If
                                If (v_dblCount > 0) Then
                                    If MsgBox(mv_resourceManager.GetString("ERR_INVALID_STATUS_02"), MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                        Exit Sub
                                    End If
                                End If
                            End If
                            ' end of PhuongHT add : canh bao khi trung catype,actiondate,codeid

                            'AnTB add 14/02/2015: canh bao khi chuyen khoan ra ngoai ma thong tin nguoi nhan khac thong tin nguoi chuyen
                            If (ObjectName = "CF.CFOTHERACC") Then
                                Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                                Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strTYPE, v_strCFCUSTID, v_strIDCODE, v_strIDDATE, v_strIDPLACE As String
                                Dim v_strCUSTID, v_strACNIDCODE, v_strACNIDDATE, v_strACNIDPLACE As String
                                Dim v_strBANKACC, v_strBANKCODE As String
                                Dim v_dblCount As Double

                                If v_strObjMsg.Length > 0 Then
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strVALUE = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "TYPE"
                                                        v_strTYPE = v_strVALUE
                                                    Case "CFCUSTID"
                                                        v_strCFCUSTID = v_strVALUE
                                                    Case "IDCODE"
                                                        v_strIDCODE = v_strVALUE
                                                    Case "IDDATE"
                                                        v_strIDDATE = v_strVALUE
                                                    Case "IDPLACE"
                                                        v_strIDPLACE = v_strVALUE
                                                    Case "CUSTID"
                                                        v_strCUSTID = v_strVALUE
                                                    Case "ACNIDCODE"
                                                        v_strACNIDCODE = v_strVALUE
                                                    Case "ACNIDDATE"
                                                        v_strACNIDDATE = v_strVALUE
                                                    Case "ACNIDPLACE"
                                                        v_strIDPLACE = v_strVALUE
                                                    Case "BANKACC"
                                                        v_strBANKACC = v_strVALUE
                                                End Select
                                            End With
                                        Next
                                    Next
                                End If

                                If (v_strTYPE = "1" And (UCase(Trim(v_strCFCUSTID)) <> UCase(Trim(v_strCUSTID)) Or UCase(Trim(v_strIDCODE)) <> UCase(Trim(v_strACNIDCODE)) Or _
                                    UCase(Trim(v_strIDDATE)) <> UCase(Trim(v_strACNIDDATE)))) Then
                                    If MsgBox(mv_resourceManager.GetString("ERR_CFOTHERACC_DIFFERENCE_INFO"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                        Exit Sub
                                    End If
                                End If
                                'AnTB add 01/03/2015: canh bao khi NH chuyen tien khong phai NH lien ket
                                v_strSQL = "SELECT COUNT(*) COUNT FROM VW_AFMAST_CUSTODYCD WHERE  BANKACCTNO like '" & v_strBANKACC & "'"
                                Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
                                v_ws.Message(v_strObjMsg_2)
                                If v_strObjMsg_2.Length > 0 Then
                                    v_xmlDocument.LoadXml(v_strObjMsg_2)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strVALUE = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "COUNT"
                                                        v_dblCount = v_strVALUE
                                                End Select
                                            End With
                                        Next
                                    Next
                                End If
                                If (v_strTYPE = "1" And v_dblCount = 0) Then
                                    If MsgBox(mv_resourceManager.GetString("ERR_CFOTHERACC_BANKACC_NOT_LINK"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                                        Exit Sub
                                    End If
                                End If
                                'AnTB add 01/03/2015: canh bao khi NH chuyen tien khong phai NH lien ket
                            End If
                            'AnTB add 14/02/2015: canh bao khi chuyen khoan ra ngoai ma thong tin nguoi nhan khac thong tin nguoi chuyen


                            v_lngError = v_ws.Message(v_strObjMsg)

                            'Get error description
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Update mouse pointer
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                            MsgBox(Replace(ResourceManager.GetString("EditSuccess"), "@", Me.Text), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            'Refresh to screen
                            If Me.attrSaveButtonType = SaveButtonType.ApplyButton Then
                                ShowScreenBasedOnActionFlag()
                            ElseIf Me.attrSaveButtonType = SaveButtonType.OKButton Then
                                OnClose()
                            End If
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub OnReject()

    End Sub

    Public Overridable Sub OnApprove()

    End Sub

    Public Overridable Sub OnNavigate()

    End Sub

    Public Overridable Sub OnExternalField()

    End Sub

    Public Overridable Sub OnDeleteDetail(ByVal v_strKeyFieldName As String, ByVal v_strKeyFieldValue As String, ByVal v_strModule As String, ByVal v_ParentObjName As String, ByVal v_ParentClause As String)
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".OnDeleteDetail"
        Dim v_strObjMsg, v_strClause, v_strErrorMessage As String, v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")
            Select Case KeyFieldType
                Case "D"
                    v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                Case "C"
                    v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
            End Select
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, v_strModule, gc_ActionDelete, , v_strClause, , , , , , , , v_ParentObjName, v_ParentClause)
            v_ws.Message(v_strObjMsg)
            'Xu ly thong tin tra ve
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
            If v_lngError <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                'Else
                'MsgBox(Replace(ResourceManager.GetString("DeleteSuccess"), "@", Me.Text), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub OnClose()
        If (attrSaveButtonType = SaveButtonType.OKButton) Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Public Overridable Sub OnInit()
        If (DesignMode) Then
            Return
        End If
        'Create control on the screen
        LoadTabPageControl()
        'Load data to sub grid detail
        LoadDetailData()
        DisplayButton()
        'Show the screen based on status
        ShowScreenBasedOnActionFlag()

        'GianhVG add them code xu ly khi them moi. 
        'Nhung truong gia tri Lookup va Search ma co default gia tri thi lay ra Dien giai cho gia tri do luon.
        If Me.ExeFlag = ExecuteFlag.AddNew Then
            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                If Not mv_arrObjFields(i).FieldValue Is Nothing Then
                    If mv_arrObjFields(i).LookUp = "Y" _
                    And (mv_arrObjFields(i).ControlType.Trim = "T" _
                    Or mv_arrObjFields(i).ControlType.Trim = "M") And mv_arrObjFields(i).FieldValue.Length > 0 Then
                        GetFieldLookUpDescByIndex(i)
                    ElseIf mv_arrObjFields(i).SearchCode.Trim.Length > 0 _
                        And (mv_arrObjFields(i).ControlType.Trim = "T" _
                        Or mv_arrObjFields(i).ControlType.Trim = "M") And mv_arrObjFields(i).FieldValue.Length > 0 Then
                        GetFieldSearchCodeDescByIndex(i)
                    End If
                End If
            Next
        End If
        'End GianhVG Add        

        mv_blnIsLoading = False

        If Me.FlagLog <> "NONE" Then
            Me.Text = "[" & Me.FlagLog & "]: " & Me.Text
        End If


    End Sub

    'FDS DieuNDA: Export du lieu tu grid
    Protected Overridable Function OnExport(ByVal p_grid As GridEx) As Int32
        Dim v_strOldCultureName As String = String.Empty
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|Text files (*.txt)|*.txt|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Me.Cursor.Current = Cursors.WaitCursor

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                If Mid(v_strFileName, Len(v_strFileName) - 3) <> ".xls" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (p_grid.DataRows.Count > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        For idx As Integer = 0 To p_grid.Columns.Count - 1
                            If p_grid.Columns(idx).Visible Then
                                v_strData &= p_grid.Columns(idx).Title & vbTab
                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        For i As Integer = 0 To p_grid.DataRows.Count - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To p_grid.DataRows(i).Cells.Count - 1
                                If p_grid.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(p_grid.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_resourceManager.GetString("frmMaster.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.Cursor.Current = Cursors.Default
                        Exit Function
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else

                    'Ghi file excel
                    'If Me.chkALL.Checked Then
                    '    'Dim v_Ew As New ExcelLib
                    '    'v_Ew.WriteXLSFile(v_strFileName, mv_SearchData)
                    '    'mv_SearchData.Dispose()

                    '    Dim v_Ew As New ExcelLib
                    '    v_Ew.WriteXLSFileEx(v_strFileName, mv_SearchData, Me.TableName)
                    '    mv_SearchData.Dispose()

                    'Else
                    'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                    'Dim oldCI As Globalization.CultureInfo
                    'oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                    'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                    v_strOldCultureName = SetCultureInfo("en-US")

                    Dim objExcel As Excel.Application ' Excel object
                    Dim objWorkbook As Excel.Workbook 'Workbook object 
                    Dim objWorksheet As Excel.Worksheet 'Worksheet object 

                    objExcel = New Excel.ApplicationClass
                    'Add a new workbook 
                    objWorkbook = objExcel.Workbooks.Add()

                    'Set the Wwrksheet object to the sheet in the workbook you want to use 
                    'Note: You can use an Index number as well as specifying the name of the sheet 
                    objWorksheet = CType(objWorkbook.Worksheets.Item("Sheet1"), Excel.Worksheet)

                    Dim varInt_StartRow As Integer
                    If System.IO.File.Exists(v_strFileName) = True Then 'Check to see if file exists
                        objWorkbook = objExcel.Workbooks.Open(v_strFileName)
                        objWorksheet = objWorkbook.Worksheets.Item("Sheet1")

                        'Find last empty cell
                        varInt_StartRow = objWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                    Else
                        varInt_StartRow = 0
                    End If
                    If (p_grid.DataRows.Count > 0) Then



                        Dim i, j As Integer
                        'Write header
                        For idx As Integer = 0 To p_grid.Columns.Count - 1
                            If p_grid.Columns(idx).Visible Then
                                'v_strData &= SearchGrid.Columns(idx).Title & vbTab
                                CType(objWorksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                                With objWorksheet.Range(objWorksheet.Cells(1, i + 1), objWorksheet.Cells(1, i + 1))
                                    .Value = CStr(p_grid.Columns(idx).Title)
                                    .Font.Size = 12
                                    .Font.Name = "Times New Roman"
                                    .VerticalAlignment = Excel.Constants.xlTop
                                    .HorizontalAlignment = Excel.Constants.xlCenter
                                    .Select()
                                    i = i + 1
                                End With
                            End If
                        Next

                        'Write data
                        For j = 0 To p_grid.DataRows.Count - 1
                            i = 0
                            For idx As Integer = 0 To p_grid.DataRows(j).Cells.Count - 1
                                If p_grid.Columns(idx).Visible Then
                                    With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                        .Value = CStr(p_grid.DataRows(j).Cells(idx).Value)
                                        .NumberFormat = "@"
                                    End With
                                    i = i + 1
                                End If
                            Next
                        Next

                        'Save workbook before closing 
                        objWorkbook.SaveAs(v_strFileName)

                    Else
                        MsgBox(mv_resourceManager.GetString("frmMaster.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Function
                    End If

                    'Close the workbook and Excel 
                    objWorkbook.Close(False, "", Nothing)
                    objWorkbook = Nothing
                    objExcel.Quit()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                    objExcel = Nothing

                    'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                    'System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                    'End If

                End If


                MsgBox(mv_resourceManager.GetString("frmMaster.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Me.Cursor.Current = Cursors.Default
            Exit Function

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            If Len(v_strOldCultureName) > 0 Then
                v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            End If
        End Try
    End Function
    'End FDS DieuNDA
#End Region

#Region " Form events "

    Private Sub frmMaster_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub
    Private Sub frmMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (DesignMode) Then
            Return
        End If
        OnInit()
    End Sub

    Private Sub frmMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If Not mv_xmlDocument Is Nothing Then
            mv_xmlDocument = Nothing
        End If
    End Sub


    Private Sub frmMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, v_strSQL, strFLDNAME As String, v_intIndex As Integer
        Dim v_strFLDVALUE, v_strVALEXP As String, v_ctl, v_panel As Control, v_tabIndex, v_panelIndex As Integer
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If (Me.ActiveControl Is btnOK) Then
                        OnSave()
                    Else
                        If TypeOf (Me.ActiveControl) Is TextBox Or TypeOf (Me.ActiveControl) Is ComboBox _
                            Or TypeOf (Me.ActiveControl) Is FlexMaskEditBox Or TypeOf (Me.ActiveControl) Is DateTimePicker Then
                            SendKeys.Send("{Tab}")
                            e.Handled = True
                        End If
                    End If
                Case Keys.F5
                    If Me.ActiveControl.Name = PREFIXED_MSKDATA & "BUSDATE" Then
                        Exit Sub
                    End If
                    If InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_intIndex = Me.ActiveControl.Tag
                        'Tra cuu thong tin
                        If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 _
                            And mv_arrObjFields(v_intIndex).ControlType <> "C" Then
                            'Goi ham de thiet lap man hinh tim kiem
                            mv_frmSearchScreen = New frmSearch(Me.UserLanguage)
                            mv_frmSearchScreen.TableName = mv_arrObjFields(v_intIndex).SearchCode
                            mv_frmSearchScreen.ModuleCode = mv_arrObjFields(v_intIndex).SrModCode
                            mv_frmSearchScreen.AuthCode = "NYNNYYNNNN" 'Chi cho phep thuc hien Close va View. Tinh nang nay can nang cap de kiem tra them quyen
                            mv_frmSearchScreen.IsLocalSearch = gc_IsNotLocalMsg
                            mv_frmSearchScreen.IsLookup = "Y"
                            mv_frmSearchScreen.SearchOnInit = False
                            mv_frmSearchScreen.BranchId = Me.BranchId
                            mv_frmSearchScreen.TellerId = Me.TellerId
                            'TruongLD Add 20/07/2017 them de loai tru cac data da gan cho Parent
                            mv_frmSearchScreen.LinkValue = Me.ParentValue
                            'End TruongLD
                            mv_frmSearchScreen.SearchByTransact = True
                            mv_frmSearchScreen.ShowDialog()
                            If Not mv_frmSearchScreen.ReturnValue Is Nothing Then
                                Me.ActiveControl.Text = mv_frmSearchScreen.ReturnValue
                                If Len(mv_frmSearchScreen.RefValue) > 0 Then
                                    v_tabIndex = mv_arrObjFields(v_intIndex).TabIndex
                                    v_panelIndex = mv_arrObjFields(v_intIndex).GroupIndex
                                    v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                    v_ctl = v_panel.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    v_ctl.Top = Me.ActiveControl.Top
                                    v_ctl.Text = mv_frmSearchScreen.RefValue
                                    v_ctl.Visible = True
                                End If
                                strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                                FillLookupData(strFLDNAME, mv_frmSearchScreen.ReturnValue, mv_frmSearchScreen.FULLDATA, mv_frmSearchScreen.KeyColumn)
                                mv_frmSearchScreen.Dispose()
                            End If
                        ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" _
                            And mv_arrObjFields(v_intIndex).ControlType <> "C" Then
                            Dim v_strFILTERID As String
                            'Get filterid from related field (TAGFIELD)
                            If mv_arrObjFields(v_intIndex).TagField.Trim.Length > 0 Then
                                v_strFILTERID = GetControlValueByName(mv_arrObjFields(v_intIndex).TagField)
                            Else
                                v_strFILTERID = String.Empty
                            End If
                            Dim frm As New frmLookUp(UserLanguage)
                            frm.IsLocalSearch = gc_IsLocalMsg
                            v_strSQL = mv_arrObjFields(v_intIndex).LookupList
                            v_strSQL = v_strSQL.Replace("<$TAGFIELD>", v_strFILTERID)
                            v_strSQL = v_strSQL.Replace("<$BRID>", Me.BranchId)
                            v_strSQL = v_strSQL.Replace("<$TLID>", Me.TellerId)
                            v_strSQL = v_strSQL.Replace("<$PARENTID>", Me.ParentValue)
                            v_strSQL = v_strSQL.Replace("<$PARENTOBJ>", Me.ParentObject)
                            v_strSQL = v_strSQL.Replace("<$PARENTMOD>", Me.ParentModule)
                            v_strSQL = v_strSQL.Replace("<$KEYVALUE>", Me.KeyFieldValue)
                            v_strSQL = v_strSQL.Replace("<$OBJNAME>", Me.ObjectName)
                            v_strSQL = v_strSQL.Replace("<$MODCODE>", Me.ModuleCode)
                            v_strSQL = v_strSQL.Replace("<$HO_BRID>", HO_BRID)
                            'Ngay 13/01/2020 NamTv khi check ngon ngu doi thong tin desc combobox theo ngon ngu
                            If Me.UserLanguage = gc_LANG_ENGLISH Then
                                v_strSQL = v_strSQL.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                v_strSQL = v_strSQL.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                            Else
                                v_strSQL = v_strSQL.Replace("<@CDCONTENT>", "CDCONTENT")
                                v_strSQL = v_strSQL.Replace("<@DESCRIPTION>", "DESCRIPTION")
                            End If
                            'NamTv End.
                            frm.SQLCMD = v_strSQL
                            frm.ShowDialog()
                            If Not frm.RETURNDATA Is Nothing Then
                                v_intPos = InStr(frm.RETURNDATA, vbTab)
                                If v_intPos > 0 Then
                                    Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                                    v_tabIndex = mv_arrObjFields(v_intIndex).TabIndex
                                    v_panelIndex = mv_arrObjFields(v_intIndex).GroupIndex
                                    v_panel = Me.tabMaster.TabPages(v_tabIndex).Controls(v_panelIndex)
                                    v_ctl = v_panel.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    v_ctl.Top = Me.ActiveControl.Top
                                    v_ctl.Text = Mid(frm.RETURNDATA, v_intPos + 1)
                                    v_ctl.Visible = True
                                    'Nap cac gia tri tra ve cho cac truong khac
                                    strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                                    FillLookupData(strFLDNAME, Mid(frm.RETURNDATA, 1, v_intPos - 1), frm.FULLDATA)
                                End If
                                frm.Dispose()
                            End If
                        End If
                    End If
                Case Keys.F9
                    'Toggle Basic/Advanced show for first tab
                    ToggleFirstTabBasicAdvancedShow()
                Case Keys.Escape
                    OnClose()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
#End Region

    'trung.luu: 14-01-2021 Print Swift
    Private Sub tabMaster_MouseDown(sender As Object, e As MouseEventArgs)
        Try
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                btnDownLoad.Caption = mv_resourceManager.GetString("EXPORT")
                PreviewPrint.Caption = mv_resourceManager.GetString("PREVIEWPRINT")
                PreviewPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                popmenu.ShowPopup(Control.MousePosition)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDownLoad_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDownLoad.ItemClick
        Try
            Dim PrintDialog As PrintDialog = New PrintDialog
            PrintDialog.Document = PreparePrintDocument()
            PrintDialog.AllowSomePages = True
            PrintDialog.AllowSelection = True
            If PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDialog.Document.Print()
                MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If


            'Dim ms As MemoryStream = New MemoryStream()
            'Dim SaveFileDialog As SaveFileDialog = New SaveFileDialog()
            'SaveFileDialog.CreatePrompt = True
            'SaveFileDialog.OverwritePrompt = True
            'SaveFileDialog.Filter = "Images|*.rtf,*.txt"
            'If SaveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '    File.WriteAllText(SaveFileDialog.FileName, mv_v_rtbData_RichTextBox.Text)

            '    MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'End If
        Catch ex As Exception
            MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Function PreparePrintDocument() As PrintDocument
        Dim Print_Document As New PrintDocument
        AddHandler Print_Document.PrintPage, AddressOf Print_PrintPage
        Return Print_Document
    End Function
    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim Page As String
        Page = mv_v_rtbData_RichTextBox.Text
        e.Graphics.DrawString(Page, Me.Font, Brushes.Black, 50, 50)
        e.HasMorePages = False
    End Sub


    Private Sub PreviewPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PreviewPrint.ItemClick
        Dim Print_Preview As New PrintPreviewDialog
        Print_Preview.Document = PreparePrintDocument()
        Print_Preview.WindowState = FormWindowState.Normal
        Print_Preview.PrintPreviewControl.Zoom = 1.5
        Print_Preview.HorizontalScroll.Enabled = True
        Print_Preview.VerticalScroll.Enabled = True
        Print_Preview.ShowDialog()
    End Sub
    'trung.luu: 14-01-2021 Print Swift
End Class

<Serializable()> _
Public Class CGrpMaster

#Region " Declare variabes & consts "
    Private v_strOBJNAME As String
    Private v_strGRNAME As String
    Private v_strGRTYPE As String
    Private v_strSEARCHCODE As String
    Private v_strKEYFIELD As String
    Private v_strKEYVALUE As String
    Private v_strCAREBYCHK As String
    Private v_strGRBUTTONS As String
    Private v_intPANELIDX As Integer
    Private v_intGRIDIDX As Integer
#End Region

#Region " Properties "
    Public Property GRIDIDX() As Integer
        Get
            Return v_intGRIDIDX
        End Get
        Set(ByVal Value As Integer)
            v_intGRIDIDX = Value
        End Set
    End Property

    Public Property PANELIDX() As Integer
        Get
            Return v_intPANELIDX
        End Get
        Set(ByVal Value As Integer)
            v_intPANELIDX = Value
        End Set
    End Property

    Public Property KEYFIELD() As String
        Get
            Return v_strKEYFIELD
        End Get
        Set(ByVal Value As String)
            v_strKEYFIELD = Value
        End Set
    End Property

    Public Property KEYVALUE() As String
        Get
            Return v_strKEYVALUE
        End Get
        Set(ByVal Value As String)
            v_strKEYVALUE = Value
        End Set
    End Property

    Public Property GRTYPE() As String
        Get
            Return v_strGRTYPE
        End Get
        Set(ByVal Value As String)
            v_strGRTYPE = Value
        End Set
    End Property

    Public Property OBJNAME() As String
        Get
            Return v_strOBJNAME
        End Get
        Set(ByVal Value As String)
            v_strOBJNAME = Value
        End Set
    End Property

    Public Property GRNAME() As String
        Get
            Return v_strGRNAME
        End Get
        Set(ByVal Value As String)
            v_strGRNAME = Value
        End Set
    End Property

    Public Property GRBUTTONS() As String
        Get
            Return v_strGRBUTTONS
        End Get
        Set(ByVal Value As String)
            v_strGRBUTTONS = Value
        End Set
    End Property

    Public Property SEARCHCODE() As String
        Get
            Return v_strSEARCHCODE
        End Get
        Set(ByVal Value As String)
            v_strSEARCHCODE = Value
        End Set
    End Property

    Public Property CAREBYCHK() As String
        Get
            Return v_strCAREBYCHK
        End Get
        Set(ByVal Value As String)
            v_strCAREBYCHK = Value
        End Set
    End Property

#End Region

End Class


