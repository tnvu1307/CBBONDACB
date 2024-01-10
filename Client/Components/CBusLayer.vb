Imports System.Net
Imports System.Threading
Imports System.Web.Services.Protocols
Imports Microsoft.Win32
Imports CommonLibrary
Imports _VSTP.AuthWS
Imports System.Runtime.InteropServices

Public Structure SYSTEMTIME
    Public wYear As UInt16
    Public wMonth As UInt16
    Public wDayOfWeek As UInt16
    Public wDay As UInt16
    Public wHour As UInt16
    Public wMinute As UInt16
    Public wSecond As UInt16
    Public wMilliseconds As UInt16
End Structure

Public Enum BusLayerResult
    None = 0
    Success = 1
    ServiceFailure = 2
    UnknownFailure = 3
    ConnectionFailure = 4
    AuthenticationFailure = 5
    AccountBlock = 6
End Enum

Public Class CBusLayer
    Private Const c_wsTimeout As Integer = 300000000 '30000 seconds

    Private mv_strLanguage As String = String.Empty
    Private mv_strIpAddress As String = String.Empty
    Private mv_strWsName As String = String.Empty

    Private mv_strTicket As String = Nothing

    'TruongLD comment when convert
    'Private mv_wsAuth As New AuthService
    'Public CurrentTellerProfile As New CTellerProfile

    'TruongLD add when convert
    Public CurrentTellerProfile As New CommonLibrary.CTellerProfile
    'End TruongLD

    Public st As New SYSTEMTIME

    <DllImport("kernel32.dll")> _
    Public Shared Sub GetLocalTime(ByRef lpSystemTime As SYSTEMTIME)
    End Sub

    <DllImport("kernel32.dll")> _
    Public Shared Sub SetLocalTime(ByRef lpSystemTime As SYSTEMTIME)
    End Sub

    Public Sub New()
        '1. Lấy thông số ngôn ngữ của ứng dụng từ Registry
        Try
            Dim version_pro_uat = System.Configuration.ConfigurationSettings.AppSettings("version_pro_uat")
            Dim v_strLang As String = String.Empty
            Dim v_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(gc_RegistryKey + version_pro_uat)

            If Not v_regKey Is Nothing Then
                v_strLang = CType(v_regKey.GetValue(gc_REG_LANG), String)

                Select Case v_strLang
                    Case CommonLibrary.gc_LANG_VIETNAMESE
                        mv_strLanguage = CommonLibrary.gc_LANG_VIETNAMESE
                    Case CommonLibrary.gc_LANG_ENGLISH
                        mv_strLanguage = CommonLibrary.gc_LANG_ENGLISH
                    Case Else
                        mv_strLanguage = CommonLibrary.gc_LANG_VIETNAMESE
                End Select
            Else
                mv_strLanguage = CommonLibrary.gc_LANG_VIETNAMESE
            End If
        Catch ex As Exception
            CommonLibrary.LogError.Write(ex.Message & vbCrLf & ex.StackTrace, EventLogEntryType.Error)
        End Try
        mv_strWsName = System.Net.Dns.GetHostName
        mv_strIpAddress = GetIPAddress()

        '2. Khởi tạo thông tin chung cho NSD
        CurrentTellerProfile.BranchId = "0000"
        CurrentTellerProfile.TellerId = "0000"
        CurrentTellerProfile.BranchName = String.Empty
        CurrentTellerProfile.Description = String.Empty
        CurrentTellerProfile.Password = String.Empty
        CurrentTellerProfile.TellerRight = "NNNN"
        CurrentTellerProfile.TellerGroup = "00"
        CurrentTellerProfile.TellerLevel = 0
        CurrentTellerProfile.TimeSearch = 0
        CurrentTellerProfile.TellerName = String.Empty
        CurrentTellerProfile.TellerPrinterName = String.Empty
        CurrentTellerProfile.TellerTitle = String.Empty
        CurrentTellerProfile.LoginTime = String.Empty
        CurrentTellerProfile.TellerGroupCareBy = String.Empty
        CurrentTellerProfile.CompanyCode = String.Empty
        CurrentTellerProfile.CompanyName = String.Empty

        '3. Set WebService timeout
        'mv_wsAuth.Timeout = c_wsTimeout
    End Sub

    Public Function Login(ByVal pv_strUserName As String, ByVal pv_strPassword As String) As BusLayerResult
        'Lưu thông tin của NSD hiện th�?i
        CurrentTellerProfile.TellerName = pv_strUserName
        CurrentTellerProfile.Password = pv_strPassword

        'Try to get a ticket
        Dim ticketResult As BusLayerResult = GetAuthorizationTicket()
        If ticketResult = BusLayerResult.Success Then
            'TruongLD Comment when convert
            'Dim newTellerProfile As CTellerProfile

            'TruongLD Add when convert
            Dim newTellerProfile As HOAuthService.CTellerProfile
            'End TruongLD


            'Lấy thông tin NSD
            Try
                'TruongLD Comment when convert
                'newTellerProfile = mv_wsAuth.GetTellerProfile(mv_strTicket)

                'TruongLD add when convert
                'newTellerProfile = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetTellerProfile(mv_strTicket))
                'End TruongLD

                Dim v_ws As New AuthManagement
                newTellerProfile = v_ws.GetTellerProfile(mv_strTicket)
            Catch ex As Exception
                Return HandleException(ex)
            End Try

            If newTellerProfile Is Nothing Then
                Return BusLayerResult.AuthenticationFailure
            End If

            'Lưu lại thông tin NSD
            CurrentTellerProfile.BranchId = newTellerProfile.BranchId
            CurrentTellerProfile.BranchName = newTellerProfile.BranchName
            CurrentTellerProfile.Description = newTellerProfile.Description
            CurrentTellerProfile.TellerRight = newTellerProfile.TellerRight
            CurrentTellerProfile.TellerGroup = newTellerProfile.TellerGroup
            CurrentTellerProfile.TellerId = newTellerProfile.TellerId
            CurrentTellerProfile.TellerLevel = newTellerProfile.TellerLevel
            CurrentTellerProfile.TellerName = newTellerProfile.TellerName
            CurrentTellerProfile.TellerPrinterName = newTellerProfile.TellerPrinterName
            CurrentTellerProfile.TellerTitle = newTellerProfile.TellerTitle
            CurrentTellerProfile.BusDate = newTellerProfile.BusDate
            CurrentTellerProfile.Interval = newTellerProfile.Interval
            CurrentTellerProfile.TellerGroupCareBy = newTellerProfile.TellerGroupCareBy
            CurrentTellerProfile.TimeSearch = newTellerProfile.TimeSearch
            CurrentTellerProfile.LoginTime = newTellerProfile.LoginTime
            CurrentTellerProfile.NextDate = newTellerProfile.NextDate
            CurrentTellerProfile.CompanyName = newTellerProfile.CompanyName
            CurrentTellerProfile.CompanyCode = newTellerProfile.CompanyCode
            GetLocalTime(st)

            'st.wHour = Convert.ToUInt16(Strings.Left(CurrentTellerProfile.LoginTime, 2))
            'st.wMinute = Convert.ToUInt16(Strings.Mid(CurrentTellerProfile.LoginTime, 4, 2))
            'st.wSecond = Convert.ToUInt16(Strings.Right(CurrentTellerProfile.LoginTime, 2))

            'SetLocalTime(st)

        End If

        Return ticketResult
    End Function

    'Public Sub BusSystemMessage(ByRef pv_strObjMsg As String)
    '    'TruongLD Comment when convert
    '    'mv_wsAuth.Message(pv_strObjMsg)

    '    'TruongLD Add when convert
    '    Dim strTmpInput As String = pv_strObjMsg
    '    strTmpInput = TripleDesEncryptData(strTmpInput)
    '    CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.Message(strTmpInput))
    '    pv_strObjMsg = TripleDesDecryptData(strTmpInput)
    'End Sub


    Public Sub BusSystemMessage(ByRef pv_strObjMsg As String)
        'TruongLD Comment when convert
        'mv_wsAuth.Message(pv_strObjMsg)

        'TruongLD Add when convert
        Dim strTmpInput As String = pv_strObjMsg

        Dim v_ws As New AuthManagement
        Try
            strTmpInput = TripleDesEncryptData(strTmpInput)
            v_ws.Message(strTmpInput)
            pv_strObjMsg = TripleDesDecryptData(strTmpInput)
        Catch ex As Exception
            'Log lỗi
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
        'CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.Message(strTmpInput))
        'pv_strObjMsg = TripleDesDecryptData(strTmpInput)
    End Sub

#Region "Properties"
    Public ReadOnly Property AppLanguage() As String
        Get
            Return mv_strLanguage
        End Get
    End Property

    Public ReadOnly Property AppIpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
    End Property

    Public ReadOnly Property AppWsName() As String
        Get
            Return mv_strWsName
        End Get
    End Property
#End Region

#Region " Auth Service "
    Private Function GetAuthorizationTicket() As BusLayerResult
        Try
            With CurrentTellerProfile
                'TruongLD comment when convert
                'mv_strTicket = mv_wsAuth.GetAuthorizationTicket(.TellerName, .Password)

                'TruongLD Add when convert
                Dim v_ws As New AuthManagement
                mv_strTicket = v_ws.GetAuthorizationTicket(.TellerName, .Password)
                'End TruongLD
            End With
        Catch ex As Exception
            mv_strTicket = Nothing
            Return HandleException(ex)
        End Try

        If mv_strTicket Is Nothing Then
            'Username/password failed
            Return BusLayerResult.AuthenticationFailure
        ElseIf mv_strTicket = "6" Then
            Return BusLayerResult.AccountBlock
        End If

        Return BusLayerResult.Success
    End Function
#End Region

#Region " Helper Functions "
    Private Function HandleException(ByVal ex As Exception) As BusLayerResult
        CommonLibrary.LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)

        If ex.GetType() Is GetType(WebException) Then
            Return BusLayerResult.ConnectionFailure
        ElseIf ex.GetType() Is GetType(SoapException) Then
            Return BusLayerResult.ServiceFailure
        Else
            Return BusLayerResult.UnknownFailure
        End If
    End Function

    Private Function GetIPAddress() As String
        Try
            Dim sHostName As String = System.Net.Dns.GetHostName()
            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(sHostName)
            Dim IpA() As System.Net.IPAddress = ipE.AddressList
            Dim sAddr As String

            sAddr = IpA(0).ToString

            Return sAddr
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
