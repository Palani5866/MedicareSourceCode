<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConversion_Proposer_Status
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.grpCurrent_Proposer_Status = New System.Windows.Forms.GroupBox
        Me.rbUnderwritingPU = New System.Windows.Forms.RadioButton
        Me.rdiUnderwriting = New System.Windows.Forms.RadioButton
        Me.rdiReject = New System.Windows.Forms.RadioButton
        Me.rdiDeferment = New System.Windows.Forms.RadioButton
        Me.rdiAcknowledgement = New System.Windows.Forms.RadioButton
        Me.grpNew_Proposer_Status = New System.Windows.Forms.GroupBox
        Me.rbUnderwritingPU_New = New System.Windows.Forms.RadioButton
        Me.rdiUnderwriting_New = New System.Windows.Forms.RadioButton
        Me.rdiReject_New = New System.Windows.Forms.RadioButton
        Me.rdiDeferment_New = New System.Windows.Forms.RadioButton
        Me.rdiAcknowledgement_New = New System.Windows.Forms.RadioButton
        Me.lblFrom_To = New System.Windows.Forms.Label
        Me.lblConversion_Remark = New System.Windows.Forms.Label
        Me.lblProposer_ID = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpCurrent_Proposer_Status.SuspendLayout()
        Me.grpNew_Proposer_Status.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(283, 337)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'grpCurrent_Proposer_Status
        '
        Me.grpCurrent_Proposer_Status.Controls.Add(Me.rbUnderwritingPU)
        Me.grpCurrent_Proposer_Status.Controls.Add(Me.rdiUnderwriting)
        Me.grpCurrent_Proposer_Status.Controls.Add(Me.rdiReject)
        Me.grpCurrent_Proposer_Status.Controls.Add(Me.rdiDeferment)
        Me.grpCurrent_Proposer_Status.Controls.Add(Me.rdiAcknowledgement)
        Me.grpCurrent_Proposer_Status.Location = New System.Drawing.Point(12, 12)
        Me.grpCurrent_Proposer_Status.Name = "grpCurrent_Proposer_Status"
        Me.grpCurrent_Proposer_Status.Size = New System.Drawing.Size(180, 149)
        Me.grpCurrent_Proposer_Status.TabIndex = 0
        Me.grpCurrent_Proposer_Status.TabStop = False
        Me.grpCurrent_Proposer_Status.Text = "Current Status"
        '
        'rbUnderwritingPU
        '
        Me.rbUnderwritingPU.AutoCheck = False
        Me.rbUnderwritingPU.AutoSize = True
        Me.rbUnderwritingPU.Location = New System.Drawing.Point(24, 115)
        Me.rbUnderwritingPU.Name = "rbUnderwritingPU"
        Me.rbUnderwritingPU.Size = New System.Drawing.Size(108, 17)
        Me.rbUnderwritingPU.TabIndex = 4
        Me.rbUnderwritingPU.TabStop = True
        Me.rbUnderwritingPU.Text = "Underwriting (PU)"
        Me.rbUnderwritingPU.UseVisualStyleBackColor = True
        '
        'rdiUnderwriting
        '
        Me.rdiUnderwriting.AutoCheck = False
        Me.rdiUnderwriting.AutoSize = True
        Me.rdiUnderwriting.Location = New System.Drawing.Point(24, 92)
        Me.rdiUnderwriting.Name = "rdiUnderwriting"
        Me.rdiUnderwriting.Size = New System.Drawing.Size(84, 17)
        Me.rdiUnderwriting.TabIndex = 3
        Me.rdiUnderwriting.TabStop = True
        Me.rdiUnderwriting.Text = "Underwriting"
        Me.rdiUnderwriting.UseVisualStyleBackColor = True
        '
        'rdiReject
        '
        Me.rdiReject.AutoCheck = False
        Me.rdiReject.AutoSize = True
        Me.rdiReject.Location = New System.Drawing.Point(24, 68)
        Me.rdiReject.Name = "rdiReject"
        Me.rdiReject.Size = New System.Drawing.Size(56, 17)
        Me.rdiReject.TabIndex = 2
        Me.rdiReject.TabStop = True
        Me.rdiReject.Text = "Reject"
        Me.rdiReject.UseVisualStyleBackColor = True
        '
        'rdiDeferment
        '
        Me.rdiDeferment.AutoCheck = False
        Me.rdiDeferment.AutoSize = True
        Me.rdiDeferment.Location = New System.Drawing.Point(24, 44)
        Me.rdiDeferment.Name = "rdiDeferment"
        Me.rdiDeferment.Size = New System.Drawing.Size(74, 17)
        Me.rdiDeferment.TabIndex = 1
        Me.rdiDeferment.TabStop = True
        Me.rdiDeferment.Text = "Deferment"
        Me.rdiDeferment.UseVisualStyleBackColor = True
        '
        'rdiAcknowledgement
        '
        Me.rdiAcknowledgement.AutoCheck = False
        Me.rdiAcknowledgement.AutoSize = True
        Me.rdiAcknowledgement.Location = New System.Drawing.Point(24, 20)
        Me.rdiAcknowledgement.Name = "rdiAcknowledgement"
        Me.rdiAcknowledgement.Size = New System.Drawing.Size(83, 17)
        Me.rdiAcknowledgement.TabIndex = 0
        Me.rdiAcknowledgement.TabStop = True
        Me.rdiAcknowledgement.Text = "Acceptance"
        Me.rdiAcknowledgement.UseVisualStyleBackColor = True
        '
        'grpNew_Proposer_Status
        '
        Me.grpNew_Proposer_Status.Controls.Add(Me.rbUnderwritingPU_New)
        Me.grpNew_Proposer_Status.Controls.Add(Me.rdiUnderwriting_New)
        Me.grpNew_Proposer_Status.Controls.Add(Me.rdiReject_New)
        Me.grpNew_Proposer_Status.Controls.Add(Me.rdiDeferment_New)
        Me.grpNew_Proposer_Status.Controls.Add(Me.rdiAcknowledgement_New)
        Me.grpNew_Proposer_Status.Location = New System.Drawing.Point(243, 12)
        Me.grpNew_Proposer_Status.Name = "grpNew_Proposer_Status"
        Me.grpNew_Proposer_Status.Size = New System.Drawing.Size(180, 149)
        Me.grpNew_Proposer_Status.TabIndex = 1
        Me.grpNew_Proposer_Status.TabStop = False
        Me.grpNew_Proposer_Status.Text = "New Status"
        '
        'rbUnderwritingPU_New
        '
        Me.rbUnderwritingPU_New.AutoSize = True
        Me.rbUnderwritingPU_New.Location = New System.Drawing.Point(25, 115)
        Me.rbUnderwritingPU_New.Name = "rbUnderwritingPU_New"
        Me.rbUnderwritingPU_New.Size = New System.Drawing.Size(108, 17)
        Me.rbUnderwritingPU_New.TabIndex = 5
        Me.rbUnderwritingPU_New.TabStop = True
        Me.rbUnderwritingPU_New.Text = "Underwriting (PU)"
        Me.rbUnderwritingPU_New.UseVisualStyleBackColor = True
        '
        'rdiUnderwriting_New
        '
        Me.rdiUnderwriting_New.AutoSize = True
        Me.rdiUnderwriting_New.Location = New System.Drawing.Point(25, 92)
        Me.rdiUnderwriting_New.Name = "rdiUnderwriting_New"
        Me.rdiUnderwriting_New.Size = New System.Drawing.Size(84, 17)
        Me.rdiUnderwriting_New.TabIndex = 4
        Me.rdiUnderwriting_New.TabStop = True
        Me.rdiUnderwriting_New.Text = "Underwriting"
        Me.rdiUnderwriting_New.UseVisualStyleBackColor = True
        '
        'rdiReject_New
        '
        Me.rdiReject_New.AutoSize = True
        Me.rdiReject_New.Location = New System.Drawing.Point(25, 68)
        Me.rdiReject_New.Name = "rdiReject_New"
        Me.rdiReject_New.Size = New System.Drawing.Size(56, 17)
        Me.rdiReject_New.TabIndex = 3
        Me.rdiReject_New.TabStop = True
        Me.rdiReject_New.Text = "Reject"
        Me.rdiReject_New.UseVisualStyleBackColor = True
        '
        'rdiDeferment_New
        '
        Me.rdiDeferment_New.AutoSize = True
        Me.rdiDeferment_New.Location = New System.Drawing.Point(25, 44)
        Me.rdiDeferment_New.Name = "rdiDeferment_New"
        Me.rdiDeferment_New.Size = New System.Drawing.Size(74, 17)
        Me.rdiDeferment_New.TabIndex = 2
        Me.rdiDeferment_New.TabStop = True
        Me.rdiDeferment_New.Text = "Deferment"
        Me.rdiDeferment_New.UseVisualStyleBackColor = True
        '
        'rdiAcknowledgement_New
        '
        Me.rdiAcknowledgement_New.AutoSize = True
        Me.rdiAcknowledgement_New.Location = New System.Drawing.Point(25, 20)
        Me.rdiAcknowledgement_New.Name = "rdiAcknowledgement_New"
        Me.rdiAcknowledgement_New.Size = New System.Drawing.Size(83, 17)
        Me.rdiAcknowledgement_New.TabIndex = 1
        Me.rdiAcknowledgement_New.TabStop = True
        Me.rdiAcknowledgement_New.Text = "Acceptance"
        Me.rdiAcknowledgement_New.UseVisualStyleBackColor = True
        '
        'lblFrom_To
        '
        Me.lblFrom_To.AutoSize = True
        Me.lblFrom_To.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom_To.Location = New System.Drawing.Point(197, 65)
        Me.lblFrom_To.Name = "lblFrom_To"
        Me.lblFrom_To.Size = New System.Drawing.Size(43, 20)
        Me.lblFrom_To.TabIndex = 2
        Me.lblFrom_To.Text = "---->"
        '
        'lblConversion_Remark
        '
        Me.lblConversion_Remark.AutoSize = True
        Me.lblConversion_Remark.Location = New System.Drawing.Point(12, 178)
        Me.lblConversion_Remark.Name = "lblConversion_Remark"
        Me.lblConversion_Remark.Size = New System.Drawing.Size(103, 13)
        Me.lblConversion_Remark.TabIndex = 3
        Me.lblConversion_Remark.Text = "Conversion Reason:"
        '
        'lblProposer_ID
        '
        Me.lblProposer_ID.AutoSize = True
        Me.lblProposer_ID.Location = New System.Drawing.Point(12, 354)
        Me.lblProposer_ID.Name = "lblProposer_ID"
        Me.lblProposer_ID.Size = New System.Drawing.Size(66, 13)
        Me.lblProposer_ID.TabIndex = 6
        Me.lblProposer_ID.Text = "Proposer_ID"
        Me.lblProposer_ID.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(105, 355)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected, Me.Reason})
        Me.dgvForm.Location = New System.Drawing.Point(8, 194)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(415, 96)
        Me.dgvForm.TabIndex = 8
        '
        'colDeduction_BatchSelected
        '
        Me.colDeduction_BatchSelected.FalseValue = "F"
        Me.colDeduction_BatchSelected.HeaderText = "(Tick)"
        Me.colDeduction_BatchSelected.IndeterminateValue = ""
        Me.colDeduction_BatchSelected.Name = "colDeduction_BatchSelected"
        Me.colDeduction_BatchSelected.TrueValue = "T"
        Me.colDeduction_BatchSelected.Width = 50
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Name = "Reason"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(5, 299)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 9
        Me.lblRemarks.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(92, 296)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(331, 33)
        Me.txtRemarks.TabIndex = 10
        '
        'dlgConversion_Proposer_Status
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(441, 378)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblProposer_ID)
        Me.Controls.Add(Me.lblConversion_Remark)
        Me.Controls.Add(Me.lblFrom_To)
        Me.Controls.Add(Me.grpNew_Proposer_Status)
        Me.Controls.Add(Me.grpCurrent_Proposer_Status)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgConversion_Proposer_Status"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert Proposer's Status"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpCurrent_Proposer_Status.ResumeLayout(False)
        Me.grpCurrent_Proposer_Status.PerformLayout()
        Me.grpNew_Proposer_Status.ResumeLayout(False)
        Me.grpNew_Proposer_Status.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents grpCurrent_Proposer_Status As System.Windows.Forms.GroupBox
    Friend WithEvents rdiUnderwriting As System.Windows.Forms.RadioButton
    Friend WithEvents rdiReject As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDeferment As System.Windows.Forms.RadioButton
    Friend WithEvents rdiAcknowledgement As System.Windows.Forms.RadioButton
    Friend WithEvents grpNew_Proposer_Status As System.Windows.Forms.GroupBox
    Friend WithEvents rdiUnderwriting_New As System.Windows.Forms.RadioButton
    Friend WithEvents rdiReject_New As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDeferment_New As System.Windows.Forms.RadioButton
    Friend WithEvents rdiAcknowledgement_New As System.Windows.Forms.RadioButton
    Friend WithEvents lblFrom_To As System.Windows.Forms.Label
    Friend WithEvents lblConversion_Remark As System.Windows.Forms.Label
    Friend WithEvents lblProposer_ID As System.Windows.Forms.Label
    Friend WithEvents rbUnderwritingPU As System.Windows.Forms.RadioButton
    Friend WithEvents rbUnderwritingPU_New As System.Windows.Forms.RadioButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox

End Class
