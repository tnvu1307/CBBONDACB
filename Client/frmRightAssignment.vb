Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Xceed.SmartUI.Controls.TreeView
Imports CommonLibrary
Imports AppCore
Imports AppCore.GridEx
Imports AppCore.ComboBoxEx

Public Class frmRightAssignment
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
    Private WithEvents stvFuncMenu As Xceed.SmartUI.Controls.TreeView.SmartTreeView
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Private WithEvents nodeDirect As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents pnlToolBar As System.Windows.Forms.Panel
    Friend WithEvents pnlFuncAssign As System.Windows.Forms.Panel
    Friend WithEvents ckbDELETE As System.Windows.Forms.CheckBox
    Friend WithEvents ckbEDIT As System.Windows.Forms.CheckBox
    Friend WithEvents ckbADD As System.Windows.Forms.CheckBox
    Friend WithEvents ckbINQUIRY As System.Windows.Forms.CheckBox
    Friend WithEvents ckbACCESS As System.Windows.Forms.CheckBox
    Private WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents lblFUNCTION As System.Windows.Forms.Label
    Private WithEvents tbnSave As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents imlToolBar As System.Windows.Forms.ImageList
    Private WithEvents tbnCancel As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents grbAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents lblACCESS As System.Windows.Forms.Label
    Friend WithEvents lblINQUIRY As System.Windows.Forms.Label
    Friend WithEvents lblADD As System.Windows.Forms.Label
    Friend WithEvents lblEDIT As System.Windows.Forms.Label
    Friend WithEvents ckbAPPROVE As System.Windows.Forms.CheckBox
    Friend WithEvents lblAPPROVE As System.Windows.Forms.Label
    Friend WithEvents grbRptAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents ckbRPTADD As System.Windows.Forms.CheckBox
    Friend WithEvents ckbRPTPRINT As System.Windows.Forms.CheckBox
    Friend WithEvents ckbRPTVIEW As System.Windows.Forms.CheckBox
    Friend WithEvents grbTransAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents lblCHECKERLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtCHECKERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblOFFICERLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblCASHIERLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtOFFICERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txtCASHIERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblTELLERLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblCURRCOD As System.Windows.Forms.Label
    Friend WithEvents txtTELLERLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents cboCURRCOD As AppCore.ComboBoxEx
    Friend WithEvents lblRPTAREA As System.Windows.Forms.Label
    Friend WithEvents cboRPTAREA As AppCore.ComboBoxEx
    Friend WithEvents grbGnrAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents lblGNRCHECKERLM As System.Windows.Forms.Label
    Friend WithEvents txtGNRCHECKERLM As System.Windows.Forms.TextBox
    Friend WithEvents lblGNROFFICERLM As System.Windows.Forms.Label
    Friend WithEvents lblGNRCASHIERLM As System.Windows.Forms.Label
    Friend WithEvents txtGNROFFICERLM As System.Windows.Forms.TextBox
    Friend WithEvents txtGNRCASHIERLM As System.Windows.Forms.TextBox
    Friend WithEvents lblGNRTELLERLM As System.Windows.Forms.Label
    Friend WithEvents lblGNRCURR As System.Windows.Forms.Label
    Friend WithEvents txtGNRTELLERLM As System.Windows.Forms.TextBox
    Friend WithEvents cboGNRCURR As AppCore.ComboBoxEx
    Friend WithEvents ckbGNRACC As System.Windows.Forms.CheckBox
    Private WithEvents nodeAdjust As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents lblDELETE As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRightAssignment))
        Me.imlMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.stvFuncMenu = New Xceed.SmartUI.Controls.TreeView.SmartTreeView(Me.components)
        Me.nodeDirect = New Xceed.SmartUI.Controls.TreeView.Node()
        Me.nodeAdjust = New Xceed.SmartUI.Controls.TreeView.Node()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlToolBar = New System.Windows.Forms.Panel()
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnSave = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbnCancel = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.imlToolBar = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlFuncAssign = New System.Windows.Forms.Panel()
        Me.grbGnrAccessRight = New System.Windows.Forms.GroupBox()
        Me.ckbGNRACC = New System.Windows.Forms.CheckBox()
        Me.lblGNRCHECKERLM = New System.Windows.Forms.Label()
        Me.txtGNRCHECKERLM = New System.Windows.Forms.TextBox()
        Me.lblGNROFFICERLM = New System.Windows.Forms.Label()
        Me.lblGNRCASHIERLM = New System.Windows.Forms.Label()
        Me.txtGNROFFICERLM = New System.Windows.Forms.TextBox()
        Me.txtGNRCASHIERLM = New System.Windows.Forms.TextBox()
        Me.lblGNRTELLERLM = New System.Windows.Forms.Label()
        Me.lblGNRCURR = New System.Windows.Forms.Label()
        Me.txtGNRTELLERLM = New System.Windows.Forms.TextBox()
        Me.cboGNRCURR = New AppCore.ComboBoxEx()
        Me.grbTransAccessRight = New System.Windows.Forms.GroupBox()
        Me.lblCHECKERLIMIT = New System.Windows.Forms.Label()
        Me.txtCHECKERLIMIT = New System.Windows.Forms.TextBox()
        Me.lblOFFICERLIMIT = New System.Windows.Forms.Label()
        Me.lblCASHIERLIMIT = New System.Windows.Forms.Label()
        Me.txtOFFICERLIMIT = New System.Windows.Forms.TextBox()
        Me.txtCASHIERLIMIT = New System.Windows.Forms.TextBox()
        Me.lblTELLERLIMIT = New System.Windows.Forms.Label()
        Me.lblCURRCOD = New System.Windows.Forms.Label()
        Me.txtTELLERLIMIT = New System.Windows.Forms.TextBox()
        Me.cboCURRCOD = New AppCore.ComboBoxEx()
        Me.grbRptAccessRight = New System.Windows.Forms.GroupBox()
        Me.lblRPTAREA = New System.Windows.Forms.Label()
        Me.cboRPTAREA = New AppCore.ComboBoxEx()
        Me.ckbRPTADD = New System.Windows.Forms.CheckBox()
        Me.ckbRPTPRINT = New System.Windows.Forms.CheckBox()
        Me.ckbRPTVIEW = New System.Windows.Forms.CheckBox()
        Me.lblFUNCTION = New System.Windows.Forms.Label()
        Me.grbAccessRight = New System.Windows.Forms.GroupBox()
        Me.ckbAPPROVE = New System.Windows.Forms.CheckBox()
        Me.lblAPPROVE = New System.Windows.Forms.Label()
        Me.lblDELETE = New System.Windows.Forms.Label()
        Me.lblEDIT = New System.Windows.Forms.Label()
        Me.lblADD = New System.Windows.Forms.Label()
        Me.lblINQUIRY = New System.Windows.Forms.Label()
        Me.lblACCESS = New System.Windows.Forms.Label()
        Me.ckbDELETE = New System.Windows.Forms.CheckBox()
        Me.ckbEDIT = New System.Windows.Forms.CheckBox()
        Me.ckbADD = New System.Windows.Forms.CheckBox()
        Me.ckbINQUIRY = New System.Windows.Forms.CheckBox()
        Me.ckbACCESS = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.stvFuncMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolBar.SuspendLayout()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFuncAssign.SuspendLayout()
        Me.grbGnrAccessRight.SuspendLayout()
        Me.grbTransAccessRight.SuspendLayout()
        Me.grbRptAccessRight.SuspendLayout()
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
        Me.Splitter1.Size = New System.Drawing.Size(3, 584)
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
        Me.Panel1.Size = New System.Drawing.Size(1032, 50)
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
        Me.stvFuncMenu.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.nodeDirect, Me.nodeAdjust})
        Me.stvFuncMenu.ItemsImageList = Me.imlMenu
        Me.stvFuncMenu.Location = New System.Drawing.Point(3, 50)
        Me.stvFuncMenu.Name = "stvFuncMenu"
        Me.stvFuncMenu.Size = New System.Drawing.Size(292, 534)
        Me.stvFuncMenu.TabIndex = 0
        Me.stvFuncMenu.Text = "stvFuncMenu"
        Me.stvFuncMenu.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'nodeDirect
        '
        Me.nodeDirect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeDirect.ImageIndex = 2
        Me.nodeDirect.Name = "nodeDirect"
        Me.nodeDirect.Tag = Nothing
        Me.nodeDirect.Text = "Flex"
        '
        'nodeAdjust
        '
        Me.nodeAdjust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeAdjust.ImageIndex = 2
        Me.nodeAdjust.Key = "000000"
        Me.nodeAdjust.Name = "nodeAdjust"
        Me.nodeAdjust.Tag = Nothing
        Me.nodeAdjust.Text = "CustomizeMenu"
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(295, 50)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 534)
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
        Me.pnlToolBar.Size = New System.Drawing.Size(737, 40)
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
        Me.SmartToolBar1.Size = New System.Drawing.Size(737, 42)
        Me.SmartToolBar1.TabIndex = 0
        Me.SmartToolBar1.Text = "SmartToolBar1"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnSave
        '
        Me.tbnSave.ImageIndex = 1
        Me.tbnSave.Name = "tbnSave"
        Me.tbnSave.Tag = Nothing
        Me.tbnSave.Text = "tbnSave"
        '
        'tbnCancel
        '
        Me.tbnCancel.ImageIndex = 0
        Me.tbnCancel.Name = "tbnCancel"
        Me.tbnCancel.Tag = Nothing
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
        Me.pnlFuncAssign.Controls.Add(Me.grbGnrAccessRight)
        Me.pnlFuncAssign.Controls.Add(Me.grbTransAccessRight)
        Me.pnlFuncAssign.Controls.Add(Me.grbRptAccessRight)
        Me.pnlFuncAssign.Controls.Add(Me.lblFUNCTION)
        Me.pnlFuncAssign.Controls.Add(Me.grbAccessRight)
        Me.pnlFuncAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFuncAssign.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFuncAssign.Location = New System.Drawing.Point(298, 90)
        Me.pnlFuncAssign.Name = "pnlFuncAssign"
        Me.pnlFuncAssign.Size = New System.Drawing.Size(737, 494)
        Me.pnlFuncAssign.TabIndex = 1
        '
        'grbGnrAccessRight
        '
        Me.grbGnrAccessRight.Controls.Add(Me.ckbGNRACC)
        Me.grbGnrAccessRight.Controls.Add(Me.lblGNRCHECKERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.txtGNRCHECKERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.lblGNROFFICERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.lblGNRCASHIERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.txtGNROFFICERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.txtGNRCASHIERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.lblGNRTELLERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.lblGNRCURR)
        Me.grbGnrAccessRight.Controls.Add(Me.txtGNRTELLERLM)
        Me.grbGnrAccessRight.Controls.Add(Me.cboGNRCURR)
        Me.grbGnrAccessRight.Location = New System.Drawing.Point(352, 251)
        Me.grbGnrAccessRight.Name = "grbGnrAccessRight"
        Me.grbGnrAccessRight.Size = New System.Drawing.Size(344, 203)
        Me.grbGnrAccessRight.TabIndex = 5
        Me.grbGnrAccessRight.TabStop = False
        Me.grbGnrAccessRight.Tag = "grbGnrAccessRight"
        Me.grbGnrAccessRight.Text = "grbGnrAccessRight"
        '
        'ckbGNRACC
        '
        Me.ckbGNRACC.Enabled = False
        Me.ckbGNRACC.Location = New System.Drawing.Point(12, 20)
        Me.ckbGNRACC.Name = "ckbGNRACC"
        Me.ckbGNRACC.Size = New System.Drawing.Size(245, 24)
        Me.ckbGNRACC.TabIndex = 22
        Me.ckbGNRACC.Tag = "ckbGNRACC"
        Me.ckbGNRACC.Text = "ckbGNRACC"
        '
        'lblGNRCHECKERLM
        '
        Me.lblGNRCHECKERLM.AutoSize = True
        Me.lblGNRCHECKERLM.Location = New System.Drawing.Point(9, 176)
        Me.lblGNRCHECKERLM.Name = "lblGNRCHECKERLM"
        Me.lblGNRCHECKERLM.Size = New System.Drawing.Size(97, 13)
        Me.lblGNRCHECKERLM.TabIndex = 21
        Me.lblGNRCHECKERLM.Tag = "GNRCHECKERLM"
        Me.lblGNRCHECKERLM.Text = "lblGNRCHECKERLM"
        Me.lblGNRCHECKERLM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGNRCHECKERLM
        '
        Me.txtGNRCHECKERLM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGNRCHECKERLM.Location = New System.Drawing.Point(129, 173)
        Me.txtGNRCHECKERLM.MaxLength = 20
        Me.txtGNRCHECKERLM.Name = "txtGNRCHECKERLM"
        Me.txtGNRCHECKERLM.Size = New System.Drawing.Size(150, 21)
        Me.txtGNRCHECKERLM.TabIndex = 4
        Me.txtGNRCHECKERLM.Tag = "GNRCHECKERLM"
        Me.txtGNRCHECKERLM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGNROFFICERLM
        '
        Me.lblGNROFFICERLM.AutoSize = True
        Me.lblGNROFFICERLM.Location = New System.Drawing.Point(9, 147)
        Me.lblGNROFFICERLM.Name = "lblGNROFFICERLM"
        Me.lblGNROFFICERLM.Size = New System.Drawing.Size(95, 13)
        Me.lblGNROFFICERLM.TabIndex = 19
        Me.lblGNROFFICERLM.Tag = "GNROFFICERLM"
        Me.lblGNROFFICERLM.Text = "lblGNROFFICERLM"
        Me.lblGNROFFICERLM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGNRCASHIERLM
        '
        Me.lblGNRCASHIERLM.AutoSize = True
        Me.lblGNRCASHIERLM.Location = New System.Drawing.Point(9, 118)
        Me.lblGNRCASHIERLM.Name = "lblGNRCASHIERLM"
        Me.lblGNRCASHIERLM.Size = New System.Drawing.Size(95, 13)
        Me.lblGNRCASHIERLM.TabIndex = 18
        Me.lblGNRCASHIERLM.Tag = "GNRCASHIERLM"
        Me.lblGNRCASHIERLM.Text = "lblGNRCASHIERLM"
        Me.lblGNRCASHIERLM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGNROFFICERLM
        '
        Me.txtGNROFFICERLM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGNROFFICERLM.Location = New System.Drawing.Point(129, 144)
        Me.txtGNROFFICERLM.MaxLength = 20
        Me.txtGNROFFICERLM.Name = "txtGNROFFICERLM"
        Me.txtGNROFFICERLM.Size = New System.Drawing.Size(150, 21)
        Me.txtGNROFFICERLM.TabIndex = 3
        Me.txtGNROFFICERLM.Tag = "GNROFFICERLM"
        Me.txtGNROFFICERLM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGNRCASHIERLM
        '
        Me.txtGNRCASHIERLM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGNRCASHIERLM.Location = New System.Drawing.Point(129, 115)
        Me.txtGNRCASHIERLM.MaxLength = 20
        Me.txtGNRCASHIERLM.Name = "txtGNRCASHIERLM"
        Me.txtGNRCASHIERLM.Size = New System.Drawing.Size(150, 21)
        Me.txtGNRCASHIERLM.TabIndex = 2
        Me.txtGNRCASHIERLM.Tag = "GNRCASHIERLM"
        Me.txtGNRCASHIERLM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGNRTELLERLM
        '
        Me.lblGNRTELLERLM.AutoSize = True
        Me.lblGNRTELLERLM.Location = New System.Drawing.Point(9, 89)
        Me.lblGNRTELLERLM.Name = "lblGNRTELLERLM"
        Me.lblGNRTELLERLM.Size = New System.Drawing.Size(86, 13)
        Me.lblGNRTELLERLM.TabIndex = 12
        Me.lblGNRTELLERLM.Tag = "GNRTELLERLM"
        Me.lblGNRTELLERLM.Text = "lblGNRTELLERLM"
        Me.lblGNRTELLERLM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGNRCURR
        '
        Me.lblGNRCURR.AutoSize = True
        Me.lblGNRCURR.Location = New System.Drawing.Point(9, 60)
        Me.lblGNRCURR.Name = "lblGNRCURR"
        Me.lblGNRCURR.Size = New System.Drawing.Size(66, 13)
        Me.lblGNRCURR.TabIndex = 11
        Me.lblGNRCURR.Tag = "GNRCURR"
        Me.lblGNRCURR.Text = "lblGNRCURR"
        Me.lblGNRCURR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGNRTELLERLM
        '
        Me.txtGNRTELLERLM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGNRTELLERLM.Location = New System.Drawing.Point(129, 86)
        Me.txtGNRTELLERLM.MaxLength = 20
        Me.txtGNRTELLERLM.Name = "txtGNRTELLERLM"
        Me.txtGNRTELLERLM.Size = New System.Drawing.Size(150, 21)
        Me.txtGNRTELLERLM.TabIndex = 1
        Me.txtGNRTELLERLM.Tag = "GNRTELLERLM"
        Me.txtGNRTELLERLM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboGNRCURR
        '
        Me.cboGNRCURR.DisplayMember = "DISPLAY"
        Me.cboGNRCURR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGNRCURR.Location = New System.Drawing.Point(129, 57)
        Me.cboGNRCURR.Name = "cboGNRCURR"
        Me.cboGNRCURR.Size = New System.Drawing.Size(100, 21)
        Me.cboGNRCURR.TabIndex = 0
        Me.cboGNRCURR.Tag = "GNRCURR"
        Me.cboGNRCURR.ValueMember = "VALUE"
        '
        'grbTransAccessRight
        '
        Me.grbTransAccessRight.Controls.Add(Me.lblCHECKERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.txtCHECKERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.lblOFFICERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.lblCASHIERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.txtOFFICERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.txtCASHIERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.lblTELLERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.lblCURRCOD)
        Me.grbTransAccessRight.Controls.Add(Me.txtTELLERLIMIT)
        Me.grbTransAccessRight.Controls.Add(Me.cboCURRCOD)
        Me.grbTransAccessRight.Location = New System.Drawing.Point(352, 45)
        Me.grbTransAccessRight.Name = "grbTransAccessRight"
        Me.grbTransAccessRight.Size = New System.Drawing.Size(344, 200)
        Me.grbTransAccessRight.TabIndex = 2
        Me.grbTransAccessRight.TabStop = False
        Me.grbTransAccessRight.Tag = "grbTransAccessRight"
        Me.grbTransAccessRight.Text = "grbTransAccessRight"
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
        'grbRptAccessRight
        '
        Me.grbRptAccessRight.Controls.Add(Me.lblRPTAREA)
        Me.grbRptAccessRight.Controls.Add(Me.cboRPTAREA)
        Me.grbRptAccessRight.Controls.Add(Me.ckbRPTADD)
        Me.grbRptAccessRight.Controls.Add(Me.ckbRPTPRINT)
        Me.grbRptAccessRight.Controls.Add(Me.ckbRPTVIEW)
        Me.grbRptAccessRight.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grbRptAccessRight.Location = New System.Drawing.Point(10, 251)
        Me.grbRptAccessRight.Name = "grbRptAccessRight"
        Me.grbRptAccessRight.Size = New System.Drawing.Size(336, 203)
        Me.grbRptAccessRight.TabIndex = 1
        Me.grbRptAccessRight.TabStop = False
        Me.grbRptAccessRight.Tag = "AccessRight"
        Me.grbRptAccessRight.Text = "grbRptAccessRight"
        '
        'lblRPTAREA
        '
        Me.lblRPTAREA.AutoSize = True
        Me.lblRPTAREA.Location = New System.Drawing.Point(12, 133)
        Me.lblRPTAREA.Name = "lblRPTAREA"
        Me.lblRPTAREA.Size = New System.Drawing.Size(63, 13)
        Me.lblRPTAREA.TabIndex = 22
        Me.lblRPTAREA.Tag = "RPTAREA"
        Me.lblRPTAREA.Text = "lblRPTAREA"
        Me.lblRPTAREA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRPTAREA
        '
        Me.cboRPTAREA.DisplayMember = "DISPLAY"
        Me.cboRPTAREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRPTAREA.Location = New System.Drawing.Point(154, 130)
        Me.cboRPTAREA.Name = "cboRPTAREA"
        Me.cboRPTAREA.Size = New System.Drawing.Size(120, 21)
        Me.cboRPTAREA.TabIndex = 3
        Me.cboRPTAREA.Tag = "RPTAREA"
        Me.cboRPTAREA.ValueMember = "VALUE"
        '
        'ckbRPTADD
        '
        Me.ckbRPTADD.Location = New System.Drawing.Point(15, 100)
        Me.ckbRPTADD.Name = "ckbRPTADD"
        Me.ckbRPTADD.Size = New System.Drawing.Size(160, 24)
        Me.ckbRPTADD.TabIndex = 2
        Me.ckbRPTADD.Tag = "ADD"
        Me.ckbRPTADD.Text = "ckbRPTADD"
        '
        'ckbRPTPRINT
        '
        Me.ckbRPTPRINT.Enabled = False
        Me.ckbRPTPRINT.Location = New System.Drawing.Point(15, 65)
        Me.ckbRPTPRINT.Name = "ckbRPTPRINT"
        Me.ckbRPTPRINT.Size = New System.Drawing.Size(160, 24)
        Me.ckbRPTPRINT.TabIndex = 1
        Me.ckbRPTPRINT.Tag = "PRINT"
        Me.ckbRPTPRINT.Text = "ckbRPTPRINT"
        '
        'ckbRPTVIEW
        '
        Me.ckbRPTVIEW.Enabled = False
        Me.ckbRPTVIEW.Location = New System.Drawing.Point(15, 30)
        Me.ckbRPTVIEW.Name = "ckbRPTVIEW"
        Me.ckbRPTVIEW.Size = New System.Drawing.Size(160, 24)
        Me.ckbRPTVIEW.TabIndex = 0
        Me.ckbRPTVIEW.Tag = "VIEW"
        Me.ckbRPTVIEW.Text = "ckbRPTVIEW"
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
        Me.grbAccessRight.Size = New System.Drawing.Size(336, 200)
        Me.grbAccessRight.TabIndex = 0
        Me.grbAccessRight.TabStop = False
        Me.grbAccessRight.Tag = "AccessRight"
        Me.grbAccessRight.Text = "grbAccessRight"
        '
        'ckbAPPROVE
        '
        Me.ckbAPPROVE.Location = New System.Drawing.Point(15, 172)
        Me.ckbAPPROVE.Name = "ckbAPPROVE"
        Me.ckbAPPROVE.Size = New System.Drawing.Size(20, 24)
        Me.ckbAPPROVE.TabIndex = 5
        Me.ckbAPPROVE.Tag = "ckbAPPROVE"
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
        Me.ckbDELETE.Tag = "ckbDELETE"
        '
        'ckbEDIT
        '
        Me.ckbEDIT.Location = New System.Drawing.Point(15, 110)
        Me.ckbEDIT.Name = "ckbEDIT"
        Me.ckbEDIT.Size = New System.Drawing.Size(20, 24)
        Me.ckbEDIT.TabIndex = 3
        Me.ckbEDIT.Tag = "ckbEDIT"
        '
        'ckbADD
        '
        Me.ckbADD.Location = New System.Drawing.Point(15, 80)
        Me.ckbADD.Name = "ckbADD"
        Me.ckbADD.Size = New System.Drawing.Size(20, 24)
        Me.ckbADD.TabIndex = 2
        Me.ckbADD.Tag = "ckbADD"
        '
        'ckbINQUIRY
        '
        Me.ckbINQUIRY.Location = New System.Drawing.Point(15, 50)
        Me.ckbINQUIRY.Name = "ckbINQUIRY"
        Me.ckbINQUIRY.Size = New System.Drawing.Size(20, 24)
        Me.ckbINQUIRY.TabIndex = 1
        Me.ckbINQUIRY.Tag = "ckbINQUIRY"
        '
        'ckbACCESS
        '
        Me.ckbACCESS.Location = New System.Drawing.Point(15, 20)
        Me.ckbACCESS.Name = "ckbACCESS"
        Me.ckbACCESS.Size = New System.Drawing.Size(20, 24)
        Me.ckbACCESS.TabIndex = 0
        Me.ckbACCESS.Tag = "ckbACCESS"
        '
        'frmRightAssignment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1035, 584)
        Me.Controls.Add(Me.pnlFuncAssign)
        Me.Controls.Add(Me.pnlToolBar)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.stvFuncMenu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmRightAssignment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmRightAssignment"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stvFuncMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolBar.ResumeLayout(False)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFuncAssign.ResumeLayout(False)
        Me.pnlFuncAssign.PerformLayout()
        Me.grbGnrAccessRight.ResumeLayout(False)
        Me.grbGnrAccessRight.PerformLayout()
        Me.grbTransAccessRight.ResumeLayout(False)
        Me.grbTransAccessRight.PerformLayout()
        Me.grbRptAccessRight.ResumeLayout(False)
        Me.grbRptAccessRight.PerformLayout()
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
    Private mv_arrCurrCod() As String
    Private mv_strTransAuthString As String
    Private mv_strTlauthString As String
    Private mv_strReportAuth As String
    Private mv_strTlRight As String
    Private mv_strGrpRight As String
    Private mv_strRight As String
    Private mv_strAUTHCODE As String
    Private mv_strCMDID As String

    Dim hParentsFilter As New Hashtable
    Dim hFunctionFilter As New Hashtable

    Dim hTlauthFilter As New Hashtable
    Dim hTransFilter As New Hashtable
    Dim hCurrDecFilter As New Hashtable
    Dim hModCodeFilter As New Hashtable
    Dim hTxCodeFilter As New Hashtable
    Dim hCmdIdFilter As New Hashtable
    Dim hChildrenFilter As New Hashtable
    Dim hReportFilter As New Hashtable

    'This node will be used as a temp node
    Private mv_node As New Node
    Private mv_textbox As New System.Windows.Forms.TextBox
    'PhuNh current node 
    Private mv_currnodeIdx As Integer = -1

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

#Region " Load menu "
    Private hTreeMenuFunction As New Hashtable      'Key là CommandCode, Value là TreeMenuFunction Object
    Private arrTreeMenuFunction() As CTreeMenuFunction
    Private arrTreeNode As New Hashtable            'Với cmdCode tương ứng với node nào trên cây menu

    'VinhLD thêm để xử lý chỉ gọi lên HOST một lần
    Private Sub LoadTreeMenu(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_objFunction As CommonLibrary.CTreeMenuFunction
        Dim v_nodeRoot, v_nodeParent, v_node As Node
        Dim i As Integer
        Try
            'Clear cây chức năng
            stvFuncMenu.Items(0).Items.Clear()

            If IsShown Then
                'Lấy thông tin về cây chức năng của toàn hệ thống
                GetTreeMenuAll()
                'Hiển thị cây Menu
                If arrTreeMenuFunction.Length > 0 Then
                    arrTreeNode.Clear()
                    v_nodeRoot = stvFuncMenu.Items(0)
                    For i = 0 To arrTreeMenuFunction.Length - 1 Step 1
                        v_objFunction = arrTreeMenuFunction(i)
                        If Not v_objFunction.CmdCode.Length = 0 Then
                            If v_objFunction.MenuLevel = 1 Then
                                'Root Item
                                v_nodeParent = v_nodeRoot
                            Else
                                'Xác định parent node là node cha
                                If Not arrTreeNode(v_objFunction.PrID) Is Nothing Then
                                    v_nodeParent = arrTreeNode(v_objFunction.PrID)
                                Else
                                    'Mặc định đưa vào RootNode
                                    v_nodeParent = v_nodeRoot
                                End If
                            End If
                            'Chỉ tạo cây menu nếu có con
                            If Not (v_objFunction.LastItem = "N" And v_objFunction.ChildCount = 0) Then
                                v_node = BindObjectToTreeNode(v_objFunction, v_nodeParent)
                                'Ghi nhận
                                arrTreeNode.Add(v_objFunction.CmdCode, v_node)
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception

        Finally
            XmlDocument = Nothing
        End Try
    End Sub

    'VinhLD dựng cây chức năng theo Object function
    Private Function BindObjectToTreeNode(ByRef objFunction As CommonLibrary.CTreeMenuFunction, ByRef parentTreeNode As Node) As Node
        Dim v_tempNode, v_retNode As Node
        Dim strMenuKey As String
        If Not objFunction Is Nothing Then
            If Not ((objFunction.MenuType = "T" Or objFunction.MenuType = "R" Or objFunction.MenuType = "V") And objFunction.LastItem = "Y") Then
                'Chức năng là CMDMENU
                strMenuKey = objFunction.CmdCode & "|" & objFunction.MenuType & "|" & objFunction.ModCode _
                                & "|" & objFunction.ObjName & "|" & objFunction.AuthCode & "|" & objFunction.StrAuth
                v_retNode = AddTreeNode(parentTreeNode, strMenuKey, objFunction.CmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)
                Return v_retNode
            Else
                'Chức năng là TLTX/RPTMASTER
                If objFunction.CmdAllow = "Y" Then
                    Dim strTransKey As String = objFunction.CmdCode & "|" & objFunction.CmdAllow & "|" & objFunction.ModCode & "|" & objFunction.MenuType
                    v_retNode = AddTreeNode(parentTreeNode, strTransKey, objFunction.CmdCode & ": " & objFunction.CmdName, gc_IS_LAST_MENU, objFunction.ImageIndex)
                    Return v_retNode
                End If
            End If


            'Xử lý menuKey cho từng loại
        End If
        Return Nothing
    End Function

    'Lấy hết cây chức năng, giao dich và các báo cáo được phân quyền sử dụng
    Private Sub GetTreeMenuAll()
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strObjMsg, v_strKey, v_strFLDNAME, v_strValue, v_strCMDID, v_strPRID As String
        Dim v_obj, v_objTmp As CommonLibrary.CTreeMenuFunction
        Dim v_strSQL, v_strRPTID, v_strMODCODE, v_strCMDTYPE, v_strDESC, v_strSTORENAME As String
        Dim i, j As Integer
        Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        Try
            'VinhLD goi ham lay cay chuc nang Full
            v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                            OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetTreeMenuAll")
            m_ws.Message(v_strObjMsg)

            'Khởi tạo cây chức năng
            hTreeMenuFunction.Clear()
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim arrTreeMenuFunction(v_nodeList.Count)
            For i = 0 To v_nodeList.Count - 1
                v_obj = New CommonLibrary.CTreeMenuFunction
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "ODRID"
                                v_obj.SequenceId = v_strValue
                            Case "CMDCODE"
                                v_strKey = v_strValue
                                v_obj.CmdCode = v_strValue
                            Case "CMDID"
                                v_obj.CmdID = v_strValue
                            Case "PRID"
                                v_obj.PrID = v_strValue
                            Case "CMDNAME"
                                v_obj.CmdName = v_strValue
                            Case "EN_CMDNAME"
                                v_obj.EN_CmdName = v_strValue
                            Case "LAST"
                                v_obj.LastItem = v_strValue
                            Case "IMGINDEX"
                                v_obj.ImageIndex = v_strValue
                            Case "MODCODE"
                                v_obj.ModCode = v_strValue
                            Case "OBJNAME"
                                v_obj.ObjName = v_strValue
                            Case "MENUTYPE"
                                v_obj.MenuType = v_strValue
                            Case "LEV"
                                v_obj.MenuLevel = v_strValue
                            Case "CMDALLOW"
                                v_obj.CmdAllow = v_strValue
                            Case "AUTHCODE"
                                v_obj.AuthCode = v_strValue
                            Case "STRAUTH"
                                v_obj.StrAuth = v_strValue
                            Case "RIGHTSCOPE"
                                v_obj.RightScope = v_strValue
                        End Select
                    End With
                Next

                'Kiểm tra đã có command code chưa
                If hTreeMenuFunction(v_strKey) Is Nothing Then
                    'Sử dụng để dựng Menu theo thứ tự
                    arrTreeMenuFunction(i) = v_obj
                    'Sử dụng để truy cập thuộc tính
                    hTreeMenuFunction.Add(v_strKey, v_obj)

                    'Xử lý Item cha
                    v_strCMDID = v_obj.CmdID
                    v_strPRID = v_obj.PrID
                    v_objTmp = v_obj
                    While Not hTreeMenuFunction(v_strPRID) Is Nothing
                        If v_objTmp.LastItem = "Y" Then
                            'Cha có con
                            CType(hTreeMenuFunction(v_strPRID), CommonLibrary.CTreeMenuFunction).ChildCount += 1
                        Else
                            CType(hTreeMenuFunction(v_strPRID), CommonLibrary.CTreeMenuFunction).ChildCount = _
                                CType(hTreeMenuFunction(v_strCMDID), CommonLibrary.CTreeMenuFunction).ChildCount
                        End If
                        v_objTmp = CType(hTreeMenuFunction(v_strPRID), CommonLibrary.CTreeMenuFunction)
                        v_strPRID = v_objTmp.PrID
                        v_strCMDID = v_objTmp.CmdID
                    End While
                Else
                    'Sử dụng để dựng Menu theo thứ tự
                    v_obj.CmdCode = ""
                    arrTreeMenuFunction(i) = v_obj
                End If
            Next

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            m_ws = Nothing
        End Try
    End Sub
#End Region

#Region " Overridable methods "
    Dim nCountChildCall As Long = 0

    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            DisableAssignment()
            DoResizePanel()
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmRightAssignment-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            FillData()
            FillTransData()
            FillRptData()

            'LoadTreeMenu()
            DisplayMenus()
            DisplayAdjustMenus()

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
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                End If
            Next

            'Load caption of controls in toolbar
            tbnSave.Text = mv_ResourceManager.GetString("tbnSave")
            tbnCancel.Text = mv_ResourceManager.GetString("tbnCancel")

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmRightAssignment")
            If AssignType = "User" Then
                lblCaption.Text = mv_ResourceManager.GetString("lblCaption0") & UserName
            ElseIf AssignType = "Group" Then
                lblCaption.Text = mv_ResourceManager.GetString("lblCaption1") & GroupName
            End If

            'Disable control if in view mode
            If (ExeFlag = ExecuteFlag.View) Then
                tbnSave.Enabled = False
            End If

            'Disable access right area
            grbAccessRight.Visible = False
            grbRptAccessRight.Visible = False
            grbTransAccessRight.Visible = False
            grbGnrAccessRight.Visible = False

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
                If hFunctionFilter(v_strCMDID) Is Nothing Then
                    hFunctionFilter.Add(v_strCMDID, v_strHashKey)
                End If
                mv_strFuncAuth &= v_strHashKey & "#"
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillTransData()

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
                cboGNRCURR.AddItems(v_arrCurrName(i), mv_arrCurrCod(i))
            Next

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

    Private Sub FillRptData()
        Try
            Dim v_strFLDNAME, v_strValue As String

            'Get Report access right of user
            Dim v_strCmdInquiryRpt, v_strRptObjMsg As String
            Dim v_strTXCODE, v_strCMDID, v_strCNT, v_strMENUTYPE, v_strLEV, v_strCMDALLOW, v_strMODCODE, v_strAUTH, v_strCMDTYPE, v_strHashKey, v_strHashValue As String
            Dim v_strSQL, v_strObjMsg As String

            'FILL AREA
            Dim v_wsAR As New BDSDeliveryManagement
            v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'AREA' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_wsAR.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboRPTAREA, "", Me.UserLanguage)

            'Get Report access right
            If AssignType = "User" Then
                v_strCmdInquiryRpt = "SELECT M.RPTID RPTID, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 4 LEV, A.CMDTYPE " _
                                    & "FROM RPTMASTER M, CMDAUTH A " _
                                    & "WHERE M.RPTID = A.CMDCODE AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE IN ('R','G') AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.RPTID"
                v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryRpt)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryRpt = "SELECT M.RPTID RPTID, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 4 LEV, A.CMDTYPE " _
                                    & "FROM RPTMASTER M, CMDAUTH A " _
                                    & "WHERE M.RPTID = A.CMDCODE AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE IN ('R','G') AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.RPTID"
                v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryRpt)
            End If

            Dim v_wsRpt As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsRpt.Message(v_strRptObjMsg)

            Dim v_xmlRptDocument As New Xml.XmlDocument
            Dim v_nodeRptList As Xml.XmlNodeList

            v_xmlRptDocument.LoadXml(v_strRptObjMsg)
            v_nodeRptList = v_xmlRptDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strRPTID As String
            For i As Integer = 0 To v_nodeRptList.Count - 1
                Try
                    For j As Integer = 0 To v_nodeRptList.Item(i).ChildNodes.Count - 1
                        With v_nodeRptList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "RPTID"
                                v_strRPTID = v_strValue
                            Case "LEV"
                                v_strLEV = v_strValue
                            Case "CMDALLOW"
                                v_strCMDALLOW = v_strValue
                            Case "STRAUTH"
                                v_strAUTH = v_strValue
                            Case "CMDTYPE"
                                v_strCMDTYPE = v_strValue
                        End Select
                    Next
                    'Fill to hashtable
                    v_strHashValue = v_strRPTID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & v_strCMDTYPE
                    If Not hReportFilter.ContainsKey(v_strRPTID) Then
                        hReportFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Next

            'Get Function access right of user
            Dim v_strCmdInquiryFunc, v_strFuncObjMsg As String
            If AssignType = "User" Then
                v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                                            & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU1 " _
                                                & " LEFT JOIN " _
                                                & " (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU2 " _
                                            & " ON MNU1.CMDID = MNU2.PRID " _
                                            & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                                            & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                                            & " FROM (SELECT M.*, N.TXCODE " _
                                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                                            & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                            & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                                            & " ORDER BY M.CMDID) MNU " _
                                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                                    & " ORDER BY MNU.CMDID "

                'v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                '                    & "from CMDMENU M, CMDAUTH A " _
                '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                '                    & "and A.AUTHID = '" & UserId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'R')" _
                '                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryFunc)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                                            & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU1 " _
                                                & " LEFT JOIN " _
                                                & " (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU2 " _
                                            & " ON MNU1.CMDID = MNU2.PRID " _
                                            & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                                            & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                                            & " FROM (SELECT M.*, N.TXCODE " _
                                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                                            & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                            & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                                            & " ORDER BY M.CMDID) MNU " _
                                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                                    & " ORDER BY MNU.CMDID "
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryFunc)
            End If

            Dim v_wsFunc As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsFunc.Message(v_strFuncObjMsg)

            Dim v_xmlFuncDocument As New Xml.XmlDocument
            Dim v_nodeFuncList As Xml.XmlNodeList

            v_xmlFuncDocument.LoadXml(v_strFuncObjMsg)
            v_nodeFuncList = v_xmlFuncDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeFuncList.Count - 1
                For j As Integer = 0 To v_nodeFuncList.Item(i).ChildNodes.Count - 1
                    With v_nodeFuncList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "CNT"
                            v_strCNT = CStr(v_strValue).Trim
                        Case "CMDID"
                            v_strCMDID = v_strValue
                        Case "LEV"
                            v_strLEV = v_strValue
                        Case "MENUTYPE"
                            v_strMENUTYPE = CStr(v_strValue).Trim
                        Case "TXCODE"
                            v_strMODCODE = CStr(v_strValue).Trim
                        Case "CMDALLOW"
                            v_strCMDALLOW = v_strValue
                        Case "STRAUTH"
                            v_strAUTH = v_strValue
                    End Select
                Next
                'Fill to hashtable
                v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & "M"
                If hReportFilter(v_strCMDID) Is Nothing Then
                    hReportFilter.Add(v_strCMDID, v_strHashValue)
                End If
                'Fill to Children hashtable
                If v_strMENUTYPE = "R" Then
                    Dim v_strRPTCNT As String
                    If AssignType = "User" Then
                        v_strSQL = "SELECT COUNT(RPTID) RPTCNT " _
                            & "FROM RPTMASTER M, CMDAUTH A, APPMODULES APP " _
                            & "WHERE APP.TXCODE = '" & v_strMODCODE & "' AND SUBSTR(M.RPTID, 0, 2) = APP.MODCODE AND M.RPTID = A.CMDCODE " _
                            & "AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                            & "ORDER BY M.RPTID"
                    ElseIf AssignType = "Group" Then
                        v_strSQL = "SELECT COUNT(RPTID) RPTCNT " _
                            & "FROM RPTMASTER M, CMDAUTH A, APPMODULES APP " _
                            & "WHERE APP.TXCODE = '" & v_strMODCODE & "' AND SUBSTR(M.RPTID, 0, 2) = APP.MODCODE AND M.RPTID = A.CMDCODE " _
                            & "AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                            & "ORDER BY M.RPTID"
                    End If

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
                                Case "RPTCNT"
                                    v_strRPTCNT = CStr(v_strValue).Trim
                            End Select
                        Next
                    Next
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strRPTCNT
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If

                Else
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strCNT
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If
                End If

                'mv_strReportAuth &= v_strHashValue & "#"

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
            grbRptAccessRight.Width = pnlFuncAssign.Width - 20
            grbTransAccessRight.Width = pnlFuncAssign.Width - 20
            grbGnrAccessRight.Width = pnlFuncAssign.Width - 20
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục ẩn các control phân quyền --''
    ''---------------------------------------''
    Private Sub DisableAssignment()
        Try
            'grbAccessRight.Enabled = False\
            grbAccessRight.Visible = False
            grbRptAccessRight.Visible = False
            grbTransAccessRight.Visible = False
            grbGnrAccessRight.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------------''
    ''-- Thủ tục hiển thị các control phân quyền --''
    ''---------------------------------------------''
    Private Sub EnableAssignment()
        Try
            grbAccessRight.Visible = True
            grbAccessRight.Enabled = True
            grbRptAccessRight.Visible = False
            grbTransAccessRight.Visible = False
            grbGnrAccessRight.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnableAllAssignment()
        Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
        Try
            '--NHom phan quyen chuc nang
            grbAccessRight.Width = 335
            grbAccessRight.Height = 200
            grbAccessRight.Location = New Point(10, 45)
            grbAccessRight.Visible = True
            grbAccessRight.Enabled = True
            ckbACCESS.Enabled = True
            ckbACCESS.Checked = False
            ckbINQUIRY.Enabled = True
            ckbINQUIRY.Checked = False
            ckbADD.Enabled = True
            ckbADD.Checked = False
            ckbEDIT.Enabled = True
            ckbEDIT.Checked = False
            ckbDELETE.Enabled = True
            ckbDELETE.Checked = False
            ckbAPPROVE.Enabled = True
            ckbAPPROVE.Checked = False
            '--Nhom phan quyen giao dich
            grbTransAccessRight.Width = 335
            grbTransAccessRight.Height = 200
            grbTransAccessRight.Location = New Point(355, 45)
            grbTransAccessRight.Visible = True
            grbTransAccessRight.Enabled = True
            If mv_strRight <> String.Empty Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)
                'Enable textboxs
                txtTELLERLIMIT.Enabled = (v_strTeller = "Y")
                txtOFFICERLIMIT.Enabled = (v_strOfficer = "Y")
                txtCHECKERLIMIT.Enabled = (v_strChecker = "Y")
                txtCASHIERLIMIT.Enabled = (v_strCashier = "Y")
                txtTELLERLIMIT.Text = String.Empty
                txtOFFICERLIMIT.Text = String.Empty
                txtCHECKERLIMIT.Text = String.Empty
                txtCASHIERLIMIT.Text = String.Empty
            End If
            '--Nhom phan quyen bao cao
            grbRptAccessRight.Width = 335
            grbRptAccessRight.Height = 200
            grbRptAccessRight.Location = New Point(10, 255)
            grbRptAccessRight.Visible = True
            grbRptAccessRight.Enabled = True
            ckbRPTPRINT.Enabled = False
            ckbRPTVIEW.Enabled = False
            ckbRPTPRINT.Checked = False
            ckbRPTVIEW.Checked = False
            ckbRPTADD.Enabled = True
            ckbRPTADD.Checked = False
            '--Nhom phan quyen general view
            grbGnrAccessRight.Width = 335
            grbGnrAccessRight.Height = 200
            grbGnrAccessRight.Location = New Point(355, 255)
            grbGnrAccessRight.Visible = True
            grbGnrAccessRight.Enabled = True

            'Enable textboxs
            ckbGNRACC.Enabled = True
            ckbGNRACC.Checked = False
            cboGNRCURR.Enabled = True
            If ckbGNRACC.Checked Then
                If mv_strRight <> String.Empty Then
                    v_strTeller = Mid(mv_strRight, 1, 1)
                    v_strCashier = Mid(mv_strRight, 2, 1)
                    v_strOfficer = Mid(mv_strRight, 3, 1)
                    v_strChecker = Mid(mv_strRight, 4, 1)
                    txtGNRTELLERLM.Enabled = (v_strTeller = "Y")
                    txtGNROFFICERLM.Enabled = (v_strOfficer = "Y")
                    txtGNRCHECKERLM.Enabled = (v_strChecker = "Y")
                    txtGNRCASHIERLM.Enabled = False
                    txtGNRTELLERLM.Text = String.Empty
                    txtGNROFFICERLM.Text = String.Empty
                    txtGNRCHECKERLM.Text = String.Empty
                End If
            Else
                txtGNRTELLERLM.Enabled = False
                txtGNROFFICERLM.Enabled = False
                txtGNRCHECKERLM.Enabled = False
                txtGNRCASHIERLM.Enabled = False
                cboGNRCURR.Enabled = False
                txtGNRTELLERLM.Text = String.Empty
                txtGNROFFICERLM.Text = String.Empty
                txtGNRCHECKERLM.Text = String.Empty
                txtGNRCASHIERLM.Text = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnableTransAssignment()
        Try
            grbTransAccessRight.Visible = True
            grbTransAccessRight.Enabled = True
            grbTransAccessRight.Left = grbAccessRight.Left
            grbTransAccessRight.Location = grbAccessRight.Location
            grbAccessRight.Visible = False
            grbRptAccessRight.Visible = False
            grbGnrAccessRight.Visible = False

            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
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
                v_arr = stvFuncMenu.SelectedItem.Key.Split("|")
                If v_arr.Length = 5 Then
                    v_strTXTYPE = CStr(v_arr(4)).Trim
                End If
                If (v_strTXTYPE = "D") Or (v_strTXTYPE = "W") Then
                    txtCASHIERLIMIT.Enabled = (v_strCashier = "Y")
                Else
                    txtCASHIERLIMIT.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnableRptAssignment()
        Try
            grbRptAccessRight.Visible = True
            grbRptAccessRight.Enabled = True
            grbRptAccessRight.Left = grbAccessRight.Left
            grbRptAccessRight.Location = grbAccessRight.Location
            grbAccessRight.Visible = False
            grbTransAccessRight.Visible = False
            grbGnrAccessRight.Visible = False
            ckbRPTPRINT.Enabled = False
            ckbRPTVIEW.Enabled = False
            'cboRPTAREA.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnableGnrAssignment()
        Try
            grbGnrAccessRight.Visible = True
            grbGnrAccessRight.Enabled = True
            grbGnrAccessRight.Left = grbAccessRight.Left
            grbGnrAccessRight.Location = grbAccessRight.Location
            grbAccessRight.Visible = False
            grbRptAccessRight.Visible = False
            grbTransAccessRight.Visible = False

            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            Dim v_strTLTXCD, v_strRPTID, v_strLEV, v_strLAST As String
            Dim v_strTXTYPE, v_arr(), v_arrID() As String
            v_arr = stvFuncMenu.SelectedItem.Key.Split("|")
            v_strLEV = v_arr(1)
            v_strLAST = v_arr(2)
            If v_strLAST = "Y" Then
                v_strTXTYPE = CStr(v_arr(4)).Trim
                v_arrID = CStr(v_arr(0)).Split("^")
                v_strRPTID = v_arrID(0)
                v_strTLTXCD = v_arrID(1)
            End If

            ckbGNRACC.Enabled = True
            If mv_strRight <> String.Empty And v_strTLTXCD <> "EXEC" And v_strTLTXCD <> "VIEW" And v_strLAST = "Y" And ckbGNRACC.Checked Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)

                'Enable textboxs
                txtGNRTELLERLM.Enabled = (v_strTeller = "Y")
                txtGNROFFICERLM.Enabled = (v_strOfficer = "Y")
                txtGNRCHECKERLM.Enabled = (v_strChecker = "Y")


                If (v_strTXTYPE = "D") Or (v_strTXTYPE = "W") Then
                    txtGNRCASHIERLM.Enabled = (v_strCashier = "Y")
                Else
                    txtGNRCASHIERLM.Enabled = False
                End If
                cboGNRCURR.Enabled = True
            ElseIf v_strLAST = "N" And mv_strRight <> String.Empty And ckbGNRACC.Checked Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)

                'Enable textboxs
                txtGNRTELLERLM.Enabled = (v_strTeller = "Y")
                txtGNROFFICERLM.Enabled = (v_strOfficer = "Y")
                txtGNRCHECKERLM.Enabled = (v_strChecker = "Y")
                txtGNRCASHIERLM.Enabled = False
                cboGNRCURR.Enabled = True
            Else
                txtGNRTELLERLM.Enabled = False
                txtGNROFFICERLM.Enabled = False
                txtGNRCHECKERLM.Enabled = False
                txtGNRCASHIERLM.Enabled = False
                cboGNRCURR.Enabled = False
                txtGNRTELLERLM.Text = String.Empty
                txtGNROFFICERLM.Text = String.Empty
                txtGNRCHECKERLM.Text = String.Empty
                txtGNRCASHIERLM.Text = String.Empty
            End If
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
            ckbAPPROVE.Enabled = False
            grbRptAccessRight.Enabled = False
            grbTransAccessRight.Enabled = False
            grbGnrAccessRight.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    ''----------------------------------------------''
    ''-- Thủ tục ghi nội dung phân quyền vào CSDL --''
    ''----------------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_strAllStrAuth, v_strGrpUsrId, v_strAuthString As String
        Dim v_strAllAuthString, v_strMenuKeyAuth, v_strTransAuth As String

        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long
            Dim v_strErrorSource, v_strErrorMessage As String

            If txtCASHIERLIMIT.Focus Or txtCHECKERLIMIT.Focus Or txtTELLERLIMIT.Focus Or txtOFFICERLIMIT.Focus _
                Or txtGNRCASHIERLM.Focus Or txtGNRCHECKERLM.Focus Or txtGNROFFICERLM.Focus Or txtGNRTELLERLM.Focus Then
                SendKeys.Send("{Tab}")
                SendKeys.Flush()
            End If

            If AssignType = "User" Then
                'Get strAuth from menu            
                'v_strAllStrAuth = GetAuthString(stvFuncMenu.Items(0))
                v_strAllStrAuth = UserId & "$" & mv_strFuncAuth

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllStrAuth, "FunctionAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If


                'Phan quyen giao dich
                'Get Auth string from menu
                'v_strMenuKeyAuth = GetMenuKeyAuthString(stvTransMenu.Items(0))
                v_strMenuKeyAuth = mv_strTransAuthString
                'Get Auth string of all transactions
                v_strAllAuthString = UserId & "$" & v_strMenuKeyAuth & "$" & mv_strTlauthString

                'Buil XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllAuthString, "TransactionAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

                'Phan quyen bao cao
                'Get strAuth from menu            
                'v_strAllStrAuth = GetAuthString(stvRptMenu.Items(0))
                v_strAllStrAuth = UserId & "$" & mv_strReportAuth

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllStrAuth, "ReportAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

            ElseIf AssignType = "Group" Then
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get strAuth from menu            
                'v_strStrAuth = GetAuthString(stvFuncMenu.Items(0))
                v_strAuthString = mv_strFuncAuth
                'Add Groupid and Usersid string to strAuth
                v_strAllStrAuth = GroupId & "$" & v_strAuthString & "$" & v_strGrpUsrId

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllStrAuth, "FunctionAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

                'Phan quyen giao dich
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get Auth string from menu
                'v_strMenuKeyAuth = GetMenuKeyAuthString(stvTransMenu.Items(0))
                v_strMenuKeyAuth = mv_strTransAuthString
                'Get Auth string of all transactions
                v_strAllAuthString = GroupId & "$" & v_strMenuKeyAuth & "$" & mv_strTlauthString & "$" & v_strGrpUsrId

                'Buil XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllAuthString, "TransactionAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

                'Phan quyen bao cao
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get strAuth from menu            
                'v_strAuthString = GetAuthString(stvRptMenu.Items(0))
                v_strAuthString = mv_strReportAuth
                'Add Groupid and Usersid string to strAuth
                v_strAllStrAuth = GroupId & "$" & v_strAuthString & "$" & v_strGrpUsrId

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllStrAuth, "ReportAssignment")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

            End If

            ''Reset lai Index Inmage
            ChangeImageIndex(stvFuncMenu.Items(0))

            MsgBox(mv_ResourceManager.GetString("SavingSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'Me.Close()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Private Function AddTreeNode(ByRef pv_nodeParent As Node, _
                                     ByVal pv_strKey As String, _
                                     ByVal pv_strName As String, _
                                     ByVal pv_strLast As String, _
                                     Optional ByVal pv_intImageIdx As Integer = 0, _
                                        Optional ByVal pv_strObjName As String = "") As Node
        Try
            'Create new node
            Dim v_node As New Node(pv_strName, pv_intImageIdx)

            v_node.Key = pv_strKey
            v_node.Text = pv_strName
            v_node.ToolTipText = pv_strName
            If pv_strLast = "N" Then
                v_node.Expanded = False
            End If
            'Add node to menu tree
            pv_nodeParent.Items.Add(v_node)
            Return v_node
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function AddTreeAdjustNode(ByRef pv_nodeParent As Node, _
                                     ByVal pv_strKey As String, _
                                     ByVal pv_strTag As String, _
                                     ByVal pv_strName As String, _
                                     ByVal pv_strLast As String, _
                                     Optional ByVal pv_intImageIdx As Integer = 0) As Node
        Try
            'Create new node
            Dim v_node As New Node(pv_strName, pv_intImageIdx)

            v_node.Key = pv_strKey
            v_node.Text = pv_strName
            v_node.Tag = pv_strTag
            v_node.ToolTipText = pv_strName
            If pv_strLast = "N" Then
                v_node.Expanded = False
            End If
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
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetParentMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , GroupId, "GetParentMenu")
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

                        nCountChildCall = 0
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

    Private Sub DisplayAdjustMenus(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFuncHashValue, v_strMenuKey, v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strCMDALLOW, v_strSTRAUTH, v_strLEV, v_arrHashKey() As String

        Try
            If IsShown Then
                If AssignType = "User" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetParentAdjustMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , GroupId, "GetParentAdjustMenu")
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
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    If v_strPRID = "000000" Then
                        v_strMenuKey = v_strCMDID & "|" & v_strLEV

                        Dim v_node As New Node(v_strCmdName, v_intIndex)
                        v_node.Key = CStr(v_strMenuKey)
                        v_node.ToolTipText = v_strCmdName
                        v_node.Expanded = False

                        Me.stvFuncMenu.Items(1).Items.Add(v_node)
                        AddChildAdjustMenu(stvFuncMenu.Items(1).Items(CStr(v_strMenuKey)), CStr(v_strMenuKey))
                    End If
                Next v_intCount
            Else
                Me.stvFuncMenu.Items(1).Items.Clear()
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
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strLast, v_strMenuType, v_strLEV, v_strAUTHCODE As String
        Dim v_strModCode, v_strObjName, v_strMenuKey, v_arrHashKey() As String
        Dim v_strCMDALLOW, v_strSTRAUTH, v_strFuncHashValue As String
        Dim v_NewNode As New Node

        Try
            nCountChildCall = nCountChildCall + 1
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetChildMenu")
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
                                Case "AUTHCODE"
                                    v_strAUTHCODE = Trim(v_strValue)
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

                    hModCodeFilter.Add(v_strCMDID, v_strModCode)

                    'If (Trim(v_strMenuType) <> "R") And (Trim(v_strMenuType) <> "T") Then
                    'Set menu's key
                    v_strMenuKey = v_strCMDID & "|" & v_strLEV & "|" & v_strLast & "|" & "M" & "|" & v_strMenuType & "|" & v_strAUTHCODE
                    'Add new node to menu tree
                    v_NewNode = AddTreeNode(pv_nodeParent, v_strMenuKey, v_strCmdName, v_strLast, v_intIndex)
                    AddChildMenu(v_NewNode, v_strMenuKey)
                    ''Add new value to hashtable
                    hParentsFilter.Add(v_strCMDID, v_strPRID)
                    'End If

                    'FILL MENU RPT, TRANSACTION, GENERALVIEW
                    Dim v_strNodeKey As String
                    If v_strMenuType = "T" Then
                        v_strNodeKey = v_strCMDID & "|" & v_strLEV & "|" & v_strModCode
                        AddTransChildMenu(v_NewNode, v_strNodeKey)
                    ElseIf v_strMenuType = "R" Then
                        v_strNodeKey = v_strCMDID & "|" & v_strLEV & "|" & v_strModCode
                        AddRptChildMenu(v_NewNode, v_strNodeKey)
                    ElseIf v_strMenuType = "G" Then
                        v_strNodeKey = v_strCMDID & "|" & v_strLEV & "|" & v_strModCode
                        AddGnrViewChildMenu(v_NewNode, v_strNodeKey)
                    End If

                Next v_intCount
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub AddChildAdjustMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strLast, v_strMenuType, v_strLEV, v_strAUTHCODE As String
        Dim v_strModCode, v_strObjName, v_strMenuKey, v_strMenuTag, v_arrHashKey() As String
        Dim v_strCMDALLOW, v_strSTRAUTH, v_strFuncHashValue, v_strREFID, v_strREFCMDID, v_strRefMenuType, v_strREFLEV, v_strRPTID As String
        Dim v_NewNode As New Node

        Try
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetChildAdjustMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetChildAdjustMenu")
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
                                Case "REFMENUTYPE"
                                    v_strRefMenuType = Trim(v_strValue)
                                Case "CMDALLOW"
                                    v_strCMDALLOW = Trim(v_strValue)
                                Case "STRAUTH"
                                    v_strSTRAUTH = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                                Case "REFLEV"
                                    v_strREFLEV = Trim(v_strValue)
                                Case "AUTHCODE"
                                    v_strAUTHCODE = Trim(v_strValue)
                                Case "REFID"
                                    v_strREFID = Trim(v_strValue) 'R: RPTID; G: TLTXCD; T: TLTXCD
                                Case "REFCMDID"
                                    v_strREFCMDID = Trim(v_strValue) 'CMDMENU.CMDID
                                Case "IMGINDEX"
                                    v_intIndex = CInt(v_strValue)
                            End Select
                        End With
                    Next v_int



                    'Set menu's key
                    If v_strMenuType.Equals("R") Then
                        v_strMenuKey = v_strREFID & "|" & v_strLEV & "|" & "Y" & "|" & "R" & "|" & v_strMenuType & "|" & v_strCMDID & "|" & v_strREFCMDID
                        'v_strMenuKey = v_strRPTID & "|" & v_strLEV & "|" & "Y" & "|" & "R" & "|" & v_strCMDTYPE
                        v_strMenuTag = v_strREFID & "|" & v_strREFLEV & "|" & "Y" & "|" & "R" & "|" & v_strRefMenuType


                        'Check CMDALLOW of user who is assigned
                        If Not hReportFilter(v_strREFID) Is Nothing Then
                            v_arrHashKey = CStr(hReportFilter(v_strREFID)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If
                    ElseIf v_strMenuType.Equals("G") Then
                        v_strMenuKey = v_strREFID & "|" & v_strLEV & "|" & "Y" & "|" & "G" & "|" & "T" & "|" & v_strCMDID & "|" & v_strREFCMDID
                        'v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & "Y" & "|" & "G" & "|" & v_strTXTYPE
                        v_strMenuTag = v_strREFID & "|" & v_strREFLEV & "|" & "Y" & "|" & "G" & "|" & v_strRefMenuType

                        If InStr(v_strREFID, "^") > 0 Then
                            Dim v_arrID() As String
                            v_arrID = v_strREFID.Split("^")
                            v_strRPTID = v_arrID(0)
                        End If
                        If Not hReportFilter(v_strRPTID) Is Nothing Then
                            v_arrHashKey = CStr(hReportFilter(v_strRPTID)).Split("|")
                            v_strCMDALLOW = Mid(Trim(v_arrHashKey(2)), 1, 1)
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If
                    ElseIf v_strMenuType.Equals("T") Then
                        v_strMenuKey = v_strREFID & "|" & v_strLEV & "|" & "Y" & "|" & "T" & "|" & "T" & "|" & v_strCMDID & "|" & v_strREFCMDID
                        'v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & "Y" & "|" & "T" & "|" & v_strTXTYPE
                        v_strMenuTag = v_strREFID & "|" & v_strREFLEV & "|" & "Y" & "|" & "T" & "|" & v_strRefMenuType

                        'Check CMDALLOW of user who is assigned
                        If Not hTransFilter(v_strREFID) Is Nothing Then
                            v_arrHashKey = CStr(hTransFilter(v_strREFID)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If

                    Else
                        v_strMenuKey = v_strCMDID & "|" & v_strLEV & "|" & v_strLast & "|" & "M" & "|" & v_strMenuType & "|" & v_strAUTHCODE & "|" & v_strCMDID & "|" & v_strREFCMDID
                        'v_strMenuKey = v_strCMDID & "|" & v_strLEV & "|" & v_strLast & "|" & "M" & "|" & v_strMenuType & "|" & v_strAUTHCODE
                        If Not v_strMenuType.Equals("P") Then
                            v_strMenuTag = v_strREFID & "|" & v_strREFLEV & "|" & v_strLast & "|" & "M" & "|" & v_strRefMenuType & "|" & v_strAUTHCODE
                        Else
                            v_strMenuTag = "P"
                        End If
                        'Check CMDALLOW of user who is assigned
                        If Not hFunctionFilter(v_strREFID) Is Nothing Then
                            v_arrHashKey = CStr(hFunctionFilter(v_strREFID)).Split("|")
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
                    End If
                    'Add new node to menu tree
                    v_NewNode = AddTreeAdjustNode(pv_nodeParent, v_strMenuKey, v_strMenuTag, v_strCmdName, v_strLast, v_intIndex)
                    AddChildAdjustMenu(v_NewNode, v_strMenuKey)
                Next v_intCount

                Try
                    If pv_nodeParent.Items.Count <= 0 AndAlso pv_nodeParent.Key.Split("|")(4) = "P" Then
                        If pv_nodeParent.Key.Substring(1, 6) = "000000" Then
                            pv_nodeParent.Items.Clear()
                        Else
                            pv_nodeParent.ParentItem.Items.Remove(pv_nodeParent)
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddTransChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
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
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetTransChildMenu")
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

                        'Check CMDALLOW of user who is assigned
                        If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                            v_arrHashKey = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If

                        v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & "Y" & "|" & "T" & "|" & v_strTXTYPE
                        'Add one child node to menu
                        v_NewNode = AddTreeNode(pv_nodeParent, v_strMenuKey, v_strTXDESC, "Y", v_intIndex)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddRptChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex, v_intLEV As Integer
        Dim v_strFLDNAME, v_strValue, v_strMenuType As String
        Dim v_strObjName, v_strMenuKey, v_strPRCODE, v_strPRID, v_strPRLEV, v_arrKey(), v_arrHashKey() As String
        Dim v_strRPTID, v_strMODCODE, v_strRPTNAME, v_strCMDALLOW, v_strSTRAUTH, v_strLEV, v_strCMDTYPE As String
        Dim v_NewNode As New Node

        Try
            v_arrKey = pv_strKey.Split("|")
            v_strPRCODE = CStr(hModCodeFilter(v_arrKey(0)))
            v_strPRLEV = CStr(v_arrKey(1))
            v_strPRID = CStr(v_arrKey(0))
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetRptChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetRptChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            v_intLEV = CInt(v_strPRLEV) + 1
            v_strLEV = CStr(v_intLEV)

            If Not pv_nodeParent Is Nothing Then
                If v_nodeList.Count > 0 Then
                    For v_intCount = 0 To v_nodeList.Count - 1
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString

                                Select Case Trim(v_strFLDNAME)
                                    Case "RPTID"
                                        v_strRPTID = Trim(v_strValue)
                                    Case "MODCODE"
                                        v_strMODCODE = Trim(v_strValue)
                                    Case "RPTNAME"
                                        v_strRPTNAME = Trim(v_strValue)
                                    Case "CMDTYPE"
                                        v_strCMDTYPE = Trim(v_strValue)
                                        'Case "IMGINDEX"
                                        '    v_intIndex = CInt(Trim(v_strValue))
                                        'Case "CMDALLOW"
                                        '    v_strCMDALLOW = Trim(v_strValue)
                                        'Case "STRAUTH"
                                        '    v_strSTRAUTH = Trim(v_strValue)
                                        'Case "LEV"
                                        '    v_strLEV = Trim(v_strValue)
                                End Select
                            End With
                        Next v_int

                        'Check CMDALLOW of user who is assigned
                        If Not hReportFilter(v_strRPTID) Is Nothing Then
                            v_arrHashKey = CStr(hReportFilter(v_strRPTID)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If


                        'If v_strCMDALLOW = "" Then
                        '    v_strCMDALLOW = "N"
                        'End If
                        'If Trim(v_strCMDALLOW) = "Y" Then
                        '    v_intIndex = 5
                        'Else
                        '    v_intIndex = 3
                        'End If
                        'If v_strSTRAUTH = "" Then
                        '    v_strSTRAUTH = "NNNN"
                        'End If

                        v_strMenuKey = v_strRPTID & "|" & v_strLEV & "|" & "Y" & "|" & "R" & "|" & v_strCMDTYPE

                        AddTreeNode(pv_nodeParent, v_strMenuKey, v_strRPTNAME, "Y", v_intIndex)
                        'AddChildMenu(v_NewNode, v_strRPTID)
                        'Add new value to hashtable
                        'Dim v_strRptHashValue As String
                        If hParentsFilter(v_strRPTID) Is Nothing Then
                            hParentsFilter.Add(v_strRPTID, v_strPRID)
                        End If
                        'v_strRptHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strSTRAUTH
                        'hReportFilter.Add(v_strRPTID, v_strRptHashValue)
                        'mv_strReportAuth &= v_strRptHashValue & "#"
                    Next v_intCount
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddGnrViewChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex, v_intLEV As Integer
        Dim v_strFLDNAME, v_strValue, v_strMenuType As String
        Dim v_strObjName, v_strMenuKey, v_strPRCODE, v_strPRLEV, v_arrKey(), v_arrHashKey() As String
        Dim v_strRPTID, v_strMODCODE, v_strRPTNAME, v_strCMDALLOW, v_strSTRAUTH, v_strLEV, v_strCMDTYPE As String
        Dim v_strTLTXCD, v_strTXDESC, v_strTXTYPE, v_strLIMIT, v_strCURRCODE, v_strPRID As String
        Dim v_NewNode As New Node

        Try
            v_arrKey = pv_strKey.Split("|")
            v_strPRID = v_arrKey(0)
            v_strPRCODE = CStr(hModCodeFilter(v_arrKey(0)))
            v_strPRLEV = CStr(v_arrKey(1))
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetGnrViewChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetGnrViewChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            v_intLEV = CInt(v_strPRLEV) + 1
            v_strLEV = CStr(v_intLEV)

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
                                End Select
                            End With
                        Next v_int

                        'Check CMDALLOW of user who is assigned

                        If InStr(v_strTLTXCD, "^") > 0 Then
                            Dim v_arrID() As String
                            v_arrID = v_strTLTXCD.Split("^")
                            v_strRPTID = v_arrID(0)
                        End If
                        If Not hReportFilter(v_strRPTID) Is Nothing Then
                            v_arrHashKey = CStr(hReportFilter(v_strRPTID)).Split("|")
                            v_strCMDALLOW = Mid(Trim(v_arrHashKey(2)), 1, 1)
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If


                        'If v_strCMDALLOW = "" Then
                        '    v_strCMDALLOW = "N"
                        'End If
                        'If Trim(v_strCMDALLOW) = "Y" Then
                        '    v_intIndex = 5
                        'Else
                        '    v_intIndex = 3
                        'End If
                        'If v_strSTRAUTH = "" Then
                        '    v_strSTRAUTH = "NNNN"
                        'End If

                        v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & "Y" & "|" & "G" & "|" & v_strTXTYPE

                        'v_strMenuKey = v_strRPTID & "|" & v_strLEV & "|" & "G" & "|" & v_strCMDTYPE

                        AddTreeNode(pv_nodeParent, v_strMenuKey, v_strTXDESC, "Y", v_intIndex)
                        'AddChildMenu(v_NewNode, v_strRPTID)
                        'Add new value to hashtable
                        'Dim v_strRptHashValue As String
                        If hParentsFilter(v_strTLTXCD) Is Nothing Then
                            hParentsFilter.Add(v_strTLTXCD, v_strPRID)
                        End If
                        'v_strRptHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strSTRAUTH
                        'hReportFilter.Add(v_strRPTID, v_strRptHashValue)
                        'mv_strReportAuth &= v_strRptHashValue & "#"
                    Next v_intCount
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub Menu_Click(ByVal pv_treeNode As Node)
        'mv_currnodeIdx = pv_treeNode.Index
        'Update mouse pointer
        Cursor.Current = Cursors.WaitCursor
        Dim v_arrMenuKey As String()
        Dim v_strLEV, v_strMenuType, v_strSubMenuType As String
        Try

            If pv_treeNode.Key <> "" Then
                Try
                    v_arrMenuKey = pv_treeNode.Key.Split("|")
                    v_strLEV = v_arrMenuKey(1)
                    If CInt(v_strLEV) > 1 Then
                        v_strMenuType = v_arrMenuKey(3)
                        v_strSubMenuType = v_arrMenuKey(4)
                    End If
                Catch ex As Exception
                    v_strMenuType = "P"
                    v_strSubMenuType = "P"
                End Try

                lblFUNCTION.Text = pv_treeNode.Text
                If (pv_treeNode.Tag = "P" OrElse (pv_treeNode.ImageIndex <> 3 And pv_treeNode.ImageIndex <> 5)) _
                    AndAlso Not (v_strMenuType = "M" And v_strSubMenuType = "T") _
                    AndAlso Not (v_strMenuType = "M" And v_strSubMenuType = "R") _
                    AndAlso Not (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                    EnableAllAssignment()
                Else
                    If Not pv_treeNode.Tag Is Nothing Then
                        ShowAccessRight(CType(GetNodeMenuByKey(pv_treeNode.Tag, Me.stvFuncMenu.Items(0)), Node))
                    Else
                        ShowAccessRight(pv_treeNode)
                    End If
                End If
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
        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)

            If v_strMenuType = "M" And InStr("T/R/G", v_strSubMenuType) = 0 Then
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
        Dim v_strAuth, v_strCMDID, v_strLast, v_strLEV, v_strSubMenuType, v_arrAuth() As String


        Try
            If pv_treeNode.Index = mv_currnodeIdx Then
                Return
            Else
                mv_currnodeIdx = pv_treeNode.Index
                Me.txtCASHIERLIMIT.Text = String.Empty
                Me.txtCHECKERLIMIT.Text = String.Empty
                Me.txtOFFICERLIMIT.Text = String.Empty
                Me.txtTELLERLIMIT.Text = String.Empty
            End If

            If pv_treeNode.Key <> "" Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                v_strCMDID = v_arrMenuKey(0)
                v_strLEV = v_arrMenuKey(1)
                If CInt(v_strLEV) > 1 Then
                    v_strLast = v_arrMenuKey(2)
                    v_strMenuType = v_arrMenuKey(3)
                    v_strSubMenuType = v_arrMenuKey(4)

                    If v_strMenuType = "M" And InStr("T/R/G", v_strSubMenuType) = 0 Then
                        EnableAssignment()
                        ShowFuncAccessRight(pv_treeNode)
                    ElseIf v_strMenuType = "T" Or (v_strMenuType = "M" And v_strSubMenuType = "T") Then
                        EnableTransAssignment()
                        If VerifyDataType() Then
                            mv_node = pv_treeNode
                            'Display transaction access right
                            ShowTransAccessRight(cboCURRCOD, pv_treeNode)
                        End If

                    ElseIf v_strMenuType = "R" Or (v_strMenuType = "M" And v_strSubMenuType = "R") Then
                        EnableRptAssignment()
                        'Display report access right
                        ShowRptAccessRight(pv_treeNode)
                    ElseIf v_strMenuType = "G" Or (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                        EnableGnrAssignment()
                        If VerifyDataType() Then
                            mv_node = pv_treeNode
                            'Display transaction access right
                            ShowGnrAccessRight(cboGNRCURR, pv_treeNode)
                        End If
                    End If
                Else
                    DisableAssignment()
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

    Private Sub ChangeImageIndex(ByRef pv_treeNode As Node, Optional ByVal pv_treeAdjustNode As Node = Nothing)
        Dim v_arrMenuKey() As String
        Dim v_strAuth, v_strCMDID, v_arrAuth() As String
        Dim v_strMenuType, v_strLEV, v_strSubMenuType, v_strLast, v_strTLTXCD As String

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            If v_arrMenuKey.Length > 1 Then
                v_strCMDID = v_arrMenuKey(0)
                v_strLEV = v_arrMenuKey(1)
                If CInt(v_strLEV) > 1 Then
                    v_strLast = v_arrMenuKey(2)
                    v_strMenuType = v_arrMenuKey(3)
                    v_strSubMenuType = v_arrMenuKey(4)
                End If

                If CInt(v_strLEV) = 1 Or v_strMenuType = "M" Then
                    If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                        v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                        v_strAuth = v_arrAuth(2)
                    Else
                        v_strAuth = "NNNNNN"
                    End If
                    If Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count > 0 Then
                        pv_treeNode.ImageIndex = 4
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 4
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 5
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 5
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "N" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 3
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 3
                        End If
                    Else
                        pv_treeNode.ImageIndex = 0
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 0
                        End If
                    End If
                    'Set imageindex for parent
                    If CInt(v_strLEV) > 1 Then 'Node con
                        Dim v_parentNode As Node
                        Dim v_Node As Node
                        v_Node = pv_treeNode
                        For i As Integer = 1 To CInt(v_strLEV) - 1
                            v_parentNode = v_Node.ParentItem
                            If Not v_parentNode Is Nothing Then
                                If v_Node.ImageIndex = 5 Then
                                    v_parentNode.ImageIndex = 4
                                Else
                                    Dim count As Integer
                                    count = 0
                                    For Each objNode As Node In v_parentNode.Items
                                        If objNode.ImageIndex = 5 Or objNode.ImageIndex = 4 Then
                                            count = count + 1
                                        End If
                                    Next
                                    If count > 0 Then
                                        v_parentNode.ImageIndex = 4
                                    Else
                                        v_parentNode.ImageIndex = 0
                                    End If
                                End If
                            End If
                            v_Node = v_parentNode
                        Next
                    End If
                ElseIf v_strMenuType = "R" Then
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                        v_strAuth = v_arrAuth(2)
                    Else
                        v_strAuth = "NNN"
                    End If
                    If Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count > 0 Then
                        pv_treeNode.ImageIndex = 4
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 4
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 5
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 5
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "N" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 3
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 3
                        End If
                    Else
                        pv_treeNode.ImageIndex = 0
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 0
                        End If
                    End If
                    'Set imageindex for parent
                    'Set imageindex for parent
                    If CInt(v_strLEV) > 1 Then 'Node con
                        Dim v_parentNode As Node
                        Dim v_Node As Node
                        v_Node = pv_treeNode
                        For i As Integer = 1 To CInt(v_strLEV) - 1
                            v_parentNode = v_Node.ParentItem
                            If Not v_parentNode Is Nothing Then
                                If v_Node.ImageIndex = 5 Then
                                    v_parentNode.ImageIndex = 4
                                Else
                                    Dim count As Integer
                                    count = 0
                                    For Each objNode As Node In v_parentNode.Items
                                        If objNode.ImageIndex = 5 Or objNode.ImageIndex = 4 Then
                                            count = count + 1
                                            Exit For
                                        End If
                                    Next
                                    If count > 0 Then
                                        v_parentNode.ImageIndex = 4
                                    Else
                                        v_parentNode.ImageIndex = 0
                                    End If
                                End If
                            End If
                            v_Node = v_parentNode
                        Next
                    End If

                ElseIf v_strMenuType = "T" Then
                    v_arrMenuKey = pv_treeNode.Key.Split("|")
                    v_strTLTXCD = Trim(v_arrMenuKey(0))
                    If v_strTLTXCD.Length = 4 Then
                        If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                            v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                            If v_arrAuth(2) = "Y" Then
                                pv_treeNode.ImageIndex = 5
                                If Not pv_treeAdjustNode Is Nothing Then
                                    pv_treeAdjustNode.ImageIndex = 5
                                End If
                            Else
                                pv_treeNode.ImageIndex = 3
                                If Not pv_treeAdjustNode Is Nothing Then
                                    pv_treeAdjustNode.ImageIndex = 3
                                End If
                            End If
                        End If
                    Else
                        'Check CMDALLOW of user who is assigned
                        If Not (v_strTLTXCD Is Nothing Or v_strTLTXCD.Length = 0) Then
                            If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                                v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                                If v_arrAuth(2) = "Y" Then
                                    pv_treeNode.ImageIndex = 4
                                    If Not pv_treeAdjustNode Is Nothing Then
                                        pv_treeAdjustNode.ImageIndex = 4
                                    End If
                                Else
                                    pv_treeNode.ImageIndex = 0
                                    If Not pv_treeAdjustNode Is Nothing Then
                                        pv_treeAdjustNode.ImageIndex = 0
                                    End If
                                End If
                            Else
                                pv_treeNode.ImageIndex = 0
                                If Not pv_treeAdjustNode Is Nothing Then
                                    pv_treeAdjustNode.ImageIndex = 0
                                End If
                            End If
                        End If

                    End If
                    'Set imageindex for parent
                    If CInt(v_strLEV) > 1 Then 'Node con
                        Dim v_parentNode As Node
                        Dim v_Node As Node
                        v_Node = pv_treeNode
                        For i As Integer = 1 To CInt(v_strLEV) - 1
                            v_parentNode = v_Node.ParentItem
                            If Not v_parentNode Is Nothing Then
                                If v_Node.ImageIndex = 5 Then
                                    v_parentNode.ImageIndex = 4
                                Else
                                    Dim count As Integer
                                    count = 0
                                    For Each objNode As Node In v_parentNode.Items
                                        If objNode.ImageIndex = 5 Or objNode.ImageIndex = 4 Then
                                            count = count + 1
                                            Exit For
                                        End If
                                    Next
                                    If count > 0 Then
                                        v_parentNode.ImageIndex = 4
                                    Else
                                        v_parentNode.ImageIndex = 0
                                    End If
                                End If
                            End If
                            v_Node = v_parentNode
                        Next
                    End If

                ElseIf v_strMenuType = "G" Then
                    If InStr(v_strCMDID, "^") > 0 Then
                        Dim v_arrID() As String
                        v_arrID = v_strCMDID.Split("^")
                        v_strCMDID = v_arrID(0)
                    End If
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                        v_strAuth = v_arrAuth(2)
                    Else
                        v_strAuth = "N"
                    End If
                    If Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count > 0 Then
                        pv_treeNode.ImageIndex = 4
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 4
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "Y" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 5
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 5
                        End If
                    ElseIf Mid(v_strAuth, 1, 1) = "N" And pv_treeNode.Items.Count = 0 Then
                        pv_treeNode.ImageIndex = 3
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 3
                        End If
                    Else
                        pv_treeNode.ImageIndex = 0
                        If Not pv_treeAdjustNode Is Nothing Then
                            pv_treeAdjustNode.ImageIndex = 0
                        End If
                    End If
                    'Set imageindex for parent
                    If CInt(v_strLEV) > 1 Then 'Node con
                        Dim v_parentNode As Node
                        Dim v_Node As Node
                        v_Node = pv_treeNode
                        For i As Integer = 1 To CInt(v_strLEV) - 1
                            v_parentNode = v_Node.ParentItem
                            If Not v_parentNode Is Nothing Then
                                If v_Node.ImageIndex = 5 Then
                                    v_parentNode.ImageIndex = 4
                                Else
                                    Dim count As Integer
                                    count = 0
                                    For Each objNode As Node In v_parentNode.Items
                                        If objNode.ImageIndex = 5 Or objNode.ImageIndex = 4 Then
                                            count = count + 1
                                            Exit For
                                        End If
                                    Next
                                    If count > 0 Then
                                        v_parentNode.ImageIndex = 4
                                    Else
                                        v_parentNode.ImageIndex = 0
                                    End If
                                End If
                            End If
                            v_Node = v_parentNode
                        Next
                    End If
                End If
            End If
            If pv_treeAdjustNode Is Nothing Then
                ChangeImageIndexOnAdjustNode(pv_treeNode, Me.stvFuncMenu.Items(1))
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
        Dim v_strLast, v_strMenuType, v_strSubMenuType As String

        Try

            'Get auth string and CMDID
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            If CInt(v_strLEV) > 1 Then
                v_strLast = v_arrMenuKey(2)
                v_strMenuType = v_arrMenuKey(3)
                v_strSubMenuType = v_arrMenuKey(4)
            End If

            If v_strMenuType = "M" And InStr("T/R/G", v_strSubMenuType) = 0 Then
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
                    'If (CInt(v_strLEV) > 1) And (v_strCMDALLOW = "Y") Then
                    If (CInt(v_strLEV) > 1) Then
                        SetParentNodeKey(pv_treeNode, v_strCMDALLOW)
                    End If

                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetNodeMenuByKey(ByVal str As String, ByVal node As Node) As Node
        Dim v_node As Node
        Try
            For i As Integer = 0 To node.Items.Count - 1
                If node.Items(i).Items.Count > 0 Then
                    v_node = CType(GetNodeMenuByKey(str, node.Items(i)), Node)
                    If Not v_node Is Nothing Then
                        Return v_node
                    End If
                End If
                If node.Items(i).Key = str Then
                    Return node.Items(i)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Set lại key của các node cha của 1 node      --''
    ''-- + Đầu vào: pv_treeNode: node có các node cha cần set key --''
    ''-- + Đầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub SetParentNodeKey(ByVal pv_treeNode As Node, ByVal pv_strCMDALLOW As String)
        Dim v_strPRID, v_strLEV, v_strCMDID, v_strAUTH, v_strHashValue, v_arrMenuKey(), v_strMenuType As String
        Dim v_strCMDALLOW, v_strPRLEV, v_arrAuth() As String
        Dim v_intPRLEV As Integer
        Dim v_strRptBRID As String

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strMenuType = v_arrMenuKey(3)
            Dim v_ChildNode, v_ParentsNode As Node
            v_ChildNode = pv_treeNode

            If pv_strCMDALLOW = "Y" Then
                If v_strMenuType = "R" And CInt(v_strLEV) = 4 Then
                    v_strPRID = hParentsFilter(v_strCMDID)
                    v_strRptBRID = v_strPRID
                    v_strPRLEV = 3
                    If Not hReportFilter(v_strPRID) Is Nothing Then
                        v_arrAuth = CStr(hReportFilter(v_strPRID)).Split("|")
                        v_strAUTH = v_arrAuth(2)
                        v_strMenuType = v_arrAuth(3)
                        v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                        If v_strCMDALLOW = "N" Then
                            v_strCMDALLOW = "Y"
                        End If
                        v_strAUTH = v_strCMDALLOW & Mid(v_strAUTH, 2)
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hReportFilter(v_strPRID)
                        hReportFilter.Remove(v_strPRID)
                        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                        hReportFilter.Add(v_strPRID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    Else
                        v_strAUTH = "YNN"
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                        'Add new value to hash table and auth's string
                        hReportFilter.Add(v_strPRID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If
                ElseIf v_strMenuType = "G" And CInt(v_strLEV) = 4 Then
                    'Neu la general view cua GD thi update node cha GD tuong ung trong TH GD thuc hien truc tiep
                    Dim v_strTLTXCD As String
                    v_strTLTXCD = Mid(v_strCMDID, InStr(v_strCMDID, "^") + 1)
                    If Not hParentsFilter(v_strTLTXCD) Is Nothing Then
                        v_strPRID = hParentsFilter(v_strTLTXCD)
                        v_strPRLEV = "3"
                        If IsNumeric(txtGNRTELLERLM.Text) Or IsNumeric(txtGNRCASHIERLM.Text) Or IsNumeric(txtGNRCHECKERLM.Text) Or IsNumeric(txtGNROFFICERLM.Text) Then
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
                        End If
                    End If

                End If
                For i As Integer = 0 To CInt(v_strLEV) - 2
                    v_strPRID = hParentsFilter(v_strCMDID)
                    v_intPRLEV = CInt(v_strLEV) - (i + 1)
                    v_strPRLEV = CStr(v_intPRLEV)
                    If v_strPRID Is Nothing Then
                        Exit For
                    End If
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
                        'Neu la node cha cua bao cao thi ghi nhan chuoi phan quyen bao cao
                        If v_strPRID = v_strRptBRID Then
                            v_strAUTH = "YNN"
                        Else
                            v_strAUTH = "YNNNNN"
                        End If
                        v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strPRID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If

                    v_strCMDID = v_strPRID
                Next

            ElseIf pv_strCMDALLOW = "N" Then
                'Kiem tra cac menu con, neu ko con menu nao co quyen thi xoa quyen
                Dim v_intCount As Integer
                Dim v_arrPR() As String
                Dim v_strPRMenuType As String
                For i As Integer = 1 To CInt(v_strLEV) - 1
                    v_intCount = 0
                    v_ParentsNode = v_ChildNode.ParentItem
                    If Not v_ParentsNode Is Nothing Then
                        v_arrPR = v_ParentsNode.Key.Split("|")
                        v_strPRID = v_arrPR(0)
                        'v_strPRMenuType = v_arrPR(3)
                        For Each objNode As Node In v_ParentsNode.Items
                            v_arrMenuKey = objNode.Key.Split("|")
                            v_strCMDID = v_arrMenuKey(0)
                            v_strLEV = v_arrMenuKey(1)
                            v_strMenuType = v_arrMenuKey(3)
                            If v_strMenuType = "M" Then
                                If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                                    v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                                    v_strAUTH = v_arrAuth(2)
                                    v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                                    If v_strCMDALLOW = "Y" Then
                                        v_intCount += 1
                                        Exit For
                                    End If
                                End If
                            ElseIf v_strMenuType = "T" Then
                                If Not hTransFilter(v_strCMDID) Is Nothing Then
                                    v_arrAuth = CStr(hTransFilter(v_strCMDID)).Split("|")
                                    v_strAUTH = v_arrAuth(2)
                                    v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                                    If v_strCMDALLOW = "Y" Then
                                        v_intCount += 1
                                        Exit For
                                    End If
                                End If
                            ElseIf v_strMenuType = "R" Then
                                If Not hReportFilter(v_strCMDID) Is Nothing Then
                                    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                                    v_strAUTH = v_arrAuth(2)
                                    v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                                    If v_strCMDALLOW = "Y" Then
                                        v_intCount += 1
                                        Exit For
                                    End If
                                End If
                            ElseIf v_strMenuType = "G" Then
                                v_strCMDID = Mid(v_strCMDID, 1, InStr(v_strCMDID, "^") - 1)
                                If Not hReportFilter(v_strCMDID) Is Nothing Then
                                    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                                    v_strAUTH = v_arrAuth(2)
                                    v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                                    If v_strCMDALLOW = "Y" Then
                                        v_intCount += 1
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        If v_intCount = 0 Then
                            'Set lai gia tri quyen 
                            v_strAUTH = "NNNNNN"
                            If Not hFunctionFilter(v_strPRID) Is Nothing Then
                                'Remove old value before add new value to hash table and auth's string
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hFunctionFilter(v_strPRID)
                                hFunctionFilter.Remove(v_strPRID)
                                mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                            End If

                            'Neu la report thi xoa di
                            If Not hReportFilter(v_strPRID) Is Nothing Then
                                'Remove old value before add new value to hash table and auth's string
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hReportFilter(v_strPRID)
                                hReportFilter.Remove(v_strPRID)
                                mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            End If
                        End If
                    End If
                    v_ChildNode = v_ParentsNode
                Next

            End If
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
        DoCheckedChangedMenuGroup(ckbAPPROVE, stvFuncMenu.SelectedItem)
        'Checkbox_CheckedChanged(ckbAPPROVE, stvFuncMenu.SelectedItem)
    End Sub


    ''------------------------------------------------------------------''
    ''-- Thay đổi các giá trị khi thay đổi trạng thái của các control --''
    ''------------------------------------------------------------------''
    Private Sub ShowTransAccessRight(ByVal sender As Object, ByVal pv_treeNode As Node)
        Try
            If pv_treeNode.Items.Count > 0 Then
                DoControlChange(sender, pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        ShowTransAccessRight(sender, v_node)
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


    Private Sub ShowTransAccessRightGroup(ByVal pv_txtBox As TextBox, ByRef pv_node As Node)
        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        If pv_node.Items.Count > 0 Then
            For i As Integer = 0 To pv_node.Items.Count - 1
                If pv_node.Items(i).Items.Count > 0 Then
                    ShowTransAccessRightGroup(pv_txtBox, pv_node.Items(i))
                Else
                    v_arrMenuKey = pv_node.Items(i).Key.Split("|")
                    v_strCMDID = v_arrMenuKey(0)
                    v_strLEV = v_arrMenuKey(1)
                    v_strLast = v_arrMenuKey(2)
                    v_strMenuType = v_arrMenuKey(3)
                    v_strSubMenuType = v_arrMenuKey(4)
                    If v_strMenuType = "T" Or (v_strMenuType = "M" And v_strSubMenuType = "T") Then
                        ShowTransAccessRight(pv_txtBox, pv_node.Items(i))
                    End If
                End If
            Next
        Else
            v_arrMenuKey = pv_node.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)
            If v_strMenuType = "T" Or (v_strMenuType = "M" And v_strSubMenuType = "T") Then
                ShowTransAccessRight(pv_txtBox, pv_node)
            End If
        End If
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
                    If VerifyDataType() = False Then
                        Exit Sub
                    End If

                    'EnableAccessRight(pv_treeNode)
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
                    MessageBox.Show(mv_ResourceManager.GetString("TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    'MsgBox(mv_ResourceManager.GetString("TellerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtTELLERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtTELLERLIMIT.Text) < 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox(mv_ResourceManager.GetString("TransMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtTELLERLIMIT.Focus()
                    Return False
                End If
            End If

            'Check Officer limit
            If txtOFFICERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtOFFICERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtOFFICERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtOFFICERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtOFFICERLIMIT.Focus()
                    Return False

                End If
            End If

            'Check Cashier limit
            If txtCASHIERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtCASHIERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtCASHIERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtCASHIERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtCASHIERLIMIT.Focus()
                    Return False
                End If
            End If

            'Check Checker limit
            If txtCHECKERLIMIT.Text <> String.Empty Then
                If Not IsNumeric(txtCHECKERLIMIT.Text) Then
                    MsgBox(mv_ResourceManager.GetString("CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtCHECKERLIMIT.Focus()
                    Return False
                ElseIf CDbl(txtCHECKERLIMIT.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
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
    ''-- + Mục đích: Cập nhật giá trị khóa của node của menu tree --''
    ''-- + ?�ầu vào: pv_treeNode: node của menu tree vừa click     --''
    ''-- + ?�ầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub ResetMenuKey(ByVal pv_treeNode As Node)

        Dim v_arrMenuKey(), v_arrID(), v_strTLTXCD, v_strCMDALLOW, v_strLEV, v_strMenuType, v_strMenuKey As String
        Dim v_strTellerKey, v_strOfficerKey, v_strCashierKey, v_strCheckerKey As String

        Try

            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                If v_arrMenuKey.Length > 1 Then
                    'Select TLTXCD and old CMDALLOW
                    'v_strTLTXCD = Trim(v_arrMenuKey(0))
                    v_strLEV = Trim(v_arrMenuKey(1))
                    v_strMenuType = Trim(v_arrMenuKey(3))
                    If v_strMenuType = "T" Then
                        v_strTLTXCD = Trim(v_arrMenuKey(0))
                    ElseIf v_strMenuType = "G" Then
                        v_arrID = v_arrMenuKey(0).Split("^")
                        v_strTLTXCD = Trim(v_arrID(1))
                    End If
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
                    v_strMenuKey = v_strTLTXCD & "|" & v_strLEV & "|" & v_strCMDALLOW & "|" & "T"
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
                        SetParentNodeKey(pv_treeNode, v_strCMDALLOW)
                    End If

                End If
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    ''------------------------------------------''
    ''-- Hiển thị các quyền đã có cua chuc nang --''
    ''------------------------------------------''
    Private Sub ShowFuncAccessRight(ByVal pv_treeNode As Node)
        Dim v_strMenuType, v_strModCode, v_strObjName, v_arrMenuKey() As String
        Dim v_strAccess, v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove, v_strAUTHCODE As String
        Dim v_strAuth, v_strCMDID, v_strLast, v_strLEV, v_strSubMenuType, v_arrAuth() As String

        Try

            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                v_strCMDID = v_arrMenuKey(0)
                v_strLEV = v_arrMenuKey(1)
                If CInt(v_strLEV) > 1 Then
                    v_strLast = v_arrMenuKey(2)
                    v_strMenuType = v_arrMenuKey(3)
                    v_strSubMenuType = v_arrMenuKey(4)
                    v_strAUTHCODE = v_arrMenuKey(5)
                End If

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
                    v_strApprove = Mid(v_strAuth, 6, 1)

                    'Display Access right
                    ckbACCESS.Checked = (v_strAccess = "Y")
                    If ckbACCESS.Checked = False Then
                        txtGNRTELLERLM.Text = String.Empty
                        txtGNRCASHIERLM.Text = String.Empty
                        txtGNROFFICERLM.Text = String.Empty
                        txtGNRCHECKERLM.Text = String.Empty
                        ckbGNRACC.Checked = False
                    End If

                    ckbINQUIRY.Checked = (v_strInquiry = "Y")
                    ckbADD.Checked = (v_strAdd = "Y")
                    ckbEDIT.Checked = (v_strEdit = "Y")
                    ckbDELETE.Checked = (v_strDelete = "Y")
                    ckbAPPROVE.Checked = (v_strApprove = "Y")
                End If

                'Voi cac man hinh dac biet chi can hien quyen truy nhap
                If v_strMenuType = "M" And v_strSubMenuType = "A" Then
                    ckbINQUIRY.Enabled = False
                    ckbADD.Enabled = False
                    ckbEDIT.Enabled = False
                    ckbDELETE.Enabled = False
                    ckbAPPROVE.Enabled = False
                ElseIf v_strMenuType = "M" And InStr("P/M/O", v_strSubMenuType) > 0 Then
                    'Hien thi theo menu
                    'ckbINQUIRY.Enabled = True
                    'ckbADD.Enabled = True
                    'ckbEDIT.Enabled = True
                    'ckbDELETE.Enabled = True
                    'ckbAPPROVE.Enabled = True
                    ckbINQUIRY.Enabled = (Mid(v_strAUTHCODE, 2, 1) = "Y")
                    ckbADD.Enabled = (Mid(v_strAUTHCODE, 1, 1) = "Y")
                    ckbEDIT.Enabled = (Mid(v_strAUTHCODE, 3, 1) = "Y")
                    ckbDELETE.Enabled = (Mid(v_strAUTHCODE, 4, 1) = "Y")
                    ckbAPPROVE.Enabled = (Mid(v_strAUTHCODE, 11, 1) = "Y")
                End If

                'Allow assign in edit mode only
                If (ExeFlag = ExecuteFlag.View) Then
                    DisallowChange()
                End If
            Else

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''------------------------------------------''
    ''-- Hiển thị các quyền đã có cua bao cao --''
    ''------------------------------------------''
    Private Sub ShowRptAccessRight(ByVal pv_treeNode As Node)
        Dim v_strMenuType, v_strModCode, v_strObjName, v_arrMenuKey() As String
        Dim v_strView, v_strPrint, v_strAdd, v_strArea As String
        Dim v_strAuth, v_strCMDID, v_strCMDTYPE, v_arrAuth() As String

        Try

            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                v_strCMDID = v_arrMenuKey(0)
                v_strCMDTYPE = v_arrMenuKey(3)

                If Not hReportFilter(v_strCMDID) Is Nothing Then
                    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                    v_strAuth = v_arrAuth(2)
                Else
                    v_strAuth = "NNNA"
                End If

                'Select Auth string
                'v_strAuth = v_arrMenuKey(1)
                If v_strAuth <> Nothing And v_strCMDTYPE = "R" Then
                    v_strView = Mid(v_strAuth, 1, 1)
                    v_strPrint = Mid(v_strAuth, 2, 1)
                    v_strAdd = Mid(v_strAuth, 3, 1)
                    v_strArea = Mid(v_strAuth, 4, 1)

                    'If (Trim(v_strCMDTYPE) = "R") Or (Trim(v_strCMDTYPE) = "P") Then
                    'ckbRPTVIEW.Enabled = True
                    'ckbRPTPRINT.Enabled = True
                    ckbRPTADD.Enabled = True
                    'Display Access right
                    ckbRPTVIEW.Checked = (v_strView = "Y")
                    ckbRPTPRINT.Checked = (v_strPrint = "Y")
                    ckbRPTADD.Checked = (v_strAdd = "Y")
                    cboRPTAREA.SelectedValue = v_strArea
                    'cboRPTAREA.SelectedIndexChanged()
                End If

                'Allow assign in Edit mode only
                If (ExeFlag = ExecuteFlag.View) Then
                    DisallowChange()
                End If
                'Else
                '    DisableAssignment()
                'End If
            Else

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------------------------------''
    ''-- Thay đổi các giá trị khi thay đổi trạng thái của checkbox --''
    ''---------------------------------------------------------------''
    Private Sub RptCheckbox_CheckedChanged(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)
            If v_strMenuType = "R" Or (v_strMenuType = "M" And v_strSubMenuType = "R") Then

                If pv_treeNode.Items.Count > 0 Then
                    DoRptCheckboxChange(sender, pv_treeNode)
                    Dim v_node As Node
                    For Each v_node In pv_treeNode.Items
                        If v_node.Items.Count > 0 Then
                            RptCheckbox_CheckedChanged(sender, v_node)
                        Else
                            DoRptCheckboxChange(sender, v_node)
                        End If
                    Next
                Else
                    DoRptCheckboxChange(sender, pv_treeNode)
                End If
            End If

        Catch ex As Exception
            Throw ex

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
    Private Sub DoRptCheckboxChange(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_node As Node
        Dim v_strView, v_strPrint, v_strAdd As String
        Dim v_strArea As String = "A" 'Mac dinh pham vi la toan cty
        Dim v_strCMDID, v_strMenuType, v_arrMenuKey(), v_strAuth, v_strLEV, v_arrAuth(), v_strHashValue, v_strCMDALLOW As String

        Try

            'Get Auth string and CMDID
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strMenuType = v_arrMenuKey(3)
            If Not hReportFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                v_strAuth = v_arrAuth(2)
            Else
                v_strAuth = "NNNA"
            End If

            If v_strAuth <> String.Empty Then
                'If ckbVIEW's value has changed
                If (sender Is ckbRPTVIEW) Then
                    If ckbRPTVIEW.Checked Then
                        v_strView = "Y"
                        v_strAuth = v_strView & Mid(v_strAuth, 2, 3)
                    Else
                        v_strView = "N"
                        ckbRPTPRINT.Checked = False
                        ckbRPTADD.Checked = False
                        v_strPrint = "N"
                        v_strAdd = "N"

                        v_strAuth = v_strView & v_strPrint & v_strAdd & Mid(v_strAuth, 4, 1)
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                    'Update new value to hash table
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hReportFilter(v_strCMDID)
                        hReportFilter.Remove(v_strCMDID)
                        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                        hReportFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hReportFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If

                    'If ckbPRINT's value has changed
                ElseIf (sender Is ckbRPTPRINT) Then
                    If (v_strMenuType = "R") Or (v_strMenuType = "P") Then
                        If ckbRPTPRINT.Checked Then
                            v_strPrint = "Y"
                            If ckbRPTVIEW.Checked = False Then
                                ckbRPTVIEW.Checked = True
                            End If
                            v_strView = "Y"
                            v_strAuth = v_strView & v_strPrint & Mid(v_strAuth, 3, 2)
                        Else
                            v_strPrint = "N"
                            ckbRPTADD.Checked = False
                            v_strAdd = "N"
                            v_strAuth = Mid(v_strAuth, 1, 1) & v_strPrint & v_strAdd & Mid(v_strAuth, 4, 1)
                        End If
                        v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                        'Update new value to hash table
                        If Not hReportFilter(v_strCMDID) Is Nothing Then
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strCMDID)
                            hReportFilter.Remove(v_strCMDID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        End If
                    End If

                    'If ckbADD's value has changed
                ElseIf (sender Is ckbRPTADD) Then
                    If (v_strMenuType = "R") Or (v_strMenuType = "P") Or (v_strMenuType = "M") Then
                        If ckbRPTADD.Checked Then
                            'v_strEdit = "Y"
                            If ckbRPTVIEW.Checked = False Then
                                ckbRPTVIEW.Checked = True
                            End If
                            v_strView = "Y"
                            If ckbRPTPRINT.Checked = False Then
                                ckbRPTPRINT.Checked = True
                            End If
                            v_strPrint = "Y"
                            v_strAuth = v_strView & v_strPrint & "Y" & Mid(v_strAuth, 4, 1)
                        Else
                            'v_strEdit = "N"
                            'v_strAuth = Mid(v_strAuth, 1, 3)
                            ckbRPTVIEW.Checked = False
                            ckbRPTPRINT.Checked = False
                            v_strAuth = "NNN" & Mid(v_strAuth, 4, 1)
                        End If
                        v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                        'Update new value to hash table
                        If Not hReportFilter(v_strCMDID) Is Nothing Then
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strCMDID)
                            hReportFilter.Remove(v_strCMDID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        End If
                    End If
                ElseIf (sender Is cboRPTAREA) Then
                    If Not cboRPTAREA.SelectedValue Is Nothing Then
                        If (v_strMenuType = "R") Or (v_strMenuType = "P") Or (v_strMenuType = "M") Then
                            v_strAuth = Mid(v_strAuth, 1, 3) & cboRPTAREA.SelectedValue
                            v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                            'Update new value to hash table
                            If Not hReportFilter(v_strCMDID) Is Nothing Then
                                'Remove old value before add new value to hash table and auth's string
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hReportFilter(v_strCMDID)
                                hReportFilter.Remove(v_strCMDID)
                                mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                                hReportFilter.Add(v_strCMDID, v_strHashValue)
                                mv_strReportAuth &= v_strHashValue & "#"
                            Else
                                'Add new value to hash table and auth's string
                                hReportFilter.Add(v_strCMDID, v_strHashValue)
                                mv_strReportAuth &= v_strHashValue & "#"
                            End If
                        End If
                    End If
                End If

                'Set image icon to current node - modified by TungNT
                'Dim v_intImgindex As Integer
                'Dim v_arrHashKey() As String
                'Dim v_strCMDALLOW As String
                'If v_strLEV > 3 Then 'Child node
                '    If Not hReportFilter(v_strCMDID) Is Nothing Then
                '        v_arrHashKey = CStr(hReportFilter(v_strCMDID)).Split("|")
                '        v_strCMDALLOW = Trim(v_arrHashKey(2))
                '        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                '        If v_strCMDALLOW = "Y" Then
                '            v_intImgindex = 5
                '        Else
                '            v_intImgindex = 3
                '        End If
                '    Else
                '        v_intImgindex = 3
                '    End If
                '    Dim pv_parentNode As Node = pv_treeNode.ParentItem
                '    If Not pv_parentNode Is Nothing Then
                '        If v_intImgindex = 5 Then
                '            pv_parentNode.ImageIndex = 4
                '        Else
                '            Dim i, count As Integer
                '            count = 0
                '            For Each objNode As Node In pv_parentNode.Items
                '                If objNode.ImageIndex = 5 Then
                '                    count = count + 1
                '                End If
                '            Next
                '            If count > 0 Then
                '                pv_parentNode.ImageIndex = 4
                '            Else
                '                pv_parentNode.ImageIndex = 0
                '            End If

                '        End If
                '    End If
                'Else 'Parent node
                '    If Not hReportFilter(v_strCMDID) Is Nothing Then
                '        v_arrHashKey = CStr(hReportFilter(v_strCMDID)).Split("|")
                '        v_strCMDALLOW = Trim(v_arrHashKey(2))
                '        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                '        If v_strCMDALLOW = "Y" Then
                '            v_intImgindex = 4
                '        Else
                '            v_intImgindex = 0
                '        End If
                '    Else
                '        v_intImgindex = 0
                '    End If
                'End If
                'pv_treeNode.ImageIndex = v_intImgindex
                'End

                'Set key for parent node
                If (CInt(v_strLEV) > 1) Then
                    'SetRptParentNodeKey(pv_treeNode)
                    If ckbRPTVIEW.Checked Then
                        v_strCMDALLOW = "Y"
                    Else
                        v_strCMDALLOW = "N"
                    End If
                    SetParentNodeKey(pv_treeNode, v_strCMDALLOW)
                End If
                ChangeImageIndex(pv_treeNode)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Set lại key của các node cha của 1 node      --''
    ''-- + Đầu vào: pv_treeNode: node có các node cha cần set key --''
    ''-- + Đầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub SetRptParentNodeKey(ByVal pv_treeNode As Node)
        Dim v_strPRID, v_strLEV, v_strCMDID, v_strAUTH, v_strHashValue, v_arrMenuKey() As String
        Dim v_strCMDALLOW, v_strPRCMDALLOW, v_strPRLEV, v_strMODCODE, v_strMenuType, v_arrAuth(), v_arrPrAuth(), v_arrChild() As String
        Dim v_intPRLEV, v_intChildNum As Integer

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            If Not hReportFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                v_strCMDALLOW = Mid(CStr(v_arrAuth(2)), 1, 1)

                If v_strCMDALLOW = "Y" Then
                    For i As Integer = 0 To CInt(v_strLEV) - 2
                        v_strPRID = hParentsFilter(v_strCMDID)
                        'v_strPRID = hCmdIdFilter(v_strMODCODE)
                        v_intPRLEV = CInt(v_strLEV) - (i + 1)
                        v_strPRLEV = CStr(v_intPRLEV)

                        If Not hReportFilter(v_strPRID) Is Nothing Then
                            v_arrAuth = CStr(hReportFilter(v_strPRID)).Split("|")
                            v_strAUTH = v_arrAuth(2)
                            v_strMenuType = v_arrAuth(3)
                            v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                            If v_strCMDALLOW = "N" Then
                                v_strCMDALLOW = "Y"
                            End If
                            v_strAUTH = v_strCMDALLOW & Mid(v_strAUTH, 2)
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strPRID)
                            hReportFilter.Remove(v_strPRID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strPRID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            If CInt(v_strPRLEV) = 3 Then
                                v_strAUTH = "YNN"
                            Else
                                v_strAUTH = "YNNNN"
                            End If
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strPRID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
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
                        'v_strPRID = hCmdIdFilter(v_strMODCODE)
                        v_intPRLEV = CInt(v_strLEV) - (i + 1)
                        v_strPRLEV = CStr(v_intPRLEV)

                        If Not hChildrenFilter(v_strPRID) Is Nothing Then
                            If (CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Then
                                'Tinh lai so node con
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
                                'Lay len so node con
                                v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                                v_strMenuType = CStr(v_arrChild(2))
                                v_intChildNum = CInt(CStr(v_arrChild(3)))
                            End If
                        Else
                            v_intChildNum = 0
                        End If

                        If Not hReportFilter(v_strPRID) Is Nothing Then
                            If (v_intChildNum = 0 And CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Or (v_intChildNum = 1 And CInt(v_strPRLEV) < CInt(v_strLEV) - 1) Then
                                v_arrAuth = CStr(hReportFilter(v_strPRID)).Split("|")
                                v_strAUTH = v_arrAuth(2)
                                v_strMenuType = v_arrAuth(3)
                                If Len(Trim(v_strAUTH)) = 1 Then
                                    v_strAUTH = "N"
                                ElseIf Len(Trim(v_strAUTH)) > 1 Then
                                    If CInt(v_strPRLEV) = 3 Then
                                        v_strAUTH = "NNN"
                                    Else
                                        v_strAUTH = "NNNNN"
                                    End If
                                End If
                                v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                                'Remove old value before add new value to hash table and auth's string
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hReportFilter(v_strPRID)
                                hReportFilter.Remove(v_strPRID)
                                mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                                hReportFilter.Add(v_strPRID, v_strHashValue)
                                mv_strReportAuth &= v_strHashValue & "#"

                                'Set Image
                                Dim v_ParentNode As Node = pv_treeNode.ParentItem
                                v_ParentNode.ImageIndex = 0
                            Else
                                Exit For
                            End If

                        Else
                            'v_strAUTH = "YNNNN"
                            'v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                            ''Add new value to hash table and auth's string
                            'hReportFilter.Add(v_strPRID, v_strHashValue)
                            'mv_strReportAuth &= v_strHashValue & "#"
                        End If

                        v_strCMDID = v_strPRID
                    Next

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ShowGnrAccessRight(ByVal sender As Object, ByVal pv_treeNode As Node)
        Try
            Dim v_strCMDID, v_arrMenuKey(), v_arrID(), v_strCMDALLOW, v_arrAuth() As String
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            If InStr(v_arrMenuKey(0), "^") > 0 Then
                v_arrID = v_arrMenuKey(0).Split("^")
                v_strCMDID = v_arrID(0)
            Else
                v_strCMDID = Trim(v_arrMenuKey(0))
            End If
            If pv_treeNode.Items.Count > 0 Then
                If Not hFunctionFilter(v_strCMDID) Is Nothing Then
                    v_arrAuth = CStr(hFunctionFilter(v_strCMDID)).Split("|")
                    v_strCMDALLOW = Mid(v_arrAuth(2), 1, 1)
                Else
                    v_strCMDALLOW = "N"
                End If
            Else
                If Not hReportFilter(v_strCMDID) Is Nothing Then
                    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                    v_strCMDALLOW = v_arrAuth(2)
                Else
                    v_strCMDALLOW = "N"
                End If
            End If
            ckbGNRACC.Checked = (v_strCMDALLOW = "Y")

            If pv_treeNode.Items.Count > 0 Then
                DoGnrControlChange(sender, pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        ShowGnrAccessRight(sender, v_node)
                    Else
                        DoGnrControlChange(sender, v_node)
                    End If
                Next

                'Enable cac control cho phan quyen, ko show han muc cua tung GD
                'txtGNRTELLERLM.Enabled = True
                'txtGNROFFICERLM.Enabled = True
                'txtGNRCASHIERLM.Enabled = False
                'txtGNRCHECKERLM.Enabled = True
            Else
                DoGnrControlChange(sender, pv_treeNode)
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''-----------------------------------------------------------''
    ''-- + Mục đích: Cập nhật các giá trị phân quyền cần thiết --''
    ''--   khi giá trị của 1 control nào đó thay đổi           --''
    ''-- + Đầu vào: - sender: Control có giá trị thay đổi      --''
    ''--            - pv_treeNode: Node hiện tại của menu tree --''
    ''-- + Đầu ra: N/A                                         --''
    ''-- + Tác giả: Nguyễn Nhân Thế                            --''
    ''-- + Ghi chú: N/A                                        --''
    ''-----------------------------------------------------------''
    Private Sub DoGnrControlChange(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_arrMenuKey() As String
        Dim v_strTLTXCD, v_strCMDALLOW, v_strCURRCOD, v_strLIMIT, v_strLEV As String
        Dim v_strHashKey, v_strHashValue, v_arrAuth(), v_arrID() As String
        Dim v_strRPTID As String

        Try
            If Not pv_treeNode Is Nothing Then
                If pv_treeNode.Key <> String.Empty Then

                    'EnableAccessRight(pv_treeNode)
                    v_arrMenuKey = pv_treeNode.Key.Split("|")
                    If InStr(v_arrMenuKey(0), "^") > 0 Then
                        v_arrID = v_arrMenuKey(0).Split("^")
                        v_strRPTID = v_arrID(0)
                        v_strTLTXCD = v_arrID(1)
                    Else
                        v_strTLTXCD = Trim(v_arrMenuKey(0))
                    End If
                    'PhuongHT add: bo cac tltxcd khong pai jao dich
                    If v_strTLTXCD.Length > 4 Then
                        Exit Sub
                    End If
                    'If Not hReportFilter(v_strRPTID) Is Nothing Then
                    '    v_arrAuth = CStr(hReportFilter(v_strRPTID)).Split("|")
                    '    v_strCMDALLOW = v_arrAuth(2)
                    'Else
                    '    v_strCMDALLOW = "N"
                    'End If
                    'ckbGNRACC.Checked = (v_strCMDALLOW = "Y")

                    v_strLEV = v_arrMenuKey(1)
                    'If Not hTransFilter(v_strTLTXCD) Is Nothing Then
                    '    v_arrAuth = CStr(hTransFilter(v_strTLTXCD)).Split("|")
                    '    v_strCMDALLOW = v_arrAuth(2)
                    'Else
                    '    v_strCMDALLOW = "N"
                    'End If
                    'If (sender Is ckbGNRACC) Then
                    '    If ckbGNRACC.Checked Then
                    '        v_strCMDALLOW = "Y"
                    '    Else
                    '        v_strCMDALLOW = "N"
                    '    End If

                    '    v_strHashValue = v_strRPTID & "|" & v_strLEV & "|" & v_strCMDALLOW & "|" & "G"
                    '    'Update new value to hash table
                    '    If Not hReportFilter(v_strRPTID) Is Nothing Then
                    '        'Remove old value before add new value to hash table and auth's string
                    '        Dim v_strOldHashValue As String
                    '        v_strOldHashValue = hReportFilter(v_strRPTID)
                    '        hReportFilter.Remove(v_strRPTID)
                    '        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                    '        hReportFilter.Add(v_strRPTID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    Else
                    '        'Add new value to hash table and auth's string
                    '        hReportFilter.Add(v_strRPTID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    End If
                    'End If

                    If v_strTLTXCD <> "EXEC" And v_strTLTXCD <> "VIEW" Then
                        'If CURRCOD combobox's value has changed 
                        If (sender Is cboGNRCURR) Then
                            v_strCURRCOD = Trim(CStr(cboGNRCURR.SelectedValue))
                            v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|"
                            Dim v_arrLimit() As String
                            'Display access right of TELLER
                            If hTlauthFilter(v_strHashKey & "T") Is Nothing Then
                                txtGNRTELLERLM.Clear()
                            Else
                                txtGNRTELLERLM.Enabled = True
                                v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "T")).Split("|")
                                txtGNRTELLERLM.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboGNRCURR.SelectedValue))

                            End If
                            'Display access right of OFFICER
                            If hTlauthFilter(v_strHashKey & "A") Is Nothing Then
                                txtGNROFFICERLM.Clear()
                            Else
                                txtGNROFFICERLM.Enabled = True
                                v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "A")).Split("|")
                                txtGNROFFICERLM.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboGNRCURR.SelectedValue))
                            End If
                            'Display access right of CASHIER
                            If hTlauthFilter(v_strHashKey & "C") Is Nothing Then
                                txtGNRCASHIERLM.Clear()
                            Else
                                txtGNRCASHIERLM.Enabled = True
                                v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "C")).Split("|")
                                txtGNRCASHIERLM.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboGNRCURR.SelectedValue))
                            End If
                            'Display access right of CHECKER
                            If hTlauthFilter(v_strHashKey & "R") Is Nothing Then
                                txtGNRCHECKERLM.Clear()
                            Else
                                txtGNRCHECKERLM.Enabled = True
                                v_arrLimit = CStr(hTlauthFilter(v_strHashKey & "R")).Split("|")
                                txtGNRCHECKERLM.Text = FormatNumber(Trim(v_arrLimit(3)), hCurrDecFilter(cboGNRCURR.SelectedValue))
                            End If

                            'If TELLERLIMIT textbox's value has changed
                        ElseIf (sender Is txtGNRTELLERLM) Then
                            v_strCURRCOD = Trim(CStr(cboGNRCURR.SelectedValue))
                            v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "T"
                            If IsNumeric(txtGNRTELLERLM.Text) Then
                                If CDbl(txtGNRTELLERLM.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                    txtGNRTELLERLM.Text = FormatNumber(txtGNRTELLERLM.Text, hCurrDecFilter(cboGNRCURR.SelectedValue))
                                    If CDbl(txtGNRTELLERLM.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then

                                        'Update new values of transaction limit
                                        v_strLIMIT = Replace(CStr(txtGNRTELLERLM.Text), ",", "").Trim()
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

                            ElseIf txtGNRTELLERLM.Text = String.Empty Then
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                End If
                            End If

                            'If OFFICERLIMIT textbox's value has changed
                        ElseIf (sender Is txtGNROFFICERLM) Then
                            v_strCURRCOD = Trim(CStr(cboGNRCURR.SelectedValue))
                            v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "A"
                            If IsNumeric(txtGNROFFICERLM.Text) Then
                                txtGNROFFICERLM.Text = FormatNumber(txtGNROFFICERLM.Text, hCurrDecFilter(cboGNRCURR.SelectedValue))
                                If CDbl(txtGNROFFICERLM.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                    v_strLIMIT = Replace(CStr(txtGNROFFICERLM.Text), ",", "").Trim()
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
                            ElseIf txtGNROFFICERLM.Text = String.Empty Then
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                End If
                            End If

                            'If CASHIERLIMIT textbox's value has changed
                        ElseIf (sender Is txtGNRCASHIERLM) Then
                            v_strCURRCOD = Trim(CStr(cboGNRCURR.SelectedValue))
                            v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "C"
                            If IsNumeric(txtGNRCASHIERLM.Text) Then
                                txtGNRCASHIERLM.Text = FormatNumber(txtGNRCASHIERLM.Text, hCurrDecFilter(cboGNRCURR.SelectedValue))
                                If CDbl(txtGNRCASHIERLM.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                    v_strLIMIT = Replace(CStr(txtGNRCASHIERLM.Text), ",", "").Trim()
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
                            ElseIf txtGNRCASHIERLM.Text = String.Empty Then
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                End If
                            End If

                            'If CHECKERLIMIT textbox's value has changed
                        ElseIf (sender Is txtGNRCHECKERLM) Then
                            v_strCURRCOD = Trim(CStr(cboGNRCURR.SelectedValue))
                            v_strHashKey = v_strTLTXCD & "|" & v_strCURRCOD & "|" & "R"
                            If IsNumeric(txtGNRCHECKERLM.Text) Then
                                txtGNRCHECKERLM.Text = FormatNumber(txtGNRCHECKERLM.Text, hCurrDecFilter(cboGNRCURR.SelectedValue))
                                If CDbl(txtGNRCHECKERLM.Text) + IIf(Strings.Right(UserRight, 1) = "Y", 1, 0) + IIf(Strings.Right(GroupRight, 1) = "Y", 1, 0) > 0 Then
                                    v_strLIMIT = Replace(CStr(txtGNRCHECKERLM.Text), ",", "").Trim()
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
                            ElseIf txtGNRCHECKERLM.Text = String.Empty Then
                                If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                                    'Remove old value
                                    Dim v_strOldHashValue As String
                                    v_strOldHashValue = hTlauthFilter(v_strHashKey)
                                    hTlauthFilter.Remove(v_strHashKey)
                                    mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                                End If
                            End If
                        Else

                        End If
                    End If


                    'Begin GianhVG add
                    'Change image index
                    ResetMenuKey(pv_treeNode)
                    'ChangeImageIndex(pv_treeNode)
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

    ''----------------------------------------------------------------''
    ''-- + Mục đích: Kiểm tra kiểu dữ liệu nhập vào của các hạn mức --''
    ''-- + Đầu vào: N/A                                             --''
    ''-- + Đầu ra: True nếu là kiểu số, False nếu là kiểu khác      --''
    ''-- + Tác giả: Nguyễn Nhân Thế                                 --''
    ''-- + Ghi chú: N/A                                             --''
    ''----------------------------------------------------------------''
    Private Function VerifyGnrDataType() As Boolean
        Try
            'Check Teller limit
            If txtGNRTELLERLM.Text <> String.Empty Then
                If Not IsNumeric(txtGNRTELLERLM.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    'MsgBox(mv_ResourceManager.GetString("TellerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtGNRTELLERLM.Focus()
                    Return False
                ElseIf CDbl(txtGNRTELLERLM.Text) < 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("TellerMsg"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox(mv_ResourceManager.GetString("TransMsg"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    txtGNRTELLERLM.Focus()
                    Return False
                End If
            End If

            'Check Officer limit
            If txtGNROFFICERLM.Text <> String.Empty Then
                If Not IsNumeric(txtGNROFFICERLM.Text) Then
                    MsgBox(mv_ResourceManager.GetString("OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNROFFICERLM.Focus()
                    Return False
                ElseIf CDbl(txtGNROFFICERLM.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("OfficerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNROFFICERLM.Focus()
                    Return False
                End If
            End If

            'Check Cashier limit
            If txtGNRCASHIERLM.Text <> String.Empty Then
                If Not IsNumeric(txtGNRCASHIERLM.Text) Then
                    MsgBox(mv_ResourceManager.GetString("CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNRCASHIERLM.Focus()
                    Return False
                ElseIf CDbl(txtGNRCASHIERLM.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("CashierMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNRCASHIERLM.Focus()
                    Return False
                End If
            End If

            'Check Checker limit
            If txtGNRCHECKERLM.Text <> String.Empty Then
                If Not IsNumeric(txtGNRCHECKERLM.Text) Then
                    MsgBox(mv_ResourceManager.GetString("CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNRCHECKERLM.Focus()
                    Return False
                ElseIf CDbl(txtGNRCHECKERLM.Text) < 0 Then
                    MsgBox(mv_ResourceManager.GetString("CheckerMsg"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtGNRCHECKERLM.Focus()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GnrCheckbox_CheckedChanged(ByVal sender As Object, ByVal pv_treeNode As Node)

        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)
            If v_strMenuType = "G" Or (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                If pv_treeNode.Items.Count > 0 Then
                    DoGnrCheckboxChange(sender, pv_treeNode)
                    Dim v_node As Node
                    For Each v_node In pv_treeNode.Items
                        If v_node.Items.Count > 0 Then
                            GnrCheckbox_CheckedChanged(sender, v_node)
                        Else
                            DoGnrCheckboxChange(sender, v_node)
                        End If
                    Next
                Else
                    DoGnrCheckboxChange(sender, pv_treeNode)
                End If
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub DoGnrCheckboxChange(ByVal sender As Object, ByVal pv_treeNode As Node)

        Try
            Dim v_strRPTID, v_arrMenuKey(), v_arrID(), v_strCMDALLOW, v_arrAuth(), v_strHashValue, v_strLEV, v_strTLTXCD, v_strMenuType As String
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            If InStr(v_arrMenuKey(0), "^") > 0 Then
                v_arrID = v_arrMenuKey(0).Split("^")
                v_strRPTID = v_arrID(0)
                v_strTLTXCD = v_arrID(1)
            Else
                v_strRPTID = Trim(v_arrMenuKey(0))
                v_strTLTXCD = String.Empty
            End If
            v_strLEV = v_arrMenuKey(1)
            v_strMenuType = v_arrMenuKey(3)
            'If Not hReportFilter(v_strCMDID) Is Nothing Then
            '    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
            '    v_strCMDALLOW = v_arrAuth(2)
            'Else
            '    v_strCMDALLOW = "N"
            'End If
            'ckbGNRACC.Checked = (v_strCMDALLOW = "Y")

            If (sender Is ckbGNRACC) Then
                If ckbGNRACC.Checked Then
                    v_strCMDALLOW = "Y"
                Else
                    v_strCMDALLOW = "N"
                End If
                If v_strMenuType = "G" Then
                    v_strHashValue = v_strRPTID & "|" & v_strLEV & "|" & v_strCMDALLOW & "|" & "G"
                    'Update new value to hash table
                    If Not hReportFilter(v_strRPTID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hReportFilter(v_strRPTID)
                        hReportFilter.Remove(v_strRPTID)
                        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                        hReportFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hReportFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If
                Else
                    v_strHashValue = v_strRPTID & "|" & v_strLEV & "|" & v_strCMDALLOW
                    'Update new value to hash table
                    If Not hFunctionFilter(v_strRPTID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hFunctionFilter(v_strRPTID)
                        hFunctionFilter.Remove(v_strRPTID)
                        mv_strFuncAuth = Replace(mv_strFuncAuth, v_strOldHashValue & "#", "").Trim
                        hFunctionFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hFunctionFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strFuncAuth &= v_strHashValue & "#"
                    End If
                End If

                'Xoa het phan quyen giao dich neu checked = false
                If v_strCMDALLOW = "N" Then
                    Dim v_strHashKey As String
                    'Transaction limit
                    v_strHashKey = v_strTLTXCD & "|" & Trim(CStr(cboGNRCURR.SelectedValue)) & "|T"
                    'Update new value to hash table
                    If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hTlauthFilter(v_strHashKey)
                        hTlauthFilter.Remove(v_strHashKey)
                        mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                    End If

                    'Officer
                    v_strHashKey = v_strTLTXCD & "|" & Trim(CStr(cboGNRCURR.SelectedValue)) & "|A"
                    'Update new value to hash table
                    If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hTlauthFilter(v_strHashKey)
                        hTlauthFilter.Remove(v_strHashKey)
                        mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                    End If

                    'Cashier
                    v_strHashKey = v_strTLTXCD & "|" & Trim(CStr(cboGNRCURR.SelectedValue)) & "|C"
                    'Update new value to hash table
                    If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hTlauthFilter(v_strHashKey)
                        hTlauthFilter.Remove(v_strHashKey)
                        mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                    End If

                    'Checker
                    v_strHashKey = v_strTLTXCD & "|" & Trim(CStr(cboGNRCURR.SelectedValue)) & "|R"
                    'Update new value to hash table
                    If Not hTlauthFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hTlauthFilter(v_strHashKey)
                        hTlauthFilter.Remove(v_strHashKey)
                        mv_strTlauthString = Replace(mv_strTlauthString, v_strOldHashValue & "#", "").Trim()
                    End If
                End If
                'If ckbGNRACC.Checked Then
                SetParentNodeKey(pv_treeNode, v_strCMDALLOW)
                'End If
                ChangeImageIndex(pv_treeNode)
            End If
        Catch ex As Exception
            Throw ex

        End Try
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

    Private Sub ChangeImageIndexOnAdjustNode(ByRef pv_normalNode As Node, ByRef pv_adjustNode As Node)
        Try
            For i As Integer = 0 To pv_adjustNode.Items.Count - 1
                If pv_adjustNode.Items(i).Items.Count > 0 Then
                    ChangeImageIndexOnAdjustNode(pv_normalNode, pv_adjustNode.Items(i))
                Else
                    If Not pv_adjustNode.Items(i).Tag Is Nothing AndAlso pv_normalNode.Key = pv_adjustNode.Items(i).Tag Then
                        ChangeImageIndex(pv_normalNode, pv_adjustNode.Items(i))
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ckbACCESS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbACCESS.Click
        Try
            DoCheckedChangedMenuGroup(ckbACCESS, stvFuncMenu.SelectedItem)
        Catch ex As Exception

        End Try
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        Checkbox_CheckedChanged(ckbACCESS, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        Checkbox_CheckedChanged(ckbACCESS, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    Checkbox_CheckedChanged(ckbACCESS, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub DoCheckedChangedMenuGroup(ByVal sender As Object, ByRef pv_node As Node)
        Try
            If (pv_node.ImageIndex <> 3 AndAlso pv_node.ImageIndex <> 5) OrElse pv_node.Tag = "P" Then
                If pv_node.Items.Count > 0 Then
                    For i As Integer = 0 To pv_node.Items.Count - 1
                        If pv_node.Items(i).Items.Count > 0 Then
                            DoCheckedChangedMenuGroup(sender, pv_node.Items(i))
                        Else
                            If Not pv_node.Items(i).Tag Is Nothing Then
                                Try
                                    Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Items(i).Tag, stvFuncMenu.Items(0)), Node)
                                    Checkbox_CheckedChanged(sender, v_node)
                                    'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                                Catch ex As Exception
                                    Checkbox_CheckedChanged(sender, pv_node.Items(i))
                                End Try
                            Else
                                Checkbox_CheckedChanged(sender, pv_node.Items(i))
                            End If
                        End If
                    Next
                End If
            Else
                If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
                    Try
                        Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Tag, stvFuncMenu.Items(0)), Node)
                        Checkbox_CheckedChanged(sender, v_node)
                        'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                    Catch ex As Exception
                        Checkbox_CheckedChanged(sender, pv_node)
                    End Try
                Else
                    Checkbox_CheckedChanged(sender, pv_node)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ckbINQUIRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbINQUIRY.Click
        DoCheckedChangedMenuGroup(ckbINQUIRY, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        Checkbox_CheckedChanged(ckbINQUIRY, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        Checkbox_CheckedChanged(ckbINQUIRY, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    Checkbox_CheckedChanged(ckbINQUIRY, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub ckbADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbADD.Click
        DoCheckedChangedMenuGroup(ckbADD, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        Checkbox_CheckedChanged(ckbADD, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        Checkbox_CheckedChanged(ckbADD, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    Checkbox_CheckedChanged(ckbADD, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub ckbEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbEDIT.Click
        DoCheckedChangedMenuGroup(ckbEDIT, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        Checkbox_CheckedChanged(ckbEDIT, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        Checkbox_CheckedChanged(ckbEDIT, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    Checkbox_CheckedChanged(ckbEDIT, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub ckbDELETE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbDELETE.Click
        DoCheckedChangedMenuGroup(ckbDELETE, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        Checkbox_CheckedChanged(ckbDELETE, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        Checkbox_CheckedChanged(ckbDELETE, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    Checkbox_CheckedChanged(ckbDELETE, stvFuncMenu.SelectedItem)
        'End If
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

    Private Sub txtTELLERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If VerifyDataType() = False Then
            Exit Sub
        End If
        'ShowTransAccessRight(txtTELLERLIMIT, mv_node)
        ShowTransAccessRightGroup(txtTELLERLIMIT, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtOFFICERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOFFICERLIMIT.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If VerifyDataType() = False Then
            Exit Sub
        End If
        'ShowTransAccessRight(txtOFFICERLIMIT, mv_node)
        ShowTransAccessRightGroup(txtOFFICERLIMIT, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtCASHIERLIMIT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASHIERLIMIT.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If VerifyDataType() = False Then
            Exit Sub
        End If
        'ShowTransAccessRight(txtCASHIERLIMIT, mv_node)
        ShowTransAccessRightGroup(txtCASHIERLIMIT, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtCHECKERLIMIT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If VerifyDataType() = False Then
            Exit Sub
        End If
        'ShowTransAccessRight(txtCHECKERLIMIT, mv_node)
        ShowTransAccessRightGroup(txtCHECKERLIMIT, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtTELLERLIMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.Click
        mv_textbox = txtTELLERLIMIT
    End Sub

    Private Sub txtTELLERLIMIT_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.GotFocus
        mv_textbox = txtTELLERLIMIT
        mv_currnodeIdx = Me.stvFuncMenu.SelectedItem.Index
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
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub txtCHECKERLIMIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.Click
        mv_textbox = txtCHECKERLIMIT
    End Sub

    Private Sub txtCHECKERLIMIT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECKERLIMIT.GotFocus
        mv_textbox = txtCHECKERLIMIT
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub cboCURRCOD_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCURRCOD.SelectedValueChanged
        ShowTransAccessRight(cboCURRCOD, stvFuncMenu.SelectedItem)
    End Sub

    Private Sub ckbRPTADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRPTADD.Click
        Me.ckbRPTPRINT.Checked = Me.ckbRPTADD.Checked
        Me.ckbRPTVIEW.Checked = Me.ckbRPTADD.Checked
        DoRptCheckedChangedMenuGroup(ckbRPTADD, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        RptCheckbox_CheckedChanged(ckbRPTADD, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        RptCheckbox_CheckedChanged(ckbRPTADD, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    RptCheckbox_CheckedChanged(ckbRPTADD, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub ckbRPTPRINT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRPTPRINT.Click
        DoRptCheckedChangedMenuGroup(ckbRPTPRINT, stvFuncMenu.SelectedItem)
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        RptCheckbox_CheckedChanged(ckbRPTPRINT, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        RptCheckbox_CheckedChanged(ckbRPTPRINT, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    RptCheckbox_CheckedChanged(ckbRPTPRINT, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub ckbRPTVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRPTVIEW.Click
        Try
            DoRptCheckedChangedMenuGroup(ckbRPTVIEW, stvFuncMenu.SelectedItem)
        Catch ex As Exception

        End Try
        'If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '    Try
        '        Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '        RptCheckbox_CheckedChanged(ckbRPTVIEW, v_node)
        '        ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '    Catch ex As Exception
        '        RptCheckbox_CheckedChanged(ckbRPTVIEW, stvFuncMenu.SelectedItem)
        '    End Try
        'Else
        '    RptCheckbox_CheckedChanged(ckbRPTVIEW, stvFuncMenu.SelectedItem)
        'End If
    End Sub

    Private Sub DoRptCheckedChangedMenuGroup(ByVal sender As Object, ByRef pv_node As Node)
        Try
            If (pv_node.ImageIndex <> 3 AndAlso pv_node.ImageIndex <> 5) OrElse pv_node.Tag = "P" Then
                If pv_node.Items.Count > 0 Then
                    For i As Integer = 0 To pv_node.Items.Count - 1
                        If pv_node.Items(i).Items.Count > 0 Then
                            DoRptCheckedChangedMenuGroup(sender, pv_node.Items(i))
                        Else
                            If Not pv_node.Items(i).Tag Is Nothing Then
                                Try
                                    Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Items(i).Tag, stvFuncMenu.Items(0)), Node)
                                    RptCheckbox_CheckedChanged(sender, v_node)
                                    'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                                Catch ex As Exception
                                    RptCheckbox_CheckedChanged(sender, pv_node.Items(i))
                                End Try
                            Else
                                RptCheckbox_CheckedChanged(sender, pv_node.Items(i))
                            End If
                        End If
                    Next
                End If
            Else
                If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
                    Try
                        Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Tag, stvFuncMenu.Items(0)), Node)
                        RptCheckbox_CheckedChanged(sender, v_node)
                        'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                    Catch ex As Exception
                        RptCheckbox_CheckedChanged(sender, pv_node)
                    End Try
                Else
                    RptCheckbox_CheckedChanged(sender, pv_node)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cboRPTAREA_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRPTAREA.SelectedValueChanged
        Try
            DoRptCheckedChangedMenuGroup(cboRPTAREA, stvFuncMenu.SelectedItem)
        Catch ex As Exception

        End Try
        'If Not stvFuncMenu.SelectedItem Is Nothing Then
        '    If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
        '        Try
        '            Dim v_node As Node = CType(GetNodeMenuByKey(stvFuncMenu.SelectedItem.Tag, stvFuncMenu.Items(0)), Node)
        '            RptCheckbox_CheckedChanged(cboRPTAREA, v_node)
        '            ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
        '        Catch ex As Exception
        '            RptCheckbox_CheckedChanged(cboRPTAREA, stvFuncMenu.SelectedItem)
        '        End Try
        '    Else
        '        RptCheckbox_CheckedChanged(cboRPTAREA, stvFuncMenu.SelectedItem)
        '    End If
        'End If
    End Sub

    Private Sub ckbGNRACC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbGNRACC.CheckedChanged
        Try
            DoGnrAccessCheckedChangedMenuGroup(ckbGNRACC, stvFuncMenu.SelectedItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DoGnrCheckedChangedMenuGroup(ByVal sender As Object, ByRef pv_node As Node)
        Try
            If (pv_node.ImageIndex <> 3 AndAlso pv_node.ImageIndex <> 5) OrElse pv_node.Tag = "P" Then
                If pv_node.Items.Count > 0 Then
                    For i As Integer = 0 To pv_node.Items.Count - 1
                        If pv_node.Items(i).Items.Count > 0 Then
                            DoGnrCheckedChangedMenuGroup(sender, pv_node.Items(i))
                        Else
                            If Not pv_node.Items(i).Tag Is Nothing Then
                                Try
                                    Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Items(i).Tag, stvFuncMenu.Items(0)), Node)
                                    GnrCheckbox_CheckedChanged(sender, v_node)
                                    'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                                Catch ex As Exception
                                    GnrCheckbox_CheckedChanged(sender, pv_node.Items(i))
                                End Try
                            Else
                                GnrCheckbox_CheckedChanged(sender, pv_node.Items(i))
                            End If
                        End If
                    Next
                End If
            Else
                If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
                    Try
                        Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Tag, stvFuncMenu.Items(0)), Node)
                        GnrCheckbox_CheckedChanged(sender, v_node)
                        'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                    Catch ex As Exception
                        GnrCheckbox_CheckedChanged(sender, pv_node)
                    End Try
                Else
                    GnrCheckbox_CheckedChanged(sender, pv_node)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DoGnrAccessCheckedChangedMenuGroup(ByVal sender As Object, ByRef pv_node As Node)
        Try
            If (pv_node.ImageIndex <> 3 AndAlso pv_node.ImageIndex <> 5) OrElse pv_node.Tag = "P" Then
                If pv_node.Items.Count > 0 Then
                    For i As Integer = 0 To pv_node.Items.Count - 1
                        If pv_node.Items(i).Items.Count > 0 Then
                            DoGnrAccessCheckedChangedMenuGroup(sender, pv_node.Items(i))
                        Else
                            If Not pv_node.Items(i).Tag Is Nothing Then
                                Try
                                    Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Items(i).Tag, stvFuncMenu.Items(0)), Node)
                                    GnrAccessCheckbox_CheckedChanged(sender, v_node)
                                    'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                                Catch ex As Exception
                                    GnrAccessCheckbox_CheckedChanged(sender, pv_node.Items(i))
                                End Try
                            Else
                                GnrAccessCheckbox_CheckedChanged(sender, pv_node.Items(i))
                            End If
                        End If
                    Next
                End If
            Else
                If Not stvFuncMenu.SelectedItem.Tag Is Nothing Then
                    Try
                        Dim v_node As Node = CType(GetNodeMenuByKey(pv_node.Tag, stvFuncMenu.Items(0)), Node)
                        GnrAccessCheckbox_CheckedChanged(sender, v_node)
                        'ChangeImageIndexOnAdjustNode(v_node, stvFuncMenu.Items(1))
                    Catch ex As Exception
                        GnrAccessCheckbox_CheckedChanged(sender, pv_node)
                    End Try
                Else
                    GnrAccessCheckbox_CheckedChanged(sender, pv_node)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GnrAccessCheckbox_CheckedChanged(ByVal sender As Object, ByVal pv_treeNode As Node)

        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)
            If v_strMenuType = "G" Or (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                If pv_treeNode.Items.Count > 0 Then
                    DoGNRACCCheckboxChange(sender, pv_treeNode)
                    Dim v_node As Node
                    For Each v_node In pv_treeNode.Items
                        If v_node.Items.Count > 0 Then
                            GnrAccessCheckbox_CheckedChanged(sender, v_node)
                        Else
                            DoGNRACCCheckboxChange(sender, v_node)
                        End If
                    Next
                Else
                    DoGNRACCCheckboxChange(sender, pv_treeNode)
                End If
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub DoGNRACCCheckboxChange(ByVal sender As Object, ByRef pv_node As Node)
        If ckbGNRACC.Checked Then
            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            Dim v_strTLTXCD, v_strRPTID, v_strLEV, v_strLAST As String
            Dim v_strTXTYPE, v_arr(), v_arrID() As String

            v_arr = pv_node.Key.Split("|")
            v_strLEV = v_arr(1)
            v_strLAST = v_arr(2)
            If v_strLAST = "Y" Then
                v_strTXTYPE = CStr(v_arr(4)).Trim
                v_arrID = CStr(v_arr(0)).Split("^")
                v_strRPTID = v_arrID(0)
                v_strTLTXCD = v_arrID(1)
            End If

            If mv_strRight <> String.Empty And v_strTLTXCD <> "EXEC" And v_strTLTXCD <> "VIEW" And v_strLAST = "Y" Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)

                'Enable textboxs
                txtGNRTELLERLM.Enabled = (v_strTeller = "Y")
                txtGNROFFICERLM.Enabled = (v_strOfficer = "Y")
                txtGNRCHECKERLM.Enabled = (v_strChecker = "Y")


                If (v_strTXTYPE = "D") Or (v_strTXTYPE = "W") Then
                    txtGNRCASHIERLM.Enabled = (v_strCashier = "Y")
                Else
                    txtGNRCASHIERLM.Enabled = False
                End If
                cboGNRCURR.Enabled = True
            ElseIf v_strLAST = "N" And mv_strRight <> String.Empty Then
                v_strTeller = Mid(mv_strRight, 1, 1)
                v_strCashier = Mid(mv_strRight, 2, 1)
                v_strOfficer = Mid(mv_strRight, 3, 1)
                v_strChecker = Mid(mv_strRight, 4, 1)

                'Enable textboxs
                txtGNRTELLERLM.Enabled = (v_strTeller = "Y")
                txtGNROFFICERLM.Enabled = (v_strOfficer = "Y")
                txtGNRCHECKERLM.Enabled = (v_strChecker = "Y")
                txtGNRCASHIERLM.Enabled = False
                cboGNRCURR.Enabled = True
            End If
        Else
            txtGNRTELLERLM.Enabled = False
            txtGNROFFICERLM.Enabled = False
            txtGNRCHECKERLM.Enabled = False
            txtGNRCASHIERLM.Enabled = False
            cboGNRCURR.Enabled = False
            txtGNRTELLERLM.Text = String.Empty
            txtGNROFFICERLM.Text = String.Empty
            txtGNRCHECKERLM.Text = String.Empty
            txtGNRCASHIERLM.Text = String.Empty
        End If
        'ShowGnrAccessRight(ckbGNRACC, mv_node)
        'GnrCheckbox_CheckedChanged(ckbGNRACC, mv_node)
    End Sub

    Private Sub ShowGnrAccessRightGroup(ByVal pv_txtBox As TextBox, ByRef pv_node As Node)
        Dim v_strCMDID, v_strLEV, v_strLast, v_strMenuType, v_strSubMenuType As String
        Dim v_arrMenuKey As String()
        If pv_node.Items.Count > 0 Then
            For i As Integer = 0 To pv_node.Items.Count - 1
                If pv_node.Items(i).Items.Count > 0 Then
                    ShowGnrAccessRightGroup(pv_txtBox, pv_node.Items(i))
                Else
                    v_arrMenuKey = pv_node.Items(i).Key.Split("|")
                    v_strCMDID = v_arrMenuKey(0)
                    v_strLEV = v_arrMenuKey(1)
                    v_strLast = v_arrMenuKey(2)
                    v_strMenuType = v_arrMenuKey(3)
                    v_strSubMenuType = v_arrMenuKey(4)
                    If v_strMenuType = "G" Or (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                        ShowGnrAccessRight(pv_txtBox, pv_node.Items(i))
                    End If
                End If
            Next
        Else
            v_arrMenuKey = pv_node.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strLast = v_arrMenuKey(2)
            v_strMenuType = v_arrMenuKey(3)
            v_strSubMenuType = v_arrMenuKey(4)
            If v_strMenuType = "G" Or (v_strMenuType = "M" And v_strSubMenuType = "G") Then
                ShowGnrAccessRight(pv_txtBox, pv_node)
            End If
        End If
    End Sub

    Private Sub txtGNRCASHIERLM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRCASHIERLM.GotFocus
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub txtGNRCASHIERLM_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRCASHIERLM.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If ckbGNRACC.Checked Then
            DoGnrCheckedChangedMenuGroup(ckbGNRACC, Me.stvFuncMenu.SelectedItem)
        End If
        If VerifyGnrDataType() = False Then
            Exit Sub
        End If
        ShowGnrAccessRightGroup(txtGNRCASHIERLM, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtGNRCHECKERLM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRCHECKERLM.GotFocus
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub txtGNRCHECKERLM_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRCHECKERLM.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If ckbGNRACC.Checked Then
            DoGnrCheckedChangedMenuGroup(ckbGNRACC, Me.stvFuncMenu.SelectedItem)
        End If
        If VerifyGnrDataType() = False Then
            Exit Sub
        End If
        ShowGnrAccessRightGroup(txtGNRCHECKERLM, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtGNROFFICERLM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNROFFICERLM.GotFocus
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub txtGNROFFICERLM_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNROFFICERLM.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If ckbGNRACC.Checked Then
            DoGnrCheckedChangedMenuGroup(ckbGNRACC, Me.stvFuncMenu.SelectedItem)
        End If
        If VerifyGnrDataType() = False Then
            Exit Sub
        End If
        ShowGnrAccessRightGroup(txtGNROFFICERLM, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub txtGNRTELLERLM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRTELLERLM.GotFocus
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub

    Private Sub txtGNRTELLERLM_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNRTELLERLM.Leave
        ShowAccessRight(Me.stvFuncMenu.SelectedItem)
        If ckbGNRACC.Checked Then
            DoGnrCheckedChangedMenuGroup(ckbGNRACC, Me.stvFuncMenu.SelectedItem)
        End If
        If VerifyGnrDataType() = False Then
            Exit Sub
        End If
        ShowGnrAccessRightGroup(txtGNRTELLERLM, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub stvFuncMenu_ItemDoubleClick(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemEventArgs) Handles stvFuncMenu.ItemDoubleClick
        Try
            If (stvFuncMenu.SelectedItem.Items.Count > 0) Then
                SendKeys.Send("{Right}")
                SendKeys.Flush()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ckbGNRACC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbGNRACC.Click
        DoGnrCheckedChangedMenuGroup(ckbGNRACC, Me.stvFuncMenu.SelectedItem)
    End Sub

    Private Sub stvFuncMenu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stvFuncMenu.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Menu_Click(stvFuncMenu.SelectedItem)
        End If
    End Sub

#End Region



    Private Sub cboRPTAREA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRPTAREA.SelectedIndexChanged

    End Sub

    Private Sub txtGNROFFICERLM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGNROFFICERLM.Validating
        Return
    End Sub

    Private Sub txtTELLERLIMIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.Enter

    End Sub

    Private Sub txtTELLERLIMIT_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTELLERLIMIT.LocationChanged

    End Sub

    Private Sub lblOFFICERLIMIT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblOFFICERLIMIT.GotFocus
        mv_currnodeIdx = stvFuncMenu.SelectedItem.Index
    End Sub
End Class
