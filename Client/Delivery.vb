Imports CommonLibrary
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Web.Mail

Public Class Delivery
    Public Function SendMessage(ByRef pv_strMessage As String, ByVal v_strCOMPRESSED As String) As Long
        'Call Host WebService 
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'TruongLD Comment when convert
        'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
        Dim v_lngErr As Long

        If v_strCOMPRESSED = "Y" Then
            'Compress message
            Dim pv_arrByteMessage() As Byte = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            'v_lngErr = v_ws.Message(pv_arrByteMessage)

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
        Else
            'Khong nen
            v_lngErr = v_ws.Message(pv_strMessage)
        End If

        Return v_lngErr
    End Function

    Sub TestMessage()
        Try
            'Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New UnicodeEncoding

            'Create byte arrays to hold original, encrypted, and decrypted data.
            Dim dataToEncrypt As Byte() = ByteConverter.GetBytes("Data to Encrypt")
            Dim encryptedData() As Byte
            Dim decryptedData() As Byte
            Dim signature() As Byte

            'public and private key data.
            Dim RSA As New RSACryptoServiceProvider

            Dim initPRKey, initPBKey, rsaPRKey, rsaPBKey As String
            'Generate current key
            initPRKey = RSA.ToXmlString(True)
            initPBKey = RSA.ToXmlString(False)
            'Save key to file
            RSASaveKey(initPRKey, "C:\TEMP\PRKEY.XML")
            RSASaveKey(initPBKey, "C:\TEMP\PBKEY.XML")
            'Load key from file
            RSALoadKey(rsaPRKey, "C:\TEMP\PRKEY.XML")
            RSALoadKey(rsaPBKey, "C:\TEMP\PBKEY.XML")

            'Pass the data to ENCRYPT, the public key information 
            '(using RSACryptoServiceProvider.ExportParameters(false),
            'and a boolean flag specifying no OAEP padding.
            RSA.FromXmlString(rsaPBKey)
            encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(False), False)

            RSA.FromXmlString(rsaPRKey)
            Dim rsaPrivateKey, rsaPublicKey As RSAParameters
            rsaPrivateKey = RSA.ExportParameters(True)
            rsaPublicKey = RSA.ExportParameters(False)

            signature = HashAndSign(encryptedData, rsaPrivateKey)
            If VerifyHash(rsaPublicKey, encryptedData, signature) Then
                'Pass the data to DECRYPT, the private key information 
                '(using RSACryptoServiceProvider.ExportParameters(true),
                'and a boolean flag specifying no OAEP padding.
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(True), False)
            End If

            'Display the decrypted plaintext to the console. 
            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData))
        Catch ex As ArgumentNullException
            'Catch this exception in case the encryption did
            'not succeed.
            Throw ex
        End Try
    End Sub

    Public Shared Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            'Create a new instance of RSACryptoServiceProvider.
            Dim RSA As New RSACryptoServiceProvider

            'Import the RSA Key information. This only needs
            'toinclude the public key information.
            RSA.ImportParameters(RSAKeyInfo)

            'Encrypt the passed byte array and specify OAEP padding.  
            'OAEP padding is only available on Microsoft Windows XP or
            'later.  
            Return RSA.Encrypt(DataToEncrypt, DoOAEPPadding)
            'Catch and display a CryptographicException  
            'to the console.
        Catch ex As CryptographicException
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Shared Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            'Create a new instance of RSACryptoServiceProvider.
            Dim RSA As New RSACryptoServiceProvider

            'Import the RSA Key information. This needs
            'to include the private key information.
            RSA.ImportParameters(RSAKeyInfo)

            'Decrypt the passed byte array and specify OAEP padding.  
            'OAEP padding is only available on Microsoft Windows XP or
            'later.  
            Return RSA.Decrypt(DataToDecrypt, DoOAEPPadding)

            'Catch and display a CryptographicException  
            'to the console.
        Catch ex As CryptographicException
            Throw ex
            Return Nothing
        End Try
    End Function

    'Manually performs hash and then signs hashed value.
    Public Shared Function HashAndSign(ByVal encrypted() As Byte, ByVal RSAKeyInfo As RSAParameters) As Byte()
        Dim rsaCSP As New RSACryptoServiceProvider
        Dim hash As New SHA1Managed
        Dim hashedData() As Byte

        rsaCSP.ImportParameters(RSAKeyInfo)

        hashedData = hash.ComputeHash(encrypted)
        Return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"))
    End Function 'HashAndSign

    'Manually performs hash and then verifies hashed value.
    Public Function VerifyHash(ByVal RSAKeyInfo As RSAParameters, ByVal signedData() As Byte, ByVal signature() As Byte) As Boolean
        Dim rsaCSP As New RSACryptoServiceProvider
        Dim hash As New SHA1Managed
        Dim hashedData() As Byte

        rsaCSP.ImportParameters(RSAKeyInfo)

        hashedData = hash.ComputeHash(signedData)
        Return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature)
    End Function 'VerifyHash

    Public Shared Function RSASaveKey(ByVal RSAKeyInfo As String, ByVal KeyPath As String) As Long
        Try
            Dim objXMLStream As StreamWriter = New StreamWriter(KeyPath)
            objXMLStream.Write(RSAKeyInfo)
            objXMLStream.Close()
            'Dim objStream As FileStream = File.OpenWrite(KeyPath)
            'Dim objFormater As New BinaryFormatter
            'objFormater.Serialize(objStream, RSAKeyInfo)
            'objStream.Close()
            Return 0
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function

    Public Shared Function RSALoadKey(ByRef RSAKeyInfo As String, ByVal KeyPath As String) As Long
        Try
            Dim objXMLStream As StreamReader = New StreamReader(KeyPath)
            RSAKeyInfo = objXMLStream.ReadToEnd()
            objXMLStream.Close()
            'Dim objStream As FileStream = File.OpenRead(KeyPath)
            'Dim objFormater As New BinaryFormatter
            'RSAKeyInfo = DirectCast(objFormater.Deserialize(objStream), RSAParameters)
            'objStream.Close()
            Return 0
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
    End Function

    Public Shared Function SendMail(ByVal v_strSignature As String, ByVal FromEmail As String, ByVal ToEmail As String, ByVal Subject As String, _
        ByVal UserName As String, ByVal UserPassword As String, _
        ByVal Body As String, ByVal SmtpServer As String, Optional ByVal attachFiles As ArrayList = Nothing, Optional ByVal v_StrHeader As String = "") As Boolean
        Try

            Dim Message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage

            Dim mailFile As MailAttachment

            Dim fileName As String
            Message.To = ToEmail
            Message.From = FromEmail
            Message.Subject = Subject
            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.BodyFormat = MailFormat.Html

            'Message.Body = Body

            'Ve VNDS test lai insert anh logo o signature
            '"<P class=MsoNormal><B>" & _
            '"<P class=MsoNormal><SPAN style='COLOR: navy'><o:p>&nbsp;</o:p></SPAN></P>" & _
            '"<SPAN style='COLOR: #333399'>" & _
            '"<img src='/exchweb/img/vndirect_logo.jpg'>" & _
            '"</SPAN></B>" & _
            Message.Body = Body & ControlChars.NewLine & ControlChars.NewLine & v_strSignature
            'Message.Body = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>" & _
            '                "<HTML xmlns='http://www.w3.org/TR/REC-html40' xmlns:v = " & _
            '                "'urn:schemas-microsoft-com:vml' xmlns:o = " & _
            '                "'urn:schemas-microsoft-com:office:office' xmlns:w = " & _
            '                "'urn:schemas-microsoft-com:office:word'>" & _
            '                "<HEAD><TITLE>" + Subject + "</TITLE>" & _
            '                "<META http-equiv=Content-Type content='text/html; charset=utf-8'>" & _
            '                "<META content=Word.Document name=ProgId>" & _
            '                "<META content='MSHTML 6.00.3790.0' name=GENERATOR>" & _
            '                "<META content='Microsoft Word 11' name=Originator>" & _
            '                "<STYLE>@page Section1 {size: 8.5in 11.0in; margin: 1.0in 1.25in 1.0in 1.25in; mso-header-margin: .5in; mso-footer-margin: .5in; mso-paper-source: 0; }" & _
            '                "P.MsoNormal {" & _
            '                 "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ''; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
            '                "LI.MsoNormal {" & _
            '                    "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ""; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
            '                "DIV.MsoNormal {" & _
            '                    "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ""; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
            '                "A:link {" & _
            '                     "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
            '                "SPAN.MsoHyperlink {" & _
            '                     "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
            '                "A:visited {" & _
            '                     "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
            '                "SPAN.MsoHyperlinkFollowed {" & _
            '                     "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
            '                "SPAN.SpellE {" & _
            '                    "mso-style-name: ''; mso-spl-e: yes}" & _
            '                "DIV.Section1 {" & _
            '                    "page:       Section1()}" & _
            '                "</STYLE>" & _
            '                "</HEAD>" & _
            '                "<BODY lang=EN-US style='tab-interval: .5in' vLink=blue link=blue>" & _
            '                "<P><SPAN>" + Body + "</SPAN></P>" & _
            '                "<DIV class=Section1>" & _
            '                "<P class=MsoNormal align=left><B>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: navy'>Phòng Dịch Vụ Khách Hàng</SPAN></B></P>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: navy'><o:p></o:p></SPAN></P>" & _
            '                "<SPAN style='COLOR: black'><o:p></o:p></SPAN></P>" & _
            '                "<P class=MsoNormal><SPAN class=SpellE><STRONG>" & _
            '                "<SPAN style='COLOR: #333399'>Công ty Cổ phần Chứng Khoán Sacombank</SPAN></STRONG></SPAN>" & _
            '                "<SPAN style='FONT-SIZE: 10pt'><o:p></o:p></SPAN></P>" & _
            '                "<P class=MsoNormal><SPAN style='FONT-SIZE: 10pt; COLOR: #333399'><BR>Nam Kỳ Khởi Nghĩa, " & _
            '                "TPHCM,&nbsp;Việt Nam <BR>Tel:&nbsp; (84 4) 9724568&nbsp;<BR>Fax:&nbsp; " & _
            '                "(84 8) 68686868 <o:p></o:p></SPAN></P> " & _
            '                "<P class=MsoNormal><SPAN style='FONT-SIZE: 10pt; COLOR: #333399'><BR>Nam Kỳ Khởi Nghĩa, " & _
            '                "Quận 3, TP.HCM<BR>Tel:&nbsp; (84 8) 9146925&nbsp;<BR>Fax:&nbsp; " & _
            '                "(84 8) 9146924 <o:p></o:p></SPAN></P> " & _
            '                "<P class=MsoNormal><SPAN style='FONT-SIZE: 10pt; COLOR: #333399'>" & _
            '                "<BR>HotLine:&nbsp; 113114115 - 123456789&nbsp;" & _
            '                "<o:p></o:p></SPAN></P> " & _
            '                "<P class=MsoNormal>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: #333399'>Email:</SPAN>" & _
            '                "<SPAN style = 'FONT-SIZE: 10pt; COLOR: navy'>" & _
            '                "<A href='mailto:dvkh@sbs.com.vn'>dvkh@sbs.com.vn</A></SPAN>" & _
            '                "<SPAN style = 'FONT-SIZE: 10pt; COLOR: navy'>" & _
            '                ", <A href='mailto:support@sbs.com.vn'>support@sbs.com.vn</A></SPAN>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: #333399'><o:p></o:p></SPAN></P>" & _
            '                "<P class=MsoNormal>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: #333399'>Web</SPAN><STRONG>" & _
            '                "<SPAN style='COLOR: #333399'>: </SPAN></STRONG>" & _
            '                "<SPAN style='COLOR: navy'>" & _
            '                "<A title=http://www.vndirect.com.vn/ href='http://www.sbs.com.vn/'>" & _
            '                "<SPAN style = 'FONT-SIZE: 10pt; COLOR: #333399'> " & _
            '                "<SPAN title=http://www.sbs.com.vn/>http://www.sbs.com.vn</SPAN></SPAN></A></SPAN>" & _
            '                "<SPAN style='FONT-SIZE: 10pt; COLOR: #333399'><o:p></o:p></SPAN></P>" & _
            '                "</DIV></BODY></HTML> "

            Message.Body = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>" & _
                            "<HTML xmlns='http://www.w3.org/TR/REC-html40' xmlns:v = " & _
                            "'urn:schemas-microsoft-com:vml' xmlns:o = " & _
                            "'urn:schemas-microsoft-com:office:office' xmlns:w = " & _
                            "'urn:schemas-microsoft-com:office:word'>" & _
                            "<HEAD><TITLE>" + Subject + "</TITLE>" & _
                            "<META http-equiv=Content-Type content='text/html; charset=utf-8'>" & _
                            "<META content=Word.Document name=ProgId>" & _
                            "<META content='MSHTML 6.00.3790.0' name=GENERATOR>" & _
                            "<META content='Microsoft Word 11' name=Originator>" & _
                            "<STYLE>@page Section1 {size: 8.5in 11.0in; margin: 1.0in 1.25in 1.0in 1.25in; mso-header-margin: .5in; mso-footer-margin: .5in; mso-paper-source: 0; }" & _
                            "P.MsoNormal {" & _
                             "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ''; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
                            "LI.MsoNormal {" & _
                                "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ""; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
                            "DIV.MsoNormal {" & _
                                "FONT-SIZE: 12pt; MARGIN: 0in 0in 0pt; FONT-FAMILY: 'Times New Roman'; mso-style-parent: ""; mso-pagination: widow-orphan; mso-fareast-font-family: 'Times New Roman'}" & _
                            "A:link {" & _
                                 "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
                            "SPAN.MsoHyperlink {" & _
                                 "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
                            "A:visited {" & _
                                 "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
                            "SPAN.MsoHyperlinkFollowed {" & _
                                 "COLOR: blue; TEXT-DECORATION: underline; text-underline: single}" & _
                            "SPAN.SpellE {" & _
                                "mso-style-name: ''; mso-spl-e: yes}" & _
                            "DIV.Section1 {" & _
                                "page:       Section1()}" & _
                            "</STYLE>" & _
                            "</HEAD>" & _
                            "<BODY lang=EN-US style='tab-interval: .5in' vLink=blue link=blue>" & _
                            "<P><SPAN>" + v_StrHeader + "</SPAN></P>" & _
                            "<P><SPAN>" + Body + "</SPAN></P>" & _
                            "<P><SPAN>" + v_strSignature + "</SPAN></P>" & _
                            "<DIV class=Section1>" & _
                            "</DIV></BODY></HTML> "

            'Dim fs As New StreamWriter("C:\testhtml.html")
            'fs.Write(Message.Body)
            'fs.Flush()
            'fs.Close()

            If Not attachFiles Is Nothing Then
                For Each fileName In attachFiles
                    mailFile = New MailAttachment(fileName)
                    Message.Attachments.Add(mailFile)
                Next
            End If

            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", SmtpServer)
            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2)
            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserName)
            Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", UserPassword)

            SmtpMail.SmtpServer = SmtpServer
            SmtpMail.Send(Message)
            Return True

        Catch ehttp As System.Web.HttpException
            Return False
        End Try
    End Function

    Public Shared Function SendMailRegister(ByVal strBody As String, ByVal EmailSender As String, ByVal EmailSubject As String, _
        ByVal SmtpServer As String, ByVal UserName As String, ByVal UserPassword As String, _
        ByVal template As String, ByVal ToEmail As String, ByVal ToName As String, ByVal toPIN As String) As Boolean
        Try
            Dim Body As String

            'Body thi phai lay tu file len
            Dim oFile As System.IO.File
            Dim oRead As System.IO.StreamReader
            oRead = oFile.OpenText(template) 'filename (like attachment name)
            Body = oRead.ReadToEnd()
            oRead.Close()

            If SendMail(strBody, EmailSender, ToEmail, EmailSubject, UserName, UserPassword, Body, SmtpServer) Then
                Return True
            Else
                Return False
            End If

        Catch e As System.Exception
            Return False
        End Try

    End Function


End Class

