Imports ExcelLibrary.SpreadSheet
Imports CommonLibrary

Public Class ExcelLib
    Public Function WriteXLSFile(ByVal pFileName As String, ByVal pDataSet As DataSet) As Boolean
        Try
            'Create a workbook instance
            Dim workbook As Workbook = New Workbook()
            Dim worksheet As Worksheet
            Dim iRow As Integer = 0
            Dim iCol As Integer = 0
            Dim sTemp As String = String.Empty
            Dim dTemp As Double = 0
            Dim decTemp As Decimal = 0
            Dim iTemp As Integer = 0
            Dim dtTemp As DateTime
            Dim count As Integer = 0
            Dim iTotalRows As Integer = 0
            Dim iSheetCount As Integer = 0

            'Read DataSet
            If Not pDataSet Is Nothing And pDataSet.Tables.Count > 0 Then

                'Traverse DataTable inside the DataSet
                For Each dt As DataTable In pDataSet.Tables

                    'Create a worksheet instance
                    iSheetCount = iSheetCount + 1
                    worksheet = New Worksheet("Sheet" & iSheetCount.ToString())

                    'Write Table Header
                    For Each dc As DataColumn In dt.Columns
                        worksheet.Cells(iRow, iCol) = New Cell(dc.ColumnName)
                        iCol = iCol + 1
                    Next

                    'Write Table Body
                    iRow = 1
                    For Each dr As DataRow In dt.Rows
                        iCol = 0
                        For Each dc As DataColumn In dt.Columns
                            sTemp = dr(dc.ColumnName).ToString()
                            Select Case dc.DataType.Name
                                Case GetType(System.DateTime).Name
                                    'DateTime.TryParse(sTemp, dtTemp)
                                    dtTemp = DDMMYYYY_SystemDate(sTemp)
                                    Dim strVal As String = String.Empty
                                    strVal = FormatDateTime(dtTemp, DateFormat.ShortDate)
                                    worksheet.Cells(iRow, iCol) = New Cell(strVal)
                                Case GetType(System.Double).Name
                                    Double.TryParse(sTemp, dTemp)
                                    worksheet.Cells(iRow, iCol) = New Cell(dTemp, "#,##0.00")
                                Case GetType(System.Decimal).Name
                                    Decimal.TryParse(sTemp, decTemp)
                                    worksheet.Cells(iRow, iCol) = New Cell(decTemp, "#,##0.00")
                                Case Else
                                    worksheet.Cells(iRow, iCol) = New Cell(sTemp)
                            End Select
                            iCol = iCol + 1
                        Next
                        iRow = iRow + 1
                    Next

                    'Attach worksheet to workbook
                    workbook.Worksheets.Add(worksheet)
                    iTotalRows = iTotalRows + iRow
                Next
            End If


            workbook.Save(pFileName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function WriteXLSFileEx(ByVal pFileName As String, ByVal pDataSet As DataSet, ByVal pSearchcode As String) As Boolean
        Try
            'Create a workbook instance
            Dim workbook As Workbook = New Workbook()
            Dim worksheet As Worksheet
            Dim iRow As Integer = 0
            Dim iCol As Integer = 0
            Dim sTemp As String = String.Empty
            Dim dTemp As Double = 0
            Dim decTemp As Decimal = 0
            Dim iTemp As Integer = 0
            Dim dtTemp As DateTime
            Dim count As Integer = 0
            Dim iTotalRows As Integer = 0
            Dim iSheetCount As Integer = 0

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFieldCode, v_strFieldType, v_strFieldName, v_str_EN_FieldName As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strFLDKEYTMP As String = "["
            Dim v_strSQL As String = "SELECT FIELDCODE,  FIELDNAME , EN_FIELDNAME  FROM SEARCHFLD WHERE SEARCHCODE='" & pSearchcode & "' AND DISPLAY ='Y' ORDER BY  POSITION "
            Dim v_ws As New BDSDeliveryManagement
            Dim v_hf As New Hashtable

            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "FIELDCODE"
                                v_strFieldCode = v_strVALUE
                                v_strFLDKEYTMP = v_strFLDKEYTMP & v_strFieldCode & "]["
                            Case "FIELDNAME"
                                v_strFieldName = v_strVALUE
                            Case "EN_FIELDNAME"
                                v_str_EN_FieldName = v_strVALUE
                        End Select
                    End With
                Next
                If v_strFieldCode.Length > 0 Then
                    v_hf.Add(v_strFieldCode, v_strFieldName)
                End If
            Next

            'Read DataSet
            If Not pDataSet Is Nothing And pDataSet.Tables.Count > 0 Then

                'Traverse DataTable inside the DataSet
                For Each dt As DataTable In pDataSet.Tables

                    'Create a worksheet instance
                    iSheetCount = iSheetCount + 1
                    worksheet = New Worksheet("Sheet" & iSheetCount.ToString())

                    'Write Table Header
                    For Each dc As DataColumn In dt.Columns
                        If InStr(v_strFLDKEYTMP, "[" & dc.ColumnName & "]") > 0 Then
                            worksheet.Cells(iRow, iCol) = New Cell(v_hf(dc.ColumnName))
                            iCol = iCol + 1
                        End If
                    Next

                    'Write Table Body
                    iRow = 1
                    For Each dr As DataRow In dt.Rows
                        iCol = 0
                        For Each dc As DataColumn In dt.Columns
                            If InStr(v_strFLDKEYTMP, "[" & dc.ColumnName & "]") > 0 Then
                                sTemp = dr(dc.ColumnName).ToString()
                                Select Case dc.DataType.Name
                                    Case GetType(System.DateTime).Name
                                        'DateTime.TryParse(sTemp, dtTemp)
                                        dtTemp = DDMMYYYY_SystemDate(sTemp)
                                        Dim strVal As String = String.Empty
                                        strVal = FormatDateTime(dtTemp, DateFormat.ShortDate)
                                        worksheet.Cells(iRow, iCol) = New Cell(strVal)
                                    Case GetType(System.Double).Name
                                        Double.TryParse(sTemp, dTemp)
                                        worksheet.Cells(iRow, iCol) = New Cell(dTemp, "#,##0.00")
                                    Case GetType(System.Decimal).Name
                                        Decimal.TryParse(sTemp, decTemp)
                                        worksheet.Cells(iRow, iCol) = New Cell(decTemp, "#,##0.00")
                                    Case Else
                                        worksheet.Cells(iRow, iCol) = New Cell(sTemp)
                                End Select
                                iCol = iCol + 1
                            End If
                        Next
                        iRow = iRow + 1
                    Next

                    'Attach worksheet to workbook
                    workbook.Worksheets.Add(worksheet)
                    iTotalRows = iTotalRows + iRow
                Next
            End If


            workbook.Save(pFileName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub ExportData(v_strFileName As String, gridControl As DevExpress.XtraGrid.GridControl, v_filetype As String)
        'Throw New NotImplementedException
        Try
            Select Case v_filetype
                Case ".xls"
                    gridControl.ExportToXls(v_strFileName)
                Case ".xlsx"
                    gridControl.ExportToXlsx(v_strFileName)
                Case ".rtf"
                    gridControl.ExportToRtf(v_strFileName)
                Case ".pdf"
                    gridControl.ExportToPdf(v_strFileName)
                Case ".html"
                    gridControl.ExportToHtml(v_strFileName)
                Case ".mht"
                    gridControl.ExportToMht(v_strFileName)
                Case ".csv" 'thunt-03/01/2019: xu ly xuat csv
                    gridControl.ExportToCsv(v_strFileName, New DevExpress.XtraPrinting.CsvExportOptions() With {.Encoding = System.Text.UnicodeEncoding.UTF8})
                Case ".txt" 'thunt-03/01/2019: xu ly xuat txt
                    gridControl.ExportToText(v_strFileName, New DevExpress.XtraPrinting.TextExportOptions() With {.Encoding = System.Text.UnicodeEncoding.UTF8})
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

End Class
