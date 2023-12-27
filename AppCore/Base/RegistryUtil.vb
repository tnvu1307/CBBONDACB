Imports Microsoft.Win32

Public Class RegistryUtil
    'tiennv
    'CONST KEY
    Public Const FONT_SIZE As String = "FONT_SIZE"

    Public Shared Function GetKey(ByVal key As String) As String
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\FSS\FundServ")
        Try
            Return rk.GetValue(key.ToUpper())
        Catch ex As Exception
            Return Nothing
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try
    End Function

    Public Shared Function SetKey(ByVal key As String, ByVal value As String) As Boolean
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\FSS\FundServ")
        Try
            rk.SetValue(key.ToUpper(), value)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If (rk IsNot Nothing) Then
                rk.Close()
            End If
        End Try
    End Function

    Public Shared Function DeleteKey(ByVal key As String) As Boolean
        Try
            Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\FSS\FundServ")
            ' Delete key.
            rk.DeleteValue(key)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
