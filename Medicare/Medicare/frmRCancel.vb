Public Class frmRCancel
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub frmRCancel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmRCancel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Me.gbDecision.Enabled = False
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _ObjBusi.getDetails_IX("RF_FOLLLOWUP", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvRDetails
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(0).DisplayIndex = 17
                Me.tslblTot.Text = "Total Records : " & dt.Rows.Count
            End With
        Else
            Me.dgvRDetails.DataSource = dt
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub dgvRDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRDetails.CellDoubleClick
        If Me.dgvRDetails.SelectedRows.Count > 0 Then
            With Me.dgvRDetails
                Dim dt As New DataTable
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Me.gbDecision.Enabled = True
                Me.btnPrint.Enabled = False
                Me.btnSubmit.Enabled = True
                Me.btnCancel.Enabled = True
                Me.lblREFID.Text = .SelectedRows(0).Cells(1).Value.ToString()
                Me.lblPREMIUM.Text = .SelectedRows(0).Cells(3).Value.ToString()
            End With
        End If
    End Sub
#Region "Progress Bar"
    'SharedData.ReadyToHideMarquee = False
    'StartMarqueeThread()
    'EVENTS PLACE
    'SyncLock SharedData
    'SharedData.ReadyToHideMarquee = True
    'End SyncLock
    'Application.DoEvents()
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
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.lblREFID.Text = "REFID"
        Me.gbDecision.Enabled = False
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        MsgBox("Endorsement successfully.")
                        Me.btnPrint.Enabled = True
                        Me.btnSubmit.Enabled = False
                    Else
                        MsgBox("Error in endorsing this record.")
                    End If
                Case 7
                    Exit Sub
            End Select
        End If
    End Sub
    Private Function Endorse_Changes() As Boolean
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & Me.lblREFID.Text.Trim & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdInsert_MemberPolicy As SqlCommandBuilder
        cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & Me.lblREFID.Text.Trim & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)

        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)

        Dim ds_Endorsement As New DataSet

        Try
            da_MemberPolicy.Fill(ds_Endorsement, "dt_Member_Policy")
            da_MemberLog.Fill(ds_Endorsement, "log_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")


            With ds_Endorsement.Tables("dt_Member_Policy").Rows(0)
                .Item("Cancellation_Date") = Me.dtpPolicy_CancellationDate.Value
                .Item("Status") = Me.cmbCancellation_Reason.SelectedItem.ToString.Trim
                .Item("Remarks") = "Policy Cancelled"
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With

            da_MemberPolicy.Update(ds_Endorsement, "dt_Member_Policy")
            _objBusi.InsUpsPremiumHistory("CANCELLATION", Guid.NewGuid.ToString.Trim(), Me.lblREFID.Text.Trim, "", Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.lblPREMIUM.Text.Trim(), "InActive", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)

            _objBusi.InsUpsPolicyPremiumHistory("CANCELLATION", Me.lblREFID.Text.ToString.Trim(), "0.00", "", Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)

            Dim dr_MemberLog As DataRow
            dr_MemberLog = ds_Endorsement.Tables("log_Member").NewRow

            With dr_MemberLog
                .Item("Member_Policy_ID") = Me.lblREFID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Activity_Detail") = "Policy cancelled/lapsed."
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
                .Item("Member_Policy_ID") = Me.lblREFID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "C"
                .Item("Endorsement_Detail") = "Policy cancelled. Reason for cancellation: " & Me.cmbCancellation_Reason.SelectedItem.ToString.Trim & _
                                              ", effective from " & Format(Me.dtpPolicy_CancellationDate.Value, "dd/MM/yyyy") & "."
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("TRANS_TYPE") = "POLICY CANCELLED"
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
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim type As String
        type = Me.cmbCancellation_Reason.SelectedIndex
        Select Case type
            Case "0", "6"
                PrintLetters.Print_Letters("AngkasaCancellation.rpt", Me.lblREFID.Text.Trim, type)
            Case "1"
                PrintLetters.Print_Letters("NPL.rpt", Me.lblREFID.Text.Trim, type)
            Case "2"
                PrintLetters.Print_Letters("Change2Yearly.rpt", Me.lblREFID.Text.Trim, type)
            Case "3"
                PrintLetters.Print_Letters("Due_to_60_Percent.rpt", Me.lblREFID.Text.Trim, type)
            Case "4"
                PrintLetters.Print_Letters("No_Deduction_Frm_Angkasa.rpt", Me.lblREFID.Text.Trim, type)
            Case "5"
                PrintLetters.Print_Letters("NPCC.rpt", Me.lblREFID.Text.Trim, type)
            Case "7"
                PrintLetters.Print_Letters("IncompleteBorang.rpt", Me.lblREFID.Text.Trim, type)
        End Select
    End Sub
    Private Function Verify_Endorsement_Details() As Boolean
        If Me.lblREFID.Text = "REFID" Then
            MsgBox("Please do select the Member Policy.")
            Return False
        Else
            If Me.cmbCancellation_Reason.SelectedIndex = -1 Then
                MsgBox("Please do select the Cancellation Reason.")
                Me.cmbCancellation_Reason.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub dtpPolicy_CancellationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPolicy_CancellationDate.ValueChanged
        If Not (My.Settings.Username.Trim.ToUpper() = "ADMIN" Or My.Settings.Username.Trim.ToUpper() = "SRI") Then
            If Not dtpPolicy_CancellationDate.Value >= Now() Then
                MsgBox("Invalid date!")
                dtpPolicy_CancellationDate.Value = Now()
            End If
        End If
    End Sub
    Private Sub dgvRDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRDetails.CellContentClick
        With Me.dgvRDetails
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(1).Value.ToString()
                CS.lblType.Text = "RETIREES"
                CS.ShowDialog()
            End If
        End With
    End Sub
End Class