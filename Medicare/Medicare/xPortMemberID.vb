Public Class xPortMemberID
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub xPortMemberID_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub xPortMemberID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        
        xPort2Xcel2()
        
    End Sub
    Private Sub xPort2Xcel2()
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim dt1 As New DataTable
        dt1 = _objBusi.getSubmissionDetails_MID("WOCID", "", "", "", Conn)
        Dim xWName As String = ""
        Dim xRowCount As Integer = 0
        xWB.Worksheets.Add()
        xWName = "Sheet" & (xWB.Worksheets.Count).ToString.Trim
        With xWB.Worksheets(xWName)
            .Cells(1, 1) = "SUBMISSION TO SUN LIFE MALAYSIA TAKAFUL BERHAD"
            .Cells(2, 1) = "WITH OUT MEMBER/CLIENT ID DETAILS "
            .Cells(3, 1) = "EXPORTED ON : " & Now()

            .Cells(5, 1) = "Pol Num"
            .Cells(5, 2) = "Sub Num"
            .Cells(5, 3) = "Tran Type"
            .Cells(5, 4) = "Mem Num"
            .Cells(5, 5) = "Dep Num"
            .Cells(5, 6) = "Clnt Num"
            .Cells(5, 7) = "IC No"
            .Cells(5, 8) = "Family Rel"
            .Cells(5, 9) = "Eff Date"
            .Cells(5, 10) = "Expiry Date"
            .Cells(5, 11) = "Member Termination Date"
            .Cells(5, 12) = "Plan No"
            .Cells(5, 13) = "Plan Description"
            .Cells(5, 14) = "Surname"
            .Cells(5, 15) = "Name Fmt"
            .Cells(5, 16) = "Sex"
            .Cells(5, 17) = "Marital Status"
            .Cells(5, 18) = "Street"
            .Cells(5, 19) = "Line 1"
            .Cells(5, 20) = "Line 2"
            .Cells(5, 21) = "Line 3"
            .Cells(5, 22) = "Country"
            .Cells(5, 23) = "Telephone (Home)"
            .Cells(5, 24) = "Telephone (Office)"
            .Cells(5, 25) = "Mobile No"
            .Cells(5, 26) = "Nationality"
            .Cells(5, 27) = "DOB"
            .Cells(5, 28) = "Age"
            .Cells(5, 29) = "Gross Contribution"
            .Cells(5, 30) = "Headcount"
            .Cells(5, 31) = "Addr Type"
            .Cells(5, 32) = "Refund Ind"
            .Cells(5, 33) = "Type of Data"
            .Cells(5, 34) = "Date Prv Policy"
            .Cells(5, 35) = "Bank Account No"
            .Cells(5, 36) = "Application No"
            .Cells(5, 37) = "Medical Exclusions"
            .Cells(5, 38) = "No of Beneficiary"

            .Cells(5, 39) = "Beneficiary #1 Full Name"
            .Cells(5, 40) = "Beneficiary #1 Sex"
            .Cells(5, 41) = "Beneficiary #1 Marital Status"
            .Cells(5, 42) = "Beneficiary #1 DOB"
            .Cells(5, 43) = "Beneficiary #1 IC No"
            .Cells(5, 44) = "Beneficiary #1 Nationality"
            .Cells(5, 45) = "Beneficiary #1 Relationship"
            .Cells(5, 46) = "Beneficiary #1 Percentage"

            .Cells(5, 47) = "Beneficiary #2 Full Name"
            .Cells(5, 48) = "Beneficiary #2 Sex"
            .Cells(5, 49) = "Beneficiary #2 Marital Status"
            .Cells(5, 50) = "Beneficiary #2 DOB"
            .Cells(5, 51) = "Beneficiary #2 IC No"
            .Cells(5, 52) = "Beneficiary #2 Nationality"
            .Cells(5, 53) = "Beneficiary #2 Relationship"
            .Cells(5, 54) = "Beneficiary #2 Percentage"

            .Cells(5, 55) = "Beneficiary #3 Full Name"
            .Cells(5, 56) = "Beneficiary #3 Sex"
            .Cells(5, 57) = "Beneficiary #3 Marital Status"
            .Cells(5, 58) = "Beneficiary #3 DOB"
            .Cells(5, 59) = "Beneficiary #3 IC No"
            .Cells(5, 60) = "Beneficiary #3 Nationality"
            .Cells(5, 61) = "Beneficiary #3 Relationship"
            .Cells(5, 62) = "Beneficiary #3 Percentage"

            .Cells(5, 63) = "Beneficiary #4 Full Name"
            .Cells(5, 64) = "Beneficiary #4 Sex"
            .Cells(5, 65) = "Beneficiary #4 Marital Status"
            .Cells(5, 66) = "Beneficiary #4 DOB"
            .Cells(5, 67) = "Beneficiary #4 IC No"
            .Cells(5, 68) = "Beneficiary #4 Nationality"
            .Cells(5, 69) = "Beneficiary #4 Relationship"
            .Cells(5, 70) = "Beneficiary #4 Percentage"

            .Cells(5, 71) = "Beneficiary #5 Full Name"
            .Cells(5, 72) = "Beneficiary #5 Sex"
            .Cells(5, 73) = "Beneficiary #5 Marital Status"
            .Cells(5, 74) = "Beneficiary #5 DOB"
            .Cells(5, 75) = "Beneficiary #5 IC No"
            .Cells(5, 76) = "Beneficiary #5 Nationality"
            .Cells(5, 77) = "Beneficiary #5 Relationship"
            .Cells(5, 78) = "Beneficiary #5 Percentage"

            .Cells(5, 79) = "Beneficiary #6 Full Name"
            .Cells(5, 80) = "Beneficiary #6 Sex"
            .Cells(5, 81) = "Beneficiary #6 Marital Status"
            .Cells(5, 82) = "Beneficiary #6 DOB"
            .Cells(5, 83) = "Beneficiary #6 IC No"
            .Cells(5, 84) = "Beneficiary #6 Nationality"
            .Cells(5, 85) = "Beneficiary #6 Relationship"
            .Cells(5, 86) = "Beneficiary #6 Percentage"

            .Cells(5, 87) = "Beneficiary #7 Full Name"
            .Cells(5, 88) = "Beneficiary #7 Sex"
            .Cells(5, 89) = "Beneficiary #7 Marital Status"
            .Cells(5, 90) = "Beneficiary #7 DOB"
            .Cells(5, 91) = "Beneficiary #7 IC No"
            .Cells(5, 92) = "Beneficiary #7 Nationality"
            .Cells(5, 93) = "Beneficiary #7 Relationship"
            .Cells(5, 94) = "Beneficiary #7 Percentage"

            .Cells(5, 95) = "Beneficiary #8 Full Name"
            .Cells(5, 96) = "Beneficiary #8 Sex"
            .Cells(5, 97) = "Beneficiary #8 Marital Status"
            .Cells(5, 98) = "Beneficiary #8 DOB"
            .Cells(5, 99) = "Beneficiary #8 IC No"
            .Cells(5, 100) = "Beneficiary #8 Nationality"
            .Cells(5, 101) = "Beneficiary #8 Relationship"
            .Cells(5, 102) = "Beneficiary #8 Percentage"

            .Cells(5, 103) = "Beneficiary #9 Full Name"
            .Cells(5, 104) = "Beneficiary #9 Sex"
            .Cells(5, 105) = "Beneficiary #9 Marital Status"
            .Cells(5, 106) = "Beneficiary #9 DOB"
            .Cells(5, 107) = "Beneficiary #9 IC No"
            .Cells(5, 108) = "Beneficiary #9 Nationality"
            .Cells(5, 109) = "Beneficiary #9 Relationship"
            .Cells(5, 110) = "Beneficiary #9 Percentage"

            .Cells(5, 111) = "Beneficiary #10 Full Name"
            .Cells(5, 112) = "Beneficiary #10 Sex"
            .Cells(5, 113) = "Beneficiary #10 Marital Status"
            .Cells(5, 114) = "Beneficiary #10 DOB"
            .Cells(5, 115) = "Beneficiary #10 IC No"
            .Cells(5, 116) = "Beneficiary #10 Nationality"
            .Cells(5, 117) = "Beneficiary #10 Relationship"
            .Cells(5, 118) = "Beneficiary #10 Percentage"

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
        End With
        xRowCount = 6
        For Each dr As DataRow In dt1.Rows
            Dim dt As New DataTable
            dt = _objBusi.getSubmissionDetails_MID("SUBMISSION", dr("ID").ToString.Trim(), "", dr("DEDUCTION_CODE").ToString.Trim(), Conn)
            If dt.Rows.Count > 0 Then
                Dim drCount As Integer = 0
                Do While drCount < dt.Rows.Count
                    With dt.Rows(drCount)
                        xWB.Worksheets(xWName).Cells(xRowCount, 1) = .Item("polnum").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 2) = .Item("subnum").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 3) = .Item("transtype").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 4) = .Item("memnum").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 5) = .Item("depnum").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 6) = .Item("clntnum").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 7) = .Item("icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 8) = .Item("familyrel").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 9) = .Item("effdate").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 10) = .Item("expirydate").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 11) = .Item("memterminationdate").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 12) = .Item("planno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 13) = .Item("plandescription").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 14) = .Item("surname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 15) = .Item("namefmt").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 16) = .Item("sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 17) = .Item("maritalstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 18) = .Item("add1").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 19) = .Item("add2").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 20) = .Item("add3").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 21) = .Item("add4").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 22) = .Item("country").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 23) = .Item("telephone").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 24) = .Item("telephoneoff").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 25) = .Item("mobileno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 26) = .Item("nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 27) = .Item("memdob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 28) = .Item("age").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 29) = .Item("grosscontribution").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 30) = .Item("headcount").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 31) = .Item("addresstype").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 32) = .Item("refund").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 33) = .Item("typeofdata").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 34) = .Item("dateprvpolicy").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 35) = .Item("bankaccountno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 36) = .Item("applicationno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 37) = .Item("medicalexclusions").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 38) = .Item("noofbenificiary").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 39) = .Item("b1fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 40) = .Item("b1sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 41) = .Item("b1mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 42) = .Item("b1dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 43) = .Item("b1icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 44) = .Item("b1nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 45) = .Item("b1relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 46) = .Item("b1per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 47) = .Item("b2fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 48) = .Item("b2sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 49) = .Item("b2mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 50) = .Item("b2dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 51) = .Item("b2icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 52) = .Item("b2nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 53) = .Item("b2relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 54) = .Item("b2per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 55) = .Item("b3fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 56) = .Item("b3sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 57) = .Item("b3mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 58) = .Item("b3dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 59) = .Item("b3icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 60) = .Item("b3nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 61) = .Item("b3relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 62) = .Item("b3per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 63) = .Item("b4fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 64) = .Item("b4sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 65) = .Item("b4mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 66) = .Item("b4dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 67) = .Item("b4icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 68) = .Item("b4nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 69) = .Item("b4relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 70) = .Item("b4per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 71) = .Item("b5fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 72) = .Item("b5sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 73) = .Item("b5mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 74) = .Item("b5dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 75) = .Item("b5icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 76) = .Item("b5nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 77) = .Item("b5relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 78) = .Item("b5per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 79) = .Item("b6fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 80) = .Item("b6sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 81) = .Item("b6mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 82) = .Item("b6dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 83) = .Item("b6icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 84) = .Item("b6nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 85) = .Item("b6relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 86) = .Item("b6per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 87) = .Item("b7fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 88) = .Item("b7sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 89) = .Item("b7mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 90) = .Item("b7dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 91) = .Item("b7icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 92) = .Item("b7nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 93) = .Item("b7relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 94) = .Item("b7per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 95) = .Item("b8fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 96) = .Item("b8sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 97) = .Item("b8mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 98) = .Item("b8dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 99) = .Item("b8icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 100) = .Item("b8nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 101) = .Item("b8relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 102) = .Item("b8per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 103) = .Item("b9fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 104) = .Item("b9sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 105) = .Item("b9mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 106) = .Item("b9dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 107) = .Item("b9icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 108) = .Item("b9nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 109) = .Item("b9relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 110) = .Item("b9per").ToString.Trim

                        xWB.Worksheets(xWName).Cells(xRowCount, 111) = .Item("b10fullname").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 112) = .Item("b10sex").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 113) = .Item("b10mstatus").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 114) = .Item("b10dob").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 115) = .Item("b10icno").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 116) = .Item("b10nationality").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 117) = .Item("b10relationship").ToString.Trim
                        xWB.Worksheets(xWName).Cells(xRowCount, 118) = .Item("b10per").ToString.Trim
                    End With
                    xRowCount += 1
                    drCount += 1
                Loop
            End If
        Next
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        xApp.Visible = True
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
End Class