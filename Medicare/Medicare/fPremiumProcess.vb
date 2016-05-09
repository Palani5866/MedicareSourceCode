Public Class fPremiumProcess
#Region "Global Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
#End Region
#Region "Page Events"
    Private Sub fPremiumProcess_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fPremiumProcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
        BINDDATA()
    End Sub
#End Region
#Region "Data Bind Events"
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr, f2Yr, p1M, p2M, cM, f1M, f2M As String
        For p2I As Integer = 0 To 11
            p2M = "0" & p2I + 1
            If p2M.Length = 3 Then
                p2M = p2M.Substring(1, 2)
            End If
            p2Yr = Now.Year() - 1 & p2M
            aMonth.Add(p2Yr)
        Next
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        Dim s As String
        s = "0" + Now.Month.ToString()
        If s.Length = 3 Then
            s = s.Substring(1, 2)
        End If
        Me.tsReport_ddlMonth.ComboBox.DataSource = aMonth
        Me.tsReport_ddlMonth.ComboBox.Text = Now.Year() & s
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fPremiumProcess("DTOP", Me.lblREF1.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(2).HeaderText = "Batch No"
                .Columns(3).HeaderText = "Batch Record Count"
                .Columns(4).HeaderText = "Batch Record Consolidated"
                .Columns(5).HeaderText = "Batch Record Successfully Processed"
                .Columns(6).HeaderText = "Batch Uploaded On"
                .Columns(7).HeaderText = "Batch Uploaded By"
                .Columns(8).HeaderText = "Status"
            End With
        Else
            MsgBox("No record found")
            Me.dgvForm.DataSource = dt
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Len(Me.tsReport_ddlMonth.Text.Trim()) > 0 Then
            MsgBox("Please do select Processing Month!")
            Me.tsReport_ddlMonth.Focus()
            Exit Sub
        End If
        sProcessPremium()
        BINDDATA()
    End Sub
#End Region
#Region "Premium Process"
    Private Sub sProcessPremium()
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim dgvRowCount As Integer = 0
        Dim BatchTransCount As Integer = 0
        Dim BatchTransSuccessCount As Integer = 0
        Dim BatchTransErrorCount As Integer = 0
        Dim aDeduction_Month As String
        With Me.dgvForm
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                    If .Rows(dgvRowCount).Cells(8).Value = 0 Then
                        Dim Olddt, Newdt, Otherdt As New DataTable
                        Olddt = _objBusi.fPremiumProcess("PREMIUM", .Rows(dgvRowCount).Cells(2).Value.ToString.Trim(), "", "", "", "", "", "", "", "ON", "BATCHNO", Conn)
                        Otherdt = _objBusi.fPremiumProcess("PREMIUM", .Rows(dgvRowCount).Cells(2).Value.ToString.Trim(), "", "", "", "", "", "", "", "OTHER", "BATCHNO", Conn)
                        If Otherdt.Rows.Count > 0 Then
                            For Each dr As DataRow In Otherdt.Rows
                                _objBusi.fINPremiumProcess("INSERT", dr("No_Kad_Pengenalan").ToString.Trim, dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "RECOVER", Conn)
                                _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                BatchTransSuccessCount += 1
                                BatchTransErrorCount += 1
                            Next
                        End If
                        If Olddt.Rows.Count > 0 Then
                            aDeduction_Month = Olddt.Rows(0)("Bulan_Potongan").ToString.Trim
                            For Each dr As DataRow In Olddt.Rows
                                Dim dtMember As New DataTable
                                dtMember = _objBusi.fPremiumProcess("PREMIUM", dr("NO_KAD_PENGENALAN").ToString.Trim(), dr("KOD_POTONGAN").ToString.Trim(), "", "", "", "", "", "", "", "CHECK", Conn)
                                Select Case dtMember.Rows.Count
                                    Case 0
                                        _objBusi.fINPremiumProcess("INSERT", dr("No_Kad_Pengenalan").ToString.Trim, dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "KIV", Conn)
                                        _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                        BatchTransSuccessCount += 1
                                        BatchTransErrorCount += 1
                                    Case 1
                                        If dr("Jumlah_Pokok") = dtMember.Rows(0)("Deduction_Amount") Then
                                            If IsDBNull(dtMember.Rows(0)("Cancellation_Date")) = True Then
                                                _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), dtMember.Rows(0)("ID").ToString(), dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "MONTHLYDEDUCTION", Conn) 'Monthly Deduction                                                
                                                _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                                BatchTransSuccessCount += 1
                                                If IsDBNull(dtMember.Rows(0)("Effective_Date")) = True Then
                                                    Update_MemberPolicy_Effective_Date(dtMember.Rows(0)("ID").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim())
                                                End If

                                            Else
                                                If Len(dtMember.Rows(0)("Cancellation_Date").ToString.Trim) > 0 Then
                                                    _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), dtMember.Rows(0)("ID").ToString(), dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "MONTHLYDEDUCTION", Conn) 'Monthly Deduction                                                
                                                    _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                                    BatchTransSuccessCount += 1
                                                    If IsDBNull(dtMember.Rows(0)("Effective_Date")) = True Then
                                                        Update_MemberPolicy_Effective_Date(dtMember.Rows(0)("ID").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim())
                                                    End If
                                                Else
                                                    _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), dtMember.Rows(0)("ID").ToString(), dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "MONTHLYDEDUCTION", Conn) 'Monthly Deduction                                                
                                                    _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                                    BatchTransSuccessCount += 1

                                                    If IsDBNull(dtMember.Rows(0)("Effective_Date")) = True Then
                                                        Update_MemberPolicy_Effective_Date(dtMember.Rows(0)("ID").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim())
                                                    End If

                                                End If
                                            End If
                                        Else
                                            If dr("Jumlah_Pokok") > dtMember.Rows(0)("Deduction_Amount") Then
                                                _objBusi.fINPremiumProcess("INSERT", dr("No_Kad_Pengenalan").ToString.Trim, dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "KIV", Conn)
                                                _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                                BatchTransSuccessCount += 1
                                                BatchTransErrorCount += 1
                                            Else
                                                Dim sAmt As Double
                                                sAmt = dr("Jumlah_Pokok") - dtMember.Rows(0)("Deduction_Amount")
                                                _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), dtMember.Rows(0)("ID").ToString(), dr("Bulan_Potongan").ToString, dr("Kod_Potongan").ToString, dr("Jumlah_Pokok"), dr("Batch_No").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "MONTHLYDEDUCTION", Conn)
                                                _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), "SHORTFALL", dtMember.Rows(0)("ID").ToString.Trim(), dr("Bulan_Potongan").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim(), dtMember.Rows(0)("Deduction_Amount").ToString(), dr("Jumlah_Pokok"), sAmt.ToString(), dr("Batch_No").ToString, "SHORTFALL", Conn)
                                                _objBusi.fINPremiumProcess("UPDATE", dr("ID").ToString.Trim, "", "", "", "", "", "", "", "", "ANGKASA", Conn)
                                                BatchTransSuccessCount += 1
                                                BatchTransErrorCount += 1
                                                If IsDBNull(dtMember.Rows(0)("Effective_Date")) = True Then
                                                    Update_MemberPolicy_Effective_Date(dtMember.Rows(0)("ID").ToString, Me.tsReport_ddlMonth.Text.ToString.Trim())
                                                End If
                                            End If
                                        End If
                                End Select
                                BatchTransCount += 1
                            Next
                            _objBusi.fINPremiumProcess("UPDATE", .Rows(dgvRowCount).Cells(2).Value.ToString, BatchTransSuccessCount, "", "", "", "", "", "", "", "RECORDCOUNT", Conn)
                            BatchTransCount = 0
                            BatchTransSuccessCount = 0
                            BatchTransErrorCount = 0
                        End If
                    End If
                End If
                dgvRowCount += 1
            Loop
        End With
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        MsgBox("Monthly Deduction Process completed, please do check on the Suspension Account for errors.")
    End Sub
#End Region
#Region "Update Function"
    Private Function Update_MemberPolicy_Effective_Date(ByVal var_ID As String, ByVal var_Receiving_Month As String)
        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text
        cmdSelect_Member_Policy.CommandText = "SELECT * FROM dt_Member_Policy WHERE ID = '" & var_ID.Trim & "'"
        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)

        Dim cmdUpdate_Effective_Date As SqlCommandBuilder
        cmdUpdate_Effective_Date = New SqlCommandBuilder(da_Member_Policy)
        Dim ds_MemberPolicy As New DataSet
        Try
            da_Member_Policy.Fill(ds_MemberPolicy, "dt_Member_Policy")

            If ds_MemberPolicy.Tables("dt_Member_Policy").Rows.Count = 1 Then
                Dim dr_MemberPolicy As DataRow = ds_MemberPolicy.Tables("dt_Member_Policy").Rows(0)

                Dim var_effective_month As Short
                Dim var_effective_year As Short
                Dim var_effective_date As Date

                var_effective_month = Val(var_Receiving_Month.Substring(4, 2)) + 1
                var_effective_year = Val(var_Receiving_Month.Substring(0, 4))

                If var_effective_month = 13 Then
                    var_effective_year += 1
                    var_effective_month = 1
                End If
                var_effective_date = Convert.ToDateTime(Str(var_effective_year) & "/" & Str(var_effective_month) & "/15")
                dr_MemberPolicy.Item("Effective_Date") = var_effective_date
                dr_MemberPolicy.Item("Status") = "INFORCE"
                da_Member_Policy.Update(ds_MemberPolicy, "dt_Member_Policy")
                _objBusi.spUpdate("GST", var_ID.ToString(), "", "", "", "", "", "", "", "", "", Conn)
                _objBusi.InsUpsPremiumHistory("UP", Guid.NewGuid().ToString(), var_ID.ToString(), Format(var_effective_date, "MM/dd/yyyy"), "", "", "Active", "", "", Conn)
                Return True
            Else
                MsgBox("Error in loading the data")
                Return False
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
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