Public Class Renewal_Yr_Submission
  
    Dim Conn As DbConnection = New SqlConnection
    Dim BatchNo As String = ""
    Dim _objBusi As New Business
    Private Sub Renewal_Yr_Submission_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Renewal_Yr_Submission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    Me.PopGrids()
                Else
                    MsgBox("Renewal To date is < Renewal From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Sub PopGrids()
        Dim var_Renew_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Renew_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Renew_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Renewal_Date_From As String = var_Renew_From_Month & "/" & var_Renew_From_Day & "/" & var_Renew_From_Year

        Dim var_Renew_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Renew_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Renew_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Renewal_Date_To As String = var_Renew_To_Month & "/" & var_Renew_To_Day & "/" & var_Renew_To_Year

        Dim sdt As New DataTable
        sdt = _objBusi.fgetDetailsII("YRRENEWAL", var_Renewal_Date_From, var_Renewal_Date_To, "", "", "", "", "", "", "", "B", Conn)
        If sdt.Rows.Count > 0 Then
            With Me.dgvYrRenewalSub
                .DataSource = sdt
                .Columns(0).DisplayIndex = 1
            End With
        End If

       
        Dim dt As New DataTable
        dt = _objBusi.getDetails("MEMBER", var_Renewal_Date_From, var_Renewal_Date_To, "", "", "YPENDINGLIST", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvYrRenewalPend
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(2).HeaderText = ""
                .Columns(3).HeaderText = "Doc. Received Date"
                .Columns(4).HeaderText = "File #"
                .Columns(5).HeaderText = "Policy #"
                .Columns(6).HeaderText = "Full Name"
                .Columns(7).HeaderText = "IC"
                .Columns(8).HeaderText = "Gross Premium "
                .Columns(9).HeaderText = "Plan "
                .Columns(10).HeaderText = "Payment Method "
                .Columns(11).HeaderText = "Effective Date "
                .Columns(13).HeaderText = "Credit Card - Batch # "
                .Columns(14).HeaderText = "Credit Card - Approval Code "
                .Columns(15).HeaderText = "Credit Card - Invoice # "
                .Columns(16).HeaderText = "Cheque # "
                .Columns(17).HeaderText = "Cheque - Receipt # "
                .Columns(18).Visible = False
                .Columns(19).Visible = False
                .Columns(12).Visible = False

                .Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(11).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
            End With
        Else
            MsgBox("No Record Found")
        End If
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvYrRenewalPend.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim ckxls_wks_name As String = ""
            Dim ccxls_wks_name As String = ""
            Dim cxls_wks_name As String = ""
            Dim iC As Integer = 0
            Dim iCC As Integer = 0
            Dim iCK As Integer = 0
            Dim i As Integer = 0
            Dim ckxls_row_counter As Integer = 7
            Dim ckvar_name_count As Integer = 0
            Dim ccxls_row_counter As Integer = 7
            Dim ccvar_name_count As Integer = 0
            Dim cxls_row_counter As Integer = 7
            Dim cvar_name_count As Integer = 0
            With Me.dgvYrRenewalPend
                Do While i < .Rows.Count
                    If .Rows(i).Cells(0).Value = "1" Then
                        Dim payment_method As String
                        payment_method = .Rows(i).Cells(10).Value.ToString.Trim()
                        Select Case payment_method

                            Case "Cash"
                                If iC = 0 Then
                                    xls_workbook.Worksheets.Add()
                                    cxls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
                                End If

                                iC += 1
                                With xls_workbook.Worksheets(cxls_wks_name)
                                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: CATB"
                                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: " & BatchNo '& Me.ssReport_Parameter.Text.Trim
                                    .Cells(3, 1) = "A/C CODE: GI2073"
                                    .Cells(4, 1) = "PAYMENT BY CASH"

                                    .Cells(6, 1) = "NO"
                                    .Cells(6, 2) = "DOC. REC. DATE"
                                    .Cells(6, 3) = "FILE #"
                                    .Cells(6, 4) = "POLICY NO."
                                    .Cells(6, 5) = "FULL NAME"
                                    .Cells(6, 6) = "IC"
                                    .Cells(6, 7) = "PREMIUM"
                                    .Cells(6, 8) = "GST 6%"
                                    .Cells(6, 9) = "GROSS PREMIUM"
                                    .Cells(6, 10) = "PLAN"
                                    .Cells(6, 11) = "POLICY EFFECTIVE DATE"
                                    .Cells(6, 12) = "POLICY EXPIRY DATE"
                                    .Cells(6, 13) = "MEDICARE'S RECEIPT NO."
                                    .Cells(6, 14) = "BANK IN"
                                    .Cells(6, 15) = "REMARK"

                                    .Cells(cxls_row_counter, 1) = "'" & (cxls_row_counter - 6).ToString.Trim
                                    .Cells(cxls_row_counter, 2) = "'" & dgvYrRenewalPend.Rows(i).Cells(3).Value
                                    .Cells(cxls_row_counter, 3) = "'" & dgvYrRenewalPend.Rows(i).Cells(4).Value
                                    .Cells(cxls_row_counter, 4) = dgvYrRenewalPend.Rows(i).Cells(5).Value
                                    .Cells(cxls_row_counter, 5) = "'" & dgvYrRenewalPend.Rows(i).Cells(6).Value
                                    .Cells(cxls_row_counter, 6) = "'" & dgvYrRenewalPend.Rows(i).Cells(7).Value
                                    Dim Premium, GST, TOTPREMIUM As Decimal
                                    Premium = dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    GST = Premium * 6 / 100
                                    TOTPREMIUM = Premium + GST
                                    .Cells(cxls_row_counter, 7) = "'" & dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    .Cells(cxls_row_counter, 8) = "'" & GST
                                    .Cells(cxls_row_counter, 9) = "'" & TOTPREMIUM
                                    .Cells(cxls_row_counter, 10) = "'" & dgvYrRenewalPend.Rows(i).Cells(9).Value
                                    .Cells(cxls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, +1, Convert.ToDateTime(dgvYrRenewalPend.Rows(i).Cells(12).Value).AddYears(-1))
                                    .Cells(cxls_row_counter, 12) = "'" & dgvYrRenewalPend.Rows(i).Cells(12).Value
                                    .Cells(cxls_row_counter, 13) = "'" & dgvYrRenewalPend.Rows(i).Cells(18).Value
                                    cxls_row_counter += 1
                                    cvar_name_count += 1
                                End With
                            Case "Cheque"

                                If iCK = 0 Then
                                    xls_workbook.Worksheets.Add()
                                    ckxls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
                                End If
                                iCK += 1
                                With xls_workbook.Worksheets(ckxls_wks_name)
                                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: CATB"
                                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: " & BatchNo '& Me.ssReport_Parameter.Text.Trim
                                    .Cells(3, 1) = "A/C CODE: GI2073"
                                    .Cells(4, 1) = "PAYMENT BY CHEQUE"

                                    .Cells(6, 1) = "NO"
                                    .Cells(6, 2) = "DOC. REC. DATE"
                                    .Cells(6, 3) = "FILE #"
                                    .Cells(6, 4) = "POLICY NO."
                                    .Cells(6, 5) = "FULL NAME"
                                    .Cells(6, 6) = "IC"
                                    .Cells(6, 7) = "PREMIUM"
                                    .Cells(6, 8) = "GST 6%"
                                    .Cells(6, 9) = "GROSS PREMIUM"
                                    .Cells(6, 10) = "PLAN"
                                    .Cells(6, 11) = "POLICY EFFECTIVE DATE"
                                    .Cells(6, 12) = "POLICY EXPIRY DATE"
                                    .Cells(6, 13) = "CHEQUE NO."
                                    .Cells(6, 14) = "MEDICARE'S RECEIPT NO."
                                    .Cells(6, 15) = "BANK IN"
                                    .Cells(6, 16) = "REMARK"

                                    .Cells(ckxls_row_counter, 1) = "'" & (ckxls_row_counter - 6).ToString.Trim
                                    .Cells(ckxls_row_counter, 2) = "'" & dgvYrRenewalPend.Rows(i).Cells(3).Value
                                    .Cells(ckxls_row_counter, 3) = "'" & dgvYrRenewalPend.Rows(i).Cells(4).Value
                                    .Cells(ckxls_row_counter, 4) = dgvYrRenewalPend.Rows(i).Cells(5).Value
                                    .Cells(ckxls_row_counter, 5) = "'" & dgvYrRenewalPend.Rows(i).Cells(6).Value
                                    .Cells(ckxls_row_counter, 6) = "'" & dgvYrRenewalPend.Rows(i).Cells(7).Value

                                    Dim Premium, GST, TOTPREMIUM As Decimal
                                    Premium = dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    GST = Premium * 6 / 100
                                    TOTPREMIUM = Premium + GST
                                    .Cells(ckxls_row_counter, 7) = "'" & dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    .Cells(ckxls_row_counter, 8) = "'" & GST
                                    .Cells(ckxls_row_counter, 9) = "'" & TOTPREMIUM

                                    .Cells(ckxls_row_counter, 10) = "'" & dgvYrRenewalPend.Rows(i).Cells(9).Value
                                    .Cells(ckxls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, +1, Convert.ToDateTime(dgvYrRenewalPend.Rows(i).Cells(12).Value).AddYears(-1))
                                    .Cells(ckxls_row_counter, 12) = "'" & dgvYrRenewalPend.Rows(i).Cells(12).Value
                                    .Cells(ckxls_row_counter, 13) = "'" & dgvYrRenewalPend.Rows(i).Cells(16).Value
                                    .Cells(ckxls_row_counter, 14) = "'" & dgvYrRenewalPend.Rows(i).Cells(17).Value


                                    ckxls_row_counter += 1
                                    ckvar_name_count += 1

                                End With

                            Case "Credit Card"

                                If iCC = 0 Then
                                    xls_workbook.Worksheets.Add()
                                    ccxls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
                                End If
                                iCC += 1
                                With xls_workbook.Worksheets(ccxls_wks_name)
                                    .Cells(1, 1) = "SUBMISSION OF YEARLY PROPOSALS TO PROCESSING DEPARTMENT: CATB"
                                    .Cells(2, 1) = "CUEPACSCARE RENEWAL CASES. BATCH NO: " & BatchNo '& Me.ssReport_Parameter.Text.Trim
                                    .Cells(3, 1) = "A/C CODE: GI2073"
                                    .Cells(4, 1) = "PAYMENT BY CREDIT CARD"

                                    .Cells(6, 1) = "NO"
                                    .Cells(6, 2) = "DOC. REC. DATE"
                                    .Cells(6, 3) = "FILE #"
                                    .Cells(6, 4) = "POLICY NO."
                                    .Cells(6, 5) = "FULL NAME"
                                    .Cells(6, 6) = "IC"
                                    .Cells(6, 7) = "PREMIUM"
                                    .Cells(6, 8) = "GST"
                                    .Cells(6, 9) = "GROSS PREMIUM"
                                    .Cells(6, 10) = "PLAN"
                                    .Cells(6, 11) = "POLICY EFFECTIVE DATE"
                                    .Cells(6, 12) = "POLICY EXPIRY DATE"
                                    .Cells(6, 13) = "BATCH NO."
                                    .Cells(6, 14) = "APPROVAL CODE"
                                    .Cells(6, 15) = "INVOICE NO."
                                    .Cells(6, 16) = "REMARK"

                                    .Cells(ccxls_row_counter, 1) = "'" & (ccxls_row_counter - 6).ToString.Trim
                                    .Cells(ccxls_row_counter, 2) = "'" & dgvYrRenewalPend.Rows(i).Cells(3).Value
                                    .Cells(ccxls_row_counter, 3) = "'" & dgvYrRenewalPend.Rows(i).Cells(4).Value
                                    .Cells(ccxls_row_counter, 4) = dgvYrRenewalPend.Rows(i).Cells(5).Value
                                    .Cells(ccxls_row_counter, 5) = "'" & dgvYrRenewalPend.Rows(i).Cells(6).Value
                                    .Cells(ccxls_row_counter, 6) = "'" & dgvYrRenewalPend.Rows(i).Cells(7).Value

                                    Dim Premium, GST, TOTPREMIUM As Decimal
                                    Premium = dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    GST = Premium * 6 / 100
                                    TOTPREMIUM = Premium + GST

                                    .Cells(ccxls_row_counter, 7) = "'" & dgvYrRenewalPend.Rows(i).Cells(8).Value
                                    .Cells(ckxls_row_counter, 8) = "'" & GST
                                    .Cells(ckxls_row_counter, 9) = "'" & TOTPREMIUM

                                    .Cells(ccxls_row_counter, 10) = "'" & dgvYrRenewalPend.Rows(i).Cells(9).Value
                                    .Cells(ccxls_row_counter, 11) = "'" & DateAdd(DateInterval.Day, +1, Convert.ToDateTime(dgvYrRenewalPend.Rows(i).Cells(12).Value).AddYears(-1))
                                    .Cells(ccxls_row_counter, 12) = "'" & dgvYrRenewalPend.Rows(i).Cells(12).Value
                                    .Cells(ccxls_row_counter, 13) = "'" & dgvYrRenewalPend.Rows(i).Cells(13).Value
                                    .Cells(ccxls_row_counter, 14) = "'" & dgvYrRenewalPend.Rows(i).Cells(14).Value
                                    .Cells(ccxls_row_counter, 15) = "'" & dgvYrRenewalPend.Rows(i).Cells(15).Value

                                    ccxls_row_counter += 1
                                    ccvar_name_count += 1
                                End With
                        End Select
                    End If
                    i += 1
                Loop
            End With
            MsgBox("Exporting records to PREMIUM PAYMENT STATEMENT TO INSURER completed.")
            xls_file.Visible = True
        End If
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim sRes As String
        Dim i As Integer = 0

        BatchNo = Now.Day & "/" & Now.Month & "/" & "REN" & "/" & Now.Year()
        With Me.dgvYrRenewalPend
            Do While i < .Rows.Count
                If .Rows(i).Cells(0).Value = "1" Then

                    Dim _scUpdate As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    _scUpdate.CommandType = CommandType.Text
                    _scUpdate.CommandText = "Update dt_Member_Policy_YearlyRenewal set status='" & .Rows(i).Cells(0).Value.ToString & " ' where member_policy_id='" & .Rows(i).Cells(1).Value.ToString & "'"
                    sRes = _scUpdate.ExecuteNonQuery
                    
                    Dim _scUp As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
                    _scUp.CommandType = CommandType.Text
                    _scUp.CommandText = "UPDATE DT_MEMBER_POLICY SET BATCH_NO='" & BatchNo & "' WHERE ID='" & .Rows(i).Cells(1).Value.ToString() & "'"
                    _scUp.ExecuteNonQuery()

                End If
                i += 1
            Loop
            Xport2Xcel()
            If sRes = "1" Then
                MsgBox("Status Updated Successfully")
                Me.Close()
            End If
        End With
    End Sub
    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked Then
            Dim i As Integer = 0
            With Me.dgvYrRenewalPend
                Do While i < .Rows.Count
                    .Rows(i).Cells(0).Value = 1
                    i += 1
                Loop
            End With
        Else
            Dim i As Integer = 0
            With Me.dgvYrRenewalPend
                Do While i < .Rows.Count
                    .Rows(i).Cells(0).Value = 0
                    i += 1
                Loop
            End With
        End If
    End Sub
    Private Sub llXport2Xcel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llXport2Xcel.LinkClicked
        Xport2Xcel()
    End Sub
    Private Sub dgvYrRenewalSub_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvYrRenewalSub.CellContentClick
        With Me.dgvYrRenewalSub
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(1).Value) Then
                    Dim D As New fInDetails
                    D.lblREF1.Text = .Rows(e.RowIndex).Cells(1).Value.ToString.Trim()
                    D.Show()
                End If
            End If
        End With
    End Sub
End Class