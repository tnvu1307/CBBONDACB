Imports System
Imports System.Data
Imports System.Xml
Imports System.Text
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports HostCommonLibrary


Public Class OracleHelper

#Region " Các phương thức private và hàm constructor "
    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Lớp này chỉ cung cấp các static method, viết hàm constructor này nhằm chống việc
    '               khai báo biến theo kiểu "new OracleHelper()"
    ' + Đầu vào:    N/A
    ' + Đầu ra:     N/A
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Private Sub New()
        'Không làm gì cả
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Hàm này dùng để thêm một mảng OracleParameter vào một OracleCommand.
    '               Hàm này sử dụng giá trị DbNull cho tất cả các tham số InputOutput và có giá trị
    '               là null.
    ' + Đầu vào:    
    '       - Command:              OracleCommand được thêm mảng các OracleParameter.
    '       - CommandParameter():   Mảng các OracleParameter thêm vào trong OracleCommand.
    ' + Đầu ra:     N/A
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Private Shared Sub AttachParameters(ByVal Command As OracleCommand, ByVal CommandParameter() As OracleParameter)
        Dim p As OracleParameter

        For Each p In CommandParameter
            If (p.Direction = ParameterDirection.InputOutput) And (p.Value Is Nothing) Then
                p.Value = Nothing
            End If
            Command.Parameters.Add(p)
        Next p
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Hàm này dùng để gán một mảng các giá trị cho một mảng các tham số
    ' + Đầu vào:    
    '       - CommandParameters:    Mảng các tham số được gán giá trị
    '       - ParameterValues:      Mảng các giá trị
    ' + Đầu ra:     N/A
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Private Shared Sub AssignParameterValues(ByVal CommandParameters() As OracleParameter, ByVal ParameterValues() As Object)
        Dim i, j As Short

        If (CommandParameters Is Nothing) And (ParameterValues Is Nothing) Then
            'Không làm gì cả nếu chúng ta không có dữ liệu
            Return
        End If

        'Số lượng các tham số và số lượng các giá trị phải bằng nhau
        If CommandParameters.Length <> ParameterValues.Length Then
            Throw New ArgumentException("Số lượng giá trị các tham số không bằng số lượng các tham số!")
        End If

        'Gán giá trị cho tham số
        j = CommandParameters.Length - 1
        For i = 0 To j
            CommandParameters(i).Value = ParameterValues(i)
        Next
    End Sub

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Gán các tham số cần thiết cho 1 command
    ' + Đầu vào:    
    '       - Command:              Lệnh
    '       - Connection:           Kết nối đến CSDL
    '       - CommandType:          Loại command
    '       - CommandText:          Câu lệnh của command (tên stored procedure hoặc câu lệnh SQL)
    '       - CommandParameters():  Mảng các tham số của command
    ' + Đầu ra:     N/A
    ' + Trả về:     N/A
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Private Shared Sub PrepareCommand(ByRef Command As OracleCommand, _
                                      ByVal Connection As OracleConnection, _
                                      ByVal CommandType As CommandType, _
                                      ByVal CommandText As String, _
                                      ByVal CommandParameters() As OracleParameter)

        'Gán command text (là tên của stored procedure hoặc câu lệnh SQL)
        Command.CommandText = CommandText

        'Gán command type
        Command.CommandType = CommandType

        'Không có timeout
        Command.CommandTimeout = 0 '30 phút

        'Mở kết nối đến CSDL
        If Connection.State <> ConnectionState.Open Then
            Connection.Open()

            Dim sessionGlobalization As OracleGlobalization = Connection.GetSessionInfo()
            sessionGlobalization.DateFormat = gc_FORMAT_DATE_Db
            Connection.SetSessionInfo(sessionGlobalization)

        End If

        'Gán connection cho command
        Command.Connection = Connection


        'Attach các tham số cho câu lệnh
        If Not (CommandParameters Is Nothing) Then
            AttachParameters(Command, CommandParameters)
        End If

        Return
    End Sub
#End Region

#Region " ExecuteNonQuery "
    Public Overloads Shared Function ExecuteNonQuery(ByVal ConnectionString As String, _
                                                     ByVal CommandType As CommandType, _
                                                     ByVal CommandText As String) As Integer
        'Chuyển cho lời gọi hàm ExecuteNonQuery với mảng các tham số là Nothing
        Return ExecuteNonQuery(ConnectionString, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteNonQuery(ByVal ConnectionString As String, _
                                                         ByVal CommandType As CommandType, _
                                                         ByVal CommandText As String, _
                                                         ByVal ParamArray CommandParameters() As OracleParameter) As Integer
        'Tạo kết nối đến CSDL, dispose sau khi dùng xong
        Dim cn As New OracleConnection(ConnectionString)

        Try
            'cn.Open()

            'Chuyển cho hàm ExecuteNonQuery với Connection thay cho ConnectionString
            Return ExecuteNonQuery(cn, CommandType, CommandText, CommandParameters)
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteNonQuery(ByVal Connection As OracleConnection, _
                                                     ByVal CommandType As CommandType, _
                                                     ByVal CommandText As String, _
                                                     ByVal ParamArray CommandParameters() As OracleParameter) As Integer
        'Tạo 1 command và chuẩn bị các tham số
        
        Dim cmd As New OracleCommand
        Dim retval As Integer
        Try
            PrepareCommand(cmd, Connection, CommandType, CommandText, CommandParameters)

            'Execute the command
            retval = cmd.ExecuteNonQuery

            'Clear các tham số khỏi command để có thể sử dụng lại về sau
            cmd.Parameters.Clear()

        Catch ex As Exception
            Throw ex
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
        End Try

        Return retval
    End Function

    Public Overloads Shared Function ExecuteNonQuery(ByVal ConnectionString As String, _
                                                     ByVal StoredProceduredName As String, _
                                                     ByVal ParameterNames() As Object, _
                                                     ByVal ParameterValues() As Object, _
                                                     ByVal ParameterTypes() As Object) As Integer
        Dim CommandParameters As OracleParameter()
        Dim cn As OracleConnection
        Dim cmd As OracleCommand
        Try


            'Nếu có giá trị của tham số
            If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
                cn = New OracleConnection(ConnectionString)
                cmd = New OracleCommand(StoredProceduredName)
                For i As Integer = 0 To ParameterNames.Length - 1
                    Dim v_Parameter As OracleParameter
                    cmd.CommandType = CommandType.StoredProcedure
                    v_Parameter = New OracleParameter(CStr(ParameterNames(i)), ParameterTypes(i))
                    v_Parameter.Direction = ParameterDirection.Input
                    v_Parameter.Value = ParameterValues(i)
                    cmd.Parameters.Add(v_Parameter)
                Next
                cn.Open()
                cmd.Connection = cn
                Return cmd.ExecuteNonQuery()
            Else 'Không có giá trị của tham số
                'Thực hiện command không có tham số
                Return ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, StoredProceduredName)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Connection.Close()
            cmd.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteNonQuery(ByVal Connection As OracleConnection, _
                                                     ByVal CommandType As CommandType, _
                                                     ByVal CommandText As String) As Integer
        Return ExecuteNonQuery(Connection, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteNonQuery(ByVal Connection As OracleConnection, _
                                                     ByVal StoredProceduredName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(Connection.ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, parameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteNonQuery(Connection, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteNonQuery(Connection, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function

#End Region

#Region " ExecuteDataset "
    Public Overloads Shared Function ExecuteDataset(ByVal ConnectionString As String, _
                                                    ByVal CommandType As CommandType, _
                                                    ByVal CommandText As String) As DataSet
        Return ExecuteDataset(ConnectionString, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteDataset(ByVal ConnectionString As String, _
                                                    ByVal CommandType As CommandType, _
                                                    ByVal CommandText As String, _
                                                    ByVal ParamArray CommandParameters() As OracleParameter) As DataSet
        'Tạo kết nối đến CSDL, dispose sau khi sử dụng xong
        Dim cn As New OracleConnection(ConnectionString)

        Try
            cn.Open()

            Return ExecuteDataset(cn, CommandType, CommandText, CommandParameters)
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteDataset(ByVal Connection As OracleConnection, _
                                                    ByVal CommandType As CommandType, _
                                                    ByVal CommandText As String, _
                                                    ByVal ParamArray CommandParameters() As OracleParameter) As DataSet
        Dim cmd As New OracleCommand
        Dim ds As New DataSet
        Dim da As New OracleDataAdapter
        Try
            'Tạo command và chuẩn bị các tham số


            PrepareCommand(cmd, Connection, CommandType, CommandText, CommandParameters)

            'Tạo DataAdapter và DataSet
            da = New OracleDataAdapter(cmd)

            'Fill dữ liệu vào DataSet
            da.Fill(ds)

            'Clear các tham số của command
            cmd.Parameters.Clear()

            'Trả về DataSet
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
            ds.Dispose()
            da.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteDataset(ByVal ConnectionString As String, _
                                                    ByVal StoredProceduredName As String, _
                                                    ByVal ParamArray ParameterValues() As Object) As DataSet
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function

    Public Overloads Shared Function ExecuteDataset(ByVal Connection As OracleConnection, _
                                                    ByVal CommandType As CommandType, _
                                                    ByVal CommandText As String) As DataSet
        Return ExecuteDataset(Connection, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteDataset(ByVal Connection As OracleConnection, _
                                                    ByVal StoredProceduredName As String, _
                                                    ByVal ParamArray ParameterValues() As Object) As DataSet
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(Connection.ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteDataset(Connection, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteDataset(Connection, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function
#End Region

#Region " ExecuteReader "
    Private Enum OracleConnectionOwnership
        'Connection is owned and managed by OracleHelper
        Internal
        'Connection is owned and managed by the caller
        [External]
    End Enum

    Private Overloads Shared Function ExecuteReader(ByVal Connection As OracleConnection, _
                                                    ByVal CommandType As CommandType, _
                                                    ByVal CommandText As String, _
                                                    ByVal CommandParameters() As OracleParameter, _
                                                    ByVal ConnectionOwnerShip As OracleConnectionOwnership) As OracleDataReader
        'Tạo command
        Dim cmd As New OracleCommand
        'Khai báo Reader
        Dim dr As OracleDataReader
        Try
            PrepareCommand(cmd, Connection, CommandType, CommandText, CommandParameters)

            'ExecuteReader with the appropriate CommandBehavior
            If ConnectionOwnerShip = OracleConnectionOwnership.External Then
                dr = cmd.ExecuteReader()
            Else
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            'Clear tham số của command
            cmd.Parameters.Clear()

            Return dr
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
            dr.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal ConnectionString As String, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String) As OracleDataReader
        Return ExecuteReader(ConnectionString, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal ConnectionString As String, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String, _
                                                   ByVal ParamArray CommandParameters() As OracleParameter) As OracleDataReader
        'Tạo kết nối đến CSDL, dispose khi sử dụng xong
        Dim cn As New OracleConnection(ConnectionString)

        Try
            cn.Open()

            Return ExecuteReader(cn, CommandType, CommandText, CommandParameters, OracleConnectionOwnership.Internal)
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal ConnectionString As String, _
                                                   ByVal StoredProceduredName As String, _
                                                   ByVal ParamArray ParameterValues() As Object) As OracleDataReader
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteReader(ConnectionString, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteReader(ConnectionString, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal Connection As OracleConnection, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String) As OracleDataReader
        Return ExecuteReader(Connection, CommandType, CommandText, CType(Nothing, OracleParameter))
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal Connection As OracleConnection, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String, _
                                                   ByVal ParamArray CommandParameters() As OracleParameter) As OracleDataReader
        Return ExecuteReader(Connection, CommandType, CommandText, CommandParameters, OracleConnectionOwnership.External)
    End Function

    Public Overloads Shared Function ExecuteReader(ByVal Connection As OracleConnection, _
                                                   ByVal StoredProceduredName As String, _
                                                   ByVal ParamArray ParameterValues() As Object) As OracleDataReader
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(Connection.ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteReader(Connection, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteReader(Connection, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function
#End Region

#Region " ExecuteScalar "
    Public Overloads Shared Function ExecuteScalar(ByVal ConnectionString As String, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String) As Object
        Return ExecuteScalar(ConnectionString, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteScalar(ByVal ConnectionString As String, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String, _
                                                   ByVal ParamArray CommandParameters() As OracleParameter) As Object
        'Tạo kết nối đến CSDL, dispose sau khi sử dụng xong
        Dim cn As OracleConnection

        Try
            cn = New OracleConnection(ConnectionString)
            cn.Open()

            Return ExecuteScalar(cn, CommandType, CommandText, CommandParameters)
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Shared Function ExecuteScalar(ByVal ConnectionString As String, _
                                                   ByVal StoredProceduredName As String, _
                                                   ByVal ParamArray ParameterValues() As Object) As Object
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteScalar(ConnectionString, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteScalar(ConnectionString, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function

    Public Overloads Shared Function ExecuteScalar(ByVal Connection As OracleConnection, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String) As Object
        Return ExecuteScalar(Connection, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteScalar(ByVal Connection As OracleConnection, _
                                                   ByVal CommandType As CommandType, _
                                                   ByVal CommandText As String, _
                                                   ByVal ParamArray CommandParameters() As OracleParameter) As Object
        'Tạo command
        Dim cmd As New OracleCommand
        Dim retval As Object
        Try
            PrepareCommand(cmd, Connection, CommandType, CommandText, CommandParameters)

            retval = cmd.ExecuteScalar()

            'Clear tham số của command
            cmd.Parameters.Clear()

            Return retval
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
        End Try
        
    End Function

    Public Overloads Shared Function ExecuteScalar(ByVal Connection As OracleConnection, _
                                                   ByVal StoredProceduredName As String, _
                                                   ByVal ParamArray ParameterValues() As Object) As Object
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(Connection.ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteScalar(Connection, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteScalar(Connection, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function
#End Region

#Region " ExecuteXmlReader "
    Public Overloads Shared Function ExecuteXmlReader(ByVal Connection As OracleConnection, _
                                                      ByVal CommandType As CommandType, _
                                                      ByVal CommandText As String) As XmlReader
        Return ExecuteXmlReader(Connection, CommandType, CommandText, CType(Nothing, OracleParameter()))
    End Function

    Public Overloads Shared Function ExecuteXmlReader(ByVal Connection As OracleConnection, _
                                                      ByVal CommandType As CommandType, _
                                                      ByVal CommandText As String, _
                                                      ByVal ParamArray CommandParameters() As OracleParameter) As XmlReader
        'Tạo command
        Dim cmd As New OracleCommand
        Dim retval As XmlReader
        Try
            PrepareCommand(cmd, Connection, CommandType, CommandText, CommandParameters)

            retval = cmd.ExecuteXmlReader()

            'Clear tham số của command
            cmd.Parameters.Clear()

            Return retval
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
        End Try

    End Function

    Public Overloads Shared Function ExecuteXmlReader(ByVal Connection As OracleConnection, _
                                                      ByVal StoredProceduredName As String, _
                                                      ByVal ParamArray ParameterValues() As Object) As XmlReader
        Dim CommandParameters As OracleParameter()

        'Nếu có giá trị của tham số
        If Not (ParameterValues Is Nothing) And ParameterValues.Length > 0 Then
            'Lấy danh sách các tham số của Stored Procedured
            CommandParameters = OracleHelperParameterCache.GetSpParameterSet(Connection.ConnectionString, StoredProceduredName)

            'Gán giá trị cho các tham số
            AssignParameterValues(CommandParameters, ParameterValues)

            'Thực hiện command với bộ tham số
            Return ExecuteXmlReader(Connection, CommandType.StoredProcedure, StoredProceduredName, CommandParameters)
        Else 'Không có giá trị của tham số
            'Thực hiện command không có tham số
            Return ExecuteXmlReader(Connection, CommandType.StoredProcedure, StoredProceduredName)
        End If
    End Function
#End Region



#Region "Bulk Copy - Oracle"
    Public Shared Function GenerateInsertCommand(ByVal srcDataRow As DataRow) As String
        Dim sb As New StringBuilder(), sbfields As New StringBuilder(), sbvalues As New StringBuilder()
        'Loop for each column
        Dim parmcount As Integer = 0
        For Each dc As DataColumn In srcDataRow.Table.Columns
            sbfields.Append(dc.ColumnName).Append(",")
            sbvalues.Append("" & IIf(srcDataRow(dc.ColumnName) Is DBNull.Value, "NULL", srcDataRow(dc.ColumnName)) & ",")
        Next
        sb.Append("INSERT INTO ")
        sb.Append(srcDataRow.Table.TableName)
        sb.Append(" (")
        sb.Append(sbfields.ToString(0, sbfields.Length - 1))
        sb.Append(") VALUES (")
        sb.Append(sbvalues.ToString(0, sbvalues.Length - 1))
        sb.Append(")")
        Return sb.ToString()
    End Function
    Public Shared Function BulkCopyDataTable(ByVal connstr As String, ByVal srcDataTable As DataTable) As Integer
        Dim i As Integer = 0
        Try
            For Each dr As DataRow In srcDataTable.Rows
                ExecuteNonQuery(connstr, CommandType.Text, GenerateInsertCommand(dr))
                i += 1
            Next
        Catch ex As Exception
            Return -1
        Finally
        End Try
        Return i
    End Function
#End Region
End Class

Public Class OracleHelperParameterCache

#Region " Các private method, khai báo biến và hàm constructor "
    Private Sub New()
        'Không làm gì cả
    End Sub

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    Private Shared Function DiscoverSpParameterSet(ByVal ConnectionString As String, _
                                                   ByVal StoredProceduredName As String, _
                                                   ByVal IncludeReturnValueParameter As Boolean, _
                                                   ByVal ParamArray ParameterValues() As Object) As OracleParameter()
        'Dim cn As New OracleConnection(ConnectionString)
        'Dim cmd As OracleCommand = New OracleCommand(StoredProceduredName, cn)
        'Dim DiscoveredParameters() As OracleParameter

        'Try
        '    cn.Open()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    OracleCommandBuilder.DeriveParameters(cmd)
        '    If Not IncludeReturnValueParameter Then
        '        cmd.Parameters.RemoveAt(0)
        '    End If

        '    DiscoveredParameters = New OracleParameter(cmd.Parameters.Count - 1) {}
        '    cmd.Parameters.CopyTo(DiscoveredParameters, 0)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    cmd.Dispose()
        '    cn.Dispose()
        'End Try

        'Return DiscoveredParameters
    End Function

    Private Shared Function CloneParameters(ByVal OriginalParameters() As OracleParameter) As OracleParameter()
        Dim i As Short
        Dim j As Short = OriginalParameters.Length - 1
        Dim ClonedParameters(j) As OracleParameter

        For i = 0 To j
            ClonedParameters(i) = CType(CType(OriginalParameters(i), ICloneable).Clone, OracleParameter)
        Next

        Return ClonedParameters
    End Function
#End Region

#Region " Caching functions "
    Public Shared Sub CacheParameterSet(ByVal ConnectionString As String, _
                                        ByVal CommandText As String, _
                                        ByVal ParamArray CommandParameters() As OracleParameter)
        Dim hashKey As String = ConnectionString + ":" + CommandText

        paramCache(hashKey) = CommandParameters
    End Sub

    Public Shared Function GetCachedParameterSet(ByVal ConnectionString As String, ByVal CommandText As String) As OracleParameter()
        Dim hashKey As String = ConnectionString + ":" + CommandText
        Dim CachedParameters As OracleParameter() = CType(paramCache(hashKey), OracleParameter())

        If CachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(CachedParameters)
        End If
    End Function
#End Region

#Region " Parameter Discovery Functions "
    Public Overloads Shared Function GetSpParameterSet(ByVal ConnectionString As String, ByVal StoredProceduredName As String) As OracleParameter()
        Return GetSpParameterSet(ConnectionString, StoredProceduredName, False)
    End Function

    Public Overloads Shared Function GetSpParameterSet(ByVal ConnectionString As String, _
                                                       ByVal StoredProceduredName As String, _
                                                       ByVal IncludeReturnValueParameter As Boolean) As OracleParameter()
        Dim CachedParameters() As OracleParameter
        Dim hashKey As String

        hashKey = ConnectionString + ":" + StoredProceduredName + IIf(IncludeReturnValueParameter = True, ":include ReturnValue Parameter", "")

        CachedParameters = CType(paramCache(hashKey), OracleParameter())

        If (CachedParameters Is Nothing) Then
            paramCache(hashKey) = DiscoverSpParameterSet(ConnectionString, StoredProceduredName, IncludeReturnValueParameter)
            CachedParameters = CType(paramCache(hashKey), OracleParameter())
        End If

        Return CloneParameters(CachedParameters)
    End Function
#End Region

End Class
