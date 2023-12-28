Imports AppCore
Imports CommonLibrary
Imports System.Drawing

Public Class frmCalendar
    Inherits System.Windows.Forms.Form

#Region "Declare variables and constants"
    Const c_ResourceManager = gc_RootNamespace & ".frmCalendar-"

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Const c_FIRSTDATE = 1
    Const c_CLDRTYPE = "000"
    Dim c_CLDRTYPESB As String
    Private mv_strCLEARDAY As String()
    Private mv_strSCHEDULETYPE As String()
    Private mv_strHOLIDAY As String()
    Friend WithEvents CobRef As AppCore.ComboBoxEx
    Private mv_strDATE As String()
    Friend WithEvents ToolTipSB As System.Windows.Forms.ToolTip
    Private mv_strSBEOP As String()
	
	Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String

    Private mv_arrBatchCmd() As String

    Private mv_strBranchId As String
    Private mv_strTellerId As String

    Private mv_strLocalObject As String

#End Region

#Region "Properties"
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property
	
	    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        OnInit()

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents pnMonth1 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_1 As System.Windows.Forms.Label
    Friend WithEvents pnMonth2 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_2 As System.Windows.Forms.Label
    Friend WithEvents pnMonth3 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_3 As System.Windows.Forms.Label
    Friend WithEvents pnMonth4 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_4 As System.Windows.Forms.Label
    Friend WithEvents pnMonth5 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_5 As System.Windows.Forms.Label
    Friend WithEvents pnMonth6 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_6 As System.Windows.Forms.Label
    Friend WithEvents pnMonth7 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_7 As System.Windows.Forms.Label
    Friend WithEvents pnMonth8 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_8 As System.Windows.Forms.Label
    Friend WithEvents pnMonth9 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_9 As System.Windows.Forms.Label
    Friend WithEvents pnMonth10 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_10 As System.Windows.Forms.Label
    Friend WithEvents pnMonth11 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_11 As System.Windows.Forms.Label
    Friend WithEvents pnMonth12 As System.Windows.Forms.Panel
    Friend WithEvents lbl1_12 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lbl3_1 As System.Windows.Forms.Label
    Friend WithEvents lbl2_1 As System.Windows.Forms.Label
    Friend WithEvents lbl3_2 As System.Windows.Forms.Label
    Friend WithEvents lbl2_2 As System.Windows.Forms.Label
    Friend WithEvents lbl3_3 As System.Windows.Forms.Label
    Friend WithEvents lbl2_3 As System.Windows.Forms.Label
    Friend WithEvents lbl3_4 As System.Windows.Forms.Label
    Friend WithEvents lbl2_4 As System.Windows.Forms.Label
    Friend WithEvents lbl3_5 As System.Windows.Forms.Label
    Friend WithEvents lbl2_5 As System.Windows.Forms.Label
    Friend WithEvents lbl3_6 As System.Windows.Forms.Label
    Friend WithEvents lbl2_6 As System.Windows.Forms.Label
    Friend WithEvents lbl3_7 As System.Windows.Forms.Label
    Friend WithEvents lbl2_7 As System.Windows.Forms.Label
    Friend WithEvents lbl3_8 As System.Windows.Forms.Label
    Friend WithEvents lbl2_8 As System.Windows.Forms.Label
    Friend WithEvents lbl3_9 As System.Windows.Forms.Label
    Friend WithEvents lbl2_9 As System.Windows.Forms.Label
    Friend WithEvents lbl3_10 As System.Windows.Forms.Label
    Friend WithEvents lbl2_10 As System.Windows.Forms.Label
    Friend WithEvents lbl3_11 As System.Windows.Forms.Label
    Friend WithEvents lbl2_11 As System.Windows.Forms.Label
    Friend WithEvents lbl3_12 As System.Windows.Forms.Label
    Friend WithEvents lbl2_12 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_1_1 As System.Windows.Forms.Label
    Friend WithEvents lbl6_1 As System.Windows.Forms.Label
    Friend WithEvents lbl5_1 As System.Windows.Forms.Label
    Friend WithEvents lbl4_1 As System.Windows.Forms.Label
    Friend WithEvents lbl6_2 As System.Windows.Forms.Label
    Friend WithEvents lbl5_2 As System.Windows.Forms.Label
    Friend WithEvents lbl4_2 As System.Windows.Forms.Label
    Friend WithEvents lbl6_3 As System.Windows.Forms.Label
    Friend WithEvents lbl5_3 As System.Windows.Forms.Label
    Friend WithEvents lbl4_3 As System.Windows.Forms.Label
    Friend WithEvents lbl6_4 As System.Windows.Forms.Label
    Friend WithEvents lbl5_4 As System.Windows.Forms.Label
    Friend WithEvents lbl4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_1_1 As System.Windows.Forms.Label
    Friend WithEvents lbl6_5 As System.Windows.Forms.Label
    Friend WithEvents lbl5_5 As System.Windows.Forms.Label
    Friend WithEvents lbl4_5 As System.Windows.Forms.Label
    Friend WithEvents lbl6_6 As System.Windows.Forms.Label
    Friend WithEvents lbl5_6 As System.Windows.Forms.Label
    Friend WithEvents lbl4_6 As System.Windows.Forms.Label
    Friend WithEvents lbl6_7 As System.Windows.Forms.Label
    Friend WithEvents lbl5_7 As System.Windows.Forms.Label
    Friend WithEvents lbl4_7 As System.Windows.Forms.Label
    Friend WithEvents lbl6_8 As System.Windows.Forms.Label
    Friend WithEvents lbl5_8 As System.Windows.Forms.Label
    Friend WithEvents lbl4_8 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_1_1 As System.Windows.Forms.Label
    Friend WithEvents lbl6_9 As System.Windows.Forms.Label
    Friend WithEvents lbl5_9 As System.Windows.Forms.Label
    Friend WithEvents lbl4_9 As System.Windows.Forms.Label
    Friend WithEvents lbl6_10 As System.Windows.Forms.Label
    Friend WithEvents lbl5_10 As System.Windows.Forms.Label
    Friend WithEvents lbl4_10 As System.Windows.Forms.Label
    Friend WithEvents lbl6_11 As System.Windows.Forms.Label
    Friend WithEvents lbl5_11 As System.Windows.Forms.Label
    Friend WithEvents lbl4_11 As System.Windows.Forms.Label
    Friend WithEvents lbl6_12 As System.Windows.Forms.Label
    Friend WithEvents lbl5_12 As System.Windows.Forms.Label
    Friend WithEvents lbl4_12 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_1_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_2_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_1 As System.Windows.Forms.Label
    Friend WithEvents lbl7_1 As System.Windows.Forms.Label
    Friend WithEvents lbl7_2 As System.Windows.Forms.Label
    Friend WithEvents lbl7_3 As System.Windows.Forms.Label
    Friend WithEvents lbl7_4 As System.Windows.Forms.Label
    Friend WithEvents lbl7_5 As System.Windows.Forms.Label
    Friend WithEvents lbl7_6 As System.Windows.Forms.Label
    Friend WithEvents lbl7_7 As System.Windows.Forms.Label
    Friend WithEvents lbl7_8 As System.Windows.Forms.Label
    Friend WithEvents lbl7_9 As System.Windows.Forms.Label
    Friend WithEvents lbl7_10 As System.Windows.Forms.Label
    Friend WithEvents lbl7_11 As System.Windows.Forms.Label
    Friend WithEvents lbl7_12 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_3_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_4_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_5_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_6_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay1_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay2_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay4_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay5_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay6_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay7_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay8_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay9_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay10_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay11_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_1 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_6 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_5 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_4 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_3 As System.Windows.Forms.Label
    Friend WithEvents lblDay12_7_2 As System.Windows.Forms.Label
    Friend WithEvents lblDay3_1_4 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmSetup As System.Windows.Forms.ContextMenu
    Friend WithEvents lblMonthJan As System.Windows.Forms.Label
    Friend WithEvents lblMonthFeb As System.Windows.Forms.Label
    Friend WithEvents lblMonthMar As System.Windows.Forms.Label
    Friend WithEvents lblMonthApr As System.Windows.Forms.Label
    Friend WithEvents lblMonthMay As System.Windows.Forms.Label
    Friend WithEvents lblMonthJun As System.Windows.Forms.Label
    Friend WithEvents lblMonthJul As System.Windows.Forms.Label
    Friend WithEvents lblMonthAug As System.Windows.Forms.Label
    Friend WithEvents lblMonthSep As System.Windows.Forms.Label
    Friend WithEvents lblMonthOct As System.Windows.Forms.Label
    Friend WithEvents lblMonthNov As System.Windows.Forms.Label
    Friend WithEvents lblMonthDec As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalendar))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.pnMonth1 = New System.Windows.Forms.Panel
        Me.lblDay1_7_6 = New System.Windows.Forms.Label
        Me.lblDay1_6_6 = New System.Windows.Forms.Label
        Me.lblDay1_5_6 = New System.Windows.Forms.Label
        Me.lblDay1_4_6 = New System.Windows.Forms.Label
        Me.lblDay1_3_6 = New System.Windows.Forms.Label
        Me.lblDay1_2_6 = New System.Windows.Forms.Label
        Me.lblDay1_1_6 = New System.Windows.Forms.Label
        Me.lblDay1_7_5 = New System.Windows.Forms.Label
        Me.lblDay1_6_5 = New System.Windows.Forms.Label
        Me.lblDay1_5_5 = New System.Windows.Forms.Label
        Me.lblDay1_4_5 = New System.Windows.Forms.Label
        Me.lblDay1_3_5 = New System.Windows.Forms.Label
        Me.lblDay1_2_5 = New System.Windows.Forms.Label
        Me.lblDay1_1_5 = New System.Windows.Forms.Label
        Me.lblDay1_7_4 = New System.Windows.Forms.Label
        Me.lblDay1_6_4 = New System.Windows.Forms.Label
        Me.lblDay1_5_4 = New System.Windows.Forms.Label
        Me.lblDay1_4_4 = New System.Windows.Forms.Label
        Me.lblDay1_3_4 = New System.Windows.Forms.Label
        Me.lblDay1_2_4 = New System.Windows.Forms.Label
        Me.lblDay1_1_4 = New System.Windows.Forms.Label
        Me.lblDay1_7_3 = New System.Windows.Forms.Label
        Me.lblDay1_6_3 = New System.Windows.Forms.Label
        Me.lblDay1_5_3 = New System.Windows.Forms.Label
        Me.lblDay1_4_3 = New System.Windows.Forms.Label
        Me.lblDay1_3_3 = New System.Windows.Forms.Label
        Me.lblDay1_2_3 = New System.Windows.Forms.Label
        Me.lblDay1_1_3 = New System.Windows.Forms.Label
        Me.lblDay1_7_2 = New System.Windows.Forms.Label
        Me.lblDay1_6_2 = New System.Windows.Forms.Label
        Me.lblDay1_5_2 = New System.Windows.Forms.Label
        Me.lblDay1_4_2 = New System.Windows.Forms.Label
        Me.lblDay1_3_2 = New System.Windows.Forms.Label
        Me.lblDay1_2_2 = New System.Windows.Forms.Label
        Me.lblDay1_1_2 = New System.Windows.Forms.Label
        Me.lblDay1_7_1 = New System.Windows.Forms.Label
        Me.lblDay1_6_1 = New System.Windows.Forms.Label
        Me.lblDay1_5_1 = New System.Windows.Forms.Label
        Me.lblDay1_4_1 = New System.Windows.Forms.Label
        Me.lblDay1_3_1 = New System.Windows.Forms.Label
        Me.lblDay1_2_1 = New System.Windows.Forms.Label
        Me.lblDay1_1_1 = New System.Windows.Forms.Label
        Me.lbl7_1 = New System.Windows.Forms.Label
        Me.lbl6_1 = New System.Windows.Forms.Label
        Me.lbl5_1 = New System.Windows.Forms.Label
        Me.lbl4_1 = New System.Windows.Forms.Label
        Me.lbl3_1 = New System.Windows.Forms.Label
        Me.lbl2_1 = New System.Windows.Forms.Label
        Me.lbl1_1 = New System.Windows.Forms.Label
        Me.lblMonthJan = New System.Windows.Forms.Label
        Me.pnMonth2 = New System.Windows.Forms.Panel
        Me.lblDay2_7_6 = New System.Windows.Forms.Label
        Me.lblDay2_6_6 = New System.Windows.Forms.Label
        Me.lblDay2_5_6 = New System.Windows.Forms.Label
        Me.lblDay2_4_6 = New System.Windows.Forms.Label
        Me.lblDay2_3_6 = New System.Windows.Forms.Label
        Me.lblDay2_2_6 = New System.Windows.Forms.Label
        Me.lblDay2_1_6 = New System.Windows.Forms.Label
        Me.lblDay2_7_5 = New System.Windows.Forms.Label
        Me.lblDay2_6_5 = New System.Windows.Forms.Label
        Me.lblDay2_5_5 = New System.Windows.Forms.Label
        Me.lblDay2_4_5 = New System.Windows.Forms.Label
        Me.lblDay2_3_5 = New System.Windows.Forms.Label
        Me.lblDay2_2_5 = New System.Windows.Forms.Label
        Me.lblDay2_1_5 = New System.Windows.Forms.Label
        Me.lblDay2_7_4 = New System.Windows.Forms.Label
        Me.lblDay2_6_4 = New System.Windows.Forms.Label
        Me.lblDay2_5_4 = New System.Windows.Forms.Label
        Me.lblDay2_4_4 = New System.Windows.Forms.Label
        Me.lblDay2_3_4 = New System.Windows.Forms.Label
        Me.lblDay2_2_4 = New System.Windows.Forms.Label
        Me.lblDay2_1_4 = New System.Windows.Forms.Label
        Me.lblDay2_7_3 = New System.Windows.Forms.Label
        Me.lblDay2_6_3 = New System.Windows.Forms.Label
        Me.lblDay2_5_3 = New System.Windows.Forms.Label
        Me.lblDay2_4_3 = New System.Windows.Forms.Label
        Me.lblDay2_3_3 = New System.Windows.Forms.Label
        Me.lblDay2_2_3 = New System.Windows.Forms.Label
        Me.lblDay2_1_3 = New System.Windows.Forms.Label
        Me.lblDay2_7_2 = New System.Windows.Forms.Label
        Me.lblDay2_6_2 = New System.Windows.Forms.Label
        Me.lblDay2_5_2 = New System.Windows.Forms.Label
        Me.lblDay2_4_2 = New System.Windows.Forms.Label
        Me.lblDay2_3_2 = New System.Windows.Forms.Label
        Me.lblDay2_2_2 = New System.Windows.Forms.Label
        Me.lblDay2_1_2 = New System.Windows.Forms.Label
        Me.lblDay2_7_1 = New System.Windows.Forms.Label
        Me.lblDay2_6_1 = New System.Windows.Forms.Label
        Me.lblDay2_5_1 = New System.Windows.Forms.Label
        Me.lblDay2_4_1 = New System.Windows.Forms.Label
        Me.lblDay2_3_1 = New System.Windows.Forms.Label
        Me.lblDay2_2_1 = New System.Windows.Forms.Label
        Me.lblDay2_1_1 = New System.Windows.Forms.Label
        Me.lbl7_2 = New System.Windows.Forms.Label
        Me.lbl6_2 = New System.Windows.Forms.Label
        Me.lbl5_2 = New System.Windows.Forms.Label
        Me.lbl4_2 = New System.Windows.Forms.Label
        Me.lbl3_2 = New System.Windows.Forms.Label
        Me.lbl2_2 = New System.Windows.Forms.Label
        Me.lbl1_2 = New System.Windows.Forms.Label
        Me.lblMonthFeb = New System.Windows.Forms.Label
        Me.pnMonth3 = New System.Windows.Forms.Panel
        Me.lblDay3_1_4 = New System.Windows.Forms.Label
        Me.lblDay3_7_6 = New System.Windows.Forms.Label
        Me.lblDay3_6_6 = New System.Windows.Forms.Label
        Me.lblDay3_5_6 = New System.Windows.Forms.Label
        Me.lblDay3_4_6 = New System.Windows.Forms.Label
        Me.lblDay3_3_6 = New System.Windows.Forms.Label
        Me.lblDay3_2_6 = New System.Windows.Forms.Label
        Me.lblDay3_1_6 = New System.Windows.Forms.Label
        Me.lblDay3_7_5 = New System.Windows.Forms.Label
        Me.lblDay3_6_5 = New System.Windows.Forms.Label
        Me.lblDay3_5_5 = New System.Windows.Forms.Label
        Me.lblDay3_4_5 = New System.Windows.Forms.Label
        Me.lblDay3_3_5 = New System.Windows.Forms.Label
        Me.lblDay3_2_5 = New System.Windows.Forms.Label
        Me.lblDay3_1_5 = New System.Windows.Forms.Label
        Me.lblDay3_7_4 = New System.Windows.Forms.Label
        Me.lblDay3_6_4 = New System.Windows.Forms.Label
        Me.lblDay3_5_4 = New System.Windows.Forms.Label
        Me.lblDay3_4_4 = New System.Windows.Forms.Label
        Me.lblDay3_3_4 = New System.Windows.Forms.Label
        Me.lblDay3_2_4 = New System.Windows.Forms.Label
        Me.lblDay3_7_3 = New System.Windows.Forms.Label
        Me.lblDay3_6_3 = New System.Windows.Forms.Label
        Me.lblDay3_5_3 = New System.Windows.Forms.Label
        Me.lblDay3_4_3 = New System.Windows.Forms.Label
        Me.lblDay3_3_3 = New System.Windows.Forms.Label
        Me.lblDay3_2_3 = New System.Windows.Forms.Label
        Me.lblDay3_1_3 = New System.Windows.Forms.Label
        Me.lblDay3_7_2 = New System.Windows.Forms.Label
        Me.lblDay3_6_2 = New System.Windows.Forms.Label
        Me.lblDay3_5_2 = New System.Windows.Forms.Label
        Me.lblDay3_4_2 = New System.Windows.Forms.Label
        Me.lblDay3_3_2 = New System.Windows.Forms.Label
        Me.lblDay3_2_2 = New System.Windows.Forms.Label
        Me.lblDay3_1_2 = New System.Windows.Forms.Label
        Me.lblDay3_7_1 = New System.Windows.Forms.Label
        Me.lblDay3_6_1 = New System.Windows.Forms.Label
        Me.lblDay3_5_1 = New System.Windows.Forms.Label
        Me.lblDay3_4_1 = New System.Windows.Forms.Label
        Me.lblDay3_3_1 = New System.Windows.Forms.Label
        Me.lblDay3_2_1 = New System.Windows.Forms.Label
        Me.lblDay3_1_1 = New System.Windows.Forms.Label
        Me.lbl7_3 = New System.Windows.Forms.Label
        Me.lbl6_3 = New System.Windows.Forms.Label
        Me.lbl5_3 = New System.Windows.Forms.Label
        Me.lbl4_3 = New System.Windows.Forms.Label
        Me.lbl3_3 = New System.Windows.Forms.Label
        Me.lbl2_3 = New System.Windows.Forms.Label
        Me.lbl1_3 = New System.Windows.Forms.Label
        Me.lblMonthMar = New System.Windows.Forms.Label
        Me.pnMonth4 = New System.Windows.Forms.Panel
        Me.lblDay4_7_6 = New System.Windows.Forms.Label
        Me.lblDay4_6_6 = New System.Windows.Forms.Label
        Me.lblDay4_5_6 = New System.Windows.Forms.Label
        Me.lblDay4_4_6 = New System.Windows.Forms.Label
        Me.lblDay4_3_6 = New System.Windows.Forms.Label
        Me.lblDay4_2_6 = New System.Windows.Forms.Label
        Me.lblDay4_1_6 = New System.Windows.Forms.Label
        Me.lblDay4_7_5 = New System.Windows.Forms.Label
        Me.lblDay4_6_5 = New System.Windows.Forms.Label
        Me.lblDay4_5_5 = New System.Windows.Forms.Label
        Me.lblDay4_4_5 = New System.Windows.Forms.Label
        Me.lblDay4_3_5 = New System.Windows.Forms.Label
        Me.lblDay4_2_5 = New System.Windows.Forms.Label
        Me.lblDay4_1_5 = New System.Windows.Forms.Label
        Me.lblDay4_7_4 = New System.Windows.Forms.Label
        Me.lblDay4_6_4 = New System.Windows.Forms.Label
        Me.lblDay4_5_4 = New System.Windows.Forms.Label
        Me.lblDay4_4_4 = New System.Windows.Forms.Label
        Me.lblDay4_3_4 = New System.Windows.Forms.Label
        Me.lblDay4_2_4 = New System.Windows.Forms.Label
        Me.lblDay4_1_4 = New System.Windows.Forms.Label
        Me.lblDay4_7_3 = New System.Windows.Forms.Label
        Me.lblDay4_6_3 = New System.Windows.Forms.Label
        Me.lblDay4_5_3 = New System.Windows.Forms.Label
        Me.lblDay4_4_3 = New System.Windows.Forms.Label
        Me.lblDay4_3_3 = New System.Windows.Forms.Label
        Me.lblDay4_2_3 = New System.Windows.Forms.Label
        Me.lblDay4_1_3 = New System.Windows.Forms.Label
        Me.lblDay4_7_2 = New System.Windows.Forms.Label
        Me.lblDay4_6_2 = New System.Windows.Forms.Label
        Me.lblDay4_5_2 = New System.Windows.Forms.Label
        Me.lblDay4_4_2 = New System.Windows.Forms.Label
        Me.lblDay4_3_2 = New System.Windows.Forms.Label
        Me.lblDay4_2_2 = New System.Windows.Forms.Label
        Me.lblDay4_1_2 = New System.Windows.Forms.Label
        Me.lblDay4_7_1 = New System.Windows.Forms.Label
        Me.lblDay4_6_1 = New System.Windows.Forms.Label
        Me.lblDay4_5_1 = New System.Windows.Forms.Label
        Me.lblDay4_4_1 = New System.Windows.Forms.Label
        Me.lblDay4_3_1 = New System.Windows.Forms.Label
        Me.lblDay4_2_1 = New System.Windows.Forms.Label
        Me.lblDay4_1_1 = New System.Windows.Forms.Label
        Me.lbl7_4 = New System.Windows.Forms.Label
        Me.lbl6_4 = New System.Windows.Forms.Label
        Me.lbl5_4 = New System.Windows.Forms.Label
        Me.lbl4_4 = New System.Windows.Forms.Label
        Me.lbl3_4 = New System.Windows.Forms.Label
        Me.lbl2_4 = New System.Windows.Forms.Label
        Me.lbl1_4 = New System.Windows.Forms.Label
        Me.lblMonthApr = New System.Windows.Forms.Label
        Me.pnMonth5 = New System.Windows.Forms.Panel
        Me.lblDay5_7_6 = New System.Windows.Forms.Label
        Me.lblDay5_6_6 = New System.Windows.Forms.Label
        Me.lblDay5_5_6 = New System.Windows.Forms.Label
        Me.lblDay5_4_6 = New System.Windows.Forms.Label
        Me.lblDay5_3_6 = New System.Windows.Forms.Label
        Me.lblDay5_2_6 = New System.Windows.Forms.Label
        Me.lblDay5_1_6 = New System.Windows.Forms.Label
        Me.lblDay5_7_5 = New System.Windows.Forms.Label
        Me.lblDay5_6_5 = New System.Windows.Forms.Label
        Me.lblDay5_5_5 = New System.Windows.Forms.Label
        Me.lblDay5_4_5 = New System.Windows.Forms.Label
        Me.lblDay5_3_5 = New System.Windows.Forms.Label
        Me.lblDay5_2_5 = New System.Windows.Forms.Label
        Me.lblDay5_1_5 = New System.Windows.Forms.Label
        Me.lblDay5_7_4 = New System.Windows.Forms.Label
        Me.lblDay5_6_4 = New System.Windows.Forms.Label
        Me.lblDay5_5_4 = New System.Windows.Forms.Label
        Me.lblDay5_4_4 = New System.Windows.Forms.Label
        Me.lblDay5_3_4 = New System.Windows.Forms.Label
        Me.lblDay5_2_4 = New System.Windows.Forms.Label
        Me.lblDay5_1_4 = New System.Windows.Forms.Label
        Me.lblDay5_7_3 = New System.Windows.Forms.Label
        Me.lblDay5_6_3 = New System.Windows.Forms.Label
        Me.lblDay5_5_3 = New System.Windows.Forms.Label
        Me.lblDay5_4_3 = New System.Windows.Forms.Label
        Me.lblDay5_3_3 = New System.Windows.Forms.Label
        Me.lblDay5_2_3 = New System.Windows.Forms.Label
        Me.lblDay5_1_3 = New System.Windows.Forms.Label
        Me.lblDay5_7_2 = New System.Windows.Forms.Label
        Me.lblDay5_6_2 = New System.Windows.Forms.Label
        Me.lblDay5_5_2 = New System.Windows.Forms.Label
        Me.lblDay5_4_2 = New System.Windows.Forms.Label
        Me.lblDay5_3_2 = New System.Windows.Forms.Label
        Me.lblDay5_2_2 = New System.Windows.Forms.Label
        Me.lblDay5_1_2 = New System.Windows.Forms.Label
        Me.lblDay5_7_1 = New System.Windows.Forms.Label
        Me.lblDay5_6_1 = New System.Windows.Forms.Label
        Me.lblDay5_5_1 = New System.Windows.Forms.Label
        Me.lblDay5_4_1 = New System.Windows.Forms.Label
        Me.lblDay5_3_1 = New System.Windows.Forms.Label
        Me.lblDay5_2_1 = New System.Windows.Forms.Label
        Me.lblDay5_1_1 = New System.Windows.Forms.Label
        Me.lbl7_5 = New System.Windows.Forms.Label
        Me.lbl6_5 = New System.Windows.Forms.Label
        Me.lbl5_5 = New System.Windows.Forms.Label
        Me.lbl4_5 = New System.Windows.Forms.Label
        Me.lbl3_5 = New System.Windows.Forms.Label
        Me.lbl2_5 = New System.Windows.Forms.Label
        Me.lbl1_5 = New System.Windows.Forms.Label
        Me.lblMonthMay = New System.Windows.Forms.Label
        Me.pnMonth6 = New System.Windows.Forms.Panel
        Me.lblDay6_7_6 = New System.Windows.Forms.Label
        Me.lblDay6_6_6 = New System.Windows.Forms.Label
        Me.lblDay6_5_6 = New System.Windows.Forms.Label
        Me.lblDay6_4_6 = New System.Windows.Forms.Label
        Me.lblDay6_3_6 = New System.Windows.Forms.Label
        Me.lblDay6_2_6 = New System.Windows.Forms.Label
        Me.lblDay6_1_6 = New System.Windows.Forms.Label
        Me.lblDay6_7_5 = New System.Windows.Forms.Label
        Me.lblDay6_6_5 = New System.Windows.Forms.Label
        Me.lblDay6_5_5 = New System.Windows.Forms.Label
        Me.lblDay6_4_5 = New System.Windows.Forms.Label
        Me.lblDay6_3_5 = New System.Windows.Forms.Label
        Me.lblDay6_2_5 = New System.Windows.Forms.Label
        Me.lblDay6_1_5 = New System.Windows.Forms.Label
        Me.lblDay6_7_4 = New System.Windows.Forms.Label
        Me.lblDay6_6_4 = New System.Windows.Forms.Label
        Me.lblDay6_5_4 = New System.Windows.Forms.Label
        Me.lblDay6_4_4 = New System.Windows.Forms.Label
        Me.lblDay6_3_4 = New System.Windows.Forms.Label
        Me.lblDay6_2_4 = New System.Windows.Forms.Label
        Me.lblDay6_1_4 = New System.Windows.Forms.Label
        Me.lblDay6_7_3 = New System.Windows.Forms.Label
        Me.lblDay6_6_3 = New System.Windows.Forms.Label
        Me.lblDay6_5_3 = New System.Windows.Forms.Label
        Me.lblDay6_4_3 = New System.Windows.Forms.Label
        Me.lblDay6_3_3 = New System.Windows.Forms.Label
        Me.lblDay6_2_3 = New System.Windows.Forms.Label
        Me.lblDay6_1_3 = New System.Windows.Forms.Label
        Me.lblDay6_7_2 = New System.Windows.Forms.Label
        Me.lblDay6_6_2 = New System.Windows.Forms.Label
        Me.lblDay6_5_2 = New System.Windows.Forms.Label
        Me.lblDay6_4_2 = New System.Windows.Forms.Label
        Me.lblDay6_3_2 = New System.Windows.Forms.Label
        Me.lblDay6_2_2 = New System.Windows.Forms.Label
        Me.lblDay6_1_2 = New System.Windows.Forms.Label
        Me.lblDay6_7_1 = New System.Windows.Forms.Label
        Me.lblDay6_6_1 = New System.Windows.Forms.Label
        Me.lblDay6_5_1 = New System.Windows.Forms.Label
        Me.lblDay6_4_1 = New System.Windows.Forms.Label
        Me.lblDay6_3_1 = New System.Windows.Forms.Label
        Me.lblDay6_2_1 = New System.Windows.Forms.Label
        Me.lblDay6_1_1 = New System.Windows.Forms.Label
        Me.lbl7_6 = New System.Windows.Forms.Label
        Me.lbl6_6 = New System.Windows.Forms.Label
        Me.lbl5_6 = New System.Windows.Forms.Label
        Me.lbl4_6 = New System.Windows.Forms.Label
        Me.lbl3_6 = New System.Windows.Forms.Label
        Me.lbl2_6 = New System.Windows.Forms.Label
        Me.lbl1_6 = New System.Windows.Forms.Label
        Me.lblMonthJun = New System.Windows.Forms.Label
        Me.pnMonth7 = New System.Windows.Forms.Panel
        Me.lblDay7_7_6 = New System.Windows.Forms.Label
        Me.lblDay7_6_6 = New System.Windows.Forms.Label
        Me.lblDay7_5_6 = New System.Windows.Forms.Label
        Me.lblDay7_4_6 = New System.Windows.Forms.Label
        Me.lblDay7_3_6 = New System.Windows.Forms.Label
        Me.lblDay7_2_6 = New System.Windows.Forms.Label
        Me.lblDay7_1_6 = New System.Windows.Forms.Label
        Me.lblDay7_7_5 = New System.Windows.Forms.Label
        Me.lblDay7_6_5 = New System.Windows.Forms.Label
        Me.lblDay7_5_5 = New System.Windows.Forms.Label
        Me.lblDay7_4_5 = New System.Windows.Forms.Label
        Me.lblDay7_3_5 = New System.Windows.Forms.Label
        Me.lblDay7_2_5 = New System.Windows.Forms.Label
        Me.lblDay7_1_5 = New System.Windows.Forms.Label
        Me.lblDay7_7_4 = New System.Windows.Forms.Label
        Me.lblDay7_6_4 = New System.Windows.Forms.Label
        Me.lblDay7_5_4 = New System.Windows.Forms.Label
        Me.lblDay7_4_4 = New System.Windows.Forms.Label
        Me.lblDay7_3_4 = New System.Windows.Forms.Label
        Me.lblDay7_2_4 = New System.Windows.Forms.Label
        Me.lblDay7_1_4 = New System.Windows.Forms.Label
        Me.lblDay7_7_3 = New System.Windows.Forms.Label
        Me.lblDay7_6_3 = New System.Windows.Forms.Label
        Me.lblDay7_5_3 = New System.Windows.Forms.Label
        Me.lblDay7_4_3 = New System.Windows.Forms.Label
        Me.lblDay7_3_3 = New System.Windows.Forms.Label
        Me.lblDay7_2_3 = New System.Windows.Forms.Label
        Me.lblDay7_1_3 = New System.Windows.Forms.Label
        Me.lblDay7_7_2 = New System.Windows.Forms.Label
        Me.lblDay7_6_2 = New System.Windows.Forms.Label
        Me.lblDay7_5_2 = New System.Windows.Forms.Label
        Me.lblDay7_4_2 = New System.Windows.Forms.Label
        Me.lblDay7_3_2 = New System.Windows.Forms.Label
        Me.lblDay7_2_2 = New System.Windows.Forms.Label
        Me.lblDay7_1_2 = New System.Windows.Forms.Label
        Me.lblDay7_7_1 = New System.Windows.Forms.Label
        Me.lblDay7_6_1 = New System.Windows.Forms.Label
        Me.lblDay7_5_1 = New System.Windows.Forms.Label
        Me.lblDay7_4_1 = New System.Windows.Forms.Label
        Me.lblDay7_3_1 = New System.Windows.Forms.Label
        Me.lblDay7_2_1 = New System.Windows.Forms.Label
        Me.lblDay7_1_1 = New System.Windows.Forms.Label
        Me.lbl7_7 = New System.Windows.Forms.Label
        Me.lbl6_7 = New System.Windows.Forms.Label
        Me.lbl5_7 = New System.Windows.Forms.Label
        Me.lbl4_7 = New System.Windows.Forms.Label
        Me.lbl3_7 = New System.Windows.Forms.Label
        Me.lbl2_7 = New System.Windows.Forms.Label
        Me.lbl1_7 = New System.Windows.Forms.Label
        Me.lblMonthJul = New System.Windows.Forms.Label
        Me.pnMonth8 = New System.Windows.Forms.Panel
        Me.lblDay8_7_6 = New System.Windows.Forms.Label
        Me.lblDay8_6_6 = New System.Windows.Forms.Label
        Me.lblDay8_5_6 = New System.Windows.Forms.Label
        Me.lblDay8_4_6 = New System.Windows.Forms.Label
        Me.lblDay8_3_6 = New System.Windows.Forms.Label
        Me.lblDay8_2_6 = New System.Windows.Forms.Label
        Me.lblDay8_1_6 = New System.Windows.Forms.Label
        Me.lblDay8_7_5 = New System.Windows.Forms.Label
        Me.lblDay8_6_5 = New System.Windows.Forms.Label
        Me.lblDay8_5_5 = New System.Windows.Forms.Label
        Me.lblDay8_4_5 = New System.Windows.Forms.Label
        Me.lblDay8_3_5 = New System.Windows.Forms.Label
        Me.lblDay8_2_5 = New System.Windows.Forms.Label
        Me.lblDay8_1_5 = New System.Windows.Forms.Label
        Me.lblDay8_7_4 = New System.Windows.Forms.Label
        Me.lblDay8_6_4 = New System.Windows.Forms.Label
        Me.lblDay8_5_4 = New System.Windows.Forms.Label
        Me.lblDay8_4_4 = New System.Windows.Forms.Label
        Me.lblDay8_3_4 = New System.Windows.Forms.Label
        Me.lblDay8_2_4 = New System.Windows.Forms.Label
        Me.lblDay8_1_4 = New System.Windows.Forms.Label
        Me.lblDay8_7_3 = New System.Windows.Forms.Label
        Me.lblDay8_6_3 = New System.Windows.Forms.Label
        Me.lblDay8_5_3 = New System.Windows.Forms.Label
        Me.lblDay8_4_3 = New System.Windows.Forms.Label
        Me.lblDay8_3_3 = New System.Windows.Forms.Label
        Me.lblDay8_2_3 = New System.Windows.Forms.Label
        Me.lblDay8_1_3 = New System.Windows.Forms.Label
        Me.lblDay8_7_2 = New System.Windows.Forms.Label
        Me.lblDay8_6_2 = New System.Windows.Forms.Label
        Me.lblDay8_5_2 = New System.Windows.Forms.Label
        Me.lblDay8_4_2 = New System.Windows.Forms.Label
        Me.lblDay8_3_2 = New System.Windows.Forms.Label
        Me.lblDay8_2_2 = New System.Windows.Forms.Label
        Me.lblDay8_1_2 = New System.Windows.Forms.Label
        Me.lblDay8_7_1 = New System.Windows.Forms.Label
        Me.lblDay8_6_1 = New System.Windows.Forms.Label
        Me.lblDay8_5_1 = New System.Windows.Forms.Label
        Me.lblDay8_4_1 = New System.Windows.Forms.Label
        Me.lblDay8_3_1 = New System.Windows.Forms.Label
        Me.lblDay8_2_1 = New System.Windows.Forms.Label
        Me.lblDay8_1_1 = New System.Windows.Forms.Label
        Me.lbl7_8 = New System.Windows.Forms.Label
        Me.lbl6_8 = New System.Windows.Forms.Label
        Me.lbl5_8 = New System.Windows.Forms.Label
        Me.lbl4_8 = New System.Windows.Forms.Label
        Me.lbl3_8 = New System.Windows.Forms.Label
        Me.lbl2_8 = New System.Windows.Forms.Label
        Me.lbl1_8 = New System.Windows.Forms.Label
        Me.lblMonthAug = New System.Windows.Forms.Label
        Me.pnMonth9 = New System.Windows.Forms.Panel
        Me.lblDay9_7_6 = New System.Windows.Forms.Label
        Me.lblDay9_6_6 = New System.Windows.Forms.Label
        Me.lblDay9_5_6 = New System.Windows.Forms.Label
        Me.lblDay9_4_6 = New System.Windows.Forms.Label
        Me.lblDay9_3_6 = New System.Windows.Forms.Label
        Me.lblDay9_2_6 = New System.Windows.Forms.Label
        Me.lblDay9_1_6 = New System.Windows.Forms.Label
        Me.lblDay9_7_5 = New System.Windows.Forms.Label
        Me.lblDay9_6_5 = New System.Windows.Forms.Label
        Me.lblDay9_5_5 = New System.Windows.Forms.Label
        Me.lblDay9_4_5 = New System.Windows.Forms.Label
        Me.lblDay9_3_5 = New System.Windows.Forms.Label
        Me.lblDay9_2_5 = New System.Windows.Forms.Label
        Me.lblDay9_1_5 = New System.Windows.Forms.Label
        Me.lblDay9_7_4 = New System.Windows.Forms.Label
        Me.lblDay9_6_4 = New System.Windows.Forms.Label
        Me.lblDay9_5_4 = New System.Windows.Forms.Label
        Me.lblDay9_4_4 = New System.Windows.Forms.Label
        Me.lblDay9_3_4 = New System.Windows.Forms.Label
        Me.lblDay9_2_4 = New System.Windows.Forms.Label
        Me.lblDay9_1_4 = New System.Windows.Forms.Label
        Me.lblDay9_7_3 = New System.Windows.Forms.Label
        Me.lblDay9_6_3 = New System.Windows.Forms.Label
        Me.lblDay9_5_3 = New System.Windows.Forms.Label
        Me.lblDay9_4_3 = New System.Windows.Forms.Label
        Me.lblDay9_3_3 = New System.Windows.Forms.Label
        Me.lblDay9_2_3 = New System.Windows.Forms.Label
        Me.lblDay9_1_3 = New System.Windows.Forms.Label
        Me.lblDay9_7_2 = New System.Windows.Forms.Label
        Me.lblDay9_6_2 = New System.Windows.Forms.Label
        Me.lblDay9_5_2 = New System.Windows.Forms.Label
        Me.lblDay9_4_2 = New System.Windows.Forms.Label
        Me.lblDay9_3_2 = New System.Windows.Forms.Label
        Me.lblDay9_2_2 = New System.Windows.Forms.Label
        Me.lblDay9_1_2 = New System.Windows.Forms.Label
        Me.lblDay9_7_1 = New System.Windows.Forms.Label
        Me.lblDay9_6_1 = New System.Windows.Forms.Label
        Me.lblDay9_5_1 = New System.Windows.Forms.Label
        Me.lblDay9_4_1 = New System.Windows.Forms.Label
        Me.lblDay9_3_1 = New System.Windows.Forms.Label
        Me.lblDay9_2_1 = New System.Windows.Forms.Label
        Me.lblDay9_1_1 = New System.Windows.Forms.Label
        Me.lbl7_9 = New System.Windows.Forms.Label
        Me.lbl6_9 = New System.Windows.Forms.Label
        Me.lbl5_9 = New System.Windows.Forms.Label
        Me.lbl4_9 = New System.Windows.Forms.Label
        Me.lbl3_9 = New System.Windows.Forms.Label
        Me.lbl2_9 = New System.Windows.Forms.Label
        Me.lbl1_9 = New System.Windows.Forms.Label
        Me.lblMonthSep = New System.Windows.Forms.Label
        Me.pnMonth10 = New System.Windows.Forms.Panel
        Me.lblDay10_7_6 = New System.Windows.Forms.Label
        Me.lblDay10_6_6 = New System.Windows.Forms.Label
        Me.lblDay10_5_6 = New System.Windows.Forms.Label
        Me.lblDay10_4_6 = New System.Windows.Forms.Label
        Me.lblDay10_3_6 = New System.Windows.Forms.Label
        Me.lblDay10_2_6 = New System.Windows.Forms.Label
        Me.lblDay10_1_6 = New System.Windows.Forms.Label
        Me.lblDay10_7_5 = New System.Windows.Forms.Label
        Me.lblDay10_6_5 = New System.Windows.Forms.Label
        Me.lblDay10_5_5 = New System.Windows.Forms.Label
        Me.lblDay10_4_5 = New System.Windows.Forms.Label
        Me.lblDay10_3_5 = New System.Windows.Forms.Label
        Me.lblDay10_2_5 = New System.Windows.Forms.Label
        Me.lblDay10_1_5 = New System.Windows.Forms.Label
        Me.lblDay10_7_4 = New System.Windows.Forms.Label
        Me.lblDay10_6_4 = New System.Windows.Forms.Label
        Me.lblDay10_5_4 = New System.Windows.Forms.Label
        Me.lblDay10_4_4 = New System.Windows.Forms.Label
        Me.lblDay10_3_4 = New System.Windows.Forms.Label
        Me.lblDay10_2_4 = New System.Windows.Forms.Label
        Me.lblDay10_1_4 = New System.Windows.Forms.Label
        Me.lblDay10_7_3 = New System.Windows.Forms.Label
        Me.lblDay10_6_3 = New System.Windows.Forms.Label
        Me.lblDay10_5_3 = New System.Windows.Forms.Label
        Me.lblDay10_4_3 = New System.Windows.Forms.Label
        Me.lblDay10_3_3 = New System.Windows.Forms.Label
        Me.lblDay10_2_3 = New System.Windows.Forms.Label
        Me.lblDay10_1_3 = New System.Windows.Forms.Label
        Me.lblDay10_7_2 = New System.Windows.Forms.Label
        Me.lblDay10_6_2 = New System.Windows.Forms.Label
        Me.lblDay10_5_2 = New System.Windows.Forms.Label
        Me.lblDay10_4_2 = New System.Windows.Forms.Label
        Me.lblDay10_3_2 = New System.Windows.Forms.Label
        Me.lblDay10_2_2 = New System.Windows.Forms.Label
        Me.lblDay10_1_2 = New System.Windows.Forms.Label
        Me.lblDay10_7_1 = New System.Windows.Forms.Label
        Me.lblDay10_6_1 = New System.Windows.Forms.Label
        Me.lblDay10_5_1 = New System.Windows.Forms.Label
        Me.lblDay10_4_1 = New System.Windows.Forms.Label
        Me.lblDay10_3_1 = New System.Windows.Forms.Label
        Me.lblDay10_2_1 = New System.Windows.Forms.Label
        Me.lblDay10_1_1 = New System.Windows.Forms.Label
        Me.lbl7_10 = New System.Windows.Forms.Label
        Me.lbl6_10 = New System.Windows.Forms.Label
        Me.lbl5_10 = New System.Windows.Forms.Label
        Me.lbl4_10 = New System.Windows.Forms.Label
        Me.lbl3_10 = New System.Windows.Forms.Label
        Me.lbl2_10 = New System.Windows.Forms.Label
        Me.lbl1_10 = New System.Windows.Forms.Label
        Me.lblMonthOct = New System.Windows.Forms.Label
        Me.pnMonth11 = New System.Windows.Forms.Panel
        Me.lblDay11_7_6 = New System.Windows.Forms.Label
        Me.lblDay11_6_6 = New System.Windows.Forms.Label
        Me.lblDay11_5_6 = New System.Windows.Forms.Label
        Me.lblDay11_4_6 = New System.Windows.Forms.Label
        Me.lblDay11_3_6 = New System.Windows.Forms.Label
        Me.lblDay11_2_6 = New System.Windows.Forms.Label
        Me.lblDay11_1_6 = New System.Windows.Forms.Label
        Me.lblDay11_7_5 = New System.Windows.Forms.Label
        Me.lblDay11_6_5 = New System.Windows.Forms.Label
        Me.lblDay11_5_5 = New System.Windows.Forms.Label
        Me.lblDay11_4_5 = New System.Windows.Forms.Label
        Me.lblDay11_3_5 = New System.Windows.Forms.Label
        Me.lblDay11_2_5 = New System.Windows.Forms.Label
        Me.lblDay11_1_5 = New System.Windows.Forms.Label
        Me.lblDay11_7_4 = New System.Windows.Forms.Label
        Me.lblDay11_6_4 = New System.Windows.Forms.Label
        Me.lblDay11_5_4 = New System.Windows.Forms.Label
        Me.lblDay11_4_4 = New System.Windows.Forms.Label
        Me.lblDay11_3_4 = New System.Windows.Forms.Label
        Me.lblDay11_2_4 = New System.Windows.Forms.Label
        Me.lblDay11_1_4 = New System.Windows.Forms.Label
        Me.lblDay11_7_3 = New System.Windows.Forms.Label
        Me.lblDay11_6_3 = New System.Windows.Forms.Label
        Me.lblDay11_5_3 = New System.Windows.Forms.Label
        Me.lblDay11_4_3 = New System.Windows.Forms.Label
        Me.lblDay11_3_3 = New System.Windows.Forms.Label
        Me.lblDay11_2_3 = New System.Windows.Forms.Label
        Me.lblDay11_1_3 = New System.Windows.Forms.Label
        Me.lblDay11_7_2 = New System.Windows.Forms.Label
        Me.lblDay11_6_2 = New System.Windows.Forms.Label
        Me.lblDay11_5_2 = New System.Windows.Forms.Label
        Me.lblDay11_4_2 = New System.Windows.Forms.Label
        Me.lblDay11_3_2 = New System.Windows.Forms.Label
        Me.lblDay11_2_2 = New System.Windows.Forms.Label
        Me.lblDay11_1_2 = New System.Windows.Forms.Label
        Me.lblDay11_7_1 = New System.Windows.Forms.Label
        Me.lblDay11_6_1 = New System.Windows.Forms.Label
        Me.lblDay11_5_1 = New System.Windows.Forms.Label
        Me.lblDay11_4_1 = New System.Windows.Forms.Label
        Me.lblDay11_3_1 = New System.Windows.Forms.Label
        Me.lblDay11_2_1 = New System.Windows.Forms.Label
        Me.lblDay11_1_1 = New System.Windows.Forms.Label
        Me.lbl7_11 = New System.Windows.Forms.Label
        Me.lbl6_11 = New System.Windows.Forms.Label
        Me.lbl5_11 = New System.Windows.Forms.Label
        Me.lbl4_11 = New System.Windows.Forms.Label
        Me.lbl3_11 = New System.Windows.Forms.Label
        Me.lbl2_11 = New System.Windows.Forms.Label
        Me.lbl1_11 = New System.Windows.Forms.Label
        Me.lblMonthNov = New System.Windows.Forms.Label
        Me.pnMonth12 = New System.Windows.Forms.Panel
        Me.lblDay12_7_6 = New System.Windows.Forms.Label
        Me.lblDay12_6_6 = New System.Windows.Forms.Label
        Me.lblDay12_5_6 = New System.Windows.Forms.Label
        Me.lblDay12_4_6 = New System.Windows.Forms.Label
        Me.lblDay12_3_6 = New System.Windows.Forms.Label
        Me.lblDay12_2_6 = New System.Windows.Forms.Label
        Me.lblDay12_1_6 = New System.Windows.Forms.Label
        Me.lblDay12_7_5 = New System.Windows.Forms.Label
        Me.lblDay12_6_5 = New System.Windows.Forms.Label
        Me.lblDay12_5_5 = New System.Windows.Forms.Label
        Me.lblDay12_4_5 = New System.Windows.Forms.Label
        Me.lblDay12_3_5 = New System.Windows.Forms.Label
        Me.lblDay12_2_5 = New System.Windows.Forms.Label
        Me.lblDay12_1_5 = New System.Windows.Forms.Label
        Me.lblDay12_7_4 = New System.Windows.Forms.Label
        Me.lblDay12_6_4 = New System.Windows.Forms.Label
        Me.lblDay12_5_4 = New System.Windows.Forms.Label
        Me.lblDay12_4_4 = New System.Windows.Forms.Label
        Me.lblDay12_3_4 = New System.Windows.Forms.Label
        Me.lblDay12_2_4 = New System.Windows.Forms.Label
        Me.lblDay12_1_4 = New System.Windows.Forms.Label
        Me.lblDay12_7_3 = New System.Windows.Forms.Label
        Me.lblDay12_6_3 = New System.Windows.Forms.Label
        Me.lblDay12_5_3 = New System.Windows.Forms.Label
        Me.lblDay12_4_3 = New System.Windows.Forms.Label
        Me.lblDay12_3_3 = New System.Windows.Forms.Label
        Me.lblDay12_2_3 = New System.Windows.Forms.Label
        Me.lblDay12_1_3 = New System.Windows.Forms.Label
        Me.lblDay12_7_2 = New System.Windows.Forms.Label
        Me.lblDay12_6_2 = New System.Windows.Forms.Label
        Me.lblDay12_5_2 = New System.Windows.Forms.Label
        Me.lblDay12_4_2 = New System.Windows.Forms.Label
        Me.lblDay12_3_2 = New System.Windows.Forms.Label
        Me.lblDay12_2_2 = New System.Windows.Forms.Label
        Me.lblDay12_1_2 = New System.Windows.Forms.Label
        Me.lblDay12_7_1 = New System.Windows.Forms.Label
        Me.lblDay12_6_1 = New System.Windows.Forms.Label
        Me.lblDay12_5_1 = New System.Windows.Forms.Label
        Me.lblDay12_4_1 = New System.Windows.Forms.Label
        Me.lblDay12_3_1 = New System.Windows.Forms.Label
        Me.lblDay12_2_1 = New System.Windows.Forms.Label
        Me.lblDay12_1_1 = New System.Windows.Forms.Label
        Me.lbl7_12 = New System.Windows.Forms.Label
        Me.lbl6_12 = New System.Windows.Forms.Label
        Me.lbl5_12 = New System.Windows.Forms.Label
        Me.lbl4_12 = New System.Windows.Forms.Label
        Me.lbl3_12 = New System.Windows.Forms.Label
        Me.lbl2_12 = New System.Windows.Forms.Label
        Me.lbl1_12 = New System.Windows.Forms.Label
        Me.lblMonthDec = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.cmSetup = New System.Windows.Forms.ContextMenu
        Me.CobRef = New AppCore.ComboBoxEx
        Me.ToolTipSB = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.pnMonth1.SuspendLayout()
        Me.pnMonth2.SuspendLayout()
        Me.pnMonth3.SuspendLayout()
        Me.pnMonth4.SuspendLayout()
        Me.pnMonth5.SuspendLayout()
        Me.pnMonth6.SuspendLayout()
        Me.pnMonth7.SuspendLayout()
        Me.pnMonth8.SuspendLayout()
        Me.pnMonth9.SuspendLayout()
        Me.pnMonth10.SuspendLayout()
        Me.pnMonth11.SuspendLayout()
        Me.pnMonth12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 50)
        Me.Panel1.TabIndex = 9
        '
        'lblCaption
        '
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(776, 16)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'pnMonth1
        '
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_6)
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_5)
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_4)
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_3)
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_2)
        Me.pnMonth1.Controls.Add(Me.lblDay1_7_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_6_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_5_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_4_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_3_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_2_1)
        Me.pnMonth1.Controls.Add(Me.lblDay1_1_1)
        Me.pnMonth1.Controls.Add(Me.lbl7_1)
        Me.pnMonth1.Controls.Add(Me.lbl6_1)
        Me.pnMonth1.Controls.Add(Me.lbl5_1)
        Me.pnMonth1.Controls.Add(Me.lbl4_1)
        Me.pnMonth1.Controls.Add(Me.lbl3_1)
        Me.pnMonth1.Controls.Add(Me.lbl2_1)
        Me.pnMonth1.Controls.Add(Me.lbl1_1)
        Me.pnMonth1.Controls.Add(Me.lblMonthJan)
        Me.pnMonth1.Location = New System.Drawing.Point(0, 88)
        Me.pnMonth1.Name = "pnMonth1"
        Me.pnMonth1.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth1.TabIndex = 10
        '
        'lblDay1_7_6
        '
        Me.lblDay1_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay1_7_6.Name = "lblDay1_7_6"
        Me.lblDay1_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_6.TabIndex = 49
        Me.lblDay1_7_6.Tag = "42"
        '
        'lblDay1_6_6
        '
        Me.lblDay1_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay1_6_6.Name = "lblDay1_6_6"
        Me.lblDay1_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_6.TabIndex = 48
        Me.lblDay1_6_6.Tag = "41"
        '
        'lblDay1_5_6
        '
        Me.lblDay1_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay1_5_6.Name = "lblDay1_5_6"
        Me.lblDay1_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_6.TabIndex = 47
        Me.lblDay1_5_6.Tag = "40"
        '
        'lblDay1_4_6
        '
        Me.lblDay1_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay1_4_6.Name = "lblDay1_4_6"
        Me.lblDay1_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_6.TabIndex = 46
        Me.lblDay1_4_6.Tag = "39"
        '
        'lblDay1_3_6
        '
        Me.lblDay1_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay1_3_6.Name = "lblDay1_3_6"
        Me.lblDay1_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_6.TabIndex = 45
        Me.lblDay1_3_6.Tag = "38"
        '
        'lblDay1_2_6
        '
        Me.lblDay1_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay1_2_6.Name = "lblDay1_2_6"
        Me.lblDay1_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_6.TabIndex = 44
        Me.lblDay1_2_6.Tag = "37"
        '
        'lblDay1_1_6
        '
        Me.lblDay1_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay1_1_6.Name = "lblDay1_1_6"
        Me.lblDay1_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_6.TabIndex = 43
        Me.lblDay1_1_6.Tag = "36"
        '
        'lblDay1_7_5
        '
        Me.lblDay1_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay1_7_5.Name = "lblDay1_7_5"
        Me.lblDay1_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_5.TabIndex = 42
        Me.lblDay1_7_5.Tag = "35"
        '
        'lblDay1_6_5
        '
        Me.lblDay1_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay1_6_5.Name = "lblDay1_6_5"
        Me.lblDay1_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_5.TabIndex = 41
        Me.lblDay1_6_5.Tag = "34"
        '
        'lblDay1_5_5
        '
        Me.lblDay1_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay1_5_5.Name = "lblDay1_5_5"
        Me.lblDay1_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_5.TabIndex = 40
        Me.lblDay1_5_5.Tag = "33"
        '
        'lblDay1_4_5
        '
        Me.lblDay1_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay1_4_5.Name = "lblDay1_4_5"
        Me.lblDay1_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_5.TabIndex = 39
        Me.lblDay1_4_5.Tag = "32"
        '
        'lblDay1_3_5
        '
        Me.lblDay1_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay1_3_5.Name = "lblDay1_3_5"
        Me.lblDay1_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_5.TabIndex = 38
        Me.lblDay1_3_5.Tag = "31"
        '
        'lblDay1_2_5
        '
        Me.lblDay1_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay1_2_5.Name = "lblDay1_2_5"
        Me.lblDay1_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_5.TabIndex = 37
        Me.lblDay1_2_5.Tag = "30"
        '
        'lblDay1_1_5
        '
        Me.lblDay1_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay1_1_5.Name = "lblDay1_1_5"
        Me.lblDay1_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_5.TabIndex = 36
        Me.lblDay1_1_5.Tag = "29"
        '
        'lblDay1_7_4
        '
        Me.lblDay1_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay1_7_4.Name = "lblDay1_7_4"
        Me.lblDay1_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_4.TabIndex = 35
        Me.lblDay1_7_4.Tag = "28"
        '
        'lblDay1_6_4
        '
        Me.lblDay1_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay1_6_4.Name = "lblDay1_6_4"
        Me.lblDay1_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_4.TabIndex = 34
        Me.lblDay1_6_4.Tag = "27"
        '
        'lblDay1_5_4
        '
        Me.lblDay1_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay1_5_4.Name = "lblDay1_5_4"
        Me.lblDay1_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_4.TabIndex = 33
        Me.lblDay1_5_4.Tag = "26"
        '
        'lblDay1_4_4
        '
        Me.lblDay1_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay1_4_4.Name = "lblDay1_4_4"
        Me.lblDay1_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_4.TabIndex = 32
        Me.lblDay1_4_4.Tag = "25"
        '
        'lblDay1_3_4
        '
        Me.lblDay1_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay1_3_4.Name = "lblDay1_3_4"
        Me.lblDay1_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_4.TabIndex = 31
        Me.lblDay1_3_4.Tag = "24"
        '
        'lblDay1_2_4
        '
        Me.lblDay1_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay1_2_4.Name = "lblDay1_2_4"
        Me.lblDay1_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_4.TabIndex = 30
        Me.lblDay1_2_4.Tag = "23"
        '
        'lblDay1_1_4
        '
        Me.lblDay1_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay1_1_4.Name = "lblDay1_1_4"
        Me.lblDay1_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_4.TabIndex = 29
        Me.lblDay1_1_4.Tag = "22"
        '
        'lblDay1_7_3
        '
        Me.lblDay1_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay1_7_3.Name = "lblDay1_7_3"
        Me.lblDay1_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_3.TabIndex = 28
        Me.lblDay1_7_3.Tag = "21"
        '
        'lblDay1_6_3
        '
        Me.lblDay1_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay1_6_3.Name = "lblDay1_6_3"
        Me.lblDay1_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_3.TabIndex = 27
        Me.lblDay1_6_3.Tag = "20"
        '
        'lblDay1_5_3
        '
        Me.lblDay1_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay1_5_3.Name = "lblDay1_5_3"
        Me.lblDay1_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_3.TabIndex = 26
        Me.lblDay1_5_3.Tag = "19"
        '
        'lblDay1_4_3
        '
        Me.lblDay1_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay1_4_3.Name = "lblDay1_4_3"
        Me.lblDay1_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_3.TabIndex = 25
        Me.lblDay1_4_3.Tag = "18"
        '
        'lblDay1_3_3
        '
        Me.lblDay1_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay1_3_3.Name = "lblDay1_3_3"
        Me.lblDay1_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_3.TabIndex = 24
        Me.lblDay1_3_3.Tag = "17"
        '
        'lblDay1_2_3
        '
        Me.lblDay1_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay1_2_3.Name = "lblDay1_2_3"
        Me.lblDay1_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_3.TabIndex = 23
        Me.lblDay1_2_3.Tag = "16"
        '
        'lblDay1_1_3
        '
        Me.lblDay1_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay1_1_3.Name = "lblDay1_1_3"
        Me.lblDay1_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_3.TabIndex = 22
        Me.lblDay1_1_3.Tag = "15"
        '
        'lblDay1_7_2
        '
        Me.lblDay1_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay1_7_2.Name = "lblDay1_7_2"
        Me.lblDay1_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_2.TabIndex = 21
        Me.lblDay1_7_2.Tag = "14"
        '
        'lblDay1_6_2
        '
        Me.lblDay1_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay1_6_2.Name = "lblDay1_6_2"
        Me.lblDay1_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_2.TabIndex = 20
        Me.lblDay1_6_2.Tag = "13"
        '
        'lblDay1_5_2
        '
        Me.lblDay1_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay1_5_2.Name = "lblDay1_5_2"
        Me.lblDay1_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_2.TabIndex = 19
        Me.lblDay1_5_2.Tag = "12"
        '
        'lblDay1_4_2
        '
        Me.lblDay1_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay1_4_2.Name = "lblDay1_4_2"
        Me.lblDay1_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_2.TabIndex = 18
        Me.lblDay1_4_2.Tag = "11"
        '
        'lblDay1_3_2
        '
        Me.lblDay1_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay1_3_2.Name = "lblDay1_3_2"
        Me.lblDay1_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_2.TabIndex = 17
        Me.lblDay1_3_2.Tag = "10"
        '
        'lblDay1_2_2
        '
        Me.lblDay1_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay1_2_2.Name = "lblDay1_2_2"
        Me.lblDay1_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_2.TabIndex = 16
        Me.lblDay1_2_2.Tag = "9"
        '
        'lblDay1_1_2
        '
        Me.lblDay1_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay1_1_2.Name = "lblDay1_1_2"
        Me.lblDay1_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_2.TabIndex = 15
        Me.lblDay1_1_2.Tag = "8"
        '
        'lblDay1_7_1
        '
        Me.lblDay1_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay1_7_1.Name = "lblDay1_7_1"
        Me.lblDay1_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_7_1.TabIndex = 14
        Me.lblDay1_7_1.Tag = "7"
        '
        'lblDay1_6_1
        '
        Me.lblDay1_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay1_6_1.Name = "lblDay1_6_1"
        Me.lblDay1_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_6_1.TabIndex = 13
        Me.lblDay1_6_1.Tag = "6"
        '
        'lblDay1_5_1
        '
        Me.lblDay1_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay1_5_1.Name = "lblDay1_5_1"
        Me.lblDay1_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_5_1.TabIndex = 12
        Me.lblDay1_5_1.Tag = "5"
        '
        'lblDay1_4_1
        '
        Me.lblDay1_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay1_4_1.Name = "lblDay1_4_1"
        Me.lblDay1_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_4_1.TabIndex = 11
        Me.lblDay1_4_1.Tag = "4"
        '
        'lblDay1_3_1
        '
        Me.lblDay1_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay1_3_1.Name = "lblDay1_3_1"
        Me.lblDay1_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_3_1.TabIndex = 10
        Me.lblDay1_3_1.Tag = "3"
        '
        'lblDay1_2_1
        '
        Me.lblDay1_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay1_2_1.Name = "lblDay1_2_1"
        Me.lblDay1_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_2_1.TabIndex = 9
        Me.lblDay1_2_1.Tag = "2"
        '
        'lblDay1_1_1
        '
        Me.lblDay1_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay1_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay1_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay1_1_1.Name = "lblDay1_1_1"
        Me.lblDay1_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay1_1_1.TabIndex = 8
        Me.lblDay1_1_1.Tag = "1"
        '
        'lbl7_1
        '
        Me.lbl7_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_1.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_1.Name = "lbl7_1"
        Me.lbl7_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_1.TabIndex = 7
        Me.lbl7_1.Text = "Sat"
        Me.lbl7_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_1
        '
        Me.lbl6_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_1.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_1.Name = "lbl6_1"
        Me.lbl6_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_1.TabIndex = 6
        Me.lbl6_1.Text = "Fri"
        Me.lbl6_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_1
        '
        Me.lbl5_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_1.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_1.Name = "lbl5_1"
        Me.lbl5_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_1.TabIndex = 5
        Me.lbl5_1.Text = "Thu"
        Me.lbl5_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_1
        '
        Me.lbl4_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_1.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_1.Name = "lbl4_1"
        Me.lbl4_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_1.TabIndex = 4
        Me.lbl4_1.Text = "Wed"
        Me.lbl4_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_1
        '
        Me.lbl3_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_1.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_1.Name = "lbl3_1"
        Me.lbl3_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_1.TabIndex = 3
        Me.lbl3_1.Text = "Tue"
        Me.lbl3_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_1
        '
        Me.lbl2_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_1.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_1.Name = "lbl2_1"
        Me.lbl2_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_1.TabIndex = 2
        Me.lbl2_1.Text = "Mon"
        Me.lbl2_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_1
        '
        Me.lbl1_1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_1.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_1.Name = "lbl1_1"
        Me.lbl1_1.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_1.TabIndex = 1
        Me.lbl1_1.Text = "Sun"
        Me.lbl1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthJan
        '
        Me.lblMonthJan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthJan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMonthJan.Location = New System.Drawing.Point(80, 8)
        Me.lblMonthJan.Name = "lblMonthJan"
        Me.lblMonthJan.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthJan.TabIndex = 0
        Me.lblMonthJan.Text = "January"
        Me.lblMonthJan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth2
        '
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_6)
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_5)
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_4)
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_3)
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_2)
        Me.pnMonth2.Controls.Add(Me.lblDay2_7_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_6_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_5_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_4_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_3_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_2_1)
        Me.pnMonth2.Controls.Add(Me.lblDay2_1_1)
        Me.pnMonth2.Controls.Add(Me.lbl7_2)
        Me.pnMonth2.Controls.Add(Me.lbl6_2)
        Me.pnMonth2.Controls.Add(Me.lbl5_2)
        Me.pnMonth2.Controls.Add(Me.lbl4_2)
        Me.pnMonth2.Controls.Add(Me.lbl3_2)
        Me.pnMonth2.Controls.Add(Me.lbl2_2)
        Me.pnMonth2.Controls.Add(Me.lbl1_2)
        Me.pnMonth2.Controls.Add(Me.lblMonthFeb)
        Me.pnMonth2.Location = New System.Drawing.Point(232, 88)
        Me.pnMonth2.Name = "pnMonth2"
        Me.pnMonth2.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth2.TabIndex = 11
        '
        'lblDay2_7_6
        '
        Me.lblDay2_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay2_7_6.Name = "lblDay2_7_6"
        Me.lblDay2_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_6.TabIndex = 49
        Me.lblDay2_7_6.Tag = "42"
        '
        'lblDay2_6_6
        '
        Me.lblDay2_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay2_6_6.Name = "lblDay2_6_6"
        Me.lblDay2_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_6.TabIndex = 48
        Me.lblDay2_6_6.Tag = "41"
        '
        'lblDay2_5_6
        '
        Me.lblDay2_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay2_5_6.Name = "lblDay2_5_6"
        Me.lblDay2_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_6.TabIndex = 47
        Me.lblDay2_5_6.Tag = "40"
        '
        'lblDay2_4_6
        '
        Me.lblDay2_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay2_4_6.Name = "lblDay2_4_6"
        Me.lblDay2_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_6.TabIndex = 46
        Me.lblDay2_4_6.Tag = "39"
        '
        'lblDay2_3_6
        '
        Me.lblDay2_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay2_3_6.Name = "lblDay2_3_6"
        Me.lblDay2_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_6.TabIndex = 45
        Me.lblDay2_3_6.Tag = "38"
        '
        'lblDay2_2_6
        '
        Me.lblDay2_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay2_2_6.Name = "lblDay2_2_6"
        Me.lblDay2_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_6.TabIndex = 44
        Me.lblDay2_2_6.Tag = "37"
        '
        'lblDay2_1_6
        '
        Me.lblDay2_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay2_1_6.Name = "lblDay2_1_6"
        Me.lblDay2_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_6.TabIndex = 43
        Me.lblDay2_1_6.Tag = "36"
        '
        'lblDay2_7_5
        '
        Me.lblDay2_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay2_7_5.Name = "lblDay2_7_5"
        Me.lblDay2_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_5.TabIndex = 42
        Me.lblDay2_7_5.Tag = "35"
        '
        'lblDay2_6_5
        '
        Me.lblDay2_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay2_6_5.Name = "lblDay2_6_5"
        Me.lblDay2_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_5.TabIndex = 41
        Me.lblDay2_6_5.Tag = "34"
        '
        'lblDay2_5_5
        '
        Me.lblDay2_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay2_5_5.Name = "lblDay2_5_5"
        Me.lblDay2_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_5.TabIndex = 40
        Me.lblDay2_5_5.Tag = "33"
        '
        'lblDay2_4_5
        '
        Me.lblDay2_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay2_4_5.Name = "lblDay2_4_5"
        Me.lblDay2_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_5.TabIndex = 39
        Me.lblDay2_4_5.Tag = "32"
        '
        'lblDay2_3_5
        '
        Me.lblDay2_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay2_3_5.Name = "lblDay2_3_5"
        Me.lblDay2_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_5.TabIndex = 38
        Me.lblDay2_3_5.Tag = "31"
        '
        'lblDay2_2_5
        '
        Me.lblDay2_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay2_2_5.Name = "lblDay2_2_5"
        Me.lblDay2_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_5.TabIndex = 37
        Me.lblDay2_2_5.Tag = "30"
        '
        'lblDay2_1_5
        '
        Me.lblDay2_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay2_1_5.Name = "lblDay2_1_5"
        Me.lblDay2_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_5.TabIndex = 36
        Me.lblDay2_1_5.Tag = "29"
        '
        'lblDay2_7_4
        '
        Me.lblDay2_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay2_7_4.Name = "lblDay2_7_4"
        Me.lblDay2_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_4.TabIndex = 35
        Me.lblDay2_7_4.Tag = "28"
        '
        'lblDay2_6_4
        '
        Me.lblDay2_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay2_6_4.Name = "lblDay2_6_4"
        Me.lblDay2_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_4.TabIndex = 34
        Me.lblDay2_6_4.Tag = "27"
        '
        'lblDay2_5_4
        '
        Me.lblDay2_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay2_5_4.Name = "lblDay2_5_4"
        Me.lblDay2_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_4.TabIndex = 33
        Me.lblDay2_5_4.Tag = "26"
        '
        'lblDay2_4_4
        '
        Me.lblDay2_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay2_4_4.Name = "lblDay2_4_4"
        Me.lblDay2_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_4.TabIndex = 32
        Me.lblDay2_4_4.Tag = "25"
        '
        'lblDay2_3_4
        '
        Me.lblDay2_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay2_3_4.Name = "lblDay2_3_4"
        Me.lblDay2_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_4.TabIndex = 31
        Me.lblDay2_3_4.Tag = "24"
        '
        'lblDay2_2_4
        '
        Me.lblDay2_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay2_2_4.Name = "lblDay2_2_4"
        Me.lblDay2_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_4.TabIndex = 30
        Me.lblDay2_2_4.Tag = "23"
        '
        'lblDay2_1_4
        '
        Me.lblDay2_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay2_1_4.Name = "lblDay2_1_4"
        Me.lblDay2_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_4.TabIndex = 29
        Me.lblDay2_1_4.Tag = "22"
        '
        'lblDay2_7_3
        '
        Me.lblDay2_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay2_7_3.Name = "lblDay2_7_3"
        Me.lblDay2_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_3.TabIndex = 28
        Me.lblDay2_7_3.Tag = "21"
        '
        'lblDay2_6_3
        '
        Me.lblDay2_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay2_6_3.Name = "lblDay2_6_3"
        Me.lblDay2_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_3.TabIndex = 27
        Me.lblDay2_6_3.Tag = "20"
        '
        'lblDay2_5_3
        '
        Me.lblDay2_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay2_5_3.Name = "lblDay2_5_3"
        Me.lblDay2_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_3.TabIndex = 26
        Me.lblDay2_5_3.Tag = "19"
        '
        'lblDay2_4_3
        '
        Me.lblDay2_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay2_4_3.Name = "lblDay2_4_3"
        Me.lblDay2_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_3.TabIndex = 25
        Me.lblDay2_4_3.Tag = "18"
        '
        'lblDay2_3_3
        '
        Me.lblDay2_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay2_3_3.Name = "lblDay2_3_3"
        Me.lblDay2_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_3.TabIndex = 24
        Me.lblDay2_3_3.Tag = "17"
        '
        'lblDay2_2_3
        '
        Me.lblDay2_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay2_2_3.Name = "lblDay2_2_3"
        Me.lblDay2_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_3.TabIndex = 23
        Me.lblDay2_2_3.Tag = "16"
        '
        'lblDay2_1_3
        '
        Me.lblDay2_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay2_1_3.Name = "lblDay2_1_3"
        Me.lblDay2_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_3.TabIndex = 22
        Me.lblDay2_1_3.Tag = "15"
        '
        'lblDay2_7_2
        '
        Me.lblDay2_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay2_7_2.Name = "lblDay2_7_2"
        Me.lblDay2_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_2.TabIndex = 21
        Me.lblDay2_7_2.Tag = "14"
        '
        'lblDay2_6_2
        '
        Me.lblDay2_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay2_6_2.Name = "lblDay2_6_2"
        Me.lblDay2_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_2.TabIndex = 20
        Me.lblDay2_6_2.Tag = "13"
        '
        'lblDay2_5_2
        '
        Me.lblDay2_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay2_5_2.Name = "lblDay2_5_2"
        Me.lblDay2_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_2.TabIndex = 19
        Me.lblDay2_5_2.Tag = "12"
        '
        'lblDay2_4_2
        '
        Me.lblDay2_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay2_4_2.Name = "lblDay2_4_2"
        Me.lblDay2_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_2.TabIndex = 18
        Me.lblDay2_4_2.Tag = "11"
        '
        'lblDay2_3_2
        '
        Me.lblDay2_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay2_3_2.Name = "lblDay2_3_2"
        Me.lblDay2_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_2.TabIndex = 17
        Me.lblDay2_3_2.Tag = "10"
        '
        'lblDay2_2_2
        '
        Me.lblDay2_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay2_2_2.Name = "lblDay2_2_2"
        Me.lblDay2_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_2.TabIndex = 16
        Me.lblDay2_2_2.Tag = "9"
        '
        'lblDay2_1_2
        '
        Me.lblDay2_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay2_1_2.Name = "lblDay2_1_2"
        Me.lblDay2_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_2.TabIndex = 15
        Me.lblDay2_1_2.Tag = "8"
        '
        'lblDay2_7_1
        '
        Me.lblDay2_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay2_7_1.Name = "lblDay2_7_1"
        Me.lblDay2_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_7_1.TabIndex = 14
        Me.lblDay2_7_1.Tag = "7"
        '
        'lblDay2_6_1
        '
        Me.lblDay2_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay2_6_1.Name = "lblDay2_6_1"
        Me.lblDay2_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_6_1.TabIndex = 13
        Me.lblDay2_6_1.Tag = "6"
        '
        'lblDay2_5_1
        '
        Me.lblDay2_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay2_5_1.Name = "lblDay2_5_1"
        Me.lblDay2_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_5_1.TabIndex = 12
        Me.lblDay2_5_1.Tag = "5"
        '
        'lblDay2_4_1
        '
        Me.lblDay2_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay2_4_1.Name = "lblDay2_4_1"
        Me.lblDay2_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_4_1.TabIndex = 11
        Me.lblDay2_4_1.Tag = "4"
        '
        'lblDay2_3_1
        '
        Me.lblDay2_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay2_3_1.Name = "lblDay2_3_1"
        Me.lblDay2_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_3_1.TabIndex = 10
        Me.lblDay2_3_1.Tag = "3"
        '
        'lblDay2_2_1
        '
        Me.lblDay2_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay2_2_1.Name = "lblDay2_2_1"
        Me.lblDay2_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_2_1.TabIndex = 9
        Me.lblDay2_2_1.Tag = "2"
        '
        'lblDay2_1_1
        '
        Me.lblDay2_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay2_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay2_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay2_1_1.Name = "lblDay2_1_1"
        Me.lblDay2_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay2_1_1.TabIndex = 8
        Me.lblDay2_1_1.Tag = "1"
        '
        'lbl7_2
        '
        Me.lbl7_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_2.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_2.Name = "lbl7_2"
        Me.lbl7_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_2.TabIndex = 7
        Me.lbl7_2.Text = "Sat"
        Me.lbl7_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_2
        '
        Me.lbl6_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_2.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_2.Name = "lbl6_2"
        Me.lbl6_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_2.TabIndex = 6
        Me.lbl6_2.Text = "Fri"
        Me.lbl6_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_2
        '
        Me.lbl5_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_2.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_2.Name = "lbl5_2"
        Me.lbl5_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_2.TabIndex = 5
        Me.lbl5_2.Text = "Thu"
        Me.lbl5_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_2
        '
        Me.lbl4_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_2.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_2.Name = "lbl4_2"
        Me.lbl4_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_2.TabIndex = 4
        Me.lbl4_2.Text = "Wed"
        Me.lbl4_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_2
        '
        Me.lbl3_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_2.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_2.Name = "lbl3_2"
        Me.lbl3_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_2.TabIndex = 3
        Me.lbl3_2.Text = "Tue"
        Me.lbl3_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_2
        '
        Me.lbl2_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_2.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_2.Name = "lbl2_2"
        Me.lbl2_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_2.TabIndex = 2
        Me.lbl2_2.Text = "Mon"
        Me.lbl2_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_2
        '
        Me.lbl1_2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_2.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_2.Name = "lbl1_2"
        Me.lbl1_2.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_2.TabIndex = 1
        Me.lbl1_2.Text = "Sun"
        Me.lbl1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthFeb
        '
        Me.lblMonthFeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthFeb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthFeb.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthFeb.Name = "lblMonthFeb"
        Me.lblMonthFeb.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthFeb.TabIndex = 0
        Me.lblMonthFeb.Text = "February"
        Me.lblMonthFeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth3
        '
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_6)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_5)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_4)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_3)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_2)
        Me.pnMonth3.Controls.Add(Me.lblDay3_7_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_6_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_5_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_4_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_3_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_2_1)
        Me.pnMonth3.Controls.Add(Me.lblDay3_1_1)
        Me.pnMonth3.Controls.Add(Me.lbl7_3)
        Me.pnMonth3.Controls.Add(Me.lbl6_3)
        Me.pnMonth3.Controls.Add(Me.lbl5_3)
        Me.pnMonth3.Controls.Add(Me.lbl4_3)
        Me.pnMonth3.Controls.Add(Me.lbl3_3)
        Me.pnMonth3.Controls.Add(Me.lbl2_3)
        Me.pnMonth3.Controls.Add(Me.lbl1_3)
        Me.pnMonth3.Controls.Add(Me.lblMonthMar)
        Me.pnMonth3.Location = New System.Drawing.Point(464, 88)
        Me.pnMonth3.Name = "pnMonth3"
        Me.pnMonth3.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth3.TabIndex = 12
        '
        'lblDay3_1_4
        '
        Me.lblDay3_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay3_1_4.Name = "lblDay3_1_4"
        Me.lblDay3_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_4.TabIndex = 50
        Me.lblDay3_1_4.Tag = "22"
        '
        'lblDay3_7_6
        '
        Me.lblDay3_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay3_7_6.Name = "lblDay3_7_6"
        Me.lblDay3_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_6.TabIndex = 49
        Me.lblDay3_7_6.Tag = "42"
        '
        'lblDay3_6_6
        '
        Me.lblDay3_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay3_6_6.Name = "lblDay3_6_6"
        Me.lblDay3_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_6.TabIndex = 48
        Me.lblDay3_6_6.Tag = "41"
        '
        'lblDay3_5_6
        '
        Me.lblDay3_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay3_5_6.Name = "lblDay3_5_6"
        Me.lblDay3_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_6.TabIndex = 47
        Me.lblDay3_5_6.Tag = "40"
        '
        'lblDay3_4_6
        '
        Me.lblDay3_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay3_4_6.Name = "lblDay3_4_6"
        Me.lblDay3_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_6.TabIndex = 46
        Me.lblDay3_4_6.Tag = "39"
        '
        'lblDay3_3_6
        '
        Me.lblDay3_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay3_3_6.Name = "lblDay3_3_6"
        Me.lblDay3_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_6.TabIndex = 45
        Me.lblDay3_3_6.Tag = "38"
        '
        'lblDay3_2_6
        '
        Me.lblDay3_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay3_2_6.Name = "lblDay3_2_6"
        Me.lblDay3_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_6.TabIndex = 44
        Me.lblDay3_2_6.Tag = "37"
        '
        'lblDay3_1_6
        '
        Me.lblDay3_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay3_1_6.Name = "lblDay3_1_6"
        Me.lblDay3_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_6.TabIndex = 43
        Me.lblDay3_1_6.Tag = "36"
        '
        'lblDay3_7_5
        '
        Me.lblDay3_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay3_7_5.Name = "lblDay3_7_5"
        Me.lblDay3_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_5.TabIndex = 42
        Me.lblDay3_7_5.Tag = "35"
        '
        'lblDay3_6_5
        '
        Me.lblDay3_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay3_6_5.Name = "lblDay3_6_5"
        Me.lblDay3_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_5.TabIndex = 41
        Me.lblDay3_6_5.Tag = "34"
        '
        'lblDay3_5_5
        '
        Me.lblDay3_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay3_5_5.Name = "lblDay3_5_5"
        Me.lblDay3_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_5.TabIndex = 40
        Me.lblDay3_5_5.Tag = "33"
        '
        'lblDay3_4_5
        '
        Me.lblDay3_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay3_4_5.Name = "lblDay3_4_5"
        Me.lblDay3_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_5.TabIndex = 39
        Me.lblDay3_4_5.Tag = "32"
        '
        'lblDay3_3_5
        '
        Me.lblDay3_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay3_3_5.Name = "lblDay3_3_5"
        Me.lblDay3_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_5.TabIndex = 38
        Me.lblDay3_3_5.Tag = "31"
        '
        'lblDay3_2_5
        '
        Me.lblDay3_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay3_2_5.Name = "lblDay3_2_5"
        Me.lblDay3_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_5.TabIndex = 37
        Me.lblDay3_2_5.Tag = "30"
        '
        'lblDay3_1_5
        '
        Me.lblDay3_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay3_1_5.Name = "lblDay3_1_5"
        Me.lblDay3_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_5.TabIndex = 36
        Me.lblDay3_1_5.Tag = "29"
        '
        'lblDay3_7_4
        '
        Me.lblDay3_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay3_7_4.Name = "lblDay3_7_4"
        Me.lblDay3_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_4.TabIndex = 35
        Me.lblDay3_7_4.Tag = "28"
        '
        'lblDay3_6_4
        '
        Me.lblDay3_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay3_6_4.Name = "lblDay3_6_4"
        Me.lblDay3_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_4.TabIndex = 34
        Me.lblDay3_6_4.Tag = "27"
        '
        'lblDay3_5_4
        '
        Me.lblDay3_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay3_5_4.Name = "lblDay3_5_4"
        Me.lblDay3_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_4.TabIndex = 33
        Me.lblDay3_5_4.Tag = "26"
        '
        'lblDay3_4_4
        '
        Me.lblDay3_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay3_4_4.Name = "lblDay3_4_4"
        Me.lblDay3_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_4.TabIndex = 32
        Me.lblDay3_4_4.Tag = "25"
        '
        'lblDay3_3_4
        '
        Me.lblDay3_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay3_3_4.Name = "lblDay3_3_4"
        Me.lblDay3_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_4.TabIndex = 31
        Me.lblDay3_3_4.Tag = "24"
        '
        'lblDay3_2_4
        '
        Me.lblDay3_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay3_2_4.Name = "lblDay3_2_4"
        Me.lblDay3_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_4.TabIndex = 30
        Me.lblDay3_2_4.Tag = "23"
        '
        'lblDay3_7_3
        '
        Me.lblDay3_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay3_7_3.Name = "lblDay3_7_3"
        Me.lblDay3_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_3.TabIndex = 28
        Me.lblDay3_7_3.Tag = "21"
        '
        'lblDay3_6_3
        '
        Me.lblDay3_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay3_6_3.Name = "lblDay3_6_3"
        Me.lblDay3_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_3.TabIndex = 27
        Me.lblDay3_6_3.Tag = "20"
        '
        'lblDay3_5_3
        '
        Me.lblDay3_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay3_5_3.Name = "lblDay3_5_3"
        Me.lblDay3_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_3.TabIndex = 26
        Me.lblDay3_5_3.Tag = "19"
        '
        'lblDay3_4_3
        '
        Me.lblDay3_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay3_4_3.Name = "lblDay3_4_3"
        Me.lblDay3_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_3.TabIndex = 25
        Me.lblDay3_4_3.Tag = "18"
        '
        'lblDay3_3_3
        '
        Me.lblDay3_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay3_3_3.Name = "lblDay3_3_3"
        Me.lblDay3_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_3.TabIndex = 24
        Me.lblDay3_3_3.Tag = "17"
        '
        'lblDay3_2_3
        '
        Me.lblDay3_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay3_2_3.Name = "lblDay3_2_3"
        Me.lblDay3_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_3.TabIndex = 23
        Me.lblDay3_2_3.Tag = "16"
        '
        'lblDay3_1_3
        '
        Me.lblDay3_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay3_1_3.Name = "lblDay3_1_3"
        Me.lblDay3_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_3.TabIndex = 22
        Me.lblDay3_1_3.Tag = "15"
        '
        'lblDay3_7_2
        '
        Me.lblDay3_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay3_7_2.Name = "lblDay3_7_2"
        Me.lblDay3_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_2.TabIndex = 21
        Me.lblDay3_7_2.Tag = "14"
        '
        'lblDay3_6_2
        '
        Me.lblDay3_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay3_6_2.Name = "lblDay3_6_2"
        Me.lblDay3_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_2.TabIndex = 20
        Me.lblDay3_6_2.Tag = "13"
        '
        'lblDay3_5_2
        '
        Me.lblDay3_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay3_5_2.Name = "lblDay3_5_2"
        Me.lblDay3_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_2.TabIndex = 19
        Me.lblDay3_5_2.Tag = "12"
        '
        'lblDay3_4_2
        '
        Me.lblDay3_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay3_4_2.Name = "lblDay3_4_2"
        Me.lblDay3_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_2.TabIndex = 18
        Me.lblDay3_4_2.Tag = "11"
        '
        'lblDay3_3_2
        '
        Me.lblDay3_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay3_3_2.Name = "lblDay3_3_2"
        Me.lblDay3_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_2.TabIndex = 17
        Me.lblDay3_3_2.Tag = "10"
        '
        'lblDay3_2_2
        '
        Me.lblDay3_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay3_2_2.Name = "lblDay3_2_2"
        Me.lblDay3_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_2.TabIndex = 16
        Me.lblDay3_2_2.Tag = "9"
        '
        'lblDay3_1_2
        '
        Me.lblDay3_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay3_1_2.Name = "lblDay3_1_2"
        Me.lblDay3_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_2.TabIndex = 15
        Me.lblDay3_1_2.Tag = "8"
        '
        'lblDay3_7_1
        '
        Me.lblDay3_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay3_7_1.Name = "lblDay3_7_1"
        Me.lblDay3_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_7_1.TabIndex = 14
        Me.lblDay3_7_1.Tag = "7"
        '
        'lblDay3_6_1
        '
        Me.lblDay3_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay3_6_1.Name = "lblDay3_6_1"
        Me.lblDay3_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_6_1.TabIndex = 13
        Me.lblDay3_6_1.Tag = "6"
        '
        'lblDay3_5_1
        '
        Me.lblDay3_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay3_5_1.Name = "lblDay3_5_1"
        Me.lblDay3_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_5_1.TabIndex = 12
        Me.lblDay3_5_1.Tag = "5"
        '
        'lblDay3_4_1
        '
        Me.lblDay3_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay3_4_1.Name = "lblDay3_4_1"
        Me.lblDay3_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_4_1.TabIndex = 11
        Me.lblDay3_4_1.Tag = "4"
        '
        'lblDay3_3_1
        '
        Me.lblDay3_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay3_3_1.Name = "lblDay3_3_1"
        Me.lblDay3_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_3_1.TabIndex = 10
        Me.lblDay3_3_1.Tag = "3"
        '
        'lblDay3_2_1
        '
        Me.lblDay3_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay3_2_1.Name = "lblDay3_2_1"
        Me.lblDay3_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_2_1.TabIndex = 9
        Me.lblDay3_2_1.Tag = "2"
        '
        'lblDay3_1_1
        '
        Me.lblDay3_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay3_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay3_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay3_1_1.Name = "lblDay3_1_1"
        Me.lblDay3_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay3_1_1.TabIndex = 8
        Me.lblDay3_1_1.Tag = "1"
        '
        'lbl7_3
        '
        Me.lbl7_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_3.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_3.Name = "lbl7_3"
        Me.lbl7_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_3.TabIndex = 7
        Me.lbl7_3.Text = "Sat"
        Me.lbl7_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_3
        '
        Me.lbl6_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_3.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_3.Name = "lbl6_3"
        Me.lbl6_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_3.TabIndex = 6
        Me.lbl6_3.Text = "Fri"
        Me.lbl6_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_3
        '
        Me.lbl5_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_3.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_3.Name = "lbl5_3"
        Me.lbl5_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_3.TabIndex = 5
        Me.lbl5_3.Text = "Thu"
        Me.lbl5_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_3
        '
        Me.lbl4_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_3.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_3.Name = "lbl4_3"
        Me.lbl4_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_3.TabIndex = 4
        Me.lbl4_3.Text = "Wed"
        Me.lbl4_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_3
        '
        Me.lbl3_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_3.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_3.Name = "lbl3_3"
        Me.lbl3_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_3.TabIndex = 3
        Me.lbl3_3.Text = "Tue"
        Me.lbl3_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_3
        '
        Me.lbl2_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_3.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_3.Name = "lbl2_3"
        Me.lbl2_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_3.TabIndex = 2
        Me.lbl2_3.Text = "Mon"
        Me.lbl2_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_3
        '
        Me.lbl1_3.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_3.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_3.Name = "lbl1_3"
        Me.lbl1_3.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_3.TabIndex = 1
        Me.lbl1_3.Text = "Sun"
        Me.lbl1_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthMar
        '
        Me.lblMonthMar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthMar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthMar.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthMar.Name = "lblMonthMar"
        Me.lblMonthMar.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthMar.TabIndex = 0
        Me.lblMonthMar.Text = "March"
        Me.lblMonthMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth4
        '
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_6)
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_5)
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_4)
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_3)
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_2)
        Me.pnMonth4.Controls.Add(Me.lblDay4_7_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_6_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_5_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_4_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_3_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_2_1)
        Me.pnMonth4.Controls.Add(Me.lblDay4_1_1)
        Me.pnMonth4.Controls.Add(Me.lbl7_4)
        Me.pnMonth4.Controls.Add(Me.lbl6_4)
        Me.pnMonth4.Controls.Add(Me.lbl5_4)
        Me.pnMonth4.Controls.Add(Me.lbl4_4)
        Me.pnMonth4.Controls.Add(Me.lbl3_4)
        Me.pnMonth4.Controls.Add(Me.lbl2_4)
        Me.pnMonth4.Controls.Add(Me.lbl1_4)
        Me.pnMonth4.Controls.Add(Me.lblMonthApr)
        Me.pnMonth4.Location = New System.Drawing.Point(696, 88)
        Me.pnMonth4.Name = "pnMonth4"
        Me.pnMonth4.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth4.TabIndex = 13
        '
        'lblDay4_7_6
        '
        Me.lblDay4_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay4_7_6.Name = "lblDay4_7_6"
        Me.lblDay4_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_6.TabIndex = 49
        Me.lblDay4_7_6.Tag = "42"
        '
        'lblDay4_6_6
        '
        Me.lblDay4_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay4_6_6.Name = "lblDay4_6_6"
        Me.lblDay4_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_6.TabIndex = 48
        Me.lblDay4_6_6.Tag = "41"
        '
        'lblDay4_5_6
        '
        Me.lblDay4_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay4_5_6.Name = "lblDay4_5_6"
        Me.lblDay4_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_6.TabIndex = 47
        Me.lblDay4_5_6.Tag = "40"
        '
        'lblDay4_4_6
        '
        Me.lblDay4_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay4_4_6.Name = "lblDay4_4_6"
        Me.lblDay4_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_6.TabIndex = 46
        Me.lblDay4_4_6.Tag = "39"
        '
        'lblDay4_3_6
        '
        Me.lblDay4_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay4_3_6.Name = "lblDay4_3_6"
        Me.lblDay4_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_6.TabIndex = 45
        Me.lblDay4_3_6.Tag = "38"
        '
        'lblDay4_2_6
        '
        Me.lblDay4_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay4_2_6.Name = "lblDay4_2_6"
        Me.lblDay4_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_6.TabIndex = 44
        Me.lblDay4_2_6.Tag = "37"
        '
        'lblDay4_1_6
        '
        Me.lblDay4_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay4_1_6.Name = "lblDay4_1_6"
        Me.lblDay4_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_6.TabIndex = 43
        Me.lblDay4_1_6.Tag = "36"
        '
        'lblDay4_7_5
        '
        Me.lblDay4_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay4_7_5.Name = "lblDay4_7_5"
        Me.lblDay4_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_5.TabIndex = 42
        Me.lblDay4_7_5.Tag = "35"
        '
        'lblDay4_6_5
        '
        Me.lblDay4_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay4_6_5.Name = "lblDay4_6_5"
        Me.lblDay4_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_5.TabIndex = 41
        Me.lblDay4_6_5.Tag = "34"
        '
        'lblDay4_5_5
        '
        Me.lblDay4_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay4_5_5.Name = "lblDay4_5_5"
        Me.lblDay4_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_5.TabIndex = 40
        Me.lblDay4_5_5.Tag = "33"
        '
        'lblDay4_4_5
        '
        Me.lblDay4_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay4_4_5.Name = "lblDay4_4_5"
        Me.lblDay4_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_5.TabIndex = 39
        Me.lblDay4_4_5.Tag = "32"
        '
        'lblDay4_3_5
        '
        Me.lblDay4_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay4_3_5.Name = "lblDay4_3_5"
        Me.lblDay4_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_5.TabIndex = 38
        Me.lblDay4_3_5.Tag = "31"
        '
        'lblDay4_2_5
        '
        Me.lblDay4_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay4_2_5.Name = "lblDay4_2_5"
        Me.lblDay4_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_5.TabIndex = 37
        Me.lblDay4_2_5.Tag = "30"
        '
        'lblDay4_1_5
        '
        Me.lblDay4_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay4_1_5.Name = "lblDay4_1_5"
        Me.lblDay4_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_5.TabIndex = 36
        Me.lblDay4_1_5.Tag = "29"
        '
        'lblDay4_7_4
        '
        Me.lblDay4_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay4_7_4.Name = "lblDay4_7_4"
        Me.lblDay4_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_4.TabIndex = 35
        Me.lblDay4_7_4.Tag = "28"
        '
        'lblDay4_6_4
        '
        Me.lblDay4_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay4_6_4.Name = "lblDay4_6_4"
        Me.lblDay4_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_4.TabIndex = 34
        Me.lblDay4_6_4.Tag = "27"
        '
        'lblDay4_5_4
        '
        Me.lblDay4_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay4_5_4.Name = "lblDay4_5_4"
        Me.lblDay4_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_4.TabIndex = 33
        Me.lblDay4_5_4.Tag = "26"
        '
        'lblDay4_4_4
        '
        Me.lblDay4_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay4_4_4.Name = "lblDay4_4_4"
        Me.lblDay4_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_4.TabIndex = 32
        Me.lblDay4_4_4.Tag = "25"
        '
        'lblDay4_3_4
        '
        Me.lblDay4_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay4_3_4.Name = "lblDay4_3_4"
        Me.lblDay4_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_4.TabIndex = 31
        Me.lblDay4_3_4.Tag = "24"
        '
        'lblDay4_2_4
        '
        Me.lblDay4_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay4_2_4.Name = "lblDay4_2_4"
        Me.lblDay4_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_4.TabIndex = 30
        Me.lblDay4_2_4.Tag = "23"
        '
        'lblDay4_1_4
        '
        Me.lblDay4_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay4_1_4.Name = "lblDay4_1_4"
        Me.lblDay4_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_4.TabIndex = 29
        Me.lblDay4_1_4.Tag = "22"
        '
        'lblDay4_7_3
        '
        Me.lblDay4_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay4_7_3.Name = "lblDay4_7_3"
        Me.lblDay4_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_3.TabIndex = 28
        Me.lblDay4_7_3.Tag = "21"
        '
        'lblDay4_6_3
        '
        Me.lblDay4_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay4_6_3.Name = "lblDay4_6_3"
        Me.lblDay4_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_3.TabIndex = 27
        Me.lblDay4_6_3.Tag = "20"
        '
        'lblDay4_5_3
        '
        Me.lblDay4_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay4_5_3.Name = "lblDay4_5_3"
        Me.lblDay4_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_3.TabIndex = 26
        Me.lblDay4_5_3.Tag = "19"
        '
        'lblDay4_4_3
        '
        Me.lblDay4_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay4_4_3.Name = "lblDay4_4_3"
        Me.lblDay4_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_3.TabIndex = 25
        Me.lblDay4_4_3.Tag = "18"
        '
        'lblDay4_3_3
        '
        Me.lblDay4_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay4_3_3.Name = "lblDay4_3_3"
        Me.lblDay4_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_3.TabIndex = 24
        Me.lblDay4_3_3.Tag = "17"
        '
        'lblDay4_2_3
        '
        Me.lblDay4_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay4_2_3.Name = "lblDay4_2_3"
        Me.lblDay4_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_3.TabIndex = 23
        Me.lblDay4_2_3.Tag = "16"
        '
        'lblDay4_1_3
        '
        Me.lblDay4_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay4_1_3.Name = "lblDay4_1_3"
        Me.lblDay4_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_3.TabIndex = 22
        Me.lblDay4_1_3.Tag = "15"
        '
        'lblDay4_7_2
        '
        Me.lblDay4_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay4_7_2.Name = "lblDay4_7_2"
        Me.lblDay4_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_2.TabIndex = 21
        Me.lblDay4_7_2.Tag = "14"
        '
        'lblDay4_6_2
        '
        Me.lblDay4_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay4_6_2.Name = "lblDay4_6_2"
        Me.lblDay4_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_2.TabIndex = 20
        Me.lblDay4_6_2.Tag = "13"
        '
        'lblDay4_5_2
        '
        Me.lblDay4_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay4_5_2.Name = "lblDay4_5_2"
        Me.lblDay4_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_2.TabIndex = 19
        Me.lblDay4_5_2.Tag = "12"
        '
        'lblDay4_4_2
        '
        Me.lblDay4_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay4_4_2.Name = "lblDay4_4_2"
        Me.lblDay4_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_2.TabIndex = 18
        Me.lblDay4_4_2.Tag = "11"
        '
        'lblDay4_3_2
        '
        Me.lblDay4_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay4_3_2.Name = "lblDay4_3_2"
        Me.lblDay4_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_2.TabIndex = 17
        Me.lblDay4_3_2.Tag = "10"
        '
        'lblDay4_2_2
        '
        Me.lblDay4_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay4_2_2.Name = "lblDay4_2_2"
        Me.lblDay4_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_2.TabIndex = 16
        Me.lblDay4_2_2.Tag = "9"
        '
        'lblDay4_1_2
        '
        Me.lblDay4_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay4_1_2.Name = "lblDay4_1_2"
        Me.lblDay4_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_2.TabIndex = 15
        Me.lblDay4_1_2.Tag = "8"
        '
        'lblDay4_7_1
        '
        Me.lblDay4_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay4_7_1.Name = "lblDay4_7_1"
        Me.lblDay4_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_7_1.TabIndex = 14
        Me.lblDay4_7_1.Tag = "7"
        '
        'lblDay4_6_1
        '
        Me.lblDay4_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay4_6_1.Name = "lblDay4_6_1"
        Me.lblDay4_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_6_1.TabIndex = 13
        Me.lblDay4_6_1.Tag = "6"
        '
        'lblDay4_5_1
        '
        Me.lblDay4_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay4_5_1.Name = "lblDay4_5_1"
        Me.lblDay4_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_5_1.TabIndex = 12
        Me.lblDay4_5_1.Tag = "5"
        '
        'lblDay4_4_1
        '
        Me.lblDay4_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay4_4_1.Name = "lblDay4_4_1"
        Me.lblDay4_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_4_1.TabIndex = 11
        Me.lblDay4_4_1.Tag = "4"
        '
        'lblDay4_3_1
        '
        Me.lblDay4_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay4_3_1.Name = "lblDay4_3_1"
        Me.lblDay4_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_3_1.TabIndex = 10
        Me.lblDay4_3_1.Tag = "3"
        '
        'lblDay4_2_1
        '
        Me.lblDay4_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay4_2_1.Name = "lblDay4_2_1"
        Me.lblDay4_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_2_1.TabIndex = 9
        Me.lblDay4_2_1.Tag = "2"
        '
        'lblDay4_1_1
        '
        Me.lblDay4_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay4_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay4_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay4_1_1.Name = "lblDay4_1_1"
        Me.lblDay4_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay4_1_1.TabIndex = 8
        Me.lblDay4_1_1.Tag = "1"
        '
        'lbl7_4
        '
        Me.lbl7_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_4.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_4.Name = "lbl7_4"
        Me.lbl7_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_4.TabIndex = 7
        Me.lbl7_4.Text = "Sat"
        Me.lbl7_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_4
        '
        Me.lbl6_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_4.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_4.Name = "lbl6_4"
        Me.lbl6_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_4.TabIndex = 6
        Me.lbl6_4.Text = "Fri"
        Me.lbl6_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_4
        '
        Me.lbl5_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_4.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_4.Name = "lbl5_4"
        Me.lbl5_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_4.TabIndex = 5
        Me.lbl5_4.Text = "Thu"
        Me.lbl5_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_4
        '
        Me.lbl4_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_4.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_4.Name = "lbl4_4"
        Me.lbl4_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_4.TabIndex = 4
        Me.lbl4_4.Text = "Wed"
        Me.lbl4_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_4
        '
        Me.lbl3_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_4.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_4.Name = "lbl3_4"
        Me.lbl3_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_4.TabIndex = 3
        Me.lbl3_4.Text = "Tue"
        Me.lbl3_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_4
        '
        Me.lbl2_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_4.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_4.Name = "lbl2_4"
        Me.lbl2_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_4.TabIndex = 2
        Me.lbl2_4.Text = "Mon"
        Me.lbl2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_4
        '
        Me.lbl1_4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_4.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_4.Name = "lbl1_4"
        Me.lbl1_4.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_4.TabIndex = 1
        Me.lbl1_4.Text = "Sun"
        Me.lbl1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthApr
        '
        Me.lblMonthApr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthApr.ForeColor = System.Drawing.Color.Purple
        Me.lblMonthApr.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthApr.Name = "lblMonthApr"
        Me.lblMonthApr.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthApr.TabIndex = 0
        Me.lblMonthApr.Text = "April"
        Me.lblMonthApr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth5
        '
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_6)
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_5)
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_4)
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_3)
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_2)
        Me.pnMonth5.Controls.Add(Me.lblDay5_7_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_6_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_5_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_4_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_3_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_2_1)
        Me.pnMonth5.Controls.Add(Me.lblDay5_1_1)
        Me.pnMonth5.Controls.Add(Me.lbl7_5)
        Me.pnMonth5.Controls.Add(Me.lbl6_5)
        Me.pnMonth5.Controls.Add(Me.lbl5_5)
        Me.pnMonth5.Controls.Add(Me.lbl4_5)
        Me.pnMonth5.Controls.Add(Me.lbl3_5)
        Me.pnMonth5.Controls.Add(Me.lbl2_5)
        Me.pnMonth5.Controls.Add(Me.lbl1_5)
        Me.pnMonth5.Controls.Add(Me.lblMonthMay)
        Me.pnMonth5.Location = New System.Drawing.Point(0, 280)
        Me.pnMonth5.Name = "pnMonth5"
        Me.pnMonth5.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth5.TabIndex = 14
        '
        'lblDay5_7_6
        '
        Me.lblDay5_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay5_7_6.Name = "lblDay5_7_6"
        Me.lblDay5_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_6.TabIndex = 49
        Me.lblDay5_7_6.Tag = "42"
        '
        'lblDay5_6_6
        '
        Me.lblDay5_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay5_6_6.Name = "lblDay5_6_6"
        Me.lblDay5_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_6.TabIndex = 48
        Me.lblDay5_6_6.Tag = "41"
        '
        'lblDay5_5_6
        '
        Me.lblDay5_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay5_5_6.Name = "lblDay5_5_6"
        Me.lblDay5_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_6.TabIndex = 47
        Me.lblDay5_5_6.Tag = "40"
        '
        'lblDay5_4_6
        '
        Me.lblDay5_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay5_4_6.Name = "lblDay5_4_6"
        Me.lblDay5_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_6.TabIndex = 46
        Me.lblDay5_4_6.Tag = "39"
        '
        'lblDay5_3_6
        '
        Me.lblDay5_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay5_3_6.Name = "lblDay5_3_6"
        Me.lblDay5_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_6.TabIndex = 45
        Me.lblDay5_3_6.Tag = "38"
        '
        'lblDay5_2_6
        '
        Me.lblDay5_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay5_2_6.Name = "lblDay5_2_6"
        Me.lblDay5_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_6.TabIndex = 44
        Me.lblDay5_2_6.Tag = "37"
        '
        'lblDay5_1_6
        '
        Me.lblDay5_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay5_1_6.Name = "lblDay5_1_6"
        Me.lblDay5_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_6.TabIndex = 43
        Me.lblDay5_1_6.Tag = "36"
        '
        'lblDay5_7_5
        '
        Me.lblDay5_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay5_7_5.Name = "lblDay5_7_5"
        Me.lblDay5_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_5.TabIndex = 42
        Me.lblDay5_7_5.Tag = "35"
        '
        'lblDay5_6_5
        '
        Me.lblDay5_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay5_6_5.Name = "lblDay5_6_5"
        Me.lblDay5_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_5.TabIndex = 41
        Me.lblDay5_6_5.Tag = "34"
        '
        'lblDay5_5_5
        '
        Me.lblDay5_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay5_5_5.Name = "lblDay5_5_5"
        Me.lblDay5_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_5.TabIndex = 40
        Me.lblDay5_5_5.Tag = "33"
        '
        'lblDay5_4_5
        '
        Me.lblDay5_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay5_4_5.Name = "lblDay5_4_5"
        Me.lblDay5_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_5.TabIndex = 39
        Me.lblDay5_4_5.Tag = "32"
        '
        'lblDay5_3_5
        '
        Me.lblDay5_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay5_3_5.Name = "lblDay5_3_5"
        Me.lblDay5_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_5.TabIndex = 38
        Me.lblDay5_3_5.Tag = "31"
        '
        'lblDay5_2_5
        '
        Me.lblDay5_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay5_2_5.Name = "lblDay5_2_5"
        Me.lblDay5_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_5.TabIndex = 37
        Me.lblDay5_2_5.Tag = "30"
        '
        'lblDay5_1_5
        '
        Me.lblDay5_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay5_1_5.Name = "lblDay5_1_5"
        Me.lblDay5_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_5.TabIndex = 36
        Me.lblDay5_1_5.Tag = "29"
        '
        'lblDay5_7_4
        '
        Me.lblDay5_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay5_7_4.Name = "lblDay5_7_4"
        Me.lblDay5_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_4.TabIndex = 35
        Me.lblDay5_7_4.Tag = "28"
        '
        'lblDay5_6_4
        '
        Me.lblDay5_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay5_6_4.Name = "lblDay5_6_4"
        Me.lblDay5_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_4.TabIndex = 34
        Me.lblDay5_6_4.Tag = "27"
        '
        'lblDay5_5_4
        '
        Me.lblDay5_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay5_5_4.Name = "lblDay5_5_4"
        Me.lblDay5_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_4.TabIndex = 33
        Me.lblDay5_5_4.Tag = "26"
        '
        'lblDay5_4_4
        '
        Me.lblDay5_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay5_4_4.Name = "lblDay5_4_4"
        Me.lblDay5_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_4.TabIndex = 32
        Me.lblDay5_4_4.Tag = "25"
        '
        'lblDay5_3_4
        '
        Me.lblDay5_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay5_3_4.Name = "lblDay5_3_4"
        Me.lblDay5_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_4.TabIndex = 31
        Me.lblDay5_3_4.Tag = "24"
        '
        'lblDay5_2_4
        '
        Me.lblDay5_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay5_2_4.Name = "lblDay5_2_4"
        Me.lblDay5_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_4.TabIndex = 30
        Me.lblDay5_2_4.Tag = "23"
        '
        'lblDay5_1_4
        '
        Me.lblDay5_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay5_1_4.Name = "lblDay5_1_4"
        Me.lblDay5_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_4.TabIndex = 29
        Me.lblDay5_1_4.Tag = "22"
        '
        'lblDay5_7_3
        '
        Me.lblDay5_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay5_7_3.Name = "lblDay5_7_3"
        Me.lblDay5_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_3.TabIndex = 28
        Me.lblDay5_7_3.Tag = "21"
        '
        'lblDay5_6_3
        '
        Me.lblDay5_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay5_6_3.Name = "lblDay5_6_3"
        Me.lblDay5_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_3.TabIndex = 27
        Me.lblDay5_6_3.Tag = "20"
        '
        'lblDay5_5_3
        '
        Me.lblDay5_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay5_5_3.Name = "lblDay5_5_3"
        Me.lblDay5_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_3.TabIndex = 26
        Me.lblDay5_5_3.Tag = "19"
        '
        'lblDay5_4_3
        '
        Me.lblDay5_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay5_4_3.Name = "lblDay5_4_3"
        Me.lblDay5_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_3.TabIndex = 25
        Me.lblDay5_4_3.Tag = "18"
        '
        'lblDay5_3_3
        '
        Me.lblDay5_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay5_3_3.Name = "lblDay5_3_3"
        Me.lblDay5_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_3.TabIndex = 24
        Me.lblDay5_3_3.Tag = "17"
        '
        'lblDay5_2_3
        '
        Me.lblDay5_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay5_2_3.Name = "lblDay5_2_3"
        Me.lblDay5_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_3.TabIndex = 23
        Me.lblDay5_2_3.Tag = "16"
        '
        'lblDay5_1_3
        '
        Me.lblDay5_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay5_1_3.Name = "lblDay5_1_3"
        Me.lblDay5_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_3.TabIndex = 22
        Me.lblDay5_1_3.Tag = "15"
        '
        'lblDay5_7_2
        '
        Me.lblDay5_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay5_7_2.Name = "lblDay5_7_2"
        Me.lblDay5_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_2.TabIndex = 21
        Me.lblDay5_7_2.Tag = "14"
        '
        'lblDay5_6_2
        '
        Me.lblDay5_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay5_6_2.Name = "lblDay5_6_2"
        Me.lblDay5_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_2.TabIndex = 20
        Me.lblDay5_6_2.Tag = "13"
        '
        'lblDay5_5_2
        '
        Me.lblDay5_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay5_5_2.Name = "lblDay5_5_2"
        Me.lblDay5_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_2.TabIndex = 19
        Me.lblDay5_5_2.Tag = "12"
        '
        'lblDay5_4_2
        '
        Me.lblDay5_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay5_4_2.Name = "lblDay5_4_2"
        Me.lblDay5_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_2.TabIndex = 18
        Me.lblDay5_4_2.Tag = "11"
        '
        'lblDay5_3_2
        '
        Me.lblDay5_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay5_3_2.Name = "lblDay5_3_2"
        Me.lblDay5_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_2.TabIndex = 17
        Me.lblDay5_3_2.Tag = "10"
        '
        'lblDay5_2_2
        '
        Me.lblDay5_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay5_2_2.Name = "lblDay5_2_2"
        Me.lblDay5_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_2.TabIndex = 16
        Me.lblDay5_2_2.Tag = "9"
        '
        'lblDay5_1_2
        '
        Me.lblDay5_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay5_1_2.Name = "lblDay5_1_2"
        Me.lblDay5_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_2.TabIndex = 15
        Me.lblDay5_1_2.Tag = "8"
        '
        'lblDay5_7_1
        '
        Me.lblDay5_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay5_7_1.Name = "lblDay5_7_1"
        Me.lblDay5_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_7_1.TabIndex = 14
        Me.lblDay5_7_1.Tag = "7"
        '
        'lblDay5_6_1
        '
        Me.lblDay5_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay5_6_1.Name = "lblDay5_6_1"
        Me.lblDay5_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_6_1.TabIndex = 13
        Me.lblDay5_6_1.Tag = "6"
        '
        'lblDay5_5_1
        '
        Me.lblDay5_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay5_5_1.Name = "lblDay5_5_1"
        Me.lblDay5_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_5_1.TabIndex = 12
        Me.lblDay5_5_1.Tag = "5"
        '
        'lblDay5_4_1
        '
        Me.lblDay5_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay5_4_1.Name = "lblDay5_4_1"
        Me.lblDay5_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_4_1.TabIndex = 11
        Me.lblDay5_4_1.Tag = "4"
        '
        'lblDay5_3_1
        '
        Me.lblDay5_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay5_3_1.Name = "lblDay5_3_1"
        Me.lblDay5_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_3_1.TabIndex = 10
        Me.lblDay5_3_1.Tag = "3"
        '
        'lblDay5_2_1
        '
        Me.lblDay5_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay5_2_1.Name = "lblDay5_2_1"
        Me.lblDay5_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_2_1.TabIndex = 9
        Me.lblDay5_2_1.Tag = "2"
        '
        'lblDay5_1_1
        '
        Me.lblDay5_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay5_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay5_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay5_1_1.Name = "lblDay5_1_1"
        Me.lblDay5_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay5_1_1.TabIndex = 8
        Me.lblDay5_1_1.Tag = "1"
        '
        'lbl7_5
        '
        Me.lbl7_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_5.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_5.Name = "lbl7_5"
        Me.lbl7_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_5.TabIndex = 7
        Me.lbl7_5.Text = "Sat"
        Me.lbl7_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_5
        '
        Me.lbl6_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_5.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_5.Name = "lbl6_5"
        Me.lbl6_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_5.TabIndex = 6
        Me.lbl6_5.Text = "Fri"
        Me.lbl6_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_5
        '
        Me.lbl5_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_5.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_5.Name = "lbl5_5"
        Me.lbl5_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_5.TabIndex = 5
        Me.lbl5_5.Text = "Thu"
        Me.lbl5_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_5
        '
        Me.lbl4_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_5.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_5.Name = "lbl4_5"
        Me.lbl4_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_5.TabIndex = 4
        Me.lbl4_5.Text = "Wed"
        Me.lbl4_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_5
        '
        Me.lbl3_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_5.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_5.Name = "lbl3_5"
        Me.lbl3_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_5.TabIndex = 3
        Me.lbl3_5.Text = "Tue"
        Me.lbl3_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_5
        '
        Me.lbl2_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_5.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_5.Name = "lbl2_5"
        Me.lbl2_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_5.TabIndex = 2
        Me.lbl2_5.Text = "Mon"
        Me.lbl2_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_5
        '
        Me.lbl1_5.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_5.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_5.Name = "lbl1_5"
        Me.lbl1_5.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_5.TabIndex = 1
        Me.lbl1_5.Text = "Sun"
        Me.lbl1_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthMay
        '
        Me.lblMonthMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthMay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMonthMay.Location = New System.Drawing.Point(80, 8)
        Me.lblMonthMay.Name = "lblMonthMay"
        Me.lblMonthMay.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthMay.TabIndex = 0
        Me.lblMonthMay.Text = "May"
        Me.lblMonthMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth6
        '
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_6)
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_5)
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_4)
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_3)
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_2)
        Me.pnMonth6.Controls.Add(Me.lblDay6_7_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_6_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_5_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_4_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_3_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_2_1)
        Me.pnMonth6.Controls.Add(Me.lblDay6_1_1)
        Me.pnMonth6.Controls.Add(Me.lbl7_6)
        Me.pnMonth6.Controls.Add(Me.lbl6_6)
        Me.pnMonth6.Controls.Add(Me.lbl5_6)
        Me.pnMonth6.Controls.Add(Me.lbl4_6)
        Me.pnMonth6.Controls.Add(Me.lbl3_6)
        Me.pnMonth6.Controls.Add(Me.lbl2_6)
        Me.pnMonth6.Controls.Add(Me.lbl1_6)
        Me.pnMonth6.Controls.Add(Me.lblMonthJun)
        Me.pnMonth6.Location = New System.Drawing.Point(232, 280)
        Me.pnMonth6.Name = "pnMonth6"
        Me.pnMonth6.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth6.TabIndex = 15
        '
        'lblDay6_7_6
        '
        Me.lblDay6_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay6_7_6.Name = "lblDay6_7_6"
        Me.lblDay6_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_6.TabIndex = 49
        Me.lblDay6_7_6.Tag = "42"
        '
        'lblDay6_6_6
        '
        Me.lblDay6_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay6_6_6.Name = "lblDay6_6_6"
        Me.lblDay6_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_6.TabIndex = 48
        Me.lblDay6_6_6.Tag = "41"
        '
        'lblDay6_5_6
        '
        Me.lblDay6_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay6_5_6.Name = "lblDay6_5_6"
        Me.lblDay6_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_6.TabIndex = 47
        Me.lblDay6_5_6.Tag = "40"
        '
        'lblDay6_4_6
        '
        Me.lblDay6_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay6_4_6.Name = "lblDay6_4_6"
        Me.lblDay6_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_6.TabIndex = 46
        Me.lblDay6_4_6.Tag = "39"
        '
        'lblDay6_3_6
        '
        Me.lblDay6_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay6_3_6.Name = "lblDay6_3_6"
        Me.lblDay6_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_6.TabIndex = 45
        Me.lblDay6_3_6.Tag = "38"
        '
        'lblDay6_2_6
        '
        Me.lblDay6_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay6_2_6.Name = "lblDay6_2_6"
        Me.lblDay6_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_6.TabIndex = 44
        Me.lblDay6_2_6.Tag = "37"
        '
        'lblDay6_1_6
        '
        Me.lblDay6_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay6_1_6.Name = "lblDay6_1_6"
        Me.lblDay6_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_6.TabIndex = 43
        Me.lblDay6_1_6.Tag = "36"
        '
        'lblDay6_7_5
        '
        Me.lblDay6_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay6_7_5.Name = "lblDay6_7_5"
        Me.lblDay6_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_5.TabIndex = 42
        Me.lblDay6_7_5.Tag = "35"
        '
        'lblDay6_6_5
        '
        Me.lblDay6_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay6_6_5.Name = "lblDay6_6_5"
        Me.lblDay6_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_5.TabIndex = 41
        Me.lblDay6_6_5.Tag = "34"
        '
        'lblDay6_5_5
        '
        Me.lblDay6_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay6_5_5.Name = "lblDay6_5_5"
        Me.lblDay6_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_5.TabIndex = 40
        Me.lblDay6_5_5.Tag = "33"
        '
        'lblDay6_4_5
        '
        Me.lblDay6_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay6_4_5.Name = "lblDay6_4_5"
        Me.lblDay6_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_5.TabIndex = 39
        Me.lblDay6_4_5.Tag = "32"
        '
        'lblDay6_3_5
        '
        Me.lblDay6_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay6_3_5.Name = "lblDay6_3_5"
        Me.lblDay6_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_5.TabIndex = 38
        Me.lblDay6_3_5.Tag = "31"
        '
        'lblDay6_2_5
        '
        Me.lblDay6_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay6_2_5.Name = "lblDay6_2_5"
        Me.lblDay6_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_5.TabIndex = 37
        Me.lblDay6_2_5.Tag = "30"
        '
        'lblDay6_1_5
        '
        Me.lblDay6_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay6_1_5.Name = "lblDay6_1_5"
        Me.lblDay6_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_5.TabIndex = 36
        Me.lblDay6_1_5.Tag = "29"
        '
        'lblDay6_7_4
        '
        Me.lblDay6_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay6_7_4.Name = "lblDay6_7_4"
        Me.lblDay6_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_4.TabIndex = 35
        Me.lblDay6_7_4.Tag = "28"
        '
        'lblDay6_6_4
        '
        Me.lblDay6_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay6_6_4.Name = "lblDay6_6_4"
        Me.lblDay6_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_4.TabIndex = 34
        Me.lblDay6_6_4.Tag = "27"
        '
        'lblDay6_5_4
        '
        Me.lblDay6_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay6_5_4.Name = "lblDay6_5_4"
        Me.lblDay6_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_4.TabIndex = 33
        Me.lblDay6_5_4.Tag = "26"
        '
        'lblDay6_4_4
        '
        Me.lblDay6_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay6_4_4.Name = "lblDay6_4_4"
        Me.lblDay6_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_4.TabIndex = 32
        Me.lblDay6_4_4.Tag = "25"
        '
        'lblDay6_3_4
        '
        Me.lblDay6_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay6_3_4.Name = "lblDay6_3_4"
        Me.lblDay6_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_4.TabIndex = 31
        Me.lblDay6_3_4.Tag = "24"
        '
        'lblDay6_2_4
        '
        Me.lblDay6_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay6_2_4.Name = "lblDay6_2_4"
        Me.lblDay6_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_4.TabIndex = 30
        Me.lblDay6_2_4.Tag = "23"
        '
        'lblDay6_1_4
        '
        Me.lblDay6_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay6_1_4.Name = "lblDay6_1_4"
        Me.lblDay6_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_4.TabIndex = 29
        Me.lblDay6_1_4.Tag = "22"
        '
        'lblDay6_7_3
        '
        Me.lblDay6_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay6_7_3.Name = "lblDay6_7_3"
        Me.lblDay6_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_3.TabIndex = 28
        Me.lblDay6_7_3.Tag = "21"
        '
        'lblDay6_6_3
        '
        Me.lblDay6_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay6_6_3.Name = "lblDay6_6_3"
        Me.lblDay6_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_3.TabIndex = 27
        Me.lblDay6_6_3.Tag = "20"
        '
        'lblDay6_5_3
        '
        Me.lblDay6_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay6_5_3.Name = "lblDay6_5_3"
        Me.lblDay6_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_3.TabIndex = 26
        Me.lblDay6_5_3.Tag = "19"
        '
        'lblDay6_4_3
        '
        Me.lblDay6_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay6_4_3.Name = "lblDay6_4_3"
        Me.lblDay6_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_3.TabIndex = 25
        Me.lblDay6_4_3.Tag = "18"
        '
        'lblDay6_3_3
        '
        Me.lblDay6_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay6_3_3.Name = "lblDay6_3_3"
        Me.lblDay6_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_3.TabIndex = 24
        Me.lblDay6_3_3.Tag = "17"
        '
        'lblDay6_2_3
        '
        Me.lblDay6_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay6_2_3.Name = "lblDay6_2_3"
        Me.lblDay6_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_3.TabIndex = 23
        Me.lblDay6_2_3.Tag = "16"
        '
        'lblDay6_1_3
        '
        Me.lblDay6_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay6_1_3.Name = "lblDay6_1_3"
        Me.lblDay6_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_3.TabIndex = 22
        Me.lblDay6_1_3.Tag = "15"
        '
        'lblDay6_7_2
        '
        Me.lblDay6_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay6_7_2.Name = "lblDay6_7_2"
        Me.lblDay6_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_2.TabIndex = 21
        Me.lblDay6_7_2.Tag = "14"
        '
        'lblDay6_6_2
        '
        Me.lblDay6_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay6_6_2.Name = "lblDay6_6_2"
        Me.lblDay6_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_2.TabIndex = 20
        Me.lblDay6_6_2.Tag = "13"
        '
        'lblDay6_5_2
        '
        Me.lblDay6_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay6_5_2.Name = "lblDay6_5_2"
        Me.lblDay6_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_2.TabIndex = 19
        Me.lblDay6_5_2.Tag = "12"
        '
        'lblDay6_4_2
        '
        Me.lblDay6_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay6_4_2.Name = "lblDay6_4_2"
        Me.lblDay6_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_2.TabIndex = 18
        Me.lblDay6_4_2.Tag = "11"
        '
        'lblDay6_3_2
        '
        Me.lblDay6_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay6_3_2.Name = "lblDay6_3_2"
        Me.lblDay6_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_2.TabIndex = 17
        Me.lblDay6_3_2.Tag = "10"
        '
        'lblDay6_2_2
        '
        Me.lblDay6_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay6_2_2.Name = "lblDay6_2_2"
        Me.lblDay6_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_2.TabIndex = 16
        Me.lblDay6_2_2.Tag = "9"
        '
        'lblDay6_1_2
        '
        Me.lblDay6_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay6_1_2.Name = "lblDay6_1_2"
        Me.lblDay6_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_2.TabIndex = 15
        Me.lblDay6_1_2.Tag = "8"
        '
        'lblDay6_7_1
        '
        Me.lblDay6_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay6_7_1.Name = "lblDay6_7_1"
        Me.lblDay6_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_7_1.TabIndex = 14
        Me.lblDay6_7_1.Tag = "7"
        '
        'lblDay6_6_1
        '
        Me.lblDay6_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay6_6_1.Name = "lblDay6_6_1"
        Me.lblDay6_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_6_1.TabIndex = 13
        Me.lblDay6_6_1.Tag = "6"
        '
        'lblDay6_5_1
        '
        Me.lblDay6_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay6_5_1.Name = "lblDay6_5_1"
        Me.lblDay6_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_5_1.TabIndex = 12
        Me.lblDay6_5_1.Tag = "5"
        '
        'lblDay6_4_1
        '
        Me.lblDay6_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay6_4_1.Name = "lblDay6_4_1"
        Me.lblDay6_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_4_1.TabIndex = 11
        Me.lblDay6_4_1.Tag = "4"
        '
        'lblDay6_3_1
        '
        Me.lblDay6_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay6_3_1.Name = "lblDay6_3_1"
        Me.lblDay6_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_3_1.TabIndex = 10
        Me.lblDay6_3_1.Tag = "3"
        '
        'lblDay6_2_1
        '
        Me.lblDay6_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay6_2_1.Name = "lblDay6_2_1"
        Me.lblDay6_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_2_1.TabIndex = 9
        Me.lblDay6_2_1.Tag = "2"
        '
        'lblDay6_1_1
        '
        Me.lblDay6_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay6_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay6_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay6_1_1.Name = "lblDay6_1_1"
        Me.lblDay6_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay6_1_1.TabIndex = 8
        Me.lblDay6_1_1.Tag = "1"
        '
        'lbl7_6
        '
        Me.lbl7_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_6.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_6.Name = "lbl7_6"
        Me.lbl7_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_6.TabIndex = 7
        Me.lbl7_6.Text = "Sat"
        Me.lbl7_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_6
        '
        Me.lbl6_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_6.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_6.Name = "lbl6_6"
        Me.lbl6_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_6.TabIndex = 6
        Me.lbl6_6.Text = "Fri"
        Me.lbl6_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_6
        '
        Me.lbl5_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_6.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_6.Name = "lbl5_6"
        Me.lbl5_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_6.TabIndex = 5
        Me.lbl5_6.Text = "Thu"
        Me.lbl5_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_6
        '
        Me.lbl4_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_6.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_6.Name = "lbl4_6"
        Me.lbl4_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_6.TabIndex = 4
        Me.lbl4_6.Text = "Wed"
        Me.lbl4_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_6
        '
        Me.lbl3_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_6.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_6.Name = "lbl3_6"
        Me.lbl3_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_6.TabIndex = 3
        Me.lbl3_6.Text = "Tue"
        Me.lbl3_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_6
        '
        Me.lbl2_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_6.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_6.Name = "lbl2_6"
        Me.lbl2_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_6.TabIndex = 2
        Me.lbl2_6.Text = "Mon"
        Me.lbl2_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_6
        '
        Me.lbl1_6.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_6.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_6.Name = "lbl1_6"
        Me.lbl1_6.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_6.TabIndex = 1
        Me.lbl1_6.Text = "Sun"
        Me.lbl1_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthJun
        '
        Me.lblMonthJun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthJun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthJun.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthJun.Name = "lblMonthJun"
        Me.lblMonthJun.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthJun.TabIndex = 0
        Me.lblMonthJun.Text = "June"
        Me.lblMonthJun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth7
        '
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_6)
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_5)
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_4)
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_3)
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_2)
        Me.pnMonth7.Controls.Add(Me.lblDay7_7_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_6_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_5_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_4_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_3_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_2_1)
        Me.pnMonth7.Controls.Add(Me.lblDay7_1_1)
        Me.pnMonth7.Controls.Add(Me.lbl7_7)
        Me.pnMonth7.Controls.Add(Me.lbl6_7)
        Me.pnMonth7.Controls.Add(Me.lbl5_7)
        Me.pnMonth7.Controls.Add(Me.lbl4_7)
        Me.pnMonth7.Controls.Add(Me.lbl3_7)
        Me.pnMonth7.Controls.Add(Me.lbl2_7)
        Me.pnMonth7.Controls.Add(Me.lbl1_7)
        Me.pnMonth7.Controls.Add(Me.lblMonthJul)
        Me.pnMonth7.Location = New System.Drawing.Point(464, 280)
        Me.pnMonth7.Name = "pnMonth7"
        Me.pnMonth7.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth7.TabIndex = 16
        '
        'lblDay7_7_6
        '
        Me.lblDay7_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay7_7_6.Name = "lblDay7_7_6"
        Me.lblDay7_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_6.TabIndex = 49
        Me.lblDay7_7_6.Tag = "42"
        '
        'lblDay7_6_6
        '
        Me.lblDay7_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay7_6_6.Name = "lblDay7_6_6"
        Me.lblDay7_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_6.TabIndex = 48
        Me.lblDay7_6_6.Tag = "41"
        '
        'lblDay7_5_6
        '
        Me.lblDay7_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay7_5_6.Name = "lblDay7_5_6"
        Me.lblDay7_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_6.TabIndex = 47
        Me.lblDay7_5_6.Tag = "40"
        '
        'lblDay7_4_6
        '
        Me.lblDay7_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay7_4_6.Name = "lblDay7_4_6"
        Me.lblDay7_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_6.TabIndex = 46
        Me.lblDay7_4_6.Tag = "39"
        '
        'lblDay7_3_6
        '
        Me.lblDay7_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay7_3_6.Name = "lblDay7_3_6"
        Me.lblDay7_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_6.TabIndex = 45
        Me.lblDay7_3_6.Tag = "38"
        '
        'lblDay7_2_6
        '
        Me.lblDay7_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay7_2_6.Name = "lblDay7_2_6"
        Me.lblDay7_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_6.TabIndex = 44
        Me.lblDay7_2_6.Tag = "37"
        '
        'lblDay7_1_6
        '
        Me.lblDay7_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay7_1_6.Name = "lblDay7_1_6"
        Me.lblDay7_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_6.TabIndex = 43
        Me.lblDay7_1_6.Tag = "36"
        '
        'lblDay7_7_5
        '
        Me.lblDay7_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay7_7_5.Name = "lblDay7_7_5"
        Me.lblDay7_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_5.TabIndex = 42
        Me.lblDay7_7_5.Tag = "35"
        '
        'lblDay7_6_5
        '
        Me.lblDay7_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay7_6_5.Name = "lblDay7_6_5"
        Me.lblDay7_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_5.TabIndex = 41
        Me.lblDay7_6_5.Tag = "34"
        '
        'lblDay7_5_5
        '
        Me.lblDay7_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay7_5_5.Name = "lblDay7_5_5"
        Me.lblDay7_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_5.TabIndex = 40
        Me.lblDay7_5_5.Tag = "33"
        '
        'lblDay7_4_5
        '
        Me.lblDay7_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay7_4_5.Name = "lblDay7_4_5"
        Me.lblDay7_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_5.TabIndex = 39
        Me.lblDay7_4_5.Tag = "32"
        '
        'lblDay7_3_5
        '
        Me.lblDay7_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay7_3_5.Name = "lblDay7_3_5"
        Me.lblDay7_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_5.TabIndex = 38
        Me.lblDay7_3_5.Tag = "31"
        '
        'lblDay7_2_5
        '
        Me.lblDay7_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay7_2_5.Name = "lblDay7_2_5"
        Me.lblDay7_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_5.TabIndex = 37
        Me.lblDay7_2_5.Tag = "30"
        '
        'lblDay7_1_5
        '
        Me.lblDay7_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay7_1_5.Name = "lblDay7_1_5"
        Me.lblDay7_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_5.TabIndex = 36
        Me.lblDay7_1_5.Tag = "29"
        '
        'lblDay7_7_4
        '
        Me.lblDay7_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay7_7_4.Name = "lblDay7_7_4"
        Me.lblDay7_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_4.TabIndex = 35
        Me.lblDay7_7_4.Tag = "28"
        '
        'lblDay7_6_4
        '
        Me.lblDay7_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay7_6_4.Name = "lblDay7_6_4"
        Me.lblDay7_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_4.TabIndex = 34
        Me.lblDay7_6_4.Tag = "27"
        '
        'lblDay7_5_4
        '
        Me.lblDay7_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay7_5_4.Name = "lblDay7_5_4"
        Me.lblDay7_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_4.TabIndex = 33
        Me.lblDay7_5_4.Tag = "26"
        '
        'lblDay7_4_4
        '
        Me.lblDay7_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay7_4_4.Name = "lblDay7_4_4"
        Me.lblDay7_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_4.TabIndex = 32
        Me.lblDay7_4_4.Tag = "25"
        '
        'lblDay7_3_4
        '
        Me.lblDay7_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay7_3_4.Name = "lblDay7_3_4"
        Me.lblDay7_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_4.TabIndex = 31
        Me.lblDay7_3_4.Tag = "24"
        '
        'lblDay7_2_4
        '
        Me.lblDay7_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay7_2_4.Name = "lblDay7_2_4"
        Me.lblDay7_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_4.TabIndex = 30
        Me.lblDay7_2_4.Tag = "23"
        '
        'lblDay7_1_4
        '
        Me.lblDay7_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay7_1_4.Name = "lblDay7_1_4"
        Me.lblDay7_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_4.TabIndex = 29
        Me.lblDay7_1_4.Tag = "22"
        '
        'lblDay7_7_3
        '
        Me.lblDay7_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay7_7_3.Name = "lblDay7_7_3"
        Me.lblDay7_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_3.TabIndex = 28
        Me.lblDay7_7_3.Tag = "21"
        '
        'lblDay7_6_3
        '
        Me.lblDay7_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay7_6_3.Name = "lblDay7_6_3"
        Me.lblDay7_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_3.TabIndex = 27
        Me.lblDay7_6_3.Tag = "20"
        '
        'lblDay7_5_3
        '
        Me.lblDay7_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay7_5_3.Name = "lblDay7_5_3"
        Me.lblDay7_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_3.TabIndex = 26
        Me.lblDay7_5_3.Tag = "19"
        '
        'lblDay7_4_3
        '
        Me.lblDay7_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay7_4_3.Name = "lblDay7_4_3"
        Me.lblDay7_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_3.TabIndex = 25
        Me.lblDay7_4_3.Tag = "18"
        '
        'lblDay7_3_3
        '
        Me.lblDay7_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay7_3_3.Name = "lblDay7_3_3"
        Me.lblDay7_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_3.TabIndex = 24
        Me.lblDay7_3_3.Tag = "17"
        '
        'lblDay7_2_3
        '
        Me.lblDay7_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay7_2_3.Name = "lblDay7_2_3"
        Me.lblDay7_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_3.TabIndex = 23
        Me.lblDay7_2_3.Tag = "16"
        '
        'lblDay7_1_3
        '
        Me.lblDay7_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay7_1_3.Name = "lblDay7_1_3"
        Me.lblDay7_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_3.TabIndex = 22
        Me.lblDay7_1_3.Tag = "15"
        '
        'lblDay7_7_2
        '
        Me.lblDay7_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay7_7_2.Name = "lblDay7_7_2"
        Me.lblDay7_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_2.TabIndex = 21
        Me.lblDay7_7_2.Tag = "14"
        '
        'lblDay7_6_2
        '
        Me.lblDay7_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay7_6_2.Name = "lblDay7_6_2"
        Me.lblDay7_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_2.TabIndex = 20
        Me.lblDay7_6_2.Tag = "13"
        '
        'lblDay7_5_2
        '
        Me.lblDay7_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay7_5_2.Name = "lblDay7_5_2"
        Me.lblDay7_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_2.TabIndex = 19
        Me.lblDay7_5_2.Tag = "12"
        '
        'lblDay7_4_2
        '
        Me.lblDay7_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay7_4_2.Name = "lblDay7_4_2"
        Me.lblDay7_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_2.TabIndex = 18
        Me.lblDay7_4_2.Tag = "11"
        '
        'lblDay7_3_2
        '
        Me.lblDay7_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay7_3_2.Name = "lblDay7_3_2"
        Me.lblDay7_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_2.TabIndex = 17
        Me.lblDay7_3_2.Tag = "10"
        '
        'lblDay7_2_2
        '
        Me.lblDay7_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay7_2_2.Name = "lblDay7_2_2"
        Me.lblDay7_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_2.TabIndex = 16
        Me.lblDay7_2_2.Tag = "9"
        '
        'lblDay7_1_2
        '
        Me.lblDay7_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay7_1_2.Name = "lblDay7_1_2"
        Me.lblDay7_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_2.TabIndex = 15
        Me.lblDay7_1_2.Tag = "8"
        '
        'lblDay7_7_1
        '
        Me.lblDay7_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay7_7_1.Name = "lblDay7_7_1"
        Me.lblDay7_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_7_1.TabIndex = 14
        Me.lblDay7_7_1.Tag = "7"
        '
        'lblDay7_6_1
        '
        Me.lblDay7_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay7_6_1.Name = "lblDay7_6_1"
        Me.lblDay7_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_6_1.TabIndex = 13
        Me.lblDay7_6_1.Tag = "6"
        '
        'lblDay7_5_1
        '
        Me.lblDay7_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay7_5_1.Name = "lblDay7_5_1"
        Me.lblDay7_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_5_1.TabIndex = 12
        Me.lblDay7_5_1.Tag = "5"
        '
        'lblDay7_4_1
        '
        Me.lblDay7_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay7_4_1.Name = "lblDay7_4_1"
        Me.lblDay7_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_4_1.TabIndex = 11
        Me.lblDay7_4_1.Tag = "4"
        '
        'lblDay7_3_1
        '
        Me.lblDay7_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay7_3_1.Name = "lblDay7_3_1"
        Me.lblDay7_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_3_1.TabIndex = 10
        Me.lblDay7_3_1.Tag = "3"
        '
        'lblDay7_2_1
        '
        Me.lblDay7_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay7_2_1.Name = "lblDay7_2_1"
        Me.lblDay7_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_2_1.TabIndex = 9
        Me.lblDay7_2_1.Tag = "2"
        '
        'lblDay7_1_1
        '
        Me.lblDay7_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay7_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay7_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay7_1_1.Name = "lblDay7_1_1"
        Me.lblDay7_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay7_1_1.TabIndex = 8
        Me.lblDay7_1_1.Tag = "1"
        '
        'lbl7_7
        '
        Me.lbl7_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_7.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_7.Name = "lbl7_7"
        Me.lbl7_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_7.TabIndex = 7
        Me.lbl7_7.Text = "Sat"
        Me.lbl7_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_7
        '
        Me.lbl6_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_7.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_7.Name = "lbl6_7"
        Me.lbl6_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_7.TabIndex = 6
        Me.lbl6_7.Text = "Fri"
        Me.lbl6_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_7
        '
        Me.lbl5_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_7.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_7.Name = "lbl5_7"
        Me.lbl5_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_7.TabIndex = 5
        Me.lbl5_7.Text = "Thu"
        Me.lbl5_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_7
        '
        Me.lbl4_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_7.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_7.Name = "lbl4_7"
        Me.lbl4_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_7.TabIndex = 4
        Me.lbl4_7.Text = "Wed"
        Me.lbl4_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_7
        '
        Me.lbl3_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_7.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_7.Name = "lbl3_7"
        Me.lbl3_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_7.TabIndex = 3
        Me.lbl3_7.Text = "Tue"
        Me.lbl3_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_7
        '
        Me.lbl2_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_7.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_7.Name = "lbl2_7"
        Me.lbl2_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_7.TabIndex = 2
        Me.lbl2_7.Text = "Mon"
        Me.lbl2_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_7
        '
        Me.lbl1_7.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_7.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_7.Name = "lbl1_7"
        Me.lbl1_7.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_7.TabIndex = 1
        Me.lbl1_7.Text = "Sun"
        Me.lbl1_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthJul
        '
        Me.lblMonthJul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthJul.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthJul.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthJul.Name = "lblMonthJul"
        Me.lblMonthJul.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthJul.TabIndex = 0
        Me.lblMonthJul.Text = "July"
        Me.lblMonthJul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth8
        '
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_6)
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_5)
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_4)
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_3)
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_2)
        Me.pnMonth8.Controls.Add(Me.lblDay8_7_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_6_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_5_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_4_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_3_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_2_1)
        Me.pnMonth8.Controls.Add(Me.lblDay8_1_1)
        Me.pnMonth8.Controls.Add(Me.lbl7_8)
        Me.pnMonth8.Controls.Add(Me.lbl6_8)
        Me.pnMonth8.Controls.Add(Me.lbl5_8)
        Me.pnMonth8.Controls.Add(Me.lbl4_8)
        Me.pnMonth8.Controls.Add(Me.lbl3_8)
        Me.pnMonth8.Controls.Add(Me.lbl2_8)
        Me.pnMonth8.Controls.Add(Me.lbl1_8)
        Me.pnMonth8.Controls.Add(Me.lblMonthAug)
        Me.pnMonth8.Location = New System.Drawing.Point(696, 280)
        Me.pnMonth8.Name = "pnMonth8"
        Me.pnMonth8.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth8.TabIndex = 17
        '
        'lblDay8_7_6
        '
        Me.lblDay8_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay8_7_6.Name = "lblDay8_7_6"
        Me.lblDay8_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_6.TabIndex = 49
        Me.lblDay8_7_6.Tag = "42"
        '
        'lblDay8_6_6
        '
        Me.lblDay8_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay8_6_6.Name = "lblDay8_6_6"
        Me.lblDay8_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_6.TabIndex = 48
        Me.lblDay8_6_6.Tag = "41"
        '
        'lblDay8_5_6
        '
        Me.lblDay8_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay8_5_6.Name = "lblDay8_5_6"
        Me.lblDay8_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_6.TabIndex = 47
        Me.lblDay8_5_6.Tag = "40"
        '
        'lblDay8_4_6
        '
        Me.lblDay8_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay8_4_6.Name = "lblDay8_4_6"
        Me.lblDay8_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_6.TabIndex = 46
        Me.lblDay8_4_6.Tag = "39"
        '
        'lblDay8_3_6
        '
        Me.lblDay8_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay8_3_6.Name = "lblDay8_3_6"
        Me.lblDay8_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_6.TabIndex = 45
        Me.lblDay8_3_6.Tag = "38"
        '
        'lblDay8_2_6
        '
        Me.lblDay8_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay8_2_6.Name = "lblDay8_2_6"
        Me.lblDay8_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_6.TabIndex = 44
        Me.lblDay8_2_6.Tag = "37"
        '
        'lblDay8_1_6
        '
        Me.lblDay8_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay8_1_6.Name = "lblDay8_1_6"
        Me.lblDay8_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_6.TabIndex = 43
        Me.lblDay8_1_6.Tag = "36"
        '
        'lblDay8_7_5
        '
        Me.lblDay8_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay8_7_5.Name = "lblDay8_7_5"
        Me.lblDay8_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_5.TabIndex = 42
        Me.lblDay8_7_5.Tag = "35"
        '
        'lblDay8_6_5
        '
        Me.lblDay8_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay8_6_5.Name = "lblDay8_6_5"
        Me.lblDay8_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_5.TabIndex = 41
        Me.lblDay8_6_5.Tag = "34"
        '
        'lblDay8_5_5
        '
        Me.lblDay8_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay8_5_5.Name = "lblDay8_5_5"
        Me.lblDay8_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_5.TabIndex = 40
        Me.lblDay8_5_5.Tag = "33"
        '
        'lblDay8_4_5
        '
        Me.lblDay8_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay8_4_5.Name = "lblDay8_4_5"
        Me.lblDay8_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_5.TabIndex = 39
        Me.lblDay8_4_5.Tag = "32"
        '
        'lblDay8_3_5
        '
        Me.lblDay8_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay8_3_5.Name = "lblDay8_3_5"
        Me.lblDay8_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_5.TabIndex = 38
        Me.lblDay8_3_5.Tag = "31"
        '
        'lblDay8_2_5
        '
        Me.lblDay8_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay8_2_5.Name = "lblDay8_2_5"
        Me.lblDay8_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_5.TabIndex = 37
        Me.lblDay8_2_5.Tag = "30"
        '
        'lblDay8_1_5
        '
        Me.lblDay8_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay8_1_5.Name = "lblDay8_1_5"
        Me.lblDay8_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_5.TabIndex = 36
        Me.lblDay8_1_5.Tag = "29"
        '
        'lblDay8_7_4
        '
        Me.lblDay8_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay8_7_4.Name = "lblDay8_7_4"
        Me.lblDay8_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_4.TabIndex = 35
        Me.lblDay8_7_4.Tag = "28"
        '
        'lblDay8_6_4
        '
        Me.lblDay8_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay8_6_4.Name = "lblDay8_6_4"
        Me.lblDay8_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_4.TabIndex = 34
        Me.lblDay8_6_4.Tag = "27"
        '
        'lblDay8_5_4
        '
        Me.lblDay8_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay8_5_4.Name = "lblDay8_5_4"
        Me.lblDay8_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_4.TabIndex = 33
        Me.lblDay8_5_4.Tag = "26"
        '
        'lblDay8_4_4
        '
        Me.lblDay8_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay8_4_4.Name = "lblDay8_4_4"
        Me.lblDay8_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_4.TabIndex = 32
        Me.lblDay8_4_4.Tag = "25"
        '
        'lblDay8_3_4
        '
        Me.lblDay8_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay8_3_4.Name = "lblDay8_3_4"
        Me.lblDay8_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_4.TabIndex = 31
        Me.lblDay8_3_4.Tag = "24"
        '
        'lblDay8_2_4
        '
        Me.lblDay8_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay8_2_4.Name = "lblDay8_2_4"
        Me.lblDay8_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_4.TabIndex = 30
        Me.lblDay8_2_4.Tag = "23"
        '
        'lblDay8_1_4
        '
        Me.lblDay8_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay8_1_4.Name = "lblDay8_1_4"
        Me.lblDay8_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_4.TabIndex = 29
        Me.lblDay8_1_4.Tag = "22"
        '
        'lblDay8_7_3
        '
        Me.lblDay8_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay8_7_3.Name = "lblDay8_7_3"
        Me.lblDay8_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_3.TabIndex = 28
        Me.lblDay8_7_3.Tag = "21"
        '
        'lblDay8_6_3
        '
        Me.lblDay8_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay8_6_3.Name = "lblDay8_6_3"
        Me.lblDay8_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_3.TabIndex = 27
        Me.lblDay8_6_3.Tag = "20"
        '
        'lblDay8_5_3
        '
        Me.lblDay8_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay8_5_3.Name = "lblDay8_5_3"
        Me.lblDay8_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_3.TabIndex = 26
        Me.lblDay8_5_3.Tag = "19"
        '
        'lblDay8_4_3
        '
        Me.lblDay8_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay8_4_3.Name = "lblDay8_4_3"
        Me.lblDay8_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_3.TabIndex = 25
        Me.lblDay8_4_3.Tag = "18"
        '
        'lblDay8_3_3
        '
        Me.lblDay8_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay8_3_3.Name = "lblDay8_3_3"
        Me.lblDay8_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_3.TabIndex = 24
        Me.lblDay8_3_3.Tag = "17"
        '
        'lblDay8_2_3
        '
        Me.lblDay8_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay8_2_3.Name = "lblDay8_2_3"
        Me.lblDay8_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_3.TabIndex = 23
        Me.lblDay8_2_3.Tag = "16"
        '
        'lblDay8_1_3
        '
        Me.lblDay8_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay8_1_3.Name = "lblDay8_1_3"
        Me.lblDay8_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_3.TabIndex = 22
        Me.lblDay8_1_3.Tag = "15"
        '
        'lblDay8_7_2
        '
        Me.lblDay8_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay8_7_2.Name = "lblDay8_7_2"
        Me.lblDay8_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_2.TabIndex = 21
        Me.lblDay8_7_2.Tag = "14"
        '
        'lblDay8_6_2
        '
        Me.lblDay8_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay8_6_2.Name = "lblDay8_6_2"
        Me.lblDay8_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_2.TabIndex = 20
        Me.lblDay8_6_2.Tag = "13"
        '
        'lblDay8_5_2
        '
        Me.lblDay8_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay8_5_2.Name = "lblDay8_5_2"
        Me.lblDay8_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_2.TabIndex = 19
        Me.lblDay8_5_2.Tag = "12"
        '
        'lblDay8_4_2
        '
        Me.lblDay8_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay8_4_2.Name = "lblDay8_4_2"
        Me.lblDay8_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_2.TabIndex = 18
        Me.lblDay8_4_2.Tag = "11"
        '
        'lblDay8_3_2
        '
        Me.lblDay8_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay8_3_2.Name = "lblDay8_3_2"
        Me.lblDay8_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_2.TabIndex = 17
        Me.lblDay8_3_2.Tag = "10"
        '
        'lblDay8_2_2
        '
        Me.lblDay8_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay8_2_2.Name = "lblDay8_2_2"
        Me.lblDay8_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_2.TabIndex = 16
        Me.lblDay8_2_2.Tag = "9"
        '
        'lblDay8_1_2
        '
        Me.lblDay8_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay8_1_2.Name = "lblDay8_1_2"
        Me.lblDay8_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_2.TabIndex = 15
        Me.lblDay8_1_2.Tag = "8"
        '
        'lblDay8_7_1
        '
        Me.lblDay8_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay8_7_1.Name = "lblDay8_7_1"
        Me.lblDay8_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_7_1.TabIndex = 14
        Me.lblDay8_7_1.Tag = "7"
        '
        'lblDay8_6_1
        '
        Me.lblDay8_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay8_6_1.Name = "lblDay8_6_1"
        Me.lblDay8_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_6_1.TabIndex = 13
        Me.lblDay8_6_1.Tag = "6"
        '
        'lblDay8_5_1
        '
        Me.lblDay8_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay8_5_1.Name = "lblDay8_5_1"
        Me.lblDay8_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_5_1.TabIndex = 12
        Me.lblDay8_5_1.Tag = "5"
        '
        'lblDay8_4_1
        '
        Me.lblDay8_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay8_4_1.Name = "lblDay8_4_1"
        Me.lblDay8_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_4_1.TabIndex = 11
        Me.lblDay8_4_1.Tag = "4"
        '
        'lblDay8_3_1
        '
        Me.lblDay8_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay8_3_1.Name = "lblDay8_3_1"
        Me.lblDay8_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_3_1.TabIndex = 10
        Me.lblDay8_3_1.Tag = "3"
        '
        'lblDay8_2_1
        '
        Me.lblDay8_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay8_2_1.Name = "lblDay8_2_1"
        Me.lblDay8_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_2_1.TabIndex = 9
        Me.lblDay8_2_1.Tag = "2"
        '
        'lblDay8_1_1
        '
        Me.lblDay8_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay8_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay8_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay8_1_1.Name = "lblDay8_1_1"
        Me.lblDay8_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay8_1_1.TabIndex = 8
        Me.lblDay8_1_1.Tag = "1"
        '
        'lbl7_8
        '
        Me.lbl7_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_8.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_8.Name = "lbl7_8"
        Me.lbl7_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_8.TabIndex = 7
        Me.lbl7_8.Text = "Sat"
        Me.lbl7_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_8
        '
        Me.lbl6_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_8.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_8.Name = "lbl6_8"
        Me.lbl6_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_8.TabIndex = 6
        Me.lbl6_8.Text = "Fri"
        Me.lbl6_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_8
        '
        Me.lbl5_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_8.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_8.Name = "lbl5_8"
        Me.lbl5_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_8.TabIndex = 5
        Me.lbl5_8.Text = "Thu"
        Me.lbl5_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_8
        '
        Me.lbl4_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_8.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_8.Name = "lbl4_8"
        Me.lbl4_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_8.TabIndex = 4
        Me.lbl4_8.Text = "Wed"
        Me.lbl4_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_8
        '
        Me.lbl3_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_8.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_8.Name = "lbl3_8"
        Me.lbl3_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_8.TabIndex = 3
        Me.lbl3_8.Text = "Tue"
        Me.lbl3_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_8
        '
        Me.lbl2_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_8.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_8.Name = "lbl2_8"
        Me.lbl2_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_8.TabIndex = 2
        Me.lbl2_8.Text = "Mon"
        Me.lbl2_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_8
        '
        Me.lbl1_8.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_8.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_8.Name = "lbl1_8"
        Me.lbl1_8.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_8.TabIndex = 1
        Me.lbl1_8.Text = "Sun"
        Me.lbl1_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthAug
        '
        Me.lblMonthAug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthAug.ForeColor = System.Drawing.Color.Purple
        Me.lblMonthAug.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthAug.Name = "lblMonthAug"
        Me.lblMonthAug.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthAug.TabIndex = 0
        Me.lblMonthAug.Text = "August"
        Me.lblMonthAug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth9
        '
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_6)
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_5)
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_4)
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_3)
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_2)
        Me.pnMonth9.Controls.Add(Me.lblDay9_7_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_6_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_5_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_4_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_3_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_2_1)
        Me.pnMonth9.Controls.Add(Me.lblDay9_1_1)
        Me.pnMonth9.Controls.Add(Me.lbl7_9)
        Me.pnMonth9.Controls.Add(Me.lbl6_9)
        Me.pnMonth9.Controls.Add(Me.lbl5_9)
        Me.pnMonth9.Controls.Add(Me.lbl4_9)
        Me.pnMonth9.Controls.Add(Me.lbl3_9)
        Me.pnMonth9.Controls.Add(Me.lbl2_9)
        Me.pnMonth9.Controls.Add(Me.lbl1_9)
        Me.pnMonth9.Controls.Add(Me.lblMonthSep)
        Me.pnMonth9.Location = New System.Drawing.Point(0, 472)
        Me.pnMonth9.Name = "pnMonth9"
        Me.pnMonth9.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth9.TabIndex = 18
        '
        'lblDay9_7_6
        '
        Me.lblDay9_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay9_7_6.Name = "lblDay9_7_6"
        Me.lblDay9_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_6.TabIndex = 49
        Me.lblDay9_7_6.Tag = "42"
        '
        'lblDay9_6_6
        '
        Me.lblDay9_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay9_6_6.Name = "lblDay9_6_6"
        Me.lblDay9_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_6.TabIndex = 48
        Me.lblDay9_6_6.Tag = "41"
        '
        'lblDay9_5_6
        '
        Me.lblDay9_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay9_5_6.Name = "lblDay9_5_6"
        Me.lblDay9_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_6.TabIndex = 47
        Me.lblDay9_5_6.Tag = "40"
        '
        'lblDay9_4_6
        '
        Me.lblDay9_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay9_4_6.Name = "lblDay9_4_6"
        Me.lblDay9_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_6.TabIndex = 46
        Me.lblDay9_4_6.Tag = "39"
        '
        'lblDay9_3_6
        '
        Me.lblDay9_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay9_3_6.Name = "lblDay9_3_6"
        Me.lblDay9_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_6.TabIndex = 45
        Me.lblDay9_3_6.Tag = "38"
        '
        'lblDay9_2_6
        '
        Me.lblDay9_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay9_2_6.Name = "lblDay9_2_6"
        Me.lblDay9_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_6.TabIndex = 44
        Me.lblDay9_2_6.Tag = "37"
        '
        'lblDay9_1_6
        '
        Me.lblDay9_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay9_1_6.Name = "lblDay9_1_6"
        Me.lblDay9_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_6.TabIndex = 43
        Me.lblDay9_1_6.Tag = "36"
        '
        'lblDay9_7_5
        '
        Me.lblDay9_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay9_7_5.Name = "lblDay9_7_5"
        Me.lblDay9_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_5.TabIndex = 42
        Me.lblDay9_7_5.Tag = "35"
        '
        'lblDay9_6_5
        '
        Me.lblDay9_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay9_6_5.Name = "lblDay9_6_5"
        Me.lblDay9_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_5.TabIndex = 41
        Me.lblDay9_6_5.Tag = "34"
        '
        'lblDay9_5_5
        '
        Me.lblDay9_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay9_5_5.Name = "lblDay9_5_5"
        Me.lblDay9_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_5.TabIndex = 40
        Me.lblDay9_5_5.Tag = "33"
        '
        'lblDay9_4_5
        '
        Me.lblDay9_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay9_4_5.Name = "lblDay9_4_5"
        Me.lblDay9_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_5.TabIndex = 39
        Me.lblDay9_4_5.Tag = "32"
        '
        'lblDay9_3_5
        '
        Me.lblDay9_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay9_3_5.Name = "lblDay9_3_5"
        Me.lblDay9_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_5.TabIndex = 38
        Me.lblDay9_3_5.Tag = "31"
        '
        'lblDay9_2_5
        '
        Me.lblDay9_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay9_2_5.Name = "lblDay9_2_5"
        Me.lblDay9_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_5.TabIndex = 37
        Me.lblDay9_2_5.Tag = "30"
        '
        'lblDay9_1_5
        '
        Me.lblDay9_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay9_1_5.Name = "lblDay9_1_5"
        Me.lblDay9_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_5.TabIndex = 36
        Me.lblDay9_1_5.Tag = "29"
        '
        'lblDay9_7_4
        '
        Me.lblDay9_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay9_7_4.Name = "lblDay9_7_4"
        Me.lblDay9_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_4.TabIndex = 35
        Me.lblDay9_7_4.Tag = "28"
        '
        'lblDay9_6_4
        '
        Me.lblDay9_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay9_6_4.Name = "lblDay9_6_4"
        Me.lblDay9_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_4.TabIndex = 34
        Me.lblDay9_6_4.Tag = "27"
        '
        'lblDay9_5_4
        '
        Me.lblDay9_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay9_5_4.Name = "lblDay9_5_4"
        Me.lblDay9_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_4.TabIndex = 33
        Me.lblDay9_5_4.Tag = "26"
        '
        'lblDay9_4_4
        '
        Me.lblDay9_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay9_4_4.Name = "lblDay9_4_4"
        Me.lblDay9_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_4.TabIndex = 32
        Me.lblDay9_4_4.Tag = "25"
        '
        'lblDay9_3_4
        '
        Me.lblDay9_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay9_3_4.Name = "lblDay9_3_4"
        Me.lblDay9_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_4.TabIndex = 31
        Me.lblDay9_3_4.Tag = "24"
        '
        'lblDay9_2_4
        '
        Me.lblDay9_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay9_2_4.Name = "lblDay9_2_4"
        Me.lblDay9_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_4.TabIndex = 30
        Me.lblDay9_2_4.Tag = "23"
        '
        'lblDay9_1_4
        '
        Me.lblDay9_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay9_1_4.Name = "lblDay9_1_4"
        Me.lblDay9_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_4.TabIndex = 29
        Me.lblDay9_1_4.Tag = "22"
        '
        'lblDay9_7_3
        '
        Me.lblDay9_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay9_7_3.Name = "lblDay9_7_3"
        Me.lblDay9_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_3.TabIndex = 28
        Me.lblDay9_7_3.Tag = "21"
        '
        'lblDay9_6_3
        '
        Me.lblDay9_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay9_6_3.Name = "lblDay9_6_3"
        Me.lblDay9_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_3.TabIndex = 27
        Me.lblDay9_6_3.Tag = "20"
        '
        'lblDay9_5_3
        '
        Me.lblDay9_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay9_5_3.Name = "lblDay9_5_3"
        Me.lblDay9_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_3.TabIndex = 26
        Me.lblDay9_5_3.Tag = "19"
        '
        'lblDay9_4_3
        '
        Me.lblDay9_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay9_4_3.Name = "lblDay9_4_3"
        Me.lblDay9_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_3.TabIndex = 25
        Me.lblDay9_4_3.Tag = "18"
        '
        'lblDay9_3_3
        '
        Me.lblDay9_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay9_3_3.Name = "lblDay9_3_3"
        Me.lblDay9_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_3.TabIndex = 24
        Me.lblDay9_3_3.Tag = "17"
        '
        'lblDay9_2_3
        '
        Me.lblDay9_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay9_2_3.Name = "lblDay9_2_3"
        Me.lblDay9_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_3.TabIndex = 23
        Me.lblDay9_2_3.Tag = "16"
        '
        'lblDay9_1_3
        '
        Me.lblDay9_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay9_1_3.Name = "lblDay9_1_3"
        Me.lblDay9_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_3.TabIndex = 22
        Me.lblDay9_1_3.Tag = "15"
        '
        'lblDay9_7_2
        '
        Me.lblDay9_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay9_7_2.Name = "lblDay9_7_2"
        Me.lblDay9_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_2.TabIndex = 21
        Me.lblDay9_7_2.Tag = "14"
        '
        'lblDay9_6_2
        '
        Me.lblDay9_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay9_6_2.Name = "lblDay9_6_2"
        Me.lblDay9_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_2.TabIndex = 20
        Me.lblDay9_6_2.Tag = "13"
        '
        'lblDay9_5_2
        '
        Me.lblDay9_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay9_5_2.Name = "lblDay9_5_2"
        Me.lblDay9_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_2.TabIndex = 19
        Me.lblDay9_5_2.Tag = "12"
        '
        'lblDay9_4_2
        '
        Me.lblDay9_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay9_4_2.Name = "lblDay9_4_2"
        Me.lblDay9_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_2.TabIndex = 18
        Me.lblDay9_4_2.Tag = "11"
        '
        'lblDay9_3_2
        '
        Me.lblDay9_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay9_3_2.Name = "lblDay9_3_2"
        Me.lblDay9_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_2.TabIndex = 17
        Me.lblDay9_3_2.Tag = "10"
        '
        'lblDay9_2_2
        '
        Me.lblDay9_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay9_2_2.Name = "lblDay9_2_2"
        Me.lblDay9_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_2.TabIndex = 16
        Me.lblDay9_2_2.Tag = "9"
        '
        'lblDay9_1_2
        '
        Me.lblDay9_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay9_1_2.Name = "lblDay9_1_2"
        Me.lblDay9_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_2.TabIndex = 15
        Me.lblDay9_1_2.Tag = "8"
        '
        'lblDay9_7_1
        '
        Me.lblDay9_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay9_7_1.Name = "lblDay9_7_1"
        Me.lblDay9_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_7_1.TabIndex = 14
        Me.lblDay9_7_1.Tag = "7"
        '
        'lblDay9_6_1
        '
        Me.lblDay9_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay9_6_1.Name = "lblDay9_6_1"
        Me.lblDay9_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_6_1.TabIndex = 13
        Me.lblDay9_6_1.Tag = "6"
        '
        'lblDay9_5_1
        '
        Me.lblDay9_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay9_5_1.Name = "lblDay9_5_1"
        Me.lblDay9_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_5_1.TabIndex = 12
        Me.lblDay9_5_1.Tag = "5"
        '
        'lblDay9_4_1
        '
        Me.lblDay9_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay9_4_1.Name = "lblDay9_4_1"
        Me.lblDay9_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_4_1.TabIndex = 11
        Me.lblDay9_4_1.Tag = "4"
        '
        'lblDay9_3_1
        '
        Me.lblDay9_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay9_3_1.Name = "lblDay9_3_1"
        Me.lblDay9_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_3_1.TabIndex = 10
        Me.lblDay9_3_1.Tag = "3"
        '
        'lblDay9_2_1
        '
        Me.lblDay9_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay9_2_1.Name = "lblDay9_2_1"
        Me.lblDay9_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_2_1.TabIndex = 9
        Me.lblDay9_2_1.Tag = "2"
        '
        'lblDay9_1_1
        '
        Me.lblDay9_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay9_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay9_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay9_1_1.Name = "lblDay9_1_1"
        Me.lblDay9_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay9_1_1.TabIndex = 8
        Me.lblDay9_1_1.Tag = "1"
        '
        'lbl7_9
        '
        Me.lbl7_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_9.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_9.Name = "lbl7_9"
        Me.lbl7_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_9.TabIndex = 7
        Me.lbl7_9.Text = "Sat"
        Me.lbl7_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_9
        '
        Me.lbl6_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_9.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_9.Name = "lbl6_9"
        Me.lbl6_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_9.TabIndex = 6
        Me.lbl6_9.Text = "Fri"
        Me.lbl6_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_9
        '
        Me.lbl5_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_9.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_9.Name = "lbl5_9"
        Me.lbl5_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_9.TabIndex = 5
        Me.lbl5_9.Text = "Thu"
        Me.lbl5_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_9
        '
        Me.lbl4_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_9.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_9.Name = "lbl4_9"
        Me.lbl4_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_9.TabIndex = 4
        Me.lbl4_9.Text = "Wed"
        Me.lbl4_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_9
        '
        Me.lbl3_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_9.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_9.Name = "lbl3_9"
        Me.lbl3_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_9.TabIndex = 3
        Me.lbl3_9.Text = "Tue"
        Me.lbl3_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_9
        '
        Me.lbl2_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_9.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_9.Name = "lbl2_9"
        Me.lbl2_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_9.TabIndex = 2
        Me.lbl2_9.Text = "Mon"
        Me.lbl2_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_9
        '
        Me.lbl1_9.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_9.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_9.Name = "lbl1_9"
        Me.lbl1_9.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_9.TabIndex = 1
        Me.lbl1_9.Text = "Sun"
        Me.lbl1_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthSep
        '
        Me.lblMonthSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthSep.ForeColor = System.Drawing.Color.Navy
        Me.lblMonthSep.Location = New System.Drawing.Point(80, 8)
        Me.lblMonthSep.Name = "lblMonthSep"
        Me.lblMonthSep.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthSep.TabIndex = 0
        Me.lblMonthSep.Text = "September"
        Me.lblMonthSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth10
        '
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_6)
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_5)
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_4)
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_3)
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_2)
        Me.pnMonth10.Controls.Add(Me.lblDay10_7_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_6_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_5_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_4_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_3_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_2_1)
        Me.pnMonth10.Controls.Add(Me.lblDay10_1_1)
        Me.pnMonth10.Controls.Add(Me.lbl7_10)
        Me.pnMonth10.Controls.Add(Me.lbl6_10)
        Me.pnMonth10.Controls.Add(Me.lbl5_10)
        Me.pnMonth10.Controls.Add(Me.lbl4_10)
        Me.pnMonth10.Controls.Add(Me.lbl3_10)
        Me.pnMonth10.Controls.Add(Me.lbl2_10)
        Me.pnMonth10.Controls.Add(Me.lbl1_10)
        Me.pnMonth10.Controls.Add(Me.lblMonthOct)
        Me.pnMonth10.Location = New System.Drawing.Point(232, 472)
        Me.pnMonth10.Name = "pnMonth10"
        Me.pnMonth10.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth10.TabIndex = 19
        '
        'lblDay10_7_6
        '
        Me.lblDay10_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay10_7_6.Name = "lblDay10_7_6"
        Me.lblDay10_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_6.TabIndex = 49
        Me.lblDay10_7_6.Tag = "42"
        '
        'lblDay10_6_6
        '
        Me.lblDay10_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay10_6_6.Name = "lblDay10_6_6"
        Me.lblDay10_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_6.TabIndex = 48
        Me.lblDay10_6_6.Tag = "41"
        '
        'lblDay10_5_6
        '
        Me.lblDay10_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay10_5_6.Name = "lblDay10_5_6"
        Me.lblDay10_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_6.TabIndex = 47
        Me.lblDay10_5_6.Tag = "40"
        '
        'lblDay10_4_6
        '
        Me.lblDay10_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay10_4_6.Name = "lblDay10_4_6"
        Me.lblDay10_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_6.TabIndex = 46
        Me.lblDay10_4_6.Tag = "39"
        '
        'lblDay10_3_6
        '
        Me.lblDay10_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay10_3_6.Name = "lblDay10_3_6"
        Me.lblDay10_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_6.TabIndex = 45
        Me.lblDay10_3_6.Tag = "38"
        '
        'lblDay10_2_6
        '
        Me.lblDay10_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay10_2_6.Name = "lblDay10_2_6"
        Me.lblDay10_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_6.TabIndex = 44
        Me.lblDay10_2_6.Tag = "37"
        '
        'lblDay10_1_6
        '
        Me.lblDay10_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay10_1_6.Name = "lblDay10_1_6"
        Me.lblDay10_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_6.TabIndex = 43
        Me.lblDay10_1_6.Tag = "36"
        '
        'lblDay10_7_5
        '
        Me.lblDay10_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay10_7_5.Name = "lblDay10_7_5"
        Me.lblDay10_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_5.TabIndex = 42
        Me.lblDay10_7_5.Tag = "35"
        '
        'lblDay10_6_5
        '
        Me.lblDay10_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay10_6_5.Name = "lblDay10_6_5"
        Me.lblDay10_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_5.TabIndex = 41
        Me.lblDay10_6_5.Tag = "34"
        '
        'lblDay10_5_5
        '
        Me.lblDay10_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay10_5_5.Name = "lblDay10_5_5"
        Me.lblDay10_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_5.TabIndex = 40
        Me.lblDay10_5_5.Tag = "33"
        '
        'lblDay10_4_5
        '
        Me.lblDay10_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay10_4_5.Name = "lblDay10_4_5"
        Me.lblDay10_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_5.TabIndex = 39
        Me.lblDay10_4_5.Tag = "32"
        '
        'lblDay10_3_5
        '
        Me.lblDay10_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay10_3_5.Name = "lblDay10_3_5"
        Me.lblDay10_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_5.TabIndex = 38
        Me.lblDay10_3_5.Tag = "31"
        '
        'lblDay10_2_5
        '
        Me.lblDay10_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay10_2_5.Name = "lblDay10_2_5"
        Me.lblDay10_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_5.TabIndex = 37
        Me.lblDay10_2_5.Tag = "30"
        '
        'lblDay10_1_5
        '
        Me.lblDay10_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay10_1_5.Name = "lblDay10_1_5"
        Me.lblDay10_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_5.TabIndex = 36
        Me.lblDay10_1_5.Tag = "29"
        '
        'lblDay10_7_4
        '
        Me.lblDay10_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay10_7_4.Name = "lblDay10_7_4"
        Me.lblDay10_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_4.TabIndex = 35
        Me.lblDay10_7_4.Tag = "28"
        '
        'lblDay10_6_4
        '
        Me.lblDay10_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay10_6_4.Name = "lblDay10_6_4"
        Me.lblDay10_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_4.TabIndex = 34
        Me.lblDay10_6_4.Tag = "27"
        '
        'lblDay10_5_4
        '
        Me.lblDay10_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay10_5_4.Name = "lblDay10_5_4"
        Me.lblDay10_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_4.TabIndex = 33
        Me.lblDay10_5_4.Tag = "26"
        '
        'lblDay10_4_4
        '
        Me.lblDay10_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay10_4_4.Name = "lblDay10_4_4"
        Me.lblDay10_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_4.TabIndex = 32
        Me.lblDay10_4_4.Tag = "25"
        '
        'lblDay10_3_4
        '
        Me.lblDay10_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay10_3_4.Name = "lblDay10_3_4"
        Me.lblDay10_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_4.TabIndex = 31
        Me.lblDay10_3_4.Tag = "24"
        '
        'lblDay10_2_4
        '
        Me.lblDay10_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay10_2_4.Name = "lblDay10_2_4"
        Me.lblDay10_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_4.TabIndex = 30
        Me.lblDay10_2_4.Tag = "23"
        '
        'lblDay10_1_4
        '
        Me.lblDay10_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay10_1_4.Name = "lblDay10_1_4"
        Me.lblDay10_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_4.TabIndex = 29
        Me.lblDay10_1_4.Tag = "22"
        '
        'lblDay10_7_3
        '
        Me.lblDay10_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay10_7_3.Name = "lblDay10_7_3"
        Me.lblDay10_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_3.TabIndex = 28
        Me.lblDay10_7_3.Tag = "21"
        '
        'lblDay10_6_3
        '
        Me.lblDay10_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay10_6_3.Name = "lblDay10_6_3"
        Me.lblDay10_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_3.TabIndex = 27
        Me.lblDay10_6_3.Tag = "20"
        '
        'lblDay10_5_3
        '
        Me.lblDay10_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay10_5_3.Name = "lblDay10_5_3"
        Me.lblDay10_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_3.TabIndex = 26
        Me.lblDay10_5_3.Tag = "19"
        '
        'lblDay10_4_3
        '
        Me.lblDay10_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay10_4_3.Name = "lblDay10_4_3"
        Me.lblDay10_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_3.TabIndex = 25
        Me.lblDay10_4_3.Tag = "18"
        '
        'lblDay10_3_3
        '
        Me.lblDay10_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay10_3_3.Name = "lblDay10_3_3"
        Me.lblDay10_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_3.TabIndex = 24
        Me.lblDay10_3_3.Tag = "17"
        '
        'lblDay10_2_3
        '
        Me.lblDay10_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay10_2_3.Name = "lblDay10_2_3"
        Me.lblDay10_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_3.TabIndex = 23
        Me.lblDay10_2_3.Tag = "16"
        '
        'lblDay10_1_3
        '
        Me.lblDay10_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay10_1_3.Name = "lblDay10_1_3"
        Me.lblDay10_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_3.TabIndex = 22
        Me.lblDay10_1_3.Tag = "15"
        '
        'lblDay10_7_2
        '
        Me.lblDay10_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay10_7_2.Name = "lblDay10_7_2"
        Me.lblDay10_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_2.TabIndex = 21
        Me.lblDay10_7_2.Tag = "14"
        '
        'lblDay10_6_2
        '
        Me.lblDay10_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay10_6_2.Name = "lblDay10_6_2"
        Me.lblDay10_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_2.TabIndex = 20
        Me.lblDay10_6_2.Tag = "13"
        '
        'lblDay10_5_2
        '
        Me.lblDay10_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay10_5_2.Name = "lblDay10_5_2"
        Me.lblDay10_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_2.TabIndex = 19
        Me.lblDay10_5_2.Tag = "12"
        '
        'lblDay10_4_2
        '
        Me.lblDay10_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay10_4_2.Name = "lblDay10_4_2"
        Me.lblDay10_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_2.TabIndex = 18
        Me.lblDay10_4_2.Tag = "11"
        '
        'lblDay10_3_2
        '
        Me.lblDay10_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay10_3_2.Name = "lblDay10_3_2"
        Me.lblDay10_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_2.TabIndex = 17
        Me.lblDay10_3_2.Tag = "10"
        '
        'lblDay10_2_2
        '
        Me.lblDay10_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay10_2_2.Name = "lblDay10_2_2"
        Me.lblDay10_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_2.TabIndex = 16
        Me.lblDay10_2_2.Tag = "9"
        '
        'lblDay10_1_2
        '
        Me.lblDay10_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay10_1_2.Name = "lblDay10_1_2"
        Me.lblDay10_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_2.TabIndex = 15
        Me.lblDay10_1_2.Tag = "8"
        '
        'lblDay10_7_1
        '
        Me.lblDay10_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay10_7_1.Name = "lblDay10_7_1"
        Me.lblDay10_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_7_1.TabIndex = 14
        Me.lblDay10_7_1.Tag = "7"
        '
        'lblDay10_6_1
        '
        Me.lblDay10_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay10_6_1.Name = "lblDay10_6_1"
        Me.lblDay10_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_6_1.TabIndex = 13
        Me.lblDay10_6_1.Tag = "6"
        '
        'lblDay10_5_1
        '
        Me.lblDay10_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay10_5_1.Name = "lblDay10_5_1"
        Me.lblDay10_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_5_1.TabIndex = 12
        Me.lblDay10_5_1.Tag = "5"
        '
        'lblDay10_4_1
        '
        Me.lblDay10_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay10_4_1.Name = "lblDay10_4_1"
        Me.lblDay10_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_4_1.TabIndex = 11
        Me.lblDay10_4_1.Tag = "4"
        '
        'lblDay10_3_1
        '
        Me.lblDay10_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay10_3_1.Name = "lblDay10_3_1"
        Me.lblDay10_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_3_1.TabIndex = 10
        Me.lblDay10_3_1.Tag = "3"
        '
        'lblDay10_2_1
        '
        Me.lblDay10_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay10_2_1.Name = "lblDay10_2_1"
        Me.lblDay10_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_2_1.TabIndex = 9
        Me.lblDay10_2_1.Tag = "2"
        '
        'lblDay10_1_1
        '
        Me.lblDay10_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay10_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay10_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay10_1_1.Name = "lblDay10_1_1"
        Me.lblDay10_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay10_1_1.TabIndex = 8
        Me.lblDay10_1_1.Tag = "1"
        '
        'lbl7_10
        '
        Me.lbl7_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_10.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_10.Name = "lbl7_10"
        Me.lbl7_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_10.TabIndex = 7
        Me.lbl7_10.Text = "Sat"
        Me.lbl7_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_10
        '
        Me.lbl6_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_10.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_10.Name = "lbl6_10"
        Me.lbl6_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_10.TabIndex = 6
        Me.lbl6_10.Text = "Fri"
        Me.lbl6_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_10
        '
        Me.lbl5_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_10.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_10.Name = "lbl5_10"
        Me.lbl5_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_10.TabIndex = 5
        Me.lbl5_10.Text = "Thu"
        Me.lbl5_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_10
        '
        Me.lbl4_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_10.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_10.Name = "lbl4_10"
        Me.lbl4_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_10.TabIndex = 4
        Me.lbl4_10.Text = "Wed"
        Me.lbl4_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_10
        '
        Me.lbl3_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_10.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_10.Name = "lbl3_10"
        Me.lbl3_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_10.TabIndex = 3
        Me.lbl3_10.Text = "Tue"
        Me.lbl3_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_10
        '
        Me.lbl2_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_10.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_10.Name = "lbl2_10"
        Me.lbl2_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_10.TabIndex = 2
        Me.lbl2_10.Text = "Mon"
        Me.lbl2_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_10
        '
        Me.lbl1_10.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_10.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_10.Name = "lbl1_10"
        Me.lbl1_10.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_10.TabIndex = 1
        Me.lbl1_10.Text = "Sun"
        Me.lbl1_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthOct
        '
        Me.lblMonthOct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthOct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthOct.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthOct.Name = "lblMonthOct"
        Me.lblMonthOct.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthOct.TabIndex = 0
        Me.lblMonthOct.Text = "October"
        Me.lblMonthOct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth11
        '
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_6)
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_5)
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_4)
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_3)
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_2)
        Me.pnMonth11.Controls.Add(Me.lblDay11_7_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_6_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_5_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_4_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_3_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_2_1)
        Me.pnMonth11.Controls.Add(Me.lblDay11_1_1)
        Me.pnMonth11.Controls.Add(Me.lbl7_11)
        Me.pnMonth11.Controls.Add(Me.lbl6_11)
        Me.pnMonth11.Controls.Add(Me.lbl5_11)
        Me.pnMonth11.Controls.Add(Me.lbl4_11)
        Me.pnMonth11.Controls.Add(Me.lbl3_11)
        Me.pnMonth11.Controls.Add(Me.lbl2_11)
        Me.pnMonth11.Controls.Add(Me.lbl1_11)
        Me.pnMonth11.Controls.Add(Me.lblMonthNov)
        Me.pnMonth11.Location = New System.Drawing.Point(464, 472)
        Me.pnMonth11.Name = "pnMonth11"
        Me.pnMonth11.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth11.TabIndex = 20
        '
        'lblDay11_7_6
        '
        Me.lblDay11_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay11_7_6.Name = "lblDay11_7_6"
        Me.lblDay11_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_6.TabIndex = 49
        Me.lblDay11_7_6.Tag = "42"
        '
        'lblDay11_6_6
        '
        Me.lblDay11_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay11_6_6.Name = "lblDay11_6_6"
        Me.lblDay11_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_6.TabIndex = 48
        Me.lblDay11_6_6.Tag = "41"
        '
        'lblDay11_5_6
        '
        Me.lblDay11_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay11_5_6.Name = "lblDay11_5_6"
        Me.lblDay11_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_6.TabIndex = 47
        Me.lblDay11_5_6.Tag = "40"
        '
        'lblDay11_4_6
        '
        Me.lblDay11_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay11_4_6.Name = "lblDay11_4_6"
        Me.lblDay11_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_6.TabIndex = 46
        Me.lblDay11_4_6.Tag = "39"
        '
        'lblDay11_3_6
        '
        Me.lblDay11_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay11_3_6.Name = "lblDay11_3_6"
        Me.lblDay11_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_6.TabIndex = 45
        Me.lblDay11_3_6.Tag = "38"
        '
        'lblDay11_2_6
        '
        Me.lblDay11_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay11_2_6.Name = "lblDay11_2_6"
        Me.lblDay11_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_6.TabIndex = 44
        Me.lblDay11_2_6.Tag = "37"
        '
        'lblDay11_1_6
        '
        Me.lblDay11_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay11_1_6.Name = "lblDay11_1_6"
        Me.lblDay11_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_6.TabIndex = 43
        Me.lblDay11_1_6.Tag = "36"
        '
        'lblDay11_7_5
        '
        Me.lblDay11_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay11_7_5.Name = "lblDay11_7_5"
        Me.lblDay11_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_5.TabIndex = 42
        Me.lblDay11_7_5.Tag = "35"
        '
        'lblDay11_6_5
        '
        Me.lblDay11_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay11_6_5.Name = "lblDay11_6_5"
        Me.lblDay11_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_5.TabIndex = 41
        Me.lblDay11_6_5.Tag = "34"
        '
        'lblDay11_5_5
        '
        Me.lblDay11_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay11_5_5.Name = "lblDay11_5_5"
        Me.lblDay11_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_5.TabIndex = 40
        Me.lblDay11_5_5.Tag = "33"
        '
        'lblDay11_4_5
        '
        Me.lblDay11_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay11_4_5.Name = "lblDay11_4_5"
        Me.lblDay11_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_5.TabIndex = 39
        Me.lblDay11_4_5.Tag = "32"
        '
        'lblDay11_3_5
        '
        Me.lblDay11_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay11_3_5.Name = "lblDay11_3_5"
        Me.lblDay11_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_5.TabIndex = 38
        Me.lblDay11_3_5.Tag = "31"
        '
        'lblDay11_2_5
        '
        Me.lblDay11_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay11_2_5.Name = "lblDay11_2_5"
        Me.lblDay11_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_5.TabIndex = 37
        Me.lblDay11_2_5.Tag = "30"
        '
        'lblDay11_1_5
        '
        Me.lblDay11_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay11_1_5.Name = "lblDay11_1_5"
        Me.lblDay11_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_5.TabIndex = 36
        Me.lblDay11_1_5.Tag = "29"
        '
        'lblDay11_7_4
        '
        Me.lblDay11_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay11_7_4.Name = "lblDay11_7_4"
        Me.lblDay11_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_4.TabIndex = 35
        Me.lblDay11_7_4.Tag = "28"
        '
        'lblDay11_6_4
        '
        Me.lblDay11_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay11_6_4.Name = "lblDay11_6_4"
        Me.lblDay11_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_4.TabIndex = 34
        Me.lblDay11_6_4.Tag = "27"
        '
        'lblDay11_5_4
        '
        Me.lblDay11_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay11_5_4.Name = "lblDay11_5_4"
        Me.lblDay11_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_4.TabIndex = 33
        Me.lblDay11_5_4.Tag = "26"
        '
        'lblDay11_4_4
        '
        Me.lblDay11_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay11_4_4.Name = "lblDay11_4_4"
        Me.lblDay11_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_4.TabIndex = 32
        Me.lblDay11_4_4.Tag = "25"
        '
        'lblDay11_3_4
        '
        Me.lblDay11_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay11_3_4.Name = "lblDay11_3_4"
        Me.lblDay11_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_4.TabIndex = 31
        Me.lblDay11_3_4.Tag = "24"
        '
        'lblDay11_2_4
        '
        Me.lblDay11_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay11_2_4.Name = "lblDay11_2_4"
        Me.lblDay11_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_4.TabIndex = 30
        Me.lblDay11_2_4.Tag = "23"
        '
        'lblDay11_1_4
        '
        Me.lblDay11_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay11_1_4.Name = "lblDay11_1_4"
        Me.lblDay11_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_4.TabIndex = 29
        Me.lblDay11_1_4.Tag = "22"
        '
        'lblDay11_7_3
        '
        Me.lblDay11_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay11_7_3.Name = "lblDay11_7_3"
        Me.lblDay11_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_3.TabIndex = 28
        Me.lblDay11_7_3.Tag = "21"
        '
        'lblDay11_6_3
        '
        Me.lblDay11_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay11_6_3.Name = "lblDay11_6_3"
        Me.lblDay11_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_3.TabIndex = 27
        Me.lblDay11_6_3.Tag = "20"
        '
        'lblDay11_5_3
        '
        Me.lblDay11_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay11_5_3.Name = "lblDay11_5_3"
        Me.lblDay11_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_3.TabIndex = 26
        Me.lblDay11_5_3.Tag = "19"
        '
        'lblDay11_4_3
        '
        Me.lblDay11_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay11_4_3.Name = "lblDay11_4_3"
        Me.lblDay11_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_3.TabIndex = 25
        Me.lblDay11_4_3.Tag = "18"
        '
        'lblDay11_3_3
        '
        Me.lblDay11_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay11_3_3.Name = "lblDay11_3_3"
        Me.lblDay11_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_3.TabIndex = 24
        Me.lblDay11_3_3.Tag = "17"
        '
        'lblDay11_2_3
        '
        Me.lblDay11_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay11_2_3.Name = "lblDay11_2_3"
        Me.lblDay11_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_3.TabIndex = 23
        Me.lblDay11_2_3.Tag = "16"
        '
        'lblDay11_1_3
        '
        Me.lblDay11_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay11_1_3.Name = "lblDay11_1_3"
        Me.lblDay11_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_3.TabIndex = 22
        Me.lblDay11_1_3.Tag = "15"
        '
        'lblDay11_7_2
        '
        Me.lblDay11_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay11_7_2.Name = "lblDay11_7_2"
        Me.lblDay11_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_2.TabIndex = 21
        Me.lblDay11_7_2.Tag = "14"
        '
        'lblDay11_6_2
        '
        Me.lblDay11_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay11_6_2.Name = "lblDay11_6_2"
        Me.lblDay11_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_2.TabIndex = 20
        Me.lblDay11_6_2.Tag = "13"
        '
        'lblDay11_5_2
        '
        Me.lblDay11_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay11_5_2.Name = "lblDay11_5_2"
        Me.lblDay11_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_2.TabIndex = 19
        Me.lblDay11_5_2.Tag = "12"
        '
        'lblDay11_4_2
        '
        Me.lblDay11_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay11_4_2.Name = "lblDay11_4_2"
        Me.lblDay11_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_2.TabIndex = 18
        Me.lblDay11_4_2.Tag = "11"
        '
        'lblDay11_3_2
        '
        Me.lblDay11_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay11_3_2.Name = "lblDay11_3_2"
        Me.lblDay11_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_2.TabIndex = 17
        Me.lblDay11_3_2.Tag = "10"
        '
        'lblDay11_2_2
        '
        Me.lblDay11_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay11_2_2.Name = "lblDay11_2_2"
        Me.lblDay11_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_2.TabIndex = 16
        Me.lblDay11_2_2.Tag = "9"
        '
        'lblDay11_1_2
        '
        Me.lblDay11_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay11_1_2.Name = "lblDay11_1_2"
        Me.lblDay11_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_2.TabIndex = 15
        Me.lblDay11_1_2.Tag = "8"
        '
        'lblDay11_7_1
        '
        Me.lblDay11_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay11_7_1.Name = "lblDay11_7_1"
        Me.lblDay11_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_7_1.TabIndex = 14
        Me.lblDay11_7_1.Tag = "7"
        '
        'lblDay11_6_1
        '
        Me.lblDay11_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay11_6_1.Name = "lblDay11_6_1"
        Me.lblDay11_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_6_1.TabIndex = 13
        Me.lblDay11_6_1.Tag = "6"
        '
        'lblDay11_5_1
        '
        Me.lblDay11_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay11_5_1.Name = "lblDay11_5_1"
        Me.lblDay11_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_5_1.TabIndex = 12
        Me.lblDay11_5_1.Tag = "5"
        '
        'lblDay11_4_1
        '
        Me.lblDay11_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay11_4_1.Name = "lblDay11_4_1"
        Me.lblDay11_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_4_1.TabIndex = 11
        Me.lblDay11_4_1.Tag = "4"
        '
        'lblDay11_3_1
        '
        Me.lblDay11_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay11_3_1.Name = "lblDay11_3_1"
        Me.lblDay11_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_3_1.TabIndex = 10
        Me.lblDay11_3_1.Tag = "3"
        '
        'lblDay11_2_1
        '
        Me.lblDay11_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay11_2_1.Name = "lblDay11_2_1"
        Me.lblDay11_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_2_1.TabIndex = 9
        Me.lblDay11_2_1.Tag = "2"
        '
        'lblDay11_1_1
        '
        Me.lblDay11_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay11_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay11_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay11_1_1.Name = "lblDay11_1_1"
        Me.lblDay11_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay11_1_1.TabIndex = 8
        Me.lblDay11_1_1.Tag = "1"
        '
        'lbl7_11
        '
        Me.lbl7_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_11.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_11.Name = "lbl7_11"
        Me.lbl7_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_11.TabIndex = 7
        Me.lbl7_11.Text = "Sat"
        Me.lbl7_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_11
        '
        Me.lbl6_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_11.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_11.Name = "lbl6_11"
        Me.lbl6_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_11.TabIndex = 6
        Me.lbl6_11.Text = "Fri"
        Me.lbl6_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_11
        '
        Me.lbl5_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_11.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_11.Name = "lbl5_11"
        Me.lbl5_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_11.TabIndex = 5
        Me.lbl5_11.Text = "Thu"
        Me.lbl5_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_11
        '
        Me.lbl4_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_11.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_11.Name = "lbl4_11"
        Me.lbl4_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_11.TabIndex = 4
        Me.lbl4_11.Text = "Wed"
        Me.lbl4_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_11
        '
        Me.lbl3_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_11.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_11.Name = "lbl3_11"
        Me.lbl3_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_11.TabIndex = 3
        Me.lbl3_11.Text = "Tue"
        Me.lbl3_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_11
        '
        Me.lbl2_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_11.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_11.Name = "lbl2_11"
        Me.lbl2_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_11.TabIndex = 2
        Me.lbl2_11.Text = "Mon"
        Me.lbl2_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_11
        '
        Me.lbl1_11.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_11.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_11.Name = "lbl1_11"
        Me.lbl1_11.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_11.TabIndex = 1
        Me.lbl1_11.Text = "Sun"
        Me.lbl1_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthNov
        '
        Me.lblMonthNov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthNov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonthNov.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthNov.Name = "lblMonthNov"
        Me.lblMonthNov.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthNov.TabIndex = 0
        Me.lblMonthNov.Text = "November"
        Me.lblMonthNov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMonth12
        '
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_6)
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_5)
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_4)
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_3)
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_2)
        Me.pnMonth12.Controls.Add(Me.lblDay12_7_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_6_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_5_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_4_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_3_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_2_1)
        Me.pnMonth12.Controls.Add(Me.lblDay12_1_1)
        Me.pnMonth12.Controls.Add(Me.lbl7_12)
        Me.pnMonth12.Controls.Add(Me.lbl6_12)
        Me.pnMonth12.Controls.Add(Me.lbl5_12)
        Me.pnMonth12.Controls.Add(Me.lbl4_12)
        Me.pnMonth12.Controls.Add(Me.lbl3_12)
        Me.pnMonth12.Controls.Add(Me.lbl2_12)
        Me.pnMonth12.Controls.Add(Me.lbl1_12)
        Me.pnMonth12.Controls.Add(Me.lblMonthDec)
        Me.pnMonth12.Location = New System.Drawing.Point(696, 472)
        Me.pnMonth12.Name = "pnMonth12"
        Me.pnMonth12.Size = New System.Drawing.Size(232, 192)
        Me.pnMonth12.TabIndex = 21
        '
        'lblDay12_7_6
        '
        Me.lblDay12_7_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_6.Location = New System.Drawing.Point(200, 168)
        Me.lblDay12_7_6.Name = "lblDay12_7_6"
        Me.lblDay12_7_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_6.TabIndex = 49
        Me.lblDay12_7_6.Tag = "42"
        '
        'lblDay12_6_6
        '
        Me.lblDay12_6_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_6.Location = New System.Drawing.Point(168, 168)
        Me.lblDay12_6_6.Name = "lblDay12_6_6"
        Me.lblDay12_6_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_6.TabIndex = 48
        Me.lblDay12_6_6.Tag = "41"
        '
        'lblDay12_5_6
        '
        Me.lblDay12_5_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_6.Location = New System.Drawing.Point(136, 168)
        Me.lblDay12_5_6.Name = "lblDay12_5_6"
        Me.lblDay12_5_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_6.TabIndex = 47
        Me.lblDay12_5_6.Tag = "40"
        '
        'lblDay12_4_6
        '
        Me.lblDay12_4_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_6.Location = New System.Drawing.Point(104, 168)
        Me.lblDay12_4_6.Name = "lblDay12_4_6"
        Me.lblDay12_4_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_6.TabIndex = 46
        Me.lblDay12_4_6.Tag = "39"
        '
        'lblDay12_3_6
        '
        Me.lblDay12_3_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_6.Location = New System.Drawing.Point(72, 168)
        Me.lblDay12_3_6.Name = "lblDay12_3_6"
        Me.lblDay12_3_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_6.TabIndex = 45
        Me.lblDay12_3_6.Tag = "38"
        '
        'lblDay12_2_6
        '
        Me.lblDay12_2_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_6.Location = New System.Drawing.Point(40, 168)
        Me.lblDay12_2_6.Name = "lblDay12_2_6"
        Me.lblDay12_2_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_6.TabIndex = 44
        Me.lblDay12_2_6.Tag = "37"
        '
        'lblDay12_1_6
        '
        Me.lblDay12_1_6.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_6.Location = New System.Drawing.Point(8, 168)
        Me.lblDay12_1_6.Name = "lblDay12_1_6"
        Me.lblDay12_1_6.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_6.TabIndex = 43
        Me.lblDay12_1_6.Tag = "36"
        '
        'lblDay12_7_5
        '
        Me.lblDay12_7_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_5.Location = New System.Drawing.Point(200, 144)
        Me.lblDay12_7_5.Name = "lblDay12_7_5"
        Me.lblDay12_7_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_5.TabIndex = 42
        Me.lblDay12_7_5.Tag = "35"
        '
        'lblDay12_6_5
        '
        Me.lblDay12_6_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_5.Location = New System.Drawing.Point(168, 144)
        Me.lblDay12_6_5.Name = "lblDay12_6_5"
        Me.lblDay12_6_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_5.TabIndex = 41
        Me.lblDay12_6_5.Tag = "34"
        '
        'lblDay12_5_5
        '
        Me.lblDay12_5_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_5.Location = New System.Drawing.Point(136, 144)
        Me.lblDay12_5_5.Name = "lblDay12_5_5"
        Me.lblDay12_5_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_5.TabIndex = 40
        Me.lblDay12_5_5.Tag = "33"
        '
        'lblDay12_4_5
        '
        Me.lblDay12_4_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_5.Location = New System.Drawing.Point(104, 144)
        Me.lblDay12_4_5.Name = "lblDay12_4_5"
        Me.lblDay12_4_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_5.TabIndex = 39
        Me.lblDay12_4_5.Tag = "32"
        '
        'lblDay12_3_5
        '
        Me.lblDay12_3_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_5.Location = New System.Drawing.Point(72, 144)
        Me.lblDay12_3_5.Name = "lblDay12_3_5"
        Me.lblDay12_3_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_5.TabIndex = 38
        Me.lblDay12_3_5.Tag = "31"
        '
        'lblDay12_2_5
        '
        Me.lblDay12_2_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_5.Location = New System.Drawing.Point(40, 144)
        Me.lblDay12_2_5.Name = "lblDay12_2_5"
        Me.lblDay12_2_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_5.TabIndex = 37
        Me.lblDay12_2_5.Tag = "30"
        '
        'lblDay12_1_5
        '
        Me.lblDay12_1_5.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_5.Location = New System.Drawing.Point(8, 144)
        Me.lblDay12_1_5.Name = "lblDay12_1_5"
        Me.lblDay12_1_5.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_5.TabIndex = 36
        Me.lblDay12_1_5.Tag = "29"
        '
        'lblDay12_7_4
        '
        Me.lblDay12_7_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_4.Location = New System.Drawing.Point(200, 120)
        Me.lblDay12_7_4.Name = "lblDay12_7_4"
        Me.lblDay12_7_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_4.TabIndex = 35
        Me.lblDay12_7_4.Tag = "28"
        '
        'lblDay12_6_4
        '
        Me.lblDay12_6_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_4.Location = New System.Drawing.Point(168, 120)
        Me.lblDay12_6_4.Name = "lblDay12_6_4"
        Me.lblDay12_6_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_4.TabIndex = 34
        Me.lblDay12_6_4.Tag = "27"
        '
        'lblDay12_5_4
        '
        Me.lblDay12_5_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_4.Location = New System.Drawing.Point(136, 120)
        Me.lblDay12_5_4.Name = "lblDay12_5_4"
        Me.lblDay12_5_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_4.TabIndex = 33
        Me.lblDay12_5_4.Tag = "26"
        '
        'lblDay12_4_4
        '
        Me.lblDay12_4_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_4.Location = New System.Drawing.Point(104, 120)
        Me.lblDay12_4_4.Name = "lblDay12_4_4"
        Me.lblDay12_4_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_4.TabIndex = 32
        Me.lblDay12_4_4.Tag = "25"
        '
        'lblDay12_3_4
        '
        Me.lblDay12_3_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_4.Location = New System.Drawing.Point(72, 120)
        Me.lblDay12_3_4.Name = "lblDay12_3_4"
        Me.lblDay12_3_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_4.TabIndex = 31
        Me.lblDay12_3_4.Tag = "24"
        '
        'lblDay12_2_4
        '
        Me.lblDay12_2_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_4.Location = New System.Drawing.Point(40, 120)
        Me.lblDay12_2_4.Name = "lblDay12_2_4"
        Me.lblDay12_2_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_4.TabIndex = 30
        Me.lblDay12_2_4.Tag = "23"
        '
        'lblDay12_1_4
        '
        Me.lblDay12_1_4.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_4.Location = New System.Drawing.Point(8, 120)
        Me.lblDay12_1_4.Name = "lblDay12_1_4"
        Me.lblDay12_1_4.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_4.TabIndex = 29
        Me.lblDay12_1_4.Tag = "22"
        '
        'lblDay12_7_3
        '
        Me.lblDay12_7_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_3.Location = New System.Drawing.Point(200, 96)
        Me.lblDay12_7_3.Name = "lblDay12_7_3"
        Me.lblDay12_7_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_3.TabIndex = 28
        Me.lblDay12_7_3.Tag = "21"
        '
        'lblDay12_6_3
        '
        Me.lblDay12_6_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_3.Location = New System.Drawing.Point(168, 96)
        Me.lblDay12_6_3.Name = "lblDay12_6_3"
        Me.lblDay12_6_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_3.TabIndex = 27
        Me.lblDay12_6_3.Tag = "20"
        '
        'lblDay12_5_3
        '
        Me.lblDay12_5_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_3.Location = New System.Drawing.Point(136, 96)
        Me.lblDay12_5_3.Name = "lblDay12_5_3"
        Me.lblDay12_5_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_3.TabIndex = 26
        Me.lblDay12_5_3.Tag = "19"
        '
        'lblDay12_4_3
        '
        Me.lblDay12_4_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_3.Location = New System.Drawing.Point(104, 96)
        Me.lblDay12_4_3.Name = "lblDay12_4_3"
        Me.lblDay12_4_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_3.TabIndex = 25
        Me.lblDay12_4_3.Tag = "18"
        '
        'lblDay12_3_3
        '
        Me.lblDay12_3_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_3.Location = New System.Drawing.Point(72, 96)
        Me.lblDay12_3_3.Name = "lblDay12_3_3"
        Me.lblDay12_3_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_3.TabIndex = 24
        Me.lblDay12_3_3.Tag = "17"
        '
        'lblDay12_2_3
        '
        Me.lblDay12_2_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_3.Location = New System.Drawing.Point(40, 96)
        Me.lblDay12_2_3.Name = "lblDay12_2_3"
        Me.lblDay12_2_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_3.TabIndex = 23
        Me.lblDay12_2_3.Tag = "16"
        '
        'lblDay12_1_3
        '
        Me.lblDay12_1_3.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_3.Location = New System.Drawing.Point(8, 96)
        Me.lblDay12_1_3.Name = "lblDay12_1_3"
        Me.lblDay12_1_3.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_3.TabIndex = 22
        Me.lblDay12_1_3.Tag = "15"
        '
        'lblDay12_7_2
        '
        Me.lblDay12_7_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_2.Location = New System.Drawing.Point(200, 72)
        Me.lblDay12_7_2.Name = "lblDay12_7_2"
        Me.lblDay12_7_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_2.TabIndex = 21
        Me.lblDay12_7_2.Tag = "14"
        '
        'lblDay12_6_2
        '
        Me.lblDay12_6_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_2.Location = New System.Drawing.Point(168, 72)
        Me.lblDay12_6_2.Name = "lblDay12_6_2"
        Me.lblDay12_6_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_2.TabIndex = 20
        Me.lblDay12_6_2.Tag = "13"
        '
        'lblDay12_5_2
        '
        Me.lblDay12_5_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_2.Location = New System.Drawing.Point(136, 72)
        Me.lblDay12_5_2.Name = "lblDay12_5_2"
        Me.lblDay12_5_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_2.TabIndex = 19
        Me.lblDay12_5_2.Tag = "12"
        '
        'lblDay12_4_2
        '
        Me.lblDay12_4_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_2.Location = New System.Drawing.Point(104, 72)
        Me.lblDay12_4_2.Name = "lblDay12_4_2"
        Me.lblDay12_4_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_2.TabIndex = 18
        Me.lblDay12_4_2.Tag = "11"
        '
        'lblDay12_3_2
        '
        Me.lblDay12_3_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_2.Location = New System.Drawing.Point(72, 72)
        Me.lblDay12_3_2.Name = "lblDay12_3_2"
        Me.lblDay12_3_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_2.TabIndex = 17
        Me.lblDay12_3_2.Tag = "10"
        '
        'lblDay12_2_2
        '
        Me.lblDay12_2_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_2.Location = New System.Drawing.Point(40, 72)
        Me.lblDay12_2_2.Name = "lblDay12_2_2"
        Me.lblDay12_2_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_2.TabIndex = 16
        Me.lblDay12_2_2.Tag = "9"
        '
        'lblDay12_1_2
        '
        Me.lblDay12_1_2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_2.Location = New System.Drawing.Point(8, 72)
        Me.lblDay12_1_2.Name = "lblDay12_1_2"
        Me.lblDay12_1_2.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_2.TabIndex = 15
        Me.lblDay12_1_2.Tag = "8"
        '
        'lblDay12_7_1
        '
        Me.lblDay12_7_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_7_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_7_1.Location = New System.Drawing.Point(200, 48)
        Me.lblDay12_7_1.Name = "lblDay12_7_1"
        Me.lblDay12_7_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_7_1.TabIndex = 14
        Me.lblDay12_7_1.Tag = "7"
        '
        'lblDay12_6_1
        '
        Me.lblDay12_6_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_6_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_6_1.Location = New System.Drawing.Point(168, 48)
        Me.lblDay12_6_1.Name = "lblDay12_6_1"
        Me.lblDay12_6_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_6_1.TabIndex = 13
        Me.lblDay12_6_1.Tag = "6"
        '
        'lblDay12_5_1
        '
        Me.lblDay12_5_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_5_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_5_1.Location = New System.Drawing.Point(136, 48)
        Me.lblDay12_5_1.Name = "lblDay12_5_1"
        Me.lblDay12_5_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_5_1.TabIndex = 12
        Me.lblDay12_5_1.Tag = "5"
        '
        'lblDay12_4_1
        '
        Me.lblDay12_4_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_4_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_4_1.Location = New System.Drawing.Point(104, 48)
        Me.lblDay12_4_1.Name = "lblDay12_4_1"
        Me.lblDay12_4_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_4_1.TabIndex = 11
        Me.lblDay12_4_1.Tag = "4"
        '
        'lblDay12_3_1
        '
        Me.lblDay12_3_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_3_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_3_1.Location = New System.Drawing.Point(72, 48)
        Me.lblDay12_3_1.Name = "lblDay12_3_1"
        Me.lblDay12_3_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_3_1.TabIndex = 10
        Me.lblDay12_3_1.Tag = "3"
        '
        'lblDay12_2_1
        '
        Me.lblDay12_2_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_2_1.Location = New System.Drawing.Point(40, 48)
        Me.lblDay12_2_1.Name = "lblDay12_2_1"
        Me.lblDay12_2_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_2_1.TabIndex = 9
        Me.lblDay12_2_1.Tag = "2"
        '
        'lblDay12_1_1
        '
        Me.lblDay12_1_1.BackColor = System.Drawing.SystemColors.Info
        Me.lblDay12_1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay12_1_1.Location = New System.Drawing.Point(8, 48)
        Me.lblDay12_1_1.Name = "lblDay12_1_1"
        Me.lblDay12_1_1.Size = New System.Drawing.Size(32, 23)
        Me.lblDay12_1_1.TabIndex = 8
        Me.lblDay12_1_1.Tag = "1"
        '
        'lbl7_12
        '
        Me.lbl7_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl7_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl7_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7_12.Location = New System.Drawing.Point(200, 32)
        Me.lbl7_12.Name = "lbl7_12"
        Me.lbl7_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl7_12.TabIndex = 7
        Me.lbl7_12.Text = "Sat"
        Me.lbl7_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6_12
        '
        Me.lbl6_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl6_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl6_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6_12.Location = New System.Drawing.Point(168, 32)
        Me.lbl6_12.Name = "lbl6_12"
        Me.lbl6_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl6_12.TabIndex = 6
        Me.lbl6_12.Text = "Fri"
        Me.lbl6_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5_12
        '
        Me.lbl5_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl5_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl5_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5_12.Location = New System.Drawing.Point(136, 32)
        Me.lbl5_12.Name = "lbl5_12"
        Me.lbl5_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl5_12.TabIndex = 5
        Me.lbl5_12.Text = "Thu"
        Me.lbl5_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4_12
        '
        Me.lbl4_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl4_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4_12.Location = New System.Drawing.Point(104, 32)
        Me.lbl4_12.Name = "lbl4_12"
        Me.lbl4_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl4_12.TabIndex = 4
        Me.lbl4_12.Text = "Wed"
        Me.lbl4_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3_12
        '
        Me.lbl3_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl3_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl3_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3_12.Location = New System.Drawing.Point(72, 32)
        Me.lbl3_12.Name = "lbl3_12"
        Me.lbl3_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl3_12.TabIndex = 3
        Me.lbl3_12.Text = "Tue"
        Me.lbl3_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2_12
        '
        Me.lbl2_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl2_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2_12.Location = New System.Drawing.Point(40, 32)
        Me.lbl2_12.Name = "lbl2_12"
        Me.lbl2_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl2_12.TabIndex = 2
        Me.lbl2_12.Text = "Mon"
        Me.lbl2_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1_12
        '
        Me.lbl1_12.BackColor = System.Drawing.SystemColors.Control
        Me.lbl1_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl1_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_12.Location = New System.Drawing.Point(8, 32)
        Me.lbl1_12.Name = "lbl1_12"
        Me.lbl1_12.Size = New System.Drawing.Size(32, 16)
        Me.lbl1_12.TabIndex = 1
        Me.lbl1_12.Text = "Sun"
        Me.lbl1_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonthDec
        '
        Me.lblMonthDec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthDec.ForeColor = System.Drawing.Color.Purple
        Me.lblMonthDec.Location = New System.Drawing.Point(88, 8)
        Me.lblMonthDec.Name = "lblMonthDec"
        Me.lblMonthDec.Size = New System.Drawing.Size(72, 16)
        Me.lblMonthDec.TabIndex = 0
        Me.lblMonthDec.Text = "December"
        Me.lblMonthDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboYear
        '
        Me.cboYear.Location = New System.Drawing.Point(432, 61)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(80, 21)
        Me.cboYear.TabIndex = 22
        Me.cboYear.Text = "2009"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(752, 64)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Add year"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(840, 64)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "Close"
        '
        'CobRef
        '
        Me.CobRef.DisplayMember = "DISPLAY"
        Me.CobRef.FormattingEnabled = True
        Me.CobRef.Location = New System.Drawing.Point(291, 61)
        Me.CobRef.Name = "CobRef"
        Me.CobRef.Size = New System.Drawing.Size(121, 21)
        Me.CobRef.TabIndex = 25
        Me.CobRef.ValueMember = "VALUE"
        '
        'frmCalendar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 669)
        Me.Controls.Add(Me.CobRef)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.pnMonth12)
        Me.Controls.Add(Me.pnMonth11)
        Me.Controls.Add(Me.pnMonth10)
        Me.Controls.Add(Me.pnMonth9)
        Me.Controls.Add(Me.pnMonth8)
        Me.Controls.Add(Me.pnMonth7)
        Me.Controls.Add(Me.pnMonth6)
        Me.Controls.Add(Me.pnMonth5)
        Me.Controls.Add(Me.pnMonth4)
        Me.Controls.Add(Me.pnMonth3)
        Me.Controls.Add(Me.pnMonth2)
        Me.Controls.Add(Me.pnMonth1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frmCalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCalendar"
        Me.Panel1.ResumeLayout(False)
        Me.pnMonth1.ResumeLayout(False)
        Me.pnMonth2.ResumeLayout(False)
        Me.pnMonth3.ResumeLayout(False)
        Me.pnMonth4.ResumeLayout(False)
        Me.pnMonth5.ResumeLayout(False)
        Me.pnMonth6.ResumeLayout(False)
        Me.pnMonth7.ResumeLayout(False)
        Me.pnMonth8.ResumeLayout(False)
        Me.pnMonth9.ResumeLayout(False)
        Me.pnMonth10.ResumeLayout(False)
        Me.pnMonth11.ResumeLayout(False)
        Me.pnMonth12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Functions"
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Me.Text = mv_ResourceManager.GetString(Me.Name)
        Me.lblCaption.Text = mv_ResourceManager.GetString("lblCaption")
        Me.btnAdd.Text = mv_ResourceManager.GetString("btnAdd")
        Me.btnClose.Text = mv_ResourceManager.GetString("btnClose")

    End Sub

    Private Sub OnInit()
        LoadComboRef()
        LoadComboYear()
        LoadCalendar()
        ' CobRef.Enabled = False
    End Sub
    'STE0012
    Private Sub LoadComboRef()
        Dim v_ws As New BDSDeliveryManagement

        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorMessage As String = String.Empty
        Dim v_strErrorSource As String = String.Empty
        Dim ERR_SA_USER_OUT_OF_SYSTEM As Long = -100007
        Try

            Dim v_strCmdSQL As String, v_strObjMsg As String

            'Che do view, hien thi ca lenh huy sua
            v_strCmdSQL = "SELECT CDVAL VALUE , CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'TRADEPLACE' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionInquiry, v_strCmdSQL)
            v_lngError = v_ws.Message(v_strObjMsg)
            If v_lngError = ERR_SA_USER_OUT_OF_SYSTEM Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            FillComboEx(v_strObjMsg, CobRef, "", Me.UserLanguage)
            c_CLDRTYPESB = "000"

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ex.Message, EventLogEntryType.Error)


            Throw ex
        Finally
            'v_ws.Close()
        End Try
    End Sub
    'End STE0012


    Private Sub LoadComboYear()
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_strSQL, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            Dim i, j As Integer

            Me.cboYear.Items.Clear()

            v_strSQL = "SELECT DISTINCT TO_CHAR(SBDATE, 'YYYY') YEAR FROM SBCLDR WHERE CLDRTYPE = '" & c_CLDRTYPE & "' ORDER BY YEAR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = Convert.ToString(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME
                            Case "YEAR"
                                cboYear.Items.Add(v_strVALUE.Trim)
                        End Select
                    End With
                Next
            Next

            v_strSQL = "SELECT TO_CHAR(SBDATE, 'YYYY') YEAR FROM SBCLDR WHERE SBBUSDAY = 'Y' AND CLDRTYPE = '" & c_CLDRTYPE & "' ORDER BY SBDATE"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = Convert.ToString(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME
                            Case "YEAR"
                                cboYear.SelectedIndex = cboYear.Items.IndexOf(v_strVALUE.Trim)
                                Exit For
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            'v_ws.Close()
        End Try
    End Sub

    Private Sub LoadCalendar()
        Try
            Dim v_strSQL, v_strObjMsg As String
            'Dim v_ws As New BDSDeliveryManagement
            Dim v_ws As New BDSDeliveryManagement

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            Dim i, j, temp As Integer
            Dim v_ctlPanel, v_ctl As Control
            Dim v_strMonth, v_strTest As String
            Dim v_strName As String
            Dim v_intStartIndex, v_intEndIndex As Integer
            Dim v_strYear As String = Convert.ToString(cboYear.SelectedItem)
            'c_CLDRTYPE = Convert.ToString(CboRef.SelectedItem)
            Dim v_intNumberDays, v_intDayOfYear As Integer
            v_intNumberDays = DateDiff(DateInterval.DayOfYear, DDMMYYYY_SystemDate("01/01/" & v_strYear), DDMMYYYY_SystemDate("31/12/" & v_strYear))
            ReDim mv_strCLEARDAY(v_intNumberDays)
            ReDim mv_strSCHEDULETYPE(v_intNumberDays)
            ReDim mv_strHOLIDAY(v_intNumberDays)
            ReDim mv_strDATE(v_intNumberDays)
            ReDim mv_strSBEOP(v_intNumberDays)
            Dim v_strClearDay, v_strScheduleType, v_strHoliday, v_strDATE, v_strSBEOP As String

            'v_strSQL = "SELECT TO_CHAR(SB.SBDATE,'DD/MM/YYYY') CHARDATE, SB.HOLIDAY, GX.CLEARDAY, GX.SCHEDULE_TYPE FROM SBCLDR SB, GXCALENDAR GX " & _
            '        "WHERE SB.CLDRTYPE = '" & c_CLDRTYPE & "' AND TO_CHAR(SB.SBDATE,'YYYY') = '" & v_strYear & "' " & _
            '        "AND TO_DATE(GX.TXDATE,'DD/MM/YYYY') = SB.SBDATE "
            'STE0012()
            'v_strSQL = "SELECT TO_CHAR(SB.SBDATE,'DD/MM/YYYY') CHARDATE, SB.HOLIDAY, GX.CLEARDAY, GX.SCHEDULE_TYPE ,  " & _
            ' "(case when COM.SBEOP is null then 'N' else 'Y' end) SBEOP FROM SBCLDR SB, GXCALENDAR GX, (select distinct sbdate, sbeop from SBCLDR " & _
            '"where SBCLDR.cldrtype like (case when '" & c_CLDRTYPESB & "' = 'ALL' then '%%' else '" & c_CLDRTYPESB & "' end) and sbeop = 'Y') COM WHERE SB.CLDRTYPE = '000' " & _
            ' "AND TO_CHAR(SB.SBDATE,'YYYY') = '" & v_strYear & "' AND TO_DATE(GX.TXDATE,'DD/MM/YYYY') = SB.SBDATE and SB.sbdate = COM.SBDATE(+)"

            'STE0012

            v_strSQL = "SELECT TO_CHAR(SB.SBDATE,'DD/MM/YYYY') CHARDATE, SB.HOLIDAY FROM SBCLDR SB " & _
                   "WHERE SB.CLDRTYPE = '" & c_CLDRTYPESB & "' AND TO_CHAR(SB.SBDATE,'YYYY') = '" & v_strYear & "' "


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            ''v_ws.Close()
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = Convert.ToString(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME
                            Case "CHARDATE"
                                v_strDATE = v_strVALUE
                                v_intDayOfYear = DDMMYYYY_SystemDate(v_strVALUE).DayOfYear
                            Case "CLEARDAY"
                                v_strClearDay = v_strVALUE
                            Case "HOLIDAY"
                                v_strHoliday = v_strVALUE
                            Case "SCHEDULE_TYPE"
                                v_strScheduleType = v_strVALUE
                                'STE0012
                                'Case "SBEOP"
                                '    v_strSBEOP = v_strVALUE
                                'STE0012
                        End Select
                    End With
                Next
                mv_strDATE(v_intDayOfYear - 1) = v_strDATE
                mv_strHOLIDAY(v_intDayOfYear - 1) = v_strHoliday
                mv_strCLEARDAY(v_intDayOfYear - 1) = v_strClearDay
                mv_strSCHEDULETYPE(v_intDayOfYear - 1) = v_strScheduleType
                mv_strSBEOP(v_intDayOfYear - 1) = v_strSBEOP
            Next

            For Each v_ctlPanel In Me.Controls
                If (TypeOf (v_ctlPanel) Is Panel) Then
                    v_strName = v_ctlPanel.Name
                    If v_strName.IndexOf("pnMonth") = 0 Then
                        v_strMonth = v_strName.Substring(7)
                        v_intStartIndex = SetStartIndex(v_strMonth, v_strYear)
                        v_intEndIndex = SetEndIndex(v_strMonth, v_strYear)
                        For Each v_ctl In v_ctlPanel.Controls
                            If v_ctl.Name.IndexOf("lblDay") = 0 Then
                                v_ctl.ForeColor = System.Drawing.SystemColors.ControlText
                                v_ctl.BackColor = System.Drawing.Color.AliceBlue
                                RemoveHandler v_ctl.MouseDown, AddressOf LabelDay_MouseDown
                                RemoveHandler v_ctl.MouseMove, AddressOf lblDay_MouseMove
                                RemoveHandler v_ctl.MouseLeave, AddressOf lblDay_MouseLeave
                                'RemoveHandler v_ctl.MouseLeave, AddressOf lblDay_MouseMove
                                If gf_CorrectNumericField(v_ctl.Tag) < v_intStartIndex _
                                Or gf_CorrectNumericField(v_ctl.Tag) - v_intStartIndex + 1 > v_intEndIndex Then
                                    v_ctl.Enabled = False
                                    v_ctl.Text = String.Empty
                                    v_ctl.ContextMenu = Nothing
                                Else
                                    v_ctl.Text = c_FIRSTDATE + gf_CorrectNumericField(v_ctl.Tag) - v_intStartIndex
                                    v_ctl.Enabled = True
                                    temp = DDMMYYYY_SystemDate(v_ctl.Text & "/" & v_strMonth & "/" & v_strYear).DayOfYear
                                    If mv_strHOLIDAY(temp - 1) = "Y" Then
                                        v_ctl.ForeColor = System.Drawing.Color.Red
                                    End If
                                    If mv_strSBEOP(temp - 1) = "Y" Then
                                        v_ctl.BackColor = System.Drawing.Color.Yellow
                                    End If
                                    v_ctl.TabIndex = temp - 1
                                    v_ctl.ContextMenu = cmSetup
                                    AddHandler v_ctl.MouseDown, AddressOf LabelDay_MouseDown
                                    AddHandler v_ctl.MouseMove, AddressOf lblDay_MouseMove
                                    AddHandler v_ctl.MouseLeave, AddressOf lblDay_MouseLeave
                                End If
                            ElseIf v_ctl.Name.IndexOf("lblMonth") < 0 Then
                                v_ctl.ContextMenu = cmSetup
                                RemoveHandler v_ctl.MouseDown, AddressOf LabelDayOfMonth_MouseDown
                                AddHandler v_ctl.MouseDown, AddressOf LabelDayOfMonth_MouseDown
                                ' AddHandler v_ctl.MouseMove, AddressOf lblDay_MouseMove
                                ' RemoveHandler v_ctl.MouseMove, AddressOf lblDay_MouseMove
                            End If
                        Next
                    End If
                End If
            Next

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                             & "Error code: System error!" & vbNewLine _
                                                             & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Function SetStartIndex(ByVal pv_strMonth As String, ByVal pv_strYear As String)
        Dim v_dtFrom As DateTime = New DateTime(CInt(pv_strYear), CInt(pv_strMonth), c_FIRSTDATE)
        Return v_dtFrom.DayOfWeek + 1
    End Function

    Private Function SetEndIndex(ByVal pv_strMonth As String, ByVal pv_strYear As String)
        Dim v_dtFrom As DateTime = New DateTime(CInt(pv_strYear), CInt(pv_strMonth), c_FIRSTDATE)
        v_dtFrom = v_dtFrom.AddMonths(1).AddDays(-1)
        Return v_dtFrom.Day
    End Function

    Private Sub SetHoliday(ByVal sender As Object, ByVal v_strHoliday As String)
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strCmdInquiry As String
            Dim v_strObjMsg As String
            Dim strSQL As String
            Dim v_strDate As String
            Dim v_ctl As Label = CType(sender, Label)

            If mv_strHOLIDAY(v_ctl.TabIndex) = v_strHoliday Then
                Exit Sub
            End If

            'If v_ctl.ForeColor = Color.Red Then
            '    Exit Sub
            'End If

            v_strDate = mv_strDATE(v_ctl.TabIndex)

            strSQL = v_strDate & "$" & v_strHoliday & "$" & CobRef.SelectedValue  'c_CLDRTYPESB

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SETHOLIDAY")
            v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            If v_strHoliday = "Y" Then
                v_ctl.ForeColor = System.Drawing.Color.Red
                mv_strHOLIDAY(v_ctl.TabIndex) = "Y"
            Else
                v_ctl.ForeColor = System.Drawing.SystemColors.ControlText
                mv_strHOLIDAY(v_ctl.TabIndex) = "N"
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                & "Error code: System error!" & vbNewLine _
                                & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try


    End Sub

    Private Sub SetDOMHoliday(ByVal sender As Object, ByVal v_strHoliday As String)
        Dim v_strName, v_strMonth, v_strDay, v_strYear As String
        v_strName = CType(sender, Label).Name
        v_strMonth = v_strName.Substring(v_strName.IndexOf("_") + 1)
        v_strDay = v_strName.Substring(3, 1)
        v_strYear = Convert.ToString(cboYear.SelectedItem)
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_strObjMsg As String
            Dim strSQL As String

            strSQL = v_strDay & "$" & v_strMonth & "$" & v_strYear & "$" & v_strHoliday & "$" & c_CLDRTYPESB

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_DOM_HOLIDAY")
            v_ws.Message(v_strObjMsg)
            Dim v_frm As frmDefineCLDR
            If v_strHoliday = "Y" Then
                v_frm = New frmDefineCLDR(Me.UserLanguage, "SET_HOLIDAY", True, , v_strDay, , v_strMonth, v_strYear, c_CLDRTYPESB)
            Else
                v_frm = New frmDefineCLDR(Me.UserLanguage, "SET_WORKING_DAY", True, , v_strDay, , v_strMonth, v_strYear, c_CLDRTYPESB)
            End If
            v_frm.ShowDialog()

            If v_frm.mv_strReturn = "" Then
                Exit Sub
            End If

            If v_frm.mv_strReturn.IndexOf("M$") = 0 Then
                If v_frm.mv_strReturn.Substring(2) = "0" Then
                    Dim v_ctlPanel, v_ctl As Control
                    For Each v_ctlPanel In Me.Controls
                        If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name = "pnMonth" & v_strMonth Then
                            For Each v_ctl In v_ctlPanel.Controls
                                If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay" & v_strMonth & "_" & v_strDay) = 0 And v_ctl.Enabled Then
                                    If v_strHoliday = "Y" Then
                                        v_ctl.ForeColor = System.Drawing.Color.Red
                                    Else
                                        v_ctl.ForeColor = System.Drawing.SystemColors.ControlText
                                    End If
                                End If
                            Next
                            Exit For
                        End If

                    Next
                End If

            ElseIf v_frm.mv_strReturn.IndexOf("Y$") = 0 Then
                If v_frm.mv_strReturn.Substring(2) = "0" Then
                    Dim v_ctlPanel, v_ctl As Control
                    For Each v_ctlPanel In Me.Controls
                        If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name.IndexOf("pnMonth") = 0 Then
                            For Each v_ctl In v_ctlPanel.Controls
                                If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay") = 0 And v_ctl.Name.IndexOf("_" & v_strDay & "_") > 0 And v_ctl.Enabled Then
                                    If v_strHoliday = "Y" Then
                                        v_ctl.ForeColor = System.Drawing.Color.Red
                                    Else
                                        v_ctl.ForeColor = System.Drawing.SystemColors.ControlText
                                    End If
                                End If
                            Next
                        End If

                    Next
                End If

            End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                                         & "Error code: System error!" & vbNewLine _
                                                                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub AddYear()
        Try
            Dim v_lngError As Long
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strObjMsg As String
            Dim str_add As String
            Dim v_strHoliday As String = "#1#7#"
            Dim v_strYear As String

            v_strYear = Convert.ToString(CInt(cboYear.Items.Item(cboYear.Items.Count - 1)) + 1)

            str_add = v_strYear & "$" & v_strHoliday

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , str_add, "ADDNEWYEAR")
            v_lngError = v_ws.Message(v_strObjMsg)
            'v_ws.Close()
            If v_lngError = ERR_SYSTEM_OK Then
                cboYear.Items.Add(v_strYear)
                cboYear.SelectedIndex = cboYear.Items.Count - 1
                LoadCalendar()
                MessageBox.Show(mv_ResourceManager.GetString("AddYearSuccess").Replace("@Year", v_strYear))
            Else
                MessageBox.Show(mv_ResourceManager.GetString("AddYearNotSuccess").Replace("@Year", v_strYear))
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                                                     & "Error code: System error!" & vbNewLine _
                                                                                     & "Error message: " & ex.Message, EventLogEntryType.Error)

        End Try

    End Sub
    'Huynq cap nhat GXCANDELAR
    'Private Sub SetClearDay(ByVal sender As Object)
    '    Dim v_strDate As String
    '    Dim v_ctl As Label = CType(sender, Label)

    '    v_strDate = mv_strDATE(v_ctl.TabIndex)

    '    Dim v_frm As New frmDefineCLDR(Me.UserLanguage, "SET_CLEARDAY", False, mv_strCLEARDAY(v_ctl.TabIndex), , v_strDate)
    '    v_frm.ShowDialog()
    '    If v_frm.mv_strReturn <> String.Empty Then
    '        mv_strCLEARDAY(v_ctl.TabIndex) = v_frm.mv_strReturn
    '    End If
    'End Sub

    'Private Sub SetScheduleType(ByVal sender As Object)
    '    Dim v_strDate As String
    '    Dim v_ctl As Label = CType(sender, Label)

    '    v_strDate = mv_strDATE(v_ctl.TabIndex)

    '    Dim v_frm As New frmDefineCLDR(Me.UserLanguage, "SET_SCHEDULE_TYPE", False, mv_strSCHEDULETYPE(v_ctl.TabIndex), , v_strDate)
    '    v_frm.ShowDialog()

    '    If v_frm.mv_strReturn <> String.Empty Then
    '        mv_strSCHEDULETYPE(v_ctl.TabIndex) = v_frm.mv_strReturn
    '    End If
    'End Sub

    'Private Sub SetDOMClearDay(ByVal sender As Object)
    '    Dim v_strName, v_strMonth, v_strDay, v_strYear As String
    '    v_strName = CType(sender, Label).Name
    '    v_strMonth = v_strName.Substring(v_strName.IndexOf("_") + 1)
    '    v_strDay = v_strName.Substring(3, 1)
    '    v_strYear = Convert.ToString(cboYear.SelectedItem)


    '    Dim v_frm As New frmDefineCLDR(Me.UserLanguage, "SET_CLEARDAY", True, , v_strDay, , v_strMonth, v_strYear)
    '    v_frm.ShowDialog()
    '    If v_frm.mv_strReturn <> String.Empty Then
    '        If v_frm.mv_strReturn.IndexOf("M$") = 0 Then
    '            Dim v_ctlPanel, v_ctl As Control
    '            For Each v_ctlPanel In Me.Controls
    '                If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name = "pnMonth" & v_strMonth Then
    '                    For Each v_ctl In v_ctlPanel.Controls
    '                        If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay" & v_strMonth & "_" & v_strDay) = 0 And v_ctl.Enabled Then
    '                            mv_strCLEARDAY(v_ctl.TabIndex) = v_frm.mv_strReturn.Substring(2)
    '                        End If
    '                    Next
    '                    Exit For
    '                End If

    '            Next

    '        ElseIf v_frm.mv_strReturn.IndexOf("Y$") = 0 Then
    '            Dim v_ctlPanel, v_ctl As Control
    '            For Each v_ctlPanel In Me.Controls
    '                If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name.IndexOf("pnMonth") = 0 Then
    '                    For Each v_ctl In v_ctlPanel.Controls
    '                        If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay") = 0 And v_ctl.Name.IndexOf("_" & v_strDay & "_") > 0 And v_ctl.Enabled Then
    '                            mv_strCLEARDAY(v_ctl.TabIndex) = v_frm.mv_strReturn.Substring(2)
    '                        End If
    '                    Next
    '                End If
    '            Next

    '        End If
    '    End If
    'End Sub

    'Private Sub SetDOMScheduleType(ByVal sender As Object)
    '    Dim v_strName, v_strMonth, v_strDay, v_strYear As String
    '    v_strName = CType(sender, Label).Name
    '    v_strMonth = v_strName.Substring(v_strName.IndexOf("_") + 1)
    '    v_strDay = v_strName.Substring(3, 1)
    '    v_strYear = Convert.ToString(cboYear.SelectedItem)


    '    Dim v_frm As New frmDefineCLDR(Me.UserLanguage, "SET_SCHEDULE_TYPE", True, , v_strDay, , v_strMonth, v_strYear)
    '    v_frm.ShowDialog()
    '    If v_frm.mv_strReturn <> String.Empty Then
    '        If v_frm.mv_strReturn.IndexOf("M$") = 0 Then
    '            Dim v_ctlPanel, v_ctl As Control
    '            For Each v_ctlPanel In Me.Controls
    '                If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name = "pnMonth" & v_strMonth Then
    '                    For Each v_ctl In v_ctlPanel.Controls
    '                        If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay" & v_strMonth & "_" & v_strDay) = 0 And v_ctl.Enabled Then
    '                            mv_strSCHEDULETYPE(v_ctl.TabIndex) = v_frm.mv_strReturn.Substring(2)
    '                        End If
    '                    Next
    '                    Exit For
    '                End If

    '            Next

    '        ElseIf v_frm.mv_strReturn.IndexOf("Y$") = 0 Then
    '            Dim v_ctlPanel, v_ctl As Control
    '            For Each v_ctlPanel In Me.Controls
    '                If TypeOf (v_ctlPanel) Is Panel And v_ctlPanel.Name.IndexOf("pnMonth") = 0 Then
    '                    For Each v_ctl In v_ctlPanel.Controls
    '                        If TypeOf (v_ctl) Is Label And v_ctl.Name.IndexOf("lblDay") = 0 And v_ctl.Name.IndexOf("_" & v_strDay & "_") > 0 And v_ctl.Enabled Then
    '                            mv_strSCHEDULETYPE(v_ctl.TabIndex) = v_frm.mv_strReturn.Substring(2)
    '                        End If
    '                    Next
    '                End If
    '            Next

    '        End If
    '    End If
    'End Sub

#End Region

#Region "Form Events"
    Private Sub CobRef_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobRef.SelectedIndexChanged
        ' Dim a As String = CobRef.Text
        Try
            Dim b As String = CobRef.SelectedValue
            Dim v_strCodeID As String
            If (Not CobRef.SelectedValue Is DBNull.Value) Then
                c_CLDRTYPESB = CobRef.SelectedValue
            End If
            LoadCalendar()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub lblDay_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim v_ctl As Label = CType(sender, Label)
        If v_ctl.BackColor = Color.Yellow Then
            Exit Sub
        Else
            v_ctl.BackColor = Color.DarkGreen
        End If
    End Sub

    Private Sub lblDay_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_ctl As Label = CType(sender, Label)
        If v_ctl.BackColor = Color.Yellow Then
            Exit Sub
        Else
            v_ctl.BackColor = Color.AliceBlue
        End If
    End Sub

    Private Sub LabelDay_MouseDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim v_ctl As Label = CType(Sender, Label)
            ContextHandler_Day(v_ctl, e)
            v_ctl.ContextMenu.Show(v_ctl, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub LabelDayOfMonth_MouseDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim v_ctl As Label = CType(Sender, Label)
            ContextHandler_DayOfMonth(v_ctl, e)
            v_ctl.ContextMenu.Show(v_ctl, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        LoadCalendar()
    End Sub

    Protected Sub ContextHandler_Day(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmSetup.MenuItems.Clear()

        AddContextMenu("1" & ". " & mv_ResourceManager.GetString("SETHOLIDAY"), False, sender)
        AddContextMenu("2" & ". " & mv_ResourceManager.GetString("UNSETHOLIDAY"), False, sender)
        ' AddContextMenu("3" & ". " & mv_ResourceManager.GetString("CLEARDAY") & ": " & mv_strCLEARDAY(CType(sender, Label).TabIndex), False, sender)
        'AddContextMenu("4" & ". " & mv_ResourceManager.GetString("SCHEDULE_TYPE") & ": " & mv_strSCHEDULETYPE(CType(sender, Label).TabIndex), False, sender)
        'AddContextMenu("5" & ". " & mv_ResourceManager.GetString("SETFINALWORK"), False, sender)
    End Sub

    Protected Sub ContextHandler_DayOfMonth(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmSetup.MenuItems.Clear()

        AddContextMenu("1" & ". " & mv_ResourceManager.GetString("SETHOLIDAY"), True, sender)
        AddContextMenu("2" & ". " & mv_ResourceManager.GetString("UNSETHOLIDAY"), True, sender)
        ' AddContextMenu("3" & ". " & mv_ResourceManager.GetString("CLEARDAY"), True, sender)
        'AddContextMenu("4" & ". " & mv_ResourceManager.GetString("SCHEDULE_TYPE"), True, sender)
    End Sub

    Private Sub AddContextMenu(ByVal Caption As String, ByVal IsDOM As Boolean, ByVal sender As Object, Optional ByVal IsEnabled As Boolean = True)
        Dim objMenuItem As MenuItem
        objMenuItem = New MenuItem
        objMenuItem.Text = Caption
        objMenuItem.Enabled = IsEnabled
        cmSetup.MenuItems.Add(objMenuItem)
        'Handling Popup menu item click event
        If IsDOM Then
            AddHandler objMenuItem.Click, AddressOf CMenuClick_DOM
        Else
            AddHandler objMenuItem.Click, AddressOf CMenuClick
        End If

    End Sub

    Private Sub CMenuClick_DOM(ByVal sender As Object, ByVal e As System.EventArgs)
        'Point to menu item clicked
        Dim objCurMenuItem As MenuItem = CType(sender, MenuItem)
        'create the submenu based on whatever selection is being made, mnuSelection
        Select Case objCurMenuItem.Text.Substring(0, 1)
            Case "1"
                SetDOMHoliday(cmSetup.SourceControl, "Y")
            Case "2"
                SetDOMHoliday(cmSetup.SourceControl, "N")
                'Case "3"
                '    'SetDOMClearDay(cmSetup.SourceControl)
                'Case "4"
                'SetDOMScheduleType(cmSetup.SourceControl)
        End Select
    End Sub

    Private Sub CMenuClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Point to menu item clicked
        Dim objCurMenuItem As MenuItem = CType(sender, MenuItem)
        'create the submenu based on whatever selection is being made, mnuSelection
        Select Case objCurMenuItem.Text.Substring(0, 1)
            Case "1"
                SetHoliday(cmSetup.SourceControl, "Y")
            Case "2"
                SetHoliday(cmSetup.SourceControl, "N")
                'Case "3"
                '    'SetClearDay(cmSetup.SourceControl)
                'Case "4"
                'SetScheduleType(cmSetup.SourceControl)
                '    'STE0012
                'Case "5"
                '    SetLastWorkingDate(cmSetup.SourceControl)
                '    'END STE0012
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddYear()
    End Sub
    'STE0012 Huynq dung set ngay lam viec cuoi, chua dung toi
    'Private Sub SetLastWorkingDate(ByVal sender As Object)
    '    Try
    '        'Huynq dung de set ngay lam viec cuoi
    '        Dim v_ws As New BDSDeliveryManagement
    '        Dim v_strCmdInquiry As String
    '        Dim v_strObjMsg As String
    '        Dim strSQL As String
    '        Dim strSQLSB As String
    '        Dim v_strDate As String
    '        Dim v_ctl As Label = CType(sender, Label)

    '        'If mv_strSBEOP(v_ctl.TabIndex) = "N" Then
    '        '    Exit Sub
    '        'End If
    '        v_strDate = mv_strDATE(v_ctl.TabIndex)
    '        If c_CLDRTYPESB = "ALL" Then
    '            If v_ctl.BackColor = Color.Yellow Then
    '                strSQL = v_strDate & "$" & "N" & "$" & "ALL"
    '                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_LASTWORKINGDATE")
    '                v_ws.Message(v_strObjMsg)
    '                v_ctl.BackColor = Color.AliceBlue
    '            Else
    '                strSQL = v_strDate & "$" & "Y" & "$" & "ALL"
    '                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_LASTWORKINGDATE")
    '                v_ws.Message(v_strObjMsg)
    '                v_ctl.BackColor = System.Drawing.Color.Yellow
    '            End If
    '        Else
    '            If v_ctl.BackColor = Color.Yellow Then
    '                strSQL = v_strDate & "$" & "N" & "$" & c_CLDRTYPESB
    '                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_LASTWORKINGDATE")
    '                v_ws.Message(v_strObjMsg)
    '                v_ctl.BackColor = Color.AliceBlue
    '            Else
    '                strSQL = v_strDate & "$" & "Y" & "$" & c_CLDRTYPESB
    '                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.Calendar", gc_ActionAdhoc, , strSQL, "SET_LASTWORKINGDATE")
    '                v_ws.Message(v_strObjMsg)
    '                v_ctl.BackColor = System.Drawing.Color.Yellow
    '            End If
    '        End If



    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                            & "Error code: System error!" & vbNewLine _
    '                            & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        Throw ex
    '    End Try

    'End Sub
    'END STE0012
#End Region
   
    Private Sub frmCalendar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class

