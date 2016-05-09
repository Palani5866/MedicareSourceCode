Public Class fXcessPayment
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim Amount As Double
    Private Sub fXcessPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fXcessPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA("NULL", "")
        Me.gbExcessPaymentAction.Visible = False
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt, cdt As New DataTable
        If P1 = "NULL" Then
            dt = _objBusi.getDetails("SUSPENSE", "", "", "", "", "SUSPENSE", Conn)
            cdt = _objBusi.getDetails("SUSPENSE", "", "", "", "", "CLOSED", Conn)
        Else
            dt = _objBusi.getDetails("SUSPENSE", Me.tsSuspense_cbType.Text.Trim(), Me.tstxtName.Text.ToString.Trim(), "", "", "SUSPENSE", Conn)
        End If

        If dt.Rows.Count > 0 Then
            With Me.dgvExcessPaymentDetails
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
            Me.dgvExcessPaymentDetails.DataSource = dt
        End If

        If cdt.Rows.Count > 0 Then
            With Me.dgvClosedList
                .DataSource = cdt
            End With
        Else
            Me.dgvClosedList.DataSource = cdt
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
    Private Sub dgvSuspenseDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExcessPaymentDetails.CellDoubleClick
        With Me.dgvExcessPaymentDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt As New DataTable
            dt = _objBusi.getDetails("SUSPENSE", .CurrentRow.Cells(0).Value.ToString, "", "", "", "ID", Conn)
            Me.lblID.Text = .CurrentRow.Cells(0).Value.ToString
            Amount = .CurrentRow.Cells(5).Value.ToString
            Me.gbExcessPaymentAction.Visible = True
        End With
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes, A2Take, CNO, CDT, CAMOUNT As String
        If Me.txtRemarks.Text.Trim() = "" Then
            MsgBox("Please do key in remarks!")
            Me.txtRemarks.Focus()
            Exit Sub
        End If
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
        sRes = _objBusi.UpdateSuspenseAccount(Me.lblID.Text.ToString.Trim(), A2Take, CNO, Format(Me.dtpChequeDate.Value, "MM/dd/yyyy"), CAMOUNT, My.Settings.Username, Me.txtRemarks.Text.Trim(), Conn)
        If sRes = "1" Then
            MsgBox("Successfully Submited")
            Me.txtChequeAmount.Text = ""
            Me.txtChequeNo.Text = ""
            Me.gbExcessPaymentAction.Visible = False
            Me.txtRemarks.Text = ""
            BINDDATA("NULL", "")
        Else
            MsgBox("Error while Submiting")
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtChequeAmount.Text = ""
        Me.txtChequeNo.Text = ""
        Me.gbExcessPaymentAction.Visible = False
        Me.txtRemarks.Text = ""
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
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        If Me.dgvExcessPaymentDetails.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "EXCESS PAYMENT DETAILS"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(5, 1) = "#"
                .Cells(5, 2) = "FULL NAME"
                .Cells(5, 3) = "IC"
                .Cells(5, 4) = "DEDUCTION MONTH"
                .Cells(5, 5) = "DEDUCTION CODE"
                .Cells(5, 6) = "PREMIUM"
                .Cells(5, 7) = "BATCH NO"
                .Cells(5, 8) = "RECEIVING MONTH"
                .Cells(5, 9) = "REMARKS"
                .Cells(5, 10) = "CREATED BY"
                .Cells(5, 11) = "CREATED ON"
                Dim xRCount As Integer = 6
                Dim dgvRowcount As Integer = 0
                Do While dgvRowcount < Me.dgvExcessPaymentDetails.RowCount
                    .Cells(xRCount, 1) = "'" & (xRCount - 5).ToString.Trim
                    .Cells(xRCount, 2) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(1).Value.ToString.Trim
                    .Cells(xRCount, 3) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(2).Value.ToString.Trim
                    .Cells(xRCount, 4) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(3).Value.ToString.Trim
                    .Cells(xRCount, 5) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(4).Value.ToString.Trim
                    .Cells(xRCount, 6) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(5).Value.ToString.Trim
                    .Cells(xRCount, 7) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(6).Value.ToString.Trim
                    .Cells(xRCount, 8) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(7).Value.ToString.Trim
                    .Cells(xRCount, 9) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(8).Value.ToString.Trim
                    .Cells(xRCount, 10) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(9).Value.ToString.Trim
                    .Cells(xRCount, 11) = "'" & Me.dgvExcessPaymentDetails.Rows(dgvRowcount).Cells(10).Value.ToString.Trim
                    xRCount += 1
                    dgvRowcount += 1
                Loop
            End With
        End If
        MsgBox("Exporting records to Excess Payment Details.")
        xApp.Visible = True
    End Sub
End Class