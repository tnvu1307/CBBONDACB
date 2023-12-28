Imports CommonLibrary
Imports AppCore
Public Class frmApprove
    Inherits AppCore.frmMaintenance
    Public ChangeGrid As GridEx
    Public apprv As Boolean = False
    Private ResourceManager1 As Resources.ResourceManager
    Private ResourceManager2 As Resources.ResourceManager
    Const c_ResourceManager = gc_RootNamespace '"SIGMA"

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
    'Protected WithEvents lblCaption As System.Windows.Forms.Label
    Protected WithEvents btnApprove As System.Windows.Forms.Button
    Protected WithEvents btnReject As System.Windows.Forms.Button
    Protected WithEvents pnlChangeGrid As System.Windows.Forms.Panel
    Protected WithEvents Panel2 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlChangeGrid = New System.Windows.Forms.Panel
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnReject = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(8, 457)
        Me.cboLink.Name = "cboLink"
        Me.cboLink.Size = New System.Drawing.Size(121, 21)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(272, 457)
        Me.btnApprv.Name = "btnApprv"
        Me.btnApprv.Size = New System.Drawing.Size(75, 24)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(352, 457)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(432, 457)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 24)
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 54)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(792, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        '
        'pnlChangeGrid
        '
        Me.pnlChangeGrid.Location = New System.Drawing.Point(0, 56)
        Me.pnlChangeGrid.Name = "pnlChangeGrid"
        Me.pnlChangeGrid.Size = New System.Drawing.Size(872, 248)
        Me.pnlChangeGrid.TabIndex = 0
        Me.pnlChangeGrid.Tag = "pnlChangeGrid"
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(712, 328)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(75, 25)
        Me.btnApprove.TabIndex = 22
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(632, 328)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 25)
        Me.btnReject.TabIndex = 23
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 54)
        Me.Panel2.TabIndex = 3
        '
        'frmApprove
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(872, 375)
        Me.Controls.Add(Me.pnlChangeGrid)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnApprove)
        Me.Name = "frmApprove"
        Me.Text = "frmApprove"
        Me.Controls.SetChildIndex(Me.btnApprove, 0)
        Me.Controls.SetChildIndex(Me.btnReject, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.pnlChangeGrid, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmApprove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitExternal()
        LoadChangeGrid()
    End Sub
#Region "Khoi tao Grid"
    Private Sub InitExternal()

        Me.Text = ResourceManager.GetString("formText")
        Dim v_cmrSetSchHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrSetSchHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrSetSchHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        'Kh?i t?o Grid InOrder
        ChangeGrid = New GridEx

        Dim v_cmrInOrderHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrInOrderHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrInOrderHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ChangeGrid.FixedHeaderRows.Add(v_cmrInOrderHeader)
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("TLNAME", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("MAKER_DT", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("APPROVE_RQD", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("MOD_NUM", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("COLUMN_NAME", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("FROM_VALUE", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("TO_VALUE", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("ACTION_FLAG", GetType(System.String)))
        ChangeGrid.Columns.Add(New Xceed.Grid.Column("MAKER_TIME", GetType(System.String)))

        ChangeGrid.Columns("TLNAME").Title = ResourceManager.GetString("grid.TLNAME")
        ChangeGrid.Columns("MAKER_DT").Title = ResourceManager.GetString("grid.MAKER_DT")
        ChangeGrid.Columns("APPROVE_RQD").Title = ResourceManager.GetString("grid.APPROVE_RQD")
        ChangeGrid.Columns("MOD_NUM").Title = ResourceManager.GetString("grid.MOD_NUM")
        ChangeGrid.Columns("COLUMN_NAME").Title = ResourceManager.GetString("grid.COLUMN_NAME")
        ChangeGrid.Columns("FROM_VALUE").Title = ResourceManager.GetString("grid.FROM_VALUE")
        ChangeGrid.Columns("TO_VALUE").Title = ResourceManager.GetString("grid.TO_VALUE")
        ChangeGrid.Columns("ACTION_FLAG").Title = ResourceManager.GetString("grid.ACTION_FLAG")
        ChangeGrid.Columns("MAKER_TIME").Title = ResourceManager.GetString("grid.MAKER_TIME")

        ChangeGrid.Columns("TLNAME").Width = 100
        ChangeGrid.Columns("TLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("MAKER_DT").Width = 80
        ChangeGrid.Columns("MAKER_DT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("APPROVE_RQD").Width = 80
        ChangeGrid.Columns("APPROVE_RQD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("MOD_NUM").Width = 0
        ChangeGrid.Columns("MOD_NUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("APPROVE_RQD").Width = 70
        ChangeGrid.Columns("COLUMN_NAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("COLUMN_NAME").Width = 140
        ChangeGrid.Columns("FROM_VALUE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("FROM_VALUE").Width = 180
        ChangeGrid.Columns("TO_VALUE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("TO_VALUE").Width = 180
        ChangeGrid.Columns("ACTION_FLAG").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("ACTION_FLAG").Width = 180
        ChangeGrid.Columns("MAKER_TIME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ChangeGrid.Columns("MAKER_TIME").Width = 100
        Me.pnlChangeGrid.Controls.Clear()
        Me.pnlChangeGrid.Controls.Add(ChangeGrid)
        ChangeGrid.Dock = Windows.Forms.DockStyle.Fill

        btnApprove.Text = ResourceManager.GetString("btnApprove")
        btnReject.Text = ResourceManager.GetString("btnReject")
        btnCancel.Text = ResourceManager.GetString("btnCancel")
    End Sub
#End Region

#Region "Load du lieu cho Grid"
    Private Sub FillDataGrid(ByVal pv_xGrid As Xceed.Grid.GridControl, _
                        ByVal pv_strObjMsg As String, _
                        ByVal pv_strResource As String, _
                        Optional ByVal pv_strTable As String = "", _
                        Optional ByVal pv_strFilter As String = "", _
                        Optional ByVal pv_intFromrow As Int32 = 0, _
                        Optional ByVal pv_intTorow As Int32 = 0, _
                        Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim v_dt As DataTable
        Dim v_dr As DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_xGrid.DataRows.Clear()
            pv_xGrid.BeginInit()

            For v_intCount = 0 To v_nodeList.Count - 1
                Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()

                For Each v_xColumn In pv_xGrid.Columns
                    Dim resourceManagerName As String = ""
                    Dim childData As Boolean = False
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = Convert.ToString(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = Convert.ToString(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                            If UCase(v_strFLDNAME = "CHILD_TABLE_NAME") And v_strValue <> "" Then
                                childData = True
                                If resourceManagerName <> v_strValue Then
                                    resourceManagerName = v_strValue
                                    ResourceManager2 = New Resources.ResourceManager(c_ResourceManager & ".frm" & resourceManagerName & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
                                End If
                            End If

                            If UCase(v_strFLDNAME) = UCase(Trim(v_xColumn.FieldName)) Then
                                If UCase(v_xColumn.FieldName) <> "SIGNATURE" Then
                                    If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue = "0", False, True)
                                    Else
                                        Select Case v_xColumn.DataType.Name
                                            Case GetType(System.String).Name
                                                'Neu du lieu la "thong tin sua" thi lay mo ta tuong ung tu resource cua tung phan he
                                                If (v_strFLDNAME = "COLUMN_NAME" And v_strValue <> "Tạo mới thông tin" And resourceManagerName <> "AFTEMPLATES") Then
                                                    If childData Then
                                                        Dim tabName As String = Convert.ToString(ResourceManager2.GetString("frm" & resourceManagerName))
                                                        'v_xDataRow.Cells(v_xColumn.FieldName).Value = tabName & "." & IIf(v_strValue Is DBNull.Value, "", Convert.ToString(ResourceManager2.GetString(v_strValue)))
                                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = tabName & IIf(v_strValue Is DBNull.Value, "", Convert.ToString(ResourceManager2.GetString(v_strValue)))
                                                    Else
                                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", Convert.ToString(ResourceManager1.GetString(v_strValue)))
                                                    End If
                                                Else
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", Convert.ToString(v_strValue))
                                                End If
                                            Case GetType(System.Decimal).Name
                                                If v_strValue = "" Then
                                                    v_strValue = 0
                                                End If
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                                            Case GetType(Integer).Name
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                                            Case GetType(Long).Name
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                                            Case GetType(Double).Name
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                            Case GetType(System.DateTime).Name
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                                            Case GetType(System.Boolean).Name
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", Convert.ToString(v_strValue))
                                            Case Else
                                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                                        End Select
                                    End If
                                    v_xDataRow.EndEdit()
                                End If
                            End If
                        End With
                    Next
                Next
                '  End If
            Next

            pv_xGrid.EndInit()
            _FormatGridBefore(pv_xGrid, pv_strTable, pv_strResource, False, , pv_intFromrow, pv_intTorow, pv_intTotalrow)
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub LoadChangeGrid()
        Try
            Dim v_strClause As String

            Select Case KeyFieldType
                Case "C"
                    v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select
            If Not ChangeGrid Is Nothing Then
                'Remove các bản ghi cu
                ChangeGrid.DataRows.Clear()
                Dim v_strSQL As String
                Dim v_ws As New BDSDeliveryManagement
                If Not TableName.Equals("CFMAST") Then
                    v_strSQL = "SELECT ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, APPROVE_ID, APPROVE_DT, MOD_NUM, COLUMN_NAME, FROM_VALUE, TO_VALUE, B.TLNAME, Maker_Time " & ControlChars.CrLf _
                               & " FROM " & ControlChars.CrLf _
                               & "(SELECT table_name, record_key, maker_id, maker_dt, approve_rqd, approve_id, approve_dt, mod_num, column_name, from_value, to_value, action_flag, child_table_name, child_record_key, maker_time FROM MAINTAIN_LOG " & ControlChars.CrLf _
                               & " UNION ALL SELECT '" & TableName & "', '" & Replace(v_strClause, "'", "") & "', null, null, 'Y', null, null, 0, 'Tạo mới thông tin', null, null, null, null, null, null FROM " & TableName & " WHERE " & v_strClause & ") A, TLPROFILES B WHERE MAKER_ID = TLID(+) AND " & ControlChars.CrLf _
                               & " TABLE_NAME = '" & TableName & "' AND " & ControlChars.CrLf _
                               & " RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND APPROVE_ID IS NULL AND " & ControlChars.CrLf _
                               & " MOD_NUM >= (SELECT NVL(MIN(MOD_NUM),0) FROM MAINTAIN_LOG WHERE " & ControlChars.CrLf _
                                                   & " APPROVE_RQD = 'Y' AND " & ControlChars.CrLf _
                                                   & " TABLE_NAME = '" & TableName & "' AND " & ControlChars.CrLf _
                                                   & " RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND APPROVE_ID IS NULL) ORDER BY MOD_NUM ASC, MAKER_DT DESC, MAKER_TIME DESC"
                Else
                    v_strSQL = "SELECT ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, APPROVE_ID, APPROVE_DT, MOD_NUM, COLUMN_NAME, FROM_VALUE, TO_VALUE, B.TLNAME, Maker_Time " & ControlChars.CrLf _
                                                   & " FROM " & ControlChars.CrLf _
                                                   & "(SELECT table_name, record_key, maker_id, maker_dt, approve_rqd, approve_id, approve_dt, mod_num, column_name, from_value, to_value, action_flag, child_table_name, child_record_key, maker_time FROM MAINTAIN_LOG " & ControlChars.CrLf _
                                                   & " UNION ALL SELECT '" & TableName & "', '" & Replace(v_strClause, "'", "") & "', null, null, 'Y', null, null, 0, 'Tạo mới thông tin', null, null, null, null, null, null FROM " & TableName & " WHERE " & v_strClause & ") A, TLPROFILES B WHERE MAKER_ID = TLID(+) AND " & ControlChars.CrLf _
                                                   & " ((TABLE_NAME = '" & TableName & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') " & ControlChars.CrLf _
                                                        & " OR (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where STATUS = 'P' AND " & v_strClause & "))) " & ControlChars.CrLf _
                                                   & " AND APPROVE_ID IS NULL AND " & ControlChars.CrLf _
                                                   & " MOD_NUM >= (SELECT NVL(MIN(MOD_NUM),0) FROM MAINTAIN_LOG WHERE " & ControlChars.CrLf _
                                                                       & " APPROVE_RQD = 'Y' AND " & ControlChars.CrLf _
                                                                       & " ((TABLE_NAME = '" & TableName & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') " & ControlChars.CrLf _
                                                        & " OR (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where STATUS = 'P' AND " & v_strClause & "))) AND APPROVE_ID IS NULL) " & ControlChars.CrLf _
                                                & " ORDER BY MOD_NUM ASC, MAKER_DT DESC, MAKER_TIME DESC"
                End If
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, "SA.SYSVAR", gc_ActionInquiry, v_strSQL)

                v_ws.Message(v_strObjMsg)
                'v_ws.Close()
                FillDataGrid(ChangeGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Dim v_strObjMsg As String
        Dim v_strSQL As String
        'Dim v_blnFirstAppr As Boolean = False
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try

            If ChangeGrid.DataRows.Count = 0 Then
                MsgBox(ResourceManager.GetString("NothingToApprove"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Return
            End If
            Dim v_ws As New BDSDeliveryManagement

            ''VanNT
            'If ObjectName = OBJNAME_CF_AFMAST Then
            '    v_strSQL = "SELECT ACCTNO FROM DDMAST WHERE AFACCTNO = '" & KeyFieldValue & "' "
            '    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
            '    v_ws.Message(v_strObjMsg)
            '    v_xmlDocument.LoadXml(v_strObjMsg)
            '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '    If Not v_nodeList Is Nothing Then
            '        If v_nodeList.Count > 0 Then
            '            v_blnFirstAppr = False
            '        Else
            '            v_blnFirstAppr = True
            '        End If
            '    End If
            'End If
            ''VanNT Ended

            Dim v_strClause As String

            Select Case KeyFieldType
                Case "C"
                    v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select
            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionApprove, , v_strClause)


            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            Dim v_strErrorSource, v_strErrorMessage As String            

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            'If v_blnFirstAppr = True Then
            '    Dim v_ParaString As New System.Text.StringBuilder
            '    Dim v_strMsgCode As String = "PG652"
            '    Dim v_strFuncName As String = "getAcctBalance"
            '    Dim v_strFLDNAME, v_strVALUE, v_strVNDACCT, v_strGOLDACCT, v_strBANKCIF, v_strCCYCD, v_strBRCODE As String

            '    v_strSQL = "SELECT BANKAC FROM ACMAP WHERE AFACCTNO = '" & KeyFieldValue & "' AND CCYCD = '00'"
            '    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
            '    v_ws.Message(v_strObjMsg)
            '    v_xmlDocument.LoadXml(v_strObjMsg)
            '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '    For v_intCount As Integer = 0 To v_nodeList.Count - 1
            '        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
            '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
            '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
            '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
            '                Select Case v_strFLDNAME
            '                    Case "BANKAC"
            '                        v_strVNDACCT = Trim(v_strVALUE)
            '                End Select
            '            End With
            '        Next
            '    Next

            '    v_strSQL = "SELECT BANKAC, SHORTCD FROM ACMAP, SBCURRENCY WHERE AFACCTNO = '" & KeyFieldValue & "' AND ACMAP.CCYCD <> '00' " & _
            '            "AND ACMAP.CCYCD = SBCURRENCY.CCYCD "
            '    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
            '    v_ws.Message(v_strObjMsg)
            '    v_xmlDocument.LoadXml(v_strObjMsg)
            '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '    For v_intCount As Integer = 0 To v_nodeList.Count - 1
            '        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
            '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
            '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
            '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
            '                Select Case v_strFLDNAME
            '                    Case "BANKAC"
            '                        v_strGOLDACCT = Trim(v_strVALUE)
            '                    Case "SHORTCD"
            '                        v_strCCYCD = Trim(v_strVALUE)
            '                End Select
            '            End With
            '        Next
            '    Next

            '    If v_strGOLDACCT.Length < 4 Or v_strVNDACCT.Length < 4 Then
            '        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , KeyFieldValue, "RestoreApproveAction")
            '        v_ws.Message(v_strObjMsg)
            '        MsgBox(ResourceManager.GetString("ApprovalFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            '        Exit Sub
            '    End If

            '    If v_strGOLDACCT.Substring(0, 4) <> v_strVNDACCT.Substring(0, 4) Then
            '        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , KeyFieldValue, "RestoreApproveAction")
            '        v_ws.Message(v_strObjMsg)
            '        MsgBox(ResourceManager.GetString("BranchCodeErr"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            '        Exit Sub
            '    End If

            '    v_strBRCODE = v_strVNDACCT.Substring(0, 4)

            '    v_strSQL = "SELECT BANKCIFID FROM CFMAST, AFMAST WHERE AFMAST.ACCTNO = '" & KeyFieldValue & "' AND AFMAST.CUSTID = CFMAST.CUSTID "
            '    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strSQL)
            '    v_ws.Message(v_strObjMsg)
            '    v_xmlDocument.LoadXml(v_strObjMsg)
            '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '    For v_intCount As Integer = 0 To v_nodeList.Count - 1
            '        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
            '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
            '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
            '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
            '                Select Case v_strFLDNAME
            '                    Case "BANKCIFID"
            '                        v_strBANKCIF = v_strVALUE
            '                End Select
            '            End With
            '        Next
            '    Next


            '    v_ParaString.Append("<parameters REFERENCE='' MSGCODE='" & v_strMsgCode & "' REFNUM='' SRC='" & v_strFuncName & "' TLTXCD='' IPADDRESS='' WSNAME='' BRID='' TLID=''>")
            '    Dim v_strSettleDate As String = Me.BusDate.Substring(6, 4) & Me.BusDate.Substring(3, 2) & Me.BusDate.Substring(0, 2)
            '    v_ParaString.Append("<entry fldname='SETTLEDATE' fldval='" & v_strSettleDate & "'></entry>")
            '    v_ParaString.Append("<entry fldname='BRANCHCODE' fldval='" & v_strBRCODE & "'></entry>")
            '    v_ParaString.Append("<entry fldname='CIF' fldval='" & v_strBANKCIF & "'></entry>")
            '    v_ParaString.Append("<entry fldname='VNDACCT' fldval='" & v_strVNDACCT & "'></entry>")
            '    v_ParaString.Append("<entry fldname='GOLDACCT' fldval='" & v_strGOLDACCT & "'></entry>")
            '    v_ParaString.Append("<entry fldname='GOLDACCTCCY' fldval='" & v_strCCYCD & "'></entry>")
            '    v_ParaString.Append("</parameters>")
            '    Dim v_strSendMessage As String = BuildSendGWMsg(Me.BusDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, , gc_ActionInquiry, , v_strFuncName, v_ParaString.ToString, , )
            '    Dim v_wsAuth As New AuthWS.AuthService
            '    Dim v_lngError As Long = v_wsAuth.Message(v_strSendMessage)
            '    If v_lngError <> ERR_SYSTEM_OK Then
            '        v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , KeyFieldValue, "RestoreApproveAction")
            '        v_ws.Message(v_strObjMsg)
            '        Dim v_node As Xml.XmlNode
            '        Dim v_strReturnMsg, v_strErrMsg As String
            '        v_strErrMsg = ResourceManager.GetString("GetBankAcctnoError")
            '        v_xmlDocument.LoadXml(v_strSendMessage)
            '        v_node = v_xmlDocument.SelectSingleNode(gc_SCHEMA_SENDGWMESSAGE_RETURNMSG)
            '        v_strReturnMsg = v_node.InnerText
            '        If v_strReturnMsg <> "" Then
            '            v_xmlDocument.LoadXml(v_strReturnMsg)
            '            v_node = v_xmlDocument.SelectSingleNode("msg/para[@name='errormsg']")
            '            If Not v_node Is Nothing Then
            '                v_strErrMsg = v_node.InnerText
            '            End If
            '        End If
            '        MsgBox(v_strErrMsg, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            '        Exit Sub
            '    End If
            'End If

            MsgBox(ResourceManager.GetString("ApproveSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            Me.apprv = True
            MyBase.OnClose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("ApprovalFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(c_ResourceManager & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        ResourceManager1 = New Resources.ResourceManager(c_ResourceManager & ".frm" & TableName & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        lblCaption.Text = ResourceManager.GetString("Caption")
    End Sub

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Dim v_strObjMsg As String
        Try
            If ChangeGrid.DataRows.Count = 0 Then
                MsgBox(ResourceManager.GetString("NothingToReject"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Return
            End If
            Dim v_strClause As String

            Select Case KeyFieldType
                Case "C"
                    v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionReject, , v_strClause)

            Dim v_ws As New BDSDeliveryManagement
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            Dim v_strErrorSource, v_strErrorMessage As String

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            MsgBox(ResourceManager.GetString("RejectSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            MyBase.OnClose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("ApprovalFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
