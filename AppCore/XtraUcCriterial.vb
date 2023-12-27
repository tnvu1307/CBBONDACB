Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Namespace Controls

    Public Class XtraUcCriterial

        Private Sub fcCriterial_PopupMenuShowing(sender As Object, e As DevExpress.XtraEditors.Filtering.PopupMenuShowingEventArgs) Handles fcCriterial.PopupMenuShowing
            If (e.MenuType = DevExpress.XtraEditors.Filtering.FilterControlMenuType.Clause And e.Menu.Items.Count > 0) Then

                For i As Integer = e.Menu.Items.Count - 1 To 0
                    If e.Menu.Items(i).Caption = Localizer.Active.GetLocalizedString(StringId.FilterClauseBeginsWith) Or e.Menu.Items(i).Caption = Localizer.Active.GetLocalizedString(StringId.FilterClauseContains) Then
                        e.Menu.Items.RemoveAt(i)
                    End If
                Next
            End If
        End Sub

        Protected Overridable Sub CreateUnboundColumnFilter(arrSearchFieldRequired() As String, arrSearchFieldName() As String, arrSearchFieldType() As String, arrSearchFieldCaption() As String, arrSearchSqlRef() As String)
            CreateFilterColumn(fcCriterial, arrSearchFieldRequired, arrSearchFieldName, arrSearchFieldType, arrSearchFieldCaption, arrSearchSqlRef)
        End Sub

        Public ReadOnly Property CriterialProperty As XtraFilterControl
            Get
                Return _fcCriterial
            End Get
        End Property
    End Class
End Namespace