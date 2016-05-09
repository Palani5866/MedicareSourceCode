Imports System.Windows.Forms
Public Class dlgConversion_Proposer_Status
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub dlgConversion_Proposer_Status_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgConversion_Proposer_Status_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.txtRemarks.Visible = False
        Me.lblRemarks.Visible = False
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
#Region "Click Events"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If Me.Verify_Conversion_Details() = False Then
                Exit Sub
            End If
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim cmdSelect_Proposer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Proposer.CommandType = CommandType.Text
            cmdSelect_Proposer.CommandText = "SELECT * FROM dt_Proposer " & _
                                             "WHERE ID = '" & Me.lblProposer_ID.Text.Trim & "'"

            Dim da_Proposer As New SqlDataAdapter(cmdSelect_Proposer)

            Dim cmdUpdate_Proposer As SqlCommandBuilder
            cmdUpdate_Proposer = New SqlCommandBuilder(da_Proposer)


            Dim cmdSelect_Log_Proposer_New As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Log_Proposer_New.CommandType = CommandType.Text
            cmdSelect_Log_Proposer_New.CommandText = "SELECT * FROM log_Proposer"

            Dim da_Log_Proposer As New SqlDataAdapter(cmdSelect_Log_Proposer_New)

            Dim cmdInsert_Log_Proposer_New As SqlCommandBuilder
            cmdInsert_Log_Proposer_New = New SqlCommandBuilder(da_Log_Proposer)


            Dim ds_Proposer As New DataSet


            da_Proposer.Fill(ds_Proposer, "dt_Proposer")
            da_Log_Proposer.Fill(ds_Proposer, "log_Proposer")

            If Me.rdiAcknowledgement_New.Checked = True Then
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1A"
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username
            ElseIf Me.rdiDeferment_New.Checked = True Then
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1D"
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            ElseIf Me.rdiReject_New.Checked = True Then
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1R"
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            ElseIf Me.rdiUnderwriting_New.Checked = True Then
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1U"
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            ElseIf Me.rbUnderwritingPU_New.Checked = True Then
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Status") = "1PU"
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_on") = Now()
                ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Statusaltered_by") = My.Settings.Username.ToString.Trim()
            End If
            Dim i As Integer = 0
            Dim sStr As String = ""
            If Me.dgvForm.Rows.Count > 0 Then
                With Me.dgvForm
                    Do While i < .Rows.Count
                        If .Rows(i).Cells(0).Value = "T" Then
                            sStr = sStr & " " & .Rows(i).Cells(1).Value.ToString().Trim()
                        End If
                        i += 1
                    Loop
                End With
            End If
            If Not My.Settings.Username = "Admin" Then
                If sStr.Trim() = "" Then
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                    MsgBox("Please tick the reason for changing status! Or Contact admin")
                    Exit Sub
                End If
            End If
            If Me.txtRemarks.Text.ToString.Trim().Length > 0 Then
                If sStr.ToString().Trim() = "LAIN-LAIN" Then
                    sStr = Me.txtRemarks.Text.Trim()
                End If
            End If
            ds_Proposer.Tables("dt_Proposer").Rows(0).Item("Decline_Reason") = sStr
            da_Proposer.Update(ds_Proposer, "dt_Proposer")


            Dim dr_Log_Proposer As DataRow
            dr_Log_Proposer = ds_Proposer.Tables("log_Proposer").NewRow

            With dr_Log_Proposer
                .Item("Proposer_ID") = Me.lblProposer_ID.Text.Trim
                .Item("Date") = Now()
                .Item("Username") = My.Settings.Username.Trim
                .Item("Message") = sStr
            End With

            ds_Proposer.Tables("log_Proposer").Rows.Add(dr_Log_Proposer)
            da_Log_Proposer.Update(ds_Proposer, "log_Proposer")
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function Verify_Conversion_Details() As Boolean
        If Me.rdiAcknowledgement_New.Checked = False Then
            If Me.rdiDeferment_New.Checked = False Then
                If Me.rdiReject_New.Checked = False Then
                    If Me.rdiUnderwriting_New.Checked = False Then
                        If Me.rbUnderwritingPU_New.Checked = False Then
                            MsgBox("Please do select the new status.")
                            Return False
                        End If
                    End If
                End If
            End If
        End If
        Dim i As Integer = 0
        Dim sRes As Integer = 0
        With Me.dgvForm
            Do While i < .Rows.Count
                If .Rows(i).Cells(0).Value = "T" Then
                    Return True
                Else
                    sRes += 1
                End If
                i += 1
            Loop
        End With
        If sRes > 0 Then
            MsgBox("Please do Tick the Conversion Reason.")
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Change Events"
    Private Sub rdiAcknowledgement_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiAcknowledgement_New.CheckedChanged
        Me.txtRemarks.Visible = False
        Me.lblRemarks.Visible = False
        Select Case Me.lblStatus.Text.Trim()
            Case "1D"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	TERIMA MAKLUM BALAS DARI PEMOHON"
                End With
            Case "1R"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PERMOHONAN SEMULA"
                End With
            Case "1U"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PEMOHON BERSETUJU DENGAN PENYERTAAN BERSYARAT"
                End With
        End Select
    End Sub
    Private Sub rdiDeferment_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiDeferment_New.CheckedChanged
        Me.txtRemarks.Visible = False
        Me.lblRemarks.Visible = False
        Select Case Me.lblStatus.Text.Trim()
            Case "1A", "1U", "1R"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PERMOHONAN TAK LENGKAP"
                End With
        End Select
    End Sub
    Private Sub rdiReject_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiReject_New.CheckedChanged

        Me.txtRemarks.Visible = True
        Me.lblRemarks.Visible = True
        Select Case Me.lblStatus.Text.Trim()
            Case "1A", "1U", "1D"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "POTONGAN ANGKASA MELEBIHI 60%"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PERMINTAAN ANDA UNTUK MEMBATALKAN PERMOHONAN"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	MEMPUNYAI SEJARAH PERUBATAN PERIBADI / KELUARGA"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PERMOHONAN MELEBIHI 60 HARI"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "LAIN-LAIN"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	TIADA MAKLUM BALAS DARIPADA PEMOHON"
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	TUKAR KEPADA BAYARAN TAHUNAN"
                End With
        End Select
    End Sub
    Private Sub rdiUnderwriting_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiUnderwriting_New.CheckedChanged
        Me.txtRemarks.Visible = False
        Me.lblRemarks.Visible = False
        Select Case Me.lblStatus.Text.Trim()
            Case "1D", "1R"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PENYERTAAN BERSYARAT"
                End With
        End Select
    End Sub
    Private Sub rbUnderwritingPU_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUnderwritingPU_New.CheckedChanged
        Me.txtRemarks.Visible = False
        Me.lblRemarks.Visible = False
        Select Case Me.lblStatus.Text.Trim()
            Case "1A", "1D", "1R", "1U"
                With Me.dgvForm
                    .Rows.Clear()
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Cells(1).Value = "•	PENYERTAAN BERSYARAT"
                End With
        End Select
    End Sub
#End Region
    
End Class
