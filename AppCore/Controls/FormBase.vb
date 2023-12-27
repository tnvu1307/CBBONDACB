Imports DevExpress.XtraTab
Imports System.Reflection
Imports AppCore.FormBaseAttribute
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports System.Windows.Forms

Public Class FormBase
    Private _page As XtraTabPage
    Private _panel As Panel
    Private _dockStyle As DockStyle
    Private _anchor As AnchorStyles
    Private _location As LocationEnum
    Dim att As Object

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        If DelegateUtil.DlgModuleAction Is Nothing Then
            MyBase.OnLoad(e)
            Return
        End If

        Me.TopLevel = False
        _page = New XtraTabPage()
        _page.Name = String.Format("{0}|{1}", Me.Name, GetKeyParam())
        _page.Text = "Loading page ..."
        _panel = New Panel()
        _panel.Dock = DockStyle.Fill
        _panel.BackColor = SystemColors.Control
        _panel.HorizontalScroll.Maximum = 0
        _panel.AutoScroll = False
        _panel.VerticalScroll.Visible = False
        _panel.AutoScroll = True
        Dim ucLoading As UCLoadingPage = New UCLoadingPage()
        ucLoading.Dock = DockStyle.Fill
        _panel.Controls.Add(ucLoading)
        _page.Controls.Add(_panel)

        DelegateUtil.DlgModuleAction(DelegateUtil.EACTION.ADD, _page)

        MyBase.OnLoad(e)
        Dim cmdID As String = GetPropDynamic(Me, "CMDID")
        _page.Text = IIf(Not String.IsNullOrEmpty(cmdID), "[" & cmdID & "] ", "") & Me.Text

        Me.GetAtt()
        'Vi tri hien thi Form trong Tab
        Me.SetLocation()
        'Convert Form to UC add to panel
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Dock = _dockStyle
        Me.Anchor = _anchor
        Me.AutoScroll = True
        _panel.Controls.Clear()
        _panel.Controls.Add(Me)
    End Sub

    Public Sub CloseTab()
        If _page IsNot Nothing And DelegateUtil.DlgModuleAction IsNot Nothing Then
            DelegateUtil.DlgModuleAction(DelegateUtil.EACTION.CLOSE, _page)
        End If
    End Sub

    Public Function ShowDialog() As DialogResult
        Me.TopLevel = False
        MyBase.Show()
        Return DialogResult.None
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Return
    End Sub

    Public Function GetKeyParam() As String
        Dim result As String
        Try
            Dim tablename As String = GetPropDynamic(Me, "TableName")
            Dim exeFlag As String = GetPropDynamic(Me, "ExeFlag")
            If String.IsNullOrEmpty(tablename) And String.IsNullOrEmpty(exeFlag) Then
                Return Me.Handle.ToString()
            End If

            result = tablename & "|" & exeFlag
        Catch ex As Exception
            result = Me.Handle.ToString()
        End Try
        Return result
    End Function

    Protected Function GetFieldDynamic(ByVal src As Object, ByVal fieldName As String) As Object
        Try
            Return src.GetType().GetField(fieldName).GetValue(src)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Function GetPropDynamic(ByVal src As Object, ByVal propName As String) As Object
        Try
            Return src.GetType().GetProperty(propName).GetValue(src, Nothing)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#Region "Method Util"
    Private Sub GetAtt()
        _anchor = Me.Anchor
        _dockStyle = DockStyle.Fill
        Dim memberInfo As MemberInfo = Me.GetType()
        If memberInfo IsNot Nothing Then
            Dim attributes As Object() = memberInfo.GetCustomAttributes(True)
            If attributes IsNot Nothing And attributes.Count > 0 Then
                For Each att In attributes
                    Dim fbAttr As FormBaseAttribute
                    Try
                        fbAttr = CType(att, FormBaseAttribute)
                    Catch ex As Exception
                        Continue For
                    End Try

                    If fbAttr IsNot Nothing Then
                        If fbAttr._AnchorStyles IsNot Nothing Then
                            _anchor = fbAttr._AnchorStyles
                        End If

                        If fbAttr._DockStyle IsNot Nothing Then
                            _dockStyle = fbAttr._DockStyle
                        End If
                        If fbAttr._Location IsNot Nothing Then
                            _location = fbAttr._Location
                            _dockStyle = DockStyle.None
                        End If

                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SetLocation()
        If Not IsDBNull(_location) Then
            Select Case _location
                Case LocationEnum.TOP_CENTER
                    Me.StartPosition = FormStartPosition.Manual
                    Dim rcScreen As Rectangle = Screen.PrimaryScreen.WorkingArea
                    Me.Location = New System.Drawing.Point((rcScreen.Left + rcScreen.Right) / 2 - (Me.Width / 2), 10)
                Case LocationEnum.TOP_LEFT
                    Me.StartPosition = FormStartPosition.Manual
                    Dim rcScreen As Rectangle = Screen.PrimaryScreen.WorkingArea
                    Me.Location = New System.Drawing.Point(10, 10)
            End Select
        End If
    End Sub
#End Region

End Class


<AttributeUsage(AttributeTargets.All)>
Public Class FormBaseAttribute
    Inherits Attribute

    Public Enum LocationEnum
        TOP_CENTER
        TOP_LEFT
    End Enum

    Protected Friend _DockStyle? As DockStyle
    Protected Friend _AnchorStyles? As AnchorStyles
    Protected Friend _Location? As LocationEnum

    Public Sub New()
    End Sub

    Public Sub New(ByVal location As LocationEnum)
        Me._Location = location
    End Sub
End Class