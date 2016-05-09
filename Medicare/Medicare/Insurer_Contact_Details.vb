Public Class Insurer_Contact_Details
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub Insurer_Contact_Details_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Insurer_Contact_Details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getInsureContactDetails(Me.lblCContactID.Text)
    End Sub
#End Region
#Region "Data Bind"
    Private Sub getInsureContactDetails(ByVal ins_id As String)
        Dim _scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGet.CommandType = CommandType.Text
        _scGet.CommandText = "SELECT tb_Insurer_contact_details_id, Name, Designation,Tel, tb_Insurer_id FROM tb_insurer_contact_details where tb_insurer_id='" & ins_id & "'"
        Dim _sda As New SqlDataAdapter(_scGet)
        Dim ds As New DataSet
        _sda.Fill(ds, "tb_insurer_contact_details")
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvCDetails
                .DataSource = ds
                .DataMember = "tb_Insurer_contact_details"
                .Columns(0).HeaderText = "tb_Insurer_contact_details_id"
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Name"
                .Columns(2).HeaderText = "Designation"
                .Columns(3).HeaderText = "Tel"
                .Columns(4).Visible = False
                
            End With
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
        Else

            Me.btnDelete.Enabled = False
            Me.btnEdit.Enabled = False
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Insert_Insurer_contact_details()
    End Sub
#End Region
    
    Private Function Insert_Insurer_contact_details() As String
        Dim name, desig, tel, fax, email, created_by, sRes, ins_id As String

        If Me.txtCName.Text.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtCName.Focus()
            Exit Function
        End If
        If Me.txtCDesig.Text.Trim() = "" Then
            MsgBox("Designation Can't be Blank!")
            Me.txtCDesig.Focus()
            Exit Function
        End If
        If Me.txtCTel.Text.Trim() = "" Then
            MsgBox("Telephone Number Can't be Blank!")
            Me.txtCTel.Focus()
            Exit Function
        End If
        If Me.txtCEmail.Text.Trim() = "" Then
            MsgBox("Email ID Can't be Blank!")
            Me.txtCEmail.Focus()
            Exit Function
        End If
       
        name = Me.txtCName.Text.Trim()
        desig = Me.txtCDesig.Text.Trim()
        tel = Me.txtCTel.Text.Trim()
        fax = Me.txtCFax.Text.Trim()
        email = Me.txtCEmail.Text.Trim()
        created_by = My.Settings.Username

        Dim _scID As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scID.CommandType = CommandType.Text
        _scID.CommandText = "select  max(tb_insurer_id) + 1 as Insurer_id from tb_insurer"
        Dim adp As New SqlDataAdapter(_scID)
        Dim ds As New DataSet
        adp.Fill(ds, "tb_insurer")
        If Me.lblCContactID.Text = "" Then
            If Not IsDBNull(ds.Tables(0).Rows(0)("insurer_id")) Then
                ins_id = ds.Tables(0).Rows(0)("insurer_id")
            Else
                ins_id = "0"
            End If
        Else
            ins_id = Me.lblCContactID.Text
        End If

        Dim _sqlCmd_Ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Try
            _sqlCmd_Ins.CommandType = CommandType.Text
            _sqlCmd_Ins.CommandText = "INSERT INTO tb_insurer_contact_details (tb_insurer_id,name, designation, tel, fax, email, created_by, created_dt) " & _
                                                         "VALUES ('" & ins_id & "', '" & name & "', '" & _
                                                         desig & "', '" & tel & "', '" & _
                                                         fax & "', '" & email & "', '" & _
                                                         created_by & "', '" & Format(Now(), "MM/dd/yyyy") & "')"

            sRes = _sqlCmd_Ins.ExecuteNonQuery()

            If sRes = "1" Then
                clear_all()
                MsgBox("Successfully Added the Insurer Contact!")
                getInsureContactDetails(ins_id)
            Else
                MsgBox("Error while Adding the Insurer! or Currently our server busy please try again..")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub clear_all()
        Me.txtCName.Text = ""
        Me.txtCDesig.Text = ""
        Me.txtCFax.Text = ""
        Me.txtCEmail.Text = ""
        Me.txtCTel.Text = ""
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Insurer_contact_details()
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnAdd.Enabled = True
        Else

            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
            Me.Close()
        End If
    End Sub
    Private Function Update_Insurer_contact_details() As String
        Dim name, desig, tel, fax, email, modified_by, sRes, ins_id As String

        If Me.txtCName.Text.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtCName.Focus()
            Exit Function
        End If
        If Me.txtCDesig.Text.Trim() = "" Then
            MsgBox("Designation Can't be Blank!")
            Me.txtCDesig.Focus()
            Exit Function
        End If
        If Me.txtCTel.Text.Trim() = "" Then
            MsgBox("Telephone Number Can't be Blank!")
            Me.txtCTel.Focus()
            Exit Function
        End If
        If Me.txtCEmail.Text.Trim() = "" Then
            MsgBox("Email ID Can't be Blank!")
            Me.txtCEmail.Focus()
            Exit Function
        End If
      
        name = Me.txtCName.Text.Trim()
        desig = Me.txtCDesig.Text.Trim()
        tel = Me.txtCTel.Text.Trim()
        fax = Me.txtCFax.Text.Trim()
        email = Me.txtCEmail.Text.Trim()
        modified_by = My.Settings.Username
        
        Dim _sqlCmd_Ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Try
            _sqlCmd_Ins.CommandType = CommandType.Text
            _sqlCmd_Ins.CommandText = "UPDATE tb_insurer_contact_details SET name='" & name & "', designation='" & desig & "', tel='" & tel & "', fax='" & fax & "', email='" & email & "', modified_by='" & modified_by & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "' where tb_insurer_contact_details_id='" & lbltbInsurerContactID.Text & "'"
            sRes = _sqlCmd_Ins.ExecuteNonQuery()

            If sRes = "1" Then
                clear_all()
                MsgBox("Successfully Updated the Insurer contact details!")
                getInsureContactDetails(Me.dgvCDetails.SelectedRows(0).Cells(4).Value.ToString.Trim)
                Me.btnSubmit.Text = "Submit"
                Me.btnSubmit.Name = "Submit"
            Else
                MsgBox("Error while Updating the Insurer  contact details! or Currently our server busy please try again..")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvCDetails.SelectedRows.Count > 0 Then
            Dim ins_id As Integer
            ins_id = Me.dgvCDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_ins.CommandType = CommandType.Text
            _sqlCmdget_ins.CommandText = "SELECT * FROM tb_insurer_contact_details where tb_insurer_contact_details_id='" & ins_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_ins)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_insurer_contact_details")
            Me.lbltbInsurerContactID.Text = ds.Tables(0).Rows(0)("tb_insurer_contact_details_id")
            Me.lbltbInsurerContactID.Visible = False
            Me.txtCName.Text = ds.Tables(0).Rows(0)("name")
            Me.txtCDesig.Text = ds.Tables(0).Rows(0)("designation")
            Me.txtCTel.Text = ds.Tables(0).Rows(0)("tel")
            Me.txtCFax.Text = ds.Tables(0).Rows(0)("fax")
            Me.txtCEmail.Text = ds.Tables(0).Rows(0)("email")
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnDelete.Enabled = False
            Me.btnAdd.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvCDetails.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim ins_id As Integer
                Dim sRes As String
                ins_id = Me.dgvCDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_ins.CommandType = CommandType.Text
                _sqlCmddel_ins.CommandText = "Delete FROM tb_insurer_contact_details where tb_insurer_contact_details_id='" & ins_id & "'"
                sRes = _sqlCmddel_ins.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Insurer Contact!")
                    getInsureContactDetails(Me.dgvCDetails.SelectedRows(0).Cells(4).Value.ToString.Trim)
                Else
                    MsgBox("Error while Deleting the Insurer Contact! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for delete!")
        End If
    End Sub
End Class