Public Class xPolicyDetails
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub xPolicyDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub xPolicyDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.ts_SearchBy1.Text = Format(Now, "dd/MM/yyyy")
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("POLICYDETAILS", P1, P2, "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPolicyDetails
                .DataSource = dt
                .Columns(0).Visible = False 'ID
                Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvPolicyDetails.RowCount.ToString
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No Record found")
        End If
    End Sub
    Private Sub tsbtn_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Go.Click
        If Not Me.tscbSearchBy.SelectedIndex = 0 Then
            If Not Me.ts_SearchBy1.Text = "" Then
                BINDDATA(Me.tscbSearchBy.Text, Me.ts_SearchBy1.Text)
            Else
                MsgBox("Please select the search Criteria (IC/DOB)")
            End If
        Else
            MsgBox("Please select the search Criteria (Member/Spouse/Dep")
        End If
    End Sub
    Private Sub tsbtn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Export.Click
        If Me.dgvPolicyDetails.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWSName As String = ""
            xWB.Worksheets.Add()
            xWSName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWSName)
                .Cells(1, 1) = "POLICY DETAILS " & Me.tscbSearchBy.Text
                .Cells(2, 1) = "UNTILL DATE :" & Me.ts_SearchBy1.Text

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC #"
                .Cells(4, 5) = "PLAN"
                .Cells(4, 6) = "EFFECTIVE DATE"
                .Cells(4, 7) = "CANCELLATION DATE"


                .Cells(4, 8) = "NAME"
                .Cells(4, 9) = "IC"
                .Cells(4, 10) = "DOB"
                .Cells(4, 11) = "NAME1"
                .Cells(4, 12) = "IC1"
                .Cells(4, 13) = "DOB1"
                .Cells(4, 14) = "NAME2"
                .Cells(4, 15) = "IC2"
                .Cells(4, 16) = "DOB2"
                .Cells(4, 17) = "NAME3"
                .Cells(4, 18) = "IC3"
                .Cells(4, 19) = "DOB3"
                .Cells(4, 20) = "NAME4"
                .Cells(4, 21) = "IC4"
                .Cells(4, 22) = "DOB4"
                .Cells(4, 23) = "NAME5"
                .Cells(4, 24) = "IC5"
                .Cells(4, 25) = "DOB5"
                .Cells(4, 26) = "NAME6"
                .Cells(4, 27) = "IC6"
                .Cells(4, 28) = "DOB6"
                .Cells(4, 29) = "NAME7"
                .Cells(4, 30) = "IC7"
                .Cells(4, 31) = "DOB7"
                .Cells(4, 32) = "NAME8"
                .Cells(4, 33) = "IC8"
                .Cells(4, 34) = "DOB8"
                .Cells(4, 35) = "NAME9"
                .Cells(4, 36) = "IC9"
                .Cells(4, 37) = "DOB9"
                .Cells(4, 38) = "NAME10"
                .Cells(4, 39) = "IC10"
                .Cells(4, 40) = "DOB10"

                Dim xRCount As Integer = 5
                Dim dgvRCount As Integer = 0

                Do While dgvRCount < Me.dgvPolicyDetails.Rows.Count - 1
                    .Cells(xRCount, 1) = "'" & (xRCount - 4).ToString.Trim
                    .Cells(xRCount, 2) = "'" & Me.dgvPolicyDetails.Rows(dgvRCount).Cells(1).Value
                    .Cells(xRCount, 3) = "'" & Me.dgvPolicyDetails.Rows(dgvRCount).Cells(2).Value.ToString.Trim
                    .Cells(xRCount, 4) = "'" & Me.dgvPolicyDetails.Rows(dgvRCount).Cells(3).Value
                    .Cells(xRCount, 5) = "'" & Me.dgvPolicyDetails.Rows(dgvRCount).Cells(4).Value
                    If Not IsDBNull(Me.dgvPolicyDetails.Rows(dgvRCount).Cells(5).Value) Then
                        .Cells(xRCount, 6) = "'" & Format(Me.dgvPolicyDetails.Rows(dgvRCount).Cells(5).Value, "dd/MM/yyyy")
                    End If
                    If Not IsDBNull(Me.dgvPolicyDetails.Rows(dgvRCount).Cells(6).Value) Then
                        .Cells(xRCount, 7) = "'" & Format(Me.dgvPolicyDetails.Rows(dgvRCount).Cells(6).Value, "dd/MM/yyyy")
                    End If

                    Dim dt As New DataTable
                    dt = _objBusi.getDetails("POLICYDETAILS", Me.dgvPolicyDetails.Rows(dgvRCount).Cells(0).Value.ToString.Trim(), "", "", "", "FAMILY", Conn)
                    If dt.Rows.Count > 0 Then
                        Dim colCount As Integer = 8
                        For Each dr As DataRow In dt.Rows
                            .Cells(xRCount, colCount) = "'" & dr("FULL_NAME").ToString.Trim()
                            If Not IsDBNull(dr("IC_NEW")) Then
                                .Cells(xRCount, colCount + 1) = "'" & dr("IC_NEW").ToString.Trim()
                            End If
                            If Not IsDBNull(dr("BIRTH_DATE")) Then
                                .Cells(xRCount, colCount + 2) = "'" & Format(dr("BIRTH_DATE"), "dd/MM/yyyy")
                            End If
                            colCount += 3
                        Next
                    End If

                    xRCount += 1
                    dgvRCount += 1
                Loop
            End With
            MsgBox("Exporting records to Policy Details completed.")
            xApp.Visible = True
        End If
    End Sub
End Class