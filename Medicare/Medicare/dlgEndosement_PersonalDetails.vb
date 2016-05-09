Imports System.Windows.Forms
Public Class dlgEndosement_PersonalDetails
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_PersonalDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgEndosement_PersonalDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#End Region
#Region "DataBind Events"
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)
        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text

        If Search_Param1 = "Null" Then
            If Me.dgvPolicies.Rows.Count > 0 Then
                Me.dgvPolicies.DataSource = Nothing
                Me.dgvPolicies.DataMember = Nothing
            End If
            Me.txtFileNo.Clear()
            Me.txtName.Clear()
            Me.txtNRIC.Clear()
            Me.txtL2_Plan_Code.Clear()
            Me.txtRequested_Amount.Clear()
            Me.txtPolicy_EffectiveDate.Clear()
            Exit Sub
        Else


            cmdSelect_Member.CommandText = "SELECT ID, Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, " & _
                                           "Deduction_Amount, Agent_Code, Submission_Date, Effective_Date, " & _
                                           "Cancellation_Date, Policy_No, Title, Birth_Date, Race, Marital_Status, " & _
                                           "Sex, Member_Policy_ID ," & _
                                           "Phone_Mobile , Phone_Hse,Phone_off " & _
                                           "FROM vi_Member_Policy_with_PersonalDetails " & _
                                           "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                           "ORDER BY Deduction_Code"
        End If

        Dim da_Member_PostalAddress As New SqlDataAdapter(cmdSelect_Member)
        Dim ds_MemberInfo As New DataSet
        da_Member_PostalAddress.Fill(ds_MemberInfo, "vi_Member_Policy_with_PersonalDetails")

        With Me.dgvPolicies
            .DataSource = ds_MemberInfo
            .DataMember = "vi_Member_Policy_with_PersonalDetails"

            .Columns(0).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).Visible = False

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

            .Columns(5).DefaultCellStyle.Format = "###.##"

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
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub tsb_Filter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
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
        Me.lblMember_ID.Text = ""
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtL2_Plan_Code.Clear()
        Me.txtRequested_Amount.Clear()
        Me.txtPolicy_EffectiveDate.Clear()
        Me.txtMember_Title.Clear()
        Me.txtMember_Name.Clear()
        Me.dtpMember_DOB.Value = Now()
        Me.txtMember_Age.Clear()
        Me.rdiMember_Race_Malay.Checked = False
        Me.rdiMember_Race_Chinese.Checked = False
        Me.rdiMember_Race_Indian.Checked = False
        Me.rdiMember_Race_Others.Checked = False
        Me.rdiMember_MaritalStatus_Single.Checked = False
        Me.rdiMember_MaritalStatus_Married.Checked = False
        Me.rdiMember_MaritalStatus_Widowed.Checked = False
        Me.rdiMember_MaritalStatus_Divorced.Checked = False
        Me.rdiMember_Sex_Male.Checked = False
        Me.rdiMember_Sex_Female.Checked = False
        Me.txtRemark.Clear()
        Me.lblMemberPolicy_ID.Text = ""

        If e.RowIndex = -1 Then
            Exit Sub
        Else
            With Me.dgvPolicies.Rows(e.RowIndex)
                Me.lblMember_ID.Text = .Cells(0).Value.ToString.Trim
                Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                Me.txtName.Text = .Cells(2).Value.ToString.Trim
                Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                Me.txtL2_Plan_Code.Text = .Cells(4).Value.ToString.Trim
                If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                    Me.txtRequested_Amount.Text = Format(.Cells(5).Value, "#,##0.00")
                End If
                If Len(.Cells(8).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_EffectiveDate.Text = Format(.Cells(8).Value, "dd/MM/yyyy")
                End If

                Me.txtMember_Title.Text = .Cells(11).Value.ToString.Trim & " "
                Me.txtMember_Name.Text = .Cells(2).Value.ToString.Trim
                If Len(.Cells(12).Value.ToString.Trim) > 0 Then
                    Me.dtpMember_DOB.Value = .Cells(12).Value
                    Me.txtMember_Age.Text = Now().Year - Me.dtpMember_DOB.Value.Year
                End If

                If Len(.Cells(13).Value.ToString.Trim) > 0 Then
                    Select Case .Cells(13).Value.ToString.Trim
                        Case "M"
                            Me.rdiMember_Race_Malay.Checked = True
                        Case "C"
                            Me.rdiMember_Race_Chinese.Checked = True
                        Case "I"
                            Me.rdiMember_Race_Indian.Checked = True
                        Case "O"
                            Me.rdiMember_Race_Others.Checked = True
                    End Select
                End If

                If Len(.Cells(14).Value.ToString.Trim) > 0 Then
                    Select Case .Cells(14).Value.ToString.Trim
                        Case "S"
                            Me.rdiMember_MaritalStatus_Single.Checked = True
                        Case "M"
                            Me.rdiMember_MaritalStatus_Married.Checked = True
                        Case "W"
                            Me.rdiMember_MaritalStatus_Widowed.Checked = True
                        Case "D"
                            Me.rdiMember_MaritalStatus_Divorced.Checked = True
                    End Select
                End If

                If Len(.Cells(15).Value.ToString.Trim) > 0 Then
                    Select Case .Cells(15).Value
                        Case True
                            Me.rdiMember_Sex_Male.Checked = True
                        Case False
                            Me.rdiMember_Sex_Female.Checked = True
                    End Select
                End If

                Me.lblMemberPolicy_ID.Text = .Cells(16).Value.ToString.Trim
                txtPhone_MobileNo.Text = .Cells(17).Value.ToString.Trim
                txtPhone_Hse.Text = .Cells(18).Value.ToString.Trim
                txtPhone_Office.Text = .Cells(19).Value.ToString.Trim
            End With
        End If
    End Sub
    Private Sub btnTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitle.Click
        Dim frmSearch_Title As New frmSearch_Param

        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtMember_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        MsgBox("Endorsement successfully.")
                    Else
                        MsgBox("Error in endorsing this record.")
                    End If
                Case 7
                    Exit Sub
            End Select
            Me.Close()
        End If
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Sub dtpMember_DOB_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpMember_DOB.Leave
        Me.txtMember_Age.Text = Now().Year - Me.dtpMember_DOB.Value.Year
    End Sub
    Private Function Verify_Endorsement_Details() As Boolean
        If Len(Me.txtMember_Title.Text.Trim) = 0 Then
            MsgBox("Please do select the Policy Holder's Title.")
            Me.btnTitle.Focus()
            Return False
        End If

        If Len(Me.txtMember_Name.Text.Trim) = 0 Then
            MsgBox("Please do key in Policy Holder's Full Name.")
            Me.txtMember_Name.Focus()
            Return False
        End If

        If Me.dtpMember_DOB.Value = Now() Then
            MsgBox("Please do select Policy Holder's Date of Birth.")
            Me.dtpMember_DOB.Focus()
            Return False
        ElseIf Me.dtpMember_DOB.Value >= Today() Then
            MsgBox("Please do select Policy Holder's Date of Birth Within Current Date.")
            Me.dtpMember_DOB.Focus()
            Return False
        End If

        If Me.rdiMember_Race_Malay.Checked = False Then
            If Me.rdiMember_Race_Chinese.Checked = False Then
                If Me.rdiMember_Race_Indian.Checked = False Then
                    If Me.rdiMember_Race_Others.Checked = False Then
                        MsgBox("Please do select Policy Holder's Race.")
                        Return False
                    End If
                End If
            End If
        End If

        If Me.rdiMember_Sex_Male.Checked = False Then
            If Me.rdiMember_Sex_Female.Checked = False Then
                MsgBox("Please do select Policy Holder's Sex.")
                Return False
            End If
        End If

        Return True
    End Function
    Private Function Endorse_Changes() As Boolean
        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT ID, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                       " Phone_Mobile, Phone_Hse, Phone_off  FROM dt_Member " & _
                                       "WHERE ID = '" & Me.lblMember_ID.Text.Trim & "'"
        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)

        Dim cmdUpdate_Member As SqlCommandBuilder
        cmdUpdate_Member = New SqlCommandBuilder(da_Member)

        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)

        Dim ds_Endorsement As New DataSet

        Try
            da_Member.Fill(ds_Endorsement, "dt_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")

            With ds_Endorsement.Tables("dt_Member").Rows(0)
                .Item("Title") = Me.txtMember_Title.Text.Trim
                .Item("Full_Name") = Me.txtMember_Name.Text.Trim
                If Not Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim = "" Then
                    If Me.dtpMember_DOB.Value.Date <> Convert.ToDateTime(Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim).Date Then
                        .Item("Birth_Date") = Me.dtpMember_DOB.Value
                    End If
                Else
                    .Item("Birth_Date") = Me.dtpMember_DOB.Value
                End If
                If Me.rdiMember_Race_Malay.Checked = True Then
                    .Item("Race") = "M"
                ElseIf Me.rdiMember_Race_Chinese.Checked = True Then
                    .Item("Race") = "C"
                ElseIf Me.rdiMember_Race_Indian.Checked = True Then
                    .Item("Race") = "I"
                ElseIf Me.rdiMember_Race_Others.Checked = True Then
                    .Item("Race") = "O"
                End If

                If Me.rdiMember_MaritalStatus_Single.Checked = True Then
                    .Item("Marital_Status") = "S"
                ElseIf Me.rdiMember_MaritalStatus_Married.Checked = True Then
                    .Item("Marital_Status") = "M"
                ElseIf Me.rdiMember_MaritalStatus_Widowed.Checked = True Then
                    .Item("Marital_Status") = "W"
                ElseIf Me.rdiMember_MaritalStatus_Divorced.Checked = True Then
                    .Item("Marital_Status") = "D"
                End If

                If Me.rdiMember_Sex_Male.Checked = True Then
                    .Item("Sex") = 1
                ElseIf Me.rdiMember_Sex_Female.Checked = True Then
                    .Item("Sex") = 0
                End If
                .Item("Phone_Mobile") = txtPhone_MobileNo.Text.ToString.Trim()
                .Item("Phone_Hse") = txtPhone_Hse.Text.ToString.Trim()
                .Item("Phone_off") = txtPhone_Office.Text.ToString.Trim()
            End With

            da_Member.Update(ds_Endorsement, "dt_Member")

            Dim var_Change_Remark As String = ""
            Dim var_Title As String = ""
            Dim var_Name As String = ""
            Dim var_Race As String = ""
            Dim var_Marital_Status As String = ""
            Dim var_Sex As Boolean

            If Me.txtMember_Title.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim) = 0 Then
                    var_Title = "(BLANK)"
                Else
                    var_Title = Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim
                End If

                var_Change_Remark = "Change of Title from: " & var_Title.Trim & _
                                    " to " & Me.txtMember_Title.Text.Trim & ". "
            End If

            If Me.txtMember_Name.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(2).Value.ToString.Trim.ToUpper Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(2).Value.ToString.Trim) = 0 Then
                    var_Name = "(BLANK)"
                Else
                    var_Name = Me.dgvPolicies.SelectedRows(0).Cells(2).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Name from: " & var_Name.Trim & _
                                    " to " & Me.txtMember_Name.Text.Trim & ". "
            End If

            If Len(Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim) = 0 Then
                var_Change_Remark = var_Change_Remark.Trim & " Change of Date of Birth from: (BLANK)" & _
                        " to " & Format(Me.dtpMember_DOB.Value, "dd/MM/yyyy") & ". "
            Else
                If Me.dtpMember_DOB.Value.Date <> Convert.ToDateTime(Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim).Date Then
                    If Len(Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim) = 0 Then
                        var_Change_Remark = var_Change_Remark.Trim & " Change of Date of Birth from: (BLANK)" & _
                        " to " & Format(Me.dtpMember_DOB.Value, "dd/MM/yyyy") & ". "
                    Else
                        var_Change_Remark = var_Change_Remark.Trim & " Change of Date of Birth from: " & _
                                            Format(Me.dgvPolicies.SelectedRows(0).Cells(12).Value, "dd/MM/yyyy") & _
                                            " to " & Format(Me.dtpMember_DOB.Value, "dd/MM/yyyy") & ". "
                    End If
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

            If var_Race.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim) = 0 Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Race from: (BLANK) " & _
                                        " to " & var_Race.Trim & ". "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Race from: " & _
                                        Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim & _
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

            If var_Marital_Status.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim) = 0 Then
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Marital Status from: (BLANK) " & _
                                        " to " & var_Marital_Status.Trim & ". "
                Else
                    var_Change_Remark = var_Change_Remark.Trim & " Change of Marital Status from: " & _
                                        Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim & _
                                        " to " & var_Marital_Status.Trim & ". "
                End If
            End If

            If Me.rdiMember_Sex_Male.Checked = True Then
                var_Sex = True
            ElseIf Me.rdiMember_Sex_Female.Checked = True Then
                var_Sex = False
            End If

            If Len(Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString.Trim) > 0 Then
                If var_Sex <> Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString Then
                    If Me.dgvPolicies.SelectedRows(0).Cells(15).Value = True Then
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
            Dim sMobileNo, sPhoneHouse, sOfficeNo As String
            If Me.txtPhone_Hse.Text.Trim() <> Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim) = 0 Then
                    sPhoneHouse = "(BLANK)"
                Else
                    sPhoneHouse = Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim
                End If

                var_Change_Remark = "Change of House contact number from: " & sPhoneHouse.Trim & _
                                    " to " & Me.txtPhone_Hse.Text.Trim & ". "
            End If

            If Me.txtPhone_MobileNo.Text.Trim() <> Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim) = 0 Then
                    sMobileNo = "(BLANK)"
                Else
                    sMobileNo = Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim
                End If

                var_Change_Remark = "Change of Mobile Number from: " & sMobileNo.Trim & _
                                    " to " & Me.txtPhone_MobileNo.Text.Trim & ". "
            End If

            If Me.txtPhone_Office.Text.Trim() <> Me.dgvPolicies.SelectedRows(0).Cells(19).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(19).Value.ToString.Trim) = 0 Then
                    sOfficeNo = "(BLANK)"
                Else
                    sOfficeNo = Me.dgvPolicies.SelectedRows(0).Cells(19).Value.ToString.Trim
                End If

                var_Change_Remark = "Change of Office contact number from: " & sOfficeNo.Trim & _
                                    " to " & Me.txtPhone_Office.Text.Trim & ". "
            End If

            Dim dr_Member_Endorsement_New As DataRow
            dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow

            With dr_Member_Endorsement_New
                .Item("Member_ID") = Me.lblMember_ID.Text.Trim
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "E"
                .Item("Endorsement_Detail") = var_Change_Remark.Trim
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("Remark") = Me.txtRemark.Text.Trim
                .Item("TRANS_TYPE") = "CHANGE OF PERSONAL DETAILS"
                .Item("IC") = Me.txtNRIC.Text.Trim()
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Effective_Date") = dtpEffective_Date.Value
            End With

            ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
            da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")
            Me.objBusi.Log(Me.lblMemberPolicy_ID.Text.Trim, "Changes  : " & var_Change_Remark.Trim & " ***  Changed By User ID : " & My.Settings.Username & " ", Conn)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
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
End Class
