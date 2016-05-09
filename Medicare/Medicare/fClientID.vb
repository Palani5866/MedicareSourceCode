Public Class fClientID
#Region "General Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
#End Region
#Region "Page Events"
    Private Sub fClientID_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fClientID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim dt, sdt, cdt As New DataTable
        Try
            dt = _objBusi.fgetDetailsII("CLIENTID", "", "", "", "", "", "", "", "", "", "DETAILS", Conn)
            sdt = _objBusi.fgetDetailsII("CLIENTID", "", "", "", "", "", "", "", "", "", "SUBMITTED", Conn)
            cdt = _objBusi.fgetDetailsII("CLIENTID", "", "", "", "", "", "", "", "", "", "CLOSED", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvClientIDDetails
                    .DataSource = dt
                    .Columns(1).Visible = False
                End With
            Else
                MsgBox("No record found")
                Me.dgvClientIDDetails.DataSource = dt
            End If
            If sdt.Rows.Count > 0 Then
                With Me.dgvSubmittedList
                    .DataSource = sdt
                End With
            Else
                Me.dgvSubmittedList.DataSource = sdt
            End If
            If cdt.Rows.Count > 0 Then
                With Me.dgvClosedList
                    .DataSource = cdt
                End With
            Else
                Me.dgvClosedList.DataSource = cdt
            End If
        Catch ex As Exception
            MsgBox("Currently our server busy, Please try again later!")
            Me.dgvClientIDDetails.DataSource = dt
        End Try
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
                            _objBusi.spUpdate("CLIENTID", .Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), "", "", "", "", "", "", "", "", My.Settings.Username.Trim, Conn)
                        End If
                    End If
                    dgvRowCount += 1
                Loop
            End With
            MsgBox("Successfully submited the exceptional client id details!")
        Catch ex As Exception
            MsgBox("Error while submitting the exceptional client id details or Currently our server busy. Please try again later!")
        End Try
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        sProcess()
        BINDDATA()
    End Sub
    Private Sub lnkXport2Xcel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkXport2Xcel.LinkClicked
        Xport2Xcel()
    End Sub
#End Region
#Region "Export to Excel"
    Private Sub Xport2Xcel()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        If Me.dgvClientIDDetails.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "CLIENT ID EXCEPTIONAL RECORDS DETAILS"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(5, 1) = "#"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "POLCIY NO"
                .Cells(5, 5) = "FAMILY UNIT"
                .Cells(5, 6) = "MEMBER IC"
                .Cells(5, 7) = "MEMBER NAME"
                .Cells(5, 8) = "MEDICARE IC"
                .Cells(5, 9) = "MEDICARE NAME"
                .Cells(5, 10) = "REMARKS"
                Dim xRCount As Integer = 6
                Dim dgvRowcount As Integer = 0
                Do While dgvRowcount < Me.dgvClientIDDetails.RowCount
                    .Cells(xRCount, 1) = "'" & (xRCount - 5).ToString.Trim
                    .Cells(xRCount, 2) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(2).Value.ToString.Trim
                    .Cells(xRCount, 3) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(3).Value.ToString.Trim
                    .Cells(xRCount, 4) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(4).Value.ToString.Trim
                    .Cells(xRCount, 5) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(5).Value.ToString.Trim
                    .Cells(xRCount, 6) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(6).Value.ToString.Trim
                    .Cells(xRCount, 7) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(7).Value.ToString.Trim
                    .Cells(xRCount, 8) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(8).Value.ToString.Trim
                    .Cells(xRCount, 9) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(9).Value.ToString.Trim
                    .Cells(xRCount, 10) = "'" & Me.dgvClientIDDetails.Rows(dgvRowcount).Cells(10).Value.ToString.Trim
                    xRCount += 1
                    dgvRowcount += 1
                Loop
            End With
        End If
        MsgBox("Exporting records to exceptional client id details.")
        xApp.Visible = True
    End Sub
#End Region
End Class