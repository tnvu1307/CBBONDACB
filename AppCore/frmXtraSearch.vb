Imports System.IO
Imports System.Xml
Imports CommonLibrary.modCommond
Imports CommonLibrary
Imports DevExpress.Data.Filtering
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmXtraSearch
    Inherits FormBase

#Region " Contructor "
    Public Sub New()

        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = gc_LANG_VIETNAMESE
    End Sub

    Public Sub New(ByVal pv_strLanguage As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage
    End Sub
#End Region

#Region " Khai báo hằng, biến "
    Const c_ResourceManager = "AppCore.frmSearch-"
    Dim mv_dblTR_QTTY As Double = 0
    Protected WithEvents SearchCell As Xceed.Grid.Cell
    Public mv_strSearchFilter As String
    Public mv_strSearchFilterStore As String
    Public hFilter As New Hashtable
    Public hFilterStore As New Hashtable
    Public mv_frmTransactScreen As frmXtraTransact
    Private thread As Threading.Timer = New Threading.Timer(AddressOf AutoSearch, Nothing, -1, -1)

    Public mv_blnAutoSearch As Boolean = False
    Public mv_blSEQNUM As Boolean = False

    'Khai bao cac bien cho khop lenh bang tay
    Public mv_strCONFIRM_NO As String = String.Empty
    Public mv_strCUSTODYCD As String = String.Empty
    Public mv_strB_CUSTODYCD As String = String.Empty
    Public mv_strS_CUSTODYCD As String = String.Empty
    Public mv_strBORS As String = String.Empty
    Public mv_strSEC_CODE As String = String.Empty
    Public mv_intQUANTITY As Integer = 0
    Public mv_intB_QUANTITY As Integer = 0
    Public mv_intS_QUANTITY As Integer = 0
    Public mv_dblPRICE As Double = 0
    Public mv_strMATCH_DATE As String = String.Empty
    Public v_strS_ACCOUNT_NO As String = String.Empty
    Public v_strB_ACCOUNT_NO As String = String.Empty
    Public v_strS_ORDER_NO As String = String.Empty
    Public v_strB_ORDER_NO As String = String.Empty

    Private mv_strCommandType As String = gc_CommandText
    Private mv_strBANKINQ As String = ""
    Private mv_strBANKACCT As String = ""
    Private mv_strCondDefFld As String = ""
    Private mv_strStoreName As String = ""
    Private mv_strStoreParam As String = ""
    Private mv_blnLoadLastSearch As Boolean = True
    Public mv_AutoFilter As Boolean = False
    Private mv_strCMDTYPE As String
    Protected mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Public mv_strCELLSDEFINETable As New DataTable

    Protected mv_strCmdSql As String
    Protected mv_ISFLTCODEID As String = "N"
    Protected mv_ISFLTMBCODE As String = "N"
    Protected mv_strCmdSqlTemp As String
    Private mv_strcmdMenu As String
    Private mv_strTLTXCD As String
    Protected mv_strSrOderByCmd As String
    Protected mv_strObjName As String
    Private mv_strSearchAuthCode As String = ""
    Private mv_strRowLimit As String
    Private mv_strMenuType As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Public mv_strCMDID As String
    Private mv_blnSearchOnInit As Boolean
    Private mv_strAuthCode As String
    Public mv_strAuthString As String
    Private mv_strSearchByTransact As Boolean = False
    Private mv_strIsLookup As String = "N"
    Private mv_strReturnValue As String
    Private mv_strRefValue As String
    Private mv_strReturnData As String
    Private mv_strXMLData As String
    Private mv_intDblGrid As Integer = 0
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_isAutoSubmitWhenExecue As Boolean = False
    Private mv_isQuickSearch As Boolean = False

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Protected mv_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Giá trị mặc định
    Protected mv_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     'Dộ rộng hiển thị trên lưới
    Private mv_arrStrTLTXCD() As String
    Private mv_arrStrTLTXNAME As Hashtable
    Private mv_arrStrTLTXMAPFLD As Hashtable                    'Mapping giao dich
    Private mv_arrStrTLTXNAMEREF As Hashtable                   'Cho filter
    Private mv_arrStrTLTXMAPFLDREF As Hashtable

    Private mv_arrStFieldMandartory() As String                  'Có bắt buộc nhập điều kiện tìm kiếm không M. Mandartory, Y. Yes but optional
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '
    Private mv_arrStQuickSearch() As String                   '
    Private mv_arrStSummaryCode() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerRight As String
    Protected mv_strGroupCareBy As String
    Protected mv_intpage As Int32 = 1
    Protected mv_rowpage As Int32 = 0
    Protected mv_intInterval As Int32 = 0
    Private mv_strBusDate As String
    Private mv_strTimesearch As String
    Private mv_strCUSTID As String
    Private mv_strAFACCTNO As String


    Private mv_SelectedRow As Xceed.Grid.Row

    Private mv_strEnableSearchFilter As Boolean = True
    Private mv_strLinkValue As String
    Private mv_strLinkFieldSrc As String
    Private mv_strLinkFieldDes As String
    Private mv_strNextDate As String
    Private mv_strCompanyCode As String
    Private mv_strCompanyName As String
    Private mv_strParentObjName As String
    Private mv_strParentClause As String

    Private mv_strDefaultSearchFilter As String = String.Empty

    Public mv_frmSearchScreen As frmSearch

    'Variables used for CareBy filter - Modified by TungNT
    Protected mv_isCareBy As Boolean = False
    'End Modified
    Protected mv_strSymbolList As String
    Protected mv_SymbolTable As New DataTable

    Private mv_strIsSMS As String
    Private mv_strIsEMAIL As String
    Private mv_SearchData As DataSet

    Private mv_SearchDataTABLE As DataTable
    Private mv_intTotalRow As Integer
    Private mv_intTotalCountRow As Integer
    Private gvSearchSelection As GridCheckMarksSelection
    Public mv_strSearchClause As String = ""
    Public mv_strTellerName As String
    Private v_strObjMsg_search As String = ""
    Protected mv_COUNTRYTable As New DataTable

    'For Popup Menu
    Private mv_PopupMenuItem() As DevExpress.Utils.Menu.DXMenuItem

    Dim ds As New DataSet
    Dim dr As DataRow
    Private mv_CriteriaOperator As CriteriaOperatorCollection
    Public mv_CriteriaOperator_String As String

    'Private mv_arrStrTLTXNAME As Hashtable
    'Private mv_arrStrTLTXMAPFLD As Hashtable                    'Mapping giao dich
    'Private mv_arrStrTLTXNAMEREF As Hashtable                   'Cho filter
    'Private mv_arrStrTLTXMAPFLDREF As Hashtable

#End Region

#Region " Các thuộc tính của form "

    Public Property COUNTRYTable() As DataTable
        Get
            Return mv_COUNTRYTable
        End Get
        Set(ByVal Value As DataTable)
            mv_COUNTRYTable = Value
        End Set
    End Property

    Public Property mv_CriteriaOperator_Notify() As CriteriaOperatorCollection
        Get
            Return mv_CriteriaOperator
        End Get
        Set(ByVal Value As CriteriaOperatorCollection)
            mv_CriteriaOperator = Value
        End Set
    End Property
    Public Property mv_CriteriaOperator_Notify_String() As String
        Get
            Return mv_CriteriaOperator_String
        End Get
        Set(ByVal Value As String)
            mv_CriteriaOperator_String = Value
        End Set
    End Property

    Public Property CELLSDEFINETable() As DataTable
        Get
            Return mv_strCELLSDEFINETable
        End Get
        Set(ByVal Value As DataTable)
            mv_strCELLSDEFINETable = Value
        End Set
    End Property

    Public Property CompanyCode() As String
        Get
            Return mv_strCompanyCode
        End Get
        Set(ByVal Value As String)
            mv_strCompanyCode = Value
        End Set
    End Property
    Public Property CompanyName() As String
        Get
            Return mv_strCompanyName
        End Get
        Set(ByVal Value As String)
            mv_strCompanyName = Value
        End Set
    End Property
    Public Property StoreName() As String
        Get
            Return mv_strStoreName
        End Get
        Set(ByVal Value As String)
            mv_strStoreName = Value
        End Set
    End Property
    Public Property StoreParam() As String
        Get
            Return mv_strStoreParam
        End Get
        Set(ByVal Value As String)
            mv_strStoreParam = Value
        End Set
    End Property
    Public Property CommandType() As String
        Get
            Return mv_strCommandType
        End Get
        Set(ByVal Value As String)
            mv_strCommandType = Value
        End Set
    End Property

    Public Property LoadLastFilter() As Boolean
        Get
            Return mv_blnLoadLastSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnLoadLastSearch = Value
        End Set
    End Property

    Public Property DefaultSearchFilter() As String
        Get
            Return mv_strDefaultSearchFilter
        End Get
        Set(ByVal Value As String)
            mv_strDefaultSearchFilter = Value
        End Set
    End Property

    Public Property CUSTID() As String
        Get
            Return mv_strCUSTID
        End Get
        Set(ByVal Value As String)
            mv_strCUSTID = Value
        End Set
    End Property

    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property
    Public Property isAutoSearch() As Boolean
        Get
            Return mv_blnAutoSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAutoSearch = Value
        End Set
    End Property

    Public Property AutoSubmitWhenExecute() As Boolean
        Get
            Return mv_isAutoSubmitWhenExecue
        End Get
        Set(ByVal Value As Boolean)
            mv_isAutoSubmitWhenExecue = Value
        End Set
    End Property

    Public Property CMDMenu() As String
        Get
            Return mv_strcmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strcmdMenu = Value
        End Set
    End Property


    Public Property Timesearch() As String
        Get
            Return mv_strTimesearch
        End Get
        Set(ByVal Value As String)
            mv_strTimesearch = Value
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

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFieldSrc() As String
        Get
            Return mv_strLinkFieldSrc
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldSrc = Value
        End Set
    End Property

    Public Property LinkFieldDes() As String
        Get
            Return mv_strLinkFieldDes
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldDes = Value
        End Set
    End Property

    Public Property EnableSearchFilter() As Boolean
        Get
            Return mv_strEnableSearchFilter
        End Get
        Set(ByVal Value As Boolean)
            mv_strEnableSearchFilter = Value
        End Set
    End Property

    Public Property NextDate() As String
        Get
            Return mv_strNextDate
        End Get
        Set(ByVal Value As String)
            mv_strNextDate = Value
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

    Public Property RETURNDATA() As String
        Get
            Return mv_strReturnData
        End Get
        Set(ByVal Value As String)
            mv_strReturnData = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property RefValue() As String
        Get
            Return mv_strRefValue
        End Get
        Set(ByVal Value As String)
            mv_strRefValue = Value
        End Set
    End Property

    Public Property IsLookup() As String
        Get
            Return mv_strIsLookup
        End Get
        Set(ByVal Value As String)
            mv_strIsLookup = Value
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

    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
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

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
        End Set
    End Property

    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property

    Public ReadOnly Property MaintenanceFormName() As String
        Get
            Return mv_strFormName
        End Get
    End Property

    Public Property MenuType() As String
        Get
            Return mv_strMenuType
        End Get
        Set(ByVal Value As String)
            mv_strMenuType = Value
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

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
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

    Public Property SearchOnInit() As Boolean
        Get
            Return mv_blnSearchOnInit
        End Get
        Set(ByVal Value As Boolean)
            mv_blnSearchOnInit = Value
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

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
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

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    'Visible button
    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
        End Set
    End Property

    'Enable button
    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property
    Public Property SearchByTransact() As Boolean
        Get
            Return mv_strSearchByTransact
        End Get
        Set(ByVal Value As Boolean)
            mv_strSearchByTransact = Value
        End Set
    End Property
    Public Property SEQNUM() As Boolean
        Get
            Return mv_blSEQNUM
        End Get
        Set(ByVal Value As Boolean)
            mv_blSEQNUM = Value
        End Set
    End Property

    Public Property CMDTYPE() As String
        Get
            Return mv_strCMDTYPE
        End Get
        Set(ByVal Value As String)
            mv_strCMDTYPE = Value
        End Set
    End Property


    'Modified by TungNT
    Public Property CareByFilter() As Boolean
        Get
            Return mv_isCareBy
        End Get
        Set(ByVal Value As Boolean)
            mv_isCareBy = Value
        End Set
    End Property
    'End Modified
    Public Property SymbolList() As String
        Get
            Return mv_strSymbolList
        End Get
        Set(ByVal Value As String)
            mv_strSymbolList = Value
        End Set
    End Property

    Public Property SymbolTable() As DataTable
        Get
            Return mv_SymbolTable
        End Get
        Set(ByVal Value As DataTable)
            mv_SymbolTable = Value
        End Set
    End Property

    Public Property ParentObjName() As String
        Get
            Return mv_strParentObjName
        End Get
        Set(ByVal Value As String)
            mv_strParentObjName = Value
        End Set
    End Property

    Public Property ParentClause() As String
        Get
            Return mv_strParentClause
        End Get
        Set(ByVal Value As String)
            mv_strParentClause = Value
        End Set
    End Property

    Public ReadOnly Property SearchGridControl() As GridControl
        Get
            Return SearchGrid
        End Get

    End Property

    Public ReadOnly Property SearchGridView() As GridView
        Get
            Return gvResult
        End Get

    End Property

#End Region

#Region " Overridable Function "
    Public Overridable Sub OnClose()
        Try
            If Me.IsLookup = "Y" Then
                'Nếu là form search dùng để lookup thì trả v giá trị tìm kiếm

                'Nếu là form search dùng để lookup thì trả v? giá trị tìm kiếm
                If SearchGridView.RowCount > 0 Then
                    If Not SearchGridView.GetFocusedDataRow() Is Nothing Then
                        If SearchGridView.FocusedRowHandle >= 0 Then
                            ReturnValue = SearchGridView.GetFocusedDataRow().Item(mv_strKeyColumn)
                            If Len(mv_strRefColumn) > 0 Then
                                RefValue = SearchGridView.GetFocusedDataRow().Item(mv_strRefColumn)
                            Else
                                RefValue = String.Empty
                            End If
                        End If
                    End If
                End If
                Me.Close()
            Else

                'Ghi nhận lại đi?u kiện tìm kiếm lần cuối cùng
                SaveLastSearch()
                Me.Dispose()
            End If
            thread.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Protected Overridable Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        Select Case pv_intExecFlag
            Case ExecuteFlag.AddNew
                bbiNew.Caption = mv_ResourceManager.GetString("ExecuteFlag.AddNew")
            Case ExecuteFlag.View
                bbiView.Caption = mv_ResourceManager.GetString("ExecuteFlag.View")
            Case ExecuteFlag.Edit
                bbiEdit.Caption = mv_ResourceManager.GetString("ExecuteFlag.Edit")
            Case ExecuteFlag.Delete
                bbiDelete.Caption = mv_ResourceManager.GetString("ExecuteFlag.Delete")
            Case ExecuteFlag.SendSMS
                ' = mv_ResourceManager.GetString("ExecuteFlag.SendSMS")
            Case ExecuteFlag.Email
                'ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Email")
        End Select
    End Function

    Protected Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
        Dim i As Integer
        Dim v_strFLDNAME, v_KeyValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, v_strMessage As String

        Dim v_intFrom, v_intTo As Int32
        Try
            'Update mouse pointer
            v_KeyValue = String.Empty
            If Not gvResult.RowCount = 0 Then
                If Not gvResult.GetFocusedDataRow() Is Nothing Then
                    If KeyColumn Is Nothing Then
                    Else
                        v_KeyValue = gvResult.GetFocusedDataRow()(KeyColumn)
                    End If
                End If
            End If

            Cursor.Current = Cursors.WaitCursor

            'Update status bar
            bsiStatus.Caption = mv_ResourceManager.GetString("frmSearch.Searching")
            bsiExectionFlag.Caption = String.Empty
            mv_strSearchFilter = String.Empty
            mv_strSearchFilterStore = String.Empty

            If CommandType = gc_CommandProcedure Then 'Command Procedure
                StoreName = mv_strCmdSql
                If Me.bciCheckAll.Checked = True Then
                    v_intTo = 900000000
                    v_intFrom = 0
                    Dim v_strObjMsg As String = BuildSearchMessage(v_intFrom, v_intTo, pv_strModule)
                    SaveLastSearchObj(v_strObjMsg)
                    v_ws.Message(v_strObjMsg)

                    FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, mv_SearchData.Tables(0).Rows.Count, mv_SearchData.Tables(0).Rows.Count)

                Else
                    v_intTo = page * mv_rowpage
                    v_intFrom = v_intTo + 1 - mv_rowpage

                    Dim v_strObjMsg As String = BuildSearchMessage(v_intFrom, v_intTo, pv_strModule)

                    v_ws.Message(v_strObjMsg)
                    Me.FULLDATA = v_strObjMsg


                    StoreParam = "p_GET_TOTAL_ROW!1!Double!20" & _
                                    "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                                    "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                                    "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

                    v_strObjMsg = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                      gc_ActionInquiry, StoreName, StoreParam, , , , , , , CommandType)
                    SaveLastSearchObj(v_strObjMsg)
                    v_ws.Message(v_strObjMsg)

                    Dim v_xmlDocument As New XmlDocumentEx
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim v_strVALUE As String
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For v_intCount As Integer = 0 To v_nodeList.Count - 1
                        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                                Select Case v_strFLDNAME
                                    Case "COUNTROW"
                                        mv_intTotalRow = CInt(v_strVALUE)
                                End Select
                            End With
                        Next
                    Next

                    'Fill data into search grid
                    FillDataXtraGrid(SearchGrid, Me.FULLDATA, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, mv_intTotalRow)

                End If

            Else 'Command text. Only for defaul condition
                'If ModuleCode & "." & mv_strObjName = OBJNAME_CA_CAMAST And Me.CMDMenu <> "" Then
                '    mv_strSearchFilter = " AND TYPEID = '" & Microsoft.VisualBasic.Strings.Right(Me.CMDMenu, 3) & "'"
                'End If

                'TODO: build criterial
                'For i = 0 To lstCondition.Items.Count - 1
                '    If lstCondition.GetItemChecked(i) Then
                '        mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                '    End If
                'Next i

                'If used advanced search
                If (Not (fcCriterial.CriterialProperty.FilterCriteria) Is Nothing) Then
                    Dim op As CriteriaOperator = fcCriterial.CriterialProperty.FilterCriteria
                    mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
                Else
                    'Used quick search
                    BuildQuickCriterial()
                End If

                'Các điều kiện tìm kiếm bắt buộc sẽ phải nhập nếu không báo lỗi
                v_strMessage = String.Empty
                For i = 0 To mv_arrStFieldMandartory.GetLength(0) - 1
                    If UCase(mv_arrStFieldMandartory(i)) = "M" Then
                        'Bắt buộc phải nhập thì tìm kiếm xem trong xâu mv_strSearchFilter có trường này không
                        If Not mv_strSearchFilter.IndexOf(mv_arrSrFieldSrch(i)) >= 0 Then
                            If v_strMessage.Length = 0 Then
                                v_strMessage = mv_arrSrFieldDisp(i)
                            Else
                                v_strMessage = v_strMessage & ", " & mv_arrSrFieldDisp(i)
                            End If
                        End If
                    End If
                Next
                If v_strMessage.Length > 0 Then
                    MsgBox(mv_ResourceManager.GetString("REQUIRE_SEARCHFILTER") & ControlChars.CrLf & v_strMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Code doan nay cho phan quyen du lieu
                Dim v_strFUNDFilter, v_strMEMBERFilter As String
                If mv_ISFLTCODEID = "Y" Then
                    Dim v_strSQL As String
                    If mv_strTellerId <> ADMIN_ID Then
                        v_strSQL = "SELECT f.codeid FROM tlfunds f,(SELECT TLID FROM TLPROFILES WHERE TLID ='" & mv_strTellerId & "' UNION ALL SELECT COPPYTLID TLID FROM TLCOPPYRIGHT WHERE TLID ='" & mv_strTellerId & "' AND " _
                                 & " STATUS='A' AND FRDATE <=GETCURRDATE AND TODATE >= GETCURRDATE )TL " _
                                 & " WHERE f.tltype ='U' AND f.tlid = TL.TLID " _
                                 & " UNION ALL " _
                                 & " SELECT codeid FROM tlfunds  WHERE tltype ='G' AND tlid  IN " _
                                 & " (SELECT GRPID FROM TLGRPUSERS WHERE TLID ='" & mv_strTellerId & "' " _
                                 & " UNION ALL " _
                                 & " SELECT G.GRPID FROM TLCOPPYRIGHT T, TLGRPUSERS G WHERE " _
                                 & " G.TLID = T.COPPYTLID AND T.TLID = '" & mv_strTellerId & "' AND " _
                                 & " T.STATUS='A' AND T.FRDATE <=GETCURRDATE AND T.TODATE >= GETCURRDATE)"
                        v_strFUNDFilter &= " AND  CODEID IN ( " & v_strSQL & " ) "
                    End If
                    mv_strSearchFilter &= v_strFUNDFilter
                End If

                If mv_ISFLTMBCODE = "Y" Then
                    Dim v_strSQL As String
                    If mv_strTellerId <> ADMIN_ID Then
                        v_strSQL = "SELECT M.MBCODE FROM TLMEMBERS M, " _
                            & " (SELECT TLID FROM TLPROFILES WHERE TLID ='" & mv_strTellerId & "' UNION ALL SELECT COPPYTLID TLID FROM TLCOPPYRIGHT WHERE TLID ='" & mv_strTellerId & "' AND " _
                             & " STATUS='A' AND FRDATE <=GETCURRDATE AND TODATE >= GETCURRDATE )TL" _
                             & " WHERE M.TLTYPE ='U' AND M.TLID = TL.TLID" _
                        & " UNION ALL" _
                            & " SELECT mbcode FROM tlmembers WHERE tltype ='G' AND tlid  IN " _
                            & " (SELECT GRPID FROM TLGRPUSERS WHERE TLID ='" & mv_strTellerId & "' " _
                            & " UNION ALL " _
                            & " SELECT G.GRPID FROM TLCOPPYRIGHT T, TLGRPUSERS G WHERE " _
                            & " G.TLID = T.COPPYTLID AND T.TLID = '" & mv_strTellerId & "' AND " _
                            & " T.STATUS='A' AND T.FRDATE <=GETCURRDATE AND T.TODATE >= GETCURRDATE)"
                        v_strMEMBERFilter &= " AND  mbcode IN ( " & v_strSQL & " ) "
                        mv_strSearchFilter &= v_strMEMBERFilter
                    End If
                End If


                mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

                If mv_strSearchClause.Length > 0 Then
                    If mv_strSearchFilter.Length > 0 Then
                        mv_strSearchFilter = mv_strSearchFilter & " AND " & mv_strSearchClause
                    Else
                        mv_strSearchFilter = mv_strSearchClause
                    End If

                End If

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    v_intTo = page * mv_rowpage
                    v_intFrom = v_intTo + 1 - mv_rowpage

                    If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
                        mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
                    End If

                    If Not mv_blSEQNUM Then
                        If mv_strSearchFilter = "" Then
                            If mv_strSrOderByCmd <> "" Then
                                mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
                            Else
                                mv_strSearchFilter = " 0 = 0 "
                            End If
                            If Me.bciCheckAll.Checked = True Or mv_rowpage <= 0 Then
                                strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                            Else
                                If mv_strRowLimit = "Y" Then
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1 WHERE ROWNUM <= " & v_intTo & ") WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                    'ElseIf pv_strModule = "OD.OD8893" And mv_strRowLimit = "N" Then
                                    '    strRow = mv_strCmdSql
                                Else
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                End If
                            End If
                            'If pv_strModule = "OD.OD8893" Then
                            '    mv_strCmdSqlTemp = mv_strCmdSql
                            'Else
                            '    mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                            'End If
                            mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                        Else
                            If Me.bciCheckAll.Checked = True Or mv_rowpage <= 0 Then
                                strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)" '  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                            Else
                                If mv_strRowLimit = "Y" Then
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1  WHERE ROWNUM <= " & v_intTo & ")  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                Else
                                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                                End If
                            End If

                            mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter
                        End If
                    Else
                        'HaiLT them 
                        'Neu trong cau lenh SEARCH co seqnum.nextval thi phai co dieu kien san trong cau lenh     
                        If mv_strSearchFilter <> "" Then
                            strRow = mv_strCmdSql & " AND " & mv_strSearchFilter
                        Else
                            strRow = mv_strCmdSql
                        End If
                    End If

                    If SearchByTransact = True Then
                        strRow = strRow.Replace("<$BRID>", HO_BRID)
                    Else
                        strRow = strRow.Replace("<$BRID>", Me.BranchId)
                    End If
                    'TheNN sua
                    strRow = strRow.Replace("<$HO_MBID>", HO_MBID)
                    strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
                    strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)
                    strRow = strRow.Replace("<$AFACCTNO>", Me.AFACCTNO)
                    strRow = strRow.Replace("<$CUSTID>", Me.CUSTID)
                    strRow = strRow.Replace("<@KEYVALUE>", LinkValue)
                    strRow = strRow.Replace("<$TELLERID>", Me.TellerId)

                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                        strRow = strRow.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                    Else
                        strRow = strRow.Replace("<@CDCONTENT>", "CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "DESCRIPTION")
                    End If

                    'VanNT
                    Dim v_strObjMsg As String
                    If Me.bciCheckAll.Checked = True Then
                        v_strObjMsg = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow, , , , , "L")
                    Else
                        v_strObjMsg = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow)
                    End If
                    SaveLastSearchObj(v_strObjMsg)
                    v_ws.Message(v_strObjMsg)

                    Dim v_xmlDocument As New Xml.XmlDocument

                    If Me.bciCheckAll.Checked = True Then
                        mv_SearchData = New DataSet
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        mv_SearchData = ConvertXmlDocToDataSet(v_xmlDocument)

                        mv_SearchDataTABLE = New DataTable()
                        mv_SearchDataTABLE = ConvertXmlDocToDataSet(v_xmlDocument).Tables(0)

                        SearchGrid.DataSource = mv_SearchDataTABLE

                        mv_intTotalCountRow = SearchGridView.RowCount
                    Else
                        Me.FULLDATA = v_strObjMsg
                        'Fill data into search grid
                        mv_intTotalCountRow = CountRow()
                        mv_SearchDataTABLE = New DataTable()
                        mv_SearchDataTABLE = ObjDataToDataset(v_strObjMsg, , mv_strTableName)
                        SearchGrid.DataSource = mv_SearchDataTABLE
                        'FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, mv_intTotalCountRow)

                    End If


                End If
            End If

            'Format data in search grid
            XtraGridFormat(gvResult, c_ResourceManager & UserLanguage, mv_arrSrFieldSrch, mv_arrSrFieldType, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)
            'gvResult.OptionsView.ShowIndicator = True
            'gvResult.IndicatorWidth = 35
            bsiStatus.Caption = String.Empty
            'Update mouse pointer
            Cursor.Current = Cursors.Default
            'Set forcus

            SetFocusGrid(v_KeyValue)

            If bciCheckAll.Checked = True Then
                Me.bbiNext.Enabled = False
                Me.bbiPrev.Enabled = False
            Else
                If mv_intpage = 1 Then
                    bbiPrev.Enabled = False
                    If gvResult.RowCount < mv_intTotalCountRow Then
                        bbiNext.Enabled = True
                    End If
                Else
                    If gvResult.RowCount < mv_rowpage Then
                        bbiNext.Enabled = False
                        bbiPrev.Enabled = True
                    Else
                        bbiNext.Enabled = True
                        bbiPrev.Enabled = True
                    End If
                End If
            End If
            RefreshToolBar()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
        Return 0
    End Function

    Protected Function BuildSearchMessage(v_intFrom As Integer, v_intTo As Integer, pv_strModule As String) As String
        Dim i As Integer
        If mv_isQuickSearch And grpQuickSearch.Visible Then
            BuildQuickCriterial()
        Else
            BuildCriterial()
        End If


        mv_strSearchFilterStore &= "||" & "<$MBID>" & ":" & Me.BranchId
        mv_strSearchFilterStore &= "||" & "<$HO_MBID>" & ":" & HO_MBID
        mv_strSearchFilterStore &= "||" & "<$BUSDATE>" & ":" & Me.BusDate
        mv_strSearchFilterStore &= "||" & "<$AFACCTNO>" & ":" & Me.AFACCTNO
        mv_strSearchFilterStore &= "||" & "<$CUSTID>" & ":" & Me.CUSTID
        mv_strSearchFilterStore &= "||" & "<@KEYVALUE>" & ":" & LinkValue
        mv_strSearchFilterStore &= "||" & "<$TELLERID>" & ":" & Me.TellerId

        If Me.UserLanguage = gc_LANG_ENGLISH Then
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@CDCONTENT>", "EN_CDCONTENT")
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
        Else
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@CDCONTENT>", "CDCONTENT")
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@DESCRIPTION>", "DESCRIPTION")
        End If

        StoreParam = "p_GET_TOTAL_ROW!0!Double!20" & _
                     "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                     "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                     "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

        Return BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                              gc_ActionInquiry, StoreName, StoreParam, , , , "L", , , CommandType)
    End Function

    Private Sub BuildCriterial()
        'TODO: build criterial from filter control
    End Sub


    Protected Overridable Function GetRowPage() As Int32
        Dim v_strCmdInquiry As String
        Dim v_strRowPage As String = String.Empty
        v_strCmdInquiry = "select VARVALUE from SYSVAR where VARNAME='ROWPERPAGE'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim RowPage As Int32
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
                                v_strRowPage = Trim(v_strValue)
                                Exit For
                        End Select
                    End With
                Next
            Next
            RowPage = CInt(v_strRowPage)
            Return RowPage
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return 0
        End Try
    End Function

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
    Protected Overridable Function OnExport() As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_filetype As String
            'CreateExcelFile.CreateExcelDocument(ds, targetFilename)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName

                'trung.luu check extension khi chon export all file (*.*)
                Dim extension As String = Path.GetExtension(v_strFileName)
                If extension = "" Then
                    MsgBox(mv_ResourceManager.GetString("frmSearch.NothingExtension"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
                'v_filetype = Mid(v_strFileName, Len(v_strFileName) - 3)
                v_filetype = Mid(v_strFileName, InStr(v_strFileName, "."))
                'If v_filetype = ".txt" Or v_filetype = ".csv" Then
                ' If v_filetype = ".txt" Then
                ' Dim v_strData As String
                ' Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                ' If (gvResult.RowCount > 0) Then
                ' 'Write file's header
                ' v_strData = String.Empty
                ' For idx As Integer = 0 To gvResult.Columns.Count - 1
                ' If gvResult.Columns(idx).Visible Then
                ' If gvResult.Columns(idx).Caption <> "Mark" Then
                ' v_strData &= gvResult.Columns(idx).Caption & vbTab
                ' End If

                ' End If
                ' Next
                ' v_streamWriter.WriteLine(v_strData)

                ' 'Write data
                ' For i As Integer = 0 To gvResult.RowCount - 1
                ' v_strData = String.Empty

                ' For j As Integer = 0 To gvResult.Columns.Count - 1
                ' If gvResult.Columns(j).Visible Then

                ' If gvResult.Columns(j).Caption <> "Mark" Then
                ' If v_filetype = ".txt" Then
                ' v_strTemp = "@" & CStr(gvResult.GetDataRow(i)(j))
                ' Else
                ' v_strTemp = CStr(gvResult.GetDataRow(i)(j))
                ' End If

                ' v_strData &= v_strTemp & vbTab
                ' End If
                ' End If
                ' Next

                ' 'Write data to the file
                ' v_streamWriter.WriteLine(v_strData)
                ' Next
                ' Else
                ' MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ' Exit Function
                ' End If

                ' 'Close StreamWriter
                ' v_streamWriter.Close()
                ' Else
                ' 'Ghi file excel
                ' 'thunt-03/01/2019-ket xuat csv vao day
                ' Dim v_Ew As New ExcelLib
                ' v_Ew.ExportData(v_strFileName, SearchGrid, v_filetype)
                ' End If
                'Ghi file excel
                'thunt-03/01/2019-ket xuat vao day
                Dim v_Ew As New ExcelLib
                v_Ew.ExportData(v_strFileName, SearchGrid, v_filetype)
                MsgBox(mv_ResourceManager.GetString("frmSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Exit Function

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Sub OnExpand()
        Try

            sccSearch.Collapsed = Not sccSearch.Collapsed

        Catch ex As Exception
            LogError.Write("Error source: OnExpand ::" & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Overridable Function OnPrint() As Int32
        Dim v_strErrorSource, v_strErrorMessage, v_strSQL As String, v_lngError As Long, v_intRow As Integer
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Try
            If gvResult.RowCount > 0 Then
                v_strKeyFieldName = gvResult.GetFocusedDataRow()(mv_strKeyColumn).FieldName
                v_strKeyFieldValue = gvResult.GetFocusedDataRow()(mv_strKeyColumn).Value
                v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")

                'Nạp dữ liệu Header cho báo cáo tên View là: VW_PRINT_SEARCH_[SEARCHCODE]
                v_strSQL = "SELECT * FROM VW_PRINT_SEARCH_" & mv_strTableName & " WHERE KEYVALUE='" & v_strKeyFieldValue & "'"


                'Tạo báo cáo với StoredName=SearchCode

            Else
                MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToPrint"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return -1
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
        End Try

        Return 0
    End Function

    Protected Overridable Function OnBankInq() As Int32
        Return 0
    End Function

    Function GetBankBalance(ByVal pv_strACCTNO As String) As String
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

    Protected Overridable Function OnCompare() As Int32
        Try
            If Me.TableName = "CA1001" Then
                'Doi chieu so du LK khong hien thi du lieu tim kiem
                'Su dung trong truong hop du lieu lon

                Dim v_frm As New frmSearchCMP2FILE(Me.UserLanguage)
                v_frm.FULLDATA = "CA1001"
                v_frm.Searchcode = Me.TableName
                v_frm.ModuleCode = Me.ModuleCode
                v_frm.BranchId = Me.BranchId
                v_frm.TellerId = Me.TellerId
                v_frm.IpAddress = Me.IpAddress
                v_frm.WsName = Me.WsName
                v_frm.BusDate = Me.BusDate
                v_frm.Desc = Me.FormCaption
                v_frm.ISRPT = "Y"
                v_frm.ShowDialog()
            Else
                If gvResult.RowCount > 0 Then
                    Dim v_frm As New frmSearchCMP2FILE(Me.UserLanguage)
                    v_frm.FULLDATA = Me.FULLDATA
                    If Not IsDBNull(mv_SearchData) Then
                        v_frm.mv_OldData = Me.mv_SearchData
                    End If
                    v_frm.Searchcode = Me.TableName
                    v_frm.ModuleCode = Me.ModuleCode
                    v_frm.BranchId = Me.BranchId
                    v_frm.TellerId = Me.TellerId
                    v_frm.IpAddress = Me.IpAddress
                    v_frm.WsName = Me.WsName
                    v_frm.BusDate = Me.BusDate
                    v_frm.Desc = Me.FormCaption
                    v_frm.ShowDialog()
                Else
                    MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToCompare"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnAddNew() As Int32
        If ShowForm(ExecuteFlag.AddNew) = DialogResult.OK Then
            If SearchOnInit = True Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        End If
    End Function
    Protected Overridable Function OnExecuteList() As Int32
        Try

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLTXCD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long, v_intRow As Integer


            If Not SearchGrid Is Nothing Then
                If gvResult.RowCount > 0 Then
                    For v_intRow = 0 To gvResult.RowCount - 1 Step 1
                        If Not gvResult.GetDataRow(v_intRow) Is Nothing Then
                            If gvResult.GetDataRow(v_intRow)("__TICK").Value = "X" Then
                                v_strTXNUM = Trim(gvResult.GetDataRow(v_intRow)("TXNUM").Value)
                                v_strTXDATE = Trim(gvResult.GetDataRow(v_intRow)("TXDATE").Value)

                                'Lấy thông tin chi tiết v? �điện giao dịch
                                Dim v_strClause, v_strObjMsg As String
                                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteAutoGV", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If

                            End If
                        End If
                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("search.DeleteSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    Protected Overridable Function OnExecutedel() As Int32
        Try

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLTXCD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long, v_intRow As Integer


            If Not SearchGrid Is Nothing Then
                If gvResult.RowCount > 0 Then
                    For v_intRow = 0 To gvResult.RowCount - 1 Step 1
                        If Not gvResult.GetDataRow(v_intRow) Is Nothing Then
                            If gvResult.GetDataRow(v_intRow)("__TICK").Value = "X" Then
                                v_strTXNUM = Trim(gvResult.GetDataRow(v_intRow)("TXNUM").Value)
                                v_strTXDATE = Trim(gvResult.GetDataRow(v_intRow)("TXDATE").Value)

                                'Lấy thông tin chi tiết v? �điện giao dịch
                                Dim v_strClause, v_strObjMsg As String
                                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteAutoGV", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If


                            End If
                        End If
                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("search.DeleteSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    Protected Overridable Sub ExecuteCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Money(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Securities(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteOD9996(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ConfirmCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ProcessOrder(ByVal pv_TableName As String, ByVal pv_GridRow As Xceed.Grid.DataRow)

    End Sub

    Protected Overridable Function SetPaymentOrderList(ByRef v_strObjMsg As String) As Int32

    End Function

    Protected Overridable Sub PrintPaymentOrder(ByVal pv_strVoucherID As String, Optional ByVal blnPrePrint As Double = False)

    End Sub

    Protected Overridable Function OnExecute(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Int32

    End Function

    Protected Overridable Sub RegisterOnline(ByRef pv_AUTOID As String, ByRef pv_CustomerType As String, ByRef pv_CustomerName As String, _
                                             ByRef pv_CustomerBirth As String, ByRef pv_IDType As String, ByRef pv_IDCode As String, _
                                             ByRef pv_Iddate As String, ByRef pv_Idplace As String, ByRef pv_Expiredate As String, _
                                             ByRef pv_Address As String, ByRef pv_Taxcode As String, ByRef pv_PrivatePhone As String, _
                                             ByRef pv_Mobile As String, ByRef pv_Fax As String, ByRef pv_Email As String, _
                                             ByRef pv_Office As String, ByRef pv_Position As String, ByRef pv_Country As String, _
                                             ByRef pv_CustomerCity As String, ByRef pv_TKTGTT As String)

    End Sub


    'Popup Menu
    Private Sub gridView_PopupMenuClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim v_strTLTXCD, v_strTXNAME As String, item As DevExpress.Utils.Menu.DXMenuItem
        Dim view As GridView = TryCast(sender, GridView)
        Dim v_hashTLTX As Hashtable
        If e.MenuType = GridMenuType.Row Then
            v_hashTLTX = GetExecuteTLTXCD()
            For Each objKey As String In v_hashTLTX.Keys
                v_strTLTXCD = objKey
                v_strTXNAME = v_hashTLTX.Item(objKey)
                'Show validated TLTXCD
                item = New DevExpress.Utils.Menu.DXMenuItem(v_strTLTXCD & "." & v_strTXNAME)
                item.Tag = v_strTLTXCD
                AddHandler item.Click, AddressOf item_Click
                e.Menu.Items.Add(item)
            Next
        End If
    End Sub

    Private Sub item_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim v_strTLTXCD, v_strTXNAME, v_strFLDCODE, v_strValue, objKey, itemField As String
        Dim v_intRowCount, v_intCol, v_intRow As Integer, v_blnIsThatTLTXCD As Boolean = True
        Dim menuItem As DevExpress.Utils.Menu.DXMenuItem = TryCast(sender, DevExpress.Utils.Menu.DXMenuItem)
        v_strTLTXCD = menuItem.Tag  'The selected TLTXCD
        'Validate the TLTXCD
        v_intRowCount = gvResult.GetSelectedRows.Count
        If v_intRowCount > 0 Then
            OnExecute(v_strTLTXCD)
        End If
    End Sub

    'Get TLTXCD for Execute button
    Function GetExecuteTLTXCD() As Hashtable
        Dim i, j, v_intRow, v_intCol As Integer, v_hashTLTX As New Hashtable(), v_blnIsThatTLTXCD As Boolean, arrTXFLD() As String
        Dim itemField, v_strTXNAME, v_strFLDCODE, v_strValue, objKey As String
        Try
            'Prevent multiple with check All
            If Not Me.bciExecuteAll.Checked Then
                'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                If Not SearchGrid Is Nothing Then
                    If gvResult.RowCount > 0 Then
                        For v_intRow = 0 To gvSearchSelection.SelectedCount - 1
                            'Sau khi l
                            If Not gvSearchSelection.GetSelectedRow(v_intRow) Is Nothing Then
                                'Truoc khi khoi tao form giao dich da clear selection nen luc nao cung lay phan tu so 0
                                'Determine appropriate TLTXCD
                                'Determine the corresponse TLTXCD base on the selected value on the screen. 
                                For Each objKey In mv_arrStrTLTXNAME.Keys
                                    v_strTXNAME = mv_arrStrTLTXNAME.Item(objKey)
                                    v_blnIsThatTLTXCD = True
                                    'Kiem tra cac gia tri cua cot trong row duoc chon co phu hop voi giao dich khong
                                    For v_intCol = 0 To gvResult.Columns.Count - 1
                                        v_strFLDCODE = gvResult.Columns(v_intCol).FieldName
                                        If v_strFLDCODE <> "CheckMarkSelection" Then
                                            v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(v_strFLDCODE)).Trim
                                            If mv_arrStrTLTXMAPFLDREF.ContainsKey(objKey & "." & v_strFLDCODE) Then
                                                itemField = mv_arrStrTLTXMAPFLDREF.Item(objKey & "." & v_strFLDCODE).trim
                                                If itemField.Length > 0 Then
                                                    If Not itemField.IndexOf(v_strValue) >= 0 Then
                                                        v_blnIsThatTLTXCD = False
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                    If v_blnIsThatTLTXCD Then
                                        v_hashTLTX.Add(objKey, v_strTXNAME)
                                    End If
                                Next objKey
                            End If
                        Next
                    End If
                End If
            End If

            Return v_hashTLTX
        Catch ex As Exception
            'Throw ex
            Return v_hashTLTX
        End Try
    End Function

    'On press TLTXCD
    Protected Overridable Function OnExecute(Optional ByVal v_strRefTLTXCD As String = vbNullString, Optional ByVal IsDoubleClick As Boolean = False) As Int32
        Dim v_strSQL, v_strClause, v_strObjMsg As String, v_lngError As Long = ERR_SYSTEM_OK
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_execTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate, v_strRefExecuteTLTXCD, v_strRefExecuteTXNAME, v_strErrorMessage As String, v_hashTLTX As Hashtable

        'Which TLTXCD is OK
        If Me.mv_strTLTXCD.Length > 0 Then
            If Not mv_strTLTXCD.IndexOf("/") > 0 Then
                'Khi execute goi den giao dich thi thuc hien o day
                'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
                v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD, SEARCHFLD.FIELDTYPE " & ControlChars.CrLf _
                    & "FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
                    & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(TRIM(SEARCH.TLTXCD))=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
                v_execTLTXCD = mv_strTLTXCD
            Else
                If v_strRefTLTXCD IsNot Nothing AndAlso v_strRefTLTXCD.Length > 0 Then
                    v_strSQL = "SELECT APPMODULES.MODCODE, SEARCHTXMAPFLD.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHTXMAPFLD.FLDCD, SEARCHFLD.FIELDTYPE " & ControlChars.CrLf _
                        & "FROM APPMODULES, SEARCH, SEARCHFLD, SEARCHTXMAPFLD " & ControlChars.CrLf _
                        & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SEARCH.SEARCHCODE=SEARCHTXMAPFLD.SEARCHCODE " & ControlChars.CrLf _
                        & "AND SEARCHFLD.FIELDCODE=SEARCHTXMAPFLD.FIELDCODE AND LENGTH(TRIM(NVL(SEARCHTXMAPFLD.FLDCD,'')))>0" & ControlChars.CrLf _
                        & "AND APPMODULES.TXCODE=SUBSTR(SEARCHTXMAPFLD.TLTXCD,1,2) AND LENGTH(TRIM(SEARCHTXMAPFLD.TLTXCD))=4 " _
                        & "AND SEARCH.SEARCHCODE='" & mv_strTableName & "' AND SEARCHTXMAPFLD.TLTXCD='" & v_strRefTLTXCD & "'"
                    v_execTLTXCD = v_strRefTLTXCD
                Else
                    v_hashTLTX = GetExecuteTLTXCD()
                    If v_hashTLTX.Count > 0 Then
                        If v_hashTLTX.Count = 1 Then
                            v_strRefExecuteTLTXCD = v_hashTLTX.Keys(0)
                        Else
                            'thunt-11/03/2020: mở cho chọn 2 giao dịch cùng lúc
                            'Popup choose which TLTXCD
                            'if have more than once TLTXCD => end user choose which TLTXCD: Show Popup Menu
                            'For Each objKey In v_hashTLTX.Keys
                            '    v_strRefExecuteTLTXCD = objKey
                            '    v_strRefExecuteTXNAME = v_hashTLTX.Item(objKey)
                            '    v_strMODCODE = mv_arrStrTLTXNAMEREF(objKey)
                            'Next
                            'Popup choose which TLTXCD
                            'if have more than once TLTXCD => end user choose which TLTXCD: Show Popup Menu
                            'tiennv
                            'Choose one transaction
                            Dim frm = New frmXtraSearch__ChooseTransaction(v_hashTLTX)
                            frm.ShowDialog()

                            Dim dtDataRow As DataRow = frm.DataRowChoose
                            If (dtDataRow Is Nothing) Then
                                Exit Function
                            End If


                            'For Each objKey() In v_hashTLTX.Keys
                            '    v_strRefExecuteTLTXCD = objKey()
                            '    v_strRefExecuteTXNAME = v_hashTLTX.Item(objKey)
                            '    v_strMODCODE = mv_arrStrTLTXNAMEREF(objKey)
                            'Next

                            v_strRefExecuteTLTXCD = dtDataRow("TRANSACTION_CODE")
                            v_strRefExecuteTXNAME = v_hashTLTX.Item(dtDataRow("TRANSACTION_CODE"))
                            v_strMODCODE = mv_arrStrTLTXNAMEREF(dtDataRow("TRANSACTION_CODE"))
                            v_execTLTXCD = v_strRefExecuteTLTXCD
                        End If
                        'Xu ly lan luot tung giao dich
                        If v_strRefExecuteTLTXCD.Length > 0 Then
                            v_strSQL = "SELECT APPMODULES.MODCODE, SEARCHTXMAPFLD.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHTXMAPFLD.FLDCD, SEARCHFLD.FIELDTYPE " & ControlChars.CrLf _
                                & "FROM APPMODULES, SEARCH, SEARCHFLD, SEARCHTXMAPFLD " & ControlChars.CrLf _
                                & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SEARCH.SEARCHCODE=SEARCHTXMAPFLD.SEARCHCODE " & ControlChars.CrLf _
                                & "AND SEARCHFLD.FIELDCODE=SEARCHTXMAPFLD.FIELDCODE AND LENGTH(TRIM(NVL(SEARCHTXMAPFLD.FLDCD,'')))>0" & ControlChars.CrLf _
                                & "AND APPMODULES.TXCODE=SUBSTR(SEARCHTXMAPFLD.TLTXCD,1,2) AND LENGTH(TRIM(SEARCHTXMAPFLD.TLTXCD))=4 " _
                                & "AND SEARCH.SEARCHCODE='" & mv_strTableName & "' AND SEARCHTXMAPFLD.TLTXCD='" & v_strRefExecuteTLTXCD & "'"
                        End If
                    Else
                        'Show message cannot execute all
                        MsgBox("Cannot use multi select", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                        Exit Function
                    End If
                End If
            End If
        Else
            Exit Function
        End If

        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        'v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD, SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
        '    & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty
        If Not Me.bciExecuteAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                If Not SearchGrid Is Nothing Then
                    If gvResult.RowCount > 0 Then
                        Dim v_intCountSelected As Integer = 0

                        'tiennv
                        Dim drs As ArrayList = New ArrayList
                        If (IsDoubleClick) Then
                            Dim drv As DataRowView = gvResult.GetFocusedRow()
                            If drv Is Nothing Then
                                MsgBox("No selected data found")
                                Exit Function
                            End If
                            drs.Add(drv)
                        Else
                            drs = gvSearchSelection.GetSelectionRows()
                        End If

                        For v_intRow = 0 To drs.Count - 1
                            'Sau khi l
                            If Not drs(v_intRow) Is Nothing Then
                                v_intCountSelected += 1
                                'Truoc khi khoi tao form giao dich da clear selection nen luc nao cung lay phan tu so 0
                                For i = 0 To v_nodeList.Count - 1
                                    v_strFLDCODE = String.Empty
                                    v_strFLDCD = String.Empty
                                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strValue = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "MODCODE"
                                                    v_strMODCODE = Trim(v_strValue)
                                                Case "TLTXCD"
                                                    v_strTLTXCD = Trim(v_strValue)
                                                Case "FIELDCODE"
                                                    v_strFLDCODE = Trim(v_strValue)
                                                Case "FLDCD"
                                                    v_strFLDCD = Trim(v_strValue)
                                                Case "FIELDTYPE"
                                                    v_strFIELDTYPE = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next

                                    If v_strFLDCD <> "" Then
                                        If String.Compare(v_strFLDCD, "PD") = 0 Then
                                            'Neu la truong posting date
                                            If drs.Count > 0 Then
                                                v_strValue = gf_CorrectStringField(drs(v_intRow)(v_strFLDCODE))
                                                v_strValue = Replace(v_strValue, ".", "")
                                                v_strPostingDate = v_strValue
                                            Else
                                                v_strPostingDate = v_strValue
                                            End If

                                        Else
                                            'Neu la truong binh thuong 
                                            If drs.Count > 0 Then
                                                v_strValue = gf_CorrectStringField(drs(v_intRow)(v_strFLDCODE))
                                                If v_strFIELDTYPE = "C" And v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION" And v_strTLTXCD <> "6679" And v_strTLTXCD <> "0035" Then 'trung.luu: 14/10/2020 giao dich 6679,0035 khong replace dau .
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                End If
                                                v_strValue = Replace(v_strValue, "[", "?01?")
                                                v_strValue = Replace(v_strValue, "]", "?02?")
                                                v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                            Else
                                                v_strFLDDEFVAL = String.Empty
                                            End If

                                        End If
                                    End If
                                Next

                                'Nạp và thực hiện giao dịch
                                'gvResult.GetDataRow(v_intRow)("__TICK").Value = String.Empty
                                'Clear row dau tien
                                'gvSearchSelection.SelectRow(v_intRow, False)

                                SetTransactForm()
                                If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                    mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                    mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                    mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                    mv_frmTransactScreen.BranchId = Me.BranchId
                                    mv_frmTransactScreen.TellerId = Me.TellerId
                                    mv_frmTransactScreen.IpAddress = Me.IpAddress
                                    mv_frmTransactScreen.WsName = Me.WsName
                                    mv_frmTransactScreen.BusDate = Me.BusDate
                                    ' mv_frmTransactScreen.TellerName = Me.TellerName

                                    If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                        mv_frmTransactScreen.PostingDate = v_strPostingDate
                                    End If

                                    mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                    mv_frmTransactScreen.AutoClosedWhenOK = True
                                    'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                    mv_frmTransactScreen.ShowDialog()
                                    If mv_frmTransactScreen.CancelClick Then
                                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                        gvSearchSelection.ClearSelection()
                                        Exit Function

                                    End If
                                    'mv_frmTransactScreen.OnSubmit()
                                    mv_frmTransactScreen.Dispose()
                                    'Reset lại giá trị
                                    v_strFLDDEFVAL = String.Empty
                                End If
                            End If
                        Next
                        gvSearchSelection.ClearSelection()
                        If v_intCountSelected = 0 Then
                            'MsgBox("Please choose record to ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_CHOOSE_RECORD_TO_EXECUTE"))
                        End If

                    End If
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Else
            'Sua lai ham nay cho phep thuc hien all giao dich ke ca khi gap loi doi voi cac giao dich Import
            Dim v_blnIsImport As Boolean = False
            If InStr("V_SE2240|V_SE2245|V_CI1141|V_CI1101|V_CI1187|V_SE2287|V_SE2203", mv_strTableName) > 0 Then
                v_blnIsImport = True
            Else
                v_blnIsImport = False
            End If
            If Not v_nodeList.Count = 0 Then
                'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                If Not SearchGrid Is Nothing Then
                    If gvResult.RowCount > 0 Then
                        For v_intRow = 0 To gvSearchSelection.SelectedCount - 1
                            If Not gvSearchSelection.GetSelectedRow(v_intRow) Is Nothing Then
                                'Có được đánh dấu chọn
                                For i = 0 To v_nodeList.Count - 1
                                    v_strFLDCODE = String.Empty
                                    v_strFLDCD = String.Empty
                                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strValue = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "MODCODE"
                                                    v_strMODCODE = Trim(v_strValue)
                                                Case "TLTXCD"
                                                    v_strTLTXCD = Trim(v_strValue)
                                                Case "FIELDCODE"
                                                    v_strFLDCODE = Trim(v_strValue)
                                                Case "FLDCD"
                                                    v_strFLDCD = Trim(v_strValue)
                                                Case "FIELDTYPE"
                                                    v_strFIELDTYPE = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next

                                    If v_strFLDCD <> "" Then
                                        If String.Compare(v_strFLDCD, "PD") = 0 Then
                                            'Neu la truong posting date
                                            If gvResult.RowCount > 0 Then
                                                v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(v_strFLDCODE))
                                                v_strValue = Replace(v_strValue, ".", "")
                                                v_strPostingDate = v_strValue
                                            Else
                                                v_strPostingDate = v_strValue
                                            End If

                                        Else
                                            'Neu la truong binh thuong 
                                            If gvResult.RowCount > 0 Then
                                                v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(v_strFLDCODE))
                                                If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                End If
                                                v_strValue = Replace(v_strValue, "[", "?01?")
                                                v_strValue = Replace(v_strValue, "]", "?02?")
                                                v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                            Else
                                                v_strFLDDEFVAL = String.Empty
                                            End If

                                        End If
                                    End If
                                Next

                                'Nạp và thực hiện giao dịch
                                'gvResult.GetDataRow(v_intRow)("__TICK").Value = String.Empty
                                'gvSearchSelection.SelectRow(v_intRow, False)
                                SetTransactForm()
                                If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                    'TungNT modified, goi form transact kieu silent
                                    If mv_strTableName.ToUpper().EndsWith("DB") Then

                                    Else
                                        'Thuc hien goi form binh thuong
                                        mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate
                                        'mv_frmTransactScreen.TellerName = Me.mv_strTellerName

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        'Thuc hien import giao dich
                                        If v_blnIsImport Then
                                            mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                            mv_frmTransactScreen.AutoClosedWhenOK = True
                                            mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                            mv_frmTransactScreen.ShowDialog()
                                            'If mv_frmTransactScreen.CancelClick Then
                                            '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            '    Exit Function
                                            'End If
                                            'mv_frmTransactScreen.OnSubmit()
                                            mv_frmTransactScreen.Dispose()
                                            'Reset lại giá trị
                                            v_strFLDDEFVAL = String.Empty
                                        Else
                                            mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                            mv_frmTransactScreen.AutoClosedWhenOK = True
                                            mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                            mv_frmTransactScreen.ShowDialog()
                                            If mv_frmTransactScreen.CancelClick Then
                                                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                                gvSearchSelection.ClearSelection()
                                                Exit Function
                                            End If
                                            'mv_frmTransactScreen.OnSubmit()
                                            mv_frmTransactScreen.Dispose()
                                            'Reset lại giá trị
                                            v_strFLDDEFVAL = String.Empty
                                        End If

                                    End If
                                    'End TungNT
                                End If
                            End If
                        Next
                        gvSearchSelection.ClearSelection()
                    End If
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If
        gvSearchSelection.ClearSelection()
    End Function

    Protected Overridable Function OnExecuteGeneric() As Int32
        Dim v_strSQL, v_strClause, v_strObjMsg, objKey As String, v_lngError As Long = ERR_SYSTEM_OK
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strTXNAME, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String
        Dim i, j, v_intRow, v_intCol As Integer
        Dim v_strPostingDate As String, v_hashTLTX As Hashtable, v_blnIsThatTLTXCD As Boolean, itemField As String, arrTXFLD() As String
        Try
            If Me.mv_strTLTXCD.Length > 0 Then
                'Khi execute goi den giao dich thi thuc hien o day
                If Not mv_strTLTXCD.IndexOf("/") > 0 Then
                    OnExecute()   'The grid only map to once TLTXCD
                Else
                    'Prevent multiple with check All
                    If Not Me.bciExecuteAll.Checked Then
                        'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
                        If Not SearchGrid Is Nothing Then
                            If gvResult.RowCount > 0 Then
                                For v_intRow = 0 To gvSearchSelection.SelectedCount - 1
                                    'Sau khi l
                                    If Not gvSearchSelection.GetSelectedRow(v_intRow) Is Nothing Then
                                        'Truoc khi khoi tao form giao dich da clear selection nen luc nao cung lay phan tu so 0
                                        'Determine appropriate TLTXCD
                                        'Determine the corresponse TLTXCD base on the selected value on the screen. 
                                        v_hashTLTX = New Hashtable()
                                        For Each objKey In mv_arrStrTLTXNAME.Keys
                                            v_strTXNAME = mv_arrStrTLTXNAME.Item(objKey)
                                            v_blnIsThatTLTXCD = True
                                            'Kiem tra cac gia tri cua cot trong row duoc chon co phu hop voi giao dich khong
                                            For v_intCol = 0 To gvResult.Columns.Count - 1
                                                v_strFLDCODE = gvResult.Columns(v_intCol).FieldName
                                                If v_strFLDCODE <> "CheckMarkSelection" Then
                                                    v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(v_strFLDCODE)).Trim
                                                    If mv_arrStrTLTXMAPFLDREF.ContainsKey(objKey & "." & v_strFLDCODE) Then
                                                        itemField = mv_arrStrTLTXMAPFLDREF.Item(objKey & "." & v_strFLDCODE).trim
                                                        If itemField.Length > 0 Then
                                                            If Not itemField.IndexOf(v_strValue) >= 0 Then
                                                                v_blnIsThatTLTXCD = False
                                                                Exit For
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                            If v_blnIsThatTLTXCD Then
                                                v_hashTLTX.Add(objKey, v_strTXNAME)
                                            End If
                                        Next objKey

                                        'Execute transaction
                                        If v_hashTLTX.Count > 0 Then
                                            If v_hashTLTX.Count = 1 Then
                                                'Direct
                                                v_strTLTXCD = v_hashTLTX.Keys(0)
                                                v_strMODCODE = mv_arrStrTLTXNAMEREF(v_strTLTXCD)
                                                'Get default value for screen
                                                v_strFLDDEFVAL = String.Empty
                                                If gvResult.SelectedRowsCount > 0 Then
                                                    For Each objKey In mv_arrStrTLTXMAPFLD.Keys
                                                        arrTXFLD = objKey.ToString.Split(".")
                                                        If arrTXFLD(0) = v_strTLTXCD Then
                                                            v_strFLDCD = mv_arrStrTLTXMAPFLD.Item(objKey)
                                                            v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(arrTXFLD(1)))
                                                            If (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                                v_strValue = Replace(v_strValue, ".", "")
                                                            End If
                                                            v_strValue = Replace(v_strValue, "[", "?01?")
                                                            v_strValue = Replace(v_strValue, "]", "?02?")
                                                            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                        End If
                                                    Next
                                                End If
                                                SetTransactForm()
                                                If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                                    'Thuc hien goi form binh thuong
                                                    mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                                    mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                                    mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                                    mv_frmTransactScreen.BranchId = Me.BranchId
                                                    mv_frmTransactScreen.TellerId = Me.TellerId
                                                    mv_frmTransactScreen.IpAddress = Me.IpAddress
                                                    mv_frmTransactScreen.WsName = Me.WsName
                                                    mv_frmTransactScreen.BusDate = Me.BusDate
                                                    '  mv_frmTransactScreen.TellerName = Me.mv_strTellerName

                                                    If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                                        mv_frmTransactScreen.PostingDate = v_strPostingDate
                                                    End If

                                                    'Thuc hien import giao dich
                                                    mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                                    mv_frmTransactScreen.AutoClosedWhenOK = True
                                                    mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                                    mv_frmTransactScreen.ShowDialog()
                                                    If mv_frmTransactScreen.CancelClick Then
                                                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                                        gvSearchSelection.ClearSelection()
                                                        Exit Function
                                                    End If
                                                    'mv_frmTransactScreen.OnSubmit()
                                                    mv_frmTransactScreen.Dispose()
                                                    'Reset lại giá trị
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            Else
                                                'if have more than once TLTXCD => end user choose which TLTXCD: Show Popup Menu
                                                For Each objKey In v_hashTLTX.Keys
                                                    v_strTXNAME = v_hashTLTX.Item(objKey)
                                                    v_strMODCODE = mv_arrStrTLTXNAMEREF(objKey)
                                                Next
                                            End If
                                        End If
                                    End If

                                Next
                            End If
                        End If
                    End If
                End If
                'Refresh lại màn hình
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                gvSearchSelection.ClearSelection()
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnQuery() As Int32
        Try
            Dim v_strView As String
            If Len(Trim(AuthString)) > 0 Then
                v_strView = Mid(Trim(AuthString), 1, 1)
                If v_strView = "Y" Then
                    ShowForm(ExecuteFlag.View)
                Else
                    Return ERR_SYSTEM_OK
                End If
            End If
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnUpdate() As Int32
        If ShowForm(ExecuteFlag.Edit) = DialogResult.OK Then
            If SearchOnInit = True Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        End If
    End Function

    Protected Overridable Function OnApprove() As Int32
        Try
            ShowForm(ExecuteFlag.Approve)
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnDispose() As Int32
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Dim v_strDescription As String = ""
        Dim v_strObjMsg, v_strIDList, v_strSQL, v_strData, v_strFLDCDData, _
        v_strFLDCD, v_strFIELDTYPE, v_strFLDCODE, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        Try
            v_strIDList = ""
            For i As Integer = 0 To gvResult.RowCount - 1
                If gvResult.GetDataRow(i)("__TICK").Value = "X" Then
                    If TableName = "CRBTRFLOG" Then
                        v_strIDList &= gvResult.GetDataRow(i)("AUTOID").Value & ","
                    Else
                        v_strIDList &= gvResult.GetDataRow(i)("REQID").Value & ","
                    End If
                End If
            Next
            If v_strIDList.EndsWith(",") Then
                v_strIDList = v_strIDList.Substring(0, v_strIDList.Length - 1)
            End If
            If v_strIDList.Length = 0 Then
                If Not gvResult.GetFocusedDataRow() Is Nothing Then
                    If TableName = "CRBTRFLOG" Then
                        v_strIDList = gvResult.GetFocusedDataRow()("AUTOID").Value
                    Else
                        v_strIDList = gvResult.GetFocusedDataRow()("REQID").Value
                    End If
                End If
            End If

            If v_strIDList.Length > 0 Then
                If TableName Like "??BK??" Then
                    If MsgBox(mv_ResourceManager.GetString("frmSearch.DisposeConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                        v_strDescription = InputBox(mv_ResourceManager.GetString("frmSearch.DisposeDescInput"), "Description")

                        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_CRBTRFLOG, gc_ActionAdhoc, , v_strIDList, "DeleteTxReq", , , v_strDescription)

                        v_lngErrorCode = v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        Else
                            MsgBox(mv_ResourceManager.GetString("frmSearch.DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        End If
                    End If
                End If
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, ex.Message)
        End Try
    End Function

    'Protected Overridable Function OnDelete(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
    '    Dim v_strKeyFieldName, v_strKeyFieldValue As String
    '    Dim v_strClause As String

    '    Try

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Function
    Protected Overridable Function OnDelete(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause, v_strData As String

        Try
            If MsgBox(mv_ResourceManager.GetString("frmSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (gvResult.GetFocusedDataRow() Is Nothing) Then
                        'If Not (gvResult.GetFocusedDataRow() Is SearchGrid.FixedFooterRows.Item(0)) Then
                        v_strKeyFieldName = KeyColumn
                        KeyFieldType = "C"
                        v_strKeyFieldValue = gvResult.GetFocusedRow()(KeyColumn)
                        v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")
                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select
                        Dim v_strObjMsg As String
                        Dim v_lngErrorCode As Long
                        Dim v_strErrorSource, v_strErrorMessage As String
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_nodeList As Xml.XmlNodeList, i As Integer
                        Dim v_ds As DataSet
                        Dim v_xmlDoc As New XmlDocument()
                        ''If pv_strModule = "SA.BANKNOSTRO" Then
                        'Dim v_strSQL_check As String = "SELECT PAYTYPE FROM BANKNOSTRO WHERE SHORTNAME ='" & v_strKeyFieldValue & "' "
                        'v_strObjMsg = BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionInquiry, v_strSQL_check, , "GetHostData", , , )
                        'v_lngErrorCode = v_ws.Message(v_strObjMsg)

                        'If v_lngErrorCode <> ERR_SYSTEM_OK Then
                        '    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                        '    Cursor.Current = Cursors.Default
                        '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        '    Exit Function
                        'Else

                        '    v_xmlDoc.LoadXml(v_strObjMsg)
                        '    Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDoc.DocumentElement.Attributes
                        '    v_nodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
                        '    'v_strData = UnzipString((CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value).Replace("<![CDATA[", "").Replace("]]>", "")))
                        '    'v_nodeList = v_attrColl.SelectNodes("/ObjectMessage/ObjData")
                        '    Dim j As Integer
                        '    Dim v_strPAYTYPE, v_strValue, v_strFLDNAME As String
                        '    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        '        With v_nodeList.Item(i).ChildNodes(j)
                        '            v_strValue = .InnerText.ToString
                        '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        '            Select Case Trim(v_strFLDNAME)
                        '                Case "PAYTYPE"
                        '                    v_strPAYTYPE = Trim(v_strValue)
                        '            End Select
                        '        End With
                        '    Next
                        '    If Len(v_strPAYTYPE) > 0 Then
                        '        If MsgBox("Loại thanh toán đang được đùng để chuyển tiền mua sang ngân hàng." + vbCrLf + "Tiếp tục xóa", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                        '            Exit Function
                        '        End If
                        '    End If
                        'End If

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause)

                        v_ws.Message(v_strObjMsg)

                        'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        'Remove dòng dữ liệu đã xoá kh?i grid
                        gvResult.GetFocusedDataRow.Delete()
                        'Else
                        '    'Update mouse pointer
                        '    Cursor.Current = Cursors.Default
                        '    MsgBox(mv_ResourceManager.GetString("frmSearch.Footer"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        '    Exit Function
                        'End If
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If

                '?�ồng bộ lại thông tin
                'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                If SearchOnInit = True Then
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(mv_ResourceManager.GetString("frmSearch.DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnSMS() As Int32
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strSQL, v_strClause, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strErrorSource As String, v_strErrorMessage As String
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If mv_strTableName = "MR0002" Then
                If Not Me.bciExecuteAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ModuleCode & "." & ObjectName, gc_ActionAdhoc, , v_strClause, "SetMarginCallList", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    v_ws.Message(v_strObjMsg)
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            Else
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ModuleCode & "." & "SMSPROCESS", gc_ActionAdhoc, , v_strClause, "SMS_" & mv_strTableName, gc_AutoIdUsed)
                Dim count As Double
                GetDataFromGrid(v_strObjMsg, , count)
                If count <> 0 Then
                    v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.SMSSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnEmail() As Int32
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strSQL, v_strClause, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            If mv_strTableName = "DF1002" Then
                If Not Me.bciExecuteAll.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg)
                    Me.Enabled = False
                    SendEmailCall(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "", gc_ActionAdhoc, , v_strClause, "", gc_AutoIdUsed)
                    GetDataFromGrid(v_strObjMsg, True)
                    Me.Enabled = False
                    SendEmailCall(v_strObjMsg, mv_ResourceManager.GetString("EMAILLOGMESSAGE"))
                    Me.Enabled = True
                    'Refresh lại màn hình
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Throw ex
        End Try
    End Function

#End Region

#Region " Other methods "
    Public Sub PrepareArrayOfALLCODE(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, _
                                     ByRef pv_arrALLCODE As Hashtable, ByRef pv_arrALLCODEREF As Hashtable)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCDVAL, v_strCDVALREF, v_strDISPLAY, v_strENDISPLAY As String
        Dim v_intFieldCount As Integer
        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            pv_arrALLCODE = New Hashtable()
            pv_arrALLCODEREF = New Hashtable()
            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCDVAL = Trim(v_strValue)
                            Case "VALUECD"
                                v_strCDVALREF = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strDISPLAY = Trim(v_strValue)
                            Case "EN_DISPLAY"
                                v_strENDISPLAY = Trim(v_strValue)
                        End Select
                    End With
                Next
                If Not pv_arrALLCODE.ContainsKey(v_strCDVAL) Then
                    If pv_strUserLanguage = "EN" Then
                        pv_arrALLCODE.Add(v_strCDVAL, v_strENDISPLAY)
                    Else
                        pv_arrALLCODE.Add(v_strCDVAL, v_strDISPLAY)
                    End If
                    pv_arrALLCODEREF.Add(v_strCDVAL, v_strCDVALREF)
                End If
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Sub PrepareSearchParamsAdv(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_arrSrQuickSearch() As String, ByRef pv_arrSrSummaryCode() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "",
                                   Optional ByRef pv_ISFLTCODEID As String = "N", Optional ByRef pv_ISFLTMBCODE As String = "N",
                                   Optional ByRef pv_QUICKSRCH As String = "N", Optional ByRef pv_SUMMARYCD As String = "", Optional ByRef pv_intInterval As Integer = 0)

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName, v_strSrQuickSearch, v_strSrSummaryCode As String
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
            ReDim pv_arrSrQuickSearch(v_intFieldCount)
            ReDim pv_arrSrSummaryCode(v_intFieldCount)

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
                            Case "ISFLTCODEID"
                                pv_ISFLTCODEID = Trim(v_strValue)
                            Case "ISFLTMBCODE"
                                pv_ISFLTMBCODE = Trim(v_strValue)
                            Case "QUICKSRCH"
                                v_strSrQuickSearch = Trim(v_strValue)
                            Case "SUMMARYCD"
                                v_strSrSummaryCode = Trim(v_strValue)
                            Case "INTERVAL"
                                If IsNumeric(v_strValue) Then
                                    pv_intInterval = CInt(v_strValue)
                                Else
                                    pv_intInterval = 0
                                End If
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
                    pv_arrSrQuickSearch(pv_intSearchNum) = v_strSrQuickSearch
                    pv_arrSrSummaryCode(pv_intSearchNum) = v_strSrSummaryCode
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
                ReDim Preserve pv_arrSrQuickSearch(pv_intSearchNum)
                ReDim Preserve pv_arrSrSummaryCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub


    Protected Overridable Sub SetTransactForm()

    End Sub

    'Hàm này dùng de gui email canh bao Trigger
    Protected Overridable Sub SendEmailCall(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTrigger(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTodue(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailOVD(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendNotification(ByVal v_strSENDVIA As String)
    End Sub

    Protected Overridable Sub InitDialog()
        'Khởi tạo kích thước form và load resource
        If DesignMode Then
            Return
        End If
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'If chkauto.Checked = False Then
        '    Timesearch = 0
        'End If

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()
        ' 
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'Set double click event on Xceed Grid 
        AddHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick
        AddHandler SearchGrid.Click, AddressOf Grid_Click

        'Set click event for Xceed smart toolbar button
        AddHandler bbiNew.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiView.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiEdit.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiDelete.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiExit.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiExecute.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiSMS.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiEmail.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiFullScreen.ItemClick, AddressOf BarButtonItem_Click
        'AnhVT Added - Maintenance Approval Retro
        AddHandler bbiApprove.ItemClick, AddressOf BarButtonItem_Click

        'Set click event for buttons
        AddHandler bbiSearch.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiExport.ItemClick, AddressOf BarButtonItem_Click
        AddHandler bbiCompare.ItemClick, AddressOf BarButtonItem_Click

        'Set KeyDown event for Value textbox
        'Set selected index changed event for ComboBoxes

        'If Not EnableSearchFilter Then
        '    grbSearchResult.Left = grbSearchFilter.Left
        '    grbSearchResult.Top = grbSearchFilter.Top
        '    grbSearchFilter.Visible = EnableSearchFilter
        'End If

        'Thiết lập các giá trị ban đầu cho các đi?u kiện tìm kiếm
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )

        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        PrepareSearchParamsAdv(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
            mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
            mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_arrStQuickSearch, mv_arrStSummaryCode,
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
            mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
            mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT, mv_ISFLTCODEID, mv_ISFLTMBCODE, , , mv_intInterval)
        'mv_arrStQuickSearch, mv_arrStSummaryCode
        'init Searchfld
        '' SearchGrid.DataSource = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
        SearchGrid.DataSource = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)


        'Formatgid
        XtraGridFormatSummary(Me.gvResult, "", mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrStSummaryCode)
        'create filter control
        CreateFilterColumn(fcCriterial.CriterialProperty, mv_arrStFieldMandartory, mv_arrSrFieldSrch, mv_arrSrFieldType, mv_arrSrFieldDisp, mv_arrSrSQLRef, UserLanguage)
        'apply summary for field
        If mv_AutoFilter = True Then 'trung.luu: 14-01-2021 auto fileter khi mo menu tu nut notify
            gvResult.ActiveFilterCriteria = GroupOperator.Or(mv_CriteriaOperator_Notify)
        End If
        If mv_strSearchAuthCode.Length > 0 Then
            AuthCode = mv_strSearchAuthCode
        End If
        'Set enable status for toolbar buttons and other buttons depend on AuthCode string
        bbiNew.Enabled = (Mid(AuthCode, 1, 1) = "Y")
        bbiView.Visibility = IIf(Mid(AuthCode, 2, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)
        bbiEdit.Visibility = IIf(Mid(AuthCode, 3, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)
        bbiDelete.Visibility = IIf(Mid(AuthCode, 4, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)
        rpgMulti.Visible = Not (Mid(AuthCode, 2, 3) = "NNN")
        bbiSearch.Enabled = (Mid(AuthCode, 5, 1) = "Y")
        bbiExport.Enabled = (Mid(AuthCode, 6, 1) = "Y")
        bbiExecute.Visibility = IIf(Mid(AuthCode, 7, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)
        bbiSMS.Visibility = IIf(Mid(AuthCode, 8, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)
        bbiEmail.Visibility = IIf(Mid(AuthCode, 9, 1) = "Y", BarItemVisibility.Always, BarItemVisibility.Never)

        If mv_strSearchAuthCode.Length > 0 Then
            rpgCompare.Visible = (Mid(AuthCode, 10, 1) = "Y")
            'Set check all
            bciCheckAll.Checked = (Mid(AuthCode, 10, 1) = "Y")
        Else
            rpgCompare.Visible = False
            bciCheckAll.Checked = False
        End If

        'AnhVT Added - Maintenance Approval Retro
        bbiApprove.Enabled = (Mid(AuthCode, 11, 1) = "Y")

        'Set enable status for toolbar buttons depend on AuthString string
        If TellerId <> "0001" Then
            bbiView.Enabled = (Mid(AuthString, 1, 1) = "Y")
            bbiNew.Enabled = (Mid(AuthString, 2, 1) = "Y")
            bbiEdit.Enabled = (Mid(AuthString, 3, 1) = "Y")
            bbiDelete.Enabled = (Mid(AuthString, 4, 1) = "Y")
            'AnhVT Added - Maintenance Approval Retro
            bbiApprove.Enabled = (Mid(AuthString, 5, 1) = "Y")
        End If


        'Update form caption
        If UserLanguage <> "EN" Then
            FormCaption = mv_strCaption
        Else
            FormCaption = mv_strEnCaption
        End If
        Me.Text = FormCaption

        'Load the last filter
        If LoadLastFilter Then
            LoadLastSearch()
        End If

        'VanNT
        If mv_rowpage = 0 Then
            'Nếu không thiết lập sẽ lấy theo chung của mức hệ thống
            mv_rowpage = GetRowPage()
        End If
        If Not mv_strTLTXCD Is Nothing Then
            If mv_strTLTXCD = "SMS" Then
                Me.bbiExecute.Visibility = BarItemVisibility.Never
            Else
                If mv_strTLTXCD.Trim.Length = 0 Then
                    Me.bbiExecute.Visibility = BarItemVisibility.Never
                Else
                    If mv_strTLTXCD.IndexOf("/") > 0 Then
                        'Get the list of TLTXCD - 
                        mv_arrStrTLTXCD = mv_strTLTXCD.Split("/")
                        If Me.UserLanguage = "EN" Then
                            v_strCmdInquiry = "select a.tltxcd VALUE, b.modcode VALUECD, a.en_txdesc DISPLAY, a.en_txdesc EN_DISPLAY, tltxcd from tltx a, appmodules b where instr('" _
                                    & mv_strTLTXCD & "', a.TLTXCD)>0 and substr(a.tltxcd,1,2)=b.txcode"
                        Else
                            v_strCmdInquiry = "select a.tltxcd VALUE, b.modcode VALUECD, a.txdesc DISPLAY, a.en_txdesc EN_DISPLAY, tltxcd from tltx a, appmodules b where instr('" _
                                    & mv_strTLTXCD & "', a.TLTXCD)>0 and substr(a.tltxcd,1,2)=b.txcode"
                        End If
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry)
                        v_ws.Message(v_strObjMsg)
                        'Get the list of TLTX description
                        PrepareArrayOfALLCODE(Me.UserLanguage, v_strObjMsg, mv_arrStrTLTXNAME, mv_arrStrTLTXNAMEREF)

                        'Get the mapping field
                        v_strCmdInquiry = "SELECT tltxcd || '.' || fieldcode value, fldcd DISPLAY, FILTERVAL VALUECD, fldcd EN_DISPLAY FROM SEARCHTXMAPFLD WHERE searchcode='" & mv_strTableName & "' and instr('" _
                                    & mv_strTLTXCD & "', TLTXCD)>0"
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry)
                        v_ws.Message(v_strObjMsg)
                        PrepareArrayOfALLCODE(Me.UserLanguage, v_strObjMsg, mv_arrStrTLTXMAPFLD, mv_arrStrTLTXMAPFLDREF)

                        'Create the Popup Menu IF NEEDED: gridView_PopupMenuClick
                        AddHandler Me.gvResult.PopupMenuShowing, AddressOf gridView_PopupMenuClick
                    Else
                        If Me.UserLanguage = "EN" Then
                            v_strCmdInquiry = "select tltxcd VALUECD, tltxcd VALUE, en_txdesc DISPLAY, en_txdesc EN_DISPLAY, tltxcd from tltx, appmodules where TLTXCD='" _
                                    & mv_strTLTXCD & "'"
                        Else
                            v_strCmdInquiry = "select tltxcd VALUECD, tltxcd VALUE, txdesc DISPLAY, en_txdesc EN_DISPLAY, tltxcd from tltx where TLTXCD='" _
                                    & mv_strTLTXCD & "'"
                        End If
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry)
                        v_ws.Message(v_strObjMsg)
                        'Get the list of TLTX description
                        PrepareArrayOfALLCODE(Me.UserLanguage, v_strObjMsg, mv_arrStrTLTXNAME, mv_arrStrTLTXNAMEREF)

                        'Get the mapping field
                        v_strCmdInquiry = "SELECT '' VALUECD, '" & mv_strTLTXCD & "' || '.' || fieldcode value, fldcd DISPLAY, fldcd EN_DISPLAY FROM SEARCHFLD WHERE searchcode='" & mv_strTableName & "'"
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry)
                        v_ws.Message(v_strObjMsg)
                        PrepareArrayOfALLCODE(Me.UserLanguage, v_strObjMsg, mv_arrStrTLTXMAPFLD, mv_arrStrTLTXMAPFLDREF)
                    End If
                End If
            End If
        End If

        If Not ObjectName Is Nothing Then
            If Me.ObjectName.Trim.Length = 0 Then Me.bbiView.Visibility = False
        End If

        If Not gvResult.Columns.Contains(gvResult.Columns("CheckMarkSelection")) And Me.bbiExecute.Visibility = BarItemVisibility.Always Then
            gvSearchSelection = New GridCheckMarksSelection(gvResult)
            gvSearchSelection.CheckMarkColumn.VisibleIndex = 0
            gvSearchSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
        End If

        'If Me.bbiExecute.Enabled Then
        '    If gvResult.Columns("__TICK") Is Nothing Then
        '        gvResult.Columns.AddField("__TICK")
        '        gvResult.Columns("__TICK").Visible = True
        '    End If
        'End If
        'Xu ly cho QuickSearch:  mv_arrStQuickSearch

        Dim v_intNumberOfQuicSearch As Integer = 0
        mv_isQuickSearch = False
        For i As Integer = 0 To mv_arrStQuickSearch.Count() - 1
            If Not String.IsNullOrEmpty(mv_arrStQuickSearch(i)) Then
                If (mv_arrStQuickSearch(i).Equals("Y")) And mv_arrSrSQLRef(i).Trim().Length > 0 Then
                    mv_isQuickSearch = True
                    v_intNumberOfQuicSearch = v_intNumberOfQuicSearch + 1
                    If v_intNumberOfQuicSearch >= 6 Then Exit For 'Toi da chi co 06 truong
                    lblQueryDate.Visible = False
                    Select Case v_intNumberOfQuicSearch
                        Case 1
                            lblCondition1.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition1.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition1.Visible = True
                            lueCondition1.Tag = mv_arrSrFieldSrch(i)        'SQL reference
                            lueCondition1.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition1, "", UserLanguage)
                        Case 2
                            lblCondition2.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition2.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition2.Visible = True
                            lueCondition2.Tag = mv_arrSrFieldSrch(i)         'SQL reference
                            lueCondition2.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition2, "", UserLanguage)
                        Case 3
                            lblCondition3.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition3.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition3.Visible = True
                            lueCondition3.Tag = mv_arrSrFieldSrch(i)         'SQL reference
                            lueCondition3.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition3, "", UserLanguage)
                        Case 4
                            lblCondition4.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition4.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition4.Visible = True
                            lueCondition4.Tag = mv_arrSrFieldSrch(i)        'SQL reference
                            lueCondition4.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition4, "", UserLanguage)
                        Case 5
                            lblCondition5.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition5.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition5.Visible = True
                            lueCondition5.Tag = mv_arrSrFieldSrch(i)         'SQL reference
                            lueCondition5.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition5, "", UserLanguage)
                        Case 6
                            lblCondition6.Text = mv_arrSrFieldDisp(i)   'Caption
                            lblCondition6.Tag = mv_arrSrSQLRef(i)    'Field name
                            lblCondition6.Visible = True
                            lueCondition6.Tag = mv_arrSrFieldSrch(i)        'SQL reference
                            lueCondition6.Visible = True
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, mv_arrSrSQLRef(i))
                            v_ws.Message(v_strObjMsg)
                            FillXtraLookUpEdit(v_strObjMsg, lueCondition6, "", UserLanguage)

                        Case Else
                    End Select
                Else
                    If (mv_arrStQuickSearch(i).Equals("Y")) And mv_arrSrFieldType(i) = "D" Then
                        'The date field
                        Me.lblQueryDate.Text = mv_arrSrFieldDisp(i)
                        Me.lblQueryDate.Tag = mv_arrSrFieldSrch(i)
                        Me.lblQueryDate.Visible = True
                        Me.dtFrom.Visible = True
                        Me.dtTo.Visible = True
                        mv_isQuickSearch = True
                    End If
                End If
            End If
        Next

        sccSearch.Collapsed = False
        Me.grpQuickSearch.Visible = mv_isQuickSearch
        'Ban dau An khung dieu kien tim kiem
        sccSearch.Collapsed = Not sccSearch.Collapsed

        'Cho phép chọn một dòng dữ liệu trên màn hình tìm kiếm để ra báo cáo
        'Gọi hàm truyền vào SearchCode & Key fields để ra báo cáo cần in
        'Nếu dùng báo cáo ADHOC thì tệp tin mẫu báo cáo chính là SearchCode

        Me.bbiNext.Enabled = False
        If SearchOnInit Then
            mv_intpage = 1
            If ObjectName.IndexOf(".") = -1 Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            Else
                OnSearch(IsLocalSearch, ObjectName, mv_intpage)
            End If
        End If
        Me.bbiPrev.Enabled = False

    End Sub
    'trung.luu: 07-12-2020 them Button.Kind.Delete cho quicksearch
    Private Sub ControlLookup_EditValueChanged(sender As Object, e As EventArgs) Handles lueCondition1.EditValueChanged, lueCondition2.EditValueChanged, lueCondition3.EditValueChanged, lueCondition4.EditValueChanged, lueCondition5.EditValueChanged, lueCondition6.EditValueChanged
        Try
            Dim controlEditor As LookUpEditEx = CType(sender, LookUpEditEx)
            If controlEditor IsNot Nothing Then
                If (controlEditor.EditValue IsNot Nothing) Then
                    controlEditor.Properties.Buttons(1).Visible = True
                Else
                    controlEditor.Properties.Buttons(1).Visible = False
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ControlLookup_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lueCondition1.ButtonClick, lueCondition6.ButtonClick, lueCondition5.ButtonClick, lueCondition4.ButtonClick, lueCondition3.ButtonClick, lueCondition2.ButtonClick
        Try
            Dim controlEditor As LookUpEditEx = CType(sender, LookUpEditEx)
            If controlEditor IsNot Nothing Then
                If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) Then
                    controlEditor.EditValue = Nothing
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'trung.luu: 07-12-2020  them Button.Kind.Delete cho quicksearch

    Private Sub BarButtonItem_Click(sender As Object, e As ItemClickEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        CType(e.Item, BarButtonItem).Enabled = False
        If (e.Item Is bbiNew) Then
            OnAddNew()
        ElseIf (e.Item Is bbiExecute) And (CMDTYPE = "V" Or CMDTYPE Is Nothing) Then
            OnExecute()
        ElseIf (e.Item Is bbiExecute) And CMDTYPE = "D" Then
            OnExecutedel()
        ElseIf (e.Item Is bbiView) Then
            OnQuery()
        ElseIf (e.Item Is bbiEdit) Then
            OnUpdate()
        ElseIf (e.Item Is bbiDelete) Then
            OnDelete(IsLocalSearch, ModuleCode & "." & ObjectName)
        ElseIf (e.Item Is bbiSMS) Then
            SendNotification(gc_SEND_VIA_SMS)
        ElseIf (e.Item Is bbiEmail) Then
            SendNotification(gc_SEND_VIA_EMAIL)
        ElseIf (e.Item Is bbiApprove) Then
            OnApprove()
        ElseIf (e.Item Is bbiExit) Then
            CloseTab()

        ElseIf (e.Item Is bbiSearch) Then
            mv_intpage = 1
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        ElseIf (e.Item Is bbiExport) Then
            OnExport()
        ElseIf (e.Item Is bbiFullScreen) Then
            OnExpand()
        ElseIf (e.Item Is bbiCompare) Then
            OnCompare()
        End If
        CType(e.Item, BarButtonItem).Enabled = True
    End Sub

    Protected Overridable Sub DoResizeForm()

    End Sub

    ''' <summary>
    ''' Save citerial
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveLastSearch()

        Try
            'TODO: Save last criterial
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SaveLastSearchObj(ByVal strObj As String)

        Try
            v_strObjMsg_search = strObj

        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub AutoSearch(ByVal state As Object)

        Dim i As Integer
        Dim v_strFLDNAME, v_KeyValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, v_strMessage As String
        Dim v_intFrom, v_intTo As Int32
        Try
            If v_strObjMsg_search = "" Then
                Exit Sub
            Else
                Dim v_strObjMsg As String = v_strObjMsg_search
                v_ws.Message(v_strObjMsg)
                If Me.bciCheckAll.Checked = True Then
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Me.FULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    UpdateDataset(ConvertXmlDocToDataSet(v_xmlDocument).Tables(0))
                Else
                    UpdateDataset(ObjDataToDataset(v_strObjMsg, , mv_strTableName))
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Public Sub UpdateDataset(ByVal ds As DataTable)


        Try
            SearchGrid.Invoke(Sub(d As DataTable)
                                  Dim key() As DataColumn = {mv_SearchDataTABLE.Columns("RN")}
                                  mv_SearchDataTABLE.PrimaryKey = key
                                  mv_SearchDataTABLE.Merge(d)
                              End Sub, ds)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub LoadLastSearch()

        Try
            'TODO: Load last criterial
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Protected Overridable Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmSearch." & v_ctrl.Name)
            End If
        Next

        bbiNew.Caption = mv_ResourceManager.GetString("frmSearch.tbnAdd")
        bbiView.Caption = mv_ResourceManager.GetString("frmSearch.tbnView")
        bbiEdit.Caption = mv_ResourceManager.GetString("frmSearch.tbnEdit")
        bbiDelete.Caption = mv_ResourceManager.GetString("frmSearch.tbnDelete")
        bbiExecute.Caption = mv_ResourceManager.GetString("frmSearch.tbnExecute")
        bbiExit.Caption = mv_ResourceManager.GetString("frmSearch.tbnExit")
        bbiEmail.Caption = mv_ResourceManager.GetString("frmSearch.btnEmail")
        bbiSMS.Caption = mv_ResourceManager.GetString("frmSearch.btnSendSMS")
        bbiPrev.Caption = mv_ResourceManager.GetString("frmSearch.btnBACK")
        bbiNext.Caption = mv_ResourceManager.GetString("frmSearch.btnNEXT")
        bbiApprove.Caption = mv_ResourceManager.GetString("frmSearch.tbnApprove")

        bbiPreview.Caption = mv_ResourceManager.GetString("frmSearch.bbiPreview")
        bbiExport.Caption = mv_ResourceManager.GetString("frmSearch.bbiExport")
        bbiSearch.Caption = mv_ResourceManager.GetString("frmSearch.bbiSearch")
        bbiFullScreen.Caption = mv_ResourceManager.GetString("frmSearch.bbiFullScreen")
        bbiCompare.Caption = mv_ResourceManager.GetString("frmSearch.bbiCompare")

        GroupControl1.Text = mv_ResourceManager.GetString("frmSearch.SearchResults")
        gcCriterial.Text = mv_ResourceManager.GetString("frmSearch.Criterial")
        bciCheckAll.Caption = mv_ResourceManager.GetString("frmSearch.bciCheckAll")
        bciExecuteAll.Caption = mv_ResourceManager.GetString("frmSearch.bciExecuteAll")

    End Sub

    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As Xml.XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountCol As Integer

            Dim v_nodeXSD, v_nodeXML As Xml.XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXML")
            v_strDataXSD = v_nodeXSD.InnerText
            v_strDataXML = v_nodeXML.InnerText
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
            v_ds.Tables(0).TableName = "ObjData"
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Các sự kiện của form "

    Private Sub frmSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OnClose()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then
            Return
        End If
        InitDialog()

        RefreshToolBar()
    End Sub

    Private Sub frmSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim CountR As Int32
        Try
            Select Case e.KeyCode
                Case Keys.F6
                    If Not (SearchGrid Is Nothing) Then
                        If SearchGrid.Enabled And SearchGrid.Visible Then
                            SearchGrid.Focus()
                            'TODO:
                        End If
                    End If
                Case Keys.F7    'Prev
                    mv_intpage = mv_intpage - 1
                    If mv_intpage <= 0 Then
                        mv_intpage = 1
                    End If
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                Case Keys.F8    'Next
                    If CommandType = gc_CommandProcedure Then
                        CountR = mv_intTotalRow
                    Else
                        CountR = CountRow()
                    End If
                    If CountR >= (mv_intpage + 1) * mv_rowpage Then
                        mv_intpage = mv_intpage + 1
                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                    End If
                Case Keys.F9
                    If mv_intDblGrid = 0 Then
                        mv_intDblGrid = 1
                        If Me.bbiView.Visibility = False Then
                            OnClose()
                        End If
                        OnQuery()
                        mv_intDblGrid = 0
                    End If
                Case Keys.Escape
                    OnClose()
                Case Keys.C
                    If Keys.Control Then
                        'TODO: copy data
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'TODO: marked row
        RefreshToolBar()
    End Sub

    Private Sub RefreshToolBar()
        If DesignMode Then
            Return
        End If
        Dim addAuth As Boolean = (Mid(AuthCode, 1, 1) = "Y")
        Dim editAuth As Boolean = (Mid(AuthCode, 3, 1) = "Y")
        Dim viewAuth As Boolean = (Mid(AuthCode, 2, 1) = "Y")
        Dim delAuth As Boolean = (Mid(AuthCode, 4, 1) = "Y")
        Dim apprAuth As Boolean = (Mid(AuthCode, 11, 1) = "Y")


        Dim editAuthString As Boolean = (Mid(AuthString, 3, 1) = "Y")
        Dim delAuthString As Boolean = (Mid(AuthString, 4, 1) = "Y")
        Dim apprAuthString As Boolean = (Mid(AuthString, 5, 1) = "Y")

        '2010/04/21 - TRUONGLD Added - Kiem tra khong cho sua, duyet doi voi man hinh CFMAST, AFMAST khi trang thai dang block hoac dong    
        If Not gvResult.GetFocusedDataRow() Is Nothing Then
            'If gvResult.Columns.Contains(gvResult.Columns("EDITALLOW")) = True Then
            If CType(SearchGrid.DataSource, DataTable).Columns.Contains("EDITALLOW") Then
                Dim v_strEDITALLOW As String = gvResult.GetFocusedDataRow()("EDITALLOW").ToString
                If v_strEDITALLOW = "Y" Then
                    bbiEdit.Enabled = True And editAuth And editAuthString
                Else
                    bbiEdit.Enabled = False And editAuth And editAuthString
                End If
            End If
            'If gvResult.Columns.Contains(gvResult.Columns("APRALLOW")) = True Then
            If CType(SearchGrid.DataSource, DataTable).Columns.Contains("APRALLOW") Then
                Dim v_strAPRALLOW As String = gvResult.GetFocusedDataRow()("APRALLOW").ToString
                If v_strAPRALLOW = "Y" Then
                    bbiApprove.Enabled = True And apprAuth And apprAuthString
                Else
                    bbiApprove.Enabled = False And apprAuth And apprAuthString
                End If
            End If
            'If gvResult.Columns.Contains(gvResult.Columns("DELALLOW")) = True Then
            If CType(SearchGrid.DataSource, DataTable).Columns.Contains("DELALLOW") Then
                Dim v_strDELALLOW As String = gvResult.GetFocusedDataRow()("DELALLOW").ToString
                If v_strDELALLOW = "Y" Then
                    bbiDelete.Enabled = True And delAuth And delAuthString
                Else
                    bbiDelete.Enabled = False And delAuth And delAuthString
                End If
            End If
            '17/01/2020' trung.luu khi trang thai = Y => khong cho nhan nut thuc thi
            If SearchGrid.DataSource.ToString = "OD0016" Then
                If CType(SearchGrid.DataSource, DataTable).Columns.Contains("CDVALSTATUSUNHOLD") Then
                    Dim v_strCDVALSTATUSUNHOLD As String = gvResult.GetFocusedDataRow()("CDVALSTATUSUNHOLD").ToString
                    Dim v_strCDVALSTATUSOD As String = gvResult.GetFocusedDataRow()("CDVALSTATUSOD").ToString
                    Dim v_strCDVALSTATUSPAYMENT As String = gvResult.GetFocusedDataRow()("CDVALSTATUSPAYMENT").ToString
                    If v_strCDVALSTATUSUNHOLD = "Y" And v_strCDVALSTATUSOD = "7" And v_strCDVALSTATUSPAYMENT = "Y" Then
                        bbiExecute.Enabled = False
                    Else
                        bbiExecute.Enabled = True
                    End If
                End If
            End If
            '17-03-2020 trung.luu:  ODMAST với type là ETF mới cho xem detail
            If Me.ObjectName = "ODMAST" Then
                Dim v_ODTYPEVAL As String = gvResult.GetFocusedDataRow()("ODTYPEVAL").ToString
                If v_ODTYPEVAL = "SWE" Then
                    bbiView.Enabled = True
                Else
                    bbiView.Enabled = False
                End If
            End If

            If SearchGrid.DataSource.ToString = "CRBBANKREQUEST" Then
                If CType(SearchGrid.DataSource, DataTable).Columns.Contains("CFSTATUS") Then
                    Dim v_strCFSTATUS As String = gvResult.GetFocusedDataRow()("CFSTATUS").ToString
                    If v_strCFSTATUS = "C" Then
                        bbiExecute.Enabled = False
                    Else
                        bbiExecute.Enabled = True
                    End If
                End If
            End If
            'End trung.luu
        End If
        'End Truongld

        If gvResult.GetFocusedDataRow() Is Nothing Then
            bbiApprove.Enabled = True And apprAuth And apprAuthString
            bbiDelete.Enabled = True And delAuth And delAuthString
        End If
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor
            Cursor.Show()

            'BO chon tren cac dong.
            'For i As Integer = 0 To gvResult.RowCount - 1
            '    'gvResult.GetDataRow(i)("__TICK").Value = String.Empty

            'Next

            If mv_intDblGrid = 0 Then
                mv_intDblGrid = 1
                If Me.bbiExecute.Visibility = BarItemVisibility.Always Then
                    gvSearchSelection.ClearSelection()
                    If gvResult.RowCount > 0 Then
                        If Not gvResult.GetFocusedDataRow() Is Nothing Then
                            'gvResult.GetFocusedDataRow()("__TICK").Value = "X"
                            gvSearchSelection.CheckMarkColumn.Visible = True
                            OnExecute(Nothing, True)   'Execute
                            'Exit Sub
                        End If
                    End If

                ElseIf Me.bbiView.Visibility = BarItemVisibility.Always Then
                    If Len(Trim(Me.AuthString)) > 0 Then
                        If Mid(Trim(AuthString), 1, 1) = "Y" Then
                            If Me.ObjectName = "ODMAST" Then 'trung.luu: 17-03-2020: ODMAST với type là ETF mới cho xem detail
                                Dim v_ODTYPEVAL As String = gvResult.GetFocusedDataRow()("ODTYPEVAL").ToString
                                If v_ODTYPEVAL = "SWE" Then
                                    OnQuery()
                                End If
                            Else
                                OnQuery()
                            End If
                        Else
                            OnClose()
                        End If
                    Else
                        OnClose()
                    End If
                Else
                    'trung.luu 22-02-2020: check neu goi tu view ma khong di giao dich ke tiep thi khong close
                    If Me.IsLookup = "Y" Then
                        'Default is choose and close Me.mv_strTLTXCD <> "" And
                        OnClose()
                    End If
                End If
                mv_intDblGrid = 0


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbiNext.ItemClick
        Dim CountR As Int32
        If CommandType = gc_CommandProcedure Then
            CountR = mv_intTotalRow
        Else
            CountR = CountRow()
        End If
        If CountR > (mv_intpage) * mv_rowpage Then
            mv_intpage = mv_intpage + 1
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        End If
    End Sub

    Private Sub btnBACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbiPrev.ItemClick

        mv_intpage = mv_intpage - 1
        If mv_intpage <= 0 Then
            mv_intpage = 1
        End If
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
    End Sub

    Protected Function CountRow() As Int32
        Try

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_intCOUNTROW As Int32
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "select COUNT(*) COUNTROW from (" & mv_strCmdSqlTemp & ") WHERE 0=0"

            'TheNN sua
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$MBID>", Me.BranchId)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$HO_MBID>", HO_MBID)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$BUSDATE>", Me.BusDate)
            'VanNT
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$AFACCTNO>", Me.AFACCTNO)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$CUSTID>", Me.CUSTID)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<@KEYVALUE>", LinkValue)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$TELLERID>", Me.TellerId)

            If Me.UserLanguage = gc_LANG_ENGLISH Then
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
            Else
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@CDCONTENT>", "CDCONTENT")
                v_strCmdInquiry = v_strCmdInquiry.Replace("<@DESCRIPTION>", "DESCRIPTION")
            End If


            'Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, ModuleCode & "." & ObjectName, _
                                          gc_ActionInquiry, v_strCmdInquiry)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "COUNTROW"
                                v_intCOUNTROW = v_strVALUE
                        End Select
                    End With
                Next
            Next
            Return v_intCOUNTROW
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Private Sub frmSearch_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Dim width As Int16
        width = Me.Width
        If width < 640 Then
            Me.Width = 640
            Me.Left = 0
        End If

    End Sub

    Protected Sub SetFocusGrid(ByVal Value As String)
        Try
            Dim v_blnItemFound As Boolean = False
            Dim v_intIndex As Int64, v_strText As String
            If KeyColumn = "" Or Value = "" Then
                Exit Sub
            Else
                For v_intIndex = 0 To gvResult.RowCount - 1
                    If gvResult.GetDataRow(v_intIndex).Item(KeyColumn).ToString = Value Then
                        'gvResult.OptionsSelection.MultiSelect = False
                        gvResult.ClearSelection()
                        gvResult.SelectRow(v_intIndex)
                        gvResult.FocusedRowHandle = v_intIndex
                        Exit For
                    End If
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub GetDataFromGrid(ByRef pv_strObjMsg As String, Optional ByVal pv_blnAll As Boolean = False, Optional ByRef countTick As Double = 0)
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_nodeList As Xml.XmlNodeList
            Dim v_nodeObjData As Xml.XmlElement
            Dim v_nodeEntry As Xml.XmlNode
            Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

            Dim v_int, v_intCount, v_intRow, v_intCol As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)

            For v_intRow = 0 To gvResult.RowCount - 1 Step 1

                If Not gvResult.GetDataRow(v_intRow) Is Nothing Then
                    If Not pv_blnAll Then
                        If gvResult.GetDataRow(v_intRow)("__TICK").Value = "X" Then
                            'Có được đánh dấu chọn
                            v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                            For v_intCol = 0 To gvResult.RowCount - 1
                                v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                                v_attrFLDNAME.Value = gvResult.Columns(v_intCol).FieldName
                                v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                                If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                    v_attrFLDTYPE.Value = "System.DateTime"
                                Else
                                    v_attrFLDTYPE.Value = gvResult.Columns(v_intCol).ColumnType.ToString
                                End If
                                v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                                'Add current value
                                v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                                v_attrOLDVAL.Value = ""
                                v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                                'Set value
                                v_nodeEntry.InnerText = gvResult.GetDataRow(v_intRow)(v_intCol).Value

                                v_nodeObjData.AppendChild(v_nodeEntry)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                            countTick = countTick + 1
                        End If
                    Else
                        'Trong truong hop check all thi gui het.
                        v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                        For v_intCol = 0 To gvResult.RowCount - 1
                            v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                            v_attrFLDNAME.Value = gvResult.Columns(v_intCol).FieldName
                            v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                            If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                v_attrFLDTYPE.Value = "System.DateTime"
                            Else
                                v_attrFLDTYPE.Value = gvResult.Columns(v_intCol).ColumnType.ToString
                            End If
                            v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                            'Add current value
                            v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                            v_attrOLDVAL.Value = ""
                            v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                            'Set value
                            v_nodeEntry.InnerText = gvResult.GetDataRow(v_intRow)(v_intCol).Value

                            v_nodeObjData.AppendChild(v_nodeEntry)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                        countTick = gvResult.RowCount
                    End If
                End If
            Next v_intRow

            pv_strObjMsg = v_xmlDocument.InnerXml

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Sub GetSMSDataFromGrid(ByRef pv_strObjMsg As String)
        Dim v_dt As DataTable
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_nodeList As Xml.XmlNodeList
            Dim v_nodeObjData As Xml.XmlElement
            Dim v_nodeEntry As Xml.XmlNode
            Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

            Dim v_int, v_intCount, v_intRow, v_intCol As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)

            For v_intRow = 0 To gvResult.RowCount - 1 Step 1

                If Not gvResult.GetDataRow(v_intRow) Is Nothing Then
                    If gvResult.GetDataRow(v_intRow)("__TICK").Value = "X" Then
                        'Có được đánh dấu chọn
                        v_nodeObjData = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

                        For v_intCol = 0 To gvResult.RowCount - 1
                            If gvResult.Columns(v_intCol).FieldName = "TRADEPHONE" Or gvResult.Columns(v_intCol).FieldName = "SMSCONTENT" Then

                                v_nodeEntry = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
                                v_attrFLDNAME.Value = gvResult.Columns(v_intCol).FieldName
                                v_nodeEntry.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")

                                If InStr("/TXDATE/EXPDATE", "/" & v_attrFLDNAME.Value) > 0 Then
                                    v_attrFLDTYPE.Value = "System.DateTime"
                                Else
                                    v_attrFLDTYPE.Value = gvResult.Columns(v_intCol).ColumnType.ToString
                                End If



                                v_nodeEntry.Attributes.Append(v_attrFLDTYPE)

                                'Add current value
                                v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
                                v_attrOLDVAL.Value = ""
                                v_nodeEntry.Attributes.Append(v_attrOLDVAL)

                                'Set value
                                v_nodeEntry.InnerText = gvResult.GetDataRow(v_intRow)(v_intCol).Value

                                v_nodeObjData.AppendChild(v_nodeEntry)
                            End If
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_nodeObjData)
                    End If
                End If
            Next v_intRow

            pv_strObjMsg = v_xmlDocument.InnerXml

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub gvResult_CustomDrawFooter(sender As Object, e As Views.Base.RowObjectCustomDrawEventArgs) Handles gvResult.CustomDrawFooter
        Dim intTotalRows As Integer = gvResult.DataRowCount

        Dim rowSelected As Integer = 0

        If Not gvSearchSelection Is Nothing Then
            rowSelected = gvSearchSelection.SelectedCount
        End If
        Dim strFootText As String
        If UserLanguage = "VN" Then
            strFootText = String.Format("Số bản ghi được chọn/Tổng số bản ghi tìm thấy: {0}/{1}", rowSelected, intTotalRows)
        Else
            strFootText = String.Format("Number of records selected/Total records found: {0}/{1}", rowSelected, intTotalRows)
        End If


        Dim TextSize As SizeF = e.Graphics.MeasureString(strFootText, e.Appearance.Font)

        e.Appearance.DrawBackground(e.Cache, e.Bounds)

        e.Appearance.DrawString(e.Cache, strFootText, New Rectangle(e.Bounds.Left, e.Bounds.Top + 5, CInt(TextSize.Width), CInt(TextSize.Height)))

        e.Handled = True
    End Sub

    Private Sub gvResult_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles gvResult.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle.ToString()
        End If
    End Sub

    Private Sub gvResult_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvResult.RowCellStyle
        'Dim frm = New frmXtraSearch__ChooseTransaction()
        'Dim dtDataRow As DataRow = frm.DataRowChoose

        If Me.ObjectName = "SIDGROUP" Then
            If e.Column.FieldName = "IDCODE" AndAlso e.RowHandle >= 0 Then
                Dim gv = TryCast(sender, GridView)
                If gv.GetRowCellValue(e.RowHandle, "SID").ToString.Length = 0 Then
                    e.Appearance.BackColor = Color.Orange
                End If
            End If
        End If
        If Me.ObjectName = "SIDSPLIT" Then
            If e.Column.FieldName = "SID" AndAlso e.RowHandle >= 0 Then
                Dim gv = TryCast(sender, GridView)
                If gv.GetRowCellValue(e.RowHandle, "IDCODE").ToString.Length = 0 Then
                    e.Appearance.BackColor = Color.Orange
                End If
            End If
        End If

        'config trong table CELLSDEFINE
        Try
            Dim row = CELLSDEFINETable.Select("KEYS = '" & ObjectName.ToUpper() & "." & e.Column.FieldName & "'")
            If row.length > 0 Then
                Dim gv = TryCast(sender, GridView)
                For Each ln As DataRow In row
                    If gv.GetRowCellValue(e.RowHandle, ln("CFIELDNAME").ToString) = ln("CVALUE").ToString Then
                        e.Appearance.BackColor = ColorTranslator.FromHtml(ln("FORMAT").ToString)
                    End If

                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region " QuickSearch "
    Private Sub BuildQuickCriterial()
        Dim op As CriteriaOperator

        If Not lueCondition1.EditValue Is Nothing And lueCondition1.Visible Then
            op = New BinaryOperator(lueCondition1.Tag.ToString, lueCondition1.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Not lueCondition2.EditValue Is Nothing And lueCondition2.Visible Then
            op = New BinaryOperator(lueCondition2.Tag.ToString, lueCondition2.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Not lueCondition3.EditValue Is Nothing And lueCondition3.Visible Then
            op = New BinaryOperator(lueCondition3.Tag.ToString, lueCondition3.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Not lueCondition4.EditValue Is Nothing And lueCondition4.Visible Then
            op = New BinaryOperator(lueCondition4.Tag.ToString, lueCondition4.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Not lueCondition5.EditValue Is Nothing And lueCondition5.Visible Then
            op = New BinaryOperator(lueCondition5.Tag.ToString, lueCondition5.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Not lueCondition6.EditValue Is Nothing And lueCondition6.Visible Then
            op = New BinaryOperator(lueCondition6.Tag.ToString, lueCondition6.EditValue)
            mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
        If Me.lblQueryDate.Visible And Me.lblQueryDate.Checked Then
            'Get value 
            Dim v_dtFrom, v_dtTo, v_strDateFilter As String
            v_dtFrom = "TO_DATE('" & Me.dtFrom.Text & "', 'DD/MM/RRRR')"
            v_dtTo = "TO_DATE('" & Me.dtTo.Text & "', 'DD/MM/RRRR')"
            v_strDateFilter = " AND (" & lblQueryDate.Tag & " BETWEEN " & v_dtFrom & " AND " & v_dtTo & ")"
            mv_strSearchFilter &= v_strDateFilter

            'op = New BetweenOperator(lblQueryDate.Tag, v_dtFrom, v_dtTo)
            'mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
        End If
    End Sub

    Private Sub lblCondition1_Click(sender As Object, e As EventArgs) Handles lblCondition1.Click
        Me.lueCondition1.EditValue = Nothing
    End Sub

    Private Sub lblCondition2_Click(sender As Object, e As EventArgs) Handles lblCondition2.Click
        Me.lueCondition2.EditValue = Nothing
    End Sub

    Private Sub lblCondition3_Click(sender As Object, e As EventArgs) Handles lblCondition3.Click
        Me.lueCondition3.EditValue = Nothing
    End Sub

    Private Sub lblCondition4_Click(sender As Object, e As EventArgs) Handles lblCondition4.Click
        Me.lueCondition4.EditValue = Nothing
    End Sub

    Private Sub lblCondition5_Click(sender As Object, e As EventArgs) Handles lblCondition5.Click
        Me.lueCondition5.EditValue = Nothing
    End Sub

    Private Sub lblCondition6_Click(sender As Object, e As EventArgs) Handles lblCondition6.Click
        Me.lueCondition6.EditValue = Nothing
    End Sub
#End Region

    Private Function objKey() As Object
        Throw New NotImplementedException
    End Function

    Private Sub cbauto_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles cbauto.CheckedChanged
        If cbauto.Checked Then
            If v_strObjMsg_search = "" Then
                mv_intpage = 1
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            End If
            thread.Change(mv_intInterval * 1000, mv_intInterval * 1000)
        Else
            thread.Change(0, 0)
        End If
    End Sub

End Class