Imports Xceed.Grid

Module modCommon
    'Hằng số quy ước định dạng dữ liệu
    Public Const gc_FORMAT_DATE = "dd/MM/yyyy"
    Public Const gc_FORMAT_INTEGER = "#,##0"

    Public Const gc_IS_LAST_MENU = "Y"

    Public Enum SearchType
        SearchNone = -1
        SearchChoose = 0
        SearchText = 1
        SearchNumeric = 2
        SearchDate = 3
    End Enum



    Public Sub FillCombo(ByVal pv_strObjMsg As String, ByRef pv_cbo As ComboBox, Optional ByVal pv_FilterID As String = "", Optional ByVal pv_Lang As String = "EN")
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
            pv_cbo.DataBindings.Clear()
            pv_cbo.DataSource = Nothing
            pv_cbo.Items.Clear()
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
                    v_ArrayData.Add(New ComboBoxItem(v_strCboValue, v_strCboDisplay))
                ElseIf v_strCboFilterID.Length > 0 Then
                    If String.Compare(v_strCboFilterID, pv_FilterID) = 0 Then
                        v_int += 1
                        v_arrValue(v_int) = v_strCboValue
                        v_arrDisplay(v_int) = v_strCboDisplay
                        v_ArrayData.Add(New ComboBoxItem(v_strCboValue, v_strCboDisplay))
                    End If
                End If
            Next

            


            If v_ArrayData.Count > 0 Then
                pv_cbo.DataSource = v_ArrayData
                pv_cbo.DisplayMember = "Text"
                pv_cbo.ValueMember = "Value"
            End If

        Catch ex As Exception

            Throw ex
        End Try
    End Sub


    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Fill dữ liệu vào ComboBox từ nguồn dữ liệu là message XML.
    ' + Đầu vào:
    '       - pv_ctrObject:     ComboBox cần fill dữ liệu
    '       - pv_strSrcMsg:     Message XML
    '       - pv_blnIsAppend:   TRUE: bổ sung - FALSE: thêm mới. Mặc định là FALSE
    '       - pv_blnHasAllItem: TRUE: có mục tất cả - FALSE: không có mục tất cả. Mặc định là FALSE
    ' + Đầu ra:     ComboBox được fill dữ liệu
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Sub FillComboBox(ByRef pv_ctrObject As ComboBox, _
                            ByVal pv_strSrcMsg As String, _
                            Optional ByVal pv_blnIsAppend As Boolean = False, _
                            Optional ByVal pv_blnHasAllItem As Boolean = False)
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_arrList As New ArrayList
        Dim v_strFldName, v_strValue, v_strText As String

        Try
            If pv_strSrcMsg <> String.Empty Then
                XmlDocument.LoadXml(pv_strSrcMsg)
                v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For v_intI As Integer = 0 To v_nodeList.Count - 1
                    For v_intJ As Integer = 0 To v_nodeList(v_intI).ChildNodes.Count - 1
                        With v_nodeList(v_intI).ChildNodes(v_intJ)
                            v_strFldName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case v_strFldName
                                Case "TEXTFLD"
                                    v_strText = .InnerText.ToString()
                                Case "VALUEFLD"
                                    v_strValue = .InnerText.ToString()
                            End Select
                        End With
                    Next v_intJ
                    v_arrList.Add(New ComboBoxItem(v_strValue, v_strText))
                Next v_intI
            End If

            If pv_blnHasAllItem Then
                v_arrList.Add(New ComboBoxItem("", "--Tất cả--"))
            End If

            With pv_ctrObject
                If Not pv_blnIsAppend Then
                    .Items.Clear()
                End If

                If v_arrList.Count > 0 Then
                    .DataSource = v_arrList
                    .DisplayMember = "Text"
                    .ValueMember = "Value"

                    If pv_blnHasAllItem Then
                        .SelectedIndex = .Items.Count - 1
                    End If
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AddComboBoxItem(ByRef pv_ctrObject As ComboBox, _
                               ByVal pv_strText As String, _
                               ByVal pv_strValue As String, _
                               Optional ByVal pv_blnIsAppend As Boolean = False)
        Dim v_arrList As New ArrayList

        Try
            v_arrList.Add(New ComboBoxItem(pv_strValue, pv_strText))

            If Not pv_blnIsAppend Then
                pv_ctrObject.Items.Clear()
            End If

            pv_ctrObject.DataSource = v_arrList
            pv_ctrObject.DisplayMember = "Text"
            pv_ctrObject.ValueMember = "Value"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Định dạng grid để hiển thị dữ liệu tìm kiếm.
    ' + Đầu vào:
    '       - pv_xGrid:         Grid cần định dạng
    '       - pv_blnFirst:      Lần đầu? Mặc định là TRUE
    ' + Đầu ra:     Grid được định dạng
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Sub FormatXceedGrid(ByRef pv_xGrid As GridControl, Optional ByVal pv_blnFirst As Boolean = True)
        Try
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

            'Định nghĩa định dạng cho Row dữ liệu
            '
            'VisualGridElementStyle
            '
            VisualGridElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(1, Byte), CType(152, Byte), CType(2, Byte))
            VisualGridElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(249, Byte), CType(190, Byte), CType(58, Byte))

            GroupByRow1 = New Xceed.Grid.GroupByRow
            ColumnManagerRow1 = New Xceed.Grid.ColumnManagerRow
            '
            'GroupByRow1
            '
            GroupByRow1.NoGroupText = "Hãy kéo cột cần nhóm vào đây"
            GroupByRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
            GroupByRow1.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            GroupByRow1.CellFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
            '
            'ColumnManagerRow1
            '
            ColumnManagerRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            ColumnManagerRow1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)

            pv_xGrid.RowSelectorPane.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            pv_xGrid.RowSelectorPane.ForeColor = System.Drawing.Color.White
            pv_xGrid.SelectionBackColor = System.Drawing.Color.FromArgb(CType(96, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
            pv_xGrid.SelectionForeColor = System.Drawing.Color.Black

            pv_xGrid.Font = New System.Drawing.Font("Verdana", 8.25!)
            pv_xGrid.ForeColor = System.Drawing.Color.Black
            pv_xGrid.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(CType(48, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
            pv_xGrid.InactiveSelectionForeColor = System.Drawing.Color.Black

            pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle1)
            pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle2)

            If pv_blnFirst Then
                pv_xGrid.FixedHeaderRows.Add(GroupByRow1)
                pv_xGrid.FixedHeaderRows.Add(ColumnManagerRow1)
                '_FormatGridAfter(xGrid, strTable)
            End If
            Dim FooterRow As New TextRow("Tổng số bản ghi tìm kiếm:" & pv_xGrid.DataRows.Count.ToString)
            '
            'FooterRow
            '
            FooterRow.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            FooterRow.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
            pv_xGrid.FixedFooterRows.Clear()
            pv_xGrid.FixedFooterRows.Add(FooterRow)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Module

Public Class ComboBoxItem
    Private mv_strItemData As String = String.Empty
    Private mv_strItemText As String = String.Empty

    Public Sub New(ByVal ItemData As String, ByVal ItemText As String)
        mv_strItemData = ItemData
        mv_strItemText = ItemText
    End Sub

    Public ReadOnly Property Value() As String
        Get
            Return mv_strItemData
        End Get
    End Property

    Public ReadOnly Property Text() As String
        Get
            Return mv_strItemText
        End Get
    End Property
End Class
