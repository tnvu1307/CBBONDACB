Imports System.Drawing

Public Class frmSignature
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents picSign As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picSign = New System.Windows.Forms.PictureBox
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picSign
        '
        Me.picSign.Location = New System.Drawing.Point(0, 0)
        Me.picSign.Name = "picSign"
        Me.picSign.Size = New System.Drawing.Size(208, 176)
        Me.picSign.TabIndex = 0
        Me.picSign.TabStop = False
        '
        'frmSignature
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(317, 248)
        Me.Controls.Add(Me.picSign)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignature"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mv_imgSign As Image

    Public Property ImageSign() As Image
        Get
            Return mv_imgSign
        End Get
        Set(ByVal Value As Image)
            mv_imgSign = Value
        End Set
    End Property

    Private Sub frmSignature_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        picSign.Size = Me.Size
        picSign.Image = mv_imgSign
    End Sub

End Class
