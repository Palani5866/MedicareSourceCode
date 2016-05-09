<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ftShortfall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ftShortfall))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvShortfall = New System.Windows.Forms.DataGridView
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.dgvShortFallsDetails = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RID = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.tolForm.SuspendLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvShortFallsDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1139, 25)
        Me.tolForm.TabIndex = 12
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
        'dgvShortfall
        '
        Me.dgvShortfall.AllowUserToAddRows = False
        Me.dgvShortfall.AllowUserToOrderColumns = True
        Me.dgvShortfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.RID, Me.ic, Me.fullname, Me.plan, Me.PHONEHSE, Me.PHONEMOBILE, Me.PHONEOFFICE, Me.EMAIL, Me.totshort, Me.totrequested, Me.totrecovered, Me.totbal, Me.Reason, Me.Action, Me.Remarks, Me.Submit})
        Me.dgvShortfall.Location = New System.Drawing.Point(0, 28)
        Me.dgvShortfall.Name = "dgvShortfall"
        Me.dgvShortfall.Size = New System.Drawing.Size(1138, 261)
        Me.dgvShortfall.TabIndex = 14
        '
        'gbRe_Assign
        '
        Me.gbRe_Assign.Controls.Add(Me.dgvShortFallsDetails)
        Me.gbRe_Assign.Location = New System.Drawing.Point(0, 295)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1139, 281)
        Me.gbRe_Assign.TabIndex = 15
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Short Fall Details"
        '
        'dgvShortFallsDetails
        '
        Me.dgvShortFallsDetails.AllowUserToAddRows = False
        Me.dgvShortFallsDetails.AllowUserToDeleteRows = False
        Me.dgvShortFallsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortFallsDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortFallsDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvShortFallsDetails.Name = "dgvShortFallsDetails"
        Me.dgvShortFallsDetails.ReadOnly = True
        Me.dgvShortFallsDetails.Size = New System.Drawing.Size(1133, 262)
        Me.dgvShortFallsDetails.TabIndex = 0
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'RID
        '
        Me.RID.DataPropertyName = "rID"
        Me.RID.HeaderText = "RID"
        Me.RID.Name = "RID"
        Me.RID.Visible = False
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
        Me.Action.Items.AddRange(New Object() {"Finance", "Premium"})
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
        'ftShortfall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 588)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.dgvShortfall)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "ftShortfall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall (Tele Marketing)"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRe_Assign.ResumeLayout(False)
        CType(Me.dgvShortFallsDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvShortfall As System.Windows.Forms.DataGridView
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents dgvShortFallsDetails As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RID As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
