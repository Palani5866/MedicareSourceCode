<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UMD
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
        Me.lblUMDType = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.lblSelectFile = New System.Windows.Forms.Label
        Me.gbUpload = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblSelectFile1 = New System.Windows.Forms.Label
        Me.gbUpload.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUMDType
        '
        Me.lblUMDType.AutoSize = True
        Me.lblUMDType.Location = New System.Drawing.Point(371, 251)
        Me.lblUMDType.Name = "lblUMDType"
        Me.lblUMDType.Size = New System.Drawing.Size(60, 13)
        Me.lblUMDType.TabIndex = 0
        Me.lblUMDType.Text = "UMDTYPE"
        Me.lblUMDType.Visible = False
        '
        'lblSelectFile
        '
        Me.lblSelectFile.AutoSize = True
        Me.lblSelectFile.Location = New System.Drawing.Point(15, 43)
        Me.lblSelectFile.Name = "lblSelectFile"
        Me.lblSelectFile.Size = New System.Drawing.Size(56, 13)
        Me.lblSelectFile.TabIndex = 1
        Me.lblSelectFile.Text = "Select File"
        '
        'gbUpload
        '
        Me.gbUpload.Controls.Add(Me.btnCancel)
        Me.gbUpload.Controls.Add(Me.btnUpload)
        Me.gbUpload.Controls.Add(Me.btnBrowse)
        Me.gbUpload.Controls.Add(Me.txtFileName)
        Me.gbUpload.Controls.Add(Me.lblSelectFile1)
        Me.gbUpload.Controls.Add(Me.lblSelectFile)
        Me.gbUpload.Location = New System.Drawing.Point(12, 12)
        Me.gbUpload.Name = "gbUpload"
        Me.gbUpload.Size = New System.Drawing.Size(480, 131)
        Me.gbUpload.TabIndex = 2
        Me.gbUpload.TabStop = False
        Me.gbUpload.Text = "Upload File"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(230, 89)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(126, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(109, 89)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(115, 23)
        Me.btnUpload.TabIndex = 16
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(344, 40)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(53, 20)
        Me.btnBrowse.TabIndex = 13
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtFileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFileName.Location = New System.Drawing.Point(109, 40)
        Me.txtFileName.MaxLength = 10
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(229, 20)
        Me.txtFileName.TabIndex = 10
        Me.txtFileName.TabStop = False
        '
        'lblSelectFile1
        '
        Me.lblSelectFile1.AutoSize = True
        Me.lblSelectFile1.Location = New System.Drawing.Point(93, 43)
        Me.lblSelectFile1.Name = "lblSelectFile1"
        Me.lblSelectFile1.Size = New System.Drawing.Size(10, 13)
        Me.lblSelectFile1.TabIndex = 2
        Me.lblSelectFile1.Text = ":"
        '
        'UMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 164)
        Me.Controls.Add(Me.gbUpload)
        Me.Controls.Add(Me.lblUMDType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UMD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Monthly Deduction"
        Me.gbUpload.ResumeLayout(False)
        Me.gbUpload.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUMDType As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblSelectFile As System.Windows.Forms.Label
    Friend WithEvents gbUpload As System.Windows.Forms.GroupBox
    Friend WithEvents lblSelectFile1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
End Class
