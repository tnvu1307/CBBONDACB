<Serializable()> _
Public Class CIEFMISEntry

#Region " Declaration "
    Private mv_dblSUBTXNO As Integer
    Private mv_strDORC As String
    Private mv_strACCTNO As String
    Private mv_strCUSTID As String
    Private mv_strCUSTNAME As String
    Private mv_strTASKCD As String
    Private mv_strDEPTCD As String
    Private mv_strMICD As String
    Private mv_strDESCRIPTION As String
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_dblSUBTXNO = 0
        mv_strDORC = String.Empty
        mv_strACCTNO = String.Empty
        mv_strCUSTID = String.Empty
        mv_strCUSTNAME = String.Empty
        mv_strTASKCD = String.Empty
        mv_strDEPTCD = String.Empty
        mv_strMICD = String.Empty
        mv_strDESCRIPTION = String.Empty
    End Sub

    Public Overloads Sub Dispose()
        mv_dblSUBTXNO = 0
        mv_strDORC = String.Empty
        mv_strACCTNO = String.Empty
        mv_strCUSTID = String.Empty
        mv_strCUSTNAME = String.Empty
        mv_strTASKCD = String.Empty
        mv_strDEPTCD = String.Empty
        mv_strMICD = String.Empty
        mv_strDESCRIPTION = String.Empty
    End Sub
#End Region

#Region " Properties "
    Public Property SUBTXNO() As Integer
        Get
            Return mv_dblSUBTXNO
        End Get
        Set(ByVal Value As Integer)
            mv_dblSUBTXNO = Value
        End Set
    End Property

    Public Property DORC() As String
        Get
            Return mv_strDORC
        End Get
        Set(ByVal Value As String)
            mv_strDORC = Value
        End Set
    End Property

    Public Property ACCTNO() As String
        Get
            Return mv_strACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strACCTNO = Value
        End Set
    End Property

    Public Property CUSTID() As String
        Get
            Return mv_strCUSTID
        End Get
        Set(ByVal Value As String)
            mv_strCUSTID = Value
        End Set
    End Property

    Public Property CUSTNAME() As String
        Get
            Return mv_strCUSTNAME
        End Get
        Set(ByVal Value As String)
            mv_strCUSTNAME = Value
        End Set
    End Property

    Public Property TASKCD() As String
        Get
            Return mv_strTASKCD
        End Get
        Set(ByVal Value As String)
            mv_strTASKCD = Value
        End Set
    End Property

    Public Property DEPTCD() As String
        Get
            Return mv_strDEPTCD
        End Get
        Set(ByVal Value As String)
            mv_strDEPTCD = Value
        End Set
    End Property

    Public Property MICD() As String
        Get
            Return mv_strMICD
        End Get
        Set(ByVal Value As String)
            mv_strMICD = Value
        End Set
    End Property

    Public Property DESCRIPTION() As String
        Get
            Return mv_strDESCRIPTION
        End Get
        Set(ByVal Value As String)
            mv_strDESCRIPTION = Value
        End Set
    End Property

#End Region

End Class
