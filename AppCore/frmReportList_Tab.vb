Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns

Public Class frmReportList_Tab
    Inherits FormBase

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmReportList-"

    Private mv_strIsPublic As String
    Private mv_strIsFixPara As String
    Private mv_strInitPara As String
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strArea As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_strLocalObject As String
    Private mv_strBranchId As String                            'Là mã chi nhánh/đại lý
    Private mv_strTellerId As String
    Private mv_strKeyColumn As String
    Private mv_strBusDate As String
    Private mv_strBANK As String                                'Là tên đơn vị
    Private mv_strBRNAME As String                              'Là tên chi nhánh/đại lý
    Private mv_strTELLER As String                              'Là tên ngư?i s�ử dụng
    Private mv_AutoClose As Boolean = False
    Private mv_strGroupCareBy As String
    Protected mv_strTableName As String
    Public mv_strCMDID As String
    Private mv_strDefaultRPTID As String = String.Empty


    Private mv_arrSTOREDNAME() As String                         'Mảng lưu trữ Stored Name để lấy dữ liệu báo cáo
    Private mv_arrRPTID() As String                             'Mảng lưu trữ CMDID của các báo cáo
    Private mv_arrRPTNAME() As String                           'Là tiêu đ? c�ủa báo cáo
    Private mv_arrISLOCAL() As String                           'Noi lay du lieu bao cao
    Private mv_arrSTRAUTH() As String                           'Noi lay quyen dc phan cho BC
    Private mv_arrDATETIME() As Date                            'Là ngày tạo báo cáo
    Private mv_arrPAPER() As String                               'Là size giấy
    Private mv_arrORIENTATION() As String                         'Là chi?u gi�ấy báo cáo (portrait or landscape)
    Private mv_arrISCAREBY() As String
    Private mv_arrSUBRPT() As String                            'Bao cao bao gom subreport hay khong
    Private mv_arrISCMP() As String                            'Bao cao bao gom doi chieu du lieu voi file
    Private mv_arrArea() As String
    Private mv_arrISADHOC() As String

    Private mv_strReportDirectory As String
    Friend WithEvents lblBRID As System.Windows.Forms.Label
    Private mv_strReportTempDirectory As String

    Private mv_intAreaIndex As Integer = 0
    Friend WithEvents gridRPT As DevExpress.XtraGrid.GridControl
    Protected WithEvents viewRPT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataTable8 As System.Data.DataTable
    Dim hAreaFilter As New Hashtable

#End Region

#Region " Properties "
    Public Property IsFixPara() As String
        Get
            Return mv_strIsFixPara
        End Get
        Set(ByVal Value As String)
            mv_strIsFixPara = Value
        End Set
    End Property

    Public Property InitPara() As String
        Get
            Return mv_strInitPara
        End Get
        Set(ByVal Value As String)
            mv_strInitPara = Value
        End Set
    End Property

    Public Property RPTID() As String
        Get
            Return mv_strDefaultRPTID
        End Get
        Set(ByVal Value As String)
            mv_strDefaultRPTID = Value
        End Set
    End Property

    Public Property IsPublic() As String
        Get
            Return mv_strIsPublic
        End Get
        Set(ByVal Value As String)
            mv_strIsPublic = Value
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

    Public Property AutoClose() As Boolean
        Get
            Return mv_AutoClose
        End Get
        Set(ByVal Value As Boolean)
            mv_AutoClose = Value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return mv_strArea
        End Get
        Set(ByVal Value As String)
            mv_strArea = Value
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
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
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


    Public Property ReportDirectory() As String
        Get
            Return mv_strReportDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportDirectory = Value
        End Set
    End Property


    Public Property ReportTempDirectory() As String
        Get
            Return mv_strReportTempDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportTempDirectory = Value
        End Set
    End Property
    Public Property KeyColumn() As String
        Get
            Return mv_strKeyColumn
        End Get
        Set(ByVal Value As String)
            mv_strKeyColumn = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
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

    Public Property CMDID() As String
        Get
            Return mv_strCMDID
        End Get
        Set(ByVal Value As String)
            mv_strCMDID = Value
        End Set
    End Property
#End Region

#Region " Overridable function "
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

    Private Function ChooseFolder(ByVal v_strFilter As String) As String
        Try
            Dim v_FOLDERDlg As New FolderBrowserDialog
            With v_FOLDERDlg
                .SelectedPath = "C:\"

            End With
            If v_FOLDERDlg.ShowDialog() = DialogResult.OK Then
                Me.txtPATH.Text = v_FOLDERDlg.SelectedPath
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetRptTempFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & TellerId & ".rpt"
    End Function

    Private Function GetRptTemplateFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & ".rpt"
    End Function

    Private Function CreateReport(ByVal v_ds As DataSet, ByVal v_strRPTID As String, ByVal v_strRptTempFile As String) As Boolean
        Dim v_rptDocument As New ReportDocument
        Dim pv_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_strRptFilePath As String = GetRptTemplateFilePath(v_strRPTID)
            'Lay file template
            v_rptDocument.Load(ReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            'Doc thong tin tham so
            Dim v_streamReader As New StreamReader(ReportTempDirectory & v_strRptTempFile)
            pv_xmlDocument.LoadXml(v_streamReader.ReadToEnd)
            v_streamReader.Close()
            Dim i, j, v_count As Integer
            v_count = pv_xmlDocument.DocumentElement.Attributes.Count
            If v_count > 0 Then
                For i = 0 To v_count - 1 Step 1
                    v_rptDocument.DataDefinition.FormulaFields.Item(pv_xmlDocument.DocumentElement.Attributes(i).Name).Text = _
                        pv_xmlDocument.DocumentElement.Attributes(i).Value
                Next
            End If
            'Export du lieu theo 
            v_rptDocument.SetDataSource(v_ds)
            v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, ReportTempDirectory & GetRptTempFilePath(v_strRPTID))
            'Xoa file temp
            File.Delete(ReportTempDirectory & v_strRptTempFile)
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        Finally
            v_rptDocument = Nothing
            pv_xmlDocument = Nothing
        End Try
    End Function

    Public Overridable Sub OnDownload()
        Dim mv_arrRptParam() As ReportParameters
        Dim v_strObjMsg, v_strRptMsg, v_strRptPendingFile, v_strRPTID As String
        Dim v_xmlDocumentMessage As New Xml.XmlDocument
        Dim v_xmlRptMessage As New Xml.XmlDocument
        Dim v_ds As DataSet
        'TruongLD Comment when convert
        'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
        'TruongLD Add when convert
        Dim v_ws As New BDSRptDeliveryManagement
        'End TruongLD
        Dim v_nodeList As Xml.XmlNodeList, i, j As Integer
        Try
            v_strObjMsg = BuildXMLRptMsg(gc_IsNotLocalMsg, "DOWNLOAD", gc_MsgTypeProc, mv_arrRptParam, 0)
            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "GetReturnReport"

            'Lay danh sach cac bao cao dang cho xu ly
            Dim v_dirInfo As New DirectoryInfo(ReportTempDirectory)
            Dim pv_strReportFileName As String = "_REQUEST" & "_" & BranchId & "_" & TellerId & "_"
            Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles("*" & pv_strReportFileName & "*.xml")
            Dim v_fileInfo As FileInfo
            If v_arrReportFiles.Length > 0 Then
                For Each v_fileInfo In v_arrReportFiles
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_fileInfo.Name
                    v_strObjMsg = v_xmlDocumentMessage.InnerXml
                    v_ws.Message(v_strObjMsg)
                    v_xmlRptMessage.LoadXml(v_strObjMsg)
                    'Kiem tra ket qua tra ve
                    If v_xmlRptMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = "DONE" Then
                        v_nodeList = v_xmlRptMessage.SelectNodes("/ObjectMessage/RptFiles")
                        If v_nodeList.Item(0).ChildNodes.Count > 0 Then
                            v_strRptMsg = v_nodeList.Item(0).ChildNodes(0).InnerText
                            v_xmlRptMessage.LoadXml(v_strRptMsg)
                            v_ds = ConvertXmlDocToDataSet(v_xmlRptMessage)
                            j = v_fileInfo.Name.IndexOf(pv_strReportFileName)
                            v_strRPTID = v_fileInfo.Name.Substring(j + pv_strReportFileName.Length)
                            v_strRPTID = v_strRPTID.Substring(0, 6)
                            CreateReport(v_ds, v_strRPTID, v_fileInfo.Name)
                        End If
                        'Refresh lai man hinh
                    End If
                Next
                ShowReportList()
            End If
            MessageBox.Show(mv_ResourceManager.GetString("frmReportList.msgDownload"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not v_ds Is Nothing Then v_ds.Dispose()
            v_xmlDocumentMessage = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub OnGetReportPending()
        Dim mv_arrRptParam() As ReportParameters
        Dim v_strObjMsg, v_strRptMsg, v_strRptPendingFile As String
        Dim v_xmlDocumentMessage As New Xml.XmlDocument
        Dim v_xmlRptMessage As New Xml.XmlDocument
        'TruongLD Comment when convert
        'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
        'TruongLD Add when convert
        Dim v_ws As New BDSRptDeliveryManagement
        'End TruongLD
        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Try
            'Lay danh sach cac bao cao dang pending tren HOST
            v_strObjMsg = BuildXMLRptMsg(gc_IsNotLocalMsg, "GETREPORT", gc_MsgTypeProc, mv_arrRptParam, 0)
            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "GetPendingReport"
            v_strObjMsg = v_xmlDocumentMessage.InnerXml
            v_ws.Message(v_strObjMsg)
            v_xmlDocumentMessage.LoadXml(v_strObjMsg)

            'Thuc hien cac bao cao
            v_strRptMsg = BuildXMLRptMsg(gc_IsNotLocalMsg, "RUNREPORT", gc_MsgTypeProc, mv_arrRptParam, 0)
            v_xmlRptMessage.LoadXml(v_strRptMsg)
            v_xmlRptMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
            v_xmlRptMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
            v_xmlRptMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
            v_nodeList = v_xmlDocumentMessage.SelectNodes("/ObjectMessage/RptFiles")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                v_strRptPendingFile = v_nodeList.Item(0).ChildNodes(i).InnerText
                v_xmlRptMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = v_strRptPendingFile
                v_strRptMsg = v_xmlRptMessage.InnerXml
                v_ws.Message(v_strRptMsg)
            Next
            MessageBox.Show(mv_ResourceManager.GetString("frmReportList.msgRptPending"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlDocumentMessage = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub OnView(Optional ByVal Row As String = "")
        Dim v_strAdhoc As String = String.Empty
        'TruongLD Add 14/09/2011
        'Neu dung Culture la "vi-VN" --> khong su dung duoc func Convert Number to Text --> Chuyen ve "en-US"
        'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
        Dim v_strOldCultureName As String = String.Empty
        v_strOldCultureName = SetCultureInfo("en-US")
        'End TruongLD
        Try
            If (viewRPT.RowCount > 0) Then
                For i As Integer = 0 To viewRPT.RowCount - 1
                    If Row = "" Then
                        If (viewRPT.GetFocusedDataRow Is viewRPT.GetDataRow(i)) Then
                            Dim dr As DataRow = viewRPT.GetFocusedDataRow
                            If mv_arrISADHOC(i) = "Y" Then
                                If Not File.Exists(ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))) Then
                                    MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return
                                End If
                                Dim v_frm As New frmReportView
                                Dim v_Path As String = Environment.CurrentDirectory
                                v_frm.RptFileName = ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))
                                v_frm.RptName = mv_arrRPTNAME(i)
                                v_frm.ShowDialog()
                                Environment.CurrentDirectory = v_Path
                            Else
                                If Not File.Exists(ReportTempDirectory & GetReportFileNameStandard(dr("RPTID"))) Then
                                    MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return
                                End If
                                Dim report As XtraReport = New XtraReport()
                                report.PrintingSystem.LoadDocument(ReportTempDirectory & GetReportFileNameStandard(dr("RPTID")))
                                report.ShowPreview()
                            End If
                            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
                            Exit Sub
                        End If
                    Else
                        If viewRPT.GetDataRow(i)("RPTID") = Row Then

                            If Not File.Exists(ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))) Then
                                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If

                            If mv_arrISADHOC(i) = "Y" Then
                                Dim v_frm As New frmReportView
                                Dim v_Path As String = Environment.CurrentDirectory
                                v_frm.RptFileName = ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))
                                v_frm.RptName = mv_arrRPTNAME(i)
                                v_frm.ShowDialog()
                                Environment.CurrentDirectory = v_Path
                            Else
                                Dim report As XtraReport = New XtraReport()
                                report.PrintingSystem.LoadDocument(ReportTempDirectory & GetReportFileNameStandard(mv_arrRPTID(i)))
                                report.ShowPreview()
                            End If
                            'TruongLD Add 14/09/2011
                            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                            'v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
                            'End TruongLD
                            Exit Sub
                        End If
                    End If
                Next

                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            'TruongLD Add 14/09/2011
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            'End TruongLD
        End Try
    End Sub

    Public Overridable Sub OnPrint()
        Try
            If (viewRPT.RowCount > 0) Then
                For i As Integer = 0 To viewRPT.RowCount - 1
                    If (viewRPT.GetFocusedDataRow Is viewRPT.GetDataRow(i)) Then
                        Dim dr As DataRow = viewRPT.GetDataRow(i)
                        If dr("AD_HOC") = "Y" Then
                            If Not File.Exists(ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))) Then
                                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If

                            If mv_arrDATETIME(i).Year > 1 Then
                                Dim v_frm As New frmReportView
                                Dim v_Path As String = Environment.CurrentDirectory
                                v_frm.RptFileName = ReportTempDirectory & "\" & GetReportFileName(mv_arrRPTID(i))
                                v_frm.RptName = mv_arrRPTNAME(i)
                                v_frm.ShowDialog()
                                Environment.CurrentDirectory = v_Path
                            End If
                        ElseIf dr("AD_HOC") = "N" Then
                            If Not File.Exists(ReportTempDirectory & GetReportFileNameStandard(mv_arrRPTID(i))) Then
                                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If

                            If mv_arrDATETIME(i).Year > 1 Then
                                Dim report As XtraReport = New XtraReport()
                                report.PrintingSystem.LoadDocument(ReportTempDirectory & GetReportFileNameStandard(mv_arrRPTID(i)))
                                report.Print()
                            End If
                        End If
                        Exit Sub
                    End If
                Next

                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnReCreate(ByVal v_strRPTID As String)
        Try
            Dim RowKey As String
            If (viewRPT.RowCount > 0) Then
                For i As Integer = 0 To viewRPT.RowCount - 1
                    If viewRPT.GetDataRow(i)("RPTID") = v_strRPTID Then
                        'Xác định báo cáo mặc định
                        If Not viewRPT.GetFocusedDataRow Is Nothing Then
                            RowKey = viewRPT.GetFocusedDataRow()("RPTID")
                        End If
                        Dim v_frm As New frmReportParameter

                        v_frm.BranchId = Me.BranchId
                        v_frm.ModuleCode = Me.ModuleCode
                        v_frm.ObjectName = mv_arrRPTID(i)
                        v_frm.TellerId = Me.TellerId
                        'v_frm.BranchId = Me.BranchId
                        v_frm.LocalObject = mv_arrISLOCAL(i)
                        v_frm.BranchName = mv_strBRNAME
                        v_frm.Teller = mv_strTELLER
                        v_frm.ReportTitle = mv_arrRPTNAME(i)
                        v_frm.StoredName = mv_arrSTOREDNAME(i)
                        v_frm.ReportTimeCreated = mv_arrDATETIME(i)
                        v_frm.CMDID = mv_arrRPTID(i)
                        v_frm.IsCareBy = mv_arrISCAREBY(i)
                        v_frm.IsSubRPT = mv_arrSUBRPT(i)
                        v_frm.ISCMP = mv_arrISCMP(i)
                        v_frm.ISADHOC = mv_arrISADHOC(i)
                        v_frm.UserLanguage = Me.UserLanguage
                        v_frm.ReportDirectory = ReportDirectory
                        v_frm.ReportTempDirectory = ReportTempDirectory
                        v_frm.BusDate = BusDate
                        v_frm.GroupCareBy = GroupCareBy
                        v_frm.ReportArea = IIf(Me.BranchId = HO_MBID, gc_REPORT_AREA_ALL, gc_REPORT_AREA_BRANCH) ' Sua cho hien thi toan bo chi nhanh doi voi menu goi nhanh, tham so cu = gc_REPORT_AREA_BRANCH
                        v_frm.IsFixPara = Me.IsFixPara
                        v_frm.InitPara = Me.InitPara


                        v_frm.ShowDialog()
                        If mv_AutoClose = True Then
                            Me.Close()
                        End If
                        mv_arrDATETIME(i) = v_frm.ReportTimeCreated
                        If Not Me.RPTID.Length > 0 Then
                            ShowReportList()
                        End If
                        RPTID = String.Empty
                        'Refrest list view to show the report list

                        'If v_frm.ReturnExecuted = 1 Then
                        'OnView(RowKey)
                        'End If
                        Exit Sub
                    End If
                Next

                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    'T07/2017 STP Chuyen Public --> Protected
    'Public Overridable Sub OnReCreate()
    Protected Overridable Sub OnReCreate()
        Try
            Dim RowKey As String
            If (viewRPT.RowCount > 0) Then
                For i As Integer = 0 To viewRPT.RowCount - 1
                    If (viewRPT.GetFocusedDataRow Is viewRPT.GetDataRow(i)) Then
                        'Call frmReportParameter to re-create the report
                        If Not viewRPT.GetFocusedDataRow Is Nothing Then
                            RowKey = viewRPT.GetFocusedDataRow()("RPTID")
                            ' ReportList.CurrentRow.
                        End If
                        Dim v_frm As New frmReportParameter
                        Dim itemIndex As Int32 = Array.IndexOf(mv_arrRPTID, RowKey)
                        v_frm.BranchId = Me.BranchId
                        v_frm.ModuleCode = Me.ModuleCode
                        v_frm.ObjectName = mv_arrRPTID(itemIndex)
                        v_frm.TellerId = Me.TellerId
                        'v_frm.BranchId = Me.BranchId
                        v_frm.LocalObject = mv_arrISLOCAL(itemIndex)
                        v_frm.BranchName = mv_strBRNAME
                        v_frm.Teller = mv_strTELLER
                        v_frm.ReportTitle = mv_arrRPTNAME(itemIndex)
                        v_frm.StoredName = mv_arrSTOREDNAME(itemIndex)
                        v_frm.ReportTimeCreated = mv_arrDATETIME(itemIndex)
                        v_frm.CMDID = mv_arrRPTID(itemIndex)
                        v_frm.IsCareBy = mv_arrISCAREBY(itemIndex)
                        v_frm.IsSubRPT = mv_arrSUBRPT(itemIndex)
                        v_frm.ISCMP = mv_arrISCMP(itemIndex)
                        v_frm.UserLanguage = Me.UserLanguage
                        v_frm.ReportDirectory = ReportDirectory
                        v_frm.ReportTempDirectory = ReportTempDirectory
                        v_frm.BusDate = BusDate
                        v_frm.GroupCareBy = GroupCareBy
                        v_frm.ReportArea = gc_REPORT_AREA_ALL
                        v_frm.ISADHOC = mv_arrISADHOC(itemIndex)
                        v_frm.ShowDialog()
                        mv_arrDATETIME(i) = v_frm.ReportTimeCreated

                        'Refrest list view to show the report list
                        ShowReportList()
                        'If v_frm.ReturnExecuted = 1 Then
                        'OnView(RowKey)
                        'End If
                        Exit Sub
                    End If
                Next

                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    'T07/2017 STP: Them ham OnCreateReq
    Public Overridable Sub OnCreateReq()
        Try
            'Kiem tra pham vi xem bao cao
            'If cboAREA.Items.Count > 0 And Not hAreaFilter(cboAREA.SelectedValue) Is Nothing Then
            '    If hAreaFilter(cboAREA.SelectedValue) < mv_intAreaIndex Then
            '        MessageBox.Show(mv_ResourceManager.GetString("ReportAreaNotAllow") & cboAREA.Text & "!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Exit Sub
            '    End If
            'End If

            Dim RowKey As String
            If (viewRPT.RowCount > 0) Then
                For i As Integer = 0 To viewRPT.RowCount - 1
                    If (viewRPT.GetFocusedDataRow Is viewRPT.GetDataRow(i)) Then
                        'Call frmReportParameter to re-create the report
                        If Not viewRPT.GetFocusedDataRow Is Nothing Then
                            RowKey = viewRPT.GetFocusedDataRow()("RPTID")
                            ' ReportList.CurrentRow.
                        End If
                        Dim v_frm As New frmReportParameter
                        Dim itemIndex As Int32 = Array.IndexOf(mv_arrRPTID, RowKey)

                        If Me.cboAREA.SelectedValue = "A" Then
                            v_frm.BranchId = Me.BranchId
                        ElseIf Me.cboAREA.SelectedValue = "B" Then
                            v_frm.BranchId = Me.cboBRID.SelectedValue
                        ElseIf Me.cboAREA.SelectedValue = "S" Then
                            v_frm.BranchId = Me.cboAGENTID.SelectedValue
                        End If

                        v_frm.ModuleCode = Me.ModuleCode
                        v_frm.ObjectName = mv_arrRPTID(itemIndex)
                        v_frm.TellerId = Me.TellerId
                        'v_frm.BranchId = Me.BranchId
                        v_frm.LocalObject = mv_arrISLOCAL(itemIndex)
                        v_frm.BranchName = mv_strBRNAME
                        v_frm.Teller = mv_strTELLER
                        v_frm.ReportTitle = mv_arrRPTNAME(itemIndex)
                        v_frm.StoredName = mv_arrSTOREDNAME(itemIndex)
                        v_frm.ReportTimeCreated = mv_arrDATETIME(itemIndex)
                        v_frm.CMDID = mv_arrRPTID(itemIndex)
                        v_frm.IsCareBy = mv_arrISCAREBY(itemIndex)
                        v_frm.IsSubRPT = mv_arrSUBRPT(itemIndex)
                        v_frm.ISCMP = mv_arrISCMP(itemIndex)
                        v_frm.ISADHOC = mv_arrISADHOC(itemIndex)
                        v_frm.UserLanguage = Me.UserLanguage
                        v_frm.ReportDirectory = ReportDirectory
                        v_frm.ReportTempDirectory = ReportTempDirectory
                        v_frm.BusDate = BusDate
                        v_frm.GroupCareBy = GroupCareBy

                        If cboAGENTID.Items.Count > 0 Then
                            v_frm.ReportArea = gc_REPORT_AREA_AGENT
                        ElseIf cboAGENTID.Items.Count = 0 And cboBRID.Items.Count > 0 Then
                            v_frm.ReportArea = gc_REPORT_AREA_BRANCH
                        Else
                            v_frm.ReportArea = gc_REPORT_AREA_ALL
                        End If

                        v_frm.ShowDialog()
                        mv_arrDATETIME(itemIndex) = v_frm.ReportTimeCreated

                        Exit Sub
                    End If
                Next

                MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub
    'End T07/2017 STP: Them ham OnCreateReq

    Public Overridable Sub OnClose()
        Me.CloseTab()
    End Sub
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
    'T07/2017 STP: Chuyen Friend --> thanh Protected
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Protected WithEvents btnView As System.Windows.Forms.Button
    Protected WithEvents btnPrint As System.Windows.Forms.Button
    Protected WithEvents btnRecreat As System.Windows.Forms.Button
    Protected WithEvents btnClose As System.Windows.Forms.Button
    Protected WithEvents grbReportOption As System.Windows.Forms.GroupBox
    Protected WithEvents grbReportList As System.Windows.Forms.GroupBox
    Protected WithEvents cboAREA As ComboBoxEx
    Protected WithEvents cboAGENTID As ComboBoxEx
    Protected WithEvents cboBRID As ComboBoxEx
    Protected WithEvents lblAGENTID As System.Windows.Forms.Label
    Protected WithEvents lblAREA As System.Windows.Forms.Label
    Protected WithEvents pnlReportList As System.Windows.Forms.Panel
    Protected WithEvents txtPATH As System.Windows.Forms.TextBox
    Protected WithEvents btnGenerate As System.Windows.Forms.Button
    Protected WithEvents cboEXCYCLE As AppCore.ComboBoxEx
    Protected WithEvents lblEXCYCLE As System.Windows.Forms.Label
    Protected WithEvents btnBROWSER As System.Windows.Forms.Button
    Protected WithEvents btnDownload As System.Windows.Forms.Button
    Protected WithEvents btnRptPending As System.Windows.Forms.Button
    'End T07/2017 STP: Chuyen Friend --> thanh Protected
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportList_Tab))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.grbReportOption = New System.Windows.Forms.GroupBox()
        Me.txtPATH = New System.Windows.Forms.TextBox()
        Me.cboAREA = New AppCore.ComboBoxEx()
        Me.cboAGENTID = New AppCore.ComboBoxEx()
        Me.btnBROWSER = New System.Windows.Forms.Button()
        Me.cboBRID = New AppCore.ComboBoxEx()
        Me.lblBRID = New System.Windows.Forms.Label()
        Me.lblAGENTID = New System.Windows.Forms.Label()
        Me.lblAREA = New System.Windows.Forms.Label()
        Me.cboEXCYCLE = New AppCore.ComboBoxEx()
        Me.lblEXCYCLE = New System.Windows.Forms.Label()
        Me.grbReportList = New System.Windows.Forms.GroupBox()
        Me.pnlReportList = New System.Windows.Forms.Panel()
        Me.gridRPT = New DevExpress.XtraGrid.GridControl()
        Me.viewRPT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnRecreat = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnRptPending = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataTable8 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.grbReportOption.SuspendLayout()
        Me.grbReportList.SuspendLayout()
        Me.pnlReportList.SuspendLayout()
        CType(Me.gridRPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewRPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 50)
        Me.Panel1.TabIndex = 1
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "Caption"
        Me.lblCaption.Text = "lblCaption"
        '
        'grbReportOption
        '
        Me.grbReportOption.BackColor = System.Drawing.SystemColors.Control
        Me.grbReportOption.Controls.Add(Me.txtPATH)
        Me.grbReportOption.Controls.Add(Me.cboAREA)
        Me.grbReportOption.Controls.Add(Me.cboAGENTID)
        Me.grbReportOption.Controls.Add(Me.btnBROWSER)
        Me.grbReportOption.Controls.Add(Me.cboBRID)
        Me.grbReportOption.Controls.Add(Me.lblBRID)
        Me.grbReportOption.Controls.Add(Me.lblAGENTID)
        Me.grbReportOption.Controls.Add(Me.lblAREA)
        Me.grbReportOption.Controls.Add(Me.cboEXCYCLE)
        Me.grbReportOption.Controls.Add(Me.lblEXCYCLE)
        Me.grbReportOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbReportOption.Location = New System.Drawing.Point(6, 55)
        Me.grbReportOption.Name = "grbReportOption"
        Me.grbReportOption.Size = New System.Drawing.Size(780, 57)
        Me.grbReportOption.TabIndex = 0
        Me.grbReportOption.TabStop = False
        Me.grbReportOption.Tag = "ReportOption"
        Me.grbReportOption.Text = "grbReportOption"
        '
        'txtPATH
        '
        Me.txtPATH.Location = New System.Drawing.Point(280, 24)
        Me.txtPATH.Name = "txtPATH"
        Me.txtPATH.Size = New System.Drawing.Size(494, 20)
        Me.txtPATH.TabIndex = 8
        '
        'cboAREA
        '
        Me.cboAREA.DisplayMember = "DISPLAY"
        Me.cboAREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAREA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAREA.Location = New System.Drawing.Point(64, 24)
        Me.cboAREA.Name = "cboAREA"
        Me.cboAREA.Size = New System.Drawing.Size(136, 21)
        Me.cboAREA.TabIndex = 0
        Me.cboAREA.Tag = "AREA"
        Me.cboAREA.ValueMember = "VALUE"
        '
        'cboAGENTID
        '
        Me.cboAGENTID.DisplayMember = "DISPLAY"
        Me.cboAGENTID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAGENTID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAGENTID.Location = New System.Drawing.Point(568, 24)
        Me.cboAGENTID.Name = "cboAGENTID"
        Me.cboAGENTID.Size = New System.Drawing.Size(206, 21)
        Me.cboAGENTID.TabIndex = 2
        Me.cboAGENTID.Tag = "AGENTID"
        Me.cboAGENTID.ValueMember = "VALUE"
        '
        'btnBROWSER
        '
        Me.btnBROWSER.Location = New System.Drawing.Point(202, 23)
        Me.btnBROWSER.Name = "btnBROWSER"
        Me.btnBROWSER.Size = New System.Drawing.Size(75, 23)
        Me.btnBROWSER.TabIndex = 18
        Me.btnBROWSER.Tag = "btnBROWSER"
        Me.btnBROWSER.Text = "btnBROWSER"
        '
        'cboBRID
        '
        Me.cboBRID.DisplayMember = "DISPLAY"
        Me.cboBRID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBRID.Location = New System.Drawing.Point(272, 24)
        Me.cboBRID.Name = "cboBRID"
        Me.cboBRID.Size = New System.Drawing.Size(205, 21)
        Me.cboBRID.TabIndex = 1
        Me.cboBRID.Tag = "BRID"
        Me.cboBRID.ValueMember = "VALUE"
        '
        'lblBRID
        '
        Me.lblBRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBRID.Location = New System.Drawing.Point(208, 24)
        Me.lblBRID.Name = "lblBRID"
        Me.lblBRID.Size = New System.Drawing.Size(64, 21)
        Me.lblBRID.TabIndex = 2
        Me.lblBRID.Tag = "BRID"
        Me.lblBRID.Text = "Chi nhánh:"
        Me.lblBRID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAGENTID
        '
        Me.lblAGENTID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAGENTID.Location = New System.Drawing.Point(483, 24)
        Me.lblAGENTID.Name = "lblAGENTID"
        Me.lblAGENTID.Size = New System.Drawing.Size(79, 21)
        Me.lblAGENTID.TabIndex = 2
        Me.lblAGENTID.Tag = "AGENTID"
        Me.lblAGENTID.Text = "Đại lý:"
        Me.lblAGENTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAREA
        '
        Me.lblAREA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAREA.Location = New System.Drawing.Point(6, 24)
        Me.lblAREA.Name = "lblAREA"
        Me.lblAREA.Size = New System.Drawing.Size(58, 21)
        Me.lblAREA.TabIndex = 1
        Me.lblAREA.Tag = "AREA"
        Me.lblAREA.Text = "Phạm vi:"
        Me.lblAREA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEXCYCLE
        '
        Me.cboEXCYCLE.DisplayMember = "DISPLAY"
        Me.cboEXCYCLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEXCYCLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEXCYCLE.Location = New System.Drawing.Point(88, 24)
        Me.cboEXCYCLE.Name = "cboEXCYCLE"
        Me.cboEXCYCLE.Size = New System.Drawing.Size(112, 21)
        Me.cboEXCYCLE.TabIndex = 1
        Me.cboEXCYCLE.Tag = "AREA"
        Me.cboEXCYCLE.ValueMember = "VALUE"
        '
        'lblEXCYCLE
        '
        Me.lblEXCYCLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEXCYCLE.Location = New System.Drawing.Point(10, 24)
        Me.lblEXCYCLE.Name = "lblEXCYCLE"
        Me.lblEXCYCLE.Size = New System.Drawing.Size(54, 21)
        Me.lblEXCYCLE.TabIndex = 2
        Me.lblEXCYCLE.Tag = "EXCYCLE"
        Me.lblEXCYCLE.Text = "lblEXCYCLE"
        Me.lblEXCYCLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbReportList
        '
        Me.grbReportList.BackColor = System.Drawing.SystemColors.Control
        Me.grbReportList.Controls.Add(Me.pnlReportList)
        Me.grbReportList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbReportList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbReportList.Location = New System.Drawing.Point(0, 50)
        Me.grbReportList.Name = "grbReportList"
        Me.grbReportList.Size = New System.Drawing.Size(792, 335)
        Me.grbReportList.TabIndex = 1
        Me.grbReportList.TabStop = False
        Me.grbReportList.Tag = "ReportList"
        Me.grbReportList.Text = "grbReportList"
        '
        'pnlReportList
        '
        Me.pnlReportList.BackColor = System.Drawing.SystemColors.Control
        Me.pnlReportList.Controls.Add(Me.gridRPT)
        Me.pnlReportList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReportList.Location = New System.Drawing.Point(3, 16)
        Me.pnlReportList.Name = "pnlReportList"
        Me.pnlReportList.Size = New System.Drawing.Size(786, 316)
        Me.pnlReportList.TabIndex = 0
        '
        'gridRPT
        '
        Me.gridRPT.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridRPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRPT.Location = New System.Drawing.Point(0, 0)
        Me.gridRPT.MainView = Me.viewRPT
        Me.gridRPT.Name = "gridRPT"
        Me.gridRPT.Size = New System.Drawing.Size(786, 316)
        Me.gridRPT.TabIndex = 0
        Me.gridRPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewRPT})
        '
        'viewRPT
        '
        Me.viewRPT.GridControl = Me.gridRPT
        Me.viewRPT.Name = "viewRPT"
        Me.viewRPT.OptionsBehavior.Editable = False
        Me.viewRPT.OptionsBehavior.ReadOnly = True
        Me.viewRPT.OptionsView.ShowAutoFilterRow = True
        Me.viewRPT.OptionsView.ShowFooter = True
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(548, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 3
        Me.btnView.Tag = "View"
        Me.btnView.Text = "btnView"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(627, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Tag = "Print"
        Me.btnPrint.Text = "btnPrint"
        '
        'btnRecreat
        '
        Me.btnRecreat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecreat.Location = New System.Drawing.Point(468, 4)
        Me.btnRecreat.Name = "btnRecreat"
        Me.btnRecreat.Size = New System.Drawing.Size(75, 23)
        Me.btnRecreat.TabIndex = 2
        Me.btnRecreat.Tag = "Recreat"
        Me.btnRecreat.Text = "btnRecreat"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(708, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Tag = "Close"
        Me.btnClose.Text = "btnClose"
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.Location = New System.Drawing.Point(627, 4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Tag = "Print"
        Me.btnGenerate.Text = "btnGenerate"
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Location = New System.Drawing.Point(386, 4)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Tag = "Download"
        Me.btnDownload.Text = "btnDownload"
        Me.btnDownload.Visible = False
        '
        'btnRptPending
        '
        Me.btnRptPending.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRptPending.Location = New System.Drawing.Point(305, 4)
        Me.btnRptPending.Name = "btnRptPending"
        Me.btnRptPending.Size = New System.Drawing.Size(75, 23)
        Me.btnRptPending.TabIndex = 2
        Me.btnRptPending.Tag = "RptPending"
        Me.btnRptPending.Text = "btnRptPending"
        Me.btnRptPending.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnGenerate)
        Me.Panel2.Controls.Add(Me.btnView)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnRptPending)
        Me.Panel2.Controls.Add(Me.btnRecreat)
        Me.Panel2.Controls.Add(Me.btnDownload)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 355)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 30)
        Me.Panel2.TabIndex = 7
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'frmReportList_Tab
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(792, 385)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grbReportList)
        Me.Controls.Add(Me.grbReportOption)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportList_Tab"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "ReportList"
        Me.Text = "frmReportList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbReportOption.ResumeLayout(False)
        Me.grbReportOption.PerformLayout()
        Me.grbReportList.ResumeLayout(False)
        Me.pnlReportList.ResumeLayout(False)
        CType(Me.gridRPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewRPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        OnClose()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        OnPrint()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        OnView()
    End Sub

    Private Sub btnRecreat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreat.Click
        OnReCreate()
    End Sub

    Private Sub frmReportList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    'T07/2017 STP Chuyen Private  --> Protected
    'Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Protected Overridable Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (sender Is cboAREA) Then
            'RemoveHandler cboAREA.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'RemoveHandler cboEXCYCLE.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            RemoveHandler cboBRID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            RemoveHandler cboAGENTID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            ''Kiem tra pham vi xem bao cao
            'If cboAREA.Items.Count > 0 And cboAREA.SelectedIndex < mv_intAreaIndex Then
            '    MessageBox.Show(mv_ResourceManager.GetString("ReportAreaNotAllow") & cboAREA.Text & "!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    cboAREA.SelectedIndex = mv_intAreaIndex
            '    Exit Sub
            'End If
            If (cboAREA.Items.Count > 0) And (Convert.ToString(cboAREA.SelectedValue) = gc_REPORT_AREA_BRANCH) Then
                cboBRID.Enabled = True
                FillBranchComboBox()

                If (cboAGENTID.Items.Count > 0) Then
                    cboAGENTID.Clears()
                End If
                cboAGENTID.Enabled = False
            ElseIf (cboAREA.Items.Count > 0) And (Convert.ToString(cboAREA.SelectedValue) = gc_REPORT_AREA_AGENT) Then
                cboBRID.Enabled = True
                FillBranchComboBox()

                cboAGENTID.Enabled = True
                FillAgentComboBox()
            Else
                If (cboBRID.Items.Count > 0) Then
                    cboBRID.Clears()
                End If
                cboBRID.Enabled = False
                If (cboAGENTID.Items.Count > 0) Then
                    cboAGENTID.Clears()
                End If
                cboAGENTID.Enabled = False
            End If
            'RemoveHandler cboAREA.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'AddHandler cboEXCYCLE.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            AddHandler cboBRID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            AddHandler cboAGENTID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        ElseIf (sender Is cboBRID) Then
            'RemoveHandler cboAREA.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'RemoveHandler cboEXCYCLE.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'RemoveHandler cboBRID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            RemoveHandler cboAGENTID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            If (cboAREA.Items.Count > 0) And (Convert.ToString(cboAREA.SelectedValue) = gc_REPORT_AREA_BRANCH) Then
                If (cboAGENTID.Items.Count > 0) Then
                    cboAGENTID.Clears()
                End If
                cboAGENTID.Enabled = False
            ElseIf (cboAREA.Items.Count > 0) And (Convert.ToString(cboAREA.SelectedValue) = gc_REPORT_AREA_AGENT) Then
                cboAGENTID.Enabled = True
                FillAgentComboBox()
            End If
            'RemoveHandler cboAREA.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'RemoveHandler cboEXCYCLE.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            'RemoveHandler cboBRID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
            AddHandler cboAGENTID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        ElseIf (sender Is cboAGENTID) Then
            'Do nothing
        End If

        'Show report list
        ShowReportList()
    End Sub

    Private Sub frmReportList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub


    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        OnGenerate()
    End Sub


    Private Sub btnRptPending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptPending.Click
        OnGetReportPending()
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        OnDownload()
    End Sub

    Private Sub btnBROWSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBROWSER.Click
        Try
            Dim v_FOLDERDlg As New FolderBrowserDialog
            v_FOLDERDlg.SelectedPath = "C:\"
            If v_FOLDERDlg.ShowDialog() = DialogResult.OK Then
                Me.txtPATH.Text = v_FOLDERDlg.SelectedPath & "\"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Other methods "
    Private Sub DynamicShowReport(ByVal v_strRPTID As String, ByVal v_strXMLDataFile As String)
        'Sử dụng cho các báo cáo được hiển thị tự động
    End Sub

    'T07/2017 STP Chuyen Private  --> Protected
    'Private Function InitDialog()
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        'InitGrid()
        InitGridControl()


        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        'Get report directory and report temporary directory
        ReportDirectory = GetReportDirectory()
        ReportTempDirectory = GetReportTempDirectory(ReportDirectory)

        'Load dữ liệu ban đầu cho các ComboBox
        FillAreaComboBox()
        FillBranchComboBox()
        FillAgentComboBox()
        FillExcycleComboBox()

        'Add Selected Index Changed event handler to ComboBoxes
        AddHandler cboAREA.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cboEXCYCLE.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cboBRID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cboAGENTID.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged


        'Hiển thị dữ liệu báo cáo ra form
        ShowReportList()

    End Function

    Private Sub InitGridControl()
        Me.viewRPT.Columns.Clear()
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.RPTID"), "RPTID", 40, 0))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.RPTNAME"), "RPTNAME", 400, 1))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.PAPER"), "PAPER", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.ORIENTATION"), "ORIENTATION", 50, 3))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.LASTCREATED"), "LASTCREATED", 60, 4))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.STOREDNAME"), "STOREDNAME", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.ISLOCAL"), "ISLOCAL", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.STRAUTH"), "STRAUTH", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.ISCAREBY"), "ISCAREBY", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.AREA"), "AREA", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.SUBRPT"), "SUBRPT", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.ISCMP"), "ISCMP", 0, -1, False))
        Me.viewRPT.Columns.Add(CreateColumn(mv_ResourceManager.GetString("grid.AD_HOC"), "AD_HOC", 0, -1, False))

        'Disable buttons
        btnRecreat.Enabled = False
        btnView.Enabled = False
        btnPrint.Enabled = False

    End Sub

    Public Function CreateColumn(ByVal caption As String, ByVal name As String, ByVal width As Integer, ByVal visibleIndex As Integer, Optional ByVal visible As Boolean = True) As GridColumn
        Dim col As GridColumn = New GridColumn()
        col.Caption = caption
        col.Name = name
        col.Visible = visible
        col.VisibleIndex = visibleIndex
        col.Width = width
        col.FieldName = name
        col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        Return col
    End Function

    Private Sub FillExcycleComboBox()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Fill data for cboExcycle ComboBox
            If Not (cboEXCYCLE.Items.Count > 0) Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE " _
                    & "WHERE CDTYPE = 'CF' AND CDNAME = 'EXCYCLE' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboEXCYCLE, "", Me.UserLanguage)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FillAreaComboBox()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            'Fill data for cboAREA ComboBox
            If Not (cboAREA.Items.Count > 0) Then
                v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, a.LSTODR " & ControlChars.CrLf _
                    & " FROM ALLCODE a, brgrp b " & ControlChars.CrLf _
                    & " WHERE CDTYPE = 'SY' AND CDNAME = 'AREA' AND brid = '" & Me.BranchId & "' " & ControlChars.CrLf _
                    & " AND instr((CASE WHEN brid = '" & HO_BRID & "' THEN 'ABS'  " & ControlChars.CrLf _
                    & " WHEN prbrid <> brid and prbrid = '" & HO_BRID & "' THEN 'BS'  " & ControlChars.CrLf _
                    & " ELSE 'S' end),cdval) <> 0 ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboAREA, "", Me.UserLanguage)

                'Ghi nhan du lieu vao mang bam de so sanh
                Dim v_xmlDocument As New XmlDocumentEx
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_strValue, v_strFLDNAME As String
                Dim v_strArea, v_strIndex As String

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    v_strArea = v_strValue.Trim()
                                Case "LSTODR"
                                    v_strIndex = v_strValue.Trim()
                            End Select
                        End With
                    Next
                    hAreaFilter.Add(v_strArea, v_strIndex)
                Next

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub FillBranchComboBox()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            If (cboAREA.Items.Count > 0) And (cboAREA.SelectedValue <> gc_REPORT_AREA_ALL) Then
                cboBRID.Enabled = True
                If (cboBRID.Items.Count > 0) Then
                    cboBRID.Clears()
                End If

                'v_strSQL = "SELECT BRID VALUE, BRID || '. ' || BRNAME DISPLAY, BRID || '. ' || BRNAME EN_DISPLAY FROM BRGRP WHERE (PRBRID IS NULL OR PRBRID=BRID)"
                'If (BranchId <> HO_BRID) And (BranchId <> "0101") Then ' Các chi nhánh khác chi hiên thị mức đại lý
                '    v_strSQL = v_strSQL + " AND (BRID = '" + BranchId + "') "
                'End If
                If BranchId = HO_BRID Then
                    v_strSQL = "SELECT BRID VALUE, BRID || '. ' || BRNAME DISPLAY, BRID || '. ' || BRNAME EN_DISPLAY FROM BRGRP WHERE (PRBRID IS NULL OR PRBRID='" + BranchId + "' OR BRID= '" + BranchId + "')"
                Else
                    v_strSQL = "SELECT BRID VALUE, BRID || '. ' || BRNAME DISPLAY, BRID || '. ' || BRNAME EN_DISPLAY FROM BRGRP WHERE BRID= '" + BranchId + "' "
                End If

                v_strSQL = v_strSQL + " ORDER BY BRID"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboBRID, "", Me.UserLanguage)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FillAgentComboBox()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            If (cboAREA.Items.Count > 0) And (cboAREA.SelectedValue = gc_REPORT_AREA_AGENT) Then
                cboAGENTID.Enabled = True
                If (cboAGENTID.Items.Count > 0) Then
                    cboAGENTID.Clears()
                End If

                v_strSQL = "SELECT BRID VALUE, BRID || '. ' || BRNAME DISPLAY, BRID || '. ' || BRNAME EN_DISPLAY FROM BRGRP WHERE PRBRID = '" & cboBRID.SelectedValue & "' OR BRID = '" & cboBRID.SelectedValue & "' ORDER BY BRID"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboAGENTID, "", Me.UserLanguage)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ShowReportList()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_intCountCol, v_intCountRow As Integer
            Dim v_ListViewItem As ListViewItem
            Dim v_XmlNode As XmlNode


            If IsPublic = "Y" Then
                Me.btnBROWSER.Visible = True
                Me.txtPATH.Visible = True
                Me.btnGenerate.Visible = True
                Me.btnRecreat.Visible = False
                Me.btnView.Visible = False
                Me.btnPrint.Visible = False
                Me.lblAREA.Visible = False
                Me.cboAREA.Visible = False
                Me.cboEXCYCLE.Visible = True
                Me.lblEXCYCLE.Visible = True


                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , ModuleCode, "GetReportBatch")
                v_ws.Message(v_strObjMsg)
            Else
                Me.btnBROWSER.Visible = False
                Me.txtPATH.Visible = False
                Me.btnGenerate.Visible = False
                Me.btnRecreat.Visible = True
                Me.btnView.Visible = True
                Me.btnPrint.Visible = True
                Me.lblAREA.Visible = True
                Me.cboAREA.Visible = True
                Me.cboEXCYCLE.Visible = False
                Me.lblEXCYCLE.Visible = False

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , ModuleCode, "GetReportList", , , IIf(Not IsDBNull(cboAREA.SelectedValue), cboAREA.SelectedValue, String.Empty))
                v_ws.Message(v_strObjMsg)

            End If

            'ReportList.DataRows.Clear()
            'ReportList.BeginInit()
            InitGridControl()

            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            v_intCountRow = v_xmlDocument.FirstChild.ChildNodes.Count
            If v_xmlDocument.FirstChild.FirstChild Is Nothing Then
                Exit Sub
            End If
            v_intCountCol = v_xmlDocument.FirstChild.FirstChild.ChildNodes.Count

            ReDim mv_arrSTOREDNAME(v_intCountRow - 1)
            ReDim mv_arrRPTID(v_intCountRow - 1)
            ReDim mv_arrRPTNAME(v_intCountRow - 1)
            ReDim mv_arrISLOCAL(v_intCountRow - 1)
            ReDim mv_arrSTRAUTH(v_intCountRow - 1)
            ReDim mv_arrDATETIME(v_intCountRow - 1)
            ReDim mv_arrPAPER(v_intCountRow - 1)
            ReDim mv_arrORIENTATION(v_intCountRow - 1)
            ReDim mv_arrISCAREBY(v_intCountRow - 1)
            ReDim mv_arrArea(v_intCountRow - 1)
            ReDim mv_arrISADHOC(v_intCountRow - 1)
            ReDim mv_arrSUBRPT(v_intCountRow - 1)
            ReDim mv_arrISCMP(v_intCountRow - 1)

            v_XmlNode = v_xmlDocument.FirstChild

            FillDataXtraGrid(Me.gridRPT, v_strObjMsg, "", "RPTLIST", , 0, 100, 0)

            Dim v_arrStr(v_intCountCol - 2) As String
            Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strLASTCREATED As String
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "RPTID"
                                mv_arrRPTID(i) = CStr(v_strValue).Trim
                            Case "RPTNAME"
                                mv_arrRPTNAME(i) = CStr(v_strValue).Trim
                            Case "PAPER"
                                mv_arrPAPER(i) = CStr(v_strValue).Trim
                            Case "ORIENTATION"
                                mv_arrORIENTATION(i) = CStr(v_strValue).Trim
                            Case "STOREDNAME"
                                mv_arrSTOREDNAME(i) = CStr(v_strValue).Trim
                            Case "ISLOCAL"
                                mv_arrISLOCAL(i) = CStr(v_strValue).Trim
                            Case "STRAUTH"
                                mv_arrSTRAUTH(i) = CStr(v_strValue).Trim
                            Case "ISCAREBY"
                                mv_arrISCAREBY(i) = CStr(v_strValue).Trim
                            Case "AD_HOC"
                                mv_arrISADHOC(i) = CStr(v_strValue).Trim
                            Case "AREA"
                                mv_arrArea(i) = CStr(v_strValue).Trim
                            Case "SUBRPT"
                                mv_arrSUBRPT(i) = CStr(v_strValue).Trim
                            Case "ISCMP"
                                mv_arrISCMP(i) = CStr(v_strValue).Trim
                        End Select
                    End With
                Next
                mv_arrDATETIME(i) = GetReportDateCreated(GetReportFileName(mv_arrRPTID(i)))
                If mv_arrDATETIME(i).Year < 2 Then
                    v_strLASTCREATED = GetReportPending(GetReportPendingFileName(mv_arrRPTID(i)))
                Else
                    v_strLASTCREATED = mv_arrDATETIME(i).ToString
                End If
                Dim dt As DataTable = gridRPT.DataSource
                If dt IsNot Nothing Then
                    Dim rows() As DataRow = dt.Select("RPTID = '" + mv_arrRPTID(i) + "'")
                    If rows IsNot Nothing And rows.Count = 1 Then
                        rows(0)("LASTCREATED") = v_strLASTCREATED
                    End If
                End If

            Next

            gridRPT.RefreshDataSource()

            If Me.RPTID.Length > 0 Then
                OnReCreate(Me.RPTID)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmReportList." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmReportList." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmReportList." & v_ctrl.Name)
            End If
        Next

        btnClose.Text = mv_ResourceManager.GetString("frmReportList." & btnClose.Name)
        btnDownload.Text = mv_ResourceManager.GetString("frmReportList." & btnDownload.Name)
        btnGenerate.Text = mv_ResourceManager.GetString("frmReportList." & btnGenerate.Name)
        btnPrint.Text = mv_ResourceManager.GetString("frmReportList." & btnPrint.Name)
        btnRecreat.Text = mv_ResourceManager.GetString("frmReportList." & btnRecreat.Name)
        btnRptPending.Text = mv_ResourceManager.GetString("frmReportList." & btnRptPending.Name)
        btnView.Text = mv_ResourceManager.GetString("frmReportList." & btnView.Name)

        Me.Text = mv_ResourceManager.GetString("frmReportList")
        lblCaption.Text = mv_ResourceManager.GetString("frmReportList.lblCaption").Replace("@", ModuleCode)
    End Sub

    Private Sub DoResizeForm()

    End Sub

    'Private Sub LoadScreen(ByVal pv_strTLTXCD As String)
    '    'Hiển thị thông tin báo cáo lên màn hình
    '    DisplayScreen()
    'End Sub

    'Private Sub DisplayScreen()

    'End Sub

    'Private Function GetXMLFilePath(ByVal pv_strRptID As String) As String
    '    Dim v_str As String
    '    v_str = GetRptDirectory()
    '    v_str = v_str & "\XMLData\Rpt" & pv_strRptID & ".xml"
    '    Return v_str
    'End Function

    'Private Function GetRptTempFilePath(ByVal pv_strRptID As String) As String
    '    Dim v_str As String
    '    v_str = GetRptDirectory()
    '    v_str = v_str & "\RptData\Rpt" & pv_strRptID & ".rpt"
    '    Return v_str
    'End Function

    Private Function GetReportDirectory() As String
        Try
            'Get report directory from SYSVAL table on BDS
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            'TruongLD Comment when convert
            'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
            'TruongLD Add when convert
            Dim v_ws As New BDSRptDeliveryManagement
            'End TruongLD
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

    'Private Function CheckMissingFields(ByVal report As ReportDocument, ByVal data As DataSet, ByRef missingInSource As String, ByRef missingInReport As String) As Boolean
    '    Dim ht As New Hashtable
    '    Dim columns As DataColumnCollection = data.Tables(0).Columns

    '    missingInSource = ""
    '    missingInReport = ""

    '    Dim reportObject As ReportObject
    '    For Each reportObject In report.ReportDefinition.ReportObjects
    '        Try
    '            'Dim field As FieldObject = CType(reportObject, FieldObject)
    '            'If field.DataSource.Kind = FieldKind.DatabaseField Then
    '            '    Dim name As String = field.DataSource.Name
    '            '    If Not columns.Contains(name) Then
    '            '        missingInSource += name + ","
    '            '    End If
    '            '    ht.Add(field.DataSource.Name, "")
    '            'End If
    '        Catch
    '        End Try
    '    Next reportObject
    '    Dim column As DataColumn
    '    For Each column In columns
    '        Dim name As String = column.ColumnName
    '        If Not ht.Contains(name) Then
    '            missingInReport += name + ","
    '        End If
    '    Next column
    '    If missingInSource <> "" Then
    '        missingInSource = missingInSource.Substring(0, missingInSource.Length - 1)
    '    End If
    '    If missingInReport <> "" Then
    '        missingInReport = missingInReport.Substring(0, missingInReport.Length - 1)
    '    End If
    '    Return missingInSource = ""
    'End Function 'CheckMissingFields

    'Private Sub ShowMissingFields(ByVal missingInSource As String, ByVal missingInReport As String)
    '    If missingInSource = "" And missingInReport = "" Then
    '        Return
    '    End If
    '    Dim message As String = ""
    '    Dim icon As MessageBoxIcon = MessageBoxIcon.Warning

    '    If missingInSource <> "" Then
    '        icon = MessageBoxIcon.Error
    '        message += "The following fields are missing in XML feed(" + "):" + ControlChars.Lf + " but exist in report (" + ")" + ControlChars.Lf + missingInSource + ControlChars.Lf + ControlChars.Lf
    '    End If

    '    If missingInReport <> "" Then
    '        message += "The following fields are missing in report (" + ")" + ControlChars.Lf + " but exist in XML feed(" + "):" + ControlChars.Lf + missingInReport
    '    End If

    '    MessageBox.Show(message, Me.Text, MessageBoxButtons.OK, icon)
    'End Sub 'ShowMissingFields

    Private Function GetReportPendingFileName(ByVal pv_strCMDID As String) As String
        '"_PENDING" & "_" & v_strBRID & "_" & v_strTLID & "_" & v_strCMDID & "_"
        Return "_REQUEST" & "_" & BranchId & "_" & TellerId & "_" & pv_strCMDID & "_"
    End Function

    Private Function GetReportFileName(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".rpt"
    End Function

    Private Function GetReportFileNameStandard(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".prnx"
    End Function

    Private Function GetReportPending(ByVal pv_strReportFileName As String) As String
        Try
            Dim v_dirInfo As New DirectoryInfo(ReportTempDirectory)
            'Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles("*" & pv_strReportFileName & "*.xml")
            Dim v_fileInfo As FileInfo

            For Each v_fileInfo In v_arrReportFiles
                If InStr(v_fileInfo.Name, pv_strReportFileName) > 0 Then
                    'File ton tai
                    Return mv_ResourceManager.GetString("frmReportList.ReportPedingProcess")
                End If
            Next

            Return String.Empty
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function GetReportDateCreated(ByVal pv_strReportFileName As String, Optional ByRef v_strAdhoc As String = "") As Date
        Try
            Dim v_dirInfo As New DirectoryInfo(ReportTempDirectory)
            'Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles(pv_strReportFileName)
            Dim v_fileInfo As FileInfo

            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    v_strAdhoc = "Y"
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            'Xu ly doc file tu template
            pv_strReportFileName = pv_strReportFileName.Replace(".rpt", ".prnx")
            v_arrReportFiles = v_dirInfo.GetFiles(pv_strReportFileName)
            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    v_strAdhoc = "N"
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            Return Nothing
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Public Overridable Sub OnGenerate()
        Try
            'Dim RowKey As String
            'If (ReportList.DataRows.Count > 0) Then
            '    For i As Integer = 0 To ReportList.DataRows.Count - 1
            '        If (ReportList.CurrentRow Is ReportList.DataRows(i)) Then
            '            'Call frmReportParameter to re-create the report
            '            If Not ReportList.CurrentRow Is Nothing Then
            '                RowKey = Trim(CType(ReportList.CurrentRow, Xceed.Grid.DataRow).Cells(0).Value)
            '                ' ReportList.CurrentRow.
            '            End If
            '            Dim v_frm As New frmReportParameter

            '            If Me.cboAREA.SelectedValue = "A" Then
            '                v_frm.BranchId = Me.BranchId
            '            ElseIf Me.cboAREA.SelectedValue = "B" Then
            '                v_frm.BranchId = Me.cboBRID.SelectedValue
            '            Else
            '                v_frm.BranchId = Me.cboAGENTID.SelectedValue
            '            End If
            '            v_frm.IsPublic = Me.IsPublic
            '            v_frm.ExportDirectory = Me.txtPATH.Text
            '            v_frm.ModuleCode = mv_arrRPTID(i).Substring(0, 2)
            '            v_frm.ObjectName = mv_arrRPTID(i)
            '            v_frm.TellerId = Me.TellerId
            '            v_frm.LocalObject = mv_arrISLOCAL(i)
            '            v_frm.BranchName = mv_strBRNAME
            '            v_frm.Teller = mv_strTELLER
            '            v_frm.ReportTitle = mv_arrRPTNAME(i)
            '            v_frm.StoredName = mv_arrSTOREDNAME(i)
            '            v_frm.ReportTimeCreated = mv_arrDATETIME(i)
            '            v_frm.CMDID = mv_arrRPTID(i)
            '            v_frm.ISADHOC = mv_arrISADHOC(i)
            '            v_frm.UserLanguage = Me.UserLanguage
            '            v_frm.ReportDirectory = ReportDirectory
            '            v_frm.ReportTempDirectory = ReportTempDirectory
            '            v_frm.Excycle = Me.cboEXCYCLE.SelectedValue
            '            v_frm.BusDate = BusDate
            '            If (cboAREA.Items.Count > 0) Then
            '                v_frm.ReportArea = cboAREA.SelectedValue
            '            Else
            '                v_frm.ReportArea = gc_REPORT_AREA_ALL
            '            End If
            '            v_frm.ShowDialog()
            '            mv_arrDATETIME(i) = v_frm.ReportTimeCreated

            '            'Refrest list view to show the report list
            '            ShowReportList()
            '            If v_frm.ReturnExecuted = 1 Then
            '                If IsPublic <> "Y" Then
            '                    OnView(RowKey)
            '                End If
            '            End If
            '            Exit Sub
            '        End If
            '    Next

            '    MessageBox.Show(mv_ResourceManager.GetString("frmReportList.ReportNotSelected"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    'T07/2017 STP Chuyen Private  --> Protected
    'Private Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewRPT.Click
        Try
            Dim v_strSTRAUTH, v_strPrint, v_strAdd, v_strArea As String

            Dim dr As DataRowView = viewRPT.GetFocusedRow()

            If Not dr Is Nothing Then
                v_strSTRAUTH = CStr(dr.Row("STRAUTH")).Trim
                v_strPrint = "N"
                v_strAdd = "N"
                v_strArea = "A"
                If Len(Trim(v_strSTRAUTH)) > 0 Then
                    v_strPrint = Mid(v_strSTRAUTH, 1, 1)
                    v_strAdd = Mid(v_strSTRAUTH, 2, 1)
                    v_strArea = Mid(v_strSTRAUTH, 3, 1)
                End If

                btnPrint.Enabled = (v_strPrint = "Y")
                btnRecreat.Enabled = (v_strAdd = "Y")
                btnView.Enabled = True
                mv_intAreaIndex = hAreaFilter(v_strArea)
                'cboAREA.SelectedValue = v_strArea
                'mv_intAreaIndex = cboAREA.SelectedIndex

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'T07/2017 STP Chuyen Private  --> Protected
    'Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Overridable Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewRPT.DoubleClick
        Try
            Try
                If viewRPT.GetFocusedDataRow()("LASTCREATED") <> "" Then
                    OnView()
                Else
                    OnReCreate()
                End If
            Catch ex As Exception
                OnReCreate()
            End Try
            

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Grid_RowKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                OnView()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles viewRPT.KeyUp
        Try
            Grid_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
End Class
