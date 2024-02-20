Imports System.Data
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports System.Configuration
Imports HostCommonLibrary
Imports System.IO

'TruongLD comment when convert
'Imports System.EnterpriseServices

Public Enum DBProvider
    OracleClient = 0
    SQLClient = 1
    ODBC = 2
    OLEDB = 3
    Access = 4
End Enum

'TruongLD comment when convert
'<Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=4, MaxPoolSize:=10000)> _
Public Class DataAccess
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Const c_LogCommandFilePath As String = "LogCommandFilePath"
    Private mv_strModule As String = gc_MODULE_BDS
    Private mv_strConnectionString As String
    Private mv_dbProvider As DBProvider
    Private mv_blnLogCommand As Boolean = False
    Private mv_strLogFileName As String

    'TruongLD add value using for TraceSQLCmd
    Private mv_strTrace As String ', mv_strDBModule As String


#Region " Hàm constructor "

    Public Sub New()
        _InitClass(mv_strModule)
    End Sub

    ''' <summary>
    ''' DuongLH them ham khoi tao moi voi module
    ''' </summary>
    ''' <param name="pv_strModule"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pv_strModule As String)
        mv_strModule = pv_strModule
        _InitClass(pv_strModule)
    End Sub
    Public Sub NewDBInstance(ByVal pv_strModule As String)
        _InitClass(pv_strModule)
    End Sub
    '********************************************************************
    'Mục đích       	: Khởi tạo thông số của CSDL mà CLASS sẽ kết nối tới
    'Tham số        	: 
    '                       pv_strModule: Tên DB của phân hệ mà sẽ truy cập tới   
    'Trả về         	    : 
    'Ngày tạo			: 
    'Ngày cập nhật  	: 2013-03-14
    'Người cập nhật 	: DuongLH
    'Noi dung           : Them tham so config .PWDK de support ma hoa password
    '********************************************************************
    Private Sub _InitClass(ByVal pv_strModule As String)
        Dim v_strDataSource As String = String.Empty
        Dim v_strUsername As String = String.Empty
        Dim v_strPassword As String = String.Empty
        Dim v_strDBInit As String = String.Empty
        Dim v_strMinPoolSize As String = String.Empty
        Dim v_strMaxPoolSize As String = String.Empty
        Dim v_strLifeTime As String = String.Empty
        Try
            If Not (pv_strModule Is Nothing) Then
                If ConfigurationManager.AppSettings(pv_strModule & ".PRV") <> Nothing Then
                    ProvideType = CType(ConfigurationManager.AppSettings(pv_strModule & ".PRV").ToString().Trim(), DBProvider)
                End If
                If ConfigurationManager.AppSettings(pv_strModule & ".DSN") <> Nothing Then
                    v_strDataSource = ConfigurationManager.AppSettings(pv_strModule & ".DSN").ToString().Trim()
                Else
                    v_strDataSource = String.Empty
                End If
                If ConfigurationManager.AppSettings(pv_strModule & ".UID") <> Nothing Then
                    v_strUsername = ConfigurationManager.AppSettings(pv_strModule & ".UID").ToString().Trim()
                Else
                    v_strUsername = String.Empty
                End If

                If ConfigurationManager.AppSettings(pv_strModule & ".PWD") <> Nothing Then
                    v_strPassword = ConfigurationManager.AppSettings(pv_strModule & ".PWD").ToString().Trim()
                    If Not Trim(v_strPassword) Is Nothing Then
                        'If ConfigurationManager.AppSettings("ISPROTECTPASSWORD") = "Y" Then
                        '    v_strPassword = DataProtection.UnprotectData(v_strPassword)
                        'End If
                        Dim NewCrypt = New RSA()
                        If Not ConfigurationManager.AppSettings(pv_strModule & ".PWDK") Is Nothing Then
                            If Not String.IsNullOrEmpty(Signature_PrivateKey) Then
                                v_strPassword = NewCrypt.RsaDecryptWithPrivate(v_strPassword, Signature_PrivateKey)
                            End If
                        End If
                    End If
                Else
                    v_strPassword = String.Empty
                End If

                If ConfigurationManager.AppSettings(pv_strModule & ".IDB") <> Nothing Then
                    v_strDBInit = ConfigurationManager.AppSettings(pv_strModule & ".IDB").ToString
                Else
                    v_strDBInit = String.Empty
                End If
                If ConfigurationManager.AppSettings(pv_strModule & ".MINPOOLSIZE") <> Nothing Then
                    v_strMinPoolSize = ConfigurationManager.AppSettings(pv_strModule & ".MINPOOLSIZE").ToString().Trim()
                Else
                    v_strMinPoolSize = String.Empty
                End If
                If ConfigurationManager.AppSettings(pv_strModule & ".MAXPOOLSIZE") <> Nothing Then
                    v_strMaxPoolSize = ConfigurationManager.AppSettings(pv_strModule & ".MAXPOOLSIZE").ToString
                Else
                    v_strMaxPoolSize = String.Empty
                End If
                If ConfigurationManager.AppSettings(pv_strModule & ".LIFETIME") <> Nothing Then
                    v_strLifeTime = ConfigurationManager.AppSettings(pv_strModule & ".LIFETIME").ToString
                Else
                    v_strLifeTime = String.Empty
                End If

                'TruongLD add value using for TraceSQLCmd
                If ConfigurationManager.AppSettings(pv_strModule & ".TRACE") <> Nothing Then
                    mv_strTrace = ConfigurationManager.AppSettings(pv_strModule & ".TRACE").ToString
                Else
                    mv_strTrace = String.Empty
                End If
                'End TruongLD 

            Else
                ProvideType = DBProvider.OracleClient   ' Oracle by default
                v_strDataSource = String.Empty
                v_strUsername = String.Empty
                v_strPassword = String.Empty
                v_strDBInit = String.Empty
                v_strMinPoolSize = String.Empty
                v_strMaxPoolSize = String.Empty
                'TruongLD add value using for TraceSQLCmd
                mv_strTrace = String.Empty
            End If

            mv_strConnectionString = _BuildConnectionString(v_strDataSource, v_strUsername, v_strPassword, v_strDBInit, v_strMinPoolSize, v_strMaxPoolSize, v_strLifeTime)
            mv_strLogFileName = _BuildLogFileName()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Thuộc tính chỉ đọc ConnectionString "
    Private ReadOnly Property ConnectionString() As String
        Get
            Return mv_strConnectionString
        End Get
    End Property
#End Region

#Region " Các thuộc tính khác "
    Public Property strModule() As String
        Get
            Return mv_strModule
        End Get
        Set(ByVal Value As String)
            mv_strModule = Value
        End Set
    End Property

    Public Property ProvideType() As DBProvider
        Get
            Return mv_dbProvider
        End Get
        Set(ByVal Value As DBProvider)
            mv_dbProvider = Value
        End Set
    End Property

    Public Property LogCommand() As Boolean
        Get
            Return mv_blnLogCommand
        End Get
        Set(ByVal Value As Boolean)
            mv_blnLogCommand = Value
        End Set
    End Property
#End Region

#Region " Helper "
    Private Function _BuildConnectionString(ByVal pv_strDataSource As String, _
                                            ByVal pv_strUserName As String, _
                                            ByVal pv_strPassword As String, _
                                            Optional ByVal pv_strDBInit As String = "", _
                                            Optional ByVal pv_strMinPoolSize As String = "", _
                                            Optional ByVal pv_strMaxPoolSize As String = "", _
                                            Optional ByVal pv_strLifeTime As String = "") As String
        Dim v_strConnectString As String = String.Empty

        Select Case ProvideType
            Case DBProvider.OracleClient
                If Not (pv_strDataSource = String.Empty) Then
                    v_strConnectString &= "Data Source=" & pv_strDataSource
                End If
                If Not (pv_strUserName = String.Empty) Then
                    v_strConnectString &= ";User ID=" & pv_strUserName
                End If
                If Not (pv_strPassword = String.Empty) Then
                    v_strConnectString &= ";Password=" & pv_strPassword
                End If
                If Not (pv_strMinPoolSize = String.Empty) Then
                    If IsNumeric(pv_strMinPoolSize) Then
                        v_strConnectString &= ";Min Pool Size=" & CInt(pv_strMinPoolSize)
                    End If
                End If
                If Not (pv_strMaxPoolSize = String.Empty) Then
                    If IsNumeric(pv_strMaxPoolSize) Then
                        v_strConnectString &= ";Max Pool Size=" & CInt(pv_strMaxPoolSize)
                    End If
                End If
                If Not (pv_strLifeTime = String.Empty) Then
                    If IsNumeric(pv_strLifeTime) Then
                        v_strConnectString &= ";Connection Lifetime=" & CInt(pv_strLifeTime)
                    End If
                End If
            Case DBProvider.SQLClient

            Case DBProvider.ODBC

            Case DBProvider.OLEDB

            Case DBProvider.Access

        End Select

        Return v_strConnectString
    End Function

    Private Function _BuildLogFileName() As String
        Dim v_strFileName As String

        If ConfigurationManager.AppSettings(c_LogCommandFilePath) <> Nothing Then
            v_strFileName = ConfigurationManager.AppSettings(c_LogCommandFilePath).ToString().Trim()
        Else
            v_strFileName = "C:"
        End If

        v_strFileName &= "\" & Now.ToString("ddMMMyyyy") & ".log"

        Return v_strFileName
    End Function

    Private Sub LogBusinessCommand(ByVal pv_strFileName As String, ByVal pv_bCommand As BusinessCommand)
        Dim v_streamWriter As New StreamWriter(pv_strFileName, True)

        With pv_bCommand
            v_streamWriter.WriteLine()
            v_streamWriter.WriteLine(.ExecuteUser & " execute @ " & .ExecuteDate.ToString("dd/MM/yyyy") & " " & .ExecuteTime)
            v_streamWriter.WriteLine(.SQLCommand)
        End With

        v_streamWriter.Flush()
        v_streamWriter.Close()
    End Sub
#End Region

#Region " Các public method "

    Public Function ExecuteSQLParametersReturnDataset(ByVal pv_strSQLCommand As String, ByVal pv_rptParameters() As ReportParameters) As DataSet
        Dim v_arrCommandParameters() As OracleParameter
        'Dim v_intParamCount As Integer
        Dim v_cmdParam As OracleParameter
        Dim i As Integer

        Try
            ReDim v_arrCommandParameters(pv_rptParameters.Length - 1)
            For i = 0 To pv_rptParameters.Length - 1
                If (pv_rptParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_rptParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Double, pv_rptParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Date, pv_rptParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = ParameterDirection.Input
                    v_cmdParam.Value = pv_rptParameters(i).ParamValue

                    v_arrCommandParameters(i) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_rptParameters.Length - 1)
            'TruongLD Add 14/04/2010
            TraceSQLCmd(pv_strSQLCommand, mv_strModule)
            Return OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, pv_strSQLCommand, v_arrCommandParameters)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExecuteSQLReturnDataset(ByVal pv_bCommand As BusinessCommand) As DataSet
        If LogCommand() Then
            'LogBusinessCommand(mv_strLogFileName, pv_bCommand)
        End If

        Return OracleHelper.ExecuteDataset(ConnectionString(), CommandType.Text, pv_bCommand.SQLCommand)
    End Function

    Public Function ExecuteSQLReturnDataset(ByVal CommandType As CommandType, ByVal CommandText As String) As DataSet
        Return OracleHelper.ExecuteDataset(ConnectionString, CommandType, CommandText)
    End Function

    Public Function ExecuteOracleStored(ByVal pv_strStoredName As String, ByRef pv_StoreParameters() As StoreParameter, ByVal pv_ReturnIndex As Integer) As String
        Dim v_arrCommandParameters() As OracleParameter
        Dim v_cmdParam As OracleParameter
        Dim i As Integer
        Dim p As OracleParameter
        Dim Conn As New OracleConnection(ConnectionString)
        Dim scmd As New OracleCommand(pv_strStoredName, Conn)
        Try
            ReDim v_arrCommandParameters(pv_StoreParameters.Length - 1)
            For i = 0 To pv_StoreParameters.Length - 1
                If (pv_StoreParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_StoreParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Double, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Date, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                        Case "CLOB"
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Clob, pv_StoreParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = IIf(pv_StoreParameters(i).ParamDirection Is Nothing Or pv_StoreParameters(i).ParamDirection = "", ParameterDirection.InputOutput, pv_StoreParameters(i).ParamDirection)
                    v_cmdParam.Value = pv_StoreParameters(i).ParamValue
                    v_arrCommandParameters(i) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_StoreParameters.Length - 1)

            scmd.CommandType = CommandType.StoredProcedure
            For Each p In v_arrCommandParameters
                If (p.Direction = ParameterDirection.InputOutput) And (p.Value Is Nothing) Then
                    p.Value = Nothing
                End If
                scmd.Parameters.Add(p)
            Next p
            Conn.Open()

            Dim sessionGlobalization As OracleGlobalization = Conn.GetSessionInfo()
            sessionGlobalization.DateFormat = gc_FORMAT_DATE_Db
            Conn.SetSessionInfo(sessionGlobalization)

            'TruongLD Add 14/04/2010
            TraceSQLCmd(pv_strStoredName, mv_strModule)
            scmd.ExecuteNonQuery()
            For i = 0 To pv_StoreParameters.Length - 1
                pv_StoreParameters(i).ParamValue = scmd.Parameters(i).Value.ToString()
            Next
            Return scmd.Parameters(pv_ReturnIndex).Value.ToString
        Catch ex As Exception
            Throw ex
        Finally
            Conn.Dispose()
            scmd.Dispose()
        End Try
    End Function


    Public Function ExecuteStoredReturnDataset(ByVal pv_strStoredName As String, ByVal pv_rptParameters() As ReportParameters) As DataSet
        Dim v_arrCommandParameters() As OracleParameter
        'Dim v_intParamCount As Integer
        Dim v_cmdParam As OracleParameter
        Dim i As Integer

        Try
            ReDim v_arrCommandParameters(pv_rptParameters.Length)

            v_cmdParam = New OracleParameter("p_ref_cursor", OracleDbType.RefCursor)
            v_cmdParam.Direction = ParameterDirection.InputOutput
            v_cmdParam.Value = Nothing
            v_arrCommandParameters(0) = v_cmdParam

            For i = 0 To pv_rptParameters.Length - 1
                If (pv_rptParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_rptParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Double, pv_rptParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Date, pv_rptParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = ParameterDirection.Input
                    v_cmdParam.Value = pv_rptParameters(i).ParamValue

                    v_arrCommandParameters(i + 1) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_rptParameters.Length)
            'TruongLD Add 14/04/2010
            TraceSQLCmd(pv_strStoredName, mv_strModule)
            Return OracleHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, pv_strStoredName, v_arrCommandParameters)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExecuteStoredNonQuerry(ByVal pv_strStoredName As String, ByVal pv_StoreParameters() As StoreParameter) As Long
        Dim v_arrCommandParameters() As OracleParameter
        'Dim v_intParamCount As Integer
        Dim v_cmdParam As OracleParameter
        Dim i As Integer

        Try
            ReDim v_arrCommandParameters(pv_StoreParameters.Length - 1)
            For i = 0 To pv_StoreParameters.Length - 1
                If (pv_StoreParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_StoreParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Double, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Date, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = ParameterDirection.Input
                    v_cmdParam.Value = pv_StoreParameters(i).ParamValue
                    v_arrCommandParameters(i) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_StoreParameters.Length - 1)
            'TruongLD Add 14/04/2010
            TraceSQLCmd(pv_strStoredName, mv_strModule)
            Return (OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, pv_strStoredName, v_arrCommandParameters))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'TruongLD Add 08/03/2010
    Public Function ExecuteStoredNonQuerry(ByVal pv_strStoredName As String, ByVal pv_rptParameters() As ReportParameters) As Long
        Dim v_arrCommandParameters() As OracleParameter
        'Dim v_intParamCount As Integer
        Dim v_cmdParam As OracleParameter
        Dim i As Integer
        Try
            ReDim v_arrCommandParameters(pv_rptParameters.Length - 1)

            For i = 0 To pv_rptParameters.Length - 1
                If (pv_rptParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_rptParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Double, pv_rptParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Date, pv_rptParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_rptParameters(i).ParamName, OracleDbType.Varchar2, pv_rptParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = ParameterDirection.Input
                    v_cmdParam.Value = pv_rptParameters(i).ParamValue
                    v_arrCommandParameters(i) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_rptParameters.Length - 1)

            'Log các câu lệnh SQL, tên Store procedue đã được chạy
            TraceSQLCmd(pv_strStoredName, mv_strModule)

            Return (OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, pv_strStoredName, v_arrCommandParameters))
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'End TruongLD

    'TruongLD Add 08/03/2010
    Public Function TraceSQLCmd(ByVal strSQLCmd As String, ByVal strDBName As String) As Long
        Try
            If UCase(mv_strTrace) = "Y" Then
                LogError.Write("[" & strDBName & "]: " & strSQLCmd)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'End TruongLD



    Public Function ExecuteStoredReturnString(ByVal pv_strStoredName As String, ByVal pv_StoreParameters() As StoreParameter, ByVal pv_intOutIndex As Integer) As String
        Dim v_arrCommandParameters() As OracleParameter
        'Dim v_intParamCount As Integer
        Dim v_cmdParam As OracleParameter
        Dim i As Integer
        Dim p As OracleParameter
        Dim Conn As OracleConnection
        Dim scmd As OracleCommand
        Try
            ReDim v_arrCommandParameters(pv_StoreParameters.Length - 1)
            For i = 0 To pv_StoreParameters.Length - 1
                If (pv_StoreParameters(i).ParamName <> String.Empty) Then
                    Select Case pv_StoreParameters(i).ParamType
                        Case GetType(Double).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Double, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.DateTime).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Date, pv_StoreParameters(i).ParamSize)
                        Case GetType(System.String).Name
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                        Case Else
                            v_cmdParam = New OracleParameter(pv_StoreParameters(i).ParamName, OracleDbType.Varchar2, pv_StoreParameters(i).ParamSize)
                    End Select
                    v_cmdParam.Direction = pv_StoreParameters(i).ParamDirection
                    v_cmdParam.Value = pv_StoreParameters(i).ParamValue
                    v_arrCommandParameters(i) = v_cmdParam
                End If
            Next
            ReDim Preserve v_arrCommandParameters(pv_StoreParameters.Length - 1)

            Conn = New OracleConnection(ConnectionString)
            scmd = New OracleCommand(pv_strStoredName, Conn)
            scmd.CommandType = CommandType.StoredProcedure
            For Each p In v_arrCommandParameters
                If (p.Direction = ParameterDirection.InputOutput) And (p.Value Is Nothing) Then
                    p.Value = Nothing
                End If
                scmd.Parameters.Add(p)
            Next p
            Conn.Open()
            scmd.ExecuteNonQuery()
            Conn.Close()
            Return scmd.Parameters(pv_intOutIndex).Value.ToString
        Catch ex As Exception
            Throw ex
        Finally
            If Not p Is Nothing Then
                p.Dispose()
            End If
            If Not Conn Is Nothing Then
                Conn.Close()
                Conn.Dispose()
            End If
            scmd.Dispose()
        End Try
    End Function
    'nghiemnt add
    Public Function BulkCopyDataTable(ByVal srcDataTable As DataTable) As Integer
        Return OracleHelper.BulkCopyDataTable(Me.ConnectionString, srcDataTable)
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Lấy tham số hệ thống trong bảng SYSVAR
    ' + Đầu vào:    
    '       - pv_strGRNAME:      Tên group
    '       - pv_strVARNAME:     Tên biến
    ' + Đầu ra:     
    '       - pv_strVARVALUE:    Giá trị
    ' + Trả về:     Mã lỗi nếu có
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function GetSysVar(ByVal pv_strGRNAME As String, ByVal pv_strVARNAME As String, ByRef pv_strVARVALUE As String) As Long
        Dim v_strSQL As String
        Dim v_ds As DataSet

        Try
            If pv_strVARNAME = "SYSDATE" Then
                v_strSQL = "SELECT TO_CHAR(SYSDATE,'DD/MM/RRRR') VARVALUE FROM DUAL"
            ElseIf pv_strVARNAME = "SYSTIME" Then
                v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') VARVALUE FROM DUAL"
            Else
                v_strSQL = "SELECT VARVALUE, VARDESC, EN_VARDESC FROM SYSVAR WHERE TRIM(GRNAME) = '" & pv_strGRNAME & "' AND TRIM(VARNAME)='" & pv_strVARNAME & "'"
            End If
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_VARIABLE_NOTFOUND
            Else
                pv_strVARVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VARVALUE")))
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not v_ds Is Nothing Then
                v_ds.Dispose()
            End If
        End Try
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Đặt giá trị tham số hệ thống trong bảng SYSVAR
    ' + Đầu vào:    
    '       - pv_strGRNAME:      Tên group
    '       - pv_strVARNAME:     Tên biến
    '       - pv_strVARVALUE:    Giá trị
    ' + Đầu ra:     N/A
    ' + Trả về:     Mã lỗi nếu có
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function SetSysVar(ByVal pv_strGRNAME As String, ByVal pv_strVARNAME As String, ByVal pv_strVARVALUE As String) As Long
        Dim v_strSQL As String
        Dim v_ds As DataSet

        Try
            v_strSQL = "SELECT VARVALUE, VARDESC, EN_VARDESC FROM SYSVAR WHERE TRIM(GRNAME)='" & pv_strGRNAME & "' AND TRIM(VARNAME)='" & pv_strVARNAME & "'"
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_VARIABLE_NOTFOUND
            Else
                v_strSQL = "UPDATE SYSVAR SET VARVALUE='" & pv_strVARVALUE & "' WHERE TRIM(GRNAME)='" & pv_strGRNAME & "' AND TRIM(VARNAME)='" & pv_strVARNAME & "'"
                OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, v_strSQL)
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_ds.Dispose()
        End Try
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Reset  lại bộ đếm
    ' + Đầu vào:    
    '       - pv_strTable:      Tên bảng
    ' + Đầu ra:     N/A
    ' + Trả về:     Số tăng tuần tự tiếp theo
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function ResetSequence(ByVal pv_strTable As String) As Long
        Dim v_strSQL As String
        Dim v_ds As DataSet

        Try
            'Kiểm tra Sequence đã tồn tại chưa
            v_strSQL = "SELECT * FROM USER_OBJECTS WHERE OBJECT_NAME = 'SEQ_" & pv_strTable & "'"
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Xoá Sequence cũ
                v_strSQL = "DROP SEQUENCE SEQ_" & pv_strTable
                OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, v_strSQL)
            End If
            'Tạo mới Sequence 
            v_strSQL = "CREATE SEQUENCE SEQ_" & pv_strTable
            OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, v_strSQL)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_ds.Dispose()
        End Try
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Lấy số tự tăng để làm khoá chính cho bảng
    ' + Đầu vào:    
    '       - pv_strTable:      Tên bảng
    ' + Đầu ra:     N/A
    ' + Trả về:     Số tăng tuần tự tiếp theo
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function GetIDValue(ByVal pv_strTable As String) As Decimal
        Dim v_strSQL As String
        Dim v_ds As DataSet

        Try
            'Kiểm tra Sequence đã tồn tại chưa
            v_strSQL = "SELECT * FROM USER_OBJECTS WHERE OBJECT_NAME = 'SEQ_" & pv_strTable & "'"
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Tạo mới Sequence nếu chưa tồn tại
                v_strSQL = "CREATE SEQUENCE SEQ_" & pv_strTable
                OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, v_strSQL)
            End If

            'Lấy IDValue
            v_strSQL = "Select SEQ_" & pv_strTable & ".NEXTVAL ID from DUAL"
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                Return v_ds.Tables(0).Rows(0)(0)
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_ds.Dispose()
        End Try
    End Function


    Public Function GetErrorMessage(ByVal pv_lngERROR As Long) As String
        Dim v_strSQL, v_strRETURN As String
        Dim v_ds As DataSet

        Try
            v_strRETURN = String.Empty
            v_strSQL = "SELECT ERRDESC, EN_ERRDESC FROM DEFERROR WHERE ERRNUM = " & pv_lngERROR
            v_ds = OracleHelper.ExecuteDataset(ConnectionString, CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strRETURN = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EN_ERRDESC")))
            End If
            v_ds.Dispose()
            Return v_strRETURN
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Mục đích:   Thực hiện câu lệnh SQL
    ' + Đầu vào:    
    '       - ConnectionString: Tên bảng
    '       - CommandType:      
    '       - CommandText:      
    ' + Đầu ra:     N/A
    ' + Trả về:     Số tăng tuần tự tiếp theo
    ' + Tác giả:    Trần Kiều Minh
    ' + Ghi chú:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function ExecuteNonQuery(ByVal CommandType As CommandType,
                                    ByVal CommandText As String) As Integer

        TraceSQLCmd(CommandText, mv_strModule)

        Return OracleHelper.ExecuteNonQuery(ConnectionString, CommandType, CommandText)

    End Function


    Public Function ExecuteNonQuery(ByVal StoredProceduredName As String, ByVal ParameterNames() As Object, ByVal ParameterValues() As Object, ByVal ParameterTypes() As Object) As Integer

        TraceSQLCmd(StoredProceduredName, mv_strModule)

        Return OracleHelper.ExecuteNonQuery(ConnectionString, StoredProceduredName, ParameterNames, ParameterValues, ParameterTypes)

    End Function
#End Region

    'tiennv
    'Cap nhat du lieu Dblob
    Public Sub UpdateBlobData(ByVal dicParamBlob As Dictionary(Of String, String), ByVal AutoId As String, ByVal objTableName As String)
        Dim Conn As New OracleConnection(ConnectionString)
        Conn.Open()
        Try
            Dim objTableArr As String() = objTableName.Split(".")
            Dim tableName As String = IIf(objTableArr.Length = 2, objTableArr(1), objTableArr(0))

            If (dicParamBlob Is Nothing Or String.IsNullOrEmpty(tableName) Or String.IsNullOrEmpty(AutoId)) Then
                Return
            End If

            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = Conn
            Dim fieldUpdate As String = ""
            For Each param As KeyValuePair(Of String, String) In dicParamBlob
                Dim index As Int32 = (dicParamBlob.Keys.ToList().IndexOf(param.Key) + 1)
                fieldUpdate += param.Key + " = :" + index.ToString()
                If index <> dicParamBlob.Keys.Count Then
                    fieldUpdate += ","
                End If
                Dim orclPr As OracleParameter = New OracleParameter
                orclPr.OracleDbType = OracleDbType.Blob
                Dim blobData As OracleBlob = New OracleBlob(Conn)
                Dim arrByte As Byte() = Nothing
                If Not String.IsNullOrEmpty(param.Value) Then
                    arrByte = Convert.FromBase64String(param.Value)
                End If
                If arrByte IsNot Nothing Then
                    blobData.Write(arrByte, 0, IIf(arrByte IsNot Nothing, arrByte.Length, 0))
                    orclPr.Value = blobData
                End If
                cmd.Parameters.Add(orclPr)
            Next

            Dim sqlCmd As String = String.Format("UPDATE {0} SET {1} WHERE AUTOID = {2} ", tableName, fieldUpdate, AutoId)
            cmd.CommandText = sqlCmd
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            LogError.WriteException(ex)
        End Try
    End Sub

    Public Function UpdateBlobData(ByVal data As Byte(), ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As Long
        Dim Conn As New OracleConnection(ConnectionString)
        Conn.Open()
        Try
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = Conn

            Dim orclPr As OracleParameter = New OracleParameter
            orclPr.OracleDbType = OracleDbType.Blob
            Dim blobData As OracleBlob = New OracleBlob(Conn)
            If (data IsNot Nothing) Then
                blobData.Write(data, 0, data.Length)
            Else
                blobData.Write(data, 0, 0)
            End If

            orclPr.Value = blobData
            cmd.Parameters.Add(orclPr)

            Dim fieldUpdate As String = String.Format("{0} = :1", fieldname)

            Dim sqlCmd As String = String.Format("UPDATE {0} SET {1} WHERE {2} = {3} ", tableName, fieldUpdate, pk_fieldname, pk_value)
            cmd.CommandText = sqlCmd
            cmd.ExecuteNonQuery()

            Conn.Close()

            Return 0
        Catch ex As Exception
            Conn.Close()
            LogError.WriteException(ex)
            Return -288888
        End Try
    End Function

    Public Function DownloadFileFromBlob(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Byte()
        Dim Conn As New OracleConnection(ConnectionString)
        Conn.Open()
        Try
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = Conn
            cmd.CommandText = String.Format("select {0} from {1} where {2} = '{3}'", pv_FieldName, pv_TableName, pv_pkFieldName, pv_pkValue)

            Dim oraReader As OracleDataReader = cmd.ExecuteReader()

            If (oraReader.Read()) Then
                Dim data As System.Byte()
                data = oraReader(pv_FieldName)
                Conn.Close()
                Return data
            End If

            Conn.Close()
            Return Nothing

        Catch ex As Exception
            Conn.Close()
            LogError.WriteException(ex)
            Return Nothing
        End Try
    End Function

End Class
