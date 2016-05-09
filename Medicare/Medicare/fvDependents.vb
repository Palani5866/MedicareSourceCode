Public Class fvDependents
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Private Sub fvDependents_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I(Me.lblREFTYPE.Text.Trim(), Me.lblREFID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "DEP", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvDepDetails
                .DataSource = dt
                .Columns(0).Visible = True  '##TICK
                .Columns(1).Visible = False 'ID
                .Columns(2).Visible = False 'ID
                .Columns(17).Visible = False '
                .Columns(18).Visible = False '
                .Columns(19).Visible = False '
                .Columns(20).Visible = False '
                .Columns(21).Visible = False '
            End With
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Me.Close()
    End Sub
    Private Function DT_DEP() As DataTable
        Dim dt As New DataTable("DT_DEP")
        dt.Columns.Add("TITLE", GetType(String))
        dt.Columns.Add("FULLNAME", GetType(String))
        dt.Columns.Add("DOB", GetType(String))
        dt.Columns.Add("AGE", GetType(String))
        dt.Columns.Add("IC", GetType(String))
        dt.Columns.Add("OLDIC", GetType(String))
        dt.Columns.Add("ARMYIC", GetType(String))
        dt.Columns.Add("RACE", GetType(String))
        dt.Columns.Add("MSTATUS", GetType(String))
        dt.Columns.Add("RELATIONSHIP", GetType(String))
        dt.Columns.Add("SEX", GetType(String))
        dt.Columns.Add("HEIGHT", GetType(String))
        dt.Columns.Add("WEIGHT", GetType(String))
        dt.Columns.Add("OCCUPATION", GetType(String))
        dt.Columns.Add("DEPARTMENT", GetType(String))
        dt.Columns.Add("ADD1", GetType(String))
        dt.Columns.Add("ADD2", GetType(String))
        dt.Columns.Add("ADD3", GetType(String))
        dt.Columns.Add("ADD4", GetType(String))
        dt.Columns.Add("TOWN", GetType(String))
        dt.Columns.Add("STATE", GetType(String))
        dt.Columns.Add("POSTCODE", GetType(String))
        dt.Columns.Add("SHARE", GetType(String))
        dt.Columns.Add("IKIO", GetType(String))
        Return dt
    End Function
    Public Function dtfDep() As DataTable
        Dim dt As New DataTable
        My.Computer.Clipboard.Clear()
        Dim rCount As Integer = 0
        Dim iKIO As Integer = 1
        dt = DT_DEP()
        Dim row As DataRow
        Do While rCount < Me.dgvDepDetails.Rows.Count
            If Me.dgvDepDetails.Rows(rCount).Cells(0).Value = "T" Then
                Dim iCount As Integer
                Dim Share As Decimal
                iCount = Me.dgvDepDetails.Rows.Count
                Share = 100 / iCount
                row = dt.NewRow
                row("TITLE") = Me.dgvDepDetails.Rows(rCount).Cells(3).Value
                row("FULLNAME") = Me.dgvDepDetails.Rows(rCount).Cells(4).Value
                row("DOB") = Me.dgvDepDetails.Rows(rCount).Cells(5).Value
                row("AGE") = Math.Floor(DateDiff(DateInterval.Day, Me.dgvDepDetails.Rows(rCount).Cells(5).Value, Now()) / 365.25)
                row("IC") = Me.dgvDepDetails.Rows(rCount).Cells(6).Value
                row("OLDIC") = Me.dgvDepDetails.Rows(rCount).Cells(7).Value
                row("ARMYIC") = Me.dgvDepDetails.Rows(rCount).Cells(8).Value
                row("RACE") = Me.dgvDepDetails.Rows(rCount).Cells(9).Value
                row("MSTATUS") = Me.dgvDepDetails.Rows(rCount).Cells(10).Value
                row("RELATIONSHIP") = Me.dgvDepDetails.Rows(rCount).Cells(11).Value
                row("SEX") = Me.dgvDepDetails.Rows(rCount).Cells(12).Value
                row("HEIGHT") = Me.dgvDepDetails.Rows(rCount).Cells(13).Value
                row("WEIGHT") = Me.dgvDepDetails.Rows(rCount).Cells(14).Value
                row("OCCUPATION") = Me.dgvDepDetails.Rows(rCount).Cells(15).Value
                row("DEPARTMENT") = Me.dgvDepDetails.Rows(rCount).Cells(16).Value
                row("ADD1") = New_Proposer.txtProposer_AddressL1.Text
                row("ADD2") = New_Proposer.txtProposer_AddressL2.Text
                row("ADD3") = New_Proposer.txtProposerAdd3.Text
                row("ADD4") = New_Proposer.txtProposerAdd4.Text
                row("TOWN") = New_Proposer.txtProposer_City.Text
                row("STATE") = New_Proposer.txtProposer_State.Text
                row("POSTCODE") = New_Proposer.txtProposer_Postcode.Text
                row("SHARE") = Share
                row("IKIO") = iKIO
                dt.Rows.Add(row)
                dt.AcceptChanges()
            End If
            rCount += 1
        Loop
        Return dt
    End Function
    Private Sub fvDependents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
End Class