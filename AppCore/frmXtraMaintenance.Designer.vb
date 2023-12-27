<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraMaintenance
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mv_blnOnDisplayScreen As Boolean = False
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXtraMaintenance))
        Me.lblCaption = New DevExpress.XtraEditors.LabelControl()
        Me.tlpFooter = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCompare = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboLink = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnApprv = New DevExpress.XtraEditors.SimpleButton()
        Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
        Me.tlpCaption = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpFooter.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLink.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpCaption.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCaption.Location = New System.Drawing.Point(3, 18)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(56, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'tlpFooter
        '
        Me.tlpFooter.ColumnCount = 6
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpFooter.Controls.Add(Me.btnCompare, 2, 0)
        Me.tlpFooter.Controls.Add(Me.btnCancel, 5, 0)
        Me.tlpFooter.Controls.Add(Me.cboLink, 0, 0)
        Me.tlpFooter.Controls.Add(Me.btnOK, 4, 0)
        Me.tlpFooter.Controls.Add(Me.btnApprv, 3, 0)
        Me.tlpFooter.Controls.Add(Me.btnApply, 1, 0)
        Me.tlpFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpFooter.Location = New System.Drawing.Point(0, 330)
        Me.tlpFooter.Name = "tlpFooter"
        Me.tlpFooter.Padding = New System.Windows.Forms.Padding(3)
        Me.tlpFooter.RowCount = 1
        Me.tlpFooter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFooter.Size = New System.Drawing.Size(679, 44)
        Me.tlpFooter.TabIndex = 0
        Me.tlpFooter.Tag = "tlpFooter"
        '
        'btnCompare
        '
        Me.btnCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompare.Image = CType(resources.GetObject("btnCompare.Image"), System.Drawing.Image)
        Me.btnCompare.ImageIndex = 0
        Me.btnCompare.ImageList = Me.ImageCollection1
        Me.btnCompare.Location = New System.Drawing.Point(319, 10)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(84, 23)
        Me.btnCompare.TabIndex = 3
        Me.btnCompare.Tag = "btnCompare"
        Me.btnCompare.Text = "Kiểm tra"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 0)
        Me.ImageCollection1.Images.SetKeyName(0, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 1)
        Me.ImageCollection1.Images.SetKeyName(1, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("next_16x16.png", "images/arrows/next_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/next_16x16.png"), 2)
        Me.ImageCollection1.Images.SetKeyName(2, "next_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 3)
        Me.ImageCollection1.Images.SetKeyName(3, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "save_16x16.png")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.ImageIndex = 3
        Me.btnCancel.ImageList = Me.ImageCollection1
        Me.btnCancel.Location = New System.Drawing.Point(589, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(6, 6)
        Me.cboLink.Name = "cboLink"
        Me.cboLink.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLink.Size = New System.Drawing.Size(94, 20)
        Me.cboLink.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.ImageIndex = 2
        Me.btnOK.ImageList = Me.ImageCollection1
        Me.btnOK.Location = New System.Drawing.Point(499, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(84, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnApprv
        '
        Me.btnApprv.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprv.ImageIndex = 0
        Me.btnApprv.ImageList = Me.ImageCollection1
        Me.btnApprv.Location = New System.Drawing.Point(409, 10)
        Me.btnApprv.Name = "btnApprv"
        Me.btnApprv.Size = New System.Drawing.Size(84, 23)
        Me.btnApprv.TabIndex = 2
        Me.btnApprv.Tag = "btnApprv"
        Me.btnApprv.Text = "btnApprv"
        '
        'btnApply
        '
        Me.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnApply.ImageIndex = 4
        Me.btnApply.ImageList = Me.ImageCollection1
        Me.btnApply.Location = New System.Drawing.Point(229, 10)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(84, 23)
        Me.btnApply.TabIndex = 0
        Me.btnApply.Tag = "btnApply"
        Me.btnApply.Text = "btnApply"
        '
        'tlpCaption
        '
        Me.tlpCaption.BackColor = System.Drawing.Color.LightSkyBlue
        Me.tlpCaption.ColumnCount = 1
        Me.tlpCaption.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCaption.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCaption.Controls.Add(Me.lblCaption, 0, 0)
        Me.tlpCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpCaption.Location = New System.Drawing.Point(0, 0)
        Me.tlpCaption.Name = "tlpCaption"
        Me.tlpCaption.RowCount = 1
        Me.tlpCaption.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCaption.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpCaption.Size = New System.Drawing.Size(679, 50)
        Me.tlpCaption.TabIndex = 0
        '
        'frmXtraMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 374)
        Me.Controls.Add(Me.tlpCaption)
        Me.Controls.Add(Me.tlpFooter)
        Me.KeyPreview = True
        Me.Name = "frmXtraMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmXtraMaintenance"
        Me.tlpFooter.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLink.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpCaption.ResumeLayout(False)
        Me.tlpCaption.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents tlpFooter As System.Windows.Forms.TableLayoutPanel
    Protected WithEvents btnApprv As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.        
        mv_saveButtonType = SaveButtonType.NotButton
    End Sub
    Protected WithEvents lblCaption As DevExpress.XtraEditors.LabelControl
    Protected WithEvents cboLink As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tlpCaption As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Protected WithEvents btnCompare As DevExpress.XtraEditors.SimpleButton
End Class
