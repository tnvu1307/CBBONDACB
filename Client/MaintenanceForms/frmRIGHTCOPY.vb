Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.Xml
Imports AppCore

Public Class frmRIGHTCOPY
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboGROUP As ComboBoxEx
    Friend WithEvents lblGROUP As System.Windows.Forms.Label
    Friend WithEvents grbGRPINFO As System.Windows.Forms.GroupBox
    Friend WithEvents lblGRPTYPE As System.Windows.Forms.Label
    Friend WithEvents lblBRANCH As System.Windows.Forms.Label
    Friend WithEvents cboBRANCH As AppCore.ComboBoxEx
    Friend WithEvents cboGRPTYPE As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRIGHTCOPY))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.cboGROUP = New AppCore.ComboBoxEx
        Me.lblGROUP = New System.Windows.Forms.Label
        Me.grbGRPINFO = New System.Windows.Forms.GroupBox
        Me.lblBRANCH = New System.Windows.Forms.Label
        Me.cboBRANCH = New AppCore.ComboBoxEx
        Me.lblGRPTYPE = New System.Windows.Forms.Label
        Me.cboGRPTYPE = New AppCore.ComboBoxEx
        Me.Panel1.SuspendLayout()
        Me.grbGRPINFO.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(437, 142)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(517, 142)
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
        Me.Panel1.Size = New System.Drawing.Size(594, 50)
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
        'cboGROUP
        '
        Me.cboGROUP.DisplayMember = "DISPLAY"
        Me.cboGROUP.Location = New System.Drawing.Point(282, 47)
        Me.cboGROUP.Name = "cboGROUP"
        Me.cboGROUP.Size = New System.Drawing.Size(301, 21)
        Me.cboGROUP.TabIndex = 2
        Me.cboGROUP.Tag = "GROUP"
        Me.cboGROUP.ValueMember = "VALUE"
        '
        'lblGROUP
        '
        Me.lblGROUP.AutoSize = True
        Me.lblGROUP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGROUP.Location = New System.Drawing.Point(195, 50)
        Me.lblGROUP.Name = "lblGROUP"
        Me.lblGROUP.Size = New System.Drawing.Size(52, 13)
        Me.lblGROUP.TabIndex = 13
        Me.lblGROUP.Tag = "GROUP"
        Me.lblGROUP.Text = "lblGROUP"
        Me.lblGROUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbGRPINFO
        '
        Me.grbGRPINFO.Controls.Add(Me.lblBRANCH)
        Me.grbGRPINFO.Controls.Add(Me.cboBRANCH)
        Me.grbGRPINFO.Controls.Add(Me.lblGRPTYPE)
        Me.grbGRPINFO.Controls.Add(Me.cboGRPTYPE)
        Me.grbGRPINFO.Controls.Add(Me.lblGROUP)
        Me.grbGRPINFO.Controls.Add(Me.cboGROUP)
        Me.grbGRPINFO.Location = New System.Drawing.Point(3, 55)
        Me.grbGRPINFO.Name = "grbGRPINFO"
        Me.grbGRPINFO.Size = New System.Drawing.Size(589, 81)
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
        Me.cboBRANCH.Size = New System.Drawing.Size(494, 21)
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
        Me.cboGRPTYPE.Size = New System.Drawing.Size(100, 21)
        Me.cboGRPTYPE.TabIndex = 1
        Me.cboGRPTYPE.Tag = "GRPTYPE"
        Me.cboGRPTYPE.ValueMember = "VALUE"
        '
        'frmRIGHTCOPY
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(594, 170)
        Me.Controls.Add(Me.grbGRPINFO)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRIGHTCOPY"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "GROUPUSERS"
        Me.Text = "frmRIGHTCOPY"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
#End Region

#Region " Overridable methods"

    Public Overridable Sub OnInit()
        Try

            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & ".frmRIGHTCOPY-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            'If Not FillData() Then
            '    Exit Sub
            'End If
            If Not FillCombobox() Then
                Exit Sub
            End If
            LoadUserInterface(Me)
            'Lay thong tin nhom
            'If DisplayType = "Users" Then
            '    GetUserGroupsInfo(UserId)
            'Else
            '    GetUserGroupsInfo("")
            'End If
            'Fill list
            'ComboBoxValueChange()
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

            Dim v_strGroupName As String
            If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) Then
                v_strGroupName = cboGROUP.SelectedText
            End If

            'Load caption của form, label caption
            Me.Text = mv_ResourceManager.GetString("frmRIGHTCOPY")
            lblCaption.Text = mv_ResourceManager.GetString("lblCaption") & GroupName

            'lblCaption.Text = mv_ResourceManager.GetString("frmRIGHTCOPY.lblCaption") & GroupName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function FillCombobox() As Boolean
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

            'Select and fill groups type
            'If Trim(DisplayType) = "Users" Then
            '    v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, LSTODR " _
            '            & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            'ElseIf Trim(DisplayType) = "Groups" Then
            '    v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, LSTODR " _
            '            & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' AND CDVAL = '" & GroupType & "'"
            'Else
            v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " _
                    & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'GRPTYPE' ORDER BY LSTODR"
            'End If
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGRPTYPE, "", Me.UserLanguage)

            'Fill group
            'If DisplayType = "Users" Then
            '    v_strSQL = "SELECT TLID VALUE, TLNAME DISPLAY, TLNAME EN_DISPLAY, 0 LSTODR FROM TLPROFILES" _
            '            & " WHERE TLID = '" & UserId & "' AND ACTIVE = 'Y'"
            'ElseIf DisplayType = "Groups" Then
            '    v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
            '            & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            'Else
            v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                    & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                    & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            'End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)
            'Store group infor

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    'Private Sub ComboBoxValueChange()
    '    Dim v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
    '    Dim v_strTLNAME, v_strValue As String
    '    Dim v_strFLDNAME As String
    '    Dim v_strFieldType As String
    '    Dim v_strCmdInquiryUsrOutGrp, v_strCmdInquiryUsrInGrp As String

    '    Try
    '        Dim v_strGroupId, v_strGroupName As String
    '        Dim v_arrUsrInGrp(), v_arrUsrOutGrp() As String
    '        Dim v_arrUsrInfo() As String
    '        Dim v_strHashKey, v_strHashValue As String

    '        If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) _
    '           And (Not cboBRANCH.SelectedValue Is Nothing) And (Not cboBRANCH.SelectedValue Is DBNull.Value) _
    '           And (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) _
    '           And mv_blnIsLoadData Then
    '            If Trim(DisplayType) = "Users" Then
    '                v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
    '                v_strGroupName = cboGROUP.Text
    '                v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
    '                'Insert users that are not in group to list box
    '                If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
    '                        'lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
    '                    Next
    '                End If
    '                'Insert users that are in group to list box
    '                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrInGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
    '                        'lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
    '                    Next
    '                End If
    '                'Display caption
    '                lblCaption.Text = mv_ResourceManager.GetString("frmRIGHTCOPY_USR.lblCaption") & v_strGroupName
    '            Else
    '                v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
    '                v_strGroupName = cboGROUP.Text
    '                v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
    '                'Insert users that are not in group to list box
    '                If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
    '                        'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
    '                        'lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
    '                        'End If
    '                    Next
    '                End If
    '                'Insert users that are in group to list box
    '                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrInGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
    '                        'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
    '                        'lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
    '                        'End If
    '                    Next
    '                End If
    '                'Display caption
    '                lblCaption.Text = mv_ResourceManager.GetString("frmRIGHTCOPY.lblCaption") & v_strGroupName
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    
    
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
            If MessageBox.Show(mv_ResourceManager.GetString("CopyConfirm") & cboGROUP.Text & mv_ResourceManager.GetString("CopyConfirm2") & GroupName & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                v_strClause = GroupId & "|" & cboGROUP.SelectedValue
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RIGHTCOPY, gc_ActionAdhoc, , v_strClause, "RightCopy", gc_AutoIdUsed, )

                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                'Check infomations and errors from message
                Dim v_strErrorSource, v_strErrorMessage As String

                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

                MsgBox(mv_ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                If mv_intExecFlag = OK Then
                    Me.DialogResult = DialogResult.OK
                    OnClose()
                ElseIf mv_intExecFlag = Apply Then

                End If
            End If
            'Me.OnClose()

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

#End Region

#Region " Form events "

    Private Sub frmRIGHTCOPY_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub frmRIGHTCOPY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub cboGROUP_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGROUP.SelectedValueChanged
        'ComboBoxGRPValueChange()
        'ComboBoxValueChange()
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
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            Else
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                        & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)

            mv_blnIsLoadData = True
        End If
        'ComboBoxValueChange()
    End Sub

    Private Sub cboBRANCH_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBRANCH.SelectedValueChanged
        'GetUsrGrpInfo(cboGROUP.SelectedValue)
        'ComboBoxValueChange()
        If DisplayType <> "Users" Then
            'Fill group
            mv_blnIsLoadData = False

            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            cboGROUP.Clears()

            If DisplayType = "Groups" Then
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID = '" & GroupId & "' AND ACTIVE = 'Y'"
            Else
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY, GRPNAME EN_DISPLAY, 0 LSTODR FROM TLGROUPS" _
                        & " WHERE GRPID IN (SELECT PARAVALUE GRPID FROM BRGRPPARAM WHERE BRID = '" & cboBRANCH.SelectedValue & "' AND PARATYPE = 'TLGROUPS' AND DELTD = 'N') " _
                        & " AND GRPTYPE = '" & cboGRPTYPE.SelectedValue & "' AND ACTIVE = 'Y' ORDER BY GRPNAME"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboGROUP, "", Me.UserLanguage)

            mv_blnIsLoadData = True
        End If
    End Sub

#End Region
End Class
