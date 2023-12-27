<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraApprove
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReject = New DevExpress.XtraEditors.SimpleButton()
        Me.gridMAINTAIN = New DevExpress.XtraGrid.GridControl()
        Me.grvMAINTAIN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gridMAINTAIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMAINTAIN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnApprove, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnReject, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gridMAINTAIN, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.61834!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.381663!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(667, 469)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(485, 428)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(75, 23)
        Me.btnApprove.TabIndex = 0
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(575, 428)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(392, 428)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 23)
        Me.btnReject.TabIndex = 2
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        '
        'gridMAINTAIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gridMAINTAIN, 4)
        Me.gridMAINTAIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMAINTAIN.Location = New System.Drawing.Point(3, 3)
        Me.gridMAINTAIN.MainView = Me.grvMAINTAIN
        Me.gridMAINTAIN.Name = "gridMAINTAIN"
        Me.gridMAINTAIN.Size = New System.Drawing.Size(661, 419)
        Me.gridMAINTAIN.TabIndex = 3
        Me.gridMAINTAIN.Tag = "gridMAINTAIN"
        Me.gridMAINTAIN.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMAINTAIN})
        '
        'grvMAINTAIN
        '
        Me.grvMAINTAIN.GridControl = Me.gridMAINTAIN
        Me.grvMAINTAIN.Name = "grvMAINTAIN"
        '
        'frmXtraApprove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 469)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmXtraApprove"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmXtraApprove"
        Me.Text = "frmXtraApprove"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.gridMAINTAIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMAINTAIN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReject As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridMAINTAIN As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMAINTAIN As DevExpress.XtraGrid.Views.Grid.GridView
End Class
