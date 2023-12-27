Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports System.Drawing
Imports System.Xml
Imports ExcelLibrary.SpreadSheet


Public Class frmSearch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = gc_LANG_VIETNAMESE
    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Private WithEvents tbnAdd As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnView As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnEdit As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnDelete As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents SeparatorTool1 As Xceed.SmartUI.Controls.ToolBar.SeparatorTool
    Private WithEvents tbnExit As Xceed.SmartUI.Controls.ToolBar.Tool

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents imlSearch As System.Windows.Forms.ImageList
    Protected WithEvents grbSearchFilter As System.Windows.Forms.GroupBox
    Protected WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grbConditionList As System.Windows.Forms.GroupBox
    Friend WithEvents grbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents txtValue As System.Windows.Forms.Control
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents cboOperator As ComboBoxEx
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents cboField As ComboBoxEx
    Friend WithEvents lblField As System.Windows.Forms.Label
    Protected WithEvents lstCondition As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    Private WithEvents ssbInfo As Xceed.SmartUI.Controls.StatusBar.SmartStatusBar
    Private WithEvents ssbPanelStatus As Xceed.SmartUI.Controls.StatusBar.SpringPanel
    Private WithEvents ssbPanelExecFlag As Xceed.SmartUI.Controls.StatusBar.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Protected WithEvents btnNEXT As System.Windows.Forms.Button
    Protected WithEvents btnBACK As System.Windows.Forms.Button
    Private WithEvents Tool1 As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnExecute As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents mnuGrid As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.MenuItem
    Protected WithEvents chkALL As System.Windows.Forms.CheckBox
    Protected WithEvents chkExeAll As System.Windows.Forms.CheckBox
    Protected WithEvents chkauto As System.Windows.Forms.CheckBox
    Private WithEvents tbnApprove As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnDispose As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnSendSMS As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnBankINQ As System.Windows.Forms.Button
    Friend WithEvents prgbBankInq As System.Windows.Forms.ProgressBar
    Private WithEvents tbnEmail As Xceed.SmartUI.Controls.ToolBar.Tool
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnAdd = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnView = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnEdit = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnApprove = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnDelete = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnEmail = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnSendSMS = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnExecute = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.tbnDispose = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.SeparatorTool1 = New Xceed.SmartUI.Controls.ToolBar.SeparatorTool
        Me.tbnExit = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.imlSearch = New System.Windows.Forms.ImageList(Me.components)
        Me.grbSearchFilter = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCompare = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnRemoveAll = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grbConditionList = New System.Windows.Forms.GroupBox
        Me.lstCondition = New System.Windows.Forms.CheckedListBox
        Me.grbCondition = New System.Windows.Forms.GroupBox
        Me.txtValue = New System.Windows.Forms.Control
        Me.lblValue = New System.Windows.Forms.Label
        Me.cboOperator = New AppCore.ComboBoxEx
        Me.lblOperator = New System.Windows.Forms.Label
        Me.cboField = New AppCore.ComboBoxEx
        Me.lblField = New System.Windows.Forms.Label
        Me.btnNEXT = New System.Windows.Forms.Button
        Me.grbSearchResult = New System.Windows.Forms.GroupBox
        Me.pnlSearchResult = New System.Windows.Forms.Panel
        Me.ssbInfo = New Xceed.SmartUI.Controls.StatusBar.SmartStatusBar(Me.components)
        Me.ssbPanelStatus = New Xceed.SmartUI.Controls.StatusBar.SpringPanel
        Me.ssbPanelExecFlag = New Xceed.SmartUI.Controls.StatusBar.Panel
        Me.btnBACK = New System.Windows.Forms.Button
        Me.Tool1 = New Xceed.SmartUI.Controls.ToolBar.Tool
        Me.mnuGrid = New System.Windows.Forms.ContextMenu
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuDeselectAll = New System.Windows.Forms.MenuItem
        Me.chkALL = New System.Windows.Forms.CheckBox
        Me.chkExeAll = New System.Windows.Forms.CheckBox
        Me.chkauto = New System.Windows.Forms.CheckBox
        Me.btnBankINQ = New System.Windows.Forms.Button
        Me.prgbBankInq = New System.Windows.Forms.ProgressBar
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbSearchFilter.SuspendLayout()
        Me.grbConditionList.SuspendLayout()
        Me.grbCondition.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        CType(Me.ssbInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SmartToolBar1.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tbnAdd, Me.tbnView, Me.tbnEdit, Me.tbnApprove, Me.tbnDelete, Me.tbnEmail, Me.tbnSendSMS, Me.tbnExecute, Me.tbnDispose, Me.SeparatorTool1, Me.tbnExit})
        Me.SmartToolBar1.ItemsImageList = Me.imlSearch
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(880, 85)
        Me.SmartToolBar1.TabIndex = 0
        Me.SmartToolBar1.Text = "SMS"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnAdd
        '
        Me.tbnAdd.ImageIndex = 4
        Me.tbnAdd.Name = "tbnAdd"
        Me.tbnAdd.Tag = Nothing
        Me.tbnAdd.Text = "tbnAdd"
        '
        'tbnView
        '
        Me.tbnView.ImageIndex = 0
        Me.tbnView.Name = "tbnView"
        Me.tbnView.OverFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnView.Tag = Nothing
        Me.tbnView.Text = "tbnView"
        '
        'tbnEdit
        '
        Me.tbnEdit.ImageIndex = 2
        Me.tbnEdit.Name = "tbnEdit"
        Me.tbnEdit.Tag = Nothing
        Me.tbnEdit.Text = "tbnEdit"
        '
        'tbnApprove
        '
        Me.tbnApprove.ImageIndex = 6
        Me.tbnApprove.Name = "tbnApprove"
        Me.tbnApprove.Tag = Nothing
        Me.tbnApprove.Text = "tbnApprove"
        '
        'tbnDelete
        '
        Me.tbnDelete.ImageIndex = 3
        Me.tbnDelete.Name = "tbnDelete"
        Me.tbnDelete.Tag = Nothing
        Me.tbnDelete.Text = "tbnDelete"
        '
        'tbnEmail
        '
        Me.tbnEmail.ImageIndex = 5
        Me.tbnEmail.Name = "tbnEmail"
        Me.tbnEmail.Tag = Nothing
        Me.tbnEmail.Text = "tbnEmail"
        '
        'tbnSendSMS
        '
        Me.tbnSendSMS.Image = CType(resources.GetObject("tbnSendSMS.Image"), System.Drawing.Image)
        Me.tbnSendSMS.Name = "tbnSendSMS"
        Me.tbnSendSMS.Tag = Nothing
        Me.tbnSendSMS.Text = "tbnSendSMS"
        '
        'tbnExecute
        '
        Me.tbnExecute.ImageIndex = 6
        Me.tbnExecute.Name = "tbnExecute"
        Me.tbnExecute.Tag = Nothing
        Me.tbnExecute.Text = "Execute"
        '
        'tbnDispose
        '
        Me.tbnDispose.ImageIndex = 7
        Me.tbnDispose.Name = "tbnDispose"
        Me.tbnDispose.Tag = Nothing
        Me.tbnDispose.Text = "tbnDispose"
        '
        'SeparatorTool1
        '
        Me.SeparatorTool1.Name = "SeparatorTool1"
        Me.SeparatorTool1.Tag = Nothing
        '
        'tbnExit
        '
        Me.tbnExit.ImageIndex = 1
        Me.tbnExit.Name = "tbnExit"
        Me.tbnExit.Tag = Nothing
        Me.tbnExit.Text = "tbnExit"
        '
        'imlSearch
        '
        Me.imlSearch.ImageStream = CType(resources.GetObject("imlSearch.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSearch.TransparentColor = System.Drawing.Color.Transparent
        Me.imlSearch.Images.SetKeyName(0, "")
        Me.imlSearch.Images.SetKeyName(1, "")
        Me.imlSearch.Images.SetKeyName(2, "")
        Me.imlSearch.Images.SetKeyName(3, "")
        Me.imlSearch.Images.SetKeyName(4, "")
        Me.imlSearch.Images.SetKeyName(5, "")
        Me.imlSearch.Images.SetKeyName(6, "")
        Me.imlSearch.Images.SetKeyName(7, "")
        Me.imlSearch.Images.SetKeyName(8, "")
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.BackColor = System.Drawing.SystemColors.Control
        Me.grbSearchFilter.Controls.Add(Me.btnPrint)
        Me.grbSearchFilter.Controls.Add(Me.btnCompare)
        Me.grbSearchFilter.Controls.Add(Me.btnExport)
        Me.grbSearchFilter.Controls.Add(Me.btnRemoveAll)
        Me.grbSearchFilter.Controls.Add(Me.btnRemove)
        Me.grbSearchFilter.Controls.Add(Me.btnAdd)
        Me.grbSearchFilter.Controls.Add(Me.btnSearch)
        Me.grbSearchFilter.Controls.Add(Me.grbConditionList)
        Me.grbSearchFilter.Controls.Add(Me.grbCondition)
        Me.grbSearchFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 49)
        Me.grbSearchFilter.Name = "grbSearchFilter"
        Me.grbSearchFilter.Size = New System.Drawing.Size(851, 151)
        Me.grbSearchFilter.TabIndex = 1
        Me.grbSearchFilter.TabStop = False
        Me.grbSearchFilter.Text = "grbSearchFilter"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(768, 112)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Tag = "btnPrint"
        Me.btnPrint.Text = "btnPrint"
        '
        'btnCompare
        '
        Me.btnCompare.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompare.Location = New System.Drawing.Point(768, 83)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(75, 23)
        Me.btnCompare.TabIndex = 9
        Me.btnCompare.Text = "btnCompare"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(768, 54)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "btnExport"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemoveAll.Location = New System.Drawing.Point(368, 96)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(32, 24)
        Me.btnRemoveAll.TabIndex = 7
        Me.btnRemoveAll.Text = "7"
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(368, 68)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 24)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "3"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(368, 40)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 24)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "4"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(768, 25)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "btnSearch"
        '
        'grbConditionList
        '
        Me.grbConditionList.Controls.Add(Me.lstCondition)
        Me.grbConditionList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbConditionList.Location = New System.Drawing.Point(408, 19)
        Me.grbConditionList.Name = "grbConditionList"
        Me.grbConditionList.Size = New System.Drawing.Size(352, 117)
        Me.grbConditionList.TabIndex = 1
        Me.grbConditionList.TabStop = False
        Me.grbConditionList.Text = "grbConditionList"
        '
        'lstCondition
        '
        Me.lstCondition.CheckOnClick = True
        Me.lstCondition.ColumnWidth = 400
        Me.lstCondition.Location = New System.Drawing.Point(8, 24)
        Me.lstCondition.Name = "lstCondition"
        Me.lstCondition.Size = New System.Drawing.Size(336, 84)
        Me.lstCondition.TabIndex = 0
        '
        'grbCondition
        '
        Me.grbCondition.Controls.Add(Me.txtValue)
        Me.grbCondition.Controls.Add(Me.lblValue)
        Me.grbCondition.Controls.Add(Me.cboOperator)
        Me.grbCondition.Controls.Add(Me.lblOperator)
        Me.grbCondition.Controls.Add(Me.cboField)
        Me.grbCondition.Controls.Add(Me.lblField)
        Me.grbCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCondition.Location = New System.Drawing.Point(8, 19)
        Me.grbCondition.Name = "grbCondition"
        Me.grbCondition.Size = New System.Drawing.Size(352, 117)
        Me.grbCondition.TabIndex = 0
        Me.grbCondition.TabStop = False
        Me.grbCondition.Text = "grbCondition"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(119, 80)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(224, 21)
        Me.txtValue.TabIndex = 5
        Me.txtValue.Text = "txtValue"
        '
        'lblValue
        '
        Me.lblValue.Location = New System.Drawing.Point(9, 82)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(102, 16)
        Me.lblValue.TabIndex = 4
        Me.lblValue.Text = "lblValue"
        '
        'cboOperator
        '
        Me.cboOperator.DisplayMember = "DISPLAY"
        Me.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperator.Location = New System.Drawing.Point(120, 52)
        Me.cboOperator.Name = "cboOperator"
        Me.cboOperator.Size = New System.Drawing.Size(224, 21)
        Me.cboOperator.TabIndex = 3
        Me.cboOperator.ValueMember = "VALUE"
        '
        'lblOperator
        '
        Me.lblOperator.Location = New System.Drawing.Point(9, 54)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(102, 16)
        Me.lblOperator.TabIndex = 2
        Me.lblOperator.Text = "lblOperator"
        '
        'cboField
        '
        Me.cboField.DisplayMember = "DISPLAY"
        Me.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboField.Location = New System.Drawing.Point(120, 24)
        Me.cboField.Name = "cboField"
        Me.cboField.Size = New System.Drawing.Size(224, 21)
        Me.cboField.TabIndex = 1
        Me.cboField.ValueMember = "VALUE"
        '
        'lblField
        '
        Me.lblField.Location = New System.Drawing.Point(10, 26)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(102, 16)
        Me.lblField.TabIndex = 0
        Me.lblField.Text = "lblField"
        '
        'btnNEXT
        '
        Me.btnNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNEXT.Location = New System.Drawing.Point(64, 528)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(48, 21)
        Me.btnNEXT.TabIndex = 9
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(5, 208)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(851, 312)
        Me.grbSearchResult.TabIndex = 2
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Text = "grbSearchResult"
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchResult.Location = New System.Drawing.Point(8, 24)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(832, 280)
        Me.pnlSearchResult.TabIndex = 0
        '
        'ssbInfo
        '
        Me.ssbInfo.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.ssbPanelStatus, Me.ssbPanelExecFlag})
        Me.ssbInfo.Location = New System.Drawing.Point(0, 549)
        Me.ssbInfo.Name = "ssbInfo"
        Me.ssbInfo.Size = New System.Drawing.Size(880, 23)
        Me.ssbInfo.TabIndex = 3
        Me.ssbInfo.Text = "ssbInfo"
        Me.ssbInfo.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'ssbPanelStatus
        '
        Me.ssbPanelStatus.Image = CType(resources.GetObject("ssbPanelStatus.Image"), System.Drawing.Image)
        Me.ssbPanelStatus.Name = "ssbPanelStatus"
        Me.ssbPanelStatus.Tag = Nothing
        Me.ssbPanelStatus.Text = "F6: Focus to grid, F7: Prev, F8: Next, F9: Choose"
        '
        'ssbPanelExecFlag
        '
        Me.ssbPanelExecFlag.Image = CType(resources.GetObject("ssbPanelExecFlag.Image"), System.Drawing.Image)
        Me.ssbPanelExecFlag.Name = "ssbPanelExecFlag"
        Me.ssbPanelExecFlag.Tag = Nothing
        '
        'btnBACK
        '
        Me.btnBACK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBACK.Location = New System.Drawing.Point(8, 528)
        Me.btnBACK.Name = "btnBACK"
        Me.btnBACK.Size = New System.Drawing.Size(48, 21)
        Me.btnBACK.TabIndex = 10
        Me.btnBACK.Tag = "btnBACK"
        Me.btnBACK.Text = "btnBACK"
        '
        'Tool1
        '
        Me.Tool1.ImageIndex = 1
        Me.Tool1.Name = "Tool1"
        Me.Tool1.Tag = Nothing
        Me.Tool1.Text = "tbnExit"
        '
        'mnuGrid
        '
        Me.mnuGrid.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSelectAll, Me.mnuDeselectAll})
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 0
        Me.mnuSelectAll.Text = "Select all"
        '
        'mnuDeselectAll
        '
        Me.mnuDeselectAll.Index = 1
        Me.mnuDeselectAll.Text = "Deselect all"
        '
        'chkALL
        '
        Me.chkALL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkALL.Location = New System.Drawing.Point(132, 531)
        Me.chkALL.Name = "chkALL"
        Me.chkALL.Size = New System.Drawing.Size(88, 16)
        Me.chkALL.TabIndex = 11
        Me.chkALL.Tag = "chkALL"
        Me.chkALL.Text = "Search All"
        '
        'chkExeAll
        '
        Me.chkExeAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkExeAll.Location = New System.Drawing.Point(569, 532)
        Me.chkExeAll.Name = "chkExeAll"
        Me.chkExeAll.Size = New System.Drawing.Size(112, 16)
        Me.chkExeAll.TabIndex = 13
        Me.chkExeAll.Tag = "chkExeAll"
        Me.chkExeAll.Text = "Allow execute all"
        '
        'chkauto
        '
        Me.chkauto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkauto.Location = New System.Drawing.Point(338, 532)
        Me.chkauto.Name = "chkauto"
        Me.chkauto.Size = New System.Drawing.Size(88, 16)
        Me.chkauto.TabIndex = 12
        Me.chkauto.Tag = "chkauto"
        Me.chkauto.Text = "Auto search"
        '
        'btnBankINQ
        '
        Me.btnBankINQ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankINQ.Location = New System.Drawing.Point(773, 526)
        Me.btnBankINQ.Name = "btnBankINQ"
        Me.btnBankINQ.Size = New System.Drawing.Size(75, 23)
        Me.btnBankINQ.TabIndex = 14
        Me.btnBankINQ.Tag = "btnBankINQ"
        Me.btnBankINQ.Text = "btnBankINQ"
        '
        'prgbBankInq
        '
        Me.prgbBankInq.Location = New System.Drawing.Point(713, 529)
        Me.prgbBankInq.Name = "prgbBankInq"
        Me.prgbBankInq.Size = New System.Drawing.Size(135, 18)
        Me.prgbBankInq.TabIndex = 15
        Me.prgbBankInq.Visible = False
        '
        'frmSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(880, 572)
        Me.Controls.Add(Me.prgbBankInq)
        Me.Controls.Add(Me.btnBankINQ)
        Me.Controls.Add(Me.chkExeAll)
        Me.Controls.Add(Me.chkALL)
        Me.Controls.Add(Me.ssbInfo)
        Me.Controls.Add(Me.grbSearchResult)
        Me.Controls.Add(Me.grbSearchFilter)
        Me.Controls.Add(Me.SmartToolBar1)
        Me.Controls.Add(Me.btnNEXT)
        Me.Controls.Add(Me.btnBACK)
        Me.Controls.Add(Me.chkauto)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSearch"
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbSearchFilter.ResumeLayout(False)
        Me.grbConditionList.ResumeLayout(False)
        Me.grbCondition.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        CType(Me.ssbInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Khai báo hằng, biến "
    Const c_ResourceManager = "AppCore.frmSearch-"
    Dim mv_dblTR_QTTY As Double = 0
    Protected WithEvents SearchGrid As GridEx
    Protected WithEvents SearchCell As Xceed.Grid.Cell
    Public mv_strSearchFilter As String
    Public mv_strSearchFilterStore As String
    Public hFilter As New Hashtable
    Public hFilterStore As New Hashtable
    Public mv_frmTransactScreen As frmTransact
    Public v_lngErrorCode As Long

    Public mv_blnAutoSearch As Boolean = False
    Public mv_blSEQNUM As Boolean = False

    'Khai bao cac bien cho khop lenh bang tay
    Public mv_strCONFIRM_NO As String = String.Empty
    Public mv_strCUSTODYCD As String = String.Empty
    Public mv_strB_CUSTODYCD As String = String.Empty
    Public mv_strS_CUSTODYCD As String = String.Empty
    Public mv_strBORS As String = String.Empty
    Public mv_strSEC_CODE As String = String.Empty
    Public mv_intQUANTITY As Integer = 0
    Public mv_intB_QUANTITY As Integer = 0
    Public mv_intS_QUANTITY As Integer = 0
    Public mv_dblPRICE As Double = 0
    Public mv_strMATCH_DATE As String = String.Empty
    Public v_strS_ACCOUNT_NO As String = String.Empty
    Public v_strB_ACCOUNT_NO As String = String.Empty
    Public v_strS_ORDER_NO As String = String.Empty
    Public v_strB_ORDER_NO As String = String.Empty

    Private mv_strCommandType As String = gc_CommandText
    Private mv_strBANKINQ As String = ""
    Private mv_strBANKACCT As String = ""
    Private mv_strCondDefFld As String = ""
    Private mv_strStoreName As String = ""
    Private mv_strStoreParam As String = ""
    Private mv_blnLoadLastSearch As Boolean = True
    Private mv_strCMDTYPE As String
    Protected mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Protected mv_strCmdSql As String
    Protected mv_strCmdSqlTemp As String
    Private mv_strcmdMenu As String
    Private mv_strTLTXCD As String
    Protected mv_strSrOderByCmd As String
    Protected mv_strObjName As String
    Private mv_strSearchAuthCode As String
    Private mv_strRowLimit As String
    Private mv_strMenuType As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean
    Private mv_strAuthCode As String
    Private mv_strAuthString As String
    Private mv_strSearchByTransact As Boolean = False
    Private mv_strIsLookup As String = "N"
    Private mv_strReturnValue As String
    Private mv_strRefValue As String
    Private mv_strReturnData As String
    Private mv_strXMLData As String
    Private mv_intDblGrid As Integer = 0
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_isAutoSubmitWhenExecue As Boolean = False

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Protected mv_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Giá trị mặc định
    Protected mv_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     '?ộ rộng hiển thị trên lưới

    Private mv_arrStFieldMandartory() As String                  'Có bắt buộc nhập điều kiện tìm kiếm không M. Mandartory, Y. Yes but optional
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerRight As String
    Protected mv_strGroupCareBy As String
    Protected mv_intpage As Int32 = 1
    Protected mv_rowpage As Int32 = 0
    Private mv_strBusDate As String
    Private mv_strTimesearch As String
    Private mv_strCUSTID As String
    Private mv_strCFCUSTODYCD As String
    Private mv_strAFACCTNO As String


    Private mv_SelectedRow As Xceed.Grid.Row

    Private mv_strEnableSearchFilter As Boolean = True
    Private mv_strLinkValue As String
    Private mv_strLinkFieldSrc As String
    Private mv_strLinkFieldDes As String
    Private mv_strNextDate As String
    Private mv_strCompanyCode As String
    Private mv_strCompanyName As String
    Private mv_strParentObjName As String
    Private mv_strParentClause As String

    Private mv_strDefaultSearchFilter As String = String.Empty

    Public mv_frmSearchScreen As frmSearch

    'Variables used for CareBy filter - Modified by TungNT
    Protected mv_isCareBy As Boolean = False
    'End Modified
    Protected mv_strSymbolList As String
    Protected mv_SymbolTable As New DataTable

    Private mv_strIsSMS As String
    Private mv_strIsEMAIL As String
    Private mv_SearchData As DataSet
    Private mv_intTotalRow As Integer




#End Region

#Region " Các thuộc tính của form "

    Public Property CompanyCode() As String
        Get
            Return mv_strCompanyCode
        End Get
        Set(ByVal Value As String)
            mv_strCompanyCode = Value
        End Set
    End Property
    Public Property CompanyName() As String
        Get
            Return mv_strCompanyName
        End Get
        Set(ByVal Value As String)
            mv_strCompanyName = Value
        End Set
    End Property
    Public Property StoreName() As String
        Get
            Return mv_strStoreName
        End Get
        Set(ByVal Value As String)
            mv_strStoreName = Value
        End Set
    End Property
    Public Property StoreParam() As String
        Get
            Return mv_strStoreParam
        End Get
        Set(ByVal Value As String)
            mv_strStoreParam = Value
        End Set
    End Property
    Public Property CommandType() As String
        Get
            Return mv_strCommandType
        End Get
        Set(ByVal Value As String)
            mv_strCommandType = Value
        End Set
    End Property

    Public Property LoadLastFilter() As Boolean
        Get
            Return mv_blnLoadLastSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnLoadLastSearch = Value
        End Set
    End Property

    Public Property DefaultSearchFilter() As String
        Get
            Return mv_strDefaultSearchFilter
        End Get
        Set(ByVal Value As String)
            mv_strDefaultSearchFilter = Value
        End Set
    End Property

    Public Property CUSTID() As String
        Get
            Return mv_strCUSTID
        End Get
        Set(ByVal Value As String)
            mv_strCUSTID = Value
        End Set
    End Property
    Public Property CUSTODYCD() As String
        Get
            Return mv_strCFCUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strCFCUSTODYCD = Value
        End Set
    End Property

    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property
    Public Property isAutoSearch() As Boolean
        Get
            Return mv_blnAutoSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAutoSearch = Value
        End Set
    End Property

    Public Property AutoSubmitWhenExecute() As Boolean
        Get
            Return mv_isAutoSubmitWhenExecue
        End Get
        Set(ByVal Value As Boolean)
            mv_isAutoSubmitWhenExecue = Value
        End Set
    End Property

    Public Property CMDMenu() As String
        Get
            Return mv_strcmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strcmdMenu = Value
        End Set
    End Property


    Public Property Timesearch() As String
        Get
            Return mv_strTimesearch
        End Get
        Set(ByVal Value As String)
            mv_strTimesearch = Value
        End Set
    End Property

    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property

    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
        End Set
    End Property

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFieldSrc() As String
        Get
            Return mv_strLinkFieldSrc
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldSrc = Value
        End Set
    End Property

    Public Property LinkFieldDes() As String
        Get
            Return mv_strLinkFieldDes
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldDes = Value
        End Set
    End Property

    Public Property EnableSearchFilter() As Boolean
        Get
            Return mv_strEnableSearchFilter
        End Get
        Set(ByVal Value As Boolean)
            mv_strEnableSearchFilter = Value
        End Set
    End Property

    Public Property NextDate() As String
        Get
            Return mv_strNextDate
        End Get
        Set(ByVal Value As String)
            mv_strNextDate = Value
        End Set
    End Property

    Public Property FULLDATA() As String
        Get
            Return mv_strXMLData
        End Get
        Set(ByVal Value As String)
            mv_strXMLData = Value
        End Set
    End Property

    Public Property RETURNDATA() As String
        Get
            Return mv_strReturnData
        End Get
        Set(ByVal Value As String)
            mv_strReturnData = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property RefValue() As String
        Get
            Return mv_strRefValue
        End Get
        Set(ByVal Value As String)
            mv_strRefValue = Value
        End Set
    End Property
    Public Property TltxCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
        End Set
    End Property

    Public Property IsLookup() As String
        Get
            Return mv_strIsLookup
        End Get
        Set(ByVal Value As String)
            mv_strIsLookup = Value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property KeyColumn() As String
        Get
            Return mv_strKeyColumn
        End Get
        Set(ByVal Value As String)
            mv_strKeyColumn = Value
        End Set
    End Property

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
        End Set
    End Property

    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property

    Public ReadOnly Property MaintenanceFormName() As String
        Get
            Return mv_strFormName
        End Get
    End Property

    Public Property MenuType() As String
        Get
            Return mv_strMenuType
        End Get
        Set(ByVal Value As String)
            mv_strMenuType = Value
        End Set
    End Property

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
        End Set
    End Property

    Public Property SearchOnInit() As Boolean
        Get
            Return mv_blnSearchOnInit
        End Get
        Set(ByVal Value As Boolean)
            mv_blnSearchOnInit = Value
        End Set
    End Property

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    'Visible button
    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
        End Set
    End Property

    'Enable button
    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property
    Public Property SearchByTransact() As Boolean
        Get
            Return mv_strSearchByTransact
        End Get
        Set(ByVal Value As Boolean)
            mv_strSearchByTransact = Value
        End Set
    End Property
    Public Property SEQNUM() As Boolean
        Get
            Return mv_blSEQNUM
        End Get
        Set(ByVal Value As Boolean)
            mv_blSEQNUM = Value
        End Set
    End Property

    Public Property CMDTYPE() As String
        Get
            Return mv_strCMDTYPE
        End Get
        Set(ByVal Value As String)
            mv_strCMDTYPE = Value
        End Set
    End Property


    'Modified by TungNT
    Public Property CareByFilter() As Boolean
        Get
            Return mv_isCareBy
        End Get
        Set(ByVal Value As Boolean)
            mv_isCareBy = Value
        End Set
    End Property
    'End Modified
    Public Property SymbolList() As String
        Get
            Return mv_strSymbolList
        End Get
        Set(ByVal Value As String)
            mv_strSymbolList = Value
        End Set
    End Property

    Public Property SymbolTable() As DataTable
        Get
            Return mv_SymbolTable
        End Get
        Set(ByVal Value As DataTable)
            mv_SymbolTable = Value
        End Set
    End Property

    Public Property ParentObjName() As String
        Get
            Return mv_strParentObjName
        End Get
        Set(ByVal Value As String)
            mv_strParentObjName = Value
        End Set
    End Property

    Public Property ParentClause() As String
        Get
            Return mv_strParentClause
        End Get
        Set(ByVal Value As String)
            mv_strParentClause = Value
        End Set
    End Property

    Public CurrentRow As Xceed.Grid.DataRow


#End Region

#Region " Overridable Function "
    Public Overridable Sub OnClose()
        Try
            If Me.IsLookup = "Y" Then
                'Nếu là form search dùng để lookup thì trả v? giá trị tìm kiếm
                If SearchGrid.DataRows.Count > 0 Then
                    If Not SearchGrid.CurrentRow Is Nothing Then
                        If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                            ReturnValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
                            CurrentRow = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow)
                            If Len(mv_strRefColumn) > 0 Then
                                RefValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strRefColumn).Value
                            Else
                                RefValue = String.Empty
                            End If
                        End If
                    End If
                End If
                Me.Close()
            Else
                If Me.TableName = "MATCH_RESULT" And Me.ModuleCode = "SA" Then
                    'Nếu là form search dùng để tim kiem trong trading_result thì trả v? giá trị tìm kiếm
                    If SearchGrid.DataRows.Count > 0 Then
                        If Not SearchGrid.CurrentRow Is Nothing Then
                            If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                                mv_strCONFIRM_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRM_NO").Value
                                mv_strB_CUSTODYCD = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ACCOUNT_NO").Value
                                mv_strS_CUSTODYCD = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ACCOUNT_NO").Value
                                mv_strSEC_CODE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SEC_CODE").Value
                                mv_intQUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QUANTITY").Value
                                mv_intB_QUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHED_BQTTY").Value
                                mv_intS_QUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHED_SQTTY").Value
                                mv_dblPRICE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value
                                mv_strMATCH_DATE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TRADING_DATE").Value
                                v_strS_ACCOUNT_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ACCOUNT_NO").Value
                                v_strB_ACCOUNT_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ACCOUNT_NO").Value
                                v_strS_ORDER_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ORDER_NO").Value
                                v_strB_ORDER_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ORDER_NO").Value
                            End If
                        End If
                    End If
                Else
                    'Ghi nhận lại đi?u kiện tìm kiếm lần cuối cùng
                    SaveLastSearch()
                End If
                Me.Dispose()
            End If
            'Me.Close()
            ''
        Catch ex As Exception

        End Try
    End Sub

    Protected Overridable Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        Select Case pv_intExecFlag
            Case ExecuteFlag.AddNew
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.AddNew")
            Case ExecuteFlag.View
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.View")
            Case ExecuteFlag.Edit
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Edit")
            Case ExecuteFlag.Delete
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Delete")
            Case ExecuteFlag.SendSMS
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.SendSMS")
            Case ExecuteFlag.Email
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Email")
        End Select
    End Function

    Protected Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
        Dim i, j As Integer
        Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, vd, v_strMessage As String
        Dim rownumber, v_intFrom, v_intTo As Int32
        Try
            'Update mouse pointer

            If Not SearchGrid.DataRows.Count = 0 Then
                If Not SearchGrid.CurrentRow Is Nothing Then
                    If KeyColumn Is Nothing Then
                    Else
                        If checkTypeGridCurrentRow(SearchGrid.CurrentRow) Then
                            Value = Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value)
                        End If
                    End If
                End If
            End If

            Cursor.Current = Cursors.WaitCursor

            'Update status bar
            ssbPanelStatus.Text = mv_ResourceManager.GetString("frmSearch.Searching")
            ssbPanelExecFlag.Text = String.Empty
            mv_strSearchFilter = String.Empty
            mv_strSearchFilterStore = String.Empty

            If CommandType = gc_CommandProcedure Then 'Command Procedure
                StoreName = mv_strCmdSql
                If Me.chkALL.Checked = True Then
                    v_intTo = 900000000
                    v_intFrom = 0

                    For i = 0 To lstCondition.Items.Count - 1
                        If lstCondition.GetItemChecked(i) Then
                            mv_strSearchFilterStore &= "||" & hFilterStore(lstCondition.Items(i).ToString)
                        End If
                    Next i
                    mv_strSearchFilterStore &= "||" & "<$BRID>" & ":" & Me.BranchId
                    mv_strSearchFilterStore &= "||" & "<$HO_BRID>" & ":" & HO_BRID
                    mv_strSearchFilterStore &= "||" & "<$BUSDATE>" & ":" & Me.BusDate
                    mv_strSearchFilterStore &= "||" & "<$AFACCTNO>" & ":" & Me.AFACCTNO
                    mv_strSearchFilterStore &= "||" & "<$CUSTID>" & ":" & Me.CUSTID
                    mv_strSearchFilterStore &= "||" & "<@KEYVALUE>" & ":" & LinkValue
                    mv_strSearchFilterStore &= "||" & "<$TELLERID>" & ":" & Me.TellerId

                    StoreParam = "p_GET_TOTAL_ROW!0!Double!20" & _
                                    "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                                    "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                                    "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                      gc_ActionInquiry, StoreName, StoreParam, , , , "L", , , CommandType)
                    v_ws.Message(v_strObjMsg)

                    Dim v_xmlDocument As New Xml.XmlDocument
                    mv_SearchData = New DataSet
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    mv_SearchData = ConvertXmlDocToDataSet(v_xmlDocument)
                    FillDataSetToGrid(SearchGrid, mv_SearchData, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, mv_SearchData.Tables(0).Rows.Count, mv_SearchData.Tables(0).Rows.Count)
                    'mv_SearchData.Dispose()
                    v_xmlDocument.RemoveAll()
                    For Each v_xColumn In SearchGrid.Columns
                        v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                        For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                            If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                                v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                                Exit For
                            End If
                        Next
                    Next

                Else
                    v_intTo = page * mv_rowpage
                    v_intFrom = v_intTo + 1 - mv_rowpage

                    For i = 0 To lstCondition.Items.Count - 1
                        If lstCondition.GetItemChecked(i) Then
                            mv_strSearchFilterStore &= "||" & hFilterStore(lstCondition.Items(i).ToString)
                        End If
                    Next i
                    mv_strSearchFilterStore &= "||" & "<$BRID>" & ":" & Me.BranchId
                    mv_strSearchFilterStore &= "||" & "<$HO_BRID>" & ":" & HO_BRID
                    mv_strSearchFilterStore &= "||" & "<$BUSDATE>" & ":" & Me.BusDate
                    mv_strSearchFilterStore &= "||" & "<$AFACCTNO>" & ":" & Me.AFACCTNO
                    mv_strSearchFilterStore &= "||" & "<$CUSTID>" & ":" & Me.CUSTID
                    mv_strSearchFilterStore &= "||" & "<@KEYVALUE>" & ":" & LinkValue
                    mv_strSearchFilterStore &= "||" & "<$TELLERID>" & ":" & Me.TellerId

                    StoreParam = "p_GET_TOTAL_ROW!0!Double!20" & _
                                    "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                                    "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                                    "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                      gc_ActionInquiry, StoreName, StoreParam, , , , , , , CommandType)
                    v_ws.Message(v_strObjMsg)
                    Me.FULLDATA = v_strObjMsg


                    StoreParam = "p_GET_TOTAL_ROW!1!Double!20" & _
                                    "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                                    "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                                    "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                      gc_ActionInquiry, StoreName, StoreParam, , , , , , , CommandType)
                    v_ws.Message(v_strObjMsg)

                    Dim v_xmlDocument As New XmlDocumentEx
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim v_strVALUE As String
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For v_intCount As Integer = 0 To v_nodeList.Count - 1
                        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                                Select Case v_strFLDNAME
                                    Case "COUNTROW"
                                        mv_intTotalRow = CInt(v_strVALUE)
                                End Select
                            End With
                        Next
                    Next

                    'Fill data into search grid
                    FillDataGrid(SearchGrid, Me.FULLDATA, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, mv_intTotalRow)
                    'Format data in search grid
                    For Each v_xColumn In SearchGrid.Columns
                        v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                        For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                            If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                                v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                                Exit For
                            End If
                        Next
                    Next
                End If
            Else 'Command text. Only for defaul condition
                'If ModuleCode & "." & mv_strObjName = OBJNAME_CA_CAMAST And Me.CMDMenu <> "" Then
                '    mv_strSearchFilter = " AND TYPEID = '" & Strings.Right(Me.CMDMenu, 3) & "'"
                'End If

                For i = 0 To lstCondition.Items.Count - 1
                    If lstCondition.GetItemChecked(i) Then
                        mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                    End If
                Next i

                'Các điều kiện tìm kiếm bắt buộc sẽ phải nhập nếu không báo lỗi
                v_strMessage = String.Empty
                For i = 0 To mv_arrStFieldMandartory.GetLength(0) - 1
                    If UCase(mv_arrStFieldMandartory(i)) = "M" Then
                        'Bắt buộc phải nhập thì tìm kiếm xem trong xâu mv_strSearchFilter có trường này không
                        If Not mv_strSearchFilter.IndexOf(mv_arrSrFieldSrch(i)) >= 0 Then
                            If v_strMessage.Length = 0 Then
                                v_strMessage = mv_arrSrFieldDisp(i)
                            Else
                                v_strMessage = v_strMessage & ", " & mv_arrSrFieldDisp(i)
                            End If
                        End If
                    End If
                Next
                If v_strMessage.Length > 0 Then
                    MsgBox(mv_ResourceManager.GetString("REQUIRE_SEARCHFILTER") & ControlChars.CrLf & v_strMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Filter by Careby - TungNT modified
                'Sua lai de bo phan huy lenh ((ModuleCode & "." & mv_strObjName = OBJNAME_OD_ODCANCEL) Or )
                ''Or ModuleCode & "." & mv_strObjName = "OD.ODMAST"

                If mv_isCareBy = True Then
                    If ModuleCode & "." & mv_strObjName = OBJNAME_CF_AFMAST Then
                        mv_strSearchFilter &= " AND INSTR('" & mv_strGroupCareBy & "',CAREBYID)>0 "
                    ElseIf ModuleCode & "." & mv_strObjName = "OD.ODMASTVIEW" Then
                        mv_strSearchFilter &= " AND REPLACE(CUSTODYCD,'.') IN (SELECT CUSTODYCD FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                    ElseIf (ModuleCode & "." & mv_strObjName = "OD.ODCTCIVIEW") Then
                        mv_strSearchFilter &= " AND REPLACE(CUSTID,'.') IN (SELECT CUSTID FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                    End If
                End If
                'End Modified

                mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    v_intTo = page * mv_rowpage
                    v_intFrom = v_intTo + 1 - mv_rowpage

                    If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
                        mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
                    End If

                    If Not mv_blSEQNUM Then
                        If mv_strSearchFilter = "" Then
                            If mv_strSrOderByCmd <> "" Then
                                mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
                            Else
                                mv_strSearchFilter = " 0 = 0 "
                            End If
                            If Me.chkALL.Checked = True Or mv_rowpage <= 0 Then
                                strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                            Else
                                If mv_strRowLimit = "Y" Then
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1 WHERE ROWNUM <= " & v_intTo & ") WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                Else
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                End If
                            End If
                            mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                        Else
                            If Me.chkALL.Checked = True Or mv_rowpage <= 0 Then
                                strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)" '  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                            Else
                                If mv_strRowLimit = "Y" Then
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1  WHERE ROWNUM <= " & v_intTo & ")  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                Else
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                End If
                            End If

                            mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter
                        End If
                    Else
                        'HaiLT them 
                        'Neu trong cau lenh SEARCH co seqnum.nextval thi phai co dieu kien san trong cau lenh     
                        If mv_strSearchFilter <> "" Then
                            strRow = mv_strCmdSql & " AND " & mv_strSearchFilter
                        Else
                            strRow = mv_strCmdSql
                        End If
                    End If

                    If SearchByTransact = True Then
                        strRow = strRow.Replace("<$BRID>", HO_BRID)
                    Else
                        strRow = strRow.Replace("<$BRID>", Me.BranchId)
                    End If
                    'TheNN sua
                    strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
                    strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)
                    strRow = strRow.Replace("<$AFACCTNO>", Me.AFACCTNO)
                    strRow = strRow.Replace("<$CUSTID>", Me.CUSTID)
                    strRow = strRow.Replace("<@KEYVALUE>", LinkValue)
                    strRow = strRow.Replace("<$TELLERID>", Me.TellerId)

                    'Trung.luu Them song ngu ơ form search
                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                        strRow = strRow.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                    Else
                        strRow = strRow.Replace("<@CDCONTENT>", "CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "DESCRIPTION")
                    End If



                    'VanNT
                    Dim v_strObjMsg As String
                    Dim v_strFullObjMsg As String
                    If Me.chkALL.Checked = True Then
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow, , , , , "L")
                    Else
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow)
                    End If

                    v_ws.Message(v_strObjMsg)
                    If Me.chkALL.Checked = True Then
                        Dim v_xmlDocument As New Xml.XmlDocument
                        mv_SearchData = New DataSet
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        mv_SearchData = ConvertXmlDocToDataSet(v_xmlDocument)
                        FillDataSetToGrid(SearchGrid, mv_SearchData, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, mv_SearchData.Tables(0).Rows.Count)
                        'mv_SearchData.Dispose()
                        v_xmlDocument.RemoveAll()
                        For Each v_xColumn In SearchGrid.Columns
                            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                                    v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                                    Exit For
                                End If
                            Next
                        Next
                        v_strFullObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow)
                        v_xmlDocument.LoadXml(v_strFullObjMsg)
                        BuildXMLObjData(mv_SearchData, v_strFullObjMsg)
                        Me.FULLDATA = v_strFullObjMsg
                    Else
                        Me.FULLDATA = v_strObjMsg
                        'Fill data into search grid
                        FillDataGrid(SearchGrid, v_strObjMsg, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
                        'Format data in search grid
                        For Each v_xColumn In SearchGrid.Columns
                            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                                    v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            End If


            ssbPanelStatus.Text = String.Empty
            'Update mouse pointer
            Cursor.Current = Cursors.Default
            SetFocusGrid(Value)
            refreshToolBar()
            Me.btnNEXT.Enabled = True
            Me.btnBACK.Enabled = True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


    Protected Overridable Function GetRowPage() As Int32
        Dim v_strCmdInquiry As String
        Dim v_strRowPage As String = String.Empty
        v_strCmdInquiry = "select VARVALUE from SYSVAR where VARNAME='ROWPERPAGE'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim RowPage As Int32
        Try
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strRowPage = Trim(v_strValue)
                                Exit For
                        End Select
                    End With
                Next
            Next
            RowPage = CInt(v_strRowPage)
            Return RowPage
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return 0
        End Try
    End Function
    Protected Overridable Function OnExport() As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                If Mid(v_strFileName, Len(v_strFileName) - 3) <> ".xls" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (SearchGrid.DataRows.Count > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        For idx As Integer = 0 To SearchGrid.Columns.Count - 1
                            If SearchGrid.Columns(idx).Visible Then
                                v_strData &= SearchGrid.Columns(idx).Title & vbTab
                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To SearchGrid.DataRows(i).Cells.Count - 1
                                If SearchGrid.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(SearchGrid.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Function
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else

                    'Ghi file excel
                    If Me.chkALL.Checked Then
                        'Dim v_Ew As New ExcelLib
                        'v_Ew.WriteXLSFile(v_strFileName, mv_SearchData)
                        'mv_SearchData.Dispose()

                        Dim v_Ew As New ExcelLib
                        v_Ew.WriteXLSFileEx(v_strFileName, mv_SearchData, Me.TableName)
                        mv_SearchData.Dispose()

                    Else
                        'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                        Dim oldCI As Globalization.CultureInfo
                        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


                        Dim objExcel As Excel.Application ' Excel object
                        Dim objWorkbook As Excel.Workbook 'Workbook object 
                        Dim objWorksheet As Excel.Worksheet 'Worksheet object 

                        objExcel = New Excel.ApplicationClass
                        'Add a new workbook 
                        objWorkbook = objExcel.Workbooks.Add()

                        'Set the Wwrksheet object to the sheet in the workbook you want to use 
                        'Note: You can use an Index number as well as specifying the name of the sheet 
                        objWorksheet = CType(objWorkbook.Worksheets.Item("Sheet1"), Excel.Worksheet)

                        Dim varInt_StartRow As Integer
                        If System.IO.File.Exists(v_strFileName) = True Then 'Check to see if file exists
                            objWorkbook = objExcel.Workbooks.Open(v_strFileName)
                            objWorksheet = objWorkbook.Worksheets.Item("Sheet1")

                            'Find last empty cell
                            varInt_StartRow = objWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                        Else
                            varInt_StartRow = 0
                        End If
                        If (SearchGrid.DataRows.Count > 0) Then



                            Dim i, j As Integer
                            'Write header
                            For idx As Integer = 0 To SearchGrid.Columns.Count - 1
                                If SearchGrid.Columns(idx).Visible Then
                                    'v_strData &= SearchGrid.Columns(idx).Title & vbTab
                                    CType(objWorksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                                    With objWorksheet.Range(objWorksheet.Cells(1, i + 1), objWorksheet.Cells(1, i + 1))
                                        .Value = CStr(SearchGrid.Columns(idx).Title)
                                        .Font.Size = 12
                                        .Font.Name = "Times New Roman"
                                        .VerticalAlignment = Excel.Constants.xlTop
                                        .HorizontalAlignment = Excel.Constants.xlCenter
                                        .Select()
                                        i = i + 1
                                    End With
                                End If
                            Next

                            'Write data
                            For j = 0 To SearchGrid.DataRows.Count - 1
                                i = 0
                                For idx As Integer = 0 To SearchGrid.DataRows(j).Cells.Count - 1
                                    If SearchGrid.Columns(idx).Visible Then
                                        With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                            .Value = CStr(SearchGrid.DataRows(j).Cells(idx).Value)
                                            .NumberFormat = "@"
                                        End With
                                        i = i + 1
                                    End If
                                Next
                            Next

                            'Save workbook before closing 
                            objWorkbook.SaveAs(v_strFileName)

                        Else
                            MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Function
                        End If

                        'Close the workbook and Excel 
                        objWorkbook.Close(False, "", Nothing)
                        objWorkbook = Nothing
                        objExcel.Quit()
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                        objExcel = Nothing

                        'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                    End If

                End If


                MsgBox(mv_ResourceManager.GetString("frmSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Exit Function

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnPrint() As Int32
        Dim v_strErrorSource, v_strErrorMessage, v_strSQL As String, v_lngError As Long, v_intRow As Integer
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Try
            If SearchGrid.DataRows.Count > 0 Then
                v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
                v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
                v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")

                'Nạp dữ liệu Header cho báo cáo tên View là: VW_PRINT_SEARCH_[SEARCHCODE]
                v_strSQL = "SELECT * FROM VW_PRINT_SEARCH_" & mv_strTableName & " WHERE KEYVALUE='" & v_strKeyFieldValue & "'"


                'Tạo báo cáo với StoredName=SearchCode

            Else
                MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToPrint"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Function
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
        End Try
    End Function

    Protected Overridable Function OnBankInq() As Int32
        Dim v_strErrorSource, v_strErrorMessage, v_strSQL As String, v_lngError As Long, v_intRow As Integer
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Try
            If SearchGrid.DataRows.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor

                prgbBankInq.Visible = True
                btnBankINQ.Visible = False
                prgbBankInq.Maximum = SearchGrid.DataRows.Count - 1
                For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                    '--Goi sang ngan hang theo so tieu khoan dinh nghia tu truong BANKACCT
                    If Not SearchGrid.DataRows(i).Cells(mv_strBANKACCT).Value Is Nothing Then
                        GetBankBalance(SearchGrid.DataRows(i).Cells(mv_strBANKACCT).Value)
                        'Threading.Thread.Sleep(1000)
                    End If
                    prgbBankInq.Value = i
                    Application.DoEvents()
                    Cursor.Current = Cursors.WaitCursor
                Next
                prgbBankInq.Visible = False
                btnBankINQ.Visible = True
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            Else
                MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToInquiry"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Function
            End If

        Catch ex As Exception
            prgbBankInq.Visible = False
            btnBankINQ.Visible = True
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Function GetBankBalance(ByVal pv_strACCTNO As String) As String
        Try
            Dim v_strClause, v_strObjMsg, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strClause = v_strValue
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , pv_strACCTNO)
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Return v_strValue
        Catch ex As Exception
            'Throw ex
            Return "0"
        End Try
    End Function

    Protected Overridable Function OnCompare() As Int32
        Try
            If Me.TableName = "CA1001" Then
                'Doi chieu so du LK khong hien thi du lieu tim kiem
                'Su dung trong truong hop du lieu lon

                Dim v_frm As New frmSearchCMP2FILE(Me.UserLanguage)
                v_frm.FULLDATA = "CA1001"
                v_frm.Searchcode = Me.TableName
                v_frm.ModuleCode = Me.ModuleCode
                v_frm.BranchId = Me.BranchId
                v_frm.TellerId = Me.TellerId
                v_frm.IpAddress = Me.IpAddress
                v_frm.WsName = Me.WsName
                v_frm.BusDate = Me.BusDate
                v_frm.Desc = Me.FormCaption
                v_frm.ISRPT = "Y"
                v_frm.ShowDialog()
            Else
                If SearchGrid.DataRows.Count > 0 Then
                    Dim v_frm As New frmSearchCMP2FILE(Me.UserLanguage)
                    v_frm.FULLDATA = Me.FULLDATA
                    If Not IsDBNull(mv_SearchData) Then
                        v_frm.mv_OldData = Me.mv_SearchData
                    End If
                    v_frm.Searchcode = Me.TableName
                    v_frm.ModuleCode = Me.ModuleCode
                    v_frm.BranchId = Me.BranchId
                    v_frm.TellerId = Me.TellerId
                    v_frm.IpAddress = Me.IpAddress
                    v_frm.WsName = Me.WsName
                    v_frm.BusDate = Me.BusDate
                    v_frm.Desc = Me.FormCaption
                    v_frm.ShowDialog()
                Else
                    MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToCompare"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnAddNew() As Int32
        If ShowForm(ExecuteFlag.AddNew) = DialogResult.OK Then
            If SearchOnInit = True Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        End If
    End Function
    Protected Overridable Function OnExecuteList() As Int32
        Try

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLTXCD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long, v_intRow As Integer


            If Not SearchGrid Is Nothing Then
                If SearchGrid.DataRows.Count > 0 Then
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                            If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                                v_strTXNUM = Trim(SearchGrid.DataRows(v_intRow).Cells("TXNUM").Value)
                                v_strTXDATE = Trim(SearchGrid.DataRows(v_intRow).Cells("TXDATE").Value)

                                'Lấy thông tin chi tiết v? �điện giao dịch
                                Dim v_strClause, v_strObjMsg As String
                                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteAutoGV", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If

                            End If
                        End If
                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("search.DeleteSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    Protected Overridable Function OnExecutedel() As Int32
        Try

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLTXCD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long, v_intRow As Integer


            If Not SearchGrid Is Nothing Then
                If SearchGrid.DataRows.Count > 0 Then
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                            If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                                v_strTXNUM = Trim(SearchGrid.DataRows(v_intRow).Cells("TXNUM").Value)
                                v_strTXDATE = Trim(SearchGrid.DataRows(v_intRow).Cells("TXDATE").Value)

                                'Lấy thông tin chi tiết v? �điện giao dịch
                                Dim v_strClause, v_strObjMsg As String
                                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteAutoGV", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If


                            End If
                        End If
                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("search.DeleteSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    Protected Overridable Sub ExecuteCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Money(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Securities(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteOD9996(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ConfirmCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ProcessOrder(ByVal pv_TableName As String, ByVal pv_GridRow As Xceed.Grid.DataRow)

    End Sub

    Protected Overridable Function SetPaymentOrderList(ByRef v_strObjMsg As String) As Int32

    End Function

    Protected Overridable Sub PrintPaymentOrder(ByVal pv_strVoucherID As String, Optional ByVal blnPrePrint As Double = False)

    End Sub

    Protected Overridable Function OnExecute(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Int32

    End Function

    Protected Overridable Sub RegisterOnline(ByRef pv_AUTOID As String, ByRef pv_CustomerType As String, ByRef pv_CustomerName As String, _
                                             ByRef pv_CustomerBirth As String, ByRef pv_IDType As String, ByRef pv_IDCode As String, _
                                             ByRef pv_Iddate As String, ByRef pv_Idplace As String, ByRef pv_Expiredate As String, _
                                             ByRef pv_Address As String, ByRef pv_Taxcode As String, ByRef pv_PrivatePhone As String, _
                                             ByRef pv_Mobile As String, ByRef pv_Fax As String, ByRef pv_Email As String, _
                                             ByRef pv_Office As String, ByRef pv_Position As String, ByRef pv_Country As String, _
                                             ByRef pv_CustomerCity As String, ByRef pv_TKTGTT As String)

    End Sub

    Protected Overridable Function OnExecute() As Int32
        Dim v_strSQL, v_strClause, v_strObjMsg As String, v_lngError As Long = ERR_SYSTEM_OK
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE, v_strISPROCESS As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String

        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'TruongLD thêm 08/05/2010: 
        'VinhLD: 07.01.2012 Bỏ trường hợp giao dịch UTTB manual InStr(gc_CI_MANUAL_ADVANCE, mv_strTLTXCD) > 0
        'If InStr("1178", mv_strTLTXCD) > 0 Then
        If InStr("CI1178||CI1179", mv_strTableName) > 0 Then
            Dim blnFlag As Boolean = False
            For v_intRow = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                    OnExecute(v_strObjMsg, v_intRow, blnFlag)
                    'blnFlag = True
                End If
            Next

            'Reset lai man hinh
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            Exit Function
        End If
        If InStr(gc_CI_PAYMENT_ORDER_LIST, mv_strTLTXCD) > 0 Then
            Dim blnFlag As Boolean = False
            For v_intRow = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                    OnExecute(v_strObjMsg, v_intRow, blnFlag)
                    'blnFlag = True
                End If
            Next

            'Reset lai man hinh
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            Exit Function
        End If
        'End TruongLD

        'HaiLT them de kiem tra neu la OD9995 thi phai check het moi' duoc EXECUTE
        If mv_strTableName = "OD9995" Then
            For v_intRow = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value <> "X" Then
                    'MsgBox("Phải thực hiện tất cả các dòng cùng một lúc!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    MsgBox(mv_ResourceManager.GetString("frmSearch.MustExecuteAll"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If
            Next
        End If

        If (mv_strTLTXCD = "EXEC" Or mv_strTLTXCD = "3382" Or mv_strTLTXCD = "3383") Then
            Select Case mv_strTableName
                Case OBJNAME_MR_SEARCH_LIQUIDITY_STATE_VIEW, "MR0008", "DF1050", "MR0103", "MR0104", "MR9000", "MR1003"
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Chi lay dong dau tien duoc tick de xu ly
                            ProcessOrder(mv_strTableName, SearchGrid.DataRows(v_intRow))
                            Exit For
                        End If
                    Next

                Case OBJNAME_CA_EXECUTE_SECURITIES_SEARCH
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            ExecuteCA_Securities(SearchGrid.DataRows(v_intRow).Cells("CAMASTID").Value)
                            'Exit For
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)


                Case "OD9996"
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            ExecuteOD9996(SearchGrid.DataRows(v_intRow).Cells("ORDERID").Value)
                            'Exit For
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)

                Case OBJNAME_CA_EXECUTE_MONEY_SEARCH
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                            ExecuteCA_Money(SearchGrid.DataRows(v_intRow).Cells("CAMASTID").Value)
                            'Exit For
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)

                Case OBJNAME_CA_CONFIRM_SEARCH
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                            ConfirmCA(SearchGrid.DataRows(v_intRow).Cells("CAMASTID").Value)
                            'Exit For
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)

                Case "DF1003", "DF1004", "DF1005"
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Chi lay dong dau tien duoc tick de xu ly
                            ProcessOrder(mv_strTableName, SearchGrid.DataRows(v_intRow))
                            Exit For
                        End If
                    Next

                Case "CA3382" 'dien comment --check thanh vien to chuc phat hanh
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Chi lay dong dau tien duoc tick de xu ly
                            'ProcessOrder(mv_strTableName, SearchGrid.DataRows(v_intRow))
                            Dim v_strAFACCTNO, v_strISSUERMEMBERCD, v_strCUSTNAME, v_strISSUER_MEMBER As String

                            v_strAFACCTNO = SearchGrid.DataRows(v_intRow).Cells("AFACCTNO").Value
                            v_strISSUERMEMBERCD = SearchGrid.DataRows(v_intRow).Cells("ISSUERMEMBERCD").Value
                            v_strCUSTNAME = SearchGrid.DataRows(v_intRow).Cells("CUSTNAME").Value

                            'v_strISSUER_MEMBER = v_strCUSTNAME & " là Thành viên quản trị của TCPH"
                            v_strISSUER_MEMBER = mv_ResourceManager.GetString("ISSUER_MEMBER")
                            v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<FULLNAME>>", v_strCUSTNAME)

                            Dim Dialog As DialogResult
                            If v_strISSUERMEMBERCD = "Y" Then
                                Dialog = MessageBox.Show(v_strISSUER_MEMBER, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                If Dialog = Windows.Forms.DialogResult.No Then
                                    Exit Function
                                Else

                                End If
                            End If
                            Exit For
                        End If
                    Next
                    'dien

                Case "CA3383" 'dien comment --check thanh vien to chuc phat hanh
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Chi lay dong dau tien duoc tick de xu ly
                            'ProcessOrder(mv_strTableName, SearchGrid.DataRows(v_intRow))
                            Dim v_strAFACCTNO, v_strISSUERMEMBERCD, v_strCUSTNAME, v_strISSUER_MEMBER As String

                            v_strAFACCTNO = SearchGrid.DataRows(v_intRow).Cells("AFACCTNO").Value
                            v_strISSUERMEMBERCD = SearchGrid.DataRows(v_intRow).Cells("ISSUERMEMBERCD").Value
                            v_strCUSTNAME = SearchGrid.DataRows(v_intRow).Cells("CUSTNAME").Value

                            'v_strISSUER_MEMBER = v_strCUSTNAME & " là Thành viên quản trị của TCPH"
                            v_strISSUER_MEMBER = mv_ResourceManager.GetString("ISSUER_MEMBER")
                            v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<FULLNAME>>", v_strCUSTNAME)

                            Dim Dialog As DialogResult
                            If v_strISSUERMEMBERCD = "Y" Then
                                Dialog = MessageBox.Show(v_strISSUER_MEMBER, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                If Dialog = Windows.Forms.DialogResult.No Then
                                    Exit Function
                                Else

                                End If
                            End If
                            Exit For
                        End If
                    Next
                Case "ODFEEBRK" ' THem moi cho phan gan tieu khoan vao chinh sach luu ky
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddContractToBrokerFee(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("ACCTNO").Value, ".", ""))
                        End If
                    Next
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "ADDTEMPLATES" ' Dang ky dich vu Email SMS
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddTemplateToContract(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("CODE").Value, ".", ""))
                        End If
                    Next
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "CFFABROKERAGE" ' dang ky ctck
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddCTCKToContract(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value, ".", ""))
                        End If
                    Next
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "FABROKERAGEXTRA" ' THANGPV SHBVNEX-2639
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddBROKERToContract(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value, ".", ""))
                        End If                     
                    Next
                    If v_lngErrorCode = 0 Then
                        Cursor.Current = Cursors.Default
                        MsgBox(ResourceManager.GetString("AddSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        'LoadTemplates(Me.txtCUSTID.Text)
                    End If
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                    'TanPN 07/02/2020
                Case "CFCFLNKAP" ' 
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddAPToContract(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value, ".", ""))
                        End If
                    Next
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "CFDDMAST" ' dang ky ctck
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            AddCFDDMAST(Strings.Replace(SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value, ".", ""))
                        End If
                    Next
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "CFOL00" 'Binhpt them cho dang ky oline
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Chi lay dong dau tien duoc tick de xu ly
                            Dim v_AUTOID, v_CustomerType, v_CustomerName, v_CustomerBirth, v_IDType, v_IDCode, v_Iddate, v_Idplace, v_Expiredate, v_Address, v_Taxcode, v_PrivatePhone, v_Mobile, v_Fax, v_Email, v_Office, v_Position, v_Country, v_CustomerCity, v_TKTGTT As String
                            v_AUTOID = SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value
                            v_CustomerType = SearchGrid.DataRows(v_intRow).Cells("CUSTOMERTYPE").Value
                            v_CustomerName = SearchGrid.DataRows(v_intRow).Cells("CUSTOMERNAME").Value
                            v_CustomerBirth = SearchGrid.DataRows(v_intRow).Cells("CUSTOMERBIRTH").Value
                            v_IDType = SearchGrid.DataRows(v_intRow).Cells("IDTYPE").Value
                            v_IDCode = SearchGrid.DataRows(v_intRow).Cells("IDCODE").Value
                            v_Iddate = SearchGrid.DataRows(v_intRow).Cells("IDDATE").Value
                            v_Idplace = SearchGrid.DataRows(v_intRow).Cells("IDPLACE").Value
                            v_Expiredate = SearchGrid.DataRows(v_intRow).Cells("EXPIREDATE").Value
                            v_Address = SearchGrid.DataRows(v_intRow).Cells("ADDRESS").Value
                            v_Taxcode = SearchGrid.DataRows(v_intRow).Cells("TAXCODE").Value
                            v_PrivatePhone = SearchGrid.DataRows(v_intRow).Cells("PRIVATEPHONE").Value
                            v_Mobile = SearchGrid.DataRows(v_intRow).Cells("MOBILE").Value
                            v_Fax = SearchGrid.DataRows(v_intRow).Cells("FAX").Value
                            v_Email = SearchGrid.DataRows(v_intRow).Cells("EMAIL").Value
                            v_Office = SearchGrid.DataRows(v_intRow).Cells("OFFICE").Value
                            v_Position = SearchGrid.DataRows(v_intRow).Cells("POSITION").Value
                            v_Country = SearchGrid.DataRows(v_intRow).Cells("COUNTRY").Value
                            v_CustomerCity = SearchGrid.DataRows(v_intRow).Cells("CUSTOMERCITY").Value
                            v_TKTGTT = SearchGrid.DataRows(v_intRow).Cells("TKTGTT").Value
                            RegisterOnline(v_AUTOID, v_CustomerType, v_CustomerName, v_CustomerBirth, v_IDType, v_IDCode, v_Iddate, v_Idplace, v_Expiredate, v_Address, v_Taxcode, v_PrivatePhone, v_Mobile, v_Fax, v_Email, v_Office, v_Position, v_Country, v_CustomerCity, v_TKTGTT)
                            Exit For
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case "CFOL01" 'Binhpt them, xoa dang ky tu oline
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            Dim v_AUTOID, v_strErrorMessage, v_strErrorSource As String
                            Dim v_lngErrorCode As Long
                            v_AUTOID = SearchGrid.DataRows(v_intRow).Cells("AUTOID").Value
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, "CF.REGISTERONLINE", gc_ActionDelete, , "AUTOID= '" & v_AUTOID & "'")
                            v_lngErrorCode = v_ws.Message(v_strObjMsg)
                            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            End If
                        End If
                    Next
                    'Reset lai man hinh
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case Else
                    'VinhLD:
                    'Xử lý cho các bảng kê: qui định searchcode của bảng kê là XX.BK.NN, XX là mã phân hệ, NN là chuỗi số (thường là 02 số cuối)
                    'Tạo chuỗi XML quét tất cả các bản ghi được chọn và submit lên host để tạo bảng kê
                    Dim v_strListOfREQID As String = String.Empty
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Lấy trường REQID để đưa lên HOST
                            v_strListOfREQID = v_strListOfREQID & "," & SearchGrid.DataRows(v_intRow).Cells("REQID").Value
                        End If

                    Next
                    If v_strListOfREQID.Length > 0 Then
                        'Loại bỏ ký tự đầu tiên
                        v_strListOfREQID = v_strListOfREQID.Substring(1)

                        'Nạp thông tin đưa lên Host xử lý
                        v_strObjMsg = String.Empty
                        'mv_strFormName: dùng để xác định ra TRFCODE loại bảng kê, v_strListOfREQID là danh sách chi tiết
                        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_CRBTRFLOG, gc_ActionAdhoc, , mv_strFormName, "CreateListOfVoucher", , , v_strListOfREQID)
                        v_lngError = v_ws.Message(v_strObjMsg)

                        'Reset lai man hinh
                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                    End If
                    Exit Function
            End Select

        Else
            'Giao dich
        End If

        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        'T07/2017 STP Them field ISPROCESS: Xu ly bo or ko bo dau cham (.) cua field 
        'v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE, nvl(SEARCHFLD.ISPROCESS,'Y') ISPROCESS  FROM APPMODULES, SEARCH, SEARCHFLD  " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty
        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                                    'Có được đánh dấu ch?n
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                        'T07/2017 STP
                                                    Case "ISPROCESS"
                                                        v_strISPROCESS = Trim(v_strValue)
                                                        'End T07/2017 STP
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then
                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                'Neu la truong posting date
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = v_strValue
                                                End If

                                            Else
                                                'Neu la truong binh thuong 
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    'T07/2017 STP
                                                    'If v_strFIELDTYPE = "C" And v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION" Then
                                                    If v_strFIELDTYPE = "C" And v_strISPROCESS = "Y" And v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION" Then
                                                        'End T07/2017 STP
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'Nạp và thực hiện giao dịch
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                        End If
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lại giá trị
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next v_intRow
                    End If
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Else
            'Sua lai ham nay cho phep thuc hien all giao dich ke ca khi gap loi doi voi cac giao dich Import
            Dim v_blnIsImport As Boolean = False
            If InStr("V_SE2240|V_SE2245|V_CI1141|V_CI1101|V_CI1187|V_SE2287|V_SE2203|LN5505", mv_strTableName) > 0 Then
                v_blnIsImport = True
            Else
                v_blnIsImport = False
            End If
            If Not v_nodeList.Count = 0 Then
                'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                                    'Có được đánh dấu chọn
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                        'T07/2017 STP
                                                    Case "ISPROCESS"
                                                        v_strISPROCESS = Trim(v_strValue)
                                                        'End T07/2017 STP
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then
                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                'Neu la truong posting date
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = v_strValue
                                                End If

                                            Else
                                                'Neu la truong binh thuong 
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    'T07/2017 STP
                                                    'If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                    If v_strFIELDTYPE = "C" And v_strISPROCESS = "Y" And (v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION") Then
                                                        'End T07/2017 STP
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'Nạp và thực hiện giao dịch
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        'TungNT modified, goi form transact kieu silent
                                        If mv_strTableName.ToUpper().EndsWith("DB") Then

                                        Else
                                            'Thuc hien goi form binh thuong
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                            mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                            mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                            mv_frmTransactScreen.BranchId = Me.BranchId
                                            mv_frmTransactScreen.TellerId = Me.TellerId
                                            mv_frmTransactScreen.IpAddress = Me.IpAddress
                                            mv_frmTransactScreen.WsName = Me.WsName
                                            mv_frmTransactScreen.BusDate = Me.BusDate

                                            If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                                mv_frmTransactScreen.PostingDate = v_strPostingDate
                                            End If

                                            'Thuc hien import giao dich
                                            If v_blnIsImport Then
                                                mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                                mv_frmTransactScreen.AutoClosedWhenOK = True
                                                mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                                mv_frmTransactScreen.ShowDialog()
                                                'If mv_frmTransactScreen.CancelClick Then
                                                '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                                '    Exit Function
                                                'End If
                                                'mv_frmTransactScreen.OnSubmit()
                                                mv_frmTransactScreen.Dispose()
                                                'Reset lại giá trị
                                                v_strFLDDEFVAL = String.Empty
                                            Else
                                                mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                                mv_frmTransactScreen.AutoClosedWhenOK = True
                                                mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                                mv_frmTransactScreen.ShowDialog()
                                                If mv_frmTransactScreen.CancelClick Then
                                                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                                    Exit Function
                                                End If
                                                'mv_frmTransactScreen.OnSubmit()
                                                mv_frmTransactScreen.Dispose()
                                                'Reset lại giá trị
                                                v_strFLDDEFVAL = String.Empty
                                            End If

                                        End If
                                        'End TungNT
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If

    End Function

    Protected Overridable Function OnQuery() As Int32
        Try
            Dim v_strView As String
            'Không HARDCODE: đặt SEARCH.AUTHCODE=YNNN cho SEARCHCODE=AFTYPE_LIST
            'If TableName = "AFTYPE_LIST" Then
            '    AuthString = "YNNN"
            'End If
            If Len(Trim(AuthString)) > 0 Then
                v_strView = Mid(Trim(AuthString), 1, 1)
                If v_strView = "Y" Then
                    ShowForm(ExecuteFlag.View)
                Else
                    Return ERR_SYSTEM_OK
                End If
            End If
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnUpdate() As Int32
        If ShowForm(ExecuteFlag.Edit) = DialogResult.OK Then
            If SearchOnInit = True Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        End If
    End Function

    'AnhVT Added - Maintenance Approval Retro
    Protected Overridable Function OnApprove() As Int32
        Try
            ShowForm(ExecuteFlag.Approve)
            'TungNT added - duyet xong phai refresh lai, tranh duyet trung
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            'TungNT end
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnDispose() As Int32
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Dim v_strDescription As String = ""
        Dim v_strObjMsg, v_strIDList, v_strSQL, v_strData, v_strFLDCDData, _
        v_strFLDCD, v_strFIELDTYPE, v_strFLDCODE, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        Try
            v_strIDList = ""
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                    If TableName = "CRBTRFLOG" Then
                        v_strIDList &= SearchGrid.DataRows(i).Cells("AUTOID").Value & ","
                    Else
                        v_strIDList &= SearchGrid.DataRows(i).Cells("REQID").Value & ","
                    End If
                End If
            Next
            If v_strIDList.EndsWith(",") Then
                v_strIDList = v_strIDList.Substring(0, v_strIDList.Length - 1)
            End If
            If v_strIDList.Length = 0 Then
                If Not SearchGrid.CurrentRow Is Nothing Then
                    If TableName = "CRBTRFLOG" Then
                        v_strIDList = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    Else
                        v_strIDList = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("REQID").Value
                    End If
                End If
            End If

            If v_strIDList.Length > 0 Then
                If TableName Like "??BK??" Then
                    If MsgBox(mv_ResourceManager.GetString("frmSearch.DisposeConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                        v_strDescription = InputBox(mv_ResourceManager.GetString("frmSearch.DisposeDescInput"), "Description")

                        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_CRBTRFLOG, gc_ActionAdhoc, , v_strIDList, "DeleteTxReq", , , v_strDescription)

                        v_lngErrorCode = v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        Else
                            MsgBox(mv_ResourceManager.GetString("frmSearch.DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        End If
                    End If
                ElseIf TableName = "CRBTRFLOG" Then
                    v_strSQL = "SELECT SRC.TLTXCD,FLD.FIELDCODE,FLD.FLDCD,FLD.FIELDTYPE FROM SEARCH SRC,SEARCHFLD FLD" & vbCrLf & _
                               "WHERE SRC.SEARCHCODE=FLD.SEARCHCODE AND SRC.SEARCHCODE='" & TableName & "' AND FLD.FLDCD IS NOT NULL"
                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strSQL, "GetHostData", , , )
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    If v_lngErrorCode <> ERR_SYSTEM_OK Then
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    Else
                        Dim v_xmlDoc As New XmlDocument()
                        v_xmlDoc.LoadXml(v_strObjMsg)
                        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDoc.DocumentElement.Attributes
                        v_strData = UnzipString((CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value).Replace("<![CDATA[", "").Replace("]]>", "")))
                        If Not v_strData Is Nothing AndAlso v_strData.Length > 0 Then
                            Dim v_ds As New DataSet
                            Dim v_rd As New StringReader(v_strData)
                            v_ds.ReadXml(v_rd)
                            If Not v_ds Is Nothing AndAlso v_ds.Tables(0).Rows.Count > 0 Then
                                v_strFLDCDData = ""
                                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                                    v_strFLDCODE = v_ds.Tables(0).Rows(i)("FIELDCODE").ToString()
                                    v_strFIELDTYPE = v_ds.Tables(0).Rows(i)("FIELDTYPE").ToString()
                                    v_strFLDCD = v_ds.Tables(0).Rows(i)("FLDCD").ToString()
                                    v_strValue = IIf(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(v_strFLDCODE).Value Is Nothing, "", CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(v_strFLDCODE).Value)
                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                        v_strValue = v_strValue.Replace(".", "").Replace(",", "")
                                    End If
                                    v_strFLDCDData = v_strFLDCDData & "[" & v_strFLDCD & "." & v_strValue & "]"
                                Next

                                SetTransactForm()
                                mv_frmTransactScreen.ObjectName = gc_RM_CHANGECRBTRFLOGSTATUS
                                mv_frmTransactScreen.ModuleCode = "RM"
                                mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                mv_frmTransactScreen.BranchId = Me.BranchId
                                mv_frmTransactScreen.TellerId = Me.TellerId
                                mv_frmTransactScreen.IpAddress = Me.IpAddress
                                mv_frmTransactScreen.WsName = Me.WsName
                                mv_frmTransactScreen.BusDate = Me.BusDate

                                mv_frmTransactScreen.DefaultValue = v_strFLDCDData
                                mv_frmTransactScreen.AutoClosedWhenOK = True
                                mv_frmTransactScreen.ShowDialog()
                                If mv_frmTransactScreen.CancelClick Then
                                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                    Exit Function
                                End If
                                'mv_frmTransactScreen.OnSubmit()
                                mv_frmTransactScreen.Dispose()
                            End If
                        End If
                    End If
                End If
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, ex.Message)
        End Try
    End Function

    Protected Overridable Function OnDelete(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(mv_ResourceManager.GetString("frmSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (SearchGrid.CurrentRow Is Nothing) Then
                        If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                            v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
                            v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
                            v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")
                            Select Case KeyFieldType
                                Case "D"
                                    v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                                Case "N"
                                    v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                                Case "C"
                                    v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                            End Select

                            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause)
                            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                            v_ws.Message(v_strObjMsg)

                            'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                            Dim v_strErrorSource, v_strErrorMessage As String
                            Dim v_lngErrorCode As Long

                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                            If v_lngErrorCode <> 0 Then
                                'Update mouse pointer
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If

                            'Remove dòng dữ liệu đã xoá kh?i grid
                            SearchGrid.CurrentRow.Remove()
                        Else
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(mv_ResourceManager.GetString("frmSearch.Footer"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If

                '?�ồng bộ lại thông tin
                'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                If SearchOnInit = True Then
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(mv_ResourceManager.GetString("frmSearch.DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Protected Overridable Function OnSMS() As Int32
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strSQL, v_strClause, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strErrorSource As String, v_strErrorMessage As String
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If mv_strTableName = "MR0002" Then
                If Not Me.chkExeAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ModuleCode & "." & ObjectName, gc_ActionAdhoc, , v_strClause, "SetMarginCallList", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    v_ws.Message(v_strObjMsg)
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            Else
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ModuleCode & "." & "SMSPROCESS", gc_ActionAdhoc, , v_strClause, "SMS_" & mv_strTableName, gc_AutoIdUsed)
                Dim count As Double
                GetDataFromGrid(v_strObjMsg, , count)
                If count <> 0 Then
                    v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.SMSSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnEmail() As Int32
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strSQL, v_strClause, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            If mv_strTableName = "DF1002" Then
                If Not Me.chkExeAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    Me.Enabled = False
                    SendEmailCall(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg, True)
                    Me.Enabled = False
                    SendEmailCall(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
            If mv_strTableName = "DF1003" Then
                If Not Me.chkExeAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    Me.Enabled = False
                    SendEmailTrigger(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg, True)
                    Me.Enabled = False
                    SendEmailTrigger(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
            If mv_strTableName = "DF1004" Then
                If Not Me.chkExeAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    Me.Enabled = False
                    SendEmailTodue(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg, True)
                    Me.Enabled = False
                    SendEmailTodue(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
            If mv_strTableName = "DF1005" Then
                If Not Me.chkExeAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    Me.Enabled = False
                    SendEmailOVD(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg, True)
                    Me.Enabled = False
                    SendEmailOVD(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Throw ex
        End Try
    End Function

#End Region

#Region " Other methods "
    Protected Overridable Sub SetTransactForm()

    End Sub

    'Hàm này dùng de gui email canh bao Trigger
    Protected Overridable Sub SendEmailCall(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTrigger(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTodue(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailOVD(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendNotification(ByVal v_strSENDVIA As String)
    End Sub

    Protected Overridable Sub InitDialog()
        'Khởi tạo kích thước form và load resource
        If DesignMode Then
            Return
        End If
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'If chkauto.Checked = False Then
        '    Timesearch = 0
        'End If

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()
        ' 
        SearchGrid = New GridEx(mv_strTableName, c_ResourceManager & UserLanguage)
        Me.pnlSearchResult.Controls.Add(SearchGrid)
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'Set double click event on Xceed Grid 
        AddHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick
        If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SearchGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                AddHandler SearchGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
            Next
        End If
        AddHandler SearchGrid.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp

        'Set click event for Xceed smart toolbar button
        AddHandler tbnAdd.Click, AddressOf Toolbar_Click
        AddHandler tbnView.Click, AddressOf Toolbar_Click
        AddHandler tbnEdit.Click, AddressOf Toolbar_Click
        AddHandler tbnDelete.Click, AddressOf Toolbar_Click
        AddHandler tbnExit.Click, AddressOf Toolbar_Click
        AddHandler tbnExecute.Click, AddressOf Toolbar_Click
        AddHandler tbnSendSMS.Click, AddressOf Toolbar_Click
        AddHandler tbnEmail.Click, AddressOf Toolbar_Click
        'AnhVT Added - Maintenance Approval Retro
        AddHandler tbnApprove.Click, AddressOf Toolbar_Click
        AddHandler tbnDispose.Click, AddressOf Toolbar_Click

        'Set click event for buttons
        AddHandler btnSearch.Click, AddressOf Button_Click
        AddHandler btnExport.Click, AddressOf Button_Click
        AddHandler btnCompare.Click, AddressOf Button_Click
        AddHandler btnAdd.Click, AddressOf Button_Click
        AddHandler btnRemove.Click, AddressOf Button_Click
        AddHandler btnRemoveAll.Click, AddressOf Button_Click

        'Set KeyDown event for Value textbox


        'Set selected index changed event for ComboBoxes
        AddHandler cboField.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged
        AddHandler cboOperator.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged

        If Not EnableSearchFilter Then
            grbSearchResult.Left = grbSearchFilter.Left
            grbSearchResult.Top = grbSearchFilter.Top
            grbSearchFilter.Visible = EnableSearchFilter
        End If

        'Thiết lập các giá trị ban đầu cho các đi?u kiện tìm kiếm
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause)

        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        PrepareSearchParams(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
            mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
            mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
            mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
            mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT)


        If mv_strSearchAuthCode.Length > 0 Then
            AuthCode = mv_strSearchAuthCode
        End If
        'Set enable status for toolbar buttons and other buttons depend on AuthCode string
        tbnAdd.Visible = (Mid(AuthCode, 1, 1) = "Y")
        tbnView.Visible = (Mid(AuthCode, 2, 1) = "Y")
        tbnEdit.Visible = (Mid(AuthCode, 3, 1) = "Y")
        tbnDelete.Visible = (Mid(AuthCode, 4, 1) = "Y")
        btnSearch.Enabled = (Mid(AuthCode, 5, 1) = "Y")
        btnExport.Enabled = (Mid(AuthCode, 6, 1) = "Y")
        tbnExecute.Visible = (Mid(AuthCode, 7, 1) = "Y")
        tbnSendSMS.Visible = (Mid(AuthCode, 8, 1) = "Y")
        tbnEmail.Visible = (Mid(AuthCode, 9, 1) = "Y")

        If mv_strBANKINQ = "Y" Then
            Me.btnBankINQ.Visible = True
        Else
            Me.btnBankINQ.Visible = False
        End If

        If mv_strSearchAuthCode.Length > 0 Then
            btnCompare.Visible = (Mid(AuthCode, 10, 1) = "Y")
            'Set check all
            Me.chkALL.Checked = (Mid(AuthCode, 10, 1) = "Y")
        Else
            btnCompare.Visible = False
            Me.chkALL.Checked = False
        End If
        'AnhVT Added - Maintenance Approval Retro
        tbnApprove.Visible = (Mid(AuthCode, 11, 1) = "Y")
        'TungNT added - them nut de xoa dong bang ke phan corebank
        'Neu dau vao ten bang duoi dang XX.BK.XX hoac fix la bang CRBTRFLOG thi se bat chuc nang nay len
        If TableName Like "??BK??" OrElse TableName = "CRBTRFLOG" Then
            tbnDispose.Visible = True
            If TableName Like "??BK??" Then
                tbnDispose.ImageIndex = 7
            Else
                tbnDispose.ImageIndex = 8
            End If
        Else
            tbnDispose.Visible = False
        End If
        'TungNT End

        'Set enable status for toolbar buttons depend on AuthString string
        If TellerId <> "0001" Then
            tbnView.Enabled = (Mid(AuthString, 1, 1) = "Y")
            tbnAdd.Enabled = (Mid(AuthString, 2, 1) = "Y")
            tbnEdit.Enabled = (Mid(AuthString, 3, 1) = "Y")
            tbnDelete.Enabled = (Mid(AuthString, 4, 1) = "Y")
            'AnhVT Added - Maintenance Approval Retro
            tbnApprove.Enabled = (Mid(AuthString, 5, 1) = "Y")
        End If

        Dim v_strCondDefFld As String = ""
        cboField.Clears()
        For i As Integer = 1 To mv_intSearchNum
            cboField.AddItems(mv_arrSrFieldDisp(i), mv_arrSrFieldSrch(i))
            If mv_arrSrFieldSrch(i) = mv_strCondDefFld Then
                v_strCondDefFld = mv_strCondDefFld
            End If
        Next
        ''Set default display search condition
        If v_strCondDefFld.Trim.Length <> 0 Then
            cboField.SelectedValue = v_strCondDefFld
        End If
        'Update form caption
        If UserLanguage <> "EN" Then
            FormCaption = mv_strCaption
        Else
            FormCaption = mv_strEnCaption
        End If
        Me.Text = FormCaption

        'Load the last filter
        If LoadLastFilter Then
            LoadLastSearch()
        End If

        If DefaultSearchFilter.Length > 0 Then
            LoadDefaultSearchFilter()
        End If


        'VanNT
        If mv_rowpage = 0 Then
            'Nếu không thiết lập sẽ lấy theo chung của mức hệ thống
            mv_rowpage = GetRowPage()
        End If

        If SearchOnInit Then
            If ObjectName.IndexOf(".") = -1 Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            Else
                OnSearch(IsLocalSearch, ObjectName)
            End If
        End If

        If Not mv_strTLTXCD Is Nothing Then
            If mv_strTLTXCD = "SMS" Then
                Me.tbnExecute.Visible = False
            Else
                If mv_strTLTXCD.Trim.Length = 0 Then Me.tbnExecute.Visible = False
            End If
        End If
        If Not ObjectName Is Nothing Then
            If Me.ObjectName.Trim.Length = 0 Then Me.tbnView.Visible = False
        End If

        'Cho phép chọn một dòng dữ liệu trên màn hình tìm kiếm để ra báo cáo
        'Gọi hàm truyền vào SearchCode & Key fields để ra báo cáo cần in
        'Nếu dùng báo cáo ADHOC thì tệp tin mẫu báo cáo chính là SearchCode
        If mv_strFormName = "frmPRINT" Then
            Me.btnPrint.Visible = True
        Else
            Me.btnPrint.Visible = False
        End If


        If mv_strTableName = "DF1002" OrElse mv_strTableName = "DF1003" OrElse mv_strTableName = "DF1004" OrElse mv_strTableName = "DF1005" Then
            Me.tbnEmail.Visible = True
            Me.tbnSendSMS.Visible = True
        Else
            'Me.tbnEmail.Visible = False
            'Me.tbnSendSMS.Visible = False
        End If

        If Me.tbnExecute.Visible Or Me.tbnSendSMS.Visible Or Me.tbnEmail.Visible Then
            If Not SearchGrid.Columns("__TICK") Is Nothing Then
                SearchGrid.Columns("__TICK").Visible = True
                SearchGrid.ContextMenu = Me.mnuGrid
            End If
        End If
        Me.btnNEXT.Enabled = False
        Me.btnBACK.Enabled = False


    End Sub

    Protected Overridable Sub DoResizeForm()
        grbSearchFilter.Width = Me.Width - 18
        btnSearch.Left = grbSearchFilter.Width - btnSearch.Width - 9
        btnExport.Left = btnSearch.Left
        btnCompare.Left = btnSearch.Left
        btnPrint.Left = btnSearch.Left
        grbConditionList.Width = grbSearchFilter.Width - btnSearch.Width - grbConditionList.Left - 18
        lstCondition.Width = grbConditionList.Width - 16

        grbSearchResult.Width = grbSearchFilter.Width
        pnlSearchResult.Width = grbSearchResult.Width - 16
        grbSearchResult.Height = Me.Height - grbSearchResult.Top - ssbInfo.Height - 60
        pnlSearchResult.Height = grbSearchResult.Height - 32
    End Sub

    Private Sub SaveLastSearch()
        'GianhVG bo di vi ben BVS yeu cau khong save last search
        'Exit Sub

        Try
            Dim v_strObjMsg As String, v_strDefVal As String = String.Empty
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            'Dim v_strSection As String = Me.ModuleCode & "." & Me.ObjectName
            Dim v_strSection As String = Me.ModuleCode & "." & Me.mv_strTableName

            Dim v_xmlDocument As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode, v_entryNodeTmp As Xml.XmlNode
            Dim v_attrObjName, v_attrChecked, v_attrValue, v_attrDisplay As Xml.XmlAttribute

            If mv_blSEQNUM Then Exit Sub
            If Len(Dir(v_strUserProfiles)) = 0 Then
                'Tạo tệp tin UserProfiles
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "USER_PROFILES:=" & Me.BranchId & "." & Me.TellerId, , , , )
                v_xmlDocument.LoadXml(v_strObjMsg)
            Else
                v_xmlDocument.Load(v_strUserProfiles)
            End If

            v_strObjMsg = v_xmlDocument.InnerXml
            'Nạp tệp tin UserProfiles
            v_nodetxData = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData[@OBJNAME='" & v_strSection & "']")
            If Not v_nodetxData Is Nothing Then
                v_xmlDocument.DocumentElement.RemoveChild(v_nodetxData)
            End If
            v_dataElement = v_xmlDocument.DocumentElement

            'Tạo node dữ liệu
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "ObjData", "")

            'Add object name
            v_attrObjName = v_xmlDocument.CreateAttribute("OBJNAME")
            v_attrObjName.Value = v_strSection
            v_entryNode.Attributes.Append(v_attrObjName)

            For i As Integer = 0 To lstCondition.Items.Count - 1
                v_entryNodeTmp = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "DataElement", "")

                'Add checked attribute
                v_attrChecked = v_xmlDocument.CreateAttribute("CHECKED")
                If lstCondition.GetItemChecked(i) Then
                    v_attrChecked.Value = "Y"
                Else
                    v_attrChecked.Value = "N"
                End If
                v_entryNodeTmp.Attributes.Append(v_attrChecked)

                'Add value attribute
                v_attrValue = v_xmlDocument.CreateAttribute("VALUE")
                v_attrValue.Value = hFilter(lstCondition.Items(i).ToString())
                v_entryNodeTmp.Attributes.Append(v_attrValue)

                'Add display attribute
                v_attrDisplay = v_xmlDocument.CreateAttribute("DISPLAY")
                v_attrDisplay.Value = lstCondition.Items(i).ToString()
                v_entryNodeTmp.Attributes.Append(v_attrDisplay)

                v_entryNode.AppendChild(v_entryNodeTmp)
            Next i

            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.AppendChild(v_dataElement)

            v_xmlDocument.Save(v_strUserProfiles)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadLastSearch()
        'GianhVG bo di vi ben BVS yeu cau khong save last search
        'If Me.TableName = "ODCANCEL" Or Me.TableName = "ODPTREPO" Then
        Try
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            'Dim v_strSection As String = Me.ModuleCode & "." & Me.ObjectName
            Dim v_strSection As String = Me.ModuleCode & "." & Me.mv_strTableName

            Dim v_xmlDocument As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode, v_nodeEntry As Xml.XmlNode
            Dim v_strObjMsg As String = String.Empty

            If Not mv_blSEQNUM Then
                If Len(Dir(v_strUserProfiles)) = 0 Then
                    'Tạo tệp tin UserProfiles
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "USER_PROFILES:=" & Me.BranchId & "." & Me.TellerId, , , , )
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_xmlDocument.Save(v_strUserProfiles)
                Else
                    'Nạp tệp tin UserProfiles
                    v_xmlDocument.Load(v_strUserProfiles)
                    v_strObjMsg = v_xmlDocument.InnerXml
                    v_nodetxData = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData[@OBJNAME='" & v_strSection & "']")

                    If Not v_nodetxData Is Nothing Then
                        For i As Integer = 0 To v_nodetxData.ChildNodes.Count - 1
                            v_nodeEntry = v_nodetxData.ChildNodes(i)

                            lstCondition.Items.Add(v_nodeEntry.Attributes("DISPLAY").Value.ToString(), (v_nodeEntry.Attributes("CHECKED").Value.ToString() = "Y"))
                            hFilter.Add(v_nodeEntry.Attributes("DISPLAY").Value.ToString(), v_nodeEntry.Attributes("VALUE").Value.ToString())
                        Next i
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
        'Else
        '    Exit Sub
        'End If


    End Sub


    Private Sub LoadDefaultSearchFilter()
        Dim v_arrSearchFilter() As String = DefaultSearchFilter.Split("^")
        Dim v_arrSearchFilterItem() As String
        Dim v_strSearchKey, v_strFilterTmp As String
        Try
            For k As Integer = 0 To v_arrSearchFilter.Length - 1
                v_arrSearchFilterItem = v_arrSearchFilter(k).Split("|")
                For i As Integer = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                    If UCase(mv_arrSrFieldSrch(i)) = v_arrSearchFilterItem(0).ToUpper Then
                        v_strSearchKey = mv_arrSrFieldDisp(i).ToString & " " & v_arrSearchFilterItem(1) & " "
                        If v_arrSearchFilterItem(3) = "D" Then
                            v_strSearchKey = v_strSearchKey & "'" & v_arrSearchFilterItem(2) & "'"
                            v_strFilterTmp = "T." & UCase(mv_arrSrFieldSrch(i)) & " " & v_arrSearchFilterItem(1) & " TO_DATE('" & v_arrSearchFilterItem(2) & "','DD/MM/RRRR')"
                        ElseIf v_arrSearchFilterItem(3) = "N" Then
                            v_strSearchKey = v_strSearchKey & v_arrSearchFilterItem(2)
                            v_strFilterTmp = "T." & UCase(mv_arrSrFieldSrch(i)) & " " & v_arrSearchFilterItem(1) & " " & v_arrSearchFilterItem(2) & ""
                        Else
                            v_strSearchKey = v_strSearchKey & "'" & v_arrSearchFilterItem(2) & "'"
                            v_strFilterTmp = "REPLACE (UPPER( Trim (T." & UCase(mv_arrSrFieldSrch(i)) & ")),'.','') " & v_arrSearchFilterItem(1) & " UPPER ('" & v_arrSearchFilterItem(2) & "')"
                        End If
                        If hFilter(v_strSearchKey) = Nothing Then
                            lstCondition.Items.Add(v_strSearchKey, True)
                            hFilter.Add(v_strSearchKey, v_strFilterTmp)
                            hFilterStore.Add(v_strSearchKey, UCase(mv_arrSrFieldSrch(i)) & ":" & v_arrSearchFilterItem(2))
                        End If
                        Exit For
                    End If
                Next

            Next

        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Overridable Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
            End If
        Next

        tbnAdd.Text = mv_ResourceManager.GetString("frmSearch.tbnAdd")
        tbnView.Text = mv_ResourceManager.GetString("frmSearch.tbnView")
        tbnEdit.Text = mv_ResourceManager.GetString("frmSearch.tbnEdit")
        tbnDelete.Text = mv_ResourceManager.GetString("frmSearch.tbnDelete")
        tbnExecute.Text = mv_ResourceManager.GetString("frmSearch.tbnExecute")
        tbnExit.Text = mv_ResourceManager.GetString("frmSearch.tbnExit")
        tbnEmail.Text = mv_ResourceManager.GetString("frmSearch.btnEmail")
        tbnSendSMS.Text = mv_ResourceManager.GetString("frmSearch.btnSendSMS")
        btnBACK.Text = mv_ResourceManager.GetString("frmSearch.btnBACK")
        btnNEXT.Text = mv_ResourceManager.GetString("frmSearch.btnNEXT")
        btnCompare.Text = mv_ResourceManager.GetString("frmSearch.tbnCompare")
        btnPrint.Text = mv_ResourceManager.GetString("frmSearch.tbnPrint")
        If TableName = "CRBTRFLOG" Then
            tbnDispose.Text = mv_ResourceManager.GetString("frmSearch.tbnDisposeC")
        Else
            tbnDispose.Text = mv_ResourceManager.GetString("frmSearch.tbnDispose")
        End If
        'AnhVT Added - Maintenance Approval Retro
        tbnApprove.Text = mv_ResourceManager.GetString("frmSearch.tbnApprove")


    End Sub

    Private Sub NewTxtValue(ByVal pv_strSqlRef As String, ByVal pv_strFldType As String, _
                            ByVal pv_strFldMask As String, ByVal pv_strDefValue As String, ByVal pv_strFldFormat As String)
        txtValue.Dispose()

        If pv_strSqlRef.Trim.Length < 1 Then
            If Trim$(mv_arrSrFieldType(cboField.SelectedIndex + 1)) = "D" Then
                Me.txtValue = New DateTimePicker
                CType(Me.txtValue, DateTimePicker).Format = DateTimePickerFormat.Custom
                CType(Me.txtValue, DateTimePicker).CustomFormat = gc_FORMAT_DATE
            Else
                If (pv_strFldMask.Trim.Length = 0) Then
                    Me.txtValue = New System.Windows.Forms.TextBox

                    Select Case pv_strFldType.Trim
                        Case "C"
                            CType(Me.txtValue, TextBox).TextAlign = HorizontalAlignment.Left
                        Case "N"
                            CType(Me.txtValue, TextBox).TextAlign = HorizontalAlignment.Right
                    End Select
                Else
                    Me.txtValue = New FlexMaskEditBox
                    CType(Me.txtValue, FlexMaskEditBox).Mask = pv_strFldMask.Trim

                    If (pv_strFldFormat.Trim.Length > 0) Then
                        CType(Me.txtValue, FlexMaskEditBox).PromptChar = pv_strFldFormat.Trim
                    End If

                    Select Case pv_strFldType.Trim
                        Case "C"
                            CType(Me.txtValue, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
                        Case "N"
                            CType(Me.txtValue, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
                    End Select
                End If
            End If
        Else
            Me.txtValue = New ComboBoxEx
        End If
        Me.grbCondition.Controls.Add(Me.txtValue)
        '
        'txtValue
        '
        Me.txtValue.Enabled = True
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Width = cboOperator.Width
        Me.txtValue.Height = cboOperator.Height
        Me.txtValue.Left = cboOperator.Left
        Me.txtValue.Top = cboOperator.Top + cboOperator.Height + (cboOperator.Top - cboField.Top - cboField.Height)
        Me.txtValue.TabIndex = cboOperator.TabIndex + 1
        If pv_strDefValue <> "" Then
            Me.txtValue.Text = pv_strDefValue
        Else
            Me.txtValue.Text = String.Empty
        End If
        Me.txtValue.Visible = True

        'Load CSDL
        If pv_strSqlRef.Trim.Length > 0 Then
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, pv_strSqlRef)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, txtValue, "", Me.UserLanguage)
        End If
    End Sub

    Private Function checkTypeGridCurrentRow(ByVal pv_ExceedRow As Xceed.Grid.Row) As Boolean
        Try
            Dim obj As New Xceed.Grid.DataRow
            obj = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub AddTemplateToContract(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String 'thunt
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("AFTEMPLATES")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("TEMPLATE_CODE")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CUSTID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("TEMPLATE_CODE") = v_strKeyValue
            v_dr("CUSTID") = Me.LinkValue
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "SA.AFTEMPLATES", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , mv_strParentObjName, mv_strParentClause)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Private Sub AddCTCKToContract(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String 'thunt them ctck
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("FABROKERAGE")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("BRKID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CUSTODYCD")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("BRKID") = v_strKeyValue
            v_dr("CUSTODYCD") = Me.LinkValue
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "CF.FABROKERAGE", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , mv_strParentObjName, mv_strParentClause)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Private Sub AddBROKERToContract(ByVal v_strKeyValue As String)
        Dim v_strSQLString, v_tesst As String
        Dim v_strClause As String 'thunt them ctck
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("FABROKERAGEXTRA")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("MEMBERID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CUSTID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("BRKID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CUSTODYCD")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("MEMBERID") = Me.LinkValue
            v_dr("CUSTID") = Me.CUSTID
            v_dr("BRKID") = v_strKeyValue
            v_dr("CUSTODYCD") = Me.CUSTODYCD
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "FA.FABROKERAGEXTRA", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , mv_strParentObjName, mv_strParentClause)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            'Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    'TanPN 07/02/2020 
    Private Sub AddAPToContract(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("CFLNKAP")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("REFID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CUSTID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("REFID") = v_strKeyValue
            v_dr("CUSTID") = Me.LinkValue
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "CF.CFLNKAP", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , mv_strParentObjName, mv_strParentClause)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub AddCFDDMAST(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String 'thunt them ctck
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("CFDDMAST")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("ACCOUNTTYPE")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("ACCOUNTBANK")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CCYBANK")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("ACCSETTLEMENT")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("DATEOPEN")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("ACCOUNTTYPE") = v_strKeyValue
            v_dr("ACCOUNTBANK") = Me.LinkValue
            v_dr("CCYBANK") = String.Empty
            v_dr("ACCSETTLEMENT") = v_strKeyValue
            v_dr("DATEOPEN") = Me.LinkValue
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "DD.DDMAST", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , mv_strParentObjName, mv_strParentClause)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Private Sub AddContractToBrokerFee(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Dim v_dsInput As DataSet
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            v_dsInput = New DataSet("INPUT")
            v_dsInput.Tables.Add("ODPROBRKAF")

            v_dc = New DataColumn("AUTOID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("REFAUTOID")
            v_dc.DataType = GetType(Double)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("AFACCTNO")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("CREATEDDATE")
            v_dc.DataType = GetType(Date)
            v_dsInput.Tables(0).Columns.Add(v_dc)
            v_dc = New DataColumn("TLID")
            v_dc.DataType = GetType(String)
            v_dsInput.Tables(0).Columns.Add(v_dc)

            v_dsInput.Tables(0).Rows.Clear()
            v_dr = v_dsInput.Tables(0).NewRow()
            v_dr("AUTOID") = String.Empty
            v_dr("REFAUTOID") = Me.LinkValue
            v_dr("AFACCTNO") = v_strKeyValue
            v_dr("CREATEDDATE") = Me.BusDate
            v_dr("TLID") = Me.TellerId
            v_dsInput.Tables(0).Rows.Add(v_dr)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, "O", "SA.ODPROBRKAF", gc_ActionAdd, , , , gc_AutoIdUsed)
            BuildXMLObjData(v_dsInput, v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As Xml.XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountRow, v_intCountCol As Integer
            Dim v_XmlNode As Xml.XmlNode

            Dim v_nodeXSD, v_nodeXML As Xml.XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXML")
            v_strDataXSD = v_nodeXSD.InnerText
            v_strDataXML = v_nodeXML.InnerText
            'Get schema
            Dim v_XSD As New TestBase64.Base64Decoder(v_strDataXSD)
            v_arrXSDByteMessage = v_XSD.GetDecoded()
            v_strDataXSD = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXSDByteMessage)
            'Get data
            Dim v_XML As New TestBase64.Base64Decoder(v_strDataXML)
            v_arrXMLByteMessage = v_XML.GetDecoded()
            v_strDataXML = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXMLByteMessage)
            'Create dataset
            Dim v_XMLREADER, v_XSDREADER As System.IO.StringReader
            v_XMLREADER = New System.IO.StringReader(v_strDataXML)
            v_XSDREADER = New System.IO.StringReader(v_strDataXSD)
            If v_ds Is Nothing Then v_ds = New DataSet
            v_ds.Tables.Clear()
            v_ds.ReadXmlSchema(v_XSDREADER)
            v_ds.ReadXml(v_XMLREADER)
            v_ds.Tables(0).TableName = "ObjData"
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Các sự kiện của form "

    Private Sub frmSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OnClose()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then
            Return
        End If
        InitDialog()

        refreshToolBar()
    End Sub

    Private Sub frmSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub txtValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValue.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    AddSearchCriteria()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.txtValue_KeyDown" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim CountR As Int32
        Try
            Select Case e.KeyCode
                Case Keys.F6
                    If Not (SearchGrid Is Nothing) Then
                        If SearchGrid.Enabled And SearchGrid.Visible Then
                            SearchGrid.Focus()
                            If Not SearchGrid.CurrentRow Is Nothing Then
                                Dim dataRows As Xceed.Grid.Collections.ReadOnlyDataRowList = SearchGrid.GetSortedDataRows(True)
                                Dim firstTaggedDataRow As Xceed.Grid.DataRow = dataRows(0)
                                SearchGrid.CurrentRow = firstTaggedDataRow
                            End If
                        End If
                    End If
                Case Keys.F7    'Prev
                    mv_intpage = mv_intpage - 1
                    If mv_intpage <= 0 Then
                        mv_intpage = 1
                    End If
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case Keys.F8    'Next
                    If CommandType = gc_CommandProcedure Then
                        CountR = mv_intTotalRow
                    Else
                        CountR = CountRow()
                    End If
                    If CountR >= (mv_intpage + 1) * mv_rowpage Then
                        mv_intpage = mv_intpage + 1
                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                    End If
                Case Keys.F9
                    'Tương đương nhấn Double Click của dòng hiện tại
                    If mv_intDblGrid = 0 Then
                        mv_intDblGrid = 1
                        If Me.tbnView.Visible = False Then
                            OnClose()
                        End If
                        OnQuery()
                        mv_intDblGrid = 0
                    End If
                Case Keys.Escape
                    OnClose()
                Case Keys.C
                    If Keys.Control Then
                        If Not (SearchGrid.CurrentRow Is Nothing) Then
                            If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                                If mv_strKeyColumn Is Nothing Then
                                    Clipboard.SetDataObject(SearchGrid.CurrentCell.Value)
                                Else
                                    Clipboard.SetDataObject(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value)
                                End If
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not SearchGrid.CurrentColumn Is Nothing Then
            If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                If SearchGrid.CurrentCell.Value = "X" Then
                    SearchGrid.CurrentCell.Value = String.Empty
                Else
                    SearchGrid.CurrentCell.Value = "X"
                End If
            End If
        End If
        refreshToolBar()
    End Sub

    Private Sub refreshToolBar()
        If DesignMode Then
            Return
        End If
        Dim addAuth As Boolean = (Mid(AuthCode, 1, 1) = "Y")
        Dim editAuth As Boolean = (Mid(AuthCode, 3, 1) = "Y")
        Dim viewAuth As Boolean = (Mid(AuthCode, 2, 1) = "Y")
        Dim delAuth As Boolean = (Mid(AuthCode, 4, 1) = "Y")
        Dim apprAuth As Boolean = (Mid(AuthCode, 11, 1) = "Y")


        Dim editAuthString As Boolean = (Mid(AuthString, 3, 1) = "Y")
        Dim delAuthString As Boolean = (Mid(AuthString, 4, 1) = "Y")
        Dim apprAuthString As Boolean = (Mid(AuthString, 5, 1) = "Y")




        '2010/04/21 - TRUONGLD Added - Kiem tra khong cho sua, duyet doi voi man hinh CFMAST, AFMAST khi trang thai dang block hoac dong    
        If Not SearchGrid.CurrentRow Is Nothing Then
            If SearchGrid.Columns.Contains(SearchGrid.Columns("EDITALLOW")) = True Then
                Dim v_strEDITALLOW As String = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EDITALLOW").Value
                If v_strEDITALLOW = "Y" Then
                    tbnEdit.Enabled = True And editAuth And editAuthString
                Else
                    tbnEdit.Enabled = False And editAuth And editAuthString
                End If
            End If
            If SearchGrid.Columns.Contains(SearchGrid.Columns("APRALLOW")) = True Then
                Dim v_strAPRALLOW As String = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("APRALLOW").Value
                If v_strAPRALLOW = "Y" Then
                    tbnApprove.Enabled = True And apprAuth And apprAuthString
                Else
                    tbnApprove.Enabled = False And apprAuth And apprAuthString
                End If
            End If
            If SearchGrid.Columns.Contains(SearchGrid.Columns("DELALLOW")) = True Then
                Dim v_strDELALLOW As String = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELALLOW").Value
                If v_strDELALLOW = "Y" Then
                    tbnDelete.Enabled = True And delAuth And delAuthString
                Else
                    tbnDelete.Enabled = False And delAuth And delAuthString
                End If
            End If
            If SearchGrid.Columns.Contains(SearchGrid.Columns("DISPALLOW")) = True Then
                Dim v_strDISPALLOW As String = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DISPALLOW").Value
                If v_strDISPALLOW = "Y" Then
                    tbnDispose.Enabled = True
                Else
                    tbnDispose.Enabled = False
                End If
            End If
        End If
        'End Truongld

        If SearchGrid.CurrentRow Is Nothing Then
            tbnApprove.Enabled = True And apprAuth And apprAuthString
            tbnDelete.Enabled = True And delAuth And delAuthString
        End If
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'QuangVD: khi double click thi lay ma loai hinh vao man hinh them moi tieu khoan
        If TableName = "AFTYPE_LIST" Then
            OnClose()
            'Me.Close()
            Return
        End If
        'QuangVD: end

        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()

        'BO chon tren cac dong.
        For i As Integer = 0 To SearchGrid.DataRows.Count - 1
            CType(SearchGrid.DataRows(i), Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
        Next

        If mv_intDblGrid = 0 Then
            mv_intDblGrid = 1
            If Me.tbnExecute.Visible Then
                If SearchGrid.DataRows.Count > 0 Then
                    If Not SearchGrid.CurrentRow Is Nothing Then
                        CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X"
                        OnExecute()   'Execute
                        'Exit Sub
                    End If
                End If
            ElseIf Me.tbnView.Visible Then
                If Len(Trim(Me.AuthString)) > 0 Then
                    If Mid(Trim(AuthString), 1, 1) = "Y" Then
                        OnQuery()
                    Else
                        OnClose()
                    End If
                Else
                    OnClose()
                End If
            Else
                'Default is choose and close
                OnClose()
            End If
            mv_intDblGrid = 0
        End If
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Down, Keys.Up
                    refreshToolBar()
                Case Keys.Space
                    Cursor.Current = Cursors.WaitCursor
                    Cursor.Show()
                    If Not SearchGrid.Columns("__TICK") Is Nothing Then
                        If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                            If SearchGrid.CurrentCell.Value = "X" Then
                                SearchGrid.CurrentCell.Value = String.Empty
                            Else
                                SearchGrid.CurrentCell.Value = "X"
                            End If
                        End If
                    End If
                Case Keys.Enter 'Enter = OnClose de insert luon cho GD, Double_click =View 
                    Cursor.Current = Cursors.WaitCursor
                    Cursor.Show()
                    OnClose()
                Case Keys.Delete
                    OnDelete()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Toolbar_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        CType(sender, Xceed.SmartUI.SmartItem).Enabled = False
        If (sender Is tbnAdd) And (tbnAdd.Visible = True) Then
            OnAddNew()
        ElseIf (sender Is tbnExecute) And (tbnExecute.Visible = True) And CMDTYPE = "V" Then
            OnExecute()
        ElseIf (sender Is tbnExecute) And (tbnExecute.Visible = True) And CMDTYPE = "D" Then
            OnExecutedel()
        ElseIf (sender Is tbnView) And (tbnView.Visible = True) Then
            OnQuery()
        ElseIf (sender Is tbnEdit) And (tbnEdit.Visible = True) Then
            OnUpdate()
        ElseIf (sender Is tbnDelete) And (tbnDelete.Visible = True) Then
            OnDelete(IsLocalSearch, ModuleCode & "." & ObjectName)
        ElseIf (sender Is tbnSendSMS) And (tbnSendSMS.Visible = True) Then
            'OnSMS()
            SendNotification(gc_SEND_VIA_SMS)
        ElseIf (sender Is tbnEmail) And (tbnEmail.Visible = True) Then
            SendNotification(gc_SEND_VIA_EMAIL)
            'AnhVT Added - Maintenance Approval Retro
        ElseIf (sender Is tbnApprove) And (tbnApprove.Visible = True) Then
            OnApprove()
        ElseIf (sender Is tbnDispose) And (tbnDispose.Visible = True) Then
            OnDispose()
        ElseIf (sender Is tbnExit) Then
            OnClose()
        End If
        CType(sender, Xceed.SmartUI.SmartItem).Enabled = True
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strValue, v_strValueDisplay As String
        Dim v_objResult As Object
        Dim v_strFilterTmp As String
        Dim v_strSearchKey As String
        Dim v_blnSearchKeyAdded As Boolean

        Try
            If (sender Is btnSearch) Then
                mv_intpage = 1
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            ElseIf (sender Is btnExport) Then
                OnExport()
            ElseIf (sender Is btnCompare) Then
                OnCompare()
            ElseIf (sender Is btnAdd) Then
                AddSearchCriteria()
            ElseIf (sender Is btnRemove) Then
                RemoveSearchCriteria()
            ElseIf (sender Is btnRemoveAll) Then
                RemoveAllSearchCriterias()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (sender Is cboField) Then
            'Load các toán tử đi?u kiện
            AnalyzeOperator(mv_arrSrFieldOperator(cboField.SelectedIndex + 1), mv_arrSrOperator)
            cboOperator.Clears()
            For i As Integer = 1 To mv_arrSrOperator.Length
                cboOperator.AddItems(mv_arrSrOperator(i - 1), mv_arrSrOperator(i - 1))
            Next

            If CStr(Me.cboOperator.SelectedValue).Equals("LIKE") Then
                'Neu dieu kien tim kiem la like thi chuyen ve text box de bo dinh dang
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                    String.Empty, mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            Else
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                mv_arrSrFieldMask(cboField.SelectedIndex + 1), mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            End If

        ElseIf (sender Is cboOperator) Then
            If Convert.ToString(Me.cboOperator.SelectedValue).Equals("LIKE") Then
                'Neu dieu kien tim kiem la like thi chuyen ve text box de bo dinh dang
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                    String.Empty, mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            Else
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                mv_arrSrFieldMask(cboField.SelectedIndex + 1), mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            End If
            'Khi dieu kien tim kiem la like thi bo dinh dang
        End If
    End Sub

    Private Sub btnNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEXT.Click
        Dim CountR As Int32
        If CommandType = gc_CommandProcedure Then
            CountR = mv_intTotalRow
        Else
            CountR = CountRow()
        End If
        If CountR >= (mv_intpage) * mv_rowpage Then
            mv_intpage = mv_intpage + 1
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        End If
    End Sub

    Private Sub btnBACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBACK.Click

        mv_intpage = mv_intpage - 1
        If mv_intpage <= 0 Then
            mv_intpage = 1
        End If
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
    End Sub
    Private Sub tmrSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, 1)
        AddHandler btnSearch.Click, AddressOf Button_Click
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, 1)
    End Sub

    Protected Function CountRow() As Int32
        Try

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_intCOUNTROW As Int32
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "select COUNT(*) COUNTROW from (" & mv_strCmdSqlTemp & ") WHERE 0=0"

            'TheNN sua
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$BRID>", Me.BranchId)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$HO_BRID>", HO_BRID)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$BUSDATE>", Me.BusDate)
            'VanNT
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$AFACCTNO>", Me.AFACCTNO)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$CUSTID>", Me.CUSTID)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<@KEYVALUE>", LinkValue)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$TELLERID>", Me.TellerId)

            'Trung.luu Them song ngu ơ form search
            If Me.UserLanguage = gc_LANG_ENGLISH Then
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
            Else
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@CDCONTENT>", "CDCONTENT")
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@DESCRIPTION>", "DESCRIPTION")
            End If


            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, ModuleCode & "." & ObjectName, _
                                          gc_ActionInquiry, v_strCmdInquiry)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "COUNTROW"
                                v_intCOUNTROW = v_strVALUE
                        End Select
                    End With
                Next
            Next
            Return v_intCOUNTROW
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Private Sub frmSearch_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Dim width As Int16
        width = Me.Width
        If width < 640 Then
            Me.Width = 640
            Me.Left = 0
        End If

    End Sub

    Private Sub AddSearchCriteria()
        Try
            Dim v_strValue, v_strValueDisplay As String
            Dim v_objResult As Object
            Dim v_strFilterTmp As String
            Dim v_strFilterTmpUpper As String
            Dim v_strSearchKey As String
            Dim v_blnSearchKeyAdded As Boolean
            Dim i1 As Int16
            v_strValueDisplay = Trim(txtValue.Text)
            If mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length > 0 Then
                v_strValue = v_strValueDisplay
            Else
                v_strValue = Trim(txtValue.Text.ToString)

            End If

            If v_strValue <> String.Empty Then
                v_objResult = hFilter(mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
                    & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & " " _
                    & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
                    & v_strValueDisplay & IIf(Trim(mv_arrSrFieldType(cboField.SelectedIndex + 1)) <> "N", "'", ""))

                If (v_objResult Is Nothing) Then
                    v_blnSearchKeyAdded = False
                    v_strSearchKey = mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
                        & cboOperator.SelectedValue & " " & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
                        & v_strValueDisplay & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "")

                    For i As Integer = 0 To lstCondition.Items.Count - 1
                        If lstCondition.Items(i).ToString() = v_strSearchKey Then
                            v_blnSearchKeyAdded = True
                            Exit For
                        End If
                    Next

                    If Not v_blnSearchKeyAdded Then
                        If Not mv_blSEQNUM Then
                            v_strFilterTmp = "T."
                        End If
                        v_strFilterTmp &= IIf(mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length = 0, _
                            mv_arrSrFieldSrch(cboField.SelectedIndex + 1), _
                            mv_arrSrFieldSrch(cboField.SelectedIndex + 1))
                        v_strFilterTmpUpper = "REPLACE (UPPER( Trim (" & v_strFilterTmp & ")),'.','')"
                        v_strFilterTmp &= " " & cboOperator.SelectedValue & " "
                        v_strFilterTmpUpper &= " " & cboOperator.SelectedValue & " "
                        Select Case mv_arrSrFieldType(cboField.SelectedIndex + 1)
                            Case "D"
                                v_strFilterTmp &= "TO_DATE('" & v_strValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"

                                If IsNumeric(v_strValue) Then
                                    v_strFilterTmp &= CDbl(v_strValue)
                                Else
                                    Exit Sub
                                End If
                            Case "C"
                                v_strValue = Trim(Replace(v_strValue, ".", String.Empty))

                                If InStr(v_strValue, "%") > 0 Then
                                    v_strFilterTmpUpper &= "UPPER ('" _
                                                  & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "", "") & v_strValue _
                                                  & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "", "") & "')"

                                Else
                                    If v_strValue = String.Empty Then
                                        v_strFilterTmpUpper = Replace(v_strFilterTmpUpper, "=", "")
                                        v_strFilterTmpUpper &= " IS NULL "
                                    Else
                                        v_strFilterTmpUpper &= "UPPER ('" _
                                               & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & v_strValue _
                                               & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & "')"
                                    End If
                                End If
                                v_strFilterTmp = String.Empty
                                v_strFilterTmp = v_strFilterTmpUpper
                        End Select
                        lstCondition.Items.Add(v_strSearchKey, True)
                        hFilter.Add(v_strSearchKey, v_strFilterTmp)
                        hFilterStore.Add(v_strSearchKey, mv_arrSrFieldSrch(cboField.SelectedIndex + 1) & ":" & v_strValue)
                    End If
                End If
            End If
            Me.btnSearch.Select()
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub RemoveSearchCriteria()
        Try
            Dim v_objResult As Object

            If lstCondition.SelectedIndex <> -1 Then
                v_objResult = hFilter(lstCondition.Items(lstCondition.SelectedIndex).ToString())

                If Not (v_objResult Is Nothing) Then
                    hFilter.Remove(lstCondition.Items(lstCondition.SelectedIndex).ToString())
                    hFilterStore.Remove(lstCondition.Items(lstCondition.SelectedIndex).ToString())
                    lstCondition.Items.RemoveAt(lstCondition.SelectedIndex)
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub RemoveAllSearchCriterias()
        Try
            Dim v_objResult As Object
            Dim v_strValueDisplay As String

            For i As Integer = 0 To lstCondition.Items.Count - 1
                v_objResult = hFilter(lstCondition.Items(i).ToString())

                If Not (v_objResult Is Nothing) Then
                    v_strValueDisplay = lstCondition.Items(i).ToString()
                    hFilter.Remove(v_strValueDisplay)
                    hFilterStore.Remove(v_strValueDisplay)
                End If
            Next
            lstCondition.Items.Clear()
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        Dim v_intRow As Integer
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X"
                Next
            End If
        End If
    End Sub

    Private Sub mnuDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselectAll.Click
        Dim v_intRow As Integer
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                Next
            End If
        End If

    End Sub
    Protected Sub SetFocusGrid(ByVal Value As String)
        Try
            Dim v_blnItemFound As Boolean = False
            Dim v_intIndex As Int64, v_strText As String
            Dim v_intOldIndex As Integer = SearchGrid.DataRows.IndexOf(SearchGrid.CurrentRow)
            ' Dim KeyFieldValue As String = Replace(Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value), ".", String.Empty)
            If KeyColumn = "" Then
                Exit Sub
            Else
                For v_intIndex = +1 To SearchGrid.DataRows.Count - 1
                    If UCase(CType(SearchGrid.DataRows(v_intIndex), Xceed.Grid.DataRow).Cells(KeyColumn).Value) = UCase(Value) Then
                        SearchGrid.CurrentRow = SearchGrid.DataRows.Item(v_intIndex)
                        SearchGrid.SelectedRows.Clear()
                        SearchGrid.SelectedRows.Add(SearchGrid.CurrentRow)
                        For i As Integer = 0 To SearchGrid.DataRows.IndexOf(SearchGrid.CurrentRow) - v_intOldIndex - 1
                            SearchGrid.Scroll(Xceed.Grid.ScrollDirection.Down)
                        Next
                        v_blnItemFound = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub GetDataFromGrid(ByRef pv_strObjMsg As String, Optional ByVal pv_blnAll As Boolean = False, Optional ByRef countTick As Double = 0)
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_nodeList As Xml.XmlNodeList
            Dim v_nodeObjData As Xml.XmlElement
            Dim v_nodeEntry As Xml.XmlNode
            Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

            Dim v_int, v_intCount, v_intRow, v_intCol As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)

            For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1

                If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                    If Not pv_blnAll Then
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            'Có được đánh dấu chọn
                            v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                            For v_intCol = 0 To SearchGrid.DataRows(v_intRow).Cells.Count - 1
                                v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                                v_attrFLDNAME.Value = SearchGrid.Columns(v_intCol).FieldName
                                v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                                If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                    v_attrFLDTYPE.Value = "System.DateTime"
                                Else
                                    v_attrFLDTYPE.Value = SearchGrid.Columns(v_intCol).DataType.ToString
                                End If
                                v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                                'Add current value
                                v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                                v_attrOLDVAL.Value = ""
                                v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                                'Set value
                                v_nodeEntry.InnerText = SearchGrid.DataRows(v_intRow).Cells(v_intCol).Value

                                v_nodeObjData.AppendChild(v_nodeEntry)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                            countTick = countTick + 1
                        End If
                    Else
                        'Trong truong hop check all thi gui het.
                        v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                        For v_intCol = 0 To SearchGrid.DataRows(v_intRow).Cells.Count - 1
                            v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                            v_attrFLDNAME.Value = SearchGrid.Columns(v_intCol).FieldName
                            v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                            If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                v_attrFLDTYPE.Value = "System.DateTime"
                            Else
                                v_attrFLDTYPE.Value = SearchGrid.Columns(v_intCol).DataType.ToString
                            End If
                            v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                            'Add current value
                            v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                            v_attrOLDVAL.Value = ""
                            v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                            'Set value
                            v_nodeEntry.InnerText = SearchGrid.DataRows(v_intRow).Cells(v_intCol).Value

                            v_nodeObjData.AppendChild(v_nodeEntry)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                        countTick = SearchGrid.DataRows.Count
                    End If
                End If
            Next v_intRow

            pv_strObjMsg = v_xmlDocument.InnerXml

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Sub GetSMSDataFromGrid(ByRef pv_strObjMsg As String)
        Dim v_dt As DataTable
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_nodeList As Xml.XmlNodeList
            Dim v_nodeObjData As Xml.XmlElement
            Dim v_nodeEntry As Xml.XmlNode
            Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

            Dim v_int, v_intCount, v_intRow, v_intCol As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)

            For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1

                If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                    If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                        'Có được đánh dấu chọn
                        v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                        For v_intCol = 0 To SearchGrid.DataRows(v_intRow).Cells.Count - 1
                            If SearchGrid.Columns(v_intCol).FieldName = "TRADEPHONE" Or SearchGrid.Columns(v_intCol).FieldName = "SMSCONTENT" Then

                                v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                                v_attrFLDNAME.Value = SearchGrid.Columns(v_intCol).FieldName
                                v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                                If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                    v_attrFLDTYPE.Value = "System.DateTime"
                                Else
                                    v_attrFLDTYPE.Value = SearchGrid.Columns(v_intCol).DataType.ToString
                                End If



                                v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                                'Add current value
                                v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                                v_attrOLDVAL.Value = ""
                                v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                                'Set value
                                v_nodeEntry.InnerText = SearchGrid.DataRows(v_intRow).Cells(v_intCol).Value

                                v_nodeObjData.AppendChild(v_nodeEntry)
                            End If
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                    End If
                End If
            Next v_intRow

            pv_strObjMsg = v_xmlDocument.InnerXml

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub chkauto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkauto.CheckedChanged
        Me.isAutoSearch = True
    End Sub
#End Region

    Private Sub chkALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnBankINQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankINQ.Click
        OnBankInq()
    End Sub

End Class
