Imports System.IO
Imports System.Data
'Imports System.Data.SQLite


'Class sử dụng SQLite để cache dữ liệu dùng chung
Public Class CacheOnSQLite
    Private pv_strDatabalseFile As String
    Private pv_strPathFile As String
    Private pv_strSQL As String
    Private pv_ds As New DataSet
    'Private pv_SQLiteCons As New SQLite.SQLiteConnection
    'Private pv_cmdSQL As New SQLite.SQLiteCommand
    'Private pv_da As New SQLite.SQLiteDataAdapter

    Public Sub New(ByVal v_strFileName As String)
        'pv_strDatabalseFile = v_strFileName
        'pv_strPathFile = Environment.CurrentDirectory() & "\" & v_strFileName
        ''Kiểm tra nếu chưa có file thì tự động tạo trên cơ sở File mẫu có sẵn
        'Dim fFile As New FileInfo(pv_strPathFile)
        'If Not fFile.Exists Then
        '    'Tạo file database từ mẫu có sẵn
        '    FileCopy(Environment.CurrentDirectory() & "\FlexOrgDBCache.db3", pv_strPathFile)
        'End If

        ''Mở file database
        'pv_SQLiteCons.ConnectionString = "Data Source=" & pv_strPathFile & "; Version=3"
        'pv_SQLiteCons.Open()

        ''pv_cmdSQL = "create table Ramya(Elename varchar(50))"
        ''das = New SQLite.SQLiteDataAdapter(strSQL, cons)
        ''das.Fill(dss, "ramya")
        ''pv_cmdSQL = pv_SQLiteCons.CreateCommand()
        ''pv_cmdSQL.CommandText = "INSERT INTO Ramya VALUES('Microsoft')"
        ''pv_cmdSQL.CommandType = CommandType.Text
        ''pv_cmdSQL.ExecuteNonQuery()
        ''pv_cmdSQL.Dispose()
    End Sub

    Public Sub Dispose()
        'pv_SQLiteCons.Close()
        'pv_ds = Nothing
        'pv_da = Nothing
        'pv_SQLiteCons = Nothing
        'pv_cmdSQL = Nothing
    End Sub
End Class
