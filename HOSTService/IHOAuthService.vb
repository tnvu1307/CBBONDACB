Imports System.ServiceModel
Imports HostCommonLibrary
' NOTE: If you change the class name "IHOAuthService" here, you must also update the reference to "IHOAuthService" in Web.config.
<ServiceContract()> _
Public Interface IHOAuthService

    <OperationContract()> _
    Sub DoWork()

    <OperationContract()> _
    Function GetAuthorizationTicket(ByVal pv_strUserName As String, ByVal pv_strPassword As String) As String

    <OperationContract()> _
    Function GetTellerProfile(ByVal ticket As String) As CTellerProfile

    <OperationContract()> _
    Function GetLeftMenu(ByVal message As String) As Byte()

    <OperationContract()> _
    Function GetLeftAdjustMenu(ByVal message As String) As Byte()

End Interface
