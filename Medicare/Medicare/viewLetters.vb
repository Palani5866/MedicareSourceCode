Public Class viewLetters
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub viewLetters_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub viewLetters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popCB()
    End Sub
    Private Sub popCB()
        Select Case Me.lblATYPE.Text.Trim()
            Case "MEMBER"
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("User request to cancel")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Change to Yearly")
            Case "PREMIUM"
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("User request to cancel")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Non-Payment")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Change to Yearly")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Angkasa Payment > 60%")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("NO DEDUCTION FROM ANGKASA")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Non-Payment Cannot Contact")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Change to Angkasa / Others")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Incomplete Angkasa")
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Yearly Renewal Printing")
            Case "CS"
                Me.tsLetter_cbLetterType.ComboBox.Items.Add("Yearly Renewal Printing")
        End Select
    End Sub
    Private Sub tsLetter_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsLetter_Go.Click
        If Not Me.tsLetter_cbLetterType.SelectedIndex = -1 Then
            Dim sType As String
            If Me.tsLetter_cbLetterType.SelectedText = "Angkasa Cancel" Then
                sType = "Cancelled"
            Else
                sType = Me.tsLetter_cbLetterType.Text.Trim()
            End If

            Dim dt As New DataTable
            Select Case Me.tsLetter_cbLetterType.Text
                Case "Yearly Renewal Printing"
                    dt = _objBusi.getDetails("LETTERS", Me.txtIC.Text.Trim(), "", "", "", "YRP", Conn)
                Case Else
                    dt = _objBusi.getDetails("LETTERS", sType.Trim(), Me.txtIC.Text.Trim(), "", "", "", Conn)
            End Select
            If dt.Rows.Count > 0 Then
                With Me.dgvLetters
                    .DataSource = dt
                    .Columns(1).Visible = False
                    .Columns(2).Visible = False

                    .Columns(3).HeaderText = "Full_Name"
                    .Columns(4).HeaderText = "IC #"
                    .Columns(5).HeaderText = "Policy #"
                    .Columns(6).HeaderText = "Deduction Code"
                    .Columns(7).HeaderText = "Effective Date"
                    .Columns(8).HeaderText = "Cancellation Date"
                    .Columns(9).HeaderText = "Cancellation Reason"
                    .Columns(0).DisplayIndex = 9
                    .Columns(0).HeaderText = "Print"

                    Me.lblRecordCount.Text = "Record #: " & Me.dgvLetters.RowCount - 1
                End With
            Else
                MsgBox("No Record found...")
            End If
        Else

            MsgBox("Please select the creteria")
        End If

    End Sub
    Private Sub dgvLetters_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLetters.CellContentClick
        Select Case Me.lblATYPE.Text.Trim()
            Case "MEMBER"

                Dim type As String
                type = Me.tsLetter_cbLetterType.SelectedIndex
                Select Case type
                    Case "0"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("AngkasaCancellation.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                End Select
            Case "PREMIUM"
                Dim type As String
                type = Me.tsLetter_cbLetterType.SelectedIndex
                Select Case type
                    Case "0", "6"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("AngkasaCancellation.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "1"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("NPL.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "2"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("Change2Yearly.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "3"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("Due_to_60_Percent.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "4"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("No_Deduction_Frm_Angkasa.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "5"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("NPCC.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "7"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                PrintLetters.Print_Letters("IncompleteBorang.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), type)
                            End If
                        End With
                    Case "8"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                Select Case .Rows(e.RowIndex).Cells(6).Value.ToString().Substring(1, 1)
                                    Case "0"
                                        PrintLetters.Print_Letters("YearlyACLetter.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), "YEARLYRENEWAL")
                                    Case Else
                                        PrintLetters.Print_Letters("YearlyACLetterO.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), "YEARLYRENEWAL")
                                End Select
                            End If
                        End With
                End Select
            Case "CS"

                Dim type As String
                type = Me.tsLetter_cbLetterType.SelectedIndex
                Select Case type
                    Case "0"
                        With Me.dgvLetters
                            If e.ColumnIndex = 0 Then
                                If .Rows.Count = 0 Then
                                    Exit Sub
                                End If
                                Select Case .Rows(e.RowIndex).Cells(6).Value.ToString().Substring(1, 1)
                                    Case "0"
                                        PrintLetters.Print_Letters("YearlyACLetter.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), "YEARLYRENEWAL")
                                    Case Else
                                        PrintLetters.Print_Letters("YearlyACLetterO.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString(), "YEARLYRENEWAL")
                                End Select
                            End If
                        End With
                End Select
        End Select
    End Sub
    
End Class