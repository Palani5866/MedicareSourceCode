<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product_type
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
        Me.gbProductDetails = New System.Windows.Forms.GroupBox
        Me.dgvProduct = New System.Windows.Forms.DataGridView
        Me.gbProduct = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtProduct = New System.Windows.Forms.TextBox
        Me.lblProduct1 = New System.Windows.Forms.Label
        Me.lblProduct = New System.Windows.Forms.Label
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lblProductID = New System.Windows.Forms.Label
        Me.gbProductDetails.SuspendLayout()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProduct.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProductDetails
        '
        Me.gbProductDetails.Controls.Add(Me.dgvProduct)
        Me.gbProductDetails.Location = New System.Drawing.Point(13, 13)
        Me.gbProductDetails.Name = "gbProductDetails"
        Me.gbProductDetails.Size = New System.Drawing.Size(728, 144)
        Me.gbProductDetails.TabIndex = 0
        Me.gbProductDetails.TabStop = False
        Me.gbProductDetails.Text = "Product Type Details"
        '
        'dgvProduct
        '
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Location = New System.Drawing.Point(23, 20)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.Size = New System.Drawing.Size(666, 105)
        Me.dgvProduct.TabIndex = 0
        '
        'gbProduct
        '
        Me.gbProduct.Controls.Add(Me.btnCancel)
        Me.gbProduct.Controls.Add(Me.btnSubmit)
        Me.gbProduct.Controls.Add(Me.lblStatus1)
        Me.gbProduct.Controls.Add(Me.cbStatus)
        Me.gbProduct.Controls.Add(Me.lblStatus)
        Me.gbProduct.Controls.Add(Me.txtProduct)
        Me.gbProduct.Controls.Add(Me.lblProduct1)
        Me.gbProduct.Controls.Add(Me.lblProduct)
        Me.gbProduct.Location = New System.Drawing.Point(13, 213)
        Me.gbProduct.Name = "gbProduct"
        Me.gbProduct.Size = New System.Drawing.Size(728, 188)
        Me.gbProduct.TabIndex = 1
        Me.gbProduct.TabStop = False
        Me.gbProduct.Text = "Add Product Type"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(363, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(249, 137)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 61
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Location = New System.Drawing.Point(226, 84)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 60
        Me.lblStatus1.Text = ":"
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(262, 81)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(265, 21)
        Me.cbStatus.TabIndex = 59
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(115, 84)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 58
        Me.lblStatus.Text = "Status"
        '
        'txtProduct
        '
        Me.txtProduct.Location = New System.Drawing.Point(262, 37)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(265, 20)
        Me.txtProduct.TabIndex = 2
        '
        'lblProduct1
        '
        Me.lblProduct1.AutoSize = True
        Me.lblProduct1.Location = New System.Drawing.Point(226, 37)
        Me.lblProduct1.Name = "lblProduct1"
        Me.lblProduct1.Size = New System.Drawing.Size(10, 13)
        Me.lblProduct1.TabIndex = 1
        Me.lblProduct1.Text = ":"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(115, 37)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(78, 13)
        Me.lblProduct.TabIndex = 0
        Me.lblProduct.Text = "Product Type *"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(195, 164)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(303, 164)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(425, 164)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblProductID
        '
        Me.lblProductID.AutoSize = True
        Me.lblProductID.Location = New System.Drawing.Point(49, 418)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(18, 13)
        Me.lblProductID.TabIndex = 5
        Me.lblProductID.Text = "ID"
        Me.lblProductID.Visible = False
        '
        'Product_type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 451)
        Me.Controls.Add(Me.lblProductID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbProduct)
        Me.Controls.Add(Me.gbProductDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Product_type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product_type"
        Me.gbProductDetails.ResumeLayout(False)
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProduct.ResumeLayout(False)
        Me.gbProduct.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbProductDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProduct As System.Windows.Forms.DataGridView
    Friend WithEvents gbProduct As System.Windows.Forms.GroupBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblProduct1 As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblProductID As System.Windows.Forms.Label
End Class
