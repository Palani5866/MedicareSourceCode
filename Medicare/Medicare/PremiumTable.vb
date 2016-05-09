Public Class PremiumTable
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub PremiumTable_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub PremiumTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.gbMain.Visible = False
        popCB()
        getPremiumDetails()
        popPaymentMode()
    End Sub
    Private Sub getPremiumDetails()
        Dim _ds As New DataSet
        Dim _scGetAgePremiumTable As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetAgePremiumTable.CommandType = CommandType.Text
        _scGetAgePremiumTable.CommandText = "select distinct Premium_Code from tb_premium_table"
        Dim _sdaGetAgePremiumTable As New SqlDataAdapter(_scGetAgePremiumTable)
        _sdaGetAgePremiumTable.Fill(_ds, "tb_premium_table")
        With Me.dgvPremium
            .DataSource = _ds
            .DataMember = "tb_premium_table"
            .Columns(0).HeaderText = "Premium Code"
            .Columns(0).Width = 125
        End With
    End Sub
    Private Sub popCB()
        Dim arrFrm As New ArrayList
        Dim arrTo As New ArrayList
        For iFrm As Integer = 0 To 120
            arrFrm.Add(iFrm)
            Me.cbAgeFrm.ValueMember = iFrm
        Next
        For iTo As Integer = 1 To 120
            arrTo.Add(iTo)
            Me.cbAgeTo.ValueMember = iTo
        Next
        Me.cbAgeFrm.DataSource = arrFrm
        Me.cbAgeTo.DataSource = arrTo
    End Sub
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.dgvPremiumDetails.Visible = False
        Me.txtPremiumCode.Enabled = True
        Me.gbMain.Visible = True
        Me.btnSubmit.Enabled = False
        Me.btnDelete.Enabled = False
        Me.btnEdit.Enabled = False
        Me.cbParticipantType.SelectedIndex = 0
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvPremium.SelectedRows.Count > 0 Then
            Dim id As String
            id = Me.dgvPremium.SelectedRows(0).Cells(0).Value.ToString.Trim
            PremiumDetails(id)
            Me.gbMain.Visible = True
            Me.dgvPremiumDetails.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub popPaymentMode()

        Dim _scPremium As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsPremium As New DataSet
        _scPremium.CommandType = CommandType.Text
        _scPremium.CommandText = "Select * from tb_premium_type where status='Active'"
        Dim _sdaPremium As New SqlDataAdapter(_scPremium)
        _sdaPremium.Fill(_dsPremium, "tb_premium_type")
        Me.cbPaymentMode.DataSource = _dsPremium.Tables(0)
        Me.cbPaymentMode.DisplayMember = "premium_type"
        Me.cbPaymentMode.ValueMember = "premium_type"

    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvPremium.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim id As String
                Dim sRes As String
                id = Me.dgvPremium.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_premium_table where Premium_Code='" & id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes > "1" Then
                    MsgBox("Successfully Deleted the Premium Record!")
                    getPremiumDetails()
                Else
                    MsgBox("Error while Deleting the Premium Record! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for delete!")
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            MsgBox("Successfully Updated  Premium Table!")
            getPremiumDetails()
            Me.gbMain.Visible = False
            Me.btnDelete.Enabled = True
            Me.btnNew.Enabled = True
            Me.txtPremiumCode.Text = ""
        Else
            MsgBox("Successfully Inserted Premium Table!")
            getPremiumDetails()
            Me.txtPremiumCode.Text = ""
            Me.gbMain.Visible = False
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        End If
    End Sub
    Private Sub Inset_Age_Premum_Table()
        Dim AgeFrm, AgeTo, Agelimit, Premium, Payment_mode, Premium_Code, sRes, Participant_Type As String
        If Me.txtPremiumCode.Text.ToString.Trim() = "" Then
            MsgBox("Premium Code Can't be Blank!")
            Me.txtPremiumCode.Focus()
            Exit Sub
        End If
        If Me.txtPremiumAmt.Text.ToString.Trim() = "" Then
            MsgBox("Premium Amount Can't be Blank!")
            Me.txtPremiumAmt.Focus()
            Exit Sub
        End If
        If Not Len(Me.cbStatus.Text.Trim) > 0 Then
            MsgBox("Please do select the status!")
            Me.cbStatus.Focus()
            Exit Sub
        End If
        AgeFrm = Me.cbAgeFrm.SelectedValue
        AgeTo = Me.cbAgeTo.SelectedValue
        Dim sFrm, sTo As String
        sFrm = Me.cbAgeFrm.SelectedIndex
        sTo = Me.cbAgeTo.SelectedIndex
        If Not sFrm < sTo Then
            MsgBox("Incorrect Age Limit!")
            Me.cbAgeTo.Focus()
            Exit Sub
        End If
        Agelimit = AgeFrm & "-" & AgeTo
        Premium = Me.txtPremiumAmt.Text
        Payment_mode = Me.cbPaymentMode.SelectedValue
        Participant_Type = Me.cbParticipantType.SelectedValue
        Premium_Code = Me.txtPremiumCode.Text.ToString.Trim()
        Dim _scIns As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scIns.CommandType = CommandType.Text
        _scIns.CommandText = "INSERT INTO tb_premium_table (Premium_Code, Participant_Type, Age_Limit, Premium_Amt, tb_premium_type_id,effective_date, expiry_date, status, created_by, created_dt)" & _
                            "Values ('" & Premium_Code & "', '" & Participant_Type & "', '" & Agelimit & "', '" & Premium & "', '" & Payment_mode & "', '" & Me.dtpEffective_Date.Value & "', '" & Me.dtpExpiry_Date.Value & "', '" & Me.cbStatus.SelectedValue.ToString.Trim() & "', '" & My.Settings.Username & "', '" & Format(Now(), "MM/dd/yyyy") & "')"

        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Successfully Inserted Age Premium!")
            clear_all()
            Me.gbMain.Visible = False
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        Else
            MsgBox("Error while Inserting Age Premium!")
        End If
    End Sub
    Private Sub Update_Premum_Table()
        Dim AgeFrm, AgeTo, Agelimit, Premium, Payment_mode, Premium_Code, sRes, Participant_Type As String
        If Me.txtPremiumCode.Text.ToString.Trim() = "" Then
            MsgBox("Premium Code Can't be Blank!")
            Me.txtPremiumCode.Focus()
            Exit Sub
        End If
        If Me.txtPremiumAmt.Text.ToString.Trim() = "" Then
            MsgBox("Premium Amount Can't be Blank!")
            Me.txtPremiumAmt.Focus()
            Exit Sub
        End If
        If Not Len(Me.cbStatus.Text.Trim) > 0 Then
            MsgBox("Please do select the status!")
            Me.cbStatus.Focus()
            Exit Sub
        End If
        AgeFrm = Me.cbAgeFrm.SelectedValue
        AgeTo = Me.cbAgeTo.SelectedValue
        Dim sFrm, sTo As String
        sFrm = Me.cbAgeFrm.SelectedIndex
        sTo = Me.cbAgeTo.SelectedIndex
        If Not sFrm < sTo Then
            MsgBox("Incorrect Age Limit!")
            Me.cbAgeTo.Focus()
            Exit Sub
        End If
        Agelimit = AgeFrm & "-" & AgeTo
        Premium = Me.txtPremiumAmt.Text
        Payment_mode = Me.cbPaymentMode.SelectedValue
        Select Case Me.cbParticipantType.SelectedIndex
            Case "0"
                Participant_Type = "MEMBER"
            Case "1"
                Participant_Type = "SPOUSE"
            Case "2"
                Participant_Type = "CHILD"
        End Select
        Premium_Code = Me.txtPremiumCode.Text.ToString.Trim()
        Dim _scUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scUps.CommandType = CommandType.Text
        _scUps.CommandText = "Update tb_premium_table set Participant_Type='" & Participant_Type & "', age_limit='" & Agelimit & "', premium_amt='" & Premium & "', Payment_Mode='" & Payment_mode & "', effective_date='" & Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy") & "', expiry_date='" & Format(Me.dtpExpiry_Date.Value, "MM/dd/yyyy") & "', status='" & Me.cbStatus.Text.Trim() & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "', modified_by='" & My.Settings.Username & "' where id='" & Me.lblPremiumID.Text.Trim & "'"
        sRes = _scUps.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Successfully Updated Premium!")
            clear_all()
            PremiumDetails(Me.txtPremiumCode.Text.ToString.Trim())
            Me.btnAdd.Name = "ADD"
            Me.btnAdd.Text = "Add"
        Else
            MsgBox("Error while Updating Age Premium!")
        End If
    End Sub
    Private Sub clear_all()
        Me.txtPremiumAmt.Text = ""
        Me.cbAgeFrm.SelectedIndex = 0
        Me.cbAgeTo.SelectedIndex = 0
        Me.cbStatus.SelectedIndex = -1
        Me.dtpEffective_Date.Value = Now()
        Me.dtpExpiry_Date.Value = Now()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub txtPremiumAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremiumAmt.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            Me.txtPremiumAmt.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If txtPremiumAmt.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
            e.Handled = True
        End If
        If txtPremiumAmt.Text.IndexOf(".") > 0 Then
            If txtPremiumAmt.SelectionStart > txtPremiumAmt.Text.IndexOf(".") Then
                If txtPremiumAmt.Text.Length - txtPremiumAmt.Text.IndexOf(".") = 3 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.btnAdd.Name = "Update" Then
            Update_Premum_Table()
            Me.dgvPremiumDetails.Visible = True
        Else
            Inset_Premum_Table()
            Me.dgvPremiumDetails.Visible = True
        End If
    End Sub
    Private Sub Inset_Premum_Table()
        Dim AgeFrm, AgeTo, Agelimit, Premium, Payment_mode, Premium_Code, sRes, Participant_Type As String
        If Me.txtPremiumCode.Text.ToString.Trim() = "" Then
            MsgBox("Premium Code Can't be Blank!")
            Me.txtPremiumCode.Focus()
            Exit Sub
        End If
        If Me.txtPremiumAmt.Text.ToString.Trim() = "" Then
            MsgBox("Premium Amount Can't be Blank!")
            Me.txtPremiumAmt.Focus()
            Exit Sub
        End If
        If Not Len(Me.cbStatus.Text.Trim) > 0 Then
            MsgBox("Please do select the status!")
            Me.cbStatus.Focus()
            Exit Sub
        End If
        AgeFrm = Me.cbAgeFrm.SelectedValue
        AgeTo = Me.cbAgeTo.SelectedValue
        Dim sFrm, sTo As String
        sFrm = Me.cbAgeFrm.SelectedIndex
        sTo = Me.cbAgeTo.SelectedIndex
        If Not sFrm < sTo Then
            MsgBox("Incorrect Age Limit!")
            Me.cbAgeTo.Focus()
            Exit Sub
        End If
        Agelimit = AgeFrm & "-" & AgeTo
        Premium = Me.txtPremiumAmt.Text
        Payment_mode = Me.cbPaymentMode.SelectedValue
        Select Case Me.cbParticipantType.SelectedIndex
            Case "0"
                Participant_Type = "MEMBER"
            Case "1"
                Participant_Type = "SPOUSE"
            Case "2"
                Participant_Type = "CHILD"
        End Select
        Premium_Code = Me.txtPremiumCode.Text.ToString.Trim()
        Dim _scIns As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scIns.CommandType = CommandType.Text
        _scIns.CommandText = "INSERT INTO tb_premium_table (ID, Premium_Code, Participant_Type, Age_Limit, Premium_Amt, Payment_Mode,effective_date, expiry_date, status, created_by, created_dt)" & _
                            "Values ('" & Guid.NewGuid.ToString.Trim() & "', '" & Premium_Code & "', '" & Participant_Type & "', '" & Agelimit & "', '" & Premium & "', '" & Payment_mode & "', '" & Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy") & "', '" & Format(Me.dtpExpiry_Date.Value, "MM/dd/yyyy") & "', '" & Me.cbStatus.Text.Trim() & "', '" & My.Settings.Username & "', '" & Format(Now(), "MM/dd/yyyy") & "')"

        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Successfully Inserted Premium!")
            clear_all()
            Me.btnSubmit.Enabled = True
            PremiumDetails(Me.txtPremiumCode.Text.ToString.Trim())
        Else
            MsgBox("Error while Inserting Premium!")
        End If
    End Sub
    Private Sub PremiumDetails(ByVal Premium_Code As String)
        Dim _ds As New DataSet
        Dim _scGetAgePremiumTable As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetAgePremiumTable.CommandType = CommandType.Text
        _scGetAgePremiumTable.CommandText = "select id,  Premium_Code, Participant_type, age_limit, Premium_amt, Payment_Mode, effective_date, expiry_date, status from tb_premium_table where Premium_Code='" & Premium_Code & "'"
        Dim _sdaGetAgePremiumTable As New SqlDataAdapter(_scGetAgePremiumTable)
        _sdaGetAgePremiumTable.Fill(_ds, "tb_premium_table")
        Me.txtPremiumCode.Text = _ds.Tables(0).Rows(0)("Premium_Code")
        Me.txtPremiumCode.Enabled = False
        With Me.dgvPremiumDetails
            .DataSource = _ds
            .DataMember = "tb_premium_table"
            .Columns(0).HeaderText = "Edit / Update"
            .Columns(2).Visible = False 'id
            .Columns(1).HeaderText = "Delete"
            .Columns(3).HeaderText = "Premium Code"
            .Columns(4).HeaderText = "Participant Type"
            .Columns(5).HeaderText = "Age Limit"
            .Columns(6).HeaderText = "Premium Amount"
            .Columns(7).HeaderText = "Payment Mode"
            .Columns(8).HeaderText = "Effective Date"
            .Columns(9).HeaderText = "Expiry Date"
            .Columns(10).HeaderText = "Status"
            .Columns(6).DefaultCellStyle.Format = "#,#00.00"
            .Columns(0).DisplayIndex = 10
            .Columns(1).DisplayIndex = 10
        End With
    End Sub
    Private Sub dgvPremiumDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPremiumDetails.CellContentClick
        With Me.dgvPremiumDetails
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmdget_Pro.CommandType = CommandType.Text
                _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_premium_table where id='" & .Rows(e.RowIndex).Cells(2).Value.ToString() & "'"
                Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
                Dim ds As New DataSet
                adp.Fill(ds, "tb_premium_table")
                Me.lblPremiumID.Text = ds.Tables(0).Rows(0)("id").ToString()
                Me.txtPremiumAmt.Text = ds.Tables(0).Rows(0)("premium_amt")
                Dim AgeLimit() As String
                Dim age As String
                age = ds.Tables(0).Rows(0)("age_limit").ToString
                AgeLimit = age.Split("-")
                Dim iFrm, iTo As Integer
                iFrm = AgeLimit(0)
                iTo = AgeLimit(1)
                Me.cbAgeFrm.SelectedItem = iFrm
                Me.cbAgeTo.SelectedItem = iTo
                Me.cbPaymentMode.SelectedValue = ds.Tables(0).Rows(0)("payment_Mode")
                Select Case ds.Tables(0).Rows(0)("Participant_Type")
                    Case "MEMBER"
                        Me.cbParticipantType.SelectedIndex = 0
                    Case "SPOUSE"
                        Me.cbParticipantType.SelectedIndex = 1
                    Case "CHILD"
                        Me.cbParticipantType.SelectedIndex = 2
                End Select
                Me.txtPremiumCode.Text = ds.Tables(0).Rows(0)("Premium_Code")
                If Not IsDBNull(ds.Tables(0).Rows(0)("effective_date")) Then
                    Me.dtpEffective_Date.Value = ds.Tables(0).Rows(0)("effective_date")
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0)("expiry_date")) Then
                    Me.dtpExpiry_Date.Value = ds.Tables(0).Rows(0)("expiry_date")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0)("Status")) Then
                    Select Case ds.Tables(0).Rows(0)("Status")
                        Case "Active"
                            Me.cbStatus.SelectedIndex = 0
                        Case "InActive"
                            Me.cbStatus.SelectedIndex = 1
                    End Select
                End If
                Me.txtPremiumCode.Enabled = False
                Me.btnAdd.Name = "Update"
                Me.btnAdd.Text = "Update"
            ElseIf e.ColumnIndex = 1 Then
                Dim sRes As String
                Dim _sqlCmdDelete As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmdDelete.CommandType = CommandType.Text
                _sqlCmdDelete.CommandText = "DELETE FROM tb_premium_table where id='" & .Rows(e.RowIndex).Cells(2).Value.ToString() & "'"
                sRes = _sqlCmdDelete.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Premium record!")
                    PremiumDetails(.Rows(e.RowIndex).Cells(3).Value.ToString())
                    Me.gbMain.Visible = True
                    Me.btnSubmit.Text = "Update"
                    Me.btnSubmit.Name = "Update"
                    Me.btnNew.Enabled = False
                    Me.btnDelete.Enabled = False
                Else
                    MsgBox("Error while Deleting Premium record!")
                End If
            End If
        End With
    End Sub
End Class