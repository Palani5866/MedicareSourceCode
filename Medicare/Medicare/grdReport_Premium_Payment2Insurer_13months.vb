Public Class grdReport_Premium_Payment2Insurer_13months
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub grdReport_Premium_Payment2Insurer_13months_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub grdReport_Premium_Payment2Insurer_13months_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popYear()
    End Sub
    Private Sub popYear()
        Dim alYear As New ArrayList
        alYear.Add(Year(Now))
        alYear.Add(Year(Now) - 3)
        alYear.Add(Year(Now) - 2)
        alYear.Add(Year(Now) - 1)
        alYear.Add(Year(Now) + 1)
        Me.ToolStripcmbYear.ComboBox.DataSource = alYear
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
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
            MsgBox("This action cannot perform now due to pending settlements in 2/79, please do clear and try again!")
        End If
    End Sub
    Private Sub BindData()
        Dim dt As New DataTable

        dt = _objBusi.fR13M("R13M", Me.tsReport_txtDeductionCode_From.Text.Trim, Me.tsReport_txtDeductionCode_To.Text.Trim, Me.ToolStripcmbYear.ComboBox.SelectedValue.ToString(), "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "File No."
                .Columns(2).HeaderText = "IC"
                .Columns(3).HeaderText = "FULL NAME"
                .Columns(4).HeaderText = "DOB"
                .Columns(5).HeaderText = "PLAN TYPE"
                .Columns(6).HeaderText = "EFFECTIVE DATE"
                .Columns(7).HeaderText = "PLAN CHANGE/CANCELLATION DATE"
                .Columns(8).HeaderText = "Premium"
                .Columns(9).Visible = False
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
            End With
        Else
            MsgBox("We are sorry! Currently our server is busy, Please try again after some time or No record found on your criteria")
        End If
    End Sub
    Private Sub Xport2XcelNew()
        If Me.dgvForm.RowCount > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim dgRowCount As Integer = 0
            Dim xWName As String = ""
            Dim xRCount As Integer = 7
            Dim DCode As String = ""
            Do While dgRowCount < Me.dgvForm.RowCount
                With Me.dgvForm.Rows(dgRowCount)
                    If DCode <> .Cells("DCode").Value.ToString.Trim Then
                        xWB.Worksheets.Add()
                        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
                        With xWB.Worksheets(xWName)
                            .Cells(1, 1) = "PREMIUM PAYMENT STATEMENT TO INSURER"
                            .Cells(2, 1) = "EXPORTED ON : " & Now()
                            .Cells(3, 1) = "DEDUCTION CODE: " & Me.dgvForm.Rows(dgRowCount).Cells("DCode").Value.ToString.Trim()

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

                            .Cells(5, 11) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "01"
                            .Cells(5, 12) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "02"
                            .Cells(5, 13) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "03"
                            .Cells(5, 14) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "04"
                            .Cells(5, 15) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "05"
                            .Cells(5, 16) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "06"
                            .Cells(5, 17) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "07"
                            .Cells(5, 18) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "08"
                            .Cells(5, 19) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "09"
                            .Cells(5, 20) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "10"
                            .Cells(5, 21) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "11"
                            .Cells(5, 22) = "'" & Me.ToolStripcmbYear.ComboBox.SelectedValue & "12"
                            .Cells(5, 23) = "'" & Trim(Str(Val(Me.ToolStripcmbYear.ComboBox.SelectedValue) + 1) & "01")

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
                            .Columns(23).NumberFormat = "#,##0.00"
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
                    If Not (IsDBNull(.Cells("m1").Value.ToString.Trim) Or (.Cells("m1").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 11) = FormatNumber(.Cells("m1").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m2").Value.ToString.Trim) Or (.Cells("m2").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 12) = FormatNumber(.Cells("m2").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m3").Value.ToString.Trim) Or (.Cells("m3").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 13) = FormatNumber(.Cells("m3").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m4").Value.ToString.Trim) Or (.Cells("m4").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 14) = FormatNumber(.Cells("m4").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m5").Value.ToString.Trim) Or (.Cells("m5").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 15) = FormatNumber(.Cells("m5").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m6").Value.ToString.Trim) Or (.Cells("m6").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 16) = FormatNumber(.Cells("m6").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m7").Value.ToString.Trim) Or (.Cells("m7").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 17) = FormatNumber(.Cells("m7").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m8").Value.ToString.Trim) Or (.Cells("m8").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 18) = FormatNumber(.Cells("m8").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m9").Value.ToString.Trim) Or (.Cells("m9").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 19) = FormatNumber(.Cells("m9").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m10").Value.ToString.Trim) Or (.Cells("m10").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 20) = FormatNumber(.Cells("m10").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m11").Value.ToString.Trim) Or (.Cells("m11").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 21) = FormatNumber(.Cells("m11").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m12").Value.ToString.Trim) Or (.Cells("m12").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 22) = FormatNumber(.Cells("m12").Value.ToString.Trim, 2)
                    End If
                    If Not (IsDBNull(.Cells("m13").Value.ToString.Trim) Or (.Cells("m13").Value.ToString.Trim) = "") Then
                        xWB.Worksheets(xWName).Cells(xRCount, 23) = FormatNumber(.Cells("m13").Value.ToString.Trim, 2)
                    End If
                End With
                xRCount += 1
                dgRowCount += 1
            Loop
            xApp.Visible = True
        End If
    End Sub
    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        If Me.dgvForm.RowCount > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Xport2XcelNew()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("Exporting records to PREMIUM PAYMENT STATEMENT TO INSURER completed.")
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
End Class