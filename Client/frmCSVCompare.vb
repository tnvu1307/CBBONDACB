Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports AppCore
Imports AppCore.modCoreLib
Imports System
Imports System.Threading
Imports DevExpress.XtraEditors
'Imports Xceed.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCSVCompare
    'Inherits System.Windows.Forms.Form
    Inherits FormBase

#Region " Declare constant and variables "
    Const c_ResourceManager = gc_RootNamespace & "." & "frmCSVCompare-"
    Const c_statusSYSTEMNULL = "SYSTEMNULL"
    Const c_statusVSDNULL = "VSDNULL"
    Const c_statusDEVIATION = "DEVIATION"
    Const c_statusNDEVIATION = "NDEVIATION"
    Const c_fnVIEWCSV = "VIEWCSV"
    Const c_fnCOMPARE = "COMPARE"
    Const c_fnQUERY = "QUERY"
    Const c_svWrite = "WRITE"
    Const c_svAPPRV = "APPROVE"
    Const c_svEXPORT = "EXPORT"

    'Public v_frm As frmTransact
    Public v_frm As frmXtraTransact
    Private ResultGrid As GridEx
    Private v_statusCol As String
    Private mDelimiterRows As Char = "|"
    Private mDelimiterItems As Char = "~"
    Private v_searchcode As String = ""
    Private mv_strObjname As String = "ST.CSVCMP"
    Private mv_ApprvoAllow As Boolean = False
    Private mv_AllowImport As Boolean = False
    Private mv_currFunction As String = c_fnCOMPARE
    Private mv_currSaveFN As String = c_svWrite
    Private mv_tltxcd As String = String.Empty
    Private mv_intErrCount As Integer = 0
    Private mv_Req_Date As String = String.Empty

    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strBusDate As String
    Private mv_strModCode As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strCMPcode As String
    Private mv_strCurrCMPCODE As String
    Private mv_strCurrFileName As String
    Private mv_strCsvAutoid As String
    Private mv_strCMPfunc As String
    Private mv_hadImport As String
    Private mv_cmpFileName As String
    Private mv_strChoosingDate As String
    Private mv_intSystem_col As Integer = 2
    Private mv_intVsd_col As Integer = 3
    Private mv_intDeviation_col As Integer = 4
    Private mv_max_row_per_time As Integer = 5000
    Private mv_blnADHOCFORMULAR As Boolean = False
    Private mv_strADHOCFORMULAR_FNC As String = "GET_CSVREPORT_FORMULARFIELD"

    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "SHEET1"
    Private mv_intROWTITLE As String = "1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_intPAGE As String = "0"
    Private mv_strSaveTableName As String
    Private mv_strSaveTableName_hist As String
    Private mv_strOVRRQD As String
    Private mv_strVSDRPTID As String
    Private mv_strVSDID As String
    Private mv_strTRADEPLACE As String

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u ki�ện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u ki�ện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Private mv_arrSrFieldSrch() As String                       'T�ên các trư?ng l�àm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng s�ẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Gía trị mặc định

    Private mv_arrSrFieldFormat() As String                     '?�ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     '?�ộ rộng hiển thị trên lưới

    Private mv_arrStFieldMandartory() As String
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '

    Private mv_strAccessArea As String = ""
    Private mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Private mv_strCmdSql As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean
    Private mv_searchObjname As String

#End Region
#Region " Properties "
    Public Property SAVECODE() As String
        Get
            Return mv_strCurrCMPCODE
        End Get
        Set(ByVal value As String)
            If mv_strCurrCMPCODE = value Then
                Return
            End If
            mv_strCurrCMPCODE = value
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
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal value As String)
            mv_strLanguage = value
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
    Public Property ModuleCode() As String
        Get
            Return mv_strModCode
        End Get
        Set(ByVal value As String)
            mv_strModCode = value
        End Set
    End Property
    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal value As String)
            mv_strLocalObject = value
        End Set
    End Property
    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal value As String)
            mv_strBranchId = value
        End Set
    End Property
    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal value As String)
            mv_strTellerId = value
        End Set
    End Property
    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal value As String)
            mv_strIpAddress = value
        End Set
    End Property
    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal value As String)
            mv_strWsName = value
        End Set
    End Property
    Public Property CMPCODE() As String
        Get
            Return mv_strCMPcode
        End Get
        Set(ByVal value As String)
            mv_strCMPcode = value
        End Set
    End Property
    Public Property CMPFUNC() As String
        Get
            Return mv_strCMPfunc
        End Get
        Set(ByVal value As String)
            mv_strCMPfunc = value
        End Set
    End Property
    Public Property FILENAME() As String
        Get
            Return mv_strCurrFileName
        End Get
        Set(ByVal value As String)
            mv_strCurrFileName = value
        End Set
    End Property
    Public Property CsvAutoid() As String
        Get
            Return mv_strCsvAutoid
        End Get
        Set(ByVal value As String)
            mv_strCsvAutoid = value
        End Set
    End Property
#End Region
#Region "Init form"
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

    End Sub
    Private Sub InitializeGrid()
        GridDetail = New DevExpress.XtraGrid.GridControl
        GridDetail.MainView = GridvDetail
        pnDetail.Controls.Clear()
        pnDetail.Controls.Add(GridDetail)
        GridDetail.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            Try
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
                ElseIf TypeOf (v_ctrl) Is DateEdit Then
                    CType(v_ctrl, DateEdit).EditValue = CDate(Me.BusDate)
                End If
            Catch ex As Exception
            End Try
        Next
        Try
            Me.Text = mv_ResourceManager.GetString(Me.Name)
        Catch ex As Exception

        End Try

    End Sub
    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDetail = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnApprv = New System.Windows.Forms.Button()
        Me.DataTable33 = New System.Data.DataTable()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridvDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1174, 69)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.047211!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.95279!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnExecute, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFileName, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFileName, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(120, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(933, 63)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecute.Location = New System.Drawing.Point(763, 29)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(167, 30)
        Me.btnExecute.TabIndex = 12
        Me.btnExecute.Text = "Xác nhận"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(3, 6)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(69, 13)
        Me.lblFileName.TabIndex = 9
        Me.lblFileName.Tag = "lblFileName"
        Me.lblFileName.Text = "Ten file"
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.BackColor = System.Drawing.Color.Lime
        Me.txtFileName.Location = New System.Drawing.Point(78, 3)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(852, 21)
        Me.txtFileName.TabIndex = 14
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.pnDetail, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 78)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 412.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1174, 412)
        Me.TableLayoutPanel5.TabIndex = 14
        '
        'pnDetail
        '
        Me.pnDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDetail.Location = New System.Drawing.Point(23, 3)
        Me.pnDetail.Name = "pnDetail"
        Me.pnDetail.Size = New System.Drawing.Size(1128, 406)
        Me.pnDetail.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.15871!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.84129!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.btnExport, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnApprv, 4, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 496)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1174, 31)
        Me.TableLayoutPanel6.TabIndex = 15
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(1036, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(98, 25)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "Kết xuất"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnApprv
        '
        Me.btnApprv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprv.Location = New System.Drawing.Point(925, 3)
        Me.btnApprv.Name = "btnApprv"
        Me.btnApprv.Size = New System.Drawing.Size(105, 25)
        Me.btnApprv.TabIndex = 14
        Me.btnApprv.Text = "Duyệt"
        Me.btnApprv.UseVisualStyleBackColor = True
        '
        'DataTable33
        '
        Me.DataTable33.Namespace = ""
        Me.DataTable33.TableName = "COMBOBOX"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1180, 530)
        Me.TableLayoutPanel2.TabIndex = 16
        '
        'GridDetail
        '
        Me.GridDetail.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDetail.Location = New System.Drawing.Point(2, 21)
        Me.GridDetail.MainView = Me.GridvDetail
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.Size = New System.Drawing.Size(1361, 578)
        Me.GridDetail.TabIndex = 0
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridvDetail})
        '
        'GridvDetail
        '
        Me.GridvDetail.GridControl = Me.GridDetail
        Me.GridvDetail.Name = "GridvDetail"
        Me.GridvDetail.OptionsSelection.MultiSelect = True
        Me.GridvDetail.OptionsView.ShowFooter = True
        Me.GridvDetail.OptionsView.ShowGroupPanel = False
        '
        'frmCSVCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 530)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "frmCSVCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CSVCompare"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region
#Region "Init Param"

#End Region
#Region "Form event"

    Private Sub btnCompare_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewCompare()
    End Sub
    Private Sub btnWrite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case mv_currSaveFN
            Case c_svWrite
                SaveCompare()
            Case c_svAPPRV
                ApprvRouter()
        End Select
    End Sub

    Private Sub frmCSVCompare_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


    Private Sub frmCSVCompare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadResource(Me)
        Me.btnExecute.Enabled = False
        Me.Text = mv_ResourceManager.GetString("CSVCompare")
        mv_strChoosingDate = BusDate
        InitializeGrid()
    End Sub

#End Region
#Region "Form function"
    Private Sub ApprvRouter()
        Dim v_strFLDDEFVAL, v_strMODCODE As String

        Try
            v_strFLDDEFVAL = ""
            If Not Me.txtFileName.Text Is Nothing Then
                If mv_strVSDRPTID.IndexOf("CA") <> -1 Then
                    mv_tltxcd = "1510"
                    v_strFLDDEFVAL = "[01." & mv_strVSDRPTID & "][22." & Me.txtFileName.Text & "][03." & mv_strVSDID & "][02." & mv_strTRADEPLACE & "]"
                End If
                If mv_strVSDRPTID.IndexOf("DE") <> -1 Then
                    mv_tltxcd = "1509"
                    v_strFLDDEFVAL = "[01." & mv_strVSDRPTID & "][03." & Me.txtFileName.Text & "][20." & mv_strVSDID & "]"
                End If

                If mv_strVSDRPTID.IndexOf("CS") <> -1 Then
                    mv_tltxcd = "1515"
                    v_strFLDDEFVAL = "[01." & mv_strVSDRPTID & "][03." & Me.txtFileName.Text & "]"
                End If

                Dim v_ws As BDSDeliveryManagement = New BDSDeliveryManagement
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_strValue, v_strFLDNAME, v_total As String
                Dim v_strSQL, v_strObjMsg As String

                Try
                    v_total = "0"
                    v_strSQL = "SELECT COUNT(1) TOTAL FROM ALLCODE WHERE CDNAME = 'RPTID' AND CDTYPE = 'ST' AND CDVAL = '{1}'"
                    v_strSQL = String.Format(v_strSQL, mv_strChoosingDate, mv_strVSDRPTID)
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strValue = Trim(.InnerText.ToString)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "TOTAL"
                                            v_total = v_strValue.Trim
                                    End Select
                                End With
                            Next
                        Next
                    End If
                Catch ex As Exception
                    v_total = "0"
                End Try

                If v_total = "0" Then
                    Return
                End If

            End If
            v_strMODCODE = "ST"
            ' End Select
            If mv_tltxcd.Length() <> 0 And v_strFLDDEFVAL.Length <> 0 Then
                v_frm = New frmXtraTransactMaster(mv_strLanguage)
                v_frm.ObjectName = mv_tltxcd
                v_frm.ModuleCode = v_strMODCODE
                v_frm.LocalObject = gc_IsNotLocalMsg
                v_frm.BranchId = Me.BranchId
                v_frm.TellerId = Me.TellerId
                v_frm.IpAddress = Me.IpAddress
                v_frm.WsName = Me.WsName
                v_frm.BusDate = Me.BusDate
                v_frm.DefaultValue = v_strFLDDEFVAL
                v_frm.AutoClosedWhenOK = True
                v_frm.ShowDialog()
                v_frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub resetScreen()
        If Not GridDetail Is Nothing Then
            GridDetail.Dispose()
        End If
        'If mv_currFunction = c_fnCOMPARE Or mv_currFunction = c_fnQUERY Then
        'If v_searchcode.Length > 0 Then
        GridDetail = New DevExpress.XtraGrid.GridControl
        Me.pnDetail.Controls.Clear()
        Me.pnDetail.Controls.Add(GridDetail)
        GridDetail.Dock = Windows.Forms.DockStyle.Fill
        ' End If
        'lblSummary.Visible = False
        'End If
        'btnWrite.Enabled = False
    End Sub
    Private Sub GetCMPInfo(ByVal pv_strFile As String)
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strTEXT, v_strValue, v_strFLDNAME As String
        Try
            mv_blnADHOCFORMULAR = False
            Dim v_strSQL As String
            Dim v_strObjMsg As String
            v_ws = New BDSDeliveryManagement
            If pv_strFile.Length > 0 Then
                v_strSQL = String.Format("SELECT * FROM csvCompare WHERE cmpid = '{0}'", pv_strFile)
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME).ToUpper
                                Case "CMPID"
                                    mv_strCMPfunc = v_strValue.Trim
                                Case "IMPORTALLOW"
                                    mv_AllowImport = IIf(v_strValue.Trim = "Y", True, False)
                                Case "SEARCHCODE"
                                    v_searchcode = v_strValue.Trim
                                Case "STATUSCOL"
                                    v_statusCol = v_strValue.Trim
                                Case "APPRVOALLOW"
                                    mv_ApprvoAllow = IIf(v_strValue.Trim = "Y", True, False)
                                Case "TLTXCD"
                                    mv_tltxcd = v_strValue.Trim
                                Case "ADHOCFORMULAR"
                                    mv_blnADHOCFORMULAR = IIf(v_strValue.Trim = "Y", True, False)
                            End Select
                        End With
                    Next
                Next
                If mv_strCMPfunc.Length = 0 Then
                    'Me.btnCompare.Enabled = False
                    'Me.btnWrite.Enabled = False
                Else
                    'Me.btnCompare.Enabled = True
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.GetCMPInfo" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("Đối chiếu chưa hỗ trợ", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ViewCompare()
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String
        Dim v_strDMA, v_strSYSTEM, v_strVSD, v_strDEVISION As String
        Dim v_strClause As String
        Dim v_strErr_Code As String

        Try
            Dim grvDetail As DevExpress.XtraGrid.Views.Grid.GridView = GridDetail.MainView
            Cursor.Current = Cursors.WaitCursor
            Dim v_strErrorSource, v_strErrorMessage, v_strtitle As String
            mv_cmpFileName = txtFileName.Text
            v_strClause = CMPCODE & mDelimiterItems & mv_cmpFileName
            v_ws = New BDSDeliveryManagement

            'build message doi chieu
            Dim v_totalRow As Integer = 1, v_from_row = 1, v_to_row = 0, v_pageNum = 1
            Dim v_hasmore As Boolean = True, v_firstPage As Boolean = True
            While v_hasmore
                If v_pageNum = 1 Then
                    v_from_row = 1
                    v_to_row = v_from_row + mv_max_row_per_time
                Else
                    v_from_row = v_to_row + 1
                    v_to_row = v_from_row + mv_max_row_per_time
                End If

                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , v_strClause, "getCompare", , , v_from_row & "^" & v_to_row, IpAddress, , , , )
                v_strErr_Code = v_ws.Message(v_strObjMsg)
                If v_strErr_Code <> ERR_SYSTEM_OK Then
                    MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                v_xmlDocument.LoadXml(v_strObjMsg)
                If v_pageNum > 1 Then
                    v_firstPage = False
                End If
                Dim v_RowCount As Integer = 0
                FillDataXtraGrid(GridDetail, v_strObjMsg, "", v_firstPage, v_RowCount)
                If grvDetail.RowCount = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("noCompareData"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    v_hasmore = False
                End If
                If v_RowCount = 0 Or v_RowCount < mv_max_row_per_time Then
                    v_hasmore = False
                Else
                    v_pageNum += 1
                End If
            End While
            SAVECODE = CMPCODE
            formatGrid()
            If grvDetail.RowCount > 0 Then
                'btnWrite.Enabled = True
            End If

        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.ViewCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GetStringByFilter(ByVal dt As DataTable, ByVal strexp As String) As String
        Try
            Dim foundRows As Data.DataRow()
            foundRows = dt.Select(strexp)
            Return foundRows(0)("VALUE").ToString()
        Catch ex As Exception
            LogError.Write("Error source: GetStringByFilter" & strexp & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return ""
        End Try
    End Function

    Private Sub SaveCompare()
        Dim v_ws As BDSDeliveryManagement
        Dim v_strObjMsg As String
        Dim v_strClause, v_strErrorSource, v_strErrorMessage, v_strtitle As String
        Dim v_fromRow As Integer = 0, v_toRow As Integer = 0, v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_reference As String
        Try
            Dim grvDetail As DevExpress.XtraGrid.Views.Grid.GridView = GridDetail.MainView
            v_ws = New BDSDeliveryManagement
            If grvDetail.RowCount = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf MessageBox.Show(mv_ResourceManager.GetString("issave") & mv_strVSDRPTID & "?", gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                v_strClause = SAVECODE & mDelimiterItems & mv_cmpFileName

                v_ws = New BDSDeliveryManagement
                While v_hasmore
                    If v_pageNum = 1 Then
                        v_fromRow = 1
                    Else
                        v_fromRow = v_toRow + 1
                    End If
                    v_toRow = v_fromRow + mv_max_row_per_time
                    v_reference = buildSaveClause(v_fromRow, v_toRow, v_hasmore)
                    v_strObjMsg = BuildXMLObjMsg(mv_strChoosingDate, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , SAVECODE, "saveCompare", v_pageNum, , v_reference, , IpAddress, , , )

                    v_ws.Message(v_strObjMsg)
                    v_pageNum += 1
                End While
                If mv_AllowImport Then
                    v_strObjMsg = BuildXMLObjMsg(mv_strChoosingDate, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , SAVECODE, "apprvImport", , , v_reference, , IpAddress, , , )
                    v_ws.Message(v_strObjMsg)
                End If
                MessageBox.Show(mv_ResourceManager.GetString("saveComplete"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.ViewCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("Lỗi hệ thống!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function buildSaveClause(ByVal pv_FromRow As Integer, _
                                    ByVal pv_ToRow As Integer, _
                                    ByRef pv_hasmore As Boolean) As String
        Dim v_saveClase As String = String.Empty
        Dim grvDetail As DevExpress.XtraGrid.Views.Grid.GridView = GridDetail.MainView
        Dim v_RowsCount = grvDetail.RowCount
        Dim v_CellCount = grvDetail.GetRow(0).Cells.Count
        Dim v_fromRow = pv_FromRow - 1
        Dim v_toRow As Integer = Math.Min(pv_ToRow, v_RowsCount) - 1

        pv_hasmore = IIf(pv_ToRow - pv_FromRow > v_toRow - v_fromRow, False, True)
        Dim v_columnName, v_value As String
        For i As Integer = v_fromRow To v_toRow
            For j As Integer = 1 To v_CellCount - 1
                v_columnName = grvDetail.GetRow(i).Cells(j).AccessibleName
                v_value = grvDetail.GetRow(i).Cells(j).Value
                If v_value Is Nothing Then
                    v_value = String.Empty
                End If
                v_value = IIf(v_value.Length = 0, "NULL", v_value)
                v_saveClase = v_saveClase & i + 1 & "=" & v_columnName & "=" & v_value
                If j < v_CellCount - 1 Then
                    v_saveClase = v_saveClase & mDelimiterItems
                End If
            Next
            If i < v_RowsCount - 1 Then
                v_saveClase = v_saveClase & mDelimiterRows
            End If
        Next
        Return v_saveClase
    End Function
    Private Sub ViewCSVFile()
        Try
            getFileDetail()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub formatGrid()
        Dim grvDetail As DevExpress.XtraGrid.Views.Grid.GridView = GridDetail.MainView
        Dim v_count As Integer = grvDetail.RowCount
        Dim v_match = 0, v_deviation = 0, v_systemnull = 0, v_vsdnull = 0
        mv_intErrCount = 0
        For i As Integer = 0 To v_count - 1
            Select Case grvDetail.GetRow(i).Cells(v_statusCol).Value
                Case c_statusSYSTEMNULL
                    grvDetail.GetRow(i).ForeColor = Color.Red
                    v_systemnull += 1
                    mv_intErrCount += 1
                Case c_statusVSDNULL
                    grvDetail.GetRow(i).ForeColor = Color.Red
                    v_vsdnull += 1
                    mv_intErrCount += 1
                Case c_statusDEVIATION
                    grvDetail.GetRow(i).ForeColor = Color.Red
                    v_deviation += 1
                    mv_intErrCount += 1
                Case c_statusNDEVIATION
                    v_match += 1
            End Select
        Next
    End Sub


    Private Sub getFileDetail()
        Dim v_strSQL, v_strObjMsg, v_strMSGBODY, v_strFuncName As String
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_fromRow, v_toRow, v_rowCount As Integer
        Dim v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_maxrow As Integer = 10000
        Try
            v_ws = New BDSDeliveryManagement
            v_fromRow = 1
            v_toRow = v_maxrow
            Dim v_strCmdInquiry As String =
                "SELECT C.DESCRIPTION FIELDNAME, C.EN_DESCRIPTION EN_FIELDNAME, UPPER(FLDNAME) FIELDCODE, 'C' FIELDTYPE, 'Y' SRCH, 'Y' DISPLAY, 100 WIDTH " _
                & "FROM CSVCOMPAREREPORTFLD C " _
                & "WHERE CMPID = '{0}' " _
                & "ORDER BY ID ASC "
            v_strCmdInquiry = String.Format(v_strCmdInquiry, mv_strVSDRPTID)
            Dim v_strClause As String = " "
            Dim v_strObjMsgcsv As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )
            v_ws.Message(v_strObjMsgcsv)

            PrepareSearchParams(UserLanguage, v_strObjMsgcsv, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_searchObjname, mv_strFormName, _
                mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, mv_arrStFieldDefValue, _
                mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
                mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
                mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType)

            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , mv_strCsvAutoid, "getFileDetail", , , v_fromRow & "^" & v_toRow, IpAddress, , , , )
            v_ws.Message(v_strObjMsg)

            FillDataXtraGrid(GridDetail, v_strObjMsg, "", "CSVDATA", , , , )
            Dim GridViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
            GridDetail.MainView = GridViewDetail
            XtraGridFormatCSV(GridViewDetail, c_ResourceManager & UserLanguage, mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)

            If GridDetail.MainView.RowCount > 0 Then
                Me.pnDetail.Controls.Clear()
                Me.pnDetail.Controls.Add(GridDetail)
                GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Else
                MsgBox(mv_ResourceManager.GetString("csvError"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            MsgBox(mv_ResourceManager.GetString("csvError"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            LogError.Write("Error source: @FDS.frmCSVCompare.getFileDetail" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub ExportCSV()
        Try
            Dim grvDetail As DevExpress.XtraGrid.Views.Grid.GridView = GridDetail.MainView
            If Not GridDetail Is Nothing Then
                If grvDetail.RowCount = 0 Then
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If

                Dim v_dlgSave As New SaveFileDialog
                v_dlgSave.Filter = "Text files (*.csv)|*.csv|Excel files (*.xls)|*.xls"
                v_dlgSave.RestoreDirectory = True
                Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

                If v_res = DialogResult.OK Then
                    Dim v_strFileName As String = v_dlgSave.FileName
                    If (grvDetail.RowCount > 0) Then
                        GridDetail.ExportToXls(v_strFileName)
                    Else
                        MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If
                    MsgBox(mv_ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

#End Region

    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridvDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel


    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ExportCSV()
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            ViewCSVFile()
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.btnView_Click" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub btnApprv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprv.Click
        Try
            ApprvRouter()
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(mv_ResourceManager.GetString("File_data_invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub getFormularFieldsFromDB(ByVal p_fileName As String, _
                                        ByVal p_compareType As String, _
                                        ByRef p_arrFormularName() As String, _
                                        ByRef p_arrFormularValue() As String)
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_ws = New BDSDeliveryManagement
            Dim v_strObjMsg, v_strClause, v_strValue, v_strFLDNAME As String
            v_strClause = "p_fileName!" & p_fileName & "!VARCHAR!1000^p_reportType!" & p_compareType & "!VARCHAR!1000"
            v_strObjMsg = BuildXMLObjMsg("", Me.BranchId, "", Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, mv_strADHOCFORMULAR_FNC, v_strClause, "", "", "", "", "", Me.IpAddress, gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                ReDim p_arrFormularName(v_nodeList.Item(i).ChildNodes.Count - 1)
                ReDim p_arrFormularValue(v_nodeList.Item(i).ChildNodes.Count - 1)
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        p_arrFormularName(i) = "F_" & v_strFLDNAME.ToUpper
                        p_arrFormularValue(i) = v_strValue
                    End With
                Next
                Exit For 'get only first row
            Next
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmCSVCompare.getFormularFieldsFromDB" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub LoadSaveData(ByVal mv_strSaveTableName As String, Optional ByVal mv_strSaveTableName_hist As String = "_", Optional ByVal pv_strFileID As String = "%")
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName & " where fileid like '" & pv_strFileID & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                'Lay tieu de grid
                ResultGrid = New GridEx
                Dim v_cmrODBuyGrid As New Xceed.Grid.ColumnManagerRow
                v_cmrODBuyGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrODBuyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                'ODBuyGrid.FixedHeaderRows.Add(v_grODBuyGrid)
                ResultGrid.FixedHeaderRows.Add(v_cmrODBuyGrid)


                For j As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDTYPE
                        Case "System.String"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case "System.DateTime"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case Else
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.Double)))
                    End Select
                    ResultGrid.Columns(v_strFLDNAME).Title = v_strFLDNAME

                Next

                'Fill du lieu vao Grid
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    Dim v_xDataRow As Xceed.Grid.DataRow = ResultGrid.DataRows.AddNew()
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case "System.DateTime"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case Else
                                    If v_strValue.Length = 0 Or v_strValue Is vbNullString Then
                                        v_xDataRow.Cells(v_strFLDNAME).Value = 0
                                    Else
                                        v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                    End If

                            End Select

                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frResultGrid = New Xceed.Grid.TextRow(mv_ResourceManager.GetString("RESULTSYN") & v_nodeList.Count & mv_ResourceManager.GetString("ROW"))
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                Me.pnDetail.Controls.Clear()
                Me.pnDetail.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill

            Else
                'THong bao khong co du lieu duoc Import
                MessageBox.Show(mv_ResourceManager.GetString("ERR_CANTWRITE"))
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & ". LoadSaveData" & vbNewLine _
                         & "Error code: v_strCmdSQL = " & v_strCmdSQL & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub txtFileName_Validated(sender As Object, e As EventArgs) Handles txtFileName.Validated

    End Sub

    Private Sub txtFileName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFileName.Validating

    End Sub

    Private Sub txtFileName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFileName.KeyUp
        Try
            If e.KeyCode = Keys.F5 Then
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "VSDCSVLOG"
                frm.ModuleCode = "ST"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                frm.Dispose()

                Me.txtFileName.Text = Trim(frm.ReturnValue)

                Dim v_strFLDNAME, v_strValue, v_strSQL, v_strObjMsg, v_filename As String
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                If frm.FULLDATA <> Nothing Then
                    v_xmlDocument.LoadXml(frm.FULLDATA)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                    Dim k As Integer = -1

                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                If v_strFLDNAME = "FILENAME" And v_strValue = frm.ReturnValue Then
                                    k = i
                                    GoTo p_break
                                End If
                            End With
                        Next
                    Next
p_break:
                    If k >= 0 Then
                        For j As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                            With v_nodeList.Item(k).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "AUTOID"
                                        mv_strCsvAutoid = v_strValue
                                    Case "VSDID"
                                        mv_strVSDID = v_strValue
                                    Case "RPTID"
                                        mv_strVSDRPTID = v_strValue
                                    Case "TRADEPLACE"
                                        mv_strTRADEPLACE = v_strValue
                                End Select
                            End With
                        Next
                    End If

                    Me.btnExecute.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub txtFileName_TextChanged(sender As Object, e As EventArgs) Handles txtFileName.TextChanged
        btnExecute.Enabled = False
    End Sub
End Class