<Serializable()> _
Public Class CVATVoucher

#Region " Declaration "
    Private mv_strTXNUM As String
    Private mv_strTXDATE As String
    Private mv_strVOUCHERNO As String
    Private mv_strVOUCHERTYPE As String
    Private mv_strSERIENO As String
    Private mv_strVOUCHERDATE As String
    Private mv_strCUSTID As String
    Private mv_strTAXCODE As String
    Private mv_strCUSTNAME As String
    Private mv_strADDRESS As String
    Private mv_strCONTENTS As String
    Private mv_dblQTTY As Double
    Private mv_dblPRICE As Double
    Private mv_dblAMT As Double
    Private mv_dblVATRATE As Double
    Private mv_dblVATAMT As Double
    Private mv_strDESCRIPTION As String
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strTXNUM = String.Empty
        mv_strTXDATE = String.Empty
        mv_strVOUCHERNO = String.Empty
        mv_strVOUCHERTYPE = String.Empty
        mv_strSERIENO = String.Empty
        mv_strVOUCHERDATE = String.Empty
        mv_strCUSTID = String.Empty
        mv_strTAXCODE = String.Empty
        mv_strCUSTNAME = String.Empty
        mv_strADDRESS = String.Empty
        mv_strCONTENTS = String.Empty
        mv_dblQTTY = 0
        mv_dblPRICE = 0
        mv_dblAMT = 0
        mv_dblVATRATE = 0
        mv_dblVATAMT = 0
        mv_strDESCRIPTION = String.Empty
    End Sub

    Public Overloads Sub Dispose()
        mv_strTXNUM = String.Empty
        mv_strTXDATE = String.Empty
        mv_strVOUCHERNO = String.Empty
        mv_strVOUCHERTYPE = String.Empty
        mv_strSERIENO = String.Empty
        mv_strVOUCHERDATE = String.Empty
        mv_strCUSTID = String.Empty
        mv_strTAXCODE = String.Empty
        mv_strCUSTNAME = String.Empty
        mv_strADDRESS = String.Empty
        mv_strCONTENTS = String.Empty
        mv_dblQTTY = 0
        mv_dblPRICE = 0
        mv_dblAMT = 0
        mv_dblVATRATE = 0
        mv_dblVATAMT = 0
        mv_strDESCRIPTION = String.Empty
    End Sub
#End Region

#Region " Properties "
    Public Property TXNUM() As String
        Get
            Return mv_strTXNUM
        End Get
        Set(ByVal Value As String)
            mv_strTXNUM = Value
        End Set
    End Property

    Public Property TXDATE() As String
        Get
            Return mv_strTXDATE
        End Get
        Set(ByVal Value As String)
            mv_strTXDATE = Value
        End Set
    End Property

    Public Property VOUCHERNO() As String
        Get
            Return mv_strVOUCHERNO
        End Get
        Set(ByVal Value As String)
            mv_strVOUCHERNO = Value
        End Set
    End Property

    Public Property VOUCHERTYPE() As String
        Get
            Return mv_strVOUCHERTYPE
        End Get
        Set(ByVal Value As String)
            mv_strVOUCHERTYPE = Value
        End Set
    End Property

    Public Property SERIENO() As String
        Get
            Return mv_strSERIENO
        End Get
        Set(ByVal Value As String)
            mv_strSERIENO = Value
        End Set
    End Property

    Public Property VOUCHERDATE() As String
        Get
            Return mv_strVOUCHERDATE
        End Get
        Set(ByVal Value As String)
            mv_strVOUCHERDATE = Value
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

    Public Property TAXCODE() As String
        Get
            Return mv_strTAXCODE
        End Get
        Set(ByVal Value As String)
            mv_strTAXCODE = Value
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

    Public Property ADDRESS() As String
        Get
            Return mv_strADDRESS
        End Get
        Set(ByVal Value As String)
            mv_strADDRESS = Value
        End Set
    End Property

    Public Property CONTENTS() As String
        Get
            Return mv_strCONTENTS
        End Get
        Set(ByVal Value As String)
            mv_strCONTENTS = Value
        End Set
    End Property

    Public Property QTTY() As Double
        Get
            Return mv_dblQTTY
        End Get
        Set(ByVal Value As Double)
            mv_dblQTTY = Value
        End Set
    End Property

    Public Property PRICE() As Double
        Get
            Return mv_dblPRICE
        End Get
        Set(ByVal Value As Double)
            mv_dblPRICE = Value
        End Set
    End Property

    Public Property AMT() As Double
        Get
            Return mv_dblAMT
        End Get
        Set(ByVal Value As Double)
            mv_dblAMT = Value
        End Set
    End Property

    Public Property VATRATE() As Double
        Get
            Return mv_dblVATRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblVATRATE = Value
        End Set
    End Property

    Public Property VATAMT() As Double
        Get
            Return mv_dblVATAMT
        End Get
        Set(ByVal Value As Double)
            mv_dblVATAMT = Value
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
