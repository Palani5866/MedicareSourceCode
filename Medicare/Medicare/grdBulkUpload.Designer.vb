<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdBulkUpload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdBulkUpload))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Save = New System.Windows.Forms.ToolStripButton
        Me.tsb_New = New System.Windows.Forms.ToolStripButton
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_BulkUpload = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Filter = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsb_Filter_Errors_Only = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Errors_Wrong_KodPotongan = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Errors_Wrong_DeductionAmount = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Errors_Member_IC = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Errors_Member_without_DeductionCode = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Success_Only = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.satForm = New System.Windows.Forms.StatusStrip
        Me.tss_Parent = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.tolForm.SuspendLayout()
        Me.satForm.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Save, Me.tsb_New, Me.OpenToolStripButton, Me.toolStripSeparator, Me.tsb_BulkUpload, Me.PrintToolStripButton, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.HelpToolStripButton, Me.toolStripSeparator1, Me.tsb_Filter})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(784, 25)
        Me.tolForm.TabIndex = 3
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_Save
        '
        Me.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Save.Image = CType(resources.GetObject("tsb_Save.Image"), System.Drawing.Image)
        Me.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Save.Name = "tsb_Save"
        Me.tsb_Save.Size = New System.Drawing.Size(23, 22)
        Me.tsb_Save.Text = "&Save"
        '
        'tsb_New
        '
        Me.tsb_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_New.Image = CType(resources.GetObject("tsb_New.Image"), System.Drawing.Image)
        Me.tsb_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_New.Name = "tsb_New"
        Me.tsb_New.Size = New System.Drawing.Size(23, 22)
        Me.tsb_New.Text = "&New"
        Me.tsb_New.Visible = False
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        Me.OpenToolStripButton.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_BulkUpload
        '
        Me.tsb_BulkUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_BulkUpload.Image = CType(resources.GetObject("tsb_BulkUpload.Image"), System.Drawing.Image)
        Me.tsb_BulkUpload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_BulkUpload.Name = "tsb_BulkUpload"
        Me.tsb_BulkUpload.Size = New System.Drawing.Size(66, 22)
        Me.tsb_BulkUpload.Text = "Bulk Upload"
        Me.tsb_BulkUpload.Visible = False
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        Me.PrintToolStripButton.Visible = False
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        Me.CutToolStripButton.Visible = False
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        Me.CopyToolStripButton.Visible = False
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        Me.PasteToolStripButton.Visible = False
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        Me.HelpToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.toolStripSeparator1.Visible = False
        '
        'tsb_Filter
        '
        Me.tsb_Filter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter_Errors_Only, Me.tsb_Filter_Success_Only})
        Me.tsb_Filter.Name = "tsb_Filter"
        Me.tsb_Filter.Size = New System.Drawing.Size(75, 22)
        Me.tsb_Filter.Text = "Filtered By:"
        Me.tsb_Filter.Visible = False
        '
        'tsb_Filter_Errors_Only
        '
        Me.tsb_Filter_Errors_Only.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter_Errors_Wrong_KodPotongan, Me.tsb_Filter_Errors_Wrong_DeductionAmount, Me.tsb_Filter_Errors_Member_IC, Me.tsb_Filter_Errors_Member_without_DeductionCode})
        Me.tsb_Filter_Errors_Only.Name = "tsb_Filter_Errors_Only"
        Me.tsb_Filter_Errors_Only.Size = New System.Drawing.Size(275, 22)
        Me.tsb_Filter_Errors_Only.Text = "Shows Only Error Records"
        '
        'tsb_Filter_Errors_Wrong_KodPotongan
        '
        Me.tsb_Filter_Errors_Wrong_KodPotongan.Name = "tsb_Filter_Errors_Wrong_KodPotongan"
        Me.tsb_Filter_Errors_Wrong_KodPotongan.Size = New System.Drawing.Size(346, 22)
        Me.tsb_Filter_Errors_Wrong_KodPotongan.Text = "Exceptional Report: Wrong Code Requested"
        '
        'tsb_Filter_Errors_Wrong_DeductionAmount
        '
        Me.tsb_Filter_Errors_Wrong_DeductionAmount.Name = "tsb_Filter_Errors_Wrong_DeductionAmount"
        Me.tsb_Filter_Errors_Wrong_DeductionAmount.Size = New System.Drawing.Size(346, 22)
        Me.tsb_Filter_Errors_Wrong_DeductionAmount.Text = "Exceptional Report: Wrong Amount Requested"
        '
        'tsb_Filter_Errors_Member_IC
        '
        Me.tsb_Filter_Errors_Member_IC.Name = "tsb_Filter_Errors_Member_IC"
        Me.tsb_Filter_Errors_Member_IC.Size = New System.Drawing.Size(346, 22)
        Me.tsb_Filter_Errors_Member_IC.Text = "Exceptional Report: Members Don't Exist in Master List"
        '
        'tsb_Filter_Errors_Member_without_DeductionCode
        '
        Me.tsb_Filter_Errors_Member_without_DeductionCode.Name = "tsb_Filter_Errors_Member_without_DeductionCode"
        Me.tsb_Filter_Errors_Member_without_DeductionCode.Size = New System.Drawing.Size(346, 22)
        Me.tsb_Filter_Errors_Member_without_DeductionCode.Text = "Exceptional Report: Member without Deduction Code"
        '
        'tsb_Filter_Success_Only
        '
        Me.tsb_Filter_Success_Only.Name = "tsb_Filter_Success_Only"
        Me.tsb_Filter_Success_Only.Size = New System.Drawing.Size(275, 22)
        Me.tsb_Filter_Success_Only.Text = "Show Only Successful Updated Records"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem1.Text = "Active Members"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem2.Text = "Suspended Members"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem3.Text = "Cancelled Members"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem4.Text = "Remove Filter (Display ALL Members)"
        '
        'satForm
        '
        Me.satForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_Parent})
        Me.satForm.Location = New System.Drawing.Point(0, 542)
        Me.satForm.Name = "satForm"
        Me.satForm.Size = New System.Drawing.Size(784, 22)
        Me.satForm.TabIndex = 5
        Me.satForm.Text = "StatusStrip1"
        '
        'tss_Parent
        '
        Me.tss_Parent.Name = "tss_Parent"
        Me.tss_Parent.Size = New System.Drawing.Size(0, 17)
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.ReadOnly = True
        Me.dgvForm.Size = New System.Drawing.Size(784, 517)
        Me.dgvForm.TabIndex = 6
        '
        'grdBulkUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.satForm)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdBulkUpload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Uploading"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.satForm.ResumeLayout(False)
        Me.satForm.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_BulkUpload As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents satForm As System.Windows.Forms.StatusStrip
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents tss_Parent As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsb_Filter_Errors_Only As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Success_Only As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Errors_Wrong_KodPotongan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Errors_Wrong_DeductionAmount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Errors_Member_IC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Errors_Member_without_DeductionCode As System.Windows.Forms.ToolStripMenuItem
End Class
