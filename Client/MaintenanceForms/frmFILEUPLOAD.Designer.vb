<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFILEUPLOAD
    Inherits AppCore.frmXtraMaintenance

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFILEUPLOAD))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grBANK = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBUSINESS = New DevExpress.XtraEditors.LabelControl()
        Me.teFULLNAME = New DevExpress.XtraEditors.TextEdit()
        Me.lblFULLNAME = New DevExpress.XtraEditors.LabelControl()
        Me.lueBUSINESS = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblDOCTYPE = New DevExpress.XtraEditors.LabelControl()
        Me.txtAUTOID = New DevExpress.XtraEditors.TextEdit()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFileUpload = New AppCore.ButtonEditCustom()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.panelPreview = New System.Windows.Forms.Panel()
        Me.picture1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnDownLoad = New DevExpress.XtraBars.BarButtonItem()
        Me.lblCONTRACTNO = New DevExpress.XtraEditors.LabelControl()
        Me.lueDOCTYPE = New DevExpress.XtraEditors.LookUpEdit()
        Me.teCONTRACTNO = New DevExpress.XtraEditors.TextEdit()
        Me.lblTICKER = New DevExpress.XtraEditors.LabelControl()
        Me.lueTICKER = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCLIENT = New DevExpress.XtraEditors.LabelControl()
        Me.lblCREATEDATE = New DevExpress.XtraEditors.LabelControl()
        Me.deCREATEDATE = New DevExpress.XtraEditors.DateEdit()
        Me.lblTLID = New DevExpress.XtraEditors.LabelControl()
        Me.lueTLID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblTXDATE = New DevExpress.XtraEditors.LabelControl()
        Me.deTXDATE = New DevExpress.XtraEditors.DateEdit()
        Me.lblTXNUM = New DevExpress.XtraEditors.LabelControl()
        Me.teTXNUM = New DevExpress.XtraEditors.TextEdit()
        Me.lblNOTE = New DevExpress.XtraEditors.LabelControl()
        Me.teNOTE = New DevExpress.XtraEditors.TextEdit()
        Me.teCLIENT = New DevExpress.XtraEditors.TextEdit()
        Me.lblClientName = New DevExpress.XtraEditors.LabelControl()
        Me.lblCUSTODYCD = New DevExpress.XtraEditors.LabelControl()
        Me.teCUSTODYCD = New DevExpress.XtraEditors.TextEdit()
        Me.popmenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.DataTable46 = New System.Data.DataTable()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grBANK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBANK.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.teFULLNAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueBUSINESS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.txtFileUpload.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.panelPreview.SuspendLayout()
        CType(Me.picture1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDOCTYPE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCONTRACTNO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueTICKER.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCREATEDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCREATEDATE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueTLID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTXDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTXDATE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teTXNUM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teNOTE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCLIENT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCUSTODYCD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grBANK, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 611.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(917, 611)
        Me.TableLayoutPanel1.TabIndex = 1
        Me.TableLayoutPanel1.Tag = "TableLayoutPanel1"
        '
        'grBANK
        '
        Me.grBANK.Controls.Add(Me.TableLayoutPanel2)
        Me.grBANK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grBANK.Location = New System.Drawing.Point(3, 3)
        Me.grBANK.Name = "grBANK"
        Me.grBANK.Size = New System.Drawing.Size(911, 605)
        Me.grBANK.TabIndex = 0
        Me.grBANK.Tag = "grBANK"
        Me.grBANK.Text = "GroupControl1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblBUSINESS, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.teFULLNAME, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFULLNAME, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lueBUSINESS, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDOCTYPE, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAUTOID, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCONTRACTNO, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lueDOCTYPE, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.teCONTRACTNO, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTICKER, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lueTICKER, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelControl1, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCLIENT, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCREATEDATE, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.deCREATEDATE, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTLID, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lueTLID, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTXDATE, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.deTXDATE, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTXNUM, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.teTXNUM, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNOTE, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.teNOTE, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.teCLIENT, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblClientName, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCUSTODYCD, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.teCUSTODYCD, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 10
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 424.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(907, 582)
        Me.TableLayoutPanel2.TabIndex = 0
        Me.TableLayoutPanel2.Tag = "TableLayoutPanel2"
        '
        'lblBUSINESS
        '
        Me.lblBUSINESS.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBUSINESS.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblBUSINESS.Location = New System.Drawing.Point(3, 6)
        Me.lblBUSINESS.Name = "lblBUSINESS"
        Me.lblBUSINESS.Size = New System.Drawing.Size(124, 13)
        Me.lblBUSINESS.TabIndex = 0
        Me.lblBUSINESS.Tag = "BUSINESS"
        Me.lblBUSINESS.Text = "lblBUSINESS"
        '
        'teFULLNAME
        '
        Me.teFULLNAME.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.teFULLNAME.Location = New System.Drawing.Point(586, 28)
        Me.teFULLNAME.Name = "teFULLNAME"
        Me.teFULLNAME.Size = New System.Drawing.Size(318, 20)
        Me.teFULLNAME.TabIndex = 3
        Me.teFULLNAME.Tag = "FULLNAME"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFULLNAME.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblFULLNAME.Location = New System.Drawing.Point(456, 28)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(124, 19)
        Me.lblFULLNAME.TabIndex = 9
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'lueBUSINESS
        '
        Me.lueBUSINESS.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lueBUSINESS.Location = New System.Drawing.Point(133, 3)
        Me.lueBUSINESS.Name = "lueBUSINESS"
        Me.lueBUSINESS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueBUSINESS.Size = New System.Drawing.Size(317, 20)
        Me.lueBUSINESS.TabIndex = 1
        Me.lueBUSINESS.Tag = "BUSINESS"
        '
        'lblDOCTYPE
        '
        Me.lblDOCTYPE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDOCTYPE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDOCTYPE.Location = New System.Drawing.Point(456, 6)
        Me.lblDOCTYPE.Name = "lblDOCTYPE"
        Me.lblDOCTYPE.Size = New System.Drawing.Size(124, 13)
        Me.lblDOCTYPE.TabIndex = 18
        Me.lblDOCTYPE.Tag = "DOCTYPE"
        Me.lblDOCTYPE.Text = "lblFILENAME"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAUTOID.Location = New System.Drawing.Point(3, 2610)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(124, 20)
        Me.txtAUTOID.TabIndex = 9
        Me.txtAUTOID.Tag = "AUTOID"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 3)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.53846!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.46154!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnSave, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFileUpload, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.SimpleButton1, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(133, 178)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(771, 29)
        Me.TableLayoutPanel3.TabIndex = 20
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(545, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "Save file"
        '
        'txtFileUpload
        '
        Me.txtFileUpload.ActionControl = AppCore.ButtonEditCustom.ActionEnum.ADD
        Me.txtFileUpload.DataByte = Nothing
        Me.txtFileUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFileUpload.Location = New System.Drawing.Point(3, 3)
        Me.txtFileUpload.Name = "txtFileUpload"
        Me.txtFileUpload.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtFileUpload.Properties.ReadOnly = True
        Me.txtFileUpload.Size = New System.Drawing.Size(536, 20)
        Me.txtFileUpload.TabIndex = 0
        Me.txtFileUpload.Tag = "FILEBLOB"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(651, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(117, 23)
        Me.SimpleButton1.TabIndex = 13
        Me.SimpleButton1.Text = "Browse"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Controls.Add(Me.panelPreview)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.TableLayoutPanel2.SetRowSpan(Me.GroupBox1, 100)
        Me.GroupBox1.Size = New System.Drawing.Size(901, 812)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Preview"
        '
        'panelPreview
        '
        Me.panelPreview.Controls.Add(Me.picture1)
        Me.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelPreview.Location = New System.Drawing.Point(3, 17)
        Me.panelPreview.Name = "panelPreview"
        Me.panelPreview.Size = New System.Drawing.Size(895, 792)
        Me.panelPreview.TabIndex = 0
        '
        'picture1
        '
        Me.picture1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picture1.Location = New System.Drawing.Point(222, 20)
        Me.picture1.MenuManager = Me.BarManager1
        Me.picture1.Name = "picture1"
        Me.picture1.Size = New System.Drawing.Size(408, 206)
        Me.picture1.TabIndex = 1
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnDownLoad})
        Me.BarManager1.MaxItemId = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(917, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 705)
        Me.barDockControlBottom.Size = New System.Drawing.Size(917, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 705)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(917, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 705)
        '
        'btnDownLoad
        '
        Me.btnDownLoad.Caption = "Download file"
        Me.btnDownLoad.Id = 0
        Me.btnDownLoad.Name = "btnDownLoad"
        '
        'lblCONTRACTNO
        '
        Me.lblCONTRACTNO.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCONTRACTNO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCONTRACTNO.Location = New System.Drawing.Point(3, 56)
        Me.lblCONTRACTNO.Name = "lblCONTRACTNO"
        Me.lblCONTRACTNO.Size = New System.Drawing.Size(124, 13)
        Me.lblCONTRACTNO.TabIndex = 7
        Me.lblCONTRACTNO.Tag = "CONTRACTNO"
        Me.lblCONTRACTNO.Text = "lblCONTRACTNO"
        '
        'lueDOCTYPE
        '
        Me.lueDOCTYPE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lueDOCTYPE.Location = New System.Drawing.Point(586, 3)
        Me.lueDOCTYPE.Name = "lueDOCTYPE"
        Me.lueDOCTYPE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDOCTYPE.Size = New System.Drawing.Size(318, 20)
        Me.lueDOCTYPE.TabIndex = 2
        Me.lueDOCTYPE.Tag = "DOCTYPE"
        '
        'teCONTRACTNO
        '
        Me.teCONTRACTNO.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.teCONTRACTNO.Location = New System.Drawing.Point(133, 53)
        Me.teCONTRACTNO.Name = "teCONTRACTNO"
        Me.teCONTRACTNO.Size = New System.Drawing.Size(317, 20)
        Me.teCONTRACTNO.TabIndex = 5
        Me.teCONTRACTNO.Tag = "CONTRACTNO"
        '
        'lblTICKER
        '
        Me.lblTICKER.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTICKER.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTICKER.Location = New System.Drawing.Point(456, 56)
        Me.lblTICKER.Name = "lblTICKER"
        Me.lblTICKER.Size = New System.Drawing.Size(124, 13)
        Me.lblTICKER.TabIndex = 7
        Me.lblTICKER.Tag = "TICKER"
        Me.lblTICKER.Text = "lblTICKER"
        '
        'lueTICKER
        '
        Me.lueTICKER.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lueTICKER.Location = New System.Drawing.Point(586, 53)
        Me.lueTICKER.Name = "lueTICKER"
        Me.lueTICKER.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueTICKER.Size = New System.Drawing.Size(318, 20)
        Me.lueTICKER.TabIndex = 6
        Me.lueTICKER.Tag = "TICKER"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(3, 186)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(124, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Tag = "FILEBLOB"
        Me.LabelControl1.Text = "lblUPLOAD"
        '
        'lblCLIENT
        '
        Me.lblCLIENT.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCLIENT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCLIENT.Location = New System.Drawing.Point(3, 81)
        Me.lblCLIENT.Name = "lblCLIENT"
        Me.lblCLIENT.Size = New System.Drawing.Size(124, 13)
        Me.lblCLIENT.TabIndex = 7
        Me.lblCLIENT.Tag = "CLIENT"
        Me.lblCLIENT.Text = "lblCLIENT"
        '
        'lblCREATEDATE
        '
        Me.lblCREATEDATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCREATEDATE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCREATEDATE.Location = New System.Drawing.Point(3, 106)
        Me.lblCREATEDATE.Name = "lblCREATEDATE"
        Me.lblCREATEDATE.Size = New System.Drawing.Size(124, 13)
        Me.lblCREATEDATE.TabIndex = 7
        Me.lblCREATEDATE.Tag = "CREATEDATE"
        Me.lblCREATEDATE.Text = "lblCREATEDATE"
        '
        'deCREATEDATE
        '
        Me.deCREATEDATE.EditValue = Nothing
        Me.deCREATEDATE.Enabled = False
        Me.deCREATEDATE.Location = New System.Drawing.Point(133, 103)
        Me.deCREATEDATE.Name = "deCREATEDATE"
        Me.deCREATEDATE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCREATEDATE.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCREATEDATE.Size = New System.Drawing.Size(223, 20)
        Me.deCREATEDATE.TabIndex = 8
        Me.deCREATEDATE.Tag = "CREATEDATE"
        '
        'lblTLID
        '
        Me.lblTLID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTLID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTLID.Location = New System.Drawing.Point(456, 106)
        Me.lblTLID.Name = "lblTLID"
        Me.lblTLID.Size = New System.Drawing.Size(124, 13)
        Me.lblTLID.TabIndex = 7
        Me.lblTLID.Tag = "TLID"
        Me.lblTLID.Text = "lblTLID"
        '
        'lueTLID
        '
        Me.lueTLID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lueTLID.Enabled = False
        Me.lueTLID.Location = New System.Drawing.Point(586, 103)
        Me.lueTLID.Name = "lueTLID"
        Me.lueTLID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueTLID.Size = New System.Drawing.Size(318, 20)
        Me.lueTLID.TabIndex = 9
        Me.lueTLID.Tag = "TLID"
        '
        'lblTXDATE
        '
        Me.lblTXDATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTXDATE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTXDATE.Location = New System.Drawing.Point(3, 131)
        Me.lblTXDATE.Name = "lblTXDATE"
        Me.lblTXDATE.Size = New System.Drawing.Size(124, 13)
        Me.lblTXDATE.TabIndex = 7
        Me.lblTXDATE.Tag = "TXDATE"
        Me.lblTXDATE.Text = "lblTXDATE"
        '
        'deTXDATE
        '
        Me.deTXDATE.EditValue = Nothing
        Me.deTXDATE.Location = New System.Drawing.Point(133, 128)
        Me.deTXDATE.Name = "deTXDATE"
        Me.deTXDATE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTXDATE.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTXDATE.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.deTXDATE.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deTXDATE.Size = New System.Drawing.Size(223, 20)
        Me.deTXDATE.TabIndex = 10
        Me.deTXDATE.Tag = "TXDATE"
        '
        'lblTXNUM
        '
        Me.lblTXNUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTXNUM.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTXNUM.Location = New System.Drawing.Point(456, 131)
        Me.lblTXNUM.Name = "lblTXNUM"
        Me.lblTXNUM.Size = New System.Drawing.Size(124, 13)
        Me.lblTXNUM.TabIndex = 7
        Me.lblTXNUM.Tag = "TXNUM"
        Me.lblTXNUM.Text = "lblTXNUM"
        '
        'teTXNUM
        '
        Me.teTXNUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.teTXNUM.Location = New System.Drawing.Point(586, 128)
        Me.teTXNUM.Name = "teTXNUM"
        Me.teTXNUM.Size = New System.Drawing.Size(318, 20)
        Me.teTXNUM.TabIndex = 11
        Me.teTXNUM.Tag = "TXNUM"
        '
        'lblNOTE
        '
        Me.lblNOTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNOTE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNOTE.Location = New System.Drawing.Point(3, 156)
        Me.lblNOTE.Name = "lblNOTE"
        Me.lblNOTE.Size = New System.Drawing.Size(124, 13)
        Me.lblNOTE.TabIndex = 7
        Me.lblNOTE.Tag = "NOTE"
        Me.lblNOTE.Text = "lblNOTE"
        '
        'teNOTE
        '
        Me.teNOTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.teNOTE, 3)
        Me.teNOTE.Location = New System.Drawing.Point(133, 153)
        Me.teNOTE.Name = "teNOTE"
        Me.teNOTE.Size = New System.Drawing.Size(771, 20)
        Me.teNOTE.TabIndex = 12
        Me.teNOTE.Tag = "NOTE"
        '
        'teCLIENT
        '
        Me.teCLIENT.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.teCLIENT.Location = New System.Drawing.Point(133, 78)
        Me.teCLIENT.Name = "teCLIENT"
        Me.teCLIENT.Size = New System.Drawing.Size(317, 20)
        Me.teCLIENT.TabIndex = 7
        Me.teCLIENT.Tag = "CLIENT"
        '
        'lblClientName
        '
        Me.lblClientName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClientName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.TableLayoutPanel2.SetColumnSpan(Me.lblClientName, 2)
        Me.lblClientName.Location = New System.Drawing.Point(456, 81)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(448, 13)
        Me.lblClientName.TabIndex = 7
        Me.lblClientName.Tag = ""
        Me.lblClientName.Text = "ClientName"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCUSTODYCD.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(3, 31)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(124, 13)
        Me.lblCUSTODYCD.TabIndex = 14
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'teCUSTODYCD
        '
        Me.teCUSTODYCD.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.teCUSTODYCD.Location = New System.Drawing.Point(133, 28)
        Me.teCUSTODYCD.Name = "teCUSTODYCD"
        Me.teCUSTODYCD.Size = New System.Drawing.Size(317, 20)
        Me.teCUSTODYCD.TabIndex = 4
        Me.teCUSTODYCD.Tag = "CUSTODYCD"
        '
        'popmenu
        '
        Me.popmenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDownLoad)})
        Me.popmenu.Manager = Me.BarManager1
        Me.popmenu.Name = "popmenu"
        '
        'DataTable46
        '
        Me.DataTable46.Namespace = ""
        Me.DataTable46.TableName = "COMBOBOX"
        '
        'frmFILEUPLOAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 705)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmFILEUPLOAD"
        Me.Tag = "frmFILEUPLOAD"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.barDockControlTop, 0)
        Me.Controls.SetChildIndex(Me.barDockControlBottom, 0)
        Me.Controls.SetChildIndex(Me.barDockControlRight, 0)
        Me.Controls.SetChildIndex(Me.barDockControlLeft, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grBANK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBANK.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.teFULLNAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueBUSINESS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.txtFileUpload.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.panelPreview.ResumeLayout(False)
        CType(Me.picture1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDOCTYPE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCONTRACTNO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueTICKER.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCREATEDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCREATEDATE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueTLID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTXDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTXDATE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teTXNUM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teNOTE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCLIENT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCUSTODYCD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grBANK As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBUSINESS As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCONTRACTNO As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFULLNAME As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAUTOID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueBUSINESS As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblCUSTODYCD As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDOCTYPE As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtFileUpload As AppCore.ButtonEditCustom
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents panelPreview As System.Windows.Forms.Panel
    Friend WithEvents lueDOCTYPE As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents teFULLNAME As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teCUSTODYCD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teCONTRACTNO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTICKER As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueTICKER As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblCLIENT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCREATEDATE As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deCREATEDATE As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTLID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueTLID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblTXDATE As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deTXDATE As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTXNUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teTXNUM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNOTE As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teNOTE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teCLIENT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblClientName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents popmenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents DataTable46 As System.Data.DataTable
    Friend WithEvents btnDownLoad As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picture1 As DevExpress.XtraEditors.PictureEdit
End Class
