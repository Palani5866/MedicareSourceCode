<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClientRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fClientRequest))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tslblSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtSearchBy = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvClientRequest = New System.Windows.Forms.DataGridView
        Me.gbClientRequest = New System.Windows.Forms.GroupBox
        Me.dgvDependents = New System.Windows.Forms.DataGridView
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.lblPID = New System.Windows.Forms.Label
        Me.lblPHID = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbPolicyHolder = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRequestFor = New System.Windows.Forms.Label
        Me.cbPolicy = New System.Windows.Forms.CheckBox
        Me.cbCard = New System.Windows.Forms.CheckBox
        Me.lblRequestType1 = New System.Windows.Forms.Label
        Me.lblRequestType = New System.Windows.Forms.Label
        Me.lblRequestDate1 = New System.Windows.Forms.Label
        Me.dtpRequestDate = New System.Windows.Forms.DateTimePicker
        Me.lblRequestDate = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblPHIC = New System.Windows.Forms.Label
        Me.lblPHNAME = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvClientRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClientRequest.SuspendLayout()
        CType(Me.dgvDependents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearchBy, Me.tscbSearchBy, Me.tstxtSearchBy, Me.ToolStripSeparator1, Me.tsbtnGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(876, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvClientRequest)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(12, 28)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(847, 196)
        Me.gbPolicyDetails.TabIndex = 2
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
        'gbClientRequest
        '
        Me.gbClientRequest.Controls.Add(Me.lblPHNAME)
        Me.gbClientRequest.Controls.Add(Me.lblPHIC)
        Me.gbClientRequest.Controls.Add(Me.dgvDependents)
        Me.gbClientRequest.Controls.Add(Me.lblPID)
        Me.gbClientRequest.Controls.Add(Me.lblPHID)
        Me.gbClientRequest.Controls.Add(Me.txtRemarks)
        Me.gbClientRequest.Controls.Add(Me.Label3)
        Me.gbClientRequest.Controls.Add(Me.Label4)
        Me.gbClientRequest.Controls.Add(Me.Label2)
        Me.gbClientRequest.Controls.Add(Me.cbPolicyHolder)
        Me.gbClientRequest.Controls.Add(Me.Label1)
        Me.gbClientRequest.Controls.Add(Me.lblRequestFor)
        Me.gbClientRequest.Controls.Add(Me.cbPolicy)
        Me.gbClientRequest.Controls.Add(Me.cbCard)
        Me.gbClientRequest.Controls.Add(Me.lblRequestType1)
        Me.gbClientRequest.Controls.Add(Me.lblRequestType)
        Me.gbClientRequest.Controls.Add(Me.lblRequestDate1)
        Me.gbClientRequest.Controls.Add(Me.dtpRequestDate)
        Me.gbClientRequest.Controls.Add(Me.lblRequestDate)
        Me.gbClientRequest.Controls.Add(Me.btnCancel)
        Me.gbClientRequest.Controls.Add(Me.btnSubmit)
        Me.gbClientRequest.Location = New System.Drawing.Point(12, 230)
        Me.gbClientRequest.Name = "gbClientRequest"
        Me.gbClientRequest.Size = New System.Drawing.Size(847, 382)
        Me.gbClientRequest.TabIndex = 3
        Me.gbClientRequest.TabStop = False
        Me.gbClientRequest.Text = "Client Request Form"
        '
        'dgvDependents
        '
        Me.dgvDependents.AllowUserToAddRows = False
        Me.dgvDependents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDependents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check})
        Me.dgvDependents.Location = New System.Drawing.Point(224, 167)
        Me.dgvDependents.Name = "dgvDependents"
        Me.dgvDependents.Size = New System.Drawing.Size(617, 73)
        Me.dgvDependents.TabIndex = 47
        '
        'Check
        '
        Me.Check.HeaderText = "Tick"
        Me.Check.Name = "Check"
        '
        'lblPID
        '
        Me.lblPID.AutoSize = True
        Me.lblPID.Location = New System.Drawing.Point(583, 39)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(25, 13)
        Me.lblPID.TabIndex = 46
        Me.lblPID.Text = "PID"
        Me.lblPID.Visible = False
        '
        'lblPHID
        '
        Me.lblPHID.AutoSize = True
        Me.lblPHID.Location = New System.Drawing.Point(528, 39)
        Me.lblPHID.Name = "lblPHID"
        Me.lblPHID.Size = New System.Drawing.Size(33, 13)
        Me.lblPHID.TabIndex = 45
        Me.lblPHID.Text = "PHID"
        Me.lblPHID.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(215, 246)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(626, 73)
        Me.txtRemarks.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(157, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Remarks"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Dependents :"
        '
        'cbPolicyHolder
        '
        Me.cbPolicyHolder.AutoSize = True
        Me.cbPolicyHolder.Location = New System.Drawing.Point(215, 120)
        Me.cbPolicyHolder.Name = "cbPolicyHolder"
        Me.cbPolicyHolder.Size = New System.Drawing.Size(88, 17)
        Me.cbPolicyHolder.TabIndex = 32
        Me.cbPolicyHolder.Text = "Policy Holder"
        Me.cbPolicyHolder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(157, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = ":"
        '
        'lblRequestFor
        '
        Me.lblRequestFor.AutoSize = True
        Me.lblRequestFor.Location = New System.Drawing.Point(65, 121)
        Me.lblRequestFor.Name = "lblRequestFor"
        Me.lblRequestFor.Size = New System.Drawing.Size(65, 13)
        Me.lblRequestFor.TabIndex = 30
        Me.lblRequestFor.Text = "Request For"
        '
        'cbPolicy
        '
        Me.cbPolicy.AutoSize = True
        Me.cbPolicy.Location = New System.Drawing.Point(278, 85)
        Me.cbPolicy.Name = "cbPolicy"
        Me.cbPolicy.Size = New System.Drawing.Size(54, 17)
        Me.cbPolicy.TabIndex = 29
        Me.cbPolicy.Text = "Policy"
        Me.cbPolicy.UseVisualStyleBackColor = True
        '
        'cbCard
        '
        Me.cbCard.AutoSize = True
        Me.cbCard.Location = New System.Drawing.Point(215, 85)
        Me.cbCard.Name = "cbCard"
        Me.cbCard.Size = New System.Drawing.Size(48, 17)
        Me.cbCard.TabIndex = 28
        Me.cbCard.Text = "Card"
        Me.cbCard.UseVisualStyleBackColor = True
        '
        'lblRequestType1
        '
        Me.lblRequestType1.AutoSize = True
        Me.lblRequestType1.Location = New System.Drawing.Point(157, 86)
        Me.lblRequestType1.Name = "lblRequestType1"
        Me.lblRequestType1.Size = New System.Drawing.Size(10, 13)
        Me.lblRequestType1.TabIndex = 27
        Me.lblRequestType1.Text = ":"
        '
        'lblRequestType
        '
        Me.lblRequestType.AutoSize = True
        Me.lblRequestType.Location = New System.Drawing.Point(65, 86)
        Me.lblRequestType.Name = "lblRequestType"
        Me.lblRequestType.Size = New System.Drawing.Size(74, 13)
        Me.lblRequestType.TabIndex = 26
        Me.lblRequestType.Text = "Request Type"
        '
        'lblRequestDate1
        '
        Me.lblRequestDate1.AutoSize = True
        Me.lblRequestDate1.Location = New System.Drawing.Point(157, 52)
        Me.lblRequestDate1.Name = "lblRequestDate1"
        Me.lblRequestDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblRequestDate1.TabIndex = 25
        Me.lblRequestDate1.Text = ":"
        '
        'dtpRequestDate
        '
        Me.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRequestDate.Location = New System.Drawing.Point(215, 52)
        Me.dtpRequestDate.Name = "dtpRequestDate"
        Me.dtpRequestDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpRequestDate.TabIndex = 24
        '
        'lblRequestDate
        '
        Me.lblRequestDate.AutoSize = True
        Me.lblRequestDate.Location = New System.Drawing.Point(65, 52)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(73, 13)
        Me.lblRequestDate.TabIndex = 2
        Me.lblRequestDate.Text = "Request Date"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(439, 340)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(349, 340)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblPHIC
        '
        Me.lblPHIC.AutoSize = True
        Me.lblPHIC.Location = New System.Drawing.Point(651, 52)
        Me.lblPHIC.Name = "lblPHIC"
        Me.lblPHIC.Size = New System.Drawing.Size(32, 13)
        Me.lblPHIC.TabIndex = 48
        Me.lblPHIC.Text = "PHIC"
        Me.lblPHIC.Visible = False
        '
        'lblPHNAME
        '
        Me.lblPHNAME.AutoSize = True
        Me.lblPHNAME.Location = New System.Drawing.Point(697, 52)
        Me.lblPHNAME.Name = "lblPHNAME"
        Me.lblPHNAME.Size = New System.Drawing.Size(53, 13)
        Me.lblPHNAME.TabIndex = 49
        Me.lblPHNAME.Text = "PHNAME"
        Me.lblPHNAME.Visible = False
        '
        'fClientRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 624)
        Me.Controls.Add(Me.gbClientRequest)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fClientRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Request "
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvClientRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClientRequest.ResumeLayout(False)
        Me.gbClientRequest.PerformLayout()
        CType(Me.dgvDependents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtSearchBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClientRequest As System.Windows.Forms.DataGridView
    Friend WithEvents gbClientRequest As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblRequestDate As System.Windows.Forms.Label
    Friend WithEvents lblRequestDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpRequestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbCard As System.Windows.Forms.CheckBox
    Friend WithEvents lblRequestType1 As System.Windows.Forms.Label
    Friend WithEvents lblRequestType As System.Windows.Forms.Label
    Friend WithEvents cbPolicy As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRequestFor As System.Windows.Forms.Label
    Friend WithEvents cbPolicyHolder As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblPHID As System.Windows.Forms.Label
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents dgvDependents As System.Windows.Forms.DataGridView
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblPHNAME As System.Windows.Forms.Label
    Friend WithEvents lblPHIC As System.Windows.Forms.Label
End Class
