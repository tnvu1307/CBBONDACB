Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class XtraUcCriterial
        Inherits DevExpress.XtraEditors.XtraUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.fcCriterial = New XtraFilterControl()
            Me.SuspendLayout()
            '
            'fcCriterial
            '
            Me.fcCriterial.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.fcCriterial.Dock = System.Windows.Forms.DockStyle.Fill
            Me.fcCriterial.Location = New System.Drawing.Point(0, 0)
            Me.fcCriterial.Name = "fcCriterial"
            Me.fcCriterial.Size = New System.Drawing.Size(600, 540)
            Me.fcCriterial.TabIndex = 1
            '
            'XtraUcCriterial
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.fcCriterial)
            Me.Name = "XtraUcCriterial"
            Me.Size = New System.Drawing.Size(600, 540)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents fcCriterial As XtraFilterControl

    End Class
End Namespace