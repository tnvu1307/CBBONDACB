Imports AppCore
Imports CommonLibrary

Public Class frmAbout
    Inherits System.Windows.Forms.Form

    Private v_dgrTest As GridEx
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSystemStatus As System.Windows.Forms.Label
    Private v_frm As frmProcessing
    Public strVersion As String

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
    Friend WithEvents picSplash As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.picSplash = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblSystemStatus = New System.Windows.Forms.Label
        CType(Me.picSplash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picSplash
        '
        Me.picSplash.BackgroundImage = CType(resources.GetObject("picSplash.BackgroundImage"), System.Drawing.Image)
        Me.picSplash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picSplash.Image = CType(resources.GetObject("picSplash.Image"), System.Drawing.Image)
        Me.picSplash.Location = New System.Drawing.Point(0, 0)
        Me.picSplash.Name = "picSplash"
        Me.picSplash.Size = New System.Drawing.Size(453, 341)
        Me.picSplash.TabIndex = 3
        Me.picSplash.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Phiên bản "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(390, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "© 2008 - Bản quyền này thuộc về" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   CÔNG TY CỔ PHẦN GIẢI PHÁP PHẦN MỀM TÀI CHÍNH"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(51, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(293, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Liên hệ:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tel:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(92, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(281, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "(+84.4) 73 088 998  hoặc  (+84.4) 39 410 191"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(51, 256)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Web:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.LinkLabel1.Location = New System.Drawing.Point(95, 256)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(100, 23)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "www.fss.com.vn"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fax:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(93, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 23)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "(+84.4) 39 410 190 "
        '
        'lblSystemStatus
        '
        Me.lblSystemStatus.BackColor = System.Drawing.SystemColors.Window
        Me.lblSystemStatus.ForeColor = System.Drawing.Color.Red
        Me.lblSystemStatus.Location = New System.Drawing.Point(50, 284)
        Me.lblSystemStatus.Name = "lblSystemStatus"
        Me.lblSystemStatus.Size = New System.Drawing.Size(344, 44)
        Me.lblSystemStatus.TabIndex = 14
        Me.lblSystemStatus.Text = "System status"
        '
        'frmAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(453, 341)
        Me.Controls.Add(Me.lblSystemStatus)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picSplash)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About Flex Securities Trading System"
        CType(Me.picSplash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)

        'Label1.Text &= myBuildInfo.FileVersion
        Label1.Text &= strVersion
        lblSystemStatus.Text = GetSystemStatus()
    End Sub

    Private Function GetSystemStatus() As String
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSystemStatus, v_strValue, v_strFLDNAME As String
            Dim v_strSQL As String

            v_strSQL = "Select fn_GetSystemStatus SYSTEMSTATUS from Dual"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_strSystemStatus = "System Status"
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "SYSTEMSTATUS"
                                v_strSystemStatus = v_strValue
                        End Select
                    End With
                Next
            Next
            Return v_strSystemStatus
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
