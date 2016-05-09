<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdReport_Premium_Not_ReceivedFrAgency_Monthly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdReport_Premium_Not_ReceivedFrAgency_Monthly))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_ddlMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_Export = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.Angkasa_FileNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Full_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IC_New = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deduction_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deduction_Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agent_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submission_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Effective_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cancellation_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Last_Deduction_Month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Phone_HSE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.phone_off = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tsReport.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.ToolStripLabel1, Me.tsReport_txtDeductionCode_To, Me.tsReport_lblMonth, Me.tsReport_ddlMonth, Me.tsReport_Go, Me.tsReport_Div1, Me.tsReport_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(784, 25)
        Me.tsReport.TabIndex = 0
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDeductionCode_From
        '
        Me.tsReport_lblDeductionCode_From.Name = "tsReport_lblDeductionCode_From"
        Me.tsReport_lblDeductionCode_From.Size = New System.Drawing.Size(121, 22)
        Me.tsReport_lblDeductionCode_From.Text = "Deduction Code - From:"
        '
        'tsReport_txtDeductionCode_From
        '
        Me.tsReport_txtDeductionCode_From.MaxLength = 10
        Me.tsReport_txtDeductionCode_From.Name = "tsReport_txtDeductionCode_From"
        Me.tsReport_txtDeductionCode_From.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel1.Text = "Deduction Code - To:"
        '
        'tsReport_txtDeductionCode_To
        '
        Me.tsReport_txtDeductionCode_To.MaxLength = 10
        Me.tsReport_txtDeductionCode_To.Name = "tsReport_txtDeductionCode_To"
        Me.tsReport_txtDeductionCode_To.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblMonth
        '
        Me.tsReport_lblMonth.Name = "tsReport_lblMonth"
        Me.tsReport_lblMonth.Size = New System.Drawing.Size(44, 22)
        Me.tsReport_lblMonth.Text = "Month :"
        '
        'tsReport_ddlMonth
        '
        Me.tsReport_ddlMonth.Name = "tsReport_ddlMonth"
        Me.tsReport_ddlMonth.Size = New System.Drawing.Size(75, 25)
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsReport_Export
        '
        Me.tsReport_Export.Image = CType(resources.GetObject("tsReport_Export.Image"), System.Drawing.Image)
        Me.tsReport_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Export.Name = "tsReport_Export"
        Me.tsReport_Export.Size = New System.Drawing.Size(59, 22)
        Me.tsReport_Export.Text = "Export"
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 542)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(784, 22)
        Me.ssReport.TabIndex = 2
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
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvForm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Angkasa_FileNo, Me.Full_Name, Me.IC_New, Me.Deduction_Code, Me.Deduction_Amount, Me.Agent_Code, Me.Submission_Date, Me.Effective_Date, Me.Cancellation_Date, Me.Last_Deduction_Month, Me.PHTel, Me.Phone_HSE, Me.phone_off, Me.Email})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvForm.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvForm.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvForm.Size = New System.Drawing.Size(784, 517)
        Me.dgvForm.TabIndex = 1
        '
        'Angkasa_FileNo
        '
        Me.Angkasa_FileNo.HeaderText = "File No."
        Me.Angkasa_FileNo.Name = "Angkasa_FileNo"
        Me.Angkasa_FileNo.ReadOnly = True
        '
        'Full_Name
        '
        Me.Full_Name.HeaderText = "Full Name"
        Me.Full_Name.Name = "Full_Name"
        Me.Full_Name.ReadOnly = True
        '
        'IC_New
        '
        Me.IC_New.HeaderText = "IC"
        Me.IC_New.Name = "IC_New"
        Me.IC_New.ReadOnly = True
        '
        'Deduction_Code
        '
        Me.Deduction_Code.HeaderText = "Deduction Code"
        Me.Deduction_Code.Name = "Deduction_Code"
        Me.Deduction_Code.ReadOnly = True
        '
        'Deduction_Amount
        '
        Me.Deduction_Amount.HeaderText = "Deduction Amount (Premium)"
        Me.Deduction_Amount.Name = "Deduction_Amount"
        Me.Deduction_Amount.ReadOnly = True
        '
        'Agent_Code
        '
        Me.Agent_Code.HeaderText = "Agent Code"
        Me.Agent_Code.Name = "Agent_Code"
        Me.Agent_Code.ReadOnly = True
        '
        'Submission_Date
        '
        Me.Submission_Date.HeaderText = "Submission Date"
        Me.Submission_Date.Name = "Submission_Date"
        Me.Submission_Date.ReadOnly = True
        '
        'Effective_Date
        '
        Me.Effective_Date.HeaderText = "Effective Date"
        Me.Effective_Date.Name = "Effective_Date"
        Me.Effective_Date.ReadOnly = True
        '
        'Cancellation_Date
        '
        Me.Cancellation_Date.HeaderText = "Cancellation Date"
        Me.Cancellation_Date.Name = "Cancellation_Date"
        Me.Cancellation_Date.ReadOnly = True
        '
        'Last_Deduction_Month
        '
        Me.Last_Deduction_Month.HeaderText = "Last Deduction Month"
        Me.Last_Deduction_Month.Name = "Last_Deduction_Month"
        Me.Last_Deduction_Month.ReadOnly = True
        '
        'PHTel
        '
        Me.PHTel.HeaderText = "Mobile #"
        Me.PHTel.Name = "PHTel"
        Me.PHTel.ReadOnly = True
        '
        'Phone_HSE
        '
        Me.Phone_HSE.HeaderText = "Phone #"
        Me.Phone_HSE.Name = "Phone_HSE"
        Me.Phone_HSE.ReadOnly = True
        '
        'phone_off
        '
        Me.phone_off.HeaderText = "Office Contact #"
        Me.phone_off.Name = "phone_off"
        Me.phone_off.ReadOnly = True
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'grdReport_Premium_Not_ReceivedFrAgency_Monthly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdReport_Premium_Not_ReceivedFrAgency_Monthly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report: Premium Not Received from Deduction Agency (Monthly Cases)"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_ddlMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Angkasa_FileNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Full_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IC_New As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deduction_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deduction_Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agent_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submission_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Effective_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancellation_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Last_Deduction_Month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone_HSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents phone_off As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
