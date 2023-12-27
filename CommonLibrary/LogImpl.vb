Imports System.IO

Imports log4net

Public Enum LogEntryType
    Fatal = -3
    Err = -2
    Warn = -1
    Information = 0
    Debug = 1
End Enum
<Serializable()> _
Public NotInheritable Class LogImpl
    Private Const c_EventSource As String = "SIGMA"
    Private Const c_LogName As String = "Application"

    Public Shared ReadOnly log As ILog = log4net.LogManager.GetLogger(GetType(LogImpl))

    Public Shared Sub Write(ByVal ErrorMessage As String, ByVal ErrorType As LogEntryType)
        Try
            Select Case ErrorType
                Case LogEntryType.Err
                    log.Error(ErrorMessage)
                Case LogEntryType.Information
                    log.Info(ErrorMessage)
                Case LogEntryType.Warn
                    log.Warn(ErrorMessage)
                Case LogEntryType.Debug
                    log.Debug(ErrorMessage)
                Case LogEntryType.Fatal
                    log.Fatal(ErrorMessage)
            End Select
            'Nếu event source đã tồn tại
            'If EventLog.SourceExists(c_EventSource) Then
            '        'Ghi lỗi
            '    Dim msg As EventLog = New EventLog(c_LogName)
            '    msg.Source = c_EventSource
            '    msg.WriteEntry(ErrorMessage, ErrorType)
            'Else 'Event source chưa tồn tại
            '        'Tạo event source cho lần ghi lỗi tiếp theo (cần quyền admin của hệ thống)
            '    EventLog.CreateEventSource(c_EventSource, c_LogName)
            '    Dim msg As EventLog = New EventLog(c_LogName)
            '    msg.Source = c_EventSource
            '    msg.WriteEntry(ErrorMessage, ErrorType)
            '    End If
        Catch ex As Exception
            'Throw ex
            'WriteToFile(ErrorMessage, c_EventSource & "." & c_LogName & ".txt")
        End Try
    End Sub
    Public Shared Sub WriteToFile(ByVal ErrorMessage As String, ByVal pv_strFileName As String)
        Try
            'LoggingFile.Log(DateTime.Now.ToString("::HHmmss::") + ErrorMessage, pv_strFileName)
            Write(DateTime.Now.ToString("::HHmmss::") + ErrorMessage, LogEntryType.Information)
            'Dim v_streamWriter As New StreamWriter(pv_strFileName, True)
            'v_streamWriter.WriteLine(DateTime.Now.ToString("yyyyMMdd-HHmmss::") + ErrorMessage)
            'v_streamWriter.Flush()
            'v_streamWriter.Close()
        Catch ex As Exception
            'Throw ex
            Write(ex.ToString() & Environment.NewLine & ErrorMessage, LogEntryType.Err)
        End Try
    End Sub
End Class

