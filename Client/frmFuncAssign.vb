Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Xceed.SmartUI.Controls.TreeView
Imports CommonLibrary
Imports AppCore
Imports AppCore.GridEx
Imports AppCore.ComboBoxEx

Public Class frmFuncAssign
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        'Public Sub New()
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
    Friend WithEvents imlMenu As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents stvFuncMenu As Xceed.SmartUI.Controls.TreeView.SmartTreeView
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents nodeDirect As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents pnlToolBar As System.Windows.Forms.Panel
    Friend WithEvents pnlFuncAssign As System.Windows.Forms.Panel
    Friend WithEvents ckbDELETE As System.Windows.Forms.CheckBox
    Friend WithEvents ckbEDIT As System.Windows.Forms.CheckBox
    Friend WithEvents ckbADD As System.Windows.Forms.CheckBox
    Friend WithEvents ckbINQUIRY As System.Windows.Forms.CheckBox
    Friend WithEvents ckbACCESS As System.Windows.Forms.CheckBox
    Friend WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents lblFUNCTION As System.Windows.Forms.Label
    Friend WithEvents tbnSave As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents imlToolBar As System.Windows.Forms.ImageList
    Friend WithEvents tbnCancel As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents grbAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents lblACCESS As System.Windows.Forms.Label
    Friend WithEvents lblINQUIRY As System.Windows.Forms.Label
    Friend WithEvents lblADD As System.Windows.Forms.Label
    Friend WithEvents lblEDIT As System.Windows.Forms.Label
    Friend WithEvents ckbAPPROVE As System.Windows.Forms.CheckBox
    Friend WithEvents lblAPPROVE As System.Windows.Forms.Label
    Friend WithEvents lblDELETE As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFuncAssign))
        Me.imlMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.stvFuncMenu = New Xceed.SmartUI.Controls.TreeView.SmartTreeView(Me.components)
        Me.nodeDirect = New Xceed.SmartUI.Controls.TreeView.Node("@VSTP 1.0", 2)
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.pnlToolBar = New System.Windows.Forms.Panel
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnSave = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnSave", 1)
        Me.tbnCancel = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnCancel", 0)
        Me.imlToolBar = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlFuncAssign = New System.Windows.Forms.Panel
        Me.lblFUNCTION = New System.Windows.Forms.Label
        Me.grbAccessRight = New System.Windows.Forms.GroupBox
        Me.ckbAPPROVE = New System.Windows.Forms.CheckBox
        Me.lblAPPROVE = New System.Windows.Forms.Label
        Me.lblDELETE = New System.Windows.Forms.Label
        Me.lblEDIT = New System.Windows.Forms.Label
        Me.lblADD = New System.Windows.Forms.Label
        Me.lblINQUIRY = New System.Windows.Forms.Label
        Me.lblACCESS = New System.Windows.Forms.Label
        Me.ckbDELETE = New System.Windows.Forms.CheckBox
        Me.ckbEDIT = New System.Windows.Forms.CheckBox
        Me.ckbADD = New System.Windows.Forms.CheckBox
        Me.ckbINQUIRY = New System.Windows.Forms.CheckBox
        Me.ckbACCESS = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        CType(Me.stvFuncMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolBar.SuspendLayout()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFuncAssign.SuspendLayout()
        Me.grbAccessRight.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 455)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 50)
        Me.Panel1.TabIndex = 5
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "Caption"
        Me.lblCaption.Text = "lblCaption"
        '
        'stvFuncMenu
        '
        Me.stvFuncMenu.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.stvFuncMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.stvFuncMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stvFuncMenu.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.nodeDirect})
        Me.stvFuncMenu.ItemsImageList = Me.imlMenu
        Me.stvFuncMenu.Location = New System.Drawing.Point(3, 50)
        Me.stvFuncMenu.Name = "stvFuncMenu"
        Me.stvFuncMenu.Size = New System.Drawing.Size(292, 405)
        Me.stvFuncMenu.TabIndex = 6
        Me.stvFuncMenu.Text = "stvFuncMenu"
        '
        'nodeDirect
        '
        Me.nodeDirect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeDirect.ImageIndex = 2
        Me.nodeDirect.Name = "nodeDirect"
        Me.nodeDirect.Text = "@VSTP 1.0"
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(295, 50)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 405)
        Me.Splitter2.TabIndex = 7
        Me.Splitter2.TabStop = False
        '
        'pnlToolBar
        '
        Me.pnlToolBar.Controls.Add(Me.SmartToolBar1)
        Me.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlToolBar.Location = New System.Drawing.Point(298, 50)
        Me.pnlToolBar.Name = "pnlToolBar"
        Me.pnlToolBar.Size = New System.Drawing.Size(336, 40)
        Me.pnlToolBar.TabIndex = 8
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
        'imlToolBar
        '
        Me.imlToolBar.ImageStream = CType(resources.GetObject("imlToolBar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolBar.TransparentColor = System.Drawing.Color.Transparent
        Me.imlToolBar.Images.SetKeyName(0, "")
        Me.imlToolBar.Images.SetKeyName(1, "")
        '
        'pnlFuncAssign
        '
        Me.pnlFuncAssign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFuncAssign.Controls.Add(Me.lblFUNCTION)
        Me.pnlFuncAssign.Controls.Add(Me.grbAccessRight)
        Me.pnlFuncAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFuncAssign.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFuncAssign.Location = New System.Drawing.Point(298, 90)
        Me.pnlFuncAssign.Name = "pnlFuncAssign"
        Me.pnlFuncAssign.Size = New System.Drawing.Size(336, 365)
        Me.pnlFuncAssign.TabIndex = 9
        '
        'lblFUNCTION
        '
        Me.lblFUNCTION.AutoSize = True
        Me.lblFUNCTION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFUNCTION.Location = New System.Drawing.Point(10, 15)
        Me.lblFUNCTION.Name = "lblFUNCTION"
        Me.lblFUNCTION.Size = New System.Drawing.Size(75, 13)
        Me.lblFUNCTION.TabIndex = 4
        Me.lblFUNCTION.Tag = "FUNCTION"
        Me.lblFUNCTION.Text = "lblFUNCTION"
        Me.lblFUNCTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbAccessRight
        '
        Me.grbAccessRight.Controls.Add(Me.ckbAPPROVE)
        Me.grbAccessRight.Controls.Add(Me.lblAPPROVE)
        Me.grbAccessRight.Controls.Add(Me.lblDELETE)
        Me.grbAccessRight.Controls.Add(Me.lblEDIT)
        Me.grbAccessRight.Controls.Add(Me.lblADD)
        Me.grbAccessRight.Controls.Add(Me.lblINQUIRY)
        Me.grbAccessRight.Controls.Add(Me.lblACCESS)
        Me.grbAccessRight.Controls.Add(Me.ckbDELETE)
        Me.grbAccessRight.Controls.Add(Me.ckbEDIT)
        Me.grbAccessRight.Controls.Add(Me.ckbADD)
        Me.grbAccessRight.Controls.Add(Me.ckbINQUIRY)
        Me.grbAccessRight.Controls.Add(Me.ckbACCESS)
        Me.grbAccessRight.Location = New System.Drawing.Point(10, 45)
        Me.grbAccessRight.Name = "grbAccessRight"
        Me.grbAccessRight.Size = New System.Drawing.Size(280, 200)
        Me.grbAccessRight.TabIndex = 1
        Me.grbAccessRight.TabStop = False
        Me.grbAccessRight.Tag = "AccessRight"
        Me.grbAccessRight.Text = "grbAccessRight"
        '
        'ckbAPPROVE
        '
        Me.ckbAPPROVE.Location = New System.Drawing.Point(15, 172)
        Me.ckbAPPROVE.Name = "ckbAPPROVE"
        Me.ckbAPPROVE.Size = New System.Drawing.Size(20, 24)
        Me.ckbAPPROVE.TabIndex = 12
        Me.ckbAPPROVE.Tag = ""
        '
        'lblAPPROVE
        '
        Me.lblAPPROVE.AutoSize = True
        Me.lblAPPROVE.Location = New System.Drawing.Point(40, 177)
        Me.lblAPPROVE.Name = "lblAPPROVE"
        Me.lblAPPROVE.Size = New System.Drawing.Size(63, 13)
        Me.lblAPPROVE.TabIndex = 11
        Me.lblAPPROVE.Tag = "lblAPPROVE"
        Me.lblAPPROVE.Text = "lblAPPROVE"
        Me.lblAPPROVE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDELETE
        '
        Me.lblDELETE.AutoSize = True
        Me.lblDELETE.Location = New System.Drawing.Point(40, 144)
        Me.lblDELETE.Name = "lblDELETE"
        Me.lblDELETE.Size = New System.Drawing.Size(53, 13)
        Me.lblDELETE.TabIndex = 9
        Me.lblDELETE.Tag = "DELETE"
        Me.lblDELETE.Text = "lblDELETE"
        Me.lblDELETE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEDIT
        '
        Me.lblEDIT.AutoSize = True
        Me.lblEDIT.Location = New System.Drawing.Point(40, 114)
        Me.lblEDIT.Name = "lblEDIT"
        Me.lblEDIT.Size = New System.Drawing.Size(40, 13)
        Me.lblEDIT.TabIndex = 8
        Me.lblEDIT.Tag = "EDIT"
        Me.lblEDIT.Text = "lblEDIT"
        Me.lblEDIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADD
        '
        Me.lblADD.AutoSize = True
        Me.lblADD.Location = New System.Drawing.Point(40, 84)
        Me.lblADD.Name = "lblADD"
        Me.lblADD.Size = New System.Drawing.Size(38, 13)
        Me.lblADD.TabIndex = 7
        Me.lblADD.Tag = "ADD"
        Me.lblADD.Text = "lblADD"
        Me.lblADD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblINQUIRY
        '
        Me.lblINQUIRY.AutoSize = True
        Me.lblINQUIRY.Location = New System.Drawing.Point(40, 54)
        Me.lblINQUIRY.Name = "lblINQUIRY"
        Me.lblINQUIRY.Size = New System.Drawing.Size(60, 13)
        Me.lblINQUIRY.TabIndex = 6
        Me.lblINQUIRY.Tag = "INQUIRY"
        Me.lblINQUIRY.Text = "lblINQUIRY"
        Me.lblINQUIRY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACCESS
        '
        Me.lblACCESS.AutoSize = True
        Me.lblACCESS.Location = New System.Drawing.Point(40, 24)
        Me.lblACCESS.Name = "lblACCESS"
        Me.lblACCESS.Size = New System.Drawing.Size(56, 13)
        Me.lblACCESS.TabIndex = 5
        Me.lblACCESS.Tag = "ACCESS"
        Me.lblACCESS.Text = "lblACCESS"
        Me.lblACCESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbDELETE
        '
        Me.ckbDELETE.Location = New System.Drawing.Point(15, 140)
        Me.ckbDELETE.Name = "ckbDELETE"
        Me.ckbDELETE.Size = New System.Drawing.Size(20, 24)
        Me.ckbDELETE.TabIndex = 4
        Me.ckbDELETE.Tag = ""
        '
        'ckbEDIT
        '
        Me.ckbEDIT.Location = New System.Drawing.Point(15, 110)
        Me.ckbEDIT.Name = "ckbEDIT"
        Me.ckbEDIT.Size = New System.Drawing.Size(20, 24)
        Me.ckbEDIT.TabIndex = 3
        Me.ckbEDIT.Tag = ""
        '
        'ckbADD
        '
        Me.ckbADD.Location = New System.Drawing.Point(15, 80)
        Me.ckbADD.Name = "ckbADD"
        Me.ckbADD.Size = New System.Drawing.Size(20, 24)
        Me.ckbADD.TabIndex = 2
        Me.ckbADD.Tag = ""
        '
        'ckbINQUIRY
        '
        Me.ckbINQUIRY.Location = New System.Drawing.Point(15, 50)
        Me.ckbINQUIRY.Name = "ckbINQUIRY"
        Me.ckbINQUIRY.Size = New System.Drawing.Size(20, 24)
        Me.ckbINQUIRY.TabIndex = 1
        Me.ckbINQUIRY.Tag = ""
        '
        'ckbACCESS
        '
        Me.ckbACCESS.Location = New System.Drawing.Point(15, 20)
        Me.ckbACCESS.Name = "ckbACCESS"
        Me.ckbACCESS.Size = New System.Drawing.Size(20, 24)
        Me.ckbACCESS.TabIndex = 0
        Me.ckbACCESS.Tag = ""
        '
        'frmFuncAssign
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 455)
        Me.Controls.Add(Me.pnlFuncAssign)
        Me.Controls.Add(Me.pnlToolBar)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.stvFuncMenu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFuncAssign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmFuncAssign"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stvFuncMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolBar.ResumeLayout(False)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFuncAssign.ResumeLayout(False)
        Me.pnlFuncAssign.PerformLayout()
        Me.grbAccessRight.ResumeLayout(False)
        Me.grbAccessRight.PerformLayout()
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
    Private mv_strTellerName As String
    Private mv_strUserId As String
    Private mv_strUserName As String
    Private mv_strGroupId As String
    Private mv_strGroupName As String
    Private mv_strAssignType As String
    Private mv_strLocalObject As String
    Private mv_strFuncAuth As String

    Dim hParentsFilter As New Hashtable
    Dim hFunctionFilter As New Hashtable

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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
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
#End Region

#Region " Overridable methods "
    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            DisableAssignment()
            DoResizePanel()
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmFuncAssign-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            FillData()
            DisplayMenus()
        Catch ex As Exception

        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmFuncAssign." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmFuncAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmFuncAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmFuncAssign." & v_ctrl.Name)
                End If
            Next

            'Load caption of controls in toolbar
            tbnSave.Text = mv_ResourceManager.GetString("frmFuncAssign.tbnSave")
            tbnCancel.Text = mv_ResourceManager.GetString("frmFuncAssign.tbnCancel")

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmFuncAssign")
            If AssignType = "User" Then
                lblCaption.Text = mv_ResourceManager.GetString("frmFuncAssign.lblCaption0") & UserName
            ElseIf AssignType = "Group" Then
                lblCaption.Text = mv_ResourceManager.GetString("frmFuncAssign.lblCaption1") & GroupName
            End If

            'Disable control if in view mode
            If (ExeFlag = ExecuteFlag.View) Then
                tbnSave.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''------------------------------------------------''
    ''-- Lấy các thông tin phân quyền đã có của NSD --''
    ''------------------------------------------------''
    Private Sub FillData()
        Try
            Dim v_strFLDNAME, v_strValue As String

            'Get Function access right of user
            Dim v_strCmdInquiryFunc, v_strFuncObjMsg As String
            If AssignType = "User" Then
                v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                                    & "from CMDMENU M, CMDAUTH A " _
                                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                                    & "and A.AUTHID = '" & UserId & "' and A.CMDTYPE = 'M'" _
                                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryFunc)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                                    & "from CMDMENU M, CMDAUTH A " _
                                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                                    & "and A.AUTHID = '" & GroupId & "' and A.CMDTYPE = 'M'" _
                                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryFunc)
            End If

            Dim v_wsFunc As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsFunc.Message(v_strFuncObjMsg)

            Dim v_xmlFuncDocument As New Xml.XmlDocument
            Dim v_nodeFuncList As Xml.XmlNodeList

            v_xmlFuncDocument.LoadXml(v_strFuncObjMsg)
            v_nodeFuncList = v_xmlFuncDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strCMDID, v_strLEV, v_strCMDALLOW, v_strAUTH, v_strHashKey, v_strHashValue As String
            For i As Integer = 0 To v_nodeFuncList.Count - 1
                For j As Integer = 0 To v_nodeFuncList.Item(i).ChildNodes.Count - 1
                    With v_nodeFuncList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "CMDID"
                            v_strCMDID = v_strValue
                        Case "LEV"
                            v_strLEV = v_strValue
                        Case "CMDALLOW"
                            v_strCMDALLOW = v_strValue
                        Case "STRAUTH"
                            v_strAUTH = v_strValue
                    End Select
                Next
                'Fill to hashtable
                v_strHashKey = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH
                hFunctionFilter.Add(v_strCMDID, v_strHashKey)
                mv_strFuncAuth &= v_strHashKey & "#"
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục thay đổi kích thước panel --''
    ''---------------------------------------''
    Private Sub DoResizePanel()
        Try
            grbAccessRight.Width = pnlFuncAssign.Width - 20
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục ẩn các control phân quyền --''
    ''---------------------------------------''
    Private Sub DisableAssignment()
        Try
            grbAccessRight.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------------''
    ''-- Thủ tục hiển thị các control phân quyền --''
    ''---------------------------------------------''
    Private Sub EnableAssignment()
        Try
            grbAccessRight.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''-----------------------------------------------------''
    ''-- Thủ tục ẩn các control phân quyền (chế độ View) --''
    ''-----------------------------------------------------''
    Private Sub DisallowChange()
        Try
            ckbACCESS.Enabled = False
            ckbINQUIRY.Enabled = False
            ckbADD.Enabled = False
            ckbEDIT.Enabled = False
            ckbDELETE.Enabled = False
            'AnhVT Added - Maintenance Approval Retro
            ckbAPPROVE.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    ''----------------------------------------------''
    ''-- Thủ tục ghi nội dung phân quyền vào CSDL --''
    ''----------------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_strAllStrAuth, v_strGrpUsrId, v_strAuthString As String

        Try

            If AssignType = "User" Then
                'Get strAuth from menu            
                'v_strAllStrAuth = GetAuthString(stvFuncMenu.Items(0))
                v_strAllStrAuth = UserId & "$" & mv_strFuncAuth

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllStrAuth, "FunctionAssignment")
            ElseIf AssignType = "Group" Then
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get strAuth from menu            
                'v_strStrAuth = GetAuthString(stvFuncMenu.Items(0))
                v_strAuthString = mv_strFuncAuth
                'Add Groupid and Usersid string to strAuth
                v_strAllStrAuth = GroupId & "$" & v_strAuthString & "$" & v_strGrpUsrId

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllStrAuth, "FunctionAssignment")
            End If

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

            'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
            Dim v_strErrorSource, v_strErrorMessage As String

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            ''Reset lai Index Inmage
            ChangeImageIndex(stvFuncMenu.Items(0))

            MsgBox(mv_ResourceManager.GetString("frmFuncAssign.SavingSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'Me.Close()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_ResourceManager.GetString("frmFuncAssign.SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Private Function AddTreeNode(ByRef pv_nodeParent As Node, _
                                     ByVal pv_strKey As String, _
                                     ByVal pv_strName As String, _
                                     ByVal pv_strLast As String, _
                                     Optional ByVal pv_intImageIdx As Integer = 0) As Node
        Try
            'Create new node
            Dim v_node As New Node(pv_strName, pv_intImageIdx)

            v_node.Key = pv_strKey
            v_node.Text = pv_strName
            v_node.ToolTipText = pv_strName
            'Add node to menu tree
            pv_nodeParent.Items.Add(v_node)
            Return v_node
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub DisplayMenus(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFuncHashValue, v_strMenuKey, v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strCMDALLOW, v_strSTRAUTH, v_strLEV, v_arrHashKey() As String

        Try
            If IsShown Then
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
                                Case "CMDNAME"
                                    If UserLanguage <> "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                Case "EN_CMDNAME"
                                    If UserLanguage = "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                    'Case "IMGINDEX"
                                    '    v_intIndex = CInt(Trim(v_strValue))
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                    'Case "CMDALLOW"
                                    '    v_strCMDALLOW = Trim(v_strValue)
                                    'Case "STRAUTH"
                                    '    v_strSTRAUTH = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    If Len(Trim(v_strPRID)) = 0 Then
                        'If v_strCMDALLOW = "" Then
                        '    v_strCMDALLOW = "N"
                        'End If
                        'If Trim(v_strCMDALLOW) = "Y" Then
                        '    v_intIndex = 4
                        'Else
                        '    v_intIndex = 0
                        'End If
                        'If v_strSTRAUTH = "" Then
                        '    v_strSTRAUTH = "NNNN"
                        'End If

                        'Check CMDALLOW of user who is assigned
                        If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                            v_arrHashKey = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 4
                            Else
                                v_intIndex = 0
                            End If
                        Else
                            v_intIndex = 0
                        End If

                        v_strMenuKey = v_strCMDID & "|" & v_strLEV

                        Dim v_node As New Node(v_strCmdName, v_intIndex)
                        v_node.Key = CStr(v_strMenuKey)
                        v_node.ToolTipText = v_strCmdName
                        v_node.Expanded = False

                        Me.stvFuncMenu.Items(0).Items.Add(v_node)
                        AddChildMenu(stvFuncMenu.Items(0).Items(CStr(v_strMenuKey)), CStr(v_strMenuKey))
                        ''Add value to Function hashtable and FuncAuth string
                        'v_strFuncHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strSTRAUTH
                        'hFunctionFilter.Add(v_strCMDID, v_strFuncHashValue)
                        'mv_strFuncAuth &= v_strFuncHashValue & "#"
                    End If
                Next v_intCount
            Else
                Me.stvFuncMenu.Items(0).Items.Clear()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
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

            If Not pv_nodeParent Is Nothing Then
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "PRID"
                                    v_strPRID = Trim(v_strValue)
                                Case "CMDNAME"
                                    If UserLanguage <> "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                Case "EN_CMDNAME"
                                    If UserLanguage = "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                    'Case "IMGINDEX"
                                    '    v_intIndex = CInt(Trim(v_strValue))
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "LAST"
                                    v_strLast = Trim(v_strValue)
                                Case "MODCODE"
                                    v_strModCode = Trim(v_strValue)
                                Case "OBJNAME"
                                    v_strObjName = Trim(v_strValue)
                                Case "MENUTYPE"
                                    v_strMenuType = Trim(v_strValue)
                                Case "CMDALLOW"
                                    v_strCMDALLOW = Trim(v_strValue)
                                Case "STRAUTH"
                                    v_strSTRAUTH = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    'Check CMDALLOW of user who is assigned
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        v_arrHashKey = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                        v_strCMDALLOW = Trim(v_arrHashKey(2))
                        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                        If (v_strCMDALLOW = "Y") And (Trim(v_strLast) = "Y") Then
                            v_intIndex = 5
                        ElseIf (Trim(v_strCMDALLOW) = "Y") And (Trim(v_strLast) <> "Y") Then
                            v_intIndex = 4
                        ElseIf (Trim(v_strCMDALLOW) = "N") And (Trim(v_strLast) = "Y") Then
                            v_intIndex = 3
                        ElseIf (Trim(v_strCMDALLOW) = "N") And (Trim(v_strLast) <> "Y") Then
                            v_intIndex = 0
                        End If
                    Else
                        If Trim(v_strLast) = "Y" Then
                            v_intIndex = 3
                        Else
                            v_intIndex = 0
                        End If
                    End If

                    ''Assign initialize access right
                    'If v_strCMDALLOW = "" Then
                    '    v_strCMDALLOW = "N"
                    'End If
                    'If (Trim(v_strCMDALLOW) = "Y") And (Trim(v_strLast) = "Y") Then
                    '    v_intIndex = 5
                    'ElseIf (Trim(v_strCMDALLOW) = "Y") Then
                    '    v_intIndex = 4
                    'Else
                    '    v_intIndex = 3
                    'End If
                    'If v_strSTRAUTH = "" Then
                    '    v_strSTRAUTH = "NNNN"
                    'End If

                    If (Trim(v_strMenuType) <> "R") And (Trim(v_strMenuType) <> "T") Then
                        'Set menu's key
                        v_strMenuKey = v_strCMDID & "|" & v_strLEV
                        'Add new node to menu tree
                        v_NewNode = AddTreeNode(pv_nodeParent, v_strMenuKey, v_strCmdName, v_strLast, v_intIndex)
                        AddChildMenu(v_NewNode, v_strMenuKey)
                        ''Add new value to hashtable
                        hParentsFilter.Add(v_strCMDID, v_strPRID)
                    End If
                    'v_strFuncHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strSTRAUTH
                    'hFunctionFilter.Add(v_strCMDID, v_strFuncHashValue)
                    'mv_strFuncAuth &= v_strFuncHashValue & "#"
                Next v_intCount
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub Menu_Click(ByVal pv_treeNode As Node)

        'Update mouse pointer
        Cursor.Current = Cursors.WaitCursor
        Try

            If pv_treeNode.Key <> "" Then
                lblFUNCTION.Text = pv_treeNode.Text
                ShowAccessRight(pv_treeNode)
            Else
                lblFUNCTION.Text = String.Empty
                DisableAssignment()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        'Update mouse pointer
        Cursor.Current = Cursors.Default
    End Sub

    ''---------------------------------------------------------------''
    ''-- Thay đổi các giá trị khi thay đổi trạng thái của checkbox --''
    ''---------------------------------------------------------------''
    Private Sub Checkbox_CheckedChanged(ByVal sender As Object, ByVal pv_treeNode As Node)

        Try

            If pv_treeNode.Items.Count > 0 Then
                DoCheckboxChange(sender, pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        Checkbox_CheckedChanged(sender, v_node)
                    Else
                        DoCheckboxChange(sender, v_node)
                    End If
                Next
            Else
                DoCheckboxChange(sender, pv_treeNode)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    ''------------------------------''
    ''-- Hiển thị các quyền đã có --''
    ''------------------------------''
    Private Sub ShowAccessRight(ByVal pv_treeNode As Node)
        Dim v_strMenuType, v_strModCode, v_strObjName, v_arrMenuKey() As String
        Dim v_strAccess, v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove As String
        Dim v_strAuth, v_strCMDID, v_arrAuth() As String

        Try

            If pv_treeNode.Key <> "" Then
                EnableAssignment()
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                v_strCMDID = v_arrMenuKey(0)
                If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                    v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                    v_strAuth = v_arrAuth(2)
                Else
                    v_strAuth = "NNNNNN"
                End If


                If v_strAuth <> Nothing Then
                    v_strAccess = Mid(v_strAuth, 1, 1)
                    v_strInquiry = Mid(v_strAuth, 2, 1)
                    v_strAdd = Mid(v_strAuth, 3, 1)
                    v_strEdit = Mid(v_strAuth, 4, 1)
                    v_strDelete = Mid(v_strAuth, 5, 1)
                    'AnhVT Added - Maintenance Approval Retro
                    v_strApprove = Mid(v_strAuth, 6, 1)

                    'Display Access right
                    ckbACCESS.Checked = (v_strAccess = "Y")
                    ckbINQUIRY.Checked = (v_strInquiry = "Y")
                    ckbADD.Checked = (v_strAdd = "Y")
                    ckbEDIT.Checked = (v_strEdit = "Y")
                    ckbDELETE.Checked = (v_strDelete = "Y")
                    'AnhVT Added - Maintenance Approval Retro
                    ckbAPPROVE.Checked = (v_strApprove = "Y")
                End If
                'Allow assign in edit mode only
                If (ExeFlag = ExecuteFlag.View) Then
                    DisallowChange()
                End If
            Else
                DisableAssignment()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ChangeImageIndex(ByRef pv_treeNode As Node)
        Dim v_arrMenuKey() As String
        Dim v_strAuth, v_strCMDID, v_arrAuth() As String

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                v_strAuth = v_arrAuth(2)
            Else
                v_strAuth = "NNNNNN"
            End If
            If Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count > 0 Then
                pv_treeNode.ImageIndex = 4
            ElseIf Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count = 0 Then
                pv_treeNode.ImageIndex = 5
            ElseIf Mid(v_strAuth, 1, 1) = "N" And pv_treeNode.Items.Count = 0 Then
                pv_treeNode.ImageIndex = 3
            Else
                pv_treeNode.ImageIndex = 0
            End If
            'Set imageindex for parent
            If pv_treeNode.Items.Count = 0 Then 'Node con
                Dim pv_parentNode As Node = pv_treeNode.ParentItem
                If Not pv_parentNode Is Nothing Then
                    If pv_treeNode.ImageIndex = 5 Then
                        pv_parentNode.ImageIndex = 4
                    Else
                        Dim i, count As Integer
                        count = 0
                        For Each objNode As Node In pv_parentNode.Items
                            If objNode.ImageIndex = 5 Then
                                count = count + 1
                            End If
                        Next
                        If count > 0 Then
                            pv_parentNode.ImageIndex = 4
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

    ''-------------------------------------------------------------''
    ''-- + Mục đích: Thay đổi và cập nhật các giá trị phân quyền --''
    ''--             lên key của node of menu tree               --''
    ''-- + Đầu vào: - sender: Checkbox có giá trị thay đổi       --''
    ''--            - pv_treeNode: Node hiện tại của menu tree   --''
    ''-- + Đầu ra: N/A                                           --''
    ''-- + Tác giả: Nguyễn Nhân Thế                              --''
    ''-- + Ghi chú: N/A                                          --''
    ''-------------------------------------------------------------''
    Private Sub DoCheckboxChange(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_node As Node
        Dim v_strCMDALLOW, v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove As String
        Dim v_strCMDID, v_strAuth, v_strPRID, v_strLEV, v_strHashValue, v_arrMenuKey(), v_arrAuth() As String

        Try

            'Get auth string and CMDID
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                v_strAuth = v_arrAuth(2)
            Else
                v_strAuth = "NNNNNN"
            End If

            If v_strAuth <> Nothing Then
                'If ckbACCESS's value has changed
                If (sender Is ckbACCESS) Then
                    If ckbACCESS.Checked Then
                        v_strCMDALLOW = "Y"
                        v_strAuth = v_strCMDALLOW & Mid(v_strAuth, 2, 5)
                    Else
                        v_strCMDALLOW = "N"
                        ckbINQUIRY.Checked = False
                        ckbADD.Checked = False
                        ckbEDIT.Checked = False
                        ckbDELETE.Checked = False
                        ckbAPPROVE.Checked = False
                        v_strInquiry = "N"
                        v_strAdd = "N"
                        v_strEdit = "N"
                        v_strDelete = "N"
                        'AnhVT Added - Maintenance Approval Retro
                        'v_strAuth = v_strCMDALLOW & v_strInquiry & v_strAdd & v_strEdit & v_strDelete
                        v_strApprove = "N"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & v_strAdd & v_strEdit & v_strDelete & v_strApprove
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If

                    'If ckbINQUIRY's value has changed
                ElseIf (sender Is ckbINQUIRY) Then
                    If ckbINQUIRY.Checked Then
                        v_strInquiry = "Y"
                        If ckbACCESS.Checked = False Then
                            ckbACCESS.Checked = True
                        End If
                        v_strCMDALLOW = "Y"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & Mid(v_strAuth, 3, 4)
                    Else
                        v_strInquiry = "N"
                        ckbADD.Checked = False
                        ckbEDIT.Checked = False
                        ckbDELETE.Checked = False
                        ckbAPPROVE.Checked = False
                        v_strAdd = "N"
                        v_strEdit = "N"
                        v_strDelete = "N"
                        'v_strAuth = Mid(v_strAuth, 1, 1) & v_strInquiry & v_strAdd & v_strEdit & v_strDelete
                        v_strApprove = "N"
                        v_strAuth = Mid(v_strAuth, 1, 1) & v_strInquiry & v_strAdd & v_strEdit & v_strDelete & v_strApprove
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If

                    'If ckbADD's value has changed
                ElseIf (sender Is ckbADD) Then
                    If ckbADD.Checked Then
                        v_strAdd = "Y"
                        If ckbACCESS.Checked = False Then
                            ckbACCESS.Checked = True
                        End If
                        v_strCMDALLOW = "Y"
                        If ckbINQUIRY.Checked = False Then
                            ckbINQUIRY.Checked = True
                        End If
                        v_strInquiry = "Y"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & v_strAdd & Mid(v_strAuth, 4, 3)
                    Else
                        v_strAdd = "N"
                        v_strAuth = Mid(v_strAuth, 1, 2) & v_strAdd & Mid(v_strAuth, 4, 3)
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If

                    'If ckbEDIT's value has changed
                ElseIf (sender Is ckbEDIT) Then
                    If ckbEDIT.Checked Then
                        v_strEdit = "Y"
                        If ckbACCESS.Checked = False Then
                            ckbACCESS.Checked = True
                        End If
                        v_strCMDALLOW = "Y"
                        If ckbINQUIRY.Checked = False Then
                            ckbINQUIRY.Checked = True
                        End If
                        v_strInquiry = "Y"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & Mid(v_strAuth, 3, 1) & v_strEdit & Mid(v_strAuth, 5, 2)
                    Else
                        v_strEdit = "N"
                        v_strAuth = Mid(v_strAuth, 1, 3) & v_strEdit & Mid(v_strAuth, 5, 2)
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If

                    'If ckbDELETE's value has changed
                ElseIf (sender Is ckbDELETE) Then
                    If ckbDELETE.Checked Then
                        v_strDelete = "Y"
                        If ckbACCESS.Checked = False Then
                            ckbACCESS.Checked = True
                        End If
                        v_strCMDALLOW = "Y"
                        If ckbINQUIRY.Checked = False Then
                            ckbINQUIRY.Checked = True
                        End If
                        v_strInquiry = "Y"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & Mid(v_strAuth, 3, 2) & v_strDelete & Mid(v_strAuth, 6, 1)
                    Else
                        v_strDelete = "N"
                        v_strAuth = Mid(v_strAuth, 1, 4) & v_strDelete & Mid(v_strAuth, 6, 1)
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If
                    'AnhVT Added - Maintenance Approval Retro
                ElseIf (sender Is ckbAPPROVE) Then
                    If ckbAPPROVE.Checked Then
                        v_strApprove = "Y"
                        If ckbACCESS.Checked = False Then
                            ckbACCESS.Checked = True
                        End If
                        v_strCMDALLOW = "Y"
                        If ckbINQUIRY.Checked = False Then
                            ckbINQUIRY.Checked = True
                        End If
                        v_strInquiry = "Y"
                        v_strAuth = v_strCMDALLOW & v_strInquiry & Mid(v_strAuth, 3, 3) & v_strApprove
                    Else
                        v_strApprove = "N"
                        v_strAuth = Mid(v_strAuth, 1, 5) & v_strApprove
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strCMDID)
                        hFunctionFilter.Remove(v_strCMDID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If
                End If

                'Begin GianhVG add
                ChangeImageIndex(pv_treeNode)
                'End GianhVG add

                'Set key for parent node
                If (CInt(v_strLEV) > 1) And (v_strCMDALLOW = "Y") Then
                    SetParentNodeKey(pv_treeNode)
                End If



            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Set lại key của các node cha của 1 node      --''
    ''-- + Đầu vào: pv_treeNode: node có các node cha cần set key --''
    ''-- + Đầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub SetParentNodeKey(ByVal pv_treeNode As Node)
        Dim v_strPRID, v_strLEV, v_strCMDID, v_strAUTH, v_strHashValue, v_arrMenuKey() As String
        Dim v_strCMDALLOW, v_strPRLEV, v_arrAuth() As String
        Dim v_intPRLEV As Integer

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)

            For i As Integer = 0 To CInt(v_strLEV) - 2
                v_strPRID = hParentsFilter(v_strCMDID)
                v_intPRLEV = CInt(v_strLEV) - (i + 1)
                v_strPRLEV = CStr(v_intPRLEV)

                If Not hFunctionFilter(v_strPRID) Is Nothing Then
                    v_arrAuth = CStr(hFunctionFilter(v_strPRID)).Split("|")
                    v_strAUTH = v_arrAuth(2)
                    v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                    If v_strCMDALLOW = "N" Then
                        v_strCMDALLOW = "Y"
                    End If
                    v_strAUTH = v_strCMDALLOW & Mid(v_strAUTH, 2, 5)
                    v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH
                    'Remove old value before add new value to hash table and auth's string
                    Dim v_strOldHashValue As String
                    v_strOldHashValue = hFunctionFilter(v_strPRID)
                    hFunctionFilter.Remove(v_strPRID)
                    mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                    hFunctionFilter.Add(v_strPRID, v_strHashValue)
                    mv_strFuncAuth &= v_strHashValue & "#"
                Else
                    v_strAUTH = "YNNNNN"
                    v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH
                    'Add new value to hash table and auth's string
                    hFunctionFilter.Add(v_strPRID, v_strHashValue)
                    mv_strFuncAuth &= v_strHashValue & "#"
                End If

                v_strCMDID = v_strPRID
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''-------------------------------------------------------------''
    ''-- + Mục đích: Lấy giá trị khóa của các node của menu tree --''
    ''-- + Đầu vào: pv_treeNode: node cần lấy giá trị khóa       --''
    ''-- + Đầu ra: Chuỗi chứa khóa của node cần lấy              --''
    ''-- + Tác giả: Nguyễn Nhân Thế                              --''
    ''-- + Ghi chú: N/A                                          --''
    ''-------------------------------------------------------------''
    Private Function GetAuthString(ByVal pv_treeNode As Node) As String
        Dim v_strAuth As String = String.Empty
        Dim v_treeNode As Node

        Try
            For Each v_treeNode In pv_treeNode.Items
                If (v_treeNode.Key <> String.Empty) Then
                    If (v_treeNode.Items.Count > 0) Then
                        v_strAuth &= v_treeNode.Key & "#"
                        v_strAuth &= GetAuthString(v_treeNode)
                    Else
                        v_strAuth &= v_treeNode.Key & "#"
                    End If
                End If
            Next

            Return v_strAuth
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''---------------------------------------------------''
    ''-- + Mục đích: Lấy mã của những NSD thuộc nhóm   --''
    ''-- + Đầu vào: pv_strGroupId: Mã nhóm cần lấy     --''
    ''-- + Đầu ra: Chuỗi chứa mã của những NSD cần lấy --''
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


    'AnhVT Added - Maintenance Approval Retro
    Private Sub ckbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbAPPROVE.Click
        Checkbox_CheckedChanged(ckbApprove, stvFuncMenu.SelectedItem)
    End Sub

#End Region

#Region " From events "
    Private Sub frmFuncAssign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnSave.Click
        OnSave()
    End Sub

    Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnCancel.Click
        OnClose()
    End Sub

    Private Sub pnlFuncAssign_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlFuncAssign.Resize
        DoResizePanel()
    End Sub

    Private Sub ckbACCESS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbACCESS.Click
        Checkbox_CheckedChanged(ckbACCESS, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub ckbINQUIRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbINQUIRY.Click
        Checkbox_CheckedChanged(ckbINQUIRY, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub ckbADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbADD.Click
        Checkbox_CheckedChanged(ckbADD, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub ckbEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbEDIT.Click
        Checkbox_CheckedChanged(ckbEDIT, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub ckbDELETE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbDELETE.Click
        Checkbox_CheckedChanged(ckbDELETE, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub stvFuncMenu_ItemClick(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles stvFuncMenu.ItemClick
        Menu_Click(stvFuncMenu.SelectedItem)
    End Sub

    Private Sub frmFuncAssign_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

#End Region

    
End Class
