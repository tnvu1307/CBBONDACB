Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.Xml
Imports AppCore

Public Class frmGROUPUSERS
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents lstUSRNOGRP As System.Windows.Forms.ListBox
    Friend WithEvents lstUSRINGRP As System.Windows.Forms.ListBox
    Friend WithEvents btnMOVE As System.Windows.Forms.Button
    Friend WithEvents btnREMOVE As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblUSRNOGRP As System.Windows.Forms.Label
    Friend WithEvents lblUSRINGRP As System.Windows.Forms.Label
    Friend WithEvents btnREMOVEALL As System.Windows.Forms.Button
    Friend WithEvents btnMOVEALL As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grbGRPUSERS As System.Windows.Forms.GroupBox
    Friend WithEvents cboGROUP As ComboBoxEx
    Friend WithEvents lblGROUP As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents grbGRPINFO As System.Windows.Forms.GroupBox
    Friend WithEvents lblGRPTYPE As System.Windows.Forms.Label
    Friend WithEvents lblBRANCH As System.Windows.Forms.Label
    Friend WithEvents cboBRANCH As AppCore.ComboBoxEx
    Friend WithEvents lblTLGROUP As System.Windows.Forms.Label
    Friend WithEvents cboTLGROUP As AppCore.ComboBoxEx
    Friend WithEvents cboGRPTYPE As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGROUPUSERS))
        Me.lstUSRNOGRP = New System.Windows.Forms.ListBox
        Me.lstUSRINGRP = New System.Windows.Forms.ListBox
        Me.btnMOVE = New System.Windows.Forms.Button
        Me.btnREMOVE = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.lblUSRNOGRP = New System.Windows.Forms.Label
        Me.lblUSRINGRP = New System.Windows.Forms.Label
        Me.btnREMOVEALL = New System.Windows.Forms.Button
        Me.btnMOVEALL = New System.Windows.Forms.Button
        Me.grbGRPUSERS = New System.Windows.Forms.GroupBox
        Me.lblTLGROUP = New System.Windows.Forms.Label
        Me.cboTLGROUP = New AppCore.ComboBoxEx
        Me.cboGROUP = New AppCore.ComboBoxEx
        Me.lblGROUP = New System.Windows.Forms.Label
        Me.btnApply = New System.Windows.Forms.Button
        Me.grbGRPINFO = New System.Windows.Forms.GroupBox
        Me.lblBRANCH = New System.Windows.Forms.Label
        Me.cboBRANCH = New AppCore.ComboBoxEx
        Me.lblGRPTYPE = New System.Windows.Forms.Label
        Me.cboGRPTYPE = New AppCore.ComboBoxEx
        Me.Panel1.SuspendLayout()
        Me.grbGRPUSERS.SuspendLayout()
        Me.grbGRPINFO.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstUSRNOGRP
        '
        Me.lstUSRNOGRP.Location = New System.Drawing.Point(10, 50)
        Me.lstUSRNOGRP.Name = "lstUSRNOGRP"
        Me.lstUSRNOGRP.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstUSRNOGRP.Size = New System.Drawing.Size(330, 342)
        Me.lstUSRNOGRP.TabIndex = 0
        Me.lstUSRNOGRP.Tag = "USRNOGRP"
        '
        'lstUSRINGRP
        '
        Me.lstUSRINGRP.Location = New System.Drawing.Point(449, 37)
        Me.lstUSRINGRP.Name = "lstUSRINGRP"
        Me.lstUSRINGRP.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstUSRINGRP.Size = New System.Drawing.Size(330, 355)
        Me.lstUSRINGRP.TabIndex = 1
        Me.lstUSRINGRP.Tag = "USRINGRP"
        '
        'btnMOVE
        '
        Me.btnMOVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMOVE.Location = New System.Drawing.Point(359, 178)
        Me.btnMOVE.Name = "btnMOVE"
        Me.btnMOVE.Size = New System.Drawing.Size(70, 23)
        Me.btnMOVE.TabIndex = 3
        Me.btnMOVE.Tag = "btnMOVE"
        Me.btnMOVE.Text = "4"
        Me.btnMOVE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnREMOVE
        '
        Me.btnREMOVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnREMOVE.Location = New System.Drawing.Point(359, 213)
        Me.btnREMOVE.Name = "btnREMOVE"
        Me.btnREMOVE.Size = New System.Drawing.Size(70, 23)
        Me.btnREMOVE.TabIndex = 4
        Me.btnREMOVE.Tag = "btnREMOVE"
        Me.btnREMOVE.Text = "3"
        Me.btnREMOVE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(555, 546)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(635, 546)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 50)
        Me.Panel1.TabIndex = 7
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
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUSRNOGRP
        '
        Me.lblUSRNOGRP.AutoSize = True
        Me.lblUSRNOGRP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSRNOGRP.Location = New System.Drawing.Point(10, 45)
        Me.lblUSRNOGRP.Name = "lblUSRNOGRP"
        Me.lblUSRNOGRP.Size = New System.Drawing.Size(72, 13)
        Me.lblUSRNOGRP.TabIndex = 8
        Me.lblUSRNOGRP.Tag = "USRNOGRP"
        Me.lblUSRNOGRP.Text = "lblUSRNOGRP"
        Me.lblUSRNOGRP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUSRNOGRP.Visible = False
        '
        'lblUSRINGRP
        '
        Me.lblUSRINGRP.AutoSize = True
        Me.lblUSRINGRP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSRINGRP.Location = New System.Drawing.Point(446, 20)
        Me.lblUSRINGRP.Name = "lblUSRINGRP"
        Me.lblUSRINGRP.Size = New System.Drawing.Size(68, 13)
        Me.lblUSRINGRP.TabIndex = 9
        Me.lblUSRINGRP.Tag = "USRINGRP"
        Me.lblUSRINGRP.Text = "lblUSRINGRP"
        Me.lblUSRINGRP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnREMOVEALL
        '
        Me.btnREMOVEALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnREMOVEALL.Location = New System.Drawing.Point(359, 248)
        Me.btnREMOVEALL.Name = "btnREMOVEALL"
        Me.btnREMOVEALL.Size = New System.Drawing.Size(70, 23)
        Me.btnREMOVEALL.TabIndex = 5
        Me.btnREMOVEALL.Tag = "btnREMOVEALL"
        Me.btnREMOVEALL.Text = "7"
        Me.btnREMOVEALL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnMOVEALL
        '
        Me.btnMOVEALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMOVEALL.Location = New System.Drawing.Point(359, 143)
        Me.btnMOVEALL.Name = "btnMOVEALL"
        Me.btnMOVEALL.Size = New System.Drawing.Size(70, 23)
        Me.btnMOVEALL.TabIndex = 2
        Me.btnMOVEALL.Tag = "btnMOVEALL"
        Me.btnMOVEALL.Text = ">>"
        Me.btnMOVEALL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'grbGRPUSERS
        '
        Me.grbGRPUSERS.Controls.Add(Me.lblTLGROUP)
        Me.grbGRPUSERS.Controls.Add(Me.cboTLGROUP)
        Me.grbGRPUSERS.Controls.Add(Me.btnMOVE)
        Me.grbGRPUSERS.Controls.Add(Me.btnREMOVE)
        Me.grbGRPUSERS.Controls.Add(Me.lstUSRNOGRP)
        Me.grbGRPUSERS.Controls.Add(Me.lblUSRINGRP)
        Me.grbGRPUSERS.Controls.Add(Me.lblUSRNOGRP)
        Me.grbGRPUSERS.Controls.Add(Me.btnREMOVEALL)
        Me.grbGRPUSERS.Controls.Add(Me.btnMOVEALL)
        Me.grbGRPUSERS.Controls.Add(Me.lstUSRINGRP)
        Me.grbGRPUSERS.Location = New System.Drawing.Point(5, 142)
        Me.grbGRPUSERS.Name = "grbGRPUSERS"
        Me.grbGRPUSERS.Size = New System.Drawing.Size(785, 398)
        Me.grbGRPUSERS.TabIndex = 11
        Me.grbGRPUSERS.TabStop = False
        Me.grbGRPUSERS.Tag = "GRPUSERS"
        Me.grbGRPUSERS.Text = "grbGRPUSERS"
        '
        'lblTLGROUP
        '
        Me.lblTLGROUP.AutoSize = True
        Me.lblTLGROUP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTLGROUP.Location = New System.Drawing.Point(7, 23)
        Me.lblTLGROUP.Name = "lblTLGROUP"
        Me.lblTLGROUP.Size = New System.Drawing.Size(63, 13)
        Me.lblTLGROUP.TabIndex = 17
        Me.lblTLGROUP.Tag = "lblTLGROUP"
        Me.lblTLGROUP.Text = "lblTLGROUP"
        Me.lblTLGROUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTLGROUP
        '
        Me.cboTLGROUP.DisplayMember = "DISPLAY"
        Me.cboTLGROUP.Location = New System.Drawing.Point(89, 20)
        Me.cboTLGROUP.Name = "cboTLGROUP"
        Me.cboTLGROUP.Size = New System.Drawing.Size(150, 21)
        Me.cboTLGROUP.TabIndex = 16
        Me.cboTLGROUP.Tag = "TLGROUP"
        Me.cboTLGROUP.ValueMember = "VALUE"
        '
        'cboGROUP
        '
        Me.cboGROUP.DisplayMember = "DISPLAY"
        Me.cboGROUP.Location = New System.Drawing.Point(359, 47)
        Me.cboGROUP.Name = "cboGROUP"
        Me.cboGROUP.Size = New System.Drawing.Size(420, 21)
        Me.cboGROUP.TabIndex = 2
        Me.cboGROUP.Tag = "GROUP"
        Me.cboGROUP.ValueMember = "VALUE"
        '
        'lblGROUP
        '
        Me.lblGROUP.AutoSize = True
        Me.lblGROUP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGROUP.Location = New System.Drawing.Point(245, 50)
        Me.lblGROUP.Name = "lblGROUP"
        Me.lblGROUP.Size = New System.Drawing.Size(52, 13)
        Me.lblGROUP.TabIndex = 13
        Me.lblGROUP.Tag = "GROUP"
        Me.lblGROUP.Text = "lblGROUP"
        Me.lblGROUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(715, 546)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 14
        Me.btnApply.Tag = "btnApply"
        Me.btnApply.Text = "btnApply"
        '
        'grbGRPINFO
        '
        Me.grbGRPINFO.Controls.Add(Me.lblBRANCH)
        Me.grbGRPINFO.Controls.Add(Me.cboBRANCH)
        Me.grbGRPINFO.Controls.Add(Me.lblGRPTYPE)
        Me.grbGRPINFO.Controls.Add(Me.cboGRPTYPE)
        Me.grbGRPINFO.Controls.Add(Me.lblGROUP)
        Me.grbGRPINFO.Controls.Add(Me.cboGROUP)
        Me.grbGRPINFO.Location = New System.Drawing.Point(5, 55)
        Me.grbGRPINFO.Name = "grbGRPINFO"
        Me.grbGRPINFO.Size = New System.Drawing.Size(785, 81)
        Me.grbGRPINFO.TabIndex = 15
        Me.grbGRPINFO.TabStop = False
        Me.grbGRPINFO.Tag = "GRPINFO"
        Me.grbGRPINFO.Text = "grbGRPINFO"
        '
        'lblBRANCH
        '
        Me.lblBRANCH.AutoSize = True
        Me.lblBRANCH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBRANCH.Location = New System.Drawing.Point(7, 20)
        Me.lblBRANCH.Name = "lblBRANCH"
        Me.lblBRANCH.Size = New System.Drawing.Size(58, 13)
        Me.lblBRANCH.TabIndex = 17
        Me.lblBRANCH.Tag = "BRANCH"
        Me.lblBRANCH.Text = "lblBRANCH"
        Me.lblBRANCH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBRANCH
        '
        Me.cboBRANCH.DisplayMember = "DISPLAY"
        Me.cboBRANCH.Location = New System.Drawing.Point(89, 17)
        Me.cboBRANCH.Name = "cboBRANCH"
        Me.cboBRANCH.Size = New System.Drawing.Size(690, 21)
        Me.cboBRANCH.TabIndex = 0
        Me.cboBRANCH.Tag = "BRANCH"
        Me.cboBRANCH.ValueMember = "VALUE"
        '
        'lblGRPTYPE
        '
        Me.lblGRPTYPE.AutoSize = True
        Me.lblGRPTYPE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGRPTYPE.Location = New System.Drawing.Point(7, 50)
        Me.lblGRPTYPE.Name = "lblGRPTYPE"
        Me.lblGRPTYPE.Size = New System.Drawing.Size(61, 13)
        Me.lblGRPTYPE.TabIndex = 15
        Me.lblGRPTYPE.Tag = "GRPTYPE"
        Me.lblGRPTYPE.Text = "lblGRPTYPE"
        Me.lblGRPTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGRPTYPE
        '
        Me.cboGRPTYPE.DisplayMember = "DISPLAY"
        Me.cboGRPTYPE.Location = New System.Drawing.Point(89, 47)
        Me.cboGRPTYPE.Name = "cboGRPTYPE"
        Me.cboGRPTYPE.Size = New System.Drawing.Size(150, 21)
        Me.cboGRPTYPE.TabIndex = 1
        Me.cboGRPTYPE.Tag = "GRPTYPE"
        Me.cboGRPTYPE.ValueMember = "VALUE"
        '
        'frmGROUPUSERS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.grbGRPINFO)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.grbGRPUSERS)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGROUPUSERS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "GROUPUSERS"
        Me.Text = "frmGROUPUSERS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbGRPUSERS.ResumeLayout(False)
        Me.grbGRPUSERS.PerformLayout()
        Me.grbGRPINFO.ResumeLayout(False)
        Me.grbGRPINFO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables"
    Private Const Apply As Integer = 1
    Private Const OK As Integer = 2
    Const mc_strAdmin = "Admin"

    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strTellerId As String
    Private mv_strGroupId As String
    Private mv_strBranchId As String
    Private mv_strGroupName As String
    Private mv_strDisplayType As String
    Private mv_strUserId As String
    Private mv_strUserBRId As String
    Private mv_strGroupType As String
    Private mv_intExecFlag As Integer
    Private mv_arrGroupId() As String
    Private mv_arrGroupType() As String

    Private mv_blnIsLoadData As Boolean = False

    'Khai báo các bảng băm dùng chứa các thông tin NSD và nhóm
    Public hTlidOutGrpFilter As New Hashtable
    Public hTlidInGrpFilter As New Hashtable
    Public hBridInGrpFilter As New Hashtable
    Public hBridOutGrpFilter As New Hashtable
    Public hGroupsFilter As New Hashtable
    Public hGroupsTypeFilter As New Hashtable
    Public hUserFilter As New Hashtable
    Public hGrpOutUsrFilter As New Hashtable
    Public hGrpInUsrFilter As New Hashtable
    Public hGrpAvlUsrFilter As New Hashtable
    Public hTLGRPFilter As New Hashtable

#End Region

#Region " Properties"
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
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

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
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

    Public Property DisplayType() As String
        Get
            Return mv_strDisplayType
        End Get
        Set(ByVal Value As String)
            mv_strDisplayType = Value
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

    Public Property GroupType() As String
        Get
            Return mv_strGroupType
        End Get
        Set(ByVal Value As String)
            mv_strGroupType = Value
        End Set
    End Property

    Public Property UserBRID() As String
        Get
            Return mv_strUserBRId
        End Get
        Set(ByVal Value As String)
            mv_strUserBRId = Value
        End Set
    End Property

#End Region

#Region " Overridable methods"

    Public Overridable Sub OnInit()
        Try

            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & ".frmGROUPUSERS-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            'If Not FillData() Then
            '    Exit Sub
            'End If
            If Not FillCombobox() Then
                Exit Sub
            End If
            LoadUserInterface(Me)
            'Lay thong tin nhom
            If DisplayType = "Users" Then
                GetUserGroupsInfo(UserId)
                lblTLGROUP.Visible = False
                cboTLGROUP.Visible = False
            Else
                GetUserGroupsInfo("")
                lblTLGROUP.Visible = True
                cboTLGROUP.Visible = True
            End If
            'Fill list
            ComboBoxValueChange()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        'Public Function LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control) As Boolean
        Dim v_ctrl As Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmGROUPUSERS." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    If Trim(DisplayType) = "Users" Then
                        CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmGROUPUSERS_USR." & v_ctrl.Name)
                    Else
                        CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmGROUPUSERS." & v_ctrl.Name)
                    End If
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmGROUPUSERS." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmGROUPUSERS." & v_ctrl.Name)
                End If
            Next

            Dim v_strGroupName As String
            If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) Then
                v_strGroupName = cboGROUP.SelectedText
            End If

            'Load caption của form, label caption
            If Trim(DisplayType) = "Users" Then
                Me.Text = mv_ResourceManager.GetString("frmGROUPUSERS_USR")
                lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS_USR.lblCaption") & v_strGroupName
            Else
                Me.Text = mv_ResourceManager.GetString("frmGROUPUSERS")
                lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS.lblCaption") & v_strGroupName
            End If

            'lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS.lblCaption") & GroupName

            'Hide control if in view mode
            'If (ExeFlag = ExecuteFlag.View) Or (DisplayType = "Users") Then
            If (ExeFlag = ExecuteFlag.View) Then
                btnOK.Enabled = False
                btnApply.Enabled = False
                btnMOVE.Enabled = False
                btnMOVEALL.Enabled = False
                btnREMOVE.Enabled = False
                btnREMOVEALL.Enabled = False
                'If Not hGroupsFilter(GroupId) Is Nothing Then
                '    cboGROUP.SelectedValue = GroupId
                '    ComboBoxValueChange()
                '    cboGROUP.Enabled = False
                'Else
                '    MsgBox(mv_ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                '    Return False
                'End If
                cboGROUP.Enabled = False
                cboGRPTYPE.Enabled = True
            End If
            If DisplayType = "Users" Then
                cboGROUP.Enabled = False
            End If
            If DisplayType = "Groups" Then
                cboGROUP.Enabled = False
                cboGRPTYPE.Enabled = False
            End If

            'Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function FillData() As Boolean
        Try
            Dim v_strFLDNAME, v_strValue As String
            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Fill Branch
            v_strSQL = "SELECT BRID VALUE, BRNAME DISPLAY, BRNAME EN_DISPLAY, 0 LSTODR FROM BRGRP WHERE STATUS = 'A' ORDER BY BRID"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboBRANCH, "", Me.UserLanguage)
            If cboBRANCH.Items.Count > 0 Then
                If BranchId = HO_BRID Then
                    cboBRANCH.SelectedValue = BranchId
                Else
                    cboBRANCH.SelectedValue = BranchId
                    cboBRANCH.Enabled = False
                End If
            End If

            If Trim(DisplayType) = "Users" Then
                cboBRANCH.Enabled = False
            End If
            'Select and fill groups type
            If Trim(DisplayType) = "Users" Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            ElseIf Trim(DisplayType) = "Groups" Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' AND CDVAL = '" & GroupType & "'"
            Else
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            End If


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionInquiry, v_strSQL)

            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrGroupType(v_nodeList.Count - 1)
            Dim v_arrGroupTypeName(v_nodeList.Count - 1) As String

            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                mv_arrGroupType(i) = Trim(v_strValue)
                            Case "DISPLAY", "EN_DISPLAY"
                                If Me.UserLanguage = "EN" And Trim(v_strFLDNAME) = "EN_DISPLAY" Then
                                    v_arrGroupTypeName(i) = Trim(v_strValue)
                                ElseIf Me.UserLanguage = "VN" And Trim(v_strFLDNAME) = "DISPLAY" Then
                                    v_arrGroupTypeName(i) = Trim(v_strValue)
                                End If
                        End Select
                    Next
                    'Add to hash table
                    hGroupsTypeFilter.Add(mv_arrGroupType(i), v_arrGroupTypeName(i))
                    'Add item to combobox
                    cboGRPTYPE.AddItems(v_arrGroupTypeName(i), mv_arrGroupType(i))
                    'GetUsrGrpInfo(mv_arrGroupId(i))
                Next
                ComboBoxGRPTYPEValueChange()
                Return True
            Else
                MsgBox(mv_ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FillCombobox() As Boolean
        Try
            Dim v_strFLDNAME, v_strValue As String
            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Fill Branch
            'v_strSQL = "SELECT BRID VALUE, BRNAME DISPLAY, BRNAME EN_DISPLAY, 0 LSTODR FROM BRGRP WHERE STATUS = 'A' ORDER BY BRID"
            v_strSQL = "SELECT BRID VALUE, BRNAME DISPLAY, BRNAME EN_DISPLAY, 0 LSTODR FROM BRGRP WHERE 0=0 ORDER BY BRID"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboBRANCH, "", Me.UserLanguage)
            If cboBRANCH.Items.Count > 0 Then
                If BranchId = HO_BRID Then
                    cboBRANCH.SelectedValue = BranchId
                Else
                    cboBRANCH.SelectedValue = BranchId
                    cboBRANCH.Enabled = False
                End If
            End If

            If Trim(DisplayType) = "Users" Then
                cboBRANCH.SelectedValue = UserBRID
                cboBRANCH.Enabled = False
            End If

            'Select and fill groups type
            If Trim(DisplayType) = "Users" Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            ElseIf Trim(DisplayType) = "Groups" Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' AND CDVAL = '" & GroupType & "'"
            Else
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            End If
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGRPTYPE, "", Me.UserLanguage)

            'Fill group
            If DisplayType = "Users" Then
                v_strSQL = "SELECT TLID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN TLNAME || ' - ' || DESCRIPTION ELSE TLNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN TLNAME || ' - ' || DESCRIPTION ELSE TLNAME END EN_DISPLAY, 0 LSTODR FROM TLPROFILES" _
                        & " WHERE TLID = '" & UserId & "' AND ACTIVE = 'Y'"
            ElseIf DisplayType = "Groups" Then
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            Else
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                        & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)
            'Store group infor


            v_strSQL = "SELECT '<ALL>' VALUE, '<ALL>' DISPLAY, '<ALL>' EN_DISPLAY, -1 LSTODR FROM DUAL UNION ALL " _
                        & "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'TLGROUP' ORDER BY LSTODR"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboTLGROUP, "", Me.UserLanguage)

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Private Sub ComboBoxValueChange()
        Dim v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
        Dim v_strTLNAME, v_strValue As String
        Dim v_strFLDNAME As String
        Dim v_strFieldType As String
        Dim v_strCmdInquiryUsrOutGrp, v_strCmdInquiryUsrInGrp As String

        Try
            Dim v_strGroupId, v_strGroupName As String
            Dim v_arrUsrInGrp(), v_arrUsrOutGrp(), v_arrTLGrp() As String
            Dim v_arrUsrInfo() As String
            Dim v_strHashKey, v_strHashValue As String

            lstUSRNOGRP.Items.Clear()
            lstUSRINGRP.Items.Clear()
            If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) _
               And (Not cboBRANCH.SelectedValue Is Nothing) And (Not cboBRANCH.SelectedValue Is DBNull.Value) _
               And (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) _
               And mv_blnIsLoadData Then
                If Trim(DisplayType) = "Users" Then
                    v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
                    v_strGroupName = cboGROUP.Text
                    v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
                    'Insert users that are not in group to list box
                    If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                        v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")
                        For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
                            v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
                            lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
                        Next
                    End If
                    'Insert users that are in group to list box
                    If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                        v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
                        For i As Integer = 1 To v_arrUsrInGrp.Length - 2
                            v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
                            lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
                        Next
                    End If
                    'Display caption
                    lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS_USR.lblCaption") & v_strGroupName
                Else
                    v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
                    v_strGroupName = cboGROUP.Text
                    v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
                    'Insert users that are not in group to list box
                    If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                        v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")

                        For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
                            v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
                            'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
                            'v_arrTLGrp = CStr(hTLGRPFilter()).Split("#")

                            If IsNumeric(cboTLGROUP.SelectedValue) = False Then
                                lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
                            Else
                                If Not hTLGRPFilter(cboBRANCH.SelectedValue & "|" & cboTLGROUP.SelectedValue & "|" & v_arrUsrInfo(1)) Is Nothing Then
                                    lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
                                End If
                            End If

                            'lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))

                            'End If
                        Next
                    End If
                    'Insert users that are in group to list box
                    If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                        v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
                        For i As Integer = 1 To v_arrUsrInGrp.Length - 2
                            v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
                            'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
                            lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
                            'End If
                        Next
                    End If
                    'Display caption
                    lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS.lblCaption") & v_strGroupName
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetUsrGrpInfo(ByVal pv_strGroupId As String)
        Try
            Dim v_strFLDNAME, v_strValue, v_strHashValue, v_strHashKey, v_strGroupType As String
            Dim v_strSQL, v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
            Dim v_strBranchID As String

            'Get informations about users in and not in groups
            If (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) Then
                v_strGroupType = CStr(cboGRPTYPE.SelectedValue).Trim

                'Select users' name that are not in group
                If DisplayType = "Users" Then
                    v_strSQL = "SELECT M.GRPID VALUE, M.GRPNAME DISPLAY " _
                                                        & " FROM TLGROUPS M " _
                                                        & " WHERE M.GRPID NOT IN (SELECT N.GRPID FROM TLGRPUSERS N WHERE N.TLID='" & pv_strGroupId & "') " _
                                                        & " AND M.GRPTYPE = '" & v_strGroupType & "' ORDER BY M.GRPNAME "
                Else
                    'v_strSQL = "SELECT M.TLID VALUE, M.TLNAME DISPLAY " _
                    '                                    & " FROM TLPROFILES M WHERE M.BRID = CASE WHEN '" & BranchId & "' = '" & HO_BRID & "' THEN M.BRID ELSE '" & BranchId & "' END  " _
                    '                                    & " AND M.TLID NOT IN (SELECT N.TLID FROM TLGRPUSERS N WHERE N.GRPID='" & pv_strGroupId & "') " _
                    '                                    & " ORDER BY M.TLNAME "
                    v_strSQL = "SELECT M.TLID VALUE, M.TLNAME DISPLAY " _
                            & " FROM TLPROFILES M WHERE M.BRID = '" & cboBRANCH.SelectedValue & "' " _
                            & " AND M.TLID NOT IN (SELECT N.TLID FROM TLGRPUSERS N WHERE N.GRPID='" & pv_strGroupId & "') " _
                            & " ORDER BY M.TLNAME "
                End If

                v_strUsrOutGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                Dim v_wsOutGrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_wsOutGrp.Message(v_strUsrOutGrpObjMsg)
                Dim v_xmlOutGrpDocument As New Xml.XmlDocument
                Dim v_nodeOutGrpList As Xml.XmlNodeList

                v_xmlOutGrpDocument.LoadXml(v_strUsrOutGrpObjMsg)
                v_nodeOutGrpList = v_xmlOutGrpDocument.SelectNodes("/ObjectMessage/ObjData")
                Dim v_arrOutGrpTLID(v_nodeOutGrpList.Count - 1) As String
                Dim v_arrOutGrpTLNAME(v_nodeOutGrpList.Count - 1) As String
                'Remove value in hash table
                If Not hTlidOutGrpFilter(pv_strGroupId) Is Nothing Then
                    hTlidOutGrpFilter.Remove(pv_strGroupId)
                End If
                For i As Integer = 0 To v_nodeOutGrpList.Count - 1
                    For j As Integer = 0 To v_nodeOutGrpList.Item(i).ChildNodes.Count - 1
                        With v_nodeOutGrpList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_arrOutGrpTLID(i) = v_strValue
                            Case "DISPLAY"
                                v_arrOutGrpTLNAME(i) = v_strValue
                        End Select
                    Next
                    If Not hTlidOutGrpFilter(pv_strGroupId) Is Nothing Then
                        'Remove old value before add new value in hash table
                        v_strHashValue = CStr(hTlidOutGrpFilter(pv_strGroupId))
                        'Get new value
                        v_strHashValue &= v_arrOutGrpTLNAME(i) & "|" & v_arrOutGrpTLID(i) & "#"
                        'Remove old value
                        hTlidOutGrpFilter.Remove(pv_strGroupId)
                        'Add new value
                        hTlidOutGrpFilter.Add(pv_strGroupId, v_strHashValue)
                    Else
                        'Add new value
                        v_strHashValue = pv_strGroupId & "#" & v_arrOutGrpTLNAME(i) & "|" & v_arrOutGrpTLID(i) & "#"
                        hTlidOutGrpFilter.Add(pv_strGroupId, v_strHashValue)
                    End If
                    If hUserFilter(v_arrOutGrpTLNAME(i)) Is Nothing Then
                        hUserFilter.Add(v_arrOutGrpTLNAME(i), v_arrOutGrpTLID(i))
                    End If
                    'hTlidOutGrpFilter.Add(v_arrOutGrpTLNAME(i) & "|" & pv_strGroupId, v_arrOutGrpTLID(i) & "|" & pv_strGroupId)
                    'hBridOutGrpFilter.Add(v_arrOutGrpTLNAME(i) & "|" & pv_strGroupId, v_arrOutGrpBRID(i) & "|" & pv_strGroupId)
                Next

                ''''==== Select users' name that are in group ====''''
                If DisplayType = "Users" Then
                    v_strSQL = "SELECT C.GRPID VALUE, C.GRPNAME DISPLAY " _
                                                        & "FROM TLPROFILES A, TLGRPUSERS B, TLGROUPS C " _
                                                        & "WHERE A.TLID = B.TLID AND B.GRPID = C.GRPID AND A.TLID = '" & pv_strGroupId & "' " _
                                                        & "AND C.GRPTYPE = '" & v_strGroupType & "' ORDER BY C.GRPNAME"
                Else
                    'v_strSQL = "SELECT A.TLID VALUE, A.TLNAME DISPLAY " _
                    '                                    & "FROM TLPROFILES A, TLGRPUSERS B, TLGROUPS C " _
                    '                                    & "WHERE A.TLID = B.TLID AND B.GRPID = C.GRPID AND C.GRPID = '" & pv_strGroupId & "' AND A.BRID = CASE WHEN '" & BranchId & "' = '" & HO_BRID & "' THEN A.BRID ELSE '" & BranchId & "' END " _
                    '                                    & "ORDER BY A.TLNAME"
                    v_strSQL = "SELECT A.TLID VALUE, A.TLNAME DISPLAY " _
                            & "FROM TLPROFILES A, TLGRPUSERS B, TLGROUPS C " _
                            & "WHERE A.TLID = B.TLID AND B.GRPID = C.GRPID AND C.GRPID = '" & pv_strGroupId & "' AND A.BRID = '" & cboBRANCH.SelectedValue & "' " _
                            & "ORDER BY A.TLNAME"
                End If

                v_strUsrInGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                Dim v_wsIngrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_wsIngrp.Message(v_strUsrInGrpObjMsg)
                Dim v_xmlInGrpDocument As New Xml.XmlDocument
                Dim v_nodeInGrpList As Xml.XmlNodeList

                v_xmlInGrpDocument.LoadXml(v_strUsrInGrpObjMsg)
                v_nodeInGrpList = v_xmlInGrpDocument.SelectNodes("/ObjectMessage/ObjData")
                Dim v_arrInGrpTLID(v_nodeInGrpList.Count - 1) As String
                Dim v_arrInGrpTLNAME(v_nodeInGrpList.Count - 1) As String
                'Remove value in hash table
                v_strHashKey = cboBRANCH.SelectedValue & "|" & pv_strGroupId
                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                    hTlidInGrpFilter.Remove(pv_strGroupId)
                End If
                For i As Integer = 0 To v_nodeInGrpList.Count - 1
                    For j As Integer = 0 To v_nodeInGrpList.Item(i).ChildNodes.Count - 1
                        With v_nodeInGrpList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_arrInGrpTLID(i) = v_strValue
                            Case "DISPLAY"
                                v_arrInGrpTLNAME(i) = v_strValue
                        End Select
                    Next
                    'Insert informations to hash tables
                    If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value in hash table
                        v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                        'Get new value
                        v_strHashValue &= v_arrInGrpTLNAME(i) & "|" & v_arrInGrpTLID(i) & "#"
                        'Remove old value
                        hTlidInGrpFilter.Remove(v_strHashKey)
                        'Add new value
                        hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                    Else
                        'Add new value
                        v_strHashValue = cboBRANCH.SelectedValue & "|" & pv_strGroupId & "#" & v_arrInGrpTLNAME(i) & "|" & v_arrInGrpTLID(i) & "#"
                        hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                    If hUserFilter(v_arrInGrpTLNAME(i)) Is Nothing Then
                        hUserFilter.Add(v_arrInGrpTLNAME(i), v_arrInGrpTLID(i))
                    End If
                    'hTlidInGrpFilter.Add(v_arrInGrpTLNAME(i) & "|" & pv_strGroupId, v_arrInGrpTLID(i) & "|" & pv_strGroupId)
                    'hBridInGrpFilter.Add(v_arrInGrpTLNAME(i) & "|" & pv_strGroupId, v_arrInGrpBRID(i) & "|" & pv_strGroupId)
                Next


                ComboBoxGRPValueChange()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetUserGroupsInfo(ByVal pv_strGroupId As String)
        Try
            Dim v_strFLDNAME, v_strValue, v_strHashValue, v_strHashKey, v_strGroupType As String
            Dim v_strSQL, v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
            Dim v_strBranchID As String
            Dim v_strTLID, v_strTLGROUP, v_strTLNAME, v_strBRID, v_strGRPID, v_strGRPTYPE, v_strGRPNAME As String

            'Get informations about users in and not in groups
            If (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) Then
                v_strGroupType = CStr(cboGRPTYPE.SelectedValue).Trim

                'Select users' name that are not in group
                If DisplayType = "Users" Then
                    'Lay nhom ko chua NSD
                    v_strSQL = "SELECT M.GRPID, CASE WHEN M.DESCRIPTION IS NOT NULL THEN M.GRPNAME || ' - ' || M.DESCRIPTION ELSE M.GRPNAME END GRPNAME, M.GRPTYPE " & ControlChars.CrLf _
                            & " FROM TLGROUPS M " & ControlChars.CrLf _
                            & " WHERE M.GRPID NOT IN (SELECT N.GRPID FROM TLGRPUSERS N WHERE N.TLID='" & pv_strGroupId & "') AND M.ACTIVE = 'Y' " & ControlChars.CrLf _
                            & "     AND M.grpid IN (SELECT BR.paravalue FROM brgrpparam br WHERE br.paratype = 'TLGROUPS' AND BR.deltd = 'N' AND BR.brid = '" & UserBRID & "') " & ControlChars.CrLf _
                            & " ORDER BY M.GRPNAME "

                    v_strUsrOutGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_wsOutGrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    v_wsOutGrp.Message(v_strUsrOutGrpObjMsg)
                    Dim v_xmlOutGrpDocument As New Xml.XmlDocument
                    Dim v_nodeOutGrpList As Xml.XmlNodeList


                    v_xmlOutGrpDocument.LoadXml(v_strUsrOutGrpObjMsg)
                    v_nodeOutGrpList = v_xmlOutGrpDocument.SelectNodes("/ObjectMessage/ObjData")

                    For i As Integer = 0 To v_nodeOutGrpList.Count - 1
                        For j As Integer = 0 To v_nodeOutGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeOutGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "GRPID"
                                    v_strGRPID = v_strValue
                                Case "GRPNAME"
                                    v_strGRPNAME = v_strValue
                                Case "GRPTYPE"
                                    v_strGRPTYPE = v_strValue
                            End Select
                        Next
                        v_strBRID = cboBRANCH.SelectedValue
                        v_strHashKey = v_strBRID & "|" & v_strGRPTYPE & "|" & pv_strGroupId
                        If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                            'Remove old value before add new value in hash table
                            v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                            'Get new value
                            v_strHashValue &= v_strGRPNAME & "|" & v_strGRPID & "#"
                            'Remove old value
                            hTlidOutGrpFilter.Remove(v_strHashKey)
                            'Add new value
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        Else
                            'Add new value
                            v_strHashValue = v_strHashKey & "#" & v_strGRPNAME & "|" & v_strGRPID & "#"
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        End If
                        If hUserFilter(v_strGRPNAME) Is Nothing Then
                            hUserFilter.Add(v_strGRPNAME, v_strGRPID)
                        End If
                        'hTlidOutGrpFilter.Add(v_arrOutGrpTLNAME(i) & "|" & pv_strGroupId, v_arrOutGrpTLID(i) & "|" & pv_strGroupId)
                        'hBridOutGrpFilter.Add(v_arrOutGrpTLNAME(i) & "|" & pv_strGroupId, v_arrOutGrpBRID(i) & "|" & pv_strGroupId)
                    Next

                    'Lay nhom chua NSD
                    v_strSQL = "SELECT C.GRPID, CASE WHEN C.DESCRIPTION IS NOT NULL THEN C.GRPNAME || ' - ' || C.DESCRIPTION ELSE C.GRPNAME END GRPNAME, C.GRPTYPE, B.BRID " _
                            & "FROM TLPROFILES A, TLGRPUSERS B, TLGROUPS C " _
                            & "WHERE A.TLID = B.TLID AND B.GRPID = C.GRPID AND A.TLID = '" & pv_strGroupId & "' AND A.ACTIVE = 'Y' AND C.ACTIVE = 'Y' " _
                            & "ORDER BY C.GRPNAME"

                    v_strUsrInGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_wsIngrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    v_wsIngrp.Message(v_strUsrInGrpObjMsg)
                    Dim v_xmlInGrpDocument As New Xml.XmlDocument
                    Dim v_nodeInGrpList As Xml.XmlNodeList

                    v_xmlInGrpDocument.LoadXml(v_strUsrInGrpObjMsg)
                    v_nodeInGrpList = v_xmlInGrpDocument.SelectNodes("/ObjectMessage/ObjData")

                    For i As Integer = 0 To v_nodeInGrpList.Count - 1
                        For j As Integer = 0 To v_nodeInGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeInGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "GRPID"
                                    v_strGRPID = v_strValue
                                Case "GRPNAME"
                                    v_strGRPNAME = v_strValue
                                Case "GRPTYPE"
                                    v_strGRPTYPE = v_strValue
                                Case "BRID"
                                    v_strBRID = v_strValue
                            End Select
                        Next
                        'Insert informations to hash tables
                        v_strHashKey = v_strBRID & "|" & v_strGRPTYPE & "|" & pv_strGroupId
                        If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                            'Remove old value before add new value in hash table
                            v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                            'Get new value
                            v_strHashValue &= v_strGRPNAME & "|" & v_strGRPID & "#"
                            'Remove old value
                            hTlidInGrpFilter.Remove(v_strHashKey)
                            'Add new value
                            hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                        Else
                            'Add new value
                            v_strHashValue = v_strHashKey & "#" & v_strGRPNAME & "|" & v_strGRPID & "#"
                            hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                        End If
                        If hUserFilter(v_strGRPNAME) Is Nothing Then
                            hUserFilter.Add(v_strGRPNAME, v_strGRPID)
                        End If
                    Next
                    'Lay thong tin ma user
                    ReDim mv_arrGroupId(1)
                    mv_arrGroupId(0) = pv_strGroupId

                    'Lay nhom co the gan NSD vao
                    v_strSQL = "SELECT tlg.grpid, tlg.grpname " & ControlChars.CrLf _
                            & "FROM brgrpparam br, tlgroups tlg " & ControlChars.CrLf _
                            & "WHERE br.paravalue = tlg.grpid and br.paratype = 'TLGROUPS' AND BR.deltd = 'N' AND BR.brid = '" & UserBRID & "' "

                    Dim v_strGrpObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_wsGrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    v_wsGrp.Message(v_strGrpObjMsg)
                    Dim v_xmlGrpDocument As New Xml.XmlDocument
                    Dim v_nodeGrpList As Xml.XmlNodeList

                    v_xmlGrpDocument.LoadXml(v_strGrpObjMsg)
                    v_nodeGrpList = v_xmlGrpDocument.SelectNodes("/ObjectMessage/ObjData")

                    For i As Integer = 0 To v_nodeGrpList.Count - 1
                        For j As Integer = 0 To v_nodeGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "GRPID"
                                    v_strGRPID = v_strValue
                                Case "GRPNAME"
                                    v_strGRPNAME = v_strValue
                            End Select
                        Next

                        If hGrpAvlUsrFilter(v_strGRPID) Is Nothing Then
                            'Add new value
                            hGrpAvlUsrFilter.Add(v_strGRPID, v_strGRPNAME)
                        End If
                    Next
                Else
                    'Lay khach hang chua thuoc nhom
                    v_strSQL = "SELECT M.TLID, CASE WHEN M.DESCRIPTION IS NOT NULL THEN M.TLNAME || ' - ' || M.DESCRIPTION ELSE M.TLNAME END TLNAME, M.BRID, TLG.GRPID, TLG.GRPTYPE " & ControlChars.CrLf _
                            & " FROM TLPROFILES M, TLGROUPS TLG " & ControlChars.CrLf _
                            & " WHERE NOT EXISTS(SELECT N.TLID FROM TLGRPUSERS N WHERE N.GRPID=TLG.GRPID AND M.TLID = N.TLID AND N.BRID = M.BRID and N.GRPID like '%" & GroupId & "%')" & ControlChars.CrLf _
                            & "AND M.ACTIVE = 'Y' AND TLG.ACTIVE = 'Y' AND TLG.GRPID like '%" & GroupId & "%'" & ControlChars.CrLf _
                            & " ORDER BY M.TLNAME, M.BRID, TLG.GRPID "

                    v_strUsrOutGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_wsOutGrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    v_wsOutGrp.Message(v_strUsrOutGrpObjMsg)
                    Dim v_xmlOutGrpDocument As New Xml.XmlDocument
                    Dim v_nodeOutGrpList As Xml.XmlNodeList


                    v_xmlOutGrpDocument.LoadXml(v_strUsrOutGrpObjMsg)
                    v_nodeOutGrpList = v_xmlOutGrpDocument.SelectNodes("/ObjectMessage/ObjData")
                    Dim v_arrOutGrpTLID(v_nodeOutGrpList.Count - 1) As String
                    Dim v_arrOutGrpTLNAME(v_nodeOutGrpList.Count - 1) As String

                    For i As Integer = 0 To v_nodeOutGrpList.Count - 1
                        For j As Integer = 0 To v_nodeOutGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeOutGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "TLID"
                                    v_strTLID = v_strValue
                                Case "TLNAME"
                                    v_strTLNAME = v_strValue
                                Case "BRID"
                                    v_strBRID = v_strValue
                                Case "GRPID"
                                    v_strGRPID = v_strValue
                                Case "GRPTYPE"
                                    v_strGRPTYPE = v_strValue
                            End Select
                        Next
                        v_strHashKey = v_strBRID & "|" & v_strGRPTYPE & "|" & v_strGRPID
                        If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                            'Remove old value before add new value in hash table
                            v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                            'Get new value
                            v_strHashValue &= v_strTLNAME & "|" & v_strTLID & "#"
                            'Remove old value
                            hTlidOutGrpFilter.Remove(v_strHashKey)
                            'Add new value
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        Else
                            'Add new value
                            v_strHashValue = v_strHashKey & "#" & v_strTLNAME & "|" & v_strTLID & "#"
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        End If
                        If hUserFilter(v_strTLNAME) Is Nothing Then
                            hUserFilter.Add(v_strTLNAME, v_strTLID)
                        End If
                    Next

                    'Lay khach hang thuoc nhom
                    v_strSQL = "SELECT M.TLID, CASE WHEN M.DESCRIPTION IS NOT NULL THEN M.TLNAME || ' - ' || M.DESCRIPTION ELSE M.TLNAME END TLNAME, M.BRID, TLG.GRPID, TLG.GRPTYPE " & ControlChars.CrLf _
                            & " FROM TLPROFILES M, TLGROUPS TLG " & ControlChars.CrLf _
                            & " WHERE EXISTS(SELECT N.TLID FROM TLGRPUSERS N WHERE N.GRPID=TLG.GRPID AND M.TLID = N.TLID AND N.BRID = M.BRID) AND M.ACTIVE = 'Y' AND TLG.ACTIVE = 'Y' " & ControlChars.CrLf _
                            & " ORDER BY M.TLNAME, M.BRID, TLG.GRPID "

                    v_strUsrInGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_wsIngrp As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    v_wsIngrp.Message(v_strUsrInGrpObjMsg)
                    Dim v_xmlInGrpDocument As New Xml.XmlDocument
                    Dim v_nodeInGrpList As Xml.XmlNodeList

                    v_xmlInGrpDocument.LoadXml(v_strUsrInGrpObjMsg)
                    v_nodeInGrpList = v_xmlInGrpDocument.SelectNodes("/ObjectMessage/ObjData")
                    Dim v_arrInGrpTLID(v_nodeInGrpList.Count - 1) As String
                    Dim v_arrInGrpTLNAME(v_nodeInGrpList.Count - 1) As String

                    For i As Integer = 0 To v_nodeInGrpList.Count - 1
                        For j As Integer = 0 To v_nodeInGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeInGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "TLID"
                                    v_strTLID = v_strValue
                                Case "TLNAME"
                                    v_strTLNAME = v_strValue
                                Case "BRID"
                                    v_strBRID = v_strValue
                                Case "GRPID"
                                    v_strGRPID = v_strValue
                                Case "GRPTYPE"
                                    v_strGRPTYPE = v_strValue
                            End Select
                        Next
                        'Insert informations to hash tables
                        v_strHashKey = v_strBRID & "|" & v_strGRPTYPE & "|" & v_strGRPID
                        If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                            'Remove old value before add new value in hash table
                            v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                            'Get new value
                            v_strHashValue &= v_strTLNAME & "|" & v_strTLID & "#"
                            'Remove old value
                            hTlidInGrpFilter.Remove(v_strHashKey)
                            'Add new value
                            hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                        Else
                            'Add new value
                            v_strHashValue = v_strHashKey & "#" & v_strTLNAME & "|" & v_strTLID & "#"
                            hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                        End If
                        If hUserFilter(v_strTLNAME) Is Nothing Then
                            hUserFilter.Add(v_strTLNAME, v_strTLID)
                        End If
                    Next

                    'Lay tat ca nhom
                    v_strSQL = "SELECT TLG.GRPID " _
                            & " FROM TLGROUPS TLG " _
                            & " WHERE TLG.ACTIVE = 'Y'" _
                            & " ORDER BY TLG.GRPID "

                    v_strUsrInGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    v_wsIngrp.Message(v_strUsrInGrpObjMsg)

                    v_xmlInGrpDocument.LoadXml(v_strUsrInGrpObjMsg)
                    v_nodeInGrpList = v_xmlInGrpDocument.SelectNodes("/ObjectMessage/ObjData")
                    ReDim mv_arrGroupId(v_nodeInGrpList.Count - 1)

                    For i As Integer = 0 To v_nodeInGrpList.Count - 1
                        For j As Integer = 0 To v_nodeInGrpList.Item(i).ChildNodes.Count - 1
                            With v_nodeInGrpList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "GRPID"
                                    mv_arrGroupId(i) = v_strValue
                            End Select
                        Next
                    Next

                End If




                'HaiLT lay toan bo danh sach TLPROFILES 

                ' BRID,TLGROUP,TLID
                v_strSQL = "SELECT A.BRID, A.TLGROUP, A.TLID FROM TLPROFILES A ORDER BY A.TLID"

                v_strUsrOutGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                Dim v_wsTLGRP As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_wsTLGRP.Message(v_strUsrOutGrpObjMsg)
                Dim v_xmlTLGRPDocument As New Xml.XmlDocument
                Dim v_nodeTLGRPList As Xml.XmlNodeList

                v_xmlTLGRPDocument.LoadXml(v_strUsrOutGrpObjMsg)
                v_nodeTLGRPList = v_xmlTLGRPDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeTLGRPList.Count - 1
                    For j As Integer = 0 To v_nodeTLGRPList.Item(i).ChildNodes.Count - 1
                        With v_nodeTLGRPList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "BRID"
                                v_strBRID = v_strValue
                            Case "TLGROUP"
                                v_strTLGROUP = v_strValue
                            Case "TLID"
                                v_strTLID = v_strValue
                        End Select
                    Next
                    v_strHashKey = v_strBRID & "|" & v_strTLGROUP & "|" & v_strTLID
                    If Not hTLGRPFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value in hash table
                        v_strHashValue = CStr(hTLGRPFilter(v_strHashKey))
                        'Get new value
                        v_strHashValue &= v_strTLID & "#"
                        'Remove old value
                        hTLGRPFilter.Remove(v_strHashKey)
                        'Add new value
                        hTLGRPFilter.Add(v_strHashKey, v_strHashValue)
                    Else
                        'Add new value
                        v_strHashValue = v_strHashKey & "#" & v_strTLID & "#"
                        hTLGRPFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                    If hUserFilter(v_strTLID) Is Nothing Then
                        hUserFilter.Add(v_strTLID, v_strTLID)
                    End If
                Next

                'End of HaiLT


                mv_blnIsLoadData = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''----------------------------------------------------------------''
    ''-- Thủ tục lấy dữ liệu đi?n v�ào các listbox:                  --''
    ''-- Cụ thể: Lấy thông tin NSD đã trong nhóm và chưa trong nhóm --''
    ''-- rồi đi?n v�ào các textbox tương ứng                         --''
    ''----------------------------------------------------------------''
    Private Sub ComboBoxGRPValueChange()
        Dim v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
        Dim v_strTLNAME, v_strValue As String
        Dim v_strFLDNAME As String
        Dim v_strFieldType As String
        Dim v_strCmdInquiryUsrOutGrp, v_strCmdInquiryUsrInGrp As String

        Try
            Dim v_strGroupId, v_strGroupName As String
            Dim v_arrUsrInGrp(), v_arrUsrOutGrp() As String
            Dim v_arrUsrInfo() As String

            lstUSRNOGRP.Items.Clear()
            lstUSRINGRP.Items.Clear()
            If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) Then
                v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
                v_strGroupName = CStr(hGroupsFilter(v_strGroupId)).Trim
                'Insert users that are not in group to list box
                If Not hTlidOutGrpFilter(v_strGroupId) Is Nothing Then
                    v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strGroupId)).Split("#")
                    For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
                        v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
                        'TungNT modified for display group 001
                        If Trim(DisplayType) = "Users" Then
                            If Trim(v_arrUsrInfo(1)) <> ADMIN_ID Then
                                lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
                            End If
                        Else
                            lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
                        End If
                        'End
                    Next

                End If
                'Insert users that are in group to list box
                If Not hTlidInGrpFilter(v_strGroupId) Is Nothing Then
                    v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strGroupId)).Split("#")
                    For i As Integer = 1 To v_arrUsrInGrp.Length - 2
                        v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
                        'TungNT modified for display group 001
                        If Trim(DisplayType) = "Users" Then
                            If Trim(v_arrUsrInfo(1)) <> ADMIN_ID Then
                                lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
                            End If
                        Else
                            lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
                        End If


                    Next

                End If
                'Display caption
                If Trim(DisplayType) = "Users" Then
                    lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS_USR.lblCaption") & v_strGroupName
                Else
                    lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS.lblCaption") & v_strGroupName
                End If
                'lblCaption.Text = mv_ResourceManager.GetString("frmGROUPUSERS.lblCaption") & v_strGroupName
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ComboBoxGRPTYPEValueChange()
        Try
            Dim v_strFLDNAME, v_strValue, v_strGrpType As String

            'Select and fill groups name
            Dim v_strSQL, v_strGrpObjMsg As String
            If (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) Then
                v_strGrpType = CStr(cboGRPTYPE.SelectedValue).Trim

                If DisplayType = "Users" Then
                    v_strSQL = "SELECT TLID VALUE, TLNAME DISPLAY FROM TLPROFILES" _
                            & " WHERE TLID = '" & UserId & "' AND ACTIVE = 'Y'"
                ElseIf DisplayType = "Groups" Then
                    v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS" _
                            & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
                Else
                    v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS" _
                            & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = DECODE('" & BranchId & "', '" & HO_BRID & "', BRID, '" & BranchId & "') AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                            & " AND GRPTYPE = '" & v_strGrpType & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
                End If


                v_strGrpObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionInquiry, v_strSQL)
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_ws.Message(v_strGrpObjMsg)

                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList

                v_xmlDocument.LoadXml(v_strGrpObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                ReDim mv_arrGroupId(v_nodeList.Count - 1)
                Dim v_arrGroupName(v_nodeList.Count - 1) As String

                'Clear combo box
                cboGROUP.Clears()
                'Add new items to combo box
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    mv_arrGroupId(i) = Trim(v_strValue)
                                Case "DISPLAY"
                                    v_arrGroupName(i) = Trim(v_strValue)
                            End Select
                        Next
                        'Add to hash table
                        If hGroupsFilter(mv_arrGroupId(i)) Is Nothing Then
                            hGroupsFilter.Add(mv_arrGroupId(i), v_arrGroupName(i))
                        End If
                        'Add item to combobox
                        cboGROUP.AddItems(v_arrGroupName(i), mv_arrGroupId(i))
                        GetUsrGrpInfo(mv_arrGroupId(i))
                    Next
                    'ComboBoxGRPValueChange()
                    'Return True
                Else
                    Exit Sub
                    'MsgBox(mv_ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    'Return False
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''--------------------------------------------------------''
    ''-- Ghi các thông tin định nghĩa NSD cho nhóm vào CSDL --''
    ''--------------------------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        'Dim v_strTLNAME, v_strValue As String
        Dim v_strClause As String

        Try

            'Get data from list box
            'Dim v_strUsrInGrp As String
            'Dim v_strBdsidInGrp As String

            'For i As Integer = 0 To lstUSRINGRP.Items.Count - 1
            '    v_strUsrInGrp &= hTlidInGrpFilter(lstUSRINGRP.Items.Item(i)) & "|"
            '    v_strBdsidInGrp &= hBridInGrpFilter(lstUSRINGRP.Items.Item(i)) & "|"
            'Next


            'Build XML message
            v_strClause = GetUsrGrpString()

            If DisplayType = "Users" Then
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionAdhoc, , v_strClause, "AddUser2Groups", gc_AutoIdUsed, )
            Else
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGRPUSERS, gc_ActionAdhoc, , v_strClause, "AddUsersToGroup", gc_AutoIdUsed, )
            End If

            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

            'Check infomations and errors from message
            Dim v_strErrorSource, v_strErrorMessage As String            

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                Exit Sub
            End If

            MsgBox(mv_ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)

            If mv_intExecFlag = OK Then
                Me.DialogResult = DialogResult.OK
                OnClose()
            ElseIf mv_intExecFlag = Apply Then

            End If
            'Me.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                             & "Error code: System error!" & vbNewLine _
                                                             & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    ''----------------------------------------------''
    ''-- Thay đổi listbox khi thêm 1 NSD vào nhóm --''
    ''----------------------------------------------''
    Private Sub MoveOne()
        Try
            Dim v_strHashValue, v_strGroupId, v_strTLID, v_strTLNAME, v_strNewUsrInfo As String
            Dim v_strHashKey As String = String.Empty

            v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
            v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
            If Not lstUSRNOGRP.SelectedItems Is Nothing Then

                For i As Integer = 0 To lstUSRNOGRP.SelectedItems.Count - 1
                    lstUSRINGRP.Items.Add(lstUSRNOGRP.SelectedItems.Item(0))
                    v_strTLNAME = CStr(lstUSRNOGRP.SelectedItems.Item(0)).Trim
                    v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                    v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"
                    If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value in hash table
                        v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                        'Get new value
                        v_strHashValue &= v_strNewUsrInfo
                        'Remove old value
                        hTlidInGrpFilter.Remove(v_strHashKey)
                        'Add new value
                        hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                    Else
                        'Add new value
                        v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                        hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                    'Delete information of selected user from hash table
                    If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                        v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                        'Delete usr info
                        v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                        hTlidOutGrpFilter.Remove(v_strHashKey)
                        'Add new value
                        hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                    lstUSRNOGRP.Items.Remove(lstUSRNOGRP.SelectedItems.Item(0))
                Next
                'lstUSRNOGRP.Items.Remove(lstUSRNOGRP.SelectedItems)
                'lstUSRNOGRP.SelectedItems.Clear()

                'v_strTLNAME = CStr(lstUSRNOGRP.SelectedItem).Trim
                'v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                'v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"
                'If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                '    'Remove old value before add new value in hash table
                '    v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                '    'Get new value
                '    v_strHashValue &= v_strNewUsrInfo
                '    'Remove old value
                '    hTlidInGrpFilter.Remove(v_strHashKey)
                '    'Add new value
                '    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                'Else
                '    'Add new value
                '    v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                '    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                'End If
                ''Delete information of selected user from hash table
                'If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                '    v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                '    'Delete usr info
                '    v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                '    hTlidOutGrpFilter.Remove(v_strHashKey)
                '    'Add new value
                '    hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                'End If
                'hTlidInGrpFilter.Add(lstUSRNOGRP.SelectedItem, hTlidOutGrpFilter(lstUSRNOGRP.SelectedItem))
                'hBridInGrpFilter.Add(lstUSRNOGRP.SelectedItem, hBridOutGrpFilter(lstUSRNOGRP.SelectedItem))
                'hTlidOutGrpFilter.Remove(lstUSRNOGRP.SelectedItem)
                'hBridOutGrpFilter.Remove(lstUSRNOGRP.SelectedItem)
                'lstUSRNOGRP.Items.Remove(lstUSRNOGRP.SelectedItems)
            Else
                MsgBox(mv_ResourceManager.GetString("SelectedItem"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------------------''
    ''-- Thay đổi listbox khi thêm tất cả NSD vào nhóm --''
    ''---------------------------------------------------''
    Private Sub MoveAll()
        Try
            Dim v_strHashValue, v_strGroupId, v_strTLID, v_strTLNAME, v_strNewUsrInfo As String
            Dim v_strHashKey As String = String.Empty

            v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
            v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue

            'Insert into list box
            lstUSRINGRP.Items.AddRange(lstUSRNOGRP.Items)
            'Insert values into "In group" hashtable and remove values from "Out group" hashtable
            For i As Integer = 0 To lstUSRNOGRP.Items.Count - 1
                v_strTLNAME = CStr(lstUSRNOGRP.Items.Item(i)).Trim
                v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"
                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                    'Remove old value before add new value in hash table
                    v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                    'Get new value
                    v_strHashValue &= v_strNewUsrInfo
                    'Remove old value
                    hTlidInGrpFilter.Remove(v_strHashKey)
                    'Add new value
                    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                Else
                    'Add new value
                    v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                End If
                'Delete information of selected user from hash table
                If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                    v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                    'Delete usr info
                    v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                    hTlidOutGrpFilter.Remove(v_strHashKey)
                    'Add new value
                    hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                End If
                'hTlidInGrpFilter.Add(lstUSRNOGRP.Items.Item(i), hTlidOutGrpFilter(lstUSRNOGRP.Items.Item(i)))
                'hBridInGrpFilter.Add(lstUSRNOGRP.Items.Item(i), hBridOutGrpFilter(lstUSRNOGRP.Items.Item(i)))
                'hTlidOutGrpFilter.Remove(lstUSRNOGRP.Items.Item(i))
                'hBridOutGrpFilter.Remove(lstUSRNOGRP.Items.Item(i))
            Next
            'Clear list box
            lstUSRNOGRP.Items.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''------------------------------------------------''
    ''-- Thay đổi listbox khi b? 1 NSD ra kh�?i nh�óm --''
    ''------------------------------------------------''
    Private Sub ReMoveOne()
        Try
            Dim v_strHashValue, v_strGroupId, v_strTLID, v_strTLNAME, v_strNewUsrInfo As String
            Dim v_strHashKey As String = String.Empty

            v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
            v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue

            If Not lstUSRINGRP.SelectedItems Is Nothing Then
                For i As Integer = 0 To lstUSRINGRP.SelectedItems.Count - 1
                    v_strTLNAME = CStr(lstUSRINGRP.SelectedItems.Item(0)).Trim
                    v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                    v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"

                    Dim v_blnAddBack As Boolean = True
                    'If v_strTLID <> TellerId Then
                    If DisplayType = "Users" Then
                        If hGrpAvlUsrFilter(v_strTLID) Is Nothing Then
                            v_blnAddBack = False
                        End If
                    End If
                    If v_blnAddBack Then
                        lstUSRNOGRP.Items.Add(lstUSRINGRP.SelectedItems.Item(0))
                        If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                            'Remove old value before add new value in hash table
                            v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                            'Get new value
                            v_strHashValue &= v_strNewUsrInfo
                            'Remove old value
                            hTlidOutGrpFilter.Remove(v_strHashKey)
                            'Add new value
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        Else
                            'Add new value
                            v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                            hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                        End If
                    End If
                    'Delete information of selected user from hash table
                    If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                        v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                        'Delete usr info
                        v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                        hTlidInGrpFilter.Remove(v_strHashKey)
                        'Add new value
                        hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                    lstUSRINGRP.Items.Remove(lstUSRINGRP.SelectedItems.Item(0))
                Next
                

                'v_strTLNAME = CStr(lstUSRINGRP.SelectedItem).Trim
                'v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                'v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"

                'Dim v_blnAddBack As Boolean = True
                ''If v_strTLID <> TellerId Then
                'If DisplayType = "Users" Then
                '    If hGrpAvlUsrFilter(v_strTLID) Is Nothing Then
                '        v_blnAddBack = False
                '    End If
                'End If
                'If v_blnAddBack Then
                '    lstUSRNOGRP.Items.Add(lstUSRINGRP.SelectedItem)
                '    If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                '        'Remove old value before add new value in hash table
                '        v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                '        'Get new value
                '        v_strHashValue &= v_strNewUsrInfo
                '        'Remove old value
                '        hTlidOutGrpFilter.Remove(v_strHashKey)
                '        'Add new value
                '        hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                '    Else
                '        'Add new value
                '        v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                '        hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                '    End If
                'End If
                ''Delete information of selected user from hash table
                'If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                '    v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                '    'Delete usr info
                '    v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                '    hTlidInGrpFilter.Remove(v_strHashKey)
                '    'Add new value
                '    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                'End If

                'Insert/Remove values to/from hashtables
                'hTlidOutGrpFilter.Add(lstUSRINGRP.SelectedItem, hTlidInGrpFilter(lstUSRINGRP.SelectedItem))
                'hBridOutGrpFilter.Add(lstUSRINGRP.SelectedItem, hBridInGrpFilter(lstUSRINGRP.SelectedItem))
                'hTlidInGrpFilter.Remove(lstUSRINGRP.SelectedItem)
                'hBridInGrpFilter.Remove(lstUSRINGRP.SelectedItem)

                'Remove item from "In group" list box
                'lstUSRINGRP.Items.Remove(lstUSRINGRP.SelectedItems)
                'Else
                '    MsgBox(mv_ResourceManager.GetString("CurrentUser"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '    Exit Sub
                'End If
            Else
                MsgBox(mv_ResourceManager.GetString("SelectedItem"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''-----------------------------------------------------''
    ''-- Thay đổi listbox khi b? t�ất cả NSD ra kh?i nh�óm --''
    ''-----------------------------------------------------''
    Private Sub ReMoveAll()
        Try
            Dim v_strHashValue, v_strGroupId, v_strTLID, v_strTLNAME, v_strNewUsrInfo As String
            Dim v_strHashKey As String = String.Empty

            v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
            v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
            Dim v_strTellerName As String = String.Empty
            Dim v_blnAddBack As Boolean = True
            'If v_strTLID <> TellerId Then
            For i As Integer = 0 To lstUSRINGRP.Items.Count - 1
                v_blnAddBack = True
                v_strTLNAME = CStr(lstUSRINGRP.Items.Item(i)).Trim
                v_strTLID = CStr(hUserFilter(v_strTLNAME)).Trim
                v_strNewUsrInfo = v_strTLNAME & "|" & v_strTLID & "#"
                'If v_strTLID <> TellerId Then
                If DisplayType = "Users" Then
                    If hGrpAvlUsrFilter(v_strTLID) Is Nothing Then
                        v_blnAddBack = False
                    End If
                End If
                If v_blnAddBack Then
                    lstUSRNOGRP.Items.Add(lstUSRINGRP.Items.Item(i))
                    If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
                        'Remove old value before add new value in hash table
                        v_strHashValue = CStr(hTlidOutGrpFilter(v_strHashKey))
                        'Get new value
                        v_strHashValue &= v_strNewUsrInfo
                        'Remove old value
                        hTlidOutGrpFilter.Remove(v_strHashKey)
                        'Add new value
                        hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                    Else
                        'Add new value
                        v_strHashValue = v_strHashKey & "#" & v_strNewUsrInfo
                        hTlidOutGrpFilter.Add(v_strHashKey, v_strHashValue)
                    End If
                End If

                'Delete information of selected user from hash table
                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                    v_strHashValue = CStr(hTlidInGrpFilter(v_strHashKey))
                    'Delete usr info
                    v_strHashValue = v_strHashValue.Replace(v_strNewUsrInfo, String.Empty)
                    hTlidInGrpFilter.Remove(v_strHashKey)
                    'Add new value
                    hTlidInGrpFilter.Add(v_strHashKey, v_strHashValue)
                End If
                'Else
                'v_strTellerName = v_strTLNAME
                'End If


                'If CStr(hTlidInGrpFilter(lstUSRINGRP.Items.Item(i))) <> TellerId Then
                '    'Insert to "Out group" list box
                '    lstUSRNOGRP.Items.Add(lstUSRINGRP.Items.Item(i))
                '    'Insert/Remove values to/from hashtables
                '    hTlidOutGrpFilter.Add(lstUSRINGRP.Items.Item(i), hTlidInGrpFilter(lstUSRINGRP.Items.Item(i)))
                '    hBridOutGrpFilter.Add(lstUSRINGRP.Items.Item(i), hBridInGrpFilter(lstUSRINGRP.Items.Item(i)))
                '    hTlidInGrpFilter.Remove(lstUSRINGRP.Items.Item(i))
                '    hBridInGrpFilter.Remove(lstUSRINGRP.Items.Item(i))
                '    'Remove item from "In group" list box
                '    'lstUSRINGRP.Items.Remove(lstUSRINGRP.Items.Item(i))
                'Else
                '    v_strTellerName = CStr(lstUSRINGRP.Items.Item(i))
                'End If
            Next
            'Clear list box
            lstUSRINGRP.Items.Clear()
            'If v_strTellerName <> String.Empty Then
            '    lstUSRINGRP.Items.Add(v_strTellerName)
            '    MsgBox(mv_ResourceManager.GetString("CurrentUser"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetUsrGrpString() As String

        Try
            Dim v_strUsrGrpString As String
            Dim v_strHashKey As String = String.Empty
            'For j As Integer = 0 To cboBRANCH.Items.Count - 1
            '    For i As Integer = 0 To mv_arrGroupId.Length - 1
            '        v_strHashKey = CStr(cboBRANCH.Items(j)(1)) & "|" & mv_arrGroupId(i)
            '        If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
            '            v_strUsrGrpString &= CStr(hTlidInGrpFilter(v_strHashKey)) & "$"
            '        End If
            '    Next
            'Next

            For i As Integer = 0 To cboBRANCH.Items.Count - 1
                For j As Integer = 0 To cboGRPTYPE.Items.Count - 1
                    For k As Integer = 0 To mv_arrGroupId.Count - 1
                        v_strHashKey = CStr(cboBRANCH.Items(i)(1)) & "|" & cboGRPTYPE.Items(j)(1) & "|" & mv_arrGroupId(k)
                        If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
                            v_strUsrGrpString &= CStr(hTlidInGrpFilter(v_strHashKey)) & "$"
                        End If
                    Next
                Next
            Next
            
            Return v_strUsrGrpString
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Form events "

    Private Sub frmGROUPUSERS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    OnClose()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        mv_intExecFlag = OK
        OnSave()
    End Sub

    Private Sub btnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply.Click
        mv_intExecFlag = Apply
        OnSave()
    End Sub

    Private Sub frmGROUPUSERS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub btnMOVEALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMOVEALL.Click
        MoveAll()
    End Sub

    Private Sub btnMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMOVE.Click
        MoveOne()
    End Sub

    Private Sub btnREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREMOVE.Click
        ReMoveOne()
    End Sub

    Private Sub btnREMOVEALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREMOVEALL.Click
        ReMoveAll()
    End Sub

    Private Sub cboGROUP_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGROUP.SelectedValueChanged
        'ComboBoxGRPValueChange()
        ComboBoxValueChange()
    End Sub

    Private Sub cboGRPTYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGRPTYPE.SelectedValueChanged
        'ComboBoxGRPTYPEValueChange()
        '
        If DisplayType <> "Users" Then
            'Fill group
            mv_blnIsLoadData = False

            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            cboGROUP.Clears()

            If DisplayType = "Groups" Then
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            Else
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                        & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)

            mv_blnIsLoadData = True
        End If
        ComboBoxValueChange()
    End Sub

    Private Sub cboBRANCH_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBRANCH.SelectedValueChanged
        'GetUsrGrpInfo(cboGROUP.SelectedValue)
        If DisplayType <> "Users" Then
            'Fill group
            mv_blnIsLoadData = False

            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            cboGROUP.Clears()

            If DisplayType = "Groups" Then
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            Else
                v_strSQL = "SELECT GRPID VALUE, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END DISPLAY, CASE WHEN DESCRIPTION IS NOT NULL THEN GRPNAME || ' - ' || DESCRIPTION ELSE GRPNAME END EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                        & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)

            mv_blnIsLoadData = True
        End If
        ComboBoxValueChange()
    End Sub

    Private Sub lstUSRNOGRP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUSRNOGRP.DoubleClick
        If ExeFlag <> ExecuteFlag.View And DisplayType <> "Users" Then
            MoveOne()
        End If
    End Sub

    Private Sub lstUSRINGRP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUSRINGRP.DoubleClick
        If ExeFlag <> ExecuteFlag.View And DisplayType <> "Users" Then
            ReMoveOne()
        End If
    End Sub

    Private Sub cboTLGROUP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTLGROUP.SelectedIndexChanged
        ComboBoxValueChange()
    End Sub
#End Region
    
End Class
