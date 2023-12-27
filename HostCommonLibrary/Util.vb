Imports System
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Security.Cryptography
Imports System.Text

<Serializable()> _
Public Class Util
    Public Shared Function EncryptString(ByVal text As String) As String
        Dim ct As ICryptoTransform
        Dim md5 As New MD5CryptoServiceProvider
        Dim des As New TripleDESCryptoServiceProvider
        Try
            Dim v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5 As String
            v_strKey1 = "VND"
            v_strKey2 = "SBnG"
            v_strKey3 = "USD"
            v_strKey4 = "FSS"
            v_strKey5 = "F31"
            Dim m_iv() As Byte = {1, 1, 2, 8, 2, 9, 2, 9}
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 & v_strKey2 & v_strKey3 & v_strKey4 & v_strKey5))

            des.IV = m_iv
            ct = des.CreateEncryptor()

            Dim input() As Byte = Encoding.Unicode.GetBytes(text)
            Dim output() As Byte = ct.TransformFinalBlock(input, 0, input.Length)

            Return Convert.ToBase64String(output)
        Catch ex As Exception
            Throw ex
        Finally
            md5 = Nothing
            des = Nothing
        End Try
    End Function

    Public Shared Function DecryptString(ByVal text As String) As String
        Dim ct As ICryptoTransform
        Dim md5 As New MD5CryptoServiceProvider
        Dim des As New TripleDESCryptoServiceProvider
        Try
            Dim v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5 As String
            v_strKey1 = "VND"
            v_strKey2 = "SBnG"
            v_strKey3 = "USD"
            v_strKey4 = "FSS"
            v_strKey5 = "F31"
            Dim m_iv() As Byte = {1, 1, 2, 8, 2, 9, 2, 9}
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 & v_strKey2 & v_strKey3 & v_strKey4 & v_strKey5))
            des.IV = m_iv
            ct = des.CreateDecryptor()

            Dim input() As Byte = Convert.FromBase64String(text)
            Dim output() As Byte = ct.TransformFinalBlock(input, 0, input.Length)

            Return Encoding.Unicode.GetString(output)
        Catch ex As Exception
            Throw ex
        Finally
            md5 = Nothing
            des = Nothing
        End Try
    End Function
End Class
