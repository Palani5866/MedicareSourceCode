Public Class fvCS
    
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fvCS_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fvCS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.tstxtSearch.Text.ToString.Trim() = "" Then
            Me.tstxtSearch.Focus()
            MsgBox("Please do key in IC/ Full Name!")
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Select Case Me.tscbSearch.Text
            Case "IC"
                dt = _objBusi.getDetails_I("CS", "IC", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
            Case "FULL NAME"
                dt = _objBusi.getDetails_I("CS", "FULLNAME", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
            Case "DEPENDENT IC"
                dt = _objBusi.getDetails_I("CS", "DEPIC", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
            Case "DEPENDENT NAME"
                dt = _objBusi.getDetails_I("CS", "DEPFULLNAME", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
            Case "FILE NO"
                dt = _objBusi.getDetails_I("CS", "FILENO", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
            Case "POLICY NO"
                dt = _objBusi.getDetails_I("CS", "POLICYNO", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        End Select
        If dt.Rows.Count > 0 Then
            With Me.dgvCS
                .DataSource = dt
                .Columns(0).DisplayIndex = 15
                .Columns(1).Visible = False
                .Columns(2).Visible = False
            End With
        Else
            Me.dgvCS.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub dgvCS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCS.CellContentClick
        With Me.dgvCS
            Select Case e.ColumnIndex
                Case 0
                    If .Rows.Count = 0 Then
                        Exit Sub
                    End If
                    If Not IsDBNull(.Rows(e.RowIndex).Cells(1).Value) Then
                        Try
                            If .Rows(e.RowIndex).Cells(2).Value.ToString.Trim() = "P" Then
                                Dim CS As New New_Proposer
                                CS.MdiParent = frmMain
                                CS.Text = "Proposer Details (READ ONLY)"
                                CS.lblForm_Flag.Text = "Readonly"
                                CS.lblProposer_ID.Text = .Rows(e.RowIndex).Cells(1).Value.ToString()
                                CS.Show()
                            Else
                                Dim CS As New frmMember_v2
                                CS.MdiParent = frmMain
                                CS.lblGUID.Text = .Rows(e.RowIndex).Cells(1).Value.ToString()
                                CS.Show()
                            End If
                        Catch ex As Exception
                            MsgBox("No record found")
                        End Try
                    Else
                        MsgBox("No record found")
                    End If
            End Select
        End With
    End Sub
End Class