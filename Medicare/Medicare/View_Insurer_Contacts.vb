Public Class View_Insurer_Contacts
    Dim Conn As DbConnection = New SqlConnection
    Private Sub View_Insurer_Contacts_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub View_Insurer_Contacts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.getInsureContactDetails(Me.lblInsurerID.Text)
    End Sub
    Private Sub getInsureContactDetails(ByVal ins_id As String)
        Dim _scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGet.CommandType = CommandType.Text
        _scGet.CommandText = "SELECT tb_Insurer_contact_details_id, Name, Designation,Tel, tb_Insurer_id FROM tb_insurer_contact_details where tb_insurer_id='" & ins_id & "'"
        Dim _sda As New SqlDataAdapter(_scGet)
        Dim ds As New DataSet
        _sda.Fill(ds, "tb_insurer_contact_details")
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvInsurerContacts
                .DataSource = ds
                .DataMember = "tb_Insurer_contact_details"
                .Columns(0).HeaderText = "tb_Insurer_contact_details_id"
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Name"
                .Columns(2).HeaderText = "Designation"
                .Columns(3).HeaderText = "Tel"
                .Columns(4).Visible = False
            End With
            
        Else
            MsgBox("No Contacts")
            Me.Close()
        End If
    End Sub
End Class