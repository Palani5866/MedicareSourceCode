<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingPremiumTM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingPremiumTM))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslbldtFrom = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslbldtTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.gbNonPaymentDetails = New System.Windows.Forms.GroupBox
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.dgvPNONPayment = New System.Windows.Forms.DataGridView
        Me.FRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReminderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewHistory = New System.Windows.Forms.DataGridViewLinkColumn
        Me.FAction = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPaymentDetails = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.gbNonPaymentDetails.SuspendLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbldtFrom, Me.tstxtDateFrom, Me.tslbldtTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExporttoExcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1098, 25)
        Me.tsReport.TabIndex = 8
        Me.tsReport.Text = "ToolStrip"
        '
        'tslbldtFrom
        '
        Me.tslbldtFrom.Name = "tslbldtFrom"
        Me.tslbldtFrom.Size = New System.Drawing.Size(146, 22)
        Me.tslbldtFrom.Text = "Date From (dd/mm/yyyy):"
        Me.tslbldtFrom.Visible = False
        '
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.MaxLength = 10
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        Me.tstxtDateFrom.Visible = False
        '
        'tslbldtTo
        '
        Me.tslbldtTo.Name = "tslbldtTo"
        Me.tslbldtTo.Size = New System.Drawing.Size(132, 22)
        Me.tslbldtTo.Text = "Date To (dd/mm/yyyy):"
        Me.tslbldtTo.Visible = False
        '
        'tstxtDateTo
        '
        Me.tstxtDateTo.MaxLength = 10
        Me.tstxtDateTo.Name = "tstxtDateTo"
        Me.tstxtDateTo.ReadOnly = True
        Me.tstxtDateTo.Size = New System.Drawing.Size(100, 25)
        Me.tstxtDateTo.Visible = False
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(26, 22)
        Me.tsbtnGo.Text = "Go"
        Me.tsbtnGo.Visible = False
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExporttoExcel
        '
        Me.tsbtnExporttoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnExporttoExcel.Image = CType(resources.GetObject("tsbtnExporttoExcel.Image"), System.Drawing.Image)
        Me.tsbtnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExporttoExcel.Name = "tsbtnExporttoExcel"
        Me.tsbtnExporttoExcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbtnExporttoExcel.Text = "Export to Excel"
        '
        'gbNonPaymentDetails
        '
        Me.gbNonPaymentDetails.Controls.Add(Me.lblREFTYPE)
        Me.gbNonPaymentDetails.Controls.Add(Me.dgvPNONPayment)
        Me.gbNonPaymentDetails.Location = New System.Drawing.Point(0, 28)
        Me.gbNonPaymentDetails.Name = "gbNonPaymentDetails"
        Me.gbNonPaymentDetails.Size = New System.Drawing.Size(1092, 207)
        Me.gbNonPaymentDetails.TabIndex = 9
        Me.gbNonPaymentDetails.TabStop = False
        Me.gbNonPaymentDetails.Text = "Non Payment Details"
        '
        'lblREFTYPE
        '
        Me.lblREFTYPE.AutoSize = True
        Me.lblREFTYPE.Location = New System.Drawing.Point(364, 104)
        Me.lblREFTYPE.Name = "lblREFTYPE"
        Me.lblREFTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblREFTYPE.TabIndex = 1
        Me.lblREFTYPE.Text = "REFTYPE"
        Me.lblREFTYPE.Visible = False
        '
        'dgvPNONPayment
        '
        Me.dgvPNONPayment.AllowUserToAddRows = False
        Me.dgvPNONPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPNONPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FRemarks, Me.ReminderDate, Me.ViewHistory, Me.FAction, Me.Reason, Me.AssignTo, Me.Remarks, Me.Submit})
        Me.dgvPNONPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPNONPayment.Location = New System.Drawing.Point(3, 16)
        Me.dgvPNONPayment.Name = "dgvPNONPayment"
        Me.dgvPNONPayment.Size = New System.Drawing.Size(1086, 188)
        Me.dgvPNONPayment.TabIndex = 0
        '
        'FRemarks
        '
        Me.FRemarks.HeaderText = "Follow up Remarks"
        Me.FRemarks.Name = "FRemarks"
        '
        'ReminderDate
        '
        Me.ReminderDate.HeaderText = "Reminder Date"
        Me.ReminderDate.Name = "ReminderDate"
        '
        'ViewHistory
        '
        Me.ViewHistory.HeaderText = "View History"
        Me.ViewHistory.Name = "ViewHistory"
        Me.ViewHistory.Text = "View History"
        Me.ViewHistory.ToolTipText = "View History"
        Me.ViewHistory.UseColumnTextForLinkValue = True
        '
        'FAction
        '
        Me.FAction.HeaderText = "Followup Action"
        Me.FAction.Name = "FAction"
        Me.FAction.Text = "Followup Submit"
        Me.FAction.ToolTipText = "Followup Submit"
        Me.FAction.UseColumnTextForLinkValue = True
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Items.AddRange(New Object() {"Bankrupt", "Change Dept", "Deceased", "Insufficient Salary", "No Payment Without Reason", "Paid Direct To Union/Self", "Resign", "Retired", "Unpaid Leave"})
        Me.Reason.Name = "Reason"
        '
        'AssignTo
        '
        Me.AssignTo.HeaderText = "Action"
        Me.AssignTo.Items.AddRange(New Object() {"Finance", "Premium"})
        Me.AssignTo.Name = "AssignTo"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'gbPa
        '
        Me.gbPa.Controls.Add(Me.dgvPaymentDetails)
        Me.gbPa.Location = New System.Drawing.Point(3, 241)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1092, 288)
        Me.gbPa.TabIndex = 11
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Non Payment Details"
        '
        'dgvPaymentDetails
        '
        Me.dgvPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPaymentDetails.Name = "dgvPaymentDetails"
        Me.dgvPaymentDetails.Size = New System.Drawing.Size(1086, 269)
        Me.dgvPaymentDetails.TabIndex = 0
        '
        'frmPendingPremiumTM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 546)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.gbNonPaymentDetails)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "frmPendingPremiumTM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Premium (Non Payment)"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbNonPaymentDetails.ResumeLayout(False)
        Me.gbNonPaymentDetails.PerformLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslbldtFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslbldtTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbNonPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents dgvPNONPayment As System.Windows.Forms.DataGridView
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents FRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReminderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewHistory As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents FAction As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
End Class
