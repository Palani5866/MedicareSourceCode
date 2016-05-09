Public Class New_Dependent_Add
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
    Private Sub New_Dependent_Add_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub New_Dependent_Add_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub dtpDependent_DOB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDependent_DOB.Leave
        Me.txtDependent_Age.Text = Math.Floor(DateDiff(DateInterval.Day, Me.dtpDependent_DOB.Value, Now()) / 365.25)
    End Sub
    Private Function Verify_Dependent_Details() As Boolean
        If Len(Me.txtDependent_Title.Text.Trim) = 0 Then
            MsgBox("Please do select Dependent's Title.")
            Me.btnDependent_Title.Focus()
            Return False
        End If

        If Len(Me.txtDependent_FirstName.Text.Trim) = 0 Then
            MsgBox("Please do key in Dependent's First Name.")
            Me.txtDependent_FirstName.Focus()
            Return False
        End If

        If Me.dtpDependent_DOB.Value.Date = Today() Then
            MsgBox("Please do select Dependent's Date of Birth.")
            Me.dtpDependent_DOB.Focus()
            Return False
        End If

        If Len(Me.txtDependent_NRIC.Text.Trim) = 0 Then
            MsgBox("Please do key in Dependent's New I/C No or Police/Army ID.")
            Me.txtDependent_NRIC.Focus()
            Return False
        End If

        If Me.rdiDependent_Race_Malay.Checked = False Then
            If Me.rdiDependent_Race_Chinese.Checked = False Then
                If Me.rdiDependent_Race_Indian.Checked = False Then
                    If Me.rdiDependent_Race_Others.Checked = False Then
                        MsgBox("Please do select Dependent's Race.")
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
                        MsgBox("Please do select Dependent's Marital Status.")
                        Me.rdiDependent_MaritalStatus_Single.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If Me.cmbDependent_Relationship.SelectedIndex = -1 Then
            MsgBox("Please do select Dependent's Relationship with Proposer.")
            Me.cmbDependent_Relationship.Focus()
            Return False
        End If

        If Me.rdiDependent_Sex_Male.Checked = False Then
            If Me.rdiDependent_Sex_Female.Checked = False Then
                MsgBox("Please do select in Dependent's Sex.")
                Me.rdiDependent_Sex_Male.Focus()
                Return False
            End If
        End If

        If Len(Me.txtDependent_Height.Text.Trim) = 0 Then
            MsgBox("Please do key in Dependent's Height.")
            Me.txtDependent_Height.Focus()
            Return False
        End If

        If Len(Me.txtDependent_Weight.Text.Trim) = 0 Then
            MsgBox("Please do key in Dependent's Weight.")
            Me.txtDependent_Weight.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub Clear()
        Me.lblMemberID.Text = ""
        Me.lblPolicyID.Text = ""
        Me.txtDependent_Age.Text = ""
        Me.txtDependent_ArmForceID.Text = ""
        Me.txtDependent_Department.Text = ""
        Me.txtDependent_FirstName.Text = ""
        Me.txtDependent_Height.Text = ""
        Me.txtDependent_NRIC.Text = ""
        Me.txtDependent_Occupation.Text = ""
        Me.txtDependent_OldIC.Text = ""
        Me.txtDependent_Title.Text = ""
        Me.txtDependent_Weight.Text = ""
    End Sub
    Private Sub btnTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitle.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtDependent_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub

    Private Sub btnDependent_Add_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Add.Click
        If Me.Verify_Dependent_Details() = True Then
            Try

                Dim scDep_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                scDep_New.CommandType = CommandType.Text
                scDep_New.CommandText = "SELECT * FROM dt_Member_Policy_Dependents"

                Dim sdaDep_New As New SqlDataAdapter(scDep_New)
                Dim scbDep_New As SqlCommandBuilder
                scbDep_New = New SqlCommandBuilder(sdaDep_New)


                Dim scEndorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                scEndorsement.CommandType = CommandType.Text
                scEndorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
                Dim sdaEndorsement As New SqlDataAdapter(scEndorsement)

                Dim scbEndorsement As SqlCommandBuilder
                scbEndorsement = New SqlCommandBuilder(sdaEndorsement)



                Dim ds_dep As New DataSet


                sdaDep_New.Fill(ds_dep, "dt_Member_Policy_Dependents")
                sdaEndorsement.Fill(ds_dep, "dt_Member_Endorsement")

                Dim drDep_New As DataRow
                Dim strDependent_ID As String

                drDep_New = ds_dep.Tables("dt_Member_Policy_Dependents").NewRow

                strDependent_ID = Guid.NewGuid.ToString

                With drDep_New
                    .Item("ID") = strDependent_ID
                    .Item("Member_Policy_ID") = Me.lblPolicyID.Text.ToString.Trim()
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
                    .Item("Effective_Date") = Me.dtpEffectiveDate.Value
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    ds_dep.Tables("dt_Member_Policy_Dependents").Rows.Add(drDep_New)
                    sdaDep_New.Update(ds_dep, "dt_Member_Policy_Dependents")
                End With
                If Me.lblAdmin.Text = "Admin" Then
                    Me.objBusi.aLog(Me.lblPolicyID.Text.ToString.Trim(), "Added Dependant Name : " & Me.txtDependent_FirstName.Text.ToString() & "IC No : " & Me.txtDependent_NRIC.Text.ToString.Trim() & "DOB : " & Me.dtpDependent_DOB.Value & " ***  Added By User ID : " & My.Settings.Username & " ", Conn)
                Else

                    Dim drEndorsement_New As DataRow
                    drEndorsement_New = ds_dep.Tables("dt_Member_Endorsement").NewRow

                    With drEndorsement_New
                        .Item("ID") = Guid.NewGuid.ToString()
                        .Item("Member_ID") = Me.lblMemberID.Text.ToString.Trim()
                        .Item("Member_Policy_ID") = Me.lblPolicyID.Text.ToString.Trim()
                        .Item("Log_Date") = Now()
                        .Item("Endorsement_Type") = "E"
                        .Item("Endorsement_Detail") = "Adding Dependant Details Name : " & Me.txtDependent_FirstName.Text.ToString() & "IC No : " & Me.txtDependent_NRIC.Text.ToString.Trim() & "DOB : " & Me.dtpDependent_DOB.Value & ""
                        .Item("Request_Date") = Now()
                        .Item("Remark") = ""
                        .Item("TRANS_TYPE") = "ADD DEPENDENT"
                        .Item("IC") = Me.txtDependent_NRIC.Text.Trim()
                        .Item("Username") = My.Settings.Username.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                        .Item("Effective_Date") = Me.dtpEffectiveDate.Value
                    End With
                    ds_dep.Tables("dt_Member_Endorsement").Rows.Add(drEndorsement_New)
                    sdaEndorsement.Update(ds_dep, "dt_Member_Endorsement")

                    Me.objBusi.Log(Me.lblPolicyID.Text.ToString.Trim(), "Added Dependant Name : " & Me.txtDependent_FirstName.Text.ToString() & "IC No : " & Me.txtDependent_NRIC.Text.ToString.Trim() & "DOB : " & Me.dtpDependent_DOB.Value & " ***  Added By User ID : " & My.Settings.Username & " ", Conn)

                End If
                MessageBox.Show("Dependant Details Added Successfully")
                Clear()
                Me.btnDependent_Add.Visible = True
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
   
End Class