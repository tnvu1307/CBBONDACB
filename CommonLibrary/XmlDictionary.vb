<Serializable()> _
Public Class XmlNodeDictionary
#Region " Declaration "
    Private mv_strXmlFileCode As String
    Private mv_strXmlNodeID As String
    Private mv_strXmlPRNodeID As String
    Private mv_blnXmlLastNode As Boolean
    Private mv_blnXmlSumCalc As Boolean
    Private mv_blnIsNode As Boolean
    Private mv_blnXmlLevel As Integer
    Private mv_strTableFldName As String
    Private mv_strDatatype As String
    Private mv_intWIDTH As Integer
#End Region

#Region " Constructors and deconstructors "

#End Region

#Region " Properties "
    Public Property XmlFileCode() As String
        Get
            Return mv_strXmlFileCode
        End Get
        Set(ByVal Value As String)
            mv_strXmlFileCode = Value
        End Set
    End Property

    Public Property XmlNodeID() As String
        Get
            Return mv_strXmlNodeID
        End Get
        Set(ByVal Value As String)
            mv_strXmlNodeID = Value
        End Set
    End Property

    Public Property XmlPRNodeID() As String
        Get
            Return mv_strXmlPRNodeID
        End Get
        Set(ByVal Value As String)
            mv_strXmlPRNodeID = Value
        End Set
    End Property

    Public Property TableFldName() As String
        Get
            Return mv_strTableFldName
        End Get
        Set(ByVal Value As String)
            mv_strTableFldName = Value
        End Set
    End Property

    Public Property Datatype() As String
        Get
            Return mv_strDatatype
        End Get
        Set(ByVal Value As String)
            mv_strDatatype = Value
        End Set
    End Property

    Public Property XmlLevel() As Integer
        Get
            Return mv_blnXmlLevel
        End Get
        Set(ByVal Value As Integer)
            mv_blnXmlLevel = Value
        End Set
    End Property

    Public Property XmlLastNode() As Boolean
        Get
            Return mv_blnXmlLastNode
        End Get
        Set(ByVal Value As Boolean)
            mv_blnXmlLastNode = Value
        End Set
    End Property

    Public Property XmlSumCalc() As Boolean
        Get
            Return mv_blnXmlSumCalc
        End Get
        Set(ByVal Value As Boolean)
            mv_blnXmlSumCalc = Value
        End Set
    End Property


    Public Property IsNode() As Boolean
        Get
            Return mv_blnIsNode
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsNode = Value
        End Set
    End Property



    Public Property WIDTH() As Integer
        Get
            Return mv_intWIDTH
        End Get
        Set(ByVal Value As Integer)
            mv_intWIDTH = Value
        End Set
    End Property

#End Region
End Class
