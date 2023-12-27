Imports DevExpress.XtraBars

Public Class BarButtonItemEx
    Inherits BarButtonItem

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal bar As BarManager, ByVal text As String)
        MyBase.New(bar, text)
    End Sub

    Public Property Key As String
End Class
