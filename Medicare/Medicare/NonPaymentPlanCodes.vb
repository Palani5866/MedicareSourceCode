Public Class NonPaymentPlanCodes
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub NonPaymentPlanCodes_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub NonPaymentPlanCodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popCB()
    End Sub
    Private Sub popCB()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("NONPAYMENT", "", "", "", "", "", Conn)
        Me.cbPlanCode.DataSource = dt
        Me.cbPlanCode.DisplayMember = "PLAN_CODE"
        Me.cbPlanCode.ValueMember = "PLAN_CODE"
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.lblREF1.Text.Trim() = "NONPAYMENT" Then
            Dim fNP As New fNonPayment
            fNP.lblREFTYPE.Text = "OTHERS"
            fNP.lblTYPE.Text = "NONPAYMENT"
            fNP.lblREF1.Text = Me.cbPlanCode.Text.Trim()
            fNP.Show()
        Else
            Dim fPD As New OtherPlanDetails
            fPD.lblREF1.Text = Me.cbPlanCode.Text.Trim()
            fPD.Show()
        End If
    End Sub
End Class