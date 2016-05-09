Public Class ShartfallsAc
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Dim Amount As Double
    Private Sub ShartfallsAc_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub ShartfallsAc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA("NULL", "")
        Me.gbShortfallsAmounts.Visible = False
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        If P1 = "NULL" Then
            dt = _objBusi.getDetails("SHORTFALLS", "", "", "", "", "SHORTFALLS", Conn)
        Else
            dt = _objBusi.getDetails("SHORTFALLS", Me.tsSuspense_cbType.Text.Trim(), Me.tstxtName.Text.ToString.Trim(), "", "", "SHORTFALLS", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvShortfallsDetails
                .DataSource = dt
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "IC"
                .Columns(4).HeaderText = "DEDUCTION MONTH"
                .Columns(5).HeaderText = "DEDUCTION CODE"
                .Columns(6).HeaderText = "REQUESTED AMOUNT"
                .Columns(7).HeaderText = "RECEIVED AMOUNT"
                .Columns(8).HeaderText = "BATCH #"
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
    Private Sub dgvSuspenseDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfallsDetails.CellDoubleClick
        With Me.dgvShortfallsDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Me.lblIC.Text = .CurrentRow.Cells(3).Value.ToString
            Me.lblNoK.Text = .CurrentRow.Cells(0).Value.ToString
            Me.lblNOKPL.Text = .CurrentRow.Cells(1).Value.ToString
            Me.lblDM.Text = .CurrentRow.Cells(4).Value.ToString
            Me.gbShortfallsAmounts.Visible = True
        End With
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes, A2Take, CNO, CDT, CAMOUNT As String
        If Me.rbClientPaidDirect.Checked Then
            A2Take = "Client Paid Direct " & "Method of Payment : " & Me.txtMethodofPay.Text.Trim() & " Reference : " & Me.txtRef.Text.Trim() & " Requested By : " & My.Settings.Username & "Requested On : " & Now() & ". "
        ElseIf Me.rbRequest2DA.Checked Then
            A2Take = "Request to Dedution Agency " & "Month From : " & Me.txtDeductionMonthFrm.Text.Trim() & " To : " & Me.txtDeductionMonthTo.Text.Trim() & " Requested Amount : " & Me.txtAmount.Text.Trim() & " Requested By : " & My.Settings.Username & "Requested On : " & Now() & ". "
        End If
        sRes = _objBusi.UpdateShortFalls(Me.lblIC.Text.ToString.Trim(), A2Take, Me.lblNoK.Text.ToString.Trim(), Me.lblNOKPL.Text.ToString.Trim(), Me.lblDM.Text.Trim(), Conn)
        If sRes = "1" Then
            MsgBox("Successfully Submited")
            Me.txtAmount.Text = ""
            Me.txtDeductionMonthFrm.Text = ""
            Me.txtDeductionMonthTo.Text = ""
            Me.txtMethodofPay.Text = ""
            Me.txtRef.Text = ""
            Me.gbShortfallsAmounts.Visible = False
            BINDDATA("NULL", "")
        Else
            MsgBox("Error while Submiting")
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtAmount.Text = ""
        Me.txtDeductionMonthFrm.Text = ""
        Me.txtDeductionMonthTo.Text = ""
        Me.txtMethodofPay.Text = ""
        Me.txtRef.Text = ""
        Me.gbShortfallsAmounts.Visible = False
    End Sub
    Private Sub tsSuspense_cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsSuspense_cbType.SelectedIndexChanged
        Me.tstxtName.Text = ""
    End Sub
    Private Sub rbRequest2DA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRequest2DA.CheckedChanged
        If Me.rbRequest2DA.Checked Then
            Me.txtAmount.Enabled = True
            Me.txtDeductionMonthFrm.Enabled = True
            Me.txtDeductionMonthTo.Enabled = True

            'Client
            Me.txtMethodofPay.Enabled = False
            Me.txtRef.Enabled = False
        Else
            Me.txtAmount.Enabled = False
            Me.txtDeductionMonthFrm.Enabled = False
            Me.txtDeductionMonthTo.Enabled = False


            Me.txtMethodofPay.Enabled = True
            Me.txtRef.Enabled = True
        End If
    End Sub
End Class