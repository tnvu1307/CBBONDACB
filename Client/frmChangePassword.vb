Imports CommonLibrary
Imports Microsoft.Win32

Public Class frmChangePassword
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
    Friend WithEvents txtOLDPASS As System.Windows.Forms.TextBox
    Friend WithEvents lblOLDPASS As System.Windows.Forms.Label
    Friend WithEvents lblPASS As System.Windows.Forms.Label
    Friend WithEvents lblCOFPASS As System.Windows.Forms.Label
    Friend WithEvents txtPASS As System.Windows.Forms.TextBox
    Friend WithEvents txtCOFPASS As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtOLDPASS = New System.Windows.Forms.TextBox
        Me.lblOLDPASS = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.txtCOFPASS = New System.Windows.Forms.TextBox
        Me.txtPASS = New System.Windows.Forms.TextBox
        Me.lblCOFPASS = New System.Windows.Forms.Label
        Me.lblPASS = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.grbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOLDPASS
        '
        Me.txtOLDPASS.Location = New System.Drawing.Point(105, 20)
        Me.txtOLDPASS.Name = "txtOLDPASS"
        Me.txtOLDPASS.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtOLDPASS.Size = New System.Drawing.Size(150, 21)
        Me.txtOLDPASS.TabIndex = 0
        Me.txtOLDPASS.Tag = "OLDPASS"
        Me.txtOLDPASS.Text = ""
        '
        'lblOLDPASS
        '
        Me.lblOLDPASS.AutoSize = True
        Me.lblOLDPASS.Location = New System.Drawing.Point(10, 22)
        Me.lblOLDPASS.Name = "lblOLDPASS"
        Me.lblOLDPASS.Size = New System.Drawing.Size(63, 17)
        Me.lblOLDPASS.TabIndex = 1
        Me.lblOLDPASS.Tag = "OLDPASS"
        Me.lblOLDPASS.Text = "lblOLDPASS"
        Me.lblOLDPASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(274, 50)
        Me.Panel1.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(62, 17)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Tag = "Caption"
        Me.lblCaption.Text = "lblCaption"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.txtCOFPASS)
        Me.grbInfo.Controls.Add(Me.txtPASS)
        Me.grbInfo.Controls.Add(Me.lblCOFPASS)
        Me.grbInfo.Controls.Add(Me.lblPASS)
        Me.grbInfo.Controls.Add(Me.lblOLDPASS)
        Me.grbInfo.Controls.Add(Me.txtOLDPASS)
        Me.grbInfo.Location = New System.Drawing.Point(5, 55)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(265, 110)
        Me.grbInfo.TabIndex = 0
        Me.grbInfo.TabStop = False
        Me.grbInfo.Text = "grbInfo"
        '
        'txtCOFPASS
        '
        Me.txtCOFPASS.Location = New System.Drawing.Point(105, 80)
        Me.txtCOFPASS.Name = "txtCOFPASS"
        Me.txtCOFPASS.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtCOFPASS.Size = New System.Drawing.Size(150, 21)
        Me.txtCOFPASS.TabIndex = 2
        Me.txtCOFPASS.Tag = "COFPASS"
        Me.txtCOFPASS.Text = ""
        '
        'txtPASS
        '
        Me.txtPASS.Location = New System.Drawing.Point(105, 50)
        Me.txtPASS.Name = "txtPASS"
        Me.txtPASS.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPASS.Size = New System.Drawing.Size(150, 21)
        Me.txtPASS.TabIndex = 1
        Me.txtPASS.Tag = "PASS"
        Me.txtPASS.Text = ""
        '
        'lblCOFPASS
        '
        Me.lblCOFPASS.AutoSize = True
        Me.lblCOFPASS.Location = New System.Drawing.Point(10, 82)
        Me.lblCOFPASS.Name = "lblCOFPASS"
        Me.lblCOFPASS.Size = New System.Drawing.Size(62, 17)
        Me.lblCOFPASS.TabIndex = 3
        Me.lblCOFPASS.Tag = "COFPASS"
        Me.lblCOFPASS.Text = "lblCOFPASS"
        Me.lblCOFPASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPASS
        '
        Me.lblPASS.AutoSize = True
        Me.lblPASS.Location = New System.Drawing.Point(10, 52)
        Me.lblPASS.Name = "lblPASS"
        Me.lblPASS.Size = New System.Drawing.Size(41, 17)
        Me.lblPASS.TabIndex = 2
        Me.lblPASS.Tag = "PASS"
        Me.lblPASS.Text = "lblPASS"
        Me.lblPASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(115, 175)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 1
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(195, 175)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'frmChangePassword
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(274, 203)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grbInfo)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChangePassword"
        Me.Panel1.ResumeLayout(False)
        Me.grbInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strBranchId As String
    Private mv_strBranchName As String
    Private mv_strTellerId As String
    Private mv_strTellerName As String
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

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property BranchName() As String
        Get
            Return mv_strBranchName
        End Get
        Set(ByVal Value As String)
            mv_strBranchName = Value
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
#End Region

#Region " Overridable methods "
    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmChangePassword-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
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
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmChangePassword." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmChangePassword." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmChangePassword." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmChangePassword." & v_ctrl.Name)
                End If
            Next

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmChangePassword")
            lblCaption.Text = mv_ResourceManager.GetString("frmChangePassword.lblCaption") & TellerName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub OnSave()
        Dim v_strObjMsg As String
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource, v_strErrorMessage As String
        If ValidateChangePass() Then
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , Me.TellerId & "|" & txtOLDPASS.Text.Trim() & "|" & txtPASS.Text.Trim(), "ChangeBOPassword")
            v_lngErrCode = v_ws.Message(v_strObjMsg)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage, Me.UserLanguage)
                MsgBox(v_strErrorMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else
                MsgBox(mv_ResourceManager.GetString("frmChangePassword." & "SavingSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        End If
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

#End Region

#Region "Utils Methods"
    Protected Function ValidateChangePass() As Boolean
        If txtOLDPASS.Text.Trim.Length <= 0 OrElse txtPASS.Text.Trim.Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("frmChangePassword." & "PasswordEmptyMsg"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return False
        End If

        If txtCOFPASS.Text.Trim() <> txtPASS.Text.Trim() Then
            MsgBox(mv_ResourceManager.GetString("frmChangePassword." & "PasswordNotMatch"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return False
        End If

        Return True
    End Function
#End Region

#Region " Form events "
    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSave()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub
#End Region

    
End Class
