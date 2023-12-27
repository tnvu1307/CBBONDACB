<Serializable()> _
Public Class CAccountEntry
#Region " Declaration "
    Private mv_intSUBTXNO As Integer
    Private mv_strDORC As String
    Private mv_strACCTNO As String
    Private mv_strCCYCD As String
    Private mv_dblAMOUNT As Double
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_intSUBTXNO = 0
        mv_strDORC = String.Empty
        mv_strACCTNO = String.Empty
        mv_strCCYCD = String.Empty
        mv_dblAMOUNT = 0
    End Sub

    Public Overloads Sub Dispose()
        mv_intSUBTXNO = 0
        mv_strDORC = String.Empty
        mv_strACCTNO = String.Empty
        mv_strCCYCD = String.Empty
        mv_dblAMOUNT = 0
    End Sub
#End Region

#Region " Properties "
    Public Property SUBTXNO() As Integer
        Get
            Return mv_intSUBTXNO
        End Get
        Set(ByVal Value As Integer)
            mv_intSUBTXNO = Value
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

    Public Property CCYCD() As String
        Get
            Return mv_strCCYCD
        End Get
        Set(ByVal Value As String)
            mv_strCCYCD = Value
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

    Public Property AMOUNT() As Double
        Get
            Return mv_dblAMOUNT
        End Get
        Set(ByVal Value As Double)
            mv_dblAMOUNT = Value
        End Set
    End Property
#End Region
End Class
