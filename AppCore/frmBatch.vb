Imports CommonLibrary
Imports System.Windows.Forms

Public Class frmBatch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstExecute As System.Windows.Forms.ListBox
    Friend WithEvents lblBusDate As System.Windows.Forms.Label
    Friend WithEvents lstSchedule As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblConfirm As System.Windows.Forms.Label
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents lblNextDatedata As System.Windows.Forms.Label
    Friend WithEvents lblCurrDate As System.Windows.Forms.Label
    Friend WithEvents lblNextDate As System.Windows.Forms.Label
    Friend WithEvents chkCheckAll As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNextDatedata = New System.Windows.Forms.Label()
        Me.lblBusDate = New System.Windows.Forms.Label()
        Me.lblNextDate = New System.Windows.Forms.Label()
        Me.lblCurrDate = New System.Windows.Forms.Label()
        Me.lstExecute = New System.Windows.Forms.ListBox()
        Me.lstSchedule = New System.Windows.Forms.CheckedListBox()
        Me.chkCheckAll = New System.Windows.Forms.CheckBox()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(632, 547)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(712, 547)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblNextDatedata)
        Me.Panel1.Controls.Add(Me.lblBusDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 50)
        Me.Panel1.TabIndex = 20
        '
        'lblNextDatedata
        '
        Me.lblNextDatedata.BackColor = System.Drawing.Color.Gray
        Me.lblNextDatedata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextDatedata.ForeColor = System.Drawing.Color.Lime
        Me.lblNextDatedata.Location = New System.Drawing.Point(682, 13)
        Me.lblNextDatedata.Name = "lblNextDatedata"
        Me.lblNextDatedata.Size = New System.Drawing.Size(100, 23)
        Me.lblNextDatedata.TabIndex = 3
        Me.lblNextDatedata.Tag = "lblNextDatedata"
        Me.lblNextDatedata.Text = "01/02/2006"
        Me.lblNextDatedata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBusDate
        '
        Me.lblBusDate.BackColor = System.Drawing.Color.Gray
        Me.lblBusDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusDate.ForeColor = System.Drawing.Color.Lime
        Me.lblBusDate.Location = New System.Drawing.Point(452, 13)
        Me.lblBusDate.Name = "lblBusDate"
        Me.lblBusDate.Size = New System.Drawing.Size(100, 23)
        Me.lblBusDate.TabIndex = 0
        Me.lblBusDate.Text = "01/02/2006"
        Me.lblBusDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNextDate
        '
        Me.lblNextDate.AutoSize = True
        Me.lblNextDate.Location = New System.Drawing.Point(566, 18)
        Me.lblNextDate.Name = "lblNextDate"
        Me.lblNextDate.Size = New System.Drawing.Size(38, 13)
        Me.lblNextDate.TabIndex = 32
        Me.lblNextDate.Tag = "lblNextDate"
        Me.lblNextDate.Text = "Label3"
        '
        'lblCurrDate
        '
        Me.lblCurrDate.AutoSize = True
        Me.lblCurrDate.Location = New System.Drawing.Point(368, 18)
        Me.lblCurrDate.Name = "lblCurrDate"
        Me.lblCurrDate.Size = New System.Drawing.Size(38, 13)
        Me.lblCurrDate.TabIndex = 31
        Me.lblCurrDate.Tag = "lblCurrDate"
        Me.lblCurrDate.Text = "Label2"
        '
        'lstExecute
        '
        Me.lstExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lstExecute.HorizontalScrollbar = True
        Me.lstExecute.Location = New System.Drawing.Point(400, 56)
        Me.lstExecute.Name = "lstExecute"
        Me.lstExecute.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstExecute.Size = New System.Drawing.Size(384, 485)
        Me.lstExecute.TabIndex = 24
        '
        'lstSchedule
        '
        Me.lstSchedule.Location = New System.Drawing.Point(8, 56)
        Me.lstSchedule.Name = "lstSchedule"
        Me.lstSchedule.Size = New System.Drawing.Size(384, 484)
        Me.lstSchedule.TabIndex = 25
        '
        'chkCheckAll
        '
        Me.chkCheckAll.Location = New System.Drawing.Point(8, 546)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(104, 24)
        Me.chkCheckAll.TabIndex = 26
        Me.chkCheckAll.Tag = "chkCheckAll"
        Me.chkCheckAll.Text = "CheckAll"
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Location = New System.Drawing.Point(439, 552)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(38, 13)
        Me.lblConfirm.TabIndex = 30
        Me.lblConfirm.Tag = "lblConfirm"
        Me.lblConfirm.Text = "Label1"
        '
        'txtConfirm
        '
        Me.txtConfirm.Location = New System.Drawing.Point(494, 549)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.Size = New System.Drawing.Size(100, 21)
        Me.txtConfirm.TabIndex = 29
        Me.txtConfirm.Tag = "txtConfirm"
        '
        'frmBatch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.lblCurrDate)
        Me.Controls.Add(Me.lblNextDate)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.chkCheckAll)
        Me.Controls.Add(Me.lstSchedule)
        Me.Controls.Add(Me.lstExecute)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBatch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBatch"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Khai báo biến, hằng "
    Const c_ResourceManager = "AppCore.frmBatch-"
    Const c_WEB_SERVICE_TIMEOUT = 3600000
    Private mv_BlnBeforeBatch As Boolean
    Private mv_intExecFlag As Integer
    Private mv_strLanguage As String
    Private mv_resourceManager As Resources.ResourceManager

    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String

    Private mv_arrBatchCmd() As String

    Private mv_strBranchId As String
    Private mv_strTellerId As String

    Private mv_strLocalObject As String
    Private mv_strBusDate As String = String.Empty
    Public mv_AutoBatchDone As Boolean = False
#End Region

#Region " Properties "
    Public Property IsBeforeBatch() As Boolean
        Get
            Return mv_BlnBeforeBatch
        End Get
        Set(ByVal Value As Boolean)
            mv_BlnBeforeBatch = Value
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
#End Region

#Region " Form function "
    Private Sub OnClose()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_resourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        'Nạp dữ liệu cho danh sách mục cần đồng bộ
        LoadBatchCmd()
    End Sub

    Private Sub LoadBatchCmd()
        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strObjMsg As String
            Dim v_strAPPTYPE, v_strBCHMDL, v_strBCHTITLE, v_strMSQ, v_strRUNAT, v_strROWPERPAGE, v_strBCHSUCPAGE, v_strBCHDATE, v_strACTION As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin v? ng�ày làm việc hiện tại
            v_strSQL = "SELECT SBCLDR.*, GETNEXTWORKINGDATE(SBCLDR.SBDATE) SBNEXTDATE FROM SYSVAR, SBCLDR " _
                    & "WHERE SBCLDR.CLDRTYPE='000' AND SYSVAR.GRNAME = 'SYSTEM' AND SYSVAR.VARNAME='CURRDATE' AND TO_DATE(SYSVAR.VARVALUE,'" & gc_FORMAT_DATE & "')=SBCLDR.SBDATE"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_CLDR, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strSBDATE, v_strSBBUSDAY, v_strSBEOW, v_strSBEOM, v_strSBEOQ, v_strSBEOY, _
                v_strSBBOW, v_strSBBOM, v_strSBBOQ, v_strSBBOY, v_strHOLIDAY, v_strNextDate As String
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "SBDATE"
                                v_strSBDATE = v_strValue
                            Case "SBBUSDAY"
                                v_strSBBUSDAY = v_strValue
                            Case "HOLIDAY"
                                v_strHOLIDAY = v_strValue
                            Case "SBEOW"
                                v_strSBEOW = v_strValue
                            Case "SBEOM"
                                v_strSBEOM = v_strValue
                            Case "SBEOQ"
                                v_strSBEOQ = v_strValue
                            Case "SBEOY"
                                v_strSBEOY = v_strValue
                            Case "SBBOW"
                                v_strSBBOW = v_strValue
                            Case "SBBOM"
                                v_strSBBOM = v_strValue
                            Case "SBBOQ"
                                v_strSBBOQ = v_strValue
                            Case "SBBOY"
                                v_strSBBOY = v_strValue
                            Case "SBNEXTDATE"
                                v_strNextDate = v_strValue
                        End Select
                    End With
                Next
            Next
            Me.lblBusDate.Text = v_strSBDATE
            Me.lblNextDatedata.Text = v_strNextDate

            'Lấy thông tin chung v? tham s�ố chạy batch
            'v_strSQL = "SELECT * FROM SBBATCHCTL ORDER BY BCHSQN"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BATCH, gc_ActionInquiry, v_strSQL)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BATCH, gc_ActionAdhoc, )
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Me.lstSchedule.Items.Clear()
            ReDim mv_arrBatchCmd(v_nodeList.Count - 1)
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "APPTYPE"
                                v_strAPPTYPE = v_strValue
                            Case "BCHMDL"
                                v_strBCHMDL = v_strValue
                            Case "BCHTITLE"
                                v_strBCHTITLE = v_strValue
                            Case "MSQ"
                                v_strMSQ = v_strValue
                            Case "RUNAT"
                                v_strRUNAT = v_strValue
                            Case "ROWPERPAGE"
                                v_strROWPERPAGE = v_strValue
                            Case "BCHSUCPAGE"
                                v_strBCHSUCPAGE = v_strValue
                            Case "BCHDATE"
                                v_strBCHDATE = v_strValue
                            Case "ACTION"
                                v_strACTION = v_strValue
                        End Select
                    End With
                Next
                If IsBeforeBatch Then
                    If Trim(v_strACTION) = "BF" Then
                        mv_arrBatchCmd(i) = v_strMSQ
                        If CInt(v_strROWPERPAGE) <= 0 Then
                            Me.lstSchedule.Items.Add(v_strAPPTYPE & "." & v_strBCHMDL & ": " & v_strBCHTITLE)
                        Else
                            Me.lstSchedule.Items.Add(v_strAPPTYPE & "." & v_strBCHMDL & ": " & v_strBCHTITLE & "(" & CInt(v_strROWPERPAGE) & ")[" & CInt(v_strBCHSUCPAGE) & "]")
                        End If
                    End If
                Else
                    mv_arrBatchCmd(i) = v_strMSQ
                    If CInt(v_strROWPERPAGE) <= 0 Then
                        Me.lstSchedule.Items.Add(v_strAPPTYPE & "." & v_strBCHMDL & ": " & v_strBCHTITLE)
                    Else
                        Me.lstSchedule.Items.Add(v_strAPPTYPE & "." & v_strBCHMDL & ": " & v_strBCHTITLE & "(" & CInt(v_strROWPERPAGE) & ")[" & CInt(v_strBCHSUCPAGE) & "]")
                    End If
                End If


                'End If
            Next
            If Me.lstSchedule.Items.Count > 0 Then
                For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                    lstSchedule.SetItemChecked(i, True)
                Next
            End If

            'If v_strBCHDATE <> Me.BusDate Then
            '    btnOK.Enabled = False
            'End If

            Me.chkCheckAll.Checked = True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnSubmit()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            'Lấy danh sách các bước chạy Batch trong danh sách để đẩy lên Host thực hiện
            'Cấu trúc message theo dạng Object Message với các trư?ng ch�ính là thứ tự chạy Batch

            Dim v_strObjMsg, v_strValue, v_strBatch, v_strFillter As String, i, j, k As Integer, pv_xmlDocument As New Xml.XmlDocument
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrFLDTYPE As Xml.XmlAttribute, v_attrLENGTH As Xml.XmlAttribute, v_attrOLDVAL As Xml.XmlAttribute
            'Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'v_ws.Timeout = c_WEB_SERVICE_TIMEOUT

            'Duyệt toàn bộ danh sách các bước chạy Batch để nạp vào message
            'Mỗi bước batch khi thực hiện xong sẽ được remove ra kh?i danh s�ách


            'Me.lstExecute.Items.Clear()
            If Me.lstSchedule.Items.Count > 0 Then
                For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                    If i > Me.lstSchedule.Items.Count - 1 Then
                        Exit For
                    End If
                    If lstSchedule.GetItemChecked(i) = True Then
                        'Chạy lần lượt từng bước
                        v_strBatch = CType(lstSchedule.Items(i), String)
                        j = InStr(v_strBatch, ":")
                        v_strValue = Mid(v_strBatch, 1, j - 1)
                        j = InStr(v_strBatch, "(")
                        k = InStr(v_strBatch, ")")
                        Dim v_intRowPerPage As Double
                        If j > 0 Then
                            v_intRowPerPage = CDbl(Mid(v_strBatch, j + 1, k - j - 1))
                        Else
                            v_intRowPerPage = 0
                        End If

                        j = InStr(v_strBatch, "[")
                        k = InStr(v_strBatch, "]")
                        Dim v_intBCHPage As Double
                        If j > 0 Then
                            v_intBCHPage = (CDbl(Mid(v_strBatch, j + 1, k - j - 1)) + 1) / v_intRowPerPage
                        Else
                            v_intBCHPage = 0
                        End If

                        If v_intRowPerPage = 0 Then
                            v_strFillter = " AND 0=0 "
                            'v_strObjMsg = BuildXMLObjMsg(Me.lblBusDate.Text, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strFillter, "BatchExecute", , , "-1", IsBeforeBatch)
                            'LINHLNB change for longtimeout 
                            v_strObjMsg = BuildXMLObjMsg(Me.lblBusDate.Text, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionBatch, , v_strFillter, "BatchExecute", , , "-1", IsBeforeBatch)
                            BuildXMLObjMsg(v_strObjMsg)
                            pv_xmlDocument.LoadXml(v_strObjMsg)
                            v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")



                            'Append entry to data node
                            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
                            v_attrFLDNAME.Value = v_strValue
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
                            v_attrFLDTYPE.Value = "System.String"
                            v_entryNode.Attributes.Append(v_attrFLDTYPE)

                            'Add current value
                            v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
                            v_attrOLDVAL.Value = v_strValue
                            v_entryNode.Attributes.Append(v_attrOLDVAL)

                            v_entryNode.InnerText = v_strBatch
                            v_dataElement.AppendChild(v_entryNode)

                            pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            '?�ẩy message chạy Batch lên HOST
                            v_strObjMsg = pv_xmlDocument.InnerXml
                            Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
                            'TruongLD Comment when convert
                            'v_ws.Timeout = c_WEB_SERVICE_TIMEOUT
                            v_lngError = v_ws.Message(v_strObjMsg)
                            pv_xmlDocument.LoadXml(v_strObjMsg)

                            'Giải phóng web-service
                            'TruongLD Comment when convert
                            'v_ws.Dispose()

                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                                'Cập nhật màn hình trạng thái chạy Batch
                                Me.lstExecute.Items.Add(v_strBatch & "..." & mv_resourceManager.GetString("failed"))
                                Me.Refresh()
                                Exit Sub
                            Else
                                Me.lstExecute.Items.Add(v_strBatch & "..." & mv_resourceManager.GetString("done"))
                                Me.lstSchedule.Items.Remove(CType(lstSchedule.Items(i), String))
                                i = i - 1
                                Me.Refresh()
                            End If
                        Else
                            Dim v_intMaxRow As Double
                            Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
                            Do
                                v_strFillter = " AND INDEXROW BETWEEN " & v_intBCHPage * v_intRowPerPage & " AND " & (v_intBCHPage + 1) * v_intRowPerPage - 1 & " "
                                'v_strObjMsg = BuildXMLObjMsg(Me.lblBusDate.Text, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strFillter, "BatchExecute", , , ((v_intBCHPage + 1) * v_intRowPerPage - 1).ToString, IsBeforeBatch)
                                'LINHLNB add for long time out
                                v_strObjMsg = BuildXMLObjMsg(Me.lblBusDate.Text, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionBatch, , v_strFillter, "BatchExecute", , , ((v_intBCHPage + 1) * v_intRowPerPage - 1).ToString, IsBeforeBatch)
                                BuildXMLObjMsg(v_strObjMsg)
                                pv_xmlDocument.LoadXml(v_strObjMsg)
                                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")



                                'Append entry to data node
                                v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                                'Add field name
                                v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
                                v_attrFLDNAME.Value = v_strValue
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
                                v_attrFLDTYPE.Value = "System.String"
                                v_entryNode.Attributes.Append(v_attrFLDTYPE)

                                'Add current value
                                v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
                                v_attrOLDVAL.Value = v_strValue
                                v_entryNode.Attributes.Append(v_attrOLDVAL)

                                v_entryNode.InnerText = v_strBatch
                                v_dataElement.AppendChild(v_entryNode)

                                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                                '?�ẩy message chạy Batch lên HOST
                                v_strObjMsg = pv_xmlDocument.InnerXml
                                'TruongLD Comment when convert
                                'v_ws.Timeout = c_WEB_SERVICE_TIMEOUT
                                v_lngError = v_ws.Message(v_strObjMsg)
                                pv_xmlDocument.LoadXml(v_strObjMsg)

                                'Giải phóng web-service
                                'TruongLD Comment when convert
                                'v_ws.Dispose()

                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                                    'Cập nhật màn hình trạng thái chạy Batch
                                    Me.lstExecute.Items.Add(v_strBatch & "..." & mv_resourceManager.GetString("failedatpage") & v_intBCHPage.ToString & "!")
                                    Me.Refresh()
                                    Exit Sub
                                Else
                                    Me.lstExecute.Items.Add(v_strBatch & "..." & mv_resourceManager.GetString("donepage") & v_intBCHPage.ToString & ")")
                                    Me.Refresh()
                                End If
                                v_intBCHPage = v_intBCHPage + 1
                                v_intMaxRow = CDbl(Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value.ToString))
                                If v_intBCHPage * v_intRowPerPage > v_intMaxRow Then
                                    Exit Do
                                End If
                            Loop
                            Me.lstSchedule.Items.Remove(CType(lstSchedule.Items(i), String))
                            i = i - 1
                            Me.Refresh()
                        End If

                    End If
                Next

                'Me.lstSchedule.Items.Clear()

                'Me.lstSchedule.Items.Remove(lstSchedule.Items)
                'Dim myEnumerator As IEnumerator
                'myEnumerator = lstSchedule.CheckedIndices.GetEnumerator
                'While myEnumerator.MoveNext() <> False
                '    If lstSchedule.GetItemChecked(myEnumerator.Current) = True Then
                '        lstSchedule.Items.RemoveAt(myEnumerator.Current)
                '        myEnumerator.Reset()
                '    Else
                '    End If
                'End While

            End If

            If v_lngError = ERR_SYSTEM_OK Then
                'Cập nhật kết quả trả v?
                MsgBox(mv_resourceManager.GetString("BATCH_RUN_SUCCESS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                'trung.luu: 07-04-2020 batch xong tu tat
                Me.mv_AutoBatchDone = True
                Me.Close()
                Exit Sub
                'End trung.luu 07-04-2020
            End If

            'Reset l�ại màn hình
            For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                lstSchedule.SetItemChecked(i, False)
            Next

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_resourceManager.GetString("frmBatch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_resourceManager.GetString("frmBatch." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_resourceManager.GetString("frmBatch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_resourceManager.GetString(v_ctrl.Name)
            End If
        Next
        If IsBeforeBatch Then
            Me.Text = mv_resourceManager.GetString("frmBFBatch")
        Else
            Me.Text = mv_resourceManager.GetString("frmBatch")
        End If

    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtConfirm.Text = "CONFIRM" Then
            OnSubmit()
        Else
            MsgBox(mv_resourceManager.GetString("CONFIRM"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            txtConfirm.Focus()
        End If
    End Sub

    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmBatch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                If txtConfirm.Text = "CONFIRM" Then
                    OnSubmit()
                Else
                    MsgBox(mv_resourceManager.GetString("CONFIRM"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    txtConfirm.Focus()
                End If
        End Select
    End Sub

    Private Sub frmBatch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.Click
        Dim i As Integer
        If Me.chkCheckAll.Checked = True Then
            If Me.lstSchedule.Items.Count > 0 Then
                For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                    lstSchedule.SetItemChecked(i, True)
                Next
            End If
        Else
            If Me.lstSchedule.Items.Count > 0 Then
                For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                    lstSchedule.SetItemChecked(i, False)
                Next
            End If
        End If
    End Sub
    Private Sub lstSchedule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSchedule.SelectedIndexChanged
        Dim i, count As Integer
        count = 0
        If Me.lstSchedule.Items.Count > 0 Then
            For i = 0 To Me.lstSchedule.Items.Count - 1 Step 1
                If lstSchedule.GetItemChecked(i) = True Then
                    count = count + 1
                End If
            Next
            If count = Me.lstSchedule.Items.Count Then
                Me.chkCheckAll.Checked = True
            Else
                Me.chkCheckAll.Checked = False
            End If
        End If

    End Sub
#End Region

End Class
