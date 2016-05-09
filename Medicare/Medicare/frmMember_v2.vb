Imports System.IO
Public Class frmMember_v2
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim rCount As Integer
    Dim MID As String
    Private Sub frmMember_v2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmMember_v2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        If Me.lblGUID.Text = "GUID" Then
            Exit Sub
        Else
            Me.Populate_Form()
            Me.Lock_All_Controls(True)
        End If
    End Sub

    Private Sub Populate_Form()
        Try
            Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member.CommandType = CommandType.Text
            cmdSelect_Member.CommandText = "SELECT ID, Angkasa_FileNo, Title, Full_Name, Birth_Date, IC_New, IC_Old, " & _
                                           "ArmForce_ID, Race, Marital_Status, Sex, Postal_Address_L1, Postal_Address_L2, " & _
                                           "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Height, " & _
                                           "Weight, Occupation, Department, add3, Add4, clientid " & _
                                           "FROM dt_Member WHERE ID = '" & Me.lblGUID.Text.Trim & "'"
            Dim da_Member As New SqlDataAdapter(cmdSelect_Member)

            Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy.CommandType = CommandType.Text
            cmdSelect_Member_Policy.CommandText = "SELECT ID, Member_ID, Angkasa_FileNo, Deduction_Code, Deduction_Amount, " & _
                                                  "Agent_Code, Submission_Date, Effective_Date, Cancellation_Date, " & _
                                                  "Status, Payment_Frequency, Payment_Method, Policy_No, New_Policy_No, Policy_Posted_date, Remarks " & _
                                                  "FROM dt_Member_Policy WHERE Member_ID = '" & Me.lblGUID.Text.Trim & "' "
            Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)

            Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Endorsement.CommandType = CommandType.Text
            cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM vi_Member_Endorsement " & _
                                                       "WHERE Member_ID = '" & Me.lblGUID.Text.Trim & "' " & _
                                                       "ORDER BY Log_Date"
            Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)



            Dim ds_MemberInfo As New DataSet


            da_Member.Fill(ds_MemberInfo, "dt_Member")
            da_Member_Policy.Fill(ds_MemberInfo, "dt_Member_Policy")
            da_Member_Endorsement.Fill(ds_MemberInfo, "vi_Member_Endorsement")

            If ds_MemberInfo.Tables("dt_Member").Rows.Count = 0 Then
                MsgBox("Error in Loading Data...")
                Exit Sub
            Else

                With ds_MemberInfo.Tables("dt_Member").Rows(0)
                    Me.txtMember_Title.Text = .Item("Title").ToString.Trim & " "
                    Me.txtMember_Name.Text = .Item("Full_Name").ToString.Trim & " "

                    If IsDBNull(.Item("Birth_Date")) = False Then
                        Me.dtpMember_DOB.Value = .Item("Birth_Date")
                    Else
                    End If

                    Me.txtMember_NRIC.Text = .Item("IC_New").ToString.Trim & " "
                    Me.txtMember_OldIC.Text = .Item("IC_Old").ToString.Trim & " "
                    Me.txtMember_ArmForceID.Text = .Item("ArmForce_ID").ToString.Trim & " "
                    Me.txtClientID.Text = .Item("clientid").ToString.Trim() & " "

                    If IsDBNull(.Item("Race")) = False Then
                        Select Case .Item("Race")
                            Case "M"
                                Me.rdiMember_Race_Malay.Checked = True
                            Case "C"
                                Me.rdiMember_Race_Chinese.Checked = True
                            Case "I"
                                Me.rdiMember_Race_Indian.Checked = True
                            Case "O"
                                Me.rdiMember_Race_Others.Checked = True
                        End Select
                    Else
                    End If

                    If IsDBNull(.Item("Marital_Status")) = False Then
                        Select Case .Item("Marital_Status")
                            Case "S"
                                Me.rdiMember_MaritalStatus_Single.Checked = True
                            Case "M"
                                Me.rdiMember_MaritalStatus_Married.Checked = True
                            Case "W"
                                Me.rdiMember_MaritalStatus_Widowed.Checked = True
                            Case "D"
                                Me.rdiMember_MaritalStatus_Divorced.Checked = True
                        End Select
                    Else
                    End If

                    If IsDBNull(.Item("Sex")) = False Then
                        If .Item("Sex") = True Then
                            Me.rdiMember_Sex_Male.Checked = True
                        Else
                            Me.rdiMember_Sex_Female.Checked = True
                        End If
                    Else
                    End If

                    Me.txtMember_AddressL1.Text = .Item("Postal_Address_L1").ToString.Trim & " "
                    Me.txtMember_AddressL2.Text = .Item("Postal_Address_L2").ToString.Trim & " "
                    Me.txtAdd3.Text = .Item("Add3").ToString.Trim & " "
                    Me.txtAdd4.Text = .Item("Add4").ToString.Trim & " "
                    Me.txtMember_City.Text = .Item("Town").ToString.Trim & " "
                    Me.txtMember_Postcode.Text = .Item("Postcode").ToString.Trim & " "
                    Me.txtMember_State.Text = .Item("State").ToString.Trim & " "
                    Me.txtMember_Phone_Hse.Text = .Item("Phone_Hse").ToString.Trim & " "
                    Me.txtMember_Mobile.Text = .Item("Phone_Mobile").ToString.Trim & " "
                    Me.txtMember_Phone_Ofc.Text = .Item("Phone_Off").ToString.Trim & " "
                    Me.txtMember_Email.Text = .Item("Email").ToString.Trim & " "
                    Me.txtMember_Height.Text = .Item("Height").ToString.Trim & " "
                    Me.txtMember_Weight.Text = .Item("Weight").ToString.Trim & " "
                    Me.txtMember_Occupation.Text = .Item("Occupation").ToString.Trim & " "
                    Me.txtMember_Department.Text = .Item("Department").ToString.Trim & " "
                End With
                If ds_MemberInfo.Tables("dt_Member_Policy").Rows.Count = 0 Then
                    MsgBox("This member does not have any policy, please check.")
                    Exit Sub
                Else
                    With Me.dgvMyPolicies
                        .DataSource = ds_MemberInfo
                        .DataMember = "dt_Member_Policy"

                        .Columns(0).Visible = False
                        .Columns(1).Visible = False

                        .Columns(2).HeaderText = "File No."
                        .Columns(3).HeaderText = "Product Code"
                        .Columns(4).HeaderText = "Requested Amount"
                        .Columns(5).HeaderText = "Agent Code"
                        .Columns(6).HeaderText = "Submission Date"
                        .Columns(7).HeaderText = "Start Date"
                        .Columns(8).HeaderText = "End Date"
                        .Columns(9).HeaderText = "Cancellation Reason"
                        .Columns(10).HeaderText = "Payment Frequency"
                        .Columns(11).HeaderText = "Payment Method"
                        .Columns(12).HeaderText = "Old Policy/Certificate No."
                        .Columns(13).HeaderText = "New Policy/Certificate No."
                        .Columns(14).HeaderText = "Policy Posted Date"
                        .Columns(15).HeaderText = "Remarks"

                        .Columns(4).DefaultCellStyle.Format = "###.##"
                        .Columns(14).DefaultCellStyle.Format = "dd/MM/yyyy"

                        .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                        .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                    End With
                End If
                With Me.dgvMyEndorsement
                    .DataSource = ds_MemberInfo
                    .DataMember = "vi_Member_Endorsement"

                    .Columns(0).Visible = False
                    .Columns(1).Visible = False
                    .Columns(2).Visible = False

                    .Columns(3).HeaderText = "Date"
                    .Columns(4).HeaderText = "Endorsement Details"
                    .Columns(5).HeaderText = "Deduction Code"
                    .Columns(6).HeaderText = "File #"
                    .Columns(7).HeaderText = "Policy/Certificate No."
                    .Columns(8).HeaderText = "Request Date"
                    .Columns(9).HeaderText = "Remark"
                    .Columns(10).HeaderText = "Performed by"

                    .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
                    .Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"

                    .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

                Me.popdgvSS(Me.txtMember_NRIC.Text.Trim())
                Me.popdgvSFS(Me.txtMember_NRIC.Text.Trim())

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Lock_All_Controls(ByVal flag As Boolean)
        Me.txtMember_Title.ReadOnly = flag
        Me.txtMember_Name.ReadOnly = flag
        Me.dtpMember_DOB.Enabled = Not flag
        Me.txtMember_NRIC.ReadOnly = flag
        Me.txtMember_OldIC.ReadOnly = flag
        Me.txtMember_ArmForceID.ReadOnly = flag
        Me.rdiMember_Race_Malay.AutoCheck = Not flag
        Me.rdiMember_Race_Chinese.AutoCheck = Not flag
        Me.rdiMember_Race_Indian.AutoCheck = Not flag
        Me.rdiMember_Race_Others.AutoCheck = Not flag
        Me.rdiMember_MaritalStatus_Single.AutoCheck = Not flag
        Me.rdiMember_MaritalStatus_Married.AutoCheck = Not flag
        Me.rdiMember_MaritalStatus_Widowed.AutoCheck = Not flag
        Me.rdiMember_MaritalStatus_Divorced.AutoCheck = Not flag
        Me.rdiMember_Sex_Male.AutoCheck = Not flag
        Me.rdiMember_Sex_Female.AutoCheck = Not flag
        Me.txtMember_AddressL1.ReadOnly = flag
        Me.txtMember_AddressL2.ReadOnly = flag
        Me.txtAdd4.ReadOnly = flag
        Me.txtAdd3.ReadOnly = flag
        Me.txtMember_City.ReadOnly = flag
        Me.txtMember_Postcode.ReadOnly = flag
        Me.txtMember_State.ReadOnly = flag
        Me.txtMember_Phone_Hse.ReadOnly = flag
        Me.txtMember_Mobile.ReadOnly = flag
        Me.txtMember_Phone_Ofc.ReadOnly = flag
        Me.txtMember_Email.ReadOnly = flag
        Me.txtMember_Height.ReadOnly = flag
        Me.txtMember_Weight.ReadOnly = flag
        Me.txtMember_Occupation.ReadOnly = flag
        Me.txtMember_Department.ReadOnly = flag
    End Sub
    Private Sub dgvMyPolicies_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMyPolicies.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        Else
            Me.Populate_dgvMyPolicy_Transaction(e)
            Me.Populate_dgvMyPolicy_YearlyRenewal(e)
            Me.Populate_dgvDependents(e)
            Me.Populate_dgvNominees(e)
            Me.Populate_dgvExclusion_Clause(e)
            Me.Populate_dgvMyPolicy_Logs(e)
            MID = Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString()
            GetDocuments()
            GetPolicyNoDetails()
            GetPremiumHistory()
            If My.Settings.Username = "admin" Then
                Me.Populate_dgvMLOG_Logs(e)
            Else
                Me.TabPage10.Dispose()
            End If
        End If
    End Sub
    Private Sub Populate_dgvMyPolicy_Transaction(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_Policy_Transaction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Transaction.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Transaction.CommandText = "SELECT Member_Policy_ID, Angkasa_Bulan_Potongan, " & _
                                                              "Angkasa_Jumlah_Pokok, Angkasa_Batch_No, " & _
                                                              "Receiving_Month, Remark " & _
                                                              "FROM dt_Member_Policy_MonthlyDeduction " & _
                                                              "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' " & _
                                                              "ORDER BY Angkasa_Bulan_Potongan"
            Dim da_Member_Policy_Transaction As New SqlDataAdapter(cmdSelect_Member_Policy_Transaction)


            Dim ds_PolicyInfo As New DataSet


            da_Member_Policy_Transaction.Fill(ds_PolicyInfo, "dt_Member_Policy_MonthlyDeduction")

            With Me.dgvMyPolicy_Transaction
                .DataSource = ds_PolicyInfo
                .DataMember = "dt_Member_Policy_MonthlyDeduction"

                .Columns(0).Visible = False


                .Columns(1).HeaderText = "Deduction Month (YYYYMM)"
                .Columns(2).HeaderText = "Received Amount (RM)"
                .Columns(3).HeaderText = "Batch No (Angkasa)"
                .Columns(4).HeaderText = "Processing Date (YYYYMM)"
                .Columns(5).HeaderText = "Remark"

                .Columns(2).DefaultCellStyle.Format = "###.##"

                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Populate_dgvMyPolicy_YearlyRenewal(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try

            Dim cmdSelect_Member_Policy_YearlyTransaction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_YearlyTransaction.CommandType = CommandType.Text
            cmdSelect_Member_Policy_YearlyTransaction.CommandText = "SELECT Member_Policy_ID, Log_Date, Payment_Method, Request_Date, Premium, " & _
                                                              "CC_Batch_No, CC_Appr_Code, Cheque_No, Cash_Receipt_No, Cash_Receipt_IssuedBy, " & _
                                                              "Created_By " & _
                                                              "FROM dt_Member_Policy_YearlyRenewal " & _
                                                              "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' " & _
                                                              "ORDER BY Log_Date"

            Dim da_Member_Policy_YearlyTransaction As New SqlDataAdapter(cmdSelect_Member_Policy_YearlyTransaction)

            Dim ds_PolicyInfo As New DataSet
            da_Member_Policy_YearlyTransaction.Fill(ds_PolicyInfo, "dt_Member_Policy_YearlyRenewal")

            If ds_PolicyInfo.Tables("dt_Member_Policy_YearlyRenewal").Rows.Count >= 1 Then

                With Me.dgvMyPolicy_YearlyRenewal
                    .DataSource = ds_PolicyInfo
                    .DataMember = "dt_Member_Policy_YearlyRenewal"

                    .Columns(0).Visible = False

                    .Columns(1).HeaderText = "Date"
                    .Columns(2).HeaderText = "Payment Method"
                    .Columns(3).HeaderText = "Request Date"
                    .Columns(4).HeaderText = "Renewal Premium"
                    .Columns(5).HeaderText = "Credit Card - Batch #"
                    .Columns(6).HeaderText = "Credit Card - Appr #"
                    .Columns(7).HeaderText = "Cheque #"
                    .Columns(8).HeaderText = "Cash - Receipt #"
                    .Columns(9).HeaderText = "Cash - Receipt Issued By"
                    .Columns(10).HeaderText = "Performed By"

                    .Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
                    .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
                    .Columns(4).DefaultCellStyle.Format = "#,##0.00"

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
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Populate_dgvDependents(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_Dependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Dependent.CommandType = CommandType.Text
            cmdSelect_Member_Dependent.CommandText = "SELECT ID, Member_Policy_ID, Title, Full_Name, Birth_Date, IC_New, " & _
                                                     "IC_Old, ArmForce_ID, Race, Marital_Status, Relationship, Sex, " & _
                                                     "Height, Weight, Occupation, Department, clientid " & _
                                                     "FROM dt_Member_Policy_Dependents " & _
                                                     "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' " & _
                                                     "ORDER BY Birth_Date"
            Dim da_Member_Dependent As New SqlDataAdapter(cmdSelect_Member_Dependent)

            Dim ds_PolicyInfo As New DataSet
            da_Member_Dependent.Fill(ds_PolicyInfo, "dt_Member_Policy_Dependents")

            With Me.dgvDependents
                .DataSource = ds_PolicyInfo
                .DataMember = "dt_Member_Policy_Dependents"

                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "Title"
                .Columns(3).HeaderText = "Full Name As in NRIC"
                .Columns(4).HeaderText = "Date of Birth"
                .Columns(5).HeaderText = "New I/C No"
                .Columns(6).HeaderText = "Old I/C No"
                .Columns(7).HeaderText = "Policy/Army ID"
                .Columns(8).HeaderText = "Race"
                .Columns(9).HeaderText = "Marital Status"
                .Columns(10).HeaderText = "Relationship"
                .Columns(11).HeaderText = "Sex"
                .Columns(12).HeaderText = "Height"
                .Columns(13).HeaderText = "Weight"
                .Columns(14).HeaderText = "Occupation"
                .Columns(15).HeaderText = "Department"
                .Columns(16).HeaderText = "Client ID"

                .Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                Me.dgvDependents.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub popdgvSS(ByVal MID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("MEMBER", MID.Trim(), "", "", "", "MSS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSS
                .DataSource = dt
                .ReadOnly = True
            End With
        End If
    End Sub
    Private Sub popdgvSFS(ByVal MID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("MEMBER", MID.Trim(), "", "", "", "MSFS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSFS
                .DataSource = dt
                .ReadOnly = True
            End With
        End If
    End Sub
    Private Sub Populate_dgvNominees(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_Nomination As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Nomination.CommandType = CommandType.Text
            cmdSelect_Member_Nomination.CommandText = "SELECT ID, Member_Policy_ID, Title, Full_Name, Birth_Date, " & _
                                                       "IC_New, Relationship, case when (Postal_Address is null or Postal_Address='') then add1 + ' ' + add2 + ' ' + add3 + '' + add4 else Postal_Address end as Postal_Address  , Share " & _
                                                       "FROM dt_Member_Policy_Nomination " & _
                                                       "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "'"

            Dim da_Member_Nomination As New SqlDataAdapter(cmdSelect_Member_Nomination)

            Dim ds_PolicyInfo As New DataSet
            da_Member_Nomination.Fill(ds_PolicyInfo, "dt_Member_Policy_Nomination")

            With Me.dgvNominees
                .DataSource = ds_PolicyInfo
                .DataMember = "dt_Member_Policy_Nomination"

                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "Title"
                .Columns(3).HeaderText = "Full Name As in NRIC"
                .Columns(4).HeaderText = "Date of Birth"
                .Columns(5).HeaderText = "New I/C No"
                .Columns(6).HeaderText = "Relationship"
                .Columns(7).HeaderText = "Postal Address"
                .Columns(8).HeaderText = "Share"

                .Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                Me.dgvDependents.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Populate_dgvExclusion_Clause(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_ExclusionClause As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_ExclusionClause.CommandType = CommandType.Text
            cmdSelect_Member_ExclusionClause.CommandText = "SELECT ID, Member_Policy_ID, ExclusionClause_Code, " & _
                                                           "ExclusionClause_Description " & _
                                                           "FROM dt_Member_Policy_Exclusion_Clause " & _
                                                           "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "'"
            Dim da_Member_ExclusionClause As New SqlDataAdapter(cmdSelect_Member_ExclusionClause)

            Dim ds_PolicyInfo As New DataSet
            da_Member_ExclusionClause.Fill(ds_PolicyInfo, "dt_Member_Policy_Exclusion_Clause")

            With Me.dgvExclusion_Clause
                .DataSource = ds_PolicyInfo
                .DataMember = "dt_Member_Policy_Exclusion_Clause"

                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "Exclusion Clause Code"
                .Columns(3).HeaderText = "Exclusion Clause"

                Me.dgvDependents.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Populate_dgvMyPolicy_Logs(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_Policy_Logs As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Logs.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Logs.CommandText = "SELECT Member_Policy_ID, Log_Date, Activity_Detail, Username " & _
                                                       "FROM log_Member " & _
                                                       "WHERE Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' and (M_Log='0' or M_Log is null)" & _
                                                       "ORDER BY Log_Date"
            Dim da_Member_Policy_Logs As New SqlDataAdapter(cmdSelect_Member_Policy_Logs)


            Dim ds_PolicyInfo As New DataSet
            da_Member_Policy_Logs.Fill(ds_PolicyInfo, "log_Member")

            With Me.dgvMyPolicy_Logs
                .DataSource = ds_PolicyInfo
                .DataMember = "log_Member"

                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Date"
                .Columns(2).HeaderText = "Log/Activity Details"
                .Columns(3).HeaderText = "Performed by"

                .Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Populate_dgvMLOG_Logs(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim cmdSelect_Member_Policy_Logs As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Logs.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Logs.CommandText = "SELECT Member_Policy_ID, Log_Date, Activity_Detail, Username " & _
                                                       "FROM log_Member " & _
                                                       "WHERE M_log='1' and (Member_Policy_ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' Or " & _
                                                       " Member_Policy_ID=(select distinct member_id from dt_member_policy where id='" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "')) " & _
                                                       "ORDER BY Log_Date"
            Dim da_Member_Policy_Logs As New SqlDataAdapter(cmdSelect_Member_Policy_Logs)


            Dim ds_PolicyInfo As New DataSet
            da_Member_Policy_Logs.Fill(ds_PolicyInfo, "log_Member")
            With Me.dgvMLOG
                .DataSource = ds_PolicyInfo
                .DataMember = "log_Member"

                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Date"
                .Columns(2).HeaderText = "Log/Activity Details"
                .Columns(3).HeaderText = "Performed by"

                .Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"

                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
        End Try
    End Sub
#Region "Policy No Details"
    Private Sub GetPolicyNoDetails()
        Try
            Dim dt As New DataTable
            dt = _objBusi.getDetails_I("POLICYNODETAILS", MID, "", "", "", "", "", "", "", "", "", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvPolicyNoDetails
                    .DataSource = dt
                End With
            Else
                Me.dgvPolicyNoDetails.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
#End Region
#Region "Premium History"
    Private Sub GetPremiumHistory()
        Try
            Dim dt As New DataTable
            dt = _objBusi.getDetails_I("PREMIUMHISTORY", MID, "", "", "", "", "", "", "", "", "", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvPremiumHistory
                    .DataSource = dt
                End With
            Else
                Me.dgvPremiumHistory.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
#End Region
#Region "View Documents"
    Private Sub GetDocuments()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Dim strSql As String = "Select Id, Doc_Name, Doc_Type, Doc_ext, created_on from dt_documents_checklist where member_policy_id='" & MID & "'"
            Dim ADAP As New SqlDataAdapter(strSql, Conn)
            Dim DS As New DataSet()
            ADAP.Fill(DS, "dt_documents_checklist")
            If DS.Tables(0).Rows.Count > 0 Then
                Me.dgvDocList.DataSource = DS.Tables("dt_documents_checklist")
                Dim dgButtonColumn As New DataGridViewButtonColumn
                dgButtonColumn.HeaderText = "View / Download"
                dgButtonColumn.UseColumnTextForButtonValue = True
                dgButtonColumn.Text = "View File"
                dgButtonColumn.Name = "ViewFile"
                dgButtonColumn.ToolTipText = "View File"
                dgButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                dgButtonColumn.FlatStyle = FlatStyle.System
                dgButtonColumn.DefaultCellStyle.BackColor = Color.Gray
                dgButtonColumn.DefaultCellStyle.ForeColor = Color.White
                Dim dgBtnDelete As New DataGridViewButtonColumn
                If (My.Settings.Username = "SRI" Or My.Settings.Username = "Admin") Then
                    dgBtnDelete.HeaderText = "Delete"
                    dgBtnDelete.UseColumnTextForButtonValue = True
                    dgBtnDelete.Text = "Delete"
                    dgBtnDelete.Name = "Delete"
                    dgBtnDelete.ToolTipText = "Delete"
                    dgBtnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    dgBtnDelete.FlatStyle = FlatStyle.System
                    dgBtnDelete.DefaultCellStyle.BackColor = Color.Gray
                    dgBtnDelete.DefaultCellStyle.ForeColor = Color.Red
                End If

                Dim RowCount As Integer
                For RowCount = 0 To Me.dgvDocList.Rows.Count - 1
                    If rCount = 0 Then
                        Me.dgvDocList.Columns(0).Visible = False
                        Me.dgvDocList.Columns(3).Visible = False
                        Me.dgvDocList.Columns(4).Visible = False
                        Me.dgvDocList.Columns.Add(dgButtonColumn)
                        If (My.Settings.Username = "SRI" Or My.Settings.Username = "Admin") Then
                            Me.dgvDocList.Columns.Add(dgBtnDelete)
                        End If
                    End If
                    rCount += 1
                Next
            Else
                Me.dgvDocList.DataSource = DS.Tables("dt_documents_checklist")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            MessageBox.Show("Could not load the Image")
        End Try

    End Sub
    Private Sub dgvDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocList.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case Is > -1
                    If sender.Columns(e.ColumnIndex).Name = "ViewFile" Then
                        Select Case dgvDocList.Rows(e.RowIndex).Cells("Doc_Ext").Value
                            Case ".txt", ".pdf", ".doc"
                                downLoadFile(dgvDocList.Rows(e.RowIndex).Cells("Id").Value.ToString(), dgvDocList.Rows(e.RowIndex).Cells("Doc_Name").Value, dgvDocList.Rows(e.RowIndex).Cells("Doc_Type").Value)
                        End Select
                    ElseIf sender.Columns(e.ColumnIndex).Name = "Delete" Then
                        If MsgBox("Do you want Delete? ", vbYesNo, "Document") = vbYes Then
                            Dim sRes As String
                            sRes = _objBusi.Delete("DOCCHKLIST", dgvDocList.Rows(e.RowIndex).Cells("Id").Value.ToString(), "", "", "", "", "", "", "", "", "", Conn)
                            GetDocuments()
                            MsgBox("Document deleted sucessfully")
                        End If
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim strSql As String
            strSql = "Select Doc_Data from dt_documents_checklist WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & sFileName
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
End Class