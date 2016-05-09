<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fShortFall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fShortFall))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.dgvRNONPD = New System.Windows.Forms.DataGridView
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Request = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvShortfall = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHONEHSE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHONEMOBILE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHONEOFFICE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totshort = New System.Windows.Forms.DataGridViewLinkColumn
        Me.totrequested = New System.Windows.Forms.DataGridViewLinkColumn
        Me.totrecovered = New System.Windows.Forms.DataGridViewLinkColumn
        Me.totbal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.gbPendingDecision = New System.Windows.Forms.GroupBox
        Me.dgvPendingDecision = New System.Windows.Forms.DataGridView
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPendingConfirmation = New System.Windows.Forms.DataGridView
        Me.pcView = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Confirm = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvRNONPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPendingDecision.SuspendLayout()
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1090, 25)
        Me.tolForm.TabIndex = 11
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
        'gbRe_Assign
        '
        Me.gbRe_Assign.Controls.Add(Me.dgvRNONPD)
        Me.gbRe_Assign.Location = New System.Drawing.Point(0, 217)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1089, 186)
        Me.gbRe_Assign.TabIndex = 12
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Re - Assign Short Fall Details"
        '
        'dgvRNONPD
        '
        Me.dgvRNONPD.AllowUserToAddRows = False
        Me.dgvRNONPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRNONPD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewLinkColumn1, Me.Upload, Me.View, Me.Request})
        Me.dgvRNONPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRNONPD.Location = New System.Drawing.Point(3, 16)
        Me.dgvRNONPD.Name = "dgvRNONPD"
        Me.dgvRNONPD.Size = New System.Drawing.Size(1083, 167)
        Me.dgvRNONPD.TabIndex = 1
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
        'dgvShortfall
        '
        Me.dgvShortfall.AllowUserToAddRows = False
        Me.dgvShortfall.AllowUserToOrderColumns = True
        Me.dgvShortfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.ic, Me.fullname, Me.plan, Me.PHONEHSE, Me.PHONEMOBILE, Me.PHONEOFFICE, Me.EMAIL, Me.totshort, Me.totrequested, Me.totrecovered, Me.totbal, Me.Reason, Me.Action, Me.Remarks, Me.Submit})
        Me.dgvShortfall.Location = New System.Drawing.Point(2, 28)
        Me.dgvShortfall.Name = "dgvShortfall"
        Me.dgvShortfall.Size = New System.Drawing.Size(1087, 183)
        Me.dgvShortfall.TabIndex = 13
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'ic
        '
        Me.ic.DataPropertyName = "ic"
        Me.ic.HeaderText = "IC"
        Me.ic.Name = "ic"
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.HeaderText = "Full Name"
        Me.fullname.Name = "fullname"
        '
        'plan
        '
        Me.plan.DataPropertyName = "plan"
        Me.plan.HeaderText = "PLAN"
        Me.plan.Name = "plan"
        '
        'PHONEHSE
        '
        Me.PHONEHSE.DataPropertyName = "PHONE_HSE"
        Me.PHONEHSE.HeaderText = "PHONE HOUSE"
        Me.PHONEHSE.Name = "PHONEHSE"
        '
        'PHONEMOBILE
        '
        Me.PHONEMOBILE.DataPropertyName = "PHONE_MOBILE"
        Me.PHONEMOBILE.HeaderText = "PHONE MOBILE"
        Me.PHONEMOBILE.Name = "PHONEMOBILE"
        '
        'PHONEOFFICE
        '
        Me.PHONEOFFICE.DataPropertyName = "PHONE_OFF"
        Me.PHONEOFFICE.HeaderText = "PHONE OFFICE"
        Me.PHONEOFFICE.Name = "PHONEOFFICE"
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        '
        'totshort
        '
        Me.totshort.DataPropertyName = "totshort"
        Me.totshort.HeaderText = "Total Short"
        Me.totshort.Name = "totshort"
        Me.totshort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totshort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'totrequested
        '
        Me.totrequested.DataPropertyName = "totrequested"
        Me.totrequested.HeaderText = "Total Requested"
        Me.totrequested.Name = "totrequested"
        Me.totrequested.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totrequested.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'totrecovered
        '
        Me.totrecovered.DataPropertyName = "totrecovered"
        Me.totrecovered.HeaderText = "Total Recovered"
        Me.totrecovered.Name = "totrecovered"
        '
        'totbal
        '
        Me.totbal.DataPropertyName = "totbal"
        Me.totbal.HeaderText = "Total Balance"
        Me.totbal.Name = "totbal"
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Items.AddRange(New Object() {"Bankrupt", "Change Dept", "Deceased", "Insufficient Salary", "No Payment Without Reason", "Paid Direct To Union/Self", "Resign", "Retired", "Unpaid Leave"})
        Me.Reason.Name = "Reason"
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Items.AddRange(New Object() {"Tele Marketing", "Finance", "Ignore"})
        Me.Action.Name = "Action"
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
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'lblREFTYPE
        '
        Me.lblREFTYPE.AutoSize = True
        Me.lblREFTYPE.Location = New System.Drawing.Point(534, 143)
        Me.lblREFTYPE.Name = "lblREFTYPE"
        Me.lblREFTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblREFTYPE.TabIndex = 14
        Me.lblREFTYPE.Text = "REFTYPE"
        Me.lblREFTYPE.Visible = False
        '
        'gbPendingDecision
        '
        Me.gbPendingDecision.Controls.Add(Me.dgvPendingDecision)
        Me.gbPendingDecision.Location = New System.Drawing.Point(2, 589)
        Me.gbPendingDecision.Name = "gbPendingDecision"
        Me.gbPendingDecision.Size = New System.Drawing.Size(1086, 149)
        Me.gbPendingDecision.TabIndex = 16
        Me.gbPendingDecision.TabStop = False
        Me.gbPendingDecision.Text = "Short Fall Details (Confirmed / Pending Decision) "
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
        'gbPa
        '
        Me.gbPa.Controls.Add(Me.dgvPendingConfirmation)
        Me.gbPa.Location = New System.Drawing.Point(2, 406)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1086, 177)
        Me.gbPa.TabIndex = 15
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Short Fall Pending Confirmation"
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
        'fShortFall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 743)
        Me.Controls.Add(Me.gbPendingDecision)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.lblREFTYPE)
        Me.Controls.Add(Me.dgvShortfall)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "fShortFall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbRe_Assign.ResumeLayout(False)
        CType(Me.dgvRNONPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPendingDecision.ResumeLayout(False)
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents dgvShortfall As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHONEHSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHONEMOBILE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHONEOFFICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totshort As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents totrequested As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents totrecovered As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents totbal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents gbPendingDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingDecision As System.Windows.Forms.DataGridView
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingConfirmation As System.Windows.Forms.DataGridView
    Friend WithEvents pcView As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Confirm As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvRNONPD As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Request As System.Windows.Forms.DataGridViewLinkColumn
End Class
