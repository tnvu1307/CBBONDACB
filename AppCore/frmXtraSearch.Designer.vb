<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXtraSearch
    Inherits AppCore.FormBase


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXtraSearch))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.sccSearch = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcCriterial = New DevExpress.XtraEditors.GroupControl()
        Me.fcCriterial = New AppCore.Controls.XtraUcCriterial()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SearchGrid = New DevExpress.XtraGrid.GridControl()
        Me.gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rcToolbar = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiView = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
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
        Me.bbiPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCompare = New DevExpress.XtraBars.BarButtonItem()
        Me.cbauto = New DevExpress.XtraBars.BarCheckItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgNew = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMulti = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAuth = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgNavigator = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgExport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCompare = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSystem = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.grpQuickSearch = New DevExpress.XtraEditors.GroupControl()
        Me.tblLayoutQuiclSearch = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCondition1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCondition2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCondition3 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCondition4 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCondition5 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCondition6 = New DevExpress.XtraEditors.LabelControl()
        Me.lueCondition1 = New AppCore.LookUpEditEx()
        Me.lueCondition2 = New AppCore.LookUpEditEx()
        Me.lueCondition3 = New AppCore.LookUpEditEx()
        Me.lueCondition4 = New AppCore.LookUpEditEx()
        Me.lueCondition5 = New AppCore.LookUpEditEx()
        Me.lueCondition6 = New AppCore.LookUpEditEx()
        Me.dtFrom = New DevExpress.XtraEditors.DateEdit()
        Me.dtTo = New DevExpress.XtraEditors.DateEdit()
        Me.lblQueryDate = New DevExpress.XtraEditors.CheckEdit()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiModify = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.sccSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sccSearch.SuspendLayout()
        CType(Me.gcCriterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcCriterial.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpQuickSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpQuickSearch.SuspendLayout()
        Me.tblLayoutQuiclSearch.SuspendLayout()
        CType(Me.lueCondition1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQueryDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sccSearch
        '
        Me.sccSearch.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
        resources.ApplyResources(Me.sccSearch, "sccSearch")
        Me.sccSearch.Name = "sccSearch"
        Me.sccSearch.Panel1.Controls.Add(Me.gcCriterial)
        resources.ApplyResources(Me.sccSearch.Panel1, "sccSearch.Panel1")
        Me.sccSearch.Panel2.Controls.Add(Me.GroupControl1)
        Me.sccSearch.Panel2.Controls.Add(Me.grpQuickSearch)
        resources.ApplyResources(Me.sccSearch.Panel2, "sccSearch.Panel2")
        Me.sccSearch.SplitterPosition = 275
        '
        'gcCriterial
        '
        Me.gcCriterial.AppearanceCaption.Font = CType(resources.GetObject("gcCriterial.AppearanceCaption.Font"), System.Drawing.Font)
        Me.gcCriterial.AppearanceCaption.Options.UseFont = True
        Me.gcCriterial.Controls.Add(Me.fcCriterial)
        resources.ApplyResources(Me.gcCriterial, "gcCriterial")
        Me.gcCriterial.LookAndFeel.SkinName = "Coffee"
        Me.gcCriterial.Name = "gcCriterial"
        '
        'fcCriterial
        '
        resources.ApplyResources(Me.fcCriterial, "fcCriterial")
        Me.fcCriterial.Name = "fcCriterial"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = CType(resources.GetObject("GroupControl1.AppearanceCaption.Font"), System.Drawing.Font)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.SearchGrid)
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Name = "GroupControl1"
        '
        'SearchGrid
        '
        Me.SearchGrid.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SearchGrid, "SearchGrid")
        Me.SearchGrid.MainView = Me.gvResult
        Me.SearchGrid.MenuManager = Me.rcToolbar
        Me.SearchGrid.Name = "SearchGrid"
        Me.SearchGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvResult})
        '
        'gvResult
        '
        Me.gvResult.GridControl = Me.SearchGrid
        Me.gvResult.Name = "gvResult"
        Me.gvResult.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.gvResult.OptionsSelection.MultiSelect = True
        Me.gvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gvResult.OptionsView.ShowFooter = True
        '
        'rcToolbar
        '
        Me.rcToolbar.ExpandCollapseItem.Id = 0
        Me.rcToolbar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.rcToolbar.ExpandCollapseItem, Me.bbiNew, Me.bbiView, Me.bbiEdit, Me.bbiDelete, Me.bbiApprove, Me.bbiSearch, Me.bbiExport, Me.bsiStatus, Me.bsiExectionFlag, Me.bciCheckAll, Me.bbiNext, Me.bbiPrev, Me.bbiExecute, Me.bbiEmail, Me.bbiSMS, Me.bbiExit, Me.bbiFullScreen, Me.bciExecuteAll, Me.bbiPreview, Me.bbiCompare, Me.cbauto})
        resources.ApplyResources(Me.rcToolbar, "rcToolbar")
        Me.rcToolbar.MaxItemId = 31
        Me.rcToolbar.Name = "rcToolbar"
        Me.rcToolbar.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.rcToolbar.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcToolbar.ShowCategoryInCaption = False
        Me.rcToolbar.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcToolbar.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcToolbar.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.rcToolbar.ShowToolbarCustomizeItem = False
        Me.rcToolbar.StatusBar = Me.RibbonStatusBar1
        Me.rcToolbar.Toolbar.ShowCustomizeItem = False
        '
        'bbiNew
        '
        resources.ApplyResources(Me.bbiNew, "bbiNew")
        Me.bbiNew.Glyph = CType(resources.GetObject("bbiNew.Glyph"), System.Drawing.Image)
        Me.bbiNew.Id = 1
        Me.bbiNew.LargeGlyph = CType(resources.GetObject("bbiNew.LargeGlyph"), System.Drawing.Image)
        Me.bbiNew.Name = "bbiNew"
        '
        'bbiView
        '
        resources.ApplyResources(Me.bbiView, "bbiView")
        Me.bbiView.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiView.Glyph = CType(resources.GetObject("bbiView.Glyph"), System.Drawing.Image)
        Me.bbiView.Id = 6
        Me.bbiView.LargeGlyph = CType(resources.GetObject("bbiView.LargeGlyph"), System.Drawing.Image)
        Me.bbiView.Name = "bbiView"
        '
        'bbiEdit
        '
        resources.ApplyResources(Me.bbiEdit, "bbiEdit")
        Me.bbiEdit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiEdit.Glyph = CType(resources.GetObject("bbiEdit.Glyph"), System.Drawing.Image)
        Me.bbiEdit.Id = 7
        Me.bbiEdit.LargeGlyph = CType(resources.GetObject("bbiEdit.LargeGlyph"), System.Drawing.Image)
        Me.bbiEdit.Name = "bbiEdit"
        '
        'bbiDelete
        '
        resources.ApplyResources(Me.bbiDelete, "bbiDelete")
        Me.bbiDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiDelete.Glyph = CType(resources.GetObject("bbiDelete.Glyph"), System.Drawing.Image)
        Me.bbiDelete.Id = 8
        Me.bbiDelete.LargeGlyph = CType(resources.GetObject("bbiDelete.LargeGlyph"), System.Drawing.Image)
        Me.bbiDelete.Name = "bbiDelete"
        '
        'bbiApprove
        '
        resources.ApplyResources(Me.bbiApprove, "bbiApprove")
        Me.bbiApprove.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiApprove.Glyph = CType(resources.GetObject("bbiApprove.Glyph"), System.Drawing.Image)
        Me.bbiApprove.Id = 9
        Me.bbiApprove.LargeGlyph = CType(resources.GetObject("bbiApprove.LargeGlyph"), System.Drawing.Image)
        Me.bbiApprove.Name = "bbiApprove"
        '
        'bbiSearch
        '
        resources.ApplyResources(Me.bbiSearch, "bbiSearch")
        Me.bbiSearch.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiSearch.Glyph = CType(resources.GetObject("bbiSearch.Glyph"), System.Drawing.Image)
        Me.bbiSearch.Id = 10
        Me.bbiSearch.LargeGlyph = CType(resources.GetObject("bbiSearch.LargeGlyph"), System.Drawing.Image)
        Me.bbiSearch.Name = "bbiSearch"
        '
        'bbiExport
        '
        resources.ApplyResources(Me.bbiExport, "bbiExport")
        Me.bbiExport.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExport.Glyph = CType(resources.GetObject("bbiExport.Glyph"), System.Drawing.Image)
        Me.bbiExport.Id = 11
        Me.bbiExport.LargeGlyph = CType(resources.GetObject("bbiExport.LargeGlyph"), System.Drawing.Image)
        Me.bbiExport.Name = "bbiExport"
        '
        'bsiStatus
        '
        resources.ApplyResources(Me.bsiStatus, "bsiStatus")
        Me.bsiStatus.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bsiStatus.Glyph = CType(resources.GetObject("bsiStatus.Glyph"), System.Drawing.Image)
        Me.bsiStatus.Id = 12
        Me.bsiStatus.LargeGlyph = CType(resources.GetObject("bsiStatus.LargeGlyph"), System.Drawing.Image)
        Me.bsiStatus.Name = "bsiStatus"
        Me.bsiStatus.TextAlignment = System.Drawing.StringAlignment.Near
        Me.bsiStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bsiExectionFlag
        '
        resources.ApplyResources(Me.bsiExectionFlag, "bsiExectionFlag")
        Me.bsiExectionFlag.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bsiExectionFlag.Glyph = CType(resources.GetObject("bsiExectionFlag.Glyph"), System.Drawing.Image)
        Me.bsiExectionFlag.Id = 13
        Me.bsiExectionFlag.LargeGlyph = CType(resources.GetObject("bsiExectionFlag.LargeGlyph"), System.Drawing.Image)
        Me.bsiExectionFlag.Name = "bsiExectionFlag"
        Me.bsiExectionFlag.TextAlignment = System.Drawing.StringAlignment.Near
        Me.bsiExectionFlag.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bciCheckAll
        '
        resources.ApplyResources(Me.bciCheckAll, "bciCheckAll")
        Me.bciCheckAll.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bciCheckAll.Glyph = CType(resources.GetObject("bciCheckAll.Glyph"), System.Drawing.Image)
        Me.bciCheckAll.Id = 16
        Me.bciCheckAll.LargeGlyph = CType(resources.GetObject("bciCheckAll.LargeGlyph"), System.Drawing.Image)
        Me.bciCheckAll.Name = "bciCheckAll"
        '
        'bbiNext
        '
        resources.ApplyResources(Me.bbiNext, "bbiNext")
        Me.bbiNext.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiNext.Glyph = CType(resources.GetObject("bbiNext.Glyph"), System.Drawing.Image)
        Me.bbiNext.Id = 17
        Me.bbiNext.LargeGlyph = CType(resources.GetObject("bbiNext.LargeGlyph"), System.Drawing.Image)
        Me.bbiNext.Name = "bbiNext"
        '
        'bbiPrev
        '
        resources.ApplyResources(Me.bbiPrev, "bbiPrev")
        Me.bbiPrev.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiPrev.Glyph = CType(resources.GetObject("bbiPrev.Glyph"), System.Drawing.Image)
        Me.bbiPrev.Id = 18
        Me.bbiPrev.LargeGlyph = CType(resources.GetObject("bbiPrev.LargeGlyph"), System.Drawing.Image)
        Me.bbiPrev.Name = "bbiPrev"
        '
        'bbiExecute
        '
        resources.ApplyResources(Me.bbiExecute, "bbiExecute")
        Me.bbiExecute.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExecute.Glyph = CType(resources.GetObject("bbiExecute.Glyph"), System.Drawing.Image)
        Me.bbiExecute.Id = 19
        Me.bbiExecute.LargeGlyph = CType(resources.GetObject("bbiExecute.LargeGlyph"), System.Drawing.Image)
        Me.bbiExecute.Name = "bbiExecute"
        Me.bbiExecute.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiEmail
        '
        resources.ApplyResources(Me.bbiEmail, "bbiEmail")
        Me.bbiEmail.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiEmail.Glyph = CType(resources.GetObject("bbiEmail.Glyph"), System.Drawing.Image)
        Me.bbiEmail.Id = 20
        Me.bbiEmail.LargeGlyph = CType(resources.GetObject("bbiEmail.LargeGlyph"), System.Drawing.Image)
        Me.bbiEmail.Name = "bbiEmail"
        Me.bbiEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiSMS
        '
        resources.ApplyResources(Me.bbiSMS, "bbiSMS")
        Me.bbiSMS.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiSMS.Glyph = CType(resources.GetObject("bbiSMS.Glyph"), System.Drawing.Image)
        Me.bbiSMS.Id = 21
        Me.bbiSMS.LargeGlyph = CType(resources.GetObject("bbiSMS.LargeGlyph"), System.Drawing.Image)
        Me.bbiSMS.Name = "bbiSMS"
        Me.bbiSMS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiExit
        '
        resources.ApplyResources(Me.bbiExit, "bbiExit")
        Me.bbiExit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExit.Glyph = CType(resources.GetObject("bbiExit.Glyph"), System.Drawing.Image)
        Me.bbiExit.Id = 22
        Me.bbiExit.LargeGlyph = CType(resources.GetObject("bbiExit.LargeGlyph"), System.Drawing.Image)
        Me.bbiExit.Name = "bbiExit"
        '
        'bbiFullScreen
        '
        resources.ApplyResources(Me.bbiFullScreen, "bbiFullScreen")
        Me.bbiFullScreen.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiFullScreen.Glyph = CType(resources.GetObject("bbiFullScreen.Glyph"), System.Drawing.Image)
        Me.bbiFullScreen.Id = 23
        Me.bbiFullScreen.LargeGlyph = CType(resources.GetObject("bbiFullScreen.LargeGlyph"), System.Drawing.Image)
        Me.bbiFullScreen.Name = "bbiFullScreen"
        '
        'bciExecuteAll
        '
        resources.ApplyResources(Me.bciExecuteAll, "bciExecuteAll")
        Me.bciExecuteAll.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bciExecuteAll.Glyph = CType(resources.GetObject("bciExecuteAll.Glyph"), System.Drawing.Image)
        Me.bciExecuteAll.Id = 24
        Me.bciExecuteAll.LargeGlyph = CType(resources.GetObject("bciExecuteAll.LargeGlyph"), System.Drawing.Image)
        Me.bciExecuteAll.Name = "bciExecuteAll"
        '
        'bbiPreview
        '
        resources.ApplyResources(Me.bbiPreview, "bbiPreview")
        Me.bbiPreview.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiPreview.Glyph = CType(resources.GetObject("bbiPreview.Glyph"), System.Drawing.Image)
        Me.bbiPreview.Id = 25
        Me.bbiPreview.LargeGlyph = CType(resources.GetObject("bbiPreview.LargeGlyph"), System.Drawing.Image)
        Me.bbiPreview.Name = "bbiPreview"
        Me.bbiPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiCompare
        '
        resources.ApplyResources(Me.bbiCompare, "bbiCompare")
        Me.bbiCompare.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiCompare.Glyph = CType(resources.GetObject("bbiCompare.Glyph"), System.Drawing.Image)
        Me.bbiCompare.Id = 26
        Me.bbiCompare.LargeGlyph = CType(resources.GetObject("bbiCompare.LargeGlyph"), System.Drawing.Image)
        Me.bbiCompare.Name = "bbiCompare"
        '
        'cbauto
        '
        resources.ApplyResources(Me.cbauto, "cbauto")
        Me.cbauto.Id = 30
        Me.cbauto.Name = "cbauto"
        '
        'RibbonPageCategory1
        '
        resources.ApplyResources(Me.RibbonPageCategory1, "RibbonPageCategory1")
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgNew, Me.rpgMulti, Me.rpgAuth, Me.rpgNavigator, Me.rpgExport, Me.rpgCompare, Me.rpgSystem})
        Me.RibbonPage2.Name = "RibbonPage2"
        '
        'rpgNew
        '
        Me.rpgNew.ItemLinks.Add(Me.bbiNew)
        Me.rpgNew.Name = "rpgNew"
        '
        'rpgMulti
        '
        Me.rpgMulti.ItemLinks.Add(Me.bbiView)
        Me.rpgMulti.ItemLinks.Add(Me.bbiEdit)
        Me.rpgMulti.ItemLinks.Add(Me.bbiDelete)
        Me.rpgMulti.Name = "rpgMulti"
        '
        'rpgAuth
        '
        Me.rpgAuth.ItemLinks.Add(Me.bbiApprove)
        Me.rpgAuth.ItemLinks.Add(Me.bbiPreview)
        Me.rpgAuth.Name = "rpgAuth"
        '
        'rpgNavigator
        '
        Me.rpgNavigator.ItemLinks.Add(Me.bbiSearch)
        Me.rpgNavigator.ItemLinks.Add(Me.bbiPrev)
        Me.rpgNavigator.ItemLinks.Add(Me.bbiNext)
        Me.rpgNavigator.ItemLinks.Add(Me.bbiFullScreen)
        Me.rpgNavigator.Name = "rpgNavigator"
        '
        'rpgExport
        '
        Me.rpgExport.ItemLinks.Add(Me.bbiExport)
        Me.rpgExport.Name = "rpgExport"
        '
        'rpgCompare
        '
        Me.rpgCompare.ItemLinks.Add(Me.bbiCompare)
        Me.rpgCompare.Name = "rpgCompare"
        '
        'rpgSystem
        '
        Me.rpgSystem.ItemLinks.Add(Me.bbiSMS)
        Me.rpgSystem.ItemLinks.Add(Me.bbiEmail)
        Me.rpgSystem.ItemLinks.Add(Me.bbiExecute)
        Me.rpgSystem.ItemLinks.Add(Me.bbiExit)
        Me.rpgSystem.Name = "rpgSystem"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.bsiStatus)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.bsiExectionFlag)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.bciCheckAll)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.bciExecuteAll)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.cbauto)
        resources.ApplyResources(Me.RibbonStatusBar1, "RibbonStatusBar1")
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.rcToolbar
        '
        'grpQuickSearch
        '
        Me.grpQuickSearch.AppearanceCaption.Font = CType(resources.GetObject("grpQuickSearch.AppearanceCaption.Font"), System.Drawing.Font)
        Me.grpQuickSearch.AppearanceCaption.Options.UseFont = True
        Me.grpQuickSearch.Controls.Add(Me.tblLayoutQuiclSearch)
        resources.ApplyResources(Me.grpQuickSearch, "grpQuickSearch")
        Me.grpQuickSearch.Name = "grpQuickSearch"
        '
        'tblLayoutQuiclSearch
        '
        resources.ApplyResources(Me.tblLayoutQuiclSearch, "tblLayoutQuiclSearch")
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition1, 0, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition2, 1, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition3, 2, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition4, 3, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition5, 4, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblCondition6, 5, 0)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition1, 0, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition2, 1, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition3, 2, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition4, 3, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition5, 4, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lueCondition6, 5, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.dtFrom, 6, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.dtTo, 7, 1)
        Me.tblLayoutQuiclSearch.Controls.Add(Me.lblQueryDate, 6, 0)
        Me.tblLayoutQuiclSearch.Name = "tblLayoutQuiclSearch"
        '
        'lblCondition1
        '
        resources.ApplyResources(Me.lblCondition1, "lblCondition1")
        Me.lblCondition1.Name = "lblCondition1"
        '
        'lblCondition2
        '
        resources.ApplyResources(Me.lblCondition2, "lblCondition2")
        Me.lblCondition2.Name = "lblCondition2"
        '
        'lblCondition3
        '
        resources.ApplyResources(Me.lblCondition3, "lblCondition3")
        Me.lblCondition3.Name = "lblCondition3"
        '
        'lblCondition4
        '
        resources.ApplyResources(Me.lblCondition4, "lblCondition4")
        Me.lblCondition4.Name = "lblCondition4"
        '
        'lblCondition5
        '
        resources.ApplyResources(Me.lblCondition5, "lblCondition5")
        Me.lblCondition5.Name = "lblCondition5"
        '
        'lblCondition6
        '
        resources.ApplyResources(Me.lblCondition6, "lblCondition6")
        Me.lblCondition6.Name = "lblCondition6"
        '
        'lueCondition1
        '
        resources.ApplyResources(Me.lueCondition1, "lueCondition1")
        Me.lueCondition1.MenuManager = Me.rcToolbar
        Me.lueCondition1.Name = "lueCondition1"
        Me.lueCondition1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition1.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition1.Properties.Buttons2"), CType(resources.GetObject("lueCondition1.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition1.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition1.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition1.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition1.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition1.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("lueCondition1.Properties.Buttons9"), CType(resources.GetObject("lueCondition1.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition1.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition1.Properties.Buttons12"), Boolean))})
        Me.lueCondition1.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns"), resources.GetString("lueCondition1.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns2"), resources.GetString("lueCondition1.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns4"), resources.GetString("lueCondition1.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns6"), resources.GetString("lueCondition1.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns8"), resources.GetString("lueCondition1.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns10"), resources.GetString("lueCondition1.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns12"), resources.GetString("lueCondition1.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns14"), resources.GetString("lueCondition1.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns16"), resources.GetString("lueCondition1.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns18"), resources.GetString("lueCondition1.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns20"), resources.GetString("lueCondition1.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns22"), resources.GetString("lueCondition1.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns24"), resources.GetString("lueCondition1.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns26"), resources.GetString("lueCondition1.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns28"), resources.GetString("lueCondition1.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns30"), resources.GetString("lueCondition1.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns32"), resources.GetString("lueCondition1.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns34"), resources.GetString("lueCondition1.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns36"), resources.GetString("lueCondition1.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns38"), resources.GetString("lueCondition1.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns40"), resources.GetString("lueCondition1.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns42"), resources.GetString("lueCondition1.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns44"), resources.GetString("lueCondition1.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns46"), resources.GetString("lueCondition1.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns48"), resources.GetString("lueCondition1.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns50"), resources.GetString("lueCondition1.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns52"), resources.GetString("lueCondition1.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns54"), resources.GetString("lueCondition1.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns56"), resources.GetString("lueCondition1.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns58"), resources.GetString("lueCondition1.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns60"), resources.GetString("lueCondition1.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns62"), resources.GetString("lueCondition1.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns64"), resources.GetString("lueCondition1.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns66"), resources.GetString("lueCondition1.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns68"), resources.GetString("lueCondition1.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns70"), resources.GetString("lueCondition1.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns72"), resources.GetString("lueCondition1.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns74"), resources.GetString("lueCondition1.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns76"), resources.GetString("lueCondition1.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns78"), resources.GetString("lueCondition1.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns80"), resources.GetString("lueCondition1.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns82"), resources.GetString("lueCondition1.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition1.Properties.Columns84"), resources.GetString("lueCondition1.Properties.Columns85"))})
        Me.lueCondition1.Properties.NullText = resources.GetString("lueCondition1.Properties.NullText")
        Me.lueCondition1.SelectedValue = Nothing
        '
        'lueCondition2
        '
        resources.ApplyResources(Me.lueCondition2, "lueCondition2")
        Me.lueCondition2.Name = "lueCondition2"
        Me.lueCondition2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition2.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition2.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition2.Properties.Buttons2"), CType(resources.GetObject("lueCondition2.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition2.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition2.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition2.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition2.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition2.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("lueCondition2.Properties.Buttons9"), CType(resources.GetObject("lueCondition2.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition2.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition2.Properties.Buttons12"), Boolean))})
        Me.lueCondition2.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns"), resources.GetString("lueCondition2.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns2"), resources.GetString("lueCondition2.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns4"), resources.GetString("lueCondition2.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns6"), resources.GetString("lueCondition2.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns8"), resources.GetString("lueCondition2.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns10"), resources.GetString("lueCondition2.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns12"), resources.GetString("lueCondition2.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns14"), resources.GetString("lueCondition2.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns16"), resources.GetString("lueCondition2.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns18"), resources.GetString("lueCondition2.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns20"), resources.GetString("lueCondition2.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns22"), resources.GetString("lueCondition2.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns24"), resources.GetString("lueCondition2.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns26"), resources.GetString("lueCondition2.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns28"), resources.GetString("lueCondition2.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns30"), resources.GetString("lueCondition2.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns32"), resources.GetString("lueCondition2.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns34"), resources.GetString("lueCondition2.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns36"), resources.GetString("lueCondition2.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns38"), resources.GetString("lueCondition2.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns40"), resources.GetString("lueCondition2.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns42"), resources.GetString("lueCondition2.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns44"), resources.GetString("lueCondition2.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns46"), resources.GetString("lueCondition2.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns48"), resources.GetString("lueCondition2.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns50"), resources.GetString("lueCondition2.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns52"), resources.GetString("lueCondition2.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns54"), resources.GetString("lueCondition2.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns56"), resources.GetString("lueCondition2.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns58"), resources.GetString("lueCondition2.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns60"), resources.GetString("lueCondition2.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns62"), resources.GetString("lueCondition2.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns64"), resources.GetString("lueCondition2.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns66"), resources.GetString("lueCondition2.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns68"), resources.GetString("lueCondition2.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns70"), resources.GetString("lueCondition2.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns72"), resources.GetString("lueCondition2.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns74"), resources.GetString("lueCondition2.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns76"), resources.GetString("lueCondition2.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns78"), resources.GetString("lueCondition2.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns80"), resources.GetString("lueCondition2.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns82"), resources.GetString("lueCondition2.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns84"), resources.GetString("lueCondition2.Properties.Columns85")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition2.Properties.Columns86"), resources.GetString("lueCondition2.Properties.Columns87"))})
        Me.lueCondition2.Properties.NullText = resources.GetString("lueCondition2.Properties.NullText")
        Me.lueCondition2.SelectedValue = Nothing
        '
        'lueCondition3
        '
        resources.ApplyResources(Me.lueCondition3, "lueCondition3")
        Me.lueCondition3.Name = "lueCondition3"
        Me.lueCondition3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition3.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition3.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition3.Properties.Buttons2"), CType(resources.GetObject("lueCondition3.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition3.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition3.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition3.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition3.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition3.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("lueCondition3.Properties.Buttons9"), CType(resources.GetObject("lueCondition3.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition3.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition3.Properties.Buttons12"), Boolean))})
        Me.lueCondition3.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns"), resources.GetString("lueCondition3.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns2"), resources.GetString("lueCondition3.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns4"), resources.GetString("lueCondition3.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns6"), resources.GetString("lueCondition3.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns8"), resources.GetString("lueCondition3.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns10"), resources.GetString("lueCondition3.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns12"), resources.GetString("lueCondition3.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns14"), resources.GetString("lueCondition3.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns16"), resources.GetString("lueCondition3.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns18"), resources.GetString("lueCondition3.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns20"), resources.GetString("lueCondition3.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns22"), resources.GetString("lueCondition3.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns24"), resources.GetString("lueCondition3.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns26"), resources.GetString("lueCondition3.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns28"), resources.GetString("lueCondition3.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns30"), resources.GetString("lueCondition3.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns32"), resources.GetString("lueCondition3.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns34"), resources.GetString("lueCondition3.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns36"), resources.GetString("lueCondition3.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns38"), resources.GetString("lueCondition3.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns40"), resources.GetString("lueCondition3.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns42"), resources.GetString("lueCondition3.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns44"), resources.GetString("lueCondition3.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns46"), resources.GetString("lueCondition3.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns48"), resources.GetString("lueCondition3.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns50"), resources.GetString("lueCondition3.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns52"), resources.GetString("lueCondition3.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns54"), resources.GetString("lueCondition3.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns56"), resources.GetString("lueCondition3.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns58"), resources.GetString("lueCondition3.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns60"), resources.GetString("lueCondition3.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns62"), resources.GetString("lueCondition3.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns64"), resources.GetString("lueCondition3.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns66"), resources.GetString("lueCondition3.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns68"), resources.GetString("lueCondition3.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns70"), resources.GetString("lueCondition3.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns72"), resources.GetString("lueCondition3.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns74"), resources.GetString("lueCondition3.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns76"), resources.GetString("lueCondition3.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns78"), resources.GetString("lueCondition3.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns80"), resources.GetString("lueCondition3.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns82"), resources.GetString("lueCondition3.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns84"), resources.GetString("lueCondition3.Properties.Columns85")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns86"), resources.GetString("lueCondition3.Properties.Columns87")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition3.Properties.Columns88"), resources.GetString("lueCondition3.Properties.Columns89"))})
        Me.lueCondition3.Properties.NullText = resources.GetString("lueCondition3.Properties.NullText")
        Me.lueCondition3.SelectedValue = Nothing
        '
        'lueCondition4
        '
        resources.ApplyResources(Me.lueCondition4, "lueCondition4")
        Me.lueCondition4.Name = "lueCondition4"
        Me.lueCondition4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition4.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition4.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition4.Properties.Buttons2"), CType(resources.GetObject("lueCondition4.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition4.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition4.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition4.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition4.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition4.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("lueCondition4.Properties.Buttons9"), CType(resources.GetObject("lueCondition4.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition4.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition4.Properties.Buttons12"), Boolean))})
        Me.lueCondition4.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns"), resources.GetString("lueCondition4.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns2"), resources.GetString("lueCondition4.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns4"), resources.GetString("lueCondition4.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns6"), resources.GetString("lueCondition4.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns8"), resources.GetString("lueCondition4.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns10"), resources.GetString("lueCondition4.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns12"), resources.GetString("lueCondition4.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns14"), resources.GetString("lueCondition4.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns16"), resources.GetString("lueCondition4.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns18"), resources.GetString("lueCondition4.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns20"), resources.GetString("lueCondition4.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns22"), resources.GetString("lueCondition4.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns24"), resources.GetString("lueCondition4.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns26"), resources.GetString("lueCondition4.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns28"), resources.GetString("lueCondition4.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns30"), resources.GetString("lueCondition4.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns32"), resources.GetString("lueCondition4.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns34"), resources.GetString("lueCondition4.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns36"), resources.GetString("lueCondition4.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns38"), resources.GetString("lueCondition4.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns40"), resources.GetString("lueCondition4.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns42"), resources.GetString("lueCondition4.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns44"), resources.GetString("lueCondition4.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns46"), resources.GetString("lueCondition4.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns48"), resources.GetString("lueCondition4.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns50"), resources.GetString("lueCondition4.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns52"), resources.GetString("lueCondition4.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns54"), resources.GetString("lueCondition4.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns56"), resources.GetString("lueCondition4.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns58"), resources.GetString("lueCondition4.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns60"), resources.GetString("lueCondition4.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns62"), resources.GetString("lueCondition4.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns64"), resources.GetString("lueCondition4.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns66"), resources.GetString("lueCondition4.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns68"), resources.GetString("lueCondition4.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns70"), resources.GetString("lueCondition4.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns72"), resources.GetString("lueCondition4.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns74"), resources.GetString("lueCondition4.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns76"), resources.GetString("lueCondition4.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns78"), resources.GetString("lueCondition4.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns80"), resources.GetString("lueCondition4.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns82"), resources.GetString("lueCondition4.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns84"), resources.GetString("lueCondition4.Properties.Columns85")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns86"), resources.GetString("lueCondition4.Properties.Columns87")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns88"), resources.GetString("lueCondition4.Properties.Columns89")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition4.Properties.Columns90"), resources.GetString("lueCondition4.Properties.Columns91"))})
        Me.lueCondition4.Properties.NullText = resources.GetString("lueCondition4.Properties.NullText")
        Me.lueCondition4.SelectedValue = Nothing
        '
        'lueCondition5
        '
        resources.ApplyResources(Me.lueCondition5, "lueCondition5")
        Me.lueCondition5.Name = "lueCondition5"
        Me.lueCondition5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition5.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition5.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition5.Properties.Buttons2"), CType(resources.GetObject("lueCondition5.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition5.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition5.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition5.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition5.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition5.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("lueCondition5.Properties.Buttons9"), CType(resources.GetObject("lueCondition5.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition5.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition5.Properties.Buttons12"), Boolean))})
        Me.lueCondition5.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns"), resources.GetString("lueCondition5.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns2"), resources.GetString("lueCondition5.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns4"), resources.GetString("lueCondition5.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns6"), resources.GetString("lueCondition5.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns8"), resources.GetString("lueCondition5.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns10"), resources.GetString("lueCondition5.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns12"), resources.GetString("lueCondition5.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns14"), resources.GetString("lueCondition5.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns16"), resources.GetString("lueCondition5.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns18"), resources.GetString("lueCondition5.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns20"), resources.GetString("lueCondition5.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns22"), resources.GetString("lueCondition5.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns24"), resources.GetString("lueCondition5.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns26"), resources.GetString("lueCondition5.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns28"), resources.GetString("lueCondition5.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns30"), resources.GetString("lueCondition5.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns32"), resources.GetString("lueCondition5.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns34"), resources.GetString("lueCondition5.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns36"), resources.GetString("lueCondition5.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns38"), resources.GetString("lueCondition5.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns40"), resources.GetString("lueCondition5.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns42"), resources.GetString("lueCondition5.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns44"), resources.GetString("lueCondition5.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns46"), resources.GetString("lueCondition5.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns48"), resources.GetString("lueCondition5.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns50"), resources.GetString("lueCondition5.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns52"), resources.GetString("lueCondition5.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns54"), resources.GetString("lueCondition5.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns56"), resources.GetString("lueCondition5.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns58"), resources.GetString("lueCondition5.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns60"), resources.GetString("lueCondition5.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns62"), resources.GetString("lueCondition5.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns64"), resources.GetString("lueCondition5.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns66"), resources.GetString("lueCondition5.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns68"), resources.GetString("lueCondition5.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns70"), resources.GetString("lueCondition5.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns72"), resources.GetString("lueCondition5.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns74"), resources.GetString("lueCondition5.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns76"), resources.GetString("lueCondition5.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns78"), resources.GetString("lueCondition5.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns80"), resources.GetString("lueCondition5.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns82"), resources.GetString("lueCondition5.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns84"), resources.GetString("lueCondition5.Properties.Columns85")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns86"), resources.GetString("lueCondition5.Properties.Columns87")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns88"), resources.GetString("lueCondition5.Properties.Columns89")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns90"), resources.GetString("lueCondition5.Properties.Columns91")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition5.Properties.Columns92"), resources.GetString("lueCondition5.Properties.Columns93"))})
        Me.lueCondition5.Properties.NullText = resources.GetString("lueCondition5.Properties.NullText")
        Me.lueCondition5.SelectedValue = Nothing
        '
        'lueCondition6
        '
        resources.ApplyResources(Me.lueCondition6, "lueCondition6")
        Me.lueCondition6.Name = "lueCondition6"
        Me.lueCondition6.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition6.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueCondition6.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueCondition6.Properties.Buttons2"), CType(resources.GetObject("lueCondition6.Properties.Buttons3"), Integer), CType(resources.GetObject("lueCondition6.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueCondition6.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueCondition6.Properties.Buttons6"), Boolean), CType(resources.GetObject("lueCondition6.Properties.Buttons7"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueCondition6.Properties.Buttons8"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("lueCondition6.Properties.Buttons9"), CType(resources.GetObject("lueCondition6.Properties.Buttons10"), Object), CType(resources.GetObject("lueCondition6.Properties.Buttons11"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueCondition6.Properties.Buttons12"), Boolean))})
        Me.lueCondition6.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns"), resources.GetString("lueCondition6.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns2"), resources.GetString("lueCondition6.Properties.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns4"), resources.GetString("lueCondition6.Properties.Columns5")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns6"), resources.GetString("lueCondition6.Properties.Columns7")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns8"), resources.GetString("lueCondition6.Properties.Columns9")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns10"), resources.GetString("lueCondition6.Properties.Columns11")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns12"), resources.GetString("lueCondition6.Properties.Columns13")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns14"), resources.GetString("lueCondition6.Properties.Columns15")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns16"), resources.GetString("lueCondition6.Properties.Columns17")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns18"), resources.GetString("lueCondition6.Properties.Columns19")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns20"), resources.GetString("lueCondition6.Properties.Columns21")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns22"), resources.GetString("lueCondition6.Properties.Columns23")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns24"), resources.GetString("lueCondition6.Properties.Columns25")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns26"), resources.GetString("lueCondition6.Properties.Columns27")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns28"), resources.GetString("lueCondition6.Properties.Columns29")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns30"), resources.GetString("lueCondition6.Properties.Columns31")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns32"), resources.GetString("lueCondition6.Properties.Columns33")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns34"), resources.GetString("lueCondition6.Properties.Columns35")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns36"), resources.GetString("lueCondition6.Properties.Columns37")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns38"), resources.GetString("lueCondition6.Properties.Columns39")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns40"), resources.GetString("lueCondition6.Properties.Columns41")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns42"), resources.GetString("lueCondition6.Properties.Columns43")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns44"), resources.GetString("lueCondition6.Properties.Columns45")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns46"), resources.GetString("lueCondition6.Properties.Columns47")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns48"), resources.GetString("lueCondition6.Properties.Columns49")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns50"), resources.GetString("lueCondition6.Properties.Columns51")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns52"), resources.GetString("lueCondition6.Properties.Columns53")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns54"), resources.GetString("lueCondition6.Properties.Columns55")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns56"), resources.GetString("lueCondition6.Properties.Columns57")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns58"), resources.GetString("lueCondition6.Properties.Columns59")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns60"), resources.GetString("lueCondition6.Properties.Columns61")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns62"), resources.GetString("lueCondition6.Properties.Columns63")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns64"), resources.GetString("lueCondition6.Properties.Columns65")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns66"), resources.GetString("lueCondition6.Properties.Columns67")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns68"), resources.GetString("lueCondition6.Properties.Columns69")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns70"), resources.GetString("lueCondition6.Properties.Columns71")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns72"), resources.GetString("lueCondition6.Properties.Columns73")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns74"), resources.GetString("lueCondition6.Properties.Columns75")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns76"), resources.GetString("lueCondition6.Properties.Columns77")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns78"), resources.GetString("lueCondition6.Properties.Columns79")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns80"), resources.GetString("lueCondition6.Properties.Columns81")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns82"), resources.GetString("lueCondition6.Properties.Columns83")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns84"), resources.GetString("lueCondition6.Properties.Columns85")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns86"), resources.GetString("lueCondition6.Properties.Columns87")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns88"), resources.GetString("lueCondition6.Properties.Columns89")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns90"), resources.GetString("lueCondition6.Properties.Columns91")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns92"), resources.GetString("lueCondition6.Properties.Columns93")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lueCondition6.Properties.Columns94"), resources.GetString("lueCondition6.Properties.Columns95"))})
        Me.lueCondition6.Properties.NullText = resources.GetString("lueCondition6.Properties.NullText")
        Me.lueCondition6.SelectedValue = Nothing
        '
        'dtFrom
        '
        resources.ApplyResources(Me.dtFrom, "dtFrom")
        Me.dtFrom.MenuManager = Me.rcToolbar
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFrom.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'dtTo
        '
        resources.ApplyResources(Me.dtTo, "dtTo")
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTo.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lblQueryDate
        '
        resources.ApplyResources(Me.lblQueryDate, "lblQueryDate")
        Me.lblQueryDate.MenuManager = Me.rcToolbar
        Me.lblQueryDate.Name = "lblQueryDate"
        Me.lblQueryDate.Properties.Caption = resources.GetString("lblQueryDate.Properties.Caption")
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiNew)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        resources.ApplyResources(Me.RibbonPageGroup1, "RibbonPageGroup1")
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        resources.ApplyResources(Me.RibbonPage1, "RibbonPage1")
        Me.RibbonPage1.Visible = False
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem1.Id = 3
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'bbiModify
        '
        Me.bbiModify.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiModify.Id = 2
        Me.bbiModify.Name = "bbiModify"
        '
        'frmXtraSearch
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sccSearch)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.rcToolbar)
        Me.KeyPreview = True
        Me.Name = "frmXtraSearch"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sccSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sccSearch.ResumeLayout(False)
        CType(Me.gcCriterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcCriterial.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcToolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpQuickSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpQuickSearch.ResumeLayout(False)
        Me.tblLayoutQuiclSearch.ResumeLayout(False)
        CType(Me.lueCondition1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQueryDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bbiNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rcToolbar As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bbiView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgNew As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgMulti As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiApprove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAuth As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgExport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents gcCriterial As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SearchGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents bsiStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiExectionFlag As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bciCheckAll As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents bbiNext As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPrev As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgNavigator As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiExecute As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSMS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiFullScreen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSystem As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents sccSearch As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents bciExecuteAll As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents fcCriterial As AppCore.Controls.XtraUcCriterial
    Friend WithEvents bbiPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpQuickSearch As DevExpress.XtraEditors.GroupControl
    Friend WithEvents tblLayoutQuiclSearch As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCondition1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCondition2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCondition3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCondition4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCondition5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCondition6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueCondition2 As AppCore.LookUpEditEx
    Friend WithEvents lueCondition3 As AppCore.LookUpEditEx
    Friend WithEvents lueCondition4 As AppCore.LookUpEditEx
    Friend WithEvents lueCondition5 As AppCore.LookUpEditEx
    Friend WithEvents lueCondition6 As AppCore.LookUpEditEx
    Friend WithEvents lueCondition1 As AppCore.LookUpEditEx
    Friend WithEvents dtFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblQueryDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents bbiCompare As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgCompare As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cbauto As DevExpress.XtraBars.BarCheckItem
End Class
