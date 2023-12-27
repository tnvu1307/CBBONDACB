Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReportView
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Private mv_RptFilename As String
    Private mv_RptName As String
#End Region

#Region " Properties "
    Public Property RptFileName() As String
        Get
            Return mv_RptFilename
        End Get
        Set(ByVal Value As String)
            mv_RptFilename = Value
        End Set
    End Property

    Public Property RptName() As String
        Get
            Return mv_RptName
        End Get
        Set(ByVal Value As String)
            mv_RptName = Value
        End Set
    End Property
#End Region

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
    Public WithEvents cRptView As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cRptView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'cRptView
        '
        Me.cRptView.ActiveViewIndex = -1
        Me.cRptView.DisplayGroupTree = False
        Me.cRptView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cRptView.Location = New System.Drawing.Point(0, 0)
        Me.cRptView.Name = "cRptView"
        Me.cRptView.ReportSource = Nothing
        Me.cRptView.Size = New System.Drawing.Size(792, 573)
        Me.cRptView.TabIndex = 0
        '
        'frmReportView
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.cRptView)
        Me.Name = "frmReportView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportView"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"
    Private Sub frmReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.RptName
        ShowReport()
        Me.cRptView.ShowCloseButton = False
        Me.cRptView.ShowRefreshButton = False
    End Sub
#End Region

#Region "Other method"
    Private Sub ShowReport()
        Try
            Dim v_oRpt As New ReportDocument

            v_oRpt.Load(Me.mv_RptFilename)
            Me.cRptView.ReportSource = v_oRpt
            Me.cRptView.Show()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

End Class
