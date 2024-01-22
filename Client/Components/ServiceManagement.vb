Imports System.ServiceModel
Imports CommonLibrary
Imports System.IO

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

    Public Function GetVersion(ByRef pv_strMessage As String) As Long
        Dim lngError As Long = ERR_SYSTEM_OK
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOSTService.HOSTServiceClient
        Try
            'If mv_flagSignature = "Y" Then
            'pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            'End If

            pv_strMessage = TripleDesEncryptData(pv_strMessage)

            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            Dim request As HOSTService.GetVersionRequest = New HOSTService.GetVersionRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.GetVersionResponse = ws.GetVersion(request)
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function


    Public Function Message(ByRef pv_strMessage As String) As Long
        Dim lngError As Long = ERR_SYSTEM_OK
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
            lngError = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

    Public Function GetInfoAuthorMicrosoft(ByRef pv_strMessage As String) As Long
        Dim lngError As Long = ERR_SYSTEM_OK
        Dim ws As New HOSTService.HOSTServiceClient
        Try
            If mv_flagSignature = "Y" Then
                pv_strMessage = RSA.signXml(pv_strMessage, mv_keySignature, mv_tagSignature)
            End If

            'Compress
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            Dim pv_arrByteMessage() As Byte
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            Dim request As HOSTService.GetInfoAuthorMicrosoftRequest = New HOSTService.GetInfoAuthorMicrosoftRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.GetInfoAuthorMicrosoftResponse = ws.GetInfoAuthorMicrosoft(request)
            lngError = response.GetInfoAuthorMicrosoftResult
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

    Public Function InsertOrUpdateAccMicrosoft(ByRef pv_strMessage As String) As Long
        Dim lngError As Long = ERR_SYSTEM_OK
        Dim ws As New HOSTService.HOSTServiceClient
        Try
            'Compress
            Dim pv_arrByteMessage() As Byte
            pv_strMessage = TripleDesEncryptData(pv_strMessage)
            pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

            'Send to host
            Dim request As HOSTService.InsertOrUpdateAccMicrosoftRequest = New HOSTService.InsertOrUpdateAccMicrosoftRequest
            request.pv_arrByteMessage = pv_arrByteMessage

            Dim response As HOSTService.InsertOrUpdateAccMicrosoftResponse = ws.InsertOrUpdateAccMicrosoft(request)
            pv_arrByteMessage = response.pv_arrByteMessage
            lngError = response.InsertOrUpdateAccMicrosoftResult

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)

            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function

End Class

Public Class BDSPalaceOrderManagement
    Public Function PlaceOrder(ByRef pv_strMessage As String) As Long

    End Function

    'Xử lý CallBack cho hàm đặt lệnh
    Private Sub CallBackOnPlaceOrder(ByVal asyncResult As IAsyncResult)

    End Sub
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
        Dim lngError As Long = ERR_SYSTEM_OK
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
            lngError = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngError
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
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
        Dim lngError As Long = ERR_SYSTEM_OK
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
            lngError = response.MessageByteResult
            pv_arrByteMessage = response.pv_arrByteMessage

            'Decompress
            pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            pv_strMessage = TripleDesDecryptData(pv_strMessage)
            Return lngError
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
            ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
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
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOAuthService.HOAuthServiceClient
        Try
            ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
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
    'START  Phuong Add from STE
    Public Function GetLeftMenu(ByVal message As String) As Byte()
        'Dim strTemp As String = message
        'GetLeftMenu = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetLeftMenu(strTemp))
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOAuthService.HOAuthServiceClient
        Try
            Dim request As HOAuthService.GetLeftMenuRequest = New HOAuthService.GetLeftMenuRequest
            request.message = message
            Return ws.GetLeftMenu(request).GetLeftMenuResult
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function
    Public Function GetLeftAdjustMenu(ByVal message As String) As Byte()
        'Dim strTemp As String = message
        'GetLeftMenu = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetLeftMenu(strTemp))
        'Dim ws As New AuthService.AuthServiceClient
        Dim ws As New HOAuthService.HOAuthServiceClient
        Try
            Dim request As HOAuthService.GetLeftAdjustMenuRequest = New HOAuthService.GetLeftAdjustMenuRequest
            request.message = message
            Return ws.GetLeftAdjustMenu(request).GetLeftAdjustMenuResult
        Catch ex As Exception
            ws.Abort()
            Throw ex
        Finally
            ws.Close()
        End Try
    End Function
    'END
End Class