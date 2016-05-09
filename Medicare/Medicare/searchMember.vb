Public Class searchMember
    Dim Conn As DbConnection = New SqlConnection
    Dim ds_Member As New DataSet
    Private Sub searchMember_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub searchMember_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Populate_Grid("Null", "")
    End Sub
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)
        Dim cmd_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmd_Member.CommandType = CommandType.Text

        If Search_Param1 = "Null" Then
            cmd_Member.CommandText = "SELECT top 50 ID, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                     "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Occupation, " & _
                                     "Department " & _
                                     "FROM dt_Member " & _
                                     "ORDER BY Full_Name"
        Else
            cmd_Member.CommandText = "SELECT ID, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                     "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Occupation, " & _
                                     "Department " & _
                                     "FROM dt_Member " & _
                                     "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                     "ORDER BY Full_Name"
        End If


        ds_Member.Clear()


        Dim da_Member As New SqlDataAdapter(cmd_Member)


        da_Member.Fill(ds_Member, "dt_Member")

        With Me.dgvMemberDetails
            .DataSource = ds_Member
            .DataMember = "dt_Member"

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "Title"
            .Columns(2).HeaderText = "Name"
            .Columns(3).HeaderText = "Birth Date"
            .Columns(4).HeaderText = "IC (New)"
            .Columns(5).HeaderText = "Race"
            .Columns(6).HeaderText = "Marital Status"
            .Columns(7).HeaderText = "Sex"
            .Columns(8).HeaderText = "Town"
            .Columns(9).HeaderText = "Postcode"
            .Columns(10).HeaderText = "State"
            .Columns(11).HeaderText = "Phone (House)"
            .Columns(12).HeaderText = "Phone (Mobile)"
            .Columns(13).HeaderText = "Phone (Office)"
            .Columns(14).HeaderText = "Email"
            .Columns(15).HeaderText = "Occupation"
            .Columns(16).HeaderText = "Department"

            .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
        End With
    End Sub

    Private Sub dgvMemberDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemberDetails.CellDoubleClick
        With Me.dgvMemberDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If Me.lblParam.Text = "MP" Then
                Dim Mem As New Member
                Mem.MdiParent = frmMain
                Mem.lblGUID.Text = .CurrentRow.Cells(0).Value.ToString
                Mem.Show()
            Else
                Dim Member As New aMember
                Member.MdiParent = frmMain
                Member.lblID.Text = .CurrentRow.Cells(0).Value.ToString
                Member.Show()
            End If
            
        End With
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
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
End Class