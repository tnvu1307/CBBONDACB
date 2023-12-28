Public Class frmSplash
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picSplash As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
    Me.Label2 = New System.Windows.Forms.Label
    Me.picSplash = New System.Windows.Forms.PictureBox
    CType(Me.picSplash, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Location = New System.Drawing.Point(224, 160)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Loading..."
    '
    'picSplash
    '
    Me.picSplash.BackColor = System.Drawing.Color.White
    Me.picSplash.Dock = System.Windows.Forms.DockStyle.Fill
    Me.picSplash.Image = CType(resources.GetObject("picSplash.Image"), System.Drawing.Image)
    Me.picSplash.InitialImage = Nothing
    Me.picSplash.Location = New System.Drawing.Point(0, 0)
    Me.picSplash.Name = "picSplash"
    Me.picSplash.Size = New System.Drawing.Size(500, 300)
    Me.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picSplash.TabIndex = 2
    Me.picSplash.TabStop = False
    '
    'frmSplash
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(500, 300)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.picSplash)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "frmSplash"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "frmSplash"
    CType(Me.picSplash, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

End Class
