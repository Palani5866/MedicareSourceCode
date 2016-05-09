<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRCancel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRCancel))
        Me.dgvRDetails = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbDecision = New System.Windows.Forms.GroupBox
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblRemark = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.cmbCancellation_Reason = New System.Windows.Forms.ComboBox
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.lblCancellation_Reason = New System.Windows.Forms.Label
        Me.dtpPolicy_CancellationDate = New System.Windows.Forms.DateTimePicker
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
        Me.lblREFID = New System.Windows.Forms.Label
        Me.lblPREMIUM = New System.Windows.Forms.Label
        CType(Me.dgvRDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tolForm.SuspendLayout()
        Me.gbDecision.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRDetails
        '
        Me.dgvRDetails.AllowUserToAddRows = False
        Me.dgvRDetails.AllowUserToDeleteRows = False
        Me.dgvRDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View})
        Me.dgvRDetails.Location = New System.Drawing.Point(4, 33)
        Me.dgvRDetails.Name = "dgvRDetails"
        Me.dgvRDetails.Size = New System.Drawing.Size(1069, 150)
        Me.dgvRDetails.TabIndex = 0
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1085, 25)
        Me.tolForm.TabIndex = 14
        Me.tolForm.Text = "ToolStrip1"
        '
        'tslblTot
        '
        Me.tslblTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTot.ForeColor = System.Drawing.Color.Blue
        Me.tslblTot.Name = "tslblTot"
        Me.tslblTot.Size = New System.Drawing.Size(84, 22)
        Me.tslblTot.Text = "Total Records"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbDecision
        '
        Me.gbDecision.Controls.Add(Me.dtpEffective_Date)
        Me.gbDecision.Controls.Add(Me.Label1)
        Me.gbDecision.Controls.Add(Me.btnPrint)
        Me.gbDecision.Controls.Add(Me.btnCancel)
        Me.gbDecision.Controls.Add(Me.btnSubmit)
        Me.gbDecision.Controls.Add(Me.lblRemark)
        Me.gbDecision.Controls.Add(Me.txtRemark)
        Me.gbDecision.Controls.Add(Me.cmbCancellation_Reason)
        Me.gbDecision.Controls.Add(Me.lblRequestedDate)
        Me.gbDecision.Controls.Add(Me.lblCancellation_Reason)
        Me.gbDecision.Controls.Add(Me.dtpPolicy_CancellationDate)
        Me.gbDecision.Controls.Add(Me.dtpRequestedDate)
        Me.gbDecision.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.gbDecision.Location = New System.Drawing.Point(249, 198)
        Me.gbDecision.Name = "gbDecision"
        Me.gbDecision.Size = New System.Drawing.Size(593, 206)
        Me.gbDecision.TabIndex = 18
        Me.gbDecision.TabStop = False
        Me.gbDecision.Text = "Decisions"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(170, 142)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffective_Date.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Effective Date:"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(180, 177)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 18
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(342, 177)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(261, 177)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 16
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(25, 105)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 13)
        Me.lblRemark.TabIndex = 14
        Me.lblRemark.Text = "Remark:"
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(170, 101)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(393, 35)
        Me.txtRemark.TabIndex = 15
        '
        'cmbCancellation_Reason
        '
        Me.cmbCancellation_Reason.FormattingEnabled = True
        Me.cmbCancellation_Reason.Items.AddRange(New Object() {"User request to cancel", "Non-Payment", "Change to Yearly", "Angkasa Payment > 60%", "NO DEDUCTION FROM ANGKASA", "Non-Payment Cannot Contact", "Change to Angkasa / Others", "Incomplete Angkasa"})
        Me.cmbCancellation_Reason.Location = New System.Drawing.Point(170, 74)
        Me.cmbCancellation_Reason.Name = "cmbCancellation_Reason"
        Me.cmbCancellation_Reason.Size = New System.Drawing.Size(393, 21)
        Me.cmbCancellation_Reason.TabIndex = 13
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(25, 26)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(88, 13)
        Me.lblRequestedDate.TabIndex = 8
        Me.lblRequestedDate.Text = "Requested Date:"
        '
        'lblCancellation_Reason
        '
        Me.lblCancellation_Reason.AutoSize = True
        Me.lblCancellation_Reason.Location = New System.Drawing.Point(25, 78)
        Me.lblCancellation_Reason.Name = "lblCancellation_Reason"
        Me.lblCancellation_Reason.Size = New System.Drawing.Size(108, 13)
        Me.lblCancellation_Reason.TabIndex = 12
        Me.lblCancellation_Reason.Text = "Cancellation Reason:"
        '
        'dtpPolicy_CancellationDate
        '
        Me.dtpPolicy_CancellationDate.Location = New System.Drawing.Point(170, 48)
        Me.dtpPolicy_CancellationDate.Name = "dtpPolicy_CancellationDate"
        Me.dtpPolicy_CancellationDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpPolicy_CancellationDate.TabIndex = 11
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(170, 22)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 9
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(25, 52)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 10
        Me.lblPolicy_CancellationDate.Text = "Cancellation Date:"
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(523, 205)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 19
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'lblPREMIUM
        '
        Me.lblPREMIUM.AutoSize = True
        Me.lblPREMIUM.Location = New System.Drawing.Point(513, 205)
        Me.lblPREMIUM.Name = "lblPREMIUM"
        Me.lblPREMIUM.Size = New System.Drawing.Size(58, 13)
        Me.lblPREMIUM.TabIndex = 20
        Me.lblPREMIUM.Text = "PREMIUM"
        Me.lblPREMIUM.Visible = False
        '
        'frmRCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 422)
        Me.Controls.Add(Me.lblPREMIUM)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.gbDecision)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.dgvRDetails)
        Me.Name = "frmRCancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retiree Cancellation"
        CType(Me.dgvRDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbDecision.ResumeLayout(False)
        Me.gbDecision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents cmbCancellation_Reason As System.Windows.Forms.ComboBox
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents lblCancellation_Reason As System.Windows.Forms.Label
    Friend WithEvents dtpPolicy_CancellationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents lblPREMIUM As System.Windows.Forms.Label
End Class
