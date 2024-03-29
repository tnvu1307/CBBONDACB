﻿Imports System.ServiceModel

' NOTE: If you change the class name "IHOSTService" here, you must also update the reference to "IHOSTService" in Web.config.
<ServiceContract()> _
Public Interface IHOSTService

    <OperationContract()> _
    Sub DoWork()

    <OperationContract()> _
    Function MessageByte(ByRef pv_arrByteMessage As Byte()) As Long

    <OperationContract()>
    Function GetVersion(ByRef pv_arrByteMessage() As Byte) As Long

    <OperationContract()> _
    Function MessageString(ByRef pv_strMessage As String) As Long

    <OperationContract()> _
    Function OMessageByte(ByVal pv_arrByteMessage As Byte()) As Object()

    <OperationContract()> _
    Function OMessageString(ByVal pv_strMessage As String) As Object()

    <OperationContract()>
    Function GetFlagSignature() As String

    <OperationContract()>
    Function GetTicketAccount(ByRef pv_arrByteMessage As Byte()) As Long

    <OperationContract()>
    Function GetInfoAuthorMicrosoft(ByRef pv_arrByteMessage As Byte()) As Long

    <OperationContract()>
    Function GetSecondsLimitAFK(ByRef pv_arrByteMessage As Byte()) As Long
End Interface
'End Namespace