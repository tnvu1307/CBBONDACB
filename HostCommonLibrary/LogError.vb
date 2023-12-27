Imports log4net

Public NotInheritable Class LogError
    Private ReadOnly Log As ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Write(ByVal ErrorMessage As String, Optional ByVal ErrorType As String = "", Optional ByVal Tag As String = "")
        Try
            If ErrorType = "EventLogEntryType.Error" Then
                Log.Error("::" & Tag & "::" & ErrorMessage)
            ElseIf ErrorType = "EventLogEntryType.Information" Then
                Log.Info("::" & Tag & "::" & ErrorMessage)
            Else
                If Log.IsDebugEnabled Then
                    Log.Debug("::" & Tag & "::" & ErrorMessage)
                End If
            End If
        Catch ex As Exception
            Log.Error("::LogError.Write:: " & ex.Message)
        End Try
    End Sub

    Public Sub WriteException(ByVal exc As Exception)
        Dim errStr = "Error source : {0}. Error code: {1}. Error message: {2}."
        Try
            Log.Error(String.Format(errStr, exc.Source, exc.StackTrace, exc.Message))
        Catch ex As Exception
            Log.Error(String.Format(errStr, ex.Source, ex.StackTrace, ex.Message))
        End Try
    End Sub
End Class

