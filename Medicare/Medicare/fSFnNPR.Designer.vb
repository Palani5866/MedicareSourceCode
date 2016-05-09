<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSFnNPR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSFnNPR))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.lblP1 = New System.Windows.Forms.Label
        Me.dgvNPnSF = New System.Windows.Forms.DataGridView
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPendingConfirmation = New System.Windows.Forms.DataGridView
        Me.pcView = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Confirm = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbPendingDecision = New System.Windows.Forms.GroupBox
        Me.dgvPendingDecision = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REFID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_TO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_ON = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_BY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IC_NEW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.full_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.DMFRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DMTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPendingDecision.SuspendLayout()
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1093, 25)
        Me.tolForm.TabIndex = 13
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
        Me.gbRe_Assign.Controls.Add(Me.lblP1)
        Me.gbRe_Assign.Controls.Add(Me.dgvNPnSF)
        Me.gbRe_Assign.Location = New System.Drawing.Point(0, 28)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1089, 217)
        Me.gbRe_Assign.TabIndex = 14
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Request"
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(417, 126)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 7
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'dgvNPnSF
        '
        Me.dgvNPnSF.AllowUserToAddRows = False
        Me.dgvNPnSF.AllowUserToDeleteRows = False
        Me.dgvNPnSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNPnSF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.REFID, Me.ASSIGN_TO, Me.ASSIGN_ON, Me.ASSIGN_BY, Me.IC_NEW, Me.full_name, Me.DOB, Me.PCODE, Me.PTYPE, Me.FNO, Me.PHOUSE, Me.POFFICE, Me.PMOBILE, Me.EMAIL, Me.NON_PAYMENT, Me.TOT_SHORT, Me.TOT_SHORT_NR, Me.TOT_SHORT_R, Me.TOT_SHORT_RECOVER, Me.TOT_BAL, Me.DMFRM, Me.DMTO, Me.RAMT, Me.UP, Me.View, Me.Submit})
        Me.dgvNPnSF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNPnSF.Location = New System.Drawing.Point(3, 16)
        Me.dgvNPnSF.Name = "dgvNPnSF"
        Me.dgvNPnSF.Size = New System.Drawing.Size(1083, 198)
        Me.dgvNPnSF.TabIndex = 6
        '
        'gbPa
        '
        Me.gbPa.Controls.Add(Me.dgvPendingConfirmation)
        Me.gbPa.Location = New System.Drawing.Point(3, 251)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1086, 229)
        Me.gbPa.TabIndex = 18
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Pending Confirmation"
        '
        'dgvPendingConfirmation
        '
        Me.dgvPendingConfirmation.AllowUserToAddRows = False
        Me.dgvPendingConfirmation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingConfirmation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcView, Me.Confirm})
        Me.dgvPendingConfirmation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingConfirmation.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingConfirmation.Name = "dgvPendingConfirmation"
        Me.dgvPendingConfirmation.Size = New System.Drawing.Size(1080, 210)
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
        'gbPendingDecision
        '
        Me.gbPendingDecision.Controls.Add(Me.dgvPendingDecision)
        Me.gbPendingDecision.Location = New System.Drawing.Point(3, 486)
        Me.gbPendingDecision.Name = "gbPendingDecision"
        Me.gbPendingDecision.Size = New System.Drawing.Size(1086, 203)
        Me.gbPendingDecision.TabIndex = 19
        Me.gbPendingDecision.TabStop = False
        Me.gbPendingDecision.Text = "Request Details (Confirmed / Closed )"
        '
        'dgvPendingDecision
        '
        Me.dgvPendingDecision.AllowUserToAddRows = False
        Me.dgvPendingDecision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingDecision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingDecision.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingDecision.Name = "dgvPendingDecision"
        Me.dgvPendingDecision.Size = New System.Drawing.Size(1080, 184)
        Me.dgvPendingDecision.TabIndex = 0
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
        'full_name
        '
        Me.full_name.DataPropertyName = "full_name"
        Me.full_name.HeaderText = "FULL NAME"
        Me.full_name.Name = "full_name"
        '
        'DOB
        '
        Me.DOB.DataPropertyName = "DOB"
        Me.DOB.HeaderText = "DOB"
        Me.DOB.Name = "DOB"
        '
        'PCODE
        '
        Me.PCODE.DataPropertyName = "PCODE"
        Me.PCODE.HeaderText = "PLAN CODE"
        Me.PCODE.Name = "PCODE"
        '
        'PTYPE
        '
        Me.PTYPE.DataPropertyName = "PTYPE"
        Me.PTYPE.HeaderText = "PLAN TYPE"
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
        Me.NON_PAYMENT.HeaderText = "TOT NON PAYMENT"
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
        Me.TOT_SHORT_R.HeaderText = "TOTAL SHORT REQUESTED"
        Me.TOT_SHORT_R.Name = "TOT_SHORT_R"
        '
        'TOT_SHORT_RECOVER
        '
        Me.TOT_SHORT_RECOVER.DataPropertyName = "TOT_SHORT_RECOVER"
        Me.TOT_SHORT_RECOVER.HeaderText = "TOTAL SHORT RECOVER"
        Me.TOT_SHORT_RECOVER.Name = "TOT_SHORT_RECOVER"
        '
        'TOT_BAL
        '
        Me.TOT_BAL.DataPropertyName = "TOT_BAL"
        Me.TOT_BAL.HeaderText = "TOTAL BALANCE"
        Me.TOT_BAL.Name = "TOT_BAL"
        '
        'DMFRM
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DMFRM.DefaultCellStyle = DataGridViewCellStyle1
        Me.DMFRM.HeaderText = "DEDUCTION MONTH FROM"
        Me.DMFRM.MaxInputLength = 6
        Me.DMFRM.Name = "DMFRM"
        '
        'DMTO
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DMTO.DefaultCellStyle = DataGridViewCellStyle2
        Me.DMTO.HeaderText = "DEDUCTION MONTH TO"
        Me.DMTO.MaxInputLength = 6
        Me.DMTO.Name = "DMTO"
        '
        'RAMT
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.RAMT.DefaultCellStyle = DataGridViewCellStyle3
        Me.RAMT.HeaderText = "REQUEST AMOUNT"
        Me.RAMT.MaxInputLength = 6
        Me.RAMT.Name = "RAMT"
        '
        'UP
        '
        Me.UP.HeaderText = "UPLOAD"
        Me.UP.Name = "UP"
        Me.UP.Text = "Upload"
        Me.UP.ToolTipText = "Upload"
        Me.UP.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'fSFnNPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 698)
        Me.Controls.Add(Me.gbPendingDecision)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "fSFnNPR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall and Non Payment Request"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbRe_Assign.ResumeLayout(False)
        Me.gbRe_Assign.PerformLayout()
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPendingDecision.ResumeLayout(False)
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingConfirmation As System.Windows.Forms.DataGridView
    Friend WithEvents pcView As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Confirm As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents gbPendingDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingDecision As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNPnSF As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_TO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_ON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_BY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IC_NEW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents full_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOB As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents DMFRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
End Class
