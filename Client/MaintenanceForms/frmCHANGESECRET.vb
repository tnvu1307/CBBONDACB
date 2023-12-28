Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.Xml
Imports AppCore

Public Class frmCHANGESECRET
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ricSECRET As System.Windows.Forms.RichTextBox
    Friend WithEvents lblSECRET As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.lblSECRET = New System.Windows.Forms.Label()
        Me.ricSECRET = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(437, 142)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(517, 142)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 50)
        Me.Panel1.TabIndex = 7
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
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSECRET
        '
        Me.lblSECRET.AutoSize = True
        Me.lblSECRET.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECRET.Location = New System.Drawing.Point(34, 78)
        Me.lblSECRET.Name = "lblSECRET"
        Me.lblSECRET.Size = New System.Drawing.Size(55, 13)
        Me.lblSECRET.TabIndex = 17
        Me.lblSECRET.Tag = "SECRET"
        Me.lblSECRET.Text = "lblSECRET"
        Me.lblSECRET.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ricSECRET
        '
        Me.ricSECRET.Location = New System.Drawing.Point(95, 75)
        Me.ricSECRET.Name = "ricSECRET"
        Me.ricSECRET.Size = New System.Drawing.Size(497, 54)
        Me.ricSECRET.TabIndex = 18
        Me.ricSECRET.Tag = "SECRET"
        Me.ricSECRET.Text = ""
        '
        'frmCHANGESECRET
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 181)
        Me.Controls.Add(Me.ricSECRET)
        Me.Controls.Add(Me.lblSECRET)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCHANGESECRET"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CHANGESECRET"
        Me.Text = "frmCHANGESECRET"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables"
    Private Const Apply As Integer = 1
    Private Const OK As Integer = 2
    Const mc_strAdmin = "Admin"

    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strTellerId As String
    Private mv_strGroupId As String
    Private mv_strBranchId As String
    Private mv_strGroupName As String
    Private mv_strDisplayType As String
    Private mv_strUserId As String
    Private mv_strGroupType As String
    Private mv_intExecFlag As Integer
    Private mv_arrGroupId() As String
    Private mv_arrGroupType() As String

    Private mv_blnIsLoadData As Boolean = False

    'Khai báo các bảng băm dùng chứa các thông tin NSD và nhóm
    Public hTlidOutGrpFilter As New Hashtable
    Public hTlidInGrpFilter As New Hashtable
    Public hBridInGrpFilter As New Hashtable
    Public hBridOutGrpFilter As New Hashtable
    Public hGroupsFilter As New Hashtable
    Public hGroupsTypeFilter As New Hashtable
    Public hUserFilter As New Hashtable
    Public hGrpOutUsrFilter As New Hashtable
    Public hGrpInUsrFilter As New Hashtable

#End Region

#Region " Properties"
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
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

    Public Property GroupId() As String
        Get
            Return mv_strGroupId
        End Get
        Set(ByVal Value As String)
            mv_strGroupId = Value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return mv_strGroupName
        End Get
        Set(ByVal Value As String)
            mv_strGroupName = Value
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

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property DisplayType() As String
        Get
            Return mv_strDisplayType
        End Get
        Set(ByVal Value As String)
            mv_strDisplayType = Value
        End Set
    End Property

    Public Property UserId() As String
        Get
            Return mv_strUserId
        End Get
        Set(ByVal Value As String)
            mv_strUserId = Value
        End Set
    End Property

    Public Property GroupType() As String
        Get
            Return mv_strGroupType
        End Get
        Set(ByVal Value As String)
            mv_strGroupType = Value
        End Set
    End Property
#End Region

#Region " Overridable methods"

    Public Overridable Sub OnInit()
        Try

            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & ".frmCHANGESECRET-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            'If Not FillData() Then
            '    Exit Sub
            'End If
            If Not FillCombobox() Then
                Exit Sub
            End If
            LoadUserInterface(Me)
            'Lay thong tin nhom
            'If DisplayType = "Users" Then
            '    GetUserGroupsInfo(UserId)
            'Else
            '    GetUserGroupsInfo("")
            'End If
            'Fill list
            'ComboBoxValueChange()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        'Public Function LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control) As Boolean
        Dim v_ctrl As Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then

                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                End If
            Next

            'Load caption của form, label caption
            Me.Text = mv_ResourceManager.GetString("frmCHANGESECRET")
            lblCaption.Text = mv_ResourceManager.GetString("lblCaption") & GroupName

            'lblCaption.Text = mv_ResourceManager.GetString("frmCHANGESECRET.lblCaption") & GroupName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function FillCombobox() As Boolean
        Try
            Dim v_strFLDNAME, v_strValue As String
            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    'Private Sub ComboBoxValueChange()
    '    Dim v_strUsrOutGrpObjMsg, v_strUsrInGrpObjMsg As String
    '    Dim v_strTLNAME, v_strValue As String
    '    Dim v_strFLDNAME As String
    '    Dim v_strFieldType As String
    '    Dim v_strCmdInquiryUsrOutGrp, v_strCmdInquiryUsrInGrp As String

    '    Try
    '        Dim v_strGroupId, v_strGroupName As String
    '        Dim v_arrUsrInGrp(), v_arrUsrOutGrp() As String
    '        Dim v_arrUsrInfo() As String
    '        Dim v_strHashKey, v_strHashValue As String

    '        If (Not cboGROUP.SelectedValue Is Nothing) And (Not cboGROUP.SelectedValue Is DBNull.Value) _
    '           And (Not cboBRANCH.SelectedValue Is Nothing) And (Not cboBRANCH.SelectedValue Is DBNull.Value) _
    '           And (Not cboGRPTYPE.SelectedValue Is Nothing) And (Not cboGRPTYPE.SelectedValue Is DBNull.Value) _
    '           And mv_blnIsLoadData Then
    '            If Trim(DisplayType) = "Users" Then
    '                v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
    '                v_strGroupName = cboGROUP.Text
    '                v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
    '                'Insert users that are not in group to list box
    '                If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
    '                        'lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
    '                    Next
    '                End If
    '                'Insert users that are in group to list box
    '                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrInGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
    '                        'lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
    '                    Next
    '                End If
    '                'Display caption
    '                lblCaption.Text = mv_ResourceManager.GetString("frmCHANGESECRET_USR.lblCaption") & v_strGroupName
    '            Else
    '                v_strGroupId = CStr(cboGROUP.SelectedValue).Trim
    '                v_strGroupName = cboGROUP.Text
    '                v_strHashKey = cboBRANCH.SelectedValue & "|" & cboGRPTYPE.SelectedValue & "|" & cboGROUP.SelectedValue
    '                'Insert users that are not in group to list box
    '                If Not hTlidOutGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrOutGrp = CStr(hTlidOutGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrOutGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrOutGrp(i).Split("|")
    '                        'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
    '                        'lstUSRNOGRP.Items.Add(v_arrUsrInfo(0))
    '                        'End If
    '                    Next
    '                End If
    '                'Insert users that are in group to list box
    '                If Not hTlidInGrpFilter(v_strHashKey) Is Nothing Then
    '                    v_arrUsrInGrp = CStr(hTlidInGrpFilter(v_strHashKey)).Split("#")
    '                    For i As Integer = 1 To v_arrUsrInGrp.Length - 2
    '                        v_arrUsrInfo = v_arrUsrInGrp(i).Split("|")
    '                        'If v_arrUsrInfo(1) <> TellerId And v_arrUsrInfo(1) <> ADMIN_ID Then
    '                        'lstUSRINGRP.Items.Add(v_arrUsrInfo(0))
    '                        'End If
    '                    Next
    '                End If
    '                'Display caption
    '                lblCaption.Text = mv_ResourceManager.GetString("frmCHANGESECRET.lblCaption") & v_strGroupName
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub



    ''--------------------------------------------------------''
    ''-- Ghi các thông tin định nghĩa NSD cho nhóm vào CSDL --''
    ''--------------------------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_strClause As String
        Try
            v_strClause = ricSECRET.Text
            'Build XML message
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.CHANGESECRET", gc_ActionAdhoc, , v_strClause, "Submit", gc_AutoIdUsed, )

            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

            If v_lngErrorCode = 0 Then
                Dim v_xmlDocument As XmlDocumentEx = New XmlDocumentEx()
                v_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_strerrorCode As String = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='errorCode']").InnerText
                Dim v_strerrorDesc As String = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='errorDesc']").InnerText
                If v_strerrorCode = "00" Then
                    MsgBox(mv_ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox("errorCode: " & v_strerrorCode & vbCrLf & "errorDesc: " & v_strerrorDesc, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR CALL API")
                End If
            Else
                Dim v_strErrorSource, v_strErrorMessage As String
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                             & "Error code: System error!" & vbNewLine _
                                                             & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

#End Region

#Region " Form events "

    Private Sub frmCHANGESECRET_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    OnClose()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        mv_intExecFlag = OK
        OnSave()
    End Sub

    Private Sub frmCHANGESECRET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub cboGROUP_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ComboBoxGRPValueChange()
        'ComboBoxValueChange()
    End Sub

#End Region
End Class
