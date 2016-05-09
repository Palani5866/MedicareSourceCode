Imports System.Windows.Forms
Public Class dlgEndosement_Reinstate
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_Reinstate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgEndosement_Reinstate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#End Region
#Region "DataBind Events"
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)
        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text
        Dim dt As New DataTable
        If Search_Param1 = "Null" Then
            If Me.dgvPolicies.Rows.Count > 0 Then
                Me.dgvPolicies.DataSource = Nothing
                Me.dgvPolicies.DataMember = Nothing
            End If
            Me.txtFileNo.Clear()
            Me.txtName.Clear()
            Me.txtNRIC.Clear()
            Me.txtL2_Plan_Code_Old.Clear()
            Me.txtRequested_Amount_Old.Clear()
            Me.txtPolicy_EffectiveDate_Old.Clear()
            Me.txtPolicy_CancellationDate.Clear()
            Exit Sub
        Else
            dt = _objBusi.getDetails("MEMBER", Search_Param1, Search_Param2, "", "", "ERI", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvPolicies
                .DataSource = dt
                .Columns(0).Visible = False 'ID
                .Columns(1).HeaderText = "File No."
                .Columns(2).HeaderText = "Full Name"
                .Columns(3).HeaderText = "IC (New)"
                .Columns(4).HeaderText = "Product Code"
                .Columns(5).HeaderText = "Requested Amount"
                .Columns(6).HeaderText = "Agent Code"
                .Columns(7).HeaderText = "Submission Date"
                .Columns(8).HeaderText = "1st Payment Date"
                .Columns(9).HeaderText = "Cancellation Date"
                .Columns(10).HeaderText = "Policy/Certificate No."

                .Columns(5).DefaultCellStyle.Format = "#,##0.00"

                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Else
            MsgBox("No Record found!")
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvPolicies_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicies.CellClick
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtL2_Plan_Code_Old.Clear()
        Me.txtRequested_Amount_Old.Clear()
        Me.txtPolicy_EffectiveDate_Old.Clear()
        Me.txtPolicy_CancellationDate.Clear()

        If e.RowIndex = -1 Then
            Exit Sub
        Else
            With Me.dgvPolicies.Rows(e.RowIndex)
                Me.lblMemberPolicy_ID.Text = .Cells(0).Value.ToString.Trim
                Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                Me.txtName.Text = .Cells(2).Value.ToString.Trim
                Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                Me.txtL2_Plan_Code_Old.Text = .Cells(4).Value.ToString.Trim
                If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                    Me.txtRequested_Amount_Old.Text = Format(.Cells(5).Value, "#,##0.00")
                End If
                If Len(.Cells(8).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_EffectiveDate_Old.Text = Format(.Cells(8).Value, "dd/MM/yyyy")
                End If
                If Len(.Cells(9).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_CancellationDate.Text = Format(.Cells(9).Value, "dd/MM/yyyy")
                End If
            End With
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        MsgBox("Endorsement successfully.")
                    Else
                        MsgBox("Error in endorsing this record.")
                    End If
                Case 7
                    Exit Sub
            End Select
            Me.Close()
        End If
    End Sub
    Private Sub tsb_Filter_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
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
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function Verify_Endorsement_Details() As Boolean
        If Me.lblMemberPolicy_ID.Text = "GUID" Then
            MsgBox("Please do select the Member Policy.")
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Endorse"
    Private Function Endorse_Changes() As Boolean
        '##Declare SQL Command to hold records from Table: dt_Member_Policy
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdInsert_MemberPolicy As SqlCommandBuilder
        cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

        '##Declare SQL Command to hold records from Table: log_Member
        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)

        '##Declare SQL Command to hold records from Table: dt_Member_Endorsement
        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)

        '##Declare dataset for Table: dt_Member_Policy
        Dim ds_Endorsement As New DataSet

        '##Fill dataset with records from Table: dt_Member_Policy
        Try
            da_MemberPolicy.Fill(ds_Endorsement, "dt_Member_Policy")
            da_MemberLog.Fill(ds_Endorsement, "log_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")

            With ds_Endorsement.Tables("dt_Member_Policy").Rows(0)
                .Item("Cancellation_Date") = System.DBNull.Value
                '.Item("Cancellation_Reason") = System.DBNull.Value
                If IsDBNull(.Item("effective_date")) Then
                    .Item("effective_date") = Me.dtpEffective_Date.Value
                End If
                .Item("Status") = "INFORCE"
                .Item("Remarks") = ""
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With

            da_MemberPolicy.Update(ds_Endorsement, "dt_Member_Policy")
            Dim varID As String
            varID = Guid.NewGuid.ToString.Trim()

            'Premium History
            _objBusi.InsUpsPremiumHistory("INS", varID, Me.lblMemberPolicy_ID.Text.Trim, Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), "", Me.txtRequested_Amount_Old.Text, "Active", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)
            _objBusi.InsUpsPremiumHistory("EUPS", varID, Me.lblMemberPolicy_ID.Text.Trim, "", Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), Me.txtRequested_Amount_Old.Text.Trim(), "InActive", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)
            'END

            'NEW POLICY PREMIUM HISTORY UPDATE
            _objBusi.InsUpsPolicyPremiumHistory("INS", Me.lblMemberPolicy_ID.Text.ToString.Trim(), Me.txtRequested_Amount_Old.Text, Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), "", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)
            'END
            '##Add Log
            Dim dr_MemberLog As DataRow
            dr_MemberLog = ds_Endorsement.Tables("log_Member").NewRow

            With dr_MemberLog
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Activity_Detail") = "Reinstate Policy."
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
            End With

            ds_Endorsement.Tables("log_Member").Rows.Add(dr_MemberLog)
            da_MemberLog.Update(ds_Endorsement, "log_Member")


            Dim dr_Member_Endorsement_New As DataRow
            dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow

            With dr_Member_Endorsement_New
                .Item("Member_ID") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "E"
                .Item("Endorsement_Detail") = "Policy reinstated."
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("Remark") = Me.txtRemark.Text.ToString.Trim
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Effective_Date") = dtpEffective_Date.Value
            End With
            ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
            da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
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
