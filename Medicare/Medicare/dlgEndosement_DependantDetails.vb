Public Class dlgEndosement_DependantDetails
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
    Dim otitle, oName, oDOB, oNRIC, oCLIENTID, oNRIC_OLD, oARMY_IC, oRace, oM_status, osex, oheight, oOccupation, oDept, oweight, oRelationship, oEffective_date, oRemarks As String
#End Region
#Region "Click Events"
    Private Sub btnDependent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Add.Click
        If Me.Verify_Dependent_Details() = True Then
            Try

                Dim cmdSelect_Proposer_Dependent_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Proposer_Dependent_New.CommandType = CommandType.Text
                cmdSelect_Proposer_Dependent_New.CommandText = "SELECT * FROM dt_Member_Policy_Dependents"

                Dim da_Proposer_Dependent_New As New SqlDataAdapter(cmdSelect_Proposer_Dependent_New)
                Dim cmdInsert_Proposer_Dependent_New As SqlCommandBuilder
                cmdInsert_Proposer_Dependent_New = New SqlCommandBuilder(da_Proposer_Dependent_New)


                Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_Member_Endorsement.CommandType = CommandType.Text
                cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
                Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

                Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
                cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)



                Dim ds_dep As New DataSet


                da_Proposer_Dependent_New.Fill(ds_dep, "dt_Member_Policy_Dependents")
                da_Member_Endorsement.Fill(ds_dep, "dt_Member_Endorsement")

                Dim dr_Proposer_Dependent_New As DataRow
                Dim var_Proposer_Dependent_ID As String
                Dim var_Member_Policy_ID As String


                dr_Proposer_Dependent_New = ds_dep.Tables("dt_Member_Policy_Dependents").NewRow

                var_Proposer_Dependent_ID = Guid.NewGuid.ToString
                '

                Dim _sqlCmdget_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmdget_ins.CommandType = CommandType.Text
                _sqlCmdget_ins.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & Me.lblICNO.Text.Trim & "')"
                Dim adp As New SqlDataAdapter(_sqlCmdget_ins)
                Dim ds As New DataSet
                Dim sRes As Guid
                adp.Fill(ds, "dt_member_policy")
                sRes = ds.Tables(0).Rows(0)("ID")
                var_Member_Policy_ID = ds.Tables(0).Rows(0)("ID").ToString

                With dr_Proposer_Dependent_New
                    .Item("ID") = var_Proposer_Dependent_ID
                    .Item("Member_Policy_ID") = var_Member_Policy_ID
                    .Item("Title") = Me.txtDependent_Title.Text.Trim
                    .Item("Full_Name") = Me.txtDependent_FirstName.Text.Trim
                    .Item("Birth_Date") = Me.dtpDependent_DOB.Value
                    .Item("IC_New") = Me.txtDependent_NRIC.Text.Trim
                    .Item("IC_Old") = Me.txtDependent_OldIC.Text.Trim
                    .Item("CLIENTID") = Me.txtClientID.Text.Trim
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

                    ds_dep.Tables("dt_Member_Policy_Dependents").Rows.Add(dr_Proposer_Dependent_New)
                    da_Proposer_Dependent_New.Update(ds_dep, "dt_Member_Policy_Dependents")
                End With


                Dim dr_Member_Endorsement_New As DataRow
                dr_Member_Endorsement_New = ds_dep.Tables("dt_Member_Endorsement").NewRow

                With dr_Member_Endorsement_New
                    .Item("ID") = Guid.NewGuid.ToString()
                    .Item("Member_ID") = ds.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                    .Item("Member_Policy_ID") = var_Member_Policy_ID
                    .Item("Log_Date") = Now()
                    .Item("Endorsement_Type") = "E"
                    .Item("Endorsement_Detail") = "Adding Dependant Details Name : " & Me.txtDependent_FirstName.Text.ToString() & "IC No : " & Me.txtDependent_NRIC.Text.ToString.Trim() & "DOB : " & Me.dtpDependent_DOB.Value & ""
                    .Item("Request_Date") = Now()
                    .Item("Remark") = ""
                    .Item("TRANS_TYPE") = "ADD DEPENDENT"
                    .Item("IC") = Me.txtDependent_NRIC.Text.Trim()
                    .Item("Remark") = ""
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Effective_Date") = Me.dtpEffectiveDate.Value
                End With

                ds_dep.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
                da_Member_Endorsement.Update(ds_dep, "dt_Member_Endorsement")
                Me.objBusi.Log(var_Member_Policy_ID, "Added Dependant Name : " & Me.txtDependent_FirstName.Text.ToString() & "IC No : " & Me.txtDependent_NRIC.Text.ToString.Trim() & "DOB : " & Me.dtpDependent_DOB.Value & " ***  Added By User ID : " & My.Settings.Username & " ", Conn)
                MessageBox.Show("Dependant Details Added Successfully")
                Clear()
                Me.Close()
                Me.btnDependent_Add.Visible = True
                Me.btnDependent_Update.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnDependent_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Title.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtDependent_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnDependent_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDependent_Update.Click
        Update_Dependent_details()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.txtRemarks.Text.Trim() = "" Then
            MsgBox("Please do key in reason for delete the Dependant..")
            Exit Sub
        End If
        Dim dt As New DataTable
        dt = objBusi.getDetails("MEMBERDETAILS", lblID.Text.Trim(), "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Me.objBusi.EndorsementLog(dt.Rows(0)("MEMBER_ID").ToString().Trim(), dt.Rows(0)("ID").ToString.Trim(), "EA", "Deleted Dependent IC New :  " & Me.txtDependent_NRIC.Text.Trim() & " Name : " & Me.txtDependent_FirstName.Text.Trim() & " Effective Date : " & Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss") & " Remarks : " & Me.txtRemarks.Text.Trim(), Now(), "", Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss"), Me.txtDependent_NRIC.Text.Trim(), "DELETED DEPENDENT", Conn)
        End If
        Dim sRes As String
        Dim scDelete As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scDelete.CommandType = CommandType.Text
        scDelete.CommandText = "DELETE FROM dt_Member_Policy_Dependents WHERE ID = '" & lblID.Text & "'"
        sRes = scDelete.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Successfully deleted the dependent")
            Me.Close()
        Else
            MsgBox("Error while deleting the dependent")
        End If
    End Sub
#End Region
#Region "General Functions/Subs"
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
        txtDependent_Age.Text = ""
        txtDependent_Department.Text = ""
        txtDependent_ArmForceID.Text = ""
        txtDependent_FirstName.Text = ""
        txtDependent_Height.Text = ""
        txtDependent_Occupation.Text = ""
        txtDependent_OldIC.Text = ""
        txtDependent_Title.Text = ""
        txtDependent_Weight.Text = ""
        'cmbDependent_Relationship.SelectedIndex = -1 
    End Sub
    Private Function getDependent_details(ByVal id As String) As Boolean
        Dim _ds As New DataSet
        Dim _scDependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scDependent.CommandType = CommandType.Text
        _scDependent.CommandText = "SELECT * FROM dt_Member_Policy_Dependents WHERE ID = '" & id & "'"
        Dim _sdaDependent As New SqlDataAdapter(_scDependent)
        _sdaDependent.Fill(_ds, "dt_Member_Policy_Dependents")
        ' Me.lblMemberID.Text = id
        If _ds.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Title")) Then
                Me.txtDependent_Title.Text = _ds.Tables(0).Rows(0)("Title")
                otitle = _ds.Tables(0).Rows(0)("Title")
            Else
                otitle = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Full_Name")) Then
                Me.txtDependent_FirstName.Text = _ds.Tables(0).Rows(0)("Full_Name")
                oName = _ds.Tables(0).Rows(0)("Full_Name")
            Else
                oName = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Birth_Date")) Then
                Me.dtpDependent_DOB.Value = _ds.Tables(0).Rows(0)("Birth_Date")
                oDOB = _ds.Tables(0).Rows(0)("Birth_Date")
            Else
                oDOB = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("IC_NEW")) Then
                Me.txtDependent_NRIC.Text = _ds.Tables(0).Rows(0)("IC_NEW")
                oNRIC = _ds.Tables(0).Rows(0)("IC_NEW")
            Else
                oNRIC = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("CLIENTID")) Then
                Me.txtClientID.Text = _ds.Tables(0).Rows(0)("CLIENTID")
                oCLIENTID = _ds.Tables(0).Rows(0)("CLIENTID")
            Else
                oCLIENTID = ""
            End If

            If Not IsDBNull(_ds.Tables(0).Rows(0)("IC_Old")) Then
                Me.txtDependent_OldIC.Text = _ds.Tables(0).Rows(0)("IC_Old")
                oNRIC_OLD = _ds.Tables(0).Rows(0)("IC_Old")
            Else
                oNRIC_OLD = ""
            End If

            If Not IsDBNull(_ds.Tables(0).Rows(0)("ArmForce_ID")) Then
                Me.txtDependent_ArmForceID.Text = _ds.Tables(0).Rows(0)("ArmForce_ID")
                oARMY_IC = _ds.Tables(0).Rows(0)("ArmForce_ID")
            Else
                oARMY_IC = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Race")) Then
                Select Case _ds.Tables(0).Rows(0)("Race")
                    Case "M"
                        Me.rdiDependent_Race_Malay.Checked = True
                    Case "C"
                        Me.rdiDependent_Race_Chinese.Checked = True
                    Case "I"
                        Me.rdiDependent_Race_Indian.Checked = True
                    Case "O"
                        Me.rdiDependent_Race_Others.Checked = True
                End Select
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Marital_Status")) Then
                oM_status = _ds.Tables(0).Rows(0)("Marital_Status")
                Select Case _ds.Tables(0).Rows(0)("Marital_Status")
                    Case "S"
                        Me.rdiDependent_MaritalStatus_Single.Checked = True
                    Case "M"
                        Me.rdiDependent_MaritalStatus_Married.Checked = True
                    Case "W"
                        Me.rdiDependent_MaritalStatus_Widowed.Checked = True
                    Case "D"
                        Me.rdiDependent_MaritalStatus_Divorced.Checked = True
                End Select
            Else
                oM_status = ""
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Sex")) Then
                If _ds.Tables(0).Rows(0)("Sex") = 1 Then
                    Me.rdiDependent_Sex_Male.Checked = True
                Else
                    Me.rdiDependent_Sex_Female.Checked = True
                End If
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Height")) Then
                Me.txtDependent_Height.Text = _ds.Tables(0).Rows(0)("Height")
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Weight")) Then
                Me.txtDependent_Weight.Text = _ds.Tables(0).Rows(0)("Weight")
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Occupation")) Then
                Me.txtDependent_Occupation.Text = _ds.Tables(0).Rows(0)("Occupation")
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Department")) Then
                Me.txtDependent_Department.Text = _ds.Tables(0).Rows(0)("Department")
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Relationship")) Then
                Me.cmbDependent_Relationship.SelectedItem = _ds.Tables(0).Rows(0)("Relationship")
            End If
            If Not IsDBNull(_ds.Tables(0).Rows(0)("Effective_Date")) Then
                Me.dtpEffectiveDate.Value = _ds.Tables(0).Rows(0)("Effective_Date")
            End If
        End If
    End Function
    Private Function Endorsment_Changes() As String
        Dim title, Name, DOB, NRIC, CLIENTID, NRIC_OLD, ARMY_IC, Race, M_status, sex, height, Occupation, Dept, weight, Relationship, Effective_date As String
        Dim sRemarks As String = ""

        If Me.txtDependent_Title.Text.Trim <> otitle.ToString.Trim() Then
            If Len(otitle.ToString.Trim()) = 0 Then
                title = "(BLANK)"
            Else
                title = otitle.ToString.Trim()
            End If
            sRemarks = "Change of Dependent  Title from: " & title & " to " & Me.txtDependent_Title.Text.Trim & ". "
        End If


        If Me.txtDependent_FirstName.Text.Trim <> oName.ToString.Trim Then
            If Len(oName.ToString.Trim) = 0 Then
                Name = "(BLANK)"
            Else
                Name = oName.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of  Dependent Name from: " & oName & " to " & Me.txtDependent_FirstName.Text.Trim & ". "
        End If

        If Me.dtpDependent_DOB.Value <> oDOB.ToString.Trim Then
            If Len(oDOB.ToString.Trim) = 0 Then
                DOB = "(BLANK)"
            Else
                DOB = oDOB.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Dependent Date Of Birth from: " & DOB & " to " & Me.dtpDependent_DOB.Value & ". "
        End If

        If Me.txtDependent_NRIC.Text.Trim <> oNRIC.ToString.Trim Then
            If Len(oNRIC.ToString.Trim) = 0 Then
                NRIC = "(BLANK)"
            Else
                NRIC = oNRIC.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Dependent NRIC from: " & NRIC & " to " & Me.txtDependent_NRIC.Text.Trim & ". "
        End If

        If Me.txtClientID.Text.Trim <> oCLIENTID.ToString.Trim Then
            If Len(oCLIENTID.ToString.Trim) = 0 Then
                CLIENTID = "(BLANK)"
            Else
                CLIENTID = oCLIENTID.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Dependent CLIENTID from: " & CLIENTID & " to " & Me.txtClientID.Text.Trim & ". "
        End If


        If Me.txtDependent_OldIC.Text.Trim <> oNRIC_OLD.ToString.Trim Then
            If Len(oNRIC_OLD.ToString.Trim) = 0 Then
                NRIC_OLD = "(BLANK)"
            Else
                NRIC_OLD = oNRIC_OLD.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Dependent NRIC OLD from: " & NRIC_OLD & " to " & Me.txtDependent_OldIC.Text.Trim & ". "
        End If

        If Me.txtDependent_ArmForceID.Text.Trim <> oARMY_IC.ToString.Trim Then
            If Len(oARMY_IC.ToString.Trim) = 0 Then
                ARMY_IC = "(BLANK)"
            Else
                ARMY_IC = oARMY_IC.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Dependent ARMY ID from: " & ARMY_IC & " to " & Me.txtDependent_ArmForceID.Text.Trim & ". "
        End If


        Dim m_status1 As String
        If Me.rdiDependent_MaritalStatus_Single.Checked = True Then
            m_status1 = "S"
        ElseIf Me.rdiDependent_MaritalStatus_Married.Checked = True Then
            m_status1 = "M"
        ElseIf Me.rdiDependent_MaritalStatus_Widowed.Checked = True Then
            m_status1 = "W"
        ElseIf Me.rdiDependent_MaritalStatus_Divorced.Checked = True Then
            m_status1 = "D"
        End If
        If m_status1 <> oM_status.ToString.Trim Then
            If Len(oARMY_IC.ToString.Trim) = 0 Then
                M_status = "(BLANK)"
            Else
                M_status = oM_status.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "  Change of Dependent Marital Status  from: " & M_status & " to " & m_status1 & ". "
        End If
        Return sRemarks
    End Function
    Private Sub dtpDependent_DOB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDependent_DOB.Leave
        Me.txtDependent_Age.Text = Now().Year - Me.dtpDependent_DOB.Value.Year
    End Sub
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_DependantDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim id As String = Me.lblID.Text
        If Not id = "ID" Then
            getDependent_details(id)
            Me.btnDependent_Add.Visible = False
            Me.btnDependent_Update.Visible = True
            Me.btnDelete.Visible = True
        Else
            Me.btnDependent_Add.Visible = True
            Me.btnDependent_Update.Visible = False
            Me.btnDelete.Visible = False
            Dim cmd_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmd_Parameter.CommandType = CommandType.Text


            Dim ds_Param As New DataSet

            cmd_Parameter.CommandText = "SELECT * FROM dt_member " & _
                                              "WHERE IC_New = '" & Me.lblICNO.Text.Trim & "'"

            Dim da_ProposerMember As New SqlDataAdapter(cmd_Parameter)
            da_ProposerMember.Fill(ds_Param, "dt_Proposer")

            If ds_Param.Tables("dt_Proposer").Rows.Count > 0 Then
                With ds_Param.Tables("dt_Proposer").Rows(0)
                    lblProposer_ID.Text = .Item("ID").ToString.Trim
                End With
            End If
        End If

    End Sub
#End Region
#Region "Update"
    Private Sub Update_Dependent_details()
        Dim Race, m_status, sex, sRes As String
        If Me.Verify_Dependent_Details() = True Then
            If Me.rdiDependent_Race_Malay.Checked = True Then
                Race = "M"
            ElseIf Me.rdiDependent_Race_Chinese.Checked = True Then
                Race = "C"
            ElseIf Me.rdiDependent_Race_Indian.Checked = True Then
                Race = "I"
            ElseIf Me.rdiDependent_Race_Others.Checked = True Then
                Race = "O"
            End If

            If Me.rdiDependent_MaritalStatus_Single.Checked = True Then
                m_status = "S"
            ElseIf Me.rdiDependent_MaritalStatus_Married.Checked = True Then
                m_status = "M"
            ElseIf Me.rdiDependent_MaritalStatus_Widowed.Checked = True Then
                m_status = "W"
            ElseIf Me.rdiDependent_MaritalStatus_Divorced.Checked = True Then
                m_status = "D"
            End If
            If Me.rdiDependent_Sex_Male.Checked = True Then
                sex = 1
            ElseIf Me.rdiDependent_Sex_Female.Checked = True Then
                sex = 0
            End If
           
            Dim dod As String
            dod = Format(Me.dtpDependent_DOB.Value, "MM/dd/yyyy")

            Try
                sRes = objBusi.UpdateDependentsDetails("UPDATE", Me.lblID.Text.ToString.Trim(), Me.txtClientID.Text.ToString.Trim(), Me.txtDependent_Title.Text.Trim(), Me.txtDependent_NRIC.Text.Trim(), Me.txtDependent_FirstName.Text.Trim(), dod, Me.txtDependent_OldIC.Text.Trim(), Me.txtDependent_ArmForceID.Text.Trim(), Race, m_status, sex, Me.cmbDependent_Relationship.SelectedItem.ToString.Trim(), Val(Me.txtDependent_Height.Text), Val(Me.txtDependent_Weight.Text), Me.txtDependent_Occupation.Text.Trim, Me.txtDependent_Department.Text.Trim(), Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), My.Settings.Username.Trim, Conn)
                If Me.lblAdmin.Text = "Admin" Then
                    Me.objBusi.aLog(Me.lblMember_Policy_ID.Text, "Updating Dependents Details User ID : " & My.Settings.Username & " ", Conn)
                Else
                    Me.objBusi.Log(Me.lblMember_Policy_ID.Text, "Updating Dependents Details User ID : " & My.Settings.Username & " ", Conn)
                    Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblMember_Policy_ID.Text, "E", Endorsment_Changes, Now(), "", Me.dtpEffectiveDate.Value, Me.txtDependent_NRIC.Text.Trim(), "CHANGE OF DEPENDENT DETAILS", Conn)
                End If

                If sRes = "1" Then
                    MsgBox("Successfully Updated the Dependent details!")
                    Clear()
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("Error while Updating the Dependent details! or Currently our server busy please try again..")
            End Try
        End If
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