Public Class vCS
  
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub vCS_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vCS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Select Case Me.lblType.Text.Trim()
            Case "SHORTFALLS"
                SFBINDDATA()
                Me.Text = "View Short Details"
            Case "SMS"
                SMSBINDDATA()
                Me.Text = "View SMS Details"
            Case "SHORTFALLFWUP"
                SNONFWUPBINDDATA()
                Me.Text = "View Followup Comments"
            Case "RETIREES"
                RETIREESBINDDATA()
                Me.Text = "View Followup Comments"
            Case Else
                BINDDATA()
        End Select
    End Sub
    Private Sub RETIREESBINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_VIII("RETIREES", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvFDetails
                .DataSource = dt
            End With
        Else
            Me.dgvFDetails.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Me.lblType.Text = "LIST" Then
            dt = _objBusi.getDetails_I("FOLLOWUP", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblStatus.Text.ToString.Trim(), "LIST", Conn)
        Else
            dt = _objBusi.getDetails_I("FOLLOWUP", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvFDetails
                .DataSource = dt
            End With
        Else
            Me.dgvFDetails.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub SMSBINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fSMS("SMS", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", "ALL", "DETAILS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvFDetails
                .DataSource = dt
            End With
        Else
            Me.dgvFDetails.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub SFBINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("SHORTFALL", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "RD", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvFDetails
                .DataSource = dt
            End With
        Else
            Me.dgvFDetails.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub SNONFWUPBINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_VIII("SFNONPCOMMENTS", Me.lblPID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvFDetails
                .DataSource = dt
            End With
        Else
            Me.dgvFDetails.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
End Class