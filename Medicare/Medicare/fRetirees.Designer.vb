<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fRetirees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fRetirees))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tslblSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtSearchBy = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.gbClientRequest = New System.Windows.Forms.GroupBox
        Me.txtOSPGST = New System.Windows.Forms.TextBox
        Me.lblOSPGST1 = New System.Windows.Forms.Label
        Me.lblOSPGST = New System.Windows.Forms.Label
        Me.txtOSP = New System.Windows.Forms.TextBox
        Me.lblOSP1 = New System.Windows.Forms.Label
        Me.lblOSP = New System.Windows.Forms.Label
        Me.txtTotalPremium = New System.Windows.Forms.TextBox
        Me.txtGST = New System.Windows.Forms.TextBox
        Me.txtPremiumAmount = New System.Windows.Forms.TextBox
        Me.lblPHNAME = New System.Windows.Forms.Label
        Me.lblPHIC = New System.Windows.Forms.Label
        Me.lblPID = New System.Windows.Forms.Label
        Me.lblPHID = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotalPremium1 = New System.Windows.Forms.Label
        Me.lblTotalPremium = New System.Windows.Forms.Label
        Me.lblGST1 = New System.Windows.Forms.Label
        Me.lblGST = New System.Windows.Forms.Label
        Me.lblPremiumAmount1 = New System.Windows.Forms.Label
        Me.lblPremiumAmount = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvClientRequest = New System.Windows.Forms.DataGridView
        Me.lblRTYPE = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.gbClientRequest.SuspendLayout()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvClientRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearchBy, Me.tscbSearchBy, Me.tstxtSearchBy, Me.ToolStripSeparator1, Me.tsbtnGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(868, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tslblSearchBy
        '
        Me.tslblSearchBy.Name = "tslblSearchBy"
        Me.tslblSearchBy.Size = New System.Drawing.Size(64, 22)
        Me.tslblSearchBy.Text = "Search By :"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"IC ", "FULL NAME"})
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(121, 25)
        '
        'tstxtSearchBy
        '
        Me.tstxtSearchBy.Name = "tstxtSearchBy"
        Me.tstxtSearchBy.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(32, 22)
        Me.tsbtnGo.Text = "Go.."
        '
        'gbClientRequest
        '
        Me.gbClientRequest.Controls.Add(Me.txtOSPGST)
        Me.gbClientRequest.Controls.Add(Me.lblOSPGST1)
        Me.gbClientRequest.Controls.Add(Me.lblOSPGST)
        Me.gbClientRequest.Controls.Add(Me.txtOSP)
        Me.gbClientRequest.Controls.Add(Me.lblOSP1)
        Me.gbClientRequest.Controls.Add(Me.lblOSP)
        Me.gbClientRequest.Controls.Add(Me.txtTotalPremium)
        Me.gbClientRequest.Controls.Add(Me.txtGST)
        Me.gbClientRequest.Controls.Add(Me.txtPremiumAmount)
        Me.gbClientRequest.Controls.Add(Me.lblPHNAME)
        Me.gbClientRequest.Controls.Add(Me.lblPHIC)
        Me.gbClientRequest.Controls.Add(Me.lblPID)
        Me.gbClientRequest.Controls.Add(Me.lblPHID)
        Me.gbClientRequest.Controls.Add(Me.txtRemarks)
        Me.gbClientRequest.Controls.Add(Me.Label3)
        Me.gbClientRequest.Controls.Add(Me.Label4)
        Me.gbClientRequest.Controls.Add(Me.lblTotalPremium1)
        Me.gbClientRequest.Controls.Add(Me.lblTotalPremium)
        Me.gbClientRequest.Controls.Add(Me.lblGST1)
        Me.gbClientRequest.Controls.Add(Me.lblGST)
        Me.gbClientRequest.Controls.Add(Me.lblPremiumAmount1)
        Me.gbClientRequest.Controls.Add(Me.lblPremiumAmount)
        Me.gbClientRequest.Controls.Add(Me.btnCancel)
        Me.gbClientRequest.Controls.Add(Me.btnPrint)
        Me.gbClientRequest.Location = New System.Drawing.Point(142, 227)
        Me.gbClientRequest.Name = "gbClientRequest"
        Me.gbClientRequest.Size = New System.Drawing.Size(560, 319)
        Me.gbClientRequest.TabIndex = 5
        Me.gbClientRequest.TabStop = False
        Me.gbClientRequest.Text = "Retirement Process"
        '
        'txtOSPGST
        '
        Me.txtOSPGST.Location = New System.Drawing.Point(219, 59)
        Me.txtOSPGST.Name = "txtOSPGST"
        Me.txtOSPGST.ReadOnly = True
        Me.txtOSPGST.Size = New System.Drawing.Size(100, 20)
        Me.txtOSPGST.TabIndex = 58
        Me.txtOSPGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOSPGST1
        '
        Me.lblOSPGST1.AutoSize = True
        Me.lblOSPGST1.Location = New System.Drawing.Point(190, 62)
        Me.lblOSPGST1.Name = "lblOSPGST1"
        Me.lblOSPGST1.Size = New System.Drawing.Size(10, 13)
        Me.lblOSPGST1.TabIndex = 57
        Me.lblOSPGST1.Text = ":"
        '
        'lblOSPGST
        '
        Me.lblOSPGST.AutoSize = True
        Me.lblOSPGST.Location = New System.Drawing.Point(46, 62)
        Me.lblOSPGST.Name = "lblOSPGST"
        Me.lblOSPGST.Size = New System.Drawing.Size(135, 13)
        Me.lblOSPGST.TabIndex = 56
        Me.lblOSPGST.Text = "GST 6% (For Out Standing)"
        '
        'txtOSP
        '
        Me.txtOSP.Location = New System.Drawing.Point(219, 31)
        Me.txtOSP.Name = "txtOSP"
        Me.txtOSP.Size = New System.Drawing.Size(100, 20)
        Me.txtOSP.TabIndex = 55
        Me.txtOSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOSP1
        '
        Me.lblOSP1.AutoSize = True
        Me.lblOSP1.Location = New System.Drawing.Point(190, 34)
        Me.lblOSP1.Name = "lblOSP1"
        Me.lblOSP1.Size = New System.Drawing.Size(10, 13)
        Me.lblOSP1.TabIndex = 54
        Me.lblOSP1.Text = ":"
        '
        'lblOSP
        '
        Me.lblOSP.AutoSize = True
        Me.lblOSP.Location = New System.Drawing.Point(46, 34)
        Me.lblOSP.Name = "lblOSP"
        Me.lblOSP.Size = New System.Drawing.Size(112, 13)
        Me.lblOSP.TabIndex = 53
        Me.lblOSP.Text = "Out Standing Premium"
        '
        'txtTotalPremium
        '
        Me.txtTotalPremium.Location = New System.Drawing.Point(219, 154)
        Me.txtTotalPremium.Name = "txtTotalPremium"
        Me.txtTotalPremium.ReadOnly = True
        Me.txtTotalPremium.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPremium.TabIndex = 52
        Me.txtTotalPremium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGST
        '
        Me.txtGST.Location = New System.Drawing.Point(219, 119)
        Me.txtGST.Name = "txtGST"
        Me.txtGST.ReadOnly = True
        Me.txtGST.Size = New System.Drawing.Size(100, 20)
        Me.txtGST.TabIndex = 51
        Me.txtGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPremiumAmount
        '
        Me.txtPremiumAmount.Location = New System.Drawing.Point(219, 85)
        Me.txtPremiumAmount.Name = "txtPremiumAmount"
        Me.txtPremiumAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtPremiumAmount.TabIndex = 50
        Me.txtPremiumAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPHNAME
        '
        Me.lblPHNAME.AutoSize = True
        Me.lblPHNAME.Location = New System.Drawing.Point(468, 92)
        Me.lblPHNAME.Name = "lblPHNAME"
        Me.lblPHNAME.Size = New System.Drawing.Size(53, 13)
        Me.lblPHNAME.TabIndex = 49
        Me.lblPHNAME.Text = "PHNAME"
        Me.lblPHNAME.Visible = False
        '
        'lblPHIC
        '
        Me.lblPHIC.AutoSize = True
        Me.lblPHIC.Location = New System.Drawing.Point(430, 92)
        Me.lblPHIC.Name = "lblPHIC"
        Me.lblPHIC.Size = New System.Drawing.Size(32, 13)
        Me.lblPHIC.TabIndex = 48
        Me.lblPHIC.Text = "PHIC"
        Me.lblPHIC.Visible = False
        '
        'lblPID
        '
        Me.lblPID.AutoSize = True
        Me.lblPID.Location = New System.Drawing.Point(390, 93)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(25, 13)
        Me.lblPID.TabIndex = 46
        Me.lblPID.Text = "PID"
        Me.lblPID.Visible = False
        '
        'lblPHID
        '
        Me.lblPHID.AutoSize = True
        Me.lblPHID.Location = New System.Drawing.Point(335, 93)
        Me.lblPHID.Name = "lblPHID"
        Me.lblPHID.Size = New System.Drawing.Size(33, 13)
        Me.lblPHID.TabIndex = 45
        Me.lblPHID.Text = "PHID"
        Me.lblPHID.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(219, 183)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(328, 73)
        Me.txtRemarks.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Remarks"
        '
        'lblTotalPremium1
        '
        Me.lblTotalPremium1.AutoSize = True
        Me.lblTotalPremium1.Location = New System.Drawing.Point(190, 157)
        Me.lblTotalPremium1.Name = "lblTotalPremium1"
        Me.lblTotalPremium1.Size = New System.Drawing.Size(10, 13)
        Me.lblTotalPremium1.TabIndex = 31
        Me.lblTotalPremium1.Text = ":"
        '
        'lblTotalPremium
        '
        Me.lblTotalPremium.AutoSize = True
        Me.lblTotalPremium.Location = New System.Drawing.Point(46, 157)
        Me.lblTotalPremium.Name = "lblTotalPremium"
        Me.lblTotalPremium.Size = New System.Drawing.Size(83, 13)
        Me.lblTotalPremium.TabIndex = 30
        Me.lblTotalPremium.Text = "Total Premium : "
        '
        'lblGST1
        '
        Me.lblGST1.AutoSize = True
        Me.lblGST1.Location = New System.Drawing.Point(190, 122)
        Me.lblGST1.Name = "lblGST1"
        Me.lblGST1.Size = New System.Drawing.Size(10, 13)
        Me.lblGST1.TabIndex = 27
        Me.lblGST1.Text = ":"
        '
        'lblGST
        '
        Me.lblGST.AutoSize = True
        Me.lblGST.Location = New System.Drawing.Point(46, 122)
        Me.lblGST.Name = "lblGST"
        Me.lblGST.Size = New System.Drawing.Size(46, 13)
        Me.lblGST.TabIndex = 26
        Me.lblGST.Text = "GST 6%"
        '
        'lblPremiumAmount1
        '
        Me.lblPremiumAmount1.AutoSize = True
        Me.lblPremiumAmount1.Location = New System.Drawing.Point(190, 88)
        Me.lblPremiumAmount1.Name = "lblPremiumAmount1"
        Me.lblPremiumAmount1.Size = New System.Drawing.Size(10, 13)
        Me.lblPremiumAmount1.TabIndex = 25
        Me.lblPremiumAmount1.Text = ":"
        '
        'lblPremiumAmount
        '
        Me.lblPremiumAmount.AutoSize = True
        Me.lblPremiumAmount.Location = New System.Drawing.Point(46, 88)
        Me.lblPremiumAmount.Name = "lblPremiumAmount"
        Me.lblPremiumAmount.Size = New System.Drawing.Size(86, 13)
        Me.lblPremiumAmount.TabIndex = 2
        Me.lblPremiumAmount.Text = "Premium Amount"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(295, 281)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(205, 281)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvClientRequest)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(6, 28)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(847, 196)
        Me.gbPolicyDetails.TabIndex = 4
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Holder Policy Details"
        '
        'dgvClientRequest
        '
        Me.dgvClientRequest.AllowUserToAddRows = False
        Me.dgvClientRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClientRequest.Location = New System.Drawing.Point(3, 16)
        Me.dgvClientRequest.Name = "dgvClientRequest"
        Me.dgvClientRequest.Size = New System.Drawing.Size(841, 177)
        Me.dgvClientRequest.TabIndex = 2
        '
        'lblRTYPE
        '
        Me.lblRTYPE.AutoSize = True
        Me.lblRTYPE.Location = New System.Drawing.Point(749, 292)
        Me.lblRTYPE.Name = "lblRTYPE"
        Me.lblRTYPE.Size = New System.Drawing.Size(43, 13)
        Me.lblRTYPE.TabIndex = 6
        Me.lblRTYPE.Text = "RTYPE"
        Me.lblRTYPE.Visible = False
        '
        'fRetirees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 558)
        Me.Controls.Add(Me.lblRTYPE)
        Me.Controls.Add(Me.gbClientRequest)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fRetirees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retirement Process"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbClientRequest.ResumeLayout(False)
        Me.gbClientRequest.PerformLayout()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvClientRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtSearchBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbClientRequest As System.Windows.Forms.GroupBox
    Friend WithEvents lblPHNAME As System.Windows.Forms.Label
    Friend WithEvents lblPHIC As System.Windows.Forms.Label
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents lblPHID As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPremium1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPremium As System.Windows.Forms.Label
    Friend WithEvents lblGST1 As System.Windows.Forms.Label
    Friend WithEvents lblGST As System.Windows.Forms.Label
    Friend WithEvents lblPremiumAmount1 As System.Windows.Forms.Label
    Friend WithEvents lblPremiumAmount As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClientRequest As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalPremium As System.Windows.Forms.TextBox
    Friend WithEvents txtGST As System.Windows.Forms.TextBox
    Friend WithEvents txtPremiumAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtOSPGST As System.Windows.Forms.TextBox
    Friend WithEvents lblOSPGST1 As System.Windows.Forms.Label
    Friend WithEvents lblOSPGST As System.Windows.Forms.Label
    Friend WithEvents txtOSP As System.Windows.Forms.TextBox
    Friend WithEvents lblOSP1 As System.Windows.Forms.Label
    Friend WithEvents lblOSP As System.Windows.Forms.Label
    Friend WithEvents lblRTYPE As System.Windows.Forms.Label
End Class
