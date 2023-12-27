Public Class frmXtraSearch__ChooseTransaction
    Public DataRowChoose As DataRow
    Public v_hashTLTX As Hashtable

    Public Sub New(ByVal v_hashTLTX As Hashtable)
        InitializeComponent()
        Try
            Me.v_hashTLTX = v_hashTLTX
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmXtraSearch__ChooseTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hashtable to datatable
        Dim objKey As Object
        Dim dt As DataTable = New DataTable("DataTable")
        dt.Columns.Add(New DataColumn("TRANSACTION_CODE", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TRANSACTION_NAME", Type.GetType("System.String")))
        If v_hashTLTX IsNot Nothing Then
            For Each objKey In v_hashTLTX.Keys
                Dim r As DataRow = dt.NewRow()
                r("TRANSACTION_CODE") = objKey
                r("TRANSACTION_NAME") = v_hashTLTX.Item(objKey)
                dt.Rows.Add(r)
            Next
        End If
        grcChooseTransaction.DataSource = dt
        '

    End Sub

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim drv As DataRowView = Nothing
        Try
            drv = CType(grvChooseTransaction.GetFocusedRow, DataRowView)
        Catch ex As Exception
        End Try

        If drv Is Nothing Then
            MsgBox("Please select a transaction")
            Return
        End If

        DataRowChoose = drv.Row
        Me.Close()

    End Sub
End Class