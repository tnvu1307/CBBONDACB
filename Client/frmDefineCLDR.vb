Imports AppCore
Imports CommonLibrary

Public Class frmDefineCLDR
    Inherits System.Windows.Forms.Form

#Region "Declare variables and constants"
    Const c_ResourceManager As String = gc_RootNamespace & ".frmDefineCLDR-"

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strFunction As String
    Private mv_blnDOM As Boolean
    Private mv_strDay As String
    Private mv_strMonth As String
    Private mv_strDate As String
    Private mv_strYear As String
    Private mv_strValue As String
    Private c_CLDRTYPEB As String

    Private Const c_CLDRTYPE As String = "000"

    Public mv_strReturn As String

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String, ByVal pv_strFunction As String, ByVal pv_blnDOM As Boolean, _
                    Optional ByVal pv_strValue As String = "", _
                    Optional ByVal pv_strDay As String = "", Optional ByVal pv_strDate As String = "", _
                    Optional ByVal pv_strMonth As String = "", Optional ByVal pv_strYear As String = "", Optional ByVal pv_CLDRTYPEB As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & mv_strLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        mv_strFunction = pv_strFunction
        mv_blnDOM = pv_blnDOM
        mv_strDay = pv_strDay
        mv_strDate = pv_strDate
        mv_strMonth = pv_strMonth
        mv_strYear = pv_strYear
        mv_strValue = pv_strValue
        c_CLDRTYPEB = pv_CLDRTYPEB
        LoadScheduleCombo()

        If mv_blnDOM Then
            btnSetYear.Visible = True
            btnSetMonth.Visible = True
            btnCancel.Visible = True
        Else
            btnOK.Visible = True
            btnCancel.Visible = True
        End If

        Select Case pv_strFunction
            Case "SET_HOLIDAY"
                lblHoliday.Visible = True
            Case "SET_WORKING_DAY"
                lblWorkingDay.Visible = True
            Case "SET_CLEARDAY"
                lblCLEARDAY.Visible = True
                txtCLEARDAY.Visible = True
                txtCLEARDAY.Text = mv_strValue
            Case "SET_SCHEDULE_TYPE"
                lblSCHEDULE.Visible = True
                cboSCHEDULE.Visible = True
                If Not mv_blnDOM Then
                    cboSCHEDULE.SelectedValue = mv_strValue
                End If

        End Select

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
    Friend WithEvents txtCLEARDAY As System.Windows.Forms.TextBox
    Friend WithEvents lblCLEARDAY As System.Windows.Forms.Label
    Friend WithEvents lblSCHEDULE As System.Windows.Forms.Label
    Friend WithEvents cboSCHEDULE As AppCore.ComboBoxEx
    Friend WithEvents btnSetYear As System.Windows.Forms.Button
    Friend WithEvents btnSetMonth As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblHoliday As System.Windows.Forms.Label
    Friend WithEvents lblWorkingDay As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCLEARDAY = New System.Windows.Forms.TextBox
        Me.lblCLEARDAY = New System.Windows.Forms.Label
        Me.lblSCHEDULE = New System.Windows.Forms.Label
        Me.cboSCHEDULE = New AppCore.ComboBoxEx
        Me.btnSetYear = New System.Windows.Forms.Button
        Me.btnSetMonth = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblHoliday = New System.Windows.Forms.Label
        Me.lblWorkingDay = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtCLEARDAY
        '
        Me.txtCLEARDAY.Location = New System.Drawing.Point(208, 16)
        Me.txtCLEARDAY.Name = "txtCLEARDAY"
        Me.txtCLEARDAY.TabIndex = 0
        Me.txtCLEARDAY.Tag = "CLEARDAY"
        Me.txtCLEARDAY.Text = "txtCLEARDAY"
        '
        'lblCLEARDAY
        '
        Me.lblCLEARDAY.Location = New System.Drawing.Point(96, 16)
        Me.lblCLEARDAY.Name = "lblCLEARDAY"
        Me.lblCLEARDAY.TabIndex = 1
        Me.lblCLEARDAY.Tag = "CLEARDAY"
        Me.lblCLEARDAY.Text = "lblCLEARDAY"
        Me.lblCLEARDAY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSCHEDULE
        '
        Me.lblSCHEDULE.Location = New System.Drawing.Point(96, 16)
        Me.lblSCHEDULE.Name = "lblSCHEDULE"
        Me.lblSCHEDULE.TabIndex = 2
        Me.lblSCHEDULE.Tag = "SCHEDULE"
        Me.lblSCHEDULE.Text = "lblSCHEDULE"
        Me.lblSCHEDULE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSCHEDULE
        '
        Me.cboSCHEDULE.DisplayMember = "DISPLAY"
        Me.cboSCHEDULE.Location = New System.Drawing.Point(208, 16)
        Me.cboSCHEDULE.Name = "cboSCHEDULE"
        Me.cboSCHEDULE.Size = New System.Drawing.Size(104, 21)
        Me.cboSCHEDULE.TabIndex = 3
        Me.cboSCHEDULE.Tag = "SCHEDULE"
        Me.cboSCHEDULE.ValueMember = "VALUE"
        '
        'btnSetYear
        '
        Me.btnSetYear.Location = New System.Drawing.Point(16, 56)
        Me.btnSetYear.Name = "btnSetYear"
        Me.btnSetYear.Size = New System.Drawing.Size(128, 23)
        Me.btnSetYear.TabIndex = 4
        Me.btnSetYear.Tag = "btnSetYear"
        Me.btnSetYear.Text = "btnSetYear"
        '
        'btnSetMonth
        '
        Me.btnSetMonth.Location = New System.Drawing.Point(176, 56)
        Me.btnSetMonth.Name = "btnSetMonth"
        Me.btnSetMonth.Size = New System.Drawing.Size(120, 23)
        Me.btnSetMonth.TabIndex = 5
        Me.btnSetMonth.Tag = "btnSetMonth"
        Me.btnSetMonth.Text = "btnSetMonth"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(328, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'lblHoliday
        '
        Me.lblHoliday.Location = New System.Drawing.Point(16, 16)
        Me.lblHoliday.Name = "lblHoliday"
        Me.lblHoliday.Size = New System.Drawing.Size(416, 23)
        Me.lblHoliday.TabIndex = 7
        Me.lblHoliday.Tag = "lblHoliday"
        Me.lblHoliday.Text = "lblHoliday"
        Me.lblHoliday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWorkingDay
        '
        Me.lblWorkingDay.Location = New System.Drawing.Point(8, 16)
        Me.lblWorkingDay.Name = "lblWorkingDay"
        Me.lblWorkingDay.Size = New System.Drawing.Size(424, 23)
        Me.lblWorkingDay.TabIndex = 8
        Me.lblWorkingDay.Tag = "lblWorkingDay"
        Me.lblWorkingDay.Text = "lblWorkingDay"
        Me.lblWorkingDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(176, 56)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'frmDefineCLDR
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 93)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblWorkingDay)
        Me.Controls.Add(Me.lblHoliday)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSetMonth)
        Me.Controls.Add(Me.btnSetYear)
        Me.Controls.Add(Me.cboSCHEDULE)
        Me.Controls.Add(Me.lblSCHEDULE)
        Me.Controls.Add(Me.lblCLEARDAY)
        Me.Controls.Add(Me.txtCLEARDAY)
        Me.Name = "frmDefineCLDR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private functions"
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Control
        For Each v_ctrl In pv_ctrl.Controls
            v_ctrl.Visible = False
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = ""
            End If
        Next
    End Sub

    Private Sub LoadScheduleCombo()
        Try
            Dim v_strSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement

            v_strSQL = "SELECT CDVAL VALUE, CDVAL DISPLAY, CDVAL EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'SCHEDULETYPE' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, "SA.LOOKUP", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            FillComboEx(v_strObjMsg, cboSCHEDULE, "", mv_strLanguage)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                             & "Error code: System error!" & vbNewLine _
                                                             & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub
#End Region

#Region "Form events"
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_lngErrorCode As Long

            Dim v_strCmdInquiry As String
            Dim v_strObjMsg As String
            Dim strSQL As String
            Select Case mv_strFunction
                Case "SET_CLEARDAY"
                    strSQL = mv_strDate & "$" & Me.txtCLEARDAY.Text
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_CLEARDAY")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    If v_lngErrorCode = ERR_SYSTEM_OK Then
                        mv_strReturn = Me.txtCLEARDAY.Text
                    End If

                Case "SET_SCHEDULE_TYPE"
                    strSQL = mv_strDate & "$" & Me.cboSCHEDULE.SelectedValue
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_SCHEDULE")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    If v_lngErrorCode = ERR_SYSTEM_OK Then
                        mv_strReturn = Me.cboSCHEDULE.SelectedValue
                    End If
            End Select
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                                         & "Error code: System error!" & vbNewLine _
                                                                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            'v_ws.Close()
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        mv_strReturn = ""
        Me.Close()
    End Sub

    Private Sub btnSetYear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetYear.Click
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
            Dim v_strObjMsg As String
            Dim strSQL As String
            Select Case mv_strFunction
                Case "SET_HOLIDAY"
                    strSQL = mv_strDay & "$" & mv_strYear & "$" & "Y" & "$" & c_CLDRTYPEB

                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOY_HOLIDAY")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    mv_strReturn = "Y$" & Convert.ToString(v_lngErrorCode)
                Case "SET_WORKING_DAY"
                    strSQL = mv_strDay & "$" & mv_strYear & "$" & "N" & "$" & c_CLDRTYPEB

                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOY_HOLIDAY")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    mv_strReturn = "Y$" & Convert.ToString(v_lngErrorCode)
                    'Case "SET_CLEARDAY"
                    '    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & Me.txtCLEARDAY.Text & "$Year"
                    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_CLEARDAY")
                    '    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    '    If v_lngErrorCode = ERR_SYSTEM_OK Then
                    '        mv_strReturn = "Y$" & Me.txtCLEARDAY.Text
                    '    End If
                    'Case "SET_SCHEDULE_TYPE"
                    '    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & Me.cboSCHEDULE.SelectedValue & "$Year"
                    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_SCHEDULE")
                    '    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    '    If v_lngErrorCode = ERR_SYSTEM_OK Then
                    '        mv_strReturn = "Y$" & Me.cboSCHEDULE.SelectedValue
                    '    End If
            End Select
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                                                     & "Error code: System error!" & vbNewLine _
                                                                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            'v_ws.Close()
        End Try
    End Sub

    Private Sub btnSetMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetMonth.Click
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
            Dim v_strObjMsg As String
            Dim strSQL As String
            Select Case mv_strFunction
                Case "SET_HOLIDAY"
                    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & "Y" & "$" & c_CLDRTYPEB

                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_HOLIDAY")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    mv_strReturn = "M$" & Convert.ToString(v_lngErrorCode)
                Case "SET_WORKING_DAY"
                    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & "N" & "$" & c_CLDRTYPEB

                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_HOLIDAY")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    mv_strReturn = "M$" & Convert.ToString(v_lngErrorCode)
                    'Case "SET_CLEARDAY"
                    '    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & Me.txtCLEARDAY.Text & "$Month"
                    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_CLEARDAY")
                    '    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    '    If v_lngErrorCode = ERR_SYSTEM_OK Then
                    '        mv_strReturn = "M$" & Me.txtCLEARDAY.Text
                    '    End If
                    'Case "SET_SCHEDULE_TYPE"
                    '    strSQL = mv_strDay & "$" & mv_strMonth & "$" & mv_strYear & "$" & Me.cboSCHEDULE.SelectedValue & "$Month"
                    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_SCHEDULE")
                    '    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    '    If v_lngErrorCode = ERR_SYSTEM_OK Then
                    '        mv_strReturn = "M$" & Me.cboSCHEDULE.SelectedValue
                    '    End If
            End Select
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                                                     & "Error code: System error!" & vbNewLine _
                                                                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            'v_ws.Close()
        End Try
    End Sub

    Private Sub txtCLEARDAY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCLEARDAY.Validating
        If Not IsNumeric(txtCLEARDAY.Text) Then
            MessageBox.Show(mv_ResourceManager.GetString("NotNumeric"))
            e.Cancel = True
            Exit Sub
        End If
    End Sub
#End Region

    
End Class
