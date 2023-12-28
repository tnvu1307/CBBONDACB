Public Class frmTransactMaster
    Inherits AppCore.frmTransact

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)

        MyBase.New(pv_strLanguage)
        'MyBase.New()
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Protected Overrides Sub SetLookUpDataForm()
        mv_frmSearchScreen = New frmSearchMaster(Me.UserLanguage)
    End Sub
End Class
