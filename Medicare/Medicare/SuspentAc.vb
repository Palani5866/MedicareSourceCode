Public Class SuspentAc
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Dim Amount As Double
    Private Sub SuspentAc_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub SuspentAc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA("NULL", "")
        Me.gbSuspentAmounts.Visible = False
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        If P1 = "NULL" Then
            dt = _objBusi.getDetails("SUSPENSE", "", "", "", "", "SUSPENSE", Conn)
        Else
            dt = _objBusi.getDetails("SUSPENSE", Me.tsSuspense_cbType.Text.Trim(), Me.tstxtName.Text.ToString.Trim(), "", "", "SUSPENSE", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvSuspenseDetails
                .DataSource = dt
                .Columns(0).Visible = False 'ID
                .Columns(1).HeaderText = "FULL NAME"
                .Columns(2).HeaderText = "IC"
                .Columns(3).HeaderText = "DEDUCTION MONTH"
                .Columns(4).HeaderText = "DEDUCTION CODE"
                .Columns(5).HeaderText = "DEDUCTION AMOUNT"
                .Columns(6).HeaderText = "BATCH #"
                .Columns(7).HeaderText = "RECEIVING MONTH"
                .Columns(8).HeaderText = "REMARKS"
                .Columns(9).HeaderText = "CREATED BY"
                .Columns(10).HeaderText = "CREATED ON"
                .ReadOnly = True
            End With
        Else
            MsgBox("No Record found")
        End If
    End Sub
    Private Sub tsSuspense_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSuspense_Go.Click
        If Not Me.tsSuspense_cbType.SelectedIndex = 0 Then
            If Me.tstxtName.Text.ToString.Trim = "" Then
                MsgBox("Please key In IC/Full Name")
                Me.tstxtName.Focus()
                Exit Sub
            End If
            BINDDATA(Me.tsSuspense_cbType.Text.Trim(), Me.tstxtName.Text.ToString.Trim())
        Else
            MsgBox("Please select the creteria")
        End If
    End Sub
    Private Sub dgvSuspenseDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSuspenseDetails.CellDoubleClick
        With Me.dgvSuspenseDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt As New DataTable
            dt = _objBusi.getDetails("SUSPENSE", .CurrentRow.Cells(0).Value.ToString, "", "", "", "ID", Conn)
            Me.lblID.Text = .CurrentRow.Cells(0).Value.ToString
            Amount = .CurrentRow.Cells(5).Value.ToString
            Me.gbSuspentAmounts.Visible = True
        End With
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes, A2Take, CNO, CDT, CAMOUNT As String
        If Me.rbA2TClient.Checked Then
            A2Take = "Client Cannot be Contacted"
        ElseIf Me.rbA2T2Knockoff.Checked Then
            A2Take = "Knockoff"
        ElseIf Me.rbA2T2Refound.Checked Then
            A2Take = "To Refund"
        End If
        If Me.txtChequeNo.Text.Trim = "" Then
            CNO = ""
        Else
            CNO = Me.txtChequeNo.Text.Trim()
        End If
        If Me.txtChequeAmount.Text.Trim() = "" Then
            CAMOUNT = "0"
        Else
            CAMOUNT = Me.txtChequeAmount.Text.Trim()
        End If
        sRes = _objBusi.UpdateSuspenseAccount(Me.lblID.Text.ToString.Trim(), A2Take, CNO, Me.dtpChequeDate.Value, CAMOUNT, My.Settings.Username, "", Conn)
        If sRes = "1" Then
            MsgBox("Successfully Submited")
            Me.txtChequeAmount.Text = ""
            Me.txtChequeNo.Text = ""
            Me.gbSuspentAmounts.Visible = False
            BINDDATA("NULL", "")
        Else
            MsgBox("Error while Submiting")
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtChequeAmount.Text = ""
        Me.txtChequeNo.Text = ""
        Me.gbSuspentAmounts.Visible = False
    End Sub
    Private Sub tsSuspense_cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsSuspense_cbType.SelectedIndexChanged
        Me.tstxtName.Text = ""
    End Sub
    Private Sub rbA2T2Refound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbA2T2Refound.CheckedChanged
        If Me.rbA2T2Refound.Checked Then
            Me.txtChequeAmount.Enabled = True
            Me.txtChequeNo.Enabled = True
            Me.dtpChequeDate.Enabled = True
        Else
            Me.txtChequeAmount.Enabled = False
            Me.txtChequeNo.Enabled = False
            Me.dtpChequeDate.Enabled = False
        End If
    End Sub
End Class