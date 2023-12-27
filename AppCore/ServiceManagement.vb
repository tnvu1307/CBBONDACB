Imports System.Xml
Imports CommonLibrary
Imports Excel

Public Class BDSDeliveryManagement

    Private mv_flagSignature = Nothing
    Private mv_tagSignature = Nothing
    Private mv_keySignature = Nothing

    Public Sub New()
        If mv_flagSignature = Nothing Then
            Dim ws As New HOSTService.HOSTServiceClient
            Dim request As HOSTService.GetFlagSignatureRequest = New HOSTService.GetFlagSignatureRequest()
            Dim response As HOSTService.GetFlagSignatureResponse

            Try
                response = ws.GetFlagSignature(request)
                Dim res = response.GetFlagSignatureResult

                Dim flag() As String = res.Split("|")

                mv_flagSignature = flag(0)
                mv_tagSignature = flag(1)
                mv_keySignature = flag(2)
            Catch ex As Exception
                mv_flagSignature = "N"
                mv_tagSignature = "Signature"
                mv_keySignature = ""
            End Try

        End If
    End Sub

    Public Function Message(ByRef pv_strMessage As String) As Long
        Dim lngReturn As Long = ERR_SYSTEM_OK

        'Dim ws As New BDSService.BDSServiceClient
        Dim ws As New HOSTService.HOSTServiceClient
        Try
            Dim v_xmlDocumentMessage As New XmlDocumentEx
            v_xmlDocumentMessage.LoadXml(pv_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strACTIONFLAG As String = String.Empty
            If Not (v_attrColl.GetNamedItem(modCommond.gc_AtributeACTFLAG) Is Nothing) Then
                v_strACTIONFLAG = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            End If

            If v_strACTIONFLAG = modCommond.gc_ActionBatch Then
                ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
            End If

            If mv_flagSignature = "Y" Then
                pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            End If

            'Mã hóa message trước khi gửi
            pv_strMessage = TripleDesEncryptData(pv_strMessage)

            'Compress
            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            Dim request As HOSTService.MessageByteRequest = New HOSTService.MessageByteRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.MessageByteResponse = ws.MessageByte(request)
            lngReturn = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngReturn
            'Giải mã message
        Catch ex As Exception
            ws.Abort()
        Finally
            ws.Close()
        End Try
    End Function

    Public Function UploadFile(ByVal pv_dsDataBytes As DataSet, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As Long
        Dim lngError As Long = ERR_SYSTEM_OK
        Dim ws As New BDSServiceStreamedClient
        ws.Endpoint.Binding.SendTimeout = TimeSpan.FromMinutes(10)

        Try

            If (pv_dsDataBytes IsNot Nothing AndAlso pv_dsDataBytes.Tables.Count = 1) Then
                For Each r As DataRow In pv_dsDataBytes.Tables(0).Rows
                    For Each c As DataColumn In r.Table.Columns
                        If (c.DataType Is GetType(System.Byte())) Then
                            lngError = ws.UploadFile(r(c.ColumnName), c.ColumnName, pv_pkFieldName, pv_pkValue, pv_TableName)
                        End If
                    Next
                Next
            End If
            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

    Public Function DownloadFile(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Byte()
        Dim lngError As Long = ERR_SYSTEM_OK
        Dim ws As New BDSServiceStreamedClient
        ws.Endpoint.Binding.SendTimeout = TimeSpan.FromMinutes(10)
        Try
            Return ws.DownloadFile(pv_FieldName, pv_pkFieldName, pv_pkValue, pv_TableName)

        Catch ex As Exception
            ws.Abort()
            Return Nothing
        Finally
            ws.Close()
        End Try
    End Function

End Class

Public Class BDSDeliveryLongTimeOutManagement

    Private mv_flagSignature = Nothing
    Private mv_tagSignature = Nothing
    Private mv_keySignature = Nothing

    Public Sub New()
        If mv_flagSignature = Nothing Then
            Dim ws As New HOSTService.HOSTServiceClient
            Dim request As HOSTService.GetFlagSignatureRequest = New HOSTService.GetFlagSignatureRequest()
            Dim response As HOSTService.GetFlagSignatureResponse

            Try
                response = ws.GetFlagSignature(request)
                Dim res = response.GetFlagSignatureResult

                Dim flag() As String = res.Split("|")

                mv_flagSignature = flag(0)
                mv_tagSignature = flag(1)
                mv_keySignature = flag(2)
            Catch ex As Exception
                mv_flagSignature = "N"
                mv_tagSignature = "Signature"
                mv_keySignature = ""
            End Try

        End If
    End Sub

    Public Function Message(ByRef pv_strMessage As String) As Long
        Dim lngReturn As Long = ERR_SYSTEM_OK
        Dim ws As New HOSTService.HOSTServiceClient
        Try

            If mv_flagSignature = "Y" Then
                pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            End If

            ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
            pv_strMessage = TripleDesEncryptData(pv_strMessage)

            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            Dim request As HOSTService.MessageByteRequest = New HOSTService.MessageByteRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.MessageByteResponse = ws.MessageByte(request)
            lngReturn = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage
            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngReturn
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

End Class

Public Class BDSRptDeliveryManagement

    Private mv_flagSignature = Nothing
    Private mv_tagSignature = Nothing
    Private mv_keySignature = Nothing

    Public Sub New()
        If mv_flagSignature = Nothing Then
            Dim ws As New HOSTService.HOSTServiceClient
            Dim request As HOSTService.GetFlagSignatureRequest = New HOSTService.GetFlagSignatureRequest()
            Dim response As HOSTService.GetFlagSignatureResponse

            Try
                response = ws.GetFlagSignature(request)
                Dim res = response.GetFlagSignatureResult

                Dim flag() As String = res.Split("|")

                mv_flagSignature = flag(0)
                mv_tagSignature = flag(1)
                mv_keySignature = flag(2)
            Catch ex As Exception
                mv_flagSignature = "N"
                mv_tagSignature = "Signature"
                mv_keySignature = ""
            End Try

        End If
    End Sub

    Public Function Message(ByRef pv_strMessage As String) As Long
        Dim lngReturn As Long = ERR_SYSTEM_OK
        'Dim ws As New BDSRptService.BDSRptServiceClient
        Dim ws As New HOSTRptService.HOSTRptServiceClient
        Try
            If mv_flagSignature = "Y" Then
                pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            End If

            'Dim ws As New HOSTDelivery.HOSTDeliveryClient
            pv_strMessage = TripleDesEncryptData(pv_strMessage)

            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'lngReturn = ws.Message(pv_strMessage)
            'lngReturn = ws.MessageBytes(pv_arrByteMessage)
            Dim request As HOSTRptService.MessageByteRequest = New HOSTRptService.MessageByteRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTRptService.MessageByteResponse = ws.MessageByte(request)
            lngReturn = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage
            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngReturn
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
        Return lngReturn
    End Function

End Class

Public Class AuthManagement

    Private mv_flagSignature = Nothing
    Private mv_tagSignature = Nothing
    Private mv_keySignature = Nothing

    Public Sub New()
        If mv_flagSignature = Nothing Then
            Dim ws As New HOSTService.HOSTServiceClient
            Dim request As HOSTService.GetFlagSignatureRequest = New HOSTService.GetFlagSignatureRequest()
            Dim response As HOSTService.GetFlagSignatureResponse

            Try
                response = ws.GetFlagSignature(request)
                Dim res = response.GetFlagSignatureResult

                Dim flag() As String = res.Split("|")

                mv_flagSignature = flag(0)
                mv_tagSignature = flag(1)
                mv_keySignature = flag(2)
            Catch ex As Exception
                mv_flagSignature = "N"
                mv_tagSignature = "Signature"
                mv_keySignature = ""
            End Try

        End If
    End Sub

    Public Function Message(ByRef pv_strMessage As String) As Long
        Dim lngReturn As Long = ERR_SYSTEM_OK
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOSTService.HOSTServiceClient
        Try
            If mv_flagSignature = "Y" Then
                pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            End If

            pv_strMessage = TripleDesEncryptData(pv_strMessage)

            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            Dim request As HOSTService.MessageByteRequest = New HOSTService.MessageByteRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.MessageByteResponse = ws.MessageByte(request)
            lngReturn = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage
            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngReturn
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function
    Public Function GetAuthorizationTicket(ByVal pv_strUserName As String, ByVal pv_strPassword As String) As String
        'GetAuthorizationTicket = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetAuthorizationTicket(pv_strUserName, pv_strPassword))
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOAuthService.HOAuthServiceClient
        Try
            Dim request As HOAuthService.GetAuthorizationTicketRequest = New HOAuthService.GetAuthorizationTicketRequest
            request.pv_strUserName = pv_strUserName
            request.pv_strPassword = pv_strPassword

            Return ws.GetAuthorizationTicket(request).GetAuthorizationTicketResult
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

    Public Function GetTellerProfile(ByVal ticket As String) As HOAuthService.CTellerProfile
        'Dim strTemp As String = ticket
        'GetTellerProfile = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetTellerProfile(strTemp))
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOAuthService.HOAuthServiceClient
        Try
            Dim request As HOAuthService.GetTellerProfileRequest = New HOAuthService.GetTellerProfileRequest
            request.ticket = ticket
            Return ws.GetTellerProfile(request).GetTellerProfileResult
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function
End Class
