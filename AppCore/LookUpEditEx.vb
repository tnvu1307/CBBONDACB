Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Public Class LookUpEditEx
    Inherits LookUpEdit

    Dim ds As New DataSet
    Dim dr As DataRow

    Public Const COMBOBOX_TABLE As String = "COMBOBOX"
    Public Const DISPLAY_ITEM As String = "DISPLAY"
    Public Const VALUE_ITEM As String = "VALUE"

    Public is_check As Boolean = False

    Public Property ComboData() As DataTable
        Get
            Return ds.Tables(0).Copy()
        End Get
        Set(ByVal Value As DataTable)
            ds.Tables.Remove("COMBOBOX")
            ds.Tables.Add(Value)
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            If Me.EditValue Is Nothing Then
                Return Nothing
            End If

            Return Me.EditValue.ToString()
        End Get
        Set(value As String)
            SetLookUpEditDefaultValue(Me, value)
        End Set
    End Property


    'Modified by TungNT
    Public ReadOnly Property ComboSource() As DataTable
        Get
            Return ds.Tables(0).Copy()
        End Get
    End Property
    'End Modified

    Public Sub New()
        MyBase.New()
        BuildDataTables()
        If Not MyBase.Properties.DataSource Is Nothing Then
            MyBase.Properties.DataSource.Clear()
        End If

        Me.BeginUpdate()
        BindingXtraLookUpEdit(ds.Tables(COMBOBOX_TABLE), Me.Properties, Nothing)
        Me.EndUpdate()
    End Sub

    Public Sub Clears()
        ds.Tables(0).Clear()
    End Sub

    Public Sub AddItems(ByVal ItemDisplay As String, ByVal ItemValue As Object)
        dr = ds.Tables(0).NewRow
        ds.Tables(0).Rows.Add(dr)
        dr(DISPLAY_ITEM) = ItemDisplay
        dr(VALUE_ITEM) = ItemValue.ToString
    End Sub

    Public Sub AddAllItems(ByVal ItemDisplay() As String, ByVal ItemValue() As Object)
        dr = ds.Tables(0).NewRow
        For i As Integer = 0 To ItemDisplay.GetLength(0) - 1
            ds.Tables(0).Rows.Add(dr)
            dr(DISPLAY_ITEM) = ItemDisplay(i)
            dr(VALUE_ITEM) = ItemValue(i).ToString
        Next
    End Sub

    Public Sub RemoveItem(ByVal ItemValue As Object)
        For i As Integer = ds.Tables(COMBOBOX_TABLE).Rows.Count - 1 To 0
            If CStr(ds.Tables(COMBOBOX_TABLE).Rows(i)(VALUE_ITEM)) = CStr(ItemValue) Then
                ds.Tables(COMBOBOX_TABLE).Rows.RemoveAt(i)
                Exit For
            End If
        Next
    End Sub

    Public Function GetItemDisplayByKey(ByVal KeyValue As String)
        For Each v_dr As DataRow In ds.Tables(0).Rows
            If v_dr(VALUE_ITEM) = KeyValue Then
                Return CStr(v_dr(DISPLAY_ITEM))
            End If
        Next
    End Function

    Public Sub CopyTo(ByRef obj As LookUpEditEx)
        If obj Is Nothing Then
            obj = New LookUpEditEx
            For Each v_dr As DataRow In ds.Tables(0).Rows
                obj.AddItems(CStr(v_dr(DISPLAY_ITEM)), CStr(v_dr(VALUE_ITEM)))
            Next
        End If
    End Sub

    Public Function GetSize() As Integer
        Return ds.Tables(0).Rows.Count
    End Function

    Public Function IsContaints(ByVal KeyValue As String) As Boolean
        For Each v_dr As DataRow In ds.Tables(0).Rows
            If v_dr(VALUE_ITEM) = KeyValue Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub c_Forcus()
        Me.is_check = True
        Me.Focus()
    End Sub

    Private Sub BuildDataTables()
        Dim table As DataTable = New DataTable(COMBOBOX_TABLE)
        With table.Columns
            .Add(DISPLAY_ITEM, GetType(System.String))
            .Add(VALUE_ITEM, GetType(System.Object))
        End With
        ds.Tables.Add(table)
    End Sub

    Private Sub ComboBoxAutoComplete_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim Index As Integer
        Dim Actual As String
        Dim Found As String
        Dim MatchFound As Boolean
        Try
            Me.Text = Me.Text.Trim
            If Me.Text.Length = 0 Then
                Me.SelectedValue = -1
                Me.SelectAll()
                Return
            End If

            'If the backspace key was pressed then remove the last character that was typed in and try to find a match.
            'Note that the selected text from the last character typed in to the end of the combo text field will also be deleted.
            If e.KeyCode = Keys.Back Then
                Me.Text = Me.Text.Substring(0, Me.Text.Length - 1)
            End If


            ' Do nothing for some keys such as navigation keys.
            If ((e.KeyCode = Keys.Left) Or _
                (e.KeyCode = Keys.Right) Or _
                (e.KeyCode = Keys.Up) Or _
                (e.KeyCode = Keys.Down) Or _
                (e.KeyCode = Keys.PageUp) Or _
                (e.KeyCode = Keys.PageDown) Or _
                (e.KeyCode = Keys.Home) Or _
                (e.KeyCode = Keys.End) Or _
                (e.KeyCode = Keys.Tab) Or _
                (e.KeyCode = Keys.Tab And e.Shift)) Then
                Return
            End If

            If e.KeyCode = Keys.Enter Then
                If is_check = True Then
                    is_check = False
                    Return
                End If
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
