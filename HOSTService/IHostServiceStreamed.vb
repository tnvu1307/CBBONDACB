Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IHostServiceStreamed" in both code and config file together.
<ServiceContract()>
Public Interface IHostServiceStreamed

    <OperationContract()> _
    Function UploadFile(ByVal data As Byte(), ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As Long

    <OperationContract()> _
    Function DownloadFile(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Byte()
End Interface
