Imports System.IO
Imports System.Text.RegularExpressions
Public Class New_Proposer
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim sProposerID As String
    Dim sReject As String = ""
    Dim sStartDate As String = ""
    Dim _objBusi As New Business
    Dim iKIO As Integer = 0
    Dim REFID, REFTYPE As String
    Dim PID As String = ""
    Dim rCount As Integer
#End Region
#Region "Page Events"
    Private Sub New_Proposer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub New_Proposer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblProposer_ID.Text.Trim = "Proposer_ID" Then
            Exit Sub
        Else
            Select Case Me.lblForm_Flag.Text
                Case "N"
                    Me.btnLookUP_IC.Enabled = True
                    Me.btnEdit.Enabled = False
                    Me.btnEdit.Visible = False
                Case "V"
                    Me.btnLookUP_IC.Enabled = False
                    Me.Populate_Form4Verification()
                    Me.Lock_All_Controls(True)

                    Me.btnEdit.Location = New Point(12, 10)
                    Me.btnEdit.Enabled = True
                    Me.btnEdit.Visible = True
                    Me.btnPrint.Visible = True
                    Me.btnInfoLetter.Visible = True

                    Me.lblAngkasa_FileNo.Visible = True
                    Me.txtAngkasa_FileNo.Visible = True

                    Me.btnInsert_Angkasa_FileNo.Enabled = False
                    Me.btnInsert_Angkasa_FileNo.Visible = False
                Case "View"
                    Me.btnLookUP_IC.Enabled = False
                    Me.Populate_Form4Verification()
                    Me.Lock_All_Controls(True)

                    Me.btnEdit.Location = New Point(12, 10)
                    Me.btnEdit.Enabled = True
                    Me.btnEdit.Visible = True
                    Me.btnPrint.Visible = True

                    Me.lblAngkasa_FileNo.Visible = True
                    Me.txtAngkasa_FileNo.Visible = True

                    Me.btnInsert_Angkasa_FileNo.Enabled = False
                    Me.btnInsert_Angkasa_FileNo.Visible = False
                Case "Unlock"
                    Me.btnLookUP_IC.Enabled = False
                    Me.Populate_Form4Verification()
                    Me.Lock_All_Controls(True)

                    Me.btnEdit.Location = New Point(12, 10)
                    Me.btnEdit.Enabled = True
                    Me.btnEdit.Visible = True
                    Me.btnPrint.Visible = True

                    Me.lblAngkasa_FileNo.Visible = True
                    Me.txtAngkasa_FileNo.Visible = True
                Case "Readonly"
                    Me.btnLookUP_IC.Enabled = False
                    Me.Populate_Form4Verification()
                    Me.Lock_All_Controls(True)

                    Me.btnEdit.Location = New Point(12, 10)
                    Me.btnEdit.Enabled = False
                    Me.btnEdit.Visible = False
                    Me.btnPrint.Visible = True

                    Me.lblAngkasa_FileNo.Visible = True
                    Me.txtAngkasa_FileNo.Visible = True
                Case Else
                    MsgBox("Error in loading form due to Form Flag: (N)ew / (V)erification / View")
            End Select
            PID = Me.lblProposer_ID.Text.Trim
            Me.txtBrowse.Text = ""
            Me.txtDocName.Text = ""
            GetDocuments()
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnLookUP_IC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUP_IC.Click
        If Len(Me.txtProposer_NRIC.Text.Trim) <> 0 Then
            Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSearch_Parameter.CommandType = CommandType.Text

            Dim cmdSearch_ParameterMember As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSearch_ParameterMember.CommandType = CommandType.Text

            Dim ds_Search_Param As New DataSet
            Dim ds_Search_Param_Mem As New DataSet
            cmdSearch_Parameter.CommandText = "SELECT * FROM dt_Proposer " & _
                                              "WHERE IC_New = '" & Me.txtProposer_NRIC.Text.Trim & "'"
            cmdSearch_ParameterMember.CommandText = "SELECT * FROM dt_Member " & _
                                              "WHERE IC_New = '" & Me.txtProposer_NRIC.Text.Trim & "'"

            Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)
            Dim da_ProposerMember As New SqlDataAdapter(cmdSearch_ParameterMember)


            da_Proposer.Fill(ds_Search_Param, "dt_Proposer")
            da_ProposerMember.Fill(ds_Search_Param_Mem, "dt_Member")

            If ds_Search_Param.Tables("dt_Proposer").Rows.Count > 0 Then
                With ds_Search_Param.Tables("dt_Proposer").Rows(0)
                    Dim s As String
                    s = .Item("Status").ToString().Trim()
                    If (.Item("Status").ToString().Trim() = "1R" Or .Item("Status").ToString().Trim() = "1D" Or .Item("Status").ToString().Trim() = "1U" Or .Item("Status").ToString().Trim() = "1PU") Then
                        If Not (IsDBNull(.Item("Angkasa_FileNo")) Or .Item("Angkasa_FileNo").ToString.Trim() = "") Then
                            Dim result As DialogResult = MessageBox.Show("Proposer already exists in the system! " & vbCrLf & vbCrLf & " Status : " & .Item("Status").ToString().Trim() & vbCrLf & " File No : " & .Item("Angkasa_fileNo") & vbCrLf & " Plan Code : " & .Item("Plan_code") & vbCrLf & " Date of Proposal Received: " & .Item("Proposal_Received_Date") & vbCrLf & vbCrLf & "Do you want proceed New Proposer?", "Proposer Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Select Case result
                                Case 6
                                Case 7
                                    Me.Close()
                                Case 2
                                    Me.txtProposer_NRIC.Text = ""
                                    Me.txtProposer_NRIC.Focus()
                                    Exit Sub
                            End Select
                        End If
                    End If

                    Me.txtProposer_Title.Text = .Item("Title").ToString.Trim
                    Me.txtProposer_Name.Text = .Item("Full_Name").ToString.Trim
                    Me.dtpProposer_DOB.Value = .Item("Birth_Date")
                    Me.txtProposer_NRIC.Text = .Item("IC_New").ToString.Trim
                    Me.txtProposer_OldIC.Text = .Item("IC_Old").ToString.Trim
                    Me.txtProposer_ArmForceID.Text = .Item("ArmForce_ID").ToString.Trim

                    Select Case .Item("Race")
                        Case "M"
                            Me.rdiProposer_Race_Malay.Checked = True
                        Case "C"
                            Me.rdiProposer_Race_Chinese.Checked = True
                        Case "I"
                            Me.rdiProposer_Race_Indian.Checked = True
                        Case "O"
                            Me.rdiProposer_Race_Others.Checked = True
                    End Select

                    Select Case .Item("Marital_Status")
                        Case "S"
                            Me.rdiProposer_MaritalStatus_Single.Checked = True
                        Case "M"
                            Me.rdiProposer_MaritalStatus_Married.Checked = True
                        Case "W"
                            Me.rdiProposer_MaritalStatus_Widowed.Checked = True
                        Case "D"
                            Me.rdiProposer_MaritalStatus_Divorced.Checked = True
                    End Select

                    If .Item("Sex") = True Then
                        Me.rdiProposer_Sex_Male.Checked = True
                    Else
                        Me.rdiProposer_Sex_Female.Checked = True
                    End If

                    Me.dtpProposal_Received_Date.Value = .Item("Proposal_Received_Date")
                    If Not IsDBNull(.Item("Proposal_Signed_Date")) Then
                        Me.dtpDateofSigned.Value = .Item("Proposal_Signed_Date")
                    End If
                    Me.txtProposer_AddressL1.Text = .Item("Postal_Address_L1").ToString.Trim
                    Me.txtProposer_AddressL2.Text = .Item("Postal_Address_L2").ToString.Trim
                    Me.txtProposerAdd3.Text = .Item("Add3").ToString.Trim
                    Me.txtProposerAdd4.Text = .Item("Add4").ToString.Trim
                    Me.txtProposer_City.Text = .Item("Town").ToString.Trim
                    Me.txtProposer_Postcode.Text = .Item("Postcode").ToString.Trim
                    Me.txtProposer_State.Text = .Item("State").ToString.Trim
                    Me.txtProposer_Phone_Hse.Text = .Item("Phone_Hse").ToString.Trim
                    Me.txtProposer_Mobile.Text = .Item("Phone_Mobile").ToString.Trim
                    Me.txtProposer_Phone_Ofc.Text = .Item("Phone_Off").ToString.Trim
                    Me.txtProposer_Email.Text = .Item("Email").ToString.Trim
                    Me.txtProposer_Height.Text = .Item("Height").ToString.Trim
                    Me.txtProposer_Weight.Text = .Item("Weight").ToString.Trim
                    Me.txtProposer_Occupation.Text = .Item("Occupation").ToString.Trim
                    Me.txtProposer_Department.Text = .Item("Department").ToString.Trim
                    Me.txtBorang1_79_SN.Text = .Item("payment_method_biroangkasa_borang1_79_sn").ToString.Trim
                    REFTYPE = "PROPOSER"
                    REFID = .Item("ID").ToString.Trim
                    Me.btnSDepedents.Visible = True
                    Me.btnSNominee.Visible = True
                End With
            Else

                If ds_Search_Param_Mem.Tables("dt_Member").Rows.Count > 0 Then

                    With ds_Search_Param_Mem.Tables("dt_Member").Rows(0)

                        Me.txtProposer_Title.Text = .Item("Title").ToString.Trim
                        Me.txtProposer_Name.Text = .Item("Full_Name").ToString.Trim

                        If IsDBNull(.Item("Birth_Date")) Then
                            Me.dtpProposer_DOB.Value = Now()
                        Else
                            Me.dtpProposer_DOB.Value = .Item("Birth_Date")
                        End If

                        Me.txtProposer_NRIC.Text = .Item("IC_New").ToString.Trim
                        Me.txtProposer_OldIC.Text = .Item("IC_Old").ToString.Trim
                        Me.txtProposer_ArmForceID.Text = .Item("ArmForce_ID").ToString.Trim

                        If Not (IsDBNull(.Item("Race"))) Then
                            Select Case .Item("Race")
                                Case "M"
                                    Me.rdiProposer_Race_Malay.Checked = True
                                Case "C"
                                    Me.rdiProposer_Race_Chinese.Checked = True
                                Case "I"
                                    Me.rdiProposer_Race_Indian.Checked = True
                                Case "O"
                                    Me.rdiProposer_Race_Others.Checked = True
                            End Select
                        End If

                        If Not (IsDBNull(.Item("Marital_Status"))) Then
                            Select Case .Item("Marital_Status")
                                Case "S"
                                    Me.rdiProposer_MaritalStatus_Single.Checked = True
                                Case "M"
                                    Me.rdiProposer_MaritalStatus_Married.Checked = True
                                Case "W"
                                    Me.rdiProposer_MaritalStatus_Widowed.Checked = True
                                Case "D"
                                    Me.rdiProposer_MaritalStatus_Divorced.Checked = True
                            End Select
                        End If

                        If Not (IsDBNull(.Item("Sex"))) Then
                            If .Item("Sex") = True Then
                                Me.rdiProposer_Sex_Male.Checked = True
                            Else
                                Me.rdiProposer_Sex_Female.Checked = True
                            End If
                        End If
                        Me.dtpProposal_Received_Date.Value = Now()
                        Me.dtpDateofSigned.Value = Now()
                        Me.txtProposer_AddressL1.Text = IIf(IsDBNull(.Item("Postal_Address_L1").ToString.Trim), "", .Item("Postal_Address_L1").ToString.Trim)
                        Me.txtProposer_AddressL2.Text = IIf(IsDBNull(.Item("Postal_Address_L2").ToString.Trim), "", .Item("Postal_Address_L2").ToString.Trim)
                        Me.txtProposer_City.Text = IIf(IsDBNull(.Item("Town").ToString.Trim), "", .Item("Town").ToString.Trim)
                        Me.txtProposer_Postcode.Text = IIf(IsDBNull(.Item("Postcode").ToString.Trim), "", .Item("Postcode").ToString.Trim)
                        Me.txtProposer_State.Text = IIf(IsDBNull(.Item("State").ToString.Trim), "", .Item("State").ToString.Trim)
                        Me.txtProposer_Phone_Hse.Text = IIf(IsDBNull(.Item("Phone_Hse").ToString.Trim), "", .Item("Phone_Hse").ToString.Trim)
                        Me.txtProposer_Mobile.Text = IIf(IsDBNull(.Item("Phone_Mobile").ToString.Trim), "", .Item("Phone_Mobile").ToString.Trim)
                        Me.txtProposer_Phone_Ofc.Text = IIf(IsDBNull(.Item("Phone_Off").ToString.Trim), "", .Item("Phone_Off").ToString.Trim)
                        Me.txtProposer_Email.Text = IIf(IsDBNull(.Item("Email").ToString.Trim), "", .Item("Email").ToString.Trim)
                        Me.txtProposer_Height.Text = IIf(IsDBNull(.Item("Height").ToString.Trim), "", .Item("Height").ToString.Trim)
                        Me.txtProposer_Weight.Text = IIf(IsDBNull(.Item("Weight").ToString.Trim), "", .Item("Weight").ToString.Trim)
                        Me.txtProposer_Occupation.Text = IIf(IsDBNull(.Item("Occupation").ToString.Trim), "", .Item("Occupation").ToString.Trim)
                        Me.txtProposer_Department.Text = IIf(IsDBNull(.Item("Department").ToString.Trim), "", .Item("Department").ToString.Trim)
                        REFTYPE = "MEMBER"
                        REFID = .Item("ID").ToString.Trim
                        Me.btnSDepedents.Visible = True
                        Me.btnSNominee.Visible = True
                    End With
                End If

            End If
        End If
    End Sub
    Private Sub btnTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitle.Click
        Dim frmSearch_Title As New frmSearch_Param
        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()
        Me.txtProposer_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click
        Dim frmSearch_State As New frmSearch_Param
        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()
        Me.txtProposer_State.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnDependent_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Title.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtDependent_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlan.Click
        Dim findProduct_Code As New findProduct_Code
        findProduct_Code.lblREF1.Text = Guid.NewGuid().ToString()
        findProduct_Code.ShowDialog()
        Dim iData As IDataObject = Clipboard.GetDataObject()
        If iData.GetDataPresent(DataFormats.Text) Then
            txtProposer_Plan_Code.Text = CType(iData.GetData(DataFormats.Text), String)
            GetDetails(CType(iData.GetData(DataFormats.Text), String))
        Else
            txtProposer_Plan_Code.Text = "Could not retrieve data off the clipboard."
        End If
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgent.Click
        Dim SA As New SearchAgent
        SA.ShowDialog()
        Dim iData As IDataObject = Clipboard.GetDataObject()

        If iData.GetDataPresent(DataFormats.Text) Then

            Dim sRes As String
            sRes = CType(iData.GetData(DataFormats.Text), String)

            Dim dt As New DataTable
            Dim sda As SqlDataAdapter
            Dim cmd As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT agent_code As Agent_Code, agent_name as Staff_Name, Percentage FROM tb_agent where tb_agent_id='" & sRes & "'"
            cmd.ExecuteNonQuery()
            sda = New SqlDataAdapter(cmd)
            sda.Fill(dt)
            If Me.lblEdit_Status.Text = "Edit Mode" Then
                Me.txtProposer_Plan_Commission_AgentCode.Text = dt.Rows(0)("Agent_Code")
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = dt.Rows(0)("Percentage")
                Me.lblStaff_Name.Text = dt.Rows(0)("Staff_Name")
            Else
                With Me.dgvAgents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = dt.Rows(0)("Agent_Code")
                    .Rows(.Rows.Count - 1).Cells(1).Value = dt.Rows(0)("Staff_Name")
                    .Rows(.Rows.Count - 1).Cells(2).Value = dt.Rows(0)("Percentage")
                End With
                Me.btnAgent_Add.Enabled = False
                Me.btnAgent.Enabled = False
            End If

        Else

            txtProposer_Plan_Code.Text = "Could not retrieve data off the clipboard."
        End If

        My.Computer.Clipboard.Clear()


    End Sub
    Private Sub btnExclusionClause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclusionClause.Click
        Dim frmSearch_ExclusionClause As New frmSearch_Param

        frmSearch_ExclusionClause.lblForm_Flag.Text = "E"
        frmSearch_ExclusionClause.ShowDialog()

        Me.txtUnderwriting_ExclusionClause_Code.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()

        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) <> 0 Then

            Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSearch_Parameter.CommandType = CommandType.Text
            cmdSearch_Parameter.CommandText = "SELECT ExclusionClause_Header, ExclusionClause_Footer FROM dt_Underwriting_ExclusionClause " & _
                                              "WHERE ExclusionClause_Code = '" & Me.txtUnderwriting_ExclusionClause_Code.Text.Trim & "'"


            Dim ds_Search_Param As New DataSet


            Dim da_ExclusionClause As New SqlDataAdapter(cmdSearch_Parameter)


            da_ExclusionClause.Fill(ds_Search_Param, "dt_Underwriting_ExclusionClause")

            With ds_Search_Param.Tables("dt_Underwriting_ExclusionClause")
                If .Rows.Count > 0 Then
                    Me.txtUnderwriting_ExclusionClause_Header.Text = .Rows(0).Item("ExclusionClause_Header") & " "
                    Me.txtUnderwriting_ExclusionClause_Footer.Text = .Rows(0).Item("ExclusionClause_Footer") & " "
                Else
                    MsgBox("Error in retrieving Exclusion Clause")
                    Exit Sub
                End If
            End With

            Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                Case "E17", "E19", "E21", "E31", "E34"
                    Me.txtUnderwriting_Other_Parameters.Clear()
                    Me.txtUnderwriting_Other_Parameters.Enabled = True
                Case Else
                    Me.txtUnderwriting_Other_Parameters.Clear()
                    Me.txtUnderwriting_Other_Parameters.Enabled = False
            End Select

        End If
    End Sub
    Private Sub btnDependent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent.Click
        Dim frmSearch_Dependents As New frmSearch_Param

        frmSearch_Dependents.lblForm_Flag.Text = "SC"
        With frmSearch_Dependents.dgvFind_Result
            .Columns.Add("Col1", "Full Name As in NRIC")
            .Columns.Add("Col2", "Relationship")

            .Rows.Clear()
            Dim var_dependent_count As Integer = 0

            Do While var_dependent_count < Me.dgvDependents.Rows.Count
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = Me.dgvDependents.Rows(var_dependent_count).Cells(1).Value.ToString.Trim
                .Rows(.Rows.Count - 1).Cells(1).Value = Me.dgvDependents.Rows(var_dependent_count).Cells(9).Value.ToString

                var_dependent_count += 1
            Loop
        End With


        frmSearch_Dependents.ShowDialog()

        Me.txtUnderwriting_ApplyTo.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Me.TabControl1.SelectedIndex -= 1
        If Me.TabControl1.SelectedIndex <= 0 Then
            Me.TabControl1.SelectedIndex = 0
        End If
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Me.TabControl1.SelectedIndex += 1
        If Me.TabControl1.SelectedIndex >= 6 Then
            Me.TabControl1.SelectedIndex = 6
        End If
    End Sub
    Private Sub btnDependent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Add.Click
        If Me.Verify_Dependent_Details() = True Then
            If Me.lblEdit_Status.Text = "Edit Mode" Then

                Dim cmdSelect_Proposer_Dependent_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_Dependent_New.CommandType = CommandType.Text
                cmdSelect_Proposer_Dependent_New.CommandText = "SELECT * FROM dt_Proposer_Dependents"

                Dim da_Proposer_Dependent_New As New SqlDataAdapter(cmdSelect_Proposer_Dependent_New)

                Dim cmdInsert_Proposer_Dependent_New As SqlCommandBuilder
                cmdInsert_Proposer_Dependent_New = New SqlCommandBuilder(da_Proposer_Dependent_New)


                Dim ds_Proposer As New DataSet


                da_Proposer_Dependent_New.Fill(ds_Proposer, "dt_Proposer_Dependents")

                Dim dr_Proposer_Dependent_New As DataRow
                Dim var_Proposer_Dependent_ID As String


                dr_Proposer_Dependent_New = ds_Proposer.Tables("dt_Proposer_Dependents").NewRow

                var_Proposer_Dependent_ID = Guid.NewGuid.ToString

                With dr_Proposer_Dependent_New
                    .Item("ID") = var_Proposer_Dependent_ID
                    .Item("Proposer_ID") = Me.lblProposer_ID.Text.Trim
                    .Item("Title") = Me.txtDependent_Title.Text.Trim
                    .Item("Full_Name") = Me.txtDependent_FirstName.Text.Trim
                    .Item("Birth_Date") = Me.dtpDependent_DOB.Value
                    .Item("IC_New") = Me.txtDependent_NRIC.Text.Trim
                    .Item("IC_Old") = Me.txtDependent_OldIC.Text.Trim
                    .Item("ArmForce_ID") = Me.txtDependent_ArmForceID.Text.Trim

                    If Me.rdiDependent_Race_Malay.Checked = True Then
                        .Item("Race") = "M"
                    ElseIf Me.rdiDependent_Race_Chinese.Checked = True Then
                        .Item("Race") = "C"
                    ElseIf Me.rdiDependent_Race_Indian.Checked = True Then
                        .Item("Race") = "I"
                    ElseIf Me.rdiDependent_Race_Others.Checked = True Then
                        .Item("Race") = "O"
                    End If

                    If Me.rdiDependent_MaritalStatus_Single.Checked = True Then
                        .Item("Marital_Status") = "S"
                    ElseIf Me.rdiDependent_MaritalStatus_Married.Checked = True Then
                        .Item("Marital_Status") = "M"
                    ElseIf Me.rdiDependent_MaritalStatus_Widowed.Checked = True Then
                        .Item("Marital_Status") = "W"
                    ElseIf Me.rdiDependent_MaritalStatus_Divorced.Checked = True Then
                        .Item("Marital_Status") = "D"
                    End If

                    .Item("Relationship") = Me.cmbDependent_Relationship.SelectedItem.ToString.Trim

                    If Me.rdiDependent_Sex_Male.Checked = True Then
                        .Item("Sex") = 1
                    ElseIf Me.rdiDependent_Sex_Female.Checked = True Then
                        .Item("Sex") = 0
                    End If

                    .Item("Height") = Val(Me.txtDependent_Height.Text)
                    .Item("Weight") = Val(Me.txtDependent_Weight.Text)
                    .Item("Occupation") = Me.txtDependent_Occupation.Text.Trim
                    .Item("Department") = Me.txtDependent_Department.Text.Trim
                    .Item("KeyInOrder") = iKIO
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    ds_Proposer.Tables("dt_Proposer_Dependents").Rows.Add(dr_Proposer_Dependent_New)
                    da_Proposer_Dependent_New.Update(ds_Proposer, "dt_Proposer_Dependents")
                    iKIO += 1
                End With


                Me.Reset_Enrolled_Dependents_Tab_Value()


                Me.Lock_Enrolled_Dependents_Tab(True)
                Me.btnDependent_Add.Visible = True
                Me.btnDependent_Update.Enabled = False
                Me.btnDependent_Update.Visible = False
                Me.btnDependent_CancelUpdate.Enabled = False
                Me.btnDependent_CancelUpdate.Visible = False


                Me.Populate_dgvDependents()
            Else
                With Me.dgvDependents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtDependent_Title.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtDependent_FirstName.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(2).Value = Me.dtpDependent_DOB.Value
                    .Rows(.Rows.Count - 1).Cells(3).Value = Math.Floor(DateDiff(DateInterval.Day, Me.dtpDependent_DOB.Value, Now()) / 365.25)
                    .Rows(.Rows.Count - 1).Cells(4).Value = Me.txtDependent_NRIC.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(5).Value = Me.txtDependent_OldIC.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(6).Value = Me.txtDependent_ArmForceID.Text.Trim

                    If Me.rdiDependent_Race_Malay.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(7).Value = "M"
                    ElseIf Me.rdiDependent_Race_Chinese.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(7).Value = "C"
                    ElseIf Me.rdiDependent_Race_Indian.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(7).Value = "I"
                    ElseIf Me.rdiDependent_Race_Others.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(7).Value = "O"
                    End If

                    If Me.rdiDependent_MaritalStatus_Single.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(8).Value = "S"
                    ElseIf Me.rdiDependent_MaritalStatus_Married.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(8).Value = "M"
                    ElseIf Me.rdiDependent_MaritalStatus_Widowed.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(8).Value = "W"
                    ElseIf Me.rdiDependent_MaritalStatus_Divorced.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(8).Value = "D"
                    End If

                    .Rows(.Rows.Count - 1).Cells(9).Value = Me.cmbDependent_Relationship.SelectedItem.ToString.Trim
                    If Me.rdiDependent_Sex_Male.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(10).Value = 1
                    ElseIf Me.rdiDependent_Sex_Female.Checked = True Then
                        .Rows(.Rows.Count - 1).Cells(10).Value = 0
                    End If

                    .Rows(.Rows.Count - 1).Cells(11).Value = Val(Me.txtDependent_Height.Text)
                    .Rows(.Rows.Count - 1).Cells(12).Value = Val(Me.txtDependent_Weight.Text)
                    .Rows(.Rows.Count - 1).Cells(13).Value = Me.txtDependent_Occupation.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(14).Value = Me.txtDependent_Department.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(16).Value = iKIO
                    iKIO += 1
                End With


                Me.Reset_Enrolled_Dependents_Tab_Value()
            End If
        End If
    End Sub
    Private Sub btnAgent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgent_Add.Click
        If Len(Me.txtProposer_Plan_Commission_AgentCode.Text.Trim) = 0 Then
            MsgBox("Please do select Agent Code.")
            Me.btnAgent.Focus()
        Else
            If Len(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim) = 0 Then
                MsgBox("Please do key in Share Percentage.")
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Focus()
            Else
                If Me.lblEdit_Status.Text = "Edit Mode" Then

                    Dim cmdSelect_Proposer_Agent_Commission_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_Proposer_Agent_Commission_New.CommandType = CommandType.Text
                    cmdSelect_Proposer_Agent_Commission_New.CommandText = "SELECT * FROM dt_Proposer_Agent_Commission"

                    Dim da_Proposer_Agent_Commission_New As New SqlDataAdapter(cmdSelect_Proposer_Agent_Commission_New)

                    Dim cmdInsert_Proposer_Agent_Commission_New As SqlCommandBuilder
                    cmdInsert_Proposer_Agent_Commission_New = New SqlCommandBuilder(da_Proposer_Agent_Commission_New)


                    Dim ds_Proposer As New DataSet


                    da_Proposer_Agent_Commission_New.Fill(ds_Proposer, "dt_Proposer_Agent_Commission")

                    Dim dr_Proposer_Agent_Commission_New As DataRow
                    Dim var_Proposer_Agent_Commission_ID As String


                    dr_Proposer_Agent_Commission_New = ds_Proposer.Tables("dt_Proposer_Agent_Commission").NewRow

                    var_Proposer_Agent_Commission_ID = Guid.NewGuid.ToString

                    With dr_Proposer_Agent_Commission_New
                        .Item("ID") = var_Proposer_Agent_Commission_ID
                        .Item("Proposer_ID") = Me.lblProposer_ID.Text.Trim
                        .Item("Agent_Code") = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                        .Item("Agent_Share_Percentage") = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Last_Modified_By") = My.Settings.Username.Trim
                        .Item("Last_Modified_On") = Now()

                        ds_Proposer.Tables("dt_Proposer_Agent_Commission").Rows.Add(dr_Proposer_Agent_Commission_New)
                        da_Proposer_Agent_Commission_New.Update(ds_Proposer, "dt_Proposer_Agent_Commission")
                    End With


                    Me.Reset_Insurance_Proposed_Tab_Agent_Value()


                    Me.Lock_Insurance_Proposed_Tab_Agent(True)
                    Me.btnAgent_Add.Visible = True
                    Me.btnAgent_Update.Enabled = False
                    Me.btnAgent_Update.Visible = False
                    Me.btnAgent_CancelUpdate.Enabled = False
                    Me.btnAgent_CancelUpdate.Visible = False


                    Me.Populate_dgvAgents()
                Else
                    With Me.dgvAgents
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = ""
                        .Rows(.Rows.Count - 1).Cells(2).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                    End With


                    Me.Reset_Insurance_Proposed_Tab_Agent_Value()
                End If
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to cancel this Proposer Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel this Proposer's Application Form")
        Select Case Result
            Case 6
                Me.Close()
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.Permit_To_Save = True Then
            If Me.chkProceed2Verification.Checked = True Then
                If Me.lblEdit_Status.Text = "Edit Mode" Then
                    If Me.lblE32.Text = "D1E32" Then
                        If vD1E32() Then
                            Exit Sub
                        End If
                    End If
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    Me.Save_Proposer_ApplicationForm_Changes()
                    PrintEnable()
                Else
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    Me.Save_Proposer_ApplicationForm_New()
                    
                End If
                Me.Lock_All_Controls(True)
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.btnPrint.Visible = True
            End If
        End If
    End Sub
    Private Sub btnPrint_AcknowledgementLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_AcknowledgementLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If
        If Me.lblProposer_Status.Text.Trim = "0" Then
            If Not My.Settings.Username = "Admin" Then
                If Me.dgvExclusion_Clause.Rows.Count > 0 Then
                    Dim iGCount As Integer = 0
                    Do While iGCount < Me.dgvExclusion_Clause.Rows.Count
                        If Me.dgvExclusion_Clause.Rows(iGCount).Cells(0).Value.ToString.Trim = "E31" Then
                            Dim dt As DataTable
                            dt = _objBusi.getDetails("EC", Me.lblProposer_ID.Text.Trim(), "", "", "", "E31", Conn)
                            If dt.Rows.Count = 1 Then
                                MsgBox("There is a EC E31 with one dependent, Please check it or check with you admin!")
                                Exit Sub
                            End If
                        End If
                        iGCount += 1
                    Loop
                End If
            End If


            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Statusaltered_on, Statusaltered_by FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1A"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If


        Dim rpt_acknowledgement As New Acknowledgement
        rpt_acknowledgement.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim
        rpt_acknowledgement.lblPlancode.Text = Me.txtProposer_Plan_Code.Text


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL1.Text.Trim

        If Len(Me.txtProposer_AddressL2.Text.Trim) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL2.Text.Trim & " " & Me.txtProposerAdd3.Text.ToString.Trim() & " " & Me.txtProposerAdd4.Text.ToString.Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_State.Text.Trim

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = " "
            Case 4
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select

        rpt_acknowledgement.Show()
    End Sub
    Private Sub btnPrint_DefermentLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_DefermentLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If
        If Me.lblProposer_Status.Text.Trim = "0" Then

            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Statusaltered_on, Statusaltered_by FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1D"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If

        Dim rpt_deferment As New Deferment
        rpt_deferment.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim
        rpt_deferment.lblPlanCode.Text = Me.txtProposer_Plan_Code.Text


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        Dim rpt_deferments As New Deferment
        rpt_deferments.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL1.Text.Trim

        If Len(Me.txtProposer_AddressL2.Text.Trim) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL2.Text.Trim & " " & Me.txtProposerAdd3.Text.ToString.Trim() & " " & Me.txtProposerAdd4.Text.ToString.Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_State.Text.Trim

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_deferment.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_deferment.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_deferment.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_deferments.LabelL4.Text = " "
            Case 4
                rpt_deferment.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_deferment.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_deferment.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_deferment.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim

        End Select



        Dim rpt_errorfields As New DataTable
        rpt_errorfields.Columns.Add("Col 1")
        If Me.chkDocumentation_CheckList_Proposer_Form.Checked = True Then
            If Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = True Then
            ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = True Then
                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Tidak Lengkap "
                If Me.cbTLBATarikh.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian A (Tarikh Lahir)"
                End If
                If Me.cbTLBANoTelefon.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian A (No Telefon)"
                End If
                If Me.cbTLBBNoKad.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (No Kad Pengenalan Pasangan)"
                End If
                If Me.cbTLBBNoSijil.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)"
                End If
                If Me.cbTLBBSurat.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Surat Pengambilan Anak Angkat)"
                End If
                If Me.cbTLBBSertakan.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Sertakan Sijil Kelahiran Anak)"
                End If
                If Me.cbTLBBPasangan.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)"
                End If



                If Me.cbTLBCSOAL.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian C (Soal Selidik)"
                End If
                If Me.cbTLBD.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian D & E (Tandatangan Pemohon)"
                End If
                If Me.cbTLJenis.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Jenis Pilihan Pelan"
                End If
                If Me.cbTLBP.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian Penamaan"
                End If
                If Me.chkBPTP.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian Pengisytiharan (Tandatangan Pemohon)"
                End If
                If Me.chkSDTS.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Seksyen D (Tandatangan Saksi)"
                End If
                If Me.chkSDTP.Checked Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Seksyen D (Tandatangan Pemilik)"
                End If
            Else
                If Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = True Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Borang Lama"
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = True Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Borang Salah"
                End If
            End If
        Else
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Tidak Disertakan"
        End If
        Dim sPlanCode As String()
        Dim sPcode As String
        sPlanCode = Me.txtProposer_Plan_Code.Text.ToString.Trim().Split("-")
        sPcode = sPlanCode(1).Substring(0, 1)

        If Me.chkDocumentation_CheckList_IC.Checked = False Then
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Kad Pengenalan / Tidak Disertakan"
        End If

        If Me.chkDocumentation_CheckList_PG.Checked = True Then
            If Me.rbPG6BTJ.Checked = True Then
                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terbaru / Tidak Disertakan"
            End If
        Else
            If Not sPcode = "Y" Then
                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terbaru"
            End If
        End If

        If Me.chkDocumentation_CheckList_Payslip.Enabled = True Then
            If Me.chkDocumentation_CheckList_Payslip.Checked = True Then
                If Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = True Then
                        rpt_errorfields.Rows.Add()
                        rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terkini / Tidak Jelas"
                    End If
                End If
            Else

                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Tidak Disertakan"

            End If
        Else
            If Not sPcode = "Y" Then
                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Tidak Disertakan"
            End If
        End If
        If Me.chkDocumentation_CheckList_Borang1_79.Enabled = True Then
            If Me.chkDocumentation_CheckList_Borang1_79.Checked = True Then
                If Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = True Then
                        rpt_errorfields.Rows.Add()
                        rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Terdapat kesilapan mengisi Borang Biro Angkasa 1/79"
                    ElseIf Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True Then
                        rpt_errorfields.Rows.Add()
                        rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Penggunaan 'liquid paper' pada Borang Biro Angkasa 1/79"
                    ElseIf Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = True Then
                        rpt_errorfields.Rows.Add()
                        rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Muat Turun Borang Biro Angkasa 1/79"
                    Else
                        If Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = True Then
                            rpt_errorfields.Rows.Add()
                            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Biro Angkasa 1/79 Tidak Lengkap"
                            If Me.cbTLTP.Checked Then
                                rpt_errorfields.Rows.Add()
                                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Tandatangan Pemohon"
                            End If
                            If Me.cbTLCM.Checked Then
                                rpt_errorfields.Rows.Add()
                                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Cop Majikan"
                            End If
                            If Me.cbTLTM.Checked Then
                                rpt_errorfields.Rows.Add()
                                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Tandatangan Majikan"
                            End If
                        Else
                            If Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True Then
                                rpt_errorfields.Rows.Add()
                                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Penggunaan 'liquid paper' pada Borang Biro Angkasa 1/79"
                            End If
                        End If
                    End If
                End If
            Else
                rpt_errorfields.Rows.Add()
                rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Biro Angkasa 1/79 Tidak Disertakan"
            End If
        End If
        Dim s As String
        s = rpt_errorfields.Rows.Count
        Select Case rpt_errorfields.Rows.Count
            Case 1
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = ""
                rpt_deferment.Label3.Text = ""
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 2
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = ""
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 3
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 4
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 5
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 6
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 7
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 8
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = rpt_errorfields.Rows(7).Item(0).ToString.Trim
                rpt_deferment.Label9.Text = ""
            Case 9
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = rpt_errorfields.Rows(7).Item(0).ToString.Trim
                rpt_deferment.Label9.Text = rpt_errorfields.Rows(8).Item(0).ToString.Trim
        End Select

        rpt_deferment.Show()
    End Sub
    Private Sub btnPrint_RejectLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_RejectLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If
        If Me.lblProposer_Status.Text.Trim = "0" Then
            Dim frmSearch_Title As New frmSearch_Param

            frmSearch_Title.lblForm_Flag.Text = "D"
            frmSearch_Title.ShowDialog()

            Me.lblReject_Reason.Text = My.Computer.Clipboard.GetText()
            My.Computer.Clipboard.Clear()


            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Decline_Reason, Statusaltered_on, Statusaltered_by FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1R"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Decline_Reason") = Me.lblReject_Reason.Text.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If

        If (Me.lblRejectReason.Text.Trim() = "PROPOSEREXISTS" Or Me.lblRejectReason.Text.Trim() = "PROPOSERSPOUSEEXISTS" Or Me.lblRejectReason.Text.Trim() = "PROPOSEROVERAGED") Then

            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Decline_Reason FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1R"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Decline_Reason") = Me.lblReject_Reason.Text.Trim
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If

        Dim rpt_reject As New Rejection
        rpt_reject.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim
        rpt_reject.lblReject_Reason.Text = Me.lblReject_Reason.Text.Trim
        rpt_reject.lblRejectReason.Text = Me.lblRejectReason.Text.Trim()
        rpt_reject.lblsDate.Text = sStartDate
        rpt_reject.lblPlanCode.Text = Me.txtProposer_Plan_Code.Text

        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL1.Text.Trim

        If Len(Me.txtProposer_AddressL2.Text.Trim) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL2.Text.Trim & " " & Me.txtProposerAdd3.Text.ToString.Trim() & " " & Me.txtProposerAdd4.Text.ToString.Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_State.Text.Trim

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_reject.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_reject.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_reject.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_reject.LabelL4.Text = " "
            Case 4
                rpt_reject.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_reject.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_reject.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_reject.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select

        rpt_reject.Show()
    End Sub
    Private Sub btnPrint_UnderwritingLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_UnderwritingLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If

        Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_New.CommandType = CommandType.Text
        cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Statusaltered_on, Statusaltered_by FROM dt_Proposer " & _
                                             "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

        Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

        Dim cmdInsert_Proposer_New As SqlCommandBuilder
        cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


        Dim ds_Proposer As New DataSet

        da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")
        If Me.lblProposer_Status.Text.Trim = "0" Then
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1PU"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
        Else
            If Not ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status").ToString.Trim() = "1U" Then
                If Me.rbUWCIMBYes.Checked Then
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1U"
                Else
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1PU"
                End If
            End If
        End If
        da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        PrintLetters.PrintProposer("UW.rpt", Me.lblProposer_ID.Text.Trim, "UW")
    End Sub
    Private Sub btnNominee_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNominee_Title.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtNominee_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnNominee_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNominee_Add.Click
        If Me.Verify_Nominee_Details() = True Then
            If Me.lblEdit_Status.Text = "Edit Mode" Then

                Dim cmdSelect_Proposer_Nomination_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_Nomination_New.CommandType = CommandType.Text
                cmdSelect_Proposer_Nomination_New.CommandText = "SELECT * FROM dt_Proposer_Nomination"

                Dim da_Proposer_Nomination_New As New SqlDataAdapter(cmdSelect_Proposer_Nomination_New)

                Dim cmdInsert_Proposer_Nomination_New As SqlCommandBuilder
                cmdInsert_Proposer_Nomination_New = New SqlCommandBuilder(da_Proposer_Nomination_New)


                Dim ds_Proposer As New DataSet


                da_Proposer_Nomination_New.Fill(ds_Proposer, "dt_Proposer_Nomination")

                Dim dr_Proposer_Nomination_New As DataRow
                Dim var_Proposer_Nomination_ID As String


                dr_Proposer_Nomination_New = ds_Proposer.Tables("dt_Proposer_Nomination").NewRow

                var_Proposer_Nomination_ID = Guid.NewGuid.ToString

                With dr_Proposer_Nomination_New
                    .Item("ID") = var_Proposer_Nomination_ID
                    .Item("Proposer_ID") = Me.lblProposer_ID.Text.Trim

                    .Item("Title") = Me.txtNominee_Title.Text.Trim
                    .Item("Full_Name") = Me.txtNominee_Name.Text.Trim
                    .Item("Birth_Date") = Me.dtpNominee_DOB.Value
                    .Item("IC_New") = Me.txtNominee_NRIC.Text.Trim

                    .Item("Relationship") = Me.cbNominee_Relationship.Text.Trim
                    .Item("Add1") = Me.txtNAdd1.Text.Trim()
                    .Item("Add2") = Me.txtNAdd2.Text.Trim()
                    .Item("Add3") = Me.txtNAdd3.Text.Trim()
                    .Item("Add4") = Me.txtNAdd4.Text.Trim()
                    .Item("Town") = Me.txtNTown.Text.Trim()
                    .Item("State") = Me.txtNState.Text.Trim()
                    .Item("Poscode") = Me.txtNPoscode.Text.Trim()

                    .Item("Share") = Me.txtNominee_SharePercentage.Text.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    ds_Proposer.Tables("dt_Proposer_Nomination").Rows.Add(dr_Proposer_Nomination_New)
                    da_Proposer_Nomination_New.Update(ds_Proposer, "dt_Proposer_Nomination")
                End With


                Me.Reset_Nominee_Tab_Value()


                Me.Lock_Nomination_Tab(True)
                Me.btnNominee_Add.Visible = True
                Me.btnNominee_Update.Enabled = False
                Me.btnNominee_Update.Visible = False
                Me.btnNominee_CancelUpdate.Enabled = False
                Me.btnNominee_CancelUpdate.Visible = False


                Me.Populate_dgvNominees()
            Else
                With Me.dgvNominees
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtNominee_Title.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtNominee_Name.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(2).Value = Me.dtpNominee_DOB.Value
                    .Rows(.Rows.Count - 1).Cells(3).Value = Me.txtNominee_NRIC.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(4).Value = Me.cbNominee_Relationship.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(5).Value = Me.txtNAdd1.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(6).Value = Me.txtNAdd2.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(7).Value = Me.txtNAdd3.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(8).Value = Me.txtNAdd4.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(9).Value = Me.txtNTown.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(10).Value = Me.txtNState.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(11).Value = Me.txtNPoscode.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(12).Value = Me.txtNominee_SharePercentage.Text.Trim
                End With


                Me.Reset_Nominee_Tab_Value()
            End If
        Else
            MsgBox("There is an error in the Nominee's details, pls verify")
            Exit Sub
        End If
    End Sub
    Private Sub btnExclusionClause_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclusionClause_Add.Click
        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) = 0 Then
            MsgBox("Please do select the exclusion clause!")
            Exit Sub
        Else
            If Not Me.chkUnderwriting_ApplyTo.Checked Then
                If Len(Me.txtUnderwriting_ApplyTo.Text.Trim()) = 0 Then
                    MsgBox("Please do select the exclusion clause Apply to whom?")
                    Exit Sub
                End If
            End If
            Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                Case "E17", "E19", "E21", "E31", "E34"
                    If Len(Me.txtUnderwriting_Other_Parameters.Text.Trim) = 0 Then
                        MsgBox("Please do key in the Other Parameters field")
                        Exit Sub
                    End If
            End Select

            If Me.lblEdit_Status.Text = "Edit Mode" Then

                Dim cmdSelect_Proposer_ExclusionClause_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_ExclusionClause_New.CommandType = CommandType.Text
                cmdSelect_Proposer_ExclusionClause_New.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause"

                Dim da_Proposer_ExclusionClause_New As New SqlDataAdapter(cmdSelect_Proposer_ExclusionClause_New)

                Dim cmdInsert_Proposer_ExclusionClause_New As SqlCommandBuilder
                cmdInsert_Proposer_ExclusionClause_New = New SqlCommandBuilder(da_Proposer_ExclusionClause_New)


                Dim ds_Proposer As New DataSet


                da_Proposer_ExclusionClause_New.Fill(ds_Proposer, "dt_Proposer_Exclusion_Clause")

                Dim dr_Proposer_ExclusionClause_New As DataRow
                Dim var_Proposer_ExclusionClause_ID As String


                dr_Proposer_ExclusionClause_New = ds_Proposer.Tables("dt_Proposer_Exclusion_Clause").NewRow

                var_Proposer_ExclusionClause_ID = Guid.NewGuid.ToString

                With dr_Proposer_ExclusionClause_New
                    .Item("ID") = var_Proposer_ExclusionClause_ID
                    .Item("Proposer_ID") = Me.lblProposer_ID.Text.Trim
                    .Item("ExclusionClause_Code") = Me.txtUnderwriting_ExclusionClause_Code.Text.Trim

                    Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                        Case "E17", "E19", "E21", "E31"
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                       Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                       Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                       Me.txtProposer_Name.Text.Trim & " "
                            Else
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                       Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                       Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                       Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                            End If
                        Case "E33"
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                            Else
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                            End If
                        Case "E34"
                            .Item("ExclusionClause_Description") = Me.txtUnderwriting_Other_Parameters.Text.Trim
                        Case Else
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim
                            Else
                                .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim
                            End If
                    End Select

                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    ds_Proposer.Tables("dt_Proposer_Exclusion_Clause").Rows.Add(dr_Proposer_ExclusionClause_New)
                    da_Proposer_ExclusionClause_New.Update(ds_Proposer, "dt_Proposer_Exclusion_Clause")
                End With


                Me.Reset_Underwriting_Tab_Value()


                Me.Lock_Underwriting_Tab(True)
                Me.btnExclusionClause_Add.Visible = True
                Me.btnExclusionClause_Update.Enabled = False
                Me.btnExclusionClause_Update.Visible = False
                Me.btnExclusionClause_CancelUpdate.Enabled = False
                Me.btnExclusionClause_CancelUpdate.Visible = False


                Me.Populate_dgvExclusion_Clause()
            Else
                With Me.dgvExclusion_Clause
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtUnderwriting_ExclusionClause_Code.Text.Trim

                    Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                        Case "E17", "E19", "E21", "E31"
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                        Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                        Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                        Me.txtProposer_Name.Text.Trim & " "
                            Else
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                        Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                        Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                        Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                            End If
                        Case "E33"
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                            Else
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                            End If
                        Case "E34"
                            .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_Other_Parameters.Text.Trim
                        Case Else
                            If Me.chkUnderwriting_ApplyTo.Checked = True Then
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim
                            Else
                                .Rows(.Rows.Count - 1).Cells(1).Value = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim
                            End If
                    End Select
                    .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                    Me.Reset_Underwriting_Tab_Value()
                End With
            End If
        End If
    End Sub
    Private Sub btnInsert_Angkasa_FileNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert_Angkasa_FileNo.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to proceed with the insertion of Angkasa File No to this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fill in Angkasa File # to the Proposer Form")
        Select Case Result
            Case 6

                Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_New.CommandType = CommandType.Text
                cmdSelect_Proposer_New.CommandText = "SELECT ID, Angkasa_FileNo, Last_Modified_By, Last_Modified_On FROM dt_Proposer " & _
                                                     "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

                Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

                Dim cmdInsert_Proposer_New As SqlCommandBuilder
                cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


                Dim ds_Proposer As New DataSet


                da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Angkasa_FileNo") = Me.txtAngkasa_FileNo.Text.Trim
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Last_Modified_By") = My.Settings.Username.ToString.Trim
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Last_Modified_On") = Now()
                da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
                MsgBox("Update done.")
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.lblForm_Flag.Text <> "Unlock" Then
            Me.Lock_All_Controls(False)
            Me.btnPrint.Visible = False
            Me.dgvDependents.MultiSelect = False
            Me.dgvDependents.ContextMenuStrip = Me.cmsDependent

            Me.dgvAgents.MultiSelect = False
            Me.dgvAgents.ContextMenuStrip = Me.cmsAgent


            Me.dgvNominees.MultiSelect = False
            Me.dgvNominees.ContextMenuStrip = Me.cmsNominee

            Me.dgvExclusion_Clause.MultiSelect = False
            Me.dgvExclusion_Clause.ContextMenuStrip = Me.cmsExclusionClause
        Else

            Me.txtProposer_Title.ReadOnly = False
            Me.btnTitle.Enabled = True
            Me.txtProposer_Name.ReadOnly = False
            Me.dtpProposer_DOB.Enabled = True
            Me.txtProposer_NRIC.ReadOnly = False
            Me.txtProposer_OldIC.ReadOnly = False
            Me.txtProposer_ArmForceID.ReadOnly = False
            Me.rdiProposer_Race_Malay.AutoCheck = True
            Me.rdiProposer_Race_Chinese.AutoCheck = True
            Me.rdiProposer_Race_Indian.AutoCheck = True
            Me.rdiProposer_Race_Others.AutoCheck = True
            Me.txtAngkasa_FileNo.ReadOnly = False
            Me.rdiProposer_MaritalStatus_Single.AutoCheck = True
            Me.rdiProposer_MaritalStatus_Married.AutoCheck = True
            Me.rdiProposer_MaritalStatus_Widowed.AutoCheck = True
            Me.rdiProposer_MaritalStatus_Divorced.AutoCheck = True
            Me.rdiProposer_Sex_Male.AutoCheck = True
            Me.rdiProposer_Sex_Female.AutoCheck = True
            Me.dtpProposal_Received_Date.Enabled = True
            Me.dtpDateofSigned.Enabled = True
            Me.txtProposer_AddressL1.ReadOnly = False
            Me.txtProposer_AddressL2.ReadOnly = False
            Me.txtProposer_City.ReadOnly = False
            Me.txtProposer_Postcode.ReadOnly = False
            Me.txtProposer_State.ReadOnly = False
            Me.btnState.Enabled = True
            Me.txtProposer_Phone_Hse.ReadOnly = False
            Me.txtProposer_Mobile.ReadOnly = False
            Me.txtProposer_Phone_Ofc.ReadOnly = False
            Me.txtProposer_Email.ReadOnly = False
            Me.txtProposer_Height.ReadOnly = False
            Me.txtProposer_Weight.ReadOnly = False
            Me.txtProposer_Occupation.ReadOnly = False
            Me.txtProposer_Department.ReadOnly = False


            Me.txtProposer_Plan_Code.ReadOnly = True
            Me.btnPlan.Enabled = True
            Me.txtProposer_L2_Plan_Code.ReadOnly = True

            Me.txtProposer_Plan_Premium.ReadOnly = False
            Me.chkProposer_Plan_SpecialPromo.AutoCheck = False

            Me.rdiProposer_Plan_Payment_Frequency_Yearly.AutoCheck = False
            Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.AutoCheck = False
            Me.rdiProposer_Plan_Payment_Frequency_Quarterly.AutoCheck = False
            Me.rdiProposer_Plan_Payment_Frequency_Monthly.AutoCheck = False
            Me.txtProposer_Plan_Payment_Method.ReadOnly = True
            
            Select Case Me.txtProposer_Plan_Payment_Method.Text
                Case "Credit Card"
                    Me.txtProposer_Plan_Payment_CreditCard_Batch_No.ReadOnly = True
                    Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.ReadOnly = True
                    Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.ReadOnly = True
                Case "Cheque"
                    Me.txtProposer_Plan_Payment_Cheque_No.ReadOnly = True
                    Me.txtProposer_Plan_Payment_Cheque_Receipt_No.ReadOnly = True
                Case "Cash"
                    Me.txtProposer_Plan_Payment_Receipt_No.ReadOnly = True
                    Me.txtProposer_Plan_Payment_Receipt_IssuedBy.ReadOnly = True
            End Select
            
            Me.txtBorang1_79_SN.ReadOnly = False


            Me.chkDataEntry_CheckList_Proposer_Details.AutoCheck = False
            Me.chkDataEntry_CheckList_Dependent_Details.AutoCheck = False
            Me.chkDataEntry_CheckList_InsuranceProposed_Details.AutoCheck = False
            Me.chkDataEntry_CheckList_BiroAngkasa_Details.AutoCheck = False
            Me.chkDataEntry_CheckList_Nomination.AutoCheck = False
            Me.chkDocumentation_CheckList_Proposer_Form.AutoCheck = False
            Me.rdiDocumentation_CheckList_Proposer_Form_Complete.AutoCheck = False
            Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.AutoCheck = False
            Me.cbTLBATarikh.AutoCheck = False
            Me.cbTLBANoTelefon.AutoCheck = False
            Me.cbTLBBNoKad.AutoCheck = False
            Me.cbTLBBNoSijil.AutoCheck = False
            Me.cbTLBBSurat.AutoCheck = False
            Me.cbTLBBSertakan.AutoCheck = False
            Me.cbTLBBPasangan.AutoCheck = False
            Me.cbTLBCSOAL.AutoCheck = False
            Me.cbTLBD.AutoCheck = False
            Me.cbTLJenis.AutoCheck = False
            Me.cbTLBP.AutoCheck = False
            Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.AutoCheck = False
            Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.AutoCheck = False
            Me.chkDocumentation_CheckList_IC.AutoCheck = False
            Me.chkDocumentation_CheckList_PG.AutoCheck = False
            Me.rbPG6BTJ.AutoCheck = False
            Me.rbPG6BJ.AutoCheck = False
            Me.chkDocumentation_CheckList_Payslip.AutoCheck = False
            Me.rdiDocumentation_CheckList_Payslip_Clear.AutoCheck = False
            Me.rdiDocumentation_CheckList_Payslip_NotClear.AutoCheck = False
            Me.chkDocumentation_CheckList_Borang1_79.AutoCheck = False
            Me.rdiDocumentation_CheckList_Borang1_79_Complete.AutoCheck = False
            Me.rdiDocumentation_CheckList_Borang1_79_Error.AutoCheck = False
            Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.AutoCheck = False
            Me.rdiDocumentation_CheckList_Borang1_79_InComplete.AutoCheck = False
            Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.AutoCheck = False
            Me.cbTLTP.AutoCheck = False
            Me.cbTLCM.AutoCheck = False
            Me.chkProceed2Verification.AutoCheck = True
        End If

        Me.Lock_Enrolled_Dependents_Tab(True)
        Me.Lock_Insurance_Proposed_Tab_Agent(True)

        Me.Lock_Nomination_Tab(True)
        Me.Lock_Underwriting_Tab(True)

        Me.lblEdit_Status.Text = "Edit Mode"
        Me.lblEdit_Status.Location = New Point(22, 15)
        Me.lblEdit_Status.Visible = True
        Me.btnEdit.Enabled = False
        Me.btnEdit.Visible = False

        Me.flpUWCIMB.Enabled = True
        Me.rbUWCIMBNo.Enabled = True
        Me.rbUWCIMBYes.Enabled = True
    End Sub
    Private Sub cmsDependent_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDependent_Edit.Click
        If Me.dgvDependents.SelectedRows.Count = 1 Then

            Me.Lock_Enrolled_Dependents_Tab(False)
            Me.btnDependent_Add.Enabled = False
            Me.btnDependent_Add.Visible = False
            Me.btnDependent_Update.Enabled = True
            Me.btnDependent_Update.Visible = True
            Me.btnDependent_CancelUpdate.Enabled = True
            Me.btnDependent_CancelUpdate.Visible = True
            Me.btnDependent_CancelUpdate.Location = New Point(690, 251)


            With Me.dgvDependents.SelectedRows(0)
                Me.txtDependent_Title.Text = .Cells(0).Value.ToString.Trim
                Me.txtDependent_FirstName.Text = .Cells(1).Value.ToString.Trim
                Me.dtpDependent_DOB.Value = .Cells(2).Value
                Me.txtDependent_Age.Text = .Cells(3).Value
                Me.txtDependent_NRIC.Text = .Cells(4).Value.ToString.Trim
                Me.txtDependent_OldIC.Text = .Cells(5).Value.ToString.Trim
                Me.txtDependent_ArmForceID.Text = .Cells(6).Value.ToString.Trim

                Select Case .Cells(7).Value.ToString.Trim
                    Case "M"
                        Me.rdiDependent_Race_Malay.Checked = True
                    Case "C"
                        Me.rdiDependent_Race_Chinese.Checked = True
                    Case "I"
                        Me.rdiDependent_Race_Indian.Checked = True
                    Case "O"
                        Me.rdiDependent_Race_Others.Checked = True
                End Select

                Select Case .Cells(8).Value.ToString.Trim
                    Case "S"
                        Me.rdiDependent_MaritalStatus_Single.Checked = True
                    Case "M"
                        Me.rdiDependent_MaritalStatus_Married.Checked = True
                    Case "W"
                        Me.rdiDependent_MaritalStatus_Widowed.Checked = True
                    Case "D"
                        Me.rdiDependent_MaritalStatus_Divorced.Checked = True
                End Select

                Me.cmbDependent_Relationship.SelectedItem = .Cells(9).Value.ToString.Trim

                If .Cells(10).Value = True Then
                    Me.rdiDependent_Sex_Male.Checked = True
                Else
                    Me.rdiDependent_Sex_Female.Checked = True
                End If

                Me.txtDependent_Height.Text = .Cells(11).Value
                Me.txtDependent_Weight.Text = .Cells(12).Value
                Me.txtDependent_Occupation.Text = .Cells(13).Value.ToString.Trim
                Me.txtDependent_Department.Text = .Cells(14).Value.ToString.Trim
                Me.lblDependent_ID.Text = .Cells(15).Value.ToString.Trim
                If Not IsNothing(.Cells(16).Value) Then
                    iKIO = .Cells(16).Value.ToString.Trim
                End If
            End With
        Else
            MsgBox("Please do select the Dependent which you would like to edit.")
        End If
    End Sub
    Private Sub btnDependent_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Update.Click
        If Me.Verify_Dependent_Details() = True Then

            Dim cmdSelect_Proposer_Dependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Dependent.CommandType = CommandType.Text
            cmdSelect_Proposer_Dependent.CommandText = "SELECT * FROM dt_Proposer_Dependents " & _
                                                       "WHERE ID = '" & Me.lblDependent_ID.Text.Trim & "'"

            Dim da_Proposer_Dependent As New SqlDataAdapter(cmdSelect_Proposer_Dependent)

            Dim cmdUpdate_Proposer_Dependent As SqlCommandBuilder
            cmdUpdate_Proposer_Dependent = New SqlCommandBuilder(da_Proposer_Dependent)


            Dim ds_Proposer_Dependent As New DataSet


            da_Proposer_Dependent.Fill(ds_Proposer_Dependent, "dt_Proposer_Dependents")

            With ds_Proposer_Dependent.Tables("dt_Proposer_Dependents").Rows(0)
                .Item("Title") = Me.txtDependent_Title.Text.Trim
                .Item("Full_Name") = Me.txtDependent_FirstName.Text.Trim
                .Item("Birth_Date") = Me.dtpDependent_DOB.Value
                .Item("IC_New") = Me.txtDependent_NRIC.Text.Trim
                .Item("IC_Old") = Me.txtDependent_OldIC.Text.Trim
                .Item("ArmForce_ID") = Me.txtDependent_ArmForceID.Text.Trim

                If Me.rdiDependent_Race_Malay.Checked = True Then
                    .Item("Race") = "M"
                ElseIf Me.rdiDependent_Race_Chinese.Checked = True Then
                    .Item("Race") = "C"
                ElseIf Me.rdiDependent_Race_Indian.Checked = True Then
                    .Item("Race") = "I"
                ElseIf Me.rdiDependent_Race_Others.Checked = True Then
                    .Item("Race") = "O"
                End If

                If Me.rdiDependent_MaritalStatus_Single.Checked = True Then
                    .Item("Marital_Status") = "S"
                ElseIf Me.rdiDependent_MaritalStatus_Married.Checked = True Then
                    .Item("Marital_Status") = "M"
                ElseIf Me.rdiDependent_MaritalStatus_Widowed.Checked = True Then
                    .Item("Marital_Status") = "W"
                ElseIf Me.rdiDependent_MaritalStatus_Divorced.Checked = True Then
                    .Item("Marital_Status") = "D"
                End If

                .Item("Relationship") = Me.cmbDependent_Relationship.SelectedItem.ToString.Trim

                If Me.rdiDependent_Sex_Male.Checked = True Then
                    .Item("Sex") = 1
                ElseIf Me.rdiDependent_Sex_Female.Checked = True Then
                    .Item("Sex") = 0
                End If

                .Item("Height") = Val(Me.txtDependent_Height.Text)
                .Item("Weight") = Val(Me.txtDependent_Weight.Text)
                .Item("Occupation") = Me.txtDependent_Occupation.Text.Trim
                .Item("Department") = Me.txtDependent_Department.Text.Trim
                .Item("KeyInOrder") = iKIO
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
                iKIO += 1
            End With

            da_Proposer_Dependent.Update(ds_Proposer_Dependent, "dt_Proposer_Dependents")
            MsgBox("Update done.")


            Me.Reset_Enrolled_Dependents_Tab_Value()


            Me.Lock_Enrolled_Dependents_Tab(True)
            Me.btnDependent_Add.Visible = True
            Me.btnDependent_Update.Enabled = False
            Me.btnDependent_Update.Visible = False
            Me.btnDependent_CancelUpdate.Enabled = False
            Me.btnDependent_CancelUpdate.Visible = False


            Me.Populate_dgvDependents()
        End If
    End Sub
    Private Sub btnDependent_CancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_CancelUpdate.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to cancel the update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel update for Dependent's details")
        Select Case Result
            Case 6

                Me.Reset_Enrolled_Dependents_Tab_Value()


                Me.Lock_Enrolled_Dependents_Tab(True)
                Me.btnDependent_Add.Visible = True
                Me.btnDependent_Update.Enabled = False
                Me.btnDependent_Update.Visible = False
                Me.btnDependent_CancelUpdate.Enabled = False
                Me.btnDependent_CancelUpdate.Visible = False
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub cmsDependent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDependent_Add.Click

        Me.Reset_Enrolled_Dependents_Tab_Value()


        Me.Lock_Enrolled_Dependents_Tab(False)
        Me.btnDependent_Add.Enabled = True
        Me.btnDependent_Add.Visible = True
        Me.btnDependent_Update.Enabled = False
        Me.btnDependent_Update.Visible = False
        Me.btnDependent_CancelUpdate.Enabled = False
        Me.btnDependent_CancelUpdate.Visible = False
    End Sub
    Private Sub cmsDependent_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDependent_Delete.Click
        If Me.lblFIND.Text = "FIND" Then
            If Me.dgvDependents.SelectedRows.Count = 1 Then
                Dim Result As Integer
                Result = MsgBox("Do you want to delete this Dependent's record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Dependent's details")
                Select Case Result
                    Case 6
                        Me.dgvDependents.Rows.RemoveAt(dgvDependents.CurrentRow.Index)
                    Case 7
                        Exit Sub
                End Select
            Else
                MsgBox("Please do select the Dependent which you would like to delete.")
            End If
        Else
            If Me.txtProposer_Plan_Code.Text.Trim() = "WRONGCODE" Then
                If Me.dgvDependents.SelectedRows.Count = 1 Then
                    Me.dgvDependents.Rows.RemoveAt(dgvDependents.CurrentRow.Index)
                    Me.txtProposer_Plan_Code.Text = ""
                End If
            End If
            If Me.dgvDependents.SelectedRows.Count = 1 Then
                Dim Result As Integer
                Result = MsgBox("Do you want to delete this Dependent's record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Dependent's details")
                Select Case Result
                    Case 6

                        Dim cmdSelect_Proposer_Dependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        cmdSelect_Proposer_Dependent.CommandType = CommandType.Text
                        cmdSelect_Proposer_Dependent.CommandText = "SELECT * FROM dt_Proposer_Dependents " & _
                                                                   "WHERE ID = '" & Me.dgvDependents.SelectedRows(0).Cells(15).Value.ToString.Trim & "'"

                        Dim da_Proposer_Dependent As New SqlDataAdapter(cmdSelect_Proposer_Dependent)

                        Dim cmdUpdate_Proposer_Dependent As SqlCommandBuilder
                        cmdUpdate_Proposer_Dependent = New SqlCommandBuilder(da_Proposer_Dependent)


                        Dim ds_Proposer_Dependent As New DataSet


                        da_Proposer_Dependent.Fill(ds_Proposer_Dependent, "dt_Proposer_Dependents")

                        If ds_Proposer_Dependent.Tables("dt_Proposer_Dependents").Rows.Count = 1 Then
                            ds_Proposer_Dependent.Tables("dt_Proposer_Dependents").Rows(0).Delete()

                            da_Proposer_Dependent.Update(ds_Proposer_Dependent, "dt_Proposer_Dependents")
                            MsgBox("Record deleted.")


                            Me.Populate_dgvDependents()
                        Else
                            MsgBox("More than 1 records found for this dependent, please contact the system vendor.")
                        End If
                    Case 7
                        Exit Sub
                End Select
            Else
                MsgBox("Please do select the Dependent which you would like to delete.")
            End If
        End If
    End Sub
    Private Sub cmsAgent_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAgent_Edit.Click
        If Me.dgvAgents.SelectedRows.Count = 1 Then

            Me.Lock_Insurance_Proposed_Tab_Agent(False)
            Me.btnAgent_Add.Enabled = False
            Me.btnAgent_Add.Visible = False
            Me.btnAgent_Update.Enabled = True
            Me.btnAgent_Update.Visible = True
            Me.btnAgent_CancelUpdate.Enabled = True
            Me.btnAgent_CancelUpdate.Visible = True
            Me.btnAgent_CancelUpdate.Location = New Point(652, 13)


            With Me.dgvAgents.SelectedRows(0)
                Me.txtProposer_Plan_Commission_AgentCode.Text = .Cells(0).Value.ToString.Trim
                Me.lblStaff_Name.Text = .Cells(1).Value.ToString.Trim
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = .Cells(2).Value.ToString
                Me.lblAgent_ID.Text = .Cells(3).Value.ToString.Trim
            End With
        Else
            MsgBox("Please do select the Agent which you would like to edit.")
        End If
    End Sub
    Private Sub btnAgent_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgent_Update.Click
        If Len(Me.txtProposer_Plan_Commission_AgentCode.Text.Trim) = 0 Then
            MsgBox("Please do select Agent Code.")
            Me.btnAgent.Focus()
        Else
            If Len(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim) = 0 Then
                MsgBox("Please do key in Share Percentage.")
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Focus()
            Else

                Dim cmdSelect_Proposer_Agent_Commission As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_Agent_Commission.CommandType = CommandType.Text
                cmdSelect_Proposer_Agent_Commission.CommandText = "SELECT * FROM dt_Proposer_Agent_Commission " & _
                                                                  "WHERE ID = '" & Me.lblAgent_ID.Text.Trim & "'"

                Dim da_Proposer_Agent_Commission As New SqlDataAdapter(cmdSelect_Proposer_Agent_Commission)

                Dim cmdUpdate_Proposer_Agent_Commission As SqlCommandBuilder
                cmdUpdate_Proposer_Agent_Commission = New SqlCommandBuilder(da_Proposer_Agent_Commission)


                Dim ds_Proposer_Agent_Commission As New DataSet


                da_Proposer_Agent_Commission.Fill(ds_Proposer_Agent_Commission, "dt_Proposer_Agent_Commission")

                With ds_Proposer_Agent_Commission.Tables("dt_Proposer_Agent_Commission").Rows(0)
                    .Item("Agent_Code") = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                    .Item("Agent_Share_Percentage") = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                    .Item("Agent_Level") = Me.lblStaff_Name.Text.ToString.Trim
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()
                End With

                da_Proposer_Agent_Commission.Update(ds_Proposer_Agent_Commission, "dt_Proposer_Agent_Commission")
                MsgBox("Update done.")


                Me.Reset_Insurance_Proposed_Tab_Agent_Value()


                Me.Lock_Insurance_Proposed_Tab_Agent(True)

                Me.btnAgent_Add.Visible = True
                Me.btnAgent_Update.Enabled = False
                Me.btnAgent_Update.Visible = False
                Me.btnAgent_CancelUpdate.Enabled = False
                Me.btnAgent_CancelUpdate.Visible = False


                Me.Populate_dgvAgents()
            End If
        End If
    End Sub
    Private Sub btnAgent_CancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgent_CancelUpdate.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to cancel the update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel update for Agent Commisison's details")
        Select Case Result
            Case 6

                Me.Reset_Insurance_Proposed_Tab_Agent_Value()


                Me.Lock_Insurance_Proposed_Tab_Agent(True)
                Me.btnAgent_Add.Visible = True
                Me.btnAgent_Update.Enabled = False
                Me.btnAgent_Update.Visible = False
                Me.btnAgent_CancelUpdate.Enabled = False
                Me.btnAgent_CancelUpdate.Visible = False
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub cmsAgent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAgent_Add.Click

        Me.Reset_Insurance_Proposed_Tab_Agent_Value()


        Me.Lock_Insurance_Proposed_Tab_Agent(False)
        Me.btnAgent_Add.Enabled = True
        Me.btnAgent_Add.Visible = True
        Me.btnAgent_Update.Enabled = False
        Me.btnAgent_Update.Visible = False
        Me.btnAgent_CancelUpdate.Enabled = False
        Me.btnAgent_CancelUpdate.Visible = False
    End Sub
    Private Sub cmsAgent_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAgent_Delete.Click
        If Me.dgvAgents.SelectedRows.Count = 1 Then
            Dim Result As Integer
            Result = MsgBox("Do you want to delete this Agent's record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Agent's details")
            Select Case Result
                Case 6

                    Dim cmdSelect_Proposer_Agent_Commission As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_Proposer_Agent_Commission.CommandType = CommandType.Text
                    cmdSelect_Proposer_Agent_Commission.CommandText = "SELECT * FROM dt_Proposer_Agent_Commission " & _
                                                                      "WHERE ID = '" & Me.dgvAgents.SelectedRows(0).Cells(3).Value.ToString.Trim & "'"

                    Dim da_Proposer_Agent_Commission As New SqlDataAdapter(cmdSelect_Proposer_Agent_Commission)

                    Dim cmdUpdate_Proposer_Agent_Commission As SqlCommandBuilder
                    cmdUpdate_Proposer_Agent_Commission = New SqlCommandBuilder(da_Proposer_Agent_Commission)


                    Dim ds_Proposer_Agent_Commission As New DataSet


                    da_Proposer_Agent_Commission.Fill(ds_Proposer_Agent_Commission, "dt_Proposer_Agent_Commission")

                    If ds_Proposer_Agent_Commission.Tables("dt_Proposer_Agent_Commission").Rows.Count = 1 Then
                        ds_Proposer_Agent_Commission.Tables("dt_Proposer_Agent_Commission").Rows(0).Delete()

                        da_Proposer_Agent_Commission.Update(ds_Proposer_Agent_Commission, "dt_Proposer_Agent_Commission")
                        MsgBox("Record deleted.")


                        Me.Populate_dgvAgents()
                    Else
                        MsgBox("More than 1 records found for this agent, please contact the system vendor.")
                    End If
                Case 7
                    Exit Sub
            End Select
        Else
            MsgBox("Please do select the Agent which you would like to delete.")
        End If
    End Sub
#Region "Nominee"
    Private Sub cmsNominee_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsNominee_Edit.Click
        If Me.dgvNominees.SelectedRows.Count = 1 Then

            Me.Lock_Nomination_Tab(False)
            Me.btnNominee_Add.Enabled = False
            Me.btnNominee_Add.Visible = False
            Me.btnNominee_Update.Enabled = True
            Me.btnNominee_Update.Visible = True
            Me.btnNominee_CancelUpdate.Enabled = True
            Me.btnNominee_CancelUpdate.Visible = True
            Me.btnNominee_CancelUpdate.Location = New Point(698, 250)


            With Me.dgvNominees.SelectedRows(0)
                Me.txtNominee_Title.Text = .Cells(0).Value.ToString.Trim
                Me.txtNominee_Name.Text = .Cells(1).Value.ToString.Trim
                Me.dtpNominee_DOB.Value = .Cells(2).Value
                Me.txtNominee_NRIC.Text = .Cells(3).Value.ToString.Trim
                Me.cbNominee_Relationship.Text = .Cells(4).Value.ToString.Trim
                Me.txtNAdd1.Text = .Cells(5).Value.ToString.Trim
                Me.txtNAdd2.Text = .Cells(6).Value.ToString.Trim
                Me.txtNAdd3.Text = .Cells(7).Value.ToString.Trim
                Me.txtNAdd4.Text = .Cells(8).Value.ToString.Trim
                Me.txtNTown.Text = .Cells(9).Value.ToString.Trim
                Me.txtNState.Text = .Cells(10).Value.ToString.Trim
                Me.txtNPoscode.Text = .Cells(11).Value.ToString.Trim
                Me.txtNominee_SharePercentage.Text = .Cells(12).Value
                .Cells(12).Value = 0
                Me.lblNominee_ID.Text = .Cells(13).Value.ToString.Trim
            End With
        Else
            MsgBox("Please do select the Nominee which you would like to edit.")
        End If
    End Sub
    Private Sub btnNominee_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNominee_Update.Click
        If Me.Verify_Nominee_Details() = True Then

            Dim cmdSelect_Proposer_Nominee As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Nominee.CommandType = CommandType.Text
            cmdSelect_Proposer_Nominee.CommandText = "SELECT * FROM dt_Proposer_Nomination " & _
                                                     "WHERE ID = '" & Me.lblNominee_ID.Text.Trim & "'"

            Dim da_Proposer_Nominee As New SqlDataAdapter(cmdSelect_Proposer_Nominee)

            Dim cmdUpdate_Proposer_Nominee As SqlCommandBuilder
            cmdUpdate_Proposer_Nominee = New SqlCommandBuilder(da_Proposer_Nominee)


            Dim ds_Proposer_Nominee As New DataSet


            da_Proposer_Nominee.Fill(ds_Proposer_Nominee, "dt_Proposer_Nomination")

            With ds_Proposer_Nominee.Tables("dt_Proposer_Nomination").Rows(0)
                .Item("Title") = Me.txtNominee_Title.Text.Trim
                .Item("Full_Name") = Me.txtNominee_Name.Text.Trim
                .Item("Birth_Date") = Me.dtpNominee_DOB.Value
                .Item("IC_New") = Me.txtNominee_NRIC.Text.Trim
                .Item("Relationship") = Me.cbNominee_Relationship.Text.Trim
                .Item("Add1") = txtNAdd1.Text.Trim
                .Item("Add2") = txtNAdd2.Text.Trim
                .Item("Add3") = txtNAdd3.Text.Trim
                .Item("Add4") = txtNAdd4.Text.Trim
                .Item("Town") = txtNTown.Text.Trim
                .Item("State") = txtNState.Text.Trim
                .Item("Poscode") = txtNPoscode.Text.Trim()
                .Item("Share") = Val(txtNominee_SharePercentage.Text.Trim)
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With

            da_Proposer_Nominee.Update(ds_Proposer_Nominee, "dt_Proposer_Nomination")
            MsgBox("Update done.")


            Me.Reset_Nominee_Tab_Value()


            Me.Lock_Nomination_Tab(True)
            Me.btnNominee_Add.Visible = True
            Me.btnNominee_Update.Enabled = False
            Me.btnNominee_Update.Visible = False
            Me.btnNominee_CancelUpdate.Enabled = False
            Me.btnNominee_CancelUpdate.Visible = False


            Me.Populate_dgvNominees()
        End If
    End Sub
    Private Sub btnNominee_CancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNominee_CancelUpdate.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to cancel the update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel update for Nominee's details")
        Select Case Result
            Case 6

                Me.Reset_Nominee_Tab_Value()


                Me.Lock_Nomination_Tab(True)
                Me.btnNominee_Add.Visible = True
                Me.btnNominee_Update.Enabled = False
                Me.btnNominee_Update.Visible = False
                Me.btnNominee_CancelUpdate.Enabled = False
                Me.btnNominee_CancelUpdate.Visible = False
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub cmsNominee_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsNominee_Add.Click

        Me.Reset_Nominee_Tab_Value()


        Me.Lock_Nomination_Tab(False)
        Me.btnNominee_Add.Enabled = True
        Me.btnNominee_Add.Visible = True
        Me.btnNominee_Update.Enabled = False
        Me.btnNominee_Update.Visible = False
        Me.btnNominee_CancelUpdate.Enabled = False
        Me.btnNominee_CancelUpdate.Visible = False
    End Sub
    Private Sub cmsNominee_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsNominee_Delete.Click
        If Me.lblFIND.Text = "FIND" Then
            If Me.dgvNominees.SelectedRows.Count = 1 Then
                Dim Result As Integer
                Result = MsgBox("Do you want to delete this Nominee's record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Nominee's details")
                Select Case Result
                    Case 6
                        Me.dgvNominees.Rows.RemoveAt(Me.dgvNominees.CurrentRow.Index)
                    Case 7
                        Exit Sub
                End Select
            Else
                MsgBox("Please do select the Nominee which you would like to delete.")
            End If
        Else
            If Me.dgvNominees.SelectedRows.Count = 1 Then
                Dim Result As Integer
                Result = MsgBox("Do you want to delete this Nominee's record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Nominee's details")
                Select Case Result
                    Case 6

                        Dim cmdSelect_Proposer_Nominee As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        cmdSelect_Proposer_Nominee.CommandType = CommandType.Text
                        cmdSelect_Proposer_Nominee.CommandText = "SELECT * FROM dt_Proposer_Nomination " & _
                                                                 "WHERE ID = '" & Me.dgvNominees.SelectedRows(0).Cells(13).Value.ToString.Trim & "'"

                        Dim da_Proposer_Nominee As New SqlDataAdapter(cmdSelect_Proposer_Nominee)

                        Dim cmdUpdate_Proposer_Nominee As SqlCommandBuilder
                        cmdUpdate_Proposer_Nominee = New SqlCommandBuilder(da_Proposer_Nominee)


                        Dim ds_Proposer_Nominee As New DataSet


                        da_Proposer_Nominee.Fill(ds_Proposer_Nominee, "dt_Proposer_Nomination")

                        If ds_Proposer_Nominee.Tables("dt_Proposer_Nomination").Rows.Count = 1 Then
                            ds_Proposer_Nominee.Tables("dt_Proposer_Nomination").Rows(0).Delete()

                            da_Proposer_Nominee.Update(ds_Proposer_Nominee, "dt_Proposer_Nomination")
                            MsgBox("Record deleted.")


                            Me.Populate_dgvNominees()
                        Else
                            MsgBox("More than 1 records found for this nominee, please contact the system vendor.")
                        End If
                    Case 7
                        Exit Sub
                End Select
            Else
                MsgBox("Please do select the Nominee which you would like to delete.")
            End If
        End If
    End Sub
#End Region
#End Region
#Region "Data Bind"
    Private Sub BINDDEPDETAILS(ByVal REFTYPE As String, ByVal REFID As String)
        Dim dtDep, dtNominee As New DataTable
        dtDep = _objBusi.getDetails_I(REFTYPE, REFID, "", "", "", "", "", "", "", "", "DEP", Conn)
        If dtDep.Rows.Count > 0 Then
            For Each dr As DataRow In dtDep.Rows
                With Me.dgvDependents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = dr("Title").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(1).Value = dr("Full_Name").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(2).Value = dr("Birth_Date").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(3).Value = Math.Floor(DateDiff(DateInterval.Day, dr("Birth_Date"), Now()) / 365.25)
                    .Rows(.Rows.Count - 1).Cells(4).Value = dr("IC_New").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(5).Value = dr("IC_Old").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(6).Value = dr("ArmForce_ID").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(7).Value = dr("Race").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(8).Value = dr("Marital_Status").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(9).Value = dr("Relationship").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(10).Value = dr("Sex").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(11).Value = dr("Height").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(12).Value = dr("Weight").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(13).Value = dr("Occupation").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(14).Value = dr("Department").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(16).Value = iKIO
                    iKIO += 1
                End With

                With Me.dgvNominees
                    Dim iCount As Integer
                    Dim Share As Decimal
                    iCount = dtDep.Rows.Count
                    Share = 100 / iCount

                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = dr("Title").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(1).Value = dr("Full_Name").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(2).Value = dr("Birth_Date")
                    .Rows(.Rows.Count - 1).Cells(3).Value = dr("IC_New").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(4).Value = dr("Relationship").ToString.Trim()
                    .Rows(.Rows.Count - 1).Cells(5).Value = Me.txtProposer_AddressL1.Text
                    .Rows(.Rows.Count - 1).Cells(6).Value = Me.txtProposer_AddressL2.Text
                    .Rows(.Rows.Count - 1).Cells(7).Value = Me.txtProposerAdd3.Text
                    .Rows(.Rows.Count - 1).Cells(8).Value = Me.txtProposerAdd4.Text
                    .Rows(.Rows.Count - 1).Cells(9).Value = Me.txtProposer_City.Text
                    .Rows(.Rows.Count - 1).Cells(10).Value = Me.txtProposer_State.Text
                    .Rows(.Rows.Count - 1).Cells(11).Value = Me.txtProposer_Postcode.Text
                    .Rows(.Rows.Count - 1).Cells(12).Value = Share
                    .Rows(.Rows.Count - 1).Cells(12).ReadOnly = False
                End With
            Next

            Me.lblFIND.Text = "FIND"
            Me.dgvDependents.MultiSelect = False
            Me.dgvDependents.ContextMenuStrip = Me.cmsDependent
            Me.cmsDependent_Delete.Visible = True
            Me.cmsDependent_Delete.Enabled = True
            Me.cmsDependent_Edit.Enabled = False
            Me.cmsDependent_Add.Enabled = False
            Me.Reset_Enrolled_Dependents_Tab_Value()

            Me.dgvNominees.MultiSelect = False
            Me.dgvNominees.ContextMenuStrip = Me.cmsNominee
            Me.cmsNominee_Delete.Visible = True
            Me.cmsNominee_Delete.Enabled = True
            Me.cmsNominee_Edit.Enabled = False
            Me.cmsNominee_Add.Enabled = False
            Me.Reset_Nominee_Tab_Value()
        End If
    End Sub
    Private Sub GetDetails(ByVal ID As String)
        Dim scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scGet.CommandType = CommandType.Text
        scGet.CommandText = "SELECT * FROM tb_product_code a " & _
                            " inner join tb_deduction_code c on a.product_code=c.product_code " & _
                            " WHERE a.Product_Code='" & ID & "'"
        Dim sda As New SqlDataAdapter(scGet)
        Dim ds As New DataSet
        sda.Fill(ds, "tb_product_code")
        If Not Me.lblE32.Text.Trim() = "D1E32" Then
            If Not lblVerficationCheck.Text = "VPRINT" Then
                Dim dtVProduct As DataTable
                dtVProduct = _objBusi.getDetails("MEMBERCHECK", Me.txtProposer_NRIC.Text.Trim(), ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "PRODUCTV", Conn)
                If dtVProduct.Rows.Count > 0 Then
                    MsgBox("This Proposer have another plan under processes, Please check it!")
                    Me.txtProposer_Plan_Code.Text = ""
                    Exit Sub
                End If
            End If
        End If
        Dim dtAge As New DataTable
        dtAge = _objBusi.getDetails("MEMBERCHECK", Me.txtProposer_NRIC.Text.Trim(), "", "", "", "PRODUCTAGE", Conn)

        Dim Age1 As Integer
        Age1 = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
        Dim s1 As String
        s1 = Age1
        If Not IsDBNull(ds.Tables(0).Rows(0)("Age_Limit")) Then
            If Not Age1 < ds.Tables(0).Rows(0)("Age_Limit") Then
                If Not MsgBox("Proposer age excced the Product Age Limit!canot proceed the further action! you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                    Me.lblRREASONPCODE.Text = Me.txtProposer_Plan_Code.Text.Trim()
                    Me.lblReject_Reason.Text = "Proposer age excced!" & Me.txtProposer_Plan_Code.Text.Trim()
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Premium.Text = "0"
                    Me.rdiProceed2RejectLetter.Checked = True
                    Me.rdiProceed2AcknowledgementLetter.Enabled = False
                    Me.rdiProceed2DefermentLetter.Enabled = False
                    Me.rdiProceed2UnderwritingLetter.Enabled = False
                    Me.rdioYearlyLetter.Enabled = False
                    Me.chkDataEntry_CheckList_Proposer_Details.Enabled = False
                    Me.chkDataEntry_CheckList_Dependent_Details.Enabled = False
                    Me.chkDataEntry_CheckList_InsuranceProposed_Details.Enabled = False
                    Me.chkDataEntry_CheckList_BiroAngkasa_Details.Enabled = False
                    Me.chkDataEntry_CheckList_Nomination.Enabled = False
                    Me.chkProceed2Verification.Enabled = False
                    Me.chkDocumentation_CheckList_Proposer_Form.Enabled = False
                    Me.chkDocumentation_CheckList_IC.Enabled = False
                    Me.chkDocumentation_CheckList_PG.Enabled = False
                    Me.rbPG6BTJ.Enabled = False
                    Me.rbPG6BJ.Enabled = False
                    Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnCancel.Enabled = False
                    Me.txtProposer_Plan_Commission_AgentCode.Text = "0"
                    Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = "0"
                    Me.txtProposer_Plan_Payment_Method.Text = "-"
                    With Me.dgvAgents
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                        .Rows(.Rows.Count - 1).Cells(2).Value = 0
                    End With
                    Me.lblProposer_Status.Text = "1R"
                    Me.lblRejectReason.Text = "PROPOSEROVERAGED"
                    Me.Save_Proposer_ApplicationForm_New()
                    Me.GrpBox_ActionAfter_Verification.Visible = True
                    Me.chkDocumentation_CheckList_Payslip.Enabled = False
                    Dim tp1, tp2, tp3, tp6, tp7 As Control
                    Me.TabControl1.DeselectTab(1)
                    tp1 = Me.TabPage1
                    tp1.Enabled = False
                    tp1.Visible = False
                    tp2 = Me.TabPage2
                    tp2.Enabled = False
                    tp3 = Me.TabPage3
                    tp3.Enabled = False
                    tp6 = Me.TabPage6
                    tp6.Enabled = False
                    tp7 = Me.TabPage7
                    tp7.Enabled = False
                    tp7.Dispose()
                    Me.TabControl1.SelectedTab = Me.TabPage5
                    Me.TabControl1.TabStop = True
                    Me.lblProposer_ID.Text = sProposerID
                    Exit Sub
                Else
                    Me.txtProposer_Plan_Code.Text = ""
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Premium.Text = ""
                    Exit Sub
                End If
            End If
        End If
       
        Dim NOOFTIMES As Integer = 0
        Dim dtAllow As New DataTable
        dtAllow = _objBusi.getDetails("MEMBERCHECK", ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "", "PRODUCTALLOW", Conn)
        If dtAllow.Rows.Count > 0 Then
            If Not IsDBNull(dtAllow.Rows(0)("NO_OF_TIMES")) Then
                NOOFTIMES = dtAllow.Rows(0)("NO_OF_TIMES")
            Else
                NOOFTIMES = 1
            End If
        Else
            NOOFTIMES = 1
        End If
        Dim iRowCount As Integer = 0
        Dim dtChk As New DataTable
        dtChk = _objBusi.getDetails("MEMBERCHECK", Me.txtProposer_NRIC.Text.Trim(), ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "MEMBER", Conn)
        iRowCount = dtChk.Rows.Count
        If iRowCount >= NOOFTIMES Then
            If dtChk.Rows.Count > 0 Then
                If Not MsgBox("This proposer already exists with this product canot proceed the further action! you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                    Me.lblRREASONPCODE.Text = Me.txtProposer_Plan_Code.Text.Trim()
                    Me.lblReject_Reason.Text = "Proposer exists with this product!" & Me.txtProposer_Plan_Code.Text.Trim()
                    Me.sStartDate = dtChk.Rows(0)("Effective_Date").ToString().Trim()
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Premium.Text = "0"
                    Me.rdiProceed2RejectLetter.Checked = True
                    Me.rdiProceed2AcknowledgementLetter.Enabled = False
                    Me.rdiProceed2DefermentLetter.Enabled = False
                    Me.rdiProceed2UnderwritingLetter.Enabled = False
                    Me.rdioYearlyLetter.Enabled = False
                    Me.chkDataEntry_CheckList_Proposer_Details.Enabled = False
                    Me.chkDataEntry_CheckList_Dependent_Details.Enabled = False
                    Me.chkDataEntry_CheckList_InsuranceProposed_Details.Enabled = False
                    Me.chkDataEntry_CheckList_BiroAngkasa_Details.Enabled = False
                    Me.chkDataEntry_CheckList_Nomination.Enabled = False
                    Me.chkProceed2Verification.Enabled = False
                    Me.chkDocumentation_CheckList_Proposer_Form.Enabled = False
                    Me.chkDocumentation_CheckList_IC.Enabled = False
                    Me.chkDocumentation_CheckList_PG.Enabled = False
                    Me.rbPG6BTJ.Enabled = False
                    Me.rbPG6BJ.Enabled = False
                    Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnCancel.Enabled = False
                    Me.txtProposer_Plan_Commission_AgentCode.Text = "0"
                    Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = "0"
                    With Me.dgvAgents
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                        .Rows(.Rows.Count - 1).Cells(2).Value = 0
                    End With
                    Me.lblProposer_Status.Text = "1R"
                    Me.Save_Proposer_ApplicationForm_New()
                    Me.txtProposer_Plan_Code.Text = "PWRONGCODE"
                    Me.GrpBox_ActionAfter_Verification.Visible = True
                    Me.chkDocumentation_CheckList_Payslip.Enabled = False
                    Dim tp1, tp2, tp3, tp4, tp6, tp7, tp5 As Control
                    Me.TabControl1.DeselectTab(1)
                    tp1 = Me.TabPage1
                    tp1.Enabled = False
                    tp1.Visible = False
                    tp2 = Me.TabPage2
                    tp2.Enabled = False
                    tp3 = Me.TabPage3
                    tp3.Enabled = False
                    tp6 = Me.TabPage6
                    tp6.Enabled = False
                    tp7 = Me.TabPage7
                    tp7.Enabled = False
                    tp7.Dispose()
                    Me.TabControl1.SelectedTab = Me.TabPage5
                    Me.TabControl1.TabStop = True
                    Me.lblRejectReason.Text = "PROPOSEREXISTS"
                    Me.lblProposer_ID.Text = sProposerID
                    Exit Sub
                Else
                    Me.txtProposer_Plan_Code.Text = ""
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Premium.Text = ""
                    Exit Sub
                End If
            End If
        End If

        Dim dtChk1 As New DataTable
        dtChk1 = _objBusi.getDetails("MEMBERCHECK", Me.txtProposer_NRIC.Text.Trim().Replace("C", ""), ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "MEMBERINDEP", Conn)
        If dtChk1.Rows.Count > 0 Then
            If Not MsgBox("Proposer existed as a Dependent with this product! Please do re select another product!!or  you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                Me.lblRREASONPCODE.Text = Me.txtProposer_Plan_Code.Text.Trim()
                Me.lblReject_Reason.Text = "Spouse have the policy with this product!" & Me.txtProposer_Plan_Code.Text.Trim()
                Me.txtProposer_L2_Plan_Code.Text = ""
                Me.sStartDate = dtChk1.Rows(0)("Effective_Date").ToString().Trim() & "|" & dtChk1.Rows(0)("MEMNAME").ToString().Trim()
                Me.txtProposer_Plan_Premium.Text = "0"
                Me.rdiProceed2RejectLetter.Checked = True
                Me.rdiProceed2AcknowledgementLetter.Enabled = False
                Me.rdiProceed2DefermentLetter.Enabled = False
                Me.rdiProceed2UnderwritingLetter.Enabled = False
                Me.rdioYearlyLetter.Enabled = False
                Me.chkDataEntry_CheckList_Proposer_Details.Enabled = False
                Me.chkDataEntry_CheckList_Dependent_Details.Enabled = False
                Me.chkDataEntry_CheckList_InsuranceProposed_Details.Enabled = False
                Me.chkDataEntry_CheckList_BiroAngkasa_Details.Enabled = False
                Me.chkDataEntry_CheckList_Nomination.Enabled = False
                Me.chkProceed2Verification.Enabled = False
                Me.chkDocumentation_CheckList_Proposer_Form.Enabled = False
                Me.chkDocumentation_CheckList_IC.Enabled = False
                Me.chkDocumentation_CheckList_PG.Enabled = False
                Me.rbPG6BTJ.Enabled = False
                Me.rbPG6BJ.Enabled = False
                Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.txtProposer_Plan_Commission_AgentCode.Text = "0"
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = "0"
                With Me.dgvAgents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(1).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                    .Rows(.Rows.Count - 1).Cells(2).Value = 0
                End With
                Me.lblRejectReason.Text = "PROPOSERSPOUSEEXISTS"
                Me.lblProposer_Status.Text = "1R"
                Me.Save_Proposer_ApplicationForm_New()
                Me.lblProposer_ID.Text = sProposerID
                Me.txtProposer_Plan_Code.Text = "PWRONGCODE"
                Me.GrpBox_ActionAfter_Verification.Visible = True
                Me.chkDocumentation_CheckList_Payslip.Enabled = False
                Dim tp1, tp2, tp3, tp4, tp6, tp7, tp5 As Control
                Me.TabControl1.DeselectTab(1)
                tp1 = Me.TabPage1
                tp1.Enabled = False
                tp1.Visible = False
                tp2 = Me.TabPage2
                tp2.Enabled = False
                tp3 = Me.TabPage3
                tp3.Enabled = False
                tp6 = Me.TabPage6
                tp6.Enabled = False
                tp7 = Me.TabPage7
                tp7.Enabled = False
                tp7.Dispose()
                Me.TabControl1.SelectedTab = Me.TabPage5
                Me.TabControl1.TabStop = True
                Exit Sub
            Else
                Me.txtProposer_Plan_Code.Text = ""
                Me.txtProposer_L2_Plan_Code.Text = ""
                Me.txtProposer_Plan_Premium.Text = ""
                Exit Sub
            End If
        End If

        Dim iCount As Integer = 0
        If Me.dgvDependents.Rows.Count > 0 Then
            Do While iCount < Me.dgvDependents.Rows.Count
                If Me.dgvDependents.Rows(iCount).Cells(9).Value.ToString.Trim().ToUpper() = "SPOUSE" Then
                    Dim dtChk2 As New DataTable
                    dtChk2 = _objBusi.getDetails("MEMBERCHECK", "C" & Me.dgvDependents.Rows(iCount).Cells(4).Value.ToString.Trim(), ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "MEMBER", Conn)
                    If dtChk2.Rows.Count > 0 Then
                        If Not MsgBox("Spouse have the policy with this product! Remove the spouse Name from Dependents List to proceed the further action!or  you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                            Me.lblRREASONPCODE.Text = Me.txtProposer_Plan_Code.Text.Trim()
                            Me.lblReject_Reason.Text = "Spouse have the policy with this product!" & Me.txtProposer_Plan_Code.Text.Trim()
                            Me.txtProposer_L2_Plan_Code.Text = ""
                            Me.sStartDate = dtChk2.Rows(0)("Effective_Date").ToString().Trim() & "|" & dtChk2.Rows(0)("FULL_NAME").ToString().Trim()
                            Me.txtProposer_Plan_Premium.Text = "0"
                            Me.rdiProceed2RejectLetter.Checked = True
                            Me.rdiProceed2AcknowledgementLetter.Enabled = False
                            Me.rdiProceed2DefermentLetter.Enabled = False
                            Me.rdiProceed2UnderwritingLetter.Enabled = False
                            Me.rdioYearlyLetter.Enabled = False
                            Me.chkDataEntry_CheckList_Proposer_Details.Enabled = False
                            Me.chkDataEntry_CheckList_Dependent_Details.Enabled = False
                            Me.chkDataEntry_CheckList_InsuranceProposed_Details.Enabled = False
                            Me.chkDataEntry_CheckList_BiroAngkasa_Details.Enabled = False
                            Me.chkDataEntry_CheckList_Nomination.Enabled = False
                            Me.chkProceed2Verification.Enabled = False
                            Me.chkDocumentation_CheckList_Proposer_Form.Enabled = False
                            Me.chkDocumentation_CheckList_IC.Enabled = False
                            Me.chkDocumentation_CheckList_PG.Enabled = False
                            Me.rbPG6BTJ.Enabled = False
                            Me.rbPG6BJ.Enabled = False
                            Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                            Me.btnSave.Enabled = False
                            Me.btnCancel.Enabled = False
                            Me.txtProposer_Plan_Commission_AgentCode.Text = "0"
                            Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = "0"
                            With Me.dgvAgents
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                                .Rows(.Rows.Count - 1).Cells(1).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                                .Rows(.Rows.Count - 1).Cells(2).Value = 0
                            End With
                            Me.Save_Proposer_ApplicationForm_New()
                            Me.txtProposer_Plan_Code.Text = "PWRONGCODE"
                            Me.GrpBox_ActionAfter_Verification.Visible = True
                            Me.chkDocumentation_CheckList_Payslip.Enabled = False
                            Dim tp1, tp2, tp3, tp4, tp6, tp7, tp5 As Control
                            Me.TabControl1.DeselectTab(1)
                            tp1 = Me.TabPage1
                            tp1.Enabled = False
                            tp1.Visible = False
                            tp2 = Me.TabPage2
                            tp2.Enabled = False
                            tp3 = Me.TabPage3
                            tp3.Enabled = False
                            tp6 = Me.TabPage6
                            tp6.Enabled = False
                            tp7 = Me.TabPage7
                            tp7.Enabled = False
                            tp7.Dispose()
                            Me.TabControl1.SelectedTab = Me.TabPage5
                            Me.TabControl1.TabStop = True
                            Me.lblRejectReason.Text = "PROPOSERSPOUSEEXISTS"
                            Me.lblProposer_Status.Text = "1R"
                            Me.lblProposer_ID.Text = sProposerID
                            Exit Sub
                        Else
                            Me.txtProposer_Plan_Code.Text = ""
                            Me.txtProposer_L2_Plan_Code.Text = ""
                            Me.txtProposer_Plan_Premium.Text = ""
                            Exit Sub
                        End If
                        Exit Sub
                    End If
                End If
                iCount += 1
            Loop
        End If

        Me.txtProposer_Plan_Code.Text = ds.Tables(0).Rows(0)("Product_Code").ToString.Trim()
        Me.txtProposer_L2_Plan_Code.Text = ds.Tables(0).Rows(0)("Plan_Type").ToString.Trim()
        Me.txtProposer_Plan_Payment_Method.Text = ds.Tables(0).Rows(0)("Received_From").ToString.Trim()
        Dim dtMemexists As New DataTable
        dtMemexists = _objBusi.getDetails("MEMBERCHECK", Me.txtProposer_NRIC.Text.ToString.Trim(), "", "", "", "MEMBEREXISTS", Conn)
        If dtMemexists.Rows.Count > 0 Then
        Else
            If vDepSAge() = False Then
                Me.txtBorang1_79_SN.Text = "0"
                TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
                Me.txtProposer_Plan_Code.Text = ""
                Me.txtProposer_L2_Plan_Code.Text = ""
                Me.txtProposer_Plan_Payment_Method.Text = ""
                Me.txtProposer_Plan_Premium.Text = ""
                Me.txtBorang1_79_SN.Text = ""
                Exit Sub
            End If
        End If
        Dim sP1 As String
        sP1 = ds.Tables(0).Rows(0)("deduction_code").ToString.Trim.Substring(0, 1)
        If sP1 = "Y" Then
            Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True
            Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = False
            Me.rdiProposer_Plan_Payment_Frequency_Monthly.Enabled = False
        Else
            Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = True
            Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = False
            Me.rdiProposer_Plan_Payment_Frequency_Monthly.Enabled = True
        End If
        If ds.Tables(0).Rows(0)("Plan_Type").ToString.Trim() = "EMPLOYEE AND FAMILY ONLY" Then
            If Me.dgvDependents.RowCount < 1 Then
                If Not MsgBox("Proposed plan is family plan,please do key in dependents details or select another product! or you want continue..!", vbYesNo, "Medicare") = vbYes Then
                    Me.txtProposer_Plan_Code.Text = ""
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Payment_Method.Text = ""
                    Exit Sub
                End If
            End If
        ElseIf ds.Tables(0).Rows(0)("Plan_Type").ToString.Trim() = "EMPLOYEE ONLY" Then
            If Me.dgvDependents.RowCount > 0 Then
                If Not MsgBox("Proposed plan is Individual plan,please remove dependents details or select another product! or you want continue..!", vbYesNo, "Medicare") = vbYes Then
                    Me.txtProposer_Plan_Code.Text = ""
                    Me.txtProposer_L2_Plan_Code.Text = ""
                    Me.txtProposer_Plan_Payment_Method.Text = ""
                    Exit Sub
                End If
            End If
        End If
        Dim scSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scSelect.CommandType = CommandType.Text
        scSelect.CommandText = "SELECT * FROM tb_Premium_Table WHERE Premium_Code='" & ds.Tables(0).Rows(0)("Premium_Code").ToString.Trim() & "' and Status='Active'"
        Dim sdaP As New SqlDataAdapter(scSelect)
        Dim dsP As New DataSet
        sdaP.Fill(dsP, "tb_Premium_Table")

        For Each dr As DataRow In dsP.Tables(0).Rows
            Dim Age, sAge, eAge As Integer
            Age = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
            Dim Age_Limit As String()
            Dim a As String
            a = dr("Age_Limit")
            Age_Limit = a.Split("-")
            sAge = Age_Limit(0)
            eAge = Age_Limit(1)
            If Age >= sAge And Age <= eAge Then
                Me.txtProposer_Plan_Premium.Text = dr("Premium_Amt")
                Exit For
            Else
                Me.txtProposer_Plan_Premium.Text = ""
            End If
        Next
        If Me.txtProposer_Plan_Premium.Text = "" Then
            If Not MsgBox("Proposer age exceed/less canot proceed the further action! you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                Me.lblRREASONPCODE.Text = Me.txtProposer_Plan_Code.Text.Trim()
                Me.lblReject_Reason.Text = "Proposer age excced!" & Me.txtProposer_Plan_Code.Text.Trim()
                Me.txtProposer_L2_Plan_Code.Text = ""
                Me.txtProposer_Plan_Premium.Text = "0"
                Me.rdiProceed2RejectLetter.Checked = True
                Me.rdiProceed2AcknowledgementLetter.Enabled = False
                Me.rdiProceed2DefermentLetter.Enabled = False
                Me.rdiProceed2UnderwritingLetter.Enabled = False
                Me.rdioYearlyLetter.Enabled = False
                Me.chkDataEntry_CheckList_Proposer_Details.Enabled = False
                Me.chkDataEntry_CheckList_Dependent_Details.Enabled = False
                Me.chkDataEntry_CheckList_InsuranceProposed_Details.Enabled = False
                Me.chkDataEntry_CheckList_BiroAngkasa_Details.Enabled = False
                Me.chkDataEntry_CheckList_Nomination.Enabled = False
                Me.chkProceed2Verification.Enabled = False
                Me.chkDocumentation_CheckList_Proposer_Form.Enabled = False
                Me.chkDocumentation_CheckList_IC.Enabled = False
                Me.chkDocumentation_CheckList_PG.Enabled = False
                Me.rbPG6BTJ.Enabled = False
                Me.rbPG6BJ.Enabled = False
                Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.txtProposer_Plan_Commission_AgentCode.Text = "0"
                Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = "0"
                With Me.dgvAgents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = Me.txtProposer_Plan_Commission_AgentCode.Text.Trim
                    .Rows(.Rows.Count - 1).Cells(1).Value = Val(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
                    .Rows(.Rows.Count - 1).Cells(2).Value = 0
                End With
                Me.lblProposer_Status.Text = "1R"
                Me.lblRejectReason.Text = "PROPOSEROVERAGED"
                Me.Save_Proposer_ApplicationForm_New()

                Me.GrpBox_ActionAfter_Verification.Visible = True
                Me.chkDocumentation_CheckList_Payslip.Enabled = False
                Dim tp1, tp2, tp3, tp4, tp6, tp7, tp5 As Control
                Me.TabControl1.DeselectTab(1)
                tp1 = Me.TabPage1
                tp1.Enabled = False
                tp1.Visible = False
                tp2 = Me.TabPage2
                tp2.Enabled = False
                tp3 = Me.TabPage3
                tp3.Enabled = False
                
                tp6 = Me.TabPage6
                tp6.Enabled = False
                tp7 = Me.TabPage7
                tp7.Enabled = False
                tp7.Dispose()
                sReject = "REJECT"
                Me.TabControl1.SelectedTab = Me.TabPage5
                Me.TabControl1.TabStop = True
                Me.lblProposer_ID.Text = sProposerID
                Exit Sub
                Exit Sub
            Else
                Me.txtProposer_Plan_Code.Text = ""
                Me.txtProposer_L2_Plan_Code.Text = ""
                Exit Sub
            End If
        End If
        Dim sP As String
        sP = ds.Tables(0).Rows(0)("Product_Code").ToString.Substring(0, 10).Trim()


        Select Case sP
            Case "CUEPACS PA"

                Dim PATotalAmount As Double
                Dim TotalAmount As String
                Dim Age As String
                Dim dep_count As Integer = 0
                Dim Age_Limit As String()
                Dim a As String
                Age = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
                For Each dr As DataRow In dsP.Tables(0).Rows
                    a = dr("Age_Limit")
                    Age_Limit = a.Split("-")
                    Dim PType As String
                    PType = dr("Participant_Type").ToString.Trim()
                    If PType = "MEMBER" Then
                        If Age >= Age_Limit(0) And Age <= Age_Limit(1) Then
                            PATotalAmount += dr("Premium_Amt")
                            Me.txtProposer_Plan_Premium.Text = PATotalAmount
                            Exit For
                        End If
                    End If
                Next
                If Me.dgvDependents.RowCount > 0 Then
                    Do While dep_count < Me.dgvDependents.Rows.Count
                        Dim DepAge, Relation, depParam As String
                        DepAge = Math.Floor(DateDiff(DateInterval.Day, Me.dgvDependents.Rows(dep_count).Cells(2).Value, Now()) / 365.25)
                        Dim sLen As String
                        sLen = DepAge.Length()
                        If sLen = "1" Then
                            DepAge = "0" & DepAge
                        End If
                        Relation = Me.dgvDependents.Rows(dep_count).Cells(9).Value.ToString().Trim()
                        If Relation = "Children" Then
                            depParam = "CHILD"
                        Else
                            depParam = "SPOUSE"
                        End If
                        For Each dr As DataRow In dsP.Tables(0).Select("Participant_Type = '" & depParam & "'")
                            a = dr("Age_Limit")
                            Age_Limit = a.Split("-")
                            If DepAge >= Age_Limit(0) And DepAge <= Age_Limit(1) Then
                                PATotalAmount += dr("Premium_Amt")
                                Exit For
                            End If
                        Next
                        TotalAmount = PATotalAmount
                        dep_count += 1
                    Loop
                    Me.txtProposer_Plan_Premium.Text = PATotalAmount
                End If

            Case Else

                For Each dr As DataRow In dsP.Tables(0).Rows

                    Dim Age As Integer
                    Dim dep_count As Integer = 0
                    Dim Relations As String = ""
                    If Me.dgvDependents.RowCount > 0 Then
                        Age = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
                        Do While dep_count < Me.dgvDependents.Rows.Count
                            Dim DepAge As String
                            Relations = Me.dgvDependents.Rows(dep_count).Cells(9).Value.ToString.Trim()
                            DepAge = Math.Floor(DateDiff(DateInterval.Day, Me.dgvDependents.Rows(dep_count).Cells(2).Value, Now()) / 365.25)
                            If DepAge > Age Then

                                Age = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
                                Exit Do
                            End If
                            dep_count += 1
                        Loop
                    Else
                        Age = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
                    End If

                    If Not Relations = "Children" Then
                        Dim Age_Limit As String()
                        Dim a As String
                        a = dr("Age_Limit")
                        Age_Limit = a.Split("-")
                        If Age >= Age_Limit(0) And Age <= Age_Limit(1) Then
                            Me.txtProposer_Plan_Premium.Text = dr("Premium_Amt")
                            Exit For
                        End If
                    End If
                Next

        End Select
        Me.txtProposer_Plan_Premium.Enabled = False

    End Sub
    Private Sub Populate_Form4Verification()
        Try
            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)
            Dim cmdSelect_Proposer_Angkasa_Deduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Angkasa_Deduction.CommandType = CommandType.Text
            cmdSelect_Proposer_Angkasa_Deduction.CommandText = "SELECT * FROM dt_Proposer_Angkasa_Deduction " & _
                                                               "WHERE Proposer_ID = '" & Me.lblProposer_ID.Text.Trim & "'"
            Dim da_Proposer_Angkasa_Deduction As New SqlDataAdapter(cmdSelect_Proposer_Angkasa_Deduction)

            Dim ds_Proposer4Verify As New DataSet
            da_Proposer.Fill(ds_Proposer4Verify, "dt_Proposer")
            da_Proposer_Angkasa_Deduction.Fill(ds_Proposer4Verify, "dt_Proposer_Angkasa_Deduction")

            With ds_Proposer4Verify.Tables("dt_Proposer").Rows(0)
                If Me.lblForm_Flag.Text = "V" Then
                    If .Item("Level2_Plan_Code").ToString.Trim() = "EMPLOYEE AND FAMILY ONLY" Or .Item("Level2_Plan_Code").ToString.Trim() = "FAMILY" Then
                        Dim dt As New DataTable
                        dt = _objBusi.getDetails("PROPOSER", .Item("ID").ToString.Trim(), "", "", "", "E32", Conn)
                        If dt.Rows.Count > 0 Then
                            Me.lblE32.Text = "D1E32"
                            MsgBox("This proposer have one dependent with Exclusion Clause E32, Please change the plan code and delete dependent to processed further!")
                        End If
                    End If
                End If
                Me.txtProposer_Title.Text = .Item("Title").ToString.Trim
                Me.txtProposer_Name.Text = .Item("Full_Name").ToString.Trim
                Me.dtpProposer_DOB.Value = .Item("Birth_Date")
                Me.txtProposer_Age.Text = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
                Me.txtProposer_NRIC.Text = .Item("IC_New").ToString.Trim
                Me.txtProposer_OldIC.Text = .Item("IC_Old").ToString.Trim
                Me.txtProposer_ArmForceID.Text = .Item("ArmForce_ID").ToString.Trim

                Select Case .Item("Race")
                    Case "M"
                        Me.rdiProposer_Race_Malay.Checked = True
                    Case "C"
                        Me.rdiProposer_Race_Chinese.Checked = True
                    Case "I"
                        Me.rdiProposer_Race_Indian.Checked = True
                    Case "O"
                        Me.rdiProposer_Race_Others.Checked = True
                End Select

                Me.txtAngkasa_FileNo.Text = .Item("Angkasa_FileNo").ToString.Trim

                Select Case .Item("Marital_Status")
                    Case "S"
                        Me.rdiProposer_MaritalStatus_Single.Checked = True
                    Case "M"
                        Me.rdiProposer_MaritalStatus_Married.Checked = True
                    Case "W"
                        Me.rdiProposer_MaritalStatus_Widowed.Checked = True
                    Case "D"
                        Me.rdiProposer_MaritalStatus_Divorced.Checked = True
                End Select

                If .Item("Sex") = True Then
                    Me.rdiProposer_Sex_Male.Checked = True
                Else
                    Me.rdiProposer_Sex_Female.Checked = True
                End If

                Me.dtpProposal_Received_Date.Value = .Item("Proposal_Received_Date")
                If Not IsDBNull(.Item("Proposal_Signed_Date")) Then
                    Me.dtpDateofSigned.Value = .Item("Proposal_Signed_Date")
                End If
                Me.txtProposer_AddressL1.Text = .Item("Postal_Address_L1").ToString.Trim
                Me.txtProposer_AddressL2.Text = .Item("Postal_Address_L2").ToString.Trim
                Me.txtProposerAdd3.Text = .Item("Add3").ToString.Trim
                Me.txtProposerAdd4.Text = .Item("Add4").ToString.Trim
                Me.txtProposer_City.Text = .Item("Town").ToString.Trim
                Me.txtProposer_Postcode.Text = .Item("Postcode").ToString.Trim
                Me.txtProposer_State.Text = .Item("State").ToString.Trim
                If Not IsDBNull(.Item("Bank_Name")) Then
                    Me.cbBankName.Text = .Item("Bank_Name").ToString.Trim
                End If
                If Not IsDBNull(.Item("Bank_Ac")) Then
                    Me.txtBankAc.Text = .Item("Bank_Ac").ToString.Trim
                End If
                Me.txtProposer_Phone_Hse.Text = .Item("Phone_Hse").ToString.Trim
                Me.txtProposer_Mobile.Text = .Item("Phone_Mobile").ToString.Trim
                Me.txtProposer_Phone_Ofc.Text = .Item("Phone_Off").ToString.Trim
                Me.txtProposer_Email.Text = .Item("Email").ToString.Trim
                Me.txtProposer_Height.Text = .Item("Height").ToString.Trim
                Me.txtProposer_Weight.Text = .Item("Weight").ToString.Trim
                Me.txtProposer_Occupation.Text = .Item("Occupation").ToString.Trim
                Me.txtProposer_Department.Text = .Item("Department").ToString.Trim

                Me.txtProposer_Plan_Code.Text = .Item("Plan_Code").ToString.Trim
                Me.txtProposer_L2_Plan_Code.Text = .Item("Level2_Plan_Code").ToString.Trim
                Me.txtProposer_Plan_Premium.Text = .Item("Premium").ToString.Trim
                Me.chkProposer_Plan_SpecialPromo.Checked = .Item("Special_Promo")

                Select Case .Item("Payment_Frequency")
                    Case "Y"
                        Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True
                    Case "H"
                        Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.Checked = True
                    Case "Q"
                        Me.rdiProposer_Plan_Payment_Frequency_Quarterly.Checked = True
                    Case "M"
                        Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = True
                End Select

                Me.txtProposer_Plan_Payment_Method.Text = .Item("Payment_Method").ToString.Trim


                Select Case Me.txtProposer_Plan_Payment_Method.Text
                    Case "Credit Card"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = True
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                    Case "Cheque"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = True
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                    Case "Cash"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = True
                    Case Else
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                End Select


                Me.txtProposer_Plan_Payment_CreditCard_Batch_No.Text = .Item("Payment_Method_CreditCard_Batch_No").ToString.Trim
                Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.Text = .Item("Payment_Method_CreditCard_Appr_Code").ToString.Trim
                Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.Text = .Item("Payment_Method_CreditCard_Invoice_No").ToString.Trim
                Me.txtProposer_Plan_Payment_Cheque_No.Text = .Item("Payment_Method_Cheque_No").ToString.Trim
                Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Text = .Item("Payment_Method_Cheque_Receipt_No").ToString.Trim
                Me.txtProposer_Plan_Payment_Receipt_No.Text = .Item("Payment_Method_Cash_Receipt_No").ToString.Trim
                Me.txtProposer_Plan_Payment_Receipt_IssuedBy.Text = .Item("Payment_Method_Cash_Receipt_IssuedBy").ToString.Trim
                Me.txtBorang1_79_SN.Text = .Item("Payment_Method_BiroAngkasa_Borang1_79_SN").ToString.Trim


                Me.chkDataEntry_CheckList_Proposer_Details.Checked = .Item("DataEntry_Checklist_Proposer_Details")
                Me.chkDataEntry_CheckList_Dependent_Details.Checked = .Item("DataEntry_Checklist_Enrolled_Dependents")
                Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked = .Item("DataEntry_Checklist_Insurance_Proposed")
                Me.chkDataEntry_CheckList_BiroAngkasa_Details.Checked = .Item("DataEntry_Checklist_BiroAngkasa_Deduction")

                Me.chkDocumentation_CheckList_Proposer_Form.Checked = .Item("Document_Checklist_Application_Form")
                Me.chkDataEntry_CheckList_Nomination.Checked = .Item("DataEntry_Checklist_Nomination")

                If Not IsDBNull(.Item("Document_Checklist_Application_Form_Status")) Then
                    Select Case .Item("Document_Checklist_Application_Form_Status")
                        Case "Lengkap"
                            Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = True
                        Case "Tidak Lengkap"
                            Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = True
                            Me.flpBPTL.Visible = True
                            Me.flpBPTL.Enabled = True
                            If Not IsDBNull(.Item("DCAF_Status")) Then
                                Dim s As String
                                s = .Item("DCAF_Status")
                                Dim sMsg() As String
                                sMsg = s.Split("!")
                                For Each str As String In sMsg
                                    Select Case str.Trim()
                                        Case "-Bahagian A (Tarikh Lahir)"
                                            Me.cbTLBATarikh.Checked = True
                                        Case "-Bahagian A (No Telefon)"
                                            Me.cbTLBANoTelefon.Checked = True
                                        Case "-Bahagian B (No Kad Pengenalan Pasangan)"
                                            Me.cbTLBBNoKad.Checked = True
                                        Case "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)"
                                            Me.cbTLBBNoSijil.Checked = True
                                        Case "-Bahagian B (Surat Pengambilan Anak Angkat)"
                                            Me.cbTLBBSurat.Checked = True
                                        Case "-Bahagian B (Sertakan Sijil Kelahiran Anak)"
                                            Me.cbTLBBSertakan.Checked = True
                                        Case "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)"
                                            Me.cbTLBBPasangan.Checked = True
                                        Case "-Bahagian C (Soal Selidik)"
                                            Me.cbTLBCSOAL.Checked = True
                                        Case "-Bahagian D & E (Tandatangan Pemohon)"
                                            Me.cbTLBD.Checked = True
                                        Case "-Jenis Pilihan Pelan"
                                            Me.cbTLJenis.Checked = True
                                        Case "-Bahagian Penamaan"
                                            Me.cbTLBP.Checked = True
                                        Case "-Bahagian Pengisytiharan (Tandatangan Pemohon)"
                                            Me.chkBPTP.Checked = True
                                        Case "-Seksyen D (Tandatangan Saksi)"
                                            Me.chkSDTS.Checked = True
                                        Case "-Seksyen D (Tandatangan Pemilik)"
                                            Me.chkSDTP.Checked = True
                                    End Select
                                Next

                            End If
                        Case "Borang Lama"
                            Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = True
                        Case "Borang Salah"
                            Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = True
                    End Select
                End If
                Me.chkDocumentation_CheckList_IC.Checked = .Item("Document_Checklist_IC")
                If Not IsDBNull(.Item("Document_Checklist_Penyata")) Then
                    Me.chkDocumentation_CheckList_PG.Checked = .Item("Document_Checklist_Penyata")
                End If
                If Me.chkDocumentation_CheckList_PG.Checked = True Then
                    If Not IsDBNull(.Item("Document_Checklist_Penyata_Status")) Then
                        Select Case .Item("Document_Checklist_Penyata_Status")
                            Case "Tidak"
                                Me.rbPG6BTJ.Checked = True
                            Case "Ya"
                                Me.rbPG6BJ.Checked = True
                        End Select
                    End If
                End If

                Me.chkDocumentation_CheckList_Payslip.Checked = .Item("Document_Checklist_Payslip")

                If Me.chkDocumentation_CheckList_Payslip.Checked = True Then
                    Select Case .Item("Document_Checklist_Payslip_Status")
                        Case "Jelas"
                            Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = True
                        Case "Tidak Jelas"
                            Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = True
                    End Select
                End If

                Me.chkDocumentation_CheckList_Borang1_79.Checked = .Item("Document_Checklist_Borang1_79")
                If Me.chkDocumentation_CheckList_Borang1_79.Checked = True Then
                    Select Case .Item("Document_Checklist_Borang1_79_Status")
                        Case "Lengkap dengan Maklumat Majikan dan Cop Majikan"
                            Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = True
                        Case "Terdapat kesilapan mengisi Borang 1/79"
                            Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = True
                        Case "Penggunaan 'liquid paper' pada Borang 1/79"
                            Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True
                        Case "Muat Turun Borang 1/79"
                            Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = True
                        Case "Tidak Lengkap"
                            Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = True
                            Me.flpBTL.Visible = True
                            Me.flpBTL.Enabled = True
                            If Not IsDBNull(.Item("DCB179_Status")) Then
                                Dim s1 As String
                                s1 = .Item("DCB179_Status")
                                Dim sMsg1() As String
                                sMsg1 = s1.Split("!")
                                For Each str1 As String In sMsg1
                                    Select Case str1.Trim()
                                        Case "Tandatangan Pemohon"
                                            Me.cbTLTP.Checked = True
                                        Case "Cop Majikan"
                                            Me.cbTLCM.Checked = True
                                        Case "Tandatangan Majikan"
                                            Me.cbTLTM.Checked = True
                                    End Select
                                Next

                            End If

                    End Select
                End If

                If .Item("CIMB_UW_STATUS").ToString.Trim = "YES" Then
                    Me.rbUWCIMBYes.Checked = True
                    Me.rbUWCIMBNo.Checked = False
                Else
                    Me.rbUWCIMBYes.Checked = False
                    Me.rbUWCIMBNo.Checked = True
                End If

                Me.lblProposer_Status.Text = .Item("Status").ToString.Trim

                If Len(.Item("Decline_Reason").ToString.Trim) > 0 Then
                    Me.lblReject_Reason.Text = .Item("Decline_Reason").ToString.Trim
                End If
            End With

            Me.Populate_dgvDependents()

            Me.Populate_dgvAgents()

            Me.Populate_dgvNominees()

            Me.Populate_dgvExclusion_Clause()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
#Region "Lock Controls"
    Private Sub Lock_All_Controls(ByVal flag As Boolean)

        Me.txtProposer_Title.ReadOnly = flag
        Me.btnTitle.Enabled = Not flag
        Me.txtProposer_Name.ReadOnly = flag
        Me.dtpProposer_DOB.Enabled = Not flag
        Me.txtProposer_NRIC.ReadOnly = flag
        Me.txtProposer_OldIC.ReadOnly = flag
        Me.txtProposer_ArmForceID.ReadOnly = flag
        Me.rdiProposer_Race_Malay.AutoCheck = Not flag
        Me.rdiProposer_Race_Chinese.AutoCheck = Not flag
        Me.rdiProposer_Race_Indian.AutoCheck = Not flag
        Me.rdiProposer_Race_Others.AutoCheck = Not flag
        Me.txtAngkasa_FileNo.ReadOnly = flag
        Me.rdiProposer_MaritalStatus_Single.AutoCheck = Not flag
        Me.rdiProposer_MaritalStatus_Married.AutoCheck = Not flag
        Me.rdiProposer_MaritalStatus_Widowed.AutoCheck = Not flag
        Me.rdiProposer_MaritalStatus_Divorced.AutoCheck = Not flag
        Me.rdiProposer_Sex_Male.AutoCheck = Not flag
        Me.rdiProposer_Sex_Female.AutoCheck = Not flag
        Me.dtpProposal_Received_Date.Enabled = Not flag
        Me.dtpDateofSigned.Enabled = Not flag
        Me.txtProposer_AddressL1.ReadOnly = flag
        Me.txtProposer_AddressL2.ReadOnly = flag
        Me.txtProposerAdd3.ReadOnly = flag
        Me.txtProposerAdd4.ReadOnly = flag
        Me.txtProposer_City.ReadOnly = flag
        Me.txtProposer_Postcode.ReadOnly = flag
        Me.txtProposer_State.ReadOnly = flag
        Me.btnState.Enabled = Not flag
        Me.txtProposer_Phone_Hse.ReadOnly = flag
        Me.txtProposer_Mobile.ReadOnly = flag
        Me.txtProposer_Phone_Ofc.ReadOnly = flag
        Me.txtProposer_Email.ReadOnly = flag
        Me.txtProposer_Height.ReadOnly = flag
        Me.txtProposer_Weight.ReadOnly = flag
        Me.txtProposer_Occupation.ReadOnly = flag
        Me.txtProposer_Department.ReadOnly = flag


        Me.Lock_Enrolled_Dependents_Tab(flag)


        Me.txtProposer_Plan_Code.ReadOnly = flag
        Me.btnPlan.Enabled = Not flag
        Me.txtProposer_L2_Plan_Code.ReadOnly = flag
        Me.txtProposer_Plan_Premium.ReadOnly = flag
        Me.chkProposer_Plan_SpecialPromo.AutoCheck = Not flag
        Me.rdiProposer_Plan_Payment_Frequency_Yearly.AutoCheck = Not flag
        Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.AutoCheck = Not flag
        Me.rdiProposer_Plan_Payment_Frequency_Quarterly.AutoCheck = Not flag
        Me.rdiProposer_Plan_Payment_Frequency_Monthly.AutoCheck = Not flag
        Me.txtProposer_Plan_Payment_Method.ReadOnly = flag


        Select Case Me.txtProposer_Plan_Payment_Method.Text
            Case "Credit Card"
                Me.txtProposer_Plan_Payment_CreditCard_Batch_No.ReadOnly = flag
                Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.ReadOnly = flag
                Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.ReadOnly = flag
            Case "Cheque"
                Me.txtProposer_Plan_Payment_Cheque_No.ReadOnly = flag
                Me.txtProposer_Plan_Payment_Cheque_Receipt_No.ReadOnly = flag
            Case "Cash"
                Me.txtProposer_Plan_Payment_Receipt_No.ReadOnly = flag
                Me.txtProposer_Plan_Payment_Receipt_IssuedBy.ReadOnly = flag
        End Select
       
        Me.Lock_Insurance_Proposed_Tab_Agent(flag)


        Me.txtBorang1_79_SN.ReadOnly = flag


        Me.Lock_Nomination_Tab(flag)


        Me.Lock_Underwriting_Tab(flag)


        Me.chkDataEntry_CheckList_Proposer_Details.AutoCheck = Not flag
        Me.chkDataEntry_CheckList_Dependent_Details.AutoCheck = Not flag
        Me.chkDataEntry_CheckList_InsuranceProposed_Details.AutoCheck = Not flag
        Me.chkDataEntry_CheckList_BiroAngkasa_Details.AutoCheck = Not flag
        Me.chkDataEntry_CheckList_Nomination.AutoCheck = Not flag
        Me.chkDocumentation_CheckList_Proposer_Form.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Proposer_Form_Complete.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.AutoCheck = Not flag
        Me.cbTLBATarikh.AutoCheck = Not flag
        Me.cbTLBANoTelefon.AutoCheck = Not flag
        Me.cbTLBBNoKad.AutoCheck = Not flag
        Me.cbTLBBNoSijil.AutoCheck = Not flag
        Me.cbTLBBSurat.AutoCheck = Not flag
        Me.cbTLBBSertakan.AutoCheck = Not flag
        Me.cbTLBBPasangan.AutoCheck = Not flag
        Me.cbTLBCSOAL.AutoCheck = Not flag
        Me.cbTLBD.AutoCheck = Not flag
        Me.cbTLJenis.AutoCheck = Not flag
        Me.cbTLBP.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.AutoCheck = Not flag
        Me.chkDocumentation_CheckList_IC.AutoCheck = Not flag
        Me.chkDocumentation_CheckList_PG.AutoCheck = Not flag
        Me.rbPG6BTJ.AutoCheck = Not flag
        Me.rbPG6BJ.AutoCheck = Not flag
        Me.chkDocumentation_CheckList_Payslip.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Payslip_Clear.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Payslip_NotClear.AutoCheck = Not flag
        Me.chkDocumentation_CheckList_Borang1_79.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Borang1_79_Complete.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Borang1_79_Error.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Borang1_79_InComplete.AutoCheck = Not flag
        Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.AutoCheck = Not flag
        Me.cbTLTP.AutoCheck = Not flag
        Me.cbTLCM.AutoCheck = Not flag
        Me.chkProceed2Verification.AutoCheck = Not flag
    End Sub
    Private Sub Lock_Enrolled_Dependents_Tab(ByVal flag As Boolean)
        Me.txtDependent_Title.ReadOnly = flag
        Me.btnDependent_Title.Enabled = Not flag
        Me.txtDependent_FirstName.ReadOnly = flag
        Me.dtpDependent_DOB.Enabled = Not flag
        Me.txtDependent_NRIC.ReadOnly = flag
        Me.txtDependent_OldIC.ReadOnly = flag
        Me.txtDependent_ArmForceID.ReadOnly = flag
        Me.rdiDependent_Race_Malay.AutoCheck = Not flag
        Me.rdiDependent_Race_Chinese.AutoCheck = Not flag
        Me.rdiDependent_Race_Indian.AutoCheck = Not flag
        Me.rdiDependent_Race_Others.AutoCheck = Not flag
        Me.rdiDependent_MaritalStatus_Single.AutoCheck = Not flag
        Me.rdiDependent_MaritalStatus_Married.AutoCheck = Not flag
        Me.rdiDependent_MaritalStatus_Widowed.AutoCheck = Not flag
        Me.rdiDependent_MaritalStatus_Divorced.AutoCheck = Not flag
        Me.cmbDependent_Relationship.Enabled = Not flag
        Me.rdiDependent_Sex_Male.AutoCheck = Not flag
        Me.rdiDependent_Sex_Female.AutoCheck = Not flag
        Me.txtDependent_Height.ReadOnly = flag
        Me.txtDependent_Weight.ReadOnly = flag
        Me.txtDependent_Occupation.ReadOnly = flag
        Me.txtDependent_Department.ReadOnly = flag
        Me.btnDependent_Add.Enabled = Not flag
        Me.dgvDependents.AllowUserToDeleteRows = Not flag
    End Sub
    Private Sub Lock_Insurance_Proposed_Tab_Agent(ByVal flag As Boolean)
        Me.txtProposer_Plan_Commission_AgentCode.ReadOnly = flag
        Me.btnAgent.Enabled = Not flag
        Me.txtProposer_Plan_Commission_Agent_SharePercentage.ReadOnly = flag
        Me.btnAgent_Add.Enabled = Not flag
        Me.dgvAgents.AllowUserToDeleteRows = Not flag
    End Sub
    Private Sub Lock_Nomination_Tab(ByVal flag As Boolean)
        Me.txtNominee_Title.ReadOnly = flag
        Me.btnNominee_Title.Enabled = Not flag
        Me.txtNominee_Name.ReadOnly = flag
        Me.dtpNominee_DOB.Enabled = Not flag
        Me.txtNominee_NRIC.ReadOnly = flag
        Me.cbNominee_Relationship.Enabled = Not flag
        Me.txtNState.ReadOnly = flag
        Me.txtNPoscode.ReadOnly = flag
        Me.txtNTown.ReadOnly = flag
        Me.txtNAdd1.ReadOnly = flag
        Me.txtNAdd2.ReadOnly = flag
        Me.txtNAdd3.ReadOnly = flag
        Me.txtNAdd4.ReadOnly = flag
        Me.txtNominee_SharePercentage.ReadOnly = flag
        Me.btnNominee_Add.Enabled = Not flag
        Me.dgvNominees.AllowUserToDeleteRows = Not flag
    End Sub
    Private Sub Lock_Underwriting_Tab(ByVal flag As Boolean)
        Me.txtUnderwriting_ExclusionClause_Code.ReadOnly = flag
        Me.btnExclusionClause.Enabled = Not flag
        Me.chkUnderwriting_ApplyTo.AutoCheck = Not flag
        Me.txtUnderwriting_ApplyTo.ReadOnly = flag
        Me.btnDependent.Enabled = Not flag
        Me.txtUnderwriting_Other_Parameters.ReadOnly = flag
        Me.btnExclusionClause_Add.Enabled = Not flag
        Me.dgvExclusion_Clause.AllowUserToDeleteRows = Not flag
    End Sub
#End Region
#Region "General"
    Private Function Remove_Alphabet_Symbol(ByVal var_String As String) As String
        var_String = var_String.ToUpper.Replace("A", "")
        var_String = var_String.ToUpper.Replace("B", "")
        var_String = var_String.ToUpper.Replace("C", "")
        var_String = var_String.ToUpper.Replace("D", "")
        var_String = var_String.ToUpper.Replace("E", "")
        var_String = var_String.ToUpper.Replace("F", "")
        var_String = var_String.ToUpper.Replace("G", "")
        var_String = var_String.ToUpper.Replace("H", "")
        var_String = var_String.ToUpper.Replace("I", "")
        var_String = var_String.ToUpper.Replace("J", "")
        var_String = var_String.ToUpper.Replace("K", "")
        var_String = var_String.ToUpper.Replace("L", "")
        var_String = var_String.ToUpper.Replace("M", "")
        var_String = var_String.ToUpper.Replace("N", "")
        var_String = var_String.ToUpper.Replace("O", "")
        var_String = var_String.ToUpper.Replace("P", "")
        var_String = var_String.ToUpper.Replace("Q", "")
        var_String = var_String.ToUpper.Replace("R", "")
        var_String = var_String.ToUpper.Replace("S", "")
        var_String = var_String.ToUpper.Replace("T", "")
        var_String = var_String.ToUpper.Replace("U", "")
        var_String = var_String.ToUpper.Replace("V", "")
        var_String = var_String.ToUpper.Replace("W", "")
        var_String = var_String.ToUpper.Replace("X", "")
        var_String = var_String.ToUpper.Replace("Y", "")
        var_String = var_String.ToUpper.Replace("Z", "")
        var_String = var_String.ToUpper.Replace("/", "")
        var_String = var_String.ToUpper.Replace("-", "")
        var_String = var_String.ToUpper.Replace("#", "")
        var_String = var_String.ToUpper.Replace("@", "")
        Return var_String.Trim
    End Function
    Private Function Verify_Dependent_Details() As Boolean
        If Len(Me.txtDependent_Title.Text.Trim) = 0 Then
            MsgBox("Please do select dependent's title.")
            Me.btnDependent_Title.Focus()
            Return False
        End If

        If Len(Me.txtDependent_FirstName.Text.Trim) = 0 Then
            MsgBox("Please do key in dependent's full name.")
            Me.txtDependent_FirstName.Focus()
            Return False
        End If

        If Me.dtpDependent_DOB.Value.Date = Today() Then
            MsgBox("Please do select dependent's date of birth.")
            Me.dtpDependent_DOB.Focus()
            Return False
        End If

        If Len(Me.txtDependent_NRIC.Text.Trim) = 0 Then
            MsgBox("Please do key in dependent's new I/C No or police/army ID.")
            Me.txtDependent_NRIC.Focus()
            Return False
        End If

        If Me.rdiDependent_Race_Malay.Checked = False Then
            If Me.rdiDependent_Race_Chinese.Checked = False Then
                If Me.rdiDependent_Race_Indian.Checked = False Then
                    If Me.rdiDependent_Race_Others.Checked = False Then
                        MsgBox("Please do select dependent's race.")
                        Me.rdiDependent_Race_Malay.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Me.rdiDependent_MaritalStatus_Single.Checked = False Then
            If Me.rdiDependent_MaritalStatus_Married.Checked = False Then
                If Me.rdiDependent_MaritalStatus_Widowed.Checked = False Then
                    If Me.rdiDependent_MaritalStatus_Divorced.Checked = False Then
                        MsgBox("Please do select dependent's marital status.")
                        Me.rdiDependent_MaritalStatus_Single.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Me.cmbDependent_Relationship.SelectedIndex = -1 Then
            MsgBox("Please do select dependent's relationship with proposer.")
            Me.cmbDependent_Relationship.Focus()
            Return False
        End If

        If Me.rdiDependent_Sex_Male.Checked = False Then
            If Me.rdiDependent_Sex_Female.Checked = False Then
                MsgBox("Please do select in dependent's sex.")
                Me.rdiDependent_Sex_Male.Focus()
                Return False
            End If
        End If

        If Len(Me.txtDependent_Height.Text.Trim) = 0 Then
            MsgBox("Please do key in dependent's height.")
            Me.txtDependent_Height.Focus()
            Return False
        End If
        If Len(Me.txtDependent_Weight.Text.Trim) = 0 Then
            MsgBox("Please do key in dependent's weight.")
            Me.txtDependent_Weight.Focus()
            Return False
        End If

        If Me.cmbDependent_Relationship.Text = "Spouse" Then
            Dim dt As New DataTable
            dt = _objBusi.getDetails("PROPOSER", Me.txtProposer_NRIC.Text.ToString(), "", "", "", "CHECKDEPAGE", Conn)
            If Not dt.Rows.Count > 0 Then
                If Math.Floor(DateDiff(DateInterval.Day, Me.dtpDependent_DOB.Value, Now()) / 365.25) > 70 Then
                    MsgBox("Over aged spouse! Please check it")
                    Me.dtpDependent_DOB.Focus()
                    Return False
                End If
            End If
        Else
            If Math.Floor(DateDiff(DateInterval.Day, Me.dtpDependent_DOB.Value, Now()) / 365.25) > 22 Then
                MsgBox("Over aged child! Please check it")
                Me.dtpDependent_DOB.Focus()
                Return False
            End If
        End If
        Return True
    End Function
#End Region
#Region "Change Events"
    Private Function Change_IC(ByVal var_IC_New As String) As String
        If IsNumeric(var_IC_New) = True Then
            Select Case Len(var_IC_New.Trim)
                Case 7
                    Change_IC = "0" & var_IC_New
                Case 6
                    Change_IC = "00" & var_IC_New
                Case 5
                    Change_IC = "000" & var_IC_New
                Case 4
                    Change_IC = "0000" & var_IC_New
                Case 3
                    Change_IC = "00000" & var_IC_New
                Case 2
                    Change_IC = "000000" & var_IC_New
                Case 1
                    Change_IC = "0000000" & var_IC_New
                Case Else
                    Change_IC = var_IC_New
            End Select
            Return Change_IC
        Else
            Change_IC = var_IC_New
            Return Change_IC
        End If
    End Function
    Private Sub rdiProposer_Plan_Payment_Frequency_Yearly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProposer_Plan_Payment_Frequency_Yearly.CheckedChanged
        Me.txtProposer_Plan_Payment_Method.Clear()
    End Sub
    Private Sub rdiProposer_Plan_Payment_Frequency_HalfYearly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProposer_Plan_Payment_Frequency_HalfYearly.CheckedChanged
        Me.txtProposer_Plan_Payment_Method.Clear()
    End Sub
    Private Sub rdiProposer_Plan_Payment_Frequency_Quarterly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProposer_Plan_Payment_Frequency_Quarterly.CheckedChanged
        Me.txtProposer_Plan_Payment_Method.Clear()
    End Sub
    Private Sub rdiProposer_Plan_Payment_Frequency_Monthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProposer_Plan_Payment_Frequency_Monthly.CheckedChanged
        Me.txtProposer_Plan_Payment_Method.Clear()
    End Sub
    Private Sub chkDocumentation_CheckList_Proposer_Form_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocumentation_CheckList_Proposer_Form.CheckedChanged
        If Me.chkDocumentation_CheckList_Proposer_Form.Checked = True Then
            Me.fowDocumentation_CheckList_Proposer_Form.Enabled = True
        Else
            Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = False
            Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = False
            Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = False
            Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = False
            Me.fowDocumentation_CheckList_Proposer_Form.Enabled = False
        End If

    End Sub
    Private Sub chkDocumentation_CheckList_Payslip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocumentation_CheckList_Payslip.CheckedChanged
        If Me.chkDocumentation_CheckList_Payslip.Checked = True Then
            Me.fowDocumentation_CheckList_Payslip.Enabled = True
        Else
            Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = False
            Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = False
            Me.fowDocumentation_CheckList_Payslip.Enabled = False
        End If
    End Sub
    Private Sub chkDocumentation_CheckList_Borang1_79_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocumentation_CheckList_Borang1_79.CheckedChanged
        If Me.chkDocumentation_CheckList_Borang1_79.Checked = True Then
            Me.fowDocumentation_CheckList_Borang1_79.Enabled = True
        Else
            Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = False
            Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = False
            Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = False
            Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = False
            Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = False
            Me.fowDocumentation_CheckList_Borang1_79.Enabled = False
        End If
    End Sub
    Private Sub Save_Proposer_ApplicationForm_Changes()
        Try

            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)

            Dim cmdUpdate_Proposer As SqlCommandBuilder
            cmdUpdate_Proposer = New SqlCommandBuilder(da_Proposer)


            Dim ds_Proposer As New DataSet


            da_Proposer.Fill(ds_Proposer, "dt_Proposer")

            With ds_Proposer.Tables("dt_Proposer").Rows(0)
                .Item("Title") = Me.txtProposer_Title.Text.Trim
                .Item("Full_Name") = Me.txtProposer_Name.Text.Trim
                .Item("Birth_Date") = Me.dtpProposer_DOB.Value
                .Item("IC_New") = Me.txtProposer_NRIC.Text.Trim
                .Item("IC_Old") = Me.txtProposer_OldIC.Text.Trim
                .Item("ArmForce_ID") = Me.txtProposer_ArmForceID.Text.Trim

                If Me.rdiProposer_Race_Malay.Checked = True Then
                    .Item("Race") = "M"
                ElseIf Me.rdiProposer_Race_Chinese.Checked = True Then
                    .Item("Race") = "C"
                ElseIf Me.rdiProposer_Race_Indian.Checked = True Then
                    .Item("Race") = "I"
                ElseIf Me.rdiProposer_Race_Others.Checked = True Then
                    .Item("Race") = "O"
                End If

                .Item("Angkasa_FileNo") = Me.txtAngkasa_FileNo.Text.Trim

                If Me.rdiProposer_MaritalStatus_Single.Checked = True Then
                    .Item("Marital_Status") = "S"
                ElseIf Me.rdiProposer_MaritalStatus_Married.Checked = True Then
                    .Item("Marital_Status") = "M"
                ElseIf Me.rdiProposer_MaritalStatus_Widowed.Checked = True Then
                    .Item("Marital_Status") = "W"
                ElseIf Me.rdiProposer_MaritalStatus_Divorced.Checked = True Then
                    .Item("Marital_Status") = "D"
                End If

                If Me.rdiProposer_Sex_Male.Checked = True Then
                    .Item("Sex") = 1
                ElseIf Me.rdiProposer_Sex_Female.Checked = True Then
                    .Item("Sex") = 0
                End If

                .Item("Proposal_Received_Date") = Me.dtpProposal_Received_Date.Value

                .Item("Proposal_Signed_Date") = Me.dtpDateofSigned.Value

                .Item("Postal_Address_L1") = Me.txtProposer_AddressL1.Text.Trim
                .Item("Postal_Address_L2") = Me.txtProposer_AddressL2.Text.Trim
                .Item("Add3") = Me.txtProposerAdd3.Text.Trim()
                .Item("Add4") = Me.txtProposerAdd4.Text.Trim()
                .Item("Town") = Me.txtProposer_City.Text.Trim
                .Item("Postcode") = Me.txtProposer_Postcode.Text.Trim
                .Item("State") = Me.txtProposer_State.Text.Trim
                .Item("Bank_Name") = Me.cbBankName.Text.Trim
                .Item("Bank_Ac") = Me.txtBankAc.Text.Trim
                .Item("Phone_Hse") = Me.txtProposer_Phone_Hse.Text.Trim
                .Item("Phone_Mobile") = Me.txtProposer_Mobile.Text.Trim
                .Item("Phone_Off") = Me.txtProposer_Phone_Ofc.Text.Trim
                .Item("Email") = Me.txtProposer_Email.Text.Trim
                .Item("Height") = Me.txtProposer_Height.Text.Trim
                .Item("Weight") = Me.txtProposer_Weight.Text.Trim
                .Item("Occupation") = Me.txtProposer_Occupation.Text.Trim
                .Item("Department") = Me.txtProposer_Department.Text.Trim
                .Item("Plan_Code") = Me.txtProposer_Plan_Code.Text.Trim
                .Item("Level2_Plan_Code") = Me.txtProposer_L2_Plan_Code.Text.Trim
                .Item("Premium") = Me.txtProposer_Plan_Premium.Text
                .Item("Special_Promo") = Me.chkProposer_Plan_SpecialPromo.Checked
                If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
                    .Item("Payment_Frequency") = "Y"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.Checked = True Then
                    .Item("Payment_Frequency") = "H"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_Quarterly.Checked = True Then
                    .Item("Payment_Frequency") = "Q"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = True Then
                    .Item("Payment_Frequency") = "M"
                End If

                .Item("Payment_Method") = Me.txtProposer_Plan_Payment_Method.Text.Trim
                .Item("Payment_Method_CreditCard_Batch_No") = Me.txtProposer_Plan_Payment_CreditCard_Batch_No.Text.Trim
                .Item("Payment_Method_CreditCard_Appr_Code") = Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.Text.Trim
                .Item("Payment_Method_CreditCard_Invoice_No") = Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.Text.Trim
                .Item("Payment_Method_Cheque_No") = Me.txtProposer_Plan_Payment_Cheque_No.Text.Trim
                .Item("Payment_Method_Cheque_Receipt_No") = Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Text.Trim
                .Item("Payment_Method_Cash_Receipt_No") = Me.txtProposer_Plan_Payment_Receipt_No.Text.Trim
                .Item("Payment_Method_Cash_Receipt_IssuedBy") = Me.txtProposer_Plan_Payment_Receipt_IssuedBy.Text.Trim
                .Item("Payment_Method_BiroAngkasa_Borang1_79_SN") = Me.txtBorang1_79_SN.Text.Trim
                .Item("DataEntry_Checklist_Proposer_Details") = Me.chkDataEntry_CheckList_Proposer_Details.Checked
                .Item("DataEntry_Checklist_Enrolled_Dependents") = Me.chkDataEntry_CheckList_Dependent_Details.Checked
                .Item("DataEntry_Checklist_Insurance_Proposed") = Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked
                .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = Me.chkDataEntry_CheckList_BiroAngkasa_Details.Checked
                .Item("DataEntry_Checklist_Nomination") = Me.chkDataEntry_CheckList_Nomination.Checked
                .Item("Document_Checklist_Application_Form") = Me.chkDocumentation_CheckList_Proposer_Form.Checked

                If Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Lengkap"
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Tidak Lengkap"
                    Dim sMsg As String = ""
                    If Me.cbTLBATarikh.Checked Then
                        sMsg = sMsg & "-Bahagian A (Tarikh Lahir)" & " ! "
                    End If
                    If Me.cbTLBANoTelefon.Checked Then
                        sMsg = sMsg & "-Bahagian A (No Telefon)" & " ! "
                    End If

                    If Me.cbTLBBNoKad.Checked Then
                        sMsg = sMsg & "-Bahagian B (No Kad Pengenalan Pasangan)" & " ! "
                    End If
                    If Me.cbTLBBNoSijil.Checked Then
                        sMsg = sMsg & "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)" & " ! "
                    End If
                    If Me.cbTLBBSurat.Checked Then
                        sMsg = sMsg & "-Bahagian B (Surat Pengambilan Anak Angkat)" & " ! "
                    End If
                    If Me.cbTLBBSertakan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Sertakan Sijil Kelahiran Anak)" & " ! "
                    End If
                    If Me.cbTLBBPasangan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)" & " ! "
                    End If
                    If Me.cbTLBBSertakan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Sertakan Sijil Kelahiran Anak)" & " ! "
                    End If
                    If Me.cbTLBBPasangan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Pasangan / Anak Melebihi had kelayakan umur)" & " ! "
                    End If
                    If Me.cbTLBCSOAL.Checked Then
                        sMsg = sMsg & "-Bahagian C (Soal Selidik)" & " ! "
                    End If
                    If Me.cbTLBD.Checked Then
                        sMsg = sMsg & "-Bahagian D & E (Tandatangan Pemohon)" & " ! "
                    End If
                    If Me.cbTLJenis.Checked Then
                        sMsg = sMsg & "-Jenis Pilihan Pelan" & " ! "
                    End If
                    If Me.cbTLBP.Checked Then
                        sMsg = sMsg & "-Bahagian Penamaan" & " ! "
                    End If
                    If Me.chkBPTP.Checked Then
                        sMsg = sMsg & "-Bahagian Pengisytiharan (Tandatangan Pemohon)" & " ! "
                    End If
                    If Me.chkSDTS.Checked Then
                        sMsg = sMsg & "-Seksyen D (Tandatangan Saksi)" & " ! "
                    End If
                    If Me.chkSDTP.Checked Then
                        sMsg = sMsg & "-Seksyen D (Tandatangan Pemilik)" & " ! "
                    End If
                    .Item("DCAF_Status") = sMsg
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Borang Lama"
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Borang Salah"
                End If

                .Item("Document_Checklist_IC") = Me.chkDocumentation_CheckList_IC.Checked
                .Item("Document_Checklist_Penyata") = Me.chkDocumentation_CheckList_PG.Checked
                If Me.rbPG6BTJ.Checked = True Then
                    .Item("Document_Checklist_Penyata_Status") = "Tidak"
                ElseIf Me.rbPG6BJ.Checked = True Then
                    .Item("Document_Checklist_Penyata_Status") = "Ya"
                End If
                .Item("Document_Checklist_Payslip") = Me.chkDocumentation_CheckList_Payslip.Checked
                If Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = True Then
                    .Item("Document_Checklist_Payslip_Status") = "Jelas"
                ElseIf Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = True Then
                    .Item("Document_Checklist_Payslip_Status") = "Tidak Jelas"
                End If

                .Item("Document_Checklist_Borang1_79") = Me.chkDocumentation_CheckList_Borang1_79.Checked
                If Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Lengkap dengan Maklumat Majikan dan Cop Majikan"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Terdapat kesilapan mengisi Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Penggunaan 'liquid paper' pada Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Muat Turun Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Tidak Lengkap"
                    Dim sMsg1 As String = ""
                    If Me.cbTLTP.Checked Then
                        sMsg1 = sMsg1 & "Tandatangan Pemohon" & " ! "
                    End If
                    If Me.cbTLCM.Checked Then
                        sMsg1 = sMsg1 & "Cop Majikan" & " ! "
                    End If
                    If Me.cbTLTM.Checked Then
                        sMsg1 = sMsg1 & "Tandatangan Majikan" & " ! "
                    End If
                    .Item("DCB179_STATUS") = sMsg1
                End If

                If Me.rbUWCIMBYes.Checked Then
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("CIMB_UW_STATUS") = "YES"
                Else
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("CIMB_UW_STATUS") = "NO"
                End If

                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With
            da_Proposer.Update(ds_Proposer, "dt_Proposer")
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("Update done.")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub chkUnderwriting_ApplyTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnderwriting_ApplyTo.CheckedChanged
        If Me.chkUnderwriting_ApplyTo.Checked = True Then
            Me.txtUnderwriting_ApplyTo.Clear()
            Me.btnDependent.Enabled = False
        Else
            Me.btnDependent.Enabled = True
        End If
    End Sub
    Private Sub chkProceed2Verification_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProceed2Verification.CheckedChanged
        If Me.chkProceed2Verification.Checked = True Then
            Me.btnSave.Enabled = True
        Else
            Me.btnSave.Enabled = False
        End If
    End Sub
    Private Sub rdiProceed2DefermentLetter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProceed2DefermentLetter.CheckedChanged
        If Me.rdiProceed2DefermentLetter.Checked = True Then
            Me.btnPrint_DefermentLetter.Enabled = True
            Me.btnPrint_AcknowledgementLetter.Enabled = False
            Me.btnPrint_RejectLetter.Enabled = False
            Me.btnPrint_UnderwritingLetter.Enabled = False
            Me.btnYearlyLetter.Enabled = False
        End If
    End Sub
    Private Sub rdiProceed2AcknowledgementLetter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProceed2AcknowledgementLetter.CheckedChanged
        If Me.rdiProceed2AcknowledgementLetter.Checked = True Then
            Me.btnPrint_DefermentLetter.Enabled = False
            Me.btnPrint_AcknowledgementLetter.Enabled = True
            Me.btnPrint_RejectLetter.Enabled = False
            Me.btnPrint_UnderwritingLetter.Enabled = False
            Me.btnYearlyLetter.Enabled = False
        End If
    End Sub
    Private Sub rdiProceed2RejectLetter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProceed2RejectLetter.CheckedChanged
        If Me.rdiProceed2RejectLetter.Checked = True Then
            Me.btnPrint_DefermentLetter.Enabled = False
            Me.btnPrint_AcknowledgementLetter.Enabled = False
            Me.btnPrint_RejectLetter.Enabled = True
            Me.btnPrint_UnderwritingLetter.Enabled = False
            Me.btnYearlyLetter.Enabled = False
        End If
    End Sub
    Private Sub rdiProceed2UnderwritingLetter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiProceed2UnderwritingLetter.CheckedChanged
        If Me.rdiProceed2UnderwritingLetter.Checked = True Then
            Me.btnPrint_DefermentLetter.Enabled = False
            Me.btnPrint_AcknowledgementLetter.Enabled = False
            Me.btnPrint_RejectLetter.Enabled = False
            Me.btnPrint_UnderwritingLetter.Enabled = True
            Me.btnYearlyLetter.Enabled = False
        End If
    End Sub
#End Region
#Region "Text box Leave"
    Private Sub dtpProposer_DOB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpProposer_DOB.Leave

        Me.txtProposer_Age.Text = Math.Floor(DateDiff(DateInterval.Day, Me.dtpProposer_DOB.Value, Now()) / 365.25)
        
    End Sub
    Private Sub txtProposer_NRIC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_NRIC.Leave

        txtProposer_NRIC.Text = txtProposer_NRIC.Text.ToString.ToUpper()
        If Len(Me.txtProposer_NRIC.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Exit Sub
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) < 9 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Exit Sub
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) = 10 Or Len(Me.txtProposer_NRIC.Text.Trim) > 13 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Exit Sub
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) = 11 Or Len(Me.txtProposer_NRIC.Text.Trim) = 12 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txtProposer_ArmForceID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_ArmForceID.Leave
        If Len(Me.txtProposer_NRIC.Text.Trim) = 0 Then
            If Len(Me.txtProposer_ArmForceID.Text.Trim) > 0 Then
                Me.txtProposer_NRIC.Text = Me.Change_IC(Me.Remove_Alphabet_Symbol(Me.txtProposer_ArmForceID.Text.Trim).ToString)
            End If
        End If
    End Sub
    Private Sub txtProposer_Postcode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_Postcode.Leave
        Me.txtProposer_Postcode.Text = Me.Remove_Alphabet_Symbol(Me.txtProposer_Postcode.Text.Trim)
    End Sub
    Private Sub txtProposer_Height_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_Height.Leave
        Me.txtProposer_Height.Text = Me.Remove_Alphabet_Symbol(Me.txtProposer_Height.Text.Trim)
    End Sub
    Private Sub txtProposer_Weight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_Weight.Leave
        Me.txtProposer_Weight.Text = Me.Remove_Alphabet_Symbol(Me.txtProposer_Weight.Text.Trim)
    End Sub
    Private Sub dtpDependent_DOB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDependent_DOB.Leave

        Me.txtDependent_Age.Text = Math.Floor(DateDiff(DateInterval.Day, Me.dtpDependent_DOB.Value, Now()) / 365.25)
    End Sub
    Private Sub txtDependent_NRIC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDependent_NRIC.Leave

    End Sub
    Private Sub txtDependent_ArmForceID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDependent_ArmForceID.Leave
        If Len(Me.txtDependent_NRIC.Text.Trim) = 0 Then
            If Len(Me.txtDependent_ArmForceID.Text.Trim) > 0 Then
                Me.txtDependent_NRIC.Text = Me.Change_IC(Me.Remove_Alphabet_Symbol(Me.txtDependent_ArmForceID.Text.Trim).ToString)
            End If
        End If
    End Sub
    Private Sub txtDependent_Height_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDependent_Height.Leave
        Me.txtDependent_Height.Text = Me.Remove_Alphabet_Symbol(Me.txtDependent_Height.Text.Trim)
    End Sub
    Private Sub txtDependent_Weight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDependent_Weight.Leave
        Me.txtDependent_Weight.Text = Me.Remove_Alphabet_Symbol(Me.txtDependent_Weight.Text.Trim)
    End Sub
    Private Sub txtProposer_Plan_Commission_Agent_SharePercentage_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProposer_Plan_Commission_Agent_SharePercentage.Leave
        Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text = Me.Remove_Alphabet_Symbol(Me.txtProposer_Plan_Commission_Agent_SharePercentage.Text.Trim)
    End Sub
#End Region
#Region "Tab Control"
    Private Sub TabControl1_Deselecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Deselecting
        Select Case e.TabPageIndex
            Case 0
                If Me.Verify_Proposer_Details() = False Then
                    Me.chkDataEntry_CheckList_Proposer_Details.Checked = False
                    e.Cancel = True
                Else
                    Me.chkDataEntry_CheckList_Proposer_Details.Checked = True
                End If
            Case 2
                If Not Me.txtProposer_Plan_Code.Text = "WRONGCODE" Then
                    If Not Me.txtProposer_Plan_Code.Text = "PWRONGCODE" Then
                        If Me.Verify_Insurance_Proposed() = False Then
                            Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked = False
                            e.Cancel = True
                        Else
                            Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked = True
                        End If
                    End If
                End If
            Case 3
                If Me.dgvNominees.Rows.Count > 0 Then
                    With Me.dgvNominees
                        Dim dgvNCount As Integer = 0
                        Dim TotShare As Decimal = 0
                        TotShare = Val(Me.txtNominee_SharePercentage.Text.Trim)
                        Do While dgvNCount < Me.dgvNominees.Rows.Count
                            With Me.dgvNominees
                                TotShare += Val(.Rows(dgvNCount).Cells(12).Value)
                            End With
                            dgvNCount += 1
                        Loop
                        If TotShare <> 100 Then
                            MsgBox("Invalid Share % for Nomination!Please check it")
                            e.Cancel = True
                        End If
                    End With
                End If
        End Select
    End Sub
    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If Me.txtProposer_L2_Plan_Code.Text.ToString.Trim() = "EMPLOYEE AND FAMILY ONLY" Then
            Select Case e.TabPageIndex
                Case 1, 2
                Case Else
                    If Me.dgvDependents.RowCount < 1 Then
                        MsgBox("You have selected family plan,please do key in dependents details or select another product!")
                        Me.TabControl1.SelectedTab = Me.TabPage2
                    End If
            End Select
        ElseIf Me.txtProposer_L2_Plan_Code.Text.ToString.Trim() = "EMPLOYEE ONLY" Then
            Select Case e.TabPageIndex
                Case 1, 2
                Case Else
                    If Me.dgvDependents.RowCount > 0 Then
                        MsgBox("You have selected Individual plan,please remove dependents details or select another product!")
                        Me.TabControl1.SelectedTab = Me.TabPage2
                    End If
            End Select
        End If
        If Me.txtProposer_Plan_Code.Text = "WRONGCODE" Then
            Select Case e.TabPageIndex
                Case 1
                Case 2
                Case Else
                    TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
                    Me.dgvDependents.MultiSelect = False
                    Me.dgvDependents.ContextMenuStrip = Me.cmsDependent
                    Me.cmsDependent_Edit.Enabled = False
                    Me.cmsDependent_Add.Enabled = False
                    Exit Sub
            End Select
        ElseIf Me.txtProposer_Plan_Code.Text = "PWRONGCODE" Then
            TabControl1.SelectedTab = Me.TabPage5
            Exit Sub
        End If
        Select Case e.TabPageIndex
            Case 0
                Me.btnPrevious.Visible = False
                Me.btnNext.Visible = True
            Case 2
                Me.btnPrevious.Visible = True
                Me.btnNext.Visible = True
                If Me.txtProposer_Plan_Payment_Method.Text = "Deduction via Biro Angkasa" Then
                    Me.txtBorang1_79_SN.Enabled = True
                    If Me.lblForm_Flag.Text = "N" Then

                    End If
                Else
                    Me.txtBorang1_79_SN.Enabled = False
                End If
            Case 3
                Me.btnPrevious.Visible = True
                Me.btnNext.Visible = True
            Case 4
                Me.btnPrevious.Visible = True
                Me.btnNext.Visible = True
            Case 5
                Me.btnPrevious.Visible = True
                Me.btnNext.Visible = False
                If Me.lblE32.Text = "D1E32" Then
                    If vD1E32() Then
                        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
                        Exit Sub
                    End If
                End If

                If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
                    Me.chkDocumentation_CheckList_Payslip.Checked = False
                    Me.chkDocumentation_CheckList_Borang1_79.Checked = False
                    Me.chkDocumentation_CheckList_PG.Checked = False
                    Me.rbPG6BTJ.Checked = False
                    Me.rbPG6BJ.Enabled = False

                    Me.chkDocumentation_CheckList_Payslip.Enabled = False
                    Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                    Me.chkDocumentation_CheckList_PG.Enabled = False
                    Me.rbPG6BTJ.Enabled = False
                    Me.rbPG6BJ.Enabled = False
                Else
                    Me.chkDocumentation_CheckList_Payslip.Enabled = True
                    Me.chkDocumentation_CheckList_PG.Enabled = True
                    Me.rbPG6BTJ.Enabled = True
                    Me.rbPG6BJ.Enabled = True
                    If Me.txtProposer_Plan_Payment_Method.Text.Trim <> "Deduction via Biro Angkasa" Then
                        Me.chkDocumentation_CheckList_Borang1_79.Checked = False
                        Me.chkDocumentation_CheckList_Borang1_79.Enabled = False
                    Else
                        Me.chkDocumentation_CheckList_Borang1_79.Enabled = True
                    End If
                End If

                Select Case Me.lblForm_Flag.Text
                    Case "N"
                        Me.btnSave.Visible = True
                        Me.btnCancel.Visible = True
                        Me.btnSave.Enabled = False
                        Me.GrpBox_ActionAfter_Verification.Visible = False
                    Case "V"
                        If Me.lblEdit_Status.Text = "Edit Mode" Then
                            Me.chkProceed2Verification.Visible = True
                            Me.btnSave.Enabled = False
                            Me.btnSave.Visible = True
                            Me.btnCancel.Enabled = True
                            Me.btnCancel.Visible = True
                            Me.GrpBox_ActionAfter_Verification.Visible = False
                        Else
                            VEnable()
                        End If
                    Case "View"
                        If Me.lblEdit_Status.Text = "Edit Mode" Then
                            Me.chkProceed2Verification.Visible = True
                            Me.btnSave.Enabled = False
                            Me.btnSave.Visible = True
                            Me.btnCancel.Enabled = True
                            Me.btnCancel.Visible = True


                            Me.GrpBox_ActionAfter_Verification.Visible = False
                        Else
                            Me.chkProceed2Verification.Visible = False
                            Me.btnSave.Visible = False
                            Me.btnCancel.Visible = False
                            Me.GrpBox_ActionAfter_Verification.Visible = True
                            Me.FlowLayoutPanel1.Visible = False
                            Select Case Me.lblProposer_Status.Text
                                Case "1A"
                                    If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
                                        Me.btnYearlyLetter.Enabled = True
                                    Else
                                        Me.btnPrint_AcknowledgementLetter.Enabled = True
                                    End If
                                    Dim aCode As String()
                                    aCode = Me.txtProposer_Plan_Code.Text.ToString().Trim().Split("-")
                                    Dim pCode As String
                                    pCode = aCode(1).Substring(0, 1)
                                    If pCode = "Y" Then
                                        Me.btnYearlyLetter.Enabled = True
                                        Me.btnPrint_AcknowledgementLetter.Enabled = False
                                    Else
                                        Me.btnYearlyLetter.Enabled = False
                                        Me.btnPrint_AcknowledgementLetter.Enabled = True
                                    End If
                                    Me.btnInfoLetter.Visible = True
                                Case "1D"
                                    Me.btnPrint_DefermentLetter.Enabled = True
                                Case "1R"
                                    Me.btnPrint_RejectLetter.Enabled = True
                                Case "1U", "1PU"
                                    Me.btnPrint_UnderwritingLetter.Enabled = True
                                Case Else
                                    MsgBox("Error in Status")
                            End Select
                        End If
                    Case "Unlock"
                        If Me.lblEdit_Status.Text = "Edit Mode" Then
                            Me.chkProceed2Verification.Visible = True
                            Me.btnSave.Enabled = False
                            Me.btnSave.Visible = True
                            Me.btnCancel.Enabled = True
                            Me.btnCancel.Visible = True

                            Me.GrpBox_ActionAfter_Verification.Visible = False
                        Else
                            Me.chkProceed2Verification.Visible = False
                            Me.btnSave.Visible = False
                            Me.btnCancel.Visible = False
                            Me.GrpBox_ActionAfter_Verification.Visible = False
                            Me.FlowLayoutPanel1.Visible = False
                        End If
                    Case "Readonly"
                        Me.chkProceed2Verification.Visible = False
                        Me.btnSave.Visible = False
                        Me.btnCancel.Visible = False
                        Me.GrpBox_ActionAfter_Verification.Visible = False
                        Me.FlowLayoutPanel1.Visible = False
                    Case Else
                        MsgBox("Error in loading form due to Form Flag: (N)ew / (V)erification")
                End Select

            Case Else
                Me.btnPrevious.Visible = True
                Me.btnNext.Visible = True
        End Select
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Sub VEnable()
        Me.chkProceed2Verification.Visible = False
        Me.btnSave.Visible = False
        Me.btnCancel.Visible = False
        Me.GrpBox_ActionAfter_Verification.Visible = True
        Me.FlowLayoutPanel1.Enabled = True
        Me.rdiProceed2AcknowledgementLetter.Checked = True
        Me.rdiProceed2DefermentLetter.Visible = True
        Me.rdiProceed2RejectLetter.Visible = True
        Me.rdiProceed2UnderwritingLetter.Visible = True
        Me.rdioYearlyLetter.Visible = True
    End Sub
    Private Function Verify_Documentation_Complete() As Boolean
        If Me.chkDocumentation_CheckList_Proposer_Form.Checked = False Then
            Return False
        Else
            If Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = False Then
                If Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = True Then
                    Return False
                Else
                    If Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = True Then
                        Return False
                    ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = True Then
                        Return False
                    End If
                End If
            End If
        End If

        If Me.chkDocumentation_CheckList_IC.Checked = False Then
            Return False
        End If

        If Me.chkDocumentation_CheckList_PG.Checked = False Then
            Return False
        End If

        If Me.chkDocumentation_CheckList_Payslip.Enabled = True Then
            If Me.chkDocumentation_CheckList_Payslip.Checked = True Then
                If Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = True Then
                        Return False
                    End If
                End If
            Else
                Return False
            End If
        End If

        If Me.chkDocumentation_CheckList_Borang1_79.Enabled = True Then
            If Me.chkDocumentation_CheckList_Borang1_79.Checked = True Then
                If Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = True Then
                        If Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = True Then
                            Return False
                        Else
                            If Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = True Then
                                Return False
                            Else
                                If Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True Then
                                    Return False
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                Return False
            End If
        End If
        Return True
    End Function
    Private Function Verify_Proposer_Details() As Boolean

        If Len(Me.txtProposer_Title.Text.Trim) = 0 Then
            MsgBox("Please do select Proposer's Title.")
            Me.btnTitle.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Name.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Name.")
            Me.txtProposer_Name.Focus()
            Return False
        End If

        If Me.dtpProposer_DOB.Value.Date >= Today() Then
            MsgBox("Please do select Proposer's Date of Birth.")
            Me.dtpProposer_DOB.Focus()
            Return False
        End If

        If Len(Me.txtProposer_NRIC.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Return False
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) < 9 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Return False
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) = 10 Or Len(Me.txtProposer_NRIC.Text.Trim) > 13 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Return False
        ElseIf Len(Me.txtProposer_NRIC.Text.Trim) = 11 Or Len(Me.txtProposer_NRIC.Text.Trim) = 12 Then
            MsgBox("Please do key in Proposer's correct New I/C No or Police/Army ID.")
            Me.txtProposer_NRIC.Focus()
            Return False
        End If

        If Me.rdiProposer_Race_Malay.Checked = False Then
            If Me.rdiProposer_Race_Chinese.Checked = False Then
                If Me.rdiProposer_Race_Indian.Checked = False Then
                    If Me.rdiProposer_Race_Others.Checked = False Then
                        MsgBox("Please do select Proposer's Race.")
                        Me.rdiProposer_Race_Malay.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Me.rdiProposer_MaritalStatus_Single.Checked = False Then
            If Me.rdiProposer_MaritalStatus_Married.Checked = False Then
                If Me.rdiProposer_MaritalStatus_Widowed.Checked = False Then
                    If Me.rdiProposer_MaritalStatus_Divorced.Checked = False Then
                        MsgBox("Please do select Proposer's Marital Status.")
                        Me.rdiProposer_MaritalStatus_Single.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Me.rdiProposer_Sex_Male.Checked = False Then
            If Me.rdiProposer_Sex_Female.Checked = False Then
                MsgBox("Please do select in Proposer's Sex.")
                Me.rdiProposer_Sex_Male.Focus()
                Return False
            End If
        End If

        If Len(Me.txtProposer_AddressL1.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Address.")
            Me.txtProposer_AddressL1.Focus()
            Return False
        End If

        If Len(Me.txtProposer_City.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Town.")
            Me.txtProposer_City.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Postcode.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Postcode.")
            Me.txtProposer_Postcode.Focus()
            Return False
        End If

        If Len(Me.txtProposer_State.Text.Trim) = 0 Then
            MsgBox("Please do select Proposer's State.")
            Me.btnState.Focus()
            Return False
        End If

        If Me.cbBankName.SelectedIndex = -1 Then
            MsgBox("Please do select Proposer's Bank Name.")
            Me.btnState.Focus()
            Return False
        End If

        If Len(Me.txtBankAc.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Bank Account Number.")
            Me.btnState.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Phone_Hse.Text.Trim) = 0 Then
            If Len(Me.txtProposer_Mobile.Text.Trim) = 0 Then
                If Len(Me.txtProposer_Phone_Ofc.Text.Trim) = 0 Then
                    MsgBox("Please do key in Proposer's Telephone (House/Office) or Mobile.")
                    Me.txtProposer_Phone_Hse.Focus()
                    Return False
                End If
            End If
        End If

        If Len(Me.txtProposer_Height.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Height.")
            Me.txtProposer_Height.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Weight.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Weight.")
            Me.txtProposer_Weight.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Occupation.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Occupation.")
            Me.txtProposer_Occupation.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Department.Text.Trim) = 0 Then
            MsgBox("Please do key in Proposer's Department.")
            Me.txtProposer_Department.Focus()
            Return False
        End If
        If Me.lblForm_Flag.Text = "N" Then
            Dim dt1 As DateTime = Convert.ToDateTime(Me.dtpProposal_Received_Date.Text)
            Dim dt2 As DateTime = Convert.ToDateTime(DateTime.Now())
            Dim months As Integer
            months = DateDiff(DateInterval.Month, dt1, dt2)
            If Not My.Settings.Username = "Admin" Then
                If months > 6 Then
                    MsgBox("Proposer received date exceed the limited period of 6 Months, Please check it!")
                    Me.dtpProposal_Received_Date.Focus()
                    Return False
                End If
            End If
        End If
        If Me.lblForm_Flag.Text = "N" Then
            Dim dt1 As DateTime = Convert.ToDateTime(Me.dtpDateofSigned.Text)
            Dim dt2 As DateTime = Convert.ToDateTime(DateTime.Now())
            Dim months As Integer
            months = DateDiff(DateInterval.Month, dt1, dt2)
            If Not My.Settings.Username = "Admin" Then
                If months > 6 Then
                    MsgBox("Proposer Signed date exceed the limited period of 6 Months, Please check it!")
                    Me.dtpProposal_Received_Date.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Function Verify_Insurance_Proposed() As Boolean
        If Len(Me.txtProposer_Plan_Code.Text.Trim) = 0 Then
            MsgBox("Please do select Insurance Proposed's Plan Code.")
            Me.btnPlan.Focus()
            Return False
        End If

        If Len(Me.txtProposer_Plan_Premium.Text.Trim) = 0 Then
            MsgBox("Please do key in Insurance Proposed's Premium.")
            Me.txtProposer_Plan_Premium.Focus()
            Return False
        End If

        If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = False Then
            If Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.Checked = False Then
                If Me.rdiProposer_Plan_Payment_Frequency_Quarterly.Checked = False Then
                    If Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = False Then
                        MsgBox("Please do select Payment's Frequency.")
                        Me.rdiProposer_Plan_Payment_Frequency_Monthly.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Len(Me.txtProposer_Plan_Payment_Method.Text.Trim) = 0 Then
            MsgBox("Please do select payment method")
            Me.btnPayment_Method.Focus()
            Return False
        End If

        If Me.txtProposer_Plan_Payment_Method.Text = "Deduction via Biro Angkasa" Then
            If Len(Me.txtBorang1_79_SN.Text.Trim) = 0 Then
                MsgBox("Please do key in Borang SN!")
                Me.txtBorang1_79_SN.Focus()
                Return False
            End If
        End If

        Select Case Me.txtProposer_Plan_Payment_Method.Text.Trim()
            Case "Cash"
                If Len(Me.txtProposer_Plan_Payment_Receipt_No.Text.Trim()) = 0 Then
                    MsgBox("Please do key in Receipt No!")
                    Me.txtProposer_Plan_Payment_Receipt_No.Focus()
                    Return False
                End If
                If Len(Me.txtProposer_Plan_Payment_Receipt_IssuedBy.Text.Trim()) = 0 Then
                    MsgBox("Please do key in issued by!")
                    Me.txtProposer_Plan_Payment_Receipt_IssuedBy.Focus()
                    Return False
                End If
            Case "Cheque"
                If Len(Me.txtProposer_Plan_Payment_Cheque_No.Text.Trim()) = 0 Then
                    MsgBox("Please do key in Cheque No!")
                    Me.txtProposer_Plan_Payment_Cheque_No.Focus()
                    Return False
                End If
                If Len(Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Text.Trim()) = 0 Then
                    MsgBox("Please do key in Cheque Receipt No!")
                    Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Focus()
                    Return False
                End If
            Case "Credit Card"
                If Len(Me.txtProposer_Plan_Payment_CreditCard_Batch_No.Text.Trim()) = 0 Then
                    MsgBox("Please do key in credit card batch No!")
                    Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Focus()
                    Return False
                End If
                If Len(Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.Text.Trim()) = 0 Then
                    MsgBox("Please do key in credit card approved code!")
                    Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.Focus()
                    Return False
                End If
                If Len(Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.Text.Trim()) = 0 Then
                    MsgBox("Please do key in credit card invoice no!")
                    Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.Focus()
                    Return False
                End If
        End Select

        If Me.dgvAgents.RowCount = 0 Then
            MsgBox("Please do insert Agent Code & Share Percentage.")
            Return False
        End If


        Dim _ds1 As New DataSet
        Dim _scChkProposal1 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scChkProposal1.CommandType = CommandType.Text
        _scChkProposal1.CommandText = "select * from dt_member where ic_new= '" & Me.txtProposer_NRIC.Text.Trim & "'"
        Dim _sdaChkProposal1 As New SqlDataAdapter(_scChkProposal1)
        _sdaChkProposal1.Fill(_ds1, "dt_member")
        If _ds1.Tables(0).Rows.Count > 0 Then
            Dim ds As New DataSet
            Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)

            sqlCmd.CommandText = "select * from dt_member_policy where member_id='" & _ds1.Tables(0).Rows(0)("ID").ToString() & "' and Status !='INFORCE' and plan_code='" & Me.txtProposer_Plan_Code.Text.ToString.Trim() & "' and level2_plan_code='" & Me.txtProposer_L2_Plan_Code.Text.ToString.Trim() & "'"
            sqlCmd.CommandType = CommandType.Text
            Dim adp As New SqlDataAdapter(sqlCmd)
            adp.Fill(ds, "dt_member_policy")
            If Not ds.Tables(0).Rows.Count > 0 Then
                Dim ds1 As New DataSet
                Dim sqlCmd1 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                sqlCmd1.CommandText = "select * from dt_member_policy where member_id='" & _ds1.Tables(0).Rows(0)("ID").ToString() & "' and plan_code='" & Me.txtProposer_Plan_Code.Text.ToString.Trim() & "' " ' and level2_plan_code='" & Me.txtProposer_L2_Plan_Code.Text.ToString.Trim() & "'"
                sqlCmd1.CommandType = CommandType.Text
                Dim adp1 As New SqlDataAdapter(sqlCmd1)
                adp1.Fill(ds1, "dt_member_policy")
                If ds1.Tables(0).Rows.Count > 0 Then
                    Dim status As String
                    If IsDBNull(ds1.Tables(0).Rows(0)("Status")) Then
                        MsgBox("We are sorry, we unable to procced this proposal. Its already Inforce!")
                        Return False
                    Else
                        status = ds1.Tables(0).Rows(0)("Status")
                        Select Case status

                            Case "INFORCE"
                                MsgBox("We are sorry, we unable to procced this proposal. Its already Inforce!")
                                Return False
                            Case Else
                        End Select
                    End If
                End If
            End If
        Else
            If Me.lblForm_Flag.Text.Trim = "N" Then
                Dim cmdSearch_DuplicateProposal As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSearch_DuplicateProposal.CommandType = CommandType.Text

                Dim ds_Search As New DataSet
                cmdSearch_DuplicateProposal.CommandText = "SELECT IC_New, Plan_Code, Level2_Plan_Code FROM vi_Proposer_with_AgentInfo " & _
                                                          "WHERE IC_New = '" & Me.txtProposer_NRIC.Text.Trim & "' AND " & _
                                                          "Plan_Code = '" & Me.txtProposer_Plan_Code.Text.Trim & "' AND " & _
                                                          "Level2_Plan_Code = '" & Me.txtProposer_L2_Plan_Code.Text.Trim & "' AND STATUS='2'"

                Dim da_DuplicateProposer As New SqlDataAdapter(cmdSearch_DuplicateProposal)

                da_DuplicateProposer.Fill(ds_Search, "vi_Proposer_with_AgentInfo")

                With ds_Search.Tables("vi_Proposer_with_AgentInfo")
                    If .Rows.Count > 0 Then
                        MsgBox("This proposal already sign-up the " & .Rows(0).Item("Plan_Code").ToString.Trim & " - " & _
                                                                      .Rows(0).Item("Level2_Plan_Code").ToString.Trim & ".")
                        Return False
                    End If
                End With
            End If
        End If


        Return True
    End Function
    Private Function GetValues() As Boolean
        Dim ds As New DataSet
        Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where dt_member.ic_new='" & Me.txtProposer_NRIC.Text.Trim & "') and Status in('Retired','Lapse','Cancelled','User request to cancel')"
        sqlCmd.CommandType = CommandType.Text
        Dim adp As New SqlDataAdapter(sqlCmd)
        adp.Fill(ds, "dt_member_policy")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function vDepSAge() As Boolean
        Dim sPCode, Relation As String
        Dim sAge As Integer
        sPCode = Me.txtProposer_Plan_Code.Text.Trim().Substring(0, 11).ToString.Trim
        If sPCode = "CUEPACSCARE" Then
            Dim iRCount As Integer = 0
            If Me.dgvDependents.Rows.Count > 0 Then
                Do While iRCount < Me.dgvDependents.Rows.Count
                    Relation = Me.dgvDependents.Rows(iRCount).Cells(9).Value.ToString.Trim
                    If Relation = "Spouse" Then
                        sAge = Math.Floor(DateDiff(DateInterval.Day, Me.dgvDependents.Rows(iRCount).Cells(2).Value, Now()) / 365.25)
                        If sAge > 60 Then
                            MsgBox("We are sorry! We canot proceses this proposal, Due to Over aged Spouse!Please remove it for further action for this product!")
                            Return False
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                    iRCount += 1
                Loop
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Private Function vD1E32() As Boolean
        If (Me.txtProposer_L2_Plan_Code.Text = "EMPLOYEE AND FAMILY ONLY" Or Me.txtProposer_L2_Plan_Code.Text.Trim() = "FAMILY") Then
            MsgBox("This proposer have one dependent with Exclusion Clause E32, Please change the plan code to processed further!")
            Return True
        End If
        If Me.dgvDependents.RowCount > 0 Then
            MsgBox("This proposer have one dependent with Exclusion Clause E32, Please delete dependent to processed further!")
            Return True
        End If
        Return False
    End Function
    Private Sub PrintEnable()
        Me.chkProceed2Verification.Visible = False
        Me.btnSave.Visible = False
        Me.btnCancel.Visible = False
        If lblVerficationCheck.Text = "VPRINT" Then
            Me.FlowLayoutPanel1.Visible = True
        Else
            Me.FlowLayoutPanel1.Visible = False
        End If
        Me.GrpBox_ActionAfter_Verification.Visible = True
        Select Case Me.lblProposer_Status.Text
            Case "1A"
                If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
                    Me.btnYearlyLetter.Enabled = True
                Else
                    Me.btnPrint_AcknowledgementLetter.Enabled = True
                End If
                Dim aCode As String()
                aCode = Me.txtProposer_Plan_Code.Text.ToString().Trim().Split("-")
                Dim pCode As String
                pCode = aCode(1).Substring(0, 1)
                If pCode = "Y" Then
                    Me.btnYearlyLetter.Enabled = True
                    Me.btnPrint_AcknowledgementLetter.Enabled = False
                Else
                    Me.btnYearlyLetter.Enabled = False
                    Me.btnPrint_AcknowledgementLetter.Enabled = True
                End If
            Case "1D"
                Me.btnPrint_DefermentLetter.Enabled = True
            Case "1R"
                Me.btnPrint_RejectLetter.Enabled = True
            Case "1U", "1PU"
                Me.btnPrint_UnderwritingLetter.Enabled = True
        End Select
    End Sub
    Private Function getFileNo(ByVal var_Plan_Code As String) As String
        Dim p As String()
        p = var_Plan_Code.Split("-")

        Dim cmdSelect_Plan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Plan.CommandType = CommandType.Text
        cmdSelect_Plan.CommandText = "SELECT Product_Code, File_Prefix, Last_FileNo " & _
                                     "FROM tb_FileNo " & _
                                     "WHERE Product_Code='" & p(0) & "'"

        Dim da As New SqlDataAdapter(cmdSelect_Plan)

        Dim cmdUpdate_Plan As SqlCommandBuilder
        cmdUpdate_Plan = New SqlCommandBuilder(da)


        Dim ds As New DataSet


        da.Fill(ds, "tb_FileNo")

        Dim var_New_Angkasa_FileNo As String = ""

        If ds.Tables("tb_FileNo").Rows.Count = 1 Then
            With ds.Tables("tb_FileNo").Rows(0)
                If IsDBNull(.Item("File_Prefix")) = True Then
                    var_New_Angkasa_FileNo = Str(.Item("Last_FileNo") + 1).Trim
                    .Item("Last_FileNo") = var_New_Angkasa_FileNo
                    da.Update(ds, "tb_FileNo")
                Else
                    var_New_Angkasa_FileNo = .Item("File_Prefix").ToString.Trim & Str(.Item("Last_FileNo") + 1).Trim
                    .Item("Last_FileNo") = .Item("Last_FileNo") + 1
                    da.Update(ds, "tb_FileNo")
                End If
            End With
        End If
        Return var_New_Angkasa_FileNo
    End Function
    Private Function Permit_To_Save() As Boolean
        If txtProposer_Plan_Code.Text.Trim() = "Could not retrieve data off the clipboard." Then
            MsgBox("Could not retrive data of product, Please check it!")
            Return False
        End If
        If Me.chkDataEntry_CheckList_Proposer_Details.Checked = False Then
            MsgBox("Please do fill-in the Proposer's Personal details.", MsgBoxStyle.Information, "Incomplete New Proposer's Application Form")
            Me.TabControl1.SelectedIndex = 0
            Return False
        End If

        If Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked = False Then
            MsgBox("Please do fill-in the Insurance Proposed details.", MsgBoxStyle.Information, "Incomplete New Proposer's Application Form")
            Me.TabControl1.SelectedIndex = 2
            Return False
        End If

        If Me.chkDocumentation_CheckList_Proposer_Form.Checked = True Then
            If Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = False Then
                If Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = False Then
                        If Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = False Then
                            MsgBox("Please do select the status of the Borang Permohonan.", MsgBoxStyle.Information, "Incomplete New Proposer's Application Form")
                            Return False
                        End If
                    End If
                End If
            End If
        End If

        If Me.chkDocumentation_CheckList_Payslip.Enabled = True Then
            If Me.chkDocumentation_CheckList_Payslip.Checked = True Then
                If Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = False Then
                        MsgBox("Please do select the status of the Salinan Slip Gaji.", MsgBoxStyle.Information, "Incomplete New Proposer's Application Form")
                        Return False
                    End If
                End If
            End If
        End If

        If Me.chkDocumentation_CheckList_Borang1_79.Enabled = True Then
            If Me.chkDocumentation_CheckList_Borang1_79.Checked = True Then
                If Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = False Then
                    If Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = False Then
                        If Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = False Then
                            If Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = False Then
                                If Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = False Then
                                    MsgBox("Please do select the status of the Borang 1/79 (Angkasa).", MsgBoxStyle.Information, "Incomplete New Proposer's Application Form")
                                    Return False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return True
    End Function
    Private Function Verify_Nominee_Details() As Boolean
        If Len(Me.txtNominee_Title.Text.Trim) = 0 Then
            MsgBox("Please do select Nominee's Title.")
            Me.btnNominee_Title.Focus()
            Return False
        End If

        If Len(Me.txtNominee_Name.Text.Trim) = 0 Then
            MsgBox("Please do key in Nominee's Name.")
            Me.txtNominee_Name.Focus()
            Return False
        End If

        If Me.dtpNominee_DOB.Value.Date = Today() Then
            MsgBox("Please do select Nominee's Date of Birth.")
            Me.dtpNominee_DOB.Focus()
            Return False
        End If

        If Len(Me.txtNominee_NRIC.Text.Trim) = 0 Then
            MsgBox("Please do key in Nominee's New I/C No.")
            Me.txtNominee_NRIC.Focus()
            Return False
        End If

        If Len(Me.txtNAdd1.Text.Trim) = 0 Then
            MsgBox("Please do key in postal address.")
            Me.txtNAdd1.Focus()
            Return False
        End If
        If Len(Me.txtNTown.Text.Trim) = 0 Then
            MsgBox("Please do key in town.")
            Me.txtNTown.Focus()
            Return False
        End If
        If Len(Me.txtNState.Text.Trim) = 0 Then
            MsgBox("Please do key in state.")
            Me.txtNState.Focus()
            Return False
        End If

        If Len(Me.txtNPoscode.Text.Trim) = 0 Then
            MsgBox("Please do key in poscode.")
            Me.txtNPoscode.Focus()
            Return False
        End If
        If Len(Me.txtNominee_SharePercentage.Text.Trim) = 0 Then
            MsgBox("Please do key in share percentage")
            Me.txtNominee_SharePercentage.Focus()
            Return False
        End If
        If Not Me.cbNominee_Relationship.SelectedIndex > -1 Then
            MsgBox("Please do key in Nominee's Relationship with Proposer.")
            Me.cbNominee_Relationship.Focus()
            Return False
        End If

        If Me.dgvNominees.Rows.Count > 0 Then
            With Me.dgvNominees
                Dim dgvNCount As Integer = 0
                Dim TotShare As Decimal = 0
                TotShare = Val(Me.txtNominee_SharePercentage.Text.Trim)
                Do While dgvNCount < Me.dgvNominees.Rows.Count
                    With Me.dgvNominees
                        Dim s As String
                        s = Val(.Rows(dgvNCount).Cells(12).Value)
                        TotShare += Val(.Rows(dgvNCount).Cells(12).Value)
                    End With
                    dgvNCount += 1
                Loop
                If TotShare > 100 Then
                    MsgBox("Invalid share % for Nomination!Please check it")
                    Me.txtNominee_SharePercentage.Focus()
                    Return False
                End If
            End With
        ElseIf Val(Me.txtNominee_SharePercentage.Text.Trim) > 100 Then
            MsgBox("Invalid share % for Nomination!Please check it")
            Me.txtNominee_SharePercentage.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Insert"
    Private Sub Save_Proposer_ApplicationForm_New()

        Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_New.CommandType = CommandType.Text
        cmdSelect_Proposer_New.CommandText = "SELECT * FROM dt_Proposer"

        Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

        Dim cmdInsert_Proposer_New As SqlCommandBuilder
        cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


        Dim cmdSelect_Proposer_Dependent_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_Dependent_New.CommandType = CommandType.Text
        cmdSelect_Proposer_Dependent_New.CommandText = "SELECT * FROM dt_Proposer_Dependents"

        Dim da_Proposer_Dependent_New As New SqlDataAdapter(cmdSelect_Proposer_Dependent_New)

        Dim cmdInsert_Proposer_Dependent_New As SqlCommandBuilder
        cmdInsert_Proposer_Dependent_New = New SqlCommandBuilder(da_Proposer_Dependent_New)


        Dim cmdSelect_Proposer_Agent_Commission_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_Agent_Commission_New.CommandType = CommandType.Text
        cmdSelect_Proposer_Agent_Commission_New.CommandText = "SELECT * FROM dt_Proposer_Agent_Commission"

        Dim da_Proposer_Agent_Commission_New As New SqlDataAdapter(cmdSelect_Proposer_Agent_Commission_New)

        Dim cmdInsert_Proposer_Agent_Commission_New As SqlCommandBuilder
        cmdInsert_Proposer_Agent_Commission_New = New SqlCommandBuilder(da_Proposer_Agent_Commission_New)


        Dim cmdSelect_Proposer_Angkasa_Deduction_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_Angkasa_Deduction_New.CommandType = CommandType.Text
        cmdSelect_Proposer_Angkasa_Deduction_New.CommandText = "SELECT * FROM dt_Proposer_Angkasa_Deduction"

        Dim da_Proposer_Angkasa_Deduction_New As New SqlDataAdapter(cmdSelect_Proposer_Angkasa_Deduction_New)

        Dim cmdInsert_Proposer_Angkasa_Deduction_New As SqlCommandBuilder
        cmdInsert_Proposer_Angkasa_Deduction_New = New SqlCommandBuilder(da_Proposer_Angkasa_Deduction_New)


        Dim cmdSelect_Proposer_Nomination_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_Nomination_New.CommandType = CommandType.Text
        cmdSelect_Proposer_Nomination_New.CommandText = "SELECT * FROM dt_Proposer_Nomination"

        Dim da_Proposer_Nomination_New As New SqlDataAdapter(cmdSelect_Proposer_Nomination_New)

        Dim cmdInsert_Proposer_Nomination_New As SqlCommandBuilder
        cmdInsert_Proposer_Nomination_New = New SqlCommandBuilder(da_Proposer_Nomination_New)


        Dim cmdSelect_Proposer_ExclusionClause_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_ExclusionClause_New.CommandType = CommandType.Text
        cmdSelect_Proposer_ExclusionClause_New.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause"

        Dim da_Proposer_ExclusionClause_New As New SqlDataAdapter(cmdSelect_Proposer_ExclusionClause_New)

        Dim cmdInsert_Proposer_ExclusionClause_New As SqlCommandBuilder
        cmdInsert_Proposer_ExclusionClause_New = New SqlCommandBuilder(da_Proposer_ExclusionClause_New)


        Dim ds_Proposer As New DataSet


        da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")
        da_Proposer_Dependent_New.Fill(ds_Proposer, "dt_Proposer_Dependents")
        da_Proposer_Agent_Commission_New.Fill(ds_Proposer, "dt_Proposer_Agent_Commission")
        da_Proposer_Angkasa_Deduction_New.Fill(ds_Proposer, "dt_Proposer_Angkasa_Deduction")
        da_Proposer_ExclusionClause_New.Fill(ds_Proposer, "dt_Proposer_Exclusion_Clause")
        da_Proposer_Nomination_New.Fill(ds_Proposer, "dt_Proposer_Nomination")

        Dim dr_Proposer_New As DataRow
        Dim dr_Proposer_Dependent_New As DataRow
        Dim dr_Proposer_Agent_Commission_New As DataRow
        Dim dr_Proposer_Angkasa_Deduction_New As DataRow
        Dim dr_Proposer_Nomination_New As DataRow
        Dim dr_Proposer_ExclusionClause_New As DataRow
        Dim var_Proposer_ID As String
        Dim var_Proposer_Dependent_ID As String
        Dim var_Proposer_Agent_Commission_ID As String
        Dim var_Proposer_Angkasa_Deduction_ID As String
        Dim var_Proposer_Nomination_ID As String
        Dim var_Proposer_ExclusionClause_ID As String

        Try
            
            dr_Proposer_New = ds_Proposer.Tables("dt_Proposer").NewRow


            If PID.Trim() = "" Then
                var_Proposer_ID = Guid.NewGuid.ToString
            Else
                var_Proposer_ID = PID
            End If
            sProposerID = var_Proposer_ID
            With dr_Proposer_New
                .Item("ID") = var_Proposer_ID
                .Item("Title") = Me.txtProposer_Title.Text.Trim
                .Item("Full_Name") = Me.txtProposer_Name.Text.Trim
                .Item("Birth_Date") = Me.dtpProposer_DOB.Value
                .Item("IC_New") = Me.txtProposer_NRIC.Text.Trim
                .Item("IC_Old") = Me.txtProposer_OldIC.Text.Trim
                .Item("ArmForce_ID") = Me.txtProposer_ArmForceID.Text.Trim

                If Me.rdiProposer_Race_Malay.Checked = True Then
                    .Item("Race") = "M"
                ElseIf Me.rdiProposer_Race_Chinese.Checked = True Then
                    .Item("Race") = "C"
                ElseIf Me.rdiProposer_Race_Indian.Checked = True Then
                    .Item("Race") = "I"
                ElseIf Me.rdiProposer_Race_Others.Checked = True Then
                    .Item("Race") = "O"
                End If

                If Me.rdiProposer_MaritalStatus_Single.Checked = True Then
                    .Item("Marital_Status") = "S"
                ElseIf Me.rdiProposer_MaritalStatus_Married.Checked = True Then
                    .Item("Marital_Status") = "M"
                ElseIf Me.rdiProposer_MaritalStatus_Widowed.Checked = True Then
                    .Item("Marital_Status") = "W"
                ElseIf Me.rdiProposer_MaritalStatus_Divorced.Checked = True Then
                    .Item("Marital_Status") = "D"
                End If

                If Me.rdiProposer_Sex_Male.Checked = True Then
                    .Item("Sex") = 1
                ElseIf Me.rdiProposer_Sex_Female.Checked = True Then
                    .Item("Sex") = 0
                End If

                .Item("Proposal_Received_Date") = Me.dtpProposal_Received_Date.Value

                .Item("Proposal_Signed_Date") = Me.dtpDateofSigned.Value

                .Item("Postal_Address_L1") = Me.txtProposer_AddressL1.Text.Trim
                .Item("Postal_Address_L2") = Me.txtProposer_AddressL2.Text.Trim
                .Item("Add3") = Me.txtProposerAdd3.Text.Trim
                .Item("Add4") = Me.txtProposerAdd4.Text.Trim
                .Item("Town") = Me.txtProposer_City.Text.Trim
                .Item("Postcode") = Me.txtProposer_Postcode.Text.Trim
                .Item("State") = Me.txtProposer_State.Text.Trim
                .Item("Bank_Name") = Me.cbBankName.Text.Trim
                .Item("Bank_Ac") = Me.txtBankAc.Text.Trim
                .Item("Phone_Hse") = Me.txtProposer_Phone_Hse.Text.Trim
                .Item("Phone_Mobile") = Me.txtProposer_Mobile.Text.Trim
                .Item("Phone_Off") = Me.txtProposer_Phone_Ofc.Text.Trim
                .Item("Email") = Me.txtProposer_Email.Text.Trim
                .Item("Height") = Me.txtProposer_Height.Text.Trim
                .Item("Weight") = Me.txtProposer_Weight.Text.Trim
                .Item("Occupation") = Me.txtProposer_Occupation.Text.Trim
                .Item("Department") = Me.txtProposer_Department.Text.Trim
                .Item("Plan_Code") = Me.txtProposer_Plan_Code.Text.Trim
                .Item("Level2_Plan_Code") = Me.txtProposer_L2_Plan_Code.Text.Trim
                .Item("Premium") = Me.txtProposer_Plan_Premium.Text
                .Item("Special_Promo") = Me.chkProposer_Plan_SpecialPromo.Checked

                If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
                    .Item("Payment_Frequency") = "Y"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.Checked = True Then
                    .Item("Payment_Frequency") = "H"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_Quarterly.Checked = True Then
                    .Item("Payment_Frequency") = "Q"
                ElseIf Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = True Then
                    .Item("Payment_Frequency") = "M"
                End If

                .Item("Payment_Method") = Me.txtProposer_Plan_Payment_Method.Text.Trim
                .Item("Payment_Method_CreditCard_Batch_No") = Me.txtProposer_Plan_Payment_CreditCard_Batch_No.Text.Trim
                .Item("Payment_Method_CreditCard_Appr_Code") = Me.txtProposer_Plan_Payment_CreditCard_Appr_Code.Text.Trim
                .Item("Payment_Method_CreditCard_Invoice_No") = Me.txtProposer_Plan_Payment_CreditCard_Invoice_No.Text.Trim
                .Item("Payment_Method_Cheque_No") = Me.txtProposer_Plan_Payment_Cheque_No.Text.Trim
                .Item("Payment_Method_Cheque_Receipt_No") = Me.txtProposer_Plan_Payment_Cheque_Receipt_No.Text.Trim
                .Item("Payment_Method_Cash_Receipt_No") = Me.txtProposer_Plan_Payment_Receipt_No.Text.Trim
                .Item("Payment_Method_Cash_Receipt_IssuedBy") = Me.txtProposer_Plan_Payment_Receipt_IssuedBy.Text.Trim
                .Item("Payment_Method_BiroAngkasa_Borang1_79_SN") = Me.txtBorang1_79_SN.Text.Trim
                .Item("DataEntry_Checklist_Proposer_Details") = Me.chkDataEntry_CheckList_Proposer_Details.Checked
                .Item("DataEntry_Checklist_Enrolled_Dependents") = Me.chkDataEntry_CheckList_Dependent_Details.Checked
                .Item("DataEntry_Checklist_Insurance_Proposed") = Me.chkDataEntry_CheckList_InsuranceProposed_Details.Checked
                .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = Me.chkDataEntry_CheckList_BiroAngkasa_Details.Checked
                .Item("DataEntry_Checklist_Nomination") = Me.chkDataEntry_CheckList_Nomination.Checked
                .Item("Document_Checklist_Application_Form") = Me.chkDocumentation_CheckList_Proposer_Form.Checked

                If Me.rdiDocumentation_CheckList_Proposer_Form_Complete.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Lengkap"
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Tidak Lengkap"
                    Dim sMsg As String = ""
                    If Me.cbTLBATarikh.Checked Then
                        sMsg = sMsg & "-Bahagian A (Tarikh Lahir)" & " ! "
                    End If
                    If Me.cbTLBANoTelefon.Checked Then
                        sMsg = sMsg & "-Bahagian A (No Telefon)" & " ! "
                    End If

                    If Me.cbTLBBNoKad.Checked Then
                        sMsg = sMsg & "-Bahagian B (No Kad Pengenalan Pasangan)" & " ! "
                    End If
                    If Me.cbTLBBNoSijil.Checked Then
                        sMsg = sMsg & "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)" & " ! "
                    End If
                    If Me.cbTLBBSurat.Checked Then
                        sMsg = sMsg & "-Bahagian B (Surat Pengambilan Anak Angkat)" & " ! "
                    End If
                    If Me.cbTLBBSertakan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Sertakan Sijil Kelahiran Anak)" & " ! "
                    End If
                    If Me.cbTLBBPasangan.Checked Then
                        sMsg = sMsg & "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)" & " ! "
                    End If
                    If Me.cbTLBCSOAL.Checked Then
                        sMsg = sMsg & "-Bahagian C (Soal Selidik)" & " ! "
                    End If
                    If Me.cbTLBD.Checked Then
                        sMsg = sMsg & "-Bahagian D & E (Tandatangan Pemohon)" & " ! "
                    End If
                    If Me.cbTLJenis.Checked Then
                        sMsg = sMsg & "-Jenis Pilihan Pelan" & " ! "
                    End If
                    If Me.cbTLBP.Checked Then
                        sMsg = sMsg & "-Bahagian Penamaan" & " ! "
                    End If
                    If Me.chkBPTP.Checked Then
                        sMsg = sMsg & "-Bahagian Pengisytiharan (Tandatangan Pemohon)" & " ! "
                    End If
                    If Me.chkSDTS.Checked Then
                        sMsg = sMsg & "-Seksyen D (Tandatangan Saksi)" & " ! "
                    End If
                    If Me.chkSDTP.Checked Then
                        sMsg = sMsg & "-Seksyen D (Tandatangan Pemilik)" & " ! "
                    End If
                    .Item("DCAF_Status") = sMsg
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_OldForm.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Borang Lama"
                ElseIf Me.rdiDocumentation_CheckList_Proposer_Form_BorangSalah.Checked = True Then
                    .Item("Document_Checklist_Application_Form_Status") = "Borang Salah"
                End If

                .Item("Document_Checklist_IC") = Me.chkDocumentation_CheckList_IC.Checked
                .Item("Document_Checklist_Penyata") = Me.chkDocumentation_CheckList_PG.Checked
                If Me.rbPG6BTJ.Checked = True Then
                    .Item("Document_Checklist_Penyata_Status") = "Tidak"
                ElseIf Me.rbPG6BJ.Checked = True Then
                    .Item("Document_Checklist_Penyata_Status") = "Ya"
                End If
                .Item("Document_Checklist_Payslip") = Me.chkDocumentation_CheckList_Payslip.Checked
                If Me.rdiDocumentation_CheckList_Payslip_Clear.Checked = True Then
                    .Item("Document_Checklist_Payslip_Status") = "Jelas"
                ElseIf Me.rdiDocumentation_CheckList_Payslip_NotClear.Checked = True Then
                    .Item("Document_Checklist_Payslip_Status") = "Tidak Jelas"
                End If

                .Item("Document_Checklist_Borang1_79") = Me.chkDocumentation_CheckList_Borang1_79.Checked
                If Me.rdiDocumentation_CheckList_Borang1_79_Complete.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Lengkap dengan Maklumat Majikan dan Cop Majikan"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_Error.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Terdapat kesilapan mengisi Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_LiquidPaper.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Penggunaan 'liquid paper' pada Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_MuatTurunBorang.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Muat Turun Borang 1/79"
                ElseIf Me.rdiDocumentation_CheckList_Borang1_79_InComplete.Checked = True Then
                    .Item("Document_Checklist_Borang1_79_Status") = "Tidak Lengkap"
                    Dim sMsg1 As String = ""
                    If Me.cbTLTP.Checked Then
                        sMsg1 = sMsg1 & "Tandatangan Pemohon" & " ! "
                    End If
                    If Me.cbTLCM.Checked Then
                        sMsg1 = sMsg1 & "Cop Majikan" & " ! "
                    End If
                    If Me.cbTLTM.Checked Then
                        sMsg1 = sMsg1 & "Tandatangan Majikan" & " ! "
                    End If
                    .Item("DCB179_STATUS") = sMsg1
                End If
                If Me.lblRejectReason.Text = "PROPOSERSPOUSEEXISTS" Then
                    .Item("Status") = Me.lblProposer_Status.Text.ToString.Trim()
                Else
                    .Item("Status") = "0"
                End If
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
                Me.TextBox1.Text = getFileNo(Me.txtProposer_Plan_Code.Text.Trim)
                .Item("Angkasa_FileNo") = Me.TextBox1.Text.Trim
                .Item("New") = "New"
                If Me.rbUWCIMBYes.Checked Then
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("CIMB_UW_STATUS") = "YES"
                Else
                    ds_Proposer.Tables("dt_Proposer").Rows(0).Item("CIMB_UW_STATUS") = "NO"
                End If
                ds_Proposer.Tables("dt_Proposer").Rows.Add(dr_Proposer_New)
                da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
            End With


            If Me.dgvDependents.Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < Me.dgvDependents.Rows.Count

                    dr_Proposer_Dependent_New = ds_Proposer.Tables("dt_Proposer_Dependents").NewRow

                    var_Proposer_Dependent_ID = Guid.NewGuid.ToString

                    With dr_Proposer_Dependent_New
                        .Item("ID") = var_Proposer_Dependent_ID
                        .Item("Proposer_ID") = var_Proposer_ID
                        .Item("Title") = Me.dgvDependents.Rows(var_grid_counter).Cells(0).Value.ToString.Trim
                        .Item("Full_Name") = Me.dgvDependents.Rows(var_grid_counter).Cells(1).Value.ToString.Trim
                        .Item("Birth_Date") = Me.dgvDependents.Rows(var_grid_counter).Cells(2).Value
                        .Item("IC_New") = Me.dgvDependents.Rows(var_grid_counter).Cells(4).Value.ToString.Trim
                        .Item("IC_Old") = Me.dgvDependents.Rows(var_grid_counter).Cells(5).Value.ToString.Trim
                        .Item("ArmForce_ID") = Me.dgvDependents.Rows(var_grid_counter).Cells(6).Value.ToString.Trim
                        .Item("Race") = Me.dgvDependents.Rows(var_grid_counter).Cells(7).Value.ToString.Trim
                        .Item("Marital_Status") = Me.dgvDependents.Rows(var_grid_counter).Cells(8).Value.ToString.Trim
                        .Item("Relationship") = Me.dgvDependents.Rows(var_grid_counter).Cells(9).Value.ToString.Trim
                        .Item("Sex") = Me.dgvDependents.Rows(var_grid_counter).Cells(10).Value
                        .Item("Height") = Me.dgvDependents.Rows(var_grid_counter).Cells(11).Value
                        .Item("Weight") = Me.dgvDependents.Rows(var_grid_counter).Cells(12).Value
                        .Item("Occupation") = Me.dgvDependents.Rows(var_grid_counter).Cells(13).Value.ToString.Trim
                        .Item("Department") = Me.dgvDependents.Rows(var_grid_counter).Cells(14).Value.ToString.Trim
                        .Item("KeyInOrder") = Me.dgvDependents.Rows(var_grid_counter).Cells(16).Value.ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Last_Modified_By") = My.Settings.Username.Trim
                        .Item("Last_Modified_On") = Now()

                        ds_Proposer.Tables("dt_Proposer_Dependents").Rows.Add(dr_Proposer_Dependent_New)
                        da_Proposer_Dependent_New.Update(ds_Proposer, "dt_Proposer_Dependents")
                    End With
                    var_grid_counter += 1
                Loop
            End If


            If Me.dgvAgents.Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < Me.dgvAgents.Rows.Count

                    dr_Proposer_Agent_Commission_New = ds_Proposer.Tables("dt_Proposer_Agent_Commission").NewRow

                    var_Proposer_Agent_Commission_ID = Guid.NewGuid.ToString

                    With dr_Proposer_Agent_Commission_New
                        .Item("ID") = var_Proposer_Agent_Commission_ID
                        .Item("Proposer_ID") = var_Proposer_ID
                        .Item("Agent_Code") = Me.dgvAgents.Rows(var_grid_counter).Cells(0).Value.ToString.Trim
                        .Item("Agent_Level") = Me.dgvAgents.Rows(var_grid_counter).Cells(1).Value.ToString.Trim
                        .Item("Agent_Share_Percentage") = Me.dgvAgents.Rows(var_grid_counter).Cells(2).Value
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Last_Modified_By") = My.Settings.Username.Trim
                        .Item("Last_Modified_On") = Now()

                        ds_Proposer.Tables("dt_Proposer_Agent_Commission").Rows.Add(dr_Proposer_Agent_Commission_New)
                        da_Proposer_Agent_Commission_New.Update(ds_Proposer, "dt_Proposer_Agent_Commission")
                    End With
                    var_grid_counter += 1
                Loop
            End If


            If Me.dgvNominees.Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < Me.dgvNominees.Rows.Count

                    dr_Proposer_Nomination_New = ds_Proposer.Tables("dt_Proposer_Nomination").NewRow

                    var_Proposer_Nomination_ID = Guid.NewGuid.ToString

                    With dr_Proposer_Nomination_New
                        .Item("ID") = var_Proposer_Nomination_ID
                        .Item("Proposer_ID") = var_Proposer_ID
                        .Item("Title") = Me.dgvNominees.Rows(var_grid_counter).Cells(0).Value.ToString.Trim
                        .Item("Full_Name") = Me.dgvNominees.Rows(var_grid_counter).Cells(1).Value.ToString.Trim
                        .Item("Birth_Date") = Me.dgvNominees.Rows(var_grid_counter).Cells(2).Value
                        .Item("IC_New") = Me.dgvNominees.Rows(var_grid_counter).Cells(3).Value.ToString.Trim
                        .Item("Relationship") = Me.dgvNominees.Rows(var_grid_counter).Cells(4).Value.ToString.Trim
                        .Item("Add1") = Me.dgvNominees.Rows(var_grid_counter).Cells(5).Value.ToString.Trim
                        .Item("Add2") = Me.dgvNominees.Rows(var_grid_counter).Cells(6).Value.ToString.Trim
                        .Item("Add3") = Me.dgvNominees.Rows(var_grid_counter).Cells(7).Value.ToString.Trim
                        .Item("Add4") = Me.dgvNominees.Rows(var_grid_counter).Cells(8).Value.ToString.Trim
                        .Item("Town") = Me.dgvNominees.Rows(var_grid_counter).Cells(9).Value.ToString.Trim
                        .Item("State") = Me.dgvNominees.Rows(var_grid_counter).Cells(10).Value.ToString.Trim
                        .Item("Poscode") = Me.dgvNominees.Rows(var_grid_counter).Cells(11).Value.ToString.Trim
                        .Item("Share") = Me.dgvNominees.Rows(var_grid_counter).Cells(12).Value

                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Last_Modified_By") = My.Settings.Username.Trim
                        .Item("Last_Modified_On") = Now()

                        ds_Proposer.Tables("dt_Proposer_Nomination").Rows.Add(dr_Proposer_Nomination_New)
                        da_Proposer_Nomination_New.Update(ds_Proposer, "dt_Proposer_Nomination")
                    End With
                    var_grid_counter += 1
                Loop
            End If


            If Me.dgvExclusion_Clause.Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < Me.dgvExclusion_Clause.Rows.Count

                    dr_Proposer_ExclusionClause_New = ds_Proposer.Tables("dt_Proposer_Exclusion_Clause").NewRow

                    var_Proposer_ExclusionClause_ID = Guid.NewGuid.ToString

                    With dr_Proposer_ExclusionClause_New
                        .Item("ID") = var_Proposer_ExclusionClause_ID
                        .Item("Proposer_ID") = var_Proposer_ID
                        .Item("ExclusionClause_Code") = Me.dgvExclusion_Clause.Rows(var_grid_counter).Cells(0).Value.ToString.Trim
                        .Item("ExclusionClause_Description") = Me.dgvExclusion_Clause.Rows(var_grid_counter).Cells(1).Value.ToString.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Last_Modified_By") = My.Settings.Username.Trim
                        .Item("Last_Modified_On") = Now()

                        ds_Proposer.Tables("dt_Proposer_Exclusion_Clause").Rows.Add(dr_Proposer_ExclusionClause_New)
                        da_Proposer_ExclusionClause_New.Update(ds_Proposer, "dt_Proposer_Exclusion_Clause")
                    End With
                    var_grid_counter += 1
                Loop
            End If

            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()

            MsgBox("Record Saved!")

            Me.Label1.Visible = True
            Me.TextBox1.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
    Private Sub Reset_Enrolled_Dependents_Tab_Value()

        Me.txtDependent_Title.Clear()
        Me.txtDependent_FirstName.Clear()
        Me.dtpDependent_DOB.Value = Now()
        Me.txtDependent_NRIC.Clear()
        Me.txtDependent_OldIC.Clear()
        Me.txtDependent_ArmForceID.Clear()
        Me.rdiDependent_Race_Malay.Checked = False
        Me.rdiDependent_Race_Chinese.Checked = False
        Me.rdiDependent_Race_Indian.Checked = False
        Me.rdiDependent_Race_Others.Checked = False
        Me.rdiDependent_MaritalStatus_Single.Checked = False
        Me.rdiDependent_MaritalStatus_Married.Checked = False
        Me.rdiDependent_MaritalStatus_Widowed.Checked = False
        Me.rdiDependent_MaritalStatus_Divorced.Checked = False
        Me.cmbDependent_Relationship.SelectedIndex = -1
        Me.rdiDependent_Sex_Male.Checked = False
        Me.rdiDependent_Sex_Female.Checked = False
        Me.txtDependent_Height.Clear()
        Me.txtDependent_Weight.Clear()
        Me.txtDependent_Occupation.Clear()
        Me.txtDependent_Department.Clear()
    End Sub
    Private Sub Populate_dgvDependents()
        Try
            If Me.dgvDependents.Rows.Count > 0 Then
                Me.dgvDependents.Rows.Clear()
            End If


            Dim cmdSelect_Proposer_Dependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Dependent.CommandType = CommandType.Text
            cmdSelect_Proposer_Dependent.CommandText = "SELECT * FROM dt_Proposer_Dependents " & _
                                                       "WHERE Proposer_ID = '" & Me.lblProposer_ID.Text.Trim & "' order by KeyInOrder "


            Dim ds_Proposer4Verify As New DataSet
            Dim da_Proposer_Dependent As New SqlDataAdapter(cmdSelect_Proposer_Dependent)
            da_Proposer_Dependent.Fill(ds_Proposer4Verify, "dt_Proposer_Dependents")


            If ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows.Count
                    With Me.dgvDependents
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Title").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Full_Name").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(2).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Birth_Date")
                        .Rows(.Rows.Count - 1).Cells(3).Value = Math.Floor(DateDiff(DateInterval.Day, ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Birth_Date"), Now()) / 365.25)
                        .Rows(.Rows.Count - 1).Cells(4).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("IC_New").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(5).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("IC_Old").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(6).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("ArmForce_ID").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(7).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Race").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(8).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Marital_Status").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(9).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Relationship").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(10).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Sex")
                        .Rows(.Rows.Count - 1).Cells(11).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Height").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(12).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Weight").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(13).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Occupation").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(14).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("Department").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(15).Value = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("ID").ToString.Trim
                    End With
                    If Not IsDBNull(ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("KeyInOrder")) Then
                        iKIO = ds_Proposer4Verify.Tables("dt_Proposer_Dependents").Rows(var_grid_counter).Item("KeyInOrder")
                        iKIO += 1
                    End If
                    var_grid_counter += 1
                Loop
                Me.dgvDependents.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDependents.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Reset_Insurance_Proposed_Tab_Agent_Value()

        Me.txtProposer_Plan_Commission_AgentCode.Clear()
        Me.txtProposer_Plan_Commission_Agent_SharePercentage.Clear()
    End Sub
    Private Sub Populate_dgvAgents()
        Try
            If Me.dgvAgents.Rows.Count > 0 Then
                Me.dgvAgents.Rows.Clear()
            End If


            Dim cmdSelect_Proposer_Agent_Commission As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Agent_Commission.CommandType = CommandType.Text
            cmdSelect_Proposer_Agent_Commission.CommandText = "SELECT * FROM dt_Proposer_Agent_Commission " & _
                                                              "WHERE Proposer_ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim ds_Proposer4Verify As New DataSet
            Dim da_Proposer_Agent_Commission As New SqlDataAdapter(cmdSelect_Proposer_Agent_Commission)
            da_Proposer_Agent_Commission.Fill(ds_Proposer4Verify, "dt_Proposer_Agent_Commission")


            If ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows.Count
                    With Me.dgvAgents
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows(var_grid_counter).Item("Agent_Code").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows(var_grid_counter).Item("Agent_Level").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(2).Value = ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows(var_grid_counter).Item("Agent_Share_Percentage").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(3).Value = ds_Proposer4Verify.Tables("dt_Proposer_Agent_Commission").Rows(var_grid_counter).Item("ID").ToString.Trim
                    End With
                    var_grid_counter += 1
                Loop
                Me.dgvAgents.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvAgents.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Reset_Nominee_Tab_Value()
        Me.txtNominee_Title.Clear()
        Me.txtNominee_Name.Clear()
        Me.dtpNominee_DOB.Value = Now()
        Me.txtNominee_NRIC.Clear()

        Me.cbNominee_Relationship.SelectedIndex = -1

        Me.txtNAdd1.Clear()
        Me.txtNAdd2.Clear()
        Me.txtNAdd3.Clear()
        Me.txtNAdd4.Clear()
        Me.txtNTown.Clear()
        Me.txtNState.Clear()
        Me.txtNPoscode.Clear()
        Me.txtNominee_SharePercentage.Clear()
    End Sub
    Private Sub Populate_dgvNominees()
        Try
            If Me.dgvNominees.Rows.Count > 0 Then
                Me.dgvNominees.Rows.Clear()
            End If


            Dim cmdSelect_Proposer_Nomination As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_Nomination.CommandType = CommandType.Text
            cmdSelect_Proposer_Nomination.CommandText = "SELECT * FROM dt_Proposer_Nomination " & _
                                                        "WHERE Proposer_ID = '" & Me.lblProposer_ID.Text.Trim & "' order by proposer_id, (case relationship when 'Spouse' then 1 when 'Children' then 2 else 3 end) asc"

            Dim ds_Proposer4Verify As New DataSet
            Dim da_Proposer_Nomination As New SqlDataAdapter(cmdSelect_Proposer_Nomination)
            da_Proposer_Nomination.Fill(ds_Proposer4Verify, "dt_Proposer_Nomination")


            If ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows.Count
                    With Me.dgvNominees
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Title").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Full_Name").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(2).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Birth_Date")
                        .Rows(.Rows.Count - 1).Cells(3).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("IC_New").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(4).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Relationship").ToString.Trim
                        If Not IsDBNull(ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add1")) Then
                            .Rows(.Rows.Count - 1).Cells(5).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add1").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(6).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add2").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(7).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add3").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(8).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add4").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(9).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Town").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(10).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("State").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(11).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("PosCode").ToString.Trim
                        Else
                            .Rows(.Rows.Count - 1).Cells(5).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Postal_Address").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(6).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add2").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(7).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add3").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(8).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Add4").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(9).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Town").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(10).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("State").ToString.Trim
                            .Rows(.Rows.Count - 1).Cells(11).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("PosCode").ToString.Trim
                        End If
                        .Rows(.Rows.Count - 1).Cells(12).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("Share").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(13).Value = ds_Proposer4Verify.Tables("dt_Proposer_Nomination").Rows(var_grid_counter).Item("ID").ToString.Trim
                    End With
                    var_grid_counter += 1
                Loop

                Me.dgvNominees.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvNominees.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmsExclusionClause_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExclusionClause_Edit.Click
        If Me.dgvExclusion_Clause.SelectedRows.Count = 1 Then

            Me.Lock_Underwriting_Tab(False)
            Me.btnExclusionClause_Add.Enabled = False
            Me.btnExclusionClause_Add.Visible = False
            Me.btnExclusionClause_Update.Enabled = True
            Me.btnExclusionClause_Update.Visible = True
            Me.btnExclusionClause_CancelUpdate.Enabled = True
            Me.btnExclusionClause_CancelUpdate.Visible = True
            Me.btnExclusionClause_CancelUpdate.Location = New Point(641, 112)


            With Me.dgvExclusion_Clause.SelectedRows(0)
                Me.txtUnderwriting_ExclusionClause_Code.Text = .Cells(0).Value.ToString.Trim
            
                Me.lblExclusionClause_ID.Text = .Cells(2).Value.ToString.Trim
                MsgBox("You would need to reselect the Apply To and rekey in Other Parameters.")
            End With
        Else
            MsgBox("Please do select the Exclusion Clause which you would like to edit.")
        End If
    End Sub
    Private Sub btnExclusionClause_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclusionClause_Update.Click
        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) = 0 Then
            Exit Sub
        Else
            If Me.txtUnderwriting_ExclusionClause_Code.Text.Trim = "E21" Then
                If Len(Me.txtUnderwriting_Other_Parameters.Text.Trim) = 0 Then
                    MsgBox("Please do key in the Other Parameters field")
                    Exit Sub
                End If
            End If
        End If
        If Len(Me.txtUnderwriting_ExclusionClause_Header.Text.Trim) = 0 Then
            MsgBox("Exclusion Clause not selected, Please select exclusion clause!")
            Exit Sub
        End If


        Dim cmdSelect_Proposer_ExclusionClause As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposer_ExclusionClause.CommandType = CommandType.Text
        cmdSelect_Proposer_ExclusionClause.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause " & _
                                                         "WHERE ID = '" & Me.lblExclusionClause_ID.Text.Trim & "'"

        Dim da_Proposer_ExclusionClause As New SqlDataAdapter(cmdSelect_Proposer_ExclusionClause)

        Dim cmdUpdate_Proposer_ExclusionClause As SqlCommandBuilder
        cmdUpdate_Proposer_ExclusionClause = New SqlCommandBuilder(da_Proposer_ExclusionClause)


        Dim ds_Proposer_ExclusionClause As New DataSet


        da_Proposer_ExclusionClause.Fill(ds_Proposer_ExclusionClause, "dt_Proposer_Exclusion_Clause")

        With ds_Proposer_ExclusionClause.Tables("dt_Proposer_Exclusion_Clause").Rows(0)
            .Item("ExclusionClause_Code") = Me.txtUnderwriting_ExclusionClause_Code.Text.Trim

            Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                Case "E21"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                               Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                               Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                               Me.txtProposer_Name.Text.Trim & " "
                    Else
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                    End If
                Case "E33"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                    Else
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                    End If
                Case Else
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtProposer_Name.Text.Trim
                    Else
                        .Item("ExclusionClause_Description") = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
            End Select

            .Item("Last_Modified_By") = My.Settings.Username.Trim
            .Item("Last_Modified_On") = Now()
        End With

        da_Proposer_ExclusionClause.Update(ds_Proposer_ExclusionClause, "dt_Proposer_Exclusion_Clause")
        MsgBox("Update done.")


        Me.Reset_Underwriting_Tab_Value()


        Me.Lock_Underwriting_Tab(True)
        Me.btnExclusionClause_Add.Visible = True
        Me.btnExclusionClause_Update.Enabled = False
        Me.btnExclusionClause_Update.Visible = False
        Me.btnExclusionClause_CancelUpdate.Enabled = False
        Me.btnExclusionClause_CancelUpdate.Visible = False


        Me.Populate_dgvExclusion_Clause()
    End Sub
    Private Sub btnExclusionClause_CancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclusionClause_CancelUpdate.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to cancel the update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel update on the Exclusion Clause")
        Select Case Result
            Case 6

                Me.Reset_Underwriting_Tab_Value()


                Me.Lock_Underwriting_Tab(True)
                Me.btnExclusionClause_Add.Visible = True
                Me.btnExclusionClause_Update.Enabled = False
                Me.btnExclusionClause_Update.Visible = False
                Me.btnExclusionClause_CancelUpdate.Enabled = False
                Me.btnExclusionClause_CancelUpdate.Visible = False
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub cmsExclusionClause_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExclusionClause_Add.Click

        Me.Reset_Underwriting_Tab_Value()


        Me.Lock_Underwriting_Tab(False)
        Me.btnExclusionClause_Add.Enabled = True
        Me.btnExclusionClause_Add.Visible = True
        Me.btnExclusionClause_Update.Enabled = False
        Me.btnExclusionClause_Update.Visible = False
        Me.btnExclusionClause_CancelUpdate.Enabled = False
        Me.btnExclusionClause_CancelUpdate.Visible = False
    End Sub
    Private Sub cmsExclusionClause_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExclusionClause_Delete.Click
        If Me.dgvExclusion_Clause.SelectedRows.Count = 1 Then
            Dim Result As Integer
            Result = MsgBox("Do you want to delete this Exclusion Clause?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete the Exclusion Clause")
            Select Case Result
                Case 6

                    Dim cmdSelect_Proposer_ExclusionClause As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_Proposer_ExclusionClause.CommandType = CommandType.Text
                    cmdSelect_Proposer_ExclusionClause.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause " & _
                                                                     "WHERE ID = '" & Me.dgvExclusion_Clause.SelectedRows(0).Cells(2).Value.ToString.Trim & "'"

                    Dim da_Proposer_ExclusionClause As New SqlDataAdapter(cmdSelect_Proposer_ExclusionClause)

                    Dim cmdUpdate_Proposer_ExclusionClause As SqlCommandBuilder
                    cmdUpdate_Proposer_ExclusionClause = New SqlCommandBuilder(da_Proposer_ExclusionClause)


                    Dim ds_Proposer_ExclusionClause As New DataSet


                    da_Proposer_ExclusionClause.Fill(ds_Proposer_ExclusionClause, "dt_Proposer_Exclusion_Clause")

                    If ds_Proposer_ExclusionClause.Tables("dt_Proposer_Exclusion_Clause").Rows.Count = 1 Then
                        ds_Proposer_ExclusionClause.Tables("dt_Proposer_Exclusion_Clause").Rows(0).Delete()

                        da_Proposer_ExclusionClause.Update(ds_Proposer_ExclusionClause, "dt_Proposer_Exclusion_Clause")
                        MsgBox("Record deleted.")


                        Me.Populate_dgvExclusion_Clause()
                    Else
                        MsgBox("More than 1 records found for this Exclusion Clause, please contact the system vendor.")
                    End If
                Case 7
                    Exit Sub
            End Select
        Else
            MsgBox("Please do select the Exclusion Clause which you would like to delete.")
        End If
    End Sub
    Private Sub Reset_Underwriting_Tab_Value()
        Me.txtUnderwriting_ExclusionClause_Code.Clear()
        Me.txtUnderwriting_ExclusionClause_Header.Clear()
        Me.txtUnderwriting_ExclusionClause_Footer.Clear()
        Me.chkUnderwriting_ApplyTo.Checked = False
        Me.txtUnderwriting_ApplyTo.Clear()
        Me.txtUnderwriting_Other_Parameters.Clear()
    End Sub
    Private Sub Populate_dgvExclusion_Clause()
        Try
            If Me.dgvExclusion_Clause.Rows.Count > 0 Then
                Me.dgvExclusion_Clause.Rows.Clear()
            End If


            Dim cmdSelect_Proposer_ExclusionClause As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_ExclusionClause.CommandType = CommandType.Text
            cmdSelect_Proposer_ExclusionClause.CommandText = "SELECT * FROM dt_Proposer_Exclusion_Clause " & _
                                                             "WHERE Proposer_ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim ds_Proposer4Verify As New DataSet
            Dim da_Proposer_ExclusionClause As New SqlDataAdapter(cmdSelect_Proposer_ExclusionClause)
            da_Proposer_ExclusionClause.Fill(ds_Proposer4Verify, "dt_Proposer_Exclusion_Clause")


            If ds_Proposer4Verify.Tables("dt_Proposer_Exclusion_Clause").Rows.Count > 0 Then
                Dim var_grid_counter As Integer = 0

                Do While var_grid_counter < ds_Proposer4Verify.Tables("dt_Proposer_Exclusion_Clause").Rows.Count
                    With Me.dgvExclusion_Clause
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = ds_Proposer4Verify.Tables("dt_Proposer_Exclusion_Clause").Rows(var_grid_counter).Item("ExclusionClause_Code").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(1).Value = ds_Proposer4Verify.Tables("dt_Proposer_Exclusion_Clause").Rows(var_grid_counter).Item("ExclusionClause_Description").ToString.Trim
                        .Rows(.Rows.Count - 1).Cells(2).Value = ds_Proposer4Verify.Tables("dt_Proposer_Exclusion_Clause").Rows(var_grid_counter).Item("ID").ToString.Trim
                    End With
                    var_grid_counter += 1
                Loop
                Me.dgvExclusion_Clause.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvExclusion_Clause.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub rdioYearlyLetter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdioYearlyLetter.CheckedChanged
        If Me.rdioYearlyLetter.Checked = True Then
            Me.btnPrint_DefermentLetter.Enabled = False
            Me.btnPrint_AcknowledgementLetter.Enabled = False
            Me.btnPrint_RejectLetter.Enabled = False
            Me.btnPrint_UnderwritingLetter.Enabled = False
            Me.btnYearlyLetter.Enabled = True
        End If
    End Sub

    Private Sub btnYearlyLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYearlyLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If
        If Me.lblProposer_Status.Text.Trim = "0" Then
            If Not My.Settings.Username = "Admin" Then
                If Me.dgvExclusion_Clause.Rows.Count > 0 Then
                    Dim iGCount As Integer = 0
                    Do While iGCount < Me.dgvExclusion_Clause.Rows.Count
                        If Me.dgvExclusion_Clause.Rows(iGCount).Cells(0).Value.ToString.Trim = "E31" Then
                            Dim dt As DataTable
                            dt = _objBusi.getDetails("EC", Me.lblProposer_ID.Text.Trim(), "", "", "", "E31", Conn)
                            If dt.Rows.Count = 1 Then
                                MsgBox("There is a EC E31 with one dependent, Please check it or check with you admin!")
                                Exit Sub
                            End If
                        End If
                        iGCount += 1
                    Loop
                End If
            End If

            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On, Statusaltered_on, Statusaltered_by FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1A"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If


        Dim rpt_YearlyLetter As New Yearly_PlanLetter_Proposer
        rpt_YearlyLetter.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim
        rpt_YearlyLetter.lblPlancode.Text = Me.txtProposer_Plan_Code.Text


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL1.Text.Trim

        If Len(Me.txtProposer_AddressL2.Text.Trim) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL2.Text.Trim
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_State.Text.Trim

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_YearlyLetter.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL4.Text = " "
            Case 4
                rpt_YearlyLetter.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select

        rpt_YearlyLetter.Show()
    End Sub
    Private Function EmailValidation(ByVal email As String) As Boolean
        If email <> "" Then
            Dim rex As Match = Regex.Match(Trim(email), "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3})$", RegexOptions.IgnoreCase)
            If rex.Success = False Then
                MessageBox.Show("Please Enter a valid Email Address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtProposer_Email.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnPayment_Method_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment_Method.Click
        Dim frmSearch_Payment_Method As New frmSearch_Param

        frmSearch_Payment_Method.lblForm_Flag.Text = "$"

        If Me.rdiProposer_Plan_Payment_Frequency_Yearly.Checked = True Then
            frmSearch_Payment_Method.lblPayment_Frequency.Text = "Yearly"
        ElseIf Me.rdiProposer_Plan_Payment_Frequency_HalfYearly.Checked = True Then
            frmSearch_Payment_Method.lblPayment_Frequency.Text = "HalfYearly"
        ElseIf Me.rdiProposer_Plan_Payment_Frequency_Quarterly.Checked = True Then
            frmSearch_Payment_Method.lblPayment_Frequency.Text = "Quarterly"
        ElseIf Me.rdiProposer_Plan_Payment_Frequency_Monthly.Checked = True Then
            frmSearch_Payment_Method.lblPayment_Frequency.Text = "Monthly"
        End If

        frmSearch_Payment_Method.ShowDialog()

        Me.txtProposer_Plan_Payment_Method.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()

        Select Case Me.txtProposer_Plan_Payment_Method.Text
            Case "Credit Card"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = True
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cheque"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = True
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cash"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = True
            Case Else
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
        End Select


        If Me.txtProposer_Plan_Payment_Method.Text = "Deduction via Biro Angkasa" Then
            Me.txtBorang1_79_SN.Enabled = True
        Else
            Me.txtBorang1_79_SN.Enabled = False

        End If


    End Sub
    Private Sub rdiDocumentation_CheckList_Proposer_Form_InComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiDocumentation_CheckList_Proposer_Form_InComplete.CheckedChanged
        If rdiDocumentation_CheckList_Proposer_Form_InComplete.Checked Then
            Me.flpBPTL.Visible = True

            Me.flpBPTL.Enabled = True
        Else
            Me.flpBPTL.Visible = False

            Me.flpBPTL.Enabled = False
        End If
    End Sub
    Private Sub rdiDocumentation_CheckList_Borang1_79_InComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiDocumentation_CheckList_Borang1_79_InComplete.CheckedChanged
        If rdiDocumentation_CheckList_Borang1_79_InComplete.Checked Then
            Me.flpBTL.Visible = True

            Me.flpBTL.Enabled = True
        Else
            Me.flpBTL.Visible = False

            Me.flpBTL.Enabled = False
        End If
    End Sub
    Private Sub cbAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAdd.CheckedChanged
        If Me.cbAdd.Checked Then
            Me.txtNState.ReadOnly = True
            Me.txtNPoscode.ReadOnly = True
            Me.txtNTown.ReadOnly = True
            Me.txtNAdd1.ReadOnly = True
            Me.txtNAdd2.ReadOnly = True
            Me.txtNAdd3.ReadOnly = True
            Me.txtNAdd4.ReadOnly = True
            Me.btnNState.Enabled = False
            Me.txtNState.Text = Me.txtProposer_State.Text.Trim()
            Me.txtNPoscode.Text = Me.txtProposer_Postcode.Text.Trim()
            Me.txtNTown.Text = Me.txtProposer_City.Text.Trim()
            Me.txtNAdd1.Text = Me.txtProposer_AddressL1.Text.Trim()
            Me.txtNAdd2.Text = Me.txtProposer_AddressL2.Text.Trim()
            Me.txtNAdd3.Text = Me.txtProposerAdd3.Text.Trim()
            Me.txtNAdd4.Text = Me.txtProposerAdd4.Text.Trim()
        Else
            Me.txtNState.ReadOnly = False
            Me.txtNPoscode.ReadOnly = False
            Me.txtNTown.ReadOnly = False
            Me.txtNAdd1.ReadOnly = False
            Me.txtNAdd2.ReadOnly = False
            Me.txtNAdd3.ReadOnly = False
            Me.txtNAdd4.ReadOnly = False
            Me.btnNState.Enabled = True
            Me.txtNState.Text = ""
            Me.txtNPoscode.Text = ""
            Me.txtNTown.Text = ""
            Me.txtNAdd1.Text = ""
            Me.txtNAdd2.Text = ""
            Me.txtNAdd3.Text = ""
            Me.txtNAdd4.Text = ""
        End If
    End Sub
    Private Sub btnNState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNState.Click
        Dim frmSearch_State As New frmSearch_Param
        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()
        Me.txtNState.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub txtProposer_Mobile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProposer_Mobile.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            txtProposer_Mobile.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtProposer_Phone_Hse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProposer_Phone_Hse.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then

            KeyAscii = 0
            txtProposer_Phone_Hse.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtProposer_Phone_Ofc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProposer_Phone_Ofc.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            txtProposer_Phone_Ofc.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtProposer_Email_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProposer_Email.Leave
        txtProposer_Email.Text = txtProposer_Email.Text.ToString.ToLower()
        If txtProposer_Email.Text.ToString.Trim().Length > 0 Then
            If Not EmailValidation(txtProposer_Email.Text.ToString.Trim()) Then
                MsgBox("Invalid email address!, Please key in valid email address")
                txtProposer_Email.Focus()
            End If
        End If
    End Sub
    Private Sub txtProposer_Plan_Payment_Method_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProposer_Plan_Payment_Method.KeyPress

    End Sub
    Private Sub txtProposer_Plan_Payment_Method_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProposer_Plan_Payment_Method.TextChanged
        Select Case Me.txtProposer_Plan_Payment_Method.Text
            Case "Credit Card"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = True
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cheque"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = True
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cash"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = True
            Case Else
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
        End Select
        If Me.txtProposer_Plan_Payment_Method.Text = "Deduction via Biro Angkasa" Then
            Me.txtBorang1_79_SN.Enabled = True
        Else
            Me.txtBorang1_79_SN.Text = ""
            Me.txtBorang1_79_SN.Enabled = False
        End If
    End Sub
    Private Sub chkDocumentation_CheckList_PG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocumentation_CheckList_PG.CheckedChanged
        If Me.chkDocumentation_CheckList_PG.Checked = True Then
            Me.flpPG6B.Enabled = True
        Else
            Me.flpPG6B.Enabled = False
            Me.rbPG6BTJ.Checked = False
            Me.rbPG6BJ.AutoCheck = False
        End If
    End Sub
    Private Sub txtNominee_SharePercentage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNominee_SharePercentage.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]") Or (Chr(KeyAscii) = ".")) Then
            KeyAscii = 0
            Me.txtNominee_SharePercentage.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.lblForm_Flag.Text = "N" Then
            PrintLetters.PrintProposer("pProposer.rpt", sProposerID, "")
        Else
            PrintLetters.PrintProposer("pProposer.rpt", Me.lblProposer_ID.Text.Trim, "")
        End If
    End Sub
    Private Sub btnDepedents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSDepedents.Click
        Dim fD As New fvDependents
        fD.lblTYPE.Text = "DEP"
        fD.lblREFID.Text = REFID
        fD.lblREFTYPE.Text = REFTYPE
        fD.Text = "List for Dependents"
        fD.ShowDialog()
        Dim dt As New DataTable
        dt = fD.dtfDep()
        Dim iKIO As Integer = 1
        If dt.Rows.Count > 0 Then
            Me.dgvDependents.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                With Me.dgvDependents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = dr("TITLE")
                    .Rows(.Rows.Count - 1).Cells(1).Value = dr("FULLNAME")
                    .Rows(.Rows.Count - 1).Cells(2).Value = dr("DOB")
                    .Rows(.Rows.Count - 1).Cells(3).Value = dr("AGE")
                    .Rows(.Rows.Count - 1).Cells(4).Value = dr("IC")
                    .Rows(.Rows.Count - 1).Cells(5).Value = dr("OLDIC")
                    .Rows(.Rows.Count - 1).Cells(6).Value = dr("ARMYIC")
                    .Rows(.Rows.Count - 1).Cells(7).Value = dr("RACE")
                    .Rows(.Rows.Count - 1).Cells(8).Value = dr("MSTATUS")
                    .Rows(.Rows.Count - 1).Cells(9).Value = dr("RELATIONSHIP")
                    .Rows(.Rows.Count - 1).Cells(10).Value = dr("SEX")
                    .Rows(.Rows.Count - 1).Cells(11).Value = dr("HEIGHT")
                    .Rows(.Rows.Count - 1).Cells(12).Value = dr("WEIGHT")
                    .Rows(.Rows.Count - 1).Cells(13).Value = dr("OCCUPATION")
                    .Rows(.Rows.Count - 1).Cells(14).Value = dr("DEPARTMENT")
                    .Rows(.Rows.Count - 1).Cells(16).Value = iKIO
                    iKIO += 1
                End With
            Next
        End If
    End Sub
    Private Sub btnNominee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNominee.Click
        Dim fD As New fvDependents
        fD.lblTYPE.Text = "NOMINEE"
        fD.lblREFID.Text = REFID
        fD.lblREFTYPE.Text = REFTYPE
        fD.Text = "List for Nominee's"
        fD.ShowDialog()
        Dim dt As New DataTable
        dt = fD.dtfDep()
        If dt.Rows.Count > 0 Then
            Me.dgvNominees.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                With Me.dgvNominees
                    Dim iCount As Integer
                    Dim Share As Decimal
                    iCount = dt.Rows.Count
                    Share = 100 / iCount
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = dr("TITLE")
                    .Rows(.Rows.Count - 1).Cells(1).Value = dr("FULLNAME")
                    .Rows(.Rows.Count - 1).Cells(2).Value = dr("DOB")
                    .Rows(.Rows.Count - 1).Cells(3).Value = dr("IC")
                    .Rows(.Rows.Count - 1).Cells(4).Value = dr("RELATIONSHIP")
                    .Rows(.Rows.Count - 1).Cells(5).Value = Me.txtProposer_AddressL1.Text
                    .Rows(.Rows.Count - 1).Cells(6).Value = Me.txtProposer_AddressL2.Text
                    .Rows(.Rows.Count - 1).Cells(7).Value = Me.txtProposerAdd3.Text
                    .Rows(.Rows.Count - 1).Cells(8).Value = Me.txtProposerAdd4.Text
                    .Rows(.Rows.Count - 1).Cells(9).Value = Me.txtProposer_City.Text
                    .Rows(.Rows.Count - 1).Cells(10).Value = Me.txtProposer_State.Text
                    .Rows(.Rows.Count - 1).Cells(11).Value = Me.txtProposer_Postcode.Text
                    .Rows(.Rows.Count - 1).Cells(12).Value = Share
                    .Rows(.Rows.Count - 1).Cells(5).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(6).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(7).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(8).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(9).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(10).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(11).ReadOnly = False
                    .Rows(.Rows.Count - 1).Cells(12).ReadOnly = False
                End With
            Next
        End If
    End Sub
    Private Sub Showgrid()
        Dim rCount As Integer = 0
        Dim iKIO As Integer = 1
        Dim i As Integer
        i = fvDependents.dgvDepDetails.Rows.Count
        Do While rCount < fvDependents.dgvDepDetails.Rows.Count
            If fvDependents.dgvDepDetails.Rows(rCount).Cells(0).Value = "T" Then
                Dim s As String
                s = fvDependents.dgvDepDetails.Rows(rCount).Cells(3).Value
                With Me.dgvDependents
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(0).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(3).Value
                    .Rows(.Rows.Count - 1).Cells(1).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(4).Value
                    .Rows(.Rows.Count - 1).Cells(2).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(5).Value
                    .Rows(.Rows.Count - 1).Cells(3).Value = Math.Floor(DateDiff(DateInterval.Day, fvDependents.dgvDepDetails.Rows(rCount).Cells(5).Value, Now()) / 365.25)
                    .Rows(.Rows.Count - 1).Cells(4).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(6).Value
                    .Rows(.Rows.Count - 1).Cells(5).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(7).Value
                    .Rows(.Rows.Count - 1).Cells(6).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(8).Value
                    .Rows(.Rows.Count - 1).Cells(7).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(9).Value
                    .Rows(.Rows.Count - 1).Cells(8).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(10).Value

                    .Rows(.Rows.Count - 1).Cells(9).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(11).Value
                    .Rows(.Rows.Count - 1).Cells(10).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(12).Value
                    .Rows(.Rows.Count - 1).Cells(11).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(13).Value
                    .Rows(.Rows.Count - 1).Cells(12).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(14).Value
                    .Rows(.Rows.Count - 1).Cells(13).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(15).Value
                    .Rows(.Rows.Count - 1).Cells(14).Value = fvDependents.dgvDepDetails.Rows(rCount).Cells(16).Value
                    .Rows(.Rows.Count - 1).Cells(16).Value = iKIO
                    iKIO += 1
                End With
            End If
            rCount += 1
        Loop

    End Sub
    Private Sub btnInfoLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoLetter.Click
        If Me.lblE32.Text = "D1E32" Then
            If vD1E32() Then
                Exit Sub
            End If
        End If
        If Me.lblProposer_Status.Text.Trim = "0" Then
            If Not My.Settings.Username = "Admin" Then
                If Me.dgvExclusion_Clause.Rows.Count > 0 Then
                    Dim iGCount As Integer = 0
                    Do While iGCount < Me.dgvExclusion_Clause.Rows.Count
                        If Me.dgvExclusion_Clause.Rows(iGCount).Cells(0).Value.ToString.Trim = "E31" Then
                            Dim dt As DataTable
                            dt = _objBusi.getDetails("EC", Me.lblProposer_ID.Text.Trim(), "", "", "", "E31", Conn)
                            If dt.Rows.Count = 1 Then
                                MsgBox("There is a EC E31 with one dependent, Please check it or check with you admin!")
                                Exit Sub
                            End If
                        End If
                        iGCount += 1
                    Loop
                End If
            End If


            Dim cmdSelect_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Proposer_New.CommandText = "SELECT ID, Status, Verified_By, Verified_On, Printed_By, Printed_On FROM dt_Proposer " & _
                                                 "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer_New As New SqlDataAdapter(cmdSelect_Proposer_New)

            Dim cmdInsert_Proposer_New As SqlCommandBuilder
            cmdInsert_Proposer_New = New SqlCommandBuilder(da_Proposer_New)


            Dim ds_Proposer As New DataSet


            da_Proposer_New.Fill(ds_Proposer, "dt_Proposer")

            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1A"
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Verified_On") = Now()
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_By") = My.Settings.Username.ToString.Trim
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Printed_On") = Now()
            da_Proposer_New.Update(ds_Proposer, "dt_Proposer")
        End If


        Dim rpt_acknowledgement As New Acknowledgement
        rpt_acknowledgement.lblProposer_ID.Text = Me.lblProposer_ID.Text.Trim
        rpt_acknowledgement.lblPlancode.Text = Me.txtProposer_Plan_Code.Text
        rpt_acknowledgement.lblPType.Text = "INFO"


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL1.Text.Trim

        If Len(Me.txtProposer_AddressL2.Text.Trim) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_AddressL2.Text.Trim & " " & Me.txtProposerAdd3.Text.ToString.Trim() & " " & Me.txtProposerAdd4.Text.ToString.Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_Postcode.Text.Trim & " " & Me.txtProposer_City.Text.Trim
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = Me.txtProposer_State.Text.Trim

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = " "
            Case 4
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select
        rpt_acknowledgement.Show()
    End Sub
#Region "DOCUMENTS UPLOAD"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
            If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                Me.txtBrowse.Text = OpenFileDialog.FileName
            Else
                MsgBox("File Requied")
                Exit Sub
            End If
        End Using
    End Sub
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim sFileToUpload As String = ""
        sFileToUpload = LTrim(RTrim(Me.txtBrowse.Text.Trim()))
        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
        If upLoadImageOrFile(sFileToUpload, Extension) Then
            Me.txtBrowse.Text = ""
            Me.txtDocName.Text = ""
        End If
    End Sub
    Private Function upLoadImageOrFile(ByVal sFilePath As String, ByVal sFileType As String) As Boolean
        Dim FileData As Byte()
        Dim sFileName As String
        Try
           
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            If Me.lblEdit_Status.Text = "Edit Mode" Then
                PID = Me.lblProposer_ID.Text.Trim()
            Else
                If PID = "" Then
                    PID = Guid.NewGuid.ToString()
                End If
            End If
            If chkUpFName(sFileName, PID) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If

            Dim ext As String = sFileType
            Dim contenttype As String = String.Empty
            Select Case ext
                Case ".doc"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".docx"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".xls"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select
            _objBusi.fIUDocumentCheckList("INS", Guid.NewGuid.ToString(), PID, Guid.NewGuid.ToString(), "PROPOSER", "", contenttype, sFileType, sFileName, DirectCast(FileData, Object), "", My.Settings.Username.ToString.Trim(), Conn)
            GetDocuments()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ReadFile(ByVal sPath As String) As Byte()

        Dim data As Byte() = Nothing

        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length

        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)

        Dim br As New BinaryReader(fStream)


        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal PID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("DOCCHKLIST", fname, PID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub GetDocuments()
        Try

            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Dim strSql As String = "Select Id, Doc_Name, Doc_Type, Doc_ext, created_on from dt_documents_checklist where proposer_id='" & PID & "'"

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
                dgBtnDelete.HeaderText = "Delete"
                dgBtnDelete.UseColumnTextForButtonValue = True
                dgBtnDelete.Text = "Delete"
                dgBtnDelete.Name = "Delete"
                dgBtnDelete.ToolTipText = "Delete"
                dgBtnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                dgBtnDelete.FlatStyle = FlatStyle.System
                dgBtnDelete.DefaultCellStyle.BackColor = Color.Gray
                dgBtnDelete.DefaultCellStyle.ForeColor = Color.Red

                Dim RowCount As Integer
                For RowCount = 0 To Me.dgvDocList.Rows.Count - 1
                    If rCount = 0 Then
                        Me.dgvDocList.Columns(0).Visible = False
                        Me.dgvDocList.Columns(3).Visible = False
                        Me.dgvDocList.Columns(4).Visible = False
                        Me.dgvDocList.Columns.Add(dgButtonColumn)
                        Me.dgvDocList.Columns.Add(dgBtnDelete)
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
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtBrowse.Text = ""
        Me.txtDocName.Text = ""
    End Sub
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
End Class