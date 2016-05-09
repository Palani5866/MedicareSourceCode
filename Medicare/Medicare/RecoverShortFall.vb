Public Class RecoverShortFall
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Dim Batch_No As String = ""
    Private Sub RecoverShortFall_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub RecoverShortFall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.btnPrint.Enabled = False
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("SHORTFALL", Me.lblREFID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "RR", Conn)
        If dt.Rows.Count > 0 Then
            EnableFields(True)
        Else
            MsgBox("No Record found or server busy")
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clearup()
        Me.Close()
    End Sub
    Private Sub Clearup()
        Me.txtDeductionCode.Text = ""
        Me.txtFullName.Text = ""
        Me.txtNRIC.Text = ""
        Me.txtRemarks.Text = ""
        Me.txtRequestedAmt.Text = ""
        Me.txtRPFrm.Text = ""
        Me.txtRPTo.Text = ""
        Me.txtShortAmt.Text = ""
    End Sub
    Private Sub EnableFields(ByVal sAction As Boolean)
        Me.txtDeductionCode.Enabled = sAction
        Me.txtFullName.Enabled = sAction
        Me.txtNRIC.Enabled = sAction
        Me.txtRemarks.Enabled = sAction
        Me.txtRequestedAmt.Enabled = sAction
        Me.txtRPFrm.Enabled = sAction
        Me.txtRPTo.Enabled = sAction
        Me.txtShortAmt.Enabled = sAction
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Len(Me.txtRemarks.Text.Trim()) > 0 Then
            MsgBox("Please do key in remarks!")
            Me.txtRemarks.Focus()
            Exit Sub
        End If
        Dim TransType As String
        Dim RecoveredAmt As Double
        If Me.rbRA.Checked Then
            TransType = "DEDUCTION AGENCY"
            RecoveredAmt = Me.txtRequestedAmt.Text
        ElseIf Me.rbCP.Checked Then
            TransType = "CLIENT DIRECT PAY"
            RecoveredAmt = Me.txtRecoveredAmt.Text
        Else
            TransType = "IGNORE"
        End If
        Dim sRes As String
        sRes = _objBusi.fINShortFall("UPDATE", Me.lblREFID.Text.ToString.Trim(), TransType, Me.txtRPFrm.Text.Trim(), Me.txtRPTo.Text.Trim(), RecoveredAmt, Me.txtRemarks.Text.Trim(), My.Settings.Username.Trim(), Me.txtDCode.Text.ToString.Trim(), Me.lblBATCHNO.Text.Trim(), Me.txtPaymentRefNo.Text.Trim(), Conn)

        MsgBox("Sucessfully requested your short falls")
        Me.btnPrint.Enabled = True
        Me.btnSubmit.Enabled = False
        EnableFields(False)
        Me.Close()

    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub
    Private Sub txtRPFrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRPFrm.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            txtRPFrm.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtRPTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRPTo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            txtRPFrm.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtRequestedAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRequestedAmt.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            txtRPFrm.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub rbRA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRA.CheckedChanged
        Me.txtRequestedAmt.Enabled = True
        Me.txtPaymentRefNo.Enabled = False
        Me.txtRecoveredAmt.Enabled = False
        Me.txtRPFrm.Enabled = True
        Me.txtRPTo.Enabled = True
    End Sub
    Private Sub rbCP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCP.CheckedChanged
        If Me.rbCP.Checked Then
            Me.txtRequestedAmt.Enabled = False
            Me.txtPaymentRefNo.Enabled = True
            Me.txtRecoveredAmt.Enabled = True
            Me.txtRPFrm.Enabled = False
            Me.txtRPTo.Enabled = False
        End If
    End Sub
    Private Sub rbIgnor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIgnor.CheckedChanged
        If Me.rbIgnor.Checked Then
            Me.txtRequestedAmt.Enabled = False
            Me.txtPaymentRefNo.Enabled = False
            Me.txtRecoveredAmt.Enabled = False
            Me.txtRPFrm.Enabled = False
            Me.txtRPTo.Enabled = False
        End If
    End Sub
End Class