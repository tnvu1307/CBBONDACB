<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraTransact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXtraTransact))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pcButtonBar = New DevExpress.XtraEditors.PanelControl()
        Me.lblHelper = New DevExpress.XtraEditors.LabelControl()
        Me.btnApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection()
        Me.btnReject = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEntries = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdjust = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCANCEL = New DevExpress.XtraEditors.SimpleButton()
        Me.btnVoucher = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRefuse = New DevExpress.XtraEditors.SimpleButton()
        Me.pcTransactionDetail = New DevExpress.XtraEditors.PanelControl()
        Me.tabTransact = New DevExpress.XtraTab.XtraTabControl()
        Me.tabTranWorkflowLog = New DevExpress.XtraTab.XtraTabPage()
        Me.SearchGrid = New DevExpress.XtraGrid.GridControl()
        Me.gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolTxNum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTxDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolBusDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTxTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTellerId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTellerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDsAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolTxDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolWsName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolLastChange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAutoId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tabAccountEntry = New DevExpress.XtraTab.XtraTabPage()
        Me.SearchAccount = New DevExpress.XtraGrid.GridControl()
        Me.gvaccount = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCACCTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCSUBTXNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEBIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CREDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tabFEEDetails = New DevExpress.XtraTab.XtraTabPage()
        Me.tabVATVoucher = New DevExpress.XtraTab.XtraTabPage()
        Me.pcTransactionCode = New DevExpress.XtraEditors.PanelControl()
        Me.dtpValidateField = New DevExpress.XtraEditors.DateEdit()
        Me.mskTransCode = New DevExpress.XtraEditors.TextEdit()
        Me.lblTransCaption = New DevExpress.XtraEditors.LabelControl()
        Me.lblTransCode = New DevExpress.XtraEditors.LabelControl()
        Me.pnTransDetail = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.stbMain = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.tlpMain.SuspendLayout()
        CType(Me.pcButtonBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcButtonBar.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcTransactionDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcTransactionDetail.SuspendLayout()
        CType(Me.tabTransact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransact.SuspendLayout()
        Me.tabTranWorkflowLog.SuspendLayout()
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAccountEntry.SuspendLayout()
        CType(Me.SearchAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvaccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcTransactionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcTransactionCode.SuspendLayout()
        CType(Me.dtpValidateField.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpValidateField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskTransCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.pcButtonBar, 0, 3)
        Me.tlpMain.Controls.Add(Me.pcTransactionDetail, 0, 2)
        Me.tlpMain.Controls.Add(Me.pcTransactionCode, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnTransDetail, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(866, 445)
        Me.tlpMain.TabIndex = 0
        '
        'pcButtonBar
        '
        Me.pcButtonBar.Controls.Add(Me.lblHelper)
        Me.pcButtonBar.Controls.Add(Me.btnApprove)
        Me.pcButtonBar.Controls.Add(Me.btnReject)
        Me.pcButtonBar.Controls.Add(Me.btnEntries)
        Me.pcButtonBar.Controls.Add(Me.btnAdjust)
        Me.pcButtonBar.Controls.Add(Me.btnOK)
        Me.pcButtonBar.Controls.Add(Me.btnCANCEL)
        Me.pcButtonBar.Controls.Add(Me.btnVoucher)
        Me.pcButtonBar.Controls.Add(Me.btnRefuse)
        Me.pcButtonBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcButtonBar.Location = New System.Drawing.Point(0, 390)
        Me.pcButtonBar.Margin = New System.Windows.Forms.Padding(0)
        Me.pcButtonBar.Name = "pcButtonBar"
        Me.pcButtonBar.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pcButtonBar.Size = New System.Drawing.Size(866, 40)
        Me.pcButtonBar.TabIndex = 3
        '
        'lblHelper
        '
        Me.lblHelper.Location = New System.Drawing.Point(8, 8)
        Me.lblHelper.Name = "lblHelper"
        Me.lblHelper.Size = New System.Drawing.Size(41, 13)
        Me.lblHelper.TabIndex = 1
        Me.lblHelper.Text = "lblHelper"
        '
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 0
        Me.btnApprove.ImageList = Me.ImageCollection1
        Me.btnApprove.Location = New System.Drawing.Point(184, 10)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(80, 23)
        Me.btnApprove.TabIndex = 102
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
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
        Me.ImageCollection1.InsertGalleryImage("clear_16x16.png", "images/actions/clear_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/clear_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "clear_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("deletegroupheader_16x16.png", "images/reports/deletegroupheader_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/reports/deletegroupheader_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "deletegroupheader_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("deletefooter_16x16.png", "images/reports/deletefooter_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/reports/deletefooter_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "deletefooter_16x16.png")
        '
        'btnReject
        '
        Me.btnReject.ImageIndex = 6
        Me.btnReject.ImageList = Me.ImageCollection1
        Me.btnReject.Location = New System.Drawing.Point(270, 10)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(80, 23)
        Me.btnReject.TabIndex = 103
        Me.btnReject.Text = "btnReject"
        '
        'btnEntries
        '
        Me.btnEntries.Location = New System.Drawing.Point(356, 10)
        Me.btnEntries.Name = "btnEntries"
        Me.btnEntries.Size = New System.Drawing.Size(80, 23)
        Me.btnEntries.TabIndex = 104
        Me.btnEntries.Text = "btnEntries"
        '
        'btnAdjust
        '
        Me.btnAdjust.ImageIndex = 4
        Me.btnAdjust.ImageList = Me.ImageCollection1
        Me.btnAdjust.Location = New System.Drawing.Point(442, 10)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(80, 23)
        Me.btnAdjust.TabIndex = 105
        Me.btnAdjust.Text = "btnAdjust"
        '
        'btnOK
        '
        Me.btnOK.ImageIndex = 2
        Me.btnOK.ImageList = Me.ImageCollection1
        Me.btnOK.Location = New System.Drawing.Point(528, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 106
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.ImageIndex = 1
        Me.btnCANCEL.ImageList = Me.ImageCollection1
        Me.btnCANCEL.Location = New System.Drawing.Point(614, 10)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 23)
        Me.btnCANCEL.TabIndex = 107
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'btnVoucher
        '
        Me.btnVoucher.Location = New System.Drawing.Point(12, 10)
        Me.btnVoucher.Name = "btnVoucher"
        Me.btnVoucher.Size = New System.Drawing.Size(80, 23)
        Me.btnVoucher.TabIndex = 100
        Me.btnVoucher.Tag = "btnVoucher"
        Me.btnVoucher.Text = "btnVoucher"
        '
        'btnRefuse
        '
        Me.btnRefuse.ImageIndex = 5
        Me.btnRefuse.ImageList = Me.ImageCollection1
        Me.btnRefuse.Location = New System.Drawing.Point(98, 10)
        Me.btnRefuse.Name = "btnRefuse"
        Me.btnRefuse.Size = New System.Drawing.Size(80, 23)
        Me.btnRefuse.TabIndex = 101
        Me.btnRefuse.Tag = "btnRefuse"
        Me.btnRefuse.Text = "btnRefuse"
        '
        'pcTransactionDetail
        '
        Me.pcTransactionDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pcTransactionDetail.Controls.Add(Me.tabTransact)
        Me.pcTransactionDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcTransactionDetail.Location = New System.Drawing.Point(0, 270)
        Me.pcTransactionDetail.Margin = New System.Windows.Forms.Padding(0)
        Me.pcTransactionDetail.Name = "pcTransactionDetail"
        Me.pcTransactionDetail.Size = New System.Drawing.Size(866, 120)
        Me.pcTransactionDetail.TabIndex = 2
        '
        'tabTransact
        '
        Me.tabTransact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTransact.Location = New System.Drawing.Point(0, 0)
        Me.tabTransact.Name = "tabTransact"
        Me.tabTransact.SelectedTabPage = Me.tabTranWorkflowLog
        Me.tabTransact.Size = New System.Drawing.Size(866, 120)
        Me.tabTransact.TabIndex = 91
        Me.tabTransact.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabTranWorkflowLog, Me.tabAccountEntry, Me.tabFEEDetails, Me.tabVATVoucher})
        '
        'tabTranWorkflowLog
        '
        Me.tabTranWorkflowLog.Controls.Add(Me.SearchGrid)
        Me.tabTranWorkflowLog.Name = "tabTranWorkflowLog"
        Me.tabTranWorkflowLog.Size = New System.Drawing.Size(860, 92)
        Me.tabTranWorkflowLog.Text = "tabTranWorkflowLog"
        '
        'SearchGrid
        '
        Me.SearchGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchGrid.Location = New System.Drawing.Point(0, 0)
        Me.SearchGrid.MainView = Me.gvResult
        Me.SearchGrid.Name = "SearchGrid"
        Me.SearchGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.SearchGrid.Size = New System.Drawing.Size(860, 92)
        Me.SearchGrid.TabIndex = 1
        Me.SearchGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvResult})
        '
        'gvResult
        '
        Me.gvResult.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gvResult.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvResult.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvResult.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvResult.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolTxNum, Me.gcolTxDate, Me.gcolBusDate, Me.gcolTxTime, Me.gcolLevel, Me.gcolDStatus, Me.gcolTellerId, Me.gcolTellerName, Me.gcolDsAction, Me.gcolTxDesc, Me.gcolWsName, Me.gcolLastChange, Me.gcolAutoId})
        Me.gvResult.GridControl = Me.SearchGrid
        Me.gvResult.Name = "gvResult"
        Me.gvResult.OptionsBehavior.Editable = False
        Me.gvResult.OptionsBehavior.ReadOnly = True
        Me.gvResult.OptionsFilter.AllowFilterEditor = False
        Me.gvResult.OptionsView.ColumnAutoWidth = False
        Me.gvResult.OptionsView.ShowGroupPanel = False
        '
        'gcolTxNum
        '
        Me.gcolTxNum.AppearanceCell.Options.UseTextOptions = True
        Me.gcolTxNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolTxNum.Caption = "TXNUM"
        Me.gcolTxNum.FieldName = "TXNUM"
        Me.gcolTxNum.Name = "gcolTxNum"
        Me.gcolTxNum.Visible = True
        Me.gcolTxNum.VisibleIndex = 0
        Me.gcolTxNum.Width = 80
        '
        'gcolTxDate
        '
        Me.gcolTxDate.AppearanceCell.Options.UseTextOptions = True
        Me.gcolTxDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolTxDate.Caption = "TXDATE"
        Me.gcolTxDate.FieldName = "TXDATE"
        Me.gcolTxDate.Name = "gcolTxDate"
        Me.gcolTxDate.Visible = True
        Me.gcolTxDate.VisibleIndex = 1
        Me.gcolTxDate.Width = 80
        '
        'gcolBusDate
        '
        Me.gcolBusDate.AppearanceCell.Options.UseTextOptions = True
        Me.gcolBusDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolBusDate.Caption = "BUSDATE"
        Me.gcolBusDate.FieldName = "BUSDATE"
        Me.gcolBusDate.Name = "gcolBusDate"
        Me.gcolBusDate.Visible = True
        Me.gcolBusDate.VisibleIndex = 2
        Me.gcolBusDate.Width = 80
        '
        'gcolTxTime
        '
        Me.gcolTxTime.AppearanceCell.Options.UseTextOptions = True
        Me.gcolTxTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolTxTime.Caption = "TXTIME"
        Me.gcolTxTime.FieldName = "TXTIME"
        Me.gcolTxTime.Name = "gcolTxTime"
        Me.gcolTxTime.Visible = True
        Me.gcolTxTime.VisibleIndex = 3
        Me.gcolTxTime.Width = 80
        '
        'gcolLevel
        '
        Me.gcolLevel.AppearanceCell.Options.UseTextOptions = True
        Me.gcolLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolLevel.Caption = "LVEL"
        Me.gcolLevel.FieldName = "LVEL"
        Me.gcolLevel.Name = "gcolLevel"
        Me.gcolLevel.Visible = True
        Me.gcolLevel.VisibleIndex = 4
        Me.gcolLevel.Width = 50
        '
        'gcolDStatus
        '
        Me.gcolDStatus.Caption = "DSTATUS"
        Me.gcolDStatus.FieldName = "DSTATUS"
        Me.gcolDStatus.Name = "gcolDStatus"
        Me.gcolDStatus.Visible = True
        Me.gcolDStatus.VisibleIndex = 5
        Me.gcolDStatus.Width = 80
        '
        'gcolTellerId
        '
        Me.gcolTellerId.Caption = "TLID"
        Me.gcolTellerId.FieldName = "TLID"
        Me.gcolTellerId.Name = "gcolTellerId"
        Me.gcolTellerId.Width = 20
        '
        'gcolTellerName
        '
        Me.gcolTellerName.AppearanceCell.Options.UseTextOptions = True
        Me.gcolTellerName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gcolTellerName.Caption = "TLNAME"
        Me.gcolTellerName.FieldName = "TLNAME"
        Me.gcolTellerName.Name = "gcolTellerName"
        Me.gcolTellerName.Visible = True
        Me.gcolTellerName.VisibleIndex = 6
        Me.gcolTellerName.Width = 100
        '
        'gcolDsAction
        '
        Me.gcolDsAction.Caption = "DSACTION"
        Me.gcolDsAction.FieldName = "DSACTION"
        Me.gcolDsAction.Name = "gcolDsAction"
        Me.gcolDsAction.Visible = True
        Me.gcolDsAction.VisibleIndex = 7
        Me.gcolDsAction.Width = 80
        '
        'gcolTxDesc
        '
        Me.gcolTxDesc.Caption = "TXDESC"
        Me.gcolTxDesc.FieldName = "TXDESC"
        Me.gcolTxDesc.Name = "gcolTxDesc"
        Me.gcolTxDesc.Visible = True
        Me.gcolTxDesc.VisibleIndex = 9
        Me.gcolTxDesc.Width = 150
        '
        'gcolWsName
        '
        Me.gcolWsName.Caption = "WSNAME"
        Me.gcolWsName.FieldName = "WSNAME"
        Me.gcolWsName.Name = "gcolWsName"
        Me.gcolWsName.Visible = True
        Me.gcolWsName.VisibleIndex = 8
        Me.gcolWsName.Width = 100
        '
        'gcolLastChange
        '
        Me.gcolLastChange.Caption = "LASTCHANGE"
        Me.gcolLastChange.FieldName = "LASTCHANGE"
        Me.gcolLastChange.Name = "gcolLastChange"
        Me.gcolLastChange.Visible = True
        Me.gcolLastChange.VisibleIndex = 10
        Me.gcolLastChange.Width = 80
        '
        'gcolAutoId
        '
        Me.gcolAutoId.Caption = "AUTOID"
        Me.gcolAutoId.FieldName = "AUTOID"
        Me.gcolAutoId.Name = "gcolAutoId"
        '
        'tabAccountEntry
        '
        Me.tabAccountEntry.Controls.Add(Me.SearchAccount)
        Me.tabAccountEntry.Name = "tabAccountEntry"
        Me.tabAccountEntry.Size = New System.Drawing.Size(860, 92)
        Me.tabAccountEntry.Tag = "TW_AccountEntry"
        Me.tabAccountEntry.Text = "tabAccountEntry"
        '
        'SearchAccount
        '
        Me.SearchAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.SearchAccount.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        GridLevelNode2.RelationName = "Level2"
        GridLevelNode3.RelationName = "Level3"
        Me.SearchAccount.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1, GridLevelNode2, GridLevelNode3})
        Me.SearchAccount.Location = New System.Drawing.Point(0, 0)
        Me.SearchAccount.MainView = Me.gvaccount
        Me.SearchAccount.Name = "SearchAccount"
        Me.SearchAccount.Padding = New System.Windows.Forms.Padding(3)
        Me.SearchAccount.Size = New System.Drawing.Size(860, 92)
        Me.SearchAccount.TabIndex = 2
        Me.SearchAccount.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvaccount, Me.GridView1})
        '
        'gvaccount
        '
        Me.gvaccount.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gvaccount.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvaccount.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvaccount.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvaccount.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCACCTNO, Me.GCSUBTXNO, Me.DEBIT, Me.CREDIT})
        Me.gvaccount.GridControl = Me.SearchAccount
        Me.gvaccount.Name = "gvaccount"
        Me.gvaccount.OptionsBehavior.Editable = False
        Me.gvaccount.OptionsBehavior.ReadOnly = True
        Me.gvaccount.OptionsFilter.AllowFilterEditor = False
        Me.gvaccount.OptionsView.ColumnAutoWidth = False
        Me.gvaccount.OptionsView.ShowGroupPanel = False
        '
        'GCACCTNO
        '
        Me.GCACCTNO.AppearanceCell.Options.UseTextOptions = True
        Me.GCACCTNO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCACCTNO.Caption = "ACCTNO"
        Me.GCACCTNO.FieldName = "ACCTNO"
        Me.GCACCTNO.MinWidth = 60
        Me.GCACCTNO.Name = "GCACCTNO"
        Me.GCACCTNO.Visible = True
        Me.GCACCTNO.VisibleIndex = 0
        Me.GCACCTNO.Width = 180
        '
        'GCSUBTXNO
        '
        Me.GCSUBTXNO.AppearanceCell.Options.UseTextOptions = True
        Me.GCSUBTXNO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCSUBTXNO.Caption = "SUBTXNO"
        Me.GCSUBTXNO.FieldName = "SUBTXNO"
        Me.GCSUBTXNO.MinWidth = 60
        Me.GCSUBTXNO.Name = "GCSUBTXNO"
        Me.GCSUBTXNO.Visible = True
        Me.GCSUBTXNO.VisibleIndex = 1
        Me.GCSUBTXNO.Width = 180
        '
        'DEBIT
        '
        Me.DEBIT.AppearanceCell.Options.UseTextOptions = True
        Me.DEBIT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DEBIT.Caption = "DEBIT"
        Me.DEBIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.DEBIT.FieldName = "DEBIT"
        Me.DEBIT.MinWidth = 70
        Me.DEBIT.Name = "DEBIT"
        Me.DEBIT.Visible = True
        Me.DEBIT.VisibleIndex = 2
        Me.DEBIT.Width = 150
        '
        'CREDIT
        '
        Me.CREDIT.Caption = "CREDIT"
        Me.CREDIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CREDIT.FieldName = "CREDIT"
        Me.CREDIT.MinWidth = 70
        Me.CREDIT.Name = "CREDIT"
        Me.CREDIT.Visible = True
        Me.CREDIT.VisibleIndex = 3
        Me.CREDIT.Width = 150
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26})
        Me.GridView1.GridControl = Me.SearchAccount
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFilter.AllowFilterEditor = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "TXNUM"
        Me.GridColumn14.FieldName = "TXNUM"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 80
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "TXDATE"
        Me.GridColumn15.FieldName = "TXDATE"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 80
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.Caption = "BUSDATE"
        Me.GridColumn16.FieldName = "BUSDATE"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 80
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.Caption = "TXTIME"
        Me.GridColumn17.FieldName = "TXTIME"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        Me.GridColumn17.Width = 80
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "LVEL"
        Me.GridColumn18.FieldName = "LVEL"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 4
        Me.GridColumn18.Width = 50
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "DSTATUS"
        Me.GridColumn19.FieldName = "DSTATUS"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 5
        Me.GridColumn19.Width = 80
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "TLID"
        Me.GridColumn20.FieldName = "TLID"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 6
        Me.GridColumn20.Width = 20
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn21.Caption = "TLNAME"
        Me.GridColumn21.FieldName = "TLNAME"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 7
        Me.GridColumn21.Width = 100
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "DSACTION"
        Me.GridColumn22.FieldName = "DSACTION"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 8
        Me.GridColumn22.Width = 80
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "TXDESC"
        Me.GridColumn23.FieldName = "TXDESC"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 9
        Me.GridColumn23.Width = 150
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "WSNAME"
        Me.GridColumn24.FieldName = "WSNAME"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 10
        Me.GridColumn24.Width = 100
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "LASTCHANGE"
        Me.GridColumn25.FieldName = "LASTCHANGE"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 11
        Me.GridColumn25.Width = 80
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "AUTOID"
        Me.GridColumn26.FieldName = "AUTOID"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 12
        '
        'tabFEEDetails
        '
        Me.tabFEEDetails.Name = "tabFEEDetails"
        Me.tabFEEDetails.PageVisible = False
        Me.tabFEEDetails.Size = New System.Drawing.Size(860, 92)
        Me.tabFEEDetails.Text = "tabFEEDetails"
        '
        'tabVATVoucher
        '
        Me.tabVATVoucher.Name = "tabVATVoucher"
        Me.tabVATVoucher.PageVisible = False
        Me.tabVATVoucher.Size = New System.Drawing.Size(860, 92)
        Me.tabVATVoucher.Text = "tabVATVoucher"
        '
        'pcTransactionCode
        '
        Me.pcTransactionCode.Controls.Add(Me.dtpValidateField)
        Me.pcTransactionCode.Controls.Add(Me.mskTransCode)
        Me.pcTransactionCode.Controls.Add(Me.lblTransCaption)
        Me.pcTransactionCode.Controls.Add(Me.lblTransCode)
        Me.pcTransactionCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcTransactionCode.Location = New System.Drawing.Point(0, 0)
        Me.pcTransactionCode.Margin = New System.Windows.Forms.Padding(0)
        Me.pcTransactionCode.Name = "pcTransactionCode"
        Me.pcTransactionCode.Size = New System.Drawing.Size(866, 50)
        Me.pcTransactionCode.TabIndex = 0
        '
        'dtpValidateField
        '
        Me.dtpValidateField.EditValue = Nothing
        Me.dtpValidateField.Location = New System.Drawing.Point(663, 14)
        Me.dtpValidateField.Name = "dtpValidateField"
        Me.dtpValidateField.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpValidateField.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpValidateField.Size = New System.Drawing.Size(100, 20)
        Me.dtpValidateField.TabIndex = 3
        Me.dtpValidateField.Visible = False
        '
        'mskTransCode
        '
        Me.mskTransCode.EditValue = ""
        Me.mskTransCode.Location = New System.Drawing.Point(106, 14)
        Me.mskTransCode.Name = "mskTransCode"
        Me.mskTransCode.Size = New System.Drawing.Size(71, 20)
        Me.mskTransCode.TabIndex = 1
        Me.mskTransCode.Tag = "mskTransCode"
        '
        'lblTransCaption
        '
        Me.lblTransCaption.Location = New System.Drawing.Point(190, 17)
        Me.lblTransCaption.Name = "lblTransCaption"
        Me.lblTransCaption.Size = New System.Drawing.Size(74, 13)
        Me.lblTransCaption.TabIndex = 90
        Me.lblTransCaption.Text = "lblTransCaption"
        '
        'lblTransCode
        '
        Me.lblTransCode.Location = New System.Drawing.Point(16, 17)
        Me.lblTransCode.Name = "lblTransCode"
        Me.lblTransCode.Size = New System.Drawing.Size(56, 13)
        Me.lblTransCode.TabIndex = 0
        Me.lblTransCode.Tag = "lblTransCode"
        Me.lblTransCode.Text = "TransCode:"
        '
        'pnTransDetail
        '
        Me.pnTransDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnTransDetail.Location = New System.Drawing.Point(3, 53)
        Me.pnTransDetail.Name = "pnTransDetail"
        Me.pnTransDetail.Size = New System.Drawing.Size(860, 214)
        Me.pnTransDetail.TabIndex = 2
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.stbMain})
        Me.BarManager1.MaxItemId = 1
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.stbMain)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'stbMain
        '
        Me.stbMain.Caption = "BarStaticItem1"
        Me.stbMain.Id = 0
        Me.stbMain.Name = "stbMain"
        Me.stbMain.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(866, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 445)
        Me.barDockControlBottom.Size = New System.Drawing.Size(866, 25)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 445)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(866, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 445)
        '
        'frmXtraTransact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 470)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmXtraTransact"
        Me.Text = "frmXtraTransact"
        Me.tlpMain.ResumeLayout(False)
        CType(Me.pcButtonBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcButtonBar.ResumeLayout(False)
        Me.pcButtonBar.PerformLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcTransactionDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcTransactionDetail.ResumeLayout(False)
        CType(Me.tabTransact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransact.ResumeLayout(False)
        Me.tabTranWorkflowLog.ResumeLayout(False)
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAccountEntry.ResumeLayout(False)
        CType(Me.SearchAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvaccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcTransactionCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcTransactionCode.ResumeLayout(False)
        Me.pcTransactionCode.PerformLayout()
        CType(Me.dtpValidateField.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpValidateField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskTransCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pcTransactionCode As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pcTransactionDetail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblTransCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mskTransCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dtpValidateField As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTransCaption As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tabTransact As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents pcButtonBar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReject As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEntries As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdjust As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCANCEL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRefuse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVoucher As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblHelper As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents tabAccountEntry As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabFEEDetails As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabVATVoucher As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents stbMain As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents pnTransDetail As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents tabTranWorkflowLog As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SearchGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolTxNum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTxTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolBusDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTellerId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTellerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTxDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDsAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTxDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolWsName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolLastChange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolAutoId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchAccount As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvaccount As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCACCTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSUBTXNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CREDIT As DevExpress.XtraGrid.Columns.GridColumn
End Class
