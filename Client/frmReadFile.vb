Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
'Imports Microsoft.Office.Core
'Imports Microsoft.Office.Interop
'Imports interop.
Imports AppCore
Imports System.IO
Imports AppCore.modCoreLib
Imports Xceed.Grid
Imports System.Xml

Public Class frmReadFile
    Inherits System.Windows.Forms.Form
    Private m_BusLayer As CBusLayer = Nothing
    Private m_ResourceManager As Resources.ResourceManager

    Private hRptMaster As New Hashtable
    Private mv_strSYMBOLLIST As String = ""
    Private mv_strSymbolTable As New DataTable

    Private mv_srcFileName As String
    Private mv_strObjName As String
    Private mv_strFileCode As String
    Private SearchGrid As GridEx
    Private ResultGrid As GridEx
    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "SHEET1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_intROWTITLE As String = 1
    Private mv_intPAGE As String = 0
    Private mv_strTableName As String = 0
    Private mv_blnApprove As Boolean = False
    Private mv_blnIsTransaction As Boolean = False
    Private mv_blnIsImport As Boolean = False
    Private mv_blnIsCa As Boolean = False
    Private mv_strCAMASTID As String = String.Empty
    Private mv_strVSDREPORTID As String = ""
    Private mv_strChoosingDate As String = ""
    Private filecode_tradedate As String = ",I070,I081,I170,"



#Region "Property"
    Const c_ResourceManager = gc_RootNamespace & "." & "frmReadFile-"
    Private mv_strFileName As String
    Private mv_strSaveTableName As String
    Private mv_strSaveTableName_hist As String
    Private mv_strOVRRQD As String
    'Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_strIsLocalSearch As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strAuthCode As String
    Private mv_strRPTID As String
    Private mv_strMODCODE As String

    Private mv_strBusDate As String

    Private mv_strTellerType As String

    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnExpTrans As System.Windows.Forms.Button
    Private mv_strTellerID As String
    Private mv_strBranchId As String
    Private mv_strIpAddress As String
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents DataTable5 As System.Data.DataTable
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents lblbkdate As System.Windows.Forms.Label
    Friend WithEvents dtpbackdate As DevExpress.XtraEditors.DateEdit
    'Friend WithEvents txtCAMASTID As AppCore.FlexMaskEditBox
    Private mv_strWsName As String

    Private mv_strTxnum As String
    Private mv_strTxDate As String
    Private mv_strTltxcd As String
    Private mv_strViewMode As String
    Friend WithEvents DataTable52 As System.Data.DataTable
    Friend WithEvents cboFileName As AppCore.ComboBoxEx
    Friend WithEvents btnFileCSV As System.Windows.Forms.Button
    Friend WithEvents DataTable7 As System.Data.DataTable
    Private mv_strFileID As String


    Public Property IsImport() As Boolean
        Get
            Return mv_blnIsImport
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsImport = Value
        End Set
    End Property
    Public Property IsCa() As Boolean
        Get
            Return mv_blnIsCa
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsCa = Value
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

    Public Property TellerID() As String
        Get
            Return mv_strTellerID
        End Get
        Set(ByVal Value As String)
            mv_strTellerID = Value
        End Set
    End Property

    Public Property IsApprove() As Boolean
        Get
            Return mv_blnApprove
        End Get
        Set(ByVal Value As Boolean)
            mv_blnApprove = Value
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
    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return m_ResourceManager
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
    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property Txnum() As String
        Get
            Return mv_strTxnum
        End Get
        Set(ByVal Value As String)
            mv_strTxnum = Value
        End Set
    End Property

    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
        End Set
    End Property

    Public Property tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
        End Set
    End Property

    Public Property FileID() As String
        Get
            Return mv_strFileID
        End Get
        Set(ByVal Value As String)
            mv_strFileID = Value
        End Set
    End Property

    Public Property IsTransaction() As Boolean
        Get
            Return mv_blnIsTransaction
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsTransaction = Value
        End Set
    End Property

    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        UserLanguage = pv_strLanguage
        m_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    Friend WithEvents grbButton As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblBrowse As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents cboFileType As ComboBoxEx
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtCAMASTID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadFile))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFileCSV = New System.Windows.Forms.Button()
        Me.cboFileName = New AppCore.ComboBoxEx()
        Me.dtpbackdate = New DevExpress.XtraEditors.DateEdit()
        Me.lblbkdate = New System.Windows.Forms.Label()
        Me.lblBrowse = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.cboFileType = New AppCore.ComboBoxEx()
        Me.lblFileType = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grbSearchResult = New System.Windows.Forms.GroupBox()
        Me.pnlSearchResult = New System.Windows.Forms.Panel()
        Me.grbButton = New System.Windows.Forms.GroupBox()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.txtCAMASTID = New System.Windows.Forms.TextBox()
        Me.btnExpTrans = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable52 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtpbackdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpbackdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.grbButton.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnFileCSV)
        Me.GroupBox1.Controls.Add(Me.cboFileName)
        Me.GroupBox1.Controls.Add(Me.dtpbackdate)
        Me.GroupBox1.Controls.Add(Me.lblbkdate)
        Me.GroupBox1.Controls.Add(Me.lblBrowse)
        Me.GroupBox1.Controls.Add(Me.lblPath)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.cboFileType)
        Me.GroupBox1.Controls.Add(Me.lblFileType)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(876, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnFileCSV
        '
        Me.btnFileCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileCSV.Location = New System.Drawing.Point(758, 74)
        Me.btnFileCSV.Name = "btnFileCSV"
        Me.btnFileCSV.Size = New System.Drawing.Size(107, 22)
        Me.btnFileCSV.TabIndex = 33
        Me.btnFileCSV.Tag = "btnFileCSV"
        Me.btnFileCSV.Text = "Choose VSD File"
        Me.btnFileCSV.Visible = False
        '
        'cboFileName
        '
        Me.cboFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFileName.DisplayMember = "DISPLAY"
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(416, 48)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(387, 21)
        Me.cboFileName.TabIndex = 32
        Me.cboFileName.ValueMember = "VALUE"
        Me.cboFileName.Visible = False
        '
        'dtpbackdate
        '
        Me.dtpbackdate.EditValue = Nothing
        Me.dtpbackdate.Location = New System.Drawing.Point(310, 50)
        Me.dtpbackdate.Name = "dtpbackdate"
        Me.dtpbackdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpbackdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpbackdate.Size = New System.Drawing.Size(100, 20)
        Me.dtpbackdate.TabIndex = 0
        '
        'lblbkdate
        '
        Me.lblbkdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblbkdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbkdate.ForeColor = System.Drawing.Color.Red
        Me.lblbkdate.Location = New System.Drawing.Point(310, 24)
        Me.lblbkdate.Name = "lblbkdate"
        Me.lblbkdate.Size = New System.Drawing.Size(100, 23)
        Me.lblbkdate.TabIndex = 7
        Me.lblbkdate.Tag = ""
        Me.lblbkdate.Text = "Ngày"
        '
        'lblBrowse
        '
        Me.lblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowse.ForeColor = System.Drawing.Color.Red
        Me.lblBrowse.Location = New System.Drawing.Point(809, 24)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(56, 23)
        Me.lblBrowse.TabIndex = 2
        Me.lblBrowse.Text = "Chọn"
        '
        'lblPath
        '
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.Red
        Me.lblPath.Location = New System.Drawing.Point(416, 24)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(387, 23)
        Me.lblPath.TabIndex = 3
        Me.lblPath.Text = "Đường dẫn"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(809, 49)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(56, 21)
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = ">>>"
        '
        'cboFileType
        '
        Me.cboFileType.DisplayMember = "DISPLAY"
        Me.cboFileType.Location = New System.Drawing.Point(8, 48)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(296, 21)
        Me.cboFileType.TabIndex = 5
        Me.cboFileType.ValueMember = "VALUE"
        '
        'lblFileType
        '
        Me.lblFileType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileType.ForeColor = System.Drawing.Color.Red
        Me.lblFileType.Location = New System.Drawing.Point(8, 24)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(296, 23)
        Me.lblFileType.TabIndex = 4
        Me.lblFileType.Text = "Loại file"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(416, 48)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(387, 20)
        Me.txtPath.TabIndex = 1
        Me.txtPath.Text = "TextBox2"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grbSearchResult)
        Me.Panel1.Location = New System.Drawing.Point(8, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(879, 368)
        Me.Panel1.TabIndex = 1
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(0, 3)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(876, 365)
        Me.grbSearchResult.TabIndex = 25
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Tag = "grbSearchResult"
        Me.grbSearchResult.Text = "grbSearchResult"
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchResult.Location = New System.Drawing.Point(3, 17)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(870, 345)
        Me.pnlSearchResult.TabIndex = 0
        '
        'grbButton
        '
        Me.grbButton.Controls.Add(Me.btnReject)
        Me.grbButton.Controls.Add(Me.txtCAMASTID)
        Me.grbButton.Controls.Add(Me.btnExpTrans)
        Me.grbButton.Controls.Add(Me.btnExport)
        Me.grbButton.Controls.Add(Me.btnSave)
        Me.grbButton.Controls.Add(Me.btnCancel)
        Me.grbButton.Controls.Add(Me.btnLoadData)
        Me.grbButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbButton.Location = New System.Drawing.Point(0, 448)
        Me.grbButton.Name = "grbButton"
        Me.grbButton.Size = New System.Drawing.Size(894, 69)
        Me.grbButton.TabIndex = 26
        Me.grbButton.TabStop = False
        Me.grbButton.Tag = "grbButton"
        Me.grbButton.Text = "grbButton"
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(472, 40)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 23)
        Me.btnReject.TabIndex = 31
        Me.btnReject.Text = "btnReject"
        Me.btnReject.UseVisualStyleBackColor = True
        '
        'txtCAMASTID
        '
        Me.txtCAMASTID.Location = New System.Drawing.Point(120, 42)
        Me.txtCAMASTID.Name = "txtCAMASTID"
        Me.txtCAMASTID.Size = New System.Drawing.Size(118, 20)
        Me.txtCAMASTID.TabIndex = 30
        '
        'btnExpTrans
        '
        Me.btnExpTrans.Location = New System.Drawing.Point(8, 40)
        Me.btnExpTrans.Name = "btnExpTrans"
        Me.btnExpTrans.Size = New System.Drawing.Size(106, 23)
        Me.btnExpTrans.TabIndex = 29
        Me.btnExpTrans.Tag = "btnExpTrans"
        Me.btnExpTrans.Text = "btnExpTrans"
        Me.btnExpTrans.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(553, 40)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 28
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(714, 40)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 26
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "btnSave"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(794, 40)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(634, 40)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 25
        Me.btnLoadData.Tag = "btnLoadData"
        Me.btnLoadData.Text = "btnLoadData"
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
        'DataTable52
        '
        Me.DataTable52.Namespace = ""
        Me.DataTable52.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'frmReadFile
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(894, 517)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbButton)
        Me.KeyPreview = True
        Me.Name = "frmReadFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReadFile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtpbackdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpbackdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        Me.grbButton.ResumeLayout(False)
        Me.grbButton.PerformLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Function"
    Private Sub OnBrowser()
        Try
            Dim v_dlgOpen As New OpenFileDialog
            'v_dlgOpen.Filter = "Open files (*" & mv_strEXTENTION & ")|*" & mv_strEXTENTION & ""
            v_dlgOpen.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files(2003) (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                mv_srcFileName = v_dlgOpen.FileName
                Me.txtPath.Text = mv_srcFileName
                pnlSearchResult.Controls.Clear()
            End If
            pnlSearchResult.Dock = DockStyle.Fill
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmReadFile.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OnLoadData()
        Dim v_strOldCultureName As String = String.Empty
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook

        Try
            Dim filecode = Me.cboFileType.SelectedValue.ToString
            SearchGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range
            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim Obj As Object
            Dim v_xColumn As Xceed.Grid.Column
            'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
            'Dim oldCI As Globalization.CultureInfo
            'oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
            'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            v_strOldCultureName = SetCultureInfo("en-US")

            If Me.txtPath.Text.Trim.Length = 0 Then
                MessageBox.Show(m_ResourceManager.GetString("MSG_FILEPATH"))
                Me.ActiveControl = Me.btnBrowse
                Exit Sub
            End If
            Dim ds As New DataSet
            Try
                Dim xmlFile As XmlReader
                xmlFile = XmlReader.Create(mv_srcFileName, New XmlReaderSettings())
                ds.ReadXml(xmlFile)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                xlApp = New Excel.Application

                xlWorkBook = xlApp.Workbooks.Add()
                xlWorkSheet = xlWorkBook.ActiveSheet
                xlWorkSheet.Cells.NumberFormat = "@"
                For Each dc In ds.Tables(0).Columns
                    colIndex = colIndex + 1
                    xlWorkSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In ds.Tables(0).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(0).Columns
                        colIndex = colIndex + 1
                        xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
                xlWorkSheet.Cells.ClearFormats()
                xlWorkSheet.Rows.ClearFormats()
            Catch ex As Exception

                xlApp = New Excel.Application
                xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)

                If xlWorkBook Is Nothing Then
                    MessageBox.Show(m_ResourceManager.GetString("ERR_FILEPATH"))
                    Me.ActiveControl = Me.btnBrowse
                    Exit Sub
                End If
                If filecode = "I036" And mv_strCAMASTID.Length = 0 Then
                    MessageBox.Show(m_ResourceManager.GetString("ERR_CANOTSELECT"))
                    Exit Sub
                End If
                xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))
            End Try


            range = xlWorkSheet.UsedRange
            Dim range2 As Object(,) = xlWorkSheet.UsedRange.Value2

            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                For cCnt = 1 To range.Columns.Count
                    If Not CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value Is Nothing Then
                        SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                        SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value).Trim
                        SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                        SearchGrid.Columns(cCnt.ToString).Width = 100
                    End If
                Next
            End If
            'Them cot trade_date voi truong hop import VSD

            If InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
                SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField("TRADE_DATE").Trim
                SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                SearchGrid.Columns(cCnt.ToString).Width = 100
            End If
            If InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
                If Me.dtpbackdate.Text.Trim.Length = 0 Then
                    MessageBox.Show(m_ResourceManager.GetString("MSG_TRADEDATE"))
                    Me.ActiveControl = Me.btnBrowse
                    Exit Sub
                End If
            End If
            SearchGrid.DataRows.Clear()
            SearchGrid.BeginInit()

            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                'trung.luu case voi I074 bo dong dau tien sau header => vi header bi merge row
                If String.Compare(filecode, "I074") = 0 Then
                    For rCnt = mv_intROWTITLE + 2 To range.Rows.Count
                        Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                        For Each v_xColumn In SearchGrid.Columns
                            If mv_strCAMASTID.Length > 0 And v_xColumn.Title.ToString = "CAMASTID" Then
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = Replace(mv_strCAMASTID, ".", "")
                            Else
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                            End If
                        Next

                        v_xDataRow.EndEdit()
                    Next
                Else
                    'vu.tran khong doc data rong
                    For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
                        Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                        Dim v_check As Integer = 0
                        For Each v_xColumn In SearchGrid.Columns
                            If mv_strCAMASTID.Length > 0 And v_xColumn.Title.ToString = "CAMASTID" Then
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = Replace(mv_strCAMASTID, ".", "")
                                'Them cot trade_date voi truong hop import VSD
                            ElseIf v_xColumn.Title.ToString = "TRADE_DATE" And InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(Format(dtpbackdate.EditValue, "dd/MM/yyyy"))
                            Else
                                If InStr(mv_srcFileName.ToLower, ".csv") > 0 Or InStr(mv_srcFileName.ToLower, ".xml") > 0 Then
                                    Dim value As String = range2(rCnt, CInt(v_xColumn.FieldName))
                                    If IsNothing(value) Then
                                        v_check = v_check + 1
                                        If v_check = SearchGrid.Columns.Count Then
                                            SearchGrid.DataRows.RemoveAt(v_xDataRow.Index)
                                            v_xDataRow.EndEdit()
                                            GoTo end_of_for
                                        End If
                                    End If
                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(value)
                                Else
                                    Dim valueRange As Excel.Range
                                    valueRange = range.Cells(rCnt, CInt(v_xColumn.FieldName))
                                    Dim Value As String = Trim(valueRange.Value)
                                    Try
                                        If IsNothing(valueRange.Value) Then
                                            v_check = v_check + 1
                                            If v_check = SearchGrid.Columns.Count Then
                                                SearchGrid.DataRows.RemoveAt(v_xDataRow.Index)
                                                v_xDataRow.EndEdit()
                                                GoTo end_of_for
                                            End If
                                        End If

                                        If IsDate(Value) And Value.Length >= 8 Then
                                            Dim dt As DateTime = Convert.ToDateTime(Value)
                                            If (InStr(Value, "/") > 0 And Value.Length > 10) Then
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(dt.ToString("dd/MM/yyyy HH:mm:ss"))
                                            ElseIf (InStr(Value, "/") = 0 And Value.Length > 8) Then
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(dt.ToString("dd/MM/yyyy HH:mm:ss"))
                                            Else
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(dt.ToString("dd/MM/yyyy"))
                                            End If
                                        Else
                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(Value)
                                        End If
                                    Catch ex As Exception
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(Value)
                                    End Try
                                End If
                            End If
                            'trung.luu clear dong trong,dong chua du lieu rac khi doc len tu excel voi import broker template 1
                            If (v_xColumn.Title = "Broker Code" Or v_xColumn.Title = "Quantity(shs)") And String.Compare(filecode, "I073") = 0 Then
                                If v_xDataRow.Cells(v_xColumn.FieldName).Value Is Nothing Then
                                    SearchGrid.DataRows.RemoveAt(v_xDataRow.Index)
                                    Exit For
                                End If
                            End If
                        Next
                        v_xDataRow.EndEdit()
                    Next
                End If
            End If

end_of_for:

            Dim v_frSearchGrid = New Xceed.Grid.TextRow(m_ResourceManager.GetString("DATARECEIVED") & " " & range.Rows.Count - mv_intROWTITLE & " " & m_ResourceManager.GetString("ROW"))
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            SearchGrid.FixedFooterRows.Clear()
            SearchGrid.FixedFooterRows.Add(v_frSearchGrid)

            SearchGrid.EndInit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            Me.pnlSearchResult.Controls.Clear()
            Me.pnlSearchResult.Controls.Add(SearchGrid)
            SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            'System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Catch ex As Exception
            xlApp.Workbooks.Close()
            LogError.Write("Error source: @VSTP.frmReadFile.OnLoadData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(m_ResourceManager.GetString("ERR_DATAFORMAT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Len(v_strOldCultureName) > 0 Then
                v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            End If
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub OnSave()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "ImportXMLFileToDB"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            Dim v_grid As New AppCore.GridEx
            If Not IsApprove Then
                v_grid = SearchGrid
            Else
                v_grid = ResultGrid
            End If
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            If (MessageBox.Show(m_ResourceManager.GetString("MSG_CONFIRM"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder
                'Gan title
                For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns
                    If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                        v_strValue = CType(v_xColumn, Xceed.Grid.Column).Title
                    Else
                        v_strValue = ""
                    End If
                    v_strBuffer.Append("" & v_strValue & "~")
                Next
                v_strBuffer.Append("|")
                'Gan noi dung
                For i As Integer = 0 To v_grid.DataRows.Count - 1
                    With v_grid.DataRows(i)
                        For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns

                            If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                                v_strValue = CStr(.Cells(v_xColumn.FieldName).Value)
                                'TriBui:process nothing value
                                If v_strValue Is Nothing Then
                                    v_strValue = ""
                                End If
                                'TriBui:process string content (')
                                If v_strValue.Contains("'") Then
                                    v_strValue = v_strValue.Replace("'", "''")
                                End If
                            Else
                                v_strValue = ""
                            End If
                            v_strBuffer.Append("" & v_strValue & "~")
                        Next
                        v_strBuffer.Append("|")
                    End With
                Next
                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                Dim pv_xmlDocument As New Xml.XmlDocument
                Dim v_strFeedBackMessage, v_strFeedBackMessageVN As String
                pv_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_strFileId As String
                v_strFileId = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeAUTOID).Value

                'TruongLD Comment when convert
                'v_ws.Dispose()
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Load lai du lieu de biet loi~ o dau trong truong hop Return ra ma loi~
                    If mv_strSaveTableName.Length > 0 Then
                        LoadSaveData(mv_strSaveTableName, mv_strSaveTableName, v_strFileId)
                    End If
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                    MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                v_strFeedBackMessageVN = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value

                Dim str_replace As String = "Tổng số bản ghi"
                Dim str_replace_EN As String = "Total records"
                If Me.UserLanguage = "VN" Then
                    v_strFeedBackMessage = v_strFeedBackMessageVN
                Else
                    v_strFeedBackMessage = Replace(v_strFeedBackMessageVN, str_replace, str_replace_EN)
                End If

                pv_xmlDocument = Nothing
                Cursor.Current = Cursors.Default
                'check error here
                If v_strFeedBackMessage.Trim.Length = 0 Then
                    MessageBox.Show(m_ResourceManager.GetString("MSG_SUCCESS"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(m_ResourceManager.GetString("MSG_SUCCESS") & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'LOAD LAI DU LIEU DA SAVE DE KIEM TRA
                If mv_strSaveTableName.Length > 0 And mv_strSaveTableName <> "CADTLIMP" Then
                    LoadSaveData(mv_strSaveTableName, mv_strSaveTableName_hist, v_strFileId)
                End If


            End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(m_ResourceManager.GetString("ERR_IMPUTFILEFORMAT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Oninit()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        m_BusLayer = New CBusLayer
        'btnSave.Enabled = True
        btnExpTrans.Enabled = False



        'Load combobox
        If IsCa Then
            v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE filecode in ('I036','I040','I044') ORDER BY filecode"
        Else
            If IsApprove Then
                If IsImport Then
                    If Me.ModuleCode = SUB_SYSTEM_SA Then
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY," _
                                           & " filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='T' and OVRRQD='Y'   ORDER BY filecode"
                    Else
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY," _
                                           & " filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='T' and OVRRQD='Y' AND filecode <>'I036' and CMDCODE = '" & Me.ModuleCode & "' ORDER BY filecode"
                    End If

                Else
                    If Me.ModuleCode <> SUB_SYSTEM_SA Then
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' and OVRRQD='Y' AND filecode <>'I064' and CMDCODE = '" & Me.ModuleCode & "' ORDER BY filecode"
                    Else
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='I' and OVRRQD='Y' AND filecode <>'I036' AND filecode <>'I064' ORDER BY filecode"
                    End If

                End If
            Else
                If IsImport Then
                    If Me.ModuleCode = SUB_SYSTEM_SA Then
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY," _
                    & " filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='T'   ORDER BY filecode"
                    Else
                        v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY," _
                                            & " filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='T' AND filecode <>'I036' and CMDCODE = '" & Me.ModuleCode & "' ORDER BY filecode"
                    End If

                Else
                    v_strCmdSQL = "SELECT filecode VALUE, filecode || ': ' || filename DISPLAY, filecode || ': ' || filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='I'  ORDER BY filecode"
                End If
            End If

        End If

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboFileType, "", Me.UserLanguage)

        'TruongLD add 06/02/2020
        If IsTransaction Then
            Dim v_strFileCode As String
            Dim v_strTableName, v_strTableName_hist, v_strTranStatus, v_strIsBackdate As String
            GetTranInfo(Me.Txnum, Me.TxDate, v_strFileCode, v_strTableName, v_strTableName_hist, v_strTranStatus, v_strIsBackdate)
            cboFileType.SelectedValue = v_strFileCode
            cboFileType.Enabled = False

            LoadSaveData(v_strTableName, v_strTableName_hist, Me.FileID)

            btnLoadData.Enabled = False
            If v_strTranStatus <> "4" Then
                btnReject.Enabled = False
                btnSave.Enabled = False
            End If
        ElseIf IsApprove = False Then
            btnReject.Enabled = False
        End If


        If IsCa Then
            Me.txtCAMASTID.Visible = True
        Else
            Me.txtCAMASTID.Visible = False
        End If


        'Reset path
        Me.txtPath.Text = ""
        Me.grbSearchResult.Text = m_ResourceManager.GetString("grbSearchResult") '"Kết quả"
        Me.GroupBox1.Text = ""
        Me.grbButton.Text = ""
        Me.btnCancel.Text = m_ResourceManager.GetString("btnCancel") '"&Thoát"
        Me.btnLoadData.Text = m_ResourceManager.GetString("btnLoadData") '"Đọc &dữ liệu"
        Me.btnExport.Text = m_ResourceManager.GetString("btnExport") '"Kết xuất"
        Me.btnExpTrans.Text = m_ResourceManager.GetString("btnExpTrans") '"&Exp Transaction"
        Me.lblBrowse.Text = m_ResourceManager.GetString("lblBrowse")
        Me.lblFileType.Text = m_ResourceManager.GetString("lblFileType")
        Me.lblPath.Text = m_ResourceManager.GetString("lblPath")
        Me.btnReject.Text = m_ResourceManager.GetString("btnReject")
        Me.lblbkdate.Text = m_ResourceManager.GetString("lblbkdate")

        If IsApprove Then
            If IsImport Then
                Me.btnSave.Text = m_ResourceManager.GetString("DUYET") '"Duyệt"
                'Form Caption
                Me.Text = m_ResourceManager.GetString("DUYETIMPORT") '"Duyệt Import giao dịch"
                Me.txtPath.Enabled = False
                Me.btnBrowse.Enabled = False
            Else
                Me.btnSave.Text = m_ResourceManager.GetString("DUYET") '"Duyệt"
                'Form Caption
                Me.Text = m_ResourceManager.GetString("DUYETDONGBO") '"Duyệt đồng bộ số liệu"
                Me.txtPath.Enabled = False
                Me.btnBrowse.Enabled = False
            End If

        Else
            If IsImport Then
                Me.btnSave.Text = m_ResourceManager.GetString("GHIDULIEU") '"Ghi dữ liệu"
                'Form Caption
                Me.Text = m_ResourceManager.GetString("frmReadFile") '"Import giao dịch"
            Else
                Me.btnSave.Text = m_ResourceManager.GetString("GHIDULIEU") '"Ghi dữ liệu"
                'Form Caption
                Me.Text = m_ResourceManager.GetString("DONGBO") '"Đồng bộ số liệu"
            End If

        End If
    End Sub

    Private Sub OnReject()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "RejectImportFile"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            Dim v_grid As New AppCore.GridEx
            If Not IsApprove Then
                v_grid = SearchGrid
            Else
                v_grid = ResultGrid
            End If
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            If (MessageBox.Show(m_ResourceManager.GetString("CANCELDATA"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder
                For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns
                    If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                        v_strValue = CType(v_xColumn, Xceed.Grid.Column).Title
                    Else
                        v_strValue = ""
                    End If
                    v_strBuffer.Append("" & v_strValue & "~")
                Next
                v_strBuffer.Append("|")
                'Gan noi dung
                For i As Integer = 0 To v_grid.DataRows.Count - 1
                    With v_grid.DataRows(i)
                        For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns

                            If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                                v_strValue = CStr(.Cells(v_xColumn.FieldName).Value)
                            Else
                                v_strValue = ""
                            End If
                            v_strBuffer.Append("" & v_strValue & "~")
                        Next
                        v_strBuffer.Append("|")
                    End With
                Next
                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(Me.TxDate, , , Me.TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, Me.FileID, Me.Txnum, mv_strFileCode, IIf(IsApprove, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                'TruongLD Comment when convert
                'v_ws.Dispose()
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Load lai du lieu de biet loi~ o dau trong truong hop Return ra ma loi~
                    If mv_strSaveTableName.Length > 0 Then
                        LoadSaveData(mv_strSaveTableName)
                    End If
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                MessageBox.Show(m_ResourceManager.GetString("CANCELPROCESS"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                v_grid.Clear()
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(m_ResourceManager.GetString("INPUTDATA"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub GetFileInfo(ByVal pv_strFile As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM filemaster WHERE filecode='" & pv_strFile & "'AND eori<>'C'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FILEPATH"
                                mv_strFILEPATH = v_strValue
                                Me.txtPath.Text = v_strValue
                            Case "SHEETNAME"
                                mv_strSHEETNAME = v_strValue
                            Case "ROWTITLE"
                                mv_intROWTITLE = CInt(v_strValue)
                            Case "EXTENTION"
                                mv_strEXTENTION = v_strValue
                            Case "PAGE"
                                mv_intPAGE = CInt(v_strValue)
                            Case "TABLENAME"
                                mv_strSaveTableName = v_strValue
                            Case "TABLENAME_HIST"
                                mv_strSaveTableName_hist = v_strValue
                            Case "OVRRQD"
                                mv_strOVRRQD = v_strValue
                            Case "MODCODE"
                                mv_strMODCODE = v_strValue
                            Case "RPTID"
                                mv_strRPTID = v_strValue
                        End Select
                    End With
                Next
            Next
            'If mv_strRPTID.Trim <> "" Then
            '    'btnSave.Enabled = False
            '    btnExpTrans.Enabled = True
            'Else
            '    ' btnSave.Enabled = True
            '    btnExpTrans.Enabled = False
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetTranInfo(ByVal pv_strtxnum As String,
                                    ByVal pv_strtxdate As String,
                                    ByRef pv_strfilecode As String,
                                    ByRef pv_strtablename As String,
                                    ByRef pv_strtablename_hist As String,
                                    ByRef pv_strTranStatus As String,
                                    ByRef pv_strIsBackdate As String
                                    )
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "Select fld.filecode, fld.tablename, tl.txstatus, nvl(fld.tablename_hist,fld.tablename) tablename_hist, (case when tl.txdate = getcurrdate then 'N' else 'Y' end) ISBACKDATE" & ControlChars.CrLf _
                            & " from vw_tllog_all tl, vw_tllogfld_all tf, filemaster fld" & ControlChars.CrLf _
                            & " where tl.txnum = tf.txnum and tl.txdate=tf.txdate " & ControlChars.CrLf _
                            & " and tl.txnum='" & pv_strtxnum & "'" & ControlChars.CrLf _
                            & " and tl.txdate=to_date('" & pv_strtxdate & "','DD/MM/RRRR')" & ControlChars.CrLf _
                            & " and tf.fldcd = '16' and fld.filecode = tf.cvalue"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FILECODE"
                                pv_strfilecode = v_strValue
                                Me.txtPath.Text = v_strValue
                            Case "TABLENAME"
                                pv_strtablename = v_strValue
                            Case "TABLENAME_HIST"
                                pv_strtablename_hist = v_strValue
                            Case "TXSTATUS"
                                pv_strTranStatus = v_strValue
                            Case "ISBACKDATE"
                                pv_strIsBackdate = v_strValue
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & ". GetTranInfo" & vbNewLine _
                         & "Error code: v_strCmdSQL = " & v_strCmdSQL & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub LoadSaveData(ByVal mv_strSaveTableName As String, Optional ByVal mv_strSaveTableName_hist As String = "_", Optional ByVal pv_strFileID As String = "%")
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            If pv_strFileID = "" Then
                pv_strFileID = "%"
            End If
            If Me.IsTransaction Then
                If mv_strSaveTableName = mv_strSaveTableName_hist Or mv_strSaveTableName_hist = "_" Then
                    v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName & " where fileid like '" & pv_strFileID & "'"
                Else
                    v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName & " where fileid like '" & pv_strFileID & "' " _
                        & " union all SELECT * FROM " & mv_strSaveTableName_hist & " where fileid like '" & pv_strFileID & "' "
                End If

            Else
                v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName & " where fileid like '" & pv_strFileID & "' and OVRSTATUS not in ('Y','R')"
            End If


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
                                    'If v_strFLDNAME = "TRADE_DATE" Then
                                    '    Dim tradedate As String = dtpbackdate.EditValue
                                    '    v_xDataRow.Cells(v_strFLDNAME).Value = tradedate
                                    'Else
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                    'End If
                                Case "System.DateTime"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case Else
                                    If v_strValue.Length = 0 Or v_strValue Is vbNullString Then
                                        v_xDataRow.Cells(v_strFLDNAME).Value = Double.Parse(0)
                                    Else
                                        v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                    End If

                            End Select

                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frResultGrid = New Xceed.Grid.TextRow(m_ResourceManager.GetString("RESULTSYN") & v_nodeList.Count & m_ResourceManager.GetString("ROW"))
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                Me.pnlSearchResult.Controls.Clear()
                Me.pnlSearchResult.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill

                grbSearchResult.AutoSize = True
                If mv_strRPTID.Trim <> "" Then
                    'btnSave.Enabled = False
                    btnExpTrans.Enabled = True
                Else
                    ' btnSave.Enabled = True
                    btnExpTrans.Enabled = False
                End If

            Else
                'THong bao khong co du lieu duoc Import
                MessageBox.Show(m_ResourceManager.GetString("ERR_CANTWRITE"))
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & ". LoadSaveData" & vbNewLine _
                         & "Error code: v_strCmdSQL = " & v_strCmdSQL & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

#End Region


#Region "Form events"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OnBrowser()
    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        If IsApprove Then
            'Load du lieu tu file save data
            LoadSaveData(mv_strSaveTableName)
        Else
            'Load du lieu tu file duong dan

            If cboFileName.Visible = False Then
                OnLoadData()
            Else
                ViewCSVFile()
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.IsTransaction = True Then
            ' Duyet qua duong GD
            OnApprove()
        Else
            OnSave()
        End If

    End Sub

    Private Sub frmReadFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Oninit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub cboFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strTEXT, v_strValue, v_strFLDNAME As String
        Dim v_strSQL As String
        Dim v_strObjMsg As String
        Dim filecode = cboFileType.SelectedValue.ToString()

        v_ws = New BDSDeliveryManagement

        If Not Me.cboFileType.SelectedValue Is Nothing Then
            pnlSearchResult.Controls.Clear()
            Dim v_strFile As String
            mv_strFileCode = filecode
            v_strFile = mv_strFileCode
            GetFileInfo(v_strFile)
        End If

        If filecode = "I036" Then
            Me.txtCAMASTID.Visible = True
            Me.txtCAMASTID.BackColor = System.Drawing.Color.GreenYellow
            'Me.txtCAMASTID.Mask = "9999999999999999"
            'Me.txtCAMASTID.MaskCharInclude = False
        Else
            Me.txtCAMASTID.Visible = False
        End If

        Try
            v_strSQL = String.Format("SELECT TRADEDATE FROM FILEMASTER WHERE FILECODE = '{0}'", filecode)
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
                            Case "TRADEDATE"
                                If v_strValue = "Y" Then
                                    filecode_tradedate = "," + filecode + ","
                                Else
                                    filecode_tradedate = ""
                                End If
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            filecode_tradedate = ",I070,I081,I170,I083"
        End Try

        'Trung.luu => loai file = VSD => cho chon ngay backdate

        If InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
            dtpbackdate.Visible = True
            lblbkdate.Visible = True
            lblFileType.Width = CInt(296)
            cboFileType.Width = CInt(296)
            dtpbackdate.EditValue = DateTime.ParseExact(Me.BusDate, "dd/MM/yyyy", Nothing)
        Else
            dtpbackdate.Visible = False
            lblbkdate.Visible = False
            lblFileType.Width = CInt(396)
            cboFileType.Width = CInt(396)
        End If

        Try
            v_strSQL = String.Format("SELECT VSDREPORTID FROM VSD_MAP_IMPORT WHERE IMPORTID = '{0}'", filecode)
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            mv_strVSDREPORTID = Nothing

            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME).ToUpper
                            Case "VSDREPORTID"
                                mv_strVSDREPORTID = v_strValue.Trim
                        End Select
                    End With
                Next
            Next
            btnFileCSV.Visible = False
            btnBrowse.Visible = True
            If Not mv_strVSDREPORTID Is Nothing Then
                btnFileCSV.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim v_strFileName, v_strData As String, iX, iY, iColumn, intFreeFile As Integer
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|Text files (*.txt)|*.txt|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                v_strFileName = v_dlgSave.FileName
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (ResultGrid.DataRows.Count > 0) Then
                    'Column header
                    iColumn = 1
                    For iY = 0 To ResultGrid.Columns.Count - 1
                        If ResultGrid.Columns(iY).Visible Then
                            v_strData &= ResultGrid.Columns(iY).Title & vbTab
                            iColumn = iColumn + 1
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Data
                    For iX = 0 To ResultGrid.DataRows.Count - 1
                        v_strData = String.Empty
                        iColumn = 1
                        For iY = 0 To ResultGrid.Columns.Count - 1
                            If ResultGrid.Columns(iY).Visible Then
                                v_strData &= ResultGrid.DataRows(iX).Cells(iY).Value.ToString & vbTab
                                iColumn = iColumn + 1
                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(m_ResourceManager.GetString("NODATAEXPORT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If

                'Close StreamWriter
                v_streamWriter.Close()

                MsgBox(m_ResourceManager.GetString("EXPORTPROCESS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmReadFile_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If Me.ActiveControl.Name = "txtCAMASTID" And Me.txtCAMASTID.ReadOnly = False Then
                    Me.UserLanguage = "VN"
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CAMAST"
                    frm.ModuleCode = "CA"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerID
                    frm.ShowDialog()

                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    mv_strCAMASTID = Trim(frm.ReturnValue)
                    frm.Dispose()
                End If

        End Select


    End Sub

    Private Sub btnExpTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpTrans.Click
        'Liệt kê danh sách các View tra cứu được phép
        Dim v_intPos As Integer, ctl As Control, v_strRETURNDATA, v_strObjName, v_strModCode, v_strCMDTYPE As String

        Dim frmSearch As New frmSearchMaster(m_BusLayer.AppLanguage)
        frmSearch.BusDate = Me.BusDate
        frmSearch.TableName = mv_strRPTID
        frmSearch.ModuleCode = mv_strMODCODE
        frmSearch.TellerId = Me.TellerID
        '     frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
        frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
        frmSearch.CMDTYPE = "V"
        frmSearch.IsLocalSearch = gc_IsNotLocalMsg
        frmSearch.SearchOnInit = False
        frmSearch.BranchId = Me.BranchId
        frmSearch.IpAddress = Me.IpAddress
        frmSearch.WsName = Me.WsName
        frmSearch.SymbolList = mv_strSYMBOLLIST
        frmSearch.SymbolTable = mv_strSymbolTable


        frmSearch.ShowDialog()
        'DisplayGeneralView("SEGENERALVIEW")
        '    End If
        'End If
    End Sub

    Private Sub pnlSearchResult_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles pnlSearchResult.ControlAdded
        Try
            If pnlSearchResult.Controls.IndexOf(ResultGrid) >= 0 Then
                btnExpTrans.Enabled = True
            Else
                btnExpTrans.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If Me.IsTransaction = True Then
            ' Tu choi qua duong giao dich
            OnReject(Me.FileID)
        Else
            OnReject()
        End If
    End Sub

    Private Sub OnApprove()
        Try
            If MsgBox(m_ResourceManager.GetString("ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Dim v_strClause, v_strObjMsg, v_strErrorSource, v_strErrorMessage As String
                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_lngError As Long
                v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , Me.Txnum, , , , , , , )
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
                MessageBox.Show(m_ResourceManager.GetString("ApproveSucess"))
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OnReject(ByVal pv_FileID As String)
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg, V_strObjectName As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strClause, v_strObjMsg As String
            Dim v_strMODULCODE, v_strPARENTTABLE As String
            Dim v_blTick As Boolean = False, v_blProccess As Boolean = False
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intRejectCount As Integer = 0
            Dim v_strComment4List As String = String.Empty
            Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long
            If MsgBox(m_ResourceManager.GetString("RejectConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                v_strTXNUM = mv_strTxnum
                v_strTXDATE = mv_strTxDate
                'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , Me.Txnum)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                    'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                    If (Len(Trim(v_strOVRRQS.Replace(OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                        Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                        'Hiển thị InputBox yêu cầu nhập lý do Reject
                        v_strCommentMessage = InputBox(m_ResourceManager.GetString("RejectResion"), Me.Text, v_strCommentMessage)
                        If Len(Trim(v_strCommentMessage)) > 0 Then
                            v_strObjMsg = String.Empty
                            v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , Me.Txnum, v_strCommentMessage, , , , , , )
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                            MessageBox.Show(m_ResourceManager.GetString("RejectSucess"))
                            Me.Close()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnFileCSV_Click(sender As Object, e As EventArgs) Handles btnFileCSV.Click
        If cboFileName.Visible = False Then
            btnFileCSV.Text = "Choose PC file"
            cboFileName.Visible = True
            btnBrowse.Visible = False

            If mv_strChoosingDate <> "" Then
                getUpdateFileName()
            End If

        Else
            btnFileCSV.Text = "Choose VSD file"
            cboFileName.Visible = False
            btnBrowse.Visible = True
        End If
    End Sub

    Private Sub dtpbackdate_EditValueChanged(sender As Object, e As EventArgs) Handles dtpbackdate.EditValueChanged
        mv_strChoosingDate = dtpbackdate.EditValue

        Try
            If SearchGrid.DataRows.Count > 0 Then
                Dim filecode = cboFileType.SelectedValue.ToString
                If InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
                    OnLoadData()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub getUpdateFileName()
        Dim v_strSQL, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As BDSDeliveryManagement
        Try
            Try
                v_strSQL = String.Format("SELECT autoid VALUE, filename DISPLAY, filename EN_DISPLAY, to_char(txdate,'DD/MM/RRRR') DESCRIPTION " & ControlChars.NewLine _
                                        & " FROM vsd_csvcontent_log " & ControlChars.NewLine _
                                        & " WHERE filename like '%' || TO_CHAR(TO_DATE('{1}','{2}'),'DDMMRRRR') || '%' " & ControlChars.NewLine _
                                        & " and filename like '%{0}%'  " & ControlChars.NewLine _
                                        & " ORDER BY TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 23, 8),'DDMMRRRR') DESC, TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 14, 6),'HH24MISS') DESC ",
                                        mv_strVSDREPORTID, mv_strChoosingDate, gc_FORMAT_DATE_DB)

                v_ws = New BDSDeliveryManagement
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Catch ex As Exception
                v_strSQL = String.Format("SELECT vsd.autoid VALUE, vsd.filename DISPLAY, vsd.filename EN_DISPLAY, to_char(txdate,'dd/mm/rrrr') DESCRIPTION " & ControlChars.NewLine _
                                    & " FROM vsd_csvcontent_log  vsd " & ControlChars.NewLine _
                                    & "WHERE vsd.TXDATE = TO_DATE('{1}','{2}')" & ControlChars.NewLine _
                                    & " and filename like '%{0}%'  " & ControlChars.NewLine _
                                    & "ORDER BY vsd.autoid DESC ", mv_strVSDREPORTID, mv_strChoosingDate, gc_FORMAT_DATE_DB)

                v_ws = New BDSDeliveryManagement
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            End Try


            'v_strSQL = "SELECT cmpid,DECODE(UPPER(" & UserLanguage & ", FROM csvCompare WHERE cmpUsed = 'Y' ORDER BY lstodr"
            v_ws = New BDSDeliveryManagement
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count <= 0 Then
                Try
                    'If MessageBox.Show(mv_ResourceManager.GetString("errNoCorrectFile"), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    v_strSQL = String.Format("SELECT autoid VALUE, filename DISPLAY, filename EN_DISPLAY, to_char(txdate,'DD/MM/RRRR') DESCRIPTION " & ControlChars.NewLine _
                                    & " FROM VSD_CSVCONTENT_LOGHIST " & ControlChars.NewLine _
                                    & " WHERE filename like '%' || TO_CHAR(TO_DATE('{1}','{2}'),'DDMMRRRR') || '%' " & ControlChars.NewLine _
                                    & " AND filename like '%{0}%' " & ControlChars.NewLine _
                                    & " ORDER BY TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 14, 6),'HH24MISS') DESC ",
                                    mv_strVSDREPORTID, mv_strChoosingDate, gc_FORMAT_DATE_DB)
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                Catch ex As Exception
                    'If MessageBox.Show(mv_ResourceManager.GetString("errNoCorrectFile"), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    v_strSQL = String.Format("SELECT vsd.autoid VALUE, vsd.filename DISPLAY, vsd.filename EN_DISPLAY, to_char(txdate,'dd/mm/rrrr') DESCRIPTION " & ControlChars.NewLine _
                                    & " FROM (select * from VSD_CSVCONTENT_LOGHIST)  vsd " & ControlChars.NewLine _
                                    & "WHERE  filename like '%{0}%' and vsd.txdate = TO_DATE('{1}','{2}') " & ControlChars.NewLine _
                                    & "ORDER BY vsd.autoid DESC ", mv_strVSDREPORTID, mv_strChoosingDate, gc_FORMAT_DATE_DB)
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                End Try
            End If
            'End If
            cboFileName.Clears()
            If v_nodeList.Count > 0 Then
                FillComboEx(v_strObjMsg, cboFileName, "", Me.UserLanguage)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.getUpdateFileName." & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Me.cboFileName.Clears()
        End Try
    End Sub

    Private Sub ViewCSVFile()
        Dim v_strSQL, v_strObjMsg, v_strMSGBODY, v_strFuncName As String
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_dsDetail As DataTable
        Dim v_allowIMP As String
        Dim v_fromRow, v_toRow, v_rowCount As Integer
        Dim v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_maxrow As Integer = 6000
        Dim v_strObjname As String = "ST.CSVCMP"
        Try

            v_strSQL = "SELECT  vsd.msgbody FROM (select * from  vsd_csvcontent_log union all select * from VSD_CSVCONTENT_LOGHIST) vsd WHERE autoid = " & cboFileName.SelectedValue.ToString
            v_ws = New BDSDeliveryManagement
            SearchGrid = New GridEx

            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            While v_hasmore
                If v_pageNum = 1 Then
                    v_fromRow = 1
                Else
                    v_fromRow = v_toRow + 1
                End If
                v_toRow = v_fromRow + v_maxrow
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, v_strObjname, gc_ActionAdhoc, , cboFileName.SelectedValue.ToString, "getFileDetail", , , v_fromRow & "^" & v_toRow, IpAddress, , , , )
                v_ws.Message(v_strObjMsg)

                fillDataGrid(SearchGrid, v_strObjMsg, "", IIf(v_pageNum = 1, True, False), v_rowCount, True)

                If v_rowCount <= v_maxrow Then
                    v_hasmore = False
                End If
                v_pageNum += 1
            End While

            Dim v_frSearchGrid = New Xceed.Grid.TextRow(m_ResourceManager.GetString("DATARECEIVED") & " " & v_rowCount & " " & m_ResourceManager.GetString("ROW"))
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            SearchGrid.FixedFooterRows.Clear()
            SearchGrid.FixedFooterRows.Add(v_frSearchGrid)

            Me.pnlSearchResult.Controls.Clear()
            Me.pnlSearchResult.Controls.Add(SearchGrid)
            SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
            'btnWrite.Enabled = True
        Catch ex As Exception
            MsgBox(m_ResourceManager.GetString("ERR_DATAFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            LogError.Write("Error source: @FDS.frmCSVCompare.getFileDetail" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub fillDataGrid(ByVal pv_xGrid As GridControl, _
                            ByVal pv_strObjMsg As String, _
                            ByVal pv_strResource As String, _
                            ByVal pv_firstPage As Boolean, _
                            ByRef pv_RowCount As Integer, _
                            Optional ByVal pv_initHeader As Boolean = False, _
                            Optional ByVal pv_strTable As String = "", _
                            Optional ByVal pv_strFilter As String = "", _
                            Optional ByVal pv_intFromrow As Int32 = 0, _
                            Optional ByVal pv_intTorow As Int32 = 0, _
                            Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim v_dt As DataTable
        Dim v_dr As System.Data.DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            pv_xGrid.Columns.Clear()
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strColoumName As String
            Dim mv_strSTOCKTable As New DataTable
            Dim mv_strCUSTODYTable As New DataTable
            Dim filecode = Me.cboFileType.SelectedValue.ToString

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If pv_initHeader And pv_firstPage Then
                Dim v_fldname As String
                Dim v_fldname_ogr As String
                Dim v_fldname_en As String
                Dim v_defval As String
                Dim v_strSQL As String
                Dim v_strObjMsg As String
                Dim v_ws As BDSDeliveryManagement
                Dim v_xmlDocument1 As New Xml.XmlDocument
                Dim v_nodeList1 As Xml.XmlNodeList
                v_ws = New BDSDeliveryManagement
                v_strSQL = String.Format("SELECT * FROM CSVCOMPAREREPORTFLD WHERE instr('{0}',cmpid)>0 order by id ", mv_strVSDREPORTID)
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument1.LoadXml(v_strObjMsg)
                v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList1.Count - 1
                    'v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList1.Item(j).ChildNodes.Count - 1
                        With v_nodeList1.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME).ToUpper
                                Case "DESCRIPTION"
                                    v_fldname = v_strValue.Trim
                                Case "EN_DESCRIPTION"
                                    v_fldname_en = v_strValue.Trim
                                Case "FLDNAME"
                                    v_fldname_ogr = v_strValue.Trim
                                Case "DEFVAL"
                                    v_defval = v_strValue.Trim
                            End Select
                        End With
                    Next
                    'Next
                    'end
                    pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_fldname_ogr, GetType(System.String)))
                    pv_xGrid.Columns(v_fldname_ogr).Tag = v_defval


                    If Me.UserLanguage = "EN" Then
                        pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname_en
                    Else
                        pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname
                    End If

                    pv_xGrid.Columns(v_fldname_ogr).Width = 100
                    pv_xGrid.Columns(v_fldname_ogr).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                    pv_xGrid.Columns(v_fldname_ogr).CanBeSorted = True
                    '   End With
                Next
                Dim cCnt As Integer = v_nodeList1.Count
                If InStr(filecode_tradedate, "," + filecode + ",") > 0 Then
                    pv_xGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                    pv_xGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField("TRADE_DATE").Trim
                    pv_xGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                    pv_xGrid.Columns(cCnt.ToString).Width = 100
                End If
                pv_xGrid.DataRows.Clear()
            End If

            pv_xGrid.BeginInit()
            pv_xGrid.SelectedRows.Clear()
            If pv_firstPage Then
                pv_xGrid.DataRows.Clear()
            End If

            pv_RowCount = v_nodeList.Count
            For v_intCount = 0 To v_nodeList.Count - 1
                'If (v_intCount >= v_nodeList.Count - rowperpage) Then

                Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()
                Try
                    For Each v_xColumn In pv_xGrid.Columns
                        v_strColoumName = UCase(Trim(v_xColumn.FieldName))

                        'gan gia tri default tu defval

                        If (InStr(v_xColumn.Tag, "@", CompareMethod.Text) > 0) Then
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = Replace(v_xColumn.Tag, "@", "")
                        ElseIf (InStr(v_xColumn.Tag, "<$BUSDATE>", CompareMethod.Text) > 0) Then

                            v_xDataRow.Cells(v_xColumn.FieldName).Value = Me.BusDate
                        End If

                        If v_xColumn.FieldName = "TRADE_DATE" Or v_xColumn.Title = "TRADE_DATE" Then
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(dtpbackdate.EditValue Is DBNull.Value, "", CDate(dtpbackdate.EditValue).ToShortDateString)
                        End If

                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
                                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                                If Not (v_strValue Is DBNull.Value) Then
                                    If Trim(v_strValue) = "" Then
                                        v_strValue = Nothing
                                    End If
                                End If

                                If v_strFLDNAME = v_strColoumName Then
                                    If v_strColoumName <> "SIGNATURE" Then
                                        If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue = "0", False, True)
                                        Else
                                            Select Case v_xColumn.DataType.Name
                                                Case GetType(System.String).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                                Case GetType(System.Decimal).Name
                                                    If v_strValue = "" Then
                                                        v_strValue = 0
                                                    End If
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                                                Case GetType(Integer).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                                                Case GetType(Long).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                                                Case GetType(Double).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                                Case GetType(System.DateTime).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                                                Case GetType(System.Boolean).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))

                                                Case Else
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                                            End Select
                                        End If
                                        'ThongPM comment
                                        'v_xDataRow.EndEdit()

                                    End If

                                End If
                            End With
                        Next

                    Next
                    '  End If
                Finally
                    v_xDataRow.EndEdit()
                End Try
            Next

            pv_xGrid.EndInit()
            _FormatGridBefore(pv_xGrid, pv_strTable, pv_strResource, False, , pv_intFromrow, pv_intTorow, pv_intTotalrow)
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
            pv_xGrid.EndInit()
        End Try
    End Sub

    Private Sub dtpbackdate_Leave(sender As Object, e As EventArgs) Handles dtpbackdate.Leave
        If cboFileName.Visible = True Then
            getUpdateFileName()
        End If
    End Sub
End Class
