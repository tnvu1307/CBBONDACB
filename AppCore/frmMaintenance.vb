Imports CommonLibrary
Imports System.Windows.Forms
Imports AppCore
Imports TestBase64
Imports System.IO
Imports SendFiles
Imports ZetaCompressionLibrary

Public Enum SaveButtonType
    OKButton = 0
    ApplyButton = 1
    CancelButton = 2
    'Them DynamicScreen 12/11/2008
    ExternalButton = 3
    NavigateButton = 4
    RejectButton = 5
    ApproveButton = 6
    'Ket thuc
    NotButton = -1
End Enum

Public Class frmMaintenance
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_saveButtonType = SaveButtonType.OKButton
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
    Protected WithEvents btnOK As System.Windows.Forms.Button
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Protected WithEvents btnApply As System.Windows.Forms.Button
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents btnApprv As System.Windows.Forms.Button
    Protected WithEvents cboLink As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.lblCaption = New System.Windows.Forms.Label
    Me.btnOK = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.btnApply = New System.Windows.Forms.Button
    Me.cboLink = New AppCore.ComboBoxEx
    Me.btnApprv = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
    Me.Panel1.Controls.Add(Me.lblCaption)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(594, 50)
    Me.Panel1.TabIndex = 2
    '
    'lblCaption
    '
    Me.lblCaption.AutoSize = True
    Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCaption.Location = New System.Drawing.Point(7, 16)
    Me.lblCaption.Name = "lblCaption"
    Me.lblCaption.Size = New System.Drawing.Size(63, 13)
    Me.lblCaption.TabIndex = 0
    Me.lblCaption.Tag = "lblCaption"
    Me.lblCaption.Text = "lblCaption"
    '
    'btnOK
    '
    Me.btnOK.Location = New System.Drawing.Point(352, 424)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 10
    Me.btnOK.Tag = "btnOK"
    Me.btnOK.Text = "btnOK"
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(512, 424)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 11
    Me.btnCancel.Tag = "btnCancel"
    Me.btnCancel.Text = "btnCancel"
    '
    'btnApply
    '
    Me.btnApply.Location = New System.Drawing.Point(432, 424)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(75, 23)
    Me.btnApply.TabIndex = 12
    Me.btnApply.Tag = "btnApply"
    Me.btnApply.Text = "btnApply"
    '
    'cboLink
    '
    Me.cboLink.DisplayMember = "DISPLAY"
    Me.cboLink.Location = New System.Drawing.Point(6, 424)
    Me.cboLink.Name = "cboLink"
    Me.cboLink.Size = New System.Drawing.Size(121, 21)
    Me.cboLink.TabIndex = 13
    Me.cboLink.Tag = ""
    Me.cboLink.ValueMember = "VALUE"
    '
    'btnApprv
    '
    Me.btnApprv.Location = New System.Drawing.Point(271, 424)
    Me.btnApprv.Name = "btnApprv"
    Me.btnApprv.Size = New System.Drawing.Size(75, 23)
    Me.btnApprv.TabIndex = 14
    Me.btnApprv.Tag = "btnApprv"
    Me.btnApprv.Text = "btnApprv"
    '
    'frmMaintenance
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(594, 455)
    Me.Controls.Add(Me.btnApprv)
    Me.Controls.Add(Me.cboLink)
    Me.Controls.Add(Me.btnApply)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmMaintenance"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "frmMaintenance"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region " Khai báo biến, hằng "
    Private mv_blnIsRiskManagement As Boolean = False
    Private mv_intExecFlag As Integer = ExecuteFlag.View
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
    Public mv_frmSearchScreen As frmXtraSearch

#End Region

#Region " Overridable Functions "
    Protected Overridable Sub SetLookUpDataForm()

    End Sub

    Public Overridable Sub DoShowScreen()

    End Sub
    Public Overridable Sub FillData()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
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
            Else
                v_strCmdInquiry &= "SELECT * FROM " & TableName & " WHERE " & v_strFilter
            End If

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strCmdInquiry)
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

                    SetControlValue(Me, v_strFLDNAME, v_strFieldType, v_strValue, v_strDataType)
                    If Me.ExeFlag = ExecuteFlag.Edit Then
                        If Me.IsRiskManagement Then
                            SetRiskField(Me, v_strFLDNAME, v_strFieldType, v_blnRiskFld)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()

        If (SaveButtonType = SaveButtonType.OKButton) Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If

        Me.Close()
    End Sub
    Public Sub DoFillReturnValue(ByVal v_strGLGRP As String, ByVal v_strModCode As String, ByVal v_ctrlAccountEntries As System.Windows.Forms.ListView, Optional ByRef v_strCurrency As String = "")
        Dim v_strObjMsg, v_strCurrencyTem As String
        Dim v_strCmdInquiry As String
        Try
            v_strCurrencyTem = v_strCurrency
            v_strCmdInquiry = "SELECT ACNAME ,ACCTNO FROM GLREF WHERE APPTYPE='" & v_strModCode & "' AND GLGRP ='" & v_strGLGRP & "' ORDER BY ACNAME "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdInquiry, )
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

        LoadObjectFields()
        LoadObjectFieldValidateRules()
        FormatObjectFields(Me)
        'InitForm()
        'LoadLink()
        If cboLink.Items.Count = 0 Then
            cboLink.Visible = False
        End If
        'mv_dsControlType = New DataSet
        'PrepareDataSet_ControlType(mv_dsControlType, True, Me)
        SetLookUpDataForm()
        If ExeFlag <> ExecuteFlag.AddNew Then
            DoDataExchange()
        End If

    End Sub

    Public Overridable Sub OnSave()
        PrepareDataSet(mv_dsInput)
    End Sub

    'AnhVT Added - Maintenance Approval Retro
    Public Overridable Sub OnApprv()

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

    Public Overridable Function OnShowRiskView() As Boolean
        Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strControlTag, v_strControlType As String, v_cboEX As ComboBoxEx
        Try
            pv_ctrl.BackColor = System.Drawing.SystemColors.Control
            'Enable/disable OK, Apply buttons            

            'AnhVT Added - Maintenance Approval Retro
            btnOK.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            btnApply.Enabled = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            btnOK.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)
            btnApply.Visible = (ExeFlag = ExecuteFlag.AddNew) Or (ExeFlag = ExecuteFlag.Edit)

            btnApprv.Enabled = (ExeFlag = ExecuteFlag.Approve)
            btnApprv.Visible = (ExeFlag = ExecuteFlag.Approve)
            'AnhVT Ended
            For Each v_ctrl In pv_ctrl.Controls
                If Not v_ctrl.Tag Is Nothing Then
                    v_strControlTag = v_ctrl.Tag.ToString
                    If v_strControlTag.Trim.Length > 0 Then
                        If TypeOf (v_ctrl) Is Label Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Button Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Panel Then
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is GroupBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabControl Then
                            For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabPage Then
                            v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadUserInterface(v_ctrl)
                            'TheNN add: Load text label for checkbox control
                        ElseIf TypeOf (v_ctrl) Is CheckBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            'TheNN ended. 09-Jan-2012
                        End If
                    End If
                End If
                'Set default value for Addnew
                If ExeFlag = ExecuteFlag.AddNew Then
                    If TypeOf (v_ctrl) Is ComboBoxEx Then
                        v_cboEX = CType(v_ctrl, ComboBoxEx)
                        If v_cboEX.Items.Count > 0 Then
                            v_cboEX.SelectedIndex = 0
                        End If
                    ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                        CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
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
    'AnhVT - Maintenance Retroed
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
#End Region

#Region " Protected Functions "
    Protected Sub SetControlValue(ByRef pv_ctrl As Windows.Forms.Control, _
                                ByVal pv_strFLDNAME As String, _
                                ByVal pv_strFLDTYPE As String, _
                                ByVal pv_strFLDVAL As String, ByVal pv_strDATATYPE As String)
        Dim v_ctrl As Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "M") Then
                        CType(v_ctrl, FlexMaskEditBox).Text = Trim(pv_strFLDVAL)
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
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        If (pv_strFLDVAL.Trim().Length > 0) And (pv_strFLDVAL.Trim() <> gc_NULL_DATE) Then
                            CType(v_ctrl, DateTimePicker).Checked = True
                            CType(v_ctrl, DateTimePicker).Value = CDate(Trim(pv_strFLDVAL))
                        Else
                            CType(v_ctrl, DateTimePicker).Value = CDate(gc_NULL_DATE)
                            CType(v_ctrl, DateTimePicker).Checked = False
                        End If
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is DevExpress.XtraEditors.DateEdit Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        If (pv_strFLDVAL.Trim().Length > 0) Then
                            CType(v_ctrl, DevExpress.XtraEditors.DateEdit).EditValue = CDate(Trim(pv_strFLDVAL))
                        End If
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, ComboBoxEx).SelectedValue = Trim(pv_strFLDVAL)
                        Exit For
                    End If
                    'ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    '    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                    '        CType(v_ctrl, CheckBox).Text = Trim(pv_strFLDVAL)
                    '        Exit For
                    '    End If

                ElseIf TypeOf (v_ctrl) Is PictureBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, PictureBox).Image = GetImageFromString(pv_strFLDVAL)
                        CType(v_ctrl, PictureBox).SizeMode = PictureBoxSizeMode.CenterImage
                        CType(v_ctrl, PictureBox).BorderStyle = BorderStyle.Fixed3D
                        Exit For
                    End If

                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    SetControlValue(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_strFLDVAL, pv_strDATATYPE)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
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
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "D") Then
                        CType(v_ctrl, DateTimePicker).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, ComboBoxEx).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is PictureBox Then
                    If (v_ctrl.Tag = Trim(pv_strFLDNAME)) And (pv_strFLDTYPE = "C") Then
                        CType(v_ctrl, PictureBox).Enabled = pv_BlnRickFld
                        Exit For
                    End If
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    SetRiskField(v_ctrl, pv_strFLDNAME, pv_strFLDTYPE, pv_BlnRickFld)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

            v_strAutoPrefix = v_strAutoPrefix.Replace("<$BRID>", Me.BranchId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$TLID>", Me.TellerId)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$BUSDATE>", Me.BusDate)
            v_strAutoPrefix = v_strAutoPrefix.Replace("<$CUSTODYCD>", "021C")
            v_strAutoID = v_strAutoPrefix & v_strAutoID
            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & v_strErrorSource & "-" & v_strInvName & vbNewLine _
                         & "Error code: " & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
        FillComboEx(v_strObjMsg, cboLink, "", Me.UserLanguage)

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
            mv_frmSearchScreen.TableName = CStr(cboLink.SelectedValue).Substring(CStr(cboLink.SelectedValue).IndexOf(".") + 1)
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
            mv_frmSearchScreen.LinkFieldSrc = hLinkSrc(cboLink.SelectedValue)
            mv_frmSearchScreen.LinkFieldDes = hLinkDes(cboLink.SelectedValue)
            mv_frmSearchScreen.LinkValue = GetControlValueByName(hLinkSrc(cboLink.SelectedValue), Me)
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
    Private Sub cboLink_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLink.SelectionChangeCommitted
        ShowLinkForm()
    End Sub

    Private Sub GetControlValue(ByRef pv_dr As DataRow, _
                                    ByVal pv_ds As DataSet, _
                                    ByVal pv_ctrl As Windows.Forms.Control)
        Dim v_dc As DataColumn
        Dim v_ctrl, v_ctrTabPage As Windows.Forms.Control
        Dim v_strFldType, v_strDataType As String
        Dim v_strControlTag, v_strControlData As String
        Try
            For Each v_ctrl In pv_ctrl.Controls
                v_strControlTag = UCase(v_ctrl.Tag)
                If (v_strControlTag <> "") Then
                    If (TypeOf (v_ctrl) Is TabControl) Then
                        For Each v_ctrTabPage In v_ctrl.Controls
                            If (TypeOf (v_ctrTabPage) Is TabPage) Then
                                GetControlValue(pv_dr, pv_ds, v_ctrTabPage)
                            End If
                        Next
                    Else
                        If (TypeOf (v_ctrl) Is TextBox) Then
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
                            ElseIf (v_strFldType = "T") And (v_strDataType = "D") Then
                                If IsDateValue(v_strControlData) Then
                                    pv_dr(v_strControlTag) = v_strControlData
                                Else
                                    pv_dr(v_strControlTag) = "01/01/1900"
                                End If
                            ElseIf (v_strFldType = "T") And (v_strDataType <> "N") And (v_strDataType <> "D") Then
                                pv_dr(v_strControlTag) = v_strControlData
                            ElseIf (v_strFldType = "M") And (v_strDataType = "N") Then
                                pv_dr(v_strControlTag) = Replace(v_strControlData, ",", "").Trim()
                            ElseIf (v_strFldType = "M") And (v_strDataType = "D") Then
                                If IsDateValue(v_strControlData) Then
                                    pv_dr(v_strControlTag) = v_strControlData
                                Else
                                    pv_dr(v_strControlTag) = "01/01/1900"
                                End If
                            ElseIf (v_strFldType = "M") Then
                                pv_dr(v_strControlTag) = v_strControlData
                            End If

                        ElseIf (TypeOf (v_ctrl) Is FlexMaskEditBox) Then
                            v_strControlData = v_ctrl.Text.Trim
                            pv_dr(v_strControlTag) = v_strControlData

                        ElseIf (TypeOf (v_ctrl) Is DateTimePicker) Then

                            If IsDateValue(Trim(CStr(CType(v_ctrl, DateTimePicker).Value))) Then
                                pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateTimePicker).Value.ToShortDateString()))
                            Else
                                pv_dr(v_strControlTag) = CDate(gc_NULL_DATE)
                            End If

                            'If CType(v_ctrl, DateTimePicker).Checked Then
                            '    pv_dr(v_strControlTag) = Trim(CStr(CType(v_ctrl, DateTimePicker).Value))
                            'Else
                            '    pv_dr(v_strControlTag) = CDate(gc_NULL_DATE)
                            'End If
                        ElseIf (TypeOf (v_ctrl) Is DevExpress.XtraEditors.DateEdit) Then
                            v_strControlData = v_ctrl.Text.Trim
                            If v_strControlData.Length = 0 Then
                                pv_dr(v_strControlTag) = "01/01/1900"
                            Else
                                pv_dr(v_strControlTag) = v_strControlData
                            End If

                        ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                                If (v_strControlTag = mv_arrObjFields(i).FieldName) Then
                                    pv_dr(v_strControlTag) = Trim(CType(v_ctrl, ComboBoxEx).SelectedValue)
                                    Exit For
                                End If
                            Next

                        ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                            pv_dr(v_strControlTag) = GetStringFromImage(CType(v_ctrl, PictureBox))

                        ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                            GetControlValue(pv_dr, pv_ds, v_ctrl)

                        ElseIf (TypeOf (v_ctrl) Is Panel) Then
                            GetControlValue(pv_dr, pv_ds, v_ctrl)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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

    Public Function GetControlValueByName(ByVal pv_strFLDNAME As String, ByVal pv_ctrl As Control) As String
        Dim v_strReturnValue As String = String.Empty

        Try
            If (Trim(pv_strFLDNAME) <> "") Then
                For Each v_ctrl As Control In pv_ctrl.Controls
                    If (TypeOf (v_ctrl) Is TabControl) Then
                        For Each v_ctrTabPage As Control In v_ctrl.Controls
                            If (TypeOf (v_ctrTabPage) Is TabPage) Then
                                v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrTabPage)
                                If (v_strReturnValue <> String.Empty) Then
                                    Exit For
                                End If
                            End If
                        Next
                    ElseIf (TypeOf (v_ctrl) Is TextBox) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, TextBox).Text
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
                                v_strReturnValue = CDate(gc_NULL_DATE)
                            End If
                        End If
                    ElseIf (TypeOf (v_ctrl) Is DevExpress.XtraEditors.DateEdit) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = Trim(CStr(CType(v_ctrl, DevExpress.XtraEditors.DateEdit).EditValue))
                        End If
                    ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                        If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                            v_strReturnValue = CType(v_ctrl, ComboBoxEx).SelectedValue.ToString()
                        End If
                        'ElseIf (TypeOf (v_ctrl) Is PictureBox) Then
                        '    If (UCase(v_ctrl.Tag) = pv_strFLDNAME) Then
                        '        v_strReturnValue = CType(v_ctrl, PictureBox).Image.
                        '    End If

                    ElseIf (TypeOf (v_ctrl) Is GroupBox) Then
                        v_strReturnValue = GetControlValueByName(pv_strFLDNAME, v_ctrl)
                        If (v_strReturnValue <> String.Empty) Then
                            Exit For
                        End If
                    ElseIf (TypeOf (v_ctrl) Is Panel) Then
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

            Return String.Empty
        End Try
    End Function

    Private Function GetReferenceData(ByVal pv_xmlObjDataRef As String, ByVal pv_strFLDNAME As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlRefDocument As New Xml.XmlDocument
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry)
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
            v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strLookupName, v_strSearchCode, v_strSRMODCode As String
        Dim v_intOdrNum, v_intFldLen As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory, v_blnRiskField As Boolean

        Try
            'Create message to inquiry object fields
            Dim v_strClause As String = "upper(MODCODE) = '" & ModuleCode & "' AND upper(OBJNAME) = '" & ObjectName & "' ORDER BY ODRNUM"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)

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
                                v_strCaption = Trim(v_strValue)
                            Case "EN_CAPTION"
                                v_strEnCaption = Trim(v_strValue)
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
                    'HaiLT them
                    If String.Compare(v_strDefVal, "<$BUSDATE>") = 0 Then v_strDefVal = Me.BusDate
                    If v_strDefVal.IndexOf("<$SQL>") >= 0 Then
                        'Neu la tham chieu tu cau lenh SQL
                        Dim mv_strXMLFldMasterTmp As String
                        Dim v_nodeListTmp As Xml.XmlNodeList
                        Dim v_xmlDocumentTmp As New Xml.XmlDocument
                        Dim v_strClauseTmp, v_strValueTmp, v_strFLDNAMETmp As String
                        Dim v_strObjMsgTmp As String
                        v_strDefVal = Replace(v_strDefVal, "<$SQL>", "")

                        'Doc thong tin cac truong cua object duoc dung de hien thi
                        v_strObjMsgTmp = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strDefVal, )
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
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            'v_ws.Message(v_strObjMsg)
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG,TAGFIELD,TAGVALUE, CHKLEV FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & ObjectName & "' ORDER BY VALTYPE, ODRNUM" 'Thứ tự order by là quan tr?ng kh ông sửa
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
                        If Me.UserLanguage = "EN" Then
                            MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Else
                            MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                        SetControlFocus(Me, mv_arrObjFields(i).FieldName)
                        Return False
                    End If
                ElseIf (mv_arrObjFields(i).FieldType = "D") And (mv_arrObjFields(i).Mandatory) Then
                    v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(i).FieldName, Me).ToString().Trim()
                    If (Not (v_strFLDVALUE.Length > 0)) Or (v_strFLDVALUE.Trim() = gc_NULL_DATE) Then
                        If Me.UserLanguage = "EN" Then
                            MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Else
                            MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                        SetControlFocus(Me, mv_arrObjFields(i).FieldName)
                        Return False
                    End If
                End If

                If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                    And (mv_arrObjFields(i).DataType = "N") Then
                    v_strFLDVALUE = GetControlValueByName(mv_arrObjFields(i).FieldName, Me).ToString().Trim()

                    If v_strFLDVALUE.Length > 0 Then
                        If Not IsNumeric(v_strFLDVALUE) Then
                            If Me.UserLanguage = "EN" Then
                                MsgBox(Replace(ResourceManager.GetString("NumericDataType"), "@", mv_arrObjFields(i).EnCaption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Else
                                MsgBox(Replace(ResourceManager.GetString("NumericDataType"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            End If
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
                                                    Case "FV"
                                                        '.VALEXP la function name, .VALEXP2 la gia tri tham so phan cach nhau boi 02 dau ##
                                                        v_strVALEXP = .VALEXP   'Ten oracle function name
                                                        Dim v_strVALEXP2 As String = String.Empty
                                                        v_strVALEXP2 = BuildFUNCPARA(.VALEXP2) 'noi dung tham so
                                                        Dim v_check As String = "FALSE"
                                                        If (v_strVALEXP2 = String.Empty) Then
                                                            Exit Select
                                                        End If
                                                        v_check = GetDBFunction(v_strVALEXP, v_strVALEXP2).ToString
                                                        If Not (v_check.ToUpper = "TRUE") Then
                                                            If Not ShowValMsg(mv_arrObjFldVals(i), Me.UserLanguage) Then
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function BuildFUNCPARA(ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex, v_lngControlIndex As Long, v_ctl As Control
            Dim v_intIndex As Integer
            v_strEvaluator = vbNullString
            v_lngIndex = 1
            Dim v_index_spilit As Long
            v_index_spilit = 0


            While strAMTEXP.Length > 0
                'lay ra tung element phan cach nhau boi dau ##
                v_index_spilit = strAMTEXP.IndexOf("#")
                If (v_index_spilit > 1) Then
                    v_strElemenent = strAMTEXP.Substring(0, v_index_spilit)
                    strAMTEXP = strAMTEXP.Substring(v_index_spilit + 2)
                Else
                    v_strElemenent = strAMTEXP
                    strAMTEXP = ""
                End If


                Select Case v_strElemenent
                    Case "##"
                        'Dau phan cach: giu nguyen
                        v_strEvaluator = v_strEvaluator & ","
                    Case "TD"   'transaction date
                        v_strEvaluator = v_strEvaluator & "TO_DATE('" & Me.mv_strBusDate & "','" & gc_FORMAT_DATE & "')"
                    Case "BR" 'BranchID'
                        v_strEvaluator = v_strEvaluator & "'" & Me.BranchId & "'"
                    Case Else

                        If (v_strElemenent.StartsWith("@")) Then
                            v_strValue = v_strElemenent.Trim("@")
                        Else
                            v_strValue = GetControlValueByName(v_strElemenent, Me)
                        End If

                        v_strValue = "'" & v_strValue.Replace("'", "''") & "'"
                        v_strEvaluator = v_strEvaluator & v_strValue
                End Select
                If v_index_spilit > 1 Then
                    v_strEvaluator = v_strEvaluator & ","
                End If

            End While

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function

    Private Function GetDBFunction(ByVal pv_strFunctionName As String, ByVal pv_strParameters As String) As String
        Try
            'Cau truc pv_strParameters: giatri1##giatri2##...##giatrin
            Dim v_strClause, v_strObjMsg, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
            'Dim v_ws As New BDSDelivery.BDSDelivery
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strClause = v_strValue
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, pv_strFunctionName, pv_strParameters, "ExecDBFunction")
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Return v_strValue
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FormatObjectFields(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strInputMask As String

        Try
            For Each v_ctrl In pv_ctrl.Controls
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
                                    AddHandler CType(v_ctrl, TextBox).KeyUp, AddressOf TextBox_KeyUp
                                End If
                                If (Len(.SearchCode) > 0) And (ExeFlag <> ExecuteFlag.View) Then
                                    CType(v_ctrl, TextBox).BackColor = System.Drawing.Color.GreenYellow
                                    AddHandler CType(v_ctrl, TextBox).KeyUp, AddressOf TextBox_KeyUp
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
                                If .DataType = "D" Then
                                    CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = True
                                Else
                                    CType(v_ctrl, FlexMaskEditBox).MaskCharInclude = False
                                End If

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
                    AddHandler CType(v_ctrl, TextBox).GotFocus, AddressOf TextBox_GotFocus
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) And (.FieldType = "C") And (.LookupList.Length > 0) Then
                                'Load from object reference data in object message
                                FillComboExRefData(mv_strXMLFldMaster, CType(v_ctrl, ComboBoxEx), v_ctrl.Tag, Me.UserLanguage)

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
                ElseIf TypeOf (v_ctrl) Is DevExpress.XtraEditors.DateEdit Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) Then
                                CType(v_ctrl, DevExpress.XtraEditors.DateEdit).Visible = .Visible
                                CType(v_ctrl, DevExpress.XtraEditors.DateEdit).Enabled = .Enabled
                                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                                    CType(v_ctrl, DevExpress.XtraEditors.DateEdit).Enabled = False
                                End If

                                'set caption foce color
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    FormatObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    FormatObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    FormatObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    FormatObjectFields(v_ctrl)
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
                        ElseIf (TypeOf (v_ctrl) Is TabControl) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TabControl"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is TabPage) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TabPage"
                            pv_ds.Tables(0).Columns.Add(v_dc)
                        ElseIf (TypeOf (v_ctrl) Is TextBox) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "TextBox"
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
                        ElseIf (TypeOf (v_ctrl) Is ComboBoxEx) Then
                            v_dc = New DataColumn(v_strControlTag)
                            v_dc.DataType = GetType(String)
                            v_dc.Caption = "ComboBoxEx"
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
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
                    Case Else
                        v_dc.DataType = GetType(String)
                End Select

                pv_ds.Tables(0).Columns.Add(v_dc)
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FillLookupData(ByVal pv_strFLDNAME As String, ByVal pv_strVALUE As String, ByVal pv_strFULLDATA As String)
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_intNodeIndex As Integer
            Dim v_strLookupField As String
            Dim v_ctrl As Control

            v_xmlDocument.LoadXml(pv_strFULLDATA)
            Dim v_intCount As Integer = mv_arrObjFields.GetLength(0)

            If v_intCount > 0 Then
                'Xác định Node chứa dữ liệu
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If "VALUE" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) _
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
                                For j As Integer = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                    With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                        If v_strLookupField = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                            'Gán giá trị cho contol tương ứng
                                            SetControlValue(Me, mv_arrObjFields(i).FieldName, mv_arrObjFields(i).FieldType, .InnerText.ToString().Trim(), mv_arrObjFields(i).DataType)
                                        End If
                                    End With
                                Next
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

            If IsNumeric(pv_ctrl.Text) And v_strFormat.IndexOf("#,##") > -1 Then
                pv_ctrl.Text = Format(CDbl(pv_ctrl.Text), v_strFormat.Trim)
            ElseIf IsNumeric(pv_ctrl.Text) Then
                pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetControlFocus(ByVal pv_ctrl As Control, ByVal pv_strFLDNAME As String)
        Dim v_ctrl As Control

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
                    ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, DateTimePicker).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, ComboBoxEx).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is PictureBox Then
                        If (v_ctrl.Tag = Trim(pv_strFLDNAME)) Then
                            CType(v_ctrl, PictureBox).Focus()
                            Exit For
                        End If
                    ElseIf TypeOf (v_ctrl) Is GroupBox Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is TabControl Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is TabPage Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    ElseIf TypeOf (v_ctrl) Is Panel Then
                        SetControlFocus(v_ctrl, pv_strFLDNAME)
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetCaptionForeColor(ByVal pv_ctlParent As Control, ByVal pv_strFLDNAME As String, ByVal Color As System.Drawing.Color)
        Try
            Dim v_ctrl As Control

            For Each v_ctrl In pv_ctlParent.Controls
                If (TypeOf (v_ctrl) Is Label) And (v_ctrl.Tag = pv_strFLDNAME) Then
                    v_ctrl.ForeColor = Color
                    Exit For
                End If
            Next
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
                OnClose()
                'AnhVT Added - Maintenance Approval Retro
            ElseIf (sender Is btnApprv) Then
                OnApprv()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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
                        If TypeOf (Me.ActiveControl) Is TextBox Or TypeOf (Me.ActiveControl) Is ComboBox _
                            Or TypeOf (Me.ActiveControl) Is FlexMaskEditBox Or TypeOf (Me.ActiveControl) Is DateTimePicker Then
                            SendKeys.Send("{Tab}")
                            e.Handled = True
                        End If
                    End If
                Case Keys.Escape
                    OnClose()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub TextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim v_strFLDNAME, v_strLookupSQL As String
        Dim v_intPos As Integer, v_intIndex As Integer
        Dim ctl As Control

        Try
            Select Case e.KeyCode
                Case Keys.F5
                    'v_strFLDNAME = CType(sender, FlexMaskEditBox).Tag
                    v_strFLDNAME = CType(sender, Control).Tag
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If (mv_arrObjFields(i).FieldName = v_strFLDNAME) Then
                            v_intIndex = i
                            Exit For
                        End If
                    Next
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then


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
                        v_strLookupSQL = Replace(v_strLookupSQL, "<$BRID>", Me.BranchId)
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
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
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

    Public Function getMv_arrObjFields() As CFieldMaster()
        Return mv_arrObjFields
    End Function

    Public Sub setMv_arrObjFields(ByVal mv_arrObjFields As CFieldMaster(), ByVal form As Control)
        Me.mv_arrObjFields = mv_arrObjFields
        setColorObjectFields(form)
    End Sub

    Private Sub setColorObjectFields(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is TextBox Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) Then
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
                ElseIf TypeOf (v_ctrl) Is ComboBoxEx Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) Then
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
                            If (v_ctrl.Tag = .FieldName) Then
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
                            If (v_ctrl.Tag = .FieldName) Then
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is DevExpress.XtraEditors.DateEdit Then
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        With mv_arrObjFields(i)
                            If (v_ctrl.Tag = .FieldName) Then
                                If .Mandatory Then
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Red)
                                Else
                                    SetCaptionForeColor(v_ctrl.Parent, .FieldName, System.Drawing.Color.Blue)
                                End If

                                Exit For
                            End If
                        End With
                    Next
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    setColorObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    setColorObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    setColorObjectFields(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    setColorObjectFields(v_ctrl)
                End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: frmMaintenance." & ModuleCode & "." & ObjectName & ".FormatObjectFields" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & IIf(v_ctrl.Name Is Nothing, ".", v_ctrl.Name & ".") & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

#End Region

End Class
