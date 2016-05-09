Public Class grdReport_Submission2Insurer_Yearly
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdReport_Submission2Insurer_Yearly_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdReport_Submission2Insurer_Yearly_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Me.Populate_Grid()
    End Sub

    Private Sub Populate_Grid()
       
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing


        Dim cmdSelect_Proposers As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposers.CommandType = CommandType.Text
        cmdSelect_Proposers.CommandText = "SELECT Proposal_Received_Date, Full_Name, IC_New, Premium, Level2_Plan_Code, Payment_Method, " & _
                                          "Payment_Method_CreditCard_Batch_No, Payment_Method_CreditCard_Appr_Code, " & _
                                          "Payment_Method_CreditCard_Invoice_No, Payment_Method_Cheque_No, " & _
                                          "Payment_Method_Cheque_Receipt_No, Payment_Method_Cash_Receipt_No " & _
                                          "FROM dt_Proposer " & _
                                          "WHERE Submission_Batch_No = '" & Me.ssReport_Parameter.Text.Trim & "' " & _
                                          "ORDER BY Proposal_Received_Date"
        Dim da_Selected_Proposers As New SqlDataAdapter(cmdSelect_Proposers)


        Dim ds_InsurerReport As New DataSet
        da_Selected_Proposers.Fill(ds_InsurerReport, "dt_Proposer")

        With Me.dgvForm
            .DataSource = ds_InsurerReport
            .DataMember = "dt_Proposer"

            .Columns(0).HeaderText = "Doc. Received Date"
            .Columns(1).HeaderText = "Full Name"
            .Columns(2).HeaderText = "IC"
            .Columns(3).HeaderText = "Gross Premium"
            .Columns(4).HeaderText = "Plan"
            .Columns(5).HeaderText = "Payment Method"
            .Columns(6).HeaderText = "Credit Card - Batch #"
            .Columns(7).HeaderText = "Credit Card - Approval Code"
            .Columns(8).HeaderText = "Credit Card - Invoice #"
            .Columns(9).HeaderText = "Cheque #"
            .Columns(10).HeaderText = "Cheque - Receipt #"
            .Columns(11).HeaderText = "Cash  - Receipt #"

            .Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(3).DefaultCellStyle.Format = "#,#00.00"
        End With

        Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
        Me.ssReport_RecordCount.Visible = True
    End Sub

    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
       
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim cmdSelect_Yearly_Proposers As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Yearly_Proposers.CommandType = CommandType.Text
            cmdSelect_Yearly_Proposers.CommandText = "SELECT Proposal_Received_Date, Full_Name, IC_New, (Premium + (Premium * 6 /100)) as APremium, Premium, Level2_Plan_Code, Payment_Method, " & _
                                                     "Payment_Method_CreditCard_Batch_No, Payment_Method_CreditCard_Appr_Code, " & _
                                                     "Payment_Method_CreditCard_Invoice_No, Payment_Method_Cheque_No, " & _
                                                     "Payment_Method_Cheque_Receipt_No, Payment_Method_Cash_Receipt_No " & _
                                                     "FROM dt_Proposer " & _
                                                     "WHERE Submission_Batch_No = '" & Me.ssReport_Parameter.Text.Trim & "' " & _
                                                     "ORDER BY Proposal_Received_Date"
            Dim da_Selected_Yearly_Proposers As New SqlDataAdapter(cmdSelect_Yearly_Proposers)


            Dim ds_InsurerReport2xls As New DataSet
            da_Selected_Yearly_Proposers.Fill(ds_InsurerReport2xls, "dt_Proposer")

            Dim xls_wks_name As String = ""


            Dim var_Proposal_Cash As DataRow() = ds_InsurerReport2xls.Tables("dt_Proposer").Select("Payment_Method = 'Cash'")

            If var_Proposal_Cash.Length > 0 Then
                MsgBox("Cash: " & var_Proposal_Cash.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)
                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: SUNLIFE MALAYSIA TAKAFUL BERHAD"
                    .Cells(2, 1) = "CUEPACSCARE NEW CASES. BATCH NO: " & Me.ssReport_Parameter.Text.Trim
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CASH"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "PREMIUM"
                    .Cells(6, 7) = "GST 6%"
                    .Cells(6, 8) = "GROSS PREMIUM WITH GST"
                    .Cells(6, 9) = "PLAN"
                    .Cells(6, 10) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 11) = "POLICY EXPIRY DATE"
                    .Cells(6, 12) = "MEDICARE'S RECEIPT NO."
                    .Cells(6, 13) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_Proposal_Cash.Length
                        Dim var_Effective_Day As Integer = Convert.ToDateTime(var_Proposal_Cash(var_name_count).Item("Proposal_Received_Date")).Day
                        Dim var_Effective_Month As Integer = Convert.ToDateTime(var_Proposal_Cash(var_name_count).Item("Proposal_Received_Date")).Month
                        Dim var_Effective_Year As Integer = Convert.ToDateTime(var_Proposal_Cash(var_name_count).Item("Proposal_Received_Date")).Year

                        If (var_Effective_Day + 14) > 15 Then
                            If (var_Effective_Day + 14) > 30 Then
                                var_Effective_Day = 15
                            Else
                                var_Effective_Day = 1
                            End If

                            If (var_Effective_Month + 1) > 12 Then
                                var_Effective_Year += 1
                                var_Effective_Month = 1
                            Else
                                var_Effective_Month += 1
                            End If
                        Else
                            var_Effective_Day = 15
                        End If
                        If Len(var_Effective_Month) = 1 Then
                            var_Effective_Month = "0" + var_Effective_Month
                        End If

                        Dim var_Effective_Date As Date = var_Effective_Day.ToString & "/" & var_Effective_Month.ToString & "/" & var_Effective_Year.ToString
                        Dim var_Expiry_Date As Date = var_Effective_Date.AddDays(364)
                       

                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_Proposal_Cash(var_name_count).Item("Proposal_Received_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "NEW CASES"
                        .Cells(xls_row_counter, 4) = var_Proposal_Cash(var_name_count).Item("Full_Name").ToString
                        .Cells(xls_row_counter, 5) = "'" & var_Proposal_Cash(var_name_count).Item("IC_New").ToString
                        .Cells(xls_row_counter, 6) = "'" & Format(var_Proposal_Cash(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & Format(var_Proposal_Cash(var_name_count).Item("Premium") * 6 / 100, "#,#0.00")
                        .Cells(xls_row_counter, 8) = "'" & Format(var_Proposal_Cash(var_name_count).Item("APremium"), "#,#00.00")
                        .Cells(xls_row_counter, 9) = "'" & var_Proposal_Cash(var_name_count).Item("Level2_Plan_Code").ToString
                        .Cells(xls_row_counter, 10) = "'" & Format(var_Effective_Date, "dd/MM/yyyy")

                        .Cells(xls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, -1, Convert.ToDateTime(var_Effective_Date).AddYears(1))
                        .Cells(xls_row_counter, 12) = "'" & var_Proposal_Cash(var_name_count).Item("Payment_Method_Cash_Receipt_No").ToString
                        xls_row_counter += 1
                        var_name_count += 1
                    Loop

                    .Cells(xls_row_counter + 2, 2) = "PREPARED BY"
                    .Cells(xls_row_counter + 5, 2) = "------------------------"
                    .Cells(xls_row_counter + 6, 2) = "Name : " & My.Settings.Username.ToUpper.Trim()
                    .Cells(xls_row_counter + 7, 2) = "Date : " & Format(Now(), "dd/MM/yyyy")
                    .Cells(xls_row_counter + 2, 9) = "RECEIVED BY"
                    .Cells(xls_row_counter + 5, 9) = "------------------------"
                    .Cells(xls_row_counter + 6, 9) = "Name : "
                    .Cells(xls_row_counter + 7, 9) = "Date : "
                End With
            End If


            Dim var_Proposal_Cheque As DataRow() = ds_InsurerReport2xls.Tables("dt_Proposer").Select("Payment_Method = 'Cheque'")

            If var_Proposal_Cheque.Length > 0 Then
                MsgBox("Cheque: " & var_Proposal_Cheque.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)
                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: SUNLIFE MALAYSIA TAKAFUL BERHAD"
                    .Cells(2, 1) = "CUEPACSCARE NEW CASES. BATCH NO: " & Me.ssReport_Parameter.Text.Trim
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CHEQUE"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "PREMIUM"
                    .Cells(6, 7) = "GST 6%"
                    .Cells(6, 8) = "GROSS PREMIUM WITH GST"
                    .Cells(6, 9) = "PLAN"
                    .Cells(6, 10) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 11) = "POLICY EXPIRY DATE"
                    .Cells(6, 12) = "CHEQUE NO."
                    .Cells(6, 13) = "MEDICARE'S RECEIPT NO."
                    .Cells(6, 14) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_Proposal_Cheque.Length
                        Dim var_Effective_Day As Integer = Convert.ToDateTime(var_Proposal_Cheque(var_name_count).Item("Proposal_Received_Date")).Day
                        Dim var_Effective_Month As Integer = Convert.ToDateTime(var_Proposal_Cheque(var_name_count).Item("Proposal_Received_Date")).Month
                        Dim var_Effective_Year As Integer = Convert.ToDateTime(var_Proposal_Cheque(var_name_count).Item("Proposal_Received_Date")).Year

                        If (var_Effective_Day + 14) > 15 Then
                            If (var_Effective_Day + 14) > 30 Then
                                var_Effective_Day = 15
                            Else
                                var_Effective_Day = 1
                            End If

                            If (var_Effective_Month + 1) > 12 Then
                                var_Effective_Year += 1
                                var_Effective_Month = 1
                            Else
                                var_Effective_Month += 1
                            End If
                        Else
                            var_Effective_Day = 15
                        End If
                        If Len(var_Effective_Month) = 1 Then
                            var_Effective_Month = "0" + var_Effective_Month
                        End If

                        Dim var_Effective_Date As Date = var_Effective_Day.ToString & "/" & var_Effective_Month.ToString & "/" & var_Effective_Year.ToString
                        Dim var_Expiry_Date As Date = var_Effective_Date.AddDays(364)

                        
                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_Proposal_Cheque(var_name_count).Item("Proposal_Received_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "NEW CASES"
                        .Cells(xls_row_counter, 4) = var_Proposal_Cheque(var_name_count).Item("Full_Name").ToString
                        .Cells(xls_row_counter, 5) = "'" & var_Proposal_Cheque(var_name_count).Item("IC_New").ToString
                        .Cells(xls_row_counter, 6) = "'" & Format(var_Proposal_Cheque(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & Format(var_Proposal_Cheque(var_name_count).Item("Premium") * 6 / 100, "#,#0.00")
                        .Cells(xls_row_counter, 8) = "'" & Format(var_Proposal_Cheque(var_name_count).Item("APremium"), "#,#00.00")
                        .Cells(xls_row_counter, 9) = "'" & var_Proposal_Cheque(var_name_count).Item("Level2_Plan_Code").ToString
                        .Cells(xls_row_counter, 10) = "'" & Format(var_Effective_Date, "dd/MM/yyyy")

                        .Cells(xls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, -1, Convert.ToDateTime(var_Effective_Date).AddYears(1))
                        .Cells(xls_row_counter, 12) = "'" & var_Proposal_Cheque(var_name_count).Item("Payment_Method_Cheque_No").ToString
                        .Cells(xls_row_counter, 13) = "'" & var_Proposal_Cheque(var_name_count).Item("Payment_Method_Cheque_Receipt_No").ToString

                        xls_row_counter += 1
                        var_name_count += 1
                    Loop
                    .Cells(xls_row_counter + 2, 2) = "PREPARED BY"
                    .Cells(xls_row_counter + 5, 2) = "------------------------"
                    .Cells(xls_row_counter + 6, 2) = "Name : " & My.Settings.Username.ToUpper.Trim()
                    .Cells(xls_row_counter + 7, 2) = "Date : " & Format(Now(), "dd/MM/yyyy")
                    .Cells(xls_row_counter + 2, 9) = "RECEIVED BY"
                    .Cells(xls_row_counter + 5, 9) = "------------------------"
                    .Cells(xls_row_counter + 6, 9) = "Name : "
                    .Cells(xls_row_counter + 7, 9) = "Date : "
                End With

            End If


            Dim var_Proposal_Credit_Card As DataRow() = ds_InsurerReport2xls.Tables("dt_Proposer").Select("Payment_Method = 'Credit Card'")

            If var_Proposal_Credit_Card.Length > 0 Then
                MsgBox("Credit Card: " & var_Proposal_Credit_Card.Length.ToString)
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                With xls_workbook.Worksheets(xls_wks_name)
                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: SUNLIFE MALAYSIA TAKAFUL BERHAD"
                    .Cells(2, 1) = "CUEPACSCARE NEW CASES. BATCH NO: " & Me.ssReport_Parameter.Text.Trim
                    .Cells(3, 1) = "A/C CODE: GI2073"
                    .Cells(4, 1) = "PAYMENT BY CREDIT CARD"

                    .Cells(6, 1) = "NO"
                    .Cells(6, 2) = "DOC. REC. DATE"
                    .Cells(6, 3) = "POLICY NO."
                    .Cells(6, 4) = "FULL NAME"
                    .Cells(6, 5) = "IC"
                    .Cells(6, 6) = "PREMIUM"
                    .Cells(6, 7) = "GST 6%"
                    .Cells(6, 8) = "GROSS PREMIUM WITH GST"
                    .Cells(6, 9) = "PLAN"
                    .Cells(6, 10) = "POLICY EFFECTIVE DATE"
                    .Cells(6, 11) = "POLICY EXPIRY DATE"
                    .Cells(6, 12) = "BATCH NO."
                    .Cells(6, 13) = "APPROVAL CODE"
                    .Cells(6, 14) = "INVOICE NO."
                    .Cells(6, 15) = "REMARK"

                    Dim xls_row_counter As Integer = 7
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < var_Proposal_Credit_Card.Length
                        Dim var_Effective_Day As Integer = Convert.ToDateTime(var_Proposal_Credit_Card(var_name_count).Item("Proposal_Received_Date")).Day
                        Dim var_Effective_Month As Integer = Convert.ToDateTime(var_Proposal_Credit_Card(var_name_count).Item("Proposal_Received_Date")).Month
                        Dim var_Effective_Year As Integer = Convert.ToDateTime(var_Proposal_Credit_Card(var_name_count).Item("Proposal_Received_Date")).Year

                        If (var_Effective_Day + 14) > 15 Then
                            If (var_Effective_Day + 14) > 30 Then
                                var_Effective_Day = 15
                            Else
                                var_Effective_Day = 1
                            End If

                            If (var_Effective_Month + 1) > 12 Then
                                var_Effective_Year += 1
                                var_Effective_Month = 1
                            Else
                                var_Effective_Month += 1
                            End If
                        Else
                            var_Effective_Day = 15
                        End If
                        If Len(var_Effective_Month) = 1 Then
                            var_Effective_Month = "0" + var_Effective_Month
                        End If

                        Dim var_Effective_Date As Date = var_Effective_Day.ToString & "/" & var_Effective_Month.ToString & "/" & var_Effective_Year.ToString
                        Dim var_Expiry_Date As Date = var_Effective_Date.AddDays(364)

                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 6).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & Format(var_Proposal_Credit_Card(var_name_count).Item("Proposal_Received_Date"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 3) = "NEW CASES"
                        .Cells(xls_row_counter, 4) = var_Proposal_Credit_Card(var_name_count).Item("Full_Name").ToString
                        .Cells(xls_row_counter, 5) = "'" & var_Proposal_Credit_Card(var_name_count).Item("IC_New").ToString
                        .Cells(xls_row_counter, 6) = "'" & Format(var_Proposal_Credit_Card(var_name_count).Item("Premium"), "#,#00.00")
                        .Cells(xls_row_counter, 7) = "'" & Format(var_Proposal_Credit_Card(var_name_count).Item("Premium") * 6 / 100, "#,#0.00")
                        .Cells(xls_row_counter, 8) = "'" & Format(var_Proposal_Credit_Card(var_name_count).Item("APremium"), "#,#00.00")
                        .Cells(xls_row_counter, 9) = "'" & var_Proposal_Credit_Card(var_name_count).Item("Level2_Plan_Code").ToString
                        .Cells(xls_row_counter, 10) = "'" & Format(var_Effective_Date, "dd/MM/yyyy")

                        .Cells(xls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, -1, Convert.ToDateTime(var_Effective_Date).AddYears(1))
                        .Cells(xls_row_counter, 12) = "'" & var_Proposal_Credit_Card(var_name_count).Item("Payment_Method_CreditCard_Batch_No").ToString
                        .Cells(xls_row_counter, 13) = "'" & var_Proposal_Credit_Card(var_name_count).Item("Payment_Method_CreditCard_Appr_Code").ToString
                        .Cells(xls_row_counter, 14) = "'" & var_Proposal_Credit_Card(var_name_count).Item("Payment_Method_CreditCard_Invoice_No").ToString

                        xls_row_counter += 1
                        var_name_count += 1
                    Loop

                    .Cells(xls_row_counter + 2, 2) = "PREPARED BY"
                    .Cells(xls_row_counter + 5, 2) = "------------------------"
                    .Cells(xls_row_counter + 6, 2) = "Name : " & My.Settings.Username.ToUpper.Trim()
                    .Cells(xls_row_counter + 7, 2) = "Date : " & Format(Now(), "dd/MM/yyyy")
                    .Cells(xls_row_counter + 2, 9) = "RECEIVED BY"
                    .Cells(xls_row_counter + 5, 9) = "------------------------"
                    .Cells(xls_row_counter + 6, 9) = "Name : "
                    .Cells(xls_row_counter + 7, 9) = "Date : "
                End With
            End If

            MsgBox("Exporting records to PREMIUM PAYMENT STATEMENT TO INSURER completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class