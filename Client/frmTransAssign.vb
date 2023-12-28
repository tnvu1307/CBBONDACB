Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Xceed.SmartUI.Controls.TreeView
Imports CommonLibrary
Imports AppCore
Imports AppCore.GridEx
Imports AppCore.ComboBoxEx

Public Class frmTransAssign
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents stvTransMenu As Xceed.SmartUI.Controls.TreeView.SmartTreeView
    Friend WithEvents imlMenu As System.Windows.Forms.ImageList
    Friend WithEvents Node1 As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents cboCURRCOD As ComboBoxEx
    Friend WithEvents lblCURRCOD As System.Windows.Forms.Label
    Friend WithEvents imlToolBar As System.Windows.Forms.ImageList
    Friend WithEvents grbTransAssign As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlTransAssign As System.Windows.Forms.Panel
    Friend WithEvents lblTRANS As System.Windows.Forms.Label
    Friend WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents tbnSave As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnCancel As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents txtOFFICERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txtCASHIERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txtTELLERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txtCHECKERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblCHECKERLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblCASHIERLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblTELLERLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblOFFICERLIMIT As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransAssign))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.stvTransMenu = New Xceed.SmartUI.Controls.TreeView.SmartTreeView(Me.components)
        Me.Node1 = New Xceed.SmartUI.Controls.TreeView.Node("@VSTP - Transaction", 2)
        Me.imlMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.grbTransAssign = New System.Windows.Forms.GroupBox
        Me.lblCHECKERLIMIT = New System.Windows.Forms.Label
        Me.txtCHECKERLIMIT = New System.Windows.Forms.TextBox
        Me.lblOFFICERLIMIT = New System.Windows.Forms.Label
        Me.lblCASHIERLIMIT = New System.Windows.Forms.Label
        Me.txtOFFICERLIMIT = New System.Windows.Forms.TextBox
        Me.txtCASHIERLIMIT = New System.Windows.Forms.TextBox
        Me.lblTELLERLIMIT = New System.Windows.Forms.Label
        Me.lblCURRCOD = New System.Windows.Forms.Label
        Me.txtTELLERLIMIT = New System.Windows.Forms.TextBox
        Me.cboCURRCOD = New AppCore.ComboBoxEx
        Me.imlToolBar = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnSave = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnSave", 1)
        Me.tbnCancel = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnCancel", 0)
        Me.pnlTransAssign = New System.Windows.Forms.Panel
        Me.lblTRANS = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.stvTransMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbTransAssign.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTransAssign.SuspendLayout()
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
        Me.Panel1.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Tag = "Caption"
        Me.lblCaption.Text = "lblCaption"
        '
        'stvTransMenu
        '
        Me.stvTransMenu.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.stvTransMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.stvTransMenu.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.Node1})
        Me.stvTransMenu.ItemsImageList = Me.imlMenu
        Me.stvTransMenu.Location = New System.Drawing.Point(0, 50)
        Me.stvTransMenu.Name = "stvTransMenu"
        Me.stvTransMenu.Size = New System.Drawing.Size(295, 405)
        Me.stvTransMenu.TabIndex = 0
        Me.stvTransMenu.Text = "stvTransMenu"
        '
        'Node1
        '
        Me.Node1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Node1.ImageIndex = 2
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "@VSTP - Transaction"
        '
        'imlMenu
        '
        Me.imlMenu.ImageStream = CType(resources.GetObject("imlMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMenu.Images.SetKeyName(0, "")
        Me.imlMenu.Images.SetKeyName(1, "")
        Me.imlMenu.Images.SetKeyName(2, "")
        Me.imlMenu.Images.SetKeyName(3, "")
        Me.imlMenu.Images.SetKeyName(4, "")
        Me.imlMenu.Images.SetKeyName(5, "")
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(295, 50)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 405)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'grbTransAssign
        '
        Me.grbTransAssign.Controls.Add(Me.lblCHECKERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.txtCHECKERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.lblOFFICERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.lblCASHIERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.txtOFFICERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.txtCASHIERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.lblTELLERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.lblCURRCOD)
        Me.grbTransAssign.Controls.Add(Me.txtTELLERLIMIT)
        Me.grbTransAssign.Controls.Add(Me.cboCURRCOD)
        Me.grbTransAssign.Location = New System.Drawing.Point(10, 40)
        Me.grbTransAssign.Name = "grbTransAssign"
        Me.grbTransAssign.Size = New System.Drawing.Size(310, 175)
        Me.grbTransAssign.TabIndex = 0
        Me.grbTransAssign.TabStop = False
        Me.grbTransAssign.Tag = "grbTransAssign"
        Me.grbTransAssign.Text = "grbTransAssign"
        '
        'lblCHECKERLIMIT
        '
        Me.lblCHECKERLIMIT.AutoSize = True
        Me.lblCHECKERLIMIT.Location = New System.Drawing.Point(10, 147)
        Me.lblCHECKERLIMIT.Name = "lblCHECKERLIMIT"
        Me.lblCHECKERLIMIT.Size = New System.Drawing.Size(90, 13)
        Me.lblCHECKERLIMIT.TabIndex = 21
        Me.lblCHECKERLIMIT.Tag = "CHECKERLIMIT"
        Me.lblCHECKERLIMIT.Text = "lblCHECKERLIMIT"
        Me.lblCHECKERLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCHECKERLIMIT
        '
        Me.txtCHECKERLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCHECKERLIMIT.Location = New System.Drawing.Point(130, 145)
        Me.txtCHECKERLIMIT.MaxLength = 20
        Me.txtCHECKERLIMIT.Name = "txtCHECKERLIMIT"
        Me.txtCHECKERLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.txtCHECKERLIMIT.TabIndex = 4
        Me.txtCHECKERLIMIT.Tag = "CHECKER"
        Me.txtCHECKERLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOFFICERLIMIT
        '
        Me.lblOFFICERLIMIT.AutoSize = True
        Me.lblOFFICERLIMIT.Location = New System.Drawing.Point(10, 117)
        Me.lblOFFICERLIMIT.Name = "lblOFFICERLIMIT"
        Me.lblOFFICERLIMIT.Size = New System.Drawing.Size(88, 13)
        Me.lblOFFICERLIMIT.TabIndex = 19
        Me.lblOFFICERLIMIT.Tag = "OFFICERLIMIT"
        Me.lblOFFICERLIMIT.Text = "lblOFFICERLIMIT"
        Me.lblOFFICERLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCASHIERLIMIT
        '
        Me.lblCASHIERLIMIT.AutoSize = True
        Me.lblCASHIERLIMIT.Location = New System.Drawing.Point(10, 87)
        Me.lblCASHIERLIMIT.Name = "lblCASHIERLIMIT"
        Me.lblCASHIERLIMIT.Size = New System.Drawing.Size(88, 13)
        Me.lblCASHIERLIMIT.TabIndex = 18
        Me.lblCASHIERLIMIT.Tag = "CASHIERLIMIT"
        Me.lblCASHIERLIMIT.Text = "lblCASHIERLIMIT"
        Me.lblCASHIERLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOFFICERLIMIT
        '
        Me.txtOFFICERLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOFFICERLIMIT.Location = New System.Drawing.Point(130, 115)
        Me.txtOFFICERLIMIT.MaxLength = 20
        Me.txtOFFICERLIMIT.Name = "txtOFFICERLIMIT"
        Me.txtOFFICERLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.txtOFFICERLIMIT.TabIndex = 3
        Me.txtOFFICERLIMIT.Tag = "OFFICER"
        Me.txtOFFICERLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCASHIERLIMIT
        '
        Me.txtCASHIERLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCASHIERLIMIT.Location = New System.Drawing.Point(130, 85)
        Me.txtCASHIERLIMIT.MaxLength = 20
        Me.txtCASHIERLIMIT.Name = "txtCASHIERLIMIT"
        Me.txtCASHIERLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.txtCASHIERLIMIT.TabIndex = 2
        Me.txtCASHIERLIMIT.Tag = "CASHIER"
        Me.txtCASHIERLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTELLERLIMIT
        '
        Me.lblTELLERLIMIT.AutoSize = True
        Me.lblTELLERLIMIT.Location = New System.Drawing.Point(10, 57)
        Me.lblTELLERLIMIT.Name = "lblTELLERLIMIT"
        Me.lblTELLERLIMIT.Size = New System.Drawing.Size(79, 13)
        Me.lblTELLERLIMIT.TabIndex = 12
        Me.lblTELLERLIMIT.Tag = "TELLERLIMIT"
        Me.lblTELLERLIMIT.Text = "lblTELLERLIMIT"
        Me.lblTELLERLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCURRCOD
        '
        Me.lblCURRCOD.AutoSize = True
        Me.lblCURRCOD.Location = New System.Drawing.Point(10, 27)
        Me.lblCURRCOD.Name = "lblCURRCOD"
        Me.lblCURRCOD.Size = New System.Drawing.Size(67, 13)
        Me.lblCURRCOD.TabIndex = 11
        Me.lblCURRCOD.Tag = "CURRCOD"
        Me.lblCURRCOD.Text = "lblCURRCOD"
        Me.lblCURRCOD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTELLERLIMIT
        '
        Me.txtTELLERLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTELLERLIMIT.Location = New System.Drawing.Point(130, 55)
        Me.txtTELLERLIMIT.MaxLength = 20
        Me.txtTELLERLIMIT.Name = "txtTELLERLIMIT"
        Me.txtTELLERLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.txtTELLERLIMIT.TabIndex = 1
        Me.txtTELLERLIMIT.Tag = "TELLER"
        Me.txtTELLERLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCURRCOD
        '
        Me.cboCURRCOD.DisplayMember = "DISPLAY"
        Me.cboCURRCOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCURRCOD.Location = New System.Drawing.Point(130, 25)
        Me.cboCURRCOD.Name = "cboCURRCOD"
        Me.cboCURRCOD.Size = New System.Drawing.Size(100, 21)
        Me.cboCURRCOD.TabIndex = 0
        Me.cboCURRCOD.Tag = "CURRCOD"
        Me.cboCURRCOD.ValueMember = "VALUE"
        '
        'imlToolBar
        '
        Me.imlToolBar.ImageStream = CType(resources.GetObject("imlToolBar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolBar.TransparentColor = System.Drawing.Color.Transparent
        Me.imlToolBar.Images.SetKeyName(0, "")
        Me.imlToolBar.Images.SetKeyName(1, "")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SmartToolBar1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(298, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 40)
        Me.Panel2.TabIndex = 3
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SmartToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SmartToolBar1.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tbnSave, Me.tbnCancel})
        Me.SmartToolBar1.ItemsImageList = Me.imlToolBar
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(336, 42)
        Me.SmartToolBar1.TabIndex = 0
        Me.SmartToolBar1.Text = "SmartToolBar1"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnSave
        '
        Me.tbnSave.ImageIndex = 1
        Me.tbnSave.Name = "tbnSave"
        Me.tbnSave.Text = "tbnSave"
        '
        'tbnCancel
        '
        Me.tbnCancel.ImageIndex = 0
        Me.tbnCancel.Name = "tbnCancel"
        Me.tbnCancel.Text = "tbnCancel"
        '
        'pnlTransAssign
        '
        Me.pnlTransAssign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTransAssign.Controls.Add(Me.lblTRANS)
        Me.pnlTransAssign.Controls.Add(Me.grbTransAssign)
        Me.pnlTransAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTransAssign.Location = New System.Drawing.Point(298, 90)
        Me.pnlTransAssign.Name = "pnlTransAssign"
        Me.pnlTransAssign.Size = New System.Drawing.Size(336, 365)
        Me.pnlTransAssign.TabIndex = 1
        '
        'lblTRANS
        '
        Me.lblTRANS.AutoSize = True
        Me.lblTRANS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRANS.Location = New System.Drawing.Point(10, 15)
        Me.lblTRANS.Name = "lblTRANS"
        Me.lblTRANS.Size = New System.Drawing.Size(57, 13)
        Me.lblTRANS.TabIndex = 11
        Me.lblTRANS.Tag = "TRANS"
        Me.lblTRANS.Text = "lblTRANS"
        Me.lblTRANS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTransAssign
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(634, 455)
        Me.Controls.Add(Me.pnlTransAssign)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.stvTransMenu)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransAssign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTransAssign"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stvTransMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbTransAssign.ResumeLayout(False)
        Me.grbTransAssign.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTransAssign.ResumeLayout(False)
        Me.pnlTransAssign.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String

    Private mv_intExecFlag As Integer
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strUserId As String
    Private mv_strUserName As String
    Private mv_strGroupId As String
    Private mv_strGroupName As String
    Private mv_strAssignType As String
    Private mv_strTlRight As String
    Private mv_strGrpRight As String
    Private mv_strRight As String

    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrCurrCod() As String
    Private mv_strTransAuthString As String
    Private mv_strTlauthString As String
    'PhuongADD
    Private mv_userAction As Integer
    Private mv_MenuClick As Integer = 1
    Private mv_SaveClick As Integer = 2
    'This node will be used as a temp node
    Private mv_node As New Node
    Private mv_textbox As New System.Windows.Forms.TextBox

    Private mv_strLocalObject As String

    Dim hTlauthFilter As New Hashtable
    Dim hTransFilter As New Hashtable
    Dim hCurrDecFilter As New Hashtable
    Dim hParentsFilter As New Hashtable
    Dim hModCodeFilter As New Hashtable
    Dim hTxCodeFilter As New Hashtable
    Dim hCmdIdFilter As New Hashtable
    Dim hChildrenFilter As New Hashtable
#End Region

#Region " Properties "

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

    Public Property UserId() As String
        Get
            Return mv_strUserId
        End Get
        Set(ByVal Value As String)
            mv_strUserId = Value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return mv_strUserName
        End Get
        Set(ByVal Value As String)
            mv_strUserName = Value
        End Set
    End Property

    Public Property GroupId() As String
        Get
            Return mv_strGroupId
        End Get
        Set(ByVal Value As String)
            mv_strGroupId = Value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return mv_strGroupName
        End Get
        Set(ByVal Value As String)
            mv_strGroupName = Value
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
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
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

    Public Property AssignType() As String
        Get
            Return mv_strAssignType
        End Get
        Set(ByVal Value As String)
            mv_strAssignType = Value
        End Set
    End Property

    Public Property UserRight() As String
        Get
            Return mv_strTlRight
        End Get
        Set(ByVal Value As String)
            mv_strTlRight = Value
        End Set
    End Property

    Public Property GroupRight() As String
        Get
            Return mv_strGrpRight
        End Get
        Set(ByVal Value As String)
            mv_strGrpRight = Value
        End Set
    End Property

#End Region

#Region " Overridable methods "
    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            DoResizePanel()
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmTransAssign-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            FillData()
            GetParents()
            DisableAccessRight()
            DisplayMenus()
        Catch ex As Exception

        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        'Dim v_strTellerName As String

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmTransAssign." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmTransAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmTransAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmTransAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is ComboBox Then
                    If CType(v_ctrl, ComboBox).Items.Count > 0 Then
                        CType(v_ctrl, ComboBox).SelectedIndex = 0
                    End If
                End If
            Next

            'Load caption of toolbar
            tbnSave.Text = mv_ResourceManager.GetString("frmTransAssign.tbnSave")
            tbnCancel.Text = mv_ResourceManager.GetString("frmTransAssign.tbnCancel")
            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmTransAssign")
            lblCaption.Text = mv_ResourceManager.GetString("frmTransAssign.lblCaption") & UserName
            'Disable control if in view mode
            If (ExeFlag = ExecuteFlag.View) Then
                tbnSave.Enabled = False
            End If

            'Get right
            If AssignType = "User" Then
                mv_strRight = UserRight
            ElseIf AssignType = "Group" Then
                mv_strRight = GroupRight
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục thay đổi kích thước panel --''
    ''---------------------------------------''
    Private Sub DoResizePanel()
        Try
            grbTransAssign.Width = pnlTransAssign.Width - 20
        Catch ex As Exception

        End Try
    End Sub

    ''-------------------------------------------------''
    ''-- Thủ tục lấy và fill dữ liệu vào các control --''
    ''-------------------------------------------------''
    Private Sub FillData()

        Dim v_strFLDNAME, v_strValue As String

        Try

            'Select and fill currency code
            Dim v_strCmdInquiryCurr, v_strCurrCodeObjMsg As String
            v_strCmdInquiryCurr = "SELECT CCYCD VALUE, SHORTCD DISPLAY, CCYDECIMAL CCYDECIMAL FROM SBCURRENCY WHERE ACTIVE = 'Y' ORDER BY CCYCD"
            v_strCurrCodeObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryCurr)
            Dim v_wsCurrCode As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsCurrCode.Message(v_strCurrCodeObjMsg)

            Dim v_xmlCurrCodDocument As New Xml.XmlDocument
            Dim v_nodeCurrCodList As Xml.XmlNodeList

            v_xmlCurrCodDocument.LoadXml(v_strCurrCodeObjMsg)
            v_nodeCurrCodList = v_xmlCurrCodDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrCurrCod(v_nodeCurrCodList.Count)
            Dim v_arrCurrName(v_nodeCurrCodList.Count) As String
            Dim v_intCurrDec As Integer

            For i As Integer = 0 To v_nodeCurrCodList.Count - 1
                For j As Integer = 0 To v_nodeCurrCodList.Item(i).ChildNodes.Count - 1
                    With v_nodeCurrCodList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "VALUE"
                            mv_arrCurrCod(i) = Trim(v_strValue)
                        Case "DISPLAY"
                            v_arrCurrName(i) = Trim(v_strValue)
                        Case "CCYDECIMAL"
                            v_intCurrDec = CInt(Trim(v_strValue))
                    End Select
                Next
                'Add to CurrDec hash table
                hCurrDecFilter.Add(mv_arrCurrCod(i), v_intCurrDec)
                'Add item to CURRCOD combobox
                cboCURRCOD.AddItems(v_arrCurrName(i), mv_arrCurrCod(i))
            Next

            'Get Transaction access right
            'Dim v_strCmdInquiryTrans, v_strTransObjMsg As String
            'Dim v_strTXCODE, v_strCMDID, v_strLEV, v_strCMDALLOW, v_strAUTH, v_strHashKey, v_strHashValue As String
            ''Get parents access right
            'If AssignType = "User" Then
            '    v_strCmdInquiryTrans = "SELECT M.TXCODE TXCODE, M.CMDID CMDID, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, C.CMDID CMDID " _
            '                                & "FROM APPMODULES N, CMDMENU C " _
            '                                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'T') M, CMDAUTH A " _
            '                        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
            '                        & "ORDER BY M.CMDID "
            '    'v_strCmdInquiryTrans = "SELECT M.TXCODE TXCODE, 1 LEV, A.CMDALLOW CMDALLOW " _
            '    '                    & "FROM APPMODULES M, CMDAUTH A " _
            '    '                    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
            '    '                    & "ORDER BY M.TXCODE"
            '    v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryTrans)
            'ElseIf AssignType = "Group" Then
            '    v_strCmdInquiryTrans = "SELECT M.TXCODE TXCODE, M.CMDID CMDID, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                                        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, C.CMDID CMDID " _
            '                                                & "FROM APPMODULES N, CMDMENU C " _
            '                                                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'T') M, CMDAUTH A " _
            '                                        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
            '                                        & "ORDER BY M.CMDID "
            '    'v_strCmdInquiryTrans = "SELECT M.TXCODE TXCODE, 1 LEV, A.CMDALLOW CMDALLOW " _
            '    '                    & "FROM APPMODULES M, CMDAUTH A " _
            '    '                    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
            '    '                    & "ORDER BY M.TXCODE"
            '    v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryTrans)
            'End If

            'Dim v_wsPrTrans As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'v_wsPrTrans.Message(v_strTransObjMsg)

            'Dim v_xmlPrTransDocument As New Xml.XmlDocument
            'Dim v_nodePrTransList As Xml.XmlNodeList

            'v_xmlPrTransDocument.LoadXml(v_strTransObjMsg)
            'v_nodePrTransList = v_xmlPrTransDocument.SelectNodes("/ObjectMessage/ObjData")
            'Dim v_strTXCODE, v_strCMDID, v_strLEV, v_strCMDALLOW, v_strAUTH, v_strHashKey, v_strHashValue As String
            'For i As Integer = 0 To v_nodePrTransList.Count - 1
            '    For j As Integer = 0 To v_nodePrTransList.Item(i).ChildNodes.Count - 1
            '        With v_nodePrTransList.Item(i).ChildNodes(j)
            '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '            v_strValue = .InnerText.ToString
            '        End With
            '        Select Case Trim(v_strFLDNAME)
            '            Case "TXCODE"
            '                v_strTXCODE = v_strValue
            '            Case "CMDID"
            '                v_strCMDID = Trim(v_strValue)
            '            Case "LEV"
            '                v_strLEV = v_strValue
            '            Case "CMDALLOW"
            '                v_strCMDALLOW = v_strValue
            '        End Select
            '    Next
            '    'Fill to hashtable
            '    v_strHashKey = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW
            '    hTransFilter.Add(v_strCMDID, v_strHashKey)
            '    mv_strTransAuthString &= v_strHashKey & "#"
            'Next

            'Get Transaction access right
            Dim v_strCmdInquiryTrans, v_strTransObjMsg As String
            Dim v_strTXCODE, v_strCMDID, v_strLEV, v_strCMDALLOW, v_strAUTH, v_strHashKey, v_strHashValue, v_strCNT, v_strMENUTYPE As String
            If AssignType = "User" Then
                If TellerId <> ADMIN_ID Then
                    v_strCmdInquiryTrans = "SELECT M.TLTXCD TLTXCD, A.CMDALLOW CMDALLOW, 4 LEV " _
                                    & "FROM TLTX M, CMDAUTH A " _
                                    & "WHERE M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                    & " AND M.TLTXCD IN (SELECT M.TLTXCD  FROM TLTX M, CMDAUTH A WHERE M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & TellerId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y')" _
                                    & "ORDER BY M.TLTXCD "
                    v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryTrans)
                Else
                    v_strCmdInquiryTrans = "SELECT M.TLTXCD TLTXCD, A.CMDALLOW CMDALLOW, 4 LEV " _
                                    & "FROM TLTX M, CMDAUTH A " _
                                    & "WHERE M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.TLTXCD "
                    v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryTrans)
                End If
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryTrans = "SELECT M.TLTXCD TLTXCD, A.CMDALLOW CMDALLOW, 4 LEV " _
                                    & "FROM TLTX M, CMDAUTH A " _
                                    & "WHERE M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.TLTXCD "
                v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryTrans)
            End If

            Dim v_wsTrans As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsTrans.Message(v_strTransObjMsg)

            Dim v_xmlTransDocument As New Xml.XmlDocument
            Dim v_nodeTransList As Xml.XmlNodeList

            v_xmlTransDocument.LoadXml(v_strTransObjMsg)
            v_nodeTransList = v_xmlTransDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strTLTXCD As String
            For i As Integer = 0 To v_nodeTransList.Count - 1
                For j As Integer = 0 To v_nodeTransList.Item(i).ChildNodes.Count - 1
                    With v_nodeTransList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "TLTXCD"
                            v_strTLTXCD = v_strValue
                        Case "LEV"
                            v_strLEV = v_strValue
                        Case "CMDALLOW"
                            v_strCMDALLOW = v_strValue
                    End Select
                Next
                'Fill to hashtable
                v_strHashKey = v_strTLTXCD & "|" & v_strLEV & "|" & v_strCMDALLOW & "|" & "T"
                hTransFilter.Add(v_strTLTXCD, v_strHashKey)
                mv_strTransAuthString &= v_strHashKey & "#"
            Next

            'Get Function access right of user
            Dim v_strCmdInquiryFunc, v_strFuncObjMsg As String
            If AssignType = "User" Then
                'v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                '                    & "from CMDMENU M, CMDAUTH A " _
                '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                '                    & "and A.AUTHID = '" & UserId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T')" _
                '                    & "order by M.CMDID"
                'v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                '                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                '                         & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                '                                & " FROM CMDMENU M, CMDAUTH A " _
                '                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                '                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T') " _
                '                                & " ORDER BY M.CMDID) MNU1 " _
                '                                & " LEFT JOIN " _
                '                                & " (SELECT M.PRID, M.CMDID CMDID " _
                '                                & " FROM CMDMENU M, CMDAUTH A " _
                '                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                '                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T') " _
                '                                & " ORDER BY M.CMDID) MNU2 " _
                '                         & " ON MNU1.CMDID = MNU2.PRID " _
                '                         & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                '                         & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                '                         & " FROM (SELECT M.*, N.TXCODE " _
                '                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                '                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                '                         & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                '                         & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T') " _
                '                         & " ORDER BY M.CMDID) MNU " _
                '                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                '                    & " ORDER BY MNU.CMDID "
                'PhuongNN ADD
                v_strCmdInquiryFunc = "Select M.CMDID CMDID, APP.TXCODE TXCODE, M.menutype MENUTYPE, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                                    & "from CMDMENU M, CMDAUTH A, appmodules APP " _
                                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                                    & "and A.AUTHID = '" & UserId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T') " _
                                    & "and APP.MODCODE(+) = M.MODCODE " _
                                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryFunc)
            ElseIf AssignType = "Group" Then
                'Phuong ADD
                'v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                '                    & "from CMDMENU M, CMDAUTH A " _
                '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                '                    & "and A.AUTHID = '" & GroupId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T')" _
                '                    & "order by M.CMDID"
                v_strCmdInquiryFunc = "Select M.CMDID CMDID, APP.TXCODE TXCODE, M.menutype MENUTYPE, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                                    & "from CMDMENU M, CMDAUTH A, appmodules APP " _
                                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                                    & "and A.AUTHID = '" & GroupId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'T') " _
                                    & "and APP.MODCODE(+) = M.MODCODE " _
                                    & "order by M.CMDID"
                'Phuong End
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryFunc)
            End If

            Dim v_wsFunc As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsFunc.Message(v_strFuncObjMsg)

            Dim v_xmlFuncDocument As New Xml.XmlDocument
            Dim v_nodeFuncList As Xml.XmlNodeList

            v_xmlFuncDocument.LoadXml(v_strFuncObjMsg)
            v_nodeFuncList = v_xmlFuncDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strSQL, v_strObjMsg As String

            For i As Integer = 0 To v_nodeFuncList.Count - 1
                For j As Integer = 0 To v_nodeFuncList.Item(i).ChildNodes.Count - 1
                    With v_nodeFuncList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        'Case "CNT"
                        '    v_strCNT = CStr(v_strValue).Trim
                        Case "CMDID"
                            v_strCMDID = CStr(v_strValue).Trim
                        Case "LEV"
                            v_strLEV = CStr(v_strValue).Trim
                        Case "MENUTYPE"
                            v_strMENUTYPE = CStr(v_strValue).Trim
                        Case "TXCODE"
                            v_strTXCODE = CStr(v_strValue).Trim
                        Case "CMDALLOW"
                            v_strCMDALLOW = CStr(v_strValue).Trim
                        Case "STRAUTH"
                            v_strAUTH = CStr(v_strValue).Trim
                    End Select
                Next
                'Fill to hashtable
                v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & "M"
                If hTransFilter(v_strCMDID) Is Nothing Then
                    hTransFilter.Add(v_strCMDID, v_strHashValue)
                End If
                'Fill to Children hashtable
                If v_strMENUTYPE = "T" Then
                    Dim v_strTXCNT As String
                    v_strSQL = "SELECT COUNT(TLTXCD) TXCNT " _
                            & " FROM TLTX M, CMDAUTH A " _
                            & " WHERE SUBSTR(M.TLTXCD, 0, 2) = '" & v_strTXCODE & "' AND M.TLTXCD = A.CMDCODE " _
                            & " AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                            & " ORDER BY M.TLTXCD "
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    v_ws.Message(v_strObjMsg)
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_nodeList As Xml.XmlNodeList
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For k As Integer = 0 To v_nodeList.Count - 1
                        For l As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                            With v_nodeList.Item(k).ChildNodes(l)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "TXCNT"
                                    v_strTXCNT = CStr(v_strValue).Trim
                            End Select
                        Next
                    Next
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strTXCNT
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If

                Else
                    Dim v_strNChild As String
                    v_strSQL = " select count(*) NCHLD from cmdauth A, cmdmenu  M " _
                                & " where(A.cmdcode = M.prid)" _
                                & " and A.authid = '" & GroupId & "' and  A.cmdallow = 'Y' and A.cmdcode = '" & v_strCMDID & "'" _
                                & " order by a.cmdcode"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    v_ws.Message(v_strObjMsg)
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_nodeList As Xml.XmlNodeList
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For k As Integer = 0 To v_nodeList.Count - 1
                        For l As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                            With v_nodeList.Item(k).ChildNodes(l)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "NCHLD"
                                    v_strNChild = CStr(v_strValue).Trim
                            End Select
                        Next
                    Next
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strNChild
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If

                End If

                'mv_strReportAuth &= v_strHashValue & "#"
            Next


            'Get Transaction limit of user
            If AssignType = "User" Then
                v_strCmdInquiryTrans = "SELECT TLTXCD, CODEID, TLTYPE, TLLIMIT FROM TLAUTH WHERE AUTHTYPE = 'U' AND AUTHID = '" & UserId & "'"
                v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryTrans)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryTrans = "SELECT TLTXCD, CODEID, TLTYPE, TLLIMIT FROM TLAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & GroupId & "'"
                v_strTransObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryTrans)
            End If

            Dim v_wsTlLimit As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsTlLimit.Message(v_strTransObjMsg)

            Dim v_xmlTlLimitDocument As New Xml.XmlDocument
            Dim v_nodeTlLimitList As Xml.XmlNodeList

            v_xmlTlLimitDocument.LoadXml(v_strTransObjMsg)
            v_nodeTlLimitList = v_xmlTlLimitDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strCURRCOD, v_strTLTYPE, v_strTLLIMIT As String
            For i As Integer = 0 To v_nodeTlLimitList.Count - 1
                For j As Integer = 0 To v_nodeTlLimitList.Item(i).ChildNodes.Count - 1
                    With v_nodeTlLimitList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "TLTXCD"
                            v_strTLTXCD = v_strValue
                        Case "CODEID"
                            v_strCURRCOD = v_strValue
                        Case "TLTYPE"
                            v_strTLTYPE = v_strValue
                        Case "TLLIMIT"
                            v_strTLLIMIT = v_strValue
                    End Select
                Next
                'Fill to hashtable
                v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & v_strTLTYPE
                v_strHashValue = v_strHashKey & "|" & v_strTLLIMIT
                hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                mv_strTlauthString &= v_strHashValue & "#"
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''--------------------------------------''
    ''-- Ghi nội dung phân quy?n v�ào CSDL --''
    ''--------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_strAllAuthString, v_strMenuKeyAuth, v_strTransAuth, v_strGrpUsrId As String

        Try
            mv_userAction = mv_SaveClick
            'Update value of last changed textbox            
            ControlValue_Changed(mv_textbox, mv_node)

            'Reset last clicked menu
            ResetKey(mv_node)

            'Verify data type
            If (VerifyDataType() = False) Then
                Exit Sub
            End If

            If AssignType = "User" Then
                'Get Auth string from menu
                'v_strMenuKeyAuth = GetMenuKeyAuthString(stvTransMenu.Items(0))
                v_strMenuKeyAuth = mv_strTransAuthString
                'Get Auth string of all transactions
                v_strAllAuthString = UserId & "$" & v_strMenuKeyAuth & "$" & mv_strTlauthString

                'Buil XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllAuthString, "TransactionAssignment")

            ElseIf AssignType = "Group" Then
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get Auth string from menu
                'v_strMenuKeyAuth = GetMenuKeyAuthString(stvTransMenu.Items(0))
                v_strMenuKeyAuth = mv_strTransAuthString
                'Get Auth string of all transactions
                v_strAllAuthString = GroupId & "$" & v_strMenuKeyAuth & "$" & mv_strTlauthString & "$" & v_strGrpUsrId

                'Buil XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllAuthString, "TransactionAssignment")
            End If

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Check infomations and errors from message
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            ChangeImageIndex(stvTransMenu.Items(0))

            MsgBox(mv_ResourceManager.GetString("frmTransAssign.SavingSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'Me.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_ResourceManager.GetString("frmTransAssign.SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Private Function AddTreeNode(ByRef pv_nodeParent As Node, _
                                     ByVal pv_strKey As String, _
                                     ByVal pv_strName As String, _
                                     Optional ByVal pv_intImageIdx As Integer = 0) As Node
        'Create new node
        Dim v_node As New Node(pv_strName, pv_intImageIdx)
        Dim v_strNodeText, v_strTLTXCD, v_arrMenuKey() As String
        Try
            If pv_strKey <> String.Empty Then
                v_arrMenuKey = pv_strKey.Split("|")
                v_strTLTXCD = v_arrMenuKey(0)
            End If
            'Get node's name
            v_strNodeText = v_strTLTXCD & ": " & pv_strName

            v_node.Key = pv_strKey
            v_node.Text = v_strNodeText
            v_node.ToolTipText = v_strNodeText
            'Add node to menu
            pv_nodeParent.Items.Add(v_node)
            Return v_node

        Catch ex As Exception

        End Try
    End Function

    Private Sub DisplayMenus(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strMenuKey, v_strNodeKey, v_arrHashValue() As String
        Dim v_strTXCODE, v_strMODNAME, v_strMODCODE, v_strLEV, v_strCMDALLOW, v_strAUTH As String
        Dim v_strLocal As String = "N"

        Try
            If IsShown Then
                If AssignType = "User" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetTransParentMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId, "GetTransParentMenu")
                End If

                Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                m_ws.Message(v_strObjMsg)

                XmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                'stvRptMenu.Visible = False
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "TXCODE"
                                    v_strTXCODE = Trim(v_strValue)
                                Case "MODCODE"
                                    v_strMODCODE = Trim(v_strValue)
                                Case "MODNAME"
                                    v_strMODNAME = Trim(v_strValue)
                                    'Case "IMGINDEX"
                                    '    v_intIndex = CInt(Trim(v_strValue))
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                                    'Case "CMDALLOW"
                                    '    v_strCMDALLOW = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    'If Trim(v_strCMDALLOW) = String.Empty Then
                    '    v_strCMDALLOW = "N"
                    'End If

                    'Check CMDALLOW of user who is assigned
                    If Not hTransFilter(v_strCMDID) Is Nothing Then
                        v_arrHashValue = CStr(hTransFilter(v_strCMDID)).Split("|")
                        v_strCMDALLOW = Trim(v_arrHashValue(2))
                        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1)
                        If v_strCMDALLOW = "Y" Then
                            v_intIndex = 5
                        Else
                            v_intIndex = 0
                        End If
                    Else
                        v_intIndex = 0
                    End If

                    'If Trim(v_strCMDALLOW) = "Y" Then
                    '    v_intIndex = 5
                    'Else
                    '    v_intIndex = 0
                    'End If

                    'Add TXCODE and MODCODE to hash tables
                    hTxCodeFilter.Add(v_strMODCODE, v_strTXCODE)
                    hModCodeFilter.Add(v_strCMDID, v_strMODCODE)
                    hCmdIdFilter.Add(v_strMODCODE, v_strCMDID)

                    v_strNodeKey = v_strCMDID & "|" & v_strLEV & "|" & "M"

                    'If Len(Trim(v_strPRID)) = 0 Then
                    Dim v_node As New Node(v_strMODNAME, v_intIndex)
                    v_node.Key = CStr(v_strNodeKey)
                    v_node.ToolTipText = v_strMODNAME
                    v_node.Expanded = False

                    Me.stvTransMenu.Items(0).Items.Add(v_node)
                    'Add children node to menu
                    v_strMenuKey = v_strCMDID & "|" & v_strLEV & "|" & v_strTXCODE
                    AddChildMenu(stvTransMenu.Items(0).Items(CStr(v_strNodeKey)), CStr(v_strMenuKey))
                    'Add value to Report hashtable and RptAuth string
                    'Dim v_strTransHashValue As String
                    'v_strTransHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strAUTH
                    'hTransFilter.Add(v_strTXCODE, v_strTransHashValue)
                    'mv_strTransAuthString &= v_strTransHashValue & "#"
                Next v_intCount

            Else
                Me.stvTransMenu.Items(0).Items.Clear()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex, v_intLEV As Integer
        Dim v_strFLDNAME, v_strValue, v_strMenuType, v_strPRLEV As String
        Dim v_strObjName, v_strMenuKey, v_strPRCODE, v_strPRID, v_arrKey(), v_arrHashKey() As String
        Dim v_strTLTXCD, v_strTXDESC, v_strTXTYPE, v_strLIMIT, v_strCMDALLOW, v_strCURRCODE, v_strLEV As String
        Dim v_NewNode As New Node

        Try
            v_arrKey = pv_strKey.Split("|")
            v_strPRID = v_arrKey(0)
            v_strPRLEV = CStr(v_arrKey(1))
            v_strPRCODE = v_arrKey(2)

            v_intLEV = CInt(v_strPRLEV) + 1
            v_strLEV = CStr(v_intLEV)

            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetTransChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId & "|" & v_strPRCODE, "GetTransChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If Not pv_nodeParent Is Nothing Then
                If v_nodeList.Count > 0 Then
                    For v_intCount = 0 To v_nodeList.Count - 1
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString

                                Select Case Trim(v_strFLDNAME)
                                    Case "TLTXCD"
                                        v_strTLTXCD = Trim(v_strValue)
                                    Case "TXDESC"
                                        If UserLanguage = "VN" Then
                                            v_strTXDESC = Trim(v_strValue)
                                        End If
                                    Case "EN_TXDESC"
                                        If UserLanguage = "EN" Then
                                            v_strTXDESC = Trim(v_strValue)
                                        End If
                                    Case "TXTYPE"
                                        v_strTXTYPE = Trim(v_strValue)
                                        'Case "IMGINDEX"
                                        '    v_intIndex = CInt(Trim(v_strValue))
                                        'Case "CMDALLOW"
                                        '    v_strCMDALLOW = Trim(v_strValue)
                                        'Case "LEV"
                                        '    v_strLEV = Trim(v_strValue)
                                End Select
                            End With
                        Next v_int

                        'If Trim(v_strCMDALLOW) = String.Empty Then
                        '    v_strCMDALLOW = "N"
                        'End If

                        'Check CMDALLOW of user who is assigned
                        If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                            v_arrHashKey = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 4
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If
                        'If Trim(v_strCMDALLOW) = "Y" Then
                        '    v_intIndex = 4
                        'Else
                        '    v_intIndex = 3
                        'End If

                        v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & "T" & "|" & v_strTXTYPE
                        'Add one child node to menu
                        v_NewNode = AddTreeNode(pv_nodeParent, v_strMenuKey, v_strTXDESC, v_intIndex)
                        'Add new value to hashtable
                        'Dim v_strTransHashValue As String
                        hParentsFilter.Add(v_strTLTXCD, v_strPRID)
                        'v_strTransHashValue = v_strMenuKey & "|" & v_strCMDALLOW
                        'hTransFilter.Add(v_strTLTXCD, v_strTransHashValue)
                        'mv_strTransAuthString &= v_strTransHashValue & "#"
                    Next v_intCount
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub Menu_Click(ByVal pv_treeNode As Node)
        'Update mouse pointer
        Me.mv_userAction = mv_MenuClick
        Cursor.Current = Cursors.WaitCursor
        Try
            If pv_treeNode.Key <> String.Empty Then
                If VerifyDataType() Then
                    'ResetKey(mv_node)
                    mv_node = pv_treeNode
                    ShowAccessRight(pv_treeNode)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
        'Update mouse pointer
        Cursor.Current = Cursors.Default
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục ẩn các control phân quy?n --''
    ''---------------------------------------''
    Private Sub DisableAccessRight()
        Try
            'txtTELLERLIMIT.Text = String.Empty
            cboCURRCOD.SelectedIndex = 0
            grbTransAssign.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    ''---------------------------------------------''
    ''-- Th�ủ tục hiển thị các control phân quy?n --''
    ''---------------------------------------------''
    Private Sub EnableAccessRight(ByVal pv_treeNode As Node)
        Try
            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            grbTransAssign.Enabled = True
            If mv_strRight <> String.Empty Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)

                'Enable textboxs
                txtTELLERLIMIT.Enabled = (v_strTeller = "Y")
                txtOFFICERLIMIT.Enabled = (v_strOfficer = "Y")
                txtCHECKERLIMIT.Enabled = (v_strChecker = "Y")

                Dim v_strTXTYPE, v_arr() As String
                v_arr = pv_treeNode.Key.Split("|")
                If v_arr.Length = 4 Then
                    v_strTXTYPE = CStr(v_arr(3)).Trim
                End If
                If (v_strTXTYPE = "D") Or (v_strTXTYPE = "W") Then
                    txtCASHIERLIMIT.Enabled = (v_strCashier = "Y")
                Else
                    txtCASHIERLIMIT.Enabled = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''----------------------------------------------------------''
    ''-- Th�ủ tục ẩn các control phân quy?n, khi �ở chế độ view --''
    ''-- (Chỉ cho phép ch?n xem, ko cho ph�ép sửa thông tin)   --''
    ''----------------------------------------------------------''
    Private Sub DisallowChange()
        Try
            grbTransAssign.Enabled = True
            txtTELLERLIMIT.ReadOnly = True
            txtOFFICERLIMIT.ReadOnly = True
            txtCASHIERLIMIT.ReadOnly = True
        Catch ex As Exception

        End Try

    End Sub
    ''---------------------------------------------''
    ''-- Hiển thị các quy?n v�à hạn mức giao dịch --''
    ''---------------------------------------------''
    Private Sub ShowAccessRight(ByVal pv_treeNode As Node)
        Dim v_strMenuType, v_strModCode, v_strObjName, v_arrMenuKey() As String
        Dim v_strCMDALLOW, v_strSTRAUTH, v_strTRANS, v_strAPPR, v_strCASH As String

        Try
            'If key <> null
            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                If v_arrMenuKey.Length > 1 Then
                    'EnableAccessRight()
                    'Display name of transaction
                    lblTRANS.Text = pv_treeNode.Text
                    'Display access right
                    ControlValue_Changed(cboCURRCOD, pv_treeNode)
                Else
                    lblTRANS.Text = String.Empty
                    DisableAccessRight()
                End If
            Else
                lblTRANS.Text = String.Empty
                DisableAccessRight()
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''------------------------------------------------------------------''
    ''-- Thay đổi các giá trị khi thay đổi trạng thái của các control --''
    ''------------------------------------------------------------------''
    Private Sub ControlValue_Changed(ByVal sender As Object, ByVal pv_treeNode As Node)
        Try
            If pv_treeNode.Items.Count > 0 Then
                DoControlChange(sender, pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        ControlValue_Changed(sender, v_node)
                    Else
                        DoControlChange(sender, v_node)
                    End If
                Next
            Else
                DoControlChange(sender, pv_treeNode)
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''-----------------------------------------------------------''
    ''-- + Mục đích: Cập nhật các giá trị phân quy?n c�ần thiết --''
    ''--   khi giá trị của 1 control nào đó thay đổi           --''
    ''-- + ?�ầu vào: - sender: Control có giá trị thay đổi      --''
    ''--            - pv_treeNode: Node hiện tại của menu tree --''
    ''-- + ?�ầu ra: N/A                                         --''
    ''-- + Tác giả: Nguyễn Nhân Thế                            --''
    ''-- + Ghi chú: N/A                                        --''
    ''-----------------------------------------------------------''
    Private Sub DoControlChange(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_arrMenuKey() As String
        Dim v_strTLTXCD, v_strCMDALLOW, v_strCURRCOD, v_strLIMIT, v_strLEV As String
        Dim v_strHashKey, v_strHashValue, v_arrAuth() As String

        Try
            If Not pv_treeNode Is Nothing Then
                If pv_treeNode.Key <> String.Empty Then

                    EnableAccessRight(pv_treeNode)
                    v_arrMenuKey = pv_treeNode.Key.Split("|")
                    v_strTLTXCD = Trim(v_arrMenuKey(0))
                    'PhuongHT add: bo cac tltxcd khong pai jao dich
                    If v_strTLTXCD.Length > 4 Then
                        Exit Sub
                    End If
                    v_strLEV = v_arrMenuKey(1)
                    If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                        v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                        v_strCMDALLOW = v_arrAuth(2)
                    Else
                        v_strCMDALLOW = "N"
                    End If

                    'If CURRCOD combobox's value has changed 
                    If (sender Is cboCURRCOD) Then
                        v_strCURRCOD = Trim(CStr(cboCURRCOD.SelectedValue))
                        v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|"
                        Dim v_arrLimit() As String
                        'Display access right of TELLER
                        If hTlauthFilter(v_strHashKey & "T") Is Nothing Then
                            txtTELLERLIMIT.Clear()
                        Else
                            txtTELLERLIMIT.Enabled = True
                            v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "T")).Split("|")
                            txtTELLERLIMIT.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboCURRCOD.SelectedValue))

                        End If
                        'Display access right of OFFICER
                        If hTlauthFilter(v_strHashKey & "A") Is Nothing Then
                            txtOFFICERLIMIT.Clear()
                        Else
                            txtOFFICERLIMIT.Enabled = True
                            v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "A")).Split("|")
                            txtOFFICERLIMIT.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboCURRCOD.SelectedValue))
                        End If
                        'Display access right of CASHIER
                        If hTlauthFilter(v_strHashKey & "C") Is Nothing Then
                            txtCASHIERLIMIT.Clear()
                        Else
                            txtCASHIERLIMIT.Enabled = True
                            v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "C")).Split("|")
                            txtCASHIERLIMIT.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboCURRCOD.SelectedValue))
                        End If
                        'Display access right of CHECKER
                        If hTlauthFilter(v_strHashKey & "R") Is Nothing Then
                            txtCHECKERLIMIT.Clear()
                        Else
                            txtCHECKERLIMIT.Enabled = True
                            v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "R")).Split("|")
                            txtCHECKERLIMIT.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboCURRCOD.SelectedValue))
                        End If

                        'If TELLERLIMIT textbox's value has changed
                    ElseIf (sender Is txtTELLERLIMIT) Then
                        v_strCURRCOD = Trim(CStr(cboCURRCOD.SelectedValue))
                        v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "T"
                        If IsNumeric(txtTELLERLIMIT.Text) Then
                            If CDbl(txtTELLERLIMIT.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                txtTELLERLIMIT.Text = FormatNumber(txtTELLERLIMIT.Text, hCurrDecFilter(cboCURRCOD.SelectedValue))
                                If CDbl(txtTELLERLIMIT.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then

                                    'Update new values of transaction limit
                                    v_strLIMIT = Replace(CStr(txtTELLERLIMIT.Text), ",", "").Trim()
                                    v_strHashValue = v_strHashKey & "|" & v_strLIMIT
                                    'Update new value to hash table
                                    If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                        'Remove old value before add new value to hash table and auth's string
                                        Dim v_strOldHashValue As String
                                        v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                        hTlauthFilter.Remove(v_strHashKey)
                                        mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                        hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                        mv_strTlauthString &= v_strHashValue & "#"
                                    Else
                                        'Add new value to hash table and auth's string
                                        hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                        mv_strTlauthString &= v_strHashValue & "#"
                                    End If
                                End If
                            End If

                        ElseIf txtTELLERLIMIT.Text = String.Empty Then
                            If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                'Remove old value
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                hTlauthFilter.Remove(v_strHashKey)
                                mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                            End If
                        End If

                        'If OFFICERLIMIT textbox's value has changed
                    ElseIf (sender Is txtOFFICERLIMIT) Then
                        v_strCURRCOD = Trim(CStr(cboCURRCOD.SelectedValue))
                        v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "A"
                        If IsNumeric(txtOFFICERLIMIT.Text) Then
                            txtOFFICERLIMIT.Text = FormatNumber(txtOFFICERLIMIT.Text, hCurrDecFilter(cboCURRCOD.SelectedValue))
                            If CDbl(txtOFFICERLIMIT.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                v_strLIMIT = Replace(CStr(txtOFFICERLIMIT.Text), ",", "").Trim()
                                v_strHashValue = v_strHashKey & "|" & v_strLIMIT
                                'Update new value to hash table
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value before add new value to hash table and auth's string
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                Else
                                    'Add new value to hash table and auth's string
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                End If
                            End If
                        ElseIf txtOFFICERLIMIT.Text = String.Empty Then
                            If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                'Remove old value
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                hTlauthFilter.Remove(v_strHashKey)
                                mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                            End If
                        End If

                        'If CASHIERLIMIT textbox's value has changed
                    ElseIf (sender Is txtCASHIERLIMIT) Then
                        v_strCURRCOD = Trim(CStr(cboCURRCOD.SelectedValue))
                        v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "C"
                        If IsNumeric(txtCASHIERLIMIT.Text) Then
                            txtCASHIERLIMIT.Text = FormatNumber(txtCASHIERLIMIT.Text, hCurrDecFilter(cboCURRCOD.SelectedValue))
                            If CDbl(txtCASHIERLIMIT.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                v_strLIMIT = Replace(CStr(txtCASHIERLIMIT.Text), ",", "").Trim()
                                v_strHashValue = v_strHashKey & "|" & v_strLIMIT
                                'Update new value to hash table and auth's string
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value before add new value to hash table and auth's string
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                Else
                                    'Add new value to hash table and auth's string
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                End If
                            End If
                        ElseIf txtCASHIERLIMIT.Text = String.Empty Then
                            If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                'Remove old value
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                hTlauthFilter.Remove(v_strHashKey)
                                mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                            End If
                        End If

                        'If CHECKERLIMIT textbox's value has changed
                    ElseIf (sender Is txtCHECKERLIMIT) Then
                        v_strCURRCOD = Trim(CStr(cboCURRCOD.SelectedValue))
                        v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "R"
                        If IsNumeric(txtCHECKERLIMIT.Text) Then
                            txtCHECKERLIMIT.Text = FormatNumber(txtCHECKERLIMIT.Text, hCurrDecFilter(cboCURRCOD.SelectedValue))
                            If CDbl(txtCHECKERLIMIT.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                v_strLIMIT = Replace(CStr(txtCHECKERLIMIT.Text), ",", "").Trim()
                                v_strHashValue = v_strHashKey & "|" & v_strLIMIT
                                'Update new value to hash table and auth's string
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value before add new value to hash table and auth's string
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                Else
                                    'Add new value to hash table and auth's string
                                    hTlauthFilter.Add(v_strHashKey, v_strHashValue)
                                    mv_strTlauthString &= v_strHashValue & "#"
                                End If
                            End If
                        ElseIf txtCHECKERLIMIT.Text = String.Empty Then
                            If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                'Remove old value
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                hTlauthFilter.Remove(v_strHashKey)
                                mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                            End If
                        End If

                    End If

                    'Begin GianhVG add
                    'Change image index
                    ResetMenuKey(pv_treeNode)
                    ChangeImageIndex(pv_treeNode)
                    'End GianhVG add

                    'Allow assign in edit mode only
                    If (ExeFlag = ExecuteFlag.View) Then
                        DisallowChange()
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Cập nhật giá trị khóa của node của menu tree --''
    ''--------------------------------------------------------------''
    Private Sub ResetKey(ByVal pv_treeNode As Node)
        Try
            If pv_treeNode.Items.Count > 0 Then
                ResetMenuKey(pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        ResetMenuKey(pv_treeNode)
                    Else
                        ResetMenuKey(v_node)
                    End If
                Next
            Else
                ResetMenuKey(pv_treeNode)
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Cập nhật giá trị khóa của node của menu tree --''
    ''-- + ?�ầu vào: pv_treeNode: node của menu tree vừa click     --''
    ''-- + ?�ầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub ResetMenuKey(ByVal pv_treeNode As Node)

        Dim v_arrMenuKey(), v_strTLTXCD, v_strCMDALLOW, v_strLEV, v_strMenuType, v_strMenuKey As String
        Dim v_strTellerKey, v_strOfficerKey, v_strCashierKey, v_strCheckerKey As String

        Try

            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                If v_arrMenuKey.Length > 1 Then
                    'Select TLTXCD and old CMDALLOW
                    v_strTLTXCD = Trim(v_arrMenuKey(0))
                    v_strLEV = Trim(v_arrMenuKey(1))
                    v_strMenuType = Trim(v_arrMenuKey(2))
                    'Set CMDALLOW to not allow
                    v_strCMDALLOW = "N"

                    'Check right for transactions
                    Dim v_strResult As String
                    For i As Integer = 0 To cboCURRCOD.Items.Count - 1
                        v_strTellerKey = v_strTLTXCD & "|" & mv_arrCurrCod(i) & "|" & "T"
                        v_strOfficerKey = v_strTLTXCD & "|" & mv_arrCurrCod(i) & "|" & "A"
                        v_strCashierKey = v_strTLTXCD & "|" & mv_arrCurrCod(i) & "|" & "C"
                        v_strCheckerKey = v_strTLTXCD & "|" & mv_arrCurrCod(i) & "|" & "R"

                        'Check Teller
                        v_strResult = hTlauthFilter(v_strTellerKey)
                        'If any transaction's right is exist
                        If Not v_strResult Is Nothing Then
                            v_strCMDALLOW = "Y"
                            Exit For
                        End If
                        'Check Officer
                        v_strResult = hTlauthFilter(v_strOfficerKey)
                        'If any approve's right is exist
                        If Not v_strResult Is Nothing Then
                            v_strCMDALLOW = "Y"
                            Exit For
                        End If
                        'Check Cashier
                        v_strResult = hTlauthFilter(v_strCashierKey)
                        'If any cash's right is exist
                        If Not v_strResult Is Nothing Then
                            v_strCMDALLOW = "Y"
                            Exit For
                        End If
                        'Check Checker
                        v_strResult = hTlauthFilter(v_strCheckerKey)
                        'If any cash's right is exist
                        If Not v_strResult Is Nothing Then
                            v_strCMDALLOW = "Y"
                            Exit For
                        End If
                    Next
                    'Reset menu's key
                    'Update new value to menu key
                    v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & v_strCMDALLOW & "|" & v_strMenuType
                    If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hTransFilter(v_strTLTXCD)
                        hTransFilter.Remove(v_strTLTXCD)
                        mv_strTransAuthString = Replace(mv_strTransAuthString, v_strOldHashValue & "#", "").Trim()
                        hTransFilter.Add(v_strTLTXCD, v_strMenuKey)
                        mv_strTransAuthString &= v_strMenuKey & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hTransFilter.Add(v_strTLTXCD, v_strMenuKey)
                        mv_strTransAuthString &= v_strMenuKey & "#"
                    End If

                    'Set parent tree node
                    'If CInt(v_strLEV) > 1 And mv_userAction = mv_SaveClick Then
                    '    SetParentNodeKey(pv_treeNode)
                    'End If
                    'GianhVG chinh sua
                    If CInt(v_strLEV) > 1 Then
                        SetParentNodeKey(pv_treeNode)
                    End If

                End If
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    ''-------------------------------------------------------------''
    ''-- + Mục đích: Lấy giá trị khóa của các node của menu tree --''
    ''-- + ?�ầu vào: pv_treeNode: node cần lấy giá trị khóa       --''
    ''-- + ?�ầu ra: Chuỗi chứa khóa của node cần lấy              --''
    ''-- + Tác giả: Nguyễn Nhân Thế                              --''
    ''-- + Ghi chú: N/A                                          --''
    ''-------------------------------------------------------------''
    Private Function GetMenuKeyAuthString(ByVal pv_treeNode As Node) As String
        Dim v_strAuth As String = String.Empty
        Dim v_treeNode As Node

        Try
            For Each v_treeNode In pv_treeNode.Items
                If (v_treeNode.Key <> String.Empty) Then
                    If (v_treeNode.Items.Count > 0) Then
                        v_strAuth &= GetMenuKeyAuthString(v_treeNode)
                    Else
                        Dim v_arrMenuKey() As String
                        v_arrMenuKey = v_treeNode.Key.Split("|")
                        If v_arrMenuKey.Length > 1 Then
                            v_strAuth &= v_treeNode.Key & "#"
                        End If
                    End If
                End If
            Next
            Return v_strAuth
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''---------------------------------------------------''
    ''-- + Mục đích: Lấy mã của những NSD thuộc nhóm   --''
    ''-- + ?�ầu vào: pv_strGroupId: Mã nhóm cần lấy     --''
    ''-- + ?�ầu ra: Chuỗi chứa mã của những NSD cần lấy --''
    ''-- + Tác giả: Nguyễn Nhân Thế                    --''
    ''-- + Ghi chú: N/A                                --''
    ''---------------------------------------------------''
    Private Function GetGrpUsrId(ByVal pv_strGroupId As String) As String
        Dim v_strUsersId As String = String.Empty
        Dim v_strUsrInGrpSql, v_strFLDNAME, v_strValue As String
        Dim v_strObjMsg As String

        Try

            ''''==== Select users' name that are in group ====''''
            v_strUsrInGrpSql = "SELECT TLPROFILES.TLID VALUE, TLPROFILES.TLNAME DISPLAY " _
                                    & "FROM TLPROFILES, TLGRPUSERS, TLGROUPS " _
                                    & "WHERE TLPROFILES.TLID = TLGRPUSERS.TLID AND TLGRPUSERS.GRPID = TLGROUPS.GRPID AND TLGROUPS.GRPID = '" & pv_strGroupId & "' ORDER BY TLPROFILES.TLNAME"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strUsrInGrpSql)
            Dim v_wsIngrp As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsIngrp.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "VALUE"
                            v_strUsersId &= v_strValue & "#"
                    End Select
                Next
            Next

            Return v_strUsersId
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''----------------------------------------------------------------''
    ''-- + Mục đích: Kiểm tra kiểu dữ liệu nhập vào của các hạn mức --''
    ''-- + ?�ầu vào: N/A                                             --''
    ''-- + ?�ầu ra: True nếu là kiểu số, False nếu là kiểu khác      --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                 --''
    ''-- + Ghi chú: N/A                                             --''
    ''----------------------------------------------------------------''
    Private Function VerifyDataType() As Boolean
        Try
            'Check Teller limit
            If txtTELLERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtTELLERLIMIT.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransAssign.TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    'MsgBox(mv_ResourceManager.GetString("frmTransAssign.TellerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtTELLERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtTELLERLIMIT.Text) < 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmTransAssign.TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox(mv_ResourceManager.GetString("frmTransAssign.TransMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtTELLERLIMIT.Focus()
                    Return False
                End If
            End If

            'Check Officer limit
            If txtOFFICERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtOFFICERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtOFFICERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtOFFICERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtOFFICERLIMIT.Focus()
                    Return False

                End If
            End If

            'Check Cashier limit
            If txtCASHIERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtCASHIERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtCASHIERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtCASHIERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtCASHIERLIMIT.Focus()
                    Return False
                End If
            End If

            'Check Checker limit
            If txtCHECKERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtCHECKERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtCHECKERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtCHECKERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("frmTransAssign.CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtCHECKERLIMIT.Focus()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Set lại key của các node cha của 1 node      --''
    ''-- + ?�ầu vào: pv_treeNode: node có các node cha cần set key --''
    ''-- + ?�ầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub SetParentNodeKey(ByVal pv_treeNode As Node)
        Dim v_strPRID, v_strLEV, v_strCMDID, v_strAUTH, v_strHashValue, v_arrMenuKey() As String
        Dim v_strCMDALLOW, v_strPRLEV, v_strMenuType, v_arrAuth() As String
        Dim v_strPRCMDALLOW, v_strOldHashValue, v_arrChild() As String
        Dim v_intPRLEV, v_intChildNum As Integer

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_arrAuth = CStr(hTransFilter(v_strCMDID)).Split("|")
            v_strCMDALLOW = Mid(CStr(v_arrAuth(2)), 1, 1)

            If v_strCMDALLOW = "Y" Then
                For i As Integer = 0 To CInt(v_strLEV) - 2
                    v_strPRID = hParentsFilter(v_strCMDID)
                    v_intPRLEV = CInt(v_strLEV) - (i + 1)
                    v_strPRLEV = CStr(v_intPRLEV)

                    If Not hTransFilter(v_strPRID) Is Nothing Then
                        v_arrAuth = CStr(hTransFilter(v_strPRID)).Split("|")
                        'v_strPRLEV = v_arrAuth(1)
                        v_strAUTH = v_arrAuth(2)
                        v_strMenuType = v_arrAuth(3)
                        If Len(Trim(v_strAUTH)) = 1 Then
                            If v_strAUTH = "N" Then
                                v_strAUTH = "Y"
                            End If
                        ElseIf Len(Trim(v_strAUTH)) = 5 Then
                            v_strPRCMDALLOW = Mid(v_strAUTH, 1, 1)
                            If v_strPRCMDALLOW = "N" Then
                                v_strPRCMDALLOW = "Y"
                            End If
                            v_strAUTH = v_strPRCMDALLOW & Mid(v_strAUTH, 2, 4)
                        End If
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                        'Remove old value before add new value to hash table and auth's string
                        v_strOldHashValue = hTransFilter(v_strPRID)
                        hTransFilter.Remove(v_strPRID)
                        mv_strTransAuthString = Replace(mv_strTransAuthString, v_strOldHashValue & "#", "").Trim
                        hTransFilter.Add(v_strPRID, v_strHashValue)
                        mv_strTransAuthString &= v_strHashValue & "#"
                    Else
                        v_strAUTH = "YNNNN"
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                        'Add new value to hash table and auth's string
                        hTransFilter.Add(v_strPRID, v_strHashValue)
                        mv_strTransAuthString &= v_strHashValue & "#"
                    End If
                    If Not hChildrenFilter(v_strPRID) Is Nothing Then
                        If (CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Then
                            v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                            v_strMenuType = CStr(v_arrChild(2))
                            v_intChildNum = CInt(CStr(v_arrChild(3))) + 1
                            'Update Children hashtable
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strMenuType & "|" & CStr(v_intChildNum)
                            hChildrenFilter.Remove(v_strPRID)
                            hChildrenFilter.Add(v_strPRID, v_strHashValue)
                        Else
                            v_intChildNum = -1
                        End If
                    Else
                        v_intChildNum = 1
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & "M" & "|" & CStr(v_intChildNum)
                        hChildrenFilter.Add(v_strPRID, v_strHashValue)
                    End If

                    v_strCMDID = v_strPRID
                Next

            ElseIf v_strCMDALLOW = "N" Then
                For i As Integer = 0 To CInt(v_strLEV) - 2
                    v_strPRID = hParentsFilter(v_strCMDID)
                    v_intPRLEV = CInt(v_strLEV) - (i + 1)
                    v_strPRLEV = CStr(v_intPRLEV)

                    If Not hChildrenFilter(v_strPRID) Is Nothing Then
                        If (CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Then
                            v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                            v_strMenuType = CStr(v_arrChild(2))
                            v_intChildNum = CInt(CStr(v_arrChild(3)))
                            If v_intChildNum > 0 Then
                                v_intChildNum = v_intChildNum - 1
                            End If
                            'Update Children hashtable
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strMenuType & "|" & CStr(v_intChildNum)
                            hChildrenFilter.Remove(v_strPRID)
                            hChildrenFilter.Add(v_strPRID, v_strHashValue)
                        Else
                            v_intChildNum = -1
                        End If
                    Else
                        v_intChildNum = 0
                    End If

                    If Not hTransFilter(v_strPRID) Is Nothing Then
                        If v_intChildNum = 0 Then
                            v_arrAuth = CStr(hTransFilter(v_strPRID)).Split("|")
                            'v_strPRLEV = v_arrAuth(1)
                            v_strAUTH = v_arrAuth(2)
                            v_strMenuType = v_arrAuth(3)
                            If Len(Trim(v_strAUTH)) = 1 Then
                                If v_strAUTH = "Y" Then
                                    v_strAUTH = "N"
                                End If
                            ElseIf Len(Trim(v_strAUTH)) = 5 Then
                                v_strAUTH = "NNNNN"
                            End If
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                            'Remove old value before add new value to hash table and auth's string
                            v_strOldHashValue = hTransFilter(v_strPRID)
                            hTransFilter.Remove(v_strPRID)
                            mv_strTransAuthString = Replace(mv_strTransAuthString, v_strOldHashValue & "#", "").Trim
                            hTransFilter.Add(v_strPRID, v_strHashValue)
                            mv_strTransAuthString &= v_strHashValue & "#"
                        End If

                    Else

                    End If
                    v_strCMDID = v_strPRID
                Next

            Else

            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



    ''==========================================================''
    '' Thủ tục lấy mã của node cha của các node trong menu tree ''
    ''==========================================================''

    Private Sub GetParents(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount As Integer
        Dim v_strMenuKey, v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strLEV As String

        v_strMenuKey = ""
        v_strFLDNAME = ""
        v_strValue = ""
        v_strPRID = ""
        v_strCMDID = ""
        v_strLEV = ""

        Try
            If IsShown Then
                v_strObjMsg = ""
                If AssignType = "User" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetUserParentMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId, "GetUserParentMenu")
                End If

                Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                m_ws.Message(v_strObjMsg)

                XmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "PRID"
                                    v_strPRID = Trim(v_strValue)
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    If Len(Trim(v_strPRID)) = 0 Then
                        v_strMenuKey = v_strCMDID & "|" & v_strLEV
                        'Get ID of child node
                        GetChildren(CStr(v_strMenuKey))
                    End If
                Next v_intCount
            Else

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub GetChildren(ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strLast, v_strMenuType, v_strLEV As String
        Dim v_strModCode, v_strObjName, v_strMenuKey, v_arrHashKey() As String
        Dim v_strCMDALLOW, v_strSTRAUTH, v_strFuncHashValue As String
        Dim v_NewNode As New Node

        Try
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetUserChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId & "|" & pv_strKey, "GetUserChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "PRID"
                                v_strPRID = Trim(v_strValue)
                            Case "CMDID"
                                v_strCMDID = Trim(v_strValue)
                            Case "LEV"
                                v_strLEV = Trim(v_strValue)
                            Case "LAST"
                                v_strLast = Trim(v_strValue)
                            Case "MENUTYPE"
                                v_strMenuType = Trim(v_strValue)
                        End Select
                    End With
                Next v_int

                ''Add new value to hashtable
                If hParentsFilter(v_strCMDID) Is Nothing Then
                    hParentsFilter.Add(v_strCMDID, v_strPRID)
                End If

                'Set menu's key
                v_strMenuKey = v_strCMDID & "|" & v_strLEV
                'Add new node to menu tree
                If (v_strLast <> "Y") And (v_strMenuType <> "T") And (v_strMenuType <> "R") Then
                    GetChildren(v_strMenuKey)
                End If

            Next v_intCount
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ChangeImageIndex(ByRef pv_treeNode As Node)
        Dim v_arrMenuKey() As String
        Dim v_strAuth, v_strTLTXCD, v_arrAuth() As String

        Try

            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strTLTXCD = Trim(v_arrMenuKey(0))
            If v_strTLTXCD.Length = 4 Then
                If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                    v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                    If v_arrAuth(2) = "Y" Then
                        pv_treeNode.ImageIndex = 4
                    Else
                        pv_treeNode.ImageIndex = 3
                    End If
                End If
            Else
                'Check CMDALLOW of user who is assigned
                If Not (v_strTLTXCD Is Nothing Or v_strTLTXCD.Length = 0) Then
                    If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                        v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                        If v_arrAuth(2) = "Y" Then
                            pv_treeNode.ImageIndex = 5
                        Else
                            pv_treeNode.ImageIndex = 0
                        End If
                    Else
                        pv_treeNode.ImageIndex = 0
                    End If
                End If
                
            End If
            'Set imageindex for parent
            If pv_treeNode.Items.Count = 0 And v_strTLTXCD.Length = 4 Then 'Node con
                Dim pv_parentNode As Node = pv_treeNode.ParentItem
                If Not pv_parentNode Is Nothing Then
                    If pv_treeNode.ImageIndex = 4 Then
                        pv_parentNode.ImageIndex = 5
                    Else
                        Dim i, count As Integer
                        count = 0
                        For Each objNode As Node In pv_parentNode.Items
                            If objNode.ImageIndex = 4 Then
                                count = count + 1
                            End If
                        Next
                        If count > 0 Then
                            pv_parentNode.ImageIndex = 5
                        Else
                            pv_parentNode.ImageIndex = 0
                        End If
                    End If
                End If
            End If

            If pv_treeNode.Items.Count > 0 Then
                For Each v_treeNode As Node In pv_treeNode.Items
                    ChangeImageIndex(v_treeNode)
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Form Events "
    Private Sub frmTransAssign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub pnlTransAssign_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DoResizePanel()
    End Sub

    Private Sub tbnSave_Click(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnSave.Click
        OnSave()
    End Sub

    Private Sub tbnCancel_Click(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnCancel.Click
        OnClose()
    End Sub

    Private Sub stvTransMenu_ItemClick(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles stvTransMenu.ItemClick
        Menu_Click(stvTransMenu.SelectedItem)
    End Sub

    Private Sub cboCURRCOD_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCURRCOD.SelectedValueChanged
        ControlValue_Changed(cboCURRCOD, stvTransMenu.SelectedItem)
    End Sub

    'Private Sub ckbTRANSLIMIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ControlValue_Changed(ckbTRANSLIMIT, stvTransMenu.SelectedItem)
    'End Sub

    'Private Sub ckbAPPRLIMIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ControlValue_Changed(ckbAPPRLIMIT, stvTransMenu.SelectedItem)
    'End Sub

    'Private Sub ckbCASHLIMIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ControlValue_Changed(ckbCASHLIMIT, stvTransMenu.SelectedItem)
    'End Sub

    Private Sub txtTELLERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.Leave
        ControlValue_Changed(txtTELLERLIMIT, mv_node)
    End Sub

    Private Sub txtOFFICERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOFFICERLIMIT.Leave
        ControlValue_Changed(txtOFFICERLIMIT, mv_node)
    End Sub

    Private Sub txtCASHIERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASHIERLIMIT.Leave
        ControlValue_Changed(txtCASHIERLIMIT, mv_node)
    End Sub

    Private Sub txtCHECKERLIMIT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.Leave
        ControlValue_Changed(txtCHECKERLIMIT, mv_node)
    End Sub

    Private Sub txtTELLERLIMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.Click
        mv_textbox = txtTELLERLIMIT
    End Sub

    Private Sub txtTELLERLIMIT_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.GotFocus
        mv_textbox = txtTELLERLIMIT
    End Sub

    Private Sub txtOFFICERLIMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOFFICERLIMIT.Click
        mv_textbox = txtOFFICERLIMIT
    End Sub

    Private Sub txtOFFICERLIMIT_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOFFICERLIMIT.GotFocus
        mv_textbox = txtOFFICERLIMIT
    End Sub

    Private Sub txtCASHIERLIMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASHIERLIMIT.Click
        mv_textbox = txtCASHIERLIMIT
    End Sub

    Private Sub txtCASHIERLIMIT_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASHIERLIMIT.GotFocus
        mv_textbox = txtCASHIERLIMIT
    End Sub

    Private Sub txtCHECKERLIMIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.Click
        mv_textbox = txtCHECKERLIMIT
    End Sub

    Private Sub txtCHECKERLIMIT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.GotFocus
        mv_textbox = txtCHECKERLIMIT
    End Sub

    Private Sub frmTransAssign_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

#End Region

    
End Class
