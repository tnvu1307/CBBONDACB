Public Class ImageViewer
    Inherits System.Windows.Forms.UserControl

    'Member Variables
    Private m_MouseButtons As System.Windows.Forms.MouseButtons = Windows.Forms.MouseButtons.Left
    Private m_OriginalImage As System.Drawing.Bitmap

    Private m_PanStartPoint As System.Drawing.Point
    Private m_Origin As New System.Drawing.Point(0, 0)

    Private g As Graphics
    Private SrcRect As System.Drawing.Rectangle
    Private DestRect As System.Drawing.Rectangle

    Private m_ZoomOnMouseWheel As Boolean = True
    Private m_ZoomFactor As Double = 1.0


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region "Public/Private Shadows"
    Public Shadows Property Image() As System.Drawing.Image
        Get
            Return m_OriginalImage
        End Get
        Set(ByVal Value As System.Drawing.Image)
            If Value Is Nothing Then
                m_OriginalImage = Nothing
                Exit Property
            End If
            Dim r As New Rectangle(0, 0, Value.Width, Value.Height)
            m_OriginalImage = Value
            'Clone the image so we can set the pixelformat.
            ' This improves performance quite a bit
            m_OriginalImage = m_OriginalImage.Clone(r, Imaging.PixelFormat.Format32bppRgb)
            'Force a paint
            Me.Invalidate()
        End Set
    End Property

    Public Shadows Property initialimage() As System.Drawing.Image
        Get
            Return m_OriginalImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            Me.Image = value
        End Set
    End Property

    Public Shadows Property BackgroundImage() As System.Drawing.Image
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Image)

        End Set
    End Property

#End Region

#Region "Protected Overrides"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.Clear(Me.BackColor)
        DrawImage(e.Graphics)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        DestRect = New System.Drawing.Rectangle(0, 0, ClientSize.Width, ClientSize.Height)
        MyBase.OnSizeChanged(e)
    End Sub

#End Region

#Region "Public Properties"

    Public Property PanButton() As System.Windows.Forms.MouseButtons
        Get
            Return m_MouseButtons
        End Get
        Set(ByVal value As System.Windows.Forms.MouseButtons)
            m_MouseButtons = value
        End Set
    End Property

    Public Property ZoomOnMouseWheel() As Boolean
        Get
            Return m_ZoomOnMouseWheel
        End Get
        Set(ByVal value As Boolean)
            m_ZoomOnMouseWheel = value
        End Set
    End Property

    Public Property ZoomFactor() As Double
        Get
            Return m_ZoomFactor
        End Get
        Set(ByVal value As Double)
            m_ZoomFactor = value
            If m_ZoomFactor > 16 Then m_ZoomFactor = 16
            If m_ZoomFactor < 0.05 Then m_ZoomFactor = 0.05

            Me.Invalidate()
        End Set
    End Property

    Public Property Origin() As System.Drawing.Point
        Get
            Return m_Origin
        End Get
        Set(ByVal value As System.Drawing.Point)
            m_Origin = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Public Methods"

    Public Sub ShowActualSize()
        m_ZoomFactor = 1
        Me.Invalidate()
    End Sub

    Public Sub ResetImage()
        m_Origin.X = 0
        m_Origin.Y = 0
        m_ZoomFactor = 1.0
        Me.Invalidate()
    End Sub

#End Region

    Private Sub DrawImage(ByRef g As Graphics)
        If m_OriginalImage Is Nothing Then Exit Sub
        SrcRect = New System.Drawing.Rectangle(m_Origin.X, m_Origin.Y, ClientSize.Width / m_ZoomFactor, ClientSize.Height / m_ZoomFactor)
        g.DrawImage(m_OriginalImage, DestRect, SrcRect, GraphicsUnit.Pixel)
    End Sub

    Private Sub ImageViewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        m_PanStartPoint = New Point(e.X, e.Y)
        Me.Focus()
    End Sub

    Private Sub ImageViewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = m_MouseButtons Then
            Dim DeltaX As Integer = m_PanStartPoint.X - e.X
            Dim DeltaY As Integer = m_PanStartPoint.Y - e.Y

            'Set the origin of the new image
            m_Origin.X = m_Origin.X + (DeltaX / m_ZoomFactor)
            m_Origin.Y = m_Origin.Y + (DeltaY / m_ZoomFactor)

            'Make sure we don't go out of bounds
            If m_Origin.X < 0 Then m_Origin.X = 0
            If m_Origin.Y < 0 Then m_Origin.Y = 0
            If m_Origin.X > m_OriginalImage.Width - (ClientSize.Width / m_ZoomFactor) Then
                m_Origin.X = m_OriginalImage.Width - (ClientSize.Width / m_ZoomFactor)
            End If
            If m_Origin.Y > m_OriginalImage.Height - (ClientSize.Height / m_ZoomFactor) Then
                m_Origin.Y = m_OriginalImage.Height - (ClientSize.Height / m_ZoomFactor)
            End If

            If m_Origin.X < 0 Then m_Origin.X = 0
            If m_Origin.Y < 0 Then m_Origin.Y = 0

            'reset the startpoints
            m_PanStartPoint.X = e.X
            m_PanStartPoint.Y = e.Y

            'Force a paint
            Me.Invalidate()
        End If
    End Sub

    Private Sub ImageViewer_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        If Not ZoomOnMouseWheel Then Exit Sub
        If e.Delta > 0 Then
            ZoomFactor = Math.Round(ZoomFactor * 1.1, 2)
        ElseIf e.Delta < 0 Then
            ZoomFactor = Math.Round(ZoomFactor * 0.9, 2)
        End If
    End Sub

End Class
