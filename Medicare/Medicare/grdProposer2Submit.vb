Public Class grdProposer2Submit
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub grdProposer2Submit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub grdProposer2Submit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("VP", Me.lblParam.Text.ToString.Trim(), "", "", "", "P2S", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                Dim p As String
                Dim aP As String()
                p = dt.Rows(0)("PLAN_CODE").ToString.Trim()
                aP = p.Split("-")
                If aP(1).Substring(0, 1) = "Y" Then
                    Me.tsb_ProcessSubmission_Yearly.Enabled = True
                    Me.tsb_ProcessSubmission.Enabled = False
                Else
                    Me.tsb_ProcessSubmission_Yearly.Enabled = False
                    Me.tsb_ProcessSubmission.Enabled = True
                End If
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "Title"
                .Columns(3).HeaderText = "Full Name As in NRIC"
                .Columns(4).HeaderText = "New I/C No"
                .Columns(5).HeaderText = "State"
                .Columns(6).HeaderText = "Plan Code"
                .Columns(7).HeaderText = "Plan Code (Level 2)"
                .Columns(8).HeaderText = "Status"
                .Columns(9).HeaderText = "File No"

                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub tsb_ProcessSubmission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ProcessSubmission.Click
        Try

            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE Status = '1A' "

            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)

            Dim cmdUpdate_Proposer As SqlCommandBuilder
            cmdUpdate_Proposer = New SqlCommandBuilder(da_Proposer)


            Dim ds_Proposer As New DataSet


            da_Proposer.Fill(ds_Proposer, "dt_Proposer")

            Dim dgvForm_counter As Integer = 0
            Dim Submission_Batch_No As String = Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
            Dim dr_Proposer As DataRow()

            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count
                    If .Rows(dgvForm_counter).Cells(0).Value = "T" Then
                        dr_Proposer = ds_Proposer.Tables("dt_Proposer").Select("ID = '" & .Rows(dgvForm_counter).Cells(1).Value.ToString & "'")

                        If dr_Proposer.Length = 1 Then
                            dr_Proposer(0).Item("Status") = "2"
                            dr_Proposer(0).Item("Submission_Batch_No") = Submission_Batch_No
                            dr_Proposer(0).Item("Submission2Angkasa_By") = My.Settings.Username.Trim
                            dr_Proposer(0).Item("Submission2Angkasa_On") = Now()

                            da_Proposer.Update(ds_Proposer, "dt_Proposer")
                        End If
                    End If
                    dgvForm_counter += 1
                Loop
            End With

            Dim rpt_SubmitToAngkasa As New SubmitToAngkasa

            rpt_SubmitToAngkasa.lblBatch_No.Text = Submission_Batch_No
            rpt_SubmitToAngkasa.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub tsb_ProcessSubmission_Yearly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ProcessSubmission_Yearly.Click
        Try

            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE Status = '1A' "

            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)

            Dim cmdUpdate_Proposer As SqlCommandBuilder
            cmdUpdate_Proposer = New SqlCommandBuilder(da_Proposer)


            Dim ds_Proposer As New DataSet


            da_Proposer.Fill(ds_Proposer, "dt_Proposer")

            Dim dgvForm_counter As Integer = 0
            Dim Submission_Batch_No As String = Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss") & "-Y"
            Dim dr_Proposer As DataRow()

            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count
                    If .Rows(dgvForm_counter).Cells(0).Value = "T" Then
                        dr_Proposer = ds_Proposer.Tables("dt_Proposer").Select("ID = '" & .Rows(dgvForm_counter).Cells(1).Value.ToString & "'")

                        If dr_Proposer.Length = 1 Then
                            dr_Proposer(0).Item("Status") = "2"
                            dr_Proposer(0).Item("Submission_Batch_No") = Submission_Batch_No
                            dr_Proposer(0).Item("Submission2Angkasa_By") = My.Settings.Username.Trim
                            dr_Proposer(0).Item("Submission2Angkasa_On") = Now()

                            da_Proposer.Update(ds_Proposer, "dt_Proposer")
                        End If
                    End If
                    dgvForm_counter += 1
                Loop
            End With

            Dim grd_Report_Submission2Insurer_Yearly As New grdReport_Submission2Insurer_Yearly

            grd_Report_Submission2Insurer_Yearly.MdiParent = Me.MdiParent
            grd_Report_Submission2Insurer_Yearly.ssReport_Parameter.Text = Submission_Batch_No
            grd_Report_Submission2Insurer_Yearly.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class