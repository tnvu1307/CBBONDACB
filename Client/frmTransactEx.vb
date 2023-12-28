Imports AppCore
Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO.Path
Imports System.Windows.Forms.Application

Public Class frmTransactEx

    Const c_ResourceManager As String = gc_RootNamespace & "." & "frmTransactEx-"
    Private mv_strTltxcd As String
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strBusDate As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBranchId As String
    Private mv_strTellerName As String
    Private mv_strLocalObject As String
    Private mv_strTellerId As String
    Private AccountGrid As AppCore.GridEx
    Private mv_strOldSearchBy As String
    Private mv_strOldSearchValue As String
    Private mv_xmlCUSTOMER As XmlDocumentEx
    Private mv_strXmlMessageData As String
    Private mv_arrAFACCTNO() As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_blnAcctEntry As Boolean


    'fee info
    Private mv_strFORP As String
    Private mv_dblFEEAMT As Double
    Private mv_dblFEERATE As Double
    Private mv_dblMINVAL As Double
    Private mv_dblMAXVAL As Double
    Private mv_dblVATRATE As Double

    'print report
    Private BranchName As String = String.Empty
    Private BranchAddress As String = String.Empty
    Private BranchPhoneFax As String = String.Empty
    Private DEALINGCUSTODYCD As String = String.Empty
    Private HEADOFFICE As String = String.Empty
    Private ReportTitle As String = String.Empty
    Private mv_blnFirstLoad As Boolean = False
    Private mv_blnView As Boolean = False


#Region " Windows Form Designer generated code "
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        InitExternal()


    End Sub
#End Region

#Region "Properties "


    Public Property MessageData() As String
        Get
            Return mv_strXmlMessageData
        End Get
        Set(ByVal Value As String)
            mv_strXmlMessageData = Value
        End Set
    End Property
    Public Property Tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
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
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
        End Set
    End Property

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
        End Set
    End Property
#End Region


#Region "Private Functions"

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                CType(v_ctrl, RichTextBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                CType(v_ctrl, SplitContainer).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString("frmTransactEx")

    End Sub

    Private Sub EnableResource(ByRef pv_ctrl As Windows.Forms.Control, ByRef pv_Enabled As Boolean)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is GroupBox Then
                'CType(v_ctrl, GroupBox).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                'CType(v_ctrl, SplitContainer).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                'CType(v_ctrl, Panel).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                CType(v_ctrl, RichTextBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is AppCore.ComboBoxEx Then
                CType(v_ctrl, AppCore.ComboBoxEx).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is ComboBox Then
                CType(v_ctrl, ComboBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is MaskedTextBox Then
                CType(v_ctrl, MaskedTextBox).Enabled = pv_Enabled
            End If
        Next
    End Sub

#Region "Print"

    Protected Sub PrintTransact(ByVal pv_strVoucherID As String)
        Dim v_strOldCultureName As String = String.Empty
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_ctl As Control
            Dim pv_VoucherID As String
            pv_VoucherID = pv_strVoucherID
            Dim v_strRptFilePath As String = pv_VoucherID & ".rpt"
            Dim v_blnFileExists As Boolean = False
            Dim v_strReportDirectory, v_strReportTempDirectory As String

            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_strOffName, v_strTlName, v_strTXSTATUS As String
            Dim v_ws As New BDSDeliveryManagement

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String

            Dim v_blnVietnamese As Boolean
            Dim v_strDValue As String
            Dim v_strMValue As String
            Dim v_strYValue As String
            Dim v_strTemp As String
            Dim d As New Date

            v_strReportDirectory = GetReportDirectory()
            v_strReportTempDirectory = GetReportTempDirectory(v_strReportDirectory)
            Dim v_dirInfo As New DirectoryInfo(v_strReportDirectory)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_file As FileInfo


            ' Check if report template is exists
            For Each v_file In v_fileInfo
                If v_file.Name = v_strRptFilePath Then
                    v_blnFileExists = True
                    Exit For
                End If
            Next

            If v_blnFileExists = False Then
                MessageBox.Show(mv_ResourceManager.GetString("CANNOT_FOUND_RPT_FILE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(v_strReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName As String

            GetReportFormularValue()

            Dim v_strBANKID, v_strBANKNAME, v_strBANKACC, v_strBANKACCNAME, v_strGLACCTNO, v_strTXNUM, v_strTXDATE, v_strFEETYPE As String
            Dim v_dblAMT As Double

            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
            For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name

                Dim v_intCount, v_intIndex As Integer
                Select Case v_strFormulaName.ToUpper()
                    Case "P_REFID"
                        v_crFFieldDefinition.Text = "'" & Me.txtREFID.Text.Trim & "'"
                    Case "P_DATE"
                        v_crFFieldDefinition.Text = "'" & Me.BusDate & "'"
                    Case "P_FULLNAME"
                        v_crFFieldDefinition.Text = "'" & Me.txtRQSNAME.Text.Trim & "'"
                    Case "P_ADDRESS"
                        v_crFFieldDefinition.Text = "'" & Me.txtADDRESS.Text.Trim & "'"
                    Case "P_LICENSE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDCODE.Text.Trim & "'"
                    Case "P_IDDATE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDDATE.Text.Trim & "'"
                    Case "P_IDPLACE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDPLACE.Text.Trim & "'"
                    Case "P_CUSTODYCD"
                        v_crFFieldDefinition.Text = "'" & Me.txtCUSTODYCD.Text.Trim & "'"
                    Case "P_CUSTNAME"
                        v_crFFieldDefinition.Text = "'" & Me.lblFULLNAME.Text.Trim & "'"
                    Case "P_AMT"
                        v_crFFieldDefinition.Text = "'" & FormatNumber(CDbl(Me.txtAMT.Text.Trim)) & "'"
                    Case "P_DESC"
                        v_crFFieldDefinition.Text = "'" & Me.txtDESC.Text.Trim & "'"
                    Case "P_BENEFACCT"
                        v_crFFieldDefinition.Text = "'" & IIf(Me.Tltxcd = gc_CI_INTERNALTRANSFER, String.Empty, Me.txtBENEFACCT.Text) & "'"
                    Case "P_BENEFCUSTNAME"
                        v_crFFieldDefinition.Text = "'" & IIf(Me.Tltxcd = gc_CI_INTERNALTRANSFER, Me.lblFULLNAME2.Text, Me.txtBENEFCUSTNAME.Text.Trim) & "'"
                    Case "P_BENEFBANK"
                        v_crFFieldDefinition.Text = "'" & Me.txtBENEFBANK.Text.Trim & "'"
                    Case "P_CUSTODYCD2"
                        v_crFFieldDefinition.Text = "'" & Me.txtCUSTODYCD2.Text.Trim & "'"
                    Case "P_ACCTNO2"
                        If Not mv_arrAFACCTNO Is Nothing Then
                            v_crFFieldDefinition.Text = "'" & mv_arrAFACCTNO(Me.cboAFACCTNO2.SelectedIndex) & "'"
                        End If
                    Case "P_ADDRESS2"
                        v_crFFieldDefinition.Text = "'" & Me.txtADDRESS2.Text.Trim & "'"
                    Case "P_LICENSE2"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDCODE2.Text.Trim & "'"
                    Case "P_IDDATE2"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDDATE2.Text.Trim & "'"
                    Case "P_IDPLACE2"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDPLACE2.Text.Trim & "'"
                    Case gc_RPT_FORMULAR_BRID
                        v_crFFieldDefinition.Text = "'" & Me.BranchId & "'"
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HEADOFFICE & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_FORMULAR_DEALINGCUSTODYCD
                        v_crFFieldDefinition.Text = "'" & DEALINGCUSTODYCD & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & Me.BusDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Me.TellerId & "'"

                End Select
            Next

            'TruongLD Add 14/09/2011
            'Neu dung Culture la "vi-VN" --> khong su dung duoc func Convert Number to Text --> Chuyen ve "en-US"
            'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office

            v_strOldCultureName = SetCultureInfo("en-US")
            'End TruongLD

            If v_rptDocument.IsLoaded Then
                'Export to PDF
                v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, v_strReportTempDirectory & pv_VoucherID & ".rpt")
            End If


            Dim v_Path As String = Environment.CurrentDirectory
            Dim v_frm As New frmReportView

            v_frm.RptFileName = v_strReportTempDirectory & pv_VoucherID & ".rpt"
            v_frm.RptName = pv_VoucherID
            v_frm.ShowDialog()
            Environment.CurrentDirectory = v_Path
            'TruongLD Add 14/09/2011
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            'v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            'End TruongLD

        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        Finally
            If Len(v_strOldCultureName) > 0 Then
                v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            End If
        End Try
    End Sub

    Protected Sub SubPrintTransact(ByVal pv_strVoucherID As String)
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_ctl As Control
            Dim pv_VoucherID As String
            pv_VoucherID = pv_strVoucherID
            Dim v_strRptFilePath As String = pv_VoucherID & ".rpt"
            Dim v_blnFileExists As Boolean = False
            Dim v_strReportDirectory, v_strReportTempDirectory As String

            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_strOffName, v_strTlName, v_strTXSTATUS As String
            Dim v_ws As New BDSDeliveryManagement

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String

            Dim v_blnVietnamese As Boolean
            Dim v_strDValue As String
            Dim v_strMValue As String
            Dim v_strYValue As String
            Dim v_strTemp As String
            Dim d As New Date
            Dim v_strTransact_Detail_List As String

            'Lay du lieu vao dataset
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountRow, v_intCountCol As Integer
            v_ds.Tables.Add("RptData")
            For j As Integer = 0 To AccountGrid.Columns.Count - 1
                v_dc = New DataColumn(AccountGrid.Columns(j).FieldName)
                v_dc.ColumnName = AccountGrid.Columns(j).FieldName
                v_dc.DataType = AccountGrid.Columns(j).DataType
                v_ds.Tables(0).Columns.Add(v_dc)
            Next
            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                If Not AccountGrid.DataRows(i).Cells("AFAMT").Value Is Nothing AndAlso AccountGrid.DataRows(i).Cells("AFAMT").Value <> 0 Then
                    v_dr = v_ds.Tables(0).NewRow()
                    For j As Integer = 0 To AccountGrid.Columns.Count - 1
                        v_dr(j) = AccountGrid.DataRows(i).Cells(j).Value
                    Next
                    v_ds.Tables(0).Rows.Add(v_dr)
                    v_strTransact_Detail_List = v_strTransact_Detail_List & AccountGrid.DataRows(i).Cells("AFACCTNO").Value & " - " & AccountGrid.DataRows(i).Cells("TXNUM").Value & " : " & FormatNumber(AccountGrid.DataRows(i).Cells("AFAMT").Value, 0) & "CCY" & "|"
                End If
            Next

            v_strReportDirectory = GetReportDirectory()
            v_strReportTempDirectory = GetReportTempDirectory(v_strReportDirectory)
            Dim v_dirInfo As New DirectoryInfo(v_strReportDirectory)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_file As FileInfo


            ' Check if report template is exists
            For Each v_file In v_fileInfo
                If v_file.Name = v_strRptFilePath Then
                    v_blnFileExists = True
                    Exit For
                End If
            Next
            If v_blnFileExists = False Then
                v_ds.WriteXml(v_strReportDirectory & pv_VoucherID & ".xml", XmlWriteMode.WriteSchema)
                MessageBox.Show(mv_ResourceManager.GetString("CANNOT_FOUND_RPT_FILE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(v_strReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName As String

            GetReportFormularValue()

            Dim v_strBANKID, v_strBANKNAME, v_strBANKACC, v_strBANKACCNAME, v_strGLACCTNO, v_strTXNUM, v_strTXDATE, v_strFEETYPE As String
            Dim v_dblAMT As Double

            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
            For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name

                Dim v_intCount, v_intIndex As Integer
                Select Case v_strFormulaName.ToUpper()
                    Case "P_REFID"
                        v_crFFieldDefinition.Text = "'" & Me.txtREFID.Text.Trim & "'"
                    Case "P_DATE"
                        v_crFFieldDefinition.Text = "'" & Me.BusDate & "'"
                    Case "P_FULLNAME"
                        v_crFFieldDefinition.Text = "'" & Me.txtRQSNAME.Text.Trim & "'"
                    Case "P_ADDRESS"
                        v_crFFieldDefinition.Text = "'" & Me.txtADDRESS.Text.Trim & "'"
                    Case "P_LICENSE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDCODE.Text.Trim & "'"
                    Case "P_IDDATE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDDATE.Text.Trim & "'"
                    Case "P_IDPLACE"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDPLACE.Text.Trim & "'"
                    Case "P_CUSTODYCD"
                        v_crFFieldDefinition.Text = "'" & Me.txtCUSTODYCD.Text.Trim & "'"
                    Case "P_CUSTNAME"
                        v_crFFieldDefinition.Text = "'" & Me.lblFULLNAME.Text.Trim & "'"
                    Case "P_AMT"
                        v_crFFieldDefinition.Text = "'" & FormatNumber(CDbl(Me.txtAMT.Text.Trim)) & "'"
                    Case "P_DESC"
                        v_crFFieldDefinition.Text = "'" & Me.txtDESC.Text.Trim & "'"
                    Case "P_BENEFACCT"
                        v_crFFieldDefinition.Text = "'" & IIf(Me.Tltxcd = gc_CI_INTERNALTRANSFER, String.Empty, Me.txtBENEFACCT.Text) & "'"
                    Case "P_BENEFCUSTNAME"
                        v_crFFieldDefinition.Text = "'" & IIf(Me.Tltxcd = gc_CI_INTERNALTRANSFER, Me.lblFULLNAME2.Text, Me.txtBENEFCUSTNAME.Text.Trim) & "'"
                    Case "P_BENEFBANK"
                        v_crFFieldDefinition.Text = "'" & Me.txtBENEFBANK.Text.Trim & "'"
                    Case "P_CUSTODYCD2"
                        v_crFFieldDefinition.Text = "'" & Me.txtCUSTODYCD2.Text.Trim & "'"
                    Case "P_ACCTNO2"
                        If Not mv_arrAFACCTNO Is Nothing Then
                            v_crFFieldDefinition.Text = "'" & mv_arrAFACCTNO(Me.cboAFACCTNO2.SelectedIndex) & "'"
                        End If
                    Case "P_ADDRESS2"
                        v_crFFieldDefinition.Text = "'" & Me.txtADDRESS2.Text.Trim & "'"
                    Case "P_LICENSE2"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDCODE2.Text.Trim & "'"
                    Case "P_IDDATE2"
                        v_crFFieldDefinition.Text = "'" & Me.txtIDDATE2.Text.Trim & "'"
                    Case "P_IDPLACE2"
                    Case "F_TRANSACT_LIST_DETAIL"
                        v_crFFieldDefinition.Text = "'" & v_strTransact_Detail_List & "'"
                    Case gc_RPT_FORMULAR_BRID
                        v_crFFieldDefinition.Text = "'" & Me.BranchId & "'"
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HEADOFFICE & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_FORMULAR_DEALINGCUSTODYCD
                        v_crFFieldDefinition.Text = "'" & DEALINGCUSTODYCD & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & Me.BusDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Me.TellerId & "'"
                End Select
            Next
            v_rptDocument.SetDataSource(v_ds)

            If v_rptDocument.IsLoaded Then
                'Export to PDF
                v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, v_strReportTempDirectory & pv_VoucherID & ".rpt")
            End If

            Dim v_frm As New frmReportView
            Dim v_Path As String = Environment.CurrentDirectory
            v_frm.RptFileName = v_strReportTempDirectory & pv_VoucherID & ".rpt"
            v_frm.RptName = pv_VoucherID
            v_frm.ShowDialog()
            Environment.CurrentDirectory = v_Path
        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub GetReportFormularValue()
        Try
            'Get common values from SYSVAR table
            Dim v_strSQL As String = "SELECT VARNAME, VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND varname IN ('BRADDRESS','BRPHONEFAX','BRNAME', 'HEADOFFICE', 'DEALINGCUSTODYCD')"
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSRptDeliveryManagement
            Dim v_intRowCount As Integer
            Dim v_strVarName, v_strVarValue As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_xmlNode As Xml.XmlNode

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count

            If (v_intRowCount > 0) Then
                v_xmlNode = v_xmlDocument.FirstChild

                For i As Integer = 0 To v_intRowCount - 1
                    v_strVarName = v_xmlNode.ChildNodes(i).ChildNodes(0).InnerText.Trim().ToUpper()

                    Select Case v_strVarName
                        Case "HEADOFFICE"
                            HEADOFFICE = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME"
                            BranchName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS"
                            BranchAddress = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX"
                            BranchPhoneFax = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "DEALINGCUSTODYCD"
                            DEALINGCUSTODYCD = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                    End Select
                Next
            Else
                BranchName = String.Empty
                BranchAddress = String.Empty
                BranchPhoneFax = String.Empty
                DEALINGCUSTODYCD = String.Empty
                HEADOFFICE = String.Empty
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetReportDirectory() As String
        Try

            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSRptDeliveryManagement
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String
            Dim v_strReportDir As String = String.Empty

            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'DIRRPTFILES'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strReportDir = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next

            If Not (v_strReportDir.Length > 0) Then
                v_strReportDir = GetDirectoryName(ExecutablePath) & "\REPORTS\"
            End If
            v_strReportDir = v_strReportDir.Trim() & IIf(v_strReportDir.Trim().Substring(v_strReportDir.Trim().Length - 1) = "\", "", "\")

            'Check if report directory is exists; otherwise, create it
            Dim v_dirInfo As New DirectoryInfo(v_strReportDir)
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If
            'Check if report temporary directory is exists; otherwise, create it
            v_dirInfo = New DirectoryInfo(GetReportTempDirectory(v_strReportDir))
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If

            Return v_strReportDir
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Function GetReportTempDirectory(ByVal pv_strReportDir As String) As String
        Return pv_strReportDir & "TEMP\"
    End Function
#End Region


    Private Sub InitExternal()
        AccountGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        AccountGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        AccountGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("AVLAFAMT", GetType(System.Double)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("AFAMT", GetType(System.Double)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("FEEAMT", GetType(System.Double)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("VATAMT", GetType(System.Double)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("STATUS_DESC", GetType(System.String)))
        AccountGrid.Columns.Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))

        AccountGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("ACCOUNT_AFACCTNO")
        AccountGrid.Columns("TYPENAME").Title = mv_ResourceManager.GetString("ACCOUNT_ACTYPE")
        AccountGrid.Columns("AVLAFAMT").Title = mv_ResourceManager.GetString("ACCOUNT_AVAILAFAMT")
        AccountGrid.Columns("AFAMT").Title = mv_ResourceManager.GetString("ACCOUNT_AFAMT")
        AccountGrid.Columns("FEEAMT").Title = mv_ResourceManager.GetString("ACCOUNT_FEEAMT")
        AccountGrid.Columns("VATAMT").Title = mv_ResourceManager.GetString("ACCOUNT_VATAMT")
        AccountGrid.Columns("STATUS_DESC").Title = mv_ResourceManager.GetString("ACCOUNT_STATUS_DESC")
        AccountGrid.Columns("TXNUM").Title = mv_ResourceManager.GetString("TXNUM")

        AccountGrid.Columns("AFACCTNO").Width = 100
        AccountGrid.Columns("TYPENAME").Width = 200
        AccountGrid.Columns("AVLAFAMT").Width = 100
        AccountGrid.Columns("AFAMT").Width = 100
        AccountGrid.Columns("FEEAMT").Width = 100
        AccountGrid.Columns("VATAMT").Width = 100
        AccountGrid.Columns("STATUS_DESC").Width = 100
        AccountGrid.Columns("TXNUM").Width = 100

        AccountGrid.Columns("STATUS").Visible = False

        AccountGrid.Columns("AVLAFAMT").FormatSpecifier = "#,##0.###"
        AccountGrid.Columns("AFAMT").FormatSpecifier = "#,##0.###"
        AccountGrid.Columns("FEEAMT").FormatSpecifier = "#,##0.###"
        AccountGrid.Columns("VATAMT").FormatSpecifier = "#,##0.###"

        AccountGrid.Columns("AFAMT").ReadOnly = False

        AccountGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        AccountGrid.Columns("TYPENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountGrid.Columns("AVLAFAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        AccountGrid.Columns("AFAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        AccountGrid.Columns("STATUS_DESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        AccountGrid.Columns("TXNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center


        Me.scrMain.Panel2.Controls.Clear()
        Me.scrMain.Panel2.Controls.Add(AccountGrid)
        AccountGrid.Dock = Windows.Forms.DockStyle.Fill

        If Me.AccountGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.AccountGrid.DataRowTemplate.Cells.Count - 1
                AddHandler AccountGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf AccountGrid_Changed
            Next
            For j As Integer = 0 To Me.AccountGrid.DataRows.Count - 1
                Me.AccountGrid.DataRows(j).Cells("AFAMT").BackColor = Color.White
            Next
        End If

    End Sub

    Private Function GetWithDrawnID() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_WITHDRAWN"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        'Tạo số hiệu lệnh = Mã chi nhánh + Ngày hệ thống + Số tự tăng

        Return Strings.Right("0000000000" & CStr(v_strAutoID), Len("0000000000"))

    End Function

    Private Sub LoadTransactInfo(ByVal v_strREFID As String)
        Dim v_strSQL, v_strObjMsg, v_strNValue, v_strCValue, v_strFieldName, v_strValue, v_strTXNUM, v_strTXDATE, v_strFldType, v_strFLDNAME, v_strDefName, v_strPDefName, v_strDefVal As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_objField As CFieldMaster

        Try

            v_strSQL = "SELECT txnum, txdate FROM cicustwithdraw WHERE REF = '" & v_strREFID & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXNUM"
                                v_strTXNUM = v_strValue
                            Case "TXDATE"
                                v_strTXDATE = v_strValue
                        End Select
                    End With
                Next
                ViewTransactInfo(v_strTXNUM, v_strTXDATE)
            Next

            'Cap nhat so tien tong.
            Me.txtAVAILAMT.Text = "0"
            Me.txtAMT.Text = "0"
            Me.txtFEEAMT.Text = "0"
            Me.txtVATAMT.Text = "0"
            Me.txtREMAINAMT.Text = "0"
            Me.txtETAMT.Text = "0"

            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                Me.txtAVAILAMT.Text = CDbl(IIf(Me.txtAVAILAMT.Text = String.Empty, "0", Me.txtAVAILAMT.Text)) + Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0)
                Me.txtAMT.Text = CDbl(IIf(Me.txtAMT.Text = String.Empty, "0", Me.txtAMT.Text)) + AccountGrid.DataRows(i).Cells("AFAMT").Value
                Me.txtFEEAMT.Text = CDbl(IIf(Me.txtFEEAMT.Text = String.Empty, "0", Me.txtFEEAMT.Text)) + AccountGrid.DataRows(i).Cells("FEEAMT").Value
                Me.txtVATAMT.Text = CDbl(IIf(Me.txtVATAMT.Text = String.Empty, "0", Me.txtVATAMT.Text)) + AccountGrid.DataRows(i).Cells("VATAMT").Value
            Next
            Me.txtREMAINAMT.Text = CDbl(Me.txtAVAILAMT.Text) - CDbl(Me.txtAMT.Text)
            Me.txtETAMT.Text = CDbl(Me.txtAMT.Text) + CDbl(Me.txtFEEAMT.Text) + CDbl(Me.txtVATAMT.Text)

            FormatText()


            If mv_blnView Then
                EnableResource(Me, False)
                Me.btnCancel.Enabled = True
                Me.btnPrint.Enabled = True
                Me.btnSubPrint.Enabled = True
                Me.txtREFID.Enabled = True
                For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                    AccountGrid.DataRows(i).Cells("AFAMT").ReadOnly = True
                Next
            Else
                EnableResource(Me, True)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewTransactInfo(ByVal v_strTXNUM As String, ByVal v_strTXDATE As String)
        Dim v_strSQL, v_strObjMsg, v_strNValue, v_strCValue, v_strFieldName, v_strValue, v_strFldType, v_strFLDNAME, v_strDefName, v_strPDefName, v_strDefVal As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_objField As CFieldMaster
        Try
            v_strSQL = "SELECT tf.*, fm.defname , fm.pdefname, fm.fldtype " & ControlChars.CrLf _
            & "FROM tllogfld tf,(SELECT * FROM cicustwithdraw ci WHERE ci.txnum = '" & v_strTXNUM & "' AND ci.txdate = to_date('" & v_strTXDATE & "','DD/MM/RRRR')) wd, fldmaster fm " & ControlChars.CrLf _
            & "WHERE tf.txnum = wd.txnum AND wd.txdate = tf.txdate AND fm.fldname = tf.fldcd AND fm.objname = '" & Me.Tltxcd & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFields(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                v_strNValue = vbNullString
                v_strCValue = vbNullString
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "NVALUE"
                                v_strNValue = v_strValue
                            Case "CVALUE"
                                v_strCValue = v_strValue
                            Case "PDEFNAME"
                                v_strPDefName = v_strValue
                            Case "FLDTYPE"
                                v_strFldType = v_strValue
                            Case "FLDCD"
                                v_strFieldName = v_strValue
                        End Select
                    End With
                Next
                v_objField = New CFieldMaster
                With v_objField
                    .ColumnName = v_strDefName
                    .FieldName = v_strFieldName
                    If CDbl(v_strNValue) <> 0 Then
                        v_strDefVal = v_strNValue
                    ElseIf v_strFldType = "N" Then
                        v_strDefVal = v_strNValue
                    Else
                        v_strDefVal = v_strCValue
                    End If
                    .FieldValue = v_strDefVal
                    .DefaultValue = v_strDefVal
                    .Enabled = False 'v_blnEnabled
                    .PDefName = v_strPDefName
                End With
                mv_arrObjFields(i) = v_objField
            Next

            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'fill data to control
            Select Case Me.Tltxcd
                Case gc_CI_CASH_WITHDRAWN
                    'GetFieldValueByName("03") 'ACCTNO   
                    Me.txtDESC.Text = GetFieldValueByName("30") 'DESC     
                    'GetFieldValueByName("79") 'REFID    
                    If mv_blnFirstLoad Then
                        Me.txtCUSTODYCD.Text = GetFieldValueByName("88") 'CUSTODYCD
                        If Me.txtCUSTODYCD.Text <> String.Empty Then
                            GetCustomerSubAccount(Me.txtCUSTODYCD.Text)
                        End If
                        mv_blnFirstLoad = False
                    End If
                    Me.txtRQSNAME.Text = GetFieldValueByName("95") 'CUSTNAME 
                    'Me.txtADDRESS.Text = GetFieldValueByName("91") 'ADDRESS  
                    'Me.txtIDCODE.Text = GetFieldValueByName("92") 'LICENSE  
                    'Me.lblFULLNAME.Text = GetFieldValueByName("90") 'FULLNAME 
                    'Me.txtIDDATE.Text = GetFieldValueByName("98") 'IDDATE   
                    'Me.txtIDPLACE.Text = GetFieldValueByName("99") 'IDPLACE  
                    For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                        If AccountGrid.DataRows(i).Cells("AFACCTNO").Value = GetFieldValueByName("03") Then
                            AccountGrid.DataRows(i).Cells("AVLAFAMT").Value = CDbl(GetFieldValueByName("89")) 'AVLCASH  
                            AccountGrid.DataRows(i).Cells("AFAMT").Value = CDbl(GetFieldValueByName("10")) 'AMT 
                            AccountGrid.DataRows(i).Cells("FEEAMT").Value = 0.0 'FEEAMT   
                            AccountGrid.DataRows(i).Cells("VATAMT").Value = 0.0 'VATAMT    
                            AccountGrid.DataRows(i).Cells("TXNUM").Value = v_strTXNUM
                        End If
                    Next
                Case gc_CI_INTERNALTRANSFER
                    Me.txtDESC.Text = GetFieldValueByName("30") 'DESC  
                    Me.txtRQSNAME.Text = GetFieldValueByName("31") 'FULLNAME 
                    'GetFieldValueByName("79") 'REFID     
                    If mv_blnFirstLoad Then
                        Me.txtCUSTODYCD.Text = GetFieldValueByName("88") 'CUSTODYCD
                        If Me.txtCUSTODYCD.Text <> String.Empty Then
                            GetCustomerSubAccount(Me.txtCUSTODYCD.Text)
                        End If
                        mv_blnFirstLoad = False
                    End If
                    If GetFieldValueByName("89") <> Me.txtCUSTODYCD2.Text Then
                        Me.txtCUSTODYCD2.Text = GetFieldValueByName("89") 'CUSTODYCD
                        If Me.txtCUSTODYCD2.Text <> String.Empty Then
                            GetCustomerSubAccount2(Me.txtCUSTODYCD2.Text)
                        End If
                    End If
                    Me.cboAFACCTNO2.SelectedIndex = mv_arrAFACCTNO.IndexOf(mv_arrAFACCTNO, GetFieldValueByName("05")) 'CACCTNO  
                    'GetFieldValueByName("90") 'CUSTNAME 
                    'Me.txtADDRESS.Text = GetFieldValueByName("91") 'ADDRESS  
                    'Me.txtIDCODE.Text = GetFieldValueByName("92") 'LICENSE  
                    'Me.lblFULLNAME2.Text = GetFieldValueByName("93") 'CUSTNAME2
                    'Me.txtADDRESS2.Text = GetFieldValueByName("94") 'ADDRESS2 
                    'Me.txtIDCODE2.Text = GetFieldValueByName("95") 'LICENSE2 
                    'Me.txtIDCODE.Text = GetFieldValueByName("96") 'IDDATE   
                    'Me.txtIDDATE.Text = GetFieldValueByName("97") 'IDPLACE  
                    'Me.txtIDDATE2.Text = GetFieldValueByName("98") 'IDDATE2  
                    'Me.txtIDPLACE2.Text = GetFieldValueByName("99") 'IDPLACE2 
                    For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                        If AccountGrid.DataRows(i).Cells("AFACCTNO").Value = GetFieldValueByName("03") Then
                            AccountGrid.DataRows(i).Cells("AVLAFAMT").Value = CDbl(GetFieldValueByName("87")) 'CASTBAL  
                            AccountGrid.DataRows(i).Cells("AFAMT").Value = CDbl(GetFieldValueByName("10")) 'AMT 
                            AccountGrid.DataRows(i).Cells("FEEAMT").Value = 0.0 'FEEAMT   
                            AccountGrid.DataRows(i).Cells("VATAMT").Value = 0.0 'VATAMT    
                            AccountGrid.DataRows(i).Cells("TXNUM").Value = v_strTXNUM
                        End If
                    Next
                Case gc_CI_TRANSFER2BANK
                    'GetFieldValueByName("03") 'ACCTNO       
                    'GetFieldValueByName("05") 'BANKID       
                    Me.cboIORO.SelectedValue = GetFieldValueByName("09") 'IORO 
                    'GetFieldValueByName("13") 'TRFAMT       
                    Me.txtDESC.Text = GetFieldValueByName("30") 'DESC         
                    Me.txtFEECD.Text = GetFieldValueByName("66") '$FEECD       
                    'GetFieldValueByName("79") 'REFID        
                    Me.txtBENEFBANK.Text = GetFieldValueByName("80") 'BENEFBANK    
                    Me.txtBENEFACCT.Text = GetFieldValueByName("81") 'BENEFACCT    
                    Me.txtBENEFCUSTNAME.Text = GetFieldValueByName("82") 'BENEFCUSTNAME 
                    If mv_blnFirstLoad Then
                        Me.txtCUSTODYCD.Text = GetFieldValueByName("88") 'CUSTODYCD
                        If Me.txtCUSTODYCD.Text <> String.Empty Then
                            GetCustomerSubAccount(Me.txtCUSTODYCD.Text)
                        End If
                        mv_blnFirstLoad = False
                    End If
                    Me.txtRQSNAME.Text = GetFieldValueByName("95") 'CUSTNAME     
                    'Me.lblFULLNAME.Text = GetFieldValueByName("95") 'FULLNAME     
                    'Me.txtADDRESS.Text = GetFieldValueByName("96") 'ADDRESS      
                    'Me.txtIDCODE.Text = GetFieldValueByName("97") 'LICENSE      
                    'Me.txtIDDATE.Text = GetFieldValueByName("98") 'IDDATE       
                    'Me.txtIDPLACE.Text = GetFieldValueByName("99") 'IDPLACE   
                    For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                        If AccountGrid.DataRows(i).Cells("AFACCTNO").Value = GetFieldValueByName("03") Then
                            AccountGrid.DataRows(i).Cells("AVLAFAMT").Value = CDbl(GetFieldValueByName("89")) 'CASTBAL   
                            AccountGrid.DataRows(i).Cells("AFAMT").Value = CDbl(GetFieldValueByName("10")) 'AMT 
                            AccountGrid.DataRows(i).Cells("FEEAMT").Value = CDbl(GetFieldValueByName("11")) 'FEEAMT   
                            AccountGrid.DataRows(i).Cells("VATAMT").Value = CDbl(GetFieldValueByName("12")) 'VATAMT       
                            AccountGrid.DataRows(i).Cells("TXNUM").Value = v_strTXNUM
                        End If
                    Next

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetFieldValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = gc_RootNamespace & "." & "frmTransactEx.GetFieldValueByName"
        Dim i, v_count As Integer, v_strFLDVALUE As String
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    v_strFLDVALUE = mv_arrObjFields(i).FieldValue
                    Return v_strFLDVALUE
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Private Function ControlValidation() As Boolean
        If Me.txtCUSTODYCD.TextLength = 0 OrElse AccountGrid.DataRows.Count = 0 Then
            MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTINFO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtCUSTODYCD.Focus()
            Return False
        End If
        If Me.txtAMT.Text = String.Empty OrElse CDbl(Me.txtAMT.Text) <= 0 Then
            MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtAMT.Focus()
            Return False
        End If

        If Me.Tltxcd = "1100" Then

        ElseIf Me.Tltxcd = "1101" Then
            If Me.txtBENEFACCT.Text = String.Empty Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_BENEFACCT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBENEFACCT.Focus()
                Return False
            End If
            If Me.txtBENEFBANK.Text = String.Empty Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_BENEFBANK"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBENEFBANK.Focus()
                Return False
            End If
            If Me.txtBENEFCUSTNAME.Text = String.Empty Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_BENEFCUSTNAME"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBENEFCUSTNAME.Focus()
                Return False
            End If
            If Me.txtFEECD.Enabled AndAlso Me.txtFEECD.Text = String.Empty Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_FEECD"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtFEECD.Focus()
                Return False
            End If
        ElseIf Me.Tltxcd = "1120" Then
            If Me.txtCUSTODYCD2.Text = String.Empty OrElse Me.lblFULLNAME2.Text = String.Empty Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTINFO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtCUSTODYCD2.Focus()
                Return False
            End If
        End If
        Return True
    End Function



    Private Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage, v_strTXDESC As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strLate As String
        Dim v_blnSuccess As Boolean = False
        Try
            If Me.txtCUSTODYCD.Text.Trim = String.Empty OrElse AccountGrid.DataRows.Count = 0 Then
                Exit Sub
            End If
            Select Case Me.Tltxcd
                Case gc_CI_CASH_WITHDRAWN
                    v_strTXDESC = mv_ResourceManager.GetString("WITHDRAWN_DESC")
                Case gc_CI_INTERNALTRANSFER
                    v_strTXDESC = mv_ResourceManager.GetString("INTERNALTRANSFER_DESC")
                Case gc_CI_TRANSFER2BANK
                    v_strTXDESC = mv_ResourceManager.GetString("TRANSFER2BANK_DESC")
            End Select

            If (MessageBox.Show(mv_ResourceManager.GetString("ConfirmApply").Replace("<<TXDESC>>", v_strTXDESC), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If Not ControlValidation() Then
                    Exit Sub
                End If
                Me.txtREFID.Text = GetWithDrawnID()

                For k As Integer = 0 To AccountGrid.DataRows.Count - 1
                    If AccountGrid.DataRows(k).Cells("AFAMT").Value <> 0 Then
                        'Verify và tạo điện giao dịch
                        If Not VerifyRules(v_strTxMsg, k) Then
                            Exit Sub
                        Else
                            v_lngError = v_ws.Message(v_strTxMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                Else
                                    v_lngError = v_ws.Message(v_strTxMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
                                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                            Exit Sub
                                        Else
                                            'Lấy thêm nguyên nhân duyệt
                                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                        End If
                                    Else
                                        v_blnSuccess = True
                                        v_xmlDocument.LoadXml(v_strTxMsg)
                                        If Not v_xmlDocument.SelectSingleNode("TransactMessage") Is Nothing AndAlso Not v_xmlDocument.SelectSingleNode("TransactMessage").Attributes("TXNUM") Is Nothing Then
                                            AccountGrid.DataRows(k).Cells("TXNUM").Value = v_xmlDocument.SelectSingleNode("TransactMessage").Attributes("TXNUM").InnerText
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
                If v_blnSuccess Then
                    MsgBox(mv_ResourceManager.GetString("TransactionSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    EnableResource(Me, False)
                    Me.btnPrint.Enabled = True
                    Me.btnSubPrint.Enabled = True
                    Me.btnCancel.Enabled = True
                    For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                        AccountGrid.DataRows(i).Cells("AFAMT").ReadOnly = True
                    Next
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region " Events"
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        OnSubmit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Select Case Me.Tltxcd
                Case gc_CI_CASH_WITHDRAWN
                    PrintTransact("WDRLCCUST")
                Case gc_CI_INTERNALTRANSFER
                    PrintTransact("TRANFCCUST")
                Case gc_CI_TRANSFER2BANK
                    PrintTransact("TRANFCCUST")

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCUSTODYCD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUSTODYCD.GotFocus

        txtCUSTODYCD.SelectionStart = txtCUSTODYCD.Text.Trim.Length

    End Sub

    Private Sub AccountGrid_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AllocateWithdrawAmount()
    End Sub

    Private Sub txtCUSTODYCD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD.Validating
        Dim v_strSEARCHVALUE As String
        Me.txtCUSTODYCD.Text = Me.txtCUSTODYCD.Text.ToUpper

        v_strSEARCHVALUE = txtCUSTODYCD.Text.ToUpper
        If Me.mv_strOldSearchValue <> v_strSEARCHVALUE Then
            mv_strOldSearchValue = v_strSEARCHVALUE
            'Lay danh sach cac tieu khoan.
            GetCustomerSubAccount(v_strSEARCHVALUE)
            'Lay danh sach so tien co the rut cua tung tieu khoan.
            GetAvlWithdrawSubAccount()
            'Tinh toan tong so tien cho phep rut
            Me.txtAVAILAMT.Text = "0"
            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                Me.txtAVAILAMT.Text = CDbl(Me.txtAVAILAMT.Text) + Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0)
            Next
            'Neu tong so tien cho phep rut <> 0 --> thuc hien phan bo so tien rut.
            'If Me.txtAVAILAMT.Text <> "0" Then
            '    Me.txtAMT.Text = Me.txtAVAILAMT.Text
            '    'validating cua txtAMT se thuc hien phan bo so tien rut.
            'End If
            FormatText()

            Me.txtAMT.Focus()
        End If
    End Sub

    Private Sub GetCustomerSubAccount(ByVal v_strSEARCHVALUE As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFULLNAME, v_strADDRESS, v_strIDDATE, v_strIDPLACE, _
                v_strIDCODE, v_strSQLString As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select cf.fullname, cf.address, cf.idcode, cf.iddate, cf.idplace, af.acctno afacctno, aft.typename , 0 avlafamt, 0 afamt, af.status , a1.cdcontent status_desc " & ControlChars.CrLf _
                        & " from afmast af, cfmast cf, aftype aft , mrtype mrt, allcode a1 " & ControlChars.CrLf _
                        & " where af.custid = cf.custid and af.actype = aft.actype and aft.mrtype = mrt.actype(+) AND a1.cdtype = 'CF' AND a1.cdname = 'STATUS' AND a1.cdval = af.status " & ControlChars.CrLf _
                        & " and cf.custodycd = '" & v_strSEARCHVALUE.ToUpper & "' " & ControlChars.CrLf _
                        & " ORDER BY (CASE WHEN MRT.MRTYPE = 'T' THEN 10 WHEN MRT.MRTYPE = 'L' THEN 5 ELSE 0 END) ASC "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.AccountGrid.DataRows.Clear()

                    Me.lblFULLNAME.Text = String.Empty
                    Me.txtRQSNAME.Text = String.Empty
                    Me.txtADDRESS.Text = String.Empty
                    Me.txtIDCODE.Text = String.Empty
                    Me.txtIDDATE.Text = String.Empty
                    Me.txtIDPLACE.Text = String.Empty

                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
                    Exit Sub
                End If
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                v_strFULLNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADDRESS" Then
                                v_strADDRESS = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
                                v_strIDCODE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDDATE" Then
                                v_strIDDATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDPLACE" Then
                                v_strIDPLACE = .InnerText.ToString
                            End If
                        End With
                    Next
                    Me.lblFULLNAME.Text = v_strFULLNAME
                    Me.txtADDRESS.Text = v_strADDRESS
                    Me.txtIDCODE.Text = v_strIDCODE
                    Me.txtIDDATE.Text = v_strIDDATE
                    Me.txtIDPLACE.Text = v_strIDPLACE
                    Me.txtRQSNAME.Text = v_strFULLNAME
                    Exit For
                Next

                'Fill data to grid
                AccountGrid.DataRows.Clear()
                FillDataGrid(AccountGrid, v_strObjMsg, "")
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub GetCustomerSubAccount2(ByVal v_strSEARCHVALUE As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFULLNAME, v_strADDRESS, v_strIDDATE, v_strIDPLACE, v_strIDCODE, v_strACCTNO, v_strOWNERNAME, v_strSQLString As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "SELECT acctno, ownername, cf.idcode, cf.idplace, cf.iddate,cf.address, cf.fullname FROM VW_BD_GETSUBACCT_BYCF vw, cfmast cf WHERE cfcustodycd = custodycd AND  cfcustodycd = '" & v_strSEARCHVALUE.ToUpper & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.txtCUSTODYCD2.Text = String.Empty
                    Me.txtCUSTODYCD2.Focus()
                    Me.lblFULLNAME2.Text = String.Empty
                    Me.txtADDRESS2.Text = String.Empty
                    Me.txtIDCODE2.Text = String.Empty
                    Me.txtIDDATE2.Text = String.Empty
                    Me.txtIDPLACE2.Text = String.Empty

                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
                    Exit Sub
                End If
                Me.cboAFACCTNO2.Items.Clear()
                mv_arrAFACCTNO = Nothing
                ReDim mv_arrAFACCTNO(v_lngCount)
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                v_strFULLNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACCTNO" Then
                                v_strACCTNO = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "OWNERNAME" Then
                                v_strOWNERNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADDRESS" Then
                                v_strADDRESS = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
                                v_strIDCODE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDDATE" Then
                                v_strIDDATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDPLACE" Then
                                v_strIDPLACE = .InnerText.ToString
                            End If
                        End With
                    Next
                    mv_arrAFACCTNO(i) = v_strACCTNO
                    Me.cboAFACCTNO2.Items.Add(v_strOWNERNAME)
                Next
                If Me.cboAFACCTNO2.Items.Count > 0 Then
                    Me.cboAFACCTNO2.SelectedIndex = 0
                End If
                Me.lblFULLNAME2.Text = v_strFULLNAME
                Me.txtADDRESS2.Text = v_strADDRESS
                Me.txtIDCODE2.Text = v_strIDCODE
                Me.txtIDDATE2.Text = v_strIDDATE
                Me.txtIDPLACE2.Text = v_strIDPLACE
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub GetAvlWithdrawSubAccount()
        Dim v_strObjMsg, v_strCmdSQL, v_strClause, v_strAFACCTNO, v_strValue, v_strFLDNAME As String
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            For i As Integer = 0 To AccountGrid.DataRows.Count - 1

                v_strCmdSQL = "INQUIRYACCOUNT"
                v_strClause = "f_TABLENAME!" & "CIMAST" & "!varchar2!20^f_ACCTNO!" & AccountGrid.DataRows(i).Cells("AFACCTNO").Value.ToString & "!varchar2!20^f_INDATE!" & mv_strBusDate & "!varchar2!20^f_TYPE!" & "U" & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For j As Integer = 0 To v_nodeList.Count - 1
                    For k As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                        With v_nodeList.Item(j).ChildNodes(k)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "BALDEFOVD"
                                    If v_strValue = Nothing Or v_strValue = "" Then
                                        v_strValue = "0"
                                    End If
                                    AccountGrid.DataRows(i).Cells("AVLAFAMT").Value = CDbl(v_strValue)
                            End Select
                        End With
                    Next
                Next

            Next


            For m As Integer = 0 To AccountGrid.DataRows.Count - 1
                If AccountGrid.DataRows(m).Cells("AVLAFAMT").Value > 0 Then
                    AccountGrid.DataRows(m).Cells("AFAMT").BackColor = Color.White
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub AllocateWithdrawAmount()
        Try

            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                If AccountGrid.DataRows(i).Cells("STATUS").Value = "A" OrElse mv_blnView Then
                    AccountGrid.DataRows(i).Cells("AFAMT").Value = Math.Floor(Math.Max(Math.Min(AccountGrid.DataRows(i).Cells("AFAMT").Value, Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0)), 0))
                Else
                    AccountGrid.DataRows(i).Cells("AFAMT").Value = 0.0
                End If
            Next
            Me.txtAMT.Text = "0"
            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                Me.txtAMT.Text = CDbl(Me.txtAMT.Text) + AccountGrid.DataRows(i).Cells("AFAMT").Value
            Next
            Me.txtREMAINAMT.Text = (CDbl(Me.txtAVAILAMT.Text) - CDbl(Me.txtAMT.Text)).ToString

            If Me.txtDESC.Text = String.Empty Then
                Select Case Me.Tltxcd
                    Case gc_CI_CASH_WITHDRAWN
                        Me.txtDESC.Text = mv_ResourceManager.GetString("WITHDRAWN_DESC")
                    Case gc_CI_TRANSFER2BANK
                        Me.txtDESC.Text = mv_ResourceManager.GetString("TRANSFER2BANK_DESC")
                    Case gc_CI_INTERNALTRANSFER
                        Me.txtDESC.Text = mv_ResourceManager.GetString("INTERNALTRANSFER_DESC")
                End Select
            End If

            FeeCalc()
            FormatText()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormatText()
        Try
            txtAVAILAMT.Text = FormatNumber(IIf(txtAVAILAMT.Text = String.Empty, "0", txtAVAILAMT.Text), 0, TriState.True, TriState.True, TriState.True)
            txtREMAINAMT.Text = FormatNumber(IIf(txtREMAINAMT.Text = String.Empty, "0", txtREMAINAMT.Text), 0, TriState.True, TriState.True, TriState.True)
            txtAMT.Text = FormatNumber(IIf(txtAMT.Text = String.Empty, "0", txtAMT.Text), 0, TriState.True, TriState.True, TriState.True)
            txtETAMT.Text = FormatNumber(IIf(txtETAMT.Text = String.Empty, "0", txtETAMT.Text), 0, TriState.True, TriState.True, TriState.True)
            txtFEEAMT.Text = FormatNumber(IIf(txtFEEAMT.Text = String.Empty, "0", txtFEEAMT.Text), 0, TriState.True, TriState.True, TriState.True)
            txtVATAMT.Text = FormatNumber(IIf(txtFEEAMT.Text = String.Empty, "0", txtVATAMT.Text), 0, TriState.True, TriState.True, TriState.True)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadScreen(ByVal strTLTXCD As String, _
                Optional ByVal v_blnChain As Boolean = False, _
                Optional ByVal v_blnData As Boolean = False, _
                Optional ByVal v_strXML As String = vbNullString)
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String, i, j, m, n As Integer, v_objField As CFieldMaster, v_objFieldVal As CFieldVal
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, _
            v_strChainName, v_strLookupName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, v_strSearchCode, v_strSrModCode As String
        Dim v_intOdrNum, v_intFldLen, v_intIndex As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean

        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
            If Len(Me.ModuleCode) > 0 Then
                v_strSQL = "SELECT TX.* FROM TLTX TX, APPMODULES APP WHERE SUBSTR(TX.TLTXCD,1,2)=APP.TXCODE " _
                    & "AND UPPER(TX.TLTXCD) = '" & strTLTXCD & "' " _
                    & "AND UPPER(APP.MODCODE) = '" & Me.ModuleCode & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
            Else
                v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            End If
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
                Exit Sub
            End If

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = Trim(v_strValue)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSrModCode = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
                        End Select
                    End With
                Next

                v_objField = New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .LookupName = v_strLookupName
                    If v_strDefName = "DESC" And Len(v_strDefVal) = 0 Then
                        'Xá»­ lÃ½ cho trÆ°á»?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°á»?ng nÃ y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiáº¿t)
                    End If
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .InvName = v_strInvName
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSrModCode
                    .FieldValue = String.Empty
                End With
                mv_arrObjFields(i) = v_objField
            Next
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°á»?ng giao dá»‹ch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan trá»?ng khÃ´ng sá»­a
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)
            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg As String

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°á»?ng cá»§a giao dá»‹ch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldVal_FldName = Trim(v_strValue)
                            Case "VALTYPE"
                                v_strFieldVal_ValType = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strFieldVal_Operator = Trim(v_strValue)
                            Case "VALEXP"
                                v_strFieldVal_ValExp = Trim(v_strValue)
                            Case "VALEXP2"
                                v_strFieldVal_ValExp2 = Trim(v_strValue)
                            Case "ERRMSG"
                                v_strFieldVal_ErrMsg = Trim(v_strValue)
                            Case "EN_ERRMSG"
                                v_strFieldVal_EnErrMsg = Trim(v_strValue)
                        End Select
                    End With
                Next

                'XÃ¡c Ä‘á»‹nh index cá»§a máº£ng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                'Ä?iá»?u kiá»‡n xá»­ lÃ½
                v_objFieldVal = New CFieldVal
                With v_objFieldVal
                    .OBJNAME = strTLTXCD
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .IDXFLD = v_intIndex
                End With
                mv_arrObjFldVals(i) = v_objFieldVal
            Next
            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FeeCalc()
        Dim v_dblSumFee, v_dblSumVAT, v_dblItemFee, v_dblItemVAT, v_dblSumAmt As Double
        Try
            If cboIORO.SelectedValue <> "0" Then

                For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                    'Tinh phi tung tieu khoan
                    If CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) <> 0 Then
                        v_dblItemFee = Math.Max(IIf(mv_strFORP = "F", mv_dblFEEAMT, CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) * mv_dblFEERATE), mv_dblMINVAL)
                        If mv_dblMAXVAL <> 0 Then
                            v_dblItemFee = Math.Min(v_dblItemFee, mv_dblMAXVAL)
                        End If
                        AccountGrid.DataRows(i).Cells("FEEAMT").Value = Math.Round(v_dblItemFee, 0)
                        v_dblItemFee = 0

                        'Tinh VAT tung tieu khoan
                        v_dblItemVAT = CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) * mv_dblVATRATE
                        AccountGrid.DataRows(i).Cells("VATAMT").Value = Math.Round(v_dblItemVAT, 0)
                        v_dblItemVAT = 0

                        'Neu phi + so tien >  so tien kha dung tren tung tieu khoan. -> set lai gia tri = availble - (fee+vat).
                        If CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value) > Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0) Then
                            AccountGrid.DataRows(i).Cells("AFAMT").Value = Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0) - (CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value))
                            FeeCalc()
                        End If
                    End If
                Next
                'Cap nhat gia tri tong
                v_dblSumAmt = 0
                For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                    v_dblSumAmt = v_dblSumAmt + CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value)
                    v_dblSumFee = v_dblSumFee + CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value)
                    v_dblSumVAT = v_dblSumVAT + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value)
                Next
                Me.txtETAMT.Text = FormatNumber(v_dblSumAmt, 0)
                'Cap nhat gia tri phi & VAT.
                Me.txtFEEAMT.Text = FormatNumber(Math.Round(v_dblSumFee, 0))
                Me.txtVATAMT.Text = FormatNumber(Math.Round(v_dblSumVAT, 0))
            Else
                For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                    'Tinh phi tung tieu khoan
                    If CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) <> 0 Then
                        v_dblItemFee = Math.Max(IIf(mv_strFORP = "F", mv_dblFEEAMT, CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) * mv_dblFEERATE), mv_dblMINVAL)
                        If mv_dblMAXVAL <> 0 Then
                            v_dblItemFee = Math.Min(v_dblItemFee, mv_dblMAXVAL)
                        End If
                        AccountGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                        AccountGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                        v_dblItemVAT = 0

                        'Neu phi + so tien >  so tien kha dung tren tung tieu khoan. -> set lai gia tri = availble - (fee+vat).
                        If CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value) > Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0) Then
                            AccountGrid.DataRows(i).Cells("AFAMT").Value = Math.Max(CDbl(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value), 0) - (CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value) + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value))
                            FeeCalc()
                        End If
                    End If
                Next
                'Cap nhat gia tri tong
                v_dblSumAmt = 0
                For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                    v_dblSumAmt = v_dblSumAmt + CDbl(AccountGrid.DataRows(i).Cells("AFAMT").Value)
                    v_dblSumFee = v_dblSumFee + CDbl(AccountGrid.DataRows(i).Cells("FEEAMT").Value)
                    v_dblSumVAT = v_dblSumVAT + CDbl(AccountGrid.DataRows(i).Cells("VATAMT").Value)
                Next
                Me.txtETAMT.Text = FormatNumber(v_dblSumAmt, 0)
                'Cap nhat gia tri phi & VAT.
                Me.txtFEEAMT.Text = FormatNumber(Math.Round(v_dblSumFee, 0))
                Me.txtVATAMT.Text = FormatNumber(Math.Round(v_dblSumVAT, 0))
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function VerifyRules(ByRef v_strTxMsg As String, ByVal v_intRow As Integer) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            LoadScreen(Me.Tltxcd)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, Me.Tltxcd, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                Select Case Me.Tltxcd
                    Case gc_CI_CASH_WITHDRAWN
                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)
                                    Case "03" 'ACCTNO   
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFACCTNO").Value
                                    Case "10" 'AMT      
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFAMT").Value
                                    Case "30" 'DESC     
                                        v_strFLDVALUE = "[" & Me.txtREFID.Text & "]" & Me.txtDESC.Text
                                    Case "88" 'CUSTODYCD
                                        v_strFLDVALUE = Me.txtCUSTODYCD.Text
                                    Case "89" 'AVLCASH  
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AVLAFAMT").Value
                                    Case "90" 'CUSTNAME chu tai khoan
                                        v_strFLDVALUE = Me.lblFULLNAME.Text
                                    Case "91" 'ADDRESS  
                                        v_strFLDVALUE = Me.txtADDRESS.Text
                                    Case "92" 'LICENSE  
                                        v_strFLDVALUE = Me.txtIDCODE.Text
                                    Case "95" 'FULLNAME  
                                        v_strFLDVALUE = Me.txtRQSNAME.Text
                                    Case "98" 'IDDATE  
                                        v_strFLDVALUE = Me.txtIDDATE.Text
                                    Case "99" 'IDPLACE  
                                        v_strFLDVALUE = Me.txtIDPLACE.Text
                                    Case "79" 'REFID  
                                        v_strFLDVALUE = Me.txtREFID.Text
                                End Select

                                'Append entry to data node
                                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                v_attrFLDNAME.Value = v_strFLDNAME
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                v_attrDATATYPE.Value = v_strDATATYPE
                                v_entryNode.Attributes.Append(v_attrDATATYPE)

                                'Set value
                                v_entryNode.InnerText = v_strFLDVALUE
                                v_dataElement.AppendChild(v_entryNode)

                                'Remember account field
                                If UCase(v_strFLDNAME) = "03" Then
                                    Clipboard.SetDataObject(v_strFLDVALUE)
                                End If
                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                    Case gc_CI_TRANSFER2BANK

                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)
                                    Case "03" 'ACCTNO       
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFACCTNO").Value
                                    Case "05" 'BANKID       
                                        v_strFLDVALUE = ""
                                    Case "09" 'IORO       
                                        v_strFLDVALUE = cboIORO.SelectedValue
                                    Case "10" 'AMT          
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFAMT").Value
                                    Case "11" 'FEEAMT          
                                        v_strFLDVALUE = IIf(cboIORO.SelectedValue = "0", 0, AccountGrid.DataRows(v_intRow).Cells("FEEAMT").Value)
                                    Case "12" 'VATAMT          
                                        v_strFLDVALUE = IIf(cboIORO.SelectedValue = "0", 0, AccountGrid.DataRows(v_intRow).Cells("VATAMT").Value)
                                    Case "13" 'TRFAMT          
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFAMT").Value + AccountGrid.DataRows(v_intRow).Cells("FEEAMT").Value + AccountGrid.DataRows(v_intRow).Cells("VATAMT").Value
                                    Case "30" 'DESC         
                                        v_strFLDVALUE = "[" & Me.txtREFID.Text & "]" & Me.txtDESC.Text
                                    Case "66" '$FEECD          
                                        v_strFLDVALUE = Me.txtFEECD.Text
                                    Case "80" 'BENEFBANK       
                                        v_strFLDVALUE = Me.txtBENEFBANK.Text
                                    Case "81" 'BENEFACCT       
                                        v_strFLDVALUE = Me.txtBENEFACCT.Text
                                    Case "82" 'BENEFCUSTNAME   
                                        v_strFLDVALUE = Me.txtBENEFCUSTNAME.Text
                                    Case "88" 'CUSTODYCD       
                                        v_strFLDVALUE = Me.txtCUSTODYCD.Text
                                    Case "89" 'CASTBAL         
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AVLAFAMT").Value
                                    Case "90" 'CUSTNAME       
                                        v_strFLDVALUE = Me.lblFULLNAME.Text
                                    Case "95" 'FULLNAME        
                                        v_strFLDVALUE = Me.txtRQSNAME.Text
                                    Case "96" 'ADDRESS         
                                        v_strFLDVALUE = Me.txtADDRESS.Text
                                    Case "97" 'LICENSE        
                                        v_strFLDVALUE = Me.txtIDCODE.Text
                                    Case "98" 'IDDATE         
                                        v_strFLDVALUE = Me.txtIDDATE.Text
                                    Case "99" 'IDPLACE         
                                        v_strFLDVALUE = Me.txtIDPLACE.Text
                                    Case "79" 'REFID  
                                        v_strFLDVALUE = Me.txtREFID.Text
                                End Select

                                'Append entry to data node
                                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                v_attrFLDNAME.Value = v_strFLDNAME
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                v_attrDATATYPE.Value = v_strDATATYPE
                                v_entryNode.Attributes.Append(v_attrDATATYPE)

                                'Set value
                                v_entryNode.InnerText = v_strFLDVALUE
                                v_dataElement.AppendChild(v_entryNode)

                                'Remember account field
                                If UCase(v_strFLDNAME) = "03" Then
                                    Clipboard.SetDataObject(v_strFLDVALUE)
                                End If
                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                    Case "1120"
                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)
                                    Case "03" 'DACCTNO    
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFACCTNO").Value
                                    Case "05" 'CACCTNO   
                                        v_strFLDVALUE = mv_arrAFACCTNO(Me.cboAFACCTNO2.SelectedIndex)
                                    Case "10" 'AMT 
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AFAMT").Value
                                    Case "30" 'DESC     
                                        v_strFLDVALUE = "[" & Me.txtREFID.Text & "]" & Me.txtDESC.Text
                                    Case "31" 'FULLNAME 
                                        v_strFLDVALUE = Me.txtRQSNAME.Text
                                    Case "87" 'CASTBAL  
                                        v_strFLDVALUE = AccountGrid.DataRows(v_intRow).Cells("AVLAFAMT").Value
                                    Case "88" 'CUSTODYCD
                                        v_strFLDVALUE = Me.txtCUSTODYCD.Text
                                    Case "89" 'CUSTODYCD
                                        v_strFLDVALUE = Me.txtCUSTODYCD2.Text
                                    Case "90" 'CUSTNAME 
                                        v_strFLDVALUE = Me.lblFULLNAME.Text
                                    Case "91" 'ADDRESS  
                                        v_strFLDVALUE = Me.txtADDRESS.Text
                                    Case "92" 'LICENSE  
                                        v_strFLDVALUE = Me.txtIDCODE.Text
                                    Case "93" 'CUSTNAME2
                                        v_strFLDVALUE = Me.lblFULLNAME2.Text
                                    Case "94" 'ADDRESS2 
                                        v_strFLDVALUE = Me.txtADDRESS2.Text
                                    Case "95" 'LICENSE2 
                                        v_strFLDVALUE = Me.txtIDCODE2.Text
                                    Case "96" 'IDDATE   
                                        v_strFLDVALUE = Me.txtIDDATE.Text
                                    Case "97" 'IDPLACE  
                                        v_strFLDVALUE = Me.txtIDPLACE.Text
                                    Case "98" 'IDDATE2  
                                        v_strFLDVALUE = Me.txtIDDATE2.Text
                                    Case "99" 'IDPLACE2 
                                        v_strFLDVALUE = Me.txtIDPLACE2.Text
                                    Case "79" 'REFID  
                                        v_strFLDVALUE = Me.txtREFID.Text
                                End Select

                                'Append entry to data node
                                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                v_attrFLDNAME.Value = v_strFLDNAME
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                v_attrDATATYPE.Value = v_strDATATYPE
                                v_entryNode.Attributes.Append(v_attrDATATYPE)

                                'Set value
                                v_entryNode.InnerText = v_strFLDVALUE
                                v_dataElement.AppendChild(v_entryNode)

                                'Remember account field
                                If UCase(v_strFLDNAME) = "03" Then
                                    Clipboard.SetDataObject(v_strFLDVALUE)
                                End If
                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                End Select
            End If
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub txtAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAMT.Validating
        Dim v_dblRemainQtty As Double = 0
        Try
            If Not IsNumeric(Me.txtAMT.Text) Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_NUMERIC"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtAMT.Text = Me.txtAVAILAMT.Text
            End If
            If Me.txtAMT.Text = String.Empty Then
                Me.txtAMT.Text = "0"
            Else
                Me.txtAMT.Text = Math.Round(CDbl(Me.txtAMT.Text))
            End If
            Me.txtREMAINAMT.Text = CDbl(Me.txtAVAILAMT.Text) - CDbl(Me.txtAMT.Text)
            v_dblRemainQtty = CDbl(Me.txtAMT.Text)

            For i As Integer = 0 To AccountGrid.DataRows.Count - 1
                AccountGrid.DataRows(i).Cells("AFAMT").Value = Math.Min(v_dblRemainQtty, Math.Max(AccountGrid.DataRows(i).Cells("AVLAFAMT").Value, 0))
                v_dblRemainQtty = v_dblRemainQtty - AccountGrid.DataRows(i).Cells("AFAMT").Value
            Next

            AllocateWithdrawAmount()
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmTransactEx_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                If Me.txtCUSTODYCD.Focused And Me.txtCUSTODYCD.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_TX"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.GroupCareBy = True
                    frm.CareByFilter = True
                    frm.ShowDialog()
                    Me.txtCUSTODYCD.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                ElseIf Me.txtCUSTODYCD2.Focused And Me.txtCUSTODYCD2.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_TX"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.GroupCareBy = True
                    frm.CareByFilter = True
                    frm.ShowDialog()
                    Me.txtCUSTODYCD2.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                ElseIf Me.txtFEECD.Focused Then
                    Dim v_intPos As Integer
                    Dim frm As New frmLookUp(UserLanguage)
                    frm.IsLocalSearch = gc_IsLocalMsg

                    frm.SQLCMD = "SELECT FEECD VALUECD, FEECD VALUE, FEENAME DISPLAY, FEENAME EN_DISPLAY, FEENAME DESCRIPTION FROM FEEMASTER WHERE FEECD IN (SELECT DISTINCT FEECD FROM FEEMAP WHERE TLTXCD='" & Me.Tltxcd & "')"
                    frm.ShowDialog()
                    If Not frm.RETURNDATA Is Nothing Then
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            Me.txtFEECD.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                        End If
                        frm.Dispose()
                    End If

                ElseIf Me.txtREFID.Focused Then
                    Dim v_intPos As Integer
                    Dim frm As New frmLookUp(UserLanguage)
                    frm.IsLocalSearch = gc_IsNotLocalMsg

                    frm.SQLCMD = "SELECT DISTINCT ci.REF valuecd, ci.REF value, 'TK:' || cf.custodycd  || ' -' || ci.txdesc  display, 'TK:' || cf.custodycd  || ' -' || ci.txdesc en_display, 'TK:' || cf.custodycd  || ' -' || ci.txdesc description " & ControlChars.CrLf _
                        & "FROM cicustwithdraw ci, afmast af , cfmast cf, tllog tl " & ControlChars.CrLf _
                        & "WHERE ci.afacctno = af.acctno And af.custid = cf.custid And tl.txnum = ci.txnum and tl.txdate = ci.txdate " & ControlChars.CrLf _
                        & "AND tl.tltxcd = '" & Me.Tltxcd & "'"

                    frm.ShowDialog()
                    If Not frm.RETURNDATA Is Nothing Then
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            Me.txtREFID.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            If Me.txtREFID.Text <> String.Empty Then
                                mv_blnView = True
                                mv_blnFirstLoad = True
                                LoadTransactInfo(Me.txtREFID.Text)
                            End If
                        End If
                        frm.Dispose()
                    End If
                End If
            Case Keys.Enter
                SendKeys.Send("{Tab}")
                e.Handled = True
        End Select
    End Sub

    Private Sub frmTransactEx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim v_strObjMsg, v_strCmdSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Me.grbInternalTransfer.Location = New Point(19, 149)
        Me.grbExternalTransfer.Location = New Point(19, 149)
        If Me.Tltxcd = "1100" Then
            Me.Text = mv_ResourceManager.GetString("WITHDRAWN_DESC").ToString
            Me.grbInternalTransfer.Visible = False
            Me.grbExternalTransfer.Visible = False
            Me.scrMain.SplitterDistance = 155
        ElseIf Me.Tltxcd = "1101" Then
            Me.Text = mv_ResourceManager.GetString("TRANSFER2BANK_DESC").ToString
            Me.grbInternalTransfer.Visible = False
            Me.grbExternalTransfer.Visible = True
            Me.scrMain.SplitterDistance = 248
            'Load cboIORO
            v_strCmdSQL = "SELECT A.CDVAL VALUE, A.CDCONTENT DISPLAY, A.EN_CDCONTENT EN_DISPLAY FROM ALLCODE A WHERE A.CDTYPE='SA' AND A.CDNAME='IOROFEE' ORDER BY A.LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboIORO, "", Me.UserLanguage)
            If Me.cboIORO.Items.Count > 0 Then
                Me.cboIORO.SelectedIndex = 0
            End If

        ElseIf Me.Tltxcd = "1120" Then
            Me.Text = mv_ResourceManager.GetString("INTERNALTRANSFER_DESC").ToString
            Me.grbInternalTransfer.Visible = True
            Me.grbExternalTransfer.Visible = False
            Me.scrMain.SplitterDistance = 248
        End If
        Me.txtCUSTODYCD.SelectionStart = Me.txtCUSTODYCD.Text.Trim.Length
        Me.txtCUSTODYCD.Focus()
    End Sub

    Private Sub txtCUSTODYCD2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD2.Validating
        Me.txtCUSTODYCD2.Text = Me.txtCUSTODYCD2.Text.ToUpper

        Dim v_strSEARCHVALUE As String
        Try
            v_strSEARCHVALUE = txtCUSTODYCD2.Text.ToUpper
            GetCustomerSubAccount2(v_strSEARCHVALUE)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboIORO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIORO.SelectedIndexChanged
        Try
            If Me.Tltxcd = "1101" Then
                FeeCalc()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFEECD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFEECD.Validating
        Dim v_strSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim mv_xmlCUSTOMER As XmlDocumentEx
        Dim v_nodeList As XmlNodeList
        Dim v_lngCount As Long

        Try
            'Lay thong tin bieu phi.
            If Me.txtFEECD.Text.Trim <> String.Empty Then
                v_strSQL = "SELECT forp, feeamt, feerate, minval, maxval, vatrate FROM feemaster where feecd = '" & Me.txtFEECD.Text.Trim & "' "

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                mv_xmlCUSTOMER = New XmlDocumentEx
                mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
                If Not mv_xmlCUSTOMER Is Nothing Then
                    v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                    v_lngCount = v_nodeList.Count
                    If v_lngCount = 0 Then
                        Me.txtFEECD.Text = String.Empty
                        mv_strFORP = String.Empty
                        mv_dblFEEAMT = 0
                        mv_dblFEERATE = 0
                        mv_dblMINVAL = 0
                        mv_dblMAXVAL = 0
                        mv_dblVATRATE = 0
                    End If
                    For i As Integer = 0 To v_lngCount - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FORP" Then
                                    mv_strFORP = .InnerText.ToString
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FEEAMT" Then
                                    mv_dblFEEAMT = CDbl(.InnerText.ToString)
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FEERATE" Then
                                    mv_dblFEERATE = CDbl(.InnerText.ToString) / 100
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MINVAL" Then
                                    mv_dblMINVAL = CDbl(.InnerText.ToString)
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAXVAL" Then
                                    mv_dblMAXVAL = CDbl(.InnerText.ToString)
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VATRATE" Then
                                    mv_dblVATRATE = CDbl(.InnerText.ToString) / 100
                                End If
                            End With
                        Next
                    Next
                Else
                    Me.txtFEECD.Text = String.Empty
                    mv_strFORP = String.Empty
                    mv_dblFEEAMT = 0
                    mv_dblFEERATE = 0
                    mv_dblMINVAL = 0
                    mv_dblMAXVAL = 0
                    mv_dblVATRATE = 0
                End If
            End If
            'Tinh toan thong tin bieu phi.
            If Me.Tltxcd = "1101" Then
                FeeCalc()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblREFID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lblREFID.Validating
        Dim v_strSQL As String
        Try
            Select Case Me.Tltxcd
                Case gc_CI_CASH_WITHDRAWN
                Case gc_CI_INTERNALTRANSFER
                Case gc_CI_TRANSFER2BANK

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSubPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubPrint.Click
        Try
            Select Case Me.Tltxcd
                Case gc_CI_CASH_WITHDRAWN
                    SubPrintTransact("WDRLCSUBCUST")
                Case gc_CI_INTERNALTRANSFER
                    SubPrintTransact("TRANFCSUBCUST")
                Case gc_CI_TRANSFER2BANK
                    SubPrintTransact("TRANFCSUBCUST")

            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class