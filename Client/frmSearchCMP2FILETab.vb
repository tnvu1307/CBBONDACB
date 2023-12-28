Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports Microsoft
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Configuration
Imports ExcelLibrary
Imports AppCore
'Imports DataAccessLayer

''Imports Xceed.Grid
''Imports ExcelLibrary.SpreadSheet

Public Class frmSearchCMP2FILETab
    'Inherits System.Windows.Forms.Form
    Inherits FormBase

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeComponent()
        LoadResource(Me)
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
    Private WithEvents GridEx1 As AppCore.GridEx
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents DataTable5 As System.Data.DataTable
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents DataTable10 As System.Data.DataTable
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
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents DataTable43 As System.Data.DataTable
    Friend WithEvents DataTable44 As System.Data.DataTable
    Friend WithEvents DataTable45 As System.Data.DataTable
    Friend WithEvents DataTable46 As System.Data.DataTable
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataTable93 As System.Data.DataTable
    Friend WithEvents DataTable92 As System.Data.DataTable
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GridEx1 = New AppCore.GridEx()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable9 = New System.Data.DataTable()
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
        Me.DataTable42 = New System.Data.DataTable()
        Me.DataTable43 = New System.Data.DataTable()
        Me.DataTable44 = New System.Data.DataTable()
        Me.DataTable45 = New System.Data.DataTable()
        Me.DataTable46 = New System.Data.DataTable()
        Me.DataTable92 = New System.Data.DataTable()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.DataTable93 = New System.Data.DataTable()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable92, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DataTable93, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridEx1
        '
        Me.GridEx1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridEx1.ForeColor = System.Drawing.Color.Black
        Me.GridEx1.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GridEx1.InactiveSelectionForeColor = System.Drawing.Color.Black
        Me.GridEx1.Location = New System.Drawing.Point(0, 0)
        Me.GridEx1.Name = "GridEx1"
        Me.GridEx1.ReadOnly = True
        '
        '
        '
        Me.GridEx1.RowSelectorPane.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.GridEx1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GridEx1.SelectionForeColor = System.Drawing.Color.Black
        Me.GridEx1.TabIndex = 0
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
        'DataTable5
        '
        Me.DataTable5.Namespace = ""
        Me.DataTable5.TableName = "COMBOBOX"
        '
        'DataTable6
        '
        Me.DataTable6.Namespace = ""
        Me.DataTable6.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'DataTable9
        '
        Me.DataTable9.Namespace = ""
        Me.DataTable9.TableName = "COMBOBOX"
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
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'DataTable43
        '
        Me.DataTable43.Namespace = ""
        Me.DataTable43.TableName = "COMBOBOX"
        '
        'DataTable44
        '
        Me.DataTable44.Namespace = ""
        Me.DataTable44.TableName = "COMBOBOX"
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
        'DataTable92
        '
        Me.DataTable92.Namespace = ""
        Me.DataTable92.TableName = "COMBOBOX"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.panel2)
        Me.Panel3.Controls.Add(Me.panel1)
        Me.Panel3.Location = New System.Drawing.Point(12, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1208, 649)
        Me.Panel3.TabIndex = 26
        '
        'panel2
        '
        Me.panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel2.AutoScroll = True
        Me.panel2.AutoSize = True
        Me.panel2.Location = New System.Drawing.Point(12, 222)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(1184, 423)
        Me.panel2.TabIndex = 26
        '
        'panel1
        '
        Me.panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.AutoScroll = True
        Me.panel1.AutoSize = True
        Me.panel1.Location = New System.Drawing.Point(12, 12)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1184, 203)
        Me.panel1.TabIndex = 25
        '
        'DataTable93
        '
        Me.DataTable93.Namespace = ""
        Me.DataTable93.TableName = "COMBOBOX"
        '
        'frmSearchCMP2FILETab
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(1232, 673)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmSearchCMP2FILETab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "frmSearchCMP2FILE"
        Me.Text = "frmSearchCMP2FILE"
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable92, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataTable93, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Property"
    Const c_ResourceManager = gc_RootNamespace & "." & "frmSearchCMP2FILETab-"
    Const PREFIXED_MSKDATA = "mskData"
    Private mv_strCmdMenu As String
    Private mv_strFileName As String = String.Empty
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strModuleCode As String
    Private mv_strSearchcode As String
    Private mv_strLanguage As String = "VN"
    Private mv_strIsLocalSearch As String
    Private mv_strAuthCode As String
    Private mv_strWsName As String
    Private mv_strIpAddress As String
    Private mv_strBusDate As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strDesc As String
    Private mv_strISRPT As String = "N"
    Private mv_strObjname As String
    Private mv_strRptID As String
    Private mv_strReportDirectory As String
    Private mv_strReportTempDirectory As String
    Private mv_strGroupCareBy As String
    Private mv_strIsFixPara As String
    Private mv_strInitPara As String

    Dim v_frmRptParameter As New frmReportParameter()
    Dim v_frmCMP As New frmSearchCMP2FILE(UserLanguage, v_frmRptParameter)

    Public Property CMDMenu() As String
        Get
            Return mv_strCmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strCmdMenu = Value
        End Set
    End Property

    Public Property RptID() As String
        Get
            Return mv_strRptID
        End Get
        Set(ByVal Value As String)
            mv_strRptID = Value
        End Set
    End Property

    Public Property ISRPT() As String
        Get
            Return mv_strISRPT
        End Get
        Set(ByVal Value As String)
            mv_strISRPT = Value
        End Set
    End Property

    Public Property Desc() As String
        Get
            Return mv_strDesc
        End Get
        Set(ByVal Value As String)
            mv_strDesc = Value
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
    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
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
    Public Property Searchcode() As String
        Get
            Return mv_strSearchcode
        End Get
        Set(ByVal Value As String)
            mv_strSearchcode = Value
        End Set
    End Property
    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
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

    Public Property ObjectName() As String
        Get
            Return mv_strObjname
        End Get
        Set(ByVal value As String)
            mv_strObjname = value
        End Set
    End Property

    Public Property ReportDirectory() As String
        Get
            Return mv_strReportDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportDirectory = Value
        End Set
    End Property


    Public Property ReportTempDirectory() As String
        Get
            Return mv_strReportTempDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportTempDirectory = Value
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

    Public Property IsFixPara() As String
        Get
            Return mv_strIsFixPara
        End Get
        Set(ByVal Value As String)
            mv_strIsFixPara = Value
        End Set
    End Property

    Public Property InitPara() As String
        Get
            Return mv_strInitPara
        End Get
        Set(ByVal Value As String)
            mv_strInitPara = Value
        End Set
    End Property
#End Region

#Region " Form methods "
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                'CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmSearchCMP2FILE." & v_ctrl.Name)
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString("frmSearchCMP2FILETab")
    End Sub
#End Region

#Region "Form event"

#End Region

#Region "Private Sub"

#End Region


    Private Sub frmSearchCMP2FILETab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "[" + CMDMenu + "] " + Desc

        'load form paramaster
        LoadRptDetail()

        'load form compare
        LoadFrmCMP()

    End Sub

    Private Sub LoadRptDetail()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_intCountCol, v_intCountRow As Integer
            Dim v_ListViewItem As ListViewItem

            v_strSQL = "SELECT * FROM RPTMASTER WHERE RPTID = '" + RptID + "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strSQL, , )
            v_ws.Message(v_strObjMsg)

            Dim v_nodeList As Xml.XmlNodeList
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
                            Case "ISLOCAL"
                                v_frmRptParameter.LocalObject = Trim(v_strValue)
                            Case "EN_DESCRIPTION"
                                If UserLanguage = "EN" Then
                                    v_frmRptParameter.ReportTitle = Trim(v_strValue)
                                End If
                            Case "DESCRIPTION"
                                If UserLanguage <> "EN" Then
                                    v_frmRptParameter.ReportTitle = Trim(v_strValue)
                                End If
                            Case "STOREDNAME"
                                v_frmRptParameter.StoredName = Trim(v_strValue)
                            Case "ISCAREBY"
                                v_frmRptParameter.IsCareBy = Trim(v_strValue)
                            Case "SUBRPT"
                                v_frmRptParameter.IsSubRPT = Trim(v_strValue)
                            Case "ISCMP"
                                v_frmRptParameter.ISCMP = Trim(v_strValue)
                            Case "AD_HOC"
                                v_frmRptParameter.ISADHOC = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            v_frmRptParameter.BranchId = BranchId
            v_frmRptParameter.ModuleCode = ModuleCode
            v_frmRptParameter.ObjectName = RptID
            v_frmRptParameter.TellerId = TellerId
            v_frmRptParameter.BranchName = BranchId
            v_frmRptParameter.Teller = TellerId
            v_frmRptParameter.CMDID = RptID
            v_frmRptParameter.UserLanguage = UserLanguage
            v_frmRptParameter.ReportDirectory = ReportDirectory
            v_frmRptParameter.ReportTempDirectory = ReportTempDirectory
            v_frmRptParameter.BusDate = BusDate
            v_frmRptParameter.GroupCareBy = GroupCareBy
            v_frmRptParameter.ReportArea = IIf(Me.BranchId = HO_MBID, gc_REPORT_AREA_ALL, gc_REPORT_AREA_BRANCH)
            v_frmRptParameter.IsFixPara = Me.IsFixPara
            v_frmRptParameter.InitPara = Me.InitPara
            v_frmRptParameter.TopLevel = False
            v_frmRptParameter.Visible = False
            v_frmRptParameter.Show()

            Dim RptParaDetail As Panel = v_frmRptParameter.GetPnRptParaDetail()
            RptParaDetail.BorderStyle = BorderStyle.None
            RptParaDetail.Height = RptParaDetail.Height - 150
            RptParaDetail.Location = panel1.Location 'New Point((panel1.Width - RptParaDetail.Width) / 2, (panel1.Height - RptParaDetail.Height) / 2)

            panel1.Controls.Add(RptParaDetail)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFrmCMP()
        Try
            v_frmRptParameter.PrepareReportParams2(String.Empty)
            v_frmCMP.FULLDATA = "RPT"
            v_frmCMP.Searchcode = v_frmRptParameter.StoredName
            v_frmCMP.ModuleCode = ModuleCode
            v_frmCMP.BranchId = BranchId
            v_frmCMP.TellerId = TellerId
            v_frmCMP.IpAddress = IpAddress
            v_frmCMP.WsName = WsName
            v_frmCMP.BusDate = BusDate
            v_frmCMP.Desc = v_frmRptParameter.ReportTitle
            v_frmCMP.ISRPT = "Y"
            v_frmCMP.mv_strStoredname = v_frmRptParameter.StoredName
            v_frmCMP.mv_intNumOfParam = v_frmRptParameter.getIntNumOfParam()
            v_frmCMP.mv_arrRptParam = v_frmRptParameter.getArrRptParam()
            v_frmCMP.TopLevel = False
            v_frmCMP.Location = panel2.Location 'New Point((panel1.Width - v_frmCMP.Width) / 2, (panel1.Height - v_frmCMP.Height) / 2)
            v_frmCMP.Dock = DockStyle.Fill
            v_frmCMP.ControlBox = False
            v_frmCMP.ShowInTaskbar = False
            v_frmCMP.FormBorderStyle = Windows.Forms.FormBorderStyle.None

            v_frmCMP.Show()
            panel2.Controls.Add(v_frmCMP)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSearchCMP2FILETab_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer

        Dim mv_arrObjFields() As CFieldMaster
        mv_arrObjFields = v_frmRptParameter.mv_arrObjFields

        Dim pnRptParaDetail As Panel = v_frmRptParameter.GetPnRptParaDetail()

        Select Case e.KeyCode
            Case Keys.F5
                If InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                    v_intIndex = Me.ActiveControl.Tag
                    'Tra cứu thông tin
                    If Len(v_frmRptParameter.mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        'Dim frm As New frmSearch(Me.UserLanguage)
                        Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                        frm.TableName = mv_arrObjFields(v_intIndex).SearchCode
                        frm.ModuleCode = mv_arrObjFields(v_intIndex).SrModCode
                        frm.LinkValue = v_frmRptParameter.GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField) 'mv_Keyvalue
                        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                        frm.IsLocalSearch = gc_IsNotLocalMsg
                        frm.IsLookup = "Y"
                        frm.SearchOnInit = False
                        frm.BranchId = Me.BranchId
                        frm.TellerId = Me.TellerId
                        frm.ShowDialog()
                        Me.ActiveControl.Text = frm.ReturnValue
                        If Len(frm.RefValue) > 0 Then
                            ctl = pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                            ctl.Top = Me.ActiveControl.Top
                            ctl.Text = frm.RefValue
                            ctl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            ctl.ForeColor = System.Drawing.Color.Blue
                            ctl.Visible = True
                        End If
                        frm.Dispose()

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            ctl = pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                            ctl.Top = Me.ActiveControl.Top
                            ctl.Text = Mid(frm.RETURNDATA, v_intPos + 1)
                            ctl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            ctl.ForeColor = System.Drawing.Color.Blue
                            ctl.Visible = True

                            'Nạp các giá trị tương ứng cho các trư?ng kh�ác
                            strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                            '  FillLookupData(strFLDNAME, Mid(frm.RETURNDATA, 1, v_intPos - 1), frm.FULLDATA)
                        End If
                        frm.Dispose()
                    End If
                End If
            Case Keys.Enter
                If InStr(CType(Me.ActiveControl, Control).Name, PREFIXED_MSKDATA) > 0 Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                End If
        End Select
    End Sub
End Class

