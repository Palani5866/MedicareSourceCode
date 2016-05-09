Public Class fPolicy
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim ds_Member As New DataSet
#End Region
#Region "Page Events"
    Private Sub fPolicy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fPolicy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        PopGrid("Null", "")
    End Sub
#End Region
#Region "Data Bind"
    Private Sub PopGrid(ByVal sParam1 As String, ByVal sParam2 As String)
        Dim cmd_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmd_Member.CommandType = CommandType.Text
        If sParam1 = "Null" Then
            cmd_Member.CommandText = "SELECT ID, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                     "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Occupation, " & _
                                     "Department " & _
                                     "FROM dt_Member " & _
                                     "ORDER BY Full_Name"
        Else
            cmd_Member.CommandText = "SELECT ID, Title, Full_Name, Birth_Date, IC_New, Race, Marital_Status, Sex, " & _
                                     "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Occupation, " & _
                                     "Department " & _
                                     "FROM dt_Member " & _
                                     "WHERE " & sParam1 & " Like '" & sParam2 & "%' " & _
                                     " ORDER BY Full_Name"
        End If


        ds_Member.Clear()


        Dim da_Member As New SqlDataAdapter(cmd_Member)


        da_Member.Fill(ds_Member, "dt_Member")

        With Me.dgvMember
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
#End Region
#Region "Click Events"
    Private Sub tsb_Filter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
        Select Case Me.tsb_Filter.SelectedItem
            Case "IC"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.PopGrid("IC_New", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case "Full Name"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.PopGrid("Full_Name", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case Else
                Me.PopGrid("Null", "")
        End Select
    End Sub
    Private Sub dgvMember_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMember.CellDoubleClick
        With Me.dgvMember
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect.CommandType = CommandType.Text
            cmdSelect.CommandText = "SELECT ID, Member_ID, Angkasa_FileNo, Deduction_Code, Deduction_Amount, " & _
                                     "Agent_Code, Submission_Date, Effective_Date, Cancellation_Date, " & _
                                     "Status, Payment_Frequency, Payment_Method, Policy_No " & _
                                     "FROM dt_Member_Policy WHERE Member_ID = '" & .CurrentRow.Cells(0).Value.ToString & "'"
            Dim sdp As New SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            sdp.Fill(ds, "dt_member_policy")
            With Me.dgvPolicyDetails
                .DataSource = ds
                .DataMember = "dt_Member_Policy"

                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "File No."
                .Columns(3).HeaderText = "Product Code"
                .Columns(4).HeaderText = "Requested Amount"
                .Columns(5).HeaderText = "Agent Code"
                .Columns(6).HeaderText = "Submission Date"
                .Columns(7).HeaderText = "Start Date"
                .Columns(8).HeaderText = "End Date"
                .Columns(9).HeaderText = "Cancellation Reason"
                .Columns(10).HeaderText = "Payment Frequency"
                .Columns(11).HeaderText = "Payment Method"
                .Columns(12).HeaderText = "Policy/Certificate No."

                .Columns(4).DefaultCellStyle.Format = "###.##"

                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
        End With
    End Sub
    Private Sub dgvPolicyDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicyDetails.CellDoubleClick
        With Me.dgvPolicyDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim oPolicy As New afPolicy
            If Me.lblAdmin.Text = "Admin" Then
                oPolicy.lblAdmin.Text = "Admin"
            End If
            oPolicy.MdiParent = frmMain
            oPolicy.lblPolicyID.Text = .CurrentRow.Cells(0).Value.ToString
            oPolicy.lblMemberID.Text = .CurrentRow.Cells(1).Value.ToString
            oPolicy.Show()
        End With
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
#End Region
    
   
End Class