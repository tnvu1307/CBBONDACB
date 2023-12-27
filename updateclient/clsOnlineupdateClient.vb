Imports CommonLibrary
Imports Microsoft.Win32
Imports System.IO
Imports System.net
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Public Class clsClient

    Public Event endall() 'raised, is update is made and the parent-app should exit

    Public wClient As WebClient

    Public Sub GetNewVersion(ByVal processname As String, ByVal processexe As String, ByVal pv_RegistryKey As String, ByVal pv_version As String, ByVal url As String, ByVal v_oldVersion As String, ByVal UType As Integer)
        Try
            GetNewVersionClient(processname, processexe, pv_version, url, v_oldVersion, UType)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub GetNewVersionClient(ByVal processname As String, ByVal processexe As String, ByVal pv_version As String, ByVal url As String, ByVal v_oldVersion As String, ByVal UType As Integer)
        Try

            Dim v_strReportDir As String = GetDirectoryName(ExecutablePath) & "\REPORTS\"

            If Exists(GetDirectoryName(ExecutablePath) & "\update.exe.config") Then
                Delete(GetDirectoryName(ExecutablePath) & "\update.exe.config")
            End If
            If url Is Nothing Then
                url = "http://localhost/Deployment/Client"
            End If

            Dim sw As StreamWriter = New StreamWriter(GetDirectoryName(ExecutablePath) & "\update.exe.config", False)
            sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            sw.WriteLine("<configuration>")
            sw.WriteLine("	<appSettings>")
            sw.WriteLine("		<add key=""Update"" value=""1"" />")
            sw.WriteLine("		<add key=""ProcessName"" value=""" & processname & """ />")
            sw.WriteLine("		<add key=""Version"" value=""" & pv_version & """ />")
            sw.WriteLine("		<add key=""WaitParentToExit"" value=""1"" />")
            sw.WriteLine("		<add key=""KillParentAfterWait"" value=""1"" />")
            sw.WriteLine("		<add key=""UpdateURL"" value=""" & url & "/" & pv_version & ".zip"" />")
            sw.WriteLine("		<add key=""BasePath"" value=""" & GetDirectoryName(ExecutablePath) & """ />")
            sw.WriteLine("		<add key=""StartExe"" value=""" & processexe & """ />")
            sw.WriteLine("		<add key=""KillParentAfterWait"" value=""1"" />")
            sw.WriteLine("		<add key=""ReportPath"" value=""" & v_strReportDir & """ />")
            sw.WriteLine("		<add key=""OldVersion"" value=""" & v_oldVersion & """ />")
            sw.WriteLine("		<add key=""UpdateType"" value=""" & UType & """ />")
            sw.WriteLine("	</appSettings>")
            sw.WriteLine("</configuration>")
            sw.Flush()
            sw.Close()
            If FileLen(GetDirectoryName(ExecutablePath) & "\update.exe") > 0 Then
                Process.Start(GetDirectoryName(ExecutablePath) & "\update.exe")
                RaiseEvent endall()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
