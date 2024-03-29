Imports Microsoft.Win32
Imports System.Threading
Imports System.Globalization
Imports Xceed.SmartUI.Controls.TreeView
Imports CommonLibrary
Imports AppCore
Imports updateclient
Imports System.Xml
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Configuration
Imports SocketServer
Imports System.Net.Sockets
Imports System.Text
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTab
Imports Xceed.SmartUI.Controls.ToolBar
Imports DevExpress.Data.Filtering
Imports System.Text.RegularExpressions


<Assembly: log4net.Config.XmlConfigurator(Watch:=True)> 

Public Class frmMDIMain
    Inherits DevExpress.XtraEditors.XtraForm


    Private threadNotify As Threading.Timer = New Threading.Timer(AddressOf InitNotify, Nothing, -1, -1)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()

        Xceed.SmartUI.Licenser.LicenseKey = "SUN35-LHF9Z-EN0Y4-6RTA"
        Xceed.Grid.Licenser.LicenseKey = "GRD38-NH0NZ-R858H-RYDA"

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents imlMenu As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Node1 As Xceed.SmartUI.Controls.TreeView.Node
    Private WithEvents stbMain As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents imlToolbar As System.Windows.Forms.ImageList
    Private WithEvents tbtTransaction As Xceed.SmartUI.Controls.ToolBar.TextBoxTool
    Private WithEvents SeparatorTool1 As Xceed.SmartUI.Controls.ToolBar.SeparatorTool
    Private WithEvents tbrLogin As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents Node2 As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents tmrCallCenter As System.Windows.Forms.Timer
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents DataTable5 As System.Data.DataTable
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiSystem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSystemLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSystemLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSystemShowHideFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSystemShowHideGroupFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiSystemChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiSystemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLanguageVietnamese As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLanguageEnglish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHelpUserManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents DataTable44 As System.Data.DataTable
    Friend WithEvents barManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barMainMenu As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents sbrPanelBranch As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents sbrPanelUser As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents sbrPanelStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents sbrPanelDateTime As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataTable78 As System.Data.DataTable
    Friend WithEvents DataTable10 As System.Data.DataTable
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataTable11 As System.Data.DataTable
    Friend WithEvents DataTable12 As System.Data.DataTable
    Friend WithEvents DataTable13 As System.Data.DataTable
    Friend WithEvents DataTable14 As System.Data.DataTable
    Friend WithEvents DataTable15 As System.Data.DataTable
    Friend WithEvents DataTable16 As System.Data.DataTable
    Friend WithEvents DataTable17 As System.Data.DataTable
    Friend WithEvents DataTable18 As System.Data.DataTable
    Friend WithEvents DataTable19 As System.Data.DataTable
    Friend WithEvents DataTable20 As System.Data.DataTable
    Friend WithEvents DataTable21 As System.Data.DataTable
    Friend WithEvents DataTable22 As System.Data.DataTable
    Friend WithEvents DataTable23 As System.Data.DataTable
    Friend WithEvents DataTable24 As System.Data.DataTable
    Friend WithEvents DataTable25 As System.Data.DataTable
    Friend WithEvents DataTable26 As System.Data.DataTable
    Friend WithEvents DataTable27 As System.Data.DataTable
    Friend WithEvents DataTable28 As System.Data.DataTable
    Friend WithEvents DataTable29 As System.Data.DataTable
    Friend WithEvents DataTable30 As System.Data.DataTable
    Friend WithEvents DataTable31 As System.Data.DataTable
    Friend WithEvents DataTable32 As System.Data.DataTable
    Friend WithEvents DataTable33 As System.Data.DataTable
    Friend WithEvents DataTable34 As System.Data.DataTable
    Friend WithEvents DataTable35 As System.Data.DataTable
    Friend WithEvents DataTable36 As System.Data.DataTable
    Friend WithEvents DataTable37 As System.Data.DataTable
    Friend WithEvents DataTable38 As System.Data.DataTable
    Friend WithEvents DataTable39 As System.Data.DataTable
    Friend WithEvents DataTable40 As System.Data.DataTable
    Friend WithEvents DataTable41 As System.Data.DataTable
    Friend WithEvents DataTable43 As System.Data.DataTable
    Friend WithEvents DataTable45 As System.Data.DataTable
    Friend WithEvents DataTable46 As System.Data.DataTable
    Friend WithEvents DataTable47 As System.Data.DataTable
    Friend WithEvents DataTable48 As System.Data.DataTable
    Friend WithEvents DataTable49 As System.Data.DataTable
    Friend WithEvents DataTable50 As System.Data.DataTable
    Friend WithEvents DataTable51 As System.Data.DataTable
    Friend WithEvents DataTable52 As System.Data.DataTable
    Friend WithEvents DataTable53 As System.Data.DataTable
    Friend WithEvents DataTable54 As System.Data.DataTable
    Friend WithEvents DataTable55 As System.Data.DataTable
    Friend WithEvents DataTable56 As System.Data.DataTable
    Friend WithEvents DataTable57 As System.Data.DataTable
    Friend WithEvents DataTable58 As System.Data.DataTable
    Friend WithEvents DataTable59 As System.Data.DataTable
    Friend WithEvents DataTable60 As System.Data.DataTable
    Friend WithEvents DataTable61 As System.Data.DataTable
    Friend WithEvents DataTable62 As System.Data.DataTable
    Friend WithEvents DataTable63 As System.Data.DataTable
    Friend WithEvents DataTable64 As System.Data.DataTable
    Friend WithEvents DataTable65 As System.Data.DataTable
    Friend WithEvents DataTable66 As System.Data.DataTable
    Friend WithEvents DataTable67 As System.Data.DataTable
    Friend WithEvents DataTable68 As System.Data.DataTable
    Friend WithEvents DataTable69 As System.Data.DataTable
    Friend WithEvents DataTable70 As System.Data.DataTable
    Friend WithEvents DataTable71 As System.Data.DataTable
    Friend WithEvents DataTable72 As System.Data.DataTable
    Friend WithEvents DataTable73 As System.Data.DataTable
    Friend WithEvents DataTable74 As System.Data.DataTable
    Friend WithEvents DataTable75 As System.Data.DataTable
    Friend WithEvents DataTable76 As System.Data.DataTable
    Friend WithEvents DataTable77 As System.Data.DataTable
    Friend WithEvents DataTable79 As System.Data.DataTable
    Friend WithEvents DataTable80 As System.Data.DataTable
    Friend WithEvents DataTable81 As System.Data.DataTable
    Friend WithEvents DataTable82 As System.Data.DataTable
    Friend WithEvents DataTable83 As System.Data.DataTable
    Friend WithEvents DataTable84 As System.Data.DataTable
    Friend WithEvents DataTable85 As System.Data.DataTable
    Friend WithEvents DataTable86 As System.Data.DataTable
    Friend WithEvents DataTable87 As System.Data.DataTable
    Friend WithEvents DataTable88 As System.Data.DataTable
    Friend WithEvents DataTable89 As System.Data.DataTable
    Friend WithEvents DataTable90 As System.Data.DataTable
    Friend WithEvents DataTable91 As System.Data.DataTable
    Friend WithEvents DataTable92 As System.Data.DataTable
    Friend WithEvents DataTable93 As System.Data.DataTable
    Friend WithEvents DataTable94 As System.Data.DataTable
    Friend WithEvents DataTable95 As System.Data.DataTable
    Friend WithEvents DataTable96 As System.Data.DataTable
    Friend WithEvents DataTable97 As System.Data.DataTable
    Friend WithEvents DataTable98 As System.Data.DataTable
    Friend WithEvents DataTable99 As System.Data.DataTable
    Friend WithEvents DataTable100 As System.Data.DataTable
    Friend WithEvents DataTable101 As System.Data.DataTable
    Friend WithEvents DataTable102 As System.Data.DataTable
    Friend WithEvents DataTable103 As System.Data.DataTable
    Friend WithEvents DataTable104 As System.Data.DataTable
    Friend WithEvents DataTable105 As System.Data.DataTable
    Friend WithEvents DataTable106 As System.Data.DataTable
    Friend WithEvents DataTable107 As System.Data.DataTable
    Friend WithEvents DataTable108 As System.Data.DataTable
    Friend WithEvents DataTable109 As System.Data.DataTable
    Friend WithEvents DataTable110 As System.Data.DataTable
    Friend WithEvents DataTable111 As System.Data.DataTable
    Friend WithEvents DataTable112 As System.Data.DataTable
    Friend WithEvents DataTable113 As System.Data.DataTable
    Friend WithEvents DataTable114 As System.Data.DataTable
    Friend WithEvents DataTable115 As System.Data.DataTable
    Friend WithEvents DataTable116 As System.Data.DataTable
    Friend WithEvents DataTable117 As System.Data.DataTable
    Friend WithEvents DataTable118 As System.Data.DataTable
    Friend WithEvents DataTable119 As System.Data.DataTable
    Friend WithEvents DataTable120 As System.Data.DataTable
    Friend WithEvents DataTable121 As System.Data.DataTable
    Friend WithEvents DataTable122 As System.Data.DataTable
    Friend WithEvents DataTable123 As System.Data.DataTable
    Friend WithEvents DataTable124 As System.Data.DataTable
    Friend WithEvents DataTable125 As System.Data.DataTable
    Friend WithEvents DataTable126 As System.Data.DataTable
    Friend WithEvents DataTable127 As System.Data.DataTable
    Friend WithEvents DataTable128 As System.Data.DataTable
    Friend WithEvents DataTable129 As System.Data.DataTable
    Friend WithEvents DataTable130 As System.Data.DataTable
    Friend WithEvents DataTable131 As System.Data.DataTable
    Friend WithEvents DataTable132 As System.Data.DataTable
    Friend WithEvents DataTable133 As System.Data.DataTable
    Friend WithEvents DataTable134 As System.Data.DataTable
    Friend WithEvents DataTable135 As System.Data.DataTable
    Friend WithEvents DataTable136 As System.Data.DataTable
    Friend WithEvents DataTable137 As System.Data.DataTable
    Friend WithEvents DataTable138 As System.Data.DataTable
    Friend WithEvents DataTable139 As System.Data.DataTable
    Friend WithEvents DataTable140 As System.Data.DataTable
    Friend WithEvents DataTable141 As System.Data.DataTable
    Friend WithEvents DataTable142 As System.Data.DataTable
    Friend WithEvents DataTable143 As System.Data.DataTable
    Friend WithEvents DataTable144 As System.Data.DataTable
    Friend WithEvents DataTable145 As System.Data.DataTable
    Friend WithEvents DataTable146 As System.Data.DataTable
    Friend WithEvents DataTable147 As System.Data.DataTable
    Friend WithEvents DataTable148 As System.Data.DataTable
    Friend WithEvents DataTable149 As System.Data.DataTable
    Friend WithEvents DataTable150 As System.Data.DataTable
    Friend WithEvents DataTable151 As System.Data.DataTable
    Friend WithEvents DataTable152 As System.Data.DataTable
    Friend WithEvents DataTable153 As System.Data.DataTable
    Friend WithEvents DataTable154 As System.Data.DataTable
    Friend WithEvents DataTable155 As System.Data.DataTable
    Friend WithEvents xtraTabControlModule As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents DataTable297 As System.Data.DataTable
    Friend WithEvents DataTable316 As System.Data.DataTable
    Friend WithEvents btnChooseFontSize As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DataTable157 As System.Data.DataTable
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnNotify As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnclose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuClose As DevExpress.XtraBars.PopupMenu
    Friend WithEvents DataTable195 As System.Data.DataTable
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btncloseother As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btncloseright As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btncloseall As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tmrAFK As Windows.Forms.Timer
    Private WithEvents tbrLogout As Xceed.SmartUI.Controls.ToolBar.Tool





    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDIMain))
        Me.tmrMain = New System.Windows.Forms.Timer()
        Me.imlMenu = New System.Windows.Forms.ImageList()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbMain = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar()
        Me.tbrLogin = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbrLogout = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.SeparatorTool1 = New Xceed.SmartUI.Controls.ToolBar.SeparatorTool()
        Me.tbtTransaction = New Xceed.SmartUI.Controls.ToolBar.TextBoxTool()
        Me.imlToolbar = New System.Windows.Forms.ImageList()
        Me.Node1 = New Xceed.SmartUI.Controls.TreeView.Node()
        Me.Node2 = New Xceed.SmartUI.Controls.TreeView.Node()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.tmrCallCenter = New System.Windows.Forms.Timer()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.tsmiSystem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSystemLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSystemLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSystemShowHideFunction = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSystemShowHideGroupFunction = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiSystemChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiSystemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLanguageVietnamese = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLanguageEnglish = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHelpUserManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable44 = New System.Data.DataTable()
        Me.barManager = New DevExpress.XtraBars.BarManager()
        Me.barMainMenu = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.sbrPanelBranch = New DevExpress.XtraBars.BarStaticItem()
        Me.sbrPanelUser = New DevExpress.XtraBars.BarStaticItem()
        Me.sbrPanelStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.sbrPanelDateTime = New DevExpress.XtraBars.BarStaticItem()
        Me.btnNotify = New DevExpress.XtraBars.BarSubItem()
        Me.btnChooseFontSize = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnclose = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.btncloseother = New DevExpress.XtraBars.BarButtonItem()
        Me.btncloseright = New DevExpress.XtraBars.BarButtonItem()
        Me.btncloseall = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.DataTable9 = New System.Data.DataTable()
        Me.DataTable78 = New System.Data.DataTable()
        Me.DataTable10 = New System.Data.DataTable()
        Me.DataTable11 = New System.Data.DataTable()
        Me.DataTable12 = New System.Data.DataTable()
        Me.DataTable13 = New System.Data.DataTable()
        Me.DataTable14 = New System.Data.DataTable()
        Me.DataTable15 = New System.Data.DataTable()
        Me.DataTable16 = New System.Data.DataTable()
        Me.DataTable17 = New System.Data.DataTable()
        Me.DataTable18 = New System.Data.DataTable()
        Me.DataTable19 = New System.Data.DataTable()
        Me.DataTable20 = New System.Data.DataTable()
        Me.DataTable21 = New System.Data.DataTable()
        Me.DataTable22 = New System.Data.DataTable()
        Me.DataTable23 = New System.Data.DataTable()
        Me.DataTable24 = New System.Data.DataTable()
        Me.DataTable25 = New System.Data.DataTable()
        Me.DataTable26 = New System.Data.DataTable()
        Me.DataTable27 = New System.Data.DataTable()
        Me.DataTable28 = New System.Data.DataTable()
        Me.DataTable29 = New System.Data.DataTable()
        Me.DataTable30 = New System.Data.DataTable()
        Me.DataTable31 = New System.Data.DataTable()
        Me.DataTable32 = New System.Data.DataTable()
        Me.DataTable33 = New System.Data.DataTable()
        Me.DataTable34 = New System.Data.DataTable()
        Me.DataTable35 = New System.Data.DataTable()
        Me.DataTable36 = New System.Data.DataTable()
        Me.DataTable37 = New System.Data.DataTable()
        Me.DataTable38 = New System.Data.DataTable()
        Me.DataTable39 = New System.Data.DataTable()
        Me.DataTable40 = New System.Data.DataTable()
        Me.DataTable41 = New System.Data.DataTable()
        Me.DataTable43 = New System.Data.DataTable()
        Me.DataTable45 = New System.Data.DataTable()
        Me.DataTable46 = New System.Data.DataTable()
        Me.DataTable47 = New System.Data.DataTable()
        Me.DataTable48 = New System.Data.DataTable()
        Me.DataTable49 = New System.Data.DataTable()
        Me.DataTable50 = New System.Data.DataTable()
        Me.DataTable51 = New System.Data.DataTable()
        Me.DataTable52 = New System.Data.DataTable()
        Me.DataTable53 = New System.Data.DataTable()
        Me.DataTable54 = New System.Data.DataTable()
        Me.DataTable55 = New System.Data.DataTable()
        Me.DataTable56 = New System.Data.DataTable()
        Me.DataTable57 = New System.Data.DataTable()
        Me.DataTable58 = New System.Data.DataTable()
        Me.DataTable59 = New System.Data.DataTable()
        Me.DataTable60 = New System.Data.DataTable()
        Me.DataTable61 = New System.Data.DataTable()
        Me.DataTable62 = New System.Data.DataTable()
        Me.DataTable63 = New System.Data.DataTable()
        Me.DataTable64 = New System.Data.DataTable()
        Me.DataTable65 = New System.Data.DataTable()
        Me.DataTable66 = New System.Data.DataTable()
        Me.DataTable67 = New System.Data.DataTable()
        Me.DataTable68 = New System.Data.DataTable()
        Me.DataTable69 = New System.Data.DataTable()
        Me.DataTable70 = New System.Data.DataTable()
        Me.DataTable71 = New System.Data.DataTable()
        Me.DataTable72 = New System.Data.DataTable()
        Me.DataTable73 = New System.Data.DataTable()
        Me.DataTable74 = New System.Data.DataTable()
        Me.DataTable75 = New System.Data.DataTable()
        Me.DataTable76 = New System.Data.DataTable()
        Me.DataTable77 = New System.Data.DataTable()
        Me.DataTable79 = New System.Data.DataTable()
        Me.DataTable80 = New System.Data.DataTable()
        Me.DataTable81 = New System.Data.DataTable()
        Me.DataTable82 = New System.Data.DataTable()
        Me.DataTable83 = New System.Data.DataTable()
        Me.DataTable84 = New System.Data.DataTable()
        Me.DataTable85 = New System.Data.DataTable()
        Me.DataTable86 = New System.Data.DataTable()
        Me.DataTable87 = New System.Data.DataTable()
        Me.DataTable88 = New System.Data.DataTable()
        Me.DataTable89 = New System.Data.DataTable()
        Me.DataTable90 = New System.Data.DataTable()
        Me.DataTable91 = New System.Data.DataTable()
        Me.DataTable92 = New System.Data.DataTable()
        Me.DataTable93 = New System.Data.DataTable()
        Me.DataTable94 = New System.Data.DataTable()
        Me.DataTable95 = New System.Data.DataTable()
        Me.DataTable96 = New System.Data.DataTable()
        Me.DataTable97 = New System.Data.DataTable()
        Me.DataTable98 = New System.Data.DataTable()
        Me.DataTable99 = New System.Data.DataTable()
        Me.DataTable100 = New System.Data.DataTable()
        Me.DataTable101 = New System.Data.DataTable()
        Me.DataTable102 = New System.Data.DataTable()
        Me.DataTable103 = New System.Data.DataTable()
        Me.DataTable104 = New System.Data.DataTable()
        Me.DataTable105 = New System.Data.DataTable()
        Me.DataTable106 = New System.Data.DataTable()
        Me.DataTable107 = New System.Data.DataTable()
        Me.DataTable108 = New System.Data.DataTable()
        Me.DataTable109 = New System.Data.DataTable()
        Me.DataTable110 = New System.Data.DataTable()
        Me.DataTable111 = New System.Data.DataTable()
        Me.DataTable112 = New System.Data.DataTable()
        Me.DataTable113 = New System.Data.DataTable()
        Me.DataTable114 = New System.Data.DataTable()
        Me.DataTable115 = New System.Data.DataTable()
        Me.DataTable116 = New System.Data.DataTable()
        Me.DataTable117 = New System.Data.DataTable()
        Me.DataTable118 = New System.Data.DataTable()
        Me.DataTable119 = New System.Data.DataTable()
        Me.DataTable120 = New System.Data.DataTable()
        Me.DataTable121 = New System.Data.DataTable()
        Me.DataTable122 = New System.Data.DataTable()
        Me.DataTable123 = New System.Data.DataTable()
        Me.DataTable124 = New System.Data.DataTable()
        Me.DataTable125 = New System.Data.DataTable()
        Me.DataTable126 = New System.Data.DataTable()
        Me.DataTable127 = New System.Data.DataTable()
        Me.DataTable128 = New System.Data.DataTable()
        Me.DataTable129 = New System.Data.DataTable()
        Me.DataTable130 = New System.Data.DataTable()
        Me.DataTable131 = New System.Data.DataTable()
        Me.DataTable132 = New System.Data.DataTable()
        Me.DataTable133 = New System.Data.DataTable()
        Me.DataTable134 = New System.Data.DataTable()
        Me.DataTable135 = New System.Data.DataTable()
        Me.DataTable136 = New System.Data.DataTable()
        Me.DataTable137 = New System.Data.DataTable()
        Me.DataTable138 = New System.Data.DataTable()
        Me.DataTable139 = New System.Data.DataTable()
        Me.DataTable140 = New System.Data.DataTable()
        Me.DataTable141 = New System.Data.DataTable()
        Me.DataTable142 = New System.Data.DataTable()
        Me.DataTable143 = New System.Data.DataTable()
        Me.DataTable144 = New System.Data.DataTable()
        Me.DataTable145 = New System.Data.DataTable()
        Me.DataTable146 = New System.Data.DataTable()
        Me.DataTable147 = New System.Data.DataTable()
        Me.DataTable148 = New System.Data.DataTable()
        Me.DataTable149 = New System.Data.DataTable()
        Me.DataTable150 = New System.Data.DataTable()
        Me.DataTable151 = New System.Data.DataTable()
        Me.DataTable152 = New System.Data.DataTable()
        Me.DataTable153 = New System.Data.DataTable()
        Me.DataTable154 = New System.Data.DataTable()
        Me.DataTable155 = New System.Data.DataTable()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.xtraTabControlModule = New DevExpress.XtraTab.XtraTabControl()
        Me.DataTable297 = New System.Data.DataTable()
        Me.DataTable316 = New System.Data.DataTable()
        Me.DataTable157 = New System.Data.DataTable()
        Me.PopupMenuClose = New DevExpress.XtraBars.PopupMenu()
        Me.DataTable195 = New System.Data.DataTable()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tmrAFK = New System.Windows.Forms.Timer()
        CType(Me.stbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable85, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable86, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable87, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable88, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable89, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable90, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable91, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable93, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable94, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable95, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable96, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable97, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable98, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable99, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable101, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable102, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable103, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable104, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable105, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable107, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable108, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable109, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable113, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable114, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable115, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable116, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable117, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable118, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable119, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable120, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable121, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable122, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable123, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable124, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable125, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable126, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable127, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable129, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable131, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable132, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable133, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable134, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable135, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable137, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable138, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable139, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable140, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable141, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable142, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable143, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable144, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable145, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable146, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable147, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable148, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable149, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable150, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable151, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable152, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable153, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable154, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable155, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.xtraTabControlModule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable297, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable316, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable157, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable195, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 1000
        '
        'imlMenu
        '
        Me.imlMenu.ImageStream = CType(resources.GetObject("imlMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMenu.Images.SetKeyName(0, "")
        Me.imlMenu.Images.SetKeyName(1, "")
        Me.imlMenu.Images.SetKeyName(2, "")
        Me.imlMenu.Images.SetKeyName(3, "")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 16)
        Me.Label1.TabIndex = 0
        '
        'stbMain
        '
        Me.stbMain.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tbrLogin, Me.tbrLogout, Me.SeparatorTool1, Me.tbtTransaction})
        Me.stbMain.ItemsImageList = Me.imlToolbar
        Me.stbMain.Location = New System.Drawing.Point(0, 20)
        Me.stbMain.Name = "stbMain"
        Me.stbMain.Size = New System.Drawing.Size(1072, 30)
        Me.stbMain.TabIndex = 17
        Me.stbMain.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.OfficeXP
        '
        'tbrLogin
        '
        Me.tbrLogin.Image = CType(resources.GetObject("tbrLogin.Image"), System.Drawing.Image)
        Me.tbrLogin.Name = "tbrLogin"
        Me.tbrLogin.ShowShortcut = False
        Me.tbrLogin.Tag = "tbrLogin"
        '
        'tbrLogout
        '
        Me.tbrLogout.Name = "tbrLogout"
        Me.tbrLogout.Tag = "tbrLogout"
        '
        'SeparatorTool1
        '
        Me.SeparatorTool1.Name = "SeparatorTool1"
        Me.SeparatorTool1.Tag = Nothing
        '
        'tbtTransaction
        '
        Me.tbtTransaction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbtTransaction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tbtTransaction.Name = "tbtTransaction"
        Me.tbtTransaction.Tag = "tbtTransaction"
        Me.tbtTransaction.Text = "Mã giao dịch:"
        '
        'imlToolbar
        '
        Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolbar.TransparentColor = System.Drawing.Color.Transparent
        '
        'Node1
        '
        Me.Node1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Node1.ImageIndex = 2
        Me.Node1.Name = "Node1"
        Me.Node1.Tag = Nothing
        Me.Node1.Text = "VSTP"
        Me.Node1.ToolTipText = "VSTP"
        '
        'Node2
        '
        Me.Node2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Node2.ImageIndex = 2
        Me.Node2.Name = "Node2"
        Me.Node2.Tag = "000000"
        Me.Node2.Text = "CustomizeMenu"
        Me.Node2.ToolTipText = "CustomizeMenu"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'tmrCallCenter
        '
        Me.tmrCallCenter.Interval = 5000
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'DataTable4
        '
        Me.DataTable4.Namespace = ""
        Me.DataTable4.TableName = "COMBOBOX"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'DataTable5
        '
        Me.DataTable5.Namespace = ""
        Me.DataTable5.TableName = "COMBOBOX"
        '
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'msMain
        '
        Me.msMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.msMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.msMain.Location = New System.Drawing.Point(0, 29)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(1715, 34)
        Me.msMain.TabIndex = 23
        Me.msMain.Text = "MenuStrip1"
        Me.msMain.Visible = False
        '
        'tsmiSystem
        '
        Me.tsmiSystem.Name = "tsmiSystem"
        Me.tsmiSystem.Size = New System.Drawing.Size(69, 20)
        Me.tsmiSystem.Text = "&Hệ thống"
        '
        'tsmiSystemLogin
        '
        Me.tsmiSystemLogin.Name = "tsmiSystemLogin"
        Me.tsmiSystemLogin.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemLogin.Text = "Vào chương trình"
        '
        'tsmiSystemLogout
        '
        Me.tsmiSystemLogout.Name = "tsmiSystemLogout"
        Me.tsmiSystemLogout.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemLogout.Text = "Ra khỏi chương trình"
        '
        'tsmiSystemShowHideFunction
        '
        Me.tsmiSystemShowHideFunction.Name = "tsmiSystemShowHideFunction"
        Me.tsmiSystemShowHideFunction.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemShowHideFunction.Text = "Ẩn/hiện chức năng hệ thống"
        '
        'tsmiSystemShowHideGroupFunction
        '
        Me.tsmiSystemShowHideGroupFunction.Name = "tsmiSystemShowHideGroupFunction"
        Me.tsmiSystemShowHideGroupFunction.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemShowHideGroupFunction.Text = "Ẩn/hiện chức năng nhóm"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
        '
        'tsmiSystemChangePassword
        '
        Me.tsmiSystemChangePassword.Name = "tsmiSystemChangePassword"
        Me.tsmiSystemChangePassword.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemChangePassword.Text = "Đổi mật khẩu..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(224, 6)
        '
        'tsmiSystemExit
        '
        Me.tsmiSystemExit.Name = "tsmiSystemExit"
        Me.tsmiSystemExit.Size = New System.Drawing.Size(227, 22)
        Me.tsmiSystemExit.Text = "Thoát chương trình"
        '
        'tsmiLanguage
        '
        Me.tsmiLanguage.Name = "tsmiLanguage"
        Me.tsmiLanguage.Size = New System.Drawing.Size(73, 20)
        Me.tsmiLanguage.Text = "&Ngôn ngữ"
        '
        'tsmiLanguageVietnamese
        '
        Me.tsmiLanguageVietnamese.Name = "tsmiLanguageVietnamese"
        Me.tsmiLanguageVietnamese.Size = New System.Drawing.Size(227, 22)
        Me.tsmiLanguageVietnamese.Text = "Tiếng Việt"
        '
        'tsmiLanguageEnglish
        '
        Me.tsmiLanguageEnglish.Name = "tsmiLanguageEnglish"
        Me.tsmiLanguageEnglish.Size = New System.Drawing.Size(152, 22)
        Me.tsmiLanguageEnglish.Text = "English"
        '
        'tsmiHelp
        '
        Me.tsmiHelp.Name = "tsmiHelp"
        Me.tsmiHelp.Size = New System.Drawing.Size(64, 20)
        Me.tsmiHelp.Text = "&Trợ giúp"
        '
        'tsmiHelpUserManual
        '
        Me.tsmiHelpUserManual.Name = "tsmiHelpUserManual"
        Me.tsmiHelpUserManual.Size = New System.Drawing.Size(198, 22)
        Me.tsmiHelpUserManual.Text = "Hướng dẫn sử dụng"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(195, 6)
        '
        'tsmiHelpAbout
        '
        Me.tsmiHelpAbout.Name = "tsmiHelpAbout"
        Me.tsmiHelpAbout.Size = New System.Drawing.Size(198, 22)
        Me.tsmiHelpAbout.Text = "Thông tin chương trình"
        '
        'DataTable6
        '
        Me.DataTable6.Namespace = ""
        Me.DataTable6.TableName = "COMBOBOX"
        '
        'DataTable44
        '
        Me.DataTable44.Namespace = ""
        Me.DataTable44.TableName = "COMBOBOX"
        '
        'barManager
        '
        Me.barManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barMainMenu, Me.Bar3})
        Me.barManager.DockControls.Add(Me.barDockControlTop)
        Me.barManager.DockControls.Add(Me.barDockControlBottom)
        Me.barManager.DockControls.Add(Me.barDockControlLeft)
        Me.barManager.DockControls.Add(Me.barDockControlRight)
        Me.barManager.Form = Me
        Me.barManager.Images = Me.ImageCollection1
        Me.barManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.sbrPanelBranch, Me.sbrPanelUser, Me.sbrPanelStatus, Me.sbrPanelDateTime, Me.BarStaticItem1, Me.BarSubItem1, Me.BarButtonItem1, Me.BarButtonItem2, Me.btnChooseFontSize, Me.BarButtonItem3, Me.btnNotify, Me.btnclose, Me.BarButtonItem5, Me.btncloseother, Me.btncloseright, Me.btncloseall})
        Me.barManager.MainMenu = Me.barMainMenu
        Me.barManager.MaxItemId = 18
        Me.barManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit1})
        Me.barManager.StatusBar = Me.Bar3
        '
        'barMainMenu
        '
        Me.barMainMenu.BarName = "Main menu"
        Me.barMainMenu.DockCol = 0
        Me.barMainMenu.DockRow = 0
        Me.barMainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barMainMenu.OptionsBar.AllowQuickCustomization = False
        Me.barMainMenu.OptionsBar.DrawBorder = False
        Me.barMainMenu.OptionsBar.DrawDragBorder = False
        Me.barMainMenu.OptionsBar.UseWholeRow = True
        Me.barMainMenu.Text = "Main menu"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.sbrPanelBranch), New DevExpress.XtraBars.LinkPersistInfo(Me.sbrPanelUser), New DevExpress.XtraBars.LinkPersistInfo(Me.sbrPanelStatus), New DevExpress.XtraBars.LinkPersistInfo(Me.sbrPanelDateTime), New DevExpress.XtraBars.LinkPersistInfo(Me.btnNotify), New DevExpress.XtraBars.LinkPersistInfo(Me.btnChooseFontSize), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.Caption Or DevExpress.XtraBars.BarLinkUserDefines.PaintStyle), DevExpress.XtraBars.BarLinkUserDefines), Me.BarButtonItem1, "Notify works status", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.Standard)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DisableCustomization = True
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'sbrPanelBranch
        '
        Me.sbrPanelBranch.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.sbrPanelBranch.Caption = "Chi nhánh"
        Me.sbrPanelBranch.Glyph = CType(resources.GetObject("sbrPanelBranch.Glyph"), System.Drawing.Image)
        Me.sbrPanelBranch.Id = 0
        Me.sbrPanelBranch.LargeGlyph = CType(resources.GetObject("sbrPanelBranch.LargeGlyph"), System.Drawing.Image)
        Me.sbrPanelBranch.Name = "sbrPanelBranch"
        Me.sbrPanelBranch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.sbrPanelBranch.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbrPanelBranch.Width = 32
        '
        'sbrPanelUser
        '
        Me.sbrPanelUser.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.sbrPanelUser.Glyph = CType(resources.GetObject("sbrPanelUser.Glyph"), System.Drawing.Image)
        Me.sbrPanelUser.Id = 1
        Me.sbrPanelUser.LargeGlyph = CType(resources.GetObject("sbrPanelUser.LargeGlyph"), System.Drawing.Image)
        Me.sbrPanelUser.Name = "sbrPanelUser"
        Me.sbrPanelUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.sbrPanelUser.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbrPanelUser.Width = 32
        '
        'sbrPanelStatus
        '
        Me.sbrPanelStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.sbrPanelStatus.Glyph = CType(resources.GetObject("sbrPanelStatus.Glyph"), System.Drawing.Image)
        Me.sbrPanelStatus.Id = 2
        Me.sbrPanelStatus.LargeGlyph = CType(resources.GetObject("sbrPanelStatus.LargeGlyph"), System.Drawing.Image)
        Me.sbrPanelStatus.Name = "sbrPanelStatus"
        Me.sbrPanelStatus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.sbrPanelStatus.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbrPanelStatus.Width = 32
        '
        'sbrPanelDateTime
        '
        Me.sbrPanelDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.sbrPanelDateTime.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.sbrPanelDateTime.Glyph = CType(resources.GetObject("sbrPanelDateTime.Glyph"), System.Drawing.Image)
        Me.sbrPanelDateTime.Id = 3
        Me.sbrPanelDateTime.LargeGlyph = CType(resources.GetObject("sbrPanelDateTime.LargeGlyph"), System.Drawing.Image)
        Me.sbrPanelDateTime.Name = "sbrPanelDateTime"
        Me.sbrPanelDateTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.sbrPanelDateTime.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbrPanelDateTime.Width = 32
        '
        'btnNotify
        '
        Me.btnNotify.Glyph = CType(resources.GetObject("btnNotify.Glyph"), System.Drawing.Image)
        Me.btnNotify.Id = 12
        Me.btnNotify.LargeGlyph = CType(resources.GetObject("btnNotify.LargeGlyph"), System.Drawing.Image)
        Me.btnNotify.Name = "btnNotify"
        Me.btnNotify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnChooseFontSize
        '
        Me.btnChooseFontSize.Glyph = CType(resources.GetObject("btnChooseFontSize.Glyph"), System.Drawing.Image)
        Me.btnChooseFontSize.Id = 10
        Me.btnChooseFontSize.LargeGlyph = CType(resources.GetObject("btnChooseFontSize.LargeGlyph"), System.Drawing.Image)
        Me.btnChooseFontSize.Name = "btnChooseFontSize"
        Me.btnChooseFontSize.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 7
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1072, 20)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 483)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1072, 59)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 20)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 463)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1072, 20)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 463)
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.InsertGalleryImage("copy_16x16.png", "images/edit/copy_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/copy_16x16.png"), 0)
        Me.ImageCollection1.Images.SetKeyName(0, "copy_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("customization_16x16.png", "images/edit/customization_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/customization_16x16.png"), 1)
        Me.ImageCollection1.Images.SetKeyName(1, "customization_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cut_16x16.png", "images/edit/cut_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/cut_16x16.png"), 2)
        Me.ImageCollection1.Images.SetKeyName(2, "cut_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("redo_16x16.png", "images/history/redo_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/history/redo_16x16.png"), 3)
        Me.ImageCollection1.Images.SetKeyName(3, "redo_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("example_16x16.png", "images/support/example_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/example_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "example_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("merge_16x16.png", "images/actions/merge_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/merge_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "merge_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("edit_16x16.png", "images/edit/edit_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "edit_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("paste_16x16.png", "images/edit/paste_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "paste_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("home_16x16.png", "images/navigation/home_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "home_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("breakingchange_16x16.png", "images/support/breakingchange_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/breakingchange_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "breakingchange_16x16.png")
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "BarStaticItem1"
        Me.BarStaticItem1.Id = 5
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "BarSubItem1"
        Me.BarSubItem1.Id = 6
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 8
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "BarButtonItem3"
        Me.BarButtonItem3.Id = 11
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'btnclose
        '
        Me.btnclose.Caption = "Close"
        Me.btnclose.Id = 13
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Tag = "tabclose"
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "BarButtonItem5"
        Me.BarButtonItem5.Id = 14
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'btncloseother
        '
        Me.btncloseother.Caption = "Close other tab"
        Me.btncloseother.Id = 15
        Me.btncloseother.Name = "btncloseother"
        Me.btncloseother.Tag = "tabcloseother"
        '
        'btncloseright
        '
        Me.btncloseright.Caption = "Close tab to the right"
        Me.btncloseright.Id = 16
        Me.btncloseright.Name = "btncloseright"
        Me.btncloseright.Tag = "tabcloseright"
        '
        'btncloseall
        '
        Me.btncloseall.Caption = "Close all tab"
        Me.btncloseall.Id = 17
        Me.btncloseall.Name = "btncloseall"
        Me.btncloseall.Tag = "closeall"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        '
        'DataTable9
        '
        Me.DataTable9.Namespace = ""
        Me.DataTable9.TableName = "COMBOBOX"
        '
        'DataTable78
        '
        Me.DataTable78.Namespace = ""
        Me.DataTable78.TableName = "COMBOBOX"
        '
        'DataTable10
        '
        Me.DataTable10.Namespace = ""
        Me.DataTable10.TableName = "COMBOBOX"
        '
        'DataTable11
        '
        Me.DataTable11.Namespace = ""
        Me.DataTable11.TableName = "COMBOBOX"
        '
        'DataTable12
        '
        Me.DataTable12.Namespace = ""
        Me.DataTable12.TableName = "COMBOBOX"
        '
        'DataTable13
        '
        Me.DataTable13.Namespace = ""
        Me.DataTable13.TableName = "COMBOBOX"
        '
        'DataTable14
        '
        Me.DataTable14.Namespace = ""
        Me.DataTable14.TableName = "COMBOBOX"
        '
        'DataTable15
        '
        Me.DataTable15.Namespace = ""
        Me.DataTable15.TableName = "COMBOBOX"
        '
        'DataTable16
        '
        Me.DataTable16.Namespace = ""
        Me.DataTable16.TableName = "COMBOBOX"
        '
        'DataTable17
        '
        Me.DataTable17.Namespace = ""
        Me.DataTable17.TableName = "COMBOBOX"
        '
        'DataTable18
        '
        Me.DataTable18.Namespace = ""
        Me.DataTable18.TableName = "COMBOBOX"
        '
        'DataTable19
        '
        Me.DataTable19.Namespace = ""
        Me.DataTable19.TableName = "COMBOBOX"
        '
        'DataTable20
        '
        Me.DataTable20.Namespace = ""
        Me.DataTable20.TableName = "COMBOBOX"
        '
        'DataTable21
        '
        Me.DataTable21.Namespace = ""
        Me.DataTable21.TableName = "COMBOBOX"
        '
        'DataTable22
        '
        Me.DataTable22.Namespace = ""
        Me.DataTable22.TableName = "COMBOBOX"
        '
        'DataTable23
        '
        Me.DataTable23.Namespace = ""
        Me.DataTable23.TableName = "COMBOBOX"
        '
        'DataTable24
        '
        Me.DataTable24.Namespace = ""
        Me.DataTable24.TableName = "COMBOBOX"
        '
        'DataTable25
        '
        Me.DataTable25.Namespace = ""
        Me.DataTable25.TableName = "COMBOBOX"
        '
        'DataTable26
        '
        Me.DataTable26.Namespace = ""
        Me.DataTable26.TableName = "COMBOBOX"
        '
        'DataTable27
        '
        Me.DataTable27.Namespace = ""
        Me.DataTable27.TableName = "COMBOBOX"
        '
        'DataTable28
        '
        Me.DataTable28.Namespace = ""
        Me.DataTable28.TableName = "COMBOBOX"
        '
        'DataTable29
        '
        Me.DataTable29.Namespace = ""
        Me.DataTable29.TableName = "COMBOBOX"
        '
        'DataTable30
        '
        Me.DataTable30.Namespace = ""
        Me.DataTable30.TableName = "COMBOBOX"
        '
        'DataTable31
        '
        Me.DataTable31.Namespace = ""
        Me.DataTable31.TableName = "COMBOBOX"
        '
        'DataTable32
        '
        Me.DataTable32.Namespace = ""
        Me.DataTable32.TableName = "COMBOBOX"
        '
        'DataTable33
        '
        Me.DataTable33.Namespace = ""
        Me.DataTable33.TableName = "COMBOBOX"
        '
        'DataTable34
        '
        Me.DataTable34.Namespace = ""
        Me.DataTable34.TableName = "COMBOBOX"
        '
        'DataTable35
        '
        Me.DataTable35.Namespace = ""
        Me.DataTable35.TableName = "COMBOBOX"
        '
        'DataTable36
        '
        Me.DataTable36.Namespace = ""
        Me.DataTable36.TableName = "COMBOBOX"
        '
        'DataTable37
        '
        Me.DataTable37.Namespace = ""
        Me.DataTable37.TableName = "COMBOBOX"
        '
        'DataTable38
        '
        Me.DataTable38.Namespace = ""
        Me.DataTable38.TableName = "COMBOBOX"
        '
        'DataTable39
        '
        Me.DataTable39.Namespace = ""
        Me.DataTable39.TableName = "COMBOBOX"
        '
        'DataTable40
        '
        Me.DataTable40.Namespace = ""
        Me.DataTable40.TableName = "COMBOBOX"
        '
        'DataTable41
        '
        Me.DataTable41.Namespace = ""
        Me.DataTable41.TableName = "COMBOBOX"
        '
        'DataTable43
        '
        Me.DataTable43.Namespace = ""
        Me.DataTable43.TableName = "COMBOBOX"
        '
        'DataTable45
        '
        Me.DataTable45.Namespace = ""
        Me.DataTable45.TableName = "COMBOBOX"
        '
        'DataTable46
        '
        Me.DataTable46.Namespace = ""
        Me.DataTable46.TableName = "COMBOBOX"
        '
        'DataTable47
        '
        Me.DataTable47.Namespace = ""
        Me.DataTable47.TableName = "COMBOBOX"
        '
        'DataTable48
        '
        Me.DataTable48.Namespace = ""
        Me.DataTable48.TableName = "COMBOBOX"
        '
        'DataTable49
        '
        Me.DataTable49.Namespace = ""
        Me.DataTable49.TableName = "COMBOBOX"
        '
        'DataTable50
        '
        Me.DataTable50.Namespace = ""
        Me.DataTable50.TableName = "COMBOBOX"
        '
        'DataTable51
        '
        Me.DataTable51.Namespace = ""
        Me.DataTable51.TableName = "COMBOBOX"
        '
        'DataTable52
        '
        Me.DataTable52.Namespace = ""
        Me.DataTable52.TableName = "COMBOBOX"
        '
        'DataTable53
        '
        Me.DataTable53.Namespace = ""
        Me.DataTable53.TableName = "COMBOBOX"
        '
        'DataTable54
        '
        Me.DataTable54.Namespace = ""
        Me.DataTable54.TableName = "COMBOBOX"
        '
        'DataTable55
        '
        Me.DataTable55.Namespace = ""
        Me.DataTable55.TableName = "COMBOBOX"
        '
        'DataTable56
        '
        Me.DataTable56.Namespace = ""
        Me.DataTable56.TableName = "COMBOBOX"
        '
        'DataTable57
        '
        Me.DataTable57.Namespace = ""
        Me.DataTable57.TableName = "COMBOBOX"
        '
        'DataTable58
        '
        Me.DataTable58.Namespace = ""
        Me.DataTable58.TableName = "COMBOBOX"
        '
        'DataTable59
        '
        Me.DataTable59.Namespace = ""
        Me.DataTable59.TableName = "COMBOBOX"
        '
        'DataTable60
        '
        Me.DataTable60.Namespace = ""
        Me.DataTable60.TableName = "COMBOBOX"
        '
        'DataTable61
        '
        Me.DataTable61.Namespace = ""
        Me.DataTable61.TableName = "COMBOBOX"
        '
        'DataTable62
        '
        Me.DataTable62.Namespace = ""
        Me.DataTable62.TableName = "COMBOBOX"
        '
        'DataTable63
        '
        Me.DataTable63.Namespace = ""
        Me.DataTable63.TableName = "COMBOBOX"
        '
        'DataTable64
        '
        Me.DataTable64.Namespace = ""
        Me.DataTable64.TableName = "COMBOBOX"
        '
        'DataTable65
        '
        Me.DataTable65.Namespace = ""
        Me.DataTable65.TableName = "COMBOBOX"
        '
        'DataTable66
        '
        Me.DataTable66.Namespace = ""
        Me.DataTable66.TableName = "COMBOBOX"
        '
        'DataTable67
        '
        Me.DataTable67.Namespace = ""
        Me.DataTable67.TableName = "COMBOBOX"
        '
        'DataTable68
        '
        Me.DataTable68.Namespace = ""
        Me.DataTable68.TableName = "COMBOBOX"
        '
        'DataTable69
        '
        Me.DataTable69.Namespace = ""
        Me.DataTable69.TableName = "COMBOBOX"
        '
        'DataTable70
        '
        Me.DataTable70.Namespace = ""
        Me.DataTable70.TableName = "COMBOBOX"
        '
        'DataTable71
        '
        Me.DataTable71.Namespace = ""
        Me.DataTable71.TableName = "COMBOBOX"
        '
        'DataTable72
        '
        Me.DataTable72.Namespace = ""
        Me.DataTable72.TableName = "COMBOBOX"
        '
        'DataTable73
        '
        Me.DataTable73.Namespace = ""
        Me.DataTable73.TableName = "COMBOBOX"
        '
        'DataTable74
        '
        Me.DataTable74.Namespace = ""
        Me.DataTable74.TableName = "COMBOBOX"
        '
        'DataTable75
        '
        Me.DataTable75.Namespace = ""
        Me.DataTable75.TableName = "COMBOBOX"
        '
        'DataTable76
        '
        Me.DataTable76.Namespace = ""
        Me.DataTable76.TableName = "COMBOBOX"
        '
        'DataTable77
        '
        Me.DataTable77.Namespace = ""
        Me.DataTable77.TableName = "COMBOBOX"
        '
        'DataTable79
        '
        Me.DataTable79.Namespace = ""
        Me.DataTable79.TableName = "COMBOBOX"
        '
        'DataTable80
        '
        Me.DataTable80.Namespace = ""
        Me.DataTable80.TableName = "COMBOBOX"
        '
        'DataTable81
        '
        Me.DataTable81.Namespace = ""
        Me.DataTable81.TableName = "COMBOBOX"
        '
        'DataTable82
        '
        Me.DataTable82.Namespace = ""
        Me.DataTable82.TableName = "COMBOBOX"
        '
        'DataTable83
        '
        Me.DataTable83.Namespace = ""
        Me.DataTable83.TableName = "COMBOBOX"
        '
        'DataTable84
        '
        Me.DataTable84.Namespace = ""
        Me.DataTable84.TableName = "COMBOBOX"
        '
        'DataTable85
        '
        Me.DataTable85.Namespace = ""
        Me.DataTable85.TableName = "COMBOBOX"
        '
        'DataTable86
        '
        Me.DataTable86.Namespace = ""
        Me.DataTable86.TableName = "COMBOBOX"
        '
        'DataTable87
        '
        Me.DataTable87.Namespace = ""
        Me.DataTable87.TableName = "COMBOBOX"
        '
        'DataTable88
        '
        Me.DataTable88.Namespace = ""
        Me.DataTable88.TableName = "COMBOBOX"
        '
        'DataTable89
        '
        Me.DataTable89.Namespace = ""
        Me.DataTable89.TableName = "COMBOBOX"
        '
        'DataTable90
        '
        Me.DataTable90.Namespace = ""
        Me.DataTable90.TableName = "COMBOBOX"
        '
        'DataTable91
        '
        Me.DataTable91.Namespace = ""
        Me.DataTable91.TableName = "COMBOBOX"
        '
        'DataTable92
        '
        Me.DataTable92.Namespace = ""
        Me.DataTable92.TableName = "COMBOBOX"
        '
        'DataTable93
        '
        Me.DataTable93.Namespace = ""
        Me.DataTable93.TableName = "COMBOBOX"
        '
        'DataTable94
        '
        Me.DataTable94.Namespace = ""
        Me.DataTable94.TableName = "COMBOBOX"
        '
        'DataTable95
        '
        Me.DataTable95.Namespace = ""
        Me.DataTable95.TableName = "COMBOBOX"
        '
        'DataTable96
        '
        Me.DataTable96.Namespace = ""
        Me.DataTable96.TableName = "COMBOBOX"
        '
        'DataTable97
        '
        Me.DataTable97.Namespace = ""
        Me.DataTable97.TableName = "COMBOBOX"
        '
        'DataTable98
        '
        Me.DataTable98.Namespace = ""
        Me.DataTable98.TableName = "COMBOBOX"
        '
        'DataTable99
        '
        Me.DataTable99.Namespace = ""
        Me.DataTable99.TableName = "COMBOBOX"
        '
        'DataTable100
        '
        Me.DataTable100.Namespace = ""
        Me.DataTable100.TableName = "COMBOBOX"
        '
        'DataTable101
        '
        Me.DataTable101.Namespace = ""
        Me.DataTable101.TableName = "COMBOBOX"
        '
        'DataTable102
        '
        Me.DataTable102.Namespace = ""
        Me.DataTable102.TableName = "COMBOBOX"
        '
        'DataTable103
        '
        Me.DataTable103.Namespace = ""
        Me.DataTable103.TableName = "COMBOBOX"
        '
        'DataTable104
        '
        Me.DataTable104.Namespace = ""
        Me.DataTable104.TableName = "COMBOBOX"
        '
        'DataTable105
        '
        Me.DataTable105.Namespace = ""
        Me.DataTable105.TableName = "COMBOBOX"
        '
        'DataTable106
        '
        Me.DataTable106.Namespace = ""
        Me.DataTable106.TableName = "COMBOBOX"
        '
        'DataTable107
        '
        Me.DataTable107.Namespace = ""
        Me.DataTable107.TableName = "COMBOBOX"
        '
        'DataTable108
        '
        Me.DataTable108.Namespace = ""
        Me.DataTable108.TableName = "COMBOBOX"
        '
        'DataTable109
        '
        Me.DataTable109.Namespace = ""
        Me.DataTable109.TableName = "COMBOBOX"
        '
        'DataTable110
        '
        Me.DataTable110.Namespace = ""
        Me.DataTable110.TableName = "COMBOBOX"
        '
        'DataTable111
        '
        Me.DataTable111.Namespace = ""
        Me.DataTable111.TableName = "COMBOBOX"
        '
        'DataTable112
        '
        Me.DataTable112.Namespace = ""
        Me.DataTable112.TableName = "COMBOBOX"
        '
        'DataTable113
        '
        Me.DataTable113.Namespace = ""
        Me.DataTable113.TableName = "COMBOBOX"
        '
        'DataTable114
        '
        Me.DataTable114.Namespace = ""
        Me.DataTable114.TableName = "COMBOBOX"
        '
        'DataTable115
        '
        Me.DataTable115.Namespace = ""
        Me.DataTable115.TableName = "COMBOBOX"
        '
        'DataTable116
        '
        Me.DataTable116.Namespace = ""
        Me.DataTable116.TableName = "COMBOBOX"
        '
        'DataTable117
        '
        Me.DataTable117.Namespace = ""
        Me.DataTable117.TableName = "COMBOBOX"
        '
        'DataTable118
        '
        Me.DataTable118.Namespace = ""
        Me.DataTable118.TableName = "COMBOBOX"
        '
        'DataTable119
        '
        Me.DataTable119.Namespace = ""
        Me.DataTable119.TableName = "COMBOBOX"
        '
        'DataTable120
        '
        Me.DataTable120.Namespace = ""
        Me.DataTable120.TableName = "COMBOBOX"
        '
        'DataTable121
        '
        Me.DataTable121.Namespace = ""
        Me.DataTable121.TableName = "COMBOBOX"
        '
        'DataTable122
        '
        Me.DataTable122.Namespace = ""
        Me.DataTable122.TableName = "COMBOBOX"
        '
        'DataTable123
        '
        Me.DataTable123.Namespace = ""
        Me.DataTable123.TableName = "COMBOBOX"
        '
        'DataTable124
        '
        Me.DataTable124.Namespace = ""
        Me.DataTable124.TableName = "COMBOBOX"
        '
        'DataTable125
        '
        Me.DataTable125.Namespace = ""
        Me.DataTable125.TableName = "COMBOBOX"
        '
        'DataTable126
        '
        Me.DataTable126.Namespace = ""
        Me.DataTable126.TableName = "COMBOBOX"
        '
        'DataTable127
        '
        Me.DataTable127.Namespace = ""
        Me.DataTable127.TableName = "COMBOBOX"
        '
        'DataTable128
        '
        Me.DataTable128.Namespace = ""
        Me.DataTable128.TableName = "COMBOBOX"
        '
        'DataTable129
        '
        Me.DataTable129.Namespace = ""
        Me.DataTable129.TableName = "COMBOBOX"
        '
        'DataTable130
        '
        Me.DataTable130.Namespace = ""
        Me.DataTable130.TableName = "COMBOBOX"
        '
        'DataTable131
        '
        Me.DataTable131.Namespace = ""
        Me.DataTable131.TableName = "COMBOBOX"
        '
        'DataTable132
        '
        Me.DataTable132.Namespace = ""
        Me.DataTable132.TableName = "COMBOBOX"
        '
        'DataTable133
        '
        Me.DataTable133.Namespace = ""
        Me.DataTable133.TableName = "COMBOBOX"
        '
        'DataTable134
        '
        Me.DataTable134.Namespace = ""
        Me.DataTable134.TableName = "COMBOBOX"
        '
        'DataTable135
        '
        Me.DataTable135.Namespace = ""
        Me.DataTable135.TableName = "COMBOBOX"
        '
        'DataTable136
        '
        Me.DataTable136.Namespace = ""
        Me.DataTable136.TableName = "COMBOBOX"
        '
        'DataTable137
        '
        Me.DataTable137.Namespace = ""
        Me.DataTable137.TableName = "COMBOBOX"
        '
        'DataTable138
        '
        Me.DataTable138.Namespace = ""
        Me.DataTable138.TableName = "COMBOBOX"
        '
        'DataTable139
        '
        Me.DataTable139.Namespace = ""
        Me.DataTable139.TableName = "COMBOBOX"
        '
        'DataTable140
        '
        Me.DataTable140.Namespace = ""
        Me.DataTable140.TableName = "COMBOBOX"
        '
        'DataTable141
        '
        Me.DataTable141.Namespace = ""
        Me.DataTable141.TableName = "COMBOBOX"
        '
        'DataTable142
        '
        Me.DataTable142.Namespace = ""
        Me.DataTable142.TableName = "COMBOBOX"
        '
        'DataTable143
        '
        Me.DataTable143.Namespace = ""
        Me.DataTable143.TableName = "COMBOBOX"
        '
        'DataTable144
        '
        Me.DataTable144.Namespace = ""
        Me.DataTable144.TableName = "COMBOBOX"
        '
        'DataTable145
        '
        Me.DataTable145.Namespace = ""
        Me.DataTable145.TableName = "COMBOBOX"
        '
        'DataTable146
        '
        Me.DataTable146.Namespace = ""
        Me.DataTable146.TableName = "COMBOBOX"
        '
        'DataTable147
        '
        Me.DataTable147.Namespace = ""
        Me.DataTable147.TableName = "COMBOBOX"
        '
        'DataTable148
        '
        Me.DataTable148.Namespace = ""
        Me.DataTable148.TableName = "COMBOBOX"
        '
        'DataTable149
        '
        Me.DataTable149.Namespace = ""
        Me.DataTable149.TableName = "COMBOBOX"
        '
        'DataTable150
        '
        Me.DataTable150.Namespace = ""
        Me.DataTable150.TableName = "COMBOBOX"
        '
        'DataTable151
        '
        Me.DataTable151.Namespace = ""
        Me.DataTable151.TableName = "COMBOBOX"
        '
        'DataTable152
        '
        Me.DataTable152.Namespace = ""
        Me.DataTable152.TableName = "COMBOBOX"
        '
        'DataTable153
        '
        Me.DataTable153.Namespace = ""
        Me.DataTable153.TableName = "COMBOBOX"
        '
        'DataTable154
        '
        Me.DataTable154.Namespace = ""
        Me.DataTable154.TableName = "COMBOBOX"
        '
        'DataTable155
        '
        Me.DataTable155.Namespace = ""
        Me.DataTable155.TableName = "COMBOBOX"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.xtraTabControlModule)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(1066, 398)
        Me.Panel2.TabIndex = 0
        '
        'xtraTabControlModule
        '
        Me.xtraTabControlModule.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        Me.xtraTabControlModule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xtraTabControlModule.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[False]
        Me.xtraTabControlModule.Location = New System.Drawing.Point(3, 3)
        Me.xtraTabControlModule.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.xtraTabControlModule.Name = "xtraTabControlModule"
        Me.xtraTabControlModule.Size = New System.Drawing.Size(1060, 392)
        Me.xtraTabControlModule.TabIndex = 0
        '
        'DataTable297
        '
        Me.DataTable297.Namespace = ""
        Me.DataTable297.TableName = "COMBOBOX"
        '
        'DataTable316
        '
        Me.DataTable316.Namespace = ""
        Me.DataTable316.TableName = "COMBOBOX"
        '
        'DataTable157
        '
        Me.DataTable157.Namespace = ""
        Me.DataTable157.TableName = "COMBOBOX"
        '
        'PopupMenuClose
        '
        Me.PopupMenuClose.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnclose), New DevExpress.XtraBars.LinkPersistInfo(Me.btncloseother), New DevExpress.XtraBars.LinkPersistInfo(Me.btncloseright), New DevExpress.XtraBars.LinkPersistInfo(Me.btncloseall)})
        Me.PopupMenuClose.Manager = Me.barManager
        Me.PopupMenuClose.Name = "PopupMenuClose"
        Me.PopupMenuClose.ShowNavigationHeader = DevExpress.Utils.DefaultBoolean.[True]
        '
        'DataTable195
        '
        Me.DataTable195.Namespace = ""
        Me.DataTable195.TableName = "COMBOBOX"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LawnGreen
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1066, 23)
        Me.Panel3.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1072, 433)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'tmrAFK
        '
        Me.tmrAFK.Interval = 1000
        '
        'frmMDIMain
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.ClientSize = New System.Drawing.Size(1072, 542)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.stbMain)
        Me.Controls.Add(Me.msMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMDIMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: VSTP 1.0 On 2023 ::."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stbMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable85, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable86, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable87, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable88, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable89, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable90, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable91, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable93, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable94, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable95, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable96, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable97, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable98, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable99, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable101, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable102, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable103, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable104, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable105, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable107, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable108, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable109, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable110, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable113, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable114, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable115, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable116, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable117, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable118, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable119, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable120, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable121, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable122, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable123, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable124, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable125, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable126, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable127, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable129, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable131, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable132, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable133, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable134, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable135, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable137, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable138, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable139, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable140, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable141, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable142, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable143, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable144, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable145, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable146, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable147, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable148, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable149, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable150, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable151, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable152, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable153, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable154, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable155, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.xtraTabControlModule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable297, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable316, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable157, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable195, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Cache variable "
    Private mv_strSYMBOLLIST As String = ""
    Private mv_strSymbolTable As New DataTable
    Public mv_strCOUNTRYLIST As String = ""
    Public mv_strCOUNTRYTable As New DataTable


    Public mv_strCELLSDEFINELIST As String = ""
    Public mv_strCELLSDEFINETable As New DataTable

    Public mv_strPROVINCELIST As String = ""
    Public mv_strPROVINCETable As New DataTable
    Private mv_SymbolList As New DataSet
    Private mv_strVersion As String = "0000"
    'Private m_CurrCAToken As CAToken
    Private mv_SignMode As String = "N"
    Private mv_isValidToken As Boolean = True
    Private mv_str_cmdmenu As String
#End Region

#Region " Private section "
    'Public mainThread As Thread
    'Dim thrCheckSession As New Threading.Thread(AddressOf CheckSession)
    Public Shared secondsLimitAFK As Integer
    Public Shared remainingConnectionTimeToHost As Integer

    Public server As AsynchronousSocketListener
    Delegate Sub ShowMainScreenCallBack(ByVal phoneNumber As String)
    Private m_frmTele As New Form

    Dim v_strCallNumber As String
    Dim serverVT As TcpListener
    Dim streamVT As NetworkStream
    Dim v_strTELEORDER As String
    Dim istcplistener As Boolean

    'Primary middle tier component
    Private m_BusLayer As CBusLayer = Nothing
    Public tickCount As Decimal

    'Misc variables
    Private m_blnIsOnline As Boolean = True             'Mặc định là làm việc online
    Private m_ResourceManager As Resources.ResourceManager
    Private mv_strTellerRight As String

    Private m_blnAllowBrokerDesk As Boolean = False
    Private m_blnAllowTeleOrder As Boolean = False
    Private m_blnAllowBrokerConfirm As Boolean = False
    Private m_blnAllowCreateDeal As Boolean = False
    Private m_blnAllowForceSell As Boolean = False
    Private mv_strCurrentTime As String
    Dim hTransAllowed As New Hashtable
    Private hMenuFunction As New Hashtable
    Private hRptMaster As New Hashtable
    Private hTreeMenuFunction As New Hashtable      'Key là CommandCode, Value là TreeMenuFunction Object
    Private hTreeMnViewCodeMap As New Hashtable     ' map giua mnviewcode va cmdid
    Private arrTreeMenuFunction() As CTreeMenuFunction
    Private arrTreeNode As New Hashtable            'Với cmdCode tương ứng với node nào trên cây menu

    'Custom exception for exiting the application
    Private Class ExitException
        Inherits ApplicationException

        Private m_Msg As String = String.Empty

        Public Sub New()
        End Sub

        Public Sub New(ByVal msg As String)
            m_Msg = msg
        End Sub

        Public Sub Show()


            If m_Msg <> String.Empty Then MsgBox(m_Msg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Sub
    End Class


#End Region

#Region " Other Mothod "

    Private Sub getSignMode()
        Dim v_strCmdInquiry As String
        v_strCmdInquiry = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME ='ISSIGNMODE' "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString
                    Select Case Trim(v_strFLDNAME)
                        Case "VARVALUE"
                            mv_SignMode = Trim(v_strValue)
                    End Select
                End With
            Next
        Next
    End Sub
    Private Function getCurrdate() As String
        Dim v_strCmdInquiry As String
        v_strCmdInquiry = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME ='CURRDATE' "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim v_strCurrdate As String = String.Empty
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString
                    Select Case Trim(v_strFLDNAME)
                        Case "VARVALUE"
                            v_strCurrdate = Trim(v_strValue)
                    End Select
                End With
            Next
        Next
        Return v_strCurrdate
    End Function

    Private Sub LoadBarMenu(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg, str_objFunction As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_objFunction As CommonLibrary.CTreeMenuFunction

        Dim v_nodeRoot, v_nodeParent As BarSubItemEx
        Dim v_node As BarButtonItemEx

        Dim i As Integer
        Dim j As Integer
        Try
            'Clear cây chức năng
            barManager.MainMenu.ClearLinks()
            If IsShown Then
                'Lấy thông tin về cây chức năng của UserLogin
                GetTreeMenuFunction()
                'Hiển thị cây Menu
                If arrTreeMenuFunction.Length > 0 Then
                    arrTreeNode.Clear()
                    For i = 0 To arrTreeMenuFunction.Length - 1 Step 1
                        v_objFunction = arrTreeMenuFunction(i)
                        Try
                            If Not (v_objFunction Is Nothing) Then
                                If Not (v_objFunction.CmdCode.Length = 0) Then
                                    If v_objFunction.MenuLevel = 1 Then
                                        'Root Item
                                        j = j + 1

                                        If m_BusLayer.AppLanguage <> "EN" Then
                                            str_objFunction = "&" & j & ". " & v_objFunction.CmdName
                                        Else
                                            str_objFunction = "&" & j & ". " & v_objFunction.EN_CmdName
                                        End If


                                        'NAMNT
                                        'Dim v_mnu As New BarSubItemEx(barManager, "&" & j & ". " & v_objFunction.CmdName)
                                        Dim v_mnu As New BarSubItemEx(barManager, str_objFunction)

                                        v_mnu.Key = v_objFunction.CmdCode

                                        If v_objFunction.ImageIndex > 0 Then
                                            v_mnu.ImageIndex = v_objFunction.ImageIndex
                                        End If

                                        barMainMenu.AddItem(v_mnu)
                                        v_nodeRoot = v_mnu
                                    Else
                                        'Xác định parent node là node cha
                                        If Not arrTreeNode(v_objFunction.PrID) Is Nothing Then
                                            v_nodeParent = arrTreeNode(v_objFunction.PrID)
                                        Else
                                            'Mặc định đưa vào RootNode
                                            v_nodeParent = v_nodeRoot
                                        End If

                                        'Chỉ tạo cây menu nếu có con
                                        If v_objFunction.ChildCount > 0 Then
                                            'Sub Item


                                            If m_BusLayer.AppLanguage <> "EN" Then
                                                str_objFunction = v_objFunction.CmdName
                                            Else
                                                str_objFunction = v_objFunction.EN_CmdName
                                            End If

                                            ' Dim v_mnu As New BarSubItemEx(barManager, v_objFunction.CmdName)
                                            Dim v_mnu As New BarSubItemEx(barManager, str_objFunction)

                                            v_mnu.Key = v_objFunction.CmdCode

                                            If v_objFunction.ImageIndex > 0 Then
                                                v_mnu.ImageIndex = v_objFunction.ImageIndex
                                            End If

                                            v_nodeParent.AddItem(v_mnu)

                                            arrTreeNode.Add(v_objFunction.CmdCode, v_mnu)
                                        Else
                                            v_node = BindButtonItemToSubItem(v_objFunction, v_nodeParent)

                                            If v_objFunction.ImageIndex > 0 Then
                                                v_node.ImageIndex = v_objFunction.ImageIndex
                                            End If
                                            'Ghi nhận
                                            arrTreeNode.Add(v_objFunction.CmdCode, v_node)
                                        End If

                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            LogError.Write("CmdName: " & i, EventLogEntryType.Error)
                        End Try


                    Next
                    'Hiển thị menu customized
                    'DisplayAdjustMenu_BDS()
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.StackTrace & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        Finally
            XmlDocument = Nothing
        End Try
    End Sub

    Private Sub LoadMenu(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_objFunction As CommonLibrary.CTreeMenuFunction
        Dim v_nodeRoot, v_nodeParent, v_node As MenuItemEx
        Dim i As Integer
        Try
            'Clear cây chức năng
            Me.msMain.Items.Clear()
            If IsShown Then
                'Lấy thông tin về cây chức năng của UserLogin
                GetTreeMenuFunction()
                'Hiển thị cây Menu
                If arrTreeMenuFunction.Length > 0 Then
                    arrTreeNode.Clear()
                    For i = 0 To arrTreeMenuFunction.Length - 1 Step 1
                        v_objFunction = arrTreeMenuFunction(i)
                        If Not v_objFunction.CmdCode.Length = 0 Then

                            If v_objFunction.MenuLevel = 1 Then
                                'Root Item
                                'Dim v_mnu As New MenuItemEx(v_objFunction.CmdName)
                                'NAMNT
                                Dim v_mnu As New MenuItemEx(v_objFunction.EN_CmdName)
                                v_mnu.Key = v_objFunction.CmdCode
                                msMain.Items.Add(v_mnu)
                                v_nodeRoot = v_mnu
                            Else
                                'Xác định parent node là node cha
                                If Not arrTreeNode(v_objFunction.PrID) Is Nothing Then
                                    v_nodeParent = arrTreeNode(v_objFunction.PrID)
                                Else
                                    'Mặc định đưa vào RootNode
                                    v_nodeParent = v_nodeRoot
                                End If
                                'Chỉ tạo cây menu nếu có con
                                If Not (v_objFunction.LastItem = "N" And v_objFunction.ChildCount = 0) Then
                                    v_node = BindObjectToTreeNode(v_objFunction, v_nodeParent)
                                    'Ghi nhận
                                    arrTreeNode.Add(v_objFunction.CmdCode, v_node)
                                End If
                            End If
                        End If
                    Next
                    'Hiển thị menu customized
                    'DisplayAdjustMenu_BDS()
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
        Finally
            XmlDocument = Nothing
        End Try
    End Sub

    Private Function BindButtonItemToSubItem(ByRef objFunction As CommonLibrary.CTreeMenuFunction, ByRef parentTreeNode As BarSubItemEx) As BarButtonItemEx
        Dim v_tempNode, v_retNode As BarButtonItemEx
        Dim strMenuKey As String

        Try
            If Not objFunction Is Nothing Then
                If (objFunction.MenuType = "A" And objFunction.LastItem = "Y") Then
                    ''Chuc nang goi giao dich truc tiep
                    'Dim strTransKey As String = "|Y|" & objFunction.ModCode
                    ''If hTransAllowed(objFunction.TLTXCD) Is Nothing Then
                    ''hTransAllowed.Add(objFunction.TLTXCD, strTransKey)
                    ''End If
                    ''TruongLD Add load song ngu anh-viet khi login lan dau
                    'Dim v_strCmdName As String
                    'If m_BusLayer.AppLanguage <> "EN" Then
                    '    v_strCmdName = objFunction.CmdName
                    'ElseIf m_BusLayer.AppLanguage = "EN" Then
                    '    v_strCmdName = objFunction.EN_CmdName
                    'End If
                    ''End TruongLD
                    ''AnTB 24/04/2015 modify fix loi khong the hien duoc tieng anh khi thay doi ngon ngu
                    'v_retNode = AddTreeNode(parentTreeNode, strTransKey, v_strCmdName, gc_IS_LAST_MENU, objFunction.ImageIndex)
                    'Return v_retNode

                    strMenuKey = objFunction.CmdCode & "|" & objFunction.MenuType & "|" & objFunction.ModCode _
                                        & "|" & objFunction.ObjName & "|" & objFunction.AuthCode & "|" & objFunction.StrAuth & "|" & objFunction.Shortcut

                    Dim v_strCmdName As String
                    If m_BusLayer.AppLanguage <> "EN" Then
                        v_strCmdName = objFunction.CmdName
                    ElseIf m_BusLayer.AppLanguage = "EN" Then
                        v_strCmdName = objFunction.EN_CmdName
                    End If
                    v_retNode = AddTreeNode(parentTreeNode, strMenuKey, objFunction.CmdCode & ": " & v_strCmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)
                    'v_retNode = AddTreeNode(parentTreeNode, strMenuKey, objFunction.MnViewCode & ": " & v_strCmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)
                    If String.Compare(objFunction.ObjName, "FODEALER") = 0 Or String.Compare(objFunction.ObjName, "PAFNMLTRAD") = 0 Then
                        m_blnAllowBrokerDesk = True
                    ElseIf String.Compare(objFunction.ObjName, "TELEINQ") = 0 Then
                        m_blnAllowTeleOrder = True
                    ElseIf String.Compare(objFunction.ObjName, "BROKERCONFIRM") = 0 Then
                        m_blnAllowBrokerConfirm = True
                    ElseIf String.Compare(objFunction.ObjName, "CREATEDFGRDEAL") = 0 Then
                        m_blnAllowCreateDeal = True
                    ElseIf String.Compare(objFunction.ObjName, "FOFORCESELL") = 0 Then
                        m_blnAllowForceSell = True
                    End If
                    Return v_retNode

                Else
                    If Not (objFunction.MenuType = "T" And objFunction.LastItem = "Y") Then
                        'Chức năng là CMDMENU
                        strMenuKey = objFunction.CmdCode & "|" & objFunction.MenuType & "|" & objFunction.ModCode _
                                        & "|" & objFunction.ObjName & "|" & objFunction.AuthCode & "|" & objFunction.StrAuth & "|" & objFunction.Shortcut

                        Dim v_strCmdName As String
                        If m_BusLayer.AppLanguage <> "EN" Then
                            v_strCmdName = objFunction.CmdName
                        ElseIf m_BusLayer.AppLanguage = "EN" Then
                            v_strCmdName = objFunction.EN_CmdName
                        End If
                        v_retNode = AddTreeNode(parentTreeNode, strMenuKey, objFunction.CmdCode & ": " & v_strCmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)
                        'v_retNode = AddTreeNode(parentTreeNode, strMenuKey, objFunction.MnViewCode & ": " & v_strCmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)
                        If String.Compare(objFunction.ObjName, "FODEALER") = 0 Or String.Compare(objFunction.ObjName, "PAFNMLTRAD") = 0 Then
                            m_blnAllowBrokerDesk = True
                        ElseIf String.Compare(objFunction.ObjName, "TELEINQ") = 0 Then
                            m_blnAllowTeleOrder = True
                        ElseIf String.Compare(objFunction.ObjName, "BROKERCONFIRM") = 0 Then
                            m_blnAllowBrokerConfirm = True
                        ElseIf String.Compare(objFunction.ObjName, "CREATEDFGRDEAL") = 0 Then
                            m_blnAllowCreateDeal = True
                        ElseIf String.Compare(objFunction.ObjName, "FOFORCESELL") = 0 Then
                            m_blnAllowForceSell = True
                        End If
                        Return v_retNode
                    Else
                        'Chức năng là TLTX
                        If objFunction.CmdAllow = "Y" Then
                            Dim strTransKey As String = objFunction.CmdCode & "|" & objFunction.CmdAllow & "|" & objFunction.ModCode
                            If hTransAllowed(objFunction.CmdCode) Is Nothing Then
                                hTransAllowed.Add(objFunction.CmdCode, strTransKey)
                            End If
                            'TruongLD Add load song ngu anh-viet khi login lan dau
                            Dim v_strCmdName As String
                            If m_BusLayer.AppLanguage <> "EN" Then
                                v_strCmdName = objFunction.CmdName
                            ElseIf m_BusLayer.AppLanguage = "EN" Then
                                v_strCmdName = objFunction.EN_CmdName
                            End If
                            'End TruongLD
                            'AnTB 24/04/2015 modify fix loi khong the hien duoc tieng anh khi thay doi ngon ngu
                            'v_retNode = AddTreeNode(parentTreeNode, strTransKey, objFunction.CmdCode & ": " & v_strCmdName, gc_IS_LAST_MENU, objFunction.ImageIndex)
                            v_retNode = AddTreeNode(parentTreeNode, strTransKey, objFunction.CmdCode & ": " & v_strCmdName, gc_IS_LAST_MENU, objFunction.ImageIndex)

                            Return v_retNode
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return Nothing
    End Function

    Private Function BindObjectToTreeNode(ByRef objFunction As CommonLibrary.CTreeMenuFunction, ByRef parentTreeNode As MenuItemEx) As MenuItemEx
        Dim v_tempNode, v_retNode As MenuItemEx
        Dim strMenuKey As String
        If Not objFunction Is Nothing Then
            If Not (objFunction.MenuType = "T" And objFunction.LastItem = "Y") Then
                'Chức năng là CMDMENU
                strMenuKey = objFunction.CmdCode & "|" & objFunction.MenuType & "|" & objFunction.ModCode _
                                & "|" & objFunction.ObjName & "|" & objFunction.AuthCode & "|" & objFunction.StrAuth & "|" & objFunction.Shortcut

                'TruongLD Add load song ngu anh-viet khi login lan dau
                Dim v_strCmdName As String
                If m_BusLayer.AppLanguage <> "EN" Then
                    v_strCmdName = objFunction.CmdName
                ElseIf m_BusLayer.AppLanguage = "EN" Then
                    v_strCmdName = objFunction.EN_CmdName
                End If
                'End TruongLD
                '24/04/2015 AnTB modify case theo ngon ngu de the hien len cay menu
                v_retNode = AddTreeNode(parentTreeNode, strMenuKey, v_strCmdName, objFunction.LastItem, objFunction.ImageIndex, objFunction.ObjName)

                If String.Compare(objFunction.ObjName, "FODEALER") = 0 Or String.Compare(objFunction.ObjName, "PAFNMLTRAD") = 0 Then
                    m_blnAllowBrokerDesk = True
                ElseIf String.Compare(objFunction.ObjName, "TELEINQ") = 0 Then
                    m_blnAllowTeleOrder = True
                ElseIf String.Compare(objFunction.ObjName, "BROKERCONFIRM") = 0 Then
                    m_blnAllowBrokerConfirm = True
                ElseIf String.Compare(objFunction.ObjName, "CREATEDFGRDEAL") = 0 Then
                    m_blnAllowCreateDeal = True
                ElseIf String.Compare(objFunction.ObjName, "FOFORCESELL") = 0 Then
                    m_blnAllowForceSell = True
                End If
                Return v_retNode
            Else
                'Chức năng là TLTX
                If objFunction.CmdAllow = "Y" Then
                    Dim strTransKey As String = objFunction.CmdCode & "|" & objFunction.CmdAllow & "|" & objFunction.ModCode
                    If hTransAllowed(objFunction.CmdCode) Is Nothing Then
                        hTransAllowed.Add(objFunction.CmdCode, strTransKey)
                    End If
                    'TruongLD Add load song ngu anh-viet khi login lan dau
                    Dim v_strCmdName As String
                    If m_BusLayer.AppLanguage <> "EN" Then
                        v_strCmdName = objFunction.CmdName
                    ElseIf m_BusLayer.AppLanguage = "EN" Then
                        v_strCmdName = objFunction.EN_CmdName
                    End If
                    'End TruongLD
                    'AnTB 24/04/2015 modify fix loi khong the hien duoc tieng anh khi thay doi ngon ngu
                    v_retNode = AddTreeNode(parentTreeNode, strTransKey, objFunction.CmdCode & ": " & v_strCmdName, gc_IS_LAST_MENU, objFunction.ImageIndex)
                    Return v_retNode
                End If
            End If
        End If
        Return Nothing
    End Function

    'Lấy cây chức năng và các báo cáo được phân quyền sử dụng
    Private Sub GetTreeMenuFunction()
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strObjMsg, v_strKey, v_strFLDNAME, v_strValue, v_strCMDID, v_strPRID As String
        Dim v_obj, v_objTmp As CommonLibrary.CTreeMenuFunction
        Dim v_strSQL, v_strRPTID, v_strMODCODE, v_strCMDTYPE, v_strDESC, v_strSTORENAME As String
        Dim i, j As Integer
        Try
            'VinhLD goi ham lay cay chuc nang theo UserLogin
            v_strObjMsg = CommonLibrary.BuildXMLObjMsg(Now.Date, m_BusLayer.CurrentTellerProfile.BranchId, Now.Date,
                    m_BusLayer.CurrentTellerProfile.TellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                    OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , m_BusLayer.CurrentTellerProfile.TellerId, "GetTreeMenuByUser", , , "U", m_BusLayer.CurrentTellerProfile.AccessArea)
            m_BusLayer.BusSystemMessage(v_strObjMsg)

            'Khởi tạo cây chức năng
            hTreeMenuFunction.Clear()
            hTreeMnViewCodeMap.Clear()
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim arrTreeMenuFunction(v_nodeList.Count)
            For i = 0 To v_nodeList.Count - 1
                v_obj = New CommonLibrary.CTreeMenuFunction
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "ODRID"
                                v_obj.SequenceId = v_strValue
                            Case "CMDCODE"
                                v_strKey = v_strValue
                                v_obj.CmdCode = v_strValue
                            Case "CMDID"
                                v_obj.CmdID = v_strValue
                            Case "PRID"
                                v_obj.PrID = v_strValue
                            Case "CMDNAME"
                                v_obj.CmdName = v_strValue
                            Case "EN_CMDNAME"
                                v_obj.EN_CmdName = v_strValue
                            Case "LAST"
                                v_obj.LastItem = v_strValue
                            Case "IMGINDEX"
                                v_obj.ImageIndex = v_strValue
                            Case "MODCODE"
                                v_obj.ModCode = v_strValue
                            Case "OBJNAME"
                                v_obj.ObjName = v_strValue
                            Case "MENUTYPE"
                                v_obj.MenuType = v_strValue
                            Case "LEV"
                                v_obj.MenuLevel = v_strValue
                            Case "CMDALLOW"
                                v_obj.CmdAllow = v_strValue
                            Case "AUTHCODE"
                                v_obj.AuthCode = v_strValue
                            Case "STRAUTH"
                                v_obj.StrAuth = v_strValue
                            Case "RIGHTSCOPE"
                                v_obj.RightScope = v_strValue
                            Case "SHORTCUT"
                                v_obj.Shortcut = v_strValue
                            Case "MNVIEWCODE"
                                v_obj.MnViewCode = v_strValue
                            Case "MKTDOMAIN"
                                v_obj.MktDomain = v_strValue
                            Case "USERROLES"
                                v_obj.UserRoles = v_strValue
                            Case "TLTXCD"
                                If v_strValue.Length > 0 Then
                                    v_obj.TLTXCD = v_strValue.Trim
                                Else
                                    v_obj.TLTXCD = ""
                                End If
                        End Select
                    End With
                Next

                'Kiểm tra đã có command code chưa
                If Not hTreeMenuFunction.ContainsKey(v_strKey) Then
                    'Sử dụng để dựng Menu theo thứ tự
                    arrTreeMenuFunction(i) = v_obj
                    'Sử dụng để truy cập thuộc tính
                    hTreeMenuFunction.Add(v_strKey, v_obj)
                    'If v_obj.MnViewCode.Length > 0 Then
                    'If Not hTreeMnViewCodeMap.ContainsKey(v_obj.MnViewCode) Then
                    ' hTreeMnViewCodeMap.Add(v_obj.MnViewCode, v_strKey)
                    ' End If
                    '  End If

                    'Xử lý Item cha
                    'v_strCMDID = v_obj.CmdID
                    'v_strPRID = v_obj.PrID
                    'v_objTmp = v_obj
                    If hTreeMenuFunction.ContainsKey(v_obj.PrID) Then
                        'If v_obj.LastItem = "Y" Then
                        'Cha có con
                        IncreParentChildCount(v_obj)
                        'hTreeMenuFunction(v_obj.PrID).ChildCount += 1
                        'Else
                        '    CType(hTreeMenuFunction(v_strPRID), CommonLibrary.CTreeMenuFunction).ChildCount = _
                        '        CType(hTreeMenuFunction(v_strCMDID), CommonLibrary.CTreeMenuFunction).ChildCount
                        'End If
                        'v_objTmp = CType(hTreeMenuFunction(v_strPRID), CommonLibrary.CTreeMenuFunction)
                        'v_strPRID = v_objTmp.PrID
                        'v_strCMDID = v_objTmp.CmdID
                    End If
                Else
                    'Sử dụng để dựng Menu theo thứ tự
                    v_obj.CmdCode = ""
                    arrTreeMenuFunction(i) = v_obj
                End If
            Next

            'Xử lý nếu menu cha không có Item con nào thì remove luôn
            'For i = 0 To v_nodeList.Count - 1
            '    v_obj = arrTreeMenuFunction(i)
            '    If v_obj.LastItem = "N" Then
            '        If v_obj.ChildCount = 0 Then

            '        End If
            '    End If
            'Next


            'VinhLD them vao de goi truc tiep bao cao tu man hinh chinh
            'Load danh sách báo cáo            
            v_strSQL = "SELECT DISTINCT MODCODE, RPTID, CMDTYPE, MAX(DT.DESCRIPTION) DESCTXT, MAX(DT.EN_DESCRIPTION) EN_DESCTXT,STOREDNAME " & ControlChars.CrLf _
                & "FROM RPTMASTER DT WHERE DT.CMDTYPE in( 'V','D','L','R') AND DT.visible <> 'N' AND DT.MODCODE LIKE '%' "
            If m_BusLayer.CurrentTellerProfile.TellerId <> ADMIN_ID Then
                'Lấy theo phân quyền
                v_strSQL = v_strSQL & " AND DT.RPTID IN (" & ControlChars.CrLf _
                    & "SELECT A.CMDCODE FROM CMDAUTH A WHERE A.AUTHTYPE='U' AND A.CMDTYPE IN ('R','V','L','G') AND A.AUTHID='" & m_BusLayer.CurrentTellerProfile.TellerId & "' UNION " & ControlChars.CrLf _
                    & "SELECT DISTINCT A.CMDCODE FROM CMDAUTH A, TLGRPUSERS M WHERE A.AUTHTYPE='G' AND A.CMDTYPE IN ('R','V','L','G') AND M.GRPID=A.AUTHID AND M.TLID='" & m_BusLayer.CurrentTellerProfile.TellerId & "')"
            End If
            v_strSQL = v_strSQL & ControlChars.CrLf & "GROUP BY MODCODE, RPTID, CMDTYPE, STOREDNAME ORDER BY MODCODE, RPTID"
            v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            m_BusLayer.BusSystemMessage(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            hRptMaster.Clear()
            'Nạp vào HashTable báo cáo
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "RPTID"
                                v_strRPTID = v_strValue
                            Case "CMDTYPE"
                                v_strCMDTYPE = v_strValue
                            Case "MODCODE"
                                v_strMODCODE = v_strValue
                            Case "DESCTXT"
                                If m_BusLayer.AppLanguage <> "EN" Then
                                    v_strDESC = v_strValue
                                End If
                            Case "EN_DESCTXT"
                                If m_BusLayer.AppLanguage = "EN" Then
                                    v_strDESC = v_strValue
                                End If
                            Case "STOREDNAME"
                                v_strSTORENAME = v_strValue
                        End Select
                    End With
                Next v_int
                hRptMaster.Add(v_strCMDTYPE & v_strRPTID, v_strCMDTYPE & "|" & v_strMODCODE & "|" & v_strDESC & "|" & v_strSTORENAME)
            Next v_intCount

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    Private Sub IncreParentChildCount(ByVal lastItem As CommonLibrary.CTreeMenuFunction)
        Try
            If hTreeMenuFunction.ContainsKey(lastItem.PrID) Then
                hTreeMenuFunction(lastItem.PrID).ChildCount += 1

                IncreParentChildCount(hTreeMenuFunction(lastItem.PrID))

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'End VinhLD
    Private Sub OnMDILoad()
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        BarButtonItem1.Visibility = BarItemVisibility.Never
        Dim v_strPhoneCalllistening, v_strCulture_Lang, v_strDecimal_Number, v_strGroup_Number, v_strSystemMenuHideDefault, v_strCustomizeMenuHideDefault As String
        v_strCulture_Lang = ConfigurationManager.AppSettings("CultureInfo")
        v_strDecimal_Number = ConfigurationManager.AppSettings("NumberDecimalSeparator")
        v_strGroup_Number = ConfigurationManager.AppSettings("NumberGroupSeparator")
        v_strPhoneCalllistening = ConfigurationManager.AppSettings("PhoneCalllistening")
        'Dim ci As New CultureInfo("vi-VN")
        Dim ci As New CultureInfo(v_strCulture_Lang)
        ci.NumberFormat.NumberDecimalSeparator = v_strDecimal_Number
        ci.NumberFormat.NumberGroupSeparator = v_strGroup_Number

        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        ci.DateTimeFormat.DateSeparator = "/"
        Application.CurrentCulture = ci
        Thread.CurrentThread.CurrentCulture = ci

        'Chưa hiển thị màn hình tìm kiếm các giao dịch trong ngày. Chỉ hiển thị màn hình này khi đăng nhập vào xong
        ucSearchTLLOG.Visible = False
        'Trung.luu: 04-04-2020
        'Ẩn thanh bar menu khi chưa login
        Bar3.Visible = False

        'Disible transaction code menu
        tbtTransaction.Visible = False

        'Load Splash form



        'Khởi tạo các tham số cho hệ thống
        Try
            'Tạo một instance của lớp ứng dụng
            m_BusLayer = New CBusLayer
            m_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "Localize-" & m_BusLayer.AppLanguage, System.Reflection.Assembly.GetExecutingAssembly())

            'Load user interface depend on system language
            LoadUserInterface()
        Catch ex As UriFormatException

            MsgBox(m_ResourceManager.GetString(gc_SYSERR_BAD_URL), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.Close()
            Return
        End Try

        'Lay tham so signmode
        'mv_SignMode = ConfigurationManager.AppSettings("SignMode")
        'getSignMode()

        ''Load CA
        'If mv_SignMode = "Y" Then
        '    Dim frmCA As New CALoad
        '    frmCA.ShowDialog(Me)
        '    m_CurrCAToken = frmCA.CurrToken

        '    If m_CurrCAToken.Serial.Length = 0 Then
        '        Exit Sub
        '    End If
        '    m_BusLayer.CAToken = m_CurrCAToken
        '    m_BusLayer.mv_SignMode = "Y"
        'End If

        LoadRegistrySettings()

        If m_blnIsOnline Then
            If DisplayLoginForm() = DialogResult.Cancel Then End

            'Check valid token luc login
            If Not mv_isValidToken Then
                ChangeOnlineStatus(False)
                'Invisible TLLOG search & transaction code menu
                ucSearchTLLOG.Visible = False
                tbtTransaction.Visible = False
                hMenuFunction.Clear()
                m_blnAllowBrokerDesk = False
                m_blnAllowTeleOrder = False
                m_blnAllowCreateDeal = False
                m_blnAllowForceSell = False

                barManager.MainMenu.ClearLinks()

                LoadBarSystemMenu("2")
                'Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
                ''Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
                'v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
                'v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
                'v_mnuLogin.ImageIndex = 4
                'v_mnuLogin.Alignment = BarItemLinkAlignment.Right
                'barMainMenu.AddItem(v_mnuLogin)
                'AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick
                Exit Sub
            End If

            'Chuyen con tro chuot sang hinh dong ho cat
            MyBase.Cursor = Cursors.WaitCursor

            ChangeOnlineStatus(True)

            Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
            Me.Text = ".:: VSTP " & myBuildInfo.FileVersion & " On " & System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString("dd-MMM-yyyy") & " ::."


            sbrPanelStatus.Caption = m_ResourceManager.GetString("STATUS_LOADING_MENU")

            'LoadMenu()
            'LoadSystemMenu()
            LoadBarMenu()
            LoadBarSystemMenu("1")

            sbrPanelStatus.Caption = m_ResourceManager.GetString("STATUS_LOADING_PARAMS")

            ucSearchTLLOG.TableName = "TLLOG"
            ucSearchTLLOG.ModuleCode = "SY"
            ucSearchTLLOG.IsLocalSearch = gc_IsLocalMsg
            ucSearchTLLOG.UserLanguage = m_BusLayer.AppLanguage
            ucSearchTLLOG.SearchOnInit = False
            ucSearchTLLOG.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
            ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
            ucSearchTLLOG.TellerType = m_BusLayer.CurrentTellerProfile.TellerRight
            ucSearchTLLOG.TellerGroup = m_BusLayer.CurrentTellerProfile.TellerGroup
            ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
            ucSearchTLLOG.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
            ucSearchTLLOG.AccessArea = m_BusLayer.CurrentTellerProfile.AccessArea
            ucSearchTLLOG.InitDialog()
            ucSearchTLLOG.tmrSearch.Enabled = False

            AddHandler ucSearchTLLOG.OnShowCriterial, AddressOf OnAdvanceSearch

            If m_BusLayer.CurrentTellerProfile.Interval > 0 Then
                ucSearchTLLOG.tmrSearch.Interval = m_BusLayer.CurrentTellerProfile.Interval
                ucSearchTLLOG.tmrSearch.Enabled = True
            End If
            'Dim frm As New AppCore.frmSearch(m_BusLayer.AppLanguage)
            'If m_BusLayer.CurrentTellerProfile.TimeSearch > 0 Then
            '    frm.tmrSearch.Interval = m_BusLayer.CurrentTellerProfile.TimeSearch
            '    frm.tmrSearch.Enabled = True
            'End If
            'Add token
            'If mv_SignMode = "Y" Then
            '    ucSearchTLLOG.mv_SignMode = mv_SignMode
            '    ucSearchTLLOG.m_CurrCAToken = m_CurrCAToken
            'End If


            sbrPanelStatus.Caption = m_ResourceManager.GetString("STATUS_WORKING")
            'trung.luuL 05/06/2020 Tạm thời ẩn nút notify
            btnNotify.Visibility = BarItemVisibility.Never
            'Chuyen con tro chuot ve hinh dang binh thuong
            MyBase.Cursor = Cursors.Default
            'Tickcount for count time
            tickCount = CDec(Microsoft.VisualBasic.Strings.Left(m_BusLayer.CurrentTellerProfile.LoginTime, 2)) * 3600
            tickCount += CDec(Microsoft.VisualBasic.Strings.Mid(m_BusLayer.CurrentTellerProfile.LoginTime, 4, 2)) * 60
            tickCount += CDec(Microsoft.VisualBasic.Strings.Right(m_BusLayer.CurrentTellerProfile.LoginTime, 2))
            tickCount *= 1000
            tmrMain.Start()
            tmrCallCenter.Start()
            Bar3.Visible = True
            'End Trung.luu: 04-04-2020 Hiện thanh bar menu khi đã login
        End If

        'Hiển thị màn hình giao dịch trong ngày
        ucSearchTLLOG.Visible = True

        'Visible transaction code menu
        tbtTransaction.Visible = True
        ''Load danh sach chung khoan giao dich trong ngay
        LoadCasheInfo()
        'Close splash form
        Try
            v_strSystemMenuHideDefault = ConfigurationManager.AppSettings("SystemMenuHideDefault")
        Catch ex As Exception
            v_strSystemMenuHideDefault = "N"
        End Try
        Try
            v_strCustomizeMenuHideDefault = ConfigurationManager.AppSettings("CustomizeMenuHideDefault")
        Catch ex As Exception
            v_strCustomizeMenuHideDefault = "N"
        End Try

        If v_strPhoneCalllistening = "Y" Then
            'GianhVG Begin Them doan code xu ly bat so dien thoai 
            server = New AsynchronousSocketListener(15000)
            AddHandler server.Received, AddressOf ServerReceivedEvent 'ReceivePhoneNumberEventHandler(ServerReceivedEvent)
            Dim mainThreadDelegate As New System.Threading.Thread(AddressOf Me.server.StartListening)
            mainThreadDelegate.Sleep(3000)
            mainThreadDelegate.Start()
            'GianhVG End Them doan code xu ly bat so dien thoai 
        End If



        'tmrCallCenter.Interval = ConfigurationManager.AppSettings("PhoneTimerListening")

        'thrCheckSession.Start()
        'thrCheckSession.IsBackground = True


        'threadNotify.Change(1000, 1000)

        'Bar3.Manager.LargeIcons = True
        'LoadRegistryGridViewSettings()
    End Sub

    Private Sub OnAdvanceSearch()
        Try
            Dim frm As New frmXtraCriterial
            frm.SearchFieldMadatory = ucSearchTLLOG.SearchFieldMadatory
            frm.SearchFieldName = ucSearchTLLOG.SearchField
            frm.SearchFieldType = ucSearchTLLOG.SearchFieldType
            frm.SearchFieldCaption = ucSearchTLLOG.SearchFieldDisplay
            frm.SearchFieldSqlRef = ucSearchTLLOG.SearchFieldSqlRef
            frm.mv_language = m_BusLayer.AppLanguage
            frm.ShowDialog()

            If Not frm.ReturnValue Is Nothing Then
                'ucSearchTLLOG.AccessArea =M
                ucSearchTLLOG.Criterial = frm.ReturnValue
                ucSearchTLLOG.AccessArea = Me.m_BusLayer.CurrentTellerProfile.AccessArea
                ucSearchTLLOG.Search()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadSystemMenu()
        Dim v_mnuLogOUT As New MenuItemEx("Đăng Xuất")
        'Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
        v_mnuLogOUT.Key = "xxxxxx|A|SA|LOGOUT|YYYYYYYYYY|YYYY|"
        v_mnuLogOUT.ShortcutKeys = GetShortcut("F3")
        v_mnuLogOUT.Alignment = ToolStripItemAlignment.Right
        msMain.Items.Add(v_mnuLogOUT)
        AddHandler v_mnuLogOUT.Click, AddressOf Me.MenuItem_Click
        'v_mnuLogIN.Key = "yyyyyy|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
        'v_mnuLogIN.ShortcutKeys = GetShortcut("F4")
        'v_mnuLogIN.Alignment = ToolStripItemAlignment.Right
        'msMain.Items.Add(v_mnuLogIN)
        'AddHandler v_mnuLogIN.Click, AddressOf Me.MenuItem_Click

    End Sub

    Private Sub LoadBarSystemMenu(ByVal pv_strMode As String)
        'mode: 1. Login, 2 logout
        'Menu cha

        Dim v_mnuSystem As New BarSubItemEx(barManager, "0.System")
        v_mnuSystem.ImageIndex = 9
        v_mnuSystem.Alignment = BarItemLinkAlignment.Right
        barMainMenu.AddItem(v_mnuSystem)

        If pv_strMode = 1 Then
            'them menu doi pass
            Dim v_mnuChangePassword As New BarSubItemEx(barManager, "Change Password")
            v_mnuChangePassword.Key = "xxxxxx|A|SA|CHANGEPASSWORD|YYYYYYYYYY|YYYY|"
            'v_mnuChangePassword.ItemShortcut = New BarShortcut(GetShortcut("F3"))
            v_mnuChangePassword.ImageIndex = 4
            v_mnuChangePassword.Alignment = BarItemLinkAlignment.Right

            v_mnuSystem.AddItem(v_mnuChangePassword)
            AddHandler v_mnuChangePassword.ItemClick, AddressOf Me.BarSubItemClick
            'them menu loguot
            Dim v_mnuLogOUT As New BarSubItemEx(barManager, "Log out")
            'Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
            v_mnuLogOUT.Key = "xxxxxx|A|SA|LOGOUT|YYYYYYYYYY|YYYY|"
            v_mnuLogOUT.ItemShortcut = New BarShortcut(GetShortcut("F3"))
            v_mnuLogOUT.ImageIndex = 4
            v_mnuLogOUT.Alignment = BarItemLinkAlignment.Right
            v_mnuSystem.AddItem(v_mnuLogOUT)
            AddHandler v_mnuLogOUT.ItemClick, AddressOf Me.BarSubItemClick


            'them menu doi pass
            Dim v_mnuLangEnglish As New BarSubItemEx(barManager, "English")
            v_mnuLangEnglish.Key = "xxxxxx|A|SA|LANGENGLISH|YYYYYYYYYY|YYYY|"
            'v_mnuChangePassword.ItemShortcut = New BarShortcut(GetShortcut("F3"))
            v_mnuLangEnglish.ImageIndex = 4
            v_mnuLangEnglish.Alignment = BarItemLinkAlignment.Right
            If m_BusLayer.AppLanguage = "VN" Then
                v_mnuSystem.AddItem(v_mnuLangEnglish)
            End If
            AddHandler v_mnuLangEnglish.ItemClick, AddressOf Me.BarSubItemClick

            'them menu doi pass
            Dim v_mnuLangVietnamese As New BarSubItemEx(barManager, "Tiếng Việt")
            v_mnuLangVietnamese.Key = "xxxxxx|A|SA|LANGVIETNAMESE|YYYYYYYYYY|YYYY|"
            'v_mnuChangePassword.ItemShortcut = New BarShortcut(GetShortcut("F3"))
            v_mnuLangVietnamese.ImageIndex = 4
            v_mnuLangVietnamese.Alignment = BarItemLinkAlignment.Right
            If m_BusLayer.AppLanguage = "EN" Then
                v_mnuSystem.AddItem(v_mnuLangVietnamese)
            End If
            AddHandler v_mnuLangVietnamese.ItemClick, AddressOf Me.BarSubItemClick

            'TanPN 21/07/2020 them menu thoat chuong trinh
            'Dim v_mnuSysExit As New BarSubItemEx(barManager, "Exit")
            'v_mnuSysExit.Key = "xxxxxx|A|SA|EXIT|YYYYYYYYYY|YYYY|"
            'v_mnuSysExit.ItemShortcut = New BarShortcut(GetShortcut("CtrlX"))
            'v_mnuSysExit.ImageIndex = 4
            'v_mnuSysExit.Alignment = BarItemLinkAlignment.Right
            'v_mnuSystem.AddItem(v_mnuSysExit)
            'AddHandler v_mnuSysExit.ItemClick, AddressOf Me.mnuSysExit_Click

        Else
            'them menu loguot
            Dim v_mnuLogin As New BarSubItemEx(barManager, "Log in")
            'Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
            v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
            v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
            v_mnuLogin.ImageIndex = 4
            v_mnuLogin.Alignment = BarItemLinkAlignment.Right
            v_mnuSystem.AddItem(v_mnuLogin)
            AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick

            'TanPN 21/07/2020 them menu thoat chuong trinh
            Dim v_mnuSysExit As New BarSubItemEx(barManager, "Exit")
            v_mnuSysExit.Key = "xxxxxx|A|SA|EXIT|YYYYYYYYYY|YYYY|"
            v_mnuSysExit.ItemShortcut = New BarShortcut(GetShortcut("CtrlX"))
            v_mnuSysExit.ImageIndex = 4
            v_mnuSysExit.Alignment = BarItemLinkAlignment.Right
            v_mnuSystem.AddItem(v_mnuSysExit)
            AddHandler v_mnuSysExit.ItemClick, AddressOf Me.mnuSysExit_Click
        End If

    End Sub

    Private Delegate Sub SetLogOutSessionDelegate()
    Private Sub SetLogOutSession()
        If Me.InvokeRequired Then
            Me.Invoke(New SetLogOutSessionDelegate(AddressOf SetLogOutSession))
        Else
            ChangeOnlineStatus(False)

            'Invisible TLLOG search & transaction code menu
            ucSearchTLLOG.Visible = False
            tbtTransaction.Visible = False
            hMenuFunction.Clear()
            m_blnAllowBrokerDesk = False
            m_blnAllowTeleOrder = False
            m_blnAllowCreateDeal = False
            m_blnAllowForceSell = False
            '  thrCheckSession.Suspend()

        End If
    End Sub
    Private Sub ServerReceivedEvent(ByVal sender As Object, ByVal e As ReceivePhoneNumberEventArgs)
        Dim v_strPhoneCalllisteningVT, v_strPhoneCalllistening As String
        v_strPhoneCalllistening = ConfigurationManager.AppSettings("PhoneCalllistening")
        If v_strPhoneCalllistening = "Y" Then
            ShowMainScreen(e.Message.Substring(0, e.Message.Length - 5))
        End If
    End Sub
    Public Sub MultiThreadingVT()
        Dim isstreamVT As Boolean
        isstreamVT = False
        While istcplistener
            Dim client As New TcpClient
            Try
                client = serverVT.AcceptTcpClient
                'Receive msg'
                streamVT = client.GetStream()
                isstreamVT = True
                Dim r_byt(client.ReceiveBufferSize) As Byte
                streamVT.Read(r_byt, 0, client.ReceiveBufferSize)
                Dim str As String = Encoding.ASCII.GetString(r_byt)
                ShowMainScreen(str)
            Catch ex As Exception
            Finally
                If isstreamVT Then
                    streamVT.Close()
                End If
                client.Close()
            End Try
        End While
    End Sub


    Private Sub ShowMainScreen(ByVal phoneNumber As String)
        'Dim m_frmTele As New frmTeleInq(m_BusLayer.AppLanguage)
        'frm.txtMOBILE.Text = phoneNumber

        Dim showMSC As New ShowMainScreenCallBack(AddressOf ShowMainScreen)
        If phoneNumber Is Nothing Then
            Return
        End If

        Me.Invoke(showMSC, New Object() {phoneNumber})


    End Sub
#End Region

    Private ucSearchTLLOG As XtraSearch

#Region " Các sự kiện mở và đóng form chính "
    Private Sub frmMDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            SplashScreenManager.ShowForm(GetType(WaitForm1))
            AutoUpdate()
            InitDesignSearch()
            OnMDILoad()
            AddSearchToTabControl()


            'Init TabControlMudule - tiennv
            xtraTabControlModule.Visible = True
            DelegateUtil.DlgModuleAction = AddressOf ReloadTabModuleAction

            InitFontSize()

            'Luc nay la da dang nhap thanh cong
            'Bat dau dem thoi gian con lai co the connect voi HOST
            Dim v_ws As New BDSDeliveryManagement
            Dim response = String.Empty
            v_ws.GetSecondsLimitAFK(response)
            secondsLimitAFK = Integer.Parse(response)
            remainingConnectionTimeToHost = secondsLimitAFK

            tmrAFK.Start()
        Catch ex As Exception
            'LogError.Write("frmMDIMain_Load.:", LogEntryType.Fatal, ex)
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
        Finally
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Public Sub InitFontSize()
        Dim fz As Double = FontSize.FontSize825
        'tiennv
        Dim fontSizeDefault As String = RegistryUtil.GetKey(RegistryUtil.FONT_SIZE)
        If (Not String.IsNullOrEmpty(fontSizeDefault)) Then
            fz = Double.Parse(fontSizeDefault)
        End If

        ChangeFontSize(fz)

        CreateFontSize(FontSize.FontSize825)
        CreateFontSize(FontSize.FontSize875)
        CreateFontSize(FontSize.FontSize925)
        CreateFontSize(FontSize.FontSize975)
        CreateFontSize(FontSize.FontSize1025)
        CreateFontSize(FontSize.FontSize1075)
        CreateFontSize(FontSize.FontSize1125)
        CreateFontSize(FontSize.FontSize1175)
        CreateFontSize(FontSize.FontSize1225)
        CreateFontSize(FontSize.FontSize1275)
    End Sub
    Public Sub InitNotify(ByVal state As Object)

        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            v_strCmdSQL = "select * from vw_alert_for_admin"

            v_strObjMsg = BuildXMLObjMsg(, , m_BusLayer.CurrentTellerProfile.BranchId, m_BusLayer.CurrentTellerProfile.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strValue, v_strDESC, v_FILTERCOL, v_FILTERVAL, v_strAUTOID, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer

            btnNotify.ClearLinks()
            If v_nodeList.Count > 0 Then
                btnNotify.Visibility = BarItemVisibility.Always
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "AUTOID"
                                    v_strAUTOID = Trim(v_strValue)
                                Case "DESCSCRIPTION"
                                    v_strDESC = Trim(v_strValue)
                                Case "FILTERCOL"
                                    v_FILTERCOL = Trim(v_strValue)
                                Case "FILTERVAL"
                                    v_FILTERVAL = Trim(v_strValue)
                            End Select

                        End With
                    Next
                    Invoke(Sub(autoid As String, desc As String)
                               Dim item As BarButtonItem = New BarButtonItem(barManager, desc)
                               item.Tag = autoid
                               If item.Tag.ToString.Length < 10 Then
                                   item.Description = v_FILTERCOL
                                   item.Name = v_FILTERVAL
                               End If
                               AddHandler item.ItemClick, AddressOf Notify_ItemClick
                               btnNotify.AddItem(item)
                               btnNotify.Caption = btnNotify.ItemLinks.Count
                           End Sub, v_strAUTOID, v_strDESC)
                Next
            Else
                btnNotify.Visibility = BarItemVisibility.Never
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CreateFontSize(ByVal fz As Double)
        Dim item As BarButtonItem = New BarButtonItem(barManager, (fz / 100).ToString())
        item.Tag = fz
        AddHandler item.ItemClick, AddressOf FontSize_ItemClick
        btnChooseFontSize.AddItem(item)
    End Sub

    Public Sub CreateNotify(ByVal autoid As Double, ByVal desc As String)
        Dim item As BarButtonItem = New BarButtonItem(barManager, desc)
        item.Tag = autoid
        btnNotify.AddItem(item)
    End Sub

    Private Sub FontSize_ItemClick(sender As Object, e As ItemClickEventArgs)
        Dim fz As Double = FontSize.FontSize825
        If (e.Item.Tag IsNot Nothing) Then
            fz = e.Item.Tag
        End If

        ChangeFontSize(fz)
    End Sub

    Public Sub ChangeFontSize(ByVal fz As Double)

        btnChooseFontSize.Caption = (fz / 100).ToString()

        'Doi voi control su dung Devexpress
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = New System.Drawing.Font(DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont.Name, fz / 100)
        'XtraBar khong thuoc XtraEditor
        'Menu

        Dim itemXtraBars = barMainMenu.ItemLinks
        If (itemXtraBars IsNot Nothing) Then
            For Each itemLink As BarItemLink In itemXtraBars
                SetFontSizeMenu(itemLink, fz)
            Next
        End If

        '
        'Doi voi control binh thuong
        'Dim controls = FormControlUtil.GetAllControl(Me)
        'For Each ctrl In controls
        'If TypeOf (ctrl) Is Label Then
        'CType(ctrl, Label).Font = New Font(Control.DefaultFont, fz / 100)
        'End If
        '...
        'Next

        'Doi voi Xceed
        Dim itemXceeds = stbMain.Items
        If (itemXceeds IsNot Nothing) Then
            For Each item In itemXceeds
                If TypeOf (item) Is TextBoxTool Then
                    CType(item, TextBoxTool).Font = New Font(CType(item, TextBoxTool).Font.FontFamily, fz / 100)
                End If
            Next
        End If

        'Set registry
        RegistryUtil.SetKey(RegistryUtil.FONT_SIZE, fz.ToString())
    End Sub

    'tiennv
    'Set size menu
    Public Sub SetFontSizeMenu(ByRef barmenuLink As BarItemLink, ByVal fz As Double)
        Dim item = barmenuLink.Item
        If (TypeOf (item) Is BarSubItemEx) Then
            Dim barSubItemEx As BarSubItemEx = CType(item, BarSubItemEx)
            barSubItemEx.ItemAppearance.Normal.Font = New System.Drawing.Font(barSubItemEx.ItemAppearance.Normal.Font.FontFamily, fz / 100)
            barSubItemEx.ItemAppearance.Normal.Options.UseFont = True
            If (barSubItemEx.ItemLinks IsNot Nothing) Then
                For Each itemLink As BarItemLink In barSubItemEx.ItemLinks
                    SetFontSizeMenu(itemLink, fz)
                Next
            End If
        ElseIf (TypeOf (item) Is BarButtonItemEx) Then
            Dim barButtonItemEx As BarButtonItemEx = CType(item, BarButtonItemEx)
            barButtonItemEx.ItemAppearance.Normal.Font = New System.Drawing.Font(barButtonItemEx.ItemAppearance.Normal.Font.FontFamily, fz / 100)
            barButtonItemEx.ItemAppearance.Normal.Options.UseFont = True
        End If
    End Sub


    Sub InitDesignSearch()
        xtraTabControlModule.Visible = False
        Me.ucSearchTLLOG = New XtraSearch()
        Me.ucSearchTLLOG.AccessArea = ""
        Me.ucSearchTLLOG.BranchId = Nothing
        Me.ucSearchTLLOG.BusDate = Nothing
        Me.ucSearchTLLOG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucSearchTLLOG.FormCaption = Nothing
        Me.ucSearchTLLOG.INTERVAL = Nothing
        Me.ucSearchTLLOG.IsLocalSearch = Nothing
        Me.ucSearchTLLOG.KeyColumn = Nothing
        Me.ucSearchTLLOG.KeyFieldType = Nothing
        Me.ucSearchTLLOG.Location = New System.Drawing.Point(0, 35)
        Me.ucSearchTLLOG.ModuleCode = Nothing
        Me.ucSearchTLLOG.Name = "ucSearchTLLOG"
        Me.ucSearchTLLOG.SearchOnInit = False
        Me.ucSearchTLLOG.Size = New System.Drawing.Size(1072, 434)
        Me.ucSearchTLLOG.TabIndex = 26
        Me.ucSearchTLLOG.TableName = Nothing
        Me.ucSearchTLLOG.TellerGroup = Nothing
        Me.ucSearchTLLOG.TellerId = Nothing
        Me.ucSearchTLLOG.TellerName = Nothing
        Me.ucSearchTLLOG.TellerType = Nothing
        Me.ucSearchTLLOG.UserLanguage = Nothing
    End Sub

    Sub AddSearchToTabControl()
        xtraTabControlModule.TabPages.Clear()
        Dim page As XtraTabPage = New XtraTabPage()
        page.Name = Me.ucSearchTLLOG.Name
        page.Text = m_ResourceManager.GetString("XTRA_TAB_PAGE__HOME")
        page.ShowCloseButton = DefaultBoolean.False
        page.Controls.Add(Me.ucSearchTLLOG)
        xtraTabControlModule.TabPages.Add(page)
    End Sub

#Region "TabModule - tiennv"
    Private Sub xtraTabControlModule_CloseButtonClick(sender As Object, e As EventArgs) Handles xtraTabControlModule.CloseButtonClick
        Dim xtraTabControl As XtraTabControl = CType(sender, XtraTabControl)
        If IsNothing(xtraTabControl) Then
            Return
        End If

        Dim closePageEvent As DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs = CType(e, DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)
        If closePageEvent Is Nothing Then
            Return
        End If

        Dim page As XtraTabPage = CType(closePageEvent.Page, XtraTabPage)
        If page IsNot Nothing And xtraTabControl.Contains(page) Then
            xtraTabControl.TabPages.Remove(page)
            If xtraTabControl.TabPages.Count > 1 Then
                xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1
            End If
            SetHeaderAutoFill()
        End If
    End Sub

    Public Sub ReloadTabModuleAction(ByVal action As DelegateUtil.EACTION, ByVal page As XtraTabPage)
        If action = DelegateUtil.EACTION.ADD Then
            For Each p As XtraTabPage In xtraTabControlModule.TabPages
                If (p.Name = page.Name) Then
                    xtraTabControlModule.SelectedTabPage = p
                    xtraTabControlModule.Update()
                    Return
                End If
            Next
            xtraTabControlModule.TabPages.Add(page)
            xtraTabControlModule.SelectedTabPage = page
            xtraTabControlModule.Visible = xtraTabControlModule.TabPages.Count > 0
            xtraTabControlModule.Update()
        ElseIf action = DelegateUtil.EACTION.CLOSE Then
            xtraTabControlModule.TabPages.Remove(page)
            xtraTabControlModule.Visible = Not (xtraTabControlModule.TabPages.Count = 0)
            xtraTabControlModule.Update()
        ElseIf action = DelegateUtil.EACTION.CLEAR Then
            xtraTabControlModule.TabPages.Clear()
            xtraTabControlModule.Update()
        ElseIf action = DelegateUtil.EACTION.SELECT_PAGE_EXIST Then
            xtraTabControlModule.TabPages.Remove(page)
            If xtraTabControlModule.TabPages.Count > 0 Then
                For Each p As XtraTabPage In xtraTabControlModule.TabPages
                    If (p.Text = page.Text) Then
                        xtraTabControlModule.SelectedTabPage = p
                        xtraTabControlModule.Update()
                        Return
                    End If
                Next
            End If
        ElseIf action = DelegateUtil.EACTION.CLOSE_ALL_BUT_THIS Then
            'If xtraTabControlModule.TabPages.Count > 0 Then
            '    For Each p As XtraTabPage In xtraTabControlModule.TabPages
            '        If (p.Text <> page.Text) Then
            '            p.PageVisible = False
            '        End If
            '    Next
            'End If
            xtraTabControlModule.TabPages.Clear()
            xtraTabControlModule.TabPages.Add(page)
            xtraTabControlModule.SelectedTabPage = page
            xtraTabControlModule.Visible = xtraTabControlModule.TabPages.Count > 0
            'xtraTabControlModule.Update()
        End If
        SetHeaderAutoFill()
    End Sub
    ''' <summary>
    ''' Ham nay de set autofill hay khong
    ''' Khi so tab nho hon hoac bang 6 thi Dock cua header khac fill
    ''' Nguoc lai la fill
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetHeaderAutoFill()
        If xtraTabControlModule.TabPages.Count > 6 Then
            xtraTabControlModule.HeaderAutoFill = DefaultBoolean.True
        Else
            xtraTabControlModule.HeaderAutoFill = DefaultBoolean.False
        End If
    End Sub
#End Region

    Private Sub frmMDIMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            SaveRegistrySettings()
            'SaveRegistryGridViewSettings()
            istcplistener = False
            If v_strTELEORDER = "Y" Then
                serverVT.Stop()
            End If
            tmrMain.Enabled = False
            tmrCallCenter.Enabled = False
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
        End Try
    End Sub
#End Region

#Region " Helper methods "
    Private Sub SaveRegistrySettings()
        Try
            Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey)

            If MyBase.WindowState <> FormWindowState.Minimized Then
                v_regKey.SetValue("WindowState", Convert.ToInt32(MyBase.WindowState))
                v_regKey.SetValue("Height", MyBase.Height)
                v_regKey.SetValue("Width", MyBase.Width)
            End If

            v_regKey.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'trung.luu: 20-11-2020 luu registry grid man hinh chinh
    Private Sub SaveRegistryGridViewSettings()
        Try
            Dim v_regKey As String = "DevExpress\XtraGrid\Layouts\MainLayout\SearchGridView||" & m_BusLayer.CurrentTellerProfile.TellerId
            ucSearchTLLOG.SearchGridControl.MainView.SaveLayoutToRegistry(v_regKey)

            'ucSearchTLLOG.SearchGridControl.MainView.SaveLayoutToXml("E:\SHB\CB\cb\@VSTP\Deployment\Client\trung\XtraGrid_SaveLayoutToXML.xml")
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadRegistryGridViewSettings()
        Dim v_str_regKey As String = "DevExpress\XtraGrid\Layouts\MainLayout\SearchGridView||" & m_BusLayer.CurrentTellerProfile.TellerId
        Dim v_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(v_str_regKey)
        If v_regKey Is Nothing Then Return
        ucSearchTLLOG.SearchGridControl.MainView.RestoreLayoutFromRegistry(v_str_regKey)

    End Sub
    'trung.luu: 20-11-2020 luu registry grid man hinh chinh

    Private Sub LoadRegistrySettings()
        Dim v_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(gc_RegistryKey)
        If v_regKey Is Nothing Then Return

        'Get some ui settings
        If Not v_regKey.GetValue("WindowState") Is Nothing Then
            MyBase.WindowState = CType(v_regKey.GetValue("WindowState"), FormWindowState)
        End If
        If Not v_regKey.GetValue("Height") Is Nothing Then
            MyBase.Height = CType(v_regKey.GetValue("Height"), Integer)
        End If
        If Not v_regKey.GetValue("Width") Is Nothing Then
            MyBase.Width = CType(v_regKey.GetValue("Width"), Integer)
        End If

        'Close the key
        v_regKey.Close()
    End Sub

    Private Sub DisplayReconcileFunction(Optional ByVal pv_ModuleCode As String = "")
        'Liệt kê danh sách các View tra cứu được phép
        Dim frm As New AppCore.frmLookUp(m_BusLayer.AppLanguage)
        Dim v_intPos As Integer, ctl As Control, v_strRETURNDATA, v_strObjName, v_strModCode As String
        frm.SQLCMD = "SELECT SQLCHECK VALUE, MODCODE || '.' || AUTOID VALUECD,SEARCHTITLE DISPLAY,EN_SEARCHTITLE EN_DISPLAY, MODCODE DESCRIPTION ,MODCODE,SQLCHECK FROM RECONCILE"
        frm.AcceptedClose = False
        frm.isReconcile = True
        frm.ShowDialog()
    End Sub

    Private Sub DisplayGeneralView(Optional ByVal pv_ModuleCode As String = "", Optional ByVal pv_MenuTag As String = "")
        'Liệt kê danh sách các View tra cứu được phép
        'Dim frm As New AppCore.frmLookUp(m_BusLayer.AppLanguage)
        Dim frm As New frmLookUp_Tab(m_BusLayer.AppLanguage)
        Dim v_intPos As Integer, ctl As Control, v_strRETURNDATA, v_strObjName, v_strModCode, v_strCMDTYPE, v_strSTOREDNAME As String
        Dim v_strReportList, strFrmRETURNDATA As String
        v_strReportList = ""
        If Not hRptMaster Is Nothing Then
            For i As Integer = 0 To hRptMaster.Count - 1
                If (hRptMaster.Keys(i).ToString.Trim.StartsWith("R") = False) Then
                    v_strReportList = v_strReportList & hRptMaster.Keys(i).ToString & "|"
                End If

            Next
        End If
        strFrmRETURNDATA = ""
        If pv_MenuTag.Length = 0 Then

            If m_BusLayer.AppLanguage = "VN" Then

                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.DESCRIPTION DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') AND DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"
            Else
                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.en_description DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') AND DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"
            End If
            ''TanPN add 25/09/2020 
            frm.MenuTag = pv_MenuTag
            frm.AcceptedClose = False
            frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
            frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
            frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
            'frm.SessionID = m_BusLayer.CurrentTellerProfile.SessionID
            frm.CELLSDEFINETable = mv_strCELLSDEFINETable
            frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
            frm.SymbolList = mv_strSYMBOLLIST
            frm.SymbolTable = mv_strSymbolTable
            frm.IpAddress = m_BusLayer.AppIpAddress
            frm.WsName = m_BusLayer.AppWsName
            frm.TableName = pv_ModuleCode
            frm.CMDID = pv_ModuleCode
            ''TanPN end

            frm.AcceptedClose = False
            frm.Show()
            'If Not frm.RETURNDATA Is Nothing Then
            '    strFrmRETURNDATA = frm.RETURNDATA
            '    v_intPos = InStr(strFrmRETURNDATA, vbTab)
            'End If
        End If
        If strFrmRETURNDATA.Length <> 0 OrElse pv_MenuTag.Length <> 0 Then
            If v_intPos > 0 OrElse pv_MenuTag.Length <> 0 Then
                If pv_MenuTag.Length <> 0 Then
                    v_strRETURNDATA = pv_MenuTag
                Else
                    v_strRETURNDATA = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                End If
                Dim v_arrRETURNDATA As String()
                v_arrRETURNDATA = v_strRETURNDATA.Split(".")
                v_strModCode = v_arrRETURNDATA(0)
                v_strObjName = v_arrRETURNDATA(1)
                v_strCMDTYPE = v_arrRETURNDATA(2)
                v_strSTOREDNAME = v_arrRETURNDATA(3)

                Dim frmSearch As New frmSearchMaster(m_BusLayer.AppLanguage)
                frmSearch.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                frmSearch.TableName = v_strObjName
                frmSearch.CMDMenu = v_strObjName
                frmSearch.ModuleCode = v_strModCode
                frmSearch.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                frmSearch.CMDMenu = v_strObjName
                frmSearch.COUNTRYTable = mv_strCOUNTRYTable
                frmSearch.CELLSDEFINETable = mv_strCELLSDEFINETable
                frmSearch.PROVINCETable = mv_strPROVINCETable
                frmSearch.mv_strCMDID = v_strObjName
                'frmSearch.SessionID = m_BusLayer.CurrentTellerProfile.SessionID
                'frmSearch.MacAddress = m_BusLayer.CurrentTellerProfile.MacAddress
                frmSearch.AuthCode = "NYNNYYYNNY" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                frmSearch.CMDTYPE = v_strCMDTYPE
                frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                frmSearch.SearchOnInit = False
                frmSearch.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                frmSearch.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                frmSearch.IpAddress = m_BusLayer.AppIpAddress
                frmSearch.WsName = m_BusLayer.AppWsName
                frmSearch.SymbolList = mv_strSYMBOLLIST
                frmSearch.SymbolTable = mv_strSymbolTable
                frmSearch.Show()
                'Trung.luu: 04-04-2020 gọi generalview rồi thì không popup lại form lookup nữa 
                'DisplayGeneralView(pv_ModuleCode)
            End If

        End If

    End Sub


    Private Sub DisplayGeneralViewfilter(Optional ByVal pv_ModuleCode As String = "", Optional ByVal pv_MenuTag As String = "")
        'Liệt kê danh sách các View tra cứu được phép
        Dim frm As New AppCore.frmLookUp(m_BusLayer.AppLanguage)
        Dim v_intPos As Integer, ctl As Control, v_strRETURNDATA, v_strObjName, v_strModCode, v_strCMDTYPE, v_strSTOREDNAME As String
        Dim v_strReportList, strFrmRETURNDATA As String
        v_strReportList = ""
        If Not hRptMaster Is Nothing Then
            For i As Integer = 0 To hRptMaster.Count - 1
                If (hRptMaster.Keys(i).ToString.Trim.StartsWith("R") = False) Then
                    v_strReportList = v_strReportList & hRptMaster.Keys(i).ToString & "|"
                End If

            Next
        End If
        strFrmRETURNDATA = ""
        If pv_MenuTag.Length = 0 Then

            If m_BusLayer.AppLanguage = "VN" Then

                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.DESCRIPTION DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') AND DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"
            Else
                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.en_description DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') AND DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"
            End If


            frm.AcceptedClose = False
            frm.ShowDialog()
            If Not frm.RETURNDATA Is Nothing Then
                strFrmRETURNDATA = frm.RETURNDATA
                v_intPos = InStr(strFrmRETURNDATA, vbTab)
            End If

        Else

            If m_BusLayer.AppLanguage = "VN" Then

                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.DESCRIPTION DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') and  INSTR( DT.CMDID,'" & pv_MenuTag & "' ) >  0  AND  DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"
            Else
                frm.SQLCMD = "SELECT DT.MODCODE || '.' || DT.RPTID || '.' || DT.CMDTYPE || '.' || DT.STOREDNAME VALUE, DT.MODCODE || '.' || DT.RPTID VALUECD, " & ControlChars.CrLf _
                            & "     DT.en_description DISPLAY, DT.en_description EN_DISPLAY, DT.MODCODE DESCRIPTION, DT.MODCODE " & ControlChars.CrLf _
                            & " FROM RPTMASTER DT " & ControlChars.CrLf _
                            & " WHERE DT.CMDTYPE in('V','D','L') and  INSTR( DT.CMDID,'" & pv_MenuTag & "' ) >  0  AND  DT.visible <> 'N' AND DT.MODCODE LIKE " & "'%" & pv_ModuleCode & "%'" & "  AND INSTR('" & v_strReportList & "','V' || RPTID || '|')>0  " & ControlChars.CrLf _
                            & " ORDER BY DT.MODCODE, VALUE"


            End If


            frm.AcceptedClose = False
            frm.ShowDialog()
            If Not frm.RETURNDATA Is Nothing Then
                strFrmRETURNDATA = frm.RETURNDATA
                v_intPos = InStr(strFrmRETURNDATA, vbTab)
            End If
        End If
        If strFrmRETURNDATA.Length <> 0 Then
            If v_intPos > 0 OrElse pv_MenuTag.Length <> 0 Then

                v_strRETURNDATA = Mid(frm.RETURNDATA, 1, v_intPos - 1)

                Dim v_arrRETURNDATA As String()
                v_arrRETURNDATA = v_strRETURNDATA.Split(".")
                v_strModCode = v_arrRETURNDATA(0)
                v_strObjName = v_arrRETURNDATA(1)
                v_strCMDTYPE = v_arrRETURNDATA(2)
                v_strSTOREDNAME = v_arrRETURNDATA(3)


                Dim frmSearch As New frmSearchMaster(m_BusLayer.AppLanguage)
                frmSearch.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                frmSearch.TableName = v_strObjName
                frmSearch.mv_strCMDID = v_strObjName
                frmSearch.ModuleCode = v_strModCode
                frmSearch.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                frmSearch.AuthCode = "NYNNYYYNNY" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                frmSearch.CMDTYPE = v_strCMDTYPE
                frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                frmSearch.SearchOnInit = False
                frmSearch.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                frmSearch.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                frmSearch.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                frmSearch.IpAddress = m_BusLayer.AppIpAddress
                frmSearch.WsName = m_BusLayer.AppWsName
                frmSearch.SymbolList = mv_strSYMBOLLIST
                frmSearch.SymbolTable = mv_strSymbolTable
                frmSearch.CELLSDEFINETable = mv_strCELLSDEFINETable
                frmSearch.Show()
                DisplayGeneralViewfilter(pv_ModuleCode, pv_MenuTag)
            End If
        End If


    End Sub

    Private Function DisplayLoginForm() As DialogResult
        'Trung.luu: 29-03-2020: goi form login moi
        Dim frm As New frmXtraLogin(m_BusLayer)
        Dim frmResult As DialogResult = frm.ShowDialog(Me)
        Me.Refresh()

        LogError.Write("DisplayLoginForm begin GetTellerRight: " & Now(), EventLogEntryType.Information)
        m_BusLayer.CurrentTellerProfile.TellerRight = GetTellerRight()
        LogError.Write("DisplayLoginForm end GetTellerRight: " & Now(), EventLogEntryType.Information)

        LogError.Write("DisplayLoginForm begin GetTellerRight: " & Now(), EventLogEntryType.Information)
        m_BusLayer.CurrentTellerProfile.TellerGroupCareBy = GetGroupCareBy()
        LogError.Write("DisplayLoginForm end GetGroupCareBy: " & Now(), EventLogEntryType.Information)

        LogError.Write("DisplayLoginForm begin GetTellerRight: " & Now(), EventLogEntryType.Information)
        m_BusLayer.CurrentTellerProfile.TellerGroup = GetTellerGroup()
        LogError.Write("DisplayLoginForm end GetTellerGroup: " & Now(), EventLogEntryType.Information)

        Return frmResult
    End Function

    Private Sub UpdateLastVersion()

        'Me.tmrMain.Enabled = True
        'Dim str As String
        'str = m_BusLayer.CurrentTellerProfile.Interval

        'sbrPanelBranch.Text = m_BusLayer.CurrentTellerProfile.BranchId _
        '    & IIf(m_BusLayer.CurrentTellerProfile.BranchName <> String.Empty, " - " & m_BusLayer.CurrentTellerProfile.BranchName, String.Empty)
        'sbrPanelStatus.Text = m_ResourceManager.GetString("STATUS_WORKING")
        'sbrPanelUser.Text = m_BusLayer.CurrentTellerProfile.TellerName
        'If m_BusLayer.CurrentTellerProfile.Description <> String.Empty Then
        '    sbrPanelUser.Text &= " (" & m_BusLayer.CurrentTellerProfile.Description & ")"
        'End If

        ''TruongLD modify when convert
        'sbrPanelDateTime.Text = m_BusLayer.CurrentTellerProfile.BusDate & " - " _
        '    & Now.ToString("HH:mm:ss")

        'mnuSysLogin.Visible = False
        'mnuSysLogin.Enabled = False
        'mnuSysLogout.Visible = True
        'mnuSysLogout.Enabled = True
        'mnuSysChangePassword.Visible = True
        'mnuSysChangePassword.Enabled = True
        'mnuSysSep02.Visible = True

        'update new version
        Dim v_client_check As New clsClient
        Dim v_strSQL As String
        v_strSQL = " SELECT VARVALUE AS VERSION FROM  SYSVAR WHERE VARNAME='VERSION'"

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String

        Dim v_Version, v_NewVersion As String
        Dim v_autoupdate As String

        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "VERSION"
                            v_Version = v_strValue
                    End Select
                End With
            Next
        Next

        MessageBox.Show("Chương trình sẽ cập nhật bảng mới,nhấn OK tiếp tục.", "Update", MessageBoxButtons.OK)

        v_client_check.GetNewVersion("VSTP", "VSTP.exe", gc_RegistryKey, v_Version, System.Configuration.ConfigurationSettings.AppSettings("URLforDownload"), v_Version, 1)

        ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId

    End Sub

    Private Sub Logout()
        ChangeOnlineStatus(False)
        'SaveRegistryGridViewSettings()
        'Invisible TLLOG search & transaction code menu
        ucSearchTLLOG.Visible = False
        tbtTransaction.Visible = False
        hMenuFunction.Clear()
        m_blnAllowBrokerDesk = False
        m_blnAllowTeleOrder = False
        m_blnAllowCreateDeal = False
        m_blnAllowForceSell = False

        barManager.MainMenu.ClearLinks()
        LoadBarSystemMenu("2")
        'Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
        ''Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
        'v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
        'v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
        'v_mnuLogin.ImageIndex = 4
        'v_mnuLogin.Alignment = BarItemLinkAlignment.Right
        'barMainMenu.AddItem(v_mnuLogin)
        'AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick

        If DelegateUtil.DlgModuleAction IsNot Nothing Then
            DelegateUtil.DlgModuleAction(DelegateUtil.EACTION.CLEAR, Nothing)
        End If

        'Tat bo dem thoi gian con lai connect voi Host
        tmrAFK.Enabled = False
    End Sub

    Private Sub ChangeOnlineStatus(ByVal newState As Boolean)
        m_blnIsOnline = newState
        Dim v_lngErr As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource, v_strErrorMessage As String
        If m_blnIsOnline Then
            Me.tmrMain.Enabled = True
            Me.tmrCallCenter.Enabled = True
            Dim str As String
            str = m_BusLayer.CurrentTellerProfile.Interval

            sbrPanelBranch.Caption = m_BusLayer.CurrentTellerProfile.BranchId _
                & IIf(m_BusLayer.CurrentTellerProfile.BranchName <> String.Empty, " - " & m_BusLayer.CurrentTellerProfile.BranchName, String.Empty)
            sbrPanelStatus.Caption = m_ResourceManager.GetString("STATUS_WORKING")
            sbrPanelUser.Caption = m_BusLayer.CurrentTellerProfile.TellerName
            If m_BusLayer.CurrentTellerProfile.Description <> String.Empty Then
                sbrPanelUser.Caption &= " (" & m_BusLayer.CurrentTellerProfile.Description & ")"
            End If

            'TruongLD comment when convert
            'sbrPanelDateTime.Text = m_BusLayer.CurrentTellerProfile.BusDate & " - " _
            '    & Format$(Now.Hour, "00") & ":" & Format$(Now.Minute, "00") & ":" & Format$(Now.Second, "00")

            'TruongLD modify when convert
            sbrPanelDateTime.Caption = m_BusLayer.CurrentTellerProfile.BusDate & " - " _
                & Now.ToString("HH:mm:ss")

            _tsmiSystemLogin.Visible = False
            _tsmiSystemLogin.Enabled = False

            _tsmiSystemLogout.Visible = True
            _tsmiSystemLogout.Enabled = True

            _tsmiSystemChangePassword.Visible = True
            _tsmiSystemChangePassword.Enabled = True

            'mnuSysSep02.Visible = True

            'update new version
            Dim v_client_check As New clsClient
            Dim v_strSQL As String
            v_strSQL = " SELECT MAX(NVL(ACTUALVERSION,'')) AS ACTUALVERSION, MAX(NVL(AUTOUPDATE,'')) AS AUTOUPDATE, MAX(NVL(REPORTVERSION,'')) AS REPORTVERSION" &
                       " FROM ( " &
                       " SELECT VARVALUE AS ACTUALVERSION, '' AS AUTOUPDATE, '' REPORTVERSION FROM  SYSVAR WHERE VARNAME='ACTUALVERSION'" &
                       " UNION ALL" &
                       " SELECT '' AS ACTUALVERSION, VARVALUE AUTOUPDATE, '' REPORTVERSION  FROM  SYSVAR WHERE VARNAME='AUTOUPDATE'" &
                       " UNION ALL" &
                       " SELECT '' AS ACTUALVERSION, '' AUTOUPDATE, VARVALUE REPORTVERSION  FROM  SYSVAR WHERE VARNAME='REPORTVERSION')"

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'If mv_SignMode = "Y" Then
            'v_ws.CAToken = m_CurrCAToken
            'End If

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String

            Dim v_Version, v_AppCoreVersion, v_CommonLibraryVersion, v_NewVersion, v_ReportVersion, v_strAutoUpdate As String
            Dim v_OldReportVersion As String
            Dim v_autoupdate As String
            v_OldReportVersion = "reports.0.0.0.0000.0000"
            v_ReportVersion = "reports.0.0.0.0000.0000"
            Dim v_strObjMsg As String = ""
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL, , , , , , , , , , , , m_BusLayer.CurrentTellerProfile.TellerName)
            v_lngErr = v_ws.Message(v_strObjMsg)


            If v_lngErr <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErr, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                mv_isValidToken = False
                Me.Close()
            End If
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ACTUALVERSION"
                                v_NewVersion = v_strValue
                                'Case "REPORTVERSION"
                                '    v_ReportVersion = v_strValue
                            Case "AUTOUPDATE"
                                v_strAutoUpdate = v_strValue
                        End Select
                    End With
                Next
            Next

#If DEBUG Then
            v_strAutoUpdate = "N"
#End If

            Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
            Dim AppCoreBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("AppCore.dll")
            Dim CommonLibraryBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("CommonLibrary.dll")

            If Not myBuildInfo Is Nothing Then
                v_Version = myBuildInfo.FileVersion.Replace(".", "")
            End If
            If Not AppCoreBuildInfo Is Nothing Then
                v_AppCoreVersion = AppCoreBuildInfo.FileVersion.Replace(".", "")
            End If
            If Not CommonLibraryBuildInfo Is Nothing Then
                v_CommonLibraryVersion = CommonLibraryBuildInfo.FileVersion.Replace(".", "")
            End If
            Dim v_strAppDir As String
            'Dim v_strAppDir As String = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"

            'Cap nhat phien ban moi
            If v_strAutoUpdate = "Y" Then   'Nếu AutoUpdate = "Y" thi xet tiếp version. Nếu là "N" hoặc NULL thì thôi.
                ' lay ra version cua cac file DLL
                v_strObjMsg = ""
                v_ws.GetVersion(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ACTUALVERSION"
                                    v_NewVersion = v_strValue
                            End Select
                        End With
                    Next
                Next
                ' cap nhat file DLL
                If v_NewVersion <> v_Version OrElse v_NewVersion <> v_AppCoreVersion OrElse v_NewVersion <> v_CommonLibraryVersion Then
                    MessageBox.Show("Chương trình tự động cập nhật bản mới" & ControlChars.CrLf &
                                    "Phiên bản hiện tại: " & v_Version & ControlChars.CrLf &
                                    "Phiên bản mới nhất: " & v_NewVersion & ControlChars.CrLf &
                                    "Nhấn OK tiếp tục", "Update", MessageBoxButtons.OK)
                    v_client_check.GetNewVersion("VSTP", "VSTP.exe", gc_RegistryKey, v_NewVersion, System.Configuration.ConfigurationSettings.AppSettings("URLforDownload"), v_Version, 1)
                End If
                ' lay ra version can update cua file RPT
                v_strSQL = "SELECT REPORTVERSION FROM VERSION ORDER BY REPORTVERSION DESC"
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1

                    With v_nodeList.Item(i).ChildNodes(0)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "REPORTVERSION"
                                v_ReportVersion = v_strValue
                        End Select
                        v_strAppDir = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"
                        If Exists(v_strAppDir) Then
                            v_OldReportVersion = v_ReportVersion
                            Exit For
                        End If
                    End With

                Next
                ' update file RPT
                v_strSQL = "SELECT REPORTVERSION FROM VERSION WHERE REPORTVERSION > '" & v_OldReportVersion & "' ORDER BY REPORTVERSION "
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "REPORTVERSION"
                                    v_ReportVersion = v_strValue
                            End Select
                            v_strAppDir = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"
                            'MessageBox.Show("Chương trình tự động cập nhật báo cáo mới,nhấn OK tiếp tục ", "Update", MessageBoxButtons.OK)
                            MessageBox.Show("Chương trình tự động cập nhật báo cáo mới" & ControlChars.CrLf &
                                    "Phiên bản báo cáo hiện tại: " & v_OldReportVersion & ControlChars.CrLf &
                                    "Phiên bản báo cáo cập nhật : " & v_ReportVersion & ControlChars.CrLf &
                                    "Nhấn OK tiếp tục", "Update", MessageBoxButtons.OK)
                            v_client_check.GetNewVersion("VSTP", "VSTP.exe", gc_RegistryKey, v_ReportVersion, System.Configuration.ConfigurationSettings.AppSettings("URLRptDownload"), v_ReportVersion, 2)
                        End With
                    Next
                Next
            End If

        Else
            Me.tmrMain.Enabled = False
            Me.tmrCallCenter.Enabled = False
            sbrPanelBranch.Caption = String.Empty
            sbrPanelStatus.Caption = String.Empty
            sbrPanelUser.Caption = String.Empty
            sbrPanelDateTime.Caption = String.Empty


            _tsmiSystemLogin.Visible = True
            _tsmiSystemLogin.Enabled = True

            _tsmiSystemLogout.Visible = False
            _tsmiSystemLogout.Enabled = False

            _tsmiSystemChangePassword.Visible = False
            _tsmiSystemChangePassword.Enabled = False

            'mnuSysSep02.Visible = False
        End If
        'ucSearchTLLOG.Visible = False

        ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
        'ucSearchTLLOG.Visible = True
        'tbtTransaction.Visible = False

    End Sub
    Private Sub AutoUpdate()

        Dim v_lngErr As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource, v_strErrorMessage As String



        'mnuSysSep02.Visible = True

        'update new version
        Dim v_client_check As New clsClient
        Dim v_strSQL As String
        v_strSQL = " SELECT MAX(NVL(ACTUALVERSION,'')) AS ACTUALVERSION, MAX(NVL(AUTOUPDATE,'')) AS AUTOUPDATE, MAX(NVL(REPORTVERSION,'')) AS REPORTVERSION" &
                   " FROM ( " &
                   " SELECT VARVALUE AS ACTUALVERSION, '' AS AUTOUPDATE, '' REPORTVERSION FROM  SYSVAR WHERE VARNAME='ACTUALVERSION'" &
                   " UNION ALL" &
                   " SELECT '' AS ACTUALVERSION, VARVALUE AUTOUPDATE, '' REPORTVERSION  FROM  SYSVAR WHERE VARNAME='AUTOUPDATE'" &
                   " UNION ALL" &
                   " SELECT '' AS ACTUALVERSION, '' AUTOUPDATE, VARVALUE REPORTVERSION  FROM  SYSVAR WHERE VARNAME='REPORTVERSION')"

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'If mv_SignMode = "Y" Then
        'v_ws.CAToken = m_CurrCAToken
        'End If

        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String

        Dim v_Version, v_AppCoreVersion, v_CommonLibraryVersion, v_NewVersion, v_ReportVersion, v_strAutoUpdate As String
        Dim v_OldReportVersion As String
        Dim v_autoupdate As String
        v_OldReportVersion = "reports.0.0.0.0000.0000"
        v_ReportVersion = "reports.0.0.0.0000.0000"
        Dim v_strObjMsg As String = ""
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
        'v_ws.Message(v_strObjMsg)
        'Dim v_strObjMsg As String = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL, , , , , , , , , , , , m_BusLayer.CurrentTellerProfile.TellerName)

        'Dim v_strObjMsg As String = BuildXMLObjMsg(, "0001", , "0001", gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL, , , , , , , , , , , , "Admin")
        v_lngErr = v_ws.Message(v_strObjMsg)


        If v_lngErr <> ERR_SYSTEM_OK Then
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErr, v_strErrorMessage)
            Cursor.Current = Cursors.Default
            MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
            mv_isValidToken = False
            Me.Close()
        End If
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTUALVERSION"
                            v_NewVersion = v_strValue
                            'Case "REPORTVERSION"
                            '    v_ReportVersion = v_strValue
                        Case "AUTOUPDATE"
                            v_strAutoUpdate = v_strValue
                    End Select
                End With
            Next
        Next

#If DEBUG Then
        v_strAutoUpdate = "N"
#End If

        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        Dim AppCoreBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("AppCore.dll")
        Dim CommonLibraryBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("CommonLibrary.dll")

        If Not myBuildInfo Is Nothing Then
            v_Version = myBuildInfo.FileVersion.Replace(".", "")
        End If
        If Not AppCoreBuildInfo Is Nothing Then
            v_AppCoreVersion = AppCoreBuildInfo.FileVersion.Replace(".", "")
        End If
        If Not CommonLibraryBuildInfo Is Nothing Then
            v_CommonLibraryVersion = CommonLibraryBuildInfo.FileVersion.Replace(".", "")
        End If
        Dim v_strAppDir As String
        'Dim v_strAppDir As String = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"

        'Cap nhat phien ban moi
        If v_strAutoUpdate = "Y" Then   'Nếu AutoUpdate = "Y" thi xet tiếp version. Nếu là "N" hoặc NULL thì thôi.
            ' lay ra version cua cac file DLL

            v_strObjMsg = ""
            v_ws.GetVersion(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ACTUALVERSION"
                                v_NewVersion = v_strValue
                        End Select
                    End With
                Next
            Next
            ' cap nhat file DLL
            If v_NewVersion <> v_Version OrElse v_NewVersion <> v_AppCoreVersion OrElse v_NewVersion <> v_CommonLibraryVersion Then
                MessageBox.Show("Chương trình tự động cập nhật bản mới" & ControlChars.CrLf &
                                "Phiên bản hiện tại: " & v_Version & ControlChars.CrLf &
                                "Phiên bản mới nhất: " & v_NewVersion & ControlChars.CrLf &
                                "Nhấn OK tiếp tục", "Update", MessageBoxButtons.OK)
                v_client_check.GetNewVersion("VSTP", "VSTP.exe", gc_RegistryKey, v_NewVersion, System.Configuration.ConfigurationSettings.AppSettings("URLforDownload"), v_Version, 1)
            End If
            ' lay ra version can update cua file RPT
            v_strSQL = "SELECT REPORTVERSION FROM VERSION ORDER BY REPORTVERSION DESC"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1

                With v_nodeList.Item(i).ChildNodes(0)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "REPORTVERSION"
                            v_ReportVersion = v_strValue
                    End Select
                    v_strAppDir = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"
                    If Exists(v_strAppDir) Then
                        v_OldReportVersion = v_ReportVersion
                        Exit For
                    End If
                End With

            Next
            ' update file RPT
            v_strSQL = "SELECT REPORTVERSION FROM VERSION WHERE REPORTVERSION > '" & v_OldReportVersion & "' ORDER BY REPORTVERSION "
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "REPORTVERSION"
                                v_ReportVersion = v_strValue
                        End Select
                        v_strAppDir = GetDirectoryName(ExecutablePath) & "\" & v_ReportVersion & ".dat"
                        'MessageBox.Show("Chương trình tự động cập nhật báo cáo mới,nhấn OK tiếp tục ", "Update", MessageBoxButtons.OK)
                        MessageBox.Show("Chương trình tự động cập nhật báo cáo mới" & ControlChars.CrLf &
                                "Phiên bản báo cáo hiện tại: " & v_OldReportVersion & ControlChars.CrLf &
                                "Phiên bản báo cáo cập nhật : " & v_ReportVersion & ControlChars.CrLf &
                                "Nhấn OK tiếp tục", "Update", MessageBoxButtons.OK)
                        v_client_check.GetNewVersion("VSTP", "VSTP.exe", gc_RegistryKey, v_ReportVersion, System.Configuration.ConfigurationSettings.AppSettings("URLRptDownload"), v_ReportVersion, 2)
                    End With
                Next
            Next
        End If



    End Sub
    Private Function AddTreeNode(ByRef pv_nodeParent As Node,
                               ByVal pv_strKey As String,
                               ByVal pv_strName As String,
                               ByVal pv_strLast As String,
                               Optional ByVal pv_intImageIdx As Integer = 0,
                               Optional ByVal pv_strObjName As String = "") As Node
        'Create new node
        Dim v_node As New Node(pv_strName, pv_intImageIdx)

        v_node.Key = pv_strKey
        v_node.ToolTipText = pv_strName
        If pv_strLast = gc_IS_LAST_MENU Then
            Dim v_arrMenuKey() As String
            v_arrMenuKey = pv_strKey.Split("|")
            If v_arrMenuKey.Length <> 3 Then 'Không ph?i là transaction
                v_node.Text = v_arrMenuKey(0) & ": " & pv_strName
            End If
            hMenuFunction.Add(v_arrMenuKey(0), v_arrMenuKey)
            AddHandler v_node.Click, AddressOf Me.Menu_Click
            AddHandler v_node.KeyDown, AddressOf Me.Menu_KeyUp
        Else
            v_node.Text = pv_strName
            v_node.Expanded = False
        End If

        pv_nodeParent.Items.Add(v_node)
        Return v_node
    End Function

    Private Function AddTreeNode(ByRef pv_nodeParent As BarSubItemEx,
                              ByVal pv_strKey As String,
                              ByVal pv_strName As String,
                              ByVal pv_strLast As String,
                              Optional ByVal pv_intImageIdx As Integer = 0,
                              Optional ByVal pv_strObjName As String = "") As BarButtonItemEx

        Dim v_node As New BarButtonItemEx(barManager, pv_strName)
        'Create new node
        If pv_strName.Equals("-") Then
            pv_nodeParent.AddItem(v_node).BeginGroup = True
        Else


            v_node.Key = pv_strKey

            If pv_strLast = gc_IS_LAST_MENU Then
                Dim v_arrMenuKey() As String
                v_arrMenuKey = pv_strKey.Split("|")

                If v_arrMenuKey.Length <> 3 Then 'Không ph?i là transaction
                    v_node.Caption = pv_strName
                    v_node.ItemShortcut = New BarShortcut(GetShortcut(v_arrMenuKey(6)))
                End If

                If Not hMenuFunction.Contains(v_arrMenuKey(0)) Then
                    hMenuFunction.Add(v_arrMenuKey(0), v_arrMenuKey)
                End If

                AddHandler v_node.ItemClick, AddressOf BarButtonItemClick
                'AddHandler v_node.KeyDown, AddressOf Me.Menu_KeyUp
            Else
                v_node.Caption = pv_strName
                'v_node.Expanded = False
            End If

            pv_nodeParent.AddItem(v_node)


        End If
        Return v_node
    End Function

    Private Function AddTreeNode(ByRef pv_nodeParent As MenuItemEx,
                              ByVal pv_strKey As String,
                              ByVal pv_strName As String,
                              ByVal pv_strLast As String,
                              Optional ByVal pv_intImageIdx As Integer = 0,
                              Optional ByVal pv_strObjName As String = "") As MenuItemEx

        Dim v_node As New MenuItemEx(pv_strName)
        'Create new node
        If pv_strName.Equals("-") Then
            pv_nodeParent.DropDownItems.Add(New ToolStripSeparator)
        Else


            v_node.Key = pv_strKey

            If pv_strLast = gc_IS_LAST_MENU Then
                Dim v_arrMenuKey() As String
                v_arrMenuKey = pv_strKey.Split("|")

                If v_arrMenuKey.Length <> 3 Then 'Không ph?i là transaction
                    v_node.Text = pv_strName
                    v_node.ShortcutKeys = GetShortcut(v_arrMenuKey(6))
                End If

                hMenuFunction.Add(v_arrMenuKey(0), v_arrMenuKey)
                AddHandler v_node.Click, AddressOf Me.MenuItem_Click
                'AddHandler v_node.KeyDown, AddressOf Me.Menu_KeyUp
            Else
                v_node.Text = pv_strName
                'v_node.Expanded = False
            End If

            pv_nodeParent.DropDownItems.Add(v_node)


        End If
        Return v_node
    End Function

    Private Function AddTreeAdjustNode(ByRef pv_nodeParent As Node,
                               ByVal pv_strKey As String,
                               ByVal pv_strTag As String,
                               ByVal pv_strName As String,
                               ByVal pv_strLast As String,
                               Optional ByVal pv_intImageIdx As Integer = 0,
                               Optional ByVal pv_strObjName As String = "") As Node
        'Create new node
        Dim v_node As New Node(pv_strName, pv_intImageIdx)

        v_node.Key = "A" & pv_strKey
        v_node.ToolTipText = pv_strName
        v_node.Tag = pv_strTag
        If pv_strLast = gc_IS_LAST_MENU Then
            v_node.Text = pv_strName
            AddHandler v_node.Click, AddressOf Me.AdjustMenu_Click
            AddHandler v_node.KeyUp, AddressOf Me.AdjustMenu_KeyUp
        Else
            v_node.Text = pv_strName
            v_node.Expanded = False
        End If

        pv_nodeParent.Items.Add(v_node)
        Return v_node
    End Function

    Private Sub LoadCasheInfo()
        mv_strSymbolTable = New DataTable
        mv_strSYMBOLLIST = ""
        mv_strCOUNTRYTable = New DataTable
        mv_strCOUNTRYLIST = ""
        mv_strPROVINCETable = New DataTable
        mv_strPROVINCELIST = ""

        'trung.luu: 03-09-2020
        mv_strCELLSDEFINETable = New DataTable
        mv_strCELLSDEFINELIST = ""

        'Load danh sach chung khoan giao dich trong ngay
        Dim v_strCmdSQL As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement

        v_strCmdSQL = "SELECT  CDVAL VALUE, EN_CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'COUNTRY' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        mv_strCOUNTRYLIST = v_strObjMsg
        FillDataToTable(v_strObjMsg, mv_strCOUNTRYTable)

        'Load danh sach PROVINCE
        v_strCmdSQL = "SELECT  CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'PROVINCE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        mv_strPROVINCELIST = v_strObjMsg
        FillDataToTable(v_strObjMsg, mv_strPROVINCETable)


        'trung.luu: 03-09-2020
        'Load danh sach CELLSDEFINE
        v_strCmdSQL = "SELECT KEYS, OBJECTNAME, CFIELDNAME, FFIELDNAME, CVALUE,FORMAT FROM CELLSDEFINE"
        v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        mv_strCELLSDEFINETable = ObjDataToDataset(v_strObjMsg, , "CELLSDEFINE")
    End Sub

    Public Function GetShortcut(ByVal strShortcut As String) As System.Windows.Forms.Shortcut
        Select Case strShortcut
            Case "Alt0"
                Return System.Windows.Forms.Shortcut.Alt0
            Case "Alt1"
                Return System.Windows.Forms.Shortcut.Alt1
            Case "Alt2"
                Return System.Windows.Forms.Shortcut.Alt2
            Case "Alt3"
                Return System.Windows.Forms.Shortcut.Alt3
            Case "Alt4"
                Return System.Windows.Forms.Shortcut.Alt4
            Case "Alt5"
                Return System.Windows.Forms.Shortcut.Alt5
            Case "Alt6"
                Return System.Windows.Forms.Shortcut.Alt6
            Case "Alt7"
                Return System.Windows.Forms.Shortcut.Alt7
            Case "Alt8"
                Return System.Windows.Forms.Shortcut.Alt8
            Case "Alt9"
                Return System.Windows.Forms.Shortcut.Alt9
            Case "AltBksp"
                Return System.Windows.Forms.Shortcut.AltBksp
            Case "AltF1"
                Return System.Windows.Forms.Shortcut.AltF1
            Case "AltF2"
                Return System.Windows.Forms.Shortcut.AltF2
            Case "AltF3"
                Return System.Windows.Forms.Shortcut.AltF3
            Case "AltF4"
                Return System.Windows.Forms.Shortcut.AltF4
            Case "AltF5"
                Return System.Windows.Forms.Shortcut.AltF5
            Case "AltF6"
                Return System.Windows.Forms.Shortcut.AltF6
            Case "AltF7"
                Return System.Windows.Forms.Shortcut.AltF7
            Case "AltF8"
                Return System.Windows.Forms.Shortcut.AltF8
            Case "AltF9"
                Return System.Windows.Forms.Shortcut.AltF9
            Case "AltF10"
                Return System.Windows.Forms.Shortcut.AltF10
            Case "AltF11"
                Return System.Windows.Forms.Shortcut.AltF11
            Case "AltF12"
                Return System.Windows.Forms.Shortcut.AltF12
            Case "Ctrl0"
                Return System.Windows.Forms.Shortcut.Ctrl0
            Case "Ctrl1"
                Return System.Windows.Forms.Shortcut.Ctrl1
            Case "Ctrl2"
                Return System.Windows.Forms.Shortcut.Ctrl2
            Case "Ctrl3"
                Return System.Windows.Forms.Shortcut.Ctrl3
            Case "Ctrl4"
                Return System.Windows.Forms.Shortcut.Ctrl4
            Case "Ctrl5"
                Return System.Windows.Forms.Shortcut.Ctrl5
            Case "Ctrl6"
                Return System.Windows.Forms.Shortcut.Ctrl6
            Case "Ctrl7"
                Return System.Windows.Forms.Shortcut.Ctrl7
            Case "Ctrl8"
                Return System.Windows.Forms.Shortcut.Ctrl8
            Case "Ctrl9"
                Return System.Windows.Forms.Shortcut.Ctrl9
            Case "CtrlA"
                Return System.Windows.Forms.Shortcut.CtrlA
            Case "CtrlB"
                Return System.Windows.Forms.Shortcut.CtrlB
            Case "CtrlC"
                Return System.Windows.Forms.Shortcut.CtrlC
            Case "CtrlD"
                Return System.Windows.Forms.Shortcut.CtrlD
            Case "CtrlDel"
                Return System.Windows.Forms.Shortcut.CtrlDel
            Case "CtrlE"
                Return System.Windows.Forms.Shortcut.CtrlE
            Case "CtrlF"
                Return System.Windows.Forms.Shortcut.CtrlF
            Case "CtrlF1"
                Return System.Windows.Forms.Shortcut.CtrlF1
            Case "CtrlF10"
                Return System.Windows.Forms.Shortcut.CtrlF10
            Case "CtrlF11"
                Return System.Windows.Forms.Shortcut.CtrlF11
            Case "CtrlF12"
                Return System.Windows.Forms.Shortcut.CtrlF12
            Case "CtrlF2"
                Return System.Windows.Forms.Shortcut.CtrlF2
            Case "CtrlF3"
                Return System.Windows.Forms.Shortcut.CtrlF3
            Case "CtrlF4"
                Return System.Windows.Forms.Shortcut.CtrlF4
            Case "CtrlF5"
                Return System.Windows.Forms.Shortcut.CtrlF5
            Case "CtrlF6"
                Return System.Windows.Forms.Shortcut.CtrlF6
            Case "CtrlF7"
                Return System.Windows.Forms.Shortcut.CtrlF7
            Case "CtrlF8"
                Return System.Windows.Forms.Shortcut.CtrlF8
            Case "CtrlF9"
                Return System.Windows.Forms.Shortcut.CtrlF9
            Case "CtrlG"
                Return System.Windows.Forms.Shortcut.CtrlG
            Case "CtrlH"
                Return System.Windows.Forms.Shortcut.CtrlH
            Case "CtrlI"
                Return System.Windows.Forms.Shortcut.CtrlI
            Case "CtrlIns"
                Return System.Windows.Forms.Shortcut.CtrlIns
            Case "CtrlJ"
                Return System.Windows.Forms.Shortcut.CtrlJ
            Case "CtrlK"
                Return System.Windows.Forms.Shortcut.CtrlK
            Case "CtrlL"
                Return System.Windows.Forms.Shortcut.CtrlL
            Case "CtrlM"
                Return System.Windows.Forms.Shortcut.CtrlM
            Case "CtrlN"
                Return System.Windows.Forms.Shortcut.CtrlN
            Case "CtrlO"
                Return System.Windows.Forms.Shortcut.CtrlO
            Case "CtrlP"
                Return System.Windows.Forms.Shortcut.CtrlP
            Case "CtrlQ"
                Return System.Windows.Forms.Shortcut.CtrlQ
            Case "CtrlR"
                Return System.Windows.Forms.Shortcut.CtrlR
            Case "CtrlS"
                Return System.Windows.Forms.Shortcut.CtrlS
            Case "CtrlShift0"
                Return System.Windows.Forms.Shortcut.CtrlShift0
            Case "CtrlShift1"
                Return System.Windows.Forms.Shortcut.CtrlShift1
            Case "CtrlShift2"
                Return System.Windows.Forms.Shortcut.CtrlShift2
            Case "CtrlShift3"
                Return System.Windows.Forms.Shortcut.CtrlShift3
            Case "CtrlShift4"
                Return System.Windows.Forms.Shortcut.CtrlShift4
            Case "CtrlShift5"
                Return System.Windows.Forms.Shortcut.CtrlShift5
            Case "CtrlShift6"
                Return System.Windows.Forms.Shortcut.CtrlShift6
            Case "CtrlShift7"
                Return System.Windows.Forms.Shortcut.CtrlShift7
            Case "CtrlShift8"
                Return System.Windows.Forms.Shortcut.CtrlShift8
            Case "CtrlShift9"
                Return System.Windows.Forms.Shortcut.CtrlShift9
            Case "CtrlShiftA"
                Return System.Windows.Forms.Shortcut.CtrlShiftA
            Case "CtrlShiftB"
                Return System.Windows.Forms.Shortcut.CtrlShiftB
            Case "CtrlShiftC"
                Return System.Windows.Forms.Shortcut.CtrlShiftC
            Case "CtrlShiftD"
                Return System.Windows.Forms.Shortcut.CtrlShiftD
            Case "CtrlShiftE"
                Return System.Windows.Forms.Shortcut.CtrlShiftE
            Case "CtrlShiftF"
                Return System.Windows.Forms.Shortcut.CtrlShiftF
            Case "CtrlShiftF1"
                Return System.Windows.Forms.Shortcut.CtrlShiftF1
            Case "CtrlShiftF10"
                Return System.Windows.Forms.Shortcut.CtrlShiftF10
            Case "CtrlShiftF11"
                Return System.Windows.Forms.Shortcut.CtrlShiftF11
            Case "CtrlShiftF12"
                Return System.Windows.Forms.Shortcut.CtrlShiftF12
            Case "CtrlShiftF2"
                Return System.Windows.Forms.Shortcut.CtrlShiftF2
            Case "CtrlShiftF3"
                Return System.Windows.Forms.Shortcut.CtrlShiftF3
            Case "CtrlShiftF4"
                Return System.Windows.Forms.Shortcut.CtrlShiftF4
            Case "CtrlShiftF5"
                Return System.Windows.Forms.Shortcut.CtrlShiftF5
            Case "CtrlShiftF6"
                Return System.Windows.Forms.Shortcut.CtrlShiftF6
            Case "CtrlShiftF7"
                Return System.Windows.Forms.Shortcut.CtrlShiftF7
            Case "CtrlShiftF8"
                Return System.Windows.Forms.Shortcut.CtrlShiftF8
            Case "CtrlShiftF9"
                Return System.Windows.Forms.Shortcut.CtrlShiftF9
            Case "CtrlShiftG"
                Return System.Windows.Forms.Shortcut.CtrlShiftG
            Case "CtrlShiftH"
                Return System.Windows.Forms.Shortcut.CtrlShiftH
            Case "CtrlShiftI"
                Return System.Windows.Forms.Shortcut.CtrlShiftI
            Case "CtrlShiftJ"
                Return System.Windows.Forms.Shortcut.CtrlShiftJ
            Case "CtrlShiftK"
                Return System.Windows.Forms.Shortcut.CtrlShiftK
            Case "CtrlShiftL"
                Return System.Windows.Forms.Shortcut.CtrlShiftL
            Case "CtrlShiftM"
                Return System.Windows.Forms.Shortcut.CtrlShiftM
            Case "CtrlShiftN"
                Return System.Windows.Forms.Shortcut.CtrlShiftN
            Case "CtrlShiftO"
                Return System.Windows.Forms.Shortcut.CtrlShiftO
            Case "CtrlShiftP"
                Return System.Windows.Forms.Shortcut.CtrlShiftP
            Case "CtrlShiftQ"
                Return System.Windows.Forms.Shortcut.CtrlShiftQ
            Case "CtrlShiftR"
                Return System.Windows.Forms.Shortcut.CtrlShiftR
            Case "CtrlShiftS"
                Return System.Windows.Forms.Shortcut.CtrlShiftS
            Case "CtrlShiftT"
                Return System.Windows.Forms.Shortcut.CtrlShiftT
            Case "CtrlShiftU"
                Return System.Windows.Forms.Shortcut.CtrlShiftU
            Case "CtrlShiftV"
                Return System.Windows.Forms.Shortcut.CtrlShiftV
            Case "CtrlShiftW"
                Return System.Windows.Forms.Shortcut.CtrlShiftW
            Case "CtrlShiftX"
                Return System.Windows.Forms.Shortcut.CtrlShiftX
            Case "CtrlShiftY"
                Return System.Windows.Forms.Shortcut.CtrlShiftY
            Case "CtrlShiftZ"
                Return System.Windows.Forms.Shortcut.CtrlShiftZ
            Case "CtrlT"
                Return System.Windows.Forms.Shortcut.CtrlT
            Case "CtrlU"
                Return System.Windows.Forms.Shortcut.CtrlU
            Case "CtrlV"
                Return System.Windows.Forms.Shortcut.CtrlV
            Case "CtrlW"
                Return System.Windows.Forms.Shortcut.CtrlW
            Case "CtrlX"
                Return System.Windows.Forms.Shortcut.CtrlX
            Case "CtrlY"
                Return System.Windows.Forms.Shortcut.CtrlY
            Case "CtrlZ"
                Return System.Windows.Forms.Shortcut.CtrlZ
            Case "Del"
                Return System.Windows.Forms.Shortcut.Del
            Case "F1"
                Return System.Windows.Forms.Shortcut.F1
            Case "F10"
                Return System.Windows.Forms.Shortcut.F10
            Case "F11"
                Return System.Windows.Forms.Shortcut.F11
            Case "F12"
                Return System.Windows.Forms.Shortcut.F12
            Case "F2"
                Return System.Windows.Forms.Shortcut.F2
            Case "F3"
                Return System.Windows.Forms.Shortcut.F3
            Case "F4"
                Return System.Windows.Forms.Shortcut.F4
            Case "F5"
                Return System.Windows.Forms.Shortcut.F5
            Case "F6"
                Return System.Windows.Forms.Shortcut.F6
            Case "F7"
                Return System.Windows.Forms.Shortcut.F7
            Case "F8"
                Return System.Windows.Forms.Shortcut.F8
            Case "F9"
                Return System.Windows.Forms.Shortcut.F9
            Case "Ins"
                Return System.Windows.Forms.Shortcut.Ins
            Case "None"
                Return System.Windows.Forms.Shortcut.None
            Case "ShiftDel"
                Return System.Windows.Forms.Shortcut.ShiftDel
            Case "ShiftF1"
                Return System.Windows.Forms.Shortcut.ShiftF1
            Case "ShiftF10"
                Return System.Windows.Forms.Shortcut.ShiftF10
            Case "ShiftF11"
                Return System.Windows.Forms.Shortcut.ShiftF11
            Case "ShiftF12"
                Return System.Windows.Forms.Shortcut.ShiftF12
            Case "ShiftF2"
                Return System.Windows.Forms.Shortcut.ShiftF2
            Case "ShiftF3"
                Return System.Windows.Forms.Shortcut.ShiftF3
            Case "ShiftF4"
                Return System.Windows.Forms.Shortcut.ShiftF4
            Case "ShiftF5"
                Return System.Windows.Forms.Shortcut.ShiftF5
            Case "ShiftF6"
                Return System.Windows.Forms.Shortcut.ShiftF6
            Case "ShiftF7"
                Return System.Windows.Forms.Shortcut.ShiftF7
            Case "ShiftF8"
                Return System.Windows.Forms.Shortcut.ShiftF8
            Case "ShiftF9"
                Return System.Windows.Forms.Shortcut.ShiftF9
            Case "ShiftIns"
                Return System.Windows.Forms.Shortcut.ShiftIns
            Case Else
                Return Nothing
        End Select
    End Function
    Private Sub MenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_arrMenuKey() As String
        v_arrMenuKey = CType(sender, MenuItemEx).Key.Split("|")
        ExecuteMenuFunction(v_arrMenuKey)
    End Sub

    Private Sub BarButtonItemClick(sender As Object, e As ItemClickEventArgs)
        Dim v_arrMenuKey() As String
        v_arrMenuKey = CType(e.Item, BarButtonItemEx).Key.Split("|")
        ExecuteMenuFunction(v_arrMenuKey)
    End Sub

    Private Sub BarSubItemClick(sender As Object, e As ItemClickEventArgs)
        Dim v_arrMenuKey() As String
        v_arrMenuKey = CType(e.Item, BarSubItemEx).Key.Split("|")
        ExecuteMenuFunction(v_arrMenuKey)
    End Sub

    Private Sub AddChildMenu_bk(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strLast, v_strMenuType, v_strAuthCode, v_strAuthString As String
        Dim v_strModCode, v_strObjName, v_strMenuKey As String
        Dim v_NewNode As New Node

        Try
            v_strObjMsg = CommonLibrary.BuildXMLObjMsg(Now.Date, m_BusLayer.CurrentTellerProfile.BranchId, Now.Date,
                m_BusLayer.CurrentTellerProfile.TellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , m_BusLayer.CurrentTellerProfile.TellerId & "|" & pv_strKey, "GetUserChildMenu")
            m_BusLayer.BusSystemMessage(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If Not pv_nodeParent Is Nothing Then
                'Get right of current user
                Dim v_strMaker As String
                If m_BusLayer.CurrentTellerProfile.TellerRight <> String.Empty Then
                    v_strMaker = Mid(m_BusLayer.CurrentTellerProfile.TellerRight, 1, 1)
                End If

                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "PRID"
                                    v_strPRID = Trim(v_strValue)
                                Case "CMDNAME"
                                    If m_BusLayer.AppLanguage <> "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                Case "EN_CMDNAME"
                                    If m_BusLayer.AppLanguage = "EN" Then
                                        v_strCmdName = Trim(v_strValue)
                                    End If
                                Case "IMGINDEX"
                                    v_intIndex = CInt(Trim(v_strValue))
                                Case "CMDCODE"
                                    v_strCMDID = Trim(v_strValue)
                                Case "LAST"
                                    v_strLast = Trim(v_strValue)
                                Case "MODCODE"
                                    v_strModCode = Trim(v_strValue)
                                Case "OBJNAME"
                                    v_strObjName = Trim(v_strValue)
                                Case "MENUTYPE"
                                    v_strMenuType = Trim(v_strValue)
                                Case "AUTHCODE"
                                    v_strAuthCode = v_strValue.Trim()
                                Case "STRAUTH"
                                    v_strAuthString = v_strValue.Trim()
                            End Select
                        End With
                    Next v_int

                    v_strMenuKey = v_strCMDID & "|" & v_strMenuType & "|" & v_strModCode & "|" & v_strObjName & "|" & v_strAuthCode & "|" & v_strAuthString

                    v_NewNode = AddTreeNode(pv_nodeParent, v_strMenuKey, v_strCmdName, v_strLast, v_intIndex)

                    'Insert transaction to menu tree
                    If (v_strMenuType = "T") And (v_strMaker = "Y") Then
                        Dim v_strTransKey As String
                        v_strTransKey = m_BusLayer.CurrentTellerProfile.TellerId & "|" & v_strModCode
                        AddTransChildMenu_bk(v_NewNode, v_strTransKey)
                    End If

                    AddChildMenu_bk(v_NewNode, v_strCMDID)
                Next v_intCount
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    ''' <summary>
    ''' Huy viet
    ''' </summary>
    ''' <param name="parentNode"></param>
    ''' <param name="xNode"></param>
    ''' <remarks></remarks>
    Private Sub AddChildMenu_BDS(ByRef parentNode As Node, ByRef xNode As Xml.XmlNode)
        If xNode.Name = "ObjectMessage" Then
            For Each node As Xml.XmlNode In xNode.ChildNodes
                If node.Name = "ObjData" Then
                    Dim newTreeNode As Node = BindXmlNodeToTreeNode(node, parentNode)
                    For Each grand As Xml.XmlNode In node.ChildNodes
                        If grand.Attributes.GetNamedItem("fldname") Is Nothing Then
                            Continue For
                        End If
                        Dim nodeFieldName As Xml.XmlNode
                        nodeFieldName = grand.Attributes.GetNamedItem("fldname")
                        If nodeFieldName.Value = "CMDCODE" Then
                            If grand.HasChildNodes Then
                                If Not grand.FirstChild.NextSibling Is Nothing Then
                                    AddChildMenu_BDS(newTreeNode, grand.FirstChild.NextSibling)
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub AddChildAdjustMenu_BDS(ByRef parentNode As Node, ByRef xNode As Xml.XmlNode)
        If xNode.Name = "ObjectMessage" Then
            For Each node As Xml.XmlNode In xNode.ChildNodes
                If node.Name = "ObjData" Then
                    Dim newTreeNode As Node = BindXmlNodeToTreeAdjustNode(node, parentNode)
                    For Each grand As Xml.XmlNode In node.ChildNodes
                        If grand.Attributes.GetNamedItem("fldname") Is Nothing Then
                            Continue For
                        End If
                        Dim nodeFieldName As Xml.XmlNode
                        nodeFieldName = grand.Attributes.GetNamedItem("fldname")
                        If nodeFieldName.Value = "CMDCODE" Then
                            If grand.HasChildNodes Then
                                If Not grand.FirstChild.NextSibling Is Nothing Then
                                    AddChildAdjustMenu_BDS(newTreeNode, grand.FirstChild.NextSibling)
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            Next
        End If
        Try
            If parentNode.Items.Count <= 0 AndAlso parentNode.Key.Split("|")(1) = "P" Then
                If parentNode.Key.Substring(1, 6) = "000000" Then
                    parentNode.Items.Clear()
                Else
                    parentNode.ParentItem.Items.Remove(parentNode)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function BindXmlNodeToTreeNode(ByRef xmlNode As Xml.XmlNode, ByRef parentTreeNode As Node) As Node
        Dim v_tempNode, v_retNode As Node
        If xmlNode.Name = "ObjData" Then
            'Check Type of tree node 
            Dim parentNode As Xml.XmlNode = xmlNode.ParentNode
            Dim isTransNode As Boolean = False
            If parentNode.Attributes.GetNamedItem("FUNCTIONNAME").Value = "GetTransChildMenu" Then
                isTransNode = True
            End If

            Dim treeNode As New Node
            'Xml Object fields
            Dim prId As String = String.Empty
            Dim cmdCode As String = String.Empty
            Dim cmdName As String = String.Empty
            Dim imgIndex As String = String.Empty
            Dim menuType As String = String.Empty
            Dim hotKey As String = String.Empty
            Dim shortKey As String = String.Empty
            Dim modCode As String = String.Empty
            Dim objName As String = String.Empty
            Dim last As String = String.Empty
            Dim trans As String = String.Empty
            Dim authString As String = String.Empty
            Dim authCode As String = String.Empty
            Dim tlTxcd As String = String.Empty
            Dim txDesc As String = String.Empty
            Dim cmdAllow As String = String.Empty

            'Neu la tree node binh thuong
            If Not isTransNode Then
                For Each child As Xml.XmlNode In xmlNode.ChildNodes
                    If child.Attributes.GetNamedItem("fldname") Is Nothing Then
                        Continue For
                    End If
                    Dim nodeFieldName As XmlNode
                    nodeFieldName = child.Attributes.GetNamedItem("fldname")
                    Dim nodeFieldValue As String = child.InnerText

                    Select Case nodeFieldName.Value
                        Case "CMDCODE"
                            cmdCode = nodeFieldValue
                        Case "PRID"
                            prId = nodeFieldValue
                        Case "CMDNAME"
                            If m_BusLayer.AppLanguage <> "EN" Then
                                cmdName = nodeFieldValue
                            End If
                        Case "EN_CMDNAME"
                            If m_BusLayer.AppLanguage = "EN" Then
                                cmdName = nodeFieldValue
                            End If
                        Case "IMGINDEX"
                            imgIndex = CInt(nodeFieldValue)
                        Case "LAST"
                            last = nodeFieldValue
                        Case "MODCODE"
                            modCode = nodeFieldValue
                        Case "OBJNAME"
                            objName = nodeFieldValue
                        Case "MENUTYPE"
                            menuType = nodeFieldValue
                        Case "HOTKEY"
                            hotKey = nodeFieldValue
                        Case "SHORTKEY"
                            shortKey = nodeFieldValue
                        Case "AUTHCODE"
                            authCode = nodeFieldValue
                        Case "STRAUTH"
                            authString = nodeFieldValue
                    End Select
                Next

                Dim strMenuKey As String = cmdCode & "|" & menuType & "|" & modCode & "|" & objName & "|" & authCode & "|" & authString
                ''Dat HotKey
                'Select Case hotKey.Trim
                '    Case "F1"
                '        mv_strHotKeyF1 = strMenuKey.Split("|")
                '    Case "F2"
                '        mv_strHotKeyF2 = strMenuKey.Split("|")
                '    Case "F3"
                '        mv_strHotKeyF3 = strMenuKey.Split("|")
                '    Case "F4"
                '        mv_strHotKeyF4 = strMenuKey.Split("|")
                '    Case "F5"
                '        mv_strHotKeyF5 = strMenuKey.Split("|")
                '    Case "F6"
                '        mv_strHotKeyF6 = strMenuKey.Split("|")
                '    Case "F7"
                '        mv_strHotKeyF7 = strMenuKey.Split("|")
                '    Case "F8"
                '        mv_strHotKeyF8 = strMenuKey.Split("|")
                '    Case "F9"
                '        mv_strHotKeyF9 = strMenuKey.Split("|")
                '    Case "F10"
                '        mv_strHotKeyF10 = strMenuKey.Split("|")
                '    Case "F11"
                '        mv_strHotKeyF11 = strMenuKey.Split("|")
                '    Case "F12"
                '        mv_strHotKeyF12 = strMenuKey.Split("|")
                'End Select
                'SetTreeNodeAttribute(treeNode, strMenuKey, cmdName, last, imgIndex)
                'Ghi nhan ShortKey
                'If String.Compare(shortKey, "Y") = 0 And String.Compare(last, "Y") = 0 Then
                '    'Create ShortCutNode
                '    v_tempNode = CreateShortCutNode(gc_PREFIX_SHORTCUT & strMenuKey, cmdName, last, imgIndex)
                '    mv_arrShortKey.Add(v_tempNode)
                'End If
                v_retNode = AddTreeNode(parentTreeNode, strMenuKey, cmdName, last, imgIndex, objName)

                If String.Compare(objName, "FODEALER") = 0 Or String.Compare(objName, "PAFNMLTRAD") = 0 Then
                    m_blnAllowBrokerDesk = True
                ElseIf String.Compare(objName, "TELEINQ") = 0 Then
                    m_blnAllowTeleOrder = True
                ElseIf String.Compare(objName, "CREATEDFGRDEAL") = 0 Then
                    m_blnAllowCreateDeal = True
                ElseIf String.Compare(objName, "FOFORCESELL") = 0 Then
                    m_blnAllowForceSell = True
                End If
                Return v_retNode
            Else 'Neu la tree node transaction
                For Each child As XmlNode In xmlNode.ChildNodes
                    If child.Attributes.GetNamedItem("fldname") Is Nothing Then
                        Continue For
                    End If
                    Dim nodeFieldName As XmlNode
                    nodeFieldName = child.Attributes.GetNamedItem("fldname")
                    Dim nodeFieldValue As String = child.InnerText
                    Select Case nodeFieldName.Value
                        Case "TLTXCD"
                            tlTxcd = nodeFieldValue
                        Case "TXDESC"
                            If m_BusLayer.AppLanguage <> "EN" Then
                                txDesc = nodeFieldValue
                            End If
                        Case "EN_TXDESC"
                            If m_BusLayer.AppLanguage = "EN" Then
                                txDesc = nodeFieldValue
                            End If
                        Case "MODCODE"
                            modCode = nodeFieldValue
                        Case "IMGINDEX"
                            imgIndex = CInt(nodeFieldValue)
                        Case "CMDALLOW"
                            cmdAllow = nodeFieldValue
                        Case "SHORTKEY"
                            shortKey = nodeFieldValue
                    End Select
                Next
                If cmdAllow = "Y" Then
                    Dim strTransKey As String = tlTxcd & "|" & cmdAllow & "|" & modCode
                    If hTransAllowed(tlTxcd) Is Nothing Then
                        hTransAllowed.Add(tlTxcd, strTransKey)
                    End If
                    'Ghi nhan ShortKey
                    'If String.Compare(shortKey, "Y") = 0 Then
                    '    'Create ShortCutNode
                    '    v_tempNode = CreateShortCutNode(gc_PREFIX_SHORTCUT & strTransKey, tlTxcd & ": " & txDesc, gc_IS_LAST_MENU, imgIndex)
                    '    mv_arrShortKey.Add(v_tempNode)
                    'End If
                    v_retNode = AddTreeNode(parentTreeNode, strTransKey, tlTxcd & ": " & txDesc, gc_IS_LAST_MENU, imgIndex)
                    Return v_retNode
                End If
            End If
        End If
        Return Nothing
    End Function


    Private Function BindXmlNodeToTreeAdjustNode(ByRef xmlNode As Xml.XmlNode, ByRef parentTreeNode As Node) As Node
        Dim v_tempNode, v_retNode As Node
        If xmlNode.Name = "ObjData" Then
            'Check Type of tree node 
            Dim parentNode As Xml.XmlNode = xmlNode.ParentNode

            Dim treeNode As New Node
            'Xml Object fields
            Dim prId As String = String.Empty
            Dim cmdCode As String = String.Empty
            Dim cmdName As String = String.Empty
            Dim imgIndex As String = String.Empty
            Dim menuType As String = String.Empty
            Dim hotKey As String = String.Empty
            Dim shortKey As String = String.Empty
            Dim modCode As String = String.Empty
            Dim objName As String = String.Empty
            Dim last As String = String.Empty
            Dim trans As String = String.Empty
            Dim authString As String = String.Empty
            Dim authCode As String = String.Empty
            Dim tlTxcd As String = String.Empty
            Dim txDesc As String = String.Empty
            Dim cmdAllow As String = String.Empty
            Dim refCmdCode As String = String.Empty

            For Each child As Xml.XmlNode In xmlNode.ChildNodes
                If child.Attributes.GetNamedItem("fldname") Is Nothing Then
                    Continue For
                End If
                Dim nodeFieldName As XmlNode
                nodeFieldName = child.Attributes.GetNamedItem("fldname")
                Dim nodeFieldValue As String = child.InnerText

                Select Case nodeFieldName.Value
                    Case "REFCMDCODE"
                        refCmdCode = nodeFieldValue
                    Case "CMDCODE"
                        cmdCode = nodeFieldValue
                    Case "PRID"
                        prId = nodeFieldValue
                    Case "CMDNAME"
                        If m_BusLayer.AppLanguage <> "EN" Then
                            cmdName = nodeFieldValue
                        End If
                    Case "EN_CMDNAME"
                        If m_BusLayer.AppLanguage = "EN" Then
                            cmdName = nodeFieldValue
                        End If
                    Case "IMGINDEX"
                        imgIndex = CInt(nodeFieldValue)
                    Case "LAST"
                        last = nodeFieldValue
                    Case "MODCODE"
                        modCode = nodeFieldValue
                    Case "OBJNAME"
                        objName = nodeFieldValue
                    Case "MENUTYPE"
                        menuType = nodeFieldValue
                    Case "HOTKEY"
                        hotKey = nodeFieldValue
                    Case "SHORTKEY"
                        shortKey = nodeFieldValue
                    Case "AUTHCODE"
                        authCode = nodeFieldValue
                    Case "STRAUTH"
                        authString = nodeFieldValue
                End Select
            Next

            Dim strMenuKey As String = cmdCode & "|" & menuType & "|" & modCode & "|" & objName & "|" & authCode & "|" & authString
            Dim strMenuTag As String = ""
            If menuType = "G" Then
                strMenuTag = modCode & "." & refCmdCode & "." & "V" & "." & refCmdCode
            ElseIf menuType = "R" Then
                strMenuTag = refCmdCode
            ElseIf menuType = "T" Then
                strMenuTag = refCmdCode & "|" & "Y" & "|" & modCode
            Else
                strMenuTag = refCmdCode & "|" & menuType & "|" & modCode & "|" & objName & "|" & authCode & "|" & authString
            End If
            v_retNode = AddTreeAdjustNode(parentTreeNode, strMenuKey, strMenuTag, cmdName, last, imgIndex, objName)

            Return v_retNode
        End If
        Return Nothing
    End Function

    Private Sub AddTransChildMenu_bk(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)

        Dim v_strTransObjMsg As String
        Dim v_strFLDNAME, v_strValue, v_strTransKey As String
        Dim v_strTLTXCD, v_strTlName, v_strCmdAllow, v_strImgIndex, v_strModCode As String
        Dim v_NewNode As New Node


        Try
            v_strTransObjMsg = CommonLibrary.BuildXMLObjMsg(Now.Date, m_BusLayer.CurrentTellerProfile.BranchId, Now.Date,
                        m_BusLayer.CurrentTellerProfile.TellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                        OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , pv_strKey, "GetTransChildMenu")
            m_BusLayer.BusSystemMessage(v_strTransObjMsg)
            Dim TransXmlDocument As New Xml.XmlDocument
            Dim v_nodeTransList As Xml.XmlNodeList
            TransXmlDocument.LoadXml(v_strTransObjMsg)
            v_nodeTransList = TransXmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If Not pv_nodeParent Is Nothing Then
                For v_intCount As Integer = 0 To v_nodeTransList.Count - 1
                    For v_int As Integer = 0 To v_nodeTransList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeTransList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "TLTXCD"
                                    v_strTLTXCD = Trim(v_strValue)
                                Case "TXDESC"
                                    If m_BusLayer.AppLanguage <> "EN" Then
                                        v_strTlName = Trim(v_strValue)
                                    End If
                                Case "EN_TXDESC"
                                    If m_BusLayer.AppLanguage = "EN" Then
                                        v_strTlName = Trim(v_strValue)
                                    End If
                                Case "MODCODE"
                                    v_strModCode = Trim(v_strValue)
                                Case "IMGINDEX"
                                    v_strImgIndex = CInt(Trim(v_strValue))
                                Case "CMDALLOW"
                                    v_strCmdAllow = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    'Add transaction node to menu tree
                    If v_strCmdAllow = "Y" Then
                        v_strTransKey = v_strTLTXCD & "|" & v_strCmdAllow & "|" & v_strModCode
                        v_NewNode = AddTreeNode(pv_nodeParent, v_strTransKey, v_strTLTXCD & ": " & v_strTlName, gc_IS_LAST_MENU, v_strImgIndex)

                        'Add to hash table
                        If hTransAllowed(v_strTLTXCD) Is Nothing Then
                            hTransAllowed.Add(v_strTLTXCD, v_strTransKey)
                        End If
                    End If

                Next v_intCount
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdminChangeStatus(ByVal v_strCODE As String)
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long


        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD



            Select Case v_strCODE
                Case "BRACTIVE"
                    v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BranchActive", , , "GetDate")
                Case "BRINACTIVE"
                    v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BranchDeActive", , , "GetDate")
                Case "HOACTIVE"
                    v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "HostActive", , , "GetDate")
                Case "HOINACTIVE"
                    v_strObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "HostDeActive", , , "GetDate")
            End Select

            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            Else
                'Cập nhật kết quả trả v?
                If m_BusLayer.AppLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Change status successfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Else
                    MsgBox("Doi trang thai hoan tat", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

                End If
                If v_strCODE = "BRACTIVE" Then
                    '-----Thuc hien logout-----

                    ChangeOnlineStatus(False)
                    ucSearchTLLOG.Visible = False
                    tbtTransaction.Visible = False
                    hMenuFunction.Clear()

                    If Not DisplayLoginForm() = DialogResult.Cancel Then
                        ChangeOnlineStatus(True)
                        'Load lai cache
                        LoadCasheInfo()
                        ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                    End If

                    'Hiển thị màn hình giao dịch trong ngày
                    ucSearchTLLOG.Visible = True

                    'Visible transaction code menu
                    tbtTransaction.Visible = True
                End If

            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub ExecuteMenuFunction(ByVal pv_arrMenuKey() As String, Optional ByVal pv_strTag As String = "")
        Try
            Dim v_strMenuType, v_strModCode, v_strObjName, v_strAuthCode, v_strAuthString, v_arrMenuKey() As String
            Dim v_strTLTXCD, v_strCmdAllow, v_strCMDTYPE As String
            Dim v_strCMDID As String
            'Check valid token
            v_arrMenuKey = pv_arrMenuKey
            'Check ngay he thong
            If v_arrMenuKey.Length = 3 Then
                If m_BusLayer.CurrentTellerProfile.BusDate <> getCurrdate() Then
                    MsgBox("Ngày của máy trạm và ngày của máy chủ khác nhau, hãy đăng nhập lại!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    ChangeOnlineStatus(False)
                    'Invisible TLLOG search & transaction code menu
                    ucSearchTLLOG.Visible = False
                    tbtTransaction.Visible = False
                    hMenuFunction.Clear()
                    m_blnAllowBrokerDesk = False
                    m_blnAllowTeleOrder = False
                    m_blnAllowCreateDeal = False
                    m_blnAllowForceSell = False

                    barManager.MainMenu.ClearLinks()
                    LoadBarSystemMenu("2")
                    'Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
                    ''Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
                    'v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
                    'v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
                    'v_mnuLogin.ImageIndex = 4
                    'v_mnuLogin.Alignment = BarItemLinkAlignment.Right
                    'barMainMenu.AddItem(v_mnuLogin)
                    'AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick
                    Exit Sub
                End If
            ElseIf Not (v_arrMenuKey.Length = 7 And (v_arrMenuKey(3) = "LOGOUT" Or v_arrMenuKey(3) = "LOGIN")) Then
                If m_BusLayer.CurrentTellerProfile.BusDate <> getCurrdate() Then
                    MsgBox("Ngày của máy trạm và ngày của máy chủ khác nhau, hãy đăng nhập lại!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    ChangeOnlineStatus(False)
                    'Invisible TLLOG search & transaction code menu
                    ucSearchTLLOG.Visible = False
                    tbtTransaction.Visible = False
                    hMenuFunction.Clear()
                    m_blnAllowBrokerDesk = False
                    m_blnAllowTeleOrder = False
                    m_blnAllowCreateDeal = False
                    m_blnAllowForceSell = False

                    barManager.MainMenu.ClearLinks()
                    LoadBarSystemMenu("2")
                    'Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
                    ''Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
                    'v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
                    'v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
                    'v_mnuLogin.ImageIndex = 4
                    'v_mnuLogin.Alignment = BarItemLinkAlignment.Right
                    'barMainMenu.AddItem(v_mnuLogin)
                    'AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick

                    Exit Sub
                End If
            End If



            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            If v_arrMenuKey.Length > 0 Then
                ' If node is not transaction
                If v_arrMenuKey.Length = 7 Then
                    v_strCMDID = v_arrMenuKey(0)
                    v_strMenuType = v_arrMenuKey(1)
                    v_strModCode = v_arrMenuKey(2)
                    v_strObjName = v_arrMenuKey(3)
                    v_strAuthCode = v_arrMenuKey(4)
                    v_strAuthString = v_arrMenuKey(5)


                    Select Case v_strMenuType
                        Case "E"    'Call Executable Application
                            Dim v_strPathFile, v_strArgs As String
                            v_strPathFile = Application.StartupPath & "\" & v_strObjName & ".exe"
                            v_strArgs = m_BusLayer.CurrentTellerProfile.BranchId & " " _
                                        & m_BusLayer.CurrentTellerProfile.TellerId & " " _
                                        & m_BusLayer.CurrentTellerProfile.TellerName & " " _
                                        & m_BusLayer.CurrentTellerProfile.BusDate & " " _
                                        & m_BusLayer.CurrentTellerProfile.TellerGroupCareBy & " "
                            Dim v_Process As System.Diagnostics.Process
                            v_Process = Process.Start(v_strPathFile, v_strArgs)
                            v_Process.WaitForExit()

                        Case "R"    'Report
                            Select Case v_strObjName
                                Case "RPTMASTER"

                                    Dim frm As New frmReportMaster_Tab(m_BusLayer.AppLanguage)
                                    frm.ModuleCode = v_strModCode
                                    frm.LocalObject = gc_IsLocalMsg
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                                    frm.TableName = v_strModCode
                                    frm.CMDID = v_strModCode
                                    If pv_strTag.Length <> 0 Then
                                        frm.RPTID = pv_strTag
                                    End If
                                    frm.ShowDialog()
                                Case "SUBMIT_REPORT"
                                    Dim frm As New frmReportMaster(m_BusLayer.AppLanguage)
                                    frm.ModuleCode = v_strModCode
                                    frm.LocalObject = gc_IsLocalMsg
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                                    If pv_strTag.Length <> 0 Then
                                        frm.RPTID = pv_strTag
                                    End If
                                    frm.ShowDialog()
                                Case "STVREQUEST"
                                    Dim frm As New frmRequestMaster(m_BusLayer.AppLanguage)
                                    frm.ModuleCode = v_strModCode
                                    frm.LocalObject = gc_IsLocalMsg
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                                    frm.TableName = v_strModCode
                                    frm.CMDID = v_strModCode
                                    If pv_strTag.Length <> 0 Then
                                        frm.RPTID = pv_strTag
                                    End If
                                    frm.ShowDialog()
                                    'End 'T07/2017 STP
                            End Select


                        Case "G"
                            DisplayGeneralView(v_strModCode, pv_strTag)

                        Case "T"
                            If Not hMenuFunction(pv_strTag) Is Nothing Then
                                v_arrMenuKey = hMenuFunction(pv_strTag)
                                ExecuteMenuFunction(v_arrMenuKey)
                            End If

                        Case "M"    'Maintenance
                            Dim frm As New frmSearchMaster(m_BusLayer.AppLanguage)
                            frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                            frm.NextDate = m_BusLayer.CurrentTellerProfile.NextDate
                            frm.TableName = v_strObjName
                            frm.ModuleCode = v_strModCode
                            frm.AuthCode = v_strAuthCode
                            frm.AuthString = v_strAuthString
                            frm.IsLocalSearch = gc_IsNotLocalMsg
                            frm.mv_strCMDID = v_strCMDID
                            frm.COUNTRYTable = mv_strCOUNTRYTable
                            frm.PROVINCETable = mv_strPROVINCETable
                            frm.CELLSDEFINETable = mv_strCELLSDEFINETable
                            frm.SearchOnInit = True
                            frm.SymbolList = mv_strSYMBOLLIST
                            frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                            frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                            frm.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                            frm.TellerRight = m_BusLayer.CurrentTellerProfile.TellerRight
                            frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                            'If m_BusLayer.CurrentTellerProfile.TimeSearch > 0 Then

                            '    frm.mv_Timer.Interval = m_BusLayer.CurrentTellerProfile.TimeSearch
                            '    frm.mv_Timer.Enabled = True
                            'End If

                            frm.IpAddress = m_BusLayer.AppIpAddress
                            frm.WsName = m_BusLayer.AppWsName
                            frm.CompanyCode = m_BusLayer.CurrentTellerProfile.CompanyCode
                            frm.CompanyName = m_BusLayer.CurrentTellerProfile.CompanyName
                            frm.Show()
                            ''frm.Dispose()

                        Case "O"    'DynamicScreen
                            Dim frm As New frmSearchMaster(m_BusLayer.AppLanguage)
                            frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                            frm.NextDate = m_BusLayer.CurrentTellerProfile.NextDate
                            frm.TableName = v_strObjName
                            frm.ModuleCode = v_strModCode
                            frm.MenuType = v_strMenuType
                            frm.AuthCode = v_strAuthCode
                            frm.AuthString = v_strAuthString
                            frm.IsLocalSearch = gc_IsNotLocalMsg
                            frm.CELLSDEFINETable = mv_strCELLSDEFINETable
                            frm.COUNTRYTable = mv_strCOUNTRYTable
                            frm.mv_strCMDID = v_strCMDID
                            frm.SearchOnInit = True
                            frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                            frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                            frm.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                            frm.TellerRight = m_BusLayer.CurrentTellerProfile.TellerRight
                            frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy


                            frm.IpAddress = m_BusLayer.AppIpAddress
                            frm.WsName = m_BusLayer.AppWsName
                            frm.CompanyCode = m_BusLayer.CurrentTellerProfile.CompanyCode
                            frm.CompanyName = m_BusLayer.CurrentTellerProfile.CompanyName

                            frm.Show()

                        Case "A"    'Special
                            Select Case v_strObjName
                                Case "CHANGEPASSWORD"
                                    Dim v_objChangePassword As New frmChangePassword
                                    v_objChangePassword.UserLanguage = m_BusLayer.AppLanguage
                                    v_objChangePassword.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    v_objChangePassword.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                                    v_objChangePassword.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    v_objChangePassword.BranchName = m_BusLayer.CurrentTellerProfile.BranchName
                                    v_objChangePassword.ShowDialog()
                                Case "LOGOUT"
                                    If XtraMessageBox.Show(m_ResourceManager.GetString("LOGOUT_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        Logout()
                                    End If
                                Case "LOGIN"
                                    If Not DisplayLoginForm() = DialogResult.Cancel Then
                                        AddSearchToTabControl()
                                        If Not mv_isValidToken Then
                                            ChangeOnlineStatus(False)
                                            'Invisible TLLOG search & transaction code menu
                                            ucSearchTLLOG.Visible = False
                                            tbtTransaction.Visible = False
                                            hMenuFunction.Clear()
                                            m_blnAllowBrokerDesk = False
                                            m_blnAllowTeleOrder = False
                                            m_blnAllowCreateDeal = False
                                            m_blnAllowForceSell = False

                                            barManager.MainMenu.ClearLinks()
                                            LoadBarSystemMenu("2")
                                            'Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
                                            ''Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
                                            'v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
                                            'v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
                                            'v_mnuLogin.ImageIndex = 4
                                            'v_mnuLogin.Alignment = BarItemLinkAlignment.Right
                                            'barMainMenu.AddItem(v_mnuLogin)
                                            'AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick
                                            Exit Sub
                                        End If
                                        hMenuFunction.Clear()
                                        ChangeOnlineStatus(True)
                                        LoadCasheInfo()

                                        ucSearchTLLOG.TableName = "TLLOG"
                                        ucSearchTLLOG.ModuleCode = "SY"
                                        'ucSearchTLLOG.ObjectName = "TLLOG"
                                        ucSearchTLLOG.IsLocalSearch = gc_IsLocalMsg
                                        ucSearchTLLOG.UserLanguage = m_BusLayer.AppLanguage
                                        ucSearchTLLOG.SearchOnInit = True
                                        ucSearchTLLOG.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                        ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                        ucSearchTLLOG.TellerType = m_BusLayer.CurrentTellerProfile.TellerRight
                                        ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                        ucSearchTLLOG.TellerGroup = m_BusLayer.CurrentTellerProfile.TellerGroup
                                        ucSearchTLLOG.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                                        ucSearchTLLOG.mv_SignMode = Me.mv_SignMode
                                        'ucSearchTLLOG.m_CurrCAToken = Me.m_CurrCAToken
                                        ucSearchTLLOG.LoadInterface()
                                        'ucSearchTLLOG.InitDialog()
                                        ucSearchTLLOG.AccessArea = Me.m_BusLayer.CurrentTellerProfile.AccessArea
                                        'ucSearchTLLOG.OnSearch(gc_IsLocalMsg, "SY.TLLOG")
                                        ucSearchTLLOG.Criterial = String.Empty
                                        ucSearchTLLOG.Search("Y", "SY", "TLLOG")
                                        ucSearchTLLOG.OnSearch()
                                        ucSearchTLLOG.Visible = True
                                        tbtTransaction.Visible = True
                                        LoadBarMenu()
                                        LoadBarSystemMenu("1")
                                        'LoadRegistryGridViewSettings()

                                        'Bat lai bo dem thoi gian con lai co the connect voi Host
                                        tmrAFK.Enabled = True
                                        remainingConnectionTimeToHost = secondsLimitAFK
                                    End If
                                Case "LANGENGLISH"
                                    'If MsgBox(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then
                                    If XtraMessageBox.Show(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        '1. Save setting into the registry
                                        Dim version_pro_uat = System.Configuration.ConfigurationSettings.AppSettings("version_pro_uat")
                                        Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey + version_pro_uat)
                                        v_regKey.SetValue(gc_REG_LANG, gc_LANG_ENGLISH)
                                        v_regKey.Close()
                                        Application.Restart()
                                        Environment.Exit(0)
                                    End If
                                Case "LANGVIETNAMESE"
                                    'If MsgBox(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then
                                    If XtraMessageBox.Show(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        '1. Save setting into the registry
                                        Dim version_pro_uat = System.Configuration.ConfigurationSettings.AppSettings("version_pro_uat")
                                        Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey + version_pro_uat)
                                        v_regKey.SetValue(gc_REG_LANG, gc_LANG_VIETNAMESE)
                                        v_regKey.Close()
                                        Application.Restart()
                                        Environment.Exit(0)
                                    End If
                                Case "READFILE"
                                    Dim frm As New frmReadFile(m_BusLayer.AppLanguage)
                                    frm.TableName = v_strObjName
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.ModuleCode = v_strModCode
                                    frm.IsApprove = False
                                    frm.IsImport = False
                                    frm.AuthCode = v_strAuthCode
                                    frm.IsLocalSearch = gc_IsNotLocalMsg
                                    frm.TellerID = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.IpAddress = m_BusLayer.AppIpAddress
                                    frm.WsName = m_BusLayer.AppWsName
                                    frm.ShowDialog()
                                Case "IMPORTFILE"
                                    Dim frm As New frmReadFile(m_BusLayer.AppLanguage)
                                    frm.TableName = v_strObjName
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.ModuleCode = v_strModCode
                                    frm.IsApprove = False
                                    frm.IsImport = True
                                    frm.AuthCode = v_strAuthCode
                                    frm.IsLocalSearch = gc_IsNotLocalMsg
                                    frm.TellerID = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.IpAddress = m_BusLayer.AppIpAddress
                                    frm.WsName = m_BusLayer.AppWsName
                                    frm.ShowDialog()
                                Case "GENERALVIEW"  'Màn hình danh sách tra cứu tổng hợp
                                    DisplayGeneralView()
                                Case "BATCH"  'Màn hình xử lý Batch cuối ngày
                                    Dim frm As New frmBatchMaster(m_BusLayer.AppLanguage)
                                    frm.TableName = v_strObjName
                                    frm.ModuleCode = v_strModCode
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.ShowDialog()
                                    If frm.mv_AutoBatchDone Then
                                        For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                                            If Application.OpenForms(i).Name <> Me.Name Then
                                                Application.OpenForms(i).Close()
                                            End If
                                        Next
                                        ChangeOnlineStatus(False)
                                        ucSearchTLLOG.Visible = False
                                        tbtTransaction.Visible = False
                                        hMenuFunction.Clear()
                                        m_blnAllowBrokerDesk = False
                                        m_blnAllowTeleOrder = False
                                        m_blnAllowCreateDeal = False
                                        m_blnAllowForceSell = False

                                        'trung.luu: 08-04-2020 batch xong tu logout, goi login
                                        barManager.MainMenu.ClearLinks()
                                        LoadBarSystemMenu("2")
                                        frm.Dispose()
                                        If Not DisplayLoginForm() = DialogResult.Cancel Then
                                            ChangeOnlineStatus(True)
                                            'Load lai cache
                                            LoadCasheInfo()
                                            ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                        End If

                                        'Hiển thị màn hình giao dịch trong ngày
                                        ucSearchTLLOG.TableName = "TLLOG"
                                        ucSearchTLLOG.ModuleCode = "SY"
                                        'ucSearchTLLOG.ObjectName = "TLLOG"
                                        ucSearchTLLOG.IsLocalSearch = gc_IsLocalMsg
                                        ucSearchTLLOG.UserLanguage = m_BusLayer.AppLanguage
                                        ucSearchTLLOG.SearchOnInit = True
                                        ucSearchTLLOG.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                        ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                        ucSearchTLLOG.TellerType = m_BusLayer.CurrentTellerProfile.TellerRight
                                        ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                        ucSearchTLLOG.TellerGroup = m_BusLayer.CurrentTellerProfile.TellerGroup
                                        ucSearchTLLOG.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                                        ucSearchTLLOG.mv_SignMode = Me.mv_SignMode
                                        ucSearchTLLOG.LoadInterface()
                                        ucSearchTLLOG.InitDialog()
                                        ucSearchTLLOG.AccessArea = Me.m_BusLayer.CurrentTellerProfile.AccessArea
                                        ucSearchTLLOG.Criterial = String.Empty
                                        ucSearchTLLOG.Search("Y", "SY", "TLLOG")

                                        ucSearchTLLOG.Visible = True

                                        'Visible transaction code menu
                                        tbtTransaction.Visible = True
                                        LoadBarMenu()
                                        LoadBarSystemMenu("1")
                                    End If

                                Case "CALENDAR"  'Màn hình quản lý lịch làm việc
                                    Dim frm As New frmCalendar(m_BusLayer.AppLanguage)
                                    frm.TableName = v_strObjName
                                    frm.ModuleCode = v_strModCode
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    'frm.IsCalendarFund = False
                                    frm.ShowDialog()
                                Case "GROUPUSERS"
                                    Dim frm As New frmGROUPUSERS
                                    frm.UserLanguage = m_BusLayer.AppLanguage
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.ExeFlag = ExecuteFlag.AddNew
                                    frm.ShowDialog()
                                Case "CSVCMP"
                                    Dim frm As New frmCSVCompare(m_BusLayer.AppLanguage)
                                    'frm.ObjectName = v_strTLTXCD
                                    frm.ModuleCode = v_strModCode
                                    frm.LocalObject = gc_IsNotLocalMsg
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.IpAddress = m_BusLayer.AppIpAddress
                                    frm.WsName = m_BusLayer.AppWsName
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.ShowDialog()
                                Case "BRACTIVE", "BRINACTIVE", "HOACTIVE", "HOINACTIVE"
                                    Dim v_strMsg As String = String.Empty
                                    Select Case v_strObjName
                                        Case "BRACTIVE"
                                            v_strMsg = m_ResourceManager.GetString("ACTIVE_BDS_CONFIRMATION")
                                        Case "BRINACTIVE"
                                            v_strMsg = m_ResourceManager.GetString("DEACTIVE_BDS_CONFIRMATION")
                                        Case "HOACTIVE"
                                            v_strMsg = m_ResourceManager.GetString("ACTIVE_HOST_CONFIRMATION")
                                        Case "HOINACTIVE"
                                            v_strMsg = m_ResourceManager.GetString("DEACTIVE_HOST_CONFIRMATION")
                                    End Select

                                    If (MessageBox.Show(v_strMsg, gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                                        AdminChangeStatus(v_strObjName)
                                    End If
                                Case "UPDATELASTVERSION"
                                    UpdateLastVersion()
                                Case "RPTTAB"

                                    Dim v_strSQL As String = "SELECT TLTXCD, CMDNAME, EN_CMDNAME FROM CMDMENU WHERE OBJNAME = '" + v_strObjName + "'"
                                    Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strSQL, , )
                                    Dim v_ws As New BDSDeliveryManagement
                                    v_ws.Message(v_strObjMsg)

                                    Dim v_nodeList As Xml.XmlNodeList
                                    Dim v_strFLDNAME As String
                                    Dim v_strValue As String

                                    Dim v_xmlDocument As New XmlDocumentEx
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                    Dim v_tltxcd As String
                                    Dim v_desc As String

                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                v_strValue = .InnerText.ToString
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "TLTXCD"
                                                        v_tltxcd = Trim(v_strValue)
                                                    Case "CMDNAME"
                                                        If m_BusLayer.AppLanguage <> "EN" Then
                                                            v_desc = Trim(v_strValue)
                                                        End If
                                                    Case "EN_CMDNAME"
                                                        If m_BusLayer.AppLanguage = "EN" Then
                                                            v_desc = Trim(v_strValue)
                                                        End If
                                                End Select
                                            End With
                                        Next
                                    Next

                                    Dim frm As New frmSearchCMP2FILETab(m_BusLayer.AppLanguage)
                                    frm.ObjectName = v_strObjName
                                    frm.RptID = v_tltxcd
                                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frm.CMDMenu = v_strCMDID
                                    frm.AuthCode = v_strAuthCode
                                    frm.UserLanguage = m_BusLayer.AppLanguage
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.IpAddress = m_BusLayer.AppIpAddress
                                    frm.WsName = m_BusLayer.AppWsName
                                    frm.Desc = v_desc
                                    frm.Show()
                                Case "CHANGE_SECRET"
                                    Dim frm As New frmCHANGESECRET()
                                    frm.UserLanguage = m_BusLayer.AppLanguage
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.ShowDialog()
                                Case "CALLAPIVMONEY"
                                    Dim frm As New frmCALLAPIVMONEY()
                                    frm.UserLanguage = m_BusLayer.AppLanguage
                                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frm.ShowDialog()
                            End Select
                        Case Else
                            MsgBox(m_ResourceManager.GetString("FUNCTION_ISNOT_IMPLEMENTED"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Code ")
                    End Select

                    'If node is transaction
                ElseIf v_arrMenuKey.Length = 3 Then
                    'Transaction
                    v_strTLTXCD = v_arrMenuKey(0)
                    v_strCmdAllow = v_arrMenuKey(1)
                    v_strModCode = v_arrMenuKey(2)
                    'trung.luu: 28-03-2020 ghep code moi {frmTransactmast =>frmXtraTransactMaster)
                    Dim frm As New frmXtraTransactMaster(m_BusLayer.AppLanguage)
                    frm.ObjectName = v_strTLTXCD
                    frm.ModuleCode = v_strModCode
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                    frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                    frm.IpAddress = m_BusLayer.AppIpAddress
                    frm.WsName = m_BusLayer.AppWsName
                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                    'frm.mv_SignMode = Me.mv_SignMode
                    'frm.m_CurrCAToken = Me.m_CurrCAToken
                    'frm.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                    frm.ShowDialog()
                End If
            End If


            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        End Try

    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        Dim v_arrMenuKey() As String
        v_arrMenuKey = e.Item.Key.Split("|")
        ExecuteMenuFunction(v_arrMenuKey)
    End Sub

    Private Sub Menu_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter, Keys.Space
                    Dim v_arrMenuKey() As String
                    v_arrMenuKey = CType(sender, Xceed.SmartUI.Controls.TreeView.Node).Key.Split("|")
                    'trung.luu: 04-06-2020: logout login khi nhan enter bi goi lai form cũ
                    'ExecuteMenuFunction(v_arrMenuKey)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AdjustMenu_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        Dim v_arrMenuKey() As String
        v_arrMenuKey = e.Item.Key.Split("|")
        ExecuteMenuFunction(v_arrMenuKey, e.Item.Tag.Split("|")(0))
    End Sub

    Private Sub AdjustMenu_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter, Keys.Space
                    Dim v_arrMenuKey() As String
                    v_arrMenuKey = CType(sender, Xceed.SmartUI.Controls.TreeView.Node).Key.Split("|")
                    ExecuteMenuFunction(v_arrMenuKey, CType(sender, Xceed.SmartUI.Controls.TreeView.Node).Tag.Split("|")(0))
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadUserInterface()

        tsmiSystem.Text = m_ResourceManager.GetString("frmMDIMain.mnuSys")
        tsmiSystemLogin.Text = m_ResourceManager.GetString("frmMDIMain.mnuSysLogin")
        tsmiSystemLogout.Text = m_ResourceManager.GetString("frmMDIMain.mnuSysLogout")
        tsmiSystemChangePassword.Text = m_ResourceManager.GetString("frmMDIMain.mnuSysChangePassword")
        tsmiSystemExit.Text = m_ResourceManager.GetString("frmMDIMain.mnuSysExit")

        tsmiLanguage.Text = m_ResourceManager.GetString("frmMDIMain.mnuLanguage")
        tsmiLanguageVietnamese.Text = m_ResourceManager.GetString("frmMDIMain.mnuLangVietnamese")
        tsmiLanguageEnglish.Text = m_ResourceManager.GetString("frmMDIMain.mnuLangEnglish")

        tsmiHelp.Text = m_ResourceManager.GetString("frmMDIMain.mnuHelp")
        tsmiHelpUserManual.Text = m_ResourceManager.GetString("frmMDIMain.mnuHelpUserManual")
        tsmiHelpAbout.Text = m_ResourceManager.GetString("frmMDIMain.mnuHelpAbout")

        tbtTransaction.Text = m_ResourceManager.GetString("TRANSACTION_CODE")
        tbtTransaction.VirtualTextBox.ForeColor = Color.Chocolate

        Select Case m_BusLayer.AppLanguage
            Case gc_LANG_VIETNAMESE
                tsmiLanguageVietnamese.Checked = True
                tsmiLanguageEnglish.Checked = False
            Case gc_LANG_ENGLISH
                tsmiLanguageVietnamese.Checked = False
                tsmiLanguageEnglish.Checked = True
        End Select

        Dim sToolTip = New SuperToolTip()
        sToolTip.Items.Add(m_ResourceManager.GetString("frmMDIMain.sbrPanelBranch"))
        sbrPanelBranch.SuperTip = sToolTip

        Dim sToolTipUser = New SuperToolTip()
        sToolTipUser.Items.Add(m_ResourceManager.GetString("frmMDIMain.sbrPanelUser"))
        sbrPanelUser.SuperTip = sToolTipUser

        Dim sToolTipStatus = New SuperToolTip()
        sToolTipStatus.Items.Add(m_ResourceManager.GetString("frmMDIMain.sbrPanelStatus"))
        sbrPanelStatus.SuperTip = sToolTipStatus

        Dim sToolTipDateTime = New SuperToolTip()
        sToolTipDateTime.Items.Add(m_ResourceManager.GetString("frmMDIMain.sbrPanelDateTime"))
        sbrPanelDateTime.SuperTip = sToolTipDateTime

    End Sub

    Private Sub ShowTransact()

        Try
            Dim frm As New frmTransactMaster(m_BusLayer.AppLanguage)
            Dim v_lngErrCode As Long
            Dim v_strAllowObjMsg As String

            Dim v_strTLTXCD, v_strTXCODE, v_strCmdInquiry As String
            Dim v_strModeCode As String = String.Empty
            v_strTLTXCD = tbtTransaction.VirtualTextBox.Text
            If v_strTLTXCD.Length > 2 Then
                v_strTXCODE = v_strTLTXCD.Substring(0, 2)
            End If

            'Check transaction allowed of current teller 

            If hTransAllowed(Trim(v_strTLTXCD)) Is Nothing Then
                v_lngErrCode = ERR_SA_TRANSACT_CMDALLOW
            End If
            Dim v_strTlRight, v_strMaker As String
            v_strTlRight = m_BusLayer.CurrentTellerProfile.TellerRight
            If v_strTlRight <> String.Empty Then
                v_strMaker = Mid(v_strTlRight, 1, 1)
                If v_strMaker <> "Y" Then
                    v_lngErrCode = ERR_SA_CRTUSR_NOTTELLER
                    ''Thông báo lỗi
                    'Dim v_strErrorSource, v_strErrorMessage As String
                    'GetErrorFromMessage(v_strAllowObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                    'Cursor.Current = Cursors.Default
                    'MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, Me.Text)
                    'Exit Sub
                End If
            End If


            'v_strAllowObjMsg = BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , m_BusLayer.CurrentTellerProfile.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strTlType & "|" & v_strTLTXCD, "CheckTransAllow", )
            'Dim v_wsAllow As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'v_lngErrCode = v_wsAllow.Message(v_strAllowObjMsg)

            If v_lngErrCode = ERR_SYSTEM_OK Then
                'v_strCmdInquiry = "SELECT MODCODE FROM APPMODULES WHERE TXCODE='" & v_strTXCODE & "'"
                v_strCmdInquiry = "SELECT MODCODE FROM APPMODULES,TLTX WHERE TXCODE='" & v_strTXCODE & "' AND SUBSTR(TLTX.TLTXCD,0,2)=APPMODULES.TXCODE AND TLTX.TLTXCD='" & Trim(v_strTLTXCD) & "' AND TLTX.DIRECT='Y'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_ws.Message(v_strObjMsg)

                Dim v_xmlDocument As New System.Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_nodeEntry As Xml.XmlNode
                Dim v_strFLDNAME As String
                Dim v_strValue As String

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "MODCODE"
                                    v_strModeCode = Trim(v_strValue)
                                    Exit For
                            End Select
                        End With
                    Next
                Next
                If Len(Trim(v_strModeCode)) > 0 Then
                    frm.ObjectName = tbtTransaction.VirtualTextBox.Text
                    frm.ModuleCode = v_strModeCode
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                    frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                    frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                    frm.IpAddress = m_BusLayer.AppIpAddress
                    frm.WsName = m_BusLayer.AppWsName
                    frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                    'frm.mv_SignMode = Me.mv_SignMode
                    'frm.m_CurrCAToken = Me.m_CurrCAToken
                    'frm.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                    frm.ShowDialog()
                Else
                    'Thông báo giao dịch phải qua tra cứu
                    MessageBox.Show("Giao dịch này phải thực hiện thông qua màn hình tra cứu !")
                End If
            Else
                'Thông báo lỗi
                Dim v_strErrorSource, v_strErrorMessage As String
                If v_strAllowObjMsg Is Nothing Then
                    MessageBox.Show("Bạn không có quyền thực hiện giao dịch này ! Liên hệ quản trị hệ thống !")
                Else
                    GetErrorFromMessage(v_strAllowObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

            End If


        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        End Try
    End Sub


    Private Function GetTellerRight() As String
        Try
            Dim v_strTellerRight As String
            If m_BusLayer.CurrentTellerProfile.TellerRight <> String.Empty Then
                v_strTellerRight = m_BusLayer.CurrentTellerProfile.TellerRight
                'If Teller does not have any right (maker, cashier,...)
                If v_strTellerRight = "NNNN" Then
                    Dim v_strObjMsg, v_strFLDNAME, v_strValue As String
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim XmlDocument As New Xml.XmlDocument

                    v_strObjMsg = CommonLibrary.BuildXMLObjMsg(Now.Date, m_BusLayer.CurrentTellerProfile.BranchId, Now.Date,
                                    m_BusLayer.CurrentTellerProfile.TellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                                    OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , m_BusLayer.CurrentTellerProfile.TellerId, "GetTellerRight")
                    m_BusLayer.BusSystemMessage(v_strObjMsg)

                    XmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                    If v_nodeList.Count = 1 Then
                        If v_nodeList.Item(0).ChildNodes.Count = 1 Then
                            With v_nodeList.Item(0).ChildNodes(0)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString

                                Select Case Trim(v_strFLDNAME)
                                    Case "GRPRIGHT"
                                        v_strTellerRight = Trim(v_strValue)
                                End Select
                            End With
                        End If
                    End If
                End If
            Else
                v_strTellerRight = "NNNN"
            End If

            Return v_strTellerRight
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetGroupCareBy() As String
        Try
            Dim v_strGroupCareBy, v_strGroupId, v_strGroupName As String
            Dim v_strObjMsg, v_strFLDNAME, v_strValue, v_strSQL, v_strTellerId As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim XmlDocument As New Xml.XmlDocument

            v_strTellerId = m_BusLayer.CurrentTellerProfile.TellerId

            v_strObjMsg = CommonLibrary.BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , v_strTellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                                    OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , , "GetGroupCareBy")
            m_BusLayer.BusSystemMessage(v_strObjMsg)
            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    v_strGroupId = Trim(v_strValue)
                                Case "DISPLAY"
                                    v_strGroupName = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    v_strGroupCareBy &= v_strGroupId & "|" & v_strGroupName & "#"
                Next
            End If

            Return v_strGroupCareBy
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetTellerGroup() As String
        Try
            Dim v_strTellerGroup, v_strGroupId, v_strGroupName As String
            Dim v_strObjMsg, v_strFLDNAME, v_strValue, v_strSQL, v_strTellerId As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim XmlDocument As New Xml.XmlDocument

            v_strTellerId = m_BusLayer.CurrentTellerProfile.TellerId

            v_strObjMsg = CommonLibrary.BuildXMLObjMsg(, m_BusLayer.CurrentTellerProfile.BranchId, , v_strTellerId, CommonLibrary.gc_IsLocalMsg, CommonLibrary.gc_MsgTypeObj,
                                    OBJNAME_SY_AUTHENTICATION, CommonLibrary.gc_ActionInquiry, , , "GetTellerGroup")
            m_BusLayer.BusSystemMessage(v_strObjMsg)
            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    v_strGroupId = Trim(v_strValue)
                                Case "DISPLAY"
                                    v_strGroupName = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    v_strTellerGroup &= v_strGroupId & "|"
                Next
            End If

            Return v_strTellerGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ComputeUpTime()
        Dim nTicks As Double
        Dim nDays As Integer
        Dim nHours As Integer
        Dim nMin As Integer
        Dim nSec As Integer
        Dim TimeUp As String

        nTicks = tickCount
        nTicks = nTicks / 1000
        'nDays = Int(nTicks / (3600 * 24))
        nTicks = nTicks - (Int(nTicks / (3600 * 24)) * (3600 * 24))
        nHours = Int(nTicks / 3600)
        nTicks = nTicks - (Int(nTicks / 3600) * 3600)
        nMin = Int(nTicks / 60)
        nTicks = nTicks - (Int(nTicks / 60) * 60)
        nSec = nTicks
        'Label6.Text = Environment.TickCount
        sbrPanelDateTime.Caption = m_BusLayer.CurrentTellerProfile.BusDate & " - " _
            & Now.ToString("HH:mm:ss") '& Format$(nHours, "00") & ":" & Format$(nMin, "00") & ":" & Format$(nSec, "00")
        tickCount += 1000
    End Sub

    'Private Sub GetPhoneNumberFromCallCenter()
    '    If v_strTELEORDER = "Y" Then

    '        Dim wsCallCenter As New CallCenterService.SCABSServiceSoapClient
    '        Dim v_strNewCallNumber As String
    '        Try
    '            v_strNewCallNumber = wsCallCenter.GetCallingnumber(m_BusLayer.CurrentTellerProfile.TellerExtTel)
    '            'v_strNewCallNumber = "0979562387"
    '            If v_strNewCallNumber Is Nothing Then
    '            Else
    '                If v_strNewCallNumber <> v_strCallNumber Then
    '                    v_strCallNumber = v_strNewCallNumber
    '                    ShowMainScreen(v_strCallNumber)
    '                End If
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub


#End Region

#Region " Form events "
    Private Sub tmrMain_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrMain.Tick
        ComputeUpTime()
    End Sub



    Private Sub mnuSysExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiSystemExit.Click
        'If MsgBox(m_ResourceManager.GetString("EXIT_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then
        If XtraMessageBox.Show(m_ResourceManager.GetString("EXIT_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Dispose()
            End
        End If
    End Sub

    Private Sub mnuSysLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiSystemLogout.Click
        If MsgBox(m_ResourceManager.GetString("LOGOUT_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then

            ChangeOnlineStatus(False)
            'Invisible TLLOG search & transaction code menu
            ucSearchTLLOG.Visible = False
            tbtTransaction.Visible = False
            hMenuFunction.Clear()
            m_blnAllowBrokerDesk = False
            m_blnAllowTeleOrder = False
            m_blnAllowCreateDeal = False
            m_blnAllowForceSell = False

        End If
    End Sub

    Private Sub mnuSysLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiSystemLogin.Click
        If Not DisplayLoginForm() = DialogResult.Cancel Then
            hMenuFunction.Clear()
            ChangeOnlineStatus(True)
            LoadCasheInfo()
            ucSearchTLLOG.IsLocalSearch = gc_IsLocalMsg
            ucSearchTLLOG.UserLanguage = m_BusLayer.AppLanguage
            ucSearchTLLOG.SearchOnInit = False
            ucSearchTLLOG.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
            ucSearchTLLOG.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
            ucSearchTLLOG.TellerType = m_BusLayer.CurrentTellerProfile.TellerRight
            ucSearchTLLOG.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
            ucSearchTLLOG.TellerGroup = m_BusLayer.CurrentTellerProfile.TellerGroup
            ucSearchTLLOG.AccessArea = m_BusLayer.CurrentTellerProfile.AccessArea
            ucSearchTLLOG.LoadInterface()
            'ucSearchTLLOG.OnSearch(gc_IsLocalMsg, "SY.TLLOG")
            ucSearchTLLOG.Visible = True
            tbtTransaction.Visible = True
        End If
    End Sub

    Private Sub mnuHelpUserManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiHelpUserManual.Click
        MsgBox("Xin lỗi quý vị! Hiện tại, chức năng này chưa được xây dựng.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiHelpAbout.Click
        Dim v_frm As New frmAbout
        'Dim v_frm As New frmBRGRP(m_BusLayer.AppLanguage)

        v_frm.ShowDialog()
    End Sub

    Private Sub mnuLangVietnamese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiLanguageVietnamese.Click
        If Not tsmiLanguageVietnamese.Checked Then
            If MsgBox(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then
                '1. Save setting into the registry
                Dim version_pro_uat = System.Configuration.ConfigurationSettings.AppSettings("version_pro_uat")
                Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey + version_pro_uat)
                v_regKey.SetValue(gc_REG_LANG, gc_LANG_VIETNAMESE)
                v_regKey.Close()

                '2. Exit the application
                End
            End If
        End If
    End Sub

    Private Sub mnuLangEnglish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiLanguageEnglish.Click
        If Not tsmiLanguageEnglish.Checked Then
            If MsgBox(m_ResourceManager.GetString("CHANGE_LANGUAGE_CONFIRMATION"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.Yes Then
                '1. Save setting into the registry
                Dim version_pro_uat = System.Configuration.ConfigurationSettings.AppSettings("version_pro_uat")
                Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey + version_pro_uat)
                v_regKey.SetValue(gc_REG_LANG, gc_LANG_ENGLISH)
                v_regKey.Close()

                '2. Exit the application
                End
            End If
        End If
    End Sub

    Private Sub mnuSysChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiSystemChangePassword.Click
        Dim v_objChangePassword As New frmChangePassword
        v_objChangePassword.UserLanguage = m_BusLayer.AppLanguage
        v_objChangePassword.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
        v_objChangePassword.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
        v_objChangePassword.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
        v_objChangePassword.BranchName = m_BusLayer.CurrentTellerProfile.BranchName
        v_objChangePassword.ShowDialog()
    End Sub

    Private Sub tbtTransaction_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbtTransaction.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                If m_BusLayer.CurrentTellerProfile.BusDate <> getCurrdate() Then
                    MsgBox("Ngày của máy trạm và ngày của máy chủ khác nhau, hãy đăng nhập lại!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    ChangeOnlineStatus(False)
                    'Invisible TLLOG search & transaction code menu
                    ucSearchTLLOG.Visible = False
                    tbtTransaction.Visible = False
                    hMenuFunction.Clear()
                    m_blnAllowBrokerDesk = False
                    m_blnAllowTeleOrder = False
                    m_blnAllowCreateDeal = False
                    m_blnAllowForceSell = False

                    barManager.MainMenu.ClearLinks()

                    Dim v_mnuLogin As New BarSubItemEx(barManager, "Đăng Nhập")
                    'Dim v_mnuLogIN As New MenuItemEx("Đăng Nhập")
                    v_mnuLogin.Key = "xxxxxx|A|SA|LOGIN|YYYYYYYYYY|YYYY|"
                    v_mnuLogin.ItemShortcut = New BarShortcut(GetShortcut("F2"))
                    v_mnuLogin.ImageIndex = 4
                    v_mnuLogin.Alignment = BarItemLinkAlignment.Right
                    barMainMenu.AddItem(v_mnuLogin)
                    AddHandler v_mnuLogin.ItemClick, AddressOf Me.BarSubItemClick
                    Exit Sub
                End If
                Dim v_refKey, v_arrMenuKey() As String
                v_refKey = tbtTransaction.VirtualTextBox.Text
                If IsNumeric(v_refKey) Then
                    If Not hTreeMnViewCodeMap(v_refKey) Is Nothing Then
                        If Not hMenuFunction(hTreeMnViewCodeMap(v_refKey)) Is Nothing Then
                            v_arrMenuKey = hMenuFunction(hTreeMnViewCodeMap(v_refKey))
                            ExecuteMenuFunction(v_arrMenuKey)
                            Exit Sub
                        Else
                            If m_BusLayer.AppLanguage <> "EN" Then
                                MsgBox("Chức năng không tồn tại, không được gọi trực tiếp hoặc bạn không đủ quyền sử dụng chức năng này!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                            Else
                                MsgBox("The requested function is invalid!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                            End If
                            Exit Sub
                        End If
                    End If
                    'Kich hoat loi goi tu menu function: Giá trị trong TextBox là MenuKey


                    If Not hMenuFunction(v_refKey) Is Nothing Then
                        v_arrMenuKey = hMenuFunction(v_refKey)
                        ExecuteMenuFunction(v_arrMenuKey)
                    Else
                        If m_BusLayer.AppLanguage <> "EN" Then
                            MsgBox("Chức năng không tồn tại, không được gọi trực tiếp hoặc bạn không đủ quyền sử dụng chức năng này!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                        Else
                            MsgBox("The requested function is invalid!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                        End If
                        Exit Sub
                    End If
                Else
                    'Kiểm tra có phải là báo cáo không
                    v_refKey = v_refKey.ToUpper
                    If v_refKey.Length <= 9 Then
                        If Not hRptMaster(v_refKey) Is Nothing Then
                            v_arrMenuKey = hRptMaster(v_refKey).ToString.Split("|")
                            If v_arrMenuKey(0) = "V" Then
                                If (v_arrMenuKey(3) <> "PO" And v_arrMenuKey(3) <> "SSE" And v_arrMenuKey(3) <> "LNTYPECHG") Then
                                    Dim frmSearch As New frmSearchMaster(m_BusLayer.AppLanguage)
                                    frmSearch.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                    frmSearch.TableName = v_refKey.Substring(1)
                                    frmSearch.ModuleCode = v_arrMenuKey(1)
                                    frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép gọi chức năng tạo giao dịch kế tiếp (Choose)

                                    Dim v_strObjName As String
                                    v_strObjName = v_refKey.Substring(1, v_refKey.Length - 1)
                                    If v_strObjName = "OD8829" Then
                                        frmSearch.AuthCode = "NYNNYYYNNY" 'Chỉ cho phép gọi chức năng tạo giao dịch kế tiếp (Choose)
                                    End If
                                    If InStr("DF3001,DF3002,DF3003,DF3004,DF5009,MR0001,MR0003,MR0002,MR1001,MR1002,MR1003", v_strObjName) Then
                                        frmSearch.AuthString = "YYYY"
                                    End If


                                    If v_strObjName = "OD9995" Then
                                        frmSearch.SEQNUM = True
                                    End If
                                    ' end of PhuongHT add 

                                    frmSearch.CMDTYPE = v_arrMenuKey(0)
                                    frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                                    frmSearch.SearchOnInit = False
                                    frmSearch.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                    frmSearch.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                    frmSearch.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                                    frmSearch.IpAddress = m_BusLayer.AppIpAddress
                                    frmSearch.WsName = m_BusLayer.AppWsName
                                    frmSearch.mv_strCMDID = v_strObjName
                                    frmSearch.SymbolList = mv_strSYMBOLLIST
                                    frmSearch.SymbolTable = mv_strSymbolTable
                                    frmSearch.CELLSDEFINETable = mv_strCELLSDEFINETable
                                    frmSearch.Show()
                                End If
                            ElseIf v_arrMenuKey(0) = "R" Then
                                'Gọi màn hình ReportList và truyền vào mã báo cáo được chọn
                                Dim frm As New frmReportMaster_Tab(m_BusLayer.AppLanguage)
                                frm.ModuleCode = v_arrMenuKey(1)
                                frm.RPTID = v_refKey.Substring(1)
                                frm.LocalObject = gc_IsLocalMsg
                                frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                                frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                                frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                                frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                                frm.TableName = v_arrMenuKey(1)
                                frm.CMDID = v_arrMenuKey(1)
                                frm.ShowDialog()
                                tbtTransaction.VirtualTextBox.Text = ""
                            Else
                                If m_BusLayer.AppLanguage <> "EN" Then
                                    MsgBox("Chức năng không tồn tại, không được gọi trực tiếp hoặc bạn không đủ quyền sử dụng chức năng này!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                                Else
                                    MsgBox("The requested function is invalid!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                                End If
                                Exit Sub
                            End If
                        Else
                            If m_BusLayer.AppLanguage <> "EN" Then
                                MsgBox("Chức năng không tồn tại, không được gọi trực tiếp hoặc bạn không đủ quyền sử dụng chức năng này!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                            Else
                                MsgBox("The requested function is invalid!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                            End If
                            Exit Sub
                        End If
                    End If
                    tbtTransaction.VirtualTextBox.Text = ""
                End If
            Case Keys.F5
                Dim frm As New AppCore.frmLookUp(m_BusLayer.AppLanguage)
                Dim v_intPos As Integer, ctl As Control
                frm.SQLCMD = "SELECT TLTXCD VALUECD, TLTXCD VALUE, TXDESC DISPLAY, EN_TXDESC EN_DISPLAY, EN_TXDESC DESCRIPTION FROM TLTX WHERE DIRECT='Y' ORDER BY VALUE"
                frm.ShowDialog()
                If Not frm.RETURNDATA Is Nothing Then
                    v_intPos = InStr(frm.RETURNDATA, vbTab)
                    If v_intPos > 0 Then
                        Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                    End If
                    frm.Dispose()
                End If
        End Select
    End Sub



#End Region

#Region " MDI Form events "
    Private Sub frmMDIMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim smtNode As New Xceed.SmartUI.Controls.TreeView.Node
        Dim v_arrMenuKey() As String

        Try

            Select Case e.KeyCode
                Case Keys.F2

                Case Keys.F4

                Case Keys.F7

                Case Keys.H
                    If e.Control Then
                        'Me.tbtTransaction.VirtualTextBox.
                        stbMain.Focus()
                        'tbtTransaction.Focused()
                    End If
                Case Keys.F12

                Case Keys.Escape
                    Dim page As XtraTabPage = xtraTabControlModule.SelectedTabPage
                    If (page IsNot Nothing And page.ShowCloseButton <> DefaultBoolean.False) Then
                        xtraTabControlModule.TabPages.Remove(page)
                        xtraTabControlModule.Update()
                    End If
            End Select
        Catch ex As Exception
            LogError.Write("Error source: frmMDIMain.frmMDIMain_KeyUp" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'Hien thi man hinh nhac viec

        'Always show the Form
        'Dim frm As New frmALERT(m_BusLayer.AppLanguage)
        'frm.TableName = v_strObjName
        'frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
        'frm.ModuleCode = v_strModCode
        'frm.ObjectName = "SA.ALERT"
        'frm.UserLanguage = m_BusLayer.AppLanguage
        'frm.TellerID = m_BusLayer.CurrentTellerProfile.TellerId
        'frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
        'frm.ShowDialog()
    End Sub

    Private Sub Notify_ItemClick(sender As Object, e As ItemClickEventArgs)
        If (e.Item.Tag IsNot Nothing) Then
            If e.Item.Tag.ToString.Length < 10 Then
                'ExecuteMenuFunction(hMenuFunction(e.Item.Tag))
                Dim frm As New frmSearchMaster(m_BusLayer.AppLanguage)
                Dim collection As CriteriaOperatorCollection = New CriteriaOperatorCollection()
                If e.Item.Description <> "" And e.Item.Name <> "" Then 'trung.luu: 14-01-2021 auto fileter khi mo menu tu nut notify
                    Dim mc() As String = Regex.Split(e.Item.Name, ",")
                    For Each m As String In mc
                        Dim v_operator As CriteriaOperator = New BinaryOperator(e.Item.Description, m)
                        collection.Add(v_operator)
                    Next m
                    frm.mv_CriteriaOperator_Notify = collection
                    frm.mv_AutoFilter = True
                End If

                frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
                frm.NextDate = m_BusLayer.CurrentTellerProfile.NextDate
                frm.TableName = hMenuFunction(e.Item.Tag)(3)
                frm.ModuleCode = hMenuFunction(e.Item.Tag)(2)
                frm.MenuType = hMenuFunction(e.Item.Tag)(1)
                frm.AuthCode = hMenuFunction(e.Item.Tag)(4)
                frm.AuthString = hMenuFunction(e.Item.Tag)(5)
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.CELLSDEFINETable = mv_strCELLSDEFINETable
                frm.COUNTRYTable = mv_strCOUNTRYTable
                frm.mv_strCMDID = hMenuFunction(e.Item.Tag)(0)
                frm.SearchOnInit = True
                frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                frm.TellerName = m_BusLayer.CurrentTellerProfile.TellerName
                frm.TellerRight = m_BusLayer.CurrentTellerProfile.TellerRight
                frm.GroupCareBy = m_BusLayer.CurrentTellerProfile.TellerGroupCareBy
                frm.IpAddress = m_BusLayer.AppIpAddress
                frm.WsName = m_BusLayer.AppWsName
                frm.CompanyCode = m_BusLayer.CurrentTellerProfile.CompanyCode
                frm.CompanyName = m_BusLayer.CurrentTellerProfile.CompanyName
                frm.Show()
            Else
                OnView(e.Item.Tag, m_BusLayer.CurrentTellerProfile.BusDate, m_BusLayer.CurrentTellerProfile.TellerId)
                ucSearchTLLOG.Search()
            End If
        End If
    End Sub

    Private Sub btnNotify_Popup(sender As Object, e As EventArgs) Handles btnNotify.Popup
        'threadNotify.Change(-1, -1)
    End Sub

    Private Sub btnNotify_CloseUp(sender As Object, e As EventArgs) Handles btnNotify.CloseUp
        'threadNotify.Change(1000, 1000)
    End Sub

    Protected Overridable Function OnView(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, ByVal pv_strOffName As String)
        Try
            Dim v_strTXNUM, v_strTXDATE, v_strTLTXCD As String
            'Trung.luu: 31-03-2020
            v_strTXNUM = pv_strTxNum
            v_strTXDATE = pv_strTxDate
            'Hiển thị lên màn hình giao dịch
            Dim frm As New frmXtraTransactMaster(m_BusLayer.AppLanguage)
            frm.LocalObject = gc_IsNotLocalMsg
            frm.ObjectName = ""
            frm.TxDate = v_strTXDATE
            frm.TxNum = v_strTXNUM
            frm.BusDate = m_BusLayer.CurrentTellerProfile.BusDate
            frm.TellerType = m_BusLayer.CurrentTellerProfile.TellerRight
            frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
            frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
            frm.Txstatuscd = "4"
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'trung.luu: 10-07-2020 option close tab mouse right click
    Private Sub xtraTabControlModule_MouseDown(sender As Object, e As MouseEventArgs) Handles xtraTabControlModule.MouseDown
        Try
            Dim info = xtraTabControlModule.CalcHitInfo(e.Location)
            If (info IsNot Nothing AndAlso info.HitTest = DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader AndAlso e.Button = Windows.Forms.MouseButtons.Right) Then
                btnclose.Caption = m_ResourceManager.GetString("tabclose")
                btncloseother.Caption = m_ResourceManager.GetString("tabcloseother")
                btncloseright.Caption = m_ResourceManager.GetString("tabcloseright")
                btncloseall.Caption = m_ResourceManager.GetString("closeall")
                PopupMenuClose.ShowPopup(Control.MousePosition)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnclose.ItemClick
        Try
            Dim page As XtraTabPage = xtraTabControlModule.SelectedTabPage
            Dim index As Integer
            If (page IsNot Nothing And page.ShowCloseButton <> DefaultBoolean.False) Then
                index = xtraTabControlModule.SelectedTabPageIndex
                xtraTabControlModule.TabPages.Remove(page)
                xtraTabControlModule.SelectedTabPageIndex = index - 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncloseother_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btncloseother.ItemClick
        Try
            Dim index As Integer = xtraTabControlModule.SelectedTabPageIndex
            For value As Integer = 0 To xtraTabControlModule.TabPages.Count - 1
                If value <> index Then
                    xtraTabControlModule.SelectedTabPageIndex = value
                    Dim page As XtraTabPage = xtraTabControlModule.SelectedTabPage
                    If (page IsNot Nothing And page.ShowCloseButton <> DefaultBoolean.False) Then
                        xtraTabControlModule.TabPages.Remove(page)
                    End If
                End If
            Next value
            xtraTabControlModule.SelectedTabPageIndex = index
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncloseright_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btncloseright.ItemClick
        Try
            Dim index As Integer = xtraTabControlModule.SelectedTabPageIndex
            For value As Integer = index To xtraTabControlModule.TabPages.Count - 1
                If value > index Then
                    xtraTabControlModule.SelectedTabPageIndex = value
                    Dim page As XtraTabPage = xtraTabControlModule.SelectedTabPage
                    If (page IsNot Nothing And page.ShowCloseButton <> DefaultBoolean.False) Then
                        xtraTabControlModule.TabPages.Remove(page)
                    End If
                End If
            Next value
            xtraTabControlModule.SelectedTabPageIndex = index
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncloseall_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btncloseall.ItemClick
        Try
            DelegateUtil.DlgModuleAction(DelegateUtil.EACTION.CLEAR, Nothing)
            AddSearchToTabControl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tmrAFK_Tick(sender As Object, e As EventArgs) Handles tmrAFK.Tick
        remainingConnectionTimeToHost = remainingConnectionTimeToHost - 1

        If remainingConnectionTimeToHost = 0 Then
            XtraMessageBox.Show(m_ResourceManager.GetString("LIMIT_SECONDS_AFK"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Logout()
        End If
    End Sub
    'end trung.luu: 10-07-2020
End Class

