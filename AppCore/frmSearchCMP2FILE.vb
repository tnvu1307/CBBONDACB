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
Imports System.Threading.Tasks

'Imports DataAccessLayer

''Imports Xceed.Grid
''Imports ExcelLibrary.SpreadSheet

Public Class frmSearchCMP2FILE
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
    End Sub

    Public Sub New(ByVal pv_strLanguage As String, ByVal frmRptParameter As frmReportParameter)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        v_frmRptParameter = frmRptParameter
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowser As System.Windows.Forms.Button
    Friend WithEvents txtFromFile As System.Windows.Forms.TextBox
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents lblFromFile As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents grbFiles As System.Windows.Forms.GroupBox
    Friend WithEvents lblTXDATE As System.Windows.Forms.Label
    Friend WithEvents dtpTXDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFileCSV As System.Windows.Forms.Button
    Friend WithEvents cboFileName As AppCore.ComboBoxEx
    Friend WithEvents cboFileType As AppCore.ComboBoxEx
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchCMP2FILE))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.grbSearchResult = New System.Windows.Forms.GroupBox()
        Me.pnlSearchResult = New System.Windows.Forms.Panel()
        Me.btnBrowser = New System.Windows.Forms.Button()
        Me.txtFromFile = New System.Windows.Forms.TextBox()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.lblFromFile = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grbFiles = New System.Windows.Forms.GroupBox()
        Me.lblFileType = New System.Windows.Forms.Label()
        Me.cboFileType = New AppCore.ComboBoxEx()
        Me.cboFileName = New AppCore.ComboBoxEx()
        Me.btnFileCSV = New System.Windows.Forms.Button()
        Me.lblTXDATE = New System.Windows.Forms.Label()
        Me.dtpTXDATE = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.grbFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1038, 50)
        Me.Panel1.TabIndex = 22
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(16, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(8, 127)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(1023, 369)
        Me.grbSearchResult.TabIndex = 24
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
        Me.pnlSearchResult.Size = New System.Drawing.Size(1017, 349)
        Me.pnlSearchResult.TabIndex = 0
        '
        'btnBrowser
        '
        Me.btnBrowser.Location = New System.Drawing.Point(571, 36)
        Me.btnBrowser.Name = "btnBrowser"
        Me.btnBrowser.Size = New System.Drawing.Size(31, 22)
        Me.btnBrowser.TabIndex = 2
        Me.btnBrowser.Tag = "btnBrowser"
        Me.btnBrowser.Text = "...."
        '
        'txtFromFile
        '
        Me.txtFromFile.Location = New System.Drawing.Point(8, 38)
        Me.txtFromFile.Name = "txtFromFile"
        Me.txtFromFile.Size = New System.Drawing.Size(558, 20)
        Me.txtFromFile.TabIndex = 1
        Me.txtFromFile.Text = "txtFromFile"
        '
        'btnCompare
        '
        Me.btnCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompare.Location = New System.Drawing.Point(780, 36)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(75, 22)
        Me.btnCompare.TabIndex = 3
        Me.btnCompare.Tag = "btnCompare"
        Me.btnCompare.Text = "btnCompare"
        '
        'lblFromFile
        '
        Me.lblFromFile.AutoSize = True
        Me.lblFromFile.Location = New System.Drawing.Point(8, 16)
        Me.lblFromFile.Name = "lblFromFile"
        Me.lblFromFile.Size = New System.Drawing.Size(56, 13)
        Me.lblFromFile.TabIndex = 2
        Me.lblFromFile.Tag = "lblFromFile"
        Me.lblFromFile.Text = "lblFromFile"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(940, 36)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(860, 36)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 22)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        '
        'grbFiles
        '
        Me.grbFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiles.Controls.Add(Me.lblFileType)
        Me.grbFiles.Controls.Add(Me.cboFileType)
        Me.grbFiles.Controls.Add(Me.cboFileName)
        Me.grbFiles.Controls.Add(Me.btnFileCSV)
        Me.grbFiles.Controls.Add(Me.lblTXDATE)
        Me.grbFiles.Controls.Add(Me.dtpTXDATE)
        Me.grbFiles.Controls.Add(Me.btnExport)
        Me.grbFiles.Controls.Add(Me.btnCancel)
        Me.grbFiles.Controls.Add(Me.lblFromFile)
        Me.grbFiles.Controls.Add(Me.btnCompare)
        Me.grbFiles.Controls.Add(Me.txtFromFile)
        Me.grbFiles.Controls.Add(Me.btnBrowser)
        Me.grbFiles.Location = New System.Drawing.Point(8, 56)
        Me.grbFiles.Name = "grbFiles"
        Me.grbFiles.Size = New System.Drawing.Size(1023, 65)
        Me.grbFiles.TabIndex = 1
        Me.grbFiles.TabStop = False
        Me.grbFiles.Tag = "grbFiles"
        Me.grbFiles.Text = "grbFiles"
        '
        'lblFileType
        '
        Me.lblFileType.AutoSize = True
        Me.lblFileType.Location = New System.Drawing.Point(388, 17)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(57, 13)
        Me.lblFileType.TabIndex = 33
        Me.lblFileType.Tag = "lblFileType"
        Me.lblFileType.Text = "lblFileType"
        Me.lblFileType.Visible = False
        '
        'cboFileType
        '
        Me.cboFileType.DisplayMember = "DISPLAY"
        Me.cboFileType.FormattingEnabled = True
        Me.cboFileType.Location = New System.Drawing.Point(441, 13)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(125, 21)
        Me.cboFileType.TabIndex = 32
        Me.cboFileType.ValueMember = "VALUE"
        Me.cboFileType.Visible = False
        '
        'cboFileName
        '
        Me.cboFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFileName.DisplayMember = "DISPLAY"
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(8, 37)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(558, 21)
        Me.cboFileName.TabIndex = 31
        Me.cboFileName.ValueMember = "VALUE"
        Me.cboFileName.Visible = False
        '
        'btnFileCSV
        '
        Me.btnFileCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileCSV.Location = New System.Drawing.Point(608, 36)
        Me.btnFileCSV.Name = "btnFileCSV"
        Me.btnFileCSV.Size = New System.Drawing.Size(107, 22)
        Me.btnFileCSV.TabIndex = 30
        Me.btnFileCSV.Tag = "btnFileCSV"
        Me.btnFileCSV.Text = "Choose VSD File"
        Me.btnFileCSV.Visible = False
        '
        'lblTXDATE
        '
        Me.lblTXDATE.AutoSize = True
        Me.lblTXDATE.Location = New System.Drawing.Point(143, 16)
        Me.lblTXDATE.Name = "lblTXDATE"
        Me.lblTXDATE.Size = New System.Drawing.Size(75, 13)
        Me.lblTXDATE.TabIndex = 29
        Me.lblTXDATE.Text = "Date Compare"
        '
        'dtpTXDATE
        '
        Me.dtpTXDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpTXDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTXDATE.Location = New System.Drawing.Point(231, 15)
        Me.dtpTXDATE.Name = "dtpTXDATE"
        Me.dtpTXDATE.Size = New System.Drawing.Size(82, 20)
        Me.dtpTXDATE.TabIndex = 0
        '
        'frmSearchCMP2FILE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1038, 501)
        Me.Controls.Add(Me.grbSearchResult)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmSearchCMP2FILE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "frmSearchCMP2FILE"
        Me.Text = "frmSearchCMP2FILE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbSearchResult.ResumeLayout(False)
        Me.grbFiles.ResumeLayout(False)
        Me.grbFiles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Property"
    Const c_ResourceManager = "AppCore.frmSearchCMP2FILE-"
    Private mv_strFileName As String = String.Empty
    Private mv_strFULLDATA As String = String.Empty
    Private mv_ResourceManager As Resources.ResourceManager
    Public SearchGrid As GridEx
    Private mv_strModuleCode As String
    Private mv_strTableName As String
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
    Private mv_hOldData As New Hashtable
    Private mv_hFileData As New Hashtable
    Private mv_strKeyCMP As String = String.Empty
    Private mv_strFIELDCMP As String = String.Empty
    Private mv_CountContainer As Integer     ' Bao.Nguyen tao bien tam chua count de xu ly
    Private mv_data As DataTable
    Private mv_GridData As DataTable
    Private mv_strDataWriteToDB As String = ""
    Private mv_GridDataDetail As DataTable
    Public mv_OldData As DataSet
    ''Tham so dau vao cho bao cao
    Public mv_strStoredname As String
    Public mv_arrRptParam() As ReportParameters    'mang tham so bao cao
    Public mv_intNumOfParam As Integer     'So luong tham so cua bao cao

    Private mv_arrObjFields() As CFieldMaster
    Private mv_srcFileName As String
    Private mv_strTxdate As String = String.Empty
    Private mv_strISRPT As String = "N"
    Private mv_arrCMPCODE() As String
    Private mv_strISNUM As String = "N"
    Private mv_strSHEETNAME As String = "SHEET1"

    Dim v_frmRptParameter As New frmReportParameter()

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

    Public Property FULLDATA() As String
        Get
            Return mv_strFULLDATA
        End Get
        Set(ByVal Value As String)
            mv_strFULLDATA = Value
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
#End Region

#Region " Form methods "
    Protected Overridable Function InitDialog()

        AddHandler btnExport.Click, AddressOf Button_Click
        AddHandler btnCancel.Click, AddressOf Button_Click
        AddHandler btnBrowser.Click, AddressOf Button_Click
        AddHandler btnCompare.Click, AddressOf Button_Click

        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        'DoResizeForm()
        InitGrid(Me.Searchcode)
        Me.dtpTXDATE.Value = DateTime.ParseExact(Me.BusDate, "dd/MM/yyyy", Nothing)
        Me.dtpTXDATE.Enabled = False
        If Me.Searchcode = "CA1001" Then
            Me.dtpTXDATE.Enabled = True
        ElseIf Me.Searchcode = "SE0087" Then
            btnFileCSV.Visible = True
            If v_frmRptParameter.ObjectName <> "" Then
                Me.dtpTXDATE.Enabled = True
            End If
        End If
        Me.txtFromFile.Text = String.Empty
        'sLoadUserInterface(Me)
        lblCaption.Text = Me.Desc
        'Me.Text = String.Format("{0}[{1}]", Me.Text, Me.Desc)

        Try
            Dim v_strSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_TOTAL As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As BDSDeliveryManagement

            v_strSQL = String.Format("SELECT COUNT(1) TOTAL FROM VSD_MAP_COMPARE WHERE VIEWID = '{0}'", Me.Searchcode)
            v_ws = New BDSDeliveryManagement
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "TOTAL"
                                v_TOTAL = v_strVALUE
                        End Select
                    End With
                Next
            Next
            Dim count As Integer = Convert.ToInt32(v_TOTAL)
            mv_CountContainer = count
            If count > 0 Then
                btnFileCSV.Visible = True
                Me.dtpTXDATE.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub InitGrid(ByVal pv_strObjname As String)
        SearchGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))

        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        'Lay thong so trong search
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        ''Khoi tao data
        mv_GridDataDetail = New DataTable
        Dim v_strFLDNAME, v_strVALUE, v_strFieldCode, v_strFieldType, v_strFieldFormat, v_strFieldName, v_strEnFieldName, v_strWidth, v_strFIELDCMP, v_strFIELDCMPKEY As String
        Dim v_strCmdInquiry As String = "  SELECT * FROM SEARCHFLD WHERE SEARCHCODE ='" & pv_strObjname & "'  AND FIELDCMP IS NOT NULL  ORDER BY POSITION  "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry)

        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'Add cot phan loai
        SearchGrid.Columns.Add(New Xceed.Grid.Column("G_TYPE", GetType(System.String)))
        SearchGrid.Columns("G_TYPE").Title = ResourceManager.GetString("grid.TYPE")
        SearchGrid.Columns("G_TYPE").Width = 60
        ReDim mv_arrCMPCODE(v_nodeList.Count - 1)

        mv_GridDataDetail.Columns.Add("G_TYPE", GetType(System.String))

        ''Tao du lieu tren HT
        For v_intCount As Integer = 0 To v_nodeList.Count - 1
            For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "FIELDCODE"
                            v_strFieldCode = v_strVALUE
                        Case "FIELDTYPE"
                            v_strFieldType = v_strVALUE
                        Case "FIELDNAME"
                            v_strFieldName = "[HT]_" & v_strVALUE
                        Case "EN_FIELDNAME"
                            v_strEnFieldName = "[HT]_" & v_strVALUE
                        Case "WIDTH"
                            v_strWidth = CDec(v_strVALUE)
                        Case "FIELDCMP"
                            v_strFIELDCMP = v_strVALUE
                        Case "FIELDCMPKEY"
                            v_strFIELDCMPKEY = v_strVALUE
                        Case "FORMAT"
                            v_strFieldFormat = Trim(v_strVALUE)
                    End Select
                End With
            Next

            Select Case v_strFieldType
                Case "D"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "N"
                    'Dim v_decimalColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(System.Decimal))
                    'If (Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0) And v_strFieldFormat <> "0" Then
                    '    v_decimalColumn.FormatSpecifier = v_strFieldFormat
                    'Else
                    '    v_decimalColumn.FormatSpecifier = "#,##0.00"
                    'End If
                    'SearchGrid.Columns.Add(v_decimalColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "I"
                    'Dim v_integerColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Integer))
                    'If Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0 Then
                    '    v_integerColumn.FormatSpecifier = v_strFieldFormat
                    'Else
                    '    v_integerColumn.FormatSpecifier = "#,##0"
                    'End If

                    'SearchGrid.Columns.Add(v_integerColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "L"
                    'Dim v_longColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Long))
                    'v_longColumn.FormatSpecifier = "#,##0"
                    'SearchGrid.Columns.Add(v_longColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "C"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "B"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.Boolean)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
            End Select
            If Not v_strFieldCode Is Nothing Then
                SearchGrid.Columns(v_strFieldCode).Title = IIf(Me.UserLanguage = gc_LANG_VIETNAMESE, v_strFieldName, v_strEnFieldName)
                SearchGrid.Columns(v_strFieldCode).Width = v_strWidth
            End If
        Next

        'Add cot phan cach
        SearchGrid.Columns.Add(New Xceed.Grid.Column("G_XX", GetType(System.String)))
        SearchGrid.Columns("G_XX").Title = "__"
        SearchGrid.Columns("G_XX").Width = 10

        mv_GridDataDetail.Columns.Add("G_XX", GetType(System.String))

        'Khoi tao phan du lieu tren file
        For v_intCount As Integer = 0 To v_nodeList.Count - 1
            For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "FIELDCODE"
                            v_strFieldCode = "F_" & v_strVALUE
                        Case "FIELDTYPE"
                            v_strFieldType = v_strVALUE
                        Case "FIELDNAME"
                            v_strFieldName = "[File]_" & v_strVALUE
                        Case "EN_FIELDNAME"
                            v_strEnFieldName = "[File]_" & v_strVALUE
                        Case "WIDTH"
                            v_strWidth = CDec(v_strVALUE)
                        Case "FIELDCMP"
                            v_strFIELDCMP = v_strVALUE
                        Case "FIELDCMPKEY"
                            v_strFIELDCMPKEY = v_strVALUE
                        Case "FORMAT"
                            v_strFieldFormat = Trim(v_strVALUE)
                    End Select
                End With
            Next

            Select Case v_strFieldType
                Case "D"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "N"
                    'Dim v_decimalColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(System.Decimal))
                    'If (Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0) And v_strFieldFormat <> "0" Then
                    '    v_decimalColumn.FormatSpecifier = v_strFieldFormat
                    'Else
                    '    v_decimalColumn.FormatSpecifier = "#,##0.00"
                    'End If
                    'SearchGrid.Columns.Add(v_decimalColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "I"
                    'Dim v_integerColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Integer))
                    'If Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0 Then
                    '    v_integerColumn.FormatSpecifier = v_strFieldFormat
                    'Else
                    '    v_integerColumn.FormatSpecifier = "#,##0"
                    'End If

                    'SearchGrid.Columns.Add(v_integerColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "L"
                    'Dim v_longColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Long))
                    'v_longColumn.FormatSpecifier = "#,##0"
                    'SearchGrid.Columns.Add(v_longColumn)
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "C"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
                Case "B"
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.Boolean)))
                    mv_GridDataDetail.Columns.Add(v_strFieldCode, GetType(System.String))
            End Select
            If Not v_strFieldCode Is Nothing Then
                SearchGrid.Columns(v_strFieldCode).Title = IIf(Me.UserLanguage = gc_LANG_VIETNAMESE, v_strFieldName, v_strEnFieldName)
                SearchGrid.Columns(v_strFieldCode).Width = v_strWidth
            End If
        Next

        Dim FooterRow As New Xceed.Grid.TextRow(ResourceManager.GetString("grid.Footer") & " [" & SearchGrid.DataRows.Count.ToString & "]")
        '
        'FooterRow
        '
        FooterRow.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        FooterRow.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        SearchGrid.FixedFooterRows.Clear()
        SearchGrid.FixedFooterRows.Add(FooterRow)

        Me.pnlSearchResult.Controls.Clear()
        Me.pnlSearchResult.Controls.Add(SearchGrid)
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
    End Sub
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
        Me.btnBrowser.Text = mv_ResourceManager.GetString("btnOpenFile")
        Me.Text = mv_ResourceManager.GetString("frmSearchCMP2FILE")
    End Sub


    Private Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                        CType(v_ctrlTmp, TabPage).Text = ResourceManager.GetString(v_ctrlTmp.Tag)
                    Next
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                    CType(v_ctrl, TabPage).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).Text = vbNullString
                ElseIf TypeOf (v_ctrl) Is RadioButton Then
                    CType(v_ctrl, RadioButton).Text = ResourceManager.GetString(v_ctrl.Tag)
                End If
            Next
            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Or (Me.Text.Trim() = Me.Name) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Form event"
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (sender Is btnExport) Then
                OnExport()
            ElseIf (sender Is btnCancel) Then
                OnClose()
            ElseIf (sender Is btnBrowser) Then
                OnBrowser()
            ElseIf (sender Is btnCompare) Then
                OnCompare()
                OnSave()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmSearchCMP2FILE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

#End Region

#Region "Private Sub"
    Private Sub OnClose()
        Me.Close()
    End Sub
    Private Sub OnExport()
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
                        MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else

                    'Dim v_dataset As New DataSet
                    'v_dataset.Tables.Add(mv_GridDataDetail)
                    ' ''ExcelLibrary.DataSetHelper.CreateWorkbook(v_strFileName, v_dataset)
                    'Dim v_ew As New ExcelLib
                    'v_ew.WriteXLSFile(v_strFileName, v_dataset)
                    'mv_GridData.Dispose()
                    'v_dataset.Dispose()
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
                        MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
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
                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnExport" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetOldData_bk()

        Try

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_countmsg As Integer = 0
            Dim v_ckey As Integer = 0



            Dim v_strFLDNAME, v_strVALUE As String
            v_xmlDocument.LoadXml(Me.FULLDATA)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                Dim v_strHKey As String = String.Empty
                Dim v_strHValue As String = String.Empty
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        If InStr(mv_strKeyCMP, v_strFLDNAME) > 0 Then
                            v_strHKey = v_strHKey & "|" & v_strVALUE
                        End If
                        If InStr(mv_strFIELDCMP, v_strFLDNAME) > 0 Then
                            v_strHValue = v_strHValue & "|" & v_strVALUE
                        End If
                    End With
                Next
                If Not mv_hOldData.ContainsKey(v_strHKey) Then
                    mv_hOldData.Add(v_strHKey, v_strHValue)
                Else
                    'Truong hop trung key
                    v_ckey = v_ckey + 1
                    mv_hOldData.Add(v_strHKey & "[" & v_ckey & "]", v_strHValue)
                    'Thong bao trung key
                    If v_countmsg < 1 Then
                        MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.OlddataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End If
                    v_countmsg = v_countmsg + 1
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                                   & "Error code: System error!" & vbNewLine _
                                   & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetOldData()
        ''Lay du lieu trong he thong
        Try

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_countmsg As Integer = 0
            Dim v_ckey As Integer = 0
            Dim v_ds As DataSet

            Dim v_strFLDNAME, v_strVALUE As String

            If Me.ISRPT = "Y" Then ' Lay du lieu theo duong bao cao
                v_ckey = 0
                v_countmsg = 0
                'Lay theo duong bao cao
                Dim v_ws As New BDSRptDeliveryManagement
                Dim v_xmlDocumentMessage As New Xml.XmlDocument

                Dim v_wsObj As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_xmlDoc As New XmlDocumentEx
                Dim v_strObjMsg As String = String.Empty
                If Me.Searchcode = "CA1001" Then
                    PrepareReportParams(dtpTXDATE.Value.ToString("dd/MM/yyyy"))
                ElseIf Me.Searchcode = "SE0087" Or Me.Searchcode = "ODCMPVSD" Then
                    mv_arrRptParam(0).ParamValue = "A"
                End If
                'PrepareReportParams(Me.dtpTXDATE.Value.ToString)
                v_strObjMsg = BuildXMLRptMsg("N", mv_strStoredname, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                'Setup attributes
                v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                v_strObjMsg = v_xmlDocumentMessage.InnerXml

                v_ws.Message(v_strObjMsg)
                'Create report
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_ds = ConvertXmlDocToDataSet(v_xmlDocument)
                'Tao Hashtable


                For k As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    Dim v_Key As String = String.Empty
                    Dim v_VALUE As String = String.Empty
                    'Sap xep theo thu tu trong SEARCHFLD
                    ''TH1: Lay theo ten cot
                    ''TH2: Lay theo thu tu
                    For i As Integer = 0 To mv_data.Rows.Count - 1
                        For Each Dt As DataColumn In v_ds.Tables(0).Columns
                            ''FIELDCODE,FIELDCMP
                            If Dt.ColumnName = mv_data.Rows(i)("FIELDCODE").ToString Then
                                Select Case Dt.DataType.Name
                                    Case GetType(System.DateTime).Name
                                        If Not IsDBNull(v_ds.Tables(0).Rows(k)(Dt.ColumnName)) Then
                                            v_VALUE = v_VALUE & "|" & gf_CorrectStringField(Format(v_ds.Tables(0).Rows(k)(Dt.ColumnName), gc_FORMAT_DATE))
                                        Else
                                            v_VALUE = v_VALUE & "|" & v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                        End If

                                    Case GetType(System.Decimal).Name
                                        Dim v_mValue As String
                                        v_mValue = gf_CorrectStringField(gf_CorrectNumericField(v_ds.Tables(0).Rows(k)(Dt.ColumnName)) * Math.Pow(1, 1))
                                        v_VALUE = v_VALUE & "|" & v_mValue 'v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim

                                    Case GetType(System.Double).Name
                                        v_VALUE = v_VALUE & "|" & v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                    Case Else
                                        v_VALUE = v_VALUE & "|" & v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                End Select
                                'v_VALUE = v_VALUE & "|" & v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                    'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                    v_Key = v_Key & "|" & modCommond.CutMark(v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim).Replace(" ", "").ToUpper()
                                    'End If
                                End If
                                Exit For
                            End If
                        Next
                    Next
                    If Not mv_hOldData.ContainsKey(v_Key) Then
                        If v_Key.Replace("|", "").Length > 0 Then
                            mv_hOldData.Add(v_Key, v_VALUE)
                        End If
                    Else
                        'Truong hop trung key
                        If v_Key.Replace("|", "").Length > 0 Then
                            ' v_ckey = v_ckey + 1
                            v_Key = HandleDuplicateKey(mv_hOldData, v_Key)
                            mv_hOldData.Add(v_Key, v_VALUE)
                            '  mv_hOldData.Add(v_Key & "[" & v_ckey & "]", v_VALUE)



                            'Thong bao trung key
                            If v_countmsg < 1 Then
                                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.OlddataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            v_countmsg = v_countmsg + 1
                        End If
                    End If
                Next
            Else
                If Not IsDBNull(mv_OldData) Then
                    For k As Integer = 0 To mv_OldData.Tables(0).Rows.Count - 1
                        Dim v_Key As String = String.Empty
                        Dim v_VALUE As String = String.Empty
                        'Sap xep theo thu tu trong SEARCHFLD
                        For i As Integer = 0 To mv_data.Rows.Count - 1
                            For Each Dt As DataColumn In mv_OldData.Tables(0).Columns
                                If Dt.ColumnName = mv_data.Rows(i)("FIELDCODE").ToString Then
                                    Select Case Dt.DataType.Name
                                        Case GetType(System.DateTime).Name

                                            v_VALUE = v_VALUE & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(mv_OldData.Tables(0).Rows(k)(Dt.ColumnName)), gc_FORMAT_DATE))


                                        Case GetType(System.Decimal).Name
                                            Dim v_mValue As String
                                            v_mValue = gf_CorrectStringField(gf_CorrectNumericField(mv_OldData.Tables(0).Rows(k)(Dt.ColumnName)) * Math.Pow(1, 1))
                                            v_VALUE = v_VALUE & "|" & v_mValue 'v_ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                        Case GetType(System.Double).Name
                                            v_VALUE = v_VALUE & "|" & mv_OldData.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                        Case Else
                                            v_VALUE = v_VALUE & "|" & mv_OldData.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                    End Select
                                    If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                        'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                        v_Key = v_Key & "|" & mv_OldData.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                        'End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        If Not mv_hOldData.ContainsKey(v_Key) Then
                            If v_Key.Replace("|", "").Length > 0 Then
                                mv_hOldData.Add(v_Key, v_VALUE)
                            End If
                        Else
                            'Truong hop trung key
                            If v_Key.Replace("|", "").Length > 0 Then
                                v_ckey = v_ckey + 1
                                mv_hOldData.Add(v_Key & "[" & v_ckey & "]", v_VALUE)

                                'Thong bao trung key
                                If v_countmsg < 1 Then
                                    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.OlddataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                End If
                                v_countmsg = v_countmsg + 1
                            End If
                        End If
                    Next
                Else
                    v_xmlDocument.LoadXml(Me.FULLDATA)
                    v_ckey = 0
                    v_countmsg = 0
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For v_intCount = 0 To v_nodeList.Count - 1
                        Dim v_strHKey As String = String.Empty
                        Dim v_strHValue As String = String.Empty
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                                If InStr(mv_strKeyCMP, v_strFLDNAME) > 0 Then
                                    v_strHKey = v_strHKey & "|" & v_strVALUE
                                End If
                                If InStr(mv_strFIELDCMP, v_strFLDNAME) > 0 Then
                                    v_strHValue = v_strHValue & "|" & v_strVALUE
                                End If
                            End With
                        Next
                        If Not mv_hOldData.ContainsKey(v_strHKey) Then
                            mv_hOldData.Add(v_strHKey, v_strHValue)
                        Else
                            'Truong hop trung key
                            v_ckey = v_ckey + 1
                            mv_hOldData.Add(v_strHKey & "[" & v_ckey & "]", v_strHValue)
                            'Thong bao trung key
                            If v_countmsg < 1 Then
                                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.OlddataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            v_countmsg = v_countmsg + 1
                        End If
                    Next
                End If

            End If


        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                                   & "Error code: System error!" & vbNewLine _
                                   & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetKeyCMP()
        Try
            Dim v_strCondition As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFieldCode, v_strFieldType, v_strFIELDCMP, v_strFIELDCMPKEY As String
            Dim v_strFLDNAME, v_strVALUE As String
            mv_data = New DataTable
            mv_data.Columns.Add("FIELDCODE", GetType(String))
            mv_data.Columns.Add("FIELDCMP", GetType(String))
            mv_data.Columns.Add("FIELDCMPKEY", GetType(String))
            mv_data.Columns.Add("FIELDTYPE", GetType(String))

            v_strCondition = String.Format("UPPER(SEARCHCODE) = '{0}' AND FIELDCMP IS NOT NULL ORDER BY POSITION", mv_strSearchcode)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "SELECT FIELDCODE,FIELDTYPE,FIELDCMP,FIELDCMPKEY FROM V_SEARCHCD WHERE 0=0 "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strCondition)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrCMPCODE(v_nodeList.Count - 1)
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "FIELDCODE"
                                v_strFieldCode = v_strVALUE
                            Case "FIELDTYPE"
                                v_strFieldType = v_strVALUE
                            Case "FIELDCMP"
                                v_strFIELDCMP = v_strVALUE
                                '' Y : lay theo thu tu, N: Lay theo ten cot 
                                If IsNumeric(v_strFIELDCMP) Then
                                    mv_strISNUM = "Y"
                                Else
                                    mv_strISNUM = "N"
                                End If
                            Case "FIELDCMPKEY"
                                v_strFIELDCMPKEY = v_strVALUE
                        End Select
                    End With
                Next
                mv_data.Rows.Add(v_strFieldCode, v_strFIELDCMP, v_strFIELDCMPKEY)
                mv_strFIELDCMP = mv_strFIELDCMP & "|" & v_strFIELDCMP
                If v_strFIELDCMPKEY = "Y" Then
                    mv_strKeyCMP = mv_strKeyCMP & "|" & v_strFIELDCMP
                End If
                mv_arrCMPCODE(v_intCount) = v_strFIELDCMP

            Next

        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                                              & "Error code: System error!" & vbNewLine _
                                              & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetNewDataFromXML()
        Dim v_fsReadXml As System.IO.FileStream
        Dim v_fsReadXsd As System.IO.FileStream
        Try
            Dim v_strFilename As String = mv_strFileName
            v_fsReadXml = New System.IO.FileStream(v_strFilename, System.IO.FileMode.Open)
            'Dim v_strConfig As String
            'Dim v_strOrderBy As String = ""
            'v_strConfig = Me.Searchcode.Remove(2, 1) & "ORDER"
            'v_strOrderBy = ConfigurationManager.AppSettings(v_strConfig)
            'Dim v_strXsdFile As String = ""
            'v_strConfig = Me.Searchcode.Remove(2, 1) & "XSDFILE"
            'v_strXsdFile = ConfigurationManager.AppSettings(v_strConfig)
            'If v_strXsdFile.Length <> 0 Then
            '    v_strXsdFile = GetDirectoryName(ExecutablePath) & v_strXsdFile
            '    v_fsReadXsd = New System.IO.FileStream(v_strXsdFile, System.IO.FileMode.Open)
            'End If
            'Dim v_arrClidx(20) As String, v_strSort As String = ""
            Dim ds As DataSet = New DataSet()
            Dim dt As New DataTable
            'ds.ReadXmlSchema()
            ds.ReadXml(v_fsReadXml)
            'If Not v_strOrderBy Is Nothing Then
            '    v_arrClidx = v_strOrderBy.Split(",")
            '    For i As Integer = 0 To v_arrClidx.Length - 2
            '        v_strSort &= ds.Tables(0).Columns(Convert.ToInt16(v_arrClidx(i)) - 1).ColumnName & " ASC, "
            '    Next
            '    v_strSort &= ds.Tables(0).Columns(Convert.ToInt16(v_arrClidx(v_arrClidx.Length - 1)) - 1).ColumnName & " ASC"
            'End If

            'For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
            '    v_arrClidx(i) = ds.Tables(0).Columns(i).ColumnName
            '    ds.Tables(0).Columns(i).ColumnName = i + 1 
            'Next
            If ds.Tables(0).Rows.Count > 0 Then
                '  ds.Tables(0).DefaultView.Sort = v_strSort
                dt = ds.Tables(0).DefaultView.ToTable()
            Else
                '  ds.Tables(1).DefaultView.Sort = v_strSort
                dt = ds.Tables(1).DefaultView.ToTable()
            End If

            'For i As Integer = 0 To dt.Columns.Count - 1
            '    dt.Columns(i).ColumnName = v_arrClidx(i)
            'Next
            'Tao Hashtable
            Dim v_strKey As String = String.Empty
            Dim v_strValue As String = String.Empty
            Dim v_countmsg As Integer = 0
            Dim v_ckey As Integer = 0
            ''TH1: Lay theo ten cot
            ''TH2: Lay theo thu tu tren file
            If mv_strISNUM = "Y" Then
                ''1
                For k As Integer = 0 To dt.Rows.Count - 1
                    v_strKey = String.Empty
                    v_strValue = String.Empty
                    'Sap xep theo thu tu trong SEARCHFLD
                    For i As Integer = 0 To mv_data.Rows.Count - 1
                        For j As Integer = 0 To dt.Columns.Count - 1
                            If j = mv_data.Rows(i)("FIELDCMP").ToString Then
                                v_strValue = v_strValue & "|" & dt.Rows(k)(j).ToString.Trim
                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                    'If dt.Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                    v_strKey = v_strKey & "|" & modCommond.CutMark(dt.Rows(k)(j).ToString.Trim.Replace(" ", "")).ToUpper
                                    'End If
                                End If
                                Exit For
                            End If
                        Next
                    Next

                    If Not mv_hFileData.ContainsKey(v_strKey) Then
                        If v_strKey.Replace("|", "").Length > 0 Then
                            mv_hFileData.Add(v_strKey, v_strValue)
                        End If
                    Else
                        'Truong hop trung key
                        If v_strKey.Replace("|", "").Length > 0 Then
                            v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                            mv_hFileData.Add(v_strKey, v_strValue)

                            'Thong bao trung key
                            'If v_countmsg < 1 Then
                            '    MsgBox(mv_ResourceManager.GetString("frmCompareTradingResult.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            'End If
                            'v_countmsg = v_countmsg + 1
                        End If
                    End If
                Next
            Else
                '''2
                For k As Integer = 0 To dt.Rows.Count - 1
                    v_strKey = String.Empty
                    v_strValue = String.Empty
                    'Sap xep theo thu tu trong SEARCHFLD
                    For i As Integer = 0 To mv_data.Rows.Count - 1
                        For Each dc As DataColumn In dt.Columns
                            Dim v_strXSLColumn As String = modCommond.CutMark(dc.ColumnName.ToString.Replace(" ", "")).ToUpper
                            Dim v_strFieldCMP As String = mv_data.Rows(i)("FIELDCMP").ToString.ToUpper
                            If v_strXSLColumn = v_strFieldCMP Then
                                v_strValue = v_strValue & "|" & dt.Rows(k)(dc.ColumnName).ToString.Trim
                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                    'If dt.Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                    v_strKey = v_strKey & "|" & modCommond.CutMark(dt.Rows(k)(dc.ColumnName).ToString.Trim.Replace(" ", "")).ToUpper
                                    'End If
                                End If
                                Exit For
                            End If
                        Next
                    Next
                    If Not mv_hFileData.ContainsKey(v_strKey) Then
                        If v_strKey.Replace("|", "").Length > 0 Then
                            mv_hFileData.Add(v_strKey, modCommond.CutMark(v_strValue))
                        End If
                    Else
                        'Truong hop trung key
                        If v_strKey.Replace("|", "").Length > 0 Then
                            v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                            mv_hFileData.Add(v_strKey, v_strValue)

                            'Thong bao trung key
                            'If v_countmsg < 1 Then
                            '    MsgBox(mv_ResourceManager.GetString("frmCompareTradingResult.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            'End If
                            'v_countmsg = v_countmsg + 1
                        End If
                    End If
                Next
            End If


            'Close
            ds.Dispose()
            '  v_fsReadXsd.Close()
            v_fsReadXml.Close()
        Catch ex As Exception
            ' v_fsReadXsd.Close()
            v_fsReadXml.Close()
            LogError.Write("Error source: @VSTP.frmCompareTradingResult.OnCompare" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'T07/2017 STP
    Function ReadCSV(ByVal path As String, ByVal ConvertTypeCSV As Char()) As System.Data.DataTable

        Try

            Dim sr As New StreamReader(path)
            Dim fullFileStr As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()

            Dim lines As String() = fullFileStr.Split(ControlChars.Lf)
            Dim recs As New DataTable()
            Dim sArr As String() = lines(0).Split(ConvertTypeCSV)

            For Each s As String In sArr
                recs.Columns.Add(New DataColumn())
            Next

            Dim row As DataRow
            Dim finalLine As String = ""
            For Each line As String In lines
                row = recs.NewRow()
                finalLine = line.Replace(Convert.ToString(ControlChars.Cr), "")
                row.ItemArray = finalLine.Split(ConvertTypeCSV)
                recs.Rows.Add(row)
            Next

            Return recs

        Catch ex As Exception
            'Throw ex
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.GetNewData.ReadCSV" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    'Private Function HandleDuplicateKey(ByVal pv_ht As Hashtable, ByVal pv_strKey As String) As String
    '    Dim v_strKey As String
    '    For i As Integer = 1 To pv_ht.Count
    '        v_strKey = pv_strKey & "[" & i & "]"
    '        If Not pv_ht.ContainsKey(v_strKey) Then
    '            Return v_strKey
    '        End If
    '    Next
    '    Return pv_strKey
    'End Function

    'End T07/2017 STP
    'T07/2017 STP
    Private Sub GetNewData()

        Try
            'T07/2017 STP
            Dim v_strKey As String = String.Empty
            Dim v_strValue As String = String.Empty
            If InStr(mv_strFileName, ".csv") > 0 Or (cboFileName.Visible And cboFileName.Text <> "") = True Then
                Dim v_FormatDate = String.Empty
                Dim dtcsv As DataTable
                '14/09/2016 NamTv chinh lay tham so file .csv tren sysvar
                Dim v_strCmdInquiry As String
                v_strCmdInquiry = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME='CONVERTTYPECSV' AND GRNAME='SYSTEM'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                v_ws.Message(v_strObjMsg)
                Dim v_xmlDocument As New System.Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_nodeEntry As Xml.XmlNode
                Dim v_strFLDNAME As String
                Dim v_ConvertTypeCSV As String

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
                                        v_ConvertTypeCSV = Trim(v_strValue)
                                        Exit For
                                End Select
                            End With
                        Next
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

                Dim v_ConvertTypeCSVs As String() = v_ConvertTypeCSV.Split(" ")
                Dim ArrCSV(v_ConvertTypeCSVs.Count - 1) As Char
                For k As Integer = 0 To v_ConvertTypeCSVs.Count - 1
                    ArrCSV(k) = Convert.ToChar(v_ConvertTypeCSVs(k).ToString)
                Next
                'Tao Hashtable

                If cboFileName.Visible = False Then
                    dtcsv = ReadCSV(mv_strFileName, ArrCSV)
                Else
                    If Me.Searchcode = "SE0087" Then
                        dtcsv = getCSVDetail("DE083")
                    Else
                        dtcsv = getCSVDetail(cboFileType.SelectedValue)
                    End If
                End If

                If mv_strISNUM = "Y" Then
                    For k As Integer = 0 To dtcsv.Rows.Count - 1
                        v_strKey = String.Empty
                        v_strValue = String.Empty

                        'Sap xep theo thu tu trong SEARCHFLD
                        For i As Integer = 0 To mv_data.Rows.Count - 1
                            'Ngay 06/10/2017 NamTv them format datetime
                            v_FormatDate = mv_data.Rows(i)("FIELDTYPE").ToString
                            'End NamTv
                            For j As Integer = 0 To dtcsv.Columns.Count - 1
                                If j = mv_data.Rows(i)("FIELDCMP").ToString Then
                                    If v_FormatDate = "D" Then
                                        v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(dtcsv.Rows(k)(j)), gc_FORMAT_DATE))
                                    Else
                                        v_strValue = v_strValue & "|" & dtcsv.Rows(k)(j).ToString.Trim
                                    End If
                                    If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                        'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                        'v_strKey = v_strKey & "|" & dtcsv.Rows(k)(j).ToString.Trim
                                        v_strKey = v_strKey & "|" & modCommond.CutMark(dtcsv.Rows(k)(j).ToString.Trim).Replace(" ", "").ToUpper()
                                        'End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        If Not mv_hFileData.ContainsKey(v_strKey) Then
                            If v_strKey.Replace("|", "").Length > 0 Then
                                mv_hFileData.Add(v_strKey, v_strValue)
                            End If
                        Else
                            'Truong hop trung key
                            If v_strKey.Replace("|", "").Length > 0 Then
                                v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                mv_hFileData.Add(v_strKey, v_strValue)

                                'Thong bao trung key
                                'If v_countmsg < 1 Then
                                '    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                'End If
                                'v_countmsg = v_countmsg + 1
                            End If
                        End If
                    Next
                Else
                    For k As Integer = 0 To dtcsv.Rows.Count - 1
                        v_strKey = String.Empty
                        v_strValue = String.Empty
                        'Sap xep theo thu tu trong SEARCHFLD
                        For i As Integer = 0 To mv_data.Rows.Count - 1
                            For Each Dt As DataColumn In dtcsv.Columns
                                Dim v_strXSLColumn As String = modCommond.CutMark(Dt.ColumnName.ToString.Replace(" ", "")).ToUpper
                                Dim v_strFieldCMP As String = mv_data.Rows(i)("FIELDCMP").ToString.ToUpper
                                If v_strXSLColumn = v_strFieldCMP Then
                                    Select Case Dt.DataType.Name
                                        Case GetType(System.DateTime).Name
                                            v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(dtcsv.Rows(k)(Dt.ColumnName)), gc_FORMAT_DATE))
                                        Case Else
                                            v_strValue = v_strValue & "|" & dtcsv.Rows(k)(Dt.ColumnName).ToString.Trim
                                    End Select

                                    If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                        'If dtExcel.Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                        v_strKey = v_strKey & "|" & modCommond.CutMark(dtcsv.Rows(k)(Dt.ColumnName).ToString.Trim.Replace(" ", "")).ToUpper
                                        'End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        If Not mv_hFileData.ContainsKey(v_strKey) Then
                            If v_strKey.Replace("|", "").Length > 0 Then
                                mv_hFileData.Add(v_strKey, v_strValue)
                            End If
                        Else
                            'Truong hop trung key
                            If v_strKey.Replace("|", "").Length > 0 Then
                                v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                mv_hFileData.Add(v_strKey, v_strValue)

                                'Thong bao trung key
                                'If v_countmsg < 1 Then
                                '    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                'End If
                                'v_countmsg = v_countmsg + 1
                            End If
                        End If
                    Next
                End If
            Else
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim range As Excel.Range
                Dim rCnt As Integer
                Dim cCnt As Integer
                Dim Obj As Object
                Dim v_xColumn As Xceed.Grid.Column
                Dim v_strOldCultureName As String = String.Empty
                Dim dtExcel As New DataTable
                Dim dr As DataRow
                Dim iss As Integer
                Dim icc As Integer
                Dim v_FormatDate = String.Empty

                v_strOldCultureName = SetCultureInfo("en-US")
                xlApp = New Excel.Application
                xlWorkBook = xlApp.Workbooks.Open(mv_strFileName)
                xlWorkSheet = xlWorkBook.Worksheets(1)
                range = xlWorkSheet.UsedRange

                For icc = 1 To range.Columns.Count
                    If mv_strISNUM = "N" Then
                        dtExcel.Columns.Add(CType(range.Cells(1, icc), Excel.Range).Value, GetType(System.String))
                    Else
                        dtExcel.Columns.Add(icc, GetType(System.String))
                    End If
                Next

                If mv_strISNUM = "N" Then
                    iss = 2
                Else
                    iss = 1
                End If

                For iss = iss To range.Rows.Count
                    dr = dtExcel.NewRow()
                    For icc = 1 To range.Columns.Count
                        If mv_strISNUM = "N" Then
                            dr(CType(range.Cells(1, icc), Excel.Range).Value) = CType(range.Cells(iss, icc), Excel.Range).Value
                        Else
                            dr(icc - 1) = CType(range.Cells(iss, icc), Excel.Range).Value
                        End If
                    Next
                    dtExcel.Rows.Add(dr)
                Next

                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                'End T07/2017 STP
                'Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 12.0 ;HDR=YES;"
                ''Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 8.0;HDR=YES;"
                'If mv_strFileName.EndsWith("xls") Or mv_strFileName.EndsWith("XLS") Then
                '    connString = "Provider=Microsoft.ACE.OLEDB.8.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 8.0 Xml;IMEX=1;HDR=YES;"
                'End If
                'Dim oledbConn As OleDbConnection = New OleDbConnection(connString)

                Dim v_strOrderBy As String = ""
                Try
                    ' Open connection
                    'oledbConn.Open()
                    Dim v_strConfig As String
                    v_strConfig = Me.Searchcode.Remove(2, 1) & "ORDERBY"
                    v_strOrderBy = ConfigurationManager.AppSettings(v_strConfig)

                    If Me.Searchcode = "ODCMPVSD" Then
                        v_strOrderBy = mv_ResourceManager.GetString("ODCMPVSDORDERBY")
                    Else
                        v_strOrderBy = " "
                    End If

                    'If Me.Searchcode = "CA1003" Then
                    '    v_strOrderBy = ConfigurationManager.AppSettings("CA003CMPORDERBY") '"CMPDATE|CMPTIME|HT_CUSTODYCD|HT_FULLNAME|HT_IDCODE|HT_IDDATE|HT_IDPLACE|HT_ADDRESS|HT_SYMBOL|HT_AMT|HT_BALANCE|FILE_CUSTODYCD|FILE_FULLNAME|FILE_IDCODE|FILE_IDDATE|FILE_IDPLACE|FILE_ADDRESS|FILE_SYMBOL|FILE_AMT|FILE_BALANCE| ~ "
                    'End If
                    'If Me.Searchcode = "SE0087" Then
                    '    v_strOrderBy = ConfigurationManager.AppSettings("SE0087CMPORDERBY") '"CMPDATE|CMPTIME|HT_CUSTODYCD|HT_FULLNAME|HT_IDCODE|HT_IDDATE|HT_IDPLACE|HT_ADDRESS|HT_SYMBOL|HT_QTTY_TYPE|HT_QTTY|HT_MORTAGE|FILE_CUSTODYCD|FILE_FULLNAME|FILE_IDCODE|FILE_IDDATE|FILE_IDPLACE|FILE_ADDRESS|FILE_SYMBOL|FILE_QTTY_TYPE|FILE_QTTY|FILE_MORTAGE| ~ "
                    'End If
                    'Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Sheet1$] " & v_strOrderBy, oledbConn)
                    'Dim oleda As OleDbDataAdapter = New OleDbDataAdapter()
                    'oleda.SelectCommand = cmd
                    'Dim ds As DataSet = New DataSet()
                    'oleda.Fill(ds, "FILEDATA")
                    'Tao Hashtable

                    Dim v_countmsg As Integer = 0
                    Dim v_ckey As Integer = 0
                    ''TH1: Lay theo ten cot
                    ''TH2: Lay theo thu tu tren file
                    If mv_strISNUM = "Y" Then
                        ''1
                        For k As Integer = 0 To dtExcel.Rows.Count - 1
                            v_strKey = String.Empty
                            v_strValue = String.Empty

                            'Sap xep theo thu tu trong SEARCHFLD
                            For i As Integer = 0 To mv_data.Rows.Count - 1
                                'Ngay 06/10/2017 NamTv them format datetime
                                v_FormatDate = mv_data.Rows(i)("FIELDTYPE").ToString
                                'End NamTv
                                For j As Integer = 0 To dtExcel.Columns.Count - 1
                                    If j = mv_data.Rows(i)("FIELDCMP").ToString Then
                                        If v_FormatDate = "D" Then
                                            v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(dtExcel.Rows(k)(j)), gc_FORMAT_DATE))
                                        Else
                                            v_strValue = v_strValue & "|" & dtExcel.Rows(k)(j).ToString.Trim
                                        End If
                                        If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                            'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                            'v_strKey = v_strKey & "|" & dtExcel.Rows(k)(j).ToString.Trim
                                            v_strKey = v_strKey & "|" & modCommond.CutMark(dtExcel.Rows(k)(j).ToString.Trim).Replace(" ", "").ToUpper()
                                            'End If
                                        End If
                                        Exit For
                                    End If
                                Next
                            Next
                            If Not mv_hFileData.ContainsKey(v_strKey) Then
                                If v_strKey.Replace("|", "").Length > 0 Then
                                    mv_hFileData.Add(v_strKey, v_strValue)
                                End If
                            Else
                                'Truong hop trung key
                                If v_strKey.Replace("|", "").Length > 0 Then
                                    v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                    mv_hFileData.Add(v_strKey, v_strValue)
                                End If
                            End If
                        Next
                    Else
                        '''2
                        For k As Integer = 0 To dtExcel.Rows.Count - 1
                            v_strKey = String.Empty
                            v_strValue = String.Empty
                            'Sap xep theo thu tu trong SEARCHFLD
                            For i As Integer = 0 To mv_data.Rows.Count - 1
                                For Each Dt As DataColumn In dtExcel.Columns
                                    Dim v_strXSLColumn As String = modCommond.CutMark(Dt.ColumnName.ToString.Replace(" ", "")).ToUpper
                                    Dim v_strFieldCMP As String = mv_data.Rows(i)("FIELDCMP").ToString.ToUpper
                                    If v_strXSLColumn = v_strFieldCMP Then
                                        Select Case Dt.DataType.Name
                                            Case GetType(System.DateTime).Name
                                                v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(dtExcel.Rows(k)(Dt.ColumnName)), gc_FORMAT_DATE))
                                            Case Else
                                                v_strValue = v_strValue & "|" & dtExcel.Rows(k)(Dt.ColumnName).ToString.Trim
                                        End Select

                                        If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                            'If dtExcel.Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                            v_strKey = v_strKey & "|" & modCommond.CutMark(dtExcel.Rows(k)(Dt.ColumnName).ToString.Trim.Replace(" ", "")).ToUpper
                                            'End If
                                        End If
                                        Exit For
                                    End If
                                Next
                            Next
                            If Not mv_hFileData.ContainsKey(v_strKey) Then
                                If v_strKey.Replace("|", "").Length > 0 Then
                                    mv_hFileData.Add(v_strKey, v_strValue)
                                End If
                            Else
                                'Truong hop trung key
                                If v_strKey.Replace("|", "").Length > 0 Then
                                    v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                    mv_hFileData.Add(v_strKey, v_strValue)

                                    'Thong bao trung key
                                    'If v_countmsg < 1 Then
                                    '    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                    'End If
                                    'v_countmsg = v_countmsg + 1
                                End If
                            End If
                        Next
                    End If

                    'Close
                    'ds.Dispose()
                    'oleda.Dispose()
                    'oledbConn.Close()
                Catch ex As Exception
                    'oledbConn.Close()
                    LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                           & "Error code: System error!" & vbNewLine _
                           & "Error message: " & ex.Message, EventLogEntryType.Error)
                    GetNewDataFromXML()
                    'MessageBox.Show(mv_ResourceManager.GetString("frmSearchCMP2FILE.CannotOpenFile") & vbCrLf _
                    '               & mv_ResourceManager.GetString("frmSearchCMP2FILE.ErrorFileFormat"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If 'T07/2017 STP
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub GetNewData_bk20180305()
        Try
            Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 12.0 Xml;"
            'If mv_strFileName.EndsWith("xls") Or mv_strFileName.EndsWith("XLS") Then
            '    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 8.0;IMEX=1;HDR=YES;"
            'End If
            'Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 8.0"
            Dim oledbConn As OleDbConnection = New OleDbConnection(connString)
            Dim v_strOrderBy As String = ""


            'Dim v_obj As DataAccess
            Try
                ' Open connection
                oledbConn.Open()
                Dim v_strConfig As String
                v_strConfig = Me.Searchcode.Remove(2, 1) & "ORDERBY"
                v_strOrderBy = ConfigurationManager.AppSettings(v_strConfig)

                If Me.Searchcode = "ODCMPVSD" Then
                    v_strOrderBy = mv_ResourceManager.GetString("ODCMPVSDORDERBY")
                Else
                    v_strOrderBy = " "
                End If





                'If Me.Searchcode = "CA1003" Then
                '    v_strOrderBy = ConfigurationManager.AppSettings("CA003CMPORDERBY") '"CMPDATE|CMPTIME|HT_CUSTODYCD|HT_FULLNAME|HT_IDCODE|HT_IDDATE|HT_IDPLACE|HT_ADDRESS|HT_SYMBOL|HT_AMT|HT_BALANCE|FILE_CUSTODYCD|FILE_FULLNAME|FILE_IDCODE|FILE_IDDATE|FILE_IDPLACE|FILE_ADDRESS|FILE_SYMBOL|FILE_AMT|FILE_BALANCE| ~ "
                'End If
                'If Me.Searchcode = "SE0087" Then
                '    v_strOrderBy = ConfigurationManager.AppSettings("SE0087CMPORDERBY") '"CMPDATE|CMPTIME|HT_CUSTODYCD|HT_FULLNAME|HT_IDCODE|HT_IDDATE|HT_IDPLACE|HT_ADDRESS|HT_SYMBOL|HT_QTTY_TYPE|HT_QTTY|HT_MORTAGE|FILE_CUSTODYCD|FILE_FULLNAME|FILE_IDCODE|FILE_IDDATE|FILE_IDPLACE|FILE_ADDRESS|FILE_SYMBOL|FILE_QTTY_TYPE|FILE_QTTY|FILE_MORTAGE| ~ "
                'End If
                Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Sheet1$] " & v_strOrderBy, oledbConn)
                Dim oleda As OleDbDataAdapter = New OleDbDataAdapter()
                oleda.SelectCommand = cmd
                Dim ds As DataSet = New DataSet()
                oleda.Fill(ds, "FILEDATA")
                'Tao Hashtable
                Dim v_strKey As String = String.Empty
                Dim v_strValue As String = String.Empty
                Dim v_countmsg As Integer = 0
                Dim v_ckey As Integer = 0





                ''TH1: Lay theo ten cot
                ''TH2: Lay theo thu tu tren file
                If mv_strISNUM = "Y" Then
                    ''1
                    For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        v_strKey = String.Empty
                        v_strValue = String.Empty
                        'Sap xep theo thu tu trong SEARCHFLD
                        For i As Integer = 0 To mv_data.Rows.Count - 1
                            For j As Integer = 0 To ds.Tables(0).Columns.Count - 1
                                If j = mv_data.Rows(i)("FIELDCMP").ToString Then
                                    Select Case ds.Tables(0).Columns(j).DataType.Name
                                        Case GetType(System.DateTime).Name
                                            v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(ds.Tables(0).Rows(k)(j)), gc_FORMAT_DATE))
                                        Case Else
                                            v_strValue = v_strValue & "|" & ds.Tables(0).Rows(k)(j).ToString.Trim
                                    End Select
                                    v_strValue = v_strValue & "|" & ds.Tables(0).Rows(k)(j).ToString.Trim
                                    If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                        'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                        v_strKey = v_strKey & "|" & modCommond.CutMark(ds.Tables(0).Rows(k)(j).ToString.Trim.Replace(" ", "")).ToUpper
                                        'End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        If Not mv_hFileData.ContainsKey(v_strKey) Then
                            If v_strKey.Replace("|", "").Length > 0 Then
                                mv_hFileData.Add(v_strKey, v_strValue)
                            End If
                        Else
                            'Truong hop trung key
                            If v_strKey.Replace("|", "").Length > 0 Then
                                v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                mv_hFileData.Add(v_strKey, v_strValue)

                                'Thong bao trung key
                                'If v_countmsg < 1 Then
                                '    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                'End If
                                'v_countmsg = v_countmsg + 1
                            End If
                        End If
                    Next
                Else
                    '''2
                    For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        v_strKey = String.Empty
                        v_strValue = String.Empty
                        'Sap xep theo thu tu trong SEARCHFLD
                        For i As Integer = 0 To mv_data.Rows.Count - 1
                            For Each Dt As DataColumn In ds.Tables(0).Columns
                                Dim v_strXSLColumn As String = modCommond.CutMark(Dt.ColumnName.ToString.Replace(" ", "")).ToUpper
                                Dim v_strFieldCMP As String = mv_data.Rows(i)("FIELDCMP").ToString.ToUpper
                                If v_strXSLColumn = v_strFieldCMP Then
                                    Select Case Dt.DataType.Name
                                        Case GetType(System.DateTime).Name
                                            v_strValue = v_strValue & "|" & gf_CorrectStringField(Format(gf_CorrectDateField(ds.Tables(0).Rows(k)(Dt.ColumnName)), gc_FORMAT_DATE))
                                        Case Else
                                            v_strValue = v_strValue & "|" & ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
                                    End Select

                                    If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                        'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                        v_strKey = v_strKey & "|" & modCommond.CutMark(ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim.Replace(" ", "")).ToUpper
                                        'End If
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        If Not mv_hFileData.ContainsKey(v_strKey) Then
                            If v_strKey.Replace("|", "").Length > 0 Then
                                mv_hFileData.Add(v_strKey, v_strValue)
                            End If
                        Else
                            'Truong hop trung key
                            If v_strKey.Replace("|", "").Length > 0 Then
                                v_strKey = HandleDuplicateKey(mv_hFileData, v_strKey)
                                mv_hFileData.Add(v_strKey, v_strValue)

                                'Thong bao trung key
                                'If v_countmsg < 1 Then
                                '    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                'End If
                                'v_countmsg = v_countmsg + 1
                            End If
                        End If
                    Next
                End If


                'Close
                ds.Dispose()
                oleda.Dispose()
                oledbConn.Close()
            Catch ex As Exception
                oledbConn.Close()
                LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
                GetNewDataFromXML()
                'MessageBox.Show(mv_ResourceManager.GetString("frmSearchCMP2FILE.CannotOpenFile") & vbCrLf _
                '               & mv_ResourceManager.GetString("frmSearchCMP2FILE.ErrorFileFormat"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'End T07/2017 STP
    Private Function HandleDuplicateKey(ByVal pv_ht As Hashtable, ByVal pv_strKey As String) As String
        Dim v_strKey As String
        For i As Integer = 1 To pv_ht.Count
            v_strKey = pv_strKey & "[" & i & "]"
            If Not pv_ht.ContainsKey(v_strKey) Then
                Return v_strKey
            End If
        Next
        Return pv_strKey
    End Function

    'Private Sub GetNewData()
    '    Try
    '        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 12.0"
    '        'Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & mv_strFileName & ";Extended Properties=Excel 8.0"
    '        Dim oledbConn As OleDbConnection = New OleDbConnection(connString)
    '        Try
    '            ' Open connection
    '            oledbConn.Open()
    '            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn)
    '            Dim oleda As OleDbDataAdapter = New OleDbDataAdapter()
    '            oleda.SelectCommand = cmd
    '            Dim ds As DataSet = New DataSet()
    '            oleda.Fill(ds, "FILEDATA")
    '            'Tao Hashtable
    '            Dim v_strKey As String = String.Empty
    '            Dim v_strValue As String = String.Empty
    '            Dim v_countmsg As Integer = 0
    '            Dim v_ckey As Integer = 0
    '            ''TH1: Lay theo ten cot
    '            ''TH2: Lay theo thu tu tren file
    '            If mv_strISNUM = "Y" Then
    '                ''1
    '                For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '                    v_strKey = String.Empty
    '                    v_strValue = String.Empty
    '                    'Sap xep theo thu tu trong SEARCHFLD
    '                    For i As Integer = 0 To mv_data.Rows.Count - 1
    '                        For j As Integer = 1 To ds.Tables(0).Columns.Count
    '                            If j = mv_data.Rows(i)("FIELDCMP").ToString Then
    '                                v_strValue = v_strValue & "|" & ds.Tables(0).Rows(k)(j).ToString.Trim
    '                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
    '                                    'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
    '                                    v_strKey = v_strKey & "|" & ds.Tables(0).Rows(k)(j).ToString.Trim
    '                                    'End If
    '                                End If
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next
    '                    If Not mv_hFileData.ContainsKey(v_strKey) Then
    '                        If v_strKey.Replace("|", "").Length > 0 Then
    '                            mv_hFileData.Add(v_strKey, v_strValue)
    '                        End If
    '                    Else
    '                        'Truong hop trung key
    '                        If v_strKey.Replace("|", "").Length > 0 Then
    '                            v_ckey = v_ckey + 1
    '                            mv_hFileData.Add(v_strKey & "[" & v_ckey & "]", v_strValue)

    '                            'Thong bao trung key
    '                            If v_countmsg < 1 Then
    '                                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '                            End If
    '                            v_countmsg = v_countmsg + 1
    '                        End If
    '                    End If
    '                Next
    '            Else
    '                '''2
    '                For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '                    v_strKey = String.Empty
    '                    v_strValue = String.Empty
    '                    'Sap xep theo thu tu trong SEARCHFLD
    '                    For i As Integer = 0 To mv_data.Rows.Count - 1
    '                        For Each Dt As DataColumn In ds.Tables(0).Columns
    '                            If Dt.ColumnName = mv_data.Rows(i)("FIELDCMP").ToString Then
    '                                v_strValue = v_strValue & "|" & ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
    '                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
    '                                    'If ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
    '                                    v_strKey = v_strKey & "|" & ds.Tables(0).Rows(k)(Dt.ColumnName).ToString.Trim
    '                                    'End If
    '                                End If
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next
    '                    If Not mv_hFileData.ContainsKey(v_strKey) Then
    '                        If v_strKey.Replace("|", "").Length > 0 Then
    '                            mv_hFileData.Add(v_strKey, v_strValue)
    '                        End If
    '                    Else
    '                        'Truong hop trung key
    '                        If v_strKey.Replace("|", "").Length > 0 Then
    '                            v_ckey = v_ckey + 1
    '                            mv_hFileData.Add(v_strKey & "[" & v_ckey & "]", v_strValue)

    '                            'Thong bao trung key
    '                            If v_countmsg < 1 Then
    '                                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '                            End If
    '                            v_countmsg = v_countmsg + 1
    '                        End If
    '                    End If
    '                Next
    '            End If


    '            'Close
    '            ds.Dispose()
    '            oleda.Dispose()
    '            oledbConn.Close()
    '        Catch ex As Exception
    '            oledbConn.Close()
    '            Throw ex
    '        End Try
    '    Catch ex As Exception
    '        LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
    '                   & "Error code: System error!" & vbNewLine _
    '                   & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub



    Private Sub GetNewData_bk()
        Try
            Try

                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim range As Excel.Range
                Dim rCnt As Integer
                Dim cCnt As Integer
                'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                Dim oldCI As Globalization.CultureInfo
                oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                xlApp = New Excel.ApplicationClass
                xlWorkBook = xlApp.Workbooks.Open(mv_strFileName)
                xlWorkSheet = xlWorkBook.Worksheets(1)
                Dim DataTB As New DataTable
                range = xlWorkSheet.UsedRange
                If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                    For cCnt = 1 To range.Columns.Count
                        If InStr(mv_strFIELDCMP, gf_CorrectStringField(CType(range.Cells(1, cCnt), Excel.Range).Value).Trim) > 0 Then
                            DataTB.Columns.Add(gf_CorrectStringField(CType(range.Cells(1, cCnt), Excel.Range).Value).Trim, GetType(System.String))
                        End If
                    Next
                End If

                If range.Rows.Count >= 2 Then
                    For rCnt = 2 To range.Rows.Count
                        Dim v_xDataRow As DataRow
                        v_xDataRow = DataTB.NewRow()
                        Dim j As Integer = 0
                        For i As Integer = 1 To range.Columns.Count
                            If InStr(mv_strFIELDCMP, gf_CorrectStringField(CType(range.Cells(1, i), Excel.Range).Value).Trim) > 0 Then
                                v_xDataRow(j) = gf_CorrectStringField(CType(range.Cells(rCnt, i), Excel.Range).Value)
                                j = j + 1
                            End If
                        Next
                        DataTB.Rows.Add(v_xDataRow)
                        DataTB.AcceptChanges()
                    Next

                End If
                xlWorkBook.Close()
                xlApp.Quit()

                'Tao Hashtable
                Dim v_strKey As String = String.Empty
                Dim v_strValue As String = String.Empty
                Dim v_countmsg As Integer = 0
                Dim v_ckey As Integer = 0

                For k As Integer = 0 To DataTB.Rows.Count - 1
                    v_strKey = String.Empty
                    v_strValue = String.Empty
                    'Sap xep theo thu tu trong SEARCHFLD
                    For i As Integer = 0 To mv_data.Rows.Count - 1
                        For Each Dt As DataColumn In DataTB.Columns
                            If Dt.ColumnName = mv_data.Rows(i)("FIELDCMP").ToString Then
                                v_strValue = v_strValue & "|" & DataTB.Rows(k)(Dt.ColumnName).ToString
                                If mv_data.Rows(i)("FIELDCMPKEY") = "Y" Then
                                    'If DataTB.Rows(k)(Dt.ColumnName).ToString.Length > 0 Then
                                    v_strKey = v_strKey & "|" & DataTB.Rows(k)(Dt.ColumnName).ToString
                                    'End If
                                End If
                                Exit For
                            End If
                        Next
                    Next
                    If Not mv_hFileData.ContainsKey(v_strKey) Then
                        If v_strKey.Replace("|", "").Length > 0 Then
                            mv_hFileData.Add(v_strKey, v_strValue)
                        End If
                    Else
                        'Truong hop trung key
                        If v_strKey.Replace("|", "").Length > 0 Then
                            v_ckey = v_ckey + 1
                            mv_hFileData.Add(v_strKey & "[" & v_ckey & "]", v_strValue)

                            'Thong bao trung key
                            If v_countmsg < 1 Then
                                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.NewdataInvalidKey"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
                            v_countmsg = v_countmsg + 1
                        End If
                    End If
                Next
            Catch ex As Exception

                Throw ex
            End Try
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                       & "Error code: System error!" & vbNewLine _
                       & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ResetData()
        mv_strFIELDCMP = String.Empty
        mv_strKeyCMP = String.Empty
        mv_hFileData.Clear()
        mv_hOldData.Clear()
        Me.SearchGrid.DataRows.Clear()
    End Sub

    Private Sub OnCompare()
        Try
            If v_frmRptParameter.ObjectName <> "" Then
                v_frmRptParameter.PrepareReportParams2(String.Empty)
                mv_intNumOfParam = v_frmRptParameter.getIntNumOfParam
                mv_arrRptParam = v_frmRptParameter.getArrRptParam
            End If
        Catch ex As Exception

        End Try

        Try
            If (Not IsDBNull(Me.FULLDATA) Or Not IsDBNull(mv_OldData)) And (Me.txtFromFile.Text.Length > 0 Or (cboFileName.Visible = True And cboFileName.Text <> "")) Then
                If File.Exists(Me.txtFromFile.Text) Or cboFileName.Visible = True Then
                    ResetData()
                    GetKeyCMP()
                    GetOldData()
                    GetNewData()
                    'Compare data
                    Dim DicOld, DicFile As DictionaryEntry
                    Dim l As Integer = 0
                    Dim log As Integer = 0
                    Dim Data, Data_log As New DataTable
                    Dim v_strType As String = String.Empty
                    Dim v_checkInNewData, v_checkCompare As String

                    ' 1:  in data, not in file
                    ' 2:  not in data, in file
                    ' 3:  in data, in file, # value
                    Data.Columns.Add("STT", GetType(Integer))
                    Data.Columns.Add("TYPE", GetType(System.String))
                    Data.Columns.Add("KEY", GetType(System.String))
                    Data.Columns.Add("OLDVALUE", GetType(System.String))
                    Data.Columns.Add("NEWVALUE", GetType(System.String))

                    Data_log.Columns.Add("STT", GetType(Integer))
                    Data_log.Columns.Add("TYPE", GetType(System.String))
                    Data_log.Columns.Add("KEY", GetType(System.String))
                    Data_log.Columns.Add("OLDVALUE", GetType(System.String))
                    Data_log.Columns.Add("NEWVALUE", GetType(System.String))
                    '05/10/2015 DieuNDA: Sua lai thuat toan compare
                    For Each DicOld In mv_hOldData
                        Dim k As Integer = 0
                        ''Compare Key



                        If (mv_hFileData).ContainsKey(DicOld.Key) Then
                            'Compare values
                            If mv_hFileData(DicOld.Key) = DicOld.Value Then
                                k = k + 1
                            Else
                                v_strType = "3"
                            End If
                        Else
                            v_strType = "1"
                        End If
                        Dim v_strTemp As String = String.Empty
                        If v_strType = "1" Then
                            v_strTemp = String.Empty
                        ElseIf v_strType = "3" Then
                            v_strTemp = mv_hFileData(DicOld.Key).ToString
                        Else
                            v_strTemp = String.Empty
                        End If
                        If k = 0 Then
                            Data.Rows.Add(l, v_strType, DicOld.Key, DicOld.Value, v_strTemp)
                            l = l + 1
                        End If
                        'trung.luu: add ca truong hop khop 
                        Data_log.Rows.Add(log, v_strType, DicOld.Key, DicOld.Value, v_strTemp)
                        log = log + 1
                    Next

                    'For Each DicOld In mv_hOldData
                    'v_checkCompare = "N"
                    'v_checkInNewData = "N"
                    'For Each DicFile In mv_hFileData

                    'If DicOld.Key.ToString.Split("[")(0) = DicFile.Key.ToString.Split("[")(0) Then
                    'v_checkInNewData = "Y"

                    'If DicOld.Value = DicFile.Value Then
                    'v_checkCompare = "Y"
                    'End If

                    'End If

                    'Next

                    'If v_checkInNewData = "N" Then
                    'Data.Rows.Add(l, "1", DicOld.Key, DicOld.Value, String.Empty)
                    'l = l + 1
                    'ElseIf v_checkCompare = "N" Then
                    'For Each DicFile In mv_hFileData
                    'If DicOld.Key.ToString.Split("[")(0) = DicFile.Key.ToString.Split("[")(0) Then
                    'Data.Rows.Add(l, "3", DicOld.Key, DicOld.Value, DicFile.ToString)
                    'l = l + 1
                    'End If
                    'Next
                    'End If

                    'Next
                    'End 05/10/2015 DieuNDA
                    For Each DicFile In mv_hFileData
                        If Not mv_hOldData.ContainsKey(DicFile.Key) Then
                            v_strType = "2"
                            Data.Rows.Add(l, v_strType, DicFile.Key, String.Empty, DicFile.Value)
                            l = l + 1
                        End If
                        Data_log.Rows.Add(log, v_strType, DicFile.Key, String.Empty, DicFile.Value)
                        log = log + 1
                    Next
                    Data_log.DefaultView.Sort = "STT ASC"
                    Data_log = Data_log.DefaultView.ToTable()
                    mv_strDataWriteToDB = ConvertDataFromDataTable(Data_log)
                    If Data.Rows.Count > 0 Then
                        FillDataCompare(Data)
                        mv_GridData = New DataTable
                        mv_GridData = Data
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.FILE_SAME_DATA"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    mv_data.Clear()
                Else
                    MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.FILENAME_MUST_VALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If
            Else
                MsgBox(mv_ResourceManager.GetString("frmSearchCMP2FILE.FILENAME_MUST_VALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If

        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ConvertDataFromDataTable(ByVal pv_data As DataTable) As String
        Try
            Dim v_strDataTmp As String
            Dim v_strAppConfig As String
            Dim v_txdate As String = dtpTXDATE.Value.ToString("dd/MM/yyyy")

            v_strAppConfig = Me.Searchcode.Remove(2, 1)
            'v_strDataTmp = "TLID|TXDATE|" & ConfigurationManager.AppSettings(v_strAppConfig)
            For Each v_dr As DataRow In pv_data.Rows
                Dim v_strData As String = String.Empty
                Dim v_arrDataFld() As String
                Dim v_strTemp As String = String.Empty
                For j As Integer = 0 To mv_data.Rows.Count - 1
                    v_strTemp = v_strTemp & "|" & " "
                Next
                If v_dr("NEWVALUE").ToString.Length < 2 Then
                    If v_dr("OLDVALUE").ToString.Length < 2 Then
                        v_strData = Me.TellerId & "|" & Me.BusDate & "|" & v_txdate & "|" & Now.ToString("HH:mm:ss") & "|0|" & v_strTemp & "|" & " " & v_strTemp & "|"
                    Else
                        v_strData = Me.TellerId & "|" & Me.BusDate & "|" & v_txdate & "|" & Now.ToString("HH:mm:ss") & "|" & v_dr("TYPE").ToString & v_dr("OLDVALUE").ToString & "|" & " " & v_strTemp & "|"
                    End If
                Else
                    If v_dr("OLDVALUE").ToString.Length < 2 Then
                        v_strData = Me.TellerId & "|" & Me.BusDate & "|" & v_txdate & "|" & Now.ToString("HH:mm:ss") & "|" & v_dr("TYPE").ToString & v_strTemp & v_dr("NEWVALUE").ToString & "|"
                    Else
                        v_strData = Me.TellerId & "|" & Me.BusDate & "|" & v_txdate & "|" & Now.ToString("HH:mm:ss") & "|" & v_dr("TYPE").ToString & v_dr("OLDVALUE").ToString & v_dr("NEWVALUE").ToString & "|"
                    End If
                End If
                v_strDataTmp = v_strDataTmp & v_strData & "#" & " "
            Next
            'Return String convert from data table
            Return v_strDataTmp
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnWrite" & vbNewLine _
                    & "Error code: System error!" & vbNewLine _
                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub FillDataCompare(ByVal pv_data As DataTable)
        Try
            Dim v_drTmp As System.Data.DataRow
            For Each v_dr As DataRow In pv_data.Rows
                Dim v_strData As String = String.Empty
                Dim v_arrDataFld() As String
                ''Add data to datatable
                v_drTmp = mv_GridDataDetail.NewRow
                mv_GridDataDetail.Rows.Add(v_drTmp)
                Dim v_strTemp As String = String.Empty
                For j As Integer = 0 To mv_data.Rows.Count - 1
                    v_strTemp = v_strTemp & "|" & " "
                Next
                If v_dr("NEWVALUE").ToString.Length < 2 Then
                    If v_dr("OLDVALUE").ToString.Length < 2 Then
                        v_strData = v_dr("TYPE").ToString & v_strTemp & "|" & " " & v_strTemp
                    Else
                        v_strData = v_dr("TYPE").ToString & v_dr("OLDVALUE").ToString & "|" & " " & v_strTemp
                    End If
                Else
                    If v_dr("OLDVALUE").ToString.Length < 2 Then
                        v_strData = v_dr("TYPE").ToString & v_strTemp & "|" & " " & v_dr("NEWVALUE").ToString
                    Else
                        v_strData = v_dr("TYPE").ToString & v_dr("OLDVALUE").ToString & "|" & " " & v_dr("NEWVALUE").ToString
                    End If
                End If

                v_arrDataFld = v_strData.Split("|")
                Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()

                Dim i As Integer = 0
                For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                    If i < v_arrDataFld.Length Then
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = v_arrDataFld(i).ToString
                        '' Set data to datatable
                        v_drTmp(v_xColumn.FieldName) = v_arrDataFld(i).ToString

                    Else
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = String.Empty
                        v_drTmp(v_xColumn.FieldName) = String.Empty

                    End If
                    If v_xColumn.FieldName = "G_TYPE" Then
                        Select Case v_arrDataFld(0).ToString
                            Case "1"
                                v_xDataRow.Cells(0).BackColor = Drawing.Color.Red
                            Case "2"
                                v_xDataRow.Cells(0).BackColor = Drawing.Color.Yellow
                            Case "3"
                                v_xDataRow.Cells(0).BackColor = Drawing.Color.Green
                            Case "4"
                                v_xDataRow.Cells(0).BackColor = Drawing.Color.Cyan
                        End Select
                    End If
                    If v_xColumn.FieldName = "G_XX" Then
                        v_xDataRow.Cells("G_XX").BackColor = Drawing.Color.DarkCyan
                    End If
                    i = i + 1
                Next
                v_xDataRow.EndEdit()
            Next
            'Add grid title

            SearchGrid.EndInit()
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                    & "Error code: System error!" & vbNewLine _
                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillDataCompare_bk(ByVal pv_data As DataTable)
        Try
            For Each v_dr As DataRow In pv_data.Rows
                Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                    If Not (v_dr(v_xColumn.FieldName) Is DBNull.Value) Then
                        Select Case v_xColumn.FieldName
                            Case "TYPE"
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = v_dr("TYPE").ToString
                                Select Case v_dr("TYPE").ToString
                                    Case "1"
                                        v_xDataRow.Cells(v_xColumn.FieldName).BackColor = Drawing.Color.Red
                                    Case "2"
                                        v_xDataRow.Cells(v_xColumn.FieldName).BackColor = Drawing.Color.Yellow
                                    Case "3"
                                        v_xDataRow.Cells(v_xColumn.FieldName).BackColor = Drawing.Color.Green
                                    Case "4"
                                        v_xDataRow.Cells(v_xColumn.FieldName).BackColor = Drawing.Color.Cyan
                                End Select
                            Case "KEY"
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = v_dr("KEY").ToString
                            Case "OLDVALUE"
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = v_dr("OLDVALUE").ToString
                            Case "NEWVALUE"
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = v_dr("NEWVALUE").ToString
                            Case Else
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_dr(v_xColumn.FieldName))
                        End Select
                    End If
                Next

                v_xDataRow.EndEdit()
            Next
            'Add grid title
            SearchGrid.Columns("KEY").Title = ResourceManager.GetString("grid.KEY") & "[" & mv_strKeyCMP & "]"
            SearchGrid.Columns("OLDVALUE").Title = ResourceManager.GetString("grid.OLDVALUE") & "[" & mv_strFIELDCMP & "]"
            SearchGrid.Columns("NEWVALUE").Title = ResourceManager.GetString("grid.NEWVALUE") & "[" & mv_strFIELDCMP & "]"

            SearchGrid.EndInit()
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnCompare" & vbNewLine _
                    & "Error code: System error!" & vbNewLine _
                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OnBrowser()
        Try
            If cboFileName.Visible = False Then
                Dim v_dlgOpen As New OpenFileDialog
                v_dlgOpen.Filter = "Excel files(2003) (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|CSV file (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*"
                v_dlgOpen.RestoreDirectory = True

                Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
                If v_res = DialogResult.OK Then
                    mv_strFileName = v_dlgOpen.FileName
                    Me.txtFromFile.Text = mv_strFileName
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReceiverData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub PrepareReportParams(ByVal F_DATE As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters
            ReDim mv_arrRptParam(2) 'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = 3
            mv_strStoredname = "CA1001"

            'OPT
            v_obj = New ReportParameters
            v_obj.ParamName = "OPT"
            v_obj.ParamCaption = "Pham vi"
            v_obj.ParamValue = "A"
            v_obj.ParamSize = 1
            v_obj.ParamType = "M"
            mv_arrRptParam(0) = v_obj
            'BRID
            v_obj = New ReportParameters
            v_obj.ParamName = "BRID"
            v_obj.ParamCaption = "Chi nhanh"
            v_obj.ParamValue = "ALL"
            v_obj.ParamType = "M"
            v_obj.ParamSize = 4

            mv_arrRptParam(1) = v_obj
            'F_DATE
            v_obj = New ReportParameters
            v_obj.ParamName = "F_DATE"
            v_obj.ParamCaption = "Tai Ngay"
            v_obj.ParamValue = F_DATE
            v_obj.ParamType = "M"
            v_obj.ParamSize = 10
            mv_arrRptParam(2) = v_obj

            mv_arrRptParam(2) = v_obj

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
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

            'ReportAsychronous = String.Empty
            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/RptDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/RptDataXML")
            If Not (v_nodeXSD Is Nothing And v_nodeXML Is Nothing) Then
                'The return data is compressed
                v_strDataXSD = v_nodeXSD.InnerText
                v_strDataXML = v_nodeXML.InnerText
                If v_strDataXSD <> "PENDING" Then   'Synchronous report
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
                    v_ds.Tables(0).TableName = "RptData"
                    Return v_ds
                Else    'Asynchronous report
                    ''Delete old data
                    'Dim v_strFile As String = ReportTempDirectory & GetRptTempFilePath(CMDID)
                    'File.Delete(v_strFile)

                    ''Ghi ra file voi trang thai PENDING
                    ''Dim v_streamWriter As New StreamWriter(ReportTempDirectory & GetRptPendingFilePath(CMDID))
                    'Dim v_streamWriter As New StreamWriter(ReportTempDirectory & v_strDataXML)
                    'v_streamWriter.Write(v_strDataXSD)
                    'v_streamWriter.Flush()
                    'v_streamWriter.Close()

                    'Ghi nhan lai ten file dang pending cho xu ly tren host
                    'ReportAsychronous = v_strDataXML
                    Return Nothing
                End If
            Else
                'Normal way: the return data is not compressed
                v_ds.Tables.Add("RptData")
                v_intCountRow = pv_xmlDoc.FirstChild.ChildNodes.Count
                If (v_intCountRow > 0) Then
                    v_intCountCol = pv_xmlDoc.FirstChild.FirstChild.ChildNodes.Count

                    For i As Integer = 0 To v_intCountCol - 1
                        v_dc = New DataColumn(pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldname").InnerText)
                        v_dc.ColumnName = pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldname").InnerText

                        Select Case pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldtype").InnerText
                            Case "System.Decimal"
                                v_dc.DataType = GetType(System.Decimal)
                            Case "System.String"
                                v_dc.DataType = GetType(System.String)
                            Case "System.Double"
                                v_dc.DataType = GetType(System.Double)
                            Case "System.DateTime"
                                v_dc.DataType = GetType(System.DateTime)
                            Case Else
                                v_dc.DataType = GetType(System.String)
                        End Select

                        v_ds.Tables(0).Columns.Add(v_dc)
                    Next

                    v_XmlNode = pv_xmlDoc.FirstChild
                    For j As Integer = 0 To v_intCountRow - 1
                        v_dr = v_ds.Tables(0).NewRow()
                        For i As Integer = 0 To v_intCountCol - 1
                            v_dr(i) = Trim(v_XmlNode.ChildNodes(j).ChildNodes(i).InnerText)
                        Next
                        v_ds.Tables(0).Rows.Add(v_dr)
                    Next
                End If
                Return v_ds
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Private Sub getUpdateFileName(ByVal report_name As String, ByVal report_date As String)
        Dim v_strSQL, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As BDSDeliveryManagement
        Try

            Try
                v_strSQL = String.Format("SELECT autoid VALUE, filename DISPLAY, filename EN_DISPLAY, to_char(txdate,'DD/MM/RRRR') DESCRIPTION " & ControlChars.NewLine _
                                        & " FROM vsd_csvcontent_log " & ControlChars.NewLine _
                                        & " WHERE TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 23, 8),'DDMMRRRR') = TO_DATE('{1}','{2}') " & ControlChars.NewLine _
                                        & " and filename like '%{0}%'  " & ControlChars.NewLine _
                                        & " ORDER BY TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 14, 6),'HH24MISS') DESC ",
                                        report_name, report_date, gc_FORMAT_DATE_DB)

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
                                    & "ORDER BY vsd.autoid DESC ", report_name, report_date, gc_FORMAT_DATE_DB)

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
                                    & " WHERE TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 23, 8),'DDMMRRRR') = TO_DATE('{1}','{2}') " & ControlChars.NewLine _
                                    & " AND filename like '%{0}%' " & ControlChars.NewLine _
                                    & " ORDER BY TO_DATE(SUBSTR(FILENAME,INSTR(UPPER(FILENAME),'.CSV') - 14, 6),'HH24MISS') DESC ",
                                    report_name, report_date, gc_FORMAT_DATE_DB)
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                Catch ex As Exception
                    'If MessageBox.Show(mv_ResourceManager.GetString("errNoCorrectFile"), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    v_strSQL = String.Format("SELECT vsd.autoid VALUE, vsd.filename DISPLAY, vsd.filename EN_DISPLAY, to_char(txdate,'dd/mm/rrrr') DESCRIPTION " & ControlChars.NewLine _
                                    & " FROM (select * from VSD_CSVCONTENT_LOGHIST)  vsd " & ControlChars.NewLine _
                                    & "WHERE  filename like '%{0}%' and vsd.txdate = TO_DATE('{1}','{2}') AND funcName IS NULL" & ControlChars.NewLine _
                                    & "ORDER BY vsd.autoid DESC ", report_name, report_date, gc_FORMAT_DATE_DB)
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
        End Try
    End Sub

    Private Sub btnFileCSV_Click(sender As Object, e As EventArgs) Handles btnFileCSV.Click
        Dim v_strSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_TOTAL As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As BDSDeliveryManagement

        If cboFileName.Visible = False Then
            btnFileCSV.Text = "Choose PC file"
            cboFileName.Visible = True

            If Me.Searchcode = "SE0087" Then
                getUpdateFileName("DE083", dtpTXDATE.Value.ToString("dd/MM/yyyy"))
            Else
                lblFileType.Visible = True
                cboFileType.Visible = True

                v_strSQL = String.Format("SELECT VSDREPORTID VALUE, VSDREPORTID DISPLAY, VSDREPORTID EN_DISPLAY, VSDREPORTID DESCRIPTION FROM VSD_MAP_COMPARE WHERE VIEWID = '{0}'", Me.Searchcode)
                v_ws = New BDSDeliveryManagement
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                cboFileType.Clears()
                If v_nodeList.Count > 0 Then
                    FillComboEx(v_strObjMsg, cboFileType, "", Me.UserLanguage)
                End If
            End If
        Else
            lblFileType.Visible = False
            cboFileType.Visible = False

            btnFileCSV.Text = "Choose VSD file"
            cboFileName.Visible = False
        End If
    End Sub

    Function getCSVDetail(ByVal cboReportName As String) As System.Data.DataTable
        Dim v_strSQL, v_strObjMsg, v_strMSGBODY, v_strFuncName As String
        Dim v_ws = New BDSDeliveryManagement
        Dim v_fromRow, v_toRow, v_rowCount As Integer
        Dim v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_maxrow As Integer = 6000
        Dim mv_strObjname As String = "ST.CSVCMP"

        v_strSQL = String.Format("SELECT * FROM CSVCOMPAREREPORTFLD WHERE instr('{0}',cmpid)>0 order by id ", cboReportName)
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument1 As New Xml.XmlDocument
        Dim v_nodeList1 As Xml.XmlNodeList
        v_xmlDocument1.LoadXml(v_strObjMsg)
        v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

        Dim dt As New DataTable
        Dim pv_xGrid As New Xceed.Grid.GridControl
        Dim v_fldname, v_fldname_ogr, v_fldname_en, v_fldname2 As String
        Dim v_strValue, v_strFLDNAME, v_defval, v_strColoumName As String

        For i As Integer = 0 To v_nodeList1.Count - 1
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
                        Case "FLDNAME2"
                            v_fldname2 = v_strValue.Trim
                    End Select
                End With
            Next

            pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_fldname_ogr, GetType(System.String)))
            pv_xGrid.Columns(v_fldname_ogr).Tag = v_defval

            If Me.UserLanguage = "EN" Then
                pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname_en
            Else
                pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname
            End If


            If mv_CountContainer > 2 Then
                dt.Columns.Add(New DataColumn(v_fldname2))
            Else
                dt.Columns.Add(New DataColumn)
            End If

        Next

        Dim v_xColumn As Xceed.Grid.Column

        While v_hasmore
            If v_pageNum = 1 Then
                v_fromRow = 1
            Else
                v_fromRow = v_toRow + 1
            End If
            v_toRow = v_fromRow + v_maxrow
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , cboFileName.SelectedValue, "getFileDetail", , , v_fromRow & "^" & v_toRow, IpAddress, , , , )
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            v_rowCount = v_nodeList.Count
            For i As Integer = 0 To v_nodeList.Count - 1
                Dim IArray As New ArrayList
                For Each v_xColumn In pv_xGrid.Columns
                    v_strColoumName = UCase(Trim(v_xColumn.FieldName))

                    If (InStr(v_xColumn.Tag, "@", CompareMethod.Text) > 0) Then
                        IArray.Add(Replace(v_xColumn.Tag, "@", ""))
                    ElseIf (InStr(v_xColumn.Tag, "<$BUSDATE>", CompareMethod.Text) > 0) Then
                        IArray.Add(Me.BusDate)
                    End If

                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
                            If Not (v_strValue Is DBNull.Value) Then
                                If Trim(v_strValue) = "" Then
                                    v_strValue = Nothing
                                End If
                            End If

                            If v_strFLDNAME = v_strColoumName Then
                                If v_strColoumName <> "SIGNATURE" Then
                                    If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
                                        IArray.Add(IIf(v_strValue = "0", False, True))
                                    Else
                                        Select Case v_xColumn.DataType.Name
                                            Case GetType(System.String).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue)))
                                            Case GetType(System.Decimal).Name
                                                If v_strValue = "" Then
                                                    v_strValue = 0
                                                End If
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue)))
                                            Case GetType(Integer).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue)))
                                            Case GetType(Long).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue)))
                                            Case GetType(Double).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue)))
                                            Case GetType(System.DateTime).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString))
                                            Case GetType(System.Boolean).Name
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue)))
                                            Case Else
                                                IArray.Add(IIf(v_strValue Is DBNull.Value, "", v_strValue))
                                        End Select
                                    End If
                                End If

                            End If
                        End With
                    Next
                Next

                Dim row As DataRow = dt.NewRow()
                row.ItemArray = IArray.ToArray()
                dt.Rows.Add(row)
            Next

            If v_rowCount <= v_maxrow Then
                v_hasmore = False
            End If
            v_pageNum += 1
        End While

        Return dt

    End Function

    Private Sub dtpTXDATE_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpTXDATE.ValueChanged
        If cboFileName.Visible = True Then
            If Me.Searchcode = "SE0087" Then
                getUpdateFileName("DE083", dtpTXDATE.Value.ToString("dd/MM/yyyy"))
            Else
                getUpdateFileName(cboFileType.SelectedValue, dtpTXDATE.Value.ToString("dd/MM/yyyy"))
            End If
        End If
    End Sub

    Private Async Function OnSave() As Threading.Tasks.Task(Of String)
        Dim v_strErrorSource, v_strErrorMessage, v_lngError, v_strClauseParam As String
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim v_strBuffer, v_strBufferTemp As New System.Text.StringBuilder
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strStoreName, v_filename As String

        Try
            v_strStoreName = "SP_RSE0087"
            v_filename = Me.txtFromFile.Text
            If cboFileName.Visible = True Then
                v_filename = cboFileName.Text
            End If
            Const strBank_holdbalance_param As String = "str_data!{0}!CLOB!99999" & _
                                                    "^filename!{1}!varchar2!4000" & _
                                                 "^P_ERR_CODE!{2}!VARCHAR2!30"


            v_strClauseParam = String.Format(strBank_holdbalance_param, mv_strDataWriteToDB, v_filename, "")
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strStoreName, v_strClauseParam, , , , , , , gc_CommandProcedure)
            'v_lngError = v_ws.Message(v_strObjMsg)
            'trung.luu: 19-05-2021 them await goi xuong store log hist de khong bi cham client
            v_lngError = Await Task.Run(Function() v_ws.Message(v_strObjMsg))
            'If v_lngError <> ERR_SYSTEM_OK Then
            '    Exit Function
            'End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmSearchCMP2FILE.OnWrite" & vbNewLine _
                         & "Error code: Log lich su doi chieu error: SP_RSE0087!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("msgInvalidInputFile"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "0"
        End Try
    End Function


    Private Sub cboFileType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFileType.SelectedValueChanged
        If Not (IsDBNull(cboFileType.SelectedValue) Or IsNothing(cboFileType.SelectedValue)) Then
            getUpdateFileName(cboFileType.SelectedValue, dtpTXDATE.Value.ToString("dd/MM/yyyy"))
        End If
    End Sub
End Class

