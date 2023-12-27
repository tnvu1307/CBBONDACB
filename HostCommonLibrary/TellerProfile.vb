Imports System.Runtime.Serialization

<Serializable()>
<DataContract()>
Public Class CTellerProfile
    <DataMember()>
    Public Property NextDate() As String
        Get
            Return m_NextDate
        End Get
        Set(value As String)
            m_NextDate = value
        End Set
    End Property
    Private m_NextDate As String
    <DataMember()>
    Public Property TellerId() As String
        Get
            Return m_TellerId
        End Get
        Set(value As String)
            m_TellerId = value
        End Set
    End Property
    Private m_TellerId As String
    <DataMember()>
    Public Property TellerName() As String
        Get
            Return m_TellerName
        End Get
        Set(value As String)
            m_TellerName = value
        End Set
    End Property
    Private m_TellerName As String
    <DataMember()>
    Public Property TellerFullName() As String
        Get
            Return m_TellerFullName
        End Get
        Set(value As String)
            m_TellerFullName = value
        End Set
    End Property
    Private m_TellerFullName As String
    <DataMember()>
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(value As String)
            m_Password = value
        End Set
    End Property
    Private m_Password As String
    <DataMember()>
    Public Property TellerLevel() As String
        Get
            Return m_TellerLevel
        End Get
        Set(value As String)
            m_TellerLevel = value
        End Set
    End Property
    Private m_TellerLevel As Integer
    <DataMember()>
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(value As String)
            m_CompanyCode = value
        End Set
    End Property
    Private m_CompanyCode As String
    <DataMember()>
    Public Property CompanyName() As String
        Get
            Return m_CompanyName
        End Get
        Set(value As String)
            m_CompanyName = value
        End Set
    End Property
    Private m_CompanyName As String
    <DataMember()>
    Public Property BranchId() As String
        Get
            Return m_BranchId
        End Get
        Set(value As String)
            m_BranchId = value
        End Set
    End Property
    Private m_BranchId As String
    <DataMember()>
    Public Property BranchName() As String
        Get
            Return m_BranchName
        End Get
        Set(value As String)
            m_BranchName = value
        End Set
    End Property
    Private m_BranchName As String
    <DataMember()>
    Public Property BusDate() As String
        Get
            Return m_BusDate
        End Get
        Set(value As String)
            m_BusDate = value
        End Set
    End Property
    Private m_BusDate As String
    <DataMember()>
    Public Property Interval() As String
        Get
            Return m_Interval
        End Get
        Set(value As String)
            m_Interval = value
        End Set
    End Property
    Private m_Interval As String
    <DataMember()>
    Public Property TellerTitle() As String
        Get
            Return m_TellerTitle
        End Get
        Set(value As String)
            m_TellerTitle = value
        End Set
    End Property
    Private m_TellerTitle As String
    <DataMember()>
    Public Property TellerPrinterName() As String
        Get
            Return m_TellerPrinterName
        End Get
        Set(value As String)
            m_TellerPrinterName = value
        End Set
    End Property
    Private m_TellerPrinterName As String
    <DataMember()>
    Public Property TellerGroup() As String
        Get
            Return m_TellerGroup
        End Get
        Set(value As String)
            m_TellerGroup = value
        End Set
    End Property
    Private m_TellerGroup As String
    <DataMember()>
    Public Property TellerRight() As String
        Get
            Return m_TellerRight
        End Get
        Set(value As String)
            m_TellerRight = value
        End Set
    End Property
    Private m_TellerRight As String
    <DataMember()>
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Private m_Description As String
    <DataMember()>
    Public Property LoginTime() As String
        Get
            Return m_LoginTime
        End Get
        Set(value As String)
            m_LoginTime = value
        End Set
    End Property
    Private m_LoginTime As String
    <DataMember()>
    Public Property TellerGroupCareBy() As String
        Get
            Return m_TellerGroupCareBy
        End Get
        Set(value As String)
            m_TellerGroupCareBy = value
        End Set
    End Property
    Private m_TellerGroupCareBy As String
    <DataMember()>
    Public Property TimeSearch() As String
        Get
            Return m_TimeSearch
        End Get
        Set(value As String)
            m_TimeSearch = value
        End Set
    End Property
    Private m_TimeSearch As String
    <DataMember()>
    Public Property IPAddress() As String
        Get
            Return m_IPAddress
        End Get
        Set(value As String)
            m_IPAddress = value
        End Set
    End Property
    Private m_IPAddress As String
    <DataMember()>
    Public Property MacAddress() As String
        Get
            Return m_MacAddress
        End Get
        Set(value As String)
            m_MacAddress = value
        End Set
    End Property
    Private m_MacAddress As String
    <DataMember()>
    Public Property AccessArea() As String
        Get
            Return m_AccessArea
        End Get
        Set(value As String)
            m_AccessArea = value
        End Set
    End Property
    Private m_AccessArea As String

End Class

