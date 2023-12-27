<Serializable()> _
Public Class CFieldMaster

#Region " Declaration "
    Private mv_intButtonIndex As Integer
    Private mv_intCaptionIndex As Integer
    Private mv_intLabelIndex As Integer
    Private mv_intCtlIndex As Integer
    Private mv_strFldName As String
    Private mv_strDefName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_intOdrNum As Integer
    Private mv_strFldType As String
    Private mv_strFldMask As String
    Private mv_strFldFormat As String
    Private mv_intFldWidth As Integer
    Private mv_intFldRow As Integer
    Private mv_intFldLen As Integer
    Private mv_strLookupList As String
    Private mv_strLookupCheck As String
    Private mv_strDefVal As String
    Private mv_blnVisible As Boolean
    Private mv_blnEnable As Boolean
    Private mv_blnMandatory As Boolean
    Private mv_strAmtExp As String
    Private mv_strValidTag As String
    Private mv_strLookup As String
    Private mv_strLookupName As String
    Private mv_strControlType As String
    Private mv_strDataType As String
    Private mv_strFldValue As String
    Private mv_strPrintInfo As String
    Private mv_strInvFormat As String
    Private mv_strInvName As String
    Private mv_strFldSource As String
    Private mv_strFldDesc As String
    Private mv_strSearchCode As String
    Private mv_strSrModCode As String
    Private mv_blnRISKFLD As Boolean
    Private mv_strGroupName As String
    Private mv_intGroupIndex As Integer
    Private mv_intTabIndex As Integer
    Private mv_strFldRound As String
    Private mv_strTagField As String
    Private mv_strTagValue As String
    Private mv_strTagList As String
    Private mv_strTagListData As String
    Private mv_strTagLookUpDesc As String
    Private mv_strPDefName As String
    Private mv_strTagUpdate As String
    Private mv_strIsParam As String
    Private mv_strSubField As String
    Private mv_strPDefValue As String
    Private mv_strDefDesc As String
    Private mv_strDefParam As String
    Private mv_strSearchflt As String
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strFldName = String.Empty
        mv_strDefName = String.Empty
        mv_strCaption = String.Empty
        mv_strEnCaption = String.Empty
        mv_strFldType = String.Empty
        mv_strFldMask = String.Empty
        mv_strFldFormat = String.Empty
        mv_strLookupList = String.Empty
        mv_strLookupCheck = String.Empty
        mv_strLookupName = String.Empty
        mv_strDefVal = String.Empty
        mv_strAmtExp = String.Empty
        mv_strPDefName = String.Empty

        mv_intOdrNum = 0
        mv_intFldLen = 0
        mv_intFldWidth = 0
        mv_intLabelIndex = 0
        mv_intCaptionIndex = 0
        mv_intCtlIndex = 0
        mv_intButtonIndex = -1

        mv_blnVisible = True
        mv_blnEnable = True
        mv_blnMandatory = False
        mv_strValidTag = String.Empty
        mv_strLookup = String.Empty
        mv_strDataType = String.Empty
        mv_strControlType = "T"
        mv_strFldValue = String.Empty
        mv_strInvName = String.Empty
        mv_strFldSource = String.Empty
        mv_strFldDesc = String.Empty
        mv_blnRISKFLD = False

        mv_strGroupName = String.Empty
        mv_strTagField = String.Empty
        mv_strTagValue = String.Empty
        mv_strTagUpdate = String.Empty

    End Sub

    Public Overloads Sub Dispose()
        mv_strFldName = String.Empty
        mv_strDefName = String.Empty
        mv_strCaption = String.Empty
        mv_strFldType = String.Empty
        mv_strFldMask = String.Empty
        mv_strFldFormat = String.Empty
        mv_strLookupList = String.Empty
        mv_strLookupCheck = String.Empty
        mv_strLookupName = String.Empty
        mv_strDefVal = String.Empty
        mv_strAmtExp = String.Empty
        mv_strValidTag = String.Empty
        mv_strLookup = String.Empty
        mv_strDataType = String.Empty
        mv_strControlType = String.Empty
        mv_strFldValue = String.Empty
        mv_intOdrNum = 0
        mv_intFldLen = 0
        mv_intFldWidth = 0

        mv_blnVisible = True
        mv_blnEnable = True
        mv_blnMandatory = False
        mv_strInvName = String.Empty
        mv_strFldSource = String.Empty
        mv_strFldDesc = String.Empty
        mv_blnRISKFLD = String.Empty
        mv_strTagUpdate = String.Empty

    End Sub
#End Region

#Region " Properties "
    Public Property DefDesc() As String
        Get
            Return mv_strDefDesc
        End Get
        Set(ByVal Value As String)
            mv_strDefDesc = Value
        End Set
    End Property
    Public Property Searchflt() As String
        Get
            Return mv_strSearchflt
        End Get
        Set(ByVal Value As String)
            mv_strSearchflt = Value
        End Set
    End Property

    Public Property DefParam() As String
        Get
            Return mv_strDefParam
        End Get
        Set(ByVal Value As String)
            mv_strDefParam = Value
        End Set
    End Property

    Public Property PDefValue() As String
        Get
            Return mv_strPDefValue
        End Get
        Set(ByVal Value As String)
            mv_strPDefValue = Value
        End Set
    End Property

    Public Property SubField() As String
        Get
            Return mv_strSubField
        End Get
        Set(ByVal Value As String)
            mv_strSubField = Value
        End Set
    End Property

    Public Property FldRound() As String
        Get
            Return mv_strFldRound
        End Get
        Set(ByVal Value As String)
            mv_strFldRound = Value
        End Set
    End Property

    Public Property IsParam() As String
        Get
            Return mv_strIsParam
        End Get
        Set(ByVal Value As String)
            mv_strIsParam = Value
        End Set
    End Property

    Public Property PDefName() As String
        Get
            Return mv_strPDefName
        End Get
        Set(ByVal Value As String)
            mv_strPDefName = Value
        End Set
    End Property

    Public Property ButtonIndex() As Integer
        Get
            Return mv_intButtonIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intButtonIndex = Value
        End Set
    End Property

    Public Property TabIndex() As Integer
        Get
            Return mv_intTabIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intTabIndex = Value
        End Set
    End Property

    Public Property GroupIndex() As Integer
        Get
            Return mv_intGroupIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intGroupIndex = Value
        End Set
    End Property

    Public Property CaptionIndex() As Integer
        Get
            Return mv_intCaptionIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intCaptionIndex = Value
        End Set
    End Property

    Public Property LabelIndex() As Integer
        Get
            Return mv_intLabelIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intLabelIndex = Value
        End Set
    End Property

    Public Property ControlIndex() As Integer
        Get
            Return mv_intCtlIndex
        End Get
        Set(ByVal Value As Integer)
            mv_intCtlIndex = Value
        End Set
    End Property

    Public Property SrModCode() As String
        Get
            Return mv_strSrModCode
        End Get
        Set(ByVal Value As String)
            mv_strSrModCode = Value
        End Set
    End Property

    Public Property SearchCode() As String
        Get
            Return mv_strSearchCode
        End Get
        Set(ByVal Value As String)
            mv_strSearchCode = Value
        End Set
    End Property

    Public Property LookupName() As String
        Get
            Return mv_strLookupName
        End Get
        Set(ByVal Value As String)
            mv_strLookupName = Value
        End Set
    End Property

    Public Property PrintInfo() As String
        Get
            Return mv_strPrintInfo
        End Get
        Set(ByVal Value As String)
            mv_strPrintInfo = Value
        End Set
    End Property

    Public Property FldDesc() As String
        Get
            Return mv_strFldDesc
        End Get
        Set(ByVal Value As String)
            mv_strFldDesc = Value
        End Set
    End Property

    Public Property FldSource() As String
        Get
            Return mv_strFldSource
        End Get
        Set(ByVal Value As String)
            mv_strFldSource = Value
        End Set
    End Property

    Public Property InvFormat() As String
        Get
            Return mv_strInvFormat
        End Get
        Set(ByVal Value As String)
            mv_strInvFormat = Value
        End Set
    End Property

    Public Property InvName() As String
        Get
            Return mv_strInvName
        End Get
        Set(ByVal Value As String)
            mv_strInvName = Value
        End Set
    End Property

    Public Property FieldName() As String
        Get
            Return mv_strFldName
        End Get
        Set(ByVal Value As String)
            mv_strFldName = Value
        End Set
    End Property

    Public Property ColumnName() As String
        Get
            Return mv_strDefName
        End Get
        Set(ByVal Value As String)
            mv_strDefName = Value
        End Set
    End Property

    Public Property Caption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property EnCaption() As String
        Get
            Return mv_strEnCaption
        End Get
        Set(ByVal Value As String)
            mv_strEnCaption = Value
        End Set
    End Property

    Public Property FieldType() As String
        Get
            Return mv_strFldType
        End Get
        Set(ByVal Value As String)
            mv_strFldType = Value
        End Set
    End Property

    Public Property FieldValue() As String
        Get
            Return mv_strFldValue
        End Get
        Set(ByVal Value As String)
            mv_strFldValue = Value
        End Set
    End Property

    Public Property InputMask() As String
        Get
            Return mv_strFldMask
        End Get
        Set(ByVal Value As String)
            mv_strFldMask = Value
        End Set
    End Property

    Public Property FieldFormat() As String
        Get
            Return mv_strFldFormat
        End Get
        Set(ByVal Value As String)
            mv_strFldFormat = Value
        End Set
    End Property

    Public Property LookupList() As String
        Get
            Return mv_strLookupList
        End Get
        Set(ByVal Value As String)
            mv_strLookupList = Value
        End Set
    End Property

    Public Property LookupCheck() As String
        Get
            Return mv_strLookupCheck
        End Get
        Set(ByVal Value As String)
            mv_strLookupCheck = Value
        End Set
    End Property

    Public Property DefaultValue() As String
        Get
            Return mv_strDefVal
        End Get
        Set(ByVal Value As String)
            mv_strDefVal = Value
        End Set
    End Property

    Public Property AmtExp() As String
        Get
            Return mv_strAmtExp
        End Get
        Set(ByVal Value As String)
            mv_strAmtExp = Value
        End Set
    End Property

    Public Property ValidTag() As String
        Get
            Return mv_strValidTag
        End Get
        Set(ByVal Value As String)
            mv_strValidTag = Value
        End Set
    End Property

    Public Property LookUp() As String
        Get
            Return mv_strLookup
        End Get
        Set(ByVal Value As String)
            mv_strLookup = Value
        End Set
    End Property

    Public Property ControlType() As String
        Get
            Return mv_strControlType
        End Get
        Set(ByVal Value As String)
            mv_strControlType = Value
        End Set
    End Property

    Public Property DataType() As String
        Get
            Return mv_strDataType
        End Get
        Set(ByVal Value As String)
            mv_strDataType = Value
        End Set
    End Property

    Public Property DisplayOrder() As Integer
        Get
            Return mv_intOdrNum
        End Get
        Set(ByVal Value As Integer)
            mv_intOdrNum = Value
        End Set
    End Property

    Public Property FieldLength() As Integer
        Get
            Return mv_intFldLen
        End Get
        Set(ByVal Value As Integer)
            mv_intFldLen = Value
        End Set
    End Property

    Public Property FieldWidth() As Integer
        Get
            Return mv_intFldWidth
        End Get
        Set(ByVal Value As Integer)
            mv_intFldWidth = Value
        End Set
    End Property
    Public Property FieldRow() As Integer
        Get
            Return mv_intFldRow
        End Get
        Set(ByVal Value As Integer)
            mv_intFldRow = Value
        End Set
    End Property
    Public Property Visible() As Boolean
        Get
            Return mv_blnVisible
        End Get
        Set(ByVal Value As Boolean)
            mv_blnVisible = Value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return mv_blnEnable
        End Get
        Set(ByVal Value As Boolean)
            mv_blnEnable = Value
        End Set
    End Property

    Public Property Mandatory() As Boolean
        Get
            Return mv_blnMandatory
        End Get
        Set(ByVal Value As Boolean)
            mv_blnMandatory = Value
        End Set
    End Property

    Public Property RiskField() As Boolean
        Get
            Return mv_blnRISKFLD
        End Get
        Set(ByVal Value As Boolean)
            mv_blnRISKFLD = Value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return mv_strGroupName
        End Get
        Set(ByVal Value As String)
            mv_strGroupName = Value
        End Set
    End Property

    Public Property TagField() As String
        Get
            Return mv_strTagField
        End Get
        Set(ByVal Value As String)
            mv_strTagField = Value
        End Set
    End Property

    Public Property TagValue() As String
        Get
            Return mv_strTagValue
        End Get
        Set(ByVal Value As String)
            mv_strTagValue = Value
        End Set
    End Property

    Public Property TagList() As String
        Get
            Return mv_strTagList
        End Get
        Set(ByVal Value As String)
            mv_strTagList = Value
        End Set
    End Property

    Public Property TagListData() As String
        Get
            Return mv_strTagListData
        End Get
        Set(ByVal Value As String)
            mv_strTagListData = Value
        End Set
    End Property

    Public Property TagLookUpDesc() As String
        Get
            Return mv_strTagLookUpDesc
        End Get
        Set(ByVal Value As String)
            mv_strTagLookUpDesc = Value
        End Set
    End Property

    Public Property TagUpdate() As String
        Get
            Return mv_strTagUpdate
        End Get
        Set(ByVal Value As String)
            mv_strTagUpdate = Value
        End Set
    End Property

#End Region

End Class
