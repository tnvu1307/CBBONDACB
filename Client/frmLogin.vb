Imports Microsoft.Win32
Imports CommonLibrary

Public Class frmLogin
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal bl As CBusLayer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_BusLayer = bl
        m_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "Localize-" & m_BusLayer.AppLanguage, System.Reflection.Assembly.GetExecutingAssembly())
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cbRemember As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cbRemember = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 50)
        Me.Panel1.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(72, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Enter your user name and password."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "User name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password:"
        '
        'txtUserName
        '
        Me.txtUserName.AccessibleDescription = "User Name"
        Me.txtUserName.AccessibleName = "User Name"
        Me.txtUserName.Location = New System.Drawing.Point(104, 62)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(248, 21)
        Me.txtUserName.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = "Password"
        Me.txtPassword.AccessibleName = "Password"
        Me.txtPassword.Location = New System.Drawing.Point(104, 96)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(248, 21)
        Me.txtPassword.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = "OK"
        Me.btnOK.AccessibleName = "OK"
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(128, 152)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = "Cancel"
        Me.btnCancel.AccessibleName = "Cancel"
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(240, 152)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'cbRemember
        '
        Me.cbRemember.AccessibleDescription = "Remember password"
        Me.cbRemember.AccessibleName = "Remember password"
        Me.cbRemember.Checked = True
        Me.cbRemember.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRemember.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbRemember.Location = New System.Drawing.Point(104, 126)
        Me.cbRemember.Name = "cbRemember"
        Me.cbRemember.Size = New System.Drawing.Size(248, 16)
        Me.cbRemember.TabIndex = 2
        Me.cbRemember.Text = "Remember user name."
        Me.cbRemember.Visible = False
        '
        'frmLogin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(362, 183)
        Me.Controls.Add(Me.cbRemember)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private m_BusLayer As CBusLayer
    Private m_ResourceManager As Resources.ResourceManager

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        '#If DEBUG Then
        Dim v_strUserName As String = String.Empty
        Dim v_strPassword As String = String.Empty

        Try

            cbRemember.Visible = True

            Dim v_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(gc_RegistryKey)

            If Not v_regKey Is Nothing Then
                v_strUserName = CType(v_regKey.GetValue("UserName"), String)
                'v_strPassword = DataProtection.UnprotectData(CType(v_regKey.GetValue("Password"), String))
                v_strPassword = CStr(v_regKey.GetValue("Password"))

                v_regKey.Close()
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbCrLf & ex.StackTrace, EventLogEntryType.Error)
        End Try

        If v_strUserName <> String.Empty AndAlso v_strPassword <> String.Empty Then

            txtUserName.Text = v_strUserName
            ' 03/08/2015 DieuNDA: He thong chi luu lai username ko cho luu lai password
            txtPassword.Text = String.Empty 'v_strPassword
            cbRemember.Checked = True

        End If
        '#End If

        Me.Activate()
        txtUserName.Focus()
    End Sub

    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus
        With txtUserName
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.KeyPress

    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        With txtPassword
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DoConfirm()
    End Sub

    Private Sub frmLogin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If Me.btnOK.Focused Then
                    DoConfirm()
                ElseIf Me.txtUserName.Focused Then
                    Me.txtPassword.Focus()
                    Me.txtPassword.SelectAll()
                ElseIf Me.txtPassword.Focused Then
                    Me.btnOK.Focus()
                    'Else
                    '    SendKeys.Send("{Tab}")
                    '    e.Handled = True
                End If

        End Select
    End Sub

    Private Sub DoConfirm()
        'GetVersion()
        Me.DialogResult = DialogResult.None

        If txtUserName.Text.Trim() <> String.Empty AndAlso txtPassword.Text.Trim() <> String.Empty Then
            MyBase.Cursor = Cursors.WaitCursor
            'Dim blResult As BusLayerResult = m_BusLayer.Login(txtUserName.Text, DataProtection.ProtectData(txtPassword.Text, GetMACAddress()))
            Dim blResult As BusLayerResult = m_BusLayer.Login(txtUserName.Text, txtPassword.Text)
            MyBase.Cursor = Cursors.Arrow

            If blResult = BusLayerResult.Success Then


                '#If DEBUG Then
                'Vào hệ thống thành công, lưu lại mã truy cập và mật khẩu nếu cần
                Try
                    Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey)

                    If cbRemember.Checked Then
                        v_regKey.SetValue(gc_REG_USERNAME, txtUserName.Text)
                        'v_regKey.SetValue(gc_REG_PASSWORD, DataProtection.ProtectData(txtPassword.Text, GetMACAddress()))
                        v_regKey.SetValue(gc_REG_PASSWORD, txtPassword.Text)
                    Else
                        v_regKey.DeleteValue(gc_REG_USERNAME, False)
                        v_regKey.DeleteValue(gc_REG_PASSWORD, False)
                    End If
                    v_regKey.Close()
                Catch ex As Exception
                    LogError.Write(ex.Message & vbCrLf & ex.StackTrace, EventLogEntryType.Error)
                End Try
                '#End If
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                txtUserName.SelectAll()
                txtUserName.Focus()

                If blResult = BusLayerResult.ServiceFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_SVR_ERROR) & " " & m_ResourceManager.GetString(gc_SYSERR_CONTACT_NET_ADMIN), _
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ElseIf blResult = BusLayerResult.ConnectionFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_SRV_UNREACHABLE) & " " & m_ResourceManager.GetString(gc_SYSERR_CHECK_CONNECTION), _
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ElseIf blResult = BusLayerResult.AuthenticationFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_INCORRECT_USR_OR_PWD) & " " & m_ResourceManager.GetString(gc_SYSERR_RE_TYPE), _
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_UNKNOWN_ERROR) & " " & m_ResourceManager.GetString(gc_SYSERR_CHECK_EVENT_LOG), _
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If
        Else
            MsgBox(m_ResourceManager.GetString(gc_SYSERR_RE_TYPE), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub


    Private Sub GetVersion()
        Try
            'Get version from SYSVAL table on BDS
            Dim v_strSQL As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String
            Dim v_Vesion As String = String.Empty

            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'VERSION'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
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
                                v_Vesion = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next

            If Not v_Vesion = "1.0.6.2.1" Then
                MsgBox("Version khong dung, hay cap nhat version moi nhat hoac lien he IT de duoc tro giup", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


End Class
