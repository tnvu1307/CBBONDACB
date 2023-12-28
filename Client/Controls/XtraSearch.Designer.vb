<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraSearch
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraSearch))
        Me.rcToolbar = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiView = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiApprove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExport = New DevExpress.XtraBars.BarButtonItem()
        Me.bsiStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiExectionFlag = New DevExpress.XtraBars.BarStaticItem()
        Me.bciCheckAll = New DevExpress.XtraBars.BarCheckItem()
        Me.bbiNext = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPrev = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExecute = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSMS = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiFullScreen = New DevExpress.XtraBars.BarButtonItem()
        Me.bciExecuteAll = New DevExpress.XtraBars.BarCheckItem()
        Me.bbiCashier = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiReject = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiHistory = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiAdvanceSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiNextPage = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiBackPage = New DevExpress.XtraBars.BarButtonItem()
        Me.bciCheckAllPage = New DevExpress.XtraBars.BarCheckItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgView = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCash = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAudit = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSystem = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSearch = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.sccSearch = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcCriterial = New DevExpress.XtraEditors.GroupControl()
        Me.fcCriterial = New AppCore.Controls.XtraUcCriterial()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SearchGrid = New DevExpress.XtraGrid.GridControl()
        Me.gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.riteStatus = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tmrSearch = New System.Windows.Forms.Timer(Me.components)
        Me.DataTable41 = New System.Data.DataTable()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.DataTable52 = New System.Data.DataTable()
        Me.DataTable57 = New System.Data.DataTable()
        Me.DataTable1 = New System.Data.DataTable()
        CType(Me.rcToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sccSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sccSearch.SuspendLayout()
        CType(Me.gcCriterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcCriterial.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riteStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcToolbar
        '
        Me.rcToolbar.AllowMdiChildButtons = False
        Me.rcToolbar.ExpandCollapseItem.Id = 0
        Me.rcToolbar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.rcToolbar.ExpandCollapseItem, Me.bbiNew, Me.bbiView, Me.bbiEdit, Me.bbiApprove, Me.bbiSearch, Me.bbiExport, Me.bsiStatus, Me.bsiExectionFlag, Me.bciCheckAll, Me.bbiNext, Me.bbiPrev, Me.bbiExecute, Me.bbiEmail, Me.bbiSMS, Me.bbiExit, Me.bbiFullScreen, Me.bciExecuteAll, Me.bbiCashier, Me.bbiReject, Me.bbiHistory, Me.bbiAdvanceSearch, Me.bbiCancel, Me.BarSubItem1, Me.BarButtonItem1, Me.bbiNextPage, Me.bbiBackPage, Me.bciCheckAllPage})
        Me.rcToolbar.Location = New System.Drawing.Point(0, 0)
        Me.rcToolbar.MaxItemId = 8
        Me.rcToolbar.Name = "rcToolbar"
        Me.rcToolbar.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.rcToolbar.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.rcToolbar.Size = New System.Drawing.Size(641, 96)
        Me.rcToolbar.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'bbiNew
        '
        Me.bbiNew.Caption = "Thêm"
        Me.bbiNew.Glyph = CType(resources.GetObject("bbiNew.Glyph"), System.Drawing.Image)
        Me.bbiNew.Id = 1
        Me.bbiNew.LargeGlyph = CType(resources.GetObject("bbiNew.LargeGlyph"), System.Drawing.Image)
        Me.bbiNew.Name = "bbiNew"
        '
        'bbiView
        '
        Me.bbiView.Caption = "Xem"
        Me.bbiView.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiView.Glyph = CType(resources.GetObject("bbiView.Glyph"), System.Drawing.Image)
        Me.bbiView.Id = 6
        Me.bbiView.LargeGlyph = CType(resources.GetObject("bbiView.LargeGlyph"), System.Drawing.Image)
        Me.bbiView.Name = "bbiView"
        '
        'bbiEdit
        '
        Me.bbiEdit.Caption = "Sửa"
        Me.bbiEdit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiEdit.Glyph = CType(resources.GetObject("bbiEdit.Glyph"), System.Drawing.Image)
        Me.bbiEdit.Id = 7
        Me.bbiEdit.LargeGlyph = CType(resources.GetObject("bbiEdit.LargeGlyph"), System.Drawing.Image)
        Me.bbiEdit.Name = "bbiEdit"
        '
        'bbiApprove
        '
        Me.bbiApprove.Caption = "Duyệt"
        Me.bbiApprove.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiApprove.Glyph = CType(resources.GetObject("bbiApprove.Glyph"), System.Drawing.Image)
        Me.bbiApprove.Id = 9
        Me.bbiApprove.LargeGlyph = CType(resources.GetObject("bbiApprove.LargeGlyph"), System.Drawing.Image)
        Me.bbiApprove.Name = "bbiApprove"
        '
        'bbiSearch
        '
        Me.bbiSearch.Caption = "Tìm"
        Me.bbiSearch.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiSearch.Glyph = CType(resources.GetObject("bbiSearch.Glyph"), System.Drawing.Image)
        Me.bbiSearch.Id = 10
        Me.bbiSearch.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5)
        Me.bbiSearch.LargeGlyph = CType(resources.GetObject("bbiSearch.LargeGlyph"), System.Drawing.Image)
        Me.bbiSearch.Name = "bbiSearch"
        Me.bbiSearch.ShortcutKeyDisplayString = "F5"
        '
        'bbiExport
        '
        Me.bbiExport.Caption = "Kết xuất"
        Me.bbiExport.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExport.Glyph = CType(resources.GetObject("bbiExport.Glyph"), System.Drawing.Image)
        Me.bbiExport.Id = 11
        Me.bbiExport.LargeGlyph = CType(resources.GetObject("bbiExport.LargeGlyph"), System.Drawing.Image)
        Me.bbiExport.Name = "bbiExport"
        '
        'bsiStatus
        '
        Me.bsiStatus.Caption = "Trạng thái"
        Me.bsiStatus.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bsiStatus.Glyph = CType(resources.GetObject("bsiStatus.Glyph"), System.Drawing.Image)
        Me.bsiStatus.Id = 12
        Me.bsiStatus.LargeGlyph = CType(resources.GetObject("bsiStatus.LargeGlyph"), System.Drawing.Image)
        Me.bsiStatus.Name = "bsiStatus"
        Me.bsiStatus.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'bsiExectionFlag
        '
        Me.bsiExectionFlag.Caption = "Hành động"
        Me.bsiExectionFlag.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bsiExectionFlag.Glyph = CType(resources.GetObject("bsiExectionFlag.Glyph"), System.Drawing.Image)
        Me.bsiExectionFlag.Id = 13
        Me.bsiExectionFlag.LargeGlyph = CType(resources.GetObject("bsiExectionFlag.LargeGlyph"), System.Drawing.Image)
        Me.bsiExectionFlag.Name = "bsiExectionFlag"
        Me.bsiExectionFlag.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'bciCheckAll
        '
        Me.bciCheckAll.Caption = "Không phân trang"
        Me.bciCheckAll.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bciCheckAll.Glyph = CType(resources.GetObject("bciCheckAll.Glyph"), System.Drawing.Image)
        Me.bciCheckAll.Id = 16
        Me.bciCheckAll.LargeGlyph = CType(resources.GetObject("bciCheckAll.LargeGlyph"), System.Drawing.Image)
        Me.bciCheckAll.Name = "bciCheckAll"
        '
        'bbiNext
        '
        Me.bbiNext.Caption = "Trang tiếp"
        Me.bbiNext.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiNext.Glyph = CType(resources.GetObject("bbiNext.Glyph"), System.Drawing.Image)
        Me.bbiNext.Id = 17
        Me.bbiNext.LargeGlyph = CType(resources.GetObject("bbiNext.LargeGlyph"), System.Drawing.Image)
        Me.bbiNext.Name = "bbiNext"
        '
        'bbiPrev
        '
        Me.bbiPrev.Caption = "Trang trước"
        Me.bbiPrev.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiPrev.Glyph = CType(resources.GetObject("bbiPrev.Glyph"), System.Drawing.Image)
        Me.bbiPrev.Id = 18
        Me.bbiPrev.LargeGlyph = CType(resources.GetObject("bbiPrev.LargeGlyph"), System.Drawing.Image)
        Me.bbiPrev.Name = "bbiPrev"
        '
        'bbiExecute
        '
        Me.bbiExecute.Caption = "Thực hiện"
        Me.bbiExecute.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExecute.Glyph = CType(resources.GetObject("bbiExecute.Glyph"), System.Drawing.Image)
        Me.bbiExecute.Id = 19
        Me.bbiExecute.LargeGlyph = CType(resources.GetObject("bbiExecute.LargeGlyph"), System.Drawing.Image)
        Me.bbiExecute.Name = "bbiExecute"
        '
        'bbiEmail
        '
        Me.bbiEmail.Caption = "Gửi email"
        Me.bbiEmail.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiEmail.Glyph = CType(resources.GetObject("bbiEmail.Glyph"), System.Drawing.Image)
        Me.bbiEmail.Id = 20
        Me.bbiEmail.LargeGlyph = CType(resources.GetObject("bbiEmail.LargeGlyph"), System.Drawing.Image)
        Me.bbiEmail.Name = "bbiEmail"
        '
        'bbiSMS
        '
        Me.bbiSMS.Caption = "Gửi SMS"
        Me.bbiSMS.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiSMS.Glyph = CType(resources.GetObject("bbiSMS.Glyph"), System.Drawing.Image)
        Me.bbiSMS.Id = 21
        Me.bbiSMS.LargeGlyph = CType(resources.GetObject("bbiSMS.LargeGlyph"), System.Drawing.Image)
        Me.bbiSMS.Name = "bbiSMS"
        '
        'bbiExit
        '
        Me.bbiExit.Caption = "Thoát"
        Me.bbiExit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExit.Glyph = CType(resources.GetObject("bbiExit.Glyph"), System.Drawing.Image)
        Me.bbiExit.Id = 22
        Me.bbiExit.LargeGlyph = CType(resources.GetObject("bbiExit.LargeGlyph"), System.Drawing.Image)
        Me.bbiExit.Name = "bbiExit"
        '
        'bbiFullScreen
        '
        Me.bbiFullScreen.Caption = "Ẩn điều kiện"
        Me.bbiFullScreen.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiFullScreen.Glyph = CType(resources.GetObject("bbiFullScreen.Glyph"), System.Drawing.Image)
        Me.bbiFullScreen.Id = 23
        Me.bbiFullScreen.LargeGlyph = CType(resources.GetObject("bbiFullScreen.LargeGlyph"), System.Drawing.Image)
        Me.bbiFullScreen.Name = "bbiFullScreen"
        '
        'bciExecuteAll
        '
        Me.bciExecuteAll.Caption = "Thực hiện hết"
        Me.bciExecuteAll.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bciExecuteAll.Glyph = CType(resources.GetObject("bciExecuteAll.Glyph"), System.Drawing.Image)
        Me.bciExecuteAll.Id = 24
        Me.bciExecuteAll.LargeGlyph = CType(resources.GetObject("bciExecuteAll.LargeGlyph"), System.Drawing.Image)
        Me.bciExecuteAll.Name = "bciExecuteAll"
        '
        'bbiCashier
        '
        Me.bbiCashier.Caption = "Quỹ"
        Me.bbiCashier.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiCashier.Glyph = CType(resources.GetObject("bbiCashier.Glyph"), System.Drawing.Image)
        Me.bbiCashier.Id = 25
        Me.bbiCashier.LargeGlyph = CType(resources.GetObject("bbiCashier.LargeGlyph"), System.Drawing.Image)
        Me.bbiCashier.Name = "bbiCashier"
        '
        'bbiReject
        '
        Me.bbiReject.Caption = "Từ chối"
        Me.bbiReject.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiReject.Glyph = CType(resources.GetObject("bbiReject.Glyph"), System.Drawing.Image)
        Me.bbiReject.Id = 26
        Me.bbiReject.LargeGlyph = CType(resources.GetObject("bbiReject.LargeGlyph"), System.Drawing.Image)
        Me.bbiReject.Name = "bbiReject"
        '
        'bbiHistory
        '
        Me.bbiHistory.Caption = "Lịch sử giao dịch"
        Me.bbiHistory.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiHistory.Glyph = CType(resources.GetObject("bbiHistory.Glyph"), System.Drawing.Image)
        Me.bbiHistory.Id = 28
        Me.bbiHistory.LargeGlyph = CType(resources.GetObject("bbiHistory.LargeGlyph"), System.Drawing.Image)
        Me.bbiHistory.Name = "bbiHistory"
        '
        'bbiAdvanceSearch
        '
        Me.bbiAdvanceSearch.Caption = "Tìm kiếm nâng cao"
        Me.bbiAdvanceSearch.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiAdvanceSearch.Glyph = CType(resources.GetObject("bbiAdvanceSearch.Glyph"), System.Drawing.Image)
        Me.bbiAdvanceSearch.Id = 1
        Me.bbiAdvanceSearch.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6)
        Me.bbiAdvanceSearch.LargeGlyph = CType(resources.GetObject("bbiAdvanceSearch.LargeGlyph"), System.Drawing.Image)
        Me.bbiAdvanceSearch.Name = "bbiAdvanceSearch"
        Me.bbiAdvanceSearch.ShortcutKeyDisplayString = "F6"
        '
        'bbiCancel
        '
        Me.bbiCancel.Caption = "Hủy"
        Me.bbiCancel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiCancel.Glyph = CType(resources.GetObject("bbiCancel.Glyph"), System.Drawing.Image)
        Me.bbiCancel.Id = 2
        Me.bbiCancel.LargeGlyph = CType(resources.GetObject("bbiCancel.LargeGlyph"), System.Drawing.Image)
        Me.bbiCancel.Name = "bbiCancel"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "BarSubItem1"
        Me.BarSubItem1.Id = 3
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 4
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'bbiNextPage
        '
        Me.bbiNextPage.Caption = "Trang tiếp"
        Me.bbiNextPage.Glyph = CType(resources.GetObject("bbiNextPage.Glyph"), System.Drawing.Image)
        Me.bbiNextPage.Id = 5
        Me.bbiNextPage.LargeGlyph = CType(resources.GetObject("bbiNextPage.LargeGlyph"), System.Drawing.Image)
        Me.bbiNextPage.Name = "bbiNextPage"
        Me.bbiNextPage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbiBackPage
        '
        Me.bbiBackPage.Caption = "Trang trước"
        Me.bbiBackPage.Glyph = CType(resources.GetObject("bbiBackPage.Glyph"), System.Drawing.Image)
        Me.bbiBackPage.Id = 6
        Me.bbiBackPage.LargeGlyph = CType(resources.GetObject("bbiBackPage.LargeGlyph"), System.Drawing.Image)
        Me.bbiBackPage.Name = "bbiBackPage"
        Me.bbiBackPage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bciCheckAllPage
        '
        Me.bciCheckAllPage.Caption = "Không phân trang"
        Me.bciCheckAllPage.Glyph = CType(resources.GetObject("bciCheckAllPage.Glyph"), System.Drawing.Image)
        Me.bciCheckAllPage.Id = 7
        Me.bciCheckAllPage.LargeGlyph = CType(resources.GetObject("bciCheckAllPage.LargeGlyph"), System.Drawing.Image)
        Me.bciCheckAllPage.Name = "bciCheckAllPage"
        Me.bciCheckAllPage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Color = System.Drawing.Color.Empty
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonPageCategory1.Text = "RibbonPageCategory1"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgView, Me.rpgCash, Me.rpgAudit, Me.rpgSystem, Me.rpgSearch})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'rpgView
        '
        Me.rpgView.ItemLinks.Add(Me.bbiView)
        Me.rpgView.Name = "rpgView"
        '
        'rpgCash
        '
        Me.rpgCash.ItemLinks.Add(Me.bbiCashier)
        Me.rpgCash.Name = "rpgCash"
        Me.rpgCash.Visible = False
        '
        'rpgAudit
        '
        Me.rpgAudit.ItemLinks.Add(Me.bbiApprove)
        Me.rpgAudit.ItemLinks.Add(Me.bbiReject)
        Me.rpgAudit.ItemLinks.Add(Me.bbiCancel)
        Me.rpgAudit.Name = "rpgAudit"
        Me.rpgAudit.Text = "Kiểm soát"
        '
        'rpgSystem
        '
        Me.rpgSystem.ItemLinks.Add(Me.bbiFullScreen)
        Me.rpgSystem.Name = "rpgSystem"
        Me.rpgSystem.Visible = False
        '
        'rpgSearch
        '
        Me.rpgSearch.ItemLinks.Add(Me.bbiSearch)
        Me.rpgSearch.ItemLinks.Add(Me.bbiAdvanceSearch)
        Me.rpgSearch.ItemLinks.Add(Me.bbiExport)
        Me.rpgSearch.ItemLinks.Add(Me.bbiHistory)
        Me.rpgSearch.ItemLinks.Add(Me.bbiBackPage)
        Me.rpgSearch.ItemLinks.Add(Me.bbiNextPage)
        Me.rpgSearch.ItemLinks.Add(Me.bciCheckAllPage)
        Me.rpgSearch.Name = "rpgSearch"
        Me.rpgSearch.Text = "Tìm kiếm"
        '
        'sccSearch
        '
        Me.sccSearch.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
        Me.sccSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sccSearch.Location = New System.Drawing.Point(0, 96)
        Me.sccSearch.Name = "sccSearch"
        Me.sccSearch.Panel1.Controls.Add(Me.gcCriterial)
        Me.sccSearch.Panel1.Text = "Panel1"
        Me.sccSearch.Panel2.Controls.Add(Me.GroupControl1)
        Me.sccSearch.Panel2.Controls.Add(Me.PanelControl1)
        Me.sccSearch.Panel2.Text = "Panel2"
        Me.sccSearch.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
        Me.sccSearch.Size = New System.Drawing.Size(641, 256)
        Me.sccSearch.SplitterPosition = 300
        Me.sccSearch.TabIndex = 5
        Me.sccSearch.Text = "SplitContainerControl1"
        '
        'gcCriterial
        '
        Me.gcCriterial.Controls.Add(Me.fcCriterial)
        Me.gcCriterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCriterial.Location = New System.Drawing.Point(0, 0)
        Me.gcCriterial.LookAndFeel.SkinName = "Coffee"
        Me.gcCriterial.Name = "gcCriterial"
        Me.gcCriterial.Size = New System.Drawing.Size(0, 0)
        Me.gcCriterial.TabIndex = 4
        Me.gcCriterial.Text = "Điều kiện tìm kiếm"
        '
        'fcCriterial
        '
        Me.fcCriterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fcCriterial.Location = New System.Drawing.Point(0, 20)
        Me.fcCriterial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fcCriterial.Name = "fcCriterial"
        Me.fcCriterial.Size = New System.Drawing.Size(0, 0)
        Me.fcCriterial.TabIndex = 0
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SearchGrid)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 44)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(641, 212)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Kết quả tìm kiếm"
        '
        'SearchGrid
        '
        Me.SearchGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchGrid.Location = New System.Drawing.Point(2, 21)
        Me.SearchGrid.MainView = Me.gvResult
        Me.SearchGrid.Name = "SearchGrid"
        Me.SearchGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.riteStatus})
        Me.SearchGrid.Size = New System.Drawing.Size(637, 189)
        Me.SearchGrid.TabIndex = 0
        Me.SearchGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvResult})
        '
        'gvResult
        '
        Me.gvResult.GridControl = Me.SearchGrid
        Me.gvResult.Name = "gvResult"
        Me.gvResult.OptionsSelection.MultiSelect = True
        Me.gvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gvResult.OptionsView.ShowFooter = True
        '
        'riteStatus
        '
        Me.riteStatus.AutoHeight = False
        Me.riteStatus.Name = "riteStatus"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(641, 44)
        Me.PanelControl1.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelControl1.Location = New System.Drawing.Point(2, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(637, 40)
        Me.LabelControl1.TabIndex = 0
        '
        'tmrSearch
        '
        Me.tmrSearch.Interval = 1000000
        '
        'DataTable41
        '
        Me.DataTable41.Namespace = ""
        Me.DataTable41.TableName = "COMBOBOX"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.InsertGalleryImage("notes_16x16.png", "images/content/notes_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/notes_16x16.png"), 0)
        Me.ImageCollection1.Images.SetKeyName(0, "notes_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 1)
        Me.ImageCollection1.Images.SetKeyName(1, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("bugreport_16x16.png", "images/programming/bugreport_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/bugreport_16x16.png"), 2)
        Me.ImageCollection1.Images.SetKeyName(2, "bugreport_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("currency_16x16.png", "images/miscellaneous/currency_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/miscellaneous/currency_16x16.png"), 3)
        Me.ImageCollection1.Images.SetKeyName(3, "currency_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("time_16x16.png", "images/scheduling/time_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/time_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "time_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("tag_16x16.png", "images/programming/tag_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/tag_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "tag_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(7, "if_Erase_16_16.png")
        Me.ImageCollection1.Images.SetKeyName(8, "if_Erase_16_16.png")
        '
        'DataTable52
        '
        Me.DataTable52.Namespace = ""
        Me.DataTable52.TableName = "COMBOBOX"
        '
        'DataTable57
        '
        Me.DataTable57.Namespace = ""
        Me.DataTable57.TableName = "COMBOBOX"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'XtraSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sccSearch)
        Me.Controls.Add(Me.rcToolbar)
        Me.Name = "XtraSearch"
        Me.Size = New System.Drawing.Size(641, 352)
        CType(Me.rcToolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sccSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sccSearch.ResumeLayout(False)
        CType(Me.gcCriterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcCriterial.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riteStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcToolbar As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bbiNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiApprove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bsiStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiExectionFlag As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bciCheckAll As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents bbiNext As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPrev As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExecute As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSMS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiFullScreen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bciExecuteAll As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents bbiCashier As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiReject As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgView As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgCash As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgAudit As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgSystem As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents sccSearch As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents gcCriterial As DevExpress.XtraEditors.GroupControl
    Friend WithEvents fcCriterial As AppCore.Controls.XtraUcCriterial
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SearchGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents tmrSearch As System.Windows.Forms.Timer
    Friend WithEvents rpgSearch As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiHistory As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents riteStatus As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DataTable41 As System.Data.DataTable
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bbiAdvanceSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataTable52 As System.Data.DataTable
    Friend WithEvents DataTable57 As System.Data.DataTable
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiNextPage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiBackPage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bciCheckAllPage As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents DataTable1 As System.Data.DataTable

End Class
