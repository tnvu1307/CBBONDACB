Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports DevExpress.XtraGrid.Columns
Imports AppCore

Public Class frmLookUp_Tab
    Inherits FormBase
    'Public v_dtgLookupData As New GridEx

#Region " Declare constant and variables "
    Const c_ResourceManager = gc_RootNamespace & "." & "frmLookup_Tab-"
    Const WIDTH_GRID_LOOKUP = 550

    'Const SEARCH_OPTION_BEGIN = "SearchOption.BeginWith"
    'Const SEARCH_OPTION_CONTAINS = "SearchOption.Contains"

    Private mv_blnAutoClosed As Boolean = False
    Private mv_blnAcceptedClose As Boolean = True
    Private mv_blnisReconcile As Boolean = False
    Private mv_strCaption As String
    Private mv_strSQLCommand As String
    Private mv_strReturnData As String
    Private mv_strAuthcode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strXMLData As String
    Private mv_strAFtypeData As String
    Friend WithEvents grcLookup As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvLookup As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Private mv_strIsLocalSearch As String
    Protected mv_strGroupCareBy As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_SessionID As String
    Private mv_strBusDate As String
    Protected mv_strSymbolList As String
    Protected mv_SymbolTable As New DataTable
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Protected mv_strTableName As String
    Public mv_strCMDID As String
    Private mv_MenuTag As String
    Public mv_strCELLSDEFINETable As New DataTable


#End Region

#Region " Properties "

    Public Property CELLSDEFINETable() As DataTable
        Get
            Return mv_strCELLSDEFINETable
        End Get
        Set(ByVal Value As DataTable)
            mv_strCELLSDEFINETable = Value
        End Set
    End Property

    Public Property isReconcile() As Boolean
        Get
            Return mv_blnisReconcile
        End Get
        Set(ByVal Value As Boolean)
            mv_blnisReconcile = Value
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

    Public Property AcceptedClose() As Boolean
        Get
            Return mv_blnAcceptedClose
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAcceptedClose = Value
        End Set
    End Property

    Public Property AutoClosed() As Boolean
        Get
            Return mv_blnAutoClosed
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAutoClosed = Value
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

    Public Property CAPTION() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property SQLCMD() As String
        Get
            Return mv_strSQLCommand
        End Get
        Set(ByVal Value As String)
            mv_strSQLCommand = Value
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

    Public Property AuthCode() As String
        Get
            Return mv_strAuthcode
        End Get
        Set(ByVal Value As String)
            mv_strAuthcode = Value
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

    Public Property AFtypeData() As String
        Get
            Return mv_strAFtypeData
        End Get
        Set(ByVal Value As String)
            mv_strAFtypeData = Value
        End Set
    End Property

    Public Property MenuTag() As String
        Get
            Return mv_MenuTag
        End Get
        Set(ByVal Value As String)
            mv_MenuTag = Value
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
    Public Property SessionID() As String
        Get
            Return mv_SessionID
        End Get
        Set(ByVal value As String)
            mv_SessionID = value
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

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property CMDID() As String
        Get
            Return mv_strCMDID
        End Get
        Set(ByVal Value As String)
            mv_strCMDID = Value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents pnLookup As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.pnLookup = New System.Windows.Forms.Panel()
        Me.grcLookup = New DevExpress.XtraGrid.GridControl()
        Me.grvLookup = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.pnLookup.SuspendLayout()
        CType(Me.grcLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(414, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCANCEL.Location = New System.Drawing.Point(498, 5)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 23)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnLookup
        '
        Me.pnLookup.BackColor = System.Drawing.SystemColors.Control
        Me.pnLookup.Controls.Add(Me.grcLookup)
        Me.pnLookup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnLookup.Location = New System.Drawing.Point(0, 0)
        Me.pnLookup.Name = "pnLookup"
        Me.pnLookup.Size = New System.Drawing.Size(594, 408)
        Me.pnLookup.TabIndex = 5
        '
        'grcLookup
        '
        Me.grcLookup.Cursor = System.Windows.Forms.Cursors.Default
        Me.grcLookup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grcLookup.Location = New System.Drawing.Point(0, 0)
        Me.grcLookup.MainView = Me.grvLookup
        Me.grcLookup.Name = "grcLookup"
        Me.grcLookup.Size = New System.Drawing.Size(594, 408)
        Me.grcLookup.TabIndex = 0
        Me.grcLookup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvLookup})
        '
        'grvLookup
        '
        Me.grvLookup.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvLookup.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvLookup.GridControl = Me.grcLookup
        Me.grvLookup.Name = "grvLookup"
        Me.grvLookup.OptionsBehavior.Editable = False
        Me.grvLookup.OptionsBehavior.ReadOnly = True
        Me.grvLookup.OptionsView.ShowAutoFilterRow = True
        Me.grvLookup.OptionsView.ShowFooter = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.btnCANCEL)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 33)
        Me.Panel1.TabIndex = 6
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
        'frmLookUp_Tab
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(594, 408)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnLookup)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLookUp_Tab"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLookup"
        Me.TopMost = True
        Me.pnLookup.ResumeLayout(False)
        CType(Me.grcLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvLookup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
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
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiáº¿t láº­p cÃ¡c thuá»™c tÃ­nh ban Ä‘áº§u cho form
        DoResizeForm()

        'Náº¡p dá»¯ liá»‡u hiá»ƒn thá»‹ thÃ´ng tin tra cá»©u
        'If Len(Trim(SQLCMD)) > 0 Then
        LoadLookupData()
        'End If
        grcLookup.Dock = DockStyle.Fill
    End Function

    Private Sub LoadLookupData()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String

        Try
            'Create message to inquiry object fields
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
            'If lookup data is ACTYPE in AFMAST
            If Trim(AFtypeData) <> String.Empty Then
                v_strObjMsg = AFtypeData
            Else
                If Trim(SQLCMD) <> String.Empty Then
                    If mv_strIsLocalSearch = "Y" Then
                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, SQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                    Else
                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, SQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                    End If
                End If
            End If

            'LÆ°u trá»¯ danh sÃ¡ch tÃ¬m kiáº¿m tráº£ vá»?
            FULLDATA = v_strObjMsg

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim i, j As Integer

            'Hiá»ƒn thá»‹ toÃ n bá»™ ná»™i dung cá»§a dá»¯ liá»‡u tÃ¬m kiáº¿m tráº£ vá»?
            If v_nodeList.Count > 0 Then
                'Táº¡o Header cá»§a Grid
                For j = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                        Dim gridColumn As GridColumn = New GridColumn()
                        gridColumn.FieldName = v_strFLDNAME
                        gridColumn.Name = v_strFLDNAME
                        gridColumn.VisibleIndex = j
                        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                gridColumn.Visible = False
                            Case "VALUECD"
                                gridColumn.Width = 0.5 * WIDTH_GRID_LOOKUP / 10
                                If UserLanguage <> "EN" Then
                                    gridColumn.Caption = mv_ResourceManager.GetString("VALUECD")
                                End If
                            Case "DESCRIPTION"
                                gridColumn.Width = 0.5 * WIDTH_GRID_LOOKUP / 10
                                If UserLanguage <> "EN" Then
                                    gridColumn.Caption = mv_ResourceManager.GetString("DESCRIPTION")
                                End If
                            Case "DISPLAY"
                                If UserLanguage = "EN" Then
                                    gridColumn.Visible = False
                                Else
                                    gridColumn.Width = 7 * WIDTH_GRID_LOOKUP / 10
                                    gridColumn.Caption = mv_ResourceManager.GetString("DISPLAY")
                                End If
                            Case "EN_DISPLAY"
                                If UserLanguage <> "EN" Then
                                    gridColumn.Visible = False
                                Else
                                    gridColumn.Width = 5 * WIDTH_GRID_LOOKUP / 10
                                End If
                            Case Else
                                gridColumn.Visible = False
                        End Select

                        grvLookup.Columns.Add(gridColumn)
                    End With
                Next
                Dim dt As DataTable = ObjDataToDataset(v_strObjMsg)
                For Each r As DataRow In dt.Rows
                    If (dt.Columns.Contains("VALUE") And dt.Columns.Contains("DESCRIPTION")) Then
                        r("VALUE") += ControlChars.Tab & r("DESCRIPTION")
                    End If
                Next
                grcLookup.DataSource = dt
                grcLookup.Dock = DockStyle.Fill
                'v_dtgLookupData.DataRows.Clear()
                'v_dtgLookupData.BeginInit()
                'For i = 0 To v_nodeList.Count - 1
                '    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgLookupData.DataRows.AddNew()
                '    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                '        With v_nodeList.Item(i).ChildNodes(j)
                '            v_strValue = Trim(.InnerText)
                '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                '            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                '            Select Case Trim(v_strFLDNAME)
                '                Case "VALUE"
                '                    v_strTEXT = v_strValue
                '                Case "DESCRIPTION"
                '                    v_strTEXT = v_strTEXT & ControlChars.Tab & v_strValue
                '            End Select
                '        End With
                '    Next
                '    'DÃ¹ng Ä‘á»ƒ tráº£ vá»? giÃ¡ trá»‹ RETURNDATA cho form lookup
                '    v_xDataRow.Cells("VALUE").Value = v_strTEXT
                '    v_xDataRow.EndEdit()
                'Next
                'v_dtgLookupData.EndInit()
                'Me.pnLookup.Controls.Add(v_dtgLookupData)

                ''Tá»± Ä‘á»™ng Ä‘Ã³ng mÃ n hÃ¬nh náº¿u chá»‰ cÃ³ 01 báº£n ghi vÃ  AutoClosed=True
                'If v_nodeList.Count = 1 And AutoClosed Then
                '    OnAccept()
                'End If
                'pnLookup.Select()
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        OnAccept()
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    OnAccept()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OnClose()
        Me.CloseTab()
    End Sub

    Private Sub OnAccept()
        Dim dt As DataTable = grcLookup.DataSource
        If dt IsNot Nothing And dt.Rows.Count > 0 Then
            'Current row
            Dim drv As DataRowView = grvLookup.GetFocusedRow()
            If drv IsNot Nothing Then
                Me.RETURNDATA = drv.Row("VALUE")
            End If
        End If
        DisplayGeneralView()
    End Sub

    Private Sub OnSearch()
        'Dim v_blnItemFound As Boolean = False
        'Dim v_intIndex As Int16, v_strText As String = Trim(txtSearch.Text)
        'Dim v_intOldIndex As Integer = v_dtgLookupData.DataRows.IndexOf(v_dtgLookupData.CurrentRow)
        'Dim v_strValue As String

        'If (v_strText.Length > 0) Then
        '    Select Case cboSearchOption.SelectedValue
        '        Case SEARCH_OPTION_BEGIN
        '            For v_intIndex = v_intOldIndex + 1 To v_dtgLookupData.DataRows.Count - 1
        '                v_strValue = CType(v_dtgLookupData.DataRows(v_intIndex), Xceed.Grid.DataRow).Cells("VALUECD").Value.ToString().ToUpper()

        '                If (v_strValue.IndexOf(v_strText.ToUpper) = 0) Then
        '                    v_dtgLookupData.CurrentRow = v_dtgLookupData.DataRows.Item(v_intIndex)
        '                    v_dtgLookupData.SelectedRows.Clear()
        '                    v_dtgLookupData.SelectedRows.Add(v_dtgLookupData.CurrentRow)
        '                    For i As Integer = 0 To v_dtgLookupData.DataRows.IndexOf(v_dtgLookupData.CurrentRow) - v_intOldIndex - 1
        '                        v_dtgLookupData.Scroll(Xceed.Grid.ScrollDirection.Down)
        '                    Next i
        '                    v_blnItemFound = True
        '                    Exit For
        '                End If
        '            Next v_intIndex
        '        Case SEARCH_OPTION_CONTAINS
        '            For v_intIndex = v_intOldIndex + 1 To v_dtgLookupData.DataRows.Count - 1
        '                If InStr(UCase(CType(v_dtgLookupData.DataRows(v_intIndex), Xceed.Grid.DataRow).Cells("VALUE").Value), UCase(v_strText)) > 0 _
        '                    Or InStr(UCase(CType(v_dtgLookupData.DataRows(v_intIndex), Xceed.Grid.DataRow).Cells("DESCRIPTION").Value), UCase(v_strText)) > 0 Then
        '                    v_dtgLookupData.CurrentRow = v_dtgLookupData.DataRows.Item(v_intIndex)
        '                    v_dtgLookupData.SelectedRows.Clear()
        '                    v_dtgLookupData.SelectedRows.Add(v_dtgLookupData.CurrentRow)
        '                    For i As Integer = 0 To v_dtgLookupData.DataRows.IndexOf(v_dtgLookupData.CurrentRow) - v_intOldIndex - 1
        '                        v_dtgLookupData.Scroll(Xceed.Grid.ScrollDirection.Down)
        '                    Next
        '                    v_blnItemFound = True
        '                    Exit For
        '                End If
        '            Next v_intIndex
        '    End Select

        '    If (Not v_blnItemFound) Then
        '        If (MessageBox.Show(mv_ResourceManager.GetString("frmLookup.SearchConfirm"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
        '            'Move to the top of list
        '            v_dtgLookupData.Scroll(Xceed.Grid.ScrollDirection.TopPage)
        '            v_dtgLookupData.CurrentRow = v_dtgLookupData.DataRows.Item(0)
        '            v_dtgLookupData.SelectedRows.Clear()
        '            v_dtgLookupData.SelectedRows.Add(v_dtgLookupData.CurrentRow)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmLookup." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmLookup." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmLookup." & v_ctrl.Name)
            End If
        Next

        btnCANCEL.Text = mv_ResourceManager.GetString("frmLookup.btnCANCEL")
        btnOK.Text = mv_ResourceManager.GetString("frmLookup.btnOK")

        Me.Text = mv_ResourceManager.GetString("frmLookup")
    End Sub
#End Region

#Region " Form events "
    Private Sub frmLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmLookUp_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnAccept()
    End Sub

    Private Sub frmLookUp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
                'Case Keys.Enter
                '    If Me.ActiveControl.Name = "txtSearch" Then
                '        If Len(Trim(CType(Me.ActiveControl, TextBox).Text)) > 0 Then
                '            OnSearch()
                '        End If
                '    End If
        End Select
    End Sub
#End Region

    Private Sub grvLookup_DoubleClick(sender As Object, e As EventArgs) Handles grvLookup.DoubleClick
        OnAccept()
    End Sub

    Private Sub DisplayGeneralView()

        Dim v_intPos As Integer, v_strRETURNDATA, v_strObjName, v_strModCode, v_strCMDTYPE, v_strSTOREDNAME As String
        Dim strFrmRETURNDATA As String

        If Not Me.RETURNDATA Is Nothing Then
            strFrmRETURNDATA = Me.RETURNDATA
            v_intPos = InStr(strFrmRETURNDATA, vbTab)
        End If

        If strFrmRETURNDATA.Length <> 0 OrElse MenuTag.Length <> 0 Then
            If v_intPos > 0 OrElse MenuTag.Length <> 0 Then
                If MenuTag.Length <> 0 Then
                    v_strRETURNDATA = MenuTag
                Else
                    v_strRETURNDATA = Mid(Me.RETURNDATA, 1, v_intPos - 1)
                End If
                Dim v_arrRETURNDATA As String()
                v_arrRETURNDATA = v_strRETURNDATA.Split(".")
                v_strModCode = v_arrRETURNDATA(0)
                v_strObjName = v_arrRETURNDATA(1)
                v_strCMDTYPE = v_arrRETURNDATA(2)
                v_strSTOREDNAME = v_arrRETURNDATA(3)

                Dim frmSearch As New frmSearchMaster(UserLanguage)
                frmSearch.BusDate = Me.BusDate
                frmSearch.TableName = v_strObjName
                frmSearch.CMDMenu = v_strObjName
                frmSearch.ModuleCode = v_strModCode
                frmSearch.GroupCareBy = Me.GroupCareBy
                frmSearch.CMDMenu = v_strObjName
                'frmSearch.COUNTRYTable = mv_strCOUNTRYTable
                'frmSearch.CELLSDEFINETable = mv_strCELLSDEFINETable
                'frmSearch.PROVINCETable = mv_strPROVINCETable
                frmSearch.mv_strCMDID = v_strObjName
                'frmSearch.SessionID = m_BusLayer.CurrentTellerProfile.SessionID
                'frmSearch.MacAddress = m_BusLayer.CurrentTellerProfile.MacAddress
                frmSearch.AuthCode = "NYNNYYYNNY" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                frmSearch.CMDTYPE = v_strCMDTYPE
                frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                frmSearch.SearchOnInit = False
                frmSearch.BranchId = Me.BranchId
                frmSearch.TellerId = Me.TellerId
                frmSearch.IpAddress = Me.IpAddress
                frmSearch.WsName = Me.WsName
                frmSearch.SymbolList = Me.SymbolList
                frmSearch.SymbolTable = Me.SymbolTable
                frmSearch.CELLSDEFINETable = Me.CELLSDEFINETable
                frmSearch.Show()
                'Trung.luu: 04-04-2020 gọi generalview rồi thì không popup lại form lookup nữa 
                'DisplayGeneralView(pv_ModuleCode)
            End If

        End If

    End Sub

End Class
