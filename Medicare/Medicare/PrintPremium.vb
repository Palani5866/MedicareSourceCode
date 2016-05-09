Public Class PrintPremium
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Dim sType As String
    Private Sub PrintPremium_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub PrintPremium_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If sType = "SEARCH" Then
            dt = _objBusi.getDetails_I("PRINTPREMIUM", Me.lblType.Text.Trim(), Me.tsLetter_cbLetterType.Text.Trim(), Me.tstbSearch.Text.Trim(), "", "", "", "", "", "", "SEARCH", Conn)
        Else
            dt = _objBusi.getDetails_I("PRINTPREMIUM", Me.lblType.Text.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvLetters
                .DataSource = dt
                .Columns(1).Visible = False 'ID
                .Columns(2).HeaderText = "IC #"
                .Columns(3).HeaderText = "FULL NAME"
                .Columns(4).HeaderText = "PLAN CODE"
                .Columns(5).HeaderText = "PLAN TYPE"
                .Columns(6).HeaderText = "ANGKASA FILE #"
                .Columns(7).HeaderText = "STATUS"
                .Columns(0).DisplayIndex = 7
                .Columns(0).HeaderText = "Print"
                Me.lblRecordCount.Text = "Record #: " & Me.dgvLetters.RowCount - 1
            End With
        End If
    End Sub
    Private Sub tsLetter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLetter_Go.Click
        sType = "SEARCH"
        If Len(Me.tstbSearch.Text.Trim()) = 0 Then
            MsgBox("Please do key in IC/full name")
            Me.tstbSearch.Focus()
            Exit Sub
        End If
        If Len(Me.tsLetter_cbLetterType.Text.Trim()) = 0 Then
            MsgBox("Please do select search type")
            Me.tsLetter_cbLetterType.Focus()
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub dgvLetters_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLetters.CellContentClick
        Dim type As String
        type = Me.lblType.Text.Trim()
        Select Case type
            Case "PI"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If
                        PrintLetters.Print_Letters("PI.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString().Trim(), "PRINTPREMIUM")
                    End If
                End With
            Case "PD"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If
                        PrintLetters.Print_Letters("PI.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString().Trim(), "PRINTPREMIUM")
                    End If
                End With
        End Select
    End Sub
End Class