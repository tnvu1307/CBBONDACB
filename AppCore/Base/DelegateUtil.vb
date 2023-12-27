Imports DevExpress.XtraTab

Public Class DelegateUtil
    Public Enum EACTION
        ADD
        CLOSE
        CLEAR 'Clear all tab
        CLOSE_ALL_BUT_THIS
        SELECT_PAGE_EXIST
    End Enum

    Public Shared DlgModuleAction As Action(Of EACTION, XtraTabPage)
End Class
