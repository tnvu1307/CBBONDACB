Imports CommonLibrary
Imports System.Windows.Forms

Public Class frmProcessing
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProcessing))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.SystemColors.Window
        Me.lblMsg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(72, 21)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(272, 23)
        Me.lblMsg.TabIndex = 1
        Me.lblMsg.Text = "Processing..."
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmProcessing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(350, 64)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProcessing"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constants and varriables declaration "
    Const c_RESOURCE_MANAGER = "AppCore.frmProcessing-"

    Private mv_strAppLang As String
    Private mv_processType As ProcessType
#End Region

#Region " Properties "
    Public Property UserLanguage() As String
        Get
            Return mv_strAppLang
        End Get
        Set(ByVal Value As String)
            mv_strAppLang = Value
        End Set
    End Property

    Public Property ProcessType() As ProcessType
        Get
            Return mv_processType
        End Get
        Set(ByVal Value As ProcessType)
            mv_processType = Value
        End Set
    End Property
#End Region

#Region " Public methods "
    Public Sub InitDialog()
        Try
            Dim v_resourceManager As New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

            Select Case ProcessType
                Case ProcessType.BatchProcess
                    lblMsg.Text = v_resourceManager.GetString("BATCH_PROCESSING")
                Case ProcessType.ReportProcess
                    lblMsg.Text = v_resourceManager.GetString("REPORT_PROCESSING")
                Case ProcessType.ExportProcess
                    lblMsg.Text = v_resourceManager.GetString("EXPORT_PROCESSING")
                Case ProcessType.SendEmailProcess
                    lblMsg.Text = v_resourceManager.GetString("SENDEMAIL_PROCESSING")
                Case ProcessType.Processing
                    lblMsg.Text = v_resourceManager.GetString("PROCESSING")
            End Select
        Catch ex As Exception
            LogError.Write("Error source: frmProcessing.InitDialog" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class
