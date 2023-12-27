<Serializable()> _
Public NotInheritable Class LogError
    Private Const c_EventSource As String = "@VSTP"
    Private Const c_LogName As String = "Application"

    Public Shared Sub Write(ByVal ErrorMessage As String, ByVal ErrorType As EventLogEntryType)
        Try
            'Nếu event source đã tồn tại
            If EventLog.SourceExists(c_EventSource) Then
                'Ghi lỗi
                Dim msg As EventLog = New EventLog(c_LogName)
                msg.Source = c_EventSource
                msg.WriteEntry(ErrorMessage, ErrorType)
            Else 'Event source chưa tồn tại
                'Tạo event source cho lần ghi lỗi tiếp theo (cần quyền admin của hệ thống)
                EventLog.CreateEventSource(c_EventSource, c_LogName)
            End If
        Catch

        End Try
    End Sub
End Class

