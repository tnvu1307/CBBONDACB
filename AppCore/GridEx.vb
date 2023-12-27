Imports Xceed.Grid
Imports System.Windows.Forms

<Serializable()> _
Public Class GridEx
    Inherits GridControl

    Public Sub New(ByVal pv_strTable As String, ByVal pv_strResource As String)
        MyBase.New()

        'License
        Licenser.LicenseKey = "GRD38-NH0NZ-R858H-RYDA"
        AddHandler KeyUp, AddressOf G_KeyUp
        'Thiết lập một số thuộc tính chung nhất của GRID
        _FormatGridBefore(Me, pv_strTable, pv_strResource)
    End Sub

    Public Sub New()
        MyBase.New()

        'License
        Licenser.LicenseKey = "GRD38-NH0NZ-R858H-RYDA"
        AddHandler KeyUp, AddressOf G_KeyUp
        'Thiết lập một số thuộc tính chung nhất của GRID
        _FormatGridBefore(Me, , , False, False)
    End Sub

    Private Sub G_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Control.C
                    Dim strToClipboard As String = ""
                    Dim selections = TryCast(sender, GridEx).SelectedRows
                    If (selections.Count > 0) Then
                        For i As Integer = 0 To selections.Count - 1
                            Dim r As DataRow = selections(i)
                            If (r Is Nothing) Then
                                Continue For
                            End If

                            For j As Integer = 0 To r.Cells.Count - 1
                                strToClipboard += Convert.ToString(r.Cells(j).Value) + Convert.ToChar(9)
                            Next
                            strToClipboard += Environment.NewLine
                        Next
                    End If
                    If Not String.IsNullOrEmpty(strToClipboard) Then
                        Clipboard.SetText(strToClipboard)
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

End Class
