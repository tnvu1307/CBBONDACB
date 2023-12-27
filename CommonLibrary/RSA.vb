Imports System.IO
Imports System.Text
Imports System.Xml
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Crypto.Encodings
Imports Org.BouncyCastle.Crypto.Engines
Imports Org.BouncyCastle.OpenSsl

Public Class RSA

    Public Shared Function RsaEncryptWithPublic(ByVal clearText As String, ByVal publicKey As String) As String
        Dim bytesToEncrypt = Encoding.UTF8.GetBytes(clearText)
        Dim encryptEngine = New Pkcs1Encoding(New RsaEngine())

        Using txtreader = New StringReader(publicKey)
            Dim keyParameter = CType(New PemReader(txtreader).ReadObject(), AsymmetricKeyParameter)
            encryptEngine.Init(True, keyParameter)
        End Using

        Dim encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length))
        Return encrypted
    End Function

    Public Shared Function RsaDecryptWithPrivate(ByVal base64Input As String, ByVal privateKey As String) As String
        Dim bytesToDecrypt = Convert.FromBase64String(base64Input)
        Dim keyPair As AsymmetricCipherKeyPair
        Dim decryptEngine = New Pkcs1Encoding(New RsaEngine())

        Using txtreader = New StringReader(privateKey)
            keyPair = CType(New PemReader(txtreader).ReadObject(), AsymmetricCipherKeyPair)
            decryptEngine.Init(False, keyPair.[Private])
        End Using

        Dim decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length))
        Return decrypted
    End Function

    Public Shared Function signXml(ByVal pv_strMessage As String, ByVal pv_strKeySign As String, ByVal pv_strTagSign As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.LoadXml(pv_strMessage)

        Dim attr As XmlAttribute = xmlDoc.CreateAttribute(pv_strTagSign)
        attr.Value = RSA.RsaEncryptWithPublic(pv_strKeySign, modCommond.Signature_PublicKey)
        xmlDoc.DocumentElement.Attributes.Append(attr)

        Return xmlDoc.OuterXml
    End Function
End Class
