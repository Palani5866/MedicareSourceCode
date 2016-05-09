Public Class rRecoverShortFall
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub rRecoverShortFall_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rRecoverShortFall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Me.gbDecisionMake.Enabled = False
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Me.tscbSearch.Text = "IC" Then
            If Me.tstxtSearch.Text.ToString.Trim() = "" Then
                MsgBox("Please do key in IC / Full Name!")
                Me.tstxtSearch.Focus()
                Exit Sub
            End If
            dt = _objBusi.fShortFalls("RECOVER", "IC", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Conn)
        ElseIf Me.tscbSearch.Text = "FULL NAME" Then
            If Me.tstxtSearch.Text.ToString.Trim() = "" Then
                MsgBox("Please do key in IC / Full Name!")
                Me.tstxtSearch.Focus()
                Exit Sub
            End If
            dt = _objBusi.fShortFalls("RECOVER", "FULLNAME", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Conn)
        Else
            dt = _objBusi.fShortFalls("RECOVER", "", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvShortfallRecover
                .DataSource = dt
                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 19
                .Columns(1).DisplayIndex = 19
                .Columns(2).DisplayIndex = 19
                .Columns(3).DisplayIndex = 19


                .Columns(5).ReadOnly = True
                .Columns(6).ReadOnly = True
                .Columns(7).ReadOnly = True
                .Columns(8).ReadOnly = True
                .Columns(9).ReadOnly = True
                .Columns(10).ReadOnly = True
                .Columns(11).ReadOnly = True
                .Columns(16).ReadOnly = True
                .Columns(17).ReadOnly = True
                .Columns(18).ReadOnly = True
                .Columns(19).ReadOnly = True
            End With
        Else
            MsgBox("No record found")
        End If

        Dim dtClose As DataTable
        dtClose = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "CLOSED", Conn)
        If dtClose.Rows.Count > 0 Then
            With Me.dgvFullRecovered
                .DataSource = dtClose
            End With
        End If
    End Sub
    Private Sub dgvProposer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfallRecover.CellContentClick
        With Me.dgvShortfallRecover
            If e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in remarks")
                        Exit Sub
                    End If
                    If MsgBox("Are you sure? You want update this comments", vbYesNo, "Followup") = vbYes Then
                        Dim sRes As String
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), Nothing, My.Settings.Username, "", "", Conn)

                        MsgBox("Successfully updated your comments!")
                        BINDDATA()

                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblType.Text = "SHORTFALLS"
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New sSFDecision
                CS.MdiParent = frmMain
                CS.lblREF1.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                CS.Show()
            End If
        End With
    End Sub
    Private Sub dgvShortfallRecover_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfallRecover.CellDoubleClick
        With Me.dgvShortfallRecover
            Dim dt As New DataTable
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            dt = _objBusi.fShortFalls("DECISION", .SelectedRows(0).Cells(4).Value.ToString(), "", "", "", "", "", "", "", "", "ACTION", Conn)
            If dt.Rows.Count > 0 Then
                Me.gbDecisionMake.Enabled = True
                Me.txtFullName.Text = dt.Rows(0)("FULL_NAME")
                Me.txtNRIC.Text = dt.Rows(0)("IC_NEW")
                Me.lblREF2.Text = dt.Rows(0)("PID").ToString().Trim()
                Me.lblREF3.Text = dt.Rows(0)("SFID").ToString().Trim()
                Me.lblAMT.Text = .SelectedRows(0).Cells(14).Value.ToString().Replace("-", "")
            Else
                Me.gbDecisionMake.Enabled = False
            End If
        End With
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Len(Me.txtsfRemarks.Text.Trim()) > 0 Then
            MsgBox("Please do key the remarks!")
            Me.txtsfRemarks.Focus()
            Exit Sub
        End If
        Dim sDecision, sRes As String
        If Me.rbC2Y.Checked Then
            If Not Len(Me.txtPaymentRefNo.Text.Trim()) > 0 Then
                MsgBox("Please do key the Payment Reference Number.!")
                Me.txtPaymentRefNo.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRecoveredAmt.Text.Trim()) > 0 Then
                MsgBox("Please do key the Amount Received!")
                Me.txtRecoveredAmt.Focus()
                Exit Sub
            End If
            If Not Me.lblAMT.Text.Trim() = Me.txtRecoveredAmt.Text.Trim() Then
                MsgBox("You can't recovered Less/More then Short Amount!")
                Me.txtRecoveredAmt.Text = Me.lblAMT.Text.Trim()
            End If
            sDecision = "CLIENT PAY DIRECT"
            sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF3.Text.ToString.Trim(), "CLIENT PAY DIRECT", Me.lblREF2.Text.ToString.Trim(), Me.txtPaymentRefNo.Text.Trim(), Me.txtRecoveredAmt.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "", "", "DECISION", Conn)
            If sRes = "1" Then
                MsgBox("Thank you..Your Short fall payment has been received!")
                BINDDATA()
                Me.gbDecisionMake.Enabled = False
            End If
        ElseIf Me.rbCP.Checked Then
            If Me.cmbCancellation_Reason.SelectedIndex = -1 Then
                MsgBox("Please do select the Cancellation Reason.")
                Me.cmbCancellation_Reason.Focus()
                Exit Sub
            End If
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF3.Text.ToString.Trim(), "UR2C", Me.lblREF2.Text.ToString.Trim(), Format(Me.dtpRequestedDate.Value, "MM/dd/yyyy"), Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.cmbCancellation_Reason.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "DECISION", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Cancelled the policy.")
                        Me.btnPrint.Enabled = True
                        Me.btnSubmit.Enabled = False
                        Clearup()

                    Else
                        MsgBox("Error while cancelling the policy")
                    End If
                Case 7
                    Exit Sub
            End Select
        ElseIf Me.rbIgnor.Checked Then
            If Not Len(Me.txtRPFrm.Text.Trim()) > 0 Then
                MsgBox("Please do key the Recover Period From!")
                Me.txtRPFrm.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRPTo.Text.Trim()) > 0 Then
                MsgBox("Please do key the Recover Period To!")
                Me.txtRPTo.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRequestedAmt.Text.Trim()) > 0 Then
                MsgBox("Please do key the Requesting Amount!")
                Me.txtRequestedAmt.Focus()
                Exit Sub
            End If
            If Not Me.lblAMT.Text.Trim() = Me.txtRequestedAmt.Text.Trim() Then
                MsgBox("You can't request Less/More then Short Amount!")
                Me.txtRequestedAmt.Text = Me.lblAMT.Text.Trim()
            End If
            sDecision = "RE-REQUEST"
            sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF3.Text.ToString.Trim(), "RE-REQUEST", Me.lblREF2.Text.ToString.Trim(), Me.txtRPFrm.Text.Trim(), Me.txtRPTo.Text.Trim(), Me.txtDCode.Text.Trim(), Me.txtRequestedAmt.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "DECISION", Conn)
            If sRes = "1" Then
                MsgBox("Successfully Re-Requested")
                BINDDATA()
                Me.gbDecisionMake.Enabled = False
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clearup()
        Me.gbDecisionMake.Enabled = False
    End Sub
    Private Sub Clearup()
        Me.txtFullName.Text = ""
        Me.txtNRIC.Text = ""
        Me.txtsfRemarks.Text = ""
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim type As String
        type = Me.cmbCancellation_Reason.SelectedIndex
        Select Case type
            Case "0", "6"
                PrintLetters.Print_Letters("AngkasaCancellation.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "1"
                PrintLetters.Print_Letters("NPL.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "2"
                PrintLetters.Print_Letters("Change2Yearly.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "3"
                PrintLetters.Print_Letters("Due_to_60_Percent.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "4"
                PrintLetters.Print_Letters("No_Deduction_Frm_Angkasa.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "5"
                PrintLetters.Print_Letters("NPCC.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "7"
                PrintLetters.Print_Letters("IncompleteBorang.rpt", Me.lblREF2.Text.ToString.Trim(), type)
        End Select

    End Sub
    Private Sub rbC2Y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbC2Y.CheckedChanged
        If Me.rbC2Y.Checked Then
            Me.txtPaymentRefNo.Enabled = True
            Me.txtRecoveredAmt.Enabled = True
            Me.txtDCode.Enabled = False
            Me.txtRequestedAmt.Enabled = False
            Me.txtRPFrm.Enabled = False
            Me.txtRPTo.Enabled = False
            Me.dtpEffective_Date.Enabled = False
            Me.dtpPolicy_CancellationDate.Enabled = False
            Me.dtpRequestedDate.Enabled = False
            Me.cmbCancellation_Reason.Enabled = False
            Me.txtRequestedAmt.Text = "0.00"
            Me.txtRecoveredAmt.Text = Me.lblAMT.Text.Trim()
        End If
    End Sub
    Private Sub rbIgnor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIgnor.CheckedChanged
        Me.txtPaymentRefNo.Enabled = False
        Me.txtRecoveredAmt.Enabled = False
        Me.txtDCode.Enabled = True
        Me.txtRequestedAmt.Enabled = True
        Me.txtRPFrm.Enabled = True
        Me.txtRPTo.Enabled = True
        Me.dtpEffective_Date.Enabled = False
        Me.dtpPolicy_CancellationDate.Enabled = False
        Me.dtpRequestedDate.Enabled = False
        Me.cmbCancellation_Reason.Enabled = False
        Me.txtRequestedAmt.Text = Me.lblAMT.Text.Trim()
        Me.txtRecoveredAmt.Text = "0.00"
    End Sub
    Private Sub rbCP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCP.CheckedChanged
        Me.txtPaymentRefNo.Enabled = False
        Me.txtRecoveredAmt.Enabled = False
        Me.txtDCode.Enabled = False
        Me.txtRequestedAmt.Enabled = False
        Me.txtRPFrm.Enabled = False
        Me.txtRPTo.Enabled = False
        Me.dtpEffective_Date.Enabled = True
        Me.dtpPolicy_CancellationDate.Enabled = True
        Me.dtpRequestedDate.Enabled = True
        Me.cmbCancellation_Reason.Enabled = True
        Me.txtRequestedAmt.Text = "0.00"
        Me.txtRecoveredAmt.Text = "0.00"
    End Sub
    Private Sub dtpPolicy_CancellationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPolicy_CancellationDate.ValueChanged

        If Not My.Settings.Username.Trim.ToUpper() = "ADMIN" Then
            If Not dtpPolicy_CancellationDate.Value >= Now() Then
                MsgBox("Invalid date!")
                dtpPolicy_CancellationDate.Value = Now()
            End If
        End If
    End Sub
End Class