Public Class afPolicy
#Region "Global Veriables"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub afPolicy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub afPolicy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindPolicyDetails(Me.lblPolicyID.Text.Trim())
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BindPolicyDetails(ByVal PID As String)
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text

        cmdSelect.CommandText = "SELECT * FROM dt_Member_Policy WHERE ID='" & PID & "'"
        Dim adp As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet
        adp.Fill(ds, "dt_Member_Policy_Nomination")
        
        If ds.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0)("Effective_Date")) Then
                Me.dtpEDate.Value = ds.Tables(0).Rows(0)("Effective_Date")
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0)("Cancellation_Date")) Then
                Me.dtpCDate.Value = ds.Tables(0).Rows(0)("Cancellation_Date")
            End If
            Me.txtAFileNo.Text = ds.Tables(0).Rows(0)("Angkasa_FileNo")
            Me.txtAgentCode.Text = ds.Tables(0).Rows(0)("Agent_Code")
        End If
        Me.lblPCODE.Text = ds.Tables(0).Rows(0)("Deduction_Code").ToString.Trim()
        Me.lblDeductionCode.Text = ds.Tables(0).Rows(0)("Deduction_Code").ToString().Substring(0, 1)
        If ds.Tables(0).Rows(0)("Deduction_Code").ToString().Substring(0, 1) = "Y" Then
            GrpBox_Payment_Details.Enabled = True

            Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.CommandText = "SELECT Top 1 * FROM dt_member_policy_YearlyRenewal WHERE Member_policy_ID='" & PID & "' Order By log_date Desc"
            Dim sdp As New SqlDataAdapter(sqlCmd)
            Dim dt As New DataTable
            sdp.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.lblRenewalID.Text = dt.Rows(0)("ID").ToString()
                Me.dtpRequestedDate.Value = dt.Rows(0)("Request_Date")
                Me.txtPayment_Method.Text = dt.Rows(0)("Payment_Method")
                Me.txtRenewal_Premium_New.Text = dt.Rows(0)("Premium")
                Select Case Me.txtPayment_Method.Text
                    Case "Credit Card"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = True
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                        Me.txtPayment_CreditCard_BatchNo.Text = dt.Rows(0)("CC_Batch_No")
                        Me.txtPayment_CreditCard_ApprCode.Text = dt.Rows(0)("CC_Appr_Code")
                        Me.txtPayment_CreditCard_Inv_No.Text = dt.Rows(0)("CC_Invoice_No")
                    Case "Cheque"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = True
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                        Me.txtPayment_Cheque_No.Text = dt.Rows(0)("Cheque_No")
                        Me.txtPayment_Cheque_Receipt_No.Text = dt.Rows(0)("Cheque_Receipt_No")
                    Case "Cash"
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = True
                        Me.txtPayment_Cash_Receipt_IssuedBy.Text = dt.Rows(0)("Cash_Receipt_IssuedBy")
                        Me.txtPayment_Cash_Receipt_No.Text = dt.Rows(0)("Cash_Receipt_No")
                    Case Else
                        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                        Me.GrpBox_Payment_Details_Cheque.Enabled = False
                        Me.GrpBox_Payment_Details_Cash.Enabled = False
                End Select
            End If
        End If
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If chkValidation() Then
            Dim sRes As String
            Dim cmdUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdUps.CommandType = CommandType.Text
            cmdUps.CommandText = "Update dt_Member_Policy SET Effective_Date='" & Format(Me.dtpEDate.Value, "MM/dd/yyyy") & "', Cancellation_Date='" & Format(Me.dtpCDate.Value, "MM/dd/yyyy") & "', " & _
                                " Angkasa_FileNo='" & Me.txtAFileNo.Text.Trim & "', Agent_Code='" & Me.txtAgentCode.Text.Trim & "' WHERE ID='" & Me.lblPolicyID.Text & "'"
            sRes = cmdUps.ExecuteNonQuery()
            If Me.lblAdmin.Text = "Admin" Then
                Me._objBusi.aLog(Me.lblPolicyID.Text, "Updating Policy Details User ID : " & My.Settings.Username & " ", Conn)
            End If
            If Me.lblDeductionCode.Text = "Y" Then
                Dim scYR As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                scYR.CommandType = CommandType.Text
                scYR.CommandText = "Update dt_Member_Policy_YearlyRenewal SET Payment_Method='" & Me.txtPayment_Method.Text.Trim & "', Premium='" & Convert.ToDouble(txtRenewal_Premium_New.Text.Trim) & "', " & _
                                 " CC_Batch_No='" & Me.txtPayment_CreditCard_BatchNo.Text.Trim & "', CC_Appr_Code='" & Me.txtPayment_CreditCard_ApprCode.Text.Trim & "', " & _
                                 " CC_Invoice_No='" & Me.txtPayment_CreditCard_Inv_No.Text.Trim & "', Cheque_No='" & Me.txtPayment_Cheque_No.Text.Trim & "', " & _
                                 " Request_Date='" & Format(Me.dtpRequestedDate.Value, "MM/dd/yyyy") & "', " & _
                                 " Cheque_Receipt_No='" & Me.txtPayment_Cheque_Receipt_No.Text.Trim & "', Cash_Receipt_No='" & Me.txtPayment_Cash_Receipt_No.Text.Trim & "', " & _
                                 " Cash_Receipt_IssuedBy='" & Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim & "' WHERE ID='" & Me.lblRenewalID.Text.ToString() & "'"
                scYR.ExecuteNonQuery()
                If Me.lblAdmin.Text = "Admin" Then
                    Me._objBusi.aLog(Me.lblPolicyID.Text, "Updating Renewal Details User ID : " & My.Settings.Username & " ", Conn)
                End If
            End If
            If sRes = "1" Then
                MsgBox("Successfully Updated Policy Details")
                Me.txtAFileNo.Text = ""
                Me.txtAgentCode.Text = ""
                Me.Close()
            Else
                MsgBox("Error while updating Policy Details")
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnPayment_Method_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment_Method.Click
        Dim frmSearch_Payment_Method As New frmSearch_Param
        frmSearch_Payment_Method.lblForm_Flag.Text = "$"
        frmSearch_Payment_Method.lblPayment_Frequency.Text = "Yearly"
        frmSearch_Payment_Method.ShowDialog()
        Me.txtPayment_Method.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()

        Select Case Me.txtPayment_Method.Text
            Case "Credit Card"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = True
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cheque"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = True
                Me.GrpBox_Payment_Details_Cash.Enabled = False
            Case "Cash"
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = True
            Case Else
                Me.GrpBox_Payment_Details_CreditCard.Enabled = False
                Me.GrpBox_Payment_Details_Cheque.Enabled = False
                Me.GrpBox_Payment_Details_Cash.Enabled = False
        End Select

        Me.txtPayment_CreditCard_BatchNo.Clear()
        Me.txtPayment_CreditCard_ApprCode.Clear()
        Me.txtPayment_CreditCard_Inv_No.Clear()
        Me.txtPayment_Cheque_No.Clear()
        Me.txtPayment_Cheque_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_No.Clear()
        Me.txtPayment_Cash_Receipt_IssuedBy.Clear()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function chkValidation() As Boolean
        If Me.txtAFileNo.Text.ToString.Trim() = "" Then
            MsgBox("Title Can't be Blank!")
            Me.txtAFileNo.Focus()
            Return False
        End If
        If Me.txtAgentCode.Text.ToString.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtAgentCode.Focus()
            Return False
        End If
        If Verify_Payment_Details() Then
            Return True
        End If
    End Function
    Private Function Verify_Payment_Details() As Boolean
        If Len(Me.txtRenewal_Premium_New.Text.Trim) = 0 Then
            MsgBox("Please do key in the Premium.")
            Me.txtRenewal_Premium_New.Focus()
            Return False
        Else
            If IsNumeric(Me.txtRenewal_Premium_New.Text) = False Then
                MsgBox("Premium is not in Numeric format, please do key in the value.")
                Me.txtRenewal_Premium_New.Focus()
                Return False
            Else
                Select Case Me.txtPayment_Method.Text.Trim
                    Case "Credit Card"
                        If Len(Me.txtPayment_CreditCard_ApprCode.Text.Trim) = 0 Then
                            MsgBox("Please do key in the Credit Card Approval Code (Appr Code).")
                            Me.txtPayment_CreditCard_ApprCode.Focus()
                            Return False
                        Else
                            If Len(Me.txtPayment_CreditCard_BatchNo.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Credit Card Batch No.")
                                Me.txtPayment_CreditCard_BatchNo.Focus()
                                Return False
                            Else
                                If Len(Me.txtPayment_CreditCard_Inv_No.Text.Trim) = 0 Then
                                    MsgBox("Please do key in the Invoice No.")
                                    Me.txtPayment_CreditCard_Inv_No.Focus()
                                    Return False
                                Else
                                    Return True
                                End If
                            End If
                        End If
                    Case "Cheque"
                        If Len(Me.txtPayment_Cheque_No.Text.Trim) = 0 Then
                            MsgBox("Please do key in the Cheque No.")
                            Me.txtPayment_Cheque_No.Focus()
                            Return False
                        Else
                            If Len(Me.txtPayment_Cheque_Receipt_No.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Receipt No.")
                                Me.txtPayment_Cheque_Receipt_No.Focus()
                            Else
                                Return True
                            End If
                        End If
                    Case "Cash"
                        If Len(Me.txtPayment_Cash_Receipt_No.Text.Trim) = 0 Then
                            MsgBox("Please do key in the Receipt No.")
                            Me.txtPayment_Cash_Receipt_No.Focus()
                            Return False
                        Else
                            If Len(Me.txtPayment_Cash_Receipt_IssuedBy.Text.Trim) = 0 Then
                                MsgBox("Please do key in the Receipt Issued By.")
                                Me.txtPayment_Cash_Receipt_IssuedBy.Focus()
                                Return False
                            Else
                                Return True
                            End If
                        End If
                End Select
            End If
        End If
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