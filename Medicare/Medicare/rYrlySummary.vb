Public Class rYrlySummary
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim sType As String
    Private Sub rYrlySummary_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rYrlySummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDYR()
    End Sub
    Private Sub BINDYR()
        Dim aYR As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr As String
        p1YR = Now.Year() - 2
        aYR.Add(p1YR)
        p2Yr = Now.Year() - 1
        aYR.Add(p2Yr)
        cYr = Now.Year()
        aYR.Add(cYr)
        f1Yr = Now.Year() + 1
        aYR.Add(f1Yr)
        Me.tsddlYr.ComboBox.DataSource = aYR
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fYrSummary("YR", Me.tsddlYr.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvYS
                .DataSource = dt
            End With
        Else
            Me.dgvYS.DataSource = dt
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Not Len(Me.tsddlYr.Text.Trim()) > 0 Then
            MsgBox("Please do select the batch no!")
            Me.tsddlYr.Focus()
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvYS.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "YEARLY SUMMARY REPORT"
                .Cells(2, 1) = "FOR THE YEAR : " & Me.tsddlYr.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "PLAN TYPE"
                .Cells(4, 3) = "JANUARY"
                .Cells(4, 4) = "FEBRUARY"
                .Cells(4, 5) = "MARCH"
                .Cells(4, 6) = "APRIL"
                .Cells(4, 7) = "MAY"
                .Cells(4, 8) = "JUNE"
                .Cells(4, 9) = "JULY"
                .Cells(4, 10) = "AUGUST"
                .Cells(4, 11) = "SEPTEMBER"
                .Cells(4, 12) = "OCTOBER"
                .Cells(4, 13) = "NOVEMBER"
                .Cells(4, 14) = "DECEMBER"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvYS.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = Me.dgvYS.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = Me.dgvYS.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = Me.dgvYS.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = Me.dgvYS.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = Me.dgvYS.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = Me.dgvYS.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = Me.dgvYS.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = Me.dgvYS.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = Me.dgvYS.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = Me.dgvYS.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = Me.dgvYS.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = Me.dgvYS.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = Me.dgvYS.Rows(iCount).Cells(12).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            xApp.Visible = True
        Else
            MsgBox("No record found")
        End If
    End Sub
End Class