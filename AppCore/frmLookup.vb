Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports DevExpress.XtraGrid.Columns

Public Class frmLookUp
    Inherits System.Windows.Forms.Form
    'Public v_dtgLookupData As New GridEx

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmLookup-"
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
    Private mv_strIsLocalSearch As String

#End Region

#Region " Properties "
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
        Me.pnLookup.SuspendLayout()
        CType(Me.grcLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(424, 375)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(508, 375)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 23)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnLookup
        '
        Me.pnLookup.BackColor = System.Drawing.SystemColors.Control
        Me.pnLookup.Controls.Add(Me.grcLookup)
        Me.pnLookup.Location = New System.Drawing.Point(6, 8)
        Me.pnLookup.Name = "pnLookup"
        Me.pnLookup.Size = New System.Drawing.Size(582, 361)
        Me.pnLookup.TabIndex = 5
        '
        'grcLookup
        '
        Me.grcLookup.Cursor = System.Windows.Forms.Cursors.Default
        Me.grcLookup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grcLookup.Location = New System.Drawing.Point(0, 0)
        Me.grcLookup.MainView = Me.grvLookup
        Me.grcLookup.Name = "grcLookup"
        Me.grcLookup.Size = New System.Drawing.Size(582, 361)
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
        '
        'frmLookUp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(594, 405)
        Me.Controls.Add(Me.pnLookup)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLookUp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLookup"
        Me.TopMost = True
        Me.pnLookup.ResumeLayout(False)
        CType(Me.grcLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvLookup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        'Nạp dữ liệu hiển thị thông tin tra cứu
        'If Len(Trim(SQLCMD)) > 0 Then
        LoadLookupData()
        'End If

    End Function

    Private Sub LoadLookupData()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String

        Try
            'Create message to inquiry object fields
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v�? giao dịch
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

            'Lưu trữ danh sách tìm kiếm trả v�?
            FULLDATA = v_strObjMsg

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim i, j As Integer

            'Hiển thị toàn bộ nội dung của dữ liệu tìm kiếm trả v�?
            If v_nodeList.Count > 0 Then
                'Tạo Header của Grid
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
                                gridColumn.Width = 1.5 * WIDTH_GRID_LOOKUP / 10
                                If UserLanguage <> "EN" Then
                                    gridColumn.Caption = mv_ResourceManager.GetString("VALUECD")
                                End If
                            Case "DESCRIPTION"
                                gridColumn.Width = 3 * WIDTH_GRID_LOOKUP / 10
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
                '    'Dùng để trả v�? giá trị RETURNDATA cho form lookup
                '    v_xDataRow.Cells("VALUE").Value = v_strTEXT
                '    v_xDataRow.EndEdit()
                'Next
                'v_dtgLookupData.EndInit()
                'Me.pnLookup.Controls.Add(v_dtgLookupData)

                ''Tự động đóng màn hình nếu chỉ có 01 bản ghi và AutoClosed=True
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
        Me.Close()
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
        Me.Close()

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
End Class
