Public Class fEndorsSubmission
    Dim Conn As DbConnection = New SqlConnection
    Dim BatchNo As String = ""
    Dim _objBusi As New Business
    Private Sub fEndorsSubmission_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fEndorsSubmission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
        popUpSBNo()
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Effective Date (From) (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If
        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Effective Date (To) (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Effective Date (From) in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Effective Date (To) in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    BINDDATA()
                Else
                    MsgBox("Effective Date (To) is < Effective Date (From).")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Sub popUpSBNo()
        Dim dt, dtc As New DataTable
        dt = _objBusi.getDetails_II("ENDORSEMENT", "", "", "", "", "", "", "", "", "", "S", Conn)
        If dt.Rows.Count > 0 Then
            Me.tscbESBatchNo.ComboBox.DataSource = dt
            Me.tscbESBatchNo.ComboBox.ValueMember = "SUBMISSION_BATCHNO"
            Me.tscbESBatchNo.ComboBox.DisplayMember = "SUBMISSION_BATCHNO"
        End If
        dtc = _objBusi.getDetails_II("ENDORSEMENT", "", "", "", "", "", "", "", "", "", "ESC", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvEAI
                .DataSource = dtc
                .Columns(0).Visible = False 'ID
            End With
        End If
    End Sub
    Private Sub BINDDATA()
        Dim varFrmDay As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim varFrmMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim varFrmYear As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim varFrmDate As String = varFrmMonth & "/" & varFrmDay & "/" & varFrmYear

        Dim varToDay As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim varToMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim varToYear As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim varToDate As String = varToMonth & "/" & varToDay & "/" & varToYear

        Dim dt As New DataTable
        dt = _objBusi.getDetails_II("ENDORSEMENT", varFrmDate, varToDate, Me.lblREFNO.Text.ToString.Trim(), "", "", "", "", "", "", "ED", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvEPS
                .DataSource = dt
                .Columns(1).Visible = False 'ID 
                Me.lblTotalRecords.Text = "Total Records : " & .Rows.Count.ToString.Trim()
            End With
        Else
            Me.dgvEPS.DataSource = dt
            Me.lblTotalRecords.Text = "Total Records : 0 "
            MsgBox("No Record found!")
        End If
    End Sub
    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked Then
            Dim i As Integer = 0
            With Me.dgvEPS
                Do While i < .Rows.Count
                    .Rows(i).Cells(0).Value = 1
                    i += 1
                Loop
            End With
        Else
            Dim i As Integer = 0
            With Me.dgvEPS
                Do While i < .Rows.Count
                    .Rows(i).Cells(0).Value = 0
                    i += 1
                Loop
            End With
        End If
    End Sub
    Private Sub btnPSSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPSSubmit.Click
        Dim i As Integer = 0
        BatchNo = Now.Day & "/" & Now.Month & "/" & "ES" & "/" & Now.Year()
        With Me.dgvEPS
            Do While i < .Rows.Count
                If .Rows(i).Cells(0).Value = "1" Then
                    _objBusi.spUpdate("ENDORSEMENT", .Rows(i).Cells(1).Value.ToString(), BatchNo, "", "", "", "", "", "", "", "ES", Conn)
                End If
                i += 1
            Loop
        End With
        xPort2Xcel()
        Me.Close()
    End Sub
    Private Sub tsbtnESGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnESGo.Click
        ESBINDDATA()
    End Sub
    Private Sub ESBINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_II("ENDORSEMENT", Me.tscbESBatchNo.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "ESD", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvEPAI
                .DataSource = dt
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvEPAI.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub llXport2Xcel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llXport2Xcel.LinkClicked
        xPort2Xcel()
    End Sub
    Private Sub xPort2Xcel()
        If Me.dgvEPS.RowCount > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim varFromDay As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
            Dim varFromMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
            Dim varFromYear As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
            Dim DateFrom As String = varFromMonth & "/" & varFromDay & "/" & varFromYear

            Dim varToDay As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
            Dim varToMonth As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
            Dim varToYear As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
            Dim DateTo As String = varToMonth & "/" & varToDay & "/" & varToYear
            Dim dgvrCount As Integer = 0
            Dim xWName As String = ""
            Dim xRowCount As Integer = 0
            Dim drCount As Integer = 0
            BatchNo = Now.Day & "/" & Now.Month & "/" & "ES" & "/" & Now.Year()
            xWB.Worksheets.Add()
            xWName = "Sheet" & (xWB.Worksheets.Count).ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SUBMISSION OF ENDORSEMENT BATCH NO : " & BatchNo
                .Cells(2, 1) = "SUBMISSION ON : " & Now()

                .Cells(5, 1) = "Endorsement Type"
                .Cells(5, 2) = "Pol Num"
                .Cells(5, 3) = "Sub Num"
                .Cells(5, 4) = "Tran Type"
                .Cells(5, 5) = "Mem Num"
                .Cells(5, 6) = "Dep Num"
                .Cells(5, 7) = "Clnt Num"
                .Cells(5, 8) = "IC No"
                .Cells(5, 9) = "Family Rel"
                .Cells(5, 10) = "Eff Date"
                .Cells(5, 11) = "Expiry Date"
                .Cells(5, 12) = "Member Termination Date"
                .Cells(5, 13) = "Plan No"
                .Cells(5, 14) = "Plan Description"
                .Cells(5, 15) = "Surname"
                .Cells(5, 16) = "Name Fmt"
                .Cells(5, 17) = "Sex"
                .Cells(5, 18) = "Marital Status"
                .Cells(5, 19) = "Street"
                .Cells(5, 20) = "Line 1"
                .Cells(5, 21) = "Line 2"
                .Cells(5, 22) = "Line 3"
                .Cells(5, 23) = "Country"
                .Cells(5, 24) = "Telephone (Home)"
                .Cells(5, 25) = "Telephone (Office)"
                .Cells(5, 26) = "Mobile No"
                .Cells(5, 27) = "Email"
                .Cells(5, 28) = "Nationality"
                .Cells(5, 29) = "DOB"
                .Cells(5, 30) = "Age"
                .Cells(5, 31) = "Gross Contribution"
                .Cells(5, 32) = "Headcount"
                .Cells(5, 33) = "Addr Type"
                .Cells(5, 34) = "Refund Ind"
                .Cells(5, 35) = "Type of Data"
                .Cells(5, 36) = "Date Prv Policy"
                .Cells(5, 37) = "Bank Account No"
                .Cells(5, 38) = "Application No"
                .Cells(5, 39) = "Medical Exclusions"
                .Cells(5, 40) = "No of Beneficiary"

                .Cells(5, 41) = "Beneficiary #1 Full Name"
                .Cells(5, 42) = "Beneficiary #1 Sex"
                .Cells(5, 43) = "Beneficiary #1 Marital Status"
                .Cells(5, 44) = "Beneficiary #1 DOB"
                .Cells(5, 45) = "Beneficiary #1 IC No"
                .Cells(5, 46) = "Beneficiary #1 Nationality"
                .Cells(5, 47) = "Beneficiary #1 Relationship"
                .Cells(5, 48) = "Beneficiary #1 Percentage"

                .Cells(5, 49) = "Beneficiary #2 Full Name"
                .Cells(5, 50) = "Beneficiary #2 Sex"
                .Cells(5, 51) = "Beneficiary #2 Marital Status"
                .Cells(5, 52) = "Beneficiary #2 DOB"
                .Cells(5, 53) = "Beneficiary #2 IC No"
                .Cells(5, 54) = "Beneficiary #2 Nationality"
                .Cells(5, 55) = "Beneficiary #2 Relationship"
                .Cells(5, 56) = "Beneficiary #2 Percentage"

                .Cells(5, 57) = "Beneficiary #3 Full Name"
                .Cells(5, 58) = "Beneficiary #3 Sex"
                .Cells(5, 59) = "Beneficiary #3 Marital Status"
                .Cells(5, 60) = "Beneficiary #3 DOB"
                .Cells(5, 61) = "Beneficiary #3 IC No"
                .Cells(5, 62) = "Beneficiary #3 Nationality"
                .Cells(5, 63) = "Beneficiary #3 Relationship"
                .Cells(5, 64) = "Beneficiary #3 Percentage"

                .Cells(5, 65) = "Beneficiary #4 Full Name"
                .Cells(5, 66) = "Beneficiary #4 Sex"
                .Cells(5, 67) = "Beneficiary #4 Marital Status"
                .Cells(5, 68) = "Beneficiary #4 DOB"
                .Cells(5, 69) = "Beneficiary #4 IC No"
                .Cells(5, 70) = "Beneficiary #4 Nationality"
                .Cells(5, 71) = "Beneficiary #4 Relationship"
                .Cells(5, 72) = "Beneficiary #4 Percentage"

                .Cells(5, 73) = "Beneficiary #5 Full Name"
                .Cells(5, 74) = "Beneficiary #5 Sex"
                .Cells(5, 75) = "Beneficiary #5 Marital Status"
                .Cells(5, 76) = "Beneficiary #5 DOB"
                .Cells(5, 77) = "Beneficiary #5 IC No"
                .Cells(5, 78) = "Beneficiary #5 Nationality"
                .Cells(5, 79) = "Beneficiary #5 Relationship"
                .Cells(5, 80) = "Beneficiary #5 Percentage"

                .Cells(5, 81) = "Beneficiary #6 Full Name"
                .Cells(5, 82) = "Beneficiary #6 Sex"
                .Cells(5, 83) = "Beneficiary #6 Marital Status"
                .Cells(5, 84) = "Beneficiary #6 DOB"
                .Cells(5, 85) = "Beneficiary #6 IC No"
                .Cells(5, 86) = "Beneficiary #6 Nationality"
                .Cells(5, 87) = "Beneficiary #6 Relationship"
                .Cells(5, 88) = "Beneficiary #6 Percentage"

                .Cells(5, 89) = "Beneficiary #7 Full Name"
                .Cells(5, 90) = "Beneficiary #7 Sex"
                .Cells(5, 91) = "Beneficiary #7 Marital Status"
                .Cells(5, 92) = "Beneficiary #7 DOB"
                .Cells(5, 93) = "Beneficiary #7 IC No"
                .Cells(5, 94) = "Beneficiary #7 Nationality"
                .Cells(5, 95) = "Beneficiary #7 Relationship"
                .Cells(5, 96) = "Beneficiary #7 Percentage"

                .Cells(5, 97) = "Beneficiary #8 Full Name"
                .Cells(5, 98) = "Beneficiary #8 Sex"
                .Cells(5, 99) = "Beneficiary #8 Marital Status"
                .Cells(5, 100) = "Beneficiary #8 DOB"
                .Cells(5, 101) = "Beneficiary #8 IC No"
                .Cells(5, 102) = "Beneficiary #8 Nationality"
                .Cells(5, 103) = "Beneficiary #8 Relationship"
                .Cells(5, 104) = "Beneficiary #8 Percentage"

                .Cells(5, 105) = "Beneficiary #9 Full Name"
                .Cells(5, 106) = "Beneficiary #9 Sex"
                .Cells(5, 107) = "Beneficiary #9 Marital Status"
                .Cells(5, 108) = "Beneficiary #9 DOB"
                .Cells(5, 109) = "Beneficiary #9 IC No"
                .Cells(5, 110) = "Beneficiary #9 Nationality"
                .Cells(5, 111) = "Beneficiary #9 Relationship"
                .Cells(5, 112) = "Beneficiary #9 Percentage"

                .Cells(5, 113) = "Beneficiary #10 Full Name"
                .Cells(5, 114) = "Beneficiary #10 Sex"
                .Cells(5, 115) = "Beneficiary #10 Marital Status"
                .Cells(5, 116) = "Beneficiary #10 DOB"
                .Cells(5, 117) = "Beneficiary #10 IC No"
                .Cells(5, 118) = "Beneficiary #10 Nationality"
                .Cells(5, 119) = "Beneficiary #10 Relationship"
                .Cells(5, 120) = "Beneficiary #10 Percentage"

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
                .Columns(11).NumberFormat = "@"
                .Columns(12).NumberFormat = "@"
                .Columns(13).NumberFormat = "@"
                .Columns(14).NumberFormat = "@"
                .Columns(15).NumberFormat = "@"
                .Columns(16).NumberFormat = "@"
                .Columns(17).NumberFormat = "@"
                .Columns(18).NumberFormat = "@"
                .Columns(19).NumberFormat = "@"
                .Columns(20).NumberFormat = "@"
                .Columns(21).NumberFormat = "@"
                .Columns(22).NumberFormat = "@"
                .Columns(23).NumberFormat = "@"
                .Columns(24).NumberFormat = "@"
                .Columns(25).NumberFormat = "@"
                .Columns(26).NumberFormat = "@"
                .Columns(27).NumberFormat = "@"
                .Columns(28).NumberFormat = "@"
                .Columns(29).NumberFormat = "@"
                .Columns(30).NumberFormat = "@"
                .Columns(31).NumberFormat = "@"
                .Columns(32).NumberFormat = "@"
                .Columns(33).NumberFormat = "@"
                .Columns(34).NumberFormat = "@"
                .Columns(35).NumberFormat = "@"
                .Columns(36).NumberFormat = "@"
                .Columns(37).NumberFormat = "@"
                .Columns(38).NumberFormat = "@"

                .Columns(39).NumberFormat = "@"
                .Columns(40).NumberFormat = "@"
                .Columns(41).NumberFormat = "@"
                .Columns(42).NumberFormat = "@"
                .Columns(43).NumberFormat = "@"
                .Columns(44).NumberFormat = "@"
                .Columns(45).NumberFormat = "@"
                .Columns(46).NumberFormat = "@"

                .Columns(47).NumberFormat = "@"
                .Columns(48).NumberFormat = "@"
                .Columns(49).NumberFormat = "@"
                .Columns(50).NumberFormat = "@"
                .Columns(51).NumberFormat = "@"
                .Columns(52).NumberFormat = "@"
                .Columns(53).NumberFormat = "@"
                .Columns(54).NumberFormat = "@"

                .Columns(55).NumberFormat = "@"
                .Columns(56).NumberFormat = "@"
                .Columns(57).NumberFormat = "@"
                .Columns(58).NumberFormat = "@"
                .Columns(59).NumberFormat = "@"
                .Columns(60).NumberFormat = "@"
                .Columns(61).NumberFormat = "@"
                .Columns(62).NumberFormat = "@"

                .Columns(63).NumberFormat = "@"
                .Columns(64).NumberFormat = "@"
                .Columns(65).NumberFormat = "@"
                .Columns(66).NumberFormat = "@"
                .Columns(67).NumberFormat = "@"
                .Columns(68).NumberFormat = "@"
                .Columns(69).NumberFormat = "@"
                .Columns(70).NumberFormat = "@"

                .Columns(71).NumberFormat = "@"
                .Columns(72).NumberFormat = "@"
                .Columns(73).NumberFormat = "@"
                .Columns(74).NumberFormat = "@"
                .Columns(75).NumberFormat = "@"
                .Columns(76).NumberFormat = "@"
                .Columns(77).NumberFormat = "@"
                .Columns(78).NumberFormat = "@"

                .Columns(79).NumberFormat = "@"
                .Columns(80).NumberFormat = "@"
                .Columns(81).NumberFormat = "@"
                .Columns(82).NumberFormat = "@"
                .Columns(83).NumberFormat = "@"
                .Columns(84).NumberFormat = "@"
                .Columns(85).NumberFormat = "@"
                .Columns(86).NumberFormat = "@"

                .Columns(87).NumberFormat = "@"
                .Columns(88).NumberFormat = "@"
                .Columns(89).NumberFormat = "@"
                .Columns(90).NumberFormat = "@"
                .Columns(91).NumberFormat = "@"
                .Columns(92).NumberFormat = "@"
                .Columns(93).NumberFormat = "@"
                .Columns(94).NumberFormat = "@"

                .Columns(95).NumberFormat = "@"
                .Columns(96).NumberFormat = "@"
                .Columns(97).NumberFormat = "@"
                .Columns(98).NumberFormat = "@"
                .Columns(99).NumberFormat = "@"
                .Columns(100).NumberFormat = "@"
                .Columns(101).NumberFormat = "@"
                .Columns(102).NumberFormat = "@"

                .Columns(103).NumberFormat = "@"
                .Columns(104).NumberFormat = "@"
                .Columns(105).NumberFormat = "@"
                .Columns(106).NumberFormat = "@"
                .Columns(107).NumberFormat = "@"
                .Columns(108).NumberFormat = "@"
                .Columns(109).NumberFormat = "@"
                .Columns(110).NumberFormat = "@"

                .Columns(111).NumberFormat = "@"
                .Columns(112).NumberFormat = "@"
                .Columns(113).NumberFormat = "@"
                .Columns(114).NumberFormat = "@"
                .Columns(115).NumberFormat = "@"
                .Columns(116).NumberFormat = "@"
                .Columns(117).NumberFormat = "@"
                .Columns(118).NumberFormat = "@"
                .Columns(119).NumberFormat = "@"
                .Columns(120).NumberFormat = "@"
            End With
            xRowCount = 6
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            With Me.dgvEPS
                Do While dgvrCount < .Rows.Count
                    If .Rows(dgvrCount).Cells(0).Value = "1" Then
                        If Not IsDBNull(.Rows(dgvrCount).Cells(1).Value) Then
                            Dim dt As New DataTable
                            dt = _objBusi.getEndorsementSubmission("ES", DateFrom, DateTo, .Rows(dgvrCount).Cells(1).Value.ToString().Trim(), "", "", Conn)
                            If dt.Rows.Count > 0 Then
                                For Each dr As DataRow In dt.Rows
                                    xWB.Worksheets(xWName).Cells(xRowCount, 1) = dr("etype").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 2) = dr("polnum").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 3) = dr("subnum").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 4) = dr("transtype").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 5) = dr("memnum").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 6) = dr("depnum").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 7) = dr("clntnum").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 8) = dr("icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 9) = dr("familyrel").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 10) = dr("effdate").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 11) = dr("expirydate").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 12) = dr("memterminationdate").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 13) = dr("planno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 14) = dr("plandescription").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 15) = dr("surname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 16) = dr("namefmt").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 17) = dr("sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 18) = dr("maritalstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 19) = dr("add1").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 20) = dr("add2").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 21) = dr("add3").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 22) = dr("add4").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 23) = dr("country").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 24) = dr("telephone").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 25) = dr("telephoneoff").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 26) = dr("mobileno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 27) = dr("email").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 28) = dr("nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 29) = dr("memdob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 30) = dr("age").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 31) = dr("grosscontribution").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 32) = dr("headcount").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 33) = dr("addresstype").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 34) = dr("refund").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 35) = dr("typeofdata").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 36) = dr("dateprvpolicy").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 37) = dr("bankaccountno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 38) = dr("applicationno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 39) = dr("medicalexclusions").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 40) = dr("noofbenificiary").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 41) = dr("b1fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 42) = dr("b1sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 43) = dr("b1mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 44) = dr("b1dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 45) = dr("b1icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 46) = dr("b1nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 47) = dr("b1relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 48) = dr("b1per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 49) = dr("b2fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 50) = dr("b2sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 51) = dr("b2mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 52) = dr("b2dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 53) = dr("b2icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 54) = dr("b2nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 55) = dr("b2relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 56) = dr("b2per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 57) = dr("b3fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 58) = dr("b3sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 59) = dr("b3mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 60) = dr("b3dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 61) = dr("b3icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 62) = dr("b3nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 63) = dr("b3relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 64) = dr("b3per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 65) = dr("b4fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 66) = dr("b4sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 67) = dr("b4mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 68) = dr("b4dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 69) = dr("b4icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 70) = dr("b4nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 71) = dr("b4relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 72) = dr("b4per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 73) = dr("b5fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 74) = dr("b5sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 75) = dr("b5mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 76) = dr("b5dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 77) = dr("b5icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 78) = dr("b5nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 79) = dr("b5relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 80) = dr("b5per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 81) = dr("b6fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 82) = dr("b6sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 83) = dr("b6mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 84) = dr("b6dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 85) = dr("b6icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 86) = dr("b6nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 87) = dr("b6relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 88) = dr("b6per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 89) = dr("b7fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 90) = dr("b7sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 91) = dr("b7mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 92) = dr("b7dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 93) = dr("b7icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 94) = dr("b7nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 95) = dr("b7relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 96) = dr("b7per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 97) = dr("b8fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 98) = dr("b8sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 99) = dr("b8mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 100) = dr("b8dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 101) = dr("b8icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 102) = dr("b8nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 103) = dr("b8relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 104) = dr("b8per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 105) = dr("b9fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 106) = dr("b9sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 107) = dr("b9mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 108) = dr("b9dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 109) = dr("b9icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 110) = dr("b9nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 111) = dr("b9relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 112) = dr("b9per").ToString.Trim

                                    xWB.Worksheets(xWName).Cells(xRowCount, 113) = dr("b10fullname").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 114) = dr("b10sex").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 115) = dr("b10mstatus").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 116) = dr("b10dob").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 117) = dr("b10icno").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 118) = dr("b10nationality").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 119) = dr("b10relationship").ToString.Trim
                                    xWB.Worksheets(xWName).Cells(xRowCount, 120) = dr("b10per").ToString.Trim

                                    xRowCount += 1
                                Next
                            End If
                        End If
                    End If
                    dgvrCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        End If
    End Sub
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
    Private Sub btnPAISubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPAISubmit.Click
        Dim i As Integer = 0
        With Me.dgvEPAI
            Do While i < .Rows.Count
                If Not IsDBNull(.Rows(i).Cells(1).Value) Then
                    If .Rows(i).Cells(0).Value = "1" Then
                        Dim sRes As String
                        sRes = _objBusi.spUpdate("ENDORSEMENT", .Rows(i).Cells(1).Value.ToString(), "", "", "", "", "", "", "", "", "EV", Conn)
                    End If
                End If
                i += 1
            Loop
            ESBINDDATA()
            popUpSBNo()
        End With
    End Sub
    Private Sub cmsEPSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsEPSDelete.Click
        With Me.dgvEPS
            If .SelectedRows.Count = 1 Then
                Dim sRes As String
                sRes = _objBusi.spUpdate("ENDORSEMENT", .CurrentRow.Cells(1).Value.ToString, "", "", "", "", "", "", "", "", "ED", Conn)
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the endorsement!")
                    BINDDATA()
                Else
                    MsgBox("Error while deleting the edorsement!")
                End If
            Else
                MsgBox("Please do select which you would like to Delete.")
            End If
        End With
    End Sub
    Private Sub cmsEPAIDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsEPAIDelete.Click
        With Me.dgvEPAI
            If .SelectedRows.Count = 1 Then
                Dim sRes As String
                sRes = _objBusi.spUpdate("ENDORSEMENT", .CurrentRow.Cells(1).Value.ToString, "", "", "", "", "", "", "", "", "ED", Conn)
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the endorsement!")
                    ESBINDDATA()
                Else
                    MsgBox("Error while deleting the edorsement!")
                End If
            Else
                MsgBox("Please do select which you would like to Delete.")
            End If
        End With
    End Sub
End Class