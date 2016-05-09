Public Class Exclusion_Clause
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub Exclusion_Clause_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Exclusion_Clause_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblGUID.Text = "" Then
            getExclusionClauseDetails(Me.lblExclusionClause_ID.Text)
            Me.btnSubmit.Name = "Update"
            Me.btnSubmit.Text = "Update"
            Me.btnDelete.Visible = True
            Me.lblRemarks.Visible = True
            Me.txtRemarks.Visible = True
            Me.btnDependent.Enabled = False
            Me.chkUnderwriting_ApplyTo.Enabled = False
        Else
            Me.btnSubmit.Name = "Submit"
            Me.btnSubmit.Text = "Submit"
            Me.btnDelete.Visible = False
            Me.lblRemarks.Visible = False
            Me.txtRemarks.Visible = False
        End If
    End Sub
#End Region
#Region "Data Bind"
    Private Sub getExclusionClauseDetails(ByVal EID As String)
        Dim dt As New DataTable
        dt = objBusi.getDetails("MEMBER", EID, "", "", "", "EEC", Conn)
        If dt.Rows.Count > 0 Then
            Me.lblMember_Policy_ID.Text = dt.Rows(0)("MPID").ToString().Trim()
            Me.lblMemberID.Text = dt.Rows(0)("MID").ToString().Trim()
            Me.txtUnderwriting_ExclusionClause_Header.Text = dt.Rows(0)("ExclusionClause_Description")
            Me.txtUnderwriting_ExclusionClause_Code.Text = dt.Rows(0)("ExclusionClause_Code")
            If Not IsDBNull(dt.Rows(0)("applyto")) Then
                Me.txtUnderwriting_ApplyTo.Text = dt.Rows(0)("applyto")
            Else
                Me.txtUnderwriting_ApplyTo.Text = ""
            End If
            If Not IsDBNull(dt.Rows(0)("Effective_Date")) Then
                Me.dtpEffectiveDate.Value = dt.Rows(0)("Effective_Date")
            End If
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If chkValidate() = True Then
            If Me.btnSubmit.Name = "Update" Then
                ups_ExclusionClause()
            Else
                ins_ExclusionClause()
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnExclusionClause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExclusionClause.Click
        Dim frmSearch_ExclusionClause As New frmSearch_Param

        frmSearch_ExclusionClause.lblForm_Flag.Text = "E"
        frmSearch_ExclusionClause.ShowDialog()

        Me.txtUnderwriting_ExclusionClause_Code.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()

        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) <> 0 Then
            If Me.txtUnderwriting_ExclusionClause_Code.Text.Substring(0, 1) = "E" Then
                Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSearch_Parameter.CommandType = CommandType.Text
                cmdSearch_Parameter.CommandText = "SELECT ExclusionClause_Header, ExclusionClause_Footer FROM dt_Underwriting_ExclusionClause " & _
                                                  "WHERE ExclusionClause_Code = '" & Me.txtUnderwriting_ExclusionClause_Code.Text.Trim & "'"


                Dim ds_Search_Param As New DataSet


                Dim da_ExclusionClause As New SqlDataAdapter(cmdSearch_Parameter)


                da_ExclusionClause.Fill(ds_Search_Param, "dt_Underwriting_ExclusionClause")

                With ds_Search_Param.Tables("dt_Underwriting_ExclusionClause")
                    If .Rows.Count > 0 Then
                        Me.txtUnderwriting_ExclusionClause_Header.Text = .Rows(0).Item("ExclusionClause_Header") & " "
                        Me.txtUnderwriting_ExclusionClause_Footer.Text = .Rows(0).Item("ExclusionClause_Footer") & " "
                    Else
                        MsgBox("Error in retrieving Exclusion Clause")
                        Exit Sub
                    End If
                End With
                Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                    Case "E17", "E19", "E21", "E31", "E34"
                        Me.txtUnderwriting_Other_Parameters.Clear()
                        Me.txtUnderwriting_Other_Parameters.Enabled = True
                    Case Else
                        Me.txtUnderwriting_Other_Parameters.Clear()
                        Me.txtUnderwriting_Other_Parameters.Enabled = False
                End Select
            End If
            Me.btnDependent.Enabled = True
            Me.chkUnderwriting_ApplyTo.Enabled = True
        End If
    End Sub
    Private Sub btnDependent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDependent.Click
        Dim frmSearch_Dependents As New frmSearch_Param
        frmSearch_Dependents.lblForm_Flag.Text = "SC"
        With frmSearch_Dependents.dgvFind_Result
            .Columns.Add("Col1", "Full Name As in NRIC")
            .Columns.Add("Col2", "Relationship")
            .Rows.Clear()
            Dim id As String
            If Me.lblGUID.Text = "" Then
                id = Me.lblMember_Policy_ID.Text.Trim()
            Else
                id = Me.lblGUID.Text
            End If
            Dim var_dependent_count As Integer = 0
            Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect.CommandType = CommandType.Text
            cmdSelect.CommandText = "SELECT Full_Name, RelationShip  FROM dt_Member_Policy_Dependents WHERE Member_Policy_ID='" & id & "'"
            Dim adp As New SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            adp.Fill(ds, "dt_Member_Policy_Dependents")
            For Each dr As DataRow In ds.Tables(0).Rows
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = dr("Full_Name")
                .Rows(.Rows.Count - 1).Cells(1).Value = dr("RelationShip")
            Next
        End With
        frmSearch_Dependents.ShowDialog()
        Me.txtUnderwriting_ApplyTo.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Not Len(Me.txtRemarks.Text.Trim()) > 0 Then
                MsgBox("Please do key reason for delete!")
                Me.txtRemarks.Focus()
                Exit Sub
            End If
            If MsgBox("Are you sure you want delete this Exclusion Clause?", vbYesNo, "MEMBER") = vbYes Then
                Dim sRes As String
                sRes = objBusi.Delete("MEMBER", Me.lblExclusionClause_ID.Text, "", "", "", "", "", "", "", "", "EC", Conn)
                If sRes = "1" Then
                    If Me.lblAdmin.Text = "Admin" Then
                        Me.objBusi.aLog(Me.lblMember_Policy_ID.Text.Trim(), "Deleted Exclusion Clause " & Me.txtUnderwriting_ExclusionClause_Code.Text.Trim() & " User ID : " & My.Settings.Username & " ", Conn)
                    Else
                        Me.objBusi.Log(Me.lblMember_Policy_ID.Text(), "Deleted Exclusion Clause " & Me.txtUnderwriting_ExclusionClause_Code.Text.Trim() & " User ID : " & My.Settings.Username & " ", Conn)
                        Me.objBusi.EndorsementLog(Me.lblMemberID.Text.ToString().Trim(), Me.lblMember_Policy_ID.Text.ToString().Trim(), "E", "Deleted  Exclusion Clause :  " & Me.txtUnderwriting_ExclusionClause_Code.Text.Trim() & " " & Me.txtUnderwriting_ExclusionClause_Header.Text.Trim() & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.ToString.Trim() & " " & Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss") & "Remarks : " & Me.txtRemarks.Text.Trim(), Now(), "", Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss"), Me.txtUnderwriting_ApplyTo.Text.ToString.Trim(), "DELETE EXCLUSION CLAUSE", Conn)
                    End If
                    MsgBox("Successfully deleted the Exclusion Clause!")
                    Me.Close()
                Else
                    MsgBox("Error while deleting Exclusion Clause, Please try again later!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Server busy, Please try again later!")
        End Try
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function chkValidate() As Boolean
        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) = 0 Then
            MsgBox("Please do select Exclusion Caluse code")
            Return False
        End If
        If Me.chkUnderwriting_ApplyTo.Checked = False Then
            If Len(Me.txtUnderwriting_ApplyTo.Text.Trim()) = 0 Then
                MsgBox("Please do key in apply to")
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub Clear_All()
        Me.txtUnderwriting_Other_Parameters.Text = ""
    End Sub
#End Region
#Region "INSERT"
    Private Sub ins_ExclusionClause()
        Dim sRes, E_Code, EC As String
        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) = 0 Then
            Exit Sub
        Else
            Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                Case "E17", "E19", "E21", "E31", "E34"
                    If Len(Me.txtUnderwriting_Other_Parameters.Text.Trim) = 0 Then
                        MsgBox("Please do key in the Other Parameters field")
                        Exit Sub
                    End If
            End Select
            Dim APPLYTO As String
            E_Code = Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
            Select Case E_Code
                Case "E17", "E19", "E21", "E31"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.lblMemberName.Text.Trim & " "
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case "E33"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.lblMemberName.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case "E34"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.lblMemberName.Text.Trim & " "
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case Else
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.lblMemberName.Text.Trim
                        APPLYTO = Me.lblMemberName.Text.Trim
                    ElseIf Not Me.txtUnderwriting_ApplyTo.Text.Trim() = "" Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    Else
                        MsgBox("Please do select apply to")
                        Exit Sub
                    End If
            End Select
            sRes = objBusi.INSUPSEC("INS", Guid.NewGuid.ToString.Trim(), Me.lblGUID.Text.Trim(), E_Code, EC, Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), APPLYTO, My.Settings.Username, Conn)
            If Me.lblAdmin.Text = "Admin" Then
                Me.objBusi.aLog(Me.lblGUID.Text, "Adding New Exclusion Clause. By User ID : " & My.Settings.Username & " ", Conn)
            Else
                Me.objBusi.Log(Me.lblGUID.Text, "Adding New Exclusion Clause. By User ID : " & My.Settings.Username & " ", Conn)
                Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblGUID.Text, "E", "Adding New Exclusion Clause. Exclusion Clause Code:  " & E_Code & " Exclusion Clause : " & EC & "", Now(), "ADD EXCLUSION CLAUSE", dtpEffectiveDate.Value, APPLYTO, "ADD EXCLUSION CLAUSE", Conn)
            End If

            If sRes = "1" Then
                MsgBox("Successfully Inserted Exclusion Clause")
                Clear_All()
                Me.Close()
            Else
                MsgBox("Error while Inserting Exclusion Clause")
            End If
        End If
    End Sub
#End Region
#Region "UPDATE"
    Private Sub ups_ExclusionClause()
        Dim sRes, E_Code, EC As String
        If Len(Me.txtUnderwriting_ExclusionClause_Code.Text.Trim) = 0 Then
            Exit Sub
        Else
            Select Case Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
                Case "E17", "E19", "E21", "E31", "E34"
                    If Len(Me.txtUnderwriting_Other_Parameters.Text.Trim) = 0 Then
                        MsgBox("Please do key in the Other Parameters field")
                        Exit Sub
                    End If
            End Select
            E_Code = Me.txtUnderwriting_ExclusionClause_Code.Text.Trim
            Dim APPLYTO As String
            Select Case E_Code
                Case "E17", "E19", "E21", "E31"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " "
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case "E33"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " "
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim & " " & Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case "E34"
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " "
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & _
                                                                Me.txtUnderwriting_Other_Parameters.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ExclusionClause_Footer.Text.Trim & " " & _
                                                                Me.txtUnderwriting_ApplyTo.Text.Trim & " "
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
                Case Else
                    If Me.chkUnderwriting_ApplyTo.Checked = True Then
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim
                        APPLYTO = Me.lblMemberName.Text.Trim
                    Else
                        EC = Me.txtUnderwriting_ExclusionClause_Header.Text.Trim & " " & Me.txtUnderwriting_ApplyTo.Text.Trim
                        APPLYTO = Me.txtUnderwriting_ApplyTo.Text.Trim
                    End If
            End Select
            sRes = objBusi.INSUPSEC("UPS", Me.lblExclusionClause_ID.Text.Trim(), Me.lblExclusionClause_ID.Text.Trim(), E_Code, EC, Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), APPLYTO, My.Settings.Username, Conn)
            If Me.lblAdmin.Text = "Admin" Then
                Me.objBusi.aLog(Me.lblMember_Policy_ID.Text, "Updating Exclusion Clause  By User ID : " & My.Settings.Username & " ", Conn)
            Else
                Me.objBusi.Log(Me.lblMember_Policy_ID.Text, "Updating Exclusion Clause  By User ID : " & My.Settings.Username & " ", Conn)
                Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblMember_Policy_ID.Text, "E", "Updating Exclusion Clause. Exclusion Clause Code :  " & E_Code & " Exclusion Clause : " & EC & "", Now(), "CHAGE OF EXCLUSION CLAUSE", dtpEffectiveDate.Value, APPLYTO, "CHAGE OF EXCLUSION CLAUSE", Conn)
            End If
            If sRes = "1" Then
                MsgBox("Successfully Updated Exclusion Clause")
                Clear_All()
                Me.Close()
            Else
                MsgBox("Error while updating Exclusion Clause")
            End If
        End If
    End Sub
#End Region
#Region "Change Eevents"
    Private Sub chkUnderwriting_ApplyTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnderwriting_ApplyTo.CheckedChanged
        If Me.chkUnderwriting_ApplyTo.Checked Then
            Me.btnDependent.Enabled = False
            Me.txtUnderwriting_ApplyTo.Text = ""
        Else
            Me.btnDependent.Enabled = True
        End If
    End Sub
    Private Sub txtUnderwriting_ApplyTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnderwriting_ApplyTo.TextChanged
        If Len(Me.txtUnderwriting_ApplyTo.Text.Trim()) > 0 Then
            Me.chkUnderwriting_ApplyTo.Enabled = False
        Else
            Me.chkUnderwriting_ApplyTo.Enabled = True
            Me.txtUnderwriting_ApplyTo.Text = ""
        End If
    End Sub
#End Region
End Class