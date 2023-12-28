Imports System
Imports AppCore
Imports CommonLibrary

Public Class frmTLGROUPS
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
    Friend WithEvents txtGRPID As FlexMaskEditBox
    Friend WithEvents grbGROUPINFO As System.Windows.Forms.GroupBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblGRPNAME As System.Windows.Forms.Label
    Friend WithEvents lblACTIVE As System.Windows.Forms.Label
    Friend WithEvents cboACTIVE As AppCore.ComboBoxEx
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents txtGRPNAME As System.Windows.Forms.TextBox
    Friend WithEvents btnRptAssign As System.Windows.Forms.Button
    Friend WithEvents btnTransAssign As System.Windows.Forms.Button
    Friend WithEvents btnFuncAssign As System.Windows.Forms.Button
    Friend WithEvents grbFUNCTION As System.Windows.Forms.GroupBox
    Friend WithEvents lblGRPTYPE As System.Windows.Forms.Label
    Friend WithEvents cboGRPTYPE As AppCore.ComboBoxEx
    Friend WithEvents ckbCHECKER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbOFFICER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCASHIER As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTELLER As System.Windows.Forms.CheckBox
    Friend WithEvents lblGRPID As System.Windows.Forms.Label
    Friend WithEvents grbGRPRIGHT As System.Windows.Forms.GroupBox
    Friend WithEvents txtGRPRIGHT As System.Windows.Forms.TextBox
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnRightAssign As System.Windows.Forms.Button
    Friend WithEvents btnRightCopy As System.Windows.Forms.Button
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents ckbVIEWER As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTLGROUPS))
        Me.txtGRPID = New AppCore.FlexMaskEditBox()
        Me.grbGROUPINFO = New System.Windows.Forms.GroupBox()
        Me.lblGRPID = New System.Windows.Forms.Label()
        Me.lblGRPTYPE = New System.Windows.Forms.Label()
        Me.cboGRPTYPE = New AppCore.ComboBoxEx()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.lblGRPNAME = New System.Windows.Forms.Label()
        Me.lblACTIVE = New System.Windows.Forms.Label()
        Me.cboACTIVE = New AppCore.ComboBoxEx()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtGRPNAME = New System.Windows.Forms.TextBox()
        Me.txtGRPRIGHT = New System.Windows.Forms.TextBox()
        Me.grbFUNCTION = New System.Windows.Forms.GroupBox()
        Me.btnRightCopy = New System.Windows.Forms.Button()
        Me.btnRightAssign = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnTransAssign = New System.Windows.Forms.Button()
        Me.btnFuncAssign = New System.Windows.Forms.Button()
        Me.btnRptAssign = New System.Windows.Forms.Button()
        Me.grbGRPRIGHT = New System.Windows.Forms.GroupBox()
        Me.ckbVIEWER = New System.Windows.Forms.CheckBox()
        Me.ckbCHECKER = New System.Windows.Forms.CheckBox()
        Me.ckbOFFICER = New System.Windows.Forms.CheckBox()
        Me.ckbCASHIER = New System.Windows.Forms.CheckBox()
        Me.ckbTELLER = New System.Windows.Forms.CheckBox()
        Me.DataTable8 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.grbGROUPINFO.SuspendLayout()
        Me.grbFUNCTION.SuspendLayout()
        Me.grbGRPRIGHT.SuspendLayout()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(246, 269)
        Me.btnOK.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(326, 269)
        Me.btnCancel.TabIndex = 4
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(406, 269)
        Me.btnApply.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(485, 50)
        Me.Panel1.TabIndex = 6
        '
        'cboLink
        '
        '
        'txtGRPID
        '
        Me.txtGRPID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGRPID.Location = New System.Drawing.Point(117, 19)
        Me.txtGRPID.Name = "txtGRPID"
        Me.txtGRPID.Size = New System.Drawing.Size(110, 21)
        Me.txtGRPID.TabIndex = 1
        Me.txtGRPID.Tag = "GRPID"
        Me.txtGRPID.Text = "txtGRPID"
        '
        'grbGROUPINFO
        '
        Me.grbGROUPINFO.Controls.Add(Me.lblGRPID)
        Me.grbGROUPINFO.Controls.Add(Me.lblGRPTYPE)
        Me.grbGROUPINFO.Controls.Add(Me.cboGRPTYPE)
        Me.grbGROUPINFO.Controls.Add(Me.lblDESCRIPTION)
        Me.grbGROUPINFO.Controls.Add(Me.lblGRPNAME)
        Me.grbGROUPINFO.Controls.Add(Me.lblACTIVE)
        Me.grbGROUPINFO.Controls.Add(Me.cboACTIVE)
        Me.grbGROUPINFO.Controls.Add(Me.txtDESCRIPTION)
        Me.grbGROUPINFO.Controls.Add(Me.txtGRPNAME)
        Me.grbGROUPINFO.Controls.Add(Me.txtGRPID)
        Me.grbGROUPINFO.Controls.Add(Me.txtGRPRIGHT)
        Me.grbGROUPINFO.Location = New System.Drawing.Point(5, 55)
        Me.grbGROUPINFO.Name = "grbGROUPINFO"
        Me.grbGROUPINFO.Size = New System.Drawing.Size(476, 110)
        Me.grbGROUPINFO.TabIndex = 0
        Me.grbGROUPINFO.TabStop = False
        Me.grbGROUPINFO.Tag = "GROUPINFO"
        Me.grbGROUPINFO.Text = "grbGROUPINFO"
        '
        'lblGRPID
        '
        Me.lblGRPID.AutoSize = True
        Me.lblGRPID.Location = New System.Drawing.Point(10, 22)
        Me.lblGRPID.Name = "lblGRPID"
        Me.lblGRPID.Size = New System.Drawing.Size(48, 13)
        Me.lblGRPID.TabIndex = 30
        Me.lblGRPID.Tag = "GRPID"
        Me.lblGRPID.Text = "lblGRPID"
        Me.lblGRPID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGRPTYPE
        '
        Me.lblGRPTYPE.AutoSize = True
        Me.lblGRPTYPE.Location = New System.Drawing.Point(233, 22)
        Me.lblGRPTYPE.Name = "lblGRPTYPE"
        Me.lblGRPTYPE.Size = New System.Drawing.Size(61, 13)
        Me.lblGRPTYPE.TabIndex = 29
        Me.lblGRPTYPE.Tag = "GRPTYPE"
        Me.lblGRPTYPE.Text = "lblGRPTYPE"
        Me.lblGRPTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGRPTYPE
        '
        Me.cboGRPTYPE.DisplayMember = "DISPLAY"
        Me.cboGRPTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGRPTYPE.Location = New System.Drawing.Point(358, 19)
        Me.cboGRPTYPE.Name = "cboGRPTYPE"
        Me.cboGRPTYPE.Size = New System.Drawing.Size(110, 21)
        Me.cboGRPTYPE.TabIndex = 2
        Me.cboGRPTYPE.Tag = "GRPTYPE"
        Me.cboGRPTYPE.ValueMember = "VALUE"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.AutoSize = True
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(10, 82)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(85, 13)
        Me.lblDESCRIPTION.TabIndex = 27
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGRPNAME
        '
        Me.lblGRPNAME.AutoSize = True
        Me.lblGRPNAME.Location = New System.Drawing.Point(10, 52)
        Me.lblGRPNAME.Name = "lblGRPNAME"
        Me.lblGRPNAME.Size = New System.Drawing.Size(65, 13)
        Me.lblGRPNAME.TabIndex = 26
        Me.lblGRPNAME.Tag = "GRPNAME"
        Me.lblGRPNAME.Text = "lblGRPNAME"
        Me.lblGRPNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACTIVE
        '
        Me.lblACTIVE.AutoSize = True
        Me.lblACTIVE.Location = New System.Drawing.Point(233, 52)
        Me.lblACTIVE.Name = "lblACTIVE"
        Me.lblACTIVE.Size = New System.Drawing.Size(53, 13)
        Me.lblACTIVE.TabIndex = 24
        Me.lblACTIVE.Tag = "ACTIVE"
        Me.lblACTIVE.Text = "lblACTIVE"
        Me.lblACTIVE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboACTIVE
        '
        Me.cboACTIVE.DisplayMember = "DISPLAY"
        Me.cboACTIVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboACTIVE.Location = New System.Drawing.Point(358, 49)
        Me.cboACTIVE.Name = "cboACTIVE"
        Me.cboACTIVE.Size = New System.Drawing.Size(110, 21)
        Me.cboACTIVE.TabIndex = 4
        Me.cboACTIVE.Tag = "ACTIVE"
        Me.cboACTIVE.ValueMember = "VALUE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(117, 79)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(351, 21)
        Me.txtDESCRIPTION.TabIndex = 5
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'txtGRPNAME
        '
        Me.txtGRPNAME.Location = New System.Drawing.Point(117, 49)
        Me.txtGRPNAME.Name = "txtGRPNAME"
        Me.txtGRPNAME.Size = New System.Drawing.Size(110, 21)
        Me.txtGRPNAME.TabIndex = 3
        Me.txtGRPNAME.Tag = "GRPNAME"
        Me.txtGRPNAME.Text = "txtGRPNAME"
        '
        'txtGRPRIGHT
        '
        Me.txtGRPRIGHT.Location = New System.Drawing.Point(275, 80)
        Me.txtGRPRIGHT.Name = "txtGRPRIGHT"
        Me.txtGRPRIGHT.Size = New System.Drawing.Size(100, 21)
        Me.txtGRPRIGHT.TabIndex = 0
        Me.txtGRPRIGHT.Tag = "GRPRIGHT"
        Me.txtGRPRIGHT.Text = "txtGRPRIGHT"
        '
        'grbFUNCTION
        '
        Me.grbFUNCTION.Controls.Add(Me.btnRightCopy)
        Me.grbFUNCTION.Controls.Add(Me.btnRightAssign)
        Me.grbFUNCTION.Controls.Add(Me.btnUsers)
        Me.grbFUNCTION.Controls.Add(Me.btnTransAssign)
        Me.grbFUNCTION.Controls.Add(Me.btnFuncAssign)
        Me.grbFUNCTION.Controls.Add(Me.btnRptAssign)
        Me.grbFUNCTION.Location = New System.Drawing.Point(5, 220)
        Me.grbFUNCTION.Name = "grbFUNCTION"
        Me.grbFUNCTION.Size = New System.Drawing.Size(476, 43)
        Me.grbFUNCTION.TabIndex = 2
        Me.grbFUNCTION.TabStop = False
        Me.grbFUNCTION.Tag = "FUNCTION"
        Me.grbFUNCTION.Text = "grbFUNCTION"
        '
        'btnRightCopy
        '
        Me.btnRightCopy.Location = New System.Drawing.Point(370, 15)
        Me.btnRightCopy.Name = "btnRightCopy"
        Me.btnRightCopy.Size = New System.Drawing.Size(100, 23)
        Me.btnRightCopy.TabIndex = 6
        Me.btnRightCopy.Tag = "btnRightCopy"
        Me.btnRightCopy.Text = "btnRightCopy"
        '
        'btnRightAssign
        '
        Me.btnRightAssign.Location = New System.Drawing.Point(13, 15)
        Me.btnRightAssign.Name = "btnRightAssign"
        Me.btnRightAssign.Size = New System.Drawing.Size(100, 23)
        Me.btnRightAssign.TabIndex = 5
        Me.btnRightAssign.Tag = "btnRightAssign"
        Me.btnRightAssign.Text = "btnRightAssign"
        '
        'btnUsers
        '
        Me.btnUsers.Location = New System.Drawing.Point(132, 15)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(100, 23)
        Me.btnUsers.TabIndex = 3
        Me.btnUsers.Tag = "btnUsers"
        Me.btnUsers.Text = "btnUsers"
        '
        'btnTransAssign
        '
        Me.btnTransAssign.Location = New System.Drawing.Point(112, 44)
        Me.btnTransAssign.Name = "btnTransAssign"
        Me.btnTransAssign.Size = New System.Drawing.Size(80, 23)
        Me.btnTransAssign.TabIndex = 1
        Me.btnTransAssign.Tag = "btnTransAssign"
        Me.btnTransAssign.Text = "btnTransAssign"
        '
        'btnFuncAssign
        '
        Me.btnFuncAssign.Location = New System.Drawing.Point(15, 44)
        Me.btnFuncAssign.Name = "btnFuncAssign"
        Me.btnFuncAssign.Size = New System.Drawing.Size(80, 23)
        Me.btnFuncAssign.TabIndex = 0
        Me.btnFuncAssign.Tag = "btnFuncAssign"
        Me.btnFuncAssign.Text = "btnFuncAssign"
        '
        'btnRptAssign
        '
        Me.btnRptAssign.Location = New System.Drawing.Point(204, 44)
        Me.btnRptAssign.Name = "btnRptAssign"
        Me.btnRptAssign.Size = New System.Drawing.Size(80, 23)
        Me.btnRptAssign.TabIndex = 2
        Me.btnRptAssign.Tag = "btnRptAssign"
        Me.btnRptAssign.Text = "btnRptAssign"
        '
        'grbGRPRIGHT
        '
        Me.grbGRPRIGHT.Controls.Add(Me.ckbVIEWER)
        Me.grbGRPRIGHT.Controls.Add(Me.ckbCHECKER)
        Me.grbGRPRIGHT.Controls.Add(Me.ckbOFFICER)
        Me.grbGRPRIGHT.Controls.Add(Me.ckbCASHIER)
        Me.grbGRPRIGHT.Controls.Add(Me.ckbTELLER)
        Me.grbGRPRIGHT.Location = New System.Drawing.Point(5, 165)
        Me.grbGRPRIGHT.Name = "grbGRPRIGHT"
        Me.grbGRPRIGHT.Size = New System.Drawing.Size(476, 55)
        Me.grbGRPRIGHT.TabIndex = 1
        Me.grbGRPRIGHT.TabStop = False
        Me.grbGRPRIGHT.Tag = "GRPRIGHT"
        Me.grbGRPRIGHT.Text = "grbGRPRIGHT"
        '
        'ckbVIEWER
        '
        Me.ckbVIEWER.Location = New System.Drawing.Point(10, 20)
        Me.ckbVIEWER.Name = "ckbVIEWER"
        Me.ckbVIEWER.Size = New System.Drawing.Size(85, 25)
        Me.ckbVIEWER.TabIndex = 0
        Me.ckbVIEWER.Tag = "VIEWER"
        Me.ckbVIEWER.Text = "ckbVIEWER"
        '
        'ckbCHECKER
        '
        Me.ckbCHECKER.Location = New System.Drawing.Point(376, 20)
        Me.ckbCHECKER.Name = "ckbCHECKER"
        Me.ckbCHECKER.Size = New System.Drawing.Size(91, 25)
        Me.ckbCHECKER.TabIndex = 4
        Me.ckbCHECKER.Tag = "CHECKER"
        Me.ckbCHECKER.Text = "ckbCHECKER"
        '
        'ckbOFFICER
        '
        Me.ckbOFFICER.Location = New System.Drawing.Point(286, 20)
        Me.ckbOFFICER.Name = "ckbOFFICER"
        Me.ckbOFFICER.Size = New System.Drawing.Size(86, 25)
        Me.ckbOFFICER.TabIndex = 3
        Me.ckbOFFICER.Tag = "OFFICER"
        Me.ckbOFFICER.Text = "ckbOFFICER"
        '
        'ckbCASHIER
        '
        Me.ckbCASHIER.Location = New System.Drawing.Point(188, 20)
        Me.ckbCASHIER.Name = "ckbCASHIER"
        Me.ckbCASHIER.Size = New System.Drawing.Size(94, 25)
        Me.ckbCASHIER.TabIndex = 2
        Me.ckbCASHIER.Tag = "CASHIER"
        Me.ckbCASHIER.Text = "ckbCASHIER"
        '
        'ckbTELLER
        '
        Me.ckbTELLER.Location = New System.Drawing.Point(99, 20)
        Me.ckbTELLER.Name = "ckbTELLER"
        Me.ckbTELLER.Size = New System.Drawing.Size(85, 25)
        Me.ckbTELLER.TabIndex = 1
        Me.ckbTELLER.Tag = "TELLER"
        Me.ckbTELLER.Text = "ckbTELLER"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'frmTLGROUPS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(485, 297)
        Me.Controls.Add(Me.grbGRPRIGHT)
        Me.Controls.Add(Me.grbFUNCTION)
        Me.Controls.Add(Me.grbGROUPINFO)
        Me.Name = "frmTLGROUPS"
        Me.Tag = "TLGROUPS"
        Me.Text = "frmTLGROUPS"
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grbGROUPINFO, 0)
        Me.Controls.SetChildIndex(Me.grbFUNCTION, 0)
        Me.Controls.SetChildIndex(Me.grbGRPRIGHT, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbGROUPINFO.ResumeLayout(False)
        Me.grbGROUPINFO.PerformLayout()
        Me.grbFUNCTION.ResumeLayout(False)
        Me.grbGRPRIGHT.ResumeLayout(False)
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables"
    Private mv_strGroupId As String
    Private mv_strGroupRight As String
#End Region

#Region " Properties"
    Public Property GroupId() As String
        Get
            Return mv_strGroupid
        End Get
        Set(ByVal Value As String)
            mv_strGroupid = Value
        End Set
    End Property
#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            GetGroupRight()

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , "GRPID = '" & Trim(txtGRPID.Text) & "'", , gc_AutoIdUnused)
                   
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            MyBase.DoDataExchange()
                            LoadUserInterface(Me)
                            txtGRPID.Enabled = False
                            grbFUNCTION.Enabled = True
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                    'If sender Is btnOK Then
                    '    Me.DialogResult = DialogResult.OK
                    '    MyBase.OnClose()
                    'ElseIf sender Is btnApply Then
                    '    KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                    '    ExeFlag = ExecuteFlag.Edit
                    '    LoadUserInterface(Me)
                    '    txtGRPID.Enabled = False
                    '    grbFUNCTION.Enabled = True
                    'End If
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                            txtGRPID.Enabled = False
                            grbFUNCTION.Enabled = True
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                    'If sender Is btnOK Then
                    '    Me.DialogResult = DialogResult.OK
                    '    MyBase.OnClose()
                    'ElseIf sender Is btnApply Then
                    '    grbFUNCTION.Enabled = True
                    'End If
            End Select

            'Me.DialogResult = DialogResult.OK
            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

        'Disable or enable control
        If (ExeFlag = ExecuteFlag.AddNew) Then
            btnUsers.Enabled = False
            grbFUNCTION.Enabled = False
            txtGRPID.Text = CStr(GetGroupId())
            btnRightCopy.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.View) Then
            cboGRPTYPE.Enabled = False
            cboACTIVE.Enabled = False
            btnUsers.Enabled = True
            btnApply.Enabled = False
            btnRightCopy.Enabled = False
            If cboGRPTYPE.SelectedValue = "2" Then
                grbFUNCTION.Enabled = True
                'btnAftype.Enabled = True
            Else
                grbFUNCTION.Enabled = True
                'btnAftype.Enabled = False
            End If
            grbGRPRIGHT.Enabled = False
            txtGRPID.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            btnUsers.Enabled = True
            btnRightCopy.Enabled = True
            If cboACTIVE.SelectedValue = "N" Then
                grbFUNCTION.Enabled = False
                grbGRPRIGHT.Enabled = False

            Else
                grbFUNCTION.Enabled = True
                grbGRPRIGHT.Enabled = True
                'If cboGRPTYPE.SelectedValue = "2" Then
                '    btnAftype.Enabled = True
                'Else
                '    btnAftype.Enabled = False
                'End If
            End If
            txtGRPID.Enabled = False
        End If
        txtGRPRIGHT.Visible = False

        'Display right of group
        If (ExeFlag = ExecuteFlag.View) Or (ExeFlag = ExecuteFlag.Edit) Then
            Dim v_strGrpRight, v_strMaker, v_strCashier, v_strChecker, v_strOfficer, v_strViewer As String
            v_strGrpRight = CStr(txtGRPRIGHT.Text).Trim
            v_strMaker = Mid(v_strGrpRight, 1, 1)
            v_strCashier = Mid(v_strGrpRight, 2, 1)
            v_strOfficer = Mid(v_strGrpRight, 3, 1)
            v_strChecker = Mid(v_strGrpRight, 4, 1)
            v_strViewer = Mid(v_strGrpRight, 5, 1)

            'Map to checkboxs
            ckbTELLER.Checked = (v_strMaker = "Y")
            ckbCASHIER.Checked = (v_strCashier = "Y")
            ckbOFFICER.Checked = (v_strOfficer = "Y")
            ckbCHECKER.Checked = (v_strChecker = "Y")
            ckbVIEWER.Checked = (v_strViewer = "Y")

            mv_strGroupRight = v_strGrpRight

        End If
    End Sub

    Private Sub GetGroupRight()
        Try
            Dim v_strGrpRight, v_strView, v_strMaker, v_strCashier, v_strChecker, v_strOfficer As String
            'Get TLType string
            v_strGrpRight = String.Empty
     
            If ckbTELLER.Checked Then
                v_strMaker = "Y"
            Else
                v_strMaker = "N"
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
                v_strView = "Y"
            Else
                v_strView = "N"
            End If
            v_strGrpRight = v_strMaker & v_strCashier & v_strOfficer & v_strChecker & v_strView
            txtGRPRIGHT.Text = v_strGrpRight
            mv_strGroupRight = v_strGrpRight
            'mv_strTlType = v_strTLTypeStr
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Function GetGroupId() As String
        Try

            Dim v_strSQL, v_strGrpId As String
            Dim v_strObjMsg As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , , "GetGroupId")
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
                            Case "GRPID"
                                v_strGrpId = CStr(v_strValue).Trim
                        End Select
                    End With
                Next
            Next

            If v_strGrpId Is String.Empty Then
                v_strGrpId = "1"
            End If
            'Gh�ép để thành GroupId
            v_strGrpId = Strings.Right("0000" & CStr(v_strGrpId), Len("0000"))
            Return v_strGrpId
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub cboGRPTYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGRPTYPE.SelectedValueChanged
        Try
            If (Not cboGRPTYPE.SelectedValue Is DBNull.Value) And (Not cboGRPTYPE.SelectedValue Is Nothing) Then
                If cboGRPTYPE.SelectedValue = "2" Then
                    ckbTELLER.Checked = False
                    ckbCASHIER.Checked = False
                    ckbOFFICER.Checked = False
                    ckbCHECKER.Checked = False
                    grbGRPRIGHT.Enabled = False
                    grbFUNCTION.Enabled = False
                ElseIf cboGRPTYPE.SelectedValue = "1" Then
                    'ckbTELLER.Checked = True
                    'ckbCASHIER.Checked = True
                    'ckbOFFICER.Checked = True
                    'ckbCHECKER.Checked = True
                    grbGRPRIGHT.Enabled = True
                    grbFUNCTION.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Form events "
    ''----------------------------------------------------''
    ''-- Hiển thị form gán ngư?i d�ùng vào nhóm hiện tại --''
    ''----------------------------------------------------''
    Private Sub btnUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUsers.Click
        Dim v_objGROUPUSERS As New frmGROUPUSERS
        v_objGROUPUSERS.UserLanguage = UserLanguage
        v_objGROUPUSERS.TellerId = TellerId
        v_objGROUPUSERS.BranchId = BranchId
        v_objGROUPUSERS.GroupId = txtGRPID.Text
        v_objGROUPUSERS.GroupName = txtGRPNAME.Text
        v_objGROUPUSERS.ExeFlag = ExeFlag
        v_objGROUPUSERS.DisplayType = "Groups"
        v_objGROUPUSERS.GroupType = CStr(cboGRPTYPE.SelectedValue).Trim
        v_objGROUPUSERS.ShowDialog()
    End Sub

    'Private Sub btnAftype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAftype.Click
    '    Dim v_objGRPAFTYPE As New frmGRPAFTYPE
    '    v_objGRPAFTYPE.UserLanguage = UserLanguage
    '    v_objGRPAFTYPE.TellerId = TellerId
    '    v_objGRPAFTYPE.BranchId = BranchId
    '    v_objGRPAFTYPE.GroupId = txtGRPID.Text
    '    v_objGRPAFTYPE.GroupName = txtGRPNAME.Text
    '    v_objGRPAFTYPE.ExeFlag = ExeFlag
    '    v_objGRPAFTYPE.GroupType = CStr(cboGRPTYPE.SelectedValue).Trim
    '    v_objGRPAFTYPE.ShowDialog()
    'End Sub

    ''---------------------------------------------------------''
    ''-- Hiển thị form phân quy?n ch�ức năng cho nhóm hiện tại --''
    ''---------------------------------------------------------''
    Private Sub btnFuncAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFuncAssign.Click
        Dim v_objFuncAssign As New frmFuncAssign(UserLanguage)
        v_objFuncAssign.TellerId = TellerId
        v_objFuncAssign.GroupId = txtGRPID.Text
        v_objFuncAssign.GroupName = txtGRPNAME.Text
        v_objFuncAssign.UserLanguage = UserLanguage
        v_objFuncAssign.ExeFlag = ExeFlag
        v_objFuncAssign.AssignType = "Group"
        v_objFuncAssign.ShowDialog()
    End Sub

    ''---------------------------------------------------------''
    ''-- Hiển thị form phân quy?n giao d�ịch cho nhóm hiện tại --''
    ''---------------------------------------------------------''
    Private Sub btnTransAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransAssign.Click
        Dim v_objTransAssign As New frmTransAssign(UserLanguage)
        v_objTransAssign.TellerId = TellerId
        v_objTransAssign.GroupId = txtGRPID.Text
        v_objTransAssign.GroupName = txtGRPNAME.Text
        v_objTransAssign.UserLanguage = UserLanguage.Trim
        v_objTransAssign.ExeFlag = ExeFlag
        v_objTransAssign.AssignType = "Group"
        v_objTransAssign.GroupRight = mv_strGroupRight
        v_objTransAssign.ShowDialog()
    End Sub

    ''-------------------------------------------------------''
    ''-- Hiển thị form phân quy?n b�áo cáo cho nhóm hiện tại --''
    ''-------------------------------------------------------''
    Private Sub btnRptAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptAssign.Click
        Dim v_objRptAssign As New frmRptAssign(UserLanguage)
        v_objRptAssign.TellerId = TellerId
        v_objRptAssign.GroupId = txtGRPID.Text
        v_objRptAssign.GroupName = txtGRPNAME.Text
        v_objRptAssign.UserLanguage = UserLanguage
        v_objRptAssign.ExeFlag = ExeFlag
        v_objRptAssign.AssignType = "Group"
        v_objRptAssign.ShowDialog()
    End Sub

    'Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
    '    OnSave()
    'End Sub

    'Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    '    OnSave()
    'End Sub

    Private Sub btnRightAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightAssign.Click
        Dim v_objRightAssign As New frmRightAssignment(UserLanguage)
        v_objRightAssign.TellerId = TellerId
        v_objRightAssign.GroupId = txtGRPID.Text
        v_objRightAssign.GroupName = txtGRPNAME.Text
        v_objRightAssign.UserLanguage = UserLanguage
        v_objRightAssign.ExeFlag = ExeFlag
        v_objRightAssign.AssignType = "Group"
        v_objRightAssign.GroupRight = mv_strGroupRight
        v_objRightAssign.ShowDialog()
    End Sub

    Private Sub btnRightCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightCopy.Click
        Dim v_objRightCopy As New frmRIGHTCOPY()
        v_objRightCopy.UserLanguage = UserLanguage
        v_objRightCopy.TellerId = TellerId
        v_objRightCopy.BranchId = BranchId
        v_objRightCopy.GroupId = txtGRPID.Text
        v_objRightCopy.GroupName = txtGRPNAME.Text
        v_objRightCopy.ShowDialog()
    End Sub

#End Region

    
   
End Class
