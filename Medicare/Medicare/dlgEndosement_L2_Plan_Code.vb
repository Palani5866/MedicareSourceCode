Imports System.Windows.Forms
Imports System.IO
Public Class dlgEndosement_L2_Plan_Code
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim MID As String
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_L2_Plan_Code_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgEndosement_L2_Plan_Code_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.txtPlanCodeAmt.ReadOnly = True
        Me.txtPlanCodeLevel2.ReadOnly = True
        Me.txtPlanCode.ReadOnly = True
        btnDependent_Add.Enabled = False
        Me.OK_Button.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.btnClear.Enabled = False
        Me.btnUpload.Enabled = False
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
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.txtFileNo.Clear()
        Me.txtName.Clear()
        Me.txtNRIC.Clear()
        Me.txtL2_Plan_Code_Old.Clear()
        Me.txtRequested_Amount_Old.Clear()
        Me.txtPolicy_EffectiveDate_Old.Clear()
        Dim dt As New DataTable
        Try
            If e.RowIndex = -1 Then
                Exit Sub
            Else
                With Me.dgvPolicies.Rows(e.RowIndex)
                    dt = _objBusi.Check("POLICY", .Cells(0).Value.ToString.Trim, "", "", "", "", "", "", "", "", "CHANGEPLAN", Conn)
                    If dt.Rows.Count > 0 Then
                        Me.lblMemberPolicy_ID.Text = .Cells(0).Value.ToString.Trim
                        Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                        Me.txtName.Text = .Cells(2).Value.ToString.Trim
                        Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                        Me.txtL2_Plan_Code_Old.Text = .Cells(4).Value.ToString.Trim
                        If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                            If IsNumeric(.Cells(5).Value) = True Then
                                Me.txtRequested_Amount_Old.Text = Format(.Cells(5).Value, "#,##0.00")
                            End If
                        End If
                        Me.OK_Button.Enabled = True
                        btnDependent_Add.Enabled = True
                        Me.btnBrowse.Enabled = True
                        Me.btnClear.Enabled = True
                        Me.btnUpload.Enabled = True
                    Else
                        MsgBox("You can't perform this action due to policy has been Cancelled/Change plan or Other's, Please check with your admin!")
                    End If
                End With
            End If
        Catch ex As Exception
            MsgBox("Currently our server busy! Please try again later!")
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        MsgBox("Endorsement successfully.")
                        If Me.txtPlanCodeLevel2.Text.Trim() = "EMPLOYEE AND FAMILY ONLY" Then
                            Me.btnDependent_Add.Enabled = True
                        Else
                            Me.btnDependent_Add.Enabled = False
                        End If
                    End If
                Case 7
                    Exit Sub
            End Select
        End If
    End Sub
    Private Sub btnDependent_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent_Add.Click
        If Me.txtPlanCodeLevel2.Text.Trim() = "EMPLOYEE AND FAMILY ONLY" Then
            dlgEndosement_DependantDetails.lblICNO.Text = txtNRIC.Text.ToString.Trim
            dlgEndosement_DependantDetails.Show()
        Else
            MsgBox("Invalid plan code, Please check plan and try again!")
        End If
    End Sub
    Private Sub btnPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlan.Click
        Dim findProduct_Code As New findProduct_Code
        findProduct_Code.lblREF1.Text = Me.lblMemberPolicy_ID.Text.ToString.Trim()
        findProduct_Code.ShowDialog()
        Dim iData As IDataObject = Clipboard.GetDataObject()
        If iData.GetDataPresent(DataFormats.Text) Then
            Me.txtPlanCode.Text = CType(iData.GetData(DataFormats.Text), String)
            GetDetails(CType(iData.GetData(DataFormats.Text), String))
            Me.btnDependent_Add.Enabled = False
        Else
            Me.txtPlanCode.Text = "Could not retrieve data off the clipboard."
        End If
        My.Computer.Clipboard.Clear()
    End Sub
#End Region
#Region "DataBind Events"
    Private Sub Populate_Grid(ByVal Search_Param1 As String, ByVal Search_Param2 As String)
        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text

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
            Me.dtpPolicy_CancellationDate_Old.Value = Now()
            Exit Sub
        Else
            cmdSelect_Member_Policy.CommandText = "SELECT ID, Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, " & _
                                                  "Deduction_Amount, Agent_Code, Submission_Date, Effective_Date, " & _
                                                  "Cancellation_Date, Policy_No " & _
                                                  "FROM vi_Member_Policy_v2 " & _
                                                  "WHERE " & Search_Param1 & " Like '" & Search_Param2 & "%' " & _
                                                  "ORDER BY Deduction_Code"
        End If

        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)
        Dim ds_MemberInfo As New DataSet
        da_Member_Policy.Fill(ds_MemberInfo, "vi_Member_Policy_v2")

        With Me.dgvPolicies
            .DataSource = ds_MemberInfo
            .DataMember = "vi_Member_Policy_v2"

            .Columns(0).Visible = False
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

            .Columns(5).DefaultCellStyle.Format = "#,##0.00"

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
    Private Sub tsb_Filter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsb_Filter.SelectedIndexChanged
        Me.tsb_Filter_Param.Clear()
    End Sub
#Region "General Functions/Subs"
    Private Sub GetDetails(ByVal ID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("MEMBERDETAILS", Me.lblMemberPolicy_ID.Text.ToString.Trim(), "", "", "", "PLANCODE", Conn)

        Dim scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scGet.CommandType = CommandType.Text
        scGet.CommandText = "SELECT * FROM tb_product_code a " & _
                            " inner join tb_deduction_code c on a.product_code=c.product_code " & _
                            " WHERE a.Product_Code='" & ID & "'"
        Dim sda As New SqlDataAdapter(scGet)
        Dim ds As New DataSet
        sda.Fill(ds, "tb_product_code")

        Dim dtAge As New DataTable
        dtAge = _objBusi.getDetails("MEMBERCHECK", dt.Rows(0)("IC_NEW").ToString.Trim(), "", "", "", "PRODUCTAGE", Conn)
        Dim NOOFTIMES As Integer = 0
        Dim dtAllow As New DataTable
        dtAllow = _objBusi.getDetails("MEMBERCHECK", ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "", "PRODUCTALLOW", Conn)
        If dtAllow.Rows.Count > 0 Then
            Dim S As String
            S = dtAllow.Rows(0)("PRODUCT_PLAN_TYPE")
            If Not IsDBNull(dtAllow.Rows(0)("NO_OF_TIMES")) Then
                NOOFTIMES = dtAllow.Rows(0)("NO_OF_TIMES")
            Else
                NOOFTIMES = 1
            End If
        Else
            NOOFTIMES = 1
        End If
        Dim iRowCount As Integer = 0
        Dim dtDep As New DataTable
        dtDep = _objBusi.getDetails("MEMBERDETAILS", Me.lblMemberPolicy_ID.Text.ToString.Trim(), "", "", "DEP", "PLANCODE", Conn)
        Dim iCount As Integer = 0
        If dtDep.Rows.Count > 0 Then
            Do While iCount < dtDep.Rows.Count
                If dtDep.Rows(iCount)("RELATIONSHIP").ToString.Trim().ToUpper() = "SPOUSE" Then
                    Dim dtChk2 As New DataTable
                    dtChk2 = _objBusi.getDetails("MEMBERCHECK", "C" & dtDep.Rows(iCount)("IC_NEW").ToString.Trim(), ds.Tables(0).Rows(0)("Product_Code").ToString.Trim().Substring(0, 11), "", "", "MEMBER", Conn)
                    If dtChk2.Rows.Count > 0 Then
                        MsgBox("Spouse have the policy with this product!Please do re select another product or Remove the spouse Name from Dependents List")
                        txtPlanCode.Text = "WRONGCODE"
                        Exit Sub
                    End If
                End If
                iCount += 1
            Loop
        End If

        Me.txtPlanCode.Text = ds.Tables(0).Rows(0)("Product_Code").ToString.Trim()
        Me.txtPlanCodeLevel2.Text = ds.Tables(0).Rows(0)("Plan_Type").ToString.Trim()
        Dim scSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scSelect.CommandType = CommandType.Text
        scSelect.CommandText = "SELECT * FROM tb_Premium_Table WHERE Premium_Code='" & ds.Tables(0).Rows(0)("Premium_Code").ToString.Trim() & "' and status='Active'"
        Dim sdaP As New SqlDataAdapter(scSelect)
        Dim dsP As New DataSet
        sdaP.Fill(dsP, "tb_Premium_Table")

        For Each dr As DataRow In dsP.Tables(0).Rows
            Dim Age As String
            Age = Math.Floor(DateDiff(DateInterval.Day, dt.Rows(0)("Birth_Date"), Now()) / 365.25)
            Dim Age_Limit As String()
            Dim a As String
            a = dr("Age_Limit")
            Age_Limit = a.Split("-")
            If (Age > Age_Limit(0) Or Age >= Age_Limit(0)) And (Age < Age_Limit(1) Or Age <= Age_Limit(1)) Then
                Me.txtPlanCodeAmt.Text = dr("Premium_Amt")
                Exit For
            Else
                Me.txtPlanCodeAmt.Text = ""
            End If
        Next
        If Me.txtPlanCodeAmt.Text = "" Then
            If Not MsgBox("Proposer age exceed canot proceed the further action! you want select another product ? else Proposal will be reject!", vbYesNo, "Change") = vbYes Then
                Me.txtPlanCodeAmt.Text = "0"
                Me.Close()
                Exit Sub
            Else
                Me.txtPlanCode.Text = ""
                Me.txtPlanCodeLevel2.Text = ""
                Exit Sub
            End If
        End If
        Dim sP As String
        sP = ds.Tables(0).Rows(0)("Product_Code").ToString.Substring(0, 10).Trim()
        Select Case sP
            Case "CUEPACS PA"
                Dim PATotalAmount As Double
                Dim TotalAmount As String
                Dim Age As String
                Dim dep_count As Integer = 0
                Dim Age_Limit As String()
                Dim a As String
                Age = Math.Floor(DateDiff(DateInterval.Day, dt.Rows(0)("Birth_Date"), Now()) / 365.25)
                For Each dr As DataRow In dsP.Tables(0).Rows
                    a = dr("Age_Limit")
                    Age_Limit = a.Split("-")
                    Dim PType As String
                    PType = dr("Participant_Type").ToString.Trim()
                    If PType = "MEMBER" Then
                        If Age > Age_Limit(0) And Age < Age_Limit(1) Then
                            PATotalAmount += dr("Premium_Amt")
                            Me.txtPlanCodeAmt.Text = PATotalAmount
                            Exit For
                        End If
                    End If
                Next
                If dtDep.Rows.Count > 0 Then
                    Do While dep_count < dtDep.Rows.Count
                        Dim DepAge, Relation, depParam As String
                        DepAge = Math.Floor(DateDiff(DateInterval.Day, dtDep.Rows(dep_count)("BIRTH_DATE"), Now()) / 365.25)
                        Dim sLen As String
                        sLen = DepAge.Length()
                        If sLen = "1" Then
                            DepAge = "0" & DepAge
                        End If
                        Relation = dtDep.Rows(dep_count)("RELATIONSHIP")
                        If Relation = "Children" Then
                            depParam = "CHILD"
                        Else
                            depParam = "SPOUSE"
                        End If
                        For Each dr As DataRow In dsP.Tables(0).Select("Participant_Type = '" & depParam & "'")
                            a = dr("Age_Limit")
                            Age_Limit = a.Split("-")
                            If (DepAge > Age_Limit(0) Or DepAge >= Age_Limit(0)) And (DepAge < Age_Limit(1) Or DepAge <= Age_Limit(1)) Then
                                PATotalAmount += dr("Premium_Amt")
                                Exit For
                            End If
                        Next
                        TotalAmount = PATotalAmount
                        dep_count += 1
                    Loop
                    Me.txtPlanCodeAmt.Text = PATotalAmount
                End If
            Case Else
                For Each dr As DataRow In dsP.Tables(0).Rows
                    Dim Age As Integer
                    Dim dep_count As Integer = 0
                    Dim Relations As String = ""
                    If dtDep.Rows.Count > 0 Then
                        Age = Math.Floor(DateDiff(DateInterval.Day, dt.Rows(0)("BIRTH_DATE"), Now()) / 365.25)
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
                        Age = Math.Floor(DateDiff(DateInterval.Day, dt.Rows(0)("BIRTH_DATE"), Now()) / 365.25)
                    End If
                    If Not Relations = "Children" Then
                        Dim Age_Limit As String()
                        Dim a As String
                        a = dr("Age_Limit")
                        Age_Limit = a.Split("-")
                        If Age > Age_Limit(0) And Age < Age_Limit(1) Then
                            Exit For
                        End If
                    End If
                Next
        End Select
        Me.txtPlanCodeAmt.Enabled = False
    End Sub
    Private Function Verify_Endorsement_Details() As Boolean
        If Len(Me.txtPlanCode.Text.Trim) = 0 Then
            MsgBox("Please do key in the new Plan Code (Level 2).")
            Me.txtPlanCode.Focus()
            Return False
        Else
            If Me.txtL2_Plan_Code_Old.Text.Trim = Me.txtPlanCode.Text.Trim Then
                MsgBox("New Plan Code (Level 2) cannot be the same as Old Plan Code (Level 2).")
                Me.txtPlanCode.Focus()
                Return False
            End If
        End If

        If Len(Me.txtPlanCodeAmt.Text.Trim) = 0 Then
            MsgBox("Please do key in the new Premium/Requested Amount.")
            Me.txtPlanCodeAmt.Focus()
            Return False
        ElseIf IsNumeric(Me.txtPlanCodeAmt.Text.Trim) = False Then
            MsgBox("Please do key in Numeric Value for new Premium/Requested Amount.")
            Me.txtPlanCodeAmt.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function Endorse_Changes() As Boolean
        Try
            Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberPolicy.CommandType = CommandType.Text
            cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                                 "WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
            Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

            Dim cmdInsert_MemberPolicy As SqlCommandBuilder
            cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

            Dim cmdSelect_MemberPolicy_Dependents As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberPolicy_Dependents.CommandType = CommandType.Text
            cmdSelect_MemberPolicy_Dependents.CommandText = "SELECT * FROM dt_Member_Policy_Dependents " & _
                                                            "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
            Dim da_MemberPolicy_Dependents As New SqlDataAdapter(cmdSelect_MemberPolicy_Dependents)

            Dim cmdInsert_MemberPolicy_Dependents As SqlCommandBuilder
            cmdInsert_MemberPolicy_Dependents = New SqlCommandBuilder(da_MemberPolicy_Dependents)

            Dim cmdSelect_MemberPolicy_ExclusionClause As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberPolicy_ExclusionClause.CommandType = CommandType.Text
            cmdSelect_MemberPolicy_ExclusionClause.CommandText = "SELECT * FROM dt_Member_Policy_Exclusion_Clause " & _
                                                                 "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
            Dim da_MemberPolicy_ExclusionClause As New SqlDataAdapter(cmdSelect_MemberPolicy_ExclusionClause)

            Dim cmdInsert_MemberPolicy_ExclusionClause As SqlCommandBuilder
            cmdInsert_MemberPolicy_ExclusionClause = New SqlCommandBuilder(da_MemberPolicy_ExclusionClause)

            Dim cmdSelect_MemberPolicy_Nomination As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberPolicy_Nomination.CommandType = CommandType.Text
            cmdSelect_MemberPolicy_Nomination.CommandText = "SELECT * FROM dt_Member_Policy_Nomination " & _
                                                            "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
            Dim da_MemberPolicy_Nomination As New SqlDataAdapter(cmdSelect_MemberPolicy_Nomination)

            Dim cmdInsert_MemberPolicy_Nomination As SqlCommandBuilder
            cmdInsert_MemberPolicy_Nomination = New SqlCommandBuilder(da_MemberPolicy_Nomination)

            Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberLog.CommandType = CommandType.Text
            cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                              "WHERE Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"

            Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

            Dim cmdInsert_MemberLog As SqlCommandBuilder
            cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)

            Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Endorsement.CommandType = CommandType.Text
            cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
            Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

            Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
            cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)
            Dim P_Code As String


            Dim ds_Endorsement As New DataSet


            Try
                da_MemberPolicy.Fill(ds_Endorsement, "dt_Member_Policy")
                da_MemberPolicy_Dependents.Fill(ds_Endorsement, "dt_Member_Policy_Dependents")
                da_MemberPolicy_ExclusionClause.Fill(ds_Endorsement, "dt_Member_Policy_Exclusion_Clause")
                da_MemberPolicy_Nomination.Fill(ds_Endorsement, "dt_Member_Policy_Nomination")
                da_MemberLog.Fill(ds_Endorsement, "log_Member")
                da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")


                With ds_Endorsement.Tables("dt_Member_Policy").Rows(0)
                    .Item("Cancellation_Date") = Me.dtpPolicy_CancellationDate_Old.Value.Date
                    .Item("Status") = "Transferred to " & Me.txtPlanCode.Text.Trim
                    .Item("Remarks") = "Change Plan From " & ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Deduction_Code").ToString & " To " & Me.txtPlanCode.Text.Trim
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()
                End With

                _objBusi.InsUpsPremiumHistory("EUPC", Guid.NewGuid.ToString(), Me.lblMemberPolicy_ID.Text.Trim, "", Format(Me.dtpPolicy_CancellationDate_Old.Value, "MM/dd/yyyy"), Me.txtRequested_Amount_Old.Text.Trim(), "InActive", "Change Plan", My.Settings.Username, Conn)

                _objBusi.InsUpsPolicyPremiumHistory("UPDATE", Me.lblMemberPolicy_ID.Text.ToString.Trim(), "0.00", "", Format(Me.dtpPolicy_CancellationDate_Old.Value, "MM/dd/yyyy"), "Change Plan", My.Settings.Username, Conn)

                Dim dr_MemberPolicy_Old As DataRow = ds_Endorsement.Tables("dt_Member_Policy").Rows(0)

                With dr_MemberPolicy_Old
                    .Item("Member_ID") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                    .Item("Agent_Code") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Agent_Code").ToString
                    .Item("Submission_Date") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Submission_Date")
                    .Item("Angkasa_FileNo") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Angkasa_FileNo")
                    .Item("Plan_Code") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Plan_Code")
                    .Item("Level2_Plan_Code") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Level2_Plan_Code")
                    .Item("Special_Promo") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Special_Promo")
                    .Item("Underwriting_Required") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Underwriting_Required")
                    .Item("Payment_Frequency") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Payment_Frequency")
                    .Item("Payment_Method") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Payment_Method")
                    .Item("DataEntry_Checklist_Proposer_Details") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Proposer_Details")
                    .Item("DataEntry_Checklist_Enrolled_Dependents") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Enrolled_Dependents")
                    .Item("DataEntry_Checklist_Insurance_Proposed") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Insurance_Proposed")
                    .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_BiroAngkasa_Deduction")
                    .Item("DataEntry_Checklist_Nomination") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Nomination")
                    .Item("Document_Checklist_Application_Form") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Application_Form")
                    .Item("Document_Checklist_IC") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_IC")
                    .Item("Document_Checklist_Payslip") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Payslip")
                    .Item("Document_Checklist_Borang1_79") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Borang1_79")
                End With

                Dim dr_MemberPolicy_New As DataRow
                Dim var_MemberPolicy_ID_New As String = ""
                dr_MemberPolicy_New = ds_Endorsement.Tables("dt_Member_Policy").NewRow

                With dr_MemberPolicy_New
                    var_MemberPolicy_ID_New = Guid.NewGuid.ToString
                    .Item("ID") = var_MemberPolicy_ID_New
                    Dim p As String()

                    p = Me.txtPlanCode.Text.ToString.Trim().Split("-")
                    Dim s, s1 As String
                    s = p(0)
                    s1 = p(1)
                    P_Code = p(1).ToString.Trim()
                    .Item("Deduction_Code") = p(1).ToString.Trim()
                    .Item("Deduction_Amount") = Me.txtPlanCodeAmt.Text
                    Select Case Me.txtL2_Plan_Code_Old.Text.Trim()
                        Case "0511", "0512", "0513", "0514", "0531", "0532", "0550", "0551"
                            Select Case P_Code
                                Case "0511", "0512", "0513", "0514", "0531", "0532", "0550", "0551"
                                Case Else
                                    MsgBox("Can't change the plan code due to payment method is different!")
                                    Me.txtPlanCode.Text = ""
                                    Me.txtPlanCodeLevel2.Text = ""
                                    Me.txtPlanCodeAmt.Text = ""
                                    Return False
                            End Select
                    End Select
                    Dim sSri As String
                    sSri = P_Code.Substring(0, 1)
                    If sSri = "Y" Then
                        Dim var_Effective_Day As Integer = Convert.ToDateTime(Me.dtpEffective_Date.Value.Date).Day
                        Dim var_Effective_Month As Integer = Convert.ToDateTime(Me.dtpEffective_Date.Value.Date).Month
                        Dim var_Effective_Year As Integer = Convert.ToDateTime(Me.dtpEffective_Date.Value.Date).Year
                        Dim var_Effective_Date As Date = var_Effective_Day.ToString & "/" & var_Effective_Month.ToString & "/" & var_Effective_Year.ToString
                        .Item("Effective_Date") = var_Effective_Date
                        .Item("Cancellation_Date") = Me.dtpPolicy_CancellationDate_Old.Value.Date
                    Else
                        .Item("Effective_Date") = Me.dtpEffective_Date.Value.Date
                        _objBusi.InsUpsPremiumHistory("INS", Guid.NewGuid.ToString(), var_MemberPolicy_ID_New, Format(Me.dtpEffective_Date.Value.Date, "MM/dd/yyyy"), "", Me.txtPlanCodeAmt.Text, "Active", "Change Plan", My.Settings.Username, Conn)
                        _objBusi.InsUpsPolicyPremiumHistory("INS", var_MemberPolicy_ID_New, Me.txtPlanCodeAmt.Text, Format(Me.dtpEffective_Date.Value.Date, "MM/dd/yyyy"), "", "Change Plan", My.Settings.Username, Conn)
                    End If
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    .Item("Member_ID") = dr_MemberPolicy_Old.Item("Member_ID")
                    .Item("Agent_Code") = dr_MemberPolicy_Old.Item("Agent_Code")
                    .Item("Submission_Date") = dr_MemberPolicy_Old.Item("Submission_Date")
                    .Item("Angkasa_FileNo") = dr_MemberPolicy_Old.Item("Angkasa_FileNo")
                    .Item("Plan_Code") = Me.txtPlanCode.Text.Trim
                    .Item("Level2_Plan_Code") = Me.txtPlanCodeLevel2.Text.Trim
                    .Item("Special_Promo") = dr_MemberPolicy_Old.Item("Special_Promo")
                    .Item("Underwriting_Required") = dr_MemberPolicy_Old.Item("Underwriting_Required")
                    .Item("Payment_Frequency") = dr_MemberPolicy_Old.Item("Payment_Frequency")
                    .Item("Payment_Method") = dr_MemberPolicy_Old.Item("Payment_Method")
                    .Item("DataEntry_Checklist_Proposer_Details") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Proposer_Details")
                    .Item("DataEntry_Checklist_Enrolled_Dependents") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Enrolled_Dependents")
                    .Item("DataEntry_Checklist_Insurance_Proposed") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Insurance_Proposed")
                    .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_BiroAngkasa_Deduction")
                    .Item("DataEntry_Checklist_Nomination") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Nomination")
                    .Item("Document_Checklist_Application_Form") = dr_MemberPolicy_Old.Item("Document_Checklist_Application_Form")
                    .Item("Document_Checklist_IC") = dr_MemberPolicy_Old.Item("Document_Checklist_IC")
                    .Item("Document_Checklist_Payslip") = dr_MemberPolicy_Old.Item("Document_Checklist_Payslip")
                    .Item("Document_Checklist_Borang1_79") = dr_MemberPolicy_Old.Item("Document_Checklist_Borang1_79")
                    .Item("Status") = "INFORCE"
                    .Item("Policy_Status") = "New"
                    .Item("Remarks") = "Change Plan From " & ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Deduction_Code").ToString & " To " & P_Code
                End With

                ds_Endorsement.Tables("dt_Member_Policy").Rows.Add(dr_MemberPolicy_New)
                da_MemberPolicy.Update(ds_Endorsement, "dt_Member_Policy")

                Dim dr_MemberPolicy_Dependents As DataRow()
                Dim var_Dependent_count As Integer = 0

                If (P_Code = "Y0531" Or P_Code = "0531" Or P_Code = "0511") Then
                    dr_MemberPolicy_Dependents = ds_Endorsement.Tables("dt_Member_Policy_Dependents").Select("Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'")

                    If dr_MemberPolicy_Dependents.Length > 0 Then
                        Do While var_Dependent_count < dr_MemberPolicy_Dependents.Length
                            Dim dr_MemberPolicy_Dependents_New As DataRow = ds_Endorsement.Tables("dt_Member_Policy_Dependents").NewRow

                            With dr_MemberPolicy_Dependents_New
                                .Item("ID") = Guid.NewGuid.ToString
                                .Item("Member_Policy_ID") = var_MemberPolicy_ID_New
                                .Item("Title") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Title").ToString.Trim
                                .Item("Full_Name") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Full_Name").ToString.Trim
                                .Item("Birth_Date") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Birth_Date")
                                .Item("IC_New") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("IC_New").ToString.Trim
                                .Item("IC_Old") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("IC_Old").ToString.Trim
                                .Item("ArmForce_ID") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("ArmForce_ID").ToString.Trim
                                .Item("Race") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Race").ToString.Trim
                                .Item("Marital_Status") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Marital_Status").ToString.Trim
                                .Item("Relationship") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Relationship").ToString.Trim
                                .Item("Sex") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Sex")
                                .Item("Height") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Height")
                                .Item("Weight") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Weight")
                                .Item("Occupation") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Occupation").ToString.Trim
                                .Item("Department") = dr_MemberPolicy_Dependents(var_Dependent_count).Item("Department").ToString.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                            End With
                            ds_Endorsement.Tables("dt_Member_Policy_Dependents").Rows.Add(dr_MemberPolicy_Dependents_New)
                            da_MemberPolicy_Dependents.Update(ds_Endorsement, "dt_Member_Policy_Dependents")
                            var_Dependent_count += 1
                        Loop
                    End If
                End If


                If (P_Code = "Y0532" Or P_Code = "0532" Or P_Code = "0512") Then
                    Dim Member_Policy_ID As String
                    Member_Policy_ID = Me.lblMemberPolicy_ID.Text.Trim
                    Dim scMemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    scMemberPolicy.CommandType = CommandType.Text
                    scMemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
                    Dim sda_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)
                    Dim ds As New DataSet
                    sda_MemberPolicy.Fill(ds, "dt_member_policy")
                    If ds.Tables(0).Rows(0)("Status") = "Transferred to " & P_Code Then
                        Dim scRemoveOldDependent As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        scRemoveOldDependent.CommandType = CommandType.Text
                        scRemoveOldDependent.CommandText = "DELETE FROM dt_Member_Policy_Dependents where member_policy_id='" & Me.lblMemberPolicy_ID.Text.Trim & "'"
                        scRemoveOldDependent.ExecuteNonQuery()
                    End If
                End If
                Dim dr_MemberPolicy_EC As DataRow()
                Dim var_EC_count As Integer = 0

                dr_MemberPolicy_EC = ds_Endorsement.Tables("dt_Member_Policy_Exclusion_Clause").Select("Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'")

                If dr_MemberPolicy_EC.Length > 0 Then
                    Do While var_EC_count < dr_MemberPolicy_EC.Length
                        Dim dr_Member_Policy_EC_New As DataRow = ds_Endorsement.Tables("dt_Member_Policy_Exclusion_Clause").NewRow

                        With dr_Member_Policy_EC_New
                            .Item("ID") = Guid.NewGuid.ToString
                            .Item("Member_Policy_ID") = var_MemberPolicy_ID_New
                            .Item("ExclusionClause_Code") = dr_MemberPolicy_EC(var_EC_count).Item("ExclusionClause_Code").ToString.Trim
                            .Item("ExclusionClause_Description") = dr_MemberPolicy_EC(var_EC_count).Item("ExclusionClause_Description").ToString.Trim
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                            .Item("Last_Modified_By") = My.Settings.Username.Trim
                            .Item("Last_Modified_On") = Now()
                        End With
                        ds_Endorsement.Tables("dt_Member_Policy_Exclusion_Clause").Rows.Add(dr_Member_Policy_EC_New)
                        da_MemberPolicy_ExclusionClause.Update(ds_Endorsement, "dt_Member_Policy_Exclusion_Clause")
                        var_EC_count += 1
                    Loop
                End If

                Dim dr_MemberPolicy_Nomination As DataRow()
                Dim var_Nomination_count As Integer = 0

                dr_MemberPolicy_Nomination = ds_Endorsement.Tables("dt_Member_Policy_Nomination").Select("Member_Policy_ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'")

                If dr_MemberPolicy_Nomination.Length > 0 Then
                    Do While var_Nomination_count < dr_MemberPolicy_Nomination.Length
                        Dim dr_Member_Policy_Nomination_New As DataRow = ds_Endorsement.Tables("dt_Member_Policy_Nomination").NewRow

                        With dr_Member_Policy_Nomination_New
                            .Item("ID") = Guid.NewGuid.ToString
                            .Item("Member_Policy_ID") = var_MemberPolicy_ID_New
                            .Item("Title") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Title").ToString.Trim
                            .Item("Full_Name") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Full_Name").ToString.Trim
                            .Item("Birth_Date") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Birth_Date")
                            .Item("IC_New") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("IC_New").ToString.Trim
                            .Item("Relationship") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Relationship").ToString.Trim
                            .Item("Postal_Address") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Postal_Address").ToString.Trim
                            .Item("Share") = dr_MemberPolicy_Nomination(var_Nomination_count).Item("Share")
                            .Item("Created_By") = My.Settings.Username.Trim
                            .Item("Created_On") = Now()
                            .Item("Last_Modified_By") = My.Settings.Username.Trim
                            .Item("Last_Modified_On") = Now()
                        End With
                        ds_Endorsement.Tables("dt_Member_Policy_Nomination").Rows.Add(dr_Member_Policy_Nomination_New)
                        da_MemberPolicy_Nomination.Update(ds_Endorsement, "dt_Member_Policy_Nomination")
                        var_Nomination_count += 1
                    Loop
                End If

                Dim dr_MemberLog_Old As DataRow
                dr_MemberLog_Old = ds_Endorsement.Tables("log_Member").NewRow

                With dr_MemberLog_Old
                    .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                    .Item("Log_Date") = Now()
                    .Item("Activity_Detail") = "Change Plan Code (Level 2) from: " & Me.txtL2_Plan_Code_Old.Text.Trim & _
                                               " to " & P_Code
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Endorsement.Tables("log_Member").Rows.Add(dr_MemberLog_Old)
                da_MemberLog.Update(ds_Endorsement, "log_Member")

                Dim dr_MemberLog_New As DataRow
                dr_MemberLog_New = ds_Endorsement.Tables("log_Member").NewRow

                With dr_MemberLog_New
                    .Item("Member_Policy_ID") = var_MemberPolicy_ID_New
                    .Item("Log_Date") = Now()
                    .Item("Activity_Detail") = "Change Plan Code (Level 2) from: " & Me.txtL2_Plan_Code_Old.Text.Trim & _
                                               " to " & P_Code
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Endorsement.Tables("log_Member").Rows.Add(dr_MemberLog_New)
                da_MemberLog.Update(ds_Endorsement, "log_Member")

                Dim dr_Member_Endorsement_New As DataRow
                dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow

                With dr_Member_Endorsement_New
                    .Item("Member_ID") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                    .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                    .Item("Log_Date") = Now()
                    .Item("Endorsement_Type") = "E"
                    .Item("Endorsement_Detail") = "Change Plan Code (Level 2) from: " & Me.txtL2_Plan_Code_Old.Text.Trim & _
                                                  " to " & P_Code
                    .Item("Request_Date") = Me.dtpRequestedDate.Value
                    .Item("TRANS_TYPE") = "CHANGE OF PLAN CODE"
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Effective_Date") = dtpEffective_Date.Value
                End With

                ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
                da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")

                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
#Region "DOCUMENTS UPLOAD"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
            If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                Me.txtBrowse.Text = OpenFileDialog.FileName
            Else 'Cancel
                MsgBox("File Requied")
                Exit Sub
            End If
        End Using
    End Sub
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim sFileToUpload As String = ""
        sFileToUpload = LTrim(RTrim(Me.txtBrowse.Text.Trim()))
        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
        If upLoadImageOrFile(sFileToUpload, Extension) Then
            MsgBox("Uploaded successfully, Please check at Member log.")
            Me.txtBrowse.Text = ""
            Me.txtDocName.Text = ""
        Else
            MsgBox("Error while uploading the documnet or Currently our server busy Please try again later.")
        End If
    End Sub
    Private Function upLoadImageOrFile(ByVal sFilePath As String, ByVal sFileType As String) As Boolean
        Dim FileData As Byte()
        Dim sFileName As String
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            MID = Me.lblMemberPolicy_ID.Text.Trim
            If chkUpFName(sFileName, MID) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If

            Dim ext As String = sFileType
            Dim contenttype As String = String.Empty
            Select Case ext
                Case ".doc"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".docx"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".xls"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select
            _objBusi.fIUDocumentCheckList("INS", Guid.NewGuid.ToString(), MID, MID, "MEMBER", "", contenttype, sFileType, sFileName, DirectCast(FileData, Object), "", My.Settings.Username.ToString.Trim(), Conn)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ReadFile(ByVal sPath As String) As Byte()
        Dim data As Byte() = Nothing
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal MID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("DOCCHKLIST", fname, MID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtBrowse.Text = ""
        Me.txtDocName.Text = ""
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
