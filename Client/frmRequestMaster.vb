Public Class frmRequestMaster
    Inherits AppCore.frmReportList_Tab

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region " Form Events "
    Protected Overrides Function InitDialog()
        MyBase.InitDialog()
        Try

            Me.btnGenerate.Visible = False
            Me.btnPrint.Visible = False
            Me.btnView.Visible = False
            Me.btnDownload.Visible = False
            Me.btnRptPending.Visible = False
            Me.cboBRID.Enabled = False
            Me.cboEXCYCLE.Enabled = False
            Me.grbReportOption.Visible = False

            Me.grbReportList.Location = New System.Drawing.Point(6, 55)
            Me.grbReportList.Size = New System.Drawing.Size(780, 355)

            Me.pnlReportList.Location = New System.Drawing.Point(5, 20)
            Me.pnlReportList.Size = New System.Drawing.Size(780, 320)

            Me.btnRecreat.Location = New System.Drawing.Point(631, 426)
        Catch ex As Exception

        End Try
    End Function

    Protected Overrides Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Protected Overrides Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'OnGenerate()
        OnCreateReq()
    End Sub

    Protected Overrides Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_strSTRAUTH, v_strPrint, v_strAdd, v_strArea As String
            Dim dr As DataRowView = viewRPT.GetFocusedRow()

            If Not dr Is Nothing Then
                v_strSTRAUTH = CStr(dr.Row("STRAUTH")).Trim
                v_strPrint = "N"
                v_strAdd = "N"
                v_strArea = "A"
                If Len(Trim(v_strSTRAUTH)) > 0 Then
                    v_strAdd = Mid(v_strSTRAUTH, 2, 1)
                End If
                btnRecreat.Enabled = (v_strAdd = "Y")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Overrides Sub OnReCreate()
        OnCreateReq()
    End Sub

#End Region


End Class
