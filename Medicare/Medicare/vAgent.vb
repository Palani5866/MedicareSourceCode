Public Class vAgent
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Dim SearchBy As Boolean = False
    Private Sub vAgent_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vAgent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Try
            Select Case Me.tscbStatus.SelectedIndex
                Case "0"
                    If SearchBy Then
                        dt = _objBusi.fgetDetailsII("AGENT", Me.tstxtSearchBy.Text.Trim(), "Active", "", "", "", "", "", "", "", "SEARCHBY", Conn)
                    Else
                        dt = _objBusi.fgetDetailsII("AGENT", "", "Active", "", "", "", "", "", "", "", "", Conn)
                    End If
                Case "1"
                    If SearchBy Then
                        dt = _objBusi.fgetDetailsII("AGENT", Me.tstxtSearchBy.Text.Trim(), "InActive", "", "", "", "", "", "", "", "SEARCHBY", Conn)
                    Else
                        dt = _objBusi.fgetDetailsII("AGENT", "", "InActive", "", "", "", "", "", "", "", "", Conn)
                    End If
            End Select

            If dt.Rows.Count > 0 Then
                With Me.dgvAgentDetails
                    .DataSource = dt
                End With
            Else
                MsgBox("No record found")
                Me.dgvAgentDetails.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox("We are sorry currently our server busy, Please try again later!")
            Me.dgvAgentDetails.DataSource = dt
        End Try
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Not Me.tscbStatus.SelectedIndex > -1 Then
            MsgBox("Required Status!")
            Me.tscbStatus.Focus()
        End If
        If Not Me.tstxtSearchBy.Text.ToString.Trim() = "" Then
            SearchBy = True
        End If
        BINDDATA()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvAgentDetails.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "ACTIVE AGENT DETAILS"
                .Cells(2, 1) = "Exported on : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "NAME"
                .Cells(5, 3) = "IC"
                .Cells(5, 4) = "AGENT CODE"
                .Cells(5, 5) = "ADD1"
                .Cells(5, 6) = "ADD2"
                .Cells(5, 7) = "TOWN"
                .Cells(5, 8) = "STATE"
                .Cells(5, 9) = "POSCODE"
                .Cells(5, 10) = "CONTACT # (HOME)"
                .Cells(5, 11) = "CONTACT # (OFFICE)"
                .Cells(5, 12) = "MOBILE"
                .Cells(5, 13) = "EMAIL"
                .Cells(5, 14) = "EFFECTIVE DATE"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvAgentDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvAgentDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: ACTIVE AGENT LISTING")
            xApp.Visible = True
        End If
    End Sub
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        If Me.dgvAgentDetails.RowCount > 0 Then
            XPort2Xcel()
        Else
            MsgBox("No record found")
        End If
    End Sub
End Class