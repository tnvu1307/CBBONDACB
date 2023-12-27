'Các object sử dụng để lên trang báo cáo
Imports CommonLibrary
Imports System.Drawing
Imports DevExpress.XtraReports.UI

<Serializable()> _
Public Class RptLayoutField

#Region " Declaration "
    Private Enum ReportFieldAlign
        Left = 0
        Right = 1
        Center = 2
    End Enum
    Private mv_lngSubReportNo As Long = 0   'Thuộc SubReport nào. 0 là report chính (master)
    Private mv_strTheme As String
    Private mv_strGrpType As String
    Private mv_strGrpName As String
    Private mv_strFieldName As String
    Private mv_strFieldType As String = "BD"   'BD.Body, RH. Report header, PH.Page header, GH.Group header, RF.Report footer, PF.Page footer, GF.Groupt footer
    Private mv_strFieldDataType As String = "C"
    Private mv_strFieldFORP As String = "P"
    Private mv_strPicturePath As String
    Private mv_lngFieldLength As Long = 0   'Độ dài của trường (dùng cho kiểu ký tự)
    Private mv_lngFieldWidth As Long = 20    'Độ dài của Cell theo tỷ lệ. Mặc định là 20%
    Private mv_lngFieldHeight As Long = 0 'Thứ tự hiển thị
    Private mv_blnColSpan As Boolean = False 'Mặc định ko phải là colspan
    Private mv_blnRowSpan As Boolean = False 'Mặc định ko phải là rowspan
    Private mv_bytFieldAlign As Byte = ReportFieldAlign.Center
    Private mv_strFieldFormat As String
    Private mv_strFieldCaption_VN As String 'Caption tiếng việt
    Private mv_strFieldCaption_EN As String 'Caption tiếng Anh
    Private mv_strBackColor As String       'Màu nền
    Private mv_strForeColor As String       'Màu chữ
    Private mv_strFieldExpression As String = "" 'Biểu thức tính toán
    Private mv_strFontName As String = "Courier New"
    Private mv_blnFontItalic As Boolean = False
    Private mv_blnFontBold As Boolean = False
    Private mv_blnFontUnderline As Boolean = False
    Private mv_bytFontSize As Byte = 10
    Private mv_lngRowNo As Long = 0     'Hàng nào
    Private mv_lngColNo As Long = 0     'Cột nào

    Private mv_strGroupField As String = ""        'Tên trường được nhóm
    Private mv_intGroupLevel As Integer = 0     'Group level mấy
    Private mv_strGroupRefFieldName As String = ""  'Hiển thị tên trường nào
    Private mv_strGroupSummaryExpression As String = ""

    Private mv_blnWrapText As Boolean = True
    Private mv_blnVisible As Boolean = True
    Private mv_blnBorderTop As Boolean = True
    Private mv_blnBorderLeft As Boolean = True
    Private mv_blnBorderRight As Boolean = True
    Private mv_blnBorderBottom As Boolean = True
    Private mv_lngBorderWeight As Long = 0
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()

    End Sub

    Public Overloads Sub Dispose()

    End Sub
#End Region

#Region " Properties "
    Public Property THEMECODE() As String
        Get
            Return mv_strTheme
        End Get
        Set(ByVal Value As String)
            mv_strTheme = Value
        End Set
    End Property

    Public Property FLDNAME() As String
        Get
            Return mv_strFieldName
        End Get
        Set(ByVal Value As String)
            mv_strFieldName = Value
        End Set
    End Property

    Public Property FLDTYPE() As String
        Get
            Return mv_strFieldType
        End Get
        Set(ByVal Value As String)
            mv_strFieldType = Value
        End Set
    End Property

    Public Property GRPNAME() As String
        Get
            Return mv_strGrpName
        End Get
        Set(ByVal Value As String)
            mv_strGrpName = Value
        End Set
    End Property

    Public Property GRPTYPE() As String
        Get
            Return mv_strGrpType
        End Get
        Set(ByVal Value As String)
            mv_strGrpType = Value
        End Set
    End Property

    Public Property FORP() As String
        Get
            Return mv_strFieldFORP
        End Get
        Set(ByVal Value As String)
            mv_strFieldFORP = Value
        End Set
    End Property

    Public Property PICPATH() As String
        Get
            Return mv_strPicturePath
        End Get
        Set(ByVal Value As String)
            mv_strPicturePath = Value
        End Set
    End Property

    Public Property FLDDATATYPE() As String
        Get
            Return mv_strFieldDataType
        End Get
        Set(ByVal Value As String)
            mv_strFieldDataType = Value
        End Set
    End Property

    Public Property SUBREPORTNO() As Long
        Get
            Return mv_lngSubReportNo
        End Get
        Set(ByVal Value As Long)
            mv_lngSubReportNo = Value
        End Set
    End Property

    Public Property ROWNO() As Long
        Get
            Return mv_lngRowNo
        End Get
        Set(ByVal Value As Long)
            mv_lngRowNo = Value
        End Set
    End Property

    Public Property COLNO() As Long
        Get
            Return mv_lngColNo
        End Get
        Set(ByVal Value As Long)
            mv_lngColNo = Value
        End Set
    End Property

    Public Property FLDWIDTH() As Long
        Get
            Return mv_lngFieldWidth
        End Get
        Set(ByVal Value As Long)
            mv_lngFieldWidth = Value
        End Set
    End Property

    Public Property FLDLENGTH() As Long
        Get
            Return mv_lngFieldLength
        End Get
        Set(ByVal Value As Long)
            mv_lngFieldLength = Value
        End Set
    End Property

    Public Property FLDHEIGHT() As Long
        Get
            Return mv_lngFieldHeight
        End Get
        Set(ByVal Value As Long)
            mv_lngFieldHeight = Value
        End Set
    End Property

    Public Property CAPTION_VN() As String
        Get
            Return mv_strFieldCaption_VN
        End Get
        Set(ByVal Value As String)
            mv_strFieldCaption_VN = Value
        End Set
    End Property

    Public Property CAPTION_EN() As String
        Get
            Return mv_strFieldCaption_EN
        End Get
        Set(ByVal Value As String)
            mv_strFieldCaption_EN = Value
        End Set
    End Property

    Public Property FLDFIELDALIGN() As Byte
        Get
            Return mv_bytFieldAlign
        End Get
        Set(ByVal Value As Byte)
            mv_bytFieldAlign = Value
        End Set
    End Property

    Public Property FLDFORMAT() As String
        Get
            Return mv_strFieldFormat
        End Get
        Set(ByVal Value As String)
            mv_strFieldFormat = Value
        End Set
    End Property

    Public Property BACKCOLOR() As String
        Get
            Return mv_strBackColor
        End Get
        Set(ByVal Value As String)
            mv_strBackColor = Value
        End Set
    End Property

    Public Property FORECOLOR() As String
        Get
            Return mv_strForeColor
        End Get
        Set(ByVal Value As String)
            mv_strForeColor = Value
        End Set
    End Property

    Public Property FLDEXPRESSION() As String
        Get
            Return mv_strFieldExpression
        End Get
        Set(ByVal Value As String)
            mv_strFieldExpression = Value
        End Set
    End Property

    Public Property FLDFONTNAME() As String
        Get
            Return mv_strFontName
        End Get
        Set(ByVal Value As String)
            mv_strFontName = Value
        End Set
    End Property

    Public Property FLDFONTITALIC() As Boolean
        Get
            Return mv_blnFontItalic
        End Get
        Set(ByVal Value As Boolean)
            mv_blnFontItalic = Value
        End Set
    End Property

    Public Property FLDFONTBOLD() As Boolean
        Get
            Return mv_blnFontBold
        End Get
        Set(ByVal Value As Boolean)
            mv_blnFontBold = Value
        End Set
    End Property

    Public Property FLDFONTUNDERLINE() As Boolean
        Get
            Return mv_blnFontUnderline
        End Get
        Set(ByVal Value As Boolean)
            mv_blnFontUnderline = Value
        End Set
    End Property

    Public Property FLDFONTSIZE() As Byte
        Get
            Return mv_bytFontSize
        End Get
        Set(ByVal Value As Byte)
            mv_bytFontSize = Value
        End Set
    End Property

    Public Property FLDGROUPFIELD() As String
        Get
            Return mv_strGroupField
        End Get
        Set(ByVal Value As String)
            mv_strGroupField = Value
        End Set
    End Property

    Public Property FLDGROUPLEVEL() As Integer
        Get
            Return mv_intGroupLevel
        End Get
        Set(ByVal Value As Integer)
            mv_intGroupLevel = Value
        End Set
    End Property

    Public Property FLDGROUPREFFLDNAME() As String
        Get
            Return mv_strGroupRefFieldName
        End Get
        Set(ByVal Value As String)
            mv_strGroupRefFieldName = Value
        End Set
    End Property

    Public Property FLDGROUPEXPRESSION() As String
        Get
            Return mv_strGroupSummaryExpression
        End Get
        Set(ByVal Value As String)
            mv_strGroupSummaryExpression = Value
        End Set
    End Property

    Public Property WRAPTEXT() As Boolean
        Get
            Return mv_blnWrapText
        End Get
        Set(ByVal Value As Boolean)
            mv_blnWrapText = Value
        End Set
    End Property

    Public Property VISIBLE() As Boolean
        Get
            Return mv_blnVisible
        End Get
        Set(ByVal Value As Boolean)
            mv_blnVisible = Value
        End Set
    End Property

    Public Property FLDCOLSPAN() As Boolean
        Get
            Return mv_blnColSpan
        End Get
        Set(ByVal Value As Boolean)
            mv_blnColSpan = Value
        End Set
    End Property

    Public Property FLDROWSPAN() As Boolean
        Get
            Return mv_blnRowSpan
        End Get
        Set(ByVal Value As Boolean)
            mv_blnRowSpan = Value
        End Set
    End Property

    Public Property FLDBORDERTOP() As Boolean
        Get
            Return mv_blnBorderTop
        End Get
        Set(ByVal Value As Boolean)
            mv_blnBorderTop = Value
        End Set
    End Property

    Public Property FLDBORDERLEFT() As Boolean
        Get
            Return mv_blnBorderLeft
        End Get
        Set(ByVal Value As Boolean)
            mv_blnBorderLeft = Value
        End Set
    End Property

    Public Property FLDBORDERRIGHT() As Boolean
        Get
            Return mv_blnBorderRight
        End Get
        Set(ByVal Value As Boolean)
            mv_blnBorderRight = Value
        End Set
    End Property

    Public Property FLDBORDERBOTTOM() As Boolean
        Get
            Return mv_blnBorderBottom
        End Get
        Set(ByVal Value As Boolean)
            mv_blnBorderBottom = Value
        End Set
    End Property


    Public Property FLDBORDERWEIGTH() As Long
        Get
            Return mv_lngborderweight
        End Get
        Set(ByVal Value As Long)
            mv_lngborderweight = Value
        End Set
    End Property

#End Region

End Class

<Serializable()> _
Public Class RptMaster

#Region " Variables "
    Private mv_strLanguage As String
    Private mv_strReportID As String
    Private mv_strReportTitle As String
    Private mv_lngBodyDetail As Long = 0
    Private mv_lngReportHeader As Long = 0
    Private mv_lngReportFooter As Long = 0
    Private mv_lngPageHeader As Long = 0
    Private mv_lngPageFooter As Long = 0
    Private mv_strPaperSize As String = "A4"
    Private mv_strOrientation As String = "P"
    Private mv_lngTopMargin As Long = 0
    Private mv_lngLeftMargin As Long = 0
    Private mv_lngRightMargin As Long = 0
    Private mv_lngBottomMargin As Long = 0


    Private mv_lngNumberOfSubReport As Long = 0 'Số lượng sub-report
    Private mv_strAorS As String = "S"                'A: Báo cáo không sử dụng based template (RPTBASED), S: Sử dụng kế thừa RPTBASED
    Private mv_strHasSubReport As String = "N"
    Private Const PREFIX_CALCULATION = "objCal"
    Private Const PREFIX_CALCULATION_RUNNING = "objCalRun"
    Private mv_singleHeightItem As Single = 23.0!

    Public mv_ds As DataSet    'Dữ liệu hiển thị
    Public mv_RefRptDoc As XtraReport

    Private mv_dblRunning As Double
    Private mv_strFormatRunning As String

    Public mv_arrRefRunning(0) As Double
    Public mv_arrRefExpression(0) As String
    Public mv_arrRefFormat(0) As String

    Public mv_strReportDirectory As String
    Public mv_arrRefFormulaName() As String     'Mảng lưu trữ tên các tham số formula
    Public mv_arrRefFormulaValue() As String    'Mảng lưu trữ giá trị các tham số formula
    Public mv_arrObjSections() As RptSection
#End Region

#Region " Properties "
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property HASSUBREPORT() As String
        Get
            Return mv_strHasSubReport
        End Get
        Set(ByVal Value As String)
            mv_strHasSubReport = Value
        End Set
    End Property

    Public Property AORS() As String
        Get
            Return mv_strAorS
        End Get
        Set(ByVal Value As String)
            mv_strAorS = Value
        End Set
    End Property

    Public Property RPTID() As String
        Get
            Return mv_strReportID
        End Get
        Set(ByVal Value As String)
            mv_strReportID = Value
        End Set
    End Property

    Public Property RPTTITLE() As String
        Get
            Return mv_strReportTitle
        End Get
        Set(ByVal Value As String)
            mv_strReportTitle = Value
        End Set
    End Property

    Public Property SUBCOUNT() As Long
        Get
            Return mv_lngNumberOfSubReport
        End Get
        Set(ByVal Value As Long)
            mv_lngNumberOfSubReport = Value
        End Set
    End Property

    Public Property TOPMARGIN() As Long
        Get
            Return mv_lngTopMargin
        End Get
        Set(ByVal Value As Long)
            mv_lngTopMargin = Value
        End Set
    End Property

    Public Property LEFTMARGIN() As Long
        Get
            Return mv_lngLeftMargin
        End Get
        Set(ByVal Value As Long)
            mv_lngLeftMargin = Value
        End Set
    End Property

    Public Property RIGHTMARGIN() As Long
        Get
            Return mv_lngRightMargin
        End Get
        Set(ByVal Value As Long)
            mv_lngRightMargin = Value
        End Set
    End Property

    Public Property BOTTOMMARGIN() As Long
        Get
            Return mv_lngBottomMargin
        End Get
        Set(ByVal Value As Long)
            mv_lngBottomMargin = Value
        End Set
    End Property

    Public Property PAPERSIZE() As String
        Get
            Return mv_strPaperSize
        End Get
        Set(ByVal Value As String)
            mv_strPaperSize = Value
        End Set
    End Property

    Public Property ORIENTATION() As String
        Get
            Return mv_strOrientation
        End Get
        Set(ByVal Value As String)
            mv_strOrientation = Value
        End Set
    End Property

    Public Property RPTHEADERHEIGHT() As Long
        Get
            Return mv_lngReportHeader
        End Get
        Set(ByVal Value As Long)
            mv_lngReportHeader = Value
        End Set
    End Property

    Public Property RPTFOOTERHEIGHT() As Long
        Get
            Return mv_lngReportFooter
        End Get
        Set(ByVal Value As Long)
            mv_lngReportFooter = Value
        End Set
    End Property

    Public Property PAGEHEADERHEIGHT() As Long
        Get
            Return mv_lngPageHeader
        End Get
        Set(ByVal Value As Long)
            mv_lngPageHeader = Value
        End Set
    End Property

    Public Property PAGEFOOTERHEIGHT() As Long
        Get
            Return mv_lngPageFooter
        End Get
        Set(ByVal Value As Long)
            mv_lngPageFooter = Value
        End Set
    End Property

    Public Property BODYDETAILHEIGHT() As Long
        Get
            Return mv_lngBodyDetail
        End Get
        Set(ByVal Value As Long)
            mv_lngBodyDetail = Value
        End Set
    End Property
#End Region

#Region " Method for report "
    Private Sub BasedXtraReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        CreateReportLayout(mv_RefRptDoc, UserLanguage)
    End Sub

    Private Sub tblCell_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim v_xrObject As XRTableCell
        v_xrObject = CType(sender, XRTableCell)
        v_xrObject.Text = mv_dblRunning
    End Sub

    Private Sub lblCustom_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim v_xrObject As XRLabel, v_intIdx As Integer
        v_xrObject = CType(sender, XRLabel)
        v_intIdx = v_xrObject.Tag.ToString.Substring(1) 'Ký tự đầu tiên là phép toán + - * /, sau đó là chỉ số của mảng
        If IsNumeric(v_intIdx) Then
            v_xrObject.Text = String.Format(mv_arrRefFormat(v_intIdx), mv_arrRefRunning(v_intIdx))
        End If
    End Sub

    Private Sub lblCustom_SummaryGetResult(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs)
        Dim v_xrObject As XRLabel, v_intIdx As Integer
        v_xrObject = CType(sender, XRLabel)
        v_intIdx = v_xrObject.Tag.ToString.Substring(1) 'Ký tự đầu tiên là phép toán + - * /, sau đó là chỉ số của mảng
        If IsNumeric(v_intIdx) Then
            e.Result = mv_arrRefRunning(v_intIdx)
            e.Handled = True
        End If
    End Sub

    Private Sub lblCustom_SummaryReset(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_xrObject As XRLabel, v_intIdx As Integer
        v_xrObject = CType(sender, XRLabel)
        v_intIdx = v_xrObject.Tag.ToString.Substring(1) 'Ký tự đầu tiên là phép toán + - * /, sau đó là chỉ số của mảng
        If IsNumeric(v_intIdx) Then
            mv_arrRefRunning(v_intIdx) = 0
        End If
    End Sub

    Private Sub lblCustom_SummaryRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_intPos, v_intTmp, v_intIdx As Integer, v_xrObject As XRLabel
        Dim v_strExpression, v_strTemp, v_strAMTEXP, v_strOperator, v_strField, v_strFieldValue As String, v_dblValue As Double
        v_xrObject = CType(sender, XRLabel)

        'Phép toán xử lý
        v_intIdx = v_xrObject.Tag.ToString.Substring(1) 'Ký tự đầu tiên là phép toán + - * /, sau đó là chỉ số của mảng
        If IsNumeric(v_intIdx) Then
            v_strExpression = mv_arrRefExpression(v_intIdx)
            v_intPos = 0
            v_strAMTEXP = ""
            'Tìm đến phép toán tương ứng: hiện chỉ hỗ trợ +, -, *, /
            v_dblValue = 0
            v_strTemp = v_strExpression
            'Tip xử lý phép toán: sử dụng mask để đánh dấu các vị trí có phép toán
            v_strTemp = v_strTemp.Replace("+", "~")
            v_strTemp = v_strTemp.Replace("-", "~")
            v_strTemp = v_strTemp.Replace("*", "~")
            v_strTemp = v_strTemp.Replace("/", "~")
            v_strTemp = v_strTemp.Replace("(", "~")
            v_strTemp = v_strTemp.Replace(")", "~")
            While v_intPos < v_strExpression.Length
                v_intTmp = v_strTemp.IndexOf("~", v_intPos) 'Lấy vị trí có chứa phép toán
                If v_intTmp > 0 Then
                    'Tìm vị trí của phép toán kế tiếp
                    v_strOperator = v_strExpression.Substring(v_intTmp, 1)      'Phép toán
                Else
                    'Không còn phép toán
                    v_strOperator = String.Empty
                    v_intTmp = v_strExpression.Length
                End If
                'Giá trị của trường kế tiếp
                v_strField = v_strExpression.Substring(v_intPos, v_intTmp - v_intPos)  'Tên trường
                v_strFieldValue = mv_RefRptDoc.GetCurrentColumnValue(v_strField)   'Giá trị của trường
                'Biểu thức số học
                v_strAMTEXP = v_strAMTEXP & v_strFieldValue & v_strOperator
                'Ký tự kế tiếp
                v_intPos = v_intTmp + 1
            End While
            'Kết quả tính toán
            If v_strAMTEXP.Length > 0 Then
                Dim v_objEval As New Evaluator
                v_dblValue = v_objEval.Eval(v_strAMTEXP)
            End If
            'Phép toán running
            v_strOperator = v_xrObject.Tag.ToString.Substring(0, 1)
            Select Case v_strOperator
                Case "+"
                    mv_arrRefRunning(v_intIdx) += v_dblValue
                Case "-"
                    mv_arrRefRunning(v_intIdx) -= v_dblValue
                Case "*"
                    mv_arrRefRunning(v_intIdx) *= v_dblValue
                Case "/"
                    If v_dblValue <> 0 Then
                        mv_arrRefRunning(v_intIdx) /= v_dblValue
                    End If
            End Select
        End If
    End Sub

    'Tạo một table đưa vào report control
    'Cho phép khai báo một bảng bên trong một cell: v_strType=SG (sub group table), SB (sub bodydetai table, có xử lý binding)
    Private Function CreateSectionTable(ByVal v_rptDoc As BasedXtraReport, ByVal v_strLang As String, ByVal v_strType As String, _
                    ByVal v_objRptSection As RptSection, ByVal v_strRefName As String, ByVal v_lngRefWidth As Long) As DevExpress.XtraReports.UI.XRTable
        Dim v_intIdx, v_intParamIdx, v_intParamCount, v_intRowIdx, v_intColIdx As Integer, v_strItemRemove, v_strGrpRunningType, v_strOperator As String
        Dim v_objField, v_objTmpField As RptLayoutField, v_objTmpSection As RptSection, v_tmpTblSection As DevExpress.XtraReports.UI.XRTable
        Dim pic As XRPictureBox, pageInfor As XRPageInfo
        v_intParamCount = mv_arrRefFormulaName.GetLength(0) - 1
        'Biến xử lý bảng
        Dim tblRptSection As DevExpress.XtraReports.UI.XRTable
        Dim tblRow As DevExpress.XtraReports.UI.XRTableRow
        Dim tblCell, tblTmpCell As DevExpress.XtraReports.UI.XRTableCell
        Dim v_objFontStyle As System.Drawing.FontStyle
        Dim v_objSummary As XRSummary
        Dim v_objCalculatorField As DevExpress.XtraReports.UI.CalculatedField

        tblRptSection = New DevExpress.XtraReports.UI.XRTable
        tblRptSection.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        tblRptSection.Name = v_strRefName
        'Đặt độ rộng
        If String.Compare(v_objRptSection.PORF, "P") = 0 Then
            'Theo tỷ lệ
            tblRptSection.Width = (v_objRptSection.WIDTH / 100) * v_lngRefWidth
        Else
            'Cố định
            tblRptSection.Width = v_objRptSection.WIDTH
        End If

        'Đặt chế độ đường kẻ
        If v_objRptSection.BORDERWIDTH = 0 Then
            tblRptSection.Borders = DevExpress.XtraPrinting.BorderSide.None
        Else
            tblRptSection.BorderWidth = v_objRptSection.BORDERWIDTH
            'tblRptSection.Borders = DevExpress.XtraPrinting.BorderSide.All
            If v_objRptSection.BDTOP = "Y" Then tblRptSection.Borders = tblRptSection.Borders Or DevExpress.XtraPrinting.BorderSide.Top
            If v_objRptSection.BDBOTTOM = "Y" Then tblRptSection.Borders = tblRptSection.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
            If v_objRptSection.BDLEFT = "Y" Then tblRptSection.Borders = tblRptSection.Borders Or DevExpress.XtraPrinting.BorderSide.Left
            If v_objRptSection.BDRIGHT = "Y" Then tblRptSection.Borders = tblRptSection.Borders Or DevExpress.XtraPrinting.BorderSide.Right
        End If


        If v_objRptSection.ROWSCOUNT > 0 Then
            For v_intRowIdx = 0 To v_objRptSection.ROWSCOUNT - 1 Step 1
                'Tạo dòng dữ liệu của Header/Footer
                v_strItemRemove = String.Empty 'Sử dụng để xử lý Colspan
                tblRow = New DevExpress.XtraReports.UI.XRTableRow
                tblRow.HeightF = 0
                For v_intColIdx = 0 To v_objRptSection.COLSCOUNT - 1 Step 1
                    'Do sử dụng mảng một chiều nên phần tử cell = HÀNG * CỘT
                    v_objField = v_objRptSection.mv_arrObjFields(v_intRowIdx, v_intColIdx)
                    'Tạo Cell
                    tblCell = New DevExpress.XtraReports.UI.XRTableCell
                    tblCell.Name = tblRptSection.Name & "." & v_objField.FLDNAME & "." & v_intRowIdx & "." & v_intColIdx
                    tblCell.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                    'Kẻ cell
                    tblCell.BorderWidth = v_objRptSection.BORDERWIDTH
                    tblCell.Borders = DevExpress.XtraPrinting.BorderSide.None
                    If v_objField.FLDBORDERTOP Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Top
                    If v_objField.FLDBORDERBOTTOM Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                    If v_objField.FLDBORDERLEFT Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Left
                    If v_objField.FLDBORDERRIGHT Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Right

                    'Ghi nhận xử lý colspan
                    If v_objField.FLDCOLSPAN Then
                        v_strItemRemove &= CStr(v_intColIdx) & ","
                        tblCell.Borders = DevExpress.XtraPrinting.BorderSide.None
                    End If
                    'Kẻ đường xử lý ROWSPAN
                    If v_objField.FLDROWSPAN Then
                        If v_objRptSection.BORDERWIDTH > 0 Then
                            If v_intRowIdx <> 0 Then
                                'Cell hiện tại: Bỏ đường kẻ top nếu có border
                                tblCell.Borders = DevExpress.XtraPrinting.BorderSide.None
                                If v_objField.FLDBORDERBOTTOM Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                                If v_objField.FLDBORDERLEFT Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Left
                                If v_objField.FLDBORDERRIGHT Then tblCell.Borders = tblCell.Borders Or DevExpress.XtraPrinting.BorderSide.Right

                                v_objTmpField = v_objRptSection.mv_arrObjFields(v_intRowIdx - 1, v_intColIdx)
                                tblTmpCell = tblRptSection.Rows(v_intRowIdx - 1).Cells(v_intColIdx)
                                If v_objTmpField.FLDROWSPAN Then
                                    'Bỏ top/bottom border của dòng trên
                                    tblTmpCell.Borders = DevExpress.XtraPrinting.BorderSide.None
                                    If v_objField.FLDBORDERLEFT Then tblTmpCell.Borders = tblTmpCell.Borders Or DevExpress.XtraPrinting.BorderSide.Left
                                    If v_objField.FLDBORDERRIGHT Then tblTmpCell.Borders = tblTmpCell.Borders Or DevExpress.XtraPrinting.BorderSide.Right
                                Else
                                    'Bỏ bottom border của dòng trên
                                    tblTmpCell.Borders = DevExpress.XtraPrinting.BorderSide.None
                                    If v_objField.FLDBORDERTOP Then tblTmpCell.Borders = tblTmpCell.Borders Or DevExpress.XtraPrinting.BorderSide.Top
                                    If v_objField.FLDBORDERLEFT Then tblTmpCell.Borders = tblTmpCell.Borders Or DevExpress.XtraPrinting.BorderSide.Left
                                    If v_objField.FLDBORDERRIGHT Then tblTmpCell.Borders = tblTmpCell.Borders Or DevExpress.XtraPrinting.BorderSide.Right
                                End If
                            End If
                        End If
                    End If
                    'Đặt format hiển thị: font, wraptext, align
                    tblCell.WordWrap = v_objField.WRAPTEXT
                    v_objFontStyle = IIf(v_objField.FLDFONTBOLD, FontStyle.Bold, FontStyle.Regular) _
                        Xor IIf(v_objField.FLDFONTITALIC, FontStyle.Italic, FontStyle.Regular) _
                        Xor IIf(v_objField.FLDFONTUNDERLINE, FontStyle.Underline, FontStyle.Regular)
                    tblCell.Font = New System.Drawing.Font(v_objField.FLDFONTNAME, v_objField.FLDFONTSIZE, v_objFontStyle)
                    If v_objField.BACKCOLOR.Length > 0 Then tblCell.BackColor = System.Drawing.ColorTranslator.FromHtml(v_objField.BACKCOLOR)
                    If v_objField.FORECOLOR.Length > 0 Then tblCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(v_objField.FORECOLOR)
                    Select Case v_objField.FLDFIELDALIGN
                        Case 0  'Left
                            tblCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        Case 1  'Right
                            tblCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        Case 2  'Center
                            tblCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        Case Else
                            tblCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    End Select
                    'Xử lý độ rộng theo qui định của Section
                    If String.Compare(v_objRptSection.PORF, "P") = 0 Then
                        tblCell.SizeF = New System.Drawing.SizeF((v_objField.FLDWIDTH / 100) * tblRptSection.WidthF, v_objField.FLDHEIGHT)
                    Else
                        tblCell.SizeF = New System.Drawing.SizeF(v_objField.FLDWIDTH, v_objField.FLDHEIGHT)
                    End If

                    If v_objField.FLDCOLSPAN Or v_objField.FLDROWSPAN Then
                        'Nếu COLSPAN và ROWSPAN thì bỏ qua
                        tblCell.Text = String.Empty
                    Else
                        'Xử lý cách lấy dữ liệu cho CELL căn cứ theo FLDEXPRESSION, v_strType, FLDGROUPEXPRESSION và FLDGROUPREFFLDNAME
                        If v_objField.FLDEXPRESSION.Length = 0 Then
                            If String.Compare(v_strType, "BD") = 0 Or String.Compare(v_strType, "SB") = 0 Then
                                'BODY DETAIL
                                'Lấy trực tiếp giá trị từ DataSet của báo cáo: v_objField.FLDNAME chính là tên trường của dataset
                                tblCell.DataBindings.Add("Text", Nothing, v_objField.FLDNAME)
                                'Định dạng trường số/ngày tháng
                                If v_objField.FLDFORMAT.Length > 0 Then
                                    tblCell.DataBindings(0).FormatString = v_objField.FLDFORMAT
                                End If
                            ElseIf String.Compare(v_strType, "GH") = 0 Or String.Compare(v_strType, "GF") = 0 Then
                                If v_objField.FLDGROUPREFFLDNAME.Length > 0 Then
                                    'Nếu chỉ có FLDGROUPREFFLDNAME thì đây là trường tham chiếu hiển thị tại phần header/footer của nhóm
                                    tblCell.DataBindings.Add("Text", Nothing, v_objField.FLDGROUPREFFLDNAME)
                                    'Định dạng trường số/ngày tháng
                                    If v_objField.FLDFORMAT.Length > 0 Then
                                        tblCell.DataBindings(0).FormatString = v_objField.FLDFORMAT
                                    End If
                                End If
                            Else
                                If String.Compare(v_objField.FLDTYPE, "P") = 0 And v_objField.PICPATH.Length > 0 Then
                                    'Nếu là kiểu Picture box sẽ nạp tệp tin ảnh tại runtimv_rptDocument. 
                                    pic = New XRPictureBox
                                    pic.Image = Image.FromFile(mv_strReportDirectory & v_objField.PICPATH)
                                    pic.Borders = DevExpress.XtraPrinting.BorderSide.None
                                    pic.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize
                                    pic.TopF = tblCell.TopF
                                    pic.LeftF = tblCell.LeftF
                                    pic.Visible = True
                                    pic.BringToFront()
                                    tblCell.Controls.Add(pic)
                                Else
                                    'Lấy text cố định theo tham số
                                    If String.Compare(v_strLang, "EN") = 0 Then
                                        tblCell.Text = v_objField.CAPTION_EN
                                    Else
                                        tblCell.Text = v_objField.CAPTION_VN
                                    End If
                                End If
                            End If
                        ElseIf String.Compare(v_objField.FLDEXPRESSION, "{subtable}") = 0 Then
                            'Tham chiếu đến một table nhỏ hơn
                            If v_objField.FLDGROUPREFFLDNAME.Length > 0 Then
                                v_objTmpSection = New RptSection
                                v_objTmpSection.GetReportSectionInfor(v_objRptSection.RPTID, v_objField.FLDGROUPREFFLDNAME, v_objField.THEMECODE, v_objField.SUBREPORTNO)
                                v_tmpTblSection = CreateSectionTable(v_rptDoc, v_strLang, v_objTmpSection.GROUPTYPE, v_objTmpSection, tblCell.Name, tblCell.WidthF)
                                If Not v_tmpTblSection Is Nothing Then
                                    tblCell.Controls.Add(v_tmpTblSection)
                                End If
                            End If
                        ElseIf String.Compare(v_objField.FLDEXPRESSION, "{rownum}") = 0 Then
                            If String.Compare(v_strType, "BD") = 0 Or String.Compare(v_strType, "SB") = 0 Then
                                v_objSummary = New XRSummary
                                v_objSummary.Running = SummaryRunning.Report
                                v_objSummary.Func = SummaryFunc.RecordNumber
                                'Trường được dùng để tính toán được định nghĩa ở v_objField.FLDEXPRESSION
                                tblCell.DataBindings.Add("Text", Nothing, v_objField.FLDGROUPREFFLDNAME)
                                'Định dạng trường số/ngày tháng
                                If v_objField.FLDFORMAT.Length > 0 Then
                                    v_objSummary.FormatString = v_objField.FLDFORMAT
                                End If
                                tblCell.Summary = v_objSummary
                            End If
                        ElseIf String.Compare(v_objField.FLDEXPRESSION, "{page}") = 0 Then
                            pageInfor = New XRPageInfo
                            pageInfor.PageInfo = DevExpress.XtraPrinting.PageInfo.Number
                            pageInfor.HeightF = tblCell.HeightF
                            pageInfor.WidthF = tblCell.WidthF
                            pageInfor.Borders = DevExpress.XtraPrinting.BorderSide.None
                            'Biến nội tại của báo cáo
                            tblCell.Controls.Add(pageInfor)
                        ElseIf String.Compare(v_objField.FLDEXPRESSION, "{numpages}") = 0 Then
                            pageInfor = New XRPageInfo
                            pageInfor.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal
                            pageInfor.HeightF = tblCell.HeightF
                            pageInfor.WidthF = tblCell.WidthF
                            pageInfor.Borders = DevExpress.XtraPrinting.BorderSide.None
                            'Biến nội tại của báo cáo
                            tblCell.Controls.Add(pageInfor)
                        ElseIf v_objField.FLDEXPRESSION.Substring(0, 1) = "$" Then
                            'Nếu là biến formula truyền vào: từ màn hình tham số tạo báo cáo
                            For v_intParamIdx = 0 To v_intParamCount Step 1
                                If String.Compare("$" & mv_arrRefFormulaName(v_intParamIdx), v_objField.FLDEXPRESSION) = 0 Then
                                    tblCell.Text = mv_arrRefFormulaValue(v_intParamIdx)
                                    Exit For
                                End If
                            Next
                        ElseIf v_objField.FLDEXPRESSION.Substring(0, 1) = "@" Then
                            'Ghi nhận phần tử mảng để xử lý cho control running
                            v_intIdx = Me.mv_arrRefRunning.GetLength(0) - 1
                            ReDim Preserve mv_arrRefRunning(v_intIdx + 1)
                            ReDim Preserve mv_arrRefExpression(v_intIdx + 1)
                            ReDim Preserve mv_arrRefFormat(v_intIdx + 1)
                            mv_arrRefRunning(v_intIdx) = 0
                            mv_arrRefExpression(v_intIdx) = v_objField.FLDGROUPEXPRESSION
                            mv_arrRefFormat(v_intIdx) = v_objField.FLDFORMAT
                            v_strGrpRunningType = v_objField.FLDEXPRESSION.Substring(1, 1)
                            v_strOperator = v_objField.FLDEXPRESSION.Substring(2, 1)
                            'Nhóm running total
                            If (String.Compare(v_strType, "BD") = 0 Or String.Compare(v_strType, "SB") = 0 Or String.Compare(v_strType, "GH") = 0 Or String.Compare(v_strType, "GF") = 0) And _
                                v_strGrpRunningType = "G" Then
                                tblCell.Summary.Running = SummaryRunning.Group
                            ElseIf (String.Compare(v_strType, "PH") = 0 Or String.Compare(v_strType, "PF") = 0) Or v_strGrpRunningType = "P" Then
                                tblCell.Summary.Running = SummaryRunning.Page
                            Else
                                tblCell.Summary.Running = SummaryRunning.Report
                            End If
                            tblCell.Summary.Func = SummaryFunc.Custom
                            tblCell.Tag = v_strOperator & v_intIdx

                            AddHandler CType(tblCell, XRLabel).SummaryGetResult, AddressOf lblCustom_SummaryGetResult
                            AddHandler CType(tblCell, XRLabel).SummaryReset, AddressOf lblCustom_SummaryReset
                            AddHandler CType(tblCell, XRLabel).SummaryRowChanged, AddressOf lblCustom_SummaryRowChanged
                            AddHandler CType(tblCell, XRLabel).BeforePrint, AddressOf lblCustom_BeforePrint
                            CType(tblCell, XRLabel).DataBindings.Add("Text", Nothing, PREFIX_CALCULATION_RUNNING & v_objField.FLDGROUPREFFLDNAME)
                            If v_objField.FLDFORMAT.Length > 0 Then
                                tblCell.DataBindings(0).FormatString = v_objField.FLDFORMAT
                            End If

                        Else    'Nếu có định nghĩa khác 
                            If v_objField.FLDGROUPEXPRESSION.Length > 0 Then
                                'Phép toán cho Group of record
                                If v_objField.FLDGROUPEXPRESSION.Length > 0 Then
                                    v_objSummary = New XRSummary
                                    If String.Compare(v_strType, "GH") = 0 Or String.Compare(v_strType, "GF") = 0 Then
                                        'Theo nhóm
                                        v_objSummary.Running = SummaryRunning.Group
                                    ElseIf String.Compare(v_strType, "PH") = 0 Or String.Compare(v_strType, "PF") = 0 Then
                                        'Theo trang
                                        v_objSummary.Running = SummaryRunning.Page
                                    ElseIf String.Compare(v_strType, "RH") = 0 Or String.Compare(v_strType, "RF") = 0 Then
                                        'Theo báo cáo
                                        v_objSummary.Running = SummaryRunning.Report
                                    End If
                                    'Có phép toán xử lý tính GROUP BY
                                    Select Case v_objField.FLDGROUPEXPRESSION
                                        Case "SUM"  'Tính tổng
                                            v_objSummary.Func = SummaryFunc.Sum
                                        Case "AVG"  'Tính trung bình
                                            v_objSummary.Func = SummaryFunc.Avg
                                        Case "MAX"  'Tính tối đa
                                            v_objSummary.Func = SummaryFunc.Max
                                        Case "MIN"  'Tính tối thiểu
                                            v_objSummary.Func = SummaryFunc.Min
                                        Case "CNT"  'Đếm-count
                                            v_objSummary.Func = SummaryFunc.Count
                                    End Select
                                    'Trường được dùng để tính toán được định nghĩa ở v_objField.FLDEXPRESSION
                                    tblCell.DataBindings.Add("Text", Nothing, v_objField.FLDEXPRESSION)
                                    'Định dạng trường số/ngày tháng
                                    If v_objField.FLDFORMAT.Length > 0 Then
                                        v_objSummary.FormatString = v_objField.FLDFORMAT
                                    End If
                                    tblCell.Summary = v_objSummary
                                End If
                            ElseIf String.Compare(v_strType, "BD") = 0 Or String.Compare(v_strType, "SB") = 0 Then
                                'Biểu thức tính cho một dòng dữ liệu chi tiết
                                'Nếu là biểu thức tính toán                                
                                v_objCalculatorField = New CalculatedField
                                v_objCalculatorField.DataMember = mv_ds.Tables(0).TableName
                                v_objCalculatorField.DataSource = v_rptDoc.DataSource
                                v_objCalculatorField.Expression = v_objField.FLDEXPRESSION
                                v_objCalculatorField.Name = PREFIX_CALCULATION & v_objField.FLDNAME
                                tblCell.DataBindings.Add("Text", Nothing, PREFIX_CALCULATION & v_objField.FLDNAME)
                                'Định dạng trường số/ngày tháng
                                If v_objField.FLDFORMAT.Length > 0 Then
                                    tblCell.DataBindings(0).FormatString = v_objField.FLDFORMAT
                                End If
                                v_rptDoc.CalculatedFields.Add(v_objCalculatorField)
                            End If
                        End If
                        tblCell.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                    End If
                    tblRow.Cells.Add(tblCell)
                Next
                'Xử lý Colspan và Rowspan
                If v_strItemRemove.Length > 0 Then
                    v_strItemRemove = v_strItemRemove.Trim(",".ToCharArray)
                    Dim str() As String = v_strItemRemove.Split(",".ToCharArray)
                    For intItem As Integer = str.Length - 1 To 0 Step -1
                        tblCell = tblRow.Cells(CInt(str(intItem)))
                        Dim tblCellPre As XRTableCell = tblCell.PreviousCell
                        Dim sngWidth As Single = tblCell.WidthF
                        tblCell.WidthF = 0
                        tblCellPre.WidthF += sngWidth '- 1 'TIP
                        tblRow.Cells.Remove(tblCell)
                    Next
                End If
                v_strItemRemove = String.Empty

                'Thêm row dữ liệu
                tblRptSection.Rows.Add(tblRow)
            Next
        End If

        Return tblRptSection
    End Function

    'Khởi tạo các Section gốc
    Private Function PreCreateSection(ByVal v_rptDoc As XtraReport, ByVal v_strLang As String, ByVal v_strType As String, ByVal v_strName As String, _
                ByVal v_objRptSection As RptSection, Optional ByVal v_strPreFix As String = "", Optional ByVal v_intGroupLevel As Integer = 0, _
                Optional ByVal v_strGroupField As String = "") As Boolean
        Dim v_lngBasedHeight, v_lngBasedWidth As Long
        Dim refReportControl As XRControl, detail As DetailBand, pageHeader As PageHeaderBand, pageFooter As PageFooterBand, _
            rptHeader As ReportHeaderBand, rptFooter As ReportFooterBand, grpHeader As GroupHeaderBand, grpFooter As GroupFooterBand

        'Tạo Band
        If String.Compare(v_strType, "BD") = 0 Then
            'Detail report
            detail = New DetailBand
            detail.Height = CSng(Me.BODYDETAILHEIGHT)
            refReportControl = detail
        ElseIf String.Compare(v_strType, "SR") = 0 Then
            'Detail report
            detail = New DetailBand
            detail.Height = CSng(Me.BODYDETAILHEIGHT)
            refReportControl = detail
        ElseIf String.Compare(v_strType, "RH") = 0 Then
            rptHeader = New ReportHeaderBand
            rptHeader.HeightF = CSng(Me.RPTHEADERHEIGHT)
            refReportControl = rptHeader
        ElseIf String.Compare(v_strType, "RF") = 0 Then
            rptFooter = New ReportFooterBand
            rptFooter.HeightF = CSng(Me.RPTFOOTERHEIGHT)
            refReportControl = rptFooter
        ElseIf String.Compare(v_strType, "PH") = 0 Then
            pageHeader = New PageHeaderBand
            pageHeader.Height = Me.PAGEHEADERHEIGHT
            refReportControl = pageHeader
        ElseIf String.Compare(v_strType, "PF") = 0 Then
            pageFooter = New PageFooterBand
            pageFooter.HeightF = CSng(Me.PAGEFOOTERHEIGHT)
            refReportControl = pageFooter
        ElseIf String.Compare(v_strType, "GH") = 0 Then
            'Khởi tạo GroupHeader
            grpHeader = New GroupHeaderBand
            grpHeader.Name = v_strType & "." & v_strGroupField
            grpHeader.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(v_strGroupField, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
            grpHeader.Level = v_intGroupLevel
            grpHeader.HeightF = 0
            refReportControl = grpHeader
        ElseIf String.Compare(v_strType, "GF") = 0 Then
            'Khởi tạo GroupFooter
            grpFooter = New GroupFooterBand
            grpFooter.Name = v_strType & "." & v_strGroupField
            grpFooter.Level = v_intGroupLevel
            grpFooter.HeightF = 0
            refReportControl = grpFooter
        End If
        refReportControl.LocationF = New DevExpress.Utils.PointFloat(0.0!, v_objRptSection.GAPRATIO * mv_singleHeightItem)

        'Đặt kích thước chiều rộng
        If String.Compare(v_objRptSection.PORF, "P") = 0 Then
            'Theo tỷ lệ
            v_lngBasedWidth = (v_objRptSection.WIDTH / 100) * (v_rptDoc.PageWidth - Me.LEFTMARGIN - Me.RIGHTMARGIN)
        Else
            'Cố định
            v_lngBasedWidth = v_objRptSection.WIDTH
        End If

        If String.Compare(v_strType, "SR") = 0 Then
            Dim intLastLocationFloatItem As Single = 0.0!
            'Nếu là sub-report
            Dim v_subRpt As New BasedXtraReport
            v_subRpt.DataSource = Me.mv_ds
            If Not v_objRptSection.mv_objSubRptMaster.CreateReportLayout(v_subRpt, v_strLang) Then
                Return False
            End If
            'Đưa sub-report vào detail band
            Dim v_subReportControl As New XRSubreport
            v_subReportControl.Name = "subRPT." & v_strName
            v_subReportControl.ReportSource = v_subRpt
            v_subReportControl.LocationF = New DevExpress.Utils.PointFloat(0.0!, v_objRptSection.GAPRATIO * mv_singleHeightItem)
            v_rptDoc.Bands(BandKind.Detail).Controls.Add(v_subReportControl)
        Else
            Dim tblRptSection As DevExpress.XtraReports.UI.XRTable
            tblRptSection = CreateSectionTable(v_rptDoc, v_strLang, v_strType, v_objRptSection, refReportControl.Name, v_lngBasedWidth)
            If Not tblRptSection Is Nothing Then
                'Add band vào báo cáo
                Select Case v_objRptSection.GROUPTYPE
                    Case "RH"
                        v_rptDoc.Bands.Add(rptHeader)
                        v_rptDoc.Bands(BandKind.ReportHeader).Controls.Add(tblRptSection)
                    Case "RF"
                        v_rptDoc.Bands.Add(rptFooter)
                        v_rptDoc.Bands(BandKind.ReportFooter).Controls.Add(tblRptSection)
                    Case "PH"
                        v_rptDoc.Bands.Add(pageHeader)
                        v_rptDoc.Bands(BandKind.PageHeader).Controls.Add(tblRptSection)
                    Case "PF"
                        v_rptDoc.Bands.Add(pageFooter)
                        v_rptDoc.Bands(BandKind.PageFooter).Controls.Add(tblRptSection)
                    Case "GH"
                        grpHeader.Controls.Add(tblRptSection)
                        v_rptDoc.Bands.Add(grpHeader)
                    Case "GF"
                        grpFooter.Controls.Add(tblRptSection)
                        v_rptDoc.Bands.Add(grpFooter)
                    Case "BD"
                        v_rptDoc.Bands(BandKind.Detail).Controls.Add(tblRptSection)
                End Select
            End If
        End If

        Return True
    End Function

    'Create odd/even style
    Public Sub InitStyles()
        ' Create different odd and even styles
        Dim oddStyle As XRControlStyle = New XRControlStyle()
        Dim evenStyle As XRControlStyle = New XRControlStyle()
        ' Specify the odd style appearance
        oddStyle.BackColor = Color.White  'Color.LightBlue
        oddStyle.StyleUsing.UseBackColor = True
        oddStyle.StyleUsing.UseBorders = False
        oddStyle.Name = "OddStyle"
        ' Specify the even style appearance
        evenStyle.BackColor = Color.White 'Color.LightPink
        evenStyle.StyleUsing.UseBackColor = True
        evenStyle.StyleUsing.UseBorders = False
        evenStyle.Name = "EvenStyle"

        ' Add styles to report's style sheet
        Me.mv_RefRptDoc.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {oddStyle, evenStyle})
        CreateReportLayout(mv_RefRptDoc, UserLanguage)
        'AddHandler mv_RefRptDoc.BeforePrint, AddressOf BasedXtraReport_BeforePrint
    End Sub

    'Tạo layout của báo cáo trên cơ sở mv_arrObjSections & mv_arrObjMaster
    Public Function CreateReportLayout(ByVal v_rptDoc As XtraReport, Optional ByVal v_strLang As String = "VN") As Boolean
        Dim v_intCount, v_intPosition, v_intIndex As Integer
        Dim tblRptSection As DevExpress.XtraReports.UI.XRTable
        Try
            'Tham chiếu báo cáo sẽ xử lý
            mv_RefRptDoc = v_rptDoc
            v_rptDoc.Name = Me.RPTID

            'Thiết lập template cho báo cáo            
            If Me.ORIENTATION = "P" Then
                v_rptDoc.Landscape = False
            Else
                v_rptDoc.Landscape = True
            End If
            Select Case Me.PAPERSIZE
                Case "A3"
                    v_rptDoc.PaperKind = System.Drawing.Printing.PaperKind.A3
                Case "A4"
                    v_rptDoc.PaperKind = System.Drawing.Printing.PaperKind.A4
                Case "LT"
                    v_rptDoc.PaperKind = System.Drawing.Printing.PaperKind.Letter
                Case Else
                    v_rptDoc.PaperKind = System.Drawing.Printing.PaperKind.A4
            End Select

            'Khởi tạo các band
            v_intCount = mv_arrObjSections.GetLength(0)
            If v_intCount > 0 Then
                For v_intIndex = 0 To v_intCount - 1 Step 1
                    'Duyệt từng Band
                    If Not mv_arrObjSections(v_intIndex) Is Nothing Then
                        With mv_arrObjSections(v_intIndex)
                            If Not PreCreateSection(v_rptDoc, v_strLang, .GROUPTYPE, .FULLNAME, mv_arrObjSections(v_intIndex), , .GROUPLEVEL, .GROUPFIELD) Then
                                Return False
                            End If
                        End With

                    End If
                Next
            End If

            Return True
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    'Khởi tạo tham số định nghĩa cho report
    Public Function GetReportMasterDefinition(ByVal v_strRPTID As String, ByVal v_strTHEMECODE As String) As Boolean
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx, v_xmlNode As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strObjMsg, v_strVarName, v_strVarValue As String, v_intRowCount, v_intCount, i, j As Integer
        Dim v_objReportSection As RptSection, v_objReportField As RptLayoutField
        Try
            'Thiết lập tham số chung của báo cáo từ thông tin định trong RPTMASTER
            v_strSQL = "SELECT * FROM RPTMASTER WHERE RPTID='" & v_strRPTID & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count
            If (v_intRowCount > 0) Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strVarValue = .InnerText.ToString
                            v_strVarName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case v_strVarName
                                Case "RHEADER"
                                    Me.RPTHEADERHEIGHT = v_strVarValue
                                Case "PHEADER"
                                    Me.PAGEHEADERHEIGHT = v_strVarValue
                                Case "RFOOTER"
                                    Me.RPTFOOTERHEIGHT = v_strVarValue
                                Case "PFOOTER"
                                    Me.PAGEFOOTERHEIGHT = v_strVarValue
                                Case "RDETAIL"
                                    Me.BODYDETAILHEIGHT = v_strVarValue
                                Case "ORIENTATION"
                                    Me.ORIENTATION = v_strVarValue
                                Case "PSIZE"
                                    Me.PAPERSIZE = v_strVarValue
                                Case "DESCRIPTION"
                                    Me.RPTTITLE = v_strVarValue
                                Case "TOPMARGIN"
                                    Me.TOPMARGIN = v_strVarValue
                                Case "LEFTMARGIN"
                                    Me.LEFTMARGIN = v_strVarValue
                                Case "RIGHTMARGIN"
                                    Me.RIGHTMARGIN = v_strVarValue
                                Case "BOTTOMMARGIN"
                                    Me.BOTTOMMARGIN = v_strVarValue
                                Case "AORS"
                                    Me.AORS = v_strVarValue
                            End Select
                        End With
                    Next
                Next
            Else
                Return False
            End If

            Me.RPTID = v_strRPTID
            'Tạo các Band (group theo các thông tin từ bàng RPTGRPMST
            If String.Compare(Me.AORS, "S") = 0 Then
                v_strSQL = "SELECT RPTID, SUBRPTNO, GRPTYPE, FULLNAME, GRPLEVEL, GRPFIELD, SORTTYPE, LSTODR, PORF, GRPWIDTH, LINETOP, LINELEFT, LINERIGHT, LINEBOTTOM, LINEWEIGHT FROM RPTGRPMST " _
                        & "WHERE RPTID='RPTBASED' AND SUBRPTNO=0 AND GRPTYPE IN ('RH','RF','PF') AND " _
                        & "GRPTYPE NOT IN (SELECT GRPTYPE FROM RPTGRPMST WHERE SUBRPTNO=0 AND RPTID='" & RPTID & "') UNION ALL " _
                        & "SELECT RPTID, SUBRPTNO, GRPTYPE, FULLNAME, GRPLEVEL, GRPFIELD, SORTTYPE, LSTODR, PORF, GRPWIDTH, LINETOP, LINELEFT, LINERIGHT, LINEBOTTOM, LINEWEIGHT FROM RPTGRPMST " _
                        & "WHERE RPTID='" & RPTID & "' AND GRPTYPE NOT IN ('SN','SB')"
            Else
                v_strSQL = "SELECT RPTID, SUBRPTNO, GRPTYPE, FULLNAME, GRPLEVEL, GRPFIELD, SORTTYPE, LSTODR, PORF, GRPWIDTH, LINETOP, LINELEFT, LINERIGHT, LINEBOTTOM, LINEWEIGHT FROM RPTGRPMST " _
                        & "WHERE RPTID='" & RPTID & "' AND GRPTYPE NOT IN ('SN','SB')"
            End If
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count
            If (v_intRowCount > 0) Then
                'Số lượng section
                ReDim Me.mv_arrObjSections(v_intRowCount)
                For i = 0 To v_nodeList.Count - 1
                    v_objReportSection = New RptSection
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strVarValue = .InnerText.ToString
                            v_strVarName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case v_strVarName
                                Case "RPTID"
                                    v_objReportSection.RPTID = v_strVarValue    'Phải lấy đúng RPTID để xác định được bảng định nghĩa
                                Case "SUBRPTNO"
                                    v_objReportSection.SUBRPTNO = v_strVarValue
                                Case "GRPTYPE"
                                    v_objReportSection.GROUPTYPE = v_strVarValue
                                Case "FULLNAME"
                                    v_objReportSection.FULLNAME = v_strVarValue
                                Case "GRPLEVEL"
                                    v_objReportSection.GROUPLEVEL = v_strVarValue
                                Case "GRPFIELD"
                                    v_objReportSection.GROUPFIELD = v_strVarValue
                                Case "SORTTYPE"
                                    v_objReportSection.SORTTYPE = v_strVarValue
                                Case "PORF"
                                    v_objReportSection.PORF = v_strVarValue
                                Case "GRPWIDTH"
                                    v_objReportSection.WIDTH = v_strVarValue
                                Case "LINETOP"
                                    v_objReportSection.BDTOP = v_strVarValue
                                Case "LINELEFT"
                                    v_objReportSection.BDLEFT = v_strVarValue
                                Case "LINERIGHT"
                                    v_objReportSection.BDRIGHT = v_strVarValue
                                Case "LINEBOTTOM"
                                    v_objReportSection.BDBOTTOM = v_strVarValue
                                Case "LINEWEIGHT"
                                    v_objReportSection.BORDERWIDTH = v_strVarValue
                                Case "GAPRATIO"
                                    v_objReportSection.GAPRATIO = v_strVarValue
                            End Select
                        End With
                    Next

                    If String.Compare(v_objReportSection.GROUPTYPE, "SR") = 0 Then
                        Me.HASSUBREPORT = "Y"
                        'Nếu là sub-report
                        v_objReportSection.GetSubReportInfor(v_objReportSection.FULLNAME, v_strTHEMECODE, Me)
                    Else
                        'Lấy dữ liệu chi tiết được định nghĩa (các cell trong ban)
                        v_strSQL = "SELECT * FROM RPTGRPDTL WHERE RPTID='" & v_objReportSection.RPTID & "' AND GRPNAME='" & v_objReportSection.FULLNAME & "' AND THEMECODE='" _
                            & v_strTHEMECODE & "' AND GRPTYPE='" & v_objReportSection.GROUPTYPE & "' AND SUBRPTNO=" & v_objReportSection.SUBRPTNO & " " _
                            & "ORDER BY ROWNO, COLNO"   'Thứ tự order by là quan trọng
                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
                        v_ws.Message(v_strObjMsg)
                        v_objReportSection.InitSection(v_strObjMsg, v_objReportSection.GROUPTYPE)
                    End If

                    'Đưa vào sanh sách
                    Me.mv_arrObjSections(i) = v_objReportSection
                Next
            End If
            Return True
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
#End Region

End Class

<Serializable()> _
Public Class RptSection
    Private mv_intNumberOfRows As Integer
    Private mv_intNumberOfCols As Integer
    Private mv_strPORF As String = "P"
    Private mv_dblWidth As Double = 100
    Private mv_intHeight As Integer
    Private mv_intBorderWidth As Integer = 1        'Độ dày của bảng
    Private mv_strRPTID As String
    Private mv_intSubRptNo As Integer = 0
    Private mv_intGapRatio As Integer = 1
    Private mv_strGroupType As String
    Private mv_strFullName As String
    Private mv_intGroupLevel As Integer = 0
    Private mv_strGroupField As String
    Private mv_strSortType As String = "A"

    Private mv_strBorderTop As String = "N"
    Private mv_strBorderLeft As String = "N"
    Private mv_strBorderRight As String = "N"
    Private mv_strBorderBottom As String = "N"

    Public mv_objSubRptMaster As RptMaster              'Tham chiếu SUBREPORT
    Public mv_arrObjFields(10, 10) As RptLayoutField  'Mảng hai chiều HÀNG-CỘT, mặc định

    Public Property PORF() As String
        Get
            Return mv_strPORF
        End Get
        Set(ByVal Value As String)
            mv_strPORF = Value
        End Set
    End Property

    Public Property BDTOP() As String
        Get
            Return mv_strBorderTop
        End Get
        Set(ByVal Value As String)
            mv_strBorderTop = Value
        End Set
    End Property

    Public Property BDLEFT() As String
        Get
            Return mv_strBorderLeft
        End Get
        Set(ByVal Value As String)
            mv_strBorderLeft = Value
        End Set
    End Property

    Public Property BDRIGHT() As String
        Get
            Return mv_strBorderRight
        End Get
        Set(ByVal Value As String)
            mv_strBorderRight = Value
        End Set
    End Property

    Public Property BDBOTTOM() As String
        Get
            Return mv_strBorderBottom
        End Get
        Set(ByVal Value As String)
            mv_strBorderBottom = Value
        End Set
    End Property

    Public Property WIDTH() As Double
        Get
            Return mv_dblWidth
        End Get
        Set(ByVal Value As Double)
            mv_dblWidth = Value
        End Set
    End Property

    Public Property SUBRPTNO() As Integer
        Get
            Return mv_intSubRptNo
        End Get
        Set(ByVal Value As Integer)
            mv_intSubRptNo = Value
        End Set
    End Property

    Public Property RPTID() As String
        Get
            Return mv_strRPTID
        End Get
        Set(ByVal Value As String)
            mv_strRPTID = Value
        End Set
    End Property

    Public Property GROUPTYPE() As String
        Get
            Return mv_strGroupType
        End Get
        Set(ByVal Value As String)
            mv_strGroupType = Value
        End Set
    End Property

    Public Property FULLNAME() As String
        Get
            Return mv_strFullName
        End Get
        Set(ByVal Value As String)
            mv_strFullName = Value
        End Set
    End Property

    Public Property BORDERWIDTH() As Integer
        Get
            Return mv_intBorderWidth
        End Get
        Set(ByVal Value As Integer)
            mv_intBorderWidth = Value
        End Set
    End Property

    Public Property GROUPLEVEL() As Integer
        Get
            Return mv_intGroupLevel
        End Get
        Set(ByVal Value As Integer)
            mv_intGroupLevel = Value
        End Set
    End Property

    Public Property GROUPFIELD() As String
        Get
            Return mv_strGroupField
        End Get
        Set(ByVal Value As String)
            mv_strGroupField = Value
        End Set
    End Property

    Public Property SORTTYPE() As String
        Get
            Return mv_strSortType
        End Get
        Set(ByVal Value As String)
            mv_strSortType = Value
        End Set
    End Property

    Public Property HEIGHT() As Integer
        Get
            Return mv_intHeight
        End Get
        Set(ByVal Value As Integer)
            mv_intHeight = Value
        End Set
    End Property

    Public Property ROWSCOUNT() As Integer
        Get
            Return mv_intNumberOfRows
        End Get
        Set(ByVal Value As Integer)
            mv_intNumberOfRows = Value
        End Set
    End Property

    Public Property COLSCOUNT() As Integer
        Get
            Return mv_intNumberOfCols
        End Get
        Set(ByVal Value As Integer)
            mv_intNumberOfCols = Value
        End Set
    End Property

    Public Property GAPRATIO() As Integer
        Get
            Return mv_intGapRatio
        End Get
        Set(ByVal Value As Integer)
            mv_intGapRatio = Value
        End Set
    End Property

    'Dựng thông tin đầy đủ về một Section: một section name là duy nhất trong một subreport
    Public Sub GetReportSectionInfor(ByVal v_strRPTID As String, ByVal v_strGRPNAME As String, ByVal v_strTHEME As String, ByVal v_lngSUBRPTNO As Long)
        Dim v_strSQL, v_strObjMsg As String
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx, v_xmlNode As Xml.XmlNode, v_nodeList As Xml.XmlNodeList, v_objField As RptLayoutField
        Dim v_intRowCount, v_intColCount, v_intCount, i, j As Integer, v_strVarName, v_strVarValue As String
        Try
            'Lấy dữ liệu chung của section, vì là sectio
            v_strSQL = "SELECT * FROM RPTGRPMST WHERE RPTID='" & v_strRPTID & "' AND FULLNAME='" & v_strGRPNAME & "' AND SUBRPTNO=" & v_lngSUBRPTNO
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count
            If (v_intRowCount > 0) Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strVarValue = .InnerText.ToString
                            v_strVarName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case v_strVarName
                                Case "RPTID"
                                    Me.RPTID = v_strVarValue    'Phải lấy đúng RPTID để xác định được bảng định nghĩa
                                Case "SUBRPTNO"
                                    Me.SUBRPTNO = v_strVarValue
                                Case "GRPTYPE"
                                    Me.GROUPTYPE = v_strVarValue
                                Case "FULLNAME"
                                    Me.FULLNAME = v_strVarValue
                                Case "GRPLEVEL"
                                    Me.GROUPLEVEL = v_strVarValue
                                Case "GRPFIELD"
                                    Me.GROUPFIELD = v_strVarValue
                                Case "SORTTYPE"
                                    Me.SORTTYPE = v_strVarValue
                                Case "PORF"
                                    Me.PORF = v_strVarValue
                                Case "GRPWIDTH"
                                    Me.WIDTH = v_strVarValue
                                Case "LINETOP"
                                    Me.BDTOP = v_strVarValue
                                Case "LINELEFT"
                                    Me.BDLEFT = v_strVarValue
                                Case "LINERIGHT"
                                    Me.BDRIGHT = v_strVarValue
                                Case "LINEBOTTOM"
                                    Me.BDBOTTOM = v_strVarValue
                                Case "LINEWEIGHT"
                                    Me.BORDERWIDTH = v_strVarValue
                            End Select
                        End With
                    Next
                Next
            Else
                Exit Sub
            End If

            If String.Compare(Me.GROUPTYPE, "SR") = 0 Then
                'Nếu là sub-report: tạo một sub report master khác
                mv_objSubRptMaster = New RptMaster
            Else
                'Lấy dữ liệu chi tiết về section
                v_strSQL = "SELECT * FROM RPTGRPDTL WHERE RPTID='" & v_strRPTID & "' AND GRPNAME='" & v_strGRPNAME & "' AND THEMECODE='" _
                    & v_strTHEME & "' AND GRPTYPE='" & Me.GROUPTYPE & "' AND SUBRPTNO=" & v_lngSUBRPTNO & " " _
                    & "ORDER BY ROWNO, COLNO"   'Thứ tự order by là quan trọng
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                'Dựng cấu trúc của Section từ Schema truyền vào: Lấy theo Object message
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                v_intCount = v_xmlDocument.FirstChild.ChildNodes.Count
                v_intColCount = 0
                v_intRowCount = 0
                If (v_intCount > 0) Then
                    ReDim mv_arrObjFields(v_intCount, v_intCount)
                    v_xmlNode = v_xmlDocument.FirstChild
                    For i = 0 To v_nodeList.Count - 1
                        v_objField = New RptLayoutField
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strVarValue = .InnerText.ToString
                                v_strVarName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case v_strVarName
                                    Case "RPTID"
                                    Case "SUBRPTNO"
                                        v_objField.SUBREPORTNO = v_strVarValue
                                    Case "GRPTYPE"
                                        v_objField.GRPTYPE = v_strVarValue
                                    Case "GRPNAME"
                                        v_objField.GRPNAME = v_strVarValue
                                    Case "THEMECODE"
                                        v_objField.THEMECODE = v_strVarValue
                                    Case "FLDNAME"
                                        v_objField.FLDNAME = v_strVarValue
                                    Case "FLDTYPE"
                                        v_objField.FLDTYPE = v_strVarValue
                                    Case "PICPATH"
                                        v_objField.PICPATH = v_strVarValue
                                    Case "CAPTION"
                                        v_objField.CAPTION_VN = v_strVarValue
                                    Case "CAPTION_EN"
                                        v_objField.CAPTION_EN = v_strVarValue
                                    Case "FLDAMTEXP"
                                        v_objField.FLDEXPRESSION = v_strVarValue
                                    Case "GRPEXP"
                                        v_objField.FLDGROUPEXPRESSION = v_strVarValue
                                    Case "GRPREFNAME"
                                        v_objField.FLDGROUPREFFLDNAME = v_strVarValue
                                    Case "COLLEN"
                                        v_objField.FLDLENGTH = v_strVarValue
                                    Case "COLFORP"
                                        v_objField.FORP = v_strVarValue
                                    Case "COLWIDTH"
                                        v_objField.FLDWIDTH = v_strVarValue
                                    Case "COLHEIGHT"
                                        v_objField.FLDHEIGHT = CLng(v_strVarValue)
                                    Case "COLNO"
                                        v_objField.COLNO = CLng(v_strVarValue)
                                        v_intColCount = IIf(CDbl(v_strVarValue) > v_intColCount, CDbl(v_strVarValue), v_intColCount)
                                    Case "ROWNO"
                                        v_objField.ROWNO = CLng(v_strVarValue)
                                        v_intRowCount = IIf(CDbl(v_strVarValue) > v_intRowCount, CDbl(v_strVarValue), v_intRowCount)
                                    Case "COLSPAN"
                                        v_objField.FLDCOLSPAN = IIf(v_strVarValue = "Y", True, False)
                                    Case "ROWSPAN"
                                        v_objField.FLDROWSPAN = IIf(v_strVarValue = "Y", True, False)
                                    Case "COLALIGN"
                                        If v_strVarValue = "L" Then
                                            v_objField.FLDFIELDALIGN = 0
                                        ElseIf v_strVarValue = "R" Then
                                            v_objField.FLDFIELDALIGN = 1
                                        ElseIf v_strVarValue = "C" Then
                                            v_objField.FLDFIELDALIGN = 2
                                        Else
                                            v_objField.FLDFIELDALIGN = 0
                                        End If
                                    Case "BACKCOLOR"
                                        v_objField.BACKCOLOR = v_strVarValue
                                    Case "FORECOLOR"
                                        v_objField.FORECOLOR = v_strVarValue
                                    Case "FLDFORMAT"
                                        v_objField.FLDFORMAT = v_strVarValue
                                    Case "FONTNAME"
                                        v_objField.FLDFONTNAME = v_strVarValue
                                    Case "FONTSIZE"
                                        v_objField.FLDFONTSIZE = CByte(v_strVarValue)
                                    Case "FONTYPE"
                                        v_objField.FLDFONTBOLD = IIf(v_strVarValue.ToUpper.IndexOf("B") >= 0, True, False)
                                        v_objField.FLDFONTITALIC = IIf(v_strVarValue.ToUpper.IndexOf("I") >= 0, True, False)
                                        v_objField.FLDFONTUNDERLINE = IIf(v_strVarValue.ToUpper.IndexOf("U") >= 0, True, False)
                                    Case "WRAPTEXT"
                                        v_objField.WRAPTEXT = IIf(v_strVarValue = "Y", True, False)
                                    Case "VISIBLE"
                                        v_objField.VISIBLE = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINETOP"
                                        v_objField.FLDBORDERTOP = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINELEFT"
                                        v_objField.FLDBORDERLEFT = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINERIGHT"
                                        v_objField.FLDBORDERRIGHT = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINEBOTTOM"
                                        v_objField.FLDBORDERBOTTOM = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINEWEIGHT"
                                        v_objField.FLDBORDERWEIGTH = v_strVarValue
                                End Select
                            End With
                        Next
                        'Thêm object
                        mv_arrObjFields(v_objField.ROWNO, v_objField.COLNO) = v_objField
                        Me.COLSCOUNT = v_intColCount + 1
                        Me.ROWSCOUNT = v_intRowCount + 1
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    'Dựng thông tin chi tiết về một section
    Public Sub InitSection(ByVal v_strSectionSchema As String, Optional ByVal v_strSectionType As String = "")
        Dim v_xmlDocument As New XmlDocumentEx, v_xmlNode As Xml.XmlNode, v_nodeList As Xml.XmlNodeList, v_objField As RptLayoutField
        Dim v_intRowCount, v_intColCount, v_intCount, i, j As Integer, v_strVarName, v_strVarValue As String
        Try
            If v_strSectionSchema.Length = 0 Then
                InitDemoSection(v_strSectionType)
            Else
                'Dựng cấu trúc của Section từ Schema truyền vào: Lấy theo Object message
                v_xmlDocument.LoadXml(v_strSectionSchema)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                v_intCount = v_xmlDocument.FirstChild.ChildNodes.Count
                v_intColCount = 0
                v_intRowCount = 0
                If (v_intCount > 0) Then
                    ReDim mv_arrObjFields(v_intCount, v_intCount)
                    v_xmlNode = v_xmlDocument.FirstChild
                    For i = 0 To v_nodeList.Count - 1
                        v_objField = New RptLayoutField
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strVarValue = .InnerText.ToString
                                v_strVarName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case v_strVarName
                                    Case "RPTID"
                                    Case "SUBRPTNO"
                                        v_objField.SUBREPORTNO = v_strVarValue
                                    Case "GRPTYPE"
                                        v_objField.GRPTYPE = v_strVarValue
                                    Case "GRPNAME"
                                        v_objField.GRPNAME = v_strVarValue
                                    Case "THEMECODE"
                                        v_objField.THEMECODE = v_strVarValue
                                    Case "FLDNAME"
                                        v_objField.FLDNAME = v_strVarValue
                                    Case "FLDTYPE"
                                        v_objField.FLDTYPE = v_strVarValue
                                    Case "PICPATH"
                                        v_objField.PICPATH = v_strVarValue
                                    Case "CAPTION"
                                        v_objField.CAPTION_VN = v_strVarValue
                                    Case "CAPTION_EN"
                                        v_objField.CAPTION_EN = v_strVarValue
                                    Case "FLDAMTEXP"
                                        v_objField.FLDEXPRESSION = v_strVarValue
                                    Case "GRPEXP"
                                        v_objField.FLDGROUPEXPRESSION = v_strVarValue
                                    Case "GRPREFNAME"
                                        v_objField.FLDGROUPREFFLDNAME = v_strVarValue
                                    Case "COLLEN"
                                        v_objField.FLDLENGTH = v_strVarValue
                                    Case "COLFORP"
                                        v_objField.FORP = v_strVarValue
                                    Case "COLWIDTH"
                                        v_objField.FLDWIDTH = v_strVarValue
                                    Case "COLHEIGHT"
                                        v_objField.FLDHEIGHT = CLng(v_strVarValue)
                                    Case "COLNO"
                                        v_objField.COLNO = CLng(v_strVarValue)
                                        v_intColCount = IIf(CDbl(v_strVarValue) > v_intColCount, CDbl(v_strVarValue), v_intColCount)
                                    Case "ROWNO"
                                        v_objField.ROWNO = CLng(v_strVarValue)
                                        v_intRowCount = IIf(CDbl(v_strVarValue) > v_intRowCount, CDbl(v_strVarValue), v_intRowCount)
                                    Case "COLSPAN"
                                        v_objField.FLDCOLSPAN = IIf(v_strVarValue = "Y", True, False)
                                    Case "ROWSPAN"
                                        v_objField.FLDROWSPAN = IIf(v_strVarValue = "Y", True, False)
                                    Case "COLALIGN"
                                        If v_strVarValue = "L" Then
                                            v_objField.FLDFIELDALIGN = 0
                                        ElseIf v_strVarValue = "R" Then
                                            v_objField.FLDFIELDALIGN = 1
                                        ElseIf v_strVarValue = "C" Then
                                            v_objField.FLDFIELDALIGN = 2
                                        Else
                                            v_objField.FLDFIELDALIGN = 0
                                        End If
                                    Case "BACKCOLOR"
                                        v_objField.BACKCOLOR = v_strVarValue
                                    Case "FORECOLOR"
                                        v_objField.FORECOLOR = v_strVarValue
                                    Case "FLDFORMAT"
                                        v_objField.FLDFORMAT = v_strVarValue
                                    Case "FONTNAME"
                                        v_objField.FLDFONTNAME = v_strVarValue
                                    Case "FONTSIZE"
                                        v_objField.FLDFONTSIZE = CByte(v_strVarValue)
                                    Case "FONTYPE"
                                        v_objField.FLDFONTBOLD = IIf(v_strVarValue.ToUpper.IndexOf("B") >= 0, True, False)
                                        v_objField.FLDFONTITALIC = IIf(v_strVarValue.ToUpper.IndexOf("I") >= 0, True, False)
                                        v_objField.FLDFONTUNDERLINE = IIf(v_strVarValue.ToUpper.IndexOf("U") >= 0, True, False)
                                    Case "WRAPTEXT"
                                        v_objField.WRAPTEXT = IIf(v_strVarValue = "Y", True, False)
                                    Case "VISIBLE"
                                        v_objField.VISIBLE = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINETOP"
                                        v_objField.FLDBORDERTOP = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINELEFT"
                                        v_objField.FLDBORDERLEFT = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINERIGHT"
                                        v_objField.FLDBORDERRIGHT = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINEBOTTOM"
                                        v_objField.FLDBORDERBOTTOM = IIf(v_strVarValue = "Y", True, False)
                                    Case "LINEWEIGHT"
                                        v_objField.FLDBORDERWEIGTH = v_strVarValue
                                End Select
                            End With
                        Next
                        'Thêm object
                        mv_arrObjFields(v_objField.ROWNO, v_objField.COLNO) = v_objField
                        Me.COLSCOUNT = v_intColCount + 1
                        Me.ROWSCOUNT = v_intRowCount + 1
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    'Dựng thông tin về sub-report
    Public Function GetSubReportInfor(ByVal v_strRPTID As String, ByVal v_strTHEMECODE As String, ByVal v_objParentRptMaster As RptMaster) As Boolean
        Dim v_intCount, i As Integer, v_dblReturn As Boolean
        mv_objSubRptMaster = New RptMaster

        'Copy bộ tham số hệ thống từ MasterReport
        v_intCount = v_objParentRptMaster.mv_arrRefFormulaName.GetLength(0) - 1
        If v_intCount > 0 Then
            ReDim mv_objSubRptMaster.mv_arrRefFormulaName(v_intCount)
            ReDim mv_objSubRptMaster.mv_arrRefFormulaValue(v_intCount)
            For i = 0 To v_intCount
                mv_objSubRptMaster.mv_arrRefFormulaName(i) = v_objParentRptMaster.mv_arrRefFormulaName(i)
                mv_objSubRptMaster.mv_arrRefFormulaValue(i) = v_objParentRptMaster.mv_arrRefFormulaValue(i)
            Next
        End If
        mv_objSubRptMaster.mv_ds = v_objParentRptMaster.mv_ds
        mv_objSubRptMaster.mv_strReportDirectory = v_objParentRptMaster.mv_strReportDirectory

        'Lấy tham số về sub-report
        v_dblReturn = mv_objSubRptMaster.GetReportMasterDefinition(v_strRPTID, v_strTHEMECODE)
        Return v_dblReturn
    End Function

    'Chỉ sử dụng để test
    Private Sub InitDemoSection(ByVal v_strType As String)
        Dim v_intRow, v_intCol As Integer, v_objField As RptLayoutField
        ReDim mv_arrObjFields(ROWSCOUNT, COLSCOUNT)
        'Mặc định: dùng để demo
        For v_intRow = 0 To ROWSCOUNT - 1 Step 1
            For v_intCol = 0 To COLSCOUNT - 1 Step 1
                v_objField = New RptLayoutField
                'Tạo tham số cấu trúc
                If String.Compare(v_strType, "BD") = 0 Then
                    'Khung chứa phần chi tiết: Body 03 trường CHAR, NUM
                    v_objField.FLDEXPRESSION = String.Empty
                    If v_intCol <= 2 Then
                        v_objField.FLDNAME = "CHAR0" & v_intCol
                    ElseIf v_intCol <= 5 And v_intCol > 2 Then
                        v_objField.FLDNAME = "NUM0" & v_intCol - 3
                    Else
                        'Biểu thức
                        v_objField.FLDNAME = "CAL0" & v_intCol
                        v_objField.FLDEXPRESSION = "NUM00+NUM01"
                    End If
                    v_objField.CAPTION_EN = "EN " & v_objField.FLDNAME
                    v_objField.CAPTION_VN = "VN " & v_objField.FLDNAME
                ElseIf String.Compare(v_strType, "GH") = 0 Then
                    v_objField.FLDNAME = v_intRow & "." & v_intCol
                    v_objField.FLDGROUPFIELD = "CHAR00"
                    If v_intRow = 1 And v_intCol = 0 Then
                        v_objField.CAPTION_EN = "Section "
                        v_objField.CAPTION_VN = "Vùng "
                    ElseIf v_intRow = 1 And v_intCol = 1 Then
                        v_objField.FLDCOLSPAN = True
                    ElseIf v_intRow = 1 And v_intCol = 2 Then
                        v_objField.FLDGROUPREFFLDNAME = "CHAR00"
                        v_objField.FLDFONTBOLD = True
                    Else
                        v_objField.CAPTION_EN = "EN " & v_objField.FLDNAME
                        v_objField.CAPTION_VN = "VN " & v_objField.FLDNAME
                    End If
                ElseIf String.Compare(v_strType, "GF") = 0 Then
                    If v_intRow = ROWSCOUNT - 1 Then
                        'Hiển thị phép toán ở dòng cuối cùng
                        If v_intCol = 0 Then
                            v_objField.FLDNAME = "GCHAR0" & v_intCol
                            v_objField.FLDGROUPFIELD = "CHAR00"
                            v_objField.FLDGROUPREFFLDNAME = "CHAR00"
                        ElseIf v_intCol <= 2 And v_intCol > 0 Then
                            v_objField.FLDNAME = "GCHAR0" & v_intCol
                            v_objField.FLDCOLSPAN = True
                        ElseIf v_intCol <= 5 And v_intCol > 2 Then
                            v_objField.FLDNAME = "GSUM0" & v_intCol - 3
                            v_objField.FLDEXPRESSION = "NUM0" & v_intCol - 3  'Tham số đầu vào cho biểu thức tính GROUPEXPRESSION
                            v_objField.FLDGROUPFIELD = "CHAR00"
                            If v_intCol = 3 Then v_objField.FLDGROUPEXPRESSION = "AVG"
                            If v_intCol = 4 Then v_objField.FLDGROUPEXPRESSION = "SUM"
                            If v_intCol = 5 Then v_objField.FLDGROUPEXPRESSION = "MAX"
                        Else
                            'Biểu thức
                            v_objField.FLDNAME = "GCAL0" & v_intCol
                            v_objField.CAPTION_EN = "EN " & v_objField.FLDNAME
                            v_objField.CAPTION_VN = "VN " & v_objField.FLDNAME
                            v_objField.FLDGROUPFIELD = "CHAR00"
                            v_objField.FLDEXPRESSION = "GSUM00+GSUM01"
                        End If
                    Else
                        v_objField.FLDNAME = v_intRow & "." & v_intCol
                        v_objField.CAPTION_EN = "EN " & v_objField.FLDNAME
                        v_objField.CAPTION_VN = "VN " & v_objField.FLDNAME
                        v_objField.FLDGROUPFIELD = "CHAR00"
                    End If
                Else
                    'Khung các phần section khác
                    v_objField.FLDNAME = v_intRow & "." & v_intCol
                    v_objField.CAPTION_EN = "EN " & v_objField.FLDNAME
                    v_objField.CAPTION_VN = "VN " & v_objField.FLDNAME
                    If v_intRow = 0 And v_intCol = 2 Then v_objField.FLDCOLSPAN = True
                    If v_intRow <> 0 And v_intCol = 0 Then v_objField.FLDROWSPAN = True
                    If v_intRow = 2 And v_intCol = 2 Then v_objField.FLDROWSPAN = True
                    'Thuộc tính kẻ bảng
                    If BORDERWIDTH = 0 Then
                        'Nếu không kẻ bảng
                        v_objField.FLDBORDERTOP = False
                        v_objField.FLDBORDERBOTTOM = False
                        v_objField.FLDBORDERRIGHT = False
                        v_objField.FLDBORDERLEFT = False
                    Else
                        v_objField.FLDBORDERTOP = True
                        v_objField.FLDBORDERLEFT = True
                        If v_intRow <> ROWSCOUNT - 1 Then
                            v_objField.FLDBORDERBOTTOM = False
                        Else
                            v_objField.FLDBORDERBOTTOM = True
                        End If

                        If v_intCol <> COLSCOUNT - 1 Then
                            v_objField.FLDBORDERRIGHT = False
                        Else
                            v_objField.FLDBORDERRIGHT = True
                        End If
                    End If
                End If
                'Đăng ký danh sách
                mv_arrObjFields(v_intRow, v_intCol) = v_objField
            Next
        Next

    End Sub

End Class
