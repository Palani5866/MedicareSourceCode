Imports System.Windows.Forms
Public Class dlgPremium_Renewal
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub dlgPremium_Renewal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgPremium_Renewal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        btnPrint_YearlyLetter.Enabled = False

    End Sub
#End Region
#Region "Data Bind"
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)

        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text

        Me.GrpBox_Payment_Details.Enabled = False
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtDOB.Clear()
        Me.txtAge.Clear()
        Me.txtL2_Plan_Code.Clear()
        Me.txtRenewal_Premium.Clear()
        Me.txtPolicy_EffectiveDate.Clear()
        Me.txtPolicy_ExpiryDate.Clear()

        Me.dtpRequestedDate.MaxDate = DateTime.Today

        Me.rdCash.Checked = True
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Enabled = True
        Me.txtRenewal_Premium_New.Clear()
        Me.txtPayment_CreditCard_BatchNo.Clear()
        Me.txtPayment_CreditCard_ApprCode.Clear()
        Me.txtPayment_CreditCard_Inv_No.Clear()
        Me.txtPayment_Cheque_No.Clear()
        Me.txtPayment_Cheque_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_IssuedBy.Clear()

        If Search_Param1 = "Null" Then
            If Me.dgvPolicies.Rows.Count > 0 Then
                Me.dgvPolicies.DataSource = Nothing
                Me.dgvPolicies.DataMember = Nothing
            End If
            Exit Sub
        Else
            cmdSelect_Member_Policy.CommandText = "SELECT b.ID, b.Angkasa_FileNo, a.Full_Name, a.IC_New, b.Deduction_Code, " & _
                                                  "b.Deduction_Amount, b.Agent_Code, b.Submission_Date, b.Effective_Date, " & _
                                                  "b.Cancellation_Date, b.Policy_No, a.Birth_Date " & _
                                                  "FROM dt_member a INNER JOIN dt_member_policy b ON b.member_id=a.id " & _
                                                  "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                                  "AND b.Deduction_Code LIKE 'Y%' " & _
                                                  "ORDER BY b.Deduction_Code"

        End If

        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)


        Dim ds_MemberInfo As New DataSet

        da_Member_Policy.Fill(ds_MemberInfo, "dt_member")

        With Me.dgvPolicies
            .DataSource = ds_MemberInfo
            .DataMember = "dt_member"

            .Columns(0).Visible = False
            .Columns(11).Visible = False

            .Columns(1).HeaderText = "File No."
            .Columns(2).HeaderText = "Full Name"
            .Columns(3).HeaderText = "IC (New)"
            .Columns(4).HeaderText = "Product Code"
            .Columns(5).HeaderText = "Requested Amount"
            .Columns(6).HeaderText = "Agent Code"
            .Columns(7).HeaderText = "Submission Date"
            .Columns(8).HeaderText = "1st Payment Date"
            .Columns(9).HeaderText = "Cancellation Date"
            .Columns(10).HeaderText = "Policy/Certificate No."

            .Columns(5).DefaultCellStyle.Format = "#,##0.00"

            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsb_Filter_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
        Select Case Me.tsb_Filter.SelectedItem
            Case "IC"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.Populate_Grid("IC_New", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case "Full Name"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.Populate_Grid("Full_Name", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case Else
                Me.Populate_Grid("Null", "")
        End Select
    End Sub
    Private Sub dgvPolicies_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicies.CellClick
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtDOB.Clear()
        Me.txtAge.Clear()
        Me.txtL2_Plan_Code.Clear()
        Me.txtRenewal_Premium.Clear()
        Me.txtPolicy_EffectiveDate.Clear()
        Me.txtPolicy_ExpiryDate.Clear()
        Me.dtpRequestedDate.MaxDate = DateTime.Today

        Me.rdCash.Checked = True
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Enabled = True
        Me.txtRenewal_Premium_New.Clear()
        Me.txtPayment_CreditCard_BatchNo.Clear()
        Me.txtPayment_CreditCard_ApprCode.Clear()
        Me.txtPayment_CreditCard_Inv_No.Clear()
        Me.txtPayment_Cheque_No.Clear()
        Me.txtPayment_Cheque_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_IssuedBy.Clear()

        If e.RowIndex = -1 Then
            Me.GrpBox_Payment_Details.Enabled = False
            Exit Sub
        Else
            Me.GrpBox_Payment_Details.Enabled = True
            With Me.dgvPolicies.Rows(e.RowIndex)
                Me.lblMemberPolicy_ID.Text = .Cells(0).Value.ToString.Trim
                Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                Me.txtName.Text = .Cells(2).Value.ToString.Trim
                Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                If Len(.Cells(11).Value.ToString.Trim) > 0 Then
                    Me.txtDOB.Text = Format(.Cells(11).Value, "dd/MM/yyyy")
                End If
                If Len(.Cells(11).Value.ToString.Trim) > 0 Then
                    Me.txtAge.Text = Now().Year - Convert.ToDateTime(.Cells(11).Value).Year
                End If
                Me.txtL2_Plan_Code.Text = .Cells(4).Value.ToString.Trim
                If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                    Dim dt As New DataTable
                    dt = _objBusi.fgetPolicyPremium(.Cells(0).Value.ToString.Trim, Format(.Cells(9).Value, "MM/dd/yyyy"), Conn)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0)(0)) Then
                            Me.txtRenewal_Premium.Text = dt.Rows(0)(0)
                            Me.txtRenewal_Premium_New.Text = dt.Rows(0)(0)
                            Dim Premium, GST, TotPremium As Decimal
                            Premium = dt.Rows(0)(0)
                            GST = Premium * 6 / 100
                            TotPremium = Premium + GST
                            Me.txtGST.Text = GST
                            Me.txtTotalPremium.Text = TotPremium
                        Else
                            Me.txtRenewal_Premium.Text = Format(.Cells(5).Value, "#,##0.00")
                            Me.txtRenewal_Premium_New.Text = Format(.Cells(5).Value, "#,##0.00")
                            Dim Premium, GST, TotPremium As Decimal
                            Premium = Format(.Cells(5).Value, "#,##0.00")
                            GST = Premium * 6 / 100
                            TotPremium = Premium + GST
                            Me.txtGST.Text = GST
                            Me.txtTotalPremium.Text = TotPremium
                        End If
                    Else
                        Me.txtRenewal_Premium.Text = Format(.Cells(5).Value, "#,##0.00")
                        Me.txtRenewal_Premium_New.Text = Format(.Cells(5).Value, "#,##0.00")
                        Dim Premium, GST, TotPremium As Decimal
                        Premium = Format(.Cells(5).Value, "#,##0.00")
                        GST = Premium * 6 / 100
                        TotPremium = Premium + GST
                        Me.txtGST.Text = GST
                        Me.txtTotalPremium.Text = TotPremium
                    End If
                    
                    Me.cbGST.Checked = True
                End If
                If Len(.Cells(8).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_EffectiveDate.Text = Format(.Cells(8).Value, "dd/MM/yyyy")
                End If
                If Len(.Cells(9).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_ExpiryDate.Text = Format(.Cells(9).Value, "dd/MM/yyyy")
                End If
                Me.OK_Button.Enabled = True

            End With
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.Verify_Payment_Details = True Then
            Dim dt As New DataTable
            dt = _objBusi.Check("RENEW", Me.lblMemberPolicy_ID.Text.Trim(), "", "", "", "", "", "", "", "", "", Conn)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)("PSTATUS").ToString().Trim()
                    Case "0"
                        MsgBox("We are soory, we unable to renew this policy due to policy has been cancelled or change of plan!, Please contact your admin!")
                        Exit Sub
                    Case "1"
                    Case "2"
                        MsgBox("We are soory, we unable to renew this policy due to SPOUSE OVER AGE!, Please contact your Admin or change the plan!")
                        Exit Sub
                    Case "3"
                        MsgBox("We are soory, we unable to renew this policy due to SPOUSE OVER AGE!, Please contact your Admin or remove Spouse using endorsement!")
                        Exit Sub
                End Select
            End If

            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Renew_Premium_Yearly = True Then
                        btnPrint_YearlyLetter.Enabled = True
                        Me.OK_Button.Enabled = False
                        Me.dgvPolicies.Enabled = False
                        MsgBox("Renewal successfully completed.")

                    End If
                Case 7
                    Exit Sub
            End Select

        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnPrint_YearlyLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_YearlyLetter.Click
        Select Case Me.txtL2_Plan_Code.Text.ToString().Trim().Substring(1, 1)
            Case "0"
                PrintLetters.Print_Letters("YearlyACLetter.rpt", Me.lblMemberPolicy_ID.Text.Trim, "YEARLYRENEWAL")
            Case Else
                PrintLetters.Print_Letters("YearlyACLetterO.rpt", Me.lblMemberPolicy_ID.Text.Trim, "YEARLYRENEWAL")
        End Select
        ClearAll()
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
    Private Sub rdCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCash.CheckedChanged
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Enabled = True
    End Sub
    Private Sub rdCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCheque.CheckedChanged
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Enabled = True
        Me.GrpBox_Payment_Details_Cash.Enabled = False
    End Sub
    Private Sub rdCC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCC.CheckedChanged
        Me.GrpBox_Payment_Details_CreditCard.Enabled = True
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Enabled = False
    End Sub
#End Region
#Region "Renewal"
    Private Function Renew_Premium_Yearly() As Boolean

        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdInsert_MemberPolicy As SqlCommandBuilder
        cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)



        Dim cmdSelect_MemberPolicy_YearlyRenewal As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy_YearlyRenewal.CommandType = CommandType.Text
        cmdSelect_MemberPolicy_YearlyRenewal.CommandText = "SELECT * FROM dt_Member_Policy_YearlyRenewal " & _
                                                        "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberPolicy_YearlyRenewal As New SqlDataAdapter(cmdSelect_MemberPolicy_YearlyRenewal)

        Dim cmdInsert_MemberPolicy_YearlyRenewal As SqlCommandBuilder
        cmdInsert_MemberPolicy_YearlyRenewal = New SqlCommandBuilder(da_MemberPolicy_YearlyRenewal)



        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)



        Dim ds_Renewal As New DataSet


        Try
            da_MemberPolicy.Fill(ds_Renewal, "dt_Member_Policy")
            da_MemberPolicy_YearlyRenewal.Fill(ds_Renewal, "dt_Member_Policy_YearlyRenewal")
            da_MemberLog.Fill(ds_Renewal, "log_Member")
            If ds_Renewal.Tables("dt_member_policy").Rows(0)("status").ToString.Trim() = "Lapse" Then
                Select Case My.Settings.Username.Trim()
                    Case "admin"
                    Case Else
                        MsgBox("Sorry can't process. This Policy has been lapse or Your not authorized to do this. Please check with your admin")
                        Exit Function
                End Select
            End If
            Dim eDate, pNextRenewal As String
            Dim cYear, nextYear, pYear, pMonth, cMonth1 As Integer
            cMonth1 = Now.Month()
            If cMonth1 = 12 Then
                nextYear = Now.Year() + 2
                cYear = Now.Year() + 1
            ElseIf cMonth1 = 11 Then
                nextYear = Now.Year() + 2
                cYear = Now.Year()
            Else
                nextYear = Now.Year() + 1
                cYear = Now.Year()
            End If
            Dim cY, nY, pY As String
            cY = cYear
            nY = nextYear
            pY = pYear
            If Not IsDBNull(ds_Renewal.Tables("dt_member_policy").Rows(0)("Cancellation_Date")) Then
                eDate = ds_Renewal.Tables("dt_member_policy").Rows(0)("Cancellation_Date")
                pYear = Year(eDate)
                pMonth = Month(eDate)
                If pMonth < 12 Then
                    cYear = Now.Year()
                End If
                pNextRenewal = DateAdd(DateInterval.Month, -3, Convert.ToDateTime(eDate))
                If pYear = nextYear Then
                    MsgBox("Sorry can't process. This Policy has been renewed. Next Renewal Date is : " & pNextRenewal)
                    Exit Function
                Else
                    Dim exDate, exYear1, exMonth1 As String
                    Dim exYear, exMonth, cMonth, RSM As Integer
                    If pMonth <= cMonth1 Then
                        exDate = DateAdd(DateInterval.Day, +60, Convert.ToDateTime(eDate))
                    Else
                        exDate = eDate
                    End If
                    exYear = Year(exDate)
                    If Now.Month() = 12 Then
                        exMonth = 13
                    Else
                        exMonth = Month(exDate)
                    End If
                    cMonth = Now.Month()
                    exYear1 = exYear
                    exMonth1 = exMonth

                    Dim SRI, RenewalStartMonth, RSM1, RSY As String
                    If Not (My.Settings.Username = "admin") Then
                        RSY = Year(DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate)))
                        RenewalStartMonth = DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate))
                        RSM = Month(DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate)))
                        RSM1 = cMonth
                        If exYear = nextYear And cMonth <> 11 Then
                            MsgBox("Sorry can't process. This Policy has been renewed. Next Renewal Date is : " & pNextRenewal)
                            Exit Function
                        ElseIf exYear < cYear And exMonth <> 12 And exMonth <> 11 Then
                            MsgBox("EXM" & exMonth & " " & exYear & "CM " & cMonth & " " & nextYear)
                            MsgBox("Sorry can't process. This policy has been lapse!. Please check with administrator")
                            Exit Function
                        ElseIf exMonth < cMonth And cMonth <> 11 Then
                            If ds_Renewal.Tables("dt_Member_Policy").Rows(0)("Status") = "Lapse" Then
                                MsgBox("Sorry can't process. This policy renewal period closed. Please contact administrator")
                                Exit Function
                            End If
                        ElseIf exYear = RSY And cMonth < RSM And RSY >= cYear Then
                            MsgBox("Sorry can't process. This Policy has been renewed. Next Renewal Date is : " & pNextRenewal)
                            Exit Function
                        Else

                            With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                                If IsDBNull(.Item("Cancellation_Date")) Then
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                                Else
                                    .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                                End If
                                .Item("Deduction_Amount") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("Policy_Status") = "Renewed"
                                If Me.cbGST.Checked Then
                                    .Item("GST") = 1
                                Else
                                    .Item("GST") = 0
                                End If
                            End With

                            da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")


                            Dim dr_MemberPolicy_YearlyRenewal As DataRow
                            dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow
                            Dim PType As String
                            If Me.rdCash.Checked Then
                                PType = "Cash"
                            ElseIf Me.rdCheque.Checked Then
                                PType = "Cheque"
                            Else
                                PType = "Credit Card"
                            End If

                            With dr_MemberPolicy_YearlyRenewal
                                .Item("ID") = Guid.NewGuid.ToString()
                                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                                .Item("Log_Date") = Now()
                                .Item("Payment_Method") = PType
                                .Item("Request_Date") = Me.dtpRequestedDate.Value.Date
                                .Item("Premium") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)

                                Select Case PType
                                    Case "Credit Card"
                                        .Item("CC_Batch_No") = Me.txtPayment_CreditCard_BatchNo.Text.Trim
                                        .Item("CC_Appr_Code") = Me.txtPayment_CreditCard_ApprCode.Text.Trim
                                        .Item("CC_Invoice_No") = Me.txtPayment_CreditCard_Inv_No.Text.Trim
                                    Case "Cheque"
                                        .Item("Cheque_No") = Me.txtPayment_Cheque_No.Text.Trim
                                        .Item("Cheque_Receipt_No") = Me.txtPayment_Cheque_Receipt_No.Text.Trim
                                    Case "Cash"
                                        .Item("Cash_Receipt_No") = Me.txtPayment_Cash_Receipt_No.Text.Trim
                                        .Item("Cash_Receipt_IssuedBy") = Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim
                                End Select

                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                            da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                            Dim dr_MemberLog As DataRow
                            dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                            With dr_MemberLog
                                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Policy renewed."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                            da_MemberLog.Update(ds_Renewal, "log_Member")
                        End If
                    Else
                        If exYear = nextYear Then
                            MsgBox("Sorry can't process. This Policy has been renewed. Next Renewal Date is : " & pNextRenewal)
                            Exit Function
                        Else
                            With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                                If IsDBNull(.Item("Cancellation_Date")) Then
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                                Else
                                    .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                                End If
                                .Item("Deduction_Amount") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("Policy_Status") = "Renewed"
                                If Me.cbGST.Checked Then
                                    .Item("GST") = 1
                                Else
                                    .Item("GST") = 0
                                End If
                            End With
                            da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")

                            Dim dr_MemberPolicy_YearlyRenewal As DataRow
                            dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow
                            Dim PType As String
                            If Me.rdCash.Checked Then
                                PType = "Cash"
                            ElseIf Me.rdCheque.Checked Then
                                PType = "Cheque"
                            Else
                                PType = "Credit Card"
                            End If

                            With dr_MemberPolicy_YearlyRenewal
                                .Item("ID") = Guid.NewGuid.ToString()
                                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                                .Item("Log_Date") = Now()
                                .Item("Payment_Method") = PType
                                .Item("Request_Date") = Me.dtpRequestedDate.Value.Date
                                .Item("Premium") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)

                                Select Case PType
                                    Case "Credit Card"
                                        .Item("CC_Batch_No") = Me.txtPayment_CreditCard_BatchNo.Text.Trim
                                        .Item("CC_Appr_Code") = Me.txtPayment_CreditCard_ApprCode.Text.Trim
                                        .Item("CC_Invoice_No") = Me.txtPayment_CreditCard_Inv_No.Text.Trim
                                    Case "Cheque"
                                        .Item("Cheque_No") = Me.txtPayment_Cheque_No.Text.Trim
                                        .Item("Cheque_Receipt_No") = Me.txtPayment_Cheque_Receipt_No.Text.Trim
                                    Case "Cash"
                                        .Item("Cash_Receipt_No") = Me.txtPayment_Cash_Receipt_No.Text.Trim
                                        .Item("Cash_Receipt_IssuedBy") = Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim
                                End Select

                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                            da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                            Dim dr_MemberLog As DataRow
                            dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                            With dr_MemberLog
                                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Special Approval by Administrator... Policy renewed."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                            da_MemberLog.Update(ds_Renewal, "log_Member")
                        End If
                    End If

                End If
            Else
                With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                    If IsDBNull(.Item("Cancellation_Date")) Then
                        .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                    Else
                        .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                    End If
                    .Item("Deduction_Amount") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()
                    .Item("Status") = "INFORCE"
                    .Item("Policy_Status") = "Renewed"
                    If Me.cbGST.Checked Then
                        .Item("GST") = 1
                    Else
                        .Item("GST") = 0
                    End If
                End With

                da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")


                Dim dr_MemberPolicy_YearlyRenewal As DataRow
                dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow
                Dim PType As String
                If Me.rdCash.Checked Then
                    PType = "Cash"
                ElseIf Me.rdCheque.Checked Then
                    PType = "Cheque"
                Else
                    PType = "Credit Card"
                End If

                With dr_MemberPolicy_YearlyRenewal
                    .Item("ID") = Guid.NewGuid.ToString()
                    .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                    .Item("Log_Date") = Now()
                    .Item("Payment_Method") = PType
                    .Item("Request_Date") = Me.dtpRequestedDate.Value.Date
                    .Item("Premium") = Convert.ToDouble(Me.txtRenewal_Premium_New.Text.Trim)

                    Select Case PType
                        Case "Credit Card"
                            .Item("CC_Batch_No") = Me.txtPayment_CreditCard_BatchNo.Text.Trim
                            .Item("CC_Appr_Code") = Me.txtPayment_CreditCard_ApprCode.Text.Trim
                            .Item("CC_Invoice_No") = Me.txtPayment_CreditCard_Inv_No.Text.Trim
                        Case "Cheque"
                            .Item("Cheque_No") = Me.txtPayment_Cheque_No.Text.Trim
                            .Item("Cheque_Receipt_No") = Me.txtPayment_Cheque_Receipt_No.Text.Trim
                        Case "Cash"
                            .Item("Cash_Receipt_No") = Me.txtPayment_Cash_Receipt_No.Text.Trim
                            .Item("Cash_Receipt_IssuedBy") = Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim
                    End Select

                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                Dim dr_MemberLog As DataRow
                dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                With dr_MemberLog
                    .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                    .Item("Log_Date") = Now()
                    .Item("Activity_Detail") = "Policy renewed."
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                da_MemberLog.Update(ds_Renewal, "log_Member")
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error in renewal this policy.")
            Return False
        End Try
    End Function
#End Region
#Region "General Functions/Subs"
    Private Sub ClearAll()
        Me.GrpBox_Payment_Details.Enabled = False
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtDOB.Clear()
        Me.txtAge.Clear()
        Me.txtL2_Plan_Code.Clear()
        Me.txtRenewal_Premium.Clear()
        Me.txtPolicy_EffectiveDate.Clear()
        Me.txtPolicy_ExpiryDate.Clear()
        Me.dtpRequestedDate.MaxDate = DateTime.Today
        Me.rdCash.Checked = True
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Enabled = True
        Me.txtRenewal_Premium_New.Clear()
        Me.txtPayment_CreditCard_BatchNo.Clear()
        Me.txtPayment_CreditCard_ApprCode.Clear()
        Me.txtPayment_CreditCard_Inv_No.Clear()
        Me.txtPayment_Cheque_No.Clear()
        Me.txtPayment_Cheque_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_IssuedBy.Clear()
        Me.dgvPolicies.Columns.Clear()
        Me.btnPrint_YearlyLetter.Enabled = False
    End Sub
    Private Function Verify_Payment_Details() As Boolean
        If Me.lblMemberPolicy_ID.Text = "GUID" Then
            MsgBox("Please do select the Member Policy.")
            Return False
        Else
            If Not Me.txtAge.Text.Trim() = "" Then
                If Me.txtAge.Text.Trim > 70 Then
                    MsgBox("We are soory, Unable to renew this policy due to OVER AGE! Please contact your Admin")
                    Return False
                End If
            Else
                MsgBox("We are soory, Unable to renew the policy!Please check DOB or Contact your admin!")
                Return False
            End If
            If Len(Me.txtRenewal_Premium_New.Text.Trim) = 0 Then
                MsgBox("Please do key in the Premium.")
                Me.txtRenewal_Premium_New.Focus()
                Return False
            Else
                If IsNumeric(Me.txtRenewal_Premium_New.Text) = False Then
                    MsgBox("Premium is not in Numeric format, please do key in the value.")
                    Me.txtRenewal_Premium_New.Focus()
                    Return False
                Else
                    Dim PType As String
                    If Me.rdCash.Checked Then
                        PType = "Cash"
                    ElseIf Me.rdCheque.Checked Then
                        PType = "Cheque"
                    Else
                        PType = "Credit Card"
                    End If
                    Select Case PType
                        Case "Credit Card"
                            If Len(Me.txtPayment_CreditCard_ApprCode.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Credit Card Approval Code (Appr Code).")
                                Me.txtPayment_CreditCard_ApprCode.Focus()
                                Return False
                            Else
                                If Len(Me.txtPayment_CreditCard_BatchNo.Text.Trim) = 0 Then
                                    MsgBox("Please do key in the Credit Card Batch No.")
                                    Me.txtPayment_CreditCard_BatchNo.Focus()
                                    Return False
                                Else
                                    If Len(Me.txtPayment_CreditCard_Inv_No.Text.Trim) = 0 Then
                                        MsgBox("Please do key in the Invoice No.")
                                        Me.txtPayment_CreditCard_Inv_No.Focus()
                                        Return False
                                    Else
                                        Return True
                                    End If
                                End If
                            End If
                        Case "Cheque"
                            If Len(Me.txtPayment_Cheque_No.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Cheque No.")
                                Me.txtPayment_Cheque_No.Focus()
                                Return False
                            Else
                                If Len(Me.txtPayment_Cheque_Receipt_No.Text.Trim) = 0 Then
                                    MsgBox("Please do key in the Receipt No.")
                                    Me.txtPayment_Cheque_Receipt_No.Focus()
                                Else
                                    Return True
                                End If
                            End If
                        Case "Cash"
                            If Len(Me.txtPayment_Cash_Receipt_No.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Receipt No.")
                                Me.txtPayment_Cash_Receipt_No.Focus()
                                Return False
                            Else
                                If Len(Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim) = 0 Then
                                    MsgBox("Please do key in the Receipt Issued By.")
                                    Me.txtPayment_Cash_Receipt_IssuedBy.Focus()
                                    Return False
                                Else
                                    Return True
                                End If
                            End If
                    End Select
                End If
            End If
        End If
    End Function
#End Region
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
    Private Sub cbGST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGST.CheckedChanged
        If Me.cbGST.Checked Then
            If Not Me.txtRenewal_Premium_New.Text = "" Then
                Dim Premium, GST, TotPremium As Decimal
                Premium = Me.txtRenewal_Premium_New.Text
                GST = Premium * 6 / 100
                TotPremium = Premium + GST
                Me.txtGST.Text = GST
                Me.txtTotalPremium.Text = TotPremium
            End If
        Else
            If Not Me.txtRenewal_Premium_New.Text = "" Then
                Dim Premium, GST, TotPremium As Decimal
                Premium = Me.txtRenewal_Premium_New.Text
                GST = "0.00"
                TotPremium = Premium + GST
                Me.txtGST.Text = GST
                Me.txtTotalPremium.Text = TotPremium
            End If
        End If
    End Sub
End Class
