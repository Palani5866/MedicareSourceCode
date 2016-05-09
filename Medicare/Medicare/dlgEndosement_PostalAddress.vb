Imports System.Windows.Forms
Public Class dlgEndosement_PostalAddress
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_PostalAddress_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgEndosement_PostalAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#End Region
#Region "DataBind Events"
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text

        If Search_Param1 = "Null" Then
            If Me.dgvPolicies.Rows.Count > 0 Then
                Me.dgvPolicies.DataSource = Nothing
                Me.dgvPolicies.DataMember = Nothing
            End If
            Me.txtFileNo.Clear()
            Me.txtName.Clear()
            Me.txtNRIC.Clear()
            Me.txtL2_Plan_Code_Old.Clear()
            Me.txtRequested_Amount_Old.Clear()
            Me.txtPolicy_EffectiveDate_Old.Clear()
            Exit Sub
        Else
            cmdSelect_Member.CommandText = "SELECT ID, Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, " & _
                                           "Deduction_Amount, Agent_Code, Submission_Date, Effective_Date, " & _
                                           "Cancellation_Date, Policy_No, Postal_Address_L1, Postal_Address_L2, " & _
                                           "Town, Postcode, State, Member_Policy_ID, add3, add4 " & _
                                           "FROM vi_Member_Policy_with_PostalAddress " & _
                                           "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                           "ORDER BY Deduction_Code"
        End If

        Dim da_Member_PostalAddress As New SqlDataAdapter(cmdSelect_Member)


        Dim ds_MemberInfo As New DataSet

        da_Member_PostalAddress.Fill(ds_MemberInfo, "vi_Member_Policy_with_PostalAddress")

        With Me.dgvPolicies
            .DataSource = ds_MemberInfo
            .DataMember = "vi_Member_Policy_with_PostalAddress"

            .Columns(0).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False

            .Columns(1).HeaderText = "File No."
            .Columns(2).HeaderText = "Full Name"
            .Columns(3).HeaderText = "IC (New)"
            .Columns(4).HeaderText = "Product Code"
            .Columns(5).HeaderText = "Requested Amount"
            .Columns(6).HeaderText = "Agent Code"
            .Columns(7).HeaderText = "Submission Date"
            .Columns(8).HeaderText = "1st Payment Date"
            .Columns(9).HeaderText = "Cancellation Date"
            .Columns(10).HeaderText = "Policy/Certificate No."

            .Columns(5).DefaultCellStyle.Format = "###.##"

            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With
    End Sub
#End Region
#Region "Click Events"
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub tsb_Filter_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
        Select Case Me.tsb_Filter.SelectedItem
            Case "IC"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.Populate_Grid("IC_New", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case "Full Name"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.Populate_Grid("Full_Name", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case Else
                Me.Populate_Grid("Null", "")
        End Select
    End Sub
    Private Sub dgvPolicies_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicies.CellClick
        Me.lblMember_ID.Text = ""
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtL2_Plan_Code_Old.Clear()
        Me.txtRequested_Amount_Old.Clear()
        Me.txtPolicy_EffectiveDate_Old.Clear()
        Me.txtMember_AddressL1.Clear()
        Me.txtMember_AddressL2.Clear()
        Me.txtAdd3.Clear()
        Me.txtAdd4.Clear()
        Me.txtMember_City.Clear()
        Me.txtMember_Postcode.Clear()
        Me.txtMember_State.Clear()
        Me.lblMemberPolicy_ID.Text = ""

        If e.RowIndex = -1 Then
            Exit Sub
        Else
            With Me.dgvPolicies.Rows(e.RowIndex)
                Me.lblMember_ID.Text = .Cells(0).Value.ToString.Trim
                Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                Me.txtName.Text = .Cells(2).Value.ToString.Trim
                Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                Me.txtL2_Plan_Code_Old.Text = .Cells(4).Value.ToString.Trim
                If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                    Me.txtRequested_Amount_Old.Text = Format(.Cells(5).Value, "#,##0.00")
                End If
                If Len(.Cells(8).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_EffectiveDate_Old.Text = Format(.Cells(8).Value, "dd/MM/yyyy")
                End If
                Me.txtMember_AddressL1.Text = .Cells(11).Value.ToString.Trim
                Me.txtMember_AddressL2.Text = .Cells(12).Value.ToString.Trim
                Me.txtMember_City.Text = .Cells(13).Value.ToString.Trim
                Me.txtMember_Postcode.Text = .Cells(14).Value.ToString.Trim
                Me.txtMember_State.Text = .Cells(15).Value.ToString.Trim
                Me.lblMemberPolicy_ID.Text = .Cells(16).Value.ToString.Trim
                Me.txtAdd3.Text = .Cells(17).Value.ToString.Trim
                Me.txtAdd4.Text = .Cells(18).Value.ToString.Trim
                Me.OK_Button.Enabled = True
            End With
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        MsgBox("Endorsement successfully.")
                        Me.OK_Button.Enabled = False
                        Me.lblMember_ID.Text = ""
                        Me.txtFileNo.Clear()
                        Me.txtName.Clear()
                        Me.txtNRIC.Clear()
                        Me.txtL2_Plan_Code_Old.Clear()
                        Me.txtRequested_Amount_Old.Clear()
                        Me.txtPolicy_EffectiveDate_Old.Clear()
                        Me.txtMember_AddressL1.Clear()
                        Me.txtMember_AddressL2.Clear()
                        Me.txtAdd3.Clear()
                        Me.txtAdd4.Clear()
                        Me.txtMember_City.Clear()
                        Me.txtMember_Postcode.Clear()
                        Me.txtMember_State.Clear()
                        Me.lblMemberPolicy_ID.Text = ""
                    Else
                        MsgBox("Error in endorsing this record.")
                        Me.OK_Button.Enabled = True
                    End If
                Case 7
                    Exit Sub
            End Select
            'Me.Close()
        End If
    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click
        Dim frmSearch_State As New frmSearch_Param

        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()

        Me.txtMember_State.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function Verify_Endorsement_Details() As Boolean
        If Len(Me.txtMember_AddressL1.Text.Trim) = 0 Then
            MsgBox("Please do key in the Postal Address.")
            Me.txtMember_AddressL1.Focus()
            Return False
        End If

        If Len(Me.txtMember_City.Text.Trim) = 0 Then
            MsgBox("Please do key in the Town.")
            Me.txtMember_City.Focus()
            Return False
        End If

        If Len(Me.txtMember_Postcode.Text.Trim) = 0 Then
            MsgBox("Please do key in the Postcode.")
            Me.txtMember_Postcode.Focus()
            Return False
        End If

        If Len(Me.txtMember_State.Text.Trim) = 0 Then
            MsgBox("Please do select the State.")
            Me.btnState.Focus()
            Return False
        End If

        If Me.txtMember_AddressL1.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim Then
            If Me.txtMember_AddressL2.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim Then
                If Me.txtAdd3.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim Then
                    If Me.txtAdd4.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim Then
                        If Me.txtMember_City.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim Then
                            If Me.txtMember_Postcode.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim Then
                                If Me.txtMember_State.Text.Trim = Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString.Trim Then
                                    MsgBox("No changes is been made")
                                    Return False
                                Else
                                    Return True
                                End If
                            Else
                                Return True
                            End If
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If

        Return True
    End Function
#End Region
#Region "Endorse"
    Private Function Endorse_Changes() As Boolean
        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT ID, IC_New, Postal_Address_L1, Postal_Address_L2, Town, Postcode, State, add3, add4 " & _
                                       "FROM dt_Member " & _
                                       "WHERE ID = '" & Me.lblMember_ID.Text.Trim & "'"
        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)

        Dim cmdUpdate_Member As SqlCommandBuilder
        cmdUpdate_Member = New SqlCommandBuilder(da_Member)


        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement where member_id='" & Me.lblMember_ID.Text.Trim & "' "
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)

        Dim scSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scSelect.CommandType = CommandType.Text
        scSelect.CommandText = "SELECT DISTINCT ID FROM DT_MEMBER_POLICY WHERE MEMBER_ID='" & Me.lblMember_ID.Text.Trim & "' "
        Dim sda As New SqlDataAdapter(scSelect)
        Dim ds As New DataSet
        sda.Fill(ds, "DT_MEMBER_POLICY")


        Dim ds_Endorsement As New DataSet


        Try
            da_Member.Fill(ds_Endorsement, "dt_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")

            With ds_Endorsement.Tables("dt_Member").Rows(0)
                .Item("Postal_Address_L1") = Me.txtMember_AddressL1.Text.Trim
                .Item("Postal_Address_L2") = Me.txtMember_AddressL2.Text.Trim
                .Item("Add3") = Me.txtAdd3.Text.Trim()
                .Item("Add4") = Me.txtAdd4.Text.Trim()
                .Item("Town") = Me.txtMember_City.Text.Trim
                .Item("Postcode") = Me.txtMember_Postcode.Text.Trim
                .Item("State") = Me.txtMember_State.Text.Trim
            End With

            da_Member.Update(ds_Endorsement, "dt_Member")

            Dim var_Change_Remark As String = ""
            Dim var_PostalAddress_Line1 As String = ""
            Dim var_PostalAddress_Line2 As String = ""
            Dim var_PostalAddress_City As String = ""
            Dim var_PostalAddress_Postcode As String = ""
            Dim var_PostalAddress_State As String = ""

            If Me.txtMember_AddressL1.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim) = 0 Then
                    var_PostalAddress_Line1 = "(BLANK)"
                Else
                    var_PostalAddress_Line1 = Me.dgvPolicies.SelectedRows(0).Cells(11).Value.ToString.Trim
                End If

                var_Change_Remark = "Change of Postal Address (Line 1) from: " & var_PostalAddress_Line1.Trim & _
                                    " to " & Me.txtMember_AddressL1.Text.Trim & ". "
            End If

            If Me.txtMember_AddressL2.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim) = 0 Then
                    var_PostalAddress_Line2 = "(BLANK)"
                Else
                    var_PostalAddress_Line2 = Me.dgvPolicies.SelectedRows(0).Cells(12).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (Line 2) from: " & var_PostalAddress_Line2.Trim & _
                                    " to " & Me.txtMember_AddressL2.Text.Trim & ". "
            End If
            Dim add3, add4 As String
            If Me.txtAdd3.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim) = 0 Then
                    add3 = "(BLANK)"
                Else
                    add3 = Me.dgvPolicies.SelectedRows(0).Cells(17).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (Line 3) from: " & add3.Trim & _
                                    " to " & Me.txtAdd3.Text.Trim & ". "
            End If
            If Me.txtAdd4.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim) = 0 Then
                    add4 = "(BLANK)"
                Else
                    add4 = Me.dgvPolicies.SelectedRows(0).Cells(18).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (Line 3) from: " & add4.Trim & _
                                    " to " & Me.txtAdd4.Text.Trim & ". "
            End If

            If Me.txtMember_City.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim) = 0 Then
                    var_PostalAddress_City = "(BLANK)"
                Else
                    var_PostalAddress_City = Me.dgvPolicies.SelectedRows(0).Cells(13).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (Town) from: " & var_PostalAddress_City.Trim & _
                                    " to " & Me.txtMember_City.Text.Trim & ". "
            End If

            If Me.txtMember_Postcode.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim) = 0 Then
                    var_PostalAddress_Postcode = "(BLANK)"
                Else
                    var_PostalAddress_Postcode = Me.dgvPolicies.SelectedRows(0).Cells(14).Value.ToString.Trim

                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (Postcode) from: " & var_PostalAddress_Postcode.Trim & _
                                    " to " & Me.txtMember_Postcode.Text.Trim & ". "
            End If

            If Me.txtMember_State.Text.Trim <> Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString.Trim Then
                If Len(Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString.Trim) = 0 Then
                    var_PostalAddress_State = "(BLANK)"
                Else
                    var_PostalAddress_State = Me.dgvPolicies.SelectedRows(0).Cells(15).Value.ToString.Trim
                End If

                var_Change_Remark = var_Change_Remark.Trim & " Change of Postal Address (State) from: " & var_PostalAddress_State.Trim & _
                                    " to " & Me.txtMember_State.Text.Trim & ". "
            End If


            Dim dr_Member_Endorsement_New As DataRow
            dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow
            With dr_Member_Endorsement_New
                .Item("ID") = Guid.NewGuid.ToString()
                .Item("Member_ID") = Me.lblMember_ID.Text.Trim
                .Item("Member_Policy_ID") = ds.Tables(0).Rows(0)("ID").ToString.Trim()
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "EA"
                .Item("Postal_Address_L1") = var_PostalAddress_Line1.Trim
                .Item("Postal_Address_L2") = var_PostalAddress_Line2.Trim & " " & add3 & " " & add4
                .Item("Town") = var_PostalAddress_City.Trim
                .Item("Postcode") = var_PostalAddress_Postcode.Trim
                .Item("State") = var_PostalAddress_State.Trim
                .Item("Endorsement_Detail") = var_Change_Remark.Trim
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("Remark") = Me.txtRemark.Text.Trim
                .Item("TRANS_TYPE") = "CHANGE OF ADDRESS"
                .Item("IC") = Me.txtNRIC.Text.Trim()
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Effective_Date") = dtpEffective_Date.Value
            End With

            ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
            da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")
            Me.objBusi.Log(ds.Tables(0).Rows(0)("ID").ToString.Trim(), "Changes Remaks : " & var_Change_Remark.Trim & " ***  Changed By User ID : " & My.Settings.Username & " ", Conn)
            Return True
        Catch ex As Exception
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
