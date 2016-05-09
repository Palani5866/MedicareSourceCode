Public Class rYShortfallReport
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub rYShortfallReport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rYShortfallReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Select Case Me.lblREF1.Text
            Case "SHORTFALL"
                Me.Text = "PREMIUM SHORT FALL DETAILS"
            Case "NONP"
                Me.Text = "PREMIUM NON PAYMNET DETAILS"
                Me.lblMonthTo.Text = "Deduction Month : "
                Me.lblMonthTo.Visible = True
                Me.cbMonthTo.Visible = True
        End Select
        popYear()
    End Sub
    Private Sub popYear()
        'Year
        Dim alYear As New ArrayList
        alYear.Add(Year(Now))
        alYear.Add(Year(Now) - 3)
        alYear.Add(Year(Now) - 2)
        alYear.Add(Year(Now) - 1)
        alYear.Add(Year(Now) + 1)
        Me.ToolStripcmbYear.ComboBox.DataSource = alYear

        Dim cbMonth As New ArrayList
        cbMonth.Add("01")
        cbMonth.Add("02")
        cbMonth.Add("03")
        cbMonth.Add("04")
        cbMonth.Add("05")
        cbMonth.Add("06")
        cbMonth.Add("07")
        cbMonth.Add("08")
        cbMonth.Add("09")
        cbMonth.Add("10")
        cbMonth.Add("11")
        cbMonth.Add("12")
        Me.cbMonthTo.ComboBox.DataSource = cbMonth
        Me.cbMonthFrm.ComboBox.DataSource = cbMonth
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        Select Case Me.lblREF1.Text
            Case "SHORTFALL"
                BindData()
            Case "NONP"
                BindDataNONPayment()
        End Select
    End Sub
    Private Sub BindDataNONPayment()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.rYRSFR("NONP", Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString(), Me.cbMonthTo.ComboBox.SelectedValue.ToString(), "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvShortFallReport
                .DataSource = dt
                .Columns(0).Visible = False
                Me.lblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        Else
            Me.dgvShortFallReport.DataSource = dt
            Me.lblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("We are sorry! Currently our server is busy, Please try again after some time or No record found on your criteria")
        End If
    End Sub
    Private Sub BindDataNONP()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.rYRSFR("NONP", Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString(), "", Me.cbMonthTo.ComboBox.SelectedText.ToString(), "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvShortFallReport
                .DataSource = dt
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "IC"
                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "PLAN CODE"
                .Columns(4).HeaderText = "PREMIUM"
                .Columns(5).HeaderText = "STATUS"
                .Columns(6).HeaderText = "START DATE"
                .Columns(7).HeaderText = "END DATE"
                .Columns(8).HeaderText = "PHONE HOUSE"
                .Columns(9).HeaderText = "PHONE MOBILE"
                .Columns(10).HeaderText = "PHONE OFFICE"
                .Columns(11).HeaderText = "EMAIL"
                .Columns(12).HeaderText = "REMARKS"
                
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
                .Columns(16).Visible = False
                .Columns(17).Visible = False
                .Columns(18).Visible = False
                .Columns(19).Visible = False
                .Columns(20).Visible = False
                .Columns(21).Visible = False
                .Columns(22).Visible = False
                .Columns(23).Visible = False
                .Columns(24).Visible = False
                
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        Else
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("We are sorry! Currently our server is busy, Please try again after some time or No record found on your criteria")
        End If
    End Sub
    Private Sub BindData()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.rYRSFR("SFR12M", Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString(), "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvShortFallReport
                .DataSource = dt
                Me.lblTotalRecords.Text = "Total Records : " & dt.Rows.Count
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "IC"
                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "PLAN CODE"
                .Columns(4).HeaderText = "EFFECTIVE_DATE"
                .Columns(5).HeaderText = "PHONE HOUSE"
                .Columns(6).HeaderText = "PHONE MOBILE"
                .Columns(7).HeaderText = "PHONE OFFICE"
                .Columns(8).HeaderText = "EMAIL"
                .Columns(9).HeaderText = "REMARKS"

                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
                .Columns(16).Visible = False
                .Columns(17).Visible = False
                .Columns(18).Visible = False
                .Columns(19).Visible = False
                .Columns(20).Visible = False
                .Columns(21).Visible = False
                .Columns(22).Visible = False
                .Columns(23).Visible = False
                .Columns(24).Visible = False
                .Columns(25).Visible = False
                .Columns(26).Visible = False
                .Columns(27).Visible = False
                .Columns(28).Visible = False
                .Columns(29).Visible = False
                .Columns(30).Visible = False
                .Columns(31).Visible = False
                .Columns(32).Visible = False
                .Columns(33).Visible = False
                .Columns(34).Visible = False
                .Columns(35).Visible = False
                .Columns(36).Visible = False
                .Columns(37).Visible = False
                .Columns(38).Visible = False
                .Columns(39).Visible = False
                .Columns(40).Visible = False
                .Columns(41).Visible = False
                .Columns(42).Visible = False
                .Columns(43).Visible = False
                .Columns(44).Visible = False
                .Columns(45).Visible = False
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        Else
            Me.dgvShortFallReport.DataSource = dt
            Me.lblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("We are sorry! Currently our server is busy, Please try again after some time or No record found on your criteria")
        End If
    End Sub
    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        Select Case Me.lblREF1.Text
            Case "SHORTFALL"
                Xport2XcelNew()
            Case "NONP"
                Xport2XcelNONPaymnet()
        End Select

    End Sub
    Private Sub Xport2XcelNONPaymnet()
        Try
            If Me.dgvShortFallReport.RowCount > 0 Then
                SharedData.ReadyToHideMarquee = False
                StartMarqueeThread()
                Dim xApp As New Microsoft.Office.Interop.Excel.Application
                Dim xWB As Microsoft.Office.Interop.Excel.Workbook
                xWB = xApp.Workbooks.Add
                Dim dgRowCount As Integer = 0
                Dim xWName As String = ""
                Dim xRCount As Integer = 7
                Dim DCode As String = ""
                Dim Code As String = ""
                Do While dgRowCount < Me.dgvShortFallReport.RowCount
                    With Me.dgvShortFallReport.Rows(dgRowCount)
                        If Code <> .Cells("Code").Value.ToString.Trim Then
                            xWB.Worksheets.Add()
                            xWName = "Sheet" & xWB.Worksheets.Count
                            With xWB.Worksheets(xWName)
                                .Cells(1, 1) = "NON PAYMENT DETAILS FOR THE MONTH OF " & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString() & Me.cbMonthTo.ComboBox.SelectedValue.ToString()
                                .Cells(2, 1) = "Report # : MPNONP/" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
                                .Cells(3, 1) = "CODE : " & Me.dgvShortFallReport.Rows(dgRowCount).Cells("Code").Value.ToString.Trim

                                .Cells(5, 1) = "NO"
                                .Cells(5, 2) = "FILE NO"
                                .Cells(5, 3) = "IC"
                                .Cells(5, 4) = "FULL NAME"
                                .Cells(5, 5) = "PLAN CODE"
                                .Cells(5, 6) = "START DATE"
                                .Cells(5, 7) = "DUE DEDUCTION MONTH "
                                .Cells(5, 8) = "DUE PREMIUM"
                                .Cells(5, 9) = "PHONE HOUSE"
                                .Cells(5, 10) = "PHONE MOBILE"
                                .Cells(5, 11) = "PHONE OFFICE"
                                .Cells(5, 12) = "EMAIL"
                                .Cells(5, 13) = "REMARKS"
                            End With
                            xRCount = 6
                            Code = .Cells("Code").Value.ToString.Trim
                        End If
                        xWB.Worksheets(xWName).Cells(xRCount, 1) = "'" & (xRCount - 5).ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 2) = "'" & .Cells(1).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 3) = "'" & .Cells(2).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 4) = "'" & .Cells(3).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 5) = "'" & .Cells(4).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 6) = "'" & .Cells(5).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 7) = "'" & .Cells(6).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 8) = "'" & .Cells(7).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 9) = "'" & .Cells(8).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 10) = "'" & .Cells(9).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 11) = "'" & .Cells(10).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 12) = "'" & .Cells(11).Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 13) = ""
                    End With
                    xRCount += 1
                    dgRowCount += 1
                Loop
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                xApp.Visible = True
            Else
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("No record found")
            End If
        Catch ex As Exception
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("Error while exporting report" & ex.StackTrace.ToString())
        End Try
    End Sub
    Private Sub Xport2XcelNew()
        If Me.dgvShortFallReport.RowCount > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim dgRowCount As Integer = 0
            Dim xWName As String = ""
            Dim xRCount As Integer = 7
            Dim DCode As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM SHORT FALL REPORT"
                .Cells(2, 1) = "Report # : MPSFR/" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")

                .Cells(4, 1) = "IC"
                .Cells(4, 2) = "FULL NAME"
                .Cells(4, 3) = "PLAN CODE"
                .Cells(4, 4) = "EFFECTIVE DATE"
                .Cells(4, 5) = "PHONE HOUSE"
                .Cells(4, 6) = "PHONE MOBILE"
                .Cells(4, 7) = "PHONE OFFICE"
                .Cells(4, 8) = "EMAIL"
                .Cells(4, 9) = "REMARKS"

                .Columns(1).NumberFormat = "@"
                .Columns(2).NumberFormat = "@"
                .Columns(3).NumberFormat = "@"
                .Columns(4).NumberFormat = "@"
                .Columns(5).NumberFormat = "@"
                .Columns(6).NumberFormat = "@"
                .Columns(7).NumberFormat = "@"
                .Columns(8).NumberFormat = "@"
                .Columns(9).NumberFormat = "@"

                .Cells(4, 10) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "01"
                .Cells(4, 13) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "02"
                .Cells(4, 16) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "03"
                .Cells(4, 19) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "04"
                .Cells(4, 22) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "05"
                .Cells(4, 25) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "06"
                .Cells(4, 28) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "07"
                .Cells(4, 31) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "08"
                .Cells(4, 34) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "09"
                .Cells(4, 37) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "10"
                .Cells(4, 40) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "11"
                .Cells(4, 43) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "12"

                .Range("J4:L4").Merge()
                .Range("M4:O4").Merge()
                .Range("P4:R4").Merge()
                .Range("S4:U4").Merge()
                .Range("V4:X4").Merge()
                .Range("Y4:AA4").Merge()
                .Range("AB4:AD4").Merge()
                .Range("AE4:AG4").Merge()
                .Range("AH4:AJ4").Merge()
                .Range("AK4:AM4").Merge()
                .Range("AN4:AP4").Merge()
                .Range("AQ4:AS4").Merge()

                .Cells(5, 10) = "PREMIUM"
                .Cells(5, 11) = "RECEIVED AMOUNT"
                .Cells(5, 12) = "SHORT AMOUNT"
                .Cells(5, 13) = "PREMIUM"
                .Cells(5, 14) = "RECEIVED AMOUNT"
                .Cells(5, 15) = "SHORT AMOUNT"
                .Cells(5, 16) = "PREMIUM"
                .Cells(5, 17) = "RECEIVED AMOUNT"
                .Cells(5, 18) = "SHORT AMOUNT"
                .Cells(5, 19) = "PREMIUM"
                .Cells(5, 20) = "RECEIVED AMOUNT"
                .Cells(5, 21) = "SHORT AMOUNT"
                .Cells(5, 22) = "PREMIUM"
                .Cells(5, 23) = "RECEIVED AMOUNT"
                .Cells(5, 24) = "SHORT AMOUNT"
                .Cells(5, 25) = "PREMIUM"
                .Cells(5, 26) = "RECEIVED AMOUNT"
                .Cells(5, 27) = "SHORT AMOUNT"
                .Cells(5, 28) = "PREMIUM"
                .Cells(5, 29) = "RECEIVED AMOUNT"
                .Cells(5, 30) = "SHORT AMOUNT"
                .Cells(5, 31) = "PREMIUM"
                .Cells(5, 32) = "RECEIVED AMOUNT"
                .Cells(5, 33) = "SHORT AMOUNT"
                .Cells(5, 34) = "PREMIUM"
                .Cells(5, 35) = "RECEIVED AMOUNT"
                .Cells(5, 36) = "SHORT AMOUNT"
                .Cells(5, 37) = "PREMIUM"
                .Cells(5, 38) = "RECEIVED AMOUNT"
                .Cells(5, 39) = "SHORT AMOUNT"
                .Cells(5, 40) = "PREMIUM"
                .Cells(5, 41) = "RECEIVED AMOUNT"
                .Cells(5, 42) = "SHORT AMOUNT"
                .Cells(5, 43) = "PREMIUM"
                .Cells(5, 44) = "RECEIVED AMOUNT"
                .Cells(5, 45) = "SHORT AMOUNT"

                .Columns(10).NumberFormat = "#,##0.00"
                .Columns(13).NumberFormat = "#,##0.00"
                .Columns(16).NumberFormat = "#,##0.00"
                .Columns(19).NumberFormat = "#,##0.00"
                .Columns(22).NumberFormat = "#,##0.00"
                .Columns(25).NumberFormat = "#,##0.00"
                .Columns(28).NumberFormat = "#,##0.00"
                .Columns(31).NumberFormat = "#,##0.00"
                .Columns(34).NumberFormat = "#,##0.00"
                .Columns(37).NumberFormat = "#,##0.00"
                .Columns(40).NumberFormat = "#,##0.00"
                .Columns(43).NumberFormat = "#,##0.00"

            End With
            xRCount = 6

            Do While dgRowCount < Me.dgvShortFallReport.RowCount
                With Me.dgvShortFallReport.Rows(dgRowCount)
                    xWB.Worksheets(xWName).Cells(xRCount, 1) = "'" & .Cells("IC").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 2) = "'" & .Cells("FULLNAME").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 3) = "'" & .Cells("DCODE").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 4) = "'" & .Cells("effective_date").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 5) = "'" & .Cells("phone_hse").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 6) = "'" & .Cells("phone_mobile").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 7) = "'" & .Cells("phone_off").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 8) = "'" & .Cells("email").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 9) = "'" & .Cells("remarks").Value.ToString.Trim
                    If Not (IsDBNull(.Cells("p1").Value.ToString.Trim) Or (.Cells("p1").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 10) = FormatNumber(.Cells("p1").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r1").Value.ToString.Trim) Or (.Cells("r1").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 11) = FormatNumber(.Cells("r1").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s1").Value.ToString.Trim) Or (.Cells("s1").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 12) = FormatNumber(.Cells("s1").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p2").Value.ToString.Trim) Or (.Cells("p2").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 13) = FormatNumber(.Cells("p2").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r2").Value.ToString.Trim) Or (.Cells("r2").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 14) = FormatNumber(.Cells("r2").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s2").Value.ToString.Trim) Or (.Cells("s2").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 15) = FormatNumber(.Cells("s2").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p3").Value.ToString.Trim) Or (.Cells("p3").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 16) = FormatNumber(.Cells("p3").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r3").Value.ToString.Trim) Or (.Cells("r3").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 17) = FormatNumber(.Cells("r3").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s3").Value.ToString.Trim) Or (.Cells("s3").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 18) = FormatNumber(.Cells("s3").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p4").Value.ToString.Trim) Or (.Cells("p4").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 19) = FormatNumber(.Cells("p4").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r4").Value.ToString.Trim) Or (.Cells("r4").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 20) = FormatNumber(.Cells("r4").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s4").Value.ToString.Trim) Or (.Cells("s4").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 21) = FormatNumber(.Cells("s4").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p5").Value.ToString.Trim) Or (.Cells("p5").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 22) = FormatNumber(.Cells("p5").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r5").Value.ToString.Trim) Or (.Cells("r5").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 23) = FormatNumber(.Cells("r5").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s5").Value.ToString.Trim) Or (.Cells("s5").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 24) = FormatNumber(.Cells("s5").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p6").Value.ToString.Trim) Or (.Cells("p6").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 25) = FormatNumber(.Cells("p6").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r6").Value.ToString.Trim) Or (.Cells("r6").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 26) = FormatNumber(.Cells("r6").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s6").Value.ToString.Trim) Or (.Cells("s6").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 27) = FormatNumber(.Cells("s6").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p7").Value.ToString.Trim) Or (.Cells("p7").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 28) = FormatNumber(.Cells("p7").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r7").Value.ToString.Trim) Or (.Cells("r7").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 29) = FormatNumber(.Cells("r7").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s7").Value.ToString.Trim) Or (.Cells("s7").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 30) = FormatNumber(.Cells("s7").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p8").Value.ToString.Trim) Or (.Cells("p8").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 31) = FormatNumber(.Cells("p8").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r8").Value.ToString.Trim) Or (.Cells("r8").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 32) = FormatNumber(.Cells("r8").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s8").Value.ToString.Trim) Or (.Cells("s8").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 33) = FormatNumber(.Cells("s8").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p9").Value.ToString.Trim) Or (.Cells("p9").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 34) = FormatNumber(.Cells("p9").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r9").Value.ToString.Trim) Or (.Cells("r9").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 35) = FormatNumber(.Cells("r9").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s9").Value.ToString.Trim) Or (.Cells("s9").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 36) = FormatNumber(.Cells("s9").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p10").Value.ToString.Trim) Or (.Cells("p10").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 37) = FormatNumber(.Cells("p10").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r10").Value.ToString.Trim) Or (.Cells("r10").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 38) = FormatNumber(.Cells("r10").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s10").Value.ToString.Trim) Or (.Cells("s10").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 39) = FormatNumber(.Cells("s10").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p11").Value.ToString.Trim) Or (.Cells("p11").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 40) = FormatNumber(.Cells("p11").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r11").Value.ToString.Trim) Or (.Cells("r11").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 41) = FormatNumber(.Cells("r11").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s11").Value.ToString.Trim) Or (.Cells("s11").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 42) = FormatNumber(.Cells("s11").Value.ToString.Trim, 2)
                    End If

                    If Not (IsDBNull(.Cells("p12").Value.ToString.Trim) Or (.Cells("p12").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 43) = FormatNumber(.Cells("p12").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("r12").Value.ToString.Trim) Or (.Cells("r12").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 44) = FormatNumber(.Cells("r12").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("s12").Value.ToString.Trim) Or (.Cells("s12").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 45) = FormatNumber(.Cells("s12").Value.ToString.Trim, 2)
                    End If
                End With
                xRCount += 1
                dgRowCount += 1
            Loop
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("No record found")
        End If
    End Sub
    Private Sub Xport2XcelNONP()
        If Me.dgvShortFallReport.RowCount > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim dgRowCount As Integer = 0
            Dim xWName As String = ""
            Dim xRCount As Integer = 7
            Dim DCode As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT DETAILS FOR THE YEAR OF " & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString()
                .Cells(2, 1) = "Report # : MPNONP/" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")

                .Cells(4, 1) = "IC"
                .Cells(4, 2) = "FULL NAME"
                .Cells(4, 3) = "PLAN CODE"
                .Cells(4, 4) = "EFFECTIVE DATE"
                .Cells(4, 5) = "STATUS"
                .Cells(4, 6) = "PHONE HOUSE"
                .Cells(4, 7) = "PHONE MOBILE"
                .Cells(4, 8) = "PHONE OFFICE"
                .Cells(4, 9) = "EMAIL"
                .Cells(4, 10) = "REMARKS"

                .Columns(1).NumberFormat = "@"
                .Columns(2).NumberFormat = "@"
                .Columns(3).NumberFormat = "@"
                .Columns(4).NumberFormat = "@"
                .Columns(5).NumberFormat = "@"
                .Columns(6).NumberFormat = "@"
                .Columns(7).NumberFormat = "@"
                .Columns(8).NumberFormat = "@"
                .Columns(9).NumberFormat = "@"
                .Columns(10).NumberFormat = "@"

                .Cells(4, 11) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "01"
                .Cells(4, 12) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "02"
                .Cells(4, 13) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "03"
                .Cells(4, 14) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "04"
                .Cells(4, 15) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "05"
                .Cells(4, 16) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "06"
                .Cells(4, 17) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "07"
                .Cells(4, 18) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "08"
                .Cells(4, 19) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "09"
                .Cells(4, 20) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "10"
                .Cells(4, 21) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "11"
                .Cells(4, 22) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "12"

                .Columns(11).NumberFormat = "#,##0.00"
                .Columns(12).NumberFormat = "#,##0.00"
                .Columns(13).NumberFormat = "#,##0.00"
                .Columns(14).NumberFormat = "#,##0.00"
                .Columns(15).NumberFormat = "#,##0.00"
                .Columns(16).NumberFormat = "#,##0.00"
                .Columns(17).NumberFormat = "#,##0.00"
                .Columns(18).NumberFormat = "#,##0.00"
                .Columns(19).NumberFormat = "#,##0.00"
                .Columns(20).NumberFormat = "#,##0.00"
                .Columns(21).NumberFormat = "#,##0.00"
                .Columns(22).NumberFormat = "#,##0.00"
            End With
            xRCount = 6
            Dim cMonth As Integer

            Dim s As String
            s = Me.cbMonthTo.ComboBox.SelectedValue
            cMonth = Me.cbMonthTo.ComboBox.SelectedValue
            Do While dgRowCount < Me.dgvShortFallReport.RowCount
                If sPremiumCheck(Me.dgvShortFallReport.Rows(dgRowCount).Cells("ID").Value.ToString.Trim, Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()) Then
                    With Me.dgvShortFallReport.Rows(dgRowCount)
                        xWB.Worksheets(xWName).Cells(xRCount, 1) = "'" & .Cells("IC").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 2) = "'" & .Cells("FULLNAME").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 3) = "'" & .Cells("DCODE").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 4) = "'" & .Cells("sdate").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 5) = "'" & .Cells("STATUS").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 6) = "'" & .Cells("contactno").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 7) = "'" & .Cells("phone_mobile").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 8) = "'" & .Cells("phone_off").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 9) = "'" & .Cells("email").Value.ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRCount, 10) = "'" & .Cells("remarks").Value.ToString.Trim
                        Dim sYr, eYr As String
                        Dim eDate, M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12 As DateTime
                        sYr = .Cells("sdate").Value.ToString.Trim()

                        eDate = sYr.Substring(0, 10)
                        M1 = "28/01/" & Me.ToolStripcmbYear.ComboBox.SelectedValue
                        M2 = "28/02/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M3 = "28/03/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M4 = "28/04/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M5 = "28/05/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M6 = "28/06/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M7 = "28/07/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M8 = "28/08/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M9 = "28/09/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M10 = "28/10/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M11 = "28/11/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        M12 = "28/12/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()

                        eYr = "01/28/" & Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString.Trim()
                        If eDate < M1 Then
                            If cMonth = "1" Or cMonth > "1" Then
                                If Not (IsDBNull(.Cells("p1").Value.ToString.Trim) Or (.Cells("p1").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p1").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 11) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M2 Then
                            If cMonth = "2" Or cMonth > "2" Then
                                If Not (IsDBNull(.Cells("p2").Value.ToString.Trim) Or (.Cells("p2").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p2").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 12) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M3 Then
                            If cMonth = "3" Or cMonth > "3" Then
                                If Not (IsDBNull(.Cells("p3").Value.ToString.Trim) Or (.Cells("p3").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p3").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 13) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M4 Then
                            If cMonth = "4" Or cMonth > "4" Then
                                If Not (IsDBNull(.Cells("p4").Value.ToString.Trim) Or (.Cells("p4").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p4").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 14) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M5 Then
                            If cMonth = "5" Or cMonth > "5" Then
                                If Not (IsDBNull(.Cells("p5").Value.ToString.Trim) Or (.Cells("p5").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p5").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 15) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                        If eDate < M6 Then
                            If cMonth = "6" Or cMonth > "6" Then
                                If Not (IsDBNull(.Cells("p6").Value.ToString.Trim) Or (.Cells("p6").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p6").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 16) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M7 Then
                            If cMonth = "7" Or cMonth > "7" Then
                                If Not (IsDBNull(.Cells("p7").Value.ToString.Trim) Or (.Cells("p7").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p7").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 17) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                        If eDate < M8 Then
                            If cMonth = "8" Or cMonth > "8" Then
                                If Not (IsDBNull(.Cells("p8").Value.ToString.Trim) Or (.Cells("p8").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p8").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 18) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                        If eDate < M9 Then
                            If cMonth = "9" Or cMonth > "9" Then
                                If Not (IsDBNull(.Cells("p9").Value.ToString.Trim) Or (.Cells("p9").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p9").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 19) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                        If eDate < M10 Then
                            If cMonth = "10" Or cMonth > "10" Then
                                If Not (IsDBNull(.Cells("p10").Value.ToString.Trim) Or (.Cells("p10").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p10").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 20) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                        If eDate < M11 Then
                            If cMonth = "11" Or cMonth > "11" Then
                                If Not (IsDBNull(.Cells("p11").Value.ToString.Trim) Or (.Cells("p11").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p11").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 21) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If

                        If eDate < M12 Then
                            If cMonth = "12" Or cMonth > "12" Then
                                If Not (IsDBNull(.Cells("p12").Value.ToString.Trim) Or (.Cells("p12").Value.ToString.Trim) = "") Then
                                    If Not FormatNumber(.Cells("p12").Value.ToString.Trim, 2) > 0 Then
                                        xWB.Worksheets(xWName).Cells(xRCount, 22) = FormatNumber(.Cells("cp").Value.ToString.Trim, 2)
                                    End If
                                End If
                            End If
                        End If
                    End With
                    xRCount += 1
                End If
                dgRowCount += 1
            Loop

            xWB.Worksheets(xWName).Cells(xRCount, 1) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 2) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 3) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 4) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 5) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 6) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 7) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 8) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 9) = ""
            xWB.Worksheets(xWName).Cells(xRCount, 10) = ""

            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("No record found")
        End If
    End Sub
    Private Function sPremiumCheck(ByVal id As String, ByVal sYr As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("RNONPAYMENT", id, sYr, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim sRes As String
                sRes = dr("Angkasa_Bulan_Potongan")
                Dim sMonth As String
                sMonth = sYr + Me.cbMonthTo.ComboBox.SelectedValue.ToString.Trim()
                If (dr("Angkasa_Bulan_Potongan") = sMonth Or dr("Angkasa_Bulan_Potongan") >= sMonth) Then
                    Return False
                End If
            Next
        Else
            Return True
        End If
        Return True
    End Function
#Region "Progress Bar"
    Private Shared SharedData As New SharedObject()
    Protected Overridable Sub StartMarqueeThread()
        Dim t As New Threading.Thread(AddressOf ShowMarqueeForm)
        t.Start()
    End Sub
    Protected Overridable Sub ShowMarqueeForm()
        Dim L As New Loading()
        L.Show()
        L.Update()
        Do
            SyncLock SharedData
                If SharedData.ReadyToHideMarquee Then
                    Exit Do
                End If
            End SyncLock
            Application.DoEvents()
        Loop
    End Sub
    Private Class SharedObject
        Public ReadyToHideMarquee As Boolean
    End Class
#End Region
End Class