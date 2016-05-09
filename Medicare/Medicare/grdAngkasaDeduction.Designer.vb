<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdAngkasaDeduction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdAngkasaDeduction))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_BulkUpload = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tsbConsolidate_MonthlyDeduction = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_ChangeRequest = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_ProcessMonthlyDeduction = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child = New System.Windows.Forms.ToolStripButton
        Me.tsb_Filter = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsb_Filter_New_UnComplete = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_Completed = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Filter_All = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Export2Excel_Suspend_Account = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_New = New System.Windows.Forms.ToolStripButton
        Me.tsb_Open = New System.Windows.Forms.ToolStripButton
        Me.tsb_Patch_Reprocess_KIV = New System.Windows.Forms.ToolStripButton
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ofdAngkasa_Upload = New System.Windows.Forms.OpenFileDialog
        Me.tolForm.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_BulkUpload, Me.ToolStripSeparator2, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.HelpToolStripButton, Me.tsbConsolidate_MonthlyDeduction, Me.ToolStripSeparator3, Me.tsb_ChangeRequest, Me.toolStripSeparator1, Me.tsb_ProcessMonthlyDeduction, Me.ToolStripSeparator5, Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child, Me.tsb_Filter, Me.ToolStripSeparator4, Me.tsb_Export2Excel_Suspend_Account, Me.toolStripSeparator, Me.tsb_New, Me.tsb_Open, Me.tsb_Patch_Reprocess_KIV})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(784, 25)
        Me.tolForm.TabIndex = 4
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_BulkUpload
        '
        Me.tsb_BulkUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_BulkUpload.Enabled = False
        Me.tsb_BulkUpload.Image = CType(resources.GetObject("tsb_BulkUpload.Image"), System.Drawing.Image)
        Me.tsb_BulkUpload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_BulkUpload.Name = "tsb_BulkUpload"
        Me.tsb_BulkUpload.Size = New System.Drawing.Size(66, 22)
        Me.tsb_BulkUpload.Text = "Bulk Upload"
        Me.tsb_BulkUpload.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        Me.SaveToolStripButton.Visible = False
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
        'tsbConsolidate_MonthlyDeduction
        '
        Me.tsbConsolidate_MonthlyDeduction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbConsolidate_MonthlyDeduction.Image = CType(resources.GetObject("tsbConsolidate_MonthlyDeduction.Image"), System.Drawing.Image)
        Me.tsbConsolidate_MonthlyDeduction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsolidate_MonthlyDeduction.Name = "tsbConsolidate_MonthlyDeduction"
        Me.tsbConsolidate_MonthlyDeduction.Size = New System.Drawing.Size(159, 22)
        Me.tsbConsolidate_MonthlyDeduction.Text = "Consolidate Monthly Deduction"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_ChangeRequest
        '
        Me.tsb_ChangeRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_ChangeRequest.Image = CType(resources.GetObject("tsb_ChangeRequest.Image"), System.Drawing.Image)
        Me.tsb_ChangeRequest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ChangeRequest.Name = "tsb_ChangeRequest"
        Me.tsb_ChangeRequest.Size = New System.Drawing.Size(124, 22)
        Me.tsb_ChangeRequest.Text = "Change Request (2/79)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_ProcessMonthlyDeduction
        '
        Me.tsb_ProcessMonthlyDeduction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_ProcessMonthlyDeduction.Image = CType(resources.GetObject("tsb_ProcessMonthlyDeduction.Image"), System.Drawing.Image)
        Me.tsb_ProcessMonthlyDeduction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ProcessMonthlyDeduction.Name = "tsb_ProcessMonthlyDeduction"
        Me.tsb_ProcessMonthlyDeduction.Size = New System.Drawing.Size(140, 22)
        Me.tsb_ProcessMonthlyDeduction.Text = "Process Monthly Deduction"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_Export2Excel_Angkasa_MonthlyDeduction_Child
        '
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Image = CType(resources.GetObject("tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Image"), System.Drawing.Image)
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Name = "tsb_Export2Excel_Angkasa_MonthlyDeduction_Child"
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Size = New System.Drawing.Size(189, 17)
        Me.tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Text = "Export Monthly Deduction (Delimited)"
        '
        'tsb_Filter
        '
        Me.tsb_Filter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter_New_UnComplete, Me.tsb_Filter_Completed, Me.tsb_Filter_All})
        Me.tsb_Filter.Name = "tsb_Filter"
        Me.tsb_Filter.Size = New System.Drawing.Size(75, 17)
        Me.tsb_Filter.Text = "Filtered By:"
        Me.tsb_Filter.Visible = False
        '
        'tsb_Filter_New_UnComplete
        '
        Me.tsb_Filter_New_UnComplete.Name = "tsb_Filter_New_UnComplete"
        Me.tsb_Filter_New_UnComplete.Size = New System.Drawing.Size(258, 22)
        Me.tsb_Filter_New_UnComplete.Text = "New/UnComplete Batch"
        '
        'tsb_Filter_Completed
        '
        Me.tsb_Filter_Completed.Name = "tsb_Filter_Completed"
        Me.tsb_Filter_Completed.Size = New System.Drawing.Size(258, 22)
        Me.tsb_Filter_Completed.Text = "Processed Batch (100% Completed)"
        '
        'tsb_Filter_All
        '
        Me.tsb_Filter_All.Name = "tsb_Filter_All"
        Me.tsb_Filter_All.Size = New System.Drawing.Size(258, 22)
        Me.tsb_Filter_All.Text = "Remove Filter (Display ALL Batches)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_Export2Excel_Suspend_Account
        '
        Me.tsb_Export2Excel_Suspend_Account.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Export2Excel_Suspend_Account.Enabled = False
        Me.tsb_Export2Excel_Suspend_Account.Image = CType(resources.GetObject("tsb_Export2Excel_Suspend_Account.Image"), System.Drawing.Image)
        Me.tsb_Export2Excel_Suspend_Account.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Export2Excel_Suspend_Account.Name = "tsb_Export2Excel_Suspend_Account"
        Me.tsb_Export2Excel_Suspend_Account.Size = New System.Drawing.Size(183, 17)
        Me.tsb_Export2Excel_Suspend_Account.Text = "Export Suspend Account (Delimited)"
        Me.tsb_Export2Excel_Suspend_Account.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        Me.toolStripSeparator.Visible = False
        '
        'tsb_New
        '
        Me.tsb_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_New.Enabled = False
        Me.tsb_New.Image = CType(resources.GetObject("tsb_New.Image"), System.Drawing.Image)
        Me.tsb_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_New.Name = "tsb_New"
        Me.tsb_New.Size = New System.Drawing.Size(23, 20)
        Me.tsb_New.Text = "&New"
        Me.tsb_New.Visible = False
        '
        'tsb_Open
        '
        Me.tsb_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Open.Enabled = False
        Me.tsb_Open.Image = CType(resources.GetObject("tsb_Open.Image"), System.Drawing.Image)
        Me.tsb_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Open.Name = "tsb_Open"
        Me.tsb_Open.Size = New System.Drawing.Size(23, 20)
        Me.tsb_Open.Text = "&Open"
        Me.tsb_Open.Visible = False
        '
        'tsb_Patch_Reprocess_KIV
        '
        Me.tsb_Patch_Reprocess_KIV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Patch_Reprocess_KIV.Enabled = False
        Me.tsb_Patch_Reprocess_KIV.Image = CType(resources.GetObject("tsb_Patch_Reprocess_KIV.Image"), System.Drawing.Image)
        Me.tsb_Patch_Reprocess_KIV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Patch_Reprocess_KIV.Name = "tsb_Patch_Reprocess_KIV"
        Me.tsb_Patch_Reprocess_KIV.Size = New System.Drawing.Size(163, 17)
        Me.tsb_Patch_Reprocess_KIV.Text = "Quick Fix on Monthly Reprocess"
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(784, 539)
        Me.dgvForm.TabIndex = 5
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
        'grdAngkasaDeduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdAngkasaDeduction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Angkasa Deduction List"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Open As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsb_Filter_New_UnComplete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_Completed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Filter_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_ProcessMonthlyDeduction As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_BulkUpload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ofdAngkasa_Upload As System.Windows.Forms.OpenFileDialog
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tsb_ChangeRequest As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_Export2Excel_Angkasa_MonthlyDeduction_Child As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbConsolidate_MonthlyDeduction As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Export2Excel_Suspend_Account As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_Patch_Reprocess_KIV As System.Windows.Forms.ToolStripButton
End Class
