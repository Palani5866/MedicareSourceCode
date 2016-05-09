Public Class Dependant
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim ds_Member As New DataSet
    Dim M_ID As String
#End Region
#Region "Page Events"
    Private Sub Dependant_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        PopGrid("Null", "")
    End Sub
#End Region
#Region "Data Bind"
    Private Sub PopGrid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        
        Dim cmd_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmd_Member.CommandType = CommandType.Text
        If Search_Param1 = "Null" Then
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
                                     "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                     "ORDER BY Full_Name"
        End If
        ds_Member.Clear()
        Dim da_Member As New SqlDataAdapter(cmd_Member)
        da_Member.Fill(ds_Member, "dt_Member")
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        With Me.dgvForm
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
    Private Sub getPolicyDetails(ByVal MemID As String)
        M_ID = MemID
        Me.gbPolicyDetails.Visible = True
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT ID, Member_ID, Angkasa_FileNo, Deduction_Code, Deduction_Amount, " & _
                                 "Agent_Code, Submission_Date, Effective_Date, Cancellation_Date, " & _
                                 "Status, Payment_Frequency, Payment_Method, Policy_No " & _
                                 "FROM dt_Member_Policy WHERE Member_ID = '" & MemID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet
        sdp.Fill(ds, "dt_member_policy")
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
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
                Dim fDependent As New dlgEndosement_DependantDetails
                fDependent.lblMemberID.Text = MemID
            End With
        Else
            MsgBox("Sorry there no policies inforce for this member!")
            Me.gbPolicyDetails.Visible = True
        End If
    End Sub
    Private Sub getDependantdetails(ByVal member_id As String)

        Dim _ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim _scDependant As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scDependant.CommandType = CommandType.Text
        _scDependant.CommandText = "SELECT ID, Member_Policy_ID, Title, Full_Name, Birth_Date, IC_New, " & _
                                    "IC_Old, ArmForce_ID, Race, Marital_Status, Relationship, Sex, " & _
                                    "Height, Weight, Occupation, Department " & _
                                    "FROM dt_Member_Policy_Dependents " & _
                                    "WHERE Member_Policy_ID ='" & member_id & "' " & _
                                    "ORDER BY Birth_Date"
        Dim _sdaDependant As New SqlDataAdapter(_scDependant)
        Me.gbDDetails.Visible = True
        _sdaDependant.Fill(_ds, "dt_Member_Policy_Dependents")
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If _ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvDDetails
                .DataSource = _ds
                .DataMember = "dt_Member_Policy_Dependents"

                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "Title"
                .Columns(3).HeaderText = "Full Name As in NRIC"
                .Columns(4).HeaderText = "Date of Birth"
                .Columns(5).HeaderText = "New I/C No"
                .Columns(6).HeaderText = "Old I/C No"
                .Columns(7).HeaderText = "Policy/Army ID"
                .Columns(8).HeaderText = "Race"
                .Columns(9).HeaderText = "Marital Status"
                .Columns(10).HeaderText = "Relationship"
                .Columns(11).HeaderText = "Sex"
                .Columns(12).HeaderText = "Height"
                .Columns(13).HeaderText = "Weight"
                .Columns(14).HeaderText = "Occupation"
                .Columns(15).HeaderText = "Department"

                .Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"

                Me.dgvDDetails.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvDDetails.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            End With
        Else
            MsgBox("Sorry there no dependant for this member!")
            Me.gbDDetails.Visible = True
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub dgvForm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvForm.DoubleClick
        With Me.dgvForm
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            getPolicyDetails(.CurrentRow.Cells(0).Value.ToString)
        End With
    End Sub
    Private Sub dgvPolicyDetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPolicyDetails.DoubleClick
        With Me.dgvPolicyDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            getDependantdetails(.CurrentRow.Cells(0).Value.ToString)
        End With
    End Sub
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
#End Region
#Region "Update Dependent"
    Private Sub dgvDDetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDDetails.DoubleClick
        With Me.dgvDDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim fDependent As New dlgEndosement_DependantDetails
            If Me.lblAdmin.Text = "Admin" Then
                fDependent.lblAdmin.Text = "Admin"
            End If
            fDependent.MdiParent = frmMain
            fDependent.lblID.Text = .CurrentRow.Cells(0).Value.ToString
            fDependent.lblMember_Policy_ID.Text = .CurrentRow.Cells(1).Value.ToString
            fDependent.lblMemberID.Text = M_ID
            fDependent.Show()
        End With
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
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