Public Class frmAdminMessages
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
    Friend WithEvents grbInMessage As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grbOutMessage As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblTrader As System.Windows.Forms.Label
    Friend WithEvents lblFirm As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grbInMessage = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.grbOutMessage = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.lblTrader = New System.Windows.Forms.Label
        Me.lblFirm = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grbInMessage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 264)
        Me.Panel1.TabIndex = 0
        '
        'grbInMessage
        '
        Me.grbInMessage.BackColor = System.Drawing.Color.Pink
        Me.grbInMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbInMessage.Location = New System.Drawing.Point(0, 0)
        Me.grbInMessage.Name = "grbInMessage"
        Me.grbInMessage.Size = New System.Drawing.Size(792, 264)
        Me.grbInMessage.TabIndex = 0
        Me.grbInMessage.TabStop = False
        Me.grbInMessage.Text = "In Message"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grbOutMessage)
        Me.Panel2.Location = New System.Drawing.Point(0, 272)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 224)
        Me.Panel2.TabIndex = 1
        '
        'grbOutMessage
        '
        Me.grbOutMessage.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.grbOutMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbOutMessage.Location = New System.Drawing.Point(0, 0)
        Me.grbOutMessage.Name = "grbOutMessage"
        Me.grbOutMessage.Size = New System.Drawing.Size(792, 224)
        Me.grbOutMessage.TabIndex = 0
        Me.grbOutMessage.TabStop = False
        Me.grbOutMessage.Text = "Out message"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(64, 510)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(520, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.ForeColor = System.Drawing.Color.Blue
        Me.TextBox2.Location = New System.Drawing.Point(640, 510)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(40, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox3
        '
        Me.TextBox3.ForeColor = System.Drawing.Color.Blue
        Me.TextBox3.Location = New System.Drawing.Point(744, 510)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(40, 20)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "TextBox3"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(0, 512)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(56, 16)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Tag = "Message"
        Me.lblMessage.Text = "Message"
        '
        'lblTrader
        '
        Me.lblTrader.ForeColor = System.Drawing.Color.Blue
        Me.lblTrader.Location = New System.Drawing.Point(696, 512)
        Me.lblTrader.Name = "lblTrader"
        Me.lblTrader.Size = New System.Drawing.Size(40, 17)
        Me.lblTrader.TabIndex = 6
        Me.lblTrader.Text = "Trader"
        '
        'lblFirm
        '
        Me.lblFirm.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblFirm.ForeColor = System.Drawing.Color.Blue
        Me.lblFirm.Location = New System.Drawing.Point(592, 512)
        Me.lblFirm.Name = "lblFirm"
        Me.lblFirm.Size = New System.Drawing.Size(40, 17)
        Me.lblFirm.TabIndex = 7
        Me.lblFirm.Text = "Firm"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(628, 540)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.TabIndex = 4
        Me.btnSend.Tag = "Send"
        Me.btnSend.Text = "&Send"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(712, 540)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 5
        Me.btnExit.Tag = "Exit"
        Me.btnExit.Text = "Exit"
        '
        'frmAdminMessages
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.lblFirm)
        Me.Controls.Add(Me.lblTrader)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAdminMessages"
        Me.Text = "frmAdminMessages"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Private method"
    Private Function OnClose()
        Me.Dispose()
    End Function

#End Region
#Region "Form events"
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        OnClose()
    End Sub
#End Region
End Class
