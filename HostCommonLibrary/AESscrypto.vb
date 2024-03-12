Imports System.Security.Cryptography
Imports System.Text
Imports HostCommonLibrary
Imports System.IO
Imports System.Data
Public Class AESscrypto
    Public Shared Function DecryptString(ByVal plainText As String, ByVal AESkey As String, ByVal AESivs As String) As String
        Using aesAlg As Aes = Aes.Create()
            aesAlg.Key = Encoding.UTF8.GetBytes(AESkey)
            aesAlg.IV = Encoding.UTF8.GetBytes(AESivs)
            aesAlg.Mode = CipherMode.CBC

            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            Using msdecrypt As New MemoryStream(Convert.FromBase64String(plainText))
                Using csdecrypt As New CryptoStream(msdecrypt, decryptor, CryptoStreamMode.Read)
                    Using swdecrypt As New StreamReader(csdecrypt)
                        Return swdecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function

End Class
