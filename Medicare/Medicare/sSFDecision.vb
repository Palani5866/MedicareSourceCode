Public Class sSFDecision
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub sSFDecision_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub sSFDecision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("DECISION", Me.lblREF1.Text.ToString.Trim, "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
        Else
            MsgBox("No record found")
        End If
    End Sub
    Private Sub Clearup()
        Me.txtDeductionCode.Text = ""
        Me.txtFullName.Text = ""
        Me.txtNRIC.Text = ""
        Me.txtRemarks.Text = ""
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Len(Me.txtRemarks.Text.Trim()) > 0 Then
            MsgBox("Please do key the remarks!")
            Me.txtRemarks.Focus()
            Exit Sub
        End If
        Dim sDecision, sRes As String

        If Me.rbC2Y.Checked Then
            sDecision = "CHANGE TO YEARLY"
            sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF1.Text.ToString.Trim, "", "", "", "", "", "", "", "", "", Conn)
        ElseIf Me.rbCP.Checked Then
            sDecision = "USER REQUEST TO CANCEL"
            sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF1.Text.ToString.Trim, "", "", "", "", "", "", "", "", "", Conn)
        ElseIf Me.rbIgnor.Checked Then
            sDecision = "IGNORE"
            sRes = _objBusi.fINShortFall("UPDATE", Me.lblREF1.Text.ToString.Trim, "", "", "", "", "", "", "", "", "", Conn)
        End If
        If sRes = "1" Then
            MsgBox("Successfully submited")
            Clearup()
            Me.Close()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clearup()
        Me.Close()
    End Sub
End Class