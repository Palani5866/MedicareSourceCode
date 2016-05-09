Public Class grdReport_Submission2Insurer_Yearly_Renewal
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdReport_Submission2Insurer_Yearly_Renewal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdReport_Submission2Insurer_Yearly_Renewal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal From date (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal To date (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Renewal From date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Renewal To date in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    Me.Populate_Grid()
                Else
                    MsgBox("Renewal To date is < Renewal From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub

    Private Sub Populate_Grid()
        
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing

        Dim var_Renew_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Renew_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Renew_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Renewal_Date_From As String = var_Renew_From_Month & "/" & var_Renew_From_Day & "/" & var_Renew_From_Year

        Dim var_Renew_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Renew_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Renew_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Renewal_Date_To As String = var_Renew_To_Month & "/" & var_Renew_To_Day & "/" & var_Renew_To_Year


        Dim cmdSelected_PolicyHolders As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelected_PolicyHolders.CommandType = CommandType.Text
        cmdSelected_PolicyHolders.CommandText = "SELECT Log_Date, Request_Date, Policy_No, Full_Name, IC_New, Premium, Level2_Plan_Code, " & _
                                                "Payment_Method, Effective_Date, CC_Batch_No, CC_Appr_Code, CC_Invoice_No, " & _
                                                "Cheque_No, Cheque_Receipt_No, Cash_Receipt_No, Cash_Receipt_IssuedBy " & _
                                                "FROM vi_Member_Policy_YearlyRenewal " & _
                                                "WHERE Deduction_Code LIKE 'Y%' " & _
                                                "AND CANCELLATION_DATE BETWEEN '" & var_Renewal_Date_From & "' " & _
                                                "AND '" & var_Renewal_Date_To & "' " & _
                                                "ORDER BY CANCELLATION_DATE DESC"
        Dim da_PolicyHolders As New SqlDataAdapter(cmdSelected_PolicyHolders)


        Dim ds_InsurerReport As New DataSet
        da_PolicyHolders.Fill(ds_InsurerReport, "vi_Member_Policy_YearlyRenewal")

        With Me.dgvForm
            .DataSource = ds_InsurerReport
            .DataMember = "vi_Member_Policy_YearlyRenewal"

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "Doc. Received Date"
            .Columns(2).HeaderText = "Policy #"
            .Columns(3).HeaderText = "Full Name"
            .Columns(4).HeaderText = "IC"
            .Columns(5).HeaderText = "Gross Premium"
            .Columns(6).HeaderText = "Plan"
            .Columns(7).HeaderText = "Payment Method"
            .Columns(8).HeaderText = "Effective Date"
            .Columns(9).HeaderText = "Credit Card - Batch #"
            .Columns(10).HeaderText = "Credit Card - Approval Code"
            .Columns(11).HeaderText = "Credit Card - Invoice #"
            .Columns(12).HeaderText = "Cheque #"
            .Columns(13).HeaderText = "Cheque - Receipt #"
            .Columns(14).HeaderText = "Cash  - Receipt #"

            .Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(5).DefaultCellStyle.Format = "#,#00.00"

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

            Dim var_Renew_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
            Dim var_Renew_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
            Dim var_Renew_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
            Dim var_Renewal_Date_From As String = var_Renew_From_Month & "/" & var_Renew_From_Day & "/" & var_Renew_From_Year

            Dim var_Renew_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
            Dim var_Renew_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
            Dim var_Renew_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
            Dim var_Renewal_Date_To As String = var_Renew_To_Month & "/" & var_Renew_To_Day & "/" & var_Renew_To_Year


            Dim cmdSelected_PolicyHolders_YearlyRenewal As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelected_PolicyHolders_YearlyRenewal.CommandType = CommandType.Text
            cmdSelected_PolicyHolders_YearlyRenewal.CommandText = "SELECT Log_Date, Request_Date, Policy_No, Full_Name, IC_New, Premium, Level2_Plan_Code, " & _
                                                                  "Payment_Method, Effective_Date, Cancellation_Date, CC_Batch_No, CC_Appr_Code, CC_Invoice_No, " & _
                                                                  "Cheque_No, Cheque_Receipt_No, Cash_Receipt_No, Cash_Receipt_IssuedBy " & _
                                                                  "FROM vi_Member_Policy_YearlyRenewal " & _
                                                                  "WHERE Deduction_Code LIKE 'Y%' " & _
                                                                  "AND CANCELLATION_DATE BETWEEN '" & var_Renewal_Date_From & "' " & _
                                                                  "AND '" & var_Renewal_Date_To & "' " & _
                                                                  "ORDER BY CANCELLATION_DATE DESC"
            Dim da_PolicyHolders As New SqlDataAdapter(cmdSelected_PolicyHolders_YearlyRenewal)


            Dim ds_InsurerReport2xls As New DataSet
            da_PolicyHolders.Fill(ds_InsurerReport2xls, "vi_Member_Policy_YearlyRenewal")

            Dim xls_wks_name As String = ""


            Dim var_YearlyRenewal_Cash As DataRow() = ds_InsurerReport2xls.Tables("vi_Member_Policy_YearlyRenewal").Select("Payment_Method = 'Cash'")

            If var_YearlyRenewal_Cash.Length > 0 Then
                MsgBox("Cash: " & var_YearlyRenewal_Cash.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)

                    .Cells(1, 1) = "TOTAL OF YEARLY RENEWAL PROPOSALS"
                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: " '& Me.ssReport_Parameter.Text.Trim
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CASH"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "GROSS PREMIUM"
                    .Cells(6, 7) = "PLAN"
                    .Cells(6, 8) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 9) = "POLICY EXPIRY DATE"
                    .Cells(6, 10) = "MEDICARE'S RECEIPT NO."
                    .Cells(6, 11) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_YearlyRenewal_Cash.Length
                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_YearlyRenewal_Cash(var_name_count).Item("Request_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "'" & var_YearlyRenewal_Cash(var_name_count).Item("Policy_No").ToString.Trim
                        .Cells(xls_row_counter, 4) = var_YearlyRenewal_Cash(var_name_count).Item("Full_Name").ToString.Trim
                        .Cells(xls_row_counter, 5) = "'" & var_YearlyRenewal_Cash(var_name_count).Item("IC_New").ToString.Trim
                        .Cells(xls_row_counter, 6) = "'" & Format(var_YearlyRenewal_Cash(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & var_YearlyRenewal_Cash(var_name_count).Item("Level2_Plan_Code").ToString.Trim
                        .Cells(xls_row_counter, 8) = "'" & Format(var_YearlyRenewal_Cash(var_name_count).Item("Effective_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 9) = "'" & Format(var_YearlyRenewal_Cash(var_name_count).Item("Cancellation_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 10) = "'" & var_YearlyRenewal_Cash(var_name_count).Item("Cash_Receipt_No").ToString.Trim

                        xls_row_counter += 1
                        var_name_count += 1
                    Loop
                End With
            End If


            Dim var_YearlyRenewal_Cheque As DataRow() = ds_InsurerReport2xls.Tables("vi_Member_Policy_YearlyRenewal").Select("Payment_Method = 'Cheque'")

            If var_YearlyRenewal_Cheque.Length > 0 Then
                MsgBox("Cheque: " & var_YearlyRenewal_Cheque.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)

                    .Cells(1, 1) = "TOTAL OF YEARLY RENEWAL PROPOSALS"
                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: "
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CHEQUE"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "GROSS PREMIUM"
                    .Cells(6, 7) = "PLAN"
                    .Cells(6, 8) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 9) = "POLICY EXPIRY DATE"
                    .Cells(6, 10) = "CHEQUE NO."
                    .Cells(6, 11) = "MEDICARE'S RECEIPT NO."
                    .Cells(6, 12) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_YearlyRenewal_Cheque.Length
                        Dim var_Expiry_Date As Date = Convert.ToDateTime(var_YearlyRenewal_Cheque(var_name_count).Item("Effective_Date")).AddDays(364)

                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_YearlyRenewal_Cheque(var_name_count).Item("Request_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "'" & var_YearlyRenewal_Cheque(var_name_count).Item("Policy_No").ToString.Trim
                        .Cells(xls_row_counter, 4) = var_YearlyRenewal_Cheque(var_name_count).Item("Full_Name").ToString.Trim
                        .Cells(xls_row_counter, 5) = "'" & var_YearlyRenewal_Cheque(var_name_count).Item("IC_New").ToString.Trim
                        .Cells(xls_row_counter, 6) = "'" & Format(var_YearlyRenewal_Cheque(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & var_YearlyRenewal_Cheque(var_name_count).Item("Level2_Plan_Code").ToString.Trim
                        .Cells(xls_row_counter, 8) = "'" & Format(var_YearlyRenewal_Cheque(var_name_count).Item("Effective_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 9) = "'" & Format(var_YearlyRenewal_Cheque(var_name_count).Item("Cancellation_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 10) = "'" & var_YearlyRenewal_Cheque(var_name_count).Item("Cheque_No").ToString.Trim
                        .Cells(xls_row_counter, 11) = "'" & var_YearlyRenewal_Cheque(var_name_count).Item("Cheque_Receipt_No").ToString.Trim

                        xls_row_counter += 1
                        var_name_count += 1
                    Loop
                End With
            End If


            Dim var_YearlyRenewal_Credit_Card As DataRow() = ds_InsurerReport2xls.Tables("vi_Member_Policy_YearlyRenewal").Select("Payment_Method = 'Credit Card'")

            If var_YearlyRenewal_Credit_Card.Length > 0 Then
                MsgBox("Credit Card: " & var_YearlyRenewal_Credit_Card.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)

                    .Cells(1, 1) = "TOTAL OF YEARLY RENEWAL PROPOSALS"
                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: "
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CREDIT CARD"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "GROSS PREMIUM"
                    .Cells(6, 7) = "PLAN"
                    .Cells(6, 8) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 9) = "POLICY EXPIRY DATE"
                    .Cells(6, 10) = "BATCH NO."
                    .Cells(6, 11) = "APPROVAL CODE"
                    .Cells(6, 12) = "INVOICE NO."
                    .Cells(6, 13) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_YearlyRenewal_Credit_Card.Length
                        Dim var_Expiry_Date As Date = Convert.ToDateTime(var_YearlyRenewal_Credit_Card(var_name_count).Item("Effective_Date")).AddDays(364)

                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_YearlyRenewal_Credit_Card(var_name_count).Item("Request_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("Policy_No").ToString.Trim
                        .Cells(xls_row_counter, 4) = var_YearlyRenewal_Credit_Card(var_name_count).Item("Full_Name").ToString.Trim
                        .Cells(xls_row_counter, 5) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("IC_New").ToString.Trim
                        .Cells(xls_row_counter, 6) = "'" & Format(var_YearlyRenewal_Credit_Card(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("Level2_Plan_Code").ToString.Trim
                        .Cells(xls_row_counter, 8) = "'" & Format(var_YearlyRenewal_Credit_Card(var_name_count).Item("Effective_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 9) = "'" & Format(var_YearlyRenewal_Credit_Card(var_name_count).Item("Cancellation_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 10) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("CC_Batch_No").ToString.Trim
                        .Cells(xls_row_counter, 11) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("CC_Appr_Code").ToString.Trim
                        .Cells(xls_row_counter, 12) = "'" & var_YearlyRenewal_Credit_Card(var_name_count).Item("CC_Invoice_No").ToString.Trim

                        xls_row_counter += 1
                        var_name_count += 1
                    Loop
                End With
            End If
            MsgBox("Exporting records to PREMIUM PAYMENT STATEMENT TO INSURER completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class