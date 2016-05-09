Public Class grdSubmitted_Proposers
    Dim Conn As DbConnection = New SqlConnection
    Dim Err_Msg As String = ""
    Dim _objBusi As New Business
    Private Sub grdSubmitted_Proposers_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdSubmitted_Proposers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Populate_Grid()
    End Sub

    Private Sub Populate_Grid()
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT DISTINCT Submission_Batch_No,Status " & _
                                         "FROM dt_Proposer " & _
                                         "WHERE Status='2' and ( member=0 or member is null)" & _
                                         "ORDER BY Submission_Batch_No"



        Dim ds_Search_Param As New DataSet


        Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)


        da_Proposer.Fill(ds_Search_Param, "dt_Proposer")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Proposer"

                .Columns(0).HeaderText = "Submission Batch No"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).HeaderText = "Status"
            End With
        End If


        Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.CommandText = "SELECT DISTINCT Submission_Batch_No, Status " & _
                                         "FROM dt_Proposer " & _
                                         "WHERE Status='2' and member=1" & _
                                         "ORDER BY Submission_Batch_No"
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(sqlCmd)
        adp.Fill(ds, "dt_Proposer")
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvC2Mem
                .DataSource = ds
                .DataMember = "dt_Proposer"
                .Columns(0).HeaderText = "Submission Batch No"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).HeaderText = "Status"
            End With
        End If

    End Sub
    Private Sub btnPrint_AngkasaSubmissionList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_AngkasaSubmissionList.Click
        If Me.dgvC2Mem.SelectedRows.Count > 0 Then
            If Len(Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim) < 15 Then

                Dim rpt_SubmitToAngkasa As New SubmitToAngkasa
                rpt_SubmitToAngkasa.lblBatch_No.Text = Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim
                rpt_SubmitToAngkasa.Show()
            Else
                MsgBox("Invalid selection!, Please check the selection and try again!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnGoto_AngkasaSubmissionDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoto_AngkasaSubmissionDetails.Click
        If Me.dgvC2Mem.SelectedRows.Count > 0 Then
            Dim grd_Proposer As New grdProposer
            grd_Proposer.MdiParent = Me.MdiParent
            grd_Proposer.lblForm_Flag.Text = "2"
            grd_Proposer.lblSubmission_Batch_No.Text = Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim
            grd_Proposer.Show()
        End If
    End Sub
    Private Sub btnConvert_Proposer2Member_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert_Proposer2Member.Click
        
        With Me.dgvFind_Result
            If .SelectedRows.Count > 0 Then
                Dim cmdSelect_SubmittedBatch As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_SubmittedBatch.CommandType = CommandType.Text
                cmdSelect_SubmittedBatch.CommandText = "SELECT Full_Name, IC_New, Plan_Code, Level2_Plan_Code, Premium, Payment_Method, Submission_Batch_No " & _
                                                       "FROM dt_Proposer " & _
                                                       "WHERE Submission_Batch_No = '" & .SelectedRows(0).Cells(0).Value.ToString.Trim & "' "

                Dim da_Submitted_Proposer As New SqlDataAdapter(cmdSelect_SubmittedBatch)


                Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Member.CommandType = CommandType.Text
                cmdSelect_Member.CommandText = "SELECT * FROM vi_Member_Policy_v2"

                Dim da_Member As New SqlDataAdapter(cmdSelect_Member)



                Dim ds_SubmittedBatch As New DataSet


                da_Submitted_Proposer.Fill(ds_SubmittedBatch, "dt_Proposer")
                da_Member.Fill(ds_SubmittedBatch, "vi_Member_Policy_v2")

                If MsgBox("Convert all these proposers in Batch #: " & .SelectedRows(0).Cells(0).Value.ToString.Trim & " to become Members.", MsgBoxStyle.OkCancel, "Convert Proposers->Members") = MsgBoxResult.Ok Then
                    Dim var_SelectedRows As Integer = 0
                    Dim var_ReturnedRows As DataRow()
                    Dim var_DeductionCode As String = ""
                    Dim var_Err_count As Integer = 0
                    Dim var_Dup_count As Integer = 0
                    Dim xls_row_index As Integer = 3

                    Dim xls_file As New Microsoft.Office.Interop.Excel.Application
                    Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
                    xls_workbook = xls_file.Workbooks.Add

                    With xls_workbook.Worksheets(1)
                        .Name = "Converting Errors"

                        .Columns(1).NumberFormat = "@"
                        .Columns(2).NumberFormat = "@"
                        .Columns(3).NumberFormat = "@"
                        .Columns(4).NumberFormat = "@"
                        .Columns(5).NumberFormat = "##,##0.00"
                        .Columns(6).NumberFormat = "@"
                        .Columns(7).NumberFormat = "@"

                        .Cells(1, 1) = "Full Name"
                        .Cells(1, 2) = "IC"
                        .Cells(1, 3) = "Plan Code"
                        .Cells(1, 4) = "Deduction Code"
                        .Cells(1, 5) = "Deduction Amount"
                        .Cells(1, 6) = "Status"
                        .Cells(1, 7) = "Payment Method"

                    End With

                    Do While var_SelectedRows < ds_SubmittedBatch.Tables("dt_Proposer").Rows.Count
                        With ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows)
                            Dim pCode As String()
                            pCode = .Item("Plan_Code").ToString.Split("-")
                            var_DeductionCode = pCode(1).ToString.Trim()

                            var_ReturnedRows = ds_SubmittedBatch.Tables("vi_Member_Policy_v2").Select("IC_New = '" & .Item("IC_New").ToString.Trim & "' AND " & _
                                                                                                      "Deduction_Code = '" & var_DeductionCode & "' AND " & _
                                                                                                      "Cancellation_Date IS Null")
                            Dim var_IC As String = .Item("IC_New").ToString.Trim & " "
                            Dim var_Plan_Code As String = .Item("Plan_Code").ToString.Trim & " "
                            Dim var_Level2_Plan_Code As String = .Item("Level2_Plan_Code").ToString.Trim
                            Dim var_Batch_No As String = .Item("Submission_Batch_No").ToString.Trim
                            Dim var_Payment_Method As String = .Item("Payment_Method").ToString.Trim

                            If var_ReturnedRows.Length = 0 Then

                                If Me.Transfer_Policy2Member(var_IC.Trim, var_Plan_Code.Trim, var_Level2_Plan_Code.Trim, var_DeductionCode, var_Batch_No) = False Then
                                    With xls_workbook.Worksheets(1)
                                        .Cells(xls_row_index, 1) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Full_Name").ToString.Trim
                                        .Cells(xls_row_index, 2) = var_IC.ToString.Trim
                                        .Cells(xls_row_index, 3) = var_Plan_Code.ToString.Trim & " - " & var_Level2_Plan_Code.ToString.Trim
                                        .Cells(xls_row_index, 4) = var_DeductionCode.ToString.Trim
                                        .Cells(xls_row_index, 5) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Premium").ToString
                                        .Cells(xls_row_index, 6) = Err_Msg.ToString.Trim
                                        .Cells(xls_row_index, 7) = var_Payment_Method.ToString.Trim

                                    End With
                                    xls_row_index += 1
                                    var_Err_count += 1
                                Else
                                    With xls_workbook.Worksheets(1)
                                        .Cells(xls_row_index, 1) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Full_Name").ToString.Trim
                                        .Cells(xls_row_index, 2) = var_IC.ToString.Trim
                                        .Cells(xls_row_index, 3) = var_Plan_Code.ToString.Trim & " - " & var_Level2_Plan_Code.ToString.Trim
                                        .Cells(xls_row_index, 4) = var_DeductionCode.ToString.Trim
                                        .Cells(xls_row_index, 5) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Premium").ToString
                                        .Cells(xls_row_index, 6) = "OK"
                                        .Cells(xls_row_index, 7) = var_Payment_Method.ToString.Trim
                                    End With
                                    xls_row_index += 1
                                End If
                            Else

                                With xls_workbook.Worksheets(1)
                                    .Cells(xls_row_index, 1) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Full_Name").ToString.Trim
                                    .Cells(xls_row_index, 2) = var_IC.ToString.Trim
                                    .Cells(xls_row_index, 3) = var_Plan_Code.ToString.Trim & " - " & var_Level2_Plan_Code.ToString.Trim
                                    .Cells(xls_row_index, 4) = var_DeductionCode.ToString.Trim
                                    .Cells(xls_row_index, 5) = ds_SubmittedBatch.Tables("dt_Proposer").Rows(var_SelectedRows).Item("Premium").ToString
                                    .Cells(xls_row_index, 6) = "Error: Record found in dt_Member and dt_Member_Policy."
                                    .Cells(xls_row_index, 7) = var_Payment_Method.ToString.Trim
                                End With
                                xls_row_index += 1
                                var_Dup_count += 1
                            End If

                        End With
                        var_SelectedRows += 1
                    Loop
                    MsgBox("Converting process completed.")
                    xls_file.Visible = True
                End If
            End If
        End With
    End Sub
    Private Function Transfer_Policy2Member(ByVal var_IC As String, ByVal var_Plan_Code As String, ByVal var_Level2_Plan_code As String, ByVal var_Deduction_Code As String, ByVal var_Submission_Batch_No As String) As Boolean
       
        Try

            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE IC_New = '" & var_IC.Trim & "' AND Plan_Code = '" & var_Plan_Code & _
                                             "' AND Level2_Plan_Code = '" & var_Level2_Plan_code & _
                                             "' AND Submission_Batch_No = '" & var_Submission_Batch_No & "'"
            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)


            Dim cmdSelect_Proposer_Agent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Agent.CommandType = CommandType.Text
            cmdSelect_Proposer_Agent.CommandText = "SELECT Proposer_ID, Agent_Code FROM dt_Proposer_Agent_Commission"
            Dim da_Proposer_Agent As New SqlDataAdapter(cmdSelect_Proposer_Agent)


            Dim cmdSelect_Proposer_Dependents As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Dependents.CommandType = CommandType.Text
            cmdSelect_Proposer_Dependents.CommandText = "SELECT * FROM dt_Proposer_Dependents"
            Dim da_Proposer_Dependents As New SqlDataAdapter(cmdSelect_Proposer_Dependents)


            Dim cmdSelect_Proposer_EC As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_EC.CommandType = CommandType.Text
            cmdSelect_Proposer_EC.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause"
            Dim da_Proposer_EC As New SqlDataAdapter(cmdSelect_Proposer_EC)


            Dim cmdSelect_Proposer_Nomination As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Nomination.CommandType = CommandType.Text
            cmdSelect_Proposer_Nomination.CommandText = "SELECT * FROM dt_Proposer_Nomination"
            Dim da_Proposer_Nomination As New SqlDataAdapter(cmdSelect_Proposer_Nomination)



            Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member.CommandType = CommandType.Text
            cmdSelect_Member.CommandText = "SELECT * FROM dt_Member WHERE IC_New = '" & var_IC.Trim & "'"
            Dim da_Member As New SqlDataAdapter(cmdSelect_Member)
            Dim cmdInsert_Member As SqlCommandBuilder
            cmdInsert_Member = New SqlCommandBuilder(da_Member)


            Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy.CommandType = CommandType.Text
            cmdSelect_Member_Policy.CommandText = "SELECT * FROM dt_Member_Policy"
            Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)
            Dim cmdInsert_Member_Policy As SqlCommandBuilder
            cmdInsert_Member_Policy = New SqlCommandBuilder(da_Member_Policy)


            Dim cmdSelect_Member_Dependents As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Dependents.CommandType = CommandType.Text
            cmdSelect_Member_Dependents.CommandText = "SELECT * FROM dt_Member_Policy_Dependents"
            Dim da_Member_Dependents As New SqlDataAdapter(cmdSelect_Member_Dependents)
            Dim cmdInsert_Member_Dependents As SqlCommandBuilder
            cmdInsert_Member_Dependents = New SqlCommandBuilder(da_Member_Dependents)


            Dim cmdSelect_Member_Policy_Exclusion As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Exclusion.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Exclusion.CommandText = "SELECT * FROM dt_Member_Policy_Exclusion_Clause"
            Dim da_Member_Policy_Exclusion As New SqlDataAdapter(cmdSelect_Member_Policy_Exclusion)
            Dim cmdInsert_Member_Policy_Exclusion As SqlCommandBuilder
            cmdInsert_Member_Policy_Exclusion = New SqlCommandBuilder(da_Member_Policy_Exclusion)


            Dim cmdSelect_Member_Policy_Nomination As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Nomination.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Nomination.CommandText = "SELECT * FROM dt_Member_Policy_Nomination"
            Dim da_Member_Policy_Nomination As New SqlDataAdapter(cmdSelect_Member_Policy_Nomination)
            Dim cmdInsert_Member_Policy_Nomination As SqlCommandBuilder
            cmdInsert_Member_Policy_Nomination = New SqlCommandBuilder(da_Member_Policy_Nomination)


            Dim cmdSelect_Log_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Log_Member.CommandType = CommandType.Text
            cmdSelect_Log_Member.CommandText = "SELECT * FROM log_Member"
            Dim da_log_Member As New SqlDataAdapter(cmdSelect_Log_Member)
            Dim cmdInsert_log_Member As SqlCommandBuilder
            cmdInsert_log_Member = New SqlCommandBuilder(da_log_Member)


            Dim cmdSelect_Member_Policy_Yearly As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Yearly.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Yearly.CommandText = "SELECT * FROM dt_Member_Policy_YearlyRenewal"
            Dim da_Member_Policy_Yearly As New SqlDataAdapter(cmdSelect_Member_Policy_Yearly)
            Dim cmdInsert_Member_Policy_Yearly As SqlCommandBuilder
            cmdInsert_Member_Policy_Yearly = New SqlCommandBuilder(da_Member_Policy_Yearly)



            Dim ds_Transfer As New DataSet

            Dim v_effective_dt As Date




            da_Proposer.Fill(ds_Transfer, "dt_Proposer")
            da_Proposer_Agent.Fill(ds_Transfer, "dt_Proposer_Agent_Commission")
            da_Proposer_Dependents.Fill(ds_Transfer, "dt_Proposer_Dependents")
            da_Proposer_EC.Fill(ds_Transfer, "dt_Proposer_Exclusion_Clause")
            da_Proposer_Nomination.Fill(ds_Transfer, "dt_Proposer_Nomination")
            da_Member.Fill(ds_Transfer, "dt_Member")
            da_Member_Policy.Fill(ds_Transfer, "dt_Member_Policy")
            da_Member_Dependents.Fill(ds_Transfer, "dt_Member_Policy_Dependents")
            da_Member_Policy_Exclusion.Fill(ds_Transfer, "dt_Member_Policy_Exclusion_Clause")
            da_Member_Policy_Nomination.Fill(ds_Transfer, "dt_Member_Policy_Nomination")
            da_log_Member.Fill(ds_Transfer, "log_Member")
            da_Member_Policy_Yearly.Fill(ds_Transfer, "dt_Member_Policy_YearlyRenewal")



            Dim dr_Proposer As DataRow = ds_Transfer.Tables("dt_Proposer").Rows(0)
            Dim var_Member_ID As String = ""
            Dim var_Member_Policy_ID As String = ""

            Dim cmdUpdate_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdUpdate_Proposer.CommandType = CommandType.Text
            cmdUpdate_Proposer.CommandText = "Update dt_Proposer  set member='1'" & _
                                             "WHERE IC_New = '" & var_IC.Trim & "' AND Plan_Code = '" & var_Plan_Code & _
                                             "' AND Level2_Plan_Code = '" & var_Level2_Plan_code & _
                                             "' AND Submission_Batch_No = '" & var_Submission_Batch_No & "'"
            cmdUpdate_Proposer.ExecuteNonQuery()
            Dim dtDoc As New DataTable
            Dim PID
            dtDoc = _objBusi.getDetails_I("DOCCHKLIST", var_IC.Trim(), var_Plan_Code, var_Level2_Plan_code, var_Submission_Batch_No, "", "", "", "", "", "", Conn)
            If dtDoc.Rows.Count > 0 Then
                PID = dtDoc.Rows(0)("ID").ToString.Trim()
            End If
            Dim FileData As Byte() = New Byte() {14}
            Select Case ds_Transfer.Tables("dt_Member").Rows.Count
                Case 0

                    Dim dr_Member_New As DataRow = ds_Transfer.Tables("dt_Member").NewRow

                    With dr_Member_New
                        var_Member_ID = Guid.NewGuid.ToString
                        .Item("ID") = var_Member_ID
                        .Item("Title") = dr_Proposer.Item("Title").ToString.Trim
                        .Item("Full_Name") = dr_Proposer.Item("Full_Name").ToString.Trim
                        .Item("Birth_Date") = dr_Proposer.Item("Birth_Date")
                        .Item("IC_New") = var_IC.ToString.Trim
                        .Item("IC_Old") = dr_Proposer.Item("IC_Old").ToString.Trim
                        .Item("ArmForce_ID") = dr_Proposer.Item("ArmForce_ID").ToString.Trim
                        .Item("Race") = dr_Proposer.Item("Race").ToString.Trim
                        .Item("Marital_Status") = dr_Proposer.Item("Marital_Status").ToString.Trim
                        .Item("Sex") = dr_Proposer.Item("Sex")
                        .Item("Postal_Address_L1") = dr_Proposer.Item("Postal_Address_L1").ToString.Trim
                        .Item("Postal_Address_L2") = dr_Proposer.Item("Postal_Address_L2").ToString.Trim
                        .Item("Add3") = dr_Proposer.Item("Add3").ToString.Trim
                        .Item("Add4") = dr_Proposer.Item("Add4").ToString.Trim
                        .Item("Town") = dr_Proposer.Item("Town").ToString.Trim
                        .Item("Postcode") = dr_Proposer.Item("Postcode").ToString.Trim
                        .Item("State") = dr_Proposer.Item("State").ToString.Trim
                        If Not IsDBNull(dr_Proposer.Item("Bank_Name")) Then
                            .Item("Bank_Name") = dr_Proposer.Item("Bank_Name").ToString.Trim
                        End If
                        If Not IsDBNull(dr_Proposer.Item("Bank_Ac")) Then
                            .Item("Bank_Ac") = dr_Proposer.Item("Bank_Ac").ToString.Trim
                        End If
                        .Item("Phone_Hse") = dr_Proposer.Item("Phone_Hse").ToString.Trim
                        .Item("Phone_Mobile") = dr_Proposer.Item("Phone_Mobile").ToString.Trim
                        .Item("Phone_Off") = dr_Proposer.Item("Phone_Off").ToString.Trim
                        .Item("Email") = dr_Proposer.Item("Email").ToString.Trim
                        .Item("Height") = dr_Proposer.Item("Height")
                        .Item("Weight") = dr_Proposer.Item("Weight")
                        .Item("Occupation") = dr_Proposer.Item("Occupation").ToString.Trim
                        .Item("Department") = dr_Proposer.Item("Department").ToString.Trim
                        .Item("Status") = "1"
                    End With
                    ds_Transfer.Tables("dt_Member").Rows.Add(dr_Member_New)
                    da_Member.Update(ds_Transfer, "dt_Member")


                    Dim dr_Proposer_Agent As DataRow()
                    dr_Proposer_Agent = ds_Transfer.Tables("dt_Proposer_Agent_Commission").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                    If dr_Proposer_Agent.Length > 0 Then
                        Dim dr_Member_Policy_New As DataRow = ds_Transfer.Tables("dt_Member_Policy").NewRow

                        With dr_Member_Policy_New
                            var_Member_Policy_ID = Guid.NewGuid.ToString
                            .Item("ID") = var_Member_Policy_ID
                            .Item("Member_ID") = var_Member_ID
                            .Item("Deduction_Code") = var_Deduction_Code
                            .Item("Deduction_Amount") = dr_Proposer.Item("Premium")
                            .Item("PLAN_CODE") = dr_Proposer.Item("PLAN_CODE").ToString.Trim
                            .Item("LEVEL2_PLAN_CODE") = dr_Proposer.Item("LEVEL2_PLAN_CODE").ToString.Trim
                            .Item("Agent_Code") = dr_Proposer_Agent(0).Item("Agent_Code").ToString.Trim
                            .Item("Submission_Date") = dr_Proposer.Item("Submission2Angkasa_On")
                            If var_Deduction_Code.Substring(0, 1) = "Y" Then
                                Dim var_Effective_Day As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Day
                                Dim var_Effective_Month As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Month
                                Dim var_Effective_Year As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Year

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
                                
                                v_effective_dt = var_Effective_Date
                                .Item("Effective_Date") = var_Effective_Date
                                .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(var_Effective_Date).AddYears(1))
                                .Item("Status") = "INFORCE"
                            Else
                                _objBusi.InsUpsPremiumHistory("INS", Guid.NewGuid.ToString(), var_Member_Policy_ID, "", "", dr_Proposer.Item("Premium"), "Active", "NEW", My.Settings.Username, Conn)


                                _objBusi.InsUpsPolicyPremiumHistory("INS", var_Member_Policy_ID, dr_Proposer.Item("Premium"), "", "", "NEW POLICY", My.Settings.Username, Conn)

                            End If

                            .Item("Angkasa_FileNo") = dr_Proposer.Item("Angkasa_FileNo").ToString.Trim
                            .Item("Batch_No") = dr_Proposer.Item("Submission_Batch_No").ToString.Trim
                            .Item("Special_Promo") = dr_Proposer.Item("Special_Promo")
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                            .Item("Last_Modified_By") = My.Settings.Username.Trim
                            .Item("Last_Modified_On") = Now()
                            .Item("Policy_Status") = "New"
                        End With
                        ds_Transfer.Tables("dt_Member_Policy").Rows.Add(dr_Member_Policy_New)
                        da_Member_Policy.Update(ds_Transfer, "dt_Member_Policy")
                    Else

                        Err_Msg = "Error: IC #: " & var_IC.Trim.Trim & ", find 0 agent code in the Proposer."
                        Return False
                    End If

                    If (dr_Proposer.Item("Payment_Frequency")) = "Y" Then   ' Y= Yearly
                        Dim dr_Member_Policy_Yearly_New_Cases As DataRow = ds_Transfer.Tables("dt_Member_Policy_YearlyRenewal").NewRow
                        With dr_Member_Policy_Yearly_New_Cases
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Proposal_Received_Date") 'dr_Proposer.Item("Created_On")
                            .Item("Payment_Method") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method").ToString.Trim), "", dr_Proposer.Item("Payment_Method").ToString.Trim)
                            .Item("Request_Date") = IIf(IsDBNull(dr_Proposer.Item("Proposal_Received_Date")), "", dr_Proposer.Item("Proposal_Received_Date").ToString.Trim)
                            .Item("Premium") = dr_Proposer.Item("Premium")
                            .Item("CC_Batch_No") = IIf(IsDBNull(dr_Proposer.Item("Submission_Batch_No").ToString.Trim), "", dr_Proposer.Item("Submission_Batch_No").ToString.Trim)
                            .Item("CC_Appr_Code") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_CreditCard_Appr_Code").ToString.Trim), "", dr_Proposer.Item("Payment_Method_CreditCard_Appr_Code").ToString.Trim)
                            .Item("CC_Invoice_No") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_CreditCard_Invoice_No").ToString.Trim), "", dr_Proposer.Item("Payment_Method_CreditCard_Invoice_No").ToString.Trim)
                            .Item("Cheque_No") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_Cheque_No").ToString.Trim), "", dr_Proposer.Item("Payment_Method_Cheque_No").ToString.Trim)
                            .Item("Cheque_Receipt_No") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_Cheque_Receipt_No").ToString.Trim), "", dr_Proposer.Item("Payment_Method_Cheque_Receipt_No").ToString.Trim)
                            .Item("Cash_Receipt_No") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_Cash_Receipt_No").ToString.Trim), "", dr_Proposer.Item("Payment_Method_Cash_Receipt_No").ToString.Trim)
                            .Item("Cash_Receipt_IssuedBy") = IIf(IsDBNull(dr_Proposer.Item("Payment_Method_Cash_Receipt_IssuedBy").ToString.Trim), "", dr_Proposer.Item("Payment_Method_Cash_Receipt_IssuedBy").ToString.Trim)
                            .Item("Created_By") = IIf(IsDBNull(dr_Proposer.Item("Created_By").ToString.Trim), "", dr_Proposer.Item("Created_By").ToString.Trim)
                            .Item("Created_On") = IIf(IsDBNull(dr_Proposer.Item("Created_On").ToString.Trim), "", dr_Proposer.Item("Created_On").ToString.Trim)
                        End With
                        ds_Transfer.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_Member_Policy_Yearly_New_Cases)
                        da_Member_Policy_Yearly.Update(ds_Transfer, "dt_Member_Policy_YearlyRenewal")
                    End If

                    _objBusi.fIUDocumentCheckList("UPS", Guid.NewGuid.ToString(), PID, var_Member_Policy_ID, "MEMBER", "", "", "", "", FileData, "", My.Settings.Username.ToString.Trim(), Conn)

                    Dim dr_Proposer_Dependents As DataRow()
                    Dim var_Dependent_count As Integer = 0

                    dr_Proposer_Dependents = ds_Transfer.Tables("dt_Proposer_Dependents").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                    If dr_Proposer_Dependents.Length > 0 Then
                        Do While var_Dependent_count < dr_Proposer_Dependents.Length
                            Dim dr_Member_Policy_Dependents_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Dependents").NewRow

                            With dr_Member_Policy_Dependents_New
                                .Item("ID") = Guid.NewGuid.ToString
                                .Item("Member_Policy_ID") = var_Member_Policy_ID
                                .Item("Title") = dr_Proposer_Dependents(var_Dependent_count).Item("Title").ToString.Trim
                                .Item("Full_Name") = dr_Proposer_Dependents(var_Dependent_count).Item("Full_Name").ToString.Trim
                                .Item("Birth_Date") = dr_Proposer_Dependents(var_Dependent_count).Item("Birth_Date")
                                .Item("IC_New") = dr_Proposer_Dependents(var_Dependent_count).Item("IC_New").ToString.Trim
                                .Item("IC_Old") = dr_Proposer_Dependents(var_Dependent_count).Item("IC_Old").ToString.Trim
                                .Item("ArmForce_ID") = dr_Proposer_Dependents(var_Dependent_count).Item("ArmForce_ID").ToString.Trim
                                .Item("Race") = dr_Proposer_Dependents(var_Dependent_count).Item("Race").ToString.Trim
                                .Item("Marital_Status") = dr_Proposer_Dependents(var_Dependent_count).Item("Marital_Status").ToString.Trim
                                .Item("Relationship") = dr_Proposer_Dependents(var_Dependent_count).Item("Relationship").ToString.Trim
                                .Item("Sex") = dr_Proposer_Dependents(var_Dependent_count).Item("Sex")
                                .Item("Height") = dr_Proposer_Dependents(var_Dependent_count).Item("Height")
                                .Item("Weight") = dr_Proposer_Dependents(var_Dependent_count).Item("Weight")
                                .Item("Occupation") = dr_Proposer_Dependents(var_Dependent_count).Item("Occupation").ToString.Trim
                                .Item("Department") = dr_Proposer_Dependents(var_Dependent_count).Item("Department").ToString.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                            End With
                            ds_Transfer.Tables("dt_Member_Policy_Dependents").Rows.Add(dr_Member_Policy_Dependents_New)
                            da_Member_Dependents.Update(ds_Transfer, "dt_Member_Policy_Dependents")
                            var_Dependent_count += 1
                        Loop
                    End If


                    Dim dr_Proposer_EC As DataRow()
                    Dim var_EC_count As Integer = 0

                    dr_Proposer_EC = ds_Transfer.Tables("dt_Proposer_Exclusion_Clause").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                    If dr_Proposer_EC.Length > 0 Then
                        Do While var_EC_count < dr_Proposer_EC.Length
                            Dim dr_Member_Policy_EC_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Exclusion_Clause").NewRow

                            With dr_Member_Policy_EC_New
                                .Item("ID") = Guid.NewGuid.ToString
                                .Item("Member_Policy_ID") = var_Member_Policy_ID
                                .Item("ExclusionClause_Code") = dr_Proposer_EC(var_EC_count).Item("ExclusionClause_Code").ToString.Trim
                                .Item("ExclusionClause_Description") = dr_Proposer_EC(var_EC_count).Item("ExclusionClause_Description").ToString.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                            End With
                            ds_Transfer.Tables("dt_Member_Policy_Exclusion_Clause").Rows.Add(dr_Member_Policy_EC_New)
                            da_Member_Policy_Exclusion.Update(ds_Transfer, "dt_Member_Policy_Exclusion_Clause")
                            var_EC_count += 1
                        Loop
                    End If


                    Dim dr_Proposer_Nomination As DataRow()
                    Dim var_Nomination_count As Integer = 0

                    dr_Proposer_Nomination = ds_Transfer.Tables("dt_Proposer_Nomination").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                    If dr_Proposer_Nomination.Length > 0 Then
                        Do While var_Nomination_count < dr_Proposer_Nomination.Length
                            Dim dr_Member_Policy_Nomination_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Nomination").NewRow

                            With dr_Member_Policy_Nomination_New
                                .Item("ID") = Guid.NewGuid.ToString
                                .Item("Member_Policy_ID") = var_Member_Policy_ID
                                .Item("Title") = dr_Proposer_Nomination(var_Nomination_count).Item("Title").ToString.Trim
                                .Item("Full_Name") = dr_Proposer_Nomination(var_Nomination_count).Item("Full_Name").ToString.Trim
                                .Item("Birth_Date") = dr_Proposer_Nomination(var_Nomination_count).Item("Birth_Date")
                                .Item("IC_New") = dr_Proposer_Nomination(var_Nomination_count).Item("IC_New").ToString.Trim
                                .Item("Relationship") = dr_Proposer_Nomination(var_Nomination_count).Item("Relationship").ToString.Trim
                                .Item("Postal_Address") = dr_Proposer_Nomination(var_Nomination_count).Item("Postal_Address").ToString.Trim
                                .Item("Share") = dr_Proposer_Nomination(var_Nomination_count).Item("Share")
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                            End With
                            ds_Transfer.Tables("dt_Member_Policy_Nomination").Rows.Add(dr_Member_Policy_Nomination_New)
                            da_Member_Policy_Nomination.Update(ds_Transfer, "dt_Member_Policy_Nomination")
                            var_Nomination_count += 1
                        Loop
                    End If


                    Dim dr_log_Member_New As DataRow = ds_Transfer.Tables("log_Member").NewRow


                    With dr_log_Member_New
                        .Item("Member_Policy_ID") = var_Member_Policy_ID
                        .Item("Log_Date") = dr_Proposer.Item("Proposal_Received_Date")
                        .Item("Activity_Detail") = "Proposal received."
                        .Item("Username") = dr_Proposer.Item("Created_By").ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                    End With
                    ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                    da_log_Member.Update(ds_Transfer, "log_Member")


                    dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                    With dr_log_Member_New
                        .Item("Member_Policy_ID") = var_Member_Policy_ID
                        .Item("Log_Date") = dr_Proposer.Item("Created_On")
                        .Item("Activity_Detail") = "Proposal's details been keyed into system."
                        .Item("Username") = dr_Proposer.Item("Created_By").ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                    End With
                    ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                    da_log_Member.Update(ds_Transfer, "log_Member")


                    If IsDBNull(dr_Proposer.Item("Last_Modified_On")) = False Then
                        dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                        With dr_log_Member_New
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Last_Modified_On")
                            .Item("Activity_Detail") = "Proposal details changed."
                            .Item("Username") = dr_Proposer.Item("Last_Modified_By").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                        End With
                        ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                        da_log_Member.Update(ds_Transfer, "log_Member")
                    End If


                    dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                    With dr_log_Member_New
                        .Item("Member_Policy_ID") = var_Member_Policy_ID
                        .Item("Log_Date") = dr_Proposer.Item("Verified_On")
                        .Item("Activity_Detail") = "Proposal's details been verified."
                        .Item("Username") = dr_Proposer.Item("Verified_By").ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                    End With
                    ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                    da_log_Member.Update(ds_Transfer, "log_Member")


                    dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                    With dr_log_Member_New
                        .Item("Member_Policy_ID") = var_Member_Policy_ID
                        .Item("Log_Date") = dr_Proposer.Item("Submission2Angkasa_On")
                        .Item("Activity_Detail") = "Proposal submitted to Salary Deduction Agency/Insurer, Batch #: " & dr_Proposer.Item("Submission_Batch_No").ToString.Trim & "."
                        .Item("Username") = dr_Proposer.Item("Submission2Angkasa_By").ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                    End With
                    ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                    da_log_Member.Update(ds_Transfer, "log_Member")

                    Transfer_Policy2Member = True

                Case 1

                    Dim dr_Member As DataRow = ds_Transfer.Tables("dt_Member").Rows(0)

                    With dr_Member
                        If IsDBNull(.Item("Title")) = True Then
                            .Item("Title") = dr_Proposer.Item("Title").ToString.Trim
                        End If
                        If IsDBNull(.Item("Full_Name")) = True Then
                            .Item("Full_Name") = dr_Proposer.Item("Full_Name").ToString.Trim
                        End If
                        If IsDBNull(.Item("Birth_Date")) = True Then
                            .Item("Birth_Date") = dr_Proposer.Item("Birth_Date")
                        End If
                        If IsDBNull(.Item("IC_Old")) = True Then
                            .Item("IC_Old") = dr_Proposer.Item("IC_Old").ToString.Trim
                        End If
                        If IsDBNull(.Item("ArmForce_ID")) = True Then
                            .Item("ArmForce_ID") = dr_Proposer.Item("ArmForce_ID").ToString.Trim
                        End If
                        If IsDBNull(.Item("Race")) = True Then
                            .Item("Race") = dr_Proposer.Item("Race").ToString.Trim
                        End If
                        If IsDBNull(.Item("Marital_Status")) = True Then
                            .Item("Marital_Status") = dr_Proposer.Item("Marital_Status").ToString.Trim
                        End If
                        If IsDBNull(.Item("Sex")) = True Then
                            .Item("Sex") = dr_Proposer.Item("Sex")
                        End If
                        .Item("Postal_Address_L1") = dr_Proposer.Item("Postal_Address_L1").ToString.Trim
                        .Item("Postal_Address_L2") = dr_Proposer.Item("Postal_Address_L2").ToString.Trim
                        .Item("Town") = dr_Proposer.Item("Town").ToString.Trim
                        .Item("Add3") = dr_Proposer.Item("Add3").ToString.Trim
                        .Item("Add4") = dr_Proposer.Item("Add4").ToString.Trim
                        .Item("Postcode") = dr_Proposer.Item("Postcode").ToString.Trim
                        .Item("State") = dr_Proposer.Item("State").ToString.Trim
                        If Not IsDBNull(dr_Proposer.Item("Bank_Name")) Then
                            .Item("Bank_Name") = dr_Proposer.Item("Bank_Name").ToString.Trim
                        End If
                        If Not IsDBNull(dr_Proposer.Item("State")) Then
                            .Item("State") = dr_Proposer.Item("State").ToString.Trim
                        End If

                        If IsDBNull(.Item("Phone_Hse")) = True Then
                            .Item("Phone_Hse") = dr_Proposer.Item("Phone_Hse").ToString.Trim
                        End If
                        If IsDBNull(.Item("Phone_Mobile")) = True Then
                            .Item("Phone_Mobile") = dr_Proposer.Item("Phone_Mobile").ToString.Trim
                        End If
                        If IsDBNull(.Item("Phone_Off")) = True Then
                            .Item("Phone_Off") = dr_Proposer.Item("Phone_Off").ToString.Trim
                        End If
                        If IsDBNull(.Item("Email")) = True Then
                            .Item("Email") = dr_Proposer.Item("Email").ToString.Trim
                        End If
                        If IsDBNull(.Item("Height")) = True Then
                            .Item("Height") = dr_Proposer.Item("Height")
                        End If
                        If IsDBNull(.Item("Weight")) = True Then
                            .Item("Weight") = dr_Proposer.Item("Weight")
                        End If
                        If IsDBNull(.Item("Occupation")) = True Then
                            .Item("Occupation") = dr_Proposer.Item("Occupation").ToString.Trim
                        End If
                        If IsDBNull(.Item("Department")) = True Then
                            .Item("Department") = dr_Proposer.Item("Department").ToString.Trim
                        End If
                        If IsDBNull(.Item("Status")) = True Then
                            .Item("Status") = "1"
                        End If
                    End With
                    da_Member.Update(ds_Transfer, "dt_Member")

                    Dim var_Member_id1 As String
                    var_Member_id1 = ds_Transfer.Tables("dt_Member").Rows(0).Item("ID").ToString.Trim

                    Dim dr_Member_Policy As DataRow()
                    dr_Member_Policy = ds_Transfer.Tables("dt_Member_Policy").Select("Member_ID = '" & ds_Transfer.Tables("dt_Member").Rows(0).Item("ID").ToString.Trim & _
                                                                                     "' AND Deduction_Code = '" & var_Deduction_Code & "' AND Cancellation_Date IS NULL")

                    If dr_Member_Policy.Length > 0 Then
                        MsgBox("IC #: " & var_IC.Trim & " found in dt_Member and Deduction Code is " & var_Deduction_Code & ".")
                        Transfer_Policy2Member = False
                    Else

                        Dim dr_Proposer_Agent As DataRow()
                        dr_Proposer_Agent = ds_Transfer.Tables("dt_Proposer_Agent_Commission").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                        If dr_Proposer_Agent.Length > 0 Then
                            Dim dr_Member_Policy_New As DataRow = ds_Transfer.Tables("dt_Member_Policy").NewRow

                            With dr_Member_Policy_New
                                var_Member_Policy_ID = Guid.NewGuid.ToString
                                .Item("ID") = var_Member_Policy_ID
                                .Item("Member_ID") = ds_Transfer.Tables("dt_Member").Rows(0).Item("ID").ToString.Trim
                                .Item("Deduction_Code") = var_Deduction_Code
                                .Item("Deduction_Amount") = dr_Proposer.Item("Premium")
                                .Item("PLAN_CODE") = dr_Proposer.Item("PLAN_CODE").ToString.Trim
                                .Item("LEVEL2_PLAN_CODE") = dr_Proposer.Item("LEVEL2_PLAN_CODE").ToString.Trim
                                .Item("Agent_Code") = dr_Proposer_Agent(0).Item("Agent_Code").ToString.Trim
                                .Item("Submission_Date") = dr_Proposer.Item("Submission2Angkasa_On")
                                If var_Deduction_Code.Substring(0, 1) = "Y" Then
                                    Dim var_Effective_Day As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Day
                                    Dim var_Effective_Month As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Month
                                    Dim var_Effective_Year As Integer = Convert.ToDateTime(dr_Proposer.Item("Proposal_Received_Date")).Year

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

                                    .Item("Effective_Date") = var_Effective_Date
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(var_Effective_Date).AddYears(1))
                                    .Item("Status") = "INFORCE"

                                Else
                                    _objBusi.InsUpsPremiumHistory("INS", Guid.NewGuid.ToString(), var_Member_Policy_ID, "", "", dr_Proposer.Item("Premium"), "Active", "", My.Settings.Username, Conn)


                                    _objBusi.InsUpsPolicyPremiumHistory("INS", var_Member_Policy_ID, dr_Proposer.Item("Premium"), "", "", "NEW POLICY", My.Settings.Username, Conn)

                                End If
                                .Item("Angkasa_FileNo") = dr_Proposer.Item("Angkasa_FileNo").ToString.Trim
                                .Item("Special_Promo") = dr_Proposer.Item("Special_Promo")
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Policy_Status") = "New"
                            End With
                            ds_Transfer.Tables("dt_Member_Policy").Rows.Add(dr_Member_Policy_New)
                            da_Member_Policy.Update(ds_Transfer, "dt_Member_Policy")
                        Else

                            Err_Msg = "Error: IC #: " & var_IC.Trim.Trim & ", find 0 agent code in the Proposer."
                            Return False
                        End If
                        _objBusi.fIUDocumentCheckList("UPS", Guid.NewGuid.ToString(), PID, var_Member_Policy_ID, "MEMBER", "", "", "", "", DirectCast(FileData, Object), "", My.Settings.Username.ToString.Trim(), Conn)

                        Dim dr_Proposer_Dependents As DataRow()
                        Dim var_Dependent_count As Integer = 0

                        dr_Proposer_Dependents = ds_Transfer.Tables("dt_Proposer_Dependents").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                        If dr_Proposer_Dependents.Length > 0 Then
                            Do While var_Dependent_count < dr_Proposer_Dependents.Length
                                Dim dr_Member_Policy_Dependents_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Dependents").NewRow

                                With dr_Member_Policy_Dependents_New
                                    .Item("ID") = Guid.NewGuid.ToString
                                    .Item("Member_Policy_ID") = var_Member_Policy_ID
                                    .Item("Title") = dr_Proposer_Dependents(var_Dependent_count).Item("Title").ToString.Trim
                                    .Item("Full_Name") = dr_Proposer_Dependents(var_Dependent_count).Item("Full_Name").ToString.Trim
                                    .Item("Birth_Date") = dr_Proposer_Dependents(var_Dependent_count).Item("Birth_Date")
                                    .Item("IC_New") = dr_Proposer_Dependents(var_Dependent_count).Item("IC_New").ToString.Trim
                                    .Item("IC_Old") = dr_Proposer_Dependents(var_Dependent_count).Item("IC_Old").ToString.Trim
                                    .Item("ArmForce_ID") = dr_Proposer_Dependents(var_Dependent_count).Item("ArmForce_ID").ToString.Trim
                                    .Item("Race") = dr_Proposer_Dependents(var_Dependent_count).Item("Race").ToString.Trim
                                    .Item("Marital_Status") = dr_Proposer_Dependents(var_Dependent_count).Item("Marital_Status").ToString.Trim
                                    .Item("Relationship") = dr_Proposer_Dependents(var_Dependent_count).Item("Relationship").ToString.Trim
                                    .Item("Sex") = dr_Proposer_Dependents(var_Dependent_count).Item("Sex")
                                    .Item("Height") = dr_Proposer_Dependents(var_Dependent_count).Item("Height")
                                    .Item("Weight") = dr_Proposer_Dependents(var_Dependent_count).Item("Weight")
                                    .Item("Occupation") = dr_Proposer_Dependents(var_Dependent_count).Item("Occupation").ToString.Trim
                                    .Item("Department") = dr_Proposer_Dependents(var_Dependent_count).Item("Department").ToString.Trim
                                    .Item("Created_By") = My.Settings.Username.Trim
                                    .Item("Created_On") = Now()
                                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                                    .Item("Last_Modified_On") = Now()
                                End With
                                ds_Transfer.Tables("dt_Member_Policy_Dependents").Rows.Add(dr_Member_Policy_Dependents_New)
                                da_Member_Dependents.Update(ds_Transfer, "dt_Member_Policy_Dependents")
                                var_Dependent_count += 1
                            Loop
                        End If


                        Dim dr_Proposer_EC As DataRow()
                        Dim var_EC_count As Integer = 0

                        dr_Proposer_EC = ds_Transfer.Tables("dt_Proposer_Exclusion_Clause").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                        If dr_Proposer_EC.Length > 0 Then
                            Do While var_EC_count < dr_Proposer_EC.Length
                                Dim dr_Member_Policy_EC_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Exclusion_Clause").NewRow

                                With dr_Member_Policy_EC_New
                                    .Item("ID") = Guid.NewGuid.ToString
                                    .Item("Member_Policy_ID") = var_Member_Policy_ID
                                    .Item("ExclusionClause_Code") = dr_Proposer_EC(var_EC_count).Item("ExclusionClause_Code").ToString.Trim
                                    .Item("ExclusionClause_Description") = dr_Proposer_EC(var_EC_count).Item("ExclusionClause_Description").ToString.Trim
                                    .Item("Created_By") = My.Settings.Username.Trim
                                    .Item("Created_On") = Now()
                                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                                    .Item("Last_Modified_On") = Now()
                                End With
                                ds_Transfer.Tables("dt_Member_Policy_Exclusion_Clause").Rows.Add(dr_Member_Policy_EC_New)
                                da_Member_Policy_Exclusion.Update(ds_Transfer, "dt_Member_Policy_Exclusion_Clause")
                                var_EC_count += 1
                            Loop
                        End If


                        Dim dr_Proposer_Nomination As DataRow()
                        Dim var_Nomination_count As Integer = 0

                        dr_Proposer_Nomination = ds_Transfer.Tables("dt_Proposer_Nomination").Select("Proposer_ID = '" & dr_Proposer.Item("ID").ToString.Trim & "'")

                        If dr_Proposer_Nomination.Length > 0 Then
                            Do While var_Nomination_count < dr_Proposer_Nomination.Length
                                Dim dr_Member_Policy_Nomination_New As DataRow = ds_Transfer.Tables("dt_Member_Policy_Nomination").NewRow

                                With dr_Member_Policy_Nomination_New
                                    .Item("ID") = Guid.NewGuid.ToString
                                    .Item("Member_Policy_ID") = var_Member_Policy_ID
                                    .Item("Title") = dr_Proposer_Nomination(var_Nomination_count).Item("Title").ToString.Trim
                                    .Item("Full_Name") = dr_Proposer_Nomination(var_Nomination_count).Item("Full_Name").ToString.Trim
                                    .Item("Birth_Date") = dr_Proposer_Nomination(var_Nomination_count).Item("Birth_Date")
                                    .Item("IC_New") = dr_Proposer_Nomination(var_Nomination_count).Item("IC_New").ToString.Trim
                                    .Item("Relationship") = dr_Proposer_Nomination(var_Nomination_count).Item("Relationship").ToString.Trim
                                    .Item("Postal_Address") = dr_Proposer_Nomination(var_Nomination_count).Item("Postal_Address").ToString.Trim
                                    .Item("Share") = dr_Proposer_Nomination(var_Nomination_count).Item("Share")
                                    .Item("Created_By") = My.Settings.Username.Trim
                                    .Item("Created_On") = Now()
                                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                                    .Item("Last_Modified_On") = Now()
                                End With
                                ds_Transfer.Tables("dt_Member_Policy_Nomination").Rows.Add(dr_Member_Policy_Nomination_New)
                                da_Member_Policy_Nomination.Update(ds_Transfer, "dt_Member_Policy_Nomination")
                                var_Nomination_count += 1
                            Loop
                        End If


                        Dim dr_log_Member_New As DataRow = ds_Transfer.Tables("log_Member").NewRow


                        With dr_log_Member_New
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Proposal_Received_Date")
                            .Item("Activity_Detail") = "Proposal received."
                            .Item("Username") = dr_Proposer.Item("Created_By").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                        End With
                        ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                        da_log_Member.Update(ds_Transfer, "log_Member")


                        dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                        With dr_log_Member_New
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Created_On")
                            .Item("Activity_Detail") = "Proposal's details been keyed into system."
                            .Item("Username") = dr_Proposer.Item("Created_By").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                        End With
                        ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                        da_log_Member.Update(ds_Transfer, "log_Member")


                        If IsDBNull(dr_Proposer.Item("Last_Modified_On")) = False Then
                            dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                            With dr_log_Member_New
                                .Item("Member_Policy_ID") = var_Member_Policy_ID
                                .Item("Log_Date") = dr_Proposer.Item("Last_Modified_On")
                                .Item("Activity_Detail") = "Proposal details changed."
                                .Item("Username") = dr_Proposer.Item("Last_Modified_By").ToString.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With
                            ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                            da_log_Member.Update(ds_Transfer, "log_Member")
                        End If


                        dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                        With dr_log_Member_New
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Verified_On")
                            .Item("Activity_Detail") = "Proposal's details been verified."
                            .Item("Username") = dr_Proposer.Item("Verified_By").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                        End With
                        ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                        da_log_Member.Update(ds_Transfer, "log_Member")


                        dr_log_Member_New = ds_Transfer.Tables("log_Member").NewRow

                        With dr_log_Member_New
                            .Item("Member_Policy_ID") = var_Member_Policy_ID
                            .Item("Log_Date") = dr_Proposer.Item("Submission2Angkasa_On")
                            .Item("Activity_Detail") = "Proposal submitted to Angkasa, Batch #: " & dr_Proposer.Item("Submission_Batch_No").ToString.Trim
                            .Item("Username") = dr_Proposer.Item("Submission2Angkasa_By").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                        End With
                        ds_Transfer.Tables("log_Member").Rows.Add(dr_log_Member_New)
                        da_log_Member.Update(ds_Transfer, "log_Member")

                        Transfer_Policy2Member = True
                    End If
                Case Else
                    MsgBox("This IC #: " & var_IC.Trim & " consists of multiple records, please do call your system vendor now. Thanks.")
                    Transfer_Policy2Member = False
            End Select
        Catch ex As Exception
            Err_Msg = "OK"
            Transfer_Policy2Member = False
        End Try
    End Function
    Private Sub btnPrint_SubmissionList_Yearly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_SubmissionList_Yearly.Click
        If Me.dgvC2Mem.SelectedRows.Count > 0 Then
            If Len(Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim) > 14 Then

                Dim grd_Report_Submission2Insurer_Yearly As New grdReport_Submission2Insurer_Yearly
                grd_Report_Submission2Insurer_Yearly.MdiParent = Me.MdiParent
                grd_Report_Submission2Insurer_Yearly.ssReport_Parameter.Text = Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim
                grd_Report_Submission2Insurer_Yearly.Show()
            Else
                MsgBox("Invalid selection! Please check the selection and try again!")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub btnSubmission2CIMB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmission2CIMB.Click
        If Me.dgvC2Mem.SelectedRows.Count > 0 Then
            Xport2Xcel(Me.dgvC2Mem.SelectedRows(0).Cells(0).Value.ToString.Trim)
        End If
    End Sub
    Private Function Xport2Xcel(ByVal BatchNO As String) As String
        MsgBox("Starting the export process...", MsgBoxStyle.Information)
        Dim dt As New DataTable

        dt = _objBusi.getSubProposerDetails("PS2CIMB", BatchNO, "", "", "", "", Conn)


        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_wb As Microsoft.Office.Interop.Excel.Workbook
        xls_wb = xls_file.Workbooks.Add
        Dim xls_wks_name As String = ""
        Dim xlsR_Count As Integer = 0
        Dim old_plan_code As String = ""

        For Each dr As DataRow In dt.Rows
            If old_plan_code <> dr("PLAN_CODE").ToString.Trim().Substring(0, 12) Then
                xls_wb.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_wb.Worksheets.Count.ToString.Trim
                With xls_wb.Worksheets(xls_wks_name)

                    .Cells(1, 1) = "SUBMISSION OF NEW PROPOSALS TO SUN LIFE MALAYSIA TAKAFUL BERHAD"
                    .Cells(2, 1) = "CUEPASCARE A/C CODE : "
                    .Cells(3, 1) = "BATCH # : " & BatchNO

                    .Cells(5, 1) = "NO"
                    .Cells(5, 2) = "FILE NO"
                    .Cells(5, 3) = "FULL NAME"
                    .Cells(5, 4) = "IC "
                    .Cells(5, 5) = "PLAN TYPE"
                    .Cells(5, 6) = "REMARKS FROM CATB"
                End With
                xlsR_Count = 6
                old_plan_code = dr("PLAN_CODE").ToString.Trim().Substring(0, 12)
            End If


            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 1) = "'" & (xlsR_Count - 5).ToString.Trim
            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 2) = "'" & dr("ANGKASA_FILENO")
            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 3) = "'" & dr("FULL_NAME")
            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 4) = "'" & dr("IC_NEW")
            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 5) = "'" & dr("LEVEL2_PLAN_CODE")
            xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count, 6) = ""
            xlsR_Count += 1
        Next

        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 2, 2) = "PREPARED BY"
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 5, 2) = "------------------------"
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 6, 2) = "Name : " & My.Settings.Username.ToUpper.Trim()
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 7, 2) = "Date : " & Format(Now(), "dd/MM/yyyy")
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 2, 5) = "RECEIVED BY"
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 5, 5) = "------------------------"
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 6, 5) = "Name : "
        xls_wb.Worksheets(xls_wks_name).Cells(xlsR_Count + 7, 5) = "Date : "

        MsgBox("Sucessfuly Exported New Proposals Submission Details for Sun Life")
        xls_file.Visible = True
    End Function
End Class