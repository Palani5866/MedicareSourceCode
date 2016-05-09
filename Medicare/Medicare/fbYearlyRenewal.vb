Public Class fbYearlyRenewal
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub fbYearlyRenewal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fbYearlyRenewal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal From date (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal To date (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Renewal From date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Renewal To date in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    BINDDATA()
                Else
                    MsgBox("Renewal To date is < Renewal From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        sProcess()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim vFromDay As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim vFromMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim vFromYear As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim vDateFrom As String = vFromMonth & "/" & vFromDay & "/" & vFromYear

        Dim vToDay As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim vToMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim vToYear As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim vDateTo As String = vToMonth & "/" & vToDay & "/" & vToYear
        Dim dt As New DataTable
        dt = _objBusi.fgetDetailsII("RENEWAL", vDateFrom, vDateTo, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvClientIDDetails
                .DataSource = dt
                .Columns(1).Visible = False
            End With
        Else
            MsgBox("No record found")
            Me.dgvClientIDDetails.DataSource = dt
        End If
    End Sub
#End Region
#Region "Process"
    Private Sub sProcess()
        Dim dgvRowCount As Integer = 0
        Try
            With Me.dgvClientIDDetails
                Do While dgvRowCount < .Rows.Count
                    If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                        If Not IsDBNull(.Rows(dgvRowCount).Cells(1).Value) Then
                            _objBusi.spUpdate("RENEWAL", .Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), "", "", "", "", "", "", "", "", My.Settings.Username.Trim, Conn)
                        End If
                    End If
                    dgvRowCount += 1
                Loop
            End With
            MsgBox("Successfully renewal selected policies!")
        Catch ex As Exception
            MsgBox("Error while renewal the policies or Currently our server busy. Please try again later!")
        End Try
    End Sub
#End Region
#Region "Change Events"
    Public Sub dgvClientIDDetails_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvClientIDDetails.CellValueChanged
        With Me.dgvClientIDDetails
            If .Rows(e.RowIndex).Cells(0).Value = "T" Then

            End If
        End With
    End Sub
#End Region
End Class