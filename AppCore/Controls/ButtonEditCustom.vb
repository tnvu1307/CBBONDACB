Imports System.IO

Public Class ButtonEditCustom

    Private Property _dataByte As Byte()
    Public Property DataByte As Byte()
        Get
            If ActionControl = ActionEnum.EDIT Then
                Return _dataByte
            End If

            If Not String.IsNullOrEmpty(Me.FullPath) Then
                Return File.ReadAllBytes(Me.FullPath)
            End If
            Return _dataByte
        End Get
        Set(value As Byte())
            _dataByte = value
        End Set
    End Property

    Public Sub SetValue(ByVal strBase64 As String)
        ActionControl = ActionEnum.EDIT
        If String.IsNullOrEmpty(strBase64) Then
            Return
        End If

        Me.DataByte = Convert.FromBase64String(strBase64)
        If Me.DataByte IsNot Nothing Then
            Me.Text = "(You want to edit the File, please select a new image)"
        End If
    End Sub

    Public Sub SetValue(ByVal data As System.Byte())
        ActionControl = ActionEnum.EDIT
        If data Is Nothing Then
            Return
        End If

        Me.DataByte = data
        If Me.DataByte IsNot Nothing Then
            Me.Text = "(You want to edit the File, please select a new image)"
        End If
    End Sub

    Public Sub SetPath(ByVal path As String)
        ActionControl = ActionEnum.ADD
        Me.FullPath = path
        Me.Text = path
    End Sub

    Private Property FullPath As String
    Public Property ActionControl As ActionEnum
    Public Enum ActionEnum
        ADD
        EDIT
    End Enum



    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

End Class
