Imports CommonLibrary
Imports Newtonsoft.Json
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web

Public Class frmLoginMicrosoft
    Private _authenMicrosoft As ResponseAuthenMicrosoft

    Private _urlAuthorizeCode As String
    Private _urlAccessToken As String
    Private _redirectUri As String
    Private _clientId As String
    Private _clientSecret As String
    Private _scope As String

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Public Sub New(urlAuthorizeCode As String, urlAccessToken As String, redirectUri As String, clientId As String, clientSecret As String, scope As String)
        MyBase.New()

        _urlAuthorizeCode = urlAuthorizeCode
        _urlAccessToken = urlAccessToken
        _redirectUri = redirectUri
        _clientId = clientId
        _clientSecret = clientSecret
        _scope = scope

        InitializeComponent()
    End Sub

    Public ReadOnly Property AuthenMicrosoft() As ResponseAuthenMicrosoft
        Get
            Return _authenMicrosoft
        End Get
    End Property

    Private Sub wbLoginMicrosoft_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles wbLoginMicrosoft.Navigated
        If (wbLoginMicrosoft.Url.AbsoluteUri.StartsWith(_redirectUri)) Then
            Dim authorizeCode = GetParamValue(wbLoginMicrosoft.Url, "code")

            _authenMicrosoft = GetResponseAuthen(authorizeCode)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmLoginMicrosoft_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = $"Navigating to start URL: {_urlAuthorizeCode}"

        wbLoginMicrosoft.Navigate(GetUrlAuthorize())
    End Sub

    Private Function GetUrlAuthorize() As Uri
        Dim builder = New UriBuilder(_urlAuthorizeCode)
        builder.Port = -1

        Dim queryParams = HttpUtility.ParseQueryString(builder.Query)
        queryParams("client_id") = _clientId
        queryParams("response_type") = "code"
        queryParams("redirect_uri") = _redirectUri
        queryParams("scope") = _scope
        queryParams("response_mode") = "query"
        queryParams("prompt") = "login"

        builder.Query = queryParams.ToString()

        Return builder.Uri
    End Function

    Private Function GetParamValue(redirectUri As Uri, paramName As String) As String
        Dim queryParmas = HttpUtility.ParseQueryString(redirectUri.Query)

        If String.IsNullOrEmpty(queryParmas(paramName)) Then
            Return String.Empty
        End If

        Return queryParmas(paramName)
    End Function

    Public Function GetResponseAuthen(authorizeCode As String) As ResponseAuthenMicrosoft
        Dim body = New Dictionary(Of String, String) From {
            {"client_id", _clientId},
            {"client_secret", _clientSecret},
            {"grant_type", "authorization_code"},
            {"code", authorizeCode},
            {"redirect_uri", _redirectUri}
        }
        Dim content = New FormUrlEncodedContent(body)

        Using client As New HttpClient()
            Try
                'accept "ssl" protocol for your request.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                'Set ContentType
                client.DefaultRequestHeaders.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"))

                Dim response = client.PostAsync(_urlAccessToken, content).Result

                If response.IsSuccessStatusCode Then
                    Return JsonConvert.DeserializeObject(Of ResponseAuthenMicrosoft)(response.Content.ReadAsStringAsync().Result)
                End If
            Catch ex As Exception
                LogError.Write("Error source: " & ex.Source & vbNewLine _
                & "Error code: System error!" & vbNewLine _
                & "Error message: " & ex.Message, EventLogEntryType.Error)
            End Try
        End Using

        Return New ResponseAuthenMicrosoft()
    End Function
End Class