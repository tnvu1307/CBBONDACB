<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactEx
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransactEx))
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.scrMain = New System.Windows.Forms.SplitContainer
        Me.txtRQSNAME = New System.Windows.Forms.TextBox
        Me.lblRQSNAME = New System.Windows.Forms.Label
        Me.grbExternalTransfer = New System.Windows.Forms.GroupBox
        Me.lblIORO = New System.Windows.Forms.Label
        Me.cboIORO = New AppCore.ComboBoxEx
        Me.txtVATAMT = New System.Windows.Forms.TextBox
        Me.lblVATAMT = New System.Windows.Forms.Label
        Me.txtBENEFCUSTNAME = New System.Windows.Forms.TextBox
        Me.lblBENEFCUSTNAME = New System.Windows.Forms.Label
        Me.txtBENEFBANK = New System.Windows.Forms.TextBox
        Me.lblBENEFBANK = New System.Windows.Forms.Label
        Me.txtBENEFACCT = New System.Windows.Forms.TextBox
        Me.lblBENEFACCT = New System.Windows.Forms.Label
        Me.txtETAMT = New System.Windows.Forms.TextBox
        Me.lblETAMT = New System.Windows.Forms.Label
        Me.txtFEEAMT = New System.Windows.Forms.TextBox
        Me.lblFEEAMT = New System.Windows.Forms.Label
        Me.lblFEECD = New System.Windows.Forms.Label
        Me.txtFEECD = New System.Windows.Forms.TextBox
        Me.grbInternalTransfer = New System.Windows.Forms.GroupBox
        Me.lblAFACCTNO2 = New System.Windows.Forms.Label
        Me.txtIDPLACE2 = New System.Windows.Forms.TextBox
        Me.cboAFACCTNO2 = New System.Windows.Forms.ComboBox
        Me.txtIDCODE2 = New System.Windows.Forms.TextBox
        Me.txtIDDATE2 = New System.Windows.Forms.TextBox
        Me.lblIDDATE2 = New System.Windows.Forms.Label
        Me.lblIDCODE2 = New System.Windows.Forms.Label
        Me.lblIDPLACE2 = New System.Windows.Forms.Label
        Me.txtADDRESS2 = New System.Windows.Forms.TextBox
        Me.lblADDRESS2 = New System.Windows.Forms.Label
        Me.lblCUSTODYCD2 = New System.Windows.Forms.Label
        Me.lblFULLNAME2 = New System.Windows.Forms.Label
        Me.txtCUSTODYCD2 = New System.Windows.Forms.TextBox
        Me.lblREFID = New System.Windows.Forms.Label
        Me.txtREFID = New System.Windows.Forms.TextBox
        Me.lblDESC = New System.Windows.Forms.Label
        Me.txtDESC = New System.Windows.Forms.TextBox
        Me.lblREMAINAMT = New System.Windows.Forms.Label
        Me.txtREMAINAMT = New System.Windows.Forms.MaskedTextBox
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.lblAMT = New System.Windows.Forms.Label
        Me.txtAMT = New System.Windows.Forms.MaskedTextBox
        Me.lblAVAILAMT = New System.Windows.Forms.Label
        Me.txtAVAILAMT = New System.Windows.Forms.MaskedTextBox
        Me.grbCFInfo = New System.Windows.Forms.GroupBox
        Me.txtIDPLACE = New System.Windows.Forms.TextBox
        Me.txtIDDATE = New System.Windows.Forms.TextBox
        Me.txtIDCODE = New System.Windows.Forms.TextBox
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lblIDDATE = New System.Windows.Forms.Label
        Me.lblIDPLACE = New System.Windows.Forms.Label
        Me.lblIDCODE = New System.Windows.Forms.Label
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.btnSubPrint = New System.Windows.Forms.Button
        Me.scrMain.Panel1.SuspendLayout()
        Me.scrMain.SuspendLayout()
        Me.grbExternalTransfer.SuspendLayout()
        Me.grbInternalTransfer.SuspendLayout()
        Me.grbCFInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(589, 423)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Tag = "btnApply"
        Me.btnApply.Text = "btnApply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(670, 423)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(12, 423)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "btnPrint"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'scrMain
        '
        Me.scrMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.scrMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.scrMain.Location = New System.Drawing.Point(0, 0)
        Me.scrMain.Name = "scrMain"
        Me.scrMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scrMain.Panel1
        '
        Me.scrMain.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.scrMain.Panel1.Controls.Add(Me.txtRQSNAME)
        Me.scrMain.Panel1.Controls.Add(Me.lblRQSNAME)
        Me.scrMain.Panel1.Controls.Add(Me.grbExternalTransfer)
        Me.scrMain.Panel1.Controls.Add(Me.grbInternalTransfer)
        Me.scrMain.Panel1.Controls.Add(Me.lblREFID)
        Me.scrMain.Panel1.Controls.Add(Me.txtREFID)
        Me.scrMain.Panel1.Controls.Add(Me.lblDESC)
        Me.scrMain.Panel1.Controls.Add(Me.txtDESC)
        Me.scrMain.Panel1.Controls.Add(Me.lblREMAINAMT)
        Me.scrMain.Panel1.Controls.Add(Me.txtREMAINAMT)
        Me.scrMain.Panel1.Controls.Add(Me.lblCUSTODYCD)
        Me.scrMain.Panel1.Controls.Add(Me.lblAMT)
        Me.scrMain.Panel1.Controls.Add(Me.txtAMT)
        Me.scrMain.Panel1.Controls.Add(Me.lblAVAILAMT)
        Me.scrMain.Panel1.Controls.Add(Me.txtAVAILAMT)
        Me.scrMain.Panel1.Controls.Add(Me.grbCFInfo)
        Me.scrMain.Panel1.Controls.Add(Me.lblFULLNAME)
        Me.scrMain.Panel1.Controls.Add(Me.txtCUSTODYCD)
        Me.scrMain.Size = New System.Drawing.Size(757, 417)
        Me.scrMain.SplitterDistance = 352
        Me.scrMain.TabIndex = 0
        '
        'txtRQSNAME
        '
        Me.txtRQSNAME.Location = New System.Drawing.Point(123, 27)
        Me.txtRQSNAME.Name = "txtRQSNAME"
        Me.txtRQSNAME.Size = New System.Drawing.Size(172, 20)
        Me.txtRQSNAME.TabIndex = 32
        Me.txtRQSNAME.TabStop = False
        Me.txtRQSNAME.Tag = "txtRQSNAME"
        '
        'lblRQSNAME
        '
        Me.lblRQSNAME.AutoSize = True
        Me.lblRQSNAME.Location = New System.Drawing.Point(16, 30)
        Me.lblRQSNAME.Name = "lblRQSNAME"
        Me.lblRQSNAME.Size = New System.Drawing.Size(71, 13)
        Me.lblRQSNAME.TabIndex = 33
        Me.lblRQSNAME.Tag = "lblRQSNAME"
        Me.lblRQSNAME.Text = "lblRQSNAME"
        '
        'grbExternalTransfer
        '
        Me.grbExternalTransfer.Controls.Add(Me.lblIORO)
        Me.grbExternalTransfer.Controls.Add(Me.cboIORO)
        Me.grbExternalTransfer.Controls.Add(Me.txtVATAMT)
        Me.grbExternalTransfer.Controls.Add(Me.lblVATAMT)
        Me.grbExternalTransfer.Controls.Add(Me.txtBENEFCUSTNAME)
        Me.grbExternalTransfer.Controls.Add(Me.lblBENEFCUSTNAME)
        Me.grbExternalTransfer.Controls.Add(Me.txtBENEFBANK)
        Me.grbExternalTransfer.Controls.Add(Me.lblBENEFBANK)
        Me.grbExternalTransfer.Controls.Add(Me.txtBENEFACCT)
        Me.grbExternalTransfer.Controls.Add(Me.lblBENEFACCT)
        Me.grbExternalTransfer.Controls.Add(Me.txtETAMT)
        Me.grbExternalTransfer.Controls.Add(Me.lblETAMT)
        Me.grbExternalTransfer.Controls.Add(Me.txtFEEAMT)
        Me.grbExternalTransfer.Controls.Add(Me.lblFEEAMT)
        Me.grbExternalTransfer.Controls.Add(Me.lblFEECD)
        Me.grbExternalTransfer.Controls.Add(Me.txtFEECD)
        Me.grbExternalTransfer.Location = New System.Drawing.Point(19, 248)
        Me.grbExternalTransfer.Name = "grbExternalTransfer"
        Me.grbExternalTransfer.Size = New System.Drawing.Size(722, 93)
        Me.grbExternalTransfer.TabIndex = 21
        Me.grbExternalTransfer.TabStop = False
        Me.grbExternalTransfer.Tag = "grbExternalTransfer"
        Me.grbExternalTransfer.Text = "grbExternalTransfer"
        '
        'lblIORO
        '
        Me.lblIORO.AutoSize = True
        Me.lblIORO.Location = New System.Drawing.Point(14, 26)
        Me.lblIORO.Name = "lblIORO"
        Me.lblIORO.Size = New System.Drawing.Size(44, 13)
        Me.lblIORO.TabIndex = 31
        Me.lblIORO.Tag = "lblIORO"
        Me.lblIORO.Text = "lblIORO"
        '
        'cboIORO
        '
        Me.cboIORO.DisplayMember = "DISPLAY"
        Me.cboIORO.FormattingEnabled = True
        Me.cboIORO.Location = New System.Drawing.Point(104, 23)
        Me.cboIORO.Name = "cboIORO"
        Me.cboIORO.Size = New System.Drawing.Size(70, 21)
        Me.cboIORO.TabIndex = 0
        Me.cboIORO.Tag = "IORO"
        Me.cboIORO.ValueMember = "VALUE"
        '
        'txtVATAMT
        '
        Me.txtVATAMT.Location = New System.Drawing.Point(272, 46)
        Me.txtVATAMT.Name = "txtVATAMT"
        Me.txtVATAMT.ReadOnly = True
        Me.txtVATAMT.Size = New System.Drawing.Size(73, 20)
        Me.txtVATAMT.TabIndex = 27
        Me.txtVATAMT.TabStop = False
        Me.txtVATAMT.Tag = "VATAMT"
        Me.txtVATAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVATAMT
        '
        Me.lblVATAMT.AutoSize = True
        Me.lblVATAMT.Location = New System.Drawing.Point(182, 49)
        Me.lblVATAMT.Name = "lblVATAMT"
        Me.lblVATAMT.Size = New System.Drawing.Size(61, 13)
        Me.lblVATAMT.TabIndex = 26
        Me.lblVATAMT.Tag = "lblVATAMT"
        Me.lblVATAMT.Text = "lblVATAMT"
        '
        'txtBENEFCUSTNAME
        '
        Me.txtBENEFCUSTNAME.Location = New System.Drawing.Point(491, 67)
        Me.txtBENEFCUSTNAME.Name = "txtBENEFCUSTNAME"
        Me.txtBENEFCUSTNAME.Size = New System.Drawing.Size(225, 20)
        Me.txtBENEFCUSTNAME.TabIndex = 4
        Me.txtBENEFCUSTNAME.Tag = "BENEFCUSTNAME"
        '
        'lblBENEFCUSTNAME
        '
        Me.lblBENEFCUSTNAME.AutoSize = True
        Me.lblBENEFCUSTNAME.Location = New System.Drawing.Point(359, 74)
        Me.lblBENEFCUSTNAME.Name = "lblBENEFCUSTNAME"
        Me.lblBENEFCUSTNAME.Size = New System.Drawing.Size(112, 13)
        Me.lblBENEFCUSTNAME.TabIndex = 24
        Me.lblBENEFCUSTNAME.Tag = "lblBENEFCUSTNAME"
        Me.lblBENEFCUSTNAME.Text = "lblBENEFCUSTNAME"
        '
        'txtBENEFBANK
        '
        Me.txtBENEFBANK.Location = New System.Drawing.Point(491, 45)
        Me.txtBENEFBANK.Name = "txtBENEFBANK"
        Me.txtBENEFBANK.Size = New System.Drawing.Size(225, 20)
        Me.txtBENEFBANK.TabIndex = 3
        Me.txtBENEFBANK.Tag = "BENEFBANK"
        '
        'lblBENEFBANK
        '
        Me.lblBENEFBANK.AutoSize = True
        Me.lblBENEFBANK.Location = New System.Drawing.Point(359, 52)
        Me.lblBENEFBANK.Name = "lblBENEFBANK"
        Me.lblBENEFBANK.Size = New System.Drawing.Size(81, 13)
        Me.lblBENEFBANK.TabIndex = 22
        Me.lblBENEFBANK.Tag = "lblBENEFBANK"
        Me.lblBENEFBANK.Text = "lblBENEFBANK"
        '
        'txtBENEFACCT
        '
        Me.txtBENEFACCT.Location = New System.Drawing.Point(491, 23)
        Me.txtBENEFACCT.Name = "txtBENEFACCT"
        Me.txtBENEFACCT.Size = New System.Drawing.Size(225, 20)
        Me.txtBENEFACCT.TabIndex = 2
        Me.txtBENEFACCT.Tag = "BENEFACCT"
        '
        'lblBENEFACCT
        '
        Me.lblBENEFACCT.AutoSize = True
        Me.lblBENEFACCT.Location = New System.Drawing.Point(359, 30)
        Me.lblBENEFACCT.Name = "lblBENEFACCT"
        Me.lblBENEFACCT.Size = New System.Drawing.Size(80, 13)
        Me.lblBENEFACCT.TabIndex = 20
        Me.lblBENEFACCT.Tag = "lblBENEFACCT"
        Me.lblBENEFACCT.Text = "lblBENEFACCT"
        '
        'txtETAMT
        '
        Me.txtETAMT.Location = New System.Drawing.Point(104, 68)
        Me.txtETAMT.Name = "txtETAMT"
        Me.txtETAMT.ReadOnly = True
        Me.txtETAMT.Size = New System.Drawing.Size(241, 20)
        Me.txtETAMT.TabIndex = 19
        Me.txtETAMT.TabStop = False
        Me.txtETAMT.Tag = "ETAMT"
        Me.txtETAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblETAMT
        '
        Me.lblETAMT.AutoSize = True
        Me.lblETAMT.Location = New System.Drawing.Point(14, 71)
        Me.lblETAMT.Name = "lblETAMT"
        Me.lblETAMT.Size = New System.Drawing.Size(54, 13)
        Me.lblETAMT.TabIndex = 18
        Me.lblETAMT.Tag = "lblETAMT"
        Me.lblETAMT.Text = "lblETAMT"
        '
        'txtFEEAMT
        '
        Me.txtFEEAMT.Location = New System.Drawing.Point(104, 46)
        Me.txtFEEAMT.Name = "txtFEEAMT"
        Me.txtFEEAMT.ReadOnly = True
        Me.txtFEEAMT.Size = New System.Drawing.Size(70, 20)
        Me.txtFEEAMT.TabIndex = 17
        Me.txtFEEAMT.TabStop = False
        Me.txtFEEAMT.Tag = "FEEAMT"
        Me.txtFEEAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFEEAMT
        '
        Me.lblFEEAMT.AutoSize = True
        Me.lblFEEAMT.Location = New System.Drawing.Point(14, 49)
        Me.lblFEEAMT.Name = "lblFEEAMT"
        Me.lblFEEAMT.Size = New System.Drawing.Size(60, 13)
        Me.lblFEEAMT.TabIndex = 16
        Me.lblFEEAMT.Tag = "lblFEEAMT"
        Me.lblFEEAMT.Text = "lblFEEAMT"
        '
        'lblFEECD
        '
        Me.lblFEECD.AutoSize = True
        Me.lblFEECD.Location = New System.Drawing.Point(182, 26)
        Me.lblFEECD.Name = "lblFEECD"
        Me.lblFEECD.Size = New System.Drawing.Size(52, 13)
        Me.lblFEECD.TabIndex = 17
        Me.lblFEECD.Tag = "lblFEECD"
        Me.lblFEECD.Text = "lblFEECD"
        '
        'txtFEECD
        '
        Me.txtFEECD.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtFEECD.Location = New System.Drawing.Point(272, 23)
        Me.txtFEECD.MaxLength = 10
        Me.txtFEECD.Name = "txtFEECD"
        Me.txtFEECD.Size = New System.Drawing.Size(73, 20)
        Me.txtFEECD.TabIndex = 1
        Me.txtFEECD.Tag = "$FEECD"
        '
        'grbInternalTransfer
        '
        Me.grbInternalTransfer.Controls.Add(Me.lblAFACCTNO2)
        Me.grbInternalTransfer.Controls.Add(Me.txtIDPLACE2)
        Me.grbInternalTransfer.Controls.Add(Me.cboAFACCTNO2)
        Me.grbInternalTransfer.Controls.Add(Me.txtIDCODE2)
        Me.grbInternalTransfer.Controls.Add(Me.txtIDDATE2)
        Me.grbInternalTransfer.Controls.Add(Me.lblIDDATE2)
        Me.grbInternalTransfer.Controls.Add(Me.lblIDCODE2)
        Me.grbInternalTransfer.Controls.Add(Me.lblIDPLACE2)
        Me.grbInternalTransfer.Controls.Add(Me.txtADDRESS2)
        Me.grbInternalTransfer.Controls.Add(Me.lblADDRESS2)
        Me.grbInternalTransfer.Controls.Add(Me.lblCUSTODYCD2)
        Me.grbInternalTransfer.Controls.Add(Me.lblFULLNAME2)
        Me.grbInternalTransfer.Controls.Add(Me.txtCUSTODYCD2)
        Me.grbInternalTransfer.Location = New System.Drawing.Point(19, 149)
        Me.grbInternalTransfer.Name = "grbInternalTransfer"
        Me.grbInternalTransfer.Size = New System.Drawing.Size(722, 93)
        Me.grbInternalTransfer.TabIndex = 20
        Me.grbInternalTransfer.TabStop = False
        Me.grbInternalTransfer.Tag = "grbInternalTransfer"
        Me.grbInternalTransfer.Text = "grbInternalTransfer"
        '
        'lblAFACCTNO2
        '
        Me.lblAFACCTNO2.AutoSize = True
        Me.lblAFACCTNO2.Location = New System.Drawing.Point(211, 26)
        Me.lblAFACCTNO2.Name = "lblAFACCTNO2"
        Me.lblAFACCTNO2.Size = New System.Drawing.Size(80, 13)
        Me.lblAFACCTNO2.TabIndex = 33
        Me.lblAFACCTNO2.Tag = "lblAFACCTNO2"
        Me.lblAFACCTNO2.Text = "lblAFACCTNO2"
        '
        'txtIDPLACE2
        '
        Me.txtIDPLACE2.Location = New System.Drawing.Point(566, 67)
        Me.txtIDPLACE2.Name = "txtIDPLACE2"
        Me.txtIDPLACE2.ReadOnly = True
        Me.txtIDPLACE2.Size = New System.Drawing.Size(150, 20)
        Me.txtIDPLACE2.TabIndex = 13
        Me.txtIDPLACE2.TabStop = False
        '
        'cboAFACCTNO2
        '
        Me.cboAFACCTNO2.FormattingEnabled = True
        Me.cboAFACCTNO2.Location = New System.Drawing.Point(301, 22)
        Me.cboAFACCTNO2.Name = "cboAFACCTNO2"
        Me.cboAFACCTNO2.Size = New System.Drawing.Size(415, 21)
        Me.cboAFACCTNO2.TabIndex = 1
        '
        'txtIDCODE2
        '
        Me.txtIDCODE2.Location = New System.Drawing.Point(204, 67)
        Me.txtIDCODE2.Name = "txtIDCODE2"
        Me.txtIDCODE2.ReadOnly = True
        Me.txtIDCODE2.Size = New System.Drawing.Size(124, 20)
        Me.txtIDCODE2.TabIndex = 12
        Me.txtIDCODE2.TabStop = False
        '
        'txtIDDATE2
        '
        Me.txtIDDATE2.Location = New System.Drawing.Point(413, 68)
        Me.txtIDDATE2.Name = "txtIDDATE2"
        Me.txtIDDATE2.ReadOnly = True
        Me.txtIDDATE2.Size = New System.Drawing.Size(79, 20)
        Me.txtIDDATE2.TabIndex = 14
        Me.txtIDDATE2.TabStop = False
        '
        'lblIDDATE2
        '
        Me.lblIDDATE2.AutoSize = True
        Me.lblIDDATE2.Location = New System.Drawing.Point(339, 71)
        Me.lblIDDATE2.Name = "lblIDDATE2"
        Me.lblIDDATE2.Size = New System.Drawing.Size(63, 13)
        Me.lblIDDATE2.TabIndex = 12
        Me.lblIDDATE2.Tag = "lblIDDATE2"
        Me.lblIDDATE2.Text = "lblIDDATE2"
        '
        'lblIDCODE2
        '
        Me.lblIDCODE2.AutoSize = True
        Me.lblIDCODE2.Location = New System.Drawing.Point(130, 70)
        Me.lblIDCODE2.Name = "lblIDCODE2"
        Me.lblIDCODE2.Size = New System.Drawing.Size(64, 13)
        Me.lblIDCODE2.TabIndex = 11
        Me.lblIDCODE2.Tag = "lblIDCODE2"
        Me.lblIDCODE2.Text = "lblIDCODE2"
        '
        'lblIDPLACE2
        '
        Me.lblIDPLACE2.AutoSize = True
        Me.lblIDPLACE2.Location = New System.Drawing.Point(498, 71)
        Me.lblIDPLACE2.Name = "lblIDPLACE2"
        Me.lblIDPLACE2.Size = New System.Drawing.Size(68, 13)
        Me.lblIDPLACE2.TabIndex = 11
        Me.lblIDPLACE2.Tag = "lblIDPLACE2"
        Me.lblIDPLACE2.Text = "lblIDPLACE2"
        '
        'txtADDRESS2
        '
        Me.txtADDRESS2.Location = New System.Drawing.Point(413, 45)
        Me.txtADDRESS2.Name = "txtADDRESS2"
        Me.txtADDRESS2.ReadOnly = True
        Me.txtADDRESS2.Size = New System.Drawing.Size(303, 20)
        Me.txtADDRESS2.TabIndex = 12
        Me.txtADDRESS2.TabStop = False
        '
        'lblADDRESS2
        '
        Me.lblADDRESS2.AutoSize = True
        Me.lblADDRESS2.Location = New System.Drawing.Point(339, 48)
        Me.lblADDRESS2.Name = "lblADDRESS2"
        Me.lblADDRESS2.Size = New System.Drawing.Size(75, 13)
        Me.lblADDRESS2.TabIndex = 11
        Me.lblADDRESS2.Tag = "lblADDRESS2"
        Me.lblADDRESS2.Text = "lblADDRESS2"
        '
        'lblCUSTODYCD2
        '
        Me.lblCUSTODYCD2.AutoSize = True
        Me.lblCUSTODYCD2.Location = New System.Drawing.Point(14, 25)
        Me.lblCUSTODYCD2.Name = "lblCUSTODYCD2"
        Me.lblCUSTODYCD2.Size = New System.Drawing.Size(90, 13)
        Me.lblCUSTODYCD2.TabIndex = 15
        Me.lblCUSTODYCD2.Tag = "lblCUSTODYCD2"
        Me.lblCUSTODYCD2.Text = "lblCUSTODYCD2"
        '
        'lblFULLNAME2
        '
        Me.lblFULLNAME2.AutoSize = True
        Me.lblFULLNAME2.Location = New System.Drawing.Point(14, 49)
        Me.lblFULLNAME2.Name = "lblFULLNAME2"
        Me.lblFULLNAME2.Size = New System.Drawing.Size(80, 13)
        Me.lblFULLNAME2.TabIndex = 14
        Me.lblFULLNAME2.Tag = "lblFULLNAME2"
        Me.lblFULLNAME2.Text = "lblFULLNAME2"
        '
        'txtCUSTODYCD2
        '
        Me.txtCUSTODYCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtCUSTODYCD2.Location = New System.Drawing.Point(104, 22)
        Me.txtCUSTODYCD2.MaxLength = 10
        Me.txtCUSTODYCD2.Name = "txtCUSTODYCD2"
        Me.txtCUSTODYCD2.Size = New System.Drawing.Size(95, 20)
        Me.txtCUSTODYCD2.TabIndex = 0
        Me.txtCUSTODYCD2.Tag = "CUSTODYCD2"
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(548, 8)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(49, 13)
        Me.lblREFID.TabIndex = 19
        Me.lblREFID.Tag = "lblREFID"
        Me.lblREFID.Text = "lblREFID"
        '
        'txtREFID
        '
        Me.txtREFID.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtREFID.Location = New System.Drawing.Point(632, 5)
        Me.txtREFID.Name = "txtREFID"
        Me.txtREFID.ReadOnly = True
        Me.txtREFID.Size = New System.Drawing.Size(107, 20)
        Me.txtREFID.TabIndex = 10
        Me.txtREFID.TabStop = False
        Me.txtREFID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDESC
        '
        Me.lblDESC.AutoSize = True
        Me.lblDESC.Location = New System.Drawing.Point(16, 126)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(46, 13)
        Me.lblDESC.TabIndex = 17
        Me.lblDESC.Tag = "lblDESC"
        Me.lblDESC.Text = "lblDESC"
        '
        'txtDESC
        '
        Me.txtDESC.Location = New System.Drawing.Point(123, 123)
        Me.txtDESC.MaxLength = 1000
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(616, 20)
        Me.txtDESC.TabIndex = 2
        Me.txtDESC.Tag = "txtDESC"
        '
        'lblREMAINAMT
        '
        Me.lblREMAINAMT.AutoSize = True
        Me.lblREMAINAMT.Location = New System.Drawing.Point(15, 99)
        Me.lblREMAINAMT.Name = "lblREMAINAMT"
        Me.lblREMAINAMT.Size = New System.Drawing.Size(82, 13)
        Me.lblREMAINAMT.TabIndex = 13
        Me.lblREMAINAMT.Tag = "lblREMAINAMT"
        Me.lblREMAINAMT.Text = "lblREMAINAMT"
        '
        'txtREMAINAMT
        '
        Me.txtREMAINAMT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtREMAINAMT.Location = New System.Drawing.Point(123, 97)
        Me.txtREMAINAMT.Name = "txtREMAINAMT"
        Me.txtREMAINAMT.ReadOnly = True
        Me.txtREMAINAMT.Size = New System.Drawing.Size(172, 20)
        Me.txtREMAINAMT.TabIndex = 10
        Me.txtREMAINAMT.TabStop = False
        Me.txtREMAINAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtREMAINAMT.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(16, 8)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(84, 13)
        Me.lblCUSTODYCD.TabIndex = 12
        Me.lblCUSTODYCD.Tag = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'lblAMT
        '
        Me.lblAMT.AutoSize = True
        Me.lblAMT.Location = New System.Drawing.Point(15, 78)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.Size = New System.Drawing.Size(40, 13)
        Me.lblAMT.TabIndex = 10
        Me.lblAMT.Tag = "lblAMT"
        Me.lblAMT.Text = "lblAMT"
        '
        'txtAMT
        '
        Me.txtAMT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtAMT.Location = New System.Drawing.Point(123, 75)
        Me.txtAMT.Name = "txtAMT"
        Me.txtAMT.Size = New System.Drawing.Size(172, 20)
        Me.txtAMT.TabIndex = 1
        Me.txtAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAMT.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblAVAILAMT
        '
        Me.lblAVAILAMT.AutoSize = True
        Me.lblAVAILAMT.Location = New System.Drawing.Point(15, 55)
        Me.lblAVAILAMT.Name = "lblAVAILAMT"
        Me.lblAVAILAMT.Size = New System.Drawing.Size(70, 13)
        Me.lblAVAILAMT.TabIndex = 8
        Me.lblAVAILAMT.Tag = "lblAVAILAMT"
        Me.lblAVAILAMT.Text = "lblAVAILAMT"
        '
        'txtAVAILAMT
        '
        Me.txtAVAILAMT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtAVAILAMT.Location = New System.Drawing.Point(123, 53)
        Me.txtAVAILAMT.Name = "txtAVAILAMT"
        Me.txtAVAILAMT.ReadOnly = True
        Me.txtAVAILAMT.Size = New System.Drawing.Size(172, 20)
        Me.txtAVAILAMT.TabIndex = 10
        Me.txtAVAILAMT.TabStop = False
        Me.txtAVAILAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAVAILAMT.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'grbCFInfo
        '
        Me.grbCFInfo.Controls.Add(Me.txtIDPLACE)
        Me.grbCFInfo.Controls.Add(Me.txtIDDATE)
        Me.grbCFInfo.Controls.Add(Me.txtIDCODE)
        Me.grbCFInfo.Controls.Add(Me.txtADDRESS)
        Me.grbCFInfo.Controls.Add(Me.lblIDDATE)
        Me.grbCFInfo.Controls.Add(Me.lblIDPLACE)
        Me.grbCFInfo.Controls.Add(Me.lblIDCODE)
        Me.grbCFInfo.Controls.Add(Me.lblADDRESS)
        Me.grbCFInfo.Location = New System.Drawing.Point(342, 31)
        Me.grbCFInfo.Name = "grbCFInfo"
        Me.grbCFInfo.Size = New System.Drawing.Size(399, 89)
        Me.grbCFInfo.TabIndex = 2
        Me.grbCFInfo.TabStop = False
        Me.grbCFInfo.Text = "grbCFInfo"
        '
        'txtIDPLACE
        '
        Me.txtIDPLACE.Location = New System.Drawing.Point(243, 60)
        Me.txtIDPLACE.Name = "txtIDPLACE"
        Me.txtIDPLACE.ReadOnly = True
        Me.txtIDPLACE.Size = New System.Drawing.Size(150, 20)
        Me.txtIDPLACE.TabIndex = 10
        Me.txtIDPLACE.TabStop = False
        Me.txtIDPLACE.Tag = "IDPLACE"
        '
        'txtIDDATE
        '
        Me.txtIDDATE.Location = New System.Drawing.Point(90, 61)
        Me.txtIDDATE.Name = "txtIDDATE"
        Me.txtIDDATE.ReadOnly = True
        Me.txtIDDATE.Size = New System.Drawing.Size(79, 20)
        Me.txtIDDATE.TabIndex = 10
        Me.txtIDDATE.TabStop = False
        Me.txtIDDATE.Tag = "IDDATE"
        '
        'txtIDCODE
        '
        Me.txtIDCODE.Location = New System.Drawing.Point(90, 39)
        Me.txtIDCODE.Name = "txtIDCODE"
        Me.txtIDCODE.ReadOnly = True
        Me.txtIDCODE.Size = New System.Drawing.Size(124, 20)
        Me.txtIDCODE.TabIndex = 10
        Me.txtIDCODE.TabStop = False
        Me.txtIDCODE.Tag = "IDCODE"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(90, 17)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.ReadOnly = True
        Me.txtADDRESS.Size = New System.Drawing.Size(303, 20)
        Me.txtADDRESS.TabIndex = 10
        Me.txtADDRESS.TabStop = False
        Me.txtADDRESS.Tag = "ADDRESS"
        '
        'lblIDDATE
        '
        Me.lblIDDATE.AutoSize = True
        Me.lblIDDATE.Location = New System.Drawing.Point(16, 64)
        Me.lblIDDATE.Name = "lblIDDATE"
        Me.lblIDDATE.Size = New System.Drawing.Size(57, 13)
        Me.lblIDDATE.TabIndex = 3
        Me.lblIDDATE.Tag = "lblIDDATE"
        Me.lblIDDATE.Text = "lblIDDATE"
        '
        'lblIDPLACE
        '
        Me.lblIDPLACE.AutoSize = True
        Me.lblIDPLACE.Location = New System.Drawing.Point(175, 64)
        Me.lblIDPLACE.Name = "lblIDPLACE"
        Me.lblIDPLACE.Size = New System.Drawing.Size(62, 13)
        Me.lblIDPLACE.TabIndex = 2
        Me.lblIDPLACE.Tag = "lblIDPLACE"
        Me.lblIDPLACE.Text = "lblIDPLACE"
        '
        'lblIDCODE
        '
        Me.lblIDCODE.AutoSize = True
        Me.lblIDCODE.Location = New System.Drawing.Point(16, 42)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(58, 13)
        Me.lblIDCODE.TabIndex = 1
        Me.lblIDCODE.Tag = "lblIDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.AutoSize = True
        Me.lblADDRESS.Location = New System.Drawing.Point(15, 21)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(69, 13)
        Me.lblADDRESS.TabIndex = 0
        Me.lblADDRESS.Tag = "lblADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.AutoSize = True
        Me.lblFULLNAME.Location = New System.Drawing.Point(224, 8)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(74, 13)
        Me.lblFULLNAME.TabIndex = 1
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(123, 5)
        Me.txtCUSTODYCD.MaxLength = 10
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(95, 20)
        Me.txtCUSTODYCD.TabIndex = 0
        Me.txtCUSTODYCD.Tag = "CUSTODYCD"
        '
        'btnSubPrint
        '
        Me.btnSubPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSubPrint.Location = New System.Drawing.Point(124, 423)
        Me.btnSubPrint.Name = "btnSubPrint"
        Me.btnSubPrint.Size = New System.Drawing.Size(107, 23)
        Me.btnSubPrint.TabIndex = 4
        Me.btnSubPrint.Tag = "btnSubPrint"
        Me.btnSubPrint.Text = "btnSubPrint"
        Me.btnSubPrint.UseVisualStyleBackColor = True
        '
        'frmTransactEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 454)
        Me.Controls.Add(Me.btnSubPrint)
        Me.Controls.Add(Me.scrMain)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransactEx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTransactEx"
        Me.scrMain.Panel1.ResumeLayout(False)
        Me.scrMain.Panel1.PerformLayout()
        Me.scrMain.ResumeLayout(False)
        Me.grbExternalTransfer.ResumeLayout(False)
        Me.grbExternalTransfer.PerformLayout()
        Me.grbInternalTransfer.ResumeLayout(False)
        Me.grbInternalTransfer.PerformLayout()
        Me.grbCFInfo.ResumeLayout(False)
        Me.grbCFInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents scrMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents grbCFInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblIDPLACE As System.Windows.Forms.Label
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Friend WithEvents txtAMT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblAVAILAMT As System.Windows.Forms.Label
    Friend WithEvents txtAVAILAMT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIDPLACE As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDATE As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCODE As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblIDDATE As System.Windows.Forms.Label
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents lblREMAINAMT As System.Windows.Forms.Label
    Friend WithEvents txtREMAINAMT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents txtREFID As System.Windows.Forms.TextBox
    Friend WithEvents grbInternalTransfer As System.Windows.Forms.GroupBox
    Friend WithEvents grbExternalTransfer As System.Windows.Forms.GroupBox
    Friend WithEvents txtADDRESS2 As System.Windows.Forms.TextBox
    Friend WithEvents lblADDRESS2 As System.Windows.Forms.Label
    Friend WithEvents lblCUSTODYCD2 As System.Windows.Forms.Label
    Friend WithEvents lblFULLNAME2 As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIDPLACE2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCODE2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDATE2 As System.Windows.Forms.TextBox
    Friend WithEvents lblIDDATE2 As System.Windows.Forms.Label
    Friend WithEvents lblIDCODE2 As System.Windows.Forms.Label
    Friend WithEvents lblIDPLACE2 As System.Windows.Forms.Label
    Friend WithEvents txtETAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblETAMT As System.Windows.Forms.Label
    Friend WithEvents txtFEEAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblFEEAMT As System.Windows.Forms.Label
    Friend WithEvents lblFEECD As System.Windows.Forms.Label
    Friend WithEvents txtFEECD As System.Windows.Forms.TextBox
    Friend WithEvents txtVATAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblVATAMT As System.Windows.Forms.Label
    Friend WithEvents txtBENEFCUSTNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBENEFCUSTNAME As System.Windows.Forms.Label
    Friend WithEvents txtBENEFBANK As System.Windows.Forms.TextBox
    Friend WithEvents lblBENEFBANK As System.Windows.Forms.Label
    Friend WithEvents txtBENEFACCT As System.Windows.Forms.TextBox
    Friend WithEvents lblBENEFACCT As System.Windows.Forms.Label
    Friend WithEvents lblIORO As System.Windows.Forms.Label
    Friend WithEvents cboIORO As AppCore.ComboBoxEx
    Friend WithEvents lblAFACCTNO2 As System.Windows.Forms.Label
    Friend WithEvents cboAFACCTNO2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtRQSNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblRQSNAME As System.Windows.Forms.Label
    Friend WithEvents btnSubPrint As System.Windows.Forms.Button
End Class
