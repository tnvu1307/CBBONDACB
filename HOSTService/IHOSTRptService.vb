Imports System.ServiceModel

' NOTE: If you change the class name "IHOSTRptService" here, you must also update the reference to "IHOSTRptService" in Web.config.
<ServiceContract()> _
Public Interface IHOSTRptService

    <OperationContract()> _
    Sub DoWork()

    <OperationContract()> _
    Function MessageString(ByRef pv_strMessage As String) As Long

    <OperationContract()>
    Function MessageByte(ByRef pv_arrByteMessage As Byte()) As Long

End Interface