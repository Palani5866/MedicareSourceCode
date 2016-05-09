<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSF))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.gbSFS = New System.Windows.Forms.GroupBox
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
        Me.gbDecisionMake = New System.Windows.Forms.GroupBox
        Me.lblAMT = New System.Windows.Forms.Label
        Me.txtRecoveredAmt = New System.Windows.Forms.TextBox
        Me.lblRecoveredAmt1 = New System.Windows.Forms.Label
        Me.lblRecoveredAmt = New System.Windows.Forms.Label
        Me.txtPaymentRefNo = New System.Windows.Forms.TextBox
        Me.lblPaymentRefNo1 = New System.Windows.Forms.Label
        Me.lblPaymentRefNo = New System.Windows.Forms.Label
        Me.txtDCode = New System.Windows.Forms.TextBox
        Me.lblDCode1 = New System.Windows.Forms.Label
        Me.lblDCode = New System.Windows.Forms.Label
        Me.txtRequestedAmt = New System.Windows.Forms.TextBox
        Me.lblRequestedAmt1 = New System.Windows.Forms.Label
        Me.lblRequestedAmt = New System.Windows.Forms.Label
        Me.txtRPTo = New System.Windows.Forms.TextBox
        Me.lblRPTo1 = New System.Windows.Forms.Label
        Me.lblRPTo = New System.Windows.Forms.Label
        Me.txtRPFrm = New System.Windows.Forms.TextBox
        Me.lblRPfrm1 = New System.Windows.Forms.Label
        Me.lblRPfrm = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.cmbCancellation_Reason = New System.Windows.Forms.ComboBox
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCancellation_Reason = New System.Windows.Forms.Label
        Me.dtpPolicy_CancellationDate = New System.Windows.Forms.DateTimePicker
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtsfRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks1 = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblRecoverType1 = New System.Windows.Forms.Label
        Me.lblRecoverType = New System.Windows.Forms.Label
        Me.flpPM = New System.Windows.Forms.FlowLayoutPanel
        Me.rbC2Y = New System.Windows.Forms.RadioButton
        Me.rbIgnor = New System.Windows.Forms.RadioButton
        Me.rbCP = New System.Windows.Forms.RadioButton
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.lblFullName1 = New System.Windows.Forms.Label
        Me.lblFullName = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.lblNRIC1 = New System.Windows.Forms.Label
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.lblREF3 = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        Me.ssReport.SuspendLayout()
        Me.gbSFS.SuspendLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDecisionMake.SuspendLayout()
        Me.flpPM.SuspendLayout()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1144, 25)
        Me.tolForm.TabIndex = 3
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 579)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(1144, 22)
        Me.ssReport.TabIndex = 8
        Me.ssReport.Text = "StatusStrip"
        '
        'ssReport_RecordCount
        '
        Me.ssReport_RecordCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_RecordCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_RecordCount.Name = "ssReport_RecordCount"
        Me.ssReport_RecordCount.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_RecordCount.Visible = False
        '
        'ssReport_Parameter
        '
        Me.ssReport_Parameter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_Parameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_Parameter.Name = "ssReport_Parameter"
        Me.ssReport_Parameter.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_Parameter.Visible = False
        '
        'gbSFS
        '
        Me.gbSFS.Controls.Add(Me.dgvShortfall)
        Me.gbSFS.Location = New System.Drawing.Point(0, 28)
        Me.gbSFS.Name = "gbSFS"
        Me.gbSFS.Size = New System.Drawing.Size(1144, 261)
        Me.gbSFS.TabIndex = 9
        Me.gbSFS.TabStop = False
        Me.gbSFS.Text = "Short Fall Summary"
        '
        'dgvShortfall
        '
        Me.dgvShortfall.AllowUserToAddRows = False
        Me.dgvShortfall.AllowUserToDeleteRows = False
        Me.dgvShortfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.ic, Me.fullname, Me.plan, Me.PHONEHSE, Me.PHONEMOBILE, Me.PHONEOFFICE, Me.EMAIL, Me.totshort, Me.totrequested, Me.totrecovered, Me.totbal})
        Me.dgvShortfall.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortfall.Location = New System.Drawing.Point(3, 16)
        Me.dgvShortfall.Name = "dgvShortfall"
        Me.dgvShortfall.ReadOnly = True
        Me.dgvShortfall.Size = New System.Drawing.Size(1138, 242)
        Me.dgvShortfall.TabIndex = 9
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'ic
        '
        Me.ic.DataPropertyName = "ic"
        Me.ic.HeaderText = "IC"
        Me.ic.Name = "ic"
        Me.ic.ReadOnly = True
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.HeaderText = "Full Name"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        '
        'plan
        '
        Me.plan.DataPropertyName = "plan"
        Me.plan.HeaderText = "PLAN"
        Me.plan.Name = "plan"
        Me.plan.ReadOnly = True
        '
        'PHONEHSE
        '
        Me.PHONEHSE.DataPropertyName = "PHONE_HSE"
        Me.PHONEHSE.HeaderText = "PHONE HOUSE"
        Me.PHONEHSE.Name = "PHONEHSE"
        Me.PHONEHSE.ReadOnly = True
        '
        'PHONEMOBILE
        '
        Me.PHONEMOBILE.DataPropertyName = "PHONE_MOBILE"
        Me.PHONEMOBILE.HeaderText = "PHONE MOBILE"
        Me.PHONEMOBILE.Name = "PHONEMOBILE"
        Me.PHONEMOBILE.ReadOnly = True
        '
        'PHONEOFFICE
        '
        Me.PHONEOFFICE.DataPropertyName = "PHONE_OFF"
        Me.PHONEOFFICE.HeaderText = "PHONE OFFICE"
        Me.PHONEOFFICE.Name = "PHONEOFFICE"
        Me.PHONEOFFICE.ReadOnly = True
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        '
        'totshort
        '
        Me.totshort.DataPropertyName = "totshort"
        Me.totshort.HeaderText = "Total Short"
        Me.totshort.Name = "totshort"
        Me.totshort.ReadOnly = True
        Me.totshort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totshort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'totrequested
        '
        Me.totrequested.DataPropertyName = "totrequested"
        Me.totrequested.HeaderText = "Total Requested"
        Me.totrequested.Name = "totrequested"
        Me.totrequested.ReadOnly = True
        Me.totrequested.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totrequested.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'totrecovered
        '
        Me.totrecovered.DataPropertyName = "totrecovered"
        Me.totrecovered.HeaderText = "Total Recovered"
        Me.totrecovered.Name = "totrecovered"
        Me.totrecovered.ReadOnly = True
        '
        'totbal
        '
        Me.totbal.DataPropertyName = "totbal"
        Me.totbal.HeaderText = "Total Balance"
        Me.totbal.Name = "totbal"
        Me.totbal.ReadOnly = True
        '
        'gbDecisionMake
        '
        Me.gbDecisionMake.Controls.Add(Me.lblAMT)
        Me.gbDecisionMake.Controls.Add(Me.txtRecoveredAmt)
        Me.gbDecisionMake.Controls.Add(Me.lblRecoveredAmt1)
        Me.gbDecisionMake.Controls.Add(Me.lblRecoveredAmt)
        Me.gbDecisionMake.Controls.Add(Me.txtPaymentRefNo)
        Me.gbDecisionMake.Controls.Add(Me.lblPaymentRefNo1)
        Me.gbDecisionMake.Controls.Add(Me.lblPaymentRefNo)
        Me.gbDecisionMake.Controls.Add(Me.txtDCode)
        Me.gbDecisionMake.Controls.Add(Me.lblDCode1)
        Me.gbDecisionMake.Controls.Add(Me.lblDCode)
        Me.gbDecisionMake.Controls.Add(Me.txtRequestedAmt)
        Me.gbDecisionMake.Controls.Add(Me.lblRequestedAmt1)
        Me.gbDecisionMake.Controls.Add(Me.lblRequestedAmt)
        Me.gbDecisionMake.Controls.Add(Me.txtRPTo)
        Me.gbDecisionMake.Controls.Add(Me.lblRPTo1)
        Me.gbDecisionMake.Controls.Add(Me.lblRPTo)
        Me.gbDecisionMake.Controls.Add(Me.txtRPFrm)
        Me.gbDecisionMake.Controls.Add(Me.lblRPfrm1)
        Me.gbDecisionMake.Controls.Add(Me.lblRPfrm)
        Me.gbDecisionMake.Controls.Add(Me.btnPrint)
        Me.gbDecisionMake.Controls.Add(Me.cmbCancellation_Reason)
        Me.gbDecisionMake.Controls.Add(Me.dtpEffective_Date)
        Me.gbDecisionMake.Controls.Add(Me.lblRequestedDate)
        Me.gbDecisionMake.Controls.Add(Me.Label1)
        Me.gbDecisionMake.Controls.Add(Me.lblCancellation_Reason)
        Me.gbDecisionMake.Controls.Add(Me.dtpPolicy_CancellationDate)
        Me.gbDecisionMake.Controls.Add(Me.dtpRequestedDate)
        Me.gbDecisionMake.Controls.Add(Me.btnCancel)
        Me.gbDecisionMake.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.gbDecisionMake.Controls.Add(Me.btnSubmit)
        Me.gbDecisionMake.Controls.Add(Me.txtsfRemarks)
        Me.gbDecisionMake.Controls.Add(Me.lblRemarks1)
        Me.gbDecisionMake.Controls.Add(Me.lblRemarks)
        Me.gbDecisionMake.Controls.Add(Me.lblRecoverType1)
        Me.gbDecisionMake.Controls.Add(Me.lblRecoverType)
        Me.gbDecisionMake.Controls.Add(Me.flpPM)
        Me.gbDecisionMake.Controls.Add(Me.txtFullName)
        Me.gbDecisionMake.Controls.Add(Me.lblFullName1)
        Me.gbDecisionMake.Controls.Add(Me.lblFullName)
        Me.gbDecisionMake.Controls.Add(Me.txtNRIC)
        Me.gbDecisionMake.Controls.Add(Me.lblNRIC1)
        Me.gbDecisionMake.Controls.Add(Me.lblNRIC)
        Me.gbDecisionMake.Location = New System.Drawing.Point(251, 295)
        Me.gbDecisionMake.Name = "gbDecisionMake"
        Me.gbDecisionMake.Size = New System.Drawing.Size(661, 274)
        Me.gbDecisionMake.TabIndex = 23
        Me.gbDecisionMake.TabStop = False
        Me.gbDecisionMake.Text = "Decision Making"
        '
        'lblAMT
        '
        Me.lblAMT.AutoSize = True
        Me.lblAMT.Location = New System.Drawing.Point(531, 163)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.Size = New System.Drawing.Size(28, 13)
        Me.lblAMT.TabIndex = 108
        Me.lblAMT.Text = "0.00"
        Me.lblAMT.Visible = False
        '
        'txtRecoveredAmt
        '
        Me.txtRecoveredAmt.Location = New System.Drawing.Point(431, 186)
        Me.txtRecoveredAmt.MaxLength = 6
        Me.txtRecoveredAmt.Name = "txtRecoveredAmt"
        Me.txtRecoveredAmt.Size = New System.Drawing.Size(78, 20)
        Me.txtRecoveredAmt.TabIndex = 107
        Me.txtRecoveredAmt.Text = "0.00"
        Me.txtRecoveredAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRecoveredAmt1
        '
        Me.lblRecoveredAmt1.AutoSize = True
        Me.lblRecoveredAmt1.Location = New System.Drawing.Point(415, 189)
        Me.lblRecoveredAmt1.Name = "lblRecoveredAmt1"
        Me.lblRecoveredAmt1.Size = New System.Drawing.Size(10, 13)
        Me.lblRecoveredAmt1.TabIndex = 106
        Me.lblRecoveredAmt1.Text = ":"
        '
        'lblRecoveredAmt
        '
        Me.lblRecoveredAmt.AutoSize = True
        Me.lblRecoveredAmt.Location = New System.Drawing.Point(276, 189)
        Me.lblRecoveredAmt.Name = "lblRecoveredAmt"
        Me.lblRecoveredAmt.Size = New System.Drawing.Size(99, 13)
        Me.lblRecoveredAmt.TabIndex = 105
        Me.lblRecoveredAmt.Text = "Recovered Amount"
        '
        'txtPaymentRefNo
        '
        Me.txtPaymentRefNo.Location = New System.Drawing.Point(162, 186)
        Me.txtPaymentRefNo.MaxLength = 6
        Me.txtPaymentRefNo.Name = "txtPaymentRefNo"
        Me.txtPaymentRefNo.Size = New System.Drawing.Size(78, 20)
        Me.txtPaymentRefNo.TabIndex = 104
        '
        'lblPaymentRefNo1
        '
        Me.lblPaymentRefNo1.AutoSize = True
        Me.lblPaymentRefNo1.Location = New System.Drawing.Point(146, 189)
        Me.lblPaymentRefNo1.Name = "lblPaymentRefNo1"
        Me.lblPaymentRefNo1.Size = New System.Drawing.Size(10, 13)
        Me.lblPaymentRefNo1.TabIndex = 103
        Me.lblPaymentRefNo1.Text = ":"
        '
        'lblPaymentRefNo
        '
        Me.lblPaymentRefNo.AutoSize = True
        Me.lblPaymentRefNo.Location = New System.Drawing.Point(31, 189)
        Me.lblPaymentRefNo.Name = "lblPaymentRefNo"
        Me.lblPaymentRefNo.Size = New System.Drawing.Size(81, 13)
        Me.lblPaymentRefNo.TabIndex = 102
        Me.lblPaymentRefNo.Text = "Payment Ref # "
        '
        'txtDCode
        '
        Me.txtDCode.Location = New System.Drawing.Point(431, 160)
        Me.txtDCode.MaxLength = 13
        Me.txtDCode.Name = "txtDCode"
        Me.txtDCode.ReadOnly = True
        Me.txtDCode.Size = New System.Drawing.Size(78, 20)
        Me.txtDCode.TabIndex = 101
        Me.txtDCode.Text = "0599"
        Me.txtDCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDCode1
        '
        Me.lblDCode1.AutoSize = True
        Me.lblDCode1.Location = New System.Drawing.Point(415, 163)
        Me.lblDCode1.Name = "lblDCode1"
        Me.lblDCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblDCode1.TabIndex = 100
        Me.lblDCode1.Text = ":"
        '
        'lblDCode
        '
        Me.lblDCode.AutoSize = True
        Me.lblDCode.Location = New System.Drawing.Point(291, 163)
        Me.lblDCode.Name = "lblDCode"
        Me.lblDCode.Size = New System.Drawing.Size(84, 13)
        Me.lblDCode.TabIndex = 99
        Me.lblDCode.Text = "Deduction Code"
        '
        'txtRequestedAmt
        '
        Me.txtRequestedAmt.Location = New System.Drawing.Point(162, 160)
        Me.txtRequestedAmt.MaxLength = 10
        Me.txtRequestedAmt.Name = "txtRequestedAmt"
        Me.txtRequestedAmt.Size = New System.Drawing.Size(78, 20)
        Me.txtRequestedAmt.TabIndex = 98
        Me.txtRequestedAmt.Text = "0.00"
        Me.txtRequestedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequestedAmt1
        '
        Me.lblRequestedAmt1.AutoSize = True
        Me.lblRequestedAmt1.Location = New System.Drawing.Point(146, 163)
        Me.lblRequestedAmt1.Name = "lblRequestedAmt1"
        Me.lblRequestedAmt1.Size = New System.Drawing.Size(10, 13)
        Me.lblRequestedAmt1.TabIndex = 97
        Me.lblRequestedAmt1.Text = ":"
        '
        'lblRequestedAmt
        '
        Me.lblRequestedAmt.AutoSize = True
        Me.lblRequestedAmt.Location = New System.Drawing.Point(31, 163)
        Me.lblRequestedAmt.Name = "lblRequestedAmt"
        Me.lblRequestedAmt.Size = New System.Drawing.Size(98, 13)
        Me.lblRequestedAmt.TabIndex = 96
        Me.lblRequestedAmt.Text = "Requested Amount"
        '
        'txtRPTo
        '
        Me.txtRPTo.Location = New System.Drawing.Point(431, 137)
        Me.txtRPTo.MaxLength = 6
        Me.txtRPTo.Name = "txtRPTo"
        Me.txtRPTo.Size = New System.Drawing.Size(78, 20)
        Me.txtRPTo.TabIndex = 95
        Me.txtRPTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRPTo1
        '
        Me.lblRPTo1.AutoSize = True
        Me.lblRPTo1.Location = New System.Drawing.Point(415, 140)
        Me.lblRPTo1.Name = "lblRPTo1"
        Me.lblRPTo1.Size = New System.Drawing.Size(10, 13)
        Me.lblRPTo1.TabIndex = 94
        Me.lblRPTo1.Text = ":"
        '
        'lblRPTo
        '
        Me.lblRPTo.AutoSize = True
        Me.lblRPTo.Location = New System.Drawing.Point(246, 140)
        Me.lblRPTo.Name = "lblRPTo"
        Me.lblRPTo.Size = New System.Drawing.Size(109, 13)
        Me.lblRPTo.TabIndex = 93
        Me.lblRPTo.Text = "Recovered Period To"
        '
        'txtRPFrm
        '
        Me.txtRPFrm.Location = New System.Drawing.Point(162, 137)
        Me.txtRPFrm.MaxLength = 6
        Me.txtRPFrm.Name = "txtRPFrm"
        Me.txtRPFrm.Size = New System.Drawing.Size(78, 20)
        Me.txtRPFrm.TabIndex = 92
        Me.txtRPFrm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRPfrm1
        '
        Me.lblRPfrm1.AutoSize = True
        Me.lblRPfrm1.Location = New System.Drawing.Point(146, 140)
        Me.lblRPfrm1.Name = "lblRPfrm1"
        Me.lblRPfrm1.Size = New System.Drawing.Size(10, 13)
        Me.lblRPfrm1.TabIndex = 91
        Me.lblRPfrm1.Text = ":"
        '
        'lblRPfrm
        '
        Me.lblRPfrm.AutoSize = True
        Me.lblRPfrm.Location = New System.Drawing.Point(31, 140)
        Me.lblRPfrm.Name = "lblRPfrm"
        Me.lblRPfrm.Size = New System.Drawing.Size(119, 13)
        Me.lblRPfrm.TabIndex = 90
        Me.lblRPfrm.Text = "Recovered Period From"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(166, 244)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 89
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmbCancellation_Reason
        '
        Me.cmbCancellation_Reason.FormattingEnabled = True
        Me.cmbCancellation_Reason.Items.AddRange(New Object() {"User request to cancel", "Non-Payment", "Change to Yearly", "Angkasa Payment > 60%", "NO DEDUCTION FROM ANGKASA", "Non-Payment Cannot Contact", "Change to Angkasa / Others", "Incomplete Angkasa"})
        Me.cmbCancellation_Reason.Location = New System.Drawing.Point(134, 112)
        Me.cmbCancellation_Reason.Name = "cmbCancellation_Reason"
        Me.cmbCancellation_Reason.Size = New System.Drawing.Size(272, 21)
        Me.cmbCancellation_Reason.TabIndex = 5
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(502, 111)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(126, 20)
        Me.dtpEffective_Date.TabIndex = 18
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(31, 90)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(88, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Requested Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(412, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Effective Date:"
        '
        'lblCancellation_Reason
        '
        Me.lblCancellation_Reason.AutoSize = True
        Me.lblCancellation_Reason.Location = New System.Drawing.Point(31, 115)
        Me.lblCancellation_Reason.Name = "lblCancellation_Reason"
        Me.lblCancellation_Reason.Size = New System.Drawing.Size(108, 13)
        Me.lblCancellation_Reason.TabIndex = 4
        Me.lblCancellation_Reason.Text = "Cancellation Reason:"
        '
        'dtpPolicy_CancellationDate
        '
        Me.dtpPolicy_CancellationDate.Location = New System.Drawing.Point(502, 86)
        Me.dtpPolicy_CancellationDate.Name = "dtpPolicy_CancellationDate"
        Me.dtpPolicy_CancellationDate.Size = New System.Drawing.Size(127, 20)
        Me.dtpPolicy_CancellationDate.TabIndex = 3
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(134, 86)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(229, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(348, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 88
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(396, 90)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 2
        Me.lblPolicy_CancellationDate.Text = "Cancellation Date:"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(253, 244)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 87
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtsfRemarks
        '
        Me.txtsfRemarks.Location = New System.Drawing.Point(162, 211)
        Me.txtsfRemarks.MaxLength = 2000
        Me.txtsfRemarks.Multiline = True
        Me.txtsfRemarks.Name = "txtsfRemarks"
        Me.txtsfRemarks.Size = New System.Drawing.Size(466, 27)
        Me.txtsfRemarks.TabIndex = 86
        '
        'lblRemarks1
        '
        Me.lblRemarks1.AutoSize = True
        Me.lblRemarks1.Location = New System.Drawing.Point(146, 214)
        Me.lblRemarks1.Name = "lblRemarks1"
        Me.lblRemarks1.Size = New System.Drawing.Size(10, 13)
        Me.lblRemarks1.TabIndex = 85
        Me.lblRemarks1.Text = ":"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(31, 214)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 84
        Me.lblRemarks.Text = "Remarks"
        '
        'lblRecoverType1
        '
        Me.lblRecoverType1.AutoSize = True
        Me.lblRecoverType1.Location = New System.Drawing.Point(118, 60)
        Me.lblRecoverType1.Name = "lblRecoverType1"
        Me.lblRecoverType1.Size = New System.Drawing.Size(10, 13)
        Me.lblRecoverType1.TabIndex = 83
        Me.lblRecoverType1.Text = ":"
        '
        'lblRecoverType
        '
        Me.lblRecoverType.AutoSize = True
        Me.lblRecoverType.Location = New System.Drawing.Point(31, 60)
        Me.lblRecoverType.Name = "lblRecoverType"
        Me.lblRecoverType.Size = New System.Drawing.Size(75, 13)
        Me.lblRecoverType.TabIndex = 82
        Me.lblRecoverType.Text = "Recover Type"
        '
        'flpPM
        '
        Me.flpPM.Controls.Add(Me.rbC2Y)
        Me.flpPM.Controls.Add(Me.rbIgnor)
        Me.flpPM.Controls.Add(Me.rbCP)
        Me.flpPM.Location = New System.Drawing.Point(134, 55)
        Me.flpPM.Name = "flpPM"
        Me.flpPM.Size = New System.Drawing.Size(494, 25)
        Me.flpPM.TabIndex = 81
        '
        'rbC2Y
        '
        Me.rbC2Y.AutoSize = True
        Me.rbC2Y.Checked = True
        Me.rbC2Y.Location = New System.Drawing.Point(3, 3)
        Me.rbC2Y.Name = "rbC2Y"
        Me.rbC2Y.Size = New System.Drawing.Size(109, 17)
        Me.rbC2Y.TabIndex = 2
        Me.rbC2Y.TabStop = True
        Me.rbC2Y.Text = "Direct Pay (Client)"
        Me.rbC2Y.UseVisualStyleBackColor = True
        '
        'rbIgnor
        '
        Me.rbIgnor.AutoSize = True
        Me.rbIgnor.Location = New System.Drawing.Point(118, 3)
        Me.rbIgnor.Name = "rbIgnor"
        Me.rbIgnor.Size = New System.Drawing.Size(168, 17)
        Me.rbIgnor.TabIndex = 3
        Me.rbIgnor.Text = "Request to Deduction Agency"
        Me.rbIgnor.UseVisualStyleBackColor = True
        '
        'rbCP
        '
        Me.rbCP.AutoSize = True
        Me.rbCP.Location = New System.Drawing.Point(292, 3)
        Me.rbCP.Name = "rbCP"
        Me.rbCP.Size = New System.Drawing.Size(89, 17)
        Me.rbCP.TabIndex = 1
        Me.rbCP.Text = "Cancel Policy"
        Me.rbCP.UseVisualStyleBackColor = True
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(369, 23)
        Me.txtFullName.MaxLength = 200
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(259, 20)
        Me.txtFullName.TabIndex = 77
        '
        'lblFullName1
        '
        Me.lblFullName1.AutoSize = True
        Me.lblFullName1.Location = New System.Drawing.Point(353, 26)
        Me.lblFullName1.Name = "lblFullName1"
        Me.lblFullName1.Size = New System.Drawing.Size(10, 13)
        Me.lblFullName1.TabIndex = 76
        Me.lblFullName1.Text = ":"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(266, 26)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(54, 13)
        Me.lblFullName.TabIndex = 75
        Me.lblFullName.Text = "Full Name"
        '
        'txtNRIC
        '
        Me.txtNRIC.Location = New System.Drawing.Point(134, 23)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(126, 20)
        Me.txtNRIC.TabIndex = 74
        '
        'lblNRIC1
        '
        Me.lblNRIC1.AutoSize = True
        Me.lblNRIC1.Location = New System.Drawing.Point(118, 26)
        Me.lblNRIC1.Name = "lblNRIC1"
        Me.lblNRIC1.Size = New System.Drawing.Size(10, 13)
        Me.lblNRIC1.TabIndex = 73
        Me.lblNRIC1.Text = ":"
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(31, 26)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(33, 13)
        Me.lblNRIC.TabIndex = 72
        Me.lblNRIC.Text = "NRIC"
        '
        'lblREF3
        '
        Me.lblREF3.AutoSize = True
        Me.lblREF3.Location = New System.Drawing.Point(1051, 388)
        Me.lblREF3.Name = "lblREF3"
        Me.lblREF3.Size = New System.Drawing.Size(34, 13)
        Me.lblREF3.TabIndex = 26
        Me.lblREF3.Text = "REF3"
        Me.lblREF3.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(1051, 414)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 25
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(1052, 437)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 24
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'fSF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 601)
        Me.Controls.Add(Me.lblREF3)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.gbDecisionMake)
        Me.Controls.Add(Me.gbSFS)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fSF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall Report"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        Me.gbSFS.ResumeLayout(False)
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDecisionMake.ResumeLayout(False)
        Me.gbDecisionMake.PerformLayout()
        Me.flpPM.ResumeLayout(False)
        Me.flpPM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbSFS As System.Windows.Forms.GroupBox
    Friend WithEvents dgvShortfall As System.Windows.Forms.DataGridView
    Friend WithEvents gbDecisionMake As System.Windows.Forms.GroupBox
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Friend WithEvents txtRecoveredAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblRecoveredAmt1 As System.Windows.Forms.Label
    Friend WithEvents lblRecoveredAmt As System.Windows.Forms.Label
    Friend WithEvents txtPaymentRefNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPaymentRefNo1 As System.Windows.Forms.Label
    Friend WithEvents lblPaymentRefNo As System.Windows.Forms.Label
    Friend WithEvents txtDCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDCode1 As System.Windows.Forms.Label
    Friend WithEvents lblDCode As System.Windows.Forms.Label
    Friend WithEvents txtRequestedAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestedAmt1 As System.Windows.Forms.Label
    Friend WithEvents lblRequestedAmt As System.Windows.Forms.Label
    Friend WithEvents txtRPTo As System.Windows.Forms.TextBox
    Friend WithEvents lblRPTo1 As System.Windows.Forms.Label
    Friend WithEvents lblRPTo As System.Windows.Forms.Label
    Friend WithEvents txtRPFrm As System.Windows.Forms.TextBox
    Friend WithEvents lblRPfrm1 As System.Windows.Forms.Label
    Friend WithEvents lblRPfrm As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbCancellation_Reason As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCancellation_Reason As System.Windows.Forms.Label
    Friend WithEvents dtpPolicy_CancellationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtsfRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks1 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblRecoverType1 As System.Windows.Forms.Label
    Friend WithEvents lblRecoverType As System.Windows.Forms.Label
    Friend WithEvents flpPM As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbC2Y As System.Windows.Forms.RadioButton
    Friend WithEvents rbIgnor As System.Windows.Forms.RadioButton
    Friend WithEvents rbCP As System.Windows.Forms.RadioButton
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName1 As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNRIC1 As System.Windows.Forms.Label
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents lblREF3 As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
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
End Class
