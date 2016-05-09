Public Class fUserAccess
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fUserAccess_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fUserAccess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindData()
        Me.cbStatus.SelectedIndex = 0
        Me.gbAddUsers.Visible = False
    End Sub
    Private Function BindData() As String
        Dim dt As New DataTable
        dt = _objBusi.getUsers("", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvUsers
                .DataSource = dt
                .Columns(0).Visible = False
                .Columns(3).Visible = False
                .Columns(1).HeaderText = "Full Name"
                .Columns(2).HeaderText = "USER ID"
                .Columns(4).HeaderText = "Expiry Date"
                .Columns(5).HeaderText = "Modules"
                .Columns(6).HeaderText = "Sub Modules"
                .Columns(7).HeaderText = "Status"
            End With
        End If
    End Function
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            If chkValidation() Then
                UpdateUser()
                Me.btnNew.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnDelete.Enabled = True
            End If
        Else

            If chkValidation() Then
                InsertUser()
                Me.btnNew.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnDelete.Enabled = True
            End If

        End If
    End Sub
#Region "INSERT USERS"
    Private Sub InsertUser()

        Dim dt As New DataTable
        dt = _objBusi.chkUser("USER", Me.txtFullName.Text.Trim(), Conn)
        If dt.Rows.Count > 0 Then
            MsgBox("This User Name already exits")
            Exit Sub
        End If
        
        Dim M, SM, Proposer_M, Proposer_SM, Member_M, Member_SM, Premium_M, Premium_SM, Reports_M, Reports_SM, Admin_M, Admin_SM, Status As String
        Status = Me.cbStatus.SelectedIndex
        Select Case Status
            Case "0"
                Status = "Active"
            Case "1"
                Status = "Inactive"
        End Select

        If Me.chkProposerModule.Checked Then
            If Me.chkProposerLevel.CheckedItems.Count > 0 Then
                Proposer_M = "P0"
                For i As Integer = 0 To Me.chkProposerLevel.Items.Count - 1
                    If Me.chkProposerLevel.GetItemChecked(i) Then
                        Proposer_SM = Proposer_SM & "P" & Me.chkProposerLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Proposer_M = "P1"
            End If
        End If

        If Me.chkMemberModule.Checked Then
            If Me.chkMemberLevel.CheckedItems.Count > 0 Then
                Member_M = "M0"
                For i As Integer = 0 To Me.chkMemberLevel.Items.Count - 1
                    If Me.chkMemberLevel.GetItemChecked(i) Then
                        Member_SM = Member_SM & "M" & Me.chkMemberLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Member_M = "M1"
            End If
        End If

        If Me.chkPremiumModule.Checked Then
            If Me.chkPremiumLevel.CheckedItems.Count > 0 Then
                Premium_M = "PRE0"
                For i As Integer = 0 To Me.chkPremiumLevel.Items.Count - 1
                    If Me.chkPremiumLevel.GetItemChecked(i) Then
                        Premium_SM = Premium_SM & "PRE" & Me.chkPremiumLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Premium_M = "PRE1"
            End If
        End If

        If Me.chkCS.Checked Then
            If Me.chkCSLevel.CheckedItems.Count > 0 Then
                Reports_M = "CS0"
                For i As Integer = 0 To Me.chkCSLevel.Items.Count - 1
                    If Me.chkCSLevel.GetItemChecked(i) Then
                        Reports_SM = Reports_SM & "CS" & Me.chkCSLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Reports_M = "CS1"
            End If
        End If

        If Me.chkAdminModule.Checked Then
            If Me.chkAdminLevel.CheckedItems.Count > 0 Then
                Admin_M = "A0"
                For i As Integer = 0 To Me.chkAdminLevel.Items.Count - 1
                    If Me.chkAdminLevel.GetItemChecked(i) Then
                        Admin_SM = Admin_SM & "A" & Me.chkAdminLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Admin_M = "A1"
            End If
        End If
        M = Proposer_M & "," & Member_M & "," & Premium_M & "," & Reports_M & "," & Admin_M
        SM = Proposer_SM & Member_SM & Premium_SM & Reports_SM & Admin_SM
        Dim sRes As String
        sRes = _objBusi.InsUpsUsers("INSERT", Guid.NewGuid.ToString(), Me.txtFullName.Text.Trim(), Me.txtUserID.Text.Trim(), Me.txtPWD.Text.Trim(), Me.dtpExpiryDate.Value, M, SM, Status, My.Settings.Username, Conn)
        If sRes = "Done" Then
            MsgBox("Successfully Inserted User Details!")
            BindData()
            Me.gbAddUsers.Visible = False
        Else
            MsgBox("Error while Inserting User Details!")
        End If

    End Sub
#End Region
#Region "UPDATES USERS"
    Private Sub UpdateUser()

        Dim M, SM, Proposer_M, Proposer_SM, Member_M, Member_SM, Premium_M, Premium_SM, Reports_M, Reports_SM, Admin_M, Admin_SM, Status As String
        Status = Me.cbStatus.SelectedIndex
        Select Case Status
            Case "0"
                Status = "Active"
            Case "1"
                Status = "Inactive"
        End Select

        If Me.chkProposerModule.Checked Then
            If Me.chkProposerLevel.CheckedItems.Count > 0 Then
                Proposer_M = "P0"
                For i As Integer = 0 To Me.chkProposerLevel.Items.Count - 1
                    If Me.chkProposerLevel.GetItemChecked(i) Then
                        Proposer_SM = Proposer_SM & "P" & Me.chkProposerLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Proposer_M = "P1"
            End If
        End If

        If Me.chkMemberModule.Checked Then
            If Me.chkMemberLevel.CheckedItems.Count > 0 Then
                Member_M = "M0"
                For i As Integer = 0 To Me.chkMemberLevel.Items.Count - 1
                    If Me.chkMemberLevel.GetItemChecked(i) Then
                        Member_SM = Member_SM & "M" & Me.chkMemberLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Member_M = "M1"
            End If
        End If

        If Me.chkPremiumModule.Checked Then
            If Me.chkPremiumLevel.CheckedItems.Count > 0 Then
                Premium_M = "PRE0"
                For i As Integer = 0 To Me.chkPremiumLevel.Items.Count - 1
                    If Me.chkPremiumLevel.GetItemChecked(i) Then
                        Premium_SM = Premium_SM & "PRE" & Me.chkPremiumLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Premium_M = "PRE1"
            End If
        End If

        If Me.chkCS.Checked Then
            If Me.chkCSLevel.CheckedItems.Count > 0 Then
                Reports_M = "CS0"
                For i As Integer = 0 To Me.chkCSLevel.Items.Count - 1
                    If Me.chkCSLevel.GetItemChecked(i) Then
                        Reports_SM = Reports_SM & "CS" & Me.chkCSLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Reports_M = "CS1"
            End If
        End If

        If Me.chkAdminModule.Checked Then
            If Me.chkAdminLevel.CheckedItems.Count > 0 Then
                Admin_M = "A0"
                For i As Integer = 0 To Me.chkAdminLevel.Items.Count - 1
                    If Me.chkAdminLevel.GetItemChecked(i) Then
                        Admin_SM = Admin_SM & "A" & Me.chkAdminLevel.GetItemText(i) & ","
                    End If
                Next i
            Else
                Admin_M = "A1"
            End If
        End If
        M = Proposer_M & "," & Member_M & "," & Premium_M & "," & Reports_M & "," & Admin_M
        SM = Proposer_SM & Member_SM & Premium_SM & Reports_SM & Admin_SM
        Dim sRes As String
        sRes = _objBusi.InsUpsUsers("UPDATE", lblID.Text.ToString(), Me.txtFullName.Text.Trim(), Me.txtUserID.Text.Trim(), Me.txtPWD.Text.Trim(), Me.dtpExpiryDate.Value, M, SM, Status, My.Settings.Username, Conn)
        If sRes = "Done" Then
            MsgBox("Successfully Updated User Details!")
            BindData()
            Me.gbAddUsers.Visible = False
        Else
            MsgBox("Error while Updating User Details!")
        End If

    End Sub
#End Region
#Region "Validation"
    Private Function chkValidation() As Boolean
        If Len(Me.txtUserID.Text.Trim) = 0 Then
            MsgBox("Required User Full Name")
            Me.txtUserID.Focus()
            Return False
        End If
        If Len(Me.txtFullName.Text.Trim) = 0 Then
            MsgBox("Required User ID")
            Me.txtFullName.Focus()
            Return False
        End If
        If Len(Me.txtPWD.Text.Trim) = 0 Then
            MsgBox("Required User ID")
            Me.txtPWD.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Modules Check Change"
    Private Sub chkProposerModule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProposerModule.CheckedChanged
        If chkProposerModule.Checked = True Then
            chkProposerLevel.Visible = True
        Else
            chkProposerLevel.Visible = False
        End If
    End Sub

    Private Sub chkMemberModule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMemberModule.CheckedChanged
        If chkMemberModule.Checked = True Then
            chkMemberLevel.Visible = True
        Else
            chkMemberLevel.Visible = False
        End If
    End Sub
    Private Sub chkPremiumModule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPremiumModule.CheckedChanged
        If chkPremiumModule.Checked = True Then
            chkPremiumLevel.Visible = True
        Else
            chkPremiumLevel.Visible = False
        End If
    End Sub

    Private Sub chkCS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCS.CheckedChanged
        If chkCS.Checked = True Then
            chkCSLevel.Visible = True
        Else
            chkCSLevel.Visible = False
        End If
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.gbAddUsers.Visible = True
        Me.btnSubmit.Name = "Submit"
        Me.btnSubmit.Text = "Submit"
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvUsers.SelectedRows.Count > 0 Then
            Dim dt As New DataTable
            dt = _objBusi.getUsers("USEREDIT", Me.dgvUsers.SelectedRows(0).Cells(0).Value.ToString.Trim, "", Conn)
            lblID.Text = dt.Rows(0)("ID").ToString()
            Me.txtFullName.Text = dt.Rows(0)("Full_Name")
            Me.txtUserID.Text = dt.Rows(0)("UserID")
            Me.txtUserID.Enabled = False
            Me.txtPWD.Text = dt.Rows(0)("Password")
            Me.dtpExpiryDate.Value = dt.Rows(0)("Expiry_Date")
            If dt.Rows(0)("Status").ToString.Trim() = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            Dim M, SM As String
            M = dt.Rows(0)("Module")
            SM = dt.Rows(0)("Sub_Module")
            Dim oM As String()
            Dim oSM As String()
            oM = M.Split(",")
            oSM = SM.Split(",")
            For Each _M As String In M.Split(",")
                Select Case _M
                    Case "P0", "P1"
                        Me.chkProposerModule.Checked = True
                    Case "M0", "M1"
                        Me.chkMemberModule.Checked = True
                    Case "PRE0", "PRE1"
                        Me.chkPremiumModule.Checked = True
                    Case "CS0", "CS1"
                        Me.chkCS.Checked = True
                    Case "A0", "A1"
                        Me.chkAdminModule.Checked = True
                End Select
            Next
            For Each _SM As String In SM.Split(",")
                Select Case _SM
                    Case "P0"
                        Me.chkProposerLevel.SetItemChecked(0, True)
                    Case "P1"
                        Me.chkProposerLevel.SetItemChecked(1, True)
                    Case "P2"
                        Me.chkProposerLevel.SetItemChecked(2, True)
                    Case "P3"
                        Me.chkProposerLevel.SetItemChecked(3, True)
                    Case "P4"
                        Me.chkProposerLevel.SetItemChecked(4, True)
                    Case "P5"
                        Me.chkProposerLevel.SetItemChecked(5, True)
                    Case "P6"
                        Me.chkProposerLevel.SetItemChecked(6, True)
                    Case "P7"
                        Me.chkProposerLevel.SetItemChecked(7, True)
                    Case "P8"
                        Me.chkProposerLevel.SetItemChecked(8, True)
                    Case "P9"
                        Me.chkProposerLevel.SetItemChecked(9, True)
                    Case "P10"
                        Me.chkProposerLevel.SetItemChecked(10, True)
                    Case "P11"
                        Me.chkProposerLevel.SetItemChecked(11, True)
                    Case "M0"
                        Me.chkMemberLevel.SetItemChecked(0, True)
                    Case "M1"
                        Me.chkMemberLevel.SetItemChecked(1, True)
                    Case "M2"
                        Me.chkMemberLevel.SetItemChecked(2, True)
                    Case "M3"
                        Me.chkMemberLevel.SetItemChecked(3, True)
                    Case "M4"
                        Me.chkMemberLevel.SetItemChecked(4, True)
                    Case "M5"
                        Me.chkMemberLevel.SetItemChecked(5, True)
                    Case "M6"
                        Me.chkMemberLevel.SetItemChecked(6, True)
                    Case "M7"
                        Me.chkMemberLevel.SetItemChecked(7, True)
                    Case "M8"
                        Me.chkMemberLevel.SetItemChecked(8, True)
                    Case "M9"
                        Me.chkMemberLevel.SetItemChecked(9, True)
                    Case "M10"
                        Me.chkMemberLevel.SetItemChecked(10, True)
                    Case "M11"
                        Me.chkMemberLevel.SetItemChecked(11, True)
                    Case "M12"
                        Me.chkMemberLevel.SetItemChecked(12, True)
                    Case "M13"
                        Me.chkMemberLevel.SetItemChecked(13, True)
                    Case "M14"
                        Me.chkMemberLevel.SetItemChecked(14, True)
                    Case "PRE0"
                        Me.chkPremiumLevel.SetItemChecked(0, True)
                    Case "PRE1"
                        Me.chkPremiumLevel.SetItemChecked(1, True)
                    Case "PRE2"
                        Me.chkPremiumLevel.SetItemChecked(2, True)
                    Case "PRE3"
                        Me.chkPremiumLevel.SetItemChecked(3, True)
                    Case "PRE4"
                        Me.chkPremiumLevel.SetItemChecked(4, True)
                    Case "PRE5"
                        Me.chkPremiumLevel.SetItemChecked(5, True)
                    Case "PRE6"
                        Me.chkPremiumLevel.SetItemChecked(6, True)
                    Case "PRE7"
                        Me.chkPremiumLevel.SetItemChecked(7, True)
                    Case "PRE8"
                        Me.chkPremiumLevel.SetItemChecked(8, True)
                    Case "PRE9"
                        Me.chkPremiumLevel.SetItemChecked(9, True)
                    Case "PRE10"
                        Me.chkPremiumLevel.SetItemChecked(10, True)
                    Case "PRE11"
                        Me.chkPremiumLevel.SetItemChecked(11, True)
                    Case "PRE12"
                        Me.chkPremiumLevel.SetItemChecked(12, True)
                    Case "PRE13"
                        Me.chkPremiumLevel.SetItemChecked(13, True)
                    Case "PRE14"
                        Me.chkPremiumLevel.SetItemChecked(14, True)
                    Case "PRE15"
                        Me.chkPremiumLevel.SetItemChecked(15, True)
                    Case "PRE16"
                        Me.chkPremiumLevel.SetItemChecked(16, True)
                    Case "PRE17"
                        Me.chkPremiumLevel.SetItemChecked(17, True)
                    Case "PRE18"
                        Me.chkPremiumLevel.SetItemChecked(18, True)
                    Case "PRE19"
                        Me.chkPremiumLevel.SetItemChecked(19, True)
                    Case "PRE20"
                        Me.chkPremiumLevel.SetItemChecked(20, True)
                    Case "PRE21"
                        Me.chkPremiumLevel.SetItemChecked(21, True)
                    Case "PRE22"
                        Me.chkPremiumLevel.SetItemChecked(22, True)
                    Case "PRE23"
                        Me.chkPremiumLevel.SetItemChecked(23, True)
                    Case "CS0"
                        Me.chkCSLevel.SetItemChecked(0, True)
                    Case "CS1"
                        Me.chkCSLevel.SetItemChecked(1, True)
                    Case "CS2"
                        Me.chkCSLevel.SetItemChecked(2, True)
                    Case "CS3"
                        Me.chkCSLevel.SetItemChecked(3, True)
                    Case "CS4"
                        Me.chkCSLevel.SetItemChecked(4, True)
                    Case "CS5"
                        Me.chkCSLevel.SetItemChecked(5, True)
                    Case "CS6"
                        Me.chkCSLevel.SetItemChecked(6, True)
                    Case "CS7"
                        Me.chkCSLevel.SetItemChecked(7, True)
                    Case "CS8"
                        Me.chkCSLevel.SetItemChecked(8, True)
                    Case "CS9"
                        Me.chkCSLevel.SetItemChecked(9, True)
                    Case "CS10"
                        Me.chkCSLevel.SetItemChecked(10, True)
                    Case "CS11"
                        Me.chkCSLevel.SetItemChecked(11, True)
                    Case "CS12"
                        Me.chkCSLevel.SetItemChecked(12, True)
                    Case "CS13"
                        Me.chkCSLevel.SetItemChecked(13, True)
                    Case "CS14"
                        Me.chkCSLevel.SetItemChecked(14, True)
                    Case "CS15"
                        Me.chkCSLevel.SetItemChecked(15, True)
                    Case "A0"
                        Me.chkAdminLevel.SetItemChecked(0, True)
                    Case "A1"
                        Me.chkAdminLevel.SetItemChecked(1, True)
                    Case "A2"
                        Me.chkAdminLevel.SetItemChecked(2, True)
                    Case "A3"
                        Me.chkAdminLevel.SetItemChecked(3, True)
                    Case "A4"
                        Me.chkAdminLevel.SetItemChecked(4, True)
                    Case "A5"
                        Me.chkAdminLevel.SetItemChecked(5, True)
                    Case "A6"
                        Me.chkAdminLevel.SetItemChecked(6, True)
                    Case "A7"
                        Me.chkAdminLevel.SetItemChecked(7, True)
                    Case "A8"
                        Me.chkAdminLevel.SetItemChecked(8, True)
                    Case "A9"
                        Me.chkAdminLevel.SetItemChecked(9, True)
                    Case "A10"
                        Me.chkAdminLevel.SetItemChecked(10, True)
                    Case "A11"
                        Me.chkAdminLevel.SetItemChecked(11, True)
                    Case "A12"
                        Me.chkAdminLevel.SetItemChecked(12, True)
                    Case "A13"
                        Me.chkAdminLevel.SetItemChecked(13, True)
                    Case "A14"
                        Me.chkAdminLevel.SetItemChecked(14, True)
                End Select
            Next
            Me.gbAddUsers.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnEdit.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvUsers.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim sRes As String
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_Users where id='" & Me.dgvUsers.SelectedRows(0).Cells(0).Value.ToString.Trim & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted User!")
                    BindData()
                Else
                    MsgBox("Error while Deleting the User! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for delete!")
        End If
    End Sub
    Private Sub chkAdminModule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdminModule.CheckedChanged
        If chkAdminModule.Checked = True Then
            chkAdminLevel.Visible = True
        Else
            chkAdminLevel.Visible = False
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class