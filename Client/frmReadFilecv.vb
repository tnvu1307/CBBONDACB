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
Imports System.Data.OleDb




Public Class frmReadFilecv
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


#Region "Property"
    Const c_ResourceManager = "AppCore.frmReceiverData-"
    Private mv_strFileName As String
    Private mv_strSaveTableName As String
    Private mv_strOVRRQD As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_strIsLocalSearch As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strAuthCode As String
    Private mv_strRPTID As String
    Private mv_strMODCODE As String

    Private mv_strBusDate As String
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnExpTrans As System.Windows.Forms.Button
    Private mv_strTellerID As String
    Private mv_strBranchId As String
    Private mv_strIpAddress As String
    Friend WithEvents btnread As System.Windows.Forms.Button
    Friend WithEvents btnimport As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents timersearh As System.Windows.Forms.Timer
    Private mv_strWsName As String

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
    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadFilecv))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.cboFileType = New AppCore.ComboBoxEx
        Me.lblFileType = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblBrowse = New System.Windows.Forms.Label
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grbSearchResult = New System.Windows.Forms.GroupBox
        Me.pnlSearchResult = New System.Windows.Forms.Panel
        Me.grbButton = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnimport = New System.Windows.Forms.Button
        Me.btnread = New System.Windows.Forms.Button
        Me.btnExpTrans = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLoadData = New System.Windows.Forms.Button
        Me.timersearh = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.grbButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.cboFileType)
        Me.GroupBox1.Controls.Add(Me.lblFileType)
        Me.GroupBox1.Controls.Add(Me.lblPath)
        Me.GroupBox1.Controls.Add(Me.lblBrowse)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(744, 48)
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
        Me.cboFileType.Size = New System.Drawing.Size(280, 21)
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
        Me.lblFileType.Size = New System.Drawing.Size(280, 23)
        Me.lblFileType.TabIndex = 4
        Me.lblFileType.Text = "Loại file"
        '
        'lblPath
        '
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.Red
        Me.lblPath.Location = New System.Drawing.Point(288, 24)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(456, 23)
        Me.lblPath.TabIndex = 3
        Me.lblPath.Text = "Đường dẫn"
        '
        'lblBrowse
        '
        Me.lblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowse.ForeColor = System.Drawing.Color.Red
        Me.lblBrowse.Location = New System.Drawing.Point(744, 24)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(56, 23)
        Me.lblBrowse.TabIndex = 2
        Me.lblBrowse.Text = "Chọn"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(288, 48)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(456, 20)
        Me.txtPath.TabIndex = 1
        Me.txtPath.Text = "TextBox2"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grbSearchResult)
        Me.Panel1.Location = New System.Drawing.Point(8, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(808, 408)
        Me.Panel1.TabIndex = 1
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(0, 0)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(808, 408)
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
        Me.pnlSearchResult.Size = New System.Drawing.Size(802, 388)
        Me.pnlSearchResult.TabIndex = 0
        '
        'grbButton
        '
        Me.grbButton.Controls.Add(Me.btnClear)
        Me.grbButton.Controls.Add(Me.btnimport)
        Me.grbButton.Controls.Add(Me.btnread)
        Me.grbButton.Controls.Add(Me.btnExpTrans)
        Me.grbButton.Controls.Add(Me.btnExport)
        Me.grbButton.Controls.Add(Me.btnSave)
        Me.grbButton.Controls.Add(Me.btnCancel)
        Me.grbButton.Controls.Add(Me.btnLoadData)
        Me.grbButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbButton.Location = New System.Drawing.Point(0, 513)
        Me.grbButton.Name = "grbButton"
        Me.grbButton.Size = New System.Drawing.Size(824, 45)
        Me.grbButton.TabIndex = 26
        Me.grbButton.TabStop = False
        Me.grbButton.Tag = "grbButton"
        Me.grbButton.Text = "grbButton"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(116, 16)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 32
        Me.btnClear.Tag = "btnClear"
        Me.btnClear.Text = "Xóa"
        '
        'btnimport
        '
        Me.btnimport.Location = New System.Drawing.Point(278, 16)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(75, 23)
        Me.btnimport.TabIndex = 31
        Me.btnimport.Text = "Ghi"
        Me.btnimport.UseVisualStyleBackColor = True
        '
        'btnread
        '
        Me.btnread.Location = New System.Drawing.Point(197, 16)
        Me.btnread.Name = "btnread"
        Me.btnread.Size = New System.Drawing.Size(75, 23)
        Me.btnread.TabIndex = 30
        Me.btnread.Text = "Đọc file"
        Me.btnread.UseVisualStyleBackColor = True
        '
        'btnExpTrans
        '
        Me.btnExpTrans.Location = New System.Drawing.Point(6, 16)
        Me.btnExpTrans.Name = "btnExpTrans"
        Me.btnExpTrans.Size = New System.Drawing.Size(106, 23)
        Me.btnExpTrans.TabIndex = 29
        Me.btnExpTrans.Tag = "btnExpTrans"
        Me.btnExpTrans.Text = "btnExpTrans"
        Me.btnExpTrans.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(359, 16)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 28
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "Kết suất"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(656, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 26
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "btnSave"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(736, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnLoadData
        '
        Me.btnLoadData.Enabled = False
        Me.btnLoadData.Location = New System.Drawing.Point(576, 16)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 25
        Me.btnLoadData.Tag = "btnLoadData"
        Me.btnLoadData.Text = "btnLoadData"
        '
        'timersearh
        '
        Me.timersearh.Enabled = True
        Me.timersearh.Interval = 10000
        '
        'frmReadFilecv
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 558)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbButton)
        Me.KeyPreview = True
        Me.Name = "frmReadFilecv"
        Me.Text = "frmReadFilecv"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        Me.grbButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Function"
    Private Sub OnBrowser()
        Try

            Dim v_FOLDERDlg As New FolderBrowserDialog
            If v_FOLDERDlg.ShowDialog() = DialogResult.OK Then
                Me.txtPath.Text = v_FOLDERDlg.SelectedPath
            End If

            'Dim v_dlgOpen As New OpenFileDialog
            'v_dlgOpen.Filter = "Open files (*" & mv_strEXTENTION & ")|*" & mv_strEXTENTION & ""

            'Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            'If v_res = DialogResult.OK Then
            '    mv_srcFileName = v_dlgOpen.FileName
            '    Me.txtPath.Text = mv_srcFileName
            'End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmReadFilecv.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OnLoadData()
        Dim v_strOldCultureName As String = String.Empty
        Try
            If Me.txtPath.Text.Trim.Length = 0 Then
                MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
                Me.ActiveControl = Me.btnBrowse
                Exit Sub
            End If
            SearchGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
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

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)
            If xlWorkBook Is Nothing Then
                MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
                Me.ActiveControl = Me.btnBrowse
                Exit Sub
            End If


            Dim DS As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim datagrid1 As DataGrid

            ' MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='C:\Users\namnt\Desktop\bvs\Conver\CFMASTCV_HN.XLS'; Extended Properties=""Excel 8.0;HDR=NO;IMEX=1;""")

            'MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & "AAA" & " '; Extended Properties=""Excel 8.0;HDR=NO;IMEX=1;""")
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " & _
                     "data source='" & "C:\Users\namnt\Desktop\bvs\Conver\CFMAST_HN.XLS" & " '; " & "Extended Properties=""Excel 8.0;HDR=NO;IMEX=1;""")

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [DMKH$]", MyConnection)
            DS = New System.Data.DataSet
            MyCommand.Fill(DS)
            datagrid1.SetDataBinding(DS, "DMKH$")
            MyConnection.Close()

            'xlWorkSheet = xlWorkBook.Worksheets(mv_strSHEETNAME)
            xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

            range = xlWorkSheet.UsedRange
            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                For cCnt = 1 To range.Columns.Count
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                    SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value)
                    SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                    SearchGrid.Columns(cCnt.ToString).Width = 100
                Next
            End If
            SearchGrid.DataRows.Clear()
            SearchGrid.BeginInit()
            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                For rCnt = mv_intROWTITLE + 1 To DS.Tables(0).Rows.Count
                    Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                    For Each v_xColumn In SearchGrid.Columns
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                    Next
                    v_xDataRow.EndEdit()
                Next
            End If


            'If range.Rows.Count >= mv_intROWTITLE + 1 Then
            '    For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
            '        Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
            '        For Each v_xColumn In SearchGrid.Columns
            '            v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
            '        Next
            '        v_xDataRow.EndEdit()
            '    Next
            'End If
            'Dim v_xDataRow As Xceed.Grid.DataRow
            'If range.Rows.Count >= mv_intROWTITLE + 1 Then
            '    For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
            '        'Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
            '        v_xDataRow = SearchGrid.DataRows.AddNew()
            '        For Each v_xColumn In SearchGrid.Columns
            '            v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
            '        Next
            '    Next
            'End If
            'v_xDataRow.EndEdit()
            Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & range.Rows.Count - mv_intROWTITLE & " dòng!")
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            SearchGrid.FixedFooterRows.Clear()
            SearchGrid.FixedFooterRows.Add(v_frSearchGrid)


            SearchGrid.EndInit()
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            Me.pnlSearchResult.Controls.Clear()
            Me.pnlSearchResult.Controls.Add(SearchGrid)
            SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            'System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmReadFilecv.OnLoadData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Len(v_strOldCultureName) > 0 Then
                v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            End If
        End Try

        'Try
        '    If Me.txtPath.Text.Trim.Length = 0 Then
        '        MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
        '        Me.ActiveControl = Me.btnBrowse
        '        Exit Sub
        '    End If
        '    SearchGrid = New GridEx
        '    Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        '    v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        '    v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        '    SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        '    Dim xlApp As Excel.Application
        '    Dim xlWorkBook As Excel.Workbook
        '    Dim xlWorkSheet As Excel.Worksheet
        '    Dim range As Excel.Range
        '    Dim rCnt As Integer
        '    Dim cCnt As Integer
        '    Dim Obj As Object
        '    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        '    Dim v_strFunctionName As String = "ImportXMLFileToDBCV"
        '    Dim v_strSQL, v_strObjMsg, v_strValue, v_strClause As String
        '    ' Dim v_strBuffer As New System.Text.StringBuilder
        '    Dim v_strtitle, v_strBuffer, v_strdata As String

        '    mv_strObjName = "SA.READFILE"

        '    'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
        '    Dim oldCI As Globalization.CultureInfo
        '    oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        '    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        '    xlApp = New Excel.ApplicationClass
        '    xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)

        '    If xlWorkBook Is Nothing Then
        '        MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
        '        Me.ActiveControl = Me.btnBrowse
        '        Exit Sub
        '    End If
        '    'xlWorkSheet = xlWorkBook.Worksheets(mv_strSHEETNAME)
        '    xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

        '    range = xlWorkSheet.UsedRange
        '    If range.Columns.Count > 0 And range.Rows.Count > 1 Then
        '        For cCnt = 1 To range.Columns.Count
        '            SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
        '            SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value)
        '            SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        '            SearchGrid.Columns(cCnt.ToString).Width = 100
        '            'Gan title

        '            If Not gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value) Is DBNull.Value Then
        '                v_strValue = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value)
        '            Else
        '                v_strValue = ""
        '            End If
        '            v_strtitle = v_strtitle & v_strValue & "~"

        '        Next
        '        v_strtitle = v_strtitle & "|"
        '    End If
        '    SearchGrid.DataRows.Clear()
        '    SearchGrid.BeginInit()

        '    If range.Rows.Count >= mv_intROWTITLE + 1 Then
        '        For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
        '            '   Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
        '            'For Each v_xColumn In range.Columns
        '            For cCnt = 1 To range.Columns.Count
        '                '   range.Columns.Count
        '                ' v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
        '                'Gan title
        '                If Not gf_CorrectStringField(CType(range.Cells(rCnt, cCnt), Excel.Range).Value) Is DBNull.Value Then
        '                    v_strValue = gf_CorrectStringField(CType(range.Cells(rCnt, cCnt), Excel.Range).Value)
        '                Else
        '                    v_strValue = ""
        '                End If
        '                v_strdata = v_strdata & v_strValue & "~"

        '            Next
        '            v_strdata = v_strdata & "|"
        '            v_strClause = v_strtitle & v_strdata
        '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId Me.TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
        '                    gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
        '            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

        '            v_strdata = ""


        '        Next

        '    End If

        '    'Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & range.Rows.Count - mv_intROWTITLE & " dòng!")
        '    'v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        '    'v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        '    'SearchGrid.FixedFooterRows.Clear()
        '    'SearchGrid.FixedFooterRows.Add(v_frSearchGrid)


        '    'SearchGrid.EndInit()
        '    xlWorkBook.Close()
        '    xlApp.Quit()

        '    releaseObject(xlApp)
        '    releaseObject(xlWorkBook)
        '    releaseObject(xlWorkSheet)

        '    Me.pnlSearchResult.Controls.Clear()
        '    Me.pnlSearchResult.Controls.Add(SearchGrid)
        '    SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
        '    'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
        '    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        'Catch ex As Exception
        '    LogError.Write("Error source: @VSTP.frmReadFilecv.OnLoadData" & vbNewLine _
        '                 & "Error code: System error!" & vbNewLine _
        '                 & "Error message: " & ex.Message, EventLogEntryType.Error)
        '    MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

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
            Dim v_strFunctionName As String = "ImportXMLFileToDBCV"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage, v_strtitle As String
            Dim v_grid As New AppCore.GridEx
            If Not IsApprove Then
                v_grid = SearchGrid
            Else
                v_grid = ResultGrid
            End If
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            '   If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
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
                v_strtitle = v_strtitle & v_strValue & "~"
            Next
            v_strtitle = v_strtitle & "|"
            'Gan noi dung
            Dim i As Integer = 0
            Dim n As Integer = 0
            For k As Integer = 0 To 10
                v_strBuffer = v_strBuffer.Remove(0, v_strBuffer.Length)
                n = Math.Min((k + 1) * 10000, v_grid.DataRows.Count)
                If k * 10000 <= n Then
                    For i = k * 10000 To n - 1 'v_grid.DataRows.Count - 1
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
                    v_strClause = v_strtitle & v_strBuffer.ToString
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                            gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
                    Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                    'TruongLD Comment when convert
                    'v_ws.Dispose()
                    If v_lngError <> ERR_SYSTEM_OK Then

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                        MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Next

            Dim pv_xmlDocument As New Xml.XmlDocument
            pv_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            pv_xmlDocument = Nothing
            Cursor.Current = Cursors.Default
            'check error here
            'If v_strFeedBackMessage.Trim.Length = 0 Then
            '    MessageBox.Show("Ghi dữ liệu thành công", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            'LOAD LAI DU LIEU DA SAVE DE KIEM TRA
            'If mv_strSaveTableName.Length > 0 Then
            '    LoadSaveData(mv_strSaveTableName)
            'End If

            ' End If
        Catch ex As Exception
            LogError.Write("Error source: @VSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Oninit()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String


        m_BusLayer = New CBusLayer
        'btnSave.Enabled = True
        btnExpTrans.Enabled = False


        'Load combobox
        If IsApprove Then
            v_strCmdSQL = "SELECT filecode VALUE, filename DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='C' and OVRRQD='Y' ORDER BY filecode"
        Else
            v_strCmdSQL = "SELECT filecode VALUE, filename DISPLAY, filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' AND eori='C' " _
                          & " UNION ALL SELECT 'ALL' VALUE, 'ALL' DISPLAY, 'ALL' EN_DISPLAY, '0' LSTODR FROM DUAL ORDER BY LSTODR "
        End If

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboFileType, "", Me.UserLanguage)
        'Reset path
        Me.txtPath.Text = ""
        Me.grbSearchResult.Text = "Kết quả"
        Me.GroupBox1.Text = ""
        Me.grbButton.Text = ""
        Me.btnCancel.Text = "&Thoát"
        Me.btnLoadData.Text = "Đọc &dữ liệu"
        Me.btnExport.Text = "Kết xuất"
        Me.btnExpTrans.Text = "&Exp Transaction"

        If IsApprove Then
            Me.btnSave.Text = "Duyệt"
            'Form Caption
            Me.Text = "Duyệt đồng bộ số liệu"
            Me.txtPath.Enabled = False
            Me.btnBrowse.Enabled = False
        Else
            Me.btnSave.Text = "Ghi dữ liệu"
            'Form Caption
            Me.Text = "Đồng bộ số liệu"
        End If
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
            v_strCmdSQL = "SELECT * FROM filemaster WHERE filecode='" & pv_strFile & "' AND eori='C'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
            If mv_strRPTID <> "" Then
                'btnSave.Enabled = False
                btnExpTrans.Enabled = True
            Else
                ' btnSave.Enabled = True
                btnExpTrans.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadSaveData()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT typecv,description FROM  CONVERT_LOG"
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


                'For j As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                '    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                '    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                '    Select Case v_strFLDTYPE
                '        Case "System.String"
                '            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                '        Case "System.DateTime"
                '            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                '        Case Else
                '            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.Double)))
                '    End Select
                '    ResultGrid.Columns(v_strFLDNAME).Title = v_strFLDNAME


                'Next

                ResultGrid.Columns.Add(New Xceed.Grid.Column("TYPECV", GetType(System.String)))
                ResultGrid.Columns("TYPECV").Title = "TYPECV"
                ResultGrid.Columns("TYPECV").Width = 0


                ResultGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
                ResultGrid.Columns("DESCRIPTION").Title = "DESCRIPTION"
                ResultGrid.Columns("DESCRIPTION").Width = 900

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
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                            End Select
                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frResultGrid = New Xceed.Grid.TextRow("Kết quả đồng bộ dữ liệu " & v_nodeList.Count & " dòng!")
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                Me.pnlSearchResult.Controls.Clear()
                Me.pnlSearchResult.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Else

            End If
        Catch ex As Exception
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
            LoadSaveData()
        Else
            'Load du lieu tu file duong dan
            OnLoadData()
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        OnSave()
    End Sub

    Private Sub frmReadFilecv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Oninit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub cboFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged
        If Not Me.cboFileType.SelectedValue Is Nothing Then
            Dim v_strFile As String
            mv_strFileCode = Me.cboFileType.SelectedValue.ToString
            v_strFile = mv_strFileCode
            GetFileInfo(v_strFile)
        End If
    End Sub
#End Region


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strFunctionName As String = "EXPORTEXCELCV"
        Dim v_strClause, v_strErrorSource, v_strErrorMessage, v_strtitle As String
        mv_strObjName = "SA.READFILE"
        v_strClause = Me.txtPath.Text & "\"


        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Try


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                      gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)


            'Dim sql As String
            'Dim i, j As Integer

            'Dim xlApp As Excel.Application
            'Dim xlWorkBook As Excel.Workbook
            'Dim xlWorkSheet As Excel.Worksheet
            'Dim misValue As Object = System.Reflection.Missing.Value

            'xlApp = New Excel.ApplicationClass
            'xlWorkBook = xlApp.Workbooks.Add(misValue)
            'xlWorkSheet = xlWorkBook.Sheets("sheet1")

            'connectionString = "data source=servername;" & _
            '"initial catalog=databasename;user id=username;password=password;"
            'cnn = New SqlConnection(connectionString)
            'cnn.Open()
            'sql = "SELECT * FROM Product"
            'Dim dscmd As New SqlDataAdapter(sql, cnn)
            'Dim ds As New DataSet
            'dscmd.Fill(ds)

            'For i = 0 To ds.Tables(0).Rows.Count - 1
            '    For j = 0 To ds.Tables(0).Columns.Count - 1
            '        xlWorkSheet.Cells(i + 1, j + 1) = _
            '        ds.Tables(0).Rows(i).Item(j)
            '    Next
            'Next

            'xlWorkSheet.SaveAs("C:\vbexcel.xlsx")
            'xlWorkBook.Close()
            'xlApp.Quit()

            'releaseObject(xlApp)
            'releaseObject(xlWorkBook)
            'releaseObject(xlWorkSheet)







            'Dim v_dlgSave As New SaveFileDialog
            'v_dlgSave.Filter = "Excel files (*.xls)|*.xls|Text files (*.txt)|*.txt|All files (*.*)|*.*"
            'Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            'If v_res = DialogResult.OK Then
            '    v_strFileName = v_dlgSave.FileName
            '    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

            '    If (ResultGrid.DataRows.Count > 0) Then
            '        'Column header
            '        iColumn = 1
            '        For iY = 0 To ResultGrid.Columns.Count - 1
            '            If ResultGrid.Columns(iY).Visible Then
            '                v_strData &= ResultGrid.Columns(iY).Title & vbTab
            '                iColumn = iColumn + 1
            '            End If
            '        Next
            '        v_streamWriter.WriteLine(v_strData)

            '        'Data
            '        For iX = 0 To ResultGrid.DataRows.Count - 1
            '            v_strData = String.Empty
            '            iColumn = 1
            '            For iY = 0 To ResultGrid.Columns.Count - 1
            '                If ResultGrid.Columns(iY).Visible Then
            '                    v_strData &= ResultGrid.DataRows(iX).Cells(iY).Value.ToString & vbTab
            '                    iColumn = iColumn + 1
            '                End If
            '            Next
            '            v_streamWriter.WriteLine(v_strData)
            '        Next
            '    Else
            '        MsgBox("Không có dữ liệu để kết xuất", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '        Exit Sub
            '    End If

            '    'Close StreamWriter
            '    v_streamWriter.Close()

            '    MsgBox("Kết xuất dữ liệu hoàn tất", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmReadFilecv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub btnExpTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpTrans.Click
        'Liệt kê danh sách các View tra cứu được phép
        Dim frm As New AppCore.frmLookUp(m_BusLayer.AppLanguage)
        Dim v_intPos As Integer, ctl As Control, v_strRETURNDATA, v_strObjName, v_strModCode, v_strCMDTYPE As String

        Dim frmSearch As New frmSearchMaster(m_BusLayer.AppLanguage)
        frmSearch.BusDate = Me.BusDate
        frmSearch.TableName = mv_strRPTID
        frmSearch.ModuleCode = mv_strMODCODE
        frmSearch.TellerId = Me.TellerID
        '     frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
        frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
        'frmSearch.AuthCode = frm.AuthCode
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

    Private Sub btnread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnread.Click
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Try
                If Me.cboFileType.SelectedValue.ToString <> "ALL" Then
                    mv_srcFileName = Me.txtPath.Text & "\" & Replace(mv_strSaveTableName, "CV", "") & ".XLSX"
                    IMPORT_EXCEL_DATA()
                Else

                    v_strCmdSQL = "SELECT * FROM filemaster WHERE  EORI ='C' ORDER BY FILECODE "
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
                                        'Me.txtPath.Text = v_strValue
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
                                    Case "OVRRQD"
                                        mv_strOVRRQD = v_strValue
                                    Case "FILECODE"
                                        mv_strFileCode = v_strValue

                                End Select

                            End With
                        Next

                        '  If mv_strSaveTableName = "USERLOGINOLCV" Or mv_strSaveTableName = "CFOTHERACCCV" Or mv_strSaveTableName = "BD01CV" Or mv_strSaveTableName = "BD02CV" Or mv_strSaveTableName = "BD03CV" Or mv_strSaveTableName = "BD04CV" Or mv_strSaveTableName = "BD05CV" Or mv_strSaveTableName = "USERLOGINOL1CV" Then
                        mv_srcFileName = Me.txtPath.Text & "\" & Replace(mv_strSaveTableName, "CV", "") & ".XLSX"
                        IMPORT_EXCEL_DATA()

                        'Else
                        '    mv_srcFileName = Me.txtPath.Text & "\" & Replace(mv_strSaveTableName, "CV", "") & "_HN.XLS"
                        '    IMPORT_EXCEL_DATA()
                        '    mv_srcFileName = Me.txtPath.Text & "\" & Replace(mv_strSaveTableName, "CV", "") & "_HCM.XLS"
                        '    IMPORT_EXCEL_DATA()
                        'End If
                    Next

                End If
                MessageBox.Show("Ghi du lieu thanh cong")
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Private Sub btnimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimport.Click

        If (MessageBox.Show("Bạn muốn chuyển đổi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Try
                Cursor.Current = Cursors.WaitCursor
                Dim v_strFunctionName As String = "IMPTABLECV"
                Dim v_strClause, v_strErrorSource, v_strErrorMessage As String

                mv_strObjName = "SA.READFILE"
                'mv_strFileCode = mv_strFileCode
                '   If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder
                'Gan title

                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                'TruongLD Comment when convert
                'v_ws.Dispose()
                LoadSaveData()
                Dim pv_xmlDocument As New Xml.XmlDocument
                pv_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
                pv_xmlDocument = Nothing
                Cursor.Current = Cursors.Default
                'check error here

                ' End If
            Catch ex As Exception
                LogError.Write("Error source: @VSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & ex.Message, EventLogEntryType.Error)
                MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub IMPORT_EXCEL_DATA()
        mv_strObjName = "SA.READFILE"
        'mv_strFileCode = mv_strFileCode
        '   If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strFunctionName As String = "ImportXMLFileToDBCV"
        Dim v_strClause, v_strErrorSource, v_strErrorMessage, v_strtitle As String
        Dim DS As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        ' Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim datagrid1 As DataGrid
        Dim v_strBuffer As New System.Text.StringBuilder
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim cCnt As Integer


        'MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " & _
        '         "data source='" & mv_srcFileName & " '; " & "Extended Properties=""Excel 8.0;HDR=NO;IMEX=1;""")


        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mv_srcFileName & ";Extended Properties=Excel 12.0"

        Dim MyConnection As OleDbConnection = New OleDbConnection(connString)

        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
        DS = New System.Data.DataSet
        MyCommand.Fill(DS)

        MyConnection.Close()

        'Gan title

        For cCnt = 0 To DS.Tables(0).Columns.Count - 1
            If Not DS.Tables(0).Columns(cCnt).ColumnName Is DBNull.Value Then
                v_strValue = DS.Tables(0).Columns(cCnt).ColumnName
            Else
                v_strValue = ""
            End If
            v_strtitle = v_strtitle & v_strValue & "~"
        Next
        v_strtitle = v_strtitle & "|"

        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim n As Integer = 0
        For k As Integer = 0 To 10
            v_strBuffer = v_strBuffer.Remove(0, v_strBuffer.Length)
            n = Math.Min((k + 1) * 10000, DS.Tables(0).Rows.Count)
            If k * 10000 <= n Then
                For i = k * 10000 To n - 1 'v_grid.DataRows.Count - 1
                    If i >= 0 Then
                        With DS.Tables(0).Rows(i)
                            For j = 0 To DS.Tables(0).Columns.Count - 1

                                If Not .Item(j) Is DBNull.Value Then
                                    v_strValue = CStr(.Item(j))
                                Else
                                    v_strValue = ""
                                End If
                                v_strBuffer.Append("" & v_strValue & "~")
                            Next
                            v_strBuffer.Append("|")
                        End With
                    End If
                Next
                v_strClause = v_strtitle & v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                'TruongLD Comment when convert
                'v_ws.Dispose()
                If v_lngError <> ERR_SYSTEM_OK Then

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                    '  MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Next


        '' Modify the following code to correctly connect to your SQL Server.
        'sConnectionString = "Password=StrongPassword;User ID=UserName;" & _
        '                    "Initial Catalog=pubs;" & _
        '                    "Data Source=(local)"

        'Dim objConn As New SqlConnection(sConnectionString)
        'objConn.Open()

        '' Create an instance of a DataAdapter.
        'Dim daAuthors As New SqlDataAdapter("Select * From Authors", objConn)

        '' Create an instance of a DataSet, and retrieve data from the Authors table.
        'Dim dsPubs As New DataSet("Pubs")
        'daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors")
        'daAuthors.Fill(dsPubs, "Authors")


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        If (MessageBox.Show("Bạn có muốn xóa dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Try

                Cursor.Current = Cursors.WaitCursor
                Dim v_strFunctionName As String = "CLEARDATACV"
                Dim v_strClause, v_strErrorSource, v_strErrorMessage As String

                mv_strObjName = "SA.READFILE"
                'mv_strFileCode = mv_strFileCode
                'If (MessageBox.Show("Bạn có muốn xóa dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

                '  End If
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder
                'Gan title

                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(IsApprove, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                'TruongLD Comment when convert
                'v_ws.Dispose()

                Dim pv_xmlDocument As New Xml.XmlDocument
                pv_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
                pv_xmlDocument = Nothing
                Cursor.Current = Cursors.Default
                'check error here

                ' End If
            Catch ex As Exception
                LogError.Write("Error source: @VSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & ex.Message, EventLogEntryType.Error)
                MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If


    End Sub

    Private Sub timersearh_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timersearh.Tick
        LoadSaveData()
    End Sub
End Class
