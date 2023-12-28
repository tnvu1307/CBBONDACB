<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraCriterial
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXtraCriterial))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataTable47 = New System.Data.DataTable()
        Me.sbSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection()
        Me.fcCriterial = New AppCore.Controls.XtraUcCriterial()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.fcCriterial, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.sbSearch, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.sbCancel, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(580, 309)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'DataTable47
        '
        Me.DataTable47.Namespace = ""
        Me.DataTable47.TableName = "COMBOBOX"
        '
        'sbSearch
        '
        Me.sbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSearch.ImageIndex = 0
        Me.sbSearch.ImageList = Me.ImageCollection1
        Me.sbSearch.Location = New System.Drawing.Point(403, 276)
        Me.sbSearch.Name = "sbSearch"
        Me.sbSearch.Size = New System.Drawing.Size(84, 25)
        Me.sbSearch.TabIndex = 1
        Me.sbSearch.Text = "Tìm kiếm"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.ImageIndex = 1
        Me.sbCancel.ImageList = Me.ImageCollection1
        Me.sbCancel.Location = New System.Drawing.Point(493, 276)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(84, 25)
        Me.sbCancel.TabIndex = 2
        Me.sbCancel.Text = "Hủy"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.InsertGalleryImage("zoom_16x16.png", "images/zoom/zoom_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/zoom/zoom_16x16.png"), 0)
        Me.ImageCollection1.Images.SetKeyName(0, "zoom_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 1)
        Me.ImageCollection1.Images.SetKeyName(1, "cancel_16x16.png")
        '
        'fcCriterial
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.fcCriterial, 4)
        Me.fcCriterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fcCriterial.Location = New System.Drawing.Point(0, 0)
        Me.fcCriterial.Margin = New System.Windows.Forms.Padding(0)
        Me.fcCriterial.Name = "fcCriterial"
        Me.fcCriterial.Size = New System.Drawing.Size(580, 269)
        Me.fcCriterial.TabIndex = 0
        '
        'frmXtraCriterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 309)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmXtraCriterial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tìm kiếm nâng cao"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents fcCriterial As AppCore.Controls.XtraUcCriterial
    Friend WithEvents DataTable47 As System.Data.DataTable
    Friend WithEvents sbSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
End Class
