Public Class viewRenewal_Notice
    Dim Conn As DbConnection = New SqlConnection
    Private WithEvents docToPrint As New Printing.PrintDocument
    Dim objBusi As New Business
    Private Sub viewRenewal_Notice_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub viewRenewal_Notice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblRenewalUWID.Text = "" Then
            Me.Text = "Renewal Notice"
        Else
            Me.Text = "Renewal Notice (UW)"
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Expiry Date (From) (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If
        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Expiry Date (To) (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If
        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Expiry Date (From) in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Expiry Date (To) in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    Dim var_Expiry_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
                    Dim var_Expiry_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
                    Dim var_Expiry_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
                    Dim var_Expiry_Date_From As String = var_Expiry_From_Month & "/" & var_Expiry_From_Day & "/" & var_Expiry_From_Year

                    Dim var_Expiry_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
                    Dim var_Expiry_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
                    Dim var_Expiry_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
                    Dim var_Expiry_Date_To As String = var_Expiry_To_Month & "/" & var_Expiry_To_Day & "/" & var_Expiry_To_Year
                    Dim Member_Policy_counter As Integer = 0


                    Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect.CommandType = CommandType.Text
                    If Me.lblRenewalUWID.Text = "" Then
                        cmdSelect.CommandText = "SELECT a.ID, Member_ID, b.Full_Name, b.IC_New, A.Policy_No,  A.Deduction_Code, a.Effective_Date, " & _
                                                                    "a.Cancellation_Date FROM dt_Member_policy a inner join dt_member b on a.member_id=b.id " & _
                                                                    "where a.Cancellation_Date between '" & var_Expiry_Date_From & "' and '" & var_Expiry_Date_To & "' and (a.Status='INFORCE') and a.deduction_code like 'Y%' " & _
                                                                    " and (Underwriting_required='0' or Underwriting_required is null) ORDER BY Cancellation_Date"
                    Else
                        cmdSelect.CommandText = "SELECT a.ID, Member_ID, b.Full_Name, b.IC_New, A.Policy_No,  A.Deduction_Code, a.Effective_Date, " & _
                                                                                            "a.Cancellation_Date FROM dt_Member_policy a inner join dt_member b on a.member_id=b.id " & _
                                                                                            "where a.Cancellation_Date between '" & var_Expiry_Date_From & "' and '" & var_Expiry_Date_To & "' and (a.Status='INFORCE') and a.deduction_code like 'Y%' " & _
                                                                                            " and Underwriting_required='1' ORDER BY Cancellation_Date"
                    End If
                    Dim sdp As New SqlDataAdapter(cmdSelect)
                    Dim ds As New DataSet
                    sdp.Fill(ds, "dt_member_policy")

                    With Me.dgvRenewal_Notice
                        .DataSource = ds
                        .DataMember = "dt_member_policy"

                        .Columns(1).Visible = False
                        .Columns(2).Visible = False

                        .Columns(3).HeaderText = "Full_Name"
                        .Columns(4).HeaderText = "IC #"
                        .Columns(5).HeaderText = "Policy #"
                        .Columns(6).HeaderText = "Deduction Code"
                        .Columns(7).HeaderText = "Effective Date"
                        .Columns(8).HeaderText = "Cancellation Date"
                        .Columns(0).DisplayIndex = 8
                        .Columns(0).HeaderText = "Print"

                        Me.lblRecordCount.Text = "Record #: " & Me.dgvRenewal_Notice.RowCount.ToString
                    End With
                Else
                    MsgBox("Expiry Date (To) is < Expiry Date (From).")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub document_PrintPage(ByVal sender As Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
           Handles docToPrint.PrintPage
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)
        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 10, 10)
    End Sub
    Private Sub dgvRenewal_Notice_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRenewal_Notice.CellContentClick
        If Me.lblRenewalUWID.Text = "" Then
            With Me.dgvRenewal_Notice
                If e.ColumnIndex = 0 Then
                    If .Rows.Count = 0 Then
                        Exit Sub
                    End If
                    Renewal_Notice.Print("RenewalNotice.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString())
                    Me.objBusi.Log(.Rows(e.RowIndex).Cells(1).Value.ToString(), "Printed Renewal Notice  : " & My.Settings.Username & " ", Conn)
                End If
            End With
        Else
            With Me.dgvRenewal_Notice
                If e.ColumnIndex = 0 Then
                    If .Rows.Count = 0 Then
                        Exit Sub
                    End If
                    Renewal_Notice.Print("RenewalUW.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString())
                    Me.objBusi.Log(.Rows(e.RowIndex).Cells(1).Value.ToString(), "Printed Renewal Notice(Under Writing) : " & My.Settings.Username & " ", Conn)
                End If
            End With
        End If
    End Sub
End Class