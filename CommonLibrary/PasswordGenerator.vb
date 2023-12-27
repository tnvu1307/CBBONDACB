Imports System
Imports System.Text

Public Class PasswordGenerator
    Private characterArray() As Char

    Private passwordLength As Int32 = 8
    Public Sub New()
        characterArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray
    End Sub

    Private Function GetRandomCharacter() As Char
        Randomize()
        Dim location As Int32 = -1
        While Not (location >= 0 AndAlso location <= Me.characterArray.GetUpperBound(0))
            location = Convert.ToInt32(Me.characterArray.GetUpperBound(0) * Rnd() + 1)
        End While

        Return Me.characterArray(location)
    End Function

    Public Function Generate() As String

        Dim count As Int32
        Dim sb As New StringBuilder
        sb.Capacity = passwordLength
        For count = 0 To passwordLength - 1
            sb.Append(GetRandomCharacter())
        Next count
        If (Not sb Is Nothing) Then
            Return sb.ToString
        End If

        Return String.Empty
    End Function

End Class
