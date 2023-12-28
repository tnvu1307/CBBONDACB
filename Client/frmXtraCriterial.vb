Imports DevExpress.Data.Filtering
Imports AppCore.modXtraLib
Imports DevExpress.XtraEditors.Filtering

Public Class frmXtraCriterial
    Public Property ReturnValue As String

    Public Property SearchFieldMadatory As String()
    Public Property SearchFieldName As String()
    Public Property SearchFieldType As String()
    Public Property SearchFieldCaption As String()
    Public Property SearchFieldSqlRef As String()
    Public Property SearchFieldDisplayText As String
    Public Property mv_language As String
    Private Shared _op As CriteriaOperator


    Private Sub sbSearch_Click(sender As Object, e As EventArgs) Handles sbSearch.Click
        ReturnValue = String.Empty
        _op = Nothing
        If (Not (fcCriterial.CriterialProperty.FilterCriteria) Is Nothing) Then
            _op = fcCriterial.CriterialProperty.FilterCriteria
            ReturnValue &= " AND " & DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetOracleWhere(_op)
            SearchFieldDisplayText = fcCriterial.CriterialProperty.GetFilterDisplayText()
        End If
        Me.Close()
    End Sub

    Private Sub frmXtraCriterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'create filter control
        CreateFilterColumn(fcCriterial.CriterialProperty, SearchFieldMadatory, SearchFieldName, SearchFieldType, SearchFieldCaption, SearchFieldSqlRef, mv_language)
        If Not _op Is Nothing Then
            fcCriterial.CriterialProperty.FilterCriteria = _op
        End If

    End Sub

    Private Sub sbCancel_Click(sender As Object, e As EventArgs) Handles sbCancel.Click
        Me.Dispose()
    End Sub

End Class