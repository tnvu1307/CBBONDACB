<Serializable()> _
Public Class ReportParameters

#Region " Khai báo hằng, biến "
    Private mv_strParamName As String
    Private mv_strParamType As String
    Private mv_intParamSize As Integer
    Private mv_objParamValue As Object
    Private mv_strParamDescription As String
    Private mv_strParamCaption As String
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strParamName = String.Empty
        mv_strParamType = String.Empty
        mv_intParamSize = 0
        mv_objParamValue = Nothing
        mv_strParamDescription = String.Empty
        mv_strParamCaption = String.Empty
    End Sub
#End Region

#Region " Các thuộc tính "
    Public Property ParamName() As String
        Get
            Return mv_strParamName
        End Get
        Set(ByVal Value As String)
            mv_strParamName = Value
        End Set
    End Property

    Public Property ParamType() As String
        Get
            Return mv_strParamType
        End Get
        Set(ByVal Value As String)
            mv_strParamType = Value
        End Set
    End Property

    Public Property ParamSize() As Integer
        Get
            Return mv_intParamSize
        End Get
        Set(ByVal Value As Integer)
            mv_intParamSize = Value
        End Set
    End Property

    Public Property ParamValue() As Object
        Get
            Return mv_objParamValue
        End Get
        Set(ByVal Value As Object)
            mv_objParamValue = Value
        End Set
    End Property

    Public Property ParamDescription() As String
        Get
            Return mv_strParamDescription
        End Get
        Set(ByVal Value As String)
            mv_strParamDescription = Value
        End Set
    End Property

    Public Property ParamCaption() As String
        Get
            Return mv_strParamCaption
        End Get
        Set(ByVal Value As String)
            mv_strParamCaption = Value
        End Set
    End Property
#End Region

End Class
