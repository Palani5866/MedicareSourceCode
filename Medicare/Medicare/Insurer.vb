
Public Class Insurer
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub Insurer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Insurer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        gbInsurer.Visible = False
        getInsurerdetails()
        Me.lblInsurerId.Visible = False
        Me.txtState.Enabled = False
        Me.cbStatus.SelectedIndex = 0
    End Sub
#End Region
#Region "Insert Insurer"
    Private Sub btnSubmit_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Insurer_details()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnEditContacts.Enabled = True
        Else
            Insert_Insurer_details()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnEditContacts.Enabled = True
        End If
    End Sub
    Private Sub btnCancel_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Function Insert_Insurer_details() As String
        Dim insurer_name, add1, add2, town, post_code, state, insurer_code, status, created_by, sRes, ins_id As String

        If Me.txtInsurer.Text.Trim() = "" Then
            MsgBox("Insurer Name Can't be Blank!")
            Me.txtInsurer.Focus()
            Exit Function
        End If
        If Me.txtAdd1.Text.Trim() = "" Then
            MsgBox("Address1 Can't be Blank!")
            Me.txtAdd1.Focus()
            Exit Function
        End If
        If Me.txtPostcode.Text.Trim() = "" Then
            MsgBox("Post Code Can't be Blank!")
            Me.txtPostcode.Focus()
            Exit Function
        End If
        If Me.txtInsurerCode.Text.Trim() = "" Then
            MsgBox("Insurer Code Can't be Blank!")
            Me.txtInsurerCode.Focus()
            Exit Function
        End If
        insurer_name = Me.txtInsurer.Text.Trim()
        add1 = Me.txtAdd1.Text.Trim()
        add2 = Me.txtAdd2.Text.Trim()
        town = Me.txtTown.Text.Trim()
        post_code = Me.txtPostcode.Text.Trim()
        state = Me.txtState.Text.Trim()
        insurer_code = Me.txtInsurerCode.Text.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        created_by = My.Settings.Username
        Dim _sqlCmd_Ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Try
            _sqlCmd_Ins.CommandType = CommandType.Text
            _sqlCmd_Ins.CommandText = "INSERT INTO tb_insurer (insurer_name, add1, add2, town, post_code, state, insurer_code , status, created_by, created_dt) " & _
                                                         "VALUES ('" & insurer_name & "', '" & _
                                                         add1 & "', '" & add2 & "', '" & _
                                                         town & "', '" & post_code & "', '" & _
                                                         state & "', '" & insurer_code & "', '" & _
                                                         status & "', '" & created_by & "', '" & Format(Now(), "MM/dd/yyyy") & "')"

            sRes = _sqlCmd_Ins.ExecuteNonQuery()

            If sRes = "1" Then
                clear_all()
                MsgBox("Successfully Added the Insurer!")
                gbInsurer.Visible = False
                getInsurerdetails()
            Else
                MsgBox("Error while Adding the Insurer! or Currently our server busy please try again..")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Function clear_all() As Boolean
        Me.txtInsurer.Text = ""
        Me.txtAdd1.Text = ""
        Me.txtAdd2.Text = ""
        Me.txtState.Text = ""
        Me.cbStatus.SelectedIndex = -1
    End Function
#End Region
#Region "Insurer Details"
    Private Sub getInsurerdetails()
        Dim _sqlCmdget_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _sqlCmdget_ins.CommandType = CommandType.Text
        _sqlCmdget_ins.CommandText = "SELECT tb_insurer_id, insurer_code, insurer_name, add1,  status FROM tb_insurer "
        Dim adp As New SqlDataAdapter(_sqlCmdget_ins)
        Dim ds As New DataSet
        adp.Fill(ds, "tb_insurer")
        With Me.dgvInsurer
            .DataSource = ds
            .DataMember = "tb_insurer"
            .Columns(1).Visible = False
            .Columns(2).HeaderText = "Insurer Code"
            .Columns(3).HeaderText = "Insurer Name"
            .Columns(4).HeaderText = "Address"
            .Columns(5).HeaderText = "Status"
            .Columns(0).HeaderText = "Contacts"
            .Columns("tb_insurer_id").DisplayIndex = 5
        End With
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        gbInsurer.Visible = True
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.btnAddContact.Text = "Add Contacts"
        Me.btnAddContact.Name = "Add Contacts"
        Me.lblInsurerId.Visible = False
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
        Me.btnEditContacts.Enabled = False

    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvInsurer.SelectedRows.Count > 0 Then
            Dim ins_id As Integer
            ins_id = Me.dgvInsurer.SelectedRows(0).Cells(1).Value.ToString.Trim
            Dim _sqlCmdget_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_ins.CommandType = CommandType.Text
            _sqlCmdget_ins.CommandText = "SELECT * FROM tb_insurer where tb_insurer_id='" & ins_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_ins)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_insurer")
            Me.lblInsurerId.Text = ds.Tables(0).Rows(0)("tb_insurer_id")
            Me.lblInsurerId.Visible = False
            Me.txtInsurer.Text = ds.Tables(0).Rows(0)("insurer_name")
            Me.txtAdd1.Text = ds.Tables(0).Rows(0)("add1")
            Me.txtAdd2.Text = ds.Tables(0).Rows(0)("add2")
            Me.txtTown.Text = ds.Tables(0).Rows(0)("town")
            Me.txtPostcode.Text = ds.Tables(0).Rows(0)("post_code")
            Me.txtState.Text = ds.Tables(0).Rows(0)("state")
            Me.txtInsurerCode.Text = ds.Tables(0).Rows(0)("insurer_code")
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            gbInsurer.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnAddContact.Text = "Edit Contacts"
            Me.btnAddContact.Name = "Edit Contacts"
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvInsurer.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim ins_id As Integer
                Dim sRes As String
                ins_id = Me.dgvInsurer.SelectedRows(0).Cells(1).Value.ToString.Trim
                Dim _sqlCmddel_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_ins.CommandType = CommandType.Text
                _sqlCmddel_ins.CommandText = "Delete FROM tb_insurer where tb_insurer_id='" & ins_id & "'"
                sRes = _sqlCmddel_ins.ExecuteNonQuery()

                Dim _sqlCmddel_ins1 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_ins1.CommandType = CommandType.Text
                _sqlCmddel_ins1.CommandText = "Delete FROM tb_insurer_contact_details where tb_insurer_id='" & ins_id & "'"
                _sqlCmddel_ins1.ExecuteNonQuery()

                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Insurer!")
                    getInsurerdetails()
                Else
                    MsgBox("Error while Deleting the Insurer! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for delete!")
        End If
    End Sub
    Private Sub btnAddContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContact.Click

        If Me.txtInsurer.Text.Trim() = "" Then
            MsgBox("Insurer Name Can't be Blank!")
            Me.txtInsurer.Focus()
            Exit Sub
        End If
        If Me.txtInsurerCode.Text.Trim() = "" Then
            MsgBox("Insurer Code Can't be Blank!")
            Me.txtInsurerCode.Focus()
            Exit Sub
        End If
        If Me.btnAddContact.Name = "Add Contacts" Then
            Dim Insurer_Contact_Details As New Insurer_Contact_Details
            Insurer_Contact_Details.Show()
        Else
            Dim ins_id As Integer
            ins_id = Me.lblInsurerId.Text.Trim
            Dim Insurer_Contact_Details As New Insurer_Contact_Details
            Insurer_Contact_Details.lblCContactID.Text = Me.lblInsurerId.Text.Trim
            Insurer_Contact_Details.Show()
        End If
    End Sub
    Private Sub btnEditContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditContacts.Click
        If Me.dgvInsurer.SelectedRows.Count > 0 Then
            Dim Insurer_Contact_Details As New Insurer_Contact_Details
            Insurer_Contact_Details.lblCContactID.Text = Me.dgvInsurer.SelectedRows(0).Cells(1).Value.ToString.Trim
            Insurer_Contact_Details.Show()
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub dgvInsurer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsurer.CellContentClick
        With Me.dgvInsurer
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim View_Insurer_Contacts As New View_Insurer_Contacts
                View_Insurer_Contacts.lblInsurerID.Text = .Rows(e.RowIndex).Cells(1).Value.ToString()
                View_Insurer_Contacts.Show()
            End If
        End With
    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click
        Dim frmSearch_State As New frmSearch_Param
        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()
        Me.txtState.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
#End Region
#Region "Update"
    Private Function Update_Insurer_details() As String
        Dim insurer_name, add1, add2, town, post_code, state, insurer_code, status, modified_by, sRes, ins_id As String

        If Me.txtInsurer.Text.Trim() = "" Then
            MsgBox("Insurer Name Can't be Blank!")
            Me.txtInsurer.Focus()
            Exit Function
        End If
        If Me.txtAdd1.Text.Trim() = "" Then
            MsgBox("Address1 Can't be Blank!")
            Me.txtAdd1.Focus()
            Exit Function
        End If
        If Me.txtPostcode.Text.Trim() = "" Then
            MsgBox("Post Code Can't be Blank!")
            Me.txtPostcode.Focus()
            Exit Function
        End If
        If Me.txtInsurerCode.Text.Trim() = "" Then
            MsgBox("Insurer Code Can't be Blank!")
            Me.txtInsurerCode.Focus()
            Exit Function
        End If
        insurer_name = Me.txtInsurer.Text.Trim()
        add1 = Me.txtAdd1.Text.Trim()
        add2 = Me.txtAdd2.Text.Trim()
        town = Me.txtTown.Text.Trim()
        post_code = Me.txtPostcode.Text.Trim()
        state = Me.txtState.Text.Trim()
        insurer_code = Me.txtInsurerCode.Text.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        modified_by = My.Settings.Username
        Dim _sqlCmd_Ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Try
            _sqlCmd_Ins.CommandType = CommandType.Text
            _sqlCmd_Ins.CommandText = "UPDATE tb_insurer SET insurer_name='" & insurer_name & "', add1='" & add1 & "', add2='" & add2 & "', town='" & town & "', post_code='" & post_code & "', state='" & state & "', insurer_code='" & insurer_code & "', status='" & status & "', modified_by='" & modified_by & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "' where tb_insurer_id='" & lblInsurerId.Text & "'"
            sRes = _sqlCmd_Ins.ExecuteNonQuery()

            If sRes = "1" Then
                clear_all()
                MsgBox("Successfully Updated the Insurer details!")
                gbInsurer.Visible = False
                getInsurerdetails()
            Else
                MsgBox("Error while Updating the Insurer details! or Currently our server busy please try again..")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
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