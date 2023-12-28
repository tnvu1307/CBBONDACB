Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Xceed.SmartUI.Controls.TreeView
Imports CommonLibrary
Imports AppCore
Imports AppCore.GridEx
Imports AppCore.ComboBoxEx

Public Class frmRptAssign
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents stvRptMenu As Xceed.SmartUI.Controls.TreeView.SmartTreeView
    Friend WithEvents imlMenu As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents Node1 As Xceed.SmartUI.Controls.TreeView.Node
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlRptAssign As System.Windows.Forms.Panel
    Friend WithEvents ckbPRINT As System.Windows.Forms.CheckBox
    Friend WithEvents ckbVIEW As System.Windows.Forms.CheckBox
    Friend WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents imlToolBar As System.Windows.Forms.ImageList
    Friend WithEvents tbnSave As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnCancel As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents lblREPORT As System.Windows.Forms.Label
    Friend WithEvents grbAccessRight As System.Windows.Forms.GroupBox
    Friend WithEvents ckbADD As System.Windows.Forms.CheckBox
    ' <System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptAssign))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.stvRptMenu = New Xceed.SmartUI.Controls.TreeView.SmartTreeView(Me.components)
        Me.Node1 = New Xceed.SmartUI.Controls.TreeView.Node("@VSTP - Report", 2)
        Me.imlMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnSave = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnSave", 1)
        Me.tbnCancel = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnCancel", 0)
        Me.imlToolBar = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlRptAssign = New System.Windows.Forms.Panel
        Me.lblREPORT = New System.Windows.Forms.Label
        Me.grbAccessRight = New System.Windows.Forms.GroupBox
        Me.ckbADD = New System.Windows.Forms.CheckBox
        Me.ckbPRINT = New System.Windows.Forms.CheckBox
        Me.ckbVIEW = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        CType(Me.stvRptMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRptAssign.SuspendLayout()
        Me.grbAccessRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Tag = "Caption"
        Me.lblCaption.Text = "lblCaption"
        '
        'stvRptMenu
        '
        Me.stvRptMenu.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.stvRptMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.stvRptMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stvRptMenu.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.Node1})
        Me.stvRptMenu.ItemsImageList = Me.imlMenu
        Me.stvRptMenu.Location = New System.Drawing.Point(0, 50)
        Me.stvRptMenu.Name = "stvRptMenu"
        Me.stvRptMenu.Size = New System.Drawing.Size(295, 405)
        Me.stvRptMenu.TabIndex = 1
        Me.stvRptMenu.Text = "stvRptMenu"
        '
        'Node1
        '
        Me.Node1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Node1.ImageIndex = 2
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "@VSTP - Report"
        '
        'imlMenu
        '
        Me.imlMenu.ImageStream = CType(resources.GetObject("imlMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMenu.Images.SetKeyName(0, "")
        Me.imlMenu.Images.SetKeyName(1, "")
        Me.imlMenu.Images.SetKeyName(2, "")
        Me.imlMenu.Images.SetKeyName(3, "")
        Me.imlMenu.Images.SetKeyName(4, "")
        Me.imlMenu.Images.SetKeyName(5, "")
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(295, 50)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 405)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SmartToolBar1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(298, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 40)
        Me.Panel2.TabIndex = 3
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SmartToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SmartToolBar1.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tbnSave, Me.tbnCancel})
        Me.SmartToolBar1.ItemsImageList = Me.imlToolBar
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(336, 42)
        Me.SmartToolBar1.TabIndex = 0
        Me.SmartToolBar1.Text = "SmartToolBar1"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnSave
        '
        Me.tbnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnSave.ImageIndex = 1
        Me.tbnSave.Name = "tbnSave"
        Me.tbnSave.Text = "tbnSave"
        '
        'tbnCancel
        '
        Me.tbnCancel.ImageIndex = 0
        Me.tbnCancel.Name = "tbnCancel"
        Me.tbnCancel.OverFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnCancel.Text = "tbnCancel"
        '
        'imlToolBar
        '
        Me.imlToolBar.ImageStream = CType(resources.GetObject("imlToolBar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolBar.TransparentColor = System.Drawing.Color.Transparent
        Me.imlToolBar.Images.SetKeyName(0, "")
        Me.imlToolBar.Images.SetKeyName(1, "")
        '
        'pnlRptAssign
        '
        Me.pnlRptAssign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRptAssign.Controls.Add(Me.lblREPORT)
        Me.pnlRptAssign.Controls.Add(Me.grbAccessRight)
        Me.pnlRptAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRptAssign.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlRptAssign.Location = New System.Drawing.Point(298, 90)
        Me.pnlRptAssign.Name = "pnlRptAssign"
        Me.pnlRptAssign.Size = New System.Drawing.Size(336, 365)
        Me.pnlRptAssign.TabIndex = 4
        '
        'lblREPORT
        '
        Me.lblREPORT.AutoSize = True
        Me.lblREPORT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREPORT.Location = New System.Drawing.Point(10, 15)
        Me.lblREPORT.Name = "lblREPORT"
        Me.lblREPORT.Size = New System.Drawing.Size(64, 13)
        Me.lblREPORT.TabIndex = 6
        Me.lblREPORT.Tag = "REPORT"
        Me.lblREPORT.Text = "lblREPORT"
        Me.lblREPORT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbAccessRight
        '
        Me.grbAccessRight.Controls.Add(Me.ckbADD)
        Me.grbAccessRight.Controls.Add(Me.ckbPRINT)
        Me.grbAccessRight.Controls.Add(Me.ckbVIEW)
        Me.grbAccessRight.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grbAccessRight.Location = New System.Drawing.Point(10, 45)
        Me.grbAccessRight.Name = "grbAccessRight"
        Me.grbAccessRight.Size = New System.Drawing.Size(280, 135)
        Me.grbAccessRight.TabIndex = 2
        Me.grbAccessRight.TabStop = False
        Me.grbAccessRight.Tag = "AccessRight"
        Me.grbAccessRight.Text = "grbAccessRight"
        '
        'ckbADD
        '
        Me.ckbADD.Location = New System.Drawing.Point(15, 100)
        Me.ckbADD.Name = "ckbADD"
        Me.ckbADD.Size = New System.Drawing.Size(160, 24)
        Me.ckbADD.TabIndex = 3
        Me.ckbADD.Tag = "ADD"
        Me.ckbADD.Text = "ckbADD"
        '
        'ckbPRINT
        '
        Me.ckbPRINT.Enabled = False
        Me.ckbPRINT.Location = New System.Drawing.Point(15, 65)
        Me.ckbPRINT.Name = "ckbPRINT"
        Me.ckbPRINT.Size = New System.Drawing.Size(160, 24)
        Me.ckbPRINT.TabIndex = 1
        Me.ckbPRINT.Tag = "PRINT"
        Me.ckbPRINT.Text = "ckbPRINT"
        '
        'ckbVIEW
        '
        Me.ckbVIEW.Enabled = False
        Me.ckbVIEW.Location = New System.Drawing.Point(15, 30)
        Me.ckbVIEW.Name = "ckbVIEW"
        Me.ckbVIEW.Size = New System.Drawing.Size(160, 24)
        Me.ckbVIEW.TabIndex = 0
        Me.ckbVIEW.Tag = "VIEW"
        Me.ckbVIEW.Text = "ckbVIEW"
        '
        'frmRptAssign
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 455)
        Me.Controls.Add(Me.pnlRptAssign)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.stvRptMenu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptAssign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRptAssign"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stvRptMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRptAssign.ResumeLayout(False)
        Me.pnlRptAssign.PerformLayout()
        Me.grbAccessRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_intExecFlag As Integer
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strUserId As String
    Private mv_strUserName As String
    Private mv_strGroupId As String
    Private mv_strGroupName As String
    Private mv_strAssignType As String

    Private mv_arrObjFields() As CFieldMaster
    Private mv_strLocalObject As String
    Private mv_strReportAuth As String

    Dim hParentsFilter As New Hashtable
    Dim hReportFilter As New Hashtable
    Dim hModCodeFilter As New Hashtable
    Dim hTxCodeFilter As New Hashtable
    Dim hCmdIdFilter As New Hashtable
    Dim hFuncFilter As New Hashtable
    Dim hChildrenFilter As New Hashtable


#End Region

#Region " Properties "

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

    Public Property UserId() As String
        Get
            Return mv_strUserId
        End Get
        Set(ByVal Value As String)
            mv_strUserId = Value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return mv_strUserName
        End Get
        Set(ByVal Value As String)
            mv_strUserName = Value
        End Set
    End Property

    Public Property GroupId() As String
        Get
            Return mv_strGroupId
        End Get
        Set(ByVal Value As String)
            mv_strGroupId = Value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return mv_strGroupName
        End Get
        Set(ByVal Value As String)
            mv_strGroupName = Value
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

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
        End Set
    End Property

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property AssignType() As String
        Get
            Return mv_strAssignType
        End Get
        Set(ByVal Value As String)
            mv_strAssignType = Value
        End Set
    End Property
#End Region

#Region " Overridable methods "
    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            DisableAssignment()
            DoResizePanel()
            mv_ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmRptAssign-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            FillData()
            GetParents()
            DisplayMenus()
        Catch ex As Exception

        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        'Dim v_strTellerName As String

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmRptAssign." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmRptAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmRptAssign." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmRptAssign." & v_ctrl.Name)
                End If
            Next

            'Load caption of toolbar
            tbnSave.Text = mv_ResourceManager.GetString("frmRptAssign.tbnSave")
            tbnCancel.Text = mv_ResourceManager.GetString("frmRptAssign.tbnCancel")
            'Load caption của form, label caption
            Me.Text = mv_ResourceManager.GetString("frmRptAssign")
            lblCaption.Text = mv_ResourceManager.GetString("frmRptAssign.lblCaption") & UserName
            'Disable control if in view mode
            If (ExeFlag = ExecuteFlag.View) Then
                tbnSave.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''------------------------------------------------''
    ''-- Lấy các thông tin phân quyền đã có của NSD --''
    ''------------------------------------------------''
    Private Sub FillData()
        Try
            Dim v_strFLDNAME, v_strValue As String

            'Get Report access right of user
            
            'Get parents access right
            'If AssignType = "User" Then
            '    v_strCmdInquiryRpt = "SELECT M.TXCODE TXCODE, M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, C.CMDID CMDID, C.LEV LEV " _
            '                                & "FROM APPMODULES N, CMDMENU C " _
            '                                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R') M, CMDAUTH A " _
            '                        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
            '                        & "ORDER BY M.CMDID "
            '    'v_strCmdInquiryRpt = "SELECT M.TXCODE TXCODE, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    '                    & "FROM APPMODULES M, CMDAUTH A " _
            '    '                    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
            '    '                    & "ORDER BY M.TXCODE"
            '    v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryRpt)
            'ElseIf AssignType = "Group" Then
            '    v_strCmdInquiryRpt = "SELECT M.TXCODE TXCODE, M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '                        & "FROM (SELECT N.TXCODE TXCODE, N.MODCODE MODCODE, C.CMDID CMDID, C.LEV LEV " _
            '                                & "FROM APPMODULES N, CMDMENU C " _
            '                                & "WHERE TRIM(N.MODCODE) = TRIM(C.MODCODE) AND TRIM(C.MENUTYPE) = 'R') M, CMDAUTH A " _
            '                        & "WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
            '                        & "ORDER BY M.CMDID "
            '    'v_strCmdInquiryRpt = "SELECT M.TXCODE TXCODE, 1 LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
            '    '                    & "FROM APPMODULES M, CMDAUTH A " _
            '    '                    & "WHERE M.TXCODE = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
            '    '                    & "ORDER BY M.TXCODE"
            '    v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryRpt)
            'End If

            'Dim v_wsPrRpt As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'v_wsPrRpt.Message(v_strRptObjMsg)

            'Dim v_xmlPrRptDocument As New Xml.XmlDocument
            'Dim v_nodePrRptList As Xml.XmlNodeList

            'v_xmlPrRptDocument.LoadXml(v_strRptObjMsg)
            'v_nodePrRptList = v_xmlPrRptDocument.SelectNodes("/ObjectMessage/ObjData")
            'Dim v_strTXCODE, v_strCMDID, v_strLEV, v_strCMDALLOW, v_strAUTH, v_strHashKey, v_strHashValue As String
            'For i As Integer = 0 To v_nodePrRptList.Count - 1
            '    For j As Integer = 0 To v_nodePrRptList.Item(i).ChildNodes.Count - 1
            '        With v_nodePrRptList.Item(i).ChildNodes(j)
            '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '            v_strValue = .InnerText.ToString
            '        End With
            '        Select Case Trim(v_strFLDNAME)
            '            Case "TXCODE"
            '                v_strTXCODE = Trim(v_strValue)
            '            Case "CMDID"
            '                v_strCMDID = Trim(v_strValue)
            '            Case "LEV"
            '                v_strLEV = Trim(v_strValue)
            '            Case "CMDALLOW"
            '                v_strCMDALLOW = Trim(v_strValue)
            '            Case "STRAUTH"
            '                v_strAUTH = Trim(v_strValue)
            '        End Select
            '    Next
            '    'Fill to hashtable
            '    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & "R"
            '    hReportFilter.Add(v_strCMDID, v_strHashValue)
            '    mv_strReportAuth &= v_strHashValue & "#"
            'Next

            Dim v_strCmdInquiryRpt, v_strRptObjMsg As String
            Dim v_strTXCODE, v_strCMDID, v_strCNT, v_strMENUTYPE, v_strLEV, v_strCMDALLOW, v_strMODCODE, v_strAUTH, v_strHashKey, v_strHashValue As String
            Dim v_strSQL, v_strObjMsg As String
            'Get Report access right
            If AssignType = "User" Then
                v_strCmdInquiryRpt = "SELECT M.RPTID RPTID, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 4 LEV " _
                                    & "FROM RPTMASTER M, CMDAUTH A " _
                                    & "WHERE M.RPTID = A.CMDCODE AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.RPTID"
                v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryRpt)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryRpt = "SELECT M.RPTID RPTID, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH, 4 LEV " _
                                    & "FROM RPTMASTER M, CMDAUTH A " _
                                    & "WHERE M.RPTID = A.CMDCODE AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                                    & "ORDER BY M.RPTID"
                v_strRptObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryRpt)
            End If

            Dim v_wsRpt As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsRpt.Message(v_strRptObjMsg)

            Dim v_xmlRptDocument As New Xml.XmlDocument
            Dim v_nodeRptList As Xml.XmlNodeList

            v_xmlRptDocument.LoadXml(v_strRptObjMsg)
            v_nodeRptList = v_xmlRptDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strRPTID As String
            For i As Integer = 0 To v_nodeRptList.Count - 1
                Try
                    For j As Integer = 0 To v_nodeRptList.Item(i).ChildNodes.Count - 1
                        With v_nodeRptList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                        End With
                        Select Case Trim(v_strFLDNAME)
                            Case "RPTID"
                                v_strRPTID = v_strValue
                            Case "LEV"
                                v_strLEV = v_strValue
                            Case "CMDALLOW"
                                v_strCMDALLOW = v_strValue
                            Case "STRAUTH"
                                v_strAUTH = v_strValue
                        End Select
                    Next
                    'Fill to hashtable
                    v_strHashValue = v_strRPTID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & "R"
                    If Not hReportFilter.ContainsKey(v_strRPTID) Then
                        hReportFilter.Add(v_strRPTID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Next

            'Get Function access right of user
            Dim v_strCmdInquiryFunc, v_strFuncObjMsg As String
            If AssignType = "User" Then
                v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                                            & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU1 " _
                                                & " LEFT JOIN " _
                                                & " (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU2 " _
                                            & " ON MNU1.CMDID = MNU2.PRID " _
                                            & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                                            & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                                            & " FROM (SELECT M.*, N.TXCODE " _
                                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                                            & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'U' AND A.CMDALLOW = 'Y' " _
                                            & " AND A.AUTHID = '" & UserId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                                            & " ORDER BY M.CMDID) MNU " _
                                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                                    & " ORDER BY MNU.CMDID "

                'v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                '                    & "from CMDMENU M, CMDAUTH A " _
                '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                '                    & "and A.AUTHID = '" & UserId & "' and A.CMDTYPE = 'M' AND (M.LAST = 'N' OR M.MENUTYPE = 'R')" _
                '                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strCmdInquiryFunc)
            ElseIf AssignType = "Group" Then
                v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                                            & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU1 " _
                                                & " LEFT JOIN " _
                                                & " (SELECT M.PRID, M.CMDID CMDID " _
                                                & " FROM CMDMENU M, CMDAUTH A " _
                                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T'  " _
                                                & " ORDER BY M.CMDID) MNU2 " _
                                            & " ON MNU1.CMDID = MNU2.PRID " _
                                            & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                                            & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                                            & " FROM (SELECT M.*, N.TXCODE " _
                                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                                            & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                                            & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                                            & " ORDER BY M.CMDID) MNU " _
                                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                                    & " ORDER BY MNU.CMDID "
                'v_strCmdInquiryFunc = "SELECT MNUMAP.CNT, MNU.* " _
                '                    & " FROM (SELECT MNU1.CMDID, COUNT(MNU2.CMDID) CNT " _
                '                            & " FROM (SELECT M.PRID, M.CMDID CMDID " _
                '                                & " FROM CMDMENU M, CMDAUTH A " _
                '                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                '                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' --AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                '                                & " ORDER BY M.CMDID) MNU1 " _
                '                                & " LEFT JOIN " _
                '                                & " (SELECT M.PRID, M.CMDID CMDID " _
                '                                & " FROM CMDMENU M, CMDAUTH A " _
                '                                & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                '                                & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' --AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                '                                & " ORDER BY M.CMDID) MNU2 " _
                '                            & " ON MNU1.CMDID = MNU2.PRID " _
                '                            & " GROUP BY MNU1.CMDID) MNUMAP,  " _
                '                            & " (SELECT M.PRID, M.CMDID, M.LEV, M.MENUTYPE, M.TXCODE, A.CMDALLOW, A.STRAUTH " _
                '                            & " FROM (SELECT M.*, N.TXCODE " _
                '                                & " FROM CMDMENU M LEFT JOIN APPMODULES N " _
                '                                & " ON TRIM(M.MODCODE) = TRIM(N.MODCODE)) M, CMDAUTH A " _
                '                            & " WHERE M.CMDID = A.CMDCODE AND A.AUTHTYPE = 'G' AND A.CMDALLOW = 'Y' " _
                '                            & " AND A.AUTHID = '" & GroupId & "' AND A.CMDTYPE = 'M' AND M.MENUTYPE <> 'T' AND (M.LAST = 'N' OR M.MENUTYPE = 'R') " _
                '                            & " ORDER BY M.CMDID) MNU " _
                '                    & " WHERE(MNUMAP.CMDID = MNU.CMDID) " _
                '                    & " ORDER BY MNU.CMDID "
                'v_strCmdInquiryFunc = "Select M.CMDID CMDID, M.LEV LEV, A.CMDALLOW CMDALLOW, A.STRAUTH STRAUTH " _
                '                    & "from CMDMENU M, CMDAUTH A " _
                '                    & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                '                    & "and A.AUTHID = '" & GroupId & "' and A.CMDTYPE = 'M'" _
                '                    & "order by M.CMDID"
                v_strFuncObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionInquiry, v_strCmdInquiryFunc)
            End If

            Dim v_wsFunc As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsFunc.Message(v_strFuncObjMsg)

            Dim v_xmlFuncDocument As New Xml.XmlDocument
            Dim v_nodeFuncList As Xml.XmlNodeList

            v_xmlFuncDocument.LoadXml(v_strFuncObjMsg)
            v_nodeFuncList = v_xmlFuncDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeFuncList.Count - 1
                For j As Integer = 0 To v_nodeFuncList.Item(i).ChildNodes.Count - 1
                    With v_nodeFuncList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "CNT"
                            v_strCNT = CStr(v_strValue).Trim
                        Case "CMDID"
                            v_strCMDID = v_strValue
                        Case "LEV"
                            v_strLEV = v_strValue
                        Case "MENUTYPE"
                            v_strMENUTYPE = CStr(v_strValue).Trim
                        Case "TXCODE"
                            v_strMODCODE = CStr(v_strValue).Trim
                        Case "CMDALLOW"
                            v_strCMDALLOW = v_strValue
                        Case "STRAUTH"
                            v_strAUTH = v_strValue
                    End Select
                Next
                'Fill to hashtable
                v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strCMDALLOW & v_strAUTH & "|" & "M"
                If hReportFilter(v_strCMDID) Is Nothing Then
                    hReportFilter.Add(v_strCMDID, v_strHashValue)
                End If
                'Fill to Children hashtable
                If v_strMENUTYPE = "R" Then
                    Dim v_strRPTCNT As String
                    If AssignType = "User" Then
                        v_strSQL = "SELECT COUNT(RPTID) RPTCNT " _
                            & "FROM RPTMASTER M, CMDAUTH A, APPMODULES APP " _
                            & "WHERE APP.TXCODE = '" & v_strMODCODE & "' AND SUBSTR(M.RPTID, 0, 2) = APP.MODCODE AND M.RPTID = A.CMDCODE " _
                            & "AND A.AUTHID = '" & UserId & "' AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                            & "ORDER BY M.RPTID"
                    ElseIf AssignType = "Group" Then
                        v_strSQL = "SELECT COUNT(RPTID) RPTCNT " _
                            & "FROM RPTMASTER M, CMDAUTH A, APPMODULES APP " _
                            & "WHERE APP.TXCODE = '" & v_strMODCODE & "' AND SUBSTR(M.RPTID, 0, 2) = APP.MODCODE AND M.RPTID = A.CMDCODE " _
                            & "AND A.AUTHID = '" & GroupId & "' AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'R' AND A.CMDALLOW = 'Y' " _
                            & "ORDER BY M.RPTID"
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    v_ws.Message(v_strObjMsg)
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_nodeList As Xml.XmlNodeList
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For k As Integer = 0 To v_nodeList.Count - 1
                        For l As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                            With v_nodeList.Item(k).ChildNodes(l)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                            End With
                            Select Case Trim(v_strFLDNAME)
                                Case "RPTCNT"
                                    v_strRPTCNT = CStr(v_strValue).Trim
                            End Select
                        Next
                    Next
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strRPTCNT
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If

                Else
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strMENUTYPE & "|" & v_strCNT
                    If hChildrenFilter(v_strCMDID) Is Nothing Then
                        hChildrenFilter.Add(v_strCMDID, v_strHashValue)
                    End If
                End If

                'mv_strReportAuth &= v_strHashValue & "#"
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục thay đổi kích thước panel --''
    ''---------------------------------------''
    Private Sub DoResizePanel()
        Try
            grbAccessRight.Width = pnlRptAssign.Width - 20
        Catch ex As Exception

        End Try
    End Sub

    ''---------------------------------------''
    ''-- Thủ tục ẩn các control phân quyền --''
    ''---------------------------------------''
    Private Sub DisableAssignment()
        Try
            grbAccessRight.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    ''---------------------------------------------''
    ''-- Thủ tục hiển thị các control phân quyền --''
    ''---------------------------------------------''
    Private Sub EnableAssignment()
        Try
            grbAccessRight.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''-----------------------------------------------------''
    ''-- Thủ tục ẩn các control phân quyền (chế độ View) --''
    ''-----------------------------------------------------''
    Private Sub DisallowChange()
        Try
            ckbVIEW.Enabled = False
            ckbPRINT.Enabled = False
            ckbADD.Enabled = False
            'ckbREGISTER.Enabled = False
            'ckbDELETE.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    ''----------------------------------------------''
    ''-- Thủ tục ghi nội dung phân quyền vào CSDL --''
    ''----------------------------------------------''
    Public Overridable Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_strAllStrAuth, v_strGrpUsrId, v_strAuthString As String

        Try

            If AssignType = "User" Then
                'Get strAuth from menu            
                'v_strAllStrAuth = GetAuthString(stvRptMenu.Items(0))
                v_strAllStrAuth = UserId & "$" & mv_strReportAuth

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strAllStrAuth, "ReportAssignment")
            ElseIf AssignType = "Group" Then
                'Get UsersId of users in this group
                v_strGrpUsrId = GetGrpUsrId(GroupId)
                'Get strAuth from menu            
                'v_strAuthString = GetAuthString(stvRptMenu.Items(0))
                v_strAuthString = mv_strReportAuth
                'Add Groupid and Usersid string to strAuth
                v_strAllStrAuth = GroupId & "$" & v_strAuthString & "$" & v_strGrpUsrId

                'Build XML message
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , v_strAllStrAuth, "ReportAssignment")
            End If

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Check infomations and errors from message
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                Exit Sub
            End If

            MsgBox(mv_ResourceManager.GetString("frmRptAssign.SavingSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_ResourceManager.GetString("frmRptAssign.SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Private Function AddTreeNode(ByRef pv_nodeParent As Node, _
                                     ByVal pv_strKey As String, _
                                     ByVal pv_strName As String, _
                                     Optional ByVal pv_intImageIdx As Integer = 0) As Node
        'Create new node
        Dim v_node As New Node(pv_strName, pv_intImageIdx)
        Dim v_strNodeText, v_strRPTID, v_arrMenuKey() As String
        Try
            If pv_strKey <> "" Then
                v_arrMenuKey = pv_strKey.Split("|")
                v_strRPTID = v_arrMenuKey(0)
            End If
            'Get node's name
            v_strNodeText = v_strRPTID & ": " & pv_strName

            v_node.Key = pv_strKey
            v_node.Text = v_strNodeText
            v_node.ToolTipText = v_strNodeText
            'Add node to menu
            pv_nodeParent.Items.Add(v_node)
            Return v_node

        Catch ex As Exception

        End Try

    End Function

    Private Sub DisplayMenus(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strCmdName, v_strLEV, v_arrHashKey() As String
        Dim v_strMODCODE, v_strMODNAME, v_strCMDID, v_strTXCODE, v_strMenuKey, v_strCMDALLOW, v_strAUTH As String
        Dim v_strLocal As String = "N"

        Try
            If IsShown Then
                If AssignType = "User" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetRptParentMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId, "GetRptParentMenu")
                End If

                Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                m_ws.Message(v_strObjMsg)

                XmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                'stvRptMenu.Visible = False
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "TXCODE"
                                    v_strTXCODE = Trim(v_strValue)
                                Case "MODCODE"
                                    v_strMODCODE = Trim(v_strValue)
                                Case "MODNAME"
                                    v_strMODNAME = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                                Case "STRAUTH"
                                    v_strAUTH = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    'Check CMDALLOW of user who is assigned
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        v_arrHashKey = CStr(hReportFilter(v_strCMDID)).Split("|")
                        v_strCMDALLOW = Trim(v_arrHashKey(2))
                        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                        If v_strCMDALLOW = "Y" Then
                            v_intIndex = 4
                        Else
                            v_intIndex = 0
                        End If
                    Else
                        v_intIndex = 0
                    End If

                    'Add TXCODE and MODCODE to hash tables
                    hTxCodeFilter.Add(v_strMODCODE, v_strTXCODE)
                    hModCodeFilter.Add(v_strCMDID, v_strMODCODE)
                    'Add CMDID to hash tables
                    hCmdIdFilter.Add(v_strMODCODE, v_strCMDID)

                    v_strMenuKey = v_strCMDID & "|" & v_strLEV & "|" & "M" & "|" & "P"

                    Dim v_node As New Node(v_strMODNAME, v_intIndex)
                    v_node.Key = CStr(v_strMenuKey)
                    v_node.ToolTipText = v_strMODNAME
                    v_node.Expanded = False

                    Me.stvRptMenu.Items(0).Items.Add(v_node)
                    AddChildMenu(stvRptMenu.Items(0).Items(CStr(v_strMenuKey)), CStr(v_strMenuKey))
                    'Add value to Report hashtable and RptAuth string

                    'Dim v_strRptHashValue As String
                    'v_strRptHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strAUTH
                    'hReportFilter.Add(v_strTXCODE, v_strRptHashValue)
                    'mv_strReportAuth &= v_strRptHashValue & "#"

                Next v_intCount
            Else
                Me.stvRptMenu.Items(0).Items.Clear()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AddChildMenu(ByRef pv_nodeParent As Node, ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex, v_intLEV As Integer
        Dim v_strFLDNAME, v_strValue, v_strMenuType As String
        Dim v_strObjName, v_strMenuKey, v_strPRCODE, v_strPRLEV, v_arrKey(), v_arrHashKey() As String
        Dim v_strRPTID, v_strMODCODE, v_strRPTNAME, v_strCMDALLOW, v_strSTRAUTH, v_strLEV, v_strCMDTYPE As String
        Dim v_NewNode As New Node

        Try
            v_arrKey = pv_strKey.Split("|")
            v_strPRCODE = CStr(hModCodeFilter(v_arrKey(0)))
            v_strPRLEV = CStr(v_arrKey(1))
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , v_strPRCODE, "GetRptChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId & "|" & v_strPRCODE, "GetRptChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            v_intLEV = CInt(v_strPRLEV) + 1
            v_strLEV = CStr(v_intLEV)

            If Not pv_nodeParent Is Nothing Then
                If v_nodeList.Count > 0 Then
                    For v_intCount = 0 To v_nodeList.Count - 1
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString

                                Select Case Trim(v_strFLDNAME)
                                    Case "RPTID"
                                        v_strRPTID = Trim(v_strValue)
                                    Case "MODCODE"
                                        v_strMODCODE = Trim(v_strValue)
                                    Case "RPTNAME"
                                        v_strRPTNAME = Trim(v_strValue)
                                    Case "CMDTYPE"
                                        v_strCMDTYPE = Trim(v_strValue)
                                        'Case "IMGINDEX"
                                        '    v_intIndex = CInt(Trim(v_strValue))
                                        'Case "CMDALLOW"
                                        '    v_strCMDALLOW = Trim(v_strValue)
                                        'Case "STRAUTH"
                                        '    v_strSTRAUTH = Trim(v_strValue)
                                        'Case "LEV"
                                        '    v_strLEV = Trim(v_strValue)
                                End Select
                            End With
                        Next v_int

                        'Check CMDALLOW of user who is assigned
                        If Not hReportFilter(v_strRPTID) Is Nothing Then
                            v_arrHashKey = CStr(hReportFilter(v_strRPTID)).Split("|")
                            v_strCMDALLOW = Trim(v_arrHashKey(2))
                            v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                            If v_strCMDALLOW = "Y" Then
                                v_intIndex = 5
                            Else
                                v_intIndex = 3
                            End If
                        Else
                            v_intIndex = 3
                        End If


                        'If v_strCMDALLOW = "" Then
                        '    v_strCMDALLOW = "N"
                        'End If
                        'If Trim(v_strCMDALLOW) = "Y" Then
                        '    v_intIndex = 5
                        'Else
                        '    v_intIndex = 3
                        'End If
                        'If v_strSTRAUTH = "" Then
                        '    v_strSTRAUTH = "NNNN"
                        'End If

                        v_strMenuKey = v_strRPTID & "|" & v_strLEV & "|" & "R" & "|" & v_strCMDTYPE

                        AddTreeNode(pv_nodeParent, v_strMenuKey, v_strRPTNAME, v_intIndex)
                        'AddChildMenu(v_NewNode, v_strRPTID)
                        'Add new value to hashtable
                        'Dim v_strRptHashValue As String
                        If hParentsFilter(v_strRPTID) Is Nothing Then
                            hParentsFilter.Add(v_strRPTID, CStr(hCmdIdFilter(v_strMODCODE)))
                        End If
                        'v_strRptHashValue = v_strMenuKey & "|" & v_strCMDALLOW & v_strSTRAUTH
                        'hReportFilter.Add(v_strRPTID, v_strRptHashValue)
                        'mv_strReportAuth &= v_strRptHashValue & "#"
                    Next v_intCount
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub Menu_Click(ByVal pv_treeNode As Node)

        'Update mouse pointer
        Cursor.Current = Cursors.WaitCursor
        Try
            If pv_treeNode.Key <> String.Empty Then
                ShowAccessRight(pv_treeNode)
            Else
                lblREPORT.Text = String.Empty
                DisableAssignment()
            End If
        Catch ex As Exception
            Throw ex
        End Try
        'Update mouse pointer
        Me.ckbPRINT.Enabled = False
        Me.ckbVIEW.Enabled = False
        Cursor.Current = Cursors.Default
    End Sub

    ''---------------------------------------------------------------''
    ''-- Thay đổi các giá trị khi thay đổi trạng thái của checkbox --''
    ''---------------------------------------------------------------''
    Private Sub Checkbox_CheckedChanged(ByVal sender As Object, ByVal pv_treeNode As Node)

        Try
            If pv_treeNode.Items.Count > 0 Then
                DoCheckboxChange(sender, pv_treeNode)
                Dim v_node As Node
                For Each v_node In pv_treeNode.Items
                    If v_node.Items.Count > 0 Then
                        Checkbox_CheckedChanged(sender, v_node)
                    Else
                        DoCheckboxChange(sender, v_node)
                    End If
                Next
            Else
                DoCheckboxChange(sender, pv_treeNode)
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    ''------------------------------''
    ''-- Hiển thị các quyền đã có --''
    ''------------------------------''
    Private Sub ShowAccessRight(ByVal pv_treeNode As Node)
        Dim v_strMenuType, v_strModCode, v_strObjName, v_arrMenuKey() As String
        Dim v_strView, v_strPrint, v_strAdd, v_strEdit, v_strDelete As String
        Dim v_strAuth, v_strCMDID, v_strCMDTYPE, v_arrAuth() As String

        Try

            If pv_treeNode.Key <> String.Empty Then
                v_arrMenuKey = pv_treeNode.Key.Split("|")
                v_strCMDID = v_arrMenuKey(0)
                v_strCMDTYPE = v_arrMenuKey(3)

                If Not hReportFilter(v_strCMDID) Is Nothing Then
                    v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                    v_strAuth = v_arrAuth(2)
                Else
                    v_strAuth = "NNN"
                End If

                'If v_arrMenuKey.Length > 1 Then
                EnableAssignment()
                lblREPORT.Text = pv_treeNode.Text
                'Select Auth string
                'v_strAuth = v_arrMenuKey(1)
                If v_strAuth <> Nothing Then
                    v_strView = Mid(v_strAuth, 1, 1)
                    v_strPrint = Mid(v_strAuth, 2, 1)
                    v_strAdd = Mid(v_strAuth, 3, 1)
                    'v_strEdit = Mid(v_strAuth, 4, 1)
                    'v_strDelete = Mid(v_strAuth, 5, 1)

                    'If (Trim(v_strCMDTYPE) = "R") Or (Trim(v_strCMDTYPE) = "P") Then
                    ckbVIEW.Enabled = True
                    ckbPRINT.Enabled = True
                    ckbADD.Enabled = True
                    'Display Access right
                    ckbVIEW.Checked = (v_strView = "Y")
                    ckbPRINT.Checked = (v_strPrint = "Y")
                    ckbADD.Checked = (v_strAdd = "Y")
                    'ckbREGISTER.Checked = (v_strAdd = "Y")
                    'ckbDELETE.Checked = (v_strDelete = "Y")
                    'Else
                    '    ckbVIEW.Enabled = True
                    '    ckbPRINT.Checked = False
                    '    ckbPRINT.Enabled = False
                    '    ckbADD.Checked = False
                    '    ckbADD.Enabled = True
                    '    ckbVIEW.Checked = (v_strView = "Y")
                    'End If
                End If

                'Allow assign in Edit mode only
                If (ExeFlag = ExecuteFlag.View) Then
                    DisallowChange()
                End If
                'Else
                '    DisableAssignment()
                'End If
            Else

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''-------------------------------------------------------------''
    ''-- + Mục đích: Thay đổi và cập nhật các giá trị phân quyền --''
    ''--             lên key của node of menu tree               --''
    ''-- + Đầu vào: - sender: Checkbox có giá trị thay đổi       --''
    ''--            - pv_treeNode: Node hiện tại của menu tree   --''
    ''-- + Đầu ra: N/A                                           --''
    ''-- + Tác giả: Nguyễn Nhân Thế                              --''
    ''-- + Ghi chú: N/A                                          --''
    ''-------------------------------------------------------------''
    Private Sub DoCheckboxChange(ByVal sender As Object, ByVal pv_treeNode As Node)
        Dim v_node As Node
        Dim v_strView, v_strPrint, v_strAdd As String
        Dim v_strCMDID, v_strMenuType, v_arrMenuKey(), v_strAuth, v_strLEV, v_arrAuth(), v_strHashValue As String

        Try

            'Get Auth string and CMDID
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            v_strMenuType = v_arrMenuKey(2)
            If Not hReportFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                v_strAuth = v_arrAuth(2)
            Else
                v_strAuth = "NNN"
            End If

            If v_strAuth <> String.Empty Then
                'If ckbVIEW's value has changed
                If (sender Is ckbVIEW) Then
                    If ckbVIEW.Checked Then
                        v_strView = "Y"
                        v_strAuth = v_strView & Mid(v_strAuth, 2, 2)
                    Else
                        v_strView = "N"
                        ckbPRINT.Checked = False
                        'ckbREGISTER.Checked = False
                        ckbADD.Checked = False
                        'ckbDELETE.Checked = False
                        v_strPrint = "N"
                        v_strAdd = "N"
                        'v_strEdit = "N"
                        'v_strDelete = "N"
                        v_strAuth = v_strView & v_strPrint & v_strAdd
                    End If
                    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                    'Update new value to hash table
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        'Remove old value before add new value to hash table and auth's string
                        Dim v_strOldHashValue As String
                        v_strOldHashValue = hReportFilter(v_strCMDID)
                        hReportFilter.Remove(v_strCMDID)
                        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                        hReportFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    Else
                        'Add new value to hash table and auth's string
                        hReportFilter.Add(v_strCMDID, v_strHashValue)
                        mv_strReportAuth &= v_strHashValue & "#"
                    End If

                    'If ckbPRINT's value has changed
                ElseIf (sender Is ckbPRINT) Then
                    If (v_strMenuType = "R") Or (v_strMenuType = "P") Then
                        If ckbPRINT.Checked Then
                            v_strPrint = "Y"
                            If ckbVIEW.Checked = False Then
                                ckbVIEW.Checked = True
                            End If
                            v_strView = "Y"
                            v_strAuth = v_strView & v_strPrint & Mid(v_strAuth, 3, 1)
                        Else
                            v_strPrint = "N"
                            'ckbREGISTER.Checked = False
                            ckbADD.Checked = False
                            'ckbDELETE.Checked = False
                            v_strAdd = "N"
                            'v_strEdit = "N"
                            'v_strDelete = "N"
                            v_strAuth = Mid(v_strAuth, 1, 1) & v_strPrint & v_strAdd
                        End If
                        v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                        'Update new value to hash table
                        If Not hReportFilter(v_strCMDID) Is Nothing Then
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strCMDID)
                            hReportFilter.Remove(v_strCMDID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        End If
                    End If


                    'If ckbREGISTER's value has changed
                    'ElseIf (sender Is ckbREGISTER) Then
                    '    If ckbREGISTER.Checked Then
                    '        v_strAdd = "Y"
                    '        If ckbVIEW.Checked = False Then
                    '            ckbVIEW.Checked = True
                    '        End If
                    '        v_strView = "Y"
                    '        If ckbPRINT.Checked = False Then
                    '            ckbPRINT.Checked = True
                    '        End If
                    '        v_strPrint = "Y"
                    '        v_strAuth = v_strView & v_strPrint & v_strAdd & Mid(v_strAuth, 4, 2)
                    '    Else
                    '        v_strAdd = "N"
                    '        v_strAuth = Mid(v_strAuth, 1, 2) & v_strAdd & Mid(v_strAuth, 4, 2)
                    '    End If
                    '    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                    '    'Update new value to hash table
                    '    If Not hReportFilter(v_strCMDID) Is Nothing Then
                    '        'Remove old value before add new value to hash table and auth's string
                    '        Dim v_strOldHashValue As String
                    '        v_strOldHashValue = hReportFilter(v_strCMDID)
                    '        hReportFilter.Remove(v_strCMDID)
                    '        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                    '        hReportFilter.Add(v_strCMDID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    Else
                    '        'Add new value to hash table and auth's string
                    '        hReportFilter.Add(v_strCMDID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    End If

                    'If ckbADD's value has changed
                ElseIf (sender Is ckbADD) Then
                    If (v_strMenuType = "R") Or (v_strMenuType = "P") Or (v_strMenuType = "M") Then
                        If ckbADD.Checked Then
                            'v_strEdit = "Y"
                            If ckbVIEW.Checked = False Then
                                ckbVIEW.Checked = True
                            End If
                            v_strView = "Y"
                            If ckbPRINT.Checked = False Then
                                ckbPRINT.Checked = True
                            End If
                            v_strPrint = "Y"
                            v_strAuth = v_strView & v_strPrint & "Y"
                        Else
                            'v_strEdit = "N"
                            'v_strAuth = Mid(v_strAuth, 1, 3)
                            ckbVIEW.Checked = False
                            ckbPRINT.Checked = False
                            v_strAuth = "NNN"
                        End If
                        v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                        'Update new value to hash table
                        If Not hReportFilter(v_strCMDID) Is Nothing Then
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strCMDID)
                            hReportFilter.Remove(v_strCMDID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strCMDID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        End If
                    End If


                    'If ckbDELETE's value has changed
                    'ElseIf (sender Is ckbDELETE) Then
                    '    If ckbDELETE.Checked Then
                    '        v_strDelete = "Y"
                    '        If ckbVIEW.Checked = False Then
                    '            ckbVIEW.Checked = True
                    '        End If
                    '        v_strView = "Y"
                    '        If ckbPRINT.Checked = False Then
                    '            ckbPRINT.Checked = True
                    '        End If
                    '        v_strPrint = "Y"
                    '        v_strAuth = v_strView & v_strPrint & Mid(v_strAuth, 3, 2) & v_strDelete

                    '    Else
                    '        v_strDelete = "N"
                    '        v_strAuth = Mid(v_strAuth, 1, 4) & v_strDelete
                    '    End If
                    '    v_strHashValue = v_strCMDID & "|" & v_strLEV & "|" & v_strAuth & "|" & v_strMenuType
                    '    'Update new value to hash table
                    '    If Not hReportFilter(v_strCMDID) Is Nothing Then
                    '        'Remove old value before add new value to hash table and auth's string
                    '        Dim v_strOldHashValue As String
                    '        v_strOldHashValue = hReportFilter(v_strCMDID)
                    '        hReportFilter.Remove(v_strCMDID)
                    '        mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                    '        hReportFilter.Add(v_strCMDID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    Else
                    '        'Add new value to hash table and auth's string
                    '        hReportFilter.Add(v_strCMDID, v_strHashValue)
                    '        mv_strReportAuth &= v_strHashValue & "#"
                    '    End If

                End If

                'Set image icon to current node - modified by TungNT
                Dim v_intImgindex As Integer
                Dim v_arrHashKey() As String
                Dim v_strCMDALLOW As String
                If v_strLEV > 3 Then 'Child node
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        v_arrHashKey = CStr(hReportFilter(v_strCMDID)).Split("|")
                        v_strCMDALLOW = Trim(v_arrHashKey(2))
                        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                        If v_strCMDALLOW = "Y" Then
                            v_intImgindex = 5
                        Else
                            v_intImgindex = 3
                        End If
                    Else
                        v_intImgindex = 3
                    End If
                    Dim pv_parentNode As Node = pv_treeNode.ParentItem
                    If Not pv_parentNode Is Nothing Then
                        If v_intImgindex = 5 Then
                            pv_parentNode.ImageIndex = 4
                        Else
                            Dim i, count As Integer
                            count = 0
                            For Each objNode As Node In pv_parentNode.Items
                                If objNode.ImageIndex = 5 Then
                                    count = count + 1
                                End If
                            Next
                            If count > 0 Then
                                pv_parentNode.ImageIndex = 4
                            Else
                                pv_parentNode.ImageIndex = 0
                            End If

                        End If
                    End If
                Else 'Parent node
                    If Not hReportFilter(v_strCMDID) Is Nothing Then
                        v_arrHashKey = CStr(hReportFilter(v_strCMDID)).Split("|")
                        v_strCMDALLOW = Trim(v_arrHashKey(2))
                        v_strCMDALLOW = Mid(v_strCMDALLOW, 1, 1).Trim
                        If v_strCMDALLOW = "Y" Then
                            v_intImgindex = 4
                        Else
                            v_intImgindex = 0
                        End If
                    Else
                        v_intImgindex = 0
                    End If
                End If
                pv_treeNode.ImageIndex = v_intImgindex
                'End

                'Set key for parent node
                If (CInt(v_strLEV) > 1) Then
                    SetParentNodeKey(pv_treeNode)
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''--------------------------------------------------------------''
    ''-- + Mục đích: Set lại key của các node cha của 1 node      --''
    ''-- + Đầu vào: pv_treeNode: node có các node cha cần set key --''
    ''-- + Đầu ra: N/A                                            --''
    ''-- + Tác giả: Nguyễn Nhân Thế                               --''
    ''-- + Ghi chú: N/A                                           --''
    ''--------------------------------------------------------------''
    Private Sub SetParentNodeKey(ByVal pv_treeNode As Node)
        Dim v_strPRID, v_strLEV, v_strCMDID, v_strAUTH, v_strHashValue, v_arrMenuKey() As String
        Dim v_strCMDALLOW, v_strPRCMDALLOW, v_strPRLEV, v_strMODCODE, v_strMenuType, v_arrAuth(), v_arrPrAuth(), v_arrChild() As String
        Dim v_intPRLEV, v_intChildNum As Integer

        Try
            v_arrMenuKey = pv_treeNode.Key.Split("|")
            v_strCMDID = v_arrMenuKey(0)
            v_strLEV = v_arrMenuKey(1)
            If Not hReportFilter(v_strCMDID) Is Nothing Then
                v_arrAuth = CStr(hReportFilter(v_strCMDID)).Split("|")
                v_strCMDALLOW = Mid(CStr(v_arrAuth(2)), 1, 1)

                If v_strCMDALLOW = "Y" Then
                    For i As Integer = 0 To CInt(v_strLEV) - 2
                        v_strPRID = hParentsFilter(v_strCMDID)
                        'v_strPRID = hCmdIdFilter(v_strMODCODE)
                        v_intPRLEV = CInt(v_strLEV) - (i + 1)
                        v_strPRLEV = CStr(v_intPRLEV)

                        If Not hReportFilter(v_strPRID) Is Nothing Then
                            v_arrAuth = CStr(hReportFilter(v_strPRID)).Split("|")
                            v_strAUTH = v_arrAuth(2)
                            v_strMenuType = v_arrAuth(3)
                            v_strCMDALLOW = Mid(v_strAUTH, 1, 1)
                            If v_strCMDALLOW = "N" Then
                                v_strCMDALLOW = "Y"
                            End If
                            v_strAUTH = v_strCMDALLOW & Mid(v_strAUTH, 2)
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                            'Remove old value before add new value to hash table and auth's string
                            Dim v_strOldHashValue As String
                            v_strOldHashValue = hReportFilter(v_strPRID)
                            hReportFilter.Remove(v_strPRID)
                            mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                            hReportFilter.Add(v_strPRID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        Else
                            If CInt(v_strPRLEV) = 3 Then
                                v_strAUTH = "YNN"
                            Else
                                v_strAUTH = "YNNNN"
                            End If
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                            'Add new value to hash table and auth's string
                            hReportFilter.Add(v_strPRID, v_strHashValue)
                            mv_strReportAuth &= v_strHashValue & "#"
                        End If

                        If Not hChildrenFilter(v_strPRID) Is Nothing Then
                            If (CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Then
                                v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                                v_strMenuType = CStr(v_arrChild(2))
                                v_intChildNum = CInt(CStr(v_arrChild(3))) + 1
                                'Update Children hashtable
                                v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strMenuType & "|" & CStr(v_intChildNum)
                                hChildrenFilter.Remove(v_strPRID)
                                hChildrenFilter.Add(v_strPRID, v_strHashValue)
                            End If
                        Else
                            v_intChildNum = 1
                            v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & "M" & "|" & CStr(v_intChildNum)
                            hChildrenFilter.Add(v_strPRID, v_strHashValue)
                        End If

                        v_strCMDID = v_strPRID
                    Next

                ElseIf v_strCMDALLOW = "N" Then
                    For i As Integer = 0 To CInt(v_strLEV) - 2
                        v_strPRID = hParentsFilter(v_strCMDID)
                        'v_strPRID = hCmdIdFilter(v_strMODCODE)
                        v_intPRLEV = CInt(v_strLEV) - (i + 1)
                        v_strPRLEV = CStr(v_intPRLEV)

                        If Not hChildrenFilter(v_strPRID) Is Nothing Then
                            If (CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Then
                                'Tinh lai so node con
                                v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                                v_strMenuType = CStr(v_arrChild(2))
                                v_intChildNum = CInt(CStr(v_arrChild(3)))
                                If v_intChildNum > 0 Then
                                    v_intChildNum = v_intChildNum - 1
                                End If
                                'Update Children hashtable
                                v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strMenuType & "|" & CStr(v_intChildNum)
                                hChildrenFilter.Remove(v_strPRID)
                                hChildrenFilter.Add(v_strPRID, v_strHashValue)
                            Else
                                'Lay len so node con
                                v_arrChild = CStr(hChildrenFilter(v_strPRID)).Split("|")
                                v_strMenuType = CStr(v_arrChild(2))
                                v_intChildNum = CInt(CStr(v_arrChild(3)))
                            End If
                        Else
                            v_intChildNum = 0
                        End If

                        If Not hReportFilter(v_strPRID) Is Nothing Then
                            If (v_intChildNum = 0 And CInt(v_strPRLEV) = CInt(v_strLEV) - 1) Or (v_intChildNum = 1 And CInt(v_strPRLEV) < CInt(v_strLEV) - 1) Then
                                v_arrAuth = CStr(hReportFilter(v_strPRID)).Split("|")
                                v_strAUTH = v_arrAuth(2)
                                v_strMenuType = v_arrAuth(3)
                                If Len(Trim(v_strAUTH)) = 1 Then
                                    v_strAUTH = "N"
                                ElseIf Len(Trim(v_strAUTH)) > 1 Then
                                    If CInt(v_strPRLEV) = 3 Then
                                        v_strAUTH = "NNN"
                                    Else
                                        v_strAUTH = "NNNNN"
                                    End If
                                End If
                                v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & v_strMenuType
                                'Remove old value before add new value to hash table and auth's string
                                Dim v_strOldHashValue As String
                                v_strOldHashValue = hReportFilter(v_strPRID)
                                hReportFilter.Remove(v_strPRID)
                                mv_strReportAuth = Replace(mv_strReportAuth, v_strOldHashValue & "#", "").Trim
                                hReportFilter.Add(v_strPRID, v_strHashValue)
                                mv_strReportAuth &= v_strHashValue & "#"

                                'Set Image
                                Dim v_ParentNode As Node = pv_treeNode.ParentItem
                                v_ParentNode.ImageIndex = 0
                            Else
                                Exit For
                            End If

                        Else
                            'v_strAUTH = "YNNNN"
                            'v_strHashValue = v_strPRID & "|" & v_strPRLEV & "|" & v_strAUTH & "|" & "M"
                            ''Add new value to hash table and auth's string
                            'hReportFilter.Add(v_strPRID, v_strHashValue)
                            'mv_strReportAuth &= v_strHashValue & "#"
                        End If

                        v_strCMDID = v_strPRID
                    Next

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''-------------------------------------------------------------''
    ''-- + Mục đích: Lấy giá trị khóa của các node của menu tree --''
    ''-- + Đầu vào: pv_treeNode: node cần lấy giá trị khóa       --''
    ''-- + Đầu ra: Chuỗi chứa khóa của node cần lấy              --''
    ''-- + Tác giả: Nguyễn Nhân Thế                              --''
    ''-- + Ghi chú: N/A                                          --''
    ''-------------------------------------------------------------''
    Private Function GetAuthString(ByVal pv_treeNode As Node) As String
        Dim v_strAuth As String = String.Empty
        Dim v_treeNode As Node

        Try
            For Each v_treeNode In pv_treeNode.Items
                If (v_treeNode.Key <> String.Empty) Then
                    If (v_treeNode.Items.Count > 0) Then
                        v_strAuth &= GetAuthString(v_treeNode)
                    Else
                        Dim v_arrMenuKey() As String
                        v_arrMenuKey = v_treeNode.Key.Split("|")
                        If v_arrMenuKey.Length > 1 Then
                            v_strAuth &= v_treeNode.Key & "#"
                        End If
                    End If
                End If
            Next

            Return v_strAuth
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    ''---------------------------------------------------''
    ''-- + Mục đích: Lấy mã của những NSD thuộc nhóm   --''
    ''--             và chưa được phân quyền           --''
    ''-- + Đầu vào: pv_strGroupId: Mã nhóm cần lấy     --''
    ''-- + Đầu ra: Chuỗi chứa mã của những NSD cần lấy --''
    ''-- + Tác giả: Nguyễn Nhân Thế                    --''
    ''-- + Ghi chú: N/A                                --''
    ''---------------------------------------------------''
    Private Function GetGrpUsrId(ByVal pv_strGroupId As String) As String
        Dim v_strUsersId As String = String.Empty
        Dim v_strUsrInGrpSql, v_strFLDNAME, v_strValue As String
        Dim v_strObjMsg As String

        Try

            ''''==== Select users' name that are in group ====''''
            v_strUsrInGrpSql = "SELECT TLPROFILES.TLID VALUE, TLPROFILES.TLNAME DISPLAY " _
                                    & "FROM TLPROFILES, TLGRPUSERS, TLGROUPS " _
                                    & "WHERE TLPROFILES.TLID = TLGRPUSERS.TLID AND TLGRPUSERS.GRPID = TLGROUPS.GRPID AND TLGROUPS.GRPID = '" & pv_strGroupId & "' ORDER BY TLPROFILES.TLNAME"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strUsrInGrpSql)
            Dim v_wsIngrp As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsIngrp.Message(v_strObjMsg)
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With
                    Select Case Trim(v_strFLDNAME)
                        Case "VALUE"
                            v_strUsersId &= v_strValue & "#"
                    End Select
                Next
            Next

            Return v_strUsersId
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''==========================================================''
    '' Thủ tục lấy mã của node cha của các node trong menu tree ''
    ''==========================================================''

    Private Sub GetParents(Optional ByVal IsShown As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strMenuKey, v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strLEV As String

        Try
            If IsShown Then
                If AssignType = "User" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                        OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , UserId, "GetUserParentMenu")
                ElseIf AssignType = "Group" Then
                    v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId, "GetUserParentMenu")
                End If

                Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                m_ws.Message(v_strObjMsg)

                XmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString

                            Select Case Trim(v_strFLDNAME)
                                Case "PRID"
                                    v_strPRID = Trim(v_strValue)
                                Case "CMDID"
                                    v_strCMDID = Trim(v_strValue)
                                Case "LEV"
                                    v_strLEV = Trim(v_strValue)
                            End Select
                        End With
                    Next v_int

                    If Len(Trim(v_strPRID)) = 0 Then
                        v_strMenuKey = v_strCMDID & "|" & v_strLEV
                        'Get ID of child node
                        GetChildren(CStr(v_strMenuKey))
                    End If
                Next v_intCount
            Else

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub GetChildren(ByVal pv_strKey As String)
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_strFLDNAME, v_strValue, v_strPRID, v_strCMDID, v_strCmdName, v_strLast, v_strMenuType, v_strLEV As String
        Dim v_strModCode, v_strObjName, v_strMenuKey, v_arrHashKey() As String
        Dim v_strCMDALLOW, v_strSTRAUTH, v_strFuncHashValue As String
        Dim v_NewNode As New Node

        Try
            If AssignType = "User" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLPROFILES, gc_ActionAdhoc, , pv_strKey, "GetUserChildMenu")
            ElseIf AssignType = "Group" Then
                v_strObjMsg = BuildXMLObjMsg(Now.Date, , Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, _
                                OBJNAME_SA_TLGROUPS, gc_ActionAdhoc, , GroupId & "|" & pv_strKey, "GetUserChildMenu")
            End If

            Dim m_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            m_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "PRID"
                                v_strPRID = Trim(v_strValue)
                            Case "CMDID"
                                v_strCMDID = Trim(v_strValue)
                            Case "LEV"
                                v_strLEV = Trim(v_strValue)
                            Case "LAST"
                                v_strLast = Trim(v_strValue)
                            Case "MENUTYPE"
                                v_strMenuType = Trim(v_strValue)
                        End Select
                    End With
                Next v_int

                ''Add new value to hashtable
                If hParentsFilter(v_strCMDID) Is Nothing Then
                    hParentsFilter.Add(v_strCMDID, v_strPRID)
                End If

                'Set menu's key
                v_strMenuKey = v_strCMDID & "|" & v_strLEV
                'Add new node to menu tree
                If (v_strLast <> "Y") And (v_strMenuType <> "T") And (v_strMenuType <> "R") Then
                    GetChildren(v_strMenuKey)
                End If

            Next v_intCount
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub


#End Region

#Region " Form Events "
    Private Sub frmRptAssign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnSave.Click
        OnSave()
    End Sub

    Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnCancel.Click
        OnClose()
    End Sub

    Private Sub pnlRptAssign_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlRptAssign.Resize
        DoResizePanel()
    End Sub

    Private Sub ckbVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbVIEW.Click
        Checkbox_CheckedChanged(ckbVIEW, stvRptMenu.SelectedItem)
    End Sub

    Private Sub ckbPRINT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbPRINT.Click
        Checkbox_CheckedChanged(ckbPRINT, stvRptMenu.SelectedItem)
    End Sub

    Private Sub ckbADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbADD.Click
        Me.ckbPRINT.Checked = Me.ckbADD.Checked
        Me.ckbVIEW.Checked = Me.ckbADD.Checked
        Checkbox_CheckedChanged(ckbADD, stvRptMenu.SelectedItem)
    End Sub

    'Private Sub ckbREGISTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Checkbox_CheckedChanged(ckbREGISTER, stvRptMenu.SelectedItem)
    'End Sub

    'Private Sub ckbDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Checkbox_CheckedChanged(ckbDELETE, stvRptMenu.SelectedItem)
    'End Sub

    Private Sub stvRptMenu_ItemClick(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles stvRptMenu.ItemClick
        Menu_Click(stvRptMenu.SelectedItem)
    End Sub

    Private Sub frmRptAssign_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

#End Region

    
    
End Class
