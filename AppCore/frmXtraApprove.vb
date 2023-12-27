Imports CommonLibrary
Public Class frmXtraApprove
#Region " Khai báo biến, hằng "
    Const c_ResourceManager = "AppCore.frmXtraApprove-"
    Private mv_blnIsRiskManagement As Boolean = False
    Private mv_blnIsReject As Boolean = False
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
    Private mv_strObjlogid As String


    Private hLinkSrc As New Hashtable
    Private hLinkDes As New Hashtable
    Private mv_strNextDate As String
    Public mv_frmSearchScreen As frmSearch

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
    Public Property Objlogid() As String
        Get
            Return mv_strObjlogid
        End Get
        Set(ByVal Value As String)
            mv_strObjlogid = Value
        End Set
    End Property
#End Region

    Private Sub frmXtraApprove_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mv_resourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitGridFromSearchCode("MAINTAINLOG", Me.gridMAINTAIN, Me.grvMAINTAIN, " AND nvl( o.pautoid,o.autoid) = ' " & Objlogid & "'", "Y", "Y", UserLanguage)

        btnApprove.Text = ResourceManager.GetString("btnApprove")
        btnReject.Text = ResourceManager.GetString("btnReject")
        btnCancel.Text = ResourceManager.GetString("btnCancel")
        Me.Text = ResourceManager.GetString("frmXtraApprove")
        If IsReject Then
            btnReject.Enabled = True
            btnApprove.Enabled = False
        Else
            btnReject.Enabled = False
            btnApprove.Enabled = True
        End If
    End Sub


    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Dim v_strObjMsg As String
        Dim v_strSQL As String
        'Dim v_blnFirstAppr As Boolean = False
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strClause As String
            v_strClause = Objlogid
            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionApprove, , v_strClause)


            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
            Dim v_strErrorSource, v_strErrorMessage As String

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            MsgBox(ResourceManager.GetString("ApproveSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim v_strObjMsg As String
        Try
           
            Dim v_strClause As String
            v_strClause = Objlogid
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionReject, , v_strClause)

            Dim v_ws As New BDSDeliveryManagement
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            Dim v_strErrorSource, v_strErrorMessage As String

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            MsgBox(ResourceManager.GetString("RejectSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("ApprovalFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
End Class