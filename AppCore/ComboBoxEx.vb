Imports System.Windows.Forms.ComboBox
Imports System.Windows.Forms

Public Class ComboBoxEx
    Inherits System.Windows.Forms.ComboBox

    Dim ds As New DataSet
    Dim dr As DataRow

    Public Const COMBOBOX_TABLE As String = "COMBOBOX"
    Public Const DISPLAY_ITEM As String = "DISPLAY"
    Public Const VALUE_ITEM As String = "VALUE"
    Public Property ComboData() As DataTable
        Get
            Return ds.Tables(0).Copy()
        End Get
        Set(ByVal Value As DataTable)
            ds.Tables.Remove("COMBOBOX")
            ds.Tables.Add(Value)
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
        MyBase.Items.Clear()
        Me.BeginUpdate()
        Me.DataSource = ds.Tables(COMBOBOX_TABLE)
        Me.DisplayMember = DISPLAY_ITEM
        Me.ValueMember = VALUE_ITEM
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

    Public Sub CopyTo(ByRef obj As ComboBoxEx)
        If obj Is Nothing Then
            obj = New ComboBoxEx
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
            'If the contents of the combo have been removed then select the first entry in the combo box list.
            Me.Text = Me.Text.Trim
            If Me.Text.Length = 0 Then
                Me.SelectedIndex = -1
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
            Do
                ' Store the actual text that has been typed.
                Actual = Me.Text

                ' Find the first match for the typed value.
                Index = Me.FindString(Actual)
                ' Get the text of the first match.
                'if index > -1 then a match was found.
                If (Index > -1) Then
                    Found = Me.Items(Index).ToString()

                    ' Select this item from the list.
                    Me.SelectedIndex = Index

                    ' Select the portion of the text that was automatically added so that any additional typing will replace it.
                    If Actual.Length = Found.Length Then
                        Me.SelectionStart = 1
                        Me.SelectionLength = Found.Length
                    Else
                        Me.SelectionStart = Actual.Length
                        Me.SelectionLength = Found.Length
                    End If

                    MatchFound = True
                Else
                    'If there isn't a match and the text typed in is only one character or nothing then just select the first
                    'entry in the combo box.
                    If Actual.Length = 1 Or Actual.Length = 0 Then
                        Me.SelectedIndex = -1
                        Me.SelectAll()
                        MatchFound = True
                    Else
                        'if there isn't a match for the text typed in then remove the last character of the text typed in
                        'and try to find a match.
                        Me.SelectionStart = Actual.Length - 1
                        Me.SelectionLength = Actual.Length - 1
                        Me.Text = Me.Text.Substring(0, Me.Text.Length - 1)

                    End If
                End If
            Loop Until MatchFound

            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
