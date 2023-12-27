' NOTE: You can use the "Rename" command on the context menu to change the class name "HostServiceStreamed" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select HostServiceStreamed.svc or HostServiceStreamed.svc.vb at the Solution Explorer and start debugging.
Imports HostCommonLibrary
Imports DataAccessLayer

Public Class HostServiceStreamed
    Implements IHostServiceStreamed

    Public Function UploadFile(ByVal data As Byte(), ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As Long Implements IHostServiceStreamed.UploadFile

        Dim v_lngErr As Long = ERR_SYSTEM_OK
        Try
            Dim v_DataAccess As New DataAccess
            v_lngErr = v_DataAccess.UpdateBlobData(data, fieldname, pk_fieldname, pk_value, tableName)
            'Dim v_ws As New HostDeliveryManagement
            'v_lngErr = v_ws.UploadFile(data, fieldname, pk_fieldname, pk_value, tableName)
            Return v_lngErr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DownloadFile(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Byte() Implements IHostServiceStreamed.DownloadFile
        Try
            Dim v_ws As New DataAccess
            Return v_ws.DownloadFileFromBlob(pv_FieldName, pv_pkFieldName, pv_pkValue, pv_TableName)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

End Class
