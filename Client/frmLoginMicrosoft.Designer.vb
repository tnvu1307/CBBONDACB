<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginMicrosoft
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.wbLoginMicrosoft = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbLoginMicrosoft
        '
        Me.wbLoginMicrosoft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbLoginMicrosoft.Location = New System.Drawing.Point(0, 0)
        Me.wbLoginMicrosoft.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbLoginMicrosoft.Name = "wbLoginMicrosoft"
        Me.wbLoginMicrosoft.Size = New System.Drawing.Size(800, 450)
        Me.wbLoginMicrosoft.TabIndex = 0
        '
        'frmLoginMicrosoft
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.wbLoginMicrosoft)
        Me.Name = "frmLoginMicrosoft"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login with Microsoft account"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wbLoginMicrosoft As WebBrowser
End Class
