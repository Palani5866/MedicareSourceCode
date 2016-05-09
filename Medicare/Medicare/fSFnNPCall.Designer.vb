<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSFnNPCall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSFnNPCall))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.dgvNPnSF = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvShortFallsDetails = New System.Windows.Forms.DataGridView
        Me.lblP1 = New System.Windows.Forms.Label
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REFID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_TO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_ON = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_BY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IC_NEW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FULL_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Birth_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHOUSE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POFFICE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PMOBILE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NON_PAYMENT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_NR = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_R = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_RECOVER = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_BAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReminderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.aAction = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvShortFallsDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1151, 25)
        Me.tolForm.TabIndex = 15
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
        Me.gbRe_Assign.Controls.Add(Me.dgvNPnSF)
        Me.gbRe_Assign.Location = New System.Drawing.Point(0, 28)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1142, 217)
        Me.gbRe_Assign.TabIndex = 17
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Follow up"
        '
        'dgvNPnSF
        '
        Me.dgvNPnSF.AllowUserToAddRows = False
        Me.dgvNPnSF.AllowUserToDeleteRows = False
        Me.dgvNPnSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNPnSF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.REFID, Me.ASSIGN_TO, Me.ASSIGN_ON, Me.ASSIGN_BY, Me.IC_NEW, Me.FULL_NAME, Me.Birth_Date, Me.PCODE, Me.PTYPE, Me.FNO, Me.PHOUSE, Me.POFFICE, Me.PMOBILE, Me.EMAIL, Me.NON_PAYMENT, Me.TOT_SHORT, Me.TOT_SHORT_NR, Me.TOT_SHORT_R, Me.TOT_SHORT_RECOVER, Me.TOT_BAL, Me.Comments, Me.ReminderDate, Me.Remarks, Me.Action, Me.AssignTo, Me.aAction, Me.View})
        Me.dgvNPnSF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNPnSF.Location = New System.Drawing.Point(3, 16)
        Me.dgvNPnSF.Name = "dgvNPnSF"
        Me.dgvNPnSF.Size = New System.Drawing.Size(1136, 198)
        Me.dgvNPnSF.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvShortFallsDetails)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 251)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1139, 212)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Followed up Details"
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
        Me.dgvShortFallsDetails.Size = New System.Drawing.Size(1133, 193)
        Me.dgvShortFallsDetails.TabIndex = 0
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(565, 226)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 19
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'REFID
        '
        Me.REFID.DataPropertyName = "REFID"
        Me.REFID.HeaderText = "REFID"
        Me.REFID.Name = "REFID"
        Me.REFID.Visible = False
        '
        'ASSIGN_TO
        '
        Me.ASSIGN_TO.DataPropertyName = "ASSIGN_TO"
        Me.ASSIGN_TO.HeaderText = "ASSIGN TO"
        Me.ASSIGN_TO.Name = "ASSIGN_TO"
        '
        'ASSIGN_ON
        '
        Me.ASSIGN_ON.DataPropertyName = "ASSIGN_ON"
        Me.ASSIGN_ON.HeaderText = "ASSIGN ON"
        Me.ASSIGN_ON.Name = "ASSIGN_ON"
        '
        'ASSIGN_BY
        '
        Me.ASSIGN_BY.DataPropertyName = "ASSIGN_BY"
        Me.ASSIGN_BY.HeaderText = "ASSIGN BY"
        Me.ASSIGN_BY.Name = "ASSIGN_BY"
        '
        'IC_NEW
        '
        Me.IC_NEW.DataPropertyName = "IC_NEW"
        Me.IC_NEW.HeaderText = "IC"
        Me.IC_NEW.Name = "IC_NEW"
        '
        'FULL_NAME
        '
        Me.FULL_NAME.DataPropertyName = "FULL_NAME"
        Me.FULL_NAME.HeaderText = "FULL NAME"
        Me.FULL_NAME.Name = "FULL_NAME"
        '
        'Birth_Date
        '
        Me.Birth_Date.DataPropertyName = "Birth_Date"
        Me.Birth_Date.HeaderText = "DOB"
        Me.Birth_Date.Name = "Birth_Date"
        '
        'PCODE
        '
        Me.PCODE.DataPropertyName = "PCODE"
        Me.PCODE.HeaderText = "PLANCODE"
        Me.PCODE.Name = "PCODE"
        '
        'PTYPE
        '
        Me.PTYPE.DataPropertyName = "PTYPE"
        Me.PTYPE.HeaderText = "PLANTYPE"
        Me.PTYPE.Name = "PTYPE"
        '
        'FNO
        '
        Me.FNO.DataPropertyName = "FNO"
        Me.FNO.HeaderText = "FILE NO"
        Me.FNO.Name = "FNO"
        '
        'PHOUSE
        '
        Me.PHOUSE.DataPropertyName = "PHOUSE"
        Me.PHOUSE.HeaderText = "PHONE HOUSE"
        Me.PHOUSE.Name = "PHOUSE"
        '
        'POFFICE
        '
        Me.POFFICE.DataPropertyName = "POFFICE"
        Me.POFFICE.HeaderText = "PHONE OFFICE"
        Me.POFFICE.Name = "POFFICE"
        '
        'PMOBILE
        '
        Me.PMOBILE.DataPropertyName = "PMOBILE"
        Me.PMOBILE.HeaderText = "PHONE MOBILE"
        Me.PMOBILE.Name = "PMOBILE"
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        '
        'NON_PAYMENT
        '
        Me.NON_PAYMENT.DataPropertyName = "NON_PAYMENT"
        Me.NON_PAYMENT.HeaderText = "TOTAL NON PAYMENT"
        Me.NON_PAYMENT.Name = "NON_PAYMENT"
        '
        'TOT_SHORT
        '
        Me.TOT_SHORT.DataPropertyName = "TOT_SHORT"
        Me.TOT_SHORT.HeaderText = "TOTAL SHORT"
        Me.TOT_SHORT.Name = "TOT_SHORT"
        '
        'TOT_SHORT_NR
        '
        Me.TOT_SHORT_NR.DataPropertyName = "TOT_SHORT_NR"
        Me.TOT_SHORT_NR.HeaderText = "TOTAL SHORT NOT REQUESTED"
        Me.TOT_SHORT_NR.Name = "TOT_SHORT_NR"
        '
        'TOT_SHORT_R
        '
        Me.TOT_SHORT_R.DataPropertyName = "TOT_SHORT_R"
        Me.TOT_SHORT_R.HeaderText = "TOTAL REQUESTED"
        Me.TOT_SHORT_R.Name = "TOT_SHORT_R"
        '
        'TOT_SHORT_RECOVER
        '
        Me.TOT_SHORT_RECOVER.DataPropertyName = "TOT_SHORT_RECOVER"
        Me.TOT_SHORT_RECOVER.HeaderText = "TOTAL RECOVERED"
        Me.TOT_SHORT_RECOVER.Name = "TOT_SHORT_RECOVER"
        '
        'TOT_BAL
        '
        Me.TOT_BAL.DataPropertyName = "TOT_BAL"
        Me.TOT_BAL.HeaderText = "TOTAL BALANCE"
        Me.TOT_BAL.Name = "TOT_BAL"
        '
        'Comments
        '
        Me.Comments.HeaderText = "Comments / Remarks"
        Me.Comments.Name = "Comments"
        '
        'ReminderDate
        '
        Me.ReminderDate.HeaderText = "Reminder Date"
        Me.ReminderDate.Name = "ReminderDate"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = False
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Items.AddRange(New Object() {"PREMIUM REQUEST", "CANCEL POLICY"})
        Me.Action.Name = "Action"
        '
        'AssignTo
        '
        Me.AssignTo.HeaderText = "Assign To"
        Me.AssignTo.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.AssignTo.Name = "AssignTo"
        '
        'aAction
        '
        Me.aAction.HeaderText = "Action"
        Me.aAction.Name = "aAction"
        Me.aAction.Text = "Submit"
        Me.aAction.ToolTipText = "Submit"
        Me.aAction.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'fSFnNPCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 465)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "fSFnNPCall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shortfall and Non Payment Followup"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbRe_Assign.ResumeLayout(False)
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvShortFallsDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvShortFallsDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents dgvNPnSF As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_TO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_ON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_BY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IC_NEW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FULL_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Birth_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHOUSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POFFICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PMOBILE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NON_PAYMENT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_NR As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_R As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_RECOVER As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_BAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReminderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents aAction As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
End Class
