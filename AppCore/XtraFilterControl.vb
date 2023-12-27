Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Filtering

Namespace Controls
    Public Class XtraFilterControl
        Inherits FilterControl

        Public Sub New()
        End Sub

        Public Function GetFilterDisplayText() As String
            Dim s As String = String.Empty
            For Each node As Node In Me.RootNode.SubNodes

                If Not node.GetNextNode().Equals(Me.RootNode.SubNodes(0)) Then
                    s += String.Format("{0} ", node.ParentNode.Text)
                End If

                node.Elements.ForEach(Function(x)
                                          If x.ElementType <> ElementType.NodeRemove Then s += x.Text & " "
                                      End Function)

            Next

            s.Trim()
            Return s
        End Function
    End Class
End Namespace

