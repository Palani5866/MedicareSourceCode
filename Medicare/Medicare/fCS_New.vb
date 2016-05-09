Public Class fCS_New
#Region "General Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub fCS_New_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fCS_New_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA("T3", Me.tscbSearch.Text, Me.tstxtSearch.Text)
        BINDDATATOT()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATATOT()
        Dim dtT1, dtT2, dtT3 As New DataTable
        dtT1 = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "", "", "", "", "", "", "", "", "T1", Me.lblREFTYPE.Text.Trim(), Conn)
        dtT2 = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "", "", "", "", "", "", "", "", "T2", Me.lblREFTYPE.Text.Trim(), Conn)
        dtT3 = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "", "", "", "", "", "", "", "", "T3", Me.lblREFTYPE.Text.Trim(), Conn)
        If dtT3.Rows.Count > 0 Then
            Me.tsToFollowup.Text = "To Follow up : " & dtT3.Rows.Count
        Else
            Me.tsFollowupReminder.Text = "To Follow up : " & "0"
        End If
        If dtT2.Rows.Count > 0 Then
            Me.tsSupervisorFollowup.Text = "Supervisor to Follow up : " & dtT2.Rows.Count
        Else
            Me.tsFollowupReminder.Text = "Supervisor to Follow up : " & "0"
        End If
        If dtT1.Rows.Count > 0 Then
            Me.tsFollowupReminder.Text = "Follow up Reminder : " & dtT1.Rows.Count
        Else
            Me.tsFollowupReminder.Text = "Follow up Reminder : " & "0"
        End If
    End Sub
    Private Sub BINDDATA(ByVal t As String, ByVal ttype As String, ByVal tvalue As String)
        Dim dt As New DataTable
        If ttype = "IC" Then
            If tvalue.ToString.Trim() = "" Then
                MsgBox("Please do key in IC!")
                Me.tstxtSearch.Focus()
                Exit Sub
            End If
            dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "IC", tvalue, "", "", "", "", "", "", t, Me.lblREFTYPE.Text.Trim(), Conn)
        ElseIf ttype = "FULL NAME" Then
            If tvalue.ToString.Trim() = "" Then
                MsgBox("Please do key in Full Name!")
                Me.tstxtSearch.Focus()
                Exit Sub
            End If
            dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "FULLNAME", tvalue, "", "", "", "", "", "", t, Me.lblREFTYPE.Text.Trim(), Conn)
        Else
            dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "", "", "", "", "", "", "", "", t, Me.lblREFTYPE.Text.Trim(), Conn)
        End If
        If dt.Rows.Count > 0 Then
            Select Case t
                Case "T1"
                    With Me.dgvReport
                        .DataSource = dt
                        .Columns(6).Visible = False
                        .Columns(0).DisplayIndex = 20
                        .Columns(1).DisplayIndex = 20
                        .Columns(2).DisplayIndex = 20
                        .Columns(3).DisplayIndex = 20
                        .Columns(4).DisplayIndex = 20
                        .Columns(5).DisplayIndex = 20


                        .Columns(7).ReadOnly = True
                        .Columns(8).ReadOnly = True
                        .Columns(9).ReadOnly = True
                        .Columns(10).ReadOnly = True
                        .Columns(11).ReadOnly = True
                        .Columns(16).ReadOnly = True
                        .Columns(17).ReadOnly = True
                        .Columns(18).ReadOnly = True
                        .Columns(19).ReadOnly = True
                        .Columns(20).ReadOnly = True
                    End With
                Case "T2"
                    With Me.dgvReportt1
                        .DataSource = dt
                        .Columns(6).Visible = False
                        .Columns(0).DisplayIndex = 20
                        .Columns(1).DisplayIndex = 20
                        .Columns(2).DisplayIndex = 20
                        .Columns(3).DisplayIndex = 20
                        .Columns(4).DisplayIndex = 20
                        .Columns(5).DisplayIndex = 20


                        .Columns(7).ReadOnly = True
                        .Columns(8).ReadOnly = True
                        .Columns(9).ReadOnly = True
                        .Columns(10).ReadOnly = True
                        .Columns(11).ReadOnly = True
                        .Columns(16).ReadOnly = True
                        .Columns(17).ReadOnly = True
                        .Columns(18).ReadOnly = True
                        .Columns(19).ReadOnly = True
                        .Columns(20).ReadOnly = True
                    End With
                Case "T3"
                    With Me.dgvReportt2
                        .DataSource = dt
                        .Columns(6).Visible = False
                        .Columns(0).DisplayIndex = 20
                        .Columns(1).DisplayIndex = 20
                        .Columns(2).DisplayIndex = 20
                        .Columns(3).DisplayIndex = 20
                        .Columns(4).DisplayIndex = 20
                        .Columns(5).DisplayIndex = 20


                        .Columns(7).ReadOnly = True
                        .Columns(8).ReadOnly = True
                        .Columns(9).ReadOnly = True
                        .Columns(10).ReadOnly = True
                        .Columns(11).ReadOnly = True
                        .Columns(16).ReadOnly = True
                        .Columns(17).ReadOnly = True
                        .Columns(18).ReadOnly = True
                        .Columns(19).ReadOnly = True
                        .Columns(20).ReadOnly = True
                    End With
            End Select
        Else
            Select Case t
                Case "T1"

                    Me.dgvReport.DataSource = dt
                Case "T2"

                    Me.dgvReportt1.DataSource = dt
                Case "T3"

                    Me.dgvReportt2.DataSource = dt
            End Select
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub dgvReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellContentClick
        With Me.dgvReport
            If e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CC As String
                If Not IsDBNull(.Rows(e.RowIndex).Cells(6).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in remarks")
                        Exit Sub
                    End If
                    If Not IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                        If IsDate(.Rows(e.RowIndex).Cells(1).Value) = False Then
                            MsgBox("Invalid Date Format!")
                            Exit Sub
                        End If
                    End If
                    If (.Rows(e.RowIndex).Cells(2).Value) Then
                        CC = "1"
                    Else
                        CC = "0"
                    End If
                    If MsgBox("Are you sure? You want update this comments", vbYesNo, "Followup") = vbYes Then
                        Dim sRes As String
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value, My.Settings.Username, CC, "", Conn)

                        MsgBox("Successfully updated your comments!")
                        BINDDATA("T1", Me.tscbSearch.Text, Me.tstxtSearch.Text)

                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblStatus.Text = Me.lblREFTYPE.Text.ToString.Trim()
                CS.lblType.Text = "LIST"
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            End If
        End With
    End Sub
    Private Sub dgvReportt1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportt1.CellContentClick
        With Me.dgvReportt1
            If e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CC As String
                If Not IsDBNull(.Rows(e.RowIndex).Cells(6).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in remarks")
                        Exit Sub
                    End If
                    If Not IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                        If IsDate(.Rows(e.RowIndex).Cells(1).Value) = False Then
                            MsgBox("Invalid Date Format!")
                            Exit Sub
                        End If
                    End If
                    If (.Rows(e.RowIndex).Cells(2).Value) Then
                        CC = "1"
                    Else
                        CC = "0"
                    End If
                    If MsgBox("Are you sure? You want update this comments", vbYesNo, "Followup") = vbYes Then
                        Dim sRes As String
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value, My.Settings.Username, CC, "", Conn)

                        MsgBox("Successfully updated your comments!")
                        BINDDATA("T2", Me.tscbSearcht1.Text, Me.tstxtSearcht1.Text)

                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblStatus.Text = Me.lblREFTYPE.Text.ToString.Trim()
                CS.lblType.Text = "LIST"
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            End If
        End With
    End Sub
    Private Sub dgvReportt2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportt2.CellContentClick
        With Me.dgvReportt2
            If e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CC As String
                If Not IsDBNull(.Rows(e.RowIndex).Cells(6).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in remarks")
                        Exit Sub
                    End If
                    If Not IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                        If IsDate(.Rows(e.RowIndex).Cells(1).Value) = False Then
                            MsgBox("Invalid Date Format!")
                            Exit Sub
                        End If
                    End If
                    If (.Rows(e.RowIndex).Cells(2).Value) Then
                        CC = "1"
                    Else
                        CC = "0"
                    End If
                    If MsgBox("Are you sure? You want update this comments", vbYesNo, "Followup") = vbYes Then
                        Dim sRes As String
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value, My.Settings.Username, CC, "", Conn)

                        MsgBox("Successfully updated your comments!")
                        BINDDATA("T3", Me.tscbSearcht2.Text, Me.tstxtSearcht2.Text)
                        BINDDATATOT()

                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblStatus.Text = Me.lblREFTYPE.Text.ToString.Trim()
                CS.lblType.Text = "LIST"
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(6).Value.ToString()
                CS.Show()
            End If
        End With
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        BINDDATA("T1", Me.tscbSearch.Text, Me.tstxtSearch.Text)
    End Sub
    Private Sub tsbtnSearcht1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSearcht1.Click
        BINDDATA("T2", Me.tscbSearcht1.Text, Me.tstxtSearcht1.Text)
    End Sub
    Private Sub tsbtnSearcht2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSearcht2.Click
        BINDDATA("T3", Me.tscbSearcht2.Text, Me.tstxtSearcht2.Text)
    End Sub
#End Region
#Region "TAB Controls"
    Private Sub tcCS_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tcCS.Deselected
        Select Case e.TabPageIndex
            Case 1
                BINDDATA("T2", "", Me.tstxtSearcht1.Text)
            Case 2
                BINDDATA("T3", "", Me.tstxtSearcht2.Text)
            Case Else
                BINDDATA("T1", "", Me.tstxtSearch.Text)
        End Select
    End Sub
    Private Sub tcCS_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tcCS.Selected
        Select Case e.TabPageIndex
            Case 1
                BINDDATA("T2", "", Me.tstxtSearcht1.Text)
            Case 2
                BINDDATA("T3", "", Me.tstxtSearcht2.Text)
            Case Else
                BINDDATA("T1", "", Me.tstxtSearch.Text)
        End Select
    End Sub
#End Region
End Class