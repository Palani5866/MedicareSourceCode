<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fYrPremiumRenewal
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
        Me.lblNoofPolicies = New System.Windows.Forms.Label
        Me.lblNoofPolicies1 = New System.Windows.Forms.Label
        Me.txtNoofPolicies = New System.Windows.Forms.TextBox
        Me.txtReceivedPremium = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBrowse = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtChequeReceiptNo = New System.Windows.Forms.TextBox
        Me.lblPayment_Cheque_Receipt_No = New System.Windows.Forms.Label
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.lblPayment_Cheque_No = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblNoofPolicies
        '
        Me.lblNoofPolicies.AutoSize = True
        Me.lblNoofPolicies.Location = New System.Drawing.Point(29, 31)
        Me.lblNoofPolicies.Name = "lblNoofPolicies"
        Me.lblNoofPolicies.Size = New System.Drawing.Size(72, 13)
        Me.lblNoofPolicies.TabIndex = 0
        Me.lblNoofPolicies.Text = "No of Policies"
        '
        'lblNoofPolicies1
        '
        Me.lblNoofPolicies1.AutoSize = True
        Me.lblNoofPolicies1.Location = New System.Drawing.Point(139, 31)
        Me.lblNoofPolicies1.Name = "lblNoofPolicies1"
        Me.lblNoofPolicies1.Size = New System.Drawing.Size(10, 13)
        Me.lblNoofPolicies1.TabIndex = 1
        Me.lblNoofPolicies1.Text = ":"
        '
        'txtNoofPolicies
        '
        Me.txtNoofPolicies.Location = New System.Drawing.Point(170, 31)
        Me.txtNoofPolicies.Name = "txtNoofPolicies"
        Me.txtNoofPolicies.Size = New System.Drawing.Size(70, 20)
        Me.txtNoofPolicies.TabIndex = 2
        Me.txtNoofPolicies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivedPremium
        '
        Me.txtReceivedPremium.Location = New System.Drawing.Point(419, 28)
        Me.txtReceivedPremium.Name = "txtReceivedPremium"
        Me.txtReceivedPremium.Size = New System.Drawing.Size(81, 20)
        Me.txtReceivedPremium.TabIndex = 5
        Me.txtReceivedPremium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(398, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(286, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Received Premium"
        '
        'txtBrowse
        '
        Me.txtBrowse.Location = New System.Drawing.Point(170, 88)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(238, 20)
        Me.txtBrowse.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(139, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Select file"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(410, 86)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(60, 23)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.Text = "Browse.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(174, 125)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(60, 23)
        Me.btnSubmit.TabIndex = 10
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(249, 125)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtChequeReceiptNo
        '
        Me.txtChequeReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChequeReceiptNo.Location = New System.Drawing.Point(419, 58)
        Me.txtChequeReceiptNo.MaxLength = 10
        Me.txtChequeReceiptNo.Name = "txtChequeReceiptNo"
        Me.txtChequeReceiptNo.Size = New System.Drawing.Size(81, 20)
        Me.txtChequeReceiptNo.TabIndex = 15
        '
        'lblPayment_Cheque_Receipt_No
        '
        Me.lblPayment_Cheque_Receipt_No.AutoSize = True
        Me.lblPayment_Cheque_Receipt_No.Location = New System.Drawing.Point(348, 61)
        Me.lblPayment_Cheque_Receipt_No.Name = "lblPayment_Cheque_Receipt_No"
        Me.lblPayment_Cheque_Receipt_No.Size = New System.Drawing.Size(64, 13)
        Me.lblPayment_Cheque_Receipt_No.TabIndex = 14
        Me.lblPayment_Cheque_Receipt_No.Text = "Receipt No:"
        '
        'txtChequeNo
        '
        Me.txtChequeNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChequeNo.Location = New System.Drawing.Point(170, 58)
        Me.txtChequeNo.MaxLength = 50
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(165, 20)
        Me.txtChequeNo.TabIndex = 13
        '
        'lblPayment_Cheque_No
        '
        Me.lblPayment_Cheque_No.AutoSize = True
        Me.lblPayment_Cheque_No.Location = New System.Drawing.Point(29, 61)
        Me.lblPayment_Cheque_No.Name = "lblPayment_Cheque_No"
        Me.lblPayment_Cheque_No.Size = New System.Drawing.Size(61, 13)
        Me.lblPayment_Cheque_No.TabIndex = 12
        Me.lblPayment_Cheque_No.Text = "Cheque No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(139, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = ":"
        '
        'fYrPremiumRenewal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 187)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtChequeReceiptNo)
        Me.Controls.Add(Me.lblPayment_Cheque_Receipt_No)
        Me.Controls.Add(Me.txtChequeNo)
        Me.Controls.Add(Me.lblPayment_Cheque_No)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtBrowse)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReceivedPremium)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNoofPolicies)
        Me.Controls.Add(Me.lblNoofPolicies1)
        Me.Controls.Add(Me.lblNoofPolicies)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fYrPremiumRenewal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Policy Renewal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNoofPolicies As System.Windows.Forms.Label
    Friend WithEvents lblNoofPolicies1 As System.Windows.Forms.Label
    Friend WithEvents txtNoofPolicies As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedPremium As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBrowse As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtChequeReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_Receipt_No As System.Windows.Forms.Label
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_No As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
