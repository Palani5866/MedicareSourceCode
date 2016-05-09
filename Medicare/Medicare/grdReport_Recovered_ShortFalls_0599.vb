Public Class grdReport_Recovered_ShortFalls_0599
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdReport_Recovered_ShortFalls_0599_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdReport_Recovered_ShortFalls_0599_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Me.tsReport_txtDeductionMonth_From.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
        Me.tsReport_txtDeductionMonth_To.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDeductionMonth_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Month - From (yyyymm).")
            Me.tsReport_txtDeductionMonth_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDeductionMonth_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Month - To (yyyymm).")
            Me.tsReport_txtDeductionMonth_To.Focus()
            Exit Sub
        End If

        If IsNumeric(Me.tsReport_txtDeductionMonth_From.Text) = False Then
            MsgBox("Please do key in the Deduction Month - From in the right format (yyyymm).")
            Me.tsReport_txtDeductionMonth_From.Focus()
            Exit Sub
        Else
            If IsNumeric(Me.tsReport_txtDeductionMonth_To.Text) = False Then
                MsgBox("Please do key in the Deduction Month - To date in the right format (yyyymm).")
                Me.tsReport_txtDeductionMonth_To.Focus()
                Exit Sub
            Else
                If Convert.ToUInt32(Me.tsReport_txtDeductionMonth_To.Text) >= Convert.ToUInt32(Me.tsReport_txtDeductionMonth_From.Text) Then
                    Me.Populate_Grid()
                Else
                    MsgBox("Deduction Month-To is < Deduction Month-From.")
                    Me.tsReport_txtDeductionMonth_To.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub Populate_Grid()
       
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing


        Dim cmdSelect_2_79Deduction_0599 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_2_79Deduction_0599.CommandType = CommandType.Text

       

        cmdSelect_2_79Deduction_0599.CommandText = "SELECT c.IC_NEW As No_Kad_Pengenalan, b.Angkasa_FileNo, a.Angkasa_Bulan_Potongan, a.Angkasa_Jumlah_Pokok, c.FULL_NAME, " & _
                                                    "a.Angkasa_Batch_No, a.Receiving_Month  " & _
                                                    "FROM dbo.dt_Member_Policy_MonthlyDeduction a  " & _
                                                    "INNER JOIN dt_member_policy b ON a.member_policy_id=b.id  " & _
                                                    "INNER JOIN dt_member c ON b.member_id=c.id  " & _
                                                    "WHERE angkasa_kod_potongan='0599'  " & _
                                                    "AND a.Angkasa_Bulan_Potongan BETWEEN '" & Me.tsReport_txtDeductionMonth_From.Text & "' " & _
                                                    "AND '" & Me.tsReport_txtDeductionMonth_To.Text & "' " & _
                                                    "ORDER BY a.angkasa_bulan_potongan  "

        Dim da_2_79Deductions As New SqlDataAdapter(cmdSelect_2_79Deduction_0599)


        Dim ds_Report As New DataSet
        da_2_79Deductions.Fill(ds_Report, "vi_Monthly_SuspendAccount")

        With Me.dgvForm
            .DataSource = ds_Report
            .DataMember = "vi_Monthly_SuspendAccount"

            .Columns(0).HeaderText = "IC"
            .Columns(1).HeaderText = "File No"
            .Columns(2).HeaderText = "Deduction Month"
            .Columns(3).HeaderText = "Deducted Amount"
            .Columns(4).HeaderText = "Full Name"
            .Columns(5).HeaderText = "Batch No"
            .Columns(6).HeaderText = "Receiving Month"

            .Columns(3).DefaultCellStyle.Format = "#,#00.00"

            Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
            Me.ssReport_RecordCount.Visible = True
        End With
    End Sub

    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
      
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim xls_wks_name As String = ""

            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "RECOVERED SHORTFALLS (DEDUCTION CODE: 0599) REPORT"

                .Cells(3, 1) = "NO"
                .Cells(3, 2) = "IC"
                .Cells(3, 3) = "FILE NO."
                .Cells(3, 4) = "DEDUCTION MONTH"
                .Cells(3, 5) = "DEDUCTED AMOUNT"
                .Cells(3, 6) = "FULL NAME"
                .Cells(3, 7) = "DEDUCTION BATCH NO."
                .Cells(3, 8) = "RECEIVING MONTH"

                Dim xls_row_counter As Integer = 4
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvForm.RowCount
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 3).ToString.Trim
                    .Cells(xls_row_counter, 2) = "'" & Me.dgvForm.Rows(var_name_count).Cells("No_Kad_Pengenalan").Value.ToString.Trim
                    .Cells(xls_row_counter, 3) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Angkasa_FileNo").Value.ToString.Trim
                    .Cells(xls_row_counter, 4) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Angkasa_Bulan_Potongan").Value.ToString.Trim
                    .Cells(xls_row_counter, 5) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells("Angkasa_Jumlah_Pokok").Value, "#,#00.00")
                    .Cells(xls_row_counter, 6) = Me.dgvForm.Rows(var_name_count).Cells("Full_Name").Value.ToString.Trim
                    .Cells(xls_row_counter, 7) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Angkasa_Batch_No").Value.ToString.Trim
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Receiving_Month").Value.ToString.Trim

                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With

            MsgBox("Exporting records to REPORT: RECOVERED SHORTFALLS (DEDUCTION CODE: 0599) completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class