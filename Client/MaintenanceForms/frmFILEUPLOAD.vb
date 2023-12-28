Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports AppCore
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text
Imports System.Globalization
Imports System.Configuration
Imports System.Threading
Imports DevExpress.XtraPdfViewer

Public Class frmFILEUPLOAD
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public WithEvents DLPPIPOGrid As GridEx
    Private mv_strREFID, mv_strCODEID As String
    Private mv_byarray As Byte()
#End Region

#Region " Properties "
    Public Property REFID() As String
        Get
            Return mv_strREFID
        End Get
        Set(ByVal Value As String)
            mv_strREFID = Value
        End Set
    End Property

    Public Property CODEID() As String
        Get
            Return mv_strCODEID
        End Get
        Set(ByVal Value As String)
            mv_strCODEID = Value
        End Set
    End Property
#End Region

    Property extImageFileAllows As String() = {"*.jpg", "*.jpeg", "*.jpe", "*.jfif", "*.png"}
    Property extFileAllows As String = String.Join(",", extImageFileAllows) + "," + "*.pdf" + "," + "*.zip"
    Property extFileAllows2 As String = String.Join(";", extImageFileAllows) + ";" + "*.pdf" + ";" + "*.zip"
#Region "private sub"
    Public Overrides Sub OnInit()
        picture1.Visible = False
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        MyBase.OnInit()
        LoadUserInterface(Me)
        'FormInit()
        If ExeFlag = ExecuteFlag.AddNew Then
            GetFILELOAD()
            FillLookUpEditDOCTYPE()
            lblClientName.Text = String.Empty
            btnSave.Enabled = False
        ElseIf ExeFlag = ExecuteFlag.View Then
            getClientName()
            btnSave.Enabled = True
            SimpleButton1.Enabled = False
        Else
            getClientName()
            btnSave.Enabled = True
        End If
        teTXNUM.BackColor = Color.GreenYellow

    End Sub
    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        'Load rieng cho form
        'txtCODEID.Text = CODEID
        If ExeFlag = ExecuteFlag.Edit Then
            'txtBIDCODE.Enabled = False
            'txtCITADCODE.Enabled = False
        End If
    End Sub
    Private Sub GetFILELOAD()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = "select SEQ_FILEUPLOAD.nextval ID from dual"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
            gc_ActionInquiry, v_strSQL, , )
        v_ws.Message(v_strObjMsg)
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strFLDNAME, v_strValue, v_strID, v_strFUNDNAME As String
        v_strID = String.Empty
        XmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "ID"
                            v_strID = CStr(v_strValue).Trim
                            txtAUTOID.Text = v_strID
                    End Select
                End With
            Next
        Next
    End Sub

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            'Check valid
            Return MyBase.VerifyRules
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            'If CInt(mv_lngFileSize / 1024 / 1024) > 9 Then
            '    MsgBox(ResourceManager.GetString("INVALIDFILESIZE"), MsgBoxStyle.Critical, gc_ApplicationTitle)
            '    Exit Sub
            'End If
            'Verify data 
            If (VerifyRule() = False) Then
                Exit Sub
            End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , " AUTOID = '" & txtAUTOID.Text & "'", , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    If (v_lngErrorCode = 0) Then
                        'v_ws.UploadFile(mv_dsTypeBytes, "AUTOID", txtAUTOID.Text, TableName)
                        mv_dsTypeBytes = Nothing
                    End If
                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK

                    Me.Dispose()
                Case ExecuteFlag.Edit

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , " AUTOID = '" & txtAUTOID.Text & "'")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    If (v_lngErrorCode = 0) Then
                        'v_ws.UploadFile(mv_dsTypeBytes, "AUTOID", txtAUTOID.Text, TableName)
                        mv_dsTypeBytes = Nothing
                    End If

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    Me.Dispose()
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

    Private Sub txtFileUpload_EditValueChanged(sender As Object, e As EventArgs) Handles txtFileUpload.EditValueChanged
        Dim control As ButtonEditCustom = CType(sender, ButtonEditCustom)
        If control IsNot Nothing And Not String.IsNullOrEmpty(control.Text) Then
            control.Properties.Buttons(0).Visible = True
            If (control.ActionControl = ButtonEditCustom.ActionEnum.EDIT) Then
                mv_byarray = control.DataByte
                PreviewFilePath(control.DataByte)
            End If

        Else
            control.Properties.Buttons(0).Visible = False
        End If
    End Sub


    Public Sub PreviewFilePath(ByVal pathFile As String)
        panelPreview.Controls.Clear()
        Dim ext As String = Path.GetExtension(pathFile)
        If Not String.IsNullOrEmpty(ext) Then
            Dim extImageFileStr As String = String.Join(",", extImageFileAllows)
            If (extFileAllows.Contains(ext.ToLower)) Then
                If (ext.ToUpper().Contains("PDF")) Then
                    Dim pdfViewer As PdfViewer = New PdfViewer()
                    pdfViewer.DocumentFilePath = pathFile
                    pdfViewer.Dock = DockStyle.Fill
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(pdfViewer)
                ElseIf (ext.ToUpper().Contains("ZIP")) Then
                    Dim txtzip As TextBox = New TextBox()
                    txtzip.Text = pathFile
                    txtzip.Dock = DockStyle.Left
                    txtzip.Enabled = False
                    txtzip.Dock = DockStyle.Top
                    txtzip.ReadOnly = True
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(txtzip)
                Else 'Image
                    Dim picture As PictureBox = New PictureBox()
                    picture.Image = Image.FromFile(pathFile)
                    picture.SizeMode = PictureBoxSizeMode.AutoSize
                    picture1 = New DevExpress.XtraEditors.PictureEdit
                    picture1.Image = Image.FromFile(pathFile)
                    picture1.Dock = DockStyle.Fill
                    picture1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True
                    picture1.Properties.ShowScrollBars = True
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(picture1)
                End If
            End If
        End If
    End Sub

    Public Sub PreviewFilePath(ByVal byteArr As Byte())
        panelPreview.Controls.Clear()

        Dim pdfViewer As PdfViewer = New PdfViewer()
        If (IsValidImage(byteArr)) Then
            picture1 = New DevExpress.XtraEditors.PictureEdit
            picture1.Image = ByteToImage(byteArr)
            picture1.Dock = DockStyle.Fill
            'picture1.SizeMode = PictureBoxSizeMode.AutoSize
            picture1.Dock = DockStyle.Fill
            picture1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True
            picture1.Properties.ShowScrollBars = True
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(picture1)
            byteArr = Nothing
        ElseIf IsValidPdf(byteArr, pdfViewer) Then
            pdfViewer.Dock = DockStyle.Fill
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(pdfViewer)
            byteArr = Nothing
        Else
            Dim txtzip As TextBox = New TextBox()
            txtzip.Text = ResourceManager.GetString("ZIP")
            txtzip.Dock = DockStyle.Left
            txtzip.Dock = DockStyle.Top
            txtzip.Enabled = False
            txtzip.ReadOnly = True
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(txtzip)
            byteArr = Nothing
        End If
    End Sub

    Public Function ByteToImage(ByVal blob As Byte()) As Bitmap
        Dim mStream As MemoryStream = New MemoryStream()
        mStream.Write(blob, 0, Convert.ToInt32(blob.Length))
        Dim bm As Bitmap = New Bitmap(mStream, False)
        mStream.Dispose()
        Return bm
    End Function

    Public Function IsValidPdf(ByVal bytes As Byte(), ByVal pdfViewer As PdfViewer) As Boolean
        Try
            Dim ms As MemoryStream = New MemoryStream(bytes)
            pdfViewer.LoadDocument(ms)
            Return True
        Catch ex As Exception

            Return False
        End Try
        Return False
    End Function

    Public Function IsValidImage(ByVal bytes As Byte()) As Boolean
        Try
            Using ms As MemoryStream = New MemoryStream(bytes)
                Image.FromStream(ms)
            End Using
        Catch ex As Exception

            Return False
        End Try
        Return True
    End Function
    Public Function IsValidZip(ByVal bytes As Byte(), ByVal path As String) As Boolean
        Try
            'If (Not Directory.Exists(path)) Then
            '    Directory.CreateDirectory(path)
            'End If
            File.WriteAllBytes(path, bytes)
            Return True
        Catch ex As Exception

            Return False
        End Try
        Return True
    End Function


    Dim mv_lngFileSize As Long = 0
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Using openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "Image & Pdf files (" + extFileAllows + ") | " + extFileAllows2
            openFileDialog.FilterIndex = 2
            openFileDialog.RestoreDirectory = True
            'openFileDialog.Multiselect = True 'trung.luu : 23-10-2020 add nhieu file
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                'For Each File In openFileDialog.FileNames
                '    Dim urlFile As String = File.ToString
                '    mv_lngFileSize = FileLen(urlFile)
                '    txtFileUpload.SetPath(urlFile)
                '    PreviewFilePath(urlFile)
                'Next
                Dim urlFile As String = openFileDialog.FileName
                mv_lngFileSize = FileLen(urlFile)
                'txtSIGNATURE.Text = urlFile 'Path.GetFileName(urlFile)
                txtFileUpload.SetPath(urlFile)
                PreviewFilePath(urlFile)
            End If
        End Using
    End Sub

    Private Sub txtFileUpload_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFileUpload.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            txtFileUpload.Text = ""
            panelPreview.Controls.Clear()
            txtFileUpload.DataByte = Nothing
        End If
    End Sub
    Private Sub FillLookUpEditDOCTYPE()
        Try
            Dim v_strTAGLIST As String = String.Empty, v_strDefValue As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement
            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                If mv_arrObjFields(i).FieldName = "DOCTYPE" Then
                    v_strTAGLIST = mv_arrObjFields(i).TagList
                    v_strDefValue = mv_arrObjFields(i).DefaultValue
                    Exit For
                End If
            Next
            v_strTAGLIST = v_strTAGLIST.Replace("<$TAGFIELD>", lueBUSINESS.EditValue)
            Dim v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strTAGLIST)
            v_ws.Message(v_strObjMsg)
            Dim result As DataTable = ObjDataToDataset(v_strObjMsg)
            BindingXtraLookUpEdit(result, lueDOCTYPE.Properties, Nothing)
            If v_strDefValue <> String.Empty Then
                lueDOCTYPE.EditValue = v_strDefValue
            Else
                SetLookUpEditDefaultValue(lueDOCTYPE, "")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub lueBUSINESS_EditValueChanged(sender As Object, e As EventArgs) Handles lueBUSINESS.EditValueChanged
        If lueBUSINESS.EditValue Is Nothing Then
            Exit Sub
        End If
        FillLookUpEditDOCTYPE()

    End Sub

    Private Sub deCREATEDATE_EditValueChanged(sender As Object, e As EventArgs) Handles deCREATEDATE.EditValueChanged
        Try
            teTXNUM.EditValue = String.Empty
        Catch ex As Exception

        End Try
    End Sub


    Private Sub teTXNUM_KeyUp(sender As Object, e As KeyEventArgs) Handles teTXNUM.KeyUp
        If Me.deTXDATE.EditValue Is Nothing Then
            MsgBox(ResourceManager.GetString("TXDATE_NOTHING"), MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            e.Handled = False
            deTXDATE.Focus()
        End If
        Select Case e.KeyCode
            Case Keys.F5

                Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                frm.TableName = "TXNUMBYTXDATE"
                frm.ModuleCode = "SA"
                frm.AuthCode = "NYNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.LinkValue = deTXDATE.EditValue
                frm.ShowDialog()
                'Sua theo yeu cau cua loi SNGP156 va SNGP394 cua SBS
                If Not (Me.ExeFlag = ExecuteFlag.Approve Or Me.ExeFlag = ExecuteFlag.View) AndAlso Not (frm.ReturnValue Is Nothing) Then
                    Me.ActiveControl.Text = frm.ReturnValue
                End If
                frm.Dispose()
        End Select
    End Sub

    Private Function OnValidation(Optional pv_control As String = "ALL") As Boolean
        Try
            If pv_control = "ALL" OrElse pv_control = teTXNUM.Name Then
                If Len(Me.teTXNUM.EditValue) > 0 Then
                    Dim v_strSQL = "SELECT COUNT(1) CNT FROM vw_tllog_all tllog, tlprofiles tl, tlprofiles ck WHERE tllog.tlid = tl.tlid(+) and tllog.offid = ck.tlid(+) and  txstatus IN ('4', '1') and tllog.tlid not in ('0000','6868') and txdate = TO_DATE('<$KEYVALUE>', 'dd/mm/rrrr')"
                    v_strSQL = v_strSQL.Replace("<$KEYVALUE>", deTXDATE.EditValue)
                    Dim v_ws As New BDSDeliveryManagement
                    Dim v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    Dim result As DataTable = ObjDataToDataset(v_strObjMsg)
                    If result.Rows.Count = 0 Then
                        MsgBox(ResourceManager.GetString("TXNUM_INVALID"), MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    End If
                End If
            End If

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub teTXNUM_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles teTXNUM.Validating
        OnValidation(teTXNUM.Name)

    End Sub

    Private Sub getClientName()
        lblClientName.Text = String.Empty

        Try
            Dim v_client As String = teCLIENT.EditValue.ToString
            If v_client = String.Empty Then
                Exit Sub
            End If
            Dim v_strSQL = "SELECT fullname from famembers where autoid = " & v_client
            Dim v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlNodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strValue, v_strFLDNAME As String
            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value))
                        If v_strFLDNAME = "FULLNAME" Then
                            lblClientName.Text = v_strValue
                            Exit Sub
                        End If
                    End With
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub teCLIENT_Validated(sender As Object, e As EventArgs) Handles teCLIENT.Validated
        getClientName()
    End Sub
    'trung.luu: 07-10-2020
    Private Sub panelPreview_MouseDown(sender As Object, e As MouseEventArgs) Handles panelPreview.MouseDown
        Try
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                btnDownLoad.Caption = ResourceManager.GetString("DOWNLOAD")
                popmenu.ShowPopup(Control.MousePosition)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDownLoad_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDownLoad.ItemClick
        If panelPreview.Controls.Count > 0 Then
            Dim ctrls = panelPreview.Controls
            If (ctrls Is Nothing OrElse ctrls.Count <> 1) Then
                MsgBox("File not found!")
                Return
            End If

            Dim ctrl = ctrls(0)
            Try
                If (TypeOf (ctrl) Is PdfViewer) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.pdf"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
                            CType(ctrl, PdfViewer).SaveDocument(ms)
                            Dim file As FileStream = New FileStream(pth.FileName, FileMode.Create, FileAccess.Write)
                            ms.WriteTo(file)
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End Using
                    End If
                ElseIf (TypeOf (ctrl) Is PictureBox) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.jpg"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        CType(ctrl, PictureBox).Image.Save(pth.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End If
                Else
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.zip"
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim filename As String = pth.FileName
                        If IsValidZip(mv_byarray, pth.FileName) Then
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            mv_byarray = Nothing
                        Else
                            MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End Try
            'Dim saveFileDialog As New SaveFileDialog()
            'saveFileDialog.FilterIndex = 2
            'saveFileDialog.RestoreDirectory = True
            'saveFileDialog.Filter = "Image ,Pdf & zip files (" + extFileAllows + ") | " + extFileAllows2

            'If saveFileDialog.ShowDialog() = DialogResult.OK Then
            '    Dim filename As String = saveFileDialog.FileName
            '    If IsValidZip(mv_byarray, Path.GetDirectoryName(saveFileDialog.FileName), Path.GetFileName(saveFileDialog.FileName)) Then
            '        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    End If
            'End If
        End If
    End Sub
    Private Sub picture1_MouseDown(sender As Object, e As MouseEventArgs)
        Try
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                btnDownLoad.Caption = ResourceManager.GetString("DOWNLOAD")
                popmenu.ShowPopup(Control.MousePosition)
            End If
        Catch ex As Exception

        End Try
    End Sub
    'trung.luu: 07-10-2020

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim ctrls = panelPreview.Controls
            If (ctrls Is Nothing OrElse ctrls.Count <> 1) Then
                MsgBox("File not found!")
                Return
            End If

            Dim ctrl = ctrls(0)
            If (TypeOf (ctrl) Is PdfViewer) Then

                Dim pth As SaveFileDialog = New SaveFileDialog()
                pth.Filter = "Images|*.pdf"
                Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

                If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
                        CType(ctrl, PdfViewer).SaveDocument(ms)
                        Dim file As FileStream = New FileStream(pth.FileName, FileMode.Create, FileAccess.Write)
                        ms.WriteTo(file)
                        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End Using
                End If


            ElseIf (TypeOf (ctrl) Is PictureBox) Then

                Dim pth As SaveFileDialog = New SaveFileDialog()
                pth.Filter = "Images|*.jpg"
                Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    CType(ctrl, PictureBox).Image.Save(pth.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            Else
                Dim pth As SaveFileDialog = New SaveFileDialog()
                pth.Filter = "Images|*.zip"
                If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Dim filename As String = pth.FileName
                    If IsValidZip(mv_byarray, pth.FileName) Then
                        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        mv_byarray = Nothing
                    Else
                        MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
End Class