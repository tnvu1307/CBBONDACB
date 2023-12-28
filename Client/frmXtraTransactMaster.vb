Public Class frmXtraTransactMaster
    Inherits AppCore.frmXtraTransact

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

    'Protected Overrides Sub SetLookUpDataForm()
    '    mv_frmSearchScreen = New frmSearchMaster(Me.UserLanguage)
    '    Me.mv_frmCFAUTH = New frmCFAUTH
    '    mv_frmCFAUTH.UserLanguage = Me.UserLanguage
    '    Me.mv_frmCFMAST = New frmCFMAST_bk
    '    mv_frmCFMAST.UserLanguage = Me.UserLanguage
    '    Me.mv_frmCFRELATION = New frmCFRELATION
    '    mv_frmCFRELATION.UserLanguage = Me.UserLanguage


    'End Sub

    'Private Sub frmXtraTransactMaster_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
    '    Select Case e.KeyCode
    '        Case Keys.F9
    '            If Me.ObjectName = "9314" Then 'Xu ly dac biet cho user SB check
    '                Dim v_strType As String = GetControlValueByName("05")
    '                If v_strType = "PP" Then
    '                    Using v_frmFAPRICEPOLICY As New frmFAPRICEPOLICY
    '                        v_frmFAPRICEPOLICY.ExeFlag = CommonLibrary.ExecuteFlag.View
    '                        v_frmFAPRICEPOLICY.UserLanguage = UserLanguage
    '                        v_frmFAPRICEPOLICY.ModuleCode = "FA"
    '                        v_frmFAPRICEPOLICY.ObjectName = "FA.FAPRICEPOLICY"
    '                        v_frmFAPRICEPOLICY.TableName = "FAPRICEPOLICY"
    '                        v_frmFAPRICEPOLICY.LocalObject = "N"
    '                        v_frmFAPRICEPOLICY.Text = "Price policy" 'Lay tu resource
    '                        v_frmFAPRICEPOLICY.TellerId = TellerId
    '                        v_frmFAPRICEPOLICY.BranchId = BranchId
    '                        v_frmFAPRICEPOLICY.BusDate = Me.BusDate
    '                        v_frmFAPRICEPOLICY.KeyFieldName = "POLICYCODE"
    '                        v_frmFAPRICEPOLICY.KeyFieldType = "C"
    '                        v_frmFAPRICEPOLICY.KeyFieldValue = GetControlValueByName("01")
    '                        v_frmFAPRICEPOLICY.ShowDialog()
    '                    End Using
    '                End If
    '            End If
    '    End Select
    'End Sub
End Class
