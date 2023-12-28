Module modDirect
    Public Const gc_RegistryKey = "Software\FSS\@VSTP"
    Public Const gc_RootNamespace = "_VSTP"

#Region " Các hằng số Value trong registry "
    Public Const gc_REG_USERNAME = "UserName"
    Public Const gc_REG_PASSWORD = "Password"

    Public Const gc_REG_LANG = "Language"

    Public Const gc_REG_HEIGHT = "Height"
    Public Const gc_REG_WIDTH = "Width"
    Public Const gc_REG_WINSTATE = "WindowState"
#End Region

#Region " Các hằng số mã lỗi hệ thống "
    Public Const gc_SYSERR_BAD_URL = "SYS-000001"
    Public Const gc_SYSERR_SVR_ERROR = "SYS-000002"
    Public Const gc_SYSERR_CONTACT_NET_ADMIN = "SYS-000003"
    Public Const gc_SYSERR_SRV_UNREACHABLE = "SYS-000004"
    Public Const gc_SYSERR_CHECK_CONNECTION = "SYS-000005"
    Public Const gc_SYSERR_INCORRECT_USR_OR_PWD = "SYS-000006"
    Public Const gc_SYSERR_RE_TYPE = "SYS-000007"
    Public Const gc_SYSERR_UNKNOWN_ERROR = "SYS-000008"
    Public Const gc_SYSERR_CHECK_EVENT_LOG = "SYS-000009"
#End Region

End Module
