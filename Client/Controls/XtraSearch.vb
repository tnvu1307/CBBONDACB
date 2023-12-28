Imports CommonLibrary
Imports System.Threading
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports System.IO
Imports System.Reflection
Imports AppCore
Imports AppCore.modXtraLib
Imports AppCore.modCoreLib
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.Drawing

Public Class XtraSearch

#Region " Khai báo hằng, biến "
    Const c_ResourceManager = gc_RootNamespace & ".ucSearch-"
    Const c_ResourceManagerGrid = "AppCore.frmSearch-"
    Const c_BlnAutoSearch = True


    Public mv_strSearchFilter As String
    Public hFilter As New Hashtable

    Private mv_strAccessArea As String = ""
    Private mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Private mv_strCmdSql As String
    Private mv_strObjName As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u ki�ện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u ki�ện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Private mv_arrSrFieldSrch() As String                       'T�ên các trư?ng l�àm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng s�ẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Gía trị mặc định

    Private mv_arrSrFieldFormat() As String                     '?�ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     '?�ộ rộng hiển thị trên lưới

    Private mv_arrStFieldMandartory() As String
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_ResourceManagerGrid As Resources.ResourceManager


    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerType As String
    Private mv_strTellerGroup As String
    Private mv_strBusDate As String
    Private mv_Worker As Thread = Nothing
    Private mv_strINTERVAL As String
    Private mv_strAutoid As String

    Private gvSearchSelection As GridCheckMarksSelection
    Private Shared gv_cache_view_search As Dictionary(Of String, DataTable) = New Dictionary(Of String, DataTable)
    Private Shared gv_cache_allcode As Dictionary(Of String, DataTable) = New Dictionary(Of String, DataTable)

    Public Event OnShowCriterial()
    Public Property Criterial As String
    'Public m_CurrCAToken As CAToken
    Public mv_SignMode As String = "N"
    Private mv_strTellerName As String
    Public ReadOnly Property SearchFieldMadatory() As String()
        Get
            Return mv_arrStFieldMandartory
        End Get
    End Property

    Public ReadOnly Property SearchField() As String()
        Get
            Return mv_arrSrFieldSrch
        End Get
    End Property

    Public ReadOnly Property SearchFieldType() As String()
        Get
            Return mv_arrSrFieldType
        End Get
    End Property

    Public ReadOnly Property SearchFieldDisplay() As String()
        Get
            Return mv_arrSrFieldDisp
        End Get
    End Property

    Public ReadOnly Property SearchFieldSqlRef() As String()
        Get
            Return mv_arrSrSQLRef
        End Get
    End Property
#End Region

#Region " Các thuộc tính của form "
    Public Property AccessArea() As String
        Get
            Return mv_strAccessArea
        End Get
        Set(ByVal Value As String)
            mv_strAccessArea = Value
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
    Public Property TellerName As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
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

    Public Property INTERVAL() As String
        Get
            Return mv_strINTERVAL
        End Get
        Set(ByVal Value As String)
            mv_strINTERVAL = Value
        End Set
    End Property


    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property

    Public Property TellerGroup() As String
        Get
            Return mv_strTellerGroup
        End Get
        Set(ByVal Value As String)
            mv_strTellerGroup = Value
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
    'Protected Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
    Public Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Try

            gvSearchSelection.ClearSelection()

            Dim v_arrTellerGroup(), v_strTellerGroup As String

            If Not TellerGroup Is Nothing Then
                v_arrTellerGroup = TellerGroup.Split("|")
                v_strTellerGroup = "'" & CStr(v_arrTellerGroup(0)).Trim & "'"
                If v_arrTellerGroup.Length > 1 Then
                    For i As Integer = 1 To v_arrTellerGroup.Length - 2
                        v_strTellerGroup &= ", " & "'" & CStr(v_arrTellerGroup(i)).Trim & "'"
                    Next
                End If
                v_strTellerGroup = "(" & v_strTellerGroup & ")"
            Else
                v_strTellerGroup = "('')"
            End If

            Dim str_search, str_Clause As String

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            mv_strSearchFilter = Criterial
            'Bo doan order by ORDER BY createdt desc
            If mv_strSearchFilter = "" Then
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " 0=0 ORDER BY TLLOG.AUTOID DESC "
            Else
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " ORDER BY TLLOG.AUTOID DESC "

            End If
            'mv_ResourceManager.GetString("ucSearch.ApproveConfirm")
            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    str_search = "pr_getussearch_en"
                Else
                    str_search = "pr_getUsSearch"
                End If

                str_Clause = "TellerId!" & Trim(TellerId) & "!varchar2!20^BranchId!" & BranchId & "!varchar2!20^SearchFilter!" & mv_strSearchFilter & "!Varchar2!20000"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                    gc_ActionInquiry, IIf(str_search.Trim.Length() > 0, str_search, ""), str_Clause, , , , , , , gc_CommandProcedure)

                v_ws.Message(v_strObjMsg)

                'Fill data into search grid
                FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManagerGrid & UserLanguage, mv_strTableName, , , , )

            End If

            XtraGridFormat(gvResult, c_ResourceManager & UserLanguage, mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)
            'Update mouse pointer
            Cursor.Current = Cursors.Default

            'End TruongLD
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    'Creates form from form name - CASE SENSITIVE
    Public Function GetFormByName(ByVal formName As String) As Form
        Dim assemblyName As String = Assembly.GetEntryAssembly().GetName.Name.Replace("@", "_")
        Dim myType As Type = Type.GetType(assemblyName & "." & formName)
        Return CType(Activator.CreateInstance(myType), Form)
    End Function
    Public Overridable Sub OnApprv()
        'Sua cho duyet hop dong di luong rieng
        Dim v_frm As New frmXtraApprove
        'v_frm.ExeFlag = ExeFlag
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ObjectName = Trim(SearchGridView.GetFocusedRow("MODULCODE")) + "." + Trim(SearchGridView.GetFocusedRow("CHILTABLE"))
        v_frm.TableName = Mid(ObjectName, 4)
        v_frm.LocalObject = IsLocalSearch
        v_frm.Text = Text
        v_frm.TellerId = TellerId
        v_frm.ParentObjName = Trim(SearchGridView.GetFocusedRow("PARENTTABLE"))
        'v_frm.GroupCareBy = GroupCareBy
        ' v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        '   v_frm.KeyFieldName = KeyFieldName
        v_frm.KeyFieldType = KeyFieldType
        ' v_frm.KeyFieldValue = KeyFieldValue
        v_frm.Objlogid = mv_strAutoid
        '  v_frm.LinkField = LinkField
        ' v_frm.IsReject = IsReject
        'v_frm.LinkValue = LinkValue
        v_frm.ShowDialog()
        'Me.DialogResult = DialogResult.OK
    End Sub
    Protected Function ShowForm(ByVal pv_intExecFlag As Integer, Optional ByVal pv_IsReject As Boolean = False) As DialogResult
        Dim v_strFullObjName As String
        Dim v_strPARENTKEY, v_strPARENTTABLE, v_strModuleCode, v_PARENTVALUE, v_strCHILDTABLE As String

        Dim v_frm As Object

        v_strPARENTTABLE = Trim(SearchGridView.GetFocusedRow("PARENTTABLE"))
        v_strPARENTKEY = Trim(SearchGridView.GetFocusedRow("PARENTKEY"))
        v_PARENTVALUE = Trim(SearchGridView.GetFocusedRow("PARENTVALUE"))
        v_strModuleCode = Trim(SearchGridView.GetFocusedRow("MODULCODE"))
        v_strCHILDTABLE = Trim(SearchGridView.GetFocusedRow("CHILTABLE"))
        If v_strPARENTTABLE = "PENSION" Then
            v_strPARENTKEY = "AUTOID"
        End If
        Try

            v_frm = GetFormByName("frm" & v_strPARENTTABLE)
            v_strFullObjName = v_strModuleCode & "." & v_strPARENTTABLE
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = v_strModuleCode
            v_frm.ObjectName = v_strFullObjName
            v_frm.TableName = v_strPARENTTABLE
            v_frm.LocalObject = IsLocalSearch
            v_frm.Text = FormCaption
            v_frm.TellerId = TellerId
            v_frm.TellerRight = "YYYY"

            v_frm.AuthString = "YYYY"
            v_frm.BranchId = BranchId
            v_frm.Busdate = Me.BusDate
            v_frm.KeyFieldName = v_strPARENTKEY
            v_frm.KeyFieldType = "C"
            v_frm.Objlogid = mv_strAutoid
            v_frm.IsReject = pv_IsReject
            v_frm.CHILDTABLE = v_strCHILDTABLE
            v_frm.KeyFieldValue = v_PARENTVALUE

            Dim frmResult As DialogResult = v_frm.ShowDialog()
            Return frmResult

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Public Overridable Function OnHistory(Optional ByVal pv_strIsLocal As String = gc_IsNotLocalMsg, Optional ByVal pv_strModule As String = "") As Int32
        Try
            Dim v_arrTellerGroup(), v_strTellerGroup As String

            Try
                'Không định timer
                tmrSearch.Enabled = False
                Dim frm As New frmXtraCriterial
                frm.SearchFieldMadatory = SearchFieldMadatory
                frm.SearchFieldName = SearchField
                frm.SearchFieldType = SearchFieldType
                frm.SearchFieldCaption = SearchFieldDisplay
                frm.SearchFieldSqlRef = SearchFieldSqlRef
                frm.ShowDialog()

                If Not frm.ReturnValue Is Nothing Then
                    Criterial = frm.ReturnValue


                    Try
                        'Dim v_arrTellerGroup(), v_strTellerGroup As String

                        If Not TellerGroup Is Nothing Then
                            v_arrTellerGroup = TellerGroup.Split("|")
                            v_strTellerGroup = "'" & CStr(v_arrTellerGroup(0)).Trim & "'"
                            If v_arrTellerGroup.Length > 1 Then
                                For i As Integer = 1 To v_arrTellerGroup.Length - 2
                                    v_strTellerGroup &= ", " & "'" & CStr(v_arrTellerGroup(i)).Trim & "'"
                                Next
                            End If
                            v_strTellerGroup = "(" & v_strTellerGroup & ")"
                        Else
                            v_strTellerGroup = "('')"
                        End If

                        Dim str_search, str_Clause As String

                        'Update mouse pointer
                        Cursor.Current = Cursors.WaitCursor

                        mv_strSearchFilter = Criterial
                        'Bo doan order by ORDER BY createdt desc
                        If mv_strSearchFilter = "" Then
                            mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " 0=0 ORDER BY TLLOG.TXNUM DESC "
                        Else
                            mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " ORDER BY TLLOG.TXNUM DESC "
                        End If
                        'mv_ResourceManager.GetString("ucSearch.ApproveConfirm")
                        If (pv_strIsLocal <> "") And (pv_strModule <> "") Then

                            If Me.UserLanguage = gc_LANG_ENGLISH Then
                                str_search = "pr_getussearchall_en"
                            Else
                                str_search = "pr_getussearchall"
                            End If

                            str_Clause = "TellerId!" & Trim(TellerId) & "!varchar2!20^BranchId!" & BranchId & "!varchar2!20^SearchFilter!" & mv_strSearchFilter & "!Varchar2!20000"
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                                gc_ActionInquiry, IIf(str_search.Trim.Length() > 0, str_search, ""), str_Clause, , , , , , , gc_CommandProcedure)

                            v_ws.Message(v_strObjMsg)

                            'Fill data into search grid
                            FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManagerGrid & UserLanguage, mv_strTableName, , , , )

                        End If

                        XtraGridFormat(gvResult, c_ResourceManager & UserLanguage, mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        'Release BDS TruongLD Add, set not auto refresh transaction on main monitor
                        tmrSearch.Enabled = c_BlnAutoSearch

                    Catch ex As Exception
                        LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
                        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End Try
                End If

            Catch ex As Exception

            End Try

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


    Protected Overridable Function OnView() As Int32
        Try
            'Check valid token
            'If mv_SignMode = "Y" Then
            '    Dim v_SignXml As New SignXML()
            '    If Not v_SignXml.CheckValidToken(Me.m_CurrCAToken) Then
            '        MsgBox("Chữ ký số không đúng, Đề nghị đăng nhập lại!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Function
            '    End If
            'End If
            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTLTXCD As String
            

            If Not (SearchGridView.GetFocusedRow Is Nothing) Then
                If Trim(SearchGridView.GetFocusedRow("TLTXCD")) = "8800" Then
                    'Duyet import file
                    'TruongLD edit 06/02/2020
                    'Trung.luu: 29-03-2020
                    Dim frm As New frmReadFile(Me.UserLanguage)
                    frm.TxDate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    frm.tltxcd = v_strTLTXCD
                    'frm.FileID = Trim(dr("ACCTNO"))
                    frm.FileID = Trim(SearchGridView.GetFocusedRow("ACCTNO"))
                    frm.IsApprove = True
                    frm.IsImport = True
                    frm.IsTransaction = True
                    frm.BranchId = Me.BranchId
                    frm.TellerID = Me.TellerId
                    frm.BusDate = Me.BusDate
                    frm.UserLanguage = Me.UserLanguage
                    frm.ModuleCode = SUB_SYSTEM_SA
                    frm.TellerType = Me.TellerType
                    frm.ShowDialog()
                Else
                    
                    'Trung.luu: 29-03-2020
                    v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    v_strTLTXCD = Trim(SearchGridView.GetFocusedRow("TLTXCD"))
                    'Hiển thị lên màn hình giao dịch
                    Dim frm As New frmXtraTransactMaster(UserLanguage)
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.ObjectName = ""
                    frm.TxDate = v_strTXDATE
                    frm.TxNum = v_strTXNUM
                    frm.BusDate = Me.BusDate
                    frm.TellerType = Me.TellerType
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
                    frm.ShowDialog()

                End If

                'GianhVG chinh sua neu view giao dich trong ngay thi search lai
                'View giao dich trong qua khu thi giu nguyen man hinh search
                If v_strTXDATE = Me.BusDate Then
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If
                gvSearchSelection.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Protected Overridable Function OnRefuse() As Int32
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'Check valid token
            'If mv_SignMode = "Y" Then
            '    Dim v_SignXml As New SignXML()
            '    If Not v_SignXml.CheckValidToken(Me.m_CurrCAToken) Then
            '        MsgBox("Chữ ký số không đúng, Đề nghị đăng nhập lại!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Function
            '    End If
            '    v_ws.CAToken = m_CurrCAToken
            'End If
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg, V_strObjectName As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strClause, v_strObjMsg As String
            Dim v_strMODULCODE, v_strPARENTTABLE As String
            Dim v_blTick As Boolean = False, v_blProccess As Boolean = False
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument

            Dim v_intRejectCount As Integer = 0
            Dim v_strComment4List As String = String.Empty
            Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long

            If gvSearchSelection.SelectedCount > 1 Then
                v_blTick = True
                If MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                    For i As Integer = 0 To gvSearchSelection.SelectedCount - 1
                        'Check trang thai gd phai la cho duyet
                        If gvSearchSelection.GetSelectedRow(i)("TXSTATUSCD") <> "4" Then
                            MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        'Tu choi
                        If Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "2004" Then
                            'Tu choi Duyet hop dong
                            Cursor.Current = Cursors.Default
                            MsgBox(mv_ResourceManager.GetString("urSearch.ContractNotRejectList"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        ElseIf (Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9997") Then
                            'Check quyền duyệt
                            'Chỉ cho user nào tạo thì được refuse. (hủy)
                            If Me.TellerId <> ADMIN_ID Then
                                If Me.TellerId <> gvSearchSelection.GetSelectedRow(i)("TLID") Then
                                    MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If
                            End If
                            'Tu choi duyet cac form maintain
                            v_strClause = Trim(gvSearchSelection.GetSelectedRow(i)("AUTOID"))
                            V_strObjectName = Trim(gvSearchSelection.GetSelectedRow(i)("MODULCODE")) & "." & Trim(gvSearchSelection.GetSelectedRow(i)("PARENTTABLE"))
                            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, "N", gc_MsgTypeObj, V_strObjectName, gc_ActionReject, , v_strClause, , , , , , , , , , Me.TellerName)
                            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo l?i
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        Else
                            v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(i)("TXNUM"))
                            v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(i)("TXDATE"))
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                    v_strObjMsg = String.Empty
                                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM, , , , , , , Me.TellerName)
                                    v_lngError = v_ws.Message(v_strObjMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
                                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                        Exit Function
                                    End If
                                End If
                            End If
                        End If
                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If
            ElseIf gvSearchSelection.SelectedCount = 1 Then
                v_blTick = True
                'Check trang thai gd phai la cho duyet
                If gvSearchSelection.GetSelectedRow(0)("TXSTATUSCD") <> "4" Then
                    MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Function
                End If
                If Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "2004" Then
                    'Chỉ cho user nào tạo thì được refuse. (hủy)
                    If Me.TellerId <> ADMIN_ID Then
                        If Me.TellerId <> gvSearchSelection.GetSelectedRow(0)("TLID") Then
                            MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    End If
                    'Tu choi Duyet hop dong
                    'Dim frm As New frmCFMAST()
                    'frm.TableName = "CFMAST"
                    'frm.BusDate = Me.BusDate
                    'frm.ModuleCode = "CF"
                    'frm.ObjectName = "CF.CFMAST"
                    'frm.UserLanguage = Me.UserLanguage
                    'frm.TellerId = Me.TellerId
                    'frm.BranchId = Me.BranchId
                    'frm.KeyFieldName = "CUSTID"
                    'frm.KeyFieldType = "C"
                    'frm.Text = "Từ chối duyệt thông tin hợp đồng"
                    'frm.KeyFieldValue = getCustIDfromCF(Trim(gvSearchSelection.GetSelectedRow(0)("ACCTNO")))
                    'frm.mv_isRejectAF = True
                    'frm.mv_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(0)("TXNUM"))
                    'frm.mv_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(0)("TXDATE"))
                    'frm.ExeFlag = ExecuteFlag.Approve
                    'frm.ShowDialog()
                ElseIf (Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9997") Then
                    'Check quyền duyệt
                    'Chỉ cho user nào tạo thì được refuse. (hủy)
                    If Me.TellerId <> ADMIN_ID Then
                        If Me.TellerId <> gvSearchSelection.GetSelectedRow(0)("TLID") Then
                            MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    End If
                    mv_strAutoid = Trim(gvSearchSelection.GetSelectedRow(0)("AUTOID"))
                    ' If ShowForm(ExecuteFlag.Approve, True) = DialogResult.OK Then
                    'If SearchOnInit = True Then
                    OnApprv()
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                    'End If
                    ' End If
                Else
                    If MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                        v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(0)("TXNUM"))
                        v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(0)("TXDATE"))
                        'Lấy thông tin chi tiết v? �điện giao dịch

                        'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                        v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                        v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                        v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                        v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                        v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                        v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                        If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                            'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                            If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM, , , , , , , Me.TellerName)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If
                                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                            End If
                        End If
                    End If
                End If
            End If


            If Not v_blTick Then
                If Not (SearchGridView.GetFocusedRow Is Nothing) Then
                    'Check trang thai gd phai la cho duyet
                    If SearchGridView.GetFocusedRow("TXSTATUSCD") <> "4" Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                    If Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2004" Then
                        'Chỉ cho user nào tạo thì được refuse. (hủy)
                        If Me.TellerId <> ADMIN_ID Then
                            If Me.TellerId <> SearchGridView.GetFocusedRow("TLID") Then
                                MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        End If
                        'Tu choi Duyet hop dong
                        'Dim frm As New frmCFMAST()
                        'frm.TableName = "CFMAST"
                        'frm.BusDate = Me.BusDate
                        'frm.ModuleCode = "CF"
                        'frm.ObjectName = "CF.CFMAST"
                        'frm.UserLanguage = Me.UserLanguage
                        'frm.TellerId = Me.TellerId
                        'frm.BranchId = Me.BranchId
                        'frm.KeyFieldName = "CUSTID"
                        'frm.KeyFieldType = "C"
                        'frm.Text = "Từ chối duyệt thông tin hợp đồng"
                        'frm.KeyFieldValue = getCustIDfromCF(Trim(SearchGridView.GetFocusedRow("ACCTNO")))
                        'frm.mv_isRejectAF = True
                        'frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        'frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        'frm.ExeFlag = ExecuteFlag.Approve
                        'frm.ShowDialog()
                    ElseIf (Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9999" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9998" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9997") Then

                        'Check quyền duyệt
                        'Chỉ cho user nào tạo thì được refuse. (hủy)
                        If Me.TellerId <> ADMIN_ID Then
                            If Me.TellerId <> SearchGridView.GetFocusedRow("TLID") Then
                                MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        End If
                        mv_strAutoid = Trim(SearchGridView.GetFocusedRow("AUTOID"))
                        If ShowForm(ExecuteFlag.Approve, True) = DialogResult.OK Then
                            'If SearchOnInit = True Then
                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                            'End If
                        End If
                    Else
                        If MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                            v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                            v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then


                                    v_strObjMsg = String.Empty
                                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM, , , , , , , Me.TellerName)
                                    v_lngError = v_ws.Message(v_strObjMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
                                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                        Exit Function
                                    End If
                                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                                End If
                            End If
                        End If
                    End If
                End If
            End If
            gvSearchSelection.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Protected Overridable Function OnRefuse_bk() As Int32
        Try
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                If Not (SearchGridView.GetFocusedRow Is Nothing) Then
                    v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM").Value)
                    v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE").Value)
                    'Lấy thông tin chi tiết v? �điện giao dịch
                    Dim v_strClause, v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                    'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                    v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                    v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                    v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                    v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                    v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                    If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                        'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                        If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                            Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                            v_strObjMsg = String.Empty
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM)
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                            MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                        End If
                    ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                        'Chỉ cho phép duyệt đối với những giao dịch dang o trang thai deleting 

                        v_strObjMsg = String.Empty
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseDeletingMessage", , v_strTXNUM)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Protected Overridable Function OnApprove(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            'update tiennv
            Dim dt As DataTable = SearchGrid.DataSource

            If dt.Rows.Count = 0 Then
                Exit Function
            End If

            If MsgBox(mv_ResourceManager.GetString("ucSearch.ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

                'TungNT sua co the approve all, neu co tick thi se thuc hien, ko thi chi thuc hien dong current
                Dim v_lngApprCount As Long = 0

                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If (drv IsNot Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        v_strOFFNAME = Trim(dr("OFFNAME"))
                        v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
                        If v_blProccess Then
                            v_lngApprCount = v_lngApprCount + 1
                        End If

                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If

                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                        v_strTXDATE = Trim(rv.Row("TXDATE")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                        v_strOFFNAME = Trim(rv.Row("OFFNAME")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OFFNAME").Value)
                        v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
                        If v_blProccess = False Then
                            Exit For
                        Else
                            v_lngApprCount = v_lngApprCount + 1
                        End If
                    Next
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedCountSuccessful").Replace("{0}", v_lngApprCount.ToString("###,##0")))
                'End
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Protected Overridable Function OnApprove() As Int32
    '    Try
    '        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '        'Check valid token
    '        'If mv_SignMode = "Y" Then
    '        '    Dim v_SignXml As New SignXML()
    '        '    If Not v_SignXml.CheckValidToken(Me.m_CurrCAToken) Then
    '        '        MsgBox("Chữ ký số không đúng, Đề nghị đăng nhập lại!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '        '        Exit Function
    '        '    End If
    '        '    v_ws.CAToken = m_CurrCAToken
    '        'End If
    '        If SearchGridView.RowCount = 0 Then
    '            Exit Function
    '        End If

    '        'Lấy TXDATE và TXNUM
    '        Dim v_blTick As Boolean = False, v_blProccess As Boolean = False
    '        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg, v_strAutoid As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
    '        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '        Dim v_lngApprCount As Long = 0
    '        Dim v_strClause, v_strObjMsg As String
    '        Dim v_strMODULCODE, v_strPARENTTABLE As String
    '        'Duyet theo list (>=2 GD)
    '        If gvSearchSelection.SelectedCount > 1 Then
    '            If MsgBox(mv_ResourceManager.GetString("ucSearch.ApproveListConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
    '                For i As Integer = 0 To gvSearchSelection.SelectedCount - 1

    '                    'If Not gvSearchSelection.GetSelectedRow(i)("WARNING").Length() = 0 Then
    '                    '    MsgBox(gvSearchSelection.GetSelectedRow(i)("WARNING"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                    'End If


    '                    v_blTick = True

    '                    If gvSearchSelection.GetSelectedRow(i)("TXSTATUSCD") <> "4" Then
    '                        MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        Exit Function
    '                    End If
    '                    If Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9997" Then
    '                        mv_strAutoid = Trim(gvSearchSelection.GetSelectedRow(i)("AUTOID"))
    '                        'Check quyền duyệt
    '                        If Me.TellerId <> ADMIN_ID Then
    '                            v_strClause = Trim(gvSearchSelection.GetSelectedRow(i)("PARENTTABLE"))
    '                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
    '                            v_lngError = v_ws.Message(v_strObjMsg)
    '                            If v_lngError <> ERR_SYSTEM_OK Then
    '                                Cursor.Current = Cursors.Default
    '                                MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                                Exit Function
    '                            End If
    '                        End If
    '                        'Duyet form maintain
    '                        v_strMODULCODE = gvSearchSelection.GetSelectedRow(i)("MODULCODE")
    '                        v_strPARENTTABLE = gvSearchSelection.GetSelectedRow(i)("PARENTTABLE")

    '                        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, v_strMODULCODE & "." & v_strPARENTTABLE, gc_ActionApprove, , mv_strAutoid, , , , , , , , , , Me.TellerName)
    '                        v_lngError = v_ws.Message(v_strObjMsg)
    '                        If v_lngError <> ERR_SYSTEM_OK Then
    '                            Cursor.Current = Cursors.Default
    '                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
    '                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                            Exit Function
    '                        End If
    '                    ElseIf InStr("2004|2016|2017", Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4)) > 0 Then
    '                        'Khong cho duyet hd hang loat
    '                        Cursor.Current = Cursors.Default
    '                        MsgBox(mv_ResourceManager.GetString("ucSearch.ContractNotApproveList"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        Exit Function
    '                    Else
    '                        v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(i)("TXNUM"))
    '                        v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(i)("TXDATE"))
    '                        v_strOFFNAME = Trim(gvSearchSelection.GetSelectedRow(i)("OFFNAME"))
    '                        v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
    '                        If v_blProccess = False Then
    '                            Exit For
    '                        End If
    '                    End If
    '                    v_lngApprCount = v_lngApprCount + 1
    '                Next
    '                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedCountSuccessful").Replace("{0}", v_lngApprCount.ToString("###,##0")))
    '            Else
    '                Exit Function
    '            End If
    '        ElseIf gvSearchSelection.SelectedCount = 1 Then

    '            'If Not gvSearchSelection.GetSelectedRow(0)("WARNING").Length() = 0 Then
    '            '    MsgBox(gvSearchSelection.GetSelectedRow(0)("WARNING"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '            'End If

    '            v_blTick = True
    '            'Check trang thai gd phai la cho duyet
    '            If gvSearchSelection.GetSelectedRow(0)("TXSTATUSCD") <> "4" Then
    '                MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                Exit Function
    '            End If
    '            If Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9997" Then
    '                mv_strAutoid = Trim(gvSearchSelection.GetSelectedRow(0)("AUTOID"))
    '                'Check quyền duyệt
    '                If Me.TellerId <> ADMIN_ID Then
    '                    v_strClause = Trim(SearchGridView.GetFocusedRow("PARENTTABLE"))
    '                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
    '                    v_lngError = v_ws.Message(v_strObjMsg)
    '                    If v_lngError <> ERR_SYSTEM_OK Then
    '                        Cursor.Current = Cursors.Default
    '                        MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        Exit Function
    '                    End If
    '                End If
    '                'If ShowForm(ExecuteFlag.Approve) = DialogResult.OK Then
    '                'If SearchOnInit = True Then
    '                OnApprv()
    '                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    '                'End If
    '                'End If
    '        ElseIf Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "2004" Then
    '            'Duyet hop dong
    '                'Dim frm As New frmCFMAST()
    '                'frm.TableName = "CFMAST"
    '                'frm.BusDate = Me.BusDate
    '                'frm.ModuleCode = "CF"
    '                'frm.ObjectName = "CF.CFMAST"
    '                'frm.UserLanguage = Me.UserLanguage
    '                'frm.TellerId = Me.TellerId
    '                'frm.BranchId = Me.BranchId
    '                'frm.KeyFieldName = "CUSTID"
    '                'frm.KeyFieldType = "C"
    '                'frm.Text = "Duyệt thông tin hợp đồng"
    '                'frm.KeyFieldValue = getCustIDfromCF(Trim(SearchGridView.GetFocusedRow("ACCTNO")))
    '                'frm.mv_isApproveAF = True
    '                'frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                'frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                'frm.mv_strDSTATUSCD = Trim(SearchGridView.GetFocusedRow("DSTATUSCD"))
    '                'frm.ExeFlag = ExecuteFlag.Approve
    '                'frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2016" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSIDGROUP
    '                '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
    '                '    frm.mv_strMODE = "APPROVE"
    '                '    frm.mv_strBrid = Me.BranchId
    '                '    frm.mv_strTLid = Me.TellerId
    '                '    frm.mv_strBusdate = Me.BusDate
    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2017" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSIDSPLIT
    '                '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
    '                '    frm.mv_strMODE = "APPROVE"
    '                '    frm.mv_strBrid = Me.BranchId
    '                '    frm.mv_strTLid = Me.TellerId
    '                '    frm.mv_strBusdate = Me.BusDate
    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4005" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSETransfer()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4014" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmBLOCKED()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4015" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmRELIEVE()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9287" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSBFUNDETF()

    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()

    '        Else
    '            v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(0)("TXNUM"))
    '            v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(0)("TXDATE"))
    '            v_strOFFNAME = Trim(gvSearchSelection.GetSelectedRow(0)("OFFNAME"))
    '            v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
    '            If v_blProccess Then
    '                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
    '            End If
    '        End If
    '            End If

    '        If Not v_blTick Then

    '            'If Not SearchGridView.GetFocusedRow("WARNING").Length() = 0 Then
    '            '    MsgBox(SearchGridView.GetFocusedRow("WARNING"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '            'End If

    '            'Check trang thai gd phai la cho duyet
    '            If SearchGridView.GetFocusedRow("TXSTATUSCD") <> "4" Then
    '                MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                Exit Function
    '            End If
    '            If Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9999" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9998" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9997" Then
    '                mv_strAutoid = Trim(SearchGridView.GetFocusedRow("AUTOID"))
    '                'Check quyền duyệt
    '                If Me.TellerId <> ADMIN_ID Then
    '                    v_strClause = Trim(SearchGridView.GetFocusedRow("PARENTTABLE"))
    '                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
    '                    v_lngError = v_ws.Message(v_strObjMsg)
    '                    If v_lngError <> ERR_SYSTEM_OK Then
    '                        Cursor.Current = Cursors.Default
    '                        MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        Exit Function
    '                    End If
    '                End If
    '                'If ShowForm(ExecuteFlag.Approve) = DialogResult.OK Then
    '                'If SearchOnInit = True Then
    '                OnApprv()
    '                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    '                'End If
    '                'End If
    '            ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2004" Then
    '                'Duyet hop dong
    '                'Dim frm As New frmCFMAST()
    '                'frm.TableName = "CFMAST"
    '                'frm.BusDate = Me.BusDate
    '                'frm.ModuleCode = "CF"
    '                'frm.ObjectName = "CF.CFMAST"
    '                'frm.UserLanguage = Me.UserLanguage
    '                'frm.TellerId = Me.TellerId
    '                'frm.BranchId = Me.BranchId
    '                'frm.KeyFieldName = "CUSTID"
    '                'frm.KeyFieldType = "C"
    '                'frm.Text = "Duyệt thông tin hợp đồng"
    '                'frm.KeyFieldValue = getCustIDfromCF(Trim(SearchGridView.GetFocusedRow("ACCTNO")))
    '                'frm.mv_isApproveAF = True
    '                'frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                'frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                'frm.mv_strDSTATUSCD = Trim(SearchGridView.GetFocusedRow("DSTATUSCD"))
    '                'frm.ExeFlag = ExecuteFlag.Approve
    '                'frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2016" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSIDGROUP
    '                '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
    '                '    frm.mv_strMODE = "APPROVE"
    '                '    frm.mv_strBrid = Me.BranchId
    '                '    frm.mv_strTLid = Me.TellerId
    '                '    frm.mv_strBusdate = Me.BusDate
    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2017" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSIDSPLIT
    '                '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
    '                '    frm.mv_strMODE = "APPROVE"
    '                '    frm.mv_strBrid = Me.BranchId
    '                '    frm.mv_strTLid = Me.TellerId
    '                '    frm.mv_strBusdate = Me.BusDate
    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4005" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmSETransfer()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4014" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmBLOCKED()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4015" Then
    '                '    'Duyet hop dong
    '                '    Dim frm As New frmRELIEVE()

    '                '    'frm.ModuleCode = "CF"
    '                '    'frm.ObjectName = "CF.CFMAST"
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '                'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9287" Then
    '                '    Dim frm As New frmSBFUNDETF()
    '                '    frm.UserLanguage = Me.UserLanguage
    '                '    frm.TellerId = Me.TellerId
    '                '    frm.BranchId = Me.BranchId
    '                '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                '    frm.ExeFlag = ExecuteFlag.Approve

    '                '    frm.ShowDialog()
    '            Else
    '                v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                v_strOFFNAME = Trim(SearchGridView.GetFocusedRow("OFFNAME"))
    '                v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
    '                If v_blProccess Then
    '                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
    '                End If

    '            End If
    '        End If
    '        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    '        gvSearchSelection.ClearSelection()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function
    Private Function getCustIDfromCF(ByVal pv_strCustodycd As String) As String
        Try
            Dim v_strCustid As String = String.Empty
            If pv_strCustodycd.Length > 0 Then
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_strFLDNAME, v_strVALUE As String
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdInquiry As String = "select custid from cfmast Where custodycd ='" & pv_strCustodycd & "'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, "CF.CFMAST", _
                                              gc_ActionInquiry, v_strCmdInquiry, )

                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "CUSTID"
                                    v_strCustid = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            End If
            Return v_strCustid
        Catch ex As Exception
            Return pv_strCustodycd
        End Try
    End Function

    'TungNT - tach ham approve sang ham khac
    Private Function ApproveTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, ByVal pv_strOffName As String) As Long
        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        v_strTXNUM = pv_strTxNum 'Trim(SearchGridView.GetFocusedRow("TXNUM").Value)
        v_strTXDATE = pv_strTxDate 'Trim(SearchGridView.GetFocusedRow("TXDATE").Value)
        v_strOFFNAME = pv_strOffName 'Trim(SearchGridView.GetFocusedRow("OFFNAME").Value)
        'Lấy thông tin chi tiết v? �điện giao dịch
        Dim v_strClause, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strWarningMessage As String = String.Empty
        Dim v_strInfoMessage As String = String.Empty
        'If mv_SignMode = "Y" Then
        '    v_ws.CAToken = m_CurrCAToken
        'End If

        Try
            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strTLTXCD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            If (v_intSTATUS = TransactStatus.Pending Or v_intSTATUS = TransactStatus.Completed) And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)

                    ''get Warning Message
                    GetWarningFromMessage(v_strObjMsg, v_strWarningMessage, v_strInfoMessage)
                    Cursor.Current = Cursors.Default
                    If v_strInfoMessage <> String.Empty Then
                        MsgBox(v_strInfoMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    If v_strWarningMessage <> String.Empty Then
                        MsgBox(v_strWarningMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        'If v_strTLTXCD = gc_CF_REMAP_TOKEN Then
                        '    Dim v_xmlErrorDocument As XmlDocumentEx
                        '    v_xmlErrorDocument = New XmlDocumentEx()
                        '    v_xmlErrorDocument.LoadXml(v_strObjMsg)
                        '    Dim v_xmlerrorNode = v_xmlErrorDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='p_err_message']")
                        '    If Not (v_xmlerrorNode Is Nothing) Then
                        '        v_strErrorMessage = v_xmlerrorNode.InnerText
                        '        Cursor.Current = Cursors.Default
                        '        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        '        Exit Function
                        '    Else
                        '        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                        '        Cursor.Current = Cursors.Default
                        '        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        '        Exit Function
                        '    End If
                        'Else
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                        ' End If
                        Return False
                    End If
                    'MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
                    Return True
                End If
            ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                'Duyệt xoá
                'Ducnv kiem tra chi maker moi duoc delete
                'Voi giao dich 9902 xoa giao dich GL trong qua khu thi khong can phai chi maker moi duoc xoa
                If v_strTLTXCD <> gc_GL_NORMAL Then
                    If Trim(Me.TellerId) <> ADMIN_ID And v_strOFFID.Length > 0 And Trim(Me.TellerId) <> Trim(v_strOFFID) Then
                        MsgBox(String.Format(mv_ResourceManager.GetString("ucSearch.ErrorApprove"), v_strOFFNAME))
                        Return False
                    End If
                End If

                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveDeleteMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                'MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeleteSuccessful"))
                Return True
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'End

    Protected Overridable Function OnApproveALL() As Int32
        Try
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor
                'Không định timer
                tmrSearch.Enabled = False
                If Me.SearchGridView.RowCount > 0 Then
                    Dim i As Integer
                    For i = 0 To Me.SearchGridView.RowCount - 1
                        'Lấy TXDATE và TXNUM
                        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                        If Not (SearchGridView.GetDataRow(i) Is Nothing) Then
                            v_strTXNUM = Trim(SearchGridView.GetDataRow(i)("TXNUM"))
                            v_strTXDATE = Trim(SearchGridView.GetDataRow(i)("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch
                            Dim v_strClause, v_strObjMsg As String
                            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                    v_strObjMsg = String.Empty
                                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                                    v_lngError = v_ws.Message(v_strObjMsg)
                                    'If v_lngError <> ERR_SYSTEM_OK Then
                                    '    'Thông báo lỗi
                                    '    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                                    '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                                    'End If
                                End If
                            End If
                        End If
                    Next
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                'Kích hoạt Timer
                tmrSearch.Enabled = c_BlnAutoSearch
                'Update mouse pointer
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnReject() As Int32
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'Check valid token
            'If mv_SignMode = "Y" Then
            '    Dim v_SignXml As New SignXML()
            '    If Not v_SignXml.CheckValidToken(Me.m_CurrCAToken) Then
            '        MsgBox("Chữ ký số không đúng, Đề nghị đăng nhập lại!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Function
            '    End If
            '    v_ws.CAToken = m_CurrCAToken
            'End If
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If

            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strTxMsg, V_strObjectName As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strClause, v_strObjMsg As String
            Dim v_strMODULCODE, v_strPARENTTABLE As String
            Dim v_blTick As Boolean = False, v_blProccess As Boolean = False
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument

            Dim v_intRejectCount As Integer = 0
            Dim v_strComment4List As String = String.Empty
            Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long

            If gvSearchSelection.SelectedCount > 1 Then
                v_blTick = True
                If MsgBox(mv_ResourceManager.GetString("ucSearch.RejectListConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                    For i As Integer = 0 To gvSearchSelection.SelectedCount - 1
                        'Check trang thai gd phai la cho duyet
                        If gvSearchSelection.GetSelectedRow(i)("TXSTATUSCD") <> "4" Then
                            MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        'Tu choi
                        If InStr("2004|2016|2017", Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4)) > 0 Then
                            'Tu choi Duyet hop dong
                            Cursor.Current = Cursors.Default
                            MsgBox(mv_ResourceManager.GetString("urSearch.ContractNotRejectList"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        ElseIf (Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD")).Substring(0, 4) = "9997") Then
                            'Check quyền duyệt
                            If Me.TellerId <> ADMIN_ID Then
                                v_strPARENTTABLE = Trim(gvSearchSelection.GetSelectedRow(i)("PARENTTABLE"))
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strPARENTTABLE, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    Cursor.Current = Cursors.Default
                                    MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    Exit Function
                                End If
                            End If
                            'Tu choi duyet cac form maintain
                            v_strClause = Trim(gvSearchSelection.GetSelectedRow(i)("AUTOID"))
                            V_strObjectName = Trim(gvSearchSelection.GetSelectedRow(i)("MODULCODE")) & "." & Trim(gvSearchSelection.GetSelectedRow(i)("PARENTTABLE"))
                            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, "N", gc_MsgTypeObj, V_strObjectName, gc_ActionReject, , v_strClause, , , , , , , , , , Me.TellerName)
                            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo l?i
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        Else
                            v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(i)("TXNUM"))
                            v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(i)("TXDATE"))
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                    'Hiển thị InputBox yêu cầu nhập lý do Reject
                                    If v_intRejectCount = 0 Then
                                        v_strComment4List = InputBox(mv_ResourceManager.GetString("ucSearch.RejectComment"), Me.Text, v_strCommentMessage)
                                        v_intRejectCount = v_intRejectCount + 1
                                    End If

                                    If Len(Trim(v_strComment4List)) > 0 Then
                                        v_strObjMsg = String.Empty
                                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strComment4List, , , , , , Me.TellerName)
                                        v_lngError = v_ws.Message(v_strObjMsg)
                                        If v_lngError <> ERR_SYSTEM_OK Then
                                            'Thông báo lỗi
                                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                            Cursor.Current = Cursors.Default
                                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                            Exit Function
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    Next
                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RerectedSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If
            ElseIf gvSearchSelection.SelectedCount = 1 Then
                v_blTick = True
                'Check trang thai gd phai la cho duyet
                If gvSearchSelection.GetSelectedRow(0)("TXSTATUSCD") <> "4" Then
                    MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Function
                End If
                If Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "2004" Then
                    'Tu choi Duyet hop dong
                    'Dim frm As New frmCFMAST()
                    'frm.TableName = "CFMAST"
                    'frm.BusDate = Me.BusDate
                    'frm.ModuleCode = "CF"
                    'frm.ObjectName = "CF.CFMAST"
                    'frm.UserLanguage = Me.UserLanguage
                    'frm.TellerId = Me.TellerId
                    'frm.BranchId = Me.BranchId
                    'frm.KeyFieldName = "CUSTID"
                    'frm.KeyFieldType = "C"
                    'frm.Text = "Từ chối duyệt thông tin hợp đồng"
                    'frm.KeyFieldValue = getCustIDfromCF(Trim(gvSearchSelection.GetSelectedRow(0)("ACCTNO")))
                    'frm.mv_isRejectAF = True
                    'frm.mv_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(0)("TXNUM"))
                    'frm.mv_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(0)("TXDATE"))
                    'frm.ExeFlag = ExecuteFlag.Approve
                    'frm.ShowDialog()
                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2016" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmSIDGROUP
                    '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
                    '    frm.mv_strMODE = "REJECT"
                    '    frm.mv_strBrid = Me.BranchId
                    '    frm.mv_strTLid = Me.TellerId
                    '    frm.mv_strBusdate = Me.BusDate
                    '    frm.ShowDialog()
                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2017" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmSIDSPLIT
                    '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
                    '    frm.mv_strMODE = "REJECT"
                    '    frm.mv_strBrid = Me.BranchId
                    '    frm.mv_strTLid = Me.TellerId
                    '    frm.mv_strBusdate = Me.BusDate
                    '    frm.ShowDialog()

                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4005" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmSETransfer()

                    '    'frm.ModuleCode = "CF"
                    '    'frm.ObjectName = "CF.CFMAST"
                    '    frm.UserLanguage = Me.UserLanguage
                    '    frm.TellerId = Me.TellerId
                    '    frm.BranchId = Me.BranchId
                    '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.ExeFlag = ExecuteFlag.Delete

                    '    frm.ShowDialog()
                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4014" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmBLOCKED()

                    '    'frm.ModuleCode = "CF"
                    '    'frm.ObjectName = "CF.CFMAST"
                    '    frm.UserLanguage = Me.UserLanguage
                    '    frm.TellerId = Me.TellerId
                    '    frm.BranchId = Me.BranchId
                    '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.ExeFlag = ExecuteFlag.Delete

                    '    frm.ShowDialog()
                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4015" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmRELIEVE()

                    '    'frm.ModuleCode = "CF"
                    '    'frm.ObjectName = "CF.CFMAST"
                    '    frm.UserLanguage = Me.UserLanguage
                    '    frm.TellerId = Me.TellerId
                    '    frm.BranchId = Me.BranchId
                    '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.ExeFlag = ExecuteFlag.Delete

                    '    frm.ShowDialog()
                    'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9287" Then
                    '    'Duyet hop dong
                    '    Dim frm As New frmSBFUNDETF()
                    '    frm.UserLanguage = Me.UserLanguage
                    '    frm.TellerId = Me.TellerId
                    '    frm.BranchId = Me.BranchId
                    '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                    '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                    '    frm.ExeFlag = ExecuteFlag.Delete

                    '    frm.ShowDialog()
                ElseIf (Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9999" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9998" Or Trim(gvSearchSelection.GetSelectedRow(0)("TLTXCD")).Substring(0, 4) = "9997") Then
                    'Check quyền duyệt
                    If Me.TellerId <> ADMIN_ID Then
                        v_strPARENTTABLE = Trim(gvSearchSelection.GetSelectedRow(0)("PARENTTABLE"))
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strPARENTTABLE, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            Cursor.Current = Cursors.Default
                            MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    End If
                    mv_strAutoid = Trim(gvSearchSelection.GetSelectedRow(0)("AUTOID"))
                    If ShowForm(ExecuteFlag.Approve, True) = DialogResult.OK Then
                        'If SearchOnInit = True Then
                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                        'End If
                    End If
                Else
                    If MsgBox(mv_ResourceManager.GetString("ucSearch.RejectConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                        v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(0)("TXNUM"))
                        v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(0)("TXDATE"))
                        'Lấy thông tin chi tiết v? �điện giao dịch

                        'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                        v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                        v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                        v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                        v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                        v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                        v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                        If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                            'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                            If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                'Hiển thị InputBox yêu cầu nhập lý do Reject
                                v_strCommentMessage = InputBox(mv_ResourceManager.GetString("ucSearch.RejectComment"), Me.Text, v_strCommentMessage)
                                If Len(Trim(v_strCommentMessage)) > 0 Then
                                    v_strObjMsg = String.Empty
                                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strCommentMessage, , , , , , Me.TellerName)
                                    v_lngError = v_ws.Message(v_strObjMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
                                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                        Exit Function
                                    End If
                                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RerectedSuccessful"))
                                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                                End If
                            End If
                        ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                            'Chỉ cho phép duyệt đối với những giao dịch dang o trang thai deleting 

                            v_strObjMsg = String.Empty
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseDeletingMessage", , v_strTXNUM)
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                            MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RerectedSuccessful"))
                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                    End If
                    End If
                End If
            End If


            If Not v_blTick Then
                If Not (SearchGridView.GetFocusedRow Is Nothing) Then
                    'Check trang thai gd phai la cho duyet
                    If SearchGridView.GetFocusedRow("TXSTATUSCD") <> "4" Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.TxstatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                    If Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2004" Then
                        'Tu choi Duyet hop dong
                        'Dim frm As New frmCFMAST()
                        'frm.TableName = "CFMAST"
                        'frm.BusDate = Me.BusDate
                        'frm.ModuleCode = "CF"
                        'frm.ObjectName = "CF.CFMAST"
                        'frm.UserLanguage = Me.UserLanguage
                        'frm.TellerId = Me.TellerId
                        'frm.BranchId = Me.BranchId
                        'frm.KeyFieldName = "CUSTID"
                        'frm.KeyFieldType = "C"
                        'frm.Text = "Từ chối duyệt thông tin hợp đồng"
                        'frm.KeyFieldValue = getCustIDfromCF(Trim(SearchGridView.GetFocusedRow("ACCTNO")))
                        'frm.mv_isRejectAF = True
                        'frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        'frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        'frm.ExeFlag = ExecuteFlag.Approve
                        'frm.ShowDialog()
                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2016" Then
                        '    'Duyet hop dong
                        '    Dim frm As New frmSIDGROUP
                        '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
                        '    frm.mv_strMODE = "REJECT"
                        '    frm.mv_strBrid = Me.BranchId
                        '    frm.mv_strTLid = Me.TellerId
                        '    frm.mv_strBusdate = Me.BusDate
                        '    frm.ShowDialog()
                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "2017" Then
                        '    'Duyet hop dong
                        '    Dim frm As New frmSIDSPLIT
                        '    frm.mv_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.mv_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.mv_Txstatuscd = Trim(SearchGridView.GetFocusedRow("TXSTATUSCD"))
                        '    frm.mv_strMODE = "REJECT"
                        '    frm.mv_strBrid = Me.BranchId
                        '    frm.mv_strTLid = Me.TellerId
                        '    frm.mv_strBusdate = Me.BusDate
                        '    frm.ShowDialog()

                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4005" Then
                        '    'Duyet hop dong
                        '    Dim frm As New frmSETransfer()

                        '    'frm.ModuleCode = "CF"
                        '    'frm.ObjectName = "CF.CFMAST"
                        '    frm.UserLanguage = Me.UserLanguage
                        '    frm.TellerId = Me.TellerId
                        '    frm.BranchId = Me.BranchId
                        '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.ExeFlag = ExecuteFlag.Delete

                        '    frm.ShowDialog()
                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4014" Then
                        '    'Duyet hop dong
                        '    Dim frm As New frmBLOCKED()

                        '    'frm.ModuleCode = "CF"
                        '    'frm.ObjectName = "CF.CFMAST"
                        '    frm.UserLanguage = Me.UserLanguage
                        '    frm.TellerId = Me.TellerId
                        '    frm.BranchId = Me.BranchId
                        '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.ExeFlag = ExecuteFlag.Delete

                        '    frm.ShowDialog()
                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "4015" Then
                        '    'Duyet hop dong
                        '    Dim frm As New frmRELIEVE()

                        '    'frm.ModuleCode = "CF"
                        '    'frm.ObjectName = "CF.CFMAST"
                        '    frm.UserLanguage = Me.UserLanguage
                        '    frm.TellerId = Me.TellerId
                        '    frm.BranchId = Me.BranchId
                        '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.ExeFlag = ExecuteFlag.Delete

                        '    frm.ShowDialog()
                        'ElseIf Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9287" Then
                        '    Dim frm As New frmSBFUNDETF()

                        '    frm.UserLanguage = Me.UserLanguage
                        '    frm.TellerId = Me.TellerId
                        '    frm.BranchId = Me.BranchId
                        '    frm.Txnum = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                        '    frm.Txdate = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                        '    frm.ExeFlag = ExecuteFlag.Delete

                        '    frm.ShowDialog()
                    ElseIf (Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9999" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9998" Or Trim(SearchGridView.GetFocusedRow("TLTXCD")).Substring(0, 4) = "9997") Then

                        'Check quyền duyệt
                        If Me.TellerId <> ADMIN_ID Then
                            v_strPARENTTABLE = Trim(SearchGridView.GetFocusedRow("PARENTTABLE"))
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strPARENTTABLE, "CheckApproveMaintainAllow", , , , , , , , , Me.TellerName)
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                Cursor.Current = Cursors.Default
                                MsgBox(mv_ResourceManager.GetString("ucSearch.MaintainAproveNotAllow"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        End If
                        mv_strAutoid = Trim(SearchGridView.GetFocusedRow("AUTOID"))
                        If ShowForm(ExecuteFlag.Approve, True) = DialogResult.OK Then
                            'If SearchOnInit = True Then
                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                            'End If
                        End If
                    Else
                        If MsgBox(mv_ResourceManager.GetString("ucSearch.RejectConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                            v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
                            v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                    'Hiển thị InputBox yêu cầu nhập lý do Reject
                                    v_strCommentMessage = InputBox(mv_ResourceManager.GetString("ucSearch.RejectComment"), Me.Text, v_strCommentMessage)
                                    If Len(Trim(v_strCommentMessage)) > 0 Then
                                        v_strObjMsg = String.Empty
                                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strCommentMessage, , , , , , Me.TellerName)
                                        v_lngError = v_ws.Message(v_strObjMsg)
                                        If v_lngError <> ERR_SYSTEM_OK Then
                                            'Thông báo lỗi
                                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                            Cursor.Current = Cursors.Default
                                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                            Exit Function
                                        End If
                                        MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RerectedSuccessful"))
                                        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            gvSearchSelection.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnCashierALL() As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.CashierConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor
                'Không định timer
                tmrSearch.Enabled = False

                If Me.SearchGridView.RowCount > 0 Then
                    Dim i As Integer
                    For i = 0 To Me.SearchGridView.RowCount - 1
                        'Lấy TXDATE và TXNUM
                        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strDELTD As String
                        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                        If Not (SearchGridView.GetDataRow(i) Is Nothing) Then
                            v_strTXNUM = Trim(SearchGridView.GetDataRow(i)("TXNUM"))
                            v_strTXDATE = Trim(SearchGridView.GetDataRow(i)("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch
                            Dim v_strClause, v_strObjMsg As String
                            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Cashier And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép thanh toán đối với các giao dịch đang ở trạng thái ch? thanh to�án
                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "CashMessage", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                End If
                            End If
                        End If
                    Next
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.CashieredSuccessful"))
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                'Kích hoạt Timer
                tmrSearch.Enabled = c_BlnAutoSearch
                'Update mouse pointer
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Protected Overridable Function OnDelete() As Int32
    '    Try
    '        'Modified by ChienTD 12/01/2007
    '        'Purpose: Confirm before action
    '        If SearchGridView.RowCount = 0 Then
    '            Exit Function
    '        End If
    '        If MsgBox(mv_ResourceManager.GetString("ucSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
    '            'Lấy TXDATE và TXNUM
    '            Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

    '            Dim v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strTxMsg, v_strDESC As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strTLNAME As String
    '            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '            For i As Integer = 0 To gvSearchSelection.SelectedCount

    '                v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(i)("TXNUM"))
    '                v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(i)("TXDATE"))
    '                v_strBUSDATE = Trim(gvSearchSelection.GetSelectedRow(i)("BUSDATE"))
    '                v_strTLTXCD = Trim(gvSearchSelection.GetSelectedRow(i)("TLTXCD"))
    '                v_strDESC = Trim(gvSearchSelection.GetSelectedRow(i)("TXDESC"))
    '                v_strTLNAME = Trim(gvSearchSelection.GetSelectedRow(i)("TLNAME"))
    '                v_blTick = True

    '                v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
    '                If Not v_blProccess Then
    '                    Exit For
    '                End If
    '            Next

    '            If Not v_blTick Then
    '                If Not (SearchGridView.GetFocusedRow Is Nothing) Then
    '                    v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM"))
    '                    v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE"))
    '                    v_strBUSDATE = Trim(SearchGridView.GetFocusedRow("BUSDATE"))
    '                    v_strTLTXCD = Trim(SearchGridView.GetFocusedRow("TLTXCD"))
    '                    v_strDESC = Trim(SearchGridView.GetFocusedRow("TXDESC"))
    '                    v_strTLNAME = Trim(SearchGridView.GetFocusedRow("TLNAME"))
    '                    v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
    '                End If
    '            End If
    '            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function

    Protected Overridable Function OnDelete(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            Dim dt As DataTable = SearchGrid.DataSource
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strTxMsg, v_strDESC As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strTLNAME As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If Not (drv Is Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        v_strBUSDATE = Trim(dr("BUSDATE"))
                        v_strTLTXCD = Trim(dr("TLTXCD"))
                        v_strDESC = Trim(dr("TXDESC"))
                        v_strTLNAME = Trim(dr("TLNAME"))
                        v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If
                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM"))
                        v_strTXDATE = Trim(rv.Row("TXDATE"))
                        v_strBUSDATE = Trim(rv.Row("BUSDATE"))
                        v_strTLTXCD = Trim(rv.Row("TLTXCD"))
                        v_strDESC = Trim(rv.Row("TXDESC"))
                        v_strTLNAME = Trim(rv.Row("TLNAME"))
                        v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
                        If Not v_blProccess Then
                            Exit For
                        End If
                    Next
                End If
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function DeleteTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, _
                                ByVal pv_strBusDate As String, ByVal pv_strTltxcd As String, _
                                ByVal pv_strDesc As String, ByVal pv_strTlName As String) As Boolean
        Dim v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strTxMsg, v_strDESC As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strTLNAME As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            v_strTXNUM = pv_strTxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
            v_strTXDATE = pv_strTxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
            v_strBUSDATE = pv_strBusDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BUSDATE").Value)
            v_strTLTXCD = pv_strTltxcd 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLTXCD").Value)
            v_strDESC = pv_strDesc 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDESC").Value)
            v_strTLNAME = pv_strTlName 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLNAME").Value)

            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            'Ducnv kiem tra chi maker moi duoc delete
            'Voi giao dich 9902 xoa giao dich GL trong qua khu thi khong can phai chi maker moi duoc xoa
            If v_strTLTXCD <> gc_GL_NORMAL Then
                If Trim(Me.TellerId) <> ADMIN_ID And Trim(Me.TellerId) <> Trim(v_strTLID) Then
                    MsgBox(String.Format(mv_ResourceManager.GetString("ucSearch.ErrorDelete"), v_strTLNAME))
                    Return False
                End If
            End If



            'If Trim(v_strDELTD) <> "Y" And v_intSTATUS = TransactStatus.Completed Then
            '    v_strObjMsg = String.Empty
            '    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteMessage", , v_strTXNUM)
            '    v_lngError = v_ws.Message(v_strObjMsg)
            '    If v_lngError <> ERR_SYSTEM_OK Then
            '        'Thông báo lỗi
            '        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
            '        Cursor.Current = Cursors.Default
            '        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Function
            '    End If
            '    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeletingSuccessful"))
            '    Return True
            'Else
            '    MsgBox("Chỉ giao dịch đã hoàn tất mới được phép xóa!")
            '    Return False
            'End If
            If Trim(v_strDELTD) <> "Y" And v_intSTATUS <> TransactStatus.ErrorOccured And v_intSTATUS <> TransactStatus.Refuse And v_intSTATUS <> TransactStatus.Completed And v_intSTATUS <> TransactStatus.Deleting Then
                'Chỉ xoá đối với những giao dịch chưa bị xoá và không lỗi và chưa bị refuse
                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Function
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeletingSuccessful"))
                Return True
            ElseIf Trim(v_strDELTD) <> "Y" And v_intSTATUS = TransactStatus.Completed Then
                'Thuc hien xoa voi giao dich o trang thai Complete chuyen thanh Pending to Delete
                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeletingMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    If v_lngError = ERR_SA_CHECKER1_OVR Or v_lngError = ERR_SA_CHECKER2_OVR Then
                        GetReasonFromMessage(v_strObjMsg, v_strErrorMessage)
                    End If
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeletingSuccessful"))
                Return True
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnCashier() As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            If SearchGridView.RowCount = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.CashierConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE

                For i As Integer = 0 To gvSearchSelection.SelectedCount

                    v_strTXNUM = Trim(gvSearchSelection.GetSelectedRow(i)("TXNUM").Value)
                    v_strTXDATE = Trim(gvSearchSelection.GetSelectedRow(i)("TXDATE").Value)

                    v_blTick = True
                    v_blProccess = CashierTran(v_strTXNUM, v_strTXDATE)
                    If Not v_blProccess Then
                        Exit For
                    End If

                Next

                If Not v_blTick Then
                    v_strTXNUM = Trim(SearchGridView.GetFocusedRow("TXNUM").Value)
                    v_strTXDATE = Trim(SearchGridView.GetFocusedRow("TXDATE").Value)

                    v_blProccess = CashierTran(v_strTXNUM, v_strTXDATE)
                End If
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function CashierTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String) As Boolean
        'Lấy TXDATE và TXNUM
        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strDELTD As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        v_strTXNUM = pv_strTxNum
        v_strTXDATE = pv_strTxDate
        Try
            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Cashier And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép thanh toán đối với các giao dịch đang ở trạng thái ch? thanh to�án
                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "CashMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.CashieredSuccessful"))
                Return True
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Protected Overridable Sub OnAdvanceSearch()
        Try
            If Not OnShowCriterialEvent Is Nothing Then
                RaiseEvent OnShowCriterial()
            End If

        Catch ex As Exception
            LogError.Write("Error source: OnExpand ::" & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Overridable Function OnExport() As Int32
        Try
            'Check valid token
            'If mv_SignMode = "Y" Then
            '    Dim v_SignXml As New SignXML()
            '    If Not v_SignXml.CheckValidToken(Me.m_CurrCAToken) Then
            '        MsgBox("Chữ ký số không đúng, Đề nghị đăng nhập lại!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Function
            '    End If
            'End If
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_filetype = Mid(v_strFileName, InStr(v_strFileName, "."))
                If v_filetype = ".txt" Or v_filetype = ".csv" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (SearchGridView.RowCount > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        For idx As Integer = 0 To SearchGridView.Columns.Count - 1
                            If SearchGridView.Columns(idx).Visible Then
                                v_strData &= SearchGridView.Columns(idx).Caption & vbTab
                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        For i As Integer = 0 To SearchGridView.RowCount - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To SearchGridView.RowCount - 1
                                If SearchGridView.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(SearchGridView.GetDataRow(i)(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("ucSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Function
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else

                    'Ghi file excel
                    Dim v_Ew As New ExcelLib
                    v_Ew.ExportData(v_strFileName, SearchGrid, v_filetype)


                End If
                MsgBox(mv_ResourceManager.GetString("ucSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
#End Region

#Region " Other methods "
    Public Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        mv_ResourceManagerGrid = New Resources.ResourceManager(c_ResourceManagerGrid & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        LoadInterface()

        bbiApprove.Caption = mv_ResourceManager.GetString("tbnApprove")
        bbiCashier.Caption = mv_ResourceManager.GetString("tbnCashier")
        bbiCancel.Caption = mv_ResourceManager.GetString("tbnCancel")
        bbiReject.Caption = mv_ResourceManager.GetString("tbnReject")
        bbiView.Caption = mv_ResourceManager.GetString("tbnView")
        'btnRefuse.Text = mv_ResourceManager.GetString("btnRefuse")
        bbiSearch.Caption = mv_ResourceManager.GetString("ucSearch.btnSearch")
        bbiAdvanceSearch.Caption = mv_ResourceManager.GetString("ucSearch.btnSearchAdvance")

        bbiExport.Caption = mv_ResourceManager.GetString("ucSearch.btnExport")
        bbiNextPage.Caption = mv_ResourceManager.GetString("tbnNext")
        bbiBackPage.Caption = mv_ResourceManager.GetString("tbnPrev")
        bbiHistory.Caption = mv_ResourceManager.GetString("ucSearch.btnHistory")

        bciCheckAllPage.Caption = mv_ResourceManager.GetString("bciCheckAllPage")
        rpgAudit.Text = mv_ResourceManager.GetString("rpgAudit")
        rpgSearch.Text = mv_ResourceManager.GetString("ucSearch.btnSearch")
        GroupControl1.Text = mv_ResourceManager.GetString("ucSearch.grbSearchResult")




        bbiCashier.Visibility = False
        bbiReject.Visibility = False
        'bbiDelete.Visibility = False

        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'Set event double click for Grid
        RemoveHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick
        AddHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick

        AddHandler gvResult.KeyUp, AddressOf Grid_KeyUp
        'AddHandler gvResult.SelectionChanged, AddressOf Grid_SelectedRowsChanged
        AddHandler gvResult.CustomDrawCell, AddressOf OnCustomDrawCell

        'If Not SearchGrid.Columns("__TICK") Is Nothing Then
        '    SearchGrid.Columns("__TICK").Visible = True
        '    SearchGrid.ContextMenu = Me.mnuGrid
        'End If

        'Set click event for buttons        
        AddHandler bbiHistory.ItemClick, AddressOf Button_Click
        AddHandler bbiSearch.ItemClick, AddressOf Button_Click
        AddHandler bbiExport.ItemClick, AddressOf Button_Click
        AddHandler bbiFullScreen.ItemClick, AddressOf Button_Click
        AddHandler bbiAdvanceSearch.ItemClick, AddressOf Button_Click

        'Thiết lập các giá trị ban đầu cho các đi?u ki�ện tìm kiếm
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        PrepareSearchParams(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, mv_strFormName, _
            mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, mv_arrStFieldDefValue, _
            mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType)

        Dim result As DataTable

        If Not gv_cache_view_search.ContainsKey(mv_strTableName) Then
            result = InitGridSearchFields(mv_strObjName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
            gv_cache_view_search.Add(mv_strTableName, result)
        Else
            gv_cache_view_search.TryGetValue(mv_strTableName, result)
        End If

        SearchGrid.DataSource = result

        gvResult.ClearSorting()
        gvResult.ClearGrouping()
        gvResult.ClearColumnsFilter()
        'gvResult.ClearSelection()


        'create filter control
        CreateFilterColumn(fcCriterial.CriterialProperty, mv_arrStFieldMandartory, mv_arrSrFieldSrch, mv_arrSrFieldType, mv_arrSrFieldDisp, mv_arrSrSQLRef)

        If Not gvResult.Columns.Contains(gvResult.Columns("CheckMarkSelection")) Then

            gvSearchSelection = New GridCheckMarksSelection(gvResult, mv_strTableName)
            gvSearchSelection.CheckMarkColumn.VisibleIndex = 0
            gvSearchSelection.CheckMarkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False
        End If

        '8. Update form caption
        If UserLanguage <> "EN" Then
            FormCaption = mv_strCaption
        Else
            FormCaption = mv_strEnCaption
        End If
        Me.Text = FormCaption


        'If SearchOnInit Then
        'trung.luu: 28-03-2020 => vao man hinh chinh tu dong nhan nut search 
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)


        'End If
    End Function

    Private Function BuildLookUpList(ByVal strSQLRef As String()) As String
        Try
            Dim v_strCmdInquiry As String = (From s In strSQLRef Where Not String.IsNullOrEmpty(s)).Aggregate("", Function(current1, s) current1 + (s + " UNION ALL "))
            v_strCmdInquiry += v_strCmdInquiry + "SELECT '' VALUE, '' DISPLAY FROM DUAL"
            'Thiết lập các giá trị ban đầu cho các đi?u ki�ện tìm kiếm
            Return BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, String.Empty, )
        Catch ex As Exception
            LogError.Write("Error source: BuildLookUpList" & ex.Source & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Function

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
            End If
        Next
    End Sub

    Public Overridable Sub LoadInterface()
        Try
            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            v_strTeller = Mid(TellerType, 1, 1)
            v_strCashier = Mid(TellerType, 2, 1)
            v_strOfficer = Mid(TellerType, 3, 1)
            v_strChecker = Mid(TellerType, 4, 1)

            'Display toolbar button
            bbiApprove.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))
            bbiCashier.Enabled = (v_strCashier = "Y")
            bbiReject.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))
            'bbiDelete.Enabled = (v_strTeller = "Y")
            'bbiRefuse.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Search()
        LabelControl1.Text = Criterial
        gvSearchSelection.ClearSelection()
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    End Sub
    Public Sub Search(ByVal pv_IslocalSearch As String, ByVal pv_ModuleCode As String, ByVal pv_ObjectName As String)
        LabelControl1.Text = Criterial
        gvSearchSelection.ClearSelection()
        OnSearch(pv_IslocalSearch, pv_ModuleCode & "." & pv_ObjectName)
    End Sub
#End Region

#Region " Các sự kiện của form "
    'TODO: ThongPM
    'Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
    '    Dim v_intRow As Integer
    '    If Not SearchGrid Is Nothing Then
    '        If SearchGridView.RowCount > 0 Then
    '            For v_intRow = 0 To SearchGridView.RowCount - 1 Step 1
    '                If SearchGridView.GetDataRow(v_intRow).Cells("__TICK").Visible = True Then
    '                    SearchGridView.GetDataRow(v_intRow).Cells("__TICK").Value = "X"
    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub

    'Private Sub mnuDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselectAll.Click
    '    Dim v_intRow As Integer
    '    If Not SearchGrid Is Nothing Then
    '        If SearchGridView.RowCount > 0 Then
    '            For v_intRow = 0 To SearchGridView.RowCount - 1 Step 1
    '                SearchGridView.GetDataRow(v_intRow).Cells("__TICK").Value = String.Empty
    '            Next
    '        End If
    '    End If

    'End Sub

    Protected Overridable Sub OnCustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        Try
            If e.Column.FieldName.Equals("TXSTATUS") Then

                Dim view = CType(sender, GridView)
                e.Column.ColumnEdit = riteStatus

                'Dim gci As GridCellInfo = CType(e.Cell, GridCellInfo)
                If (e.RowHandle >= 0) Then
                    Dim value = view.GetRowCellValue(e.RowHandle, view.Columns("TXSTATUSCD"))
                    If value = 9 Then
                        riteStatus.ContextImage = ImageCollection1.Images(Int32.Parse(value - 1))
                    Else
                        riteStatus.ContextImage = ImageCollection1.Images(Int32.Parse(value))
                    End If
                    'CType(gci.ViewInfo, TextEditViewInfo).ContextImage = ImageCollection1.Images(Int32.Parse(value))
                Else
                    riteStatus.ContextImage = ImageCollection1.Images(0)
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw
        End Try

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'TODO: ThongPM
    End Sub
    'Private Sub tmrSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSearch.Tick
    '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    ' End Sub

    Private Sub frmSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'DoResizeForm()
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs)
        Try
            If (e.Item Is bbiSearch) Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            ElseIf (e.Item Is bbiHistory) Then
                OnHistory(, ModuleCode & "." & ObjectName)
            ElseIf (e.Item Is bbiExport) Then
                OnExport()
            ElseIf (e.Item Is bbiFullScreen) Then
                OnExpand()
            ElseIf (e.Item Is bbiAdvanceSearch) Then
                OnAdvanceSearch()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw
        End Try
    End Sub
    Private Sub tbnView_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs) Handles bbiView.ItemClick
        If SearchGridView.RowCount > 0 Then
            OnView()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub

    Private Sub tbnCashier_Click(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles bbiCashier.ItemClick
        If SearchGridView.RowCount > 0 Then
            OnCashier()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub

    Private Sub tbnApprove_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs) Handles bbiApprove.ItemClick
        If SearchGridView.RowCount > 0 Then
            OnApprove()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub

    Private Sub tbnReject_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs) Handles bbiReject.ItemClick
        If SearchGridView.RowCount > 0 Then
            OnReject()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub
    Private Sub tbnRefuse_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs) Handles bbiCancel.ItemClick
        If SearchGridView.RowCount > 0 Then
            OnDelete()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub

    Private Sub tbnDelete_Click(ByVal sender As System.Object, ByVal e As ItemClickEventArgs)
        If SearchGridView.RowCount > 0 Then
            OnDelete()
        Else
            MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub

    Private Sub usSeach_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.C
                If Keys.Control Then
                    If Not (SearchGridView.GetFocusedRow Is Nothing) Then
                        Clipboard.SetDataObject(SearchGridView.GetFocusedRow("ACCTNO").Value)
                    End If
                End If
            Case Keys.F6
                If Not (SearchGrid Is Nothing) Then
                    If SearchGrid.Enabled And SearchGrid.Visible Then
                        SearchGrid.Focus()
                    End If
                End If
        End Select
    End Sub
    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            OnView()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Grid_SelectedRowsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Trim(SearchGridView.GetFocusedRow("TLTXCD").Value)
            If Trim(CType(sender, GridView).GetFocusedRow("TXSTATUSCD")) = TransactStatus.Cashier Then
                bbiCashier.Enabled = True
            Else
                bbiCashier.Enabled = False
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Alt.D
                    OnDelete(True)
                Case Keys.Alt.V
                    OnView()
                Case Keys.Alt.A
                    OnApprove()
                Case Keys.Alt.R
                    OnReject()
                Case Keys.Alt.Home
                    OnApproveALL()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Function CountRow() As Int32
        Try
            mv_strSearchFilter = String.Empty
            If (Not (fcCriterial.CriterialProperty.FilterCriteria) Is Nothing) Then
                Dim op As CriteriaOperator = fcCriterial.CriterialProperty.FilterCriteria
                mv_strSearchFilter &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(op)
            End If

            mv_strSearchFilter = Mid(mv_strSearchFilter, 5)
            If mv_strSearchFilter = "" Then
                mv_strSearchFilter = " 0 = 0 "
            End If
            'If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
            '    mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
            'End If

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_intCOUNTROW As Int32
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "select COUNT(*) COUNTROW from " & mv_strObjName & " Where 0=0"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, ModuleCode & "." & ObjectName, _
                                          gc_ActionInquiry, v_strCmdInquiry, mv_strSearchFilter)

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

#End Region



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

    Private Sub gvResult_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles gvResult.CustomDrawCell
        SetRespositoryItemEditCheck(sender, e)
    End Sub

    Private Sub SetRespositoryItemEditCheck(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
        Try
            If e.Column.FieldName = "CheckMarkSelection" AndAlso e.RowHandle >= 0 Then
                Dim gv = TryCast(sender, GridView)
                Dim isPending = gv.GetRowCellValue(e.RowHandle, "TXSTATUSCD")
                Dim v_approveAllow = gv.GetRowCellValue(e.RowHandle, "APRALLOW")
                Dim v_refuseAllow = gv.GetRowCellValue(e.RowHandle, "REFUSEALLOW")
                If InStr("|4|7|", isPending) = 0 Or (v_approveAllow = "N" And v_refuseAllow = "N") Then
                    Dim info = TryCast((TryCast(e.Cell, GridCellInfo)).ViewInfo, CheckEditViewInfo)
                    info.CheckInfo.State = ObjectState.Disabled
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
