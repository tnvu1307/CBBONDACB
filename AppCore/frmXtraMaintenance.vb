Imports System.ComponentModel
Imports System.IO
Imports System.Web.UI
Imports CommonLibrary
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports TestBase64
Imports ZetaCompressionLibrary
Imports DevExpress.XtraTab
Imports Oracle.DataAccess.Types
Imports System.Windows.Forms

Public Class frmXtraMaintenance


#Region " Khai báo biến, hằng "
    Private mv_blnIsRiskManagement As Boolean = False
    Private mv_blnIsReject As Boolean = False
    Private mv_intExecFlag As Integer = modCommond.ExecuteFlag.View
    Private mv_strLanguage As String
    Private mv_resourceManager As Resources.ResourceManager

    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String

    Private mv_strKeyField As String
    Private mv_strKeyType As String
    Private mv_strKeyValue As String

    Protected mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strAuthString As String
    Private mv_strTellerRight As String
    Private mv_strGroupCareBy As String
    Private mv_strBusDate As String
    Private mv_strObjlogid As String
    Private mv_strChildTable As String

    'AnhVT Maintenance Retroed
    Private mv_strParentObjName As String
    Private mv_strParentClause As String
    'AnhVT Ended
    Private mv_strLocalObject As String
    Private mv_strXMLFldMaster As String

    Protected mv_dsOldInput As DataSet
    Protected mv_dsInput As DataSet
    Protected mv_dsControlType As DataSet

    Private mv_saveButtonType As SaveButtonType

    Private mv_strLinkValue As String
    Private mv_strLinkField As String

    Private hLinkSrc As New Hashtable
    Private hLinkDes As New Hashtable
    Private mv_strNextDate As String
    Public mv_frmSearchScreen As frmSearch
    Private mv_isClose As Boolean = False
    Private mv_isCloseOk As Boolean = True

    Private mv_strParentValue As String

    Protected mv_dsTypeBytes As DataSet
#End Region

#Region " Overridable Functions "
    Protected Overridable Sub SetLookUpDataForm()

    End Sub

    Public Overridable Sub DoShowScreen()

    End Sub
    Public Overridable Sub FillData()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String, v_strObjMsg As String = String.Empty
        Dim v_blnRiskFld As Boolean
        Dim v_ctrl As Windows.Forms.Control

        Try
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            Dim v_strCmdInquiry As String
            If TableName = "ODMAST" Then
                v_strCmdInquiry &= " SELECT * FROM ODMAST WHERE " & v_strFilter
                v_strCmdInquiry &= " UNION ALL "
                v_strCmdInquiry &= " SELECT * FROM ODMASTHIST WHERE " & v_strFilter
            ElseIf TableName = "FEEACM" Then
                v_strCmdInquiry &= "SELECT * FROM (SELECT f.id,f.frdate,f.todate,t.feerate rate,t.CALNAV ,t.NAVTIME,t.RATETIME,f.codeid" _
                                   & " FROM feetype  f,feeapply l,feemaster t " _
                                    & " WHERE   f.feetype = 'ACM' and f.id = l.feeid and t.aplid = l.id) WHERE " & v_strFilter
            ElseIf TableName = "UNITLINKFUND" Then
                v_strCmdInquiry &= "select * from (select ROW_NUMBER() OVER(ORDER BY ULF.FUNDCODEID) AUTOID, ULF.* from " _
                            & "(select F1.CODEID FUNDCODEID, F2.CODEID REFFUNDCODEID, F2.SYMBOL REFFUNDNAME,A1.CDCONTENT REFFUNDTYPE, M.MBCODEVSD MBCODE, M.MBNAME, FA.TRADE QTTY,  'OWNER'  RELATIONSHIP, " _
                            & "ROUND(FA.TRADE/(select BALANCE from GLMAST where FUNDCODEID = F1.CODEID and ALIASCD = '081'),2) RATIO " _
                            & "from FASEMAST FA, FUND F1, FUND F2, MEMBERS M, ALLCODE A1 where FA.FUNDCODEID = F1.CODEID And FA.REFSYMBOL = F2.SYMBOL AND M.MBCODE = F2.FMCODE " _
                            & "AND F2.FTYPE=A1.CDVAL and A1.CDNAME ='REFCODETYP' AND A1.CDTYPE ='SA' union all " _
                            & "select F1.CODEID FUNDCODEID, F2.CODEID REFFUNDCODEID, F2.SYMBOL REFFUNDNAME,A1.CDCONTENT REFFUNDTYPE, M.MBCODEVSD MBCODE, M.MBNAME, FA.TRADE QTTY, 'POFORLIO'  RELATIONSHIP, " _
                            & "ROUND(FA.TRADE/(select BALANCE from GLMAST where FUNDCODEID = F1.CODEID and ALIASCD = '081'),2) RATIO " _
                            & "from FASEMAST FA, FUND F1, FUND F2, MEMBERS M, ALLCODE A1 where FA.REFSYMBOL=F1.SYMBOL and FA.FUNDCODEID=F2.CODEID AND M.MBCODE = F2.FMCODE " _
                            & "AND F2.FTYPE=A1.CDVAL and A1.CDNAME ='REFCODETYP' AND A1.CDTYPE ='SA' ) ULF where FUNDCODEID = " & ParentValue & ")  where " & v_strFilter & ""
            ElseIf TableName = "FILEUPLOAD" Then
                v_strCmdInquiry &= "select AUTOID, BUSINESS, CLIENT, CONTRACTNO, CREATEDATE, CUSTODYCD, DOCTYPE,'' FILEBLOB, NOTE, TICKER, TLID, TXDATE, TXNUM, FULLNAME from FILEUPLOAD WHERE " & v_strFilter
            Else
                v_strCmdInquiry &= "SELECT * FROM " & TableName & " WHERE " & v_strFilter
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With

                    For j As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If mv_arrObjFields(j).FieldName = Trim(v_strFLDNAME) Then
                            v_strFieldType = mv_arrObjFields(j).FieldType
                            v_strDataType = mv_arrObjFields(j).DataType
                            v_blnRiskFld = mv_arrObjFields(j).RiskField
                            Exit For
                        End If
                    Next

                    'Neu truong day la Blob thi download ve xong xet
                    If v_strDataType.Equals("B") Then
                        Dim byteData As System.Byte() = v_ws.DownloadFile(v_strFLDNAME, KeyFieldName, KeyFieldValue, TableName)
                        SetControlValue(Me, v_strFLDNAME, v_strFieldType, IIf(byteData IsNot Nothing, byteData, ""), v_strDataType)
                    Else

                        SetControlValue(Me, v_strFLDNAME, v_strFieldType, v_strValue, v_strDataType)
                    End If

                    If Me.ExeFlag = ExecuteFlag.Edit Then
                        If Me.IsRiskManagement Then
                            SetRiskField(Me, v_strFLDNAME, v_strFieldType, v_blnRiskFld)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error! v_strObjMsg.:" & v_strObjMsg & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()

        'If (SaveButtonType = SaveButtonType.OKButton) Then
        '    Me.DialogResult = DialogResult.OK
        'Else
        '    Me.DialogResult = DialogResult.Cancel
        'End If


        'Kiem tra du lieu thay doi thi can confirm khi dong form
        Dim v_dr As DataRow
        Dim v_dc As DataColumn
        Dim v_ctrl As Windows.Forms.Control
        Try

            Me.Close()

        Catch ex As Exception
            LogError.Write("Error source: " & ModuleCode & "." & ObjectName & ".DoDataExchange" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & IIf(v_ctrl.Name Is Nothing, ".", v_ctrl.Name & ".") & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try

    End Sub
    Public Sub DoFillReturnValue(ByVal v_strGLGRP As String, ByVal v_strModCode As String, ByVal v_ctrlAccountEntries As System.Windows.Forms.ListView, Optional ByRef v_strCurrency As String = "")
        Dim v_strObjMsg, v_strCurrencyTem As String
        Dim v_strCmdInquiry As String
        Try
            v_strCurrencyTem = v_strCurrency
            v_strCmdInquiry = "SELECT ACNAME ,ACCTNO FROM GLREF WHERE APPTYPE='" & v_strModCode & "' AND GLGRP ='" & v_strGLGRP & "' ORDER BY ACNAME "
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry, )
            Dim v_strOldObjMsg As String = v_strObjMsg
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument
            v_xmlDocument.LoadXml(v_strObjMsg)

            'Hien thi header
            v_ctrlAccountEntries.Clear()

            Dim v_ACNAME As New System.Windows.Forms.ColumnHeader
            v_ACNAME.Text = "ACNAME"
            v_ACNAME.Width = 80
            'v_ColReport.Text.
            v_ctrlAccountEntries.Columns.Add(v_ACNAME)

            Dim v_ACCTNO As New System.Windows.Forms.ColumnHeader
            v_ACCTNO.Text = "ACCTNO"
            v_ACCTNO.Width = 120
            v_ctrlAccountEntries.Columns.Add(v_ACCTNO)

            'Hien thi du lieu
            Dim v_ListViewItem As ListViewItem
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strAcc, v_strAccName, v_strTem As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_arrStr(2) As String
            v_ctrlAccountEntries.Items.Clear()
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_ctrlAccountEntries.Items.Clear()
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = vbNullString
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ACNAME"
                                v_strAccName = v_strValue
                            Case "ACCTNO"
                                v_strAcc = v_strValue
                                If i = 0 Then
                                    v_strCurrency = Strings.Mid(v_strAcc, 5, 2)
                                End If
                            Case Else
                        End Select
                    End With
                Next

                'Fill du lieu vao grid
                If v_strCurrencyTem <> "" Then
                    If Strings.Mid(v_strAcc, 5, 2) = v_strCurrencyTem Then
                        v_arrStr(0) = v_strAccName
                        v_arrStr(1) = v_strAcc
                        v_ListViewItem = New ListViewItem(v_arrStr)
                        v_ctrlAccountEntries.Items.Add(v_ListViewItem)
                    End If
                Else
                    v_arrStr(0) = v_strAccName
                    v_arrStr(1) = v_strAcc
                    v_ListViewItem = New ListViewItem(v_arrStr)
                    v_ctrlAccountEntries.Items.Add(v_ListViewItem)
                End If
            Next
            v_strCurrency = v_strAcc
        Catch ex As Exception
            v_ctrlAccountEntries.Visible = True
        End Try
    End Sub

    Public Overridable Sub OnInit()
        If (DesignMode) Then
            Return
        End If
        'Set click event for buttons
        AddHandler btnOK.Click, AddressOf Button_Click
        AddHandler btnApply.Click, AddressOf Button_Click
        AddHandler btnCancel.Click, AddressOf Button_Click
        AddHandler btnApprv.Click, AddressOf Button_Click
        AddHandler btnCompare.Click, AddressOf Button_Click

        LoadObjectFields()
        LoadObjectFieldValidateRules()
        FormatObjectFields(Me)
        InitForm()
        LoadLink()
        If Not cboLink.Properties.DataSource Is Nothing Then
            If CType(cboLink.Properties.DataSource, IListSource).GetList().Count = 0 Then
                cboLink.Visible = False
            End If
        End If
        btnApply.Visible = False
        btnCompare.Visible = False

        'mv_dsControlType = New DataSet
        'PrepareDataSet_ControlType(mv_dsControlType, True, Me)
        SetLookUpDataForm()
        If ExeFlag <> ExecuteFlag.AddNew Then
            DoDataExchange()
        End If
        If ExeFlag = ExecuteFlag.Approve Then
            btnOK.Visible = False
        End If

    End Sub

    Public Overridable Sub OnSave()
        PrepareDataSet(mv_dsInput)
    End Sub

    'AnhVT Added - Maintenance Approval Retro
    Public Overridable Sub OnApprv()
        'Sua cho duyet hop dong di luong rieng
        Dim v_frm As New frmXtraApprove
        v_frm.ExeFlag = ExeFlag
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ObjectName = ModuleCode + "." + CHILDTABLE
        v_frm.TableName = Mid(ObjectName, 4)
        v_frm.LocalObject = LocalObject
        v_frm.Text = Text
        v_frm.TellerId = TellerId
        v_frm.TellerRight = TellerRight
        v_frm.GroupCareBy = GroupCareBy
        v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        v_frm.KeyFieldName = KeyFieldName
        v_frm.KeyFieldType = KeyFieldType
        v_frm.KeyFieldValue = KeyFieldValue
        v_frm.Objlogid = Objlogid
        v_frm.LinkField = LinkField
        v_frm.IsReject = IsReject
        v_frm.LinkValue = LinkValue
        v_frm.ShowDialog()
        Me.DialogResult = DialogResult.OK
    End Sub
    Public Overridable Sub OnCompare()
        'Sua rieng cho cfmast
    End Sub

    Public Overridable Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Dim v_dr As DataRow
        Dim v_dc As DataColumn
        Dim v_ctrl As Windows.Forms.Control

        Try
            If pv_blnSaved Then
                v_dr = mv_dsInput.Tables(0).NewRow()
                GetControlValue(v_dr, mv_dsInput, Me)
                mv_dsInput.Tables(0).Rows.Add(v_dr)
                GetDataSetHasDataByte(v_dr)
            Else
                FillData()
                PrepareDataSet(mv_dsOldInput)

                v_dr = mv_dsOldInput.Tables(0).NewRow()
                GetControlValue(v_dr, mv_dsOldInput, Me)
                mv_dsOldInput.Tables(0).Rows.Add(v_dr)
            End If

            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ModuleCode & "." & ObjectName & ".DoDataExchange" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & IIf(v_ctrl.Name Is Nothing, ".", v_ctrl.Name & ".") & ex.Message, EventLogEntryType.Error)
            Throw ex
            Return False
        End Try
    End Function

    Public Sub GetDataSetHasDataByte(ByRef dr As DataRow)

        If (mv_dsTypeBytes Is Nothing) Then
            mv_dsTypeBytes = New DataSet()
            mv_dsTypeBytes.Tables.Add(dr.Table.Clone())
        End If

        If (dr IsNot Nothing AndAlso dr.Table.Columns.Count > 0) Then
            For Each r As DataColumn In dr.Table.Columns
                If (r.DataType Is GetType(System.Byte())) Then
                    mv_dsTypeBytes.Tables(0).Rows.Add(dr.ItemArray)
                    dr(r.ColumnName) = Nothing
                End If
            Next
        End If

    End Sub

    Public Overridable Function OnShowRiskView() As Boolean
        Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)

        'Search:::LoadUserInterface _tiennv
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strControlTag, v_strControlType As String, v_cboEX As ComboBoxEx
        Try
            pv_ctrl.BackColor = System.Drawing.SystemColors.Control
            'Enable/disable OK, Apply buttons            

            'AnhVT Added - Maintenance Approval Retro
            btnOK.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            'btnApply.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            btnOK.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            'btnApply.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            btnApply.Visible = False
            btnApprv.Enabled = (ExeFlag = ExecuteFlag.Approve)
            btnApprv.Visible = (ExeFlag = ExecuteFlag.Approve)
            'AnhVT Ended

            Dim controls As System.Collections.Generic.IEnumerable(Of Control) = FormControlUtil.GetAllHasTag(pv_ctrl)
            If (controls Is Nothing Or controls.Count = 0) Then
                Return
            End If

            For Each v_ctrl In controls
                If Not v_ctrl.Tag Is Nothing Then
                    v_strControlTag = v_ctrl.Tag.ToString
                    If v_strControlTag.Trim.Length > 0 Then
                        If TypeOf (v_ctrl) Is Label Or TypeOf (v_ctrl) Is LabelControl Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Button Or TypeOf (v_ctrl) Is SimpleButton Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Panel Then
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabControl Then
                            For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, TabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is XtraTabControl Then
                            For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, XtraTabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabPage Then
                            v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            'LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is XtraTabPage Then
                            CType(v_ctrl, XtraTabPage).Text = ResourceManager.GetString(v_strControlTag)
                            'LoadUserInterface(v_ctrl)
                            'TheNN add: Load text label for checkbox control                            
                            'ElseIf TypeOf (v_ctrl) Is TableLayoutPanel Then
                            '    LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is CheckBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            'TheNN ended. 09-Jan-2012
                        ElseIf TypeOf (v_ctrl) Is CheckEdit Then
                            CType(v_ctrl, CheckEdit).Text = ResourceManager.GetString(v_strControlTag)
                            'ElseIf TypeOf (v_ctrl) Is PanelControl Then
                            '    LoadUserInterface(v_ctrl)
                        End If
                    End If
                End If

                Try
                    Dim v_intIndex As Integer
                    Dim v_intCount As Integer = mv_arrObjFields.GetLength(0)
                    Dim v_ctrlt As Windows.Forms.Control
                    If v_intCount > 0 Then
                        For v_intIndex = 0 To v_intCount - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                For Each v_ctrlt In controls
                                    If Not v_ctrlt.Tag Is Nothing Then
                                        v_strControlTag = v_ctrlt.Tag.ToString
                                        If v_strControlTag.Trim.Length > 0 And v_strControlTag = mv_arrObjFields(v_intIndex).FieldName Then
                                            If TypeOf (v_ctrlt) Is Label Or TypeOf (v_ctrlt) Is LabelControl Then
                                                v_ctrlt.Visible = mv_arrObjFields(v_intIndex).Visible
                                                If ResourceManager.GetString(v_strControlTag) Is Nothing Then
                                                    v_ctrlt.Text = mv_arrObjFields(v_intIndex).Caption
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Catch ex As Exception

                End Try

                'Set default value for Addnew
                If ExeFlag = ExecuteFlag.AddNew Then
                    If TypeOf (v_ctrl) Is ComboBoxEx Then
                        v_cboEX = CType(v_ctrl, ComboBoxEx)
                        If v_cboEX.Items.Count > 0 AndAlso v_cboEX.SelectedIndex = -1 Then
                            v_cboEX.SelectedIndex = 0
                        End If
                    ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                        CType(v_ctrl, DateTimePicker).Value = gf_Cdate(Me.BusDate)
                    ElseIf TypeOf (v_ctrl) Is DateEdit AndAlso CType(v_ctrl, DateEdit).EditValue = Nothing Then
                        CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Me.BusDate)
                    ElseIf TypeOf (v_ctrl) Is LookUpEdit AndAlso CType(v_ctrl, LookUpEdit).EditValue = Nothing Then
                        If Not CType(v_ctrl, LookUpEdit).Properties.DataSource Is Nothing Then
                            If CType(CType(v_ctrl, LookUpEdit).Properties.DataSource, IListSource).GetList().Count > 0 Then
                                CType(v_ctrl, LookUpEdit).ItemIndex = 0
                            End If
                        End If
                    End If
                End If
            Next
            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag & ExeFlag.ToString())
        Catch ex As Exception
            Throw ex
        End Try

        'old
        'Dim v_ctrl As Windows.Forms.Control
        'Dim v_strControlTag, v_strControlType As String, v_cboEX As ComboBoxEx
        'Try
        '    pv_ctrl.BackColor = System.Drawing.SystemColors.Control
        '    'Enable/disable OK, Apply buttons            

        '    'AnhVT Added - Maintenance Approval Retro
        '    btnOK.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
        '    'btnApply.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
        '    btnOK.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
        '    'btnApply.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
        '    btnApply.Visible = False
        '    btnApprv.Enabled = (ExeFlag = ExecuteFlag.Approve)
        '    btnApprv.Visible = (ExeFlag = ExecuteFlag.Approve)
        '    'AnhVT Ended
        '    For Each v_ctrl In pv_ctrl.Controls
        '        If Not v_ctrl.Tag Is Nothing Then
        '            v_strControlTag = v_ctrl.Tag.ToString
        '            If v_strControlTag.Trim.Length > 0 Then
        '                If TypeOf (v_ctrl) Is Label Or TypeOf (v_ctrl) Is LabelControl Then
        '                    v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
        '                ElseIf TypeOf (v_ctrl) Is Button Or TypeOf (v_ctrl) Is SimpleButton Then
        '                    v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
        '                ElseIf TypeOf (v_ctrl) Is Panel Then
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is SplitContainer Then
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
        '                    v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is TabControl Then
        '                    For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, TabControl).TabPages
        '                        v_strControlTag = v_ctrlTmp.Tag
        '                        v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
        '                    Next
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is XtraTabControl Then
        '                    For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, XtraTabControl).TabPages
        '                        v_strControlTag = v_ctrlTmp.Tag
        '                        v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
        '                    Next
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is TabPage Then
        '                    v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        '                    v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is XtraTabPage Then
        '                    CType(v_ctrl, XtraTabPage).Text = ResourceManager.GetString(v_strControlTag)
        '                    LoadUserInterface(v_ctrl)
        '                    'TheNN add: Load text label for checkbox control                            
        '                ElseIf TypeOf (v_ctrl) Is TableLayoutPanel Then
        '                    LoadUserInterface(v_ctrl)
        '                ElseIf TypeOf (v_ctrl) Is CheckBox Then
        '                    v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
        '                    'TheNN ended. 09-Jan-2012
        '                ElseIf TypeOf (v_ctrl) Is CheckEdit Then
        '                    CType(v_ctrl, CheckEdit).Text = ResourceManager.GetString(v_strControlTag)
        '                ElseIf TypeOf (v_ctrl) Is PanelControl Then
        '                    LoadUserInterface(v_ctrl)
        '                End If
        '            End If
        '        End If
        '        'Set default value for Addnew
        '        If ExeFlag = ExecuteFlag.AddNew Then
        '            If TypeOf (v_ctrl) Is ComboBoxEx Then
        '                v_cboEX = CType(v_ctrl, ComboBoxEx)
        '                If v_cboEX.Items.Count > 0 Then
        '                    v_cboEX.SelectedIndex = 0
        '                End If
        '            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
        '                CType(v_ctrl, DateTimePicker).Value = gf_Cdate(Me.BusDate)
        '            ElseIf TypeOf (v_ctrl) Is DateEdit Then
        '                CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Me.BusDate)
        '            ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
        '                If Not CType(v_ctrl, LookUpEdit).Properties.DataSource Is Nothing Then
        '                    If CType(CType(v_ctrl, LookUpEdit).Properties.DataSource, IListSource).GetList().Count > 0 Then
        '                        CType(v_ctrl, LookUpEdit).ItemIndex = 0
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        '    'Load caption của form, label caption
        '    If (Me.Text.Trim() = String.Empty) Then
        '        Me.Text = ResourceManager.GetString(Me.Name)
        '    End If
        '    lblCaption.Text = ResourceManager.GetString(lblCaption.Tag & ExeFlag.ToString())
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Public Overridable Function GetIPAddress() As String
        Try
            Dim sHostName As String = System.Net.Dns.GetHostName()
            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(sHostName)
            Dim IpA() As System.Net.IPAddress = ipE.AddressList
            Dim sAddr As String

            sAddr = IpA(0).ToString

            Return sAddr
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Properties "
    Public Property IsReject() As Boolean
        Get
            Return mv_blnIsReject
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsReject = Value
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

    Public Property Objlogid() As String
        Get
            Return mv_strObjlogid
        End Get
        Set(ByVal Value As String)
            mv_strObjlogid = Value
        End Set
    End Property

    Public Property CHILDTABLE() As String
        Get
            Return mv_strChildTable
        End Get
        Set(ByVal Value As String)
            mv_strChildTable = Value
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
    'AnhVT Ended
    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkField() As String
        Get
            Return mv_strLinkField
        End Get
        Set(ByVal Value As String)
            mv_strLinkField = Value
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

    Public Property IsRiskManagement() As Boolean
        Get
            Return mv_blnIsRiskManagement
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsRiskManagement = Value
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

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
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

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return mv_strKeyField
        End Get
        Set(ByVal Value As String)
            mv_strKeyField = Value
        End Set
    End Property

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyType
        End Get
        Set(ByVal Value As String)
            mv_strKeyType = Value
        End Set
    End Property

    Public Property KeyFieldValue() As String
        Get
            Return mv_strKeyValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyValue = Replace(Value, ".", "")
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

    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
        End Set
    End Property

    Public ReadOnly Property SaveButtonType() As SaveButtonType
        Get
            Return mv_saveButtonType
        End Get
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

    Public Property ParentValue() As String
        Get
            Return mv_strParentValue
        End Get
        Set(ByVal Value As String)
            mv_strParentValue = Value
        End Set
    End Property
#End Region

#Region " Protected Functions "
    Protected Sub SetControlValue(ByRef pv_ctrl As Windows.Forms.Control, _
                                ByVal pv_strFLDNAME As String, _
                                ByVal pv_strFLDTYPE As String, _
                                ByVal pv_strFLDVAL As Object, ByVal pv_strDATATYPE As String)

        'Search:::SetControlValue _tiennv
        Dim controls As System.Collections.Generic.IEnumerable(Of Control) = FormControlUtil.GetAllHasTag(pv_ctrl)
        If (controls Is Nothing Or controls.Count = 0) Then
            Return
        End If

        Dim v_ctrl As Windows.Forms.Control
        Dim v_arrLst() As String
        Try
            For Each v_ctrl In controls
                If Trim(pv_strFLDNAME) = "NUMBERREMIND" Then        'trung.luu: 14-05-2021 xử lý control NumericUpDown
                    If TypeOf (v_ctrl) Is NumericUpDown And (TypeOf (v_ctrl) Is LabelControl) = False Then
                        'CType(v_ctrl, NumericUpDown).Value = (CType(pv_strFLDVAL, NumericUpDown)).Value
                        CType(v_ctrl, NumericUpDown).Value = pv_strFLDVAL
                        Exit For
                    End If
                End If
                If pv_strFLDNAME = "REMINDTIME" Then                'trung.luu: 14-05-2021 xử lý control TimeEdit
                    If TypeOf (v_ctrl) Is TimeEdit Then
                        CType(v_ctrl, TimeEdit).EditValue = pv_strFLDVAL
                        Exit For
                    End If
                End If
                If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, FlexMaskEditBox).Text = Trim(pv_strFLDVAL)
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is ButtonEditCustom Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME) And pv_strFLDTYPE = "T") Then
                        CType(v_ctrl, ButtonEditCustom).SetValue(pv_strFLDVAL)
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T" Or pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, TextBox).Text = Trim(pv_strFLDVAL)
                        If (pv_strDATATYPE = "N") Then
                            FormatNumericTextbox(CType(v_ctrl, TextBox))
                        End If
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T") Then
                        CType(v_ctrl, RichTextBox).Text = Trim(pv_strFLDVAL)
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
                            CType(v_ctrl, DateTimePicker).Checked = True
                            CType(v_ctrl, DateTimePicker).Value = gf_Cdate(Trim(pv_strFLDVAL))
                        Else
                            CType(v_ctrl, DateTimePicker).Value = gf_Cdate(gc_NULL_DATE)
                            CType(v_ctrl, DateTimePicker).Checked = False
                        End If
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is DateEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
                            CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Trim(pv_strFLDVAL))
                        Else
                            CType(v_ctrl, DateEdit).EditValue = Nothing
                        End If
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, ComboBoxEx).SelectedValue = Trim(pv_strFLDVAL)
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        'CType(v_ctrl, LookUpEdit).EditValue = Trim(pv_strFLDVAL)
                        SetLookUpEditDefaultValue(CType(v_ctrl, LookUpEdit), pv_strFLDVAL)
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is PictureBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, PictureBox).Image = GetImageFromString(pv_strFLDVAL)
                        CType(v_ctrl, PictureBox).SizeMode = PictureBoxSizeMode.CenterImage
                        CType(v_ctrl, PictureBox).BorderStyle = BorderStyle.Fixed3D
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is CheckedListBox And v_ctrl.Tag <> "" Then
                    Dim v_arrCdval(), v_arrCdName() As String
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                        v_arrLst = pv_strFLDVAL.Split("|")
                        Dim v_ds As New DataSet
                        Dim v_strObjMsg As String
                        Dim v_SQL As String
                        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
                        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
                        Dim v_strValue, v_strFLDNAME As String
                        Dim i, j, k, l As Integer
                        For i = 0 To UBound(mv_arrObjFields) - 1
                            If (v_ctrl.Tag = mv_arrObjFields(i).FieldName) Then
                                v_SQL = mv_arrObjFields(i).LookupList
                                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_SQL)
                                v_ws.Message(v_strObjMsg)

                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                ReDim v_arrCdName(v_nodeList.Count - 1), v_arrCdval(v_nodeList.Count - 1)
                                For j = 0 To v_nodeList.Count - 1
                                    For k = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                        With v_nodeList.Item(j).ChildNodes(k)
                                            v_strValue = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "VALUECD"
                                                    v_arrCdval(j) = Trim(v_strValue)
                                                Case "DISPLAY"
                                                    v_arrCdName(j) = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                Next

                                'So sanh list gia tri voi list value va checkbox
                                For j = 0 To v_arrLst.Length - 1
                                    For k = 0 To v_arrCdval.Length - 1
                                        If v_arrLst(j) = v_arrCdval(k) Then
                                            If UCase(v_arrCdName(k)) = "ALL" Then
                                                CType(v_ctrl, CheckedListBox).SetSelected(0, True)
                                                CType(v_ctrl, CheckedListBox).SetItemChecked(0, True)
                                            Else
                                                For l = 1 To CType(v_ctrl, CheckedListBox).Items.Count - 1
                                                    If v_arrLst(j) = v_arrCdval(k) And v_arrCdName(k) = CType(v_ctrl, CheckedListBox).Items(l).ToString Then
                                                        CType(v_ctrl, CheckedListBox).SetItemChecked(l, True)
                                                    End If
                                                Next
                                            End If

                                        End If
                                    Next
                                Next
                            End If
                        Next
                    End If
                ElseIf TypeOf (v_ctrl) Is TextEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T" Or pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, TextEdit).Text = Trim(pv_strFLDVAL)
                        Exit For
                    End If
                    If TypeName(v_ctrl) = "LookUpEdit" And (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        'CType(v_ctrl, LookUpEdit).EditValue = Trim(pv_strFLDVAL)
                        SetLookUpEditDefaultValue(CType(v_ctrl, LookUpEdit), pv_strFLDVAL)
                        Exit For
                    End If
                    If (TypeName(v_ctrl) = "DateEdit") And (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
                            'CType(v_ctrl, DateEdit).Checked = True
                            CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Trim(pv_strFLDVAL))
                        Else
                            CType(v_ctrl, DateEdit).EditValue = gf_Cdate(gc_NULL_DATE)
                            'CType(v_ctrl, DateEdit).Checked = False
                        End If
                        Exit For
                    End If
                    'ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                    '    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                    'ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
                    '    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                    'ElseIf TypeOf (v_ctrl) Is TabPage Then
                    '    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                    'ElseIf TypeOf (v_ctrl) Is XtraTabPage Then
                    '    CType(v_ctrl, XtraTabPage).Show()
                    '    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                    'ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
                    '    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

        'Old
        'Dim v_ctrl As Windows.Forms.Control
        'Dim v_arrLst() As String
        'Try
        '    For Each v_ctrl In pv_ctrl.Controls
        '        If TypeOf (v_ctrl) Is FlexMaskEditBox Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "M") Then
        '                CType(v_ctrl, FlexMaskEditBox).Text = Trim(pv_strFLDVAL)
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is TextBox Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T" Or pv_strFLDTYPE = "M") Then
        '                CType(v_ctrl, TextBox).Text = Trim(pv_strFLDVAL)
        '                If (pv_strDATATYPE = "N") Then
        '                    FormatNumericTextbox(CType(v_ctrl, TextBox))
        '                End If
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
        '                If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
        '                    CType(v_ctrl, DateTimePicker).Checked = True
        '                    CType(v_ctrl, DateTimePicker).Value = gf_Cdate(Trim(pv_strFLDVAL))
        '                Else
        '                    CType(v_ctrl, DateTimePicker).Value = gf_Cdate(gc_NULL_DATE)
        '                    CType(v_ctrl, DateTimePicker).Checked = False
        '                End If
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is DateEdit Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
        '                If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
        '                    'CType(v_ctrl, DateEdit).Checked = True
        '                    CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Trim(pv_strFLDVAL))
        '                Else
        '                    CType(v_ctrl, DateEdit).EditValue = gf_Cdate(gc_NULL_DATE)
        '                    'CType(v_ctrl, DateEdit).Checked = False
        '                End If
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
        '                CType(v_ctrl, ComboBoxEx).SelectedValue = Trim(pv_strFLDVAL)
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
        '                'CType(v_ctrl, LookUpEdit).EditValue = Trim(pv_strFLDVAL)
        '                SetLookUpEditDefaultValue(CType(v_ctrl, LookUpEdit), pv_strFLDVAL)
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is PictureBox Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
        '                CType(v_ctrl, PictureBox).Image = GetImageFromString(pv_strFLDVAL)
        '                CType(v_ctrl, PictureBox).SizeMode = PictureBoxSizeMode.CenterImage
        '                CType(v_ctrl, PictureBox).BorderStyle = BorderStyle.Fixed3D
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is CheckedListBox And v_ctrl.Tag <> "" Then
        '            Dim v_arrCdval(), v_arrCdName() As String
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
        '                v_arrLst = pv_strFLDVAL.Split("|")
        '                Dim v_ds As New DataSet
        '                Dim v_strObjMsg As String
        '                Dim v_SQL As String
        '                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        '                Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
        '                Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        '                Dim v_strValue, v_strFLDNAME As String
        '                Dim i, j, k, l As Integer
        '                For i = 0 To UBound(mv_arrObjFields) - 1
        '                    If (v_ctrl.Tag = mv_arrObjFields(i).FieldName) Then
        '                        v_SQL = mv_arrObjFields(i).LookupList
        '                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_SQL)
        '                        v_ws.Message(v_strObjMsg)

        '                        v_xmlDocument.LoadXml(v_strObjMsg)
        '                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        '                        ReDim v_arrCdName(v_nodeList.Count - 1), v_arrCdval(v_nodeList.Count - 1)
        '                        For j = 0 To v_nodeList.Count - 1
        '                            For k = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
        '                                With v_nodeList.Item(j).ChildNodes(k)
        '                                    v_strValue = .InnerText.ToString
        '                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '                                    Select Case Trim(v_strFLDNAME)
        '                                        Case "VALUECD"
        '                                            v_arrCdval(j) = Trim(v_strValue)
        '                                        Case "DISPLAY"
        '                                            v_arrCdName(j) = Trim(v_strValue)
        '                                    End Select
        '                                End With
        '                            Next
        '                        Next

        '                        'So sanh list gia tri voi list value va checkbox
        '                        For j = 0 To v_arrLst.Length - 1
        '                            For k = 0 To v_arrCdval.Length - 1
        '                                If v_arrLst(j) = v_arrCdval(k) Then
        '                                    If UCase(v_arrCdName(k)) = "ALL" Then
        '                                        CType(v_ctrl, CheckedListBox).SetSelected(0, True)
        '                                        CType(v_ctrl, CheckedListBox).SetItemChecked(0, True)
        '                                    Else
        '                                        For l = 1 To CType(v_ctrl, CheckedListBox).Items.Count - 1
        '                                            If v_arrLst(j) = v_arrCdval(k) And v_arrCdName(k) = CType(v_ctrl, CheckedListBox).Items(l).ToString Then
        '                                                CType(v_ctrl, CheckedListBox).SetItemChecked(l, True)
        '                                            End If
        '                                        Next
        '                                    End If

        '                                End If
        '                            Next
        '                        Next
        '                    End If
        '                Next
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is TextEdit Then
        '            If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T" Or pv_strFLDTYPE = "M") Then
        '                CType(v_ctrl, TextEdit).Text = Trim(pv_strFLDVAL)
        '                Exit For
        '            End If
        '            If TypeName(v_ctrl) = "LookUpEdit" And (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
        '                'CType(v_ctrl, LookUpEdit).EditValue = Trim(pv_strFLDVAL)
        '                SetLookUpEditDefaultValue(CType(v_ctrl, LookUpEdit), pv_strFLDVAL)
        '                Exit For
        '            End If
        '            If (TypeName(v_ctrl) = "DateEdit") And (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
        '                If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
        '                    'CType(v_ctrl, DateEdit).Checked = True
        '                    CType(v_ctrl, DateEdit).EditValue = gf_Cdate(Trim(pv_strFLDVAL))
        '                Else
        '                    CType(v_ctrl, DateEdit).EditValue = gf_Cdate(gc_NULL_DATE)
        '                    'CType(v_ctrl, DateEdit).Checked = False
        '                End If
        '                Exit For
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
        '            SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
        '        ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
        '            SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
        '        ElseIf TypeOf (v_ctrl) Is TabPage Then
        '            SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
        '        ElseIf TypeOf (v_ctrl) Is XtraTabPage Then
        '            CType(v_ctrl, XtraTabPage).Show()
        '            SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
        '        ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
        '            SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
        '        End If
        '    Next
        'Catch ex As Exception
        '    LogError.Write("Error source: " & ex.Source & vbNewLine _
        '                 & "Error code: System error!" & vbNewLine _
        '                 & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End Try
    End Sub

    Protected Sub SetRiskField(ByRef pv_ctrl As Windows.Forms.Control, _
                                ByVal pv_strFLDNAME As String, _
                                ByVal pv_strFLDTYPE As String, _
                                ByVal pv_BlnRickFld As Boolean)
        Dim v_ctrl As Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, FlexMaskEditBox).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T" Or pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, TextBox).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "T") Then
                        CType(v_ctrl, RichTextBox).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        CType(v_ctrl, DateTimePicker).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is DateEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        CType(v_ctrl, DateEdit).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, ComboBoxEx).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, LookUpEdit).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is PictureBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, PictureBox).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is TabPage Or TypeOf (v_ctrl) Is XtraTabPage Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Private Functions "
    Public Function GetInventoryValue(ByVal v_strInvName As String, ByVal v_strInvFormat As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmMaster." & Me.ObjectName & ".GetInventoryValue"
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            Dim v_strObjMsg, v_strClause, v_strAutoID, v_strAutoPrefix, v_strAutoString, v_strFLDNAME, v_strVALUE As String
            Dim v_intStart, v_intStop As Integer
            v_strClause = v_strInvName
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'v_strInvFormat: The inventory format. <$BRID>000000, <$CUSTODYCD>000000, <$fieldname>[000000]. 
            'The auto number must be at the end of inventory string
            v_intStart = v_strInvFormat.IndexOf("[")
            v_intStop = v_strInvFormat.IndexOf("]")
            v_strAutoString = v_strInvFormat.Substring(v_intStart + 1, v_intStop - v_intStart - 1)
            v_strAutoPrefix = v_strInvFormat.Replace("[" & v_strAutoString & "]", String.Empty)

            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
            v_strAutoID = Strings.Right(v_strAutoString.Trim & CStr(v_strAutoID), v_strAutoString.Trim.Length)

            v_strAutoPrefix = v_strAutoPrefix.Replace("<$MBID>", Me.BranchId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$TLID>", Me.TellerId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$BUSDATE>", Me.BusDate)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$CUSTODYCD>", "021C")
            v_strAutoID = v_strAutoPrefix & v_strAutoID
            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & "-" & v_strInvName & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Sub InitForm()
        Dim v_ctrl As Windows.Forms.Control
        If ExeFlag = ExecuteFlag.AddNew And Not (LinkField Is Nothing) Then
            SetControlValue(Me, LinkField, GetFieldType(LinkField), LinkValue, "C")
        End If
    End Sub

    Private Sub LoadLink()
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String, v_strFLDNAME As String, v_strValue As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, v_nodeEntry As Xml.XmlNode
        Dim v_strFKSrc As String, v_strFKDes As String, v_strKey As String
        Dim v_int As Integer

        v_strCmdSQL = "SELECT LINKTABLE VALUE, LINKNAME DISPLAY, LSTODR, FKSRC, FKDES FROM TABLINK WHERE OBJNAME='" & ObjectName & "' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillXtraLookUpEdit(v_strObjMsg, cboLink)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            v_int += 1

            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "VALUE"
                            v_strKey = Trim(v_strValue)
                        Case "FKDES"
                            v_strFKDes = Trim(v_strValue)
                        Case "FKSRC"
                            v_strFKSrc = Trim(v_strValue)
                    End Select

                End With
            Next
            hLinkSrc.Add(v_strKey, v_strFKSrc)
            hLinkDes.Add(v_strKey, v_strFKDes)
        Next i
    End Sub

    Protected Overridable Sub ShowLinkForm()
        Try
            mv_frmSearchScreen.BusDate = Me.BusDate
            mv_frmSearchScreen.NextDate = NextDate
            mv_frmSearchScreen.TableName = CStr(cboLink.EditValue).Substring(CStr(cboLink.EditValue).IndexOf(".") + 1)
            mv_frmSearchScreen.ModuleCode = Me.ModuleCode 'CStr(cboLink.SelectedValue).Substring(0, CStr(cboLink.SelectedValue).IndexOf("."))
            'mv_frmSearchScreen.AuthCode = Me.AuthString & "YNNN" 
            'VanNT, de hien thi button Search
            If ExeFlag <> ExecuteFlag.View Then
                mv_frmSearchScreen.AuthCode = "YYYYYNNN"
            Else
                mv_frmSearchScreen.AuthCode = "NYNNYNNN"
            End If

            mv_frmSearchScreen.AuthString = Me.AuthString
            mv_frmSearchScreen.IsLocalSearch = gc_IsNotLocalMsg
            mv_frmSearchScreen.SearchOnInit = True
            mv_frmSearchScreen.BranchId = Me.BranchId
            mv_frmSearchScreen.TellerId = Me.TellerId
            mv_frmSearchScreen.TellerRight = Me.TellerRight
            mv_frmSearchScreen.EnableSearchFilter = True
            mv_frmSearchScreen.LinkFieldSrc = hLinkSrc(cboLink.EditValue)
            mv_frmSearchScreen.LinkFieldDes = hLinkDes(cboLink.EditValue)
            mv_frmSearchScreen.LinkValue = GetControlValueByName(hLinkSrc(cboLink.EditValue), Me)
            mv_frmSearchScreen.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetFieldType(ByVal pv_strFLDNAME As String) As String
        Try
            Dim v_strDataType As String = String.Empty

            For i As Integer = 0 To mv_arrObjFields.Length - 1
                If (mv_arrObjFields(i).FieldName = pv_strFLDNAME) Then
                    v_strDataType = mv_arrObjFields(i).FieldType
                    Exit For
                End If
            Next

            Return v_strDataType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    REM Them event cho cboLink
    Private Sub cboLink_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowLinkForm()
    End Sub

    Private Sub GetControlValue(ByRef pv_dr As DataRow, _
                                    ByVal pv_ds As DataSet, _
                                    ByVal pv_ctrl As Windows.Forms.Control)

        'Search:::GetControlValue _tiennv
        Dim controls As System.Collections.Generic.IEnumerable(Of Control) = FormControlUtil.GetAllHasTag(pv_ctrl)
        If (controls Is Nothing Or controls.Count = 0) Then
            Return
        End If

        Dim v_dc As DataColumn
        Dim v_ctrl, v_ctrTabPage As Windows.Forms.Control
        Dim v_strFldType, v_strDataType As String
        Dim v_strControlTag, v_strControlData As String
        Try
            For Each v_ctrl In controls
                v_strControlTag = UCase(v_ctrl.Tag)
                Dim objField As CFieldMaster = mv_arrObjFields.FirstOrDefault(Function(x) x IsNot Nothing AndAlso x.FieldName = v_strControlTag)
                If objField Is Nothing Or Not pv_dr.Table.Columns.Contains(v_strControlTag) Then
                    Continue For
                End If

                If (v_strControlTag <> "") And (v_strControlTag <> " ") And (v_strControlTag <> "NULL") Then
                    If (TypeOf (v_ctrl) Is TabControl) Then
                        'For Each v_ctrTabPage In v_ctrl.Controls
                        '    If (TypeOf (v_ctrTabPage) Is TabPage) Then
                        '        GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
                        '    End If
                        'Next
                    ElseIf (TypeOf (v_ctrl) Is XtraTabControl) Then
                        'For Each v_ctrTabPage In v_ctrl.Controls
                        '    If (TypeOf (v_ctrTabPage) Is XtraTabPage) Then
                        '        GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
                        '    End If
                        'Next
                    Else
                        If (TypeOf (v_ctrl) Is ButtonEditCustom) Then
                            pv_dr(v_strControlTag) = (CType(v_ctrl, ButtonEditCustom)).DataByte
                        ElseIf v_strControlTag = "NUMBERREMIND" Then            'trung.luu: 14-05-2021 xử lý control NumericUpDown
                            If (TypeOf (v_ctrl) Is LabelControl) = False Then
                                pv_dr(v_strControlTag) = (CType(v_ctrl, NumericUpDown)).Value
                            End If
                        ElseIf (TypeOf (v_ctrl) Is TextBox) Or (TypeOf (v_ctrl) Is TextEdit) Or (TypeOf (v_ctrl) Is MemoEdit) Or (TypeOf (v_ctrl) Is RichTextBox) Then
                            If TypeName(v_ctrl) = "LookUpEdit" Then
                                For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                    If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                        If mv_arrObjFields(i).DefParam <> "N" Then
                                            pv_dr(v_strControlTag) = Trim(CType(v_ctrl, LookUpEdit).EditValue)
                                        End If
                                        Exit For
                                    End If
                                Next
                            ElseIf TypeName(v_ctrl) = "DateEdit" Then
                                If IsDateValue(Trim(CStr(CType(v_ctrl, DateEdit).EditValue))) Then
                                    pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateEdit).EditValue()))
                                Else
                                    pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
                                End If
                            ElseIf TypeName(v_ctrl) = "TimeEdit" Then           'trung.luu: 14-05-2021 xử lý control TimeEdit
                                pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, TimeEdit).Text()))
                            Else
                                For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                    If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                        v_strFldType = mv_arrObjFields(i).FieldType
                                        v_strDataType = mv_arrObjFields(i).DataType
                                        Exit For
                                    End If
                                Next
                                v_strControlData = v_ctrl.Text.Trim
                                If (v_strFldType = "T") And (v_strDataType = "N") Then
                                    If v_strControlData.Length = 0 Then
                                        pv_dr(v_strControlTag) = "0"
                                    Else
                                        pv_dr(v_strControlTag) = v_strControlData
                                    End If
                                ElseIf (v_strFldType = "T") And (v_strDataType <> "N") Then
                                    pv_dr(v_strControlTag) = v_strControlData
                                ElseIf (v_strFldType = "M") And (v_strDataType = "N") Then
                                    pv_dr(v_strControlTag) = Replace(v_strControlData, ",", "").Trim()
                                ElseIf (v_strFldType = "M") Then
                                    pv_dr(v_strControlTag) = v_strControlData
                                End If
                            End If

                        ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                            v_strControlData = v_ctrl.Text.Trim
                            pv_dr(v_strControlTag) = v_strControlData

                        ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then

                            If IsDateValue(Trim(CStr(CType(v_ctrl, DateTimePicker).Value))) Then
                                pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateTimePicker).Value.ToShortDateString()))
                            Else
                                pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
                            End If

                        ElseIf (TypeOf (v_ctrl) Is DateEdit) Then

                            If IsDateValue(Trim(CStr(CType(v_ctrl, DateEdit).EditValue))) Then
                                pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateEdit).EditValue.ToShortDateString()))
                            Else
                                pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
                            End If

                        ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                    pv_dr(v_strControlTag) = Trim(CType(v_ctrl, ComboBoxEx).SelectedValue)
                                    Exit For
                                End If
                            Next
                        ElseIf (TypeOf (v_ctrl) Is LookUpEdit) Then
                            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                    pv_dr(v_strControlTag) = Trim(CType(v_ctrl, LookUpEdit).EditValue)
                                    Exit For
                                End If
                            Next
                        ElseIf (TypeOf (v_ctrl) Is CheckedListBox) Then
                            Dim v_AllCode As String = ""
                            If CType(v_ctrl, CheckedListBox).CheckedItems.Count = 0 Then
                                v_AllCode = ""
                            Else

                                Dim v_ds As New DataSet
                                Dim v_strObjMsg As String
                                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                                Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
                                Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
                                Dim v_strValue, v_strFLDNAME, v_SQL As String
                                Dim j, k As Integer
                                v_AllCode = ""
                                For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                    If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                        v_SQL = mv_arrObjFields(i).LookupList
                                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_SQL)
                                        v_ws.Message(v_strObjMsg)

                                        v_xmlDocument.LoadXml(v_strObjMsg)
                                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                        Dim v_arrCdName(v_nodeList.Count), v_arrCdval(v_nodeList.Count) As String
                                        For j = 0 To v_nodeList.Count - 1
                                            For k = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                                With v_nodeList.Item(j).ChildNodes(k)
                                                    v_strValue = .InnerText.ToString
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    Select Case Trim(v_strFLDNAME)
                                                        Case "VALUECD"
                                                            v_arrCdval(j) = Trim(v_strValue)
                                                        Case "DISPLAY"
                                                            v_arrCdName(j) = Trim(v_strValue)
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        If CType(v_ctrl, CheckedListBox).GetItemChecked(0) Then
                                            For l As Integer = 0 To v_arrCdval.Length - 1
                                                If UCase(v_arrCdName(l)) = "ALL" Then
                                                    v_AllCode = v_arrCdval(l)
                                                End If
                                            Next
                                        Else
                                            For j = 1 To CType(v_ctrl, CheckedListBox).Items.Count - 1
                                                If CType(v_ctrl, CheckedListBox).GetItemChecked(j) Then
                                                    For k = 0 To v_arrCdval.Length - 1
                                                        If CType(v_ctrl, CheckedListBox).Items(j).ToString = v_arrCdName(k) Then
                                                            v_AllCode = v_AllCode & Trim(v_arrCdval(k)) & "|"
                                                        End If
                                                    Next
                                                End If
                                            Next
                                            v_AllCode = Microsoft.VisualBasic.Left(v_AllCode, v_AllCode.Length - 1)
                                        End If
                                    End If
                                Next
                            End If
                            If pv_dr.Table.Columns.Contains(v_strControlTag) Then pv_dr(v_strControlTag) = v_AllCode
                        ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                            pv_dr(v_strControlTag) = GetStringFromImage(CType(v_ctrl, PictureBox))
                        ElseIf (TypeOf (v_ctrl) Is LinkLabelCustom) Then
                            pv_dr(v_strControlTag) = (CType(v_ctrl, LinkLabelCustom)).DataByte

                            'ElseIf (TypeOf (v_ctrl) Is GroupBox) Or (TypeOf (v_ctrl) Is GroupControl) Then
                            '    GetControlValue(pv_dr, pv_ds, v_ctrl)

                            'ElseIf (TypeOf (v_ctrl) Is Panel) Or (TypeOf (v_ctrl) Is PanelControl) Then
                            '    GetControlValue(pv_dr, pv_ds, v_ctrl)
                        End If
                    End If
                End If
            Next

            'Old
            'Dim v_dc As DataColumn
            'Dim v_ctrl, v_ctrTabPage As Windows.Forms.Control
            'Dim v_strFldType, v_strDataType As String
            'Dim v_strControlTag, v_strControlData As String
            'Try
            '    For Each v_ctrl In pv_ctrl.Controls
            '        v_strControlTag = UCase(v_ctrl.Tag)
            '        If (v_strControlTag <> "") And (v_strControlTag <> " ") And (v_strControlTag <> "NULL") Then
            '            If (TypeOf (v_ctrl) Is TabControl) Then
            '                For Each v_ctrTabPage In v_ctrl.Controls
            '                    If (TypeOf (v_ctrTabPage) Is TabPage) Then
            '                        GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
            '                    End If
            '                Next
            '            ElseIf (TypeOf (v_ctrl) Is XtraTabControl) Then
            '                For Each v_ctrTabPage In v_ctrl.Controls
            '                    If (TypeOf (v_ctrTabPage) Is XtraTabPage) Then
            '                        GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
            '                    End If
            '                Next
            '            Else
            '                If (TypeOf (v_ctrl) Is TextBox) Or (TypeOf (v_ctrl) Is TextEdit) Or (TypeOf (v_ctrl) Is MemoEdit) Then
            '                    If TypeName(v_ctrl) = "LookUpEdit" Then
            '                        For i As Integer = 0 To UBound(mv_arrObjFields) - 1
            '                            If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
            '                                If mv_arrObjFields(i).DefParam <> "N" Then
            '                                    pv_dr(v_strControlTag) = Trim(CType(v_ctrl, LookUpEdit).EditValue)
            '                                End If
            '                                Exit For
            '                            End If
            '                        Next
            '                    ElseIf TypeName(v_ctrl) = "DateEdit" Then
            '                        If IsDateValue(Trim(CStr(CType(v_ctrl, DateEdit).EditValue))) Then
            '                            pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateEdit).EditValue.ToShortDateString()))
            '                        Else
            '                            pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
            '                        End If
            '                    Else
            '                        For i As Integer = 0 To UBound(mv_arrObjFields) - 1
            '                            If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
            '                                v_strFldType = mv_arrObjFields(i).FieldType
            '                                v_strDataType = mv_arrObjFields(i).DataType
            '                                Exit For
            '                            End If
            '                        Next
            '                        v_strControlData = v_ctrl.Text.Trim
            '                        If (v_strFldType = "T") And (v_strDataType = "N") Then
            '                            If v_strControlData.Length = 0 Then
            '                                pv_dr(v_strControlTag) = "0"
            '                            Else
            '                                pv_dr(v_strControlTag) = v_strControlData
            '                            End If
            '                        ElseIf (v_strFldType = "T") And (v_strDataType <> "N") Then
            '                            pv_dr(v_strControlTag) = v_strControlData
            '                        ElseIf (v_strFldType = "M") And (v_strDataType = "N") Then
            '                            pv_dr(v_strControlTag) = Replace(v_strControlData, ",", "").Trim()
            '                        ElseIf (v_strFldType = "M") Then
            '                            pv_dr(v_strControlTag) = v_strControlData
            '                        End If
            '                    End If

            '                ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
            '                    v_strControlData = v_ctrl.Text.Trim
            '                    pv_dr(v_strControlTag) = v_strControlData

            '                ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then

            '                    If IsDateValue(Trim(CStr(CType(v_ctrl, DateTimePicker).Value))) Then
            '                        pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateTimePicker).Value.ToShortDateString()))
            '                    Else
            '                        pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
            '                    End If

            '                ElseIf (TypeOf (v_ctrl) Is DateEdit) Then

            '                    If IsDateValue(Trim(CStr(CType(v_ctrl, DateEdit).EditValue))) Then
            '                        pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateEdit).EditValue.ToShortDateString()))
            '                    Else
            '                        pv_dr(v_strControlTag) = gf_Cdate(gc_NULL_DATE)
            '                    End If

            '                ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
            '                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
            '                        If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
            '                            pv_dr(v_strControlTag) = Trim(CType(v_ctrl, ComboBoxEx).SelectedValue)
            '                            Exit For
            '                        End If
            '                    Next
            '                ElseIf (TypeOf (v_ctrl) Is LookUpEdit) Then
            '                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
            '                        If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
            '                            pv_dr(v_strControlTag) = Trim(CType(v_ctrl, LookUpEdit).EditValue)
            '                            Exit For
            '                        End If
            '                    Next
            '                ElseIf (TypeOf (v_ctrl) Is CheckedListBox) Then
            '                    Dim v_AllCode As String = ""
            '                    If CType(v_ctrl, CheckedListBox).CheckedItems.Count = 0 Then
            '                        v_AllCode = ""
            '                    Else

            '                        Dim v_ds As New DataSet
            '                        Dim v_strObjMsg As String
            '                        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            '                        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
            '                        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
            '                        Dim v_strValue, v_strFLDNAME, v_SQL As String
            '                        Dim j, k As Integer
            '                        v_AllCode = ""
            '                        For i As Integer = 0 To UBound(mv_arrObjFields) - 1
            '                            If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
            '                                v_SQL = mv_arrObjFields(i).LookupList
            '                                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_SQL)
            '                                v_ws.Message(v_strObjMsg)

            '                                v_xmlDocument.LoadXml(v_strObjMsg)
            '                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '                                Dim v_arrCdName(v_nodeList.Count), v_arrCdval(v_nodeList.Count) As String
            '                                For j = 0 To v_nodeList.Count - 1
            '                                    For k = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
            '                                        With v_nodeList.Item(j).ChildNodes(k)
            '                                            v_strValue = .InnerText.ToString
            '                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '                                            Select Case Trim(v_strFLDNAME)
            '                                                Case "VALUECD"
            '                                                    v_arrCdval(j) = Trim(v_strValue)
            '                                                Case "DISPLAY"
            '                                                    v_arrCdName(j) = Trim(v_strValue)
            '                                            End Select
            '                                        End With
            '                                    Next
            '                                Next
            '                                If CType(v_ctrl, CheckedListBox).GetItemChecked(0) Then
            '                                    For l As Integer = 0 To v_arrCdval.Length - 1
            '                                        If UCase(v_arrCdName(l)) = "ALL" Then
            '                                            v_AllCode = v_arrCdval(l)
            '                                        End If
            '                                    Next
            '                                Else
            '                                    For j = 1 To CType(v_ctrl, CheckedListBox).Items.Count - 1
            '                                        If CType(v_ctrl, CheckedListBox).GetItemChecked(j) Then
            '                                            For k = 0 To v_arrCdval.Length - 1
            '                                                If CType(v_ctrl, CheckedListBox).Items(j).ToString = v_arrCdName(k) Then
            '                                                    v_AllCode = v_AllCode & Trim(v_arrCdval(k)) & "|"
            '                                                End If
            '                                            Next
            '                                        End If
            '                                    Next
            '                                    v_AllCode = Microsoft.VisualBasic.Left(v_AllCode, v_AllCode.Length - 1)
            '                                End If
            '                            End If
            '                        Next
            '                    End If
            '                    If pv_dr.Table.Columns.Contains(v_strControlTag) Then pv_dr(v_strControlTag) = v_AllCode
            '                ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
            '                    pv_dr(v_strControlTag) = GetStringFromImage(CType(v_ctrl, PictureBox))
            '                ElseIf (TypeOf (v_ctrl) Is LinkLabelCustom) Then
            '                    pv_dr(v_strControlTag) = (CType(v_ctrl, LinkLabelCustom)).DataByte

            '                ElseIf (TypeOf (v_ctrl) Is GroupBox) Or (TypeOf (v_ctrl) Is GroupControl) Then
            '                    GetControlValue(pv_dr, pv_ds, v_ctrl)

            '                ElseIf (TypeOf (v_ctrl) Is Panel) Or (TypeOf (v_ctrl) Is PanelControl) Then
            '                    GetControlValue(pv_dr, pv_ds, v_ctrl)
            '                End If
            '            End If
            '        End If
            '    Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Function GetStringFromImage(ByVal pv_PicBox As PictureBox) As String

        Dim v_mStream As New MemoryStream
        Dim v_Compressed As Byte()
        Dim v_Encoded As Char()
        Dim v_arrMyImage As Byte()
        Dim v_strBuilder As String = String.Empty
        'CType((v_ctrl), PictureBox)()
        If pv_PicBox.Image Is Nothing Then
            Return ""
        Else
            pv_PicBox.Image.Save(v_mStream, pv_PicBox.Image.RawFormat)
            v_arrMyImage = v_mStream.GetBuffer
            v_mStream.Close()
            v_Compressed = CompressionHelper.CompressBytes(v_arrMyImage)
            Dim v_BE As New Base64Encoder(v_Compressed)
            v_Encoded = v_BE.GetEncoded
            v_strBuilder &= v_Encoded
            Return v_strBuilder
        End If
    End Function

    Protected Function GetImageFromString(ByVal pv_strFLDVAL) As System.Drawing.Bitmap
        If pv_strFLDVAL = "" Then
            Return Nothing
        Else
            Dim v_strCompress As String = Trim(pv_strFLDVAL)
            Dim v_Compression As Byte()
            Dim v_Base64Decoder As New Base64Decoder(v_strCompress)
            v_Compression = v_Base64Decoder.GetDecoded()
            Dim v_arrActualSignImage As Byte()
            v_arrActualSignImage = CompressionHelper.DecompressBytes(v_Compression)
            Dim tmpImage As System.Drawing.Bitmap = New System.Drawing.Bitmap(New MemoryStream(v_arrActualSignImage))
            Return tmpImage
        End If
    End Function

    Public Function GetControlValueByName(ByVal pv_strFLDNAME As String, ByVal pv_ctrl As System.Windows.Forms.Control) As String
        Dim v_strReturnValue As String = String.Empty

        Try
            If (Trim(pv_strFLDNAME) <> "") Then
                For Each v_ctrl As System.Windows.Forms.Control In pv_ctrl.Controls
                    If (TypeOf (v_ctrl) Is TabControl) Then
                        For Each v_ctrTabPage As System.Windows.Forms.Control In v_ctrl.Controls
                            If (TypeOf (v_ctrTabPage) Is TabPage) Then
                                v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrTabPage)
                                If (v_strReturnValue <> String.Empty) Then
                                    Exit For
                                End If
                            End If
                        Next
                    ElseIf (TypeOf (v_ctrl) Is XtraTabControl) Then
                        For Each v_ctrTabPage As System.Windows.Forms.Control In v_ctrl.Controls
                            If (TypeOf (v_ctrTabPage) Is XtraTabPage) Then
                                v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrTabPage)
                                If (v_strReturnValue <> String.Empty) Then
                                    Exit For
                                End If
                            End If
                        Next
                    ElseIf (TypeOf (v_ctrl) Is TextEdit) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, TextEdit).Text
                        End If
                    ElseIf (TypeOf (v_ctrl) Is TextBox) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, TextBox).Text
                        End If
                    ElseIf (TypeOf (v_ctrl) Is RichTextBox) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, RichTextBox).Text
                        End If
                    ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, FlexMaskEditBox).Text
                        End If
                    ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            If CType(v_ctrl, DateTimePicker).Checked Then
                                v_strReturnValue = Trim(CStr(CType(v_ctrl, DateTimePicker).Value))
                            Else
                                v_strReturnValue = gf_Cdate(gc_NULL_DATE)
                            End If
                        End If
                    ElseIf (TypeOf (v_ctrl) Is DateEdit) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            If Not CType(v_ctrl, DateEdit).EditValue Is Nothing Then
                                v_strReturnValue = Trim(CStr(CType(v_ctrl, DateEdit).EditValue))
                            Else
                                v_strReturnValue = gf_Cdate(gc_NULL_DATE)
                            End If
                        End If
                    ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, ComboBoxEx).SelectedValue.ToString()
                        End If
                        'ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                        '    If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                        '        v_strReturnValue = CType(v_ctrl, PictureBox).Image.
                        '    End If
                    ElseIf (TypeOf (v_ctrl) Is LookUpEdit) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, LookUpEdit).EditValue.ToString()
                        End If
                    ElseIf (TypeOf (v_ctrl) Is GroupBox) Or (TypeOf (v_ctrl) Is GroupControl) Then
                        v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrl)
                        If (v_strReturnValue <> String.Empty) Then
                            Exit For
                        End If
                    ElseIf (TypeOf (v_ctrl) Is Panel) Or (TypeOf (v_ctrl) Is PanelControl) Then
                        v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrl)
                        If (v_strReturnValue <> String.Empty) Then
                            Exit For
                        End If
                    End If
                    If (v_strReturnValue <> String.Empty) Then
                        Exit For
                    End If
                Next

            End If
            Return v_strReturnValue
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

            Return String.Empty
        End Try
    End Function

    Private Function GetReferenceData(ByVal pv_xmlObjDataRef As String, ByVal pv_strFLDNAME As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlRefDocument As New Xml.XmlDocument
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry)
        v_xmlRefDocument.LoadXml(pv_xmlObjDataRef)
        v_xmlDocument.LoadXml(v_strObjMsg)

        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")
        Dim v_nodeListRef As Xml.XmlNodeList, i, j As Integer, v_strREFNAME As String
        v_nodeListRef = v_xmlRefDocument.SelectNodes("/ObjectMessage/ObjDataRef")
        For i = 0 To v_nodeListRef.Count - 1
            For j = 0 To v_nodeListRef.Item(i).ChildNodes.Count - 1
                With v_nodeListRef.Item(i).ChildNodes(j)
                    v_strREFNAME = CStr(CType(.Attributes.GetNamedItem("refname"), Xml.XmlAttribute).Value)
                    If Trim(v_strREFNAME) = (pv_strFLDNAME) Then
                        'Lấy nội dung của node để xử lý
                        v_entryNode = v_nodeListRef.Item(i).ChildNodes(j)
                        v_dataElement.AppendChild(v_entryNode)
                    End If
                End With
            Next
        Next
        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
        GetReferenceData = v_xmlDocument.InnerXml
    End Function

    Private Sub LoadObjectFields()
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.Name & ".Base.LoadObjectFields", v_strErrorMessage As String

        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strEnCaption, v_strFldType, v_strFldMask, v_strFldFormat, v_strLList, _
            v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strLookupName, v_strSearchCode, v_strSRMODCode, _
            v_blnTagfieldField, v_blnTagListField, v_strDEFPARAM As String
        Dim v_intOdrNum, v_intFldLen As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory, v_blnRiskField As Boolean

        Try
            'Create message to inquiry object fields
            Dim v_strClause As String = "upper(MODCODE) = '" & ModuleCode & "' AND upper(OBJNAME) = '" & ObjectName & "'  ORDER BY ODRNUM"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)

            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            mv_strXMLFldMaster = v_strObjMsg

            Dim v_xmlDocument As New Xml.XmlDocument
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = UCase(Trim(v_strValue))
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                v_strEnCaption = Trim(v_strValue)
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSRMODCode = Trim(v_strValue)
                            Case "RISKFLD"
                                v_blnRiskField = (Trim(v_strValue) = "Y")
                                'phuongntn add tagfield
                            Case "TAGFIELD"
                                v_blnTagfieldField = Trim(v_strValue)
                            Case "TAGLIST"
                                v_blnTagListField = Trim(v_strValue)
                            Case "DEFPARAM"
                                v_strDEFPARAM = Trim(v_strValue)
                        End Select
                    End With
                Next

                Dim v_objField As New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .EnCaption = v_strEnCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    'phuongntn add tagfield, taglist
                    .TagField = v_blnTagfieldField
                    .TagList = v_blnTagListField
                    .DefParam = v_strDEFPARAM
                    'HaiLT them
                    If v_strDefVal.IndexOf("<$SQL>") >= 0 Then
                        'Neu la tham chieu tu cau lenh SQL
                        Dim mv_strXMLFldMasterTmp As String
                        Dim v_nodeListTmp As Xml.XmlNodeList
                        Dim v_xmlDocumentTmp As New Xml.XmlDocument
                        Dim v_strClauseTmp, v_strValueTmp, v_strFLDNAMETmp As String
                        Dim v_strObjMsgTmp As String
                        v_strDefVal = Replace(v_strDefVal, "<$SQL>", "")

                        'Doc thong tin cac truong cua object duoc dung de hien thi
                        v_strObjMsgTmp = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strDefVal, )
                        v_ws.Message(v_strObjMsgTmp)
                        'mv_strXMLFldMasterTmp = v_strObjMsgTmp
                        v_xmlDocumentTmp.LoadXml(v_strObjMsgTmp)
                        v_nodeListTmp = v_xmlDocumentTmp.SelectNodes("/ObjectMessage/ObjData")
                        'ReDim mv_arrObjFields(v_nodeListTmp.Count)
                        For l As Integer = 0 To v_nodeListTmp.Count - 1
                            For m As Integer = 0 To v_nodeListTmp.Item(l).ChildNodes.Count - 1
                                With v_nodeListTmp.Item(l).ChildNodes(m)
                                    v_strValueTmp = .InnerText.ToString
                                    v_strFLDNAMETmp = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                                    Select Case Trim(v_strFLDNAMETmp)
                                        Case "DEFNAME"
                                            v_strDefVal = Trim(v_strValueTmp)
                                    End Select
                                End With
                            Next
                        Next
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        v_strDefVal = BusDate
                    ElseIf v_strDefVal = "<$TELLERID>" Then
                        v_strDefVal = TellerId
                    End If
                    'End of HaiLT them
                    .DefaultValue = v_strDefVal

                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .LookupName = v_strLookupName
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSRMODCode
                    .RiskField = v_blnRiskField
                End With
                mv_arrObjFields(i) = v_objField
            Next

            ReDim Preserve mv_arrObjFields(v_nodeList.Count)
        Catch ex As Exception
            LogError.Write("Error source: " & ModuleCode & "." & ObjectName & ".LoadObjectFields" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & v_strFieldName & v_strDefName & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub LoadObjectFieldValidateRules()
        Dim v_strClause, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_intIndex As Integer
        Dim v_objFieldVal As CFieldVal

        Try
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            'Lấy các luật kiểm tra của các trư?ng giao d�ịch
            'v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG,TAGFIELD,TAGVALUE FROM FLDVAL " & _
            '    "WHERE upper(OBJNAME) = '" & ObjectName & "' ORDER BY VALTYPE, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
            'v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            'v_ws.Message(v_strObjMsg)
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG,TAGFIELD,TAGVALUE, CHKLEV FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & ObjectName & "' ORDER BY VALTYPE, ODRNUM" 'Thứ tự order by là quan tr?ng kh ông sửa
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)


            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)

            'Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
            '    v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg, _
            '    v_strFieldVal_TagField, v_strFieldVal_TagValue As String

            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg, _
                v_strFieldVal_TagField, v_strFieldVal_TagValue, v_strFieldVal_ChkLev As String

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa form
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldVal_FldName = Trim(v_strValue)
                            Case "VALTYPE"
                                v_strFieldVal_ValType = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strFieldVal_Operator = Trim(v_strValue)
                            Case "VALEXP"
                                v_strFieldVal_ValExp = Trim(v_strValue)
                            Case "VALEXP2"
                                v_strFieldVal_ValExp2 = Trim(v_strValue)
                            Case "ERRMSG"
                                v_strFieldVal_ErrMsg = Trim(v_strValue)
                            Case "EN_ERRMSG"
                                v_strFieldVal_EnErrMsg = Trim(v_strValue)
                            Case "CHKLEV"
                                v_strFieldVal_ChkLev = Trim(v_strValue)
                            Case "TAGFIELD"
                                v_strFieldVal_TagField = Trim(v_strValue)
                            Case "TAGVALUE"
                                v_strFieldVal_TagValue = Trim(v_strValue)
                        End Select
                    End With
                Next

                'Xác định index của mảng FldMaster
                For j As Integer = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                            Exit For
                        End If
                    End If
                Next

                '?i�?u ki�ện xử lý
                v_objFieldVal = New CFieldVal

                With v_objFieldVal
                    .OBJNAME = ObjectName
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .CHKLEV = v_strFieldVal_ChkLev
                    .IDXFLD = v_intIndex
                    .TAGFIELD = v_strFieldVal_TagField
                    .TAGVALUE = v_strFieldVal_TagValue
                End With
                mv_arrObjFldVals(i) = v_objFieldVal


            Next

            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Function VerifyRules() As Boolean
        'Dim v_intIndex As Integer
        Dim v_strFLDVALUE, v_strVALEXP As String

        Try
            'Verify các trư?ng d�ữ liệu bắt buộc phải nhập và dữ liệu kiểu số
            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                    And (mv_arrObjFields(i).Mandatory) And (mv_arrObjFields(i).Enabled = True) Then
                    v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(i).FieldName, Me).ToString().Trim()

                    If Not (v_strFLDVALUE.Length > 0) Then
                        MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        SetControlFocus(Me, mv_arrObjFields(i).FieldName)
                        Return False
                    End If
                ElseIf (mv_arrObjFields(i).FieldType = "D") And (mv_arrObjFields(i).Mandatory) Then
                    v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(i).FieldName, Me).ToString().Trim()
                    If (Not (v_strFLDVALUE.Length > 0)) Or (v_strFLDVALUE.Trim() = gc_NULL_DATE) Then
                        MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        SetControlFocus(Me, mv_arrObjFields(i).FieldName)
                        Return False
                    End If
                End If

                If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                    And (mv_arrObjFields(i).DataType = "N") Then
                    v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(i).FieldName, Me).ToString().Trim()

                    If v_strFLDVALUE.Length > 0 Then
                        If Not IsNumeric(v_strFLDVALUE) Then
                            MsgBox(Replace(ResourceManager.GetString("NumericDataType"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            SetControlFocus(Me, mv_arrObjFields(i).FieldName)
                            Return False
                        End If
                    End If
                End If
            Next

            'Duyệt mảng dữ liệu danh mục các đi?u ki�ện kiểm tra
            Dim v_intCount As Integer = mv_arrObjFldVals.GetLength(0)
            Dim v_objEval As New Evaluator

            If v_intCount > 0 Then
                For i As Integer = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFldVals(i) Is Nothing Then
                        'Xử lý theo tham số đã cài đặt
                        With mv_arrObjFldVals(i)
                            If (Trim(.TAGFIELD) = "" Or GetControlValueByName(.TAGFIELD, Me) = .TAGVALUE.Trim("@")) Then
                                Select Case GetFieldDataType(.FLDNAME)
                                    Case "N"
                                        'Thực hiện xử lý cho từng phép toán
                                        If .VALTYPE = "E" Then
                                            'Do nothing
                                        ElseIf .VALTYPE = "V" Then
                                            'Lấy dữ liệu của trư?ng c�ần validate
                                            v_strFLDVALUE = GetControlValueByName(.FLDNAME, Me)

                                            If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, b? qua
                                                Select Case .[OPERATOR]
                                                    Case ">>"
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) > v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case ">="
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) >= v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<<"
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) < v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<="
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) <= v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "=="
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) = v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<>"
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (CDbl(v_strFLDVALUE) <> v_objEval.Eval(v_strVALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                End Select
                                            End If
                                        End If
                                    Case "D"
                                        'Th�ực hiện xử lý cho từng phép toán
                                        If .VALTYPE = "E" Then
                                            'Do nothing
                                        ElseIf .VALTYPE = "V" Then
                                            'Lấy dữ liệu của trư?ng c�ần validate
                                            v_strFLDVALUE = GetControlValueByName(.FLDNAME, Me)

                                            If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, b? qua
                                                Select Case .[OPERATOR]
                                                    Case ">>"
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) > BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case ">="
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) >= BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<<"
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) < BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<="
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) <= BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "=="
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) = BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<>"
                                                        If Not (DDMMYYYY_SystemDate(v_strFLDVALUE) <> BuildDATEEXP(.VALEXP)) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                End Select
                                            End If
                                        End If
                                    Case "C"
                                        'PhuongHT add 
                                        'Thực hiện xử lý cho từng phép toán
                                        If .VALTYPE = "E" Then
                                            'Do nothing
                                        ElseIf .VALTYPE = "V" Then
                                            'Lấy dữ liệu của trư?ng c�ần validate
                                            v_strFLDVALUE = GetControlValueByName(.FLDNAME, Me)

                                            If (v_strFLDVALUE.Length > 0) Then      'Chỉ validate khi NSD nhập dữ liệu; ngược lại, b? qua
                                                Select Case .[OPERATOR]
                                                    Case "=="
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (v_strFLDVALUE.Trim() = v_strVALEXP.Trim()) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                    Case "<>"
                                                        v_strVALEXP = BuildAMTEXP(.VALEXP)
                                                        If Not (v_strFLDVALUE.Trim() <> v_strVALEXP.Trim()) Then
                                                            'If Me.UserLanguage = "EN" Then
                                                            '    MsgBox(.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'Else
                                                            '    MsgBox(.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                                            'End If
                                                            'SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                            'Return False
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
                                                                SetControlFocus(Me, mv_arrObjFldVals(i).FLDNAME)
                                                                Return False
                                                            End If

                                                        End If
                                                End Select
                                            End If
                                        End If
                                End Select
                            End If
                        End With
                    End If
                Next
            End If

            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function BuildAMTEXP(ByVal strAMTEXP As String) As String
        Dim v_strEvaluator, v_strElemenent, v_strValue, v_arrTemp() As String

        Try
            v_strEvaluator = vbNullString

            If Mid(strAMTEXP, 1, 1) = "@" Then
                v_strEvaluator = Mid(strAMTEXP, 2)
            Else
                v_arrTemp = strAMTEXP.Split("|")

                For i As Integer = 0 To v_arrTemp.Length - 1
                    v_strElemenent = v_arrTemp(i)

                    Select Case v_strElemenent
                        Case "++", "--", "**", "//", "((", "))"
                            'Operand
                            v_strEvaluator &= Mid(v_strElemenent, 1, 1)
                        Case Else
                            'Operator
                            v_strValue = CDbl(GetControlValueByName(v_strElemenent, Me)).ToString()
                            v_strEvaluator &= v_strValue
                    End Select
                Next
            End If

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub FormatObjectFields(ByRef pv_ctrl As Windows.Forms.Control)

        'Search:::FormatObjectFields _tiennv
        Dim controls As System.Collections.Generic.IEnumerable(Of Control) = FormControlUtil.GetAllHasTag(pv_ctrl)
        If (controls Is Nothing Or controls.Count = 0) Then
            Return
        End If

        Dim v_ctrl As Windows.Forms.Control
        Dim v_strInputMask As String

        Try
            For Each v_ctrl In controls
                If TypeOf (v_ctrl) Is TextBox Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "T") Then
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, TextBox).MaxLength = .FieldLength
                                End If
                                If .DataType = "N" Then
                                    CType(v_ctrl, TextBox).TextAlign = HorizontalAlignment.Right
                                    AddHandler CType(v_ctrl, TextBox).LostFocus, AddressOf NumericTextBox_LostFocus
                                Else
                                    CType(v_ctrl, TextBox).TextAlign = HorizontalAlignment.Left
                                End If
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, TextBox).ReadOnly = True
                                    CType(v_ctrl, TextBox).Enabled = False
                                End If
                                'X�ử lí lookup
                                If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, TextBox).BackColor = System.Drawing.Color.Khaki
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    CType(v_ctrl, TextBox).BackColor = System.Drawing.Color.GreenYellow
                                End If

                                If ((.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve)) Or (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    AddHandler CType(v_ctrl, TextBox).KeyUp, AddressOf TextBox_KeyUp
                                    AddHandler CType(v_ctrl, TextBox).Validating, AddressOf mskData_Validating
                                End If

                                CType(v_ctrl, TextBox).Visible = .Visible
                                CType(v_ctrl, TextBox).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, TextBox).Text = .DefaultValue
                                    Else
                                        CType(v_ctrl, TextBox).Text = String.Empty
                                    End If
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
                                If .InputMask.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
                                End If
                                If .FieldFormat.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
                                End If
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
                                End If
                                If .DataType = "N" Then
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
                                    CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.NUMERIC
                                Else
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
                                    CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.ALFA
                                End If
                                'Xử lí lookup
                                If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.PeachPuff
                                    AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.GreenYellow
                                    AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
                                End If

                                CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = False
                                CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
                                CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
                                    CType(v_ctrl, FlexMaskEditBox).Enabled = False
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If

                        End With

                    Next
                    AddHandler CType(v_ctrl, TextBox).GotFocus, AddressOf TextBox_GotFocus
                ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "C") And (.LookupList.Length > 0) Then
                                'Load from object reference data in object message                               
                                FillXtraLookUpEditRefData(mv_strXMLFldMaster, CType(v_ctrl, LookUpEdit), v_ctrl.Tag)

                                CType(v_ctrl, LookUpEdit).Visible = .Visible
                                CType(v_ctrl, LookUpEdit).Enabled = .Enabled

                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, LookUpEdit).Enabled = False
                                End If
                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, LookUpEdit).EditValue = .DefaultValue
                                    Else
                                        CType(v_ctrl, LookUpEdit).EditValue = String.Empty
                                    End If
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is DateEdit Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "D") Then
                                'If .InputMask.Length > 0 Then

                                'End If
                                If .FieldFormat.Length > 0 Then
                                    With CType(v_ctrl, DateEdit)
                                        .Properties.DisplayFormat.FormatString = mv_arrObjFields(i).FieldFormat
                                        .Properties.DisplayFormat.FormatType = FormatType.DateTime
                                        .Properties.EditFormat.FormatString = mv_arrObjFields(i).FieldFormat
                                        .Properties.EditFormat.FormatType = FormatType.DateTime
                                        .Properties.Mask.EditMask = mv_arrObjFields(i).FieldFormat
                                    End With


                                End If
                                'If .FieldLength > 0 Then

                                'End If
                                CType(v_ctrl, DateEdit).Visible = .Visible
                                CType(v_ctrl, DateEdit).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, DateEdit).Enabled = False
                                End If
                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, DateEdit).EditValue = .DefaultValue
                                    Else
                                        CType(v_ctrl, DateEdit).EditValue = String.Empty
                                    End If
                                End If
                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is TextEdit Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "T") Then
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, TextEdit).Properties.MaxLength = .FieldLength
                                End If

                                If .DataType = "N" Then
                                    CType(v_ctrl, TextEdit).Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                                    CType(v_ctrl, TextEdit).Properties.Mask.EditMask = .FieldFormat
                                    CType(v_ctrl, TextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                                    CType(v_ctrl, TextEdit).Properties.Mask.UseMaskAsDisplayFormat = True
                                    'AddHandler CType(v_ctrl, TextEdit).LostFocus, AddressOf NumericTextBox_LostFocus
                                Else
                                    CType(v_ctrl, TextEdit).Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Near
                                End If

                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, TextEdit).Properties.ReadOnly = True
                                    CType(v_ctrl, TextEdit).Enabled = False
                                End If
                                'X�ử lí lookup
                                If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, TextEdit).BackColor = System.Drawing.Color.Khaki
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    CType(v_ctrl, TextEdit).BackColor = System.Drawing.Color.GreenYellow
                                End If

                                If ((.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve)) Or (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    AddHandler CType(v_ctrl, TextEdit).KeyUp, AddressOf TextBox_KeyUp
                                    AddHandler CType(v_ctrl, TextEdit).Validating, AddressOf mskData_Validating
                                End If

                                CType(v_ctrl, TextEdit).Visible = .Visible
                                CType(v_ctrl, TextEdit).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, TextEdit).Text = .DefaultValue
                                    Else
                                        CType(v_ctrl, TextEdit).Text = String.Empty
                                    End If
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
                                If .InputMask.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
                                End If
                                If .FieldFormat.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
                                End If
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
                                End If
                                If .DataType = "N" Then
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
                                    CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.NUMERIC
                                Else
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
                                    CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.ALFA
                                End If
                                'Xử lí lookup
                                If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.PeachPuff
                                    AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.GreenYellow
                                    AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
                                End If

                                CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = False
                                CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
                                CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
                                    CType(v_ctrl, FlexMaskEditBox).Enabled = False
                                End If

                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, FlexMaskEditBox).Text = .DefaultValue
                                    Else
                                        CType(v_ctrl, FlexMaskEditBox).Text = String.Empty
                                    End If
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If

                        End With

                    Next
                    AddHandler CType(v_ctrl, TextEdit).GotFocus, AddressOf TextBox_GotFocus
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "C") And (.LookupList.Length > 0) Then
                                'Load from object reference data in object message                               
                                FillComboExRefData(mv_strXMLFldMaster, CType(v_ctrl, ComboBoxEx), v_ctrl.Tag)

                                CType(v_ctrl, ComboBoxEx).Visible = .Visible
                                CType(v_ctrl, ComboBoxEx).Enabled = .Enabled

                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, ComboBoxEx).Enabled = False
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
                                If .InputMask.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
                                End If
                                If .FieldFormat.Length > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
                                End If
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
                                End If
                                If .DataType = "N" Then
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
                                Else
                                    CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
                                End If
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
                                    CType(v_ctrl, FlexMaskEditBox).Enabled = False
                                End If
                                CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
                                CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "D") Then
                                'If .InputMask.Length > 0 Then

                                'End If
                                If .FieldFormat.Length > 0 Then
                                    CType(v_ctrl, DateTimePicker).CustomFormat = .FieldFormat
                                End If
                                'If .FieldLength > 0 Then

                                'End If
                                CType(v_ctrl, DateTimePicker).Visible = .Visible
                                CType(v_ctrl, DateTimePicker).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, DateTimePicker).Enabled = False
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                    'ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                    '    FormatObjectFields(v_ctrl)
                    'ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
                    '    FormatObjectFields(v_ctrl)
                    'ElseIf TypeOf (v_ctrl) Is TabPage Or TypeOf (v_ctrl) Is XtraTabPage Then
                    '    FormatObjectFields(v_ctrl)
                    'ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
                    '    FormatObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                        CType(v_ctrl, CheckBox).Enabled = False
                    End If
                ElseIf TypeOf (v_ctrl) Is CheckEdit Then
                    If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                        CType(v_ctrl, CheckEdit).Enabled = False
                    End If
                ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "T") Then
                                If .FieldLength > 0 Then
                                    CType(v_ctrl, RichTextBox).MaxLength = .FieldLength
                                End If
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, RichTextBox).ReadOnly = True
                                    CType(v_ctrl, RichTextBox).Enabled = False
                                End If
                                'X�ử lí lookup
                                If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
                                    CType(v_ctrl, RichTextBox).BackColor = System.Drawing.Color.Khaki
                                    AddHandler CType(v_ctrl, RichTextBox).KeyUp, AddressOf TextBox_KeyUp
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    CType(v_ctrl, RichTextBox).BackColor = System.Drawing.Color.GreenYellow
                                    AddHandler CType(v_ctrl, RichTextBox).KeyUp, AddressOf TextBox_KeyUp
                                End If

                                CType(v_ctrl, RichTextBox).Visible = .Visible
                                CType(v_ctrl, RichTextBox).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.AddNew Then
                                    If (.DefaultValue.Trim.Length > 0) Then
                                        CType(v_ctrl, RichTextBox).Text = .DefaultValue
                                    Else
                                        CType(v_ctrl, RichTextBox).Text = String.Empty
                                    End If
                                End If

                                'Set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With

                    Next
                    AddHandler CType(v_ctrl, RichTextBox).GotFocus, AddressOf rtbData_GotFocus
                End If

                ''QuangVD: disable fields
                'If (mv_strTableName = "CFCONTACT" And ExeFlag = ExecuteFlag.View) Then
                '    If (v_ctrl.Name = "txtCUSTID") Then v_ctrl.Enabled = False
                '    If (v_ctrl.Name = "cboTYPE") Then v_ctrl.Enabled = False
                'End If

                'If (mv_strTableName = "CFRELATION" And ExeFlag = ExecuteFlag.View) Then
                '    If (v_ctrl.Name = "txtCUSTID") Then v_ctrl.Enabled = False
                '    If (v_ctrl.Name = "cboRETYPE") Then v_ctrl.Enabled = False
                'End If
                ''QuangVD: end here

            Next
        Catch ex As Exception
            LogError.Write("Error source: frmMaintenance." & ModuleCode & "." & ObjectName & ".FormatObjectFields" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & IIf(v_ctrl.Name Is Nothing, ".", v_ctrl.Name & ".") & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

        'Old
        'Dim v_ctrl As Windows.Forms.Control
        'Dim v_strInputMask As String

        'Try
        '    For Each v_ctrl In pv_ctrl.Controls
        '        If TypeOf (v_ctrl) Is TextBox Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "T") Then
        '                        If .FieldLength > 0 Then
        '                            CType(v_ctrl, TextBox).MaxLength = .FieldLength
        '                        End If
        '                        If .DataType = "N" Then
        '                            CType(v_ctrl, TextBox).TextAlign = HorizontalAlignment.Right
        '                            AddHandler CType(v_ctrl, TextBox).LostFocus, AddressOf NumericTextBox_LostFocus
        '                        Else
        '                            CType(v_ctrl, TextBox).TextAlign = HorizontalAlignment.Left
        '                        End If
        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, TextBox).ReadOnly = True
        '                            CType(v_ctrl, TextBox).Enabled = False
        '                        End If
        '                        'X�ử lí lookup
        '                        If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, TextBox).BackColor = System.Drawing.Color.Khaki
        '                            AddHandler CType(v_ctrl, TextBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If
        '                        If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
        '                            CType(v_ctrl, TextBox).BackColor = System.Drawing.Color.GreenYellow
        '                            AddHandler CType(v_ctrl, TextBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If

        '                        CType(v_ctrl, TextBox).Visible = .Visible
        '                        CType(v_ctrl, TextBox).Enabled = .Enabled
        '                        If ExeFlag = ExecuteFlag.AddNew Then
        '                            If (.DefaultValue.Trim.Length > 0) Then
        '                                CType(v_ctrl, TextBox).Text = .DefaultValue
        '                            Else
        '                                CType(v_ctrl, TextBox).Text = String.Empty
        '                            End If
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
        '                        If .InputMask.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
        '                        End If
        '                        If .FieldFormat.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
        '                        End If
        '                        If .FieldLength > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
        '                        End If
        '                        If .DataType = "N" Then
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
        '                            CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.NUMERIC
        '                        Else
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
        '                            CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.ALFA
        '                        End If
        '                        'Xử lí lookup
        '                        If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.PeachPuff
        '                            AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If
        '                        If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.GreenYellow
        '                            AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If

        '                        CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = False
        '                        CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
        '                        CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
        '                            CType(v_ctrl, FlexMaskEditBox).Enabled = False
        '                        End If

        '                        If ExeFlag = ExecuteFlag.AddNew Then
        '                            If (.DefaultValue.Trim.Length > 0) Then
        '                                CType(v_ctrl, FlexMaskEditBox).Text = .DefaultValue
        '                            Else
        '                                CType(v_ctrl, FlexMaskEditBox).Text = String.Empty
        '                            End If
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If

        '                End With

        '            Next
        '            AddHandler CType(v_ctrl, TextBox).GotFocus, AddressOf TextBox_GotFocus
        '        ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "C") And (.LookupList.Length > 0) Then
        '                        'Load from object reference data in object message                               
        '                        FillXtraLookUpEditRefData(mv_strXMLFldMaster, CType(v_ctrl, LookUpEdit), v_ctrl.Tag)

        '                        CType(v_ctrl, LookUpEdit).Visible = .Visible
        '                        CType(v_ctrl, LookUpEdit).Enabled = .Enabled

        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, LookUpEdit).Enabled = False
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                End With
        '            Next
        '        ElseIf TypeOf (v_ctrl) Is DateEdit Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "D") Then
        '                        'If .InputMask.Length > 0 Then

        '                        'End If
        '                        If .FieldFormat.Length > 0 Then
        '                            With CType(v_ctrl, DateEdit)
        '                                .Properties.DisplayFormat.FormatString = mv_arrObjFields(i).FieldFormat
        '                                .Properties.DisplayFormat.FormatType = FormatType.DateTime
        '                                .Properties.EditFormat.FormatString = mv_arrObjFields(i).FieldFormat
        '                                .Properties.EditFormat.FormatType = FormatType.DateTime
        '                                .Properties.Mask.EditMask = mv_arrObjFields(i).FieldFormat
        '                            End With


        '                        End If
        '                        'If .FieldLength > 0 Then

        '                        'End If
        '                        CType(v_ctrl, DateEdit).Visible = .Visible
        '                        CType(v_ctrl, DateEdit).Enabled = .Enabled
        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, DateEdit).Enabled = False
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                End With
        '            Next
        '        ElseIf TypeOf (v_ctrl) Is TextEdit Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "T") Then
        '                        If .FieldLength > 0 Then
        '                            CType(v_ctrl, TextEdit).Properties.MaxLength = .FieldLength
        '                        End If

        '                        If .DataType = "N" Then
        '                            CType(v_ctrl, TextEdit).Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far
        '                            CType(v_ctrl, TextEdit).Properties.Mask.EditMask = .FieldFormat
        '                            CType(v_ctrl, TextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '                            CType(v_ctrl, TextEdit).Properties.Mask.UseMaskAsDisplayFormat = True
        '                            'AddHandler CType(v_ctrl, TextEdit).LostFocus, AddressOf NumericTextBox_LostFocus
        '                        Else
        '                            CType(v_ctrl, TextEdit).Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Near
        '                        End If

        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, TextEdit).Properties.ReadOnly = True
        '                            CType(v_ctrl, TextEdit).Enabled = False
        '                        End If
        '                        'X�ử lí lookup
        '                        If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, TextEdit).BackColor = System.Drawing.Color.Khaki
        '                            AddHandler CType(v_ctrl, TextEdit).KeyUp, AddressOf TextBox_KeyUp
        '                        End If
        '                        If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
        '                            CType(v_ctrl, TextEdit).BackColor = System.Drawing.Color.GreenYellow
        '                            AddHandler CType(v_ctrl, TextEdit).KeyUp, AddressOf TextBox_KeyUp
        '                        End If

        '                        CType(v_ctrl, TextEdit).Visible = .Visible
        '                        CType(v_ctrl, TextEdit).Enabled = .Enabled
        '                        If ExeFlag = ExecuteFlag.AddNew Then
        '                            If (.DefaultValue.Trim.Length > 0) Then
        '                                CType(v_ctrl, TextEdit).Text = .DefaultValue
        '                            Else
        '                                CType(v_ctrl, TextEdit).Text = String.Empty
        '                            End If
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
        '                        If .InputMask.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
        '                        End If
        '                        If .FieldFormat.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
        '                        End If
        '                        If .FieldLength > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
        '                        End If
        '                        If .DataType = "N" Then
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
        '                            CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.NUMERIC
        '                        Else
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
        '                            CType(v_ctrl, FlexMaskEditBox).FieldType = FlexMaskEditBox._FieldType.ALFA
        '                        End If
        '                        'Xử lí lookup
        '                        If (.LookUp = "Y") And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.PeachPuff
        '                            AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If
        '                        If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
        '                            CType(v_ctrl, FlexMaskEditBox).BackColor = System.Drawing.Color.GreenYellow
        '                            AddHandler CType(v_ctrl, FlexMaskEditBox).KeyUp, AddressOf TextBox_KeyUp
        '                        End If

        '                        CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = False
        '                        CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
        '                        CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
        '                            CType(v_ctrl, FlexMaskEditBox).Enabled = False
        '                        End If

        '                        If ExeFlag = ExecuteFlag.AddNew Then
        '                            If (.DefaultValue.Trim.Length > 0) Then
        '                                CType(v_ctrl, FlexMaskEditBox).Text = .DefaultValue
        '                            Else
        '                                CType(v_ctrl, FlexMaskEditBox).Text = String.Empty
        '                            End If
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If

        '                End With

        '            Next
        '            AddHandler CType(v_ctrl, TextEdit).GotFocus, AddressOf TextBox_GotFocus
        '        ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "C") And (.LookupList.Length > 0) Then
        '                        'Load from object reference data in object message                               
        '                        FillComboExRefData(mv_strXMLFldMaster, CType(v_ctrl, ComboBoxEx), v_ctrl.Tag)

        '                        CType(v_ctrl, ComboBoxEx).Visible = .Visible
        '                        CType(v_ctrl, ComboBoxEx).Enabled = .Enabled

        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, ComboBoxEx).Enabled = False
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                End With
        '            Next
        '        ElseIf TypeOf (v_ctrl) Is FlexMaskEditBox Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "M") Then
        '                        If .InputMask.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).Mask = .InputMask
        '                        End If
        '                        If .FieldFormat.Length > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).PromptChar = .FieldFormat
        '                        End If
        '                        If .FieldLength > 0 Then
        '                            CType(v_ctrl, FlexMaskEditBox).MaxLength = .FieldLength
        '                        End If
        '                        If .DataType = "N" Then
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
        '                        Else
        '                            CType(v_ctrl, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
        '                        End If
        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, FlexMaskEditBox).ReadOnly = True
        '                            CType(v_ctrl, FlexMaskEditBox).Enabled = False
        '                        End If
        '                        CType(v_ctrl, FlexMaskEditBox).Visible = .Visible
        '                        CType(v_ctrl, FlexMaskEditBox).Enabled = .Enabled

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                End With
        '            Next
        '        ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
        '            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
        '                With mv_arrObjFields(i)
        '                    If (v_ctrl.Tag = .FieldName) And (.FieldType = "D") Then
        '                        'If .InputMask.Length > 0 Then

        '                        'End If
        '                        If .FieldFormat.Length > 0 Then
        '                            CType(v_ctrl, DateTimePicker).CustomFormat = .FieldFormat
        '                        End If
        '                        'If .FieldLength > 0 Then

        '                        'End If
        '                        CType(v_ctrl, DateTimePicker).Visible = .Visible
        '                        CType(v_ctrl, DateTimePicker).Enabled = .Enabled
        '                        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                            CType(v_ctrl, DateTimePicker).Enabled = False
        '                        End If

        '                        'Set caption foce color
        '                        If .Mandatory Then
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
        '                        Else
        '                            SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
        '                        End If

        '                        Exit For
        '                    End If
        '                End With
        '            Next
        '        ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
        '            FormatObjectFields(v_ctrl)
        '        ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
        '            FormatObjectFields(v_ctrl)
        '        ElseIf TypeOf (v_ctrl) Is TabPage Or TypeOf (v_ctrl) Is XtraTabPage Then
        '            FormatObjectFields(v_ctrl)
        '        ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
        '            FormatObjectFields(v_ctrl)
        '        ElseIf TypeOf (v_ctrl) Is CheckBox Then
        '            If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                CType(v_ctrl, CheckBox).Enabled = False
        '            End If
        '        ElseIf TypeOf (v_ctrl) Is CheckEdit Then
        '            If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
        '                CType(v_ctrl, CheckEdit).Enabled = False
        '            End If
        '        End If

        '        ''QuangVD: disable fields
        '        'If (mv_strTableName = "CFCONTACT" And ExeFlag = ExecuteFlag.View) Then
        '        '    If (v_ctrl.Name = "txtCUSTID") Then v_ctrl.Enabled = False
        '        '    If (v_ctrl.Name = "cboTYPE") Then v_ctrl.Enabled = False
        '        'End If

        '        'If (mv_strTableName = "CFRELATION" And ExeFlag = ExecuteFlag.View) Then
        '        '    If (v_ctrl.Name = "txtCUSTID") Then v_ctrl.Enabled = False
        '        '    If (v_ctrl.Name = "cboRETYPE") Then v_ctrl.Enabled = False
        '        'End If
        '        ''QuangVD: end here

        '    Next
        'Catch ex As Exception
        '    LogError.Write("Error source: frmMaintenance." & ModuleCode & "." & ObjectName & ".FormatObjectFields" & vbNewLine _
        '                 & "Error code: System error!" & vbNewLine _
        '                 & "Error message: " & IIf(v_ctrl.Name Is Nothing, ".", v_ctrl.Name & ".") & ex.Message, EventLogEntryType.Error)
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End Try
    End Sub

    Private Sub PrepareDataSet_ControlType(ByRef pv_ds As DataSet, ByRef v_newds As Boolean, _
                                    ByVal pv_ctrl As Windows.Forms.Control)
        Dim v_dc As DataColumn
        Dim v_ctrl, v_ctrTabPage As Windows.Forms.Control
        Dim v_strFldType, v_strDataType As String
        Dim v_strControlTag, v_strControlData As String
        Try
            If v_newds Then
                'Tao moi dataset ban dau
                If Not (pv_ds Is Nothing) Then
                    pv_ds.Dispose()
                End If
                pv_ds = New DataSet("CTLTYPE")
                pv_ds.Tables.Add(TableName)
                v_newds = False
            End If

            For Each v_ctrl In pv_ctrl.Controls
                v_strControlTag = UCase(v_ctrl.Tag)
                If v_strControlTag.Trim.Length > 0 Then
                    If (TypeOf (v_ctrl) Is TabControl) Then
                        v_dc = New DataColumn(v_strControlTag)
                        v_dc.DataType = GetType(String)
                        v_dc.Caption = "TabControl"
                        pv_ds.Tables(0).Columns.Add(v_dc)
                        PrepareDataSet_ControlType(pv_ds, v_newds, v_ctrl)
                    ElseIf (TypeOf (v_ctrl) Is XtraTabControl) Then
                        v_dc = New DataColumn(v_strControlTag)
                        v_dc.DataType = GetType(String)
                        v_dc.Caption = "XtraTabControl"
                        pv_ds.Tables(0).Columns.Add(v_dc)
                        PrepareDataSet_ControlType(pv_ds, v_newds, v_ctrl)
                    Else
                        If (TypeOf (v_ctrl) Is Button) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "Button"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is Label) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "Label"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is LabelControl) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "LabelControl"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is Panel) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "Panel"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "GroupBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is TabPage) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TabPage"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is XtraTabPage) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "XtraTabPage"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is TextBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TextBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is RichTextBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "RichTextBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is TextEdit) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TextEdit"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is MemoEdit) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "MemoEdit"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "FlexMaskEditBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "DateTimePicker"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is DateEdit) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "DateEdit"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "ComboBoxEx"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is LookUpEdit) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "LookUpEdit"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "PictureBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "GroupBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is GroupControl) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "GroupBox"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub PrepareDataSet(ByRef pv_ds As DataSet)
        Dim v_dc As DataColumn

        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If

            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add(TableName)

            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                v_dc = New DataColumn(mv_arrObjFields(i).FieldName)
                Select Case mv_arrObjFields(i).DataType
                    Case "C"
                        v_dc.DataType = GetType(String)
                    Case "D"
                        v_dc.DataType = GetType(System.DateTime)
                    Case "N"
                        v_dc.DataType = GetType(Double)
                    Case "B"
                        v_dc.DataType = GetType(System.Byte())
                    Case Else
                        v_dc.DataType = GetType(String)
                End Select
                If mv_arrObjFields(i).DefParam <> "N" Then
                    pv_ds.Tables(0).Columns.Add(v_dc)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FillLookupData(ByVal pv_strFLDNAME As String, ByVal pv_strVALUE As String, ByVal pv_strFULLDATA As String, Optional ByVal v_strFieldKey As String = "VALUE")
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_intNodeIndex As Integer
            Dim v_strLookupField As String
            Dim v_ctrl As System.Windows.Forms.Control


            v_xmlDocument.LoadXml(pv_strFULLDATA)
            Dim v_intCount As Integer = mv_arrObjFields.GetLength(0)

            If v_intCount > 0 Then
                'Xác định Node chứa dữ liệu
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If v_strFieldKey = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) _
                                And pv_strVALUE = Trim(.InnerText.ToString) Then
                                v_intNodeIndex = i
                                Exit For
                            End If
                        End With
                    Next
                Next

                'Nạp dữ liệu Lookup cho các control có khai báo
                For i As Integer = 0 To v_intCount - 1 Step 1
                    If Not (mv_arrObjFields(i) Is Nothing) Then
                        If Trim(mv_arrObjFields(i).LookupName).Length > 0 Then
                            'Nếu có tham số lấy giá trị
                            Dim v_arrLookupName() As String = mv_arrObjFields(i).LookupName.Split("|")
                            If (v_arrLookupName.Length = 2) And (v_arrLookupName(0) = pv_strFLDNAME) Then
                                v_strLookupField = v_arrLookupName(1)
                                Try
                                    For j As Integer = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                        With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                            If v_strLookupField = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                                'Gán giá trị cho contol tương ứng
                                                SetControlValue(Me, mv_arrObjFields(i).FieldName, mv_arrObjFields(i).FieldType, .InnerText.ToString().Trim(), mv_arrObjFields(i).DataType)
                                            End If
                                        End With
                                    Next
                                Catch ex As Exception
                                    SetControlValue(Me, mv_arrObjFields(i).FieldName, mv_arrObjFields(i).FieldType, "", mv_arrObjFields(i).DataType)
                                End Try
                            End If
                        End If

                    End If

                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If (TypeOf (sender) Is FlexMaskEditBox) Then
                CType(sender, FlexMaskEditBox).SelectionStart = 0
                CType(sender, FlexMaskEditBox).SelectionLength = CType(sender, FlexMaskEditBox).Mask.Length()
            ElseIf (TypeOf (sender) Is TextBox) Then
                CType(sender, TextBox).SelectionStart = 0
                CType(sender, TextBox).SelectionLength = CType(sender, TextBox).Text.Length()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String

            For i As Integer = 0 To mv_arrObjFields.Length - 1
                If (mv_arrObjFields(i).FieldName = pv_ctrl.Tag) Then
                    v_strFormat = mv_arrObjFields(i).FieldFormat
                    Exit For
                End If
            Next

            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetControlFocus(ByVal pv_ctrl As System.Windows.Forms.Control, ByVal pv_strFLDNAME As String)
        Dim v_ctrl As System.Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If (v_ctrl.Enabled And v_ctrl.Visible) Then
                    If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, FlexMaskEditBox).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is TextBox Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, TextBox).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, RichTextBox).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is TextEdit Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, TextEdit).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is MemoEdit Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, MemoEdit).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, DateTimePicker).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is DateEdit Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, DateEdit).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, ComboBoxEx).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is LookUpEdit Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, LookUpEdit).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is PictureBox Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, PictureBox).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is TabControl Or TypeOf (v_ctrl) Is XtraTabControl Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is TabPage Or TypeOf (v_ctrl) Is XtraTabPage Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is Panel Or TypeOf (v_ctrl) Is PanelControl Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetCaptionForeColor(ByVal pv_ctlParent As System.Windows.Forms.Control, ByVal pv_strFLDNAME As String, ByVal Color As System.Drawing.Color)
        Try
            Dim v_ctrl As System.Windows.Forms.Control

            For Each v_ctrl In pv_ctlParent.Controls
                If (TypeOf (v_ctrl) Is Label) And (v_ctrl.Tag = pv_strFLDNAME) Then
                    v_ctrl.ForeColor = Color
                    Exit For
                ElseIf (TypeOf (v_ctrl) Is LabelControl) And (v_ctrl.Tag = pv_strFLDNAME) Then
                    v_ctrl.ForeColor = Color
                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetCaptionMandatory(ByVal pv_ctlParent As System.Windows.Forms.Control, ByVal pv_strFLDNAME As String, ByVal pv_strMandatory As String)
        Try
            Dim v_ctrl As System.Windows.Forms.Control

            If pv_strMandatory = "Y" Then
                For Each v_ctrl In pv_ctlParent.Controls
                    If (TypeOf (v_ctrl) Is Label Or TypeOf (v_ctrl) Is LabelControl) And (v_ctrl.Tag = pv_strFLDNAME) Then
                        v_ctrl.Text = v_ctrl.Text & "(*)"
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetFieldDataType(ByVal pv_strFLDNAME As String) As String
        Try
            Dim v_strDataType As String = String.Empty

            For i As Integer = 0 To mv_arrObjFields.Length - 1
                If (mv_arrObjFields(i).FieldName = pv_strFLDNAME) Then
                    v_strDataType = mv_arrObjFields(i).DataType
                    Exit For
                End If
            Next

            Return v_strDataType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BuildDATEEXP(ByVal strDATEEXP As String) As Date
        Dim v_dtmRetVal As Date
        Dim v_strDateEXP As String
        Try
            If Mid(strDATEEXP, 1, 1) = "@" Then
                'v_dtmRetVal = DDMMYYYY_SystemDate(Mid(strDATEEXP, 2))
                v_strDateEXP = Mid(strDATEEXP, 2)
                v_strDateEXP = Replace(v_strDateEXP, "<$BUSDATE>", Me.BusDate)
                v_dtmRetVal = DDMMYYYY_SystemDate(v_strDateEXP)
            Else
                v_dtmRetVal = DDMMYYYY_SystemDate(GetControlValueByName(strDATEEXP, Me))
            End If

            Return v_dtmRetVal
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function ShowValMsg(ByVal pv_arrObjFldVal As CFieldVal, ByVal pv_strLanguage As String)
        If pv_strLanguage = "EN" Then
            If pv_arrObjFldVal.CHKLEV = gc_INFO_MESSAGE Then
                MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return True
            ElseIf pv_arrObjFldVal.CHKLEV = gc_WARNING_MESSAGE Then
                If MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Ok Then
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox(pv_arrObjFldVal.EN_ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return False
            End If
        Else
            If pv_arrObjFldVal.CHKLEV = gc_INFO_MESSAGE Then
                MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return True
            ElseIf pv_arrObjFldVal.CHKLEV = gc_WARNING_MESSAGE Then
                If MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Ok Then
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox(pv_arrObjFldVal.ERRMSG, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return False
            End If
        End If
        Return True
    End Function

#End Region

#Region " Form events "

    Private Sub frmXtraMaintenance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'If mv_saveButtonType <> SaveButtonType.CancelButton And mv_saveButtonType <> SaveButtonType.OKButton And mv_saveButtonType <> SaveButtonType.ApplyButton Then
        '    mv_isClose = True
        '    OnClose()
        'End If
    End Sub
    Private Sub frmMaintain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (sender Is btnOK) Then
                mv_saveButtonType = SaveButtonType.OKButton
                OnSave()
            ElseIf (sender Is btnApply) Then
                mv_saveButtonType = SaveButtonType.ApplyButton
                OnSave()
            ElseIf (sender Is btnCancel) Then
                mv_saveButtonType = SaveButtonType.CancelButton
                mv_isClose = True
                OnClose()
                'AnhVT Added - Maintenance Approval Retro
            ElseIf (sender Is btnApprv) Then
                OnApprv()
            ElseIf (sender Is btnCompare) Then
                OnCompare()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub frmMaintenance_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If (Me.ActiveControl Is btnOK) Then
                        OnSave()
                    Else
                        If TypeOf (Me.ActiveControl) Is TextBox Or TypeOf (Me.ActiveControl) Is System.Windows.Forms.ComboBox _
                            Or TypeOf (Me.ActiveControl) Is FlexMaskEditBox Or TypeOf (Me.ActiveControl) Is DateTimePicker _
                            Or TypeOf (ActiveControl) Is LookUpEdit Or TypeOf (ActiveControl) Is DateEdit Then
                            SendKeys.Send("{Tab}")
                            e.Handled = True
                        End If
                    End If
                Case Keys.Escape
                    mv_saveButtonType = SaveButtonType.CancelButton
                    mv_isClose = True
                    OnClose()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub TextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim v_strFLDNAME, v_strLookupSQL As String
        Dim v_intPos As Integer, v_intIndex As Integer
        Dim ctl As System.Windows.Forms.Control

        Try
            Select Case e.KeyCode
                Case Keys.F5
                    'v_strFLDNAME = CType(sender, FlexMaskEditBox).Tag
                    v_strFLDNAME = CType(sender, System.Windows.Forms.Control).Tag
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If (mv_arrObjFields(i).FieldName = v_strFLDNAME) Then
                            v_intIndex = i
                            Exit For
                        End If
                    Next
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then

                        'trung.luu: 14-04-2020 F5 maintenance khong mo tab,
                        Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                        frm.TableName = mv_arrObjFields(v_intIndex).SearchCode
                        frm.ModuleCode = mv_arrObjFields(v_intIndex).SrModCode
                        frm.AuthCode = "NYNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                        frm.IsLocalSearch = gc_IsNotLocalMsg
                        frm.IsLookup = "Y"
                        frm.SearchOnInit = False
                        frm.BranchId = Me.BranchId
                        frm.TellerId = Me.TellerId
                        frm.ShowDialog()
                        'Sua theo yeu cau cua loi SNGP156 va SNGP394 cua SBS
                        If Not (Me.ExeFlag = ExecuteFlag.Approve Or Me.ExeFlag = ExecuteFlag.View) AndAlso Not (frm.ReturnValue Is Nothing) Then
                            Me.ActiveControl.Text = frm.ReturnValue
                        End If
                        frm.Dispose()

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then

                        v_strLookupSQL = mv_arrObjFields(v_intIndex).LookupList
                        'Nếu là CFMAST

                        If Me.TableName = "CFMAST" Then
                            v_strLookupSQL = "SELECT TLID VALUE,TLID VALUECD,TLNAME DISPLAY,TLNAME EN_DISPLAY, TLNAME DESCRIPTION, TLNAME FROM tlprofiles where BRID='" & Me.BranchId & "'"
                        End If
                        Dim v_frm As New AppCore.frmLookUp(UserLanguage)
                        v_strLookupSQL = Replace(v_strLookupSQL, "<$MBID>", Me.BranchId)
                        v_strLookupSQL = Replace(v_strLookupSQL, "<$TLID>", Me.TellerId)
                        v_strLookupSQL = Replace(v_strLookupSQL, "<$BUSDATE>", Me.BusDate)
                        v_frm.SQLCMD = v_strLookupSQL
                        v_frm.ShowDialog()
                        v_intPos = InStr(v_frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            CType(sender, FlexMaskEditBox).Text = Mid(v_frm.RETURNDATA, 1, v_intPos - 1)
                            'Nạp các giá trị tương ứng cho các trư?ng kh�ác
                            FillLookupData(v_strFLDNAME, Mid(v_frm.RETURNDATA, 1, v_intPos - 1), v_frm.FULLDATA)
                        End If
                        v_frm.Dispose()
                    End If
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine & "Error StackTrace: " & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub NumericTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            FormatNumericTextbox(CType(sender, TextBox))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overridable Sub rtbData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, RichTextBox).SelectionStart = 0
        CType(sender, RichTextBox).SelectionLength = CType(sender, RichTextBox).Text.Length()
    End Sub
#End Region

    Private Sub frmXtraMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not mv_isClose Then
            mv_isClose = True
            If mv_saveButtonType = SaveButtonType.NotButton Or mv_saveButtonType = SaveButtonType.CancelButton Then
                OnClose()
                If mv_isCloseOk = False Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Public Overridable Sub mskData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_strFLDNAME As String, v_strFLDVALUE As String, v_intIndex As Integer
            v_strFLDNAME = CType(sender, System.Windows.Forms.Control).Tag
            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                If (mv_arrObjFields(i).FieldName = v_strFLDNAME) Then
                    v_intIndex = i
                    Exit For
                End If
            Next

            If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(v_intIndex).FieldName, Me).ToString().Trim()
                If Not (v_strFLDVALUE.Trim.Length = 0) Then
                    Dim v_strSQLCMD, v_strSEARCHCODE, v_FLDNAME, v_VALUE As String
                    Dim v_strKeyName, v_strSEARCHSQL As String
                    v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode

                    'Lay KeyName
                    v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                        & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                        & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_FLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_VALUE = Trim(.InnerText)
                                    Select Case v_FLDNAME
                                        Case "KEYNAME"
                                            v_strKeyName = Trim(v_VALUE)
                                        Case "SEARCHCMDSQL"
                                            v_strSEARCHSQL = Trim(v_VALUE)
                                    End Select
                                End With
                            Next
                        Next
                        'Sua doan nay them phan quyen data
                        Dim v_strClause, v_strFUNDFilter, v_strMEMBERFilter, v_strSQL As String

                        v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strFLDVALUE & "'"

                        v_strSQLCMD = v_strSQLCMD.Replace("<$MBID>", HO_MBID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_MBID>", HO_MBID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                        v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", v_strFLDVALUE)

                        If Me.UserLanguage = gc_LANG_ENGLISH Then
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                        Else
                            v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                        End If

                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                        v_ws.Message(v_strObjMsg)

                        'Kiem tra xem du lieu co ton tai khong
                        Dim v_xmlDocTmp As New Xml.XmlDocument, v_nodeListTmp As Xml.XmlNodeList
                        v_xmlDocTmp.LoadXml(v_strObjMsg)

                        v_nodeListTmp = v_xmlDocTmp.SelectNodes("/ObjectMessage/ObjData")
                        If v_nodeListTmp.Count = 0 Then
                            '   If mv_arrObjFields(v_intIndex).LookupCheck = "Y" Then
                            '       MessageBox.Show(mv_resourceManager.GetString("ERR_DATA_NOTFOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '       e.Cancel = True
                            '       Exit Sub
                            '   End If
                        End If

                        FillLookupData(v_strFLDNAME, v_strFLDVALUE, v_strObjMsg, v_strKeyName)

                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

End Class