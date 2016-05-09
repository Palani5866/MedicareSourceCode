Public Class grdLog_Daily_Activities
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdLog_Daily_Activities_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdLog_Daily_Activities_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Populate_Grid()
    End Sub
    Private Sub Populate_Grid()

        Dim cmdLog_Login_Logoff As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Login_Logoff.CommandType = CommandType.Text
        cmdLog_Login_Logoff.CommandText = "SELECT Log_Date, Activity_Detail " & _
                                          "FROM log_User " & _
                                          "WHERE Username = '" & My.Settings.Username.Trim & "' " & _
                                          "AND CONVERT(VARCHAR(10),Log_Date, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                          "ORDER BY Log_Date"
        Dim da_Log_Login_Logoff As New SqlDataAdapter(cmdLog_Login_Logoff)



        Dim cmdLog_Proposal_DataEntry As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Proposal_DataEntry.CommandType = CommandType.Text
        cmdLog_Proposal_DataEntry.CommandText = "SELECT Full_Name, Angkasa_FileNo, Created_On " & _
                                                "FROM dt_Proposer " & _
                                                "WHERE Created_By = '" & My.Settings.Username.Trim & "' " & _
                                                "AND CONVERT(VARCHAR(10), Created_On, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                                "ORDER BY Created_On"
        Dim da_Log_Proposal_DataEntry As New SqlDataAdapter(cmdLog_Proposal_DataEntry)
        
        Dim cmdLog_Proposal_Change As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Proposal_Change.CommandType = CommandType.Text
        cmdLog_Proposal_Change.CommandText = "SELECT Full_Name, Angkasa_FileNo, Last_Modified_On " & _
                                             "FROM dt_Proposer " & _
                                             "WHERE Last_Modified_By = '" & My.Settings.Username.Trim & "' " & _
                                             "AND Created_On <> Last_Modified_On " & _
                                             "AND CONVERT(VARCHAR(10), Last_Modified_On, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                             "ORDER BY Last_Modified_On"
        Dim da_Log_Proposal_Change As New SqlDataAdapter(cmdLog_Proposal_Change)
        
        Dim cmdLog_Proposal_Verify As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Proposal_Verify.CommandType = CommandType.Text
        cmdLog_Proposal_Verify.CommandText = "SELECT Full_Name, Angkasa_FileNo, Verified_On " & _
                                             "FROM dt_Proposer " & _
                                             "WHERE Verified_By = '" & My.Settings.Username.Trim & "' " & _
                                             "AND CONVERT(VARCHAR(10), Verified_On, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                             "ORDER BY Verified_On"
        Dim da_Log_Proposal_Verify As New SqlDataAdapter(cmdLog_Proposal_Verify)
        
        Dim cmdLog_Proposal_Submission As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Proposal_Submission.CommandType = CommandType.Text
        cmdLog_Proposal_Submission.CommandText = "SELECT Full_Name, Angkasa_FileNo, Submission_Batch_No, Submission2Angkasa_On As Log_Date " & _
                                                 "FROM dt_Proposer " & _
                                                 "WHERE Submission2Angkasa_By = '" & My.Settings.Username.Trim & "' " & _
                                                 "AND CONVERT(VARCHAR(10), Submission2Angkasa_On, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                                 "ORDER BY Submission2Angkasa_On"
        Dim da_Log_Proposal_Submission As New SqlDataAdapter(cmdLog_Proposal_Submission)
        
        Dim cmdLog_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Member_Endorsement.CommandType = CommandType.Text
        cmdLog_Member_Endorsement.CommandText = "SELECT Full_Name, Angkasa_FileNo, Endorsement_Detail, Log_Date " & _
                                                "FROM vi_log_Member_Endorsement " & _
                                                "WHERE Created_By = '" & My.Settings.Username.Trim & "' " & _
                                                "AND CONVERT(VARCHAR(10), Log_Date, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                                "ORDER BY Log_Date"
        Dim da_Log_Member_Endorsement As New SqlDataAdapter(cmdLog_Member_Endorsement)
        
        Dim cmdLog_Member_YearlyRenewal As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdLog_Member_YearlyRenewal.CommandType = CommandType.Text
        cmdLog_Member_YearlyRenewal.CommandText = "SELECT Full_Name, Angkasa_FileNo, Log_Date " & _
                                                  "FROM vi_log_Member_YearlyRenewal " & _
                                                  "WHERE Created_By = '" & My.Settings.Username.Trim & "' " & _
                                                  "AND CONVERT(VARCHAR(10), Log_Date, 111) = '" & Format(Now(), "yyyy/MM/dd") & "' " & _
                                                  "ORDER BY Log_Date"
        Dim da_Log_Member_YearlyRenewal As New SqlDataAdapter(cmdLog_Member_YearlyRenewal)



        Dim ds_Log As New DataSet

        da_Log_Login_Logoff.Fill(ds_Log, "log_User")
        da_Log_Proposal_DataEntry.Fill(ds_Log, "dt_Proposer_DataEntry")
        da_Log_Proposal_Change.Fill(ds_Log, "dt_Proposer_Change")
        da_Log_Proposal_Verify.Fill(ds_Log, "dt_Proposer_Verify")
        da_Log_Proposal_Submission.Fill(ds_Log, "dt_Proposer_Submission")
        da_Log_Member_Endorsement.Fill(ds_Log, "vi_log_Member_Endorsement")
        da_Log_Member_YearlyRenewal.Fill(ds_Log, "vi_log_Member_YearlyRenewal")


        Dim dt_Log As New DataTable("Log")

        Dim colActivity_DateTime As New DataColumn("Activity_DateTime")
        colActivity_DateTime.DataType = System.Type.GetType("System.DateTime")
        dt_Log.Columns.Add(colActivity_DateTime)

        Dim colFile_No As New DataColumn("FileNo")
        colFile_No.DataType = System.Type.GetType("System.String")
        dt_Log.Columns.Add(colFile_No)

        Dim colName As New DataColumn("Name")
        colName.DataType = System.Type.GetType("System.String")
        dt_Log.Columns.Add(colName)

        Dim colActivity As New DataColumn("Activity")
        colActivity.DataType = System.Type.GetType("System.String")
        dt_Log.Columns.Add(colActivity)



        Dim log_count As Integer = 0

        If ds_Log.Tables("log_User").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("log_User").Rows.Count
                With ds_Log.Tables("log_User").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Log_Date"), " ", " ", .Item("Activity_Detail")})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("dt_Proposer_DataEntry").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("dt_Proposer_DataEntry").Rows.Count
                With ds_Log.Tables("dt_Proposer_DataEntry").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Created_On"), .Item("Angkasa_FileNo"), .Item("Full_Name"), "Proposal's details been keyed into system."})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("dt_Proposer_Change").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("dt_Proposer_Change").Rows.Count
                With ds_Log.Tables("dt_Proposer_Change").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Last_Modified_On"), .Item("Angkasa_FileNo"), .Item("Full_Name"), "Proposal details changed."})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("dt_Proposer_Verify").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("dt_Proposer_Verify").Rows.Count
                With ds_Log.Tables("dt_Proposer_Verify").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Verified_On"), .Item("Angkasa_FileNo"), .Item("Full_Name"), "Proposal's details been verified."})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("dt_Proposer_Submission").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("dt_Proposer_Submission").Rows.Count
                With ds_Log.Tables("dt_Proposer_Submission").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Submission2Angkasa_On"), .Item("Angkasa_FileNo"), .Item("Full_Name"), "Proposal submitted to Salary Deduction Agency, Batch #: " & .Item("Submission_Batch_No")})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("vi_log_Member_Endorsement").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("vi_log_Member_Endorsement").Rows.Count
                With ds_Log.Tables("vi_log_Member_Endorsement").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Log_Date"), .Item("Angkasa_FileNo"), .Item("Full_Name"), .Item("Endorsement_Detail")})
                    log_count += 1
                End With
            Loop
        End If

        If ds_Log.Tables("vi_log_Member_YearlyRenewal").Rows.Count > 0 Then
            log_count = 0
            Do While log_count < ds_Log.Tables("vi_log_Member_YearlyRenewal").Rows.Count
                With ds_Log.Tables("vi_log_Member_YearlyRenewal").Rows(log_count)
                    dt_Log.Rows.Add(New Object() {.Item("Log_Date"), .Item("Angkasa_FileNo"), .Item("Full_Name"), "Renewal of Policy."})
                    log_count += 1
                End With
            Loop
        End If


        dt_Log.DefaultView.Sort = "Activity_DateTime ASC"

        Me.dgvForm.DataSource = dt_Log
        Me.dgvForm.Columns(0).HeaderText = "Date & Time"
        Me.dgvForm.Columns(1).HeaderText = "File #"
        Me.dgvForm.Columns(2).HeaderText = "Proposer / PolicyHolder's Name"
        Me.dgvForm.Columns(3).HeaderText = "Activity"

        Me.dgvForm.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvForm.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvForm.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvForm.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

    End Sub
End Class