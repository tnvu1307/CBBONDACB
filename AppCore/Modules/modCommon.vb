Imports Xceed.Grid

Module modCommon
    'Hằng số quy ước định dạng dữ liệu
    Public Const gc_FORMAT_DATE = "dd/MM/yyyy"
    Public Const gc_FORMAT_INTEGER = "#,##0"

    Public Const gc_IS_LAST_MENU = "Y"

    Public Enum SearchType
        SearchNone = -1
        SearchChoose = 0
        SearchText = 1
        SearchNumeric = 2
        SearchDate = 3
    End Enum

End Module

Public Class ComboBoxItem
    Private mv_strItemData As String = String.Empty
    Private mv_strItemText As String = String.Empty

    Public Sub New(ByVal ItemData As String, ByVal ItemText As String)
        mv_strItemData = ItemData
        mv_strItemText = ItemText
    End Sub

    Public ReadOnly Property Value() As String
        Get
            Return mv_strItemData
        End Get
    End Property

    Public ReadOnly Property Text() As String
        Get
            Return mv_strItemText
        End Get
    End Property
End Class
