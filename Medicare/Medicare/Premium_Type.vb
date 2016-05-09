
Public Class Premium_Type
    Dim Conn As DbConnection = New SqlConnection
    Private Sub Premium_Type_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Premium_Type_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getPremiumDetails()
        Me.gbPremium.Visible = False
        Me.cbStatus.SelectedIndex = 0
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub getPremiumDetails()
        Dim _ds As New DataSet
        Dim _scGetPremium As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetPremium.CommandType = CommandType.Text
        _scGetPremium.CommandText = "select tb_Premium_type_id, Premium_type,status from tb_Premium_type"
        Dim _sdaGetPremium As New SqlDataAdapter(_scGetPremium)
        _sdaGetPremium.Fill(_ds, "tb_Premium_type")
        With Me.dgvPremium
            .DataSource = _ds
            .DataMember = "tb_Premium_type"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Premium Type"
            .Columns(2).HeaderText = "Status"
        End With
    End Sub
    Private Sub Clear()
        Me.txtPremium.Text = ""
        Me.cbStatus.SelectedIndex = -1
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Premium_Type()
        Else
            Insert_Premium_Type()
        End If
    End Sub
#Region "Insert"
    Private Sub Insert_Premium_Type()
        Dim status, Premium_type As String
        If Me.txtPremium.Text.ToString.Trim() = "" Then
            MsgBox("Premium Type Can't be Blank!")
            Me.txtPremium.Focus()
            Exit Sub
        End If
        Premium_type = Me.txtPremium.Text.ToString.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim sRes As String
        Dim _scIns As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scIns.CommandType = CommandType.Text
        _scIns.CommandText = "Insert into tb_Premium_type (Premium_type, status, created_dt, created_by) " & _
                            "Values ('" & Premium_type & "', '" & status & "', '" & Format(Now(), "MM/dd/yyyy") & "', '" & My.Settings.Username & "')"
        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully Inserted Premium Type")
            getPremiumDetails()
            Clear()
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
            gbPremium.Visible = False
        Else
            MsgBox("Error while Inserting Premium Type")
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub Update_Premium_Type()
        Dim status, Premium_type, sRes As String
        If Me.txtPremium.Text.ToString.Trim() = "" Then
            MsgBox("Premium Type Can't be Blank!")
            Me.txtPremium.Focus()
            Exit Sub
        End If
        Premium_type = Me.txtPremium.Text.ToString.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim _scUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scUps.CommandType = CommandType.Text
        _scUps.CommandText = "Update tb_Premium_type Set Premium_type='" & Premium_type & "', status='" & status & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "', modified_by='" & My.Settings.Username & "' where tb_Premium_type_id='" & Me.lblPremiumID.Text & "'"
        sRes = _scUps.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully updated Premium Type")
            getPremiumDetails()
            Clear()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            gbPremium.Visible = False
        Else
            MsgBox("Error while Updating Premium Type")
        End If
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.gbPremium.Visible = True
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvPremium.SelectedRows.Count > 0 Then
            Dim pro_id As Integer
            pro_id = Me.dgvPremium.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_Pro.CommandType = CommandType.Text
            _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_Premium_type where tb_Premium_type_id='" & pro_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_Premium_type")
            Me.lblPremiumID.Text = ds.Tables(0).Rows(0)("tb_Premium_type_id")
            Me.lblPremiumID.Visible = False
            Me.txtPremium.Text = ds.Tables(0).Rows(0)("Premium_type")
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            gbPremium.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvPremium.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim pro_id As Integer
                Dim sRes As String
                pro_id = Me.dgvPremium.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_Premium_type where tb_Premium_type_id='" & pro_id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Premium Type!")
                    getPremiumDetails()
                Else
                    MsgBox("Error while Deleting the Premium Type! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for Delete!")
        End If
    End Sub
End Class