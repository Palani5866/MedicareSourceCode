Public Class xWrongPremium
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub xWrongPremium_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub xWrongPremium_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("XPORTWRONGPREMIUM", P1, P2, "", "", Me.lblPTYPE.Text.Trim(), Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvBlank
                .DataSource = dt
                .Columns(0).Visible = False 'ID
                .Columns(8).Visible = False 'ID
                .Columns(1).HeaderText = "FILE #"
                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "IC"
                .Columns(4).HeaderText = "DOB"
                .Columns(5).HeaderText = "AGE"
                .Columns(6).HeaderText = "DEDUCTION CODE"
                .Columns(7).HeaderText = "CURRENT PREMIUM"
            End With
        Else
            MsgBox("No Record found")
        End If
    End Sub
    Private Sub tsbtn_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Go.Click
        If Len(Me.tstxt_SearchBy1.Text.Trim) = 0 Then
            MsgBox("Required Deduction Code (From).")
            Me.tstxt_SearchBy1.Focus()
            Exit Sub
        End If
        If Len(Me.tstxt_SearchBy2.Text.Trim) = 0 Then
            MsgBox("Required Deduction Code (To).")
            Me.tstxt_SearchBy2.Focus()
            Exit Sub
        End If
        BINDDATA(Me.tstxt_SearchBy1.Text.Trim(), Me.tstxt_SearchBy2.Text.Trim())
    End Sub
    Private Sub tsbtn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtn_Export.Click
        If Me.lblPTYPE.Text.Trim() = "CC" Then
            xPortCC()
        Else
            xPortCPA()
        End If
    End Sub
    Private Sub xPortCC()
        If Me.dgvBlank.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWNAME As String = ""
            xWB.Worksheets.Add()
            xWNAME = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWNAME)
                .Cells(1, 1) = "WRONG PREMIUM DETAILS FOR CUEPACS CARE"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "AGE"
                .Cells(4, 7) = "DEDUCTION CODE"
                .Cells(4, 8) = "CURRENT PREMIUM"
                .Cells(4, 9) = "CORRECT PREMIUM"

                Dim xRCount As Integer = 5
                Dim dgvRCount As Integer = 0

                Do While dgvRCount < Me.dgvBlank.Rows.Count - 1
                    Dim PremiumAmount, OldPremiumAmount As Double
                    OldPremiumAmount = Me.dgvBlank.Rows(dgvRCount).Cells(7).Value
                    Dim S As String
                    Dim D As Date
                    D = Me.dgvBlank.Rows(dgvRCount).Cells(4).Value
                    S = Math.Floor(DateDiff(DateInterval.Day, D, Now()) / 365.25)
                    If S = "26" Then
                        S = S
                    End If
                    PremiumAmount = PremiumDetails(Me.dgvBlank.Rows(dgvRCount).Cells(0).Value.ToString.Trim(), Me.dgvBlank.Rows(dgvRCount).Cells(8).Value, Me.dgvBlank.Rows(dgvRCount).Cells(4).Value)
                    If OldPremiumAmount <> PremiumAmount Then
                        .Cells(xRCount, 1) = "'" & (xRCount - 4).ToString.Trim
                        .Cells(xRCount, 2) = Me.dgvBlank.Rows(dgvRCount).Cells(1).Value
                        .Cells(xRCount, 3) = Me.dgvBlank.Rows(dgvRCount).Cells(2).Value
                        .Cells(xRCount, 4) = Me.dgvBlank.Rows(dgvRCount).Cells(3).Value
                        If Not IsDBNull(Me.dgvBlank.Rows(dgvRCount).Cells(4).Value) Then
                            .Cells(xRCount, 5) = Me.dgvBlank.Rows(dgvRCount).Cells(4).Value
                        End If
                        .Cells(xRCount, 6) = Me.dgvBlank.Rows(dgvRCount).Cells(5).Value
                        .Cells(xRCount, 7) = Me.dgvBlank.Rows(dgvRCount).Cells(6).Value
                        .Cells(xRCount, 8) = Format(Me.dgvBlank.Rows(dgvRCount).Cells(7).Value, "Standard")

                        .Cells(xRCount, 9) = Format(PremiumAmount, "Standard")

                        xRCount += 1
                    End If
                    dgvRCount += 1
                Loop
            End With
            MsgBox("Exporting records to WRONG PREMIUM DETAILS FOR CUEPACS CARE LISTING completed.")
            xApp.Visible = True
        End If
    End Sub
    Private Sub xPortCPA()
        If Me.dgvBlank.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWSName As String = ""
            xWB.Worksheets.Add()
            xWSName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWSName)
                .Cells(1, 1) = "WRONG PREMIUM DETAILS FOR CUEPACS PA"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "AGE"
                .Cells(4, 7) = "SPOUSE FULL NAME"
                .Cells(4, 8) = "SPOUSE IC"
                .Cells(4, 9) = "SPOUSE DOB"
                .Cells(4, 10) = "SPOUSE AGE"
                .Cells(4, 11) = "DEDUCTION CODE"
                .Cells(4, 12) = "CURRENT PREMIUM"
                .Cells(4, 13) = "CORRECT PREMIUM"


                .Cells(4, 14) = "NAME"
                .Cells(4, 15) = "IC"
                .Cells(4, 16) = "DOB"
                .Cells(4, 17) = "AGE"
                .Cells(4, 18) = "NAME1"
                .Cells(4, 19) = "IC1"
                .Cells(4, 20) = "DOB1"
                .Cells(4, 21) = "AGE1"
                .Cells(4, 22) = "NAME2"
                .Cells(4, 23) = "IC2"
                .Cells(4, 24) = "DOB2"
                .Cells(4, 25) = "AGE2"
                .Cells(4, 26) = "NAME3"
                .Cells(4, 27) = "IC3"
                .Cells(4, 28) = "DOB3"
                .Cells(4, 29) = "AGE3"
                .Cells(4, 30) = "NAME4"
                .Cells(4, 31) = "IC4"
                .Cells(4, 32) = "DOB4"
                .Cells(4, 33) = "AGE4"
                .Cells(4, 34) = "NAME5"
                .Cells(4, 35) = "IC5"
                .Cells(4, 36) = "DOB5"
                .Cells(4, 37) = "AGE5"
                .Cells(4, 38) = "NAME6"
                .Cells(4, 39) = "IC6"
                .Cells(4, 40) = "DOB6"
                .Cells(4, 41) = "AGE6"
                .Cells(4, 42) = "NAME7"
                .Cells(4, 43) = "IC7"
                .Cells(4, 44) = "DOB7"
                .Cells(4, 45) = "AGE7"
                .Cells(4, 46) = "NAME8"
                .Cells(4, 47) = "IC8"
                .Cells(4, 48) = "DOB8"
                .Cells(4, 49) = "AGE8"
                .Cells(4, 50) = "NAME9"
                .Cells(4, 51) = "IC9"
                .Cells(4, 52) = "DOB9"
                .Cells(4, 53) = "AGE9"
                .Cells(4, 54) = "NAME10"
                .Cells(4, 55) = "IC10"
                .Cells(4, 56) = "DOB10"
                .Cells(4, 57) = "AGE10"

                Dim xRCount As Integer = 5
                Dim dgvRCount As Integer = 0

                Do While dgvRCount < Me.dgvBlank.Rows.Count - 1
                    Dim PremiumAmount, OldPremiumAmount As Double
                    OldPremiumAmount = Me.dgvBlank.Rows(dgvRCount).Cells(7).Value
                    PremiumAmount = PremiumDetails(Me.dgvBlank.Rows(dgvRCount).Cells(0).Value.ToString.Trim(), Me.dgvBlank.Rows(dgvRCount).Cells(8).Value, Me.dgvBlank.Rows(dgvRCount).Cells(4).Value)
                    If OldPremiumAmount <> PremiumAmount Then
                        .Cells(xRCount, 1) = "'" & (xRCount - 4).ToString.Trim
                        .Cells(xRCount, 2) = Me.dgvBlank.Rows(dgvRCount).Cells(1).Value
                        .Cells(xRCount, 3) = Me.dgvBlank.Rows(dgvRCount).Cells(2).Value
                        .Cells(xRCount, 4) = Me.dgvBlank.Rows(dgvRCount).Cells(3).Value
                        If Not IsDBNull(Me.dgvBlank.Rows(dgvRCount).Cells(4).Value) Then
                            .Cells(xRCount, 5) = Me.dgvBlank.Rows(dgvRCount).Cells(4).Value
                        End If
                        .Cells(xRCount, 6) = Me.dgvBlank.Rows(dgvRCount).Cells(5).Value
                        .Cells(xRCount, 11) = Me.dgvBlank.Rows(dgvRCount).Cells(6).Value
                        .Cells(xRCount, 12) = Format(Me.dgvBlank.Rows(dgvRCount).Cells(7).Value, "Standard")
                        .Cells(xRCount, 13) = Format(PremiumAmount, "Standard")


                        Dim dt As New DataTable
                        dt = _objBusi.getDetails("POLICYDETAILS", Me.dgvBlank.Rows(dgvRCount).Cells(0).Value.ToString.Trim(), "", "", "", "DEP", Conn)
                        If dt.Rows.Count > 0 Then
                            Dim colCount As Integer = 14
                            For Each dr As DataRow In dt.Rows
                                If dr("RELATIONSHIP").ToString.Trim().ToUpper = "SPOUSE" Then
                                    .Cells(xRCount, 7) = "'" & dr("FULL_NAME").ToString.Trim()
                                    .Cells(xRCount, 8) = "'" & dr("IC_NEW").ToString.Trim()
                                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                                        .Cells(xRCount, 9) = Format(dr("BIRTH_DATE"), "dd/MM/yyyy")
                                    End If
                                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                                        .Cells(xRCount, 10) = "'" & Math.Floor(DateDiff(DateInterval.Day, Convert.ToDateTime(Format(dr("BIRTH_DATE"), "dd/MM/yyyy")), Now()) / 365.25)
                                    End If
                                Else
                                    .Cells(xRCount, colCount) = "'" & dr("FULL_NAME").ToString.Trim()
                                    If Not IsDBNull(dr("IC_NEW")) Then
                                        .Cells(xRCount, colCount + 1) = "'" & dr("IC_NEW").ToString.Trim()
                                    End If
                                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                                        .Cells(xRCount, colCount + 2) = "'" & Format(dr("BIRTH_DATE"), "dd/MM/yyyy")
                                    End If
                                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                                        .Cells(xRCount, colCount + 3) = "'" & Math.Floor(DateDiff(DateInterval.Day, Convert.ToDateTime(Format(dr("BIRTH_DATE"), "dd/MM/yyyy")), Now()) / 365.25)
                                    End If
                                    colCount += 4
                                End If
                            Next
                        End If

                        xRCount += 1
                    End If
                    dgvRCount += 1
                Loop
            End With
            MsgBox("Exporting records to Policy Details completed.")
            xApp.Visible = True
        End If
    End Sub
    Private Function PremiumDetails(ByVal ID As String, ByVal P1 As String, ByVal MDOB As Date) As String
        Dim PremiumAmount As Double
        Dim dt As New DataTable
        dt = _objBusi.getDetails("XPORTWRONGPREMIUM", P1, "", "", "", "PREMIUM", Conn)
        For Each dr As DataRow In dt.Rows
            Dim Age As String
            Age = Math.Floor(DateDiff(DateInterval.Day, MDOB, Now()) / 365.25)
            Dim Age_Limit As String()
            Dim a As String
            a = dr("Age_Limit")
            Age_Limit = a.Split("-")
            If (Age > Age_Limit(0) Or Age >= Age_Limit(0)) And (Age < Age_Limit(1) Or Age <= Age_Limit(1)) Then
                PremiumAmount = dr("Premium_Amt")
                Exit For
            End If
        Next
        Dim sP As String
        sP = P1.ToString.Substring(0, 10).Trim()
        Dim dtDep As New DataTable
        dtDep = _objBusi.getDetails("POLICYDETAILS", ID, "", "", "", "FAMILYDETAILS", Conn)
        Select Case sP
            Case "CUEPACS PA"
                Dim PATotalAmount As Double
                Dim TotalAmount As String
                Dim Age As String
                Dim dep_count As Integer = 0
                Dim Age_Limit As String()
                Dim a As String
                Age = Math.Floor(DateDiff(DateInterval.Day, MDOB, Now()) / 365.25)
                For Each dr As DataRow In dt.Rows
                    a = dr("Age_Limit")
                    Age_Limit = a.Split("-")
                    Dim PType As String
                    PType = dr("Participant_Type").ToString.Trim()
                    If PType = "MEMBER" Then
                        If Age > Age_Limit(0) And Age < Age_Limit(1) Then
                            PATotalAmount += dr("Premium_Amt")
                            PremiumAmount = PATotalAmount
                            Exit For
                        End If
                    End If
                Next
                If dtDep.Rows.Count > 0 Then
                    Do While dep_count < dtDep.Rows.Count
                        Dim DepAge, Relation, depParam As String
                        If Not IsDBNull(dtDep.Rows(dep_count)("BIRTH_DATE")) Then
                            DepAge = Math.Floor(DateDiff(DateInterval.Day, dtDep.Rows(dep_count)("BIRTH_DATE"), Now()) / 365.25)
                            Dim sLen As String
                            sLen = DepAge.Length()
                            If sLen = "1" Then
                                DepAge = "0" & DepAge
                            End If
                            Relation = dtDep.Rows(dep_count)("RELATIONSHIP").ToString.Trim()
                            Select Case Relation
                                Case "Children", "SON", "DAUGHTER"
                                    depParam = "CHILD"
                                Case Else
                                    depParam = "SPOUSE"
                            End Select
                            For Each dr As DataRow In dt.Select("Participant_Type = '" & depParam & "'")
                                a = dr("Age_Limit")
                                Age_Limit = a.Split("-")
                                If (DepAge > Age_Limit(0) Or DepAge >= Age_Limit(0)) And (DepAge < Age_Limit(1) Or DepAge <= Age_Limit(1)) Then
                                    PATotalAmount += dr("Premium_Amt")
                                    Exit For
                                End If
                            Next
                            TotalAmount = PATotalAmount
                        End If
                        dep_count += 1
                    Loop
                    PremiumAmount = PATotalAmount
                End If
            Case Else
                For Each dr As DataRow In dt.Rows
                    Dim Age As Integer
                    Dim dep_count As Integer = 0
                    Dim Relations As String = ""
                    If dtDep.Rows.Count > 0 Then
                        Age = Math.Floor(DateDiff(DateInterval.Day, MDOB, Now()) / 365.25)
                        Do While dep_count < dtDep.Rows.Count
                            Dim DepAge As String
                            Relations = dtDep.Rows(dep_count)("RELATIONSHIP").ToString.Trim()
                            If Not IsDBNull(dtDep.Rows(dep_count)("BIRTH_DATE")) Then
                                DepAge = Math.Floor(DateDiff(DateInterval.Day, dtDep.Rows(dep_count)("BIRTH_DATE"), Now()) / 365.25)
                            End If
                            If DepAge > Age Then
                                Age = DepAge
                                Exit Do
                            End If
                            dep_count += 1
                        Loop
                    Else
                        Age = Math.Floor(DateDiff(DateInterval.Day, MDOB, Now()) / 365.25)
                    End If
                    If Not Relations = "Children" Then
                        Dim Age_Limit As String()
                        Dim a As String
                        a = dr("Age_Limit")
                        Age_Limit = a.Split("-")
                        If Age > Age_Limit(0) And Age < Age_Limit(1) Then
                            PremiumAmount = dr("Premium_Amt")
                            Exit For
                        End If
                    End If
                Next
        End Select
        Return PremiumAmount
    End Function

End Class