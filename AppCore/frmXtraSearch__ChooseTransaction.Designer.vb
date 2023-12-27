<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraSearch__ChooseTransaction
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grcChooseTransaction = New DevExpress.XtraGrid.GridControl()
        Me.grvChooseTransaction = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1.SuspendLayout()
        CType(Me.grcChooseTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChooseTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grcChooseTransaction)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 267)
        Me.Panel1.TabIndex = 0
        '
        'grcChooseTransaction
        '
        Me.grcChooseTransaction.Cursor = System.Windows.Forms.Cursors.Default
        Me.grcChooseTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grcChooseTransaction.Location = New System.Drawing.Point(0, 0)
        Me.grcChooseTransaction.MainView = Me.grvChooseTransaction
        Me.grcChooseTransaction.Name = "grcChooseTransaction"
        Me.grcChooseTransaction.Size = New System.Drawing.Size(443, 267)
        Me.grcChooseTransaction.TabIndex = 0
        Me.grcChooseTransaction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChooseTransaction})
        '
        'grvChooseTransaction
        '
        Me.grvChooseTransaction.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvChooseTransaction.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvChooseTransaction.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.grvChooseTransaction.GridControl = Me.grcChooseTransaction
        Me.grvChooseTransaction.Name = "grvChooseTransaction"
        Me.grvChooseTransaction.OptionsView.ShowAutoFilterRow = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Transaction Code"
        Me.GridColumn1.FieldName = "TRANSACTION_CODE"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 107
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Transaction Name"
        Me.GridColumn2.FieldName = "TRANSACTION_NAME"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 318
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnChoose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 225)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(443, 42)
        Me.Panel2.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.Location = New System.Drawing.Point(361, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(71, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnChoose.Location = New System.Drawing.Point(280, 11)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(75, 23)
        Me.btnChoose.TabIndex = 0
        Me.btnChoose.Text = "Choose"
        '
        'frmXtraSearch__ChooseTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 267)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmXtraSearch__ChooseTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose Transaction"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grcChooseTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChooseTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grcChooseTransaction As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChooseTransaction As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChoose As DevExpress.XtraEditors.SimpleButton
End Class
