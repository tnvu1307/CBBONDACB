Imports ZetaCompressionLibrary
Imports System.IO
Imports System.Windows.Forms
Imports TestBase64
Imports CommonLibrary
Imports DevExpress.XtraEditors
Imports System.Data

Public Class FormControlUtil
    Public Shared Sub GetControlValue(ByRef pv_dr As DataRow, ByVal mv_arrObjFields() As CFieldMaster, ByVal ctrlParent As Windows.Forms.Control)

        Dim controls = GetAllHasTag(ctrlParent)
        If (controls Is Nothing Or controls.Count = 0) _
            Or pv_dr Is Nothing Or pv_dr.Table Is Nothing Or pv_dr.Table.Columns.Count = 0 _
            Or mv_arrObjFields Is Nothing Then
            Return
        End If

        For Each ctrl As Control In controls

            Dim tag As String = ctrl.Tag.ToString().ToUpper()
            Dim objField As CFieldMaster = mv_arrObjFields.FirstOrDefault(Function(x) x IsNot Nothing AndAlso x.FieldName = tag)

            If objField Is Nothing Or Not pv_dr.Table.Columns.Contains(tag) Then
                Continue For
            End If

            If TypeOf (ctrl) Is TextBox _
                Or TypeOf (ctrl) Is TextEdit _
                Or TypeOf (ctrl) Is MemoEdit Then
                Dim value As String = IIf(Not String.IsNullOrEmpty(ctrl.Text), ctrl.Text, "")
                If objField IsNot Nothing And objField.FieldType = "N" Then ' Truong hop textbox la so
                    IIf(Decimal.TryParse(value, pv_dr(tag)), pv_dr(tag), pv_dr(tag) = 0)
                    Continue For
                End If
                pv_dr(tag) = value
            ElseIf TypeOf (ctrl) Is LookUpEdit _
                Or TypeOf (ctrl) Is GridLookUpEdit _
                Or TypeOf (ctrl) Is GridLookUpEdit Then
                Dim baseEdit As BaseEdit = CType(ctrl, BaseEdit)
                If baseEdit Is Nothing Or baseEdit.EditValue Is Nothing Then
                    Return
                End If
                pv_dr(tag) = baseEdit.EditValue
            ElseIf TypeOf (ctrl) Is DateEdit Then
                Dim dateEdit As DateEdit = CType(ctrl, DateEdit)
                If dateEdit IsNot Nothing Then
                    pv_dr(tag) = dateEdit.EditValue.ToShortDateString()
                End If
            ElseIf TypeOf (ctrl) Is PictureBox Then
                pv_dr(tag) = GetStringFromImage(CType(ctrl, PictureBox))
            ElseIf TypeOf (ctrl) Is FlexMaskEditBox Then
                Dim value As String = IIf(Not String.IsNullOrEmpty(ctrl.Text), ctrl.Text, "")
                pv_dr(tag) = value
            ElseIf TypeOf (ctrl) Is DateTimePicker Then
                Dim dateTimePicker As DateTimePicker = CType(ctrl, DateTimePicker)
                pv_dr(tag) = dateTimePicker.Value.ToShortDateString()
            ElseIf TypeOf (ctrl) Is ComboBoxEx Then
                Dim comboBoxEx As ComboBoxEx = CType(ctrl, ComboBoxEx)
                pv_dr(tag) = comboBoxEx.SelectedValue
            ElseIf TypeOf (ctrl) Is CheckedListBox Then
                Dim checkedListBox As CheckedListBox = CType(ctrl, CheckedListBox)
                Dim v_AllCode As String = ""
                If CType(ctrl, CheckedListBox).CheckedItems.Count = 0 Then
                    v_AllCode = ""
                Else
                    Dim v_ds As New DataSet
                    Dim v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim v_strValue, v_strFLDNAME, v_SQL As String
                    Dim j, k As Integer
                    v_AllCode = ""

                    v_SQL = objField.LookupList
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
                    If CType(ctrl, CheckedListBox).GetItemChecked(0) Then
                        For l As Integer = 0 To v_arrCdval.Length - 1
                            If UCase(v_arrCdName(l)) = "ALL" Then
                                v_AllCode = v_arrCdval(l)
                            End If
                        Next
                    Else
                        For j = 1 To CType(ctrl, CheckedListBox).Items.Count - 1
                            If CType(ctrl, CheckedListBox).GetItemChecked(j) Then
                                For k = 0 To v_arrCdval.Length - 1
                                    If CType(ctrl, CheckedListBox).Items(j).ToString = v_arrCdName(k) Then
                                        v_AllCode = v_AllCode & Trim(v_arrCdval(k)) & "|"
                                    End If
                                Next
                            End If
                        Next
                        v_AllCode = Microsoft.VisualBasic.Left(v_AllCode, v_AllCode.Length - 1)
                    End If
                End If
                pv_dr(tag) = v_AllCode
            End If
        Next
    End Sub

    Protected Sub SetControlValue(ByRef pv_ctrl As Windows.Forms.Control, _
                                ByVal pv_strFLDNAME As String, _
                                ByVal pv_strFLDTYPE As String, _
                                ByVal pv_strFLDVAL As String, ByVal pv_strDATATYPE As String)

        Dim controls = GetAllHasTag(pv_ctrl)
        If (controls Is Nothing Or controls.Count = 0) Then
            Return
        End If

        For Each ctrl As Control In controls
            Dim tag As String = ctrl.Tag.ToString().ToUpper()
            If Not pv_strFLDNAME.Equals(tag) Then
                Continue For
            End If
            ' Chua code tiep

        Next



    End Sub

    Public Shared Function GetAllHasTag(ByVal control As Control) As System.Collections.Generic.IEnumerable(Of Control)
        Dim controls As System.Collections.Generic.IEnumerable(Of Control)
        Try
            controls = control.Controls.Cast(Of Control)()
            controls = controls.SelectMany(Function(x) GetAllHasTag(x)).Concat(controls) _
                .Where(Function(x) x.Tag IsNot Nothing)
        Catch ex As Exception
            controls = Nothing
        End Try
        Return controls
    End Function

    Private Shared Function GetStringFromImage(ByVal pv_PicBox As PictureBox) As String

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
End Class
