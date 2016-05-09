Public Class grdProposer
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub grdProposer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub grdProposer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.SplitContainer2.Panel2Collapsed = True
        Select Case Me.lblForm_Flag.Text
            Case "0"
                Me.btnConversion.Enabled = False
                Me.btnConversion.Visible = False

                Populate_Proposers2Verify("U")
            Case "1"
                Me.btnConversion.Enabled = True
                Me.btnConversion.Visible = True

                Populate_VerifiedProposer("U")
            Case "2"
                Me.btnConversion.Enabled = False
                Me.btnConversion.Visible = False

                Populate_Submitted2Angkasa_Proposers("U")
            Case "3"
                Me.btnConversion.Enabled = False
                Me.btnConversion.Visible = False
                Populate_AllProposers("U")
            Case Else
                MsgBox("Error in populating grid")
        End Select
    End Sub
#End Region
#Region "Data Bind"
    Private Sub Populate_Proposers2Verify(ByVal var_filter As Char)
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text


        Dim ds_Search_Param As New DataSet

        Select Case var_filter
            Case "U"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Special_Promo FROM dt_Proposer " & _
                                                  "WHERE Status = '0' AND PLAN_CODE!='PWRONGCODE' " & _
                                                  "ORDER BY Full_Name"
            Case "I"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Special_Promo FROM dt_Proposer " & _
                                                  "WHERE Status = '0' AND PLAN_CODE!='PWRONGCODE' AND IC_New LIKE '" & Me.txtFind_String.Text.Trim & "%' " & _
                                                  "ORDER BY Full_Name"
            Case "N"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Special_Promo FROM dt_Proposer " & _
                                                  "WHERE Status = '0' AND PLAN_CODE!='PWRONGCODE' AND Full_Name LIKE '%" & Me.txtFind_String.Text.Trim & "%'" & _
                                                  "ORDER BY Full_Name"
        End Select


        Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)


        da_Proposer.Fill(ds_Search_Param, "dt_Proposer")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Proposer"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Title"
                .Columns(2).HeaderText = "Full Name As in NRIC"
                .Columns(3).HeaderText = "New I/C No"
                .Columns(4).HeaderText = "State"
                .Columns(5).HeaderText = "Plan Code"
                .Columns(6).HeaderText = "Plan Code (Level 2)"
                .Columns(7).HeaderText = "Special Promo"
                .Columns(2).Width = 300

            End With
            Me.cmbFind_Para.Enabled = True
            Me.txtFind_String.Enabled = True
            Me.btnFind.Enabled = True
        Else
            If var_filter = "U" Then
                MsgBox("No Proposers to be Verify.", MsgBoxStyle.Information, "Verify Proposer")
            Else
                MsgBox("No Proposers match to the search criteria.", MsgBoxStyle.Information, "Verify Proposer")
                Me.dgvFind_Result.DataMember = ""
            End If

        End If
    End Sub
    Private Sub Populate_VerifiedProposer(ByVal var_filter As Char)
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text


        Dim ds_Search_Param As New DataSet

        Select Case var_filter
            Case "U"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Decline_Reason, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Status Like '1%' AND PLAN_CODE!='PWRONGCODE' " & _
                                                  "ORDER BY Full_Name"
            Case "I"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Decline_Reason, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Status Like '1%' AND PLAN_CODE!='PWRONGCODE' AND IC_New LIKE '" & Me.txtFind_String.Text.Trim & "%' " & _
                                                  "ORDER BY Full_Name"
            Case "N"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status,Decline_Reason, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Status Like '1%' AND PLAN_CODE!='PWRONGCODE' AND Full_Name LIKE '%" & Me.txtFind_String.Text.Trim & "%'" & _
                                                  "ORDER BY Full_Name"
        End Select


        Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)


        da_Proposer.Fill(ds_Search_Param, "dt_Proposer")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Proposer"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Title"
                .Columns(2).HeaderText = "Full Name As in NRIC"
                .Columns(3).HeaderText = "New I/C No"
                .Columns(4).HeaderText = "State"
                .Columns(5).HeaderText = "Plan Code"
                .Columns(6).HeaderText = "Plan Code (Level 2)"
                .Columns(7).HeaderText = "Status"
                .Columns(8).HeaderText = "Remarks"
                .Columns(9).HeaderText = "File No"
                .Columns(2).Width = 300

            End With
            Me.cmbFind_Para.Enabled = True
            Me.txtFind_String.Enabled = True
            Me.btnFind.Enabled = True
        Else
            If var_filter = "U" Then
                MsgBox("No Verified Proposers.", MsgBoxStyle.Information, "Verified Proposer")
            Else
                MsgBox("No Proposers match to the search criteria.", MsgBoxStyle.Information, "Verified Proposer")
                Me.dgvFind_Result.DataMember = ""
            End If
        End If
    End Sub
    Private Sub Populate_Submitted2Angkasa_Proposers(ByVal var_filter As Char)
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text


        Dim ds_Search_Param As New DataSet

        Select Case var_filter
            Case "U"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Submission_Batch_No = '" & Me.lblSubmission_Batch_No.Text.Trim & "' " & _
                                                  "ORDER BY Angkasa_FileNo"
            Case "I"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Submission_Batch_No = '" & Me.lblSubmission_Batch_No.Text.Trim & "' AND IC_New LIKE '" & Me.txtFind_String.Text.Trim & "%' " & _
                                                  "ORDER BY Angkasa_FileNo"
            Case "N"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Angkasa_FileNo FROM dt_Proposer " & _
                                                  "WHERE Submission_Batch_No = '" & Me.lblSubmission_Batch_No.Text.Trim & "' AND Full_Name LIKE '%" & Me.txtFind_String.Text.Trim & "%'" & _
                                                  "ORDER BY Angkasa_FileNo"
        End Select


        Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)


        da_Proposer.Fill(ds_Search_Param, "dt_Proposer")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Proposer"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Title"
                .Columns(2).HeaderText = "Full Name As in NRIC"
                .Columns(3).HeaderText = "New I/C No"
                .Columns(4).HeaderText = "State"
                .Columns(5).HeaderText = "Plan Code"
                .Columns(6).HeaderText = "Plan Code (Level 2)"
                .Columns(7).HeaderText = "Status"
                .Columns(8).HeaderText = "File No"
                .Columns(2).Width = 300

            End With
            Me.cmbFind_Para.Enabled = True
            Me.txtFind_String.Enabled = True
            Me.btnFind.Enabled = True
        Else
            If var_filter = "U" Then
                MsgBox("No Verified Proposers.", MsgBoxStyle.Information, "Verified Proposer")
            Else
                MsgBox("No Proposers match to the search criteria.", MsgBoxStyle.Information, "Verified Proposer")
                Me.dgvFind_Result.DataMember = ""
            End If
        End If
    End Sub
    Private Sub Populate_AllProposers(ByVal var_filter As Char)
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text

        Dim ds_Search_Param As New DataSet
        Select Case var_filter
            Case "U"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status, Decline_Reason, Angkasa_FileNo, Submission_Batch_No FROM dt_Proposer " & _
                                                  "ORDER BY Full_Name"
            Case "I"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status,Decline_Reason, Angkasa_FileNo,Submission_Batch_No FROM dt_Proposer " & _
                                                  "WHERE IC_New LIKE '" & Me.txtFind_String.Text.Trim & "%' " & _
                                                  "ORDER BY Full_Name"
            Case "N"
                cmdSearch_Parameter.CommandText = "SELECT ID, Title, Full_Name, IC_New, State, Plan_Code, " & _
                                                  "Level2_Plan_Code, Status,Decline_Reason, Angkasa_FileNo, Submission_Batch_No FROM dt_Proposer " & _
                                                  "WHERE Full_Name LIKE '%" & Me.txtFind_String.Text.Trim & "%' " & _
                                                  "ORDER BY Full_Name"
        End Select

        Dim da_Proposer As New SqlDataAdapter(cmdSearch_Parameter)

        da_Proposer.Fill(ds_Search_Param, "dt_Proposer")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Proposer"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Title"
                .Columns(2).HeaderText = "Full Name As in NRIC"
                .Columns(3).HeaderText = "New I/C No"
                .Columns(4).HeaderText = "State"
                .Columns(5).HeaderText = "Plan Code"
                .Columns(6).HeaderText = "Plan Code (Level 2)"
                .Columns(7).HeaderText = "Status"
                .Columns(8).HeaderText = "Remarks"
                .Columns(9).HeaderText = "File No"
                .Columns(10).HeaderText = "Submission Batch No"
                .Columns(2).Width = 300

            End With
            Me.cmbFind_Para.Enabled = True
            Me.txtFind_String.Enabled = True
            Me.btnFind.Enabled = True
        Else
            If var_filter = "U" Then
                MsgBox("No Proposers.", MsgBoxStyle.Information, "View All Proposer")
            Else
                MsgBox("No Proposers match to the search criteria.", MsgBoxStyle.Information, "View All Proposer")
                Me.dgvFind_Result.DataMember = ""
            End If

        End If
    End Sub

#End Region
#Region "Change Events"
    Private Sub cmbFind_Para_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFind_Para.SelectedIndexChanged
        If Me.cmbFind_Para.SelectedIndex = 2 Then
            Me.txtFind_String.Clear()
            Me.txtFind_String.Enabled = False
        Else
            Me.txtFind_String.Enabled = True
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If Me.cmbFind_Para.SelectedIndex <> 2 Then
            If Len(Me.txtFind_String.Text.Trim) = 0 Then
                MsgBox("Search String is Empty")
                Exit Sub
            Else

                Select Case Me.lblForm_Flag.Text
                    Case "0"
                        Select Case Me.cmbFind_Para.SelectedIndex
                            Case 0
                                Populate_Proposers2Verify("I")
                            Case 1
                                Populate_Proposers2Verify("N")
                            Case Else
                                Populate_Proposers2Verify("U")
                        End Select
                    Case "1"
                        Select Case Me.cmbFind_Para.SelectedIndex
                            Case 0
                                Populate_VerifiedProposer("I")
                            Case 1
                                Populate_VerifiedProposer("N")
                            Case Else
                                Populate_VerifiedProposer("U")
                        End Select
                    Case "2"
                        Select Case Me.cmbFind_Para.SelectedIndex
                            Case 0
                                Populate_Submitted2Angkasa_Proposers("I")
                            Case 1
                                Populate_Submitted2Angkasa_Proposers("N")
                            Case Else
                                Populate_Submitted2Angkasa_Proposers("U")
                        End Select
                    Case "3"
                        Select Case Me.cmbFind_Para.SelectedIndex
                            Case 0
                                Populate_AllProposers("I")
                            Case 1
                                Populate_AllProposers("N")
                            Case Else
                                Populate_AllProposers("U")
                        End Select
                    Case Else
                        MsgBox("Error in populating grid")
                End Select
            End If
        Else
            Select Case Me.lblForm_Flag.Text
                Case "0"
                    Populate_Proposers2Verify("U")
                Case "1"
                    Populate_VerifiedProposer("U")
                Case "2"
                    Populate_Submitted2Angkasa_Proposers("U")
                Case "3"
                    Populate_AllProposers("U")
            End Select

            Me.cmbFind_Para.SelectedIndex = -1
        End If
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.dgvFind_Result.SelectedRows.Count > 0 Then
            Dim frm_Proposer_Verify As New New_Proposer
            If lblVerficationCheck.Text = "VPRINT" Then
                frm_Proposer_Verify.lblVerficationCheck.Text = "VPRINT"
            End If
            Select Case Me.lblForm_Flag.Text
                Case "0"
                    frm_Proposer_Verify.Text = "New Proposer to be verify"
                    frm_Proposer_Verify.lblForm_Flag.Text = "V"
                Case "1"
                    frm_Proposer_Verify.Text = "Verified Proposer"
                    frm_Proposer_Verify.lblForm_Flag.Text = "View"
                Case "2"
                    Dim var_response As String
                    var_response = InputBox("Please key in the password to unlock this record for editing purpose.")

                    If var_response.Trim = "medicare" Then
                        frm_Proposer_Verify.Text = "Post Proposal Submission Modification"
                        frm_Proposer_Verify.lblForm_Flag.Text = "Unlock"
                    Else
                        If Len(var_response.Trim) > 0 Then
                            MsgBox("Error in password, please do try again. Thanks.")
                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    End If
                Case "3"
                    frm_Proposer_Verify.Text = "Proposer Details (READ ONLY)"
                    frm_Proposer_Verify.lblForm_Flag.Text = "Readonly"
                Case Else
                    MsgBox("Error in populating grid")
            End Select
            frm_Proposer_Verify.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim
            frm_Proposer_Verify.Show()

            Select Case Me.lblForm_Flag.Text
                Case "0"
                    Populate_Proposers2Verify("U")
                Case "1"
                    Populate_VerifiedProposer("U")
                Case "2"
                    Populate_Submitted2Angkasa_Proposers("U")
                Case "3"
                    Populate_AllProposers("U")
                Case Else
                    MsgBox("Error in populating grid")
            End Select
        End If
    End Sub
    Private Sub btnConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConversion.Click
        If Me.dgvFind_Result.SelectedRows.Count > 0 Then
            Select Case Me.dgvFind_Result.SelectedRows(0).Cells(7).Value.ToString.Trim
                Case "1A"
                    Dim dlg_Convert_Acknowledgement As New dlgConversion_Proposer_Status
                    dlg_Convert_Acknowledgement.rdiAcknowledgement.Checked = True
                    dlg_Convert_Acknowledgement.rdiAcknowledgement_New.AutoCheck = False
                    dlg_Convert_Acknowledgement.lblStatus.Text = "1A"
                    dlg_Convert_Acknowledgement.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim

                    If dlg_Convert_Acknowledgement.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    Populate_VerifiedProposer("U")
                Case "1U"
                    Dim dlg_Convert_Underwriting As New dlgConversion_Proposer_Status
                    dlg_Convert_Underwriting.rdiUnderwriting.Checked = True
                    dlg_Convert_Underwriting.rdiUnderwriting_New.AutoCheck = False
                    dlg_Convert_Underwriting.lblStatus.Text = "1U"
                    dlg_Convert_Underwriting.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim

                    If dlg_Convert_Underwriting.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    Populate_VerifiedProposer("U")
                Case "1D"
                    Dim dlg_Convert_Deferment As New dlgConversion_Proposer_Status
                    dlg_Convert_Deferment.rdiDeferment.Checked = True
                    dlg_Convert_Deferment.lblStatus.Text = "1D"
                    dlg_Convert_Deferment.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim

                    If dlg_Convert_Deferment.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    Populate_VerifiedProposer("U")
                Case "1R"
                    Dim dlg_Convert_Deferment As New dlgConversion_Proposer_Status
                    dlg_Convert_Deferment.rdiReject.Checked = True
                    dlg_Convert_Deferment.lblStatus.Text = "1R"
                    dlg_Convert_Deferment.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim

                    If dlg_Convert_Deferment.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    Populate_VerifiedProposer("U")
                Case "1PU"
                    Dim dlg_Convert_Deferment As New dlgConversion_Proposer_Status
                    dlg_Convert_Deferment.rbUnderwritingPU.Checked = True
                    dlg_Convert_Deferment.lblStatus.Text = "1PU"
                    dlg_Convert_Deferment.lblProposer_ID.Text = Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim

                    If dlg_Convert_Deferment.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If

                    Populate_VerifiedProposer("U")
                Case Else

            End Select
        End If
    End Sub
#End Region
End Class