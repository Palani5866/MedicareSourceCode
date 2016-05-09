Public Class XportBlank
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub XportBlank_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub XportBlank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("XPORTBLANK", P1, P2, "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvBlank
                .DataSource = dt
                Select Case P1
                    Case "MEMBER"
                        .Columns(0).Visible = False 'ID
                        .Columns(1).HeaderText = "IC"
                        .Columns(2).HeaderText = "FULL NAME"
                        .Columns(3).HeaderText = "DOB"
                        .Columns(4).HeaderText = "PHONE HOUSE"
                        .Columns(5).HeaderText = "PHONE MOBILE"
                        .Columns(6).HeaderText = "PHONE OFFICE"
                    Case "SPOUSE"
                        .Columns(0).Visible = False 'ID
                        .Columns(1).HeaderText = "IC"
                        .Columns(2).HeaderText = "FULL NAME"
                        .Columns(4).HeaderText = "SPOUSE IC"
                        .Columns(5).HeaderText = "SPOUSE NAME"
                        .Columns(6).HeaderText = "RELATIONSHIP"
                        .Columns(7).HeaderText = "DOB"
                    Case "DEPENDENTS"
                        .Columns(0).Visible = False 'ID
                        .Columns(1).HeaderText = "IC"
                        .Columns(2).HeaderText = "FULL NAME"
                        .Columns(4).HeaderText = "DEP IC"
                        .Columns(5).HeaderText = "DEP NAME"
                        .Columns(6).HeaderText = "RELATIONSHIP"
                        .Columns(7).HeaderText = "DOB"
                End Select
                Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvBlank.RowCount.ToString
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No Record found")
        End If
    End Sub
    Private Sub tsbtn_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Go.Click
        If Not Me.tscbSearchBy.SelectedIndex = 0 Then
            If Not Me.tscb_SearchBy1.SelectedIndex = 0 Then
                BINDDATA(Me.tscbSearchBy.Text, Me.tscb_SearchBy1.Text)
            Else
                MsgBox("Please select the search Criteria (IC/DOB)")
            End If
        Else
            MsgBox("Please select the search Criteria (Member/Spouse/Dep")
        End If
    End Sub
    Private Sub tscbSearchBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbSearchBy.SelectedIndexChanged
        Me.tscb_SearchBy1.SelectedIndex = 0
    End Sub
    Private Sub tsbtn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Export.Click
        Select Case Me.tscbSearchBy.SelectedIndex
            Case "1"
                xPortMember()
            Case "2"
                xPortSpouse()
            Case "3"
                xPortDep()
        End Select
    End Sub
    Private Sub xPortMember()
        If Me.dgvBlank.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim xls_wks_name As String = ""
            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "MEMBER DETAILS BLANK IC/DOB"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB (MM/dd/yyyy)"
                .Cells(4, 5) = "PHONE HOUSE"
                .Cells(4, 6) = "PHONE MOBILE"
                .Cells(4, 7) = "PHONE OFFICE"

                Dim xls_row_counter As Integer = 5
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvBlank.Rows.Count
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                    .Cells(xls_row_counter, 2) = Me.dgvBlank.Rows(var_name_count).Cells(1).Value
                    .Cells(xls_row_counter, 3) = Me.dgvBlank.Rows(var_name_count).Cells(2).Value
                    If Not IsDBNull(Me.dgvBlank.Rows(var_name_count).Cells(3).Value) Then
                        .Cells(xls_row_counter, 4) = Me.dgvBlank.Rows(var_name_count).Cells(3).Value
                    End If
                    .Cells(xls_row_counter, 5) = Me.dgvBlank.Rows(var_name_count).Cells(4).Value
                    .Cells(xls_row_counter, 6) = Me.dgvBlank.Rows(var_name_count).Cells(5).Value
                    .Cells(xls_row_counter, 7) = Me.dgvBlank.Rows(var_name_count).Cells(6).Value
                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With
            MsgBox("Exporting records to MEMBER DETAILS BLANK IC/DOB LISTING completed.")
            xls_file.Visible = True
        End If
    End Sub
    Private Sub xPortSpouse()
        If Me.dgvBlank.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim xls_wks_name As String = ""
            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "SPOUSE DETAILS BLANK IC/DOB"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "SPOUSE IC"
                .Cells(4, 5) = "SPOUSE FULL NAME"
                .Cells(4, 6) = "RELATIONSHIP"
                .Cells(4, 7) = "DOB (MM/dd/yyyy)"
                .Cells(4, 8) = "DEDUCTION CODE"

                Dim xls_row_counter As Integer = 5
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvBlank.Rows.Count
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                    .Cells(xls_row_counter, 2) = Me.dgvBlank.Rows(var_name_count).Cells(1).Value
                    .Cells(xls_row_counter, 3) = Me.dgvBlank.Rows(var_name_count).Cells(2).Value
                    .Cells(xls_row_counter, 4) = "'" & Me.dgvBlank.Rows(var_name_count).Cells(3).Value
                    .Cells(xls_row_counter, 5) = Me.dgvBlank.Rows(var_name_count).Cells(4).Value
                    .Cells(xls_row_counter, 6) = Me.dgvBlank.Rows(var_name_count).Cells(5).Value
                    If Not IsDBNull(Me.dgvBlank.Rows(var_name_count).Cells(6).Value) Then
                        .Cells(xls_row_counter, 7) = Me.dgvBlank.Rows(var_name_count).Cells(6).Value
                    End If
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvBlank.Rows(var_name_count).Cells(7).Value
                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With
            MsgBox("Exporting records to SPOUSE DETAILS BLANK IC/DOB LISTING completed.")
            xls_file.Visible = True
        End If
    End Sub
    Private Sub xPortDep()
        If Me.dgvBlank.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim xls_wks_name As String = ""
            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "DEPENDENT DETAILS BLANK IC/DOB"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DEPENDENT IC"
                .Cells(4, 5) = "DEPENDENT FULL NAME"
                .Cells(4, 6) = "RELATIONSHIP"
                .Cells(4, 7) = "DOB (MM/dd/yyyy)"
                .Cells(4, 8) = "DEDUCTION CODE"

                Dim xls_row_counter As Integer = 5
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvBlank.Rows.Count
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                    .Cells(xls_row_counter, 2) = Me.dgvBlank.Rows(var_name_count).Cells(1).Value
                    .Cells(xls_row_counter, 3) = Me.dgvBlank.Rows(var_name_count).Cells(2).Value
                    .Cells(xls_row_counter, 4) = "'" & Me.dgvBlank.Rows(var_name_count).Cells(3).Value
                    .Cells(xls_row_counter, 5) = Me.dgvBlank.Rows(var_name_count).Cells(4).Value
                    .Cells(xls_row_counter, 6) = Me.dgvBlank.Rows(var_name_count).Cells(5).Value
                    If Not IsDBNull(Me.dgvBlank.Rows(var_name_count).Cells(6).Value) Then
                        .Cells(xls_row_counter, 7) = Me.dgvBlank.Rows(var_name_count).Cells(6).Value
                    End If
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvBlank.Rows(var_name_count).Cells(7).Value
                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With
            MsgBox("Exporting records to DEPENDENT DETAILS BLANK IC/DOB LISTING completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class