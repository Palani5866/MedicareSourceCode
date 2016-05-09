Public Class vAgent_Commission
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub vAgent_Commission_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vAgent_Commission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popCB()
        Me.rbSubmissionofDate.Checked = True
        Me.txtRMFROM.Visible = False
        Me.txtRMTO.Visible = False
    End Sub
    Private Sub popCB()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("AGENT", "", "", "", "", "MANAGER", Conn)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            dr = dt.NewRow()
            dr(0) = "0"
            dr(1) = "ALL"
            dt.Rows.InsertAt(dr, 0)
            Me.cbManager.DataSource = dt
            Me.cbManager.DisplayMember = "AGENT_NAME"
            Me.cbManager.ValueMember = "TB_AGENT_ID"
        End If
        Dim dtProduct As New DataTable
        dtProduct = _objBusi.getDetails("AGENT", "", "", "", "", "PRODUCT", Conn)
        If dtProduct.Rows.Count > 0 Then
            Me.cbProduct.DataSource = dtProduct
            Me.cbProduct.DisplayMember = "PRODUCT_PLAN_TYPE"
            Me.cbProduct.ValueMember = "TB_PRODUCT_PLAN_TYPE_ID"
        End If
    End Sub
    Private Sub cbManager_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbManager.SelectedIndexChanged
        If Not Me.cbManager.SelectedValue.ToString = "System.Data.DataRowView" Then
            Dim dt As New DataTable
            dt = _objBusi.getDetails("AGENT", Me.cbManager.SelectedValue, "", "", "", "SUPERVISOR", Conn)
            Dim dr As DataRow
            dr = dt.NewRow()
            dr(0) = "0"
            dr(1) = "ALL"
            dt.Rows.InsertAt(dr, 0)
            Me.cbSupervisor.DataSource = dt
            Me.cbSupervisor.DisplayMember = "AGENT_NAME"
            Me.cbSupervisor.ValueMember = "TB_AGENT_ID"
        End If
    End Sub
    Private Sub cbSupervisor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSupervisor.SelectedIndexChanged
        If Not Me.cbSupervisor.SelectedValue.ToString = "System.Data.DataRowView" Then
            Dim dt As New DataTable
            dt = _objBusi.getDetails("AGENT", Me.cbManager.SelectedValue, Me.cbSupervisor.SelectedValue, "", "", "AGENT", Conn)
            Dim dr As DataRow
            dr = dt.NewRow()
            dr(0) = "0"
            dr(1) = "ALL"
            dt.Rows.InsertAt(dr, 0)
            cbAgent.DataSource = dt
            cbAgent.DisplayMember = "AGENT_NAME"
            cbAgent.ValueMember = "TB_AGENT_ID"
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        BINDDATA()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable

        Dim cmd As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        cmd.CommandType = CommandType.Text
        If Me.rbSubmissionofDate.Checked Then
            Me.dgvACDetails.DataSource = Nothing
            Me.dgvACDetails.DataMember = Nothing
            If Me.cbManager.Text = "ALL" Then
                cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                      "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage, phone_hse, phone_mobile, Phone_off, Email " & _
                                                      "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                      "WHERE substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' AND B.Premium!='' " & _
                                                      "AND Submission2Angkasa_On >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Submission2Angkasa_On<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                      "Order by Submission2Angkasa_On"
            Else
                If Me.cbSupervisor.Text = "ALL" Then
                    If Me.cbAgent.Text = "ALL" Then
                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                              "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage,  phone_hse, phone_mobile, Phone_off, Email " & _
                                                              "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                              "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "') " & _
                                                              "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' and B.Premium!='' " & _
                                                              "AND Submission2Angkasa_On >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Submission2Angkasa_On < DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                              "Order by Submission2Angkasa_On"
                    Else
                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                          "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage,  phone_hse, phone_mobile, Phone_off, Email " & _
                                          "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                          "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') " & _
                                          "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' and B.Premium!='' " & _
                                          "AND Submission2Angkasa_On >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Submission2Angkasa_On < DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                          "Order by Submission2Angkasa_On"
                    End If
                Else
                    cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                                              "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage,  phone_hse, phone_mobile, Phone_off, Email " & _
                                                                              "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                                              "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "') " & _
                                                                              "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' and B.Premium!='' " & _
                                                                              "AND Submission2Angkasa_On >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Submission2Angkasa_On<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                                              "Order by Submission2Angkasa_On"
                End If
            End If
            
            cmd.CommandTimeout = 800000
            Dim sdp As New SqlDataAdapter(cmd)
            sdp.Fill(dt)

            If dt.Rows.Count > 0 Then
                Me.dgvACDetails.DataSource = dt
                With Me.dgvACDetails
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = "FILE #"
                    .Columns(2).HeaderText = "DATE RECEIVED"
                    .Columns(3).HeaderText = "SUBMISSION DATE"
                    .Columns(4).HeaderText = "POLICY HOLDER NAME"
                    .Columns(5).HeaderText = "POLICY HOLDER IC"
                    .Columns(6).HeaderText = "AGENT CODE"
                    .Columns(7).HeaderText = "PLAN CODE"
                    .Columns(8).HeaderText = "PLAN CODE (LEVEL 2)"
                    .Columns(9).HeaderText = "PREMIUM "
                    .Columns(10).HeaderText = "STATUS"
                    .Columns(11).HeaderText = "DECLINE REASON"
                    .Columns(9).DefaultCellStyle.Format = "###,###.00"
                    .Columns(12).Visible = False
                    .Columns(13).HeaderText = "PHONE HOUSE"
                    .Columns(14).HeaderText = "PHONE MOBILE"
                    .Columns(15).HeaderText = "PHONE OFFICE"
                    .Columns(16).HeaderText = "EMAIL"
                End With
            Else
                MsgBox("No Record Found")
                Me.dgvACDetails.Columns.Clear()
            End If
        ElseIf Me.rbEffectiveDate.Checked Then
            Me.dgvACDetails.DataSource = Nothing
            Me.dgvACDetails.DataMember = Nothing
            If Me.cbManager.Text = "ALL" Then
                cmd.CommandText = "SELECT A.ID, A.ANGKASA_FILENO, A.EFFECTIVE_DATE, A.CANCELLATION_DATE,  B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, PLAN_CODE, LEVEL2_PLAN_CODE, " & _
                                      "DEDUCTION_AMOUNT, (SELECT PERCENTAGE FROM TB_AGENT WHERE AGENT_CODE=A.AGENT_CODE) AS PERCENTAGE, phone_hse, phone_mobile, Phone_off, Email " & _
                                      "FROM DT_MEMBER_POLICY A INNER JOIN DT_MEMBER B ON A.MEMBER_ID=B.ID " & _
                                      "WHERE SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                      "AND EFFECTIVE_DATE >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' AND EFFECTIVE_DATE<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                      " AND A.STATUS='INFORCE' Order by EFFECTIVE_DATE"
            Else
                If Me.cbSupervisor.Text = "ALL" Then
                    If Me.cbAgent.Text = "ALL" Then
                        cmd.CommandText = "SELECT A.ID, A.ANGKASA_FILENO, A.EFFECTIVE_DATE, A.CANCELLATION_DATE,  B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, PLAN_CODE, LEVEL2_PLAN_CODE, " & _
                                                      "DEDUCTION_AMOUNT, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbSupervisor.SelectedValue & "') AS PERCENTAGE, phone_hse, phone_mobile, Phone_off, Email " & _
                                                      "FROM DT_MEMBER_POLICY A INNER JOIN DT_MEMBER B ON A.MEMBER_ID=B.ID " & _
                                                      "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "')  " & _
                                                      "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                     "AND EFFECTIVE_DATE >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' AND EFFECTIVE_DATE<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                      " AND A.STATUS='INFORCE' Order by EFFECTIVE_DATE"
                    Else
                        cmd.CommandText = "SELECT A.ID, A.ANGKASA_FILENO, A.EFFECTIVE_DATE, A.CANCELLATION_DATE,  B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, PLAN_CODE, LEVEL2_PLAN_CODE, " & _
                                                      "DEDUCTION_AMOUNT, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') AS PERCENTAGE, phone_hse, phone_mobile, Phone_off, Email " & _
                                                      "FROM DT_MEMBER_POLICY A INNER JOIN DT_MEMBER B ON A.MEMBER_ID=B.ID " & _
                                                      "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') " & _
                                                      "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                      "AND EFFECTIVE_DATE >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' AND EFFECTIVE_DATE<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                      " AND A.STATUS='INFORCE' Order by EFFECTIVE_DATE"
                    End If
                    
                Else
                    cmd.CommandText = "SELECT A.ID, A.ANGKASA_FILENO, A.EFFECTIVE_DATE, A.CANCELLATION_DATE,  B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, PLAN_CODE, LEVEL2_PLAN_CODE, " & _
                                                                          "DEDUCTION_AMOUNT, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbManager.SelectedValue & "') AS PERCENTAGE, phone_hse, phone_mobile, Phone_off, Email " & _
                                                                          "FROM DT_MEMBER_POLICY A INNER JOIN DT_MEMBER B ON A.MEMBER_ID=B.ID " & _
                                                                          "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "') " & _
                                                                          "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                                          "AND EFFECTIVE_DATE >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' AND EFFECTIVE_DATE<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                                          " AND A.STATUS='INFORCE' Order by EFFECTIVE_DATE"
                End If

            End If
            cmd.CommandTimeout = 800000
            Dim sdp As New SqlDataAdapter(cmd)
            sdp.Fill(dt)

            If dt.Rows.Count > 0 Then
                Me.dgvACDetails.DataSource = dt
                With Me.dgvACDetails
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = "FILE #"
                    .Columns(2).HeaderText = "EFFECTIVE DATE"
                    .Columns(3).HeaderText = "CANCELLATION DATE"
                    .Columns(4).HeaderText = "POLICY HOLDER NAME"
                    .Columns(5).HeaderText = "POLICY HOLDER IC"
                    .Columns(6).HeaderText = "AGENT CODE"
                    .Columns(7).HeaderText = "PLAN CODE"
                    .Columns(8).HeaderText = "PLAN CODE (LEVEL 2)"
                    .Columns(9).HeaderText = "PREMIUM "
                    .Columns(9).DefaultCellStyle.Format = "###,###.00"
                    .Columns(10).Visible = False
                    .Columns(11).HeaderText = "PHONE HOUSE"
                    .Columns(12).HeaderText = "PHONE MOBILE"
                    .Columns(13).HeaderText = "PHONE OFFICE"
                    .Columns(14).HeaderText = "EMAIL"
                End With
            Else
                MsgBox("No Record Found")
                Me.dgvACDetails.Columns.Clear()
            End If
        ElseIf Me.rbReceivedMonth.Checked Then
            getReport()
        ElseIf Me.rbReceivedDate.Checked Then
            getReceived_DateReport()
        End If
    End Sub
    Private Sub getReport()
        If Len(Me.txtRMFROM.Text.Trim) = 0 Then
            MsgBox("Please do key in the Receiving Month - From (yyyymm).")
            Me.txtRMFROM.Focus()
            Exit Sub
        End If
        If Len(Me.txtRMTO.Text.Trim) = 0 Then
            MsgBox("Please do key in the Receiving Month - To (yyyymm).")
            Me.txtRMTO.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.txtRMFROM.Text) = False Then
            MsgBox("Please do key in the Receiving Month - From in the right format (yyyymm).")
            Me.txtRMFROM.Focus()
            Exit Sub
        Else
            If IsNumeric(Me.txtRMTO.Text) = False Then
                MsgBox("Please do key in the Receiving Month - To date in the right format (yyyymm).")
                Me.txtRMTO.Focus()
                Exit Sub
            Else
                Try
                    If Convert.ToUInt32(Me.txtRMTO.Text) >= Convert.ToUInt32(Me.txtRMFROM.Text) Then
                        Me.dgvACDetails.DataSource = Nothing
                        Me.dgvACDetails.DataMember = Nothing
                        Dim dt As New DataTable
                        Dim cmd As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
                        cmd.CommandType = CommandType.Text
                        cmd.CommandTimeout = 80000
                        If Me.cbProduct.Text.Trim() = "CUEPACS PA" Then

                            If Me.cbManager.Text = "ALL" Then
                                cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                      "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE AGENT_CODE=B.AGENT_CODE) AS PERCENTAGE, b.Submission_Date " & _
                                                      "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                      "WHERE SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                      "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                      " AND B.STATUS='INFORCE' AND SUBMISSION_DATE > '09/01/2014' Order by B.EFFECTIVE_DATE"
                            Else
                                If Me.cbSupervisor.Text = "ALL" Then
                                    cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                      "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbManager.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                      "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                      "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "') " & _
                                                      "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                      "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                      "AND B.STATUS='INFORCE' AND SUBMISSION_DATE > '09/01/2014' Order by B.EFFECTIVE_DATE"
                                Else
                                    If Me.cbAgent.Text = "ALL" Then
                                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                          "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbSupervisor.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                          "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                          "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbSupervisor.SelectedValue & "') " & _
                                                          "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                          "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                          "AND B.STATUS='INFORCE' AND SUBMISSION_DATE > '09/01/2014' Order by B.EFFECTIVE_DATE"
                                    Else
                                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                          "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN,(SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                          "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                          "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') " & _
                                                          "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                          "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                          "AND B.STATUS='INFORCE' AND SUBMISSION_DATE > '09/01/2014' Order by B.EFFECTIVE_DATE"
                                    End If
                                End If
                            End If
                        Else
                            If Me.cbManager.Text = "ALL" Then
                                cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                      "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE AGENT_CODE=B.AGENT_CODE) AS PERCENTAGE, b.Submission_Date " & _
                                                      "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                      "WHERE SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                      "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                      " AND B.STATUS='INFORCE' Order by B.EFFECTIVE_DATE"
                            Else
                                If Me.cbSupervisor.Text = "ALL" Then
                                    cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                      "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbManager.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                      "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                      "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "') " & _
                                                      "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                      "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                      "AND B.STATUS='INFORCE' Order by B.EFFECTIVE_DATE"
                                Else
                                    If Me.cbAgent.Text = "ALL" Then
                                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                          "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN, (SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbSupervisor.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                          "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                          "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbSupervisor.SelectedValue & "') " & _
                                                          "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                          "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                          "AND B.STATUS='INFORCE' Order by B.EFFECTIVE_DATE"
                                    Else
                                        cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.EFFECTIVE_DATE, B.CANCELLATION_DATE,  C.FULL_NAME, C.IC_NEW,B.AGENT_CODE, B.PLAN_CODE, B.LEVEL2_PLAN_CODE, " & _
                                                          "A.ANGKASA_JUMLAH_POKOK, A.ANGKASA_BULAN_POTONGAN,(SELECT PERCENTAGE FROM TB_AGENT WHERE TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') AS PERCENTAGE, b.Submission_Date " & _
                                                          "FROM DT_MEMBER_POLICY_MONTHLYDEDUCTION A INNER JOIN DT_MEMBER_POLICY B ON A.MEMBER_POLICY_ID=B.ID INNER JOIN DT_MEMBER C ON B.MEMBER_ID=C.ID " & _
                                                          "WHERE AGENT_CODE IN(SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') " & _
                                                          "AND SUBSTRING(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                          "AND A.RECEIVING_MONTH BETWEEN '" & Me.txtRMFROM.Text.Trim() & "' AND '" & Me.txtRMTO.Text.Trim() & "' " & _
                                                          "AND B.STATUS='INFORCE' Order by B.EFFECTIVE_DATE"
                                    End If
                                End If
                            End If
                        End If
                        
                        cmd.CommandTimeout = 800000
                        Dim sdp As New SqlDataAdapter(cmd)
                        sdp.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Me.dgvACDetails.DataSource = dt
                            With Me.dgvACDetails
                                .Columns(0).Visible = False
                                .Columns(1).HeaderText = "FILE #"
                                .Columns(2).HeaderText = "EFFECTIVE DATE"
                                .Columns(3).HeaderText = "CANCELLATION DATE"
                                .Columns(4).HeaderText = "POLICY HOLDER NAME"
                                .Columns(5).HeaderText = "POLICY HOLDER IC"
                                .Columns(6).HeaderText = "AGENT CODE"
                                .Columns(7).HeaderText = "PLAN CODE"
                                .Columns(8).HeaderText = "PLAN CODE (LEVEL 2)"
                                .Columns(9).HeaderText = "PREMIUM "
                                .Columns(9).DefaultCellStyle.Format = "###,###.00"
                                .Columns(10).HeaderText = "DEDUCTION MONTH"
                                .Columns(11).Visible = False
                                .Columns(12).Visible = False
                            End With
                        End If
                    Else
                        MsgBox("Receiving Month-To is < Receiving Month-From.")
                        Me.txtRMTO.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Request Timeout")
                End Try
            End If
        End If
    End Sub
    Private Sub getReceived_DateReport()
        Dim dt As New DataTable

        Dim cmd As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        cmd.CommandType = CommandType.Text
        Me.dgvACDetails.DataSource = Nothing
        Me.dgvACDetails.DataMember = Nothing
        If Me.cbManager.Text = "ALL" Then
            cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                  "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage, phone_hse, phone_mobile, Phone_off, Email " & _
                                                  "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                  "WHERE substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                  "AND Proposal_Received_Date >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Proposal_Received_Date<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                  "Order by Proposal_Received_Date"
        Else
            If Me.cbSupervisor.Text = "ALL" Then
                If Me.cbAgent.Text = "ALL" Then
                    cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                          "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage, phone_hse, phone_mobile, Phone_off, Email " & _
                                                          "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                          "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "') " & _
                                                          "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                          "AND Proposal_Received_Date >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Proposal_Received_Date<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                          "Order by Proposal_Received_Date"
                Else
                    cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                  "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage, phone_hse, phone_mobile, Phone_off, Email " & _
                                  "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                  "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "' AND SUPERVISOR_ID='" & Me.cbSupervisor.SelectedValue & "' AND TB_AGENT_ID='" & Me.cbAgent.SelectedValue & "') " & _
                                  "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                  "AND Proposal_Received_Date >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Proposal_Received_Date<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                  "Order by Proposal_Received_Date"
                End If
            Else
                cmd.CommandText = "SELECT B.ID, B.ANGKASA_FILENO, B.PROPOSAL_RECEIVED_DATE, B.Submission2Angkasa_On, B.FULL_NAME, B.IC_NEW, A.AGENT_CODE, " & _
                                                                      "B.PLAN_CODE, B.LEVEL2_PLAN_CODE, B.PREMIUM, B.STATUS, B.decline_reason, a.Agent_share_percentage, phone_hse, phone_mobile, Phone_off, Email " & _
                                                                      "FROM dt_Proposer_Agent_Commission A INNER JOIN DT_PROPOSER B ON A.PROPOSER_ID=B.ID " & _
                                                                      "WHERE AGENT_CODE IN (SELECT AGENT_CODE FROM TB_AGENT WHERE Manager_ID='" & Me.cbManager.SelectedValue & "') " & _
                                                                      "and substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                                      "AND Proposal_Received_Date >='" & Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy") & "' and Proposal_Received_Date<DATEADD(DAY,1,'" & Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy") & "') " & _
                                                                      "Order by Proposal_Received_Date"
            End If
        End If
        
        cmd.CommandTimeout = 800000
        Dim sdp As New SqlDataAdapter(cmd)
        sdp.Fill(dt)

        If dt.Rows.Count > 0 Then
            Me.dgvACDetails.DataSource = dt
            With Me.dgvACDetails
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "FILE #"
                .Columns(2).HeaderText = "DATE RECEIVED"
                .Columns(3).HeaderText = "SUBMISSION DATE"
                .Columns(4).HeaderText = "POLICY HOLDER NAME"
                .Columns(5).HeaderText = "POLICY HOLDER IC"
                .Columns(6).HeaderText = "AGENT CODE"
                .Columns(7).HeaderText = "PLAN CODE"
                .Columns(8).HeaderText = "PLAN CODE (LEVEL 2)"
                .Columns(9).HeaderText = "PREMIUM "
                .Columns(10).HeaderText = "STATUS"
                .Columns(11).HeaderText = "DECLINE REASON"
                .Columns(9).DefaultCellStyle.Format = "###,###.00"
                .Columns(12).Visible = False
                .Columns(13).HeaderText = "PHONE HOUSE"
                .Columns(14).HeaderText = "PHONE MOBILE"
                .Columns(15).HeaderText = "PHONE OFFICE"
                .Columns(16).HeaderText = "EMAIL"

            End With
        Else
            MsgBox("No Record Found")
            Me.dgvACDetails.Columns.Clear()
        End If
    End Sub
    Private Sub llXport2Xcel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llXport2Xcel.LinkClicked
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        If Me.rbSubmissionofDate.Checked Then
            Xport2Xcel()
        ElseIf Me.rbEffectiveDate.Checked Then
            Xport2Xcel2()
        ElseIf Me.rbReceivedMonth.Checked Then
            Xport2Xcel1()
        ElseIf Me.rbReceivedDate.Checked Then
            Xport2Xcel3()
        End If
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        MsgBox("Exporting STATMENT OF AGENT COMMISSION IS completed.")
    End Sub
    Private Sub Xport2Xcel3()
        If Me.cbProduct.Text = "CUEPACSCARE" Then
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF PROPOSAL RECEIVED DATE: " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")


                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "DATE RECEIVED"
                    .Cells(7, 4) = "SUBMISSION DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "COMMISSION (%)"
                    .Cells(7, 12) = "COMMISSION (RM)"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(12).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & .Rows(i).Cells(12).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) And Not IsDBNull(.Rows(i).Cells(12).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & Format(.Rows(i).Cells(9).Value * .Rows(i).Cells(12).Value / 100, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(15).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 15) = "'" & .Rows(i).Cells(15).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(16).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 16) = "'" & .Rows(i).Cells(16).Value
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        Else
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF PROPOSAL RECEIVED DATE : " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")

                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "DATE RECEIVED"
                    .Cells(7, 4) = "SUBMISSION DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "NO.OF SPOUSE"
                    .Cells(7, 12) = "NO.OF CHILDREN"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(15).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 15) = "'" & .Rows(i).Cells(15).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(16).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 16) = "'" & .Rows(i).Cells(16).Value
                        End If

                        Dim dtS As New DataTable
                        dtS = _objBusi.getDetails("PROPOSER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "SPOUSE", Conn)
                        If dtS.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & dtS.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & 0
                        End If

                        Dim dtC As New DataTable
                        dtC = _objBusi.getDetails("PROPOSER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "CHILDRED", Conn)
                        If dtC.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & dtC.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 0
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        End If
    End Sub
    Private Sub Xport2Xcel()
        If Me.cbProduct.Text = "CUEPACSCARE" Then
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF SUBMISSION : " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")


                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "DATE RECEIVED"
                    .Cells(7, 4) = "SUBMISSION DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "COMMISSION (%)"
                    .Cells(7, 12) = "COMMISSION (RM)"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(12).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & .Rows(i).Cells(12).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) And Not IsDBNull(.Rows(i).Cells(12).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & Format(.Rows(i).Cells(9).Value * .Rows(i).Cells(12).Value / 100, "Standard")
                        End If

                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(15).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 15) = "'" & .Rows(i).Cells(15).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(16).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 16) = "'" & .Rows(i).Cells(16).Value
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        Else
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF SUBMISSION : " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")

                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "DATE RECEIVED"
                    .Cells(7, 4) = "SUBMISSION DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "NO.OF SPOUSE"
                    .Cells(7, 12) = "NO.OF CHILDREN"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(15).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 15) = "'" & .Rows(i).Cells(15).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(16).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 16) = "'" & .Rows(i).Cells(16).Value
                        End If
                        Dim dtS As New DataTable
                        dtS = _objBusi.getDetails("PROPOSER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "SPOUSE", Conn)
                        If dtS.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & dtS.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & 0
                        End If

                        Dim dtC As New DataTable
                        dtC = _objBusi.getDetails("PROPOSER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "CHILDRED", Conn)
                        If dtC.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & dtC.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 0
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        End If
    End Sub
    Private Sub Xport2Xcel2()
        If Me.cbProduct.Text = "CUEPACSCARE" Then
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF EFFECTIVE DATE'S: " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")


                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "EFFECTIVE DATE"
                    .Cells(7, 4) = "EXPIRY DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "COMMISSION (%)"
                    .Cells(7, 12) = "COMMISSION (RM)"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(10).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & .Rows(i).Cells(10).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) And Not IsDBNull(.Rows(i).Cells(10).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & Format(.Rows(i).Cells(9).Value * .Rows(i).Cells(10).Value / 100, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        Else
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF EFFECTIVE DATE'S : " & Format(Me.dtpPeriodFrm.Value, "dd/MM/yyyy") & " To " & Format(Me.dtpPeriodTo.Value, "dd/MM/yyyy")

                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "EFFECTIVE DATE"
                    .Cells(7, 4) = "EXPIRY DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLACE CODE (LEVEL2)"
                    .Cells(7, 10) = "PREMIUM (RM)"
                    .Cells(7, 11) = "NO.OF SPOUSE"
                    .Cells(7, 12) = "NO.OF CHILDREN"
                    .Cells(7, 13) = "PHONE HOUSE"
                    .Cells(7, 14) = "PHONE MOBILE"
                    .Cells(7, 15) = "PHONE OFFICE"
                    .Cells(7, 16) = "EMAIL"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(13).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & .Rows(i).Cells(13).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(14).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 14) = "'" & .Rows(i).Cells(14).Value
                        End If
                        Dim dtS As New DataTable
                        dtS = _objBusi.getDetails("MEMBER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "SPOUSE", Conn)
                        If dtS.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & dtS.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & 0
                        End If

                        Dim dtC As New DataTable
                        dtC = _objBusi.getDetails("MEMBER", .Rows(i).Cells(0).Value.ToString.Trim(), "", "", "", "CHILDRED", Conn)
                        If dtC.Rows.Count > 0 Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & dtC.Rows.Count
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 0
                        End If
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        End If
    End Sub
    Private Sub Xport2Xcel1()
        If Me.cbProduct.Text = "CUEPACSCARE" Then
            If Me.dgvACDetails.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim xRCount As Integer = 8
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim xName As String = ""
                xWB.Worksheets.Add()
                xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                With xWB.Worksheets(xName)
                    .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                    .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                    .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                    .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                    .Cells(5, 1) = "PERIOD OF RECEIVING MONTH'S : " & Me.txtRMFROM.Text.Trim & " TO " & Me.txtRMTO.Text.Trim


                    .Cells(7, 1) = "NO"
                    .Cells(7, 2) = "FILE #"
                    .Cells(7, 3) = "EFFECTIVE DATE"
                    .Cells(7, 4) = "EXPIRY DATE"
                    .Cells(7, 5) = "POLICY HOLDER NAME"
                    .Cells(7, 6) = "POLICYHOLDER I/C"
                    .Cells(7, 7) = "AGENT CODE"
                    .Cells(7, 8) = "PLAN CODE"
                    .Cells(7, 9) = "PLAN CODE (LEVEL2)"
                    .Cells(7, 10) = "DEDUCTION MONTH"
                    .Cells(7, 11) = "PREMIUM (RM)"
                    .Cells(7, 12) = "COMMISSION (%)"
                    .Cells(7, 13) = "COMMISSION (RM)"
                End With
                With Me.dgvACDetails
                    Do While i < .Rows.Count - 1
                        xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                        If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                        End If
                        If Not IsDBNull(.Rows(i).Cells(10).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(10).Value)
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                            xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                        End If
                        If Not IsDBNull(.Rows(i).Cells(10).Value) Then
                            If (IsDBNull(.Rows(i).Cells(12).Value.ToString().Trim()) Or Len(.Rows(i).Cells(12).Value.ToString().Trim()) = 0) Then
                                xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 2
                            Else
                                xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & .Rows(i).Cells(11).Value
                            End If
                        End If
                        If Not IsDBNull(.Rows(i).Cells(9).Value) And Not IsDBNull(.Rows(i).Cells(11).Value) Then
                            If (IsDBNull(.Rows(i).Cells(12).Value.ToString().Trim()) Or Len(.Rows(i).Cells(12).Value.ToString().Trim()) = 0) Then
                                xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & Format(.Rows(i).Cells(9).Value * 2 / 100, "Standard")
                            Else
                                xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & Format(.Rows(i).Cells(9).Value * .Rows(i).Cells(11).Value / 100, "Standard")
                            End If
                        End If
                        
                        xRCount += 1
                        i += 1
                    Loop
                End With
                xApp.Visible = True
            End If
        Else
            CPAACxPort2Xcel()
            
        End If
    End Sub
    Private Sub CPAACxPort2Xcel()

        If Me.dgvACDetails.Rows.Count > 0 Then
            Dim i As Integer = 0
            Dim xRCount As Integer = 8
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xName As String = ""
            xWB.Worksheets.Add()
            xName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xName)
                .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                .Cells(2, 1) = "MANAGER : " & Me.cbManager.Text
                .Cells(3, 1) = "SUPERVISOR : " & Me.cbSupervisor.Text
                .Cells(4, 1) = "AGENT : " & Me.cbAgent.Text
                .Cells(5, 1) = "PERIOD OF RECEIVING MONTH'S : " & Me.txtRMFROM.Text.Trim & " TO " & Me.txtRMTO.Text.Trim

                .Cells(7, 1) = "NO"
                .Cells(7, 2) = "FILE #"
                .Cells(7, 3) = "EFFECTIVE DATE"
                .Cells(7, 4) = "EXPIRY DATE"
                .Cells(7, 5) = "POLICY HOLDER NAME"
                .Cells(7, 6) = "POLICYHOLDER I/C"
                .Cells(7, 7) = "AGENT CODE"
                .Cells(7, 8) = "PLAN CODE"
                .Cells(7, 9) = "PLACE CODE (LEVEL2)"
                .Cells(7, 10) = "DEDUCTION MONTH"
                .Cells(7, 11) = "PREMIUM (RM)"
                .Cells(7, 12) = "COMMISSION (%)"
                .Cells(7, 13) = "COMMISSION (RM)"
            End With
            With Me.dgvACDetails
                Do While i < .Rows.Count - 1
                    xWB.Worksheets(xName).Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                    If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 2) = "'" & .Rows(i).Cells(1).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(2).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 3) = "'" & Format(.Rows(i).Cells(2).Value, "dd/MM/yyyy")
                    End If
                    If Not IsDBNull(.Rows(i).Cells(3).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 4) = "'" & Format(.Rows(i).Cells(3).Value, "dd/MM/yyyy")
                    End If
                    If Not IsDBNull(.Rows(i).Cells(4).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 5) = "'" & .Rows(i).Cells(4).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(5).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 6) = "'" & .Rows(i).Cells(5).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(6).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 7) = "'" & .Rows(i).Cells(6).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(7).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 8) = "'" & .Rows(i).Cells(7).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(8).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 9) = "'" & .Rows(i).Cells(8).Value
                    End If
                    If Not IsDBNull(.Rows(i).Cells(10).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 10) = "'" & Format(.Rows(i).Cells(10).Value)
                    End If
                    If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                        xWB.Worksheets(xName).Cells(xRCount, 11) = "'" & Format(.Rows(i).Cells(9).Value, "Standard")
                    End If
                    If Not IsDBNull(.Rows(i).Cells(9).Value) Then
                        If (IsDBNull(.Rows(i).Cells(11).Value.ToString().Trim()) Or Len(.Rows(i).Cells(11).Value.ToString().Trim()) = 0) Then
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 7
                        Else
                            xWB.Worksheets(xName).Cells(xRCount, 12) = "'" & 7

                        End If
                    End If
                    If Not IsDBNull(.Rows(i).Cells(9).Value) And Not IsDBNull(.Rows(i).Cells(11).Value) Then
                        If (IsDBNull(.Rows(i).Cells(11).Value.ToString().Trim()) Or Len(.Rows(i).Cells(11).Value.ToString().Trim()) = 0) Then
                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & Format(.Rows(i).Cells(9).Value * 7 / 100, "Standard")
                        Else

                            xWB.Worksheets(xName).Cells(xRCount, 13) = "'" & Format(.Rows(i).Cells(9).Value * 7 / 100, "Standard")
                        End If
                    End If
                    xRCount += 1
                    i += 1
                Loop
            End With
            xApp.Visible = True
        End If
    End Sub
    Private Sub rbSubmissionofDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSubmissionofDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbEffectiveDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEffectiveDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedMonth.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbChanged()
        If Me.rbSubmissionofDate.Checked Then
            Me.lblPeriod.Text = "Period of Submission Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
        ElseIf Me.rbEffectiveDate.Checked Then
            Me.lblPeriod.Text = "Period of Effective Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
        ElseIf Me.rbReceivedMonth.Checked Then
            Me.lblPeriod.Text = "Period of Received Month"
            Me.dtpPeriodFrm.Visible = False
            Me.dtpPeriodTo.Visible = False
            Me.txtRMFROM.Visible = True
            Me.txtRMTO.Visible = True
            Me.txtRMFROM.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
            Me.txtRMTO.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
        ElseIf Me.rbReceivedDate.Checked Then
            Me.lblPeriod.Text = "Period of Received Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
        End If
    End Sub
    Private Sub Xport2Xcel11()
        If Me.dgvACDetails.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim cmdSelect_PolicyHolders As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_PolicyHolders.CommandType = CommandType.Text
            If Me.cbManager.Text = "ALL" Then
                cmdSelect_PolicyHolders.CommandText = "SELECT Angkasa_FileNo, Full_Name, IC_New, Agent_Code, Agent_Name, Angkasa_Bulan_Potongan, " & _
                                                                  "Angkasa_Kod_Potongan, Angkasa_Jumlah_Pokok, Submission_Date, Effective_Date, Cancellation_Date " & _
                                                                  "FROM vi_Member_Policy_MonthlyDeduction_with_AgentInfo " & _
                                                                  "WHERE substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                                  "AND Receiving_Month BETWEEN '" & Me.txtRMFROM.Text & "' " & _
                                                                  "AND '" & Me.txtRMTO.Text & "' " & _
                                                                  "ORDER BY Agent_Code, Angkasa_FileNo"
            Else
                cmdSelect_PolicyHolders.CommandText = "SELECT Angkasa_FileNo, Full_Name, IC_New, Agent_Code, Agent_Name, Angkasa_Bulan_Potongan, " & _
                                                  "Angkasa_Kod_Potongan, Angkasa_Jumlah_Pokok, Submission_Date, Effective_Date, Cancellation_Date " & _
                                                  "FROM vi_Member_Policy_MonthlyDeduction_with_AgentInfo " & _
                                                  "WHERE AGENT_CODE=(SELECT top 1 AGENT_CODE FROM TB_AGENT WHERE (TB_AGENT_ID='" & Me.cbManager.SelectedValue & "' or Manager_ID='" & Me.cbManager.SelectedValue & "')) " & _
                                                  "AND substring(PLAN_CODE, 0,12)='" & Me.cbProduct.Text & "' " & _
                                                  "AND Receiving_Month BETWEEN '" & Me.txtRMFROM.Text & "' " & _
                                                  "AND '" & Me.txtRMTO.Text & "' " & _
                                                  "ORDER BY Agent_Code, Angkasa_FileNo"
            End If

            Dim da_PolicyHolder As New SqlDataAdapter(cmdSelect_PolicyHolders)

            Dim ds_AgentReport2xls As New DataSet
            da_PolicyHolder.Fill(ds_AgentReport2xls, "vi_Member_Policy_MonthlyDeduction_with_AgentInfo")

            Dim xls_wks_name As String = ""

            Dim xls_row_counter As Integer = 0
            Dim var_name_count As Integer = 0
            Dim var_Agent_Code As String = ""


            Dim var_Commmission As Double = 0.0
            Dim var_Percentage As Double = 0.0
            Dim n_Year As Int16 = 0
            Dim n_Month As Int16 = 0

            xls_file.Visible = True

            Do While var_name_count < ds_AgentReport2xls.Tables("vi_Member_Policy_MonthlyDeduction_with_AgentInfo").Rows.Count
                With ds_AgentReport2xls.Tables("vi_Member_Policy_MonthlyDeduction_with_AgentInfo").Rows(var_name_count)
                    If var_Agent_Code <> .Item("Agent_Code").ToString.Trim Then
                        xls_workbook.Worksheets.Add()
                        xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                        var_Agent_Code = .Item("Agent_Code").ToString.Trim
                        Dim var_Agent_Name As String = .Item("Agent_Name").ToString.Trim

                        With xls_workbook.Worksheets(xls_wks_name)
                            .Cells(1, 1) = "STATEMENT OF AGENT COMMISSION FOR " & Me.cbProduct.Text
                            .Cells(2, 1) = "AGENT CODE: " & var_Agent_Code.Trim & " / AGENT NAME: " & var_Agent_Name.Trim
                            .Cells(3, 1) = "FOR THE MONTH (RECEIVING MONTH): " & Me.txtRMFROM.Text.Trim & " TO " & Me.txtRMTO.Text.Trim

                            .Cells(5, 1) = "NO"
                            .Cells(5, 2) = "FILE NO."
                            .Cells(5, 3) = "SUBMISSION DATE"
                            .Cells(5, 4) = "POLICYHOLDER NAME"
                            .Cells(5, 5) = "POLICYHOLDER I/C"
                            .Cells(5, 6) = "AGENT CODE"
                            .Cells(5, 7) = "DEDUCTION MONTH"
                            .Cells(5, 8) = "DEDUCTION CODE"
                            .Cells(5, 9) = "EFFECTIVE DATE"
                            .Cells(5, 10) = "CANCELLATION DATE"
                            .Cells(5, 11) = "PREMIUM (RM)"
                            .Cells(5, 12) = "COMMISSION (%)"
                            .Cells(5, 13) = "COMMISSION (RM)"
                            .Cells(5, 14) = "N-th MONTH"

                            xls_row_counter = 6
                        End With
                    End If

                    If IsDBNull(.Item("Submission_Date")) = True Or Len(.Item("Submission_Date").ToString.Trim) = 0 Then
                        var_Commmission = .Item("Angkasa_Jumlah_Pokok") * 2 / 100
                        var_Percentage = 2.0
                    Else
                        var_Commmission = .Item("Angkasa_Jumlah_Pokok") * 4 / 100
                        var_Percentage = 4.0
                    End If

                    If IsDBNull(.Item("Effective_Date")) = False Then
                        n_Year = 0
                        n_Month = 0

                        n_Year = Val(.Item("Angkasa_Bulan_Potongan").ToString.Substring(0, 4)) - Val(Year(.Item("Effective_Date")).ToString)
                        n_Month = Val(.Item("Angkasa_Bulan_Potongan").ToString.Substring(4, 2)) - Val(Month(.Item("Effective_Date")).ToString)
                    Else
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = 0 - Val(.Item("Angkasa_Bulan_Potongan").ToString)
                    End If

                    If (var_Percentage = 2.0 And (n_Year * 12 + n_Month + 1) > 12 And (n_Year * 12 + n_Month + 1) < 37) Or (var_Percentage = 4.0) Then
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 5).ToString.Trim
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & .Item("Angkasa_FileNo").ToString.Trim
                        If IsDBNull(.Item("Submission_Date")) = False Then
                            xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & Format(.Item("Submission_Date"), "dd/MM/yyyy")
                        Else
                            xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & .Item("Submission_Date")
                        End If
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = .Item("Full_Name").ToString.Trim
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Item("IC_New").ToString.Trim
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & .Item("Agent_Code").ToString.Trim
                        Dim sRes As String
                        sRes = .Item("Angkasa_Bulan_Potongan").ToString.Trim
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & .Item("Angkasa_Bulan_Potongan").ToString.Trim
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Item("Angkasa_Kod_Potongan").ToString.Trim
                        If IsDBNull(.Item("Effective_Date")) = False Then
                            xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & Format(.Item("Effective_Date"), "dd/MM/yyyy")
                        Else
                            xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & .Item("Effective_Date")
                        End If
                        If IsDBNull(.Item("Cancellation_Date")) = False Then
                            xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 10) = "'" & Format(.Item("Cancellation_Date"), "dd/MM/yyyy")
                           
                        End If
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 11) = "'" & Format(.Item("Angkasa_Jumlah_Pokok"), "#,##0.00")
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 12) = "'" & Format(var_Percentage, "##0.00")
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 13) = Format(var_Commmission, "##0.00")

                        If var_Percentage = 4.0 Then
                            If IsDBNull(.Item("Effective_Date")) = True Then
                                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = "ERR"
                            Else
                                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = "***"
                            End If
                        Else
                            If IsDBNull(.Item("Effective_Date")) = True Then
                                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = "ERR"
                            Else
                                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = n_Year * 12 + n_Month + 1
                            End If
                        End If

                        var_Commmission = 0.0
                        xls_row_counter += 1
                    End If
                End With
                var_name_count += 1
            Loop

            MsgBox("Exporting records to STATEMENT OF AGENT COMMISSION FOR CUEPACSCARE (0531/0532) completed.")

        End If
    End Sub
#Region "Progress Bar"
    Private Shared SharedData As New SharedObject()
    Protected Overridable Sub StartMarqueeThread()
        Dim t As New Threading.Thread(AddressOf ShowMarqueeForm)
        t.Start()
    End Sub
    Protected Overridable Sub ShowMarqueeForm()
        Dim L As New Loading()
        L.Show()
        L.Update()
        Do
            SyncLock SharedData
                If SharedData.ReadyToHideMarquee Then
                    Exit Do
                End If
            End SyncLock
            Application.DoEvents()
        Loop
    End Sub
    Private Class SharedObject
        Public ReadyToHideMarquee As Boolean
    End Class
#End Region
End Class