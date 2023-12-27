Imports Xceed.Grid
Imports CommonLibrary
Imports SendFiles
Imports ZetaCompressionLibrary
Imports TestBase64
Imports System.IO

<Serializable()> _
Public Module modCoreLib



    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   ?ịnh dạng các thuộc tính chung nhất của GRID
    ' + ?ầu vào:    
    '       - pv_xGrid:         GRID cần định dạng các thuộc tính
    '       - pv_strTable:      Tên bảng dữ liệu để fill vào GRID
    '       - pv_strResource:   Tên resource dùng để định dạng GRID
    '       - pv_blnFirst:      ?ịnh dạng lần đầu; mặc định là TRUE
    ' + ?ầu ra:     GRID được định dạng
    ' + Trả v?:     N/A
    ' + Tác giả:    Trần Ki?u Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Sub _FormatGridBefore(ByRef pv_xGrid As GridControl, _
                                 Optional ByVal pv_strTable As String = vbNullString, _
                                 Optional ByVal pv_strResource As String = vbNullString, _
                                 Optional ByVal pv_blnFirst As Boolean = True, _
                                 Optional ByVal pv_blnGroup As Boolean = True, _
                                 Optional ByVal pv_intFromrow As Int32 = 0, _
                                 Optional ByVal pv_intTorow As Int32 = 0, _
                                 Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 And pv_blnGroup Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Nếu lần đầu tiên tạo thì xoá trắng định dạng của Grid
        If pv_blnFirst Then pv_xGrid.Clear()

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGrid.ReadOnly = True

        Dim GroupByRow1 As Xceed.Grid.GroupByRow
        Dim ColumnManagerRow1 As Xceed.Grid.ColumnManagerRow
        Dim VisualGridElementStyle1 As Xceed.Grid.VisualGridElementStyle
        Dim VisualGridElementStyle2 As Xceed.Grid.VisualGridElementStyle

        VisualGridElementStyle1 = New Xceed.Grid.VisualGridElementStyle
        VisualGridElementStyle2 = New Xceed.Grid.VisualGridElementStyle

        '?ịnh nghĩa định dạng cho Row dữ liệu
        '
        'VisualGridElementStyle
        '
        VisualGridElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(1, Byte), CType(152, Byte), CType(2, Byte))
        VisualGridElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(249, Byte), CType(190, Byte), CType(58, Byte))

        If pv_blnGroup Then
            GroupByRow1 = New Xceed.Grid.GroupByRow
            ColumnManagerRow1 = New Xceed.Grid.ColumnManagerRow
            '
            'GroupByRow1
            '
            '
            If Len(pv_strResource) > 0 Then
                GroupByRow1.NoGroupText = m_ResourceManager.GetString("GridEx.GroupByRow")
            End If

            GroupByRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
            GroupByRow1.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            GroupByRow1.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            '
            'ColumnManagerRow1
            '
            ColumnManagerRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            ColumnManagerRow1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ColumnManagerRow1.HorizontalAlignment = HorizontalAlignment.Center
            ColumnManagerRow1.Height = 32
        End If

        pv_xGrid.RowSelectorPane.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        pv_xGrid.RowSelectorPane.ForeColor = System.Drawing.Color.White
        pv_xGrid.SelectionBackColor = System.Drawing.Color.FromArgb(CType(96, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
        pv_xGrid.SelectionForeColor = System.Drawing.Color.Black

        pv_xGrid.Font = New System.Drawing.Font("Tahoma", 8.25!)
        pv_xGrid.ForeColor = System.Drawing.Color.Black
        pv_xGrid.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(CType(48, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
        pv_xGrid.InactiveSelectionForeColor = System.Drawing.Color.Black

        pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle1)
        pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle2)

        If pv_blnFirst Then
            pv_xGrid.FixedHeaderRows.Add(GroupByRow1)
            pv_xGrid.FixedHeaderRows.Add(ColumnManagerRow1)
            If Len(pv_strResource) > 0 Then
                _FormatGridAfter(pv_xGrid, pv_strTable, pv_strResource.Substring(pv_strResource.Length - 2))
            End If
        End If

        If Len(pv_strResource) > 0 And pv_blnGroup Then
            'Dim FooterRow As New TextRow(m_ResourceManager.GetString("GridEx.FooterRow") & pv_xGrid.DataRows.Count.ToString)
            Dim m_intToRow As Int32
            Dim FooterRow As TextRow  '(m_ResourceManager.GetString("GridEx.FooterRowFrom") & pv_intFromrow & " " & m_ResourceManager.GetString("GridEx.FooterRowTo") & m_intToRow & "   " & m_ResourceManager.GetString("GridEx.FooterRowIn") & pv_intTotalrow & " Row ")

            If (pv_intFromrow = 0) And (pv_intTorow = 0) And (pv_intTotalrow = 0) Then
                FooterRow = New TextRow(m_ResourceManager.GetString("GridEx.FooterRow") & pv_xGrid.DataRows.Count.ToString)
            Else
                If pv_intFromrow = 0 Then
                    m_intToRow = pv_intFromrow + pv_xGrid.DataRows.Count.ToString
                Else
                    m_intToRow = pv_intFromrow - 1 + pv_xGrid.DataRows.Count.ToString
                End If
                FooterRow = New TextRow(m_ResourceManager.GetString("GridEx.FooterRowFrom") & FormatNumber(pv_intFromrow, 0) & " " _
                    & m_ResourceManager.GetString("GridEx.FooterRowTo") & FormatNumber(m_intToRow, 0) & " " _
                    & m_ResourceManager.GetString("GridEx.FooterRowIn").Replace("@", FormatNumber(pv_intTotalrow, 0)))
            End If
            'FooterRow
            FooterRow.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            FooterRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            pv_xGrid.FixedFooterRows.Clear()
            pv_xGrid.FixedFooterRows.Add(FooterRow)
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   ?ịnh dạng các thuộc tính của GRID sau khi load dữ liệu
    ' + ?ầu vào:    
    '       - pv_xGrid:         GRID cần định dạng các thuộc tính
    '       - pv_strTable:      Tên bảng dữ liệu để fill vào GRID
    ' + ?ầu ra:     GRID được định dạng
    ' + Trả v?:     N/A
    ' + Tác giả:    Trần Ki?u Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Sub _FormatGridAfter(ByVal pv_xGrid As GridControl, _
                                ByVal pv_strTable As String, ByVal pv_strUserLanguage As String)
        Try
            Dim v_strCondition As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFieldCode, v_strFieldType, v_strFieldName, v_strEnFieldName, _
            v_strWidth, v_strVisible, v_strMultiLang, v_strACDType, v_strACDName, v_strFieldFormat As String
            Dim v_strFLDNAME, v_strVALUE As String

            'Lựa ch?n các đi?u kiện tìm kiếm
            v_strCondition = "upper(SEARCHCODE) = '" & pv_strTable & "' ORDER BY POSITION"

            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strCondition)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_xGrid.Dock = Windows.Forms.DockStyle.Fill
            pv_xGrid.Columns.Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
            pv_xGrid.Columns("__TICK").Visible = False
            pv_xGrid.Columns("__TICK").Title = String.Empty
            pv_xGrid.Columns("__TICK").Width = 20

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
                            Case "FIELDNAME"
                                v_strFieldName = v_strVALUE
                            Case "EN_FIELDNAME"
                                v_strEnFieldName = v_strVALUE
                            Case "WIDTH"
                                v_strWidth = CDec(v_strVALUE)
                            Case "DISPLAY"
                                v_strVisible = v_strVALUE
                            Case "MULTILANG"
                                v_strMultiLang = Trim(v_strVALUE)
                            Case "ACDTYPE"
                                v_strACDType = Trim(v_strVALUE)
                            Case "ACDNAME"
                                v_strACDName = Trim(v_strVALUE)
                            Case "FORMAT"
                                v_strFieldFormat = Trim(v_strVALUE)
                        End Select
                    End With
                Next

                Select Case v_strFieldType
                    Case "D"
                        pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    Case "N"
                        Dim v_decimalColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(System.Decimal))
                        If (Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0) And v_strFieldFormat <> "0" Then
                            v_decimalColumn.FormatSpecifier = v_strFieldFormat
                        Else
                            v_decimalColumn.FormatSpecifier = "#,##0.00"
                        End If
                        pv_xGrid.Columns.Add(v_decimalColumn)
                    Case "I"
                        Dim v_integerColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Integer))
                        If Not v_strFieldFormat Is Nothing AndAlso v_strFieldFormat.Length > 0 Then
                            v_integerColumn.FormatSpecifier = v_strFieldFormat
                        Else
                            v_integerColumn.FormatSpecifier = "#,##0"
                        End If

                        pv_xGrid.Columns.Add(v_integerColumn)
                    Case "L"
                        Dim v_longColumn As New Xceed.Grid.Column(v_strFieldCode, GetType(Long))
                        v_longColumn.FormatSpecifier = "#,##0"
                        pv_xGrid.Columns.Add(v_longColumn)
                    Case "C"
                        pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.String)))
                    Case "B"
                        pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_strFieldCode, GetType(System.Boolean)))
                End Select
                If Not v_strFieldCode Is Nothing Then
                    pv_xGrid.Columns(v_strFieldCode).Title = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strFieldName, v_strEnFieldName)
                    pv_xGrid.Columns(v_strFieldCode).Width = v_strWidth
                    pv_xGrid.Columns(v_strFieldCode).Visible = (v_strVisible = "Y")
                End If
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Fill dữ liệu vào GRID
    ' + ?ầu vào:    
    '       - pv_xGrid:         GRID cần fill dữ liệu
    '       - pv_strObjMsg:     Message trả v? chứa kết quả tìm kiếm
    '       - pv_strTable:      Tên bảng
    '       - pv_strFilter:     Filter
    ' + ?ầu ra:     GRID được fill dữ liệu
    ' + Trả v?:     N/A
    ' + Tác giả:    Trần Ki?u Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    'Public Sub FillDataGrid(ByVal pv_xGrid As GridControl, _
    '                        ByVal pv_strObjMsg As String, _
    '                        ByVal pv_strResource As String, _
    '                        Optional ByVal pv_strTable As String = "", _
    '                        Optional ByVal pv_strFilter As String = "", _
    '                        Optional ByVal pv_intFromrow As Int32 = 0, _
    '                        Optional ByVal pv_intTorow As Int32 = 0, _
    '                        Optional ByVal pv_intTotalrow As Int32 = 0)
    '    Dim v_dt As DataTable
    '    Dim v_dr As DataRow
    '    Dim v_xColumn As Xceed.Grid.Column

    '    Try
    '        Dim v_xmlDocument As New Xml.XmlDocument
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_int, v_intCount As Integer
    '        Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
    '        Dim v_strColoumName As String

    '        v_xmlDocument.LoadXml(pv_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        pv_xGrid.DataRows.Clear()
    '        pv_xGrid.BeginInit()
    '        'If rowperpage = 0 Then
    '        '    rowperpage = v_nodeList.Count
    '        'End If

    '        For v_intCount = 0 To v_nodeList.Count - 1
    '            'If (v_intCount >= v_nodeList.Count - rowperpage) Then
    '            Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()

    '            For Each v_xColumn In pv_xGrid.Columns
    '                v_strColoumName = UCase(Trim(v_xColumn.FieldName))
    '                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
    '                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
    '                        v_strValue = .InnerText.ToString
    '                        v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
    '                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
    '                        If Not (v_strValue Is DBNull.Value) Then
    '                            If Trim(v_strValue) = "" Then
    '                                v_strValue = Nothing
    '                            End If
    '                        End If
    '                        If v_strFLDNAME = v_strColoumName Then
    '                            If v_strColoumName <> "SIGNATURE" Then
    '                                If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
    '                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue = "0", False, True)
    '                                Else
    '                                    Select Case v_xColumn.DataType.Name
    '                                        Case GetType(System.String).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
    '                                        Case GetType(System.Decimal).Name
    '                                            If v_strValue = "" Then
    '                                                v_strValue = 0
    '                                            End If
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
    '                                        Case GetType(Integer).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
    '                                        Case GetType(Long).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
    '                                        Case GetType(Double).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
    '                                        Case GetType(System.DateTime).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
    '                                        Case GetType(System.Boolean).Name
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))

    '                                        Case Else
    '                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
    '                                    End Select
    '                                End If
    '                                v_xDataRow.EndEdit()

    '                            End If
    '                        End If
    '                    End With
    '                Next
    '            Next
    '            '  End If
    '        Next

    '        pv_xGrid.EndInit()
    '        _FormatGridBefore(pv_xGrid, pv_strTable, pv_strResource, False, , pv_intFromrow, pv_intTorow, pv_intTotalrow)
    '    Catch ex As Exception
    '        LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub FillDataGrid(ByVal pv_xGrid As GridControl, _
                            ByVal pv_strObjMsg As String, _
                            ByVal pv_strResource As String, _
                            Optional ByVal pv_strTable As String = "", _
                            Optional ByVal pv_strFilter As String = "", _
                            Optional ByVal pv_intFromrow As Int32 = 0, _
                            Optional ByVal pv_intTorow As Int32 = 0, _
                            Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim v_dt As DataTable
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strColoumName As String

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_xGrid.BeginInit()
            pv_xGrid.SelectedRows.Clear()
            pv_xGrid.DataRows.Clear()

            'If rowperpage = 0 Then
            '    rowperpage = v_nodeList.Count
            'End If

            For v_intCount = 0 To v_nodeList.Count - 1
                'If (v_intCount >= v_nodeList.Count - rowperpage) Then

                Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()
                Try
                    For Each v_xColumn In pv_xGrid.Columns
                        v_strColoumName = UCase(Trim(v_xColumn.FieldName))
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

    Public Sub FillDataSetToGrid(ByVal pv_xGrid As GridControl, _
                            ByVal pv_ds As DataSet, _
                            ByVal pv_strResource As String, _
                            Optional ByVal pv_strTable As String = "", _
                            Optional ByVal pv_strFilter As String = "", _
                            Optional ByVal pv_intFromrow As Int32 = 0, _
                            Optional ByVal pv_intTorow As Int32 = 0, _
                            Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim v_dt As DataTable
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strColoumName As String
            'Dim v_xDataRow As Xceed.Grid.DataRow
            pv_xGrid.DataRows.Clear()
            pv_xGrid.BeginInit()
            'If rowperpage = 0 Then
            '    rowperpage = v_nodeList.Count
            'End If
            'pv_xGrid.SetDataBinding(pv_ds, "ObjData")
            'pv_xGrid.DataSource=pv_ds.Tables(0)

            For v_intCount = 0 To pv_ds.Tables(0).Rows.Count - 1
                'If (v_intCount >= v_nodeList.Count - rowperpage) Then
                Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()
                'v_xDataRow = pv_xGrid.DataRows.AddNew()
                For Each v_xColumn In pv_xGrid.Columns
                    v_strColoumName = UCase(Trim(v_xColumn.FieldName))
                    If pv_ds.Tables(0).Columns.Contains(v_strColoumName) Then
                        v_strValue = gf_CorrectStringField(pv_ds.Tables(0).Rows(v_intCount)(v_strColoumName))
                        v_strFLDNAME = v_strColoumName 'pv_ds.Tables(0).Columns(v_strColoumName).ColumnName
                        v_strFLDTYPE = pv_ds.Tables(0).Columns(v_strColoumName).DataType.Name
                        'If Not (v_strValue Is DBNull.Value) Then
                        '    If Trim(v_strValue) = "" Then
                        '        v_strValue = Nothing
                        '    End If
                        'End If
                        'If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
                        '    v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue = "0", False, True)
                        'Else

                        'End If
                        Select Case v_xColumn.DataType.Name
                            Case GetType(System.Boolean).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue = "0", False, True)
                            Case GetType(System.String).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                            Case GetType(System.Decimal).Name
                                If v_strValue = "" Then
                                    v_strValue = 0
                                End If
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                            Case GetType(Integer).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                            Case GetType(Long).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                            Case GetType(Double).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                            Case GetType(System.DateTime).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                            Case GetType(System.Boolean).Name
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))

                            Case Else
                                v_xDataRow.Cells(v_strColoumName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                        End Select

                    End If


                Next
                '  End If
                v_xDataRow.EndEdit()
            Next

            pv_xGrid.EndInit()
            _FormatGridBefore(pv_xGrid, pv_strTable, pv_strResource, False, , pv_intFromrow, pv_intTorow, pv_intTotalrow)
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Function GetImageFromString(ByVal pv_strFLDVAL) As System.Drawing.Bitmap
        Dim v_strCompress As String = Trim(pv_strFLDVAL)
        Dim v_Compression As Byte()
        Dim v_Base64Decoder As New Base64Decoder(v_strCompress)
        v_Compression = v_Base64Decoder.GetDecoded()
        Dim v_arrActualSignImage As Byte()
        v_arrActualSignImage = CompressionHelper.DecompressBytes(v_Compression)
        Dim tmpImage As System.Drawing.Bitmap = New System.Drawing.Bitmap(New MemoryStream(v_arrActualSignImage))
        Return tmpImage
    End Function
    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Phân tích xâu các ký tự đi?u ki�ện tìm kiếm
    ' + ?�ầu vào:    
    '       - pv_strOperator:   Xâu các ký tự đi?u ki�ện tìm kiếm
    ' + ?�ầu ra:
    '       - pv_arrOperator:   Mảng chứa các toán tử tìm kiếm
    ' + Trả v?:     N/A
    ' + T�ác giả:    Trần Ki?u Minh
    ' + Ghi ch�ú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Sub AnalyzeOperator(ByVal pv_strOperator As String, ByRef pv_arrOperator() As String)
        pv_arrOperator = pv_strOperator.Split(",")

        For i As Integer = 0 To pv_arrOperator.Length - 1
            pv_arrOperator(i) = Trim(pv_arrOperator(i))
        Next
    End Sub

    'Public Sub PrepareSearchParams(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
    '                               ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
    '                               ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
    '                               ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
    '                               ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
    '                               ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
    '                               ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, _
    '                               ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
    '                               ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
    '                               Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", Optional ByRef pv_strISEMAIL As String = "N")
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim v_strFLDNAME, v_strValue As String
    '    Dim v_strKeyValue, v_strSrch, v_strRefValue As String
    '    Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode As String
    '    Dim v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
    '    Dim v_strSrFieldDisplay, v_strSrLookupSql As String
    '    Dim v_intSrFieldWidth As Integer

    '    Try
    '        pv_intSearchNum = 0

    '        v_xmlDocument.LoadXml(pv_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        ReDim pv_arrSrFieldCode(v_nodeList.Count)
    '        ReDim pv_arrSrFieldName(v_nodeList.Count)
    '        ReDim pv_arrSrFieldType(v_nodeList.Count)
    '        ReDim pv_arrSrFieldMask(v_nodeList.Count)
    '        ReDim pv_arrSrFieldDefValue(v_nodeList.Count)
    '        ReDim pv_arrSrFieldOperator(v_nodeList.Count)
    '        ReDim pv_arrSrFieldFormat(v_nodeList.Count)
    '        ReDim pv_arrSrFieldDisplay(v_nodeList.Count)
    '        ReDim pv_arrSrFieldWidth(v_nodeList.Count)
    '        ReDim pv_arrSrLookupSql(v_nodeList.Count)

    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    v_strValue = .InnerText.ToString

    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "SRCH"
    '                            v_strSrch = Trim(v_strValue)
    '                        Case "SEARCHTITLE"
    '                            v_strSrTitle = Trim(v_strValue)
    '                        Case "EN_SEARCHTITLE"
    '                            v_strSrEnTitle = Trim(v_strValue)
    '                        Case "SEARCHCMDSQL"
    '                            v_strSrCmd = Trim(v_strValue)
    '                        Case "OBJNAME"
    '                            v_strSrObjName = Trim(v_strValue)
    '                        Case "FRMNAME"
    '                            v_strFrmName = Trim(v_strValue)
    '                        Case "FIELDCODE"
    '                            v_strSrFieldCode = Trim(v_strValue)
    '                        Case "FIELDNAME"
    '                            v_strSrFieldName = Trim(v_strValue)
    '                        Case "EN_FIELDNAME"
    '                            v_strSrEnFieldName = Trim(v_strValue)
    '                        Case "FIELDTYPE"
    '                            v_strSrFieldType = Trim(v_strValue)
    '                        Case "MASK"
    '                            v_strSrFieldMask = Trim(v_strValue)
    '                        Case "DEFVALUE"
    '                            v_strSrFieldDefValue = Trim(v_strValue)
    '                        Case "ORDERBYCMDSQL"
    '                            v_strOderbycmdsql = Trim(v_strValue)
    '                        Case "OPERATOR"
    '                            v_strSrFieldOperator = Trim(v_strValue)
    '                        Case "FORMAT"
    '                            v_strSrFieldFormat = Trim(v_strValue)
    '                        Case "DISPLAY"
    '                            v_strSrFieldDisplay = Trim(v_strValue)
    '                        Case "KEY"
    '                            v_strKeyValue = Trim(v_strValue)
    '                            If v_strKeyValue = "Y" Then
    '                                pv_strKeyColumn = v_strSrFieldCode
    '                                pv_strKeyFieldType = v_strSrFieldType
    '                            End If
    '                        Case "REFVALUE"
    '                            v_strRefValue = Trim(v_strValue)

    '                            If v_strRefValue = "Y" Then
    '                                pv_strRefColumn = v_strSrFieldCode
    '                                pv_strRefFieldType = v_strSrFieldType
    '                            End If
    '                        Case "WIDTH"
    '                            v_intSrFieldWidth = CInt(Trim(v_strValue))
    '                        Case "TLTXCD"
    '                            pv_strTLTXCD = Trim(v_strValue)
    '                        Case "LOOKUPCMDSQL"
    '                            v_strSrLookupSql = Trim(v_strValue)
    '                        Case "ISSMS"
    '                            pv_strISSMS = Trim(v_strValue)
    '                        Case "ISEMAIL"
    '                            pv_strISEMAIL = Trim(v_strValue)
    '                    End Select
    '                End With
    '            Next

    '            If v_strSrch = "Y" Then
    '                pv_intSearchNum += 1

    '                If pv_intSearchNum = 1 Then
    '                    pv_strSrTitle = v_strSrTitle
    '                    pv_strSrEnTitle = v_strSrEnTitle
    '                    pv_strSrCmd = v_strSrCmd
    '                    pv_strSrOderByCmd = v_strOderbycmdsql
    '                    pv_strSrObjName = v_strSrObjName
    '                    pv_strFrmName = v_strFrmName
    '                End If
    '                pv_arrSrFieldCode(pv_intSearchNum) = v_strSrFieldCode
    '                pv_arrSrFieldName(pv_intSearchNum) = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strSrFieldName, v_strSrEnFieldName)
    '                pv_arrSrFieldType(pv_intSearchNum) = v_strSrFieldType
    '                pv_arrSrFieldMask(pv_intSearchNum) = v_strSrFieldMask
    '                pv_arrSrFieldDefValue(pv_intSearchNum) = v_strSrFieldDefValue
    '                pv_arrSrFieldOperator(pv_intSearchNum) = v_strSrFieldOperator
    '                pv_arrSrFieldFormat(pv_intSearchNum) = v_strSrFieldFormat
    '                pv_arrSrFieldDisplay(pv_intSearchNum) = v_strSrFieldDisplay
    '                pv_arrSrFieldWidth(pv_intSearchNum) = v_intSrFieldWidth
    '                pv_arrSrLookupSql(pv_intSearchNum) = v_strSrLookupSql
    '            End If
    '        Next

    '        If pv_intSearchNum > 0 Then
    '            ReDim Preserve pv_arrSrFieldCode(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldName(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldType(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldMask(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldDefValue(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldOperator(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldFormat(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldDisplay(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrFieldWidth(pv_intSearchNum)
    '            ReDim Preserve pv_arrSrLookupSql(pv_intSearchNum)
    '        End If
    '    Catch ex As Exception
    '        LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
    '        Throw ex
    '    End Try
    'End Sub


    Public Sub PrepareSearchParams(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "")

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName As String
        Dim v_intSrFieldWidth, v_intFieldCount As Integer

        Try
            pv_intSearchNum = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            ReDim pv_arrSrFieldCode(v_intFieldCount)
            ReDim pv_arrSrFieldName(v_intFieldCount)
            ReDim pv_arrSrFieldType(v_intFieldCount)
            ReDim pv_arrSrFieldMask(v_intFieldCount)
            ReDim pv_arrSrFieldDefValue(v_intFieldCount)
            ReDim pv_arrSrFieldOperator(v_intFieldCount)
            ReDim pv_arrSrFieldFormat(v_intFieldCount)
            ReDim pv_arrSrFieldDisplay(v_intFieldCount)
            ReDim pv_arrSrFieldWidth(v_intFieldCount)
            ReDim pv_arrSrLookupSql(v_intFieldCount)
            ReDim pv_arrSrFieldMultiLang(v_intFieldCount)
            ReDim pv_arrSrFieldMandatory(v_intFieldCount)
            ReDim pv_arrSrRefCDType(v_intFieldCount)
            ReDim pv_arrSrRefCDName(v_intFieldCount)

            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "ROWPERPAGE"
                                If IsNumeric(v_strValue) Then
                                    pv_intRowPerPage = CInt(v_strValue)
                                Else
                                    pv_intRowPerPage = 0
                                End If
                            Case "SRCH"
                                v_strSrch = Trim(v_strValue)
                            Case "AUTHCODE"
                                pv_strAUTHCODE = Trim(v_strValue)
                            Case "ROWLIMIT"
                                pv_strROWLIMIT = Trim(v_strValue)
                            Case "CMDTYPE"
                                pv_strCMDTYPE = Trim(v_strValue)
                            Case "SEARCHTITLE"
                                v_strSrTitle = Trim(v_strValue)
                            Case "EN_SEARCHTITLE"
                                v_strSrEnTitle = Trim(v_strValue)
                            Case "SEARCHCMDSQL"
                                v_strSrCmd = Trim(v_strValue)
                            Case "OBJNAME"
                                v_strSrObjName = Trim(v_strValue)
                            Case "FRMNAME"
                                v_strFrmName = Trim(v_strValue)
                            Case "FIELDCODE"
                                v_strSrFieldCode = Trim(v_strValue)
                            Case "FIELDNAME"
                                v_strSrFieldName = Trim(v_strValue)
                            Case "EN_FIELDNAME"
                                v_strSrEnFieldName = Trim(v_strValue)
                            Case "FIELDTYPE"
                                v_strSrFieldType = Trim(v_strValue)
                            Case "MASK"
                                v_strSrFieldMask = Trim(v_strValue)
                            Case "DEFVALUE"
                                v_strSrFieldDefValue = Trim(v_strValue)
                            Case "ORDERBYCMDSQL"
                                v_strOderbycmdsql = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strSrFieldOperator = Trim(v_strValue)
                            Case "FORMAT"
                                v_strSrFieldFormat = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strSrFieldDisplay = Trim(v_strValue)
                            Case "KEY"
                                v_strKeyValue = Trim(v_strValue)
                                If v_strKeyValue = "Y" Then
                                    pv_strKeyColumn = v_strSrFieldCode
                                    pv_strKeyFieldType = v_strSrFieldType
                                End If
                            Case "REFVALUE"
                                v_strRefValue = Trim(v_strValue)

                                If v_strRefValue = "Y" Then
                                    pv_strRefColumn = v_strSrFieldCode
                                    pv_strRefFieldType = v_strSrFieldType
                                End If
                            Case "WIDTH"
                                v_intSrFieldWidth = CInt(Trim(v_strValue))
                            Case "TLTXCD"
                                pv_strTLTXCD = Trim(v_strValue)
                            Case "LOOKUPCMDSQL"
                                v_strSrLookupSql = Trim(v_strValue)
                            Case "ISSMS"
                                pv_strISSMS = Trim(v_strValue)
                            Case "ISEMAIL"
                                pv_strISEMAIL = Trim(v_strValue)
                            Case "MULTILANG"
                                v_strSrFieldMultiLang = Trim(v_strValue)
                            Case "ACDTYPE"
                                v_strSrRefACDType = Trim(v_strValue)
                            Case "ACDNAME"
                                v_strSrRefACDName = Trim(v_strValue)
                            Case "CONDDEFFLD"
                                pv_strCondDefFld = Trim(v_strValue)
                            Case "BANKINQ"
                                pv_strBANKINQ = Trim(v_strValue)
                            Case "BANKACCT"
                                pv_strBANKACCT = Trim(v_strValue)
                        End Select
                    End With
                Next

                If v_strSrch = "Y" Or v_strSrch = "M" Then  'M là bắt buộc phải nhập giá trị tìm kiếm
                    pv_intSearchNum += 1

                    If pv_intSearchNum = 1 Then
                        pv_strSrTitle = v_strSrTitle
                        pv_strSrEnTitle = v_strSrEnTitle
                        pv_strSrCmd = v_strSrCmd
                        pv_strSrOderByCmd = v_strOderbycmdsql
                        pv_strSrObjName = v_strSrObjName
                        pv_strFrmName = v_strFrmName
                    End If
                    pv_arrSrFieldCode(pv_intSearchNum) = v_strSrFieldCode
                    pv_arrSrFieldName(pv_intSearchNum) = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strSrFieldName, v_strSrEnFieldName)
                    pv_arrSrFieldType(pv_intSearchNum) = v_strSrFieldType
                    pv_arrSrFieldMask(pv_intSearchNum) = v_strSrFieldMask
                    pv_arrSrFieldDefValue(pv_intSearchNum) = v_strSrFieldDefValue
                    pv_arrSrFieldOperator(pv_intSearchNum) = v_strSrFieldOperator
                    pv_arrSrFieldFormat(pv_intSearchNum) = v_strSrFieldFormat
                    pv_arrSrFieldDisplay(pv_intSearchNum) = v_strSrFieldDisplay
                    pv_arrSrFieldWidth(pv_intSearchNum) = v_intSrFieldWidth
                    pv_arrSrLookupSql(pv_intSearchNum) = v_strSrLookupSql
                    pv_arrSrFieldMandatory(pv_intSearchNum) = v_strSrch
                    'pv_arrSrFieldName(pv_intSearchNum) = v_strSrFieldName
                    pv_arrSrRefCDType(v_intFieldCount) = v_strSrRefACDType
                    pv_arrSrRefCDName(v_intFieldCount) = v_strSrRefACDName
                End If
            Next

            If pv_intSearchNum > 0 Then
                ReDim Preserve pv_arrSrFieldCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldName(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldType(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMask(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDefValue(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldOperator(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldFormat(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDisplay(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldWidth(pv_intSearchNum)
                ReDim Preserve pv_arrSrLookupSql(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMultiLang(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMandatory(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)

            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub


    Public Sub FillComboDataSource(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBoxEx, Optional ByVal pv_FilterID As String = "")
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCboValue, v_strCboDisplay, v_strCboFilterID As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_ArrayData As New ArrayList
        Dim v_int As Integer
        Try
            v_int = 0
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim v_arrValue(v_nodeList.Count)
            ReDim v_arrDisplay(v_nodeList.Count)
            v_int = 0
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strCboValue = String.Empty
                v_strCboDisplay = String.Empty
                v_strCboFilterID = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString.Trim
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCboValue = v_strValue
                            Case "DISPLAY"
                                v_strCboDisplay = v_strValue
                            Case "FILTERID"
                                v_strCboFilterID = v_strValue
                        End Select
                    End With
                Next
                If pv_FilterID.Length = 0 Then
                    'Do not have filter
                    v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
                ElseIf v_strCboFilterID.Length > 0 Then
                    If String.Compare(v_strCboFilterID, pv_FilterID) = 0 Then
                        v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
                    End If
                End If
            Next

            With pv_cbo
                .DisplayMember = "Description"
                .ValueMember = "Value"
                .DataSource = v_ArrayData
            End With

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    'Public Sub FillComboEx(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBoxEx, Optional ByVal pv_FilterID As String = "")
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim v_strFLDNAME, v_strValue, v_strCboValue, v_strCboDisplay, v_strCboFilterID As String
    '    Dim v_arrValue(), v_arrDisplay() As String
    '    Dim v_ArrayData As New ArrayList
    '    Dim v_int As Integer
    '    Try
    '        v_int = 0
    '        v_xmlDocument.LoadXml(pv_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        ReDim v_arrValue(v_nodeList.Count)
    '        ReDim v_arrDisplay(v_nodeList.Count)
    '        v_int = 0
    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            v_strCboValue = String.Empty
    '            v_strCboDisplay = String.Empty
    '            v_strCboFilterID = String.Empty
    '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    v_strValue = .InnerText.ToString
    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "VALUE"
    '                            v_strCboValue = Trim(v_strValue)
    '                        Case "DISPLAY"
    '                            v_strContent = Trim(v_strValue)
    '                        Case "EN_DISPLAY"
    '                            v_strENContent = Trim(v_strValue)
    '                        Case "FILTERID"
    '                            v_strCboFilterID = Trim(v_strValue)
    '                    End Select
    '                End With
    '            Next
    '            If pv_FilterID.Length = 0 Then
    '                'Do not have filter
    '                v_int += 1
    '                v_arrValue(v_int) = v_strCboValue
    '                v_arrDisplay(v_int) = v_strCboDisplay
    '                v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
    '            ElseIf v_strCboFilterID.Length > 0 Then
    '                If String.Compare(v_strCboFilterID, pv_FilterID) = 0 Then
    '                    v_int += 1
    '                    v_arrValue(v_int) = v_strCboValue
    '                    v_arrDisplay(v_int) = v_strCboDisplay
    '                    v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
    '                End If
    '            End If
    '        Next

    '        pv_cbo.Clears()
    '        For i As Integer = 1 To v_int
    '            pv_cbo.AddItems(v_arrDisplay(i), v_arrValue(i))
    '        Next

    '    Catch ex As Exception
    '        LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub FillComboEx(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBoxEx, Optional ByVal pv_FilterID As String = "", Optional ByVal pv_Lang As String = "EN")
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCboValue, v_strCboDisplay, v_strContent, v_strENContent, v_strCboFilterID As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_ArrayData As New ArrayList
        Dim v_int As Integer
        Try
            v_int = 0
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim v_arrValue(v_nodeList.Count)
            ReDim v_arrDisplay(v_nodeList.Count)
            v_int = 0
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strCboValue = String.Empty
                v_strCboDisplay = String.Empty
                v_strCboFilterID = String.Empty
                v_strContent = String.Empty
                v_strENContent = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCboValue = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strContent = Trim(v_strValue)
                            Case "EN_DISPLAY"
                                v_strENContent = Trim(v_strValue)
                            Case "FILTERID"
                                v_strCboFilterID = Trim(v_strValue)
                        End Select
                    End With
                Next

                'Display multi language
                If v_strENContent.Length = 0 Then
                    v_strCboDisplay = v_strContent
                Else
                    If pv_Lang = "EN" Then
                        v_strCboDisplay = v_strENContent
                    Else
                        v_strCboDisplay = v_strContent
                    End If
                End If

                If pv_FilterID.Length = 0 Then
                    'Do not have filter
                    v_int += 1
                    v_arrValue(v_int) = v_strCboValue
                    v_arrDisplay(v_int) = v_strCboDisplay
                    v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
                ElseIf v_strCboFilterID.Length > 0 Then
                    If String.Compare(v_strCboFilterID, pv_FilterID) = 0 Then
                        v_int += 1
                        v_arrValue(v_int) = v_strCboValue
                        v_arrDisplay(v_int) = v_strCboDisplay
                        v_ArrayData.Add(New ValueDescriptionPair(v_strCboValue, v_strCboDisplay))
                    End If
                End If
            Next

            pv_cbo.Clears()
            For i As Integer = 1 To v_int
                pv_cbo.AddItems(v_arrDisplay(i), v_arrValue(i))
            Next

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Sub FillComboExRefData(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBoxEx, ByVal pv_strREFFLDNAME As String, Optional ByVal pv_Lang As String = "EN")
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strREFNAME, v_strFLDNAME, v_strValue As String
        Dim v_arrRef() As Boolean, v_arrValue(), v_arrDisplay(), v_arrENDisplay() As String
        Dim v_int As Integer

        Try
            v_int = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjDataRef")
            ReDim v_arrRef(v_nodeList.Count)
            ReDim v_arrValue(v_nodeList.Count)
            ReDim v_arrDisplay(v_nodeList.Count)
            ReDim v_arrENDisplay(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                v_int += 1
                v_arrRef(v_int) = False
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strREFNAME = CStr(CType(.Attributes.GetNamedItem("refname"), Xml.XmlAttribute).Value)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        If Trim(pv_strREFFLDNAME) = Trim(v_strREFNAME) Then
                            v_arrRef(v_int) = True
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    v_arrValue(v_int) = Trim(v_strValue)
                                Case "DISPLAY"
                                    v_arrDisplay(v_int) = Trim(v_strValue)
                                Case "EN_DISPLAY"
                                    v_arrENDisplay(v_int) = Trim(v_strValue)
                            End Select
                        End If
                    End With
                Next
            Next

            For i As Integer = 1 To v_int
                If v_arrRef(i) Then
                    If pv_Lang = gc_LANG_ENGLISH Then
                        pv_cbo.AddItems(v_arrENDisplay(i), v_arrValue(i))
                    Else
                        pv_cbo.AddItems(v_arrDisplay(i), v_arrValue(i))
                    End If

                End If
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Function GetBankBalance(ByVal pv_strACCTNO As String) As String
        Try
            Dim v_strClause, v_strObjMsg, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strClause = v_strValue
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , pv_strACCTNO)
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Return v_strValue
        Catch ex As Exception
            'Throw ex
            Return "0"
        End Try
    End Function

End Module
