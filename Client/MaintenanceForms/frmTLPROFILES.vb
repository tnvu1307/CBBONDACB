Imports AppCore
Imports CommonLibrary

Public Class frmTLPROFILES
    Inherits AppCore.frmMaintenance

#Region " Windows Form Designer generated code "

    Public Sub New()
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
    Friend WithEvents txtTLID As FlexMaskEditBox
    Friend WithEvents grbUSERINFO As System.Windows.Forms.GroupBox
    Friend WithEvents cboBRID As AppCore.ComboBoxEx
    Friend WithEvents lblBRID As System.Windows.Forms.Label
    Friend WithEvents lblTLGROUP As System.Windows.Forms.Label
    Friend WithEvents DESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblTLPRN As System.Windows.Forms.Label
    Friend WithEvents lblTLTITLE As System.Windows.Forms.Label
    Friend WithEvents lblTLNAME As System.Windows.Forms.Label
    Friend WithEvents lblTLLEV As System.Windows.Forms.Label
    Friend WithEvents lblTLID As System.Windows.Forms.Label
    Friend WithEvents cboTLGROUP As AppCore.ComboBoxEx
    Friend WithEvents txtTLLEV As FlexMaskEditBox
    Friend WithEvents txtTLPRN As System.Windows.Forms.TextBox
    Friend WithEvents txtTLNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtTLTITLE As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents grbASSIGN As System.Windows.Forms.GroupBox
    Friend WithEvents btnRptAssign As System.Windows.Forms.Button
    Friend WithEvents btnTransAssign As System.Windows.Forms.Button
    Friend WithEvents btnFuncAssign As System.Windows.Forms.Button
    Friend WithEvents txtPIN As System.Windows.Forms.TextBox
    Friend WithEvents lblPIN As System.Windows.Forms.Label
    Friend WithEvents lblTLFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtTLFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents grbTLTYPE As System.Windows.Forms.GroupBox
    Friend WithEvents ckbTELLER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCHECKER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbOFFICER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCASHIER As System.Windows.Forms.CheckBox
    Friend WithEvents btnGroups As System.Windows.Forms.Button
    Friend WithEvents ckbVIEWER As System.Windows.Forms.CheckBox
    Friend WithEvents lblACTIVE As System.Windows.Forms.Label
    Friend WithEvents cboACTIVE As AppCore.ComboBoxEx
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents btnRightAssign As System.Windows.Forms.Button
    Friend WithEvents lblHOMEORDER As System.Windows.Forms.Label
    Friend WithEvents cboHOMEORDER As AppCore.ComboBoxEx
    Friend WithEvents cboISPARCERT As AppCore.ComboBoxEx
    Friend WithEvents lblISPARCERT As System.Windows.Forms.Label
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents txtTLTITLE1 As System.Windows.Forms.TextBox
    Friend WithEvents lblEMAIL As System.Windows.Forms.Label
    Friend WithEvents lblTLTITLE1 As System.Windows.Forms.Label
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents lblTLTITLE1EN As System.Windows.Forms.Label
    Friend WithEvents txtTLTITLE1EN As System.Windows.Forms.TextBox
    Friend WithEvents lblTLTITLENB As System.Windows.Forms.Label
    Friend WithEvents txtTLTITLENB As System.Windows.Forms.TextBox
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents DataTable11 As System.Data.DataTable
    Friend WithEvents DataTable37 As System.Data.DataTable
    Friend WithEvents DataTable38 As System.Data.DataTable
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents txtIDCODE As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTLPROFILES))
        Me.txtTLID = New AppCore.FlexMaskEditBox()
        Me.grbUSERINFO = New System.Windows.Forms.GroupBox()
        Me.lblTLTITLE1EN = New System.Windows.Forms.Label()
        Me.txtTLTITLE1EN = New System.Windows.Forms.TextBox()
        Me.lblTLTITLENB = New System.Windows.Forms.Label()
        Me.txtTLTITLENB = New System.Windows.Forms.TextBox()
        Me.lblEMAIL = New System.Windows.Forms.Label()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.lblTLTITLE1 = New System.Windows.Forms.Label()
        Me.txtTLTITLE1 = New System.Windows.Forms.TextBox()
        Me.cboISPARCERT = New AppCore.ComboBoxEx()
        Me.lblISPARCERT = New System.Windows.Forms.Label()
        Me.cboHOMEORDER = New AppCore.ComboBoxEx()
        Me.lblHOMEORDER = New System.Windows.Forms.Label()
        Me.lblIDCODE = New System.Windows.Forms.Label()
        Me.txtIDCODE = New System.Windows.Forms.TextBox()
        Me.lblACTIVE = New System.Windows.Forms.Label()
        Me.cboACTIVE = New AppCore.ComboBoxEx()
        Me.lblTLFULLNAME = New System.Windows.Forms.Label()
        Me.txtTLFULLNAME = New System.Windows.Forms.TextBox()
        Me.lblPIN = New System.Windows.Forms.Label()
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.cboBRID = New AppCore.ComboBoxEx()
        Me.lblBRID = New System.Windows.Forms.Label()
        Me.lblTLGROUP = New System.Windows.Forms.Label()
        Me.DESCRIPTION = New System.Windows.Forms.Label()
        Me.lblTLPRN = New System.Windows.Forms.Label()
        Me.lblTLTITLE = New System.Windows.Forms.Label()
        Me.lblTLNAME = New System.Windows.Forms.Label()
        Me.lblTLLEV = New System.Windows.Forms.Label()
        Me.lblTLID = New System.Windows.Forms.Label()
        Me.cboTLGROUP = New AppCore.ComboBoxEx()
        Me.txtTLLEV = New AppCore.FlexMaskEditBox()
        Me.txtTLPRN = New System.Windows.Forms.TextBox()
        Me.txtTLNAME = New System.Windows.Forms.TextBox()
        Me.txtTLTITLE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.grbASSIGN = New System.Windows.Forms.GroupBox()
        Me.btnRightAssign = New System.Windows.Forms.Button()
        Me.btnGroups = New System.Windows.Forms.Button()
        Me.btnRptAssign = New System.Windows.Forms.Button()
        Me.btnTransAssign = New System.Windows.Forms.Button()
        Me.btnFuncAssign = New System.Windows.Forms.Button()
        Me.grbTLTYPE = New System.Windows.Forms.GroupBox()
        Me.ckbVIEWER = New System.Windows.Forms.CheckBox()
        Me.ckbCHECKER = New System.Windows.Forms.CheckBox()
        Me.ckbOFFICER = New System.Windows.Forms.CheckBox()
        Me.ckbCASHIER = New System.Windows.Forms.CheckBox()
        Me.ckbTELLER = New System.Windows.Forms.CheckBox()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable11 = New System.Data.DataTable()
        Me.DataTable37 = New System.Data.DataTable()
        Me.DataTable38 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.grbUSERINFO.SuspendLayout()
        Me.grbASSIGN.SuspendLayout()
        Me.grbTLTYPE.SuspendLayout()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(426, 434)
        Me.btnOK.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(507, 434)
        Me.btnCancel.TabIndex = 4
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(345, 434)
        Me.btnApply.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(660, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(261, 501)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(5, 503)
        '
        'txtTLID
        '
        Me.txtTLID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTLID.Location = New System.Drawing.Point(125, 20)
        Me.txtTLID.Name = "txtTLID"
        Me.txtTLID.Size = New System.Drawing.Size(150, 21)
        Me.txtTLID.TabIndex = 0
        Me.txtTLID.Tag = "TLID"
        Me.txtTLID.Text = "txtTLID"
        '
        'grbUSERINFO
        '
        Me.grbUSERINFO.Controls.Add(Me.lblTLTITLE1EN)
        Me.grbUSERINFO.Controls.Add(Me.txtTLTITLE1EN)
        Me.grbUSERINFO.Controls.Add(Me.lblTLTITLENB)
        Me.grbUSERINFO.Controls.Add(Me.txtTLTITLENB)
        Me.grbUSERINFO.Controls.Add(Me.lblEMAIL)
        Me.grbUSERINFO.Controls.Add(Me.txtEMAIL)
        Me.grbUSERINFO.Controls.Add(Me.lblTLTITLE1)
        Me.grbUSERINFO.Controls.Add(Me.txtTLTITLE1)
        Me.grbUSERINFO.Controls.Add(Me.cboISPARCERT)
        Me.grbUSERINFO.Controls.Add(Me.lblISPARCERT)
        Me.grbUSERINFO.Controls.Add(Me.cboHOMEORDER)
        Me.grbUSERINFO.Controls.Add(Me.lblHOMEORDER)
        Me.grbUSERINFO.Controls.Add(Me.lblIDCODE)
        Me.grbUSERINFO.Controls.Add(Me.txtIDCODE)
        Me.grbUSERINFO.Controls.Add(Me.lblACTIVE)
        Me.grbUSERINFO.Controls.Add(Me.cboACTIVE)
        Me.grbUSERINFO.Controls.Add(Me.lblTLFULLNAME)
        Me.grbUSERINFO.Controls.Add(Me.txtTLFULLNAME)
        Me.grbUSERINFO.Controls.Add(Me.lblPIN)
        Me.grbUSERINFO.Controls.Add(Me.txtPIN)
        Me.grbUSERINFO.Controls.Add(Me.cboBRID)
        Me.grbUSERINFO.Controls.Add(Me.lblBRID)
        Me.grbUSERINFO.Controls.Add(Me.lblTLGROUP)
        Me.grbUSERINFO.Controls.Add(Me.DESCRIPTION)
        Me.grbUSERINFO.Controls.Add(Me.lblTLPRN)
        Me.grbUSERINFO.Controls.Add(Me.lblTLTITLE)
        Me.grbUSERINFO.Controls.Add(Me.lblTLNAME)
        Me.grbUSERINFO.Controls.Add(Me.lblTLLEV)
        Me.grbUSERINFO.Controls.Add(Me.lblTLID)
        Me.grbUSERINFO.Controls.Add(Me.cboTLGROUP)
        Me.grbUSERINFO.Controls.Add(Me.txtTLLEV)
        Me.grbUSERINFO.Controls.Add(Me.txtTLPRN)
        Me.grbUSERINFO.Controls.Add(Me.txtTLNAME)
        Me.grbUSERINFO.Controls.Add(Me.txtTLTITLE)
        Me.grbUSERINFO.Controls.Add(Me.txtDESCRIPTION)
        Me.grbUSERINFO.Controls.Add(Me.txtTLID)
        Me.grbUSERINFO.Location = New System.Drawing.Point(5, 55)
        Me.grbUSERINFO.Name = "grbUSERINFO"
        Me.grbUSERINFO.Size = New System.Drawing.Size(648, 300)
        Me.grbUSERINFO.TabIndex = 0
        Me.grbUSERINFO.TabStop = False
        Me.grbUSERINFO.Tag = "USERINFO"
        Me.grbUSERINFO.Text = "grbUSERINFO"
        '
        'lblTLTITLE1EN
        '
        Me.lblTLTITLE1EN.AutoSize = True
        Me.lblTLTITLE1EN.Location = New System.Drawing.Point(290, 148)
        Me.lblTLTITLE1EN.Name = "lblTLTITLE1EN"
        Me.lblTLTITLE1EN.Size = New System.Drawing.Size(74, 13)
        Me.lblTLTITLE1EN.TabIndex = 67
        Me.lblTLTITLE1EN.Tag = "TLTITLETEN"
        Me.lblTLTITLE1EN.Text = "lblTLTITLE1EN"
        Me.lblTLTITLE1EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLTITLE1EN
        '
        Me.txtTLTITLE1EN.Location = New System.Drawing.Point(492, 147)
        Me.txtTLTITLE1EN.Name = "txtTLTITLE1EN"
        Me.txtTLTITLE1EN.Size = New System.Drawing.Size(150, 21)
        Me.txtTLTITLE1EN.TabIndex = 11
        Me.txtTLTITLE1EN.Tag = "TLTITLETEN"
        '
        'lblTLTITLENB
        '
        Me.lblTLTITLENB.AutoSize = True
        Me.lblTLTITLENB.Location = New System.Drawing.Point(290, 120)
        Me.lblTLTITLENB.Name = "lblTLTITLENB"
        Me.lblTLTITLENB.Size = New System.Drawing.Size(68, 13)
        Me.lblTLTITLENB.TabIndex = 65
        Me.lblTLTITLENB.Tag = "TLTITLENB"
        Me.lblTLTITLENB.Text = "lblTLTITLENB"
        Me.lblTLTITLENB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLTITLENB
        '
        Me.txtTLTITLENB.Location = New System.Drawing.Point(492, 119)
        Me.txtTLTITLENB.Name = "txtTLTITLENB"
        Me.txtTLTITLENB.Size = New System.Drawing.Size(150, 21)
        Me.txtTLTITLENB.TabIndex = 9
        Me.txtTLTITLENB.Tag = "TLTITLENB"
        '
        'lblEMAIL
        '
        Me.lblEMAIL.AutoSize = True
        Me.lblEMAIL.Location = New System.Drawing.Point(10, 177)
        Me.lblEMAIL.Name = "lblEMAIL"
        Me.lblEMAIL.Size = New System.Drawing.Size(47, 13)
        Me.lblEMAIL.TabIndex = 63
        Me.lblEMAIL.Tag = "EMAIL"
        Me.lblEMAIL.Text = "lblEMAIL"
        Me.lblEMAIL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(125, 174)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(150, 21)
        Me.txtEMAIL.TabIndex = 12
        Me.txtEMAIL.Tag = "EMAIL"
        '
        'lblTLTITLE1
        '
        Me.lblTLTITLE1.AutoSize = True
        Me.lblTLTITLE1.Location = New System.Drawing.Point(10, 148)
        Me.lblTLTITLE1.Name = "lblTLTITLE1"
        Me.lblTLTITLE1.Size = New System.Drawing.Size(61, 13)
        Me.lblTLTITLE1.TabIndex = 61
        Me.lblTLTITLE1.Tag = "TLTITLET"
        Me.lblTLTITLE1.Text = "lblTLTITLE1"
        Me.lblTLTITLE1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLTITLE1
        '
        Me.txtTLTITLE1.Location = New System.Drawing.Point(125, 148)
        Me.txtTLTITLE1.Name = "txtTLTITLE1"
        Me.txtTLTITLE1.Size = New System.Drawing.Size(150, 21)
        Me.txtTLTITLE1.TabIndex = 10
        Me.txtTLTITLE1.Tag = "TLTITLET"
        Me.txtTLTITLE1.Text = "txtTLTITLE1"
        '
        'cboISPARCERT
        '
        Me.cboISPARCERT.DisplayMember = "DISPLAY"
        Me.cboISPARCERT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboISPARCERT.Location = New System.Drawing.Point(492, 205)
        Me.cboISPARCERT.Name = "cboISPARCERT"
        Me.cboISPARCERT.Size = New System.Drawing.Size(150, 21)
        Me.cboISPARCERT.TabIndex = 15
        Me.cboISPARCERT.Tag = "ISPARCERT"
        Me.cboISPARCERT.ValueMember = "VALUE"
        '
        'lblISPARCERT
        '
        Me.lblISPARCERT.AutoSize = True
        Me.lblISPARCERT.Location = New System.Drawing.Point(290, 209)
        Me.lblISPARCERT.Name = "lblISPARCERT"
        Me.lblISPARCERT.Size = New System.Drawing.Size(73, 13)
        Me.lblISPARCERT.TabIndex = 58
        Me.lblISPARCERT.Tag = "lblISPARCERT"
        Me.lblISPARCERT.Text = "lblISPARCERT"
        '
        'cboHOMEORDER
        '
        Me.cboHOMEORDER.DisplayMember = "DISPLAY"
        Me.cboHOMEORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHOMEORDER.Location = New System.Drawing.Point(125, 208)
        Me.cboHOMEORDER.Name = "cboHOMEORDER"
        Me.cboHOMEORDER.Size = New System.Drawing.Size(150, 21)
        Me.cboHOMEORDER.TabIndex = 14
        Me.cboHOMEORDER.Tag = "HOMEORDER"
        Me.cboHOMEORDER.ValueMember = "VALUE"
        '
        'lblHOMEORDER
        '
        Me.lblHOMEORDER.AutoSize = True
        Me.lblHOMEORDER.Location = New System.Drawing.Point(10, 209)
        Me.lblHOMEORDER.Name = "lblHOMEORDER"
        Me.lblHOMEORDER.Size = New System.Drawing.Size(81, 13)
        Me.lblHOMEORDER.TabIndex = 58
        Me.lblHOMEORDER.Tag = "HOMEORDER"
        Me.lblHOMEORDER.Text = "lblHOMEORDER"
        '
        'lblIDCODE
        '
        Me.lblIDCODE.AutoSize = True
        Me.lblIDCODE.Location = New System.Drawing.Point(290, 177)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(56, 13)
        Me.lblIDCODE.TabIndex = 57
        Me.lblIDCODE.Tag = "IDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        Me.lblIDCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDCODE
        '
        Me.txtIDCODE.Location = New System.Drawing.Point(492, 173)
        Me.txtIDCODE.Name = "txtIDCODE"
        Me.txtIDCODE.Size = New System.Drawing.Size(150, 21)
        Me.txtIDCODE.TabIndex = 13
        Me.txtIDCODE.Tag = "IDCODE"
        '
        'lblACTIVE
        '
        Me.lblACTIVE.AutoSize = True
        Me.lblACTIVE.Location = New System.Drawing.Point(290, 95)
        Me.lblACTIVE.Name = "lblACTIVE"
        Me.lblACTIVE.Size = New System.Drawing.Size(53, 13)
        Me.lblACTIVE.TabIndex = 55
        Me.lblACTIVE.Tag = "ACTIVE"
        Me.lblACTIVE.Text = "lblACTIVE"
        Me.lblACTIVE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboACTIVE
        '
        Me.cboACTIVE.DisplayMember = "DISPLAY"
        Me.cboACTIVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboACTIVE.Location = New System.Drawing.Point(492, 94)
        Me.cboACTIVE.Name = "cboACTIVE"
        Me.cboACTIVE.Size = New System.Drawing.Size(150, 21)
        Me.cboACTIVE.TabIndex = 7
        Me.cboACTIVE.Tag = "ACTIVE"
        Me.cboACTIVE.ValueMember = "VALUE"
        '
        'lblTLFULLNAME
        '
        Me.lblTLFULLNAME.AutoSize = True
        Me.lblTLFULLNAME.Location = New System.Drawing.Point(10, 97)
        Me.lblTLFULLNAME.Name = "lblTLFULLNAME"
        Me.lblTLFULLNAME.Size = New System.Drawing.Size(79, 13)
        Me.lblTLFULLNAME.TabIndex = 53
        Me.lblTLFULLNAME.Tag = "TLFULLNAME"
        Me.lblTLFULLNAME.Text = "lblTLFULLNAME"
        Me.lblTLFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLFULLNAME
        '
        Me.txtTLFULLNAME.Location = New System.Drawing.Point(125, 95)
        Me.txtTLFULLNAME.Name = "txtTLFULLNAME"
        Me.txtTLFULLNAME.Size = New System.Drawing.Size(150, 21)
        Me.txtTLFULLNAME.TabIndex = 6
        Me.txtTLFULLNAME.Tag = "TLFULLNAME"
        Me.txtTLFULLNAME.Text = "txtTLFULLNAME"
        '
        'lblPIN
        '
        Me.lblPIN.AutoSize = True
        Me.lblPIN.Location = New System.Drawing.Point(290, 72)
        Me.lblPIN.Name = "lblPIN"
        Me.lblPIN.Size = New System.Drawing.Size(34, 13)
        Me.lblPIN.TabIndex = 51
        Me.lblPIN.Tag = "PIN"
        Me.lblPIN.Text = "lblPIN"
        Me.lblPIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPIN
        '
        Me.txtPIN.Location = New System.Drawing.Point(492, 69)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPIN.Size = New System.Drawing.Size(150, 21)
        Me.txtPIN.TabIndex = 5
        Me.txtPIN.Tag = "PIN"
        '
        'cboBRID
        '
        Me.cboBRID.DisplayMember = "DISPLAY"
        Me.cboBRID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBRID.Location = New System.Drawing.Point(492, 19)
        Me.cboBRID.Name = "cboBRID"
        Me.cboBRID.Size = New System.Drawing.Size(150, 21)
        Me.cboBRID.TabIndex = 1
        Me.cboBRID.Tag = "BRID"
        Me.cboBRID.ValueMember = "VALUE"
        '
        'lblBRID
        '
        Me.lblBRID.AutoSize = True
        Me.lblBRID.Location = New System.Drawing.Point(290, 22)
        Me.lblBRID.Name = "lblBRID"
        Me.lblBRID.Size = New System.Drawing.Size(41, 13)
        Me.lblBRID.TabIndex = 49
        Me.lblBRID.Tag = "BRID"
        Me.lblBRID.Text = "lblBRID"
        Me.lblBRID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLGROUP
        '
        Me.lblTLGROUP.AutoSize = True
        Me.lblTLGROUP.Location = New System.Drawing.Point(10, 47)
        Me.lblTLGROUP.Name = "lblTLGROUP"
        Me.lblTLGROUP.Size = New System.Drawing.Size(63, 13)
        Me.lblTLGROUP.TabIndex = 48
        Me.lblTLGROUP.Tag = "TLGROUP"
        Me.lblTLGROUP.Text = "lblTLGROUP"
        Me.lblTLGROUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AutoSize = True
        Me.DESCRIPTION.Location = New System.Drawing.Point(10, 262)
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.Size = New System.Drawing.Size(85, 13)
        Me.DESCRIPTION.TabIndex = 47
        Me.DESCRIPTION.Tag = "DESCRIPTION"
        Me.DESCRIPTION.Text = "lblDESCRIPTION"
        Me.DESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLPRN
        '
        Me.lblTLPRN.AutoSize = True
        Me.lblTLPRN.Location = New System.Drawing.Point(10, 237)
        Me.lblTLPRN.Name = "lblTLPRN"
        Me.lblTLPRN.Size = New System.Drawing.Size(48, 13)
        Me.lblTLPRN.TabIndex = 46
        Me.lblTLPRN.Tag = "TLPRN"
        Me.lblTLPRN.Text = "lblTLPRN"
        Me.lblTLPRN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLTITLE
        '
        Me.lblTLTITLE.AutoSize = True
        Me.lblTLTITLE.Location = New System.Drawing.Point(10, 120)
        Me.lblTLTITLE.Name = "lblTLTITLE"
        Me.lblTLTITLE.Size = New System.Drawing.Size(55, 13)
        Me.lblTLTITLE.TabIndex = 45
        Me.lblTLTITLE.Tag = "TLTITLE"
        Me.lblTLTITLE.Text = "lblTLTITLE"
        Me.lblTLTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLNAME
        '
        Me.lblTLNAME.AutoSize = True
        Me.lblTLNAME.Location = New System.Drawing.Point(10, 72)
        Me.lblTLNAME.Name = "lblTLNAME"
        Me.lblTLNAME.Size = New System.Drawing.Size(56, 13)
        Me.lblTLNAME.TabIndex = 44
        Me.lblTLNAME.Tag = "TLNAME"
        Me.lblTLNAME.Text = "lblTLNAME"
        Me.lblTLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLLEV
        '
        Me.lblTLLEV.AutoSize = True
        Me.lblTLLEV.Location = New System.Drawing.Point(290, 47)
        Me.lblTLLEV.Name = "lblTLLEV"
        Me.lblTLLEV.Size = New System.Drawing.Size(45, 13)
        Me.lblTLLEV.TabIndex = 43
        Me.lblTLLEV.Tag = "TLLEV"
        Me.lblTLLEV.Text = "lblTLLEV"
        Me.lblTLLEV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTLID
        '
        Me.lblTLID.AutoSize = True
        Me.lblTLID.Location = New System.Drawing.Point(10, 22)
        Me.lblTLID.Name = "lblTLID"
        Me.lblTLID.Size = New System.Drawing.Size(39, 13)
        Me.lblTLID.TabIndex = 42
        Me.lblTLID.Tag = "TLID"
        Me.lblTLID.Text = "lblTLID"
        Me.lblTLID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTLGROUP
        '
        Me.cboTLGROUP.DisplayMember = "DISPLAY"
        Me.cboTLGROUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTLGROUP.Location = New System.Drawing.Point(125, 45)
        Me.cboTLGROUP.Name = "cboTLGROUP"
        Me.cboTLGROUP.Size = New System.Drawing.Size(150, 21)
        Me.cboTLGROUP.TabIndex = 2
        Me.cboTLGROUP.Tag = "TLGROUP"
        Me.cboTLGROUP.ValueMember = "VALUE"
        '
        'txtTLLEV
        '
        Me.txtTLLEV.Enabled = False
        Me.txtTLLEV.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTLLEV.Location = New System.Drawing.Point(492, 44)
        Me.txtTLLEV.Name = "txtTLLEV"
        Me.txtTLLEV.Size = New System.Drawing.Size(150, 21)
        Me.txtTLLEV.TabIndex = 3
        Me.txtTLLEV.Tag = "TLLEV"
        Me.txtTLLEV.Text = "txtTLLEV"
        '
        'txtTLPRN
        '
        Me.txtTLPRN.Location = New System.Drawing.Point(125, 236)
        Me.txtTLPRN.Name = "txtTLPRN"
        Me.txtTLPRN.Size = New System.Drawing.Size(517, 21)
        Me.txtTLPRN.TabIndex = 16
        Me.txtTLPRN.Tag = "TLPRN"
        Me.txtTLPRN.Text = "txtTLPRN"
        '
        'txtTLNAME
        '
        Me.txtTLNAME.Location = New System.Drawing.Point(125, 70)
        Me.txtTLNAME.Name = "txtTLNAME"
        Me.txtTLNAME.Size = New System.Drawing.Size(150, 21)
        Me.txtTLNAME.TabIndex = 4
        Me.txtTLNAME.Tag = "TLNAME"
        Me.txtTLNAME.Text = "txtTLNAME"
        '
        'txtTLTITLE
        '
        Me.txtTLTITLE.Location = New System.Drawing.Point(125, 120)
        Me.txtTLTITLE.Name = "txtTLTITLE"
        Me.txtTLTITLE.Size = New System.Drawing.Size(150, 21)
        Me.txtTLTITLE.TabIndex = 8
        Me.txtTLTITLE.Tag = "TLTITLE"
        Me.txtTLTITLE.Text = "txtTLTITLE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(125, 262)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(517, 21)
        Me.txtDESCRIPTION.TabIndex = 17
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'grbASSIGN
        '
        Me.grbASSIGN.Controls.Add(Me.btnRightAssign)
        Me.grbASSIGN.Controls.Add(Me.btnGroups)
        Me.grbASSIGN.Controls.Add(Me.btnRptAssign)
        Me.grbASSIGN.Controls.Add(Me.btnTransAssign)
        Me.grbASSIGN.Controls.Add(Me.btnFuncAssign)
        Me.grbASSIGN.Location = New System.Drawing.Point(5, 419)
        Me.grbASSIGN.Name = "grbASSIGN"
        Me.grbASSIGN.Size = New System.Drawing.Size(239, 47)
        Me.grbASSIGN.TabIndex = 2
        Me.grbASSIGN.TabStop = False
        Me.grbASSIGN.Tag = "ASSIGN"
        Me.grbASSIGN.Text = "grbASSIGN"
        '
        'btnRightAssign
        '
        Me.btnRightAssign.Location = New System.Drawing.Point(13, 15)
        Me.btnRightAssign.Name = "btnRightAssign"
        Me.btnRightAssign.Size = New System.Drawing.Size(100, 23)
        Me.btnRightAssign.TabIndex = 0
        Me.btnRightAssign.Tag = "btnRightAssign"
        Me.btnRightAssign.Text = "btnRightAssign"
        '
        'btnGroups
        '
        Me.btnGroups.Location = New System.Drawing.Point(127, 15)
        Me.btnGroups.Name = "btnGroups"
        Me.btnGroups.Size = New System.Drawing.Size(100, 23)
        Me.btnGroups.TabIndex = 1
        Me.btnGroups.Tag = "btnGroups"
        Me.btnGroups.Text = "btnGroups"
        '
        'btnRptAssign
        '
        Me.btnRptAssign.Location = New System.Drawing.Point(163, 48)
        Me.btnRptAssign.Name = "btnRptAssign"
        Me.btnRptAssign.Size = New System.Drawing.Size(75, 23)
        Me.btnRptAssign.TabIndex = 2
        Me.btnRptAssign.Tag = "btnRptAssign"
        Me.btnRptAssign.Text = "btnRptAssign"
        '
        'btnTransAssign
        '
        Me.btnTransAssign.Location = New System.Drawing.Point(83, 48)
        Me.btnTransAssign.Name = "btnTransAssign"
        Me.btnTransAssign.Size = New System.Drawing.Size(75, 23)
        Me.btnTransAssign.TabIndex = 1
        Me.btnTransAssign.Tag = "btnTransAssign"
        Me.btnTransAssign.Text = "btnTransAssign"
        '
        'btnFuncAssign
        '
        Me.btnFuncAssign.Location = New System.Drawing.Point(8, 48)
        Me.btnFuncAssign.Name = "btnFuncAssign"
        Me.btnFuncAssign.Size = New System.Drawing.Size(75, 23)
        Me.btnFuncAssign.TabIndex = 0
        Me.btnFuncAssign.Tag = "btnFuncAssign"
        Me.btnFuncAssign.Text = "btnFuncAssign"
        '
        'grbTLTYPE
        '
        Me.grbTLTYPE.Controls.Add(Me.ckbVIEWER)
        Me.grbTLTYPE.Controls.Add(Me.ckbCHECKER)
        Me.grbTLTYPE.Controls.Add(Me.ckbOFFICER)
        Me.grbTLTYPE.Controls.Add(Me.ckbCASHIER)
        Me.grbTLTYPE.Controls.Add(Me.ckbTELLER)
        Me.grbTLTYPE.Location = New System.Drawing.Point(5, 361)
        Me.grbTLTYPE.Name = "grbTLTYPE"
        Me.grbTLTYPE.Size = New System.Drawing.Size(575, 55)
        Me.grbTLTYPE.TabIndex = 1
        Me.grbTLTYPE.TabStop = False
        Me.grbTLTYPE.Tag = "TLTYPE"
        Me.grbTLTYPE.Text = "grbTLTYPE"
        '
        'ckbVIEWER
        '
        Me.ckbVIEWER.Location = New System.Drawing.Point(10, 20)
        Me.ckbVIEWER.Name = "ckbVIEWER"
        Me.ckbVIEWER.Size = New System.Drawing.Size(105, 25)
        Me.ckbVIEWER.TabIndex = 0
        Me.ckbVIEWER.Tag = "VIEWER"
        Me.ckbVIEWER.Text = "ckbVIEWER"
        '
        'ckbCHECKER
        '
        Me.ckbCHECKER.Location = New System.Drawing.Point(465, 20)
        Me.ckbCHECKER.Name = "ckbCHECKER"
        Me.ckbCHECKER.Size = New System.Drawing.Size(105, 25)
        Me.ckbCHECKER.TabIndex = 4
        Me.ckbCHECKER.Tag = "CHECKER"
        Me.ckbCHECKER.Text = "ckbCHECKER"
        '
        'ckbOFFICER
        '
        Me.ckbOFFICER.Location = New System.Drawing.Point(352, 20)
        Me.ckbOFFICER.Name = "ckbOFFICER"
        Me.ckbOFFICER.Size = New System.Drawing.Size(105, 25)
        Me.ckbOFFICER.TabIndex = 3
        Me.ckbOFFICER.Tag = "OFFICER"
        Me.ckbOFFICER.Text = "ckbOFFICER"
        '
        'ckbCASHIER
        '
        Me.ckbCASHIER.Location = New System.Drawing.Point(236, 20)
        Me.ckbCASHIER.Name = "ckbCASHIER"
        Me.ckbCASHIER.Size = New System.Drawing.Size(105, 25)
        Me.ckbCASHIER.TabIndex = 2
        Me.ckbCASHIER.Tag = "CASHIER"
        Me.ckbCASHIER.Text = "ckbCASHIER"
        '
        'ckbTELLER
        '
        Me.ckbTELLER.Location = New System.Drawing.Point(122, 20)
        Me.ckbTELLER.Name = "ckbTELLER"
        Me.ckbTELLER.Size = New System.Drawing.Size(105, 25)
        Me.ckbTELLER.TabIndex = 1
        Me.ckbTELLER.Tag = "TELLER"
        Me.ckbTELLER.Text = "ckbTELLER"
        '
        'DataTable6
        '
        Me.DataTable6.Namespace = ""
        Me.DataTable6.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'DataTable11
        '
        Me.DataTable11.Namespace = ""
        Me.DataTable11.TableName = "COMBOBOX"
        '
        'DataTable37
        '
        Me.DataTable37.Namespace = ""
        Me.DataTable37.TableName = "COMBOBOX"
        '
        'DataTable38
        '
        Me.DataTable38.Namespace = ""
        Me.DataTable38.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'frmTLPROFILES
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(660, 469)
        Me.Controls.Add(Me.grbTLTYPE)
        Me.Controls.Add(Me.grbASSIGN)
        Me.Controls.Add(Me.grbUSERINFO)
        Me.Name = "frmTLPROFILES"
        Me.Tag = "TLPROFILES"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.grbUSERINFO, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grbASSIGN, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grbTLTYPE, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbUSERINFO.ResumeLayout(False)
        Me.grbUSERINFO.PerformLayout()
        Me.grbASSIGN.ResumeLayout(False)
        Me.grbTLTYPE.ResumeLayout(False)
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_strTlId As String

    Private mv_strUserRight As String
    Private mv_blnSaved As Boolean = False
#End Region

#Region " Properties "
    Public Property TlId() As String
        Get
            Return mv_strTlId
        End Get
        Set(ByVal Value As String)
            mv_strTlId = Value
        End Set
    End Property
#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            MyBase.OnInit()
            FillBranch()
            FillTlType()
            CheckAccessRight()

            LoadUserInterface(Me)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub CheckAccessRight()
        Try
            If (ExeFlag = ExecuteFlag.Edit) Or (ExeFlag = ExecuteFlag.AddNew) Then
                If BranchId <> HO_BRID Then
                    MsgBox(ResourceManager.GetString("NotRight"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    OnClose()
                End If

                'If cboBRID.SelectedValue Is Nothing Then
                '    MsgBox(ResourceManager.GetString("NotRight"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                '    OnClose()
                'ElseIf CStr(cboBRID.SelectedValue).Trim <> BranchId Then
                '    If BranchId <> HO_BRID Then
                '        MsgBox(ResourceManager.GetString("NotRight"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                '        OnClose()
                '    End If
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub OnSaves(ByVal sender As Object)
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            'MyBase.OnSave()
            'If Not DoDataExchange(True) Then
            '    Exit Sub
            'End If

            'Verify data
            If (VerifyRule() = False) Then
                Exit Sub
            End If

            Dim v_strTlProfiles As String
            v_strTlProfiles = GetTLProfileStr()

            OnSave()

            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    If Not DoDataExchange(True) Then Exit Sub 'Get data from the screen to record set
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strTlProfiles, "AddNewUser")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)


                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    If sender Is btnOK Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    ElseIf sender Is btnApply Then
                        ExeFlag = ExecuteFlag.Edit
                        txtTLID.Enabled = False
                        If BranchId = HO_BRID Then
                            grbASSIGN.Enabled = True
                        End If
                    End If

                Case ExecuteFlag.Edit
                    If Not DoDataExchange(True) Then Exit Sub 'Get data from the screen to record set
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strTlProfiles, "EditUser")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    If sender Is btnOK Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    ElseIf sender Is btnApply Then
                        If BranchId = HO_BRID Then
                            grbASSIGN.Enabled = True
                        End If
                        'Hien thi phan quyen neu user active
                        If cboACTIVE.SelectedValue = "Y" Then
                            btnRightAssign.Enabled = True
                            btnGroups.Enabled = True
                        Else
                            btnRightAssign.Enabled = False
                            btnGroups.Enabled = False
                        End If
                    End If

            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        'Load caption of checkboxs
        ckbTELLER.Text = ResourceManager.GetString("TELLER")
        ckbCASHIER.Text = ResourceManager.GetString("CASHIER")
        ckbOFFICER.Text = ResourceManager.GetString("OFFICER")
        ckbCHECKER.Text = ResourceManager.GetString("CHECKER")
        ckbVIEWER.Text = ResourceManager.GetString("VIEWER")

        '�Ẩn text box TLLEV và PIN
        txtTLLEV.Enabled = False
        ' Ducnv rao lai
        'txtPIN.Enabled = False
        txtTLID.Enabled = False

        'Allow rights asignment on Head Office only
        If BranchId <> HO_BRID Then
            grbTLTYPE.Enabled = False
            grbASSIGN.Enabled = False
        End If
        'Chỉ cho phép phân quy?n khi �đã tồn tại NSD và đc phép sửa thông tin
        If (ExeFlag = ExecuteFlag.View) Then
            btnApply.Enabled = False
            grbASSIGN.Enabled = True
            ckbTELLER.Enabled = False
            ckbCASHIER.Enabled = False
            ckbOFFICER.Enabled = False
            ckbCHECKER.Enabled = False
            ckbVIEWER.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.AddNew) Then
            txtTLID.Text = CStr(GetTellerId()).Trim
            grbASSIGN.Enabled = False
            ckbTELLER.Enabled = True
            ckbCASHIER.Enabled = True
            ckbOFFICER.Enabled = True
            ckbCHECKER.Enabled = True
            ckbVIEWER.Enabled = True
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            If Trim(txtTLID.Text) = Trim(TellerId) Then
                grbASSIGN.Enabled = False
                grbTLTYPE.Enabled = False
            Else
                grbASSIGN.Enabled = True
                ckbTELLER.Enabled = True
                ckbCASHIER.Enabled = True
                ckbOFFICER.Enabled = True
                ckbCHECKER.Enabled = True
                ckbVIEWER.Enabled = True
            End If
            'An nut phan quyen neu user not active
            If cboACTIVE.SelectedValue = "Y" Then
                btnRightAssign.Enabled = True
                btnGroups.Enabled = True
            Else
                btnRightAssign.Enabled = False
                btnGroups.Enabled = False
            End If
        End If
        'An nut phan quyen cu
        btnFuncAssign.Visible = False
        btnRptAssign.Visible = False
        btnTransAssign.Visible = False
    End Sub

    'Fill data to combobox BRID 
    Private Sub FillBranch()
        Try
            Dim v_strSQL, v_strObjMsg As String
            'If ExeFlag = ExecuteFlag.AddNew Then
            'v_strSQL = "SELECT BRID VALUE, BRNAME DISPLAY FROM BRGRP WHERE STATUS = 'A' ORDER BY BRNAME"
            v_strSQL = "SELECT BRID VALUE, BRNAME DISPLAY FROM BRGRP ORDER BY BRNAME"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            Dim v_strFLDNAME, v_strValue As String
            Dim v_arrBranch(v_nodeList.Count - 1), v_arrBranchName(v_nodeList.Count - 1) As String

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "VALUE"
                            v_arrBranch(i) = Trim(v_strValue)
                        Case "DISPLAY"
                            v_arrBranchName(i) = Trim(v_strValue)
                    End Select
                Next
                'Add to cboBRID
                cboBRID.AddItems(v_arrBranchName(i), v_arrBranch(i))
            Next


            If ExeFlag <> ExecuteFlag.AddNew Then
                Dim v_strTlId, v_strBrid As String
                If KeyFieldValue <> String.Empty Then
                    v_strTlId = KeyFieldValue
                    v_strSQL = "SELECT BRID FROM TLPROFILES WHERE TLID = '" & v_strTlId & "'"
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)

                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count = 1 Then
                        With v_nodeList.Item(0).ChildNodes(0)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "BRID"
                                v_strBrid = Trim(v_strValue)
                        End Select
                    End If
                    cboBRID.SelectedValue = v_strBrid
                End If
            End If
            'Else


            'End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillTlType()
        Try
            Dim v_strTlId As String
            If KeyFieldValue <> String.Empty Then
                v_strTlId = KeyFieldValue
                Dim v_strSQL, v_strObjMsg As String
                v_strSQL = "SELECT TLTYPE FROM TLPROFILES WHERE TLID = '" & v_strTlId & "'"
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_ws.Message(v_strObjMsg)

                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                Dim v_strFLDNAME, v_strValue, v_strTlType As String
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "TLTYPE"
                                mv_strUserRight = Trim(v_strValue)
                        End Select
                    Next
                Next

                If mv_strUserRight <> String.Empty Then
                    Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker, v_strViewer As String
                    v_strTeller = Mid(mv_strUserRight, 1, 1)
                    v_strCashier = Mid(mv_strUserRight, 2, 1)
                    v_strOfficer = Mid(mv_strUserRight, 3, 1)
                    v_strChecker = Mid(mv_strUserRight, 4, 1)
                    v_strViewer = Mid(mv_strUserRight, 5, 1)

                    'Map to checkboxs
                    ckbTELLER.Checked = (v_strTeller = "Y")
                    ckbCASHIER.Checked = (v_strCashier = "Y")
                    ckbOFFICER.Checked = (v_strOfficer = "Y")
                    ckbCHECKER.Checked = (v_strChecker = "Y")
                    ckbVIEWER.Checked = (v_strViewer = "Y")
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetTLProfileStr()
        Try
            Dim v_strTLTypeStr, v_strTLProfile As String
            Dim v_strViewer, v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            Dim v_strHomeorder, v_strTlid, v_strBrid, v_strTlgroup, v_strTlname, v_strTlpassword, v_strFullname, v_strTltitle, v_strTltitle1, v_strTltitlenb, v_strTltitle1EN, v_strEmail, v_strIdcode, v_strTlprn, v_strTldescription, v_strTllev, v_strActive, v_strIsParCert As String

            'Get TLType string
            v_strTLTypeStr = String.Empty
            If ckbTELLER.Checked Then
                v_strTeller = "Y"
            Else
                v_strTeller = "N"
            End If
            If ckbCASHIER.Checked Then
                v_strCashier = "Y"
            Else
                v_strCashier = "N"
            End If
            If ckbOFFICER.Checked Then
                v_strOfficer = "Y"
            Else
                v_strOfficer = "N"
            End If
            If ckbCHECKER.Checked Then
                v_strChecker = "Y"
            Else
                v_strChecker = "N"
            End If
            If ckbVIEWER.Checked Then
                v_strViewer = "Y"
            Else
                v_strViewer = "N"
            End If
            v_strTLTypeStr = v_strTeller & v_strCashier & v_strOfficer & v_strChecker & v_strViewer
            mv_strUserRight = v_strTLTypeStr

            'Get TLProfile string
            v_strTlid = CStr(txtTLID.Text).Trim
            v_strBrid = CStr(cboBRID.SelectedValue).Trim
            v_strTlgroup = CStr(cboTLGROUP.SelectedValue).Trim
            v_strTlname = CStr(txtTLNAME.Text).Trim
            v_strFullname = CStr(txtTLFULLNAME.Text).Trim
            v_strTltitle = CStr(txtTLTITLE.Text).Trim
            v_strTltitle1 = CStr(txtTLTITLE1.Text).Trim
            v_strTltitlenb = CStr(txtTLTITLENB.Text).Trim
            v_strTltitle1EN = CStr(txtTLTITLE1EN.Text).Trim
            v_strEmail = CStr(txtEMAIL.Text).Trim
            v_strIdcode = CStr(txtIDCODE.Text).Trim 'Kieu quyet them
            v_strTlprn = CStr(txtTLPRN.Text).Trim
            v_strTldescription = CStr(txtDESCRIPTION.Text).Trim
            v_strTlpassword = CStr(txtPIN.Text).Trim
            v_strTllev = CStr(txtTLLEV.Text).Trim
            v_strActive = CStr(cboACTIVE.SelectedValue).Trim
            v_strHomeorder = CStr(cboHOMEORDER.SelectedValue).Trim
            v_strIsParCert = CStr(cboISPARCERT.SelectedValue).Trim
            v_strTLProfile = v_strTlid & "|" & v_strBrid & "|" & v_strTlgroup & "|" & v_strTlname & "|" & v_strFullname & "|" & v_strTltitle & "|"
            v_strTLProfile &= v_strTlprn & "|" & v_strTldescription & "|" & v_strTlpassword & "|" & v_strTllev & "|" & v_strTLTypeStr & "|" & v_strActive & "|" & v_strIdcode & "|" & v_strHomeorder & "|" & v_strIsParCert & "|" & v_strTltitle1 & "|" & v_strEmail & "|" & v_strTltitlenb & "|" & v_strTltitle1EN


            Return v_strTLProfile
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            'Check TLID
            If CStr(txtTLID.Text).Trim = String.Empty Then
                MsgBox(ResourceManager.GetString("TlidEmpty"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtTLID.Focus()
                Return False
            End If
            'Check TLNAME
            If CStr(txtTLNAME.Text).Trim = String.Empty Then
                MsgBox(ResourceManager.GetString("TlnameEmpty"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtTLNAME.Focus()
                Return False
            End If
            'Check PASSWORD
            'Ducnv bo rao
            If CStr(txtPIN.Text).Trim = String.Empty Then
                MsgBox(ResourceManager.GetString("PasswordEmpty"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtPIN.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

#Region " Private Methods "

    Private Function GetTellerId() As String
        Try

            Dim v_strSQL, v_strTellerId As String
            Dim v_strObjMsg As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , , "GetTellerId")
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_nodeList As Xml.XmlNodeList
            Dim XmlDocument As New Xml.XmlDocument
            Dim v_strFLDNAME, v_strValue As String

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "AUTOTLID"
                                v_strTellerId = CStr(v_strValue).Trim
                        End Select
                    End With
                Next
            Next

            If v_strTellerId Is String.Empty Then
                v_strTellerId = "1"
            End If
            'Ghép để thành GroupId
            v_strTellerId = Strings.Right("0000" & CStr(v_strTellerId), Len("0000"))
            Return v_strTellerId
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Form Events "

    Private Sub btnGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroups.Click
        Dim v_objGROUPUSERS As New frmGROUPUSERS
        v_objGROUPUSERS.UserLanguage = UserLanguage
        v_objGROUPUSERS.TellerId = TellerId
        v_objGROUPUSERS.BranchId = BranchId
        v_objGROUPUSERS.UserId = CStr(txtTLID.Text).Trim
        v_objGROUPUSERS.UserBRID = cboBRID.SelectedValue
        'v_objGROUPUSERS.GroupName = txtGRPNAME.Text
        v_objGROUPUSERS.ExeFlag = ExeFlag
        v_objGROUPUSERS.DisplayType = "Users"
        v_objGROUPUSERS.ShowDialog()
    End Sub


    ''---------------------------------------------------------''
    ''-- Hiển thị form phân quy?n ch�ức năng cho NSD hiện tại --''
    ''---------------------------------------------------------''
    Private Sub btnFuncAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFuncAssign.Click
        Dim v_objFuncAssign As New frmFuncAssign(UserLanguage)
        v_objFuncAssign.TellerId = TellerId
        v_objFuncAssign.UserId = txtTLID.Text
        v_objFuncAssign.UserName = txtTLNAME.Text
        v_objFuncAssign.UserLanguage = UserLanguage
        v_objFuncAssign.ExeFlag = ExeFlag
        v_objFuncAssign.AssignType = "User"
        v_objFuncAssign.ShowDialog()
    End Sub

    ''---------------------------------------------------------''
    ''-- Hiển thị form phân quy?n giao d�ịch cho NSD hiện tại --''
    ''---------------------------------------------------------''
    Private Sub btnTransAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransAssign.Click
        Dim v_objTransAssign As New frmTransAssign(UserLanguage)
        v_objTransAssign.TellerId = TellerId
        v_objTransAssign.UserId = txtTLID.Text
        v_objTransAssign.UserName = txtTLNAME.Text
        v_objTransAssign.UserLanguage = UserLanguage.Trim
        v_objTransAssign.ExeFlag = ExeFlag
        v_objTransAssign.UserRight = mv_strUserRight
        v_objTransAssign.AssignType = "User"
        v_objTransAssign.ShowDialog()
    End Sub

    ''-------------------------------------------------------''
    ''-- Hiển thị form phân quy?n b�áo cáo cho NSD hiện tại --''
    ''-------------------------------------------------------''
    Private Sub btnRptAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRptAssign.Click
        Dim v_objRptAssign As New frmRptAssign(UserLanguage)
        v_objRptAssign.TellerId = TellerId
        v_objRptAssign.UserId = txtTLID.Text
        v_objRptAssign.UserName = txtTLNAME.Text
        v_objRptAssign.UserLanguage = UserLanguage
        v_objRptAssign.ExeFlag = ExeFlag
        v_objRptAssign.AssignType = "User"
        v_objRptAssign.ShowDialog()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSaves(btnOK)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        OnSaves(btnApply)
    End Sub

    Private Sub txtTLNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTLNAME.Validating
        txtTLNAME.Text = txtTLNAME.Text.ToUpper
    End Sub

    Private Sub btnRightAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightAssign.Click
        Dim v_objRightAssign As New frmRightAssignment(UserLanguage)
        v_objRightAssign.TellerId = TellerId
        v_objRightAssign.UserId = txtTLID.Text
        v_objRightAssign.UserName = txtTLNAME.Text
        v_objRightAssign.UserLanguage = UserLanguage
        v_objRightAssign.ExeFlag = ExeFlag
        v_objRightAssign.UserRight = mv_strUserRight
        v_objRightAssign.AssignType = "User"
        v_objRightAssign.ShowDialog()
    End Sub

    Private Sub frmTLPROFILES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.btnApply.Visible = False
    End Sub
#End Region

    'Private Sub cboACTIVE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboACTIVE.SelectedIndexChanged
    '    If cboACTIVE.Items.Count > 0 Then
    '        If Not cboACTIVE.SelectedValue Is DBNull.Value Then
    '            If cboACTIVE.SelectedValue = "Y" Then
    '                btnRightAssign.Enabled = True
    '                btnGroups.Enabled = True
    '            Else
    '                btnRightAssign.Enabled = False
    '                btnGroups.Enabled = False
    '            End If
    '        End If
    '    End If
    'End Sub
End Class
