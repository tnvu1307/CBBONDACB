Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Globalization

Public Class CommonLib
    Public Const XPATH_RETURN_DATA As String = "/root/ReturnData"
#Region "Shared Methods"

    Public Shared Function isInt(ByVal obj As Object) As Boolean
        Try
            Int32.Parse(obj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function isNumeric(ByVal obj As Object) As Boolean
        Try
            Decimal.Parse(obj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function isDate(ByVal obj As String, ByVal dateformat As String) As Boolean
        Try
            DateTime.ParseExact(obj, dateformat, Nothing)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function CloneObject(ByVal obj As Object) As Object
        Using memStream As New MemoryStream()
            Dim binaryFormatter As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
            binaryFormatter.Serialize(memStream, obj)
            memStream.Seek(0, SeekOrigin.Begin)
            Return binaryFormatter.Deserialize(memStream)
        End Using
    End Function

    Const STR_DdMMyyyy As String = "dd/MM/yyyy"
    'Private Shared ReadOnly mv_cultureEnInfo As CultureInfo = CultureInfo.InvariantCulture ' New CultureInfo("en-US")
    ''' <summary>
    ''' 20120216: Loctx:  convert string to coressponded data type 
    ''' </summary>
    ''' 
    ''' <param name="pv_NodeList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function XmlToTable(ByVal pv_NodeList As XmlNodeList) As DataTable
        Dim v_dt As DataTable = Nothing
        Dim v_dataType As String = Nothing
        Dim v_dataValue As String = Nothing
        If Not pv_NodeList Is Nothing Then
            If pv_NodeList.Count > 0 Then
                v_dt = New DataTable(pv_NodeList(0).Name)
                For i As Integer = 0 To pv_NodeList.Count - 1
                    'Tao cau truc bang
                    If i = 0 Then
                        Dim v_fchild As XmlNodeList = pv_NodeList(i).ChildNodes
                        If Not v_fchild Is Nothing Then
                            For j As Integer = 0 To v_fchild.Count - 1
                                If Not v_dt.Columns.Contains(v_fchild(j).Attributes("name").Value) Then
                                    v_dt.Columns.Add(v_fchild(j).Attributes("name").Value, Type.GetType(v_fchild(j).Attributes("type").Value))
                                End If
                            Next
                        End If
                    End If
                    'End
                    Dim v_dr As DataRow = v_dt.NewRow()

                    Dim v_child As XmlNodeList = pv_NodeList(i).ChildNodes
                    If Not v_child Is Nothing Then
                        For j As Integer = 0 To v_child.Count - 1
                            v_dataType = v_child(j).Attributes("type").Value
                            v_dataValue = v_child(j).InnerXml
                            'Loc sua 20120116: convert string to related data type
                            Select Case v_dataType
                                Case "System.DateTime"
                                    If Not String.IsNullOrEmpty(v_dataValue) Then
                                        v_dr(v_child(j).Attributes("name").Value) = DateTime.ParseExact(v_dataValue, STR_DdMMyyyy, Nothing)
                                    Else
                                        v_dr(v_child(j).Attributes("name").Value) = DBNull.Value
                                    End If
                                Case "System.Decimal", "System.Integer", "System.Int32", "System.Int64", "System.Double"
                                    If Not String.IsNullOrEmpty(v_dataValue) AndAlso CommonLib.isNumeric(v_dataValue) Then
                                        Select Case v_dataType
                                            Case "System.Decimal"
                                                v_dr(v_child(j).Attributes("name").Value) = Convert.ToDecimal(v_dataValue, CultureInfo.InvariantCulture)
                                            Case "System.Integer", "System.Int32"
                                                v_dr(v_child(j).Attributes("name").Value) = Convert.ToInt32(v_dataValue, CultureInfo.InvariantCulture)
                                            Case "System.Int64"
                                                v_dr(v_child(j).Attributes("name").Value) = Convert.ToInt64(v_dataValue, CultureInfo.InvariantCulture)
                                            Case "System.Double"
                                                v_dr(v_child(j).Attributes("name").Value) = Convert.ToDouble(v_dataValue, CultureInfo.InvariantCulture)
                                        End Select
                                    Else
                                        v_dr(v_child(j).Attributes("name").Value) = "0"
                                    End If
                                Case Else
                                    v_dr(v_child(j).Attributes("name").Value) = v_dataValue
                            End Select
                        Next
                    End If

                    v_dt.Rows.Add(v_dr)
                Next
            End If
        End If
        Return v_dt
    End Function


    Public Shared Function ConvertTableToXml(ByVal ds As DataTable, Optional ByVal pv_tableName As String = "") As String
        If Not String.IsNullOrEmpty(pv_tableName) Then
            ds.TableName = pv_tableName
        End If
        Using v_stringWriter As New StringWriter()
            ds.WriteXml(v_stringWriter, XmlWriteMode.WriteSchema)
            Return v_stringWriter.ToString
        End Using
    End Function

    Public Shared Function ConvertXmlToTable(ByVal pv_str As String) As DataTable
        If String.IsNullOrEmpty(pv_str) Then
            Return Nothing
        End If
        Dim v_dt As New DataTable
        Using v_stringReader As New StringReader(pv_str)
            v_dt.ReadXml(v_stringReader)
            Return v_dt
        End Using
    End Function
    Public Shared Function ConvertXmlToDataSet(ByVal pv_str As String) As DataSet
        If String.IsNullOrEmpty(pv_str) Then
            Return Nothing
        End If
        Dim v_ds As New DataSet
        Using v_stringReader As New StringReader(pv_str)
            v_ds.ReadXml(v_stringReader)
            Return v_ds
        End Using
    End Function

#Region "Distinct row"

    Public Shared Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ColumnName As String) As DataTable
        Dim htCol As New Hashtable
        Dim v_dt As DataTable = Nothing

        If Not SourceTable Is Nothing Then
            v_dt = SourceTable
            For i As Integer = 0 To v_dt.Rows.Count - 1
                If Not htCol.ContainsKey(v_dt.Rows(i)(ColumnName)) Then
                    htCol.Add(v_dt.Rows(i)(ColumnName), "")
                Else
                    v_dt.Rows.RemoveAt(i)
                End If
                If i = v_dt.Rows.Count - 1 Then
                    Exit For
                End If
            Next
        End If

        Return v_dt
    End Function

#End Region

#End Region
End Class
