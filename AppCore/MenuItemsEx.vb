Public Class MenuItemEx
    Inherits System.Windows.Forms.ToolStripMenuItem
    Private mv_strKey As String

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal text As String)
        MyBase.New(text)
    End Sub

    Public Property Key() As String
        Get
            Return mv_strKey
        End Get
        Set(ByVal Value As String)
            mv_strKey = Value
        End Set
    End Property
End Class
