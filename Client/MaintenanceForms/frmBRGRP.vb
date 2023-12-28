Imports CommonLibrary
Imports AppCore

Public Class frmBRGRP
    Inherits AppCore.frmMaintenance

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
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents lblBRNAME As System.Windows.Forms.Label
    Friend WithEvents lblPRBRID As System.Windows.Forms.Label
    'Friend WithEvents txtPRBRID As System.Windows.Forms.TextBox
    Friend WithEvents txtPRBRID As FlexMaskEditBox
    Friend WithEvents txtDCNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblDCNAME As System.Windows.Forms.Label
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    'Friend WithEvents txtBDSID As System.Windows.Forms.TextBox
    Friend WithEvents tabBRGRP As System.Windows.Forms.TabControl
    Friend WithEvents TabGENERAL As System.Windows.Forms.TabPage
    Friend WithEvents TabGROUPS As System.Windows.Forms.TabPage
    Friend WithEvents lblBRID As System.Windows.Forms.Label
    Friend WithEvents txtBRID As AppCore.FlexMaskEditBox
    Friend WithEvents lblGRPNOBR As System.Windows.Forms.Label
    Friend WithEvents lblGRPINBR As System.Windows.Forms.Label
    Friend WithEvents btnMOVE As System.Windows.Forms.Button
    Friend WithEvents btnREMOVE As System.Windows.Forms.Button
    Friend WithEvents btnREMOVEALL As System.Windows.Forms.Button
    Friend WithEvents btnMOVEALL As System.Windows.Forms.Button
    Friend WithEvents lstGRPINBR As System.Windows.Forms.ListBox
    Friend WithEvents lstGRPNOBR As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCDTO As System.Windows.Forms.TextBox
    Friend WithEvents txtCUSTODYCDFROM As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBRNAME As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBRGRP))
        Me.cboSTATUS = New AppCore.ComboBoxEx
        Me.txtBRID = New AppCore.FlexMaskEditBox
        Me.lblBRID = New System.Windows.Forms.Label
        Me.lblBRNAME = New System.Windows.Forms.Label
        Me.lblPRBRID = New System.Windows.Forms.Label
        Me.txtPRBRID = New AppCore.FlexMaskEditBox
        Me.txtDCNAME = New System.Windows.Forms.TextBox
        Me.lblDCNAME = New System.Windows.Forms.Label
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.tabBRGRP = New System.Windows.Forms.TabControl
        Me.TabGENERAL = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCUSTODYCDTO = New System.Windows.Forms.TextBox
        Me.txtCUSTODYCDFROM = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBRNAME = New System.Windows.Forms.TextBox
        Me.TabGROUPS = New System.Windows.Forms.TabPage
        Me.btnMOVE = New System.Windows.Forms.Button
        Me.btnREMOVE = New System.Windows.Forms.Button
        Me.btnREMOVEALL = New System.Windows.Forms.Button
        Me.btnMOVEALL = New System.Windows.Forms.Button
        Me.lblGRPINBR = New System.Windows.Forms.Label
        Me.lblGRPNOBR = New System.Windows.Forms.Label
        Me.lstGRPINBR = New System.Windows.Forms.ListBox
        Me.lstGRPNOBR = New System.Windows.Forms.ListBox
        Me.Panel1.SuspendLayout()
        Me.tabBRGRP.SuspendLayout()
        Me.TabGENERAL.SuspendLayout()
        Me.TabGROUPS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        '
        'lblCaption
        '
        resources.ApplyResources(Me.lblCaption, "lblCaption")
        '
        'btnApply
        '
        resources.ApplyResources(Me.btnApply, "btnApply")
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        'resources.ApplyResources(Me.cboSTATUS, "cboSTATUS")
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        Me.cboSTATUS.Location = New System.Drawing.Point(120, 75)
        Me.cboSTATUS.Size = New System.Drawing.Size(150, 21)
        '
        'txtBRID
        '
        Me.txtBRID.ForeColor = System.Drawing.SystemColors.WindowText
        resources.ApplyResources(Me.txtBRID, "txtBRID")
        Me.txtBRID.Name = "txtBRID"
        Me.txtBRID.Tag = "BRID"
        '
        'lblBRID
        '
        resources.ApplyResources(Me.lblBRID, "lblBRID")
        Me.lblBRID.Name = "lblBRID"
        Me.lblBRID.Tag = "BRID"
        '
        'lblBRNAME
        '
        resources.ApplyResources(Me.lblBRNAME, "lblBRNAME")
        Me.lblBRNAME.Name = "lblBRNAME"
        Me.lblBRNAME.Tag = "BRNAME"
        '
        'lblPRBRID
        '
        resources.ApplyResources(Me.lblPRBRID, "lblPRBRID")
        Me.lblPRBRID.Name = "lblPRBRID"
        Me.lblPRBRID.Tag = "PRBRID"
        '
        'txtPRBRID
        '
        Me.txtPRBRID.ForeColor = System.Drawing.SystemColors.WindowText
        resources.ApplyResources(Me.txtPRBRID, "txtPRBRID")
        Me.txtPRBRID.Name = "txtPRBRID"
        Me.txtPRBRID.Tag = "PRBRID"
        '
        'txtDCNAME
        '
        resources.ApplyResources(Me.txtDCNAME, "txtDCNAME")
        Me.txtDCNAME.Name = "txtDCNAME"
        Me.txtDCNAME.Tag = "DCNAME"
        '
        'lblDCNAME
        '
        resources.ApplyResources(Me.lblDCNAME, "lblDCNAME")
        Me.lblDCNAME.Name = "lblDCNAME"
        Me.lblDCNAME.Tag = "DCNAME"
        '
        'lblDESCRIPTION
        '
        resources.ApplyResources(Me.lblDESCRIPTION, "lblDESCRIPTION")
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        '
        'txtDESCRIPTION
        '
        resources.ApplyResources(Me.txtDESCRIPTION, "txtDESCRIPTION")
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        '
        'lblSTATUS
        '
        resources.ApplyResources(Me.lblSTATUS, "lblSTATUS")
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Tag = "STATUS"
        '
        'tabBRGRP
        '
        Me.tabBRGRP.Controls.Add(Me.TabGENERAL)
        Me.tabBRGRP.Controls.Add(Me.TabGROUPS)
        resources.ApplyResources(Me.tabBRGRP, "tabBRGRP")
        Me.tabBRGRP.Name = "tabBRGRP"
        Me.tabBRGRP.SelectedIndex = 0
        Me.tabBRGRP.Tag = "BRGRP"
        '
        'TabGENERAL
        '
        Me.TabGENERAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabGENERAL.Controls.Add(Me.Label3)
        Me.TabGENERAL.Controls.Add(Me.Label2)
        Me.TabGENERAL.Controls.Add(Me.txtCUSTODYCDTO)
        Me.TabGENERAL.Controls.Add(Me.txtCUSTODYCDFROM)
        Me.TabGENERAL.Controls.Add(Me.Label1)
        Me.TabGENERAL.Controls.Add(Me.txtBRNAME)
        Me.TabGENERAL.Controls.Add(Me.txtDCNAME)
        Me.TabGENERAL.Controls.Add(Me.lblDESCRIPTION)
        Me.TabGENERAL.Controls.Add(Me.txtPRBRID)
        Me.TabGENERAL.Controls.Add(Me.lblPRBRID)
        Me.TabGENERAL.Controls.Add(Me.cboSTATUS)
        Me.TabGENERAL.Controls.Add(Me.lblDCNAME)
        Me.TabGENERAL.Controls.Add(Me.lblBRNAME)
        Me.TabGENERAL.Controls.Add(Me.lblBRID)
        Me.TabGENERAL.Controls.Add(Me.txtDESCRIPTION)
        Me.TabGENERAL.Controls.Add(Me.lblSTATUS)
        Me.TabGENERAL.Controls.Add(Me.txtBRID)
        resources.ApplyResources(Me.TabGENERAL, "TabGENERAL")
        Me.TabGENERAL.Name = "TabGENERAL"
        Me.TabGENERAL.Tag = "GENERAL"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Name = "Label3"
        Me.Label3.Tag = "CUSTODYCDTO"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Name = "Label2"
        Me.Label2.Tag = "CUSTODYCDFROM"
        '
        'txtCUSTODYCDTO
        '
        resources.ApplyResources(Me.txtCUSTODYCDTO, "txtCUSTODYCDTO")
        Me.txtCUSTODYCDTO.Name = "txtCUSTODYCDTO"
        Me.txtCUSTODYCDTO.Tag = "CUSTODYCDTO"
        '
        'txtCUSTODYCDFROM
        '
        resources.ApplyResources(Me.txtCUSTODYCDFROM, "txtCUSTODYCDFROM")
        Me.txtCUSTODYCDFROM.Name = "txtCUSTODYCDFROM"
        Me.txtCUSTODYCDFROM.Tag = "CUSTODYCDFROM"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Name = "Label1"
        Me.Label1.Tag = "CUSTODYCD"
        '
        'txtBRNAME
        '
        resources.ApplyResources(Me.txtBRNAME, "txtBRNAME")
        Me.txtBRNAME.Name = "txtBRNAME"
        Me.txtBRNAME.Tag = "BRNAME"
        '
        'TabGROUPS
        '
        Me.TabGROUPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabGROUPS.Controls.Add(Me.btnMOVE)
        Me.TabGROUPS.Controls.Add(Me.btnREMOVE)
        Me.TabGROUPS.Controls.Add(Me.btnREMOVEALL)
        Me.TabGROUPS.Controls.Add(Me.btnMOVEALL)
        Me.TabGROUPS.Controls.Add(Me.lblGRPINBR)
        Me.TabGROUPS.Controls.Add(Me.lblGRPNOBR)
        Me.TabGROUPS.Controls.Add(Me.lstGRPINBR)
        Me.TabGROUPS.Controls.Add(Me.lstGRPNOBR)
        resources.ApplyResources(Me.TabGROUPS, "TabGROUPS")
        Me.TabGROUPS.Name = "TabGROUPS"
        Me.TabGROUPS.Tag = "GROUPS"
        '
        'btnMOVE
        '
        resources.ApplyResources(Me.btnMOVE, "btnMOVE")
        Me.btnMOVE.Name = "btnMOVE"
        Me.btnMOVE.Tag = "btnMOVE"
        '
        'btnREMOVE
        '
        resources.ApplyResources(Me.btnREMOVE, "btnREMOVE")
        Me.btnREMOVE.Name = "btnREMOVE"
        Me.btnREMOVE.Tag = "btnREMOVE"
        '
        'btnREMOVEALL
        '
        resources.ApplyResources(Me.btnREMOVEALL, "btnREMOVEALL")
        Me.btnREMOVEALL.Name = "btnREMOVEALL"
        Me.btnREMOVEALL.Tag = "btnREMOVEALL"
        '
        'btnMOVEALL
        '
        resources.ApplyResources(Me.btnMOVEALL, "btnMOVEALL")
        Me.btnMOVEALL.Name = "btnMOVEALL"
        Me.btnMOVEALL.Tag = "btnMOVEALL"
        '
        'lblGRPINBR
        '
        resources.ApplyResources(Me.lblGRPINBR, "lblGRPINBR")
        Me.lblGRPINBR.Name = "lblGRPINBR"
        Me.lblGRPINBR.Tag = "GRPINBR"
        '
        'lblGRPNOBR
        '
        resources.ApplyResources(Me.lblGRPNOBR, "lblGRPNOBR")
        Me.lblGRPNOBR.Name = "lblGRPNOBR"
        Me.lblGRPNOBR.Tag = "GRPNOBR"
        '
        'lstGRPINBR
        '
        resources.ApplyResources(Me.lstGRPINBR, "lstGRPINBR")
        Me.lstGRPINBR.Name = "lstGRPINBR"
        Me.lstGRPINBR.Tag = "GRPINBR"
        '
        'lstGRPNOBR
        '
        resources.ApplyResources(Me.lstGRPNOBR, "lstGRPNOBR")
        Me.lstGRPNOBR.Name = "lstGRPNOBR"
        Me.lstGRPNOBR.Tag = "GRPNOBR"
        '
        'frmBRGRP
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.tabBRGRP)
        Me.Name = "frmBRGRP"
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.tabBRGRP, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabBRGRP.ResumeLayout(False)
        Me.TabGENERAL.ResumeLayout(False)
        Me.TabGENERAL.PerformLayout()
        Me.TabGROUPS.ResumeLayout(False)
        Me.TabGROUPS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region " Declare constants and variables"
    Private mv_strBrid As String

    'Khai báo các bảng băm dùng chứa các thông tin NSD và nhóm
    Public hGrpOutBrFilter As New Hashtable
    Public hGrpInBrFilter As New Hashtable
    Public hBridInGrpFilter As New Hashtable
    Public hBridOutGrpFilter As New Hashtable
#End Region

#Region " Properties "
    
#End Region


#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            FillData2ListBox()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    'Insert data groups-branch to database
                    Dim v_strBranchId, v_strGrpInBr, v_strGrpBr As String
                    v_strBranchId = CStr(txtBRID.Text).Trim

                    For i As Integer = 0 To lstGRPINBR.Items.Count - 1
                        v_strGrpInBr &= hGrpInBrFilter(lstGRPINBR.Items.Item(i)) & "|"
                    Next

                    v_strGrpBr = v_strBranchId & "#" & v_strGrpInBr
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strGrpBr, "AddGroups2Branch")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    v_ws.Message(v_strObjMsg)

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        'S�ửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            TabGROUPS.Enabled = False
        ElseIf ExeFlag = ExecuteFlag.Edit Then
            txtBRID.Enabled = False
            TabGROUPS.Enabled = True
        ElseIf ExeFlag = ExecuteFlag.View Then
            btnMOVE.Enabled = False
            btnMOVEALL.Enabled = False
            btnREMOVE.Enabled = False
            btnREMOVEALL.Enabled = False
        End If
    End Sub

    ''----------------------------------------------------------------''
    ''-- Thủ tục lấy dữ liệu đi?n v�ào các textbox:                  --''
    ''-- Cụ thể: Lấy thông tin NSD đã trong nhóm và chưa trong nhóm --''
    ''-- rồi đi?n v�ào các textbox tương ứng                         --''
    ''----------------------------------------------------------------''
    Private Sub FillData2ListBox()
        Dim v_strGrpOutBrObjMsg, v_strGrpInBrObjMsg As String
        Dim v_strTLNAME, v_strValue As String
        Dim v_strFLDNAME As String
        Dim v_strFieldType As String
        Dim v_strSQL As String

        Try
            Dim v_strBranchId As String
            v_strBranchId = CStr(txtBRID.Text).Trim
            If v_strBranchId <> String.Empty Then
                'Select names of groups that are not in Branch
                v_strSQL = "SELECT M.GRPID VALUE, M.GRPNAME DISPLAY FROM TLGROUPS M WHERE M.GRPID NOT IN (SELECT PARAVALUE FROM BRGRPPARAM WHERE BRID = '" & v_strBranchId & "' AND PARATYPE = 'TLGROUPS') ORDER BY M.GRPNAME"
                v_strGrpOutBrObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
                Dim v_wsOutBr As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_wsOutBr.Message(v_strGrpOutBrObjMsg)
                Dim v_xmlOutBrDocument As New Xml.XmlDocument
                Dim v_nodeOutBrList As Xml.XmlNodeList

                v_xmlOutBrDocument.LoadXml(v_strGrpOutBrObjMsg)
                v_nodeOutBrList = v_xmlOutBrDocument.SelectNodes("/ObjectMessage/ObjData")
                Dim v_arrOutBrGRPID(v_nodeOutBrList.Count - 1) As String
                Dim v_arrOutBrGRPNAME(v_nodeOutBrList.Count - 1) As String
                Dim v_arrOutGrpBRID(v_nodeOutBrList.Count - 1) As String
                For i As Integer = 0 To v_nodeOutBrList.Count - 1
                    For j As Integer = 0 To v_nodeOutBrList.Item(i).ChildNodes.Count - 1
                        With v_nodeOutBrList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_arrOutBrGRPID(i) = v_strValue
                            Case "DISPLAY"
                                v_arrOutBrGRPNAME(i) = v_strValue
                                lstGRPNOBR.Items.Add(v_strValue)
                                'Case "BRID"
                                '    v_arrOutGrpBRID(i) = v_strValue
                        End Select
                    Next
                    hGrpOutBrFilter.Add(v_arrOutBrGRPNAME(i), v_arrOutBrGRPID(i))
                    'hBridOutGrpFilter.Add(v_arrOutGrpTLNAME(i), v_arrOutGrpBRID(i))
                Next

                ''''==== Select users' name that are in group ====''''
                v_strSQL = "SELECT A.GRPID VALUE, A.GRPNAME DISPLAY " _
                        & " FROM TLGROUPS A, BRGRPPARAM B, BRGRP C " _
                        & " WHERE A.GRPID = B.PARAVALUE AND B.PARATYPE = 'TLGROUPS' AND C.BRID = B.BRID AND B.BRID = '" & v_strBranchId & "' " _
                        & " ORDER BY A.GRPNAME "
                v_strGrpInBrObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
                Dim v_wsInBr As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_wsInBr.Message(v_strGrpInBrObjMsg)
                Dim v_xmlInBrDocument As New Xml.XmlDocument
                Dim v_nodeInBrList As Xml.XmlNodeList

                v_xmlInBrDocument.LoadXml(v_strGrpInBrObjMsg)
                v_nodeInBrList = v_xmlInBrDocument.SelectNodes("/ObjectMessage/ObjData")
                Dim v_arrInBrGRPID(v_nodeInBrList.Count - 1) As String
                Dim v_arrInBrGRPNAME(v_nodeInBrList.Count - 1) As String
                Dim v_arrInGrpBRID(v_nodeInBrList.Count - 1) As String
                For i As Integer = 0 To v_nodeInBrList.Count - 1
                    For j As Integer = 0 To v_nodeInBrList.Item(i).ChildNodes.Count - 1
                        With v_nodeInBrList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_arrInBrGRPID(i) = v_strValue
                            Case "DISPLAY"
                                v_arrInBrGRPNAME(i) = v_strValue
                                lstGRPINBR.Items.Add(v_strValue)
                                'Case "BRID"
                                '    v_arrInGrpBRID(i) = v_strValue
                        End Select
                    Next
                    hGrpInBrFilter.Add(v_arrInBrGRPNAME(i), v_arrInBrGRPID(i))
                    'hBridInGrpFilter.Add(v_arrInGrpTLNAME(i), v_arrInGrpBRID(i))
                Next
            Else
                'MsgBox(ResourceManager.GetString("BranchInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                'Exit Sub
            End If
            

        Catch ex As Exception
            Throw ex
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    ''----------------------------------------------''
    ''-- Thay đổi listbox khi thêm 1 NSD vào nhóm --''
    ''----------------------------------------------''
    Private Sub MoveOne()
        Try
            If Not lstGRPNOBR.SelectedItem Is Nothing Then
                lstGRPINBR.Items.Add(lstGRPNOBR.SelectedItem)
                hGrpInBrFilter.Add(lstGRPNOBR.SelectedItem, hGrpOutBrFilter(lstGRPNOBR.SelectedItem))
                'hBridInGrpFilter.Add(lstGRPNOBR.SelectedItem, hBridOutGrpFilter(lstGRPNOBR.SelectedItem))
                hGrpOutBrFilter.Remove(lstGRPNOBR.SelectedItem)
                'hBridOutGrpFilter.Remove(lstGRPNOBR.SelectedItem)
                lstGRPNOBR.Items.Remove(lstGRPNOBR.SelectedItem)
            Else
                MsgBox(ResourceManager.GetString("SelectedItem"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------------------''
    ''-- Thay đổi listbox khi thêm tất cả NSD vào nhóm --''
    ''---------------------------------------------------''
    Private Sub MoveAll()
        Try
            'Insert into list box
            lstGRPINBR.Items.AddRange(lstGRPNOBR.Items)
            'Insert values into "In group" hashtable and remove values from "Out group" hashtable
            For i As Integer = 0 To lstGRPNOBR.Items.Count - 1
                hGrpInBrFilter.Add(lstGRPNOBR.Items.Item(i), hGrpOutBrFilter(lstGRPNOBR.Items.Item(i)))
                'hBridInGrpFilter.Add(lstGRPNOBR.Items.Item(i), hBridOutGrpFilter(lstGRPNOBR.Items.Item(i)))
                hGrpOutBrFilter.Remove(lstGRPNOBR.Items.Item(i))
                'hBridOutGrpFilter.Remove(lstGRPNOBR.Items.Item(i))
            Next
            'Clear list box
            lstGRPNOBR.Items.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''------------------------------------------------''
    ''-- Thay đổi listbox khi b? 1 NSD ra kh�?i nh�óm --''
    ''------------------------------------------------''
    Private Sub ReMoveOne()
        Try
            If Not lstGRPINBR.SelectedItem Is Nothing Then
                'If CStr(hGrpInBrFilter(lstGRPINBR.SelectedItem)) <> BranchId Then
                'Insert item to "Out group" list box
                lstGRPNOBR.Items.Add(lstGRPINBR.SelectedItem)
                'Insert/Remove values to/from hashtables
                hGrpOutBrFilter.Add(lstGRPINBR.SelectedItem, hGrpInBrFilter(lstGRPINBR.SelectedItem))
                'hBridOutGrpFilter.Add(lstGRPINBR.SelectedItem, hBridInGrpFilter(lstGRPINBR.SelectedItem))
                hGrpInBrFilter.Remove(lstGRPINBR.SelectedItem)
                'hBridInGrpFilter.Remove(lstGRPINBR.SelectedItem)
                'Remove item from "In group" list box
                lstGRPINBR.Items.Remove(lstGRPINBR.SelectedItem)
                'Else
                '    MsgBox(ResourceManager.GetString("CurrentUser"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                '    Exit Sub
                'End If
            Else
                MsgBox(ResourceManager.GetString("SelectedItem"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''-----------------------------------------------------''
    ''-- Thay đổi listbox khi b? t�ất cả NSD ra kh?i nh�óm --''
    ''-----------------------------------------------------''
    Private Sub ReMoveAll()
        Try
            Dim v_strTellerName As String = String.Empty
            For i As Integer = 0 To lstGRPINBR.Items.Count - 1
                'If CStr(hGrpInBrFilter(lstGRPINBR.Items.Item(i))) <> BranchId Then
                    'Insert to "Out group" list box
                    lstGRPNOBR.Items.Add(lstGRPINBR.Items.Item(i))
                    'Insert/Remove values to/from hashtables
                    hGrpOutBrFilter.Add(lstGRPINBR.Items.Item(i), hGrpInBrFilter(lstGRPINBR.Items.Item(i)))
                    'hBridOutGrpFilter.Add(lstGRPINBR.Items.Item(i), hBridInGrpFilter(lstGRPINBR.Items.Item(i)))
                    hGrpInBrFilter.Remove(lstGRPINBR.Items.Item(i))
                    'hBridInGrpFilter.Remove(lstGRPINBR.Items.Item(i))
                    'Remove item from "In group" list box
                    'lstGRPINBR.Items.Remove(lstGRPINBR.Items.Item(i))
                'Else
                '    v_strTellerName = CStr(lstGRPINBR.Items.Item(i))
                'End If
            Next
            'Clear list box
            lstGRPINBR.Items.Clear()
            'If v_strTellerName <> String.Empty Then
            '    lstGRPINBR.Items.Add(v_strTellerName)
            '    MsgBox(ResourceManager.GetString("CurrentUser"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then

            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

#Region " Form events "

    Private Sub btnMOVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMOVE.Click
        MoveOne()
    End Sub

    Private Sub btnMOVEALL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMOVEALL.Click
        MoveAll()
    End Sub

    Private Sub btnREMOVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREMOVE.Click
        ReMoveOne()
    End Sub

    Private Sub btnREMOVEALL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREMOVEALL.Click
        ReMoveAll()
    End Sub
#End Region


End Class
