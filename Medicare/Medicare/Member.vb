Public Class Member
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
    Private Sub Member_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Member_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblGUID.Text = "GUID" Then
            Exit Sub
        Else
            Me.Populate_Form()
        End If
        Me.dtpCancellationDate.Enabled = False
        Me.txtMember_Title.ReadOnly = True
        Me.txtMember_State.ReadOnly = True

    End Sub
    Private Sub Populate_Form()
        Try

            Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member.CommandType = CommandType.Text
            cmdSelect_Member.CommandText = "SELECT ID, Clientid,  Angkasa_FileNo, Title, Full_Name, Birth_Date, IC_New, IC_Old, " & _
                                           "ArmForce_ID, Race, Marital_Status, Sex, Postal_Address_L1, Postal_Address_L2, " & _
                                           "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Height, " & _
                                           "Weight, Occupation, Department, Add3, Add4 " & _
                                           "FROM dt_Member WHERE ID = '" & Me.lblGUID.Text.Trim & "'"
            Dim da_Member As New SqlDataAdapter(cmdSelect_Member)


            Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy.CommandType = CommandType.Text
            cmdSelect_Member_Policy.CommandText = "SELECT ID, Member_ID, Angkasa_FileNo, Deduction_Code, Deduction_Amount, " & _
                                                  "Agent_Code, Submission_Date, Effective_Date, Cancellation_Date, " & _
                                                  "Status, Payment_Frequency, Payment_Method, Policy_No " & _
                                                  "FROM dt_Member_Policy WHERE Member_ID = '" & Me.lblGUID.Text.Trim & "'"
            Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)


            Dim ds_MemberInfo As New DataSet


            da_Member.Fill(ds_MemberInfo, "dt_Member")
            da_Member_Policy.Fill(ds_MemberInfo, "dt_Member_Policy")

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
                    Me.lblIC_NEWOLD.Text = .Item("IC_New").ToString.Trim & " "
                    Me.txtClientID.Text = .Item("CLIENTID").ToString.Trim & " "

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
                        .Columns(12).HeaderText = "Policy/Certificate No."

                        .Columns(4).DefaultCellStyle.Format = "###.##"
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
                    End With

                    If Not IsDBNull(ds_MemberInfo.Tables("dt_Member_Policy").Rows(0)("Effective_Date")) Then
                        Me.lblEffectiveDateOLD.Text = ds_MemberInfo.Tables("dt_Member_Policy").Rows(0)("Effective_Date")
                    End If
                    If Not IsDBNull(ds_MemberInfo.Tables("dt_Member_Policy").Rows(0)("Cancellation_Date")) Then
                        Me.lblCancellationDateOld.Text = ds_MemberInfo.Tables("dt_Member_Policy").Rows(0)("Cancellation_Date")
                    End If
                    Me.lblMember_PolicyID.Text = ds_MemberInfo.Tables("dt_Member_Policy").Rows(0)("ID").ToString

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dgvMyPolicies_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMyPolicies.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        Else
            Me.getMyPolicyDetails(e)
        End If
    End Sub
    Private Sub getMyPolicyDetails(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try

            Dim cmdSelect_Member_Policy_Transaction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy_Transaction.CommandType = CommandType.Text
            cmdSelect_Member_Policy_Transaction.CommandText = "SELECT ID,Deduction_Code ,Effective_Date, Cancellation_Date " & _
                                                              "FROM dt_Member_Policy " & _
                                                              "WHERE ID = '" & Me.dgvMyPolicies.Rows(e.RowIndex).Cells(0).Value.ToString.Trim & "' "
            Dim da_Member_Policy_Transaction As New SqlDataAdapter(cmdSelect_Member_Policy_Transaction)


            Dim ds_PolicyInfo As New DataSet


            da_Member_Policy_Transaction.Fill(ds_PolicyInfo, "dt_Member_Policy")
            Me.lblPolicyID.Text = ds_PolicyInfo.Tables(0).Rows(0)("ID").ToString()
            Me.txtDeductionCode.Text = ds_PolicyInfo.Tables(0).Rows(0)("Deduction_Code")
            If Not IsDBNull(ds_PolicyInfo.Tables(0).Rows(0)("Effective_Date")) Then
                Me.dtpEffectiveDate.Value = ds_PolicyInfo.Tables(0).Rows(0)("Effective_Date")
            End If
            If Not IsDBNull(ds_PolicyInfo.Tables(0).Rows(0)("Cancellation_Date")) Then
                Me.dtpCancellationDate.Value = ds_PolicyInfo.Tables(0).Rows(0)("Cancellation_Date")
                Me.dtpCancellationDate.Enabled = True
            Else
                Me.dtpCancellationDate.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim smRes, spRes, Race, M_Status, Sex As String

            If Not chkValidation() Then
                Exit Sub
            End If

            Dim cmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT ID, Clientid, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                           " Phone_Mobile, Phone_Hse, Phone_off, Bank_Name, Bank_Ac  FROM dt_Member " & _
                                           "WHERE ID = '" & Me.lblGUID.Text.ToString.Trim & "'"
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            sda.Fill(ds, "dt_Member_Policy")


            If Me.rdiMember_Race_Indian.Checked Then
                Race = "I"
            ElseIf Me.rdiMember_Race_Malay.Checked Then
                Race = "M"
            ElseIf Me.rdiMember_Race_Chinese.Checked Then
                Race = "C"
            ElseIf Me.rdiMember_Race_Others.Checked Then
                Race = "O"
            End If
            
            If Me.rdiMember_MaritalStatus_Single.Checked Then
                M_Status = "S"
            ElseIf Me.rdiMember_MaritalStatus_Married.Checked Then
                M_Status = "M"
            ElseIf Me.rdiMember_MaritalStatus_Divorced.Checked Then
                M_Status = "D"
            ElseIf Me.rdiMember_MaritalStatus_Widowed.Checked Then
                M_Status = "W"
            End If
            
            If Me.rdiMember_Sex_Male.Checked Then
                Sex = "1"
            Else
                Sex = "0"
            End If

            Dim sRes As String
            sRes = objBusi.UpdateMemberDetails("UPS", Me.lblGUID.Text.ToString.Trim(), Me.txtClientID.Text.Trim(), Me.txtMember_Title.Text.Trim(), Me.txtMember_Name.Text.Trim(), Format(Me.dtpMember_DOB.Value, "MM/dd/yyyy"), Me.txtMember_NRIC.Text.Trim(), Race, M_Status, Sex, Me.txtMember_AddressL1.Text.ToString.Trim(), Me.txtMember_AddressL2.Text.ToString.Trim(), Me.txtAdd3.Text.ToString.Trim(), Me.txtAdd4.Text.ToString.Trim(), Me.txtMember_City.Text.Trim(), Me.txtMember_State.Text.Trim(), Me.txtMember_Postcode.Text.Trim(), Me.cbBankName.Text.Trim(), Me.txtBankAc.Text.ToString.Trim(), Me.txtMember_Phone_Hse.Text.Trim(), Me.txtMember_Mobile.Text.Trim(), Me.txtMember_Phone_Ofc.Text.Trim(), Me.txtMember_Email.Text.Trim(), Me.txtMember_Height.Text.Trim(), Me.txtMember_Weight.Text.Trim(), Me.txtMember_Occupation.Text.Trim(), Me.txtMember_Department.Text.Trim(), My.Settings.Username, Conn)
            
            Me.objBusi.Log(Me.lblGUID.Text, "Updated Member details User ID : " & My.Settings.Username & " ", Conn)


            Dim var_Change_Remark As String = ""
            Dim var_Title As String = ""
            Dim var_Name As String = ""
            Dim var_Race As String = ""
            Dim var_Marital_Status As String = ""
            Dim var_Sex As Boolean

            If Me.txtMember_Title.Text.Trim <> ds.Tables(0).Rows(0)("Title").ToString.Trim() Then
                If Len(ds.Tables(0).Rows(0)("Title").ToString.Trim()) = 0 Then
                    var_Title = "(BLANK)"
                Else
                    var_Title = ds.Tables(0).Rows(0)("Title").ToString.Trim()
                End If
                var_Change_Remark = "Change of Title from: " & var_Title.Trim & _
                                    " to " & Me.txtMember_Title.Text.Trim & ". "
            End If

            If Me.txtMember_Name.Text.Trim <> ds.Tables(0).Rows(0)("FULL_NAME").ToString.Trim().ToUpper Then
                If Len(ds.Tables(0).Rows(0)("FULL_NAME").ToString.Trim()) = 0 Then
                    var_Name = "(BLANK)"
                Else
                    var_Name = ds.Tables(0).Rows(0)("FULL_NAME").ToString.Trim()
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Name from: " & var_Name.Trim & _
                                    " to " & Me.txtMember_Name.Text.Trim & ". "
            End If

            If Me.dtpMember_DOB.Value.Date <> Today() Then
                If Len(ds.Tables(0).Rows(0)("BIRTH_DATE").ToString.Trim()) = 0 Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Date of Birth from: (BLANK)" & _
                    " to " & Format(Me.dtpMember_DOB.Value, "dd/MM/yyyy") & ". "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Date of Birth from: " & _
                                        Format(ds.Tables(0).Rows(0)("BIRTH_DATE").ToString.Trim(), "dd/MM/yyyy") & _
                                        " to " & Format(Me.dtpMember_DOB.Value, "dd/MM/yyyy") & ". "
                End If
            End If

            If Me.rdiMember_Race_Malay.Checked = True Then
                var_Race = "M"
            ElseIf Me.rdiMember_Race_Chinese.Checked = True Then
                var_Race = "C"
            ElseIf Me.rdiMember_Race_Indian.Checked = True Then
                var_Race = "I"
            ElseIf Me.rdiMember_Race_Others.Checked = True Then
                var_Race = "O"
            End If

            If var_Race.Trim <> ds.Tables(0).Rows(0)("RACE").ToString.Trim() Then
                If Len(ds.Tables(0).Rows(0)("Title").ToString.Trim()) = 0 Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Race from: (BLANK) " & _
                                        " to " & var_Race.Trim & ". "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Race from: " & _
                                        ds.Tables(0).Rows(0)("RACE").ToString.Trim() & _
                                        " to " & var_Race.Trim & ". "
                End If
            End If

            If Me.rdiMember_MaritalStatus_Single.Checked = True Then
                var_Marital_Status = "S"
            ElseIf Me.rdiMember_MaritalStatus_Married.Checked = True Then
                var_Marital_Status = "M"
            ElseIf Me.rdiMember_MaritalStatus_Widowed.Checked = True Then
                var_Marital_Status = "W"
            ElseIf Me.rdiMember_MaritalStatus_Divorced.Checked = True Then
                var_Marital_Status = "D"
            End If

            If var_Marital_Status.Trim <> ds.Tables(0).Rows(0)("RACE").ToString.Trim() Then
                If Len(ds.Tables(0).Rows(0)("RACE").ToString.Trim()) = 0 Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Marital Status from: (BLANK) " & _
                                        " to " & var_Marital_Status.Trim & ". "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Marital Status from: " & _
                                        ds.Tables(0).Rows(0)("RACE").ToString.Trim() & _
                                        " to " & var_Marital_Status.Trim & ". "
                End If
            End If

            If Me.rdiMember_Sex_Male.Checked = True Then
                var_Sex = True
            ElseIf Me.rdiMember_Sex_Female.Checked = True Then
                var_Sex = False
            End If

            If Len(ds.Tables(0).Rows(0)("SEX").ToString.Trim()) > 0 Then
                If var_Sex <> ds.Tables(0).Rows(0)("SEX").ToString.Trim() Then
                    If ds.Tables(0).Rows(0)("SEX") = True Then
                        If var_Sex = True Then
                            var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: Male" & _
                                                " to Male. "
                        Else
                            var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: Male" & _
                                                " to Female. "
                        End If
                    Else
                        If var_Sex = True Then
                            var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: Female" & _
                                                " to Male. "
                        Else
                            var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: Female" & _
                                                " to Female. "
                        End If
                    End If

                End If
            Else
                If var_Sex = True Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: (BLANK) " & _
                                        " to Male. "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Sex from: (BLANK) " & _
                                        " to Female. "
                End If
            End If
            Me.objBusi.EndorsementLog(Me.lblGUID.Text, Me.lblMember_PolicyID.Text, "E", "Change " & var_Change_Remark.Trim, Now(), Me.txtRemarks.Text, Now(), Me.txtMember_NRIC.Text.Trim(), "CHANGE OF MEMBER PERSONAL DETAILS", Conn)


            If Not Me.lblPolicyID.Text = "" Then
                Dim cmdUpdatePolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdUpdatePolicy.CommandType = CommandType.Text
                If Me.chkChangeCancellantionDate.Checked Then
                    cmdUpdatePolicy.CommandText = "UPDATE dt_member_Policy SET effective_date='" & Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy") & "', cancellation_date='" & Format(Me.dtpCancellationDate.Value, "MM/dd/yyyy") & "' " & _
                                                           " WHERE ID='" & Me.lblPolicyID.Text & "'"
                    Me.objBusi.Log(Me.lblPolicyID.Text, "Updated Effective Date : " & Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy") & " Cancellation Date : " & Format(Me.dtpCancellationDate.Value, "MM/dd/yyyy") & " User ID : " & My.Settings.Username & " ", Conn)
                    Me.objBusi.EndorsementLog(Me.lblGUID.Text, Me.lblPolicyID.Text, "E", "Change Effective Date From : " & Format(Me.lblEffectiveDateOLD.Text, "MM/dd/yyyy") & "To " & Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy") & " and Cancellation Date : " & Format(Me.lblCancellationDateOld.Text, "MM/dd/yyyy") & " TO : " & Format(Me.dtpCancellationDate.Value, "MM/dd/yyyy") & " ", Now(), Me.txtRemarks.Text, Now(), Me.txtMember_NRIC.Text.Trim(), "CHANGE OF POLICY DETAILS", Conn)
                    objBusi.UpdateEDATE(Me.lblPolicyID.Text.ToString.Trim(), Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), Format(Me.dtpCancellationDate.Value, "MM/dd/yyyy"), Conn)
                Else
                    cmdUpdatePolicy.CommandText = "UPDATE dt_member_Policy SET effective_date='" & Format(Convert.ToDateTime(Me.dtpEffectiveDate.Value), "MM/dd/yyyy") & "' " & _
                                               " WHERE ID='" & Me.lblPolicyID.Text & "'"
                    Me.objBusi.Log(Me.lblPolicyID.Text, "Updated Effective Date : " & Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy") & " User ID : " & My.Settings.Username & " ", Conn)
                    Me.objBusi.EndorsementLog(Me.lblGUID.Text, Me.lblPolicyID.Text, "E", "Change Effective Date From : " & Format(Me.lblEffectiveDateOLD.Text, "MM/dd/yyyy") & "To " & Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy") & "", Now(), Me.txtRemarks.Text, Now(), Me.txtMember_NRIC.Text.Trim(), "CHANGE OF POLICY DETAILS", Conn)
                    
                    objBusi.UpdateEDATE(Me.lblPolicyID.Text.ToString.Trim(), Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), "NOCANCELDATE", Conn)

                End If
                cmdUpdatePolicy.ExecuteNonQuery()
            End If
            If sRes = "1" Then
                MsgBox("Successfully Change the Member & Policy Details")
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox("Error while Changing the Member & Policy Details")
        End Try
    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click
        Dim frmSearch_State As New frmSearch_Param

        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()

        Me.txtMember_State.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitle.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtMember_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Function chkValidation() As Boolean
        If Me.txtMember_NRIC.Text.ToString.Trim() = "" Then
            MsgBox("IC Can't be Blank!")
            Me.txtMember_NRIC.Focus()
            Return False
        End If
        If Me.txtMember_Title.Text.ToString.Trim() = "" Then
            MsgBox("Title Can't be Blank!")
            Me.txtMember_Title.Focus()
            Return False
        End If
        If Me.txtMember_Name.Text.ToString.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtMember_Name.Focus()
            Return False
        End If
        If Me.rdiMember_Race_Malay.Checked = False Then
            If Me.rdiMember_Race_Indian.Checked = False Then
                If Me.rdiMember_Race_Chinese.Checked = False Then
                    If Me.rdiMember_Race_Others.Checked = False Then
                        MsgBox("Please Select the Race!")
                        Me.rdiMember_Race_Malay.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        If Me.rdiMember_MaritalStatus_Single.Checked = False Then
            If Me.rdiMember_MaritalStatus_Married.Checked = False Then
                If Me.rdiMember_MaritalStatus_Widowed.Checked = False Then
                    If Me.rdiMember_MaritalStatus_Divorced.Checked = False Then
                        MsgBox("Please Select the Marital Status!")
                        Me.rdiMember_MaritalStatus_Single.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        If Me.rdiMember_Sex_Male.Checked = False Then
            If Me.rdiMember_Sex_Female.Checked = False Then
                MsgBox("Please Select the Sex!")
                Me.rdiMember_Sex_Male.Focus()
                Return False
            End If
        End If
        If Me.txtMember_AddressL1.Text.ToString.Trim() = "" Then
            MsgBox("Address Can't be Blank!")
            Me.txtMember_AddressL1.Focus()
            Return False
        End If
        If Me.txtMember_Postcode.Text.ToString.Trim() = "" Then
            MsgBox("Postcode Can't be Blank!")
            Me.txtMember_Postcode.Focus()
            Return False
        End If
        If Me.txtMember_City.Text.ToString.Trim() = "" Then
            MsgBox("Town Can't be Blank!")
            Me.txtMember_City.Focus()
            Return False
        End If
        If Me.txtMember_State.Text.ToString.Trim() = "" Then
            MsgBox("State Can't be Blank!")
            Me.txtMember_State.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub chkChangeCancellantionDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeCancellantionDate.CheckedChanged
        If Me.chkChangeCancellantionDate.Checked Then
            Me.dtpCancellationDate.Enabled = True
        Else
            Me.dtpCancellationDate.Enabled = False
        End If
    End Sub
End Class