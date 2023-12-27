Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.EnterpriseServices
Imports System.Reflection
Imports System.Windows.Forms
Imports CommonLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports log4net

''' <summary>
''' Chi su dung cho gridcontrol co properties co MultiSelection = false hoac gridcontrol "Tra cuu so lenh"
''' </summary>
Public Class GridCheckMarksSelection

    Protected gridView As GridView

    Protected selection As ArrayList

    Private _column As GridColumn

    Private _edit As RepositoryItemCheckEdit

    Private mv_objname As String = ""

    'Private Shared logger As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod.DeclaringType)

    Public Sub New()
        MyBase.New()
        Me.selection = New ArrayList
    End Sub

    Public Sub New(ByVal view As GridView)
        Me.New()
        GridControlView = view
    End Sub
    Public Sub New(ByVal view As GridView, ByVal pv_objname As String)
        Me.New()
        Me.mv_objname = pv_objname
        GridControlView = view
    End Sub

    Protected Overridable Sub Attach(ByVal view As GridView)
        Try
            If (view Is Nothing) Then
                Return
            End If

            Me.selection.Clear()
            Me.gridView = view
            Me._edit = CType(view.GridControl.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            AddHandler Me._edit.EditValueChanged, AddressOf Me.edit_EditValueChanged
            If Not view.Columns.Contains(view.Columns.ColumnByFieldName("CheckMarkSelection")) Then
                Me._column = view.Columns.Add
                Me._column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                Me._column.VisibleIndex = Int32.MaxValue
                Me._column.FieldName = "CheckMarkSelection"
                Me._column.Caption = "Mark"
                Me._column.OptionsColumn.ShowCaption = False
                Me._column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                Me._column.ColumnEdit = Me._edit
                Me._column.Width = 10
            End If

            If view.OptionsSelection.MultiSelect Then
                AddHandler view.CustomDrawColumnHeader, AddressOf Me.View_CustomDrawColumnHeader
            End If

            AddHandler view.CustomDrawGroupRow, AddressOf Me.View_CustomDrawGroupRow
            AddHandler view.CustomUnboundColumnData, AddressOf Me.view_CustomUnboundColumnData
            AddHandler view.RowStyle, AddressOf Me.view_RowStyle
            AddHandler view.MouseDown, AddressOf Me.view_MouseDown
            ' clear selection
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Protected Overridable Sub Detach()
        Try
            If (Me.gridView Is Nothing) Then
                Return
            End If

            If (Not (Me._column) Is Nothing) Then
                Me._column.Dispose()
            End If

            If (Not (Me._edit) Is Nothing) Then
                Me.gridView.GridControl.RepositoryItems.Remove(Me._edit)
                Me._edit.Dispose()
            End If

            RemoveHandler gridView.CustomDrawColumnHeader, AddressOf Me.View_CustomDrawColumnHeader
            RemoveHandler gridView.CustomDrawGroupRow, AddressOf Me.View_CustomDrawGroupRow
            RemoveHandler gridView.CustomUnboundColumnData, AddressOf Me.view_CustomUnboundColumnData
            RemoveHandler gridView.RowStyle, AddressOf Me.view_RowStyle
            RemoveHandler gridView.MouseDown, AddressOf Me.view_MouseDown
            Me.gridView = Nothing
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Protected Sub DrawCheckBox(ByVal g As Graphics, ByVal r As Rectangle, ByVal Checked As Boolean)
        Try
            Dim info As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo
            Dim painter As DevExpress.XtraEditors.Drawing.CheckEditPainter
            Dim args As DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs
            info = CType(Me._edit.CreateViewInfo, DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
            painter = CType(Me._edit.CreatePainter, DevExpress.XtraEditors.Drawing.CheckEditPainter)
            info.EditValue = Checked
            info.Bounds = r
            info.CalcViewInfo(g)
            args = New DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, New DevExpress.Utils.Drawing.GraphicsCache(g), r)
            painter.Draw(args)
            args.Cache.Dispose()
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub view_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Try
            If ((e.Clicks = 1) _
                        AndAlso (e.Button = MouseButtons.Left)) Then
                Dim pt As Point = Me.gridView.GridControl.PointToClient(Control.MousePosition)
                Dim info As GridHitInfo = Me.gridView.CalcHitInfo(pt)
                If mv_objname = "TLLOG" Then
                    Dim isDisable = Me.gridView.GetRowCellValue(info.RowHandle, "TXSTATUSCD")
                    Dim v_approveAllow = Me.gridView.GetRowCellValue(info.RowHandle, "APRALLOW")
                    Dim v_refuseAllow = Me.gridView.GetRowCellValue(info.RowHandle, "REFUSEALLOW")
                    Dim v_tltxcd = Me.gridView.GetRowCellValue(info.RowHandle, "TLTXCD")
                    Dim V_DELALLOW = Me.gridView.GetRowCellValue(info.RowHandle, "DELALLOW")
                    Dim V_DELTD = Me.gridView.GetRowCellValue(info.RowHandle, "DELTD")
                    If ((Not (isDisable) Is Nothing) _
                                AndAlso (InStr("|4|7|1", isDisable) = 0 Or (V_DELALLOW = "N" And (InStr("|1|", isDisable) > 0)) Or (v_approveAllow = "N" And v_refuseAllow = "N")) Or V_DELTD = "Có") Then
                        Return
                    End If
                ElseIf mv_objname = "BROKER_CASHHOLD" Then
                    Dim isDisable = gridView.GetRowCellValue(info.RowHandle, "STATUS")
                    Dim v_unhold = gridView.GetRowCellValue(info.RowHandle, "UNHOLD")
                    If ((Not (isDisable) Is Nothing) _
                               AndAlso (InStr("C", isDisable) = 0 Or v_unhold = "Y")) Then
                        Return
                    End If
                ElseIf mv_objname = "BROKER_SEHOLD" Then
                    Dim isDisable = Me.gridView.GetRowCellValue(info.RowHandle, "STATUS")
                    Dim v_unhold = Me.gridView.GetRowCellValue(info.RowHandle, "UNHOLD")
                    If ((Not (isDisable) Is Nothing) _
                               AndAlso (InStr("1", isDisable) = 0)) Then
                        Return
                    End If
                End If

                If Not Me.gridView.OptionsSelection.MultiSelect Then
                    If (info.InRow _
                                AndAlso (Me.gridView.IsDataRow(info.RowHandle))) Then
                        Me.ClearSelection()
                        'SelectRow(info.RowHandle, true);
                        Me.SelectRow(info.RowHandle, Not Me.IsRowSelected(info.RowHandle))
                    End If

                    If (info.InColumn _
                                AndAlso (info.Column Is Me._column)) Then
                        If (SelectedCount = Me.gridView.DataRowCount) Then
                            Me.ClearSelection()
                        Else
                            Me.SelectAll()
                        End If

                    End If

                    If (info.InRow _
                                AndAlso (Me.gridView.IsGroupRow(info.RowHandle) _
                                AndAlso (info.HitTest <> GridHitTest.RowGroupButton))) Then
                        Dim selected As Boolean = Me.IsGroupRowSelected(info.RowHandle)
                        Me.SelectGroup(info.RowHandle, Not selected)
                    End If

                ElseIf Me.gridView.OptionsSelection.MultiSelect Then
                    'if (info.InRow && info.Column != column && gridGridControlView.IsDataRow(info.RowHandle))
                    '{
                    '    ClearSelection();
                    '    //SelectRow(info.RowHandle, true);
                    '    SelectRow(info.RowHandle, !IsRowSelected(info.RowHandle));
                    '}
                    If (info.InColumn _
                                AndAlso (info.Column Is Me._column)) Then
                        If (SelectedCount = Me.gridView.DataRowCount) Then
                            Me.ClearSelection()
                        Else
                            Me.SelectAll()
                        End If

                    End If

                    If (info.InRow _
                                AndAlso (info.Column Is Me._column)) Then
                        Me.SelectRow(info.RowHandle, Not Me.IsRowSelected(info.RowHandle))
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub View_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As ColumnHeaderCustomDrawEventArgs)
        Try
            If (e.Column Is Me._column) Then
                e.Info.InnerElements.Clear()
                e.Painter.DrawObject(e.Info)
                Me.DrawCheckBox(e.Graphics, e.Bounds, (SelectedCount = Me.gridView.DataRowCount))
                e.Handled = True
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub View_CustomDrawGroupRow(ByVal sender As Object, ByVal e As RowObjectCustomDrawEventArgs)
        Try
            Dim info = CType(e.Info, GridGroupRowInfo)
            info.GroupText = ("         " + info.GroupText.TrimStart)
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds)
            e.Painter.DrawObject(e.Info)
            Dim r As Rectangle = info.ButtonBounds
            r.Offset((r.Width * 2), 0)
            Me.DrawCheckBox(e.Graphics, r, Me.IsGroupRowSelected(e.RowHandle))
            e.Handled = True
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub view_RowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs)
        Try
            If Me.IsRowSelected(e.RowHandle) Then
                e.Appearance.BackColor = SystemColors.Highlight
                e.Appearance.ForeColor = ColorTranslator.FromHtml("#1a237e")
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Property GridControlView As GridView
        Get
            Return Me.gridView
        End Get
        Set(value As GridView)
            If (Me.gridView IsNot value) Then
                Me.Detach()
                Me.Attach(value)
            End If
        End Set
    End Property

    Public ReadOnly Property CheckMarkColumn As GridColumn
        Get
            Return Me._column
        End Get
    End Property

    Public ReadOnly Property SelectedCount As Integer
        Get
            Return Me.selection.Count
        End Get
    End Property

    Public Function GetSelectedRow(ByVal index As Integer) As Object
        Return Me.selection(index)
    End Function

    Public Function GetSelectedIndex(ByVal row As Object) As Integer
        Return Me.selection.IndexOf(row)
    End Function

    Public Sub ClearSelection()
        Me.selection.Clear()
        Dim dataView = CType(Me.gridView.DataSource, DataView)
        dataView.RowFilter = ""
        Me.Invalidate()
    End Sub

    Private Sub Invalidate()
        Me.gridView.CloseEditor()
        Me.gridView.BeginUpdate()
        Me.gridView.EndUpdate()
    End Sub

    Public Sub SelectAll()
        Try
            Me.selection.Clear()
            'ICollection dataSource = gridGridControlView.DataSource as ICollection;
            Dim dataView = CType(Me.gridView.DataSource, DataView)
            If mv_objname = "TLLOG" Then
                dataView.RowFilter = "TXSTATUSCD = 4 OR TXSTATUSCD = 7"
            ElseIf mv_objname = "BROKER_CASHHOLD" And Me.gridView.DataRowCount > 0 Then
                dataView.RowFilter = "STATUS = 'C' and UNHOLD = 'N'"
            ElseIf mv_objname = "BROKER_SEHOLD" Then
                dataView.RowFilter = "STATUS = 1"
            End If
            Dim dataSource = CType(dataView, ICollection)
            'if (dataSource != null && dataSource.Count == gridGridControlView.DataRowCount)
            If ((Not (dataSource) Is Nothing) _
                        AndAlso (dataSource.Count = Me.gridView.DataRowCount)) Then
                If (dataSource.Count <> 0) Then
                    Me.selection.AddRange(dataSource)
                End If

                ' fast                    
            Else
                Dim i As Integer = 0
                Do While (i < Me.gridView.DataRowCount)
                    Me.selection.Add(Me.gridView.GetRow(i))
                    i = (i + 1)
                Loop

            End If

            Me.Invalidate()
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub SelectGroup(ByVal rowHandle As Integer, ByVal selected As Boolean)
        Try
            If (Me.IsGroupRowSelected(rowHandle) AndAlso selected) Then
                Return
            End If

            Dim i As Integer = 0
            Do While (i < Me.gridView.GetChildRowCount(rowHandle))
                Dim childRowHandle As Integer = Me.gridView.GetChildRowHandle(rowHandle, i)
                If Me.gridView.IsGroupRow(childRowHandle) Then
                    Me.SelectGroup(childRowHandle, selected)
                Else
                    Me.SelectRow(childRowHandle, selected, False)
                End If

                i = (i + 1)
            Loop

            Me.Invalidate()
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Overloads Sub SelectRow(ByVal columnName As String, ByVal columnValue As String)
        Try
            If (Me.SelectedCount > 0) Then
                Return
            End If

            Dim i As Integer = 0
            Do While (i < Me.gridView.RowCount)
                If Me.gridView.GetRowCellValue(i, columnName).Equals(columnValue) Then
                    Me.SelectRow(i, True, True)
                    Exit Do
                End If

                i = (i + 1)
            Loop

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Overloads Sub SelectRow(ByVal rowHandle As Integer, ByVal selected As Boolean)
        Me.SelectRow(rowHandle, selected, True)
    End Sub

    Private Overloads Sub SelectRow(ByVal rowHandle As Integer, ByVal selected As Boolean, ByVal invalidate As Boolean)
        Try
            If (Me.IsRowSelected(rowHandle) = selected) Then
                Return
            End If

            Dim row As Object = Me.gridView.GetRow(rowHandle)
            If selected Then
                Me.selection.Add(row)
            Else
                Me.selection.Remove(row)
            End If

            If invalidate Then
                Me.Invalidate()
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function IsGroupRowSelected(ByVal rowHandle As Integer) As Boolean
        Try
            Dim i As Integer = 0
            Do While (i < Me.gridView.GetChildRowCount(rowHandle))
                Dim row As Integer = Me.gridView.GetChildRowHandle(rowHandle, i)
                If Me.gridView.IsGroupRow(row) Then
                    If Not Me.IsGroupRowSelected(row) Then
                        Return False
                    End If

                ElseIf Not Me.IsRowSelected(row) Then
                    Return False
                End If

                i = (i + 1)
            Loop

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Public Function IsRowSelected(ByVal rowHandle As Integer) As Boolean
        Dim result = False
        Try
            If Me.gridView.IsGroupRow(rowHandle) Then
                Return Me.IsGroupRowSelected(rowHandle)
            End If

            Dim row As Object = Me.gridView.GetRow(rowHandle)
            result = (Me.GetSelectedIndex(row) <> -1)
        Catch ex As Exception
            Throw
        End Try

        Return result
    End Function

    Private Sub view_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs)
        Try
            If (e.Column Is Me.CheckMarkColumn) Then
                If e.IsGetData Then
                    e.Value = Me.IsRowSelected(Me.GridControlView.GetRowHandle(e.ListSourceRowIndex))
                Else
                    Me.SelectRow(Me.GridControlView.GetRowHandle(e.ListSourceRowIndex), CType(e.Value, Boolean))
                End If

            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'gridGridControlView.PostEditor();
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function GetSelectionRows() As ArrayList
        Return Me.selection
    End Function
End Class