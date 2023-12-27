Imports System.IO

Public Class LinkLabelCustom

    Private Property _dataByte As Byte()
    Public Property DataByte As Byte()
        Get
            If Not String.IsNullOrEmpty(Me.FullPath) Then
                Return File.ReadAllBytes(Me.FullPath)
            End If
            Return _dataByte
        End Get
        Set(value As Byte())
            _dataByte = value
        End Set
    End Property



    Private Property _dataHex As String
    Public Property DataHex As String
        Get
            If Not String.IsNullOrEmpty(Me.FullPath) Then
                Return ByteArrayToString(File.ReadAllBytes(Me.FullPath))
            End If
            Return _dataHex
        End Get
        Set(value As String)
            _dataHex = value
        End Set
    End Property

    Public Function ByteArrayToString(ByVal ba As Byte()) As String
        Return BitConverter.ToString(ba).Replace("-", "")
    End Function

    Public Property FullPath As String

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

End Class
