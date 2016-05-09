Public Class fInsurarPremiumPayment
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim pMonth As Integer
#End Region
#Region "Page Events"
    Private Sub fInsurarPremiumPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        Application.DoEvents()
    End Sub
    Private Sub fInsurarPremiumPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popYear()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub popYear()
        Dim alYear As New ArrayList
        alYear.Add(Year(Now))
        alYear.Add(Year(Now) - 3)
        alYear.Add(Year(Now) - 2)
        alYear.Add(Year(Now) - 1)
        alYear.Add(Year(Now) + 1)
        Me.tscbYear.ComboBox.DataSource = alYear
    End Sub
    Private Sub BindData()
        Dim dt As New DataTable
        Try
            Select Case Me.tscbMonth.SelectedIndex
                Case "1"
                    pMonth = "01"
                Case "2"
                    pMonth = "02"
                Case "3"
                    pMonth = "03"
                Case "4"
                    pMonth = "04"
                Case "5"
                    pMonth = "05"
                Case "6"
                    pMonth = "06"
                Case "7"
                    pMonth = "07"
                Case "8"
                    pMonth = "08"
                Case "9"
                    pMonth = "09"
                Case "10"
                    pMonth = "10"
                Case "11"
                    pMonth = "11"
                Case "12"
                    pMonth = "12"
            End Select
            dt = _objBusi.fgetIPPD(Me.tscbYear.ComboBox.SelectedValue.ToString(), pMonth, Me.tsReport_txtDeductionCode_From.Text.Trim, Me.tsReport_txtDeductionCode_To.Text.Trim, Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvIPRD
                    .DataSource = dt
                    .Columns(0).Visible = False
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "File No."
                    .Columns(3).HeaderText = "IC"
                    .Columns(4).HeaderText = "FULL NAME"
                    .Columns(5).HeaderText = "DOB"
                    .Columns(6).HeaderText = "PLAN TYPE"
                    .Columns(7).HeaderText = "EFFECTIVE DATE"
                    .Columns(8).HeaderText = "PLAN CHANGE/CANCELLATION DATE"
                    .Columns(9).HeaderText = "Premium"
                    .Columns(10).HeaderText = "Status"
                    .Columns(11).Visible = False
                    .Columns(12).Visible = False
                    .Columns(13).Visible = False
                    .Columns(14).Visible = False
                    .Columns(15).Visible = False
                    .Columns(16).Visible = False
                    .Columns(17).Visible = False
                    .Columns(18).Visible = False
                End With
            Else
                Me.dgvIPRD.DataSource = dt
                MsgBox("We are sorry! Currently our server is busy, Please try again after some time or No record found on your criteria")
            End If
        Catch ex As Exception
            Me.dgvIPRD.DataSource = dt
            MsgBox("We are sorry! Currently our server is busy!" & ex.StackTrace)
        End Try
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Len(Me.tsReport_txtDeductionCode_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (From).")
            Me.tsReport_txtDeductionCode_From.Focus()
            Exit Sub
        End If
        If Len(Me.tsReport_txtDeductionCode_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (To).")
            Me.tsReport_txtDeductionCode_To.Focus()
            Exit Sub
        End If
        If Not Me.tscbMonth.SelectedIndex > 0 Then
            MsgBox("Please do select Payment Month.")
            Me.tscbMonth.Focus()
            Exit Sub
        End If
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("CHECK13MR", "", "", "", "", "", "", "", "", "", "", Conn)
        If Not dt.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            BindData()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        Else
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("This action cannot perform now due to pending settlements in 2/79, please do clear and try again!")
        End If

    End Sub
    Private Sub tsXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsXport2Xcel.Click
        If Me.dgvIPRD.RowCount > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Xport2XcelNew()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
    End Sub
#End Region
#Region "Export"
    Private Sub Xport2XcelNew()
        If Me.dgvIPRD.RowCount > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim dgRowCount As Integer = 0
            Dim xWName As String = ""
            Dim xRCount As Integer = 7
            Dim DCode As String = ""
            Dim dt As DataTable
            dt = _objBusi.fgetDetailsII("GETMONTHS", Me.tscbYear.ComboBox.SelectedValue.ToString(), pMonth, "", "", "", "", "", "", "", "", Conn)
            Do While dgRowCount < Me.dgvIPRD.RowCount
                With Me.dgvIPRD.Rows(dgRowCount)
                    If DCode <> .Cells("DCode").Value.ToString.Trim Then
                        xWB.Worksheets.Add()
                        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                        With xWB.Worksheets(xWName)
                            .Cells(1, 1) = "PREMIUM PAYMENT STATEMENT TO INSURER"
                            .Cells(2, 1) = "EXPORTED ON : " & Now()
                            .Cells(3, 1) = "DEDUCTION CODE: " & Me.dgvIPRD.Rows(dgRowCount).Cells("DCode").Value.ToString.Trim()

                            .Cells(5, 1) = "FILE NO."
                            .Cells(5, 2) = "IC"
                            .Cells(5, 3) = "FULL NAME"
                            .Cells(5, 4) = "DOB"
                            .Cells(5, 5) = "PLAN TYPE"
                            .Cells(5, 6) = "EFFECTIVE DATE"
                            .Cells(5, 7) = "PLAN CHANGE/CANCELLATION DATE"
                            .Cells(5, 8) = "OLD POLICY/CERTIFICATE NO."
                            .Cells(5, 9) = "NEW POLICY/CERTIFICATE NO."
                            .Cells(5, 10) = "STATUS"
                            .Columns(1).NumberFormat = "@"
                            .Columns(2).NumberFormat = "@"
                            .Columns(3).NumberFormat = "@"
                            .Columns(4).NumberFormat = "@"
                            .Columns(5).NumberFormat = "dd/MM/yyyy"
                            .Columns(6).NumberFormat = "dd/MM/yyyy"
                            .Columns(7).NumberFormat = "@"
                            .Columns(8).NumberFormat = "@"
                            .Columns(9).NumberFormat = "@"
                            .Columns(10).NumberFormat = "@"

                            If dt.Rows.Count > 0 Then
                                Dim iCount As Integer = 0
                                For Each dr As DataRow In dt.Rows
                                    Select Case iCount
                                        Case 0
                                            .Cells(5, 11) = "'" & dr(0).ToString().Trim()
                                        Case 1
                                            .Cells(5, 12) = "'" & dr(0).ToString().Trim()
                                        Case 2
                                            .Cells(5, 13) = "'" & dr(0).ToString().Trim()
                                        Case 3
                                            .Cells(5, 14) = "'" & dr(0).ToString().Trim()
                                        Case 4
                                            .Cells(5, 15) = "'" & dr(0).ToString().Trim()
                                        Case 5
                                            .Cells(5, 16) = "'" & dr(0).ToString().Trim()
                                    End Select
                                    iCount += 1
                                Next
                            Else
                                .Cells(5, 11) = "'" & "M1"
                                .Cells(5, 12) = "'" & "M2"
                                .Cells(5, 13) = "'" & "M3"
                                .Cells(5, 14) = "'" & "M4"
                                .Cells(5, 15) = "'" & "M5"
                                .Cells(5, 16) = "'" & "M6"
                            End If

                            .Columns(11).NumberFormat = "#,##0.00"
                            .Columns(12).NumberFormat = "#,##0.00"
                            .Columns(13).NumberFormat = "#,##0.00"
                            .Columns(14).NumberFormat = "#,##0.00"
                            .Columns(15).NumberFormat = "#,##0.00"
                            .Columns(16).NumberFormat = "#,##0.00"

                        End With
                        xRCount = 6
                        DCode = .Cells("DCode").Value.ToString.Trim
                    End If
                    xWB.Worksheets(xWName).Cells(xRCount, 1) = "'" & .Cells("FNO").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 2) = "'" & .Cells("IC").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 3) = "'" & .Cells("FULLNAME").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 4) = "'" & .Cells("DOB").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 5) = "'" & .Cells("PTYPE").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 6) = "'" & .Cells("sDate").Value
                    xWB.Worksheets(xWName).Cells(xRCount, 7) = "'" & .Cells("eDate").Value
                    xWB.Worksheets(xWName).Cells(xRCount, 8) = "'" & .Cells("oldPno").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 9) = "'" & .Cells("newPno").Value.ToString.Trim
                    xWB.Worksheets(xWName).Cells(xRCount, 10) = "'" & .Cells("status").Value.ToString.Trim
                    If Not (IsDBNull(.Cells("M1").Value.ToString.Trim) Or (.Cells("M1").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 11) = FormatNumber(.Cells("M1").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("M2").Value.ToString.Trim) Or (.Cells("M2").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 12) = FormatNumber(.Cells("M2").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("M3").Value.ToString.Trim) Or (.Cells("M3").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 13) = FormatNumber(.Cells("M3").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("M4").Value.ToString.Trim) Or (.Cells("M4").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 14) = FormatNumber(.Cells("M4").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("M5").Value.ToString.Trim) Or (.Cells("M5").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 15) = FormatNumber(.Cells("M5").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("M6").Value.ToString.Trim) Or (.Cells("M6").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 16) = FormatNumber(.Cells("M6").Value.ToString.Trim, 2)
                    End If
                End With
                xRCount += 1
                dgRowCount += 1
            Loop
            xApp.Visible = True
        End If
    End Sub
#End Region
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