Imports System.Xml
Imports HostCommonLibrary
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports Ionic.Zip
Imports System.IO
'Imports System.IO.Compression
Imports System.Collections.Generic
Imports System.Text


Public Class ZipUtils
    Public Shared Function UnZipData(ByVal content As String) As String
        Dim v_strReturn As String = String.Empty
        Try
            Dim v_objStream As New MemoryStream(Convert.FromBase64String(content))
            Dim v_objFile As ZipFile = ZipFile.Read(v_objStream)

            If Not v_objFile Is Nothing Then
                For Each v_objEntry As ZipEntry In v_objFile
                    If v_objEntry.FileName.Equals("tmp.txt") Then
                        Dim v_objOutStream As New MemoryStream
                        v_objEntry.Extract(v_objOutStream)
                        If Not v_objOutStream Is Nothing Then
                            v_objOutStream.Seek(0, SeekOrigin.Begin)
                            Dim v_objReader As New StreamReader(v_objOutStream)
                            If Not v_objReader Is Nothing Then
                                v_strReturn = v_objReader.ReadToEnd()
                            End If
                            v_objOutStream.Flush()
                            v_objOutStream.Close()
                        End If
                    End If
                Next
                v_objFile.Dispose()
                Return v_strReturn
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function
End Class