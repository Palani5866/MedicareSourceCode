<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNonPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNonPayment))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslbldtFrom = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslbldtTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.tslblTOT = New System.Windows.Forms.ToolStripLabel
        Me.gbNonPaymentDetails = New System.Windows.Forms.GroupBox
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.dgvPNONPayment = New System.Windows.Forms.DataGridView
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPendingConfirmation = New System.Windows.Forms.DataGridView
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.dgvRNONPD = New System.Windows.Forms.DataGridView
        Me.gbPendingDecision = New System.Windows.Forms.GroupBox
        Me.dgvPendingDecision = New System.Windows.Forms.DataGridView
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Request = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pcView = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Confirm = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        Me.gbNonPaymentDetails.SuspendLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvRNONPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPendingDecision.SuspendLayout()
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbldtFrom, Me.tstxtDateFrom, Me.tslbldtTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExporttoExcel, Me.tslblTOT})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1096, 25)
        Me.tsReport.TabIndex = 6
        Me.tsReport.Text = "ToolStrip"
        '
        'tslbldtFrom
        '
        Me.tslbldtFrom.Name = "tslbldtFrom"
        Me.tslbldtFrom.Size = New System.Drawing.Size(146, 22)
        Me.tslbldtFrom.Text = "Date From (dd/mm/yyyy):"
        '
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.MaxLength = 10
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'tslbldtTo
        '
        Me.tslbldtTo.Name = "tslbldtTo"
        Me.tslbldtTo.Size = New System.Drawing.Size(132, 22)
        Me.tslbldtTo.Text = "Date To (dd/mm/yyyy):"
        '
        'tstxtDateTo
        '
        Me.tstxtDateTo.MaxLength = 10
        Me.tstxtDateTo.Name = "tstxtDateTo"
        Me.tstxtDateTo.ReadOnly = True
        Me.tstxtDateTo.Size = New System.Drawing.Size(100, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(26, 22)
        Me.tsbtnGo.Text = "Go"
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
        'tslblTOT
        '
        Me.tslblTOT.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTOT.ForeColor = System.Drawing.Color.Blue
        Me.tslblTOT.Name = "tslblTOT"
        Me.tslblTOT.Size = New System.Drawing.Size(90, 22)
        Me.tslblTOT.Text = "Total Records :"
        '
        'gbNonPaymentDetails
        '
        Me.gbNonPaymentDetails.Controls.Add(Me.lblREFTYPE)
        Me.gbNonPaymentDetails.Controls.Add(Me.dgvPNONPayment)
        Me.gbNonPaymentDetails.Location = New System.Drawing.Point(0, 29)
        Me.gbNonPaymentDetails.Name = "gbNonPaymentDetails"
        Me.gbNonPaymentDetails.Size = New System.Drawing.Size(1092, 186)
        Me.gbNonPaymentDetails.TabIndex = 7
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
        Me.dgvPNONPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reason, Me.AssignTo, Me.Remarks, Me.Submit})
        Me.dgvPNONPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPNONPayment.Location = New System.Drawing.Point(3, 16)
        Me.dgvPNONPayment.Name = "dgvPNONPayment"
        Me.dgvPNONPayment.Size = New System.Drawing.Size(1086, 167)
        Me.dgvPNONPayment.TabIndex = 0
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
        Me.AssignTo.Items.AddRange(New Object() {"Tele Marketing", "Finance", "Ignore"})
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
        Me.gbPa.Controls.Add(Me.dgvPendingConfirmation)
        Me.gbPa.Location = New System.Drawing.Point(7, 393)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1086, 177)
        Me.gbPa.TabIndex = 8
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Premium Non Payment Pending Confirmation"
        '
        'dgvPendingConfirmation
        '
        Me.dgvPendingConfirmation.AllowUserToAddRows = False
        Me.dgvPendingConfirmation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingConfirmation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcView, Me.Confirm})
        Me.dgvPendingConfirmation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingConfirmation.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingConfirmation.Name = "dgvPendingConfirmation"
        Me.dgvPendingConfirmation.Size = New System.Drawing.Size(1080, 158)
        Me.dgvPendingConfirmation.TabIndex = 0
        '
        'gbRe_Assign
        '
        Me.gbRe_Assign.Controls.Add(Me.dgvRNONPD)
        Me.gbRe_Assign.Location = New System.Drawing.Point(4, 221)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1092, 166)
        Me.gbRe_Assign.TabIndex = 9
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Premium Non Payment Details (Re-Assign/Request)"
        '
        'dgvRNONPD
        '
        Me.dgvRNONPD.AllowUserToAddRows = False
        Me.dgvRNONPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRNONPD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewLinkColumn1, Me.Upload, Me.View, Me.Request})
        Me.dgvRNONPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRNONPD.Location = New System.Drawing.Point(3, 16)
        Me.dgvRNONPD.Name = "dgvRNONPD"
        Me.dgvRNONPD.Size = New System.Drawing.Size(1086, 147)
        Me.dgvRNONPD.TabIndex = 0
        '
        'gbPendingDecision
        '
        Me.gbPendingDecision.Controls.Add(Me.dgvPendingDecision)
        Me.gbPendingDecision.Location = New System.Drawing.Point(7, 576)
        Me.gbPendingDecision.Name = "gbPendingDecision"
        Me.gbPendingDecision.Size = New System.Drawing.Size(1086, 149)
        Me.gbPendingDecision.TabIndex = 10
        Me.gbPendingDecision.TabStop = False
        Me.gbPendingDecision.Text = "Premium Non Paymnet Details (Confirmed / Pending Decision) "
        '
        'dgvPendingDecision
        '
        Me.dgvPendingDecision.AllowUserToAddRows = False
        Me.dgvPendingDecision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingDecision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingDecision.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingDecision.Name = "dgvPendingDecision"
        Me.dgvPendingDecision.Size = New System.Drawing.Size(1080, 130)
        Me.dgvPendingDecision.TabIndex = 0
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "Reason"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"Bankrupt", "Change Dept", "Deceased", "Insufficient Salary", "No Payment Without Reason", "Paid Direct To Union/Self", "Resign", "Retired", "Unpaid Leave"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"Tele Marketing", "Finance", "Ignore"})
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewLinkColumn1
        '
        Me.DataGridViewLinkColumn1.HeaderText = "Submit"
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLinkColumn1.Text = "Submit"
        Me.DataGridViewLinkColumn1.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn1.UseColumnTextForLinkValue = True
        '
        'Upload
        '
        Me.Upload.HeaderText = "Upload"
        Me.Upload.Name = "Upload"
        Me.Upload.Text = "Upload"
        Me.Upload.ToolTipText = "Upload"
        Me.Upload.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Request
        '
        Me.Request.HeaderText = "Request"
        Me.Request.Name = "Request"
        Me.Request.Text = "Request"
        Me.Request.ToolTipText = "Request"
        Me.Request.UseColumnTextForLinkValue = True
        '
        'pcView
        '
        Me.pcView.HeaderText = "View"
        Me.pcView.Name = "pcView"
        Me.pcView.Text = "View"
        Me.pcView.ToolTipText = "View"
        Me.pcView.UseColumnTextForLinkValue = True
        '
        'Confirm
        '
        Me.Confirm.HeaderText = "Confirm"
        Me.Confirm.Name = "Confirm"
        Me.Confirm.Text = "Confirm"
        Me.Confirm.ToolTipText = "Confirm"
        Me.Confirm.UseColumnTextForLinkValue = True
        '
        'frmNonPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 735)
        Me.Controls.Add(Me.gbPendingDecision)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.gbNonPaymentDetails)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "frmNonPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Payment"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbNonPaymentDetails.ResumeLayout(False)
        Me.gbNonPaymentDetails.PerformLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRe_Assign.ResumeLayout(False)
        CType(Me.dgvRNONPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPendingDecision.ResumeLayout(False)
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvPNONPayment As System.Windows.Forms.DataGridView
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingConfirmation As System.Windows.Forms.DataGridView
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRNONPD As System.Windows.Forms.DataGridView
    Friend WithEvents tslblTOT As System.Windows.Forms.ToolStripLabel
    Friend WithEvents gbPendingDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingDecision As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Request As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pcView As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Confirm As System.Windows.Forms.DataGridViewLinkColumn
End Class
