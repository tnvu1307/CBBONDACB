Imports System.Xml
Imports CommonLibrary
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Filtering
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing
Imports System.Data

Public Module modXtraLib
    Private _refData As DataTable

    Property columnGridAllowVisable As String() = {"STT"}
    Private Property RefDataCache As DataTable
        Get
            '#If DEBUG Then
            ' Return Nothing
            '#End If
            If _refData Is Nothing Then
                _refData = New DataTable()
            End If

            Return _refData
        End Get
        Set(value As DataTable)
            _refData = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pv_xGridView"></param>
    ''' <param name="pv_strTable"></param>
    ''' <param name="pv_strResource"></param>
    ''' <param name="pv_blnFirst"></param>
    ''' <param name="pv_blnGroup"></param>
    ''' <param name="pv_intFromrow"></param>
    ''' <param name="pv_intTorow"></param>
    ''' <param name="pv_intTotalrow"></param>
    ''' <remarks></remarks>
    Public Sub FormatXtraGridBefore(ByRef pv_xGridView As GridView, _
                                 Optional ByVal pv_strTable As String = vbNullString, _
                                 Optional ByVal pv_strResource As String = vbNullString, _
                                 Optional ByVal pv_blnFirst As Boolean = True, _
                                 Optional ByVal pv_blnGroup As Boolean = True, _
                                 Optional ByVal pv_intFromrow As Int32 = 0, _
                                 Optional ByVal pv_intTorow As Int32 = 0, _
                                 Optional ByVal pv_intTotalrow As Int32 = 0)


    End Sub
    ''' <summary>
    ''' Format grid
    ''' </summary>
    ''' <param name="pv_xGridView"></param>
    ''' <param name="pv_strResource"></param>
    ''' <param name="mv_arrSrFieldSrch"></param>
    ''' <param name="mv_arrSrFieldFormat"></param>
    ''' <param name="pv_arrSrFieldWidth"></param>
    ''' <param name="pv_arrSrFieldCaption"></param>
    ''' <param name="pv_arrSrFieldVisibility"></param>
    ''' <remarks></remarks>
    Public Sub XtraGridFormat(ByRef pv_xGridView As GridView, pv_strResource As String, ByVal mv_arrSrFieldSrch() As String, ByVal mv_arrSrFieldType() As String, ByVal pv_arrSrFieldWidth() As Integer, pv_arrSrFieldCaption() As String, pv_arrSrFieldVisibility() As String, ByVal mv_arrSrFieldFormat() As String)
        Dim v_xColumn As GridColumn
        Dim i As Integer
        Dim v_strFLDNAME As String

        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGridView.OptionsBehavior.Editable = False
        'pv_xGridView.OptionsBehavior.AllowAddRows = True
        pv_xGridView.OptionsBehavior.ReadOnly = True

        pv_xGridView.OptionsView.ShowAutoFilterRow = True
        pv_xGridView.OptionsView.ShowGroupPanel = True
        pv_xGridView.OptionsView.ShowIndicator = False
        'pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.ColumnAutoWidth = False
        'trung.luu: 10-04-2020 tự động xuống dòng khi tiêu đề dài vượt độ rộng của cột
        pv_xGridView.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True

        'Header panel
        pv_xGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
        pv_xGridView.Appearance.HeaderPanel.Font = New Font(pv_xGridView.Appearance.HeaderPanel.Font, FontStyle.Bold)

        'Selected row color
        'pv_xGridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#283593")

        'Alternative rows color

        'trung.luu 16-04-202: đổi màu dòng chẵn lẻ
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#E0EEEE")
        'pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#DCDCDC")
        'pv_xGridView.Appearance.OddRow.BackColor = ColorTranslator.FromHtml("#c8e6c9")

        

        'Format column
        Dim l_IsVisible As Boolean = True
        For Each v_xColumn In pv_xGridView.Columns
            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
            l_IsVisible = False
            v_xColumn.FilterMode = ColumnFilterMode.DisplayText
            v_xColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                    l_IsVisible = True
                    Select Case v_xColumn.ColumnType.Name

                        Case GetType(System.Decimal).Name, GetType(Integer).Name, GetType(Long).Name, GetType(Double).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.Numeric
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "n0", mv_arrSrFieldFormat(i))

                        Case GetType(System.DateTime).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.DateTime
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "dd/MM/yy", mv_arrSrFieldFormat(i))
                            v_xColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    End Select

                    Select Case UCase(mv_arrSrFieldFormat(i))

                        Case "C"
                            Dim LookupEditReponsitory As New RepositoryItemLookUpEdit()
                            LookupEditReponsitory.Name = v_strFLDNAME
                            pv_xGridView.GridControl.RepositoryItems.Add(LookupEditReponsitory)
                            '  v_xColumn.ColumnEdit = LookupEditReponsitory

                    End Select

                    v_xColumn.Width = pv_arrSrFieldWidth(i)
                    v_xColumn.Caption = pv_arrSrFieldCaption(i)
                    v_xColumn.Visible = pv_arrSrFieldVisibility(i).Equals("Y")
                End If
            Next
            If l_IsVisible = False And Not v_xColumn.FieldName.Equals("CheckMarkSelection") Then
                v_xColumn.Visible = False
            End If
            If v_xColumn.FieldName = "SWIFT" Then
                v_xColumn.ColumnEdit = New RepositoryItemMemoEdit()
                pv_xGridView.OptionsView.RowAutoHeight = True
            End If
        Next
    End Sub

    Public Sub XtraGridFormat(ByRef pv_xGridView As GridView, pv_strResource As String, ByVal mv_arrSrFieldSrch() As String, ByVal mv_arrSrFieldFormat() As String, ByVal pv_arrSrFieldWidth() As Integer, pv_arrSrFieldCaption() As String, pv_arrSrFieldVisibility() As String, Optional ByVal pv_isEdit As String = "N")
        Dim v_xColumn As GridColumn
        Dim i As Integer
        Dim v_strFLDNAME As String

        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGridView.OptionsBehavior.Editable = False
        pv_xGridView.OptionsBehavior.ReadOnly = True
        If pv_isEdit = "Y" Then
            pv_xGridView.OptionsBehavior.Editable = True
            pv_xGridView.OptionsBehavior.ReadOnly = False
        End If

        pv_xGridView.OptionsView.ShowAutoFilterRow = True
        pv_xGridView.OptionsView.ShowGroupPanel = True
        pv_xGridView.OptionsView.ShowIndicator = False
        'pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.ColumnAutoWidth = False
        'trung.luu: 10-04-2020 tự động xuống dòng khi tiêu đề dài vượt độ rộng của cột
        pv_xGridView.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True
        'Header panel
        pv_xGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
        pv_xGridView.Appearance.HeaderPanel.Font = New Font(pv_xGridView.Appearance.HeaderPanel.Font, FontStyle.Bold)

        'Selected row color
        'pv_xGridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#283593")

        'Alternative rows color
        'pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#e8f5e9")
        'pv_xGridView.Appearance.OddRow.BackColor = ColorTranslator.FromHtml("#c8e6c9")

        'Format column
        Dim l_IsVisible As Boolean = True
        For Each v_xColumn In pv_xGridView.Columns
            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
            l_IsVisible = False
            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                    l_IsVisible = True
                    Select Case v_xColumn.ColumnType.Name

                        Case GetType(System.Decimal).Name, GetType(Integer).Name, GetType(Long).Name, GetType(Double).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.Numeric
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "n0", mv_arrSrFieldFormat(i))

                        Case GetType(System.DateTime).Name

                            v_xColumn.DisplayFormat.FormatType = FormatType.DateTime
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "dd/MM/yy", mv_arrSrFieldFormat(i))
                            v_xColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    End Select

                    v_xColumn.Width = pv_arrSrFieldWidth(i)
                    v_xColumn.Caption = pv_arrSrFieldCaption(i)
                    v_xColumn.Visible = pv_arrSrFieldVisibility(i).Equals("Y")
                End If
            Next

            If l_IsVisible = False And Not v_xColumn.FieldName.Equals("CheckMarkSelection") And Not columnGridAllowVisable.Contains(v_strFLDNAME) Then
                v_xColumn.Visible = False
            End If
        Next
    End Sub

    Public Sub XtraGridFormatCSV(ByRef pv_xGridView As GridView, pv_strResource As String, ByVal mv_arrSrFieldSrch() As String, ByVal mv_arrSrFieldType() As String, ByVal pv_arrSrFieldWidth() As Integer, pv_arrSrFieldCaption() As String, pv_arrSrFieldVisibility() As String, ByVal mv_arrSrFieldFormat() As String)
        Dim v_xColumn As GridColumn
        Dim i As Integer
        Dim v_strFLDNAME As String

        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGridView.OptionsBehavior.Editable = False
        'pv_xGridView.OptionsBehavior.AllowAddRows = True
        pv_xGridView.OptionsBehavior.ReadOnly = True

        pv_xGridView.OptionsView.ShowAutoFilterRow = True
        pv_xGridView.OptionsView.ShowGroupPanel = True
        pv_xGridView.OptionsView.ShowIndicator = False
        'pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.ColumnAutoWidth = False
        'trung.luu: 10-04-2020 tự động xuống dòng khi tiêu đề dài vượt độ rộng của cột
        pv_xGridView.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True

        'Header panel
        pv_xGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
        pv_xGridView.Appearance.HeaderPanel.Font = New Font(pv_xGridView.Appearance.HeaderPanel.Font, FontStyle.Bold)

        'Selected row color
        'pv_xGridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#283593")

        'Alternative rows color

        'trung.luu 16-04-202: đổi màu dòng chẵn lẻ
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#E0EEEE")
        'pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#DCDCDC")
        'pv_xGridView.Appearance.OddRow.BackColor = ColorTranslator.FromHtml("#c8e6c9")



        'Format column
        Dim l_IsVisible As Boolean = True
        For Each v_xColumn In pv_xGridView.Columns
            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
            'l_IsVisible = False
            v_xColumn.FilterMode = ColumnFilterMode.DisplayText
            v_xColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

            v_xColumn.Width = 100
            Dim LookupEditReponsitory As New RepositoryItemLookUpEdit()
            LookupEditReponsitory.Name = v_strFLDNAME
            pv_xGridView.GridControl.RepositoryItems.Add(LookupEditReponsitory)

            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                    Select Case v_xColumn.ColumnType.Name

                        Case GetType(System.Decimal).Name, GetType(Integer).Name, GetType(Long).Name, GetType(Double).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.Numeric
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "n0", mv_arrSrFieldFormat(i))

                        Case GetType(System.DateTime).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.DateTime
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "dd/MM/yyyy", mv_arrSrFieldFormat(i))
                            v_xColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    End Select

                    Select Case UCase(mv_arrSrFieldFormat(i))

                        Case "C"
                            Dim LookupEditReponsitory2 As New RepositoryItemLookUpEdit()
                            LookupEditReponsitory.Name = v_strFLDNAME
                            pv_xGridView.GridControl.RepositoryItems.Add(LookupEditReponsitory2)
                            '  v_xColumn.ColumnEdit = LookupEditReponsitory

                    End Select

                    v_xColumn.Width = pv_arrSrFieldWidth(i)
                    v_xColumn.Caption = pv_arrSrFieldCaption(i)
                    v_xColumn.Visible = pv_arrSrFieldVisibility(i).Equals("Y")
                End If
            Next
            If l_IsVisible = False And Not v_xColumn.FieldName.Equals("CheckMarkSelection") Then
                v_xColumn.Visible = False
            End If
        Next
    End Sub

    Public Sub XtraGridFormatSummary(ByRef pv_xGridView As GridView, pv_strResource As String, ByVal mv_arrSrFieldSrch() As String, _
                                     ByVal mv_arrSrFieldFormat() As String, ByVal pv_arrSrFieldWidth() As Integer, pv_arrSrFieldCaption() As String, _
                                     pv_arrSrFieldVisibility() As String, pv_arrStSummaryCode() As String)
        Dim v_xColumn As GridColumn
        Dim i As Integer
        Dim v_strFLDNAME As String
        Dim v_hasGroupSummary As Boolean = False
        Dim itemGrp As GridGroupSummaryItem
        Dim summaryGrp As GridGroupSummaryItemCollection

        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGridView.OptionsBehavior.Editable = False
        pv_xGridView.OptionsBehavior.ReadOnly = True

        pv_xGridView.OptionsView.ShowAutoFilterRow = True
        pv_xGridView.OptionsView.ShowGroupPanel = True
        pv_xGridView.OptionsView.ShowIndicator = False
        'pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.ColumnAutoWidth = False
        'trung.luu: 10-04-2020 tự động xuống dòng khi tiêu đề dài vượt độ rộng của cột
        pv_xGridView.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True

        'Header panel
        pv_xGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
        pv_xGridView.Appearance.HeaderPanel.Font = New Font(pv_xGridView.Appearance.HeaderPanel.Font, FontStyle.Bold)
        'Selected row color
        'pv_xGridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#283593")
        pv_xGridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        pv_xGridView.GroupSummary.Clear()

        'Alternative rows color
        'pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#e8f5e9")
        'pv_xGridView.Appearance.OddRow.BackColor = ColorTranslator.FromHtml("#c8e6c9")

        'Format column
        Dim l_IsVisible As Boolean = True
        For Each v_xColumn In pv_xGridView.Columns
            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
            l_IsVisible = False
            v_xColumn.FilterMode = ColumnFilterMode.DisplayText
            v_xColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                    l_IsVisible = True
                    Select Case v_xColumn.ColumnType.Name

                        Case GetType(System.Decimal).Name, GetType(Integer).Name, GetType(Long).Name, GetType(Double).Name, GetType(System.Object).Name, GetType(String).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.Numeric
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "n0", mv_arrSrFieldFormat(i))
                            If InStr("\AVG\MIN\MAX\SUM\CNT", pv_arrStSummaryCode(i)) > 0 Then
                                v_hasGroupSummary = True
                            End If

                            Select Case pv_arrStSummaryCode(i)
                                Case "AVG"
                                    v_xColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average
                                    v_xColumn.SummaryItem.DisplayFormat = "Avg={0:n2}"

                                    itemGrp = New GridGroupSummaryItem()
                                    itemGrp.FieldName = v_xColumn.FieldName
                                    itemGrp.SummaryType = DevExpress.Data.SummaryItemType.Average
                                    itemGrp.DisplayFormat = "Avg={0:n2}"
                                    itemGrp.ShowInGroupColumnFooter = pv_xGridView.Columns(v_xColumn.FieldName)
                                    pv_xGridView.GroupSummary.Add(itemGrp)
                                Case "MIN"
                                    v_xColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min
                                    v_xColumn.SummaryItem.DisplayFormat = "Min={0:n2}"

                                    itemGrp = New GridGroupSummaryItem()
                                    itemGrp.FieldName = v_xColumn.FieldName
                                    itemGrp.SummaryType = DevExpress.Data.SummaryItemType.Min
                                    itemGrp.DisplayFormat = "Min={0:n2}"
                                    itemGrp.ShowInGroupColumnFooter = pv_xGridView.Columns(v_xColumn.FieldName)
                                    pv_xGridView.GroupSummary.Add(itemGrp)
                                Case "MAX"
                                    v_xColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max
                                    v_xColumn.SummaryItem.DisplayFormat = "Max={0:n2}"

                                    itemGrp = New GridGroupSummaryItem()
                                    itemGrp.FieldName = v_xColumn.FieldName
                                    itemGrp.SummaryType = DevExpress.Data.SummaryItemType.Max
                                    itemGrp.DisplayFormat = "Max={0:n2}"
                                    itemGrp.ShowInGroupColumnFooter = pv_xGridView.Columns(v_xColumn.FieldName)
                                    pv_xGridView.GroupSummary.Add(itemGrp)
                                Case "SUM"
                                    v_xColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                    v_xColumn.SummaryItem.DisplayFormat = "Sum={0:n2}"

                                    itemGrp = New GridGroupSummaryItem()
                                    itemGrp.FieldName = v_xColumn.FieldName
                                    itemGrp.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                    itemGrp.DisplayFormat = "Sum={0:n2}"
                                    itemGrp.ShowInGroupColumnFooter = pv_xGridView.Columns(v_xColumn.FieldName)
                                    pv_xGridView.GroupSummary.Add(itemGrp)
                                Case "CNT"
                                    v_xColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                                    v_xColumn.SummaryItem.DisplayFormat = "Count={0:n2}"

                                    itemGrp = New GridGroupSummaryItem()
                                    itemGrp.FieldName = v_xColumn.FieldName
                                    itemGrp.SummaryType = DevExpress.Data.SummaryItemType.Count
                                    itemGrp.DisplayFormat = "Count={0:n2}"
                                    itemGrp.ShowInGroupColumnFooter = pv_xGridView.Columns(v_xColumn.FieldName)
                                    pv_xGridView.GroupSummary.Add(itemGrp)
                            End Select
                        Case GetType(System.DateTime).Name

                            v_xColumn.DisplayFormat.FormatType = FormatType.DateTime
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "dd/MM/yy", mv_arrSrFieldFormat(i))
                            v_xColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    End Select

                    v_xColumn.Width = pv_arrSrFieldWidth(i)
                    v_xColumn.Caption = pv_arrSrFieldCaption(i)
                    v_xColumn.Visible = pv_arrSrFieldVisibility(i).Equals("Y")
                End If
            Next

            If l_IsVisible = False And Not v_xColumn.FieldName.Equals("CheckMarkSelection") Then
                v_xColumn.Visible = False
            End If

        Next
    End Sub

    ''' <summary>
    ''' Convert du lieu tu ObjData hoac ObjDataRef -> System.Data.DataTable
    ''' </summary>
    ''' <param name="pv_strObjMsg">du lieu xml co node ObjData hoac ObjDataRef</param>
    ''' <param name="pv_strDataNode">Ten node can parse du lieu</param>
    ''' <param name="pv_strTable">Ten bang</param>
    ''' <returns>System.Data.DataTable</returns>
    ''' <remarks></remarks>
    Public Function ObjDataToDataset(pv_strObjMsg As String,
                                     Optional ByVal pv_strDataNode As String = "ObjData", _
                    Optional ByVal pv_strTable As String = "ObjData"
                    ) As DataTable
        Dim xmlNode As XmlNode
        Dim hasRefData As Boolean = False
        Try
            Dim v_xmlDocument As New XmlDocument
            Dim v_nodeList As XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/" + pv_strDataNode)

            Dim v_xDataSet As DataSet
            v_xDataSet = New DataSet
            v_xDataSet.Tables.Add(pv_strTable)

            For v_intCount = 0 To v_nodeList.Count - 1
                Dim v_xDataColumn As System.Data.DataColumn

                If v_intCount = 0 Then
                    'Build column
                    For Each xmlNode In v_nodeList.Item(v_intCount)
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1

                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value))
                                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)

                                If v_xDataSet.Tables(pv_strTable).Columns.Count > 0 Then
                                    If Not (v_xDataSet.Tables(pv_strTable).Columns.Contains(v_strFLDNAME)) Then
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = v_strFLDNAME
                                        v_xDataColumn.DataType = Type.GetType(v_strFLDTYPE)
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                    End If
                                Else
                                    If Not (.Attributes.GetNamedItem("refname") Is Nothing) And Not (CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value Is Nothing) Then
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = "refname"
                                        v_xDataColumn.DataType = Type.GetType("System.String")
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                        hasRefData = True
                                    Else
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = v_strFLDNAME
                                        v_xDataColumn.DataType = Type.GetType(v_strFLDTYPE)
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                    End If
                                End If
                            End With
                        Next
                    Next
                End If

                Dim v_xDataRow As DataRow
                v_xDataRow = v_xDataSet.Tables(pv_strTable).NewRow()
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    'Add data row

                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value))
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)

                        If hasRefData Then
                            v_xDataRow("refname") = CStr(CType(.Attributes.GetNamedItem("refname"), XmlAttribute).Value)
                        End If

                        If v_strFLDTYPE = GetType(System.Boolean).FullName Then
                            v_xDataRow(v_strFLDNAME).Value = IIf(v_strValue = "0", False, True)
                        Else
                            Select Case v_strFLDTYPE
                                Case GetType(System.String).FullName
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", CStr(v_strValue))
                                Case GetType(System.Decimal).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CDec(v_strValue)
                                    End If
                                Case GetType(Integer).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CInt(v_strValue)
                                    End If
                                Case GetType(Long).FullName

                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CLng(v_strValue)
                                    End If

                                Case GetType(Double).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CDbl(v_strValue)
                                    End If
                                Case GetType(System.DateTime).FullName

                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = gf_Cdate("01/01/1900")
                                    Else
                                        v_xDataRow(v_strFLDNAME) = gf_Cdate(v_strValue)
                                    End If

                                Case GetType(System.Boolean).FullName
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", CStr(v_strValue))

                                Case Else
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", v_strValue)
                            End Select
                        End If


                    End With
                Next
                v_xDataSet.Tables(pv_strTable).Rows.Add(v_xDataRow)

            Next

            If v_xDataSet.Tables.Contains(pv_strTable) And Not v_xDataSet.Tables(pv_strTable).Columns.Contains("LASTCREATED") Then
                v_xDataSet.Tables(pv_strTable).Columns.Add(New DataColumn("LASTCREATED", GetType(String)))
            End If


            Return v_xDataSet.Tables(pv_strTable)
        Catch ex As Exception
            LogError.Write("ObjDataToDataset::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        Finally

        End Try
    End Function
    Public Function ObjDataRef_ToDataset(pv_strObjMsg As String,
                                     Optional ByVal pv_strDataNode As String = "ObjDataRef", _
                    Optional ByVal pv_strTable As String = "ObjData"
                    ) As DataTable
        Dim xmlNode As XmlNode
        Dim hasRefData As Boolean = False
        Try
            Dim v_xmlDocument As New XmlDocument
            Dim v_nodeList As XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/" + pv_strDataNode)

            Dim v_xDataSet As DataSet
            v_xDataSet = New DataSet
            v_xDataSet.Tables.Add(pv_strTable)

            For v_intCount = 0 To v_nodeList.Count - 1
                Dim v_xDataColumn As System.Data.DataColumn

                If v_intCount = 0 Then
                    'Build column
                    For Each xmlNode In v_nodeList.Item(v_intCount)
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1

                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value))
                                'v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)
                                v_strFLDTYPE = "System.String"

                                If v_xDataSet.Tables(pv_strTable).Columns.Count > 0 Then
                                    If Not (v_xDataSet.Tables(pv_strTable).Columns.Contains(v_strFLDNAME)) Then
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = v_strFLDNAME
                                        v_xDataColumn.DataType = Type.GetType(v_strFLDTYPE)
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                    End If
                                Else
                                    If Not (.Attributes.GetNamedItem("refname") Is Nothing) And Not (CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value Is Nothing) Then
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = "refname"
                                        v_xDataColumn.DataType = Type.GetType("System.String")
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                        hasRefData = True
                                    Else
                                        v_xDataColumn = New DataColumn()
                                        v_xDataColumn.ColumnName = v_strFLDNAME
                                        v_xDataColumn.DataType = Type.GetType(v_strFLDTYPE)
                                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                                    End If
                                End If
                            End With
                        Next
                    Next
                End If

                Dim v_xDataRow As DataRow
                v_xDataRow = v_xDataSet.Tables(pv_strTable).NewRow()
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    'Add data row

                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value))
                        'v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)
                        v_strFLDTYPE = "System.String"

                        If hasRefData Then
                            v_xDataRow("refname") = CStr(CType(.Attributes.GetNamedItem("refname"), XmlAttribute).Value)
                        End If

                        If v_strFLDTYPE = GetType(System.Boolean).FullName Then
                            v_xDataRow(v_strFLDNAME).Value = IIf(v_strValue = "0", False, True)
                        Else
                            Select Case v_strFLDTYPE
                                Case GetType(System.String).FullName
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", CStr(v_strValue))
                                Case GetType(System.Decimal).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CDec(v_strValue)
                                    End If
                                Case GetType(Integer).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CInt(v_strValue)
                                    End If
                                Case GetType(Long).FullName

                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CLng(v_strValue)
                                    End If

                                Case GetType(Double).FullName
                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = 0
                                    Else
                                        v_xDataRow(v_strFLDNAME) = CDbl(v_strValue)
                                    End If
                                Case GetType(System.DateTime).FullName

                                    If String.IsNullOrEmpty(v_strValue) Then
                                        v_xDataRow(v_strFLDNAME) = gf_Cdate("01/01/1900")
                                    Else
                                        v_xDataRow(v_strFLDNAME) = gf_Cdate(v_strValue)
                                    End If

                                Case GetType(System.Boolean).FullName
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", CStr(v_strValue))

                                Case Else
                                    v_xDataRow(v_strFLDNAME) = IIf(String.IsNullOrEmpty(v_strValue), "", v_strValue)
                            End Select
                        End If


                    End With
                Next
                v_xDataSet.Tables(pv_strTable).Rows.Add(v_xDataRow)

            Next

            Return v_xDataSet.Tables(pv_strTable)
        Catch ex As Exception
            LogError.Write("ObjDataToDataset::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        Finally

        End Try
    End Function
    ''' <summary>
    ''' Convert du lieu tu ObjData hoac ObjDataRef -> System.Data.DataTable
    ''' </summary>
    ''' <param name="pv_strObjMsg">du lieu xml co node ObjData hoac ObjDataRef</param>
    ''' <param name="pv_strDataNode">Ten node can parse du lieu</param>
    ''' <param name="pv_strTable">Ten bang</param>
    ''' <returns>System.Data.DataTable</returns>
    ''' <remarks></remarks>
    Public Function InitGridSearchFields(pv_strTable As String, pv_strSearchFieldName() As String, pv_strSrFieldDisp() As String, pv_strSearchFieldType() As String) As DataTable

        Try
            Dim v_intCount As Integer
            Dim v_xDataSet As DataSet

            v_xDataSet = New DataSet
            v_xDataSet.Tables.Add(pv_strTable)

            For v_intCount = 0 To pv_strSearchFieldName.Count - 1
                Dim v_xDataColumn As System.Data.DataColumn
                'Build column

                If Not pv_strSearchFieldName(v_intCount) Is Nothing Then
                    If Not v_xDataSet.Tables(pv_strTable).Columns.Contains(pv_strSearchFieldName(v_intCount)) Then
                        v_xDataColumn = New DataColumn()
                        v_xDataColumn.ColumnName = pv_strSearchFieldName(v_intCount)
                        v_xDataColumn.Caption = pv_strSrFieldDisp(v_intCount)

                        Select Case pv_strSearchFieldType(v_intCount)
                            Case "N"
                                v_xDataColumn.DataType = Type.GetType("System.Double")
                            Case Else
                                v_xDataColumn.DataType = Type.GetType("System.String")
                        End Select


                        v_xDataSet.Tables(pv_strTable).Columns.Add(v_xDataColumn)
                    End If
                End If

            Next

            Return v_xDataSet.Tables(pv_strTable)
        Catch ex As Exception
            LogError.Write("InitGridSearchFields::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Fill du lieu vao GridControl
    ''' </summary>
    ''' <param name="pv_xGrid"></param>
    ''' <param name="pv_strObjMsg"></param>
    ''' <param name="pv_strResource"></param>
    ''' <param name="pv_strTable"></param>
    ''' <param name="pv_strFilter"></param>
    ''' <param name="pv_intFromrow"></param>
    ''' <param name="pv_intTorow"></param>
    ''' <param name="pv_intTotalrow"></param>
    ''' <remarks></remarks>
    Public Sub FillDataXtraGrid(ByVal pv_xGrid As DevExpress.XtraGrid.GridControl, _
                    ByVal pv_strObjMsg As String, _
                    ByVal pv_strResource As String, _
                    Optional ByVal pv_strTable As String = "", _
                    Optional ByVal pv_strFilter As String = "", _
                    Optional ByVal pv_intFromrow As Int32 = 0, _
                    Optional ByVal pv_intTorow As Int32 = 0, _
                    Optional ByVal pv_intTotalrow As Int32 = 0)
        Try

            'Dim grv As GridView = pv_xGrid.MainView
            'If grv IsNot Nothing Then
            '    grv.Columns.Clear()
            'End If
            pv_xGrid.DataSource = ObjDataToDataset(pv_strObjMsg, , pv_strTable)
            Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = pv_xGrid.MainView
            If (grv IsNot Nothing) Then
                grv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
                grv.OptionsBehavior.CopyToClipboardWithColumnHeaders = False

            End If
        Catch ex As Exception
            LogError.Write("FillDataXtraGrid::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Khoi tao grid control tu searchcode
    ''' </summary>
    ''' <param name="pv_strSearchCode"></param>
    ''' <param name="pv_XtraGrid"></param>
    ''' <param name="pv_gvResult"></param>
    ''' <remarks></remarks>
    Public Sub InitGridFromSearchCode(ByVal pv_strSearchCode As String, ByRef pv_XtraGrid As DevExpress.XtraGrid.GridControl, ByRef pv_gvResult As DevExpress.XtraGrid.Views.Grid.GridView, Optional ByVal pv_strClause As String = "", Optional ByVal pv_isFormat As String = "Y", Optional ByVal pv_keyvalue As String = "Y", Optional ByVal pv_language As String = "EN")
        Dim i As Integer
        Dim v_strFLDNAME, Value As String
        Dim strRow, v_strMessage As String
        Dim v_intFrom, v_intTo As Int32
        Dim mv_strCmdSql, mv_strFormName, mv_arrSrFieldSrch(), mv_arrSrFieldDisp(), mv_arrSrFieldType(), mv_arrSrFieldMask() As String
        Dim mv_arrStFieldDefValue(), mv_arrSrFieldOperator(), mv_arrSrFieldFormat(), mv_arrSrFieldDisplay() As String
        Dim mv_arrSrSQLRef(), mv_arrStFieldMultiLang(), mv_arrStFieldMandartory(), mv_arrStFieldRefCDType(), mv_arrStFieldRefCDName() As String
        Dim mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType As String
        Dim mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode As String
        Dim mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT As String
        Dim mv_strCaption, mv_strEnCaption, mv_strObjName As String
        Dim mv_arrSrFieldWidth() As Integer
        Try

            Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
            Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & pv_strSearchCode & "' ORDER BY POSITION"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )
            Dim v_ws As New BDSDeliveryManagement
            v_ws.Message(v_strObjMsg)
            PrepareSearchParams(pv_language, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
                mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
                mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
                mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
                mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
                mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
                mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT)

            'Add filter
            If pv_strClause.Length > 0 Then
                mv_strCmdSql = mv_strCmdSql & pv_strClause
            End If
            If pv_keyvalue.Length > 0 Then
                mv_strCmdSql = mv_strCmdSql.Replace("<@KEYVALUE>", pv_keyvalue)
                mv_strCmdSql = mv_strCmdSql.Replace("<$KEYVAL>", pv_keyvalue)
            End If

            If pv_language = gc_LANG_ENGLISH Then
                mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
            Else
                mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "CDCONTENT")
                mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "DESCRIPTION")
            End If

            'Build data
            v_strObjMsg = BuildXMLObjMsg(, , , , "N", gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
                                                gc_ActionInquiry, mv_strCmdSql)
            v_ws.Message(v_strObjMsg)
            'Fill data to grid
            FillDataXtraGrid(pv_XtraGrid, v_strObjMsg, "", pv_strSearchCode, , 0, 100, 0)
            'Format grid
            If pv_isFormat = "Y" Then
                XtraGridFormat(pv_gvResult, "", mv_arrSrFieldSrch, mv_arrSrFieldType, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CreateFilterColumn(ByRef fc As FilterControl, pv_arrSearchFieldRequired() As String, pv_arrSearchFieldName() As String, pv_arrSearchFieldType() As String, pv_arrSearchFieldCaption() As String, mv_arrSrSQLRef() As String, Optional ByVal pv_Lang As String = "EN")

        Dim v_strObjMsg As String = ""
        Dim v_ws As New BDSDeliveryManagement
        Dim I As Integer


        For I = 0 To pv_arrSearchFieldRequired.Count() - 1

            If Not String.IsNullOrEmpty(pv_arrSearchFieldRequired(I)) Then
                If (pv_arrSearchFieldRequired(I).Equals("Y")) Then
                    Select Case pv_arrSearchFieldType(I)
                        Case "D"
                            fc.FilterColumns.Add(New UnboundFilterColumn(pv_arrSearchFieldCaption(I), pv_arrSearchFieldName(I), GetType(DateTime), New RepositoryItemDateEdit(), FilterColumnClauseClass.String))
                        Case "C"

                            If Not String.IsNullOrEmpty(mv_arrSrSQLRef(I)) Then
                                Dim riLueAllcode = New RepositoryItemLookUpEdit()

                                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, mv_arrSrSQLRef(I), , )
                                v_ws.Message(v_strObjMsg)

                                FillXtraRepositoryItemLookUpEdit_search(v_strObjMsg, riLueAllcode, , pv_Lang)
                                fc.FilterColumns.Add(New UnboundFilterColumn(pv_arrSearchFieldCaption(I), pv_arrSearchFieldName(I), GetType(String), riLueAllcode, FilterColumnClauseClass.String))
                            Else
                                fc.FilterColumns.Add(New UnboundFilterColumn(pv_arrSearchFieldCaption(I), pv_arrSearchFieldName(I), GetType(String), New RepositoryItemTextEdit(), FilterColumnClauseClass.String))
                            End If

                        Case Else
                            fc.FilterColumns.Add(New UnboundFilterColumn(pv_arrSearchFieldCaption(I), pv_arrSearchFieldName(I), GetType(String), New RepositoryItemTextEdit(), FilterColumnClauseClass.String))
                    End Select

                End If
            End If


        Next
    End Sub


    ''' <summary>
    ''' Binding du lieu tu ObjDataRef vao combo box
    ''' DEBUG mode: luon parse lai data tu xml, luu toan bo ObjDataRef ra memory cache
    ''' RELEASE mode: doc luon tu cache, neu cache chua co moi parse tu xml
    ''' </summary>
    ''' <param name="pv_strObjMsg"></param>
    ''' <param name="pv_lue"></param>
    ''' <param name="pv_strRefField"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub FillXtraLookUpEditRefData(ByVal pv_strObjMsg As String, pv_lue As LookUpEdit, pv_strRefField As String)
        Try
            ''If RefDataCache Is Nothing Then
            ''RefDataCache = ObjDataToDataset(pv_strObjMsg, "ObjDataRef")
            ''End If

            ''If RefDataCache.Rows.Count = 0 Then
            ''RefDataCache = ObjDataToDataset(pv_strObjMsg, "ObjDataRef")
            ''End If

            'RefDataCache = ObjDataToDataset(pv_strObjMsg, "ObjDataRef")
            RefDataCache = ObjDataRef_ToDataset(pv_strObjMsg, "ObjDataRef")


            Dim result As DataTable = _refData.Select(String.Format("refname = '{0}'", pv_strRefField)).CopyToDataTable()

            BindingXtraLookUpEdit(result, pv_lue.Properties, Nothing)
        Catch ex As Exception
            LogError.Write("FillXtraLookUpEditRefData::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            'Throw
        End Try
    End Sub

    ''' <summary>
    ''' Binding du lieu tu ObjData vao comboBox
    ''' </summary>
    ''' <param name="pv_strObjMsg"></param>
    ''' <param name="pv_lue"></param>
    ''' <param name="pv_strRefField"></param>
    ''' <remarks></remarks>
    Public Sub FillXtraRepositoryItemLookUpEdit(ByVal pv_strObjMsg As String, pv_lue As RepositoryItemLookUpEdit, Optional ByVal pv_FilterID As String = "", Optional ByVal pv_Lang As String = "EN")
        Try
            Dim result As DataTable = ObjDataToDataset(pv_strObjMsg, "ObjData")
            BindingXtraLookUpEdit(result, pv_lue.Properties, Nothing, pv_Lang)
        Catch ex As Exception
            LogError.Write("FillXtraLookUpEditRefData::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    ''' Binding du lieu tu ObjData vao comboBox cua man hinh search
    Public Sub FillXtraRepositoryItemLookUpEdit_search(ByVal pv_strObjMsg As String, pv_lue As RepositoryItemLookUpEdit, Optional ByVal pv_FilterID As String = "", Optional ByVal pv_Lang As String = "EN")
        Dim ret As RepositoryItemLookUpEdit = IIf(pv_lue.Properties Is Nothing, New RepositoryItemLookUpEdit(), pv_lue.Properties)
        Try
            Dim result As DataTable = ObjDataToDataset(pv_strObjMsg, "ObjData")
            'BindingXtraLookUpEdit(result, pv_lue.Properties, Nothing, pv_Lang)



            
            ret.DataSource = result
            ret.ValueMember = "VALUE"
            If pv_Lang = "EN" Then
                ret.ValueMember = "EN_DISPLAY"
                ret.DisplayMember = "EN_DISPLAY"

                ret.Columns.Clear()
                ret.Columns.Add(New LookUpColumnInfo("EN_DISPLAY"))
            Else
                ret.ValueMember = "DISPLAY"
                ret.DisplayMember = "DISPLAY"

                ret.Columns.Clear()
                ret.Columns.Add(New LookUpColumnInfo("DISPLAY"))
            End If
            ret.TextEditStyle = TextEditStyles.DisableTextEditor
            ret.ShowHeader = False
            ret.ShowFooter = False
            ret.DropDownRows = IIf(result.Rows.Count >= 7, 7, result.Rows.Count)
            ret.SearchMode = SearchMode.AutoComplete
            ret.AllowNullInput = DefaultBoolean.False
            ret.SortColumnIndex = 0
            ret.NullText = String.Empty



        Catch ex As Exception
            LogError.Write("FillXtraLookUpEditRefData::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Binding du lieu tu ObjData vao comboBox
    ''' </summary>
    ''' <param name="pv_strObjMsg"></param>
    ''' <param name="pv_lue"></param>
    ''' <param name="pv_strRefField"></param>
    ''' <remarks></remarks>
    Public Sub FillXtraLookUpEdit(ByVal pv_strObjMsg As String, pv_lue As LookUpEdit, Optional ByVal pv_FilterID As String = "", Optional ByVal pv_Lang As String = "EN")
        Try
            Dim result As DataTable = ObjDataToDataset(pv_strObjMsg, "ObjData")
            BindingXtraLookUpEdit(result, pv_lue.Properties, Nothing, pv_Lang)
            pv_lue.ItemIndex = 0
        Catch ex As Exception
            LogError.Write("FillXtraLookUpEditRefData::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub
    Public Sub CreateColumnLookupEdit(ByVal pv_XtraGrid As DevExpress.XtraGrid.GridControl, ByVal pv_strObjMsg As String, strColumn As String, Optional ByVal pv_Lang As String = "EN")
        Try
            Dim rsp As New RepositoryItemLookUpEdit
            rsp.Name = strColumn
            FillXtraRepositoryItemLookUpEdit(pv_strObjMsg, rsp, , pv_Lang)

            pv_XtraGrid.RepositoryItems.Add(rsp)
            CType(pv_XtraGrid.Views(0), DevExpress.XtraGrid.Views.Grid.GridView).Columns(strColumn).ColumnEdit = pv_XtraGrid.RepositoryItems(strColumn)
        Catch ex As Exception
            LogError.Write("CreateColumnLookupEdit::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    Public Sub BindingXtraLookUpEdit(dt As DataTable, edit As RepositoryItemLookUpEdit,
                                                          collection As RepositoryItemCollection, Optional ByVal pv_Lang As String = "EN")

        Dim ret As RepositoryItemLookUpEdit = IIf(edit Is Nothing, New RepositoryItemLookUpEdit(), edit)
        Try
            If Not collection Is Nothing Then
                collection.Add(ret)
            End If
            ret.DataSource = dt
            ret.ValueMember = "VALUE"
            If pv_Lang = "EN" Then
                ret.DisplayMember = "EN_DISPLAY"

                ret.Columns.Clear()
                ret.Columns.Add(New LookUpColumnInfo("EN_DISPLAY"))
            Else
                ret.DisplayMember = "DISPLAY"

                ret.Columns.Clear()
                ret.Columns.Add(New LookUpColumnInfo("DISPLAY"))
            End If
            ret.TextEditStyle = TextEditStyles.DisableTextEditor
            ret.ShowHeader = False
            ret.ShowFooter = False
            ret.DropDownRows = IIf(dt.Rows.Count >= 7, 7, dt.Rows.Count)
            ret.SearchMode = SearchMode.AutoComplete
            ret.AllowNullInput = DefaultBoolean.False
            ret.SortColumnIndex = 0
            ret.NullText = String.Empty
        Catch ex As Exception
            LogError.Write("BindingXtraLookUpEdit::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    Public Sub SetLookUpEditDefaultValue(lookUpEdit As LookUpEdit,
                                           lookUpValue As Object)
        Try

            SetLookUpEditDefaultValue(lookUpEdit, lookUpEdit.Properties, lookUpEdit.Properties.ValueMember, lookUpValue)
        Catch ex As Exception
            LogError.Write("SetLookUpEditDefaultValue::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    Public Sub SetLookUpEditDefaultValue(lookUpEdit As LookUpEdit,
                                               respositoryItemLookUpEdit As RepositoryItemLookUpEdit,
                                               lookUpField As String, lookUpValue As Object)
        Try

            Dim r As Integer = respositoryItemLookUpEdit.GetDataSourceRowIndex(lookUpField, lookUpValue)
            lookUpEdit.EditValue = lookUpEdit.Properties.GetDataSourceValue(lookUpEdit.Properties.ValueMember, IIf(r < 0, 0, r))
        Catch ex As Exception
            LogError.Write("SetLookUpEditDefaultValue::" & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw
        End Try
    End Sub

    Private Function i() As Integer
        Throw New NotImplementedException
    End Function

End Module
