Imports System.Xml.Serialization
Partial Public Class ObjectMessageObjDataEntry

    Private fldnameField As String

    Private fldtypeField As String

    Private oldvalField As String

    Private valueField As String

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property fldname() As String
        Get
            Return Me.fldnameField
        End Get
        Set(ByVal value As String)
            Me.fldnameField = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property fldtype() As String
        Get
            Return Me.fldtypeField
        End Get
        Set(ByVal value As String)
            Me.fldtypeField = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property oldval() As String
        Get
            Return Me.oldvalField
        End Get
        Set(ByVal value As String)
            Me.oldvalField = value
        End Set
    End Property

    ''' <remarks/>
    <XmlText()> _
    Public Property Value() As String
        Get
            Return Me.valueField
        End Get
        Set(ByVal value As String)
            Me.valueField = value
        End Set
    End Property
End Class
Partial Public Class ObjectMessage

    Private objDataField As ObjectMessageObjDataEntry()

    Private transactionDate As String

    Private transactionNumber As String

    Private transactionTime As String

    Private tellerID As String

    Private branchID As String

    Private isLocal As String = "N"

    Private messageType As String = "O"

    Private objectName As String

    Private m_actionFlag As String = "ADHOC"

    Private commandInquiry As String

    Private commandClause As String

    Private m_functionName As String = "getDataFromBO"

    Private m_autoID As String

    Private m_reference As String

    Private m_reserver As String

    Private m_iPAddress As String

    Private commandType As String

    Private parentObjectName As String

    Private m_parentClause As String

    ''' <remarks/>
    <XmlArray(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> _
    <XmlArrayItem("Entry", GetType(ObjectMessageObjDataEntry), Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> _
    Public Property ObjData() As ObjectMessageObjDataEntry()
        Get
            Return Me.objDataField
        End Get
        Set(ByVal value As ObjectMessageObjDataEntry())
            Me.objDataField = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property TXDATE() As String
        Get
            Return Me.transactionDate
        End Get
        Set(ByVal value As String)
            Me.transactionDate = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property TXNUM() As String
        Get
            Return Me.transactionNumber
        End Get
        Set(ByVal value As String)
            Me.transactionNumber = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property TXTIME() As String
        Get
            Return Me.transactionTime
        End Get
        Set(ByVal value As String)
            Me.transactionTime = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property TLID() As String
        Get
            Return Me.tellerID
        End Get
        Set(ByVal value As String)
            Me.tellerID = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property BRID() As String
        Get
            Return Me.branchID
        End Get
        Set(ByVal value As String)
            Me.branchID = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property LOCAL() As String
        Get
            Return Me.isLocal
        End Get
        Set(ByVal value As String)
            Me.isLocal = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property MSGTYPE() As String
        Get
            Return Me.messageType
        End Get
        Set(ByVal value As String)
            Me.messageType = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property OBJNAME() As String
        Get
            Return Me.objectName
        End Get
        Set(ByVal value As String)
            Me.objectName = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property ACTIONFLAG() As String
        Get
            Return Me.m_actionFlag
        End Get
        Set(ByVal value As String)
            Me.m_actionFlag = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property CMDINQUIRY() As String
        Get
            Return Me.commandInquiry
        End Get
        Set(ByVal value As String)
            Me.commandInquiry = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property CLAUSE() As String
        Get
            Return Me.commandClause
        End Get
        Set(ByVal value As String)
            Me.commandClause = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property FUNCTIONNAME() As String
        Get
            Return Me.m_functionName
        End Get
        Set(ByVal value As String)
            Me.m_functionName = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property AUTOID() As String
        Get
            Return Me.m_autoID
        End Get
        Set(ByVal value As String)
            Me.m_autoID = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property REFERENCE() As String
        Get
            Return Me.m_reference
        End Get
        Set(ByVal value As String)
            Me.m_reference = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property RESERVER() As String
        Get
            Return Me.m_reserver
        End Get
        Set(ByVal value As String)
            Me.m_reserver = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property IPADDRESS() As String
        Get
            Return Me.m_iPAddress
        End Get
        Set(ByVal value As String)
            Me.m_iPAddress = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property CMDTYPE() As String
        Get
            Return Me.commandType
        End Get
        Set(ByVal value As String)
            Me.commandType = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property PARENTOBJNAME() As String
        Get
            Return Me.parentObjectName
        End Get
        Set(ByVal value As String)
            Me.parentObjectName = value
        End Set
    End Property

    ''' <remarks/>
    <XmlAttribute()> _
    Public Property PARENTCLAUSE() As String
        Get
            Return Me.m_parentClause
        End Get
        Set(ByVal value As String)
            Me.m_parentClause = value
        End Set
    End Property
End Class