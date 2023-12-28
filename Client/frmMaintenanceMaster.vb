Imports CommonLibrary
Public Class frmMaintenanceMaster
    Inherits AppCore.frmMaster

    Public Sub New(ByVal v_strTableName As String, ByVal v_intExecFlag As Integer, ByVal v_strUserLanguage As String, ByVal v_strModuleCode As String, _
                    ByVal v_strFullObjName As String, ByVal v_strIsLocalSearch As String, ByVal v_strFormCaption As String, ByVal v_strTellerId As String, _
                    ByVal v_strTellerRight As String, ByVal v_strGroupCareBy As String, ByVal v_strAuthString As String, ByVal v_strBranchId As String, _
                    ByVal v_strBusDate As String, ByVal v_strKeyColumn As String, ByVal v_strKeyFieldType As String, ByVal v_strKeyFieldValue As String, _
                    ByVal v_strLinkValue As String, ByVal v_strLinkField As String, ByVal v_strParentValue As String, ByVal v_strParentObject As String, _
                    ByVal v_strParentModule As String, ByVal v_objRefField As Object, ByVal v_strParentClause As String, _
                    ByVal v_strCompanyCode As String, ByVal v_strCompanyName As String)

        MyBase.New(v_strTableName, v_intExecFlag, v_strUserLanguage, v_strModuleCode, _
                   v_strFullObjName, v_strIsLocalSearch, v_strFormCaption, v_strTellerId, _
                   v_strTellerRight, v_strGroupCareBy, v_strAuthString, v_strBranchId, _
                   v_strBusDate, v_strKeyColumn, v_strKeyFieldType, v_strKeyFieldValue, _
                   v_strLinkValue, v_strLinkField, v_strParentValue, v_strParentObject, _
                   v_strParentModule, v_objRefField, v_strParentClause, v_strCompanyCode, v_strCompanyName)

    End Sub

    Public Overrides Sub OnApprove()
        If ObjectName <> "SA.CRBTRFLOG" Then
            'Luong duyet form maintanance
            Dim v_frm As New frmApprv
            v_frm.ExeFlag = ExeFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = ObjectName
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

            v_frm.LinkValue = LinkValue
            v_frm.LinkField = LinkField
            v_frm.ShowDialog()
            Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()
            'v_strSender = String.Empty
        Else
            'Luong duyet bang ke
            If MsgBox(ResourceManager.GetString("ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String
                Dim v_strClause As String = ""
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                v_strClause = "AUTOID = " & KeyFieldValue & ""

                v_strObjMsg = CommonLibrary.BuildXMLObjMsg(Me.BusDate, Me.BranchId, , Me.TellerId, "N", "O", OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "ApproveTrfReport", , , , )
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    MsgBox(ResourceManager.GetString("ApproveSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                End If
            End If
            
        End If

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmMaintenanceMaster
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "frmMaintenanceMaster"
        Me.ResumeLayout(False)

    End Sub
End Class
